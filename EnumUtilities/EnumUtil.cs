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
using System.Reflection;
using System.ComponentModel;
using System.Globalization;


namespace Ekstrand
{
    /// <summary>
    /// Collection of enumeration operations
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// Returns the description value from a DescriptionAttribute field.
        /// </summary>
        /// <param name="value">Enum type</param>
        /// <returns>Returns String DescriptionAttribute value otherwise the enumeration type string name.</returns>
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                 (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute),
                 false);

            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Return the custom attribute called TextAttribute text value.
        /// </summary>
        /// <param name="value">Enumeration type element</param>
        /// <returns>Returns the TextAttribute value otherwise the Enumeration type string value.</returns>
        /// <remarks>This would require the custom TextAttribute class with in Ekstrand name space.</remarks>
        public static string GetEnumTextAttribute(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            TextAttribute[] attributes = (TextAttribute[])fi.GetCustomAttributes(typeof(TextAttribute), false);

            return (attributes.Length > 0) ? attributes[0].TextValue : value.ToString();
        }

        /// <summary>
        /// Returns a list of enumeration type element
        /// </summary>
        /// <typeparam name="T">Enumeration type</typeparam>
        /// <returns>Returns a list of enumeration type element otherwise returns an empty list.</returns>
        public static List<T> EnumList<T>()
        {
            List<T> list = new List<T>();

            Type type = typeof(T);

            if (!type.IsEnum) { return list; } // soft error

            Array arrlst = Enum.GetValues(type);

            foreach (int val in arrlst)
            {
                list.Add((T)Enum.Parse(type, val.ToString()));
            }

            return list;
        }

        /// <summary>
        /// Returns total number of elements in an enumeration type.
        /// </summary>
        /// <typeparam name="T">Enumeration type</typeparam>
        /// <returns>Returns the number of elements in a given enumeration type otherwise -1</returns>
        public static int EnumCount<T>()
        {
            Type t = typeof(T);

            if (!t.IsEnum) { return -1; } // soft error
             
            Array names = Enum.GetNames(t);
            return names.Length;
        }


        /// <summary>
        /// Return enumeration type element based on description attribute value.
        /// </summary>
        /// <typeparam name="T">Enumeration type</typeparam>
        /// <param name="description">String description attribute value</param>
        /// <returns>Returns the enumeration type element based on its description attribute string value, otherwise; return default base enumeration type element.</returns>
        public static T EnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) { throw new InvalidOperationException(); }
            
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                    { return (T)field.GetValue(null); }
                }
                else
                {
                    if (field.Name == description)
                    { return (T)field.GetValue(null); }
                }
            }

            return default(T); // enum int value min
        }


        /// <summary>
        /// Returns a list of each enumeration type element name constant.
        /// </summary>
        /// <typeparam name="T">Enumeration type</typeparam>
        /// <returns>Return a list of string containing the enumeration type name constant otherwise empty list.</returns>
        public static List<string> EnumToStringList<T>()
        {
            List<string> list = new List<string>();

            Type t = typeof(T);
            if (!t.IsEnum) { return list; }       

            Array names = Enum.GetNames(t);

            foreach (string itemName in names)
            { list.Add(itemName); }

            return list;
        }

    }

}
