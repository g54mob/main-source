using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.dFuptlhGpNzTzGvWxeUdsuiEinkQ, new()
	{
		public interface dFuptlhGpNzTzGvWxeUdsuiEinkQ : IComparable<T>
		{
			void Set(T P_0);

			bool Equals(T P_0);

			void Clear();
		}

		public readonly T injector;

		private T[] PgtAQJhalbZOOqphFKgqwHgyQbao;

		private int WTzDlNEEopFJzCzZCcIgADRNcPEA;

		private int YAygvZccpdfKpfZnzxOOPFxfDBpQ;

		private int AzYhydnGWWYcrQfWjeNnxSfcgyRX;

		private int kjpWxxbwOZEZlmfGlegROgCEmutU;

		private bool leAcEFFLAKwYJHhVLroEdVpxDGcU;

		public int Count => WTzDlNEEopFJzCzZCcIgADRNcPEA;

		public int Length => WTzDlNEEopFJzCzZCcIgADRNcPEA;

		public int MaxLength => YAygvZccpdfKpfZnzxOOPFxfDBpQ;

		public int FreeSpace => YAygvZccpdfKpfZnzxOOPFxfDBpQ - WTzDlNEEopFJzCzZCcIgADRNcPEA;

		public T this[int index]
		{
			get
			{
				if (index >= WTzDlNEEopFJzCzZCcIgADRNcPEA)
				{
					throw new IndexOutOfRangeException();
				}
				return PgtAQJhalbZOOqphFKgqwHgyQbao[index];
			}
		}

		public ExpandableArray_DataContainer(int P_0, bool P_1 = true, int P_2 = 0)
		{
			injector = new T();
			PgtAQJhalbZOOqphFKgqwHgyQbao = new T[P_0];
			WTzDlNEEopFJzCzZCcIgADRNcPEA = 0;
			YAygvZccpdfKpfZnzxOOPFxfDBpQ = P_0;
			leAcEFFLAKwYJHhVLroEdVpxDGcU = P_1;
			AzYhydnGWWYcrQfWjeNnxSfcgyRX = P_2;
			for (int i = 0; i < YAygvZccpdfKpfZnzxOOPFxfDBpQ; i++)
			{
				PgtAQJhalbZOOqphFKgqwHgyQbao[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (leAcEFFLAKwYJHhVLroEdVpxDGcU)
			{
				injector.Clear();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (leAcEFFLAKwYJHhVLroEdVpxDGcU)
			{
				injector.Clear();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (WTzDlNEEopFJzCzZCcIgADRNcPEA >= YAygvZccpdfKpfZnzxOOPFxfDBpQ)
			{
				if (AzYhydnGWWYcrQfWjeNnxSfcgyRX <= 0)
				{
					return -1;
				}
				ykgvPAHTHLkpWrIqACXoVqFhQQEP();
			}
			int wTzDlNEEopFJzCzZCcIgADRNcPEA = WTzDlNEEopFJzCzZCcIgADRNcPEA;
			PgtAQJhalbZOOqphFKgqwHgyQbao[wTzDlNEEopFJzCzZCcIgADRNcPEA].Set(item);
			WTzDlNEEopFJzCzZCcIgADRNcPEA = wTzDlNEEopFJzCzZCcIgADRNcPEA + 1;
			return wTzDlNEEopFJzCzZCcIgADRNcPEA;
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
			for (int i = 0; i < WTzDlNEEopFJzCzZCcIgADRNcPEA; i++)
			{
				if (PgtAQJhalbZOOqphFKgqwHgyQbao[i].Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < WTzDlNEEopFJzCzZCcIgADRNcPEA; i++)
			{
				if (PgtAQJhalbZOOqphFKgqwHgyQbao[i].Equals(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (leAcEFFLAKwYJHhVLroEdVpxDGcU)
			{
				injector.Clear();
				for (int i = 0; i < WTzDlNEEopFJzCzZCcIgADRNcPEA; i++)
				{
					PgtAQJhalbZOOqphFKgqwHgyQbao[i].Clear();
				}
			}
			WTzDlNEEopFJzCzZCcIgADRNcPEA = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= WTzDlNEEopFJzCzZCcIgADRNcPEA)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == WTzDlNEEopFJzCzZCcIgADRNcPEA - 1)
			{
				RemoveLast();
				return;
			}
			if (leAcEFFLAKwYJHhVLroEdVpxDGcU)
			{
				PgtAQJhalbZOOqphFKgqwHgyQbao[index].Clear();
			}
			for (int i = index; i < WTzDlNEEopFJzCzZCcIgADRNcPEA - 1; i++)
			{
				PgtAQJhalbZOOqphFKgqwHgyQbao[i].Set(PgtAQJhalbZOOqphFKgqwHgyQbao[i + 1]);
			}
			if (leAcEFFLAKwYJHhVLroEdVpxDGcU)
			{
				PgtAQJhalbZOOqphFKgqwHgyQbao[WTzDlNEEopFJzCzZCcIgADRNcPEA - 1].Clear();
			}
			WTzDlNEEopFJzCzZCcIgADRNcPEA--;
		}

		public void RemoveLast()
		{
			if (WTzDlNEEopFJzCzZCcIgADRNcPEA != 0)
			{
				if (leAcEFFLAKwYJHhVLroEdVpxDGcU)
				{
					PgtAQJhalbZOOqphFKgqwHgyQbao[WTzDlNEEopFJzCzZCcIgADRNcPEA - 1].Clear();
				}
				WTzDlNEEopFJzCzZCcIgADRNcPEA--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == YAygvZccpdfKpfZnzxOOPFxfDBpQ)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, YAygvZccpdfKpfZnzxOOPFxfDBpQ);
			for (int i = 0; i < num; i++)
			{
				array[i] = PgtAQJhalbZOOqphFKgqwHgyQbao[i];
			}
			if (size > YAygvZccpdfKpfZnzxOOPFxfDBpQ)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (WTzDlNEEopFJzCzZCcIgADRNcPEA > size)
			{
				WTzDlNEEopFJzCzZCcIgADRNcPEA = size;
			}
			YAygvZccpdfKpfZnzxOOPFxfDBpQ = size;
			PgtAQJhalbZOOqphFKgqwHgyQbao = array;
		}

		public void SortAscending()
		{
			if (WTzDlNEEopFJzCzZCcIgADRNcPEA == 0)
			{
				return;
			}
			for (int i = 0; i < WTzDlNEEopFJzCzZCcIgADRNcPEA - 1; i++)
			{
				for (int j = i + 1; j < WTzDlNEEopFJzCzZCcIgADRNcPEA; j++)
				{
					if (PgtAQJhalbZOOqphFKgqwHgyQbao[j].CompareTo(PgtAQJhalbZOOqphFKgqwHgyQbao[i]) < 0)
					{
						T val = PgtAQJhalbZOOqphFKgqwHgyQbao[i];
						PgtAQJhalbZOOqphFKgqwHgyQbao[i] = PgtAQJhalbZOOqphFKgqwHgyQbao[j];
						PgtAQJhalbZOOqphFKgqwHgyQbao[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (WTzDlNEEopFJzCzZCcIgADRNcPEA == 0)
			{
				return;
			}
			for (int i = 0; i < WTzDlNEEopFJzCzZCcIgADRNcPEA - 1; i++)
			{
				for (int j = i + 1; j < WTzDlNEEopFJzCzZCcIgADRNcPEA; j++)
				{
					if (PgtAQJhalbZOOqphFKgqwHgyQbao[j].CompareTo(PgtAQJhalbZOOqphFKgqwHgyQbao[i]) > 0)
					{
						T val = PgtAQJhalbZOOqphFKgqwHgyQbao[i];
						PgtAQJhalbZOOqphFKgqwHgyQbao[i] = PgtAQJhalbZOOqphFKgqwHgyQbao[j];
						PgtAQJhalbZOOqphFKgqwHgyQbao[j] = val;
					}
				}
			}
		}

		private void ykgvPAHTHLkpWrIqACXoVqFhQQEP()
		{
			kjpWxxbwOZEZlmfGlegROgCEmutU++;
			Resize(YAygvZccpdfKpfZnzxOOPFxfDBpQ + kjpWxxbwOZEZlmfGlegROgCEmutU * AzYhydnGWWYcrQfWjeNnxSfcgyRX);
		}
	}
}
