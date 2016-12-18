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


namespace clojure.lang
{
    /// <summary>
    /// Represents an immutable collection.
    /// </summary>
    /// <remarks>
    /// <para>Lowercase-named methods for compatibility with JVM code.</para>
    /// </remarks>
    public interface IPersistentCollection : Seqable
    {
        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        /// <returns>The number of items in the collection.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "count")]
        int count();

        /// <summary>
        /// Returns a new collection that has the given element cons'd on front of the existing collection.
        /// </summary>
        /// <param name="o">An item to put at the front of the collection.</param>
        /// <returns>A new immutable collection with the item added.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "cons")]
        IPersistentCollection cons(object o);

        /// <summary>
        /// Gets an empty collection of the same type.
        /// </summary>
        /// <returns>An emtpy collection.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "empty")]
        IPersistentCollection empty();

        /// <summary>
        /// Determine if an object is equivalent to this (handles all collections).
        /// </summary>
        /// <param name="o">The object to compare.</param>
        /// <returns><c>true</c> if the object is equivalent; <c>false</c> otherwise.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "equiv")]

        bool equiv(object o);
    }
}
