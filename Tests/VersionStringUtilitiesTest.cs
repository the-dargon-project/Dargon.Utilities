﻿using NMockito;
using Xunit;

namespace Dargon
{
   public class VersionStringUtilitiesTest : NMockitoInstance
   {
      private const string kInvalidPath = "123ids890/A()!K/!)(DKQ:";
      private const string kValidPath = "123ids890/1.2.3.4/!)(DKQ:";
      private const string kValidPathVersionString = "1.2.3.4";
      private const uint kValidPathVersionNumber = 0x01020304U;

      [Fact]
      public void GetVersionNumberHappyPathTest() { AssertEquals(kValidPathVersionNumber, VersionStringUtilities.GetVersionNumber(kValidPath)); }

      [Fact]
      public void GetVersionNumberSadPathReturnsUint32MaxTest() { AssertEquals(uint.MaxValue, VersionStringUtilities.GetVersionNumber(kInvalidPath)); }

      [Fact]
      public void GetVersionStringHappyPathTest() { AssertEquals(kValidPathVersionString, VersionStringUtilities.GetVersionString(kValidPath)); }

      [Fact]
      public void GetVersionStringInvalidStringReturnsEmptyStringTest() { AssertEquals("", VersionStringUtilities.GetVersionString(kInvalidPath)); }

      [Fact]
      public void TryGetVersionNumberHappyPathTest()
      {
         uint versionNumber;
         AssertTrue(VersionStringUtilities.TryGetVersionNumber(kValidPath, out versionNumber));
         AssertEquals(kValidPathVersionNumber, versionNumber);
      }

      [Fact]
      public void TryGetVersionNumberSadPathTest()
      {
         uint versionNumber;
         AssertFalse(VersionStringUtilities.TryGetVersionNumber(kInvalidPath, out versionNumber));
         AssertEquals(uint.MaxValue, versionNumber);
      }
   }
}
