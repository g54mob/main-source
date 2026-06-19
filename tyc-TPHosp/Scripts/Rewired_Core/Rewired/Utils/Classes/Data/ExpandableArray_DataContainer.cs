using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.ZCwyRnXJtqxwKqOyVThgMfPudaO, new()
	{
		public interface ZCwyRnXJtqxwKqOyVThgMfPudaO : IComparable<T>
		{
			void vJjhoRLlAcrjzWycVrrFomtsobA(T P_0);

			bool hFRtBMPFLguJtUgBhljKTKfqOwO(T P_0);

			void dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
		}

		public readonly T injector;

		private T[] nwteNHcRpGsgfiGZzjfvOCLUadGv;

		private int oNZkEprWWJQbgFBVzixBepczssx;

		private int akilpPEOjEANSDoFJCuJzZGJfFR;

		private int cjUvjiRURpAOMgkbNUihNMLAwpD;

		private int ORtsRfZtWqpUIYeaRbfSuenaKuF;

		private bool HAKdFHkfQfJqmklldWdFmZSPnGCd;

		public int Count => oNZkEprWWJQbgFBVzixBepczssx;

		public int Length => oNZkEprWWJQbgFBVzixBepczssx;

		public int MaxLength => akilpPEOjEANSDoFJCuJzZGJfFR;

		public int FreeSpace => akilpPEOjEANSDoFJCuJzZGJfFR - oNZkEprWWJQbgFBVzixBepczssx;

		public T this[int index]
		{
			get
			{
				if (index >= oNZkEprWWJQbgFBVzixBepczssx)
				{
					throw new IndexOutOfRangeException();
				}
				return nwteNHcRpGsgfiGZzjfvOCLUadGv[index];
			}
		}

		public ExpandableArray_DataContainer(int startingMaxLength, bool clearData = true, int expansionIncrement = 0)
		{
			injector = new T();
			nwteNHcRpGsgfiGZzjfvOCLUadGv = new T[startingMaxLength];
			oNZkEprWWJQbgFBVzixBepczssx = 0;
			akilpPEOjEANSDoFJCuJzZGJfFR = startingMaxLength;
			HAKdFHkfQfJqmklldWdFmZSPnGCd = clearData;
			cjUvjiRURpAOMgkbNUihNMLAwpD = expansionIncrement;
			for (int i = 0; i < akilpPEOjEANSDoFJCuJzZGJfFR; i++)
			{
				nwteNHcRpGsgfiGZzjfvOCLUadGv[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (HAKdFHkfQfJqmklldWdFmZSPnGCd)
			{
				T val = injector;
				val.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (HAKdFHkfQfJqmklldWdFmZSPnGCd)
			{
				T val = injector;
				val.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (oNZkEprWWJQbgFBVzixBepczssx >= akilpPEOjEANSDoFJCuJzZGJfFR)
			{
				if (cjUvjiRURpAOMgkbNUihNMLAwpD <= 0)
				{
					return -1;
				}
				GtgUJCbmFiNljBCQaOPzfYyJQTm();
			}
			int num = oNZkEprWWJQbgFBVzixBepczssx;
			nwteNHcRpGsgfiGZzjfvOCLUadGv[num].vJjhoRLlAcrjzWycVrrFomtsobA(item);
			oNZkEprWWJQbgFBVzixBepczssx = num + 1;
			return num;
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
			for (int i = 0; i < oNZkEprWWJQbgFBVzixBepczssx; i++)
			{
				if (nwteNHcRpGsgfiGZzjfvOCLUadGv[i].hFRtBMPFLguJtUgBhljKTKfqOwO(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < oNZkEprWWJQbgFBVzixBepczssx; i++)
			{
				if (nwteNHcRpGsgfiGZzjfvOCLUadGv[i].hFRtBMPFLguJtUgBhljKTKfqOwO(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (HAKdFHkfQfJqmklldWdFmZSPnGCd)
			{
				T val = injector;
				val.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				for (int i = 0; i < oNZkEprWWJQbgFBVzixBepczssx; i++)
				{
					nwteNHcRpGsgfiGZzjfvOCLUadGv[i].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				}
			}
			oNZkEprWWJQbgFBVzixBepczssx = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= oNZkEprWWJQbgFBVzixBepczssx)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == oNZkEprWWJQbgFBVzixBepczssx - 1)
			{
				RemoveLast();
				return;
			}
			if (HAKdFHkfQfJqmklldWdFmZSPnGCd)
			{
				nwteNHcRpGsgfiGZzjfvOCLUadGv[index].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}
			for (int i = index; i < oNZkEprWWJQbgFBVzixBepczssx - 1; i++)
			{
				ref readonly T reference = ref nwteNHcRpGsgfiGZzjfvOCLUadGv[i];
				T val = nwteNHcRpGsgfiGZzjfvOCLUadGv[i + 1];
				reference.vJjhoRLlAcrjzWycVrrFomtsobA(val);
			}
			if (HAKdFHkfQfJqmklldWdFmZSPnGCd)
			{
				nwteNHcRpGsgfiGZzjfvOCLUadGv[oNZkEprWWJQbgFBVzixBepczssx - 1].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}
			oNZkEprWWJQbgFBVzixBepczssx--;
		}

		public void RemoveLast()
		{
			if (oNZkEprWWJQbgFBVzixBepczssx != 0)
			{
				if (HAKdFHkfQfJqmklldWdFmZSPnGCd)
				{
					nwteNHcRpGsgfiGZzjfvOCLUadGv[oNZkEprWWJQbgFBVzixBepczssx - 1].dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				}
				oNZkEprWWJQbgFBVzixBepczssx--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == akilpPEOjEANSDoFJCuJzZGJfFR)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, akilpPEOjEANSDoFJCuJzZGJfFR);
			for (int i = 0; i < num; i++)
			{
				array[i] = nwteNHcRpGsgfiGZzjfvOCLUadGv[i];
			}
			if (size > akilpPEOjEANSDoFJCuJzZGJfFR)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (oNZkEprWWJQbgFBVzixBepczssx > size)
			{
				oNZkEprWWJQbgFBVzixBepczssx = size;
			}
			akilpPEOjEANSDoFJCuJzZGJfFR = size;
			nwteNHcRpGsgfiGZzjfvOCLUadGv = array;
		}

		public void SortAscending()
		{
			if (oNZkEprWWJQbgFBVzixBepczssx == 0)
			{
				return;
			}
			for (int i = 0; i < oNZkEprWWJQbgFBVzixBepczssx - 1; i++)
			{
				for (int j = i + 1; j < oNZkEprWWJQbgFBVzixBepczssx; j++)
				{
					ref readonly T reference = ref nwteNHcRpGsgfiGZzjfvOCLUadGv[j];
					T other = nwteNHcRpGsgfiGZzjfvOCLUadGv[i];
					if (reference.CompareTo(other) < 0)
					{
						T val = nwteNHcRpGsgfiGZzjfvOCLUadGv[i];
						nwteNHcRpGsgfiGZzjfvOCLUadGv[i] = nwteNHcRpGsgfiGZzjfvOCLUadGv[j];
						nwteNHcRpGsgfiGZzjfvOCLUadGv[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (oNZkEprWWJQbgFBVzixBepczssx == 0)
			{
				return;
			}
			for (int i = 0; i < oNZkEprWWJQbgFBVzixBepczssx - 1; i++)
			{
				for (int j = i + 1; j < oNZkEprWWJQbgFBVzixBepczssx; j++)
				{
					ref readonly T reference = ref nwteNHcRpGsgfiGZzjfvOCLUadGv[j];
					T other = nwteNHcRpGsgfiGZzjfvOCLUadGv[i];
					if (reference.CompareTo(other) > 0)
					{
						T val = nwteNHcRpGsgfiGZzjfvOCLUadGv[i];
						nwteNHcRpGsgfiGZzjfvOCLUadGv[i] = nwteNHcRpGsgfiGZzjfvOCLUadGv[j];
						nwteNHcRpGsgfiGZzjfvOCLUadGv[j] = val;
					}
				}
			}
		}

		private void GtgUJCbmFiNljBCQaOPzfYyJQTm()
		{
			ORtsRfZtWqpUIYeaRbfSuenaKuF++;
			Resize(akilpPEOjEANSDoFJCuJzZGJfFR + ORtsRfZtWqpUIYeaRbfSuenaKuF * cjUvjiRURpAOMgkbNUihNMLAwpD);
		}
	}
}
