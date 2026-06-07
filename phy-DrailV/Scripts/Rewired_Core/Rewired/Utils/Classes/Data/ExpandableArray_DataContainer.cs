using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.UIocpiFNPBabRvfmEalBxiNHxOkJ, new()
	{
		public interface UIocpiFNPBabRvfmEalBxiNHxOkJ : IComparable<T>
		{
			void Set(T P_0);

			bool Equals(T P_0);

			void Clear();
		}

		public readonly T injector;

		private T[] cPjATKEFVnoncvVPaNUIGdXjNrirA;

		private int fhPGYixxooGixIiPglMkBNgUFiXX;

		private int vkqrhAEMBfeOLCKPQmFcwGQwmZveb;

		private int fPGvmVNsgONDsheXSjLNuIOfeHnc;

		private int RmjoYaVgaRgjFFBuKOgbPbnFwTzk;

		private bool AbSjNUateQynlhgxogOkDeSfuSoWb;

		public int Count => fhPGYixxooGixIiPglMkBNgUFiXX;

		public int Length => fhPGYixxooGixIiPglMkBNgUFiXX;

		public int MaxLength => vkqrhAEMBfeOLCKPQmFcwGQwmZveb;

		public int FreeSpace => vkqrhAEMBfeOLCKPQmFcwGQwmZveb - fhPGYixxooGixIiPglMkBNgUFiXX;

		public T this[int index]
		{
			get
			{
				if (index >= fhPGYixxooGixIiPglMkBNgUFiXX)
				{
					throw new IndexOutOfRangeException();
				}
				return cPjATKEFVnoncvVPaNUIGdXjNrirA[index];
			}
		}

		public ExpandableArray_DataContainer(int P_0, bool P_1 = true, int P_2 = 0)
		{
			injector = new T();
			cPjATKEFVnoncvVPaNUIGdXjNrirA = new T[P_0];
			fhPGYixxooGixIiPglMkBNgUFiXX = 0;
			vkqrhAEMBfeOLCKPQmFcwGQwmZveb = P_0;
			AbSjNUateQynlhgxogOkDeSfuSoWb = P_1;
			fPGvmVNsgONDsheXSjLNuIOfeHnc = P_2;
			for (int i = 0; i < vkqrhAEMBfeOLCKPQmFcwGQwmZveb; i++)
			{
				cPjATKEFVnoncvVPaNUIGdXjNrirA[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (AbSjNUateQynlhgxogOkDeSfuSoWb)
			{
				injector.Clear();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (AbSjNUateQynlhgxogOkDeSfuSoWb)
			{
				injector.Clear();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (fhPGYixxooGixIiPglMkBNgUFiXX >= vkqrhAEMBfeOLCKPQmFcwGQwmZveb)
			{
				if (fPGvmVNsgONDsheXSjLNuIOfeHnc <= 0)
				{
					return -1;
				}
				RNuUBXpIbDAKkKRElfOQAeiqbUMU();
			}
			int num = fhPGYixxooGixIiPglMkBNgUFiXX;
			cPjATKEFVnoncvVPaNUIGdXjNrirA[num].Set(item);
			fhPGYixxooGixIiPglMkBNgUFiXX = num + 1;
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
			for (int i = 0; i < fhPGYixxooGixIiPglMkBNgUFiXX; i++)
			{
				if (cPjATKEFVnoncvVPaNUIGdXjNrirA[i].Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < fhPGYixxooGixIiPglMkBNgUFiXX; i++)
			{
				if (cPjATKEFVnoncvVPaNUIGdXjNrirA[i].Equals(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (AbSjNUateQynlhgxogOkDeSfuSoWb)
			{
				injector.Clear();
				for (int i = 0; i < fhPGYixxooGixIiPglMkBNgUFiXX; i++)
				{
					cPjATKEFVnoncvVPaNUIGdXjNrirA[i].Clear();
				}
			}
			fhPGYixxooGixIiPglMkBNgUFiXX = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= fhPGYixxooGixIiPglMkBNgUFiXX)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == fhPGYixxooGixIiPglMkBNgUFiXX - 1)
			{
				RemoveLast();
				return;
			}
			if (AbSjNUateQynlhgxogOkDeSfuSoWb)
			{
				cPjATKEFVnoncvVPaNUIGdXjNrirA[index].Clear();
			}
			for (int i = index; i < fhPGYixxooGixIiPglMkBNgUFiXX - 1; i++)
			{
				cPjATKEFVnoncvVPaNUIGdXjNrirA[i].Set(cPjATKEFVnoncvVPaNUIGdXjNrirA[i + 1]);
			}
			if (AbSjNUateQynlhgxogOkDeSfuSoWb)
			{
				cPjATKEFVnoncvVPaNUIGdXjNrirA[fhPGYixxooGixIiPglMkBNgUFiXX - 1].Clear();
			}
			fhPGYixxooGixIiPglMkBNgUFiXX--;
		}

		public void RemoveLast()
		{
			if (fhPGYixxooGixIiPglMkBNgUFiXX != 0)
			{
				if (AbSjNUateQynlhgxogOkDeSfuSoWb)
				{
					cPjATKEFVnoncvVPaNUIGdXjNrirA[fhPGYixxooGixIiPglMkBNgUFiXX - 1].Clear();
				}
				fhPGYixxooGixIiPglMkBNgUFiXX--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == vkqrhAEMBfeOLCKPQmFcwGQwmZveb)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, vkqrhAEMBfeOLCKPQmFcwGQwmZveb);
			for (int i = 0; i < num; i++)
			{
				array[i] = cPjATKEFVnoncvVPaNUIGdXjNrirA[i];
			}
			if (size > vkqrhAEMBfeOLCKPQmFcwGQwmZveb)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (fhPGYixxooGixIiPglMkBNgUFiXX > size)
			{
				fhPGYixxooGixIiPglMkBNgUFiXX = size;
			}
			vkqrhAEMBfeOLCKPQmFcwGQwmZveb = size;
			cPjATKEFVnoncvVPaNUIGdXjNrirA = array;
		}

		public void SortAscending()
		{
			if (fhPGYixxooGixIiPglMkBNgUFiXX == 0)
			{
				return;
			}
			for (int i = 0; i < fhPGYixxooGixIiPglMkBNgUFiXX - 1; i++)
			{
				for (int j = i + 1; j < fhPGYixxooGixIiPglMkBNgUFiXX; j++)
				{
					if (cPjATKEFVnoncvVPaNUIGdXjNrirA[j].CompareTo(cPjATKEFVnoncvVPaNUIGdXjNrirA[i]) < 0)
					{
						T val = cPjATKEFVnoncvVPaNUIGdXjNrirA[i];
						cPjATKEFVnoncvVPaNUIGdXjNrirA[i] = cPjATKEFVnoncvVPaNUIGdXjNrirA[j];
						cPjATKEFVnoncvVPaNUIGdXjNrirA[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (fhPGYixxooGixIiPglMkBNgUFiXX == 0)
			{
				return;
			}
			for (int i = 0; i < fhPGYixxooGixIiPglMkBNgUFiXX - 1; i++)
			{
				for (int j = i + 1; j < fhPGYixxooGixIiPglMkBNgUFiXX; j++)
				{
					if (cPjATKEFVnoncvVPaNUIGdXjNrirA[j].CompareTo(cPjATKEFVnoncvVPaNUIGdXjNrirA[i]) > 0)
					{
						T val = cPjATKEFVnoncvVPaNUIGdXjNrirA[i];
						cPjATKEFVnoncvVPaNUIGdXjNrirA[i] = cPjATKEFVnoncvVPaNUIGdXjNrirA[j];
						cPjATKEFVnoncvVPaNUIGdXjNrirA[j] = val;
					}
				}
			}
		}

		private void RNuUBXpIbDAKkKRElfOQAeiqbUMU()
		{
			RmjoYaVgaRgjFFBuKOgbPbnFwTzk++;
			Resize(vkqrhAEMBfeOLCKPQmFcwGQwmZveb + RmjoYaVgaRgjFFBuKOgbPbnFwTzk * fPGvmVNsgONDsheXSjLNuIOfeHnc);
		}
	}
}
