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
						int num2 = 146775784;
						while (true)
						{
							switch (num2 ^ 0x8BF9EE8)
							{
							case 2:
								num2 = 146775785;
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
				while (true)
				{
					IL_0078:
					int num3 = 146775785;
					while (true)
					{
						switch (num3 ^ 0x8BF9EE8)
						{
						case 2:
							break;
						default:
							goto end_IL_007d;
						case 1:
							if (disposable != null)
							{
								goto IL_009a;
							}
							goto end_IL_007d;
						case 0:
							goto end_IL_007d;
						}
						goto IL_0078;
						IL_009a:
						disposable.Dispose();
						num3 = 146775784;
						continue;
						end_IL_007d:
						break;
					}
					break;
				}
			}
		}

		public static T[] DeepClone<T>(T[] array) where T : class, IDeepCloneable
		{
			if (array == null)
			{
				return null;
			}
			T[] array2 = new T[array.Length];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < array.Length)
				{
					num2 = -1805516567;
					num3 = num2;
				}
				else
				{
					num2 = -1805516563;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1805516563)
					{
					case 2:
						num2 = -1805516567;
						continue;
					case 3:
						break;
					case 5:
						array2[num] = array[num].DeepClone() as T;
						num2 = -1805516564;
						continue;
					case 1:
						num++;
						num2 = -1805516562;
						continue;
					case 4:
					{
						int num4;
						if (array[num] == null)
						{
							num2 = -1805516564;
							num4 = num2;
						}
						else
						{
							num2 = -1805516568;
							num4 = num2;
						}
						continue;
					}
					default:
						return array2;
					}
					break;
				}
			}
		}

		public static T[] ShallowCopy<T>(T[] array)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			T[] array2 = new T[array.Length];
			Array.Copy(array, array2, array.Length);
			int num = -339983863;
			goto IL_0008;
			IL_0008:
			switch (num ^ -339983861)
			{
			case 0:
				break;
			case 1:
				return null;
			default:
				return array2;
			}
			goto IL_0003;
			IL_0003:
			num = -339983862;
			goto IL_0008;
		}

		public static void ShallowCopy<T>(T[] sourceArray, T[] targetArray)
		{
			if (sourceArray == null)
			{
				goto IL_0003;
			}
			goto IL_0031;
			IL_0003:
			int num = 1383709298;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x5279BA73)
			{
			case 2:
				break;
			case 1:
				return;
			case 3:
				goto IL_0031;
			case 0:
				return;
			default:
			{
				int length = Math.Min(sourceArray.Length, targetArray.Length);
				Array.Copy(sourceArray, targetArray, length);
				return;
			}
			}
			goto IL_0003;
			IL_0031:
			int num2;
			if (targetArray == null)
			{
				num = 1383709299;
				num2 = num;
			}
			else
			{
				num = 1383709303;
				num2 = num;
			}
			goto IL_0008;
		}

		public static void ShallowCopy(int[] sourceArray, int[] targetArray)
		{
			if (sourceArray == null)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (targetArray == null)
				{
					num = 2075395704;
					num2 = num;
				}
				else
				{
					num = 2075395707;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x7BB40679)
					{
					case 0:
						goto IL_0004;
					case 3:
						break;
					case 1:
						return;
					default:
					{
						int length = Math.Min(sourceArray.Length, targetArray.Length);
						Array.Copy(sourceArray, targetArray, length);
						return;
					}
					}
					break;
					IL_0004:
					num = 2075395706;
				}
			}
		}

		public static void ShallowCopy(float[] sourceArray, float[] targetArray)
		{
			if (sourceArray == null)
			{
				while (true)
				{
					switch (0x510FB0A5 ^ 0x510FB0A4)
					{
					case 3:
						break;
					case 1:
						return;
					case 2:
						goto end_IL_0003;
					default:
						goto IL_0038;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			if (targetArray == null)
			{
				return;
			}
			goto IL_0038;
			IL_0038:
			int length = Math.Min(sourceArray.Length, targetArray.Length);
			Array.Copy(sourceArray, targetArray, length);
		}

		public static void ShallowCopy(bool[] sourceArray, bool[] targetArray)
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
					int num = -421288214;
					while (true)
					{
						switch (num ^ -421288213)
						{
						case 2:
							num = -421288216;
							continue;
						case 3:
							break;
						case 0:
							goto IL_0031;
						default:
							Array.Copy(sourceArray, targetArray, length);
							return;
						}
						break;
					}
					break;
				}
			}
		}

		public static byte[] CopyRange(byte[] inArray, int startPos, int length)
		{
			if (inArray != null)
			{
				int num2 = default(int);
				byte[] array = default(byte[]);
				while (true)
				{
					int num = -2044153512;
					while (true)
					{
						switch (num ^ -2044153511)
						{
						case 0:
							break;
						case 1:
							goto IL_0035;
						case 3:
							num2 = 0;
							num = -2044153507;
							continue;
						case 7:
							goto IL_0053;
						case 2:
							array[num2] = inArray[startPos + num2];
							num = -2044153505;
							continue;
						case 6:
							num2++;
							num = -2044153507;
							continue;
						case 5:
							goto end_IL_0003;
						default:
							if (num2 >= length)
							{
								return array;
							}
							goto case 2;
						}
						break;
						IL_0053:
						if (startPos < 0)
						{
							num = -2044153508;
							continue;
						}
						array = new byte[length];
						num = -2044153510;
						continue;
						IL_0035:
						int num3;
						if (length < 1)
						{
							num = -2044153508;
							num3 = num;
						}
						else
						{
							num = -2044153506;
							num3 = num;
						}
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return null;
		}

		public static int[] CopyRange(int[] inArray, int startPos, int length)
		{
			int[] array = default(int[]);
			int num = default(int);
			int num2;
			if (inArray != null && length >= 1)
			{
				if (startPos < 0)
				{
					goto IL_000b;
				}
				array = new int[length];
				num = 0;
				num2 = -568166961;
				goto IL_0010;
			}
			goto IL_002d;
			IL_000b:
			num2 = -568166964;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num2 ^ -568166963)
				{
				case 3:
					break;
				case 1:
					goto IL_002d;
				case 0:
					array[num] = inArray[startPos + num];
					num++;
					num2 = -568166961;
					continue;
				default:
					if (num >= length)
					{
						return array;
					}
					goto case 0;
				}
				break;
			}
			goto IL_000b;
			IL_002d:
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
				num = -864967699;
				goto IL_0010;
			}
			goto IL_0031;
			IL_000b:
			num = -864967701;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -864967703)
				{
				case 0:
					break;
				case 2:
					goto IL_0031;
				case 1:
					array[num2] = inArray[startPos + num2];
					num2++;
					num = -864967702;
					continue;
				case 4:
					num2 = 0;
					num = -864967702;
					continue;
				default:
					if (num2 >= length)
					{
						return array;
					}
					goto case 1;
				}
				break;
			}
			goto IL_000b;
			IL_0031:
			return null;
		}

		public static string[] CopyRange(string[] inArray, int startPos, int length)
		{
			if (inArray != null)
			{
				string[] array = default(string[]);
				int num2 = default(int);
				while (true)
				{
					int num = -307284968;
					while (true)
					{
						switch (num ^ -307284963)
						{
						case 4:
							break;
						case 3:
							array[num2] = inArray[startPos + num2];
							num2++;
							num = -307284965;
							continue;
						case 0:
							goto IL_0044;
						case 6:
							goto IL_004f;
						case 5:
							goto IL_0064;
						case 2:
							goto end_IL_0003;
						default:
							return array;
						}
						break;
						IL_0064:
						int num3;
						if (length >= 1)
						{
							num = -307284963;
							num3 = num;
						}
						else
						{
							num = -307284961;
							num3 = num;
						}
						continue;
						IL_004f:
						int num4;
						if (num2 >= length)
						{
							num = -307284964;
							num4 = num;
						}
						else
						{
							num = -307284962;
							num4 = num;
						}
						continue;
						IL_0044:
						if (startPos < 0)
						{
							num = -307284961;
							continue;
						}
						array = new string[length];
						num2 = 0;
						num = -307284965;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return null;
		}

		public static byte[] Combine(byte[] inArray1, byte[] inArray2)
		{
			byte[] array = null;
			if (inArray1 != null)
			{
				goto IL_0051;
			}
			int num = 0;
			goto IL_00a4;
			IL_0051:
			num = inArray1.Length;
			int num2 = -1180120411;
			goto IL_0011;
			IL_00a4:
			int num3 = default(int);
			if (inArray2 == null)
			{
				num3 = 0;
				num2 = -1180120409;
				goto IL_0011;
			}
			goto IL_00f5;
			IL_00f5:
			num3 = inArray2.Length;
			num2 = -1180120409;
			goto IL_0011;
			IL_0011:
			int num5 = default(int);
			int num6 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -1180120413)
				{
				case 2:
					num2 = -1180120407;
					continue;
				case 10:
					break;
				case 11:
					array[num5] = inArray1[num6];
					num5++;
					num6++;
					num2 = -1180120406;
					continue;
				case 5:
					return array;
				case 9:
					goto IL_008b;
				case 6:
					goto IL_00a4;
				case 4:
					goto IL_00b3;
				case 8:
					num4 = 0;
					num2 = -1180120416;
					continue;
				case 7:
					array[num5] = inArray2[num4];
					num5++;
					num4++;
					num2 = -1180120416;
					continue;
				case 0:
					goto IL_00e8;
				case 1:
					goto IL_00f5;
				default:
					if (num4 >= num3)
					{
						return array;
					}
					goto case 7;
				}
				break;
				IL_00e8:
				if (num3 == 0)
				{
					num2 = -1180120410;
					continue;
				}
				goto IL_0076;
				IL_0076:
				array = new byte[num + num3];
				num5 = 0;
				num6 = 0;
				num2 = -1180120406;
				continue;
				IL_00b3:
				if (num == 0)
				{
					num2 = -1180120413;
					continue;
				}
				goto IL_0076;
				IL_008b:
				int num7;
				if (num6 >= num)
				{
					num2 = -1180120405;
					num7 = num2;
				}
				else
				{
					num2 = -1180120408;
					num7 = num2;
				}
			}
			goto IL_0051;
		}

		public static int[] Combine(int[] inArray1, int[] inArray2)
		{
			int[] array = null;
			int num;
			if (inArray1 == null)
			{
				num = 0;
				goto IL_000a;
			}
			goto IL_00d1;
			IL_00d1:
			num = inArray1.Length;
			int num2 = 2138066149;
			goto IL_000f;
			IL_000a:
			num2 = 2138066152;
			goto IL_000f;
			IL_000f:
			int num4 = default(int);
			int num5 = default(int);
			int num6 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x7F704CEF)
				{
				case 12:
					break;
				case 10:
					if (inArray2 == null)
					{
						num4 = 0;
						num2 = 2138066158;
						continue;
					}
					goto case 8;
				case 6:
					num5++;
					num2 = 2138066150;
					continue;
				case 13:
					array[num6] = inArray2[num3];
					num6++;
					num2 = 2138066159;
					continue;
				case 1:
					goto IL_0082;
				case 5:
					num6 = 0;
					num5 = 0;
					num2 = 2138066150;
					continue;
				case 8:
					num4 = inArray2.Length;
					num2 = 2138066158;
					continue;
				case 2:
					return array;
				case 0:
					num3++;
					num2 = 2138066155;
					continue;
				case 3:
					goto IL_00d1;
				case 9:
					if (num5 >= num)
					{
						num3 = 0;
						num2 = 2138066155;
						continue;
					}
					goto case 11;
				case 7:
					num2 = 2138066149;
					continue;
				case 11:
					array[num6] = inArray1[num5];
					num6++;
					num2 = 2138066153;
					continue;
				default:
					if (num3 >= num4)
					{
						return array;
					}
					goto case 13;
				}
				break;
				IL_0082:
				if (num == 0 && num4 == 0)
				{
					num2 = 2138066157;
					continue;
				}
				array = new int[num + num4];
				num2 = 2138066154;
			}
			goto IL_000a;
		}

		public static float[] Combine(float[] inArray1, float[] inArray2)
		{
			float[] array = null;
			int num;
			if (inArray1 == null)
			{
				num = 0;
				goto IL_00c1;
			}
			goto IL_00f8;
			IL_0071:
			int num2 = inArray2.Length;
			int num3 = -72004525;
			goto IL_0014;
			IL_00c1:
			if (inArray2 == null)
			{
				num2 = 0;
				num3 = -72004525;
				goto IL_0014;
			}
			goto IL_0071;
			IL_00f8:
			num = inArray1.Length;
			num3 = -72004513;
			goto IL_0014;
			IL_0014:
			int num6 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num3 ^ -72004515)
				{
				case 11:
					num3 = -72004516;
					continue;
				case 12:
					num6++;
					num3 = -72004517;
					continue;
				case 7:
					break;
				case 0:
					num5 = 0;
					num3 = -72004519;
					continue;
				case 13:
					goto IL_0085;
				case 4:
					num6 = 0;
					num3 = -72004526;
					continue;
				case 5:
					num4 = 0;
					num3 = -72004524;
					continue;
				case 15:
					num3 = -72004517;
					continue;
				case 2:
					goto IL_00c1;
				case 10:
					array[num5] = inArray2[num4];
					num5++;
					num4++;
					num3 = -72004524;
					continue;
				case 14:
					goto IL_00eb;
				case 1:
					goto IL_00f8;
				case 6:
					goto IL_0106;
				case 8:
					num5++;
					num3 = -72004527;
					continue;
				case 3:
					array[num5] = inArray1[num6];
					num3 = -72004523;
					continue;
				default:
					if (num4 >= num2)
					{
						return array;
					}
					goto case 10;
				}
				break;
				IL_0106:
				int num7;
				if (num6 < num)
				{
					num3 = -72004514;
					num7 = num3;
				}
				else
				{
					num3 = -72004520;
					num7 = num3;
				}
				continue;
				IL_008a:
				array = new float[num + num2];
				num3 = -72004515;
				continue;
				IL_0085:
				if (num2 == 0)
				{
					return array;
				}
				goto IL_008a;
				IL_00eb:
				if (num == 0)
				{
					num3 = -72004528;
					continue;
				}
				goto IL_008a;
			}
			goto IL_0071;
		}

		public static string[] Combine(string[] inArray1, string[] inArray2)
		{
			string[] array = null;
			int num6 = default(int);
			int num4 = default(int);
			int num2 = default(int);
			int num7 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = 461038106;
				while (true)
				{
					switch (num ^ 0x1B7AE21F)
					{
					case 15:
						break;
					case 13:
						num = 461038099;
						continue;
					case 12:
						if (num6 == 0 && num4 == 0)
						{
							num = 461038104;
							continue;
						}
						array = new string[num6 + num4];
						num2 = 0;
						num7 = 0;
						num = 461038102;
						continue;
					case 1:
						num2++;
						num7++;
						num = 461038102;
						continue;
					case 5:
						if (inArray1 == null)
						{
							num6 = 0;
							num = 461038097;
							continue;
						}
						goto case 0;
					case 9:
					{
						int num8;
						if (num7 < num6)
						{
							num = 461038100;
							num8 = num;
						}
						else
						{
							num = 461038107;
							num8 = num;
						}
						continue;
					}
					case 3:
						num4 = inArray2.Length;
						num = 461038099;
						continue;
					case 11:
						array[num2] = inArray1[num7];
						num = 461038110;
						continue;
					case 7:
						return array;
					case 0:
						num6 = inArray1.Length;
						num = 461038097;
						continue;
					case 2:
						num3++;
						num = 461038105;
						continue;
					case 14:
						if (inArray2 == null)
						{
							num4 = 0;
							num = 461038098;
							continue;
						}
						goto case 3;
					case 4:
						num3 = 0;
						num = 461038105;
						continue;
					case 6:
					{
						int num5;
						if (num3 >= num4)
						{
							num = 461038103;
							num5 = num;
						}
						else
						{
							num = 461038101;
							num5 = num;
						}
						continue;
					}
					case 10:
						array[num2] = inArray2[num3];
						num2++;
						num = 461038109;
						continue;
					default:
						return array;
					}
					break;
				}
			}
		}

		public static T[] ParseArray<T>(string line)
		{
			line = line.Replace("{", "");
			line = line.Replace("}", "");
			string[] array = line.Split(',');
			int num3 = default(int);
			T[] array2 = default(T[]);
			string text = default(string);
			string value = default(string);
			int num2 = default(int);
			while (true)
			{
				int num = -525967799;
				while (true)
				{
					switch (num ^ -525967796)
					{
					case 0:
						break;
					case 5:
						num3 = array.Length;
						array2 = new T[num3];
						if (num3 == 1)
						{
							text = array[0].Trim().ToLower();
							num = -525967800;
							continue;
						}
						goto IL_00f6;
					case 1:
						value = array[num2].Trim();
						num = -525967793;
						continue;
					case 3:
						array2[num2] = (T)Convert.ChangeType(value, typeof(T));
						num2++;
						num = -525967794;
						continue;
					case 4:
						if (text == "")
						{
							goto case 6;
						}
						if (text == "null")
						{
							num = -525967798;
							continue;
						}
						goto IL_00f6;
					case 6:
						return null;
					default:
						{
							if (num2 >= num3)
							{
								return array2;
							}
							goto case 1;
						}
						IL_00f6:
						num2 = 0;
						num = -525967794;
						continue;
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
				goto IL_0009;
			}
			int num = array.Length;
			if (num == 0)
			{
				sortedIndices = new int[0];
				return array;
			}
			int num2;
			T[] array2 = default(T[]);
			if (num == 1)
			{
				num2 = 1669591452;
			}
			else
			{
				array2 = new T[num];
				num2 = 1669591443;
			}
			goto IL_000e;
			IL_0009:
			num2 = 1669591444;
			goto IL_000e;
			IL_000e:
			bool[] array4 = default(bool[]);
			int num3 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			T val2 = default(T);
			T val = default(T);
			while (true)
			{
				switch (num2 ^ 0x6383F190)
				{
				case 6:
					break;
				case 7:
					array4 = new bool[num];
					num3 = 0;
					num2 = 1669591442;
					continue;
				case 5:
					sortedIndices[num3] = num5;
					array4[num5] = true;
					num3++;
					num2 = 1669591442;
					continue;
				case 0:
					if (!array4[num4])
					{
						val2 = array[num4];
						if (num5 != -1)
						{
							int num7;
							if (val2.CompareTo(val) >= 0)
							{
								num2 = 1669591449;
								num7 = num2;
							}
							else
							{
								num2 = 1669591448;
								num7 = num2;
							}
							continue;
						}
						goto case 8;
					}
					goto case 9;
				case 4:
					return null;
				case 8:
					val = val2;
					num5 = num4;
					num2 = 1669591449;
					continue;
				case 9:
					num4++;
					num2 = 1669591451;
					continue;
				case 10:
					array2[num3] = val;
					num2 = 1669591445;
					continue;
				case 3:
					sortedIndices = new int[num];
					num2 = 1669591447;
					continue;
				case 11:
				{
					int num6;
					if (num4 >= num)
					{
						num2 = 1669591450;
						num6 = num2;
					}
					else
					{
						num2 = 1669591440;
						num6 = num2;
					}
					continue;
				}
				case 12:
				{
					int[] array3 = new int[1];
					sortedIndices = array3;
					return array;
				}
				case 1:
					val = default(T);
					num5 = -1;
					num4 = 0;
					num2 = 1669591451;
					continue;
				default:
					if (num3 >= num)
					{
						return array2;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0009;
		}

		public static T[] SortDescending<T>(T[] array, out int[] sortedIndices, bool ascending = true) where T : IComparable<T>
		{
			if (array == null)
			{
				sortedIndices = null;
				return null;
			}
			int num = array.Length;
			if (num == 0)
			{
				goto IL_0012;
			}
			if (num == 1)
			{
				int[] array2 = new int[1];
				sortedIndices = array2;
				return array;
			}
			T[] array3 = new T[num];
			sortedIndices = new int[num];
			int num2 = -1835617065;
			goto IL_0017;
			IL_0017:
			bool[] array4 = default(bool[]);
			int num6 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			T val2 = default(T);
			T val = default(T);
			while (true)
			{
				switch (num2 ^ -1835617058)
				{
				case 3:
					break;
				case 1:
					sortedIndices = new int[0];
					num2 = -1835617064;
					continue;
				case 2:
					array4[num6] = true;
					num3++;
					num2 = -1835617061;
					continue;
				case 13:
					if (!array4[num4])
					{
						val2 = array[num4];
						if (num6 != -1)
						{
							int num7;
							if (val2.CompareTo(val) < 0)
							{
								num2 = -1835617058;
								num7 = num2;
							}
							else
							{
								num2 = -1835617072;
								num7 = num2;
							}
							continue;
						}
						goto case 0;
					}
					goto case 14;
				case 4:
					num4 = 0;
					num2 = -1835617068;
					continue;
				case 11:
					val = default(T);
					num6 = -1;
					num2 = -1835617062;
					continue;
				case 12:
					array3[num3] = val;
					sortedIndices[num3] = num6;
					num2 = -1835617060;
					continue;
				case 9:
					array4 = new bool[num];
					num3 = 0;
					num2 = -1835617066;
					continue;
				case 10:
					num2 = -1835617063;
					continue;
				case 0:
					val = val2;
					num6 = num4;
					num2 = -1835617072;
					continue;
				case 6:
					return array;
				case 7:
				{
					int num5;
					if (num4 >= num)
					{
						num2 = -1835617070;
						num5 = num2;
					}
					else
					{
						num2 = -1835617069;
						num5 = num2;
					}
					continue;
				}
				case 8:
					num2 = -1835617061;
					continue;
				case 14:
					num4++;
					num2 = -1835617063;
					continue;
				default:
					if (num3 >= num)
					{
						return array3;
					}
					goto case 11;
				}
				break;
			}
			goto IL_0012;
			IL_0012:
			num2 = -1835617057;
			goto IL_0017;
		}

		public static int Add<T>(ref T[] array, T item)
		{
			int num;
			if (array == null)
			{
				num = 0;
				goto IL_0053;
			}
			goto IL_0067;
			IL_0067:
			num = array.Length;
			int num2 = -1807353724;
			goto IL_000d;
			IL_0053:
			int num3 = num + 1;
			T[] array2 = new T[num3];
			int num4 = 0;
			num2 = -1807353723;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1807353722)
				{
				case 0:
					num2 = -1807353726;
					continue;
				case 5:
					num4++;
					num2 = -1807353723;
					continue;
				case 1:
					array2[num4] = array[num4];
					num2 = -1807353725;
					continue;
				case 2:
					break;
				case 4:
					goto IL_0067;
				default:
					if (num4 >= num)
					{
						array2[num4] = item;
						array = array2;
						return num4;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0053;
		}

		public static int AddIfUnique<T>(ref T[] array, T item)
		{
			if (array == null || array.Length == 0 || !Contains(array, item))
			{
				return Add(ref array, item);
			}
			return -1;
		}

		public static int Insert<T>(ref T[] array, int index, T item)
		{
			if (index < 0)
			{
				index = 0;
				goto IL_000a;
			}
			goto IL_00e9;
			IL_00e9:
			int num;
			int num2;
			if (array == null)
			{
				num = 1588945810;
				num2 = num;
			}
			else
			{
				num = 1588945811;
				num2 = num;
			}
			goto IL_000f;
			IL_000a:
			num = 1588945809;
			goto IL_000f;
			IL_000f:
			T[] array2 = default(T[]);
			int num3 = default(int);
			int num6 = default(int);
			int num4 = default(int);
			int num5 = default(int);
			while (true)
			{
				switch (num ^ 0x5EB56399)
				{
				case 12:
					break;
				case 6:
					array2[num3] = array[num3];
					num3++;
					num = 1588945808;
					continue;
				case 0:
					if (num3 >= num6)
					{
						array = array2;
						num = 1588945821;
						continue;
					}
					goto case 1;
				case 3:
					return Add(ref array, item);
				case 10:
					num4 = array.Length;
					num = 1588945819;
					continue;
				case 9:
					if (num3 >= index)
					{
						array2[num3] = item;
						num5 = index;
						num3++;
						num = 1588945820;
						continue;
					}
					goto case 6;
				case 5:
					num = 1588945817;
					continue;
				case 11:
					num4 = 0;
					num = 1588945819;
					continue;
				case 8:
					goto IL_00e9;
				case 2:
					goto IL_0101;
				case 7:
					num3++;
					num = 1588945817;
					continue;
				case 1:
					array2[num3] = array[num5];
					num5++;
					num = 1588945822;
					continue;
				default:
					return index;
				}
				break;
				IL_0101:
				int num7 = num4 - 1;
				if (index <= num7)
				{
					num6 = num4 + 1;
					array2 = new T[num6];
					num3 = 0;
					num = 1588945808;
				}
				else
				{
					num = 1588945818;
				}
			}
			goto IL_000a;
		}

		public static bool RemoveAt<T>(ref T[] array, int index)
		{
			if (array == null)
			{
				return false;
			}
			if (index < 0)
			{
				goto IL_000a;
			}
			goto IL_0060;
			IL_0060:
			int num = array.Length;
			int num2 = num - 1;
			int num3;
			int num4;
			if (index > num2)
			{
				num3 = -1866589351;
				num4 = num3;
			}
			else
			{
				num3 = -1866589352;
				num4 = num3;
			}
			goto IL_000f;
			IL_000a:
			num3 = -1866589347;
			goto IL_000f;
			IL_000f:
			int num5 = default(int);
			T[] array2 = default(T[]);
			while (true)
			{
				switch (num3 ^ -1866589346)
				{
				case 9:
					break;
				case 5:
					num3 = -1866589345;
					continue;
				case 7:
					index = num2;
					num3 = -1866589352;
					continue;
				case 10:
					goto IL_0060;
				case 8:
					if (num5 >= index)
					{
						num5 = index + 1;
						num3 = -1866589349;
						continue;
					}
					goto case 11;
				case 3:
					index = 0;
					num3 = -1866589356;
					continue;
				case 4:
					num5 = 0;
					num3 = -1866589354;
					continue;
				case 11:
					array2[num5] = array[num5];
					num5++;
					num3 = -1866589354;
					continue;
				case 6:
				{
					int num6 = num - 1;
					array2 = new T[num6];
					num3 = -1866589350;
					continue;
				}
				case 1:
					if (num5 >= num)
					{
						array = array2;
						num3 = -1866589348;
						continue;
					}
					goto case 0;
				case 0:
					array2[num5 - 1] = array[num5];
					num5++;
					num3 = -1866589345;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_000a;
		}

		public static bool Remove<T>(ref T[] array, T item)
		{
			if (array == null)
			{
				return false;
			}
			int num = array.Length;
			int num2 = 0;
			while (true)
			{
				int num3 = -732513786;
				while (true)
				{
					switch (num3 ^ -732513785)
					{
					case 2:
						break;
					case 1:
						num3 = -732513788;
						continue;
					case 3:
					{
						int num4;
						if (num2 < num)
						{
							num3 = -732513785;
							num4 = num3;
						}
						else
						{
							num3 = -732513789;
							num4 = num3;
						}
						continue;
					}
					case 0:
						if (EqualityComparer<T>.Default.Equals(array[num2], item))
						{
							RemoveAt(ref array, num2);
							return true;
						}
						num2++;
						num3 = -732513788;
						continue;
					default:
						return false;
					}
					break;
				}
			}
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
				int num5 = default(int);
				int num6 = default(int);
				int num9 = default(int);
				int num7 = default(int);
				T[] array3 = default(T[]);
				int num8 = default(int);
				int num4 = default(int);
				while (true)
				{
					IL_0154:
					int num;
					if (array1.Length == 0)
					{
						if (array2 != null)
						{
							int num2;
							if (array2.Length == 0)
							{
								num = 1552665919;
								num2 = num;
							}
							else
							{
								num = 1552665912;
								num2 = num;
							}
							goto IL_0013;
						}
						return;
					}
					goto IL_00a4;
					IL_00a4:
					if (array2 == null)
					{
						return;
					}
					int num3;
					if (array2.Length == 0)
					{
						num = 1552665906;
						num3 = num;
					}
					else
					{
						num = 1552665913;
						num3 = num;
					}
					goto IL_0013;
					IL_0013:
					while (true)
					{
						switch (num ^ 0x5C8BCD38)
						{
						case 15:
							num = 1552665910;
							continue;
						default:
							return;
						case 8:
							if (num5 >= num6)
							{
								num9 = 0;
								num = 1552665917;
								continue;
							}
							goto case 3;
						case 10:
							return;
						case 5:
							if (num9 >= num7)
							{
								array1 = array3;
								num = 1552665916;
								continue;
							}
							goto case 9;
						case 11:
							num = 1552665904;
							continue;
						case 6:
							array3 = new T[num8];
							num = 1552665909;
							continue;
						case 0:
							break;
						case 12:
							num7 = array2.Length;
							num8 = num6 + num7;
							num = 1552665918;
							continue;
						case 3:
							array3[num4++] = array1[num5];
							num5++;
							num = 1552665904;
							continue;
						case 1:
							num6 = array1.Length;
							num = 1552665908;
							continue;
						case 9:
							array3[num4++] = array2[num9];
							num9++;
							num = 1552665917;
							continue;
						case 13:
							num4 = 0;
							num5 = 0;
							num = 1552665907;
							continue;
						case 14:
							goto end_IL_0154;
						case 2:
							goto IL_0154;
						case 7:
							return;
						case 4:
							return;
						}
						break;
					}
					goto IL_00a4;
					continue;
					end_IL_0154:
					break;
				}
			}
			array1 = (T[])array2.Clone();
		}

		public static T[] Add<T>(T[] array, T item)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			goto IL_0038;
			IL_0003:
			int num = 1663945412;
			goto IL_0008;
			IL_0008:
			int num3 = default(int);
			T[] array2 = default(T[]);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x632DCAC1)
				{
				case 4:
					break;
				case 0:
					num = 1663945408;
					continue;
				case 3:
					goto IL_0038;
				case 5:
					num3 = 0;
					num = 1663945411;
					continue;
				case 2:
				{
					int num4 = num3 + 1;
					array2 = new T[num4];
					num2 = 0;
					num = 1663945409;
					continue;
				}
				case 6:
					array2[num2] = array[num2];
					num2++;
					num = 1663945408;
					continue;
				default:
					if (num2 >= num3)
					{
						array2[num2] = item;
						return array2;
					}
					goto case 6;
				}
				break;
			}
			goto IL_0003;
			IL_0038:
			num3 = array.Length;
			num = 1663945411;
			goto IL_0008;
		}

		public static T[] AddIfUnique<T>(T[] array, T item)
		{
			if (array != null)
			{
				while (true)
				{
					int num = 1264462915;
					while (true)
					{
						switch (num ^ 0x4B5E2C40)
						{
						case 0:
							break;
						case 3:
							goto IL_0025;
						case 1:
							goto IL_003b;
						default:
							goto end_IL_0003;
						}
						break;
						IL_003b:
						if (!Contains(array, item))
						{
							num = 1264462914;
							continue;
						}
						return array;
						IL_0025:
						int num2;
						if (array.Length == 0)
						{
							num = 1264462914;
							num2 = num;
						}
						else
						{
							num = 1264462913;
							num2 = num;
						}
					}
					continue;
					end_IL_0003:
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
				goto IL_000a;
			}
			goto IL_00de;
			IL_00de:
			int num = default(int);
			int num2;
			if (array == null)
			{
				num = 0;
				num2 = -2040076229;
				goto IL_000f;
			}
			goto IL_014d;
			IL_000a:
			num2 = -2040076227;
			goto IL_000f;
			IL_000f:
			int num3 = default(int);
			T[] array2 = default(T[]);
			int num5 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -2040076236)
				{
				case 4:
					break;
				case 12:
					num3++;
					num2 = -2040076252;
					continue;
				case 11:
					array2[num3] = array[num5];
					num2 = -2040076236;
					continue;
				case 8:
					array2[num3] = array[num3];
					num3++;
					num2 = -2040076233;
					continue;
				case 2:
					goto IL_00a7;
				case 16:
					goto IL_00c5;
				case 9:
					goto IL_00de;
				case 3:
					if (num3 >= index)
					{
						array2[num3] = item;
						num2 = -2040076237;
						continue;
					}
					goto case 8;
				case 7:
					num5 = index;
					num3++;
					num2 = -2040076226;
					continue;
				case 13:
					num2 = -2040076233;
					continue;
				case 0:
					num5++;
					num2 = -2040076232;
					continue;
				case 1:
					array2 = new T[num4];
					num2 = -2040076239;
					continue;
				case 15:
					num2 = -2040076234;
					continue;
				case 6:
					goto IL_014d;
				case 10:
					num2 = -2040076252;
					continue;
				case 5:
					num3 = 0;
					num2 = -2040076231;
					continue;
				default:
					return array2;
				}
				break;
				IL_00c5:
				int num6;
				if (num3 < num4)
				{
					num2 = -2040076225;
					num6 = num2;
				}
				else
				{
					num2 = -2040076230;
					num6 = num2;
				}
				continue;
				IL_00a7:
				int num7 = num - 1;
				if (index > num7)
				{
					return Add(array, item);
				}
				num4 = num + 1;
				num2 = -2040076235;
			}
			goto IL_000a;
			IL_014d:
			num = array.Length;
			num2 = -2040076234;
			goto IL_000f;
		}

		public static T[] RemoveAt<T>(T[] array, int index)
		{
			if (array == null)
			{
				return null;
			}
			if (index < 0)
			{
				index = 0;
				goto IL_000f;
			}
			goto IL_00e2;
			IL_0014:
			int num;
			int num3 = default(int);
			int num5 = default(int);
			T[] array2 = default(T[]);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1370560621)
				{
				case 7:
					break;
				case 3:
					if (num3 >= index)
					{
						num3 = index + 1;
						num = -1370560619;
						continue;
					}
					goto case 5;
				case 2:
				{
					int num4 = num5 - 1;
					array2 = new T[num4];
					num = -1370560613;
					continue;
				}
				case 8:
					num3 = 0;
					num = -1370560617;
					continue;
				case 4:
					num = -1370560624;
					continue;
				case 6:
					goto IL_008b;
				case 1:
					goto IL_00a4;
				case 0:
					array2[num3 - 1] = array[num3];
					num3++;
					num = -1370560619;
					continue;
				case 10:
					goto IL_00e2;
				case 11:
					index = num2;
					num = -1370560623;
					continue;
				case 5:
					array2[num3] = array[num3];
					num3++;
					num = -1370560624;
					continue;
				default:
					return array2;
				}
				break;
				IL_00a4:
				num2 = num5 - 1;
				int num6;
				if (index > num2)
				{
					num = -1370560616;
					num6 = num;
				}
				else
				{
					num = -1370560623;
					num6 = num;
				}
				continue;
				IL_008b:
				int num7;
				if (num3 >= num5)
				{
					num = -1370560614;
					num7 = num;
				}
				else
				{
					num = -1370560621;
					num7 = num;
				}
			}
			goto IL_000f;
			IL_00e2:
			num5 = array.Length;
			num = -1370560622;
			goto IL_0014;
			IL_000f:
			num = -1370560615;
			goto IL_0014;
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
				int num2 = 625004274;
				while (true)
				{
					switch (num2 ^ 0x2540CEF1)
					{
					case 2:
						break;
					case 3:
						num3 = 0;
						num2 = 625004272;
						continue;
					case 0:
						if (EqualityComparer<T>.Default.Equals(array[num3], item))
						{
							return RemoveAt(array, num3);
						}
						num3++;
						num2 = 625004272;
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
			int num6 = default(int);
			int num4 = default(int);
			T[] array3 = default(T[]);
			int num7 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num3 = 837794497;
				while (true)
				{
					switch (num3 ^ 0x31EFBAC9)
					{
					case 5:
						break;
					case 2:
						if (num6 >= num)
						{
							num4 = 0;
							num3 = 837794509;
							continue;
						}
						goto case 7;
					case 3:
						array3 = new T[num7];
						num3 = 837794511;
						continue;
					case 4:
						num3 = 837794504;
						continue;
					case 8:
						num7 = num + num2;
						num3 = 837794506;
						continue;
					case 6:
						num5 = 0;
						num6 = 0;
						num3 = 837794507;
						continue;
					case 0:
						array3[num5++] = array2[num4];
						num4++;
						num3 = 837794504;
						continue;
					case 7:
						array3[num5++] = array1[num6];
						num6++;
						num3 = 837794507;
						continue;
					default:
						if (num4 >= num2)
						{
							return array3;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static int IndexOf<T>(T[] array, T item)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			int num = array.Length;
			int num2 = 0;
			int num3 = -910988286;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num3 ^ -910988282)
				{
				case 0:
					break;
				case 2:
					return -1;
				case 3:
					if (EqualityComparer<T>.Default.Equals(array[num2], item))
					{
						return num2;
					}
					num2++;
					num3 = -910988281;
					continue;
				case 4:
					num3 = -910988281;
					continue;
				default:
					if (num2 >= num)
					{
						return -1;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num3 = -910988284;
			goto IL_0008;
		}

		public static bool Contains<T>(T[] array, T item)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			int num = array.Length;
			int num2 = -2137426533;
			goto IL_0008;
			IL_0008:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -2137426536)
				{
				case 4:
					break;
				case 6:
					if (EqualityComparer<T>.Default.Equals(array[num3], item))
					{
						return true;
					}
					num3++;
					num2 = -2137426534;
					continue;
				case 3:
					num3 = 0;
					num2 = -2137426536;
					continue;
				case 2:
				{
					int num4;
					if (num3 >= num)
					{
						num2 = -2137426531;
						num4 = num2;
					}
					else
					{
						num2 = -2137426530;
						num4 = num2;
					}
					continue;
				}
				case 1:
					return false;
				case 0:
					num2 = -2137426534;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = -2137426535;
			goto IL_0008;
		}

		public static T Find<T>(T[] array, Predicate<T> predicate)
		{
			if (predicate == null)
			{
				goto IL_0003;
			}
			goto IL_0053;
			IL_0003:
			int num = 1755959577;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x68A9D11D)
				{
				case 0:
					break;
				case 2:
					goto IL_0031;
				case 1:
					goto IL_0053;
				case 3:
					goto IL_005d;
				case 5:
					return default(T);
				case 4:
					throw new ArgumentNullException("predicate");
				default:
					return default(T);
				}
				break;
				IL_005d:
				int num4;
				if (num2 < num3)
				{
					num = 1755959583;
					num4 = num;
				}
				else
				{
					num = 1755959579;
					num4 = num;
				}
				continue;
				IL_0031:
				if (predicate(array[num2]))
				{
					return array[num2];
				}
				num2++;
				num = 1755959582;
			}
			goto IL_0003;
			IL_0053:
			if (array == null)
			{
				num = 1755959576;
			}
			else
			{
				num3 = array.Length;
				num2 = 0;
				num = 1755959582;
			}
			goto IL_0008;
		}

		public static bool SubArray<T>(ref T[] array, int startIndex)
		{
			if (array == null)
			{
				return false;
			}
			if (array.Length == 0)
			{
				goto IL_000c;
			}
			int num;
			if (startIndex < 0)
			{
				startIndex = 0;
				num = 861772843;
				goto IL_0011;
			}
			goto IL_005d;
			IL_0011:
			T[] array2 = default(T[]);
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x335D9C2E)
				{
				case 0:
					break;
				case 6:
					array2[num4++] = array[num2];
					num2++;
					num = 861772844;
					continue;
				case 5:
					goto IL_005d;
				case 3:
					return false;
				case 1:
					goto IL_0079;
				case 4:
					num2 = startIndex;
					num = 861772844;
					continue;
				default:
					if (num2 >= num3)
					{
						array = array2;
						return true;
					}
					goto case 6;
				}
				break;
				IL_0079:
				int num5 = num3 - 1;
				if (startIndex >= num5)
				{
					return false;
				}
				int num6 = num3 - startIndex;
				array2 = new T[num6];
				num4 = 0;
				num = 861772842;
			}
			goto IL_000c;
			IL_005d:
			num3 = array.Length;
			num = 861772847;
			goto IL_0011;
			IL_000c:
			num = 861772845;
			goto IL_0011;
		}

		public static bool SubArray<T>(ref T[] array, int startIndex, int count)
		{
			if (array == null)
			{
				return false;
			}
			if (array.Length == 0)
			{
				goto IL_000f;
			}
			if (count <= 0)
			{
				return false;
			}
			int num;
			if (startIndex < 0)
			{
				startIndex = 0;
				num = -1889316743;
				goto IL_0014;
			}
			goto IL_0069;
			IL_0014:
			T[] array2 = default(T[]);
			int num5 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			int num2 = default(int);
			int num6 = default(int);
			while (true)
			{
				switch (num ^ -1889316749)
				{
				case 8:
					break;
				case 1:
					return false;
				case 10:
					goto IL_0069;
				case 5:
					array2 = new T[num5];
					num = -1889316752;
					continue;
				case 0:
					goto IL_0083;
				case 3:
					num3 = startIndex + count - 1;
					num4 = 0;
					num2 = startIndex;
					num = -1889316742;
					continue;
				case 7:
					count = num6 - startIndex;
					num = -1889316747;
					continue;
				case 6:
					num5 = count;
					num = -1889316746;
					continue;
				case 4:
					array2[num4++] = array[num2];
					num2++;
					num = -1889316742;
					continue;
				case 2:
					return false;
				default:
					if (num2 > num3)
					{
						array = array2;
						return true;
					}
					goto case 4;
				}
				break;
				IL_0083:
				if (startIndex < num6 - 1)
				{
					int num7;
					if (count <= num6 - startIndex)
					{
						num = -1889316747;
						num7 = num;
					}
					else
					{
						num = -1889316748;
						num7 = num;
					}
				}
				else
				{
					num = -1889316750;
				}
			}
			goto IL_000f;
			IL_000f:
			num = -1889316751;
			goto IL_0014;
			IL_0069:
			num6 = array.Length;
			num = -1889316749;
			goto IL_0014;
		}

		public static void Expand<T>(ref T[] array, int length)
		{
			if (length <= 0)
			{
				goto IL_0004;
			}
			goto IL_004a;
			IL_0004:
			int num = -1707010894;
			goto IL_0009;
			IL_0009:
			int num2 = default(int);
			T[] array2 = default(T[]);
			while (true)
			{
				switch (num ^ -1707010893)
				{
				case 0:
					break;
				case 1:
					return;
				case 3:
					num2 = array.Length;
					num = -1707010892;
					continue;
				case 5:
					goto IL_004a;
				case 4:
					num2 = 0;
					num = -1707010892;
					continue;
				case 6:
					Array.Copy(array, array2, num2);
					num = -1707010895;
					continue;
				case 7:
					goto IL_0078;
				default:
					array = array2;
					return;
				}
				break;
				IL_0078:
				int num3 = num2 + length;
				array2 = new T[num3];
				int num4;
				if (num2 <= 0)
				{
					num = -1707010895;
					num4 = num;
				}
				else
				{
					num = -1707010891;
					num4 = num;
				}
			}
			goto IL_0004;
			IL_004a:
			int num5;
			if (array != null)
			{
				num = -1707010896;
				num5 = num;
			}
			else
			{
				num = -1707010889;
				num5 = num;
			}
			goto IL_0009;
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
					IL_0039:
					int num2 = 0;
					int num3 = 2045918346;
					while (true)
					{
						switch (num3 ^ 0x79F23C89)
						{
						case 4:
							num3 = 2045918344;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0039;
						case 2:
							array[num2].Trim();
							num2++;
							num3 = 2045918346;
							continue;
						default:
							if (num2 >= num)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
					break;
				}
			}
		}

		public static RaycastHit[] SortNearToFar(RaycastHit[] hits)
		{
			int num = hits.Length;
			int num9 = default(int);
			int num10 = default(int);
			bool flag = default(bool);
			float num6 = default(float);
			float num7 = default(float);
			float[] array3 = default(float[]);
			int num3 = default(int);
			int num4 = default(int);
			RaycastHit[] array = default(RaycastHit[]);
			int num5 = default(int);
			int[] array2 = default(int[]);
			while (true)
			{
				int num2 = 720949020;
				while (true)
				{
					switch (num2 ^ 0x2AF8CF13)
					{
					case 5:
						break;
					case 13:
					{
						int num13;
						if (num9 >= num)
						{
							num2 = 720949016;
							num13 = num2;
						}
						else
						{
							num2 = 720949008;
							num13 = num2;
						}
						continue;
					}
					case 8:
						return null;
					case 18:
					{
						int num11;
						if (num10 < num)
						{
							num2 = 720949009;
							num11 = num2;
						}
						else
						{
							num2 = 720948992;
							num11 = num2;
						}
						continue;
					}
					case 17:
						num9++;
						num2 = 720949022;
						continue;
					case 12:
						if (flag)
						{
							flag = false;
							num2 = 720949011;
							continue;
						}
						goto case 0;
					case 7:
						if (!flag)
						{
							int num8;
							if (num6 >= num7)
							{
								num2 = 720949021;
								num8 = num2;
							}
							else
							{
								num2 = 720949023;
								num8 = num2;
							}
							continue;
						}
						goto case 12;
					case 10:
						num10 = 0;
						num2 = 720948993;
						continue;
					case 6:
					{
						num6 = array3[num3];
						int num12;
						if (!(num6 < 0f))
						{
							num2 = 720949012;
							num12 = num2;
						}
						else
						{
							num2 = 720949021;
							num12 = num2;
						}
						continue;
					}
					case 14:
						num3++;
						num2 = 720949018;
						continue;
					case 4:
						num3 = 0;
						num2 = 720949018;
						continue;
					case 16:
						if (num4 >= num)
						{
							array = new RaycastHit[num];
							num9 = 0;
							num2 = 720949022;
							continue;
						}
						goto case 20;
					case 15:
						if (hits != null)
						{
							if (num != 0)
							{
								array3 = new float[num];
								num2 = 720949010;
							}
							else
							{
								num2 = 720949019;
							}
							continue;
						}
						goto case 8;
					case 19:
						num4 = 0;
						num2 = 720948995;
						continue;
					case 2:
						array3[num10] = hits[num10].distance;
						num10++;
						num2 = 720948993;
						continue;
					case 20:
						flag = true;
						num7 = -1f;
						num5 = -1;
						num2 = 720949015;
						continue;
					case 3:
						array[num9] = hits[array2[num9]];
						num2 = 720948994;
						continue;
					case 0:
						num7 = num6;
						num5 = num3;
						num2 = 720949021;
						continue;
					case 1:
						array2 = new int[num];
						num2 = 720949017;
						continue;
					case 9:
						if (num3 >= num)
						{
							array2[num4] = num5;
							array3[num5] = -1f;
							num4++;
							num2 = 720948995;
							continue;
						}
						goto case 6;
					default:
						return array;
					}
					break;
				}
			}
		}

		public static void MoveEntryUp<T>(T[] array, int index)
		{
			if (array == null)
			{
				return;
			}
			int num4 = default(int);
			T val = default(T);
			while (true)
			{
				int num = array.Length;
				if (num <= 1)
				{
					break;
				}
				while (true)
				{
					IL_0076:
					int num2;
					int num3;
					if (index > 0)
					{
						num2 = -1803822990;
						num3 = num2;
					}
					else
					{
						num2 = -1803822987;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1803822992)
						{
						case 4:
							num2 = -1803822986;
							continue;
						case 6:
							break;
						case 0:
							num4 = index - 1;
							val = array[num4];
							num2 = -1803822989;
							continue;
						case 5:
							return;
						case 2:
							goto IL_0061;
						case 1:
							goto IL_0076;
						case 3:
							array[num4] = array[index];
							num2 = -1803822985;
							continue;
						default:
							array[index] = val;
							return;
						}
						break;
						IL_0061:
						int num5;
						if (index >= num)
						{
							num2 = -1803822987;
							num5 = num2;
						}
						else
						{
							num2 = -1803822992;
							num5 = num2;
						}
					}
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
			int num3 = default(int);
			while (true)
			{
				int num = array.Length;
				int num2 = 1281803073;
				while (true)
				{
					switch (num2 ^ 0x4C66C340)
					{
					case 7:
						num2 = 1281803078;
						continue;
					case 6:
						break;
					case 2:
						return;
					case 5:
						num3 = index + 1;
						num2 = 1281803075;
						continue;
					case 1:
						if (num <= 1)
						{
							return;
						}
						goto case 0;
					case 0:
					{
						int num5;
						if (index >= 0)
						{
							num2 = 1281803076;
							num5 = num2;
						}
						else
						{
							num2 = 1281803074;
							num5 = num2;
						}
						continue;
					}
					case 4:
					{
						int num4;
						if (index >= num - 1)
						{
							num2 = 1281803074;
							num4 = num2;
						}
						else
						{
							num2 = 1281803077;
							num4 = num2;
						}
						continue;
					}
					default:
					{
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
			if (num == 0)
			{
				return;
			}
			while (true)
			{
				T[] array2 = null;
				int num2 = 0;
				int num3 = -613450952;
				while (true)
				{
					switch (num3 ^ -613450950)
					{
					case 0:
						num3 = -613450946;
						continue;
					case 3:
						num2++;
						num3 = -613450952;
						continue;
					case 1:
						if (array[num2] != null)
						{
							Add(ref array2, array[num2]);
							num3 = -613450951;
							continue;
						}
						goto case 3;
					case 4:
						break;
					default:
						if (num2 >= num)
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
				int num2 = 1759443384;
				while (true)
				{
					switch (num2 ^ 0x68DEF9BB)
					{
					case 2:
						break;
					case 3:
						num2 = 1759443386;
						continue;
					case 0:
						if (array[num] == value)
						{
							return num;
						}
						num++;
						num2 = 1759443386;
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
			while (true)
			{
				int num2;
				int num3;
				if (num < array.Length)
				{
					num2 = 1611175568;
					num3 = num2;
				}
				else
				{
					num2 = 1611175570;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x60089692)
					{
					case 3:
						num2 = 1611175568;
						continue;
					case 2:
						if (array[num] == value)
						{
							return num;
						}
						num++;
						num2 = 1611175571;
						continue;
					case 1:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public static int IndexOf(short[] array, short value)
		{
			if (array == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = 387046836;
				while (true)
				{
					switch (num2 ^ 0x1711DDB7)
					{
					case 0:
						break;
					case 3:
						num2 = 387046837;
						continue;
					case 1:
						if (array[num] == value)
						{
							return num;
						}
						num++;
						num2 = 387046837;
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
			}
		}

		public static int IndexOf(ushort[] array, ushort value)
		{
			if (array == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = 144794987;
				while (true)
				{
					switch (num2 ^ 0x8A1656A)
					{
					case 2:
						break;
					case 1:
						num2 = 144794985;
						continue;
					case 0:
						if (array[num] == value)
						{
							return num;
						}
						num++;
						num2 = 144794985;
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

		public static int IndexOf(uint[] array, uint value)
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
					num2 = -204467493;
					num3 = num2;
				}
				else
				{
					num2 = -204467495;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -204467496)
					{
					case 0:
						num2 = -204467493;
						continue;
					case 3:
						if (array[num] == value)
						{
							return num;
						}
						num++;
						num2 = -204467494;
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

		public static int IndexOf(double[] array, double value)
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
				if (num >= array.Length)
				{
					num2 = -1203706013;
					num3 = num2;
				}
				else
				{
					num2 = -1203706014;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1203706016)
					{
					case 4:
						num2 = -1203706014;
						continue;
					case 0:
						break;
					case 1:
						return num;
					case 2:
						if (array[num] != value)
						{
							num++;
							num2 = -1203706016;
						}
						else
						{
							num2 = -1203706015;
						}
						continue;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public static int IndexOf(bool[] array, bool value)
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
					int num2 = 559107821;
					while (true)
					{
						switch (num2 ^ 0x21534EED)
						{
						case 2:
							num2 = 559107820;
							continue;
						case 1:
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
					num2 = 149049914;
					num3 = num2;
				}
				else
				{
					num2 = 149049913;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x8E2523B)
					{
					case 3:
						num2 = 149049914;
						continue;
					case 0:
						break;
					case 4:
						return num;
					case 1:
						if (!(array[num] == value))
						{
							num++;
							num2 = 149049915;
						}
						else
						{
							num2 = 149049919;
						}
						continue;
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
			int num2 = -346041656;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ -346041656)
				{
				case 2:
					break;
				case 3:
					if (array[num].Equals(value, stringComparison))
					{
						return num;
					}
					num++;
					num2 = -346041651;
					continue;
				case 5:
				{
					int num3;
					if (num >= array.Length)
					{
						num2 = -346041652;
						num3 = num2;
					}
					else
					{
						num2 = -346041653;
						num3 = num2;
					}
					continue;
				}
				case 1:
					return -1;
				case 0:
					num2 = -346041651;
					continue;
				default:
					return -1;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = -346041655;
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
				int num2 = -1359320070;
				while (true)
				{
					switch (num2 ^ -1359320069)
					{
					case 2:
						num2 = -1359320072;
						continue;
					case 3:
						break;
					case 0:
						array[num] = value;
						num++;
						num2 = -1359320070;
						continue;
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
				goto IL_0003;
			}
			goto IL_0067;
			IL_0003:
			int num = 725788452;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x2B42A727)
				{
				case 6:
					break;
				case 4:
					goto IL_0031;
				case 5:
					array[num2] = value;
					num2++;
					num = 725788455;
					continue;
				case 3:
					return;
				case 2:
					num2 = startIndex;
					num = 725788455;
					continue;
				case 1:
					goto IL_0067;
				default:
					if (num2 >= array.Length)
					{
						return;
					}
					goto case 5;
				}
				break;
			}
			goto IL_0003;
			IL_0067:
			if (startIndex >= 0)
			{
				int num3;
				if (startIndex < array.Length)
				{
					num = 725788453;
					num3 = num;
				}
				else
				{
					num = 725788451;
					num3 = num;
				}
				goto IL_0008;
			}
			goto IL_0031;
			IL_0031:
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public static void Fill<T>(T[] array, T value, int startIndex, int length)
		{
			if (array == null)
			{
				goto IL_0006;
			}
			goto IL_0095;
			IL_0006:
			int num = 1704432079;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x659791C7)
				{
				case 3:
					break;
				default:
					return;
				case 4:
					goto IL_0043;
				case 1:
					throw new ArgumentOutOfRangeException("startIndex");
				case 8:
					return;
				case 9:
					length = MathTools.Clamp(startIndex + length, 0, array.Length);
					num = 1704432069;
					continue;
				case 2:
					num2 = startIndex;
					num = 1704432067;
					continue;
				case 7:
					goto IL_0095;
				case 0:
					goto IL_00ad;
				case 5:
					array[num2] = value;
					num2++;
					num = 1704432067;
					continue;
				case 6:
					return;
				}
				break;
				IL_00ad:
				int num3;
				if (startIndex >= array.Length)
				{
					num = 1704432070;
					num3 = num;
				}
				else
				{
					num = 1704432078;
					num3 = num;
				}
				continue;
				IL_0043:
				int num4;
				if (num2 >= array.Length)
				{
					num = 1704432065;
					num4 = num;
				}
				else
				{
					num = 1704432066;
					num4 = num;
				}
			}
			goto IL_0006;
			IL_0095:
			int num5;
			if (startIndex < 0)
			{
				num = 1704432070;
				num5 = num;
			}
			else
			{
				num = 1704432071;
				num5 = num;
			}
			goto IL_000b;
		}

		public static void Populate<T>(T[] array, int startIndex, int length, Func<T> instantiator)
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
				if (length <= 0)
				{
					num = -475834524;
					num2 = num;
				}
				else
				{
					num = -475834514;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -475834513)
					{
					case 4:
						num = -475834516;
						continue;
					case 7:
						throw new ArgumentOutOfRangeException("startIndex must be < length");
					case 8:
					{
						int num5;
						if (startIndex < length)
						{
							num = -475834513;
							num5 = num;
						}
						else
						{
							num = -475834520;
							num5 = num;
						}
						continue;
					}
					case 12:
						num3++;
						num = -475834522;
						continue;
					case 11:
						return;
					case 6:
						array[num3] = instantiator();
						num = -475834525;
						continue;
					case 3:
						break;
					case 0:
						if (length > array.Length)
						{
							throw new ArgumentOutOfRangeException("length must be <= array.Length");
						}
						goto case 5;
					case 1:
					{
						int num4;
						if (startIndex >= 0)
						{
							num = -475834521;
							num4 = num;
						}
						else
						{
							num = -475834523;
							num4 = num;
						}
						continue;
					}
					case 10:
						throw new ArgumentOutOfRangeException("startIndex must be >= 0");
					case 2:
						num3 = startIndex;
						num = -475834522;
						continue;
					case 5:
						if (startIndex + length > array.Length)
						{
							throw new ArgumentOutOfRangeException("startIndex + length must be <= array.Length");
						}
						goto case 2;
					default:
						if (num3 >= startIndex + length)
						{
							return;
						}
						goto case 6;
					}
					break;
				}
			}
		}

		public static void Populate<T>(T[] array, int startIndex, int length) where T : class, new()
		{
			if (array == null)
			{
				goto IL_0006;
			}
			goto IL_013a;
			IL_0006:
			int num = 1907341303;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x71AFB7F0)
				{
				case 12:
					break;
				default:
					return;
				case 10:
					goto IL_005b;
				case 8:
					goto IL_0072;
				case 13:
					array[num2] = new T();
					num = 1907341310;
					continue;
				case 1:
					return;
				case 9:
					throw new ArgumentOutOfRangeException("startIndex must be < length");
				case 4:
					num2 = startIndex;
					num = 1907341302;
					continue;
				case 7:
					throw new ArgumentNullException("array");
				case 5:
					throw new ArgumentOutOfRangeException("length must be <= array.Length");
				case 14:
					num2++;
					num = 1907341306;
					continue;
				case 0:
					if (startIndex + length > array.Length)
					{
						throw new ArgumentOutOfRangeException("startIndex + length must be <= array.Length");
					}
					goto case 4;
				case 11:
					if (startIndex < 0)
					{
						throw new ArgumentOutOfRangeException("startIndex must be >= 0");
					}
					goto IL_0072;
				case 2:
					goto IL_013a;
				case 6:
					num = 1907341306;
					continue;
				case 15:
					goto IL_015c;
				case 3:
					return;
				}
				break;
				IL_015c:
				int num3;
				if (length > array.Length)
				{
					num = 1907341301;
					num3 = num;
				}
				else
				{
					num = 1907341296;
					num3 = num;
				}
				continue;
				IL_0072:
				int num4;
				if (startIndex >= length)
				{
					num = 1907341305;
					num4 = num;
				}
				else
				{
					num = 1907341311;
					num4 = num;
				}
				continue;
				IL_005b:
				int num5;
				if (num2 < startIndex + length)
				{
					num = 1907341309;
					num5 = num;
				}
				else
				{
					num = 1907341299;
					num5 = num;
				}
			}
			goto IL_0006;
			IL_013a:
			int num6;
			if (length <= 0)
			{
				num = 1907341297;
				num6 = num;
			}
			else
			{
				num = 1907341307;
				num6 = num;
			}
			goto IL_000b;
		}

		public static void Populate<T>(T[] array) where T : class, new()
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			Populate(array, 0, array.Length);
		}

		public static void Populate<T>(T[] array, Func<T> instantiator)
		{
			if (array == null)
			{
				while (true)
				{
					switch (-653086201 ^ -653086203)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("array");
					}
					break;
				}
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
				int num3 = -805370900;
				while (true)
				{
					switch (num3 ^ -805370898)
					{
					case 0:
						num3 = -805370897;
						continue;
					case 4:
						if (predicate(array[num2]))
						{
							num++;
							num3 = -805370899;
							continue;
						}
						goto case 3;
					case 3:
						num2++;
						num3 = -805370901;
						continue;
					case 1:
						break;
					case 2:
						num3 = -805370901;
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
				int num2 = 521009397;
				while (true)
				{
					switch (num2 ^ 0x1F0DF8F7)
					{
					case 3:
						break;
					case 2:
						num2 = 521009399;
						continue;
					case 1:
						if (a1[num] != a2[num])
						{
							num2 = 521009395;
							continue;
						}
						num++;
						num2 = 521009399;
						continue;
					case 4:
						return false;
					default:
						if (num >= a1.Length)
						{
							return true;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public static bool Contains(string[] array, string item, bool ignoreCase)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			int num = array.Length;
			int num2 = 0;
			int num3 = 262544013;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num3 ^ 0xFA61A8F)
				{
				case 0:
					break;
				case 4:
					return false;
				case 1:
					if (ignoreCase)
					{
						num3 = 262544010;
						continue;
					}
					if (array[num2] == item)
					{
						num3 = 262544012;
						continue;
					}
					goto IL_0068;
				case 5:
					if (array[num2].Equals(item, StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
					goto IL_0068;
				case 3:
					return true;
				default:
					{
						if (num2 >= num)
						{
							return false;
						}
						goto case 1;
					}
					IL_0068:
					num2++;
					num3 = 262544013;
					continue;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num3 = 262544011;
			goto IL_0008;
		}

		public static int AddIfUnique(ref string[] array, string item, bool ignoreCase)
		{
			if (array == null || array.Length == 0 || !Contains(array, item, ignoreCase))
			{
				return Add(ref array, item);
			}
			return -1;
		}

		public static void RemoveDuplicates(ref string[] array, bool ignoreCase)
		{
			int num = ((array != null) ? array.Length : 0);
			string[] array2 = default(string[]);
			int num3 = default(int);
			while (true)
			{
				int num2 = -1420519838;
				while (true)
				{
					switch (num2 ^ -1420519840)
					{
					case 6:
						break;
					case 2:
					{
						int num4;
						if (num != 0)
						{
							num2 = -1420519836;
							num4 = num2;
						}
						else
						{
							num2 = -1420519837;
							num4 = num2;
						}
						continue;
					}
					case 4:
						array2 = null;
						num2 = -1420519839;
						continue;
					case 7:
						AddIfUnique(ref array2, array[num3], ignoreCase);
						num2 = -1420519840;
						continue;
					case 3:
						return;
					case 1:
						num3 = 0;
						num2 = -1420519835;
						continue;
					case 0:
						num3++;
						num2 = -1420519835;
						continue;
					default:
						if (num3 >= num)
						{
							array = array2;
							return;
						}
						goto case 7;
					}
					break;
				}
			}
		}

		public static bool Remove(ref string[] array, string item, bool ignoreCase)
		{
			if (array == null)
			{
				return false;
			}
			int num = array.Length;
			int num3 = default(int);
			int num6 = default(int);
			while (true)
			{
				int num2 = -815444018;
				while (true)
				{
					switch (num2 ^ -815444032)
					{
					case 4:
						break;
					case 5:
					{
						int num5;
						if (num3 < num)
						{
							num2 = -815444020;
							num5 = num2;
						}
						else
						{
							num2 = -815444021;
							num5 = num2;
						}
						continue;
					}
					case 12:
						if (ignoreCase)
						{
							num2 = -815444023;
							continue;
						}
						if (array[num3] == item)
						{
							num2 = -815444022;
							continue;
						}
						goto IL_008e;
					case 8:
						num6 = 0;
						num2 = -815444032;
						continue;
					case 10:
						RemoveAt(ref array, num3);
						return true;
					case 1:
						if (array[num6] == null)
						{
							RemoveAt(ref array, num6);
							num2 = -815444019;
						}
						else
						{
							num6++;
							num2 = -815444032;
						}
						continue;
					case 2:
						RemoveAt(ref array, num3);
						return true;
					case 13:
						return true;
					case 3:
						if (array[num3].Equals(item, StringComparison.OrdinalIgnoreCase))
						{
							num2 = -815444030;
							continue;
						}
						goto IL_008e;
					case 6:
						num2 = -815444027;
						continue;
					case 0:
						if (num6 >= num)
						{
							num2 = -815444021;
							continue;
						}
						goto case 1;
					case 9:
						if (array[num3] != null)
						{
							num2 = -815444029;
							continue;
						}
						goto IL_008e;
					case 14:
					{
						int num4;
						if (item == null)
						{
							num2 = -815444024;
							num4 = num2;
						}
						else
						{
							num2 = -815444025;
							num4 = num2;
						}
						continue;
					}
					case 7:
						num3 = 0;
						num2 = -815444026;
						continue;
					default:
						{
							return false;
						}
						IL_008e:
						num3++;
						num2 = -815444027;
						continue;
					}
					break;
				}
			}
		}

		public static string[] ToLowerStripSpaces(string[] array)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			if (array.Length == 0)
			{
				return null;
			}
			string[] array2 = new string[array.Length];
			int num = 0;
			int num2 = -1596314095;
			goto IL_0008;
			IL_0003:
			num2 = -1596314094;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ -1596314095)
				{
				case 2:
					break;
				case 1:
					num++;
					num2 = -1596314095;
					continue;
				case 4:
					if (array[num] != null)
					{
						array2[num] = array[num].ToLower().Replace(" ", "");
						num2 = -1596314096;
						continue;
					}
					goto case 1;
				case 3:
					return null;
				default:
					if (num >= array.Length)
					{
						return array2;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0003;
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
					num = -1451926565;
					num2 = num;
				}
				else
				{
					num = -1451926573;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1451926574)
					{
					case 4:
						num = -1451926568;
						continue;
					case 3:
						break;
					case 9:
						goto end_IL_0112;
					case 5:
						goto IL_007e;
					case 7:
						num3++;
						num = -1451926567;
						continue;
					case 8:
						throw new ArgumentOutOfRangeException("count must be <= 32");
					case 0:
						throw new ArgumentOutOfRangeException("count");
					case 2:
						num4 = 0;
						num3 = 0;
						num = -1451926567;
						continue;
					case 6:
						if (array[num3])
						{
							num4 |= 1 << num3;
							num = -1451926571;
							continue;
						}
						goto case 7;
					case 1:
						goto IL_00fa;
					case 10:
						goto end_IL_0016;
					default:
						if (num3 >= array.Length)
						{
							return num4;
						}
						goto case 6;
					}
					int num5;
					if (count <= 32)
					{
						num = -1451926576;
						num5 = num;
					}
					else
					{
						num = -1451926566;
						num5 = num;
					}
					continue;
					IL_00fa:
					int num6;
					if (count > 0)
					{
						num = -1451926569;
						num6 = num;
					}
					else
					{
						num = -1451926574;
						num6 = num;
					}
					continue;
					IL_007e:
					int num7;
					if (startIndex + count <= array.Length + 1)
					{
						num = -1451926575;
						num7 = num;
					}
					else
					{
						num = -1451926574;
						num7 = num;
					}
					continue;
					end_IL_0016:
					break;
				}
				continue;
				end_IL_0112:
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
				int num2 = 1752308557;
				while (true)
				{
					switch (num2 ^ 0x68721B4F)
					{
					case 3:
						break;
					case 2:
						num2 = 1752308559;
						continue;
					case 1:
						if (array[num] != null)
						{
							return false;
						}
						num++;
						num2 = 1752308559;
						continue;
					default:
						if (num >= array.Length)
						{
							return true;
						}
						goto case 1;
					}
					break;
				}
			}
		}
	}
}
