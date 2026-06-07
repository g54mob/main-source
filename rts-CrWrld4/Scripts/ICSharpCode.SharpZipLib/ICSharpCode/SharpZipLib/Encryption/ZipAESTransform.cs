using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	internal class ZipAESTransform
	{
		private HMACSHA1 _hmacsha1;

		private bool _finalised;

		public byte[] GetAuthCode()
		{
			return null;
		}
	}
}
