namespace NSubstitute.Exceptions
{
	public abstract class CouldNotSetReturnException : SubstituteException
	{
		protected const string WhatProbablyWentWrong = "Make sure you called Returns() after calling your substitute (for example: mySub.SomeMethod().Returns(value)),\nand that you are not configuring other substitutes within Returns() (for example, avoid this: mySub.SomeMethod().Returns(ConfigOtherSub())).\n\nIf you substituted for a class rather than an interface, check that the call to your substitute was on a virtual/abstract member.\nReturn values cannot be configured for non-virtual/non-abstract members.\n\nCorrect use:\n\tmySub.SomeMethod().Returns(returnValue);\n\nPotentially problematic use:\n\tmySub.SomeMethod().Returns(ConfigOtherSub());\nInstead try:\n\tvar returnValue = ConfigOtherSub();\n\tmySub.SomeMethod().Returns(returnValue);\n";

		protected CouldNotSetReturnException(string s)
			: base(s + "\n\nMake sure you called Returns() after calling your substitute (for example: mySub.SomeMethod().Returns(value)),\nand that you are not configuring other substitutes within Returns() (for example, avoid this: mySub.SomeMethod().Returns(ConfigOtherSub())).\n\nIf you substituted for a class rather than an interface, check that the call to your substitute was on a virtual/abstract member.\nReturn values cannot be configured for non-virtual/non-abstract members.\n\nCorrect use:\n\tmySub.SomeMethod().Returns(returnValue);\n\nPotentially problematic use:\n\tmySub.SomeMethod().Returns(ConfigOtherSub());\nInstead try:\n\tvar returnValue = ConfigOtherSub();\n\tmySub.SomeMethod().Returns(returnValue);\n")
		{
		}
	}
}
