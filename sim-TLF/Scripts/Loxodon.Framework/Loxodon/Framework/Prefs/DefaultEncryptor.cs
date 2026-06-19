using System;
using System.Security.Cryptography;
using System.Text;

namespace Loxodon.Framework.Prefs
{
	public class DefaultEncryptor : IEncryptor
	{
		private const int IV_SIZE = 16;

		private static readonly byte[] DEFAULT_IV;

		private static readonly byte[] DEFAULT_KEY;

		private RijndaelManaged cipher;

		private byte[] iv;

		private byte[] key;

		static DefaultEncryptor()
		{
			DEFAULT_IV = Encoding.ASCII.GetBytes("5CyM5tcL3yDFiWlN");
			DEFAULT_KEY = Encoding.ASCII.GetBytes("W8fnmqMynlTJXPM1");
		}

		public DefaultEncryptor()
			: this(null, null)
		{
		}

		public DefaultEncryptor(byte[] key, byte[] iv)
		{
			this.iv = ((iv != null) ? iv : DEFAULT_IV);
			this.key = ((key != null) ? key : DEFAULT_KEY);
			CheckIV(this.iv);
			CheckKey(this.key);
			cipher = new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.PKCS7,
				KeySize = 128,
				BlockSize = 128,
				FeedbackSize = 128
			};
		}

		protected bool CheckKey(byte[] bytes)
		{
			if (bytes == null || (bytes.Length != 16 && bytes.Length != 24 && bytes.Length != 32))
			{
				throw new ArgumentException("The 'Key' must be 16byte 24byte or 32byte!");
			}
			return true;
		}

		protected bool CheckIV(byte[] bytes)
		{
			if (bytes == null || bytes.Length != 16)
			{
				throw new ArgumentException("The 'IV' must be 16byte!");
			}
			return true;
		}

		public byte[] Encode(byte[] plainData)
		{
			return cipher.CreateEncryptor(key, iv).TransformFinalBlock(plainData, 0, plainData.Length);
		}

		public byte[] Decode(byte[] cipherData)
		{
			return cipher.CreateDecryptor(key, iv).TransformFinalBlock(cipherData, 0, cipherData.Length);
		}
	}
}
