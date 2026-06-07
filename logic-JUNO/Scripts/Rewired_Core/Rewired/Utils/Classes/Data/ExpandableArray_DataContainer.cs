using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.PpQQfpicOGaWTCknreSphUKsXKis, new()
	{
		public interface PpQQfpicOGaWTCknreSphUKsXKis : IComparable<T>
		{
			void HOazBFUNiKJXNHHAygiviaarpyHB(T P_0);

			bool YMtEmYsKQrMORMjdPbvQqdEOfTIH(T P_0);

			void aHGlQCeZKmWhtlqEHuAdKOMpQAVF();
		}

		public readonly T injector;

		private T[] bopTLqvFDGdKyZRNiXZwbUBGAfvI;

		private int eVpRbQiSkUPsTfmIQYXrrFqIRzwk;

		private int VGRZumfxINalDehXUCysiiXRGjEc;

		private int AoQKEdPjTPdTSZFDekMXOUclNCpF;

		private int RyLXnciaGmqEZuyPyhaDKLduXUrE;

		private bool cIrEhBAStDrWdelxgqNMpWChNUkx;

		public int Count => eVpRbQiSkUPsTfmIQYXrrFqIRzwk;

		public int Length => eVpRbQiSkUPsTfmIQYXrrFqIRzwk;

		public int MaxLength => VGRZumfxINalDehXUCysiiXRGjEc;

		public int FreeSpace => VGRZumfxINalDehXUCysiiXRGjEc - eVpRbQiSkUPsTfmIQYXrrFqIRzwk;

		public T this[int index]
		{
			get
			{
				if (index >= eVpRbQiSkUPsTfmIQYXrrFqIRzwk)
				{
					throw new IndexOutOfRangeException();
				}
				return bopTLqvFDGdKyZRNiXZwbUBGAfvI[index];
			}
		}

		public ExpandableArray_DataContainer(int P_0, bool P_1 = true, int P_2 = 0)
		{
			injector = new T();
			bopTLqvFDGdKyZRNiXZwbUBGAfvI = new T[P_0];
			eVpRbQiSkUPsTfmIQYXrrFqIRzwk = 0;
			VGRZumfxINalDehXUCysiiXRGjEc = P_0;
			cIrEhBAStDrWdelxgqNMpWChNUkx = P_1;
			AoQKEdPjTPdTSZFDekMXOUclNCpF = P_2;
			for (int i = 0; i < VGRZumfxINalDehXUCysiiXRGjEc; i++)
			{
				bopTLqvFDGdKyZRNiXZwbUBGAfvI[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (cIrEhBAStDrWdelxgqNMpWChNUkx)
			{
				injector.aHGlQCeZKmWhtlqEHuAdKOMpQAVF();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (cIrEhBAStDrWdelxgqNMpWChNUkx)
			{
				injector.aHGlQCeZKmWhtlqEHuAdKOMpQAVF();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (eVpRbQiSkUPsTfmIQYXrrFqIRzwk >= VGRZumfxINalDehXUCysiiXRGjEc)
			{
				if (AoQKEdPjTPdTSZFDekMXOUclNCpF <= 0)
				{
					return -1;
				}
				fYWuDOYJxnFUDDrJOncOGzhScjZs();
			}
			int num = eVpRbQiSkUPsTfmIQYXrrFqIRzwk;
			bopTLqvFDGdKyZRNiXZwbUBGAfvI[num].HOazBFUNiKJXNHHAygiviaarpyHB(item);
			eVpRbQiSkUPsTfmIQYXrrFqIRzwk = num + 1;
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
			for (int i = 0; i < eVpRbQiSkUPsTfmIQYXrrFqIRzwk; i++)
			{
				if (bopTLqvFDGdKyZRNiXZwbUBGAfvI[i].YMtEmYsKQrMORMjdPbvQqdEOfTIH(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < eVpRbQiSkUPsTfmIQYXrrFqIRzwk; i++)
			{
				if (bopTLqvFDGdKyZRNiXZwbUBGAfvI[i].YMtEmYsKQrMORMjdPbvQqdEOfTIH(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (cIrEhBAStDrWdelxgqNMpWChNUkx)
			{
				injector.aHGlQCeZKmWhtlqEHuAdKOMpQAVF();
				for (int i = 0; i < eVpRbQiSkUPsTfmIQYXrrFqIRzwk; i++)
				{
					bopTLqvFDGdKyZRNiXZwbUBGAfvI[i].aHGlQCeZKmWhtlqEHuAdKOMpQAVF();
				}
			}
			eVpRbQiSkUPsTfmIQYXrrFqIRzwk = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= eVpRbQiSkUPsTfmIQYXrrFqIRzwk)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == eVpRbQiSkUPsTfmIQYXrrFqIRzwk - 1)
			{
				RemoveLast();
				return;
			}
			if (cIrEhBAStDrWdelxgqNMpWChNUkx)
			{
				bopTLqvFDGdKyZRNiXZwbUBGAfvI[index].aHGlQCeZKmWhtlqEHuAdKOMpQAVF();
			}
			for (int i = index; i < eVpRbQiSkUPsTfmIQYXrrFqIRzwk - 1; i++)
			{
				bopTLqvFDGdKyZRNiXZwbUBGAfvI[i].HOazBFUNiKJXNHHAygiviaarpyHB(bopTLqvFDGdKyZRNiXZwbUBGAfvI[i + 1]);
			}
			if (cIrEhBAStDrWdelxgqNMpWChNUkx)
			{
				bopTLqvFDGdKyZRNiXZwbUBGAfvI[eVpRbQiSkUPsTfmIQYXrrFqIRzwk - 1].aHGlQCeZKmWhtlqEHuAdKOMpQAVF();
			}
			eVpRbQiSkUPsTfmIQYXrrFqIRzwk--;
		}

		public void RemoveLast()
		{
			if (eVpRbQiSkUPsTfmIQYXrrFqIRzwk != 0)
			{
				if (cIrEhBAStDrWdelxgqNMpWChNUkx)
				{
					bopTLqvFDGdKyZRNiXZwbUBGAfvI[eVpRbQiSkUPsTfmIQYXrrFqIRzwk - 1].aHGlQCeZKmWhtlqEHuAdKOMpQAVF();
				}
				eVpRbQiSkUPsTfmIQYXrrFqIRzwk--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == VGRZumfxINalDehXUCysiiXRGjEc)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, VGRZumfxINalDehXUCysiiXRGjEc);
			for (int i = 0; i < num; i++)
			{
				array[i] = bopTLqvFDGdKyZRNiXZwbUBGAfvI[i];
			}
			if (size > VGRZumfxINalDehXUCysiiXRGjEc)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (eVpRbQiSkUPsTfmIQYXrrFqIRzwk > size)
			{
				eVpRbQiSkUPsTfmIQYXrrFqIRzwk = size;
			}
			VGRZumfxINalDehXUCysiiXRGjEc = size;
			bopTLqvFDGdKyZRNiXZwbUBGAfvI = array;
		}

		public void SortAscending()
		{
			if (eVpRbQiSkUPsTfmIQYXrrFqIRzwk == 0)
			{
				return;
			}
			for (int i = 0; i < eVpRbQiSkUPsTfmIQYXrrFqIRzwk - 1; i++)
			{
				for (int j = i + 1; j < eVpRbQiSkUPsTfmIQYXrrFqIRzwk; j++)
				{
					if (bopTLqvFDGdKyZRNiXZwbUBGAfvI[j].CompareTo(bopTLqvFDGdKyZRNiXZwbUBGAfvI[i]) < 0)
					{
						T val = bopTLqvFDGdKyZRNiXZwbUBGAfvI[i];
						bopTLqvFDGdKyZRNiXZwbUBGAfvI[i] = bopTLqvFDGdKyZRNiXZwbUBGAfvI[j];
						bopTLqvFDGdKyZRNiXZwbUBGAfvI[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (eVpRbQiSkUPsTfmIQYXrrFqIRzwk == 0)
			{
				return;
			}
			for (int i = 0; i < eVpRbQiSkUPsTfmIQYXrrFqIRzwk - 1; i++)
			{
				for (int j = i + 1; j < eVpRbQiSkUPsTfmIQYXrrFqIRzwk; j++)
				{
					if (bopTLqvFDGdKyZRNiXZwbUBGAfvI[j].CompareTo(bopTLqvFDGdKyZRNiXZwbUBGAfvI[i]) > 0)
					{
						T val = bopTLqvFDGdKyZRNiXZwbUBGAfvI[i];
						bopTLqvFDGdKyZRNiXZwbUBGAfvI[i] = bopTLqvFDGdKyZRNiXZwbUBGAfvI[j];
						bopTLqvFDGdKyZRNiXZwbUBGAfvI[j] = val;
					}
				}
			}
		}

		private void fYWuDOYJxnFUDDrJOncOGzhScjZs()
		{
			RyLXnciaGmqEZuyPyhaDKLduXUrE++;
			Resize(VGRZumfxINalDehXUCysiiXRGjEc + RyLXnciaGmqEZuyPyhaDKLduXUrE * AoQKEdPjTPdTSZFDekMXOUclNCpF);
		}
	}
}
