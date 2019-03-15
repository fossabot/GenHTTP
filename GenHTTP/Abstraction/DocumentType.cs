﻿/*

Updated: 2009/10/14

2009/10/14  Andreas Nägeli        Initial version of this file.


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

namespace GenHTTP.Abstraction {

  /// <summary>
  /// This enum describes the different document types, the
  /// GenHTTP object framework does support.
  /// </summary>
  /// <remarks>
  /// The type of a document will influence the behaviour
  /// and the presentation of the document. For more
  /// information, see the pages of the W3C:
  /// 
  /// <see href="http://www.w3.org/TR/html4/">HTML 4.01 Specification</see>
  /// <see href="http://www.w3.org/TR/xhtml1/">XHTML™ 1.0 The Extensible HyperText Markup Language</see>
  /// 
  /// Please note, that the GenHTTP object framework does neither
  /// support framesets nor HTML 5. These standards will maybe
  /// follow in later versions.
  /// </remarks>
  public enum DocumentType {
    /// <summary>
    /// Excludes presentation attributes and elements.
    /// </summary>
    Html_4_01_Strict,
    /// <summary>
    /// Includes presentation attributes and elements.
    /// </summary>
    Html_4_01_Transitional,
    /// <summary>
    /// Same as HTML 4.01 strict, but with a XML parseable
    /// structure. Recommended.
    /// </summary>
    XHtml_1_1_Strict,
    /// <summary>
    /// Same as HTML 4.01 transitional, but with a XML parseable
    /// structure.
    /// </summary>
    XHtml_1_1_Transitional
  }

}