using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	public sealed class UserData
	{
		private static class EMRkhjTgXoZTiafHYaTvUkzwjfk
		{
			private class MhuNWsSNdeFIOPrqUpcotrinQGK
			{
				public enum xcbwZwGvfnVcagdGpAqUoxbbmBe
				{
					PcvdaPGLraDcVpVTDFerAnafHgWK = 0,
					XfMFYPNbBYWiYxGxDZakDleTnIg = 1,
					ehNPUFIecmjcFTrEUzbaEBmcMGD = 2
				}

				public int PcvdaPGLraDcVpVTDFerAnafHgWK;

				public int XfMFYPNbBYWiYxGxDZakDleTnIg;

				public int ehNPUFIecmjcFTrEUzbaEBmcMGD;

				public int this[xcbwZwGvfnVcagdGpAqUoxbbmBe type]
				{
					get
					{
						switch (type)
						{
						case xcbwZwGvfnVcagdGpAqUoxbbmBe.PcvdaPGLraDcVpVTDFerAnafHgWK:
							return PcvdaPGLraDcVpVTDFerAnafHgWK;
						case xcbwZwGvfnVcagdGpAqUoxbbmBe.XfMFYPNbBYWiYxGxDZakDleTnIg:
							return XfMFYPNbBYWiYxGxDZakDleTnIg;
						case xcbwZwGvfnVcagdGpAqUoxbbmBe.ehNPUFIecmjcFTrEUzbaEBmcMGD:
							return ehNPUFIecmjcFTrEUzbaEBmcMGD;
						default:
							throw new NotImplementedException();
						}
					}
					set
					{
						int num;
						switch (type)
						{
						case xcbwZwGvfnVcagdGpAqUoxbbmBe.PcvdaPGLraDcVpVTDFerAnafHgWK:
							PcvdaPGLraDcVpVTDFerAnafHgWK = value;
							num = 447181326;
							goto IL_001b;
						case xcbwZwGvfnVcagdGpAqUoxbbmBe.ehNPUFIecmjcFTrEUzbaEBmcMGD:
							goto IL_0052;
						case xcbwZwGvfnVcagdGpAqUoxbbmBe.XfMFYPNbBYWiYxGxDZakDleTnIg:
							goto IL_0068;
							IL_001b:
							while (true)
							{
								switch (num ^ 0x1AA7720F)
								{
								case 3:
									num = 447181321;
									continue;
								case 6:
									break;
								case 4:
									goto IL_0052;
								case 2:
									return;
								case 0:
									goto IL_0068;
								case 1:
									return;
								default:
									goto end_IL_0003;
								}
								break;
							}
							goto case xcbwZwGvfnVcagdGpAqUoxbbmBe.PcvdaPGLraDcVpVTDFerAnafHgWK;
							IL_0068:
							XfMFYPNbBYWiYxGxDZakDleTnIg = value;
							return;
							IL_0052:
							ehNPUFIecmjcFTrEUzbaEBmcMGD = value;
							num = 447181325;
							goto IL_001b;
							end_IL_0003:
							break;
						}
						throw new NotImplementedException();
					}
				}

				public MhuNWsSNdeFIOPrqUpcotrinQGK(int origId, int otherId, int finalId)
				{
					PcvdaPGLraDcVpVTDFerAnafHgWK = origId;
					XfMFYPNbBYWiYxGxDZakDleTnIg = otherId;
					ehNPUFIecmjcFTrEUzbaEBmcMGD = finalId;
				}

				public override string ToString()
				{
					string text = "";
					while (true)
					{
						int num = -1482054170;
						while (true)
						{
							switch (num ^ -1482054169)
							{
							case 2:
								break;
							case 1:
								goto IL_0024;
							default:
								return text;
							}
							break;
							IL_0024:
							text += StringTools.WriteVar("origId", PcvdaPGLraDcVpVTDFerAnafHgWK);
							text += StringTools.WriteVar("otherId", XfMFYPNbBYWiYxGxDZakDleTnIg);
							text += StringTools.WriteVar("finalId", ehNPUFIecmjcFTrEUzbaEBmcMGD);
							num = -1482054169;
						}
					}
				}
			}

			private class WWUpfvqQFZlIEoRQvLsKEixNqFE<T>
			{
				public T zHDcwEEQEfTshItMCxoVVMcCGJuQ;

				public T sxChUSdSSHzfOGjISaivOHFKIkAN;

				public MhuNWsSNdeFIOPrqUpcotrinQGK.xcbwZwGvfnVcagdGpAqUoxbbmBe bBIOjiIAZNexadkAtlPGjDbqhHH;

				public IList<T> YGHUMpjyJDPJsOTlymzEWtSFFGh;

				public bool NpsWIyadXdsVqgWIvBUhGOVedbc;

				public WWUpfvqQFZlIEoRQvLsKEixNqFE(T otherItem, T finalItem, MhuNWsSNdeFIOPrqUpcotrinQGK.xcbwZwGvfnVcagdGpAqUoxbbmBe idType, IList<T> finalItems, bool isCollision)
				{
					zHDcwEEQEfTshItMCxoVVMcCGJuQ = otherItem;
					sxChUSdSSHzfOGjISaivOHFKIkAN = finalItem;
					bBIOjiIAZNexadkAtlPGjDbqhHH = idType;
					YGHUMpjyJDPJsOTlymzEWtSFFGh = finalItems;
					NpsWIyadXdsVqgWIvBUhGOVedbc = isCollision;
				}
			}

			private sealed class vDgszJYctlYeDelkuaNEKylbVSB
			{
				private sealed class owVepODpuhkrnrrABozNavQjYHKb
				{
					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public WWUpfvqQFZlIEoRQvLsKEixNqFE<InputAction> iColUqUtJXiUJwiPnwRpPAsIDOd;

					public bool XsxfGAFfomoFUXGbUyfsVTZsPjiL(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == iColUqUtJXiUJwiPnwRpPAsIDOd.zHDcwEEQEfTshItMCxoVVMcCGJuQ.categoryId;
					}

					public bool gAzJqMVsTTbzqrvoBZSDQvlEEfj(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == iColUqUtJXiUJwiPnwRpPAsIDOd.zHDcwEEQEfTshItMCxoVVMcCGJuQ.behaviorId;
					}
				}

				private sealed class ghdaNrhNDNvOuyiupnLMBzxCiyh
				{
					public WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMapLayoutManager_RuleSet_Editor> iColUqUtJXiUJwiPnwRpPAsIDOd;
				}

				private sealed class FPSyHKdMtcdKACBSGbkuVTfIZejj
				{
					public ghdaNrhNDNvOuyiupnLMBzxCiyh VhhCppCdHdAiTasrHVMGHbAAcwgw;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public int CCVcRZhkPgquWMeKtCUSDZsKSzFh;

					public bool MpijBPPsaakvzvotsZJQLhUoimf(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[VhhCppCdHdAiTasrHVMGHbAAcwgw.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == CCVcRZhkPgquWMeKtCUSDZsKSzFh;
					}
				}

				private sealed class bnVJEgprkqNFLCzoNgkqIusMFny
				{
					public ghdaNrhNDNvOuyiupnLMBzxCiyh VhhCppCdHdAiTasrHVMGHbAAcwgw;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public int CCVcRZhkPgquWMeKtCUSDZsKSzFh;

					public bool uZbWCyiJzJznpIRpTdmTvZdKmAd(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[VhhCppCdHdAiTasrHVMGHbAAcwgw.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == CCVcRZhkPgquWMeKtCUSDZsKSzFh;
					}
				}

				private sealed class aPMqImdBtqqZXiivXSCeGLDUhPb
				{
					public ghdaNrhNDNvOuyiupnLMBzxCiyh VhhCppCdHdAiTasrHVMGHbAAcwgw;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public int CCVcRZhkPgquWMeKtCUSDZsKSzFh;

					public bool VmJCdmKaksbkcTRzHqpJwsbiIjpG(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[VhhCppCdHdAiTasrHVMGHbAAcwgw.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == CCVcRZhkPgquWMeKtCUSDZsKSzFh;
					}
				}

				private sealed class XaXFRkWSCaRSqvDrLEglWrJBWiz
				{
					public WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMapEnabler_RuleSet_Editor> iColUqUtJXiUJwiPnwRpPAsIDOd;
				}

				private sealed class itHWlBnDWaEJGblxcbkyFXzgBQv
				{
					public XaXFRkWSCaRSqvDrLEglWrJBWiz ltazmzZmESYHWDrqvrzRoaSracXD;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public int CCVcRZhkPgquWMeKtCUSDZsKSzFh;

					public bool IrPoXRiWnFXJPmToddJKlEOFGhI(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[ltazmzZmESYHWDrqvrzRoaSracXD.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == CCVcRZhkPgquWMeKtCUSDZsKSzFh;
					}
				}

				private sealed class TSYqdvlnClZLZUFtNVkJCTgKJlb
				{
					public XaXFRkWSCaRSqvDrLEglWrJBWiz ltazmzZmESYHWDrqvrzRoaSracXD;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public int CCVcRZhkPgquWMeKtCUSDZsKSzFh;

					public bool ntVWnMItyTugrmrOOohkWUvZOPf(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[ltazmzZmESYHWDrqvrzRoaSracXD.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == CCVcRZhkPgquWMeKtCUSDZsKSzFh;
					}
				}

				private sealed class BgVlcXOoGthiBTxbTuPScJuWiKp
				{
					public XaXFRkWSCaRSqvDrLEglWrJBWiz ltazmzZmESYHWDrqvrzRoaSracXD;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public int CCVcRZhkPgquWMeKtCUSDZsKSzFh;

					public bool UZfJUdFIVojfbTwsYkLizNCXiBoE(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[ltazmzZmESYHWDrqvrzRoaSracXD.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == CCVcRZhkPgquWMeKtCUSDZsKSzFh;
					}
				}

				private sealed class isLHQVfjyeSUQhWuulhpotAispr
				{
					private sealed class wlpNsUDCeazWDmbwJoGSPVCClPi
					{
						public isLHQVfjyeSUQhWuulhpotAispr dKEtIwGNeRIwMxuwyYhYZYJXzXW;

						public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

						public Player_Editor.Mapping amYJzCKmWOsOgUiomdbNfsuODACj;

						public bool mySQBIGNNberJVOCWmWnKyVJCNj(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
						{
							return P_0[dKEtIwGNeRIwMxuwyYhYZYJXzXW.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == amYJzCKmWOsOgUiomdbNfsuODACj.categoryId;
						}

						public bool YlYPqHgDnxHuOfvNjwOrOUCAGick(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
						{
							return P_0[dKEtIwGNeRIwMxuwyYhYZYJXzXW.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == amYJzCKmWOsOgUiomdbNfsuODACj.layoutId;
						}
					}

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public WWUpfvqQFZlIEoRQvLsKEixNqFE<Player_Editor> iColUqUtJXiUJwiPnwRpPAsIDOd;

					public void FSQDpbkSSvGxsXxkNqnROLbuOQxB(List<Player_Editor.Mapping> P_0, List<MhuNWsSNdeFIOPrqUpcotrinQGK> P_1)
					{
						int num = 0;
						while (num < P_0.Count)
						{
							while (true)
							{
								wlpNsUDCeazWDmbwJoGSPVCClPi wlpNsUDCeazWDmbwJoGSPVCClPi2 = new wlpNsUDCeazWDmbwJoGSPVCClPi();
								wlpNsUDCeazWDmbwJoGSPVCClPi2.dKEtIwGNeRIwMxuwyYhYZYJXzXW = this;
								wlpNsUDCeazWDmbwJoGSPVCClPi2.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
								wlpNsUDCeazWDmbwJoGSPVCClPi2.amYJzCKmWOsOgUiomdbNfsuODACj = P_0[num];
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = qFUiIUBmnPANbAilZAhlbWWAmVb.UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(wlpNsUDCeazWDmbwJoGSPVCClPi2.mySQBIGNNberJVOCWmWnKyVJCNj);
								wlpNsUDCeazWDmbwJoGSPVCClPi2.amYJzCKmWOsOgUiomdbNfsuODACj.categoryId = mhuNWsSNdeFIOPrqUpcotrinQGK?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								mhuNWsSNdeFIOPrqUpcotrinQGK = P_1.Find(wlpNsUDCeazWDmbwJoGSPVCClPi2.YlYPqHgDnxHuOfvNjwOrOUCAGick);
								wlpNsUDCeazWDmbwJoGSPVCClPi2.amYJzCKmWOsOgUiomdbNfsuODACj.layoutId = mhuNWsSNdeFIOPrqUpcotrinQGK?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								num++;
								int num2 = 948529365;
								while (true)
								{
									switch (num2 ^ 0x388968D7)
									{
									case 0:
										num2 = 948529366;
										continue;
									case 1:
										break;
									default:
										goto end_IL_0028;
									}
									break;
								}
								continue;
								end_IL_0028:
								break;
							}
						}
					}
				}

				private sealed class oIBrXREZcmixfKvyFZSmrBUAFcE
				{
					public isLHQVfjyeSUQhWuulhpotAispr dKEtIwGNeRIwMxuwyYhYZYJXzXW;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public Player_Editor.CreateControllerInfo KEojvyjKrFDfpXOmrgEOERpcrbV;

					public bool QqsGqvOYKpdvRLrSEDKabJClhpTK(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[dKEtIwGNeRIwMxuwyYhYZYJXzXW.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == KEojvyjKrFDfpXOmrgEOERpcrbV.sourceId;
					}
				}

				private sealed class ufdqqNaNqewnCXhTUrYdqJGKrnc
				{
					public isLHQVfjyeSUQhWuulhpotAispr dKEtIwGNeRIwMxuwyYhYZYJXzXW;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public int tvvERjRcrFQoLeSRWZgxEcxZOWL;

					public bool BEUzdtVZhiIoNOWwKsiQbNXJROo(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[dKEtIwGNeRIwMxuwyYhYZYJXzXW.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == tvvERjRcrFQoLeSRWZgxEcxZOWL;
					}
				}

				private sealed class DcBumdWUwmPgQBQYpwNojRronAK
				{
					public isLHQVfjyeSUQhWuulhpotAispr dKEtIwGNeRIwMxuwyYhYZYJXzXW;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public int tvvERjRcrFQoLeSRWZgxEcxZOWL;

					public bool iaoIjOjAKtNGriKqlHSzPAktqycC(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[dKEtIwGNeRIwMxuwyYhYZYJXzXW.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == tvvERjRcrFQoLeSRWZgxEcxZOWL;
					}
				}

				public UserData gOEbMJdszjQGVnFGNAMUgiaelAsv;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> jtnmxUxCMIfWJeMXmRMSWrEsqNY;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> rCOYYDgHHhHHvtMfjCenDdQZwcu;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> zAvCIOcMYPmqcDAQowOVcRKFVmm;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> UFfmmpelsjFbWJmEpVbdlOaFeAZD;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> otLFyvvJVKrPTTjQSHggHDCzBjF;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> eMyHeZSgMURXJfjEoHWIfEghfUj;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> UPBebojQrOaNPTXQPHBdiDtQiFX;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> ZWOUkpipqSdNFYkZFNgpgNzVKyZ;

				public Func<ControllerType, List<MhuNWsSNdeFIOPrqUpcotrinQGK>> DPeHHHfCnMxihHMRpvTcTtofHYJ;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> bxXBAIjNrNDiLSvcpobwxkuZNvXl;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> aNnUDGfUfBQaghNCEYarVdhqplX;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> hwHTDZrBttNPFbEjKCrmcOBmynN;

				private static Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> UvGVwfVsEpnvjaNrNDZOmbjEnoJ;

				private static Func<Player_Editor.CreateControllerInfo, IList<Player_Editor.CreateControllerInfo>, int> LUfPCzfLGOcsoLlPvBUlAcMcBsAf;

				public InputCategory TrucqCVfyuQdUxhxUrlYyzGaali(WWUpfvqQFZlIEoRQvLsKEixNqFE<InputCategory> P_0)
				{
					InputCategory inputCategory = JsonTools.Clone(P_0.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
					if (P_0.NpsWIyadXdsVqgWIvBUhGOVedbc)
					{
						goto IL_0014;
					}
					goto IL_0044;
					IL_0014:
					int num = -1581013136;
					goto IL_0019;
					IL_0019:
					InputCategory inputCategory2 = default(InputCategory);
					while (true)
					{
						switch (num ^ -1581013135)
						{
						case 3:
							break;
						case 1:
							inputCategory2 = P_0.sxChUSdSSHzfOGjISaivOHFKIkAN;
							num = -1581013135;
							continue;
						case 2:
							goto IL_0044;
						default:
						{
							inputCategory.id = inputCategory2.id;
							int index = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(inputCategory2);
							P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = inputCategory;
							return inputCategory;
						}
						}
						break;
					}
					goto IL_0014;
					IL_0044:
					gOEbMJdszjQGVnFGNAMUgiaelAsv.AddActionCategory();
					inputCategory2 = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
					num = -1581013135;
					goto IL_0019;
				}

				public InputBehavior VOuXOXDabRlXvTQPJvCCSPUXVxB(WWUpfvqQFZlIEoRQvLsKEixNqFE<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
					InputBehavior inputBehavior2;
					if (P_0.NpsWIyadXdsVqgWIvBUhGOVedbc)
					{
						inputBehavior2 = P_0.sxChUSdSSHzfOGjISaivOHFKIkAN;
					}
					else
					{
						while (true)
						{
							gOEbMJdszjQGVnFGNAMUgiaelAsv.AddInputBehavior();
							inputBehavior2 = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
							int num = 1788544503;
							while (true)
							{
								switch (num ^ 0x6A9B05F5)
								{
								case 0:
									num = 1788544500;
									continue;
								case 1:
									break;
								default:
									goto end_IL_003b;
								}
								break;
							}
							continue;
							end_IL_003b:
							break;
						}
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(inputBehavior2);
					P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = inputBehavior;
					return inputBehavior;
				}

				public InputAction IENiOwbZdMGmYOliwjicfzDIcMp(WWUpfvqQFZlIEoRQvLsKEixNqFE<InputAction> P_0)
				{
					owVepODpuhkrnrrABozNavQjYHKb owVepODpuhkrnrrABozNavQjYHKb2 = new owVepODpuhkrnrrABozNavQjYHKb();
					owVepODpuhkrnrrABozNavQjYHKb2.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
					owVepODpuhkrnrrABozNavQjYHKb2.iColUqUtJXiUJwiPnwRpPAsIDOd = P_0;
					InputAction inputAction2 = default(InputAction);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					int behaviorId = default(int);
					InputAction inputAction = default(InputAction);
					int num2 = default(int);
					while (true)
					{
						int num = 1137723944;
						while (true)
						{
							switch (num ^ 0x43D04A2D)
							{
							case 7:
								break;
							case 5:
								inputAction2 = JsonTools.Clone(owVepODpuhkrnrrABozNavQjYHKb2.iColUqUtJXiUJwiPnwRpPAsIDOd.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
								num = 1137723951;
								continue;
							case 1:
								mhuNWsSNdeFIOPrqUpcotrinQGK = rCOYYDgHHhHHvtMfjCenDdQZwcu.Find(owVepODpuhkrnrrABozNavQjYHKb2.gAzJqMVsTTbzqrvoBZSDQvlEEfj);
								behaviorId = mhuNWsSNdeFIOPrqUpcotrinQGK?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? 0;
								inputAction2.id = inputAction.id;
								if (num2 != inputAction.categoryId)
								{
									gOEbMJdszjQGVnFGNAMUgiaelAsv.ChangeActionCategory(inputAction.id, num2);
									num = 1137723949;
									continue;
								}
								goto default;
							case 3:
								num2 = mhuNWsSNdeFIOPrqUpcotrinQGK?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? 0;
								if (owVepODpuhkrnrrABozNavQjYHKb2.iColUqUtJXiUJwiPnwRpPAsIDOd.NpsWIyadXdsVqgWIvBUhGOVedbc)
								{
									inputAction = owVepODpuhkrnrrABozNavQjYHKb2.iColUqUtJXiUJwiPnwRpPAsIDOd.sxChUSdSSHzfOGjISaivOHFKIkAN;
									num = 1137723948;
									continue;
								}
								goto case 6;
							case 4:
								inputAction = owVepODpuhkrnrrABozNavQjYHKb2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[owVepODpuhkrnrrABozNavQjYHKb2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
								num = 1137723948;
								continue;
							case 2:
								mhuNWsSNdeFIOPrqUpcotrinQGK = jtnmxUxCMIfWJeMXmRMSWrEsqNY.Find(owVepODpuhkrnrrABozNavQjYHKb2.XsxfGAFfomoFUXGbUyfsVTZsPjiL);
								num = 1137723950;
								continue;
							case 6:
								gOEbMJdszjQGVnFGNAMUgiaelAsv.AddAction(num2);
								num = 1137723945;
								continue;
							default:
							{
								inputAction2.categoryId = num2;
								inputAction2.behaviorId = behaviorId;
								int index = owVepODpuhkrnrrABozNavQjYHKb2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(inputAction);
								owVepODpuhkrnrrABozNavQjYHKb2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = inputAction2;
								return inputAction2;
							}
							}
							break;
						}
					}
				}

				public InputLayout CTrnFDXhRWYXeRESnugbEblPuiA(WWUpfvqQFZlIEoRQvLsKEixNqFE<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
					InputLayout inputLayout2 = default(InputLayout);
					int index = default(int);
					while (true)
					{
						int num = 66515726;
						while (true)
						{
							switch (num ^ 0x3F6F30D)
							{
							case 4:
								break;
							case 3:
								if (P_0.NpsWIyadXdsVqgWIvBUhGOVedbc)
								{
									inputLayout2 = P_0.sxChUSdSSHzfOGjISaivOHFKIkAN;
									num = 66515724;
									continue;
								}
								goto case 2;
							case 2:
								gOEbMJdszjQGVnFGNAMUgiaelAsv.AddKeyboardLayout();
								inputLayout2 = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
								num = 66515724;
								continue;
							case 5:
								index = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(inputLayout2);
								num = 66515725;
								continue;
							case 1:
								inputLayout.id = inputLayout2.id;
								num = 66515720;
								continue;
							default:
								P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = inputLayout;
								return inputLayout;
							}
							break;
						}
					}
				}

				public InputLayout gzBUijANCpajSqEqqcQEDOHqHuy(WWUpfvqQFZlIEoRQvLsKEixNqFE<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
					InputLayout inputLayout2;
					if (P_0.NpsWIyadXdsVqgWIvBUhGOVedbc)
					{
						inputLayout2 = P_0.sxChUSdSSHzfOGjISaivOHFKIkAN;
					}
					else
					{
						while (true)
						{
							gOEbMJdszjQGVnFGNAMUgiaelAsv.AddMouseLayout();
							inputLayout2 = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
							int num = -773345160;
							while (true)
							{
								switch (num ^ -773345159)
								{
								case 0:
									num = -773345157;
									continue;
								case 2:
									break;
								default:
									goto end_IL_003b;
								}
								break;
							}
							continue;
							end_IL_003b:
							break;
						}
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(inputLayout2);
					P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = inputLayout;
					return inputLayout;
				}

				public InputLayout WqUAMdZwAmALHDeCeBaHRQWkktk(WWUpfvqQFZlIEoRQvLsKEixNqFE<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
					int index = default(int);
					InputLayout inputLayout2 = default(InputLayout);
					while (true)
					{
						int num = 528693177;
						while (true)
						{
							switch (num ^ 0x1F8337BA)
							{
							case 4:
								break;
							case 6:
								P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = inputLayout;
								num = 528693178;
								continue;
							case 2:
								inputLayout2 = P_0.sxChUSdSSHzfOGjISaivOHFKIkAN;
								num = 528693183;
								continue;
							case 5:
								inputLayout.id = inputLayout2.id;
								index = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(inputLayout2);
								num = 528693180;
								continue;
							case 3:
							{
								int num2;
								if (P_0.NpsWIyadXdsVqgWIvBUhGOVedbc)
								{
									num = 528693176;
									num2 = num;
								}
								else
								{
									num = 528693179;
									num2 = num;
								}
								continue;
							}
							case 1:
								gOEbMJdszjQGVnFGNAMUgiaelAsv.AddJoystickLayout();
								inputLayout2 = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
								num = 528693183;
								continue;
							default:
								return inputLayout;
							}
							break;
						}
					}
				}

				public InputLayout AYdLJRXgDWfxRKtrEHDxQPeuKhZ(WWUpfvqQFZlIEoRQvLsKEixNqFE<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
					if (!P_0.NpsWIyadXdsVqgWIvBUhGOVedbc)
					{
						goto IL_0043;
					}
					InputLayout inputLayout2 = P_0.sxChUSdSSHzfOGjISaivOHFKIkAN;
					goto IL_0055;
					IL_0043:
					gOEbMJdszjQGVnFGNAMUgiaelAsv.AddCustomControllerLayout();
					int num = -784620575;
					goto IL_0022;
					IL_0055:
					inputLayout.id = inputLayout2.id;
					int index = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(inputLayout2);
					P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = inputLayout;
					num = -784620574;
					goto IL_0022;
					IL_0022:
					while (true)
					{
						switch (num ^ -784620576)
						{
						case 0:
							num = -784620573;
							continue;
						case 3:
							break;
						case 4:
							goto IL_0055;
						case 1:
							inputLayout2 = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
							num = -784620572;
							continue;
						default:
							return inputLayout;
						}
						break;
					}
					goto IL_0043;
				}

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> JkxfPlfjRHlKlrznmsLDKZbZePYl(ControllerType P_0)
				{
					while (true)
					{
						switch (-1041805451 ^ -1041805452)
						{
						case 0:
							continue;
						case 1:
							switch (P_0)
							{
							case ControllerType.Keyboard:
								break;
							case ControllerType.Mouse:
								return eMyHeZSgMURXJfjEoHWIfEghfUj;
							case ControllerType.Joystick:
								return UPBebojQrOaNPTXQPHBdiDtQiFX;
							case ControllerType.Custom:
								return ZWOUkpipqSdNFYkZFNgpgNzVKyZ;
							default:
								throw new NotImplementedException();
							}
							break;
						}
						break;
					}
					return otLFyvvJVKrPTTjQSHggHDCzBjF;
				}

				public CustomController_Editor iiyiENhBFfOdDjkQyAljnaJxYnr(WWUpfvqQFZlIEoRQvLsKEixNqFE<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
					CustomController_Editor customController_Editor2 = default(CustomController_Editor);
					if (P_0.NpsWIyadXdsVqgWIvBUhGOVedbc)
					{
						customController_Editor2 = P_0.sxChUSdSSHzfOGjISaivOHFKIkAN;
					}
					else
					{
						while (true)
						{
							gOEbMJdszjQGVnFGNAMUgiaelAsv.AddCustomController();
							int num = 785260056;
							while (true)
							{
								switch (num ^ 0x2ECE1E18)
								{
								case 3:
									num = 785260057;
									continue;
								case 1:
									break;
								case 0:
									customController_Editor2 = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
									num = 785260058;
									continue;
								default:
									goto end_IL_003f;
								}
								break;
							}
							continue;
							end_IL_003f:
							break;
						}
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(customController_Editor2);
					P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = customController_Editor;
					return customController_Editor;
				}

				public ControllerMapLayoutManager_RuleSet_Editor JTPDoNfYtuXEAPILYruKLAVqgBm(WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					ghdaNrhNDNvOuyiupnLMBzxCiyh ghdaNrhNDNvOuyiupnLMBzxCiyh2 = new ghdaNrhNDNvOuyiupnLMBzxCiyh();
					ghdaNrhNDNvOuyiupnLMBzxCiyh2.iColUqUtJXiUJwiPnwRpPAsIDOd = P_0;
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = default(ControllerMapLayoutManager_Rule_Editor);
					List<int> list = default(List<int>);
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor = default(ControllerMapLayoutManager_Rule_Editor);
					aPMqImdBtqqZXiivXSCeGLDUhPb aPMqImdBtqqZXiivXSCeGLDUhPb2 = default(aPMqImdBtqqZXiivXSCeGLDUhPb);
					List<MhuNWsSNdeFIOPrqUpcotrinQGK> list3 = default(List<MhuNWsSNdeFIOPrqUpcotrinQGK>);
					FPSyHKdMtcdKACBSGbkuVTfIZejj fPSyHKdMtcdKACBSGbkuVTfIZejj = default(FPSyHKdMtcdKACBSGbkuVTfIZejj);
					int num8 = default(int);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2 = default(ControllerMapLayoutManager_RuleSet_Editor);
					ControllerType controllerType2 = default(ControllerType);
					bnVJEgprkqNFLCzoNgkqIusMFny bnVJEgprkqNFLCzoNgkqIusMFny2 = default(bnVJEgprkqNFLCzoNgkqIusMFny);
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = default(ControllerMapLayoutManager_RuleSet_Editor);
					int num11 = default(int);
					int num12 = default(int);
					List<MhuNWsSNdeFIOPrqUpcotrinQGK> list2 = default(List<MhuNWsSNdeFIOPrqUpcotrinQGK>);
					int num4 = default(int);
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = default(ControllerMapLayoutManager_Rule_Editor);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK3 = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					int num5 = default(int);
					int num7 = default(int);
					int num9 = default(int);
					int num6 = default(int);
					while (true)
					{
						int num = -794755558;
						while (true)
						{
							int num3;
							switch (num ^ -794755583)
							{
							case 16:
								break;
							case 11:
								if (controllerMapLayoutManager_Rule_Editor3.categoryIds != null)
								{
									list = new List<int>();
									if (controllerMapLayoutManager_Rule_Editor3.categoryIds == null)
									{
										num = -794755570;
										continue;
									}
									num3 = controllerMapLayoutManager_Rule_Editor3.categoryIds.Count;
									goto IL_0141;
								}
								goto case 32;
							case 13:
							{
								ControllerType controllerType = controllerMapLayoutManager_Rule_Editor.controllerSetSelector.controllerType;
								if (controllerType == ControllerType.Custom)
								{
									aPMqImdBtqqZXiivXSCeGLDUhPb2 = new aPMqImdBtqqZXiivXSCeGLDUhPb();
									aPMqImdBtqqZXiivXSCeGLDUhPb2.VhhCppCdHdAiTasrHVMGHbAAcwgw = ghdaNrhNDNvOuyiupnLMBzxCiyh2;
									aPMqImdBtqqZXiivXSCeGLDUhPb2.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
									list3 = bxXBAIjNrNDiLSvcpobwxkuZNvXl;
									aPMqImdBtqqZXiivXSCeGLDUhPb2.CCVcRZhkPgquWMeKtCUSDZsKSzFh = controllerMapLayoutManager_Rule_Editor.controllerSetSelector.customControllerSourceId;
									num = -794755579;
									continue;
								}
								goto case 0;
							}
							case 15:
								num3 = 0;
								goto IL_0141;
							case 31:
								fPSyHKdMtcdKACBSGbkuVTfIZejj.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
								fPSyHKdMtcdKACBSGbkuVTfIZejj.CCVcRZhkPgquWMeKtCUSDZsKSzFh = controllerMapLayoutManager_Rule_Editor3.categoryIds[num8];
								mhuNWsSNdeFIOPrqUpcotrinQGK = UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(fPSyHKdMtcdKACBSGbkuVTfIZejj.MpijBPPsaakvzvotsZJQLhUoimf);
								if (mhuNWsSNdeFIOPrqUpcotrinQGK == null)
								{
									Logger.LogError("No new Map Category Id found for old id: " + fPSyHKdMtcdKACBSGbkuVTfIZejj.CCVcRZhkPgquWMeKtCUSDZsKSzFh);
									num = -794755553;
									continue;
								}
								goto case 14;
							case 27:
								controllerMapLayoutManager_RuleSet_Editor2 = JsonTools.Clone(ghdaNrhNDNvOuyiupnLMBzxCiyh2.iColUqUtJXiUJwiPnwRpPAsIDOd.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
								num = -794755552;
								continue;
							case 35:
								Logger.LogError(string.Concat("No new ", controllerType2, " Layout Id found for old id: ", bnVJEgprkqNFLCzoNgkqIusMFny2.CCVcRZhkPgquWMeKtCUSDZsKSzFh));
								num = -794755561;
								continue;
							case 19:
								controllerMapLayoutManager_RuleSet_Editor = ghdaNrhNDNvOuyiupnLMBzxCiyh2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[ghdaNrhNDNvOuyiupnLMBzxCiyh2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
								num = -794755559;
								continue;
							case 21:
								if (num11 >= num12)
								{
									if (ghdaNrhNDNvOuyiupnLMBzxCiyh2.iColUqUtJXiUJwiPnwRpPAsIDOd.NpsWIyadXdsVqgWIvBUhGOVedbc)
									{
										controllerMapLayoutManager_RuleSet_Editor = ghdaNrhNDNvOuyiupnLMBzxCiyh2.iColUqUtJXiUJwiPnwRpPAsIDOd.sxChUSdSSHzfOGjISaivOHFKIkAN;
										num = -794755559;
										continue;
									}
									goto case 12;
								}
								goto case 17;
							case 5:
								list2 = DPeHHHfCnMxihHMRpvTcTtofHYJ(controllerType2);
								num = -794755557;
								continue;
							case 1:
							{
								controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor2.rules[num4];
								int num10;
								if (controllerMapLayoutManager_Rule_Editor3 != null)
								{
									num = -794755574;
									num10 = num;
								}
								else
								{
									num = -794755551;
									num10 = num;
								}
								continue;
							}
							case 30:
								num8++;
								num = -794755582;
								continue;
							case 26:
								bnVJEgprkqNFLCzoNgkqIusMFny2.CCVcRZhkPgquWMeKtCUSDZsKSzFh = controllerMapLayoutManager_Rule_Editor2.layoutId;
								mhuNWsSNdeFIOPrqUpcotrinQGK2 = list2.Find(bnVJEgprkqNFLCzoNgkqIusMFny2.uZbWCyiJzJznpIRpTdmTvZdKmAd);
								num = -794755560;
								continue;
							case 32:
								num4++;
								num = -794755581;
								continue;
							case 4:
							{
								mhuNWsSNdeFIOPrqUpcotrinQGK3 = list3.Find(aPMqImdBtqqZXiivXSCeGLDUhPb2.VmJCdmKaksbkcTRzHqpJwsbiIjpG);
								int num13;
								if (mhuNWsSNdeFIOPrqUpcotrinQGK3 != null)
								{
									num = -794755556;
									num13 = num;
								}
								else
								{
									num = -794755555;
									num13 = num;
								}
								continue;
							}
							case 18:
								num = -794755575;
								continue;
							case 33:
								num5 = ((controllerMapLayoutManager_RuleSet_Editor2.rules != null) ? controllerMapLayoutManager_RuleSet_Editor2.rules.Count : 0);
								num4 = 0;
								num = -794755563;
								continue;
							case 25:
								if (mhuNWsSNdeFIOPrqUpcotrinQGK2 == null)
								{
									controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
									num = -794755550;
									continue;
								}
								goto case 10;
							case 22:
								num7++;
								num = -794755575;
								continue;
							case 3:
								if (num8 >= num9)
								{
									controllerMapLayoutManager_Rule_Editor3.categoryIds = list;
									num = -794755551;
									continue;
								}
								goto case 34;
							case 10:
								controllerMapLayoutManager_Rule_Editor2.layoutId = mhuNWsSNdeFIOPrqUpcotrinQGK2.ehNPUFIecmjcFTrEUzbaEBmcMGD;
								num = -794755561;
								continue;
							case 24:
								controllerMapLayoutManager_RuleSet_Editor2.id = controllerMapLayoutManager_RuleSet_Editor.id;
								num = -794755578;
								continue;
							case 0:
								num11++;
								num = -794755564;
								continue;
							case 29:
								controllerMapLayoutManager_Rule_Editor.controllerSetSelector.customControllerSourceId = mhuNWsSNdeFIOPrqUpcotrinQGK3.ehNPUFIecmjcFTrEUzbaEBmcMGD;
								num = -794755583;
								continue;
							case 12:
								gOEbMJdszjQGVnFGNAMUgiaelAsv.AddControllerMapLayoutManagerRuleSet();
								num = -794755566;
								continue;
							case 34:
								fPSyHKdMtcdKACBSGbkuVTfIZejj = new FPSyHKdMtcdKACBSGbkuVTfIZejj();
								fPSyHKdMtcdKACBSGbkuVTfIZejj.VhhCppCdHdAiTasrHVMGHbAAcwgw = ghdaNrhNDNvOuyiupnLMBzxCiyh2;
								num = -794755554;
								continue;
							case 8:
								if (num7 >= num6)
								{
									num12 = ((controllerMapLayoutManager_RuleSet_Editor2.rules != null) ? controllerMapLayoutManager_RuleSet_Editor2.rules.Count : 0);
									num11 = 0;
									num = -794755577;
									continue;
								}
								goto case 36;
							case 6:
								num = -794755564;
								continue;
							case 14:
								list.Add(mhuNWsSNdeFIOPrqUpcotrinQGK.ehNPUFIecmjcFTrEUzbaEBmcMGD);
								num = -794755553;
								continue;
							case 20:
								num = -794755581;
								continue;
							case 17:
								controllerMapLayoutManager_Rule_Editor = controllerMapLayoutManager_RuleSet_Editor2.rules[num11];
								num = -794755576;
								continue;
							case 23:
								bnVJEgprkqNFLCzoNgkqIusMFny2.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
								controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor2.rules[num7];
								if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
								{
									controllerType2 = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
									num = -794755580;
									continue;
								}
								goto case 22;
							case 2:
								if (num4 >= num5)
								{
									num6 = ((controllerMapLayoutManager_RuleSet_Editor2.rules != null) ? controllerMapLayoutManager_RuleSet_Editor2.rules.Count : 0);
									num7 = 0;
									num = -794755565;
									continue;
								}
								goto case 1;
							case 28:
								controllerMapLayoutManager_Rule_Editor.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + aPMqImdBtqqZXiivXSCeGLDUhPb2.CCVcRZhkPgquWMeKtCUSDZsKSzFh);
								num = -794755583;
								continue;
							case 9:
								if (controllerMapLayoutManager_Rule_Editor != null)
								{
									int num2;
									if (controllerMapLayoutManager_Rule_Editor.controllerSetSelector == null)
									{
										num = -794755583;
										num2 = num;
									}
									else
									{
										num = -794755572;
										num2 = num;
									}
									continue;
								}
								goto case 0;
							case 36:
								bnVJEgprkqNFLCzoNgkqIusMFny2 = new bnVJEgprkqNFLCzoNgkqIusMFny();
								bnVJEgprkqNFLCzoNgkqIusMFny2.VhhCppCdHdAiTasrHVMGHbAAcwgw = ghdaNrhNDNvOuyiupnLMBzxCiyh2;
								num = -794755562;
								continue;
							default:
								{
									int index = ghdaNrhNDNvOuyiupnLMBzxCiyh2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(controllerMapLayoutManager_RuleSet_Editor);
									ghdaNrhNDNvOuyiupnLMBzxCiyh2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = controllerMapLayoutManager_RuleSet_Editor2;
									return controllerMapLayoutManager_RuleSet_Editor2;
								}
								IL_0141:
								num9 = num3;
								num8 = 0;
								num = -794755582;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMapEnabler_RuleSet_Editor ritObRNBMdQWoxYnKDdJhPJYmPq(WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					XaXFRkWSCaRSqvDrLEglWrJBWiz xaXFRkWSCaRSqvDrLEglWrJBWiz = new XaXFRkWSCaRSqvDrLEglWrJBWiz();
					xaXFRkWSCaRSqvDrLEglWrJBWiz.iColUqUtJXiUJwiPnwRpPAsIDOd = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(xaXFRkWSCaRSqvDrLEglWrJBWiz.iColUqUtJXiUJwiPnwRpPAsIDOd.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
					int num = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
					int num6 = default(int);
					List<int> list2 = default(List<int>);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK3 = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					int num3 = default(int);
					int num7 = default(int);
					int num14 = default(int);
					int num13 = default(int);
					int num12 = default(int);
					int num8 = default(int);
					int num9 = default(int);
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor3 = default(ControllerMapEnabler_Rule_Editor);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					itHWlBnDWaEJGblxcbkyFXzgBQv itHWlBnDWaEJGblxcbkyFXzgBQv2 = default(itHWlBnDWaEJGblxcbkyFXzgBQv);
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor2 = default(ControllerMapEnabler_Rule_Editor);
					BgVlcXOoGthiBTxbTuPScJuWiKp bgVlcXOoGthiBTxbTuPScJuWiKp = default(BgVlcXOoGthiBTxbTuPScJuWiKp);
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor = default(ControllerMapEnabler_Rule_Editor);
					List<int> list4 = default(List<int>);
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2 = default(ControllerMapEnabler_RuleSet_Editor);
					object[] array = default(object[]);
					ControllerType controllerType = default(ControllerType);
					TSYqdvlnClZLZUFtNVkJCTgKJlb tSYqdvlnClZLZUFtNVkJCTgKJlb = default(TSYqdvlnClZLZUFtNVkJCTgKJlb);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					int index = default(int);
					List<MhuNWsSNdeFIOPrqUpcotrinQGK> list = default(List<MhuNWsSNdeFIOPrqUpcotrinQGK>);
					while (true)
					{
						int num2 = 1049999880;
						while (true)
						{
							int num4;
							switch (num2 ^ 0x3E95BA0F)
							{
							case 26:
								break;
							case 13:
								num6++;
								num2 = 1049999892;
								continue;
							case 15:
								list2.Add(mhuNWsSNdeFIOPrqUpcotrinQGK3.ehNPUFIecmjcFTrEUzbaEBmcMGD);
								num2 = 1049999874;
								continue;
							case 0:
								if (num3 < num)
								{
									goto case 19;
								}
								if (controllerMapEnabler_RuleSet_Editor.rules == null)
								{
									num2 = 1049999894;
									continue;
								}
								num4 = controllerMapEnabler_RuleSet_Editor.rules.Count;
								goto IL_058a;
							case 3:
								if (num7 >= num14)
								{
									num13 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
									num12 = 0;
									num2 = 1049999881;
									continue;
								}
								goto case 4;
							case 9:
							{
								int num11;
								if (num8 < num9)
								{
									num2 = 1049999885;
									num11 = num2;
								}
								else
								{
									num2 = 1049999891;
									num11 = num2;
								}
								continue;
							}
							case 29:
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = mhuNWsSNdeFIOPrqUpcotrinQGK2.ehNPUFIecmjcFTrEUzbaEBmcMGD;
								num2 = 1049999873;
								continue;
							case 12:
								itHWlBnDWaEJGblxcbkyFXzgBQv2.ltazmzZmESYHWDrqvrzRoaSracXD = xaXFRkWSCaRSqvDrLEglWrJBWiz;
								itHWlBnDWaEJGblxcbkyFXzgBQv2.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
								itHWlBnDWaEJGblxcbkyFXzgBQv2.CCVcRZhkPgquWMeKtCUSDZsKSzFh = controllerMapEnabler_Rule_Editor2.categoryIds[num6];
								mhuNWsSNdeFIOPrqUpcotrinQGK3 = UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(itHWlBnDWaEJGblxcbkyFXzgBQv2.IrPoXRiWnFXJPmToddJKlEOFGhI);
								if (mhuNWsSNdeFIOPrqUpcotrinQGK3 == null)
								{
									Logger.LogError("No new Map Category Id found for old id: " + itHWlBnDWaEJGblxcbkyFXzgBQv2.CCVcRZhkPgquWMeKtCUSDZsKSzFh);
									num2 = 1049999874;
									continue;
								}
								goto case 15;
							case 30:
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + bgVlcXOoGthiBTxbTuPScJuWiKp.CCVcRZhkPgquWMeKtCUSDZsKSzFh);
								num2 = 1049999873;
								continue;
							case 20:
							{
								int num5;
								if (mhuNWsSNdeFIOPrqUpcotrinQGK2 != null)
								{
									num2 = 1049999890;
									num5 = num2;
								}
								else
								{
									num2 = 1049999889;
									num5 = num2;
								}
								continue;
							}
							case 28:
								controllerMapEnabler_Rule_Editor.layoutIds = list4;
								num2 = 1049999877;
								continue;
							case 35:
								num3++;
								num2 = 1049999887;
								continue;
							case 19:
								controllerMapEnabler_Rule_Editor2 = controllerMapEnabler_RuleSet_Editor.rules[num3];
								if (controllerMapEnabler_Rule_Editor2 != null && controllerMapEnabler_Rule_Editor2.categoryIds != null)
								{
									list2 = new List<int>();
									num6 = 0;
									num2 = 1049999892;
									continue;
								}
								goto case 35;
							case 33:
								num8++;
								num2 = 1049999878;
								continue;
							case 6:
								num2 = 1049999896;
								continue;
							case 23:
								if (num12 < num13)
								{
									goto case 21;
								}
								if (xaXFRkWSCaRSqvDrLEglWrJBWiz.iColUqUtJXiUJwiPnwRpPAsIDOd.NpsWIyadXdsVqgWIvBUhGOVedbc)
								{
									controllerMapEnabler_RuleSet_Editor2 = xaXFRkWSCaRSqvDrLEglWrJBWiz.iColUqUtJXiUJwiPnwRpPAsIDOd.sxChUSdSSHzfOGjISaivOHFKIkAN;
									num2 = 1049999876;
									continue;
								}
								goto case 31;
							case 34:
								array[1] = controllerType;
								array[2] = " Layout Id found for old id: ";
								array[3] = tSYqdvlnClZLZUFtNVkJCTgKJlb.CCVcRZhkPgquWMeKtCUSDZsKSzFh;
								Logger.LogError(string.Concat(array));
								num2 = 1049999918;
								continue;
							case 21:
								controllerMapEnabler_Rule_Editor3 = controllerMapEnabler_RuleSet_Editor.rules[num12];
								if (controllerMapEnabler_Rule_Editor3 != null && controllerMapEnabler_Rule_Editor3.controllerSetSelector != null)
								{
									ControllerType controllerType2 = controllerMapEnabler_Rule_Editor3.controllerSetSelector.controllerType;
									if (controllerType2 == ControllerType.Custom)
									{
										bgVlcXOoGthiBTxbTuPScJuWiKp = new BgVlcXOoGthiBTxbTuPScJuWiKp();
										num2 = 1049999879;
										continue;
									}
								}
								goto case 14;
							case 17:
								itHWlBnDWaEJGblxcbkyFXzgBQv2 = new itHWlBnDWaEJGblxcbkyFXzgBQv();
								num2 = 1049999875;
								continue;
							case 27:
							{
								int num10;
								if (num6 < controllerMapEnabler_Rule_Editor2.categoryIds.Count)
								{
									num2 = 1049999902;
									num10 = num2;
								}
								else
								{
									num2 = 1049999882;
									num10 = num2;
								}
								continue;
							}
							case 4:
								controllerMapEnabler_Rule_Editor = controllerMapEnabler_RuleSet_Editor.rules[num7];
								num2 = 1049999901;
								continue;
							case 31:
								gOEbMJdszjQGVnFGNAMUgiaelAsv.AddControllerMapEnablerRuleSet();
								controllerMapEnabler_RuleSet_Editor2 = xaXFRkWSCaRSqvDrLEglWrJBWiz.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[xaXFRkWSCaRSqvDrLEglWrJBWiz.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
								num2 = 1049999876;
								continue;
							case 24:
								list4.Add(mhuNWsSNdeFIOPrqUpcotrinQGK.ehNPUFIecmjcFTrEUzbaEBmcMGD);
								num2 = 1049999918;
								continue;
							case 5:
								controllerMapEnabler_Rule_Editor2.categoryIds = list2;
								num2 = 1049999916;
								continue;
							case 11:
								controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
								index = xaXFRkWSCaRSqvDrLEglWrJBWiz.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(controllerMapEnabler_RuleSet_Editor2);
								num2 = 1049999897;
								continue;
							case 32:
								list4 = new List<int>();
								num9 = ((controllerMapEnabler_Rule_Editor.layoutIds != null) ? controllerMapEnabler_Rule_Editor.layoutIds.Count : 0);
								num8 = 0;
								num2 = 1049999878;
								continue;
							case 16:
							{
								List<MhuNWsSNdeFIOPrqUpcotrinQGK> list3 = bxXBAIjNrNDiLSvcpobwxkuZNvXl;
								bgVlcXOoGthiBTxbTuPScJuWiKp.CCVcRZhkPgquWMeKtCUSDZsKSzFh = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
								mhuNWsSNdeFIOPrqUpcotrinQGK2 = list3.Find(bgVlcXOoGthiBTxbTuPScJuWiKp.UZfJUdFIVojfbTwsYkLizNCXiBoE);
								num2 = 1049999899;
								continue;
							}
							case 2:
								tSYqdvlnClZLZUFtNVkJCTgKJlb = new TSYqdvlnClZLZUFtNVkJCTgKJlb();
								tSYqdvlnClZLZUFtNVkJCTgKJlb.ltazmzZmESYHWDrqvrzRoaSracXD = xaXFRkWSCaRSqvDrLEglWrJBWiz;
								tSYqdvlnClZLZUFtNVkJCTgKJlb.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
								tSYqdvlnClZLZUFtNVkJCTgKJlb.CCVcRZhkPgquWMeKtCUSDZsKSzFh = controllerMapEnabler_Rule_Editor.layoutIds[num8];
								num2 = 1049999886;
								continue;
							case 18:
								if (controllerMapEnabler_Rule_Editor != null && controllerMapEnabler_Rule_Editor.layoutIds != null)
								{
									controllerType = controllerMapEnabler_Rule_Editor.controllerSetSelector.controllerType;
									list = DPeHHHfCnMxihHMRpvTcTtofHYJ(controllerType);
									num2 = 1049999919;
									continue;
								}
								goto case 10;
							case 8:
								bgVlcXOoGthiBTxbTuPScJuWiKp.ltazmzZmESYHWDrqvrzRoaSracXD = xaXFRkWSCaRSqvDrLEglWrJBWiz;
								bgVlcXOoGthiBTxbTuPScJuWiKp.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
								num2 = 1049999903;
								continue;
							case 14:
								num12++;
								num2 = 1049999896;
								continue;
							case 10:
								num7++;
								num2 = 1049999884;
								continue;
							case 1:
								mhuNWsSNdeFIOPrqUpcotrinQGK = list.Find(tSYqdvlnClZLZUFtNVkJCTgKJlb.ntVWnMItyTugrmrOOohkWUvZOPf);
								if (mhuNWsSNdeFIOPrqUpcotrinQGK == null)
								{
									array = new object[4] { "No new ", null, null, null };
									num2 = 1049999917;
									continue;
								}
								goto case 24;
							case 25:
								num4 = 0;
								goto IL_058a;
							case 7:
								num3 = 0;
								num2 = 1049999887;
								continue;
							default:
								{
									xaXFRkWSCaRSqvDrLEglWrJBWiz.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = controllerMapEnabler_RuleSet_Editor;
									return controllerMapEnabler_RuleSet_Editor;
								}
								IL_058a:
								num14 = num4;
								num7 = 0;
								num2 = 1049999884;
								continue;
							}
							break;
						}
					}
				}

				public Player_Editor gUPDpBtsCsUXuvhJtzbBSeJztSP(WWUpfvqQFZlIEoRQvLsKEixNqFE<Player_Editor> P_0)
				{
					isLHQVfjyeSUQhWuulhpotAispr isLHQVfjyeSUQhWuulhpotAispr2 = new isLHQVfjyeSUQhWuulhpotAispr();
					isLHQVfjyeSUQhWuulhpotAispr2.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
					isLHQVfjyeSUQhWuulhpotAispr2.iColUqUtJXiUJwiPnwRpPAsIDOd = P_0;
					int num4 = default(int);
					ufdqqNaNqewnCXhTUrYdqJGKrnc ufdqqNaNqewnCXhTUrYdqJGKrnc2 = default(ufdqqNaNqewnCXhTUrYdqJGKrnc);
					Player_Editor.RuleSetMapping ruleSetMapping2 = default(Player_Editor.RuleSetMapping);
					List<Player_Editor.RuleSetMapping> ruleSets2 = default(List<Player_Editor.RuleSetMapping>);
					int num3 = default(int);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					Player_Editor player_Editor = default(Player_Editor);
					Player_Editor player_Editor3 = default(Player_Editor);
					Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> uvGVwfVsEpnvjaNrNDZOmbjEnoJ = default(Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int>);
					Player_Editor player_Editor2 = default(Player_Editor);
					Action<List<Player_Editor.Mapping>, List<MhuNWsSNdeFIOPrqUpcotrinQGK>> action = default(Action<List<Player_Editor.Mapping>, List<MhuNWsSNdeFIOPrqUpcotrinQGK>>);
					List<Player_Editor.RuleSetMapping> list2 = default(List<Player_Editor.RuleSetMapping>);
					List<Player_Editor.RuleSetMapping> list = default(List<Player_Editor.RuleSetMapping>);
					List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
					DcBumdWUwmPgQBQYpwNojRronAK dcBumdWUwmPgQBQYpwNojRronAK = default(DcBumdWUwmPgQBQYpwNojRronAK);
					Player_Editor.RuleSetMapping ruleSetMapping = default(Player_Editor.RuleSetMapping);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK3 = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					int num2 = default(int);
					oIBrXREZcmixfKvyFZSmrBUAFcE oIBrXREZcmixfKvyFZSmrBUAFcE2 = default(oIBrXREZcmixfKvyFZSmrBUAFcE);
					while (true)
					{
						int num = -1394773525;
						while (true)
						{
							switch (num ^ -1394773509)
							{
							case 29:
								break;
							case 12:
								num4++;
								num = -1394773510;
								continue;
							case 31:
								ufdqqNaNqewnCXhTUrYdqJGKrnc2 = new ufdqqNaNqewnCXhTUrYdqJGKrnc();
								ufdqqNaNqewnCXhTUrYdqJGKrnc2.dKEtIwGNeRIwMxuwyYhYZYJXzXW = isLHQVfjyeSUQhWuulhpotAispr2;
								ufdqqNaNqewnCXhTUrYdqJGKrnc2.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
								ruleSetMapping2 = ruleSets2[num3];
								if (ruleSetMapping2 != null)
								{
									ufdqqNaNqewnCXhTUrYdqJGKrnc2.tvvERjRcrFQoLeSRWZgxEcxZOWL = ruleSetMapping2.id;
									mhuNWsSNdeFIOPrqUpcotrinQGK = aNnUDGfUfBQaghNCEYarVdhqplX.Find(ufdqqNaNqewnCXhTUrYdqJGKrnc2.BEUzdtVZhiIoNOWwKsiQbNXJROo);
									int num6;
									if (mhuNWsSNdeFIOPrqUpcotrinQGK != null)
									{
										num = -1394773529;
										num6 = num;
									}
									else
									{
										num = -1394773520;
										num6 = num;
									}
									continue;
								}
								goto case 25;
							case 17:
								player_Editor = player_Editor3;
								num = -1394773524;
								continue;
							case 6:
								uvGVwfVsEpnvjaNrNDZOmbjEnoJ = UvGVwfVsEpnvjaNrNDZOmbjEnoJ;
								zLsFHNesqsGCpHNZSkhdBdStDvNb(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, uvGVwfVsEpnvjaNrNDZOmbjEnoJ);
								num = -1394773518;
								continue;
							case 13:
								if (UvGVwfVsEpnvjaNrNDZOmbjEnoJ == null)
								{
									UvGVwfVsEpnvjaNrNDZOmbjEnoJ = TKwAHXZNYCcBqawbgeZMAKVhtZLz;
									num = -1394773507;
									continue;
								}
								goto case 6;
							case 16:
								player_Editor = JsonTools.Clone(isLHQVfjyeSUQhWuulhpotAispr2.iColUqUtJXiUJwiPnwRpPAsIDOd.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
								action = isLHQVfjyeSUQhWuulhpotAispr2.FSQDpbkSSvGxsXxkNqnROLbuOQxB;
								num = -1394773542;
								continue;
							case 2:
								if (num3 >= ruleSets2.Count)
								{
									player_Editor.controllerMapLayoutManagerSettings.ruleSets = list2;
									list = new List<Player_Editor.RuleSetMapping>();
									ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
									num = -1394773533;
									continue;
								}
								goto case 31;
							case 10:
								dcBumdWUwmPgQBQYpwNojRronAK.dKEtIwGNeRIwMxuwyYhYZYJXzXW = isLHQVfjyeSUQhWuulhpotAispr2;
								dcBumdWUwmPgQBQYpwNojRronAK.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
								ruleSetMapping = ruleSets[num4];
								num = -1394773516;
								continue;
							case 22:
								dcBumdWUwmPgQBQYpwNojRronAK = new DcBumdWUwmPgQBQYpwNojRronAK();
								num = -1394773519;
								continue;
							case 7:
								ruleSetMapping = ruleSetMapping.Clone();
								ruleSetMapping.id = mhuNWsSNdeFIOPrqUpcotrinQGK3.ehNPUFIecmjcFTrEUzbaEBmcMGD;
								num = -1394773535;
								continue;
							case 18:
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + dcBumdWUwmPgQBQYpwNojRronAK.tvvERjRcrFQoLeSRWZgxEcxZOWL);
								num = -1394773513;
								continue;
							case 14:
							{
								mhuNWsSNdeFIOPrqUpcotrinQGK3 = hwHTDZrBttNPFbEjKCrmcOBmynN.Find(dcBumdWUwmPgQBQYpwNojRronAK.iaoIjOjAKtNGriKqlHSzPAktqycC);
								int num5;
								if (mhuNWsSNdeFIOPrqUpcotrinQGK3 != null)
								{
									num = -1394773508;
									num5 = num;
								}
								else
								{
									num = -1394773527;
									num5 = num;
								}
								continue;
							}
							case 23:
								num = -1394773506;
								continue;
							case 19:
								if (num2 >= player_Editor.startingCustomControllers.Count)
								{
									list2 = new List<Player_Editor.RuleSetMapping>();
									ruleSets2 = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
									num = -1394773522;
									continue;
								}
								goto case 32;
							case 27:
							{
								zLsFHNesqsGCpHNZSkhdBdStDvNb(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, uvGVwfVsEpnvjaNrNDZOmbjEnoJ);
								List<Player_Editor.CreateControllerInfo> startingCustomControllers = player_Editor2.startingCustomControllers;
								List<Player_Editor.CreateControllerInfo> startingCustomControllers2 = player_Editor.startingCustomControllers;
								List<Player_Editor.CreateControllerInfo> startingCustomControllers3 = player_Editor3.startingCustomControllers;
								if (LUfPCzfLGOcsoLlPvBUlAcMcBsAf == null)
								{
									LUfPCzfLGOcsoLlPvBUlAcMcBsAf = yTiZXwcecqNbksfJQFMyDgfWLlg;
								}
								zLsFHNesqsGCpHNZSkhdBdStDvNb(startingCustomControllers, startingCustomControllers2, startingCustomControllers3, LUfPCzfLGOcsoLlPvBUlAcMcBsAf);
								num = -1394773526;
								continue;
							}
							case 15:
								if (ruleSetMapping != null)
								{
									dcBumdWUwmPgQBQYpwNojRronAK.tvvERjRcrFQoLeSRWZgxEcxZOWL = ruleSetMapping.id;
									num = -1394773515;
									continue;
								}
								goto case 12;
							case 25:
								num3++;
								num = -1394773511;
								continue;
							case 0:
								player_Editor3.startingCustomControllers.Clear();
								num = -1394773514;
								continue;
							case 32:
								oIBrXREZcmixfKvyFZSmrBUAFcE2 = new oIBrXREZcmixfKvyFZSmrBUAFcE();
								oIBrXREZcmixfKvyFZSmrBUAFcE2.dKEtIwGNeRIwMxuwyYhYZYJXzXW = isLHQVfjyeSUQhWuulhpotAispr2;
								oIBrXREZcmixfKvyFZSmrBUAFcE2.qFUiIUBmnPANbAilZAhlbWWAmVb = this;
								num = -1394773531;
								continue;
							case 1:
								if (num4 < ruleSets.Count)
								{
									goto case 22;
								}
								player_Editor.controllerMapEnablerSettings.ruleSets = list;
								if (isLHQVfjyeSUQhWuulhpotAispr2.iColUqUtJXiUJwiPnwRpPAsIDOd.NpsWIyadXdsVqgWIvBUhGOVedbc)
								{
									player_Editor2 = isLHQVfjyeSUQhWuulhpotAispr2.iColUqUtJXiUJwiPnwRpPAsIDOd.sxChUSdSSHzfOGjISaivOHFKIkAN;
									player_Editor3 = JsonTools.Clone(player_Editor);
									player_Editor3.defaultKeyboardMaps.Clear();
									player_Editor3.defaultMouseMaps.Clear();
									num = -1394773512;
									continue;
								}
								goto case 8;
							case 20:
								action(player_Editor.defaultMouseMaps, eMyHeZSgMURXJfjEoHWIfEghfUj);
								action(player_Editor.defaultJoystickMaps, UPBebojQrOaNPTXQPHBdiDtQiFX);
								action(player_Editor.defaultCustomControllerMaps, ZWOUkpipqSdNFYkZFNgpgNzVKyZ);
								num2 = 0;
								num = -1394773528;
								continue;
							case 30:
							{
								oIBrXREZcmixfKvyFZSmrBUAFcE2.KEojvyjKrFDfpXOmrgEOERpcrbV = player_Editor.startingCustomControllers[num2];
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = bxXBAIjNrNDiLSvcpobwxkuZNvXl.Find(oIBrXREZcmixfKvyFZSmrBUAFcE2.QqsGqvOYKpdvRLrSEDKabJClhpTK);
								oIBrXREZcmixfKvyFZSmrBUAFcE2.KEojvyjKrFDfpXOmrgEOERpcrbV.sourceId = mhuNWsSNdeFIOPrqUpcotrinQGK2?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								num = -1394773505;
								continue;
							}
							case 11:
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + ufdqqNaNqewnCXhTUrYdqJGKrnc2.tvvERjRcrFQoLeSRWZgxEcxZOWL);
								num = -1394773534;
								continue;
							case 28:
								ruleSetMapping2 = ruleSetMapping2.Clone();
								ruleSetMapping2.id = mhuNWsSNdeFIOPrqUpcotrinQGK.ehNPUFIecmjcFTrEUzbaEBmcMGD;
								list2.Add(ruleSetMapping2);
								num = -1394773534;
								continue;
							case 3:
								player_Editor3.defaultJoystickMaps.Clear();
								player_Editor3.defaultCustomControllerMaps.Clear();
								num = -1394773509;
								continue;
							case 9:
								zLsFHNesqsGCpHNZSkhdBdStDvNb(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, uvGVwfVsEpnvjaNrNDZOmbjEnoJ);
								zLsFHNesqsGCpHNZSkhdBdStDvNb(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, uvGVwfVsEpnvjaNrNDZOmbjEnoJ);
								num = -1394773536;
								continue;
							case 26:
								list.Add(ruleSetMapping);
								num = -1394773513;
								continue;
							case 24:
								num4 = 0;
								num = -1394773510;
								continue;
							case 8:
								gOEbMJdszjQGVnFGNAMUgiaelAsv.AddPlayer();
								player_Editor2 = isLHQVfjyeSUQhWuulhpotAispr2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[isLHQVfjyeSUQhWuulhpotAispr2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
								num = -1394773506;
								continue;
							case 21:
								num3 = 0;
								num = -1394773511;
								continue;
							case 4:
								num2++;
								num = -1394773528;
								continue;
							case 33:
								action(player_Editor.defaultKeyboardMaps, otLFyvvJVKrPTTjQSHggHDCzBjF);
								num = -1394773521;
								continue;
							default:
							{
								player_Editor.id = player_Editor2.id;
								int index = isLHQVfjyeSUQhWuulhpotAispr2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(player_Editor2);
								isLHQVfjyeSUQhWuulhpotAispr2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = player_Editor;
								return player_Editor;
							}
							}
							break;
						}
					}
				}

				private static int TKwAHXZNYCcBqawbgeZMAKVhtZLz(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							int num2;
							if (P_1[num].categoryId == P_0.categoryId && P_1[num].layoutId == P_0.layoutId)
							{
								num2 = -2995073;
							}
							else
							{
								num++;
								num2 = -2995076;
							}
							while (true)
							{
								switch (num2 ^ -2995075)
								{
								case 0:
									num2 = -2995074;
									continue;
								case 3:
									break;
								case 2:
									return num;
								default:
									goto end_IL_0026;
								}
								break;
							}
							continue;
							end_IL_0026:
							break;
						}
					}
					return -1;
				}

				private static int yTiZXwcecqNbksfJQFMyDgfWLlg(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							int num2;
							if (P_1[num].sourceId == P_0.sourceId)
							{
								num2 = 1142802090;
							}
							else
							{
								num++;
								num2 = 1142802091;
							}
							while (true)
							{
								switch (num2 ^ 0x441DC6AB)
								{
								case 3:
									num2 = 1142802089;
									continue;
								case 2:
									break;
								case 1:
									return num;
								default:
									goto end_IL_0026;
								}
								break;
							}
							continue;
							end_IL_0026:
							break;
						}
					}
					return -1;
				}
			}

			private sealed class OpGCrwegZHTgRIPAFgRmhNzbrbI
			{
				public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

				public List<int> NGrXeWBrJVipQrvKdrzgvFBZOLI;

				public InputMapCategory tUFMguTFMGqYyJyuzmmnBQGuxUE(WWUpfvqQFZlIEoRQvLsKEixNqFE<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
					InputMapCategory inputMapCategory2 = default(InputMapCategory);
					if (P_0.NpsWIyadXdsVqgWIvBUhGOVedbc)
					{
						inputMapCategory2 = P_0.sxChUSdSSHzfOGjISaivOHFKIkAN;
						goto IL_00b3;
					}
					goto IL_00ca;
					IL_00ca:
					qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.AddMapCategory();
					int num = -41661994;
					goto IL_0028;
					IL_00b3:
					int num2 = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(inputMapCategory2);
					num = -41661999;
					goto IL_0028;
					IL_0028:
					while (true)
					{
						switch (num ^ -41662000)
						{
						case 3:
							num = -41661998;
							continue;
						case 1:
							if (P_0.bBIOjiIAZNexadkAtlPGjDbqhHH == MhuNWsSNdeFIOPrqUpcotrinQGK.xcbwZwGvfnVcagdGpAqUoxbbmBe.XfMFYPNbBYWiYxGxDZakDleTnIg)
							{
								NGrXeWBrJVipQrvKdrzgvFBZOLI.Add(num2);
								num = -41661995;
								continue;
							}
							goto case 5;
						case 6:
							inputMapCategory2 = P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
							num = -41662000;
							continue;
						case 5:
							inputMapCategory.id = inputMapCategory2.id;
							P_0.YGHUMpjyJDPJsOTlymzEWtSFFGh[num2] = inputMapCategory;
							num = -41661996;
							continue;
						case 0:
							break;
						case 2:
							goto IL_00ca;
						default:
							return inputMapCategory;
						}
						break;
					}
					goto IL_00b3;
				}
			}

			private sealed class dhSPyqTyhAowfJKOyAArxMAotxk
			{
				public OpGCrwegZHTgRIPAFgRmhNzbrbI EedWArVPGOkhrrglxdgkNqWHCvhE;

				public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

				public int XfMFYPNbBYWiYxGxDZakDleTnIg;

				public bool FLVXRBXrwRYEHkDjivbuKLxvvMG(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
				{
					return P_0.XfMFYPNbBYWiYxGxDZakDleTnIg == XfMFYPNbBYWiYxGxDZakDleTnIg;
				}
			}

			private sealed class XvxMlGZRzqwiVnEqjlHWSIHppcb
			{
				private sealed class iRhrByahfkcKikIeRqtIGQaNuZyz
				{
					public XvxMlGZRzqwiVnEqjlHWSIHppcb eyCaNQUbqKOvhDEYEzljXJSOEuq;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ControllerMap_Editor KEojvyjKrFDfpXOmrgEOERpcrbV;

					public bool eIzanQFzzXhIfKbSKqQJHQpfLWBD(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0.XfMFYPNbBYWiYxGxDZakDleTnIg == KEojvyjKrFDfpXOmrgEOERpcrbV.categoryId;
					}

					public bool CyUWwdvQyBaoHDeOTmBpdJkerjj(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0.XfMFYPNbBYWiYxGxDZakDleTnIg == KEojvyjKrFDfpXOmrgEOERpcrbV.layoutId;
					}
				}

				private sealed class ZEqOfzJpIkUwyCDtKzomKrrquOV
				{
					public XvxMlGZRzqwiVnEqjlHWSIHppcb eyCaNQUbqKOvhDEYEzljXJSOEuq;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ControllerMap_Editor hzhCQPjLDfvQZlOJUPCTNBARTjC;

					public WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMap_Editor> iColUqUtJXiUJwiPnwRpPAsIDOd;

					public bool zOracyJkWpvBGLBbMfakTWKAoIRv(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId;
					}

					public bool TiHzwltYcjrhGQbYAaGEnTpZDiJ(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId;
					}
				}

				private sealed class VFCBwLgjvBNnKwZAtxteAEvvnklM
				{
					public ZEqOfzJpIkUwyCDtKzomKrrquOV utfCFBpoXOahanPkxzKOEfFAgOWh;

					public XvxMlGZRzqwiVnEqjlHWSIHppcb eyCaNQUbqKOvhDEYEzljXJSOEuq;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ActionElementMap amYJzCKmWOsOgUiomdbNfsuODACj;

					public bool gSQUglGGoKfSKRyKfEsfBnByjIBd(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[utfCFBpoXOahanPkxzKOEfFAgOWh.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == amYJzCKmWOsOgUiomdbNfsuODACj._actionId;
					}
				}

				public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> KCRiTwViJHANxZIErLrDMwYiMhL;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> ogsEGhJINnmpZwgSMjnJGsAAgXmr;

				public int DadfTifqLMzLBHzPBuRrrgbuhMnB(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					iRhrByahfkcKikIeRqtIGQaNuZyz iRhrByahfkcKikIeRqtIGQaNuZyz2 = new iRhrByahfkcKikIeRqtIGQaNuZyz();
					iRhrByahfkcKikIeRqtIGQaNuZyz2.eyCaNQUbqKOvhDEYEzljXJSOEuq = this;
					int num2 = default(int);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					while (true)
					{
						int num = -2087848151;
						while (true)
						{
							switch (num ^ -2087848149)
							{
							case 4:
								break;
							case 2:
								iRhrByahfkcKikIeRqtIGQaNuZyz2.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
								iRhrByahfkcKikIeRqtIGQaNuZyz2.KEojvyjKrFDfpXOmrgEOERpcrbV = P_0;
								num2 = 0;
								num = -2087848152;
								continue;
							case 0:
								if (mhuNWsSNdeFIOPrqUpcotrinQGK.ehNPUFIecmjcFTrEUzbaEBmcMGD == P_1[num2].categoryId && mhuNWsSNdeFIOPrqUpcotrinQGK2 != null)
								{
									num = -2087848146;
									continue;
								}
								goto IL_00e4;
							case 1:
								mhuNWsSNdeFIOPrqUpcotrinQGK = qFUiIUBmnPANbAilZAhlbWWAmVb.UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(iRhrByahfkcKikIeRqtIGQaNuZyz2.eIzanQFzzXhIfKbSKqQJHQpfLWBD);
								mhuNWsSNdeFIOPrqUpcotrinQGK2 = KCRiTwViJHANxZIErLrDMwYiMhL.Find(iRhrByahfkcKikIeRqtIGQaNuZyz2.CyUWwdvQyBaoHDeOTmBpdJkerjj);
								if (mhuNWsSNdeFIOPrqUpcotrinQGK != null)
								{
									num = -2087848149;
									continue;
								}
								goto IL_00e4;
							case 5:
								if (mhuNWsSNdeFIOPrqUpcotrinQGK2.ehNPUFIecmjcFTrEUzbaEBmcMGD == P_1[num2].layoutId)
								{
									return num2;
								}
								goto IL_00e4;
							default:
								{
									if (num2 >= P_1.Count)
									{
										return -1;
									}
									goto case 1;
								}
								IL_00e4:
								num2++;
								num = -2087848152;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor iWoNdGdpDHdQpCcVPGyuSSoRiHg(WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMap_Editor> P_0)
				{
					ZEqOfzJpIkUwyCDtKzomKrrquOV zEqOfzJpIkUwyCDtKzomKrrquOV = new ZEqOfzJpIkUwyCDtKzomKrrquOV();
					zEqOfzJpIkUwyCDtKzomKrrquOV.eyCaNQUbqKOvhDEYEzljXJSOEuq = this;
					zEqOfzJpIkUwyCDtKzomKrrquOV.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					VFCBwLgjvBNnKwZAtxteAEvvnklM vFCBwLgjvBNnKwZAtxteAEvvnklM = default(VFCBwLgjvBNnKwZAtxteAEvvnklM);
					int num2 = default(int);
					while (true)
					{
						int num = -1507749428;
						while (true)
						{
							switch (num ^ -1507749431)
							{
							case 2:
								break;
							case 5:
								zEqOfzJpIkUwyCDtKzomKrrquOV.iColUqUtJXiUJwiPnwRpPAsIDOd = P_0;
								zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC = JsonTools.Clone(zEqOfzJpIkUwyCDtKzomKrrquOV.iColUqUtJXiUJwiPnwRpPAsIDOd.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
								mhuNWsSNdeFIOPrqUpcotrinQGK = qFUiIUBmnPANbAilZAhlbWWAmVb.UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(zEqOfzJpIkUwyCDtKzomKrrquOV.zOracyJkWpvBGLBbMfakTWKAoIRv);
								num = -1507749440;
								continue;
							case 6:
								num = -1507749435;
								continue;
							case 4:
								controllerMap_Editor2 = zEqOfzJpIkUwyCDtKzomKrrquOV.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[zEqOfzJpIkUwyCDtKzomKrrquOV.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
								num = -1507749430;
								continue;
							case 1:
							{
								Func<ActionElementMap, IList<ActionElementMap>, int> func = ogsEGhJINnmpZwgSMjnJGsAAgXmr;
								zLsFHNesqsGCpHNZSkhdBdStDvNb(controllerMap_Editor2.actionElementMaps, zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps, controllerMap_Editor.actionElementMaps, func);
								num = -1507749426;
								continue;
							}
							case 11:
							{
								vFCBwLgjvBNnKwZAtxteAEvvnklM.utfCFBpoXOahanPkxzKOEfFAgOWh = zEqOfzJpIkUwyCDtKzomKrrquOV;
								vFCBwLgjvBNnKwZAtxteAEvvnklM.eyCaNQUbqKOvhDEYEzljXJSOEuq = this;
								vFCBwLgjvBNnKwZAtxteAEvvnklM.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
								vFCBwLgjvBNnKwZAtxteAEvvnklM.amYJzCKmWOsOgUiomdbNfsuODACj = zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps[num2];
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK3 = qFUiIUBmnPANbAilZAhlbWWAmVb.zAvCIOcMYPmqcDAQowOVcRKFVmm.Find(vFCBwLgjvBNnKwZAtxteAEvvnklM.gSQUglGGoKfSKRyKfEsfBnByjIBd);
								vFCBwLgjvBNnKwZAtxteAEvvnklM.amYJzCKmWOsOgUiomdbNfsuODACj._actionId = mhuNWsSNdeFIOPrqUpcotrinQGK3?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								vFCBwLgjvBNnKwZAtxteAEvvnklM.amYJzCKmWOsOgUiomdbNfsuODACj._actionCategoryId = ((qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.GetActionById(vFCBwLgjvBNnKwZAtxteAEvvnklM.amYJzCKmWOsOgUiomdbNfsuODACj._actionId) != null) ? qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.GetActionById(vFCBwLgjvBNnKwZAtxteAEvvnklM.amYJzCKmWOsOgUiomdbNfsuODACj._actionId).categoryId : 0);
								num2++;
								num = -1507749435;
								continue;
							}
							case 0:
								vFCBwLgjvBNnKwZAtxteAEvvnklM = new VFCBwLgjvBNnKwZAtxteAEvvnklM();
								num = -1507749438;
								continue;
							case 9:
							{
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = KCRiTwViJHANxZIErLrDMwYiMhL.Find(zEqOfzJpIkUwyCDtKzomKrrquOV.TiHzwltYcjrhGQbYAaGEnTpZDiJ);
								zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId = mhuNWsSNdeFIOPrqUpcotrinQGK?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId = mhuNWsSNdeFIOPrqUpcotrinQGK2?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								num2 = 0;
								num = -1507749425;
								continue;
							}
							case 12:
								if (num2 < zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps.Count)
								{
									goto case 0;
								}
								if (zEqOfzJpIkUwyCDtKzomKrrquOV.iColUqUtJXiUJwiPnwRpPAsIDOd.NpsWIyadXdsVqgWIvBUhGOVedbc)
								{
									controllerMap_Editor2 = zEqOfzJpIkUwyCDtKzomKrrquOV.iColUqUtJXiUJwiPnwRpPAsIDOd.sxChUSdSSHzfOGjISaivOHFKIkAN;
									controllerMap_Editor = JsonTools.Clone(zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC);
									controllerMap_Editor.actionElementMaps.Clear();
									if (ogsEGhJINnmpZwgSMjnJGsAAgXmr == null)
									{
										ogsEGhJINnmpZwgSMjnJGsAAgXmr = CnEeAVXwBsoYNZdFNBVkPNJXtKz;
										num = -1507749432;
										continue;
									}
									goto case 1;
								}
								goto case 10;
							case 3:
							{
								zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC.id = controllerMap_Editor2.id;
								int index = zEqOfzJpIkUwyCDtKzomKrrquOV.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(controllerMap_Editor2);
								zEqOfzJpIkUwyCDtKzomKrrquOV.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC;
								num = -1507749439;
								continue;
							}
							case 7:
								zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC = controllerMap_Editor;
								num = -1507749430;
								continue;
							case 10:
								qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.CreateKeyboardMap(zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId, zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId);
								num = -1507749427;
								continue;
							default:
								return zEqOfzJpIkUwyCDtKzomKrrquOV.hzhCQPjLDfvQZlOJUPCTNBARTjC;
							}
							break;
						}
					}
				}

				private static int CnEeAVXwBsoYNZdFNBVkPNJXtKz(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (true)
					{
						int num2 = 1864530506;
						while (true)
						{
							switch (num2 ^ 0x6F227A4B)
							{
							case 2:
								break;
							case 1:
								num2 = 1864530507;
								continue;
							case 5:
								if (P_1[num]._axisContribution == P_0._axisContribution && P_1[num]._actionId == P_0._actionId)
								{
									return num;
								}
								goto IL_0060;
							case 3:
								if (P_1[num]._keyboardKeyCode == P_0._keyboardKeyCode && P_1[num]._modifierKey1 == P_0._modifierKey1 && P_1[num]._modifierKey2 == P_0._modifierKey2 && P_1[num]._modifierKey3 == P_0._modifierKey3)
								{
									num2 = 1864530510;
									continue;
								}
								goto IL_0060;
							case 0:
							{
								int num3;
								if (num < P_1.Count)
								{
									num2 = 1864530504;
									num3 = num2;
								}
								else
								{
									num2 = 1864530511;
									num3 = num2;
								}
								continue;
							}
							default:
								{
									return -1;
								}
								IL_0060:
								num++;
								num2 = 1864530507;
								continue;
							}
							break;
						}
					}
				}
			}

			private sealed class RFVNJSrFxlZOJQUSJFQsIcVbhqU
			{
				private sealed class EuGOxdqmTYbfwFwRJRICYqOzBBR
				{
					public RFVNJSrFxlZOJQUSJFQsIcVbhqU OvxrFDFBuhDQwFHJKeMFrQlBvcj;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ControllerMap_Editor KEojvyjKrFDfpXOmrgEOERpcrbV;

					public bool uYZZJsmrLOfFtfTZpObUegXDleE(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0.XfMFYPNbBYWiYxGxDZakDleTnIg == KEojvyjKrFDfpXOmrgEOERpcrbV.categoryId;
					}

					public bool pRwRmGKxGeWEDrMbuPQSRSjkncG(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0.XfMFYPNbBYWiYxGxDZakDleTnIg == KEojvyjKrFDfpXOmrgEOERpcrbV.layoutId;
					}
				}

				private sealed class wRjacXKPdKGpBrjotdAUSsWJEOld
				{
					public RFVNJSrFxlZOJQUSJFQsIcVbhqU OvxrFDFBuhDQwFHJKeMFrQlBvcj;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ControllerMap_Editor hzhCQPjLDfvQZlOJUPCTNBARTjC;

					public WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMap_Editor> iColUqUtJXiUJwiPnwRpPAsIDOd;

					public bool mQVezlEsDvFfkNXdoJorTkISJiU(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId;
					}

					public bool lEKmIOQIRIGZCypsqnLVPNvRDge(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId;
					}
				}

				private sealed class mJYHGkHprPqTBIPyUhQCsPONnv
				{
					public wRjacXKPdKGpBrjotdAUSsWJEOld WJxcskJGdTCsUfBtgVzavCuBosyt;

					public RFVNJSrFxlZOJQUSJFQsIcVbhqU OvxrFDFBuhDQwFHJKeMFrQlBvcj;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ActionElementMap amYJzCKmWOsOgUiomdbNfsuODACj;

					public bool wJutBdFpMiVvRiLXDWPnhicluWL(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[WJxcskJGdTCsUfBtgVzavCuBosyt.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == amYJzCKmWOsOgUiomdbNfsuODACj._actionId;
					}
				}

				public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> KCRiTwViJHANxZIErLrDMwYiMhL;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> SozEhOhkvPMYXsQcPnTdVzmzJXl;

				public int JWPSCXfWGqSLgmBIZYulvDjhFcS(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					EuGOxdqmTYbfwFwRJRICYqOzBBR euGOxdqmTYbfwFwRJRICYqOzBBR = new EuGOxdqmTYbfwFwRJRICYqOzBBR();
					euGOxdqmTYbfwFwRJRICYqOzBBR.OvxrFDFBuhDQwFHJKeMFrQlBvcj = this;
					euGOxdqmTYbfwFwRJRICYqOzBBR.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
					int num2 = default(int);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					while (true)
					{
						int num = -1720456741;
						while (true)
						{
							switch (num ^ -1720456744)
							{
							case 2:
								break;
							case 3:
								euGOxdqmTYbfwFwRJRICYqOzBBR.KEojvyjKrFDfpXOmrgEOERpcrbV = P_0;
								num2 = 0;
								num = -1720456744;
								continue;
							case 5:
								if (mhuNWsSNdeFIOPrqUpcotrinQGK2.ehNPUFIecmjcFTrEUzbaEBmcMGD == P_1[num2].layoutId)
								{
									return num2;
								}
								goto IL_0079;
							case 1:
								mhuNWsSNdeFIOPrqUpcotrinQGK2 = KCRiTwViJHANxZIErLrDMwYiMhL.Find(euGOxdqmTYbfwFwRJRICYqOzBBR.pRwRmGKxGeWEDrMbuPQSRSjkncG);
								if (mhuNWsSNdeFIOPrqUpcotrinQGK != null && mhuNWsSNdeFIOPrqUpcotrinQGK.ehNPUFIecmjcFTrEUzbaEBmcMGD == P_1[num2].categoryId && mhuNWsSNdeFIOPrqUpcotrinQGK2 != null)
								{
									num = -1720456739;
									continue;
								}
								goto IL_0079;
							case 0:
								num = -1720456740;
								continue;
							case 6:
								mhuNWsSNdeFIOPrqUpcotrinQGK = qFUiIUBmnPANbAilZAhlbWWAmVb.UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(euGOxdqmTYbfwFwRJRICYqOzBBR.uYZZJsmrLOfFtfTZpObUegXDleE);
								num = -1720456743;
								continue;
							default:
								{
									if (num2 >= P_1.Count)
									{
										return -1;
									}
									goto case 6;
								}
								IL_0079:
								num2++;
								num = -1720456740;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor DIOZvUYjukzUxmWfTQPqIJJhwdr(WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMap_Editor> P_0)
				{
					wRjacXKPdKGpBrjotdAUSsWJEOld wRjacXKPdKGpBrjotdAUSsWJEOld2 = new wRjacXKPdKGpBrjotdAUSsWJEOld();
					wRjacXKPdKGpBrjotdAUSsWJEOld2.OvxrFDFBuhDQwFHJKeMFrQlBvcj = this;
					wRjacXKPdKGpBrjotdAUSsWJEOld2.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
					wRjacXKPdKGpBrjotdAUSsWJEOld2.iColUqUtJXiUJwiPnwRpPAsIDOd = P_0;
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					int num2 = default(int);
					int index = default(int);
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					Func<ActionElementMap, IList<ActionElementMap>, int> sozEhOhkvPMYXsQcPnTdVzmzJXl = default(Func<ActionElementMap, IList<ActionElementMap>, int>);
					mJYHGkHprPqTBIPyUhQCsPONnv mJYHGkHprPqTBIPyUhQCsPONnv2 = default(mJYHGkHprPqTBIPyUhQCsPONnv);
					while (true)
					{
						int num = -1841648700;
						while (true)
						{
							switch (num ^ -1841648698)
							{
							case 3:
								break;
							case 2:
							{
								wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC = JsonTools.Clone(wRjacXKPdKGpBrjotdAUSsWJEOld2.iColUqUtJXiUJwiPnwRpPAsIDOd.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = qFUiIUBmnPANbAilZAhlbWWAmVb.UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(wRjacXKPdKGpBrjotdAUSsWJEOld2.mQVezlEsDvFfkNXdoJorTkISJiU);
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK3 = KCRiTwViJHANxZIErLrDMwYiMhL.Find(wRjacXKPdKGpBrjotdAUSsWJEOld2.lEKmIOQIRIGZCypsqnLVPNvRDge);
								wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId = mhuNWsSNdeFIOPrqUpcotrinQGK2?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId = mhuNWsSNdeFIOPrqUpcotrinQGK3?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								num = -1841648692;
								continue;
							}
							case 0:
								controllerMap_Editor2 = wRjacXKPdKGpBrjotdAUSsWJEOld2.iColUqUtJXiUJwiPnwRpPAsIDOd.sxChUSdSSHzfOGjISaivOHFKIkAN;
								num = -1841648697;
								continue;
							case 10:
								num2 = 0;
								num = -1841648690;
								continue;
							case 15:
								wRjacXKPdKGpBrjotdAUSsWJEOld2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC;
								num = -1841648696;
								continue;
							case 1:
							{
								controllerMap_Editor = JsonTools.Clone(wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC);
								controllerMap_Editor.actionElementMaps.Clear();
								int num3;
								if (SozEhOhkvPMYXsQcPnTdVzmzJXl == null)
								{
									num = -1841648701;
									num3 = num;
								}
								else
								{
									num = -1841648682;
									num3 = num;
								}
								continue;
							}
							case 16:
								sozEhOhkvPMYXsQcPnTdVzmzJXl = SozEhOhkvPMYXsQcPnTdVzmzJXl;
								num = -1841648694;
								continue;
							case 12:
								zLsFHNesqsGCpHNZSkhdBdStDvNb(controllerMap_Editor2.actionElementMaps, wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps, controllerMap_Editor.actionElementMaps, sozEhOhkvPMYXsQcPnTdVzmzJXl);
								num = -1841648689;
								continue;
							case 9:
								wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC = controllerMap_Editor;
								num = -1841648702;
								continue;
							case 4:
								wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC.id = controllerMap_Editor2.id;
								index = wRjacXKPdKGpBrjotdAUSsWJEOld2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(controllerMap_Editor2);
								num = -1841648695;
								continue;
							case 8:
								if (num2 >= wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps.Count)
								{
									int num4;
									if (!wRjacXKPdKGpBrjotdAUSsWJEOld2.iColUqUtJXiUJwiPnwRpPAsIDOd.NpsWIyadXdsVqgWIvBUhGOVedbc)
									{
										num = -1841648704;
										num4 = num;
									}
									else
									{
										num = -1841648698;
										num4 = num;
									}
									continue;
								}
								goto case 7;
							case 13:
								mJYHGkHprPqTBIPyUhQCsPONnv2.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
								num = -1841648691;
								continue;
							case 6:
								qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.CreateMouseMap(wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId, wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId);
								controllerMap_Editor2 = wRjacXKPdKGpBrjotdAUSsWJEOld2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[wRjacXKPdKGpBrjotdAUSsWJEOld2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
								num = -1841648702;
								continue;
							case 11:
							{
								mJYHGkHprPqTBIPyUhQCsPONnv2.amYJzCKmWOsOgUiomdbNfsuODACj = wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps[num2];
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = qFUiIUBmnPANbAilZAhlbWWAmVb.zAvCIOcMYPmqcDAQowOVcRKFVmm.Find(mJYHGkHprPqTBIPyUhQCsPONnv2.wJutBdFpMiVvRiLXDWPnhicluWL);
								mJYHGkHprPqTBIPyUhQCsPONnv2.amYJzCKmWOsOgUiomdbNfsuODACj._actionId = mhuNWsSNdeFIOPrqUpcotrinQGK?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								mJYHGkHprPqTBIPyUhQCsPONnv2.amYJzCKmWOsOgUiomdbNfsuODACj._actionCategoryId = ((qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.GetActionById(mJYHGkHprPqTBIPyUhQCsPONnv2.amYJzCKmWOsOgUiomdbNfsuODACj._actionId) != null) ? qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.GetActionById(mJYHGkHprPqTBIPyUhQCsPONnv2.amYJzCKmWOsOgUiomdbNfsuODACj._actionId).categoryId : 0);
								num2++;
								num = -1841648690;
								continue;
							}
							case 7:
								mJYHGkHprPqTBIPyUhQCsPONnv2 = new mJYHGkHprPqTBIPyUhQCsPONnv();
								mJYHGkHprPqTBIPyUhQCsPONnv2.WJxcskJGdTCsUfBtgVzavCuBosyt = wRjacXKPdKGpBrjotdAUSsWJEOld2;
								mJYHGkHprPqTBIPyUhQCsPONnv2.OvxrFDFBuhDQwFHJKeMFrQlBvcj = this;
								num = -1841648693;
								continue;
							case 5:
								SozEhOhkvPMYXsQcPnTdVzmzJXl = FPZNCPCOYNWYDJexNgEyliHhtQG;
								num = -1841648682;
								continue;
							default:
								return wRjacXKPdKGpBrjotdAUSsWJEOld2.hzhCQPjLDfvQZlOJUPCTNBARTjC;
							}
							break;
						}
					}
				}

				private static int FPZNCPCOYNWYDJexNgEyliHhtQG(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							int num2;
							if (P_1[num]._elementIdentifierId == P_0._elementIdentifierId && P_1[num]._axisRange == P_0._axisRange)
							{
								num2 = -1655000736;
								goto IL_000c;
							}
							goto IL_0082;
							IL_000c:
							while (true)
							{
								switch (num2 ^ -1655000736)
								{
								case 2:
									num2 = -1655000733;
									continue;
								case 3:
									break;
								case 0:
									goto IL_0058;
								default:
									goto end_IL_0029;
								}
								break;
							}
							continue;
							IL_0058:
							if (P_1[num]._axisContribution == P_0._axisContribution && P_1[num]._actionId == P_0._actionId)
							{
								return num;
							}
							goto IL_0082;
							IL_0082:
							num++;
							num2 = -1655000735;
							goto IL_000c;
							continue;
							end_IL_0029:
							break;
						}
					}
					return -1;
				}
			}

			private sealed class RQzFHtgryVKiyBWACVsEWQfIUaGQ
			{
				private sealed class NBlQFBzKsOdivvjbuFhDYUVtRDC
				{
					public RQzFHtgryVKiyBWACVsEWQfIUaGQ zkFWvbktMGrDWcokxJApcdeaxVv;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ControllerMap_Editor KEojvyjKrFDfpXOmrgEOERpcrbV;

					public bool LbHFxYtvQbTwfcQJfeMdGoUpPJV(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0.XfMFYPNbBYWiYxGxDZakDleTnIg == KEojvyjKrFDfpXOmrgEOERpcrbV.categoryId;
					}

					public bool dsYsXyVXyaDssroEfIcrHLlvSoZ(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0.XfMFYPNbBYWiYxGxDZakDleTnIg == KEojvyjKrFDfpXOmrgEOERpcrbV.layoutId;
					}
				}

				private sealed class oqQpJtFKqmWkQvtanRNLctOhdSn
				{
					public RQzFHtgryVKiyBWACVsEWQfIUaGQ zkFWvbktMGrDWcokxJApcdeaxVv;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ControllerMap_Editor hzhCQPjLDfvQZlOJUPCTNBARTjC;

					public WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMap_Editor> iColUqUtJXiUJwiPnwRpPAsIDOd;

					public bool wRWDZGsMNTbDdcuidjxvFHpAZtL(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId;
					}

					public bool RXxCacBTsvNEkqIjoaFkHIvAObgP(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId;
					}
				}

				private sealed class YyAuzIgMyOFzoJWmMTQiadfdZAg
				{
					public oqQpJtFKqmWkQvtanRNLctOhdSn oaagkmdVehgBkfcsvGkvrAsRCZgI;

					public RQzFHtgryVKiyBWACVsEWQfIUaGQ zkFWvbktMGrDWcokxJApcdeaxVv;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ActionElementMap amYJzCKmWOsOgUiomdbNfsuODACj;

					public bool YurGBubVyNWCmfsyTJidnZZgCQJ(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[oaagkmdVehgBkfcsvGkvrAsRCZgI.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == amYJzCKmWOsOgUiomdbNfsuODACj._actionId;
					}
				}

				public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> KCRiTwViJHANxZIErLrDMwYiMhL;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> JyVhrgughCelQActPJcQgzjcBtMB;

				public int RrYEdzFTOdGtlWNhDcFfcrhYtSsK(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					NBlQFBzKsOdivvjbuFhDYUVtRDC nBlQFBzKsOdivvjbuFhDYUVtRDC = new NBlQFBzKsOdivvjbuFhDYUVtRDC();
					nBlQFBzKsOdivvjbuFhDYUVtRDC.zkFWvbktMGrDWcokxJApcdeaxVv = this;
					nBlQFBzKsOdivvjbuFhDYUVtRDC.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
					nBlQFBzKsOdivvjbuFhDYUVtRDC.KEojvyjKrFDfpXOmrgEOERpcrbV = P_0;
					int num = 0;
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					while (true)
					{
						int num2;
						int num3;
						if (num >= P_1.Count)
						{
							num2 = -685031288;
							num3 = num2;
						}
						else
						{
							num2 = -685031287;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -685031288)
							{
							case 6:
								num2 = -685031287;
								continue;
							case 3:
								if (mhuNWsSNdeFIOPrqUpcotrinQGK.ehNPUFIecmjcFTrEUzbaEBmcMGD == P_1[num].categoryId && mhuNWsSNdeFIOPrqUpcotrinQGK2 != null && mhuNWsSNdeFIOPrqUpcotrinQGK2.ehNPUFIecmjcFTrEUzbaEBmcMGD == P_1[num].layoutId)
								{
									num2 = -685031283;
									continue;
								}
								goto IL_00e2;
							case 4:
								mhuNWsSNdeFIOPrqUpcotrinQGK2 = KCRiTwViJHANxZIErLrDMwYiMhL.Find(nBlQFBzKsOdivvjbuFhDYUVtRDC.dsYsXyVXyaDssroEfIcrHLlvSoZ);
								if (nBlQFBzKsOdivvjbuFhDYUVtRDC.KEojvyjKrFDfpXOmrgEOERpcrbV.hardwareGuid == P_1[num].hardwareGuid && mhuNWsSNdeFIOPrqUpcotrinQGK != null)
								{
									num2 = -685031285;
									continue;
								}
								goto IL_00e2;
							case 5:
								return num;
							case 2:
								break;
							case 1:
								mhuNWsSNdeFIOPrqUpcotrinQGK = qFUiIUBmnPANbAilZAhlbWWAmVb.UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(nBlQFBzKsOdivvjbuFhDYUVtRDC.LbHFxYtvQbTwfcQJfeMdGoUpPJV);
								num2 = -685031284;
								continue;
							default:
								{
									return -1;
								}
								IL_00e2:
								num++;
								num2 = -685031286;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor PLwIAywnGXeaEEjWkkLwgeMeroLA(WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMap_Editor> P_0)
				{
					oqQpJtFKqmWkQvtanRNLctOhdSn oqQpJtFKqmWkQvtanRNLctOhdSn2 = new oqQpJtFKqmWkQvtanRNLctOhdSn();
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					YyAuzIgMyOFzoJWmMTQiadfdZAg yyAuzIgMyOFzoJWmMTQiadfdZAg = default(YyAuzIgMyOFzoJWmMTQiadfdZAg);
					int num2 = default(int);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					while (true)
					{
						int num = 1163000607;
						while (true)
						{
							switch (num ^ 0x4551FB16)
							{
							case 12:
								break;
							case 0:
							{
								int num3;
								if (JyVhrgughCelQActPJcQgzjcBtMB == null)
								{
									num = 1163000599;
									num3 = num;
								}
								else
								{
									num = 1163000596;
									num3 = num;
								}
								continue;
							}
							case 8:
								qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.CreateJoystickMap(oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId, oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC.hardwareGuid, oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId);
								controllerMap_Editor = oqQpJtFKqmWkQvtanRNLctOhdSn2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[oqQpJtFKqmWkQvtanRNLctOhdSn2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
								num = 1163000603;
								continue;
							case 10:
							{
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = qFUiIUBmnPANbAilZAhlbWWAmVb.zAvCIOcMYPmqcDAQowOVcRKFVmm.Find(yyAuzIgMyOFzoJWmMTQiadfdZAg.YurGBubVyNWCmfsyTJidnZZgCQJ);
								yyAuzIgMyOFzoJWmMTQiadfdZAg.amYJzCKmWOsOgUiomdbNfsuODACj._actionId = mhuNWsSNdeFIOPrqUpcotrinQGK2?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								yyAuzIgMyOFzoJWmMTQiadfdZAg.amYJzCKmWOsOgUiomdbNfsuODACj._actionCategoryId = ((qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.GetActionById(yyAuzIgMyOFzoJWmMTQiadfdZAg.amYJzCKmWOsOgUiomdbNfsuODACj._actionId) != null) ? qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.GetActionById(yyAuzIgMyOFzoJWmMTQiadfdZAg.amYJzCKmWOsOgUiomdbNfsuODACj._actionId).categoryId : 0);
								num2++;
								num = 1163000592;
								continue;
							}
							case 13:
							{
								oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC.id = controllerMap_Editor.id;
								int index = oqQpJtFKqmWkQvtanRNLctOhdSn2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(controllerMap_Editor);
								oqQpJtFKqmWkQvtanRNLctOhdSn2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC;
								num = 1163000595;
								continue;
							}
							case 1:
								JyVhrgughCelQActPJcQgzjcBtMB = awJKbqSPSwwohYBKKGTrTTwnNrK;
								num = 1163000596;
								continue;
							case 9:
							{
								oqQpJtFKqmWkQvtanRNLctOhdSn2.zkFWvbktMGrDWcokxJApcdeaxVv = this;
								oqQpJtFKqmWkQvtanRNLctOhdSn2.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
								oqQpJtFKqmWkQvtanRNLctOhdSn2.iColUqUtJXiUJwiPnwRpPAsIDOd = P_0;
								oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC = JsonTools.Clone(oqQpJtFKqmWkQvtanRNLctOhdSn2.iColUqUtJXiUJwiPnwRpPAsIDOd.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK3 = qFUiIUBmnPANbAilZAhlbWWAmVb.UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(oqQpJtFKqmWkQvtanRNLctOhdSn2.wRWDZGsMNTbDdcuidjxvFHpAZtL);
								mhuNWsSNdeFIOPrqUpcotrinQGK = KCRiTwViJHANxZIErLrDMwYiMhL.Find(oqQpJtFKqmWkQvtanRNLctOhdSn2.RXxCacBTsvNEkqIjoaFkHIvAObgP);
								oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId = mhuNWsSNdeFIOPrqUpcotrinQGK3?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								num = 1163000593;
								continue;
							}
							case 11:
								yyAuzIgMyOFzoJWmMTQiadfdZAg.oaagkmdVehgBkfcsvGkvrAsRCZgI = oqQpJtFKqmWkQvtanRNLctOhdSn2;
								yyAuzIgMyOFzoJWmMTQiadfdZAg.zkFWvbktMGrDWcokxJApcdeaxVv = this;
								yyAuzIgMyOFzoJWmMTQiadfdZAg.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
								yyAuzIgMyOFzoJWmMTQiadfdZAg.amYJzCKmWOsOgUiomdbNfsuODACj = oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps[num2];
								num = 1163000604;
								continue;
							case 6:
								if (num2 >= oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps.Count)
								{
									if (oqQpJtFKqmWkQvtanRNLctOhdSn2.iColUqUtJXiUJwiPnwRpPAsIDOd.NpsWIyadXdsVqgWIvBUhGOVedbc)
									{
										controllerMap_Editor = oqQpJtFKqmWkQvtanRNLctOhdSn2.iColUqUtJXiUJwiPnwRpPAsIDOd.sxChUSdSSHzfOGjISaivOHFKIkAN;
										controllerMap_Editor2 = JsonTools.Clone(oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC);
										num = 1163000594;
										continue;
									}
									goto case 8;
								}
								goto case 3;
							case 4:
								controllerMap_Editor2.actionElementMaps.Clear();
								num = 1163000598;
								continue;
							case 7:
								oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId = mhuNWsSNdeFIOPrqUpcotrinQGK?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								num2 = 0;
								num = 1163000592;
								continue;
							case 3:
								yyAuzIgMyOFzoJWmMTQiadfdZAg = new YyAuzIgMyOFzoJWmMTQiadfdZAg();
								num = 1163000605;
								continue;
							case 2:
							{
								Func<ActionElementMap, IList<ActionElementMap>, int> jyVhrgughCelQActPJcQgzjcBtMB = JyVhrgughCelQActPJcQgzjcBtMB;
								zLsFHNesqsGCpHNZSkhdBdStDvNb(controllerMap_Editor.actionElementMaps, oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps, controllerMap_Editor2.actionElementMaps, jyVhrgughCelQActPJcQgzjcBtMB);
								oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC = controllerMap_Editor2;
								num = 1163000603;
								continue;
							}
							default:
								return oqQpJtFKqmWkQvtanRNLctOhdSn2.hzhCQPjLDfvQZlOJUPCTNBARTjC;
							}
							break;
						}
					}
				}

				private static int awJKbqSPSwwohYBKKGTrTTwnNrK(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							if (P_1[num]._elementIdentifierId == P_0._elementIdentifierId && P_1[num]._axisRange == P_0._axisRange && P_1[num]._axisContribution == P_0._axisContribution && P_1[num]._actionId == P_0._actionId)
							{
								return num;
							}
							num++;
							int num2 = 107997609;
							while (true)
							{
								switch (num2 ^ 0x66FE9AB)
								{
								case 0:
									num2 = 107997610;
									continue;
								case 1:
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
					return -1;
				}
			}

			private sealed class ruAAqgAhggIYmWJmtWDXQMRCPJm
			{
				private sealed class FlDbSVYglXHYghcfblQRMbfVXBZ
				{
					public ruAAqgAhggIYmWJmtWDXQMRCPJm DtOVhjhxJqeBNGgOjqxSOuWsjTu;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ControllerMap_Editor KEojvyjKrFDfpXOmrgEOERpcrbV;

					public bool UfQXzUeelejkgVjlfkINiKONcmVf(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0.XfMFYPNbBYWiYxGxDZakDleTnIg == KEojvyjKrFDfpXOmrgEOERpcrbV.customControllerUid;
					}

					public bool roVjcRUAaTxVwZjWdvHRwOFdVMv(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0.XfMFYPNbBYWiYxGxDZakDleTnIg == KEojvyjKrFDfpXOmrgEOERpcrbV.categoryId;
					}

					public bool GSILvbMPXmKEuAaRDMFUAMDvvSE(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0.XfMFYPNbBYWiYxGxDZakDleTnIg == KEojvyjKrFDfpXOmrgEOERpcrbV.layoutId;
					}
				}

				private sealed class ipfZVkFMUUZkOttSNtPGynemLHt
				{
					public ruAAqgAhggIYmWJmtWDXQMRCPJm DtOVhjhxJqeBNGgOjqxSOuWsjTu;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ControllerMap_Editor hzhCQPjLDfvQZlOJUPCTNBARTjC;

					public WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMap_Editor> iColUqUtJXiUJwiPnwRpPAsIDOd;

					public bool LqGWEJNlQImkdhApuVDTLkppACT(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == hzhCQPjLDfvQZlOJUPCTNBARTjC.customControllerUid;
					}

					public bool ZRfKtRGpuRGfcZIMFyXRupAcKtL(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId;
					}

					public bool vevdnVodmbGznrRoWTCazjYBbelH(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId;
					}
				}

				private sealed class uzfpVgniqkDOFBwKjHhcKaHVExSv
				{
					public ipfZVkFMUUZkOttSNtPGynemLHt bNjVKRLCcfOQGMjYGnawgowtRvX;

					public ruAAqgAhggIYmWJmtWDXQMRCPJm DtOVhjhxJqeBNGgOjqxSOuWsjTu;

					public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

					public ActionElementMap amYJzCKmWOsOgUiomdbNfsuODACj;

					public bool YFsvqNdjGQKYFHuYXuqOXEndhrnb(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
					{
						return P_0[bNjVKRLCcfOQGMjYGnawgowtRvX.iColUqUtJXiUJwiPnwRpPAsIDOd.bBIOjiIAZNexadkAtlPGjDbqhHH] == amYJzCKmWOsOgUiomdbNfsuODACj._actionId;
					}
				}

				public vDgszJYctlYeDelkuaNEKylbVSB qFUiIUBmnPANbAilZAhlbWWAmVb;

				public List<MhuNWsSNdeFIOPrqUpcotrinQGK> KCRiTwViJHANxZIErLrDMwYiMhL;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> CeoicxLfVAKFPtLFIpxsUXtkieW;

				public int gnoveLzvKHCUbPugcmTUYLsaMOV(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					FlDbSVYglXHYghcfblQRMbfVXBZ flDbSVYglXHYghcfblQRMbfVXBZ = default(FlDbSVYglXHYghcfblQRMbfVXBZ);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					int num2 = default(int);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK3 = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					while (true)
					{
						int num = 1857541329;
						while (true)
						{
							switch (num ^ 0x6EB7D4D6)
							{
							case 8:
								break;
							case 7:
								flDbSVYglXHYghcfblQRMbfVXBZ = new FlDbSVYglXHYghcfblQRMbfVXBZ();
								flDbSVYglXHYghcfblQRMbfVXBZ.DtOVhjhxJqeBNGgOjqxSOuWsjTu = this;
								num = 1857541332;
								continue;
							case 4:
								if (mhuNWsSNdeFIOPrqUpcotrinQGK2 != null && mhuNWsSNdeFIOPrqUpcotrinQGK2.ehNPUFIecmjcFTrEUzbaEBmcMGD == P_1[num2].customControllerUid && mhuNWsSNdeFIOPrqUpcotrinQGK3 != null && mhuNWsSNdeFIOPrqUpcotrinQGK3.ehNPUFIecmjcFTrEUzbaEBmcMGD == P_1[num2].categoryId)
								{
									num = 1857541334;
									continue;
								}
								goto IL_00a6;
							case 0:
								if (mhuNWsSNdeFIOPrqUpcotrinQGK != null && mhuNWsSNdeFIOPrqUpcotrinQGK.ehNPUFIecmjcFTrEUzbaEBmcMGD == P_1[num2].layoutId)
								{
									return num2;
								}
								goto IL_00a6;
							case 3:
								mhuNWsSNdeFIOPrqUpcotrinQGK2 = qFUiIUBmnPANbAilZAhlbWWAmVb.bxXBAIjNrNDiLSvcpobwxkuZNvXl.Find(flDbSVYglXHYghcfblQRMbfVXBZ.UfQXzUeelejkgVjlfkINiKONcmVf);
								mhuNWsSNdeFIOPrqUpcotrinQGK3 = qFUiIUBmnPANbAilZAhlbWWAmVb.UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(flDbSVYglXHYghcfblQRMbfVXBZ.roVjcRUAaTxVwZjWdvHRwOFdVMv);
								num = 1857541335;
								continue;
							case 2:
								flDbSVYglXHYghcfblQRMbfVXBZ.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
								flDbSVYglXHYghcfblQRMbfVXBZ.KEojvyjKrFDfpXOmrgEOERpcrbV = P_0;
								num2 = 0;
								num = 1857541331;
								continue;
							case 1:
								mhuNWsSNdeFIOPrqUpcotrinQGK = KCRiTwViJHANxZIErLrDMwYiMhL.Find(flDbSVYglXHYghcfblQRMbfVXBZ.GSILvbMPXmKEuAaRDMFUAMDvvSE);
								num = 1857541330;
								continue;
							case 5:
							{
								int num3;
								if (num2 < P_1.Count)
								{
									num = 1857541333;
									num3 = num;
								}
								else
								{
									num = 1857541328;
									num3 = num;
								}
								continue;
							}
							default:
								{
									return -1;
								}
								IL_00a6:
								num2++;
								num = 1857541331;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor QjbmFftYsllPUTFJhcdJCCmzjmPz(WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMap_Editor> P_0)
				{
					ipfZVkFMUUZkOttSNtPGynemLHt ipfZVkFMUUZkOttSNtPGynemLHt2 = new ipfZVkFMUUZkOttSNtPGynemLHt();
					ipfZVkFMUUZkOttSNtPGynemLHt2.DtOVhjhxJqeBNGgOjqxSOuWsjTu = this;
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					uzfpVgniqkDOFBwKjHhcKaHVExSv uzfpVgniqkDOFBwKjHhcKaHVExSv2 = default(uzfpVgniqkDOFBwKjHhcKaHVExSv);
					int num2 = default(int);
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = default(MhuNWsSNdeFIOPrqUpcotrinQGK);
					while (true)
					{
						int num = 1769386721;
						while (true)
						{
							switch (num ^ 0x6976B2E5)
							{
							case 0:
								break;
							case 10:
								controllerMap_Editor2.actionElementMaps.Clear();
								if (CeoicxLfVAKFPtLFIpxsUXtkieW == null)
								{
									CeoicxLfVAKFPtLFIpxsUXtkieW = vlcSKOPsCopBigewvvGERjeWSAI;
									num = 1769386734;
									continue;
								}
								goto case 11;
							case 13:
								uzfpVgniqkDOFBwKjHhcKaHVExSv2.DtOVhjhxJqeBNGgOjqxSOuWsjTu = this;
								num = 1769386730;
								continue;
							case 8:
							{
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK4 = qFUiIUBmnPANbAilZAhlbWWAmVb.zAvCIOcMYPmqcDAQowOVcRKFVmm.Find(uzfpVgniqkDOFBwKjHhcKaHVExSv2.YFsvqNdjGQKYFHuYXuqOXEndhrnb);
								uzfpVgniqkDOFBwKjHhcKaHVExSv2.amYJzCKmWOsOgUiomdbNfsuODACj._actionId = mhuNWsSNdeFIOPrqUpcotrinQGK4?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								uzfpVgniqkDOFBwKjHhcKaHVExSv2.amYJzCKmWOsOgUiomdbNfsuODACj._actionCategoryId = ((qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.GetActionById(uzfpVgniqkDOFBwKjHhcKaHVExSv2.amYJzCKmWOsOgUiomdbNfsuODACj._actionId) != null) ? qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.GetActionById(uzfpVgniqkDOFBwKjHhcKaHVExSv2.amYJzCKmWOsOgUiomdbNfsuODACj._actionId).categoryId : 0);
								num2++;
								num = 1769386723;
								continue;
							}
							case 6:
								if (num2 < ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps.Count)
								{
									goto case 2;
								}
								if (ipfZVkFMUUZkOttSNtPGynemLHt2.iColUqUtJXiUJwiPnwRpPAsIDOd.NpsWIyadXdsVqgWIvBUhGOVedbc)
								{
									controllerMap_Editor = ipfZVkFMUUZkOttSNtPGynemLHt2.iColUqUtJXiUJwiPnwRpPAsIDOd.sxChUSdSSHzfOGjISaivOHFKIkAN;
									controllerMap_Editor2 = JsonTools.Clone(ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC);
									num = 1769386735;
									continue;
								}
								goto case 5;
							case 3:
							{
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK2 = qFUiIUBmnPANbAilZAhlbWWAmVb.bxXBAIjNrNDiLSvcpobwxkuZNvXl.Find(ipfZVkFMUUZkOttSNtPGynemLHt2.LqGWEJNlQImkdhApuVDTLkppACT);
								MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK3 = qFUiIUBmnPANbAilZAhlbWWAmVb.UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(ipfZVkFMUUZkOttSNtPGynemLHt2.ZRfKtRGpuRGfcZIMFyXRupAcKtL);
								mhuNWsSNdeFIOPrqUpcotrinQGK = KCRiTwViJHANxZIErLrDMwYiMhL.Find(ipfZVkFMUUZkOttSNtPGynemLHt2.vevdnVodmbGznrRoWTCazjYBbelH);
								ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC.customControllerUid = mhuNWsSNdeFIOPrqUpcotrinQGK2?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId = mhuNWsSNdeFIOPrqUpcotrinQGK3?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								num = 1769386732;
								continue;
							}
							case 2:
								uzfpVgniqkDOFBwKjHhcKaHVExSv2 = new uzfpVgniqkDOFBwKjHhcKaHVExSv();
								uzfpVgniqkDOFBwKjHhcKaHVExSv2.bNjVKRLCcfOQGMjYGnawgowtRvX = ipfZVkFMUUZkOttSNtPGynemLHt2;
								num = 1769386728;
								continue;
							case 15:
								uzfpVgniqkDOFBwKjHhcKaHVExSv2.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
								uzfpVgniqkDOFBwKjHhcKaHVExSv2.amYJzCKmWOsOgUiomdbNfsuODACj = ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps[num2];
								num = 1769386733;
								continue;
							case 12:
								ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC = controllerMap_Editor2;
								num = 1769386722;
								continue;
							case 5:
								qFUiIUBmnPANbAilZAhlbWWAmVb.gOEbMJdszjQGVnFGNAMUgiaelAsv.CreateCustomControllerMap(ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC.categoryId, ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC.customControllerUid, ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId);
								num = 1769386724;
								continue;
							case 4:
								ipfZVkFMUUZkOttSNtPGynemLHt2.qFUiIUBmnPANbAilZAhlbWWAmVb = qFUiIUBmnPANbAilZAhlbWWAmVb;
								ipfZVkFMUUZkOttSNtPGynemLHt2.iColUqUtJXiUJwiPnwRpPAsIDOd = P_0;
								ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC = JsonTools.Clone(ipfZVkFMUUZkOttSNtPGynemLHt2.iColUqUtJXiUJwiPnwRpPAsIDOd.zHDcwEEQEfTshItMCxoVVMcCGJuQ);
								num = 1769386726;
								continue;
							case 9:
								ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC.layoutId = mhuNWsSNdeFIOPrqUpcotrinQGK?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
								num = 1769386731;
								continue;
							case 11:
							{
								Func<ActionElementMap, IList<ActionElementMap>, int> ceoicxLfVAKFPtLFIpxsUXtkieW = CeoicxLfVAKFPtLFIpxsUXtkieW;
								zLsFHNesqsGCpHNZSkhdBdStDvNb(controllerMap_Editor.actionElementMaps, ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC.actionElementMaps, controllerMap_Editor2.actionElementMaps, ceoicxLfVAKFPtLFIpxsUXtkieW);
								num = 1769386729;
								continue;
							}
							case 1:
								controllerMap_Editor = ipfZVkFMUUZkOttSNtPGynemLHt2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[ipfZVkFMUUZkOttSNtPGynemLHt2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.Count - 1];
								num = 1769386722;
								continue;
							case 14:
								num2 = 0;
								num = 1769386723;
								continue;
							default:
							{
								ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC.id = controllerMap_Editor.id;
								int index = ipfZVkFMUUZkOttSNtPGynemLHt2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh.IndexOf(controllerMap_Editor);
								ipfZVkFMUUZkOttSNtPGynemLHt2.iColUqUtJXiUJwiPnwRpPAsIDOd.YGHUMpjyJDPJsOTlymzEWtSFFGh[index] = ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC;
								return ipfZVkFMUUZkOttSNtPGynemLHt2.hzhCQPjLDfvQZlOJUPCTNBARTjC;
							}
							}
							break;
						}
					}
				}

				private static int vlcSKOPsCopBigewvvGERjeWSAI(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (true)
					{
						int num2 = 1547318555;
						while (true)
						{
							switch (num2 ^ 0x5C3A351D)
							{
							case 0:
								break;
							case 6:
								num2 = 1547318558;
								continue;
							case 2:
								if (P_1[num]._elementIdentifierId == P_0._elementIdentifierId)
								{
									num2 = 1547318552;
									continue;
								}
								goto IL_00b7;
							case 3:
							{
								int num3;
								if (num < P_1.Count)
								{
									num2 = 1547318559;
									num3 = num2;
								}
								else
								{
									num2 = 1547318553;
									num3 = num2;
								}
								continue;
							}
							case 5:
								if (P_1[num]._axisRange == P_0._axisRange && P_1[num]._axisContribution == P_0._axisContribution)
								{
									num2 = 1547318556;
									continue;
								}
								goto IL_00b7;
							case 1:
								if (P_1[num]._actionId == P_0._actionId)
								{
									return num;
								}
								goto IL_00b7;
							default:
								{
									return -1;
								}
								IL_00b7:
								num++;
								num2 = 1547318558;
								continue;
							}
							break;
						}
					}
				}
			}

			private sealed class MFDjenJfKfRAZRPBzdPMjNGtYXp<T> where T : class
			{
				public Func<T, int> UXnGyhaBOdHCiltKAHIcYFjOmhQd;
			}

			private sealed class XplumIJiwiRCSFeCoelZAMQcEula<T> where T : class
			{
				public MFDjenJfKfRAZRPBzdPMjNGtYXp<T> ZOvXvdgusSsAEFRcEjYmAhgZIsOk;

				public T hzhCQPjLDfvQZlOJUPCTNBARTjC;

				public bool qpnBasKmumxJvAXojypqCeVlgGdI(MhuNWsSNdeFIOPrqUpcotrinQGK P_0)
				{
					return P_0.ehNPUFIecmjcFTrEUzbaEBmcMGD == ZOvXvdgusSsAEFRcEjYmAhgZIsOk.UXnGyhaBOdHCiltKAHIcYFjOmhQd(hzhCQPjLDfvQZlOJUPCTNBARTjC);
				}
			}

			[CompilerGenerated]
			private static Func<InputCategory, int> nKXgrBcsZKCySHzhigYMzeWLUGA;

			[CompilerGenerated]
			private static Func<InputCategory, string> paSavYXwOPYFbXMKViDjXKZbeYR;

			[CompilerGenerated]
			private static Func<InputCategory, IList<InputCategory>, int> aKXpPadCDZCvroqhpkVJHBqbrDy;

			[CompilerGenerated]
			private static Func<InputBehavior, int> dXmBLVsXfwkuKqAoBCdRaQiMSlq;

			[CompilerGenerated]
			private static Func<InputBehavior, string> VbPvJWpLWeAhcraAtEaoEaSNdeZM;

			[CompilerGenerated]
			private static Func<InputBehavior, IList<InputBehavior>, int> EdfaiobnrmupiKSrmqeRFHfxPKV;

			[CompilerGenerated]
			private static Func<InputAction, int> HsSNPecinNYprESgcaMfGteoJrv;

			[CompilerGenerated]
			private static Func<InputAction, string> QflehtVqpdZILYNRdbVUrbZteWd;

			[CompilerGenerated]
			private static Func<InputAction, IList<InputAction>, int> pdbeBLJflAuleKKwcDqDzMgdtgr;

			[CompilerGenerated]
			private static Func<InputMapCategory, int> vUzndQgauZhSPyhTfrQhYNwTGOn;

			[CompilerGenerated]
			private static Func<InputMapCategory, string> PfsauszPfBCfmgocnkdlSnZXtuBf;

			[CompilerGenerated]
			private static Func<InputMapCategory, IList<InputMapCategory>, int> NFiojmeaVhmeBZuGbcZBEKcGWlL;

			[CompilerGenerated]
			private static Func<InputLayout, int> zfsVemDgpXLplgJClEToqPNmCJrc;

			[CompilerGenerated]
			private static Func<InputLayout, string> lacVJtUKNYBYTnJlSeqcfOecAIat;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> vlYsdGxLTzXyXRzfZuONkfZFcjI;

			[CompilerGenerated]
			private static Func<InputLayout, int> NGZXgbICNZzXhFzLfnYHiOUIkSl;

			[CompilerGenerated]
			private static Func<InputLayout, string> afsXdiTuNtYzWftOgajZFCkPkqZ;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> jiYMRYAVJlcIMpurocyMuoZYXlH;

			[CompilerGenerated]
			private static Func<InputLayout, int> gpVrAueaAkHVmjoHiUllHLWnKLf;

			[CompilerGenerated]
			private static Func<InputLayout, string> jDnTyWudgRuaClRHaIielvbXseM;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> JaejdDmABMhHycDjoPvWuTzltkh;

			[CompilerGenerated]
			private static Func<InputLayout, int> pziQWWcDsqRaJHWXaqbyBQUrsdx;

			[CompilerGenerated]
			private static Func<InputLayout, string> bCsEJTgtceyEOfidjUAtIIYQuPTC;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> xgPxLytfTXkJYTQzylChVpFSLOo;

			[CompilerGenerated]
			private static Func<CustomController_Editor, int> RmhbAIFhnXjxpejGEezVDtCdmRu;

			[CompilerGenerated]
			private static Func<CustomController_Editor, string> eNUakuJYtsaHRVCjpeaKEeAIBqG;

			[CompilerGenerated]
			private static Func<CustomController_Editor, IList<CustomController_Editor>, int> TVnBCMAqgOZmAJaWTmWevBrBrpWm;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, int> kcqHpRAQUoNEZCavjmZHMEXcvGm;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, string> YzMbUxXmUovqprgdZXzvumPRLVB;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> ULqCAxaCunKdrPqCHIfdOnlBNzkg;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, int> bZBpeHFLSyyqkTlmRkQBxGQentb;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, string> SeZrbXjWUQETuMTsQgjZhPJFVGv;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> MMbUOtXQRzoHMaNNyiYUgcifEbV;

			[CompilerGenerated]
			private static Func<Player_Editor, int> uQjuXRAYEjeUoNLIBHhmFIvtDmrH;

			[CompilerGenerated]
			private static Func<Player_Editor, string> KjordqIdAtEpLXASmoXpFaOKats;

			[CompilerGenerated]
			private static Func<Player_Editor, IList<Player_Editor>, int> SiGRiuxdJIAlXrCIksmPuDwriIT;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> bykDsyupsdSFmlhAhXIYTnYWswi;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> JKoYDhliTSZhpKdGJqBnmDIZsKw;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> cUAYaosHYqlHhoJayrAvPDtdhyj;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> GGuOJmjtrODRTNzyXqdVdPqkmKG;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> oAXUVFTwJGoaSexuxQLcSUDeEYH;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> bboHFbHaITsTNEGWSCKBxsrlwzFq;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> KCnsjxxbsSubGsZbTQBibfZDhiR;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> YgiEHYamXdmbXNFdvwUTehCADOAA;

			public static UserData VonXDnBtvIWleeWHoCosEZsMrsK(UserData P_0, UserData P_1, bool P_2)
			{
				vDgszJYctlYeDelkuaNEKylbVSB vDgszJYctlYeDelkuaNEKylbVSB2 = default(vDgszJYctlYeDelkuaNEKylbVSB);
				RQzFHtgryVKiyBWACVsEWQfIUaGQ rQzFHtgryVKiyBWACVsEWQfIUaGQ = default(RQzFHtgryVKiyBWACVsEWQfIUaGQ);
				List<MhuNWsSNdeFIOPrqUpcotrinQGK> list2 = default(List<MhuNWsSNdeFIOPrqUpcotrinQGK>);
				int num2 = default(int);
				OpGCrwegZHTgRIPAFgRmhNzbrbI opGCrwegZHTgRIPAFgRmhNzbrbI = default(OpGCrwegZHTgRIPAFgRmhNzbrbI);
				int num3 = default(int);
				RFVNJSrFxlZOJQUSJFQsIcVbhqU rFVNJSrFxlZOJQUSJFQsIcVbhqU = default(RFVNJSrFxlZOJQUSJFQsIcVbhqU);
				List<MhuNWsSNdeFIOPrqUpcotrinQGK> list4 = default(List<MhuNWsSNdeFIOPrqUpcotrinQGK>);
				Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<InputLayout>, InputLayout> func5 = default(Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<InputLayout>, InputLayout>);
				Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<InputLayout>, InputLayout> func6 = default(Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<InputLayout>, InputLayout>);
				Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<InputLayout>, InputLayout> func7 = default(Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<InputLayout>, InputLayout>);
				Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<CustomController_Editor>, CustomController_Editor> func8 = default(Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<CustomController_Editor>, CustomController_Editor>);
				Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMapLayoutManager_RuleSet_Editor>, ControllerMapLayoutManager_RuleSet_Editor> func4 = default(Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMapLayoutManager_RuleSet_Editor>, ControllerMapLayoutManager_RuleSet_Editor>);
				Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMapEnabler_RuleSet_Editor>, ControllerMapEnabler_RuleSet_Editor> func9 = default(Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<ControllerMapEnabler_RuleSet_Editor>, ControllerMapEnabler_RuleSet_Editor>);
				List<MhuNWsSNdeFIOPrqUpcotrinQGK> list3 = default(List<MhuNWsSNdeFIOPrqUpcotrinQGK>);
				dhSPyqTyhAowfJKOyAArxMAotxk dhSPyqTyhAowfJKOyAArxMAotxk2 = default(dhSPyqTyhAowfJKOyAArxMAotxk);
				InputMapCategory inputMapCategory = default(InputMapCategory);
				List<MhuNWsSNdeFIOPrqUpcotrinQGK> list5 = default(List<MhuNWsSNdeFIOPrqUpcotrinQGK>);
				Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<Player_Editor>, Player_Editor> func13 = default(Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<Player_Editor>, Player_Editor>);
				List<MhuNWsSNdeFIOPrqUpcotrinQGK> list = default(List<MhuNWsSNdeFIOPrqUpcotrinQGK>);
				while (true)
				{
					int num = 1121552064;
					while (true)
					{
						object obj3;
						switch (num ^ 0x42D986D0)
						{
						case 10:
							break;
						case 36:
							if (P_1 != null)
							{
								vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.configVars = JsonTools.Clone(P_1.configVars);
								num = 1121552074;
								continue;
							}
							goto case 26;
						case 13:
							GBpOfavtLZbtCAsMEKivJvytnss("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.inputBehaviors, P_2, vDgszJYctlYeDelkuaNEKylbVSB2.rCOYYDgHHhHHvtMfjCenDdQZwcu, (InputBehavior inputBehavior) => inputBehavior.id, (InputBehavior inputBehavior) => inputBehavior.name, delegate(InputBehavior inputBehavior, IList<InputBehavior> list7)
							{
								int num6 = 0;
								while (num6 < list7.Count)
								{
									while (true)
									{
										if (string.Equals(inputBehavior.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
										{
											return num6;
										}
										num6++;
										int num7 = -1408643509;
										while (true)
										{
											switch (num7 ^ -1408643509)
											{
											case 2:
												num7 = -1408643510;
												continue;
											case 1:
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
								return -1;
							}, vDgszJYctlYeDelkuaNEKylbVSB2.VOuXOXDabRlXvTQPJvCCSPUXVxB);
							num = 1121552092;
							continue;
						case 24:
							rQzFHtgryVKiyBWACVsEWQfIUaGQ.KCRiTwViJHANxZIErLrDMwYiMhL = vDgszJYctlYeDelkuaNEKylbVSB2.UPBebojQrOaNPTXQPHBdiDtQiFX;
							GBpOfavtLZbtCAsMEKivJvytnss("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.joystickMaps, P_2, list2, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, rQzFHtgryVKiyBWACVsEWQfIUaGQ.RrYEdzFTOdGtlWNhDcFfcrhYtSsK, rQzFHtgryVKiyBWACVsEWQfIUaGQ.PLwIAywnGXeaEEjWkkLwgeMeroLA);
							num = 1121552085;
							continue;
						case 23:
							num2 = 0;
							num = 1121552113;
							continue;
						case 2:
							GBpOfavtLZbtCAsMEKivJvytnss("Map Category", P_0.mapCategories, P_1?.mapCategories, vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.mapCategories, P_2, vDgszJYctlYeDelkuaNEKylbVSB2.UFfmmpelsjFbWJmEpVbdlOaFeAZD, (InputMapCategory inputMapCategory2) => inputMapCategory2.id, (InputMapCategory inputMapCategory2) => inputMapCategory2.name, delegate(InputMapCategory inputMapCategory2, IList<InputMapCategory> list7)
							{
								int num6 = 0;
								while (true)
								{
									int num7 = 1008908184;
									while (true)
									{
										switch (num7 ^ 0x3C22B799)
										{
										case 2:
											break;
										case 1:
											num7 = 1008908186;
											continue;
										case 0:
											if (string.Equals(inputMapCategory2.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
											{
												return num6;
											}
											num6++;
											num7 = 1008908186;
											continue;
										default:
											if (num6 >= list7.Count)
											{
												return -1;
											}
											goto case 0;
										}
										break;
									}
								}
							}, opGCrwegZHTgRIPAFgRmhNzbrbI.tUFMguTFMGqYyJyuzmmnBQGuxUE);
							num3 = 0;
							num = 1121552086;
							continue;
						case 27:
							rFVNJSrFxlZOJQUSJFQsIcVbhqU.qFUiIUBmnPANbAilZAhlbWWAmVb = vDgszJYctlYeDelkuaNEKylbVSB2;
							rFVNJSrFxlZOJQUSJFQsIcVbhqU.KCRiTwViJHANxZIErLrDMwYiMhL = vDgszJYctlYeDelkuaNEKylbVSB2.eMyHeZSgMURXJfjEoHWIfEghfUj;
							GBpOfavtLZbtCAsMEKivJvytnss("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.mouseMaps, P_2, list4, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, rFVNJSrFxlZOJQUSJFQsIcVbhqU.JWPSCXfWGqSLgmBIZYulvDjhFcS, rFVNJSrFxlZOJQUSJFQsIcVbhqU.DIOZvUYjukzUxmWfTQPqIJJhwdr);
							num = 1121552069;
							continue;
						case 16:
							func5 = null;
							func6 = null;
							func7 = null;
							func8 = null;
							func4 = null;
							func9 = null;
							num = 1121552115;
							continue;
						case 3:
						{
							XvxMlGZRzqwiVnEqjlHWSIHppcb xvxMlGZRzqwiVnEqjlHWSIHppcb = new XvxMlGZRzqwiVnEqjlHWSIHppcb();
							xvxMlGZRzqwiVnEqjlHWSIHppcb.qFUiIUBmnPANbAilZAhlbWWAmVb = vDgszJYctlYeDelkuaNEKylbVSB2;
							xvxMlGZRzqwiVnEqjlHWSIHppcb.KCRiTwViJHANxZIErLrDMwYiMhL = vDgszJYctlYeDelkuaNEKylbVSB2.otLFyvvJVKrPTTjQSHggHDCzBjF;
							GBpOfavtLZbtCAsMEKivJvytnss("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.keyboardMaps, P_2, list3, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, xvxMlGZRzqwiVnEqjlHWSIHppcb.DadfTifqLMzLBHzPBuRrrgbuhMnB, xvxMlGZRzqwiVnEqjlHWSIHppcb.iWoNdGdpDHdQpCcVPGyuSSoRiHg);
							list4 = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							rFVNJSrFxlZOJQUSJFQsIcVbhqU = new RFVNJSrFxlZOJQUSJFQsIcVbhqU();
							num = 1121552075;
							continue;
						}
						case 22:
							GBpOfavtLZbtCAsMEKivJvytnss("Action Category", P_0.actionCategories, P_1?.actionCategories, vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.actionCategories, P_2, vDgszJYctlYeDelkuaNEKylbVSB2.jtnmxUxCMIfWJeMXmRMSWrEsqNY, (InputCategory inputCategory) => inputCategory.id, (InputCategory inputCategory) => inputCategory.name, delegate(InputCategory inputCategory, IList<InputCategory> list7)
							{
								int num6 = 0;
								while (num6 < list7.Count)
								{
									while (true)
									{
										int num7;
										if (string.Equals(inputCategory.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
										{
											num7 = 26276492;
										}
										else
										{
											num6++;
											num7 = 26276495;
										}
										while (true)
										{
											switch (num7 ^ 0x190F28F)
											{
											case 2:
												num7 = 26276494;
												continue;
											case 1:
												break;
											case 3:
												return num6;
											default:
												goto end_IL_0026;
											}
											break;
										}
										continue;
										end_IL_0026:
										break;
									}
								}
								return -1;
							}, vDgszJYctlYeDelkuaNEKylbVSB2.TrucqCVfyuQdUxhxUrlYyzGaali);
							vDgszJYctlYeDelkuaNEKylbVSB2.rCOYYDgHHhHHvtMfjCenDdQZwcu = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							num = 1121552093;
							continue;
						case 8:
							num3++;
							num = 1121552091;
							continue;
						case 20:
							if (P_0 == null)
							{
								throw new ArgumentNullException("orig");
							}
							goto case 29;
						case 17:
							vDgszJYctlYeDelkuaNEKylbVSB2.eMyHeZSgMURXJfjEoHWIfEghfUj = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							num = 1121552079;
							continue;
						case 31:
						{
							List<InputLayout> mouseLayouts = P_0.mouseLayouts;
							List<InputLayout> obj5 = P_1?.mouseLayouts;
							List<InputLayout> mouseLayouts2 = vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.mouseLayouts;
							List<MhuNWsSNdeFIOPrqUpcotrinQGK> eMyHeZSgMURXJfjEoHWIfEghfUj = vDgszJYctlYeDelkuaNEKylbVSB2.eMyHeZSgMURXJfjEoHWIfEghfUj;
							Func<InputLayout, int> func17 = (InputLayout inputLayout) => inputLayout.id;
							Func<InputLayout, string> func18 = (InputLayout inputLayout) => inputLayout.name;
							Func<InputLayout, IList<InputLayout>, int> func19 = delegate(InputLayout inputLayout, IList<InputLayout> list7)
							{
								int num6 = 0;
								while (true)
								{
									int num7;
									int num8;
									if (num6 >= list7.Count)
									{
										num7 = -405359795;
										num8 = num7;
									}
									else
									{
										num7 = -405359796;
										num8 = num7;
									}
									while (true)
									{
										switch (num7 ^ -405359794)
										{
										case 0:
											num7 = -405359796;
											continue;
										case 2:
											if (string.Equals(inputLayout.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
											{
												return num6;
											}
											num6++;
											num7 = -405359793;
											continue;
										case 1:
											break;
										default:
											return -1;
										}
										break;
									}
								}
							};
							if (func5 == null)
							{
								func5 = vDgszJYctlYeDelkuaNEKylbVSB2.gzBUijANCpajSqEqqcQEDOHqHuy;
							}
							GBpOfavtLZbtCAsMEKivJvytnss("Mouse Layout", mouseLayouts, obj5, mouseLayouts2, P_2, eMyHeZSgMURXJfjEoHWIfEghfUj, func17, func18, func19, func5);
							vDgszJYctlYeDelkuaNEKylbVSB2.UPBebojQrOaNPTXQPHBdiDtQiFX = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							List<InputLayout> joystickLayouts = P_0.joystickLayouts;
							List<InputLayout> obj6 = P_1?.joystickLayouts;
							List<InputLayout> joystickLayouts2 = vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.joystickLayouts;
							List<MhuNWsSNdeFIOPrqUpcotrinQGK> uPBebojQrOaNPTXQPHBdiDtQiFX = vDgszJYctlYeDelkuaNEKylbVSB2.UPBebojQrOaNPTXQPHBdiDtQiFX;
							Func<InputLayout, int> func20 = (InputLayout inputLayout) => inputLayout.id;
							Func<InputLayout, string> func21 = (InputLayout inputLayout) => inputLayout.name;
							Func<InputLayout, IList<InputLayout>, int> func22 = delegate(InputLayout inputLayout, IList<InputLayout> list7)
							{
								int num6 = 0;
								while (true)
								{
									int num7;
									int num8;
									if (num6 >= list7.Count)
									{
										num7 = -989946090;
										num8 = num7;
									}
									else
									{
										num7 = -989946093;
										num8 = num7;
									}
									while (true)
									{
										switch (num7 ^ -989946089)
										{
										case 3:
											num7 = -989946093;
											continue;
										case 0:
											break;
										case 2:
											return num6;
										case 4:
											if (!string.Equals(inputLayout.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
											{
												num6++;
												num7 = -989946089;
											}
											else
											{
												num7 = -989946091;
											}
											continue;
										default:
											return -1;
										}
										break;
									}
								}
							};
							if (func6 == null)
							{
								func6 = vDgszJYctlYeDelkuaNEKylbVSB2.WqUAMdZwAmALHDeCeBaHRQWkktk;
							}
							GBpOfavtLZbtCAsMEKivJvytnss("Joystick Layout", joystickLayouts, obj6, joystickLayouts2, P_2, uPBebojQrOaNPTXQPHBdiDtQiFX, func20, func21, func22, func6);
							vDgszJYctlYeDelkuaNEKylbVSB2.ZWOUkpipqSdNFYkZFNgpgNzVKyZ = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							List<InputLayout> customControllerLayouts = P_0.customControllerLayouts;
							List<InputLayout> obj7 = P_1?.customControllerLayouts;
							List<InputLayout> customControllerLayouts2 = vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.customControllerLayouts;
							List<MhuNWsSNdeFIOPrqUpcotrinQGK> zWOUkpipqSdNFYkZFNgpgNzVKyZ = vDgszJYctlYeDelkuaNEKylbVSB2.ZWOUkpipqSdNFYkZFNgpgNzVKyZ;
							Func<InputLayout, int> func23 = (InputLayout inputLayout) => inputLayout.id;
							Func<InputLayout, string> func24 = (InputLayout inputLayout) => inputLayout.name;
							Func<InputLayout, IList<InputLayout>, int> func25 = delegate(InputLayout inputLayout, IList<InputLayout> list7)
							{
								int num6 = 0;
								while (true)
								{
									int num7 = -1205412196;
									while (true)
									{
										switch (num7 ^ -1205412193)
										{
										case 2:
											break;
										case 3:
											num7 = -1205412194;
											continue;
										case 0:
											if (string.Equals(inputLayout.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
											{
												return num6;
											}
											num6++;
											num7 = -1205412194;
											continue;
										default:
											if (num6 >= list7.Count)
											{
												return -1;
											}
											goto case 0;
										}
										break;
									}
								}
							};
							if (func7 == null)
							{
								func7 = vDgszJYctlYeDelkuaNEKylbVSB2.AYdLJRXgDWfxRKtrEHDxQPeuKhZ;
							}
							GBpOfavtLZbtCAsMEKivJvytnss("Custom Controller Layout", customControllerLayouts, obj7, customControllerLayouts2, P_2, zWOUkpipqSdNFYkZFNgpgNzVKyZ, func23, func24, func25, func7);
							vDgszJYctlYeDelkuaNEKylbVSB2.DPeHHHfCnMxihHMRpvTcTtofHYJ = vDgszJYctlYeDelkuaNEKylbVSB2.JkxfPlfjRHlKlrznmsLDKZbZePYl;
							num = 1121552081;
							continue;
						}
						case 30:
						{
							dhSPyqTyhAowfJKOyAArxMAotxk2.qFUiIUBmnPANbAilZAhlbWWAmVb = vDgszJYctlYeDelkuaNEKylbVSB2;
							dhSPyqTyhAowfJKOyAArxMAotxk2.XfMFYPNbBYWiYxGxDZakDleTnIg = inputMapCategory.checkConflictsCategoryIds_orig[num2];
							MhuNWsSNdeFIOPrqUpcotrinQGK mhuNWsSNdeFIOPrqUpcotrinQGK = vDgszJYctlYeDelkuaNEKylbVSB2.UFfmmpelsjFbWJmEpVbdlOaFeAZD.Find(dhSPyqTyhAowfJKOyAArxMAotxk2.FLVXRBXrwRYEHkDjivbuKLxvvMG);
							inputMapCategory.checkConflictsCategoryIds_orig[num2] = mhuNWsSNdeFIOPrqUpcotrinQGK?.ehNPUFIecmjcFTrEUzbaEBmcMGD ?? (-1);
							num = 1121552076;
							continue;
						}
						case 34:
						{
							List<Player_Editor> players = P_0.players;
							List<Player_Editor> obj8 = P_1?.players;
							List<Player_Editor> players2 = vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.players;
							List<MhuNWsSNdeFIOPrqUpcotrinQGK> list6 = list5;
							Func<Player_Editor, int> func26 = (Player_Editor player_Editor) => player_Editor.id;
							Func<Player_Editor, string> func27 = (Player_Editor player_Editor) => player_Editor.name;
							Func<Player_Editor, IList<Player_Editor>, int> func28 = delegate(Player_Editor player_Editor, IList<Player_Editor> list7)
							{
								int num6 = 0;
								while (num6 < list7.Count)
								{
									while (true)
									{
										if (string.Equals(player_Editor.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
										{
											return num6;
										}
										num6++;
										int num7 = -1465843088;
										while (true)
										{
											switch (num7 ^ -1465843087)
											{
											case 0:
												num7 = -1465843085;
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
								return -1;
							};
							if (func13 == null)
							{
								func13 = vDgszJYctlYeDelkuaNEKylbVSB2.gUPDpBtsCsUXuvhJtzbBSeJztSP;
							}
							GBpOfavtLZbtCAsMEKivJvytnss("Player", players, obj8, players2, P_2, list6, func26, func27, func28, func13);
							list3 = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							num = 1121552083;
							continue;
						}
						case 26:
							vDgszJYctlYeDelkuaNEKylbVSB2.jtnmxUxCMIfWJeMXmRMSWrEsqNY = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							num = 1121552070;
							continue;
						case 11:
						{
							int num5;
							if (num3 >= opGCrwegZHTgRIPAFgRmhNzbrbI.NGrXeWBrJVipQrvKdrzgvFBZOLI.Count)
							{
								num = 1121552084;
								num5 = num;
							}
							else
							{
								num = 1121552066;
								num5 = num;
							}
							continue;
						}
						case 1:
						{
							vDgszJYctlYeDelkuaNEKylbVSB2.bxXBAIjNrNDiLSvcpobwxkuZNvXl = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							List<CustomController_Editor> customControllers = P_0.customControllers;
							List<CustomController_Editor> obj2 = P_1?.customControllers;
							List<CustomController_Editor> customControllers2 = vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.customControllers;
							List<MhuNWsSNdeFIOPrqUpcotrinQGK> bxXBAIjNrNDiLSvcpobwxkuZNvXl = vDgszJYctlYeDelkuaNEKylbVSB2.bxXBAIjNrNDiLSvcpobwxkuZNvXl;
							Func<CustomController_Editor, int> func10 = (CustomController_Editor customController_Editor) => customController_Editor.id;
							Func<CustomController_Editor, string> func11 = (CustomController_Editor customController_Editor) => customController_Editor.name;
							Func<CustomController_Editor, IList<CustomController_Editor>, int> func12 = delegate(CustomController_Editor customController_Editor, IList<CustomController_Editor> list7)
							{
								int num6 = 0;
								while (num6 < list7.Count)
								{
									while (true)
									{
										if (string.Equals(customController_Editor.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
										{
											return num6;
										}
										num6++;
										int num7 = -1760794845;
										while (true)
										{
											switch (num7 ^ -1760794846)
											{
											case 0:
												num7 = -1760794848;
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
								return -1;
							};
							if (func8 == null)
							{
								func8 = vDgszJYctlYeDelkuaNEKylbVSB2.iiyiENhBFfOdDjkQyAljnaJxYnr;
							}
							GBpOfavtLZbtCAsMEKivJvytnss("Custom Controller", customControllers, obj2, customControllers2, P_2, bxXBAIjNrNDiLSvcpobwxkuZNvXl, func10, func11, func12, func8);
							vDgszJYctlYeDelkuaNEKylbVSB2.aNnUDGfUfBQaghNCEYarVdhqplX = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							num = 1121552094;
							continue;
						}
						case 6:
							num = 1121552091;
							continue;
						case 12:
							vDgszJYctlYeDelkuaNEKylbVSB2.zAvCIOcMYPmqcDAQowOVcRKFVmm = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							GBpOfavtLZbtCAsMEKivJvytnss("Action", P_0.actions, P_1?.actions, vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.actions, P_2, vDgszJYctlYeDelkuaNEKylbVSB2.zAvCIOcMYPmqcDAQowOVcRKFVmm, (InputAction inputAction) => inputAction.id, (InputAction inputAction) => inputAction.name, delegate(InputAction inputAction, IList<InputAction> list7)
							{
								int num6 = 0;
								while (true)
								{
									int num7 = -64270307;
									while (true)
									{
										switch (num7 ^ -64270308)
										{
										case 3:
											break;
										case 0:
										{
											int num8;
											if (num6 >= list7.Count)
											{
												num7 = -64270312;
												num8 = num7;
											}
											else
											{
												num7 = -64270306;
												num8 = num7;
											}
											continue;
										}
										case 2:
											if (string.Equals(inputAction.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
											{
												return num6;
											}
											num6++;
											num7 = -64270308;
											continue;
										case 1:
											num7 = -64270308;
											continue;
										default:
											return -1;
										}
										break;
									}
								}
							}, vDgszJYctlYeDelkuaNEKylbVSB2.IENiOwbZdMGmYOliwjicfzDIcMp);
							vDgszJYctlYeDelkuaNEKylbVSB2.UFfmmpelsjFbWJmEpVbdlOaFeAZD = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							opGCrwegZHTgRIPAFgRmhNzbrbI = new OpGCrwegZHTgRIPAFgRmhNzbrbI();
							opGCrwegZHTgRIPAFgRmhNzbrbI.qFUiIUBmnPANbAilZAhlbWWAmVb = vDgszJYctlYeDelkuaNEKylbVSB2;
							num = 1121552112;
							continue;
						case 0:
							obj3 = null;
							goto IL_0a0c;
						case 5:
							list = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							num = 1121552095;
							continue;
						case 29:
							P_0 = JsonTools.Clone(P_0);
							if (P_1 != null)
							{
								obj3 = JsonTools.Clone(P_1);
								goto IL_0a0c;
							}
							num = 1121552080;
							continue;
						case 21:
							list2 = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							rQzFHtgryVKiyBWACVsEWQfIUaGQ = new RQzFHtgryVKiyBWACVsEWQfIUaGQ();
							rQzFHtgryVKiyBWACVsEWQfIUaGQ.qFUiIUBmnPANbAilZAhlbWWAmVb = vDgszJYctlYeDelkuaNEKylbVSB2;
							num = 1121552072;
							continue;
						case 35:
							func13 = null;
							vDgszJYctlYeDelkuaNEKylbVSB2 = new vDgszJYctlYeDelkuaNEKylbVSB();
							num = 1121552068;
							continue;
						case 33:
						{
							int num4;
							if (num2 >= inputMapCategory.checkConflictsCategoryIds_orig.Count)
							{
								num = 1121552088;
								num4 = num;
							}
							else
							{
								num = 1121552073;
								num4 = num;
							}
							continue;
						}
						case 14:
						{
							List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = P_0.controllerMapLayoutManagerRuleSets;
							List<ControllerMapLayoutManager_RuleSet_Editor> obj = P_1?.controllerMapLayoutManagerRuleSets;
							List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets2 = vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.controllerMapLayoutManagerRuleSets;
							List<MhuNWsSNdeFIOPrqUpcotrinQGK> aNnUDGfUfBQaghNCEYarVdhqplX = vDgszJYctlYeDelkuaNEKylbVSB2.aNnUDGfUfBQaghNCEYarVdhqplX;
							Func<ControllerMapLayoutManager_RuleSet_Editor, int> func = (ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor) => controllerMapLayoutManager_RuleSet_Editor.id;
							Func<ControllerMapLayoutManager_RuleSet_Editor, string> func2 = (ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor) => controllerMapLayoutManager_RuleSet_Editor.name;
							Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> func3 = delegate(ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor> list7)
							{
								int num6 = 0;
								while (true)
								{
									int num7;
									int num8;
									if (num6 < list7.Count)
									{
										num7 = -882971109;
										num8 = num7;
									}
									else
									{
										num7 = -882971112;
										num8 = num7;
									}
									while (true)
									{
										switch (num7 ^ -882971112)
										{
										case 2:
											num7 = -882971109;
											continue;
										case 3:
											if (string.Equals(controllerMapLayoutManager_RuleSet_Editor.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
											{
												num7 = -882971108;
											}
											else
											{
												num6++;
												num7 = -882971111;
											}
											continue;
										case 1:
											break;
										case 4:
											return num6;
										default:
											return -1;
										}
										break;
									}
								}
							};
							if (func4 == null)
							{
								func4 = vDgszJYctlYeDelkuaNEKylbVSB2.JTPDoNfYtuXEAPILYruKLAVqgBm;
							}
							GBpOfavtLZbtCAsMEKivJvytnss("Layout Manager Set", controllerMapLayoutManagerRuleSets, obj, controllerMapLayoutManagerRuleSets2, P_2, aNnUDGfUfBQaghNCEYarVdhqplX, func, func2, func3, func4);
							vDgszJYctlYeDelkuaNEKylbVSB2.hwHTDZrBttNPFbEjKCrmcOBmynN = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							num = 1121552067;
							continue;
						}
						case 19:
						{
							List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = P_0.controllerMapEnablerRuleSets;
							List<ControllerMapEnabler_RuleSet_Editor> obj4 = P_1?.controllerMapEnablerRuleSets;
							List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets2 = vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.controllerMapEnablerRuleSets;
							List<MhuNWsSNdeFIOPrqUpcotrinQGK> hwHTDZrBttNPFbEjKCrmcOBmynN = vDgszJYctlYeDelkuaNEKylbVSB2.hwHTDZrBttNPFbEjKCrmcOBmynN;
							Func<ControllerMapEnabler_RuleSet_Editor, int> func14 = (ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor) => controllerMapEnabler_RuleSet_Editor.id;
							Func<ControllerMapEnabler_RuleSet_Editor, string> func15 = (ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor) => controllerMapEnabler_RuleSet_Editor.name;
							Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> func16 = delegate(ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor> list7)
							{
								int num6 = 0;
								while (num6 < list7.Count)
								{
									while (true)
									{
										if (string.Equals(controllerMapEnabler_RuleSet_Editor.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
										{
											return num6;
										}
										num6++;
										int num7 = -220351458;
										while (true)
										{
											switch (num7 ^ -220351457)
											{
											case 0:
												num7 = -220351459;
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
								return -1;
							};
							if (func9 == null)
							{
								func9 = vDgszJYctlYeDelkuaNEKylbVSB2.ritObRNBMdQWoxYnKDdJhPJYmPq;
							}
							GBpOfavtLZbtCAsMEKivJvytnss("Controller Map Enabler Set", controllerMapEnablerRuleSets, obj4, controllerMapEnablerRuleSets2, P_2, hwHTDZrBttNPFbEjKCrmcOBmynN, func14, func15, func16, func9);
							num = 1121552089;
							continue;
						}
						case 4:
							vDgszJYctlYeDelkuaNEKylbVSB2.otLFyvvJVKrPTTjQSHggHDCzBjF = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							GBpOfavtLZbtCAsMEKivJvytnss("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.keyboardLayouts, P_2, vDgszJYctlYeDelkuaNEKylbVSB2.otLFyvvJVKrPTTjQSHggHDCzBjF, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list7)
							{
								int num6 = 0;
								while (num6 < list7.Count)
								{
									while (true)
									{
										if (string.Equals(inputLayout.name, list7[num6].name, StringComparison.OrdinalIgnoreCase))
										{
											return num6;
										}
										num6++;
										int num7 = 317572904;
										while (true)
										{
											switch (num7 ^ 0x12EDC72A)
											{
											case 0:
												num7 = 317572907;
												continue;
											case 1:
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
								return -1;
							}, vDgszJYctlYeDelkuaNEKylbVSB2.CTrnFDXhRWYXeRESnugbEblPuiA);
							num = 1121552065;
							continue;
						case 9:
							list5 = new List<MhuNWsSNdeFIOPrqUpcotrinQGK>();
							num = 1121552114;
							continue;
						case 32:
							opGCrwegZHTgRIPAFgRmhNzbrbI.NGrXeWBrJVipQrvKdrzgvFBZOLI = new List<int>();
							num = 1121552082;
							continue;
						case 18:
						{
							int index = opGCrwegZHTgRIPAFgRmhNzbrbI.NGrXeWBrJVipQrvKdrzgvFBZOLI[num3];
							inputMapCategory = vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.mapCategories[index];
							num = 1121552071;
							continue;
						}
						case 25:
							dhSPyqTyhAowfJKOyAArxMAotxk2 = new dhSPyqTyhAowfJKOyAArxMAotxk();
							num = 1121552087;
							continue;
						case 7:
							dhSPyqTyhAowfJKOyAArxMAotxk2.EedWArVPGOkhrrglxdgkNqWHCvhE = opGCrwegZHTgRIPAFgRmhNzbrbI;
							num = 1121552078;
							continue;
						case 28:
							num2++;
							num = 1121552113;
							continue;
						default:
							{
								ruAAqgAhggIYmWJmtWDXQMRCPJm ruAAqgAhggIYmWJmtWDXQMRCPJm2 = new ruAAqgAhggIYmWJmtWDXQMRCPJm();
								ruAAqgAhggIYmWJmtWDXQMRCPJm2.qFUiIUBmnPANbAilZAhlbWWAmVb = vDgszJYctlYeDelkuaNEKylbVSB2;
								ruAAqgAhggIYmWJmtWDXQMRCPJm2.KCRiTwViJHANxZIErLrDMwYiMhL = vDgszJYctlYeDelkuaNEKylbVSB2.ZWOUkpipqSdNFYkZFNgpgNzVKyZ;
								GBpOfavtLZbtCAsMEKivJvytnss("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv.customControllerMaps, P_2, list, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, ruAAqgAhggIYmWJmtWDXQMRCPJm2.gnoveLzvKHCUbPugcmTUYLsaMOV, ruAAqgAhggIYmWJmtWDXQMRCPJm2.QjbmFftYsllPUTFJhcdJCCmzjmPz);
								return vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv;
							}
							IL_0a0c:
							P_1 = (UserData)obj3;
							vDgszJYctlYeDelkuaNEKylbVSB2.gOEbMJdszjQGVnFGNAMUgiaelAsv = (P_2 ? P_0 : new UserData(init: false));
							num = 1121552116;
							continue;
						}
						break;
					}
				}
			}

			[Conditional("DEBUG_IMPORT")]
			private static void QNRAPCjSmXxIEjzhwknKvceDeAGi(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void zLsFHNesqsGCpHNZSkhdBdStDvNb<T>(IList<T> P_0, IList<T> P_1, IList<T> P_2, Func<T, IList<T>, int> P_3)
			{
				int num = 0;
				T val = default(T);
				int num5 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num2;
					int num3;
					if (num < P_0.Count)
					{
						num2 = -1336386588;
						num3 = num2;
					}
					else
					{
						num2 = -1336386579;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1336386579)
						{
						case 8:
							num2 = -1336386588;
							continue;
						default:
							return;
						case 9:
							P_2.Add(P_0[num]);
							num2 = -1336386585;
							continue;
						case 2:
							P_2.Add(val);
							num2 = -1336386580;
							continue;
						case 0:
							if (P_1 != null)
							{
								num5 = 0;
								num2 = -1336386586;
								continue;
							}
							return;
						case 4:
							val = P_1[num5];
							num4 = P_3(val, P_2);
							num2 = -1336386581;
							continue;
						case 7:
						{
							int num6;
							if (num5 < P_1.Count)
							{
								num2 = -1336386583;
								num6 = num2;
							}
							else
							{
								num2 = -1336386578;
								num6 = num2;
							}
							continue;
						}
						case 1:
							num5++;
							num2 = -1336386582;
							continue;
						case 5:
							break;
						case 11:
							num2 = -1336386582;
							continue;
						case 6:
							if (num4 >= 0)
							{
								P_2[num4] = val;
								num2 = -1336386580;
								continue;
							}
							goto case 2;
						case 10:
							num++;
							num2 = -1336386584;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}

			private static void GBpOfavtLZbtCAsMEKivJvytnss<T>(string P_0, IList<T> P_1, IList<T> P_2, IList<T> P_3, bool P_4, List<MhuNWsSNdeFIOPrqUpcotrinQGK> P_5, Func<T, int> P_6, Func<T, string> P_7, Func<T, IList<T>, int> P_8, Func<WWUpfvqQFZlIEoRQvLsKEixNqFE<T>, T> P_9) where T : class
			{
				MFDjenJfKfRAZRPBzdPMjNGtYXp<T> mFDjenJfKfRAZRPBzdPMjNGtYXp = new MFDjenJfKfRAZRPBzdPMjNGtYXp<T>();
				mFDjenJfKfRAZRPBzdPMjNGtYXp.UXnGyhaBOdHCiltKAHIcYFjOmhQd = P_6;
				int num = 0;
				int num2 = default(int);
				T val = default(T);
				XplumIJiwiRCSFeCoelZAMQcEula<T> xplumIJiwiRCSFeCoelZAMQcEula = default(XplumIJiwiRCSFeCoelZAMQcEula<T>);
				T val2 = default(T);
				string text = default(string);
				T finalItem = default(T);
				while (true)
				{
					int num3;
					if (num >= P_1.Count)
					{
						if (P_2 != null)
						{
							num2 = 0;
							num3 = 1672996406;
							goto IL_001c;
						}
						break;
					}
					goto IL_0266;
					IL_0266:
					val = P_1[num];
					num3 = 1672996400;
					goto IL_001c;
					IL_001c:
					while (true)
					{
						object obj;
						string text2;
						switch (num3 ^ 0x63B7E63B)
						{
						case 9:
							num3 = 1672996405;
							continue;
						default:
							return;
						case 7:
							P_5.Find(xplumIJiwiRCSFeCoelZAMQcEula.qpnBasKmumxJvAXojypqCeVlgGdI).XfMFYPNbBYWiYxGxDZakDleTnIg = mFDjenJfKfRAZRPBzdPMjNGtYXp.UXnGyhaBOdHCiltKAHIcYFjOmhQd(val2);
							num3 = 1672996401;
							continue;
						case 10:
							text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
							num3 = 1672996415;
							continue;
						case 15:
							break;
						case 4:
							Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
							num3 = 1672996410;
							continue;
						case 12:
							obj = "";
							goto IL_014f;
						case 1:
							num2++;
							num3 = 1672996406;
							continue;
						case 2:
						{
							T arg2 = P_9(new WWUpfvqQFZlIEoRQvLsKEixNqFE<T>(val, null, MhuNWsSNdeFIOPrqUpcotrinQGK.xcbwZwGvfnVcagdGpAqUoxbbmBe.PcvdaPGLraDcVpVTDFerAnafHgWK, P_3, isCollision: false));
							P_5.Add(new MhuNWsSNdeFIOPrqUpcotrinQGK(mFDjenJfKfRAZRPBzdPMjNGtYXp.UXnGyhaBOdHCiltKAHIcYFjOmhQd(val), -1, mFDjenJfKfRAZRPBzdPMjNGtYXp.UXnGyhaBOdHCiltKAHIcYFjOmhQd(arg2)));
							num3 = 1672996395;
							continue;
						}
						case 5:
							if (!string.IsNullOrEmpty(P_7(val2)))
							{
								obj = "\"" + P_7(val2) + "\"";
								goto IL_014f;
							}
							num3 = 1672996407;
							continue;
						case 13:
							goto IL_0203;
						case 11:
							if (P_4)
							{
								P_5.Add(new MhuNWsSNdeFIOPrqUpcotrinQGK(mFDjenJfKfRAZRPBzdPMjNGtYXp.UXnGyhaBOdHCiltKAHIcYFjOmhQd(val), -1, mFDjenJfKfRAZRPBzdPMjNGtYXp.UXnGyhaBOdHCiltKAHIcYFjOmhQd(val)));
								num3 = 1672996395;
								continue;
							}
							goto case 2;
						case 16:
							num++;
							num3 = 1672996404;
							continue;
						case 14:
							goto IL_0266;
						case 0:
						{
							T arg = P_9(new WWUpfvqQFZlIEoRQvLsKEixNqFE<T>(val2, null, MhuNWsSNdeFIOPrqUpcotrinQGK.xcbwZwGvfnVcagdGpAqUoxbbmBe.XfMFYPNbBYWiYxGxDZakDleTnIg, P_3, isCollision: false));
							P_5.Add(new MhuNWsSNdeFIOPrqUpcotrinQGK(-1, mFDjenJfKfRAZRPBzdPMjNGtYXp.UXnGyhaBOdHCiltKAHIcYFjOmhQd(val2), mFDjenJfKfRAZRPBzdPMjNGtYXp.UXnGyhaBOdHCiltKAHIcYFjOmhQd(arg)));
							num3 = 1672996414;
							continue;
						}
						case 6:
							xplumIJiwiRCSFeCoelZAMQcEula.hzhCQPjLDfvQZlOJUPCTNBARTjC = P_9(new WWUpfvqQFZlIEoRQvLsKEixNqFE<T>(val2, finalItem, MhuNWsSNdeFIOPrqUpcotrinQGK.xcbwZwGvfnVcagdGpAqUoxbbmBe.XfMFYPNbBYWiYxGxDZakDleTnIg, P_3, isCollision: true));
							num3 = 1672996412;
							continue;
						case 3:
						{
							val2 = P_2[num2];
							int num4 = P_8(val2, P_3);
							if (num4 >= 0)
							{
								xplumIJiwiRCSFeCoelZAMQcEula = new XplumIJiwiRCSFeCoelZAMQcEula<T>();
								xplumIJiwiRCSFeCoelZAMQcEula.ZOvXvdgusSsAEFRcEjYmAhgZIsOk = mFDjenJfKfRAZRPBzdPMjNGtYXp;
								finalItem = P_3[num4];
								num3 = 1672996413;
								continue;
							}
							goto case 0;
						}
						case 8:
							return;
							IL_014f:
							text2 = (string)obj;
							Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
							num3 = 1672996410;
							continue;
						}
						break;
						IL_0203:
						int num5;
						if (num2 < P_2.Count)
						{
							num3 = 1672996408;
							num5 = num3;
						}
						else
						{
							num3 = 1672996403;
							num5 = num3;
						}
					}
				}
			}

			[CompilerGenerated]
			private static int SpwUPgYMgoHPjJXricOovWptzzvg(InputCategory P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string hkIqnSwpAVFnVlQilaPfEluWyYW(InputCategory P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int fcGjtmvRRFoSRMSpHznbRBrgHFI(InputCategory P_0, IList<InputCategory> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						int num2;
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							num2 = 26276492;
						}
						else
						{
							num++;
							num2 = 26276495;
						}
						while (true)
						{
							switch (num2 ^ 0x190F28F)
							{
							case 2:
								num2 = 26276494;
								continue;
							case 1:
								break;
							case 3:
								return num;
							default:
								goto end_IL_0026;
							}
							break;
						}
						continue;
						end_IL_0026:
						break;
					}
				}
				return -1;
			}

			[CompilerGenerated]
			private static int XgnrubLaUhMEIzAtEBpcUfkUcnIc(InputBehavior P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string PbCXoOUiMLwcSFhmHpxgiiisxbp(InputBehavior P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int uJIBHgLqNPsSqTUPrveCyVDzktn(InputBehavior P_0, IList<InputBehavior> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							return num;
						}
						num++;
						int num2 = -1408643509;
						while (true)
						{
							switch (num2 ^ -1408643509)
							{
							case 2:
								num2 = -1408643510;
								continue;
							case 1:
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
				return -1;
			}

			[CompilerGenerated]
			private static int rKzqkfYmubOdcSICoYEAGHNFrwq(InputAction P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string tvmtTAZSXhqYDqlSJOyhKSdotiv(InputAction P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int gXEOkMmKDVrHAbEvvubctpPBFZE(InputAction P_0, IList<InputAction> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = -64270307;
					while (true)
					{
						switch (num2 ^ -64270308)
						{
						case 3:
							break;
						case 0:
						{
							int num3;
							if (num >= P_1.Count)
							{
								num2 = -64270312;
								num3 = num2;
							}
							else
							{
								num2 = -64270306;
								num3 = num2;
							}
							continue;
						}
						case 2:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = -64270308;
							continue;
						case 1:
							num2 = -64270308;
							continue;
						default:
							return -1;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int muiIbPBOHEeliXGzSgJRazwLRqg(InputMapCategory P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string gyKMlqwqaGSTilXtpEwsFjMfnIo(InputMapCategory P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int VfeanqnyeXckoqCyhiEPeogjcVL(InputMapCategory P_0, IList<InputMapCategory> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = 1008908184;
					while (true)
					{
						switch (num2 ^ 0x3C22B799)
						{
						case 2:
							break;
						case 1:
							num2 = 1008908186;
							continue;
						case 0:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = 1008908186;
							continue;
						default:
							if (num >= P_1.Count)
							{
								return -1;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int RieIKMWmMiMYvohopZyDxMZBgOr(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string IUJOXynwMjDjiWZGqGQdyCFqsNQ(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int iuBcFnqjROGslBatoPHFNwdnFyUl(InputLayout P_0, IList<InputLayout> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							return num;
						}
						num++;
						int num2 = 317572904;
						while (true)
						{
							switch (num2 ^ 0x12EDC72A)
							{
							case 0:
								num2 = 317572907;
								continue;
							case 1:
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
				return -1;
			}

			[CompilerGenerated]
			private static int sBvkLbcpBpmqxNYibwteMLPczBz(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string HYhXZqsjeEdoCLkQToHyIkwsydm(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int rDfIjUOkTBjXFZjPKRXwSfHTCQo(InputLayout P_0, IList<InputLayout> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= P_1.Count)
					{
						num2 = -405359795;
						num3 = num2;
					}
					else
					{
						num2 = -405359796;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -405359794)
						{
						case 0:
							num2 = -405359796;
							continue;
						case 2:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = -405359793;
							continue;
						case 1:
							break;
						default:
							return -1;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int wqjCBbJtiDEIGCZpYrftyJCusHd(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string AFoIDuWqdwaIJDuILwBNqtPfWXk(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int RSjnpWDuctmivAryQwAlmvsabyU(InputLayout P_0, IList<InputLayout> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= P_1.Count)
					{
						num2 = -989946090;
						num3 = num2;
					}
					else
					{
						num2 = -989946093;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -989946089)
						{
						case 3:
							num2 = -989946093;
							continue;
						case 0:
							break;
						case 2:
							return num;
						case 4:
							if (!string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								num++;
								num2 = -989946089;
							}
							else
							{
								num2 = -989946091;
							}
							continue;
						default:
							return -1;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int mMJWoUvxGjLupqsPhcyMuqKMUJf(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string mhInREzanemGhokXKiYpfBGvPjV(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int UyYkUeGHUOeaFsOWaukuYNpoEDjI(InputLayout P_0, IList<InputLayout> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = -1205412196;
					while (true)
					{
						switch (num2 ^ -1205412193)
						{
						case 2:
							break;
						case 3:
							num2 = -1205412194;
							continue;
						case 0:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = -1205412194;
							continue;
						default:
							if (num >= P_1.Count)
							{
								return -1;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int fdEtDypFWUjgsDyirSccVLzsCqQ(CustomController_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string hUXkcnlERDrbxOuAIdnwQVgVUJW(CustomController_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int zlsFtaeNEaQvcqPpeyujBTUfDwjj(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							return num;
						}
						num++;
						int num2 = -1760794845;
						while (true)
						{
							switch (num2 ^ -1760794846)
							{
							case 0:
								num2 = -1760794848;
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
				return -1;
			}

			[CompilerGenerated]
			private static int OKSLxNspeDaiUtnPwKKsbEDZQsC(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string nHFXkIRQnpxoxDBUodyMjueZflL(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int iFFdkOAVAZgMjAeHdnjhbpgnhaQU(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < P_1.Count)
					{
						num2 = -882971109;
						num3 = num2;
					}
					else
					{
						num2 = -882971112;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -882971112)
						{
						case 2:
							num2 = -882971109;
							continue;
						case 3:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								num2 = -882971108;
								continue;
							}
							num++;
							num2 = -882971111;
							continue;
						case 1:
							break;
						case 4:
							return num;
						default:
							return -1;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int CcNDDaSAaWlpwmdlgpvaWBysLyM(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string mdynIyhoPIglBBKQXdjiDBrLdeu(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int ZvBwGGztNpLJcHMjihINDYgcGKR(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							return num;
						}
						num++;
						int num2 = -220351458;
						while (true)
						{
							switch (num2 ^ -220351457)
							{
							case 0:
								num2 = -220351459;
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
				return -1;
			}

			[CompilerGenerated]
			private static int vfFhXuNcbrRTSnZkPhgXNEsWcVj(Player_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string PsxIPzfeoigjfiBZzmUnYZoMhFm(Player_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int NKBVzlBulJhLDjMGihbspOEZAvd(Player_Editor P_0, IList<Player_Editor> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							return num;
						}
						num++;
						int num2 = -1465843088;
						while (true)
						{
							switch (num2 ^ -1465843087)
							{
							case 0:
								num2 = -1465843085;
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
				return -1;
			}

			[CompilerGenerated]
			private static int ImMMlhxozcKPsFPGOMtNnpGTEGR(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string lNSOiwvfNjeoEcSzwFfNpoGbCkOs(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int YIIAliQorDmUHFkGYOZGTTEXuWg(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string TSjeXxFVdZbqJfUGwLQvkyuBMiK(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int ddGCxswcQipcflgQFOOaieNhgjXB(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string VgCVETLEeHexHsnNWVTpKgyYEQH(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int hSptrrgscuSXLPlPyJDlxruYrgn(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string ctYXJZKbVLdfbDwOiiUvOIDjTEZN(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}
		}

		private sealed class DnWNkxKGGbbFZiNhCMLPORqMHtC : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public string JVLDNyGwHUmytBYkmhDmirmDmexz;

			public string mroBMnpLwxbiAaSJwonEBCTLKqFQ;

			public int PSmjXiTtTWKPkmLbUbHkvOzjvZk;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					goto IL_0023;
				}
				goto IL_0087;
				IL_0028:
				int num;
				DnWNkxKGGbbFZiNhCMLPORqMHtC dnWNkxKGGbbFZiNhCMLPORqMHtC = default(DnWNkxKGGbbFZiNhCMLPORqMHtC);
				while (true)
				{
					switch (num ^ -1726171125)
					{
					case 5:
						break;
					case 4:
						dnWNkxKGGbbFZiNhCMLPORqMHtC.JVLDNyGwHUmytBYkmhDmirmDmexz = mroBMnpLwxbiAaSJwonEBCTLKqFQ;
						num = -1726171126;
						continue;
					case 3:
						dnWNkxKGGbbFZiNhCMLPORqMHtC.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -1726171121;
						continue;
					case 6:
						dnWNkxKGGbbFZiNhCMLPORqMHtC = this;
						num = -1726171125;
						continue;
					case 0:
						num = -1726171121;
						continue;
					case 2:
						goto IL_0087;
					default:
						return dnWNkxKGGbbFZiNhCMLPORqMHtC;
					}
					break;
				}
				goto IL_0023;
				IL_0087:
				dnWNkxKGGbbFZiNhCMLPORqMHtC = new DnWNkxKGGbbFZiNhCMLPORqMHtC(0);
				num = -1726171128;
				goto IL_0028;
				IL_0023:
				num = -1726171123;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = -1687845732;
					while (true)
					{
						switch (num2 ^ -1687845736)
						{
						case 6:
							break;
						case 8:
							PSmjXiTtTWKPkmLbUbHkvOzjvZk++;
							num2 = -1687845736;
							continue;
						case 2:
							num2 = -1687845736;
							continue;
						case 3:
							return true;
						case 7:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories[PSmjXiTtTWKPkmLbUbHkvOzjvZk].tag.Equals(JVLDNyGwHUmytBYkmhDmirmDmexz, StringComparison.OrdinalIgnoreCase))
							{
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories[PSmjXiTtTWKPkmLbUbHkvOzjvZk];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = -1687845733;
								continue;
							}
							goto case 8;
						case 10:
							num2 = -1687845731;
							continue;
						case 1:
							if (JVLDNyGwHUmytBYkmhDmirmDmexz != null && !(JVLDNyGwHUmytBYkmhDmirmDmexz == string.Empty) && syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories != null)
							{
								PSmjXiTtTWKPkmLbUbHkvOzjvZk = 0;
								num2 = -1687845734;
								continue;
							}
							goto default;
						case 0:
						{
							int num3;
							if (PSmjXiTtTWKPkmLbUbHkvOzjvZk < syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories.Count)
							{
								num2 = -1687845729;
								num3 = num2;
							}
							else
							{
								num2 = -1687845731;
								num3 = num2;
							}
							continue;
						}
						case 4:
							switch (num)
							{
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = -1687845744;
								continue;
							default:
								num2 = -1687845742;
								continue;
							case 0:
								break;
							}
							goto case 9;
						case 9:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							num2 = -1687845735;
							continue;
						default:
							return false;
						}
						break;
					}
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public DnWNkxKGGbbFZiNhCMLPORqMHtC(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class DQbFTPIHgeborXIsDlmNwibFUAVb : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int ZuNkwfSRMbmzFVdbHjzFDuIxWOr;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					goto IL_001c;
				}
				goto IL_004e;
				IL_004e:
				DQbFTPIHgeborXIsDlmNwibFUAVb dQbFTPIHgeborXIsDlmNwibFUAVb = new DQbFTPIHgeborXIsDlmNwibFUAVb(0);
				dQbFTPIHgeborXIsDlmNwibFUAVb.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				int num = -1252720666;
				goto IL_0021;
				IL_001c:
				num = -1252720668;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ -1252720667)
					{
					case 0:
						break;
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						dQbFTPIHgeborXIsDlmNwibFUAVb = this;
						num = -1252720666;
						continue;
					case 2:
						goto IL_004e;
					default:
						return dQbFTPIHgeborXIsDlmNwibFUAVb;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				default:
					num = -990989174;
					goto IL_001a;
				case 0:
					goto IL_0102;
				case 1:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = -990989180;
						goto IL_001a;
					}
					IL_001a:
					while (true)
					{
						switch (num ^ -990989171)
						{
						case 0:
							break;
						case 2:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories[ZuNkwfSRMbmzFVdbHjzFDuIxWOr];
							num = -990989173;
							continue;
						case 6:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							num = -990989179;
							continue;
						case 3:
							goto IL_0083;
						case 7:
							num = -990989175;
							continue;
						case 1:
							goto IL_00b9;
						case 9:
							ZuNkwfSRMbmzFVdbHjzFDuIxWOr++;
							num = -990989170;
							continue;
						case 5:
							goto IL_0102;
						case 8:
							return true;
						default:
							goto end_IL_0008;
						}
						break;
						IL_00b9:
						int num2;
						if (!syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories[ZuNkwfSRMbmzFVdbHjzFDuIxWOr].userAssignable)
						{
							num = -990989180;
							num2 = num;
						}
						else
						{
							num = -990989169;
							num2 = num;
						}
						continue;
						IL_0083:
						int num3;
						if (ZuNkwfSRMbmzFVdbHjzFDuIxWOr >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories.Count)
						{
							num = -990989175;
							num3 = num;
						}
						else
						{
							num = -990989172;
							num3 = num;
						}
					}
					goto default;
					IL_0102:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories == null)
					{
						break;
					}
					ZuNkwfSRMbmzFVdbHjzFDuIxWOr = 0;
					num = -990989170;
					goto IL_001a;
					end_IL_0008:
					break;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public DQbFTPIHgeborXIsDlmNwibFUAVb(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class jgRgNCWeSnjPQaOkhGSWjyeHNwQh : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public string JVLDNyGwHUmytBYkmhDmirmDmexz;

			public string mroBMnpLwxbiAaSJwonEBCTLKqFQ;

			public int AOvPuJJImAsLKkhEzRBiwNLxqce;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					goto IL_001c;
				}
				goto IL_0042;
				IL_0042:
				jgRgNCWeSnjPQaOkhGSWjyeHNwQh jgRgNCWeSnjPQaOkhGSWjyeHNwQh2 = new jgRgNCWeSnjPQaOkhGSWjyeHNwQh(0);
				jgRgNCWeSnjPQaOkhGSWjyeHNwQh2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				int num = 822356134;
				goto IL_0021;
				IL_001c:
				num = 822356129;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x310428A2)
					{
					case 2:
						break;
					case 1:
						goto IL_0042;
					case 0:
						num = 822356134;
						continue;
					case 3:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						jgRgNCWeSnjPQaOkhGSWjyeHNwQh2 = this;
						num = 822356130;
						continue;
					default:
						jgRgNCWeSnjPQaOkhGSWjyeHNwQh2.JVLDNyGwHUmytBYkmhDmirmDmexz = mroBMnpLwxbiAaSJwonEBCTLKqFQ;
						return jgRgNCWeSnjPQaOkhGSWjyeHNwQh2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = -268426545;
					while (true)
					{
						switch (num2 ^ -268426550)
						{
						case 3:
							break;
						case 5:
							switch (num)
							{
							default:
								num2 = -268426550;
								continue;
							case 0:
								break;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = -268426557;
								continue;
							}
							goto case 2;
						case 0:
							num2 = -268426558;
							continue;
						case 9:
							AOvPuJJImAsLKkhEzRBiwNLxqce++;
							num2 = -268426546;
							continue;
						case 1:
							if (!(JVLDNyGwHUmytBYkmhDmirmDmexz == string.Empty) && syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories != null)
							{
								AOvPuJJImAsLKkhEzRBiwNLxqce = 0;
								num2 = -268426546;
								continue;
							}
							goto default;
						case 6:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories[AOvPuJJImAsLKkhEzRBiwNLxqce].userAssignable && syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories[AOvPuJJImAsLKkhEzRBiwNLxqce].tag.Equals(JVLDNyGwHUmytBYkmhDmirmDmexz, StringComparison.OrdinalIgnoreCase))
							{
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories[AOvPuJJImAsLKkhEzRBiwNLxqce];
								num2 = -268426547;
								continue;
							}
							goto case 9;
						case 2:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							int num4;
							if (JVLDNyGwHUmytBYkmhDmirmDmexz == null)
							{
								num2 = -268426558;
								num4 = num2;
							}
							else
							{
								num2 = -268426549;
								num4 = num2;
							}
							continue;
						}
						case 7:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 4:
						{
							int num3;
							if (AOvPuJJImAsLKkhEzRBiwNLxqce < syCPfFbHYMDOvEPjTnPLBqiOhsPv.mapCategories.Count)
							{
								num2 = -268426548;
								num3 = num2;
							}
							else
							{
								num2 = -268426558;
								num3 = num2;
							}
							continue;
						}
						default:
							return false;
						}
						break;
					}
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public jgRgNCWeSnjPQaOkhGSWjyeHNwQh(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class nKUTaDZGHUIFIUfvrsTSKGIStns : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public string JVLDNyGwHUmytBYkmhDmirmDmexz;

			public string mroBMnpLwxbiAaSJwonEBCTLKqFQ;

			public int GbrRRGsNcyFRLJzpJvBrBHZZvbz;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
				{
					goto IL_0012;
				}
				goto IL_003c;
				IL_0012:
				int num = -1938119526;
				goto IL_0017;
				IL_0017:
				nKUTaDZGHUIFIUfvrsTSKGIStns nKUTaDZGHUIFIUfvrsTSKGIStns2 = default(nKUTaDZGHUIFIUfvrsTSKGIStns);
				while (true)
				{
					switch (num ^ -1938119527)
					{
					case 0:
						break;
					case 2:
						goto IL_003c;
					case 5:
						nKUTaDZGHUIFIUfvrsTSKGIStns2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -1938119523;
						continue;
					case 3:
						goto IL_005d;
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						nKUTaDZGHUIFIUfvrsTSKGIStns2 = this;
						num = -1938119523;
						continue;
					default:
						nKUTaDZGHUIFIUfvrsTSKGIStns2.JVLDNyGwHUmytBYkmhDmirmDmexz = mroBMnpLwxbiAaSJwonEBCTLKqFQ;
						return nKUTaDZGHUIFIUfvrsTSKGIStns2;
					}
					break;
					IL_005d:
					int num2;
					if (isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
					{
						num = -1938119525;
						num2 = num;
					}
					else
					{
						num = -1938119528;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_003c:
				nKUTaDZGHUIFIUfvrsTSKGIStns2 = new nKUTaDZGHUIFIUfvrsTSKGIStns(0);
				num = -1938119524;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 0:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					if (JVLDNyGwHUmytBYkmhDmirmDmexz == null || JVLDNyGwHUmytBYkmhDmirmDmexz == string.Empty || syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories == null)
					{
						break;
					}
					GbrRRGsNcyFRLJzpJvBrBHZZvbz = 0;
					num = 871145629;
					goto IL_001f;
				case 1:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 871145630;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x33ECA09F)
						{
						case 0:
							num = 871145627;
							continue;
						case 4:
							break;
						case 1:
							GbrRRGsNcyFRLJzpJvBrBHZZvbz++;
							num = 871145629;
							continue;
						case 2:
							goto IL_00a4;
						case 3:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories[GbrRRGsNcyFRLJzpJvBrBHZZvbz].tag.Equals(JVLDNyGwHUmytBYkmhDmirmDmexz, StringComparison.OrdinalIgnoreCase))
							{
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories[GbrRRGsNcyFRLJzpJvBrBHZZvbz];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							}
							goto case 1;
						default:
							goto end_IL_0008;
						}
						break;
						IL_00a4:
						int num2;
						if (GbrRRGsNcyFRLJzpJvBrBHZZvbz >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories.Count)
						{
							num = 871145626;
							num2 = num;
						}
						else
						{
							num = 871145628;
							num2 = num;
						}
					}
					goto case 0;
					end_IL_0008:
					break;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public nKUTaDZGHUIFIUfvrsTSKGIStns(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class DVdYLLtCmywgomAsLMvrUxzpkId : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int lIekYawcbGeazlnTxPCDDczZxEG;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				DVdYLLtCmywgomAsLMvrUxzpkId dVdYLLtCmywgomAsLMvrUxzpkId;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					dVdYLLtCmywgomAsLMvrUxzpkId = this;
					goto IL_0025;
				}
				goto IL_004e;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ 0x7EC57EE1)
					{
					case 2:
						break;
					case 1:
						num = 2126872289;
						continue;
					case 3:
						goto IL_004e;
					default:
						return dVdYLLtCmywgomAsLMvrUxzpkId;
					}
					break;
				}
				goto IL_0025;
				IL_004e:
				dVdYLLtCmywgomAsLMvrUxzpkId = new DVdYLLtCmywgomAsLMvrUxzpkId(0);
				dVdYLLtCmywgomAsLMvrUxzpkId.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = 2126872289;
				goto IL_002a;
				IL_0025:
				num = 2126872288;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = -133130423;
					while (true)
					{
						switch (num2 ^ -133130431)
						{
						case 0:
							break;
						case 8:
							switch (num)
							{
							default:
								num2 = -133130425;
								continue;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = -133130432;
								continue;
							case 0:
								break;
							}
							goto case 3;
						case 5:
						{
							int num4;
							if (lIekYawcbGeazlnTxPCDDczZxEG < syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories.Count)
							{
								num2 = -133130427;
								num4 = num2;
							}
							else
							{
								num2 = -133130424;
								num4 = num2;
							}
							continue;
						}
						case 7:
							return true;
						case 3:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							int num3;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories == null)
							{
								num2 = -133130424;
								num3 = num2;
							}
							else
							{
								num2 = -133130429;
								num3 = num2;
							}
							continue;
						}
						case 6:
							num2 = -133130424;
							continue;
						case 10:
							num2 = -133130428;
							continue;
						case 2:
							lIekYawcbGeazlnTxPCDDczZxEG = 0;
							num2 = -133130421;
							continue;
						case 4:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories[lIekYawcbGeazlnTxPCDDczZxEG].userAssignable)
							{
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories[lIekYawcbGeazlnTxPCDDczZxEG];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = -133130426;
								continue;
							}
							goto case 1;
						case 1:
							lIekYawcbGeazlnTxPCDDczZxEG++;
							num2 = -133130428;
							continue;
						default:
							return false;
						}
						break;
					}
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public DVdYLLtCmywgomAsLMvrUxzpkId(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class dLgopYYCyWelwmktciUIgoJBlls : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public string JVLDNyGwHUmytBYkmhDmirmDmexz;

			public string mroBMnpLwxbiAaSJwonEBCTLKqFQ;

			public int GXvziLknNGVrIIBwDhbLbJqdCioF;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				dLgopYYCyWelwmktciUIgoJBlls dLgopYYCyWelwmktciUIgoJBlls2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					dLgopYYCyWelwmktciUIgoJBlls2 = this;
				}
				else
				{
					while (true)
					{
						dLgopYYCyWelwmktciUIgoJBlls2 = new dLgopYYCyWelwmktciUIgoJBlls(0);
						dLgopYYCyWelwmktciUIgoJBlls2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = -1613613868;
						while (true)
						{
							switch (num ^ -1613613866)
							{
							case 0:
								num = -1613613865;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				dLgopYYCyWelwmktciUIgoJBlls2.JVLDNyGwHUmytBYkmhDmirmDmexz = mroBMnpLwxbiAaSJwonEBCTLKqFQ;
				return dLgopYYCyWelwmktciUIgoJBlls2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = -1534647443;
					while (true)
					{
						switch (num2 ^ -1534647446)
						{
						case 0:
							break;
						case 7:
							switch (num)
							{
							default:
								num2 = -1534647454;
								continue;
							case 0:
								break;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = -1534647453;
								continue;
							}
							goto case 4;
						case 2:
							num2 = -1534647445;
							continue;
						case 4:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (JVLDNyGwHUmytBYkmhDmirmDmexz != null)
							{
								int num4;
								if (JVLDNyGwHUmytBYkmhDmirmDmexz == string.Empty)
								{
									num2 = -1534647444;
									num4 = num2;
								}
								else
								{
									num2 = -1534647441;
									num4 = num2;
								}
								continue;
							}
							goto default;
						case 3:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories[GXvziLknNGVrIIBwDhbLbJqdCioF].userAssignable && syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories[GXvziLknNGVrIIBwDhbLbJqdCioF].tag.Equals(JVLDNyGwHUmytBYkmhDmirmDmexz, StringComparison.OrdinalIgnoreCase))
							{
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories[GXvziLknNGVrIIBwDhbLbJqdCioF];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							}
							goto case 9;
						case 5:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories != null)
							{
								GXvziLknNGVrIIBwDhbLbJqdCioF = 0;
								num2 = -1534647448;
								continue;
							}
							goto default;
						case 9:
							GXvziLknNGVrIIBwDhbLbJqdCioF++;
							num2 = -1534647445;
							continue;
						case 8:
							num2 = -1534647444;
							continue;
						case 1:
						{
							int num3;
							if (GXvziLknNGVrIIBwDhbLbJqdCioF < syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories.Count)
							{
								num2 = -1534647447;
								num3 = num2;
							}
							else
							{
								num2 = -1534647444;
								num3 = num2;
							}
							continue;
						}
						default:
							return false;
						}
						break;
					}
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public dLgopYYCyWelwmktciUIgoJBlls(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class siutILmAORiaCxUYHvdwREYvukr : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int SRocNesKdLsnLwFbdjbxjVKxnrsd;

			public InputAction VyRXmKuGALurZWLtPgMzZFIVnfx;

			public InputCategory OEVUnxMhNKARHkQkQNFpeeAgVXpg;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				siutILmAORiaCxUYHvdwREYvukr siutILmAORiaCxUYHvdwREYvukr2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					siutILmAORiaCxUYHvdwREYvukr2 = this;
					goto IL_0025;
				}
				goto IL_004e;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ 0x67ADE6CC)
					{
					case 0:
						break;
					case 1:
						num = 1739450062;
						continue;
					case 3:
						goto IL_004e;
					default:
						return siutILmAORiaCxUYHvdwREYvukr2;
					}
					break;
				}
				goto IL_0025;
				IL_004e:
				siutILmAORiaCxUYHvdwREYvukr2 = new siutILmAORiaCxUYHvdwREYvukr(0);
				siutILmAORiaCxUYHvdwREYvukr2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = 1739450062;
				goto IL_002a;
				IL_0025:
				num = 1739450061;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					num = 355369642;
					goto IL_001f;
				case 0:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 355369641;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x152E82AB)
						{
						case 6:
							num = 355369644;
							continue;
						case 5:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = VyRXmKuGALurZWLtPgMzZFIVnfx;
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 2:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions != null)
							{
								SRocNesKdLsnLwFbdjbxjVKxnrsd = 0;
								num = 355369647;
								continue;
							}
							goto end_IL_0008;
						case 9:
							break;
						case 7:
							goto end_IL_001f;
						case 1:
							SRocNesKdLsnLwFbdjbxjVKxnrsd++;
							num = 355369647;
							continue;
						case 0:
							goto IL_00e2;
						case 3:
							goto IL_0103;
						case 4:
							goto IL_0157;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (VyRXmKuGALurZWLtPgMzZFIVnfx.userAssignable)
						{
							num = 355369646;
							num2 = num;
						}
						else
						{
							num = 355369642;
							num2 = num;
						}
						continue;
						IL_0157:
						int num3;
						if (SRocNesKdLsnLwFbdjbxjVKxnrsd < syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions.Count)
						{
							num = 355369640;
							num3 = num;
						}
						else
						{
							num = 355369635;
							num3 = num;
						}
						continue;
						IL_00e2:
						int num4;
						if (OEVUnxMhNKARHkQkQNFpeeAgVXpg.userAssignable)
						{
							num = 355369634;
							num4 = num;
						}
						else
						{
							num = 355369642;
							num4 = num;
						}
						continue;
						IL_0103:
						VyRXmKuGALurZWLtPgMzZFIVnfx = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions[SRocNesKdLsnLwFbdjbxjVKxnrsd];
						OEVUnxMhNKARHkQkQNFpeeAgVXpg = syCPfFbHYMDOvEPjTnPLBqiOhsPv.GetActionCategoryById(VyRXmKuGALurZWLtPgMzZFIVnfx.categoryId);
						int num5;
						if (OEVUnxMhNKARHkQkQNFpeeAgVXpg == null)
						{
							num = 355369642;
							num5 = num;
						}
						else
						{
							num = 355369643;
							num5 = num;
						}
						continue;
						end_IL_001f:
						break;
					}
					goto case 0;
					end_IL_0008:
					break;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public siutILmAORiaCxUYHvdwREYvukr(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class ZiEoVwEbJDjlFbtYfOoTRQlLbEOv : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int XOnJoVlUVrkjmtivJhqODDyKJDd;

			public int zPhuvRFWpUfcIWTdRFhNtaCMeLD;

			public bool ygZRNHteXxTcZVHTIfOunZiCcLr;

			public bool yNxIFThAEWeBKEVxRXYFmEMVVoPf;

			public int GXliuLrXPNppukQEuzqyEmFmyDy;

			public InputAction VZuibeShtmXXEWSvhaoohIhsLrK;

			public int HXeojklNSWtNHIhnfsDEfzbwbYu;

			public IEnumerator<int> vCECTYIuERCHgpkaxYDuQovQecx;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					goto IL_001c;
				}
				goto IL_0066;
				IL_0066:
				ZiEoVwEbJDjlFbtYfOoTRQlLbEOv ziEoVwEbJDjlFbtYfOoTRQlLbEOv = new ZiEoVwEbJDjlFbtYfOoTRQlLbEOv(0);
				ziEoVwEbJDjlFbtYfOoTRQlLbEOv.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				int num = -627511393;
				goto IL_0021;
				IL_001c:
				num = -627511394;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ -627511396)
					{
					case 5:
						break;
					case 3:
						ziEoVwEbJDjlFbtYfOoTRQlLbEOv.XOnJoVlUVrkjmtivJhqODDyKJDd = zPhuvRFWpUfcIWTdRFhNtaCMeLD;
						num = -627511395;
						continue;
					case 6:
						ziEoVwEbJDjlFbtYfOoTRQlLbEOv = this;
						num = -627511396;
						continue;
					case 4:
						goto IL_0066;
					case 0:
						num = -627511393;
						continue;
					case 2:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						num = -627511398;
						continue;
					default:
						ziEoVwEbJDjlFbtYfOoTRQlLbEOv.ygZRNHteXxTcZVHTIfOunZiCcLr = yNxIFThAEWeBKEVxRXYFmEMVVoPf;
						return ziEoVwEbJDjlFbtYfOoTRQlLbEOv;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						IL_0007:
						int num2 = 1312384325;
						while (true)
						{
							switch (num2 ^ 0x4E396540)
							{
							case 13:
								break;
							default:
								goto end_IL_000c;
							case 2:
							{
								int num5;
								if (ygZRNHteXxTcZVHTIfOunZiCcLr)
								{
									num2 = 1312384338;
									num5 = num2;
								}
								else
								{
									num2 = 1312384321;
									num5 = num2;
								}
								continue;
							}
							case 4:
								if (VZuibeShtmXXEWSvhaoohIhsLrK != null)
								{
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = VZuibeShtmXXEWSvhaoohIhsLrK;
									num2 = 1312384332;
									continue;
								}
								goto case 17;
							case 3:
								num2 = 1312384320;
								continue;
							case 17:
								if (!vCECTYIuERCHgpkaxYDuQovQecx.MoveNext())
								{
									PBvNGXoSwlmFkrZjyPVJyZLLWfS();
									num2 = 1312384320;
									continue;
								}
								goto case 14;
							case 5:
								switch (num)
								{
								case 0:
									goto IL_0109;
								case 2:
									goto IL_0162;
								case 1:
									goto IL_0248;
								case 3:
									goto IL_0269;
								}
								num2 = 1312384323;
								continue;
							case 14:
								GXliuLrXPNppukQEuzqyEmFmyDy = vCECTYIuERCHgpkaxYDuQovQecx.Current;
								num2 = 1312384330;
								continue;
							case 19:
								goto IL_0109;
							case 10:
								VZuibeShtmXXEWSvhaoohIhsLrK = syCPfFbHYMDOvEPjTnPLBqiOhsPv.GetActionById(GXliuLrXPNppukQEuzqyEmFmyDy);
								num2 = 1312384324;
								continue;
							case 20:
								goto IL_0162;
							case 7:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
								num2 = 1312384326;
								continue;
							case 18:
								vCECTYIuERCHgpkaxYDuQovQecx = syCPfFbHYMDOvEPjTnPLBqiOhsPv.SortedActionIdsInCategory(XOnJoVlUVrkjmtivJhqODDyKJDd).GetEnumerator();
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = 1312384337;
								continue;
							case 1:
								HXeojklNSWtNHIhnfsDEfzbwbYu = 0;
								num2 = 1312384329;
								continue;
							case 16:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions[HXeojklNSWtNHIhnfsDEfzbwbYu].categoryId == XOnJoVlUVrkjmtivJhqODDyKJDd)
								{
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions[HXeojklNSWtNHIhnfsDEfzbwbYu];
									num2 = 1312384327;
									continue;
								}
								goto case 8;
							case 9:
							{
								int num3;
								if (HXeojklNSWtNHIhnfsDEfzbwbYu < syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions.Count)
								{
									num2 = 1312384336;
									num3 = num2;
								}
								else
								{
									num2 = 1312384320;
									num3 = num2;
								}
								continue;
							}
							case 6:
								result = true;
								goto end_IL_000c;
							case 0:
								goto IL_0248;
							case 12:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
								result = true;
								goto end_IL_000c;
							case 11:
								goto IL_0269;
							case 8:
								HXeojklNSWtNHIhnfsDEfzbwbYu++;
								num2 = 1312384329;
								continue;
							case 15:
								goto end_IL_000c;
								IL_0248:
								result = false;
								num2 = 1312384335;
								continue;
								IL_0269:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = 1312384328;
								continue;
								IL_0162:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = 1312384337;
								continue;
								IL_0109:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions != null)
								{
									int num4;
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories == null)
									{
										num2 = 1312384320;
										num4 = num2;
									}
									else
									{
										num2 = 1312384322;
										num4 = num2;
									}
									continue;
								}
								goto IL_0248;
							}
							goto IL_0007;
							continue;
							end_IL_000c:
							break;
						}
						break;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						PBvNGXoSwlmFkrZjyPVJyZLLWfS();
					}
				}
			}

			[DebuggerHidden]
			public ZiEoVwEbJDjlFbtYfOoTRQlLbEOv(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void PBvNGXoSwlmFkrZjyPVJyZLLWfS()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (vCECTYIuERCHgpkaxYDuQovQecx != null)
				{
					vCECTYIuERCHgpkaxYDuQovQecx.Dispose();
				}
			}
		}

		private sealed class NquaPOXolrXLlxGOIHlQEgUaOck : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public string gMrjZMyBfNgzOgMdpUqchbUmnJD;

			public string taBUSBtfawhvQgJYbELnaTVouyIE;

			public bool ygZRNHteXxTcZVHTIfOunZiCcLr;

			public bool yNxIFThAEWeBKEVxRXYFmEMVVoPf;

			public int iXSKlMBFPUlFBwESevgPQBlSrsx;

			public InputCategory PrUXnmyfXxFXPsdlALpGxzrDOYw;

			public int znBOxjsyhwJPLRMYoqflMtBEimB;

			public InputAction aLkNfesrkClIeuFYVdadJMehtRX;

			public int rTDbHTELPCkoKaadDcPNwKORIEae;

			public IEnumerator<int> kPBplPFOZeNLdcSUMFKoDgXNYfJC;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					goto IL_001c;
				}
				goto IL_004e;
				IL_004e:
				NquaPOXolrXLlxGOIHlQEgUaOck nquaPOXolrXLlxGOIHlQEgUaOck = new NquaPOXolrXLlxGOIHlQEgUaOck(0);
				nquaPOXolrXLlxGOIHlQEgUaOck.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				int num = 808593037;
				goto IL_0021;
				IL_001c:
				num = 808593038;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x3032268C)
					{
					case 0:
						break;
					case 2:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						nquaPOXolrXLlxGOIHlQEgUaOck = this;
						num = 808593037;
						continue;
					case 3:
						goto IL_004e;
					default:
						nquaPOXolrXLlxGOIHlQEgUaOck.gMrjZMyBfNgzOgMdpUqchbUmnJD = taBUSBtfawhvQgJYbELnaTVouyIE;
						nquaPOXolrXLlxGOIHlQEgUaOck.ygZRNHteXxTcZVHTIfOunZiCcLr = yNxIFThAEWeBKEVxRXYFmEMVVoPf;
						return nquaPOXolrXLlxGOIHlQEgUaOck;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = 1714880098;
						goto IL_0022;
					case 0:
						goto IL_0125;
					case 3:
						goto IL_01cd;
					case 1:
						goto IL_01de;
					case 2:
						goto IL_029f;
						IL_0022:
						while (true)
						{
							switch (num ^ 0x6636FE6B)
							{
							case 3:
								break;
							default:
								goto end_IL_0008;
							case 9:
								num = 1714880111;
								continue;
							case 14:
								iXSKlMBFPUlFBwESevgPQBlSrsx = syCPfFbHYMDOvEPjTnPLBqiOhsPv.IndexOfActionCategory(gMrjZMyBfNgzOgMdpUqchbUmnJD);
								num = 1714880096;
								continue;
							case 6:
								goto IL_0097;
							case 11:
								if (iXSKlMBFPUlFBwESevgPQBlSrsx >= 0)
								{
									PrUXnmyfXxFXPsdlALpGxzrDOYw = syCPfFbHYMDOvEPjTnPLBqiOhsPv.GetActionCategory(iXSKlMBFPUlFBwESevgPQBlSrsx);
									if (ygZRNHteXxTcZVHTIfOunZiCcLr)
									{
										kPBplPFOZeNLdcSUMFKoDgXNYfJC = syCPfFbHYMDOvEPjTnPLBqiOhsPv.SortedActionIdsInCategory(PrUXnmyfXxFXPsdlALpGxzrDOYw.id).GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num = 1714880107;
										continue;
									}
									goto case 12;
								}
								goto IL_01de;
							case 15:
								goto IL_0125;
							case 12:
								rTDbHTELPCkoKaadDcPNwKORIEae = 0;
								num = 1714880110;
								continue;
							case 8:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions[rTDbHTELPCkoKaadDcPNwKORIEae].categoryId == PrUXnmyfXxFXPsdlALpGxzrDOYw.id)
								{
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions[rTDbHTELPCkoKaadDcPNwKORIEae];
									isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
									result = true;
									goto end_IL_0008;
								}
								goto case 7;
							case 1:
								goto IL_01cd;
							case 4:
								goto IL_01de;
							case 10:
								znBOxjsyhwJPLRMYoqflMtBEimB = kPBplPFOZeNLdcSUMFKoDgXNYfJC.Current;
								aLkNfesrkClIeuFYVdadJMehtRX = syCPfFbHYMDOvEPjTnPLBqiOhsPv.GetActionById(znBOxjsyhwJPLRMYoqflMtBEimB);
								if (aLkNfesrkClIeuFYVdadJMehtRX != null)
								{
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = aLkNfesrkClIeuFYVdadJMehtRX;
									isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
									result = true;
									goto end_IL_0008;
								}
								goto case 0;
							case 7:
								rTDbHTELPCkoKaadDcPNwKORIEae++;
								num = 1714880110;
								continue;
							case 0:
								if (!kPBplPFOZeNLdcSUMFKoDgXNYfJC.MoveNext())
								{
									rhqXTZzPzrsUskGnkhqHqnKpUQY();
									num = 1714880111;
									continue;
								}
								goto case 10;
							case 5:
								goto IL_0273;
							case 13:
								goto IL_029f;
							case 2:
								goto end_IL_0008;
							}
							break;
							IL_0273:
							int num2;
							if (rTDbHTELPCkoKaadDcPNwKORIEae < syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions.Count)
							{
								num = 1714880099;
								num2 = num;
							}
							else
							{
								num = 1714880111;
								num2 = num;
							}
							continue;
							IL_0097:
							if (gMrjZMyBfNgzOgMdpUqchbUmnJD != null)
							{
								int num3;
								if (gMrjZMyBfNgzOgMdpUqchbUmnJD == string.Empty)
								{
									num = 1714880111;
									num3 = num;
								}
								else
								{
									num = 1714880101;
									num3 = num;
								}
								continue;
							}
							goto IL_01de;
						}
						goto default;
						IL_029f:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
						num = 1714880107;
						goto IL_0022;
						IL_01cd:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 1714880108;
						goto IL_0022;
						IL_0125:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions != null)
						{
							int num4;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories == null)
							{
								num = 1714880111;
								num4 = num;
							}
							else
							{
								num = 1714880109;
								num4 = num;
							}
							goto IL_0022;
						}
						goto IL_01de;
						IL_01de:
						result = false;
						num = 1714880105;
						goto IL_0022;
						end_IL_0008:
						break;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						rhqXTZzPzrsUskGnkhqHqnKpUQY();
					}
				}
			}

			[DebuggerHidden]
			public NquaPOXolrXLlxGOIHlQEgUaOck(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void rhqXTZzPzrsUskGnkhqHqnKpUQY()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (kPBplPFOZeNLdcSUMFKoDgXNYfJC != null)
				{
					kPBplPFOZeNLdcSUMFKoDgXNYfJC.Dispose();
				}
			}
		}

		private sealed class IJAmTwbWZstaOssQSYHQUiWKOlR : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public string JVLDNyGwHUmytBYkmhDmirmDmexz;

			public string mroBMnpLwxbiAaSJwonEBCTLKqFQ;

			public int TxrNSWKsEwqeyvhDToOBlDEOXjY;

			public int ZZQMAZjIcnlBeJGgQgoxEOMojDL;

			public InputCategory IwkOCxrdwTGqrIWUJJoDPcBuWlx;

			public int LhrbDnJnIcurXvfqqGFFAQbOUFzg;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
				{
					goto IL_0012;
				}
				goto IL_0072;
				IL_0012:
				int num = -1012261388;
				goto IL_0017;
				IL_0017:
				IJAmTwbWZstaOssQSYHQUiWKOlR iJAmTwbWZstaOssQSYHQUiWKOlR = default(IJAmTwbWZstaOssQSYHQUiWKOlR);
				while (true)
				{
					switch (num ^ -1012261387)
					{
					case 6:
						break;
					case 5:
						num = -1012261387;
						continue;
					case 3:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						iJAmTwbWZstaOssQSYHQUiWKOlR = this;
						num = -1012261392;
						continue;
					case 1:
						goto IL_0057;
					case 4:
						goto IL_0072;
					case 0:
						iJAmTwbWZstaOssQSYHQUiWKOlR.JVLDNyGwHUmytBYkmhDmirmDmexz = mroBMnpLwxbiAaSJwonEBCTLKqFQ;
						num = -1012261385;
						continue;
					default:
						return iJAmTwbWZstaOssQSYHQUiWKOlR;
					}
					break;
					IL_0057:
					int num2;
					if (isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
					{
						num = -1012261391;
						num2 = num;
					}
					else
					{
						num = -1012261386;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_0072:
				iJAmTwbWZstaOssQSYHQUiWKOlR = new IJAmTwbWZstaOssQSYHQUiWKOlR(0);
				iJAmTwbWZstaOssQSYHQUiWKOlR.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = -1012261387;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = 1402573846;
					while (true)
					{
						switch (num2 ^ 0x53999417)
						{
						case 12:
							break;
						case 3:
							if (IwkOCxrdwTGqrIWUJJoDPcBuWlx.id == syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions[LhrbDnJnIcurXvfqqGFFAQbOUFzg].categoryId)
							{
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions[LhrbDnJnIcurXvfqqGFFAQbOUFzg];
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							}
							goto case 7;
						case 11:
							ZZQMAZjIcnlBeJGgQgoxEOMojDL++;
							num2 = 1402573850;
							continue;
						case 9:
							if (!(JVLDNyGwHUmytBYkmhDmirmDmexz == string.Empty))
							{
								TxrNSWKsEwqeyvhDToOBlDEOXjY = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions.Count;
								num2 = 1402573845;
								continue;
							}
							goto default;
						case 13:
						{
							int num5;
							if (ZZQMAZjIcnlBeJGgQgoxEOMojDL >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories.Count)
							{
								num2 = 1402573849;
								num5 = num2;
							}
							else
							{
								num2 = 1402573843;
								num5 = num2;
							}
							continue;
						}
						case 2:
							ZZQMAZjIcnlBeJGgQgoxEOMojDL = 0;
							num2 = 1402573853;
							continue;
						case 6:
							num2 = 1402573847;
							continue;
						case 7:
							LhrbDnJnIcurXvfqqGFFAQbOUFzg++;
							num2 = 1402573847;
							continue;
						case 5:
							IwkOCxrdwTGqrIWUJJoDPcBuWlx = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories[ZZQMAZjIcnlBeJGgQgoxEOMojDL];
							LhrbDnJnIcurXvfqqGFFAQbOUFzg = 0;
							num2 = 1402573841;
							continue;
						case 10:
							num2 = 1402573850;
							continue;
						case 4:
						{
							int num6;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories[ZZQMAZjIcnlBeJGgQgoxEOMojDL].tag.Equals(JVLDNyGwHUmytBYkmhDmirmDmexz, StringComparison.OrdinalIgnoreCase))
							{
								num2 = 1402573842;
								num6 = num2;
							}
							else
							{
								num2 = 1402573852;
								num6 = num2;
							}
							continue;
						}
						case 8:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories != null)
							{
								int num4;
								if (JVLDNyGwHUmytBYkmhDmirmDmexz == null)
								{
									num2 = 1402573849;
									num4 = num2;
								}
								else
								{
									num2 = 1402573854;
									num4 = num2;
								}
								continue;
							}
							goto default;
						case 0:
						{
							int num3;
							if (LhrbDnJnIcurXvfqqGFFAQbOUFzg < TxrNSWKsEwqeyvhDToOBlDEOXjY)
							{
								num2 = 1402573844;
								num3 = num2;
							}
							else
							{
								num2 = 1402573852;
								num3 = num2;
							}
							continue;
						}
						case 1:
							switch (num)
							{
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = 1402573840;
								continue;
							case 0:
								break;
							default:
								num2 = 1402573849;
								continue;
							}
							goto case 8;
						default:
							return false;
						}
						break;
					}
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public IJAmTwbWZstaOssQSYHQUiWKOlR(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class HmmtlPdCqfcaXvqAxSTQFSMZqTK : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int XOnJoVlUVrkjmtivJhqODDyKJDd;

			public int zPhuvRFWpUfcIWTdRFhNtaCMeLD;

			public bool ygZRNHteXxTcZVHTIfOunZiCcLr;

			public bool yNxIFThAEWeBKEVxRXYFmEMVVoPf;

			public InputCategory ZBFxnXvJclHcwAZilypUBHyPwgw;

			public int ZigNdqCyGEhxFpSXUKqIuPjHIce;

			public InputAction YtUfCIvJcPFXLusgBfyvUTEKCirC;

			public int lTXBKDJLCXdPiCwqfryEPhdnlNc;

			public InputAction KhTrKegaavfNznhwjQOYBIsTBtEI;

			public IEnumerator<int> TycbpOighRlGccQwhRcrgNXQvxxN;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
				{
					goto IL_0012;
				}
				goto IL_006e;
				IL_0012:
				int num = 686124951;
				goto IL_0017;
				IL_0017:
				HmmtlPdCqfcaXvqAxSTQFSMZqTK hmmtlPdCqfcaXvqAxSTQFSMZqTK = default(HmmtlPdCqfcaXvqAxSTQFSMZqTK);
				while (true)
				{
					switch (num ^ 0x28E56F92)
					{
					case 4:
						break;
					case 3:
						num = 686124947;
						continue;
					case 2:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						hmmtlPdCqfcaXvqAxSTQFSMZqTK = this;
						num = 686124945;
						continue;
					case 5:
						goto IL_0053;
					case 0:
						goto IL_006e;
					default:
						hmmtlPdCqfcaXvqAxSTQFSMZqTK.XOnJoVlUVrkjmtivJhqODDyKJDd = zPhuvRFWpUfcIWTdRFhNtaCMeLD;
						hmmtlPdCqfcaXvqAxSTQFSMZqTK.ygZRNHteXxTcZVHTIfOunZiCcLr = yNxIFThAEWeBKEVxRXYFmEMVVoPf;
						return hmmtlPdCqfcaXvqAxSTQFSMZqTK;
					}
					break;
					IL_0053:
					int num2;
					if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						num = 686124944;
						num2 = num;
					}
					else
					{
						num = 686124946;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_006e:
				hmmtlPdCqfcaXvqAxSTQFSMZqTK = new HmmtlPdCqfcaXvqAxSTQFSMZqTK(0);
				hmmtlPdCqfcaXvqAxSTQFSMZqTK.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = 686124947;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 3:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 1735507475;
						goto IL_0027;
					case 2:
						goto IL_0273;
					case 0:
						goto IL_02de;
						IL_0027:
						while (true)
						{
							switch (num ^ 0x6771BE1C)
							{
							case 0:
								num = 1735507485;
								continue;
							case 6:
								break;
							case 18:
								goto IL_00ab;
							case 8:
								TycbpOighRlGccQwhRcrgNXQvxxN = syCPfFbHYMDOvEPjTnPLBqiOhsPv.SortedActionIdsInCategory(ZBFxnXvJclHcwAZilypUBHyPwgw.id).GetEnumerator();
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 1735507479;
								continue;
							case 11:
								if (!TycbpOighRlGccQwhRcrgNXQvxxN.MoveNext())
								{
									hQJrIACBhfElZeDOnJoMpwKmBti();
									num = 1735507486;
									continue;
								}
								goto case 16;
							case 17:
								KhTrKegaavfNznhwjQOYBIsTBtEI = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions[lTXBKDJLCXdPiCwqfryEPhdnlNc];
								num = 1735507470;
								continue;
							case 14:
								goto IL_014f;
							case 7:
								goto IL_0170;
							case 2:
								num = 1735507480;
								continue;
							case 20:
								lTXBKDJLCXdPiCwqfryEPhdnlNc = 0;
								num = 1735507478;
								continue;
							case 21:
								if (KhTrKegaavfNznhwjQOYBIsTBtEI.userAssignable)
								{
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = KhTrKegaavfNznhwjQOYBIsTBtEI;
									isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
									return true;
								}
								goto case 15;
							case 19:
								goto end_IL_0027;
							case 10:
								goto IL_01ec;
							case 16:
								ZigNdqCyGEhxFpSXUKqIuPjHIce = TycbpOighRlGccQwhRcrgNXQvxxN.Current;
								num = 1735507487;
								continue;
							case 13:
								goto IL_0233;
							case 9:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = YtUfCIvJcPFXLusgBfyvUTEKCirC;
								isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
								return true;
							case 12:
								goto IL_0273;
							case 3:
								YtUfCIvJcPFXLusgBfyvUTEKCirC = syCPfFbHYMDOvEPjTnPLBqiOhsPv.GetActionById(ZigNdqCyGEhxFpSXUKqIuPjHIce);
								num = 1735507473;
								continue;
							case 5:
								goto IL_02a5;
							case 15:
								lTXBKDJLCXdPiCwqfryEPhdnlNc++;
								num = 1735507478;
								continue;
							case 1:
								goto IL_02de;
							default:
								goto end_IL_0008;
							}
							int num2;
							if (!ygZRNHteXxTcZVHTIfOunZiCcLr)
							{
								num = 1735507464;
								num2 = num;
							}
							else
							{
								num = 1735507476;
								num2 = num;
							}
							continue;
							IL_02a5:
							int num3;
							if (ZBFxnXvJclHcwAZilypUBHyPwgw.userAssignable)
							{
								num = 1735507482;
								num3 = num;
							}
							else
							{
								num = 1735507480;
								num3 = num;
							}
							continue;
							IL_0170:
							int num4;
							if (ZBFxnXvJclHcwAZilypUBHyPwgw != null)
							{
								num = 1735507481;
								num4 = num;
							}
							else
							{
								num = 1735507480;
								num4 = num;
							}
							continue;
							IL_00ab:
							int num5;
							if (KhTrKegaavfNznhwjQOYBIsTBtEI.categoryId != ZBFxnXvJclHcwAZilypUBHyPwgw.id)
							{
								num = 1735507475;
								num5 = num;
							}
							else
							{
								num = 1735507465;
								num5 = num;
							}
							continue;
							IL_0233:
							int num6;
							if (YtUfCIvJcPFXLusgBfyvUTEKCirC != null)
							{
								num = 1735507474;
								num6 = num;
							}
							else
							{
								num = 1735507479;
								num6 = num;
							}
							continue;
							IL_01ec:
							int num7;
							if (lTXBKDJLCXdPiCwqfryEPhdnlNc >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions.Count)
							{
								num = 1735507480;
								num7 = num;
							}
							else
							{
								num = 1735507469;
								num7 = num;
							}
							continue;
							IL_014f:
							int num8;
							if (!YtUfCIvJcPFXLusgBfyvUTEKCirC.userAssignable)
							{
								num = 1735507479;
								num8 = num;
							}
							else
							{
								num = 1735507477;
								num8 = num;
							}
							continue;
							end_IL_0027:
							break;
						}
						goto case 3;
						IL_02de:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions == null || syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories == null)
						{
							break;
						}
						ZBFxnXvJclHcwAZilypUBHyPwgw = syCPfFbHYMDOvEPjTnPLBqiOhsPv.GetActionCategoryById(XOnJoVlUVrkjmtivJhqODDyKJDd);
						num = 1735507483;
						goto IL_0027;
						IL_0273:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
						num = 1735507479;
						goto IL_0027;
						end_IL_0008:
						break;
					}
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = 529305739;
					while (true)
					{
						switch (num2 ^ 0x1F8C908A)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							switch (num)
							{
							case 1:
							case 2:
								try
								{
									return;
								}
								finally
								{
									hQJrIACBhfElZeDOnJoMpwKmBti();
								}
							}
							goto IL_0035;
						case 2:
							return;
						}
						break;
						IL_0035:
						num2 = 529305736;
					}
				}
			}

			[DebuggerHidden]
			public HmmtlPdCqfcaXvqAxSTQFSMZqTK(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void hQJrIACBhfElZeDOnJoMpwKmBti()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (TycbpOighRlGccQwhRcrgNXQvxxN != null)
				{
					TycbpOighRlGccQwhRcrgNXQvxxN.Dispose();
				}
			}
		}

		private sealed class OMoBXwzaJAzTpXGkBeBnbgQQyzZS : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public string OQwTlVmnHUDbZEjCxqniWATZpvDA;

			public string wDpkpKdUlIImNFhvGmPMElLmfhDe;

			public bool ygZRNHteXxTcZVHTIfOunZiCcLr;

			public bool yNxIFThAEWeBKEVxRXYFmEMVVoPf;

			public InputCategory JtYZOqNEefYyDIuaJscwhGaWUeW;

			public int AsdFUyebapoTWekhrVcJTIzRNbX;

			public InputAction SWUdIqIvNEQPCajYkPWdFQhcMVAl;

			public int oDCwRNgELiLqMmxuDPnQSJtKIgi;

			public InputAction YCuAhZpmvcLsYMcUiXzpgLUVZcI;

			public IEnumerator<int> ICzftqTrXdZHNEAkdIgeRXGKqQQ;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				OMoBXwzaJAzTpXGkBeBnbgQQyzZS oMoBXwzaJAzTpXGkBeBnbgQQyzZS;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					oMoBXwzaJAzTpXGkBeBnbgQQyzZS = this;
				}
				else
				{
					while (true)
					{
						oMoBXwzaJAzTpXGkBeBnbgQQyzZS = new OMoBXwzaJAzTpXGkBeBnbgQQyzZS(0);
						oMoBXwzaJAzTpXGkBeBnbgQQyzZS.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = 1615715048;
						while (true)
						{
							switch (num ^ 0x604DDAEA)
							{
							case 0:
								num = 1615715051;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				oMoBXwzaJAzTpXGkBeBnbgQQyzZS.OQwTlVmnHUDbZEjCxqniWATZpvDA = wDpkpKdUlIImNFhvGmPMElLmfhDe;
				oMoBXwzaJAzTpXGkBeBnbgQQyzZS.ygZRNHteXxTcZVHTIfOunZiCcLr = yNxIFThAEWeBKEVxRXYFmEMVVoPf;
				return oMoBXwzaJAzTpXGkBeBnbgQQyzZS;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						IL_0007:
						int num2 = -1705240480;
						while (true)
						{
							switch (num2 ^ -1705240469)
							{
							case 5:
								break;
							case 20:
								result = true;
								goto end_IL_000c;
							case 14:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = -1705240476;
								continue;
							case 0:
								JtYZOqNEefYyDIuaJscwhGaWUeW = syCPfFbHYMDOvEPjTnPLBqiOhsPv.GetActionCategory(OQwTlVmnHUDbZEjCxqniWATZpvDA);
								num2 = -1705240465;
								continue;
							case 19:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
								num2 = -1705240453;
								continue;
							case 9:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions != null)
								{
									int num4;
									if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories != null)
									{
										num2 = -1705240469;
										num4 = num2;
									}
									else
									{
										num2 = -1705240451;
										num4 = num2;
									}
									continue;
								}
								goto IL_0304;
							case 7:
								goto IL_00fa;
							case 1:
								goto end_IL_000c;
							case 18:
								num2 = -1705240451;
								continue;
							case 13:
								oDCwRNgELiLqMmxuDPnQSJtKIgi = 0;
								num2 = -1705240454;
								continue;
							case 17:
							{
								int num5;
								if (oDCwRNgELiLqMmxuDPnQSJtKIgi >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions.Count)
								{
									num2 = -1705240451;
									num5 = num2;
								}
								else
								{
									num2 = -1705240472;
									num5 = num2;
								}
								continue;
							}
							case 4:
								if (JtYZOqNEefYyDIuaJscwhGaWUeW != null && JtYZOqNEefYyDIuaJscwhGaWUeW.userAssignable)
								{
									if (ygZRNHteXxTcZVHTIfOunZiCcLr)
									{
										ICzftqTrXdZHNEAkdIgeRXGKqQQ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.SortedActionIdsInCategory(JtYZOqNEefYyDIuaJscwhGaWUeW.id).GetEnumerator();
										isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
										num2 = -1705240450;
										continue;
									}
									goto case 13;
								}
								goto IL_0304;
							case 2:
								AsdFUyebapoTWekhrVcJTIzRNbX = ICzftqTrXdZHNEAkdIgeRXGKqQQ.Current;
								SWUdIqIvNEQPCajYkPWdFQhcMVAl = syCPfFbHYMDOvEPjTnPLBqiOhsPv.GetActionById(AsdFUyebapoTWekhrVcJTIzRNbX);
								if (SWUdIqIvNEQPCajYkPWdFQhcMVAl != null && SWUdIqIvNEQPCajYkPWdFQhcMVAl.userAssignable)
								{
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = SWUdIqIvNEQPCajYkPWdFQhcMVAl;
									num2 = -1705240456;
									continue;
								}
								goto case 15;
							case 6:
								oDCwRNgELiLqMmxuDPnQSJtKIgi++;
								num2 = -1705240454;
								continue;
							case 11:
								switch (num)
								{
								case 2:
									break;
								case 0:
									goto IL_00fa;
								default:
									goto IL_0237;
								case 3:
									goto IL_02b7;
								case 1:
									goto IL_0304;
								}
								goto case 14;
							case 15:
								if (!ICzftqTrXdZHNEAkdIgeRXGKqQQ.MoveNext())
								{
									ZjMaobWHlbXrRwbmXBHnVixONPv();
									num2 = -1705240455;
									continue;
								}
								goto case 2;
							case 10:
								if (YCuAhZpmvcLsYMcUiXzpgLUVZcI.categoryId == JtYZOqNEefYyDIuaJscwhGaWUeW.id)
								{
									int num3;
									if (!YCuAhZpmvcLsYMcUiXzpgLUVZcI.userAssignable)
									{
										num2 = -1705240467;
										num3 = num2;
									}
									else
									{
										num2 = -1705240473;
										num3 = num2;
									}
									continue;
								}
								goto case 6;
							case 12:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = YCuAhZpmvcLsYMcUiXzpgLUVZcI;
								isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
								num2 = -1705240449;
								continue;
							case 8:
								goto IL_02b7;
							case 3:
								YCuAhZpmvcLsYMcUiXzpgLUVZcI = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions[oDCwRNgELiLqMmxuDPnQSJtKIgi];
								num2 = -1705240479;
								continue;
							case 21:
								num2 = -1705240476;
								continue;
							case 16:
								result = true;
								num2 = -1705240470;
								continue;
							default:
								goto IL_0304;
								IL_0304:
								result = false;
								goto end_IL_000c;
								IL_02b7:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = -1705240467;
								continue;
								IL_0237:
								num2 = -1705240451;
								continue;
								IL_00fa:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = -1705240478;
								continue;
							}
							goto IL_0007;
							continue;
							end_IL_000c:
							break;
						}
						break;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						ZjMaobWHlbXrRwbmXBHnVixONPv();
					}
				}
			}

			[DebuggerHidden]
			public OMoBXwzaJAzTpXGkBeBnbgQQyzZS(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void ZjMaobWHlbXrRwbmXBHnVixONPv()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (ICzftqTrXdZHNEAkdIgeRXGKqQQ == null)
				{
					return;
				}
				while (true)
				{
					int num = 1551247737;
					while (true)
					{
						switch (num ^ 0x5C762978)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002d;
						case 0:
							return;
						}
						break;
						IL_002d:
						ICzftqTrXdZHNEAkdIgeRXGKqQQ.Dispose();
						num = 1551247736;
					}
				}
			}
		}

		private sealed class psOFBWNsZOgOIaYQbjwTJcbJkalf : IDisposable, IEnumerator, IEnumerable, IEnumerable<string>, IEnumerator<string>
		{
			private string ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int tvvERjRcrFQoLeSRWZgxEcxZOWL;

			public int HEjtFCDQuzjqYEUuHIHEKiXWBfw;

			public int mONybmOebYklWebjgJSJKQRxfKM;

			public InputAction WvIhoVoYXuTIVpuEctzFyHYcjtz;

			public IEnumerator<int> HPRZlTAPkjmYUJDHsnjKXgDsqYt;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				psOFBWNsZOgOIaYQbjwTJcbJkalf psOFBWNsZOgOIaYQbjwTJcbJkalf2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					psOFBWNsZOgOIaYQbjwTJcbJkalf2 = this;
				}
				else
				{
					while (true)
					{
						psOFBWNsZOgOIaYQbjwTJcbJkalf2 = new psOFBWNsZOgOIaYQbjwTJcbJkalf(0);
						psOFBWNsZOgOIaYQbjwTJcbJkalf2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = 1702565796;
						while (true)
						{
							switch (num ^ 0x657B17A4)
							{
							case 2:
								num = 1702565797;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				psOFBWNsZOgOIaYQbjwTJcbJkalf2.tvvERjRcrFQoLeSRWZgxEcxZOWL = HEjtFCDQuzjqYEUuHIHEKiXWBfw;
				return psOFBWNsZOgOIaYQbjwTJcbJkalf2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					int num2;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 0:
						goto IL_00cb;
					default:
						goto IL_013e;
					case 2:
						goto IL_014a;
						IL_00cb:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories != null)
						{
							num = -151416852;
							num2 = num;
						}
						else
						{
							num = -151416851;
							num2 = num;
						}
						goto IL_0023;
						IL_014a:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
						num = -151416857;
						goto IL_0023;
						IL_013e:
						result = false;
						num = -151416855;
						goto IL_0023;
						IL_0023:
						while (true)
						{
							switch (num ^ -151416849)
							{
							case 5:
								num = -151416850;
								continue;
							case 4:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
								result = true;
								break;
							case 3:
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions != null)
								{
									HPRZlTAPkjmYUJDHsnjKXgDsqYt = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategoryMap.ActionIdsInCategory(tvvERjRcrFQoLeSRWZgxEcxZOWL).GetEnumerator();
									isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
									num = -151416857;
									continue;
								}
								goto IL_013e;
							case 8:
								if (!HPRZlTAPkjmYUJDHsnjKXgDsqYt.MoveNext())
								{
									ObpiVzKdASjUYGthQLeCmhorbIB();
									num = -151416851;
									continue;
								}
								goto case 0;
							case 1:
								goto IL_00cb;
							case 0:
								mONybmOebYklWebjgJSJKQRxfKM = HPRZlTAPkjmYUJDHsnjKXgDsqYt.Current;
								WvIhoVoYXuTIVpuEctzFyHYcjtz = syCPfFbHYMDOvEPjTnPLBqiOhsPv.GetActionById(mONybmOebYklWebjgJSJKQRxfKM);
								if (WvIhoVoYXuTIVpuEctzFyHYcjtz != null)
								{
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = WvIhoVoYXuTIVpuEctzFyHYcjtz.name;
									num = -151416853;
									continue;
								}
								goto case 8;
							case 2:
								goto IL_013e;
							case 7:
								goto IL_014a;
							case 6:
								break;
							}
							break;
						}
						break;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						ObpiVzKdASjUYGthQLeCmhorbIB();
					}
				}
			}

			[DebuggerHidden]
			public psOFBWNsZOgOIaYQbjwTJcbJkalf(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void ObpiVzKdASjUYGthQLeCmhorbIB()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (HPRZlTAPkjmYUJDHsnjKXgDsqYt != null)
				{
					HPRZlTAPkjmYUJDHsnjKXgDsqYt.Dispose();
				}
			}
		}

		private sealed class rpngRhOpKwAAdAKHtepxBaUAaWo : IDisposable, IEnumerator, IEnumerable, IEnumerable<string>, IEnumerator<string>
		{
			private string ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int tvvERjRcrFQoLeSRWZgxEcxZOWL;

			public int HEjtFCDQuzjqYEUuHIHEKiXWBfw;

			public int qkYHApPJWhrRYwmLaYhyIpyTZUV;

			public InputAction UZPgXyVgkrBEcgqGibaTnprNJzrp;

			public IEnumerator<int> XlNDDOhxmPlGuuPacxgnFMhNgcT;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
				{
					goto IL_0012;
				}
				goto IL_0056;
				IL_0012:
				int num = -657809085;
				goto IL_0017;
				IL_0017:
				rpngRhOpKwAAdAKHtepxBaUAaWo rpngRhOpKwAAdAKHtepxBaUAaWo2 = default(rpngRhOpKwAAdAKHtepxBaUAaWo);
				while (true)
				{
					switch (num ^ -657809086)
					{
					case 2:
						break;
					case 1:
						if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							rpngRhOpKwAAdAKHtepxBaUAaWo2 = this;
							num = -657809082;
							continue;
						}
						goto IL_0056;
					case 3:
						goto IL_0056;
					case 4:
						num = -657809086;
						continue;
					case 5:
						rpngRhOpKwAAdAKHtepxBaUAaWo2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -657809086;
						continue;
					default:
						rpngRhOpKwAAdAKHtepxBaUAaWo2.tvvERjRcrFQoLeSRWZgxEcxZOWL = HEjtFCDQuzjqYEUuHIHEKiXWBfw;
						return rpngRhOpKwAAdAKHtepxBaUAaWo2;
					}
					break;
				}
				goto IL_0012;
				IL_0056:
				rpngRhOpKwAAdAKHtepxBaUAaWo2 = new rpngRhOpKwAAdAKHtepxBaUAaWo(0);
				num = -657809081;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = 535839400;
						goto IL_001e;
					case 0:
						goto IL_0084;
					case 2:
						goto IL_0136;
					case 1:
						break;
						IL_001e:
						while (true)
						{
							switch (num ^ 0x1FF042A0)
							{
							case 2:
								break;
							case 1:
								goto IL_0056;
							case 0:
								goto IL_0084;
							case 7:
								qkYHApPJWhrRYwmLaYhyIpyTZUV = XlNDDOhxmPlGuuPacxgnFMhNgcT.Current;
								UZPgXyVgkrBEcgqGibaTnprNJzrp = syCPfFbHYMDOvEPjTnPLBqiOhsPv.GetActionById(qkYHApPJWhrRYwmLaYhyIpyTZUV);
								if (UZPgXyVgkrBEcgqGibaTnprNJzrp != null)
								{
									ubyTdixGSFKGaFQFZdQnpwgWIvJ = UZPgXyVgkrBEcgqGibaTnprNJzrp.descriptiveName;
									num = 535839397;
									continue;
								}
								goto case 4;
							case 8:
								num = 535839398;
								continue;
							case 4:
								if (!XlNDDOhxmPlGuuPacxgnFMhNgcT.MoveNext())
								{
									QIujNYhDIbNEqOsFPinIZlVxcOFE();
									num = 535839398;
									continue;
								}
								goto case 7;
							case 3:
								XlNDDOhxmPlGuuPacxgnFMhNgcT = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategoryMap.ActionIdsInCategory(tvvERjRcrFQoLeSRWZgxEcxZOWL).GetEnumerator();
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 535839396;
								continue;
							case 9:
								goto IL_0136;
							case 5:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
								return true;
							default:
								goto end_IL_0008;
							}
							break;
							IL_0056:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories == null)
							{
								goto end_IL_0008;
							}
							int num2;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions != null)
							{
								num = 535839395;
								num2 = num;
							}
							else
							{
								num = 535839398;
								num2 = num;
							}
						}
						goto default;
						IL_0136:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
						num = 535839396;
						goto IL_001e;
						IL_0084:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 535839393;
						goto IL_001e;
						end_IL_0008:
						break;
					}
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						QIujNYhDIbNEqOsFPinIZlVxcOFE();
					}
				}
			}

			[DebuggerHidden]
			public rpngRhOpKwAAdAKHtepxBaUAaWo(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void QIujNYhDIbNEqOsFPinIZlVxcOFE()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (XlNDDOhxmPlGuuPacxgnFMhNgcT == null)
				{
					return;
				}
				while (true)
				{
					int num = 1686749010;
					while (true)
					{
						switch (num ^ 0x6489BF53)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002d;
						case 0:
							return;
						}
						break;
						IL_002d:
						XlNDDOhxmPlGuuPacxgnFMhNgcT.Dispose();
						num = 1686749011;
					}
				}
			}
		}

		private sealed class wEbpVSktomGeQgVvJoJZyVuWgXC : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
		{
			private int ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public UserData syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int tvvERjRcrFQoLeSRWZgxEcxZOWL;

			public int HEjtFCDQuzjqYEUuHIHEKiXWBfw;

			public int awSWVBByhQZheiNtYFPwkfOhJAf;

			public IEnumerator<int> SQmuElBWhNrhrhdYlfiyrZTuFzD;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				wEbpVSktomGeQgVvJoJZyVuWgXC wEbpVSktomGeQgVvJoJZyVuWgXC2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					wEbpVSktomGeQgVvJoJZyVuWgXC2 = this;
					goto IL_0025;
				}
				goto IL_007c;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ -949927624)
					{
					case 5:
						break;
					case 4:
						num = -949927623;
						continue;
					case 3:
						wEbpVSktomGeQgVvJoJZyVuWgXC2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -949927623;
						continue;
					case 1:
						wEbpVSktomGeQgVvJoJZyVuWgXC2.tvvERjRcrFQoLeSRWZgxEcxZOWL = HEjtFCDQuzjqYEUuHIHEKiXWBfw;
						num = -949927622;
						continue;
					case 0:
						goto IL_007c;
					default:
						return wEbpVSktomGeQgVvJoJZyVuWgXC2;
					}
					break;
				}
				goto IL_0025;
				IL_007c:
				wEbpVSktomGeQgVvJoJZyVuWgXC2 = new wEbpVSktomGeQgVvJoJZyVuWgXC(0);
				num = -949927621;
				goto IL_002a;
				IL_0025:
				num = -949927620;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = -1680794323;
						goto IL_001e;
					case 1:
						goto IL_004e;
					case 0:
						goto IL_0057;
					case 2:
						goto IL_0103;
						IL_001e:
						while (true)
						{
							switch (num ^ -1680794324)
							{
							case 4:
								break;
							default:
								goto end_IL_0008;
							case 6:
								goto IL_004e;
							case 2:
								goto IL_0057;
							case 0:
								if (!SQmuElBWhNrhrhdYlfiyrZTuFzD.MoveNext())
								{
									fRLclUaJSMFwNFJXAcRbSkQfivqH();
									num = -1680794326;
									continue;
								}
								goto case 3;
							case 1:
								num = -1680794326;
								continue;
							case 3:
								awSWVBByhQZheiNtYFPwkfOhJAf = SQmuElBWhNrhrhdYlfiyrZTuFzD.Current;
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = awSWVBByhQZheiNtYFPwkfOhJAf;
								isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
								result = true;
								goto end_IL_0008;
							case 5:
								goto IL_0103;
							case 7:
								goto end_IL_0008;
							}
							break;
						}
						goto default;
						IL_0103:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
						num = -1680794324;
						goto IL_001e;
						IL_0057:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategories != null && syCPfFbHYMDOvEPjTnPLBqiOhsPv.actions != null)
						{
							SQmuElBWhNrhrhdYlfiyrZTuFzD = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionCategoryMap.ActionIdsInCategory(tvvERjRcrFQoLeSRWZgxEcxZOWL).GetEnumerator();
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							num = -1680794324;
							goto IL_001e;
						}
						goto IL_004e;
						IL_004e:
						result = false;
						num = -1680794325;
						goto IL_001e;
						end_IL_0008:
						break;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						fRLclUaJSMFwNFJXAcRbSkQfivqH();
					}
				}
			}

			[DebuggerHidden]
			public wEbpVSktomGeQgVvJoJZyVuWgXC(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void fRLclUaJSMFwNFJXAcRbSkQfivqH()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (SQmuElBWhNrhrhdYlfiyrZTuFzD != null)
				{
					SQmuElBWhNrhrhdYlfiyrZTuFzD.Dispose();
				}
			}
		}

		private sealed class JhDtNuqqZxQcYeCGrCfyzLgsFUA
		{
			private sealed class puhMkHpqqRqIcloTGlyAImxxhve
			{
				public JhDtNuqqZxQcYeCGrCfyzLgsFUA KJZxTYorytFaaOrlPzvgBrzwRhU;

				public ControllerMap_Editor rattTiJVMfrlkuegiThkhLtmwyl;

				public ControllerMap_Editor ZNmiScpIVNoaJXUmXRGYlfkADLj;

				public bool yqpnWhKduvnTVSGAUfRHxeiAYVL(InputLayout P_0)
				{
					return P_0.id == rattTiJVMfrlkuegiThkhLtmwyl.id;
				}

				public bool JXyhQuNEsJaBYxMpwrFKBBvIcZaC(InputLayout P_0)
				{
					return P_0.id == ZNmiScpIVNoaJXUmXRGYlfkADLj.id;
				}
			}

			public List<InputLayout> dyyTLtsXFbRnqBwdyGfQnnsGeYxi;

			public int ptmzQtpxNPKSKRBYzCvQlqCJHaQ(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				puhMkHpqqRqIcloTGlyAImxxhve puhMkHpqqRqIcloTGlyAImxxhve2 = new puhMkHpqqRqIcloTGlyAImxxhve();
				puhMkHpqqRqIcloTGlyAImxxhve2.KJZxTYorytFaaOrlPzvgBrzwRhU = this;
				puhMkHpqqRqIcloTGlyAImxxhve2.rattTiJVMfrlkuegiThkhLtmwyl = P_0;
				puhMkHpqqRqIcloTGlyAImxxhve2.ZNmiScpIVNoaJXUmXRGYlfkADLj = P_1;
				int num = dyyTLtsXFbRnqBwdyGfQnnsGeYxi.FindIndex(puhMkHpqqRqIcloTGlyAImxxhve2.yqpnWhKduvnTVSGAUfRHxeiAYVL);
				int num2 = dyyTLtsXFbRnqBwdyGfQnnsGeYxi.FindIndex(puhMkHpqqRqIcloTGlyAImxxhve2.JXyhQuNEsJaBYxMpwrFKBBvIcZaC);
				if (num > num2)
				{
					return 1;
				}
				if (num < num2)
				{
					return -1;
				}
				return 0;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ConfigVars configVars = new ConfigVars();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Player_Editor> players = new List<Player_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputAction> actions = new List<InputAction>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputCategory> actionCategories = new List<InputCategory>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ActionCategoryMap actionCategoryMap = new ActionCategoryMap();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputBehavior> inputBehaviors = new List<InputBehavior>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputMapCategory> mapCategories = new List<InputMapCategory>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputLayout> joystickLayouts = new List<InputLayout>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputLayout> keyboardLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> mouseLayouts = new List<InputLayout>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputLayout> customControllerLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> joystickMaps = new List<ControllerMap_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMap_Editor> keyboardMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> mouseMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> customControllerMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CustomController_Editor> customControllers = new List<CustomController_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = new List<ControllerMapLayoutManager_RuleSet_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = new List<ControllerMapEnabler_RuleSet_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int playerIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int actionIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int actionCategoryIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int inputBehaviorIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int mapCategoryIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int joystickLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int keyboardLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int mouseLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int customControllerLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int joystickMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int keyboardMapIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int mouseMapIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int customControllerMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int controllerMapLayoutManagerSetIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int controllerMapEnablerSetIdCounter;

		private Func<int, bool> containsActionDelegate;

		[CompilerGenerated]
		private static Action<List<Player_Editor.Mapping>, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate60;

		[CompilerGenerated]
		private static Action<List<Player_Editor.Mapping>, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate62;

		[CompilerGenerated]
		private static Action<List<Player_Editor.Mapping>, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate64;

		[CompilerGenerated]
		private static Action<List<Player_Editor.Mapping>, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate66;

		[CompilerGenerated]
		private static Action<List<Player_Editor.Mapping>, int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate68;

		internal IList<Player_Editor> Players_readOnly { get; private set; }

		internal IList<InputAction> Actions_readOnly { get; private set; }

		internal IList<InputCategory> ActionCategories_readOnly { get; private set; }

		internal IList<InputBehavior> InputBehaviors_readOnly { get; private set; }

		internal IList<InputMapCategory> MapCategories_readOnly { get; private set; }

		internal IList<InputLayout> JoystickLayouts_readOnly { get; private set; }

		internal IList<InputLayout> KeyboardLayouts_readOnly { get; private set; }

		internal IList<InputLayout> MouseLayouts_readOnly { get; private set; }

		internal IList<InputLayout> CustomControllerLayouts_readOnly { get; private set; }

		internal IList<ControllerMap_Editor> JoystickMaps_readOnly { get; private set; }

		internal IList<ControllerMap_Editor> KeyboardMaps_readOnly { get; private set; }

		internal IList<ControllerMap_Editor> MouseMaps_readOnly { get; private set; }

		internal IList<ControllerMap_Editor> CustomControllerMaps_readOnly { get; private set; }

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> ControllerMapLayoutManagerRuleSets_readOnly { get; private set; }

		internal IList<ControllerMapEnabler_RuleSet_Editor> ControllerMapEnablerRuleSets_readOnly { get; private set; }

		public ConfigVars ConfigVars => configVars;

		internal IEnumerable<InputMapCategory> UserAssignableMapCategories
		{
			get
			{
				DQbFTPIHgeborXIsDlmNwibFUAVb dQbFTPIHgeborXIsDlmNwibFUAVb = new DQbFTPIHgeborXIsDlmNwibFUAVb(-2);
				dQbFTPIHgeborXIsDlmNwibFUAVb.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return dQbFTPIHgeborXIsDlmNwibFUAVb;
			}
		}

		internal IEnumerable<InputCategory> UserAssignableActionCategories
		{
			get
			{
				DVdYLLtCmywgomAsLMvrUxzpkId dVdYLLtCmywgomAsLMvrUxzpkId = new DVdYLLtCmywgomAsLMvrUxzpkId(-2);
				dVdYLLtCmywgomAsLMvrUxzpkId.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return dVdYLLtCmywgomAsLMvrUxzpkId;
			}
		}

		internal IEnumerable<InputAction> UserAssignableActions
		{
			get
			{
				siutILmAORiaCxUYHvdwREYvukr siutILmAORiaCxUYHvdwREYvukr2 = new siutILmAORiaCxUYHvdwREYvukr(-2);
				siutILmAORiaCxUYHvdwREYvukr2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return siutILmAORiaCxUYHvdwREYvukr2;
			}
		}

		public int playerCount
		{
			get
			{
				if (players == null)
				{
					return 0;
				}
				return players.Count;
			}
		}

		internal IEnumerable<InputMapCategory> IfiNsBMejUeufcxVpwnTPNuJLBhh(string P_0)
		{
			DnWNkxKGGbbFZiNhCMLPORqMHtC dnWNkxKGGbbFZiNhCMLPORqMHtC = new DnWNkxKGGbbFZiNhCMLPORqMHtC(-2);
			dnWNkxKGGbbFZiNhCMLPORqMHtC.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			dnWNkxKGGbbFZiNhCMLPORqMHtC.mroBMnpLwxbiAaSJwonEBCTLKqFQ = P_0;
			return dnWNkxKGGbbFZiNhCMLPORqMHtC;
		}

		internal IEnumerable<InputMapCategory> sajQIsOWHJkOuqGIGeBhlwaKwd(string P_0)
		{
			jgRgNCWeSnjPQaOkhGSWjyeHNwQh jgRgNCWeSnjPQaOkhGSWjyeHNwQh2 = new jgRgNCWeSnjPQaOkhGSWjyeHNwQh(-2);
			jgRgNCWeSnjPQaOkhGSWjyeHNwQh2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			jgRgNCWeSnjPQaOkhGSWjyeHNwQh2.mroBMnpLwxbiAaSJwonEBCTLKqFQ = P_0;
			return jgRgNCWeSnjPQaOkhGSWjyeHNwQh2;
		}

		internal IEnumerable<InputCategory> wBDOFeXdBIBakVRmvTpdwkLODAC(string P_0)
		{
			nKUTaDZGHUIFIUfvrsTSKGIStns nKUTaDZGHUIFIUfvrsTSKGIStns2 = new nKUTaDZGHUIFIUfvrsTSKGIStns(-2);
			nKUTaDZGHUIFIUfvrsTSKGIStns2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			while (true)
			{
				int num = -2131450710;
				while (true)
				{
					switch (num ^ -2131450709)
					{
					case 0:
						break;
					case 1:
						goto IL_002d;
					default:
						return nKUTaDZGHUIFIUfvrsTSKGIStns2;
					}
					break;
					IL_002d:
					nKUTaDZGHUIFIUfvrsTSKGIStns2.mroBMnpLwxbiAaSJwonEBCTLKqFQ = P_0;
					num = -2131450711;
				}
			}
		}

		internal IEnumerable<InputCategory> GXaKhZUEomwUIWnmPLgoLAYSzhz(string P_0)
		{
			dLgopYYCyWelwmktciUIgoJBlls dLgopYYCyWelwmktciUIgoJBlls2 = new dLgopYYCyWelwmktciUIgoJBlls(-2);
			dLgopYYCyWelwmktciUIgoJBlls2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			dLgopYYCyWelwmktciUIgoJBlls2.mroBMnpLwxbiAaSJwonEBCTLKqFQ = P_0;
			return dLgopYYCyWelwmktciUIgoJBlls2;
		}

		internal IEnumerable<InputAction> bOufmmFjcvQxjzsprBazBUMMMgx(int P_0, bool P_1)
		{
			ZiEoVwEbJDjlFbtYfOoTRQlLbEOv ziEoVwEbJDjlFbtYfOoTRQlLbEOv = new ZiEoVwEbJDjlFbtYfOoTRQlLbEOv(-2);
			ziEoVwEbJDjlFbtYfOoTRQlLbEOv.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			ziEoVwEbJDjlFbtYfOoTRQlLbEOv.zPhuvRFWpUfcIWTdRFhNtaCMeLD = P_0;
			ziEoVwEbJDjlFbtYfOoTRQlLbEOv.yNxIFThAEWeBKEVxRXYFmEMVVoPf = P_1;
			return ziEoVwEbJDjlFbtYfOoTRQlLbEOv;
		}

		internal IEnumerable<InputAction> bOufmmFjcvQxjzsprBazBUMMMgx(string P_0, bool P_1)
		{
			NquaPOXolrXLlxGOIHlQEgUaOck nquaPOXolrXLlxGOIHlQEgUaOck = new NquaPOXolrXLlxGOIHlQEgUaOck(-2);
			nquaPOXolrXLlxGOIHlQEgUaOck.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			nquaPOXolrXLlxGOIHlQEgUaOck.taBUSBtfawhvQgJYbELnaTVouyIE = P_0;
			nquaPOXolrXLlxGOIHlQEgUaOck.yNxIFThAEWeBKEVxRXYFmEMVVoPf = P_1;
			return nquaPOXolrXLlxGOIHlQEgUaOck;
		}

		internal IEnumerable<InputAction> wKLrKmkVBVKnSBlqcArVbRbNkwWq(string P_0)
		{
			IJAmTwbWZstaOssQSYHQUiWKOlR iJAmTwbWZstaOssQSYHQUiWKOlR = new IJAmTwbWZstaOssQSYHQUiWKOlR(-2);
			iJAmTwbWZstaOssQSYHQUiWKOlR.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			iJAmTwbWZstaOssQSYHQUiWKOlR.mroBMnpLwxbiAaSJwonEBCTLKqFQ = P_0;
			return iJAmTwbWZstaOssQSYHQUiWKOlR;
		}

		internal IEnumerable<InputAction> OXWMWqjANCeuPcmgxsxrtJEFSoh(int P_0, bool P_1)
		{
			HmmtlPdCqfcaXvqAxSTQFSMZqTK hmmtlPdCqfcaXvqAxSTQFSMZqTK = new HmmtlPdCqfcaXvqAxSTQFSMZqTK(-2);
			hmmtlPdCqfcaXvqAxSTQFSMZqTK.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			hmmtlPdCqfcaXvqAxSTQFSMZqTK.zPhuvRFWpUfcIWTdRFhNtaCMeLD = P_0;
			hmmtlPdCqfcaXvqAxSTQFSMZqTK.yNxIFThAEWeBKEVxRXYFmEMVVoPf = P_1;
			return hmmtlPdCqfcaXvqAxSTQFSMZqTK;
		}

		internal IEnumerable<InputAction> OXWMWqjANCeuPcmgxsxrtJEFSoh(string P_0, bool P_1)
		{
			OMoBXwzaJAzTpXGkBeBnbgQQyzZS oMoBXwzaJAzTpXGkBeBnbgQQyzZS = new OMoBXwzaJAzTpXGkBeBnbgQQyzZS(-2);
			oMoBXwzaJAzTpXGkBeBnbgQQyzZS.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			oMoBXwzaJAzTpXGkBeBnbgQQyzZS.wDpkpKdUlIImNFhvGmPMElLmfhDe = P_0;
			oMoBXwzaJAzTpXGkBeBnbgQQyzZS.yNxIFThAEWeBKEVxRXYFmEMVVoPf = P_1;
			return oMoBXwzaJAzTpXGkBeBnbgQQyzZS;
		}

		public UserData()
			: this(init: true)
		{
		}

		private UserData(bool init)
		{
			Player_Editor player_Editor = default(Player_Editor);
			InputCategory inputCategory = default(InputCategory);
			InputLayout inputLayout2 = default(InputLayout);
			InputLayout inputLayout = default(InputLayout);
			InputLayout inputLayout3 = default(InputLayout);
			InputMapCategory inputMapCategory = default(InputMapCategory);
			while (true)
			{
				int num = -853539729;
				while (true)
				{
					switch (num ^ -853539736)
					{
					case 2:
						break;
					default:
						return;
					case 9:
						player_Editor.excludeFromControllerAutoAssignment = true;
						players.Add(player_Editor);
						inputCategory = DbDeQrHYlCiwsfJAzFhltqwKFGMu();
						num = -853539741;
						continue;
					case 1:
						inputLayout2.name = "Default";
						inputLayout2.descriptiveName = inputLayout2.name;
						mouseLayouts.Add(inputLayout2);
						inputLayout = hLYVpAShAueSrhirvyEpLlBiSSra();
						inputLayout.name = "Default";
						num = -853539732;
						continue;
					case 8:
					{
						joystickLayouts.Add(inputLayout3);
						InputLayout inputLayout4 = QLRyeYPFXCVPOfCCmiNpChRiwNOa();
						inputLayout4.name = "Default";
						inputLayout4.descriptiveName = inputLayout4.name;
						keyboardLayouts.Add(inputLayout4);
						inputLayout2 = sVWOdrUnBQIviCODztlqJGKNDrck();
						num = -853539735;
						continue;
					}
					case 11:
					{
						inputCategory.name = "Default";
						inputCategory.descriptiveName = inputCategory.name;
						actionCategories.Add(inputCategory);
						actionCategoryMap.AddCategory(inputCategory.id);
						InputBehavior inputBehavior = kUbhbGbdwKrODdTxKxOACHtcfLEI();
						inputBehavior.name = "Default";
						inputBehaviors.Add(inputBehavior);
						inputMapCategory = afQWIFPueftpztHVacesdOnQNEsb();
						num = -853539742;
						continue;
					}
					case 7:
						if (init)
						{
							configVars.updateLoop = UpdateLoopSetting.Update;
							configVars.defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;
							num = -853539736;
							continue;
						}
						return;
					case 0:
						configVars.defaultJoystickAxis2DSensitivityType = AxisSensitivity2DType.Radial;
						num = -853539731;
						continue;
					case 3:
						inputLayout3 = tKoSqohFtTtmilugrShVUkmbvqi();
						inputLayout3.name = "Default";
						inputLayout3.descriptiveName = inputLayout3.name;
						num = -853539744;
						continue;
					case 10:
						inputMapCategory.name = "Default";
						inputMapCategory.descriptiveName = inputMapCategory.name;
						mapCategories.Add(inputMapCategory);
						num = -853539733;
						continue;
					case 5:
						player_Editor = GMFgMaBPCvuifRlcLbgjOQcrNXBY();
						player_Editor.name = "System";
						player_Editor.descriptiveName = player_Editor.name;
						player_Editor.id = 9999999;
						player_Editor.startPlaying = true;
						player_Editor.assignMouseOnStart = true;
						player_Editor.assignKeyboardOnStart = true;
						num = -853539743;
						continue;
					case 4:
						inputLayout.descriptiveName = inputLayout.name;
						customControllerLayouts.Add(inputLayout2);
						num = -853539730;
						continue;
					case 6:
						return;
					}
					break;
				}
			}
		}

		public List<InputAction> GetActions_Copy()
		{
			List<InputAction> list = new List<InputAction>();
			int num = 0;
			while (num < actions.Count)
			{
				while (true)
				{
					list.Add(actions[num]);
					num++;
					int num2 = -1910902743;
					while (true)
					{
						switch (num2 ^ -1910902741)
						{
						case 0:
							num2 = -1910902742;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0028;
						}
						break;
					}
					continue;
					end_IL_0028:
					break;
				}
			}
			return list;
		}

		public List<InputBehavior> GetInputBehaviors_Copy()
		{
			List<InputBehavior> list = new List<InputBehavior>();
			int num2 = default(int);
			while (true)
			{
				int num = 977612101;
				while (true)
				{
					switch (num ^ 0x3A452D46)
					{
					case 0:
						break;
					case 3:
						num2 = 0;
						num = 977612103;
						continue;
					case 2:
						list.Add(inputBehaviors[num2].Clone());
						num2++;
						num = 977612103;
						continue;
					default:
						if (num2 >= inputBehaviors.Count)
						{
							return list;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public List<KeyboardMap> GetKeyboardMaps_Copy()
		{
			List<KeyboardMap> list = new List<KeyboardMap>();
			int num = 0;
			KeyboardMap item = default(KeyboardMap);
			while (true)
			{
				int num2 = -1699350037;
				while (true)
				{
					switch (num2 ^ -1699350033)
					{
					case 0:
						break;
					case 2:
						list.Add(item);
						num++;
						num2 = -1699350034;
						continue;
					case 3:
						item = keyboardMaps[num].WemcRkNxcNeYUDQGmfpkctxNHTu(containsActionDelegate);
						num2 = -1699350035;
						continue;
					case 4:
						num2 = -1699350034;
						continue;
					default:
						if (num >= keyboardMaps.Count)
						{
							return list;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			int num = 0;
			MouseMap item = default(MouseMap);
			while (true)
			{
				int num2 = 242889608;
				while (true)
				{
					switch (num2 ^ 0xE7A3389)
					{
					case 2:
						break;
					case 1:
						num2 = 242889610;
						continue;
					case 4:
						list.Add(item);
						num++;
						num2 = 242889610;
						continue;
					case 3:
					{
						int num3;
						if (num < mouseMaps.Count)
						{
							num2 = 242889609;
							num3 = num2;
						}
						else
						{
							num2 = 242889612;
							num3 = num2;
						}
						continue;
					}
					case 0:
						item = mouseMaps[num].JssclkKWoJeoDnDTqRbfzmxMBpq(containsActionDelegate);
						num2 = 242889613;
						continue;
					default:
						return list;
					}
					break;
				}
			}
		}

		public void AddPlayer()
		{
			players.Add(GMFgMaBPCvuifRlcLbgjOQcrNXBY());
		}

		public void InsertPlayer(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = 474284312;
					while (true)
					{
						switch (num ^ 0x1C450119)
						{
						case 0:
							break;
						case 1:
							goto IL_0026;
						case 2:
							goto end_IL_0004;
						default:
							players.Insert(index, GMFgMaBPCvuifRlcLbgjOQcrNXBY());
							return;
						}
						break;
						IL_0026:
						int num2;
						if (index < players.Count)
						{
							num = 474284314;
							num2 = num;
						}
						else
						{
							num = 474284315;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeletePlayer(int index)
		{
			if (players != null && index >= 0)
			{
				if (index < players.Count)
				{
					goto IL_004a;
				}
				while (true)
				{
					switch (0x6EAF6D58 ^ 0x6EAF6D5A)
					{
					case 0:
						break;
					case 2:
						goto end_IL_001a;
					default:
						goto IL_004a;
					}
					continue;
					end_IL_001a:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_004a:
			players.RemoveAt(index);
		}

		public bool ReorderPlayer(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(players, index, offsetDown, offsetNow);
		}

		public void DuplicatePlayer(int index)
		{
			if (players != null)
			{
				Player_Editor player_Editor = default(Player_Editor);
				while (true)
				{
					int num = 929790706;
					while (true)
					{
						switch (num ^ 0x376B7AF3)
						{
						case 4:
							break;
						case 1:
							goto IL_0035;
						case 5:
							goto end_IL_0008;
						case 0:
							player_Editor.id = GetNewPlayerId();
							player_Editor.name = StringTools.IterateName(player_Editor.name, -1, GetPlayerNames());
							player_Editor.assignMouseOnStart = false;
							if (index == players.Count - 1)
							{
								players.Add(player_Editor);
								return;
							}
							goto default;
						case 2:
							player_Editor = players[index].Clone();
							num = 929790707;
							continue;
						default:
							players.Insert(index + 1, player_Editor);
							return;
						}
						break;
						IL_0035:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num2;
						if (index >= players.Count)
						{
							num = 929790710;
							num2 = num;
						}
						else
						{
							num = 929790705;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public string[] GetPlayerNames()
		{
			if (players == null)
			{
				goto IL_0008;
			}
			string[] array = new string[players.Count];
			int num = 0;
			int num2 = -1417523324;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1417523321)
				{
				case 0:
					break;
				case 2:
					return null;
				case 1:
					array[num] = players[num].name;
					num++;
					num2 = -1417523325;
					continue;
				case 3:
					num2 = -1417523325;
					continue;
				default:
					if (num >= players.Count)
					{
						return array;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1417523323;
			goto IL_000d;
		}

		public int GetPlayerNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			int num2 = default(int);
			while (true)
			{
				results.Clear();
				int num;
				if (players == null)
				{
					num = -1993430272;
				}
				else
				{
					num2 = 0;
					num = -1993430265;
				}
				while (true)
				{
					switch (num ^ -1993430269)
					{
					case 0:
						num = -1993430270;
						continue;
					case 1:
						break;
					case 3:
						return 0;
					case 2:
						results.Add(players[num2].name);
						num2++;
						num = -1993430265;
						continue;
					default:
						if (num2 >= players.Count)
						{
							return results.Count;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int[] GetPlayerIds()
		{
			if (players == null)
			{
				return null;
			}
			int[] array = new int[players.Count];
			int num2 = default(int);
			while (true)
			{
				int num = -734994441;
				while (true)
				{
					switch (num ^ -734994444)
					{
					case 0:
						break;
					case 3:
						num2 = 0;
						num = -734994448;
						continue;
					case 1:
						num2++;
						num = -734994448;
						continue;
					case 2:
						array[num2] = players[num2].id;
						num = -734994443;
						continue;
					default:
						if (num2 >= players.Count)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int[] GetPlayerRuntimeIds()
		{
			if (players == null)
			{
				return null;
			}
			int[] array = new int[players.Count];
			int num = 0;
			while (num < players.Count)
			{
				while (true)
				{
					int num2;
					if (num == 0)
					{
						array[num] = 9999999;
						num2 = 1712512395;
						goto IL_0024;
					}
					goto IL_0062;
					IL_0024:
					while (true)
					{
						switch (num2 ^ 0x6612DD8B)
						{
						case 2:
							num2 = 1712512394;
							continue;
						case 1:
							break;
						case 0:
							num++;
							num2 = 1712512399;
							continue;
						case 3:
							goto IL_0062;
						default:
							goto end_IL_0045;
						}
						break;
					}
					continue;
					IL_0062:
					array[num] = num - 1;
					num2 = 1712512395;
					goto IL_0024;
					continue;
					end_IL_0045:
					break;
				}
			}
			return array;
		}

		public int GetPlayerRuntimeIds(IList<int> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = default(int);
			while (true)
			{
				results.Clear();
				int num2;
				if (players != null)
				{
					num = 0;
					num2 = -1116247479;
				}
				else
				{
					num2 = -1116247478;
				}
				while (true)
				{
					switch (num2 ^ -1116247478)
					{
					case 2:
						num2 = -1116247477;
						continue;
					case 3:
						num2 = -1116247473;
						continue;
					case 0:
						return 0;
					case 5:
					{
						int num3;
						if (num < players.Count)
						{
							num2 = -1116247474;
							num3 = num2;
						}
						else
						{
							num2 = -1116247486;
							num3 = num2;
						}
						continue;
					}
					case 6:
						num++;
						num2 = -1116247473;
						continue;
					case 7:
						results.Add(num - 1);
						num2 = -1116247476;
						continue;
					case 1:
						break;
					case 4:
						if (num == 0)
						{
							results.Add(9999999);
							num2 = -1116247476;
							continue;
						}
						goto case 7;
					default:
						return results.Count;
					}
					break;
				}
			}
		}

		public string GetPlayerNameById(int id)
		{
			if (players == null)
			{
				return string.Empty;
			}
			int num = 0;
			while (num < players.Count)
			{
				while (true)
				{
					if (players[num].id == id)
					{
						return players[num].name;
					}
					num++;
					int num2 = 1915600463;
					while (true)
					{
						switch (num2 ^ 0x722DBE4D)
						{
						case 0:
							num2 = 1915600460;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return string.Empty;
		}

		public Player_Editor GetPlayer(int index)
		{
			if (players != null)
			{
				while (true)
				{
					int num = -1507318914;
					while (true)
					{
						switch (num ^ -1507318913)
						{
						case 3:
							break;
						case 1:
							goto IL_002a;
						case 2:
							goto IL_003f;
						default:
							goto end_IL_0008;
						}
						break;
						IL_003f:
						if (index >= players.Count)
						{
							num = -1507318913;
							continue;
						}
						return players[index];
						IL_002a:
						int num2;
						if (index >= 0)
						{
							num = -1507318915;
							num2 = num;
						}
						else
						{
							num = -1507318913;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public int GetPlayerId(string name)
		{
			if (players == null)
			{
				return -1;
			}
			int num = 0;
			while (num < players.Count)
			{
				while (true)
				{
					int num2;
					if (players[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
					{
						num2 = -1442953649;
					}
					else
					{
						num++;
						num2 = -1442953652;
					}
					while (true)
					{
						switch (num2 ^ -1442953650)
						{
						case 0:
							num2 = -1442953651;
							continue;
						case 3:
							break;
						case 1:
							return players[num].id;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return -1;
		}

		public bool IsMouseAssigned()
		{
			if (players == null)
			{
				goto IL_0008;
			}
			int count = players.Count;
			int num = 0;
			int num2 = 1457706012;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x56E2D418)
				{
				case 3:
					break;
				case 1:
					return false;
				case 4:
					num2 = 1457706013;
					continue;
				case 5:
				{
					int num3;
					if (num >= count)
					{
						num2 = 1457706008;
						num3 = num2;
					}
					else
					{
						num2 = 1457706010;
						num3 = num2;
					}
					continue;
				}
				case 2:
					if (players[num].assignMouseOnStart)
					{
						return true;
					}
					num++;
					num2 = 1457706013;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1457706009;
			goto IL_000d;
		}

		public void ClearMouseAssignments()
		{
			if (players == null)
			{
				return;
			}
			while (true)
			{
				int count = players.Count;
				int num = 0;
				int num2 = -1347344601;
				while (true)
				{
					switch (num2 ^ -1347344604)
					{
					case 0:
						num2 = -1347344608;
						continue;
					default:
						return;
					case 1:
						players[num].assignMouseOnStart = false;
						num++;
						num2 = -1347344607;
						continue;
					case 3:
						num2 = -1347344607;
						continue;
					case 5:
					{
						int num3;
						if (num < count)
						{
							num2 = -1347344603;
							num3 = num2;
						}
						else
						{
							num2 = -1347344602;
							num3 = num2;
						}
						continue;
					}
					case 4:
						break;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public bool IsKeyboardAssigned()
		{
			if (players == null)
			{
				return false;
			}
			int count = players.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -308795668;
				while (true)
				{
					switch (num ^ -308795667)
					{
					case 3:
						break;
					case 4:
						if (players[num2].assignKeyboardOnStart)
						{
							num = -308795665;
							continue;
						}
						num2++;
						num = -308795667;
						continue;
					case 5:
						num = -308795667;
						continue;
					case 2:
						return true;
					case 1:
						num2 = 0;
						num = -308795672;
						continue;
					default:
						if (num2 >= count)
						{
							return false;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public void ClearKeyboardAssignments()
		{
			if (players == null)
			{
				return;
			}
			while (true)
			{
				int count = players.Count;
				int num = 0;
				int num2 = 146233695;
				while (true)
				{
					switch (num2 ^ 0x8B7595D)
					{
					case 3:
						num2 = 146233692;
						continue;
					case 1:
						break;
					case 0:
						players[num].assignKeyboardOnStart = false;
						num++;
						num2 = 146233695;
						continue;
					default:
						if (num >= count)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public void AddAction(int categoryId)
		{
			InputAction inputAction = cPgmfrekjKGfnBEDAFmVdUFItHSe();
			inputAction.categoryId = categoryId;
			actions.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (actions == null)
			{
				return;
			}
			while (true)
			{
				InputAction inputAction = cPgmfrekjKGfnBEDAFmVdUFItHSe();
				inputAction.categoryId = categoryId;
				actions.Add(inputAction);
				int index = actionCategoryMap.IndexOfAction(categoryId, actionId);
				actionCategoryMap.InsertAction(categoryId, inputAction.id, index);
				int num = -582700475;
				while (true)
				{
					switch (num ^ -582700475)
					{
					case 2:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0009:
					num = -582700476;
				}
			}
		}

		public void DeleteAction(int categoryId, int actionId)
		{
			int num = IndexOfActionCategory(categoryId);
			if (num < 0)
			{
				return;
			}
			while (true)
			{
				int num2 = IndexOfAction(actionId);
				int num3;
				int num4;
				if (num2 >= 0)
				{
					num3 = -595428697;
					num4 = num3;
				}
				else
				{
					num3 = -595428699;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ -595428697)
					{
					case 5:
						num3 = -595428701;
						continue;
					default:
						return;
					case 4:
						break;
					case 1:
						actionCategoryMap.RemoveAction(categoryId, actionId);
						num3 = -595428700;
						continue;
					case 2:
						return;
					case 0:
						actions.RemoveAt(num2);
						num3 = -595428698;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			return actionCategoryMap.ReorderAction(categoryId, actionId, offsetDown, offsetNow);
		}

		public int DuplicateAction_FromButton(int categoryId, int actionId)
		{
			int num = IndexOfActionCategory(categoryId);
			if (num < 0)
			{
				return -1;
			}
			int num2 = IndexOfAction(actionId);
			InputAction actionById = default(InputAction);
			InputAction inputAction = default(InputAction);
			while (true)
			{
				int num3 = 216134898;
				while (true)
				{
					switch (num3 ^ 0xCE1F4F4)
					{
					case 7:
						break;
					case 6:
						if (num2 < 0)
						{
							num3 = 216134903;
							continue;
						}
						actionById = GetActionById(actionId);
						num3 = 216134901;
						continue;
					case 5:
						actionCategoryMap.AddAction(categoryId, inputAction.id);
						num3 = 216134900;
						continue;
					case 1:
						if (actionById == null)
						{
							num3 = 216134902;
							continue;
						}
						inputAction = actionById.Clone();
						inputAction.id = GetNewActionId();
						num3 = 216134896;
						continue;
					case 2:
						return -1;
					case 4:
					{
						inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
						if (num2 == actions.Count - 1)
						{
							actions.Add(inputAction);
							num3 = 216134897;
							continue;
						}
						actions.Insert(num2 + 1, inputAction);
						int num4 = actionCategoryMap.IndexOfAction(categoryId, actionId);
						actionCategoryMap.InsertAction(categoryId, inputAction.id, num4 + 1);
						return num2 + 1;
					}
					case 3:
						return -1;
					default:
						return actions.Count - 1;
					}
					break;
				}
			}
		}

		private int jMhXxLmEOoOtDTLOgcYzCkoPFDL(int P_0, InputAction P_1)
		{
			int num = IndexOfActionCategory(P_0);
			if (num < 0)
			{
				return -1;
			}
			InputAction inputAction = P_1.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			actions.Add(inputAction);
			return actions.Count - 1;
		}

		public string[] GetActionNames()
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			string[] array = new string[actions.Count];
			int num = 0;
			int num2 = 1629480060;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x611FE479)
				{
				case 0:
					break;
				case 2:
					array[num] = actions[num].name;
					num2 = 1629480058;
					continue;
				case 5:
					num2 = 1629480056;
					continue;
				case 3:
					num++;
					num2 = 1629480056;
					continue;
				case 4:
					return null;
				default:
					if (num >= actions.Count)
					{
						return array;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1629480061;
			goto IL_000d;
		}

		public int GetActionNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			while (true)
			{
				results.Clear();
				if (actions == null)
				{
					break;
				}
				int num = 0;
				int num2 = 214686675;
				while (true)
				{
					switch (num2 ^ 0xCCBDBD1)
					{
					case 0:
						num2 = 214686672;
						continue;
					case 1:
						break;
					case 3:
						results.Add(actions[num].name);
						num++;
						num2 = 214686675;
						continue;
					default:
						if (num >= actions.Count)
						{
							return results.Count;
						}
						goto case 3;
					}
					break;
				}
			}
			return 0;
		}

		public int[] GetActionIds()
		{
			if (actions == null)
			{
				return null;
			}
			int[] array = new int[actions.Count];
			int num2 = default(int);
			while (true)
			{
				int num = -769896226;
				while (true)
				{
					switch (num ^ -769896225)
					{
					case 2:
						break;
					case 1:
						num2 = 0;
						num = -769896228;
						continue;
					case 0:
						array[num2] = actions[num2].id;
						num2++;
						num = -769896228;
						continue;
					default:
						if (num2 >= actions.Count)
						{
							return array;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public int GetActionIds(IList<int> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			while (true)
			{
				results.Clear();
				if (actions == null)
				{
					break;
				}
				int num = 0;
				int num2 = 1833670706;
				while (true)
				{
					switch (num2 ^ 0x6D4B9831)
					{
					case 2:
						num2 = 1833670709;
						continue;
					case 4:
						break;
					case 3:
						num2 = 1833670704;
						continue;
					case 0:
						results.Add(actions[num].id);
						num++;
						num2 = 1833670704;
						continue;
					default:
						if (num >= actions.Count)
						{
							return results.Count;
						}
						goto case 0;
					}
					break;
				}
			}
			return 0;
		}

		public string GetActionNameById(int id)
		{
			if (actions == null)
			{
				return string.Empty;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1046018002;
				while (true)
				{
					switch (num2 ^ -1046018001)
					{
					case 0:
						break;
					case 1:
						num2 = -1046018003;
						continue;
					case 3:
						if (actions[num].id == id)
						{
							return actions[num].name;
						}
						num++;
						num2 = -1046018003;
						continue;
					default:
						if (num >= actions.Count)
						{
							return string.Empty;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public InputAction GetAction(int index)
		{
			if (actions == null || index < 0 || index >= actions.Count)
			{
				return null;
			}
			return actions[index];
		}

		public InputAction GetAction(string name)
		{
			if (actions == null)
			{
				return null;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return null;
			}
			return actions[num];
		}

		public InputAction GetActionById(int id)
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1648582287;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1648582288)
				{
				case 0:
					break;
				case 2:
					return null;
				case 1:
				{
					int num3;
					if (num >= actions.Count)
					{
						num2 = -1648582285;
						num3 = num2;
					}
					else
					{
						num2 = -1648582284;
						num3 = num2;
					}
					continue;
				}
				case 4:
					if (actions[num].id == id)
					{
						return actions[num];
					}
					num++;
					num2 = -1648582287;
					continue;
				default:
					return null;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1648582286;
			goto IL_000d;
		}

		public int GetActionId(string name)
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			int num = IndexOfAction(name);
			int num2 = -141973225;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ -141973225)
			{
			case 2:
				break;
			case 1:
				return -1;
			default:
				if (num < 0)
				{
					return -1;
				}
				return actions[num].id;
			}
			goto IL_0008;
			IL_0008:
			num2 = -141973226;
			goto IL_000d;
		}

		public string[] GetSortedActionNamesInCategory(int id)
		{
			List<string> list = default(List<string>);
			int num;
			if (actionCategories != null)
			{
				if (actions == null)
				{
					goto IL_0010;
				}
				list = new List<string>();
				num = -1870816853;
				goto IL_0015;
			}
			goto IL_002e;
			IL_0015:
			switch (num ^ -1870816853)
			{
			case 2:
				break;
			case 1:
				goto IL_002e;
			default:
			{
				using (IEnumerator<int> enumerator = actionCategoryMap.ActionIdsInCategory(id).GetEnumerator())
				{
					while (true)
					{
						IL_0098:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = -1870816854;
							num3 = num2;
						}
						else
						{
							num2 = -1870816856;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1870816853)
							{
							case 2:
								num2 = -1870816856;
								continue;
							default:
								goto end_IL_0056;
							case 3:
							{
								int current = enumerator.Current;
								InputAction actionById = GetActionById(current);
								if (actionById != null)
								{
									list.Add(actionById.name);
									num2 = -1870816853;
									continue;
								}
								break;
							}
							case 0:
								break;
							case 1:
								goto end_IL_0056;
							}
							goto IL_0098;
							continue;
							end_IL_0056:
							break;
						}
						break;
					}
				}
				return list.ToArray();
			}
			}
			goto IL_0010;
			IL_002e:
			return null;
			IL_0010:
			num = -1870816854;
			goto IL_0015;
		}

		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			psOFBWNsZOgOIaYQbjwTJcbJkalf psOFBWNsZOgOIaYQbjwTJcbJkalf2 = new psOFBWNsZOgOIaYQbjwTJcbJkalf(-2);
			psOFBWNsZOgOIaYQbjwTJcbJkalf2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			psOFBWNsZOgOIaYQbjwTJcbJkalf2.HEjtFCDQuzjqYEUuHIHEKiXWBfw = id;
			return psOFBWNsZOgOIaYQbjwTJcbJkalf2;
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			List<string> list = default(List<string>);
			int num;
			if (actionCategories != null)
			{
				if (actions == null)
				{
					goto IL_0010;
				}
				list = new List<string>();
				num = -427108705;
				goto IL_0015;
			}
			goto IL_002e;
			IL_0015:
			switch (num ^ -427108707)
			{
			case 0:
				break;
			case 1:
				goto IL_002e;
			default:
			{
				using (IEnumerator<int> enumerator = actionCategoryMap.ActionIdsInCategory(id).GetEnumerator())
				{
					while (true)
					{
						IL_0098:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = -427108705;
							num3 = num2;
						}
						else
						{
							num2 = -427108708;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -427108707)
							{
							case 0:
								num2 = -427108708;
								continue;
							default:
								goto end_IL_0056;
							case 1:
							{
								int current = enumerator.Current;
								InputAction actionById = GetActionById(current);
								if (actionById != null)
								{
									list.Add(actionById.descriptiveName);
									num2 = -427108706;
									continue;
								}
								break;
							}
							case 3:
								break;
							case 2:
								goto end_IL_0056;
							}
							goto IL_0098;
							continue;
							end_IL_0056:
							break;
						}
						break;
					}
				}
				return list.ToArray();
			}
			}
			goto IL_0010;
			IL_002e:
			return null;
			IL_0010:
			num = -427108708;
			goto IL_0015;
		}

		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			rpngRhOpKwAAdAKHtepxBaUAaWo rpngRhOpKwAAdAKHtepxBaUAaWo2 = new rpngRhOpKwAAdAKHtepxBaUAaWo(-2);
			rpngRhOpKwAAdAKHtepxBaUAaWo2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			rpngRhOpKwAAdAKHtepxBaUAaWo2.HEjtFCDQuzjqYEUuHIHEKiXWBfw = id;
			return rpngRhOpKwAAdAKHtepxBaUAaWo2;
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			if (actionCategories == null || actions == null)
			{
				return null;
			}
			List<int> list = new List<int>();
			IEnumerator<int> enumerator = actionCategoryMap.ActionIdsInCategory(id).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						int current = enumerator.Current;
						int num = -1018956765;
						while (true)
						{
							switch (num ^ -1018956766)
							{
							case 3:
								num = -1018956768;
								continue;
							case 2:
								break;
							case 1:
								list.Add(current);
								num = -1018956766;
								continue;
							default:
								goto end_IL_004e;
							}
							break;
						}
						continue;
						end_IL_004e:
						break;
					}
				}
			}
			finally
			{
				if (enumerator != null)
				{
					while (true)
					{
						IL_0077:
						int num2 = -1018956765;
						while (true)
						{
							switch (num2 ^ -1018956766)
							{
							case 2:
								break;
							default:
								goto end_IL_007c;
							case 1:
								goto IL_0095;
							case 0:
								goto end_IL_007c;
							}
							goto IL_0077;
							IL_0095:
							enumerator.Dispose();
							num2 = -1018956766;
							continue;
							end_IL_007c:
							break;
						}
						break;
					}
				}
			}
			return list.ToArray();
		}

		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			wEbpVSktomGeQgVvJoJZyVuWgXC wEbpVSktomGeQgVvJoJZyVuWgXC2 = new wEbpVSktomGeQgVvJoJZyVuWgXC(-2);
			wEbpVSktomGeQgVvJoJZyVuWgXC2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			wEbpVSktomGeQgVvJoJZyVuWgXC2.HEjtFCDQuzjqYEUuHIHEKiXWBfw = id;
			return wEbpVSktomGeQgVvJoJZyVuWgXC2;
		}

		public bool ContainsAction(int id)
		{
			return IndexOfAction(id) >= 0;
		}

		public int IndexOfAction(int id)
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1585148090;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1585148091)
				{
				case 0:
					break;
				case 2:
					return -1;
				case 1:
					if (actions[num].id == id)
					{
						return num;
					}
					num++;
					num2 = -1585148090;
					continue;
				case 3:
				{
					int num3;
					if (num < actions.Count)
					{
						num2 = -1585148092;
						num3 = num2;
					}
					else
					{
						num2 = -1585148095;
						num3 = num2;
					}
					continue;
				}
				default:
					return -1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1585148089;
			goto IL_000d;
		}

		public int IndexOfAction(string name)
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			int num;
			int num2 = default(int);
			if (name != null)
			{
				if (name == string.Empty)
				{
					num = 427799800;
				}
				else
				{
					num2 = 0;
					num = 427799803;
				}
				goto IL_000d;
			}
			goto IL_004f;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x197FB4F9)
				{
				case 0:
					break;
				case 4:
					return -1;
				case 1:
					goto IL_004f;
				case 2:
					num = 427799807;
					continue;
				case 3:
					goto IL_0061;
				case 6:
					goto IL_0088;
				default:
					return -1;
				}
				break;
				IL_0088:
				int num3;
				if (num2 >= actions.Count)
				{
					num = 427799804;
					num3 = num;
				}
				else
				{
					num = 427799802;
					num3 = num;
				}
				continue;
				IL_0061:
				if (actions[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num2;
				}
				num2++;
				num = 427799807;
			}
			goto IL_0008;
			IL_0008:
			num = 427799805;
			goto IL_000d;
			IL_004f:
			return -1;
		}

		public void AddActionCategory()
		{
			InputCategory inputCategory = DbDeQrHYlCiwsfJAzFhltqwKFGMu();
			actionCategories.Add(inputCategory);
			while (true)
			{
				int num = 927748922;
				while (true)
				{
					switch (num ^ 0x374C5338)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0031;
					case 1:
						return;
					}
					break;
					IL_0031:
					actionCategoryMap.AddCategory(inputCategory.id);
					num = 927748921;
				}
			}
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0)
			{
				goto IL_0034;
			}
			if (index >= actionCategories.Count)
			{
				goto IL_0012;
			}
			goto IL_0046;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
			IL_0012:
			int num = -1754773051;
			goto IL_0017;
			IL_0017:
			InputCategory inputCategory = default(InputCategory);
			switch (num ^ -1754773049)
			{
			case 3:
				break;
			case 2:
				goto IL_0034;
			case 1:
				goto IL_0046;
			default:
				actionCategoryMap.AddCategory(inputCategory.id);
				return;
			}
			goto IL_0012;
			IL_0046:
			inputCategory = DbDeQrHYlCiwsfJAzFhltqwKFGMu();
			actionCategories.Insert(index, inputCategory);
			num = -1754773049;
			goto IL_0017;
		}

		public void DeleteActionCategory(int index)
		{
			if (actionCategories != null && index >= 0)
			{
				int id = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -172667243;
					while (true)
					{
						switch (num ^ -172667242)
						{
						case 8:
							break;
						default:
							return;
						case 1:
							id = actionCategories[index].id;
							actionCategoryMap.RemoveCategory(id);
							if (actions != null)
							{
								num2 = actions.Count - 1;
								num = -172667242;
								continue;
							}
							goto case 6;
						case 5:
							goto end_IL_000c;
						case 6:
							actionCategories.RemoveAt(index);
							num = -172667247;
							continue;
						case 2:
							if (actions[num2].categoryId == id)
							{
								actions.RemoveAt(num2);
								num = -172667246;
								continue;
							}
							goto case 4;
						case 3:
							goto IL_00d5;
						case 0:
							goto IL_00f7;
						case 4:
							num2--;
							num = -172667242;
							continue;
						case 7:
							return;
						}
						break;
						IL_00f7:
						int num3;
						if (num2 < 0)
						{
							num = -172667248;
							num3 = num;
						}
						else
						{
							num = -172667244;
							num3 = num;
						}
						continue;
						IL_00d5:
						int num4;
						if (index < actionCategories.Count)
						{
							num = -172667241;
							num4 = num;
						}
						else
						{
							num = -172667245;
							num4 = num;
						}
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderActionCategory(int index, bool offsetDown, bool offsetNow)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				return false;
			}
			return ListTools.OffsetAtIndex(actionCategories, index, offsetDown, offsetNow);
		}

		public void DuplicateActionCategory(int index, bool duplicateActions)
		{
			if (actionCategories != null && index >= 0)
			{
				if (index >= actionCategories.Count)
				{
					goto IL_001d;
				}
				goto IL_020b;
			}
			return;
			IL_0022:
			int num;
			List<int> list = default(List<int>);
			int num5 = default(int);
			int id2 = default(int);
			InputCategory inputCategory = default(InputCategory);
			int id = default(int);
			int num2 = default(int);
			Dictionary<int, int> dictionary = default(Dictionary<int, int>);
			while (true)
			{
				switch (num ^ 0x68B4BF24)
				{
				case 11:
					break;
				case 8:
					return;
				case 1:
					list.Add(num5);
					num = 1756675886;
					continue;
				case 0:
					id2 = inputCategory.id;
					id = actionCategories[index].id;
					num = 1756675885;
					continue;
				case 10:
					num5++;
					num = 1756675880;
					continue;
				case 5:
					num2++;
					num = 1756675882;
					continue;
				case 9:
					list = new List<int>();
					num5 = 0;
					num = 1756675880;
					continue;
				case 7:
					actionCategoryMap.AddCategory(inputCategory.id);
					if (duplicateActions && actions != null)
					{
						num = 1756675876;
						continue;
					}
					return;
				case 3:
				{
					InputAction inputAction = actions[list[num2]];
					int num6 = jMhXxLmEOoOtDTLOgcYzCkoPFDL(id, inputAction);
					if (num6 >= 0)
					{
						InputAction inputAction2 = actions[num6];
						inputAction2.categoryId = id2;
						dictionary.Add(inputAction.id, inputAction2.id);
						num = 1756675873;
						continue;
					}
					goto case 5;
				}
				case 2:
					inputCategory.name = StringTools.IterateName(inputCategory.name, -1, GetActionCategoryNames());
					if (index == actionCategories.Count - 1)
					{
						actionCategories.Add(inputCategory);
						num = 1756675875;
						continue;
					}
					goto case 6;
				case 13:
					goto IL_01a0;
				case 12:
					if (num5 >= actions.Count)
					{
						dictionary = new Dictionary<int, int>(list.Count);
						num2 = 0;
						num = 1756675882;
						continue;
					}
					goto IL_01a0;
				case 6:
					actionCategories.Insert(index + 1, inputCategory);
					num = 1756675875;
					continue;
				case 4:
					goto IL_020b;
				default:
					if (num2 >= list.Count)
					{
						IEnumerator<int> enumerator = actionCategoryMap.ActionIdsInCategory(id).GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								while (true)
								{
									int current = enumerator.Current;
									if (!dictionary.TryGetValue(current, out var value))
									{
										break;
									}
									actionCategoryMap.AddAction(id2, value);
									int num3 = 1756675878;
									while (true)
									{
										switch (num3 ^ 0x68B4BF24)
										{
										case 0:
											num3 = 1756675877;
											continue;
										case 1:
											break;
										default:
											goto end_IL_0273;
										}
										break;
									}
									continue;
									end_IL_0273:
									break;
								}
							}
							return;
						}
						finally
						{
							if (enumerator != null)
							{
								while (true)
								{
									IL_02ae:
									int num4 = 1756675878;
									while (true)
									{
										switch (num4 ^ 0x68B4BF24)
										{
										case 0:
											break;
										default:
											goto end_IL_02b3;
										case 2:
											goto IL_02cc;
										case 1:
											goto end_IL_02b3;
										}
										goto IL_02ae;
										IL_02cc:
										enumerator.Dispose();
										num4 = 1756675877;
										continue;
										end_IL_02b3:
										break;
									}
									break;
								}
							}
						}
					}
					goto case 3;
				}
				break;
				IL_01a0:
				int num7;
				if (actions[num5].categoryId == id)
				{
					num = 1756675877;
					num7 = num;
				}
				else
				{
					num = 1756675886;
					num7 = num;
				}
			}
			goto IL_001d;
			IL_020b:
			inputCategory = new InputCategory(actionCategories[index]);
			inputCategory.id = GetNewActionCategoryId();
			num = 1756675878;
			goto IL_0022;
			IL_001d:
			num = 1756675884;
			goto IL_0022;
		}

		public void ChangeActionCategory(int actionId, int newCategoryId)
		{
			int num = IndexOfAction(actionId);
			if (num < 0)
			{
				return;
			}
			while (actions[num].categoryId != newCategoryId)
			{
				while (true)
				{
					IL_004b:
					actionCategoryMap.ChangeCategory(actionId, newCategoryId);
					actions[num].categoryId = newCategoryId;
					int num2 = 1860032290;
					while (true)
					{
						switch (num2 ^ 0x6EDDD721)
						{
						case 0:
							num2 = 1860032291;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							goto IL_004b;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		public int GetActionCategoryCount(int id)
		{
			if (actionCategories == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2;
			int num3;
			if (actions != null)
			{
				num2 = 897163532;
				num3 = num2;
			}
			else
			{
				num2 = 897163529;
				num3 = num2;
			}
			goto IL_000d;
			IL_0008:
			num2 = 897163533;
			goto IL_000d;
			IL_000d:
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ 0x3579A10F)
				{
				case 4:
					break;
				case 5:
					num4++;
					num2 = 897163535;
					continue;
				case 1:
					if (actions[num4].categoryId == id)
					{
						num++;
						num2 = 897163530;
						continue;
					}
					goto case 5;
				case 3:
					num4 = 0;
					num2 = 897163535;
					continue;
				case 2:
					return 0;
				case 0:
				{
					int num5;
					if (num4 < actions.Count)
					{
						num2 = 897163534;
						num5 = num2;
					}
					else
					{
						num2 = 897163529;
						num5 = num2;
					}
					continue;
				}
				default:
					return num;
				}
				break;
			}
			goto IL_0008;
		}

		public int GetActionCategoryIndex(int id)
		{
			if (actionCategories == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1628218559;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1628218556)
				{
				case 3:
					break;
				case 0:
					if (actionCategories[num].id == id)
					{
						num2 = -1628218554;
						continue;
					}
					num++;
					num2 = -1628218555;
					continue;
				case 5:
					num2 = -1628218555;
					continue;
				case 2:
					return num;
				case 4:
					return 0;
				default:
					if (num >= actionCategories.Count)
					{
						return -1;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1628218560;
			goto IL_000d;
		}

		public string[] GetActionCategoryNames()
		{
			if (actionCategories == null)
			{
				return null;
			}
			string[] array = new string[actionCategories.Count];
			int num2 = default(int);
			while (true)
			{
				int num = -1970501117;
				while (true)
				{
					switch (num ^ -1970501119)
					{
					case 0:
						break;
					case 2:
						num2 = 0;
						num = -1970501120;
						continue;
					case 3:
						array[num2] = actionCategories[num2].name;
						num2++;
						num = -1970501120;
						continue;
					default:
						if (num2 >= actionCategories.Count)
						{
							return array;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public int[] GetActionCategoryIds()
		{
			if (actionCategories == null)
			{
				return null;
			}
			int[] array = new int[actionCategories.Count];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= actionCategories.Count)
				{
					num2 = -2046979028;
					num3 = num2;
				}
				else
				{
					num2 = -2046979027;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -2046979025)
					{
					case 0:
						num2 = -2046979027;
						continue;
					case 2:
						array[num] = actionCategories[num].id;
						num++;
						num2 = -2046979026;
						continue;
					case 1:
						break;
					default:
						return array;
					}
					break;
				}
			}
		}

		public InputCategory GetActionCategory(int index)
		{
			if (actionCategories == null || index < 0 || index >= actionCategories.Count)
			{
				return null;
			}
			return actionCategories[index];
		}

		public InputCategory GetActionCategory(string name)
		{
			if (actionCategories == null)
			{
				return null;
			}
			int num = IndexOfActionCategory(name);
			if (num < 0)
			{
				return null;
			}
			return actionCategories[num];
		}

		public InputCategory GetActionCategoryById(int id)
		{
			int num = IndexOfActionCategory(id);
			if (num < 0)
			{
				return null;
			}
			return actionCategories[num];
		}

		public int GetActionCategoryId(string name)
		{
			if (actionCategories == null)
			{
				goto IL_0008;
			}
			int num = IndexOfActionCategory(name);
			int num2 = -331812987;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ -331812988)
			{
			case 0:
				break;
			case 2:
				return -1;
			default:
				if (num < 0)
				{
					return -1;
				}
				return actionCategories[num].id;
			}
			goto IL_0008;
			IL_0008:
			num2 = -331812986;
			goto IL_000d;
		}

		public string GetActionCategoryNameById(int id)
		{
			if (actionCategories == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1237252540;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x49BEF9BC)
				{
				case 2:
					break;
				case 4:
					if (actionCategories[num].id == id)
					{
						return actionCategories[num].name;
					}
					num++;
					num2 = 1237252541;
					continue;
				case 0:
					num2 = 1237252541;
					continue;
				case 5:
					return string.Empty;
				case 1:
				{
					int num3;
					if (num < actionCategories.Count)
					{
						num2 = 1237252536;
						num3 = num2;
					}
					else
					{
						num2 = 1237252543;
						num3 = num2;
					}
					continue;
				}
				default:
					return string.Empty;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1237252537;
			goto IL_000d;
		}

		public int IndexOfActionCategory(int id)
		{
			if (actionCategories == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1486399982;
				while (true)
				{
					switch (num2 ^ -1486399981)
					{
					case 0:
						break;
					case 1:
						num2 = -1486399984;
						continue;
					case 4:
						if (actionCategories[num].id == id)
						{
							num2 = -1486399983;
							continue;
						}
						num++;
						num2 = -1486399984;
						continue;
					case 2:
						return num;
					default:
						if (num >= actionCategories.Count)
						{
							return -1;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public int IndexOfActionCategory(string name)
		{
			if (name != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -2020866101;
					while (true)
					{
						switch (num ^ -2020866104)
						{
						case 0:
							break;
						case 2:
							goto IL_0029;
						case 1:
							goto end_IL_0003;
						case 3:
							goto IL_0065;
						default:
							if (num2 >= actionCategories.Count)
							{
								return -1;
							}
							goto IL_0029;
						}
						break;
						IL_0065:
						if (!(name == string.Empty))
						{
							if (actionCategories == null)
							{
								return -1;
							}
							num2 = 0;
							num = -2020866100;
						}
						else
						{
							num = -2020866103;
						}
						continue;
						IL_0029:
						if (actionCategories[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
						{
							return num2;
						}
						num2++;
						num = -2020866100;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return -1;
		}

		public int GetActionCategoryCount()
		{
			if (actionCategories == null)
			{
				return 0;
			}
			return actionCategories.Count;
		}

		public void AddInputBehavior()
		{
			inputBehaviors.Add(kUbhbGbdwKrODdTxKxOACHtcfLEI());
		}

		public void InsertInputBehavior(int index)
		{
			if (index >= 0)
			{
				if (index < inputBehaviors.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (-1532474471 ^ -1532474469)
					{
					case 0:
						break;
					case 2:
						goto end_IL_0012;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_0042:
			inputBehaviors.Insert(index, kUbhbGbdwKrODdTxKxOACHtcfLEI());
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors != null && index >= 0)
			{
				if (index >= inputBehaviors.Count)
				{
					goto IL_0020;
				}
				goto IL_0066;
			}
			goto IL_0098;
			IL_0098:
			throw new ArgumentOutOfRangeException("index");
			IL_0066:
			int id = inputBehaviors[index].id;
			int num = -1517048803;
			goto IL_0025;
			IL_0020:
			num = -1517048804;
			goto IL_0025;
			IL_0025:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1517048805)
				{
				case 9:
					break;
				case 3:
					num2 = 0;
					num = -1517048806;
					continue;
				case 2:
					goto IL_0066;
				case 8:
					actions[num2].behaviorId = 0;
					num = -1517048802;
					continue;
				case 7:
					goto IL_0098;
				case 1:
					goto IL_00ad;
				case 4:
					goto IL_00cf;
				case 5:
					num2++;
					num = -1517048806;
					continue;
				case 6:
					goto IL_0105;
				default:
					inputBehaviors.RemoveAt(index);
					return;
				}
				break;
				IL_0105:
				int num3;
				if (actions == null)
				{
					num = -1517048805;
					num3 = num;
				}
				else
				{
					num = -1517048808;
					num3 = num;
				}
				continue;
				IL_00cf:
				int num4;
				if (actions[num2].behaviorId != id)
				{
					num = -1517048802;
					num4 = num;
				}
				else
				{
					num = -1517048813;
					num4 = num;
				}
				continue;
				IL_00ad:
				int num5;
				if (num2 < actions.Count)
				{
					num = -1517048801;
					num5 = num;
				}
				else
				{
					num = -1517048805;
					num5 = num;
				}
			}
			goto IL_0020;
		}

		public bool ReorderInputBehavior(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(inputBehaviors, index, offsetDown, offsetNow);
		}

		public void DuplicateInputBehavior(int index)
		{
			if (inputBehaviors != null && index >= 0)
			{
				InputBehavior inputBehavior = default(InputBehavior);
				while (true)
				{
					int num = -1744821256;
					while (true)
					{
						switch (num ^ -1744821250)
						{
						case 4:
							break;
						case 6:
							goto IL_003d;
						case 0:
							return;
						case 1:
							goto end_IL_000c;
						case 5:
							inputBehavior = inputBehaviors[index].Clone();
							inputBehavior.id = GetNewInputBehaviorId();
							inputBehavior.name = StringTools.IterateName(inputBehavior.name, -1, GetInputBehaviorNames());
							num = -1744821251;
							continue;
						case 3:
							if (index == inputBehaviors.Count - 1)
							{
								inputBehaviors.Add(inputBehavior);
								num = -1744821250;
								continue;
							}
							goto default;
						default:
							inputBehaviors.Insert(index + 1, inputBehavior);
							return;
						}
						break;
						IL_003d:
						int num2;
						if (index >= inputBehaviors.Count)
						{
							num = -1744821249;
							num2 = num;
						}
						else
						{
							num = -1744821253;
							num2 = num;
						}
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public string[] GetInputBehaviorNames()
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			string[] array = new string[inputBehaviors.Count];
			int num = 0;
			while (num < inputBehaviors.Count)
			{
				while (true)
				{
					array[num] = inputBehaviors[num].name;
					int num2 = -5634209;
					while (true)
					{
						switch (num2 ^ -5634212)
						{
						case 0:
							num2 = -5634211;
							continue;
						case 1:
							break;
						case 3:
							num++;
							num2 = -5634210;
							continue;
						default:
							goto end_IL_0041;
						}
						break;
					}
					continue;
					end_IL_0041:
					break;
				}
			}
			return array;
		}

		public int[] GetInputBehaviorIds()
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			int[] array = new int[inputBehaviors.Count];
			int num = 0;
			while (num < inputBehaviors.Count)
			{
				while (true)
				{
					array[num] = inputBehaviors[num].id;
					num++;
					int num2 = 877252768;
					while (true)
					{
						switch (num2 ^ 0x3449D0A2)
						{
						case 0:
							num2 = 877252771;
							continue;
						case 1:
							break;
						default:
							goto end_IL_003d;
						}
						break;
					}
					continue;
					end_IL_003d:
					break;
				}
			}
			return array;
		}

		public InputBehavior GetInputBehavior(int index)
		{
			if (inputBehaviors != null)
			{
				while (true)
				{
					int num = -1655498852;
					while (true)
					{
						switch (num ^ -1655498851)
						{
						case 2:
							break;
						case 1:
							goto IL_0026;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0026:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						if (index >= inputBehaviors.Count)
						{
							num = -1655498851;
							continue;
						}
						return inputBehaviors[index];
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public InputBehavior GetInputBehavior(string name)
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			int num = IndexOfInputBehavior(name);
			if (num < 0)
			{
				return null;
			}
			return inputBehaviors[num];
		}

		public InputBehavior GetInputBehaviorById(int id)
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2 = 530004746;
				while (true)
				{
					switch (num2 ^ 0x1F973B0E)
					{
					case 3:
						break;
					case 4:
						num2 = 530004751;
						continue;
					case 2:
						if (inputBehaviors[num].id == id)
						{
							num2 = 530004750;
							continue;
						}
						num++;
						num2 = 530004751;
						continue;
					case 0:
						return inputBehaviors[num];
					default:
						if (num >= inputBehaviors.Count)
						{
							return null;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int GetInputBehaviorId(string name)
		{
			if (inputBehaviors == null)
			{
				goto IL_0008;
			}
			int num = IndexOfInputBehavior(name);
			int num2 = 1991291758;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ 0x76B0B36F)
			{
			case 0:
				break;
			case 2:
				return -1;
			default:
				if (num < 0)
				{
					return -1;
				}
				return inputBehaviors[num].id;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1991291757;
			goto IL_000d;
		}

		public int IndexOfInputBehavior(int id)
		{
			if (inputBehaviors == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 783636931;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x2EB559C0)
				{
				case 0:
					break;
				case 5:
					return -1;
				case 4:
				{
					int num3;
					if (num < inputBehaviors.Count)
					{
						num2 = 783636929;
						num3 = num2;
					}
					else
					{
						num2 = 783636930;
						num3 = num2;
					}
					continue;
				}
				case 3:
					num2 = 783636932;
					continue;
				case 1:
					if (inputBehaviors[num].id == id)
					{
						return num;
					}
					num++;
					num2 = 783636932;
					continue;
				default:
					return -1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 783636933;
			goto IL_000d;
		}

		public int IndexOfInputBehavior(string name)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_001a;
				}
				num = 0;
				num2 = -835305332;
				goto IL_001f;
			}
			goto IL_0070;
			IL_001f:
			while (true)
			{
				switch (num2 ^ -835305332)
				{
				case 4:
					break;
				case 5:
					return num;
				case 0:
					goto IL_0051;
				case 3:
					goto IL_0070;
				case 2:
					goto IL_007b;
				default:
					return -1;
				}
				break;
				IL_007b:
				if (!inputBehaviors[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					num++;
					num2 = -835305332;
				}
				else
				{
					num2 = -835305335;
				}
				continue;
				IL_0051:
				int num3;
				if (num < inputBehaviors.Count)
				{
					num2 = -835305330;
					num3 = num2;
				}
				else
				{
					num2 = -835305331;
					num3 = num2;
				}
			}
			goto IL_001a;
			IL_0070:
			return -1;
			IL_001a:
			num2 = -835305329;
			goto IL_001f;
		}

		public void AddMapCategory()
		{
			mapCategories.Add(afQWIFPueftpztHVacesdOnQNEsb());
		}

		public void InsertMapCategory(int index)
		{
			if (index >= 0)
			{
				if (index < mapCategories.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (0x73106B50 ^ 0x73106B51)
					{
					case 0:
						break;
					case 1:
						goto end_IL_0012;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_0042:
			mapCategories.Insert(index, afQWIFPueftpztHVacesdOnQNEsb());
		}

		public void DeleteMapCategory(int index)
		{
			if (mapCategories != null)
			{
				Player_Editor player_Editor = default(Player_Editor);
				int num8 = default(int);
				Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
				int id = default(int);
				InputMapCategory inputMapCategory = default(InputMapCategory);
				int num4 = default(int);
				int num6 = default(int);
				int num5 = default(int);
				int num3 = default(int);
				int num7 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -797910818;
					while (true)
					{
						switch (num ^ -797910840)
						{
						case 4:
							break;
						default:
							return;
						case 15:
							player_Editor = players[num8];
							if (player_Editor != null)
							{
								cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultKeyboardMaps, id);
								num = -797910821;
								continue;
							}
							goto case 8;
						case 33:
							goto IL_00eb;
						case 21:
							num8 = 0;
							num = -797910807;
							continue;
						case 5:
							goto IL_011b;
						case 16:
							inputMapCategory.checkConflictsCategoryIds.RemoveAt(num4);
							num = -797910832;
							continue;
						case 7:
							if (customControllerMaps[num6].categoryId == id)
							{
								customControllerMaps.RemoveAt(num6);
								num = -797910847;
								continue;
							}
							goto case 9;
						case 0:
							goto IL_0186;
						case 26:
							num5 = keyboardMaps.Count - 1;
							num = -797910817;
							continue;
						case 17:
							goto IL_01b6;
						case 37:
							goto IL_01db;
						case 3:
							num3--;
							num = -797910803;
							continue;
						case 13:
							mapCategories.RemoveAt(index);
							num = -797910808;
							continue;
						case 29:
							goto end_IL_000b;
						case 23:
							goto IL_022c;
						case 30:
							if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate60 == null)
							{
								CS_0024_003C_003E9__CachedAnonymousMethodDelegate60 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
								{
									if (P_0 == null)
									{
										return;
									}
									while (true)
									{
										int num21 = P_0.Count - 1;
										int num22 = 1151412417;
										while (true)
										{
											switch (num22 ^ 0x44A128C2)
											{
											case 5:
												num22 = 1151412422;
												continue;
											case 7:
											{
												int num24;
												if (P_0[num21].categoryId == P_1)
												{
													num22 = 1151412418;
													num24 = num22;
												}
												else
												{
													num22 = 1151412419;
													num24 = num22;
												}
												continue;
											}
											case 1:
												num21--;
												num22 = 1151412420;
												continue;
											case 4:
												break;
											case 2:
											{
												int num23;
												if (P_0[num21] != null)
												{
													num22 = 1151412421;
													num23 = num22;
												}
												else
												{
													num22 = 1151412418;
													num23 = num22;
												}
												continue;
											}
											case 3:
												num22 = 1151412420;
												continue;
											case 0:
												P_0.RemoveAt(num21);
												num22 = 1151412419;
												continue;
											default:
												if (num21 < 0)
												{
													return;
												}
												goto case 2;
											}
											break;
										}
									}
								};
								num = -797910820;
								continue;
							}
							goto case 20;
						case 6:
							goto IL_0266;
						case 34:
							id = mapCategories[index].id;
							if (joystickMaps != null)
							{
								num3 = joystickMaps.Count - 1;
								num = -797910803;
								continue;
							}
							goto IL_0459;
						case 20:
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate60;
							num = -797910819;
							continue;
						case 38:
							num7++;
							num = -797910846;
							continue;
						case 25:
							if (customControllerMaps != null)
							{
								num6 = customControllerMaps.Count - 1;
								num = -797910825;
								continue;
							}
							goto case 27;
						case 2:
							keyboardMaps.RemoveAt(num5);
							num = -797910845;
							continue;
						case 1:
							inputMapCategory = mapCategories[num7];
							if (inputMapCategory.checkConflictsCategoryIds != null)
							{
								num4 = 0;
								num = -797910835;
								continue;
							}
							goto case 38;
						case 22:
							goto IL_0337;
						case 11:
							num5--;
							num = -797910817;
							continue;
						case 36:
							num2--;
							num = -797910840;
							continue;
						case 8:
							num8++;
							num = -797910807;
							continue;
						case 27:
							if (mapCategories != null)
							{
								num7 = 0;
								num = -797910846;
								continue;
							}
							goto IL_0266;
						case 9:
							num6--;
							num = -797910825;
							continue;
						case 35:
							if (joystickMaps[num3].categoryId == id)
							{
								joystickMaps.RemoveAt(num3);
								num = -797910837;
								continue;
							}
							goto case 3;
						case 12:
							goto IL_03e1;
						case 31:
							goto IL_0409;
						case 19:
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultMouseMaps, id);
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultJoystickMaps, id);
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultCustomControllerMaps, id);
							num = -797910848;
							continue;
						case 14:
							goto IL_0459;
						case 18:
							if (mouseMaps != null)
							{
								num2 = mouseMaps.Count - 1;
								num = -797910840;
								continue;
							}
							goto case 25;
						case 24:
							num4++;
							num = -797910835;
							continue;
						case 28:
							if (mouseMaps[num2].categoryId == id)
							{
								mouseMaps.RemoveAt(num2);
								num = -797910804;
								continue;
							}
							goto case 36;
						case 10:
							goto IL_04d5;
						case 32:
							return;
						}
						break;
						IL_04d5:
						int num9;
						if (num7 < mapCategories.Count)
						{
							num = -797910839;
							num9 = num;
						}
						else
						{
							num = -797910834;
							num9 = num;
						}
						continue;
						IL_01db:
						int num10;
						if (num3 >= 0)
						{
							num = -797910805;
							num10 = num;
						}
						else
						{
							num = -797910842;
							num10 = num;
						}
						continue;
						IL_0459:
						int num11;
						if (keyboardMaps == null)
						{
							num = -797910822;
							num11 = num;
						}
						else
						{
							num = -797910830;
							num11 = num;
						}
						continue;
						IL_0409:
						int num12;
						if (num6 < 0)
						{
							num = -797910829;
							num12 = num;
						}
						else
						{
							num = -797910833;
							num12 = num;
						}
						continue;
						IL_0266:
						int num13;
						if (players != null)
						{
							num = -797910826;
							num13 = num;
						}
						else
						{
							num = -797910843;
							num13 = num;
						}
						continue;
						IL_00eb:
						int num14;
						if (num8 >= players.Count)
						{
							num = -797910843;
							num14 = num;
						}
						else
						{
							num = -797910841;
							num14 = num;
						}
						continue;
						IL_03e1:
						int num15;
						if (keyboardMaps[num5].categoryId != id)
						{
							num = -797910845;
							num15 = num;
						}
						else
						{
							num = -797910838;
							num15 = num;
						}
						continue;
						IL_0186:
						int num16;
						if (num2 < 0)
						{
							num = -797910831;
							num16 = num;
						}
						else
						{
							num = -797910828;
							num16 = num;
						}
						continue;
						IL_022c:
						int num17;
						if (num5 >= 0)
						{
							num = -797910844;
							num17 = num;
						}
						else
						{
							num = -797910822;
							num17 = num;
						}
						continue;
						IL_0337:
						if (index < 0)
						{
							goto end_IL_000b;
						}
						int num18;
						if (index >= mapCategories.Count)
						{
							num = -797910827;
							num18 = num;
						}
						else
						{
							num = -797910806;
							num18 = num;
						}
						continue;
						IL_01b6:
						int num19;
						if (inputMapCategory.checkConflictsCategoryIds[num4] == id)
						{
							num = -797910824;
							num19 = num;
						}
						else
						{
							num = -797910832;
							num19 = num;
						}
						continue;
						IL_011b:
						int num20;
						if (num4 >= inputMapCategory.checkConflictsCategoryIds.Count)
						{
							num = -797910802;
							num20 = num;
						}
						else
						{
							num = -797910823;
							num20 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderMapCategory(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mapCategories, index, offsetDown, offsetNow);
		}

		public void DuplicateMapCategory(int index, bool duplicateMaps)
		{
			if (mapCategories == null || index < 0)
			{
				goto IL_0136;
			}
			if (index >= mapCategories.Count)
			{
				goto IL_0023;
			}
			goto IL_0155;
			IL_033f:
			InputMapCategory inputMapCategory = default(InputMapCategory);
			mapCategories.Insert(index + 1, inputMapCategory);
			int num = 466612974;
			goto IL_0028;
			IL_0136:
			throw new ArgumentOutOfRangeException("index");
			IL_0023:
			num = 466612977;
			goto IL_0028;
			IL_0028:
			int num6 = default(int);
			int id2 = default(int);
			int num7 = default(int);
			int num4 = default(int);
			int num2 = default(int);
			int id = default(int);
			int num8 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x1BCFF2FC)
				{
				case 9:
					break;
				default:
					return;
				case 22:
					if (joystickMaps != null)
					{
						num6 = joystickMaps.Count - 1;
						num = 466612978;
						continue;
					}
					goto case 16;
				case 25:
					num6--;
					num = 466612971;
					continue;
				case 1:
					if (joystickMaps[num6].categoryId == id2)
					{
						num7 = DuplicateJoystickMap(num6);
						num = 466612982;
						continue;
					}
					goto case 25;
				case 2:
					num4 = mouseMaps.Count - 1;
					num = 466612973;
					continue;
				case 20:
					keyboardMaps[num2].categoryId = id;
					num = 466612984;
					continue;
				case 13:
					goto IL_0136;
				case 14:
					num = 466612971;
					continue;
				case 11:
					goto IL_0155;
				case 26:
					num4--;
					num = 466612973;
					continue;
				case 8:
					joystickMaps[num7].categoryId = id;
					num = 466612965;
					continue;
				case 4:
					num8--;
					num = 466612979;
					continue;
				case 24:
					if (mouseMaps[num4].categoryId == id2)
					{
						int num9 = DuplicateMouseMap(num4);
						if (num9 >= 0)
						{
							mouseMaps[num9].categoryId = id;
							num = 466612966;
							continue;
						}
					}
					goto case 26;
				case 15:
					goto IL_0232;
				case 6:
					if (keyboardMaps[num8].categoryId != id2)
					{
						goto case 4;
					}
					goto IL_0260;
				case 19:
					goto IL_0283;
				case 21:
					if (customControllerMaps != null)
					{
						num5 = customControllerMaps.Count - 1;
						num = 466612987;
						continue;
					}
					return;
				case 17:
					goto IL_02c3;
				case 7:
					goto IL_02dc;
				case 16:
					if (keyboardMaps != null)
					{
						num8 = keyboardMaps.Count - 1;
						num = 466612979;
						continue;
					}
					goto IL_0283;
				case 5:
					num5--;
					num = 466612987;
					continue;
				case 10:
					goto IL_0326;
				case 12:
					goto IL_033f;
				case 0:
					if (customControllerMaps[num5].categoryId == id2)
					{
						num3 = DuplicateCustomControllerMap(num5);
						num = 466612967;
						continue;
					}
					goto case 5;
				case 27:
					if (num3 >= 0)
					{
						customControllerMaps[num3].categoryId = id;
						num = 466612985;
						continue;
					}
					goto case 5;
				case 23:
					goto IL_03a3;
				case 18:
					if (duplicateMaps)
					{
						id = inputMapCategory.id;
						id2 = mapCategories[index].id;
						num = 466612970;
						continue;
					}
					return;
				case 3:
					return;
				}
				break;
				IL_03a3:
				int num10;
				if (num6 < 0)
				{
					num = 466612972;
					num10 = num;
				}
				else
				{
					num = 466612989;
					num10 = num;
				}
				continue;
				IL_02c3:
				int num11;
				if (num4 >= 0)
				{
					num = 466612964;
					num11 = num;
				}
				else
				{
					num = 466612969;
					num11 = num;
				}
				continue;
				IL_0232:
				int num12;
				if (num8 < 0)
				{
					num = 466612975;
					num12 = num;
				}
				else
				{
					num = 466612986;
					num12 = num;
				}
				continue;
				IL_0326:
				int num13;
				if (num7 < 0)
				{
					num = 466612965;
					num13 = num;
				}
				else
				{
					num = 466612980;
					num13 = num;
				}
				continue;
				IL_0283:
				int num14;
				if (mouseMaps != null)
				{
					num = 466612990;
					num14 = num;
				}
				else
				{
					num = 466612969;
					num14 = num;
				}
				continue;
				IL_0260:
				num2 = DuplicateKeyboardMap(num8);
				int num15;
				if (num2 >= 0)
				{
					num = 466612968;
					num15 = num;
				}
				else
				{
					num = 466612984;
					num15 = num;
				}
				continue;
				IL_02dc:
				int num16;
				if (num5 < 0)
				{
					num = 466612991;
					num16 = num;
				}
				else
				{
					num = 466612988;
					num16 = num;
				}
			}
			goto IL_0023;
			IL_0155:
			inputMapCategory = new InputMapCategory(mapCategories[index]);
			inputMapCategory.id = GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName(inputMapCategory.name, -1, GetMapCategoryNames());
			if (index == mapCategories.Count - 1)
			{
				mapCategories.Add(inputMapCategory);
				num = 466612974;
				goto IL_0028;
			}
			goto IL_033f;
		}

		public int GetMapCategoryMapCount(int id)
		{
			if (mapCategories == null)
			{
				return 0;
			}
			int num = 0;
			int num4 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			int num6 = default(int);
			while (true)
			{
				int num2 = 689700124;
				while (true)
				{
					switch (num2 ^ 0x291BFD13)
					{
					case 8:
						break;
					case 1:
						if (keyboardMaps[num4].categoryId == id)
						{
							num++;
							num2 = 689700121;
							continue;
						}
						goto case 10;
					case 14:
					{
						int num12;
						if (num5 >= customControllerMaps.Count)
						{
							num2 = 689700113;
							num12 = num2;
						}
						else
						{
							num2 = 689700120;
							num12 = num2;
						}
						continue;
					}
					case 18:
					{
						int num8;
						if (num3 < joystickMaps.Count)
						{
							num2 = 689700127;
							num8 = num2;
						}
						else
						{
							num2 = 689700116;
							num8 = num2;
						}
						continue;
					}
					case 5:
						num4 = 0;
						num2 = 689700098;
						continue;
					case 16:
					{
						int num10;
						if (num6 < mouseMaps.Count)
						{
							num2 = 689700112;
							num10 = num2;
						}
						else
						{
							num2 = 689700119;
							num10 = num2;
						}
						continue;
					}
					case 7:
					{
						int num7;
						if (keyboardMaps == null)
						{
							num2 = 689700096;
							num7 = num2;
						}
						else
						{
							num2 = 689700118;
							num7 = num2;
						}
						continue;
					}
					case 11:
						if (customControllerMaps[num5].categoryId == id)
						{
							num++;
							num2 = 689700117;
							continue;
						}
						goto case 6;
					case 10:
						num4++;
						num2 = 689700098;
						continue;
					case 6:
						num5++;
						num2 = 689700125;
						continue;
					case 17:
					{
						int num11;
						if (num4 < keyboardMaps.Count)
						{
							num2 = 689700114;
							num11 = num2;
						}
						else
						{
							num2 = 689700096;
							num11 = num2;
						}
						continue;
					}
					case 0:
						num6++;
						num2 = 689700099;
						continue;
					case 13:
						num3++;
						num2 = 689700097;
						continue;
					case 9:
						num5 = 0;
						num2 = 689700125;
						continue;
					case 19:
						if (mouseMaps != null)
						{
							num6 = 0;
							num2 = 689700099;
							continue;
						}
						goto case 4;
					case 3:
						if (mouseMaps[num6].categoryId == id)
						{
							num++;
							num2 = 689700115;
							continue;
						}
						goto case 0;
					case 15:
						if (joystickMaps != null)
						{
							num3 = 0;
							num2 = 689700097;
							continue;
						}
						goto case 7;
					case 12:
						if (joystickMaps[num3].categoryId == id)
						{
							num++;
							num2 = 689700126;
							continue;
						}
						goto case 13;
					case 4:
					{
						int num9;
						if (customControllerMaps != null)
						{
							num2 = 689700122;
							num9 = num2;
						}
						else
						{
							num2 = 689700113;
							num9 = num2;
						}
						continue;
					}
					default:
						return num;
					}
					break;
				}
			}
		}

		public int GetMapCategoryIndex(int id)
		{
			if (mapCategories == null)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				int num2 = -600388342;
				while (true)
				{
					switch (num2 ^ -600388343)
					{
					case 2:
						break;
					case 3:
						num2 = -600388344;
						continue;
					case 0:
						if (mapCategories[num].id == id)
						{
							return num;
						}
						num++;
						num2 = -600388344;
						continue;
					default:
						if (num >= mapCategories.Count)
						{
							return -1;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public string[] GetMapCategoryNames()
		{
			if (mapCategories == null)
			{
				return null;
			}
			string[] array = new string[mapCategories.Count];
			int num2 = default(int);
			while (true)
			{
				int num = -1022219536;
				while (true)
				{
					switch (num ^ -1022219532)
					{
					case 3:
						break;
					case 2:
					{
						int num3;
						if (num2 >= mapCategories.Count)
						{
							num = -1022219531;
							num3 = num;
						}
						else
						{
							num = -1022219532;
							num3 = num;
						}
						continue;
					}
					case 0:
						array[num2] = mapCategories[num2].name;
						num2++;
						num = -1022219530;
						continue;
					case 4:
						num2 = 0;
						num = -1022219530;
						continue;
					default:
						return array;
					}
					break;
				}
			}
		}

		public int[] GetMapCategoryIds()
		{
			if (mapCategories == null)
			{
				return null;
			}
			int[] array = new int[mapCategories.Count];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= mapCategories.Count)
				{
					num2 = 2095443077;
					num3 = num2;
				}
				else
				{
					num2 = 2095443078;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x7CE5EC87)
					{
					case 0:
						num2 = 2095443078;
						continue;
					case 1:
						array[num] = mapCategories[num].id;
						num++;
						num2 = 2095443076;
						continue;
					case 3:
						break;
					default:
						return array;
					}
					break;
				}
			}
		}

		public InputMapCategory GetMapCategory(int index)
		{
			if (mapCategories != null)
			{
				while (true)
				{
					int num = -1991046053;
					while (true)
					{
						switch (num ^ -1991046054)
						{
						case 3:
							break;
						case 1:
							goto IL_002a;
						case 2:
							goto IL_003f;
						default:
							goto end_IL_0008;
						}
						break;
						IL_003f:
						if (index >= mapCategories.Count)
						{
							num = -1991046054;
							continue;
						}
						return mapCategories[index];
						IL_002a:
						int num2;
						if (index >= 0)
						{
							num = -1991046056;
							num2 = num;
						}
						else
						{
							num = -1991046054;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public InputMapCategory GetMapCategory(string name)
		{
			if (mapCategories == null)
			{
				return null;
			}
			int num = IndexOfMapCategory(name);
			if (num < 0)
			{
				return null;
			}
			return mapCategories[num];
		}

		public InputMapCategory GetMapCategoryById(int id)
		{
			if (mapCategories == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1271436158;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x4BC8937D)
				{
				case 2:
					break;
				case 3:
				{
					int num3;
					if (num < mapCategories.Count)
					{
						num2 = 1271436153;
						num3 = num2;
					}
					else
					{
						num2 = 1271436157;
						num3 = num2;
					}
					continue;
				}
				case 4:
					if (mapCategories[num].id == id)
					{
						return mapCategories[num];
					}
					num++;
					num2 = 1271436158;
					continue;
				case 1:
					return null;
				default:
					return null;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1271436156;
			goto IL_000d;
		}

		public int GetMapCategoryId(string name)
		{
			if (mapCategories == null)
			{
				return -1;
			}
			int num = IndexOfMapCategory(name);
			if (num < 0)
			{
				return -1;
			}
			return mapCategories[num].id;
		}

		public string GetMapCategoryNameById(int id)
		{
			if (mapCategories == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 390644479;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x1748C2FC)
				{
				case 0:
					break;
				case 2:
					return string.Empty;
				case 4:
					if (mapCategories[num].id == id)
					{
						return mapCategories[num].name;
					}
					num++;
					num2 = 390644479;
					continue;
				case 3:
				{
					int num3;
					if (num < mapCategories.Count)
					{
						num2 = 390644472;
						num3 = num2;
					}
					else
					{
						num2 = 390644477;
						num3 = num2;
					}
					continue;
				}
				default:
					return string.Empty;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 390644478;
			goto IL_000d;
		}

		public int IndexOfMapCategory(int id)
		{
			if (mapCategories == null)
			{
				return -1;
			}
			int num = 0;
			while (num < mapCategories.Count)
			{
				while (true)
				{
					if (mapCategories[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = 1761953832;
					while (true)
					{
						switch (num2 ^ 0x69054828)
						{
						case 2:
							num2 = 1761953833;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return -1;
		}

		public int IndexOfMapCategory(string name)
		{
			int num;
			int num2 = default(int);
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (mapCategories == null)
				{
					num = 8103029;
				}
				else
				{
					num2 = 0;
					num = 8103024;
				}
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num ^ 0x7BA474)
				{
				case 3:
					break;
				case 2:
					goto IL_0036;
				case 1:
					return -1;
				case 0:
					goto IL_0052;
				default:
					if (num2 >= mapCategories.Count)
					{
						return -1;
					}
					goto IL_0052;
				}
				break;
				IL_0052:
				if (mapCategories[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num2;
				}
				num2++;
				num = 8103024;
			}
			goto IL_0010;
			IL_0010:
			num = 8103030;
			goto IL_0015;
			IL_0036:
			return -1;
		}

		public string[] GetLayoutNames(ControllerType controllerType)
		{
			while (true)
			{
				switch (0x8E2E142 ^ 0x8E2E143)
				{
				case 0:
					continue;
				case 1:
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						break;
					case ControllerType.Mouse:
						return GetMouseLayoutNames();
					case ControllerType.Joystick:
						return GetJoystickLayoutNames();
					case ControllerType.Custom:
						return GetCustomControllerLayoutNames();
					default:
						throw new NotImplementedException();
					}
					break;
				}
				break;
			}
			return GetKeyboardLayoutNames();
		}

		public int[] GetLayoutIds(ControllerType controllerType)
		{
			switch (controllerType)
			{
			default:
				while (true)
				{
					switch (-1588282525 ^ -1588282526)
					{
					case 0:
						continue;
					case 1:
						if (controllerType == ControllerType.Custom)
						{
							return GetCustomControllerLayoutIds();
						}
						throw new NotImplementedException();
					}
					break;
				}
				goto case ControllerType.Keyboard;
			case ControllerType.Keyboard:
				return GetKeyboardLayoutIds();
			case ControllerType.Mouse:
				return GetMouseLayoutIds();
			case ControllerType.Joystick:
				return GetJoystickLayoutIds();
			}
		}

		public void AddJoystickLayout()
		{
			joystickLayouts.Add(tKoSqohFtTtmilugrShVUkmbvqi());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index >= 0)
			{
				if (index < joystickLayouts.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (-1649346433 ^ -1649346434)
					{
					case 0:
						break;
					case 1:
						goto end_IL_0012;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_0042:
			joystickLayouts.Insert(index, tKoSqohFtTtmilugrShVUkmbvqi());
		}

		public void DeleteJoystickLayout(int index)
		{
			if (joystickLayouts != null && index >= 0)
			{
				int num3 = default(int);
				int num2 = default(int);
				Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
				int id = default(int);
				while (true)
				{
					int num = 1247548811;
					while (true)
					{
						switch (num ^ 0x4A5C1586)
						{
						case 2:
							break;
						default:
							return;
						case 7:
							goto IL_0064;
						case 15:
							joystickMaps.RemoveAt(num3);
							num = 1247548814;
							continue;
						case 10:
							goto end_IL_000f;
						case 13:
							goto IL_00a1;
						case 1:
							num2++;
							num = 1247548813;
							continue;
						case 14:
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate62;
							num2 = 0;
							num = 1247548813;
							continue;
						case 3:
							joystickLayouts.RemoveAt(index);
							num = 1247548806;
							continue;
						case 8:
							num3--;
							num = 1247548801;
							continue;
						case 9:
							id = joystickLayouts[index].id;
							if (joystickMaps != null)
							{
								num3 = joystickMaps.Count - 1;
								num = 1247548801;
								continue;
							}
							goto IL_0139;
						case 5:
							goto IL_0139;
						case 6:
							if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate62 == null)
							{
								CS_0024_003C_003E9__CachedAnonymousMethodDelegate62 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
								{
									if (P_0 == null)
									{
										return;
									}
									while (true)
									{
										int num9 = P_0.Count - 1;
										int num10 = 269559596;
										while (true)
										{
											switch (num10 ^ 0x1011272F)
											{
											case 2:
												num10 = 269559598;
												continue;
											case 1:
												break;
											case 0:
												if (P_0[num9] != null)
												{
													int num11;
													if (P_0[num9].layoutId != P_1)
													{
														num10 = 269559595;
														num11 = num10;
													}
													else
													{
														num10 = 269559594;
														num11 = num10;
													}
													continue;
												}
												goto case 5;
											case 5:
												P_0.RemoveAt(num9);
												num10 = 269559595;
												continue;
											case 4:
												num9--;
												num10 = 269559596;
												continue;
											default:
												if (num9 < 0)
												{
													return;
												}
												goto case 0;
											}
											break;
										}
									}
								};
								num = 1247548808;
								continue;
							}
							goto case 14;
						case 11:
							goto IL_017a;
						case 4:
						{
							Player_Editor player_Editor = players[num2];
							if (player_Editor != null)
							{
								cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultJoystickMaps, id);
								num = 1247548807;
								continue;
							}
							goto case 1;
						}
						case 12:
							goto IL_01c9;
						case 0:
							return;
						}
						break;
						IL_01c9:
						int num4;
						if (joystickMaps[num3].layoutId == id)
						{
							num = 1247548809;
							num4 = num;
						}
						else
						{
							num = 1247548814;
							num4 = num;
						}
						continue;
						IL_0064:
						int num5;
						if (num3 >= 0)
						{
							num = 1247548810;
							num5 = num;
						}
						else
						{
							num = 1247548803;
							num5 = num;
						}
						continue;
						IL_0139:
						int num6;
						if (players == null)
						{
							num = 1247548805;
							num6 = num;
						}
						else
						{
							num = 1247548800;
							num6 = num;
						}
						continue;
						IL_017a:
						int num7;
						if (num2 < players.Count)
						{
							num = 1247548802;
							num7 = num;
						}
						else
						{
							num = 1247548805;
							num7 = num;
						}
						continue;
						IL_00a1:
						int num8;
						if (index >= joystickLayouts.Count)
						{
							num = 1247548812;
							num8 = num;
						}
						else
						{
							num = 1247548815;
							num8 = num;
						}
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderJoystickLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(joystickLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateJoystickLayout(int index, bool duplicateMaps)
		{
			if (joystickLayouts != null && index >= 0)
			{
				if (index >= joystickLayouts.Count)
				{
					goto IL_0020;
				}
				goto IL_008b;
			}
			goto IL_00ee;
			IL_008b:
			InputLayout inputLayout = joystickLayouts[index].Clone();
			inputLayout.id = GetNewJoystickLayoutId();
			int num = 2059039886;
			goto IL_0025;
			IL_00ee:
			throw new ArgumentOutOfRangeException("index");
			IL_0020:
			num = 2059039883;
			goto IL_0025;
			IL_0025:
			int num3 = default(int);
			int id2 = default(int);
			int num2 = default(int);
			int id = default(int);
			while (true)
			{
				switch (num ^ 0x7ABA7486)
				{
				case 0:
					break;
				default:
					return;
				case 14:
					joystickMaps[num3].layoutId = id2;
					num = 2059039875;
					continue;
				case 6:
					goto IL_008b;
				case 9:
					goto IL_00b3;
				case 12:
					if (joystickMaps != null)
					{
						num2 = joystickMaps.Count - 1;
						num = 2059039887;
						continue;
					}
					return;
				case 13:
					goto IL_00ee;
				case 7:
					joystickLayouts.Add(inputLayout);
					num = 2059039876;
					continue;
				case 8:
					goto IL_0119;
				case 11:
					joystickLayouts.Insert(index + 1, inputLayout);
					num = 2059039876;
					continue;
				case 2:
					goto IL_016e;
				case 4:
					id2 = inputLayout.id;
					id = joystickLayouts[index].id;
					num = 2059039882;
					continue;
				case 5:
					num2--;
					num = 2059039887;
					continue;
				case 3:
					if (joystickMaps[num2].layoutId == id)
					{
						num3 = DuplicateJoystickMap(num2);
						num = 2059039884;
						continue;
					}
					goto case 5;
				case 10:
					goto IL_01dd;
				case 1:
					return;
				}
				break;
				IL_01dd:
				int num4;
				if (num3 >= 0)
				{
					num = 2059039880;
					num4 = num;
				}
				else
				{
					num = 2059039875;
					num4 = num;
				}
				continue;
				IL_0119:
				inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetJoystickLayoutNames());
				int num5;
				if (index != joystickLayouts.Count - 1)
				{
					num = 2059039885;
					num5 = num;
				}
				else
				{
					num = 2059039873;
					num5 = num;
				}
				continue;
				IL_00b3:
				int num6;
				if (num2 < 0)
				{
					num = 2059039879;
					num6 = num;
				}
				else
				{
					num = 2059039877;
					num6 = num;
				}
				continue;
				IL_016e:
				int num7;
				if (!duplicateMaps)
				{
					num = 2059039879;
					num7 = num;
				}
				else
				{
					num = 2059039874;
					num7 = num;
				}
			}
			goto IL_0020;
		}

		public int GetJoystickLayoutMapCount(int id)
		{
			if (joystickLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (joystickMaps != null)
			{
				int num2 = 0;
				while (true)
				{
					int num3 = 1429208908;
					while (true)
					{
						switch (num3 ^ 0x552FFF49)
						{
						case 0:
							break;
						case 5:
							num3 = 1429208904;
							continue;
						case 2:
							if (joystickMaps[num2].layoutId == id)
							{
								num++;
								num3 = 1429208909;
								continue;
							}
							goto case 4;
						case 4:
							num2++;
							num3 = 1429208904;
							continue;
						case 1:
							goto IL_0071;
						default:
							goto end_IL_0016;
						}
						break;
						IL_0071:
						int num4;
						if (num2 >= joystickMaps.Count)
						{
							num3 = 1429208906;
							num4 = num3;
						}
						else
						{
							num3 = 1429208907;
							num4 = num3;
						}
					}
					continue;
					end_IL_0016:
					break;
				}
			}
			return num;
		}

		public int GetJoystickLayoutIndex(int id)
		{
			if (joystickLayouts == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1137224175;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x43C8A9EB)
				{
				case 3:
					break;
				case 0:
					return num;
				case 4:
					num2 = 1137224169;
					continue;
				case 5:
					if (joystickLayouts[num].id != id)
					{
						num++;
						num2 = 1137224169;
					}
					else
					{
						num2 = 1137224171;
					}
					continue;
				case 1:
					return 0;
				default:
					if (num >= joystickLayouts.Count)
					{
						return -1;
					}
					goto case 5;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1137224170;
			goto IL_000d;
		}

		public string[] GetJoystickLayoutNames()
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			string[] array = new string[joystickLayouts.Count];
			int num2 = default(int);
			while (true)
			{
				int num = -1871234940;
				while (true)
				{
					switch (num ^ -1871234939)
					{
					case 3:
						break;
					case 1:
						num2 = 0;
						num = -1871234944;
						continue;
					case 2:
						num2++;
						num = -1871234944;
						continue;
					case 0:
						array[num2] = joystickLayouts[num2].name;
						num = -1871234937;
						continue;
					case 5:
					{
						int num3;
						if (num2 >= joystickLayouts.Count)
						{
							num = -1871234943;
							num3 = num;
						}
						else
						{
							num = -1871234939;
							num3 = num;
						}
						continue;
					}
					default:
						return array;
					}
					break;
				}
			}
		}

		public int[] GetJoystickLayoutIds()
		{
			if (joystickLayouts == null)
			{
				goto IL_0008;
			}
			int[] array = new int[joystickLayouts.Count];
			int num = 0;
			int num2 = -1287909763;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1287909764)
				{
				case 0:
					break;
				case 2:
					num++;
					num2 = -1287909763;
					continue;
				case 4:
					array[num] = joystickLayouts[num].id;
					num2 = -1287909762;
					continue;
				case 3:
					return null;
				default:
					if (num >= joystickLayouts.Count)
					{
						return array;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1287909761;
			goto IL_000d;
		}

		public InputLayout GetJoystickLayout(int index)
		{
			if (joystickLayouts != null)
			{
				while (true)
				{
					int num = -752977678;
					while (true)
					{
						switch (num ^ -752977679)
						{
						case 0:
							break;
						case 3:
							goto IL_002a;
						case 1:
							goto IL_003f;
						default:
							goto end_IL_0008;
						}
						break;
						IL_003f:
						if (index >= joystickLayouts.Count)
						{
							num = -752977677;
							continue;
						}
						return joystickLayouts[index];
						IL_002a:
						int num2;
						if (index < 0)
						{
							num = -752977677;
							num2 = num;
						}
						else
						{
							num = -752977680;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public InputLayout GetJoystickLayout(string name)
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			int num = IndexOfJoystickLayout(name);
			if (num < 0)
			{
				return null;
			}
			return joystickLayouts[num];
		}

		public InputLayout GetJoystickLayoutById(int id)
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			int num = IndexOfJoystickLayout(id);
			if (num < 0)
			{
				return null;
			}
			return joystickLayouts[num];
		}

		public int GetJoystickLayoutId(string name)
		{
			if (joystickLayouts == null)
			{
				return -1;
			}
			int num = IndexOfJoystickLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return joystickLayouts[num].id;
		}

		public int IndexOfJoystickLayout(int id)
		{
			if (joystickLayouts == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = -564351213;
				while (true)
				{
					switch (num2 ^ -564351214)
					{
					case 2:
						break;
					case 1:
						num2 = -564351214;
						continue;
					case 3:
						if (joystickLayouts[num].id == id)
						{
							return num;
						}
						num++;
						num2 = -564351214;
						continue;
					default:
						if (num >= joystickLayouts.Count)
						{
							return -1;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public int IndexOfJoystickLayout(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (joystickLayouts != null)
				{
					num = 0;
					num2 = 1954340939;
				}
				else
				{
					num2 = 1954340936;
				}
				goto IL_0015;
			}
			goto IL_0068;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x747CE049)
				{
				case 0:
					break;
				case 3:
					goto IL_0036;
				case 1:
					return -1;
				case 4:
					goto IL_0068;
				default:
					if (num >= joystickLayouts.Count)
					{
						return -1;
					}
					goto IL_0036;
				}
				break;
				IL_0036:
				if (joystickLayouts[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = 1954340939;
			}
			goto IL_0010;
			IL_0010:
			num2 = 1954340941;
			goto IL_0015;
			IL_0068:
			return -1;
		}

		public string GetJoystickLayoutNameById(int id)
		{
			if (joystickLayouts != null)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= joystickLayouts.Count)
					{
						num2 = 1122300147;
						num3 = num2;
					}
					else
					{
						num2 = 1122300146;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x42E4F0F3)
						{
						case 3:
							num2 = 1122300146;
							continue;
						case 1:
							break;
						case 2:
							goto end_IL_0011;
						default:
							goto end_IL_005f;
						}
						if (joystickLayouts[num].id == id)
						{
							return joystickLayouts[num].name;
						}
						num++;
						num2 = 1122300145;
						continue;
						end_IL_0011:
						break;
					}
					continue;
					end_IL_005f:
					break;
				}
			}
			return "Unknown";
		}

		public void AddKeyboardLayout()
		{
			keyboardLayouts.Add(QLRyeYPFXCVPOfCCmiNpChRiwNOa());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -792353644;
					while (true)
					{
						switch (num ^ -792353643)
						{
						case 0:
							break;
						case 1:
							goto IL_0026;
						case 2:
							goto end_IL_0004;
						default:
							keyboardLayouts.Insert(index, QLRyeYPFXCVPOfCCmiNpChRiwNOa());
							return;
						}
						break;
						IL_0026:
						int num2;
						if (index < keyboardLayouts.Count)
						{
							num = -792353642;
							num2 = num;
						}
						else
						{
							num = -792353641;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteKeyboardLayout(int index)
		{
			if (keyboardLayouts != null && index >= 0)
			{
				if (index >= keyboardLayouts.Count)
				{
					goto IL_0023;
				}
				goto IL_00ac;
			}
			goto IL_014b;
			IL_00ac:
			int id = keyboardLayouts[index].id;
			int num = default(int);
			int num2;
			if (keyboardMaps != null)
			{
				num = keyboardMaps.Count - 1;
				num2 = 1163524929;
				goto IL_0028;
			}
			goto IL_00de;
			IL_014b:
			throw new ArgumentOutOfRangeException("index");
			IL_0023:
			num2 = 1163524935;
			goto IL_0028;
			IL_0028:
			int num3 = default(int);
			Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
			while (true)
			{
				switch (num2 ^ 0x4559FB42)
				{
				case 13:
					break;
				case 6:
					goto IL_0070;
				case 10:
				{
					Player_Editor player_Editor = players[num3];
					if (player_Editor != null)
					{
						cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultKeyboardMaps, id);
						num2 = 1163524937;
						continue;
					}
					goto case 11;
				}
				case 9:
					goto IL_00ac;
				case 7:
					goto IL_00de;
				case 2:
					goto IL_010b;
				case 3:
					goto IL_0133;
				case 5:
					goto IL_014b;
				case 0:
					num2 = 1163524934;
					continue;
				case 4:
					goto IL_016a;
				case 1:
					num--;
					num2 = 1163524929;
					continue;
				case 12:
					keyboardMaps.RemoveAt(num);
					num2 = 1163524931;
					continue;
				case 11:
					num3++;
					num2 = 1163524934;
					continue;
				default:
					goto IL_01be;
				}
				break;
				IL_016a:
				int num4;
				if (num3 >= players.Count)
				{
					num2 = 1163524938;
					num4 = num2;
				}
				else
				{
					num2 = 1163524936;
					num4 = num2;
				}
				continue;
				IL_0133:
				int num5;
				if (num < 0)
				{
					num2 = 1163524933;
					num5 = num2;
				}
				else
				{
					num2 = 1163524928;
					num5 = num2;
				}
				continue;
				IL_010b:
				int num6;
				if (keyboardMaps[num].layoutId != id)
				{
					num2 = 1163524931;
					num6 = num2;
				}
				else
				{
					num2 = 1163524942;
					num6 = num2;
				}
			}
			goto IL_0023;
			IL_00de:
			if (players != null)
			{
				if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate64 == null)
				{
					CS_0024_003C_003E9__CachedAnonymousMethodDelegate64 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
					{
						if (P_0 == null)
						{
							return;
						}
						while (true)
						{
							int num7 = P_0.Count - 1;
							int num8 = -1245745999;
							while (true)
							{
								switch (num8 ^ -1245745997)
								{
								case 6:
									num8 = -1245745993;
									continue;
								default:
									return;
								case 8:
								{
									int num10;
									if (num7 < 0)
									{
										num8 = -1245746000;
										num10 = num8;
									}
									else
									{
										num8 = -1245745994;
										num10 = num8;
									}
									continue;
								}
								case 5:
								{
									int num11;
									if (P_0[num7] == null)
									{
										num8 = -1245745998;
										num11 = num8;
									}
									else
									{
										num8 = -1245745996;
										num11 = num8;
									}
									continue;
								}
								case 1:
									P_0.RemoveAt(num7);
									num8 = -1245745997;
									continue;
								case 0:
									num7--;
									num8 = -1245745989;
									continue;
								case 2:
									num8 = -1245745989;
									continue;
								case 7:
								{
									int num9;
									if (P_0[num7].layoutId == P_1)
									{
										num8 = -1245745998;
										num9 = num8;
									}
									else
									{
										num8 = -1245745997;
										num9 = num8;
									}
									continue;
								}
								case 4:
									break;
								case 3:
									return;
								}
								break;
							}
						}
					};
					num2 = 1163524932;
					goto IL_0028;
				}
				goto IL_0070;
			}
			goto IL_01be;
			IL_01be:
			keyboardLayouts.RemoveAt(index);
			return;
			IL_0070:
			cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate64;
			num3 = 0;
			num2 = 1163524930;
			goto IL_0028;
		}

		public bool ReorderKeyboardLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(keyboardLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateKeyboardLayout(int index, bool duplicateMaps)
		{
			if (keyboardLayouts != null)
			{
				int num2 = default(int);
				int id2 = default(int);
				int id = default(int);
				InputLayout inputLayout = default(InputLayout);
				while (true)
				{
					int num = 1658688630;
					while (true)
					{
						switch (num ^ 0x62DD9475)
						{
						case 7:
							break;
						default:
							return;
						case 2:
							if (keyboardMaps[num2].layoutId == id2)
							{
								int num3 = DuplicateKeyboardMap(num2);
								if (num3 >= 0)
								{
									keyboardMaps[num3].layoutId = id;
									num = 1658688629;
									continue;
								}
							}
							goto case 0;
						case 4:
							goto end_IL_000b;
						case 1:
							inputLayout = keyboardLayouts[index].Clone();
							inputLayout.id = GetNewKeyboardLayoutId();
							num = 1658688624;
							continue;
						case 5:
							inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetKeyboardLayoutNames());
							if (index == keyboardLayouts.Count - 1)
							{
								keyboardLayouts.Add(inputLayout);
								num = 1658688633;
								continue;
							}
							goto case 6;
						case 10:
							goto IL_0117;
						case 0:
							num2--;
							num = 1658688639;
							continue;
						case 8:
							if (keyboardMaps != null)
							{
								num2 = keyboardMaps.Count - 1;
								num = 1658688639;
								continue;
							}
							return;
						case 9:
							id = inputLayout.id;
							id2 = keyboardLayouts[index].id;
							num = 1658688637;
							continue;
						case 6:
							keyboardLayouts.Insert(index + 1, inputLayout);
							num = 1658688633;
							continue;
						case 3:
							goto IL_019c;
						case 12:
							goto IL_01c5;
						case 11:
							return;
						}
						break;
						IL_01c5:
						int num4;
						if (duplicateMaps)
						{
							num = 1658688636;
							num4 = num;
						}
						else
						{
							num = 1658688638;
							num4 = num;
						}
						continue;
						IL_019c:
						if (index < 0)
						{
							goto end_IL_000b;
						}
						int num5;
						if (index >= keyboardLayouts.Count)
						{
							num = 1658688625;
							num5 = num;
						}
						else
						{
							num = 1658688628;
							num5 = num;
						}
						continue;
						IL_0117:
						int num6;
						if (num2 >= 0)
						{
							num = 1658688631;
							num6 = num;
						}
						else
						{
							num = 1658688638;
							num6 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetKeyboardLayoutMapCount(int id)
		{
			if (keyboardLayouts == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = default(int);
			int num3;
			if (keyboardMaps != null)
			{
				num2 = 0;
				num3 = 1922995553;
				goto IL_000d;
			}
			goto IL_00a8;
			IL_000d:
			while (true)
			{
				switch (num3 ^ 0x729E9560)
				{
				case 0:
					break;
				case 2:
					return 0;
				case 3:
					goto IL_004b;
				case 5:
					num2++;
					num3 = 1922995553;
					continue;
				case 6:
					num++;
					num3 = 1922995557;
					continue;
				case 1:
					goto IL_0086;
				default:
					goto IL_00a8;
				}
				break;
				IL_0086:
				int num4;
				if (num2 >= keyboardMaps.Count)
				{
					num3 = 1922995556;
					num4 = num3;
				}
				else
				{
					num3 = 1922995555;
					num4 = num3;
				}
				continue;
				IL_004b:
				int num5;
				if (keyboardMaps[num2].layoutId == id)
				{
					num3 = 1922995558;
					num5 = num3;
				}
				else
				{
					num3 = 1922995557;
					num5 = num3;
				}
			}
			goto IL_0008;
			IL_00a8:
			return num;
			IL_0008:
			num3 = 1922995554;
			goto IL_000d;
		}

		public int GetKeyboardLayoutIndex(int id)
		{
			if (keyboardLayouts == null)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1799577661;
				while (true)
				{
					switch (num2 ^ -1799577662)
					{
					case 3:
						break;
					case 1:
						num2 = -1799577664;
						continue;
					case 0:
						if (keyboardLayouts[num].id == id)
						{
							return num;
						}
						num++;
						num2 = -1799577664;
						continue;
					default:
						if (num >= keyboardLayouts.Count)
						{
							return -1;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public string[] GetKeyboardLayoutNames()
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			string[] array = new string[keyboardLayouts.Count];
			int num2 = default(int);
			while (true)
			{
				int num = 613752895;
				while (true)
				{
					switch (num ^ 0x2495203C)
					{
					case 0:
						break;
					case 3:
						num2 = 0;
						num = 613752894;
						continue;
					case 1:
						array[num2] = keyboardLayouts[num2].name;
						num2++;
						num = 613752894;
						continue;
					default:
						if (num2 >= keyboardLayouts.Count)
						{
							return array;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public int[] GetKeyboardLayoutIds()
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int[] array = new int[keyboardLayouts.Count];
			int num2 = default(int);
			while (true)
			{
				int num = -231080403;
				while (true)
				{
					switch (num ^ -231080401)
					{
					case 0:
						break;
					case 2:
						num2 = 0;
						num = -231080404;
						continue;
					case 1:
						array[num2] = keyboardLayouts[num2].id;
						num2++;
						num = -231080404;
						continue;
					default:
						if (num2 >= keyboardLayouts.Count)
						{
							return array;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public InputLayout GetKeyboardLayout(int index)
		{
			if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
			{
				return null;
			}
			return keyboardLayouts[index];
		}

		public InputLayout GetKeyboardLayout(string name)
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int num = IndexOfKeyboardLayout(name);
			if (num < 0)
			{
				return null;
			}
			return keyboardLayouts[num];
		}

		public InputLayout GetKeyboardLayoutById(int id)
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int num = IndexOfKeyboardLayout(id);
			if (num < 0)
			{
				return null;
			}
			return keyboardLayouts[num];
		}

		public int GetKeyboardLayoutId(string name)
		{
			if (keyboardLayouts == null)
			{
				return -1;
			}
			int num = IndexOfKeyboardLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return keyboardLayouts[num].id;
		}

		public int IndexOfKeyboardLayout(int id)
		{
			if (keyboardLayouts == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = 716674836;
				while (true)
				{
					switch (num2 ^ 0x2AB79716)
					{
					case 0:
						break;
					case 2:
						num2 = 716674834;
						continue;
					case 3:
						if (keyboardLayouts[num].id == id)
						{
							num2 = 716674839;
							continue;
						}
						num++;
						num2 = 716674834;
						continue;
					case 4:
					{
						int num3;
						if (num >= keyboardLayouts.Count)
						{
							num2 = 716674835;
							num3 = num2;
						}
						else
						{
							num2 = 716674837;
							num3 = num2;
						}
						continue;
					}
					case 1:
						return num;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public int IndexOfKeyboardLayout(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (keyboardLayouts == null)
				{
					return -1;
				}
				num = 0;
				num2 = 367558096;
				goto IL_0015;
			}
			goto IL_0064;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x15E87DD4)
				{
				case 3:
					break;
				case 2:
					return num;
				case 0:
					goto IL_0043;
				case 1:
					goto IL_0064;
				default:
					if (num >= keyboardLayouts.Count)
					{
						return -1;
					}
					goto IL_0043;
				}
				break;
				IL_0043:
				if (!keyboardLayouts[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					num++;
					num2 = 367558096;
				}
				else
				{
					num2 = 367558102;
				}
			}
			goto IL_0010;
			IL_0010:
			num2 = 367558101;
			goto IL_0015;
			IL_0064:
			return -1;
		}

		public string GetKeyboardLayoutNameById(int id)
		{
			if (keyboardLayouts != null)
			{
				int num = 0;
				while (true)
				{
					int num2 = -745172708;
					while (true)
					{
						switch (num2 ^ -745172705)
						{
						case 4:
							break;
						case 3:
							num2 = -745172707;
							continue;
						case 2:
							goto IL_0037;
						case 1:
							goto IL_0056;
						default:
							goto end_IL_000a;
						}
						break;
						IL_0056:
						if (keyboardLayouts[num].id == id)
						{
							return keyboardLayouts[num].name;
						}
						num++;
						num2 = -745172707;
						continue;
						IL_0037:
						int num3;
						if (num < keyboardLayouts.Count)
						{
							num2 = -745172706;
							num3 = num2;
						}
						else
						{
							num2 = -745172705;
							num3 = num2;
						}
					}
					continue;
					end_IL_000a:
					break;
				}
			}
			return "Unknown";
		}

		public void AddMouseLayout()
		{
			mouseLayouts.Add(sVWOdrUnBQIviCODztlqJGKNDrck());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0)
			{
				goto IL_0034;
			}
			if (index >= mouseLayouts.Count)
			{
				goto IL_0012;
			}
			goto IL_0046;
			IL_0046:
			mouseLayouts.Insert(index, sVWOdrUnBQIviCODztlqJGKNDrck());
			int num = -274711800;
			goto IL_0017;
			IL_0012:
			num = -274711797;
			goto IL_0017;
			IL_0017:
			switch (num ^ -274711798)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0034;
			case 3:
				goto IL_0046;
			case 2:
				return;
			}
			goto IL_0012;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteMouseLayout(int index)
		{
			if (mouseLayouts != null)
			{
				int id = default(int);
				int num2 = default(int);
				int num3 = default(int);
				Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
				Player_Editor player_Editor = default(Player_Editor);
				while (true)
				{
					int num = -930548697;
					while (true)
					{
						switch (num ^ -930548695)
						{
						case 0:
							break;
						default:
							return;
						case 4:
							goto IL_0064;
						case 1:
							goto IL_0089;
						case 12:
							id = mouseLayouts[index].id;
							if (mouseMaps != null)
							{
								num2 = mouseMaps.Count - 1;
								num = -930548703;
								continue;
							}
							goto case 9;
						case 3:
							num3++;
							num = -930548696;
							continue;
						case 8:
							goto IL_00eb;
						case 7:
							goto end_IL_000b;
						case 16:
							mouseLayouts.RemoveAt(index);
							num = -930548692;
							continue;
						case 6:
							num2--;
							num = -930548703;
							continue;
						case 9:
							if (players == null)
							{
								goto case 16;
							}
							if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate66 == null)
							{
								CS_0024_003C_003E9__CachedAnonymousMethodDelegate66 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
								{
									if (P_0 == null)
									{
										return;
									}
									while (true)
									{
										int num9 = P_0.Count - 1;
										int num10 = 977695804;
										while (true)
										{
											switch (num10 ^ 0x3A46743F)
											{
											case 4:
												num10 = 977695806;
												continue;
											case 1:
												break;
											case 0:
												P_0.RemoveAt(num9);
												num10 = 977695801;
												continue;
											case 2:
											{
												int num12;
												if (P_0[num9] == null)
												{
													num10 = 977695807;
													num12 = num10;
												}
												else
												{
													num10 = 977695802;
													num12 = num10;
												}
												continue;
											}
											case 6:
												num9--;
												num10 = 977695804;
												continue;
											case 5:
											{
												int num11;
												if (P_0[num9].layoutId != P_1)
												{
													num10 = 977695801;
													num11 = num10;
												}
												else
												{
													num10 = 977695807;
													num11 = num10;
												}
												continue;
											}
											default:
												if (num9 < 0)
												{
													return;
												}
												goto case 2;
											}
											break;
										}
									}
								};
								num = -930548693;
								continue;
							}
							goto case 2;
						case 2:
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate66;
							num3 = 0;
							num = -930548696;
							continue;
						case 13:
							if (player_Editor != null)
							{
								cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultMouseMaps, id);
								num = -930548694;
								continue;
							}
							goto case 3;
						case 11:
							player_Editor = players[num3];
							num = -930548700;
							continue;
						case 15:
							mouseMaps.RemoveAt(num2);
							num = -930548689;
							continue;
						case 10:
							goto IL_01c5;
						case 14:
							goto IL_01e7;
						case 5:
							return;
						}
						break;
						IL_01e7:
						int num4;
						if (index >= 0)
						{
							num = -930548701;
							num4 = num;
						}
						else
						{
							num = -930548690;
							num4 = num;
						}
						continue;
						IL_0064:
						int num5;
						if (mouseMaps[num2].layoutId != id)
						{
							num = -930548689;
							num5 = num;
						}
						else
						{
							num = -930548698;
							num5 = num;
						}
						continue;
						IL_00eb:
						int num6;
						if (num2 < 0)
						{
							num = -930548704;
							num6 = num;
						}
						else
						{
							num = -930548691;
							num6 = num;
						}
						continue;
						IL_01c5:
						int num7;
						if (index >= mouseLayouts.Count)
						{
							num = -930548690;
							num7 = num;
						}
						else
						{
							num = -930548699;
							num7 = num;
						}
						continue;
						IL_0089:
						int num8;
						if (num3 < players.Count)
						{
							num = -930548702;
							num8 = num;
						}
						else
						{
							num = -930548679;
							num8 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderMouseLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mouseLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateMouseLayout(int index, bool duplicateMaps)
		{
			if (mouseLayouts != null && index >= 0)
			{
				int num2 = default(int);
				int id = default(int);
				int id2 = default(int);
				InputLayout inputLayout = default(InputLayout);
				while (true)
				{
					int num = 234457727;
					while (true)
					{
						switch (num ^ 0xDF98A7C)
						{
						case 4:
							break;
						default:
							return;
						case 2:
							num2 = mouseMaps.Count - 1;
							num = 234457724;
							continue;
						case 7:
							if (mouseMaps[num2].layoutId == id)
							{
								int num3 = DuplicateMouseMap(num2);
								if (num3 >= 0)
								{
									mouseMaps[num3].layoutId = id2;
									num = 234457716;
									continue;
								}
							}
							goto case 8;
						case 8:
							num2--;
							num = 234457724;
							continue;
						case 3:
							goto IL_00b5;
						case 1:
							goto end_IL_0012;
						case 0:
							goto IL_00ec;
						case 10:
							goto IL_0104;
						case 9:
							mouseLayouts.Insert(index + 1, inputLayout);
							num = 234457718;
							continue;
						case 5:
							inputLayout = mouseLayouts[index].Clone();
							inputLayout.id = GetNewMouseLayoutId();
							inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetMouseLayoutNames());
							if (index == mouseLayouts.Count - 1)
							{
								mouseLayouts.Add(inputLayout);
								num = 234457718;
								continue;
							}
							goto case 9;
						case 6:
							return;
						}
						break;
						IL_0104:
						if (duplicateMaps)
						{
							id2 = inputLayout.id;
							id = mouseLayouts[index].id;
							int num4;
							if (mouseMaps != null)
							{
								num = 234457726;
								num4 = num;
							}
							else
							{
								num = 234457722;
								num4 = num;
							}
							continue;
						}
						return;
						IL_00b5:
						int num5;
						if (index < mouseLayouts.Count)
						{
							num = 234457721;
							num5 = num;
						}
						else
						{
							num = 234457725;
							num5 = num;
						}
						continue;
						IL_00ec:
						int num6;
						if (num2 >= 0)
						{
							num = 234457723;
							num6 = num;
						}
						else
						{
							num = 234457722;
							num6 = num;
						}
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetMouseLayoutMapCount(int id)
		{
			if (mouseLayouts == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = default(int);
			int num3;
			if (mouseMaps != null)
			{
				num2 = 0;
				num3 = -402569861;
				goto IL_000d;
			}
			goto IL_00b6;
			IL_000d:
			while (true)
			{
				switch (num3 ^ -402569861)
				{
				case 7:
					break;
				case 1:
					num2++;
					num3 = -402569859;
					continue;
				case 0:
					num3 = -402569859;
					continue;
				case 4:
					return 0;
				case 2:
					goto IL_0061;
				case 6:
					goto IL_0086;
				case 5:
					num++;
					num3 = -402569862;
					continue;
				default:
					goto IL_00b6;
				}
				break;
				IL_0086:
				int num4;
				if (num2 < mouseMaps.Count)
				{
					num3 = -402569863;
					num4 = num3;
				}
				else
				{
					num3 = -402569864;
					num4 = num3;
				}
				continue;
				IL_0061:
				int num5;
				if (mouseMaps[num2].layoutId == id)
				{
					num3 = -402569858;
					num5 = num3;
				}
				else
				{
					num3 = -402569862;
					num5 = num3;
				}
			}
			goto IL_0008;
			IL_00b6:
			return num;
			IL_0008:
			num3 = -402569857;
			goto IL_000d;
		}

		public int GetMouseLayoutIndex(int id)
		{
			if (mouseLayouts == null)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				int num2 = -524169107;
				while (true)
				{
					switch (num2 ^ -524169106)
					{
					case 0:
						break;
					case 3:
						num2 = -524169108;
						continue;
					case 4:
						return num;
					case 1:
						if (mouseLayouts[num].id != id)
						{
							num++;
							num2 = -524169108;
						}
						else
						{
							num2 = -524169110;
						}
						continue;
					default:
						if (num >= mouseLayouts.Count)
						{
							return -1;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public string[] GetMouseLayoutNames()
		{
			if (mouseLayouts == null)
			{
				goto IL_0008;
			}
			string[] array = new string[mouseLayouts.Count];
			int num = 0;
			int num2 = -944824642;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -944824644)
				{
				case 0:
					break;
				case 3:
					return null;
				case 1:
					goto IL_0046;
				default:
					if (num < mouseLayouts.Count)
					{
						goto IL_0046;
					}
					return array;
				}
				break;
				IL_0046:
				array[num] = mouseLayouts[num].name;
				num++;
				num2 = -944824642;
			}
			goto IL_0008;
			IL_0008:
			num2 = -944824641;
			goto IL_000d;
		}

		public int[] GetMouseLayoutIds()
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int[] array = new int[mouseLayouts.Count];
			int num = 0;
			while (num < mouseLayouts.Count)
			{
				while (true)
				{
					array[num] = mouseLayouts[num].id;
					num++;
					int num2 = 2082982764;
					while (true)
					{
						switch (num2 ^ 0x7C27CB6D)
						{
						case 0:
							num2 = 2082982767;
							continue;
						case 2:
							break;
						default:
							goto end_IL_003d;
						}
						break;
					}
					continue;
					end_IL_003d:
					break;
				}
			}
			return array;
		}

		public InputLayout GetMouseLayout(int index)
		{
			if (mouseLayouts != null)
			{
				while (true)
				{
					int num = 1546419495;
					while (true)
					{
						switch (num ^ 0x5C2C7D26)
						{
						case 0:
							break;
						case 1:
							goto IL_002a;
						case 3:
							goto IL_003f;
						default:
							goto end_IL_0008;
						}
						break;
						IL_003f:
						if (index >= mouseLayouts.Count)
						{
							num = 1546419492;
							continue;
						}
						return mouseLayouts[index];
						IL_002a:
						int num2;
						if (index >= 0)
						{
							num = 1546419493;
							num2 = num;
						}
						else
						{
							num = 1546419492;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public InputLayout GetMouseLayout(string name)
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int num = IndexOfMouseLayout(name);
			if (num < 0)
			{
				return null;
			}
			return mouseLayouts[num];
		}

		public InputLayout GetMouseLayoutById(int id)
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int num = IndexOfMouseLayout(id);
			if (num < 0)
			{
				return null;
			}
			return mouseLayouts[num];
		}

		public int GetMouseLayoutId(string name)
		{
			if (mouseLayouts == null)
			{
				return -1;
			}
			int num = IndexOfMouseLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return mouseLayouts[num].id;
		}

		public int IndexOfMouseLayout(int id)
		{
			if (mouseLayouts == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1727991134;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1727991136)
				{
				case 4:
					break;
				case 3:
					return -1;
				case 2:
					num2 = -1727991136;
					continue;
				case 1:
					if (mouseLayouts[num].id == id)
					{
						return num;
					}
					num++;
					num2 = -1727991136;
					continue;
				default:
					if (num >= mouseLayouts.Count)
					{
						return -1;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1727991133;
			goto IL_000d;
		}

		public int IndexOfMouseLayout(string name)
		{
			int num;
			int num2 = default(int);
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (mouseLayouts == null)
				{
					num = 918998129;
				}
				else
				{
					num2 = 0;
					num = 918998131;
				}
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num ^ 0x36C6CC70)
				{
				case 4:
					break;
				case 2:
					goto IL_0036;
				case 0:
					goto IL_0047;
				case 1:
					return -1;
				default:
					if (num2 >= mouseLayouts.Count)
					{
						return -1;
					}
					goto IL_0047;
				}
				break;
				IL_0047:
				if (mouseLayouts[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num2;
				}
				num2++;
				num = 918998131;
			}
			goto IL_0010;
			IL_0010:
			num = 918998130;
			goto IL_0015;
			IL_0036:
			return -1;
		}

		public string GetMouseLayoutNameById(int id)
		{
			if (mouseLayouts != null)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < mouseLayouts.Count)
					{
						num2 = -763021037;
						num3 = num2;
					}
					else
					{
						num2 = -763021039;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -763021040)
						{
						case 0:
							num2 = -763021037;
							continue;
						case 3:
							break;
						case 2:
							goto end_IL_0011;
						default:
							goto end_IL_005f;
						}
						if (mouseLayouts[num].id == id)
						{
							return mouseLayouts[num].name;
						}
						num++;
						num2 = -763021038;
						continue;
						end_IL_0011:
						break;
					}
					continue;
					end_IL_005f:
					break;
				}
			}
			return "Unknown";
		}

		public void AddCustomControllerLayout()
		{
			customControllerLayouts.Add(hLYVpAShAueSrhirvyEpLlBiSSra());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0)
			{
				goto IL_0034;
			}
			if (index >= customControllerLayouts.Count)
			{
				goto IL_0012;
			}
			goto IL_0046;
			IL_0046:
			customControllerLayouts.Insert(index, hLYVpAShAueSrhirvyEpLlBiSSra());
			int num = -1612883303;
			goto IL_0017;
			IL_0012:
			num = -1612883301;
			goto IL_0017;
			IL_0017:
			switch (num ^ -1612883302)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0034;
			case 2:
				goto IL_0046;
			case 3:
				return;
			}
			goto IL_0012;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteCustomControllerLayout(int index)
		{
			if (customControllerLayouts != null && index >= 0)
			{
				int num2 = default(int);
				Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
				int num3 = default(int);
				int id = default(int);
				while (true)
				{
					int num = 1281609637;
					while (true)
					{
						switch (num ^ 0x4C63CFA6)
						{
						case 10:
							break;
						case 0:
							if (players != null)
							{
								if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate68 == null)
								{
									CS_0024_003C_003E9__CachedAnonymousMethodDelegate68 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
									{
										if (P_0 == null)
										{
											return;
										}
										while (true)
										{
											int num9 = P_0.Count - 1;
											int num10 = 2093685031;
											while (true)
											{
												switch (num10 ^ 0x7CCB1922)
												{
												case 2:
													num10 = 2093685027;
													continue;
												case 1:
													break;
												case 3:
													P_0.RemoveAt(num9);
													num10 = 2093685026;
													continue;
												case 4:
													if (P_0[num9] != null)
													{
														int num11;
														if (P_0[num9].layoutId == P_1)
														{
															num10 = 2093685025;
															num11 = num10;
														}
														else
														{
															num10 = 2093685026;
															num11 = num10;
														}
														continue;
													}
													goto case 3;
												case 0:
													num9--;
													num10 = 2093685031;
													continue;
												default:
													if (num9 < 0)
													{
														return;
													}
													goto case 4;
												}
												break;
											}
										}
									};
									num = 1281609640;
									continue;
								}
								goto case 14;
							}
							goto default;
						case 2:
							goto end_IL_000c;
						case 4:
							goto IL_009c;
						case 1:
							customControllerMaps.RemoveAt(num2);
							num = 1281609645;
							continue;
						case 11:
							num2--;
							num = 1281609643;
							continue;
						case 14:
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate68;
							num3 = 0;
							num = 1281609647;
							continue;
						case 6:
						{
							Player_Editor player_Editor = players[num3];
							if (player_Editor != null)
							{
								cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultCustomControllerMaps, id);
								num = 1281609633;
								continue;
							}
							goto case 7;
						}
						case 7:
							num3++;
							num = 1281609647;
							continue;
						case 9:
							goto IL_0132;
						case 8:
							num2 = customControllerMaps.Count - 1;
							num = 1281609643;
							continue;
						case 13:
							goto IL_016c;
						case 3:
							goto IL_0184;
						case 12:
							goto IL_01a6;
						default:
							customControllerLayouts.RemoveAt(index);
							return;
						}
						break;
						IL_01a6:
						id = customControllerLayouts[index].id;
						int num4;
						if (customControllerMaps != null)
						{
							num = 1281609646;
							num4 = num;
						}
						else
						{
							num = 1281609638;
							num4 = num;
						}
						continue;
						IL_009c:
						int num5;
						if (customControllerMaps[num2].layoutId != id)
						{
							num = 1281609645;
							num5 = num;
						}
						else
						{
							num = 1281609639;
							num5 = num;
						}
						continue;
						IL_016c:
						int num6;
						if (num2 >= 0)
						{
							num = 1281609634;
							num6 = num;
						}
						else
						{
							num = 1281609638;
							num6 = num;
						}
						continue;
						IL_0184:
						int num7;
						if (index < customControllerLayouts.Count)
						{
							num = 1281609642;
							num7 = num;
						}
						else
						{
							num = 1281609636;
							num7 = num;
						}
						continue;
						IL_0132:
						int num8;
						if (num3 < players.Count)
						{
							num = 1281609632;
							num8 = num;
						}
						else
						{
							num = 1281609635;
							num8 = num;
						}
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderCustomControllerLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllerLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateCustomControllerLayout(int index, bool duplicateMaps)
		{
			if (customControllerLayouts != null && index >= 0)
			{
				int num2 = default(int);
				int id2 = default(int);
				InputLayout inputLayout = default(InputLayout);
				int id = default(int);
				while (true)
				{
					int num = 641040075;
					while (true)
					{
						switch (num ^ 0x26357EC2)
						{
						case 13:
							break;
						default:
							return;
						case 2:
						{
							int num3 = DuplicateCustomControllerMap(num2);
							if (num3 >= 0)
							{
								customControllerMaps[num3].layoutId = id2;
								num = 641040072;
								continue;
							}
							goto case 10;
						}
						case 12:
							goto end_IL_000f;
						case 11:
							id2 = inputLayout.id;
							num = 641040074;
							continue;
						case 9:
							goto IL_00b1;
						case 4:
							customControllerLayouts.Insert(index + 1, inputLayout);
							num = 641040065;
							continue;
						case 0:
							goto IL_00ec;
						case 3:
							goto IL_0114;
						case 5:
							num = 641040065;
							continue;
						case 6:
							goto IL_0135;
						case 14:
							num = 641040068;
							continue;
						case 10:
							num2--;
							num = 641040068;
							continue;
						case 7:
							inputLayout = customControllerLayouts[index].Clone();
							inputLayout.id = GetNewCustomControllerLayoutId();
							inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetCustomControllerLayoutNames());
							if (index == customControllerLayouts.Count - 1)
							{
								customControllerLayouts.Add(inputLayout);
								num = 641040071;
								continue;
							}
							goto case 4;
						case 8:
							id = customControllerLayouts[index].id;
							if (customControllerMaps != null)
							{
								num2 = customControllerMaps.Count - 1;
								num = 641040076;
								continue;
							}
							return;
						case 1:
							return;
						}
						break;
						IL_0135:
						int num4;
						if (num2 < 0)
						{
							num = 641040067;
							num4 = num;
						}
						else
						{
							num = 641040066;
							num4 = num;
						}
						continue;
						IL_00ec:
						int num5;
						if (customControllerMaps[num2].layoutId != id)
						{
							num = 641040072;
							num5 = num;
						}
						else
						{
							num = 641040064;
							num5 = num;
						}
						continue;
						IL_00b1:
						int num6;
						if (index < customControllerLayouts.Count)
						{
							num = 641040069;
							num6 = num;
						}
						else
						{
							num = 641040078;
							num6 = num;
						}
						continue;
						IL_0114:
						int num7;
						if (!duplicateMaps)
						{
							num = 641040067;
							num7 = num;
						}
						else
						{
							num = 641040073;
							num7 = num;
						}
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetCustomControllerLayoutMapCount(int id)
		{
			if (customControllerLayouts == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1769680014;
			goto IL_000d;
			IL_000d:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x697B2C8D)
				{
				case 2:
					break;
				case 8:
					num3 = 0;
					num2 = 1769680011;
					continue;
				case 5:
					num3++;
					num2 = 1769680013;
					continue;
				case 6:
					num2 = 1769680013;
					continue;
				case 1:
					return 0;
				case 3:
				{
					int num5;
					if (customControllerMaps == null)
					{
						num2 = 1769680009;
						num5 = num2;
					}
					else
					{
						num2 = 1769680005;
						num5 = num2;
					}
					continue;
				}
				case 7:
					if (customControllerMaps[num3].layoutId == id)
					{
						num++;
						num2 = 1769680008;
						continue;
					}
					goto case 5;
				case 0:
				{
					int num4;
					if (num3 >= customControllerMaps.Count)
					{
						num2 = 1769680009;
						num4 = num2;
					}
					else
					{
						num2 = 1769680010;
						num4 = num2;
					}
					continue;
				}
				default:
					return num;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1769680012;
			goto IL_000d;
		}

		public int GetCustomControllerLayoutIndex(int id)
		{
			if (customControllerLayouts == null)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < customControllerLayouts.Count)
				{
					num2 = -1847724065;
					num3 = num2;
				}
				else
				{
					num2 = -1847724072;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1847724069)
					{
					case 2:
						num2 = -1847724065;
						continue;
					case 4:
						if (customControllerLayouts[num].id == id)
						{
							num2 = -1847724069;
							continue;
						}
						num++;
						num2 = -1847724070;
						continue;
					case 1:
						break;
					case 0:
						return num;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public string[] GetCustomControllerLayoutNames()
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			string[] array = new string[customControllerLayouts.Count];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < customControllerLayouts.Count)
				{
					num2 = 935530830;
					num3 = num2;
				}
				else
				{
					num2 = 935530831;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x37C3114F)
					{
					case 3:
						num2 = 935530830;
						continue;
					case 1:
						array[num] = customControllerLayouts[num].name;
						num++;
						num2 = 935530829;
						continue;
					case 2:
						break;
					default:
						return array;
					}
					break;
				}
			}
		}

		public int[] GetCustomControllerLayoutIds()
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			int[] array = new int[customControllerLayouts.Count];
			int num2 = default(int);
			while (true)
			{
				int num = -687999699;
				while (true)
				{
					switch (num ^ -687999700)
					{
					case 3:
						break;
					case 1:
						num2 = 0;
						num = -687999700;
						continue;
					case 2:
						array[num2] = customControllerLayouts[num2].id;
						num2++;
						num = -687999700;
						continue;
					default:
						if (num2 >= customControllerLayouts.Count)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public InputLayout GetCustomControllerLayout(int index)
		{
			if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
			{
				return null;
			}
			return customControllerLayouts[index];
		}

		public InputLayout GetCustomControllerLayout(string name)
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			int num = IndexOfCustomControllerLayout(name);
			if (num < 0)
			{
				return null;
			}
			return customControllerLayouts[num];
		}

		public InputLayout GetCustomControllerLayoutById(int id)
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			int num = IndexOfCustomControllerLayout(id);
			if (num < 0)
			{
				return null;
			}
			return customControllerLayouts[num];
		}

		public int GetCustomControllerLayoutId(string name)
		{
			if (customControllerLayouts == null)
			{
				return -1;
			}
			int num = IndexOfCustomControllerLayout(name);
			if (num < 0)
			{
				return -1;
			}
			return customControllerLayouts[num].id;
		}

		public int IndexOfCustomControllerLayout(int id)
		{
			if (customControllerLayouts == null)
			{
				return -1;
			}
			int num = 0;
			while (num < customControllerLayouts.Count)
			{
				while (true)
				{
					if (customControllerLayouts[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = 1286719665;
					while (true)
					{
						switch (num2 ^ 0x4CB1C8B3)
						{
						case 0:
							num2 = 1286719666;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return -1;
		}

		public int IndexOfCustomControllerLayout(string name)
		{
			int num;
			int num2 = default(int);
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (customControllerLayouts == null)
				{
					num = -1182678899;
				}
				else
				{
					num2 = 0;
					num = -1182678900;
				}
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num ^ -1182678900)
				{
				case 3:
					break;
				case 2:
					goto IL_0036;
				case 4:
					goto IL_0047;
				case 1:
					return -1;
				default:
					if (num2 >= customControllerLayouts.Count)
					{
						return -1;
					}
					goto IL_0047;
				}
				break;
				IL_0047:
				if (customControllerLayouts[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num2;
				}
				num2++;
				num = -1182678900;
			}
			goto IL_0010;
			IL_0010:
			num = -1182678898;
			goto IL_0015;
			IL_0036:
			return -1;
		}

		public string GetCustomControllerLayoutNameById(int id)
		{
			if (customControllerLayouts != null)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= customControllerLayouts.Count)
					{
						num2 = -1141641608;
						num3 = num2;
					}
					else
					{
						num2 = -1141641606;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1141641605)
						{
						case 2:
							num2 = -1141641606;
							continue;
						case 1:
							break;
						case 0:
							goto end_IL_0011;
						default:
							goto end_IL_005f;
						}
						if (customControllerLayouts[num].id == id)
						{
							return customControllerLayouts[num].name;
						}
						num++;
						num2 = -1141641605;
						continue;
						end_IL_0011:
						break;
					}
					continue;
					end_IL_005f:
					break;
				}
			}
			return "Unknown";
		}

		public string GetLayoutNameById(ControllerType controllerType, int id)
		{
			switch (controllerType)
			{
			case ControllerType.Joystick:
				return GetJoystickLayoutNameById(id);
			case ControllerType.Keyboard:
				return GetKeyboardLayoutNameById(id);
			case ControllerType.Mouse:
				return GetMouseLayoutNameById(id);
			case ControllerType.Custom:
				return GetCustomControllerLayoutNameById(id);
			default:
				throw new NotImplementedException();
			}
		}

		internal ControllerMap YfrotiMuknQjHOeFlUzPLpOYrQj(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				while (true)
				{
					switch (0x3CACD461 ^ 0x3CACD463)
					{
					case 0:
						continue;
					case 2:
						return null;
					}
					break;
				}
			}
			else
			{
				switch (P_0.type)
				{
				case ControllerType.Joystick:
					break;
				case ControllerType.Keyboard:
					return FindKeyboardMap_Game(P_1, P_2);
				case ControllerType.Mouse:
					return FindMouseMap_Game(P_1, P_2);
				case ControllerType.Custom:
					return QfrgqtjxgxKXOuevaNKXmvMWczo(P_1, ((CustomController)P_0).sourceControllerId, P_2);
				default:
					throw new NotImplementedException();
				}
			}
			return hMkypZTzfqeaSawZHpjeONQgshs((Joystick)P_0, P_1, P_2);
		}

		public ControllerMap_Editor GetJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1515915125;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1515915126)
				{
				case 5:
					break;
				case 3:
					return null;
				case 2:
					if (joystickMaps[num].categoryId == categoryId && joystickMaps[num].layoutId == layoutId && StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
					{
						num2 = -1515915122;
						continue;
					}
					num++;
					num2 = -1515915125;
					continue;
				case 1:
				{
					int num3;
					if (num < joystickMaps.Count)
					{
						num2 = -1515915128;
						num3 = num2;
					}
					else
					{
						num2 = -1515915126;
						num3 = num2;
					}
					continue;
				}
				case 4:
					return joystickMaps[num];
				default:
					return null;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1515915127;
			goto IL_000d;
		}

		public ControllerMap_Editor GetJoystickMapById(int id, out int joystickMapIndex)
		{
			joystickMapIndex = -1;
			if (joystickMaps == null)
			{
				return null;
			}
			int num = 0;
			while (num < joystickMaps.Count)
			{
				while (true)
				{
					int num2;
					if (joystickMaps[num].id == id)
					{
						joystickMapIndex = num;
						num2 = 1593643231;
					}
					else
					{
						num++;
						num2 = 1593643228;
					}
					while (true)
					{
						switch (num2 ^ 0x5EFD10DC)
						{
						case 2:
							num2 = 1593643229;
							continue;
						case 1:
							break;
						case 3:
							return joystickMaps[num];
						default:
							goto end_IL_0033;
						}
						break;
					}
					continue;
					end_IL_0033:
					break;
				}
			}
			return null;
		}

		public List<ControllerMap_Editor> GetJoystickMaps(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				return null;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			int num = 0;
			while (num < joystickMaps.Count)
			{
				while (true)
				{
					int num2;
					if (StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
					{
						list.Add(joystickMaps[num]);
						num2 = -1298124384;
						goto IL_0019;
					}
					goto IL_006d;
					IL_0019:
					while (true)
					{
						switch (num2 ^ -1298124384)
						{
						case 2:
							num2 = -1298124381;
							continue;
						case 3:
							break;
						case 0:
							goto IL_006d;
						default:
							goto end_IL_0036;
						}
						break;
					}
					continue;
					IL_006d:
					num++;
					num2 = -1298124383;
					goto IL_0019;
					continue;
					end_IL_0036:
					break;
				}
			}
			return list;
		}

		public int GetJoystickMapId(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return -1;
			}
			int num = 0;
			while (num < joystickMaps.Count)
			{
				while (true)
				{
					int num2;
					if (joystickMaps[num].categoryId == categoryId && joystickMaps[num].layoutId == layoutId && StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
					{
						num2 = 297252093;
					}
					else
					{
						num++;
						num2 = 297252095;
					}
					while (true)
					{
						switch (num2 ^ 0x11B7B4FC)
						{
						case 0:
							num2 = 297252094;
							continue;
						case 2:
							break;
						case 1:
							return joystickMaps[num].id;
						default:
							goto end_IL_0033;
						}
						break;
					}
					continue;
					end_IL_0033:
					break;
				}
			}
			return -1;
		}

		public bool HasJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 907742641;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x361B0DB2)
				{
				case 0:
					break;
				case 4:
					return false;
				case 2:
					if (joystickMaps[num].categoryId == categoryId && joystickMaps[num].layoutId == layoutId && StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
					{
						num2 = 907742643;
						continue;
					}
					num++;
					num2 = 907742641;
					continue;
				case 1:
					return true;
				default:
					if (num >= joystickMaps.Count)
					{
						return false;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 907742646;
			goto IL_000d;
		}

		public bool HasJoystickMap(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1692087394;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x64DB3462)
				{
				case 2:
					break;
				case 1:
					return false;
				case 3:
					if (!(StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid))
					{
						goto IL_0055;
					}
					return true;
				default:
					if (num >= joystickMaps.Count)
					{
						return false;
					}
					goto case 3;
				}
				break;
				IL_0055:
				num++;
				num2 = 1692087394;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1692087395;
			goto IL_000d;
		}

		public bool HasJoystickMapInCategory(Guid hardwareGuid, int categoryId)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			int num = 0;
			while (num < joystickMaps.Count)
			{
				while (true)
				{
					if (StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid && joystickMaps[num].categoryId == categoryId)
					{
						return true;
					}
					num++;
					int num2 = 659572669;
					while (true)
					{
						switch (num2 ^ 0x275047BC)
						{
						case 0:
							num2 = 659572670;
							continue;
						case 2:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return false;
		}

		public bool CreateJoystickMap(int categoryId, Guid joystickOrTemplateGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				joystickMaps = new List<ControllerMap_Editor>();
				goto IL_0013;
			}
			goto IL_0039;
			IL_0039:
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewJoystickMapId();
			int num = 1076716432;
			goto IL_0018;
			IL_0013:
			num = 1076716436;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ 0x402D6390)
				{
				case 2:
					break;
				case 4:
					goto IL_0039;
				case 0:
					controllerMap_Editor.categoryId = categoryId;
					controllerMap_Editor.layoutId = layoutId;
					num = 1076716435;
					continue;
				case 3:
					controllerMap_Editor.hardwareGuidString = joystickOrTemplateGuid.ToString();
					joystickMaps.Add(controllerMap_Editor);
					num = 1076716433;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_0013;
		}

		public void DeleteJoystickMap(int id)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			goto IL_0041;
			IL_0008:
			int num = -1600155208;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1600155207)
				{
				case 5:
					break;
				default:
					return;
				case 0:
					num2--;
					num = -1600155205;
					continue;
				case 3:
					goto IL_0041;
				case 6:
					if (joystickMaps[num2].id == id)
					{
						joystickMaps.RemoveAt(num2);
						num = -1600155207;
						continue;
					}
					goto case 0;
				case 2:
					goto IL_007d;
				case 1:
					return;
				case 4:
					return;
				}
				break;
				IL_007d:
				int num3;
				if (num2 < 0)
				{
					num = -1600155203;
					num3 = num;
				}
				else
				{
					num = -1600155201;
					num3 = num;
				}
			}
			goto IL_0008;
			IL_0041:
			num2 = joystickMaps.Count - 1;
			num = -1600155205;
			goto IL_000d;
		}

		public int DuplicateJoystickMap(int index)
		{
			if (joystickMaps != null)
			{
				while (true)
				{
					int num = -1763010713;
					while (true)
					{
						switch (num ^ -1763010714)
						{
						case 4:
							break;
						case 1:
							goto IL_002e;
						case 3:
							goto end_IL_0008;
						case 2:
						{
							ControllerMap_Editor controllerMap_Editor = joystickMaps[index].Clone();
							controllerMap_Editor.id = GetNewJoystickMapId();
							joystickMaps.Add(controllerMap_Editor);
							num = -1763010714;
							continue;
						}
						default:
							return joystickMaps.Count - 1;
						}
						break;
						IL_002e:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num2;
						if (index < joystickMaps.Count)
						{
							num = -1763010716;
							num2 = num;
						}
						else
						{
							num = -1763010715;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		internal JoystickMap IXQGteQrRsyvfPhwsbmlpoRVOZQ(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return hMkypZTzfqeaSawZHpjeONQgshs(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap hMkypZTzfqeaSawZHpjeONQgshs(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return hMkypZTzfqeaSawZHpjeONQgshs(P_0.hardwareJoystickMapIdentifier, P_1, P_2);
		}

		private JoystickMap hMkypZTzfqeaSawZHpjeONQgshs(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.EoOpRBJjGdsjzFYByddrqEnpIABD(guid);
			JoystickMap joystickMap = default(JoystickMap);
			HardwareJoystickTemplateMap hardwareJoystickTemplateMap = default(HardwareJoystickTemplateMap);
			ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
			while (true)
			{
				int num = 1440166042;
				while (true)
				{
					int num5;
					switch (num ^ 0x55D7309B)
					{
					case 0:
						break;
					case 1:
						controllerMap_Editor = fPCzfkfmmZeiCvOsHMAdJpDdtOq(P_1, guid, P_2, false);
						if (controllerMap_Editor != null)
						{
							num = 1440166040;
							continue;
						}
						if (hardwareJoystickMap != null)
						{
							using (IEnumerator<Guid> enumerator = hardwareJoystickMap.TemplateGuids.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										Guid current = enumerator.Current;
										int num2;
										int num3;
										if (current == Guid.Empty)
										{
											num2 = 1440166041;
											num3 = num2;
										}
										else
										{
											num2 = 1440166045;
											num3 = num2;
										}
										while (true)
										{
											switch (num2 ^ 0x55D7309B)
											{
											case 0:
												num2 = 1440166046;
												continue;
											case 1:
												if (joystickMap != null)
												{
													joystickMap.SetIdentity(guid, P_1, P_2);
													num2 = 1440166047;
													continue;
												}
												goto end_IL_0139;
											case 6:
												break;
											case 3:
												joystickMap = zIYiOvevPJfPlQncqBdRcfcfWhB(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
												num2 = 1440166042;
												continue;
											case 4:
												return joystickMap;
											case 5:
												goto end_IL_009a;
											default:
												goto end_IL_0139;
											}
											hardwareJoystickTemplateMap = ReInput.AkUcEkvnHgqlWfVhjztPFZUUQuC(current);
											if (!(hardwareJoystickTemplateMap != null))
											{
												goto end_IL_0139;
											}
											controllerMap_Editor = fPCzfkfmmZeiCvOsHMAdJpDdtOq(P_1, current, P_2, false);
											int num4;
											if (controllerMap_Editor == null)
											{
												num2 = 1440166041;
												num4 = num2;
											}
											else
											{
												num2 = 1440166040;
												num4 = num2;
											}
											continue;
											end_IL_009a:
											break;
										}
										continue;
										end_IL_0139:
										break;
									}
								}
							}
						}
						if (!(guid == Guid.Empty))
						{
							goto IL_0188;
						}
						goto IL_01b8;
					case 3:
						joystickMap = controllerMap_Editor.VBSqrvDMnHWQrGAHHGgQMkxDWLx(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
						num = 1440166041;
						continue;
					default:
						{
							joystickMap.SetIdentity(guid, P_1, P_2);
							return joystickMap;
						}
						IL_018d:
						while (true)
						{
							switch (num5 ^ 0x55D7309B)
							{
							case 4:
								break;
							case 1:
								goto IL_01ae;
							case 3:
								joystickMap.SetIdentity(guid, P_1, P_2);
								num5 = 1440166041;
								continue;
							case 0:
								goto IL_01cf;
							default:
								goto IL_0207;
							}
							break;
							IL_0207:
							if (joystickMap != null)
							{
								return joystickMap;
							}
							goto IL_020c;
							IL_01ae:
							if (1 == 0)
							{
								goto IL_01b8;
							}
							goto IL_020c;
							IL_01cf:
							controllerMap_Editor = fPCzfkfmmZeiCvOsHMAdJpDdtOq(P_1, Guid.Empty, P_2, false);
							if (controllerMap_Editor != null)
							{
								joystickMap = controllerMap_Editor.VBSqrvDMnHWQrGAHHGgQMkxDWLx(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
								num5 = 1440166040;
								continue;
							}
							goto IL_020c;
							IL_020c:
							return JoystickMap.Blank(guid, P_1, P_2);
						}
						goto IL_0188;
						IL_01b8:
						num5 = 1440166043;
						goto IL_018d;
						IL_0188:
						num5 = 1440166042;
						goto IL_018d;
					}
					break;
				}
			}
		}

		private ControllerMap_Editor fPCzfkfmmZeiCvOsHMAdJpDdtOq(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor controllerMap_Editor = GetJoystickMap(P_0, P_1, P_2);
			while (true)
			{
				int num = -81058497;
				while (true)
				{
					switch (num ^ -81058499)
					{
					case 3:
						break;
					case 2:
						if (controllerMap_Editor != null)
						{
							num = -81058500;
							continue;
						}
						if (P_3)
						{
							controllerMap_Editor = qgknegDUIgvPPRgMtCSjGWxiCFkQ(P_0, P_1, P_2);
							if (controllerMap_Editor != null)
							{
								num = -81058499;
								continue;
							}
						}
						return null;
					case 1:
						return controllerMap_Editor;
					default:
						return controllerMap_Editor;
					}
					break;
				}
			}
		}

		private ControllerMap_Editor qgknegDUIgvPPRgMtCSjGWxiCFkQ(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = -852205544;
				while (true)
				{
					switch (num ^ -852205538)
					{
					case 2:
						break;
					case 5:
						if (list[num2].categoryId == P_0)
						{
							return list[num2];
						}
						num2++;
						num = -852205543;
						continue;
					case 7:
					{
						int num5;
						if (num2 < list.Count)
						{
							num = -852205541;
							num5 = num;
						}
						else
						{
							num = -852205538;
							num5 = num;
						}
						continue;
					}
					case 6:
						if (list != null && list.Count > 0)
						{
							cRKpQqSuAucyDExrbcSzTLhYBwq(list, joystickLayouts);
							num = -852205539;
							continue;
						}
						goto default;
					case 4:
						if (list[num3].categoryId == 0)
						{
							return list[num3];
						}
						num3++;
						num = -852205537;
						continue;
					case 0:
						num3 = 0;
						num = -852205537;
						continue;
					case 1:
					{
						int num4;
						if (num3 >= list.Count)
						{
							num = -852205546;
							num4 = num;
						}
						else
						{
							num = -852205542;
							num4 = num;
						}
						continue;
					}
					case 3:
						num2 = 0;
						num = -852205543;
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		private JoystickMap zIYiOvevPJfPlQncqBdRcfcfWhB(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				goto IL_0009;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			string text = default(string);
			int num;
			if (!P_2.eiQXXOJjgLNEdQEQbXcDIsgesQS(controllerMap_Editor, P_3, P_0.guid, out text))
			{
				num = 1970560482;
				goto IL_000e;
			}
			return controllerMap_Editor.VBSqrvDMnHWQrGAHHGgQMkxDWLx(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
			IL_0009:
			num = 1970560481;
			goto IL_000e;
			IL_000e:
			object[] array = default(object[]);
			while (true)
			{
				switch (num ^ 0x75745DE4)
				{
				case 4:
					break;
				case 5:
					return null;
				case 6:
					array = new object[6] { "Error remapping joystick template ", null, null, null, null, null };
					num = 1970560487;
					continue;
				case 3:
					array[1] = P_2.Guid;
					num = 1970560484;
					continue;
				case 1:
					array[3] = P_0.guid;
					array[4] = "\nReason: ";
					array[5] = text;
					Logger.LogError(string.Concat(array));
					num = 1970560486;
					continue;
				case 0:
					array[2] = " to joystick ";
					num = 1970560485;
					continue;
				default:
					return null;
				}
				break;
			}
			goto IL_0009;
		}

		private JoystickMap YGbnItFwwBEIZikkpEFQZNNjAgjG(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.EoOpRBJjGdsjzFYByddrqEnpIABD(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				goto IL_001a;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.EoOpRBJjGdsjzFYByddrqEnpIABD(Guid.Empty);
			int num = 192326709;
			goto IL_001f;
			IL_001f:
			int[] buttons = default(int[]);
			int[] axes = default(int[]);
			bool flag = default(bool);
			int result = default(int);
			int num4 = default(int);
			string name = default(string);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0xB76AC31)
				{
				case 2:
					break;
				case 3:
					return null;
				case 4:
					if (hardwareJoystickMap2 == null)
					{
						num = 192326704;
						continue;
					}
					hardwareJoystickMap.GetElementIdentifiersForControllerElements(P_1, isDefaultMap: false, out buttons, out axes);
					if (buttons == null && axes == null)
					{
						return null;
					}
					flag = false;
					num = 192326705;
					continue;
				case 1:
					return null;
				default:
				{
					List<int> list = new List<int>();
					using (IEnumerator<ActionElementMap> enumerator = P_0.AllMaps.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							while (true)
							{
								ActionElementMap current = enumerator.Current;
								ControllerElementIdentifier elementIdentifier = hardwareJoystickMap2.GetElementIdentifier(current._elementIdentifierId);
								int num2 = 192326711;
								while (true)
								{
									switch (num2 ^ 0xB76AC31)
									{
									case 2:
										num2 = 192326715;
										continue;
									case 10:
										break;
									case 1:
										list.Add(current.tqPurZpByiUWRrPJKwHxxaZZua);
										num2 = 192326709;
										continue;
									case 11:
										if (result < axes.Length)
										{
											current._elementIdentifierId = axes[result];
											num2 = 192326708;
											continue;
										}
										goto case 1;
									case 8:
										if (num4 == 1)
										{
											goto IL_0137;
										}
										goto case 3;
									case 3:
									{
										string text = Regex.Replace(name, "[^0-9]+", "");
										Logger.Log(text);
										if (int.TryParse(text, out result))
										{
											if (num4 != 0)
											{
												goto case 11;
											}
											if (result < buttons.Length)
											{
												current._elementIdentifierId = buttons[result];
												num2 = 192326712;
												continue;
											}
										}
										goto case 1;
									}
									case 6:
										if (elementIdentifier != null)
										{
											name = elementIdentifier.name;
											if (!string.IsNullOrEmpty(name))
											{
												num4 = 0;
												num2 = 192326705;
												continue;
											}
										}
										goto case 1;
									case 5:
										flag = true;
										num2 = 192326709;
										continue;
									case 9:
										num2 = 192326708;
										continue;
									case 0:
										num3 = name.IndexOf("button", 0, StringComparison.OrdinalIgnoreCase);
										if (num3 < 0)
										{
											num3 = name.IndexOf("axis", 0, StringComparison.OrdinalIgnoreCase);
											num4 = 1;
											num2 = 192326710;
											continue;
										}
										goto case 7;
									case 7:
										if (num3 < 0)
										{
											goto case 1;
										}
										if (num4 != 0)
										{
											goto case 8;
										}
										goto IL_0214;
									default:
										goto end_IL_00e2;
									}
									break;
									IL_0214:
									int num5;
									if (buttons == null)
									{
										num2 = 192326704;
										num5 = num2;
									}
									else
									{
										num2 = 192326713;
										num5 = num2;
									}
									continue;
									IL_0137:
									int num6;
									if (axes != null)
									{
										num2 = 192326706;
										num6 = num2;
									}
									else
									{
										num2 = 192326704;
										num6 = num2;
									}
								}
								continue;
								end_IL_00e2:
								break;
							}
						}
					}
					int num7 = 0;
					while (true)
					{
						int num8 = 192326704;
						while (true)
						{
							switch (num8 ^ 0xB76AC31)
							{
							case 2:
								break;
							case 1:
								num8 = 192326705;
								continue;
							case 3:
								P_0.DeleteElementMap(list[num7]);
								num7++;
								num8 = 192326705;
								continue;
							default:
								if (num7 >= list.Count)
								{
									if (!flag)
									{
										return null;
									}
									return P_0;
								}
								goto case 3;
							}
							break;
						}
					}
				}
				}
				break;
			}
			goto IL_001a;
			IL_001a:
			num = 192326706;
			goto IL_001f;
		}

		public ControllerMap_Editor GetKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -449516402;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -449516402)
				{
				case 3:
					break;
				case 1:
					return null;
				case 2:
					if (keyboardMaps[num].layoutId == layoutId)
					{
						num2 = -449516406;
						continue;
					}
					goto IL_008b;
				case 5:
					if (keyboardMaps[num].categoryId == categoryId)
					{
						num2 = -449516404;
						continue;
					}
					goto IL_008b;
				case 0:
					num2 = -449516408;
					continue;
				case 4:
					return keyboardMaps[num];
				default:
					{
						if (num >= keyboardMaps.Count)
						{
							return null;
						}
						goto case 5;
					}
					IL_008b:
					num++;
					num2 = -449516408;
					continue;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -449516401;
			goto IL_000d;
		}

		public int GetKeyboardMapId(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return -1;
			}
			int num = 0;
			while (num < keyboardMaps.Count)
			{
				while (true)
				{
					int num2;
					if (keyboardMaps[num].categoryId == categoryId && keyboardMaps[num].layoutId == layoutId)
					{
						num2 = 2076145893;
					}
					else
					{
						num++;
						num2 = 2076145892;
					}
					while (true)
					{
						switch (num2 ^ 0x7BBF78E6)
						{
						case 0:
							num2 = 2076145895;
							continue;
						case 1:
							break;
						case 3:
							return keyboardMaps[num].id;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return -1;
		}

		public bool HasKeyboardMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			int num = 0;
			while (num < keyboardMaps.Count)
			{
				while (true)
				{
					int num2;
					if (keyboardMaps[num].categoryId == categoryId)
					{
						num2 = 1450645205;
						goto IL_0016;
					}
					goto IL_008d;
					IL_0016:
					while (true)
					{
						switch (num2 ^ 0x567716D1)
						{
						case 0:
							num2 = 1450645202;
							continue;
						case 3:
							break;
						case 4:
							goto IL_0052;
						case 2:
							return true;
						default:
							goto end_IL_0037;
						}
						break;
						IL_0052:
						if (keyboardMaps[num].layoutId == layoutId && StringTools.ToGuid(keyboardMaps[num].hardwareGuidString) == hardwareGuid)
						{
							num2 = 1450645203;
							continue;
						}
						goto IL_008d;
					}
					continue;
					IL_008d:
					num++;
					num2 = 1450645200;
					goto IL_0016;
					continue;
					end_IL_0037:
					break;
				}
			}
			return false;
		}

		public bool CreateKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				goto IL_0008;
			}
			goto IL_003c;
			IL_0008:
			int num = 522650567;
			goto IL_000d;
			IL_000d:
			ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
			while (true)
			{
				switch (num ^ 0x1F2703C5)
				{
				case 0:
					break;
				case 2:
					keyboardMaps = new List<ControllerMap_Editor>();
					num = 522650564;
					continue;
				case 1:
					goto IL_003c;
				default:
					controllerMap_Editor.categoryId = categoryId;
					controllerMap_Editor.layoutId = layoutId;
					keyboardMaps.Add(controllerMap_Editor);
					return false;
				}
				break;
			}
			goto IL_0008;
			IL_003c:
			controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewKeyboardMapId();
			num = 522650566;
			goto IL_000d;
		}

		public void DeleteKeyboardMap(int id)
		{
			if (keyboardMaps == null)
			{
				return;
			}
			while (true)
			{
				int num = keyboardMaps.Count - 1;
				int num2 = 569047635;
				while (true)
				{
					switch (num2 ^ 0x21EAFA52)
					{
					case 2:
						num2 = 569047638;
						continue;
					case 4:
						break;
					case 3:
						num--;
						num2 = 569047635;
						continue;
					case 0:
						if (keyboardMaps[num].id == id)
						{
							keyboardMaps.RemoveAt(num);
							num2 = 569047633;
							continue;
						}
						goto case 3;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public int DuplicateKeyboardMap(int index)
		{
			if (keyboardMaps != null && index >= 0)
			{
				if (index < keyboardMaps.Count)
				{
					goto IL_004a;
				}
				while (true)
				{
					switch (-276453682 ^ -276453681)
					{
					case 0:
						break;
					case 1:
						goto end_IL_001a;
					default:
						goto IL_004a;
					}
					continue;
					end_IL_001a:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_004a:
			ControllerMap_Editor controllerMap_Editor = keyboardMaps[index].Clone();
			controllerMap_Editor.id = GetNewKeyboardMapId();
			keyboardMaps.Add(controllerMap_Editor);
			return keyboardMaps.Count - 1;
		}

		public ControllerMap_Editor GetKeyboardMapById(int id, out int keyboardMapIndex)
		{
			keyboardMapIndex = -1;
			int num2 = default(int);
			while (true)
			{
				int num = 1271779989;
				while (true)
				{
					switch (num ^ 0x4BCDD294)
					{
					case 3:
						break;
					case 4:
						if (keyboardMaps[num2].id == id)
						{
							keyboardMapIndex = num2;
							return keyboardMaps[num2];
						}
						num2++;
						num = 1271779988;
						continue;
					case 2:
						return null;
					case 1:
						if (keyboardMaps != null)
						{
							num2 = 0;
							num = 1271779988;
						}
						else
						{
							num = 1271779990;
						}
						continue;
					default:
						if (num2 >= keyboardMaps.Count)
						{
							return null;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public KeyboardMap FindKeyboardMap_Game(int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = UnngcCeOUSsvrJntNXiDmDYxLqpu(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			if (controllerMap_Editor != null)
			{
				goto IL_0019;
			}
			goto IL_0057;
			IL_0019:
			int num = 2080929714;
			goto IL_001e;
			IL_001e:
			KeyboardMap keyboardMap = default(KeyboardMap);
			while (true)
			{
				switch (num ^ 0x7C0877B0)
				{
				case 0:
					break;
				case 2:
					keyboardMap = controllerMap_Editor.WemcRkNxcNeYUDQGmfpkctxNHTu(containsActionDelegate);
					keyboardMap.SetIdentity(categoryId, layoutId);
					num = 2080929715;
					continue;
				case 1:
					goto IL_0057;
				default:
					return keyboardMap;
				}
				break;
			}
			goto IL_0019;
			IL_0057:
			keyboardMap = KeyboardMap.Blank(categoryId, layoutId);
			num = 2080929715;
			goto IL_001e;
		}

		public bool HasKeyboardMapInCategory(int categoryId)
		{
			if (keyboardMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 996221110;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x3B6120B2)
				{
				case 2:
					break;
				case 1:
					return false;
				case 0:
					return true;
				case 3:
					if (keyboardMaps[num].categoryId != categoryId)
					{
						num++;
						num2 = 996221110;
					}
					else
					{
						num2 = 996221106;
					}
					continue;
				default:
					if (num >= keyboardMaps.Count)
					{
						return false;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 996221107;
			goto IL_000d;
		}

		public bool HasKeyboardMapInLayout(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= keyboardMaps.Count)
				{
					num2 = 399535146;
					num3 = num2;
				}
				else
				{
					num2 = 399535147;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x17D06C28)
					{
					case 0:
						num2 = 399535147;
						continue;
					case 3:
						if (keyboardMaps[num].categoryId == categoryId && keyboardMaps[num].layoutId == layoutId)
						{
							num2 = 399535148;
							continue;
						}
						num++;
						num2 = 399535145;
						continue;
					case 1:
						break;
					case 4:
						return true;
					default:
						return false;
					}
					break;
				}
			}
		}

		public ControllerMap_Editor GetMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return null;
			}
			int num = 0;
			while (num < mouseMaps.Count)
			{
				while (true)
				{
					int num2;
					if (mouseMaps[num].categoryId == categoryId && mouseMaps[num].layoutId == layoutId)
					{
						num2 = 1542918067;
					}
					else
					{
						num++;
						num2 = 1542918064;
					}
					while (true)
					{
						switch (num2 ^ 0x5BF70FB2)
						{
						case 0:
							num2 = 1542918065;
							continue;
						case 3:
							break;
						case 1:
							return mouseMaps[num];
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return null;
		}

		public int GetMouseMapId(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return -1;
			}
			int num = 0;
			while (num < mouseMaps.Count)
			{
				while (true)
				{
					if (mouseMaps[num].categoryId == categoryId && mouseMaps[num].layoutId == layoutId)
					{
						return mouseMaps[num].id;
					}
					num++;
					int num2 = -934396542;
					while (true)
					{
						switch (num2 ^ -934396544)
						{
						case 0:
							num2 = -934396543;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return -1;
		}

		public bool HasMouseMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			int num = 0;
			while (num < mouseMaps.Count)
			{
				while (true)
				{
					int num2;
					if (mouseMaps[num].categoryId == categoryId && mouseMaps[num].layoutId == layoutId)
					{
						num2 = 973889683;
						goto IL_0016;
					}
					goto IL_0039;
					IL_0039:
					num++;
					num2 = 973889687;
					goto IL_0016;
					IL_0016:
					while (true)
					{
						switch (num2 ^ 0x3A0C6093)
						{
						case 2:
							num2 = 973889680;
							continue;
						case 1:
							return true;
						case 0:
							break;
						case 3:
							goto end_IL_0016;
						default:
							goto end_IL_0069;
						}
						if (StringTools.ToGuid(mouseMaps[num].hardwareGuidString) == hardwareGuid)
						{
							num2 = 973889682;
							continue;
						}
						goto IL_0039;
						continue;
						end_IL_0016:
						break;
					}
					continue;
					end_IL_0069:
					break;
				}
			}
			return false;
		}

		public bool CreateMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				mouseMaps = new List<ControllerMap_Editor>();
				goto IL_0013;
			}
			goto IL_0031;
			IL_0031:
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewMouseMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			int num = -570567982;
			goto IL_0018;
			IL_0013:
			num = -570567983;
			goto IL_0018;
			IL_0018:
			switch (num ^ -570567984)
			{
			case 0:
				break;
			case 1:
				goto IL_0031;
			default:
				mouseMaps.Add(controllerMap_Editor);
				return false;
			}
			goto IL_0013;
		}

		public void DeleteMouseMap(int id)
		{
			if (mouseMaps == null)
			{
				goto IL_0008;
			}
			goto IL_006c;
			IL_0008:
			int num = 331726446;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x13C5BE6F)
				{
				case 4:
					break;
				case 0:
					if (mouseMaps[num2].id == id)
					{
						mouseMaps.RemoveAt(num2);
						num = 331726445;
						continue;
					}
					goto case 2;
				case 2:
					num2--;
					num = 331726444;
					continue;
				case 1:
					return;
				case 5:
					goto IL_006c;
				default:
					if (num2 < 0)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_006c:
			num2 = mouseMaps.Count - 1;
			num = 331726444;
			goto IL_000d;
		}

		public int DuplicateMouseMap(int index)
		{
			if (mouseMaps != null)
			{
				while (true)
				{
					int num = 1082877611;
					while (true)
					{
						switch (num ^ 0x408B66AA)
						{
						case 2:
							break;
						case 1:
							goto IL_002a;
						case 0:
							goto end_IL_0008;
						default:
						{
							ControllerMap_Editor controllerMap_Editor = mouseMaps[index].Clone();
							controllerMap_Editor.id = GetNewMouseMapId();
							mouseMaps.Add(controllerMap_Editor);
							return mouseMaps.Count - 1;
						}
						}
						break;
						IL_002a:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num2;
						if (index >= mouseMaps.Count)
						{
							num = 1082877610;
							num2 = num;
						}
						else
						{
							num = 1082877609;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public ControllerMap_Editor GetMouseMapById(int id, out int mouseMapIndex)
		{
			mouseMapIndex = -1;
			if (mouseMaps == null)
			{
				return null;
			}
			int num = 0;
			while (num < mouseMaps.Count)
			{
				while (true)
				{
					if (mouseMaps[num].id == id)
					{
						mouseMapIndex = num;
						return mouseMaps[num];
					}
					num++;
					int num2 = 787092691;
					while (true)
					{
						switch (num2 ^ 0x2EEA14D3)
						{
						case 2:
							num2 = 787092690;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002f;
						}
						break;
					}
					continue;
					end_IL_002f:
					break;
				}
			}
			return null;
		}

		public MouseMap FindMouseMap_Game(int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = UnngcCeOUSsvrJntNXiDmDYxLqpu(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.JssclkKWoJeoDnDTqRbfzmxMBpq(containsActionDelegate);
				goto IL_0026;
			}
			goto IL_004c;
			IL_004c:
			mouseMap = MouseMap.Blank(categoryId, layoutId);
			int num = -1351427485;
			goto IL_002b;
			IL_0026:
			num = -1351427482;
			goto IL_002b;
			IL_002b:
			while (true)
			{
				switch (num ^ -1351427481)
				{
				case 0:
					break;
				case 2:
					goto IL_004c;
				case 3:
					num = -1351427485;
					continue;
				case 1:
					mouseMap.SetIdentity(categoryId, layoutId);
					num = -1351427484;
					continue;
				default:
					return mouseMap;
				}
				break;
			}
			goto IL_0026;
		}

		public bool HasMouseMapInCategory(int categoryId)
		{
			if (mouseMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 824182541;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x3120070D)
				{
				case 6:
					break;
				case 1:
					return false;
				case 0:
					num2 = 824182537;
					continue;
				case 4:
				{
					int num3;
					if (num < mouseMaps.Count)
					{
						num2 = 824182536;
						num3 = num2;
					}
					else
					{
						num2 = 824182542;
						num3 = num2;
					}
					continue;
				}
				case 5:
					if (mouseMaps[num].categoryId == categoryId)
					{
						num2 = 824182543;
						continue;
					}
					num++;
					num2 = 824182537;
					continue;
				case 2:
					return true;
				default:
					return false;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 824182540;
			goto IL_000d;
		}

		public bool HasMouseMapInLayout(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			int num = 0;
			while (num < mouseMaps.Count)
			{
				while (true)
				{
					if (mouseMaps[num].categoryId == categoryId && mouseMaps[num].layoutId == layoutId)
					{
						return true;
					}
					num++;
					int num2 = -906350950;
					while (true)
					{
						switch (num2 ^ -906350952)
						{
						case 0:
							num2 = -906350951;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return false;
		}

		public ControllerMap_Editor GetCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1531984945;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x5B503C32)
				{
				case 5:
					break;
				case 1:
					return null;
				case 2:
					if (customControllerMaps[num].customControllerUid == controllerUid)
					{
						num2 = 1531984950;
						continue;
					}
					goto IL_0065;
				case 4:
					return customControllerMaps[num];
				case 0:
					if (customControllerMaps[num].categoryId == categoryId && customControllerMaps[num].layoutId == layoutId)
					{
						num2 = 1531984944;
						continue;
					}
					goto IL_0065;
				default:
					{
						if (num >= customControllerMaps.Count)
						{
							return null;
						}
						goto case 0;
					}
					IL_0065:
					num++;
					num2 = 1531984945;
					continue;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1531984947;
			goto IL_000d;
		}

		public ControllerMap_Editor GetCustomControllerMapById(int mapId, out int customControllerMapIndex)
		{
			customControllerMapIndex = -1;
			if (customControllerMaps == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2 = 71767460;
				while (true)
				{
					switch (num2 ^ 0x44715A7)
					{
					case 0:
						break;
					case 1:
						return customControllerMaps[num];
					case 5:
						if (customControllerMaps[num].id != mapId)
						{
							num++;
							num2 = 71767461;
						}
						else
						{
							customControllerMapIndex = num;
							num2 = 71767462;
						}
						continue;
					case 2:
					{
						int num3;
						if (num < customControllerMaps.Count)
						{
							num2 = 71767458;
							num3 = num2;
						}
						else
						{
							num2 = 71767459;
							num3 = num2;
						}
						continue;
					}
					case 3:
						num2 = 71767461;
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		public List<ControllerMap_Editor> GetCustomControllerMaps(int controllerUid)
		{
			if (customControllerMaps == null)
			{
				return null;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			int num = 0;
			while (num < customControllerMaps.Count)
			{
				while (true)
				{
					int num2;
					if (customControllerMaps[num].customControllerUid == controllerUid)
					{
						list.Add(customControllerMaps[num]);
						num2 = -880489630;
						goto IL_0019;
					}
					goto IL_0063;
					IL_0019:
					while (true)
					{
						switch (num2 ^ -880489630)
						{
						case 3:
							num2 = -880489629;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0063;
						default:
							goto end_IL_0036;
						}
						break;
					}
					continue;
					IL_0063:
					num++;
					num2 = -880489632;
					goto IL_0019;
					continue;
					end_IL_0036:
					break;
				}
			}
			return list;
		}

		public int GetCustomControllerMapId(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				return -1;
			}
			int num = 0;
			while (num < customControllerMaps.Count)
			{
				while (true)
				{
					int num2;
					if (customControllerMaps[num].categoryId == categoryId && customControllerMaps[num].layoutId == layoutId && customControllerMaps[num].customControllerUid == controllerUid)
					{
						num2 = 1279393770;
					}
					else
					{
						num++;
						num2 = 1279393768;
					}
					while (true)
					{
						switch (num2 ^ 0x4C41FFE9)
						{
						case 0:
							num2 = 1279393771;
							continue;
						case 2:
							break;
						case 3:
							return customControllerMaps[num].id;
						default:
							goto end_IL_0033;
						}
						break;
					}
					continue;
					end_IL_0033:
					break;
				}
			}
			return -1;
		}

		public bool HasCustomControllerMap(int mapId, int categoryId, int layoutId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1772256414;
				while (true)
				{
					switch (num2 ^ -1772256410)
					{
					case 0:
						break;
					case 4:
						num2 = -1772256412;
						continue;
					case 1:
						if (customControllerMaps[num].categoryId == categoryId && customControllerMaps[num].layoutId == layoutId && customControllerMaps[num].id == mapId)
						{
							return true;
						}
						num++;
						num2 = -1772256412;
						continue;
					case 2:
					{
						int num3;
						if (num < customControllerMaps.Count)
						{
							num2 = -1772256409;
							num3 = num2;
						}
						else
						{
							num2 = -1772256411;
							num3 = num2;
						}
						continue;
					}
					default:
						return false;
					}
					break;
				}
			}
		}

		public bool HasCustomControllerMap(int mapId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = 1704564312;
				while (true)
				{
					switch (num2 ^ 0x6599965B)
					{
					case 0:
						break;
					case 3:
						num2 = 1704564319;
						continue;
					case 2:
						return true;
					case 1:
						if (customControllerMaps[num].id != mapId)
						{
							num++;
							num2 = 1704564319;
						}
						else
						{
							num2 = 1704564313;
						}
						continue;
					default:
						if (num >= customControllerMaps.Count)
						{
							return false;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public bool HasCustomControllerMapInCategory(int controllerUid, int categoryId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = 973486778;
				while (true)
				{
					switch (num2 ^ 0x3A063ABB)
					{
					case 3:
						break;
					case 1:
						num2 = 973486777;
						continue;
					case 0:
						if (customControllerMaps[num].customControllerUid == controllerUid && customControllerMaps[num].categoryId == categoryId)
						{
							return true;
						}
						num++;
						num2 = 973486777;
						continue;
					default:
						if (num >= customControllerMaps.Count)
						{
							return false;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public bool CreateCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				customControllerMaps = new List<ControllerMap_Editor>();
				goto IL_0013;
			}
			goto IL_0035;
			IL_0035:
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewCustomControllerMapId();
			int num = -266069695;
			goto IL_0018;
			IL_0013:
			num = -266069696;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ -266069695)
				{
				case 3:
					break;
				case 1:
					goto IL_0035;
				case 0:
					controllerMap_Editor.categoryId = categoryId;
					controllerMap_Editor.layoutId = layoutId;
					controllerMap_Editor.hardwareGuidString = string.Empty;
					num = -266069693;
					continue;
				default:
					controllerMap_Editor.customControllerUid = controllerUid;
					customControllerMaps.Add(controllerMap_Editor);
					return false;
				}
				break;
			}
			goto IL_0013;
		}

		public void DeleteCustomControllerMap(int mapId)
		{
			if (customControllerMaps == null)
			{
				return;
			}
			while (true)
			{
				int num = customControllerMaps.Count - 1;
				int num2 = -1758260215;
				while (true)
				{
					switch (num2 ^ -1758260214)
					{
					case 0:
						num2 = -1758260216;
						continue;
					case 2:
						break;
					case 4:
						num--;
						num2 = -1758260215;
						continue;
					case 1:
						customControllerMaps.RemoveAt(num);
						num2 = -1758260210;
						continue;
					case 5:
					{
						int num3;
						if (customControllerMaps[num].id != mapId)
						{
							num2 = -1758260210;
							num3 = num2;
						}
						else
						{
							num2 = -1758260213;
							num3 = num2;
						}
						continue;
					}
					default:
						if (num < 0)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		public int DuplicateCustomControllerMap(int index)
		{
			if (customControllerMaps == null || index < 0)
			{
				goto IL_003c;
			}
			if (index >= customControllerMaps.Count)
			{
				goto IL_001a;
			}
			goto IL_004e;
			IL_003c:
			throw new ArgumentOutOfRangeException("index");
			IL_004e:
			ControllerMap_Editor controllerMap_Editor = customControllerMaps[index].Clone();
			int num = -449255878;
			goto IL_001f;
			IL_001a:
			num = -449255877;
			goto IL_001f;
			IL_001f:
			switch (num ^ -449255878)
			{
			case 3:
				break;
			case 1:
				goto IL_003c;
			case 2:
				goto IL_004e;
			default:
				controllerMap_Editor.id = GetNewCustomControllerMapId();
				customControllerMaps.Add(controllerMap_Editor);
				return customControllerMaps.Count - 1;
			}
			goto IL_001a;
		}

		internal CustomControllerMap QfrgqtjxgxKXOuevaNKXmvMWczo(Guid P_0, int P_1, int P_2)
		{
			return QfrgqtjxgxKXOuevaNKXmvMWczo(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap QfrgqtjxgxKXOuevaNKXmvMWczo(int P_0, int P_1, int P_2)
		{
			return QfrgqtjxgxKXOuevaNKXmvMWczo(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap QfrgqtjxgxKXOuevaNKXmvMWczo(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			int id = P_0.id;
			int num = 292962733;
			goto IL_0008;
			IL_0008:
			ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
			CustomControllerMap customControllerMap = default(CustomControllerMap);
			while (true)
			{
				switch (num ^ 0x117641AE)
				{
				case 2:
					break;
				case 1:
					customControllerMap.SetIdentity(id, P_1, P_2);
					num = 292962734;
					continue;
				case 3:
					controllerMap_Editor = qKqaawcHBdZMDcfCRqJomIGwfKdn(P_1, id, P_2, false);
					num = 292962731;
					continue;
				case 4:
					return null;
				case 5:
					if (controllerMap_Editor != null)
					{
						customControllerMap = controllerMap_Editor.nkhnzynaOXhPKaCqfUYNoxfFfKnc(ContainsAction, P_0);
						customControllerMap.SetIdentity(id, P_1, P_2);
						return customControllerMap;
					}
					customControllerMap = CustomControllerMap.Blank(id, P_1, P_2);
					num = 292962735;
					continue;
				default:
					return customControllerMap;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num = 292962730;
			goto IL_0008;
		}

		private ControllerMap_Editor qKqaawcHBdZMDcfCRqJomIGwfKdn(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = CPFxXguaWIZUrbncPABmOpFXeba(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor CPFxXguaWIZUrbncPABmOpFXeba(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null)
			{
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = 403184053;
					while (true)
					{
						switch (num ^ 0x180819B4)
						{
						case 7:
							break;
						case 8:
							goto IL_004b;
						case 5:
							goto IL_0065;
						case 9:
							num3 = 0;
							num = 403184048;
							continue;
						case 1:
							if (list.Count > 0)
							{
								cRKpQqSuAucyDExrbcSzTLhYBwq(list, customControllerLayouts);
								num2 = 0;
								num = 403184054;
								continue;
							}
							goto end_IL_000e;
						case 3:
							goto IL_00a6;
						case 6:
							return list[num2];
						case 2:
							goto IL_00e0;
						case 4:
							num = 403184060;
							continue;
						default:
							goto end_IL_000e;
						}
						break;
						IL_00e0:
						int num4;
						if (num2 < list.Count)
						{
							num = 403184049;
							num4 = num;
						}
						else
						{
							num = 403184061;
							num4 = num;
						}
						continue;
						IL_0065:
						if (list[num2].categoryId == P_0)
						{
							num = 403184050;
							continue;
						}
						num2++;
						num = 403184054;
						continue;
						IL_004b:
						int num5;
						if (num3 >= list.Count)
						{
							num = 403184052;
							num5 = num;
						}
						else
						{
							num = 403184055;
							num5 = num;
						}
						continue;
						IL_00a6:
						if (list[num3].categoryId == 0)
						{
							return list[num3];
						}
						num3++;
						num = 403184060;
					}
					continue;
					end_IL_000e:
					break;
				}
			}
			return null;
		}

		public void DeleteControllerMap(ControllerType controllerType, int id)
		{
			int num;
			switch (controllerType)
			{
			default:
				num = 400144205;
				goto IL_001e;
			case ControllerType.Mouse:
				goto IL_004b;
			case ControllerType.Keyboard:
				goto IL_005a;
			case ControllerType.Custom:
				goto IL_0069;
			case ControllerType.Joystick:
				break;
				IL_001e:
				while (true)
				{
					switch (num ^ 0x17D9B74C)
					{
					case 7:
						break;
					case 0:
						goto IL_004b;
					case 3:
						goto IL_005a;
					case 2:
						goto IL_0069;
					case 4:
						return;
					case 5:
						goto end_IL_0003;
					case 1:
						num = 400144202;
						continue;
					default:
						throw new NotImplementedException();
					}
					break;
				}
				goto default;
				IL_0069:
				DeleteCustomControllerMap(id);
				num = 400144200;
				goto IL_001e;
				IL_005a:
				DeleteKeyboardMap(id);
				return;
				IL_004b:
				DeleteMouseMap(id);
				return;
				end_IL_0003:
				break;
			}
			DeleteJoystickMap(id);
		}

		public ControllerMap_Editor GetControllerMapByIndex(ControllerType controllerType, int index)
		{
			switch (controllerType)
			{
			default:
				while (true)
				{
					int num = -195516293;
					while (true)
					{
						switch (num ^ -195516295)
						{
						case 3:
							break;
						case 2:
							goto IL_0036;
						case 1:
							goto end_IL_0014;
						default:
							return null;
						}
						break;
						IL_0036:
						if (controllerType == ControllerType.Custom)
						{
							if (customControllerMaps == null)
							{
								num = -195516295;
								continue;
							}
							return customControllerMaps[index];
						}
						throw new NotImplementedException();
					}
					continue;
					end_IL_0014:
					break;
				}
				goto case ControllerType.Joystick;
			case ControllerType.Joystick:
				if (joystickMaps == null)
				{
					return null;
				}
				return joystickMaps[index];
			case ControllerType.Keyboard:
				if (keyboardMaps == null)
				{
					return null;
				}
				return keyboardMaps[index];
			case ControllerType.Mouse:
				if (mouseMaps == null)
				{
					return null;
				}
				return mouseMaps[index];
			}
		}

		public ControllerMap_Editor GetControllerMapById(ControllerType controllerType, int id, out int controllerMapIndex)
		{
			switch (controllerType)
			{
			default:
				while (true)
				{
					switch (0x661407A3 ^ 0x661407A1)
					{
					case 0:
						continue;
					case 2:
						throw new NotImplementedException();
					}
					break;
				}
				goto case ControllerType.Joystick;
			case ControllerType.Joystick:
				return GetJoystickMapById(id, out controllerMapIndex);
			case ControllerType.Keyboard:
				return GetKeyboardMapById(id, out controllerMapIndex);
			case ControllerType.Mouse:
				return GetMouseMapById(id, out controllerMapIndex);
			case ControllerType.Custom:
				return GetCustomControllerMapById(id, out controllerMapIndex);
			}
		}

		public int DuplicateControllerMap(ControllerType controllerType, int index)
		{
			while (true)
			{
				int num = -2075080025;
				while (true)
				{
					switch (num ^ -2075080028)
					{
					case 0:
						break;
					case 3:
						switch (controllerType)
						{
						default:
							goto IL_0036;
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return DuplicateKeyboardMap(index);
						case ControllerType.Mouse:
							return DuplicateMouseMap(index);
						}
						goto default;
					case 2:
						if (controllerType == ControllerType.Custom)
						{
							return DuplicateCustomControllerMap(index);
						}
						throw new NotImplementedException();
					default:
						return DuplicateJoystickMap(index);
					}
					break;
					IL_0036:
					num = -2075080026;
				}
			}
		}

		internal ControllerTemplateMap mlBpSGJBbWVCabYZEUfNXwmmhML(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.MKKPohgDyVlGheCiiHancGvCDlHE();
		}

		public void AddCustomController()
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			customControllers.Add(hTZbrXAKQEEqchpGqlSDiaSamEwc());
		}

		public void InsertCustomController(int index)
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
				goto IL_0013;
			}
			goto IL_0064;
			IL_0064:
			int num;
			if (index >= 0)
			{
				int num2;
				if (index < customControllers.Count)
				{
					num = -1414749913;
					num2 = num;
				}
				else
				{
					num = -1414749916;
					num2 = num;
				}
				goto IL_0018;
			}
			goto IL_0052;
			IL_0013:
			num = -1414749915;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ -1414749914)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					customControllers.Insert(index, hTZbrXAKQEEqchpGqlSDiaSamEwc());
					num = -1414749918;
					continue;
				case 2:
					goto IL_0052;
				case 3:
					goto IL_0064;
				case 4:
					return;
				}
				break;
			}
			goto IL_0013;
			IL_0052:
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteCustomController(int index)
		{
			if (customControllers != null)
			{
				int num2 = default(int);
				int id = default(int);
				while (true)
				{
					int num = -300791045;
					while (true)
					{
						switch (num ^ -300791047)
						{
						case 6:
							break;
						case 7:
							goto IL_0040;
						case 4:
							num2--;
							num = -300791042;
							continue;
						case 0:
							if (customControllerMaps[num2].customControllerUid == id)
							{
								customControllerMaps.RemoveAt(num2);
								num = -300791043;
								continue;
							}
							goto case 4;
						case 2:
							goto IL_0087;
						case 1:
							goto end_IL_000b;
						case 5:
							id = customControllers[index].id;
							if (customControllerMaps != null)
							{
								num2 = customControllerMaps.Count - 1;
								num = -300791042;
								continue;
							}
							goto default;
						default:
							customControllers.RemoveAt(index);
							return;
						}
						break;
						IL_0087:
						if (index < 0)
						{
							goto end_IL_000b;
						}
						int num3;
						if (index >= customControllers.Count)
						{
							num = -300791048;
							num3 = num;
						}
						else
						{
							num = -300791044;
							num3 = num;
						}
						continue;
						IL_0040:
						int num4;
						if (num2 >= 0)
						{
							num = -300791047;
							num4 = num;
						}
						else
						{
							num = -300791046;
							num4 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderCustomController(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllers, index, offsetDown, offsetNow);
		}

		public void DuplicateCustomController(int index, bool duplicateMaps)
		{
			if (customControllers == null || index < 0)
			{
				goto IL_017a;
			}
			if (index >= customControllers.Count)
			{
				goto IL_0023;
			}
			goto IL_01a5;
			IL_01a5:
			CustomController_Editor customController_Editor = customControllers[index].Clone();
			int num = -1944856815;
			goto IL_0028;
			IL_017a:
			throw new ArgumentOutOfRangeException("index");
			IL_0023:
			num = -1944856801;
			goto IL_0028;
			IL_0028:
			int id2 = default(int);
			int id = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1944856807)
				{
				case 3:
					break;
				default:
					return;
				case 8:
					customController_Editor.id = GetNewCustomControllerId();
					customController_Editor.typeGuid = Guid.NewGuid();
					num = -1944856816;
					continue;
				case 9:
					goto IL_0086;
				case 0:
					if (duplicateMaps)
					{
						id2 = customController_Editor.id;
						id = customControllers[index].id;
						if (customControllerMaps != null)
						{
							num2 = customControllerMaps.Count - 1;
							num = -1944856813;
							continue;
						}
					}
					return;
				case 4:
					if (customControllerMaps[num2].customControllerUid == id)
					{
						int num3 = DuplicateCustomControllerMap(num2);
						if (num3 >= 0)
						{
							customControllerMaps[num3].customControllerUid = id2;
							num = -1944856814;
							continue;
						}
					}
					goto case 11;
				case 10:
					goto IL_0149;
				case 1:
					customControllers.Insert(index + 1, customController_Editor);
					num = -1944856807;
					continue;
				case 6:
					goto IL_017a;
				case 7:
					customControllers.Add(customController_Editor);
					num = -1944856807;
					continue;
				case 2:
					goto IL_01a5;
				case 11:
					num2--;
					num = -1944856813;
					continue;
				case 5:
					return;
				}
				break;
				IL_0149:
				int num4;
				if (num2 >= 0)
				{
					num = -1944856803;
					num4 = num;
				}
				else
				{
					num = -1944856804;
					num4 = num;
				}
				continue;
				IL_0086:
				customController_Editor.name = StringTools.IterateName(customController_Editor.name, -1, GetCustomControllerNames());
				int num5;
				if (index == customControllers.Count - 1)
				{
					num = -1944856802;
					num5 = num;
				}
				else
				{
					num = -1944856808;
					num5 = num;
				}
			}
			goto IL_0023;
		}

		public int GetCustomControllerMapCount(int controllerUid)
		{
			if (customControllers == null)
			{
				return 0;
			}
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int num2 = -582454381;
				while (true)
				{
					switch (num2 ^ -582454382)
					{
					case 3:
						break;
					case 2:
					{
						int num4;
						if (num3 >= customControllerMaps.Count)
						{
							num2 = -582454378;
							num4 = num2;
						}
						else
						{
							num2 = -582454377;
							num4 = num2;
						}
						continue;
					}
					case 0:
						num3++;
						num2 = -582454384;
						continue;
					case 5:
						if (customControllerMaps[num3].customControllerUid == controllerUid)
						{
							num++;
							num2 = -582454382;
							continue;
						}
						goto case 0;
					case 1:
						if (customControllerMaps != null)
						{
							num3 = 0;
							num2 = -582454384;
							continue;
						}
						goto default;
					default:
						return num;
					}
					break;
				}
			}
		}

		public int GetCustomControllerIndex(int id)
		{
			if (customControllers == null)
			{
				return 0;
			}
			int num = 0;
			while (num < customControllers.Count)
			{
				while (true)
				{
					if (customControllers[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = -158967674;
					while (true)
					{
						switch (num2 ^ -158967674)
						{
						case 2:
							num2 = -158967673;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return -1;
		}

		public string[] GetCustomControllerNames()
		{
			if (customControllers == null)
			{
				goto IL_0008;
			}
			string[] array = new string[customControllers.Count];
			int num = 0;
			int num2 = 1262976755;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x4B477EF7)
				{
				case 0:
					break;
				case 3:
					return null;
				case 4:
					num2 = 1262976757;
					continue;
				case 1:
					array[num] = customControllers[num].name;
					num++;
					num2 = 1262976757;
					continue;
				default:
					if (num >= customControllers.Count)
					{
						return array;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1262976756;
			goto IL_000d;
		}

		public int[] GetCustomControllerIds()
		{
			if (customControllers == null)
			{
				goto IL_0008;
			}
			int[] array = new int[customControllers.Count];
			int num = 0;
			int num2 = -248350125;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -248350125)
				{
				case 2:
					break;
				case 1:
					return null;
				case 0:
					num2 = -248350121;
					continue;
				case 3:
					array[num] = customControllers[num].id;
					num++;
					num2 = -248350121;
					continue;
				default:
					if (num >= customControllers.Count)
					{
						return array;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -248350126;
			goto IL_000d;
		}

		public Guid[] GetCustomControllerGuids()
		{
			if (customControllers == null)
			{
				return null;
			}
			Guid[] array = new Guid[customControllers.Count];
			int num = 0;
			while (num < customControllers.Count)
			{
				while (true)
				{
					ref Guid reference = ref array[num];
					reference = customControllers[num].typeGuid;
					int num2 = 15432812;
					while (true)
					{
						switch (num2 ^ 0xEB7C6D)
						{
						case 0:
							num2 = 15432814;
							continue;
						case 3:
							break;
						case 1:
							num++;
							num2 = 15432815;
							continue;
						default:
							goto end_IL_0041;
						}
						break;
					}
					continue;
					end_IL_0041:
					break;
				}
			}
			return array;
		}

		public CustomController_Editor GetCustomController(int index)
		{
			if (customControllers != null && index >= 0)
			{
				while (true)
				{
					int num = -92041987;
					while (true)
					{
						switch (num ^ -92041988)
						{
						case 0:
							break;
						case 1:
							goto IL_002a;
						default:
							goto end_IL_000c;
						}
						break;
						IL_002a:
						if (index >= customControllers.Count)
						{
							num = -92041986;
							continue;
						}
						return customControllers[index];
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			return null;
		}

		public CustomController_Editor GetCustomController(string name)
		{
			if (customControllers == null)
			{
				return null;
			}
			int num = IndexOfCustomController(name);
			if (num < 0)
			{
				return null;
			}
			return customControllers[num];
		}

		public CustomController_Editor GetCustomControllerById(int id)
		{
			if (customControllers == null)
			{
				return null;
			}
			int num = IndexOfCustomController(id);
			if (num < 0)
			{
				return null;
			}
			return customControllers[num];
		}

		public CustomController_Editor GetCustomControllerByHardwareTypeGuid(Guid hardwareTypeGuid)
		{
			if (customControllers == null)
			{
				return null;
			}
			int num = IndexOfCustomController(hardwareTypeGuid);
			if (num < 0)
			{
				return null;
			}
			return customControllers[num];
		}

		public int GetCustomControllerId(string name)
		{
			if (customControllers == null)
			{
				return -1;
			}
			int num = IndexOfCustomController(name);
			if (num < 0)
			{
				return -1;
			}
			return customControllers[num].id;
		}

		public int IndexOfCustomController(int id)
		{
			if (customControllers == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -207431737;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -207431739)
				{
				case 0:
					break;
				case 1:
					if (customControllers[num].id == id)
					{
						return num;
					}
					num++;
					num2 = -207431743;
					continue;
				case 2:
					num2 = -207431743;
					continue;
				case 3:
					return -1;
				default:
					if (num >= customControllers.Count)
					{
						return -1;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -207431738;
			goto IL_000d;
		}

		public int IndexOfCustomController(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0013;
				}
				if (customControllers != null)
				{
					num = 0;
					num2 = 589632278;
				}
				else
				{
					num2 = 589632275;
				}
				goto IL_0018;
			}
			goto IL_008e;
			IL_0018:
			while (true)
			{
				switch (num2 ^ 0x23251316)
				{
				case 2:
					break;
				case 0:
					goto IL_003d;
				case 5:
					return -1;
				case 4:
					goto IL_0067;
				case 1:
					goto IL_008e;
				default:
					return -1;
				}
				break;
				IL_0067:
				if (customControllers[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = 589632278;
				continue;
				IL_003d:
				int num3;
				if (num >= customControllers.Count)
				{
					num2 = 589632277;
					num3 = num2;
				}
				else
				{
					num2 = 589632274;
					num3 = num2;
				}
			}
			goto IL_0013;
			IL_0013:
			num2 = 589632279;
			goto IL_0018;
			IL_008e:
			return -1;
		}

		public int IndexOfCustomController(Guid hardwareTypeGuid)
		{
			if (customControllers == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 2047742499;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x7A0E1222)
				{
				case 0:
					break;
				case 3:
					return -1;
				case 2:
					if (!(customControllers[num].typeGuid == hardwareTypeGuid))
					{
						goto IL_0050;
					}
					return num;
				default:
					if (num >= customControllers.Count)
					{
						return -1;
					}
					goto case 2;
				}
				break;
				IL_0050:
				num++;
				num2 = 2047742499;
			}
			goto IL_0008;
			IL_0008:
			num2 = 2047742497;
			goto IL_000d;
		}

		public string GetCustomControllerNameById(int id)
		{
			if (customControllers != null)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= customControllers.Count)
					{
						num2 = -231442518;
						num3 = num2;
					}
					else
					{
						num2 = -231442519;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -231442520)
						{
						case 4:
							num2 = -231442519;
							continue;
						case 1:
							break;
						case 0:
							return customControllers[num].name;
						case 3:
							goto end_IL_0014;
						default:
							goto end_IL_006d;
						}
						if (customControllers[num].id == id)
						{
							num2 = -231442520;
							continue;
						}
						num++;
						num2 = -231442517;
						continue;
						end_IL_0014:
						break;
					}
					continue;
					end_IL_006d:
					break;
				}
			}
			return "Unknown";
		}

		public void AddControllerMapLayoutManagerRuleSet()
		{
			controllerMapLayoutManagerRuleSets.Add(rIpuccQbhfzHqggDHCoPLVwjbjs());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -1193821648;
					while (true)
					{
						switch (num ^ -1193821646)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						case 1:
							goto end_IL_0004;
						default:
							controllerMapLayoutManagerRuleSets.Insert(index, rIpuccQbhfzHqggDHCoPLVwjbjs());
							return;
						}
						break;
						IL_0026:
						int num2;
						if (index >= controllerMapLayoutManagerRuleSets.Count)
						{
							num = -1193821645;
							num2 = num;
						}
						else
						{
							num = -1193821647;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets != null && index >= 0)
			{
				if (index >= controllerMapLayoutManagerRuleSets.Count)
				{
					goto IL_0023;
				}
				goto IL_00e0;
			}
			goto IL_0106;
			IL_016f:
			controllerMapLayoutManagerRuleSets.RemoveAt(index);
			int num = -955589821;
			goto IL_0028;
			IL_0106:
			throw new ArgumentOutOfRangeException("index");
			IL_0023:
			num = -955589820;
			goto IL_0028;
			IL_0028:
			Player_Editor player_Editor = default(Player_Editor);
			int num3 = default(int);
			int num2 = default(int);
			List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
			int id = default(int);
			while (true)
			{
				switch (num ^ -955589823)
				{
				case 9:
					break;
				default:
					return;
				case 13:
					goto IL_0070;
				case 4:
					player_Editor = players[num3];
					num = -955589822;
					continue;
				case 1:
					num2 = ruleSets.Count - 1;
					num = -955589811;
					continue;
				case 3:
					if (player_Editor != null)
					{
						goto IL_00bd;
					}
					goto case 7;
				case 8:
					goto IL_00e0;
				case 5:
					goto IL_0106;
				case 11:
					num2--;
					num = -955589811;
					continue;
				case 0:
					if (ruleSets[num2] != null && ruleSets[num2].id == id)
					{
						ruleSets.RemoveAt(num2);
						num = -955589814;
						continue;
					}
					goto case 11;
				case 6:
					num = -955589812;
					continue;
				case 7:
					num3++;
					num = -955589812;
					continue;
				case 10:
					goto IL_016f;
				case 12:
					goto IL_0185;
				case 2:
					return;
				}
				break;
				IL_0185:
				int num4;
				if (num2 < 0)
				{
					num = -955589818;
					num4 = num;
				}
				else
				{
					num = -955589823;
					num4 = num;
				}
				continue;
				IL_00bd:
				ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
				int num5;
				if (ruleSets == null)
				{
					num = -955589818;
					num5 = num;
				}
				else
				{
					num = -955589824;
					num5 = num;
				}
				continue;
				IL_0070:
				int num6;
				if (num3 >= players.Count)
				{
					num = -955589813;
					num6 = num;
				}
				else
				{
					num = -955589819;
					num6 = num;
				}
			}
			goto IL_0023;
			IL_00e0:
			id = controllerMapLayoutManagerRuleSets[index].id;
			if (players != null)
			{
				num3 = 0;
				num = -955589817;
				goto IL_0028;
			}
			goto IL_016f;
		}

		public bool ReorderControllerMapLayoutManagerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapLayoutManagerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets == null || index < 0)
			{
				goto IL_0043;
			}
			if (index >= controllerMapLayoutManagerRuleSets.Count)
			{
				goto IL_001a;
			}
			goto IL_006b;
			IL_0043:
			throw new ArgumentOutOfRangeException("index");
			IL_0055:
			ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = default(ControllerMapLayoutManager_RuleSet_Editor);
			controllerMapLayoutManagerRuleSets.Insert(index + 1, controllerMapLayoutManager_RuleSet_Editor);
			int num = 1409712872;
			goto IL_001f;
			IL_001a:
			num = 1409712877;
			goto IL_001f;
			IL_001f:
			switch (num ^ 0x540682E9)
			{
			case 0:
				break;
			default:
				return;
			case 4:
				goto IL_0043;
			case 3:
				goto IL_0055;
			case 2:
				goto IL_006b;
			case 1:
				return;
			}
			goto IL_001a;
			IL_006b:
			controllerMapLayoutManager_RuleSet_Editor = controllerMapLayoutManagerRuleSets[index].Clone();
			controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
			controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName(controllerMapLayoutManager_RuleSet_Editor.name, -1, GetControllerMapLayoutManagerRuleSetNames());
			if (index == controllerMapLayoutManagerRuleSets.Count - 1)
			{
				controllerMapLayoutManagerRuleSets.Add(controllerMapLayoutManager_RuleSet_Editor);
				return;
			}
			goto IL_0055;
		}

		public int GetControllerMapLayoutManagerRuleSetUsedCount(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			int num6 = default(int);
			int num3 = default(int);
			List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
			Player_Editor player_Editor = default(Player_Editor);
			while (true)
			{
				int num2 = -2022425016;
				while (true)
				{
					switch (num2 ^ -2022425022)
					{
					case 0:
						break;
					case 1:
					{
						int num7;
						if (num6 < players.Count)
						{
							num2 = -2022425014;
							num7 = num2;
						}
						else
						{
							num2 = -2022425015;
							num7 = num2;
						}
						continue;
					}
					case 2:
						num++;
						num2 = -2022425013;
						continue;
					case 4:
						num6++;
						num2 = -2022425021;
						continue;
					case 3:
						num2 = -2022425021;
						continue;
					case 9:
						num3--;
						num2 = -2022425020;
						continue;
					case 5:
						ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
						if (ruleSets != null)
						{
							num3 = ruleSets.Count - 1;
							num2 = -2022425020;
							continue;
						}
						goto case 4;
					case 10:
						if (players != null)
						{
							num6 = 0;
							num2 = -2022425023;
							continue;
						}
						goto default;
					case 8:
					{
						player_Editor = players[num6];
						int num8;
						if (player_Editor == null)
						{
							num2 = -2022425018;
							num8 = num2;
						}
						else
						{
							num2 = -2022425017;
							num8 = num2;
						}
						continue;
					}
					case 7:
						if (ruleSets[num3] != null)
						{
							int num5;
							if (ruleSets[num3].id != id)
							{
								num2 = -2022425013;
								num5 = num2;
							}
							else
							{
								num2 = -2022425024;
								num5 = num2;
							}
							continue;
						}
						goto case 9;
					case 6:
					{
						int num4;
						if (num3 < 0)
						{
							num2 = -2022425018;
							num4 = num2;
						}
						else
						{
							num2 = -2022425019;
							num4 = num2;
						}
						continue;
					}
					default:
						return num;
					}
					break;
				}
			}
		}

		public int GetControllerMapLayoutManagerRuleSetIndex(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				int num2 = -806056337;
				while (true)
				{
					switch (num2 ^ -806056340)
					{
					case 2:
						break;
					case 3:
						num2 = -806056339;
						continue;
					case 0:
						if (controllerMapLayoutManagerRuleSets[num].id == id)
						{
							return num;
						}
						num++;
						num2 = -806056339;
						continue;
					case 1:
					{
						int num3;
						if (num < controllerMapLayoutManagerRuleSets.Count)
						{
							num2 = -806056340;
							num3 = num2;
						}
						else
						{
							num2 = -806056344;
							num3 = num2;
						}
						continue;
					}
					default:
						return -1;
					}
					break;
				}
			}
		}

		public string[] GetControllerMapLayoutManagerRuleSetNames()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				goto IL_0008;
			}
			string[] array = new string[controllerMapLayoutManagerRuleSets.Count];
			int num = 0;
			int num2 = -510071783;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -510071779)
				{
				case 2:
					break;
				case 1:
					return null;
				case 3:
					array[num] = controllerMapLayoutManagerRuleSets[num].name;
					num++;
					num2 = -510071779;
					continue;
				case 4:
					num2 = -510071779;
					continue;
				default:
					if (num >= controllerMapLayoutManagerRuleSets.Count)
					{
						return array;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -510071780;
			goto IL_000d;
		}

		public int[] GetControllerMapLayoutManagerRuleSetIds()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int[] array = new int[controllerMapLayoutManagerRuleSets.Count];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < controllerMapLayoutManagerRuleSets.Count)
				{
					num2 = 472989782;
					num3 = num2;
				}
				else
				{
					num2 = 472989781;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x1C314057)
					{
					case 0:
						num2 = 472989782;
						continue;
					case 1:
						array[num] = controllerMapLayoutManagerRuleSets[num].id;
						num++;
						num2 = 472989780;
						continue;
					case 3:
						break;
					default:
						return array;
					}
					break;
				}
			}
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets != null)
			{
				while (true)
				{
					int num = 1950412729;
					while (true)
					{
						switch (num ^ 0x7440EFB8)
						{
						case 2:
							break;
						case 1:
							goto IL_002a;
						case 3:
							goto IL_003f;
						default:
							goto end_IL_0008;
						}
						break;
						IL_003f:
						if (index >= controllerMapLayoutManagerRuleSets.Count)
						{
							num = 1950412728;
							continue;
						}
						return controllerMapLayoutManagerRuleSets[index];
						IL_002a:
						int num2;
						if (index >= 0)
						{
							num = 1950412731;
							num2 = num;
						}
						else
						{
							num = 1950412728;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(string name)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(name);
			if (num < 0)
			{
				return null;
			}
			return controllerMapLayoutManagerRuleSets[num];
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSetById(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(id);
			if (num < 0)
			{
				return null;
			}
			return controllerMapLayoutManagerRuleSets[num];
		}

		public int GetControllerMapLayoutManagerRuleSetId(string name)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				goto IL_0008;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(name);
			int num2;
			if (num < 0)
			{
				num2 = -587498154;
				goto IL_000d;
			}
			return controllerMapLayoutManagerRuleSets[num].id;
			IL_0008:
			num2 = -587498155;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ -587498156)
			{
			case 0:
				break;
			case 1:
				return -1;
			default:
				return -1;
			}
			goto IL_0008;
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= controllerMapLayoutManagerRuleSets.Count)
				{
					num2 = -950714957;
					num3 = num2;
				}
				else
				{
					num2 = -950714954;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -950714958)
					{
					case 2:
						num2 = -950714954;
						continue;
					case 3:
						break;
					case 0:
						return num;
					case 4:
						if (controllerMapLayoutManagerRuleSets[num].id != id)
						{
							num++;
							num2 = -950714959;
						}
						else
						{
							num2 = -950714958;
						}
						continue;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (controllerMapLayoutManagerRuleSets != null)
				{
					num = 0;
					num2 = -1566911491;
				}
				else
				{
					num2 = -1566911495;
				}
				goto IL_0015;
			}
			goto IL_0073;
			IL_0015:
			while (true)
			{
				switch (num2 ^ -1566911491)
				{
				case 5:
					break;
				case 2:
					goto IL_003a;
				case 4:
					return -1;
				case 0:
					num2 = -1566911490;
					continue;
				case 1:
					goto IL_0073;
				default:
					if (num >= controllerMapLayoutManagerRuleSets.Count)
					{
						return -1;
					}
					goto IL_003a;
				}
				break;
				IL_003a:
				if (controllerMapLayoutManagerRuleSets[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = -1566911490;
			}
			goto IL_0010;
			IL_0010:
			num2 = -1566911492;
			goto IL_0015;
			IL_0073:
			return -1;
		}

		public string GetControllerMapLayoutManagerRuleSetNameById(int id)
		{
			if (controllerMapLayoutManagerRuleSets != null)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < controllerMapLayoutManagerRuleSets.Count)
					{
						num2 = -1722031551;
						num3 = num2;
					}
					else
					{
						num2 = -1722031549;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1722031552)
						{
						case 2:
							num2 = -1722031551;
							continue;
						case 1:
							break;
						case 0:
							goto end_IL_0011;
						default:
							goto end_IL_005f;
						}
						if (controllerMapLayoutManagerRuleSets[num].id == id)
						{
							return controllerMapLayoutManagerRuleSets[num].name;
						}
						num++;
						num2 = -1722031552;
						continue;
						end_IL_0011:
						break;
					}
					continue;
					end_IL_005f:
					break;
				}
			}
			return "Unknown";
		}

		public int GetControllerMapLayoutManagerRuleSetCount()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			return controllerMapLayoutManagerRuleSets.Count;
		}

		public void AddControllerMapEnablerRuleSet()
		{
			controllerMapEnablerRuleSets.Add(erzNehXfcIzKRVbTcqnrkFePIgqh());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0)
			{
				goto IL_0034;
			}
			if (index >= controllerMapEnablerRuleSets.Count)
			{
				goto IL_0012;
			}
			goto IL_0046;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
			IL_0012:
			int num = -1377660342;
			goto IL_0017;
			IL_0017:
			switch (num ^ -1377660343)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				goto IL_0034;
			case 2:
				goto IL_0046;
			case 1:
				return;
			}
			goto IL_0012;
			IL_0046:
			controllerMapEnablerRuleSets.Insert(index, erzNehXfcIzKRVbTcqnrkFePIgqh());
			num = -1377660344;
			goto IL_0017;
		}

		public void DeleteControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0)
			{
				goto IL_0062;
			}
			if (index >= controllerMapEnablerRuleSets.Count)
			{
				goto IL_001d;
			}
			goto IL_00ed;
			IL_00ed:
			int id = controllerMapEnablerRuleSets[index].id;
			int num;
			int num2;
			if (players != null)
			{
				num = -930846868;
				num2 = num;
			}
			else
			{
				num = -930846870;
				num2 = num;
			}
			goto IL_0022;
			IL_0062:
			throw new ArgumentOutOfRangeException("index");
			IL_001d:
			num = -930846867;
			goto IL_0022;
			IL_0022:
			int num3 = default(int);
			List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ -930846868)
				{
				case 8:
					break;
				case 1:
					goto IL_0062;
				case 5:
					goto IL_0074;
				case 7:
					goto IL_008f;
				case 0:
					num3 = 0;
					num = -930846869;
					continue;
				case 2:
					if (ruleSets[num4].id == id)
					{
						ruleSets.RemoveAt(num4);
						num = -930846873;
						continue;
					}
					goto case 11;
				case 3:
					num3++;
					num = -930846869;
					continue;
				case 10:
					goto IL_00ed;
				case 11:
					num4--;
					num = -930846875;
					continue;
				case 4:
				{
					Player_Editor player_Editor = players[num3];
					if (player_Editor != null)
					{
						ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
						if (ruleSets != null)
						{
							num4 = ruleSets.Count - 1;
							num = -930846875;
							continue;
						}
					}
					goto case 3;
				}
				case 9:
					goto IL_015e;
				default:
					controllerMapEnablerRuleSets.RemoveAt(index);
					return;
				}
				break;
				IL_015e:
				int num5;
				if (num4 >= 0)
				{
					num = -930846871;
					num5 = num;
				}
				else
				{
					num = -930846865;
					num5 = num;
				}
				continue;
				IL_008f:
				int num6;
				if (num3 < players.Count)
				{
					num = -930846872;
					num6 = num;
				}
				else
				{
					num = -930846870;
					num6 = num;
				}
				continue;
				IL_0074:
				int num7;
				if (ruleSets[num4] == null)
				{
					num = -930846873;
					num7 = num;
				}
				else
				{
					num = -930846866;
					num7 = num;
				}
			}
			goto IL_001d;
		}

		public bool ReorderControllerMapEnablerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapEnablerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets != null && index >= 0)
			{
				ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = default(ControllerMapEnabler_RuleSet_Editor);
				while (true)
				{
					int num = 1211851409;
					while (true)
					{
						switch (num ^ 0x483B6290)
						{
						case 4:
							break;
						case 3:
							controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
							num = 1211851408;
							continue;
						case 7:
							goto end_IL_000c;
						case 1:
							goto IL_0066;
						case 2:
							return;
						case 0:
							controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName(controllerMapEnabler_RuleSet_Editor.name, -1, GetControllerMapEnablerRuleSetNames());
							if (index == controllerMapEnablerRuleSets.Count - 1)
							{
								controllerMapEnablerRuleSets.Add(controllerMapEnabler_RuleSet_Editor);
								num = 1211851410;
								continue;
							}
							goto default;
						case 6:
							controllerMapEnabler_RuleSet_Editor = controllerMapEnablerRuleSets[index].Clone();
							num = 1211851411;
							continue;
						default:
							controllerMapEnablerRuleSets.Insert(index + 1, controllerMapEnabler_RuleSet_Editor);
							return;
						}
						break;
						IL_0066:
						int num2;
						if (index < controllerMapEnablerRuleSets.Count)
						{
							num = 1211851414;
							num2 = num;
						}
						else
						{
							num = 1211851415;
							num2 = num;
						}
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetControllerMapEnablerRuleSetUsedCount(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			if (players != null)
			{
				int num2 = 0;
				Player_Editor player_Editor = default(Player_Editor);
				List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
				int num5 = default(int);
				while (true)
				{
					int num3;
					int num4;
					if (num2 >= players.Count)
					{
						num3 = -1733992300;
						num4 = num3;
					}
					else
					{
						num3 = -1733992297;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ -1733992299)
						{
						case 8:
							num3 = -1733992297;
							continue;
						case 2:
							player_Editor = players[num2];
							num3 = -1733992303;
							continue;
						case 0:
							break;
						case 3:
							num2++;
							num3 = -1733992299;
							continue;
						case 9:
							if (ruleSets[num5] != null && ruleSets[num5].id == id)
							{
								num++;
								num3 = -1733992304;
								continue;
							}
							goto case 5;
						case 7:
							if (ruleSets != null)
							{
								num5 = ruleSets.Count - 1;
								num3 = -1733992301;
								continue;
							}
							goto case 3;
						case 6:
							goto IL_00d5;
						case 5:
							num5--;
							num3 = -1733992301;
							continue;
						case 4:
							if (player_Editor != null)
							{
								ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
								num3 = -1733992302;
								continue;
							}
							goto case 3;
						default:
							goto end_IL_006c;
						}
						break;
						IL_00d5:
						int num6;
						if (num5 < 0)
						{
							num3 = -1733992298;
							num6 = num3;
						}
						else
						{
							num3 = -1733992292;
							num6 = num3;
						}
					}
					continue;
					end_IL_006c:
					break;
				}
			}
			return num;
		}

		public int GetControllerMapEnablerRuleSetIndex(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			while (num < controllerMapEnablerRuleSets.Count)
			{
				while (true)
				{
					if (controllerMapEnablerRuleSets[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = 893451115;
					while (true)
					{
						switch (num2 ^ 0x3540FB69)
						{
						case 0:
							num2 = 893451112;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return -1;
		}

		public string[] GetControllerMapEnablerRuleSetNames()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			string[] array = new string[controllerMapEnablerRuleSets.Count];
			int num2 = default(int);
			while (true)
			{
				int num = -1280913462;
				while (true)
				{
					switch (num ^ -1280913461)
					{
					case 3:
						break;
					case 1:
						num2 = 0;
						num = -1280913463;
						continue;
					case 0:
						array[num2] = controllerMapEnablerRuleSets[num2].name;
						num2++;
						num = -1280913463;
						continue;
					default:
						if (num2 >= controllerMapEnablerRuleSets.Count)
						{
							return array;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public int[] GetControllerMapEnablerRuleSetIds()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				goto IL_0008;
			}
			int[] array = new int[controllerMapEnablerRuleSets.Count];
			int num = 721462326;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x2B00A434)
				{
				case 5:
					break;
				case 3:
					num2++;
					num = 721462324;
					continue;
				case 2:
					num2 = 0;
					num = 721462324;
					continue;
				case 4:
					array[num2] = controllerMapEnablerRuleSets[num2].id;
					num = 721462327;
					continue;
				case 1:
					return null;
				default:
					if (num2 >= controllerMapEnablerRuleSets.Count)
					{
						return array;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num = 721462325;
			goto IL_000d;
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets != null)
			{
				while (true)
				{
					int num = -823475784;
					while (true)
					{
						switch (num ^ -823475783)
						{
						case 0:
							break;
						case 1:
							goto IL_0026;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0026:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						if (index >= controllerMapEnablerRuleSets.Count)
						{
							num = -823475781;
							continue;
						}
						return controllerMapEnablerRuleSets[index];
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return null;
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(string name)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapEnablerRuleSet(name);
			if (num < 0)
			{
				return null;
			}
			return controllerMapEnablerRuleSets[num];
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSetById(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int num = IndexOfControllerMapEnablerRuleSet(id);
			if (num < 0)
			{
				return null;
			}
			return controllerMapEnablerRuleSets[num];
		}

		public int GetControllerMapEnablerRuleSetId(string name)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				goto IL_0008;
			}
			int num = IndexOfControllerMapEnablerRuleSet(name);
			int num2 = -692055182;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -692055181)
				{
				case 3:
					break;
				case 2:
					return -1;
				case 1:
					if (num < 0)
					{
						goto IL_003f;
					}
					return controllerMapEnablerRuleSets[num].id;
				default:
					return -1;
				}
				break;
				IL_003f:
				num2 = -692055181;
			}
			goto IL_0008;
			IL_0008:
			num2 = -692055183;
			goto IL_000d;
		}

		public int IndexOfControllerMapEnablerRuleSet(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 755560981;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x2D08F216)
				{
				case 0:
					break;
				case 1:
					return -1;
				case 2:
					if (controllerMapEnablerRuleSets[num].id != id)
					{
						goto IL_004b;
					}
					return num;
				default:
					if (num >= controllerMapEnablerRuleSets.Count)
					{
						return -1;
					}
					goto case 2;
				}
				break;
				IL_004b:
				num++;
				num2 = 755560981;
			}
			goto IL_0008;
			IL_0008:
			num2 = 755560983;
			goto IL_000d;
		}

		public int IndexOfControllerMapEnablerRuleSet(string name)
		{
			if (name != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = 1302339864;
					while (true)
					{
						switch (num ^ 0x4DA0211C)
						{
						case 0:
							break;
						case 4:
							goto IL_0029;
						case 3:
							goto IL_003d;
						case 1:
							goto end_IL_0003;
						default:
							if (num2 >= controllerMapEnablerRuleSets.Count)
							{
								return -1;
							}
							goto IL_003d;
						}
						break;
						IL_003d:
						if (controllerMapEnablerRuleSets[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
						{
							return num2;
						}
						num2++;
						num = 1302339870;
						continue;
						IL_0029:
						if (name == string.Empty)
						{
							num = 1302339869;
							continue;
						}
						if (controllerMapEnablerRuleSets == null)
						{
							return -1;
						}
						num2 = 0;
						num = 1302339870;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return -1;
		}

		public string GetControllerMapEnablerRuleSetNameById(int id)
		{
			if (controllerMapEnablerRuleSets != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -28326216;
					while (true)
					{
						switch (num ^ -28326211)
						{
						case 0:
							break;
						case 5:
							num2 = 0;
							num = -28326213;
							continue;
						case 6:
							num = -28326215;
							continue;
						case 3:
							goto IL_0049;
						case 4:
							goto IL_0064;
						case 2:
							return controllerMapEnablerRuleSets[num2].name;
						default:
							goto end_IL_000b;
						}
						break;
						IL_0064:
						int num3;
						if (num2 >= controllerMapEnablerRuleSets.Count)
						{
							num = -28326212;
							num3 = num;
						}
						else
						{
							num = -28326210;
							num3 = num;
						}
						continue;
						IL_0049:
						if (controllerMapEnablerRuleSets[num2].id == id)
						{
							num = -28326209;
							continue;
						}
						num2++;
						num = -28326215;
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			return "Unknown";
		}

		public int GetControllerMapEnablerRuleSetCount()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return 0;
			}
			return controllerMapEnablerRuleSets.Count;
		}

		public int GetNewPlayerId()
		{
			int result = playerIdCounter;
			playerIdCounter++;
			return result;
		}

		public int GetNewActionId()
		{
			int result = actionIdCounter;
			actionIdCounter++;
			return result;
		}

		public int GetNewActionCategoryId()
		{
			int result = actionCategoryIdCounter;
			actionCategoryIdCounter++;
			return result;
		}

		public int GetNewInputBehaviorId()
		{
			int result = inputBehaviorIdCounter;
			inputBehaviorIdCounter++;
			return result;
		}

		public int GetNewMapCategoryId()
		{
			int result = mapCategoryIdCounter;
			mapCategoryIdCounter++;
			return result;
		}

		public int GetNewJoystickLayoutId()
		{
			int result = joystickLayoutIdCounter;
			joystickLayoutIdCounter++;
			return result;
		}

		public int GetNewKeyboardLayoutId()
		{
			int result = keyboardLayoutIdCounter;
			keyboardLayoutIdCounter++;
			return result;
		}

		public int GetNewMouseLayoutId()
		{
			int result = mouseLayoutIdCounter;
			mouseLayoutIdCounter++;
			return result;
		}

		public int GetNewCustomControllerLayoutId()
		{
			int result = customControllerLayoutIdCounter;
			while (true)
			{
				int num = 1972355953;
				while (true)
				{
					switch (num ^ 0x758FC370)
					{
					case 0:
						break;
					case 1:
						goto IL_0025;
					default:
						return result;
					}
					break;
					IL_0025:
					customControllerLayoutIdCounter++;
					num = 1972355954;
				}
			}
		}

		public int GetNewJoystickMapId()
		{
			int result = joystickMapIdCounter;
			joystickMapIdCounter++;
			return result;
		}

		public int GetNewKeyboardMapId()
		{
			int result = keyboardMapIdCounter;
			keyboardMapIdCounter++;
			return result;
		}

		public int GetNewMouseMapId()
		{
			int result = mouseMapIdCounter;
			mouseMapIdCounter++;
			return result;
		}

		public int GetNewCustomControllerMapId()
		{
			int result = customControllerMapIdCounter;
			customControllerMapIdCounter++;
			return result;
		}

		public int GetNewCustomControllerId()
		{
			int result = customControllerIdCounter;
			customControllerIdCounter++;
			return result;
		}

		public int GetNewControllerMapLayoutManagerRuleSetId()
		{
			int result = controllerMapLayoutManagerSetIdCounter;
			controllerMapLayoutManagerSetIdCounter++;
			return result;
		}

		public int GetNewControllerMapEnablerRuleSetId()
		{
			int result = controllerMapEnablerSetIdCounter;
			controllerMapEnablerSetIdCounter++;
			return result;
		}

		private Player_Editor GMFgMaBPCvuifRlcLbgjOQcrNXBY()
		{
			Player_Editor player_Editor = new Player_Editor();
			player_Editor.id = GetNewPlayerId();
			player_Editor.name = StringTools.IterateName("Player", -1, GetPlayerNames());
			player_Editor.descriptiveName = player_Editor.name;
			while (true)
			{
				int num = -149139785;
				while (true)
				{
					switch (num ^ -149139787)
					{
					case 0:
						break;
					case 1:
						player_Editor.assignKeyboardOnStart = true;
						num = -149139791;
						continue;
					case 3:
						player_Editor.assignMouseOnStart = true;
						num = -149139788;
						continue;
					case 2:
					{
						player_Editor.startPlaying = true;
						int num2;
						if (players.Count != 1)
						{
							num = -149139788;
							num2 = num;
						}
						else
						{
							num = -149139786;
							num2 = num;
						}
						continue;
					}
					default:
						player_Editor.controllerMapEnablerSettings = new Player_Editor.ControllerMapEnablerSettings();
						player_Editor.controllerMapLayoutManagerSettings = new Player_Editor.ControllerMapLayoutManagerSettings();
						return player_Editor;
					}
					break;
				}
			}
		}

		private InputAction cPgmfrekjKGfnBEDAFmVdUFItHSe()
		{
			InputAction inputAction = new InputAction();
			inputAction.id = GetNewActionId();
			while (true)
			{
				int num = 1033916242;
				while (true)
				{
					switch (num ^ 0x3DA04F53)
					{
					case 0:
						break;
					case 1:
						inputAction.name = StringTools.IterateName("Action", -1, GetActionNames());
						inputAction.descriptiveName = inputAction.name;
						num = 1033916241;
						continue;
					case 2:
						inputAction.type = InputActionType.Button;
						num = 1033916240;
						continue;
					default:
						inputAction.userAssignable = true;
						inputAction.behaviorId = 0;
						return inputAction;
					}
					break;
				}
			}
		}

		private InputCategory DbDeQrHYlCiwsfJAzFhltqwKFGMu()
		{
			InputCategory inputCategory = new InputCategory();
			inputCategory.id = GetNewActionCategoryId();
			inputCategory.name = StringTools.IterateName("Category", -1, GetActionCategoryNames());
			inputCategory.descriptiveName = inputCategory.name;
			inputCategory.userAssignable = true;
			return inputCategory;
		}

		private InputBehavior kUbhbGbdwKrODdTxKxOACHtcfLEI()
		{
			InputBehavior inputBehavior = new InputBehavior();
			inputBehavior.id = GetNewInputBehaviorId();
			inputBehavior.name = StringTools.IterateName("Behavior", -1, GetInputBehaviorNames());
			inputBehavior.digitalAxisSimulation = true;
			inputBehavior.digitalAxisSnap = true;
			while (true)
			{
				int num = 966575236;
				while (true)
				{
					switch (num ^ 0x399CC481)
					{
					case 0:
						break;
					case 2:
						inputBehavior.buttonDeadZone = 0.5f;
						inputBehavior.buttonDownBuffer = 0f;
						num = 966575232;
						continue;
					case 3:
						inputBehavior.buttonShortPressExpiresIn = 0f;
						inputBehavior.buttonLongPressTime = 1f;
						num = 966575237;
						continue;
					case 5:
						inputBehavior.digitalAxisInstantReverse = false;
						inputBehavior.digitalAxisGravity = 3f;
						inputBehavior.digitalAxisSensitivity = 3f;
						inputBehavior.mouseXYAxisMode = MouseXYAxisMode.MouseAxis;
						inputBehavior.mouseXYAxisSensitivity = 1f;
						inputBehavior.mouseOtherAxisMode = MouseOtherAxisMode.MouseAxis;
						inputBehavior.mouseOtherAxisSensitivity = 1f;
						inputBehavior.buttonDoublePressSpeed = 0.3f;
						inputBehavior.buttonShortPressTime = 0.25f;
						num = 966575234;
						continue;
					case 4:
						inputBehavior.buttonLongPressExpiresIn = 0f;
						num = 966575235;
						continue;
					default:
						return inputBehavior;
					}
					break;
				}
			}
		}

		private InputMapCategory afQWIFPueftpztHVacesdOnQNEsb()
		{
			InputMapCategory inputMapCategory = new InputMapCategory();
			while (true)
			{
				int num = 26721536;
				while (true)
				{
					switch (num ^ 0x197BD02)
					{
					case 0:
						break;
					case 2:
						inputMapCategory.id = GetNewMapCategoryId();
						num = 26721537;
						continue;
					case 3:
						inputMapCategory.name = StringTools.IterateName("Category", -1, GetMapCategoryNames());
						inputMapCategory.descriptiveName = inputMapCategory.name;
						inputMapCategory.userAssignable = true;
						inputMapCategory.checkConflictsWithAllCategories = true;
						num = 26721539;
						continue;
					default:
						return inputMapCategory;
					}
					break;
				}
			}
		}

		private InputLayout tKoSqohFtTtmilugrShVUkmbvqi()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewJoystickLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private InputLayout QLRyeYPFXCVPOfCCmiNpChRiwNOa()
		{
			InputLayout inputLayout = new InputLayout();
			while (true)
			{
				int num = 1546485696;
				while (true)
				{
					switch (num ^ 0x5C2D7FC1)
					{
					case 0:
						break;
					case 1:
						goto IL_0024;
					default:
						inputLayout.descriptiveName = inputLayout.name;
						return inputLayout;
					}
					break;
					IL_0024:
					inputLayout.id = GetNewKeyboardLayoutId();
					inputLayout.name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames());
					num = 1546485699;
				}
			}
		}

		private InputLayout sVWOdrUnBQIviCODztlqJGKNDrck()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewMouseLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private InputLayout hLYVpAShAueSrhirvyEpLlBiSSra()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private CustomController_Editor hTZbrXAKQEEqchpGqlSDiaSamEwc()
		{
			CustomController_Editor customController_Editor = new CustomController_Editor();
			customController_Editor.id = GetNewCustomControllerId();
			customController_Editor.typeGuid = Guid.NewGuid();
			while (true)
			{
				int num = 240073069;
				while (true)
				{
					switch (num ^ 0xE4F396F)
					{
					case 0:
						break;
					case 2:
						goto IL_003b;
					default:
						return customController_Editor;
					}
					break;
					IL_003b:
					customController_Editor.name = StringTools.IterateName("CustomController", -1, GetCustomControllerNames());
					customController_Editor.descriptiveName = customController_Editor.name;
					num = 240073070;
				}
			}
		}

		private ControllerMapLayoutManager_RuleSet_Editor rIpuccQbhfzHqggDHCoPLVwjbjs()
		{
			ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = new ControllerMapLayoutManager_RuleSet_Editor();
			controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
			controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames());
			return controllerMapLayoutManager_RuleSet_Editor;
		}

		private ControllerMapEnabler_RuleSet_Editor erzNehXfcIzKRVbTcqnrkFePIgqh()
		{
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = new ControllerMapEnabler_RuleSet_Editor();
			controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
			controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames());
			return controllerMapEnabler_RuleSet_Editor;
		}

		private ControllerMap_Editor kfrBCLyPnzdXIZqqMelkHcnGyMwR(List<ControllerMap_Editor> P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int num = 0;
			while (num < P_0.Count)
			{
				while (true)
				{
					int num2;
					if (P_0[num].categoryId == P_1 && P_0[num].layoutId == P_2)
					{
						num2 = -89869145;
					}
					else
					{
						num++;
						num2 = -89869147;
					}
					while (true)
					{
						switch (num2 ^ -89869147)
						{
						case 3:
							num2 = -89869148;
							continue;
						case 1:
							break;
						case 2:
							return P_0[num];
						default:
							goto end_IL_002b;
						}
						break;
					}
					continue;
					end_IL_002b:
					break;
				}
			}
			return null;
		}

		private ControllerMap_Editor UnngcCeOUSsvrJntNXiDmDYxLqpu(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = kfrBCLyPnzdXIZqqMelkHcnGyMwR(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = pXMmLaFqykVPYGfInarbfcJrDrlE(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor pXMmLaFqykVPYGfInarbfcJrDrlE(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null)
			{
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = 433384982;
					while (true)
					{
						switch (num ^ 0x19D4EE15)
						{
						case 0:
							break;
						case 3:
							if (list.Count > 0)
							{
								cRKpQqSuAucyDExrbcSzTLhYBwq(list, P_1);
								num = 433384979;
								continue;
							}
							goto end_IL_000d;
						case 4:
							goto IL_0061;
						case 7:
							return list[num2];
						case 6:
							num2 = 0;
							num = 433384980;
							continue;
						case 8:
							goto IL_00a4;
						case 5:
							goto IL_00bd;
						case 1:
							if (num2 >= list.Count)
							{
								num3 = 0;
								num = 433384976;
								continue;
							}
							goto IL_00a4;
						default:
							goto end_IL_000d;
						}
						break;
						IL_00bd:
						int num4;
						if (num3 >= list.Count)
						{
							num = 433384983;
							num4 = num;
						}
						else
						{
							num = 433384977;
							num4 = num;
						}
						continue;
						IL_00a4:
						if (list[num2].categoryId != P_2)
						{
							num2++;
							num = 433384980;
						}
						else
						{
							num = 433384978;
						}
						continue;
						IL_0061:
						if (list[num3].categoryId == 0)
						{
							return list[num3];
						}
						num3++;
						num = 433384976;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			return null;
		}

		private void cRKpQqSuAucyDExrbcSzTLhYBwq(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			JhDtNuqqZxQcYeCGrCfyzLgsFUA jhDtNuqqZxQcYeCGrCfyzLgsFUA = new JhDtNuqqZxQcYeCGrCfyzLgsFUA();
			while (true)
			{
				int num = -1573319113;
				while (true)
				{
					switch (num ^ -1573319116)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						jhDtNuqqZxQcYeCGrCfyzLgsFUA.dyyTLtsXFbRnqBwdyGfQnnsGeYxi = P_1;
						if (P_0 != null)
						{
							int num2;
							if (jhDtNuqqZxQcYeCGrCfyzLgsFUA.dyyTLtsXFbRnqBwdyGfQnnsGeYxi != null)
							{
								num = -1573319115;
								num2 = num;
							}
							else
							{
								num = -1573319120;
								num2 = num;
							}
							continue;
						}
						return;
					case 1:
						P_0.Sort(jhDtNuqqZxQcYeCGrCfyzLgsFUA.ptmzQtpxNPKSKRBYzCvQlqCJHaQ);
						num = -1573319116;
						continue;
					case 4:
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal void SdmfoteCDVoXNaSlWEvRMBbwmDy()
		{
			Players_readOnly = new ReadOnlyCollection<Player_Editor>(players);
			Actions_readOnly = new ReadOnlyCollection<InputAction>(actions);
			int num2 = default(int);
			while (true)
			{
				int num = 249075419;
				while (true)
				{
					switch (num ^ 0xED896DF)
					{
					case 6:
						break;
					default:
						return;
					case 1:
						num = 249075416;
						continue;
					case 8:
						KeyboardMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
						num = 249075414;
						continue;
					case 7:
					{
						int num3;
						if (num2 < mapCategories.Count)
						{
							num = 249075423;
							num3 = num;
						}
						else
						{
							num = 249075418;
							num3 = num;
						}
						continue;
					}
					case 5:
						containsActionDelegate = ContainsAction;
						num = 249075420;
						continue;
					case 9:
						MouseMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
						CustomControllerMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
						ControllerMapLayoutManagerRuleSets_readOnly = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
						ControllerMapEnablerRuleSets_readOnly = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
						if (mapCategories != null)
						{
							num2 = 0;
							num = 249075422;
							continue;
						}
						goto case 5;
					case 0:
						mapCategories[num2].SdmfoteCDVoXNaSlWEvRMBbwmDy();
						num2++;
						num = 249075416;
						continue;
					case 2:
						MapCategories_readOnly = new ReadOnlyCollection<InputMapCategory>(mapCategories);
						JoystickLayouts_readOnly = new ReadOnlyCollection<InputLayout>(joystickLayouts);
						KeyboardLayouts_readOnly = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
						MouseLayouts_readOnly = new ReadOnlyCollection<InputLayout>(mouseLayouts);
						CustomControllerLayouts_readOnly = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
						JoystickMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
						num = 249075415;
						continue;
					case 4:
						ActionCategories_readOnly = new ReadOnlyCollection<InputCategory>(actionCategories);
						InputBehaviors_readOnly = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
						num = 249075421;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return EMRkhjTgXoZTiafHYaTvUkzwjfk.VonXDnBtvIWleeWHoCosEZsMrsK(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return EMRkhjTgXoZTiafHYaTvUkzwjfk.VonXDnBtvIWleeWHoCosEZsMrsK(orig, null, false);
		}

		[CompilerGenerated]
		private static void WxznFWFhKLSWRqTRYDkHAUSyOHI(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = 1151412417;
				while (true)
				{
					switch (num2 ^ 0x44A128C2)
					{
					case 5:
						num2 = 1151412422;
						continue;
					case 7:
					{
						int num4;
						if (P_0[num].categoryId == P_1)
						{
							num2 = 1151412418;
							num4 = num2;
						}
						else
						{
							num2 = 1151412419;
							num4 = num2;
						}
						continue;
					}
					case 1:
						num--;
						num2 = 1151412420;
						continue;
					case 4:
						break;
					case 2:
					{
						int num3;
						if (P_0[num] != null)
						{
							num2 = 1151412421;
							num3 = num2;
						}
						else
						{
							num2 = 1151412418;
							num3 = num2;
						}
						continue;
					}
					case 3:
						num2 = 1151412420;
						continue;
					case 0:
						P_0.RemoveAt(num);
						num2 = 1151412419;
						continue;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void SIlBmKpLSIperJpozsopNuvakxo(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = 269559596;
				while (true)
				{
					switch (num2 ^ 0x1011272F)
					{
					case 2:
						num2 = 269559598;
						continue;
					case 1:
						break;
					case 0:
						if (P_0[num] != null)
						{
							int num3;
							if (P_0[num].layoutId != P_1)
							{
								num2 = 269559595;
								num3 = num2;
							}
							else
							{
								num2 = 269559594;
								num3 = num2;
							}
							continue;
						}
						goto case 5;
					case 5:
						P_0.RemoveAt(num);
						num2 = 269559595;
						continue;
					case 4:
						num--;
						num2 = 269559596;
						continue;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void JCGgTXEOIqCyaSbJLZidoAjBthy(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = -1245745999;
				while (true)
				{
					switch (num2 ^ -1245745997)
					{
					case 6:
						num2 = -1245745993;
						continue;
					default:
						return;
					case 8:
					{
						int num4;
						if (num < 0)
						{
							num2 = -1245746000;
							num4 = num2;
						}
						else
						{
							num2 = -1245745994;
							num4 = num2;
						}
						continue;
					}
					case 5:
					{
						int num5;
						if (P_0[num] == null)
						{
							num2 = -1245745998;
							num5 = num2;
						}
						else
						{
							num2 = -1245745996;
							num5 = num2;
						}
						continue;
					}
					case 1:
						P_0.RemoveAt(num);
						num2 = -1245745997;
						continue;
					case 0:
						num--;
						num2 = -1245745989;
						continue;
					case 2:
						num2 = -1245745989;
						continue;
					case 7:
					{
						int num3;
						if (P_0[num].layoutId == P_1)
						{
							num2 = -1245745998;
							num3 = num2;
						}
						else
						{
							num2 = -1245745997;
							num3 = num2;
						}
						continue;
					}
					case 4:
						break;
					case 3:
						return;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void veMhdhqMJFeNGbUYvgFHjvfJVvM(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = 977695804;
				while (true)
				{
					switch (num2 ^ 0x3A46743F)
					{
					case 4:
						num2 = 977695806;
						continue;
					case 1:
						break;
					case 0:
						P_0.RemoveAt(num);
						num2 = 977695801;
						continue;
					case 2:
					{
						int num4;
						if (P_0[num] == null)
						{
							num2 = 977695807;
							num4 = num2;
						}
						else
						{
							num2 = 977695802;
							num4 = num2;
						}
						continue;
					}
					case 6:
						num--;
						num2 = 977695804;
						continue;
					case 5:
					{
						int num3;
						if (P_0[num].layoutId != P_1)
						{
							num2 = 977695801;
							num3 = num2;
						}
						else
						{
							num2 = 977695807;
							num3 = num2;
						}
						continue;
					}
					default:
						if (num < 0)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void PewHhTJnERgePzPsFXQyMfSSywZ(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = 2093685031;
				while (true)
				{
					switch (num2 ^ 0x7CCB1922)
					{
					case 2:
						num2 = 2093685027;
						continue;
					case 1:
						break;
					case 3:
						P_0.RemoveAt(num);
						num2 = 2093685026;
						continue;
					case 4:
						if (P_0[num] != null)
						{
							int num3;
							if (P_0[num].layoutId == P_1)
							{
								num2 = 2093685025;
								num3 = num2;
							}
							else
							{
								num2 = 2093685026;
								num3 = num2;
							}
							continue;
						}
						goto case 3;
					case 0:
						num--;
						num2 = 2093685031;
						continue;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
			}
		}
	}
}
