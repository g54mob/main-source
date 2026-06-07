using System;
using System.Text;
using UnityEngine;

namespace GameCreator.Runtime.Common.SaveSystem
{
	[Serializable]
	[Title("XOR")]
	[Category("XOR")]
	[Image(typeof(IconOR), ColorTheme.Type.Blue)]
	[Description("Uses a XOR operator to hide values")]
	public class EncryptionXOR : TDataEncryption
	{
		[SerializeField]
		private string m_Secret = "Colloportus";

		public override string Encrypt(string input)
		{
			return XOR(input);
		}

		public override string Decrypt(string input)
		{
			return XOR(input);
		}

		private string XOR(string input)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < input.Length; i++)
			{
				int index = i % m_Secret.Length;
				int num = input[i] ^ m_Secret[index];
				stringBuilder.Append((char)num);
			}
			return stringBuilder.ToString();
		}
	}
}
