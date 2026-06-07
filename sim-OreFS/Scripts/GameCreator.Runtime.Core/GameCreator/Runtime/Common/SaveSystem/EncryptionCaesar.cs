using System;
using System.Text;
using UnityEngine;

namespace GameCreator.Runtime.Common.SaveSystem
{
	[Serializable]
	[Title("Caesar")]
	[Category("Caesar")]
	[Image(typeof(IconCrown), ColorTheme.Type.Yellow)]
	[Description("Uses a Caesar cipher that shifts character positions by N amount")]
	public class EncryptionCaesar : TDataEncryption
	{
		[SerializeField]
		private int m_Positions = 5;

		public override string Encrypt(string input)
		{
			return Caesar(input, m_Positions);
		}

		public override string Decrypt(string input)
		{
			return Caesar(input, -m_Positions);
		}

		public string Caesar(string input, int positions)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in input)
			{
				int num = c + positions;
				if (num < 32 || num > 126)
				{
					stringBuilder.Append(c);
					continue;
				}
				num = (num - 32) % 95 + 32;
				stringBuilder.Append((char)num);
			}
			return stringBuilder.ToString();
		}
	}
}
