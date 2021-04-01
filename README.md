# UKPostcodeParser
This class will validate the format of a UK postcode string, and break it out in to its constituent parts:

<table>
  <tr>
    <td align="center" colspan="4">UK Postcode</td>
  </tr>
  <tr>
    <td align="center" colspan="2">Outward Code</td>
    <td align="center" colspan="2">Inward Code</td>
  </tr>
  <tr>
    <td align="center">Area</td>
    <td align="center">District</td>
    <td align="center">Sector</td>
    <td align="center">Unit</td>
  </tr>
</table>

The class validates the following postcode formats, where A signifies a letter and 9 a digit:

| Format | Example |
| --- | --- |
| AA9A 9AA | EC1A 1BB |
| A9A 9AA | W1A 0AX |
| A9 9AA | M1 1AE |
| A99 9AA | B33 8TH |
| AA9 9AA | CR2 6XH |
| AA99 9AA | DN55 1PT |

Based on information in the Wikipedia article here:  https://en.wikipedia.org/wiki/Postcodes_in_the_United_Kingdom#Formatting.



