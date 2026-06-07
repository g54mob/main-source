using System;
using System.Collections.Generic;
using UnityEngine;

public class NumberFormat : MonoBehaviour
{
	private Dictionary<int, string> suffixString = new Dictionary<int, string>();

	public Character character;

	private void Awake()
	{
		suffixString.Add(0, " Million");
		suffixString.Add(1, " Million");
		suffixString.Add(2, " Million");
		suffixString.Add(3, " Billion");
		suffixString.Add(4, " Trillion");
		suffixString.Add(5, " Quadrillion");
		suffixString.Add(6, " Quintillion");
		suffixString.Add(7, " Sextillion");
		suffixString.Add(8, " Septillion");
		suffixString.Add(9, " Octillion");
		suffixString.Add(10, " Nonillion");
		suffixString.Add(11, " Decillion");
		suffixString.Add(12, " Undecillion");
		suffixString.Add(13, " Duodecillion");
		suffixString.Add(14, " Tredecillion");
		suffixString.Add(15, " Quattuordecillion");
		suffixString.Add(16, " Quindecillion");
		suffixString.Add(17, " Sexdecillion");
		suffixString.Add(18, " Septendecillion");
		suffixString.Add(19, " Octodecillion");
		suffixString.Add(20, " Novemdecillion");
		suffixString.Add(21, " Vigintillion");
		suffixString.Add(22, " Unvigintillion");
		suffixString.Add(23, " Duovigintillion");
		suffixString.Add(24, " Trevigintillion");
		suffixString.Add(25, " Quattuorvigintillion");
		suffixString.Add(26, " Quinvigintillion");
		suffixString.Add(27, " Sexvigintillion");
		suffixString.Add(28, " Septenvigintillion");
		suffixString.Add(29, " Octovigintillion");
		suffixString.Add(30, " Novemvigintillion");
		suffixString.Add(31, " Trigintillion");
		suffixString.Add(32, " Untrigintillion");
		suffixString.Add(33, " Duotrigintillion");
		suffixString.Add(34, " Tretrigintillion");
		suffixString.Add(35, " Quattuortrigintillion");
		suffixString.Add(36, " Quintrigintillion");
		suffixString.Add(37, " Sextrigintillion");
		suffixString.Add(38, " Septentrigintillion");
		suffixString.Add(39, " Octotrigintillion");
		suffixString.Add(40, " Novemtrigintillion");
		suffixString.Add(41, " Quadragintillion");
		suffixString.Add(42, " Unquadragintillion");
		suffixString.Add(43, " Duoquadragintillion");
		suffixString.Add(44, " Trequadragintillion");
		suffixString.Add(45, " Quattuorquadragintillion");
		suffixString.Add(46, " Quinquadragintillion");
		suffixString.Add(47, " Sexquadragintillion");
		suffixString.Add(48, " Septenquadragintillion");
		suffixString.Add(49, " Octoquadragintillion");
		suffixString.Add(50, " Novemquadragintillion");
		suffixString.Add(51, " Quinquagintillion");
		suffixString.Add(52, " Unquinquagintillion");
		suffixString.Add(53, " Duoquinquagintillion");
		suffixString.Add(54, " Trequinquagintillion");
		suffixString.Add(55, " Quattuorquinquagintillion");
		suffixString.Add(56, " Quinquinquagintillion");
		suffixString.Add(57, " Sexquinquagintillion");
		suffixString.Add(58, " Septenquinquagintillion");
		suffixString.Add(59, " Octoquinquagintillion");
		suffixString.Add(60, " Novemquinquagintillion");
		suffixString.Add(61, " Sexagintillion");
		suffixString.Add(62, " Unsexagintillion");
		suffixString.Add(63, " Duosexagintillion");
		suffixString.Add(64, " Tresexagintillion");
		suffixString.Add(65, " Quattuorsexagintillion");
		suffixString.Add(66, " Quinsexagintillion");
		suffixString.Add(67, " Sexsexagintillion\n The sexiest number ;)");
		suffixString.Add(68, " Septensexagintillion");
		suffixString.Add(69, " Octosexagintillion");
		suffixString.Add(70, " Novemsexagintillion");
		suffixString.Add(71, " Septuagintillion");
		suffixString.Add(72, " Unseptuagintillion");
		suffixString.Add(73, " Duoseptuagintillion");
		suffixString.Add(74, " Treseptuagintillion");
		suffixString.Add(75, " Quattuorseptuagintillion");
		suffixString.Add(76, " Quinseptuagintillion");
		suffixString.Add(77, " Sexseptuagintillion");
		suffixString.Add(78, " Septenseptuagintillion");
		suffixString.Add(79, " Octoseptuagintillion");
		suffixString.Add(80, " Novemseptuagintillion");
		suffixString.Add(81, " Octogintillion");
		suffixString.Add(82, " Unoctogintillion");
		suffixString.Add(83, " Duooctogintillion");
		suffixString.Add(84, " Treoctogintillion");
		suffixString.Add(85, " Quattuoroctogintillion");
		suffixString.Add(86, " Quinoctogintillion");
		suffixString.Add(87, " Sexoctogintillion");
		suffixString.Add(88, " Septenoctogintillion");
		suffixString.Add(89, " Octooctogintillion");
		suffixString.Add(90, " Novemoctogintillion");
		suffixString.Add(91, " Nonagintillion");
		suffixString.Add(92, " Unnonagintillion");
		suffixString.Add(93, " Duononagintillion");
		suffixString.Add(94, " Trenonagintillion");
		suffixString.Add(95, " Quattuornonagintillion");
		suffixString.Add(96, " Quinnonagintillion");
		suffixString.Add(97, " Sexnonagintillion");
		suffixString.Add(98, " Septennonagintillion");
		suffixString.Add(99, " Octononagintillion");
		suffixString.Add(100, " Novemnonagintillion");
		suffixString.Add(101, " CENTILLION");
		suffixString.Add(102, " SUPERCENTILLION");
	}

	public string suffixFormat(double number)
	{
		if (character.settings.numberDisplay == 0)
		{
			return realSuffixFormat(number);
		}
		if (character.settings.numberDisplay == 1)
		{
			return engineerFormat(number);
		}
		if (character.settings.numberDisplay == 2)
		{
			return sciFormat(number);
		}
		return realSuffixFormat(number);
	}

	private string realSuffixFormat(double number)
	{
		if (number < 1.0)
		{
			return number.ToString();
		}
		if (number < 1000000.0)
		{
			return number.ToString("###,##0");
		}
		string text = "";
		int num = 0;
		num = (int)Math.Floor(Math.Log(number, 1000.0));
		number /= Math.Pow(1000.0, num);
		text = suffixString[num];
		return number.ToString("###.000") + text;
	}

	private string engineerFormat(double number)
	{
		if (number < 1000000.0)
		{
			return number.ToString("###,##0");
		}
		double num = Math.Floor(Math.Log10(Math.Abs(number)) / 3.0) * 3.0;
		number /= Math.Pow(10.0, num);
		return number.ToString("###.000") + "E+" + num;
	}

	private string sciFormat(double number)
	{
		if (number < 1000000.0)
		{
			return number.ToString("###,##0");
		}
		return number.ToString("E3");
	}
}
