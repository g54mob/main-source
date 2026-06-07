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
		private class QDLFQUiINosSxaIbIUAJYzJFYLVc
		{
			public readonly UpdateLoopType bHWzVkyXwCHhrEORwDqNjAXuivayA;

			public T CakoahFGwpYTqLStmakWineuyYAN;

			public QDLFQUiINosSxaIbIUAJYzJFYLVc(UpdateLoopType P_0)
			{
				bHWzVkyXwCHhrEORwDqNjAXuivayA = P_0;
			}
		}

		private const int fCectvBUOkhYRmNjjhFdrMciazODb = 0;

		private QDLFQUiINosSxaIbIUAJYzJFYLVc FnBDaQiScKmGqcAoFOResOPLgQIuB;

		private int VPqdgXdKDxzfzdncjiprEGICdwNac;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] WvahKUNxMPBKRtUuGIRFoqiSftFHA;

		private readonly QDLFQUiINosSxaIbIUAJYzJFYLVc[] PXiEntRrdfTpDMhJvqFfrNiLsxVl;

		private UpdateLoopType lWlTzzIoJYifOEgQnBMjdsFRtdrAA = (UpdateLoopType)(-1);

		public T Current => FnBDaQiScKmGqcAoFOResOPLgQIuB.CakoahFGwpYTqLStmakWineuyYAN;

		public int Count => VPqdgXdKDxzfzdncjiprEGICdwNac;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= VPqdgXdKDxzfzdncjiprEGICdwNac)
				{
					throw new IndexOutOfRangeException();
				}
				return PXiEntRrdfTpDMhJvqFfrNiLsxVl[index].CakoahFGwpYTqLStmakWineuyYAN;
			}
			set
			{
				if (index < 0 || index >= VPqdgXdKDxzfzdncjiprEGICdwNac)
				{
					throw new IndexOutOfRangeException();
				}
				PXiEntRrdfTpDMhJvqFfrNiLsxVl[index].CakoahFGwpYTqLStmakWineuyYAN = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0)
			: this(P_0, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0, Func<T> P_1)
		{
			WvahKUNxMPBKRtUuGIRFoqiSftFHA = new int[3];
			ArrayTools.Fill(WvahKUNxMPBKRtUuGIRFoqiSftFHA, -1);
			List<QDLFQUiINosSxaIbIUAJYzJFYLVc> list = new List<QDLFQUiINosSxaIbIUAJYzJFYLVc>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					QDLFQUiINosSxaIbIUAJYzJFYLVc qDLFQUiINosSxaIbIUAJYzJFYLVc = new QDLFQUiINosSxaIbIUAJYzJFYLVc(list2[i]);
					if (P_1 != null)
					{
						T cakoahFGwpYTqLStmakWineuyYAN = P_1();
						qDLFQUiINosSxaIbIUAJYzJFYLVc.CakoahFGwpYTqLStmakWineuyYAN = cakoahFGwpYTqLStmakWineuyYAN;
					}
					list.Add(qDLFQUiINosSxaIbIUAJYzJFYLVc);
					WvahKUNxMPBKRtUuGIRFoqiSftFHA[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			PXiEntRrdfTpDMhJvqFfrNiLsxVl = list.ToArray();
			VPqdgXdKDxzfzdncjiprEGICdwNac = PXiEntRrdfTpDMhJvqFfrNiLsxVl.Length;
			SetUpdateLoop(PXiEntRrdfTpDMhJvqFfrNiLsxVl[0].bHWzVkyXwCHhrEORwDqNjAXuivayA);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (lWlTzzIoJYifOEgQnBMjdsFRtdrAA != updateLoop)
			{
				lWlTzzIoJYifOEgQnBMjdsFRtdrAA = updateLoop;
				FnBDaQiScKmGqcAoFOResOPLgQIuB = PXiEntRrdfTpDMhJvqFfrNiLsxVl[WvahKUNxMPBKRtUuGIRFoqiSftFHA[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= VPqdgXdKDxzfzdncjiprEGICdwNac)
			{
				throw new IndexOutOfRangeException();
			}
			return PXiEntRrdfTpDMhJvqFfrNiLsxVl[index].CakoahFGwpYTqLStmakWineuyYAN;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return PXiEntRrdfTpDMhJvqFfrNiLsxVl[WvahKUNxMPBKRtUuGIRFoqiSftFHA[(int)updateLoop]].CakoahFGwpYTqLStmakWineuyYAN;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= VPqdgXdKDxzfzdncjiprEGICdwNac)
			{
				throw new IndexOutOfRangeException();
			}
			PXiEntRrdfTpDMhJvqFfrNiLsxVl[index].CakoahFGwpYTqLStmakWineuyYAN = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= VPqdgXdKDxzfzdncjiprEGICdwNac)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return PXiEntRrdfTpDMhJvqFfrNiLsxVl[index].bHWzVkyXwCHhrEORwDqNjAXuivayA;
		}
	}
}
