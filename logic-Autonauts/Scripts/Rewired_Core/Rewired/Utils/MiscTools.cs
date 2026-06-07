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
		private static uint FTfMUWAdDXbzIbZqrIyOzyttTUa = 0u;

		private static uint GzdKOpErpNHTYtAyQeuIlaTKlIa = 1u;

		private static uint cUcNBwwrEqTRXQZcDvrObcifWOl;

		private static int MMbDaYWKpcebxDeVRIVKBKaQauSR;

		private static int OMlOZtkdNrJiCMnSstKBUYUsnsV;

		private static int aLrEGnEpWSmZcFLTKAOaPIOBfry;

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
					int num2 = -1955377202;
					while (true)
					{
						switch (num2 ^ -1955377201)
						{
						case 0:
							num2 = -1955377203;
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
			int num = 821530999;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x30F79173)
				{
				case 0:
					break;
				case 1:
					list.Add(DeepClone(obj[num2]));
					num2++;
					num = 821530992;
					continue;
				case 4:
					num2 = 0;
					num = 821530992;
					continue;
				case 2:
					return null;
				default:
					if (num2 >= obj.Count)
					{
						return list;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num = 821530993;
			goto IL_0008;
		}

		public static Dictionary<TKey, TValue> DeepClone<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TValue : class, IDeepCloneable
		{
			if (dictionary == null)
			{
				goto IL_0003;
			}
			Dictionary<TKey, TValue> dictionary2 = new Dictionary<TKey, TValue>();
			int num = 1532874982;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x5B5DD0E4)
			{
			case 0:
				break;
			case 1:
				return null;
			default:
			{
				using (Dictionary<TKey, TValue>.Enumerator enumerator = dictionary.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							KeyValuePair<TKey, TValue> current = enumerator.Current;
							int num2 = 1532874981;
							while (true)
							{
								switch (num2 ^ 0x5B5DD0E4)
								{
								case 3:
									num2 = 1532874982;
									continue;
								case 2:
									break;
								case 1:
									dictionary2.Add(current.Key, DeepClone(current.Value));
									num2 = 1532874980;
									continue;
								default:
									goto end_IL_005b;
								}
								break;
							}
							continue;
							end_IL_005b:
							break;
						}
					}
					return dictionary2;
				}
			}
			}
			goto IL_0003;
			IL_0003:
			num = 1532874981;
			goto IL_0008;
		}

		public static Guid CreateGuidHashSHA256(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return Guid.Empty;
			}
			SHA256Managed sHA256Managed = new SHA256Managed();
			byte[] sourceArray = default(byte[]);
			byte[] array = default(byte[]);
			while (true)
			{
				int num = 526566733;
				while (true)
				{
					switch (num ^ 0x1F62C54C)
					{
					case 0:
						break;
					case 1:
						sourceArray = sHA256Managed.ComputeHash(Encoding.UTF8.GetBytes(text));
						num = 526566734;
						continue;
					case 2:
						array = new byte[16];
						Array.Copy(sourceArray, array, 16);
						num = 526566735;
						continue;
					default:
						return new Guid(array);
					}
					break;
				}
			}
		}

		public static Guid CreateGuidHashSHA1(string text)
		{
			using (SHA1 sHA = SHA1.Create())
			{
				byte[] sourceArray = sHA.ComputeHash(Encoding.UTF8.GetBytes(text));
				byte[] array = new byte[16];
				while (true)
				{
					int num = -181548900;
					while (true)
					{
						switch (num ^ -181548898)
						{
						case 0:
							break;
						case 2:
							goto IL_003e;
						default:
							return new Guid(array);
						}
						break;
						IL_003e:
						Array.Copy(sourceArray, array, 16);
						num = -181548897;
					}
				}
			}
		}

		public static Guid CreateHIDProductGuid(int vendorId, int productId)
		{
			string g = ((ushort)productId).ToString("x4") + ((ushort)vendorId).ToString("x4") + "-0000-0000-0000-504944564944";
			return new Guid(g);
		}

		public static uint Tick(uint counter)
		{
			if (counter == cUcNBwwrEqTRXQZcDvrObcifWOl)
			{
				counter = GzdKOpErpNHTYtAyQeuIlaTKlIa;
			}
			else
			{
				while (true)
				{
					counter++;
					int num = -942338761;
					while (true)
					{
						switch (num ^ -942338761)
						{
						case 2:
							num = -942338762;
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

		public static int Tick(int counter)
		{
			if (counter == OMlOZtkdNrJiCMnSstKBUYUsnsV)
			{
				counter = MMbDaYWKpcebxDeVRIVKBKaQauSR;
			}
			else
			{
				while (true)
				{
					counter++;
					int num = -170919654;
					while (true)
					{
						switch (num ^ -170919656)
						{
						case 0:
							num = -170919655;
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

		public static uint TickPrev(uint counter)
		{
			if (counter == GzdKOpErpNHTYtAyQeuIlaTKlIa)
			{
				counter = cUcNBwwrEqTRXQZcDvrObcifWOl;
				goto IL_000f;
			}
			goto IL_0038;
			IL_0038:
			counter--;
			int num = 2038572089;
			goto IL_0014;
			IL_000f:
			num = 2038572090;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num ^ 0x79822438)
				{
				case 0:
					break;
				case 2:
					num = 2038572089;
					continue;
				case 3:
					goto IL_0038;
				default:
					return counter;
				}
				break;
			}
			goto IL_000f;
		}

		public static int TickPrev(int counter)
		{
			if (counter <= aLrEGnEpWSmZcFLTKAOaPIOBfry)
			{
				goto IL_0008;
			}
			int num;
			if (counter == MMbDaYWKpcebxDeVRIVKBKaQauSR)
			{
				counter = OMlOZtkdNrJiCMnSstKBUYUsnsV;
				num = 1690731481;
				goto IL_000d;
			}
			goto IL_0046;
			IL_000d:
			switch (num ^ 0x64C683D8)
			{
			case 0:
				break;
			case 2:
				return OMlOZtkdNrJiCMnSstKBUYUsnsV;
			case 3:
				goto IL_0046;
			default:
				return counter;
			}
			goto IL_0008;
			IL_0046:
			counter--;
			num = 1690731481;
			goto IL_000d;
			IL_0008:
			num = 1690731482;
			goto IL_000d;
		}

		public static bool IsTickValid(uint tick)
		{
			return tick != FTfMUWAdDXbzIbZqrIyOzyttTUa;
		}

		public static bool IsTickValid(int tick)
		{
			return tick > aLrEGnEpWSmZcFLTKAOaPIOBfry;
		}

		public static bool IsTickNewer(uint tick1, uint tick2)
		{
			int num;
			if (tick1 != tick2)
			{
				if (tick1 == FTfMUWAdDXbzIbZqrIyOzyttTUa)
				{
					return false;
				}
				if (tick2 == FTfMUWAdDXbzIbZqrIyOzyttTUa)
				{
					return true;
				}
				if (tick1 < tick2)
				{
					if (tick2 - tick1 < 2147483648u)
					{
						num = 1834416929;
						goto IL_0009;
					}
				}
				else if (tick1 > tick2 && tick1 - tick2 > 2147483648u)
				{
					return false;
				}
				return true;
			}
			goto IL_0004;
			IL_0009:
			switch (num ^ 0x6D56FB23)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_0004;
			IL_0004:
			num = 1834416930;
			goto IL_0009;
		}

		public static bool IsTickNewer(int tick1, int tick2)
		{
			if (tick1 == tick2)
			{
				return false;
			}
			if (tick1 <= aLrEGnEpWSmZcFLTKAOaPIOBfry)
			{
				return false;
			}
			if (tick2 <= aLrEGnEpWSmZcFLTKAOaPIOBfry)
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

		public static bool IsTickNewerOrEqualTo(uint tick1, uint tick2)
		{
			if (tick1 == tick2)
			{
				return true;
			}
			if (tick1 == FTfMUWAdDXbzIbZqrIyOzyttTUa)
			{
				return false;
			}
			if (tick2 == FTfMUWAdDXbzIbZqrIyOzyttTUa)
			{
				goto IL_0018;
			}
			int num;
			if (tick1 < tick2)
			{
				if (tick2 - tick1 < 2147483648u)
				{
					return false;
				}
			}
			else if (tick1 > tick2)
			{
				num = 1519916197;
				goto IL_001d;
			}
			goto IL_005f;
			IL_005f:
			return true;
			IL_0018:
			num = 1519916196;
			goto IL_001d;
			IL_001d:
			switch (num ^ 0x5A9814A5)
			{
			case 2:
				break;
			case 1:
				return true;
			default:
				goto IL_0053;
			}
			goto IL_0018;
			IL_0053:
			if (tick1 - tick2 > 2147483648u)
			{
				return false;
			}
			goto IL_005f;
		}

		public static bool IsTickNewerOrEqualTo(int tick1, int tick2)
		{
			if (tick1 == tick2)
			{
				return true;
			}
			if (tick1 <= aLrEGnEpWSmZcFLTKAOaPIOBfry)
			{
				goto IL_000e;
			}
			int num;
			if (tick2 <= aLrEGnEpWSmZcFLTKAOaPIOBfry)
			{
				num = -1640963989;
				goto IL_0013;
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
			IL_000e:
			num = -1640963990;
			goto IL_0013;
			IL_0013:
			switch (num ^ -1640963989)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_000e;
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
				goto IL_0008;
			}
			if (value is uint)
			{
				return (uint)value;
			}
			int num;
			if (value is byte)
			{
				num = -469598915;
			}
			else
			{
				if (value is sbyte)
				{
					return (sbyte)value;
				}
				if (!(value is short))
				{
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
						return (long)(ulong)value;
					}
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
					num = -469598919;
				}
				else
				{
					num = -469598920;
				}
			}
			goto IL_000d;
			IL_0008:
			num = -469598918;
			goto IL_000d;
			IL_000d:
			switch (num ^ -469598919)
			{
			case 2:
				break;
			case 3:
				return (int)value;
			case 1:
				return (short)value;
			case 4:
				return (byte)value;
			default:
				return (long)(double)value;
			}
			goto IL_0008;
		}

		public static bool IsValidGuid(string guid)
		{
			bool result = default(bool);
			try
			{
				new Guid(guid);
				while (true)
				{
					IL_0007:
					int num = -1846780084;
					while (true)
					{
						switch (num ^ -1846780083)
						{
						case 0:
							break;
						default:
							goto end_IL_000c;
						case 1:
							goto IL_0025;
						case 2:
							goto end_IL_000c;
						}
						goto IL_0007;
						IL_0025:
						result = true;
						num = -1846780081;
						continue;
						end_IL_000c:
						break;
					}
					break;
				}
			}
			catch
			{
				while (true)
				{
					IL_0031:
					int num2 = -1846780081;
					while (true)
					{
						switch (num2 ^ -1846780083)
						{
						case 0:
							break;
						default:
							goto end_IL_0036;
						case 2:
							goto IL_004f;
						case 1:
							goto end_IL_0036;
						}
						goto IL_0031;
						IL_004f:
						result = false;
						num2 = -1846780084;
						continue;
						end_IL_0036:
						break;
					}
					break;
				}
			}
			return result;
		}

		static MiscTools()
		{
			while (true)
			{
				int num = -849460753;
				while (true)
				{
					switch (num ^ -849460754)
					{
					case 0:
						break;
					case 1:
						goto IL_002a;
					default:
						OMlOZtkdNrJiCMnSstKBUYUsnsV = int.MaxValue;
						aLrEGnEpWSmZcFLTKAOaPIOBfry = -1;
						return;
					}
					break;
					IL_002a:
					cUcNBwwrEqTRXQZcDvrObcifWOl = uint.MaxValue;
					MMbDaYWKpcebxDeVRIVKBKaQauSR = 0;
					num = -849460756;
				}
			}
		}
	}
}
