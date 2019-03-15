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

namespace GenHTTP.Abstraction.Elements {
  
  /// <summary>
  /// Defines the type of a button.
  /// </summary>
  public enum ButtonType {
    /// <summary>
    /// A submit button.
    /// </summary>
    Submit,
    /// <summary>
    /// A reset button.
    /// </summary>
    Reset,
    /// <summary>
    /// A button without special functionality.
    /// </summary>
    Button
  }

}