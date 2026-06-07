using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class MiscTools
	{
		private static uint iiLBhFyhzBIoCTEOOQvuOpyfWgF = 0u;

		private static uint lAzEDsicxRUozHmbqceQCeXSquf;

		private static uint LqeIUlMBSqQsacSffglSBCsrrVoK;

		private static int xUvhRPwUpoIvUGPSnVWOtfiOfQN;

		private static int jPzEEeSvBfJHleFTEsOJzZWsKdW;

		private static int RqtFfmuxIYDhHnbEoGUmikMBHab;

		public static object Clone(object obj)
		{
			if (!(obj is ICloneable))
			{
				return null;
			}
			return (obj as ICloneable).Clone();
		}

		public static T Clone<T>(T obj) where T : class, ICloneable
		{
			if (obj == null)
			{
				return null;
			}
			return obj.Clone() as T;
		}

		public static T DeepClone<T>(T obj) where T : class, IDeepCloneable
		{
			if (obj == null)
			{
				return null;
			}
			return obj.DeepClone() as T;
		}

		public static T DeepClone<T>(T obj, bool createIfNull) where T : class, IDeepCloneable, new()
		{
			if (obj == null)
			{
				return new T();
			}
			return obj.DeepClone() as T;
		}

		public static T[] DeepClone<T>(T[] obj) where T : class, IDeepCloneable
		{
			if (obj == null)
			{
				return null;
			}
			T[] array = new T[obj.Length];
			int num = 0;
			while (num < obj.Length)
			{
				while (true)
				{
					array[num] = DeepClone(obj[num]);
					num++;
					int num2 = -224989657;
					while (true)
					{
						switch (num2 ^ -224989658)
						{
						case 0:
							num2 = -224989660;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return array;
		}

		public static List<T> DeepClone<T>(List<T> obj) where T : class, IDeepCloneable
		{
			if (obj == null)
			{
				goto IL_0003;
			}
			List<T> list = new List<T>(obj.Count);
			int num = 0;
			int num2 = -1210219969;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ -1210219970)
				{
				case 2:
					break;
				case 3:
					return null;
				case 0:
					goto IL_003c;
				default:
					if (num < obj.Count)
					{
						goto IL_003c;
					}
					return list;
				}
				break;
				IL_003c:
				list.Add(DeepClone(obj[num]));
				num++;
				num2 = -1210219969;
			}
			goto IL_0003;
			IL_0003:
			num2 = -1210219971;
			goto IL_0008;
		}

		public static Dictionary<TKey, TValue> DeepClone<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TValue : class, IDeepCloneable
		{
			if (dictionary == null)
			{
				return null;
			}
			Dictionary<TKey, TValue> dictionary2 = new Dictionary<TKey, TValue>();
			using (Dictionary<TKey, TValue>.Enumerator enumerator = dictionary.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						KeyValuePair<TKey, TValue> current = enumerator.Current;
						dictionary2.Add(current.Key, DeepClone(current.Value));
						int num = 1759980141;
						while (true)
						{
							switch (num ^ 0x68E72A6D)
							{
							case 2:
								num = 1759980140;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0032;
							}
							break;
						}
						continue;
						end_IL_0032:
						break;
					}
				}
				return dictionary2;
			}
		}

		public static Guid CreateGuidHashSHA256(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				goto IL_0008;
			}
			SHA256Managed sHA256Managed = new SHA256Managed();
			byte[] sourceArray = sHA256Managed.ComputeHash(Encoding.UTF8.GetBytes(text));
			int num = -1767606300;
			goto IL_000d;
			IL_000d:
			byte[] array = default(byte[]);
			while (true)
			{
				switch (num ^ -1767606298)
				{
				case 0:
					break;
				case 3:
					return Guid.Empty;
				case 2:
					goto IL_004f;
				default:
					return new Guid(array);
				}
				break;
				IL_004f:
				array = new byte[16];
				Array.Copy(sourceArray, array, 16);
				num = -1767606297;
			}
			goto IL_0008;
			IL_0008:
			num = -1767606299;
			goto IL_000d;
		}

		public static Guid CreateGuidHashSHA1(string text)
		{
			using (SHA1 sHA = SHA1.Create())
			{
				byte[] sourceArray = sHA.ComputeHash(Encoding.UTF8.GetBytes(text));
				byte[] array = new byte[16];
				Array.Copy(sourceArray, array, 16);
				return new Guid(array);
			}
		}

		public static Guid CreateHIDProductGuid(int vendorId, int productId)
		{
			string g = ((ushort)productId).ToString("x4") + ((ushort)vendorId).ToString("x4") + "-0000-0000-0000-504944564944";
			return new Guid(g);
		}

		public static uint Tick(uint counter)
		{
			if (counter == LqeIUlMBSqQsacSffglSBCsrrVoK)
			{
				goto IL_0008;
			}
			goto IL_0038;
			IL_0008:
			int num = -1308707280;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1308707279)
				{
				case 2:
					break;
				case 1:
					counter = lAzEDsicxRUozHmbqceQCeXSquf;
					num = -1308707278;
					continue;
				case 0:
					goto IL_0038;
				default:
					return counter;
				}
				break;
			}
			goto IL_0008;
			IL_0038:
			counter++;
			num = -1308707278;
			goto IL_000d;
		}

		public static int Tick(int counter)
		{
			if (counter == jPzEEeSvBfJHleFTEsOJzZWsKdW)
			{
				goto IL_0008;
			}
			goto IL_0038;
			IL_0008:
			int num = 1442798305;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x55FF5AE0)
				{
				case 3:
					break;
				case 1:
					counter = xUvhRPwUpoIvUGPSnVWOtfiOfQN;
					num = 1442798306;
					continue;
				case 0:
					goto IL_0038;
				default:
					return counter;
				}
				break;
			}
			goto IL_0008;
			IL_0038:
			counter++;
			num = 1442798306;
			goto IL_000d;
		}

		public static uint TickPrev(uint counter)
		{
			if (counter == lAzEDsicxRUozHmbqceQCeXSquf)
			{
				counter = LqeIUlMBSqQsacSffglSBCsrrVoK;
			}
			else
			{
				while (true)
				{
					counter--;
					int num = 1065303262;
					while (true)
					{
						switch (num ^ 0x3F7F3CDE)
						{
						case 2:
							num = 1065303263;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002f;
						}
						break;
					}
					continue;
					end_IL_002f:
					break;
				}
			}
			return counter;
		}

		public static int TickPrev(int counter)
		{
			if (counter <= RqtFfmuxIYDhHnbEoGUmikMBHab)
			{
				goto IL_0008;
			}
			int num;
			int num2;
			if (counter != xUvhRPwUpoIvUGPSnVWOtfiOfQN)
			{
				num = 857353278;
				num2 = num;
			}
			else
			{
				num = 857353276;
				num2 = num;
			}
			goto IL_000d;
			IL_0008:
			num = 857353275;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x331A2C3F)
				{
				case 2:
					break;
				case 4:
					return jPzEEeSvBfJHleFTEsOJzZWsKdW;
				case 5:
					num = 857353279;
					continue;
				case 3:
					counter = jPzEEeSvBfJHleFTEsOJzZWsKdW;
					num = 857353274;
					continue;
				case 1:
					counter--;
					num = 857353279;
					continue;
				default:
					return counter;
				}
				break;
			}
			goto IL_0008;
		}

		public static bool IsTickValid(uint tick)
		{
			return tick != iiLBhFyhzBIoCTEOOQvuOpyfWgF;
		}

		public static bool IsTickValid(int tick)
		{
			return tick > RqtFfmuxIYDhHnbEoGUmikMBHab;
		}

		public static bool IsTickNewer(uint tick1, uint tick2)
		{
			if (tick1 == tick2)
			{
				return false;
			}
			if (tick1 == iiLBhFyhzBIoCTEOOQvuOpyfWgF)
			{
				return false;
			}
			if (tick2 == iiLBhFyhzBIoCTEOOQvuOpyfWgF)
			{
				return true;
			}
			if (tick1 < tick2)
			{
				if (tick2 - tick1 < 2147483648u)
				{
					return false;
				}
			}
			else if (tick1 > tick2 && tick1 - tick2 > 2147483648u)
			{
				return false;
			}
			return true;
		}

		public static bool IsTickNewer(int tick1, int tick2)
		{
			if (tick1 == tick2)
			{
				goto IL_0004;
			}
			if (tick1 <= RqtFfmuxIYDhHnbEoGUmikMBHab)
			{
				return false;
			}
			if (tick2 <= RqtFfmuxIYDhHnbEoGUmikMBHab)
			{
				return true;
			}
			int num;
			if (tick1 < tick2)
			{
				if (tick2 - tick1 < 1073741823)
				{
					return false;
				}
			}
			else if (tick1 > tick2)
			{
				num = 1671548453;
				goto IL_0009;
			}
			goto IL_005f;
			IL_0053:
			if (tick1 - tick2 > 1073741823)
			{
				return false;
			}
			goto IL_005f;
			IL_005f:
			return true;
			IL_0004:
			num = 1671548454;
			goto IL_0009;
			IL_0009:
			switch (num ^ 0x63A1CE27)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				goto IL_0053;
			}
			goto IL_0004;
		}

		public static bool IsTickNewerOrEqualTo(uint tick1, uint tick2)
		{
			if (tick1 == tick2)
			{
				return true;
			}
			if (tick1 == iiLBhFyhzBIoCTEOOQvuOpyfWgF)
			{
				return false;
			}
			if (tick2 == iiLBhFyhzBIoCTEOOQvuOpyfWgF)
			{
				return true;
			}
			if (tick1 < tick2)
			{
				if (tick2 - tick1 < 2147483648u)
				{
					return false;
				}
			}
			else if (tick1 > tick2 && tick1 - tick2 > 2147483648u)
			{
				return false;
			}
			return true;
		}

		public static bool IsTickNewerOrEqualTo(int tick1, int tick2)
		{
			if (tick1 == tick2)
			{
				return true;
			}
			if (tick1 <= RqtFfmuxIYDhHnbEoGUmikMBHab)
			{
				return false;
			}
			if (tick2 <= RqtFfmuxIYDhHnbEoGUmikMBHab)
			{
				return true;
			}
			if (tick1 < tick2)
			{
				if (tick2 - tick1 < 1073741823)
				{
					return false;
				}
			}
			else if (tick1 > tick2 && tick1 - tick2 > 1073741823)
			{
				return false;
			}
			return true;
		}

		public static void Swap<T>(ref T a, ref T b)
		{
			T val = a;
			a = b;
			b = val;
		}

		public static long ToLongUnchecked(object value)
		{
			if (value is int)
			{
				return (int)value;
			}
			if (value is uint)
			{
				goto IL_0018;
			}
			int num;
			if (value is byte)
			{
				num = -967850942;
			}
			else
			{
				if (value is sbyte)
				{
					return (sbyte)value;
				}
				if (value is short)
				{
					return (short)value;
				}
				if (value is ushort)
				{
					return (ushort)value;
				}
				if (value is long)
				{
					return (long)value;
				}
				if (value is ulong)
				{
					num = -967850940;
				}
				else
				{
					if (value is float)
					{
						return (long)(float)value;
					}
					if (!(value is double))
					{
						if (value is decimal)
						{
							return (long)(decimal)value;
						}
						throw new ArgumentException("value must be an integral type (excluding char).");
					}
					num = -967850937;
				}
			}
			goto IL_001d;
			IL_001d:
			switch (num ^ -967850938)
			{
			case 0:
				break;
			case 3:
				return (uint)value;
			case 4:
				return (byte)value;
			case 2:
				return (long)(ulong)value;
			default:
				return (long)(double)value;
			}
			goto IL_0018;
			IL_0018:
			num = -967850939;
			goto IL_001d;
		}

		public static bool IsValidGuid(string guid)
		{
			try
			{
				new Guid(guid);
				return true;
			}
			catch
			{
				return false;
			}
		}

		static MiscTools()
		{
			while (true)
			{
				int num = 1367627452;
				while (true)
				{
					switch (num ^ 0x518456BD)
					{
					case 0:
						break;
					case 1:
						goto IL_0024;
					default:
						RqtFfmuxIYDhHnbEoGUmikMBHab = -1;
						return;
					}
					break;
					IL_0024:
					lAzEDsicxRUozHmbqceQCeXSquf = 1u;
					LqeIUlMBSqQsacSffglSBCsrrVoK = uint.MaxValue;
					xUvhRPwUpoIvUGPSnVWOtfiOfQN = 0;
					jPzEEeSvBfJHleFTEsOJzZWsKdW = int.MaxValue;
					num = 1367627455;
				}
			}
		}
	}
}
