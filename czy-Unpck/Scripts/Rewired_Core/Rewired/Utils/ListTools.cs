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
				return false;
			}
			int count = list.Count;
			int num;
			T item = default(T);
			if (index >= 0)
			{
				if (index >= count)
				{
					goto IL_0014;
				}
				if (index == count - 1 && offsetDown)
				{
					return false;
				}
				if (index == 0 && !offsetDown)
				{
					num = -640714646;
				}
				else if (offsetNow)
				{
					item = list[index];
					list.RemoveAt(index);
					num = -640714644;
				}
				else
				{
					num = -640714641;
				}
				goto IL_0019;
			}
			goto IL_0046;
			IL_0046:
			return false;
			IL_0014:
			num = -640714642;
			goto IL_0019;
			IL_0019:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -640714644)
				{
				case 7:
					break;
				case 2:
					goto IL_0046;
				case 1:
					goto IL_0060;
				case 0:
					num2 = (offsetDown ? 1 : (-1));
					num = -640714643;
					continue;
				case 5:
					goto IL_0079;
				case 3:
					return true;
				case 6:
					return false;
				default:
					list.Add(item);
					return true;
				}
				break;
				IL_0079:
				if (index + num2 >= count)
				{
					num = -640714648;
					continue;
				}
				goto IL_00b9;
				IL_00b9:
				list.Insert(index + num2, item);
				return true;
				IL_0060:
				if (offsetDown)
				{
					num = -640714647;
					continue;
				}
				goto IL_00b9;
			}
			goto IL_0014;
		}

		public static List<T> ShallowCopy<T>(List<T> list)
		{
			if (list == null)
			{
				goto IL_0003;
			}
			int count = list.Count;
			List<T> list2 = new List<T>(count);
			int num = 0;
			int num2 = -1512936128;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ -1512936125)
				{
				case 4:
					break;
				case 2:
					return null;
				case 0:
					num++;
					num2 = -1512936128;
					continue;
				case 1:
					list2.Add(list[num]);
					num2 = -1512936125;
					continue;
				default:
					if (num >= count)
					{
						return list2;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = -1512936127;
			goto IL_0008;
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
			if (fromList != null)
			{
				int num2 = default(int);
				int count2 = default(int);
				while (true)
				{
					int num = -1664654579;
					while (true)
					{
						switch (num ^ -1664654577)
						{
						case 7:
							break;
						case 4:
							goto IL_0043;
						case 5:
							num2++;
							num = -1664654583;
							continue;
						case 8:
							toList.Add(fromList[num2]);
							num = -1664654582;
							continue;
						case 0:
							goto IL_006d;
						case 6:
							goto IL_0076;
						case 2:
							goto IL_008b;
						case 3:
							return false;
						case 1:
							goto end_IL_0006;
						default:
							return true;
						}
						break;
						IL_008b:
						if (toList == null)
						{
							num = -1664654578;
							continue;
						}
						count2 = fromList.Count;
						if (fromListStartIndex < 0)
						{
							fromListStartIndex = 0;
							num = -1664654581;
							continue;
						}
						goto IL_0043;
						IL_0076:
						int num3;
						if (num2 < count)
						{
							num = -1664654585;
							num3 = num;
						}
						else
						{
							num = -1664654586;
							num3 = num;
						}
						continue;
						IL_0043:
						if (fromListStartIndex >= count2)
						{
							num = -1664654580;
							continue;
						}
						if (count <= 0)
						{
							count = count2 - fromListStartIndex;
							num = -1664654577;
							continue;
						}
						goto IL_006d;
						IL_006d:
						num2 = fromListStartIndex;
						num = -1664654583;
					}
					continue;
					end_IL_0006:
					break;
				}
			}
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
			while (num < count)
			{
				while (true)
				{
					array[num] = list[num];
					int num2 = 353425142;
					while (true)
					{
						switch (num2 ^ 0x1510D6F5)
						{
						case 0:
							num2 = 353425140;
							continue;
						case 1:
							break;
						case 3:
							num++;
							num2 = 353425143;
							continue;
						default:
							goto end_IL_0039;
						}
						break;
					}
					continue;
					end_IL_0039:
					break;
				}
			}
			return array;
		}

		public static List<T> Combine<T>(IList<T> list1, IList<T> list2)
		{
			int num = list1?.Count ?? 0;
			if (list2 == null)
			{
				goto IL_0010;
			}
			int num2 = list2.Count;
			goto IL_008b;
			IL_008b:
			int num3 = num2;
			int capacity = num + num3;
			List<T> list3 = new List<T>(capacity);
			int num4 = 0;
			int num5 = -364451339;
			goto IL_0015;
			IL_0015:
			int num6 = default(int);
			while (true)
			{
				switch (num5 ^ -364451337)
				{
				case 0:
					break;
				case 4:
					num4++;
					num5 = -364451339;
					continue;
				case 7:
					list3.Add(list1[num4]);
					num5 = -364451341;
					continue;
				case 5:
					list3.Add(list2[num6]);
					num6++;
					num5 = -364451338;
					continue;
				case 3:
					goto IL_0082;
				case 2:
					goto IL_00a4;
				case 6:
					num6 = 0;
					num5 = -364451338;
					continue;
				default:
					if (num6 >= num3)
					{
						return list3;
					}
					goto case 5;
				}
				break;
				IL_00a4:
				int num7;
				if (num4 >= num)
				{
					num5 = -364451343;
					num7 = num5;
				}
				else
				{
					num5 = -364451344;
					num7 = num5;
				}
			}
			goto IL_0010;
			IL_0010:
			num5 = -364451340;
			goto IL_0015;
			IL_0082:
			num2 = 0;
			goto IL_008b;
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
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = 1857058862;
				while (true)
				{
					switch (num2 ^ 0x6EB0782F)
					{
					case 0:
						break;
					case 2:
						return false;
					case 3:
						if (list[num] == null)
						{
							num++;
							num2 = 1857058859;
						}
						else
						{
							num2 = 1857058861;
						}
						continue;
					case 1:
						num2 = 1857058859;
						continue;
					default:
						if (num >= count)
						{
							return true;
						}
						goto case 3;
					}
					break;
				}
			}
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
					int num2 = 806700100;
					while (true)
					{
						switch (num2 ^ 0x30154444)
						{
						case 2:
							num2 = 806700103;
							continue;
						case 3:
							break;
						case 0:
							num++;
							num2 = 806700101;
							continue;
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
				int num = 343654594;
				while (true)
				{
					switch (num ^ 0x147BC0C1)
					{
					case 0:
						break;
					case 1:
						list1.Add(list2[num2]);
						num2++;
						num = 343654597;
						continue;
					case 6:
						num2 = 0;
						num = 343654596;
						continue;
					case 2:
						return;
					case 5:
						num = 343654597;
						continue;
					case 3:
					{
						int num3;
						if (list2 != null)
						{
							num = 343654599;
							num3 = num;
						}
						else
						{
							num = 343654595;
							num3 = num;
						}
						continue;
					}
					default:
						if (num2 >= list2.Count)
						{
							return;
						}
						goto case 1;
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
			if (list.Contains(item))
			{
				return false;
			}
			list.Add(item);
			int num = 382610926;
			goto IL_0008;
			IL_0003:
			num = 382610925;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x16CE2DEC)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_0003;
		}

		public static int Count<T>(IList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				return 0;
			}
			int count = list.Count;
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = -360934741;
				while (true)
				{
					switch (num ^ -360934742)
					{
					case 5:
						break;
					case 3:
						if (predicate(list[num3]))
						{
							num2++;
							num = -360934744;
							continue;
						}
						goto case 2;
					case 4:
						num3 = 0;
						num = -360934739;
						continue;
					case 6:
					{
						int num4;
						if (num3 >= count)
						{
							num = -360934742;
							num4 = num;
						}
						else
						{
							num = -360934743;
							num4 = num;
						}
						continue;
					}
					case 1:
						num2 = 0;
						num = -360934738;
						continue;
					case 7:
						num = -360934740;
						continue;
					case 2:
						num3++;
						num = -360934740;
						continue;
					default:
						return num2;
					}
					break;
				}
			}
		}

		public static void TryClear<T>(IList<T> list)
		{
			list?.Clear();
		}

		private static bool eWeyXYWdJaipRvBnMjJWghBLOYj<T>(IList<T> P_0, T P_1)
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
				while (true)
				{
					int num = -572938355;
					while (true)
					{
						switch (num ^ -572938353)
						{
						case 0:
							break;
						case 2:
							list = new List<T>();
							num = -572938354;
							continue;
						default:
							goto end_IL_0004;
						}
						break;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			list.Add(item);
			return list.Count - 1;
		}

		public static T Find<T>(IList<T> list, Predicate<T> predicate)
		{
			if (list != null)
			{
				int num2 = default(int);
				int count = default(int);
				T result = default(T);
				while (true)
				{
					int num = 983330849;
					while (true)
					{
						switch (num ^ 0x3A9C7020)
						{
						case 0:
							break;
						case 1:
							goto IL_0031;
						case 6:
							goto IL_003b;
						case 2:
							if (num2 >= count)
							{
								result = default(T);
								num = 983330851;
								continue;
							}
							goto IL_003b;
						case 5:
							goto end_IL_0003;
						case 4:
							num2 = 0;
							num = 983330850;
							continue;
						default:
							return result;
						}
						break;
						IL_003b:
						if (predicate(list[num2]))
						{
							return list[num2];
						}
						num2++;
						num = 983330850;
						continue;
						IL_0031:
						if (predicate == null)
						{
							num = 983330853;
							continue;
						}
						count = list.Count;
						num = 983330852;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return default(T);
		}
	}
}
