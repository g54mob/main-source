using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class HIDControllerElementWithDataSet : HIDControllerElement
	{
		internal abstract class kpSgNRJMRzKQrZwlcddeBBGBDbsc
		{
			private int zKNtmbVJSUIhhpIlDRmgJjPGVbp;

			private int[] GGUmNuLERIewxJGyglaRVORwSAG;

			protected YEGXFvUHUXCyKCwNcPcYimKmYc[] FRUUibiOIWEsSCBxDuohaLtzlQrt;

			public YEGXFvUHUXCyKCwNcPcYimKmYc CLjmYleEuCraJMMUJEFwtuAaGlg;

			private int makeqSfOesOCmoTnKnppZmDJCnQg;

			private int sWXAmbipLtAbjKNEztzXOrpNGHPi = -1;

			private bool fxzgZHdorylahBrNCBxmuceoqOgc;

			protected int dataCount
			{
				get
				{
					return zKNtmbVJSUIhhpIlDRmgJjPGVbp;
				}
			}

			protected int[] updateLoopIndex
			{
				get
				{
					return GGUmNuLERIewxJGyglaRVORwSAG;
				}
			}

			public UpdateLoopType updateLoop
			{
				set
				{
					while (true)
					{
						switch (0x38546A90 ^ 0x38546A92)
						{
						case 0:
							continue;
						case 2:
							if (sWXAmbipLtAbjKNEztzXOrpNGHPi == (int)value)
							{
								return;
							}
							break;
						}
						break;
					}
					sWXAmbipLtAbjKNEztzXOrpNGHPi = (int)value;
					makeqSfOesOCmoTnKnppZmDJCnQg = GGUmNuLERIewxJGyglaRVORwSAG[(int)value];
					CLjmYleEuCraJMMUJEFwtuAaGlg = FRUUibiOIWEsSCBxDuohaLtzlQrt[makeqSfOesOCmoTnKnppZmDJCnQg];
				}
			}

			public kpSgNRJMRzKQrZwlcddeBBGBDbsc()
			{
			}

			public void hvfmLVrxQSWNdDBhcvYEClbOwhb(UpdateLoopSetting P_0, Func<UpdateLoopType, YEGXFvUHUXCyKCwNcPcYimKmYc> P_1)
			{
				if (fxzgZHdorylahBrNCBxmuceoqOgc)
				{
					Logger.LogError("Already initialized!");
					return;
				}
				GGUmNuLERIewxJGyglaRVORwSAG = new int[3];
				zKNtmbVJSUIhhpIlDRmgJjPGVbp = 0;
				List<YEGXFvUHUXCyKCwNcPcYimKmYc> list = new List<YEGXFvUHUXCyKCwNcPcYimKmYc>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list2 = tList.list;
					EnumConverter.ToUpdateLoopTypes(P_0, list2);
					int num = 0;
					while (true)
					{
						IL_0044:
						int num2 = -51464272;
						while (true)
						{
							switch (num2 ^ -51464270)
							{
							case 0:
								break;
							default:
								goto end_IL_0049;
							case 5:
								num++;
								num2 = -51464269;
								continue;
							case 1:
							{
								int num3;
								if (num >= list2.Count)
								{
									num2 = -51464271;
									num3 = num2;
								}
								else
								{
									num2 = -51464266;
									num3 = num2;
								}
								continue;
							}
							case 2:
								num2 = -51464269;
								continue;
							case 4:
								GGUmNuLERIewxJGyglaRVORwSAG[(int)list2[num]] = zKNtmbVJSUIhhpIlDRmgJjPGVbp;
								zKNtmbVJSUIhhpIlDRmgJjPGVbp++;
								list.Add(P_1(list2[num]));
								num2 = -51464265;
								continue;
							case 3:
								goto end_IL_0049;
							}
							goto IL_0044;
							continue;
							end_IL_0049:
							break;
						}
						break;
					}
				}
				FRUUibiOIWEsSCBxDuohaLtzlQrt = list.ToArray();
				fxzgZHdorylahBrNCBxmuceoqOgc = true;
			}

			private void MTXdoxGavNaSqIwIfxklhNlVJn(UpdateLoopType P_0, YEGXFvUHUXCyKCwNcPcYimKmYc P_1)
			{
				FRUUibiOIWEsSCBxDuohaLtzlQrt[GGUmNuLERIewxJGyglaRVORwSAG[(int)P_0]] = P_1;
			}

			public virtual void Update(UpdateLoopType P_0)
			{
				if (sWXAmbipLtAbjKNEztzXOrpNGHPi != (int)P_0)
				{
					updateLoop = P_0;
				}
			}

			public void xaGVjRxEvIdELjjBskoGFDUNmrm()
			{
				int num = 0;
				while (num < zKNtmbVJSUIhhpIlDRmgJjPGVbp)
				{
					while (true)
					{
						FRUUibiOIWEsSCBxDuohaLtzlQrt[num].Reset();
						num++;
						int num2 = -45174010;
						while (true)
						{
							switch (num2 ^ -45174009)
							{
							case 0:
								num2 = -45174011;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0022;
							}
							break;
						}
						continue;
						end_IL_0022:
						break;
					}
				}
			}
		}

		internal abstract class YEGXFvUHUXCyKCwNcPcYimKmYc
		{
			public readonly UpdateLoopType NigWaDmPBoxUjERAcsoKpawNrzS;

			public YEGXFvUHUXCyKCwNcPcYimKmYc(UpdateLoopType updateLoop)
			{
				NigWaDmPBoxUjERAcsoKpawNrzS = updateLoop;
			}

			public abstract void Reset();
		}

		internal kpSgNRJMRzKQrZwlcddeBBGBDbsc dataSet;

		public HIDControllerElementWithDataSet(kpSgNRJMRzKQrZwlcddeBBGBDbsc dataSet, byte reportId, HIDInfo hidInfo)
			: base(reportId, hidInfo)
		{
			this.dataSet = dataSet;
		}

		public virtual void Update(UpdateLoopType updateLoop)
		{
			if (dataSet != null)
			{
				dataSet.Update(updateLoop);
			}
		}
	}
}
