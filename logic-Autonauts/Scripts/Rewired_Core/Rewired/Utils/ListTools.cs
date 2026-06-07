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
			if (index >= 0)
			{
				if (index >= count)
				{
					goto IL_001a;
				}
				if (index == count - 1 && offsetDown)
				{
					return false;
				}
				if (index == 0)
				{
					num = -611871636;
					goto IL_001f;
				}
				goto IL_00a8;
			}
			goto IL_00b5;
			IL_001f:
			T item = default(T);
			while (true)
			{
				switch (num ^ -611871640)
				{
				case 7:
					break;
				case 6:
					return true;
				case 4:
					goto IL_0078;
				case 1:
					list.Add(item);
					num = -611871640;
					continue;
				case 0:
					return true;
				case 3:
					return false;
				case 5:
					goto IL_00b5;
				default:
					return true;
				}
				break;
				IL_0078:
				if (!offsetDown)
				{
					num = -611871637;
					continue;
				}
				goto IL_00a8;
			}
			goto IL_001a;
			IL_00b5:
			return false;
			IL_001a:
			num = -611871635;
			goto IL_001f;
			IL_00a8:
			if (offsetNow)
			{
				item = list[index];
				list.RemoveAt(index);
				int num2 = (offsetDown ? 1 : (-1));
				if (offsetDown && index + num2 >= count)
				{
					num = -611871639;
				}
				else
				{
					list.Insert(index + num2, item);
					num = -611871638;
				}
			}
			else
			{
				num = -611871634;
			}
			goto IL_001f;
		}

		public static List<T> ShallowCopy<T>(List<T> list)
		{
			if (list == null)
			{
				return null;
			}
			int count = list.Count;
			int num2 = default(int);
			List<T> list2 = default(List<T>);
			while (true)
			{
				int num = -1027070983;
				while (true)
				{
					switch (num ^ -1027070984)
					{
					case 3:
						break;
					case 2:
						num2++;
						num = -1027070979;
						continue;
					case 0:
						list2.Add(list[num2]);
						num = -1027070982;
						continue;
					case 4:
						num2 = 0;
						num = -1027070979;
						continue;
					case 1:
						list2 = new List<T>(count);
						num = -1027070980;
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
			if (fromList != null)
			{
				int count2 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = 425516684;
					while (true)
					{
						switch (num ^ 0x195CDE88)
						{
						case 2:
							break;
						case 4:
							goto IL_0043;
						case 7:
							return false;
						case 3:
							count = count2 - fromListStartIndex;
							num = 425516680;
							continue;
						case 9:
							toList.Add(fromList[num2]);
							num2++;
							num = 425516672;
							continue;
						case 0:
							num2 = fromListStartIndex;
							num = 425516672;
							continue;
						case 1:
							goto IL_0094;
						case 5:
							fromListStartIndex = 0;
							num = 425516681;
							continue;
						case 6:
							goto end_IL_0006;
						default:
							if (num2 >= count)
							{
								return true;
							}
							goto case 9;
						}
						break;
						IL_0094:
						if (fromListStartIndex < count2)
						{
							int num3;
							if (count > 0)
							{
								num = 425516680;
								num3 = num;
							}
							else
							{
								num = 425516683;
								num3 = num;
							}
						}
						else
						{
							num = 425516687;
						}
						continue;
						IL_0043:
						if (toList == null)
						{
							num = 425516686;
							continue;
						}
						count2 = fromList.Count;
						int num4;
						if (fromListStartIndex < 0)
						{
							num = 425516685;
							num4 = num;
						}
						else
						{
							num = 425516681;
							num4 = num;
						}
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
			int num2 = default(int);
			while (true)
			{
				int num = 2100663759;
				while (true)
				{
					switch (num ^ 0x7D3595CC)
					{
					case 0:
						break;
					case 3:
						num2 = 0;
						num = 2100663758;
						continue;
					case 1:
						array[num2] = list[num2];
						num2++;
						num = 2100663758;
						continue;
					default:
						if (num2 >= count)
						{
							return array;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public static List<T> Combine<T>(IList<T> list1, IList<T> list2)
		{
			int num = ((list1 != null) ? list1.Count : 0);
			int num2 = ((list2 != null) ? list2.Count : 0);
			int capacity = default(int);
			List<T> list3 = default(List<T>);
			int num5 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num3 = -1335209099;
				while (true)
				{
					switch (num3 ^ -1335209100)
					{
					case 4:
						break;
					case 1:
						capacity = num + num2;
						num3 = -1335209092;
						continue;
					case 8:
						list3 = new List<T>(capacity);
						num5 = 0;
						num3 = -1335209102;
						continue;
					case 5:
						num4 = 0;
						num3 = -1335209101;
						continue;
					case 3:
						list3.Add(list2[num4]);
						num4++;
						num3 = -1335209101;
						continue;
					case 0:
					{
						int num6;
						if (num5 >= num)
						{
							num3 = -1335209103;
							num6 = num3;
						}
						else
						{
							num3 = -1335209098;
							num6 = num3;
						}
						continue;
					}
					case 6:
						num3 = -1335209100;
						continue;
					case 2:
						list3.Add(list1[num5]);
						num5++;
						num3 = -1335209100;
						continue;
					default:
						if (num4 >= num2)
						{
							return list3;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public static bool IsNullOrEmpty<T>(IList<T> list)
		{
			if (list == null)
			{
				goto IL_0003;
			}
			int count = list.Count;
			if (count == 0)
			{
				return true;
			}
			int num;
			int num2 = default(int);
			if (!typeof(T).IsClass)
			{
				num = -1951658795;
			}
			else
			{
				num2 = 0;
				num = -1951658798;
			}
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -1951658799)
				{
				case 0:
					break;
				case 2:
					return true;
				case 4:
					return false;
				case 1:
					if (list[num2] == null)
					{
						goto IL_006a;
					}
					return false;
				default:
					if (num2 >= count)
					{
						return true;
					}
					goto case 1;
				}
				break;
				IL_006a:
				num2++;
				num = -1951658798;
			}
			goto IL_0003;
			IL_0003:
			num = -1951658797;
			goto IL_0008;
		}

		public static List<object> ConvertToObjeclist<T>(IList<T> list)
		{
			List<object> list2 = new List<object>(list.Count);
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < list.Count)
				{
					num2 = -1561416336;
					num3 = num2;
				}
				else
				{
					num2 = -1561416334;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1561416334)
					{
					case 3:
						num2 = -1561416336;
						continue;
					case 2:
						list2.Add(list[num]);
						num++;
						num2 = -1561416333;
						continue;
					case 1:
						break;
					default:
						return list2;
					}
					break;
				}
			}
		}

		public static void Concat<T>(IList<T> list1, IList<T> list2)
		{
			if (list1 != null)
			{
				if (list2 == null)
				{
					goto IL_0006;
				}
				goto IL_0040;
			}
			return;
			IL_0040:
			int num = 0;
			int num2 = -1442816931;
			goto IL_000b;
			IL_0006:
			num2 = -1442816936;
			goto IL_000b;
			IL_000b:
			while (true)
			{
				switch (num2 ^ -1442816929)
				{
				case 5:
					break;
				default:
					return;
				case 7:
					return;
				case 3:
					goto IL_0040;
				case 2:
					num2 = -1442816935;
					continue;
				case 6:
					goto IL_0050;
				case 4:
					num++;
					num2 = -1442816935;
					continue;
				case 0:
					list1.Add(list2[num]);
					num2 = -1442816933;
					continue;
				case 1:
					return;
				}
				break;
				IL_0050:
				int num3;
				if (num >= list2.Count)
				{
					num2 = -1442816930;
					num3 = num2;
				}
				else
				{
					num2 = -1442816929;
					num3 = num2;
				}
			}
			goto IL_0006;
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
				num = -391788865;
				goto IL_0008;
			}
			list.Add(item);
			return true;
			IL_0003:
			num = -391788866;
			goto IL_0008;
			IL_0008:
			switch (num ^ -391788865)
			{
			case 2:
				break;
			case 1:
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
			int num2 = 1471973515;
			goto IL_0008;
			IL_0008:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x57BC888B)
				{
				case 5:
					break;
				case 4:
					return 0;
				case 3:
					if (predicate(list[num3]))
					{
						num++;
						num2 = 1471973514;
						continue;
					}
					goto case 1;
				case 0:
					num3 = 0;
					num2 = 1471973513;
					continue;
				case 1:
					num3++;
					num2 = 1471973513;
					continue;
				default:
					if (num3 >= count)
					{
						return num;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = 1471973519;
			goto IL_0008;
		}

		public static void TryClear<T>(IList<T> list)
		{
			if (list != null)
			{
				list.Clear();
			}
		}

		private static bool HAghDLyHuuvbMYCAXpAPqOvCrJQ<T>(IList<T> P_0, T P_1)
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
				goto IL_000b;
			}
			goto IL_0029;
			IL_0029:
			list.Add(item);
			int num = -51632757;
			goto IL_0010;
			IL_000b:
			num = -51632760;
			goto IL_0010;
			IL_0010:
			switch (num ^ -51632759)
			{
			case 0:
				break;
			case 1:
				goto IL_0029;
			default:
				return list.Count - 1;
			}
			goto IL_000b;
		}
	}
}
