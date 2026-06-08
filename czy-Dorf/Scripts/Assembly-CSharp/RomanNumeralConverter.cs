public class RomanNumeralConverter
{
	private static readonly string[] ThouLetters = new string[4] { "", "M", "MM", "MMM" };

	private static readonly string[] HundLetters = new string[10] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };

	private static readonly string[] TensLetters = new string[10] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

	private static readonly string[] OnesLetters = new string[10] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

	public static string ArabicToRoman(int arabic)
	{
		if (arabic >= 4000)
		{
			int arabic2 = arabic / 1000;
			arabic %= 1000;
			return "(" + ArabicToRoman(arabic2) + ")" + ArabicToRoman(arabic);
		}
		int num = arabic / 1000;
		string text = "" + ThouLetters[num];
		arabic %= 1000;
		num = arabic / 100;
		string text2 = text + HundLetters[num];
		arabic %= 100;
		num = arabic / 10;
		string text3 = text2 + TensLetters[num];
		arabic %= 10;
		return text3 + OnesLetters[arabic];
	}
}
