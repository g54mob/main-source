using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.ZPnzQWPSCKPnqDDCowtxaBJeUJZ, new()
	{
		public interface ZPnzQWPSCKPnqDDCowtxaBJeUJZ : IComparable<T>
		{
			void dhodbseVbYqPVvdUgNSOeWdaMYFi(T P_0);

			bool hSULUfLJyWOzNdtzWOfXzAtyCXP(T P_0);

			void tAgADqjTsMUxSqYXeDyJIdETYRAp();
		}

		public readonly T injector;

		private T[] lHkKGuRVUujSXfGbWAKucaVOVCTV;

		private int sDKjLQbtrbzBMeqpEsGMrKcvbPyq;

		private int kQbScyOnUgGnkCebyZFMeXGVocGI;

		private int qWHaNKRXlVcJsJFAidOprfIMPMw;

		private int AgqbrSDFfWFucnPEuEfJOdbmJVE;

		private bool ZnXGKgdqrLIIUMxZWMCShNEHdjN;

		public int Count => sDKjLQbtrbzBMeqpEsGMrKcvbPyq;

		public int Length => sDKjLQbtrbzBMeqpEsGMrKcvbPyq;

		public int MaxLength => kQbScyOnUgGnkCebyZFMeXGVocGI;

		public int FreeSpace => kQbScyOnUgGnkCebyZFMeXGVocGI - sDKjLQbtrbzBMeqpEsGMrKcvbPyq;

		public T this[int index]
		{
			get
			{
				if (index >= sDKjLQbtrbzBMeqpEsGMrKcvbPyq)
				{
					throw new IndexOutOfRangeException();
				}
				return lHkKGuRVUujSXfGbWAKucaVOVCTV[index];
			}
		}

		public ExpandableArray_DataContainer(int startingMaxLength, bool clearData = true, int expansionIncrement = 0)
		{
			int num2 = default(int);
			while (true)
			{
				int num = -350761709;
				while (true)
				{
					switch (num ^ -350761706)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						lHkKGuRVUujSXfGbWAKucaVOVCTV[num2] = new T();
						num2++;
						num = -350761707;
						continue;
					case 4:
						qWHaNKRXlVcJsJFAidOprfIMPMw = expansionIncrement;
						num2 = 0;
						num = -350761707;
						continue;
					case 0:
						lHkKGuRVUujSXfGbWAKucaVOVCTV = new T[startingMaxLength];
						sDKjLQbtrbzBMeqpEsGMrKcvbPyq = 0;
						kQbScyOnUgGnkCebyZFMeXGVocGI = startingMaxLength;
						ZnXGKgdqrLIIUMxZWMCShNEHdjN = clearData;
						num = -350761710;
						continue;
					case 5:
						injector = new T();
						num = -350761706;
						continue;
					case 3:
					{
						int num3;
						if (num2 < kQbScyOnUgGnkCebyZFMeXGVocGI)
						{
							num = -350761705;
							num3 = num;
						}
						else
						{
							num = -350761712;
							num3 = num;
						}
						continue;
					}
					case 6:
						return;
					}
					break;
				}
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (ZnXGKgdqrLIIUMxZWMCShNEHdjN)
			{
				T val = injector;
				val.tAgADqjTsMUxSqYXeDyJIdETYRAp();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (ZnXGKgdqrLIIUMxZWMCShNEHdjN)
			{
				T val = injector;
				val.tAgADqjTsMUxSqYXeDyJIdETYRAp();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (sDKjLQbtrbzBMeqpEsGMrKcvbPyq >= kQbScyOnUgGnkCebyZFMeXGVocGI)
			{
				while (true)
				{
					int num = -765079979;
					while (true)
					{
						switch (num ^ -765079980)
						{
						case 0:
							break;
						case 1:
							goto IL_0034;
						case 3:
							AHjPkxlAqMtWLsPuFtPiTZkTlbp();
							num = -765079984;
							continue;
						default:
							return -1;
						case 4:
							goto end_IL_000e;
						}
						break;
						IL_0034:
						int num2;
						if (qWHaNKRXlVcJsJFAidOprfIMPMw > 0)
						{
							num = -765079977;
							num2 = num;
						}
						else
						{
							num = -765079978;
							num2 = num;
						}
					}
					continue;
					end_IL_000e:
					break;
				}
			}
			int num3 = sDKjLQbtrbzBMeqpEsGMrKcvbPyq;
			lHkKGuRVUujSXfGbWAKucaVOVCTV[num3].dhodbseVbYqPVvdUgNSOeWdaMYFi(item);
			sDKjLQbtrbzBMeqpEsGMrKcvbPyq = num3 + 1;
			return num3;
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
			while (num < sDKjLQbtrbzBMeqpEsGMrKcvbPyq)
			{
				while (true)
				{
					if (lHkKGuRVUujSXfGbWAKucaVOVCTV[num].hSULUfLJyWOzNdtzWOfXzAtyCXP(item))
					{
						return true;
					}
					num++;
					int num2 = 1703767692;
					while (true)
					{
						switch (num2 ^ 0x658D6E8E)
						{
						case 0:
							num2 = 1703767695;
							continue;
						case 1:
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
			while (true)
			{
				int num2 = 763478456;
				while (true)
				{
					switch (num2 ^ 0x2D81C1BB)
					{
					case 4:
						break;
					case 3:
						num2 = 763478458;
						continue;
					case 2:
						if (lHkKGuRVUujSXfGbWAKucaVOVCTV[num].hSULUfLJyWOzNdtzWOfXzAtyCXP(item))
						{
							return num;
						}
						num++;
						num2 = 763478458;
						continue;
					case 1:
					{
						int num3;
						if (num >= sDKjLQbtrbzBMeqpEsGMrKcvbPyq)
						{
							num2 = 763478459;
							num3 = num2;
						}
						else
						{
							num2 = 763478457;
							num3 = num2;
						}
						continue;
					}
					default:
						return -1;
					}
					break;
				}
			}
		}

		public void Clear()
		{
			if (ZnXGKgdqrLIIUMxZWMCShNEHdjN)
			{
				T val = injector;
				val.tAgADqjTsMUxSqYXeDyJIdETYRAp();
				int num2 = default(int);
				while (true)
				{
					int num = 237739425;
					while (true)
					{
						switch (num ^ 0xE2B9DA2)
						{
						case 0:
							break;
						case 3:
							num2 = 0;
							num = 237739424;
							continue;
						case 2:
							goto IL_004e;
						case 1:
							lHkKGuRVUujSXfGbWAKucaVOVCTV[num2].tAgADqjTsMUxSqYXeDyJIdETYRAp();
							num2++;
							num = 237739424;
							continue;
						default:
							goto end_IL_001f;
						}
						break;
						IL_004e:
						int num3;
						if (num2 >= sDKjLQbtrbzBMeqpEsGMrKcvbPyq)
						{
							num = 237739430;
							num3 = num;
						}
						else
						{
							num = 237739427;
							num3 = num;
						}
					}
					continue;
					end_IL_001f:
					break;
				}
			}
			sDKjLQbtrbzBMeqpEsGMrKcvbPyq = 0;
		}

		public void RemoveAt(int index)
		{
			if (index >= 0)
			{
				if (index >= sDKjLQbtrbzBMeqpEsGMrKcvbPyq)
				{
					goto IL_0013;
				}
				goto IL_00ca;
			}
			goto IL_00e6;
			IL_00ae:
			int num;
			int num2;
			if (!ZnXGKgdqrLIIUMxZWMCShNEHdjN)
			{
				num = 45713329;
				num2 = num;
			}
			else
			{
				num = 45713336;
				num2 = num;
			}
			goto IL_0018;
			IL_0013:
			num = 45713328;
			goto IL_0018;
			IL_0018:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x2B987B8)
				{
				case 6:
					break;
				case 0:
					lHkKGuRVUujSXfGbWAKucaVOVCTV[index].tAgADqjTsMUxSqYXeDyJIdETYRAp();
					num = 45713329;
					continue;
				case 9:
					num3 = index;
					num = 45713343;
					continue;
				case 10:
				{
					ref readonly T reference = ref lHkKGuRVUujSXfGbWAKucaVOVCTV[num3];
					T val = lHkKGuRVUujSXfGbWAKucaVOVCTV[num3 + 1];
					reference.dhodbseVbYqPVvdUgNSOeWdaMYFi(val);
					num = 45713341;
					continue;
				}
				case 2:
					goto IL_00ae;
				case 1:
					goto IL_00ca;
				case 8:
					goto IL_00e6;
				case 5:
					num3++;
					num = 45713343;
					continue;
				case 3:
					if (ZnXGKgdqrLIIUMxZWMCShNEHdjN)
					{
						lHkKGuRVUujSXfGbWAKucaVOVCTV[sDKjLQbtrbzBMeqpEsGMrKcvbPyq - 1].tAgADqjTsMUxSqYXeDyJIdETYRAp();
						num = 45713340;
						continue;
					}
					goto default;
				case 7:
					goto IL_013b;
				default:
					sDKjLQbtrbzBMeqpEsGMrKcvbPyq--;
					return;
				}
				break;
				IL_013b:
				int num4;
				if (num3 >= sDKjLQbtrbzBMeqpEsGMrKcvbPyq - 1)
				{
					num = 45713339;
					num4 = num;
				}
				else
				{
					num = 45713330;
					num4 = num;
				}
			}
			goto IL_0013;
			IL_00e6:
			throw new ArgumentOutOfRangeException("index");
			IL_00ca:
			if (index == sDKjLQbtrbzBMeqpEsGMrKcvbPyq - 1)
			{
				RemoveLast();
				return;
			}
			goto IL_00ae;
		}

		public void RemoveLast()
		{
			if (sDKjLQbtrbzBMeqpEsGMrKcvbPyq == 0)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -817805713;
			goto IL_000d;
			IL_000d:
			switch (num ^ -817805714)
			{
			case 0:
				break;
			case 1:
				return;
			case 2:
				goto IL_0032;
			default:
				goto IL_0061;
			}
			goto IL_0008;
			IL_0032:
			if (ZnXGKgdqrLIIUMxZWMCShNEHdjN)
			{
				lHkKGuRVUujSXfGbWAKucaVOVCTV[sDKjLQbtrbzBMeqpEsGMrKcvbPyq - 1].tAgADqjTsMUxSqYXeDyJIdETYRAp();
				num = -817805715;
				goto IL_000d;
			}
			goto IL_0061;
			IL_0061:
			sDKjLQbtrbzBMeqpEsGMrKcvbPyq--;
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				goto IL_0007;
			}
			goto IL_00fe;
			IL_0007:
			int num = -1146284521;
			goto IL_000c;
			IL_000c:
			int num3 = default(int);
			int num2 = default(int);
			int num4 = default(int);
			T[] array = default(T[]);
			while (true)
			{
				switch (num ^ -1146284517)
				{
				case 3:
					break;
				case 4:
					if (num3 >= num2)
					{
						goto IL_005b;
					}
					goto case 9;
				case 6:
					goto IL_0075;
				case 13:
					return;
				case 12:
					throw new Exception("Size must be greater than 0.");
				case 5:
					num4++;
					num = -1146284517;
					continue;
				case 8:
					num4 = num2;
					num = -1146284517;
					continue;
				case 1:
					sDKjLQbtrbzBMeqpEsGMrKcvbPyq = size;
					num = -1146284516;
					continue;
				case 9:
					array[num3] = lHkKGuRVUujSXfGbWAKucaVOVCTV[num3];
					num3++;
					num = -1146284513;
					continue;
				case 10:
					goto IL_00fe;
				case 0:
					if (num4 >= size)
					{
						num = -1146284516;
						continue;
					}
					goto case 11;
				case 11:
					array[num4] = new T();
					num = -1146284514;
					continue;
				case 2:
					array = new T[size];
					num2 = Math.Min(size, kQbScyOnUgGnkCebyZFMeXGVocGI);
					num3 = 0;
					num = -1146284513;
					continue;
				default:
					kQbScyOnUgGnkCebyZFMeXGVocGI = size;
					lHkKGuRVUujSXfGbWAKucaVOVCTV = array;
					return;
				}
				break;
				IL_0075:
				int num5;
				if (sDKjLQbtrbzBMeqpEsGMrKcvbPyq <= size)
				{
					num = -1146284516;
					num5 = num;
				}
				else
				{
					num = -1146284518;
					num5 = num;
				}
				continue;
				IL_005b:
				int num6;
				if (size <= kQbScyOnUgGnkCebyZFMeXGVocGI)
				{
					num = -1146284515;
					num6 = num;
				}
				else
				{
					num = -1146284525;
					num6 = num;
				}
			}
			goto IL_0007;
			IL_00fe:
			int num7;
			if (size != kQbScyOnUgGnkCebyZFMeXGVocGI)
			{
				num = -1146284519;
				num7 = num;
			}
			else
			{
				num = -1146284522;
				num7 = num;
			}
			goto IL_000c;
		}

		public void SortAscending()
		{
			if (sDKjLQbtrbzBMeqpEsGMrKcvbPyq == 0)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				int num = 0;
				int num2 = -290882768;
				while (true)
				{
					switch (num2 ^ -290882765)
					{
					case 0:
						num2 = -290882761;
						continue;
					case 5:
						num3++;
						num2 = -290882767;
						continue;
					case 7:
					{
						ref readonly T reference = ref lHkKGuRVUujSXfGbWAKucaVOVCTV[num3];
						T other = lHkKGuRVUujSXfGbWAKucaVOVCTV[num];
						if (reference.CompareTo(other) < 0)
						{
							T val = lHkKGuRVUujSXfGbWAKucaVOVCTV[num];
							lHkKGuRVUujSXfGbWAKucaVOVCTV[num] = lHkKGuRVUujSXfGbWAKucaVOVCTV[num3];
							lHkKGuRVUujSXfGbWAKucaVOVCTV[num3] = val;
							num2 = -290882762;
							continue;
						}
						goto case 5;
					}
					case 4:
						break;
					case 3:
						num2 = -290882766;
						continue;
					case 6:
						num3 = num + 1;
						num2 = -290882767;
						continue;
					case 2:
						if (num3 >= sDKjLQbtrbzBMeqpEsGMrKcvbPyq)
						{
							num++;
							num2 = -290882766;
							continue;
						}
						goto case 7;
					default:
						if (num >= sDKjLQbtrbzBMeqpEsGMrKcvbPyq - 1)
						{
							return;
						}
						goto case 6;
					}
					break;
				}
			}
		}

		public void SortDescending()
		{
			if (sDKjLQbtrbzBMeqpEsGMrKcvbPyq == 0)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				int num = 0;
				int num2 = 604356461;
				while (true)
				{
					switch (num2 ^ 0x2405BF6D)
					{
					case 2:
						num2 = 604356462;
						continue;
					case 7:
						num3++;
						num2 = 604356453;
						continue;
					case 1:
					{
						ref readonly T reference = ref lHkKGuRVUujSXfGbWAKucaVOVCTV[num3];
						T other = lHkKGuRVUujSXfGbWAKucaVOVCTV[num];
						if (reference.CompareTo(other) > 0)
						{
							T val = lHkKGuRVUujSXfGbWAKucaVOVCTV[num];
							lHkKGuRVUujSXfGbWAKucaVOVCTV[num] = lHkKGuRVUujSXfGbWAKucaVOVCTV[num3];
							lHkKGuRVUujSXfGbWAKucaVOVCTV[num3] = val;
							num2 = 604356458;
							continue;
						}
						goto case 7;
					}
					case 0:
						num2 = 604356459;
						continue;
					case 5:
						num3 = num + 1;
						num2 = 604356457;
						continue;
					case 4:
						num2 = 604356453;
						continue;
					case 8:
						if (num3 >= sDKjLQbtrbzBMeqpEsGMrKcvbPyq)
						{
							num++;
							num2 = 604356459;
							continue;
						}
						goto case 1;
					case 3:
						break;
					default:
						if (num >= sDKjLQbtrbzBMeqpEsGMrKcvbPyq - 1)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		private void AHjPkxlAqMtWLsPuFtPiTZkTlbp()
		{
			AgqbrSDFfWFucnPEuEfJOdbmJVE++;
			Resize(kQbScyOnUgGnkCebyZFMeXGVocGI + AgqbrSDFfWFucnPEuEfJOdbmJVE * qWHaNKRXlVcJsJFAidOprfIMPMw);
		}
	}
}
