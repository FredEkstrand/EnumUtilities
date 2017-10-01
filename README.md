![Project type](https://github.com/FredEkstrand/ImageFiles/raw/master/CodeIcon.png ) 

![Version 1.0.0](https://img.shields.io/badge/Version-1.0.0-brightgreen.svg) ![Licence MIT](https://img.shields.io/badge/Licence-MIT-blue.svg)
[![codecov](https://codecov.io/gh/FredEkstrand/EnumUtilities/branch/master/graph/badge.svg)](https://codecov.io/gh/FredEkstrand/EnumUtilities)

# Overview

A collection of Enumeration operations.

#### Features
The EnumUtilities have the following features:
* GetEnumDescription: Returns the description value from a DescriptionAttribute field.
* GetEnumTextAttribute: Return the custom attribute called TextAttribute text value.
* EnumList: Returns a list of enumeration of the given enumeration type.
* EnumCount: Returns total number of elements in an enumeration type.
* EnumValueFromDescription: Return enumeration type element based on description attribute value.
* EnumToStringList: Returns a List of each enumeration type element name constant.
* TextAttribute: Allow a string of text to be associated with the enum element.

## Download
The souce code and provided DLL is written in C# and targeted for the .Net Framework 4.0 and later.
You can download the DLL [here](http://fredekstrand.github.io/EnumUtilities).

## Getting started
Once downloaded add a reference to the dll in your Visual Studio project.
Then in your code file add the following to the collection of using statement.
```csharp
using Ekstrand.Text;
```
### Code

```csharp
 public enum DivisionLeagTypes
{
    [TextAttribute("AFC East")]
    AE,
    [TextAttribute("AFC West")]
    AW,
    [TextAttribute("AFC South")]
    AS,
    [TextAttribute("AFC North")]
    AN,

    [TextAttribute("NFC East")]
    NE,
    [TextAttribute("NFC West")]
    NW,
    [TextAttribute("NFC South")]
    NS,
    [TextAttribute("NFC North")]
    NN
}

[Some method]
{
    var items = EnumUtil.EnumList<DivisionLeagTypes>();
    foreach(DivisionLeagTypes en in items)
    {
        string text = en.GetEnumTextAttribute();
        Console.WriteLine(en.GetEnumTextAttribute());
        ...
    }
    ...
}
```

## Documentation
Documentation can be found [here](http://fredekstrand.github.io/EnumUtilities). 

## History
 1.0.0 Initial release into the wild.

## Contributing

If you'd like to contribute, please fork the repository and use a feature
branch. Pull requests are always welcome.

## Contact
Fred Ekstrand 
email: fredekstrandgithub@gmail.com
## Licensing

The code in this project is licensed under MIT license.

