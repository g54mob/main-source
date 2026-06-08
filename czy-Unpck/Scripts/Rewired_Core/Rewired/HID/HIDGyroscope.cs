using System;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDGyroscope : HIDControllerElementWithDataSet
	{
		internal class dEQISYQtzDNRpaWIamMgJTYYBKt : THYotAuJqxRpkaiYpKZdRoaWmOB
		{
			private int gHxZFEugLHnsbWjRnbYHrVTnLhF;

			private int eWEFXkwHrQDCcmGcPfPOHhFROjKS;

			public float[] rawValue => (fSpdVoeWhOYoAilpUehbSxUxANDS as OfxavUsHrxRquIxRBSLbLbQHMGt).exXEGrdtTPMqWAFhcADmmCipVY;

			public ExpandableArray_DataContainer<KBIcthKTrvImOspkbCGHzBZrrOsN> events => (fSpdVoeWhOYoAilpUehbSxUxANDS as OfxavUsHrxRquIxRBSLbLbQHMGt).KHrKGJRhBUAHnZUpGfQtZmbQBgx;

			public dEQISYQtzDNRpaWIamMgJTYYBKt(UpdateLoopSetting updateLoopSetting, int valueLength, int eventCapacity)
			{
				gHxZFEugLHnsbWjRnbYHrVTnLhF = valueLength;
				eWEFXkwHrQDCcmGcPfPOHhFROjKS = eventCapacity;
				QrfyiMPYnSYoyuzKvpeNAZHZaMI(updateLoopSetting, lwdCvYcHUrsRXXdEYdzGLSQPcNz);
			}

			public override void GzCliicOSMFLMvKajLgvnmGSSrh(UpdateLoopType P_0)
			{
				base.GzCliicOSMFLMvKajLgvnmGSSrh(P_0);
				(fSpdVoeWhOYoAilpUehbSxUxANDS as OfxavUsHrxRquIxRBSLbLbQHMGt).GzCliicOSMFLMvKajLgvnmGSSrh();
			}

			public void QlfXhsXpGloHHfChTjhiDSWUATTV(float[] P_0, float P_1)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < ukQXiEKzTMzPimOeOTmWBVpgDWV.Length)
					{
						num2 = 2083252919;
						num3 = num2;
					}
					else
					{
						num2 = 2083252916;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x7C2BEAB6)
						{
						case 0:
							num2 = 2083252919;
							continue;
						default:
							return;
						case 1:
							(ukQXiEKzTMzPimOeOTmWBVpgDWV[num] as OfxavUsHrxRquIxRBSLbLbQHMGt).PMThGwQESqcRqBpwrLuwbkTsJCs(P_0, P_1);
							num++;
							num2 = 2083252917;
							continue;
						case 3:
							break;
						case 2:
							return;
						}
						break;
					}
				}
			}

			private fGUslYDckUuYvbbXSoXhSBIBfBT lwdCvYcHUrsRXXdEYdzGLSQPcNz(UpdateLoopType P_0)
			{
				return new OfxavUsHrxRquIxRBSLbLbQHMGt(P_0, gHxZFEugLHnsbWjRnbYHrVTnLhF, eWEFXkwHrQDCcmGcPfPOHhFROjKS);
			}
		}

		internal class OfxavUsHrxRquIxRBSLbLbQHMGt : fGUslYDckUuYvbbXSoXhSBIBfBT
		{
			private float[] LqBernAxXmdHOHtZSrLOHldBWgwF;

			public float[] exXEGrdtTPMqWAFhcADmmCipVY;

			public ExpandableArray_DataContainer<KBIcthKTrvImOspkbCGHzBZrrOsN> KHrKGJRhBUAHnZUpGfQtZmbQBgx;

			private ExpandableArray_DataContainer<KBIcthKTrvImOspkbCGHzBZrrOsN> aNdOjiFHjFtWOuRCIuPoXudVlNG;

			public OfxavUsHrxRquIxRBSLbLbQHMGt(UpdateLoopType updateLoop, int valueLength, int eventCapacity)
				: base(updateLoop)
			{
				exXEGrdtTPMqWAFhcADmmCipVY = new float[valueLength];
				LqBernAxXmdHOHtZSrLOHldBWgwF = new float[valueLength];
				KHrKGJRhBUAHnZUpGfQtZmbQBgx = new ExpandableArray_DataContainer<KBIcthKTrvImOspkbCGHzBZrrOsN>(eventCapacity, clearData: false, 20);
				aNdOjiFHjFtWOuRCIuPoXudVlNG = new ExpandableArray_DataContainer<KBIcthKTrvImOspkbCGHzBZrrOsN>(eventCapacity, clearData: false, 20);
			}

			public void GzCliicOSMFLMvKajLgvnmGSSrh()
			{
				int num = 0;
				int count = default(int);
				int num3 = default(int);
				while (true)
				{
					int num2;
					if (num >= LqBernAxXmdHOHtZSrLOHldBWgwF.Length)
					{
						KHrKGJRhBUAHnZUpGfQtZmbQBgx.Clear();
						num2 = 564694159;
						goto IL_0009;
					}
					goto IL_00a2;
					IL_0009:
					while (true)
					{
						switch (num2 ^ 0x21A88C8C)
						{
						case 5:
							num2 = 564694157;
							continue;
						case 7:
							num2 = 564694152;
							continue;
						case 2:
							break;
						case 3:
							count = aNdOjiFHjFtWOuRCIuPoXudVlNG.Count;
							num2 = 564694156;
							continue;
						case 6:
							KHrKGJRhBUAHnZUpGfQtZmbQBgx.AddData(aNdOjiFHjFtWOuRCIuPoXudVlNG[num3]);
							num3++;
							num2 = 564694152;
							continue;
						case 0:
							num3 = 0;
							num2 = 564694155;
							continue;
						case 1:
							goto IL_00a2;
						default:
							if (num3 >= count)
							{
								aNdOjiFHjFtWOuRCIuPoXudVlNG.Clear();
								return;
							}
							goto case 6;
						}
						break;
					}
					continue;
					IL_00a2:
					exXEGrdtTPMqWAFhcADmmCipVY[num] = LqBernAxXmdHOHtZSrLOHldBWgwF[num];
					LqBernAxXmdHOHtZSrLOHldBWgwF[num] = 0f;
					num++;
					num2 = 564694158;
					goto IL_0009;
				}
			}

			public void PMThGwQESqcRqBpwrLuwbkTsJCs(float[] P_0, float P_1)
			{
				int num = 0;
				KBIcthKTrvImOspkbCGHzBZrrOsN injector = default(KBIcthKTrvImOspkbCGHzBZrrOsN);
				while (true)
				{
					IL_004c:
					int num2;
					if (num >= LqBernAxXmdHOHtZSrLOHldBWgwF.Length)
					{
						injector = aNdOjiFHjFtWOuRCIuPoXudVlNG.injector;
						num2 = -736247352;
						goto IL_0009;
					}
					goto IL_0026;
					IL_0009:
					while (true)
					{
						switch (num2 ^ -736247352)
						{
						case 3:
							num2 = -736247351;
							continue;
						case 1:
							break;
						case 2:
							goto IL_004c;
						default:
							injector.dhodbseVbYqPVvdUgNSOeWdaMYFi(P_0, P_1);
							aNdOjiFHjFtWOuRCIuPoXudVlNG.Inject();
							return;
						}
						break;
					}
					goto IL_0026;
					IL_0026:
					LqBernAxXmdHOHtZSrLOHldBWgwF[num] += P_0[num];
					num++;
					num2 = -736247350;
					goto IL_0009;
				}
			}

			public override void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
			{
				Array.Clear(exXEGrdtTPMqWAFhcADmmCipVY, 0, exXEGrdtTPMqWAFhcADmmCipVY.Length);
				aNdOjiFHjFtWOuRCIuPoXudVlNG.Clear();
				KHrKGJRhBUAHnZUpGfQtZmbQBgx.Clear();
			}
		}

		public class KBIcthKTrvImOspkbCGHzBZrrOsN : ExpandableArray_DataContainer<KBIcthKTrvImOspkbCGHzBZrrOsN>.ZPnzQWPSCKPnqDDCowtxaBJeUJZ, IComparable<KBIcthKTrvImOspkbCGHzBZrrOsN>
		{
			public Vector3 exXEGrdtTPMqWAFhcADmmCipVY;

			public float VcyElInJLsFJXvLnLYxHhMeWqFl;

			public KBIcthKTrvImOspkbCGHzBZrrOsN()
			{
			}

			public KBIcthKTrvImOspkbCGHzBZrrOsN(float[] rawValues, float deltaTime)
			{
				dhodbseVbYqPVvdUgNSOeWdaMYFi(rawValues, deltaTime);
			}

			public void dhodbseVbYqPVvdUgNSOeWdaMYFi(float[] P_0, float P_1)
			{
				int num = MathTools.Min(P_0.Length, 3);
				int num2 = 0;
				while (true)
				{
					int num3 = -1788825562;
					while (true)
					{
						switch (num3 ^ -1788825563)
						{
						case 2:
							break;
						case 3:
							num3 = -1788825564;
							continue;
						case 0:
							exXEGrdtTPMqWAFhcADmmCipVY[num2] = P_0[num2];
							num2++;
							num3 = -1788825564;
							continue;
						default:
							if (num2 >= num)
							{
								VcyElInJLsFJXvLnLYxHhMeWqFl = P_1;
								return;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			public void dhodbseVbYqPVvdUgNSOeWdaMYFi(KBIcthKTrvImOspkbCGHzBZrrOsN P_0)
			{
				exXEGrdtTPMqWAFhcADmmCipVY = P_0.exXEGrdtTPMqWAFhcADmmCipVY;
				VcyElInJLsFJXvLnLYxHhMeWqFl = P_0.VcyElInJLsFJXvLnLYxHhMeWqFl;
			}

			void ExpandableArray_DataContainer<KBIcthKTrvImOspkbCGHzBZrrOsN>.ZPnzQWPSCKPnqDDCowtxaBJeUJZ.dhodbseVbYqPVvdUgNSOeWdaMYFi(KBIcthKTrvImOspkbCGHzBZrrOsN P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in dhodbseVbYqPVvdUgNSOeWdaMYFi
				this.dhodbseVbYqPVvdUgNSOeWdaMYFi(P_0);
			}

			public bool hSULUfLJyWOzNdtzWOfXzAtyCXP(KBIcthKTrvImOspkbCGHzBZrrOsN P_0)
			{
				if (VcyElInJLsFJXvLnLYxHhMeWqFl == P_0.VcyElInJLsFJXvLnLYxHhMeWqFl)
				{
					return exXEGrdtTPMqWAFhcADmmCipVY == P_0.exXEGrdtTPMqWAFhcADmmCipVY;
				}
				return false;
			}

			bool ExpandableArray_DataContainer<KBIcthKTrvImOspkbCGHzBZrrOsN>.ZPnzQWPSCKPnqDDCowtxaBJeUJZ.hSULUfLJyWOzNdtzWOfXzAtyCXP(KBIcthKTrvImOspkbCGHzBZrrOsN P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in hSULUfLJyWOzNdtzWOfXzAtyCXP
				return this.hSULUfLJyWOzNdtzWOfXzAtyCXP(P_0);
			}

			public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				exXEGrdtTPMqWAFhcADmmCipVY.x = 0f;
				while (true)
				{
					int num = 1781852069;
					while (true)
					{
						switch (num ^ 0x6A34E7A4)
						{
						case 2:
							break;
						case 1:
							goto IL_002e;
						default:
							VcyElInJLsFJXvLnLYxHhMeWqFl = 0f;
							return;
						}
						break;
						IL_002e:
						exXEGrdtTPMqWAFhcADmmCipVY.y = 0f;
						exXEGrdtTPMqWAFhcADmmCipVY.z = 0f;
						num = 1781852068;
					}
				}
			}

			void ExpandableArray_DataContainer<KBIcthKTrvImOspkbCGHzBZrrOsN>.ZPnzQWPSCKPnqDDCowtxaBJeUJZ.tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				//ILSpy generated this explicit interface implementation from .override directive in tAgADqjTsMUxSqYXeDyJIdETYRAp
				this.tAgADqjTsMUxSqYXeDyJIdETYRAp();
			}

			public int CompareTo(KBIcthKTrvImOspkbCGHzBZrrOsN other)
			{
				return 0;
			}
		}

		public double timestamp;

		public readonly float[] lastRawValue;

		public readonly int valueLength;

		private readonly byte[] ybAmuZnIfWhorLsqFnPHtbotknK;

		private readonly float[] SxjMjbSGIueIzaFydYsSjSfQYUym;

		private readonly int noaSAguGveQGKaOFNqtKfOcYBgaj;

		private readonly int xrQLQGuApYmYgXwMFUFFCIVdarb;

		private readonly Action<byte[], float[]> PqMrIShMeNFMoGUmfXsQkHylWpwc;

		private readonly Func<float> GPfoYVUuyoymQlDrXFEmVuHPDeD;

		public float[] rawValue => (dataSet as dEQISYQtzDNRpaWIamMgJTYYBKt).rawValue;

		public ExpandableArray_DataContainer<KBIcthKTrvImOspkbCGHzBZrrOsN> events => (dataSet as dEQISYQtzDNRpaWIamMgJTYYBKt).events;

		public HIDGyroscope(UpdateLoopSetting updateLoopSetting, byte reportId, HIDInfo hidInfo, int valueLength, int startingEventCapacity, Action<byte[], float[]> calcValueDelegate, Func<float> getSensorDeltaTimeDelegate)
			: base(new dEQISYQtzDNRpaWIamMgJTYYBKt(updateLoopSetting, valueLength, startingEventCapacity), reportId, hidInfo)
		{
			while (true)
			{
				int num = 1963931459;
				while (true)
				{
					switch (num ^ 0x750F3742)
					{
					case 3:
						break;
					case 1:
						this.valueLength = valueLength;
						PqMrIShMeNFMoGUmfXsQkHylWpwc = calcValueDelegate;
						GPfoYVUuyoymQlDrXFEmVuHPDeD = getSensorDeltaTimeDelegate;
						noaSAguGveQGKaOFNqtKfOcYBgaj = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
						num = 1963931458;
						continue;
					case 0:
						xrQLQGuApYmYgXwMFUFFCIVdarb = hidInfo.dataIndex;
						ybAmuZnIfWhorLsqFnPHtbotknK = new byte[noaSAguGveQGKaOFNqtKfOcYBgaj];
						SxjMjbSGIueIzaFydYsSjSfQYUym = new float[valueLength];
						num = 1963931456;
						continue;
					default:
						lastRawValue = new float[valueLength];
						return;
					}
					break;
				}
			}
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport == null)
			{
				return;
			}
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (inputReport[0] != reportId)
				{
					num = -1344916549;
					num2 = num;
				}
				else
				{
					num = -1344916545;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1344916549)
					{
					case 8:
						num = -1344916550;
						continue;
					case 1:
						break;
					case 4:
						this.timestamp = timestamp;
						num4 = 0;
						num = -1344916558;
						continue;
					case 3:
					{
						float num6 = ((GPfoYVUuyoymQlDrXFEmVuHPDeD != null) ? GPfoYVUuyoymQlDrXFEmVuHPDeD() : 0f);
						(dataSet as dEQISYQtzDNRpaWIamMgJTYYBKt).QlfXhsXpGloHHfChTjhiDSWUATTV(SxjMjbSGIueIzaFydYsSjSfQYUym, num6);
						num3 = 0;
						num = -1344916551;
						continue;
					}
					case 5:
						ybAmuZnIfWhorLsqFnPHtbotknK[num4] = inputReport[xrQLQGuApYmYgXwMFUFFCIVdarb + num4];
						num4++;
						num = -1344916558;
						continue;
					case 6:
						if (PqMrIShMeNFMoGUmfXsQkHylWpwc != null)
						{
							PqMrIShMeNFMoGUmfXsQkHylWpwc(ybAmuZnIfWhorLsqFnPHtbotknK, SxjMjbSGIueIzaFydYsSjSfQYUym);
							num = -1344916552;
							continue;
						}
						goto case 3;
					case 0:
						return;
					case 7:
						lastRawValue[num3] = SxjMjbSGIueIzaFydYsSjSfQYUym[num3];
						num3++;
						num = -1344916551;
						continue;
					case 9:
					{
						int num5;
						if (num4 >= noaSAguGveQGKaOFNqtKfOcYBgaj)
						{
							num = -1344916547;
							num5 = num;
						}
						else
						{
							num = -1344916546;
							num5 = num;
						}
						continue;
					}
					default:
						if (num3 >= valueLength)
						{
							return;
						}
						goto case 7;
					}
					break;
				}
			}
		}

		public void UpdateValueManual(float[] value, double timestamp)
		{
			this.timestamp = timestamp;
			int num2 = default(int);
			float num4 = default(float);
			int num3 = default(int);
			while (true)
			{
				int num = 1952980971;
				while (true)
				{
					switch (num ^ 0x74681FEF)
					{
					case 5:
						break;
					case 1:
						lastRawValue[num2] = SxjMjbSGIueIzaFydYsSjSfQYUym[num2];
						num = 1952980972;
						continue;
					case 3:
						num2++;
						num = 1952980969;
						continue;
					case 4:
						num4 = ((GPfoYVUuyoymQlDrXFEmVuHPDeD != null) ? GPfoYVUuyoymQlDrXFEmVuHPDeD() : 0f);
						num3 = 0;
						num = 1952980973;
						continue;
					case 2:
						if (num3 >= valueLength)
						{
							(dataSet as dEQISYQtzDNRpaWIamMgJTYYBKt).QlfXhsXpGloHHfChTjhiDSWUATTV(SxjMjbSGIueIzaFydYsSjSfQYUym, num4);
							num2 = 0;
							num = 1952980969;
							continue;
						}
						goto case 0;
					case 0:
						SxjMjbSGIueIzaFydYsSjSfQYUym[num3] = value[num3];
						num3++;
						num = 1952980973;
						continue;
					default:
						if (num2 >= valueLength)
						{
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}
	}
}
