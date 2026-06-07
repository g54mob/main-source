using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;

internal abstract class yUsCYQUTKXfAziQMWZaMRZpbFnDUA : QTwvMqRjxXBwLOoUpuezGnwheUbM
{
	internal abstract class tNgftXjxdmdbYoAEmNllTxNXQMJd
	{
		private int ayeZhVDBmPvCgmSGHBMjQGUVdAKE;

		private int[] RHnkSbPPDqUrgEImlGRBOWwEjWQV;

		protected XkgccxJWbXIyJRpJHKhlwSDErzFCA[] BMEQLBwXoVSBpTpQFaNqCyIZHFbI;

		public XkgccxJWbXIyJRpJHKhlwSDErzFCA XpezbdWbKDqlToORBWfDHVIJbpJA;

		private int udJnAEYvGATZeEaBmXtgvIlDbHYc;

		private int TWgHXQMBZgNFIbGcZPKZudJEnsjX = -1;

		private bool JyAWTTzEmcrrkLiGEJypHwhKkuos;

		protected int ITRCyQDufAdagNAlQaHlycOTlceLA => ayeZhVDBmPvCgmSGHBMjQGUVdAKE;

		protected int[] IXCehVjURpWsbqSOMddQVGhmRzbo => RHnkSbPPDqUrgEImlGRBOWwEjWQV;

		public UpdateLoopType WgwANuHFuHkzsCCyhVFKUegWEoyOA
		{
			set
			{
				if (TWgHXQMBZgNFIbGcZPKZudJEnsjX != (int)updateLoopType)
				{
					TWgHXQMBZgNFIbGcZPKZudJEnsjX = (int)updateLoopType;
					udJnAEYvGATZeEaBmXtgvIlDbHYc = RHnkSbPPDqUrgEImlGRBOWwEjWQV[(int)updateLoopType];
					XpezbdWbKDqlToORBWfDHVIJbpJA = BMEQLBwXoVSBpTpQFaNqCyIZHFbI[udJnAEYvGATZeEaBmXtgvIlDbHYc];
				}
			}
		}

		public tNgftXjxdmdbYoAEmNllTxNXQMJd()
		{
		}

		public void SEKhtnwRxfkjZpxPSpFWRxtyabsJ(UpdateLoopSetting P_0, Func<UpdateLoopType, XkgccxJWbXIyJRpJHKhlwSDErzFCA> P_1)
		{
			if (JyAWTTzEmcrrkLiGEJypHwhKkuos)
			{
				Logger.LogError("Already initialized!");
				return;
			}
			RHnkSbPPDqUrgEImlGRBOWwEjWQV = new int[3];
			ayeZhVDBmPvCgmSGHBMjQGUVdAKE = 0;
			List<XkgccxJWbXIyJRpJHKhlwSDErzFCA> list = new List<XkgccxJWbXIyJRpJHKhlwSDErzFCA>();
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					RHnkSbPPDqUrgEImlGRBOWwEjWQV[(int)list2[i]] = ayeZhVDBmPvCgmSGHBMjQGUVdAKE;
					ayeZhVDBmPvCgmSGHBMjQGUVdAKE++;
					list.Add(P_1(list2[i]));
				}
			}
			BMEQLBwXoVSBpTpQFaNqCyIZHFbI = list.ToArray();
			XpezbdWbKDqlToORBWfDHVIJbpJA = BMEQLBwXoVSBpTpQFaNqCyIZHFbI[0];
			JyAWTTzEmcrrkLiGEJypHwhKkuos = true;
		}

		private void LVXeUzOybNnHSsrFiofElmuZLQEv(UpdateLoopType P_0, XkgccxJWbXIyJRpJHKhlwSDErzFCA P_1)
		{
			BMEQLBwXoVSBpTpQFaNqCyIZHFbI[RHnkSbPPDqUrgEImlGRBOWwEjWQV[(int)P_0]] = P_1;
		}

		public virtual void RLKbMjjwmVevrltZNUscDwIeiYD(UpdateLoopType P_0)
		{
			if (TWgHXQMBZgNFIbGcZPKZudJEnsjX != (int)P_0)
			{
				WgwANuHFuHkzsCCyhVFKUegWEoyOA = P_0;
			}
		}

		public void rlLussGIFNhKWPthOPzCPLJWNJEe()
		{
			for (int i = 0; i < ayeZhVDBmPvCgmSGHBMjQGUVdAKE; i++)
			{
				BMEQLBwXoVSBpTpQFaNqCyIZHFbI[i].nqILupIZfcUGdSCKszBHwvFwsBQO();
			}
		}
	}

	internal abstract class XkgccxJWbXIyJRpJHKhlwSDErzFCA
	{
		public readonly UpdateLoopType lIoCQdMKnAfARezXdCwkWQAFpdXsA;

		public XkgccxJWbXIyJRpJHKhlwSDErzFCA(UpdateLoopType P_0)
		{
			lIoCQdMKnAfARezXdCwkWQAFpdXsA = P_0;
		}

		public abstract void nqILupIZfcUGdSCKszBHwvFwsBQO();
	}

	internal tNgftXjxdmdbYoAEmNllTxNXQMJd zxoDSUYMiiUxCVMjPQiWlaLfTiQX;

	public yUsCYQUTKXfAziQMWZaMRZpbFnDUA(tNgftXjxdmdbYoAEmNllTxNXQMJd P_0, byte P_1, HIDInfo P_2)
		: base(P_1, P_2)
	{
		zxoDSUYMiiUxCVMjPQiWlaLfTiQX = P_0;
	}

	public virtual void SxlKqlOEQXLyDOUBqNwPjMoOfGiT(UpdateLoopType P_0)
	{
		if (zxoDSUYMiiUxCVMjPQiWlaLfTiQX != null)
		{
			zxoDSUYMiiUxCVMjPQiWlaLfTiQX.RLKbMjjwmVevrltZNUscDwIeiYD(P_0);
		}
	}
}
