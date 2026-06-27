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
		private class BgeDirtXbXNSVkERqlJyurAhGDrE
		{
			public readonly UpdateLoopType cHdBRRjptrkIicGTQvRaQuNKgjSgb;

			public T BdBmaEWAxEtmtLIlYvNvOOaENIiv;

			public BgeDirtXbXNSVkERqlJyurAhGDrE(UpdateLoopType P_0)
			{
				cHdBRRjptrkIicGTQvRaQuNKgjSgb = P_0;
			}
		}

		private const int iaPerOIZDNGpSPZdHVcWLsoGqriLA = 0;

		private BgeDirtXbXNSVkERqlJyurAhGDrE StsYcdRAdnRtdOQwaywHmxZKWFyE;

		private int SMHyywHYIETKipkkJiAAguKHHsnMA;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] RpJLAjQHJugjGAfqieqoeOiKodhMb;

		private readonly BgeDirtXbXNSVkERqlJyurAhGDrE[] EBFtnWGpeKcSSCJLPBsMBVsxiwfLA;

		private UpdateLoopType eXUDfGgNQvjADfACNDxUMYBbInDDA = (UpdateLoopType)(-1);

		public T Current => StsYcdRAdnRtdOQwaywHmxZKWFyE.BdBmaEWAxEtmtLIlYvNvOOaENIiv;

		public int Count => SMHyywHYIETKipkkJiAAguKHHsnMA;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= SMHyywHYIETKipkkJiAAguKHHsnMA)
				{
					throw new IndexOutOfRangeException();
				}
				return EBFtnWGpeKcSSCJLPBsMBVsxiwfLA[index].BdBmaEWAxEtmtLIlYvNvOOaENIiv;
			}
			set
			{
				if (index < 0 || index >= SMHyywHYIETKipkkJiAAguKHHsnMA)
				{
					throw new IndexOutOfRangeException();
				}
				EBFtnWGpeKcSSCJLPBsMBVsxiwfLA[index].BdBmaEWAxEtmtLIlYvNvOOaENIiv = value;
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0)
			: this(P_0, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting P_0, Func<T> P_1)
		{
			RpJLAjQHJugjGAfqieqoeOiKodhMb = new int[3];
			ArrayTools.Fill(RpJLAjQHJugjGAfqieqoeOiKodhMb, -1);
			List<BgeDirtXbXNSVkERqlJyurAhGDrE> list = new List<BgeDirtXbXNSVkERqlJyurAhGDrE>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					BgeDirtXbXNSVkERqlJyurAhGDrE bgeDirtXbXNSVkERqlJyurAhGDrE = new BgeDirtXbXNSVkERqlJyurAhGDrE(list2[i]);
					if (P_1 != null)
					{
						T bdBmaEWAxEtmtLIlYvNvOOaENIiv = P_1();
						bgeDirtXbXNSVkERqlJyurAhGDrE.BdBmaEWAxEtmtLIlYvNvOOaENIiv = bdBmaEWAxEtmtLIlYvNvOOaENIiv;
					}
					list.Add(bgeDirtXbXNSVkERqlJyurAhGDrE);
					RpJLAjQHJugjGAfqieqoeOiKodhMb[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			EBFtnWGpeKcSSCJLPBsMBVsxiwfLA = list.ToArray();
			SMHyywHYIETKipkkJiAAguKHHsnMA = EBFtnWGpeKcSSCJLPBsMBVsxiwfLA.Length;
			SetUpdateLoop(EBFtnWGpeKcSSCJLPBsMBVsxiwfLA[0].cHdBRRjptrkIicGTQvRaQuNKgjSgb);
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (eXUDfGgNQvjADfACNDxUMYBbInDDA != updateLoop)
			{
				eXUDfGgNQvjADfACNDxUMYBbInDDA = updateLoop;
				StsYcdRAdnRtdOQwaywHmxZKWFyE = EBFtnWGpeKcSSCJLPBsMBVsxiwfLA[RpJLAjQHJugjGAfqieqoeOiKodhMb[(int)updateLoop]];
			}
		}

		public T Get(int index)
		{
			if (index < 0 || index >= SMHyywHYIETKipkkJiAAguKHHsnMA)
			{
				throw new IndexOutOfRangeException();
			}
			return EBFtnWGpeKcSSCJLPBsMBVsxiwfLA[index].BdBmaEWAxEtmtLIlYvNvOOaENIiv;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return EBFtnWGpeKcSSCJLPBsMBVsxiwfLA[RpJLAjQHJugjGAfqieqoeOiKodhMb[(int)updateLoop]].BdBmaEWAxEtmtLIlYvNvOOaENIiv;
		}

		public void Set(int index, T item)
		{
			if (index < 0 || index >= SMHyywHYIETKipkkJiAAguKHHsnMA)
			{
				throw new IndexOutOfRangeException();
			}
			EBFtnWGpeKcSSCJLPBsMBVsxiwfLA[index].BdBmaEWAxEtmtLIlYvNvOOaENIiv = item;
		}

		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= SMHyywHYIETKipkkJiAAguKHHsnMA)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return EBFtnWGpeKcSSCJLPBsMBVsxiwfLA[index].cHdBRRjptrkIicGTQvRaQuNKgjSgb;
		}
	}
}
