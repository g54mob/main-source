using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.wCiGrxuKZvGhiJktAyXbsmDNmcuF, new()
	{
		public interface wCiGrxuKZvGhiJktAyXbsmDNmcuF : IComparable<T>
		{
			void yswGWNhGGbRRmCGYDkOmQrSKzPoFA(T P_0);

			bool nzXRvOuPZIpKqDpysFVYbbcpBTSY(T P_0);

			void TSkvOQefMTsMKyZnmFQrRkoCRuFx();
		}

		public readonly T injector;

		private T[] OzRTuujhKtxvBSPKNyrmwxbhIwpN;

		private int LLLOmUoTfzmGuofNrGtxuOYnANeeA;

		private int yfvicuFdmqZkEHfylnskqvMudajqA;

		private int fZoadlEBcoShlCMQfJMDORmeQrCtd;

		private int eVxZibcRnRDiqevlXTRVvTpJMtjsA;

		private bool RRBKuRYzwcWySrLcDpHAywcGyCsK;

		public int Count => LLLOmUoTfzmGuofNrGtxuOYnANeeA;

		public int Length => LLLOmUoTfzmGuofNrGtxuOYnANeeA;

		public int MaxLength => yfvicuFdmqZkEHfylnskqvMudajqA;

		public int FreeSpace => yfvicuFdmqZkEHfylnskqvMudajqA - LLLOmUoTfzmGuofNrGtxuOYnANeeA;

		public T this[int index]
		{
			get
			{
				if (index >= LLLOmUoTfzmGuofNrGtxuOYnANeeA)
				{
					throw new IndexOutOfRangeException();
				}
				return OzRTuujhKtxvBSPKNyrmwxbhIwpN[index];
			}
		}

		public ExpandableArray_DataContainer(int P_0, bool P_1 = true, int P_2 = 0)
		{
			injector = new T();
			OzRTuujhKtxvBSPKNyrmwxbhIwpN = new T[P_0];
			LLLOmUoTfzmGuofNrGtxuOYnANeeA = 0;
			yfvicuFdmqZkEHfylnskqvMudajqA = P_0;
			RRBKuRYzwcWySrLcDpHAywcGyCsK = P_1;
			fZoadlEBcoShlCMQfJMDORmeQrCtd = P_2;
			for (int i = 0; i < yfvicuFdmqZkEHfylnskqvMudajqA; i++)
			{
				OzRTuujhKtxvBSPKNyrmwxbhIwpN[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (RRBKuRYzwcWySrLcDpHAywcGyCsK)
			{
				injector.TSkvOQefMTsMKyZnmFQrRkoCRuFx();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (RRBKuRYzwcWySrLcDpHAywcGyCsK)
			{
				injector.TSkvOQefMTsMKyZnmFQrRkoCRuFx();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (LLLOmUoTfzmGuofNrGtxuOYnANeeA >= yfvicuFdmqZkEHfylnskqvMudajqA)
			{
				if (fZoadlEBcoShlCMQfJMDORmeQrCtd <= 0)
				{
					return -1;
				}
				IpucmKOKuCMdwWGIfDSGZABhtRXx();
			}
			int lLLOmUoTfzmGuofNrGtxuOYnANeeA = LLLOmUoTfzmGuofNrGtxuOYnANeeA;
			OzRTuujhKtxvBSPKNyrmwxbhIwpN[lLLOmUoTfzmGuofNrGtxuOYnANeeA].yswGWNhGGbRRmCGYDkOmQrSKzPoFA(item);
			LLLOmUoTfzmGuofNrGtxuOYnANeeA = lLLOmUoTfzmGuofNrGtxuOYnANeeA + 1;
			return lLLOmUoTfzmGuofNrGtxuOYnANeeA;
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
			for (int i = 0; i < LLLOmUoTfzmGuofNrGtxuOYnANeeA; i++)
			{
				if (OzRTuujhKtxvBSPKNyrmwxbhIwpN[i].nzXRvOuPZIpKqDpysFVYbbcpBTSY(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < LLLOmUoTfzmGuofNrGtxuOYnANeeA; i++)
			{
				if (OzRTuujhKtxvBSPKNyrmwxbhIwpN[i].nzXRvOuPZIpKqDpysFVYbbcpBTSY(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (RRBKuRYzwcWySrLcDpHAywcGyCsK)
			{
				injector.TSkvOQefMTsMKyZnmFQrRkoCRuFx();
				for (int i = 0; i < LLLOmUoTfzmGuofNrGtxuOYnANeeA; i++)
				{
					OzRTuujhKtxvBSPKNyrmwxbhIwpN[i].TSkvOQefMTsMKyZnmFQrRkoCRuFx();
				}
			}
			LLLOmUoTfzmGuofNrGtxuOYnANeeA = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= LLLOmUoTfzmGuofNrGtxuOYnANeeA)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == LLLOmUoTfzmGuofNrGtxuOYnANeeA - 1)
			{
				RemoveLast();
				return;
			}
			if (RRBKuRYzwcWySrLcDpHAywcGyCsK)
			{
				OzRTuujhKtxvBSPKNyrmwxbhIwpN[index].TSkvOQefMTsMKyZnmFQrRkoCRuFx();
			}
			for (int i = index; i < LLLOmUoTfzmGuofNrGtxuOYnANeeA - 1; i++)
			{
				OzRTuujhKtxvBSPKNyrmwxbhIwpN[i].yswGWNhGGbRRmCGYDkOmQrSKzPoFA(OzRTuujhKtxvBSPKNyrmwxbhIwpN[i + 1]);
			}
			if (RRBKuRYzwcWySrLcDpHAywcGyCsK)
			{
				OzRTuujhKtxvBSPKNyrmwxbhIwpN[LLLOmUoTfzmGuofNrGtxuOYnANeeA - 1].TSkvOQefMTsMKyZnmFQrRkoCRuFx();
			}
			LLLOmUoTfzmGuofNrGtxuOYnANeeA--;
		}

		public void RemoveLast()
		{
			if (LLLOmUoTfzmGuofNrGtxuOYnANeeA != 0)
			{
				if (RRBKuRYzwcWySrLcDpHAywcGyCsK)
				{
					OzRTuujhKtxvBSPKNyrmwxbhIwpN[LLLOmUoTfzmGuofNrGtxuOYnANeeA - 1].TSkvOQefMTsMKyZnmFQrRkoCRuFx();
				}
				LLLOmUoTfzmGuofNrGtxuOYnANeeA--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == yfvicuFdmqZkEHfylnskqvMudajqA)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, yfvicuFdmqZkEHfylnskqvMudajqA);
			for (int i = 0; i < num; i++)
			{
				array[i] = OzRTuujhKtxvBSPKNyrmwxbhIwpN[i];
			}
			if (size > yfvicuFdmqZkEHfylnskqvMudajqA)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (LLLOmUoTfzmGuofNrGtxuOYnANeeA > size)
			{
				LLLOmUoTfzmGuofNrGtxuOYnANeeA = size;
			}
			yfvicuFdmqZkEHfylnskqvMudajqA = size;
			OzRTuujhKtxvBSPKNyrmwxbhIwpN = array;
		}

		public void SortAscending()
		{
			if (LLLOmUoTfzmGuofNrGtxuOYnANeeA == 0)
			{
				return;
			}
			for (int i = 0; i < LLLOmUoTfzmGuofNrGtxuOYnANeeA - 1; i++)
			{
				for (int j = i + 1; j < LLLOmUoTfzmGuofNrGtxuOYnANeeA; j++)
				{
					if (OzRTuujhKtxvBSPKNyrmwxbhIwpN[j].CompareTo(OzRTuujhKtxvBSPKNyrmwxbhIwpN[i]) < 0)
					{
						T val = OzRTuujhKtxvBSPKNyrmwxbhIwpN[i];
						OzRTuujhKtxvBSPKNyrmwxbhIwpN[i] = OzRTuujhKtxvBSPKNyrmwxbhIwpN[j];
						OzRTuujhKtxvBSPKNyrmwxbhIwpN[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (LLLOmUoTfzmGuofNrGtxuOYnANeeA == 0)
			{
				return;
			}
			for (int i = 0; i < LLLOmUoTfzmGuofNrGtxuOYnANeeA - 1; i++)
			{
				for (int j = i + 1; j < LLLOmUoTfzmGuofNrGtxuOYnANeeA; j++)
				{
					if (OzRTuujhKtxvBSPKNyrmwxbhIwpN[j].CompareTo(OzRTuujhKtxvBSPKNyrmwxbhIwpN[i]) > 0)
					{
						T val = OzRTuujhKtxvBSPKNyrmwxbhIwpN[i];
						OzRTuujhKtxvBSPKNyrmwxbhIwpN[i] = OzRTuujhKtxvBSPKNyrmwxbhIwpN[j];
						OzRTuujhKtxvBSPKNyrmwxbhIwpN[j] = val;
					}
				}
			}
		}

		private void IpucmKOKuCMdwWGIfDSGZABhtRXx()
		{
			eVxZibcRnRDiqevlXTRVvTpJMtjsA++;
			Resize(yfvicuFdmqZkEHfylnskqvMudajqA + eVxZibcRnRDiqevlXTRVvTpJMtjsA * fZoadlEBcoShlCMQfJMDORmeQrCtd);
		}
	}
}
