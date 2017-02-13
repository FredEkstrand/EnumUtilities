/*
Open source MIT License
Copyright(c) 2017 Fred A Ekstrand Jr.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

YA26-20M14-9Y4B2-E3803-ZF44E-14B1R-U24V
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ekstrand
{
    /// <summary>
    /// Custom attribute used for custom text.
    /// </summary>
    /// <remarks>
    /// This attribute intended for strings that would be seen by end users.
    /// </remarks>
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public class TextAttribute : System.Attribute
    {
        private string m_Text = string.Empty;

        /// <summary>
        /// Text to be associated with object target.
        /// </summary>
        /// <param name="text">String formatted text</param>
        public TextAttribute(string text)
        {
            this.m_Text = text;
        }

        /// <summary>
        /// Get/Set TextAttribute value
        /// </summary>
        public string TextValue
        {
            get { return m_Text; }
            set { this.m_Text = value; }
        }
    }
}
