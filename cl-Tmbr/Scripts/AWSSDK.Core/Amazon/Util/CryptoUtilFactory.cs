using System;
using System.Buffers;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using AWSSDK.Runtime.Internal.Util;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Util;
using ThirdParty.MD5;

namespace Amazon.Util
{
	public static class CryptoUtilFactory
	{
		private class CryptoUtil : ICryptoUtil
		{
			[ThreadStatic]
			private static HashAlgorithm _hashAlgorithm;

			private static HashAlgorithm SHA256HashAlgorithmInstance
			{
				get
				{
					if (_hashAlgorithm == null)
					{
						_hashAlgorithm = CreateSHA256Instance();
					}
					return _hashAlgorithm;
				}
			}

			internal CryptoUtil()
			{
			}

			public string HMACSign(string data, string key, SigningAlgorithm algorithmName)
			{
				Encoding uTF = Encoding.UTF8;
				int maxByteCount = uTF.GetMaxByteCount(data.Length);
				byte[] array = ArrayPool<byte>.Shared.Rent(maxByteCount);
				try
				{
					int bytes = uTF.GetBytes(data, 0, data.Length, array, 0);
					ArraySegment<byte> data2 = new ArraySegment<byte>(array, 0, bytes);
					return HMACSign(data2, key, algorithmName);
				}
				finally
				{
					ArrayPool<byte>.Shared.Return(array);
				}
			}

			public byte[] ComputeSHA1Hash(byte[] data)
			{
				using SHA1Managed sHA1Managed = new SHA1Managed();
				return sHA1Managed.ComputeHash(data);
			}

			public byte[] ComputeSHA256Hash(byte[] data)
			{
				return SHA256HashAlgorithmInstance.ComputeHash(data);
			}

			public byte[] ComputeSHA256Hash(Stream steam)
			{
				return SHA256HashAlgorithmInstance.ComputeHash(steam);
			}

			public byte[] ComputeMD5Hash(byte[] data)
			{
				return new MD5Managed().ComputeHash(data);
			}

			public byte[] ComputeMD5Hash(Stream steam)
			{
				return new MD5Managed().ComputeHash(steam);
			}

			public string ComputeCRC32Hash(byte[] data)
			{
				return Convert.ToBase64String(new Crc32Managed().ComputeHash(data));
			}

			public string ComputeCRC32CHash(byte[] data)
			{
				return ChecksumCRTWrapper.Crc32C(data);
			}

			public string ComputeCRC64NVMEHash(byte[] data)
			{
				return ChecksumCRTWrapper.Crc64NVME(data);
			}

			public string HMACSign(byte[] data, string key, SigningAlgorithm algorithmName)
			{
				return HMACSign(new ArraySegment<byte>(data, 0, data.Length), key, algorithmName);
			}

			private string HMACSign(ArraySegment<byte> data, string key, SigningAlgorithm algorithmName)
			{
				if (string.IsNullOrEmpty(key))
				{
					throw new ArgumentNullException("key", "Please specify a Secret Signing Key.");
				}
				if (data.Count == 0)
				{
					throw new ArgumentNullException("data", "Please specify data to sign.");
				}
				KeyedHashAlgorithm keyedHashAlgorithm = CreateKeyedHashAlgorithm(algorithmName);
				if (keyedHashAlgorithm == null)
				{
					throw new InvalidOperationException("Please specify a KeyedHashAlgorithm to use.");
				}
				try
				{
					keyedHashAlgorithm.Key = Encoding.UTF8.GetBytes(key);
					return Convert.ToBase64String(keyedHashAlgorithm.ComputeHash(data.Array, data.Offset, data.Count));
				}
				finally
				{
					keyedHashAlgorithm.Dispose();
				}
			}

			public byte[] HMACSignBinary(byte[] data, byte[] key, SigningAlgorithm algorithmName)
			{
				if (key == null || key.Length == 0)
				{
					throw new ArgumentNullException("key", "Please specify a Secret Signing Key.");
				}
				if (data == null || data.Length == 0)
				{
					throw new ArgumentNullException("data", "Please specify data to sign.");
				}
				KeyedHashAlgorithm keyedHashAlgorithm = CreateKeyedHashAlgorithm(algorithmName);
				if (keyedHashAlgorithm == null)
				{
					throw new InvalidOperationException("Please specify a KeyedHashAlgorithm to use.");
				}
				try
				{
					keyedHashAlgorithm.Key = key;
					return keyedHashAlgorithm.ComputeHash(data);
				}
				finally
				{
					keyedHashAlgorithm.Dispose();
				}
			}

			private static KeyedHashAlgorithm CreateKeyedHashAlgorithm(SigningAlgorithm algorithmName)
			{
				return algorithmName switch
				{
					SigningAlgorithm.HmacSHA256 => new HMACSHA256(), 
					SigningAlgorithm.HmacSHA1 => new HMACSHA1(), 
					_ => throw new Exception($"KeyedHashAlgorithm {algorithmName.ToString()} was not found."), 
				};
			}

			internal static HashAlgorithm CreateSHA256Instance()
			{
				return SHA256.Create();
			}
		}

		private const int SHA1_BASE64_LENGTH = 28;

		private const int SHA56_BASE64_LENGTH = 44;

		private const int CRC32_BASE64_LENGTH = 8;

		private const int CRC64NVME_BASE64_LENGTH = 12;

		private static CryptoUtil util = new CryptoUtil();

		public static ICryptoUtil CryptoInstance => util;

		public static HashAlgorithm GetChecksumInstance(CoreChecksumAlgorithm algorithm)
		{
			return algorithm switch
			{
				CoreChecksumAlgorithm.SHA1 => new SHA1Managed(), 
				CoreChecksumAlgorithm.SHA256 => CryptoUtil.CreateSHA256Instance(), 
				CoreChecksumAlgorithm.CRC32 => new Crc32Managed(), 
				CoreChecksumAlgorithm.CRC32C => new CrtCrc32c(), 
				CoreChecksumAlgorithm.CRC64NVME => new CrtCrc64NVME(), 
				_ => throw new AmazonClientException($"Unable to instantiate checksum algorithm {algorithm}"), 
			};
		}

		public static int GetChecksumBase64Length(CoreChecksumAlgorithm algorithm)
		{
			switch (algorithm)
			{
			case CoreChecksumAlgorithm.SHA1:
				return 28;
			case CoreChecksumAlgorithm.SHA256:
				return 44;
			case CoreChecksumAlgorithm.CRC32C:
			case CoreChecksumAlgorithm.CRC32:
				return 8;
			case CoreChecksumAlgorithm.CRC64NVME:
				return 12;
			default:
				throw new AmazonClientException($"Unable to determine the base64-encoded length of {algorithm}");
			}
		}
	}
}
