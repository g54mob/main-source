using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace MLAPI.Security
{
	internal class EllipticDiffieHellman
	{
		protected static readonly RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();

		private static BigInteger defaultPrime;

		private static BigInteger defaultOrder;

		private static EllipticCurve defaultCurve;

		private static CurvePoint defaultGenerator;

		protected readonly EllipticCurve curve;

		public readonly BigInteger priv;

		protected readonly CurvePoint generator;

		protected readonly CurvePoint pub;

		public static BigInteger DEFAULT_PRIME
		{
			get
			{
				if (defaultPrime == null)
				{
					try
					{
						defaultPrime = (new BigInteger("1") << 255) - 19;
					}
					catch (Exception)
					{
						Debug.LogError("[MLAPI] CryptoLib failed to parse BigInt. If you are using .NET 2.0 Subset, switch to .NET 2.0 or .NET 4.5");
					}
				}
				return defaultPrime;
			}
		}

		public static BigInteger DEFAULT_ORDER
		{
			get
			{
				if (defaultOrder == null)
				{
					try
					{
						defaultOrder = (new BigInteger(1L) << 252) + new BigInteger("27742317777372353535851937790883648493");
					}
					catch (Exception)
					{
						Debug.LogError("[MLAPI] CryptoLib failed to parse BigInt. If you are using .NET 2.0 Subset, switch to .NET 2.0 or .NET 4.5");
					}
				}
				return defaultOrder;
			}
		}

		public static EllipticCurve DEFAULT_CURVE
		{
			get
			{
				if (defaultCurve == null)
				{
					try
					{
						defaultCurve = new EllipticCurve(486662, 1, DEFAULT_PRIME, EllipticCurve.CurveType.Montgomery);
					}
					catch (Exception)
					{
						Debug.LogError("[MLAPI] CryptoLib failed to parse BigInt. If you are using .NET 2.0 Subset, switch to .NET 2.0 or .NET 4.5");
					}
				}
				return defaultCurve;
			}
		}

		public static CurvePoint DEFAULT_GENERATOR
		{
			get
			{
				if (defaultGenerator == null)
				{
					try
					{
						defaultGenerator = new CurvePoint(9, new BigInteger("14781619447589544791020593568409986887264606134616475288964881837755586237401"));
					}
					catch (Exception)
					{
						Debug.LogError("[MLAPI] CryptoLib failed to parse BigInt. If you are using .NET 2.0 Subset, switch to .NET 2.0 or .NET 4.5");
					}
				}
				return defaultGenerator;
			}
		}

		public EllipticDiffieHellman(EllipticCurve curve, CurvePoint generator, BigInteger order, byte[] priv = null)
		{
			this.curve = curve;
			this.generator = generator;
			if (priv == null)
			{
				this.priv = new BigInteger();
				this.priv.GenRandomBits(order.DataLength, rand);
			}
			else
			{
				this.priv = new BigInteger(priv);
			}
			pub = curve.Multiply(generator, this.priv);
		}

		public byte[] GetPublicKey()
		{
			byte[] bytes = pub.X.GetBytes();
			byte[] bytes2 = pub.Y.GetBytes();
			byte[] array = new byte[4 + bytes.Length + bytes2.Length];
			array[0] = (byte)(bytes.Length & 0xFF);
			array[1] = (byte)((bytes.Length >> 8) & 0xFF);
			array[2] = (byte)((bytes.Length >> 16) & 0xFF);
			array[3] = (byte)((bytes.Length >> 24) & 0xFF);
			Array.Copy(bytes, 0, array, 4, bytes.Length);
			Array.Copy(bytes2, 0, array, 4 + bytes.Length, bytes2.Length);
			return array;
		}

		public byte[] GetPrivateKey()
		{
			return priv.GetBytes();
		}

		public byte[] GetSharedSecret(byte[] pK)
		{
			byte[] array = new byte[pK[0] | (pK[1] << 8) | (pK[2] << 16) | (pK[3] << 24)];
			byte[] array2 = new byte[pK.Length - array.Length - 4];
			Array.Copy(pK, 4, array, 0, array.Length);
			Array.Copy(pK, 4 + array.Length, array2, 0, array2.Length);
			CurvePoint p = new CurvePoint(new BigInteger(array), new BigInteger(array2));
			byte[] bytes = curve.Multiply(p, priv).X.GetBytes();
			return new Rfc2898DeriveBytes(bytes, Encoding.UTF8.GetBytes("P1sN0R4inb0wPl5P1sPls"), 1000).GetBytes(32);
		}
	}
}
