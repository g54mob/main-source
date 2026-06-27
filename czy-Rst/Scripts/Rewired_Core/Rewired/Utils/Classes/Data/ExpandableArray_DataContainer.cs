using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.AphGxYfQNjFhYUDfLZfCHZGYDAEN, new()
	{
		public interface AphGxYfQNjFhYUDfLZfCHZGYDAEN : IComparable<T>
		{
			void IxzjMqFEtfwjOBCFSXsFYguTfdWJ(T P_0);

			bool RnSBYdlcVChjKWYdxWSvQwKmVpkO(T P_0);

			void vxddddbOiXviuteknBwWaOZBMnlD();
		}

		public readonly T injector;

		private T[] yDIRLoaEadYphNJAEseRJPCaKfFg;

		private int feOibxfarnPPEzxSgjqWJEqgGlGFA;

		private int CRqNjRsbcsXGgibpmIvPGPabRGFt;

		private int BFfOGWSigoOwVZGTAJSwwGSNdNBV;

		private int QHoXQSvpwFXDCcevYGUieTgSHbFf;

		private bool bCUrhgHNwcbxaAivSzwnSDWXfAYdb;

		public int Count => feOibxfarnPPEzxSgjqWJEqgGlGFA;

		public int Length => feOibxfarnPPEzxSgjqWJEqgGlGFA;

		public int MaxLength => CRqNjRsbcsXGgibpmIvPGPabRGFt;

		public int FreeSpace => CRqNjRsbcsXGgibpmIvPGPabRGFt - feOibxfarnPPEzxSgjqWJEqgGlGFA;

		public T this[int index]
		{
			get
			{
				if (index >= feOibxfarnPPEzxSgjqWJEqgGlGFA)
				{
					throw new IndexOutOfRangeException();
				}
				return yDIRLoaEadYphNJAEseRJPCaKfFg[index];
			}
		}

		public ExpandableArray_DataContainer(int P_0, bool P_1 = true, int P_2 = 0)
		{
			injector = new T();
			yDIRLoaEadYphNJAEseRJPCaKfFg = new T[P_0];
			feOibxfarnPPEzxSgjqWJEqgGlGFA = 0;
			CRqNjRsbcsXGgibpmIvPGPabRGFt = P_0;
			bCUrhgHNwcbxaAivSzwnSDWXfAYdb = P_1;
			BFfOGWSigoOwVZGTAJSwwGSNdNBV = P_2;
			for (int i = 0; i < CRqNjRsbcsXGgibpmIvPGPabRGFt; i++)
			{
				yDIRLoaEadYphNJAEseRJPCaKfFg[i] = new T();
			}
		}

		public int Inject()
		{
			int result = AddData(injector);
			if (bCUrhgHNwcbxaAivSzwnSDWXfAYdb)
			{
				injector.vxddddbOiXviuteknBwWaOZBMnlD();
			}
			return result;
		}

		public int InjectIfUnique()
		{
			int result = AddIfUnique(injector);
			if (bCUrhgHNwcbxaAivSzwnSDWXfAYdb)
			{
				injector.vxddddbOiXviuteknBwWaOZBMnlD();
			}
			return result;
		}

		public int AddData(T item)
		{
			if (feOibxfarnPPEzxSgjqWJEqgGlGFA >= CRqNjRsbcsXGgibpmIvPGPabRGFt)
			{
				if (BFfOGWSigoOwVZGTAJSwwGSNdNBV <= 0)
				{
					return -1;
				}
				wCzjRleZqGxxSlNJgrLpcivwHpnVA();
			}
			int num = feOibxfarnPPEzxSgjqWJEqgGlGFA;
			yDIRLoaEadYphNJAEseRJPCaKfFg[num].IxzjMqFEtfwjOBCFSXsFYguTfdWJ(item);
			feOibxfarnPPEzxSgjqWJEqgGlGFA = num + 1;
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
			for (int i = 0; i < feOibxfarnPPEzxSgjqWJEqgGlGFA; i++)
			{
				if (yDIRLoaEadYphNJAEseRJPCaKfFg[i].RnSBYdlcVChjKWYdxWSvQwKmVpkO(item))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOfData(T item)
		{
			for (int i = 0; i < feOibxfarnPPEzxSgjqWJEqgGlGFA; i++)
			{
				if (yDIRLoaEadYphNJAEseRJPCaKfFg[i].RnSBYdlcVChjKWYdxWSvQwKmVpkO(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			if (bCUrhgHNwcbxaAivSzwnSDWXfAYdb)
			{
				injector.vxddddbOiXviuteknBwWaOZBMnlD();
				for (int i = 0; i < feOibxfarnPPEzxSgjqWJEqgGlGFA; i++)
				{
					yDIRLoaEadYphNJAEseRJPCaKfFg[i].vxddddbOiXviuteknBwWaOZBMnlD();
				}
			}
			feOibxfarnPPEzxSgjqWJEqgGlGFA = 0;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= feOibxfarnPPEzxSgjqWJEqgGlGFA)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == feOibxfarnPPEzxSgjqWJEqgGlGFA - 1)
			{
				RemoveLast();
				return;
			}
			if (bCUrhgHNwcbxaAivSzwnSDWXfAYdb)
			{
				yDIRLoaEadYphNJAEseRJPCaKfFg[index].vxddddbOiXviuteknBwWaOZBMnlD();
			}
			for (int i = index; i < feOibxfarnPPEzxSgjqWJEqgGlGFA - 1; i++)
			{
				yDIRLoaEadYphNJAEseRJPCaKfFg[i].IxzjMqFEtfwjOBCFSXsFYguTfdWJ(yDIRLoaEadYphNJAEseRJPCaKfFg[i + 1]);
			}
			if (bCUrhgHNwcbxaAivSzwnSDWXfAYdb)
			{
				yDIRLoaEadYphNJAEseRJPCaKfFg[feOibxfarnPPEzxSgjqWJEqgGlGFA - 1].vxddddbOiXviuteknBwWaOZBMnlD();
			}
			feOibxfarnPPEzxSgjqWJEqgGlGFA--;
		}

		public void RemoveLast()
		{
			if (feOibxfarnPPEzxSgjqWJEqgGlGFA != 0)
			{
				if (bCUrhgHNwcbxaAivSzwnSDWXfAYdb)
				{
					yDIRLoaEadYphNJAEseRJPCaKfFg[feOibxfarnPPEzxSgjqWJEqgGlGFA - 1].vxddddbOiXviuteknBwWaOZBMnlD();
				}
				feOibxfarnPPEzxSgjqWJEqgGlGFA--;
			}
		}

		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == CRqNjRsbcsXGgibpmIvPGPabRGFt)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, CRqNjRsbcsXGgibpmIvPGPabRGFt);
			for (int i = 0; i < num; i++)
			{
				array[i] = yDIRLoaEadYphNJAEseRJPCaKfFg[i];
			}
			if (size > CRqNjRsbcsXGgibpmIvPGPabRGFt)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = new T();
				}
			}
			else if (feOibxfarnPPEzxSgjqWJEqgGlGFA > size)
			{
				feOibxfarnPPEzxSgjqWJEqgGlGFA = size;
			}
			CRqNjRsbcsXGgibpmIvPGPabRGFt = size;
			yDIRLoaEadYphNJAEseRJPCaKfFg = array;
		}

		public void SortAscending()
		{
			if (feOibxfarnPPEzxSgjqWJEqgGlGFA == 0)
			{
				return;
			}
			for (int i = 0; i < feOibxfarnPPEzxSgjqWJEqgGlGFA - 1; i++)
			{
				for (int j = i + 1; j < feOibxfarnPPEzxSgjqWJEqgGlGFA; j++)
				{
					if (yDIRLoaEadYphNJAEseRJPCaKfFg[j].CompareTo(yDIRLoaEadYphNJAEseRJPCaKfFg[i]) < 0)
					{
						T val = yDIRLoaEadYphNJAEseRJPCaKfFg[i];
						yDIRLoaEadYphNJAEseRJPCaKfFg[i] = yDIRLoaEadYphNJAEseRJPCaKfFg[j];
						yDIRLoaEadYphNJAEseRJPCaKfFg[j] = val;
					}
				}
			}
		}

		public void SortDescending()
		{
			if (feOibxfarnPPEzxSgjqWJEqgGlGFA == 0)
			{
				return;
			}
			for (int i = 0; i < feOibxfarnPPEzxSgjqWJEqgGlGFA - 1; i++)
			{
				for (int j = i + 1; j < feOibxfarnPPEzxSgjqWJEqgGlGFA; j++)
				{
					if (yDIRLoaEadYphNJAEseRJPCaKfFg[j].CompareTo(yDIRLoaEadYphNJAEseRJPCaKfFg[i]) > 0)
					{
						T val = yDIRLoaEadYphNJAEseRJPCaKfFg[i];
						yDIRLoaEadYphNJAEseRJPCaKfFg[i] = yDIRLoaEadYphNJAEseRJPCaKfFg[j];
						yDIRLoaEadYphNJAEseRJPCaKfFg[j] = val;
					}
				}
			}
		}

		private void wCzjRleZqGxxSlNJgrLpcivwHpnVA()
		{
			QHoXQSvpwFXDCcevYGUieTgSHbFf++;
			Resize(CRqNjRsbcsXGgibpmIvPGPabRGFt + QHoXQSvpwFXDCcevYGUieTgSHbFf * BFfOGWSigoOwVZGTAJSwwGSNdNBV);
		}
	}
}
