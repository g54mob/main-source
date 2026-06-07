using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.NQrrZCNstUmxUQSuHmBoRPhtvSn, new()
	{
		public interface NQrrZCNstUmxUQSuHmBoRPhtvSn : IComparable<T>
		{
			void Set(T P_0);

			bool Equals(T P_0);

			void Clear();
		}

		public readonly T injector;

		private T[] jwgCcmBYxaMijibFhczhZuzBgQli;

		private int aaSveCvGzpfewhVzbfsVbGOoRCA;

		private int qlnKBuUEnsFEOxxHPudNoUqSmeg;

		private int yIDFKKLsKRnIWKUcXAUmIxiDJTE;

		private int EzkYZCBhQIFtEerwPtbObWJfCDm;

		private bool DODwGazFOHiscNRtvYvPKEuOubt;

		public int Count
		{
			get
			{
				return aaSveCvGzpfewhVzbfsVbGOoRCA;
			}
		}

		public int Length
		{
			get
			{
				return aaSveCvGzpfewhVzbfsVbGOoRCA;
			}
		}

		public int MaxLength
		{
			get
			{
				return qlnKBuUEnsFEOxxHPudNoUqSmeg;
			}
		}

		public int FreeSpace
		{
			get
			{
				return qlnKBuUEnsFEOxxHPudNoUqSmeg - aaSveCvGzpfewhVzbfsVbGOoRCA;
			}
		}

		public T this[int index]
		{
			get
			{
				if (index >= aaSveCvGzpfewhVzbfsVbGOoRCA)
				{
					throw new IndexOutOfRangeException();
				}
				return jwgCcmBYxaMijibFhczhZuzBgQli[index];
			}
		}

		public ExpandableArray_DataContainer(int startingMaxLength, bool clearData = true, int expansionIncrement = 0)
		{
			injector = new T();
			jwgCcmBYxaMijibFhczhZuzBgQli = new T[startingMaxLength];
			aaSveCvGzpfewhVzbfsVbGOoRCA = 0;
			qlnKBuUEnsFEOxxHPudNoUqSmeg = startingMaxLength;
			DODwGazFOHiscNRtvYvPKEuOubt = clearData;
			yIDFKKLsKRnIWKUcXAUmIxiDJTE = expansionIncrement;
			for (int i = 0; i < qlnKBuUEnsFEOxxHPudNoUqSmeg; i++)
			{
				jwgCcmBYxaMijibFhczhZuzBgQli[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (DODwGazFOHiscNRtvYvPKEuOubt)
			{
				T val = default(T);
				while (true)
				{
					int num = 369895858;
					while (true)
					{
						switch (num ^ 0x160C29B1)
						{
						case 2:
							break;
						case 3:
							val = injector;
							num = 369895857;
							continue;
						case 0:
							val.Clear();
							num = 369895856;
							continue;
						default:
							goto end_IL_0015;
						}
						break;
					}
					continue;
					end_IL_0015:
					break;
				}
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			T val = default(T);
			while (true)
			{
				int num = 988480783;
				while (true)
				{
					switch (num ^ 0x3AEB050E)
					{
					case 0:
						break;
					case 1:
						if (DODwGazFOHiscNRtvYvPKEuOubt)
						{
							val = injector;
							num = 988480780;
							continue;
						}
						goto default;
					case 2:
						val.Clear();
						num = 988480781;
						continue;
					default:
						return result;
					}
					break;
				}
			}
		}

		public int AddData(T item)
		{
			if (aaSveCvGzpfewhVzbfsVbGOoRCA >= qlnKBuUEnsFEOxxHPudNoUqSmeg)
			{
				if (yIDFKKLsKRnIWKUcXAUmIxiDJTE > 0)
				{
					goto IL_0017;
				}
				goto IL_0048;
			}
			goto IL_004a;
			IL_004a:
			int num = aaSveCvGzpfewhVzbfsVbGOoRCA;
			jwgCcmBYxaMijibFhczhZuzBgQli[num].Set(item);
			int num2 = 373482842;
			goto IL_001c;
			IL_0017:
			num2 = 373482840;
			goto IL_001c;
			IL_001c:
			switch (num2 ^ 0x1642E559)
			{
			case 2:
				break;
			case 1:
				goto IL_0039;
			case 0:
				goto IL_0048;
			default:
				aaSveCvGzpfewhVzbfsVbGOoRCA = num + 1;
				return num;
			}
			goto IL_0017;
			IL_0048:
			return -1;
			IL_0039:
			OanAfnbpDCtDnEnWdkOfeiCXKjVz();
			goto IL_004a;
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
			while (true)
			{
				int num2;
				int num3;
				if (num < aaSveCvGzpfewhVzbfsVbGOoRCA)
				{
					num2 = 1192417614;
					num3 = num2;
				}
				else
				{
					num2 = 1192417613;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x4712D94F)
					{
					case 0:
						num2 = 1192417614;
						continue;
					case 1:
						if (jwgCcmBYxaMijibFhczhZuzBgQli[num].Equals(item))
						{
							return true;
						}
						num++;
						num2 = 1192417612;
						continue;
					case 3:
						break;
					default:
						return false;
					}
					break;
				}
			}
		}

		public int IndexOfData(T item)
		{
			int num = 0;
			while (num < aaSveCvGzpfewhVzbfsVbGOoRCA)
			{
				while (true)
				{
					int num2;
					if (jwgCcmBYxaMijibFhczhZuzBgQli[num].Equals(item))
					{
						num2 = -1902324608;
					}
					else
					{
						num++;
						num2 = -1902324606;
					}
					while (true)
					{
						switch (num2 ^ -1902324606)
						{
						case 3:
							num2 = -1902324605;
							continue;
						case 1:
							break;
						case 2:
							return num;
						default:
							goto end_IL_0026;
						}
						break;
					}
					continue;
					end_IL_0026:
					break;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (DODwGazFOHiscNRtvYvPKEuOubt)
			{
				int num2 = default(int);
				T val = default(T);
				while (true)
				{
					int num = -2136384721;
					while (true)
					{
						switch (num ^ -2136384726)
						{
						case 0:
							break;
						case 3:
							goto IL_0035;
						case 4:
							jwgCcmBYxaMijibFhczhZuzBgQli[num2].Clear();
							num2++;
							num = -2136384727;
							continue;
						case 1:
							val.Clear();
							num2 = 0;
							num = -2136384727;
							continue;
						case 5:
							val = injector;
							num = -2136384725;
							continue;
						default:
							goto end_IL_000b;
						}
						break;
						IL_0035:
						int num3;
						if (num2 < aaSveCvGzpfewhVzbfsVbGOoRCA)
						{
							num = -2136384722;
							num3 = num;
						}
						else
						{
							num = -2136384728;
							num3 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			aaSveCvGzpfewhVzbfsVbGOoRCA = 0;
		}

		public void RemoveAt(int index)
		{
			if (index >= 0)
			{
				if (index >= aaSveCvGzpfewhVzbfsVbGOoRCA)
				{
					goto IL_0010;
				}
				goto IL_006d;
			}
			goto IL_008f;
			IL_008f:
			throw new ArgumentOutOfRangeException("index");
			IL_0010:
			int num = 919892111;
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x36D4708E)
				{
				case 8:
					break;
				default:
					return;
				case 2:
					aaSveCvGzpfewhVzbfsVbGOoRCA--;
					num = 919892106;
					continue;
				case 7:
					num2++;
					num = 919892110;
					continue;
				case 5:
					goto IL_006d;
				case 9:
					goto IL_0086;
				case 1:
					goto IL_008f;
				case 6:
					goto IL_00a4;
				case 0:
					if (num2 >= aaSveCvGzpfewhVzbfsVbGOoRCA - 1)
					{
						if (DODwGazFOHiscNRtvYvPKEuOubt)
						{
							jwgCcmBYxaMijibFhczhZuzBgQli[aaSveCvGzpfewhVzbfsVbGOoRCA - 1].Clear();
							num = 919892108;
							continue;
						}
						goto case 2;
					}
					goto case 3;
				case 3:
					jwgCcmBYxaMijibFhczhZuzBgQli[num2].Set(jwgCcmBYxaMijibFhczhZuzBgQli[num2 + 1]);
					num = 919892105;
					continue;
				case 4:
					return;
				}
				break;
			}
			goto IL_0010;
			IL_0086:
			num2 = index;
			num = 919892110;
			goto IL_0015;
			IL_006d:
			if (index == aaSveCvGzpfewhVzbfsVbGOoRCA - 1)
			{
				RemoveLast();
				return;
			}
			goto IL_00a4;
			IL_00a4:
			if (DODwGazFOHiscNRtvYvPKEuOubt)
			{
				jwgCcmBYxaMijibFhczhZuzBgQli[index].Clear();
				num = 919892103;
				goto IL_0015;
			}
			goto IL_0086;
		}

		public void RemoveLast()
		{
			if (aaSveCvGzpfewhVzbfsVbGOoRCA == 0)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 1347299219;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x504E2790)
			{
			case 2:
				break;
			case 3:
				return;
			case 0:
				goto IL_0032;
			default:
				goto IL_0061;
			}
			goto IL_0008;
			IL_0032:
			if (DODwGazFOHiscNRtvYvPKEuOubt)
			{
				jwgCcmBYxaMijibFhczhZuzBgQli[aaSveCvGzpfewhVzbfsVbGOoRCA - 1].Clear();
				num = 1347299217;
				goto IL_000d;
			}
			goto IL_0061;
			IL_0061:
			aaSveCvGzpfewhVzbfsVbGOoRCA--;
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			int num4 = default(int);
			while (size != qlnKBuUEnsFEOxxHPudNoUqSmeg)
			{
				while (true)
				{
					IL_00ff:
					T[] array = new T[size];
					int num = Math.Min(size, qlnKBuUEnsFEOxxHPudNoUqSmeg);
					int num2 = 0;
					int num3 = 1384316721;
					while (true)
					{
						switch (num3 ^ 0x5282FF32)
						{
						case 9:
							num3 = 1384316724;
							continue;
						case 1:
							break;
						case 0:
							array[num4] = new T();
							num4++;
							num3 = 1384316723;
							continue;
						case 8:
							if (aaSveCvGzpfewhVzbfsVbGOoRCA > size)
							{
								aaSveCvGzpfewhVzbfsVbGOoRCA = size;
								num3 = 1384316725;
								continue;
							}
							goto case 7;
						case 10:
							num3 = 1384316725;
							continue;
						case 3:
							if (num2 >= num)
							{
								if (size > qlnKBuUEnsFEOxxHPudNoUqSmeg)
								{
									num4 = num;
									num3 = 1384316723;
									continue;
								}
								goto case 8;
							}
							goto case 5;
						case 6:
							goto end_IL_0017;
						case 7:
							qlnKBuUEnsFEOxxHPudNoUqSmeg = size;
							num3 = 1384316720;
							continue;
						case 5:
							array[num2] = jwgCcmBYxaMijibFhczhZuzBgQli[num2];
							num2++;
							num3 = 1384316721;
							continue;
						case 4:
							goto IL_00ff;
						default:
							jwgCcmBYxaMijibFhczhZuzBgQli = array;
							return;
						}
						int num5;
						if (num4 < size)
						{
							num3 = 1384316722;
							num5 = num3;
						}
						else
						{
							num3 = 1384316728;
							num5 = num3;
						}
						continue;
						end_IL_0017:
						break;
					}
					break;
				}
			}
		}

		public void SortAscending()
		{
			if (aaSveCvGzpfewhVzbfsVbGOoRCA == 0)
			{
				return;
			}
			int num3 = default(int);
			T val = default(T);
			while (true)
			{
				int num = 0;
				int num2 = 42971207;
				while (true)
				{
					switch (num2 ^ 0x28FB046)
					{
					case 3:
						num2 = 42971214;
						continue;
					case 2:
					{
						int num4;
						if (jwgCcmBYxaMijibFhczhZuzBgQli[num3].CompareTo(jwgCcmBYxaMijibFhczhZuzBgQli[num]) < 0)
						{
							num2 = 42971203;
							num4 = num2;
						}
						else
						{
							num2 = 42971206;
							num4 = num2;
						}
						continue;
					}
					case 0:
						num3++;
						num2 = 42971200;
						continue;
					case 8:
						break;
					case 6:
						if (num3 >= aaSveCvGzpfewhVzbfsVbGOoRCA)
						{
							num++;
							num2 = 42971207;
							continue;
						}
						goto case 2;
					case 4:
						jwgCcmBYxaMijibFhczhZuzBgQli[num3] = val;
						num2 = 42971206;
						continue;
					case 5:
						val = jwgCcmBYxaMijibFhczhZuzBgQli[num];
						jwgCcmBYxaMijibFhczhZuzBgQli[num] = jwgCcmBYxaMijibFhczhZuzBgQli[num3];
						num2 = 42971202;
						continue;
					case 7:
						num3 = num + 1;
						num2 = 42971200;
						continue;
					default:
						if (num >= aaSveCvGzpfewhVzbfsVbGOoRCA - 1)
						{
							return;
						}
						goto case 7;
					}
					break;
				}
			}
		}

		public void SortDescending()
		{
			if (aaSveCvGzpfewhVzbfsVbGOoRCA == 0)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				int num = 0;
				int num2 = -1899857283;
				while (true)
				{
					switch (num2 ^ -1899857292)
					{
					case 6:
						num2 = -1899857289;
						continue;
					default:
						return;
					case 4:
					{
						int num6;
						if (num3 >= aaSveCvGzpfewhVzbfsVbGOoRCA)
						{
							num2 = -1899857291;
							num6 = num2;
						}
						else
						{
							num2 = -1899857290;
							num6 = num2;
						}
						continue;
					}
					case 5:
						num3 = num + 1;
						num2 = -1899857296;
						continue;
					case 3:
						break;
					case 1:
						num++;
						num2 = -1899857283;
						continue;
					case 9:
					{
						int num5;
						if (num < aaSveCvGzpfewhVzbfsVbGOoRCA - 1)
						{
							num2 = -1899857295;
							num5 = num2;
						}
						else
						{
							num2 = -1899857292;
							num5 = num2;
						}
						continue;
					}
					case 7:
						num3++;
						num2 = -1899857296;
						continue;
					case 2:
					{
						int num4;
						if (jwgCcmBYxaMijibFhczhZuzBgQli[num3].CompareTo(jwgCcmBYxaMijibFhczhZuzBgQli[num]) <= 0)
						{
							num2 = -1899857293;
							num4 = num2;
						}
						else
						{
							num2 = -1899857284;
							num4 = num2;
						}
						continue;
					}
					case 8:
					{
						T val = jwgCcmBYxaMijibFhczhZuzBgQli[num];
						jwgCcmBYxaMijibFhczhZuzBgQli[num] = jwgCcmBYxaMijibFhczhZuzBgQli[num3];
						jwgCcmBYxaMijibFhczhZuzBgQli[num3] = val;
						num2 = -1899857293;
						continue;
					}
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void OanAfnbpDCtDnEnWdkOfeiCXKjVz()
		{
			EzkYZCBhQIFtEerwPtbObWJfCDm++;
			Resize(qlnKBuUEnsFEOxxHPudNoUqSmeg + EzkYZCBhQIFtEerwPtbObWJfCDm * yIDFKKLsKRnIWKUcXAUmIxiDJTE);
		}
	}
}
