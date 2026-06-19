using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.LOEdlCYsarLsVHRklVehzPLUzmjC, new()
	{
		public interface LOEdlCYsarLsVHRklVehzPLUzmjC : IComparable<T>
		{
			void LCUIhawQpxOGJQabaynagNtLUQpN(T P_0);

			bool MapxCdOhoKqLPDmPDicUjuDaFGJdb(T P_0);

			void kBGUvxOOjLYBbiYWVtxxOQRHlpWO();
		}

		public readonly T injector;

		private T[] vUdLPVXZrvheiAvfyFKafHSgpxyt;

		private int qbjtslUUEjnEFsjgAWqtjXvgIcdK;

		private int VtRGFHZPHichzcbZArNosyxxbdmjA;

		private int ITKFEOfHFwyeSEhfsVxBKGRFckcz;

		private int DxXfLMUfYTNdLhMOookHAoSKFusZ;

		private bool iWpfKcqXmqDhbzZkeAFArJrZldlC;

		public int Count => qbjtslUUEjnEFsjgAWqtjXvgIcdK;

		public int Length => qbjtslUUEjnEFsjgAWqtjXvgIcdK;

		public int MaxLength => VtRGFHZPHichzcbZArNosyxxbdmjA;

		public int FreeSpace => VtRGFHZPHichzcbZArNosyxxbdmjA - qbjtslUUEjnEFsjgAWqtjXvgIcdK;

		public T this[int index]
		{
			get
			{
				if (index >= qbjtslUUEjnEFsjgAWqtjXvgIcdK)
				{
					throw new IndexOutOfRangeException();
				}
				return vUdLPVXZrvheiAvfyFKafHSgpxyt[index];
			}
		}

		public ExpandableArray_DataContainer(int P_0, bool P_1 = true, int P_2 = 0)
		{
			injector = new T();
			vUdLPVXZrvheiAvfyFKafHSgpxyt = new T[P_0];
			qbjtslUUEjnEFsjgAWqtjXvgIcdK = 0;
			VtRGFHZPHichzcbZArNosyxxbdmjA = P_0;
			iWpfKcqXmqDhbzZkeAFArJrZldlC = P_1;
			ITKFEOfHFwyeSEhfsVxBKGRFckcz = P_2;
			for (int i = 0; i < VtRGFHZPHichzcbZArNosyxxbdmjA; i++)
			{
				vUdLPVXZrvheiAvfyFKafHSgpxyt[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (iWpfKcqXmqDhbzZkeAFArJrZldlC)
			{
				injector.kBGUvxOOjLYBbiYWVtxxOQRHlpWO();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (iWpfKcqXmqDhbzZkeAFArJrZldlC)
			{
				injector.kBGUvxOOjLYBbiYWVtxxOQRHlpWO();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (qbjtslUUEjnEFsjgAWqtjXvgIcdK >= VtRGFHZPHichzcbZArNosyxxbdmjA)
			{
				if (ITKFEOfHFwyeSEhfsVxBKGRFckcz <= 0)
				{
					return -1;
				}
				tZUNOxutTKXMLKKfCvmIQAgwASGr();
			}
			int num = qbjtslUUEjnEFsjgAWqtjXvgIcdK;
			vUdLPVXZrvheiAvfyFKafHSgpxyt[num].LCUIhawQpxOGJQabaynagNtLUQpN(item);
			qbjtslUUEjnEFsjgAWqtjXvgIcdK = num + 1;
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
			for (int i = 0; i < qbjtslUUEjnEFsjgAWqtjXvgIcdK; i++)
			{
				if (vUdLPVXZrvheiAvfyFKafHSgpxyt[i].MapxCdOhoKqLPDmPDicUjuDaFGJdb(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < qbjtslUUEjnEFsjgAWqtjXvgIcdK; i++)
			{
				if (vUdLPVXZrvheiAvfyFKafHSgpxyt[i].MapxCdOhoKqLPDmPDicUjuDaFGJdb(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (iWpfKcqXmqDhbzZkeAFArJrZldlC)
			{
				injector.kBGUvxOOjLYBbiYWVtxxOQRHlpWO();
				for (int i = 0; i < qbjtslUUEjnEFsjgAWqtjXvgIcdK; i++)
				{
					vUdLPVXZrvheiAvfyFKafHSgpxyt[i].kBGUvxOOjLYBbiYWVtxxOQRHlpWO();
				}
			}
			qbjtslUUEjnEFsjgAWqtjXvgIcdK = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= qbjtslUUEjnEFsjgAWqtjXvgIcdK)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == qbjtslUUEjnEFsjgAWqtjXvgIcdK - 1)
			{
				RemoveLast();
				return;
			}
			if (iWpfKcqXmqDhbzZkeAFArJrZldlC)
			{
				vUdLPVXZrvheiAvfyFKafHSgpxyt[index].kBGUvxOOjLYBbiYWVtxxOQRHlpWO();
			}
			for (int i = index; i < qbjtslUUEjnEFsjgAWqtjXvgIcdK - 1; i++)
			{
				vUdLPVXZrvheiAvfyFKafHSgpxyt[i].LCUIhawQpxOGJQabaynagNtLUQpN(vUdLPVXZrvheiAvfyFKafHSgpxyt[i + 1]);
			}
			if (iWpfKcqXmqDhbzZkeAFArJrZldlC)
			{
				vUdLPVXZrvheiAvfyFKafHSgpxyt[qbjtslUUEjnEFsjgAWqtjXvgIcdK - 1].kBGUvxOOjLYBbiYWVtxxOQRHlpWO();
			}
			qbjtslUUEjnEFsjgAWqtjXvgIcdK--;
		}

		public void RemoveLast()
		{
			if (qbjtslUUEjnEFsjgAWqtjXvgIcdK != 0)
			{
				if (iWpfKcqXmqDhbzZkeAFArJrZldlC)
				{
					vUdLPVXZrvheiAvfyFKafHSgpxyt[qbjtslUUEjnEFsjgAWqtjXvgIcdK - 1].kBGUvxOOjLYBbiYWVtxxOQRHlpWO();
				}
				qbjtslUUEjnEFsjgAWqtjXvgIcdK--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == VtRGFHZPHichzcbZArNosyxxbdmjA)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, VtRGFHZPHichzcbZArNosyxxbdmjA);
			for (int i = 0; i < num; i++)
			{
				array[i] = vUdLPVXZrvheiAvfyFKafHSgpxyt[i];
			}
			if (size > VtRGFHZPHichzcbZArNosyxxbdmjA)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (qbjtslUUEjnEFsjgAWqtjXvgIcdK > size)
			{
				qbjtslUUEjnEFsjgAWqtjXvgIcdK = size;
			}
			VtRGFHZPHichzcbZArNosyxxbdmjA = size;
			vUdLPVXZrvheiAvfyFKafHSgpxyt = array;
		}

		public void SortAscending()
		{
			if (qbjtslUUEjnEFsjgAWqtjXvgIcdK == 0)
			{
				return;
			}
			for (int i = 0; i < qbjtslUUEjnEFsjgAWqtjXvgIcdK - 1; i++)
			{
				for (int j = i + 1; j < qbjtslUUEjnEFsjgAWqtjXvgIcdK; j++)
				{
					if (vUdLPVXZrvheiAvfyFKafHSgpxyt[j].CompareTo(vUdLPVXZrvheiAvfyFKafHSgpxyt[i]) < 0)
					{
						T val = vUdLPVXZrvheiAvfyFKafHSgpxyt[i];
						vUdLPVXZrvheiAvfyFKafHSgpxyt[i] = vUdLPVXZrvheiAvfyFKafHSgpxyt[j];
						vUdLPVXZrvheiAvfyFKafHSgpxyt[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (qbjtslUUEjnEFsjgAWqtjXvgIcdK == 0)
			{
				return;
			}
			for (int i = 0; i < qbjtslUUEjnEFsjgAWqtjXvgIcdK - 1; i++)
			{
				for (int j = i + 1; j < qbjtslUUEjnEFsjgAWqtjXvgIcdK; j++)
				{
					if (vUdLPVXZrvheiAvfyFKafHSgpxyt[j].CompareTo(vUdLPVXZrvheiAvfyFKafHSgpxyt[i]) > 0)
					{
						T val = vUdLPVXZrvheiAvfyFKafHSgpxyt[i];
						vUdLPVXZrvheiAvfyFKafHSgpxyt[i] = vUdLPVXZrvheiAvfyFKafHSgpxyt[j];
						vUdLPVXZrvheiAvfyFKafHSgpxyt[j] = val;
					}
				}
			}
		}

		private void tZUNOxutTKXMLKKfCvmIQAgwASGr()
		{
			DxXfLMUfYTNdLhMOookHAoSKFusZ++;
			Resize(VtRGFHZPHichzcbZArNosyxxbdmjA + DxXfLMUfYTNdLhMOookHAoSKFusZ * ITKFEOfHFwyeSEhfsVxBKGRFckcz);
		}
	}
}
