using Pathfinding.Ionic.Crc;

namespace Pathfinding.Ionic.Zip
{
	internal class ZipCrypto
	{
		private uint[] _Keys;

		private CRC32 crc32;

		private byte MagicByte => 0;

		private ZipCrypto()
		{
		}

		public static ZipCrypto ForWrite(string password)
		{
			return null;
		}

		public static ZipCrypto ForRead(string password, ZipEntry e)
		{
			return null;
		}

		public byte[] DecryptMessage(byte[] cipherText, int length)
		{
			return null;
		}

		public byte[] EncryptMessage(byte[] plainText, int length)
		{
			return null;
		}

		public void InitCipher(string passphrase)
		{
		}

		private void UpdateKeys(byte byteValue)
		{
		}
	}
}
