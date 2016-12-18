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

using Microsoft.Scripting;

namespace clojure.lang.CljCompiler.Ast
{
    // TODO: Remove Node class

    /*
    /// <summary>
    /// Base class for AST expressions in the compiler.
    /// </summary>
    /// <remarks>Stolen from IronPython.</remarks>
    public abstract class Node
    {
        #region Data

        private Microsoft.Scripting.SourceLocation _start = SourceLocation.Invalid;
        private Microsoft.Scripting.SourceLocation _end = SourceLocation.Invalid;

        #endregion

        #region Location methods

        public void SetLoc(SourceLocation start, SourceLocation end)
        {
            _start = start;
            _end = end;
        }

        public void SetLoc(SourceSpan span)
        {
            _start = span.Start;
            _end = span.End;
        }

        public SourceLocation Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public SourceLocation End
        {
            get { return _end; }
            set { _end = value; }
        }

        public SourceSpan Span
        {
            get
            {
                return new SourceSpan(_start, _end);
            }
        }

        #endregion
    }
     */
}
