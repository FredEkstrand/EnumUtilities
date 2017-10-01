using System;
using NUnit.VisualStudio.TestAdapter;
using NUnit.Framework;
using Ekstrand;
using System.Collections.Generic;


namespace EnumExtensionsTester
{
    [TestFixture]
    public class UnitTest1
    {
        #region Test Enums

        public enum BadTypes
        {
            Bad = -2,
            VeryBad = -1234,
            NotSoBad = 0,
            MightBeBad = 385773,
            JustPlaneOdd = MightBeBad | NotSoBad | VeryBad // 384539

        }

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

        [Flags]
        public enum DockPosition
        {
            [TextAttribute("Top Left")]
            [System.ComponentModel.Description("Dock to Top Left")]
            TopLeft         = 0x1,
            [TextAttribute("Top Right")]
            [System.ComponentModel.Description("Dock to Top Right")]
            TopRight        = 0x2,
            [TextAttribute("Bottom Left")]
            [System.ComponentModel.Description("Dock to Bottom Left")]
            BottomLeft      = 0x4,
            [TextAttribute("Bottom Right")]
            [System.ComponentModel.Description("Dock to Bottom Right")]
            BottomRight     = 0x8,
            [TextAttribute("All")]
            [System.ComponentModel.Description("Dock to All sides")]
            All             = 0x10
        }

        #endregion

        #region EnumCount Test Sets

        [Test]
        [Category("EnumCount Test Sets")]
        public void EnumCountTest()
        {
            int count = EnumUtil.EnumCount<DivisionLeagTypes>();
            Assert.AreEqual(8, count);
        }

        #endregion

        #region EnumToList Test Sets

        [Test]
        [Category("EnumToList Test Sets")]
        public void EnumListTest()
        {
            var items = EnumUtil.EnumList<DivisionLeagTypes>();
            Enum en = items[1];
            Assert.AreEqual(DivisionLeagTypes.AE.GetType().Name, items[1].GetType().Name);
        }

        [Test]
        [Category("EnumToList Test Sets")]
        public void EnumListCountTest()
        {
            var items = EnumUtil.EnumList<DivisionLeagTypes>();
            
            Assert.AreEqual(8, items.Count);
        }

        #endregion

        #region EnumValueFromDescription Test Sets

        [Test]
        [Category("EnumValueFromDescription Test Sets")]
        public void EnumValueFromDescriptionTest()
        {
             DockPosition dock = EnumUtil.EnumValueFromDescription<DockPosition>("Dock to All sides");

            Assert.AreEqual(DockPosition.All, dock);
        }

        [Test]
        [Category("EnumValueFromDescription Test Sets")]
        public void EnumValueFromDescriptionMissingAttributeFieldTest()
        {
            BadTypes result = EnumUtil.EnumValueFromDescription<BadTypes>("Very Bad");

            Assert.AreEqual(BadTypes.NotSoBad, result);
        }

        #endregion

        #region GetEnumTextAttribute Test Set

        [Test]
        [Category("GetEnumTextAttribute Test Set")]
        public void GetEnumTextAttributeMissingAttributeFieldTest()
        {
            string result = BadTypes.VeryBad.GetEnumTextAttribute();

            Assert.AreEqual("VeryBad", result);
        }

        [Test]
        [Category("GetEnumTextAttribute Test Set")]
        public void GetEnumTextAttributeTest()
        {
            string result = DivisionLeagTypes.AE.GetEnumTextAttribute();

            Assert.AreEqual("AFC East", result);
        }

        #endregion

    }
}
