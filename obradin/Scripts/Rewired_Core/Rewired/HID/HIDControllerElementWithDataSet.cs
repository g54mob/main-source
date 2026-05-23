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
		internal abstract class VxUwUEwsHpyhUrKaCKjiygOVwov
		{
			private int QdTdferWUIGCEcDqtckseuZfSkeF;

			private int[] xcSjpzzrNYXAIxAxYcwPczRgjNT;

			protected rBYVXUVToIgLLonOpRikzkiCPOx[] gRSZlsGnOMePzdfqhIobycvdjXwm;

			public rBYVXUVToIgLLonOpRikzkiCPOx xbRrcEKKIAKiQkVzQCekOswVHrJ;

			private int RMmuzLwPyyqjZzFkavzjXDLDVyZ;

			private int ZMZbecCGBpEGMhMVXcfFEAvXLKW = -1;

			private bool WktzUSAcjulBYRNUcifkLEmijRhD;

			protected int dataCount
			{
				get
				{
					return QdTdferWUIGCEcDqtckseuZfSkeF;
				}
			}

			protected int[] updateLoopIndex
			{
				get
				{
					return xcSjpzzrNYXAIxAxYcwPczRgjNT;
				}
			}

			public UpdateLoopType updateLoop
			{
				set
				{
					if (ZMZbecCGBpEGMhMVXcfFEAvXLKW != (int)value)
					{
						ZMZbecCGBpEGMhMVXcfFEAvXLKW = (int)value;
						RMmuzLwPyyqjZzFkavzjXDLDVyZ = xcSjpzzrNYXAIxAxYcwPczRgjNT[(int)value];
						xbRrcEKKIAKiQkVzQCekOswVHrJ = gRSZlsGnOMePzdfqhIobycvdjXwm[RMmuzLwPyyqjZzFkavzjXDLDVyZ];
					}
				}
			}

			public VxUwUEwsHpyhUrKaCKjiygOVwov()
			{
			}

			public void AhzGMQRtWGSyIzEkOTUIlpjMwgy(UpdateLoopSetting P_0, Func<UpdateLoopType, rBYVXUVToIgLLonOpRikzkiCPOx> P_1)
			{
				if (WktzUSAcjulBYRNUcifkLEmijRhD)
				{
					Logger.LogError("Already initialized!");
					return;
				}
				xcSjpzzrNYXAIxAxYcwPczRgjNT = new int[3];
				QdTdferWUIGCEcDqtckseuZfSkeF = 0;
				List<rBYVXUVToIgLLonOpRikzkiCPOx> list = new List<rBYVXUVToIgLLonOpRikzkiCPOx>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list2 = tList.list;
					int num2 = default(int);
					while (true)
					{
						IL_003a:
						int num = 1282224864;
						while (true)
						{
							switch (num ^ 0x4C6D32E4)
							{
							case 2:
								break;
							default:
								goto end_IL_003f;
							case 4:
								EnumConverter.ToUpdateLoopTypes(P_0, list2);
								num = 1282224871;
								continue;
							case 5:
							{
								int num3;
								if (num2 >= list2.Count)
								{
									num = 1282224866;
									num3 = num;
								}
								else
								{
									num = 1282224868;
									num3 = num;
								}
								continue;
							}
							case 3:
								num2 = 0;
								num = 1282224865;
								continue;
							case 1:
								list.Add(P_1(list2[num2]));
								num2++;
								num = 1282224865;
								continue;
							case 0:
								xcSjpzzrNYXAIxAxYcwPczRgjNT[(int)list2[num2]] = QdTdferWUIGCEcDqtckseuZfSkeF;
								QdTdferWUIGCEcDqtckseuZfSkeF++;
								num = 1282224869;
								continue;
							case 6:
								goto end_IL_003f;
							}
							goto IL_003a;
							continue;
							end_IL_003f:
							break;
						}
						break;
					}
				}
				gRSZlsGnOMePzdfqhIobycvdjXwm = list.ToArray();
				WktzUSAcjulBYRNUcifkLEmijRhD = true;
			}

			private void nLNuAdTDynRDdIovgbVsYLTjOyu(UpdateLoopType P_0, rBYVXUVToIgLLonOpRikzkiCPOx P_1)
			{
				gRSZlsGnOMePzdfqhIobycvdjXwm[xcSjpzzrNYXAIxAxYcwPczRgjNT[(int)P_0]] = P_1;
			}

			public virtual void Update(UpdateLoopType P_0)
			{
				if (ZMZbecCGBpEGMhMVXcfFEAvXLKW == (int)P_0)
				{
					return;
				}
				while (true)
				{
					updateLoop = P_0;
					int num = -1369951189;
					while (true)
					{
						switch (num ^ -1369951190)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000a:
						num = -1369951192;
					}
				}
			}

			public void EEGiMNPSMElaPgKQdmScoWLedfb()
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < QdTdferWUIGCEcDqtckseuZfSkeF)
					{
						num2 = -1248158845;
						num3 = num2;
					}
					else
					{
						num2 = -1248158846;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1248158848)
						{
						case 0:
							num2 = -1248158845;
							continue;
						default:
							return;
						case 3:
							gRSZlsGnOMePzdfqhIobycvdjXwm[num].Reset();
							num++;
							num2 = -1248158847;
							continue;
						case 1:
							break;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		internal abstract class rBYVXUVToIgLLonOpRikzkiCPOx
		{
			public readonly UpdateLoopType uZqPISCyPgGPOetNKiFUKtuJqjV;

			public rBYVXUVToIgLLonOpRikzkiCPOx(UpdateLoopType updateLoop)
			{
				uZqPISCyPgGPOetNKiFUKtuJqjV = updateLoop;
			}

			public abstract void Reset();
		}

		internal VxUwUEwsHpyhUrKaCKjiygOVwov dataSet;

		public HIDControllerElementWithDataSet(VxUwUEwsHpyhUrKaCKjiygOVwov dataSet, byte reportId, HIDInfo hidInfo)
			: base(reportId, hidInfo)
		{
			this.dataSet = dataSet;
		}

		public virtual void Update(UpdateLoopType updateLoop)
		{
			if (dataSet == null)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -903203551;
			goto IL_000d;
			IL_000d:
			switch (num ^ -903203550)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 2:
				goto IL_0032;
			case 1:
				return;
			}
			goto IL_0008;
			IL_0032:
			dataSet.Update(updateLoop);
			num = -903203549;
			goto IL_000d;
		}
	}
}
