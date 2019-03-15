﻿/*

Updated: 2009/10/21

2009/10/21  Andreas Nägeli        Initial version of this file.


LICENSE: This file is part of the GenHTTP webserver.

GenHTTP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
any later version.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GenHTTP.Abstraction.Elements.Containers;

namespace GenHTTP.Abstraction.Elements.Collections {
  
  /// <summary>
  /// Allows you to add links to a container.
  /// </summary>
  public class LinkCollection : ILinkContainer {
    private AddElement _Delegate;

    #region Constructors

    /// <summary>
    /// Create a new link collection.
    /// </summary>
    /// <param name="d">The delegate which allows us to add elements to the container</param>
    public LinkCollection(AddElement d) {
      _Delegate = d;
    }

    #endregion

    #region ILinkContainer Members

    /// <summary>
    /// Add an empty link.
    /// </summary>
    /// <returns>The created object</returns>
    public Link AddLink() {
      Link lnk = new Link();
      _Delegate(lnk);
      return lnk;
    }

    /// <summary>
    /// Add a new link.
    /// </summary>
    /// <param name="url">The URL to link</param>
    /// <returns>The created object</returns>
    public Link AddLink(string url) {
      Link lnk = new Link(url);
      _Delegate(lnk);
      return lnk;
    }

    /// <summary>
    /// Add a new link.
    /// </summary>
    /// <param name="url">The URL to link</param>
    /// <param name="linkText">The link text</param>
    /// <returns>The created object</returns>
    public Link AddLink(string url, string linkText) {
      Link lnk = new Link(url, linkText);
      _Delegate(lnk);
      return lnk;
    }

    /// <summary>
    /// Add a new link.
    /// </summary>
    /// <param name="url">The URL to link</param>
    /// <param name="element">The link element</param>
    /// <returns>The created object</returns>
    public Link AddLink(string url, Element element) {
      Link lnk = new Link(url, element);
      _Delegate(lnk);
      return lnk;
    }

    #endregion
  }

}