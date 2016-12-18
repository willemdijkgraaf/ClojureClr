﻿/**
 *   Copyright (c) Rich Hickey. All rights reserved.
 *   The use and distribution terms for this software are covered by the
 *   Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
 *   which can be found in the file epl-v10.html at the root of this distribution.
 *   By using this software in any fashion, you are agreeing to be bound by
 * 	 the terms of this license.
 *   You must not remove this notice, or any other, from this software.
 **/

/**
 *   Author: David Miller
 **/

using System;
using System.Collections;
using System.Runtime.Serialization;

namespace clojure.lang
{
    [Serializable]
    public class EnumeratorSeq : ASeq, ISerializable
    {
        #region Nested classes

        sealed class State
        {
            internal volatile object _val;
            internal volatile object _rest;
        }

        #endregion

        #region Data

        readonly IEnumerator _enumerator;
        readonly State _state;

        #endregion
        
        #region C-tors & factory methods

        // TODO: Rethink this now that we have the lazy version of clojure.

        // There's no way to do this properly.  
        // If the enumerator is uninitialized, we have to do a move next to see if there is an element.
        // If the enumerator is initialized, we should see if calling Current throws an exception.  Sigh.
        // Okay, try this:  access Current.  If it blows, assume we are not initialized.
        // Okay, that takes a _long_ time.  Lots of Exceptions thrown/caught.
        // Maybe the new lazy version will solve this.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "create")]
        public static EnumeratorSeq create(IEnumerator enumerator)
        {
            //bool hasElement = true;

            //try {

            //    object o = enumerator.Current;
            //}
            //catch ( InvalidOperationException )
            //{
            //    // we are before the beginning.
            //    hasElement = enumerator.MoveNext();
            //}

            bool hasElement = enumerator.MoveNext();

            return hasElement
                ? new EnumeratorSeq(enumerator)
                : null;
        }

        public EnumeratorSeq(IEnumerator enumerator)
        {
            _enumerator = enumerator;
            _state = new State();
            _state._val = _state;
            _state._rest = _state;
        }

        EnumeratorSeq(IPersistentMap meta, IEnumerator enumerator, State state)
            : base(meta)
        {
            _enumerator = enumerator;
            _state = state;
        }

        /// <summary>
        /// Construct an EnumeratorSeq during deserialization.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected EnumeratorSeq (SerializationInfo info, StreamingContext context)
        {
            throw new SerializationException("Serialization not supported for EnumeratorSeq"); 
        }


        #endregion

        #region ISeq members

        public override object first()
        {
            if (_state._val == _state)
                lock (_state)
                {
                    if (_state._val == _state)
                        _state._val = _enumerator.Current;
                }
            return _state._val;
        }

        public override ISeq next()
        {
            if ( _state._rest == _state )
                lock (_state)
                {
                    if (_state._rest == _state)
                    {
                        first();
                        _state._rest = _enumerator.MoveNext() ? new EnumeratorSeq(_enumerator) : null;
                        // Java: _state._rest = create(_enumerator);

                    }
                }
            return (ISeq)_state._rest;
        }

        #endregion

        #region IObj members

        public override IObj withMeta(IPersistentMap meta)
        {
            // Java: no check
            return meta == _meta
                ? this
                : new EnumeratorSeq(meta, _enumerator, _state);
        }

        #endregion

        #region ISerializable Members

        [System.Security.SecurityCritical]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new SerializationException("Serialization not supported for EnumeratorSeq");
        }

        #endregion
    }
}
