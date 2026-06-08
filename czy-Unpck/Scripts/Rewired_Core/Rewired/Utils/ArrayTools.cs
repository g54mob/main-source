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
						int num2 = -863152478;
						while (true)
						{
							switch (num2 ^ -863152477)
							{
							case 0:
								num2 = -863152479;
								continue;
							case 2:
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
				if (enumerator is IDisposable disposable)
				{
					while (true)
					{
						IL_007c:
						int num3 = -863152479;
						while (true)
						{
							switch (num3 ^ -863152477)
							{
							case 0:
								break;
							default:
								goto end_IL_0081;
							case 2:
								goto IL_009a;
							case 1:
								goto end_IL_0081;
							}
							goto IL_007c;
							IL_009a:
							disposable.Dispose();
							num3 = -863152478;
							continue;
							end_IL_0081:
							break;
						}
						break;
					}
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
					num2 = 1585196914;
					num3 = num2;
				}
				else
				{
					num2 = 1585196918;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x5E7C2F73)
					{
					case 2:
						num2 = 1585196914;
						continue;
					case 3:
						num++;
						num2 = 1585196915;
						continue;
					case 0:
						break;
					case 1:
					{
						int num4;
						if (array[num] == null)
						{
							num2 = 1585196912;
							num4 = num2;
						}
						else
						{
							num2 = 1585196919;
							num4 = num2;
						}
						continue;
					}
					case 4:
						array2[num] = array[num].DeepClone() as T;
						num2 = 1585196912;
						continue;
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
			while (true)
			{
				int num;
				int num2;
				if (targetArray == null)
				{
					num = 1510206932;
					num2 = num;
				}
				else
				{
					num = 1510206935;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x5A03EDD7)
					{
					case 2:
						goto IL_0004;
					case 1:
						break;
					case 3:
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
					num = 1510206934;
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
					int num = -815286946;
					while (true)
					{
						switch (num ^ -815286947)
						{
						case 0:
							num = -815286948;
							continue;
						case 1:
							break;
						case 2:
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
			byte[] array = default(byte[]);
			int num = default(int);
			int num2;
			if (inArray != null && length >= 1)
			{
				if (startPos < 0)
				{
					goto IL_000b;
				}
				array = new byte[length];
				num = 0;
				num2 = -704606920;
				goto IL_0010;
			}
			goto IL_002d;
			IL_000b:
			num2 = -704606919;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num2 ^ -704606918)
				{
				case 0:
					break;
				case 3:
					goto IL_002d;
				case 1:
					array[num] = inArray[startPos + num];
					num++;
					num2 = -704606920;
					continue;
				default:
					if (num >= length)
					{
						return array;
					}
					goto case 1;
				}
				break;
			}
			goto IL_000b;
			IL_002d:
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
					int num = 555666049;
					while (true)
					{
						switch (num ^ 0x211ECA82)
						{
						case 4:
							break;
						case 1:
							array[num2] = inArray[startPos + num2];
							num = 555666055;
							continue;
						case 6:
							goto end_IL_0007;
						case 2:
							goto IL_0056;
						case 5:
							num2++;
							num = 555666048;
							continue;
						case 3:
							goto IL_0076;
						default:
							return array;
						}
						break;
						IL_0076:
						if (startPos >= 0)
						{
							array = new int[length];
							num2 = 0;
							num = 555666048;
						}
						else
						{
							num = 555666052;
						}
						continue;
						IL_0056:
						int num3;
						if (num2 >= length)
						{
							num = 555666050;
							num3 = num;
						}
						else
						{
							num = 555666051;
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
			if (inArray != null)
			{
				int num2 = default(int);
				float[] array = default(float[]);
				while (true)
				{
					int num = -1923572813;
					while (true)
					{
						switch (num ^ -1923572814)
						{
						case 7:
							break;
						case 0:
							num2 = 0;
							num = -1923572809;
							continue;
						case 2:
							goto end_IL_0003;
						case 4:
							array[num2] = inArray[startPos + num2];
							num2++;
							num = -1923572812;
							continue;
						case 5:
							num = -1923572812;
							continue;
						case 6:
							goto IL_006c;
						case 8:
							goto IL_0081;
						case 1:
							goto IL_008f;
						default:
							return array;
						}
						break;
						IL_008f:
						int num3;
						if (length < 1)
						{
							num = -1923572816;
							num3 = num;
						}
						else
						{
							num = -1923572806;
							num3 = num;
						}
						continue;
						IL_0081:
						if (startPos >= 0)
						{
							array = new float[length];
							num = -1923572814;
						}
						else
						{
							num = -1923572816;
						}
						continue;
						IL_006c:
						int num4;
						if (num2 < length)
						{
							num = -1923572810;
							num4 = num;
						}
						else
						{
							num = -1923572815;
							num4 = num;
						}
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return null;
		}

		public static string[] CopyRange(string[] inArray, int startPos, int length)
		{
			string[] array = default(string[]);
			int num = default(int);
			int num2;
			if (inArray != null && length >= 1)
			{
				if (startPos < 0)
				{
					goto IL_000b;
				}
				array = new string[length];
				num = 0;
				num2 = -319343895;
				goto IL_0010;
			}
			goto IL_002d;
			IL_000b:
			num2 = -319343893;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num2 ^ -319343896)
				{
				case 2:
					break;
				case 3:
					goto IL_002d;
				case 0:
					array[num] = inArray[startPos + num];
					num++;
					num2 = -319343895;
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

		public static byte[] Combine(byte[] inArray1, byte[] inArray2)
		{
			byte[] array = null;
			int num;
			if (inArray1 == null)
			{
				num = 0;
				goto IL_0007;
			}
			goto IL_0072;
			IL_0072:
			num = inArray1.Length;
			int num2 = -1569758993;
			goto IL_000c;
			IL_0007:
			num2 = -1569758994;
			goto IL_000c;
			IL_000c:
			int num4 = default(int);
			int num6 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -1569758997)
				{
				case 8:
					break;
				case 5:
					num2 = -1569758993;
					continue;
				case 14:
					num2 = -1569759002;
					continue;
				case 4:
					if (inArray2 == null)
					{
						num4 = 0;
						num2 = -1569758999;
						continue;
					}
					goto case 6;
				case 7:
					goto IL_0072;
				case 11:
					num6++;
					num2 = -1569758998;
					continue;
				case 1:
					num5++;
					num2 = -1569759002;
					continue;
				case 6:
					num4 = inArray2.Length;
					num2 = -1569758999;
					continue;
				case 2:
					goto IL_00a6;
				case 9:
					array[num6] = inArray2[num3];
					num6++;
					num2 = -1569759000;
					continue;
				case 0:
					array[num6] = inArray1[num5];
					num2 = -1569759008;
					continue;
				case 13:
					if (num5 >= num)
					{
						num3 = 0;
						num2 = -1569759001;
						continue;
					}
					goto case 0;
				case 3:
					num3++;
					num2 = -1569759001;
					continue;
				case 10:
					goto IL_00fb;
				default:
					if (num3 >= num4)
					{
						return array;
					}
					goto case 9;
				}
				break;
				IL_00fb:
				if (num4 == 0)
				{
					return array;
				}
				goto IL_0100;
				IL_0100:
				array = new byte[num + num4];
				num6 = 0;
				num5 = 0;
				num2 = -1569759003;
				continue;
				IL_00a6:
				if (num == 0)
				{
					num2 = -1569759007;
					continue;
				}
				goto IL_0100;
			}
			goto IL_0007;
		}

		public static int[] Combine(int[] inArray1, int[] inArray2)
		{
			int[] array = null;
			if (inArray1 != null)
			{
				goto IL_00ae;
			}
			int num = 0;
			goto IL_00ee;
			IL_0093:
			int num2 = inArray2.Length;
			int num3 = -598813139;
			goto IL_0014;
			IL_00ee:
			if (inArray2 == null)
			{
				num2 = 0;
				num3 = -598813139;
				goto IL_0014;
			}
			goto IL_0093;
			IL_00ae:
			num = inArray1.Length;
			num3 = -598813138;
			goto IL_0014;
			IL_0014:
			int num4 = default(int);
			int num5 = default(int);
			int num6 = default(int);
			while (true)
			{
				switch (num3 ^ -598813139)
				{
				case 4:
					num3 = -598813149;
					continue;
				case 7:
					array[num4] = inArray1[num5];
					num3 = -598813147;
					continue;
				case 0:
					break;
				case 5:
					num5++;
					num3 = -598813137;
					continue;
				case 11:
					goto end_IL_0014;
				case 9:
					num6 = 0;
					num3 = -598813145;
					continue;
				case 14:
					goto IL_00ae;
				case 10:
					goto IL_00bc;
				case 2:
					goto IL_00d5;
				case 3:
					goto IL_00ee;
				case 8:
					num4++;
					num3 = -598813144;
					continue;
				case 13:
					array[num4] = inArray2[num6];
					num4++;
					num6++;
					num3 = -598813145;
					continue;
				case 1:
					num3 = -598813137;
					continue;
				case 12:
					num4 = 0;
					num5 = 0;
					num3 = -598813140;
					continue;
				default:
					return array;
				}
				if (num == 0 && num2 == 0)
				{
					return array;
				}
				array = new int[num + num2];
				num3 = -598813151;
				continue;
				IL_00d5:
				int num7;
				if (num5 >= num)
				{
					num3 = -598813148;
					num7 = num3;
				}
				else
				{
					num3 = -598813142;
					num7 = num3;
				}
				continue;
				IL_00bc:
				int num8;
				if (num6 >= num2)
				{
					num3 = -598813141;
					num8 = num3;
				}
				else
				{
					num3 = -598813152;
					num8 = num3;
				}
				continue;
				end_IL_0014:
				break;
			}
			goto IL_0093;
		}

		public static float[] Combine(float[] inArray1, float[] inArray2)
		{
			float[] array = null;
			int num;
			if (inArray1 == null)
			{
				num = 0;
				goto IL_0007;
			}
			goto IL_0061;
			IL_0061:
			num = inArray1.Length;
			int num2 = -995464432;
			goto IL_000c;
			IL_0007:
			num2 = -995464417;
			goto IL_000c;
			IL_000c:
			int num5 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			int num6 = default(int);
			while (true)
			{
				switch (num2 ^ -995464420)
				{
				case 9:
					break;
				case 7:
					num5++;
					num3++;
					num2 = -995464424;
					continue;
				case 5:
					goto IL_0061;
				case 12:
					if (inArray2 == null)
					{
						num4 = 0;
						num2 = -995464419;
						continue;
					}
					goto case 10;
				case 11:
					num2 = -995464424;
					continue;
				case 3:
					num2 = -995464432;
					continue;
				case 6:
					array[num5] = inArray1[num6];
					num5++;
					num6++;
					num2 = -995464418;
					continue;
				case 8:
					array[num5] = inArray2[num3];
					num2 = -995464421;
					continue;
				case 1:
					goto IL_00b2;
				case 10:
					num4 = inArray2.Length;
					num2 = -995464419;
					continue;
				case 2:
					if (num6 >= num)
					{
						num3 = 0;
						num2 = -995464425;
						continue;
					}
					goto case 6;
				case 0:
					num6 = 0;
					num2 = -995464418;
					continue;
				default:
					if (num3 >= num4)
					{
						return array;
					}
					goto case 8;
				}
				break;
				IL_00b2:
				if (num == 0 && num4 == 0)
				{
					return array;
				}
				array = new float[num + num4];
				num5 = 0;
				num2 = -995464420;
			}
			goto IL_0007;
		}

		public static string[] Combine(string[] inArray1, string[] inArray2)
		{
			string[] array = null;
			int num;
			if (inArray1 == null)
			{
				num = 0;
				goto IL_0091;
			}
			goto IL_0137;
			IL_0014:
			int num2;
			int num5 = default(int);
			int num6 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -2138488518)
				{
				case 6:
					num2 = -2138488523;
					continue;
				case 3:
					num5++;
					num6++;
					num2 = -2138488524;
					continue;
				case 8:
					break;
				case 4:
					num2 = -2138488520;
					continue;
				case 1:
					num4 = inArray2.Length;
					num2 = -2138488526;
					continue;
				case 10:
					goto end_IL_0014;
				case 11:
					num3++;
					num2 = -2138488520;
					continue;
				case 14:
					goto IL_00b8;
				case 7:
					array[num5] = inArray1[num6];
					num2 = -2138488519;
					continue;
				case 9:
					num5 = 0;
					num6 = 0;
					num2 = -2138488524;
					continue;
				case 13:
					goto IL_00f1;
				case 12:
					num3 = 0;
					num2 = -2138488514;
					continue;
				case 5:
					array[num5] = inArray2[num3];
					num5++;
					num2 = -2138488527;
					continue;
				case 0:
					num4 = 0;
					num2 = -2138488526;
					continue;
				case 15:
					goto IL_0137;
				default:
					if (num3 >= num4)
					{
						return array;
					}
					goto case 5;
				}
				if (num == 0)
				{
					num2 = -2138488521;
					continue;
				}
				goto IL_00f6;
				IL_00f1:
				if (num4 == 0)
				{
					return array;
				}
				goto IL_00f6;
				IL_00f6:
				array = new string[num + num4];
				num2 = -2138488525;
				continue;
				IL_00b8:
				int num7;
				if (num6 < num)
				{
					num2 = -2138488515;
					num7 = num2;
				}
				else
				{
					num2 = -2138488522;
					num7 = num2;
				}
				continue;
				end_IL_0014:
				break;
			}
			goto IL_0091;
			IL_0091:
			int num8;
			if (inArray2 != null)
			{
				num2 = -2138488517;
				num8 = num2;
			}
			else
			{
				num2 = -2138488518;
				num8 = num2;
			}
			goto IL_0014;
			IL_0137:
			num = inArray1.Length;
			num2 = -2138488528;
			goto IL_0014;
		}

		public static T[] ParseArray<T>(string line)
		{
			line = line.Replace("{", "");
			line = line.Replace("}", "");
			string[] array2 = default(string[]);
			int num2 = default(int);
			T[] array = default(T[]);
			int num3 = default(int);
			while (true)
			{
				int num = -1898183162;
				while (true)
				{
					switch (num ^ -1898183161)
					{
					case 5:
						break;
					case 1:
						array2 = line.Split(',');
						num = -1898183163;
						continue;
					case 4:
					{
						string value = array2[num2].Trim();
						array[num2] = (T)Convert.ChangeType(value, typeof(T));
						num2++;
						num = -1898183161;
						continue;
					}
					case 3:
						return null;
					case 2:
						num3 = array2.Length;
						array = new T[num3];
						if (num3 == 1)
						{
							string text = array2[0].Trim().ToLower();
							if (text == "")
							{
								goto case 3;
							}
							if (text == "null")
							{
								num = -1898183164;
								continue;
							}
						}
						num2 = 0;
						num = -1898183161;
						continue;
					default:
						if (num2 >= num3)
						{
							return array;
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
				goto IL_000f;
			}
			int num2;
			T[] array2 = default(T[]);
			bool[] array3 = default(bool[]);
			int num3 = default(int);
			if (num == 1)
			{
				num2 = -1833112302;
			}
			else
			{
				array2 = new T[num];
				sortedIndices = new int[num];
				array3 = new bool[num];
				num3 = 0;
				num2 = -1833112292;
			}
			goto IL_0014;
			IL_0014:
			T val2 = default(T);
			int num4 = default(int);
			int num5 = default(int);
			T val = default(T);
			while (true)
			{
				switch (num2 ^ -1833112300)
				{
				case 13:
					break;
				case 10:
				{
					val2 = array[num4];
					int num8;
					if (num5 == -1)
					{
						num2 = -1833112289;
						num8 = num2;
					}
					else
					{
						num2 = -1833112297;
						num8 = num2;
					}
					continue;
				}
				case 5:
					return array;
				case 6:
				{
					int[] array4 = new int[1];
					sortedIndices = array4;
					return array;
				}
				case 0:
					sortedIndices[num3] = num5;
					num2 = -1833112301;
					continue;
				case 12:
					sortedIndices = new int[0];
					num2 = -1833112303;
					continue;
				case 15:
					num4++;
					num2 = -1833112291;
					continue;
				case 4:
					num2 = -1833112291;
					continue;
				case 3:
				{
					int num7;
					if (val2.CompareTo(val) >= 0)
					{
						num2 = -1833112293;
						num7 = num2;
					}
					else
					{
						num2 = -1833112289;
						num7 = num2;
					}
					continue;
				}
				case 1:
				{
					int num6;
					if (!array3[num4])
					{
						num2 = -1833112290;
						num6 = num2;
					}
					else
					{
						num2 = -1833112293;
						num6 = num2;
					}
					continue;
				}
				case 11:
					val = val2;
					num5 = num4;
					num2 = -1833112293;
					continue;
				case 7:
					array3[num5] = true;
					num3++;
					num2 = -1833112292;
					continue;
				case 9:
					if (num4 >= num)
					{
						array2[num3] = val;
						num2 = -1833112300;
						continue;
					}
					goto case 1;
				case 2:
					val = default(T);
					num5 = -1;
					num2 = -1833112294;
					continue;
				case 14:
					num4 = 0;
					num2 = -1833112304;
					continue;
				default:
					if (num3 >= num)
					{
						return array2;
					}
					goto case 2;
				}
				break;
			}
			goto IL_000f;
			IL_000f:
			num2 = -1833112296;
			goto IL_0014;
		}

		public static T[] SortDescending<T>(T[] array, out int[] sortedIndices, bool ascending = true) where T : IComparable<T>
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
			T[] array2 = default(T[]);
			int num2;
			if (num != 1)
			{
				array2 = new T[num];
				num2 = -1379271949;
			}
			else
			{
				num2 = -1379271956;
			}
			goto IL_000e;
			IL_0009:
			num2 = -1379271937;
			goto IL_000e;
			IL_000e:
			T val = default(T);
			T val2 = default(T);
			int num3 = default(int);
			int num5 = default(int);
			bool[] array3 = default(bool[]);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -1379271939)
				{
				case 13:
					break;
				case 10:
					val = val2;
					num3 = num5;
					num2 = -1379271942;
					continue;
				case 17:
				{
					int[] array4 = new int[1];
					sortedIndices = array4;
					return array;
				}
				case 3:
				{
					int num8;
					if (!array3[num5])
					{
						num2 = -1379271943;
						num8 = num2;
					}
					else
					{
						num2 = -1379271942;
						num8 = num2;
					}
					continue;
				}
				case 9:
				{
					int num6;
					if (num4 < num)
					{
						num2 = -1379271939;
						num6 = num2;
					}
					else
					{
						num2 = -1379271950;
						num6 = num2;
					}
					continue;
				}
				case 5:
					sortedIndices[num4] = num3;
					num2 = -1379271947;
					continue;
				case 7:
					num5++;
					num2 = -1379271946;
					continue;
				case 6:
					array3 = new bool[num];
					num4 = 0;
					num2 = -1379271951;
					continue;
				case 16:
					num3 = -1;
					num5 = 0;
					num2 = -1379271940;
					continue;
				case 4:
					val2 = array[num5];
					if (num3 != -1)
					{
						int num7;
						if (val2.CompareTo(val) >= 0)
						{
							num2 = -1379271942;
							num7 = num2;
						}
						else
						{
							num2 = -1379271945;
							num7 = num2;
						}
						continue;
					}
					goto case 10;
				case 11:
					if (num5 >= num)
					{
						array2[num4] = val;
						num2 = -1379271944;
						continue;
					}
					goto case 3;
				case 0:
					val = default(T);
					num2 = -1379271955;
					continue;
				case 2:
					return null;
				case 1:
					num2 = -1379271946;
					continue;
				case 12:
					num2 = -1379271948;
					continue;
				case 8:
					array3[num3] = true;
					num4++;
					num2 = -1379271948;
					continue;
				case 14:
					sortedIndices = new int[num];
					num2 = -1379271941;
					continue;
				default:
					return array2;
				}
				break;
			}
			goto IL_0009;
		}

		public static int Add<T>(ref T[] array, T item)
		{
			int num;
			if (array == null)
			{
				num = 0;
				goto IL_0006;
			}
			goto IL_0048;
			IL_0048:
			num = array.Length;
			int num2 = -1885259067;
			goto IL_000b;
			IL_0006:
			num2 = -1885259072;
			goto IL_000b;
			IL_000b:
			T[] array2 = default(T[]);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -1885259068)
				{
				case 0:
					break;
				case 1:
				{
					int num4 = num + 1;
					array2 = new T[num4];
					num3 = 0;
					num2 = -1885259065;
					continue;
				}
				case 5:
					goto IL_0048;
				case 4:
					num2 = -1885259067;
					continue;
				case 3:
					if (num3 >= num)
					{
						array2[num3] = item;
						array = array2;
						num2 = -1885259070;
						continue;
					}
					goto case 2;
				case 2:
					array2[num3] = array[num3];
					num3++;
					num2 = -1885259065;
					continue;
				default:
					return num3;
				}
				break;
			}
			goto IL_0006;
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
			goto IL_00f8;
			IL_00f8:
			int num = default(int);
			int num2;
			if (array == null)
			{
				num = 0;
				num2 = 2071710984;
				goto IL_000f;
			}
			goto IL_0098;
			IL_000a:
			num2 = 2071710986;
			goto IL_000f;
			IL_000f:
			T[] array2 = default(T[]);
			int num3 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ 0x7B7BCD00)
				{
				case 3:
					break;
				case 7:
					array2[num3] = array[num3];
					num3++;
					num2 = 2071710982;
					continue;
				case 0:
					array2[num3] = array[num5];
					num5++;
					num3++;
					num2 = 2071710988;
					continue;
				case 2:
					goto IL_0098;
				case 5:
					num5 = index;
					num3++;
					num2 = 2071710988;
					continue;
				case 9:
					return Add(ref array, item);
				case 6:
					if (num3 >= index)
					{
						array2[num3] = item;
						num2 = 2071710981;
						continue;
					}
					goto case 7;
				case 11:
					num3 = 0;
					num2 = 2071710980;
					continue;
				case 10:
					goto IL_00f8;
				case 8:
					goto IL_0108;
				case 4:
					num2 = 2071710982;
					continue;
				case 1:
					array2 = new T[num4];
					num2 = 2071710987;
					continue;
				default:
					if (num3 >= num4)
					{
						array = array2;
						return index;
					}
					goto case 0;
				}
				break;
				IL_0108:
				int num6 = num - 1;
				if (index <= num6)
				{
					num4 = num + 1;
					num2 = 2071710977;
				}
				else
				{
					num2 = 2071710985;
				}
			}
			goto IL_000a;
			IL_0098:
			num = array.Length;
			num2 = 2071710984;
			goto IL_000f;
		}

		public static bool RemoveAt<T>(ref T[] array, int index)
		{
			if (array == null)
			{
				goto IL_0007;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = -620349927;
				num2 = num;
			}
			else
			{
				num = -620349935;
				num2 = num;
			}
			goto IL_000c;
			IL_0007:
			num = -620349921;
			goto IL_000c;
			IL_000c:
			int num4 = default(int);
			int num5 = default(int);
			T[] array2 = default(T[]);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -620349927)
				{
				case 2:
					break;
				case 0:
					num4 = array.Length;
					num = -620349926;
					continue;
				case 3:
				{
					num5 = num4 - 1;
					int num6;
					if (index <= num5)
					{
						num = -620349936;
						num6 = num;
					}
					else
					{
						num = -620349928;
						num6 = num;
					}
					continue;
				}
				case 10:
					array2[num3] = array[num3];
					num3++;
					num = -620349923;
					continue;
				case 8:
					index = 0;
					num = -620349927;
					continue;
				case 1:
					index = num5;
					num = -620349936;
					continue;
				case 9:
				{
					int num7 = num4 - 1;
					array2 = new T[num7];
					num3 = 0;
					num = -620349923;
					continue;
				}
				case 11:
					array2[num3 - 1] = array[num3];
					num3++;
					num = -620349922;
					continue;
				case 6:
					return false;
				case 4:
					if (num3 >= index)
					{
						num3 = index + 1;
						num = -620349922;
						continue;
					}
					goto case 10;
				case 7:
					if (num3 >= num4)
					{
						array = array2;
						num = -620349924;
						continue;
					}
					goto case 11;
				default:
					return true;
				}
				break;
			}
			goto IL_0007;
		}

		public static bool Remove<T>(ref T[] array, T item)
		{
			if (array == null)
			{
				goto IL_0004;
			}
			int num = array.Length;
			int num2 = 0;
			int num3 = 1002985571;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num3 ^ 0x3BC85863)
				{
				case 4:
					break;
				case 0:
				{
					int num4;
					if (num2 < num)
					{
						num3 = 1002985570;
						num4 = num3;
					}
					else
					{
						num3 = 1002985568;
						num4 = num3;
					}
					continue;
				}
				case 1:
					if (EqualityComparer<T>.Default.Equals(array[num2], item))
					{
						RemoveAt(ref array, num2);
						return true;
					}
					num2++;
					num3 = 1002985571;
					continue;
				case 2:
					return false;
				default:
					return false;
				}
				break;
			}
			goto IL_0004;
			IL_0004:
			num3 = 1002985569;
			goto IL_0009;
		}

		public static void Combine<T>(ref T[] array1, T[] array2)
		{
			if (array1 == null)
			{
				if (array2 == null)
				{
					goto IL_000a;
				}
				goto IL_0071;
			}
			goto IL_0137;
			IL_0137:
			int num;
			if (array1.Length == 0)
			{
				if (array2 != null)
				{
					int num2;
					if (array2.Length == 0)
					{
						num = 1564672205;
						num2 = num;
					}
					else
					{
						num = 1564672194;
						num2 = num;
					}
					goto IL_000f;
				}
				return;
			}
			goto IL_00cb;
			IL_000a:
			num = 1564672202;
			goto IL_000f;
			IL_000f:
			int num7 = default(int);
			int num4 = default(int);
			T[] array3 = default(T[]);
			int num5 = default(int);
			int num6 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x5D4300C4)
				{
				case 0:
					break;
				case 4:
					goto IL_005b;
				case 13:
					goto IL_0071;
				case 2:
				{
					num7 = array2.Length;
					int num8 = num4 + num7;
					array3 = new T[num8];
					num5 = 0;
					num6 = 0;
					num = 1564672192;
					continue;
				}
				case 7:
					array3[num5++] = array1[num6];
					num6++;
					num = 1564672192;
					continue;
				case 6:
					goto IL_00cb;
				case 5:
					goto IL_00ea;
				case 10:
					array3[num5++] = array2[num3];
					num3++;
					num = 1564672193;
					continue;
				case 11:
					num4 = array1.Length;
					num = 1564672198;
					continue;
				case 8:
					goto IL_0137;
				case 3:
					num3 = 0;
					num = 1564672193;
					continue;
				case 9:
					return;
				case 1:
					return;
				case 14:
					return;
				default:
					array1 = array3;
					return;
				}
				break;
				IL_00ea:
				int num9;
				if (num3 >= num7)
				{
					num = 1564672200;
					num9 = num;
				}
				else
				{
					num = 1564672206;
					num9 = num;
				}
				continue;
				IL_005b:
				int num10;
				if (num6 < num4)
				{
					num = 1564672195;
					num10 = num;
				}
				else
				{
					num = 1564672199;
					num10 = num;
				}
			}
			goto IL_000a;
			IL_00cb:
			if (array2 != null)
			{
				int num11;
				if (array2.Length != 0)
				{
					num = 1564672207;
					num11 = num;
				}
				else
				{
					num = 1564672197;
					num11 = num;
				}
				goto IL_000f;
			}
			return;
			IL_0071:
			array1 = (T[])array2.Clone();
		}

		public static T[] Add<T>(T[] array, T item)
		{
			if (array != null)
			{
				goto IL_0035;
			}
			int num = 0;
			goto IL_0077;
			IL_0035:
			num = array.Length;
			int num2 = -849402567;
			goto IL_000c;
			IL_0077:
			int num3 = num + 1;
			T[] array2 = new T[num3];
			num2 = -849402566;
			goto IL_000c;
			IL_000c:
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -849402564)
				{
				case 4:
					num2 = -849402562;
					continue;
				case 2:
					break;
				case 6:
					num4 = 0;
					num2 = -849402563;
					continue;
				case 0:
					array2[num4] = array[num4];
					num4++;
					num2 = -849402563;
					continue;
				case 1:
					goto IL_0062;
				case 5:
					goto IL_0077;
				default:
					array2[num4] = item;
					return array2;
				}
				break;
				IL_0062:
				int num5;
				if (num4 >= num)
				{
					num2 = -849402561;
					num5 = num2;
				}
				else
				{
					num2 = -849402564;
					num5 = num2;
				}
			}
			goto IL_0035;
		}

		public static T[] AddIfUnique<T>(T[] array, T item)
		{
			if (array != null)
			{
				while (true)
				{
					int num = -1035615780;
					while (true)
					{
						switch (num ^ -1035615779)
						{
						case 2:
							break;
						case 1:
							goto IL_0021;
						default:
							goto end_IL_0003;
						}
						break;
						IL_0021:
						if (array.Length == 0)
						{
							goto end_IL_0003;
						}
						if (!Contains(array, item))
						{
							num = -1035615779;
							continue;
						}
						return array;
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
				goto IL_0007;
			}
			goto IL_00ba;
			IL_0007:
			int num = -549933859;
			goto IL_000c;
			IL_000c:
			int num2 = default(int);
			T[] array2 = default(T[]);
			int num4 = default(int);
			int num3 = default(int);
			int num7 = default(int);
			while (true)
			{
				switch (num ^ -549933866)
				{
				case 2:
					break;
				case 10:
					goto IL_0050;
				case 12:
					if (num2 >= index)
					{
						array2[num2] = item;
						num = -549933857;
						continue;
					}
					goto case 6;
				case 4:
					array2 = new T[num4];
					num = -549933867;
					continue;
				case 11:
					index = 0;
					num = -549933871;
					continue;
				case 1:
					goto IL_00a1;
				case 7:
					goto IL_00ba;
				case 8:
					goto IL_00c9;
				case 0:
					array2[num2] = array[num3];
					num3++;
					num2++;
					num = -549933865;
					continue;
				case 9:
					num3 = index;
					num2++;
					num = -549933865;
					continue;
				case 3:
					num2 = 0;
					num = -549933862;
					continue;
				case 6:
					array2[num2] = array[num2];
					num2++;
					num = -549933862;
					continue;
				default:
					return array2;
				}
				break;
				IL_00a1:
				int num5;
				if (num2 >= num4)
				{
					num = -549933869;
					num5 = num;
				}
				else
				{
					num = -549933866;
					num5 = num;
				}
				continue;
				IL_0050:
				int num6 = num7 - 1;
				if (index > num6)
				{
					return Add(array, item);
				}
				num4 = num7 + 1;
				num = -549933870;
			}
			goto IL_0007;
			IL_00ba:
			if (array == null)
			{
				num7 = 0;
				num = -549933860;
				goto IL_000c;
			}
			goto IL_00c9;
			IL_00c9:
			num7 = array.Length;
			num = -549933860;
			goto IL_000c;
		}

		public static T[] RemoveAt<T>(T[] array, int index)
		{
			if (array == null)
			{
				goto IL_0006;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = -1321659;
				num2 = num;
			}
			else
			{
				num = -1321660;
				num2 = num;
			}
			goto IL_000b;
			IL_0006:
			num = -1321657;
			goto IL_000b;
			IL_000b:
			T[] array2 = default(T[]);
			int num3 = default(int);
			int num6 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ -1321663)
				{
				case 0:
					break;
				case 7:
					num = -1321656;
					continue;
				case 10:
					array2[num3 - 1] = array[num3];
					num3++;
					num = -1321656;
					continue;
				case 2:
					if (index > num6)
					{
						index = num6;
						num = -1321655;
						continue;
					}
					goto case 8;
				case 5:
					index = 0;
					num = -1321659;
					continue;
				case 8:
				{
					int num5 = num4 - 1;
					array2 = new T[num5];
					num3 = 0;
					num = -1321664;
					continue;
				}
				case 1:
					if (num3 >= index)
					{
						num3 = index + 1;
						num = -1321658;
						continue;
					}
					goto case 3;
				case 4:
					num4 = array.Length;
					num6 = num4 - 1;
					num = -1321661;
					continue;
				case 6:
					return null;
				case 3:
					array2[num3] = array[num3];
					num3++;
					num = -1321664;
					continue;
				default:
					if (num3 >= num4)
					{
						return array2;
					}
					goto case 10;
				}
				break;
			}
			goto IL_0006;
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
				int num2 = -144207284;
				while (true)
				{
					switch (num2 ^ -144207283)
					{
					case 0:
						break;
					case 1:
						num3 = 0;
						num2 = -144207281;
						continue;
					case 3:
						if (EqualityComparer<T>.Default.Equals(array[num3], item))
						{
							return RemoveAt(array, num3);
						}
						num3++;
						num2 = -144207281;
						continue;
					default:
						if (num3 >= num)
						{
							return array;
						}
						goto case 3;
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
			if (array1 == null)
			{
				goto IL_000e;
			}
			int num = array1.Length;
			goto IL_00d7;
			IL_00d1:
			num = 0;
			goto IL_00d7;
			IL_0013:
			int num2;
			int num5 = default(int);
			int num7 = default(int);
			T[] array3 = default(T[]);
			int num8 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -1500837333)
				{
				case 6:
					break;
				case 8:
					num5++;
					num2 = -1500837330;
					continue;
				case 9:
					num7 = ((array2 != null) ? array2.Length : 0);
					num2 = -1500837336;
					continue;
				case 1:
					array3[num8++] = array1[num3];
					num3++;
					num2 = -1500837332;
					continue;
				case 4:
					array3[num8++] = array2[num5];
					num2 = -1500837341;
					continue;
				case 5:
					goto IL_00ae;
				case 10:
					num2 = -1500837330;
					continue;
				case 2:
					goto IL_00d1;
				case 3:
				{
					int num6 = num4 + num7;
					array3 = new T[num6];
					num8 = 0;
					num3 = 0;
					num2 = -1500837332;
					continue;
				}
				case 7:
					if (num3 >= num4)
					{
						num5 = 0;
						num2 = -1500837343;
						continue;
					}
					goto case 1;
				default:
					return array3;
				}
				break;
				IL_00ae:
				int num9;
				if (num5 >= num7)
				{
					num2 = -1500837333;
					num9 = num2;
				}
				else
				{
					num2 = -1500837329;
					num9 = num2;
				}
			}
			goto IL_000e;
			IL_00d7:
			num4 = num;
			num2 = -1500837342;
			goto IL_0013;
			IL_000e:
			num2 = -1500837335;
			goto IL_0013;
		}

		public static int IndexOf<T>(T[] array, T item)
		{
			if (array == null)
			{
				return -1;
			}
			int num = array.Length;
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					if (EqualityComparer<T>.Default.Equals(array[num2], item))
					{
						return num2;
					}
					num2++;
					int num3 = -231174400;
					while (true)
					{
						switch (num3 ^ -231174399)
						{
						case 0:
							num3 = -231174397;
							continue;
						case 2:
							break;
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

		public static bool Contains<T>(T[] array, T item)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			int num = array.Length;
			int num2 = 0;
			int num3 = -1667100588;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num3 ^ -1667100588)
				{
				case 2:
					break;
				case 1:
					return false;
				case 3:
					if (!EqualityComparer<T>.Default.Equals(array[num2], item))
					{
						goto IL_004a;
					}
					return true;
				default:
					if (num2 >= num)
					{
						return false;
					}
					goto case 3;
				}
				break;
				IL_004a:
				num2++;
				num3 = -1667100588;
			}
			goto IL_0003;
			IL_0003:
			num3 = -1667100587;
			goto IL_0008;
		}

		public static T Find<T>(T[] array, Predicate<T> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			T result = default(T);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num;
				if (array == null)
				{
					result = default(T);
					num = 221692615;
				}
				else
				{
					num2 = array.Length;
					num = 221692613;
				}
				while (true)
				{
					switch (num ^ 0xD36C2C3)
					{
					case 2:
						num = 221692612;
						continue;
					case 7:
						break;
					case 6:
						num3 = 0;
						num = 221692611;
						continue;
					case 1:
						if (predicate(array[num3]))
						{
							return array[num3];
						}
						num3++;
						num = 221692608;
						continue;
					case 0:
						num = 221692608;
						continue;
					case 3:
					{
						int num4;
						if (num3 >= num2)
						{
							num = 221692614;
							num4 = num;
						}
						else
						{
							num = 221692610;
							num4 = num;
						}
						continue;
					}
					case 4:
						return result;
					default:
						return default(T);
					}
					break;
				}
			}
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
			goto IL_007c;
			IL_001a:
			int num;
			T[] array2 = default(T[]);
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			int num5 = default(int);
			while (true)
			{
				switch (num ^ -1884533594)
				{
				case 0:
					break;
				case 1:
					array2[num4++] = array[num2];
					num2++;
					num = -1884533598;
					continue;
				case 3:
					goto IL_005e;
				case 2:
					goto IL_007c;
				default:
					if (num2 >= num3)
					{
						array = array2;
						return true;
					}
					goto case 1;
				}
				break;
				IL_005e:
				if (startIndex >= num5)
				{
					return false;
				}
				int num6 = num3 - startIndex;
				array2 = new T[num6];
				num4 = 0;
				num2 = startIndex;
				num = -1884533598;
			}
			goto IL_0015;
			IL_007c:
			num3 = array.Length;
			num5 = num3 - 1;
			num = -1884533595;
			goto IL_001a;
			IL_0015:
			num = -1884533596;
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
				goto IL_0012;
			}
			int num;
			int num2;
			if (startIndex >= 0)
			{
				num = 1326623652;
				num2 = num;
			}
			else
			{
				num = 1326623653;
				num2 = num;
			}
			goto IL_0017;
			IL_0017:
			int num5 = default(int);
			T[] array2 = default(T[]);
			int num6 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ 0x4F12ABA7)
				{
				case 6:
					break;
				case 1:
					return false;
				case 3:
				{
					int num7 = array.Length;
					if (startIndex >= num7 - 1)
					{
						return false;
					}
					if (count > num7 - startIndex)
					{
						count = num7 - startIndex;
						num = 1326623655;
						continue;
					}
					goto case 0;
				}
				case 0:
					num5 = count;
					num = 1326623650;
					continue;
				case 2:
					startIndex = 0;
					num = 1326623652;
					continue;
				case 4:
					array2[num6++] = array[num3];
					num3++;
					num = 1326623648;
					continue;
				case 8:
					num3 = startIndex;
					num = 1326623662;
					continue;
				case 5:
					array2 = new T[num5];
					num4 = startIndex + count - 1;
					num6 = 0;
					num = 1326623663;
					continue;
				case 9:
					num = 1326623648;
					continue;
				default:
					if (num3 > num4)
					{
						array = array2;
						return true;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0012;
			IL_0012:
			num = 1326623654;
			goto IL_0017;
		}

		public static void Expand<T>(ref T[] array, int length)
		{
			if (length <= 0)
			{
				goto IL_0004;
			}
			goto IL_006b;
			IL_0004:
			int num = -1952792646;
			goto IL_0009;
			IL_0009:
			T[] array2 = default(T[]);
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1952792643)
				{
				case 6:
					break;
				default:
					return;
				case 4:
					num = -1952792642;
					continue;
				case 2:
					array = array2;
					num = -1952792651;
					continue;
				case 7:
					return;
				case 1:
					if (num3 > 0)
					{
						Array.Copy(array, array2, num3);
						num = -1952792641;
						continue;
					}
					goto case 2;
				case 5:
					goto IL_006b;
				case 9:
					array2 = new T[num2];
					num = -1952792644;
					continue;
				case 3:
					num2 = num3 + length;
					num = -1952792652;
					continue;
				case 0:
					goto IL_0094;
				case 8:
					return;
				}
				break;
			}
			goto IL_0004;
			IL_0094:
			num3 = array.Length;
			num = -1952792642;
			goto IL_0009;
			IL_006b:
			if (array == null)
			{
				num3 = 0;
				num = -1952792647;
				goto IL_0009;
			}
			goto IL_0094;
		}

		public static void Trim(string[] array)
		{
			if (array == null)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				int num = array.Length;
				int num2 = -1789252971;
				while (true)
				{
					switch (num2 ^ -1789252969)
					{
					case 0:
						num2 = -1789252973;
						continue;
					case 6:
						num3 = 0;
						num2 = -1789252970;
						continue;
					case 5:
						num3++;
						num2 = -1789252970;
						continue;
					case 4:
						break;
					case 2:
						if (num == 0)
						{
							return;
						}
						goto case 6;
					case 3:
						array[num3].Trim();
						num2 = -1789252974;
						continue;
					default:
						if (num3 >= num)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public static RaycastHit[] SortNearToFar(RaycastHit[] hits)
		{
			int num = hits.Length;
			if (hits != null)
			{
				int num8 = default(int);
				int num9 = default(int);
				int num5 = default(int);
				int[] array3 = default(int[]);
				int num3 = default(int);
				int num7 = default(int);
				float[] array2 = default(float[]);
				float num6 = default(float);
				float num4 = default(float);
				bool flag = default(bool);
				RaycastHit[] array = default(RaycastHit[]);
				while (true)
				{
					int num2 = -245584895;
					while (true)
					{
						switch (num2 ^ -245584879)
						{
						case 4:
							break;
						case 3:
							num8++;
							num2 = -245584866;
							continue;
						case 17:
							goto end_IL_0007;
						case 7:
							num9 = 0;
							num2 = -245584870;
							continue;
						case 6:
							if (num5 >= num)
							{
								array3[num3] = num7;
								num2 = -245584868;
								continue;
							}
							goto case 14;
						case 8:
							array2[num9] = hits[num9].distance;
							num9++;
							num2 = -245584879;
							continue;
						case 18:
							num6 = num4;
							num7 = num5;
							num2 = -245584891;
							continue;
						case 21:
							if (flag)
							{
								flag = false;
								num2 = -245584893;
								continue;
							}
							goto case 18;
						case 12:
						{
							ref RaycastHit reference = ref array[num8];
							reference = hits[array3[num8]];
							num2 = -245584878;
							continue;
						}
						case 0:
							if (num9 >= num)
							{
								num3 = 0;
								num2 = -245584877;
								continue;
							}
							goto case 8;
						case 13:
							array2[num7] = -1f;
							num3++;
							num2 = -245584877;
							continue;
						case 9:
							num8 = 0;
							num2 = -245584876;
							continue;
						case 19:
							flag = true;
							num6 = -1f;
							num7 = -1;
							num5 = 0;
							num2 = -245584873;
							continue;
						case 11:
							num2 = -245584879;
							continue;
						case 20:
							num5++;
							num2 = -245584873;
							continue;
						case 16:
							goto IL_0191;
						case 1:
							goto IL_01a1;
						case 15:
							goto IL_01bb;
						case 14:
							num4 = array2[num5];
							if (num4 < 0f)
							{
								goto case 20;
							}
							goto IL_01e3;
						case 5:
							num2 = -245584866;
							continue;
						case 2:
							if (num3 >= num)
							{
								array = new RaycastHit[num];
								num2 = -245584872;
								continue;
							}
							goto case 19;
						default:
							return array;
						}
						break;
						IL_01bb:
						int num10;
						if (num8 >= num)
						{
							num2 = -245584869;
							num10 = num2;
						}
						else
						{
							num2 = -245584867;
							num10 = num2;
						}
						continue;
						IL_0191:
						if (num != 0)
						{
							array2 = new float[num];
							array3 = new int[num];
							num2 = -245584874;
						}
						else
						{
							num2 = -245584896;
						}
						continue;
						IL_01e3:
						int num11;
						if (!flag)
						{
							num2 = -245584880;
							num11 = num2;
						}
						else
						{
							num2 = -245584892;
							num11 = num2;
						}
						continue;
						IL_01a1:
						int num12;
						if (num4 < num6)
						{
							num2 = -245584892;
							num12 = num2;
						}
						else
						{
							num2 = -245584891;
							num12 = num2;
						}
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			return null;
		}

		public static void MoveEntryUp<T>(T[] array, int index)
		{
			if (array == null)
			{
				return;
			}
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
					IL_005f:
					if (index <= 0)
					{
						return;
					}
					int num2;
					int num3;
					if (index >= num)
					{
						num2 = 1244885815;
						num3 = num2;
					}
					else
					{
						num2 = 1244885812;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x4A337334)
						{
						case 5:
							num2 = 1244885813;
							continue;
						case 1:
							break;
						case 0:
						{
							int num4 = index - 1;
							val = array[num4];
							array[num4] = array[index];
							num2 = 1244885814;
							continue;
						}
						case 4:
							goto IL_005f;
						case 3:
							return;
						default:
							array[index] = val;
							return;
						}
						break;
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
			while (true)
			{
				int num = array.Length;
				int num2;
				int num3;
				if (num <= 1)
				{
					num2 = -1973540497;
					num3 = num2;
				}
				else
				{
					num2 = -1973540504;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1973540500)
					{
					case 0:
						num2 = -1973540499;
						continue;
					case 2:
						return;
					case 3:
						return;
					case 1:
						break;
					case 4:
					{
						if (index < 0)
						{
							return;
						}
						int num5;
						if (index < num - 1)
						{
							num2 = -1973540503;
							num5 = num2;
						}
						else
						{
							num2 = -1973540498;
							num5 = num2;
						}
						continue;
					}
					default:
					{
						int num4 = index + 1;
						T val = array[num4];
						array[num4] = array[index];
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
				goto IL_000f;
			}
			goto IL_005d;
			IL_005d:
			T[] array2 = null;
			int num2 = 0;
			int num3 = -1178105490;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num3 ^ -1178105496)
				{
				case 0:
					break;
				case 2:
					num2++;
					num3 = -1178105490;
					continue;
				case 6:
					goto IL_0048;
				case 1:
					goto IL_005d;
				case 4:
					return;
				case 3:
					if (array[num2] != null)
					{
						Add(ref array2, array[num2]);
						num3 = -1178105494;
						continue;
					}
					goto case 2;
				default:
					array = array2;
					return;
				}
				break;
				IL_0048:
				int num4;
				if (num2 >= num)
				{
					num3 = -1178105491;
					num4 = num3;
				}
				else
				{
					num3 = -1178105493;
					num4 = num3;
				}
			}
			goto IL_000f;
			IL_000f:
			num3 = -1178105492;
			goto IL_0014;
		}

		public static int IndexOf(int[] array, int value)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			int num = 0;
			int num2 = -1763345056;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ -1763345055)
				{
				case 0:
					break;
				case 3:
					return -1;
				case 2:
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
					goto case 2;
				}
				break;
				IL_0038:
				num++;
				num2 = -1763345056;
			}
			goto IL_0003;
			IL_0003:
			num2 = -1763345054;
			goto IL_0008;
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
					num2 = -555635268;
					num3 = num2;
				}
				else
				{
					num2 = -555635266;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -555635266)
					{
					case 4:
						num2 = -555635268;
						continue;
					case 1:
						break;
					case 3:
						return num;
					case 2:
						if (array[num] != value)
						{
							num++;
							num2 = -555635265;
						}
						else
						{
							num2 = -555635267;
						}
						continue;
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
				goto IL_0003;
			}
			int num = 0;
			int num2 = 824004554;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ 0x311D4FC8)
				{
				case 0:
					break;
				case 3:
					if (array[num] == value)
					{
						return num;
					}
					num++;
					num2 = 824004556;
					continue;
				case 2:
					num2 = 824004556;
					continue;
				case 1:
					return -1;
				default:
					if (num >= array.Length)
					{
						return -1;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = 824004553;
			goto IL_0008;
		}

		public static int IndexOf(ushort[] array, ushort value)
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
					int num2 = -1023777637;
					while (true)
					{
						switch (num2 ^ -1023777637)
						{
						case 2:
							num2 = -1023777638;
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

		public static int IndexOf(uint[] array, uint value)
		{
			if (array == null)
			{
				goto IL_0003;
			}
			int num = 0;
			int num2 = 251603499;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ 0xEFF2A2A)
				{
				case 2:
					break;
				case 3:
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
				num2 = 251603499;
			}
			goto IL_0003;
			IL_0003:
			num2 = 251603497;
			goto IL_0008;
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
					int num2 = -863498064;
					while (true)
					{
						switch (num2 ^ -863498064)
						{
						case 2:
							num2 = -863498063;
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

		public static int IndexOf(bool[] array, bool value)
		{
			if (array == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = 1403803569;
				while (true)
				{
					switch (num2 ^ 0x53AC57B2)
					{
					case 0:
						break;
					case 3:
						num2 = 1403803571;
						continue;
					case 2:
						if (array[num] == value)
						{
							num2 = 1403803574;
							continue;
						}
						num++;
						num2 = 1403803571;
						continue;
					case 4:
						return num;
					default:
						if (num >= array.Length)
						{
							return -1;
						}
						goto case 2;
					}
					break;
				}
			}
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
					num2 = 465947733;
					num3 = num2;
				}
				else
				{
					num2 = 465947732;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x1BC5CC54)
					{
					case 3:
						num2 = 465947733;
						continue;
					case 1:
						if (array[num] == value)
						{
							return num;
						}
						num++;
						num2 = 465947734;
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
				return -1;
			}
			int num = 0;
			while (num < array.Length)
			{
				while (true)
				{
					if (array[num].Equals(value, stringComparison))
					{
						return num;
					}
					num++;
					int num2 = -2101899659;
					while (true)
					{
						switch (num2 ^ -2101899659)
						{
						case 2:
							num2 = -2101899660;
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

		public static void Fill<T>(T[] array, T value)
		{
			if (array == null)
			{
				return;
			}
			while (true)
			{
				int num = 0;
				int num2 = 1049339803;
				while (true)
				{
					switch (num2 ^ 0x3E8BA79F)
					{
					case 2:
						num2 = 1049339806;
						continue;
					default:
						return;
					case 1:
						break;
					case 0:
						array[num] = value;
						num++;
						num2 = 1049339803;
						continue;
					case 4:
					{
						int num3;
						if (num >= array.Length)
						{
							num2 = 1049339804;
							num3 = num2;
						}
						else
						{
							num2 = 1049339807;
							num3 = num2;
						}
						continue;
					}
					case 3:
						return;
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
					num = 1563798167;
					num2 = num;
				}
				else
				{
					num = 1563798163;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x5D35AA91)
					{
					case 0:
						num = 1563798164;
						continue;
					case 4:
						array[num3] = value;
						num3++;
						num = 1563798166;
						continue;
					case 6:
						throw new ArgumentOutOfRangeException("startIndex");
					case 2:
					{
						int num4;
						if (startIndex >= array.Length)
						{
							num = 1563798167;
							num4 = num;
						}
						else
						{
							num = 1563798162;
							num4 = num;
						}
						continue;
					}
					case 1:
						num = 1563798166;
						continue;
					case 5:
						break;
					case 3:
						num3 = startIndex;
						num = 1563798160;
						continue;
					default:
						if (num3 >= array.Length)
						{
							return;
						}
						goto case 4;
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
			while (true)
			{
				int num;
				int num2;
				if (startIndex < 0)
				{
					num = 1084386549;
					num2 = num;
				}
				else
				{
					num = 1084386547;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x40A26CF4)
					{
					case 4:
						num = 1084386551;
						continue;
					case 5:
						length = MathTools.Clamp(startIndex + length, 0, array.Length);
						num3 = startIndex;
						num = 1084386546;
						continue;
					case 1:
						throw new ArgumentOutOfRangeException("startIndex");
					case 2:
						array[num3] = value;
						num3++;
						num = 1084386548;
						continue;
					case 3:
						break;
					case 7:
					{
						int num4;
						if (startIndex < array.Length)
						{
							num = 1084386545;
							num4 = num;
						}
						else
						{
							num = 1084386549;
							num4 = num;
						}
						continue;
					}
					case 6:
						num = 1084386548;
						continue;
					default:
						if (num3 >= array.Length)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
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
					num = -1232071678;
					num2 = num;
				}
				else
				{
					num = -1232071669;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1232071671)
					{
					case 0:
						num = -1232071679;
						continue;
					case 7:
					{
						int num4;
						if (length <= array.Length)
						{
							num = -1232071667;
							num4 = num;
						}
						else
						{
							num = -1232071668;
							num4 = num;
						}
						continue;
					}
					case 9:
						num = -1232071670;
						continue;
					case 4:
						if (startIndex + length > array.Length)
						{
							throw new ArgumentOutOfRangeException("startIndex + length must be <= array.Length");
						}
						goto case 6;
					case 8:
						break;
					case 10:
						if (startIndex >= length)
						{
							throw new ArgumentOutOfRangeException("startIndex must be < length");
						}
						goto case 7;
					case 5:
						throw new ArgumentOutOfRangeException("length must be <= array.Length");
					case 6:
						num3 = startIndex;
						num = -1232071680;
						continue;
					case 1:
						array[num3] = instantiator();
						num3++;
						num = -1232071670;
						continue;
					case 11:
						return;
					case 2:
						if (startIndex < 0)
						{
							throw new ArgumentOutOfRangeException("startIndex must be >= 0");
						}
						goto case 10;
					default:
						if (num3 >= startIndex + length)
						{
							return;
						}
						goto case 1;
					}
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
						IL_00c7:
						if (startIndex < length)
						{
							while (true)
							{
								IL_00ac:
								if (length <= array.Length)
								{
									while (true)
									{
										IL_0077:
										if (startIndex + length > array.Length)
										{
											throw new ArgumentOutOfRangeException("startIndex + length must be <= array.Length");
										}
										while (true)
										{
											IL_0091:
											int num = startIndex;
											int num2 = -912566449;
											while (true)
											{
												switch (num2 ^ -912566450)
												{
												case 5:
													num2 = -912566451;
													continue;
												case 6:
													array[num] = new T();
													num++;
													num2 = -912566449;
													continue;
												case 0:
													break;
												case 2:
													goto IL_0077;
												case 7:
													goto IL_0091;
												case 3:
													goto end_IL_0061;
												case 8:
													goto IL_00ac;
												case 4:
													goto IL_00c7;
												default:
													if (num >= startIndex + length)
													{
														return;
													}
													goto case 6;
												}
												break;
											}
											break;
										}
										break;
									}
									break;
								}
								throw new ArgumentOutOfRangeException("length must be <= array.Length");
							}
							break;
						}
						throw new ArgumentOutOfRangeException("startIndex must be < length");
					}
					continue;
					end_IL_0061:
					break;
				}
			}
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
			int num3 = default(int);
			while (array != null)
			{
				int num = 0;
				int num2 = 1899250594;
				while (true)
				{
					switch (num2 ^ 0x713443A5)
					{
					case 3:
						num2 = 1899250596;
						continue;
					case 2:
						num3++;
						num2 = 1899250597;
						continue;
					case 4:
						if (predicate(array[num3]))
						{
							num++;
							num2 = 1899250599;
							continue;
						}
						goto case 2;
					case 0:
					{
						int num4;
						if (num3 < array.Length)
						{
							num2 = 1899250593;
							num4 = num2;
						}
						else
						{
							num2 = 1899250595;
							num4 = num2;
						}
						continue;
					}
					case 7:
						num3 = 0;
						num2 = 1899250592;
						continue;
					case 5:
						num2 = 1899250597;
						continue;
					case 1:
						break;
					default:
						return num;
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
				goto IL_000e;
			}
			int num = 0;
			int num2 = -1919457497;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num2 ^ -1919457501)
				{
				case 2:
					break;
				case 4:
				{
					int num3;
					if (num < a1.Length)
					{
						num2 = -1919457501;
						num3 = num2;
					}
					else
					{
						num2 = -1919457502;
						num3 = num2;
					}
					continue;
				}
				case 0:
					if (a1[num] != a2[num])
					{
						num2 = -1919457498;
						continue;
					}
					num++;
					num2 = -1919457497;
					continue;
				case 5:
					return false;
				case 3:
					return false;
				default:
					return true;
				}
				break;
			}
			goto IL_000e;
			IL_000e:
			num2 = -1919457504;
			goto IL_0013;
		}

		public static bool Contains(string[] array, string item, bool ignoreCase)
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
					if (ignoreCase)
					{
						if (array[num2].Equals(item, StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
					}
					else if (array[num2] == item)
					{
						return true;
					}
					num2++;
					int num3 = 1073170521;
					while (true)
					{
						switch (num3 ^ 0x3FF74858)
						{
						case 0:
							num3 = 1073170522;
							continue;
						case 2:
							break;
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
			return false;
		}

		public static int AddIfUnique(ref string[] array, string item, bool ignoreCase)
		{
			if (array != null && array.Length != 0)
			{
				while (true)
				{
					int num = -1736361554;
					while (true)
					{
						switch (num ^ -1736361553)
						{
						case 2:
							break;
						case 1:
							goto IL_0028;
						default:
							goto end_IL_000a;
						}
						break;
						IL_0028:
						if (!Contains(array, item, ignoreCase))
						{
							num = -1736361553;
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
			int num3 = default(int);
			string[] array2 = default(string[]);
			while (true)
			{
				int num2 = 243066059;
				while (true)
				{
					switch (num2 ^ 0xE7CE4CD)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						num3++;
						num2 = 243066057;
						continue;
					case 5:
						AddIfUnique(ref array2, array[num3], ignoreCase);
						num2 = 243066060;
						continue;
					case 4:
						if (num3 >= num)
						{
							array = array2;
							num2 = 243066062;
							continue;
						}
						goto case 5;
					case 6:
						if (num == 0)
						{
							return;
						}
						goto case 2;
					case 2:
						array2 = null;
						num3 = 0;
						num2 = 243066057;
						continue;
					case 3:
						return;
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
			int num5 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2 = -2008472322;
				while (true)
				{
					switch (num2 ^ -2008472325)
					{
					case 7:
						break;
					case 1:
						return true;
					case 2:
					{
						int num6;
						if (num5 >= num)
						{
							num2 = -2008472334;
							num6 = num2;
						}
						else
						{
							num2 = -2008472333;
							num6 = num2;
						}
						continue;
					}
					case 3:
						num3 = 0;
						num2 = -2008472325;
						continue;
					case 5:
						if (item == null)
						{
							num5 = 0;
							num2 = -2008472327;
							continue;
						}
						goto case 3;
					case 8:
						if (array[num5] == null)
						{
							RemoveAt(ref array, num5);
							return true;
						}
						num5++;
						num2 = -2008472327;
						continue;
					case 10:
						if (array[num3] != null && array[num3].Equals(item, StringComparison.OrdinalIgnoreCase))
						{
							RemoveAt(ref array, num3);
							num2 = -2008472326;
							continue;
						}
						goto IL_0064;
					case 9:
						num2 = -2008472323;
						continue;
					case 4:
						if (!ignoreCase)
						{
							if (array[num3] == item)
							{
								RemoveAt(ref array, num3);
								return true;
							}
							goto IL_0064;
						}
						num2 = -2008472335;
						continue;
					case 0:
					{
						int num4;
						if (num3 < num)
						{
							num2 = -2008472321;
							num4 = num2;
						}
						else
						{
							num2 = -2008472323;
							num4 = num2;
						}
						continue;
					}
					default:
						{
							return false;
						}
						IL_0064:
						num3++;
						num2 = -2008472325;
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
				return null;
			}
			if (array.Length == 0)
			{
				return null;
			}
			string[] array2 = new string[array.Length];
			int num = 0;
			while (num < array.Length)
			{
				while (true)
				{
					int num2;
					if (array[num] != null)
					{
						array2[num] = array[num].ToLower().Replace(" ", "");
						num2 = 1671561337;
						goto IL_001e;
					}
					goto IL_0061;
					IL_001e:
					while (true)
					{
						switch (num2 ^ 0x63A2007A)
						{
						case 0:
							num2 = 1671561336;
							continue;
						case 2:
							break;
						case 3:
							goto IL_0061;
						default:
							goto end_IL_003b;
						}
						break;
					}
					continue;
					IL_0061:
					num++;
					num2 = 1671561339;
					goto IL_001e;
					continue;
					end_IL_003b:
					break;
				}
			}
			return array2;
		}

		public static int ToBitmask(bool[] array, int startIndex, int count = 32)
		{
			if (array == null)
			{
				goto IL_0006;
			}
			goto IL_00ad;
			IL_0006:
			int num = 2123117973;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x7E8C3590)
				{
				case 4:
					break;
				case 11:
					goto IL_004f;
				case 7:
					num2 = 0;
					num3 = 0;
					num = 2123117976;
					continue;
				case 5:
					throw new ArgumentNullException("array");
				case 0:
					num3++;
					num = 2123117976;
					continue;
				case 10:
					goto IL_0095;
				case 6:
					goto IL_00ad;
				case 3:
					if (count > 32)
					{
						throw new ArgumentOutOfRangeException("count must be <= 32");
					}
					goto case 7;
				case 9:
					if (array[num3])
					{
						num2 |= 1 << num3;
						num = 2123117968;
						continue;
					}
					goto case 0;
				case 1:
					throw new ArgumentOutOfRangeException("count");
				case 12:
					goto IL_0112;
				case 8:
					goto IL_0127;
				default:
					return num2;
				}
				break;
				IL_0127:
				int num4;
				if (num3 >= array.Length)
				{
					num = 2123117970;
					num4 = num;
				}
				else
				{
					num = 2123117977;
					num4 = num;
				}
				continue;
				IL_0095:
				int num5;
				if (count <= 0)
				{
					num = 2123117969;
					num5 = num;
				}
				else
				{
					num = 2123117979;
					num5 = num;
				}
				continue;
				IL_004f:
				int num6;
				if (startIndex + count <= array.Length + 1)
				{
					num = 2123117971;
					num6 = num;
				}
				else
				{
					num = 2123117969;
					num6 = num;
				}
			}
			goto IL_0006;
			IL_0112:
			throw new ArgumentOutOfRangeException("startIndex");
			IL_00ad:
			if (startIndex >= 0)
			{
				int num7;
				if (startIndex >= array.Length)
				{
					num = 2123117980;
					num7 = num;
				}
				else
				{
					num = 2123117978;
					num7 = num;
				}
				goto IL_000b;
			}
			goto IL_0112;
		}

		public static bool IsNullOrEmpty<T>(T[] array)
		{
			if (array == null)
			{
				return true;
			}
			if (array.Length == 0)
			{
				goto IL_000a;
			}
			if (!typeof(T).IsClass)
			{
				return false;
			}
			int num = 0;
			int num2 = 1460122327;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num2 ^ 0x5707B2D7)
				{
				case 4:
					break;
				case 1:
					return true;
				case 5:
					if (array[num] != null)
					{
						return false;
					}
					num++;
					num2 = 1460122325;
					continue;
				case 0:
					num2 = 1460122325;
					continue;
				case 2:
				{
					int num3;
					if (num >= array.Length)
					{
						num2 = 1460122324;
						num3 = num2;
					}
					else
					{
						num2 = 1460122322;
						num3 = num2;
					}
					continue;
				}
				default:
					return true;
				}
				break;
			}
			goto IL_000a;
			IL_000a:
			num2 = 1460122326;
			goto IL_000f;
		}
	}
}
