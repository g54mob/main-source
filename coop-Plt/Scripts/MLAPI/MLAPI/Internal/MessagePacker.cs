using System;
using System.Security.Cryptography;
using MLAPI.Logging;
using MLAPI.Security;
using MLAPI.Serialization;
using MLAPI.Serialization.Pooled;

namespace MLAPI.Internal
{
	internal static class MessagePacker
	{
		private static readonly byte[] IV_BUFFER = new byte[16];

		private static readonly byte[] HMAC_BUFFER = new byte[32];

		private static readonly byte[] HMAC_PLACEHOLDER = new byte[32];

		internal static BitStream UnwrapMessage(BitStream inputStream, ulong clientId, out byte messageType, out SecuritySendFlags security)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(inputStream);
			try
			{
				if (inputStream.Length < 1)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogError("The incoming message was too small");
					}
					messageType = 32;
					security = SecuritySendFlags.None;
					return null;
				}
				bool flag = pooledBitReader.ReadBit();
				bool flag2 = pooledBitReader.ReadBit();
				if (flag && flag2)
				{
					security = SecuritySendFlags.Encrypted | SecuritySendFlags.Authenticated;
				}
				else if (flag)
				{
					security = SecuritySendFlags.Encrypted;
				}
				else if (flag2)
				{
					security = SecuritySendFlags.Authenticated;
				}
				else
				{
					security = SecuritySendFlags.None;
				}
				if (flag || flag2)
				{
					if (!NetworkingManager.Singleton.NetworkConfig.EnableEncryption)
					{
						if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
						{
							NetworkLog.LogError("Got a encrypted and/or authenticated message but key exchange (\"encryption\") was not enabled");
						}
						messageType = 32;
						return null;
					}
					pooledBitReader.SkipPadBits();
					if (flag2)
					{
						long position = inputStream.Position;
						int num = inputStream.Read(HMAC_BUFFER, 0, HMAC_BUFFER.Length);
						if (num != HMAC_BUFFER.Length)
						{
							if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
							{
								NetworkLog.LogError("HMAC length was invalid");
							}
							messageType = 32;
							return null;
						}
						inputStream.Position = position;
						inputStream.Write(HMAC_PLACEHOLDER, 0, HMAC_PLACEHOLDER.Length);
						byte[] array = (NetworkingManager.Singleton.IsServer ? CryptographyHelper.GetClientKey(clientId) : CryptographyHelper.GetServerKey());
						if (array == null)
						{
							if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
							{
								NetworkLog.LogError("Failed to grab key");
							}
							messageType = 32;
							return null;
						}
						using HMACSHA256 hMACSHA = new HMACSHA256(array);
						byte[] a = hMACSHA.ComputeHash(inputStream.GetBuffer(), 0, (int)inputStream.Length);
						if (!CryptographyHelper.ConstTimeArrayEqual(a, HMAC_BUFFER))
						{
							if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
							{
								NetworkLog.LogError("Received HMAC did not match the computed HMAC");
							}
							messageType = 32;
							return null;
						}
					}
					if (flag)
					{
						int num2 = inputStream.Read(IV_BUFFER, 0, IV_BUFFER.Length);
						if (num2 != IV_BUFFER.Length)
						{
							if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
							{
								NetworkLog.LogError("Invalid IV size");
							}
							messageType = 32;
							return null;
						}
						PooledBitStream pooledBitStream = PooledBitStream.Get();
						using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
						{
							rijndaelManaged.IV = IV_BUFFER;
							rijndaelManaged.Padding = PaddingMode.PKCS7;
							byte[] array2 = (NetworkingManager.Singleton.IsServer ? CryptographyHelper.GetClientKey(clientId) : CryptographyHelper.GetServerKey());
							if (array2 == null)
							{
								if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
								{
									NetworkLog.LogError("Failed to grab key");
								}
								messageType = 32;
								return null;
							}
							rijndaelManaged.Key = array2;
							using (CryptoStream cryptoStream = new CryptoStream(pooledBitStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Write))
							{
								cryptoStream.Write(inputStream.GetBuffer(), (int)inputStream.Position, (int)(inputStream.Length - inputStream.Position));
							}
							pooledBitStream.Position = 0L;
							if (pooledBitStream.Length == 0L)
							{
								if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
								{
									NetworkLog.LogError("The incoming message was too small");
								}
								messageType = 32;
								return null;
							}
							int num3 = pooledBitStream.ReadByte();
							messageType = (byte)((num3 == -1) ? 32 : ((byte)num3));
						}
						return pooledBitStream;
					}
					if (inputStream.Length - inputStream.Position <= 0)
					{
						if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
						{
							NetworkLog.LogError("The incoming message was too small");
						}
						messageType = 32;
						return null;
					}
					int num4 = inputStream.ReadByte();
					messageType = (byte)((num4 == -1) ? 32 : ((byte)num4));
					return inputStream;
				}
				messageType = pooledBitReader.ReadByteBits(6);
				return inputStream;
			}
			catch (Exception ex)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogError("Error while unwrapping headers");
				}
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError(ex.ToString());
				}
				security = SecuritySendFlags.None;
				messageType = 32;
				return null;
			}
		}

		internal static BitStream WrapMessage(byte messageType, ulong clientId, BitStream messageBody, SecuritySendFlags flags)
		{
			try
			{
				bool flag = (flags & SecuritySendFlags.Encrypted) == SecuritySendFlags.Encrypted && NetworkingManager.Singleton.NetworkConfig.EnableEncryption;
				bool flag2 = (flags & SecuritySendFlags.Authenticated) == SecuritySendFlags.Authenticated && NetworkingManager.Singleton.NetworkConfig.EnableEncryption;
				PooledBitStream pooledBitStream = PooledBitStream.Get();
				using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
				{
					pooledBitWriter.WriteBit(flag);
					pooledBitWriter.WriteBit(flag2);
					if (flag2 || flag)
					{
						pooledBitWriter.WritePadBits();
						long position = pooledBitStream.Position;
						if (flag2)
						{
							pooledBitStream.Write(HMAC_PLACEHOLDER, 0, HMAC_PLACEHOLDER.Length);
						}
						if (flag)
						{
							using RijndaelManaged rijndaelManaged = new RijndaelManaged();
							rijndaelManaged.GenerateIV();
							rijndaelManaged.Padding = PaddingMode.PKCS7;
							byte[] array = (NetworkingManager.Singleton.IsServer ? CryptographyHelper.GetClientKey(clientId) : CryptographyHelper.GetServerKey());
							if (array == null)
							{
								if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
								{
									NetworkLog.LogError("Failed to grab key");
								}
								return null;
							}
							rijndaelManaged.Key = array;
							pooledBitStream.Write(rijndaelManaged.IV);
							using CryptoStream cryptoStream = new CryptoStream(pooledBitStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write);
							cryptoStream.WriteByte(messageType);
							cryptoStream.Write(messageBody.GetBuffer(), 0, (int)messageBody.Length);
						}
						else
						{
							pooledBitStream.WriteByte(messageType);
							pooledBitStream.Write(messageBody.GetBuffer(), 0, (int)messageBody.Length);
						}
						if (flag2)
						{
							byte[] array2 = (NetworkingManager.Singleton.IsServer ? CryptographyHelper.GetClientKey(clientId) : CryptographyHelper.GetServerKey());
							if (array2 == null)
							{
								if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
								{
									NetworkLog.LogError("Failed to grab key");
								}
								return null;
							}
							using HMACSHA256 hMACSHA = new HMACSHA256(array2);
							byte[] array3 = hMACSHA.ComputeHash(pooledBitStream.GetBuffer(), 0, (int)pooledBitStream.Length);
							pooledBitStream.Position = position;
							pooledBitStream.Write(array3, 0, array3.Length);
						}
					}
					else
					{
						pooledBitWriter.WriteBits(messageType, 6);
						pooledBitStream.Write(messageBody.GetBuffer(), 0, (int)messageBody.Length);
					}
				}
				return pooledBitStream;
			}
			catch (Exception ex)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogError("Error while wrapping headers");
				}
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError(ex.ToString());
				}
				return null;
			}
		}
	}
}
