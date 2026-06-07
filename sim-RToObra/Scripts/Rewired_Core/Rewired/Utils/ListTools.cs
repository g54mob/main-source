using System;
using System.Collections.Generic;

namespace Rewired.Utils
{
	public static class ListTools
	{
		public static bool OffsetAtIndex<T>(IList<T> list, int index, bool offsetDown, bool offsetNow = true)
		{
			if (list == null)
			{
				goto IL_0003;
			}
			int count = list.Count;
			int num;
			if (index >= 0)
			{
				if (index >= count)
				{
					num = 1728433494;
				}
				else if (index == count - 1 && offsetDown)
				{
					num = 1728433495;
				}
				else
				{
					if (index != 0)
					{
						goto IL_0070;
					}
					num = 1728433492;
				}
				goto IL_0008;
			}
			goto IL_0059;
			IL_006b:
			if (!offsetDown)
			{
				return false;
			}
			goto IL_0070;
			IL_0003:
			num = 1728433489;
			goto IL_0008;
			IL_0008:
			int num3 = default(int);
			while (true)
			{
				int num2;
				switch (num ^ 0x6705CD52)
				{
				case 7:
					break;
				case 3:
					return false;
				case 2:
					num2 = -1;
					goto IL_0051;
				case 4:
					goto IL_0059;
				case 6:
					goto IL_006b;
				case 1:
					list.RemoveAt(index);
					if (offsetDown)
					{
						num2 = 1;
						goto IL_0051;
					}
					num = 1728433488;
					continue;
				case 5:
					return false;
				default:
					goto IL_00a7;
					IL_0051:
					num3 = num2;
					num = 1728433490;
					continue;
				}
				break;
			}
			goto IL_0003;
			IL_00a7:
			T item = default(T);
			if (offsetDown && index + num3 >= count)
			{
				list.Add(item);
				return true;
			}
			list.Insert(index + num3, item);
			return true;
			IL_0059:
			return false;
			IL_0070:
			if (!offsetNow)
			{
				return true;
			}
			item = list[index];
			num = 1728433491;
			goto IL_0008;
		}

		public static List<T> ShallowCopy<T>(List<T> list)
		{
			if (list == null)
			{
				return null;
			}
			int count = list.Count;
			List<T> list2 = new List<T>(count);
			int num2 = default(int);
			while (true)
			{
				int num = 418728694;
				while (true)
				{
					switch (num ^ 0x18F54AF7)
					{
					case 4:
						break;
					case 1:
						num2 = 0;
						num = 418728692;
						continue;
					case 0:
						list2.Add(list[num2]);
						num = 418728693;
						continue;
					case 2:
						num2++;
						num = 418728692;
						continue;
					default:
						if (num2 >= count)
						{
							return list2;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static bool CopyTo<T>(IList<T> fromList, IList<T> toList)
		{
			return CopyTo(fromList, toList, 0, -1);
		}

		public static bool CopyTo<T>(IList<T> fromList, IList<T> toList, int fromListStartIndex)
		{
			return CopyTo(fromList, toList, fromListStartIndex, -1);
		}

		public static bool CopyTo<T>(IList<T> fromList, IList<T> toList, int fromListStartIndex, int count)
		{
			int count2 = default(int);
			int num;
			if (fromList != null)
			{
				if (toList == null)
				{
					goto IL_0006;
				}
				count2 = fromList.Count;
				int num2;
				if (fromListStartIndex < 0)
				{
					num = -367217545;
					num2 = num;
				}
				else
				{
					num = -367217551;
					num2 = num;
				}
				goto IL_000b;
			}
			goto IL_0038;
			IL_000b:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -367217548)
				{
				case 4:
					break;
				case 6:
					goto IL_0038;
				case 1:
					toList.Add(fromList[num3]);
					num3++;
					num = -367217546;
					continue;
				case 7:
					goto IL_006e;
				case 5:
					goto IL_0077;
				case 0:
					num = -367217546;
					continue;
				case 3:
					fromListStartIndex = 0;
					num = -367217551;
					continue;
				default:
					if (num3 >= count)
					{
						return true;
					}
					goto case 1;
				}
				break;
				IL_0077:
				if (fromListStartIndex >= count2)
				{
					return false;
				}
				if (count <= 0)
				{
					count = count2 - fromListStartIndex;
					num = -367217549;
					continue;
				}
				goto IL_006e;
				IL_006e:
				num3 = fromListStartIndex;
				num = -367217548;
			}
			goto IL_0006;
			IL_0006:
			num = -367217550;
			goto IL_000b;
			IL_0038:
			return false;
		}

		public static T[] ToArray<T>(IList<T> list)
		{
			if (list == null)
			{
				return null;
			}
			int count = list.Count;
			T[] array = new T[count];
			int num = 0;
			while (true)
			{
				int num2 = -1074069901;
				while (true)
				{
					switch (num2 ^ -1074069902)
					{
					case 0:
						break;
					case 1:
						num2 = -1074069904;
						continue;
					case 2:
					{
						int num3;
						if (num < count)
						{
							num2 = -1074069903;
							num3 = num2;
						}
						else
						{
							num2 = -1074069898;
							num3 = num2;
						}
						continue;
					}
					case 3:
						array[num] = list[num];
						num++;
						num2 = -1074069904;
						continue;
					default:
						return array;
					}
					break;
				}
			}
		}

		public static List<T> Combine<T>(IList<T> list1, IList<T> list2)
		{
			int num = ((list1 != null) ? list1.Count : 0);
			int num3 = default(int);
			int num5 = default(int);
			List<T> list3 = default(List<T>);
			int num4 = default(int);
			while (true)
			{
				int num2 = -1831785822;
				while (true)
				{
					switch (num2 ^ -1831785823)
					{
					case 0:
						break;
					case 4:
						num3 = 0;
						num2 = -1831785824;
						continue;
					case 2:
					{
						int num6;
						if (num5 >= num)
						{
							num2 = -1831785819;
							num6 = num2;
						}
						else
						{
							num2 = -1831785818;
							num6 = num2;
						}
						continue;
					}
					case 5:
						num2 = -1831785821;
						continue;
					case 6:
						list3.Add(list2[num3]);
						num3++;
						num2 = -1831785815;
						continue;
					case 1:
						num2 = -1831785815;
						continue;
					case 3:
					{
						num4 = ((list2 != null) ? list2.Count : 0);
						int capacity = num + num4;
						list3 = new List<T>(capacity);
						num5 = 0;
						num2 = -1831785820;
						continue;
					}
					case 7:
						list3.Add(list1[num5]);
						num5++;
						num2 = -1831785821;
						continue;
					default:
						if (num3 >= num4)
						{
							return list3;
						}
						goto case 6;
					}
					break;
				}
			}
		}

		public static bool IsNullOrEmpty<T>(IList<T> list)
		{
			if (list == null)
			{
				return true;
			}
			int count = list.Count;
			if (count == 0)
			{
				return true;
			}
			if (!typeof(T).IsClass)
			{
				goto IL_0022;
			}
			int num = 0;
			int num2 = 416089765;
			goto IL_0027;
			IL_0022:
			num2 = 416089762;
			goto IL_0027;
			IL_0027:
			while (true)
			{
				switch (num2 ^ 0x18CD06A1)
				{
				case 0:
					break;
				case 1:
					if (list[num] != null)
					{
						return false;
					}
					num++;
					num2 = 416089763;
					continue;
				case 4:
					num2 = 416089763;
					continue;
				case 3:
					return false;
				default:
					if (num >= count)
					{
						return true;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0022;
		}

		public static List<object> ConvertToObjeclist<T>(IList<T> list)
		{
			List<object> list2 = new List<object>(list.Count);
			int num = 0;
			while (num < list.Count)
			{
				while (true)
				{
					list2.Add(list[num]);
					num++;
					int num2 = -1666173521;
					while (true)
					{
						switch (num2 ^ -1666173522)
						{
						case 0:
							num2 = -1666173524;
							continue;
						case 2:
							break;
						default:
							goto end_IL_002e;
						}
						break;
					}
					continue;
					end_IL_002e:
					break;
				}
			}
			return list2;
		}

		public static void Concat<T>(IList<T> list1, IList<T> list2)
		{
			if (list1 == null)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				int num = 1411778344;
				while (true)
				{
					switch (num ^ 0x54260729)
					{
					case 5:
						break;
					case 4:
						list1.Add(list2[num2]);
						num2++;
						num = 1411778345;
						continue;
					case 3:
						return;
					case 2:
						num2 = 0;
						num = 1411778345;
						continue;
					case 1:
					{
						int num3;
						if (list2 == null)
						{
							num = 1411778346;
							num3 = num;
						}
						else
						{
							num = 1411778347;
							num3 = num;
						}
						continue;
					}
					default:
						if (num2 >= list2.Count)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public static bool AddIfUnique<T>(IList<T> list, T item)
		{
			if (list == null)
			{
				goto IL_0003;
			}
			int num;
			if (list.Contains(item))
			{
				num = 1485054510;
				goto IL_0008;
			}
			list.Add(item);
			return true;
			IL_0003:
			num = 1485054509;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x5884222F)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				return false;
			}
			goto IL_0003;
		}

		public static int Count<T>(IList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				goto IL_0003;
			}
			int count = list.Count;
			int num = 0;
			int num2 = 0;
			int num3 = -217801105;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num3 ^ -217801109)
				{
				case 0:
					break;
				case 3:
					num2++;
					num3 = -217801105;
					continue;
				case 2:
					if (predicate(list[num2]))
					{
						num++;
						num3 = -217801112;
						continue;
					}
					goto case 3;
				case 1:
					return 0;
				default:
					if (num2 >= count)
					{
						return num;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num3 = -217801110;
			goto IL_0008;
		}

		public static void TryClear<T>(IList<T> list)
		{
			if (list != null)
			{
				list.Clear();
			}
		}

		private static bool eKwLASUIoazYxgEHvCuVTafIhIJ<T>(IList<T> P_0, T P_1)
		{
			if (P_0 == null)
			{
				return false;
			}
			P_0.Add(P_1);
			return true;
		}

		public static int AddAndCreateList<T>(ref IList<T> list, T item)
		{
			if (list == null)
			{
				list = new List<T>();
			}
			list.Add(item);
			return list.Count - 1;
		}
	}
}
