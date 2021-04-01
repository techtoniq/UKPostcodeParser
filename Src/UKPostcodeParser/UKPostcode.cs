﻿using System;
using System.Text.RegularExpressions;

namespace UKPostcodeParser
{
    public class UKPostcode
    {
        private string outwardArea = string.Empty;
        private string outwardDistrictCode = string.Empty;
        private string inwardSector = string.Empty;
        private string inwardUnit = string.Empty;

        public string Area { get { return outwardArea; } }
        public string DistrictCode { get { return outwardDistrictCode; } }
        public string District { get { return $"{Area}{DistrictCode}"; } }
        public string Sector { get { return inwardSector; } }
        public string Unit { get { return inwardUnit; } }

        public override string ToString()
        {
            return $"{Area}{DistrictCode} {Sector}{Unit}";
        }

        public UKPostcode(string postcode)
        {
            if (string.IsNullOrWhiteSpace(postcode)) throw new ArgumentException("Missing postcode");

            if(!IsValidFormat(postcode))
            {
                throw new ArgumentException("Invalid postcode format");
            }

            ParsePostcode(postcode);
        }

        private bool IsValidFormat(string postcode)
        {
            //  https://stackoverflow.com/questions/164979/regex-for-matching-uk-postcodes
            Match m = Regex.Match(postcode, @"^([A-Z][A-HJ-Y]?\d[A-Z\d]? ?\d[A-Z]{2}|GIR ?0A{2})$", RegexOptions.IgnoreCase);
            return m.Success;
        }

        private void ParsePostcode(string postcode)
        {
            int outwardInwardBreakPos = postcode.IndexOf(" ");
            if (-1 == outwardInwardBreakPos) throw new ArgumentException("Missing space between outward and inward sections of postcode");

            int charPos = 0;
            while(charPos < outwardInwardBreakPos)
            {
                if(char.IsLetter(postcode[charPos]) && string.IsNullOrWhiteSpace(outwardDistrictCode))
                {
                    outwardArea += postcode[charPos];
                }
                else
                {
                    outwardDistrictCode += postcode[charPos];
                }
                charPos++;
            }

            charPos = outwardInwardBreakPos + 1;
            while (charPos < postcode.Length)
            {
                if (char.IsDigit(postcode[charPos]))
                {
                    inwardSector += postcode[charPos];
                }
                else
                {
                    inwardUnit += postcode[charPos];
                }
                charPos++;
            }

        }
    }
}