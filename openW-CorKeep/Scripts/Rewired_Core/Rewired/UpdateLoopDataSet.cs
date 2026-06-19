using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class UpdateLoopDataSet<T> where T : class
	{
		private class AyNsLfKoeNYfAzsmEOXHGjytohIU
		{
			public readonly UpdateLoopType zaIZORCTWbcwhTGrufEXMPEWIrpf;

			public T YbieJIraOYQHgQRNgjPGwDfKbjVm;

			public AyNsLfKoeNYfAzsmEOXHGjytohIU(UpdateLoopType P_0)
			{
				zaIZORCTWbcwhTGrufEXMPEWIrpf = P_0;
			}
		}

		private const int jiejCEmuiDVwNISBlOFbSOzCOVBJ = 0;

		private AyNsLfKoeNYfAzsmEOXHGjytohIU PuDbydqYQjDPcHbSUEswKIQWdfTg;

		private int VwkuSauxjGsPzgDIrKofYvPPWVIR;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] YjkCzUviioPXGmCBCOERepSuYzYe;

		private readonly AyNsLfKoeNYfAzsmEOXHGjytohIU[] PxahEkhLICqFCXzStWtzxlebRAQb;

		private UpdateLoopType bQtndSyDrtCsKZNalHPbytGrJUkN = (UpdateLoopType)(-1);

		public T Current => PuDbydqYQjDPcHbSUEswKIQWdfTg.YbieJIraOYQHgQRNgjPGwDfKbjVm;

		public int Count => VwkuSauxjGsPzgDIrKofYvPPWVIR;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= VwkuSauxjGsPzgDIrKofYvPPWVIR)
				{
					throw new IndexOutOfRangeException();
				}
				return PxahEkhLICqFCXzStWtzxlebRAQb[index].YbieJIraOYQHgQRNgjPGwDfKbjVm;
			}
			set
			{
				if (index < 0 || index >= VwkuSauxjGsPzgDIrKofYvPPWVIR)
				{
					throw new IndexOutOfRangeException();
				}
				PxahEkhLICqFCXzStWtzxlebRAQb[index].YbieJIraOYQHgQRNgjPGwDfKbjVm = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0)
			: this(P_0, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0, Func<T> P_1)
		{
			YjkCzUviioPXGmCBCOERepSuYzYe = new int[3];
			ArrayTools.Fill(YjkCzUviioPXGmCBCOERepSuYzYe, -1);
			List<AyNsLfKoeNYfAzsmEOXHGjytohIU> list = new List<AyNsLfKoeNYfAzsmEOXHGjytohIU>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					AyNsLfKoeNYfAzsmEOXHGjytohIU ayNsLfKoeNYfAzsmEOXHGjytohIU = new AyNsLfKoeNYfAzsmEOXHGjytohIU(list2[i]);
					if (P_1 != null)
					{
						T ybieJIraOYQHgQRNgjPGwDfKbjVm = P_1();
						ayNsLfKoeNYfAzsmEOXHGjytohIU.YbieJIraOYQHgQRNgjPGwDfKbjVm = ybieJIraOYQHgQRNgjPGwDfKbjVm;
					}
					list.Add(ayNsLfKoeNYfAzsmEOXHGjytohIU);
					YjkCzUviioPXGmCBCOERepSuYzYe[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			PxahEkhLICqFCXzStWtzxlebRAQb = list.ToArray();
			VwkuSauxjGsPzgDIrKofYvPPWVIR = PxahEkhLICqFCXzStWtzxlebRAQb.Length;
			SetUpdateLoop(PxahEkhLICqFCXzStWtzxlebRAQb[0].zaIZORCTWbcwhTGrufEXMPEWIrpf);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (bQtndSyDrtCsKZNalHPbytGrJUkN != updateLoop)
			{
				bQtndSyDrtCsKZNalHPbytGrJUkN = updateLoop;
				PuDbydqYQjDPcHbSUEswKIQWdfTg = PxahEkhLICqFCXzStWtzxlebRAQb[YjkCzUviioPXGmCBCOERepSuYzYe[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= VwkuSauxjGsPzgDIrKofYvPPWVIR)
			{
				throw new IndexOutOfRangeException();
			}
			return PxahEkhLICqFCXzStWtzxlebRAQb[index].YbieJIraOYQHgQRNgjPGwDfKbjVm;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return PxahEkhLICqFCXzStWtzxlebRAQb[YjkCzUviioPXGmCBCOERepSuYzYe[(int)updateLoop]].YbieJIraOYQHgQRNgjPGwDfKbjVm;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= VwkuSauxjGsPzgDIrKofYvPPWVIR)
			{
				throw new IndexOutOfRangeException();
			}
			PxahEkhLICqFCXzStWtzxlebRAQb[index].YbieJIraOYQHgQRNgjPGwDfKbjVm = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= VwkuSauxjGsPzgDIrKofYvPPWVIR)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return PxahEkhLICqFCXzStWtzxlebRAQb[index].zaIZORCTWbcwhTGrufEXMPEWIrpf;
		}
	}
}
