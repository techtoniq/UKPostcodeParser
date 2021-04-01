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
            postcode.District.Should().Be("1");
            postcode.Sector.Should().Be("2");
            postcode.Unit.Should().Be("NS");

            postcode.OutwardCode.Should().Be("B1");
            postcode.InwardCode.Should().Be("2NS");
        }

        [Test]
        public void Validate_Format2()
        {
            var valueUnderTest = "M60 1NW";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("M");
            postcode.District.Should().Be("60");
            postcode.Sector.Should().Be("1");
            postcode.Unit.Should().Be("NW");

            postcode.OutwardCode.Should().Be("M60");
            postcode.InwardCode.Should().Be("1NW");
        }

        [Test]
        public void Validate_Format3()
        {
            var valueUnderTest = "CR2 6XH";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("CR");
            postcode.District.Should().Be("2");
            postcode.Sector.Should().Be("6");
            postcode.Unit.Should().Be("XH");

            postcode.OutwardCode.Should().Be("CR2");
            postcode.InwardCode.Should().Be("6XH");
        }

        [Test]
        public void Validate_Format4()
        {
            var valueUnderTest = "RH10 1SL";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("RH");
            postcode.District.Should().Be("10");
            postcode.Sector.Should().Be("1");
            postcode.Unit.Should().Be("SL");

            postcode.OutwardCode.Should().Be("RH10");
            postcode.InwardCode.Should().Be("1SL");
        }

        [Test]
        public void Validate_Format5()
        {
            var valueUnderTest = "W1A 0AX";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("W");
            postcode.District.Should().Be("1A");
            postcode.Sector.Should().Be("0");
            postcode.Unit.Should().Be("AX");

            postcode.OutwardCode.Should().Be("W1A");
            postcode.InwardCode.Should().Be("0AX");
        }

        [Test]
        public void Validate_Format6()
        {
            var valueUnderTest = "EC1M 1BB";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("EC");
            postcode.District.Should().Be("1M");
            postcode.Sector.Should().Be("1");
            postcode.Unit.Should().Be("BB");

            postcode.OutwardCode.Should().Be("EC1M");
            postcode.InwardCode.Should().Be("1BB");
        }

        [Test]
        public void Validate_FormatIsCaseInsensitive()
        {
            var valueUnderTest = "b1 2ns";

            var postcode = new UKPostcode(valueUnderTest);

            postcode.Area.Should().Be("b");
            postcode.District.Should().Be("1");
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