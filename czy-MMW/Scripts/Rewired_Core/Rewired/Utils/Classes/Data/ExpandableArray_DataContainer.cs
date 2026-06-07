using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.TVBgovhjLayvQrOmBMxqiXsndkMlA, new()
	{
		public interface TVBgovhjLayvQrOmBMxqiXsndkMlA : IComparable<T>
		{
			void VbTqOFRLGqiIOJyOYDrdMAAkHrCj(T P_0);

			bool QgkDGSvRNRxKxMuMbYBjOcyJRoub(T P_0);

			void wDPkJYfYYWdMcbWjbRouiAosDabW();
		}

		public readonly T injector;

		private T[] rKyCWqaQCyQWvZxGQBshNxpDTkXo;

		private int sBiHsIGbvekRAArFdckwmRQtVLUMc;

		private int JnMKPqyoazDDmyLccrGzUBWMhsNP;

		private int AKJFxjMwcjIZJLTAAROAwcqyHzZr;

		private int JEQKVrrNxMFcSgGzSdUWeTblejXv;

		private bool cfutgVDqqtDbaeRkAdgHPbiitsKp;

		public int Count => sBiHsIGbvekRAArFdckwmRQtVLUMc;

		public int Length => sBiHsIGbvekRAArFdckwmRQtVLUMc;

		public int MaxLength => JnMKPqyoazDDmyLccrGzUBWMhsNP;

		public int FreeSpace => JnMKPqyoazDDmyLccrGzUBWMhsNP - sBiHsIGbvekRAArFdckwmRQtVLUMc;

		public T this[int index]
		{
			get
			{
				if (index >= sBiHsIGbvekRAArFdckwmRQtVLUMc)
				{
					throw new IndexOutOfRangeException();
				}
				return rKyCWqaQCyQWvZxGQBshNxpDTkXo[index];
			}
		}

		public ExpandableArray_DataContainer(int P_0, bool P_1 = true, int P_2 = 0)
		{
			injector = new T();
			rKyCWqaQCyQWvZxGQBshNxpDTkXo = new T[P_0];
			sBiHsIGbvekRAArFdckwmRQtVLUMc = 0;
			JnMKPqyoazDDmyLccrGzUBWMhsNP = P_0;
			cfutgVDqqtDbaeRkAdgHPbiitsKp = P_1;
			AKJFxjMwcjIZJLTAAROAwcqyHzZr = P_2;
			for (int i = 0; i < JnMKPqyoazDDmyLccrGzUBWMhsNP; i++)
			{
				rKyCWqaQCyQWvZxGQBshNxpDTkXo[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (cfutgVDqqtDbaeRkAdgHPbiitsKp)
			{
				injector.wDPkJYfYYWdMcbWjbRouiAosDabW();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (cfutgVDqqtDbaeRkAdgHPbiitsKp)
			{
				injector.wDPkJYfYYWdMcbWjbRouiAosDabW();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (sBiHsIGbvekRAArFdckwmRQtVLUMc >= JnMKPqyoazDDmyLccrGzUBWMhsNP)
			{
				if (AKJFxjMwcjIZJLTAAROAwcqyHzZr <= 0)
				{
					return -1;
				}
				pBVgUWHaqHRdINoKoIRRmdFBGDrkA();
			}
			int num = sBiHsIGbvekRAArFdckwmRQtVLUMc;
			rKyCWqaQCyQWvZxGQBshNxpDTkXo[num].VbTqOFRLGqiIOJyOYDrdMAAkHrCj(item);
			sBiHsIGbvekRAArFdckwmRQtVLUMc = num + 1;
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
			for (int i = 0; i < sBiHsIGbvekRAArFdckwmRQtVLUMc; i++)
			{
				if (rKyCWqaQCyQWvZxGQBshNxpDTkXo[i].QgkDGSvRNRxKxMuMbYBjOcyJRoub(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < sBiHsIGbvekRAArFdckwmRQtVLUMc; i++)
			{
				if (rKyCWqaQCyQWvZxGQBshNxpDTkXo[i].QgkDGSvRNRxKxMuMbYBjOcyJRoub(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (cfutgVDqqtDbaeRkAdgHPbiitsKp)
			{
				injector.wDPkJYfYYWdMcbWjbRouiAosDabW();
				for (int i = 0; i < sBiHsIGbvekRAArFdckwmRQtVLUMc; i++)
				{
					rKyCWqaQCyQWvZxGQBshNxpDTkXo[i].wDPkJYfYYWdMcbWjbRouiAosDabW();
				}
			}
			sBiHsIGbvekRAArFdckwmRQtVLUMc = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= sBiHsIGbvekRAArFdckwmRQtVLUMc)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == sBiHsIGbvekRAArFdckwmRQtVLUMc - 1)
			{
				RemoveLast();
				return;
			}
			if (cfutgVDqqtDbaeRkAdgHPbiitsKp)
			{
				rKyCWqaQCyQWvZxGQBshNxpDTkXo[index].wDPkJYfYYWdMcbWjbRouiAosDabW();
			}
			for (int i = index; i < sBiHsIGbvekRAArFdckwmRQtVLUMc - 1; i++)
			{
				rKyCWqaQCyQWvZxGQBshNxpDTkXo[i].VbTqOFRLGqiIOJyOYDrdMAAkHrCj(rKyCWqaQCyQWvZxGQBshNxpDTkXo[i + 1]);
			}
			if (cfutgVDqqtDbaeRkAdgHPbiitsKp)
			{
				rKyCWqaQCyQWvZxGQBshNxpDTkXo[sBiHsIGbvekRAArFdckwmRQtVLUMc - 1].wDPkJYfYYWdMcbWjbRouiAosDabW();
			}
			sBiHsIGbvekRAArFdckwmRQtVLUMc--;
		}

		public void RemoveLast()
		{
			if (sBiHsIGbvekRAArFdckwmRQtVLUMc != 0)
			{
				if (cfutgVDqqtDbaeRkAdgHPbiitsKp)
				{
					rKyCWqaQCyQWvZxGQBshNxpDTkXo[sBiHsIGbvekRAArFdckwmRQtVLUMc - 1].wDPkJYfYYWdMcbWjbRouiAosDabW();
				}
				sBiHsIGbvekRAArFdckwmRQtVLUMc--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == JnMKPqyoazDDmyLccrGzUBWMhsNP)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, JnMKPqyoazDDmyLccrGzUBWMhsNP);
			for (int i = 0; i < num; i++)
			{
				array[i] = rKyCWqaQCyQWvZxGQBshNxpDTkXo[i];
			}
			if (size > JnMKPqyoazDDmyLccrGzUBWMhsNP)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (sBiHsIGbvekRAArFdckwmRQtVLUMc > size)
			{
				sBiHsIGbvekRAArFdckwmRQtVLUMc = size;
			}
			JnMKPqyoazDDmyLccrGzUBWMhsNP = size;
			rKyCWqaQCyQWvZxGQBshNxpDTkXo = array;
		}

		public void SortAscending()
		{
			if (sBiHsIGbvekRAArFdckwmRQtVLUMc == 0)
			{
				return;
			}
			for (int i = 0; i < sBiHsIGbvekRAArFdckwmRQtVLUMc - 1; i++)
			{
				for (int j = i + 1; j < sBiHsIGbvekRAArFdckwmRQtVLUMc; j++)
				{
					if (rKyCWqaQCyQWvZxGQBshNxpDTkXo[j].CompareTo(rKyCWqaQCyQWvZxGQBshNxpDTkXo[i]) < 0)
					{
						T val = rKyCWqaQCyQWvZxGQBshNxpDTkXo[i];
						rKyCWqaQCyQWvZxGQBshNxpDTkXo[i] = rKyCWqaQCyQWvZxGQBshNxpDTkXo[j];
						rKyCWqaQCyQWvZxGQBshNxpDTkXo[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (sBiHsIGbvekRAArFdckwmRQtVLUMc == 0)
			{
				return;
			}
			for (int i = 0; i < sBiHsIGbvekRAArFdckwmRQtVLUMc - 1; i++)
			{
				for (int j = i + 1; j < sBiHsIGbvekRAArFdckwmRQtVLUMc; j++)
				{
					if (rKyCWqaQCyQWvZxGQBshNxpDTkXo[j].CompareTo(rKyCWqaQCyQWvZxGQBshNxpDTkXo[i]) > 0)
					{
						T val = rKyCWqaQCyQWvZxGQBshNxpDTkXo[i];
						rKyCWqaQCyQWvZxGQBshNxpDTkXo[i] = rKyCWqaQCyQWvZxGQBshNxpDTkXo[j];
						rKyCWqaQCyQWvZxGQBshNxpDTkXo[j] = val;
					}
				}
			}
		}

		private void pBVgUWHaqHRdINoKoIRRmdFBGDrkA()
		{
			JEQKVrrNxMFcSgGzSdUWeTblejXv++;
			Resize(JnMKPqyoazDDmyLccrGzUBWMhsNP + JEQKVrrNxMFcSgGzSdUWeTblejXv * AKJFxjMwcjIZJLTAAROAwcqyHzZr);
		}
	}
}
