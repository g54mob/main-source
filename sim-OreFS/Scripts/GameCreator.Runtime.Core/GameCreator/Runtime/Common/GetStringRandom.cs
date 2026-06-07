using System;
using System.Text;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Random")]
	[Category("Random/Random")]
	[Image(typeof(IconDice), ColorTheme.Type.Yellow)]
	[Description("Returns a random string of a certain length and particular set of characters")]
	public class GetStringRandom : PropertyTypeGetString
	{
		public enum Type
		{
			Numbers = 0,
			Alphabet = 1,
			AlphaNumeric = 2,
			AlphanumericSymbolic = 3
		}

		private static readonly string ALPHABET = "abcdefghijklmnopqrstuvwxyz";

		private static readonly string NUMBERS = "0123456789";

		private static readonly string SYMBOLS = "!#$%&'()*+,-./:<=>?@[]^{}|~";

		[SerializeField]
		private int m_Length = 8;

		[SerializeField]
		private Type m_Type = Type.AlphaNumeric;

		public static PropertyGetString Create => new PropertyGetString(new GetStringRandom());

		private static char GenerateAlphabet => ALPHABET[UnityEngine.Random.Range(0, ALPHABET.Length)];

		private static char GenerateNumber => NUMBERS[UnityEngine.Random.Range(0, NUMBERS.Length)];

		private static char GenerateSymbol => SYMBOLS[UnityEngine.Random.Range(0, SYMBOLS.Length)];

		public override string String => "Random";

		public override string Get(Args args)
		{
			return Generate(m_Length, m_Type);
		}

		public override string Get(GameObject gameObject)
		{
			return Generate(m_Length, m_Type);
		}

		private static string Generate(int length, Type type)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				StringBuilder stringBuilder2 = stringBuilder;
				char value;
				switch (type)
				{
				case Type.Numbers:
					value = GenerateNumber;
					break;
				case Type.Alphabet:
					value = GenerateAlphabet;
					break;
				case Type.AlphaNumeric:
				{
					char c = ((UnityEngine.Random.Range(0, 2) != 0) ? GenerateNumber : GenerateAlphabet);
					value = c;
					break;
				}
				case Type.AlphanumericSymbolic:
					value = UnityEngine.Random.Range(0, 3) switch
					{
						0 => GenerateAlphabet, 
						1 => GenerateNumber, 
						_ => GenerateSymbol, 
					};
					break;
				default:
					throw new ArgumentOutOfRangeException("type", type, null);
				}
				stringBuilder2.Append(value);
			}
			return stringBuilder.ToString();
		}
	}
}
