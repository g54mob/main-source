using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class HIDControllerElementWithDataSet : HIDControllerElement
	{
		internal abstract class JZcHblEZdJOfYfdmMrRocOPDgYAZ
		{
			private int KjkITVsXPwizuzcalfDwzGcXmzNO;

			private int[] xWdUAhaBLHOiyHISTJIIrCmIMvVe;

			protected zeqqtlhhdqKkPgNxrCdktEnMMtCS[] nmYcSLhBeqLQvFKuKpqdnzeiJRqub;

			public zeqqtlhhdqKkPgNxrCdktEnMMtCS rgvihrYYfduivUTwfcIgkZfCHrqN;

			private int QDFMlAtSvjiHiBbAQAZpeOmBUrFNA;

			private int jQkJaWfBgJDhMmGWhEgKVhrYkikI = -1;

			private bool fKGQUDKQoHyreEHgwImahyTSKudOA;

			protected int imVdwSNAfhouaVpPkeTcGPePSgtHb => KjkITVsXPwizuzcalfDwzGcXmzNO;

			protected int[] oCzpPWHwYgbxpdmevZNaDHqxNaG => xWdUAhaBLHOiyHISTJIIrCmIMvVe;

			public UpdateLoopType gYiXHycDswJzgLyMTpXTHCIINavv
			{
				set
				{
					if (jQkJaWfBgJDhMmGWhEgKVhrYkikI != (int)updateLoopType)
					{
						jQkJaWfBgJDhMmGWhEgKVhrYkikI = (int)updateLoopType;
						QDFMlAtSvjiHiBbAQAZpeOmBUrFNA = xWdUAhaBLHOiyHISTJIIrCmIMvVe[(int)updateLoopType];
						rgvihrYYfduivUTwfcIgkZfCHrqN = nmYcSLhBeqLQvFKuKpqdnzeiJRqub[QDFMlAtSvjiHiBbAQAZpeOmBUrFNA];
					}
				}
			}

			public JZcHblEZdJOfYfdmMrRocOPDgYAZ()
			{
			}

			public void wCAnnDolWFcDCqlwUjBcoDqKkfNA(UpdateLoopSetting P_0, Func<UpdateLoopType, zeqqtlhhdqKkPgNxrCdktEnMMtCS> P_1)
			{
				if (fKGQUDKQoHyreEHgwImahyTSKudOA)
				{
					Logger.LogError("Already initialized!");
					return;
				}
				xWdUAhaBLHOiyHISTJIIrCmIMvVe = new int[3];
				KjkITVsXPwizuzcalfDwzGcXmzNO = 0;
				List<zeqqtlhhdqKkPgNxrCdktEnMMtCS> list = new List<zeqqtlhhdqKkPgNxrCdktEnMMtCS>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list2 = tList.list;
					EnumConverter.ToUpdateLoopTypes(P_0, list2);
					for (int i = 0; i < list2.Count; i++)
					{
						xWdUAhaBLHOiyHISTJIIrCmIMvVe[(int)list2[i]] = KjkITVsXPwizuzcalfDwzGcXmzNO;
						KjkITVsXPwizuzcalfDwzGcXmzNO++;
						list.Add(P_1(list2[i]));
					}
				}
				nmYcSLhBeqLQvFKuKpqdnzeiJRqub = list.ToArray();
				rgvihrYYfduivUTwfcIgkZfCHrqN = nmYcSLhBeqLQvFKuKpqdnzeiJRqub[0];
				fKGQUDKQoHyreEHgwImahyTSKudOA = true;
			}

			private void nKLOdGblzoJOdvzqIlNLKQYRONVB(UpdateLoopType P_0, zeqqtlhhdqKkPgNxrCdktEnMMtCS P_1)
			{
				nmYcSLhBeqLQvFKuKpqdnzeiJRqub[xWdUAhaBLHOiyHISTJIIrCmIMvVe[(int)P_0]] = P_1;
			}

			public virtual void fBLiUOKwdLvJrmEZnARhHshUcoXZ(UpdateLoopType P_0)
			{
				if (jQkJaWfBgJDhMmGWhEgKVhrYkikI != (int)P_0)
				{
					gYiXHycDswJzgLyMTpXTHCIINavv = P_0;
				}
			}

			public void XrZosihcTgTxOOCTkYZPazxWHPNG()
			{
				for (int i = 0; i < KjkITVsXPwizuzcalfDwzGcXmzNO; i++)
				{
					nmYcSLhBeqLQvFKuKpqdnzeiJRqub[i].XfMkhtnhdZQihHLuQHnANFpsTqFf();
				}
			}
		}

		internal abstract class zeqqtlhhdqKkPgNxrCdktEnMMtCS
		{
			public readonly UpdateLoopType HdghUfftvhwWBkBbBJcvJfaNKlQbA;

			public zeqqtlhhdqKkPgNxrCdktEnMMtCS(UpdateLoopType P_0)
			{
				HdghUfftvhwWBkBbBJcvJfaNKlQbA = P_0;
			}

			public abstract void XfMkhtnhdZQihHLuQHnANFpsTqFf();
		}

		internal JZcHblEZdJOfYfdmMrRocOPDgYAZ dataSet;

		public HIDControllerElementWithDataSet(JZcHblEZdJOfYfdmMrRocOPDgYAZ P_0, byte P_1, HIDInfo P_2)
			: base(P_1, P_2)
		{
			dataSet = P_0;
		}

		public virtual void Update(UpdateLoopType updateLoop)
		{
			if (dataSet != null)
			{
				dataSet.fBLiUOKwdLvJrmEZnARhHshUcoXZ(updateLoop);
			}
		}
	}
}
