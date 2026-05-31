using System.Text.RegularExpressions;
using UnityEngine;

namespace MyBox
{
	public class RegexStringAttribute : PropertyAttribute
	{
		public readonly Regex Regex;

		public readonly RegexStringMode AttributeMode;

		public RegexStringAttribute(string regex, RegexStringMode mode = RegexStringMode.Match, RegexOptions options = RegexOptions.None)
		{
		}
	}
}
