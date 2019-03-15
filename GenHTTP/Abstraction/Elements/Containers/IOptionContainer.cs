﻿/*

Updated: 2009/10/23

2009/10/23  Andreas Nägeli        Initial version of this file.


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

namespace GenHTTP.Abstraction.Elements.Containers {

  /// <summary>
  /// Defines methods, which should be implemented by
  /// containers with option elements.
  /// </summary>
  public interface IOptionContainer {

    /// <summary>
    /// Add an option to this element.
    /// </summary>
    /// <param name="content">The description of the element</param>
    /// <returns>The created object</returns>
    Option AddOption(string content);

    /// <summary>
    /// Add an option to this element.
    /// </summary>
    /// <param name="content">The description of the element</param>
    /// <param name="selected">Specifies, whether the list entry should be selected</param>
    /// <returns>The created object</returns>
    Option AddOption(string content, bool selected);

    /// <summary>
    /// Add an option to this element.
    /// </summary>
    /// <param name="content">The description of the element</param>
    /// <param name="value">The value of the element</param>
    /// <returns>The created object</returns>
    Option AddOption(string content, string value);

    /// <summary>
    /// Add an option to this element.
    /// </summary>
    /// <param name="content">The description of the element</param>
    /// <param name="value">The value of the element</param>
    /// <param name="selected">Specifies, whether the list entry should be selected</param>
    /// <returns>The created object</returns>
    Option AddOption(string content, string value, bool selected);

    /// <summary>
    /// Add an option to this element.
    /// </summary>
    /// <param name="content">The description of the element</param>
    /// <param name="value">The value of the element</param>
    /// <param name="label">The label of the element</param>
    /// <returns>The created object</returns>
    Option AddOption(string content, string value, string label);

    /// <summary>
    /// Add an option to this element.
    /// </summary>
    /// <param name="content">The description of the element</param>
    /// <param name="value">The value of the element</param>
    /// <param name="label">The label of the element</param>
    /// <param name="selected">Specifies, whether the list entry should be selected</param>
    /// <returns>The created object</returns>
    Option AddOption(string content, string value, string label, bool selected);

  }

}