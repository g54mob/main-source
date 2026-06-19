using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Loxodon.Log;

namespace Loxodon.Framework.Security.Cryptography
{
	public class RijndaelCryptograph : IStreamDecryptor, IDecryptor, IStreamEncryptor, IEncryptor
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(RijndaelCryptograph));

		private const int IV_SIZE = 16;

		private static readonly byte[] DEFAULT_IV = new byte[16]
		{
			45, 23, 12, 33, 44, 98, 67, 69, 22, 56,
			22, 98, 99, 68, 75, 74
		};

		private static readonly byte[] DEFAULT_KEY = new byte[32]
		{
			67, 69, 44, 98, 22, 12, 33, 12, 33, 44,
			98, 67, 99, 68, 75, 74, 69, 22, 56, 22,
			98, 98, 99, 68, 75, 74, 45, 23, 22, 56,
			45, 23
		};

		private static readonly char[] arr = new char[60]
		{
			'a', 'b', 'd', 'c', 'e', 'f', 'g', 'h', 'i', 'j',
			'k', 'l', 'm', 'n', 'p', 'r', 'q', 's', 't', 'u',
			'v', 'w', 'z', 'y', 'x', '0', '1', '2', '3', '4',
			'5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E',
			'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Q',
			'P', 'R', 'T', 'S', 'V', 'U', 'W', 'X', 'Y', 'Z'
		};

		private string algorithmName;

		private RijndaelManaged rijndael;

		private byte[] key;

		private byte[] iv;

		public virtual string AlgorithmName => algorithmName;

		public static string GenerateIV()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Random random = new Random(DateTime.Now.Millisecond);
			for (int i = 0; i < 16; i++)
			{
				stringBuilder.Append(arr[random.Next(0, arr.Length)]);
			}
			return stringBuilder.ToString();
		}

		public static string GenerateKey(int size)
		{
			if (size != 16 && size != 24 && size != 32)
			{
				throw new ArgumentNullException("The 'size' must be 16 24 or 32.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			Random random = new Random(DateTime.Now.Millisecond);
			for (int i = 0; i < size; i++)
			{
				stringBuilder.Append(arr[random.Next(0, arr.Length)]);
			}
			return stringBuilder.ToString();
		}

		public RijndaelCryptograph()
			: this(256, DEFAULT_KEY, DEFAULT_IV)
		{
		}

		public RijndaelCryptograph(byte[] key, byte[] iv)
			: this(256, key, iv)
		{
		}

		public RijndaelCryptograph(int keySize, byte[] key, byte[] iv)
		{
			CheckKeySize(keySize);
			CheckIV(iv);
			CheckKey(keySize, key);
			if ((key == DEFAULT_KEY || iv == DEFAULT_IV) && log.IsWarnEnabled)
			{
				log.Warn("Note:Do not use the default Key and IV in the production environment.");
			}
			this.key = key;
			this.iv = iv;
			rijndael = new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.PKCS7,
				KeySize = keySize,
				BlockSize = 128,
				FeedbackSize = 128
			};
			algorithmName = $"AES{rijndael.KeySize}_{rijndael.Mode}_{rijndael.Padding}";
		}

		public RijndaelCryptograph(RijndaelManaged rijndael, byte[] key, byte[] iv)
		{
			int keySize = rijndael?.KeySize ?? 256;
			CheckIV(iv);
			CheckKey(keySize, key);
			if ((key == DEFAULT_KEY || iv == DEFAULT_IV) && log.IsWarnEnabled)
			{
				log.Warn("Note:Do not use the default Key and IV in the production environment.");
			}
			this.key = key;
			this.iv = iv;
			this.rijndael = rijndael;
			if (this.rijndael == null)
			{
				this.rijndael = new RijndaelManaged
				{
					Mode = CipherMode.CBC,
					Padding = PaddingMode.PKCS7,
					KeySize = keySize,
					BlockSize = 128,
					FeedbackSize = 128
				};
			}
			algorithmName = $"AES{rijndael.KeySize}_{rijndael.Mode}_{rijndael.Padding}";
		}

		protected virtual void CheckKeySize(int keySize)
		{
			if (keySize != 128 && keySize != 192 && keySize != 256)
			{
				throw new ArgumentException("The key size must be 128, 192, or 256.");
			}
		}

		protected virtual void CheckKey(int keySize, byte[] bytes)
		{
			if (bytes == null || bytes.Length * 8 != keySize)
			{
				throw new ArgumentException($"The 'Key' must be {keySize / 8} byte!");
			}
		}

		protected virtual void CheckIV(byte[] bytes)
		{
			if (bytes == null || bytes.Length != 16)
			{
				throw new ArgumentException("The 'IV' must be 16 byte!");
			}
		}

		public virtual byte[] Decrypt(byte[] buffer)
		{
			using ICryptoTransform cryptoTransform = rijndael.CreateDecryptor(key, iv);
			return cryptoTransform.TransformFinalBlock(buffer, 0, buffer.Length);
		}

		public virtual Stream Decrypt(Stream input)
		{
			return new CryptoStream(input, rijndael.CreateDecryptor(key, iv), CryptoStreamMode.Read);
		}

		public virtual byte[] Encrypt(byte[] buffer)
		{
			using ICryptoTransform cryptoTransform = rijndael.CreateEncryptor(key, iv);
			return cryptoTransform.TransformFinalBlock(buffer, 0, buffer.Length);
		}

		public virtual Stream Encrypt(Stream input)
		{
			return new CryptoStream(input, rijndael.CreateEncryptor(key, iv), CryptoStreamMode.Read);
		}
	}
}
