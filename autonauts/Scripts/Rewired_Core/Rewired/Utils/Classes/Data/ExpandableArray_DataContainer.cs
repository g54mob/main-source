using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.auphSZvmhSLQzyipfcVqbmnlOPkA, new()
	{
		public interface auphSZvmhSLQzyipfcVqbmnlOPkA : IComparable<T>
		{
			void Set(T P_0);

			bool Equals(T P_0);

			void Clear();
		}

		public readonly T injector;

		private T[] YDazdhpxhkRnASjKZzmrujnFLma;

		private int NWGopJHdItGKNXQOFtHDGwOkIMN;

		private int JbuDlKulktojTXAdykTTLmIKdv;

		private int LATpNPjYYZidbiLnbOYktGyXtYX;

		private int xiuFCZarCEDAdTGbxCtQnKVvyOtW;

		private bool aONxibLvKBHIHbgsZbzDtWeUkyg;

		public int Count
		{
			get
			{
				return NWGopJHdItGKNXQOFtHDGwOkIMN;
			}
		}

		public int Length
		{
			get
			{
				return NWGopJHdItGKNXQOFtHDGwOkIMN;
			}
		}

		public int MaxLength
		{
			get
			{
				return JbuDlKulktojTXAdykTTLmIKdv;
			}
		}

		public int FreeSpace
		{
			get
			{
				return JbuDlKulktojTXAdykTTLmIKdv - NWGopJHdItGKNXQOFtHDGwOkIMN;
			}
		}

		public T this[int index]
		{
			get
			{
				if (index >= NWGopJHdItGKNXQOFtHDGwOkIMN)
				{
					throw new IndexOutOfRangeException();
				}
				return YDazdhpxhkRnASjKZzmrujnFLma[index];
			}
		}

		public ExpandableArray_DataContainer(int startingMaxLength, bool clearData = true, int expansionIncrement = 0)
		{
			injector = new T();
			YDazdhpxhkRnASjKZzmrujnFLma = new T[startingMaxLength];
			NWGopJHdItGKNXQOFtHDGwOkIMN = 0;
			JbuDlKulktojTXAdykTTLmIKdv = startingMaxLength;
			aONxibLvKBHIHbgsZbzDtWeUkyg = clearData;
			LATpNPjYYZidbiLnbOYktGyXtYX = expansionIncrement;
			for (int i = 0; i < JbuDlKulktojTXAdykTTLmIKdv; i++)
			{
				YDazdhpxhkRnASjKZzmrujnFLma[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (aONxibLvKBHIHbgsZbzDtWeUkyg)
			{
				T val = injector;
				val.Clear();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (aONxibLvKBHIHbgsZbzDtWeUkyg)
			{
				T val = injector;
				val.Clear();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (NWGopJHdItGKNXQOFtHDGwOkIMN >= JbuDlKulktojTXAdykTTLmIKdv)
			{
				goto IL_000e;
			}
			goto IL_003a;
			IL_000e:
			int num = -1446482691;
			goto IL_0013;
			IL_0013:
			int nWGopJHdItGKNXQOFtHDGwOkIMN = default(int);
			while (true)
			{
				switch (num ^ -1446482690)
				{
				case 5:
					break;
				case 4:
					return -1;
				case 0:
					goto IL_0048;
				case 1:
					YDazdhpxhkRnASjKZzmrujnFLma[nWGopJHdItGKNXQOFtHDGwOkIMN].Set(item);
					NWGopJHdItGKNXQOFtHDGwOkIMN = nWGopJHdItGKNXQOFtHDGwOkIMN + 1;
					num = -1446482692;
					continue;
				case 3:
					goto IL_0081;
				default:
					return nWGopJHdItGKNXQOFtHDGwOkIMN;
				}
				break;
				IL_0081:
				int num2;
				if (LATpNPjYYZidbiLnbOYktGyXtYX <= 0)
				{
					num = -1446482694;
					num2 = num;
				}
				else
				{
					num = -1446482690;
					num2 = num;
				}
			}
			goto IL_000e;
			IL_0048:
			vjlFgacNPOdkEQJNSZUjSZSKTuMP();
			goto IL_003a;
			IL_003a:
			nWGopJHdItGKNXQOFtHDGwOkIMN = NWGopJHdItGKNXQOFtHDGwOkIMN;
			num = -1446482689;
			goto IL_0013;
		}

		public int AddIfUnique(T item)
		{
			int num = IndexOfData(item);
			if (num >= 0)
			{
				return num;
			}
			return AddData(item);
		}

		public bool ContainsData(T item)
		{
			int num = 0;
			while (num < NWGopJHdItGKNXQOFtHDGwOkIMN)
			{
				while (true)
				{
					if (YDazdhpxhkRnASjKZzmrujnFLma[num].Equals(item))
					{
						return true;
					}
					num++;
					int num2 = -156024004;
					while (true)
					{
						switch (num2 ^ -156024003)
						{
						case 0:
							num2 = -156024001;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			int num = 0;
			while (num < NWGopJHdItGKNXQOFtHDGwOkIMN)
			{
				while (true)
				{
					if (YDazdhpxhkRnASjKZzmrujnFLma[num].Equals(item))
					{
						return num;
					}
					num++;
					int num2 = -2030909;
					while (true)
					{
						switch (num2 ^ -2030910)
						{
						case 0:
							num2 = -2030912;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (aONxibLvKBHIHbgsZbzDtWeUkyg)
			{
				T val = injector;
				val.Clear();
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < NWGopJHdItGKNXQOFtHDGwOkIMN)
					{
						num2 = -2121221288;
						num3 = num2;
					}
					else
					{
						num2 = -2121221285;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -2121221286)
						{
						case 0:
							num2 = -2121221288;
							continue;
						case 2:
							YDazdhpxhkRnASjKZzmrujnFLma[num].Clear();
							num++;
							num2 = -2121221287;
							continue;
						case 3:
							break;
						default:
							goto end_IL_0066;
						}
						break;
					}
					continue;
					end_IL_0066:
					break;
				}
			}
			NWGopJHdItGKNXQOFtHDGwOkIMN = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0)
			{
				goto IL_00c9;
			}
			if (index >= NWGopJHdItGKNXQOFtHDGwOkIMN)
			{
				goto IL_0013;
			}
			goto IL_00de;
			IL_00fa:
			int num;
			if (aONxibLvKBHIHbgsZbzDtWeUkyg)
			{
				YDazdhpxhkRnASjKZzmrujnFLma[index].Clear();
				num = 1595653375;
				goto IL_0018;
			}
			goto IL_0125;
			IL_0013:
			num = 1595653362;
			goto IL_0018;
			IL_0018:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x5F1BBCFA)
				{
				case 3:
					break;
				case 4:
					goto IL_0054;
				case 2:
					YDazdhpxhkRnASjKZzmrujnFLma[NWGopJHdItGKNXQOFtHDGwOkIMN - 1].Clear();
					num = 1595653360;
					continue;
				case 6:
					YDazdhpxhkRnASjKZzmrujnFLma[num2].Set(YDazdhpxhkRnASjKZzmrujnFLma[num2 + 1]);
					num2++;
					num = 1595653373;
					continue;
				case 8:
					goto IL_00c9;
				case 0:
					goto IL_00de;
				case 9:
					goto IL_00fa;
				case 5:
					goto IL_0125;
				case 7:
					goto IL_0131;
				case 1:
					num = 1595653373;
					continue;
				default:
					NWGopJHdItGKNXQOFtHDGwOkIMN--;
					return;
				}
				break;
				IL_0131:
				int num3;
				if (num2 < NWGopJHdItGKNXQOFtHDGwOkIMN - 1)
				{
					num = 1595653372;
					num3 = num;
				}
				else
				{
					num = 1595653374;
					num3 = num;
				}
				continue;
				IL_0054:
				int num4;
				if (!aONxibLvKBHIHbgsZbzDtWeUkyg)
				{
					num = 1595653360;
					num4 = num;
				}
				else
				{
					num = 1595653368;
					num4 = num;
				}
			}
			goto IL_0013;
			IL_00de:
			if (index == NWGopJHdItGKNXQOFtHDGwOkIMN - 1)
			{
				RemoveLast();
				return;
			}
			goto IL_00fa;
			IL_00c9:
			throw new ArgumentOutOfRangeException("index");
			IL_0125:
			num2 = index;
			num = 1595653371;
			goto IL_0018;
		}

		public void RemoveLast()
		{
			if (NWGopJHdItGKNXQOFtHDGwOkIMN == 0)
			{
				goto IL_0008;
			}
			goto IL_0043;
			IL_0008:
			int num = 1434580750;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x5581F70F)
			{
			case 3:
				break;
			default:
				return;
			case 4:
				goto IL_002e;
			case 2:
				goto IL_0043;
			case 1:
				return;
			case 0:
				return;
			}
			goto IL_0008;
			IL_0043:
			if (aONxibLvKBHIHbgsZbzDtWeUkyg)
			{
				YDazdhpxhkRnASjKZzmrujnFLma[NWGopJHdItGKNXQOFtHDGwOkIMN - 1].Clear();
				num = 1434580747;
				goto IL_000d;
			}
			goto IL_002e;
			IL_002e:
			NWGopJHdItGKNXQOFtHDGwOkIMN--;
			num = 1434580751;
			goto IL_000d;
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			int num4 = default(int);
			while (size != JbuDlKulktojTXAdykTTLmIKdv)
			{
				while (true)
				{
					T[] array = new T[size];
					int num = Math.Min(size, JbuDlKulktojTXAdykTTLmIKdv);
					int num2 = 0;
					int num3 = -1832697706;
					while (true)
					{
						switch (num3 ^ -1832697711)
						{
						case 4:
							num3 = -1832697712;
							continue;
						case 7:
							num3 = -1832697709;
							continue;
						case 8:
							break;
						case 3:
							array[num4] = new T();
							num4++;
							num3 = -1832697708;
							continue;
						case 0:
							if (NWGopJHdItGKNXQOFtHDGwOkIMN > size)
							{
								NWGopJHdItGKNXQOFtHDGwOkIMN = size;
								num3 = -1832697704;
								continue;
							}
							goto default;
						case 1:
							goto end_IL_005a;
						case 5:
							if (num4 >= size)
							{
								num3 = -1832697704;
								continue;
							}
							goto case 3;
						case 10:
							if (size > JbuDlKulktojTXAdykTTLmIKdv)
							{
								num4 = num;
								num3 = -1832697708;
								continue;
							}
							goto case 0;
						case 6:
							array[num2] = YDazdhpxhkRnASjKZzmrujnFLma[num2];
							num2++;
							num3 = -1832697709;
							continue;
						case 2:
							goto IL_0103;
						default:
							JbuDlKulktojTXAdykTTLmIKdv = size;
							YDazdhpxhkRnASjKZzmrujnFLma = array;
							return;
						}
						break;
						IL_0103:
						int num5;
						if (num2 >= num)
						{
							num3 = -1832697701;
							num5 = num3;
						}
						else
						{
							num3 = -1832697705;
							num5 = num3;
						}
					}
					continue;
					end_IL_005a:
					break;
				}
			}
		}

		public void SortAscending()
		{
			if (NWGopJHdItGKNXQOFtHDGwOkIMN == 0)
			{
				return;
			}
			int num3 = default(int);
			T val = default(T);
			while (true)
			{
				int num = 0;
				int num2 = -1480333873;
				while (true)
				{
					switch (num2 ^ -1480333874)
					{
					case 6:
						num2 = -1480333879;
						continue;
					default:
						return;
					case 7:
						break;
					case 1:
					{
						int num4;
						if (num < NWGopJHdItGKNXQOFtHDGwOkIMN - 1)
						{
							num2 = -1480333875;
							num4 = num2;
						}
						else
						{
							num2 = -1480333878;
							num4 = num2;
						}
						continue;
					}
					case 2:
						if (num3 >= NWGopJHdItGKNXQOFtHDGwOkIMN)
						{
							num++;
							num2 = -1480333873;
							continue;
						}
						goto case 0;
					case 8:
						num3++;
						num2 = -1480333876;
						continue;
					case 5:
						YDazdhpxhkRnASjKZzmrujnFLma[num] = YDazdhpxhkRnASjKZzmrujnFLma[num3];
						YDazdhpxhkRnASjKZzmrujnFLma[num3] = val;
						num2 = -1480333882;
						continue;
					case 0:
						if (YDazdhpxhkRnASjKZzmrujnFLma[num3].CompareTo(YDazdhpxhkRnASjKZzmrujnFLma[num]) < 0)
						{
							val = YDazdhpxhkRnASjKZzmrujnFLma[num];
							num2 = -1480333877;
							continue;
						}
						goto case 8;
					case 3:
						num3 = num + 1;
						num2 = -1480333876;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		public void SortDescending()
		{
			if (NWGopJHdItGKNXQOFtHDGwOkIMN == 0)
			{
				goto IL_0008;
			}
			goto IL_0054;
			IL_0008:
			int num = 1383753392;
			goto IL_000d;
			IL_000d:
			int num3 = default(int);
			int num2 = default(int);
			T val = default(T);
			while (true)
			{
				switch (num ^ 0x527A66B4)
				{
				case 5:
					break;
				case 7:
					num3 = num2 + 1;
					num = 1383753399;
					continue;
				case 2:
					goto IL_0054;
				case 1:
					YDazdhpxhkRnASjKZzmrujnFLma[num2] = YDazdhpxhkRnASjKZzmrujnFLma[num3];
					YDazdhpxhkRnASjKZzmrujnFLma[num3] = val;
					num = 1383753396;
					continue;
				case 6:
					if (num3 >= NWGopJHdItGKNXQOFtHDGwOkIMN)
					{
						num2++;
						num = 1383753405;
						continue;
					}
					goto case 10;
				case 0:
					num3++;
					num = 1383753394;
					continue;
				case 10:
					if (YDazdhpxhkRnASjKZzmrujnFLma[num3].CompareTo(YDazdhpxhkRnASjKZzmrujnFLma[num2]) > 0)
					{
						val = YDazdhpxhkRnASjKZzmrujnFLma[num2];
						num = 1383753397;
						continue;
					}
					goto case 0;
				case 4:
					return;
				case 3:
					num = 1383753394;
					continue;
				case 8:
					num = 1383753405;
					continue;
				default:
					if (num2 >= NWGopJHdItGKNXQOFtHDGwOkIMN - 1)
					{
						return;
					}
					goto case 7;
				}
				break;
			}
			goto IL_0008;
			IL_0054:
			num2 = 0;
			num = 1383753404;
			goto IL_000d;
		}

		private void vjlFgacNPOdkEQJNSZUjSZSKTuMP()
		{
			xiuFCZarCEDAdTGbxCtQnKVvyOtW++;
			Resize(JbuDlKulktojTXAdykTTLmIKdv + xiuFCZarCEDAdTGbxCtQnKVvyOtW * LATpNPjYYZidbiLnbOYktGyXtYX);
		}
	}
}
