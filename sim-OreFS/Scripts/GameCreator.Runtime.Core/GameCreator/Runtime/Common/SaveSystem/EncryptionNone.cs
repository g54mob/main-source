using System;

namespace GameCreator.Runtime.Common.SaveSystem
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Image(typeof(IconEmpty), ColorTheme.Type.TextLight)]
	[Description("Does not use any type of encryption")]
	public class EncryptionNone : TDataEncryption
	{
		public override string Encrypt(string input)
		{
			return input;
		}

		public override string Decrypt(string input)
		{
			return input;
		}
	}
}
