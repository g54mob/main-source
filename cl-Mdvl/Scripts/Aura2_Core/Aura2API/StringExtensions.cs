using System.Text;

namespace Aura2API
{
	public static class StringExtensions
	{
		public static string InsertStringBeforeUpperCaseLetters(this string sourceString, string insertedString, bool ignoreFirstLetter = true, bool ignoreSpaces = true)
		{
			if (string.IsNullOrEmpty(sourceString))
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder(sourceString.Length * 2);
			if (ignoreFirstLetter)
			{
				stringBuilder.Append(sourceString[0]);
			}
			for (int i = 1; i < sourceString.Length; i++)
			{
				if (char.IsUpper(sourceString[i]) && (sourceString[i - 1] != ' ' || !ignoreSpaces))
				{
					stringBuilder.Append(insertedString);
				}
				stringBuilder.Append(sourceString[i]);
			}
			return stringBuilder.ToString();
		}

		public static string InsertCharacterBeforeUpperCaseLetters(this string sourceString, char insertedCharacter, bool ignoreFirstLetter = true, bool ignoreSpaces = true)
		{
			return sourceString.InsertStringBeforeUpperCaseLetters(insertedCharacter.ToString(), ignoreFirstLetter, ignoreSpaces);
		}
	}
}
