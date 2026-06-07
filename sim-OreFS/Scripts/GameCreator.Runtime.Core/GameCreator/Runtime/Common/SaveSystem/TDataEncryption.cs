using System;

namespace GameCreator.Runtime.Common.SaveSystem
{
	[Serializable]
	[Title("Encryption System")]
	public abstract class TDataEncryption : IDataEncryption
	{
		public abstract string Encrypt(string input);

		public abstract string Decrypt(string input);
	}
}
