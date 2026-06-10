using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	public sealed class PkzipClassicManaged : PkzipClassic
	{
		private byte[] key_;

		public override int BlockSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override KeySizes[] LegalKeySizes => null;

		public override KeySizes[] LegalBlockSizes => null;

		public override byte[] Key
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void GenerateIV()
		{
		}

		public override void GenerateKey()
		{
		}

		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			return null;
		}

		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			return null;
		}
	}
}
