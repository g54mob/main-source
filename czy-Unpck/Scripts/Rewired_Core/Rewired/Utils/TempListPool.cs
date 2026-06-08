using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class TempListPool
	{
		private static class AHZZFaFSzgphamxWtubgOVBffHj
		{
			private static ADictionary<Type, List<object>> AZdvrkXEJcROMPXXCbgMaGxpNPb;

			private static ADictionary<Type, List<object>> tLists
			{
				get
				{
					if (AZdvrkXEJcROMPXXCbgMaGxpNPb == null)
					{
						return AZdvrkXEJcROMPXXCbgMaGxpNPb = new ADictionary<Type, List<object>>();
					}
					return AZdvrkXEJcROMPXXCbgMaGxpNPb;
				}
			}

			public static TList<T> FoiBapmkfbPotaqLTcsPvTvQPDb<T>(List<T> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("list");
				}
				TList<T> tList = default(TList<T>);
				while (true)
				{
					int num;
					int num2;
					if (!tLists.ContainsKey(typeof(T)))
					{
						num = 1543230975;
						num2 = num;
					}
					else
					{
						num = 1543230973;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x5BFBD5FE)
						{
						case 0:
							num = 1543230972;
							continue;
						case 2:
							break;
						case 1:
							tLists.Add(typeof(T), new List<object>(3));
							num = 1543230973;
							continue;
						case 3:
						{
							List<object> list = tLists[typeof(T)];
							if (list.Count == 0)
							{
								tList = TList<T>.Create();
								((ITListSetter<T>)tList).SetList(P_0);
								num = 1543230970;
								continue;
							}
							int index = list.Count - 1;
							TList<T> tList2 = list[index] as TList<T>;
							list.RemoveAt(index);
							((ITListSetter<T>)tList2).SetList(P_0);
							return tList2;
						}
						default:
							return tList;
						}
						break;
					}
				}
			}

			public static void qEQGTkqPLQHTralpjicnliPsyWSP<T>(TList<T> P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				while (true)
				{
					IL_004c:
					int num;
					if (!tLists.TryGetValue(typeof(T), out var value))
					{
						value = new List<object>(3);
						tLists.Add(typeof(T), value);
						num = 1922166805;
						goto IL_0009;
					}
					goto IL_0032;
					IL_0009:
					while (true)
					{
						switch (num ^ 0x7291F014)
						{
						case 4:
							num = 1922166806;
							continue;
						case 3:
							return;
						case 1:
							break;
						case 2:
							goto IL_004c;
						default:
							ListTools.AddIfUnique(value, P_0);
							return;
						}
						break;
					}
					goto IL_0032;
					IL_0032:
					int num2;
					if (value.Count < 3)
					{
						num = 1922166804;
						num2 = num;
					}
					else
					{
						num = 1922166807;
						num2 = num;
					}
					goto IL_0009;
				}
			}

			public static void tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				AZdvrkXEJcROMPXXCbgMaGxpNPb = null;
			}

			public static void tAgADqjTsMUxSqYXeDyJIdETYRAp(Type P_0)
			{
				if ((object)P_0 == null)
				{
					throw new ArgumentNullException("listType");
				}
				if (AZdvrkXEJcROMPXXCbgMaGxpNPb != null && AZdvrkXEJcROMPXXCbgMaGxpNPb.ContainsKey(P_0))
				{
					AZdvrkXEJcROMPXXCbgMaGxpNPb.Remove(P_0);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal interface ITListSetter<T>
		{
			void SetList(List<T> list);
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal sealed class TList<T> : IDisposable, ITListSetter<T>
		{
			private List<T> AzgbkpBsuARdvmLsMFAITmLDyAKN;

			private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

			public List<T> list
			{
				get
				{
					if (xRygqjRmTtURDPiwlgMmFcdNBrr)
					{
						rJwBYUmDxPTADVmPZvMnVujtNmS();
					}
					return AzgbkpBsuARdvmLsMFAITmLDyAKN;
				}
			}

			public static TList<T> Create()
			{
				return new TList<T>();
			}

			private TList()
			{
			}

			public void Dispose()
			{
				if (!xRygqjRmTtURDPiwlgMmFcdNBrr)
				{
					qEQGTkqPLQHTralpjicnliPsyWSP();
					xRygqjRmTtURDPiwlgMmFcdNBrr = true;
				}
			}

			private void qEQGTkqPLQHTralpjicnliPsyWSP()
			{
				if (AzgbkpBsuARdvmLsMFAITmLDyAKN != null)
				{
					Return(AzgbkpBsuARdvmLsMFAITmLDyAKN);
					goto IL_0013;
				}
				goto IL_0031;
				IL_0031:
				AzgbkpBsuARdvmLsMFAITmLDyAKN = null;
				int num = 2022238189;
				goto IL_0018;
				IL_0013:
				num = 2022238190;
				goto IL_0018;
				IL_0018:
				switch (num ^ 0x7888E7EC)
				{
				case 0:
					break;
				case 2:
					goto IL_0031;
				default:
					AHZZFaFSzgphamxWtubgOVBffHj.qEQGTkqPLQHTralpjicnliPsyWSP(this);
					return;
				}
				goto IL_0013;
			}

			private void ocvVyffqrzRKKSiVnnFSZARMYKq(List<T> P_0)
			{
				AzgbkpBsuARdvmLsMFAITmLDyAKN = P_0;
				xRygqjRmTtURDPiwlgMmFcdNBrr = false;
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in ocvVyffqrzRKKSiVnnFSZARMYKq
				this.ocvVyffqrzRKKSiVnnFSZARMYKq(P_0);
			}

			private static void rJwBYUmDxPTADVmPZvMnVujtNmS()
			{
				throw new Exception("The TList has been disposed.");
			}

			public static implicit operator List<T>(TList<T> obj)
			{
				return obj.list;
			}
		}

		private const int OffEcsFchfOPoVpBFtHPriyRBXh = 3;

		private const int EDAinISttxJcyuBmnveGwONoxcy = 10;

		private static ADictionary<Type, List<IList>> AWNoNSACbTBAMHruDbhrgGwietu;

		private static ADictionary<Type, List<IList>> lists
		{
			get
			{
				if (AWNoNSACbTBAMHruDbhrgGwietu == null)
				{
					return AWNoNSACbTBAMHruDbhrgGwietu = new ADictionary<Type, List<IList>>();
				}
				return AWNoNSACbTBAMHruDbhrgGwietu;
			}
		}

		public static TList<T> GetTList<T>()
		{
			return GetTList<T>(0);
		}

		public static TList<T> GetTList<T>(int capacity)
		{
			return AHZZFaFSzgphamxWtubgOVBffHj.FoiBapmkfbPotaqLTcsPvTvQPDb(Get<T>(capacity));
		}

		public static void ReturnTList<T>(TList<T> tList)
		{
			if (tList == null)
			{
				while (true)
				{
					switch (0x5FDEF70F ^ 0x5FDEF70D)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			tList.Dispose();
		}

		public static List<T> Get<T>()
		{
			return Get<T>(0);
		}

		public static List<T> Get<T>(int capacity)
		{
			if (capacity < 0)
			{
				capacity = 0;
				goto IL_000a;
			}
			goto IL_00a6;
			IL_00a6:
			int num;
			int num2;
			if (!lists.ContainsKey(typeof(T)))
			{
				num = 1908794512;
				num2 = num;
			}
			else
			{
				num = 1908794516;
				num2 = num;
			}
			goto IL_000f;
			IL_000a:
			num = 1908794526;
			goto IL_000f;
			IL_000f:
			int num4 = default(int);
			int capacity3 = default(int);
			int index2 = default(int);
			int num3 = default(int);
			List<T> result = default(List<T>);
			List<IList> list2 = default(List<IList>);
			List<T> result2 = default(List<T>);
			int index = default(int);
			int count = default(int);
			while (true)
			{
				int capacity2;
				switch (num ^ 0x71C5E496)
				{
				case 13:
					break;
				case 14:
					goto IL_0063;
				case 5:
					num4 = capacity3;
					index2 = num3;
					num = 1908794514;
					continue;
				case 7:
					return result;
				case 8:
					goto IL_00a6;
				case 10:
					num = 1908794519;
					continue;
				case 16:
					capacity2 = capacity;
					goto IL_00df;
				case 3:
					result2 = list2[num3] as List<T>;
					capacity3 = result2.Capacity;
					num = 1908794520;
					continue;
				case 12:
					result2 = list2[index2] as List<T>;
					list2.RemoveAt(index2);
					return result2;
				case 6:
					lists.Add(typeof(T), new List<IList>(3));
					num = 1908794516;
					continue;
				case 0:
					if (capacity == 0)
					{
						capacity2 = 10;
						goto IL_00df;
					}
					num = 1908794502;
					continue;
				case 4:
					goto IL_016f;
				case 2:
					goto IL_018e;
				case 11:
					num3 = 0;
					num = 1908794524;
					continue;
				case 9:
					index2 = -1;
					num = 1908794525;
					continue;
				case 1:
					goto IL_01d2;
				default:
					{
						IList list = list2[index];
						list2.RemoveAt(index);
						return list as List<T>;
					}
					IL_00df:
					result = new List<T>(capacity2);
					num = 1908794513;
					continue;
				}
				break;
				IL_01d2:
				int num5;
				if (num3 < count)
				{
					num = 1908794517;
					num5 = num;
				}
				else
				{
					num = 1908794522;
					num5 = num;
				}
				continue;
				IL_016f:
				if (capacity3 >= capacity)
				{
					list2.RemoveAt(num3);
					return result2;
				}
				num3++;
				num = 1908794519;
				continue;
				IL_0063:
				int num6;
				if (capacity3 > num4)
				{
					num = 1908794515;
					num6 = num;
				}
				else
				{
					num = 1908794514;
					num6 = num;
				}
				continue;
				IL_018e:
				list2 = lists[typeof(T)];
				if (list2.Count != 0)
				{
					if (capacity > 0)
					{
						count = list2.Count;
						num4 = -1;
						num = 1908794527;
					}
					else
					{
						index = list2.Count - 1;
						num = 1908794521;
					}
				}
				else
				{
					num = 1908794518;
				}
			}
			goto IL_000a;
		}

		public static void Return<T>(List<T> list)
		{
			if (list == null)
			{
				goto IL_0003;
			}
			goto IL_0079;
			IL_0003:
			int num = 424459081;
			goto IL_0008;
			IL_0008:
			List<IList> value = default(List<IList>);
			while (true)
			{
				switch (num ^ 0x194CBB4A)
				{
				case 0:
					break;
				case 1:
					return;
				case 2:
					goto IL_003c;
				case 6:
					value = new List<IList>(3);
					lists.Add(typeof(T), value);
					num = 424459080;
					continue;
				case 5:
					goto IL_0079;
				case 3:
					return;
				default:
					ListTools.AddIfUnique(value, list);
					return;
				}
				break;
				IL_003c:
				int num2;
				if (value.Count < 3)
				{
					num = 424459086;
					num2 = num;
				}
				else
				{
					num = 424459083;
					num2 = num;
				}
			}
			goto IL_0003;
			IL_0079:
			list.Clear();
			int num3;
			if (!lists.TryGetValue(typeof(T), out value))
			{
				num = 424459084;
				num3 = num;
			}
			else
			{
				num = 424459080;
				num3 = num;
			}
			goto IL_0008;
		}

		public static void Return<T>(List<T> list1, List<T> list2)
		{
			Return(list1);
			while (true)
			{
				int num = -481754922;
				while (true)
				{
					switch (num ^ -481754921)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 2:
						return;
					}
					break;
					IL_0024:
					Return(list2);
					num = -481754923;
				}
			}
		}

		public static void Return<T>(List<T> list1, List<T> list2, List<T> list3)
		{
			Return(list1);
			Return(list2);
			while (true)
			{
				int num = 1582629387;
				while (true)
				{
					switch (num ^ 0x5E55020A)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002a;
					case 2:
						return;
					}
					break;
					IL_002a:
					Return(list3);
					num = 1582629384;
				}
			}
		}

		public static void Clear()
		{
			AWNoNSACbTBAMHruDbhrgGwietu = null;
			AHZZFaFSzgphamxWtubgOVBffHj.tAgADqjTsMUxSqYXeDyJIdETYRAp();
		}

		public static void Clear(Type listType)
		{
			if ((object)listType == null)
			{
				throw new ArgumentNullException("listType");
			}
			while (AWNoNSACbTBAMHruDbhrgGwietu != null)
			{
				while (true)
				{
					IL_0043:
					if (!AWNoNSACbTBAMHruDbhrgGwietu.ContainsKey(listType))
					{
						return;
					}
					while (true)
					{
						IL_0058:
						AWNoNSACbTBAMHruDbhrgGwietu.Remove(listType);
						int num = 1219745445;
						while (true)
						{
							switch (num ^ 0x48B3D6A7)
							{
							case 0:
								num = 1219745446;
								continue;
							case 1:
								break;
							case 4:
								goto IL_0043;
							case 3:
								goto IL_0058;
							default:
								AHZZFaFSzgphamxWtubgOVBffHj.tAgADqjTsMUxSqYXeDyJIdETYRAp(listType);
								return;
							}
							break;
						}
						break;
					}
					break;
				}
			}
		}
	}
}
