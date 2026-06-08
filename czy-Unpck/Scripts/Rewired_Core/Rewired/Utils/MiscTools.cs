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
		private static uint uxHTpZwKYHweaWgenfvjArQwIMjj = 0u;

		private static uint rdfKhewBQFzYLCGVTnTRzMxDsvV;

		private static uint TqoeudSfzefIOxyLAUADrgEwORO;

		private static int dLzrZRucGcEwwZPiWayHGiEDjhpC;

		private static int jNnAamGtejkfDdNrzEbAUGmretiA;

		private static int NpvGruwTdSJpreFyPqhjTBoKmoD;

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
			while (true)
			{
				int num2 = -319738827;
				while (true)
				{
					switch (num2 ^ -319738828)
					{
					case 3:
						break;
					case 1:
						num2 = -319738828;
						continue;
					case 2:
						array[num] = DeepClone(obj[num]);
						num++;
						num2 = -319738828;
						continue;
					default:
						if (num >= obj.Length)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public static List<T> DeepClone<T>(List<T> obj) where T : class, IDeepCloneable
		{
			if (obj == null)
			{
				return null;
			}
			List<T> list = new List<T>(obj.Count);
			int num2 = default(int);
			while (true)
			{
				int num = 1513210557;
				while (true)
				{
					switch (num ^ 0x5A31C2BC)
					{
					case 5:
						break;
					case 3:
						list.Add(DeepClone(obj[num2]));
						num = 1513210558;
						continue;
					case 0:
						num = 1513210552;
						continue;
					case 2:
						num2++;
						num = 1513210552;
						continue;
					case 1:
						num2 = 0;
						num = 1513210556;
						continue;
					default:
						if (num2 >= obj.Count)
						{
							return list;
						}
						goto case 3;
					}
					break;
				}
			}
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
						int num = 227563688;
						while (true)
						{
							switch (num ^ 0xD9058AB)
							{
							case 0:
								num = 227563689;
								continue;
							case 2:
								break;
							case 3:
								dictionary2.Add(current.Key, DeepClone(current.Value));
								num = 227563690;
								continue;
							default:
								goto end_IL_0036;
							}
							break;
						}
						continue;
						end_IL_0036:
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
			int num = -2142102081;
			goto IL_000d;
			IL_000d:
			byte[] sourceArray = default(byte[]);
			byte[] array = default(byte[]);
			while (true)
			{
				switch (num ^ -2142102082)
				{
				case 3:
					break;
				case 2:
					return Guid.Empty;
				case 1:
					goto IL_003d;
				default:
					Array.Copy(sourceArray, array, 16);
					return new Guid(array);
				}
				break;
				IL_003d:
				sourceArray = sHA256Managed.ComputeHash(Encoding.UTF8.GetBytes(text));
				array = new byte[16];
				num = -2142102082;
			}
			goto IL_0008;
			IL_0008:
			num = -2142102084;
			goto IL_000d;
		}

		public static Guid CreateGuidHashSHA1(string text)
		{
			Guid result = default(Guid);
			using (SHA1 sHA = SHA1.Create())
			{
				byte[] sourceArray = sHA.ComputeHash(Encoding.UTF8.GetBytes(text));
				while (true)
				{
					IL_0018:
					int num = 1232233172;
					while (true)
					{
						switch (num ^ 0x497262D5)
						{
						case 2:
							break;
						default:
							goto end_IL_001d;
						case 1:
							goto IL_0036;
						case 0:
							goto end_IL_001d;
						}
						goto IL_0018;
						IL_0036:
						byte[] array = new byte[16];
						Array.Copy(sourceArray, array, 16);
						result = new Guid(array);
						num = 1232233173;
						continue;
						end_IL_001d:
						break;
					}
					break;
				}
			}
			return result;
		}

		public static Guid CreateHIDProductGuid(int vendorId, int productId)
		{
			string g = ((ushort)productId).ToString("x4") + ((ushort)vendorId).ToString("x4") + "-0000-0000-0000-504944564944";
			return new Guid(g);
		}

		public static uint Tick(uint counter)
		{
			if (counter == TqoeudSfzefIOxyLAUADrgEwORO)
			{
				goto IL_0008;
			}
			goto IL_0043;
			IL_0008:
			int num = -38730802;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -38730801)
				{
				case 2:
					break;
				case 1:
					counter = rdfKhewBQFzYLCGVTnTRzMxDsvV;
					num = -38730801;
					continue;
				case 0:
					num = -38730804;
					continue;
				case 4:
					goto IL_0043;
				default:
					return counter;
				}
				break;
			}
			goto IL_0008;
			IL_0043:
			counter++;
			num = -38730804;
			goto IL_000d;
		}

		public static int Tick(int counter)
		{
			if (counter == jNnAamGtejkfDdNrzEbAUGmretiA)
			{
				goto IL_0008;
			}
			goto IL_0038;
			IL_0008:
			int num = 1762715789;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x6910E88F)
				{
				case 0:
					break;
				case 2:
					counter = dLzrZRucGcEwwZPiWayHGiEDjhpC;
					num = 1762715788;
					continue;
				case 1:
					goto IL_0038;
				default:
					return counter;
				}
				break;
			}
			goto IL_0008;
			IL_0038:
			counter++;
			num = 1762715788;
			goto IL_000d;
		}

		public static uint TickPrev(uint counter)
		{
			if (counter == rdfKhewBQFzYLCGVTnTRzMxDsvV)
			{
				counter = TqoeudSfzefIOxyLAUADrgEwORO;
			}
			else
			{
				while (true)
				{
					counter--;
					int num = 2100310354;
					while (true)
					{
						switch (num ^ 0x7D303153)
						{
						case 0:
							num = 2100310353;
							continue;
						case 2:
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
			if (counter <= NpvGruwTdSJpreFyPqhjTBoKmoD)
			{
				return jNnAamGtejkfDdNrzEbAUGmretiA;
			}
			if (counter == dLzrZRucGcEwwZPiWayHGiEDjhpC)
			{
				counter = jNnAamGtejkfDdNrzEbAUGmretiA;
				goto IL_001d;
			}
			goto IL_0046;
			IL_0022:
			int num;
			while (true)
			{
				switch (num ^ -1543466653)
				{
				case 0:
					break;
				case 1:
					num = -1543466655;
					continue;
				case 3:
					goto IL_0046;
				default:
					return counter;
				}
				break;
			}
			goto IL_001d;
			IL_0046:
			counter--;
			num = -1543466655;
			goto IL_0022;
			IL_001d:
			num = -1543466654;
			goto IL_0022;
		}

		public static bool IsTickValid(uint tick)
		{
			return tick != uxHTpZwKYHweaWgenfvjArQwIMjj;
		}

		public static bool IsTickValid(int tick)
		{
			return tick > NpvGruwTdSJpreFyPqhjTBoKmoD;
		}

		public static bool IsTickNewer(uint tick1, uint tick2)
		{
			if (tick1 == tick2)
			{
				return false;
			}
			if (tick1 == uxHTpZwKYHweaWgenfvjArQwIMjj)
			{
				return false;
			}
			int num;
			if (tick2 != uxHTpZwKYHweaWgenfvjArQwIMjj)
			{
				if (tick1 < tick2)
				{
					if (tick2 - tick1 < 2147483648u)
					{
						num = -861726630;
						goto IL_001d;
					}
				}
				else if (tick1 > tick2 && tick1 - tick2 > 2147483648u)
				{
					num = -861726631;
					goto IL_001d;
				}
				return true;
			}
			goto IL_0018;
			IL_0018:
			num = -861726629;
			goto IL_001d;
			IL_001d:
			switch (num ^ -861726630)
			{
			case 2:
				break;
			case 1:
				return true;
			case 0:
				return false;
			default:
				return false;
			}
			goto IL_0018;
		}

		public static bool IsTickNewer(int tick1, int tick2)
		{
			if (tick1 == tick2)
			{
				return false;
			}
			if (tick1 <= NpvGruwTdSJpreFyPqhjTBoKmoD)
			{
				return false;
			}
			if (tick2 <= NpvGruwTdSJpreFyPqhjTBoKmoD)
			{
				return true;
			}
			if (tick1 < tick2)
			{
				goto IL_001e;
			}
			int num;
			if (tick1 > tick2)
			{
				num = 1216638437;
				goto IL_0023;
			}
			goto IL_006a;
			IL_006a:
			return true;
			IL_0023:
			while (true)
			{
				switch (num ^ 0x48846DE4)
				{
				case 3:
					break;
				case 2:
					goto IL_0040;
				case 1:
					goto IL_0057;
				default:
					return false;
				}
				break;
				IL_0057:
				if (tick1 - tick2 > 1073741823)
				{
					num = 1216638436;
					continue;
				}
				goto IL_006a;
				IL_0040:
				if (tick2 - tick1 < 1073741823)
				{
					return false;
				}
				goto IL_006a;
			}
			goto IL_001e;
			IL_001e:
			num = 1216638438;
			goto IL_0023;
		}

		public static bool IsTickNewerOrEqualTo(uint tick1, uint tick2)
		{
			if (tick1 == tick2)
			{
				return true;
			}
			if (tick1 == uxHTpZwKYHweaWgenfvjArQwIMjj)
			{
				goto IL_000e;
			}
			int num;
			if (tick2 != uxHTpZwKYHweaWgenfvjArQwIMjj)
			{
				if (tick1 >= tick2)
				{
					if (tick1 <= tick2 || tick1 - tick2 <= 2147483648u)
					{
						goto IL_0075;
					}
					num = 1030007743;
				}
				else
				{
					num = 1030007737;
				}
			}
			else
			{
				num = 1030007740;
			}
			goto IL_0013;
			IL_0034:
			if (tick2 - tick1 < 2147483648u)
			{
				return false;
			}
			goto IL_0075;
			IL_0013:
			switch (num ^ 0x3D64ABBD)
			{
			case 0:
				break;
			case 4:
				goto IL_0034;
			case 1:
				return true;
			case 3:
				return false;
			default:
				return false;
			}
			goto IL_000e;
			IL_000e:
			num = 1030007742;
			goto IL_0013;
			IL_0075:
			return true;
		}

		public static bool IsTickNewerOrEqualTo(int tick1, int tick2)
		{
			if (tick1 == tick2)
			{
				return true;
			}
			if (tick1 <= NpvGruwTdSJpreFyPqhjTBoKmoD)
			{
				goto IL_000e;
			}
			if (tick2 <= NpvGruwTdSJpreFyPqhjTBoKmoD)
			{
				return true;
			}
			int num;
			if (tick1 < tick2)
			{
				if (tick2 - tick1 < 1073741823)
				{
					num = 2104791595;
					goto IL_0013;
				}
			}
			else if (tick1 > tick2)
			{
				num = 2104791594;
				goto IL_0013;
			}
			goto IL_006a;
			IL_0013:
			switch (num ^ 0x7D74922B)
			{
			case 2:
				break;
			case 3:
				return false;
			case 0:
				return false;
			default:
				goto IL_005e;
			}
			goto IL_000e;
			IL_006a:
			return true;
			IL_000e:
			num = 2104791592;
			goto IL_0013;
			IL_005e:
			if (tick1 - tick2 > 1073741823)
			{
				return false;
			}
			goto IL_006a;
		}

		public static long TickDifference(uint tick1, uint tick2)
		{
			if (tick1 == tick2)
			{
				goto IL_0004;
			}
			if (tick1 == uxHTpZwKYHweaWgenfvjArQwIMjj)
			{
				return 0L;
			}
			if (tick2 == uxHTpZwKYHweaWgenfvjArQwIMjj)
			{
				return 0L;
			}
			uint num = default(uint);
			uint num2 = default(uint);
			int num3;
			if (tick1 < tick2)
			{
				num = tick2;
				num2 = tick1;
				num3 = -2120835361;
				goto IL_0009;
			}
			goto IL_003f;
			IL_003f:
			num = tick1;
			num2 = tick2;
			num3 = -2120835361;
			goto IL_0009;
			IL_0004:
			num3 = -2120835367;
			goto IL_0009;
			IL_0009:
			uint num4 = default(uint);
			while (true)
			{
				switch (num3 ^ -2120835366)
				{
				case 0:
					break;
				case 5:
					goto IL_002e;
				case 2:
					goto IL_003f;
				case 3:
					return 0L;
				case 4:
					return (long)tick1 - (long)tick2;
				default:
					return 0L - (long)num4;
				}
				break;
				IL_002e:
				if (num - num2 < 2147483648u)
				{
					num3 = -2120835362;
					continue;
				}
				uint num5 = TqoeudSfzefIOxyLAUADrgEwORO - num + num2;
				uint num6 = rdfKhewBQFzYLCGVTnTRzMxDsvV;
				num4 = num5 - num6;
				if (tick1 >= tick2)
				{
					num3 = -2120835365;
					continue;
				}
				return num4;
			}
			goto IL_0004;
		}

		public static int TickDifference(int tick1, int tick2)
		{
			if (tick1 == tick2)
			{
				return 0;
			}
			if (tick1 <= NpvGruwTdSJpreFyPqhjTBoKmoD)
			{
				goto IL_000e;
			}
			int num;
			int num2;
			if (tick2 <= NpvGruwTdSJpreFyPqhjTBoKmoD)
			{
				num = 146709778;
			}
			else if (tick1 >= tick2)
			{
				num = 146709783;
				num2 = num;
			}
			else
			{
				num = 146709782;
				num2 = num;
			}
			goto IL_0013;
			IL_000e:
			num = 146709781;
			goto IL_0013;
			IL_0013:
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ 0x8BE9D17)
				{
				case 4:
					break;
				case 2:
					return 0;
				case 0:
					num3 = tick1;
					num4 = tick2;
					num = 146709780;
					continue;
				case 5:
					return 0;
				case 1:
					num3 = tick2;
					num4 = tick1;
					num = 146709780;
					continue;
				default:
				{
					if (num3 - num4 < 1073741823)
					{
						return tick1 - tick2;
					}
					int num5 = jNnAamGtejkfDdNrzEbAUGmretiA - num3 + num4;
					int num6 = dLzrZRucGcEwwZPiWayHGiEDjhpC;
					int num7 = num5 - num6;
					if (tick1 >= tick2)
					{
						return -num7;
					}
					return num7;
				}
				}
				break;
			}
			goto IL_000e;
		}

		public static void Swap<T>(ref T a, ref T b)
		{
			T val = a;
			while (true)
			{
				int num = -1433673685;
				while (true)
				{
					switch (num ^ -1433673686)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						a = b;
						num = -1433673688;
						continue;
					case 2:
						b = val;
						num = -1433673687;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public static long ToLongUnchecked(object value)
		{
			if (value is int)
			{
				return (int)value;
			}
			if (value is uint)
			{
				return (uint)value;
			}
			if (value is byte)
			{
				return (byte)value;
			}
			if (value is sbyte)
			{
				goto IL_0038;
			}
			if (value is short)
			{
				return (short)value;
			}
			if (value is ushort)
			{
				return (ushort)value;
			}
			int num;
			if (value is long)
			{
				num = -121440684;
				goto IL_003d;
			}
			if (value is ulong)
			{
				return (long)(ulong)value;
			}
			if (value is float)
			{
				return (long)(float)value;
			}
			if (value is double)
			{
				return (long)(double)value;
			}
			if (value is decimal)
			{
				return (long)(decimal)value;
			}
			throw new ArgumentException("value must be an integral type (excluding char).");
			IL_0038:
			num = -121440681;
			goto IL_003d;
			IL_003d:
			switch (num ^ -121440682)
			{
			case 0:
				break;
			case 1:
				return (sbyte)value;
			default:
				return (long)value;
			}
			goto IL_0038;
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
				int num = 985344172;
				while (true)
				{
					switch (num ^ 0x3ABB28AD)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						TqoeudSfzefIOxyLAUADrgEwORO = uint.MaxValue;
						dLzrZRucGcEwwZPiWayHGiEDjhpC = 0;
						jNnAamGtejkfDdNrzEbAUGmretiA = int.MaxValue;
						NpvGruwTdSJpreFyPqhjTBoKmoD = -1;
						return;
					}
					break;
					IL_0024:
					rdfKhewBQFzYLCGVTnTRzMxDsvV = 1u;
					num = 985344173;
				}
			}
		}
	}
}
