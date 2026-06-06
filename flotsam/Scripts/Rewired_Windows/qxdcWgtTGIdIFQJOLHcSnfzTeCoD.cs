using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;

internal abstract class qxdcWgtTGIdIFQJOLHcSnfzTeCoD : OYzieseEeYXDrIqXsZAdwVmBBsCg
{
	internal abstract class jBzjDzGEyzPSeuWRzXabxxblkXgR
	{
		private int aRnfnTCuEIWWAOsNQekrucQvIstEA;

		private int[] NzwovfkhOnalUUrzoIcXgoggeRtfA;

		protected XvdCdlnqQLDnfbKIpIlhoHeUqiZA[] BfLEqZVYfCqbZTVBQPDqmaOhFAKgA;

		public XvdCdlnqQLDnfbKIpIlhoHeUqiZA NvmbBthWcFYNBnJRYEjtrnHiskOFA;

		private int mYAEFQfvkHZqWAWpvwacDNOplqhU;

		private int FFnBfKhWMzOsefstOtpZEYXeEdGw = -1;

		private bool TrRxqJYenpfUWFTFPmBlfhpcMtHgA;

		protected int WYEMMyFqwPJYAQivDsbJGQFrxRUB => aRnfnTCuEIWWAOsNQekrucQvIstEA;

		protected int[] CHLAVVGEWstTZinHViWYcdnUguUpA => NzwovfkhOnalUUrzoIcXgoggeRtfA;

		public UpdateLoopType EldbqeoxWGKCuStqoyEdIkBcpPvb
		{
			set
			{
				if (FFnBfKhWMzOsefstOtpZEYXeEdGw != (int)updateLoopType)
				{
					FFnBfKhWMzOsefstOtpZEYXeEdGw = (int)updateLoopType;
					mYAEFQfvkHZqWAWpvwacDNOplqhU = NzwovfkhOnalUUrzoIcXgoggeRtfA[(int)updateLoopType];
					NvmbBthWcFYNBnJRYEjtrnHiskOFA = BfLEqZVYfCqbZTVBQPDqmaOhFAKgA[mYAEFQfvkHZqWAWpvwacDNOplqhU];
				}
			}
		}

		public jBzjDzGEyzPSeuWRzXabxxblkXgR()
		{
		}

		public void QOBaJdBLmgYVdtMEPcKQhndUNrFx(UpdateLoopSetting P_0, Func<UpdateLoopType, XvdCdlnqQLDnfbKIpIlhoHeUqiZA> P_1)
		{
			if (TrRxqJYenpfUWFTFPmBlfhpcMtHgA)
			{
				Logger.LogError("Already initialized!");
				return;
			}
			NzwovfkhOnalUUrzoIcXgoggeRtfA = new int[3];
			aRnfnTCuEIWWAOsNQekrucQvIstEA = 0;
			List<XvdCdlnqQLDnfbKIpIlhoHeUqiZA> list = new List<XvdCdlnqQLDnfbKIpIlhoHeUqiZA>();
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					NzwovfkhOnalUUrzoIcXgoggeRtfA[(int)list2[i]] = aRnfnTCuEIWWAOsNQekrucQvIstEA;
					aRnfnTCuEIWWAOsNQekrucQvIstEA++;
					list.Add(P_1(list2[i]));
				}
			}
			BfLEqZVYfCqbZTVBQPDqmaOhFAKgA = list.ToArray();
			NvmbBthWcFYNBnJRYEjtrnHiskOFA = BfLEqZVYfCqbZTVBQPDqmaOhFAKgA[0];
			TrRxqJYenpfUWFTFPmBlfhpcMtHgA = true;
		}

		private void VKSmLbrxqCgNwiiUlQHKNgijiZdT(UpdateLoopType P_0, XvdCdlnqQLDnfbKIpIlhoHeUqiZA P_1)
		{
			BfLEqZVYfCqbZTVBQPDqmaOhFAKgA[NzwovfkhOnalUUrzoIcXgoggeRtfA[(int)P_0]] = P_1;
		}

		public virtual void LqABoUHGobSkNRnkWEeiWGNaplzFA(UpdateLoopType P_0)
		{
			if (FFnBfKhWMzOsefstOtpZEYXeEdGw != (int)P_0)
			{
				EldbqeoxWGKCuStqoyEdIkBcpPvb = P_0;
			}
		}

		public void pzGXOonZOAaAqPskBQwWtcJcYCfy()
		{
			for (int i = 0; i < aRnfnTCuEIWWAOsNQekrucQvIstEA; i++)
			{
				BfLEqZVYfCqbZTVBQPDqmaOhFAKgA[i].lgRQAtvmwdrLTQSTzsOHQtXCWpvF();
			}
		}
	}

	internal abstract class XvdCdlnqQLDnfbKIpIlhoHeUqiZA
	{
		public readonly UpdateLoopType jYvGalzdiLwbfpyOkNHemnYdcLuK;

		public XvdCdlnqQLDnfbKIpIlhoHeUqiZA(UpdateLoopType P_0)
		{
			jYvGalzdiLwbfpyOkNHemnYdcLuK = P_0;
		}

		public abstract void lgRQAtvmwdrLTQSTzsOHQtXCWpvF();
	}

	internal jBzjDzGEyzPSeuWRzXabxxblkXgR xhzAsCpGpdQIgBasAlNWJfZBlnjV;

	public qxdcWgtTGIdIFQJOLHcSnfzTeCoD(jBzjDzGEyzPSeuWRzXabxxblkXgR P_0, byte P_1, HIDInfo P_2)
		: base(P_1, P_2)
	{
		xhzAsCpGpdQIgBasAlNWJfZBlnjV = P_0;
	}

	public virtual void CNgbUhzKXAKZnWyQrJhPPHciXtTl(UpdateLoopType P_0)
	{
		if (xhzAsCpGpdQIgBasAlNWJfZBlnjV != null)
		{
			xhzAsCpGpdQIgBasAlNWJfZBlnjV.LqABoUHGobSkNRnkWEeiWGNaplzFA(P_0);
		}
	}
}
