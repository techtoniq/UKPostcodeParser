using FluentAssertions;
using NUnit.Framework;
using System;

namespace UKPostcodeParser.Test
{
    [TestFixture]
    public class UKPostcodeTests
    {
        [Test]
        public void Validate_Format1()
        {
            var valueUnderTest = "B1 2NS";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("B");
            postcode.DistrictCode.Should().Be("1");
            postcode.District.Should().Be("B1");
            postcode.Sector.Should().Be("2");
            postcode.Unit.Should().Be("NS");
        }

        [Test]
        public void Validate_Format2()
        {
            var valueUnderTest = "M60 1NW";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("M");
            postcode.DistrictCode.Should().Be("60");
            postcode.District.Should().Be("M60");
            postcode.Sector.Should().Be("1");
            postcode.Unit.Should().Be("NW");
        }

        [Test]
        public void Validate_Format3()
        {
            var valueUnderTest = "CR2 6XH";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("CR");
            postcode.DistrictCode.Should().Be("2");
            postcode.District.Should().Be("CR2");
            postcode.Sector.Should().Be("6");
            postcode.Unit.Should().Be("XH");
        }

        [Test]
        public void Validate_Format4()
        {
            var valueUnderTest = "RH10 1SL";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("RH");
            postcode.DistrictCode.Should().Be("10");
            postcode.District.Should().Be("RH10");
            postcode.Sector.Should().Be("1");
            postcode.Unit.Should().Be("SL");
        }

        [Test]
        public void Validate_Format5()
        {
            var valueUnderTest = "W1A 0AX";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("W");
            postcode.DistrictCode.Should().Be("1A");
            postcode.District.Should().Be("W1A");
            postcode.Sector.Should().Be("0");
            postcode.Unit.Should().Be("AX");
        }

        [Test]
        public void Validate_Format6()
        {
            var valueUnderTest = "EC1M 1BB";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("EC");
            postcode.DistrictCode.Should().Be("1M");
            postcode.District.Should().Be("EC1M");
            postcode.Sector.Should().Be("1");
            postcode.Unit.Should().Be("BB");
        }

        [Test]
        public void Validate_FormatIsCaseInsensitive()
        {
            var valueUnderTest = "b1 2ns";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("b");
            postcode.DistrictCode.Should().Be("1");
            postcode.District.Should().Be("b1");
            postcode.Sector.Should().Be("2");
            postcode.Unit.Should().Be("ns");
        }

        [Test]
        public void Validate_InvalidFormatThrowsException()
        {
            var valueUnderTest = "B1 2NST";

            Action act = () => { var postcode = new UKPostcode(valueUnderTest); };

            act.Should().Throw<ArgumentException>()
                .WithMessage("Invalid postcode format");
        }
    }
}