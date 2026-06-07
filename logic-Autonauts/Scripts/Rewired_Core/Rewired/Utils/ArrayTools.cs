using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils
{
	public static class ArrayTools
	{
		public static int[] ConvertToIntArray(Array array)
		{
			if (array == null || array.Length == 0)
			{
				return null;
			}
			int[] array2 = new int[array.Length];
			int num = 0;
			IEnumerator enumerator = array.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						object current = enumerator.Current;
						array2[num++] = Convert.ToInt32(current);
						int num2 = -686337111;
						while (true)
						{
							switch (num2 ^ -686337109)
							{
							case 0:
								num2 = -686337110;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0048;
							}
							break;
						}
						continue;
						end_IL_0048:
						break;
					}
				}
				return array2;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public static T[] DeepClone<T>(T[] array) where T : class, IDeepCloneable
		{
			if (array == null)
			{
				goto IL_0003;
			}
			T[] array2 = new T[array.Length];
			int num = 0;
			int num2 = -1692063045;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ -1692063045)
				{
				case 3:
					break;
				case 4:
					return null;
				case 2:
					num++;
					num2 = -1692063045;
					continue;
				case 1:
				{
					int num3;
					if (array[num] != null)
					{
						num2 = -1692063042;
						num3 = num2;
					}
					else
					{
						num2 = -1692063047;
						num3 = num2;
					}
					continue;
				}
				case 5:
					array2[num] = array[num].DeepClone() as T;
					num2 = -1692063047;
					continue;
				default:
					if (num >= array.Length)
					{
						return array2;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = -1692063041;
			goto IL_0008;
		}

		public static T[] ShallowCopy<T>(T[] array)
		{
			if (array == null)
			{
				return null;
			}
			T[] array2 = new T[array.Length];
			Array.Copy(array, array2, array.Length);
			return array2;
		}

		public static void ShallowCopy<T>(T[] sourceArray, T[] targetArray)
		{
			if (sourceArray != null && targetArray != null)
			{
				int length = Math.Min(sourceArray.Length, targetArray.Length);
				Array.Copy(sourceArray, targetArray, length);
			}
		}

		public static void ShallowCopy(int[] sourceArray, int[] targetArray)
		{
			if (sourceArray == null)
			{
				return;
			}
			while (targetArray != null)
			{
				while (true)
				{
					IL_0031:
					int length = Math.Min(sourceArray.Length, targetArray.Length);
					Array.Copy(sourceArray, targetArray, length);
					int num = 1926067408;
					while (true)
					{
						switch (num ^ 0x72CD74D3)
						{
						case 0:
							num = 1926067409;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							goto IL_0031;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		public static void ShallowCopy(float[] sourceArray, float[] targetArray)
		{
			if (sourceArray != null && targetArray != null)
			{
				int length = Math.Min(sourceArray.Length, targetArray.Length);
				Array.Copy(sourceArray, targetArray, length);
			}
		}

		public static void ShallowCopy(bool[] sourceArray, bool[] targetArray)
		{
			if (sourceArray != null && targetArray != null)
			{
				int length = Math.Min(sourceArray.Length, targetArray.Length);
				Array.Copy(sourceArray, targetArray, length);
			}
		}

		public static byte[] CopyRange(byte[] inArray, int startPos, int length)
		{
			if (inArray != null && length >= 1)
			{
				byte[] array = default(byte[]);
				int num2 = default(int);
				while (true)
				{
					int num = 1032595744;
					while (true)
					{
						switch (num ^ 0x3D8C2923)
						{
						case 2:
							break;
						case 3:
							goto IL_002d;
						case 0:
							goto end_IL_0007;
						case 1:
							array[num2] = inArray[startPos + num2];
							num2++;
							num = 1032595751;
							continue;
						default:
							if (num2 >= length)
							{
								return array;
							}
							goto case 1;
						}
						break;
						IL_002d:
						if (startPos < 0)
						{
							num = 1032595747;
							continue;
						}
						array = new byte[length];
						num2 = 0;
						num = 1032595751;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			return null;
		}

		public static int[] CopyRange(int[] inArray, int startPos, int length)
		{
			if (inArray != null && length >= 1)
			{
				int[] array = default(int[]);
				int num2 = default(int);
				while (true)
				{
					int num = -1068414002;
					while (true)
					{
						switch (num ^ -1068414001)
						{
						case 5:
							break;
						case 3:
							array[num2] = inArray[startPos + num2];
							num2++;
							num = -1068414005;
							continue;
						case 4:
							goto IL_0044;
						case 1:
							goto IL_0059;
						case 2:
							goto end_IL_0007;
						default:
							return array;
						}
						break;
						IL_0059:
						if (startPos < 0)
						{
							num = -1068414003;
							continue;
						}
						array = new int[length];
						num2 = 0;
						num = -1068414005;
						continue;
						IL_0044:
						int num3;
						if (num2 < length)
						{
							num = -1068414004;
							num3 = num;
						}
						else
						{
							num = -1068414001;
							num3 = num;
						}
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			return null;
		}

		public static float[] CopyRange(float[] inArray, int startPos, int length)
		{
			float[] array = default(float[]);
			int num;
			if (inArray != null && length >= 1)
			{
				if (startPos < 0)
				{
					goto IL_000b;
				}
				array = new float[length];
				num = -1746314821;
				goto IL_0010;
			}
			goto IL_0031;
			IL_000b:
			num = -1746314823;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1746314824)
				{
				case 4:
					break;
				case 1:
					goto IL_0031;
				case 3:
					num2 = 0;
					num = -1746314824;
					continue;
				case 2:
					array[num2] = inArray[startPos + num2];
					num2++;
					num = -1746314824;
					continue;
				default:
					if (num2 >= length)
					{
						return array;
					}
					goto case 2;
				}
				break;
			}
			goto IL_000b;
			IL_0031:
			return null;
		}

		public static string[] CopyRange(string[] inArray, int startPos, int length)
		{
			string[] array = default(string[]);
			int num;
			if (inArray != null && length >= 1)
			{
				if (startPos < 0)
				{
					goto IL_000b;
				}
				array = new string[length];
				num = 1096371708;
				goto IL_0010;
			}
			goto IL_0031;
			IL_000b:
			num = 1096371711;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x41594DFD)
				{
				case 0:
					break;
				case 2:
					goto IL_0031;
				case 1:
					num2 = 0;
					num = 1096371710;
					continue;
				case 4:
					array[num2] = inArray[startPos + num2];
					num2++;
					num = 1096371710;
					continue;
				default:
					if (num2 >= length)
					{
						return array;
					}
					goto case 4;
				}
				break;
			}
			goto IL_000b;
			IL_0031:
			return null;
		}

		public static byte[] Combine(byte[] inArray1, byte[] inArray2)
		{
			byte[] array = null;
			if (inArray1 != null)
			{
				goto IL_00a7;
			}
			int num = 0;
			goto IL_00d8;
			IL_00a7:
			num = inArray1.Length;
			int num2 = -531644694;
			goto IL_0014;
			IL_00d8:
			int num3 = default(int);
			if (inArray2 == null)
			{
				num3 = 0;
				num2 = -531644699;
				goto IL_0014;
			}
			goto IL_0083;
			IL_0083:
			num3 = inArray2.Length;
			num2 = -531644699;
			goto IL_0014;
			IL_0014:
			int num6 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -531644698)
				{
				case 0:
					num2 = -531644703;
					continue;
				case 3:
					break;
				case 9:
					goto IL_0062;
				case 11:
					return array;
				case 1:
					goto end_IL_0014;
				case 10:
					goto IL_008e;
				case 7:
					goto IL_00a7;
				case 2:
					if (num6 >= num)
					{
						num5 = 0;
						num2 = -531644692;
						continue;
					}
					goto case 4;
				case 6:
					array[num4] = inArray2[num5];
					num2 = -531644701;
					continue;
				case 12:
					goto IL_00d8;
				case 5:
					num4++;
					num5++;
					num2 = -531644692;
					continue;
				case 4:
					array[num4] = inArray1[num6];
					num4++;
					num6++;
					num2 = -531644700;
					continue;
				default:
					return array;
				}
				if (num == 0)
				{
					num2 = -531644689;
					continue;
				}
				goto IL_006e;
				IL_008e:
				int num7;
				if (num5 < num3)
				{
					num2 = -531644704;
					num7 = num2;
				}
				else
				{
					num2 = -531644690;
					num7 = num2;
				}
				continue;
				IL_0062:
				if (num3 == 0)
				{
					num2 = -531644691;
					continue;
				}
				goto IL_006e;
				IL_006e:
				array = new byte[num + num3];
				num4 = 0;
				num6 = 0;
				num2 = -531644700;
				continue;
				end_IL_0014:
				break;
			}
			goto IL_0083;
		}

		public static int[] Combine(int[] inArray1, int[] inArray2)
		{
			int[] array = null;
			int num6 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			int num2 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num = -971354884;
				while (true)
				{
					switch (num ^ -971354883)
					{
					case 5:
						break;
					case 9:
						array[num6] = inArray1[num4];
						num6++;
						num = -971354887;
						continue;
					case 12:
						num3 = inArray2.Length;
						num = -971354891;
						continue;
					case 7:
					{
						int num7;
						if (inArray2 == null)
						{
							num = -971354889;
							num7 = num;
						}
						else
						{
							num = -971354895;
							num7 = num;
						}
						continue;
					}
					case 2:
						array[num6] = inArray2[num2];
						num6++;
						num2++;
						num = -971354883;
						continue;
					case 10:
						num3 = 0;
						num = -971354891;
						continue;
					case 4:
						num4++;
						num = -971354885;
						continue;
					case 6:
						if (num4 >= num5)
						{
							num2 = 0;
							num = -971354890;
							continue;
						}
						goto case 9;
					case 11:
						num = -971354883;
						continue;
					case 1:
						if (inArray1 == null)
						{
							num5 = 0;
							num = -971354886;
							continue;
						}
						goto case 3;
					case 8:
						if (num5 == 0 && num3 == 0)
						{
							return array;
						}
						array = new int[num5 + num3];
						num6 = 0;
						num4 = 0;
						num = -971354885;
						continue;
					case 3:
						num5 = inArray1.Length;
						num = -971354886;
						continue;
					default:
						if (num2 >= num3)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public static float[] Combine(float[] inArray1, float[] inArray2)
		{
			float[] array = null;
			int num3 = default(int);
			int num4 = default(int);
			int num6 = default(int);
			int num5 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = 287422967;
				while (true)
				{
					switch (num ^ 0x1121B9F6)
					{
					case 7:
						break;
					case 8:
						num3 = inArray2.Length;
						num = 287422966;
						continue;
					case 6:
						array[num4] = inArray1[num6];
						num4++;
						num6++;
						num = 287422972;
						continue;
					case 1:
						if (inArray1 == null)
						{
							num5 = 0;
							num = 287422963;
							continue;
						}
						goto case 2;
					case 3:
						num = 287422966;
						continue;
					case 4:
						num = 287422973;
						continue;
					case 10:
						if (num6 >= num5)
						{
							num2 = 0;
							num = 287422962;
							continue;
						}
						goto case 6;
					case 12:
						num = 287422972;
						continue;
					case 0:
						if (num5 == 0 && num3 == 0)
						{
							return array;
						}
						array = new float[num5 + num3];
						num4 = 0;
						num6 = 0;
						num = 287422970;
						continue;
					case 2:
						num5 = inArray1.Length;
						num = 287422963;
						continue;
					case 5:
						if (inArray2 == null)
						{
							num3 = 0;
							num = 287422965;
							continue;
						}
						goto case 8;
					case 9:
						array[num4] = inArray2[num2];
						num4++;
						num2++;
						num = 287422973;
						continue;
					default:
						if (num2 >= num3)
						{
							return array;
						}
						goto case 9;
					}
					break;
				}
			}
		}

		public static string[] Combine(string[] inArray1, string[] inArray2)
		{
			string[] array = null;
			if (inArray1 == null)
			{
				goto IL_0008;
			}
			goto IL_00c7;
			IL_0008:
			int num = 1387389145;
			goto IL_000d;
			IL_000d:
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			int num5 = default(int);
			int num6 = default(int);
			while (true)
			{
				switch (num ^ 0x52B1E0D8)
				{
				case 5:
					break;
				case 3:
					array[num4] = inArray2[num2];
					num4++;
					num = 1387389150;
					continue;
				case 11:
					if (inArray2 == null)
					{
						num3 = 0;
						num = 1387389144;
						continue;
					}
					goto case 2;
				case 4:
					goto IL_0073;
				case 2:
					num3 = inArray2.Length;
					num = 1387389144;
					continue;
				case 13:
					array[num4] = inArray1[num5];
					num4++;
					num5++;
					num = 1387389140;
					continue;
				case 10:
					num = 1387389140;
					continue;
				case 1:
					num6 = 0;
					num = 1387389139;
					continue;
				case 9:
					goto IL_00c7;
				case 0:
					goto IL_00d5;
				case 7:
					num4 = 0;
					num5 = 0;
					num = 1387389138;
					continue;
				case 12:
					if (num5 >= num6)
					{
						num2 = 0;
						num = 1387389136;
						continue;
					}
					goto case 13;
				case 6:
					num2++;
					num = 1387389136;
					continue;
				default:
					if (num2 >= num3)
					{
						return array;
					}
					goto case 3;
				}
				break;
				IL_00d5:
				if (num6 == 0)
				{
					num = 1387389148;
					continue;
				}
				goto IL_0078;
				IL_0078:
				array = new string[num6 + num3];
				num = 1387389151;
				continue;
				IL_0073:
				if (num3 == 0)
				{
					return array;
				}
				goto IL_0078;
			}
			goto IL_0008;
			IL_00c7:
			num6 = inArray1.Length;
			num = 1387389139;
			goto IL_000d;
		}

		public static T[] ParseArray<T>(string line)
		{
			line = line.Replace("{", "");
			line = line.Replace("}", "");
			string[] array = line.Split(',');
			int num2 = default(int);
			int num3 = default(int);
			T[] array2 = default(T[]);
			while (true)
			{
				int num = -953864353;
				while (true)
				{
					switch (num ^ -953864359)
					{
					case 3:
						break;
					case 1:
						num2++;
						num = -953864357;
						continue;
					case 5:
						if (num3 == 1)
						{
							string text = array[0].Trim().ToLower();
							if (text == "")
							{
								goto case 0;
							}
							if (text == "null")
							{
								num = -953864359;
								continue;
							}
						}
						num2 = 0;
						num = -953864354;
						continue;
					case 7:
						num = -953864357;
						continue;
					case 6:
						num3 = array.Length;
						array2 = new T[num3];
						num = -953864356;
						continue;
					case 4:
					{
						string value = array[num2].Trim();
						array2[num2] = (T)Convert.ChangeType(value, typeof(T));
						num = -953864360;
						continue;
					}
					case 0:
						return null;
					default:
						if (num2 >= num3)
						{
							return array2;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public static T[] SortAscending<T>(T[] array, out int[] sortedIndices) where T : IComparable<T>
		{
			if (array == null)
			{
				sortedIndices = null;
				return null;
			}
			int num = array.Length;
			if (num == 0)
			{
				sortedIndices = new int[0];
				return array;
			}
			if (num == 1)
			{
				goto IL_001d;
			}
			T[] array2 = new T[num];
			int num2 = -163070395;
			goto IL_0022;
			IL_001d:
			num2 = -163070400;
			goto IL_0022;
			IL_0022:
			int num3 = default(int);
			int num5 = default(int);
			bool[] array3 = default(bool[]);
			int num4 = default(int);
			T val = default(T);
			T val2 = default(T);
			while (true)
			{
				switch (num2 ^ -163070395)
				{
				case 2:
					break;
				case 5:
				{
					int[] array4 = new int[1];
					sortedIndices = array4;
					return array;
				}
				case 4:
					sortedIndices[num3] = num5;
					array3[num5] = true;
					num3++;
					num2 = -163070388;
					continue;
				case 8:
					num4++;
					num2 = -163070398;
					continue;
				case 0:
					sortedIndices = new int[num];
					array3 = new bool[num];
					num3 = 0;
					num2 = -163070394;
					continue;
				case 1:
					if (!array3[num4])
					{
						val = array[num4];
						num2 = -163070385;
						continue;
					}
					goto case 8;
				case 6:
					val2 = val;
					num5 = num4;
					num2 = -163070387;
					continue;
				case 10:
					if (num5 != -1)
					{
						int num6;
						if (val.CompareTo(val2) < 0)
						{
							num2 = -163070397;
							num6 = num2;
						}
						else
						{
							num2 = -163070387;
							num6 = num2;
						}
						continue;
					}
					goto case 6;
				case 3:
					num2 = -163070388;
					continue;
				case 11:
					val2 = default(T);
					num5 = -1;
					num4 = 0;
					num2 = -163070398;
					continue;
				case 7:
					if (num4 >= num)
					{
						array2[num3] = val2;
						num2 = -163070399;
						continue;
					}
					goto case 1;
				default:
					if (num3 >= num)
					{
						return array2;
					}
					goto case 11;
				}
				break;
			}
			goto IL_001d;
		}

		public static T[] SortDescending<T>(T[] array, out int[] sortedIndices, bool ascending = true) where T : IComparable<T>
		{
			if (array == null)
			{
				goto IL_0006;
			}
			int num = array.Length;
			if (num == 0)
			{
				sortedIndices = new int[0];
				return array;
			}
			T[] array2 = default(T[]);
			bool[] array3 = default(bool[]);
			int num2 = default(int);
			int num3;
			if (num != 1)
			{
				array2 = new T[num];
				sortedIndices = new int[num];
				array3 = new bool[num];
				num2 = 0;
				num3 = 2014658533;
			}
			else
			{
				num3 = 2014658529;
			}
			goto IL_000b;
			IL_000b:
			int num4 = default(int);
			T val2 = default(T);
			int num6 = default(int);
			T val = default(T);
			while (true)
			{
				switch (num3 ^ 0x78153FE5)
				{
				case 11:
					break;
				case 5:
					if (num4 >= num)
					{
						array2[num2] = val2;
						sortedIndices[num2] = num6;
						array3[num6] = true;
						num2++;
						num3 = 2014658536;
						continue;
					}
					goto case 7;
				case 3:
					if (num6 != -1)
					{
						int num7;
						if (val.CompareTo(val2) >= 0)
						{
							num3 = 2014658537;
							num7 = num3;
						}
						else
						{
							num3 = 2014658541;
							num7 = num3;
						}
						continue;
					}
					goto case 8;
				case 2:
					val2 = default(T);
					num6 = -1;
					num3 = 2014658531;
					continue;
				case 0:
					num3 = 2014658536;
					continue;
				case 7:
				{
					int num5;
					if (array3[num4])
					{
						num3 = 2014658537;
						num5 = num3;
					}
					else
					{
						num3 = 2014658532;
						num5 = num3;
					}
					continue;
				}
				case 9:
					return array;
				case 8:
					val2 = val;
					num6 = num4;
					num3 = 2014658537;
					continue;
				case 1:
					val = array[num4];
					num3 = 2014658534;
					continue;
				case 6:
					num4 = 0;
					num3 = 2014658528;
					continue;
				case 12:
					num4++;
					num3 = 2014658528;
					continue;
				case 4:
				{
					int[] array4 = new int[1];
					sortedIndices = array4;
					num3 = 2014658540;
					continue;
				}
				case 10:
					sortedIndices = null;
					return null;
				default:
					if (num2 >= num)
					{
						return array2;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0006;
			IL_0006:
			num3 = 2014658543;
			goto IL_000b;
		}

		public static int Add<T>(ref T[] array, T item)
		{
			if (array == null)
			{
				goto IL_0004;
			}
			goto IL_004a;
			IL_0004:
			int num = -2102073874;
			goto IL_0009;
			IL_0009:
			int num3 = default(int);
			T[] array2 = default(T[]);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -2102073875)
				{
				case 4:
					break;
				case 6:
				{
					int num4 = num3 + 1;
					array2 = new T[num4];
					num2 = 0;
					num = -2102073875;
					continue;
				}
				case 7:
					goto IL_004a;
				case 1:
					array = array2;
					num = -2102073880;
					continue;
				case 3:
					num3 = 0;
					num = -2102073877;
					continue;
				case 2:
					array2[num2] = array[num2];
					num2++;
					num = -2102073875;
					continue;
				case 0:
					if (num2 >= num3)
					{
						array2[num2] = item;
						num = -2102073876;
						continue;
					}
					goto case 2;
				default:
					return num2;
				}
				break;
			}
			goto IL_0004;
			IL_004a:
			num3 = array.Length;
			num = -2102073877;
			goto IL_0009;
		}

		public static int AddIfUnique<T>(ref T[] array, T item)
		{
			if (array != null)
			{
				while (true)
				{
					int num = 1073343878;
					while (true)
					{
						switch (num ^ 0x3FF9ED87)
						{
						case 0:
							break;
						case 1:
							goto IL_0022;
						default:
							goto end_IL_0004;
						}
						break;
						IL_0022:
						if (array.Length == 0)
						{
							goto end_IL_0004;
						}
						if (!Contains(array, item))
						{
							num = 1073343877;
							continue;
						}
						return -1;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return Add(ref array, item);
		}

		public static int Insert<T>(ref T[] array, int index, T item)
		{
			if (index < 0)
			{
				index = 0;
				goto IL_000a;
			}
			goto IL_00fc;
			IL_00fc:
			int num = default(int);
			int num2;
			if (array == null)
			{
				num = 0;
				num2 = 1167755288;
				goto IL_000f;
			}
			goto IL_00c6;
			IL_000a:
			num2 = 1167755289;
			goto IL_000f;
			IL_000f:
			T[] array2 = default(T[]);
			int num3 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			int num6 = default(int);
			while (true)
			{
				switch (num2 ^ 0x459A881D)
				{
				case 9:
					break;
				case 0:
					array2[num3] = array[num3];
					num3++;
					num2 = 1167755294;
					continue;
				case 13:
					goto IL_0075;
				case 12:
					num2 = 1167755285;
					continue;
				case 6:
					array2[num3] = item;
					num2 = 1167755295;
					continue;
				case 11:
					num3++;
					num2 = 1167755281;
					continue;
				case 7:
					goto IL_00c6;
				case 3:
					goto IL_00d5;
				case 5:
					num5 = num - 1;
					num2 = 1167755280;
					continue;
				case 4:
					goto IL_00fc;
				case 8:
					goto IL_010c;
				case 2:
					num4 = index;
					num2 = 1167755286;
					continue;
				case 10:
					array2[num3] = array[num4];
					num4++;
					num3++;
					num2 = 1167755285;
					continue;
				default:
					array = array2;
					return index;
				}
				break;
				IL_010c:
				int num7;
				if (num3 < num6)
				{
					num2 = 1167755287;
					num7 = num2;
				}
				else
				{
					num2 = 1167755292;
					num7 = num2;
				}
				continue;
				IL_00d5:
				int num8;
				if (num3 >= index)
				{
					num2 = 1167755291;
					num8 = num2;
				}
				else
				{
					num2 = 1167755293;
					num8 = num2;
				}
				continue;
				IL_0075:
				if (index > num5)
				{
					return Add(ref array, item);
				}
				num6 = num + 1;
				array2 = new T[num6];
				num3 = 0;
				num2 = 1167755294;
			}
			goto IL_000a;
			IL_00c6:
			num = array.Length;
			num2 = 1167755288;
			goto IL_000f;
		}

		public static bool RemoveAt<T>(ref T[] array, int index)
		{
			if (array == null)
			{
				return false;
			}
			if (index < 0)
			{
				index = 0;
				goto IL_000d;
			}
			goto IL_004e;
			IL_004e:
			int num = array.Length;
			int num2 = -1139460070;
			goto IL_0012;
			IL_0012:
			T[] array2 = default(T[]);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -1139460072)
				{
				case 3:
					break;
				case 6:
					goto IL_004e;
				case 2:
				{
					int num5 = num - 1;
					if (index > num5)
					{
						index = num5;
						num2 = -1139460079;
						continue;
					}
					goto case 9;
				}
				case 7:
					array2[num3 - 1] = array[num3];
					num3++;
					num2 = -1139460067;
					continue;
				case 0:
					array2 = new T[num4];
					num2 = -1139460078;
					continue;
				case 10:
					num3 = 0;
					num2 = -1139460071;
					continue;
				case 5:
					goto IL_00ad;
				case 8:
					array2[num3] = array[num3];
					num3++;
					num2 = -1139460071;
					continue;
				case 9:
					num4 = num - 1;
					num2 = -1139460072;
					continue;
				case 1:
					if (num3 >= index)
					{
						num3 = index + 1;
						num2 = -1139460067;
						continue;
					}
					goto case 8;
				default:
					array = array2;
					return true;
				}
				break;
				IL_00ad:
				int num6;
				if (num3 >= num)
				{
					num2 = -1139460068;
					num6 = num2;
				}
				else
				{
					num2 = -1139460065;
					num6 = num2;
				}
			}
			goto IL_000d;
			IL_000d:
			num2 = -1139460066;
			goto IL_0012;
		}

		public static bool Remove<T>(ref T[] array, T item)
		{
			if (array == null)
			{
				goto IL_0004;
			}
			int num = array.Length;
			int num2 = 0;
			int num3 = -861101696;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num3 ^ -861101693)
				{
				case 0:
					break;
				case 4:
					return false;
				case 3:
					num3 = -861101695;
					continue;
				case 1:
					if (EqualityComparer<T>.Default.Equals(array[num2], item))
					{
						RemoveAt(ref array, num2);
						return true;
					}
					num2++;
					num3 = -861101695;
					continue;
				default:
					if (num2 >= num)
					{
						return false;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0004;
			IL_0004:
			num3 = -861101689;
			goto IL_0009;
		}

		public static void Combine<T>(ref T[] array1, T[] array2)
		{
			if (array1 == null)
			{
				if (array2 == null)
				{
					return;
				}
			}
			else
			{
				T[] array3 = default(T[]);
				int num7 = default(int);
				int num8 = default(int);
				int num4 = default(int);
				int num9 = default(int);
				int num5 = default(int);
				int num6 = default(int);
				while (true)
				{
					IL_0110:
					int num;
					if (array1.Length == 0)
					{
						if (array2 == null)
						{
							return;
						}
						int num2;
						if (array2.Length != 0)
						{
							num = -147441913;
							num2 = num;
						}
						else
						{
							num = -147441912;
							num2 = num;
						}
						goto IL_0013;
					}
					goto IL_00c7;
					IL_00c7:
					if (array2 != null)
					{
						int num3;
						if (array2.Length == 0)
						{
							num = -147441918;
							num3 = num;
						}
						else
						{
							num = -147441906;
							num3 = num;
						}
						goto IL_0013;
					}
					return;
					IL_0013:
					while (true)
					{
						switch (num ^ -147441915)
						{
						case 0:
							num = -147441920;
							continue;
						case 8:
							array3[num7++] = array1[num8];
							num8++;
							num = -147441905;
							continue;
						case 4:
							num4 = 0;
							num = -147441914;
							continue;
						case 6:
							num4++;
							num = -147441914;
							continue;
						case 5:
							break;
						case 11:
							num9 = array1.Length;
							num5 = array2.Length;
							num6 = num9 + num5;
							num = -147441911;
							continue;
						case 2:
							goto IL_00c7;
						case 1:
							array3[num7++] = array2[num4];
							num = -147441917;
							continue;
						case 13:
							return;
						case 9:
							goto IL_0110;
						case 12:
							array3 = new T[num6];
							num7 = 0;
							num8 = 0;
							num = -147441905;
							continue;
						case 10:
							goto IL_0149;
						case 7:
							return;
						default:
							if (num4 >= num5)
							{
								array1 = array3;
								return;
							}
							goto case 1;
						}
						break;
						IL_0149:
						int num10;
						if (num8 >= num9)
						{
							num = -147441919;
							num10 = num;
						}
						else
						{
							num = -147441907;
							num10 = num;
						}
					}
					break;
				}
			}
			array1 = (T[])array2.Clone();
		}

		public static T[] Add<T>(T[] array, T item)
		{
			int num;
			if (array == null)
			{
				num = 0;
				goto IL_0005;
			}
			goto IL_004c;
			IL_004c:
			num = array.Length;
			int num2 = -2064559062;
			goto IL_000a;
			IL_0005:
			num2 = -2064559064;
			goto IL_000a;
			IL_000a:
			T[] array2 = default(T[]);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -2064559063)
				{
				case 2:
					break;
				case 6:
					array2[num3] = array[num3];
					num2 = -2064559058;
					continue;
				case 0:
					goto IL_004c;
				case 3:
				{
					int num4 = num + 1;
					array2 = new T[num4];
					num3 = 0;
					num2 = -2064559060;
					continue;
				}
				case 1:
					num2 = -2064559062;
					continue;
				case 5:
					num2 = -2064559059;
					continue;
				case 7:
					num3++;
					num2 = -2064559059;
					continue;
				default:
					if (num3 >= num)
					{
						array2[num3] = item;
						return array2;
					}
					goto case 6;
				}
				break;
			}
			goto IL_0005;
		}

		public static T[] AddIfUnique<T>(T[] array, T item)
		{
			if (array != null && array.Length != 0)
			{
				while (true)
				{
					int num = -425543386;
					while (true)
					{
						switch (num ^ -425543388)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0026:
						if (!Contains(array, item))
						{
							num = -425543387;
							continue;
						}
						return array;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return Add(array, item);
		}

		public static T[] Insert<T>(T[] array, int index, T item)
		{
			if (index < 0)
			{
				index = 0;
				goto IL_0007;
			}
			goto IL_005c;
			IL_0160:
			int num = array.Length;
			int num2 = 1607626443;
			goto IL_000c;
			IL_0007:
			num2 = 1607626444;
			goto IL_000c;
			IL_000c:
			int num5 = default(int);
			int num4 = default(int);
			T[] array2 = default(T[]);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x5FD26EC2)
				{
				case 10:
					break;
				case 14:
					goto IL_005c;
				case 9:
					goto IL_006b;
				case 6:
					num5++;
					num4++;
					num2 = 1607626441;
					continue;
				case 7:
					array2[num4] = item;
					num2 = 1607626442;
					continue;
				case 15:
					return Add(array, item);
				case 5:
					array2[num4] = array[num4];
					num4++;
					num2 = 1607626447;
					continue;
				case 11:
					goto IL_00d9;
				case 8:
					num5 = index;
					num2 = 1607626432;
					continue;
				case 12:
					array2[num4] = array[num5];
					num2 = 1607626436;
					continue;
				case 2:
					num4++;
					num2 = 1607626433;
					continue;
				case 1:
					array2 = new T[num3];
					num4 = 0;
					num2 = 1607626447;
					continue;
				case 13:
					goto IL_013d;
				case 3:
					num2 = 1607626441;
					continue;
				case 4:
					goto IL_0160;
				default:
					return array2;
				}
				break;
				IL_013d:
				int num6;
				if (num4 < index)
				{
					num2 = 1607626439;
					num6 = num2;
				}
				else
				{
					num2 = 1607626437;
					num6 = num2;
				}
				continue;
				IL_00d9:
				int num7;
				if (num4 < num3)
				{
					num2 = 1607626446;
					num7 = num2;
				}
				else
				{
					num2 = 1607626434;
					num7 = num2;
				}
				continue;
				IL_006b:
				int num8 = num - 1;
				if (index > num8)
				{
					num2 = 1607626445;
					continue;
				}
				num3 = num + 1;
				num2 = 1607626435;
			}
			goto IL_0007;
			IL_005c:
			if (array == null)
			{
				num = 0;
				num2 = 1607626443;
				goto IL_000c;
			}
			goto IL_0160;
		}

		public static T[] RemoveAt<T>(T[] array, int index)
		{
			if (array == null)
			{
				return null;
			}
			if (index < 0)
			{
				goto IL_000c;
			}
			goto IL_0097;
			IL_0097:
			int num = array.Length;
			int num2 = 1282961364;
			goto IL_0011;
			IL_000c:
			num2 = 1282961366;
			goto IL_0011;
			IL_0011:
			int num3 = default(int);
			T[] array2 = default(T[]);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ 0x4C786FD4)
				{
				case 4:
					break;
				case 2:
					index = 0;
					num2 = 1282961362;
					continue;
				case 5:
					num3++;
					num2 = 1282961375;
					continue;
				case 7:
					array2[num3] = array[num3];
					num2 = 1282961361;
					continue;
				case 3:
					goto IL_007f;
				case 6:
					goto IL_0097;
				case 9:
					index = num4;
					num2 = 1282961372;
					continue;
				case 8:
				{
					int num5 = num - 1;
					array2 = new T[num5];
					num3 = 0;
					num2 = 1282961375;
					continue;
				}
				case 1:
					array2[num3 - 1] = array[num3];
					num3++;
					num2 = 1282961374;
					continue;
				case 11:
					if (num3 >= index)
					{
						num3 = index + 1;
						num2 = 1282961374;
						continue;
					}
					goto case 7;
				case 0:
					num4 = num - 1;
					num2 = 1282961367;
					continue;
				default:
					if (num3 >= num)
					{
						return array2;
					}
					goto case 1;
				}
				break;
				IL_007f:
				int num6;
				if (index <= num4)
				{
					num2 = 1282961372;
					num6 = num2;
				}
				else
				{
					num2 = 1282961373;
					num6 = num2;
				}
			}
			goto IL_000c;
		}

		public static T[] Remove<T>(T[] array, T item)
		{
			if (array == null)
			{
				return array;
			}
			int num = array.Length;
			int num3 = default(int);
			while (true)
			{
				int num2 = 2030224468;
				while (true)
				{
					switch (num2 ^ 0x7902C450)
					{
					case 3:
						break;
					case 4:
						num3 = 0;
						num2 = 2030224465;
						continue;
					case 2:
						return RemoveAt(array, num3);
					case 0:
						if (!EqualityComparer<T>.Default.Equals(array[num3], item))
						{
							num3++;
							num2 = 2030224465;
						}
						else
						{
							num2 = 2030224466;
						}
						continue;
					default:
						if (num3 >= num)
						{
							return array;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static T[] Combine<T>(T[] array1, T[] array2)
		{
			if (array1 == null && array2 == null)
			{
				return null;
			}
			int num = ((array1 != null) ? array1.Length : 0);
			int num2 = ((array2 != null) ? array2.Length : 0);
			int num3 = num + num2;
			T[] array3 = new T[num3];
			int num4 = 0;
			int num5 = 0;
			int num6 = default(int);
			while (true)
			{
				IL_00d5:
				int num7;
				if (num5 >= num)
				{
					num6 = 0;
					num7 = -381923072;
					goto IL_0037;
				}
				goto IL_0067;
				IL_0037:
				while (true)
				{
					switch (num7 ^ -381923070)
					{
					case 5:
						num7 = -381923068;
						continue;
					case 6:
						break;
					case 7:
						num5++;
						num7 = -381923071;
						continue;
					case 1:
						goto IL_0090;
					case 0:
						array3[num4++] = array2[num6];
						num6++;
						num7 = -381923069;
						continue;
					case 2:
						num7 = -381923069;
						continue;
					case 3:
						goto IL_00d5;
					default:
						return array3;
					}
					break;
					IL_0090:
					int num8;
					if (num6 < num2)
					{
						num7 = -381923070;
						num8 = num7;
					}
					else
					{
						num7 = -381923066;
						num8 = num7;
					}
				}
				goto IL_0067;
				IL_0067:
				array3[num4++] = array1[num5];
				num7 = -381923067;
				goto IL_0037;
			}
		}

		public static int IndexOf<T>(T[] array, T item)
		{
			if (array == null)
			{
				return -1;
			}
			int num = array.Length;
			int num2 = 0;
			while (true)
			{
				int num3 = -754363116;
				while (true)
				{
					switch (num3 ^ -754363113)
					{
					case 0:
						break;
					case 2:
						return num2;
					case 4:
						if (!EqualityComparer<T>.Default.Equals(array[num2], item))
						{
							num2++;
							num3 = -754363114;
						}
						else
						{
							num3 = -754363115;
						}
						continue;
					case 3:
						num3 = -754363114;
						continue;
					default:
						if (num2 >= num)
						{
							return -1;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public static bool Contains<T>(T[] array, T item)
		{
			if (array == null)
			{
				return false;
			}
			int num = array.Length;
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					int num3;
					if (EqualityComparer<T>.Default.Equals(array[num2], item))
					{
						num3 = -590308822;
					}
					else
					{
						num2++;
						num3 = -590308823;
					}
					while (true)
					{
						switch (num3 ^ -590308823)
						{
						case 2:
							num3 = -590308824;
							continue;
						case 1:
							break;
						case 3:
							return true;
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
			return false;
		}

		public static T Find<T>(T[] array, Predicate<T> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			while (array != null)
			{
				int num = array.Length;
				int num2 = 0;
				int num3 = -824364698;
				while (true)
				{
					switch (num3 ^ -824364697)
					{
					case 4:
						num3 = -824364700;
						continue;
					case 3:
						break;
					case 1:
						num3 = -824364697;
						continue;
					case 5:
						return array[num2];
					case 2:
						if (!predicate(array[num2]))
						{
							num2++;
							num3 = -824364697;
						}
						else
						{
							num3 = -824364702;
						}
						continue;
					default:
						if (num2 >= num)
						{
							return default(T);
						}
						goto case 2;
					}
					break;
				}
			}
			return default(T);
		}

		public static bool SubArray<T>(ref T[] array, int startIndex)
		{
			if (array == null)
			{
				return false;
			}
			if (array.Length == 0)
			{
				return false;
			}
			if (startIndex < 0)
			{
				startIndex = 0;
				goto IL_0015;
			}
			goto IL_003f;
			IL_001a:
			int num;
			T[] array2 = default(T[]);
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			int num5 = default(int);
			while (true)
			{
				switch (num ^ -263274556)
				{
				case 5:
					break;
				case 2:
					goto IL_003f;
				case 3:
					array2[num4++] = array[num2];
					num2++;
					num = -263274560;
					continue;
				case 1:
					goto IL_0072;
				case 0:
					num2 = startIndex;
					num = -263274560;
					continue;
				default:
					if (num2 >= num3)
					{
						array = array2;
						return true;
					}
					goto case 3;
				}
				break;
				IL_0072:
				if (startIndex >= num5)
				{
					return false;
				}
				int num6 = num3 - startIndex;
				array2 = new T[num6];
				num4 = 0;
				num = -263274556;
			}
			goto IL_0015;
			IL_0015:
			num = -263274554;
			goto IL_001a;
			IL_003f:
			num3 = array.Length;
			num5 = num3 - 1;
			num = -263274555;
			goto IL_001a;
		}

		public static bool SubArray<T>(ref T[] array, int startIndex, int count)
		{
			if (array == null)
			{
				return false;
			}
			if (array.Length == 0)
			{
				return false;
			}
			if (count <= 0)
			{
				return false;
			}
			if (startIndex < 0)
			{
				startIndex = 0;
				goto IL_001e;
			}
			goto IL_00a1;
			IL_0023:
			int num;
			int num4 = default(int);
			int num2 = default(int);
			T[] array2 = default(T[]);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -653274705)
				{
				case 0:
					break;
				case 6:
					if (num4 > num2)
					{
						array = array2;
						num = -653274706;
						continue;
					}
					goto case 4;
				case 4:
					array2[num3++] = array[num4];
					num4++;
					num = -653274711;
					continue;
				case 2:
					num2 = startIndex + count - 1;
					num3 = 0;
					num4 = startIndex;
					num = -653274711;
					continue;
				case 5:
					goto IL_0091;
				case 3:
					goto IL_00a1;
				default:
					return true;
				}
				break;
			}
			goto IL_001e;
			IL_00a1:
			int num5 = array.Length;
			if (startIndex >= num5 - 1)
			{
				return false;
			}
			if (count > num5 - startIndex)
			{
				count = num5 - startIndex;
				num = -653274710;
				goto IL_0023;
			}
			goto IL_0091;
			IL_001e:
			num = -653274708;
			goto IL_0023;
			IL_0091:
			int num6 = count;
			array2 = new T[num6];
			num = -653274707;
			goto IL_0023;
		}

		public static void Expand<T>(ref T[] array, int length)
		{
			if (length <= 0)
			{
				return;
			}
			T[] array2 = default(T[]);
			while (true)
			{
				int num;
				int num2;
				if (array == null)
				{
					num = 0;
					num2 = 1374391682;
					goto IL_000a;
				}
				goto IL_003c;
				IL_000a:
				while (true)
				{
					switch (num2 ^ 0x51EB8D83)
					{
					case 5:
						num2 = 1374391680;
						continue;
					default:
						return;
					case 3:
						break;
					case 4:
						goto IL_003c;
					case 1:
					{
						int num3 = num + length;
						array2 = new T[num3];
						if (num > 0)
						{
							Array.Copy(array, array2, num);
							num2 = 1374391681;
							continue;
						}
						goto case 2;
					}
					case 2:
						array = array2;
						num2 = 1374391683;
						continue;
					case 0:
						return;
					}
					break;
				}
				continue;
				IL_003c:
				num = array.Length;
				num2 = 1374391682;
				goto IL_000a;
			}
		}

		public static void Trim(string[] array)
		{
			if (array == null)
			{
				return;
			}
			while (true)
			{
				int num = array.Length;
				if (num == 0)
				{
					break;
				}
				while (true)
				{
					int num2 = 0;
					int num3 = -360372450;
					while (true)
					{
						switch (num3 ^ -360372452)
						{
						case 0:
							num3 = -360372449;
							continue;
						case 1:
							array[num2].Trim();
							num2++;
							num3 = -360372450;
							continue;
						case 4:
							break;
						case 3:
							goto end_IL_003e;
						default:
							if (num2 >= num)
							{
								return;
							}
							goto case 1;
						}
						break;
					}
					continue;
					end_IL_003e:
					break;
				}
			}
		}

		public static RaycastHit[] SortNearToFar(RaycastHit[] hits)
		{
			int num = hits.Length;
			float[] array = default(float[]);
			int[] array2 = default(int[]);
			int num2 = default(int);
			int num3;
			if (hits != null)
			{
				if (num == 0)
				{
					goto IL_0010;
				}
				array = new float[num];
				array2 = new int[num];
				num2 = 0;
				num3 = -704472887;
				goto IL_0015;
			}
			goto IL_00af;
			IL_0015:
			bool flag = default(bool);
			int num7 = default(int);
			float num5 = default(float);
			int num6 = default(int);
			int num8 = default(int);
			float num9 = default(float);
			RaycastHit[] array3 = default(RaycastHit[]);
			int num4 = default(int);
			while (true)
			{
				switch (num3 ^ -704472895)
				{
				case 13:
					break;
				case 3:
					if (flag)
					{
						flag = false;
						num3 = -704472889;
						continue;
					}
					goto case 6;
				case 14:
					num7++;
					num3 = -704472892;
					continue;
				case 10:
					flag = true;
					num5 = -1f;
					num6 = -1;
					num7 = 0;
					num3 = -704472892;
					continue;
				case 7:
					num6 = num7;
					num3 = -704472881;
					continue;
				case 2:
					goto IL_00af;
				case 1:
					num3 = -704472888;
					continue;
				case 4:
					array[num2] = hits[num2].distance;
					num2++;
					num3 = -704472879;
					continue;
				case 5:
					if (num7 >= num)
					{
						array2[num8] = num6;
						array[num6] = -1f;
						num8++;
						num3 = -704472883;
						continue;
					}
					goto case 11;
				case 16:
					if (num2 >= num)
					{
						num8 = 0;
						num3 = -704472883;
						continue;
					}
					goto case 4;
				case 6:
					num5 = num9;
					num3 = -704472890;
					continue;
				case 8:
					num3 = -704472879;
					continue;
				case 12:
					if (num8 >= num)
					{
						array3 = new RaycastHit[num];
						num4 = 0;
						num3 = -704472896;
						continue;
					}
					goto case 10;
				case 0:
					goto IL_015c;
				case 11:
					num9 = array[num7];
					if (num9 < 0f)
					{
						goto case 14;
					}
					goto IL_0188;
				case 15:
					array3[num4] = hits[array2[num4]];
					num4++;
					num3 = -704472888;
					continue;
				default:
					if (num4 >= num)
					{
						return array3;
					}
					goto case 15;
				}
				break;
				IL_015c:
				int num10;
				if (num9 >= num5)
				{
					num3 = -704472881;
					num10 = num3;
				}
				else
				{
					num3 = -704472894;
					num10 = num3;
				}
				continue;
				IL_0188:
				int num11;
				if (flag)
				{
					num3 = -704472894;
					num11 = num3;
				}
				else
				{
					num3 = -704472895;
					num11 = num3;
				}
			}
			goto IL_0010;
			IL_00af:
			return null;
			IL_0010:
			num3 = -704472893;
			goto IL_0015;
		}

		public static void MoveEntryUp<T>(T[] array, int index)
		{
			if (array == null)
			{
				return;
			}
			while (true)
			{
				int num = array.Length;
				if (num <= 1)
				{
					break;
				}
				while (true)
				{
					if (index <= 0)
					{
						return;
					}
					int num2;
					int num3;
					if (index < num)
					{
						num2 = -1458901941;
						num3 = num2;
					}
					else
					{
						num2 = -1458901939;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1458901943)
						{
						case 0:
							num2 = -1458901942;
							continue;
						case 4:
							return;
						case 1:
							break;
						case 3:
							goto end_IL_0032;
						default:
						{
							int num4 = index - 1;
							T val = array[num4];
							array[num4] = array[index];
							array[index] = val;
							return;
						}
						}
						break;
					}
					continue;
					end_IL_0032:
					break;
				}
			}
		}

		public static void MoveEntryDown<T>(T[] array, int index)
		{
			if (array == null)
			{
				return;
			}
			while (true)
			{
				int num = array.Length;
				int num2 = 530911251;
				while (true)
				{
					switch (num2 ^ 0x1FA51011)
					{
					case 4:
						num2 = 530911248;
						continue;
					case 0:
						if (index >= 0)
						{
							int num5;
							if (index < num - 1)
							{
								num2 = 530911255;
								num5 = num2;
							}
							else
							{
								num2 = 530911250;
								num5 = num2;
							}
							continue;
						}
						return;
					case 5:
						return;
					case 2:
					{
						int num4;
						if (num <= 1)
						{
							num2 = 530911252;
							num4 = num2;
						}
						else
						{
							num2 = 530911249;
							num4 = num2;
						}
						continue;
					}
					case 3:
						return;
					case 1:
						break;
					default:
					{
						int num3 = index + 1;
						T val = array[num3];
						array[num3] = array[index];
						array[index] = val;
						return;
					}
					}
					break;
				}
			}
		}

		public static void Compact<T>(ref T[] array) where T : class
		{
			int num = ((array != null) ? array.Length : 0);
			int num3 = default(int);
			T[] array2 = default(T[]);
			while (true)
			{
				int num2 = -1648219688;
				while (true)
				{
					switch (num2 ^ -1648219684)
					{
					case 3:
						break;
					case 4:
						if (num == 0)
						{
							return;
						}
						goto case 0;
					case 7:
						num3 = 0;
						num2 = -1648219686;
						continue;
					case 0:
						array2 = null;
						num2 = -1648219685;
						continue;
					case 6:
						num2 = -1648219682;
						continue;
					case 1:
						if (array[num3] != null)
						{
							Add(ref array2, array[num3]);
							num2 = -1648219687;
							continue;
						}
						goto case 5;
					case 5:
						num3++;
						num2 = -1648219682;
						continue;
					default:
						if (num3 >= num)
						{
							array = array2;
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public static int IndexOf(int[] array, int value)
		{
			if (array == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = 1130049785;
				while (true)
				{
					switch (num2 ^ 0x435B30F8)
					{
					case 3:
						break;
					case 1:
						num2 = 1130049788;
						continue;
					case 2:
						return num;
					case 0:
						if (array[num] != value)
						{
							num++;
							num2 = 1130049788;
						}
						else
						{
							num2 = 1130049786;
						}
						continue;
					default:
						if (num >= array.Length)
						{
							return -1;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static int IndexOf(float[] array, float value)
		{
			if (array == null)
			{
				return -1;
			}
			int num = 0;
			while (num < array.Length)
			{
				while (true)
				{
					if (array[num] == value)
					{
						return num;
					}
					num++;
					int num2 = -1989355429;
					while (true)
					{
						switch (num2 ^ -1989355430)
						{
						case 0:
							num2 = -1989355432;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0027;
						}
						break;
					}
					continue;
					end_IL_0027:
					break;
				}
			}
			return -1;
		}

		public static int IndexOf(short[] array, short value)
		{
			if (array == null)
			{
				return -1;
			}
			int num = 0;
			while (num < array.Length)
			{
				while (true)
				{
					int num2;
					if (array[num] == value)
					{
						num2 = -872664242;
					}
					else
					{
						num++;
						num2 = -872664243;
					}
					while (true)
					{
						switch (num2 ^ -872664243)
						{
						case 2:
							num2 = -872664244;
							continue;
						case 1:
							break;
						case 3:
							return num;
						default:
							goto end_IL_002b;
						}
						break;
					}
					continue;
					end_IL_002b:
					break;
				}
			}
			return -1;
		}

		public static int IndexOf(ushort[] array, ushort value)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			int num = 0;
			int num2 = -1685775887;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ -1685775886)
				{
				case 2:
					break;
				case 1:
					return -1;
				case 0:
					if (array[num] != value)
					{
						goto IL_0038;
					}
					return num;
				default:
					if (num >= array.Length)
					{
						return -1;
					}
					goto case 0;
				}
				break;
				IL_0038:
				num++;
				num2 = -1685775887;
			}
			goto IL_0003;
			IL_0003:
			num2 = -1685775885;
			goto IL_0008;
		}

		public static int IndexOf(uint[] array, uint value)
		{
			if (array == null)
			{
				return -1;
			}
			int num = 0;
			while (num < array.Length)
			{
				while (true)
				{
					int num2;
					if (array[num] == value)
					{
						num2 = 1424650649;
					}
					else
					{
						num++;
						num2 = 1424650648;
					}
					while (true)
					{
						switch (num2 ^ 0x54EA719A)
						{
						case 0:
							num2 = 1424650651;
							continue;
						case 1:
							break;
						case 3:
							return num;
						default:
							goto end_IL_002b;
						}
						break;
					}
					continue;
					end_IL_002b:
					break;
				}
			}
			return -1;
		}

		public static int IndexOf(double[] array, double value)
		{
			if (array == null)
			{
				return -1;
			}
			int num = 0;
			while (num < array.Length)
			{
				while (true)
				{
					if (array[num] == value)
					{
						return num;
					}
					num++;
					int num2 = 567281780;
					while (true)
					{
						switch (num2 ^ 0x21D00875)
						{
						case 0:
							num2 = 567281783;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0027;
						}
						break;
					}
					continue;
					end_IL_0027:
					break;
				}
			}
			return -1;
		}

		public static int IndexOf(bool[] array, bool value)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			int num = 0;
			int num2 = 78952515;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ 0x4B4B842)
				{
				case 0:
					break;
				case 4:
					if (array[num] == value)
					{
						return num;
					}
					num++;
					num2 = 78952512;
					continue;
				case 1:
					num2 = 78952512;
					continue;
				case 3:
					return -1;
				default:
					if (num >= array.Length)
					{
						return -1;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = 78952513;
			goto IL_0008;
		}

		public static int IndexOf(string[] array, string value)
		{
			if (array == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < array.Length)
				{
					num2 = 826258576;
					num3 = num2;
				}
				else
				{
					num2 = 826258578;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x313FB491)
					{
					case 0:
						num2 = 826258576;
						continue;
					case 1:
						if (array[num] == value)
						{
							return num;
						}
						num++;
						num2 = 826258579;
						continue;
					case 2:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public static int IndexOf(string[] array, string value, StringComparison stringComparison)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			int num = 0;
			int num2 = -1698039714;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ -1698039714)
				{
				case 4:
					break;
				case 3:
					return -1;
				case 0:
					num2 = -1698039716;
					continue;
				case 1:
					if (array[num].Equals(value, stringComparison))
					{
						return num;
					}
					num++;
					num2 = -1698039716;
					continue;
				default:
					if (num >= array.Length)
					{
						return -1;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = -1698039715;
			goto IL_0008;
		}

		public static void Fill<T>(T[] array, T value)
		{
			if (array == null)
			{
				return;
			}
			while (true)
			{
				int num = 0;
				int num2 = 1344928439;
				while (true)
				{
					switch (num2 ^ 0x5029FAB6)
					{
					case 4:
						num2 = 1344928436;
						continue;
					case 0:
						array[num] = value;
						num++;
						num2 = 1344928437;
						continue;
					case 1:
						num2 = 1344928437;
						continue;
					case 2:
						break;
					default:
						if (num >= array.Length)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static void Fill<T>(T[] array, T value, int startIndex)
		{
			if (array == null)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (startIndex < 0)
				{
					num = -652302010;
					num2 = num;
				}
				else
				{
					num = -652302009;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -652302015)
					{
					case 2:
						num = -652302016;
						continue;
					case 1:
						break;
					case 6:
					{
						int num4;
						if (startIndex < array.Length)
						{
							num = -652302014;
							num4 = num;
						}
						else
						{
							num = -652302010;
							num4 = num;
						}
						continue;
					}
					case 5:
						array[num3] = value;
						num = -652302015;
						continue;
					case 3:
						num3 = startIndex;
						num = -652302011;
						continue;
					case 7:
						throw new ArgumentOutOfRangeException("startIndex");
					case 0:
						num3++;
						num = -652302011;
						continue;
					default:
						if (num3 >= array.Length)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		public static void Fill<T>(T[] array, T value, int startIndex, int length)
		{
			if (array == null)
			{
				return;
			}
			int num3 = default(int);
			while (startIndex >= 0)
			{
				int num;
				int num2;
				if (startIndex >= array.Length)
				{
					num = 143009155;
					num2 = num;
				}
				else
				{
					num = 143009159;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x8862586)
					{
					case 8:
						num = 143009152;
						continue;
					default:
						return;
					case 7:
						array[num3] = value;
						num = 143009156;
						continue;
					case 1:
						length = MathTools.Clamp(startIndex + length, 0, array.Length);
						num3 = startIndex;
						num = 143009158;
						continue;
					case 5:
						break;
					case 3:
						goto IL_0078;
					case 6:
						goto end_IL_000c;
					case 2:
						num3++;
						num = 143009157;
						continue;
					case 0:
						num = 143009157;
						continue;
					case 4:
						return;
					}
					goto end_IL_0092;
					IL_0078:
					int num4;
					if (num3 >= array.Length)
					{
						num = 143009154;
						num4 = num;
					}
					else
					{
						num = 143009153;
						num4 = num;
					}
					continue;
					end_IL_000c:
					break;
				}
				continue;
				end_IL_0092:
				break;
			}
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public static void Populate<T>(T[] array, int startIndex, int length, Func<T> instantiator)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num3 = default(int);
			while (length > 0)
			{
				while (true)
				{
					if (startIndex < 0)
					{
						throw new ArgumentOutOfRangeException("startIndex must be >= 0");
					}
					while (true)
					{
						IL_009a:
						int num;
						int num2;
						if (startIndex < length)
						{
							num = -835838364;
							num2 = num;
						}
						else
						{
							num = -835838366;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -835838363)
							{
							case 0:
								num = -835838353;
								continue;
							default:
								return;
							case 6:
								num = -835838368;
								continue;
							case 1:
								break;
							case 11:
								goto end_IL_0016;
							case 4:
								num3 = startIndex;
								num = -835838365;
								continue;
							case 2:
								goto IL_009a;
							case 12:
								array[num3] = instantiator();
								num3++;
								num = -835838368;
								continue;
							case 8:
								throw new ArgumentOutOfRangeException("length must be <= array.Length");
							case 7:
								throw new ArgumentOutOfRangeException("startIndex must be < length");
							case 10:
								goto end_IL_0078;
							case 5:
								goto IL_0109;
							case 9:
								if (startIndex + length > array.Length)
								{
									throw new ArgumentOutOfRangeException("startIndex + length must be <= array.Length");
								}
								goto case 4;
							case 3:
								return;
							}
							int num4;
							if (length > array.Length)
							{
								num = -835838355;
								num4 = num;
							}
							else
							{
								num = -835838356;
								num4 = num;
							}
							continue;
							IL_0109:
							int num5;
							if (num3 >= startIndex + length)
							{
								num = -835838362;
								num5 = num;
							}
							else
							{
								num = -835838359;
								num5 = num;
							}
							continue;
							end_IL_0016:
							break;
						}
						break;
					}
					continue;
					end_IL_0078:
					break;
				}
			}
		}

		public static void Populate<T>(T[] array, int startIndex, int length) where T : class, new()
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (length > 0)
				{
					num = 547285163;
					num2 = num;
				}
				else
				{
					num = 547285160;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x209EE8AA)
					{
					case 0:
						num = 547285152;
						continue;
					case 1:
						if (startIndex < 0)
						{
							throw new ArgumentOutOfRangeException("startIndex must be >= 0");
						}
						goto case 7;
					case 6:
						num3++;
						num = 547285155;
						continue;
					case 8:
						num3 = startIndex;
						num = 547285155;
						continue;
					case 2:
						return;
					case 5:
						if (startIndex + length > array.Length)
						{
							throw new ArgumentOutOfRangeException("startIndex + length must be <= array.Length");
						}
						goto case 8;
					case 4:
						array[num3] = new T();
						num = 547285164;
						continue;
					case 10:
						break;
					case 7:
						if (startIndex >= length)
						{
							throw new ArgumentOutOfRangeException("startIndex must be < length");
						}
						goto case 3;
					case 3:
						if (length > array.Length)
						{
							throw new ArgumentOutOfRangeException("length must be <= array.Length");
						}
						goto case 5;
					default:
						if (num3 >= startIndex + length)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public static void Populate<T>(T[] array) where T : class, new()
		{
			if (array == null)
			{
				while (true)
				{
					switch (-305979101 ^ -305979102)
					{
					case 2:
						continue;
					case 1:
						throw new ArgumentNullException("array");
					}
					break;
				}
			}
			Populate(array, 0, array.Length);
		}

		public static void Populate<T>(T[] array, Func<T> instantiator)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			Populate(array, 0, array.Length, instantiator);
		}

		public static int Count<T>(T[] array, Predicate<T> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			while (array != null)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 797068969;
				while (true)
				{
					switch (num3 ^ 0x2F824EA8)
					{
					case 3:
						num3 = 797068970;
						continue;
					case 2:
						break;
					case 4:
						if (predicate(array[num2]))
						{
							num++;
							num3 = 797068968;
							continue;
						}
						goto case 0;
					case 0:
						num2++;
						num3 = 797068969;
						continue;
					default:
						if (num2 >= array.Length)
						{
							return num;
						}
						goto case 4;
					}
					break;
				}
			}
			return 0;
		}

		public static bool IsEqual(byte[] a1, byte[] a2)
		{
			if (a1 == a2)
			{
				return true;
			}
			if (a1.Length != a2.Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < a1.Length)
				{
					num2 = -907113560;
					num3 = num2;
				}
				else
				{
					num2 = -907113557;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -907113557)
					{
					case 4:
						num2 = -907113560;
						continue;
					case 2:
						break;
					case 1:
						return false;
					case 3:
						if (a1[num] == a2[num])
						{
							num++;
							num2 = -907113559;
						}
						else
						{
							num2 = -907113558;
						}
						continue;
					default:
						return true;
					}
					break;
				}
			}
		}

		public static bool Contains(string[] array, string item, bool ignoreCase)
		{
			if (array == null)
			{
				return false;
			}
			int num = array.Length;
			int num3 = default(int);
			while (true)
			{
				int num2 = -1227883047;
				while (true)
				{
					switch (num2 ^ -1227883048)
					{
					case 0:
						break;
					case 1:
						num3 = 0;
						num2 = -1227883044;
						continue;
					case 3:
						if (array[num3].Equals(item, StringComparison.OrdinalIgnoreCase))
						{
							num2 = -1227883046;
							continue;
						}
						goto IL_005e;
					case 2:
						return true;
					case 5:
						if (!ignoreCase)
						{
							if (array[num3] == item)
							{
								return true;
							}
							goto IL_005e;
						}
						num2 = -1227883045;
						continue;
					default:
						{
							if (num3 >= num)
							{
								return false;
							}
							goto case 5;
						}
						IL_005e:
						num3++;
						num2 = -1227883044;
						continue;
					}
					break;
				}
			}
		}

		public static int AddIfUnique(ref string[] array, string item, bool ignoreCase)
		{
			if (array != null && array.Length != 0)
			{
				while (true)
				{
					int num = 1194614177;
					while (true)
					{
						switch (num ^ 0x47345DA3)
						{
						case 0:
							break;
						case 2:
							goto IL_0028;
						default:
							goto end_IL_000a;
						}
						break;
						IL_0028:
						if (!Contains(array, item, ignoreCase))
						{
							num = 1194614178;
							continue;
						}
						return -1;
					}
					continue;
					end_IL_000a:
					break;
				}
			}
			return Add(ref array, item);
		}

		public static void RemoveDuplicates(ref string[] array, bool ignoreCase)
		{
			int num = ((array != null) ? array.Length : 0);
			if (num == 0)
			{
				goto IL_000f;
			}
			goto IL_008a;
			IL_008a:
			string[] array2 = null;
			int num2 = -1060135651;
			goto IL_0014;
			IL_0014:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -1060135655)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					AddIfUnique(ref array2, array[num3], ignoreCase);
					num2 = -1060135650;
					continue;
				case 1:
					if (num3 >= num)
					{
						array = array2;
						num2 = -1060135655;
						continue;
					}
					goto case 3;
				case 7:
					num3++;
					num2 = -1060135656;
					continue;
				case 5:
					return;
				case 6:
					num2 = -1060135656;
					continue;
				case 4:
					num3 = 0;
					num2 = -1060135649;
					continue;
				case 8:
					goto IL_008a;
				case 0:
					return;
				}
				break;
			}
			goto IL_000f;
			IL_000f:
			num2 = -1060135652;
			goto IL_0014;
		}

		public static bool Remove(ref string[] array, string item, bool ignoreCase)
		{
			if (array == null)
			{
				goto IL_0007;
			}
			int num = array.Length;
			int num2 = -695661390;
			goto IL_000c;
			IL_000c:
			int num3 = default(int);
			int num5 = default(int);
			while (true)
			{
				switch (num2 ^ -695661382)
				{
				case 2:
					break;
				case 7:
					if (array[num3] != null && array[num3].Equals(item, StringComparison.OrdinalIgnoreCase))
					{
						RemoveAt(ref array, num3);
						return true;
					}
					goto IL_00fe;
				case 8:
					if (item == null)
					{
						num5 = 0;
						num2 = -695661377;
						continue;
					}
					goto case 9;
				case 5:
					if (num5 >= num)
					{
						num2 = -695661381;
						continue;
					}
					goto case 6;
				case 10:
					return false;
				case 4:
					num2 = -695661391;
					continue;
				case 3:
					if (!ignoreCase)
					{
						if (array[num3] == item)
						{
							num2 = -695661382;
							continue;
						}
						goto IL_00fe;
					}
					num2 = -695661379;
					continue;
				case 9:
					num3 = 0;
					num2 = -695661378;
					continue;
				case 6:
					if (array[num5] == null)
					{
						RemoveAt(ref array, num5);
						return true;
					}
					num5++;
					num2 = -695661377;
					continue;
				case 0:
					RemoveAt(ref array, num3);
					return true;
				case 11:
				{
					int num4;
					if (num3 >= num)
					{
						num2 = -695661381;
						num4 = num2;
					}
					else
					{
						num2 = -695661383;
						num4 = num2;
					}
					continue;
				}
				default:
					{
						return false;
					}
					IL_00fe:
					num3++;
					num2 = -695661391;
					continue;
				}
				break;
			}
			goto IL_0007;
			IL_0007:
			num2 = -695661392;
			goto IL_000c;
		}

		public static string[] ToLowerStripSpaces(string[] array)
		{
			if (array == null)
			{
				return null;
			}
			if (array.Length == 0)
			{
				goto IL_000a;
			}
			string[] array2 = new string[array.Length];
			int num = 0;
			int num2 = 763316177;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num2 ^ 0x2D7F47D4)
				{
				case 2:
					break;
				case 1:
					return null;
				case 5:
					num2 = 763316180;
					continue;
				case 4:
					num++;
					num2 = 763316180;
					continue;
				case 3:
					if (array[num] != null)
					{
						array2[num] = array[num].ToLower().Replace(" ", "");
						num2 = 763316176;
						continue;
					}
					goto case 4;
				default:
					if (num >= array.Length)
					{
						return array2;
					}
					goto case 3;
				}
				break;
			}
			goto IL_000a;
			IL_000a:
			num2 = 763316181;
			goto IL_000f;
		}

		public static int ToBitmask(bool[] array, int startIndex, int count = 32)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num3 = default(int);
			int num4 = default(int);
			while (startIndex >= 0)
			{
				int num;
				int num2;
				if (startIndex >= array.Length)
				{
					num = 1185258909;
					num2 = num;
				}
				else
				{
					num = 1185258903;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x46A59D94)
					{
					case 2:
						num = 1185258899;
						continue;
					case 10:
						throw new ArgumentOutOfRangeException("count");
					case 6:
						break;
					case 0:
						throw new ArgumentOutOfRangeException("count must be <= 32");
					case 3:
						if (count <= 0)
						{
							goto case 10;
						}
						goto IL_0094;
					case 7:
						goto end_IL_0016;
					case 11:
						goto IL_00d0;
					case 1:
						num3++;
						num = 1185258897;
						continue;
					case 8:
						num4 |= 1 << num3;
						num = 1185258901;
						continue;
					case 9:
						goto end_IL_00b2;
					case 4:
						num4 = 0;
						num3 = 0;
						num = 1185258897;
						continue;
					default:
						if (num3 >= array.Length)
						{
							return num4;
						}
						break;
					}
					int num5;
					if (array[num3])
					{
						num = 1185258908;
						num5 = num;
					}
					else
					{
						num = 1185258901;
						num5 = num;
					}
					continue;
					IL_00d0:
					int num6;
					if (count > 32)
					{
						num = 1185258900;
						num6 = num;
					}
					else
					{
						num = 1185258896;
						num6 = num;
					}
					continue;
					IL_0094:
					int num7;
					if (startIndex + count > array.Length + 1)
					{
						num = 1185258910;
						num7 = num;
					}
					else
					{
						num = 1185258911;
						num7 = num;
					}
					continue;
					end_IL_0016:
					break;
				}
				continue;
				end_IL_00b2:
				break;
			}
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public static bool IsNullOrEmpty<T>(T[] array)
		{
			if (array == null)
			{
				return true;
			}
			if (array.Length == 0)
			{
				return true;
			}
			if (!typeof(T).IsClass)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = 1564669078;
				while (true)
				{
					switch (num2 ^ 0x5D42F492)
					{
					case 0:
						break;
					case 1:
					{
						int num3;
						if (num < array.Length)
						{
							num2 = 1564669072;
							num3 = num2;
						}
						else
						{
							num2 = 1564669073;
							num3 = num2;
						}
						continue;
					}
					case 2:
						if (array[num] != null)
						{
							return false;
						}
						num++;
						num2 = 1564669075;
						continue;
					case 4:
						num2 = 1564669075;
						continue;
					default:
						return true;
					}
					break;
				}
			}
		}
	}
}
