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
		private static class QLHgQpZPcsnVUxynhqtqdKZxfLI
		{
			private class zfpmTQonvrTjOJqbUbEUKlTCqdf
			{
				public enum WShhClxzwcSZIyaMxWChyIpnurx
				{
					RBlMEXOIUsCEfbktaDDkQUYwaysm = 0,
					RCOauDZdeEvGkaCTeYBvkrIMFQK = 1,
					cTHDnPOBDaIQlEKyfIKjBxYzcOnu = 2
				}

				public int RBlMEXOIUsCEfbktaDDkQUYwaysm;

				public int RCOauDZdeEvGkaCTeYBvkrIMFQK;

				public int cTHDnPOBDaIQlEKyfIKjBxYzcOnu;

				public int this[WShhClxzwcSZIyaMxWChyIpnurx type]
				{
					get
					{
						while (true)
						{
							switch (0x767B66D4 ^ 0x767B66D6)
							{
							case 0:
								continue;
							case 2:
								switch (type)
								{
								case WShhClxzwcSZIyaMxWChyIpnurx.RBlMEXOIUsCEfbktaDDkQUYwaysm:
									break;
								case WShhClxzwcSZIyaMxWChyIpnurx.RCOauDZdeEvGkaCTeYBvkrIMFQK:
									return RCOauDZdeEvGkaCTeYBvkrIMFQK;
								case WShhClxzwcSZIyaMxWChyIpnurx.cTHDnPOBDaIQlEKyfIKjBxYzcOnu:
									return cTHDnPOBDaIQlEKyfIKjBxYzcOnu;
								default:
									throw new NotImplementedException();
								}
								break;
							}
							break;
						}
						return RBlMEXOIUsCEfbktaDDkQUYwaysm;
					}
					set
					{
						while (true)
						{
							int num = 344136735;
							while (true)
							{
								switch (num ^ 0x14831C1E)
								{
								case 4:
									break;
								case 1:
									switch (type)
									{
									case WShhClxzwcSZIyaMxWChyIpnurx.cTHDnPOBDaIQlEKyfIKjBxYzcOnu:
										goto IL_0049;
									case WShhClxzwcSZIyaMxWChyIpnurx.RCOauDZdeEvGkaCTeYBvkrIMFQK:
										goto IL_0058;
									case WShhClxzwcSZIyaMxWChyIpnurx.RBlMEXOIUsCEfbktaDDkQUYwaysm:
										goto IL_0067;
									}
									num = 344136734;
									continue;
								case 5:
									goto IL_0049;
								case 3:
									goto IL_0058;
								case 2:
									goto IL_0067;
								case 6:
									return;
								default:
									{
										throw new NotImplementedException();
									}
									IL_0067:
									RBlMEXOIUsCEfbktaDDkQUYwaysm = value;
									num = 344136728;
									continue;
									IL_0058:
									RCOauDZdeEvGkaCTeYBvkrIMFQK = value;
									return;
									IL_0049:
									cTHDnPOBDaIQlEKyfIKjBxYzcOnu = value;
									return;
								}
								break;
							}
						}
					}
				}

				public zfpmTQonvrTjOJqbUbEUKlTCqdf(int origId, int otherId, int finalId)
				{
					RBlMEXOIUsCEfbktaDDkQUYwaysm = origId;
					RCOauDZdeEvGkaCTeYBvkrIMFQK = otherId;
					cTHDnPOBDaIQlEKyfIKjBxYzcOnu = finalId;
				}

				public override string ToString()
				{
					string text = "";
					text += StringTools.WriteVar("origId", RBlMEXOIUsCEfbktaDDkQUYwaysm);
					text += StringTools.WriteVar("otherId", RCOauDZdeEvGkaCTeYBvkrIMFQK);
					return text + StringTools.WriteVar("finalId", cTHDnPOBDaIQlEKyfIKjBxYzcOnu);
				}
			}

			private class lHFDDWjVDcRlOAZjbSJDfSQYpREQ<T>
			{
				public T jBPGEaYrWzWRAmgdbXEUhEyBXOS;

				public T cdIchUQhXPDsawgfzLCmqpUJqyw;

				public zfpmTQonvrTjOJqbUbEUKlTCqdf.WShhClxzwcSZIyaMxWChyIpnurx vGEummKjgDcSUGooGPOJfEZgtJrm;

				public IList<T> KgBiervgcFPhSNIBLZDZhOHKfLN;

				public bool HMoyquearlrlOniSOfLyhtLtphI;

				public lHFDDWjVDcRlOAZjbSJDfSQYpREQ(T otherItem, T finalItem, zfpmTQonvrTjOJqbUbEUKlTCqdf.WShhClxzwcSZIyaMxWChyIpnurx idType, IList<T> finalItems, bool isCollision)
				{
					while (true)
					{
						int num = 1812931839;
						while (true)
						{
							switch (num ^ 0x6C0F24FD)
							{
							case 0:
								break;
							case 2:
								goto IL_0024;
							default:
								HMoyquearlrlOniSOfLyhtLtphI = isCollision;
								return;
							}
							break;
							IL_0024:
							jBPGEaYrWzWRAmgdbXEUhEyBXOS = otherItem;
							cdIchUQhXPDsawgfzLCmqpUJqyw = finalItem;
							vGEummKjgDcSUGooGPOJfEZgtJrm = idType;
							KgBiervgcFPhSNIBLZDZhOHKfLN = finalItems;
							num = 1812931836;
						}
					}
				}
			}

			private sealed class pjhKBXcxIQSvXSEDSNexHaXjMmv
			{
				private sealed class kKfjeBuueMejjihJSFZyBAMYPYQT
				{
					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public lHFDDWjVDcRlOAZjbSJDfSQYpREQ<InputAction> mDgcyeMwmBaMprlpQyHooOSZUWD;

					public bool PonwMopJKwzqwPJVjAjNutdzjIv(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == mDgcyeMwmBaMprlpQyHooOSZUWD.jBPGEaYrWzWRAmgdbXEUhEyBXOS.categoryId;
					}

					public bool sDzmjYDDqFWTUiLGmreKfmNPAEH(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == mDgcyeMwmBaMprlpQyHooOSZUWD.jBPGEaYrWzWRAmgdbXEUhEyBXOS.behaviorId;
					}
				}

				private sealed class RFlYeEtvwtsrJzPcOsFudqxtbVB
				{
					public lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMapLayoutManager_RuleSet_Editor> mDgcyeMwmBaMprlpQyHooOSZUWD;
				}

				private sealed class CssflSEYNGnMuAdiSqREsneVPiLe
				{
					public RFlYeEtvwtsrJzPcOsFudqxtbVB NxFztvEgbGclhgJmhpZSembSgQ;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public int YbPMnNrMauuKoPmiSqpJmLYPYpt;

					public bool QqypPBPfTcsAJyTNPmTBuCwpCiJ(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[NxFztvEgbGclhgJmhpZSembSgQ.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == YbPMnNrMauuKoPmiSqpJmLYPYpt;
					}
				}

				private sealed class PMVKKKNXuiRBblOgwODHYOHlIxU
				{
					public RFlYeEtvwtsrJzPcOsFudqxtbVB NxFztvEgbGclhgJmhpZSembSgQ;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public int YbPMnNrMauuKoPmiSqpJmLYPYpt;

					public bool sknuvecgGTBGFHNNiPCCYKNNSoF(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[NxFztvEgbGclhgJmhpZSembSgQ.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == YbPMnNrMauuKoPmiSqpJmLYPYpt;
					}
				}

				private sealed class ggRDfkjNaAFHsdUFYZuILXnwCrer
				{
					public RFlYeEtvwtsrJzPcOsFudqxtbVB NxFztvEgbGclhgJmhpZSembSgQ;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public int YbPMnNrMauuKoPmiSqpJmLYPYpt;

					public bool FRLXmugZsQOAICRepGIpRTxmpNR(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[NxFztvEgbGclhgJmhpZSembSgQ.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == YbPMnNrMauuKoPmiSqpJmLYPYpt;
					}
				}

				private sealed class AriivNQohqbtKfpXsKPjwtDENao
				{
					public lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMapEnabler_RuleSet_Editor> mDgcyeMwmBaMprlpQyHooOSZUWD;
				}

				private sealed class xBhyosUaIqIoDUYZMEdMMDOxYCZ
				{
					public AriivNQohqbtKfpXsKPjwtDENao lriOjvLEpSzmsAdYSQrEZLuaakj;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public int YbPMnNrMauuKoPmiSqpJmLYPYpt;

					public bool UuXNMTaFKZupphIMKyYRCWoMiIa(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[lriOjvLEpSzmsAdYSQrEZLuaakj.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == YbPMnNrMauuKoPmiSqpJmLYPYpt;
					}
				}

				private sealed class JFrfNRNAiKLYAkLWkdmGVuNerSu
				{
					public AriivNQohqbtKfpXsKPjwtDENao lriOjvLEpSzmsAdYSQrEZLuaakj;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public int YbPMnNrMauuKoPmiSqpJmLYPYpt;

					public bool zoNJqMUNvBKXTzcelQMpnHiKVtT(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[lriOjvLEpSzmsAdYSQrEZLuaakj.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == YbPMnNrMauuKoPmiSqpJmLYPYpt;
					}
				}

				private sealed class QvpDZDLJTvJHSXMAXPljUNnpTjZ
				{
					public AriivNQohqbtKfpXsKPjwtDENao lriOjvLEpSzmsAdYSQrEZLuaakj;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public int YbPMnNrMauuKoPmiSqpJmLYPYpt;

					public bool SajBypNFwqmDRUpOhkkdOkyQOPY(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[lriOjvLEpSzmsAdYSQrEZLuaakj.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == YbPMnNrMauuKoPmiSqpJmLYPYpt;
					}
				}

				private sealed class EZazWksavffxpAmBeoOZIczCRAFX
				{
					private sealed class kyfXrgKKWSCSJdxSpLClTIspFgxh
					{
						public EZazWksavffxpAmBeoOZIczCRAFX pNYLFyQwRREsqeiUPyfDafyISzs;

						public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

						public Player_Editor.Mapping wWIAVQYLtUqmWRBSPcIMZSWLBQsG;

						public bool ahAfUEEridLgbYzkzdroxfpYNnT(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
						{
							return P_0[pNYLFyQwRREsqeiUPyfDafyISzs.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == wWIAVQYLtUqmWRBSPcIMZSWLBQsG.categoryId;
						}

						public bool WTUEkJiwQlUbqmXbIdzolJqXuSU(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
						{
							return P_0[pNYLFyQwRREsqeiUPyfDafyISzs.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == wWIAVQYLtUqmWRBSPcIMZSWLBQsG.layoutId;
						}
					}

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public lHFDDWjVDcRlOAZjbSJDfSQYpREQ<Player_Editor> mDgcyeMwmBaMprlpQyHooOSZUWD;

					public void XGtTnJYptYBMRwEscQGXsDvTEBF(List<Player_Editor.Mapping> P_0, List<zfpmTQonvrTjOJqbUbEUKlTCqdf> P_1)
					{
						int num = 0;
						kyfXrgKKWSCSJdxSpLClTIspFgxh kyfXrgKKWSCSJdxSpLClTIspFgxh2 = default(kyfXrgKKWSCSJdxSpLClTIspFgxh);
						while (true)
						{
							int num2 = -573921438;
							while (true)
							{
								switch (num2 ^ -573921437)
								{
								case 2:
									break;
								case 1:
									num2 = -573921434;
									continue;
								case 3:
								{
									zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = qTClCWNuYDhqHNJDcYUkEPyLewR.SclSkjgPLpFngbZoISugthSGOur.Find(kyfXrgKKWSCSJdxSpLClTIspFgxh2.ahAfUEEridLgbYzkzdroxfpYNnT);
									kyfXrgKKWSCSJdxSpLClTIspFgxh2.wWIAVQYLtUqmWRBSPcIMZSWLBQsG.categoryId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
									num2 = -573921437;
									continue;
								}
								case 4:
									kyfXrgKKWSCSJdxSpLClTIspFgxh2 = new kyfXrgKKWSCSJdxSpLClTIspFgxh();
									kyfXrgKKWSCSJdxSpLClTIspFgxh2.pNYLFyQwRREsqeiUPyfDafyISzs = this;
									kyfXrgKKWSCSJdxSpLClTIspFgxh2.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
									kyfXrgKKWSCSJdxSpLClTIspFgxh2.wWIAVQYLtUqmWRBSPcIMZSWLBQsG = P_0[num];
									num2 = -573921440;
									continue;
								case 0:
								{
									zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = P_1.Find(kyfXrgKKWSCSJdxSpLClTIspFgxh2.WTUEkJiwQlUbqmXbIdzolJqXuSU);
									kyfXrgKKWSCSJdxSpLClTIspFgxh2.wWIAVQYLtUqmWRBSPcIMZSWLBQsG.layoutId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
									num++;
									num2 = -573921434;
									continue;
								}
								default:
									if (num >= P_0.Count)
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

				private sealed class ofifhGIbYbVMCCtNdWwfAVIlpSWj
				{
					public EZazWksavffxpAmBeoOZIczCRAFX pNYLFyQwRREsqeiUPyfDafyISzs;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public Player_Editor.CreateControllerInfo AdqDRmvMCTHHDQWIUGnRloZhdLl;

					public bool YqqEfhWZzfRWnOByvtLfKvcwlHx(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[pNYLFyQwRREsqeiUPyfDafyISzs.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == AdqDRmvMCTHHDQWIUGnRloZhdLl.sourceId;
					}
				}

				private sealed class nBqPJdxWpLUxJdzvoHDcDntCbaBC
				{
					public EZazWksavffxpAmBeoOZIczCRAFX pNYLFyQwRREsqeiUPyfDafyISzs;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public int fKtuodNzZLrsthNmhfemlCLUaYzG;

					public bool XzWZOnXcEiAQjLgCrhJDQJxKaWY(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[pNYLFyQwRREsqeiUPyfDafyISzs.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == fKtuodNzZLrsthNmhfemlCLUaYzG;
					}
				}

				private sealed class GepCFWFSmMoCXhsWOzcdGUlHAcUI
				{
					public EZazWksavffxpAmBeoOZIczCRAFX pNYLFyQwRREsqeiUPyfDafyISzs;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public int fKtuodNzZLrsthNmhfemlCLUaYzG;

					public bool igqHKCIhjxsKFPCPChUilAUayvE(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[pNYLFyQwRREsqeiUPyfDafyISzs.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == fKtuodNzZLrsthNmhfemlCLUaYzG;
					}
				}

				public UserData gQKGqRzPUnrelmbksZbFXmMbfQEk;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> fkdOWSvkhKsVlzppDqqFfJszQwg;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> hjCcgSKskbufhQmwEKpioqLWKuQY;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> bApneWqkxJjGSMSoHKhCVlqWasMG;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> SclSkjgPLpFngbZoISugthSGOur;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> yGJqdfzJeMLTtAxqpValuiuofppC;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> yRyutBWetYAlfEiaLMyLYTUmXtH;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> YQRpSchsUChQpULokGiufHFJzNxR;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> BOWQgrgKHSYLhBKpcbkmdTZAKYpe;

				public Func<ControllerType, List<zfpmTQonvrTjOJqbUbEUKlTCqdf>> BqwnPHdiEAAYVKspIjetsvMuCQf;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> ngBkUCBWeNOKhqSbWSAdLHAWbwz;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> eYhzTCjKkJCfMqmOnNjyeXXxbhn;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> lhLhfTleShdifyqLvIIpptrvfPx;

				private static Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> YiQQrhLZpnsLTpRLqbkTZoFBIrnc;

				private static Func<Player_Editor.CreateControllerInfo, IList<Player_Editor.CreateControllerInfo>, int> TQtuzrrPdAYqGKUnIvxyvbupcDy;

				public InputCategory DtsHMOLCVyrBkwCBxuQJHRitExM(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<InputCategory> P_0)
				{
					InputCategory inputCategory = JsonTools.Clone(P_0.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
					if (!P_0.HMoyquearlrlOniSOfLyhtLtphI)
					{
						goto IL_0043;
					}
					InputCategory inputCategory2 = P_0.cdIchUQhXPDsawgfzLCmqpUJqyw;
					goto IL_0082;
					IL_0043:
					gQKGqRzPUnrelmbksZbFXmMbfQEk.AddActionCategory();
					inputCategory2 = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
					int num = 287794328;
					goto IL_0022;
					IL_0082:
					inputCategory.id = inputCategory2.id;
					int index = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(inputCategory2);
					num = 287794334;
					goto IL_0022;
					IL_0022:
					while (true)
					{
						switch (num ^ 0x1127649A)
						{
						case 0:
							num = 287794329;
							continue;
						case 3:
							break;
						case 4:
							P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = inputCategory;
							num = 287794331;
							continue;
						case 2:
							goto IL_0082;
						default:
							return inputCategory;
						}
						break;
					}
					goto IL_0043;
				}

				public InputBehavior PucxbXLvUNfLDGkrsdKFrckYHLbe(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
					InputBehavior inputBehavior2;
					if (P_0.HMoyquearlrlOniSOfLyhtLtphI)
					{
						inputBehavior2 = P_0.cdIchUQhXPDsawgfzLCmqpUJqyw;
						goto IL_001b;
					}
					goto IL_0059;
					IL_0059:
					gQKGqRzPUnrelmbksZbFXmMbfQEk.AddInputBehavior();
					inputBehavior2 = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
					int num = -913099209;
					goto IL_0020;
					IL_001b:
					num = -913099216;
					goto IL_0020;
					IL_0020:
					int index = default(int);
					while (true)
					{
						switch (num ^ -913099214)
						{
						case 3:
							break;
						case 1:
							P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = inputBehavior;
							num = -913099214;
							continue;
						case 4:
							goto IL_0059;
						case 5:
							inputBehavior.id = inputBehavior2.id;
							index = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(inputBehavior2);
							num = -913099213;
							continue;
						case 2:
							num = -913099209;
							continue;
						default:
							return inputBehavior;
						}
						break;
					}
					goto IL_001b;
				}

				public InputAction QELeMmbAQSEOgVfCBvPfQuzBhAR(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<InputAction> P_0)
				{
					kKfjeBuueMejjihJSFZyBAMYPYQT kKfjeBuueMejjihJSFZyBAMYPYQT2 = new kKfjeBuueMejjihJSFZyBAMYPYQT();
					InputAction inputAction = default(InputAction);
					int behaviorId = default(int);
					InputAction inputAction2 = default(InputAction);
					int num2 = default(int);
					while (true)
					{
						int num = 689774152;
						while (true)
						{
							switch (num ^ 0x291D1E49)
							{
							case 5:
								break;
							case 6:
							{
								inputAction.behaviorId = behaviorId;
								int index = kKfjeBuueMejjihJSFZyBAMYPYQT2.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(inputAction2);
								kKfjeBuueMejjihJSFZyBAMYPYQT2.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = inputAction;
								num = 689774158;
								continue;
							}
							case 3:
							{
								inputAction = JsonTools.Clone(kKfjeBuueMejjihJSFZyBAMYPYQT2.mDgcyeMwmBaMprlpQyHooOSZUWD.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = fkdOWSvkhKsVlzppDqqFfJszQwg.Find(kKfjeBuueMejjihJSFZyBAMYPYQT2.PonwMopJKwzqwPJVjAjNutdzjIv);
								num2 = ((zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : 0);
								num = 689774153;
								continue;
							}
							case 8:
								gQKGqRzPUnrelmbksZbFXmMbfQEk.AddAction(num2);
								num = 689774144;
								continue;
							case 4:
								inputAction.categoryId = num2;
								num = 689774159;
								continue;
							case 1:
								kKfjeBuueMejjihJSFZyBAMYPYQT2.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
								kKfjeBuueMejjihJSFZyBAMYPYQT2.mDgcyeMwmBaMprlpQyHooOSZUWD = P_0;
								num = 689774154;
								continue;
							case 2:
							{
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = hjCcgSKskbufhQmwEKpioqLWKuQY.Find(kKfjeBuueMejjihJSFZyBAMYPYQT2.sDzmjYDDqFWTUiLGmreKfmNPAEH);
								behaviorId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : 0);
								inputAction.id = inputAction2.id;
								if (num2 != inputAction2.categoryId)
								{
									gQKGqRzPUnrelmbksZbFXmMbfQEk.ChangeActionCategory(inputAction2.id, num2);
									num = 689774157;
									continue;
								}
								goto case 4;
							}
							case 0:
								if (kKfjeBuueMejjihJSFZyBAMYPYQT2.mDgcyeMwmBaMprlpQyHooOSZUWD.HMoyquearlrlOniSOfLyhtLtphI)
								{
									inputAction2 = kKfjeBuueMejjihJSFZyBAMYPYQT2.mDgcyeMwmBaMprlpQyHooOSZUWD.cdIchUQhXPDsawgfzLCmqpUJqyw;
									num = 689774155;
									continue;
								}
								goto case 8;
							case 9:
								inputAction2 = kKfjeBuueMejjihJSFZyBAMYPYQT2.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[kKfjeBuueMejjihJSFZyBAMYPYQT2.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
								num = 689774155;
								continue;
							default:
								return inputAction;
							}
							break;
						}
					}
				}

				public InputLayout KLbYJFVOqGOuIKNoEuZwvxFMlcy(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
					if (P_0.HMoyquearlrlOniSOfLyhtLtphI)
					{
						goto IL_0014;
					}
					goto IL_0044;
					IL_0014:
					int num = -340298317;
					goto IL_0019;
					IL_0019:
					InputLayout inputLayout2 = default(InputLayout);
					while (true)
					{
						switch (num ^ -340298318)
						{
						case 2:
							break;
						case 1:
							inputLayout2 = P_0.cdIchUQhXPDsawgfzLCmqpUJqyw;
							num = -340298318;
							continue;
						case 3:
							goto IL_0044;
						default:
						{
							inputLayout.id = inputLayout2.id;
							int index = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(inputLayout2);
							P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = inputLayout;
							return inputLayout;
						}
						}
						break;
					}
					goto IL_0014;
					IL_0044:
					gQKGqRzPUnrelmbksZbFXmMbfQEk.AddKeyboardLayout();
					inputLayout2 = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
					num = -340298318;
					goto IL_0019;
				}

				public InputLayout mKjCaiKwwMcEBkbcTdXNguyDfZQZ(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
					InputLayout inputLayout2 = default(InputLayout);
					if (P_0.HMoyquearlrlOniSOfLyhtLtphI)
					{
						inputLayout2 = P_0.cdIchUQhXPDsawgfzLCmqpUJqyw;
						goto IL_0047;
					}
					goto IL_006e;
					IL_006e:
					gQKGqRzPUnrelmbksZbFXmMbfQEk.AddMouseLayout();
					int num = -1940361177;
					goto IL_0022;
					IL_0047:
					inputLayout.id = inputLayout2.id;
					num = -1940361183;
					goto IL_0022;
					IL_0022:
					int index = default(int);
					while (true)
					{
						switch (num ^ -1940361179)
						{
						case 5:
							num = -1940361180;
							continue;
						case 3:
							break;
						case 4:
							index = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(inputLayout2);
							num = -1940361179;
							continue;
						case 1:
							goto IL_006e;
						case 2:
							inputLayout2 = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
							num = -1940361178;
							continue;
						default:
							P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = inputLayout;
							return inputLayout;
						}
						break;
					}
					goto IL_0047;
				}

				public InputLayout ARQqwfRdxyzmhWSuRlcMeHwpesWg(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
					if (P_0.HMoyquearlrlOniSOfLyhtLtphI)
					{
						goto IL_0014;
					}
					goto IL_0072;
					IL_0014:
					int num = -1246077954;
					goto IL_0019;
					IL_0019:
					InputLayout inputLayout2 = default(InputLayout);
					while (true)
					{
						switch (num ^ -1246077957)
						{
						case 2:
							break;
						case 3:
						{
							int index = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(inputLayout2);
							P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = inputLayout;
							num = -1246077953;
							continue;
						}
						case 1:
							inputLayout.id = inputLayout2.id;
							num = -1246077960;
							continue;
						case 0:
							goto IL_0072;
						case 5:
							inputLayout2 = P_0.cdIchUQhXPDsawgfzLCmqpUJqyw;
							num = -1246077958;
							continue;
						default:
							return inputLayout;
						}
						break;
					}
					goto IL_0014;
					IL_0072:
					gQKGqRzPUnrelmbksZbFXmMbfQEk.AddJoystickLayout();
					inputLayout2 = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
					num = -1246077958;
					goto IL_0019;
				}

				public InputLayout YKnDbBHhgUnHdVmTvuuylvCnFtz(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
					InputLayout inputLayout2 = default(InputLayout);
					int index = default(int);
					while (true)
					{
						int num = -1644841845;
						while (true)
						{
							switch (num ^ -1644841847)
							{
							case 4:
								break;
							case 0:
								inputLayout.id = inputLayout2.id;
								num = -1644841844;
								continue;
							case 5:
								index = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(inputLayout2);
								num = -1644841846;
								continue;
							case 2:
								if (P_0.HMoyquearlrlOniSOfLyhtLtphI)
								{
									inputLayout2 = P_0.cdIchUQhXPDsawgfzLCmqpUJqyw;
									num = -1644841847;
									continue;
								}
								goto case 1;
							case 1:
								gQKGqRzPUnrelmbksZbFXmMbfQEk.AddCustomControllerLayout();
								inputLayout2 = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
								num = -1644841847;
								continue;
							default:
								P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = inputLayout;
								return inputLayout;
							}
							break;
						}
					}
				}

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> LTlvtWjuaNqkDmTNPmJWgHYUJDg(ControllerType P_0)
				{
					switch (P_0)
					{
					default:
						while (true)
						{
							switch (-376220353 ^ -376220354)
							{
							case 2:
								continue;
							case 1:
								throw new NotImplementedException();
							}
							break;
						}
						goto case ControllerType.Keyboard;
					case ControllerType.Keyboard:
						return yGJqdfzJeMLTtAxqpValuiuofppC;
					case ControllerType.Mouse:
						return yRyutBWetYAlfEiaLMyLYTUmXtH;
					case ControllerType.Joystick:
						return YQRpSchsUChQpULokGiufHFJzNxR;
					case ControllerType.Custom:
						return BOWQgrgKHSYLhBKpcbkmdTZAKYpe;
					}
				}

				public CustomController_Editor kVoBiFreyjpFpyAkNmEaOHfmgzNF(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
					if (P_0.HMoyquearlrlOniSOfLyhtLtphI)
					{
						goto IL_0014;
					}
					goto IL_0048;
					IL_0014:
					int num = -2069655426;
					goto IL_0019;
					IL_0019:
					CustomController_Editor customController_Editor2 = default(CustomController_Editor);
					while (true)
					{
						switch (num ^ -2069655430)
						{
						case 2:
							break;
						case 4:
							customController_Editor2 = P_0.cdIchUQhXPDsawgfzLCmqpUJqyw;
							num = -2069655429;
							continue;
						case 0:
							goto IL_0048;
						case 1:
						{
							customController_Editor.id = customController_Editor2.id;
							int index = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(customController_Editor2);
							P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = customController_Editor;
							num = -2069655431;
							continue;
						}
						default:
							return customController_Editor;
						}
						break;
					}
					goto IL_0014;
					IL_0048:
					gQKGqRzPUnrelmbksZbFXmMbfQEk.AddCustomController();
					customController_Editor2 = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
					num = -2069655429;
					goto IL_0019;
				}

				public ControllerMapLayoutManager_RuleSet_Editor LjJXfLdEbuxziWzffcCTkQrpCwG(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					RFlYeEtvwtsrJzPcOsFudqxtbVB rFlYeEtvwtsrJzPcOsFudqxtbVB = new RFlYeEtvwtsrJzPcOsFudqxtbVB();
					rFlYeEtvwtsrJzPcOsFudqxtbVB.mDgcyeMwmBaMprlpQyHooOSZUWD = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(rFlYeEtvwtsrJzPcOsFudqxtbVB.mDgcyeMwmBaMprlpQyHooOSZUWD.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
					CssflSEYNGnMuAdiSqREsneVPiLe cssflSEYNGnMuAdiSqREsneVPiLe = default(CssflSEYNGnMuAdiSqREsneVPiLe);
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor = default(ControllerMapLayoutManager_Rule_Editor);
					int num3 = default(int);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					List<int> list = default(List<int>);
					object[] array = default(object[]);
					PMVKKKNXuiRBblOgwODHYOHlIxU pMVKKKNXuiRBblOgwODHYOHlIxU = default(PMVKKKNXuiRBblOgwODHYOHlIxU);
					int num4 = default(int);
					int num8 = default(int);
					int num12 = default(int);
					int num6 = default(int);
					int num5 = default(int);
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = default(ControllerMapLayoutManager_Rule_Editor);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2 = default(ControllerMapLayoutManager_RuleSet_Editor);
					ControllerType controllerType = default(ControllerType);
					ggRDfkjNaAFHsdUFYZuILXnwCrer ggRDfkjNaAFHsdUFYZuILXnwCrer2 = default(ggRDfkjNaAFHsdUFYZuILXnwCrer);
					List<zfpmTQonvrTjOJqbUbEUKlTCqdf> list2 = default(List<zfpmTQonvrTjOJqbUbEUKlTCqdf>);
					int num10 = default(int);
					List<zfpmTQonvrTjOJqbUbEUKlTCqdf> list3 = default(List<zfpmTQonvrTjOJqbUbEUKlTCqdf>);
					int num2 = default(int);
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = default(ControllerMapLayoutManager_Rule_Editor);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf4 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					ControllerType controllerType2 = default(ControllerType);
					while (true)
					{
						int num = 509369046;
						while (true)
						{
							switch (num ^ 0x1E5C5ADC)
							{
							case 30:
								break;
							case 19:
								cssflSEYNGnMuAdiSqREsneVPiLe.YbPMnNrMauuKoPmiSqpJmLYPYpt = controllerMapLayoutManager_Rule_Editor.categoryIds[num3];
								zfpmTQonvrTjOJqbUbEUKlTCqdf3 = SclSkjgPLpFngbZoISugthSGOur.Find(cssflSEYNGnMuAdiSqREsneVPiLe.QqypPBPfTcsAJyTNPmTBuCwpCiJ);
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf3 == null)
								{
									Logger.LogError("No new Map Category Id found for old id: " + cssflSEYNGnMuAdiSqREsneVPiLe.YbPMnNrMauuKoPmiSqpJmLYPYpt);
									num = 509369029;
									continue;
								}
								goto case 8;
							case 31:
								list = new List<int>();
								num = 509369053;
								continue;
							case 34:
								cssflSEYNGnMuAdiSqREsneVPiLe = new CssflSEYNGnMuAdiSqREsneVPiLe();
								cssflSEYNGnMuAdiSqREsneVPiLe.NxFztvEgbGclhgJmhpZSembSgQ = rFlYeEtvwtsrJzPcOsFudqxtbVB;
								cssflSEYNGnMuAdiSqREsneVPiLe.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
								num = 509369039;
								continue;
							case 5:
								array[3] = pMVKKKNXuiRBblOgwODHYOHlIxU.YbPMnNrMauuKoPmiSqpJmLYPYpt;
								num = 509369087;
								continue;
							case 33:
								num4++;
								num = 509369032;
								continue;
							case 13:
								controllerMapLayoutManager_Rule_Editor = controllerMapLayoutManager_RuleSet_Editor.rules[num8];
								if (controllerMapLayoutManager_Rule_Editor != null)
								{
									int num9;
									if (controllerMapLayoutManager_Rule_Editor.categoryIds != null)
									{
										num = 509369027;
										num9 = num;
									}
									else
									{
										num = 509369052;
										num9 = num;
									}
									continue;
								}
								goto case 0;
							case 20:
								if (num4 >= num12)
								{
									num6 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
									num5 = 0;
									num = 509369033;
									continue;
								}
								goto case 32;
							case 29:
								controllerMapLayoutManager_Rule_Editor2.layoutId = zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu;
								num = 509369085;
								continue;
							case 27:
								num5++;
								num = 509369033;
								continue;
							case 7:
								controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
								num = 509369038;
								continue;
							case 8:
								list.Add(zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu);
								num = 509369029;
								continue;
							case 21:
								if (num5 >= num6)
								{
									int num7;
									if (!rFlYeEtvwtsrJzPcOsFudqxtbVB.mDgcyeMwmBaMprlpQyHooOSZUWD.HMoyquearlrlOniSOfLyhtLtphI)
									{
										num = 509369081;
										num7 = num;
									}
									else
									{
										num = 509369040;
										num7 = num;
									}
									continue;
								}
								goto case 17;
							case 3:
								if (controllerType == ControllerType.Custom)
								{
									ggRDfkjNaAFHsdUFYZuILXnwCrer2 = new ggRDfkjNaAFHsdUFYZuILXnwCrer();
									ggRDfkjNaAFHsdUFYZuILXnwCrer2.NxFztvEgbGclhgJmhpZSembSgQ = rFlYeEtvwtsrJzPcOsFudqxtbVB;
									ggRDfkjNaAFHsdUFYZuILXnwCrer2.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
									num = 509369028;
									continue;
								}
								goto case 27;
							case 18:
							{
								int index = rFlYeEtvwtsrJzPcOsFudqxtbVB.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
								rFlYeEtvwtsrJzPcOsFudqxtbVB.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = controllerMapLayoutManager_RuleSet_Editor;
								num = 509369047;
								continue;
							}
							case 38:
								pMVKKKNXuiRBblOgwODHYOHlIxU.YbPMnNrMauuKoPmiSqpJmLYPYpt = controllerMapLayoutManager_Rule_Editor2.layoutId;
								zfpmTQonvrTjOJqbUbEUKlTCqdf2 = list2.Find(pMVKKKNXuiRBblOgwODHYOHlIxU.sknuvecgGTBGFHNNiPCCYKNNSoF);
								num = 509369036;
								continue;
							case 35:
								Logger.LogError(string.Concat(array));
								num = 509369085;
								continue;
							case 32:
								pMVKKKNXuiRBblOgwODHYOHlIxU = new PMVKKKNXuiRBblOgwODHYOHlIxU();
								pMVKKKNXuiRBblOgwODHYOHlIxU.NxFztvEgbGclhgJmhpZSembSgQ = rFlYeEtvwtsrJzPcOsFudqxtbVB;
								pMVKKKNXuiRBblOgwODHYOHlIxU.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
								num = 509369024;
								continue;
							case 22:
								if (num8 >= num10)
								{
									num12 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
									num = 509369043;
									continue;
								}
								goto case 13;
							case 24:
								list3 = ngBkUCBWeNOKhqSbWSAdLHAWbwz;
								num = 509369080;
								continue;
							case 6:
							{
								int num11;
								if (num3 >= num2)
								{
									num = 509369045;
									num11 = num;
								}
								else
								{
									num = 509369086;
									num11 = num;
								}
								continue;
							}
							case 36:
								ggRDfkjNaAFHsdUFYZuILXnwCrer2.YbPMnNrMauuKoPmiSqpJmLYPYpt = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
								zfpmTQonvrTjOJqbUbEUKlTCqdf4 = list3.Find(ggRDfkjNaAFHsdUFYZuILXnwCrer2.FRLXmugZsQOAICRepGIpRTxmpNR);
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf4 == null)
								{
									controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
									Logger.LogError("No new Custom Controller found for old id: " + ggRDfkjNaAFHsdUFYZuILXnwCrer2.YbPMnNrMauuKoPmiSqpJmLYPYpt);
									num = 509369031;
									continue;
								}
								goto case 4;
							case 10:
								num10 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
								num8 = 0;
								num = 509369034;
								continue;
							case 25:
								num3++;
								num = 509369050;
								continue;
							case 17:
								controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[num5];
								if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null)
								{
									controllerType = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType;
									num = 509369055;
									continue;
								}
								goto case 27;
							case 4:
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = zfpmTQonvrTjOJqbUbEUKlTCqdf4.cTHDnPOBDaIQlEKyfIKjBxYzcOnu;
								num = 509369031;
								continue;
							case 14:
								num = 509369050;
								continue;
							case 16:
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf2 == null)
								{
									controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
									array = new object[4] { "No new ", controllerType2, null, null };
									num = 509369030;
									continue;
								}
								goto case 29;
							case 28:
								controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[num4];
								if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
								{
									controllerType2 = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
									list2 = BqwnPHdiEAAYVKspIjetsvMuCQf(controllerType2);
									num = 509369082;
									continue;
								}
								goto case 33;
							case 15:
								num4 = 0;
								num = 509369032;
								continue;
							case 2:
								num = 509369051;
								continue;
							case 26:
								array[2] = " Layout Id found for old id: ";
								num = 509369049;
								continue;
							case 9:
								controllerMapLayoutManager_Rule_Editor.categoryIds = list;
								num = 509369052;
								continue;
							case 37:
								gQKGqRzPUnrelmbksZbFXmMbfQEk.AddControllerMapLayoutManagerRuleSet();
								num = 509369035;
								continue;
							case 1:
								num2 = ((controllerMapLayoutManager_Rule_Editor.categoryIds != null) ? controllerMapLayoutManager_Rule_Editor.categoryIds.Count : 0);
								num3 = 0;
								num = 509369042;
								continue;
							case 12:
								controllerMapLayoutManager_RuleSet_Editor2 = rFlYeEtvwtsrJzPcOsFudqxtbVB.mDgcyeMwmBaMprlpQyHooOSZUWD.cdIchUQhXPDsawgfzLCmqpUJqyw;
								num = 509369054;
								continue;
							case 23:
								controllerMapLayoutManager_RuleSet_Editor2 = rFlYeEtvwtsrJzPcOsFudqxtbVB.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[rFlYeEtvwtsrJzPcOsFudqxtbVB.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
								num = 509369051;
								continue;
							case 0:
								num8++;
								num = 509369034;
								continue;
							default:
								return controllerMapLayoutManager_RuleSet_Editor;
							}
							break;
						}
					}
				}

				public ControllerMapEnabler_RuleSet_Editor frpLDJFQldqZIyULpSKAUqpBFPW(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					AriivNQohqbtKfpXsKPjwtDENao ariivNQohqbtKfpXsKPjwtDENao = new AriivNQohqbtKfpXsKPjwtDENao();
					int num5 = default(int);
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor3 = default(ControllerMapEnabler_Rule_Editor);
					List<int> list4 = default(List<int>);
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2 = default(ControllerMapEnabler_RuleSet_Editor);
					int num10 = default(int);
					int num8 = default(int);
					object[] array = default(object[]);
					JFrfNRNAiKLYAkLWkdmGVuNerSu jFrfNRNAiKLYAkLWkdmGVuNerSu = default(JFrfNRNAiKLYAkLWkdmGVuNerSu);
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor2 = default(ControllerMapEnabler_Rule_Editor);
					int num2 = default(int);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf4 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					List<zfpmTQonvrTjOJqbUbEUKlTCqdf> list3 = default(List<zfpmTQonvrTjOJqbUbEUKlTCqdf>);
					ControllerType controllerType2 = default(ControllerType);
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor = default(ControllerMapEnabler_Rule_Editor);
					int num6 = default(int);
					QvpDZDLJTvJHSXMAXPljUNnpTjZ qvpDZDLJTvJHSXMAXPljUNnpTjZ = default(QvpDZDLJTvJHSXMAXPljUNnpTjZ);
					int num11 = default(int);
					int num12 = default(int);
					int num3 = default(int);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					List<int> list2 = default(List<int>);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					xBhyosUaIqIoDUYZMEdMMDOxYCZ xBhyosUaIqIoDUYZMEdMMDOxYCZ2 = default(xBhyosUaIqIoDUYZMEdMMDOxYCZ);
					int num9 = default(int);
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = default(ControllerMapEnabler_RuleSet_Editor);
					while (true)
					{
						int num = 1973912615;
						while (true)
						{
							int num13;
							switch (num ^ 0x75A78400)
							{
							case 7:
								break;
							case 44:
								if (num5 >= controllerMapEnabler_Rule_Editor3.categoryIds.Count)
								{
									controllerMapEnabler_Rule_Editor3.categoryIds = list4;
									num = 1973912610;
									continue;
								}
								goto case 10;
							case 33:
								controllerMapEnabler_Rule_Editor3 = controllerMapEnabler_RuleSet_Editor2.rules[num10];
								num = 1973912618;
								continue;
							case 2:
								num8++;
								num = 1973912613;
								continue;
							case 6:
								num8 = 0;
								num = 1973912613;
								continue;
							case 22:
								Logger.LogError(string.Concat(array));
								num = 1973912597;
								continue;
							case 31:
								jFrfNRNAiKLYAkLWkdmGVuNerSu.YbPMnNrMauuKoPmiSqpJmLYPYpt = controllerMapEnabler_Rule_Editor2.layoutIds[num2];
								zfpmTQonvrTjOJqbUbEUKlTCqdf4 = list3.Find(jFrfNRNAiKLYAkLWkdmGVuNerSu.zoNJqMUNvBKXTzcelQMpnHiKVtT);
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf4 == null)
								{
									array = new object[4] { "No new ", controllerType2, " Layout Id found for old id: ", null };
									num = 1973912580;
									continue;
								}
								goto case 41;
							case 16:
								controllerMapEnabler_Rule_Editor = controllerMapEnabler_RuleSet_Editor2.rules[num6];
								if (controllerMapEnabler_Rule_Editor != null && controllerMapEnabler_Rule_Editor.controllerSetSelector != null)
								{
									ControllerType controllerType = controllerMapEnabler_Rule_Editor.controllerSetSelector.controllerType;
									if (controllerType == ControllerType.Custom)
									{
										qvpDZDLJTvJHSXMAXPljUNnpTjZ = new QvpDZDLJTvJHSXMAXPljUNnpTjZ();
										qvpDZDLJTvJHSXMAXPljUNnpTjZ.lriOjvLEpSzmsAdYSQrEZLuaakj = ariivNQohqbtKfpXsKPjwtDENao;
										num = 1973912604;
										continue;
									}
								}
								goto case 15;
							case 37:
								if (num8 >= num11)
								{
									num12 = ((controllerMapEnabler_RuleSet_Editor2.rules != null) ? controllerMapEnabler_RuleSet_Editor2.rules.Count : 0);
									num6 = 0;
									num = 1973912579;
									continue;
								}
								goto case 13;
							case 9:
								num5 = 0;
								num = 1973912608;
								continue;
							case 23:
							{
								int num4;
								if (num2 >= num3)
								{
									num = 1973912584;
									num4 = num;
								}
								else
								{
									num = 1973912616;
									num4 = num;
								}
								continue;
							}
							case 14:
								controllerMapEnabler_Rule_Editor.controllerSetSelector.customControllerSourceId = zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu;
								num = 1973912591;
								continue;
							case 4:
								array[3] = jFrfNRNAiKLYAkLWkdmGVuNerSu.YbPMnNrMauuKoPmiSqpJmLYPYpt;
								num = 1973912598;
								continue;
							case 3:
							{
								int num14;
								if (num6 >= num12)
								{
									num = 1973912619;
									num14 = num;
								}
								else
								{
									num = 1973912592;
									num14 = num;
								}
								continue;
							}
							case 41:
								list2.Add(zfpmTQonvrTjOJqbUbEUKlTCqdf4.cTHDnPOBDaIQlEKyfIKjBxYzcOnu);
								num = 1973912606;
								continue;
							case 34:
								num10++;
								num = 1973912603;
								continue;
							case 19:
								list4.Add(zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu);
								num = 1973912576;
								continue;
							case 10:
								xBhyosUaIqIoDUYZMEdMMDOxYCZ2 = new xBhyosUaIqIoDUYZMEdMMDOxYCZ();
								xBhyosUaIqIoDUYZMEdMMDOxYCZ2.lriOjvLEpSzmsAdYSQrEZLuaakj = ariivNQohqbtKfpXsKPjwtDENao;
								xBhyosUaIqIoDUYZMEdMMDOxYCZ2.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
								xBhyosUaIqIoDUYZMEdMMDOxYCZ2.YbPMnNrMauuKoPmiSqpJmLYPYpt = controllerMapEnabler_Rule_Editor3.categoryIds[num5];
								num = 1973912596;
								continue;
							case 18:
								num13 = 0;
								goto IL_031f;
							case 12:
								Logger.LogError("No new Map Category Id found for old id: " + xBhyosUaIqIoDUYZMEdMMDOxYCZ2.YbPMnNrMauuKoPmiSqpJmLYPYpt);
								num = 1973912600;
								continue;
							case 42:
								if (controllerMapEnabler_Rule_Editor3 != null && controllerMapEnabler_Rule_Editor3.categoryIds != null)
								{
									list4 = new List<int>();
									num = 1973912585;
									continue;
								}
								goto case 34;
							case 27:
								if (num10 >= num9)
								{
									num11 = ((controllerMapEnabler_RuleSet_Editor2.rules != null) ? controllerMapEnabler_RuleSet_Editor2.rules.Count : 0);
									num = 1973912582;
									continue;
								}
								goto case 33;
							case 39:
								ariivNQohqbtKfpXsKPjwtDENao.mDgcyeMwmBaMprlpQyHooOSZUWD = P_0;
								controllerMapEnabler_RuleSet_Editor2 = JsonTools.Clone(ariivNQohqbtKfpXsKPjwtDENao.mDgcyeMwmBaMprlpQyHooOSZUWD.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
								num9 = ((controllerMapEnabler_RuleSet_Editor2.rules != null) ? controllerMapEnabler_RuleSet_Editor2.rules.Count : 0);
								num10 = 0;
								num = 1973912603;
								continue;
							case 8:
								controllerMapEnabler_Rule_Editor2.layoutIds = list2;
								num = 1973912578;
								continue;
							case 21:
								num = 1973912606;
								continue;
							case 26:
							{
								int num7;
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf3 == null)
								{
									num = 1973912588;
									num7 = num;
								}
								else
								{
									num = 1973912595;
									num7 = num;
								}
								continue;
							}
							case 25:
								num2 = 0;
								num = 1973912581;
								continue;
							case 43:
								if (ariivNQohqbtKfpXsKPjwtDENao.mDgcyeMwmBaMprlpQyHooOSZUWD.HMoyquearlrlOniSOfLyhtLtphI)
								{
									controllerMapEnabler_RuleSet_Editor = ariivNQohqbtKfpXsKPjwtDENao.mDgcyeMwmBaMprlpQyHooOSZUWD.cdIchUQhXPDsawgfzLCmqpUJqyw;
									num = 1973912611;
									continue;
								}
								goto case 1;
							case 0:
								num5++;
								num = 1973912620;
								continue;
							case 17:
								num = 1973912591;
								continue;
							case 13:
								controllerMapEnabler_Rule_Editor2 = controllerMapEnabler_RuleSet_Editor2.rules[num8];
								if (controllerMapEnabler_Rule_Editor2 == null || controllerMapEnabler_Rule_Editor2.layoutIds == null)
								{
									goto case 2;
								}
								controllerType2 = controllerMapEnabler_Rule_Editor2.controllerSetSelector.controllerType;
								list3 = BqwnPHdiEAAYVKspIjetsvMuCQf(controllerType2);
								list2 = new List<int>();
								if (controllerMapEnabler_Rule_Editor2.layoutIds != null)
								{
									num13 = controllerMapEnabler_Rule_Editor2.layoutIds.Count;
									goto IL_031f;
								}
								num = 1973912594;
								continue;
							case 29:
								jFrfNRNAiKLYAkLWkdmGVuNerSu.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
								num = 1973912607;
								continue;
							case 40:
								jFrfNRNAiKLYAkLWkdmGVuNerSu = new JFrfNRNAiKLYAkLWkdmGVuNerSu();
								num = 1973912587;
								continue;
							case 15:
								num6++;
								num = 1973912579;
								continue;
							case 5:
								num = 1973912599;
								continue;
							case 24:
								num = 1973912576;
								continue;
							case 20:
								zfpmTQonvrTjOJqbUbEUKlTCqdf3 = SclSkjgPLpFngbZoISugthSGOur.Find(xBhyosUaIqIoDUYZMEdMMDOxYCZ2.UuXNMTaFKZupphIMKyYRCWoMiIa);
								num = 1973912602;
								continue;
							case 1:
								gQKGqRzPUnrelmbksZbFXmMbfQEk.AddControllerMapEnablerRuleSet();
								controllerMapEnabler_RuleSet_Editor = ariivNQohqbtKfpXsKPjwtDENao.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[ariivNQohqbtKfpXsKPjwtDENao.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
								num = 1973912611;
								continue;
							case 11:
								jFrfNRNAiKLYAkLWkdmGVuNerSu.lriOjvLEpSzmsAdYSQrEZLuaakj = ariivNQohqbtKfpXsKPjwtDENao;
								num = 1973912605;
								continue;
							case 28:
							{
								qvpDZDLJTvJHSXMAXPljUNnpTjZ.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
								List<zfpmTQonvrTjOJqbUbEUKlTCqdf> list = ngBkUCBWeNOKhqSbWSAdLHAWbwz;
								qvpDZDLJTvJHSXMAXPljUNnpTjZ.YbPMnNrMauuKoPmiSqpJmLYPYpt = controllerMapEnabler_Rule_Editor.controllerSetSelector.customControllerSourceId;
								zfpmTQonvrTjOJqbUbEUKlTCqdf2 = list.Find(qvpDZDLJTvJHSXMAXPljUNnpTjZ.SajBypNFwqmDRUpOhkkdOkyQOPY);
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf2 == null)
								{
									controllerMapEnabler_Rule_Editor.controllerSetSelector.customControllerSourceId = -1;
									num = 1973912614;
									continue;
								}
								goto case 14;
							}
							case 35:
								controllerMapEnabler_RuleSet_Editor2.id = controllerMapEnabler_RuleSet_Editor.id;
								num = 1973912612;
								continue;
							case 32:
								num = 1973912620;
								continue;
							case 38:
								Logger.LogError("No new Custom Controller found for old id: " + qvpDZDLJTvJHSXMAXPljUNnpTjZ.YbPMnNrMauuKoPmiSqpJmLYPYpt);
								num = 1973912593;
								continue;
							case 30:
								num2++;
								num = 1973912599;
								continue;
							default:
								{
									int index = ariivNQohqbtKfpXsKPjwtDENao.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(controllerMapEnabler_RuleSet_Editor);
									ariivNQohqbtKfpXsKPjwtDENao.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = controllerMapEnabler_RuleSet_Editor2;
									return controllerMapEnabler_RuleSet_Editor2;
								}
								IL_031f:
								num3 = num13;
								num = 1973912601;
								continue;
							}
							break;
						}
					}
				}

				public Player_Editor esOehhcnDGIqbdePfuOehnKWOzgn(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<Player_Editor> P_0)
				{
					EZazWksavffxpAmBeoOZIczCRAFX eZazWksavffxpAmBeoOZIczCRAFX = new EZazWksavffxpAmBeoOZIczCRAFX();
					GepCFWFSmMoCXhsWOzcdGUlHAcUI gepCFWFSmMoCXhsWOzcdGUlHAcUI = default(GepCFWFSmMoCXhsWOzcdGUlHAcUI);
					Player_Editor.RuleSetMapping ruleSetMapping = default(Player_Editor.RuleSetMapping);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					Player_Editor player_Editor = default(Player_Editor);
					Action<List<Player_Editor.Mapping>, List<zfpmTQonvrTjOJqbUbEUKlTCqdf>> action = default(Action<List<Player_Editor.Mapping>, List<zfpmTQonvrTjOJqbUbEUKlTCqdf>>);
					int num2 = default(int);
					Player_Editor.RuleSetMapping ruleSetMapping2 = default(Player_Editor.RuleSetMapping);
					List<Player_Editor.RuleSetMapping> ruleSets2 = default(List<Player_Editor.RuleSetMapping>);
					int num5 = default(int);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					Player_Editor player_Editor3 = default(Player_Editor);
					List<Player_Editor.RuleSetMapping> list = default(List<Player_Editor.RuleSetMapping>);
					Player_Editor player_Editor2 = default(Player_Editor);
					ofifhGIbYbVMCCtNdWwfAVIlpSWj ofifhGIbYbVMCCtNdWwfAVIlpSWj2 = default(ofifhGIbYbVMCCtNdWwfAVIlpSWj);
					int num4 = default(int);
					List<Player_Editor.RuleSetMapping> list2 = default(List<Player_Editor.RuleSetMapping>);
					List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
					Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> yiQQrhLZpnsLTpRLqbkTZoFBIrnc = default(Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int>);
					while (true)
					{
						int num = -519397984;
						while (true)
						{
							switch (num ^ -519397976)
							{
							case 4:
								break;
							case 24:
								gepCFWFSmMoCXhsWOzcdGUlHAcUI = new GepCFWFSmMoCXhsWOzcdGUlHAcUI();
								gepCFWFSmMoCXhsWOzcdGUlHAcUI.pNYLFyQwRREsqeiUPyfDafyISzs = eZazWksavffxpAmBeoOZIczCRAFX;
								num = -519397954;
								continue;
							case 25:
								ruleSetMapping = ruleSetMapping.Clone();
								ruleSetMapping.id = zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu;
								num = -519397958;
								continue;
							case 1:
								eZazWksavffxpAmBeoOZIczCRAFX.mDgcyeMwmBaMprlpQyHooOSZUWD = P_0;
								player_Editor = JsonTools.Clone(eZazWksavffxpAmBeoOZIczCRAFX.mDgcyeMwmBaMprlpQyHooOSZUWD.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
								action = eZazWksavffxpAmBeoOZIczCRAFX.XGtTnJYptYBMRwEscQGXsDvTEBF;
								num = -519397977;
								continue;
							case 21:
								num2 = 0;
								num = -519397956;
								continue;
							case 19:
							{
								nBqPJdxWpLUxJdzvoHDcDntCbaBC nBqPJdxWpLUxJdzvoHDcDntCbaBC2 = new nBqPJdxWpLUxJdzvoHDcDntCbaBC();
								nBqPJdxWpLUxJdzvoHDcDntCbaBC2.pNYLFyQwRREsqeiUPyfDafyISzs = eZazWksavffxpAmBeoOZIczCRAFX;
								nBqPJdxWpLUxJdzvoHDcDntCbaBC2.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
								ruleSetMapping2 = ruleSets2[num5];
								if (ruleSetMapping2 != null)
								{
									nBqPJdxWpLUxJdzvoHDcDntCbaBC2.fKtuodNzZLrsthNmhfemlCLUaYzG = ruleSetMapping2.id;
									zfpmTQonvrTjOJqbUbEUKlTCqdf2 = eYhzTCjKkJCfMqmOnNjyeXXxbhn.Find(nBqPJdxWpLUxJdzvoHDcDntCbaBC2.XzWZOnXcEiAQjLgCrhJDQJxKaWY);
									if (zfpmTQonvrTjOJqbUbEUKlTCqdf2 == null)
									{
										Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + nBqPJdxWpLUxJdzvoHDcDntCbaBC2.fKtuodNzZLrsthNmhfemlCLUaYzG);
										num = -519397979;
										continue;
									}
									goto case 16;
								}
								goto case 13;
							}
							case 14:
								player_Editor3 = JsonTools.Clone(player_Editor);
								player_Editor3.defaultKeyboardMaps.Clear();
								player_Editor3.defaultMouseMaps.Clear();
								player_Editor3.defaultJoystickMaps.Clear();
								player_Editor3.defaultCustomControllerMaps.Clear();
								num = -519397965;
								continue;
							case 0:
								player_Editor.controllerMapEnablerSettings.ruleSets = list;
								if (eZazWksavffxpAmBeoOZIczCRAFX.mDgcyeMwmBaMprlpQyHooOSZUWD.HMoyquearlrlOniSOfLyhtLtphI)
								{
									player_Editor2 = eZazWksavffxpAmBeoOZIczCRAFX.mDgcyeMwmBaMprlpQyHooOSZUWD.cdIchUQhXPDsawgfzLCmqpUJqyw;
									num = -519397978;
									continue;
								}
								goto case 9;
							case 12:
							{
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf4 = ngBkUCBWeNOKhqSbWSAdLHAWbwz.Find(ofifhGIbYbVMCCtNdWwfAVIlpSWj2.YqqEfhWZzfRWnOByvtLfKvcwlHx);
								ofifhGIbYbVMCCtNdWwfAVIlpSWj2.AdqDRmvMCTHHDQWIUGnRloZhdLl.sourceId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf4 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf4.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								num4++;
								num = -519397966;
								continue;
							}
							case 5:
								if (num5 >= ruleSets2.Count)
								{
									player_Editor.controllerMapLayoutManagerSettings.ruleSets = list2;
									list = new List<Player_Editor.RuleSetMapping>();
									ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
									num = -519397955;
									continue;
								}
								goto case 19;
							case 17:
								ofifhGIbYbVMCCtNdWwfAVIlpSWj2 = new ofifhGIbYbVMCCtNdWwfAVIlpSWj();
								ofifhGIbYbVMCCtNdWwfAVIlpSWj2.pNYLFyQwRREsqeiUPyfDafyISzs = eZazWksavffxpAmBeoOZIczCRAFX;
								ofifhGIbYbVMCCtNdWwfAVIlpSWj2.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
								ofifhGIbYbVMCCtNdWwfAVIlpSWj2.AdqDRmvMCTHHDQWIUGnRloZhdLl = player_Editor.startingCustomControllers[num4];
								num = -519397980;
								continue;
							case 2:
								yiQQrhLZpnsLTpRLqbkTZoFBIrnc = YiQQrhLZpnsLTpRLqbkTZoFBIrnc;
								haualFiuTyJaHUWxxENcsCamafd(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, yiQQrhLZpnsLTpRLqbkTZoFBIrnc);
								haualFiuTyJaHUWxxENcsCamafd(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, yiQQrhLZpnsLTpRLqbkTZoFBIrnc);
								num = -519397969;
								continue;
							case 6:
							{
								haualFiuTyJaHUWxxENcsCamafd(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, yiQQrhLZpnsLTpRLqbkTZoFBIrnc);
								List<Player_Editor.CreateControllerInfo> startingCustomControllers = player_Editor2.startingCustomControllers;
								List<Player_Editor.CreateControllerInfo> startingCustomControllers2 = player_Editor.startingCustomControllers;
								List<Player_Editor.CreateControllerInfo> startingCustomControllers3 = player_Editor3.startingCustomControllers;
								if (TQtuzrrPdAYqGKUnIvxyvbupcDy == null)
								{
									TQtuzrrPdAYqGKUnIvxyvbupcDy = eKqobwyLTkdnKelhtPldkiDDPrQf;
								}
								haualFiuTyJaHUWxxENcsCamafd(startingCustomControllers, startingCustomControllers2, startingCustomControllers3, TQtuzrrPdAYqGKUnIvxyvbupcDy);
								player_Editor = player_Editor3;
								num = -519397964;
								continue;
							}
							case 10:
								num2++;
								num = -519397956;
								continue;
							case 26:
								if (num4 >= player_Editor.startingCustomControllers.Count)
								{
									list2 = new List<Player_Editor.RuleSetMapping>();
									ruleSets2 = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
									num5 = 0;
									num = -519397971;
									continue;
								}
								goto case 17;
							case 16:
								ruleSetMapping2 = ruleSetMapping2.Clone();
								ruleSetMapping2.id = zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu;
								num = -519397953;
								continue;
							case 22:
								gepCFWFSmMoCXhsWOzcdGUlHAcUI.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
								num = -519397981;
								continue;
							case 23:
								list2.Add(ruleSetMapping2);
								num = -519397979;
								continue;
							case 27:
								player_Editor3.startingCustomControllers.Clear();
								if (YiQQrhLZpnsLTpRLqbkTZoFBIrnc == null)
								{
									YiQQrhLZpnsLTpRLqbkTZoFBIrnc = ZnqflJFNfIadEBxZZoiXMvlkrVxB;
									num = -519397974;
									continue;
								}
								goto case 2;
							case 11:
								ruleSetMapping = ruleSets[num2];
								if (ruleSetMapping != null)
								{
									gepCFWFSmMoCXhsWOzcdGUlHAcUI.fKtuodNzZLrsthNmhfemlCLUaYzG = ruleSetMapping.id;
									zfpmTQonvrTjOJqbUbEUKlTCqdf3 = lhLhfTleShdifyqLvIIpptrvfPx.Find(gepCFWFSmMoCXhsWOzcdGUlHAcUI.igqHKCIhjxsKFPCPChUilAUayvE);
									if (zfpmTQonvrTjOJqbUbEUKlTCqdf3 == null)
									{
										Logger.LogError("No new Controller Map Enabler Set found for old id: " + gepCFWFSmMoCXhsWOzcdGUlHAcUI.fKtuodNzZLrsthNmhfemlCLUaYzG);
										num = -519397982;
										continue;
									}
									goto case 25;
								}
								goto case 10;
							case 29:
								player_Editor2 = eZazWksavffxpAmBeoOZIczCRAFX.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[eZazWksavffxpAmBeoOZIczCRAFX.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
								num = -519397973;
								continue;
							case 28:
								num = -519397973;
								continue;
							case 8:
								eZazWksavffxpAmBeoOZIczCRAFX.qTClCWNuYDhqHNJDcYUkEPyLewR = this;
								num = -519397975;
								continue;
							case 15:
								action(player_Editor.defaultKeyboardMaps, yGJqdfzJeMLTtAxqpValuiuofppC);
								action(player_Editor.defaultMouseMaps, yRyutBWetYAlfEiaLMyLYTUmXtH);
								action(player_Editor.defaultJoystickMaps, YQRpSchsUChQpULokGiufHFJzNxR);
								action(player_Editor.defaultCustomControllerMaps, BOWQgrgKHSYLhBKpcbkmdTZAKYpe);
								num4 = 0;
								num = -519397966;
								continue;
							case 20:
							{
								int num3;
								if (num2 < ruleSets.Count)
								{
									num = -519397968;
									num3 = num;
								}
								else
								{
									num = -519397976;
									num3 = num;
								}
								continue;
							}
							case 13:
								num5++;
								num = -519397971;
								continue;
							case 9:
								gQKGqRzPUnrelmbksZbFXmMbfQEk.AddPlayer();
								num = -519397963;
								continue;
							case 18:
								list.Add(ruleSetMapping);
								num = -519397982;
								continue;
							case 7:
								haualFiuTyJaHUWxxENcsCamafd(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, yiQQrhLZpnsLTpRLqbkTZoFBIrnc);
								num = -519397970;
								continue;
							default:
							{
								player_Editor.id = player_Editor2.id;
								int index = eZazWksavffxpAmBeoOZIczCRAFX.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(player_Editor2);
								eZazWksavffxpAmBeoOZIczCRAFX.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = player_Editor;
								return player_Editor;
							}
							}
							break;
						}
					}
				}

				private static int ZnqflJFNfIadEBxZZoiXMvlkrVxB(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							int num2;
							if (P_1[num].categoryId == P_0.categoryId)
							{
								num2 = -2018716103;
								goto IL_0009;
							}
							goto IL_0057;
							IL_0041:
							if (P_1[num].layoutId == P_0.layoutId)
							{
								return num;
							}
							goto IL_0057;
							IL_0057:
							num++;
							num2 = -2018716104;
							goto IL_0009;
							IL_0009:
							while (true)
							{
								switch (num2 ^ -2018716104)
								{
								case 3:
									num2 = -2018716102;
									continue;
								case 2:
									break;
								case 1:
									goto IL_0041;
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

				private static int eKqobwyLTkdnKelhtPldkiDDPrQf(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							int num2;
							if (P_1[num].sourceId == P_0.sourceId)
							{
								num2 = 627489045;
							}
							else
							{
								num++;
								num2 = 627489044;
							}
							while (true)
							{
								switch (num2 ^ 0x2566B917)
								{
								case 0:
									num2 = 627489046;
									continue;
								case 1:
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
			}

			private sealed class afoiGKdxXheWQGCGMQfnxoyKLeli
			{
				public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

				public List<int> DbvSyQPIqRBKowskMKFfMNbYJNw;

				public InputMapCategory jhXGQuZllOcCMGfWYFRieVwlLjc(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
					InputMapCategory inputMapCategory2;
					if (P_0.HMoyquearlrlOniSOfLyhtLtphI)
					{
						inputMapCategory2 = P_0.cdIchUQhXPDsawgfzLCmqpUJqyw;
						goto IL_0063;
					}
					goto IL_008c;
					IL_0043:
					inputMapCategory.id = inputMapCategory2.id;
					int num = default(int);
					P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[num] = inputMapCategory;
					int num2 = 1844840081;
					goto IL_0022;
					IL_0063:
					num = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(inputMapCategory2);
					if (P_0.vGEummKjgDcSUGooGPOJfEZgtJrm == zfpmTQonvrTjOJqbUbEUKlTCqdf.WShhClxzwcSZIyaMxWChyIpnurx.RCOauDZdeEvGkaCTeYBvkrIMFQK)
					{
						DbvSyQPIqRBKowskMKFfMNbYJNw.Add(num);
						num2 = 1844840083;
						goto IL_0022;
					}
					goto IL_0043;
					IL_008c:
					qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.AddMapCategory();
					inputMapCategory2 = P_0.KgBiervgcFPhSNIBLZDZhOHKfLN[P_0.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
					num2 = 1844840082;
					goto IL_0022;
					IL_0022:
					while (true)
					{
						switch (num2 ^ 0x6DF60692)
						{
						case 2:
							num2 = 1844840086;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0063;
						case 4:
							goto IL_008c;
						default:
							return inputMapCategory;
						}
						break;
					}
					goto IL_0043;
				}
			}

			private sealed class FGjWdsaAqkgtOnAXPhxbcJvllHp
			{
				public afoiGKdxXheWQGCGMQfnxoyKLeli YftpkbTrbMJWZcyPUcPnsMsQlpV;

				public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

				public int RCOauDZdeEvGkaCTeYBvkrIMFQK;

				public bool HbHYvLVxWJbahjSBJPShvpBahhe(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
				{
					return P_0.RCOauDZdeEvGkaCTeYBvkrIMFQK == RCOauDZdeEvGkaCTeYBvkrIMFQK;
				}
			}

			private sealed class zWShRbrSkbmQIxclFKiflhhdxUr
			{
				private sealed class xlqRjnGuoCdJhOKpEZmPeoKDoxb
				{
					public zWShRbrSkbmQIxclFKiflhhdxUr mcGHGTGKEUUyTkEctAMwMitNmUCd;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ControllerMap_Editor AdqDRmvMCTHHDQWIUGnRloZhdLl;

					public bool oclDUqlANvuBdkkCvtCZpZumUzj(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0.RCOauDZdeEvGkaCTeYBvkrIMFQK == AdqDRmvMCTHHDQWIUGnRloZhdLl.categoryId;
					}

					public bool AIMApbdiZJYZhOkTiaImOSntlQZ(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0.RCOauDZdeEvGkaCTeYBvkrIMFQK == AdqDRmvMCTHHDQWIUGnRloZhdLl.layoutId;
					}
				}

				private sealed class EAjiCVYjGndHlBpbcgYnQiDrzoIA
				{
					public zWShRbrSkbmQIxclFKiflhhdxUr mcGHGTGKEUUyTkEctAMwMitNmUCd;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ControllerMap_Editor hblKmXrIybUsjuWnbrpAiWaScrm;

					public lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMap_Editor> mDgcyeMwmBaMprlpQyHooOSZUWD;

					public bool lnoUugwjEtvgkWLphDpczocFYfh(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == hblKmXrIybUsjuWnbrpAiWaScrm.categoryId;
					}

					public bool RUTDZphUFpKDoZRslnhBQKHWlqp(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == hblKmXrIybUsjuWnbrpAiWaScrm.layoutId;
					}
				}

				private sealed class AvPufQFqcGJDkFotEcHVuSrTwmL
				{
					public EAjiCVYjGndHlBpbcgYnQiDrzoIA cFbKbTvNcGJxAacSEalXbolNmIi;

					public zWShRbrSkbmQIxclFKiflhhdxUr mcGHGTGKEUUyTkEctAMwMitNmUCd;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ActionElementMap wWIAVQYLtUqmWRBSPcIMZSWLBQsG;

					public bool aiSGyvMeFGFgqAOgWAPmqmrfzUpo(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[cFbKbTvNcGJxAacSEalXbolNmIi.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId;
					}
				}

				public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> IdHoIiVveVBwBKBeWrsEdYqfsYz;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> czksdtEezzPCzziJxEFSLwkVBYA;

				public int ZIvfCqqylYjslezoewiqRHSpMcF(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					xlqRjnGuoCdJhOKpEZmPeoKDoxb xlqRjnGuoCdJhOKpEZmPeoKDoxb2 = new xlqRjnGuoCdJhOKpEZmPeoKDoxb();
					xlqRjnGuoCdJhOKpEZmPeoKDoxb2.mcGHGTGKEUUyTkEctAMwMitNmUCd = this;
					int num2 = default(int);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					while (true)
					{
						int num = -286232040;
						while (true)
						{
							switch (num ^ -286232038)
							{
							case 4:
								break;
							case 2:
								xlqRjnGuoCdJhOKpEZmPeoKDoxb2.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
								xlqRjnGuoCdJhOKpEZmPeoKDoxb2.AdqDRmvMCTHHDQWIUGnRloZhdLl = P_0;
								num2 = 0;
								num = -286232038;
								continue;
							case 5:
								zfpmTQonvrTjOJqbUbEUKlTCqdf3 = IdHoIiVveVBwBKBeWrsEdYqfsYz.Find(xlqRjnGuoCdJhOKpEZmPeoKDoxb2.AIMApbdiZJYZhOkTiaImOSntlQZ);
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null)
								{
									num = -286232039;
									continue;
								}
								goto IL_00f2;
							case 3:
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu == P_1[num2].categoryId && zfpmTQonvrTjOJqbUbEUKlTCqdf3 != null)
								{
									num = -286232036;
									continue;
								}
								goto IL_00f2;
							case 1:
								zfpmTQonvrTjOJqbUbEUKlTCqdf2 = qTClCWNuYDhqHNJDcYUkEPyLewR.SclSkjgPLpFngbZoISugthSGOur.Find(xlqRjnGuoCdJhOKpEZmPeoKDoxb2.oclDUqlANvuBdkkCvtCZpZumUzj);
								num = -286232033;
								continue;
							case 6:
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu == P_1[num2].layoutId)
								{
									return num2;
								}
								goto IL_00f2;
							default:
								{
									if (num2 >= P_1.Count)
									{
										return -1;
									}
									goto case 1;
								}
								IL_00f2:
								num2++;
								num = -286232038;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor skumdQpneDIJVVdncfRdctYAjNME(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMap_Editor> P_0)
				{
					EAjiCVYjGndHlBpbcgYnQiDrzoIA eAjiCVYjGndHlBpbcgYnQiDrzoIA = new EAjiCVYjGndHlBpbcgYnQiDrzoIA();
					AvPufQFqcGJDkFotEcHVuSrTwmL avPufQFqcGJDkFotEcHVuSrTwmL = default(AvPufQFqcGJDkFotEcHVuSrTwmL);
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					int num2 = default(int);
					int index = default(int);
					while (true)
					{
						int num = -335592169;
						while (true)
						{
							switch (num ^ -335592165)
							{
							case 17:
								break;
							case 11:
								avPufQFqcGJDkFotEcHVuSrTwmL.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
								num = -335592172;
								continue;
							case 8:
								avPufQFqcGJDkFotEcHVuSrTwmL = new AvPufQFqcGJDkFotEcHVuSrTwmL();
								avPufQFqcGJDkFotEcHVuSrTwmL.cFbKbTvNcGJxAacSEalXbolNmIi = eAjiCVYjGndHlBpbcgYnQiDrzoIA;
								avPufQFqcGJDkFotEcHVuSrTwmL.mcGHGTGKEUUyTkEctAMwMitNmUCd = this;
								num = -335592176;
								continue;
							case 1:
							{
								Func<ActionElementMap, IList<ActionElementMap>, int> func = czksdtEezzPCzziJxEFSLwkVBYA;
								haualFiuTyJaHUWxxENcsCamafd(controllerMap_Editor.actionElementMaps, eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
								num = -335592162;
								continue;
							}
							case 2:
								eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm = JsonTools.Clone(eAjiCVYjGndHlBpbcgYnQiDrzoIA.mDgcyeMwmBaMprlpQyHooOSZUWD.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
								num = -335592168;
								continue;
							case 15:
								avPufQFqcGJDkFotEcHVuSrTwmL.wWIAVQYLtUqmWRBSPcIMZSWLBQsG = eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps[num2];
								num = -335592171;
								continue;
							case 3:
							{
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = qTClCWNuYDhqHNJDcYUkEPyLewR.SclSkjgPLpFngbZoISugthSGOur.Find(eAjiCVYjGndHlBpbcgYnQiDrzoIA.lnoUugwjEtvgkWLphDpczocFYfh);
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf4 = IdHoIiVveVBwBKBeWrsEdYqfsYz.Find(eAjiCVYjGndHlBpbcgYnQiDrzoIA.RUTDZphUFpKDoZRslnhBQKHWlqp);
								eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm.categoryId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf3 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm.layoutId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf4 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf4.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								num2 = 0;
								num = -335592163;
								continue;
							}
							case 6:
								num = -335592174;
								continue;
							case 10:
								avPufQFqcGJDkFotEcHVuSrTwmL.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionCategoryId = ((qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.GetActionById(avPufQFqcGJDkFotEcHVuSrTwmL.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId) != null) ? qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.GetActionById(avPufQFqcGJDkFotEcHVuSrTwmL.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId).categoryId : 0);
								num2++;
								num = -335592174;
								continue;
							case 5:
								eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm = controllerMap_Editor2;
								num = -335592164;
								continue;
							case 0:
							{
								int num4;
								if (!eAjiCVYjGndHlBpbcgYnQiDrzoIA.mDgcyeMwmBaMprlpQyHooOSZUWD.HMoyquearlrlOniSOfLyhtLtphI)
								{
									num = -335592161;
									num4 = num;
								}
								else
								{
									num = -335592170;
									num4 = num;
								}
								continue;
							}
							case 4:
								qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.CreateKeyboardMap(eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm.categoryId, eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm.layoutId);
								controllerMap_Editor = eAjiCVYjGndHlBpbcgYnQiDrzoIA.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[eAjiCVYjGndHlBpbcgYnQiDrzoIA.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
								num = -335592164;
								continue;
							case 12:
								eAjiCVYjGndHlBpbcgYnQiDrzoIA.mcGHGTGKEUUyTkEctAMwMitNmUCd = this;
								eAjiCVYjGndHlBpbcgYnQiDrzoIA.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
								eAjiCVYjGndHlBpbcgYnQiDrzoIA.mDgcyeMwmBaMprlpQyHooOSZUWD = P_0;
								num = -335592167;
								continue;
							case 14:
							{
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = qTClCWNuYDhqHNJDcYUkEPyLewR.bApneWqkxJjGSMSoHKhCVlqWasMG.Find(avPufQFqcGJDkFotEcHVuSrTwmL.aiSGyvMeFGFgqAOgWAPmqmrfzUpo);
								avPufQFqcGJDkFotEcHVuSrTwmL.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								num = -335592175;
								continue;
							}
							case 9:
							{
								int num3;
								if (num2 >= eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps.Count)
								{
									num = -335592165;
									num3 = num;
								}
								else
								{
									num = -335592173;
									num3 = num;
								}
								continue;
							}
							case 7:
								eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm.id = controllerMap_Editor.id;
								index = eAjiCVYjGndHlBpbcgYnQiDrzoIA.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(controllerMap_Editor);
								num = -335592181;
								continue;
							case 13:
								controllerMap_Editor = eAjiCVYjGndHlBpbcgYnQiDrzoIA.mDgcyeMwmBaMprlpQyHooOSZUWD.cdIchUQhXPDsawgfzLCmqpUJqyw;
								controllerMap_Editor2 = JsonTools.Clone(eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm);
								controllerMap_Editor2.actionElementMaps.Clear();
								if (czksdtEezzPCzziJxEFSLwkVBYA == null)
								{
									czksdtEezzPCzziJxEFSLwkVBYA = SlKixVVBeefizAVjgBubwHpOyWZ;
									num = -335592166;
									continue;
								}
								goto case 1;
							default:
								eAjiCVYjGndHlBpbcgYnQiDrzoIA.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm;
								return eAjiCVYjGndHlBpbcgYnQiDrzoIA.hblKmXrIybUsjuWnbrpAiWaScrm;
							}
							break;
						}
					}
				}

				private static int SlKixVVBeefizAVjgBubwHpOyWZ(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (true)
					{
						int num2 = 1694803655;
						while (true)
						{
							switch (num2 ^ 0x6504A6C2)
							{
							case 0:
								break;
							case 5:
								num2 = 1694803648;
								continue;
							case 6:
								if (P_1[num]._modifierKey2 == P_0._modifierKey2)
								{
									num2 = 1694803654;
									continue;
								}
								goto IL_00cc;
							case 1:
								if (P_1[num]._modifierKey1 == P_0._modifierKey1)
								{
									num2 = 1694803652;
									continue;
								}
								goto IL_00cc;
							case 3:
								if (P_1[num]._keyboardKeyCode == P_0._keyboardKeyCode)
								{
									num2 = 1694803651;
									continue;
								}
								goto IL_00cc;
							case 4:
								if (P_1[num]._modifierKey3 == P_0._modifierKey3 && P_1[num]._axisContribution == P_0._axisContribution && P_1[num]._actionId == P_0._actionId)
								{
									return num;
								}
								goto IL_00cc;
							default:
								{
									if (num >= P_1.Count)
									{
										return -1;
									}
									goto case 3;
								}
								IL_00cc:
								num++;
								num2 = 1694803648;
								continue;
							}
							break;
						}
					}
				}
			}

			private sealed class HPAWTbPzBkUuUBbtLSSJiKxfKQ
			{
				private sealed class GZPJnVsfXuFraJPPRQhdAUYuYOL
				{
					public HPAWTbPzBkUuUBbtLSSJiKxfKQ YOdfDZiXcrolgpKpvxTHRMgCstAd;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ControllerMap_Editor AdqDRmvMCTHHDQWIUGnRloZhdLl;

					public bool oaTslagDyUZPVywzMIxDLaEIAnyk(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0.RCOauDZdeEvGkaCTeYBvkrIMFQK == AdqDRmvMCTHHDQWIUGnRloZhdLl.categoryId;
					}

					public bool dSsqnIUDdqdqvJsLHmgTVaXpsnqg(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0.RCOauDZdeEvGkaCTeYBvkrIMFQK == AdqDRmvMCTHHDQWIUGnRloZhdLl.layoutId;
					}
				}

				private sealed class LaBrSQUgBQboAGYojwagQhqIyIW
				{
					public HPAWTbPzBkUuUBbtLSSJiKxfKQ YOdfDZiXcrolgpKpvxTHRMgCstAd;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ControllerMap_Editor hblKmXrIybUsjuWnbrpAiWaScrm;

					public lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMap_Editor> mDgcyeMwmBaMprlpQyHooOSZUWD;

					public bool uUTgWddEBpafAjUrDPsalwKFvNaF(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == hblKmXrIybUsjuWnbrpAiWaScrm.categoryId;
					}

					public bool hTGuCKESlEPiajvFLLCUkDlAPPO(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == hblKmXrIybUsjuWnbrpAiWaScrm.layoutId;
					}
				}

				private sealed class pPPTYSKvsGWpGotsshROgEnwEnB
				{
					public LaBrSQUgBQboAGYojwagQhqIyIW GhzOckMGJTSuROFchCtcbUflkSx;

					public HPAWTbPzBkUuUBbtLSSJiKxfKQ YOdfDZiXcrolgpKpvxTHRMgCstAd;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ActionElementMap wWIAVQYLtUqmWRBSPcIMZSWLBQsG;

					public bool kUwvLhFpgqVDtfkzmoGmYHAuCfl(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[GhzOckMGJTSuROFchCtcbUflkSx.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId;
					}
				}

				public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> IdHoIiVveVBwBKBeWrsEdYqfsYz;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> IUbBEraWSRkpPZAfciaLUCWyJLl;

				public int NJNruLpxbyjqQzecoltgCiDezow(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					GZPJnVsfXuFraJPPRQhdAUYuYOL gZPJnVsfXuFraJPPRQhdAUYuYOL = default(GZPJnVsfXuFraJPPRQhdAUYuYOL);
					int num2 = default(int);
					Predicate<zfpmTQonvrTjOJqbUbEUKlTCqdf> predicate = default(Predicate<zfpmTQonvrTjOJqbUbEUKlTCqdf>);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					while (true)
					{
						int num = 78055747;
						while (true)
						{
							switch (num ^ 0x4A70946)
							{
							case 6:
								break;
							case 1:
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null)
								{
									num = 78055746;
									continue;
								}
								goto IL_00f5;
							case 3:
								gZPJnVsfXuFraJPPRQhdAUYuYOL = new GZPJnVsfXuFraJPPRQhdAUYuYOL();
								gZPJnVsfXuFraJPPRQhdAUYuYOL.YOdfDZiXcrolgpKpvxTHRMgCstAd = this;
								gZPJnVsfXuFraJPPRQhdAUYuYOL.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
								gZPJnVsfXuFraJPPRQhdAUYuYOL.AdqDRmvMCTHHDQWIUGnRloZhdLl = P_0;
								num2 = 0;
								num = 78055748;
								continue;
							case 0:
							{
								zfpmTQonvrTjOJqbUbEUKlTCqdf2 = qTClCWNuYDhqHNJDcYUkEPyLewR.SclSkjgPLpFngbZoISugthSGOur.Find(gZPJnVsfXuFraJPPRQhdAUYuYOL.oaTslagDyUZPVywzMIxDLaEIAnyk);
								List<zfpmTQonvrTjOJqbUbEUKlTCqdf> idHoIiVveVBwBKBeWrsEdYqfsYz = IdHoIiVveVBwBKBeWrsEdYqfsYz;
								if (predicate == null)
								{
									predicate = gZPJnVsfXuFraJPPRQhdAUYuYOL.dSsqnIUDdqdqvJsLHmgTVaXpsnqg;
								}
								zfpmTQonvrTjOJqbUbEUKlTCqdf3 = idHoIiVveVBwBKBeWrsEdYqfsYz.Find(predicate);
								num = 78055751;
								continue;
							}
							case 5:
								predicate = null;
								num = 78055749;
								continue;
							case 4:
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu == P_1[num2].categoryId && zfpmTQonvrTjOJqbUbEUKlTCqdf3 != null && zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu == P_1[num2].layoutId)
								{
									return num2;
								}
								goto IL_00f5;
							default:
								{
									if (num2 >= P_1.Count)
									{
										return -1;
									}
									goto case 0;
								}
								IL_00f5:
								num2++;
								num = 78055748;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor NcEHOhSXKccVqlHhiyjsfjhuzRg(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMap_Editor> P_0)
				{
					LaBrSQUgBQboAGYojwagQhqIyIW laBrSQUgBQboAGYojwagQhqIyIW = new LaBrSQUgBQboAGYojwagQhqIyIW();
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					int num2 = default(int);
					pPPTYSKvsGWpGotsshROgEnwEnB pPPTYSKvsGWpGotsshROgEnwEnB2 = default(pPPTYSKvsGWpGotsshROgEnwEnB);
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					while (true)
					{
						int num = 1534603390;
						while (true)
						{
							switch (num ^ 0x5B78307C)
							{
							case 6:
								break;
							case 2:
								laBrSQUgBQboAGYojwagQhqIyIW.YOdfDZiXcrolgpKpvxTHRMgCstAd = this;
								num = 1534603389;
								continue;
							case 1:
								laBrSQUgBQboAGYojwagQhqIyIW.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
								laBrSQUgBQboAGYojwagQhqIyIW.mDgcyeMwmBaMprlpQyHooOSZUWD = P_0;
								laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm = JsonTools.Clone(laBrSQUgBQboAGYojwagQhqIyIW.mDgcyeMwmBaMprlpQyHooOSZUWD.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
								num = 1534603381;
								continue;
							case 13:
								controllerMap_Editor = laBrSQUgBQboAGYojwagQhqIyIW.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[laBrSQUgBQboAGYojwagQhqIyIW.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
								num = 1534603384;
								continue;
							case 9:
							{
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = qTClCWNuYDhqHNJDcYUkEPyLewR.SclSkjgPLpFngbZoISugthSGOur.Find(laBrSQUgBQboAGYojwagQhqIyIW.uUTgWddEBpafAjUrDPsalwKFvNaF);
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf4 = IdHoIiVveVBwBKBeWrsEdYqfsYz.Find(laBrSQUgBQboAGYojwagQhqIyIW.hTGuCKESlEPiajvFLLCUkDlAPPO);
								laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm.categoryId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf3 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm.layoutId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf4 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf4.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								num2 = 0;
								num = 1534603380;
								continue;
							}
							case 0:
							{
								pPPTYSKvsGWpGotsshROgEnwEnB2 = new pPPTYSKvsGWpGotsshROgEnwEnB();
								pPPTYSKvsGWpGotsshROgEnwEnB2.GhzOckMGJTSuROFchCtcbUflkSx = laBrSQUgBQboAGYojwagQhqIyIW;
								pPPTYSKvsGWpGotsshROgEnwEnB2.YOdfDZiXcrolgpKpvxTHRMgCstAd = this;
								pPPTYSKvsGWpGotsshROgEnwEnB2.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
								pPPTYSKvsGWpGotsshROgEnwEnB2.wWIAVQYLtUqmWRBSPcIMZSWLBQsG = laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps[num2];
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = qTClCWNuYDhqHNJDcYUkEPyLewR.bApneWqkxJjGSMSoHKhCVlqWasMG.Find(pPPTYSKvsGWpGotsshROgEnwEnB2.kUwvLhFpgqVDtfkzmoGmYHAuCfl);
								pPPTYSKvsGWpGotsshROgEnwEnB2.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								num = 1534603385;
								continue;
							}
							case 4:
							{
								laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm.id = controllerMap_Editor.id;
								int index = laBrSQUgBQboAGYojwagQhqIyIW.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(controllerMap_Editor);
								laBrSQUgBQboAGYojwagQhqIyIW.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm;
								num = 1534603382;
								continue;
							}
							case 8:
							{
								int num3;
								if (num2 >= laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps.Count)
								{
									num = 1534603391;
									num3 = num;
								}
								else
								{
									num = 1534603388;
									num3 = num;
								}
								continue;
							}
							case 3:
								if (laBrSQUgBQboAGYojwagQhqIyIW.mDgcyeMwmBaMprlpQyHooOSZUWD.HMoyquearlrlOniSOfLyhtLtphI)
								{
									controllerMap_Editor = laBrSQUgBQboAGYojwagQhqIyIW.mDgcyeMwmBaMprlpQyHooOSZUWD.cdIchUQhXPDsawgfzLCmqpUJqyw;
									num = 1534603387;
									continue;
								}
								goto case 11;
							case 7:
								controllerMap_Editor2 = JsonTools.Clone(laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm);
								controllerMap_Editor2.actionElementMaps.Clear();
								if (IUbBEraWSRkpPZAfciaLUCWyJLl == null)
								{
									IUbBEraWSRkpPZAfciaLUCWyJLl = ROVqaPOUzVoHrMJDgbJjEHnsKUu;
									num = 1534603376;
									continue;
								}
								goto case 12;
							case 11:
								qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.CreateMouseMap(laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm.categoryId, laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm.layoutId);
								num = 1534603377;
								continue;
							case 5:
								pPPTYSKvsGWpGotsshROgEnwEnB2.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionCategoryId = ((qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.GetActionById(pPPTYSKvsGWpGotsshROgEnwEnB2.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId) != null) ? qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.GetActionById(pPPTYSKvsGWpGotsshROgEnwEnB2.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId).categoryId : 0);
								num2++;
								num = 1534603380;
								continue;
							case 12:
							{
								Func<ActionElementMap, IList<ActionElementMap>, int> iUbBEraWSRkpPZAfciaLUCWyJLl = IUbBEraWSRkpPZAfciaLUCWyJLl;
								haualFiuTyJaHUWxxENcsCamafd(controllerMap_Editor.actionElementMaps, laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps, controllerMap_Editor2.actionElementMaps, iUbBEraWSRkpPZAfciaLUCWyJLl);
								laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm = controllerMap_Editor2;
								num = 1534603384;
								continue;
							}
							default:
								return laBrSQUgBQboAGYojwagQhqIyIW.hblKmXrIybUsjuWnbrpAiWaScrm;
							}
							break;
						}
					}
				}

				private static int ROVqaPOUzVoHrMJDgbJjEHnsKUu(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							int num2;
							if (P_1[num]._elementIdentifierId == P_0._elementIdentifierId && P_1[num]._axisRange == P_0._axisRange)
							{
								num2 = -1433166945;
								goto IL_000c;
							}
							goto IL_005e;
							IL_005e:
							num++;
							num2 = -1433166947;
							goto IL_000c;
							IL_000c:
							while (true)
							{
								switch (num2 ^ -1433166946)
								{
								case 0:
									num2 = -1433166950;
									continue;
								case 4:
									break;
								case 2:
									return num;
								case 1:
									goto IL_0069;
								default:
									goto end_IL_002d;
								}
								break;
								IL_0069:
								if (P_1[num]._axisContribution == P_0._axisContribution && P_1[num]._actionId == P_0._actionId)
								{
									num2 = -1433166948;
									continue;
								}
								goto IL_005e;
							}
							continue;
							end_IL_002d:
							break;
						}
					}
					return -1;
				}
			}

			private sealed class nRBGkhBBaHBoAnjPKyonFzHpLwc
			{
				private sealed class CZZzpzjLIremqcGRIsHIdQTkxYb
				{
					public nRBGkhBBaHBoAnjPKyonFzHpLwc vrNPwvajYAboovWlCtHmNACdPuZ;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ControllerMap_Editor AdqDRmvMCTHHDQWIUGnRloZhdLl;

					public bool VCTJTQdyldWGNdhlAQnijHomjPfd(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0.RCOauDZdeEvGkaCTeYBvkrIMFQK == AdqDRmvMCTHHDQWIUGnRloZhdLl.categoryId;
					}

					public bool tmKnAyBDPqOWIckkMZjqyfRykRx(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0.RCOauDZdeEvGkaCTeYBvkrIMFQK == AdqDRmvMCTHHDQWIUGnRloZhdLl.layoutId;
					}
				}

				private sealed class NidbapiqcmHkXHMaeaVIDlMVqAC
				{
					public nRBGkhBBaHBoAnjPKyonFzHpLwc vrNPwvajYAboovWlCtHmNACdPuZ;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ControllerMap_Editor hblKmXrIybUsjuWnbrpAiWaScrm;

					public lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMap_Editor> mDgcyeMwmBaMprlpQyHooOSZUWD;

					public bool oOQdWammRzfLCxKEvOijeJZSzzJ(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == hblKmXrIybUsjuWnbrpAiWaScrm.categoryId;
					}

					public bool JHjGotHBgrceAVNdJyyvdXHNjDW(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == hblKmXrIybUsjuWnbrpAiWaScrm.layoutId;
					}
				}

				private sealed class PqGzikwajwwOAkJmMoVWxEoEBdK
				{
					public NidbapiqcmHkXHMaeaVIDlMVqAC gkaIImjLxphBSjEJWRwoxMvWHMV;

					public nRBGkhBBaHBoAnjPKyonFzHpLwc vrNPwvajYAboovWlCtHmNACdPuZ;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ActionElementMap wWIAVQYLtUqmWRBSPcIMZSWLBQsG;

					public bool WQhlgtxRSDeGUqEbmZeGWdElAgl(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[gkaIImjLxphBSjEJWRwoxMvWHMV.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId;
					}
				}

				public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> IdHoIiVveVBwBKBeWrsEdYqfsYz;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> BmJdVoieIGENacrTolZXsSZCDhis;

				public int HPMAZpHkrvKJDPwNkOusGrVNbCK(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					CZZzpzjLIremqcGRIsHIdQTkxYb cZZzpzjLIremqcGRIsHIdQTkxYb = new CZZzpzjLIremqcGRIsHIdQTkxYb();
					cZZzpzjLIremqcGRIsHIdQTkxYb.vrNPwvajYAboovWlCtHmNACdPuZ = this;
					cZZzpzjLIremqcGRIsHIdQTkxYb.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
					cZZzpzjLIremqcGRIsHIdQTkxYb.AdqDRmvMCTHHDQWIUGnRloZhdLl = P_0;
					int num2 = default(int);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					while (true)
					{
						int num = 2016671804;
						while (true)
						{
							switch (num ^ 0x7833F83D)
							{
							case 3:
								break;
							case 1:
								num2 = 0;
								num = 2016671803;
								continue;
							case 4:
								if (cZZzpzjLIremqcGRIsHIdQTkxYb.AdqDRmvMCTHHDQWIUGnRloZhdLl.hardwareGuid == P_1[num2].hardwareGuid && zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null)
								{
									num = 2016671805;
									continue;
								}
								goto IL_0117;
							case 2:
								zfpmTQonvrTjOJqbUbEUKlTCqdf2 = qTClCWNuYDhqHNJDcYUkEPyLewR.SclSkjgPLpFngbZoISugthSGOur.Find(cZZzpzjLIremqcGRIsHIdQTkxYb.VCTJTQdyldWGNdhlAQnijHomjPfd);
								zfpmTQonvrTjOJqbUbEUKlTCqdf3 = IdHoIiVveVBwBKBeWrsEdYqfsYz.Find(cZZzpzjLIremqcGRIsHIdQTkxYb.tmKnAyBDPqOWIckkMZjqyfRykRx);
								num = 2016671801;
								continue;
							case 0:
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu == P_1[num2].categoryId && zfpmTQonvrTjOJqbUbEUKlTCqdf3 != null && zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu == P_1[num2].layoutId)
								{
									num = 2016671800;
									continue;
								}
								goto IL_0117;
							case 5:
								return num2;
							default:
								{
									if (num2 >= P_1.Count)
									{
										return -1;
									}
									goto case 2;
								}
								IL_0117:
								num2++;
								num = 2016671803;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor FwoiXqiDnVgAauhmFqelLSasWkb(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMap_Editor> P_0)
				{
					NidbapiqcmHkXHMaeaVIDlMVqAC nidbapiqcmHkXHMaeaVIDlMVqAC = new NidbapiqcmHkXHMaeaVIDlMVqAC();
					nidbapiqcmHkXHMaeaVIDlMVqAC.vrNPwvajYAboovWlCtHmNACdPuZ = this;
					nidbapiqcmHkXHMaeaVIDlMVqAC.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
					nidbapiqcmHkXHMaeaVIDlMVqAC.mDgcyeMwmBaMprlpQyHooOSZUWD = P_0;
					int num2 = default(int);
					Func<ActionElementMap, IList<ActionElementMap>, int> bmJdVoieIGENacrTolZXsSZCDhis = default(Func<ActionElementMap, IList<ActionElementMap>, int>);
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					while (true)
					{
						int num = 1762310956;
						while (true)
						{
							switch (num ^ 0x690ABB2A)
							{
							case 11:
								break;
							case 6:
							{
								nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm = JsonTools.Clone(nidbapiqcmHkXHMaeaVIDlMVqAC.mDgcyeMwmBaMprlpQyHooOSZUWD.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = qTClCWNuYDhqHNJDcYUkEPyLewR.SclSkjgPLpFngbZoISugthSGOur.Find(nidbapiqcmHkXHMaeaVIDlMVqAC.oOQdWammRzfLCxKEvOijeJZSzzJ);
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf4 = IdHoIiVveVBwBKBeWrsEdYqfsYz.Find(nidbapiqcmHkXHMaeaVIDlMVqAC.JHjGotHBgrceAVNdJyyvdXHNjDW);
								nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm.categoryId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf3 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm.layoutId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf4 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf4.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								num2 = 0;
								num = 1762310944;
								continue;
							}
							case 10:
							{
								int num3;
								if (num2 < nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps.Count)
								{
									num = 1762310954;
									num3 = num;
								}
								else
								{
									num = 1762310946;
									num3 = num;
								}
								continue;
							}
							case 4:
								num2++;
								num = 1762310944;
								continue;
							case 2:
								bmJdVoieIGENacrTolZXsSZCDhis = BmJdVoieIGENacrTolZXsSZCDhis;
								num = 1762310951;
								continue;
							case 8:
								if (nidbapiqcmHkXHMaeaVIDlMVqAC.mDgcyeMwmBaMprlpQyHooOSZUWD.HMoyquearlrlOniSOfLyhtLtphI)
								{
									controllerMap_Editor2 = nidbapiqcmHkXHMaeaVIDlMVqAC.mDgcyeMwmBaMprlpQyHooOSZUWD.cdIchUQhXPDsawgfzLCmqpUJqyw;
									num = 1762310953;
									continue;
								}
								goto case 5;
							case 0:
							{
								PqGzikwajwwOAkJmMoVWxEoEBdK pqGzikwajwwOAkJmMoVWxEoEBdK = new PqGzikwajwwOAkJmMoVWxEoEBdK();
								pqGzikwajwwOAkJmMoVWxEoEBdK.gkaIImjLxphBSjEJWRwoxMvWHMV = nidbapiqcmHkXHMaeaVIDlMVqAC;
								pqGzikwajwwOAkJmMoVWxEoEBdK.vrNPwvajYAboovWlCtHmNACdPuZ = this;
								pqGzikwajwwOAkJmMoVWxEoEBdK.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
								pqGzikwajwwOAkJmMoVWxEoEBdK.wWIAVQYLtUqmWRBSPcIMZSWLBQsG = nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps[num2];
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = qTClCWNuYDhqHNJDcYUkEPyLewR.bApneWqkxJjGSMSoHKhCVlqWasMG.Find(pqGzikwajwwOAkJmMoVWxEoEBdK.WQhlgtxRSDeGUqEbmZeGWdElAgl);
								pqGzikwajwwOAkJmMoVWxEoEBdK.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								pqGzikwajwwOAkJmMoVWxEoEBdK.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionCategoryId = ((qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.GetActionById(pqGzikwajwwOAkJmMoVWxEoEBdK.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId) != null) ? qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.GetActionById(pqGzikwajwwOAkJmMoVWxEoEBdK.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId).categoryId : 0);
								num = 1762310958;
								continue;
							}
							case 14:
							{
								nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm.id = controllerMap_Editor2.id;
								int index = nidbapiqcmHkXHMaeaVIDlMVqAC.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(controllerMap_Editor2);
								nidbapiqcmHkXHMaeaVIDlMVqAC.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm;
								num = 1762310950;
								continue;
							}
							case 5:
								qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.CreateJoystickMap(nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm.categoryId, nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm.hardwareGuid, nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm.layoutId);
								num = 1762310947;
								continue;
							case 7:
								nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm = controllerMap_Editor;
								num = 1762310955;
								continue;
							case 13:
								haualFiuTyJaHUWxxENcsCamafd(controllerMap_Editor2.actionElementMaps, nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps, controllerMap_Editor.actionElementMaps, bmJdVoieIGENacrTolZXsSZCDhis);
								num = 1762310957;
								continue;
							case 9:
								controllerMap_Editor2 = nidbapiqcmHkXHMaeaVIDlMVqAC.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[nidbapiqcmHkXHMaeaVIDlMVqAC.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
								num = 1762310948;
								continue;
							case 1:
								num = 1762310948;
								continue;
							case 3:
								controllerMap_Editor = JsonTools.Clone(nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm);
								controllerMap_Editor.actionElementMaps.Clear();
								if (BmJdVoieIGENacrTolZXsSZCDhis == null)
								{
									BmJdVoieIGENacrTolZXsSZCDhis = kJBnqaQrfqaKJXBirFpghsSgHReR;
									num = 1762310952;
									continue;
								}
								goto case 2;
							default:
								return nidbapiqcmHkXHMaeaVIDlMVqAC.hblKmXrIybUsjuWnbrpAiWaScrm;
							}
							break;
						}
					}
				}

				private static int kJBnqaQrfqaKJXBirFpghsSgHReR(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (num < P_1.Count)
					{
						while (true)
						{
							int num2;
							if (P_1[num]._elementIdentifierId == P_0._elementIdentifierId && P_1[num]._axisRange == P_0._axisRange && P_1[num]._axisContribution == P_0._axisContribution && P_1[num]._actionId == P_0._actionId)
							{
								num2 = -1041251351;
							}
							else
							{
								num++;
								num2 = -1041251350;
							}
							while (true)
							{
								switch (num2 ^ -1041251350)
								{
								case 2:
									num2 = -1041251349;
									continue;
								case 1:
									break;
								case 3:
									return num;
								default:
									goto end_IL_0029;
								}
								break;
							}
							continue;
							end_IL_0029:
							break;
						}
					}
					return -1;
				}
			}

			private sealed class hgstvUHUbdlmtRHNcKIMYPsWxoQ
			{
				private sealed class eWRKpgjIYVWCQahSWbIOMXEGeokG
				{
					public hgstvUHUbdlmtRHNcKIMYPsWxoQ RJWFvvflSsZOfeRaYdBZovarjjKD;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ControllerMap_Editor AdqDRmvMCTHHDQWIUGnRloZhdLl;

					public bool YgMNjCkPUuTTQENHAKrKHruGIgb(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0.RCOauDZdeEvGkaCTeYBvkrIMFQK == AdqDRmvMCTHHDQWIUGnRloZhdLl.customControllerUid;
					}

					public bool hURdDoMTfZzRrKCRMFGSiHumYXop(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0.RCOauDZdeEvGkaCTeYBvkrIMFQK == AdqDRmvMCTHHDQWIUGnRloZhdLl.categoryId;
					}

					public bool CFOLhvWqciwVMJKrsuRVdgxohHy(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0.RCOauDZdeEvGkaCTeYBvkrIMFQK == AdqDRmvMCTHHDQWIUGnRloZhdLl.layoutId;
					}
				}

				private sealed class BjRGMVuOeaHtIPJuSPOIeuPvTWw
				{
					public hgstvUHUbdlmtRHNcKIMYPsWxoQ RJWFvvflSsZOfeRaYdBZovarjjKD;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ControllerMap_Editor hblKmXrIybUsjuWnbrpAiWaScrm;

					public lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMap_Editor> mDgcyeMwmBaMprlpQyHooOSZUWD;

					public bool LoKcrHPbYEGbBmBoXkVMsRmoAvx(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == hblKmXrIybUsjuWnbrpAiWaScrm.customControllerUid;
					}

					public bool XsdaPFYRPTJVUOOkolqEHWixChl(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == hblKmXrIybUsjuWnbrpAiWaScrm.categoryId;
					}

					public bool xDxiNByNJjsBZcIQjGhliSyQsmVD(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == hblKmXrIybUsjuWnbrpAiWaScrm.layoutId;
					}
				}

				private sealed class QEngxhcHYrRnCldzgkIeillvtKqR
				{
					public BjRGMVuOeaHtIPJuSPOIeuPvTWw vKfeLNVNQjkugDyUtVPfLAMsfgh;

					public hgstvUHUbdlmtRHNcKIMYPsWxoQ RJWFvvflSsZOfeRaYdBZovarjjKD;

					public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

					public ActionElementMap wWIAVQYLtUqmWRBSPcIMZSWLBQsG;

					public bool UEiHHPtqzEfyfhOmerVDRcBqMdHr(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
					{
						return P_0[vKfeLNVNQjkugDyUtVPfLAMsfgh.mDgcyeMwmBaMprlpQyHooOSZUWD.vGEummKjgDcSUGooGPOJfEZgtJrm] == wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId;
					}
				}

				public pjhKBXcxIQSvXSEDSNexHaXjMmv qTClCWNuYDhqHNJDcYUkEPyLewR;

				public List<zfpmTQonvrTjOJqbUbEUKlTCqdf> IdHoIiVveVBwBKBeWrsEdYqfsYz;

				private static Func<ActionElementMap, IList<ActionElementMap>, int> KemKmnRGyOlrfgjdzCEdjQRbDqe;

				public int wtceLJCfCDVwFsMUTXTFJvdrpCbg(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					eWRKpgjIYVWCQahSWbIOMXEGeokG eWRKpgjIYVWCQahSWbIOMXEGeokG2 = default(eWRKpgjIYVWCQahSWbIOMXEGeokG);
					int num2 = default(int);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf4 = default(zfpmTQonvrTjOJqbUbEUKlTCqdf);
					while (true)
					{
						int num = 1846165326;
						while (true)
						{
							switch (num ^ 0x6E0A3F4B)
							{
							case 0:
								break;
							case 5:
								eWRKpgjIYVWCQahSWbIOMXEGeokG2 = new eWRKpgjIYVWCQahSWbIOMXEGeokG();
								eWRKpgjIYVWCQahSWbIOMXEGeokG2.RJWFvvflSsZOfeRaYdBZovarjjKD = this;
								eWRKpgjIYVWCQahSWbIOMXEGeokG2.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
								eWRKpgjIYVWCQahSWbIOMXEGeokG2.AdqDRmvMCTHHDQWIUGnRloZhdLl = P_0;
								num2 = 0;
								num = 1846165320;
								continue;
							case 1:
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf3 != null && zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu == P_1[num2].categoryId && zfpmTQonvrTjOJqbUbEUKlTCqdf4 != null && zfpmTQonvrTjOJqbUbEUKlTCqdf4.cTHDnPOBDaIQlEKyfIKjBxYzcOnu == P_1[num2].layoutId)
								{
									num = 1846165327;
									continue;
								}
								goto IL_009d;
							case 4:
								return num2;
							case 2:
							{
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = qTClCWNuYDhqHNJDcYUkEPyLewR.ngBkUCBWeNOKhqSbWSAdLHAWbwz.Find(eWRKpgjIYVWCQahSWbIOMXEGeokG2.YgMNjCkPUuTTQENHAKrKHruGIgb);
								zfpmTQonvrTjOJqbUbEUKlTCqdf3 = qTClCWNuYDhqHNJDcYUkEPyLewR.SclSkjgPLpFngbZoISugthSGOur.Find(eWRKpgjIYVWCQahSWbIOMXEGeokG2.hURdDoMTfZzRrKCRMFGSiHumYXop);
								zfpmTQonvrTjOJqbUbEUKlTCqdf4 = IdHoIiVveVBwBKBeWrsEdYqfsYz.Find(eWRKpgjIYVWCQahSWbIOMXEGeokG2.CFOLhvWqciwVMJKrsuRVdgxohHy);
								if (zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null && zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu == P_1[num2].customControllerUid)
								{
									num = 1846165322;
									continue;
								}
								goto IL_009d;
							}
							default:
								{
									if (num2 >= P_1.Count)
									{
										return -1;
									}
									goto case 2;
								}
								IL_009d:
								num2++;
								num = 1846165320;
								continue;
							}
							break;
						}
					}
				}

				public ControllerMap_Editor QvrvxflFDvlSwUFtAIbGjnIiwez(lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMap_Editor> P_0)
				{
					BjRGMVuOeaHtIPJuSPOIeuPvTWw bjRGMVuOeaHtIPJuSPOIeuPvTWw = new BjRGMVuOeaHtIPJuSPOIeuPvTWw();
					QEngxhcHYrRnCldzgkIeillvtKqR qEngxhcHYrRnCldzgkIeillvtKqR = default(QEngxhcHYrRnCldzgkIeillvtKqR);
					int num2 = default(int);
					ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
					ControllerMap_Editor controllerMap_Editor2 = default(ControllerMap_Editor);
					while (true)
					{
						int num = 878109901;
						while (true)
						{
							switch (num ^ 0x3456E4C6)
							{
							case 9:
								break;
							case 0:
							{
								int num3;
								if (KemKmnRGyOlrfgjdzCEdjQRbDqe != null)
								{
									num = 878109892;
									num3 = num;
								}
								else
								{
									num = 878109895;
									num3 = num;
								}
								continue;
							}
							case 12:
								qEngxhcHYrRnCldzgkIeillvtKqR = new QEngxhcHYrRnCldzgkIeillvtKqR();
								qEngxhcHYrRnCldzgkIeillvtKqR.vKfeLNVNQjkugDyUtVPfLAMsfgh = bjRGMVuOeaHtIPJuSPOIeuPvTWw;
								qEngxhcHYrRnCldzgkIeillvtKqR.RJWFvvflSsZOfeRaYdBZovarjjKD = this;
								qEngxhcHYrRnCldzgkIeillvtKqR.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
								num = 878109899;
								continue;
							case 10:
							{
								bjRGMVuOeaHtIPJuSPOIeuPvTWw.mDgcyeMwmBaMprlpQyHooOSZUWD = P_0;
								bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm = JsonTools.Clone(bjRGMVuOeaHtIPJuSPOIeuPvTWw.mDgcyeMwmBaMprlpQyHooOSZUWD.jBPGEaYrWzWRAmgdbXEUhEyBXOS);
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf3 = qTClCWNuYDhqHNJDcYUkEPyLewR.ngBkUCBWeNOKhqSbWSAdLHAWbwz.Find(bjRGMVuOeaHtIPJuSPOIeuPvTWw.LoKcrHPbYEGbBmBoXkVMsRmoAvx);
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf4 = qTClCWNuYDhqHNJDcYUkEPyLewR.SclSkjgPLpFngbZoISugthSGOur.Find(bjRGMVuOeaHtIPJuSPOIeuPvTWw.XsdaPFYRPTJVUOOkolqEHWixChl);
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf5 = IdHoIiVveVBwBKBeWrsEdYqfsYz.Find(bjRGMVuOeaHtIPJuSPOIeuPvTWw.xDxiNByNJjsBZcIQjGhliSyQsmVD);
								bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm.customControllerUid = ((zfpmTQonvrTjOJqbUbEUKlTCqdf3 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf3.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm.categoryId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf4 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf4.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm.layoutId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf5 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf5.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								num = 878109888;
								continue;
							}
							case 1:
								KemKmnRGyOlrfgjdzCEdjQRbDqe = lRqacEGDZslHbOpWIyYVOeTVUSiS;
								num = 878109892;
								continue;
							case 8:
								bjRGMVuOeaHtIPJuSPOIeuPvTWw.qTClCWNuYDhqHNJDcYUkEPyLewR = qTClCWNuYDhqHNJDcYUkEPyLewR;
								num = 878109900;
								continue;
							case 6:
								num2 = 0;
								num = 878109890;
								continue;
							case 2:
							{
								Func<ActionElementMap, IList<ActionElementMap>, int> kemKmnRGyOlrfgjdzCEdjQRbDqe = KemKmnRGyOlrfgjdzCEdjQRbDqe;
								haualFiuTyJaHUWxxENcsCamafd(controllerMap_Editor.actionElementMaps, bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps, controllerMap_Editor2.actionElementMaps, kemKmnRGyOlrfgjdzCEdjQRbDqe);
								num = 878109891;
								continue;
							}
							case 4:
								if (num2 < bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps.Count)
								{
									goto case 12;
								}
								if (bjRGMVuOeaHtIPJuSPOIeuPvTWw.mDgcyeMwmBaMprlpQyHooOSZUWD.HMoyquearlrlOniSOfLyhtLtphI)
								{
									controllerMap_Editor = bjRGMVuOeaHtIPJuSPOIeuPvTWw.mDgcyeMwmBaMprlpQyHooOSZUWD.cdIchUQhXPDsawgfzLCmqpUJqyw;
									controllerMap_Editor2 = JsonTools.Clone(bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm);
									controllerMap_Editor2.actionElementMaps.Clear();
									num = 878109894;
									continue;
								}
								goto case 14;
							case 13:
								qEngxhcHYrRnCldzgkIeillvtKqR.wWIAVQYLtUqmWRBSPcIMZSWLBQsG = bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm.actionElementMaps[num2];
								num = 878109889;
								continue;
							case 7:
							{
								zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = qTClCWNuYDhqHNJDcYUkEPyLewR.bApneWqkxJjGSMSoHKhCVlqWasMG.Find(qEngxhcHYrRnCldzgkIeillvtKqR.UEiHHPtqzEfyfhOmerVDRcBqMdHr);
								qEngxhcHYrRnCldzgkIeillvtKqR.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId = ((zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
								qEngxhcHYrRnCldzgkIeillvtKqR.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionCategoryId = ((qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.GetActionById(qEngxhcHYrRnCldzgkIeillvtKqR.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId) != null) ? qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.GetActionById(qEngxhcHYrRnCldzgkIeillvtKqR.wWIAVQYLtUqmWRBSPcIMZSWLBQsG._actionId).categoryId : 0);
								num2++;
								num = 878109890;
								continue;
							}
							case 11:
								bjRGMVuOeaHtIPJuSPOIeuPvTWw.RJWFvvflSsZOfeRaYdBZovarjjKD = this;
								num = 878109902;
								continue;
							case 14:
								qTClCWNuYDhqHNJDcYUkEPyLewR.gQKGqRzPUnrelmbksZbFXmMbfQEk.CreateCustomControllerMap(bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm.categoryId, bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm.customControllerUid, bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm.layoutId);
								controllerMap_Editor = bjRGMVuOeaHtIPJuSPOIeuPvTWw.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[bjRGMVuOeaHtIPJuSPOIeuPvTWw.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.Count - 1];
								num = 878109893;
								continue;
							case 5:
								bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm = controllerMap_Editor2;
								num = 878109893;
								continue;
							default:
							{
								bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm.id = controllerMap_Editor.id;
								int index = bjRGMVuOeaHtIPJuSPOIeuPvTWw.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN.IndexOf(controllerMap_Editor);
								bjRGMVuOeaHtIPJuSPOIeuPvTWw.mDgcyeMwmBaMprlpQyHooOSZUWD.KgBiervgcFPhSNIBLZDZhOHKfLN[index] = bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm;
								return bjRGMVuOeaHtIPJuSPOIeuPvTWw.hblKmXrIybUsjuWnbrpAiWaScrm;
							}
							}
							break;
						}
					}
				}

				private static int lRqacEGDZslHbOpWIyYVOeTVUSiS(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					int num = 0;
					while (true)
					{
						int num2 = -388076258;
						while (true)
						{
							switch (num2 ^ -388076257)
							{
							case 2:
								break;
							case 1:
								num2 = -388076257;
								continue;
							case 4:
								if (P_1[num]._elementIdentifierId == P_0._elementIdentifierId && P_1[num]._axisRange == P_0._axisRange && P_1[num]._axisContribution == P_0._axisContribution && P_1[num]._actionId == P_0._actionId)
								{
									return num;
								}
								num++;
								num2 = -388076257;
								continue;
							case 0:
							{
								int num3;
								if (num < P_1.Count)
								{
									num2 = -388076261;
									num3 = num2;
								}
								else
								{
									num2 = -388076260;
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
			}

			private sealed class hmlSsXToAwSkYbdrifQmzcAdWtk<T> where T : class
			{
				public Func<T, int> EDtAenTdvxqjYucNthLzuBLZlwk;
			}

			private sealed class EVfxbxOWQdTLdGxYDUlDkqWPWbM<T> where T : class
			{
				public hmlSsXToAwSkYbdrifQmzcAdWtk<T> BWzPwbaZSKggeAeMrnMfdCEIFcc;

				public T hblKmXrIybUsjuWnbrpAiWaScrm;

				public bool ajzMiRcBrodRzUKWuQrxNbqNONE(zfpmTQonvrTjOJqbUbEUKlTCqdf P_0)
				{
					return P_0.cTHDnPOBDaIQlEKyfIKjBxYzcOnu == BWzPwbaZSKggeAeMrnMfdCEIFcc.EDtAenTdvxqjYucNthLzuBLZlwk(hblKmXrIybUsjuWnbrpAiWaScrm);
				}
			}

			[CompilerGenerated]
			private static Func<InputCategory, int> dvHJJPcdmGcIyIcHLNJPGWmIKQy;

			[CompilerGenerated]
			private static Func<InputCategory, string> bHWHHCHhjPjMVAGiysXsurzkOkd;

			[CompilerGenerated]
			private static Func<InputCategory, IList<InputCategory>, int> kaFHBexWcTPXBfyLQkcMcKWeJJS;

			[CompilerGenerated]
			private static Func<InputBehavior, int> bkeIhNkAOqmCudDIgPKORMSHjTW;

			[CompilerGenerated]
			private static Func<InputBehavior, string> NjFhqWhtdyJKCqglURbdTguIelT;

			[CompilerGenerated]
			private static Func<InputBehavior, IList<InputBehavior>, int> SDjpSohGGaySQTpeTdPUcmDmVZt;

			[CompilerGenerated]
			private static Func<InputAction, int> FOSrzygkGJBnNZdMDbUylOpnpDZ;

			[CompilerGenerated]
			private static Func<InputAction, string> AdnTSlZgGhyTxFgnSexZIxdkCgJ;

			[CompilerGenerated]
			private static Func<InputAction, IList<InputAction>, int> pzxbYHRhMbXKXxDgFdkjaQujVnIg;

			[CompilerGenerated]
			private static Func<InputMapCategory, int> dnvzHSwhFPlTrnIrYDKoKfWOIKZe;

			[CompilerGenerated]
			private static Func<InputMapCategory, string> VHyFQafPGPGHYJfCSiMcgSrcMgdr;

			[CompilerGenerated]
			private static Func<InputMapCategory, IList<InputMapCategory>, int> ZEaZwcycefERtWbeCkyYbFERxQr;

			[CompilerGenerated]
			private static Func<InputLayout, int> tCwGmqXMhFBhHfgyWsJvPrAnXLJ;

			[CompilerGenerated]
			private static Func<InputLayout, string> diglnrCmBOiLteBKrDEnfUxjEIC;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> pWMVpOjeUlCQnCXbkBCEJDtMfks;

			[CompilerGenerated]
			private static Func<InputLayout, int> FGBhbdAJeXXLJQAjWEYQiLkLuwPN;

			[CompilerGenerated]
			private static Func<InputLayout, string> oFoOnqVQwrCweyPDZcBKaDCCemdj;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> xEMtNSOnexyNcwPPPPuDVktHXOr;

			[CompilerGenerated]
			private static Func<InputLayout, int> iSPPZwiivyQfUiEjXFIcKqigdZFl;

			[CompilerGenerated]
			private static Func<InputLayout, string> vCrOCMifPNDKmuVlHJDfUMXWxsq;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> LDkhXNhoxGqZMNpDTDyXLVRegnBS;

			[CompilerGenerated]
			private static Func<InputLayout, int> jMsLaAwPTapxnCmxRPNbyWqyCmL;

			[CompilerGenerated]
			private static Func<InputLayout, string> xlkvCZzDasecTzVzStgnbudFNEv;

			[CompilerGenerated]
			private static Func<InputLayout, IList<InputLayout>, int> jFJiHktuqFgzsGoXPrtoezlVOmC;

			[CompilerGenerated]
			private static Func<CustomController_Editor, int> RazRJOXPGJLHRbKytaKGHscqBVIT;

			[CompilerGenerated]
			private static Func<CustomController_Editor, string> gnWHQcJXEyaWtYfJUuPPxLcTgyk;

			[CompilerGenerated]
			private static Func<CustomController_Editor, IList<CustomController_Editor>, int> PEzoEiyRoSCyfhcRalrZqRBKtoF;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, int> scaTRPQHlsdclDVBADmQnUvvPOU;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, string> IfGTNvHpLcyDPyjMwqqgJkGCsHp;

			[CompilerGenerated]
			private static Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> OqFuxJQVpXDPhXmyXOkCtXKatG;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, int> hmTUDZTzfyEKEMiSyjmIUbkvihF;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, string> SyZEFTAlvKhuGHZntoRMmGjKqFXe;

			[CompilerGenerated]
			private static Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> GydcTtXcMfzfgvktTnkTFGGmrVd;

			[CompilerGenerated]
			private static Func<Player_Editor, int> kljldHIBfdmBGAuosIdfaDXmawH;

			[CompilerGenerated]
			private static Func<Player_Editor, string> QXwuDuWMjfvsxYSoLTRysEgRHlU;

			[CompilerGenerated]
			private static Func<Player_Editor, IList<Player_Editor>, int> WzCErikvUSCajNyeNWTKKDzoMszK;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> xIaKKmmePfKvAkQgMLjHsrcLTcE;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> NVcvvhxamQTdHDMogulyXnuUYiG;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> qnSxqyyfbqMDNhoCVHUwoFNqAkBg;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> MfqbDihWEQjdpIIEgGKKYmKbHSm;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> gINnpFFuuMOFurKiYsVpvxCbKsr;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> lGwnznohZNvhFDaMdjKaLHjenhr;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, int> IoEBAnAlGeOKNfdfGKfChCLSkbUg;

			[CompilerGenerated]
			private static Func<ControllerMap_Editor, string> IekjuWwDwtDmnWCJAKvEJsgLwYg;

			public static UserData TOjOfzJeCUTmMnojBKzdzOKRule(UserData P_0, UserData P_1, bool P_2)
			{
				pjhKBXcxIQSvXSEDSNexHaXjMmv pjhKBXcxIQSvXSEDSNexHaXjMmv2 = default(pjhKBXcxIQSvXSEDSNexHaXjMmv);
				afoiGKdxXheWQGCGMQfnxoyKLeli afoiGKdxXheWQGCGMQfnxoyKLeli2 = default(afoiGKdxXheWQGCGMQfnxoyKLeli);
				Func<lHFDDWjVDcRlOAZjbSJDfSQYpREQ<CustomController_Editor>, CustomController_Editor> func12 = default(Func<lHFDDWjVDcRlOAZjbSJDfSQYpREQ<CustomController_Editor>, CustomController_Editor>);
				int num3 = default(int);
				Func<lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMapLayoutManager_RuleSet_Editor>, ControllerMapLayoutManager_RuleSet_Editor> func4 = default(Func<lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMapLayoutManager_RuleSet_Editor>, ControllerMapLayoutManager_RuleSet_Editor>);
				Func<lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMapEnabler_RuleSet_Editor>, ControllerMapEnabler_RuleSet_Editor> func8 = default(Func<lHFDDWjVDcRlOAZjbSJDfSQYpREQ<ControllerMapEnabler_RuleSet_Editor>, ControllerMapEnabler_RuleSet_Editor>);
				List<zfpmTQonvrTjOJqbUbEUKlTCqdf> list3 = default(List<zfpmTQonvrTjOJqbUbEUKlTCqdf>);
				List<zfpmTQonvrTjOJqbUbEUKlTCqdf> list = default(List<zfpmTQonvrTjOJqbUbEUKlTCqdf>);
				hgstvUHUbdlmtRHNcKIMYPsWxoQ hgstvUHUbdlmtRHNcKIMYPsWxoQ2 = default(hgstvUHUbdlmtRHNcKIMYPsWxoQ);
				FGjWdsaAqkgtOnAXPhxbcJvllHp fGjWdsaAqkgtOnAXPhxbcJvllHp = default(FGjWdsaAqkgtOnAXPhxbcJvllHp);
				int num2 = default(int);
				InputMapCategory inputMapCategory = default(InputMapCategory);
				List<zfpmTQonvrTjOJqbUbEUKlTCqdf> list4 = default(List<zfpmTQonvrTjOJqbUbEUKlTCqdf>);
				Func<lHFDDWjVDcRlOAZjbSJDfSQYpREQ<Player_Editor>, Player_Editor> func13 = default(Func<lHFDDWjVDcRlOAZjbSJDfSQYpREQ<Player_Editor>, Player_Editor>);
				List<zfpmTQonvrTjOJqbUbEUKlTCqdf> list2 = default(List<zfpmTQonvrTjOJqbUbEUKlTCqdf>);
				zWShRbrSkbmQIxclFKiflhhdxUr zWShRbrSkbmQIxclFKiflhhdxUr2 = default(zWShRbrSkbmQIxclFKiflhhdxUr);
				while (true)
				{
					int num = 1488390542;
					while (true)
					{
						switch (num ^ 0x58B7099F)
						{
						case 20:
							break;
						case 11:
							UktPdmlSyDHGsPlslPNkmiCkigW("Map Category", P_0.mapCategories, (P_1 != null) ? P_1.mapCategories : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.mapCategories, P_2, pjhKBXcxIQSvXSEDSNexHaXjMmv2.SclSkjgPLpFngbZoISugthSGOur, (InputMapCategory inputMapCategory2) => inputMapCategory2.id, (InputMapCategory inputMapCategory2) => inputMapCategory2.name, delegate(InputMapCategory inputMapCategory2, IList<InputMapCategory> list7)
							{
								int num4 = 0;
								while (num4 < list7.Count)
								{
									while (true)
									{
										int num5;
										if (string.Equals(inputMapCategory2.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
										{
											num5 = -691502512;
										}
										else
										{
											num4++;
											num5 = -691502509;
										}
										while (true)
										{
											switch (num5 ^ -691502511)
											{
											case 0:
												num5 = -691502510;
												continue;
											case 3:
												break;
											case 1:
												return num4;
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
							}, afoiGKdxXheWQGCGMQfnxoyKLeli2.jhXGQuZllOcCMGfWYFRieVwlLjc);
							num = 1488390555;
							continue;
						case 18:
							afoiGKdxXheWQGCGMQfnxoyKLeli2.qTClCWNuYDhqHNJDcYUkEPyLewR = pjhKBXcxIQSvXSEDSNexHaXjMmv2;
							afoiGKdxXheWQGCGMQfnxoyKLeli2.DbvSyQPIqRBKowskMKFfMNbYJNw = new List<int>();
							num = 1488390548;
							continue;
						case 12:
						{
							List<CustomController_Editor> customControllers = P_0.customControllers;
							List<CustomController_Editor> obj3 = ((P_1 != null) ? P_1.customControllers : null);
							List<CustomController_Editor> customControllers2 = pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.customControllers;
							List<zfpmTQonvrTjOJqbUbEUKlTCqdf> ngBkUCBWeNOKhqSbWSAdLHAWbwz = pjhKBXcxIQSvXSEDSNexHaXjMmv2.ngBkUCBWeNOKhqSbWSAdLHAWbwz;
							Func<CustomController_Editor, int> func9 = (CustomController_Editor customController_Editor) => customController_Editor.id;
							Func<CustomController_Editor, string> func10 = (CustomController_Editor customController_Editor) => customController_Editor.name;
							Func<CustomController_Editor, IList<CustomController_Editor>, int> func11 = delegate(CustomController_Editor customController_Editor, IList<CustomController_Editor> list7)
							{
								int num4 = 0;
								while (true)
								{
									int num5 = 1336554841;
									while (true)
									{
										switch (num5 ^ 0x4FAA355B)
										{
										case 4:
											break;
										case 2:
											num5 = 1336554843;
											continue;
										case 5:
											if (string.Equals(customController_Editor.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												num5 = 1336554842;
											}
											else
											{
												num4++;
												num5 = 1336554843;
											}
											continue;
										case 0:
										{
											int num6;
											if (num4 < list7.Count)
											{
												num5 = 1336554846;
												num6 = num5;
											}
											else
											{
												num5 = 1336554840;
												num6 = num5;
											}
											continue;
										}
										case 1:
											return num4;
										default:
											return -1;
										}
										break;
									}
								}
							};
							if (func12 == null)
							{
								func12 = pjhKBXcxIQSvXSEDSNexHaXjMmv2.kVoBiFreyjpFpyAkNmEaOHfmgzNF;
							}
							UktPdmlSyDHGsPlslPNkmiCkigW("Custom Controller", customControllers, obj3, customControllers2, P_2, ngBkUCBWeNOKhqSbWSAdLHAWbwz, func9, func10, func11, func12);
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.eYhzTCjKkJCfMqmOnNjyeXXxbhn = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							num = 1488390557;
							continue;
						}
						case 4:
							num3 = 0;
							num = 1488390549;
							continue;
						case 13:
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.yRyutBWetYAlfEiaLMyLYTUmXtH = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							UktPdmlSyDHGsPlslPNkmiCkigW("Mouse Layout", P_0.mouseLayouts, (P_1 != null) ? P_1.mouseLayouts : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.mouseLayouts, P_2, pjhKBXcxIQSvXSEDSNexHaXjMmv2.yRyutBWetYAlfEiaLMyLYTUmXtH, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list7)
							{
								int num4 = 0;
								while (num4 < list7.Count)
								{
									while (true)
									{
										int num5;
										if (string.Equals(inputLayout.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
										{
											num5 = 1915712044;
										}
										else
										{
											num4++;
											num5 = 1915712045;
										}
										while (true)
										{
											switch (num5 ^ 0x722F722E)
											{
											case 0:
												num5 = 1915712047;
												continue;
											case 1:
												break;
											case 2:
												return num4;
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
							}, pjhKBXcxIQSvXSEDSNexHaXjMmv2.mKjCaiKwwMcEBkbcTdXNguyDfZQZ);
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.YQRpSchsUChQpULokGiufHFJzNxR = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							UktPdmlSyDHGsPlslPNkmiCkigW("Joystick Layout", P_0.joystickLayouts, (P_1 != null) ? P_1.joystickLayouts : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.joystickLayouts, P_2, pjhKBXcxIQSvXSEDSNexHaXjMmv2.YQRpSchsUChQpULokGiufHFJzNxR, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list7)
							{
								int num4 = 0;
								while (true)
								{
									int num5;
									int num6;
									if (num4 < list7.Count)
									{
										num5 = 471916563;
										num6 = num5;
									}
									else
									{
										num5 = 471916566;
										num6 = num5;
									}
									while (true)
									{
										switch (num5 ^ 0x1C20E012)
										{
										case 3:
											num5 = 471916563;
											continue;
										case 1:
											if (string.Equals(inputLayout.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												num5 = 471916560;
											}
											else
											{
												num4++;
												num5 = 471916562;
											}
											continue;
										case 2:
											return num4;
										case 0:
											break;
										default:
											return -1;
										}
										break;
									}
								}
							}, pjhKBXcxIQSvXSEDSNexHaXjMmv2.ARQqwfRdxyzmhWSuRlcMeHwpesWg);
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.BOWQgrgKHSYLhBKpcbkmdTZAKYpe = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							UktPdmlSyDHGsPlslPNkmiCkigW("Custom Controller Layout", P_0.customControllerLayouts, (P_1 != null) ? P_1.customControllerLayouts : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.customControllerLayouts, P_2, pjhKBXcxIQSvXSEDSNexHaXjMmv2.BOWQgrgKHSYLhBKpcbkmdTZAKYpe, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list7)
							{
								int num4 = 0;
								while (num4 < list7.Count)
								{
									while (true)
									{
										if (string.Equals(inputLayout.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
										{
											return num4;
										}
										num4++;
										int num5 = -653523450;
										while (true)
										{
											switch (num5 ^ -653523452)
											{
											case 0:
												num5 = -653523451;
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
							}, pjhKBXcxIQSvXSEDSNexHaXjMmv2.YKnDbBHhgUnHdVmTvuuylvCnFtz);
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.BqwnPHdiEAAYVKspIjetsvMuCQf = pjhKBXcxIQSvXSEDSNexHaXjMmv2.LTlvtWjuaNqkDmTNPmJWgHYUJDg;
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.ngBkUCBWeNOKhqSbWSAdLHAWbwz = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							num = 1488390547;
							continue;
						case 17:
							func12 = null;
							num = 1488390550;
							continue;
						case 2:
						{
							List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = P_0.controllerMapLayoutManagerRuleSets;
							List<ControllerMapLayoutManager_RuleSet_Editor> obj = ((P_1 != null) ? P_1.controllerMapLayoutManagerRuleSets : null);
							List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets2 = pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.controllerMapLayoutManagerRuleSets;
							List<zfpmTQonvrTjOJqbUbEUKlTCqdf> eYhzTCjKkJCfMqmOnNjyeXXxbhn = pjhKBXcxIQSvXSEDSNexHaXjMmv2.eYhzTCjKkJCfMqmOnNjyeXXxbhn;
							Func<ControllerMapLayoutManager_RuleSet_Editor, int> func = (ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor) => controllerMapLayoutManager_RuleSet_Editor.id;
							Func<ControllerMapLayoutManager_RuleSet_Editor, string> func2 = (ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor) => controllerMapLayoutManager_RuleSet_Editor.name;
							Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> func3 = delegate(ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor> list7)
							{
								int num4 = 0;
								while (num4 < list7.Count)
								{
									while (true)
									{
										if (string.Equals(controllerMapLayoutManager_RuleSet_Editor.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
										{
											return num4;
										}
										num4++;
										int num5 = -1673896669;
										while (true)
										{
											switch (num5 ^ -1673896669)
											{
											case 2:
												num5 = -1673896670;
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
							};
							if (func4 == null)
							{
								func4 = pjhKBXcxIQSvXSEDSNexHaXjMmv2.LjJXfLdEbuxziWzffcCTkQrpCwG;
							}
							UktPdmlSyDHGsPlslPNkmiCkigW("Layout Manager Set", controllerMapLayoutManagerRuleSets, obj, controllerMapLayoutManagerRuleSets2, P_2, eYhzTCjKkJCfMqmOnNjyeXXxbhn, func, func2, func3, func4);
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.lhLhfTleShdifyqLvIIpptrvfPx = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = P_0.controllerMapEnablerRuleSets;
							List<ControllerMapEnabler_RuleSet_Editor> obj2 = ((P_1 != null) ? P_1.controllerMapEnablerRuleSets : null);
							List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets2 = pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.controllerMapEnablerRuleSets;
							List<zfpmTQonvrTjOJqbUbEUKlTCqdf> lhLhfTleShdifyqLvIIpptrvfPx = pjhKBXcxIQSvXSEDSNexHaXjMmv2.lhLhfTleShdifyqLvIIpptrvfPx;
							Func<ControllerMapEnabler_RuleSet_Editor, int> func5 = (ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor) => controllerMapEnabler_RuleSet_Editor.id;
							Func<ControllerMapEnabler_RuleSet_Editor, string> func6 = (ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor) => controllerMapEnabler_RuleSet_Editor.name;
							Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> func7 = delegate(ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor> list7)
							{
								int num4 = 0;
								while (true)
								{
									int num5 = 778101316;
									while (true)
									{
										switch (num5 ^ 0x2E60E246)
										{
										case 3:
											break;
										case 2:
											num5 = 778101318;
											continue;
										case 1:
											if (string.Equals(controllerMapEnabler_RuleSet_Editor.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												return num4;
											}
											num4++;
											num5 = 778101318;
											continue;
										default:
											if (num4 >= list7.Count)
											{
												return -1;
											}
											goto case 1;
										}
										break;
									}
								}
							};
							if (func8 == null)
							{
								func8 = pjhKBXcxIQSvXSEDSNexHaXjMmv2.frpLDJFQldqZIyULpSKAUqpBFPW;
							}
							UktPdmlSyDHGsPlslPNkmiCkigW("Controller Map Enabler Set", controllerMapEnablerRuleSets, obj2, controllerMapEnablerRuleSets2, P_2, lhLhfTleShdifyqLvIIpptrvfPx, func5, func6, func7, func8);
							num = 1488390552;
							continue;
						}
						case 5:
						{
							HPAWTbPzBkUuUBbtLSSJiKxfKQ hPAWTbPzBkUuUBbtLSSJiKxfKQ = new HPAWTbPzBkUuUBbtLSSJiKxfKQ();
							hPAWTbPzBkUuUBbtLSSJiKxfKQ.qTClCWNuYDhqHNJDcYUkEPyLewR = pjhKBXcxIQSvXSEDSNexHaXjMmv2;
							hPAWTbPzBkUuUBbtLSSJiKxfKQ.IdHoIiVveVBwBKBeWrsEdYqfsYz = pjhKBXcxIQSvXSEDSNexHaXjMmv2.yRyutBWetYAlfEiaLMyLYTUmXtH;
							UktPdmlSyDHGsPlslPNkmiCkigW("Mouse Map", P_0.mouseMaps, (P_1 != null) ? P_1.mouseMaps : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.mouseMaps, P_2, list3, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, hPAWTbPzBkUuUBbtLSSJiKxfKQ.NJNruLpxbyjqQzecoltgCiDezow, hPAWTbPzBkUuUBbtLSSJiKxfKQ.NcEHOhSXKccVqlHhiyjsfjhuzRg);
							List<zfpmTQonvrTjOJqbUbEUKlTCqdf> list5 = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							nRBGkhBBaHBoAnjPKyonFzHpLwc nRBGkhBBaHBoAnjPKyonFzHpLwc2 = new nRBGkhBBaHBoAnjPKyonFzHpLwc();
							nRBGkhBBaHBoAnjPKyonFzHpLwc2.qTClCWNuYDhqHNJDcYUkEPyLewR = pjhKBXcxIQSvXSEDSNexHaXjMmv2;
							nRBGkhBBaHBoAnjPKyonFzHpLwc2.IdHoIiVveVBwBKBeWrsEdYqfsYz = pjhKBXcxIQSvXSEDSNexHaXjMmv2.YQRpSchsUChQpULokGiufHFJzNxR;
							UktPdmlSyDHGsPlslPNkmiCkigW("Joystick Map", P_0.joystickMaps, (P_1 != null) ? P_1.joystickMaps : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.joystickMaps, P_2, list5, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, nRBGkhBBaHBoAnjPKyonFzHpLwc2.HPMAZpHkrvKJDPwNkOusGrVNbCK, nRBGkhBBaHBoAnjPKyonFzHpLwc2.FwoiXqiDnVgAauhmFqelLSasWkb);
							list = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							hgstvUHUbdlmtRHNcKIMYPsWxoQ2 = new hgstvUHUbdlmtRHNcKIMYPsWxoQ();
							hgstvUHUbdlmtRHNcKIMYPsWxoQ2.qTClCWNuYDhqHNJDcYUkEPyLewR = pjhKBXcxIQSvXSEDSNexHaXjMmv2;
							num = 1488390553;
							continue;
						}
						case 14:
							fGjWdsaAqkgtOnAXPhxbcJvllHp = new FGjWdsaAqkgtOnAXPhxbcJvllHp();
							fGjWdsaAqkgtOnAXPhxbcJvllHp.YftpkbTrbMJWZcyPUcPnsMsQlpV = afoiGKdxXheWQGCGMQfnxoyKLeli2;
							fGjWdsaAqkgtOnAXPhxbcJvllHp.qTClCWNuYDhqHNJDcYUkEPyLewR = pjhKBXcxIQSvXSEDSNexHaXjMmv2;
							num = 1488390556;
							continue;
						case 10:
							if (num3 >= afoiGKdxXheWQGCGMQfnxoyKLeli2.DbvSyQPIqRBKowskMKFfMNbYJNw.Count)
							{
								pjhKBXcxIQSvXSEDSNexHaXjMmv2.yGJqdfzJeMLTtAxqpValuiuofppC = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
								num = 1488390558;
								continue;
							}
							goto case 0;
						case 15:
							if (num2 >= inputMapCategory.checkConflictsCategoryIds_orig.Count)
							{
								num3++;
								num = 1488390549;
								continue;
							}
							goto case 14;
						case 0:
						{
							int index = afoiGKdxXheWQGCGMQfnxoyKLeli2.DbvSyQPIqRBKowskMKFfMNbYJNw[num3];
							inputMapCategory = pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.mapCategories[index];
							num2 = 0;
							num = 1488390544;
							continue;
						}
						case 8:
							P_0 = JsonTools.Clone(P_0);
							P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk = (P_2 ? P_0 : new UserData(false));
							if (P_1 != null)
							{
								pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.configVars = JsonTools.Clone(P_1.configVars);
								num = 1488390543;
								continue;
							}
							goto case 16;
						case 21:
						{
							List<Player_Editor> players = P_0.players;
							List<Player_Editor> obj4 = ((P_1 != null) ? P_1.players : null);
							List<Player_Editor> players2 = pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.players;
							List<zfpmTQonvrTjOJqbUbEUKlTCqdf> list6 = list4;
							Func<Player_Editor, int> func14 = (Player_Editor player_Editor) => player_Editor.id;
							Func<Player_Editor, string> func15 = (Player_Editor player_Editor) => player_Editor.name;
							Func<Player_Editor, IList<Player_Editor>, int> func16 = delegate(Player_Editor player_Editor, IList<Player_Editor> list7)
							{
								int num4 = 0;
								while (num4 < list7.Count)
								{
									while (true)
									{
										if (string.Equals(player_Editor.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
										{
											return num4;
										}
										num4++;
										int num5 = 540244469;
										while (true)
										{
											switch (num5 ^ 0x203379F5)
											{
											case 2:
												num5 = 540244468;
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
							};
							if (func13 == null)
							{
								func13 = pjhKBXcxIQSvXSEDSNexHaXjMmv2.esOehhcnDGIqbdePfuOehnKWOzgn;
							}
							UktPdmlSyDHGsPlslPNkmiCkigW("Player", players, obj4, players2, P_2, list6, func14, func15, func16, func13);
							list2 = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							zWShRbrSkbmQIxclFKiflhhdxUr2 = new zWShRbrSkbmQIxclFKiflhhdxUr();
							num = 1488390540;
							continue;
						}
						case 19:
							zWShRbrSkbmQIxclFKiflhhdxUr2.qTClCWNuYDhqHNJDcYUkEPyLewR = pjhKBXcxIQSvXSEDSNexHaXjMmv2;
							zWShRbrSkbmQIxclFKiflhhdxUr2.IdHoIiVveVBwBKBeWrsEdYqfsYz = pjhKBXcxIQSvXSEDSNexHaXjMmv2.yGJqdfzJeMLTtAxqpValuiuofppC;
							UktPdmlSyDHGsPlslPNkmiCkigW("Keyboard Map", P_0.keyboardMaps, (P_1 != null) ? P_1.keyboardMaps : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.keyboardMaps, P_2, list2, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, zWShRbrSkbmQIxclFKiflhhdxUr2.ZIvfCqqylYjslezoewiqRHSpMcF, zWShRbrSkbmQIxclFKiflhhdxUr2.skumdQpneDIJVVdncfRdctYAjNME);
							list3 = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							num = 1488390554;
							continue;
						case 1:
							UktPdmlSyDHGsPlslPNkmiCkigW("Keyboard Layout", P_0.keyboardLayouts, (P_1 != null) ? P_1.keyboardLayouts : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.keyboardLayouts, P_2, pjhKBXcxIQSvXSEDSNexHaXjMmv2.yGJqdfzJeMLTtAxqpValuiuofppC, (InputLayout inputLayout) => inputLayout.id, (InputLayout inputLayout) => inputLayout.name, delegate(InputLayout inputLayout, IList<InputLayout> list7)
							{
								int num4 = 0;
								while (num4 < list7.Count)
								{
									while (true)
									{
										if (string.Equals(inputLayout.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
										{
											return num4;
										}
										num4++;
										int num5 = -723992909;
										while (true)
										{
											switch (num5 ^ -723992909)
											{
											case 2:
												num5 = -723992910;
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
							}, pjhKBXcxIQSvXSEDSNexHaXjMmv2.KLbYJFVOqGOuIKNoEuZwvxFMlcy);
							num = 1488390546;
							continue;
						case 3:
						{
							fGjWdsaAqkgtOnAXPhxbcJvllHp.RCOauDZdeEvGkaCTeYBvkrIMFQK = inputMapCategory.checkConflictsCategoryIds_orig[num2];
							zfpmTQonvrTjOJqbUbEUKlTCqdf zfpmTQonvrTjOJqbUbEUKlTCqdf2 = pjhKBXcxIQSvXSEDSNexHaXjMmv2.SclSkjgPLpFngbZoISugthSGOur.Find(fGjWdsaAqkgtOnAXPhxbcJvllHp.HbHYvLVxWJbahjSBJPShvpBahhe);
							inputMapCategory.checkConflictsCategoryIds_orig[num2] = ((zfpmTQonvrTjOJqbUbEUKlTCqdf2 != null) ? zfpmTQonvrTjOJqbUbEUKlTCqdf2.cTHDnPOBDaIQlEKyfIKjBxYzcOnu : (-1));
							num2++;
							num = 1488390544;
							continue;
						}
						case 9:
							func4 = null;
							func8 = null;
							func13 = null;
							pjhKBXcxIQSvXSEDSNexHaXjMmv2 = new pjhKBXcxIQSvXSEDSNexHaXjMmv();
							if (P_0 == null)
							{
								throw new ArgumentNullException("orig");
							}
							goto case 8;
						case 7:
							list4 = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							num = 1488390538;
							continue;
						case 16:
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.fkdOWSvkhKsVlzppDqqFfJszQwg = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							UktPdmlSyDHGsPlslPNkmiCkigW("Action Category", P_0.actionCategories, (P_1 != null) ? P_1.actionCategories : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.actionCategories, P_2, pjhKBXcxIQSvXSEDSNexHaXjMmv2.fkdOWSvkhKsVlzppDqqFfJszQwg, (InputCategory inputCategory) => inputCategory.id, (InputCategory inputCategory) => inputCategory.name, delegate(InputCategory inputCategory, IList<InputCategory> list7)
							{
								int num4 = 0;
								while (true)
								{
									int num5;
									int num6;
									if (num4 >= list7.Count)
									{
										num5 = -2035645129;
										num6 = num5;
									}
									else
									{
										num5 = -2035645131;
										num6 = num5;
									}
									while (true)
									{
										switch (num5 ^ -2035645129)
										{
										case 3:
											num5 = -2035645131;
											continue;
										case 2:
											if (string.Equals(inputCategory.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												return num4;
											}
											num4++;
											num5 = -2035645130;
											continue;
										case 1:
											break;
										default:
											return -1;
										}
										break;
									}
								}
							}, pjhKBXcxIQSvXSEDSNexHaXjMmv2.DtsHMOLCVyrBkwCBxuQJHRitExM);
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.hjCcgSKskbufhQmwEKpioqLWKuQY = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							UktPdmlSyDHGsPlslPNkmiCkigW("Input Behavior", P_0.inputBehaviors, (P_1 != null) ? P_1.inputBehaviors : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.inputBehaviors, P_2, pjhKBXcxIQSvXSEDSNexHaXjMmv2.hjCcgSKskbufhQmwEKpioqLWKuQY, (InputBehavior inputBehavior) => inputBehavior.id, (InputBehavior inputBehavior) => inputBehavior.name, delegate(InputBehavior inputBehavior, IList<InputBehavior> list7)
							{
								int num4 = 0;
								while (num4 < list7.Count)
								{
									while (true)
									{
										int num5;
										if (string.Equals(inputBehavior.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
										{
											num5 = 514224246;
										}
										else
										{
											num4++;
											num5 = 514224247;
										}
										while (true)
										{
											switch (num5 ^ 0x1EA67074)
											{
											case 0:
												num5 = 514224245;
												continue;
											case 1:
												break;
											case 2:
												return num4;
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
							}, pjhKBXcxIQSvXSEDSNexHaXjMmv2.PucxbXLvUNfLDGkrsdKFrckYHLbe);
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.bApneWqkxJjGSMSoHKhCVlqWasMG = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							UktPdmlSyDHGsPlslPNkmiCkigW("Action", P_0.actions, (P_1 != null) ? P_1.actions : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.actions, P_2, pjhKBXcxIQSvXSEDSNexHaXjMmv2.bApneWqkxJjGSMSoHKhCVlqWasMG, (InputAction inputAction) => inputAction.id, (InputAction inputAction) => inputAction.name, delegate(InputAction inputAction, IList<InputAction> list7)
							{
								int num4 = 0;
								while (true)
								{
									int num5 = -1926048808;
									while (true)
									{
										switch (num5 ^ -1926048807)
										{
										case 2:
											break;
										case 0:
											return num4;
										case 4:
											if (!string.Equals(inputAction.name, list7[num4].name, StringComparison.OrdinalIgnoreCase))
											{
												num4++;
												num5 = -1926048806;
											}
											else
											{
												num5 = -1926048807;
											}
											continue;
										case 1:
											num5 = -1926048806;
											continue;
										default:
											if (num4 >= list7.Count)
											{
												return -1;
											}
											goto case 4;
										}
										break;
									}
								}
							}, pjhKBXcxIQSvXSEDSNexHaXjMmv2.QELeMmbAQSEOgVfCBvPfQuzBhAR);
							pjhKBXcxIQSvXSEDSNexHaXjMmv2.SclSkjgPLpFngbZoISugthSGOur = new List<zfpmTQonvrTjOJqbUbEUKlTCqdf>();
							afoiGKdxXheWQGCGMQfnxoyKLeli2 = new afoiGKdxXheWQGCGMQfnxoyKLeli();
							num = 1488390541;
							continue;
						default:
							hgstvUHUbdlmtRHNcKIMYPsWxoQ2.IdHoIiVveVBwBKBeWrsEdYqfsYz = pjhKBXcxIQSvXSEDSNexHaXjMmv2.BOWQgrgKHSYLhBKpcbkmdTZAKYpe;
							UktPdmlSyDHGsPlslPNkmiCkigW("Custom Controller Map", P_0.customControllerMaps, (P_1 != null) ? P_1.customControllerMaps : null, pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk.customControllerMaps, P_2, list, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.id, (ControllerMap_Editor controllerMap_Editor) => controllerMap_Editor.name, hgstvUHUbdlmtRHNcKIMYPsWxoQ2.wtceLJCfCDVwFsMUTXTFJvdrpCbg, hgstvUHUbdlmtRHNcKIMYPsWxoQ2.QvrvxflFDvlSwUFtAIbGjnIiwez);
							return pjhKBXcxIQSvXSEDSNexHaXjMmv2.gQKGqRzPUnrelmbksZbFXmMbfQEk;
						}
						break;
					}
				}
			}

			[Conditional("DEBUG_IMPORT")]
			private static void APLftOfQBNzysmELJkYNAxECnKw(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void haualFiuTyJaHUWxxENcsCamafd<T>(IList<T> P_0, IList<T> P_1, IList<T> P_2, Func<T, IList<T>, int> P_3)
			{
				int num = 0;
				int num5 = default(int);
				T val = default(T);
				int num4 = default(int);
				while (true)
				{
					int num2;
					if (num >= P_0.Count)
					{
						int num3;
						if (P_1 == null)
						{
							num2 = -536112865;
							num3 = num2;
						}
						else
						{
							num2 = -536112866;
							num3 = num2;
						}
						goto IL_000c;
					}
					goto IL_00c1;
					IL_000c:
					while (true)
					{
						switch (num2 ^ -536112866)
						{
						case 4:
							num2 = -536112873;
							continue;
						default:
							return;
						case 8:
							if (num5 >= 0)
							{
								P_2[num5] = val;
								num2 = -536112875;
								continue;
							}
							goto case 5;
						case 7:
							num++;
							num2 = -536112872;
							continue;
						case 0:
							num4 = 0;
							num2 = -536112867;
							continue;
						case 3:
							break;
						case 6:
							goto end_IL_000c;
						case 5:
							P_2.Add(val);
							num2 = -536112868;
							continue;
						case 9:
							goto IL_00c1;
						case 11:
							num2 = -536112868;
							continue;
						case 10:
							val = P_1[num4];
							num5 = P_3(val, P_2);
							num2 = -536112874;
							continue;
						case 2:
							num4++;
							num2 = -536112867;
							continue;
						case 1:
							return;
						}
						int num6;
						if (num4 >= P_1.Count)
						{
							num2 = -536112865;
							num6 = num2;
						}
						else
						{
							num2 = -536112876;
							num6 = num2;
						}
						continue;
						end_IL_000c:
						break;
					}
					continue;
					IL_00c1:
					P_2.Add(P_0[num]);
					num2 = -536112871;
					goto IL_000c;
				}
			}

			private static void UktPdmlSyDHGsPlslPNkmiCkigW<T>(string P_0, IList<T> P_1, IList<T> P_2, IList<T> P_3, bool P_4, List<zfpmTQonvrTjOJqbUbEUKlTCqdf> P_5, Func<T, int> P_6, Func<T, string> P_7, Func<T, IList<T>, int> P_8, Func<lHFDDWjVDcRlOAZjbSJDfSQYpREQ<T>, T> P_9) where T : class
			{
				hmlSsXToAwSkYbdrifQmzcAdWtk<T> hmlSsXToAwSkYbdrifQmzcAdWtk2 = new hmlSsXToAwSkYbdrifQmzcAdWtk<T>();
				hmlSsXToAwSkYbdrifQmzcAdWtk2.EDtAenTdvxqjYucNthLzuBLZlwk = P_6;
				int num = 0;
				T val2 = default(T);
				T val = default(T);
				string text = default(string);
				int num4 = default(int);
				EVfxbxOWQdTLdGxYDUlDkqWPWbM<T> eVfxbxOWQdTLdGxYDUlDkqWPWbM = default(EVfxbxOWQdTLdGxYDUlDkqWPWbM<T>);
				int num6 = default(int);
				while (true)
				{
					int num2;
					int num3;
					if (num >= P_1.Count)
					{
						num2 = 1085505547;
						num3 = num2;
					}
					else
					{
						num2 = 1085505551;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x40B38009)
						{
						case 5:
							num2 = 1085505551;
							continue;
						default:
							return;
						case 14:
						{
							T arg2 = P_9(new lHFDDWjVDcRlOAZjbSJDfSQYpREQ<T>(val2, null, zfpmTQonvrTjOJqbUbEUKlTCqdf.WShhClxzwcSZIyaMxWChyIpnurx.RBlMEXOIUsCEfbktaDDkQUYwaysm, P_3, false));
							P_5.Add(new zfpmTQonvrTjOJqbUbEUKlTCqdf(hmlSsXToAwSkYbdrifQmzcAdWtk2.EDtAenTdvxqjYucNthLzuBLZlwk(val2), -1, hmlSsXToAwSkYbdrifQmzcAdWtk2.EDtAenTdvxqjYucNthLzuBLZlwk(arg2)));
							num2 = 1085505542;
							continue;
						}
						case 1:
						{
							T arg = P_9(new lHFDDWjVDcRlOAZjbSJDfSQYpREQ<T>(val, null, zfpmTQonvrTjOJqbUbEUKlTCqdf.WShhClxzwcSZIyaMxWChyIpnurx.RCOauDZdeEvGkaCTeYBvkrIMFQK, P_3, false));
							P_5.Add(new zfpmTQonvrTjOJqbUbEUKlTCqdf(-1, hmlSsXToAwSkYbdrifQmzcAdWtk2.EDtAenTdvxqjYucNthLzuBLZlwk(val), hmlSsXToAwSkYbdrifQmzcAdWtk2.EDtAenTdvxqjYucNthLzuBLZlwk(arg)));
							text = ((!string.IsNullOrEmpty(P_7(val))) ? ("\"" + P_7(val) + "\"") : "");
							num2 = 1085505560;
							continue;
						}
						case 10:
							num4++;
							num2 = 1085505546;
							continue;
						case 17:
							Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + ".");
							num2 = 1085505539;
							continue;
						case 8:
							P_5.Find(eVfxbxOWQdTLdGxYDUlDkqWPWbM.ajzMiRcBrodRzUKWuQrxNbqNONE).RCOauDZdeEvGkaCTeYBvkrIMFQK = hmlSsXToAwSkYbdrifQmzcAdWtk2.EDtAenTdvxqjYucNthLzuBLZlwk(val);
							num2 = 1085505545;
							continue;
						case 9:
							num2 = 1085505546;
							continue;
						case 4:
							val = P_2[num4];
							num6 = P_8(val, P_3);
							num2 = 1085505538;
							continue;
						case 18:
							break;
						case 7:
						{
							eVfxbxOWQdTLdGxYDUlDkqWPWbM.BWzPwbaZSKggeAeMrnMfdCEIFcc = hmlSsXToAwSkYbdrifQmzcAdWtk2;
							T finalItem = P_3[num6];
							eVfxbxOWQdTLdGxYDUlDkqWPWbM.hblKmXrIybUsjuWnbrpAiWaScrm = P_9(new lHFDDWjVDcRlOAZjbSJDfSQYpREQ<T>(val, finalItem, zfpmTQonvrTjOJqbUbEUKlTCqdf.WShhClxzwcSZIyaMxWChyIpnurx.RCOauDZdeEvGkaCTeYBvkrIMFQK, P_3, true));
							num2 = 1085505537;
							continue;
						}
						case 0:
						{
							string text2 = ((!string.IsNullOrEmpty(P_7(val))) ? ("\"" + P_7(val) + "\"") : "");
							Logger.Log(P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + " already exists. Imported data will replace original.");
							num2 = 1085505539;
							continue;
						}
						case 3:
						{
							int num7;
							if (num4 < P_2.Count)
							{
								num2 = 1085505549;
								num7 = num2;
							}
							else
							{
								num2 = 1085505541;
								num7 = num2;
							}
							continue;
						}
						case 11:
							if (num6 >= 0)
							{
								eVfxbxOWQdTLdGxYDUlDkqWPWbM = new EVfxbxOWQdTLdGxYDUlDkqWPWbM<T>();
								num2 = 1085505550;
								continue;
							}
							goto case 1;
						case 13:
							P_5.Add(new zfpmTQonvrTjOJqbUbEUKlTCqdf(hmlSsXToAwSkYbdrifQmzcAdWtk2.EDtAenTdvxqjYucNthLzuBLZlwk(val2), -1, hmlSsXToAwSkYbdrifQmzcAdWtk2.EDtAenTdvxqjYucNthLzuBLZlwk(val2)));
							num2 = 1085505542;
							continue;
						case 16:
						{
							int num5;
							if (!P_4)
							{
								num2 = 1085505543;
								num5 = num2;
							}
							else
							{
								num2 = 1085505540;
								num5 = num2;
							}
							continue;
						}
						case 15:
							num++;
							num2 = 1085505563;
							continue;
						case 6:
							val2 = P_1[num];
							num2 = 1085505561;
							continue;
						case 2:
							if (P_2 != null)
							{
								num4 = 0;
								num2 = 1085505536;
								continue;
							}
							return;
						case 12:
							return;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int MMmpPoSXbkzDRWIFZndjzCTeJpZ(InputCategory P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string poCnGWyLnFcjbyVCMFVsvnMLVuk(InputCategory P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int ngGMDsbPgPSKdJnRaUvesdVfiFe(InputCategory P_0, IList<InputCategory> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= P_1.Count)
					{
						num2 = -2035645129;
						num3 = num2;
					}
					else
					{
						num2 = -2035645131;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -2035645129)
						{
						case 3:
							num2 = -2035645131;
							continue;
						case 2:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = -2035645130;
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
			private static int VYzYZlLxnbjwomfVfoAtvhENxdw(InputBehavior P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string LiMalwhMJDPKUCEVqZUacRUbdtDv(InputBehavior P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int wvGhduFQgTSqGMQlWvTTDpviesT(InputBehavior P_0, IList<InputBehavior> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						int num2;
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							num2 = 514224246;
						}
						else
						{
							num++;
							num2 = 514224247;
						}
						while (true)
						{
							switch (num2 ^ 0x1EA67074)
							{
							case 0:
								num2 = 514224245;
								continue;
							case 1:
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

			[CompilerGenerated]
			private static int rWpQtfEsNzJcCJTmXrrNzdlOepQ(InputAction P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string nGmlYUXwVzsuzzctoHxgxTYhufR(InputAction P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int mkKOVGmNeNxyugADMMMxOylSLSi(InputAction P_0, IList<InputAction> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = -1926048808;
					while (true)
					{
						switch (num2 ^ -1926048807)
						{
						case 2:
							break;
						case 0:
							return num;
						case 4:
							if (!string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								num++;
								num2 = -1926048806;
							}
							else
							{
								num2 = -1926048807;
							}
							continue;
						case 1:
							num2 = -1926048806;
							continue;
						default:
							if (num >= P_1.Count)
							{
								return -1;
							}
							goto case 4;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int ylypoZVMaCkOOMJBxKFGFcAYMFE(InputMapCategory P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string eGETFiaUXGgTAyGPYxWdicgmvkU(InputMapCategory P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int NfgiKwrgFVvMYnhCAkxSZfAoVDj(InputMapCategory P_0, IList<InputMapCategory> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						int num2;
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							num2 = -691502512;
						}
						else
						{
							num++;
							num2 = -691502509;
						}
						while (true)
						{
							switch (num2 ^ -691502511)
							{
							case 0:
								num2 = -691502510;
								continue;
							case 3:
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

			[CompilerGenerated]
			private static int ZyoawADGFePaqFdZUlkzeEiCbscR(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string IKRIgczivxGbAiLaBynyFRtbImkg(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int agTIbzehkWhQBAbRLemCMPXeYika(InputLayout P_0, IList<InputLayout> P_1)
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
						int num2 = -723992909;
						while (true)
						{
							switch (num2 ^ -723992909)
							{
							case 2:
								num2 = -723992910;
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
			private static int eGXAKTCySlZEQDCoISLoRznhaxfQ(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string ZgnfMoaAJWCHyEryaixxvKUvxAW(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int bBleNCAKgFaVpOmrdlmlrLbQwYS(InputLayout P_0, IList<InputLayout> P_1)
			{
				int num = 0;
				while (num < P_1.Count)
				{
					while (true)
					{
						int num2;
						if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
						{
							num2 = 1915712044;
						}
						else
						{
							num++;
							num2 = 1915712045;
						}
						while (true)
						{
							switch (num2 ^ 0x722F722E)
							{
							case 0:
								num2 = 1915712047;
								continue;
							case 1:
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

			[CompilerGenerated]
			private static int mSpifnRqLJHsqZERleKcbRoriVHm(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string ITecziMDWabsrhzoekiSmApuNNQn(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int VTzRLYJPDzACRbVMhoFoeZOhErsG(InputLayout P_0, IList<InputLayout> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < P_1.Count)
					{
						num2 = 471916563;
						num3 = num2;
					}
					else
					{
						num2 = 471916566;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x1C20E012)
						{
						case 3:
							num2 = 471916563;
							continue;
						case 1:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								num2 = 471916560;
								continue;
							}
							num++;
							num2 = 471916562;
							continue;
						case 2:
							return num;
						case 0:
							break;
						default:
							return -1;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int ouNERQbjwnAEJjbeCPnBNalFLwB(InputLayout P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string udOtNYrpMgoRBngdhlLiKyiebkd(InputLayout P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int UoGIAiAcvYdOlvSyFGJhDfDrjNRi(InputLayout P_0, IList<InputLayout> P_1)
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
						int num2 = -653523450;
						while (true)
						{
							switch (num2 ^ -653523452)
							{
							case 0:
								num2 = -653523451;
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
			private static int bcWjtynldSYCQEvIUVvzmRTjIuk(CustomController_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string dFTcYdfvePHDJJnubMYbhgCScPih(CustomController_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int bvsBHiZtQyFFSMPgRZPkoqlymlF(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = 1336554841;
					while (true)
					{
						switch (num2 ^ 0x4FAA355B)
						{
						case 4:
							break;
						case 2:
							num2 = 1336554843;
							continue;
						case 5:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								num2 = 1336554842;
								continue;
							}
							num++;
							num2 = 1336554843;
							continue;
						case 0:
						{
							int num3;
							if (num < P_1.Count)
							{
								num2 = 1336554846;
								num3 = num2;
							}
							else
							{
								num2 = 1336554840;
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

			[CompilerGenerated]
			private static int UxIVwHghTFAMqqvtDbCvQCnKulc(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string xvZLjKXmKpYLZQCkNEKRSXACIhta(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int aPGlUQjEXyjNhlzEYusQGAkuis(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
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
						int num2 = -1673896669;
						while (true)
						{
							switch (num2 ^ -1673896669)
							{
							case 2:
								num2 = -1673896670;
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
			private static int SeTjzuOOXWANOrMRBdCvnkCjhku(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string uhyKZgzMiOAMdYkoaHKpFoFCqqSB(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int JjZmOGtNknUlEUNHPHCWhmQfXGjt(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
			{
				int num = 0;
				while (true)
				{
					int num2 = 778101316;
					while (true)
					{
						switch (num2 ^ 0x2E60E246)
						{
						case 3:
							break;
						case 2:
							num2 = 778101318;
							continue;
						case 1:
							if (string.Equals(P_0.name, P_1[num].name, StringComparison.OrdinalIgnoreCase))
							{
								return num;
							}
							num++;
							num2 = 778101318;
							continue;
						default:
							if (num >= P_1.Count)
							{
								return -1;
							}
							goto case 1;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static int lHZDZyNxSpmbeiuEcJAGqJGBgoTa(Player_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string TtppxpzgNwjVDYkfCflubwQFmXEa(Player_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int TrDabnERVLiJlekkHOUtaAiCIUPk(Player_Editor P_0, IList<Player_Editor> P_1)
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
						int num2 = 540244469;
						while (true)
						{
							switch (num2 ^ 0x203379F5)
							{
							case 2:
								num2 = 540244468;
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
			private static int YyGBhhvTWevlOSBghQsUKBuQCHj(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string xMOAFwpLevIsiJWHPQmGBEkygqw(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int GQWewfkhBhFOejIQvMdEiatNOgcW(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string LGljRtLzGBCtzoNmLwMkTeYSIXg(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int pcInByuLneOETcLuunbjJghyAxdd(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string FaIHlLEHfJJGdhtLjfisBlWBNAhn(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			[CompilerGenerated]
			private static int butrLvobTwDqlaChFmcuNUMJlnRV(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			[CompilerGenerated]
			private static string gqUdWZIcOBXsHlaqFtPodzMiChf(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}
		}

		private sealed class FMYHvlAirbLdntWFjAcQhLIDphg : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public string NOJlkeauWKQIBZKjVcBnYCWUgkB;

			public string wSagivdJDpAKobJbTLYNmfxUdevu;

			public int JgkqHoXbaGSqSpATxoAvQPPuCvQ;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_0053;
				IL_0012:
				int num = -2104304233;
				goto IL_0017;
				IL_0017:
				FMYHvlAirbLdntWFjAcQhLIDphg fMYHvlAirbLdntWFjAcQhLIDphg = default(FMYHvlAirbLdntWFjAcQhLIDphg);
				while (true)
				{
					switch (num ^ -2104304237)
					{
					case 0:
						break;
					case 4:
						goto IL_0038;
					case 2:
						goto IL_0053;
					case 3:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						fMYHvlAirbLdntWFjAcQhLIDphg = this;
						num = -2104304238;
						continue;
					default:
						fMYHvlAirbLdntWFjAcQhLIDphg.NOJlkeauWKQIBZKjVcBnYCWUgkB = wSagivdJDpAKobJbTLYNmfxUdevu;
						return fMYHvlAirbLdntWFjAcQhLIDphg;
					}
					break;
					IL_0038:
					int num2;
					if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg != -2)
					{
						num = -2104304239;
						num2 = num;
					}
					else
					{
						num = -2104304240;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_0053:
				fMYHvlAirbLdntWFjAcQhLIDphg = new FMYHvlAirbLdntWFjAcQhLIDphg(0);
				fMYHvlAirbLdntWFjAcQhLIDphg.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = -2104304238;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = -1275970258;
					goto IL_001f;
				case 0:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (NOJlkeauWKQIBZKjVcBnYCWUgkB == null)
						{
							break;
						}
						int num4;
						if (!(NOJlkeauWKQIBZKjVcBnYCWUgkB == string.Empty))
						{
							num = -1275970261;
							num4 = num;
						}
						else
						{
							num = -1275970259;
							num4 = num;
						}
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -1275970264)
						{
						case 0:
							num = -1275970257;
							continue;
						case 2:
							JgkqHoXbaGSqSpATxoAvQPPuCvQ = 0;
							num = -1275970260;
							continue;
						case 3:
							break;
						case 1:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories[JgkqHoXbaGSqSpATxoAvQPPuCvQ].tag.Equals(NOJlkeauWKQIBZKjVcBnYCWUgkB, StringComparison.OrdinalIgnoreCase))
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories[JgkqHoXbaGSqSpATxoAvQPPuCvQ];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							}
							goto case 6;
						case 6:
							JgkqHoXbaGSqSpATxoAvQPPuCvQ++;
							num = -1275970260;
							continue;
						case 7:
							goto end_IL_001f;
						case 4:
							goto IL_0127;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories != null)
						{
							num = -1275970262;
							num2 = num;
						}
						else
						{
							num = -1275970259;
							num2 = num;
						}
						continue;
						IL_0127:
						int num3;
						if (JgkqHoXbaGSqSpATxoAvQPPuCvQ < iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories.Count)
						{
							num = -1275970263;
							num3 = num;
						}
						else
						{
							num = -1275970259;
							num3 = num;
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
			public FMYHvlAirbLdntWFjAcQhLIDphg(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class NwjjXtLLfeKVmPGmmPGbNBmWAfX : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int ZeVdSxGRjjMJrWvXcGQSyIacEUNe;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_006e;
				IL_0012:
				int num = -784603297;
				goto IL_0017;
				IL_0017:
				NwjjXtLLfeKVmPGmmPGbNBmWAfX nwjjXtLLfeKVmPGmmPGbNBmWAfX = default(NwjjXtLLfeKVmPGmmPGbNBmWAfX);
				while (true)
				{
					switch (num ^ -784603301)
					{
					case 3:
						break;
					case 0:
						num = -784603303;
						continue;
					case 1:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						nwjjXtLLfeKVmPGmmPGbNBmWAfX = this;
						num = -784603301;
						continue;
					case 4:
						goto IL_0053;
					case 5:
						goto IL_006e;
					default:
						return nwjjXtLLfeKVmPGmmPGbNBmWAfX;
					}
					break;
					IL_0053:
					int num2;
					if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg != -2)
					{
						num = -784603298;
						num2 = num;
					}
					else
					{
						num = -784603302;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_006e:
				nwjjXtLLfeKVmPGmmPGbNBmWAfX = new NwjjXtLLfeKVmPGmmPGbNBmWAfX(0);
				nwjjXtLLfeKVmPGmmPGbNBmWAfX.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = -784603303;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 0:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = -1786961893;
					goto IL_001f;
				case 1:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -1786961894;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -1786961895)
						{
						case 0:
							num = -1786961889;
							continue;
						case 6:
							break;
						case 7:
							num = -1786961891;
							continue;
						case 5:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories[ZeVdSxGRjjMJrWvXcGQSyIacEUNe].userAssignable)
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories[ZeVdSxGRjjMJrWvXcGQSyIacEUNe];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							}
							goto case 3;
						case 2:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories != null)
							{
								ZeVdSxGRjjMJrWvXcGQSyIacEUNe = 0;
								num = -1786961890;
								continue;
							}
							goto end_IL_0008;
						case 3:
							ZeVdSxGRjjMJrWvXcGQSyIacEUNe++;
							num = -1786961891;
							continue;
						case 4:
							goto IL_00ed;
						default:
							goto end_IL_0008;
						}
						break;
						IL_00ed:
						int num2;
						if (ZeVdSxGRjjMJrWvXcGQSyIacEUNe < iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories.Count)
						{
							num = -1786961892;
							num2 = num;
						}
						else
						{
							num = -1786961896;
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
			public NwjjXtLLfeKVmPGmmPGbNBmWAfX(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class lFLiQCQYpnTnibyQYTvRFPOAuqw : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private InputMapCategory aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public string NOJlkeauWKQIBZKjVcBnYCWUgkB;

			public string wSagivdJDpAKobJbTLYNmfxUdevu;

			public int CsnGvaaZfErWvdsXWUqxDPbgEcO;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_004f;
				IL_0012:
				int num = 897618163;
				goto IL_0017;
				IL_0017:
				lFLiQCQYpnTnibyQYTvRFPOAuqw lFLiQCQYpnTnibyQYTvRFPOAuqw2 = default(lFLiQCQYpnTnibyQYTvRFPOAuqw);
				while (true)
				{
					switch (num ^ 0x358090F1)
					{
					case 4:
						break;
					case 0:
						lFLiQCQYpnTnibyQYTvRFPOAuqw2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = 897618160;
						continue;
					case 3:
						goto IL_004f;
					case 5:
						num = 897618160;
						continue;
					case 2:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							lFLiQCQYpnTnibyQYTvRFPOAuqw2 = this;
							num = 897618164;
							continue;
						}
						goto IL_004f;
					default:
						lFLiQCQYpnTnibyQYTvRFPOAuqw2.NOJlkeauWKQIBZKjVcBnYCWUgkB = wSagivdJDpAKobJbTLYNmfxUdevu;
						return lFLiQCQYpnTnibyQYTvRFPOAuqw2;
					}
					break;
				}
				goto IL_0012;
				IL_004f:
				lFLiQCQYpnTnibyQYTvRFPOAuqw2 = new lFLiQCQYpnTnibyQYTvRFPOAuqw(0);
				num = 897618161;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = -302611002;
					goto IL_001f;
				case 0:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (NOJlkeauWKQIBZKjVcBnYCWUgkB == null)
						{
							break;
						}
						int num5;
						if (!(NOJlkeauWKQIBZKjVcBnYCWUgkB == string.Empty))
						{
							num = -302610996;
							num5 = num;
						}
						else
						{
							num = -302611001;
							num5 = num;
						}
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -302611004)
						{
						case 0:
							num = -302611008;
							continue;
						case 6:
							aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories[CsnGvaaZfErWvdsXWUqxDPbgEcO];
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 5:
							break;
						case 4:
							goto end_IL_001f;
						case 8:
							goto IL_00ea;
						case 7:
							CsnGvaaZfErWvdsXWUqxDPbgEcO = 0;
							num = -302611007;
							continue;
						case 2:
							CsnGvaaZfErWvdsXWUqxDPbgEcO++;
							num = -302611007;
							continue;
						case 1:
							if (!iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories[CsnGvaaZfErWvdsXWUqxDPbgEcO].userAssignable)
							{
								goto case 2;
							}
							goto IL_0151;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (CsnGvaaZfErWvdsXWUqxDPbgEcO < iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories.Count)
						{
							num = -302611003;
							num2 = num;
						}
						else
						{
							num = -302611001;
							num2 = num;
						}
						continue;
						IL_0151:
						int num3;
						if (!iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories[CsnGvaaZfErWvdsXWUqxDPbgEcO].tag.Equals(NOJlkeauWKQIBZKjVcBnYCWUgkB, StringComparison.OrdinalIgnoreCase))
						{
							num = -302611002;
							num3 = num;
						}
						else
						{
							num = -302611006;
							num3 = num;
						}
						continue;
						IL_00ea:
						int num4;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.mapCategories != null)
						{
							num = -302611005;
							num4 = num;
						}
						else
						{
							num = -302611001;
							num4 = num;
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
			public lFLiQCQYpnTnibyQYTvRFPOAuqw(int _003C_003E1__state)
			{
				while (true)
				{
					int num = -153093130;
					while (true)
					{
						switch (num ^ -153093129)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
							return;
						}
						break;
						IL_0024:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						num = -153093131;
					}
				}
			}
		}

		private sealed class xyOPbJLpaAxdwPlBIJsTdMoTybU : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public string NOJlkeauWKQIBZKjVcBnYCWUgkB;

			public string wSagivdJDpAKobJbTLYNmfxUdevu;

			public int WdvWtGoywoQvjONPiACYEotWNpRB;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				xyOPbJLpaAxdwPlBIJsTdMoTybU xyOPbJLpaAxdwPlBIJsTdMoTybU2;
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					xyOPbJLpaAxdwPlBIJsTdMoTybU2 = this;
					goto IL_0025;
				}
				goto IL_004e;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ -1060963221)
					{
					case 0:
						break;
					case 2:
						num = -1060963224;
						continue;
					case 1:
						goto IL_004e;
					default:
						xyOPbJLpaAxdwPlBIJsTdMoTybU2.NOJlkeauWKQIBZKjVcBnYCWUgkB = wSagivdJDpAKobJbTLYNmfxUdevu;
						return xyOPbJLpaAxdwPlBIJsTdMoTybU2;
					}
					break;
				}
				goto IL_0025;
				IL_004e:
				xyOPbJLpaAxdwPlBIJsTdMoTybU2 = new xyOPbJLpaAxdwPlBIJsTdMoTybU(0);
				xyOPbJLpaAxdwPlBIJsTdMoTybU2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = -1060963224;
				goto IL_002a;
				IL_0025:
				num = -1060963223;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = 16540387;
					while (true)
					{
						switch (num2 ^ 0xFC62E1)
						{
						case 3:
							break;
						case 2:
							switch (num)
							{
							default:
								num2 = 16540389;
								continue;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = 16540384;
								continue;
							case 0:
								break;
							}
							goto case 7;
						case 0:
							num2 = 16540391;
							continue;
						case 5:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories[WdvWtGoywoQvjONPiACYEotWNpRB].tag.Equals(NOJlkeauWKQIBZKjVcBnYCWUgkB, StringComparison.OrdinalIgnoreCase))
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories[WdvWtGoywoQvjONPiACYEotWNpRB];
								num2 = 16540393;
								continue;
							}
							goto case 1;
						case 9:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories != null)
							{
								WdvWtGoywoQvjONPiACYEotWNpRB = 0;
								num2 = 16540385;
								continue;
							}
							goto default;
						case 8:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 7:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (NOJlkeauWKQIBZKjVcBnYCWUgkB != null)
							{
								int num4;
								if (!(NOJlkeauWKQIBZKjVcBnYCWUgkB == string.Empty))
								{
									num2 = 16540392;
									num4 = num2;
								}
								else
								{
									num2 = 16540389;
									num4 = num2;
								}
								continue;
							}
							goto default;
						case 1:
							WdvWtGoywoQvjONPiACYEotWNpRB++;
							num2 = 16540391;
							continue;
						case 6:
						{
							int num3;
							if (WdvWtGoywoQvjONPiACYEotWNpRB < iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories.Count)
							{
								num2 = 16540388;
								num3 = num2;
							}
							else
							{
								num2 = 16540389;
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
			public xyOPbJLpaAxdwPlBIJsTdMoTybU(int _003C_003E1__state)
			{
				while (true)
				{
					int num = 630118672;
					while (true)
					{
						switch (num ^ 0x258ED913)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
							num = 630118673;
							continue;
						case 2:
							HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
							num = 630118674;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		private sealed class VdjfRHriXqCxIvwAiOEqrsZqWOL : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int dWmdckaMGYdQPukrIExUoxXQsSo;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_003c;
				IL_0012:
				int num = 1231901303;
				goto IL_0017;
				IL_0017:
				VdjfRHriXqCxIvwAiOEqrsZqWOL vdjfRHriXqCxIvwAiOEqrsZqWOL = default(VdjfRHriXqCxIvwAiOEqrsZqWOL);
				while (true)
				{
					switch (num ^ 0x496D5273)
					{
					case 3:
						break;
					case 5:
						goto IL_003c;
					case 0:
						vdjfRHriXqCxIvwAiOEqrsZqWOL = this;
						num = 1231901297;
						continue;
					case 4:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							num = 1231901299;
							continue;
						}
						goto IL_003c;
					case 1:
						vdjfRHriXqCxIvwAiOEqrsZqWOL.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = 1231901297;
						continue;
					default:
						return vdjfRHriXqCxIvwAiOEqrsZqWOL;
					}
					break;
				}
				goto IL_0012;
				IL_003c:
				vdjfRHriXqCxIvwAiOEqrsZqWOL = new VdjfRHriXqCxIvwAiOEqrsZqWOL(0);
				num = 1231901298;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = -1478745675;
					while (true)
					{
						switch (num2 ^ -1478745676)
						{
						case 7:
							break;
						case 0:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories[dWmdckaMGYdQPukrIExUoxXQsSo].userAssignable)
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories[dWmdckaMGYdQPukrIExUoxXQsSo];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							}
							goto case 2;
						case 3:
							num2 = -1478745679;
							continue;
						case 4:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories != null)
							{
								dWmdckaMGYdQPukrIExUoxXQsSo = 0;
								num2 = -1478745678;
								continue;
							}
							goto default;
						case 6:
						{
							int num3;
							if (dWmdckaMGYdQPukrIExUoxXQsSo < iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories.Count)
							{
								num2 = -1478745676;
								num3 = num2;
							}
							else
							{
								num2 = -1478745679;
								num3 = num2;
							}
							continue;
						}
						case 2:
							dWmdckaMGYdQPukrIExUoxXQsSo++;
							num2 = -1478745678;
							continue;
						case 1:
							switch (num)
							{
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = -1478745674;
								continue;
							case 0:
								break;
							default:
								num2 = -1478745673;
								continue;
							}
							goto case 4;
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
			public VdjfRHriXqCxIvwAiOEqrsZqWOL(int _003C_003E1__state)
			{
				while (true)
				{
					int num = -324306344;
					while (true)
					{
						switch (num ^ -324306343)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
							num = -324306343;
							continue;
						case 0:
							HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
							num = -324306341;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		private sealed class dBohIEOoTQrNIbDNXTvDJHjQcbKG : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private InputCategory aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public string NOJlkeauWKQIBZKjVcBnYCWUgkB;

			public string wSagivdJDpAKobJbTLYNmfxUdevu;

			public int IfxEPNsgwKLAgBzYwMXEcTIcoZK;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					goto IL_001c;
				}
				goto IL_0065;
				IL_0065:
				dBohIEOoTQrNIbDNXTvDJHjQcbKG dBohIEOoTQrNIbDNXTvDJHjQcbKG2 = new dBohIEOoTQrNIbDNXTvDJHjQcbKG(0);
				dBohIEOoTQrNIbDNXTvDJHjQcbKG2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				int num = 983079580;
				goto IL_0021;
				IL_001c:
				num = 983079577;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x3A989A9D)
					{
					case 2:
						break;
					case 4:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						dBohIEOoTQrNIbDNXTvDJHjQcbKG2 = this;
						num = 983079580;
						continue;
					case 1:
						dBohIEOoTQrNIbDNXTvDJHjQcbKG2.NOJlkeauWKQIBZKjVcBnYCWUgkB = wSagivdJDpAKobJbTLYNmfxUdevu;
						num = 983079582;
						continue;
					case 0:
						goto IL_0065;
					default:
						return dBohIEOoTQrNIbDNXTvDJHjQcbKG2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = 844931559;
					while (true)
					{
						switch (num2 ^ 0x325CA1E5)
						{
						case 0:
							break;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (NOJlkeauWKQIBZKjVcBnYCWUgkB != null && !(NOJlkeauWKQIBZKjVcBnYCWUgkB == string.Empty) && iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories != null)
							{
								IfxEPNsgwKLAgBzYwMXEcTIcoZK = 0;
								num2 = 844931558;
								continue;
							}
							goto default;
						case 7:
							IfxEPNsgwKLAgBzYwMXEcTIcoZK++;
							num2 = 844931558;
							continue;
						case 2:
							switch (num)
							{
							case 0:
								break;
							default:
								num2 = 844931555;
								continue;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = 844931554;
								continue;
							}
							goto case 1;
						case 6:
							num2 = 844931553;
							continue;
						case 3:
						{
							int num3;
							if (IfxEPNsgwKLAgBzYwMXEcTIcoZK >= iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories.Count)
							{
								num2 = 844931553;
								num3 = num2;
							}
							else
							{
								num2 = 844931552;
								num3 = num2;
							}
							continue;
						}
						case 5:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories[IfxEPNsgwKLAgBzYwMXEcTIcoZK].userAssignable && iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories[IfxEPNsgwKLAgBzYwMXEcTIcoZK].tag.Equals(NOJlkeauWKQIBZKjVcBnYCWUgkB, StringComparison.OrdinalIgnoreCase))
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories[IfxEPNsgwKLAgBzYwMXEcTIcoZK];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							}
							goto case 7;
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
			public dBohIEOoTQrNIbDNXTvDJHjQcbKG(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class eDuazNopbBQacwhaiQMraCkggET : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int CTaGrwelATNDxtzHYwIogcoyFfKE;

			public InputAction HFXSMAojtNNGnZTRglzyoqsWzSJ;

			public InputCategory IcDFPfYiGCbutTEqzoFuPkcERvR;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					goto IL_001c;
				}
				goto IL_0052;
				IL_0052:
				eDuazNopbBQacwhaiQMraCkggET eDuazNopbBQacwhaiQMraCkggET2 = new eDuazNopbBQacwhaiQMraCkggET(0);
				eDuazNopbBQacwhaiQMraCkggET2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				int num = 1611683992;
				goto IL_0021;
				IL_001c:
				num = 1611683995;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x60105898)
					{
					case 4:
						break;
					case 3:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						eDuazNopbBQacwhaiQMraCkggET2 = this;
						num = 1611683993;
						continue;
					case 2:
						goto IL_0052;
					case 1:
						num = 1611683992;
						continue;
					default:
						return eDuazNopbBQacwhaiQMraCkggET2;
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
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				default:
					num = 1556305614;
					goto IL_001a;
				case 1:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = 1556305612;
					goto IL_001a;
				case 0:
					goto IL_0070;
					IL_001a:
					while (true)
					{
						switch (num ^ 0x5CC356C9)
						{
						case 3:
							break;
						case 7:
							num = 1556305601;
							continue;
						case 6:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 9:
							goto IL_0070;
						case 5:
							CTaGrwelATNDxtzHYwIogcoyFfKE++;
							num = 1556305613;
							continue;
						case 0:
							goto IL_00ad;
						case 4:
							goto IL_0101;
						case 1:
							goto IL_012d;
						case 2:
							if (HFXSMAojtNNGnZTRglzyoqsWzSJ.userAssignable)
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = HFXSMAojtNNGnZTRglzyoqsWzSJ;
								num = 1556305615;
								continue;
							}
							goto case 5;
						default:
							goto end_IL_0008;
						}
						break;
						IL_012d:
						int num2;
						if (IcDFPfYiGCbutTEqzoFuPkcERvR.userAssignable)
						{
							num = 1556305611;
							num2 = num;
						}
						else
						{
							num = 1556305612;
							num2 = num;
						}
						continue;
						IL_0101:
						int num3;
						if (CTaGrwelATNDxtzHYwIogcoyFfKE >= iKQXbXnVtIaMZEJNeigQJWAHqUx.actions.Count)
						{
							num = 1556305601;
							num3 = num;
						}
						else
						{
							num = 1556305609;
							num3 = num;
						}
						continue;
						IL_00ad:
						HFXSMAojtNNGnZTRglzyoqsWzSJ = iKQXbXnVtIaMZEJNeigQJWAHqUx.actions[CTaGrwelATNDxtzHYwIogcoyFfKE];
						IcDFPfYiGCbutTEqzoFuPkcERvR = iKQXbXnVtIaMZEJNeigQJWAHqUx.GetActionCategoryById(HFXSMAojtNNGnZTRglzyoqsWzSJ.categoryId);
						int num4;
						if (IcDFPfYiGCbutTEqzoFuPkcERvR != null)
						{
							num = 1556305608;
							num4 = num;
						}
						else
						{
							num = 1556305612;
							num4 = num;
						}
					}
					goto default;
					IL_0070:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actions == null)
					{
						break;
					}
					CTaGrwelATNDxtzHYwIogcoyFfKE = 0;
					num = 1556305613;
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
			public eDuazNopbBQacwhaiQMraCkggET(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class XQOnvqAfuPNsjmRoSNeUlAXIGIu : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int RqvRhFbuodTKUwYPssXTimWBfVF;

			public int xuffIzkVdMgTYNPpaleAZUCNIqtN;

			public bool gYLXlJfwJlVtdKZnhkGpMDGTPqX;

			public bool uYpfxJpDlUgbkKhLiqpIreyGqeb;

			public int InjUUPlBaNYRWdrcZuStxNWzkKA;

			public InputAction RCcaQceWSgyxeBhiIaRtASqntBaT;

			public int NkkHtkrtrSxLxJBLYEoBGGBvSQQ;

			public IEnumerator<int> xcYMpMAxhHEfSucEKzunffBHLkF;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_0040;
				IL_0012:
				int num = 1460865474;
				goto IL_0017;
				IL_0017:
				XQOnvqAfuPNsjmRoSNeUlAXIGIu xQOnvqAfuPNsjmRoSNeUlAXIGIu = default(XQOnvqAfuPNsjmRoSNeUlAXIGIu);
				while (true)
				{
					switch (num ^ 0x571309C3)
					{
					case 2:
						break;
					case 5:
						goto IL_0040;
					case 3:
						xQOnvqAfuPNsjmRoSNeUlAXIGIu.RqvRhFbuodTKUwYPssXTimWBfVF = xuffIzkVdMgTYNPpaleAZUCNIqtN;
						xQOnvqAfuPNsjmRoSNeUlAXIGIu.gYLXlJfwJlVtdKZnhkGpMDGTPqX = uYpfxJpDlUgbkKhLiqpIreyGqeb;
						num = 1460865475;
						continue;
					case 4:
						num = 1460865472;
						continue;
					case 1:
						goto IL_0080;
					case 6:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						xQOnvqAfuPNsjmRoSNeUlAXIGIu = this;
						num = 1460865479;
						continue;
					default:
						return xQOnvqAfuPNsjmRoSNeUlAXIGIu;
					}
					break;
					IL_0080:
					int num2;
					if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
					{
						num = 1460865477;
						num2 = num;
					}
					else
					{
						num = 1460865478;
						num2 = num;
					}
				}
				goto IL_0012;
				IL_0040:
				xQOnvqAfuPNsjmRoSNeUlAXIGIu = new XQOnvqAfuPNsjmRoSNeUlAXIGIu(0);
				xQOnvqAfuPNsjmRoSNeUlAXIGIu.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = 1460865472;
				goto IL_0017;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					default:
						goto IL_0074;
					case 0:
						goto IL_0194;
					case 3:
						goto IL_01b6;
					case 2:
						goto IL_01df;
						IL_0074:
						result = false;
						num = 1883396840;
						goto IL_0024;
						IL_0024:
						while (true)
						{
							switch (num ^ 0x70425AE6)
							{
							case 0:
								num = 1883396841;
								continue;
							case 7:
								goto IL_0074;
							case 1:
								InjUUPlBaNYRWdrcZuStxNWzkKA = xcYMpMAxhHEfSucEKzunffBHLkF.Current;
								RCcaQceWSgyxeBhiIaRtASqntBaT = iKQXbXnVtIaMZEJNeigQJWAHqUx.GetActionById(InjUUPlBaNYRWdrcZuStxNWzkKA);
								if (RCcaQceWSgyxeBhiIaRtASqntBaT != null)
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = RCcaQceWSgyxeBhiIaRtASqntBaT;
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
									num = 1883396837;
									continue;
								}
								goto case 12;
							case 9:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actions == null || iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories == null)
								{
									goto IL_0074;
								}
								if (gYLXlJfwJlVtdKZnhkGpMDGTPqX)
								{
									xcYMpMAxhHEfSucEKzunffBHLkF = iKQXbXnVtIaMZEJNeigQJWAHqUx.SortedActionIdsInCategory(RqvRhFbuodTKUwYPssXTimWBfVF).GetEnumerator();
									num = 1883396836;
									continue;
								}
								goto case 10;
							case 10:
								NkkHtkrtrSxLxJBLYEoBGGBvSQQ = 0;
								num = 1883396835;
								continue;
							case 3:
								result = true;
								break;
							case 12:
								if (!xcYMpMAxhHEfSucEKzunffBHLkF.MoveNext())
								{
									NkzuZBmcZzvzKyTnBefQXdiWpGg();
									num = 1883396833;
									continue;
								}
								goto case 1;
							case 5:
								goto IL_0157;
							case 2:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = 1883396842;
								continue;
							case 15:
								goto IL_0194;
							case 6:
								result = true;
								break;
							case 11:
								goto IL_01b6;
							case 13:
								NkkHtkrtrSxLxJBLYEoBGGBvSQQ++;
								num = 1883396835;
								continue;
							case 8:
								goto IL_01df;
							case 4:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actions[NkkHtkrtrSxLxJBLYEoBGGBvSQQ].categoryId == RqvRhFbuodTKUwYPssXTimWBfVF)
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.actions[NkkHtkrtrSxLxJBLYEoBGGBvSQQ];
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
									num = 1883396832;
									continue;
								}
								goto case 13;
							case 14:
								break;
							}
							break;
							IL_0157:
							int num2;
							if (NkkHtkrtrSxLxJBLYEoBGGBvSQQ < iKQXbXnVtIaMZEJNeigQJWAHqUx.actions.Count)
							{
								num = 1883396834;
								num2 = num;
							}
							else
							{
								num = 1883396833;
								num2 = num;
							}
						}
						break;
						IL_01df:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = 1883396842;
						goto IL_0024;
						IL_01b6:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 1883396843;
						goto IL_0024;
						IL_0194:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 1883396847;
						goto IL_0024;
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
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						NkzuZBmcZzvzKyTnBefQXdiWpGg();
					}
				}
			}

			[DebuggerHidden]
			public XQOnvqAfuPNsjmRoSNeUlAXIGIu(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void NkzuZBmcZzvzKyTnBefQXdiWpGg()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (xcYMpMAxhHEfSucEKzunffBHLkF != null)
				{
					xcYMpMAxhHEfSucEKzunffBHLkF.Dispose();
				}
			}
		}

		private sealed class RjevAQBMDvenJqSyfdgBffSjEKOB : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public string aonNNQmLOZrGsfBTYWbhQEslvlp;

			public string fDJRiZlkTwCJwijoUoacqalnNias;

			public bool gYLXlJfwJlVtdKZnhkGpMDGTPqX;

			public bool uYpfxJpDlUgbkKhLiqpIreyGqeb;

			public int iHOCHAFHcOnhpxjwJVVGxkLVkWV;

			public InputCategory ZGWipswCwnCtxxTNtXADOhLAiKEh;

			public int fmTVWfyDEcflbOIePGWwjatPMed;

			public InputAction uMgOdayKTUGJAezioyXkKiAaHDje;

			public int lnTrFYNctSGsJnBlDyQGhaFDIiE;

			public IEnumerator<int> gOXDEJFRiopEFtrenfGxPdlYIvn;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_0069;
				IL_0012:
				int num = 1471049534;
				goto IL_0017;
				IL_0017:
				RjevAQBMDvenJqSyfdgBffSjEKOB rjevAQBMDvenJqSyfdgBffSjEKOB = default(RjevAQBMDvenJqSyfdgBffSjEKOB);
				while (true)
				{
					switch (num ^ 0x57AE6F3B)
					{
					case 3:
						break;
					case 5:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							rjevAQBMDvenJqSyfdgBffSjEKOB = this;
							num = 1471049531;
							continue;
						}
						goto IL_0069;
					case 4:
						rjevAQBMDvenJqSyfdgBffSjEKOB.aonNNQmLOZrGsfBTYWbhQEslvlp = fDJRiZlkTwCJwijoUoacqalnNias;
						num = 1471049530;
						continue;
					case 2:
						goto IL_0069;
					case 0:
						num = 1471049535;
						continue;
					default:
						rjevAQBMDvenJqSyfdgBffSjEKOB.gYLXlJfwJlVtdKZnhkGpMDGTPqX = uYpfxJpDlUgbkKhLiqpIreyGqeb;
						return rjevAQBMDvenJqSyfdgBffSjEKOB;
					}
					break;
				}
				goto IL_0012;
				IL_0069:
				rjevAQBMDvenJqSyfdgBffSjEKOB = new RjevAQBMDvenJqSyfdgBffSjEKOB(0);
				rjevAQBMDvenJqSyfdgBffSjEKOB.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = 1471049535;
				goto IL_0017;
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
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					while (true)
					{
						IL_0007:
						int num2 = -308797125;
						while (true)
						{
							int num7;
							switch (num2 ^ -308797132)
							{
							case 8:
								break;
							default:
								goto end_IL_000c;
							case 15:
								switch (num)
								{
								case 3:
									goto IL_0168;
								case 0:
									goto IL_0202;
								case 2:
									goto IL_0234;
								case 1:
									goto IL_02f3;
								}
								num2 = -308797136;
								continue;
							case 12:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories != null)
								{
									int num5;
									if (aonNNQmLOZrGsfBTYWbhQEslvlp == null)
									{
										num2 = -308797136;
										num5 = num2;
									}
									else
									{
										num2 = -308797145;
										num5 = num2;
									}
									continue;
								}
								goto IL_02f3;
							case 7:
							{
								int num4;
								if (lnTrFYNctSGsJnBlDyQGhaFDIiE < iKQXbXnVtIaMZEJNeigQJWAHqUx.actions.Count)
								{
									num2 = -308797146;
									num4 = num2;
								}
								else
								{
									num2 = -308797136;
									num4 = num2;
								}
								continue;
							}
							case 3:
								iHOCHAFHcOnhpxjwJVVGxkLVkWV = iKQXbXnVtIaMZEJNeigQJWAHqUx.IndexOfActionCategory(aonNNQmLOZrGsfBTYWbhQEslvlp);
								if (iHOCHAFHcOnhpxjwJVVGxkLVkWV >= 0)
								{
									ZGWipswCwnCtxxTNtXADOhLAiKEh = iKQXbXnVtIaMZEJNeigQJWAHqUx.GetActionCategory(iHOCHAFHcOnhpxjwJVVGxkLVkWV);
									int num6;
									if (gYLXlJfwJlVtdKZnhkGpMDGTPqX)
									{
										num2 = -308797130;
										num6 = num2;
									}
									else
									{
										num2 = -308797123;
										num6 = num2;
									}
									continue;
								}
								goto IL_02f3;
							case 16:
								goto end_IL_000c;
							case 17:
								lnTrFYNctSGsJnBlDyQGhaFDIiE++;
								num2 = -308797133;
								continue;
							case 13:
								num2 = -308797133;
								continue;
							case 10:
								goto IL_0168;
							case 9:
								lnTrFYNctSGsJnBlDyQGhaFDIiE = 0;
								num2 = -308797127;
								continue;
							case 2:
								gOXDEJFRiopEFtrenfGxPdlYIvn = iKQXbXnVtIaMZEJNeigQJWAHqUx.SortedActionIdsInCategory(ZGWipswCwnCtxxTNtXADOhLAiKEh.id).GetEnumerator();
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = -308797135;
								continue;
							case 14:
								if (!gOXDEJFRiopEFtrenfGxPdlYIvn.MoveNext())
								{
									pRwrmNpfYlYeMxcLLLuQRlwaYxg();
									num2 = -308797136;
									continue;
								}
								goto case 0;
							case 19:
							{
								int num3;
								if (aonNNQmLOZrGsfBTYWbhQEslvlp == string.Empty)
								{
									num2 = -308797136;
									num3 = num2;
								}
								else
								{
									num2 = -308797129;
									num3 = num2;
								}
								continue;
							}
							case 6:
								goto IL_0202;
							case 5:
								num2 = -308797126;
								continue;
							case 1:
								goto IL_0234;
							case 18:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actions[lnTrFYNctSGsJnBlDyQGhaFDIiE].categoryId == ZGWipswCwnCtxxTNtXADOhLAiKEh.id)
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.actions[lnTrFYNctSGsJnBlDyQGhaFDIiE];
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
									result = true;
									goto end_IL_000c;
								}
								goto case 17;
							case 0:
								fmTVWfyDEcflbOIePGWwjatPMed = gOXDEJFRiopEFtrenfGxPdlYIvn.Current;
								uMgOdayKTUGJAezioyXkKiAaHDje = iKQXbXnVtIaMZEJNeigQJWAHqUx.GetActionById(fmTVWfyDEcflbOIePGWwjatPMed);
								if (uMgOdayKTUGJAezioyXkKiAaHDje != null)
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = uMgOdayKTUGJAezioyXkKiAaHDje;
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
									result = true;
									num2 = -308797148;
									continue;
								}
								goto case 14;
							case 4:
								goto IL_02f3;
							case 11:
								goto end_IL_000c;
								IL_0168:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = -308797147;
								continue;
								IL_02f3:
								result = false;
								num2 = -308797121;
								continue;
								IL_0234:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = -308797126;
								continue;
								IL_0202:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actions != null)
								{
									num2 = -308797128;
									num7 = num2;
								}
								else
								{
									num2 = -308797136;
									num7 = num2;
								}
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
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						pRwrmNpfYlYeMxcLLLuQRlwaYxg();
					}
				}
			}

			[DebuggerHidden]
			public RjevAQBMDvenJqSyfdgBffSjEKOB(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void pRwrmNpfYlYeMxcLLLuQRlwaYxg()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				while (true)
				{
					int num = -1940256701;
					while (true)
					{
						switch (num ^ -1940256702)
						{
						case 0:
							break;
						default:
							return;
						case 1:
						{
							int num2;
							if (gOXDEJFRiopEFtrenfGxPdlYIvn == null)
							{
								num = -1940256703;
								num2 = num;
							}
							else
							{
								num = -1940256704;
								num2 = num;
							}
							continue;
						}
						case 2:
							gOXDEJFRiopEFtrenfGxPdlYIvn.Dispose();
							num = -1940256703;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}
		}

		private sealed class GwYeKktxkqCZsxIqfmzZxNcRYwt : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public string NOJlkeauWKQIBZKjVcBnYCWUgkB;

			public string wSagivdJDpAKobJbTLYNmfxUdevu;

			public int TjjuYYALhiOgUcslavXWYaPJjYs;

			public int TnOlqFthThdLYgKAxqTgQnsxoRna;

			public InputCategory IkqrybdBHPwOHNryyiDQaXhzCdN;

			public int ZlXvjgfvHgDpSmOeHeQkhNMFFLa;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					goto IL_001c;
				}
				goto IL_0056;
				IL_0056:
				GwYeKktxkqCZsxIqfmzZxNcRYwt gwYeKktxkqCZsxIqfmzZxNcRYwt = new GwYeKktxkqCZsxIqfmzZxNcRYwt(0);
				gwYeKktxkqCZsxIqfmzZxNcRYwt.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				int num = 1348323988;
				goto IL_0021;
				IL_001c:
				num = 1348323986;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x505DCA91)
					{
					case 0:
						break;
					case 3:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						gwYeKktxkqCZsxIqfmzZxNcRYwt = this;
						num = 1348323984;
						continue;
					case 2:
						goto IL_0056;
					case 5:
						gwYeKktxkqCZsxIqfmzZxNcRYwt.NOJlkeauWKQIBZKjVcBnYCWUgkB = wSagivdJDpAKobJbTLYNmfxUdevu;
						num = 1348323989;
						continue;
					case 1:
						num = 1348323988;
						continue;
					default:
						return gwYeKktxkqCZsxIqfmzZxNcRYwt;
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
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = -59609182;
					while (true)
					{
						switch (num2 ^ -59609170)
						{
						case 11:
							break;
						case 2:
							if (IkqrybdBHPwOHNryyiDQaXhzCdN.id == iKQXbXnVtIaMZEJNeigQJWAHqUx.actions[ZlXvjgfvHgDpSmOeHeQkhNMFFLa].categoryId)
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.actions[ZlXvjgfvHgDpSmOeHeQkhNMFFLa];
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = -59609170;
								continue;
							}
							goto case 4;
						case 1:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories[TnOlqFthThdLYgKAxqTgQnsxoRna].tag.Equals(NOJlkeauWKQIBZKjVcBnYCWUgkB, StringComparison.OrdinalIgnoreCase))
							{
								IkqrybdBHPwOHNryyiDQaXhzCdN = iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories[TnOlqFthThdLYgKAxqTgQnsxoRna];
								ZlXvjgfvHgDpSmOeHeQkhNMFFLa = 0;
								num2 = -59609181;
								continue;
							}
							goto case 3;
						case 3:
							TnOlqFthThdLYgKAxqTgQnsxoRna++;
							num2 = -59609177;
							continue;
						case 13:
						{
							int num6;
							if (ZlXvjgfvHgDpSmOeHeQkhNMFFLa < TjjuYYALhiOgUcslavXWYaPJjYs)
							{
								num2 = -59609172;
								num6 = num2;
							}
							else
							{
								num2 = -59609171;
								num6 = num2;
							}
							continue;
						}
						case 8:
						{
							int num4;
							if (NOJlkeauWKQIBZKjVcBnYCWUgkB == string.Empty)
							{
								num2 = -59609180;
								num4 = num2;
							}
							else
							{
								num2 = -59609176;
								num4 = num2;
							}
							continue;
						}
						case 4:
							ZlXvjgfvHgDpSmOeHeQkhNMFFLa++;
							num2 = -59609181;
							continue;
						case 7:
							TnOlqFthThdLYgKAxqTgQnsxoRna = 0;
							num2 = -59609177;
							continue;
						case 6:
							TjjuYYALhiOgUcslavXWYaPJjYs = iKQXbXnVtIaMZEJNeigQJWAHqUx.actions.Count;
							num2 = -59609175;
							continue;
						case 5:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actions != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories != null)
							{
								int num5;
								if (NOJlkeauWKQIBZKjVcBnYCWUgkB != null)
								{
									num2 = -59609178;
									num5 = num2;
								}
								else
								{
									num2 = -59609180;
									num5 = num2;
								}
								continue;
							}
							goto default;
						case 9:
						{
							int num3;
							if (TnOlqFthThdLYgKAxqTgQnsxoRna < iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories.Count)
							{
								num2 = -59609169;
								num3 = num2;
							}
							else
							{
								num2 = -59609180;
								num3 = num2;
							}
							continue;
						}
						case 0:
							return true;
						case 12:
							switch (num)
							{
							case 0:
								break;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = -59609174;
								continue;
							default:
								num2 = -59609180;
								continue;
							}
							goto case 5;
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
			public GwYeKktxkqCZsxIqfmzZxNcRYwt(int _003C_003E1__state)
			{
				while (true)
				{
					int num = 1683753266;
					while (true)
					{
						switch (num ^ 0x645C0933)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
							num = 1683753264;
							continue;
						case 3:
							HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
							num = 1683753267;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		private sealed class LbcGBTlLRtbOdiVuMCeLHecUkDsK : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int RqvRhFbuodTKUwYPssXTimWBfVF;

			public int xuffIzkVdMgTYNPpaleAZUCNIqtN;

			public bool gYLXlJfwJlVtdKZnhkGpMDGTPqX;

			public bool uYpfxJpDlUgbkKhLiqpIreyGqeb;

			public InputCategory VIJBUBnDzjAQECAlGUmPsKKGceM;

			public int FzerxwUGrQrTpqWrdfvTDkPGAAG;

			public InputAction QhWcXEnANTfjftpEgtNcjGeNlyF;

			public int juTPvJNHdBaHEcZYSUUDNkVgdrYB;

			public InputAction GgBGHkyWFxnxLmBYCCvPFmIUuzoT;

			public IEnumerator<int> PhsHODoAFLsKRNIDoVyXirGgzJJ;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_0058;
				IL_0012:
				int num = -2142806947;
				goto IL_0017;
				IL_0017:
				LbcGBTlLRtbOdiVuMCeLHecUkDsK lbcGBTlLRtbOdiVuMCeLHecUkDsK = default(LbcGBTlLRtbOdiVuMCeLHecUkDsK);
				while (true)
				{
					switch (num ^ -2142806948)
					{
					case 4:
						break;
					case 1:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							num = -2142806951;
							continue;
						}
						goto IL_0058;
					case 6:
						goto IL_0058;
					case 2:
						lbcGBTlLRtbOdiVuMCeLHecUkDsK.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -2142806948;
						continue;
					case 0:
						lbcGBTlLRtbOdiVuMCeLHecUkDsK.RqvRhFbuodTKUwYPssXTimWBfVF = xuffIzkVdMgTYNPpaleAZUCNIqtN;
						lbcGBTlLRtbOdiVuMCeLHecUkDsK.gYLXlJfwJlVtdKZnhkGpMDGTPqX = uYpfxJpDlUgbkKhLiqpIreyGqeb;
						num = -2142806945;
						continue;
					case 5:
						lbcGBTlLRtbOdiVuMCeLHecUkDsK = this;
						num = -2142806948;
						continue;
					default:
						return lbcGBTlLRtbOdiVuMCeLHecUkDsK;
					}
					break;
				}
				goto IL_0012;
				IL_0058:
				lbcGBTlLRtbOdiVuMCeLHecUkDsK = new LbcGBTlLRtbOdiVuMCeLHecUkDsK(0);
				num = -2142806946;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 2:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = -1892491169;
						goto IL_0027;
					case 3:
						goto IL_0231;
					case 0:
						goto IL_0242;
						IL_0027:
						while (true)
						{
							switch (num ^ -1892491170)
							{
							case 2:
								num = -1892491186;
								continue;
							case 9:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -1892491169;
								continue;
							case 5:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actions != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories != null)
								{
									VIJBUBnDzjAQECAlGUmPsKKGceM = iKQXbXnVtIaMZEJNeigQJWAHqUx.GetActionCategoryById(RqvRhFbuodTKUwYPssXTimWBfVF);
									num = -1892491176;
									continue;
								}
								goto end_IL_0008;
							case 11:
								GgBGHkyWFxnxLmBYCCvPFmIUuzoT = iKQXbXnVtIaMZEJNeigQJWAHqUx.actions[juTPvJNHdBaHEcZYSUUDNkVgdrYB];
								if (GgBGHkyWFxnxLmBYCCvPFmIUuzoT.categoryId == VIJBUBnDzjAQECAlGUmPsKKGceM.id && GgBGHkyWFxnxLmBYCCvPFmIUuzoT.userAssignable)
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = GgBGHkyWFxnxLmBYCCvPFmIUuzoT;
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
									return true;
								}
								goto case 3;
							case 0:
								break;
							case 3:
								juTPvJNHdBaHEcZYSUUDNkVgdrYB++;
								num = -1892491180;
								continue;
							case 13:
								dTBzPWMsYvTojbkqIxDHCboltfM();
								num = -1892491178;
								continue;
							case 14:
								if (QhWcXEnANTfjftpEgtNcjGeNlyF.userAssignable)
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = QhWcXEnANTfjftpEgtNcjGeNlyF;
									num = -1892491185;
									continue;
								}
								goto IL_01ff;
							case 12:
								goto end_IL_0027;
							case 10:
								goto IL_01d3;
							case 1:
								goto IL_01ff;
							case 15:
								juTPvJNHdBaHEcZYSUUDNkVgdrYB = 0;
								num = -1892491180;
								continue;
							case 4:
								goto IL_0231;
							case 16:
								goto IL_0242;
							case 17:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								return true;
							case 6:
								goto IL_0268;
							case 7:
								if (gYLXlJfwJlVtdKZnhkGpMDGTPqX)
								{
									PhsHODoAFLsKRNIDoVyXirGgzJJ = iKQXbXnVtIaMZEJNeigQJWAHqUx.SortedActionIdsInCategory(VIJBUBnDzjAQECAlGUmPsKKGceM.id).GetEnumerator();
									num = -1892491177;
									continue;
								}
								goto case 15;
							default:
								goto end_IL_0008;
							}
							FzerxwUGrQrTpqWrdfvTDkPGAAG = PhsHODoAFLsKRNIDoVyXirGgzJJ.Current;
							QhWcXEnANTfjftpEgtNcjGeNlyF = iKQXbXnVtIaMZEJNeigQJWAHqUx.GetActionById(FzerxwUGrQrTpqWrdfvTDkPGAAG);
							int num2;
							if (QhWcXEnANTfjftpEgtNcjGeNlyF != null)
							{
								num = -1892491184;
								num2 = num;
							}
							else
							{
								num = -1892491169;
								num2 = num;
							}
							continue;
							IL_0268:
							if (VIJBUBnDzjAQECAlGUmPsKKGceM == null)
							{
								goto end_IL_0008;
							}
							int num3;
							if (!VIJBUBnDzjAQECAlGUmPsKKGceM.userAssignable)
							{
								num = -1892491178;
								num3 = num;
							}
							else
							{
								num = -1892491175;
								num3 = num;
							}
							continue;
							IL_01d3:
							int num4;
							if (juTPvJNHdBaHEcZYSUUDNkVgdrYB >= iKQXbXnVtIaMZEJNeigQJWAHqUx.actions.Count)
							{
								num = -1892491178;
								num4 = num;
							}
							else
							{
								num = -1892491179;
								num4 = num;
							}
							continue;
							IL_01ff:
							int num5;
							if (PhsHODoAFLsKRNIDoVyXirGgzJJ.MoveNext())
							{
								num = -1892491170;
								num5 = num;
							}
							else
							{
								num = -1892491181;
								num5 = num;
							}
							continue;
							end_IL_0027:
							break;
						}
						goto case 2;
						IL_0242:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -1892491173;
						goto IL_0027;
						IL_0231:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -1892491171;
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
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						dTBzPWMsYvTojbkqIxDHCboltfM();
					}
				}
			}

			[DebuggerHidden]
			public LbcGBTlLRtbOdiVuMCeLHecUkDsK(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void dTBzPWMsYvTojbkqIxDHCboltfM()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (PhsHODoAFLsKRNIDoVyXirGgzJJ != null)
				{
					PhsHODoAFLsKRNIDoVyXirGgzJJ.Dispose();
				}
			}
		}

		private sealed class GYagtenaeWyjFACGyDmmCZuTQrpW : IDisposable, IEnumerator, IEnumerable, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private InputAction aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public string ElaNjRsEoOZxdqlkAYVddsdGpNt;

			public string qbvFTWlRYAiWzQYZxKwLtRlnorr;

			public bool gYLXlJfwJlVtdKZnhkGpMDGTPqX;

			public bool uYpfxJpDlUgbkKhLiqpIreyGqeb;

			public InputCategory DMOikgXPIjQteHATqZrhIEoDesm;

			public int IgfayksADrrdgjPBMhJAagXCqjdr;

			public InputAction WPSiiyvwwKtimciCVbiRjDGxJgy;

			public int sASftLwwLiYdifJUoUBLbqZPouW;

			public InputAction AGoLkZphEamxwPcsBakeaBvQlZs;

			public IEnumerator<int> YElJPiXtyvAzvBrGEJTtuCcRXEq;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					goto IL_0023;
				}
				goto IL_004e;
				IL_0028:
				int num;
				GYagtenaeWyjFACGyDmmCZuTQrpW gYagtenaeWyjFACGyDmmCZuTQrpW = default(GYagtenaeWyjFACGyDmmCZuTQrpW);
				while (true)
				{
					switch (num ^ 0x4AE40260)
					{
					case 0:
						break;
					case 3:
						gYagtenaeWyjFACGyDmmCZuTQrpW = this;
						num = 1256456801;
						continue;
					case 2:
						goto IL_004e;
					default:
						gYagtenaeWyjFACGyDmmCZuTQrpW.ElaNjRsEoOZxdqlkAYVddsdGpNt = qbvFTWlRYAiWzQYZxKwLtRlnorr;
						gYagtenaeWyjFACGyDmmCZuTQrpW.gYLXlJfwJlVtdKZnhkGpMDGTPqX = uYpfxJpDlUgbkKhLiqpIreyGqeb;
						return gYagtenaeWyjFACGyDmmCZuTQrpW;
					}
					break;
				}
				goto IL_0023;
				IL_004e:
				gYagtenaeWyjFACGyDmmCZuTQrpW = new GYagtenaeWyjFACGyDmmCZuTQrpW(0);
				gYagtenaeWyjFACGyDmmCZuTQrpW.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = 1256456801;
				goto IL_0028;
				IL_0023:
				num = 1256456803;
				goto IL_0028;
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
					int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
					while (true)
					{
						IL_0007:
						int num2 = 1663808624;
						while (true)
						{
							switch (num2 ^ 0x632BB477)
							{
							case 9:
								break;
							case 3:
								AGoLkZphEamxwPcsBakeaBvQlZs = iKQXbXnVtIaMZEJNeigQJWAHqUx.actions[sASftLwwLiYdifJUoUBLbqZPouW];
								if (AGoLkZphEamxwPcsBakeaBvQlZs.categoryId == DMOikgXPIjQteHATqZrhIEoDesm.id)
								{
									int num3;
									if (AGoLkZphEamxwPcsBakeaBvQlZs.userAssignable)
									{
										num2 = 1663808636;
										num3 = num2;
									}
									else
									{
										num2 = 1663808633;
										num3 = num2;
									}
									continue;
								}
								goto case 14;
							case 5:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = 1663808631;
								continue;
							case 0:
							{
								int num5;
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actions == null)
								{
									num2 = 1663808630;
									num5 = num2;
								}
								else
								{
									num2 = 1663808639;
									num5 = num2;
								}
								continue;
							}
							case 8:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories != null)
								{
									DMOikgXPIjQteHATqZrhIEoDesm = iKQXbXnVtIaMZEJNeigQJWAHqUx.GetActionCategory(ElaNjRsEoOZxdqlkAYVddsdGpNt);
									if (DMOikgXPIjQteHATqZrhIEoDesm != null && DMOikgXPIjQteHATqZrhIEoDesm.userAssignable)
									{
										if (gYLXlJfwJlVtdKZnhkGpMDGTPqX)
										{
											YElJPiXtyvAzvBrGEJTtuCcRXEq = iKQXbXnVtIaMZEJNeigQJWAHqUx.SortedActionIdsInCategory(DMOikgXPIjQteHATqZrhIEoDesm.id).GetEnumerator();
											oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
											num2 = 1663808634;
											continue;
										}
										goto case 4;
									}
								}
								goto IL_02b0;
							case 14:
								sASftLwwLiYdifJUoUBLbqZPouW++;
								num2 = 1663808629;
								continue;
							case 15:
								goto IL_017e;
							case 4:
								sASftLwwLiYdifJUoUBLbqZPouW = 0;
								num2 = 1663808629;
								continue;
							case 11:
								aimBzjfQfPyaeQqysAQJISCBhELB = AGoLkZphEamxwPcsBakeaBvQlZs;
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 3;
								result = true;
								goto end_IL_000c;
							case 2:
							{
								int num4;
								if (sASftLwwLiYdifJUoUBLbqZPouW < iKQXbXnVtIaMZEJNeigQJWAHqUx.actions.Count)
								{
									num2 = 1663808628;
									num4 = num2;
								}
								else
								{
									num2 = 1663808630;
									num4 = num2;
								}
								continue;
							}
							case 16:
								IgfayksADrrdgjPBMhJAagXCqjdr = YElJPiXtyvAzvBrGEJTtuCcRXEq.Current;
								WPSiiyvwwKtimciCVbiRjDGxJgy = iKQXbXnVtIaMZEJNeigQJWAHqUx.GetActionById(IgfayksADrrdgjPBMhJAagXCqjdr);
								if (WPSiiyvwwKtimciCVbiRjDGxJgy != null && WPSiiyvwwKtimciCVbiRjDGxJgy.userAssignable)
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = WPSiiyvwwKtimciCVbiRjDGxJgy;
									oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
									result = true;
									num2 = 1663808625;
									continue;
								}
								goto case 13;
							case 13:
								if (!YElJPiXtyvAzvBrGEJTtuCcRXEq.MoveNext())
								{
									VyIvCvUlItyjrhQEkvqyqlTXfLT();
									num2 = 1663808630;
									continue;
								}
								goto case 16;
							case 7:
								switch (num)
								{
								case 0:
									break;
								case 2:
									goto IL_017e;
								default:
									goto IL_027f;
								case 3:
									goto IL_0293;
								case 1:
									goto IL_02b0;
								}
								goto case 5;
							case 12:
								num2 = 1663808630;
								continue;
							case 10:
								goto IL_0293;
							case 6:
								goto end_IL_000c;
							default:
								goto IL_02b0;
								IL_0293:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = 1663808633;
								continue;
								IL_027f:
								num2 = 1663808635;
								continue;
								IL_02b0:
								result = false;
								goto end_IL_000c;
								IL_017e:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num2 = 1663808634;
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
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						VyIvCvUlItyjrhQEkvqyqlTXfLT();
					}
				}
			}

			[DebuggerHidden]
			public GYagtenaeWyjFACGyDmmCZuTQrpW(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void VyIvCvUlItyjrhQEkvqyqlTXfLT()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (YElJPiXtyvAzvBrGEJTtuCcRXEq != null)
				{
					YElJPiXtyvAzvBrGEJTtuCcRXEq.Dispose();
				}
			}
		}

		private sealed class xoWrGhJmFYqiYTaGQTWmZTUwiNa : IDisposable, IEnumerator, IEnumerable, IEnumerable<string>, IEnumerator<string>
		{
			private string aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int fKtuodNzZLrsthNmhfemlCLUaYzG;

			public int BgfpLKXMFxgDkPNOkjzHjMtFDBY;

			public int mQXxIsSaGQHKuFtTVBzKXdlwgWmy;

			public InputAction UJCBKDizikVsdyngFfWUVIsbCjFi;

			public IEnumerator<int> LIHFHcWDShekWElDLCPIehsvEBR;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				xoWrGhJmFYqiYTaGQTWmZTUwiNa xoWrGhJmFYqiYTaGQTWmZTUwiNa2;
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					xoWrGhJmFYqiYTaGQTWmZTUwiNa2 = this;
					goto IL_0025;
				}
				goto IL_005e;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ -448602331)
					{
					case 2:
						break;
					case 1:
						xoWrGhJmFYqiYTaGQTWmZTUwiNa2.fKtuodNzZLrsthNmhfemlCLUaYzG = BgfpLKXMFxgDkPNOkjzHjMtFDBY;
						num = -448602335;
						continue;
					case 0:
						goto IL_005e;
					case 3:
						num = -448602332;
						continue;
					default:
						return xoWrGhJmFYqiYTaGQTWmZTUwiNa2;
					}
					break;
				}
				goto IL_0025;
				IL_005e:
				xoWrGhJmFYqiYTaGQTWmZTUwiNa2 = new xoWrGhJmFYqiYTaGQTWmZTUwiNa(0);
				xoWrGhJmFYqiYTaGQTWmZTUwiNa2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = -448602332;
				goto IL_002a;
				IL_0025:
				num = -448602330;
				goto IL_002a;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					default:
						num = 41638178;
						goto IL_001e;
					case 0:
						goto IL_006b;
					case 1:
						goto IL_00cf;
					case 2:
						goto IL_016c;
						IL_001e:
						while (true)
						{
							switch (num ^ 0x27B592B)
							{
							case 0:
								break;
							default:
								goto end_IL_0008;
							case 3:
								SgxXItGjrUdRyBZXlDwVePOwQYpb();
								num = 41638189;
								continue;
							case 11:
								goto IL_006b;
							case 10:
								result = true;
								goto end_IL_0008;
							case 6:
								goto IL_00cf;
							case 8:
								mQXxIsSaGQHKuFtTVBzKXdlwgWmy = LIHFHcWDShekWElDLCPIehsvEBR.Current;
								UJCBKDizikVsdyngFfWUVIsbCjFi = iKQXbXnVtIaMZEJNeigQJWAHqUx.GetActionById(mQXxIsSaGQHKuFtTVBzKXdlwgWmy);
								if (UJCBKDizikVsdyngFfWUVIsbCjFi != null)
								{
									aimBzjfQfPyaeQqysAQJISCBhELB = UJCBKDizikVsdyngFfWUVIsbCjFi.name;
									num = 41638191;
									continue;
								}
								goto IL_0126;
							case 1:
								goto IL_0126;
							case 4:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								num = 41638177;
								continue;
							case 5:
								num = 41638186;
								continue;
							case 9:
								num = 41638189;
								continue;
							case 7:
								goto IL_016c;
							case 2:
								goto end_IL_0008;
							}
							break;
							IL_0126:
							int num2;
							if (LIHFHcWDShekWElDLCPIehsvEBR.MoveNext())
							{
								num = 41638179;
								num2 = num;
							}
							else
							{
								num = 41638184;
								num2 = num;
							}
						}
						goto default;
						IL_016c:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = 41638186;
						goto IL_001e;
						IL_006b:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.actions != null)
						{
							LIHFHcWDShekWElDLCPIehsvEBR = iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategoryMap.ActionIdsInCategory(fKtuodNzZLrsthNmhfemlCLUaYzG).GetEnumerator();
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							num = 41638190;
							goto IL_001e;
						}
						goto IL_00cf;
						IL_00cf:
						result = false;
						num = 41638185;
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
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						SgxXItGjrUdRyBZXlDwVePOwQYpb();
					}
				}
			}

			[DebuggerHidden]
			public xoWrGhJmFYqiYTaGQTWmZTUwiNa(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void SgxXItGjrUdRyBZXlDwVePOwQYpb()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (LIHFHcWDShekWElDLCPIehsvEBR == null)
				{
					return;
				}
				while (true)
				{
					int num = 2072136028;
					while (true)
					{
						switch (num ^ 0x7B82495D)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_002d;
						case 2:
							return;
						}
						break;
						IL_002d:
						LIHFHcWDShekWElDLCPIehsvEBR.Dispose();
						num = 2072136031;
					}
				}
			}
		}

		private sealed class hRjWIfMCQuDkZRufCIBeAguPPGKa : IDisposable, IEnumerator, IEnumerable, IEnumerable<string>, IEnumerator<string>
		{
			private string aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int fKtuodNzZLrsthNmhfemlCLUaYzG;

			public int BgfpLKXMFxgDkPNOkjzHjMtFDBY;

			public int ebKFbxJJwfRLmfjEZvnpkhLCuZyc;

			public InputAction OfHdIaHRujqAKtyGLToECTEKhtT;

			public IEnumerator<int> PzDvKIpaLPAwOfnYVhHsiPNWKon;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					goto IL_001c;
				}
				goto IL_0064;
				IL_0064:
				hRjWIfMCQuDkZRufCIBeAguPPGKa hRjWIfMCQuDkZRufCIBeAguPPGKa2 = new hRjWIfMCQuDkZRufCIBeAguPPGKa(0);
				hRjWIfMCQuDkZRufCIBeAguPPGKa2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				int num = 1132779909;
				goto IL_0021;
				IL_001c:
				num = 1132779905;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x4384D985)
					{
					case 5:
						break;
					case 4:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
						num = 1132779908;
						continue;
					case 2:
						num = 1132779909;
						continue;
					case 1:
						hRjWIfMCQuDkZRufCIBeAguPPGKa2 = this;
						num = 1132779911;
						continue;
					case 3:
						goto IL_0064;
					default:
						hRjWIfMCQuDkZRufCIBeAguPPGKa2.fKtuodNzZLrsthNmhfemlCLUaYzG = BgfpLKXMFxgDkPNOkjzHjMtFDBY;
						return hRjWIfMCQuDkZRufCIBeAguPPGKa2;
					}
					break;
				}
				goto IL_001c;
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
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					case 2:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = -393267097;
						goto IL_0023;
					case 0:
						goto IL_00d0;
						IL_0023:
						while (true)
						{
							switch (num ^ -393267097)
							{
							case 5:
								num = -393267091;
								continue;
							case 3:
								break;
							case 9:
								goto end_IL_0000;
							case 12:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories != null && iKQXbXnVtIaMZEJNeigQJWAHqUx.actions != null)
								{
									PzDvKIpaLPAwOfnYVhHsiPNWKon = iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategoryMap.ActionIdsInCategory(fKtuodNzZLrsthNmhfemlCLUaYzG).GetEnumerator();
									num = -393267104;
									continue;
								}
								goto end_IL_0008;
							case 10:
								goto IL_00d0;
							case 6:
								aimBzjfQfPyaeQqysAQJISCBhELB = OfHdIaHRujqAKtyGLToECTEKhtT.descriptiveName;
								num = -393267092;
								continue;
							case 4:
								ebKFbxJJwfRLmfjEZvnpkhLCuZyc = PzDvKIpaLPAwOfnYVhHsiPNWKon.Current;
								OfHdIaHRujqAKtyGLToECTEKhtT = iKQXbXnVtIaMZEJNeigQJWAHqUx.GetActionById(ebKFbxJJwfRLmfjEZvnpkhLCuZyc);
								num = -393267094;
								continue;
							case 8:
								num = -393267097;
								continue;
							case 1:
								SwybrGndvrpgEVazmrMPgRvyKEf();
								num = -393267099;
								continue;
							case 11:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								result = true;
								num = -393267090;
								continue;
							case 13:
								goto IL_015b;
							case 7:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								num = -393267089;
								continue;
							case 0:
								goto IL_0188;
							default:
								goto end_IL_0008;
							}
							break;
							IL_0188:
							int num2;
							if (!PzDvKIpaLPAwOfnYVhHsiPNWKon.MoveNext())
							{
								num = -393267098;
								num2 = num;
							}
							else
							{
								num = -393267101;
								num2 = num;
							}
							continue;
							IL_015b:
							int num3;
							if (OfHdIaHRujqAKtyGLToECTEKhtT == null)
							{
								num = -393267097;
								num3 = num;
							}
							else
							{
								num = -393267103;
								num3 = num;
							}
						}
						goto case 2;
						IL_00d0:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -393267093;
						goto IL_0023;
						end_IL_0008:
						break;
					}
					result = false;
					end_IL_0000:;
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
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						SwybrGndvrpgEVazmrMPgRvyKEf();
					}
				}
			}

			[DebuggerHidden]
			public hRjWIfMCQuDkZRufCIBeAguPPGKa(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}

			private void SwybrGndvrpgEVazmrMPgRvyKEf()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				if (PzDvKIpaLPAwOfnYVhHsiPNWKon != null)
				{
					PzDvKIpaLPAwOfnYVhHsiPNWKon.Dispose();
				}
			}
		}

		private sealed class kVxBXRwkMqaoOFpvyUVWIDzbIyxf : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
		{
			private int aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public UserData iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int fKtuodNzZLrsthNmhfemlCLUaYzG;

			public int BgfpLKXMFxgDkPNOkjzHjMtFDBY;

			public int kLUkoRLKCCdpGtOJxisxjFmwMGRb;

			public IEnumerator<int> YhiOCnTdWBhBRDwwMHEvkCdpzRph;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_0064;
				IL_0012:
				int num = 1885839240;
				goto IL_0017;
				IL_0017:
				kVxBXRwkMqaoOFpvyUVWIDzbIyxf kVxBXRwkMqaoOFpvyUVWIDzbIyxf2 = default(kVxBXRwkMqaoOFpvyUVWIDzbIyxf);
				while (true)
				{
					switch (num ^ 0x70679F8D)
					{
					case 0:
						break;
					case 5:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							num = 1885839247;
							continue;
						}
						goto IL_0064;
					case 4:
						num = 1885839246;
						continue;
					case 2:
						kVxBXRwkMqaoOFpvyUVWIDzbIyxf2 = this;
						num = 1885839241;
						continue;
					case 1:
						goto IL_0064;
					default:
						kVxBXRwkMqaoOFpvyUVWIDzbIyxf2.fKtuodNzZLrsthNmhfemlCLUaYzG = BgfpLKXMFxgDkPNOkjzHjMtFDBY;
						return kVxBXRwkMqaoOFpvyUVWIDzbIyxf2;
					}
					break;
				}
				goto IL_0012;
				IL_0064:
				kVxBXRwkMqaoOFpvyUVWIDzbIyxf2 = new kVxBXRwkMqaoOFpvyUVWIDzbIyxf(0);
				kVxBXRwkMqaoOFpvyUVWIDzbIyxf2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = 1885839246;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num;
					switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
					{
					default:
						num = 260270259;
						goto IL_001e;
					case 2:
						goto IL_004e;
					case 0:
						goto IL_008e;
					case 1:
						break;
						IL_001e:
						while (true)
						{
							switch (num ^ 0xF8368B0)
							{
							case 0:
								break;
							case 6:
								goto IL_004e;
							case 7:
								kLUkoRLKCCdpGtOJxisxjFmwMGRb = YhiOCnTdWBhBRDwwMHEvkCdpzRph.Current;
								aimBzjfQfPyaeQqysAQJISCBhELB = kLUkoRLKCCdpGtOJxisxjFmwMGRb;
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 2;
								return true;
							case 5:
								goto IL_008e;
							case 3:
								num = 260270260;
								continue;
							case 1:
								goto IL_00eb;
							case 2:
								dJRHGaXhMvOjsKjRGicSLgvWvOP();
								num = 260270260;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00eb:
							int num2;
							if (!YhiOCnTdWBhBRDwwMHEvkCdpzRph.MoveNext())
							{
								num = 260270258;
								num2 = num;
							}
							else
							{
								num = 260270263;
								num2 = num;
							}
						}
						goto default;
						IL_008e:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategories == null || iKQXbXnVtIaMZEJNeigQJWAHqUx.actions == null)
						{
							break;
						}
						YhiOCnTdWBhBRDwwMHEvkCdpzRph = iKQXbXnVtIaMZEJNeigQJWAHqUx.actionCategoryMap.ActionIdsInCategory(fKtuodNzZLrsthNmhfemlCLUaYzG).GetEnumerator();
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = 260270257;
						goto IL_001e;
						IL_004e:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
						num = 260270257;
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
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						dJRHGaXhMvOjsKjRGicSLgvWvOP();
					}
				}
			}

			[DebuggerHidden]
			public kVxBXRwkMqaoOFpvyUVWIDzbIyxf(int _003C_003E1__state)
			{
				while (true)
				{
					int num = -998638836;
					while (true)
					{
						switch (num ^ -998638835)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0024;
						case 2:
							return;
						}
						break;
						IL_0024:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
						HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
						num = -998638833;
					}
				}
			}

			private void dJRHGaXhMvOjsKjRGicSLgvWvOP()
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
				while (true)
				{
					int num = -1497576713;
					while (true)
					{
						switch (num ^ -1497576715)
						{
						case 3:
							break;
						default:
							return;
						case 2:
						{
							int num2;
							if (YhiOCnTdWBhBRDwwMHEvkCdpzRph == null)
							{
								num = -1497576715;
								num2 = num;
							}
							else
							{
								num = -1497576716;
								num2 = num;
							}
							continue;
						}
						case 1:
							YhiOCnTdWBhBRDwwMHEvkCdpzRph.Dispose();
							num = -1497576715;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		private sealed class TUPMRcydglvgirjaQpWjIHGbxCi
		{
			private sealed class zVOHascNvdRqDKGEQhCSztynjtg
			{
				public TUPMRcydglvgirjaQpWjIHGbxCi IuFrmQggXnIJYDNVwGpxkJidZZe;

				public ControllerMap_Editor tZfhkeNLltBUGrNOBGFtCGTpEgF;

				public ControllerMap_Editor NSawOevekNbKdEGYiDwRoEKHtBBh;

				public bool wUzgBAaUEjODhrHqvkGIsGUVHWrc(InputLayout P_0)
				{
					return P_0.id == tZfhkeNLltBUGrNOBGFtCGTpEgF.id;
				}

				public bool NMaJDgNTHFvVuswXRurLknZDNkW(InputLayout P_0)
				{
					return P_0.id == NSawOevekNbKdEGYiDwRoEKHtBBh.id;
				}
			}

			public List<InputLayout> rIcvIroBgpDYMIGBXMTDQmCTMtX;

			public int zQqwCjxakTqscOJwCUDLKmcAaEe(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				zVOHascNvdRqDKGEQhCSztynjtg zVOHascNvdRqDKGEQhCSztynjtg2 = new zVOHascNvdRqDKGEQhCSztynjtg();
				zVOHascNvdRqDKGEQhCSztynjtg2.IuFrmQggXnIJYDNVwGpxkJidZZe = this;
				zVOHascNvdRqDKGEQhCSztynjtg2.tZfhkeNLltBUGrNOBGFtCGTpEgF = P_0;
				zVOHascNvdRqDKGEQhCSztynjtg2.NSawOevekNbKdEGYiDwRoEKHtBBh = P_1;
				int num = rIcvIroBgpDYMIGBXMTDQmCTMtX.FindIndex(zVOHascNvdRqDKGEQhCSztynjtg2.wUzgBAaUEjODhrHqvkGIsGUVHWrc);
				int num2 = rIcvIroBgpDYMIGBXMTDQmCTMtX.FindIndex(zVOHascNvdRqDKGEQhCSztynjtg2.NMaJDgNTHFvVuswXRurLknZDNkW);
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputMapCategory> mapCategories = new List<InputMapCategory>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputLayout> joystickLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> keyboardLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> mouseLayouts = new List<InputLayout>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputLayout> customControllerLayouts = new List<InputLayout>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMap_Editor> joystickMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> keyboardMaps = new List<ControllerMap_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMap_Editor> mouseMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> customControllerMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CustomController_Editor> customControllers = new List<CustomController_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = new List<ControllerMapLayoutManager_RuleSet_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = new List<ControllerMapEnabler_RuleSet_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int playerIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int actionIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int actionCategoryIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int inputBehaviorIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mapCategoryIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int joystickLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int keyboardLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int mouseLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int customControllerIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int controllerMapLayoutManagerSetIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		public ConfigVars ConfigVars
		{
			get
			{
				return configVars;
			}
		}

		internal IEnumerable<InputMapCategory> UserAssignableMapCategories
		{
			get
			{
				NwjjXtLLfeKVmPGmmPGbNBmWAfX nwjjXtLLfeKVmPGmmPGbNBmWAfX = new NwjjXtLLfeKVmPGmmPGbNBmWAfX(-2);
				nwjjXtLLfeKVmPGmmPGbNBmWAfX.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return nwjjXtLLfeKVmPGmmPGbNBmWAfX;
			}
		}

		internal IEnumerable<InputCategory> UserAssignableActionCategories
		{
			get
			{
				VdjfRHriXqCxIvwAiOEqrsZqWOL vdjfRHriXqCxIvwAiOEqrsZqWOL = new VdjfRHriXqCxIvwAiOEqrsZqWOL(-2);
				vdjfRHriXqCxIvwAiOEqrsZqWOL.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return vdjfRHriXqCxIvwAiOEqrsZqWOL;
			}
		}

		internal IEnumerable<InputAction> UserAssignableActions
		{
			get
			{
				eDuazNopbBQacwhaiQMraCkggET eDuazNopbBQacwhaiQMraCkggET2 = new eDuazNopbBQacwhaiQMraCkggET(-2);
				eDuazNopbBQacwhaiQMraCkggET2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return eDuazNopbBQacwhaiQMraCkggET2;
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

		internal IEnumerable<InputMapCategory> UeeOaTSRIGUUJmwfGWfKwuIAPvR(string P_0)
		{
			FMYHvlAirbLdntWFjAcQhLIDphg fMYHvlAirbLdntWFjAcQhLIDphg = new FMYHvlAirbLdntWFjAcQhLIDphg(-2);
			fMYHvlAirbLdntWFjAcQhLIDphg.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			fMYHvlAirbLdntWFjAcQhLIDphg.wSagivdJDpAKobJbTLYNmfxUdevu = P_0;
			return fMYHvlAirbLdntWFjAcQhLIDphg;
		}

		internal IEnumerable<InputMapCategory> afiDBUdsdNTvSflAxulINMHxlGZg(string P_0)
		{
			lFLiQCQYpnTnibyQYTvRFPOAuqw lFLiQCQYpnTnibyQYTvRFPOAuqw2 = new lFLiQCQYpnTnibyQYTvRFPOAuqw(-2);
			lFLiQCQYpnTnibyQYTvRFPOAuqw2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			lFLiQCQYpnTnibyQYTvRFPOAuqw2.wSagivdJDpAKobJbTLYNmfxUdevu = P_0;
			return lFLiQCQYpnTnibyQYTvRFPOAuqw2;
		}

		internal IEnumerable<InputCategory> qdHusqNOwSKQACNSEiIsRBdXKOa(string P_0)
		{
			xyOPbJLpaAxdwPlBIJsTdMoTybU xyOPbJLpaAxdwPlBIJsTdMoTybU2 = new xyOPbJLpaAxdwPlBIJsTdMoTybU(-2);
			xyOPbJLpaAxdwPlBIJsTdMoTybU2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			xyOPbJLpaAxdwPlBIJsTdMoTybU2.wSagivdJDpAKobJbTLYNmfxUdevu = P_0;
			return xyOPbJLpaAxdwPlBIJsTdMoTybU2;
		}

		internal IEnumerable<InputCategory> GHeCLHAENkteqVfOeXTxoTwLutZ(string P_0)
		{
			dBohIEOoTQrNIbDNXTvDJHjQcbKG dBohIEOoTQrNIbDNXTvDJHjQcbKG2 = new dBohIEOoTQrNIbDNXTvDJHjQcbKG(-2);
			dBohIEOoTQrNIbDNXTvDJHjQcbKG2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			dBohIEOoTQrNIbDNXTvDJHjQcbKG2.wSagivdJDpAKobJbTLYNmfxUdevu = P_0;
			return dBohIEOoTQrNIbDNXTvDJHjQcbKG2;
		}

		internal IEnumerable<InputAction> bUkCqqbTCbZDZsDEABezjonPmLX(int P_0, bool P_1)
		{
			XQOnvqAfuPNsjmRoSNeUlAXIGIu xQOnvqAfuPNsjmRoSNeUlAXIGIu = new XQOnvqAfuPNsjmRoSNeUlAXIGIu(-2);
			xQOnvqAfuPNsjmRoSNeUlAXIGIu.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			xQOnvqAfuPNsjmRoSNeUlAXIGIu.xuffIzkVdMgTYNPpaleAZUCNIqtN = P_0;
			xQOnvqAfuPNsjmRoSNeUlAXIGIu.uYpfxJpDlUgbkKhLiqpIreyGqeb = P_1;
			return xQOnvqAfuPNsjmRoSNeUlAXIGIu;
		}

		internal IEnumerable<InputAction> bUkCqqbTCbZDZsDEABezjonPmLX(string P_0, bool P_1)
		{
			RjevAQBMDvenJqSyfdgBffSjEKOB rjevAQBMDvenJqSyfdgBffSjEKOB = new RjevAQBMDvenJqSyfdgBffSjEKOB(-2);
			rjevAQBMDvenJqSyfdgBffSjEKOB.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			while (true)
			{
				int num = 1702151459;
				while (true)
				{
					switch (num ^ 0x6574C521)
					{
					case 0:
						break;
					case 2:
						goto IL_002d;
					default:
						return rjevAQBMDvenJqSyfdgBffSjEKOB;
					}
					break;
					IL_002d:
					rjevAQBMDvenJqSyfdgBffSjEKOB.fDJRiZlkTwCJwijoUoacqalnNias = P_0;
					rjevAQBMDvenJqSyfdgBffSjEKOB.uYpfxJpDlUgbkKhLiqpIreyGqeb = P_1;
					num = 1702151456;
				}
			}
		}

		internal IEnumerable<InputAction> quHkPyuugLTimSjYXbYQoqNUfms(string P_0)
		{
			GwYeKktxkqCZsxIqfmzZxNcRYwt gwYeKktxkqCZsxIqfmzZxNcRYwt = new GwYeKktxkqCZsxIqfmzZxNcRYwt(-2);
			while (true)
			{
				int num = -886021260;
				while (true)
				{
					switch (num ^ -886021259)
					{
					case 2:
						break;
					case 1:
						goto IL_0026;
					default:
						gwYeKktxkqCZsxIqfmzZxNcRYwt.wSagivdJDpAKobJbTLYNmfxUdevu = P_0;
						return gwYeKktxkqCZsxIqfmzZxNcRYwt;
					}
					break;
					IL_0026:
					gwYeKktxkqCZsxIqfmzZxNcRYwt.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					num = -886021259;
				}
			}
		}

		internal IEnumerable<InputAction> ONQkesvIeGUEvbqIKFMkJKeKicFt(int P_0, bool P_1)
		{
			LbcGBTlLRtbOdiVuMCeLHecUkDsK lbcGBTlLRtbOdiVuMCeLHecUkDsK = new LbcGBTlLRtbOdiVuMCeLHecUkDsK(-2);
			lbcGBTlLRtbOdiVuMCeLHecUkDsK.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			lbcGBTlLRtbOdiVuMCeLHecUkDsK.xuffIzkVdMgTYNPpaleAZUCNIqtN = P_0;
			lbcGBTlLRtbOdiVuMCeLHecUkDsK.uYpfxJpDlUgbkKhLiqpIreyGqeb = P_1;
			return lbcGBTlLRtbOdiVuMCeLHecUkDsK;
		}

		internal IEnumerable<InputAction> ONQkesvIeGUEvbqIKFMkJKeKicFt(string P_0, bool P_1)
		{
			GYagtenaeWyjFACGyDmmCZuTQrpW gYagtenaeWyjFACGyDmmCZuTQrpW = new GYagtenaeWyjFACGyDmmCZuTQrpW(-2);
			gYagtenaeWyjFACGyDmmCZuTQrpW.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			gYagtenaeWyjFACGyDmmCZuTQrpW.qbvFTWlRYAiWzQYZxKwLtRlnorr = P_0;
			gYagtenaeWyjFACGyDmmCZuTQrpW.uYpfxJpDlUgbkKhLiqpIreyGqeb = P_1;
			return gYagtenaeWyjFACGyDmmCZuTQrpW;
		}

		public UserData()
			: this(true)
		{
		}

		private UserData(bool init)
		{
			if (init)
			{
				configVars.updateLoop = UpdateLoopSetting.Update;
				configVars.defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;
				configVars.defaultJoystickAxis2DSensitivityType = AxisSensitivity2DType.Radial;
				Player_Editor player_Editor = GSZeaxXpRdMLDgOmmHuwrCgsXjs();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputCategory inputCategory = TRJwjOZSSTAKChaAiCgKPWJxOmQ();
				inputCategory.name = "Default";
				inputCategory.descriptiveName = inputCategory.name;
				actionCategories.Add(inputCategory);
				actionCategoryMap.AddCategory(inputCategory.id);
				InputBehavior inputBehavior = sQjLOUlHnCqbfWBVphJhsTFnFdc();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = ecUyQZFJdpXDXsgxHLbjdNRNGMI();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = jrcBygfzmVMHQPmYGgpgzbYkitSc();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = ITVOzABurSvFsagyZmuGYtbzJir();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = asWTBfYbeGKFQPgxKcIlfswQTbMv();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = tSURnYCtXucFOhJJItwlMfXhOTs();
				inputLayout4.name = "Default";
				inputLayout4.descriptiveName = inputLayout4.name;
				customControllerLayouts.Add(inputLayout3);
			}
		}

		public List<InputAction> GetActions_Copy()
		{
			List<InputAction> list = new List<InputAction>();
			int num2 = default(int);
			while (true)
			{
				int num = 1529107477;
				while (true)
				{
					switch (num ^ 0x5B245414)
					{
					case 0:
						break;
					case 2:
						num2++;
						num = 1529107472;
						continue;
					case 3:
						list.Add(actions[num2]);
						num = 1529107478;
						continue;
					case 1:
						num2 = 0;
						num = 1529107472;
						continue;
					default:
						if (num2 >= actions.Count)
						{
							return list;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public List<InputBehavior> GetInputBehaviors_Copy()
		{
			List<InputBehavior> list = new List<InputBehavior>();
			int num = 0;
			while (true)
			{
				int num2 = 524321287;
				while (true)
				{
					switch (num2 ^ 0x1F408205)
					{
					case 0:
						break;
					case 2:
						num2 = 524321284;
						continue;
					case 5:
						list.Add(inputBehaviors[num].Clone());
						num2 = 524321281;
						continue;
					case 1:
					{
						int num3;
						if (num >= inputBehaviors.Count)
						{
							num2 = 524321286;
							num3 = num2;
						}
						else
						{
							num2 = 524321280;
							num3 = num2;
						}
						continue;
					}
					case 4:
						num++;
						num2 = 524321284;
						continue;
					default:
						return list;
					}
					break;
				}
			}
		}

		public List<KeyboardMap> GetKeyboardMaps_Copy()
		{
			List<KeyboardMap> list = new List<KeyboardMap>();
			int num2 = default(int);
			while (true)
			{
				int num = -906873624;
				while (true)
				{
					switch (num ^ -906873622)
					{
					case 0:
						break;
					case 3:
					{
						KeyboardMap item = keyboardMaps[num2].SdulnsJvJXcicAJaRRIxFADCpHO(containsActionDelegate);
						list.Add(item);
						num2++;
						num = -906873618;
						continue;
					}
					case 1:
						num = -906873618;
						continue;
					case 2:
						num2 = 0;
						num = -906873621;
						continue;
					default:
						if (num2 >= keyboardMaps.Count)
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
			int num2 = default(int);
			while (true)
			{
				int num = -473116461;
				while (true)
				{
					switch (num ^ -473116462)
					{
					case 0:
						break;
					case 4:
					{
						int num3;
						if (num2 >= mouseMaps.Count)
						{
							num = -473116464;
							num3 = num;
						}
						else
						{
							num = -473116463;
							num3 = num;
						}
						continue;
					}
					case 3:
					{
						MouseMap item = mouseMaps[num2].ZuyHHsYuJPhMvykrNfAaAsRJVhK(containsActionDelegate);
						list.Add(item);
						num2++;
						num = -473116458;
						continue;
					}
					case 1:
						num2 = 0;
						num = -473116458;
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
			players.Add(GSZeaxXpRdMLDgOmmHuwrCgsXjs());
		}

		public void InsertPlayer(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -318915920;
					while (true)
					{
						switch (num ^ -318915919)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_002a;
						case 3:
							players.Insert(index, GSZeaxXpRdMLDgOmmHuwrCgsXjs());
							num = -318915917;
							continue;
						case 4:
							goto end_IL_0004;
						case 2:
							return;
						}
						break;
						IL_002a:
						int num2;
						if (index >= players.Count)
						{
							num = -318915915;
							num2 = num;
						}
						else
						{
							num = -318915918;
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
				while (true)
				{
					int num = 1138400910;
					while (true)
					{
						switch (num ^ 0x43DA9E8D)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							goto IL_0032;
						case 4:
							players.RemoveAt(index);
							num = 1138400911;
							continue;
						case 1:
							goto end_IL_000c;
						case 2:
							return;
						}
						break;
						IL_0032:
						int num2;
						if (index < players.Count)
						{
							num = 1138400905;
							num2 = num;
						}
						else
						{
							num = 1138400908;
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

		public bool ReorderPlayer(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(players, index, offsetDown, offsetNow);
		}

		public void DuplicatePlayer(int index)
		{
			if (players == null || index < 0)
			{
				goto IL_0052;
			}
			if (index >= players.Count)
			{
				goto IL_001d;
			}
			goto IL_00d6;
			IL_00d6:
			Player_Editor player_Editor = players[index].Clone();
			int num = 361281962;
			goto IL_0022;
			IL_0052:
			throw new ArgumentOutOfRangeException("index");
			IL_001d:
			num = 361281964;
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num ^ 0x1588B9A8)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					goto IL_0052;
				case 7:
					goto IL_0064;
				case 1:
					players.Insert(index + 1, player_Editor);
					num = 361281966;
					continue;
				case 2:
					player_Editor.id = GetNewPlayerId();
					num = 361281967;
					continue;
				case 5:
					goto IL_00d6;
				case 3:
					players.Add(player_Editor);
					return;
				case 6:
					return;
				}
				break;
				IL_0064:
				player_Editor.name = StringTools.IterateName(player_Editor.name, -1, GetPlayerNames());
				player_Editor.assignMouseOnStart = false;
				int num2;
				if (index == players.Count - 1)
				{
					num = 361281963;
					num2 = num;
				}
				else
				{
					num = 361281961;
					num2 = num;
				}
			}
			goto IL_001d;
		}

		public string[] GetPlayerNames()
		{
			if (players == null)
			{
				return null;
			}
			string[] array = new string[players.Count];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < players.Count)
				{
					num2 = 1253105519;
					num3 = num2;
				}
				else
				{
					num2 = 1253105517;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x4AB0DF6E)
					{
					case 0:
						num2 = 1253105519;
						continue;
					case 1:
						array[num] = players[num].name;
						num++;
						num2 = 1253105516;
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

		public int GetPlayerNames(IList<string> results)
		{
			if (results == null)
			{
				goto IL_0003;
			}
			goto IL_0074;
			IL_0003:
			int num = 1920782757;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x727CD1A6)
				{
				case 2:
					break;
				case 3:
					throw new ArgumentNullException("results");
				case 4:
					goto IL_003f;
				case 5:
					results.Add(players[num2].name);
					num2++;
					num = 1920782759;
					continue;
				case 0:
					goto IL_0074;
				default:
					if (num2 >= players.Count)
					{
						return results.Count;
					}
					goto case 5;
				}
				break;
				IL_003f:
				if (players == null)
				{
					return 0;
				}
				num2 = 0;
				num = 1920782759;
			}
			goto IL_0003;
			IL_0074:
			results.Clear();
			num = 1920782754;
			goto IL_0008;
		}

		public int[] GetPlayerIds()
		{
			if (players == null)
			{
				return null;
			}
			int[] array = new int[players.Count];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < players.Count)
				{
					num2 = -1847338474;
					num3 = num2;
				}
				else
				{
					num2 = -1847338480;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1847338476)
					{
					case 0:
						num2 = -1847338474;
						continue;
					case 3:
						break;
					case 1:
						num++;
						num2 = -1847338473;
						continue;
					case 2:
						array[num] = players[num].id;
						num2 = -1847338475;
						continue;
					default:
						return array;
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
			int num2 = default(int);
			while (true)
			{
				int num = -2051972295;
				while (true)
				{
					switch (num ^ -2051972294)
					{
					case 0:
						break;
					case 2:
						array[num2] = num2 - 1;
						num = -2051972290;
						continue;
					case 5:
						if (num2 == 0)
						{
							array[num2] = 9999999;
							num = -2051972290;
							continue;
						}
						goto case 2;
					case 3:
						num2 = 0;
						num = -2051972293;
						continue;
					case 4:
						num2++;
						num = -2051972293;
						continue;
					default:
						if (num2 >= players.Count)
						{
							return array;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		public int GetPlayerRuntimeIds(IList<int> results)
		{
			if (results == null)
			{
				goto IL_0003;
			}
			goto IL_0057;
			IL_0003:
			int num = -5048736;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -5048735)
				{
				case 4:
					break;
				case 6:
					goto IL_0038;
				case 0:
					goto IL_0057;
				case 2:
					results.Add(num2 - 1);
					num = -5048730;
					continue;
				case 3:
					if (num2 == 0)
					{
						results.Add(9999999);
						num = -5048730;
						continue;
					}
					goto case 2;
				case 7:
					num2++;
					num = -5048729;
					continue;
				case 1:
					throw new ArgumentNullException("results");
				default:
					return results.Count;
				}
				break;
				IL_0038:
				int num3;
				if (num2 >= players.Count)
				{
					num = -5048732;
					num3 = num;
				}
				else
				{
					num = -5048734;
					num3 = num;
				}
			}
			goto IL_0003;
			IL_0057:
			results.Clear();
			if (players == null)
			{
				return 0;
			}
			num2 = 0;
			num = -5048729;
			goto IL_0008;
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
					int num2 = 1171691953;
					while (true)
					{
						switch (num2 ^ 0x45D699B1)
						{
						case 2:
							num2 = 1171691952;
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
					int num = 1303459315;
					while (true)
					{
						switch (num ^ 0x4DB135F0)
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
						if (index >= players.Count)
						{
							num = 1303459314;
							continue;
						}
						return players[index];
						IL_002a:
						int num2;
						if (index >= 0)
						{
							num = 1303459313;
							num2 = num;
						}
						else
						{
							num = 1303459314;
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
			while (true)
			{
				int num2 = 120786435;
				while (true)
				{
					switch (num2 ^ 0x7330E02)
					{
					case 2:
						break;
					case 1:
						num2 = 120786433;
						continue;
					case 0:
						if (players[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
						{
							return players[num].id;
						}
						num++;
						num2 = 120786433;
						continue;
					default:
						if (num >= players.Count)
						{
							return -1;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public bool IsMouseAssigned()
		{
			if (players == null)
			{
				return false;
			}
			int count = players.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					int num2;
					if (players[num].assignMouseOnStart)
					{
						num2 = 2023439785;
					}
					else
					{
						num++;
						num2 = 2023439784;
					}
					while (true)
					{
						switch (num2 ^ 0x789B3DAA)
						{
						case 0:
							num2 = 2023439787;
							continue;
						case 1:
							break;
						case 3:
							return true;
						default:
							goto end_IL_003c;
						}
						break;
					}
					continue;
					end_IL_003c:
					break;
				}
			}
			return false;
		}

		public void ClearMouseAssignments()
		{
			if (players == null)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				int count = players.Count;
				int num = 587534607;
				while (true)
				{
					switch (num ^ 0x2305110F)
					{
					case 3:
						num = 587534603;
						continue;
					case 2:
						players[num2].assignMouseOnStart = false;
						num2++;
						num = 587534606;
						continue;
					case 0:
						num2 = 0;
						num = 587534606;
						continue;
					case 4:
						break;
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public bool IsKeyboardAssigned()
		{
			if (players == null)
			{
				goto IL_0008;
			}
			int count = players.Count;
			int num = -1929389541;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1929389544)
				{
				case 0:
					break;
				case 2:
					return false;
				case 4:
					if (players[num2].assignKeyboardOnStart)
					{
						return true;
					}
					num2++;
					num = -1929389539;
					continue;
				case 3:
					num2 = 0;
					num = -1929389543;
					continue;
				case 1:
					num = -1929389539;
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
			goto IL_0008;
			IL_0008:
			num = -1929389542;
			goto IL_000d;
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
				int num2 = -1918840746;
				while (true)
				{
					switch (num2 ^ -1918840746)
					{
					case 2:
						num2 = -1918840745;
						continue;
					case 1:
						break;
					case 3:
						players[num].assignKeyboardOnStart = false;
						num++;
						num2 = -1918840746;
						continue;
					default:
						if (num >= count)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public void AddAction(int categoryId)
		{
			InputAction inputAction = qmmLkpyoMAPiNNUvjLGWnxdTDTy();
			inputAction.categoryId = categoryId;
			actions.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			goto IL_0043;
			IL_0008:
			int num = -1065182817;
			goto IL_000d;
			IL_000d:
			int index = default(int);
			InputAction inputAction = default(InputAction);
			while (true)
			{
				switch (num ^ -1065182818)
				{
				case 2:
					break;
				case 4:
					index = actionCategoryMap.IndexOfAction(categoryId, actionId);
					num = -1065182818;
					continue;
				case 3:
					goto IL_0043;
				case 1:
					return;
				default:
					actionCategoryMap.InsertAction(categoryId, inputAction.id, index);
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0043:
			inputAction = qmmLkpyoMAPiNNUvjLGWnxdTDTy();
			inputAction.categoryId = categoryId;
			actions.Add(inputAction);
			num = -1065182822;
			goto IL_000d;
		}

		public void DeleteAction(int categoryId, int actionId)
		{
			int num = IndexOfActionCategory(categoryId);
			int num3 = default(int);
			while (true)
			{
				int num2 = 2024646332;
				while (true)
				{
					switch (num2 ^ 0x78ADA6BF)
					{
					case 4:
						break;
					case 3:
						if (num < 0)
						{
							return;
						}
						goto case 0;
					case 1:
						return;
					case 0:
					{
						num3 = IndexOfAction(actionId);
						int num4;
						if (num3 < 0)
						{
							num2 = 2024646334;
							num4 = num2;
						}
						else
						{
							num2 = 2024646333;
							num4 = num2;
						}
						continue;
					}
					default:
						actions.RemoveAt(num3);
						actionCategoryMap.RemoveAction(categoryId, actionId);
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
			if (num2 < 0)
			{
				return -1;
			}
			InputAction actionById = GetActionById(actionId);
			InputAction inputAction = default(InputAction);
			while (true)
			{
				int num3 = 494656484;
				while (true)
				{
					switch (num3 ^ 0x1D7BDBE0)
					{
					case 3:
						break;
					case 1:
						actionCategoryMap.AddAction(categoryId, inputAction.id);
						num3 = 494656482;
						continue;
					case 6:
					{
						if (num2 == actions.Count - 1)
						{
							num3 = 494656485;
							continue;
						}
						actions.Insert(num2 + 1, inputAction);
						int num4 = actionCategoryMap.IndexOfAction(categoryId, actionId);
						actionCategoryMap.InsertAction(categoryId, inputAction.id, num4 + 1);
						num3 = 494656480;
						continue;
					}
					case 2:
						return actions.Count - 1;
					case 5:
						actions.Add(inputAction);
						num3 = 494656481;
						continue;
					case 4:
						if (actionById == null)
						{
							return -1;
						}
						inputAction = actionById.Clone();
						inputAction.id = GetNewActionId();
						inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
						num3 = 494656486;
						continue;
					default:
						return num2 + 1;
					}
					break;
				}
			}
		}

		private int nRhtnVkqbagulKNvDLXitdAYEPb(int P_0, InputAction P_1)
		{
			int num = IndexOfActionCategory(P_0);
			while (true)
			{
				int num2 = 54967097;
				while (true)
				{
					switch (num2 ^ 0x346BB38)
					{
					case 0:
						break;
					case 1:
						if (num >= 0)
						{
							goto IL_002c;
						}
						return -1;
					default:
						return actions.Count - 1;
					}
					break;
					IL_002c:
					InputAction inputAction = P_1.Clone();
					inputAction.id = GetNewActionId();
					inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
					actions.Add(inputAction);
					num2 = 54967098;
				}
			}
		}

		public string[] GetActionNames()
		{
			if (actions == null)
			{
				return null;
			}
			string[] array = new string[actions.Count];
			int num = 0;
			while (true)
			{
				int num2 = -1885055424;
				while (true)
				{
					switch (num2 ^ -1885055423)
					{
					case 0:
						break;
					case 1:
						num2 = -1885055422;
						continue;
					case 2:
						array[num] = actions[num].name;
						num++;
						num2 = -1885055422;
						continue;
					default:
						if (num >= actions.Count)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int GetActionNames(IList<string> results)
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
				if (actions != null)
				{
					num = 0;
					num2 = 1721374193;
				}
				else
				{
					num2 = 1721374196;
				}
				while (true)
				{
					switch (num2 ^ 0x669A15F5)
					{
					case 0:
						num2 = 1721374192;
						continue;
					case 4:
					{
						int num3;
						if (num >= actions.Count)
						{
							num2 = 1721374198;
							num3 = num2;
						}
						else
						{
							num2 = 1721374199;
							num3 = num2;
						}
						continue;
					}
					case 2:
						results.Add(actions[num].name);
						num2 = 1721374195;
						continue;
					case 1:
						return 0;
					case 5:
						break;
					case 6:
						num++;
						num2 = 1721374193;
						continue;
					default:
						return results.Count;
					}
					break;
				}
			}
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
				int num = 1135778848;
				while (true)
				{
					switch (num ^ 0x43B29C21)
					{
					case 3:
						break;
					case 1:
						num2 = 0;
						num = 1135778851;
						continue;
					case 0:
						array[num2] = actions[num2].id;
						num2++;
						num = 1135778851;
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
			int num2 = default(int);
			while (true)
			{
				results.Clear();
				int num = 893121757;
				while (true)
				{
					switch (num ^ 0x353BF4DE)
					{
					case 0:
						num = 893121755;
						continue;
					case 2:
						results.Add(actions[num2].id);
						num = 893121759;
						continue;
					case 3:
						if (actions == null)
						{
							return 0;
						}
						num2 = 0;
						num = 893121754;
						continue;
					case 5:
						break;
					case 1:
						num2++;
						num = 893121754;
						continue;
					default:
						if (num2 >= actions.Count)
						{
							return results.Count;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public string GetActionNameById(int id)
		{
			if (actions == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -940804770;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -940804770)
				{
				case 3:
					break;
				case 4:
					if (actions[num].id == id)
					{
						num2 = -940804772;
						continue;
					}
					num++;
					num2 = -940804769;
					continue;
				case 0:
					num2 = -940804769;
					continue;
				case 2:
					return actions[num].name;
				case 5:
					return string.Empty;
				default:
					if (num >= actions.Count)
					{
						return string.Empty;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -940804773;
			goto IL_000d;
		}

		public InputAction GetAction(int index)
		{
			if (actions != null && index >= 0)
			{
				while (true)
				{
					int num = -1585621343;
					while (true)
					{
						switch (num ^ -1585621341)
						{
						case 0:
							break;
						case 2:
							goto IL_002a;
						default:
							goto end_IL_000c;
						}
						break;
						IL_002a:
						if (index >= actions.Count)
						{
							num = -1585621342;
							continue;
						}
						return actions[index];
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			return null;
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
				return null;
			}
			int num = 0;
			while (num < actions.Count)
			{
				while (true)
				{
					if (actions[num].id == id)
					{
						return actions[num];
					}
					num++;
					int num2 = 949517971;
					while (true)
					{
						switch (num2 ^ 0x38987E93)
						{
						case 2:
							num2 = 949517970;
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
			return null;
		}

		public int GetActionId(string name)
		{
			if (actions == null)
			{
				return -1;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return -1;
			}
			return actions[num].id;
		}

		public string[] GetSortedActionNamesInCategory(int id)
		{
			if (actionCategories == null || actions == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			IEnumerator<int> enumerator = actionCategoryMap.ActionIdsInCategory(id).GetEnumerator();
			try
			{
				InputAction actionById = default(InputAction);
				while (enumerator.MoveNext())
				{
					while (true)
					{
						int current = enumerator.Current;
						int num = -332360160;
						while (true)
						{
							switch (num ^ -332360156)
							{
							case 2:
								num = -332360155;
								continue;
							case 1:
								break;
							case 0:
								list.Add(actionById.name);
								num = -332360153;
								continue;
							case 4:
								goto IL_0073;
							default:
								goto end_IL_0052;
							}
							break;
							IL_0073:
							actionById = GetActionById(current);
							int num2;
							if (actionById != null)
							{
								num = -332360156;
								num2 = num;
							}
							else
							{
								num = -332360153;
								num2 = num;
							}
						}
						continue;
						end_IL_0052:
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
						IL_009c:
						int num3 = -332360155;
						while (true)
						{
							switch (num3 ^ -332360156)
							{
							case 0:
								break;
							default:
								goto end_IL_00a1;
							case 1:
								goto IL_00ba;
							case 2:
								goto end_IL_00a1;
							}
							goto IL_009c;
							IL_00ba:
							enumerator.Dispose();
							num3 = -332360154;
							continue;
							end_IL_00a1:
							break;
						}
						break;
					}
				}
			}
			return list.ToArray();
		}

		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			xoWrGhJmFYqiYTaGQTWmZTUwiNa xoWrGhJmFYqiYTaGQTWmZTUwiNa2 = new xoWrGhJmFYqiYTaGQTWmZTUwiNa(-2);
			xoWrGhJmFYqiYTaGQTWmZTUwiNa2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			xoWrGhJmFYqiYTaGQTWmZTUwiNa2.BgfpLKXMFxgDkPNOkjzHjMtFDBY = id;
			return xoWrGhJmFYqiYTaGQTWmZTUwiNa2;
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (actionCategories == null || actions == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			using (IEnumerator<int> enumerator = actionCategoryMap.ActionIdsInCategory(id).GetEnumerator())
			{
				while (true)
				{
					IL_0073:
					int num;
					int num2;
					if (enumerator.MoveNext())
					{
						num = -1879180165;
						num2 = num;
					}
					else
					{
						num = -1879180167;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1879180168)
						{
						case 2:
							num = -1879180165;
							continue;
						default:
							goto end_IL_0031;
						case 3:
						{
							int current = enumerator.Current;
							InputAction actionById = GetActionById(current);
							if (actionById != null)
							{
								list.Add(actionById.descriptiveName);
								num = -1879180168;
								continue;
							}
							break;
						}
						case 0:
							break;
						case 1:
							goto end_IL_0031;
						}
						goto IL_0073;
						continue;
						end_IL_0031:
						break;
					}
					break;
				}
			}
			return list.ToArray();
		}

		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			hRjWIfMCQuDkZRufCIBeAguPPGKa hRjWIfMCQuDkZRufCIBeAguPPGKa2 = new hRjWIfMCQuDkZRufCIBeAguPPGKa(-2);
			hRjWIfMCQuDkZRufCIBeAguPPGKa2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			hRjWIfMCQuDkZRufCIBeAguPPGKa2.BgfpLKXMFxgDkPNOkjzHjMtFDBY = id;
			return hRjWIfMCQuDkZRufCIBeAguPPGKa2;
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
						list.Add(current);
						int num = 628811374;
						while (true)
						{
							switch (num ^ 0x257AE66F)
							{
							case 0:
								num = 628811373;
								continue;
							case 2:
								break;
							default:
								goto end_IL_004a;
							}
							break;
						}
						continue;
						end_IL_004a:
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
						IL_006c:
						int num2 = 628811373;
						while (true)
						{
							switch (num2 ^ 0x257AE66F)
							{
							case 0:
								break;
							default:
								goto end_IL_0071;
							case 2:
								goto IL_008a;
							case 1:
								goto end_IL_0071;
							}
							goto IL_006c;
							IL_008a:
							enumerator.Dispose();
							num2 = 628811374;
							continue;
							end_IL_0071:
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
			kVxBXRwkMqaoOFpvyUVWIDzbIyxf kVxBXRwkMqaoOFpvyUVWIDzbIyxf2 = new kVxBXRwkMqaoOFpvyUVWIDzbIyxf(-2);
			kVxBXRwkMqaoOFpvyUVWIDzbIyxf2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			kVxBXRwkMqaoOFpvyUVWIDzbIyxf2.BgfpLKXMFxgDkPNOkjzHjMtFDBY = id;
			return kVxBXRwkMqaoOFpvyUVWIDzbIyxf2;
		}

		public bool ContainsAction(int id)
		{
			return IndexOfAction(id) >= 0;
		}

		public int IndexOfAction(int id)
		{
			if (actions == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < actions.Count)
				{
					num2 = -1043086002;
					num3 = num2;
				}
				else
				{
					num2 = -1043086004;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1043086003)
					{
					case 2:
						num2 = -1043086002;
						continue;
					case 3:
						if (actions[num].id == id)
						{
							return num;
						}
						num++;
						num2 = -1043086003;
						continue;
					case 0:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public int IndexOfAction(string name)
		{
			if (actions == null)
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
				num2 = 1798960875;
				goto IL_001f;
			}
			goto IL_003c;
			IL_001f:
			while (true)
			{
				switch (num2 ^ 0x6B39F6E9)
				{
				case 3:
					break;
				case 1:
					goto IL_003c;
				case 0:
					goto IL_0047;
				default:
					if (num >= actions.Count)
					{
						return -1;
					}
					goto IL_0047;
				}
				break;
				IL_0047:
				if (actions[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = 1798960875;
			}
			goto IL_001a;
			IL_003c:
			return -1;
			IL_001a:
			num2 = 1798960872;
			goto IL_001f;
		}

		public void AddActionCategory()
		{
			InputCategory inputCategory = TRJwjOZSSTAKChaAiCgKPWJxOmQ();
			while (true)
			{
				int num = -2109402255;
				while (true)
				{
					switch (num ^ -2109402253)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0025;
					case 1:
						return;
					}
					break;
					IL_0025:
					actionCategories.Add(inputCategory);
					actionCategoryMap.AddCategory(inputCategory.id);
					num = -2109402254;
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
			int num = 361104443;
			goto IL_0017;
			IL_0017:
			InputCategory inputCategory = default(InputCategory);
			switch (num ^ 0x15860438)
			{
			case 2:
				break;
			case 3:
				goto IL_0034;
			case 0:
				goto IL_0046;
			default:
				actionCategoryMap.AddCategory(inputCategory.id);
				return;
			}
			goto IL_0012;
			IL_0046:
			inputCategory = TRJwjOZSSTAKChaAiCgKPWJxOmQ();
			actionCategories.Insert(index, inputCategory);
			num = 361104441;
			goto IL_0017;
		}

		public void DeleteActionCategory(int index)
		{
			if (actionCategories != null)
			{
				int num2 = default(int);
				int id = default(int);
				while (true)
				{
					int num = 974363718;
					while (true)
					{
						switch (num ^ 0x3A139C43)
						{
						case 2:
							break;
						case 0:
							if (actions[num2].categoryId == id)
							{
								actions.RemoveAt(num2);
								num = 974363714;
								continue;
							}
							goto case 1;
						case 3:
							goto IL_006f;
						case 6:
							goto end_IL_0008;
						case 9:
							id = actionCategories[index].id;
							num = 974363723;
							continue;
						case 4:
							num2 = actions.Count - 1;
							num = 974363712;
							continue;
						case 5:
							goto IL_00cd;
						case 8:
							goto IL_00f3;
						case 1:
							num2--;
							num = 974363712;
							continue;
						default:
							actionCategories.RemoveAt(index);
							return;
						}
						break;
						IL_00f3:
						actionCategoryMap.RemoveCategory(id);
						int num3;
						if (actions != null)
						{
							num = 974363719;
							num3 = num;
						}
						else
						{
							num = 974363716;
							num3 = num;
						}
						continue;
						IL_00cd:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num4;
						if (index < actionCategories.Count)
						{
							num = 974363722;
							num4 = num;
						}
						else
						{
							num = 974363717;
							num4 = num;
						}
						continue;
						IL_006f:
						int num5;
						if (num2 < 0)
						{
							num = 974363716;
							num5 = num;
						}
						else
						{
							num = 974363715;
							num5 = num;
						}
					}
					continue;
					end_IL_0008:
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
					goto IL_0023;
				}
				goto IL_00d1;
			}
			return;
			IL_0028:
			int num;
			int num2 = default(int);
			int id2 = default(int);
			int id = default(int);
			InputCategory inputCategory = default(InputCategory);
			while (true)
			{
				switch (num ^ -1839134570)
				{
				case 5:
					break;
				default:
					return;
				case 9:
					if (actions[num2].categoryId == id2)
					{
						int num3 = nRhtnVkqbagulKNvDLXitdAYEPb(id2, actions[num2]);
						if (num3 >= 0)
						{
							InputAction inputAction = actions[num3];
							inputAction.categoryId = id;
							actionCategoryMap.AddAction(id, inputAction.id);
							num = -1839134571;
							continue;
						}
					}
					goto case 3;
				case 6:
					goto IL_00d1;
				case 4:
					return;
				case 11:
					goto IL_011c;
				case 2:
					goto IL_0134;
				case 8:
					if (index == actionCategories.Count - 1)
					{
						actionCategories.Add(inputCategory);
						num = -1839134569;
						continue;
					}
					goto case 7;
				case 3:
					num2--;
					num = -1839134563;
					continue;
				case 10:
					id = inputCategory.id;
					id2 = actionCategories[index].id;
					if (actions != null)
					{
						num2 = actions.Count - 1;
						num = -1839134563;
						continue;
					}
					return;
				case 1:
					num = -1839134572;
					continue;
				case 7:
					actionCategories.Insert(index + 1, inputCategory);
					num = -1839134572;
					continue;
				case 0:
					return;
				}
				break;
				IL_0134:
				actionCategoryMap.AddCategory(inputCategory.id);
				int num4;
				if (!duplicateActions)
				{
					num = -1839134570;
					num4 = num;
				}
				else
				{
					num = -1839134564;
					num4 = num;
				}
				continue;
				IL_011c:
				int num5;
				if (num2 >= 0)
				{
					num = -1839134561;
					num5 = num;
				}
				else
				{
					num = -1839134570;
					num5 = num;
				}
			}
			goto IL_0023;
			IL_00d1:
			inputCategory = new InputCategory(actionCategories[index]);
			inputCategory.id = GetNewActionCategoryId();
			inputCategory.name = StringTools.IterateName(inputCategory.name, -1, GetActionCategoryNames());
			num = -1839134562;
			goto IL_0028;
			IL_0023:
			num = -1839134574;
			goto IL_0028;
		}

		public void ChangeActionCategory(int actionId, int newCategoryId)
		{
			int num = IndexOfAction(actionId);
			if (num >= 0 && actions[num].categoryId != newCategoryId)
			{
				actionCategoryMap.ChangeCategory(actionId, newCategoryId);
				actions[num].categoryId = newCategoryId;
			}
		}

		public int GetActionCategoryCount(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int num2 = 671485141;
				while (true)
				{
					switch (num2 ^ 0x28060CD7)
					{
					case 0:
						break;
					case 2:
						if (actions != null)
						{
							num3 = 0;
							num2 = 671485139;
							continue;
						}
						goto default;
					case 4:
					{
						int num4;
						if (num3 < actions.Count)
						{
							num2 = 671485138;
							num4 = num2;
						}
						else
						{
							num2 = 671485142;
							num4 = num2;
						}
						continue;
					}
					case 3:
						num3++;
						num2 = 671485139;
						continue;
					case 5:
						if (actions[num3].categoryId == id)
						{
							num++;
							num2 = 671485140;
							continue;
						}
						goto case 3;
					default:
						return num;
					}
					break;
				}
			}
		}

		public int GetActionCategoryIndex(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < actionCategories.Count)
				{
					num2 = 1331309433;
					num3 = num2;
				}
				else
				{
					num2 = 1331309435;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x4F5A2B78)
					{
					case 4:
						num2 = 1331309433;
						continue;
					case 1:
						if (actionCategories[num].id == id)
						{
							num2 = 1331309432;
							continue;
						}
						num++;
						num2 = 1331309434;
						continue;
					case 0:
						return num;
					case 2:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public string[] GetActionCategoryNames()
		{
			if (actionCategories == null)
			{
				return null;
			}
			string[] array = new string[actionCategories.Count];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < actionCategories.Count)
				{
					num2 = -2044357874;
					num3 = num2;
				}
				else
				{
					num2 = -2044357873;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -2044357873)
					{
					case 2:
						num2 = -2044357874;
						continue;
					case 1:
						array[num] = actionCategories[num].name;
						num++;
						num2 = -2044357876;
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

		public int[] GetActionCategoryIds()
		{
			if (actionCategories == null)
			{
				return null;
			}
			int[] array = new int[actionCategories.Count];
			int num2 = default(int);
			while (true)
			{
				int num = -953376215;
				while (true)
				{
					switch (num ^ -953376212)
					{
					case 4:
						break;
					case 2:
						array[num2] = actionCategories[num2].id;
						num2++;
						num = -953376212;
						continue;
					case 3:
						num = -953376212;
						continue;
					case 0:
					{
						int num3;
						if (num2 < actionCategories.Count)
						{
							num = -953376210;
							num3 = num;
						}
						else
						{
							num = -953376211;
							num3 = num;
						}
						continue;
					}
					case 5:
						num2 = 0;
						num = -953376209;
						continue;
					default:
						return array;
					}
					break;
				}
			}
		}

		public InputCategory GetActionCategory(int index)
		{
			if (actionCategories != null)
			{
				while (true)
				{
					int num = 49030976;
					while (true)
					{
						switch (num ^ 0x2EC2743)
						{
						case 0:
							break;
						case 3:
							goto IL_002a;
						case 2:
							goto IL_003f;
						default:
							goto end_IL_0008;
						}
						break;
						IL_003f:
						if (index >= actionCategories.Count)
						{
							num = 49030978;
							continue;
						}
						return actionCategories[index];
						IL_002a:
						int num2;
						if (index < 0)
						{
							num = 49030978;
							num2 = num;
						}
						else
						{
							num = 49030977;
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
				return -1;
			}
			int num = IndexOfActionCategory(name);
			if (num < 0)
			{
				return -1;
			}
			return actionCategories[num].id;
		}

		public string GetActionCategoryNameById(int id)
		{
			if (actionCategories == null)
			{
				return string.Empty;
			}
			int num = 0;
			while (num < actionCategories.Count)
			{
				while (true)
				{
					if (actionCategories[num].id == id)
					{
						return actionCategories[num].name;
					}
					num++;
					int num2 = 1143968587;
					while (true)
					{
						switch (num2 ^ 0x442F934A)
						{
						case 0:
							num2 = 1143968584;
							continue;
						case 2:
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

		public int IndexOfActionCategory(int id)
		{
			if (actionCategories == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1028857972;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x3D532077)
				{
				case 2:
					break;
				case 4:
					return num;
				case 3:
					num2 = 1028857975;
					continue;
				case 1:
					return -1;
				case 5:
					if (actionCategories[num].id != id)
					{
						num++;
						num2 = 1028857975;
					}
					else
					{
						num2 = 1028857971;
					}
					continue;
				default:
					if (num >= actionCategories.Count)
					{
						return -1;
					}
					goto case 5;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1028857974;
			goto IL_000d;
		}

		public int IndexOfActionCategory(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (actionCategories == null)
				{
					return -1;
				}
				num = 0;
				num2 = -1068486246;
				goto IL_0015;
			}
			goto IL_0032;
			IL_0015:
			while (true)
			{
				switch (num2 ^ -1068486247)
				{
				case 2:
					break;
				case 1:
					goto IL_0032;
				case 0:
					goto IL_0047;
				default:
					if (num >= actionCategories.Count)
					{
						return -1;
					}
					goto IL_0047;
				}
				break;
				IL_0047:
				if (actionCategories[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = -1068486246;
			}
			goto IL_0010;
			IL_0010:
			num2 = -1068486248;
			goto IL_0015;
			IL_0032:
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
			inputBehaviors.Add(sQjLOUlHnCqbfWBVphJhsTFnFdc());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0)
			{
				goto IL_0034;
			}
			if (index >= inputBehaviors.Count)
			{
				goto IL_0012;
			}
			goto IL_0046;
			IL_0046:
			inputBehaviors.Insert(index, sQjLOUlHnCqbfWBVphJhsTFnFdc());
			int num = 1457767005;
			goto IL_0017;
			IL_0012:
			num = 1457767004;
			goto IL_0017;
			IL_0017:
			switch (num ^ 0x56E3C25D)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				goto IL_0034;
			case 2:
				goto IL_0046;
			case 0:
				return;
			}
			goto IL_0012;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors != null)
			{
				int num2 = default(int);
				int id = default(int);
				while (true)
				{
					int num = -691150015;
					while (true)
					{
						switch (num ^ -691150005)
						{
						case 2:
							break;
						case 5:
							goto IL_004c;
						case 6:
							if (actions != null)
							{
								num2 = 0;
								num = -691150004;
								continue;
							}
							goto default;
						case 8:
							actions[num2].behaviorId = 0;
							num = -691150008;
							continue;
						case 4:
							goto end_IL_000b;
						case 7:
							goto IL_00b6;
						case 10:
							goto IL_00d8;
						case 9:
							id = inputBehaviors[index].id;
							num = -691150003;
							continue;
						case 0:
							goto IL_010c;
						case 3:
							num2++;
							num = -691150004;
							continue;
						default:
							inputBehaviors.RemoveAt(index);
							return;
						}
						break;
						IL_010c:
						int num3;
						if (index < inputBehaviors.Count)
						{
							num = -691150014;
							num3 = num;
						}
						else
						{
							num = -691150001;
							num3 = num;
						}
						continue;
						IL_00b6:
						int num4;
						if (num2 >= actions.Count)
						{
							num = -691150006;
							num4 = num;
						}
						else
						{
							num = -691150002;
							num4 = num;
						}
						continue;
						IL_004c:
						int num5;
						if (actions[num2].behaviorId == id)
						{
							num = -691150013;
							num5 = num;
						}
						else
						{
							num = -691150008;
							num5 = num;
						}
						continue;
						IL_00d8:
						int num6;
						if (index < 0)
						{
							num = -691150001;
							num6 = num;
						}
						else
						{
							num = -691150005;
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
					int num = -1887546462;
					while (true)
					{
						switch (num ^ -1887546461)
						{
						case 2:
							break;
						case 1:
							goto IL_003f;
						case 0:
							if (index == inputBehaviors.Count - 1)
							{
								inputBehaviors.Add(inputBehavior);
								return;
							}
							goto default;
						case 5:
							inputBehavior = inputBehaviors[index].Clone();
							inputBehavior.id = GetNewInputBehaviorId();
							inputBehavior.name = StringTools.IterateName(inputBehavior.name, -1, GetInputBehaviorNames());
							num = -1887546461;
							continue;
						case 4:
							goto end_IL_0012;
						default:
							inputBehaviors.Insert(index + 1, inputBehavior);
							return;
						}
						break;
						IL_003f:
						int num2;
						if (index < inputBehaviors.Count)
						{
							num = -1887546458;
							num2 = num;
						}
						else
						{
							num = -1887546457;
							num2 = num;
						}
					}
					continue;
					end_IL_0012:
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
			while (true)
			{
				int num2;
				int num3;
				if (num < inputBehaviors.Count)
				{
					num2 = 1389978565;
					num3 = num2;
				}
				else
				{
					num2 = 1389978567;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x52D963C6)
					{
					case 0:
						num2 = 1389978565;
						continue;
					case 3:
						array[num] = inputBehaviors[num].name;
						num++;
						num2 = 1389978564;
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

		public int[] GetInputBehaviorIds()
		{
			if (inputBehaviors == null)
			{
				goto IL_0008;
			}
			int[] array = new int[inputBehaviors.Count];
			int num = 1448052682;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x564F87CE)
				{
				case 0:
					break;
				case 5:
				{
					int num3;
					if (num2 < inputBehaviors.Count)
					{
						num = 1448052684;
						num3 = num;
					}
					else
					{
						num = 1448052680;
						num3 = num;
					}
					continue;
				}
				case 2:
					array[num2] = inputBehaviors[num2].id;
					num = 1448052685;
					continue;
				case 4:
					num2 = 0;
					num = 1448052683;
					continue;
				case 1:
					return null;
				case 3:
					num2++;
					num = 1448052683;
					continue;
				default:
					return array;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num = 1448052687;
			goto IL_000d;
		}

		public InputBehavior GetInputBehavior(int index)
		{
			if (inputBehaviors != null && index >= 0)
			{
				while (true)
				{
					int num = -888601132;
					while (true)
					{
						switch (num ^ -888601131)
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
						if (index >= inputBehaviors.Count)
						{
							num = -888601129;
							continue;
						}
						return inputBehaviors[index];
					}
					continue;
					end_IL_000c:
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
				int num2;
				int num3;
				if (num < inputBehaviors.Count)
				{
					num2 = 1763256734;
					num3 = num2;
				}
				else
				{
					num2 = 1763256733;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x6919299F)
					{
					case 3:
						num2 = 1763256734;
						continue;
					case 1:
						if (inputBehaviors[num].id == id)
						{
							return inputBehaviors[num];
						}
						num++;
						num2 = 1763256735;
						continue;
					case 0:
						break;
					default:
						return null;
					}
					break;
				}
			}
		}

		public int GetInputBehaviorId(string name)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			int num = IndexOfInputBehavior(name);
			if (num < 0)
			{
				return -1;
			}
			return inputBehaviors[num].id;
		}

		public int IndexOfInputBehavior(int id)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = -670077223;
				while (true)
				{
					switch (num2 ^ -670077221)
					{
					case 4:
						break;
					case 2:
						num2 = -670077224;
						continue;
					case 3:
					{
						int num3;
						if (num < inputBehaviors.Count)
						{
							num2 = -670077218;
							num3 = num2;
						}
						else
						{
							num2 = -670077222;
							num3 = num2;
						}
						continue;
					}
					case 5:
						if (inputBehaviors[num].id == id)
						{
							num2 = -670077221;
							continue;
						}
						num++;
						num2 = -670077224;
						continue;
					case 0:
						return num;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public int IndexOfInputBehavior(string name)
		{
			if (inputBehaviors == null)
			{
				goto IL_0008;
			}
			int num;
			int num2;
			if (name == null)
			{
				num = 883777798;
				num2 = num;
			}
			else
			{
				num = 883777796;
				num2 = num;
			}
			goto IL_000d;
			IL_0008:
			num = 883777794;
			goto IL_000d;
			IL_000d:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x34AD6104)
				{
				case 3:
					break;
				case 5:
					num = 883777797;
					continue;
				case 2:
					return -1;
				case 0:
					if (!(name == string.Empty))
					{
						num3 = 0;
						num = 883777793;
					}
					else
					{
						num = 883777798;
					}
					continue;
				case 4:
					if (inputBehaviors[num3].name.Equals(name, StringComparison.OrdinalIgnoreCase))
					{
						return num3;
					}
					num3++;
					num = 883777797;
					continue;
				case 6:
					return -1;
				default:
					if (num3 >= inputBehaviors.Count)
					{
						return -1;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0008;
		}

		public void AddMapCategory()
		{
			mapCategories.Add(ecUyQZFJdpXDXsgxHLbjdNRNGMI());
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
					switch (0x2E5C57DF ^ 0x2E5C57DE)
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
			mapCategories.Insert(index, ecUyQZFJdpXDXsgxHLbjdNRNGMI());
		}

		public void DeleteMapCategory(int index)
		{
			if (mapCategories != null)
			{
				int num8 = default(int);
				int id = default(int);
				int num6 = default(int);
				int num5 = default(int);
				InputMapCategory inputMapCategory = default(InputMapCategory);
				int num7 = default(int);
				int num2 = default(int);
				Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
				Player_Editor player_Editor = default(Player_Editor);
				int num4 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = 518143081;
					while (true)
					{
						switch (num ^ 0x1EE23C48)
						{
						case 12:
							break;
						case 34:
							num8 = mouseMaps.Count - 1;
							num = 518143070;
							continue;
						case 25:
							id = mapCategories[index].id;
							if (joystickMaps != null)
							{
								num6 = joystickMaps.Count - 1;
								num = 518143083;
								continue;
							}
							goto case 23;
						case 18:
							goto IL_0109;
						case 33:
							goto IL_0125;
						case 28:
							if (customControllerMaps[num5].categoryId == id)
							{
								customControllerMaps.RemoveAt(num5);
								num = 518143069;
								continue;
							}
							goto case 21;
						case 11:
							num = 518143049;
							continue;
						case 5:
							if (mouseMaps[num8].categoryId == id)
							{
								mouseMaps.RemoveAt(num8);
								num = 518143062;
								continue;
							}
							goto case 30;
						case 24:
							goto IL_01b4;
						case 32:
							if (inputMapCategory.checkConflictsCategoryIds[num7] == id)
							{
								inputMapCategory.checkConflictsCategoryIds.RemoveAt(num7);
								num = 518143051;
								continue;
							}
							goto case 3;
						case 23:
							if (keyboardMaps != null)
							{
								num2 = keyboardMaps.Count - 1;
								num = 518143084;
								continue;
							}
							goto IL_03e2;
						case 10:
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultCustomControllerMaps, id);
							num = 518143045;
							continue;
						case 2:
							CS_0024_003C_003E9__CachedAnonymousMethodDelegate60 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
							{
								if (P_0 == null)
								{
									return;
								}
								while (true)
								{
									int num22 = P_0.Count - 1;
									int num23 = 2019667431;
									while (true)
									{
										switch (num23 ^ 0x7861ADE5)
										{
										case 5:
											num23 = 2019667428;
											continue;
										case 1:
											break;
										case 0:
											P_0.RemoveAt(num22);
											num23 = 2019667427;
											continue;
										case 6:
											num22--;
											num23 = 2019667425;
											continue;
										case 2:
											num23 = 2019667425;
											continue;
										case 3:
											if (P_0[num22] != null)
											{
												int num24;
												if (P_0[num22].categoryId == P_1)
												{
													num23 = 2019667429;
													num24 = num23;
												}
												else
												{
													num23 = 2019667427;
													num24 = num23;
												}
												continue;
											}
											goto case 0;
										default:
											if (num22 < 0)
											{
												return;
											}
											goto case 3;
										}
										break;
									}
								}
							};
							num = 518143055;
							continue;
						case 30:
							num8--;
							num = 518143070;
							continue;
						case 35:
							goto IL_0269;
						case 3:
							num7++;
							num = 518143056;
							continue;
						case 36:
							goto IL_0291;
						case 9:
							inputMapCategory = mapCategories[num4];
							if (inputMapCategory.checkConflictsCategoryIds != null)
							{
								num7 = 0;
								num = 518143056;
								continue;
							}
							goto case 38;
						case 37:
							goto IL_02d1;
						case 6:
							goto end_IL_000b;
						case 13:
							num3++;
							num = 518143047;
							continue;
						case 26:
							num6--;
							num = 518143083;
							continue;
						case 21:
							num5--;
							num = 518143048;
							continue;
						case 4:
							num2--;
							num = 518143084;
							continue;
						case 14:
							joystickMaps.RemoveAt(num6);
							num = 518143058;
							continue;
						case 27:
							goto IL_0360;
						case 22:
							goto IL_037c;
						case 16:
							goto IL_0394;
						case 15:
							goto IL_03af;
						case 38:
							num4++;
							num = 518143049;
							continue;
						case 20:
							goto IL_03e2;
						case 8:
							player_Editor = players[num3];
							if (player_Editor != null)
							{
								cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultKeyboardMaps, id);
								cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultMouseMaps, id);
								cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultJoystickMaps, id);
								num = 518143042;
								continue;
							}
							goto case 13;
						case 19:
							if (customControllerMaps != null)
							{
								num5 = customControllerMaps.Count - 1;
								num = 518143048;
								continue;
							}
							goto IL_0109;
						case 1:
							goto IL_046f;
						case 17:
							num4 = 0;
							num = 518143043;
							continue;
						case 0:
							goto IL_049f;
						case 7:
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate60;
							num3 = 0;
							num = 518143047;
							continue;
						case 31:
							if (keyboardMaps[num2].categoryId == id)
							{
								keyboardMaps.RemoveAt(num2);
								num = 518143052;
								continue;
							}
							goto case 4;
						default:
							mapCategories.RemoveAt(index);
							return;
						}
						break;
						IL_049f:
						int num9;
						if (num5 >= 0)
						{
							num = 518143060;
							num9 = num;
						}
						else
						{
							num = 518143066;
							num9 = num;
						}
						continue;
						IL_0125:
						if (index < 0)
						{
							goto end_IL_000b;
						}
						int num10;
						if (index < mapCategories.Count)
						{
							num = 518143057;
							num10 = num;
						}
						else
						{
							num = 518143054;
							num10 = num;
						}
						continue;
						IL_0269:
						int num11;
						if (num6 >= 0)
						{
							num = 518143085;
							num11 = num;
						}
						else
						{
							num = 518143071;
							num11 = num;
						}
						continue;
						IL_046f:
						int num12;
						if (num4 < mapCategories.Count)
						{
							num = 518143041;
							num12 = num;
						}
						else
						{
							num = 518143059;
							num12 = num;
						}
						continue;
						IL_0360:
						int num13;
						if (players != null)
						{
							num = 518143064;
							num13 = num;
						}
						else
						{
							num = 518143061;
							num13 = num;
						}
						continue;
						IL_02d1:
						int num14;
						if (joystickMaps[num6].categoryId == id)
						{
							num = 518143046;
							num14 = num;
						}
						else
						{
							num = 518143058;
							num14 = num;
						}
						continue;
						IL_03af:
						int num15;
						if (num3 < players.Count)
						{
							num = 518143040;
							num15 = num;
						}
						else
						{
							num = 518143061;
							num15 = num;
						}
						continue;
						IL_01b4:
						int num16;
						if (num7 < inputMapCategory.checkConflictsCategoryIds.Count)
						{
							num = 518143080;
							num16 = num;
						}
						else
						{
							num = 518143086;
							num16 = num;
						}
						continue;
						IL_03e2:
						int num17;
						if (mouseMaps == null)
						{
							num = 518143067;
							num17 = num;
						}
						else
						{
							num = 518143082;
							num17 = num;
						}
						continue;
						IL_0394:
						int num18;
						if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate60 != null)
						{
							num = 518143055;
							num18 = num;
						}
						else
						{
							num = 518143050;
							num18 = num;
						}
						continue;
						IL_0291:
						int num19;
						if (num2 < 0)
						{
							num = 518143068;
							num19 = num;
						}
						else
						{
							num = 518143063;
							num19 = num;
						}
						continue;
						IL_0109:
						int num20;
						if (mapCategories == null)
						{
							num = 518143059;
							num20 = num;
						}
						else
						{
							num = 518143065;
							num20 = num;
						}
						continue;
						IL_037c:
						int num21;
						if (num8 < 0)
						{
							num = 518143067;
							num21 = num;
						}
						else
						{
							num = 518143053;
							num21 = num;
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
			if (mapCategories != null)
			{
				int num2 = default(int);
				InputMapCategory inputMapCategory = default(InputMapCategory);
				int num4 = default(int);
				int id2 = default(int);
				int num9 = default(int);
				int id = default(int);
				int num5 = default(int);
				int num8 = default(int);
				int num7 = default(int);
				int num3 = default(int);
				int num6 = default(int);
				while (true)
				{
					int num = -445766602;
					while (true)
					{
						switch (num ^ -445766617)
						{
						case 26:
							break;
						default:
							return;
						case 14:
							num2--;
							num = -445766593;
							continue;
						case 28:
							mapCategories.Add(inputMapCategory);
							num = -445766622;
							continue;
						case 2:
							customControllerMaps[num4].categoryId = id2;
							num = -445766624;
							continue;
						case 25:
							goto end_IL_000b;
						case 24:
							goto IL_00ec;
						case 20:
							if (keyboardMaps[num9].categoryId == id)
							{
								num5 = DuplicateKeyboardMap(num9);
								num = -445766618;
								continue;
							}
							goto case 0;
						case 27:
							num8--;
							num = -445766603;
							continue;
						case 4:
							if (keyboardMaps != null)
							{
								num9 = keyboardMaps.Count - 1;
								num = -445766610;
								continue;
							}
							goto case 21;
						case 5:
							num = -445766601;
							continue;
						case 11:
							if (customControllerMaps != null)
							{
								num7 = customControllerMaps.Count - 1;
								num = -445766608;
								continue;
							}
							return;
						case 6:
							if (customControllerMaps[num7].categoryId == id)
							{
								goto IL_01a9;
							}
							goto case 7;
						case 19:
							if (num3 >= 0)
							{
								mouseMaps[num3].categoryId = id2;
								num = -445766615;
								continue;
							}
							goto case 14;
						case 17:
							goto IL_01f1;
						case 16:
							if (duplicateMaps)
							{
								id2 = inputMapCategory.id;
								id = mapCategories[index].id;
								if (joystickMaps != null)
								{
									num8 = joystickMaps.Count - 1;
									num = -445766603;
									continue;
								}
								goto case 4;
							}
							return;
						case 9:
							goto IL_025c;
						case 13:
							if (joystickMaps[num8].categoryId == id)
							{
								num6 = DuplicateJoystickMap(num8);
								num = -445766616;
								continue;
							}
							goto case 27;
						case 7:
							num7--;
							num = -445766608;
							continue;
						case 22:
							mapCategories.Insert(index + 1, inputMapCategory);
							num = -445766601;
							continue;
						case 15:
							if (num6 >= 0)
							{
								joystickMaps[num6].categoryId = id2;
								num = -445766596;
								continue;
							}
							goto case 27;
						case 0:
							num9--;
							num = -445766610;
							continue;
						case 21:
							if (mouseMaps != null)
							{
								num2 = mouseMaps.Count - 1;
								num = -445766593;
								continue;
							}
							goto case 11;
						case 12:
							keyboardMaps[num5].categoryId = id2;
							num = -445766617;
							continue;
						case 8:
							goto IL_033e;
						case 1:
							goto IL_0398;
						case 23:
							goto IL_03b1;
						case 10:
							if (mouseMaps[num2].categoryId == id)
							{
								num3 = DuplicateMouseMap(num2);
								num = -445766604;
								continue;
							}
							goto case 14;
						case 18:
							goto IL_03f6;
						case 3:
							return;
						}
						break;
						IL_03f6:
						int num10;
						if (num8 >= 0)
						{
							num = -445766614;
							num10 = num;
						}
						else
						{
							num = -445766621;
							num10 = num;
						}
						continue;
						IL_01f1:
						if (index < 0)
						{
							goto end_IL_000b;
						}
						int num11;
						if (index >= mapCategories.Count)
						{
							num = -445766594;
							num11 = num;
						}
						else
						{
							num = -445766609;
							num11 = num;
						}
						continue;
						IL_033e:
						inputMapCategory = new InputMapCategory(mapCategories[index]);
						inputMapCategory.id = GetNewMapCategoryId();
						inputMapCategory.name = StringTools.IterateName(inputMapCategory.name, -1, GetMapCategoryNames());
						int num12;
						if (index != mapCategories.Count - 1)
						{
							num = -445766607;
							num12 = num;
						}
						else
						{
							num = -445766597;
							num12 = num;
						}
						continue;
						IL_03b1:
						int num13;
						if (num7 >= 0)
						{
							num = -445766623;
							num13 = num;
						}
						else
						{
							num = -445766620;
							num13 = num;
						}
						continue;
						IL_025c:
						int num14;
						if (num9 >= 0)
						{
							num = -445766605;
							num14 = num;
						}
						else
						{
							num = -445766606;
							num14 = num;
						}
						continue;
						IL_00ec:
						int num15;
						if (num2 >= 0)
						{
							num = -445766611;
							num15 = num;
						}
						else
						{
							num = -445766612;
							num15 = num;
						}
						continue;
						IL_0398:
						int num16;
						if (num5 < 0)
						{
							num = -445766617;
							num16 = num;
						}
						else
						{
							num = -445766613;
							num16 = num;
						}
						continue;
						IL_01a9:
						num4 = DuplicateCustomControllerMap(num7);
						int num17;
						if (num4 < 0)
						{
							num = -445766624;
							num17 = num;
						}
						else
						{
							num = -445766619;
							num17 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetMapCategoryMapCount(int id)
		{
			if (mapCategories == null)
			{
				goto IL_000b;
			}
			int num = 0;
			int num2 = default(int);
			int num3;
			if (joystickMaps != null)
			{
				num2 = 0;
				num3 = -1533874337;
				goto IL_0010;
			}
			goto IL_0172;
			IL_0010:
			int num4 = default(int);
			int num6 = default(int);
			int num5 = default(int);
			while (true)
			{
				switch (num3 ^ -1533874338)
				{
				case 0:
					break;
				case 18:
					num4++;
					num3 = -1533874358;
					continue;
				case 15:
					num6++;
					num3 = -1533874353;
					continue;
				case 9:
					num3 = -1533874347;
					continue;
				case 3:
					num3 = -1533874358;
					continue;
				case 6:
					if (keyboardMaps[num5].categoryId == id)
					{
						num++;
						num3 = -1533874343;
						continue;
					}
					goto case 7;
				case 10:
					num++;
					num3 = -1533874351;
					continue;
				case 1:
					goto IL_00db;
				case 7:
					num5++;
					num3 = -1533874347;
					continue;
				case 5:
					goto IL_010b;
				case 11:
					goto IL_0127;
				case 16:
					goto IL_0149;
				case 22:
					goto IL_0172;
				case 14:
					num2++;
					num3 = -1533874337;
					continue;
				case 2:
					return 0;
				case 21:
					if (joystickMaps[num2].categoryId == id)
					{
						num++;
						num3 = -1533874352;
						continue;
					}
					goto case 14;
				case 20:
					goto IL_01d6;
				case 19:
					num6 = 0;
					num3 = -1533874353;
					continue;
				case 4:
					num5 = 0;
					num3 = -1533874345;
					continue;
				case 13:
					if (mouseMaps[num4].categoryId == id)
					{
						num++;
						num3 = -1533874356;
						continue;
					}
					goto case 18;
				case 8:
					if (mouseMaps != null)
					{
						num4 = 0;
						num3 = -1533874339;
						continue;
					}
					goto IL_010b;
				case 17:
					goto IL_024d;
				default:
					return num;
				}
				break;
				IL_024d:
				int num7;
				if (num6 >= customControllerMaps.Count)
				{
					num3 = -1533874350;
					num7 = num3;
				}
				else
				{
					num3 = -1533874354;
					num7 = num3;
				}
				continue;
				IL_0149:
				int num8;
				if (customControllerMaps[num6].categoryId == id)
				{
					num3 = -1533874348;
					num8 = num3;
				}
				else
				{
					num3 = -1533874351;
					num8 = num3;
				}
				continue;
				IL_010b:
				int num9;
				if (customControllerMaps != null)
				{
					num3 = -1533874355;
					num9 = num3;
				}
				else
				{
					num3 = -1533874350;
					num9 = num3;
				}
				continue;
				IL_01d6:
				int num10;
				if (num4 >= mouseMaps.Count)
				{
					num3 = -1533874341;
					num10 = num3;
				}
				else
				{
					num3 = -1533874349;
					num10 = num3;
				}
				continue;
				IL_00db:
				int num11;
				if (num2 >= joystickMaps.Count)
				{
					num3 = -1533874360;
					num11 = num3;
				}
				else
				{
					num3 = -1533874357;
					num11 = num3;
				}
				continue;
				IL_0127:
				int num12;
				if (num5 >= keyboardMaps.Count)
				{
					num3 = -1533874346;
					num12 = num3;
				}
				else
				{
					num3 = -1533874344;
					num12 = num3;
				}
			}
			goto IL_000b;
			IL_0172:
			int num13;
			if (keyboardMaps == null)
			{
				num3 = -1533874346;
				num13 = num3;
			}
			else
			{
				num3 = -1533874342;
				num13 = num3;
			}
			goto IL_0010;
			IL_000b:
			num3 = -1533874340;
			goto IL_0010;
		}

		public int GetMapCategoryIndex(int id)
		{
			if (mapCategories == null)
			{
				return 0;
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
					int num2 = -1109862630;
					while (true)
					{
						switch (num2 ^ -1109862632)
						{
						case 0:
							num2 = -1109862631;
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

		public string[] GetMapCategoryNames()
		{
			if (mapCategories == null)
			{
				goto IL_0008;
			}
			string[] array = new string[mapCategories.Count];
			int num = 0;
			int num2 = -3235861;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -3235857)
				{
				case 0:
					break;
				case 1:
					num++;
					num2 = -3235859;
					continue;
				case 4:
					num2 = -3235859;
					continue;
				case 5:
					return null;
				case 3:
					array[num] = mapCategories[num].name;
					num2 = -3235858;
					continue;
				default:
					if (num >= mapCategories.Count)
					{
						return array;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -3235862;
			goto IL_000d;
		}

		public int[] GetMapCategoryIds()
		{
			if (mapCategories == null)
			{
				goto IL_0008;
			}
			int[] array = new int[mapCategories.Count];
			int num = 0;
			int num2 = -579957954;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -579957954)
				{
				case 3:
					break;
				case 0:
				{
					int num3;
					if (num >= mapCategories.Count)
					{
						num2 = -579957958;
						num3 = num2;
					}
					else
					{
						num2 = -579957953;
						num3 = num2;
					}
					continue;
				}
				case 1:
					array[num] = mapCategories[num].id;
					num++;
					num2 = -579957954;
					continue;
				case 2:
					return null;
				default:
					return array;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -579957956;
			goto IL_000d;
		}

		public InputMapCategory GetMapCategory(int index)
		{
			if (mapCategories != null)
			{
				while (true)
				{
					int num = 1712068840;
					while (true)
					{
						switch (num ^ 0x660C18E9)
						{
						case 2:
							break;
						case 1:
							goto IL_002a;
						case 0:
							goto IL_003f;
						default:
							goto end_IL_0008;
						}
						break;
						IL_003f:
						if (index >= mapCategories.Count)
						{
							num = 1712068842;
							continue;
						}
						return mapCategories[index];
						IL_002a:
						int num2;
						if (index >= 0)
						{
							num = 1712068841;
							num2 = num;
						}
						else
						{
							num = 1712068842;
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
			int num2 = -719578580;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -719578578)
				{
				case 0:
					break;
				case 4:
					return null;
				case 3:
					if (mapCategories[num].id == id)
					{
						return mapCategories[num];
					}
					num++;
					num2 = -719578577;
					continue;
				case 2:
					num2 = -719578577;
					continue;
				default:
					if (num >= mapCategories.Count)
					{
						return null;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -719578582;
			goto IL_000d;
		}

		public int GetMapCategoryId(string name)
		{
			if (mapCategories == null)
			{
				goto IL_0008;
			}
			int num = IndexOfMapCategory(name);
			int num2 = -806904359;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ -806904357)
			{
			case 0:
				break;
			case 1:
				return -1;
			default:
				if (num < 0)
				{
					return -1;
				}
				return mapCategories[num].id;
			}
			goto IL_0008;
			IL_0008:
			num2 = -806904358;
			goto IL_000d;
		}

		public string GetMapCategoryNameById(int id)
		{
			if (mapCategories == null)
			{
				goto IL_000b;
			}
			int num = 0;
			int num2 = 1929983447;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num2 ^ 0x730935D4)
				{
				case 0:
					break;
				case 4:
					if (mapCategories[num].id == id)
					{
						return mapCategories[num].name;
					}
					num++;
					num2 = 1929983441;
					continue;
				case 3:
					num2 = 1929983441;
					continue;
				case 5:
				{
					int num3;
					if (num >= mapCategories.Count)
					{
						num2 = 1929983446;
						num3 = num2;
					}
					else
					{
						num2 = 1929983440;
						num3 = num2;
					}
					continue;
				}
				case 1:
					return string.Empty;
				default:
					return string.Empty;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num2 = 1929983445;
			goto IL_0010;
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
					int num2 = -1984396423;
					while (true)
					{
						switch (num2 ^ -1984396424)
						{
						case 0:
							num2 = -1984396422;
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
			return -1;
		}

		public int IndexOfMapCategory(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (mapCategories == null)
				{
					return -1;
				}
				num = 0;
				num2 = 819720936;
				goto IL_0015;
			}
			goto IL_0032;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x30DBF2EB)
				{
				case 0:
					break;
				case 2:
					goto IL_0032;
				case 1:
					goto IL_0047;
				default:
					if (num >= mapCategories.Count)
					{
						return -1;
					}
					goto IL_0047;
				}
				break;
				IL_0047:
				if (mapCategories[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = 819720936;
			}
			goto IL_0010;
			IL_0010:
			num2 = 819720937;
			goto IL_0015;
			IL_0032:
			return -1;
		}

		public string[] GetLayoutNames(ControllerType controllerType)
		{
			switch (controllerType)
			{
			default:
				while (true)
				{
					switch (-1562500383 ^ -1562500384)
					{
					case 2:
						continue;
					case 1:
						if (controllerType == ControllerType.Custom)
						{
							return GetCustomControllerLayoutNames();
						}
						throw new NotImplementedException();
					}
					break;
				}
				goto case ControllerType.Keyboard;
			case ControllerType.Keyboard:
				return GetKeyboardLayoutNames();
			case ControllerType.Mouse:
				return GetMouseLayoutNames();
			case ControllerType.Joystick:
				return GetJoystickLayoutNames();
			}
		}

		public int[] GetLayoutIds(ControllerType controllerType)
		{
			while (true)
			{
				switch (-772912745 ^ -772912746)
				{
				case 2:
					continue;
				case 1:
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						break;
					case ControllerType.Mouse:
						return GetMouseLayoutIds();
					case ControllerType.Joystick:
						return GetJoystickLayoutIds();
					case ControllerType.Custom:
						return GetCustomControllerLayoutIds();
					default:
						throw new NotImplementedException();
					}
					break;
				}
				break;
			}
			return GetKeyboardLayoutIds();
		}

		public void AddJoystickLayout()
		{
			joystickLayouts.Add(jrcBygfzmVMHQPmYGgpgzbYkitSc());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = 641831388;
					while (true)
					{
						switch (num ^ 0x264191DD)
						{
						case 3:
							break;
						case 1:
							goto IL_0026;
						case 2:
							goto end_IL_0004;
						default:
							joystickLayouts.Insert(index, jrcBygfzmVMHQPmYGgpgzbYkitSc());
							return;
						}
						break;
						IL_0026:
						int num2;
						if (index < joystickLayouts.Count)
						{
							num = 641831389;
							num2 = num;
						}
						else
						{
							num = 641831391;
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

		public void DeleteJoystickLayout(int index)
		{
			if (joystickLayouts != null && index >= 0)
			{
				if (index >= joystickLayouts.Count)
				{
					goto IL_0020;
				}
				goto IL_009b;
			}
			goto IL_0161;
			IL_01a0:
			joystickLayouts.RemoveAt(index);
			return;
			IL_0190:
			Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate62;
			int num = -351449317;
			goto IL_0025;
			IL_0020:
			num = -351449319;
			goto IL_0025;
			IL_0025:
			int num3 = default(int);
			int id = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -351449320)
				{
				case 2:
					break;
				case 8:
					num3--;
					num = -351449326;
					continue;
				case 4:
					if (joystickMaps[num3].layoutId == id)
					{
						joystickMaps.RemoveAt(num3);
						num = -351449328;
						continue;
					}
					goto case 8;
				case 0:
					goto IL_009b;
				case 6:
				{
					Player_Editor player_Editor = players[num2];
					if (player_Editor != null)
					{
						cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultJoystickMaps, id);
						num = -351449327;
						continue;
					}
					goto case 9;
				}
				case 10:
					goto IL_00fa;
				case 5:
					goto IL_0112;
				case 12:
					goto IL_013f;
				case 1:
					goto IL_0161;
				case 9:
					num2++;
					num = -351449324;
					continue;
				case 3:
					num2 = 0;
					num = -351449324;
					continue;
				case 7:
					goto IL_0190;
				default:
					goto IL_01a0;
				}
				break;
				IL_013f:
				int num4;
				if (num2 < players.Count)
				{
					num = -351449314;
					num4 = num;
				}
				else
				{
					num = -351449325;
					num4 = num;
				}
				continue;
				IL_00fa:
				int num5;
				if (num3 >= 0)
				{
					num = -351449316;
					num5 = num;
				}
				else
				{
					num = -351449315;
					num5 = num;
				}
			}
			goto IL_0020;
			IL_009b:
			id = joystickLayouts[index].id;
			if (joystickMaps != null)
			{
				num3 = joystickMaps.Count - 1;
				num = -351449326;
				goto IL_0025;
			}
			goto IL_0112;
			IL_0112:
			if (players != null)
			{
				if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate62 == null)
				{
					CS_0024_003C_003E9__CachedAnonymousMethodDelegate62 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
					{
						if (P_0 == null)
						{
							goto IL_0003;
						}
						goto IL_007b;
						IL_0003:
						int num6 = 2106351228;
						goto IL_0008;
						IL_0008:
						int num7 = default(int);
						while (true)
						{
							switch (num6 ^ 0x7D8C5E7F)
							{
							case 4:
								break;
							case 5:
								if (P_0[num7] != null)
								{
									goto IL_003a;
								}
								goto case 0;
							case 0:
								P_0.RemoveAt(num7);
								num6 = 2106351229;
								continue;
							case 3:
								return;
							case 2:
								num7--;
								num6 = 2106351230;
								continue;
							case 6:
								goto IL_007b;
							default:
								if (num7 < 0)
								{
									return;
								}
								goto case 5;
							}
							break;
							IL_003a:
							int num8;
							if (P_0[num7].layoutId == P_1)
							{
								num6 = 2106351231;
								num8 = num6;
							}
							else
							{
								num6 = 2106351229;
								num8 = num6;
							}
						}
						goto IL_0003;
						IL_007b:
						num7 = P_0.Count - 1;
						num6 = 2106351230;
						goto IL_0008;
					};
					num = -351449313;
					goto IL_0025;
				}
				goto IL_0190;
			}
			goto IL_01a0;
			IL_0161:
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderJoystickLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(joystickLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateJoystickLayout(int index, bool duplicateMaps)
		{
			if (joystickLayouts == null || index < 0)
			{
				goto IL_00d7;
			}
			if (index >= joystickLayouts.Count)
			{
				goto IL_0023;
			}
			goto IL_0127;
			IL_00d7:
			throw new ArgumentOutOfRangeException("index");
			IL_0127:
			InputLayout inputLayout = joystickLayouts[index].Clone();
			int num = -806806257;
			goto IL_0028;
			IL_0023:
			num = -806806265;
			goto IL_0028;
			IL_0028:
			int id = default(int);
			int num3 = default(int);
			int id2 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -806806261)
				{
				case 13:
					break;
				default:
					return;
				case 7:
					inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetJoystickLayoutNames());
					num = -806806271;
					continue;
				case 10:
					if (index == joystickLayouts.Count - 1)
					{
						joystickLayouts.Add(inputLayout);
						num = -806806262;
						continue;
					}
					goto case 11;
				case 1:
					if (duplicateMaps)
					{
						id = inputLayout.id;
						num = -806806270;
						continue;
					}
					return;
				case 12:
					goto IL_00d7;
				case 3:
					goto IL_00ec;
				case 14:
					if (joystickMaps != null)
					{
						num3 = joystickMaps.Count - 1;
						num = -806806264;
						continue;
					}
					return;
				case 6:
					goto IL_0127;
				case 9:
					id2 = joystickLayouts[index].id;
					num = -806806267;
					continue;
				case 11:
					joystickLayouts.Insert(index + 1, inputLayout);
					num = -806806262;
					continue;
				case 5:
					goto IL_0178;
				case 2:
					num3--;
					num = -806806264;
					continue;
				case 4:
					inputLayout.id = GetNewJoystickLayoutId();
					num = -806806260;
					continue;
				case 0:
					num2 = DuplicateJoystickMap(num3);
					num = -806806269;
					continue;
				case 8:
					if (num2 >= 0)
					{
						joystickMaps[num2].layoutId = id;
						num = -806806263;
						continue;
					}
					goto case 2;
				case 15:
					return;
				}
				break;
				IL_0178:
				int num4;
				if (joystickMaps[num3].layoutId == id2)
				{
					num = -806806261;
					num4 = num;
				}
				else
				{
					num = -806806263;
					num4 = num;
				}
				continue;
				IL_00ec:
				int num5;
				if (num3 < 0)
				{
					num = -806806268;
					num5 = num;
				}
				else
				{
					num = -806806258;
					num5 = num;
				}
			}
			goto IL_0023;
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
					int num3;
					int num4;
					if (num2 < joystickMaps.Count)
					{
						num3 = 1777469864;
						num4 = num3;
					}
					else
					{
						num3 = 1777469871;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ 0x69F209AC)
						{
						case 2:
							num3 = 1777469864;
							continue;
						case 4:
							if (joystickMaps[num2].layoutId == id)
							{
								num++;
								num3 = 1777469868;
								continue;
							}
							goto case 0;
						case 1:
							break;
						case 0:
							num2++;
							num3 = 1777469869;
							continue;
						default:
							goto end_IL_005d;
						}
						break;
					}
					continue;
					end_IL_005d:
					break;
				}
			}
			return num;
		}

		public int GetJoystickLayoutIndex(int id)
		{
			if (joystickLayouts == null)
			{
				return 0;
			}
			int num = 0;
			while (num < joystickLayouts.Count)
			{
				while (true)
				{
					if (joystickLayouts[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = 798821409;
					while (true)
					{
						switch (num2 ^ 0x2F9D0C21)
						{
						case 2:
							num2 = 798821408;
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
				int num = -1078844897;
				while (true)
				{
					switch (num ^ -1078844898)
					{
					case 0:
						break;
					case 1:
						num2 = 0;
						num = -1078844900;
						continue;
					case 2:
					{
						int num3;
						if (num2 < joystickLayouts.Count)
						{
							num = -1078844899;
							num3 = num;
						}
						else
						{
							num = -1078844902;
							num3 = num;
						}
						continue;
					}
					case 3:
						array[num2] = joystickLayouts[num2].name;
						num2++;
						num = -1078844900;
						continue;
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
				return null;
			}
			int[] array = new int[joystickLayouts.Count];
			int num = 0;
			while (true)
			{
				int num2 = -474589186;
				while (true)
				{
					switch (num2 ^ -474589185)
					{
					case 0:
						break;
					case 1:
						num2 = -474589188;
						continue;
					case 2:
						array[num] = joystickLayouts[num].id;
						num++;
						num2 = -474589188;
						continue;
					default:
						if (num >= joystickLayouts.Count)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public InputLayout GetJoystickLayout(int index)
		{
			if (joystickLayouts != null)
			{
				while (true)
				{
					int num = -1972501993;
					while (true)
					{
						switch (num ^ -1972501995)
						{
						case 3:
							break;
						case 2:
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
							num = -1972501995;
							continue;
						}
						return joystickLayouts[index];
						IL_002a:
						int num2;
						if (index < 0)
						{
							num = -1972501995;
							num2 = num;
						}
						else
						{
							num = -1972501996;
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
				goto IL_0008;
			}
			int num = IndexOfJoystickLayout(name);
			int num2;
			if (num < 0)
			{
				num2 = -936882713;
				goto IL_000d;
			}
			return joystickLayouts[num];
			IL_0008:
			num2 = -936882716;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ -936882714)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				return null;
			}
			goto IL_0008;
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
			while (true)
			{
				int num2 = -281124868;
				while (true)
				{
					switch (num2 ^ -281124867)
					{
					case 2:
						break;
					case 1:
						if (num < 0)
						{
							goto IL_0034;
						}
						return joystickLayouts[num].id;
					default:
						return -1;
					}
					break;
					IL_0034:
					num2 = -281124867;
				}
			}
		}

		public int IndexOfJoystickLayout(int id)
		{
			if (joystickLayouts == null)
			{
				return -1;
			}
			int num = 0;
			while (num < joystickLayouts.Count)
			{
				while (true)
				{
					if (joystickLayouts[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = -575956344;
					while (true)
					{
						switch (num2 ^ -575956344)
						{
						case 2:
							num2 = -575956343;
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

		public int IndexOfJoystickLayout(string name)
		{
			int num;
			int num2 = default(int);
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (joystickLayouts == null)
				{
					num = -1282311169;
				}
				else
				{
					num2 = 0;
					num = -1282311171;
				}
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num ^ -1282311169)
				{
				case 4:
					break;
				case 1:
					goto IL_0036;
				case 3:
					goto IL_0047;
				case 0:
					return -1;
				default:
					if (num2 >= joystickLayouts.Count)
					{
						return -1;
					}
					goto IL_0047;
				}
				break;
				IL_0047:
				if (joystickLayouts[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num2;
				}
				num2++;
				num = -1282311171;
			}
			goto IL_0010;
			IL_0010:
			num = -1282311170;
			goto IL_0015;
			IL_0036:
			return -1;
		}

		public string GetJoystickLayoutNameById(int id)
		{
			if (joystickLayouts != null)
			{
				int num = 0;
				while (true)
				{
					int num2 = 109460967;
					while (true)
					{
						switch (num2 ^ 0x6863DE3)
						{
						case 0:
							break;
						case 3:
							goto IL_0030;
						case 1:
							goto IL_004f;
						case 4:
							num2 = 109460960;
							continue;
						default:
							goto end_IL_000a;
						}
						break;
						IL_004f:
						if (joystickLayouts[num].id == id)
						{
							return joystickLayouts[num].name;
						}
						num++;
						num2 = 109460960;
						continue;
						IL_0030:
						int num3;
						if (num >= joystickLayouts.Count)
						{
							num2 = 109460961;
							num3 = num2;
						}
						else
						{
							num2 = 109460962;
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

		public void AddKeyboardLayout()
		{
			keyboardLayouts.Add(ITVOzABurSvFsagyZmuGYtbzJir());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -524075705;
					while (true)
					{
						switch (num ^ -524075708)
						{
						case 0:
							break;
						case 3:
							goto IL_0026;
						case 2:
							goto end_IL_0004;
						default:
							keyboardLayouts.Insert(index, ITVOzABurSvFsagyZmuGYtbzJir());
							return;
						}
						break;
						IL_0026:
						int num2;
						if (index >= keyboardLayouts.Count)
						{
							num = -524075706;
							num2 = num;
						}
						else
						{
							num = -524075707;
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
			if (keyboardLayouts != null)
			{
				int num2 = default(int);
				int num3 = default(int);
				int id = default(int);
				Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
				while (true)
				{
					int num = 22379464;
					while (true)
					{
						switch (num ^ 0x1557BC3)
						{
						case 8:
							break;
						case 9:
							num2++;
							num = 22379469;
							continue;
						case 0:
							goto end_IL_0008;
						case 6:
							if (keyboardMaps[num3].layoutId == id)
							{
								keyboardMaps.RemoveAt(num3);
								num = 22379457;
								continue;
							}
							goto case 2;
						case 1:
							cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate64;
							num2 = 0;
							num = 22379462;
							continue;
						case 5:
							num = 22379469;
							continue;
						case 3:
							if (keyboardMaps != null)
							{
								num3 = keyboardMaps.Count - 1;
								num = 22379470;
								continue;
							}
							goto case 10;
						case 12:
						{
							Player_Editor player_Editor = players[num2];
							if (player_Editor != null)
							{
								cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultKeyboardMaps, id);
								num = 22379466;
								continue;
							}
							goto case 9;
						}
						case 2:
							num3--;
							num = 22379470;
							continue;
						case 10:
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
											int num8 = 52533257;
											while (true)
											{
												switch (num8 ^ 0x3219808)
												{
												case 0:
													num8 = 52533260;
													continue;
												case 2:
													num7--;
													num8 = 52533257;
													continue;
												case 3:
													if (P_0[num7] != null)
													{
														int num9;
														if (P_0[num7].layoutId == P_1)
														{
															num8 = 52533261;
															num9 = num8;
														}
														else
														{
															num8 = 52533258;
															num9 = num8;
														}
														continue;
													}
													goto case 5;
												case 4:
													break;
												case 5:
													P_0.RemoveAt(num7);
													num8 = 52533258;
													continue;
												default:
													if (num7 < 0)
													{
														return;
													}
													goto case 3;
												}
												break;
											}
										}
									};
									num = 22379458;
									continue;
								}
								goto case 1;
							}
							goto default;
						case 13:
							goto IL_0147;
						case 14:
							goto IL_015f;
						case 4:
							id = keyboardLayouts[index].id;
							num = 22379456;
							continue;
						case 11:
							goto IL_019d;
						default:
							keyboardLayouts.RemoveAt(index);
							return;
						}
						break;
						IL_019d:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num4;
						if (index >= keyboardLayouts.Count)
						{
							num = 22379459;
							num4 = num;
						}
						else
						{
							num = 22379463;
							num4 = num;
						}
						continue;
						IL_0147:
						int num5;
						if (num3 < 0)
						{
							num = 22379465;
							num5 = num;
						}
						else
						{
							num = 22379461;
							num5 = num;
						}
						continue;
						IL_015f:
						int num6;
						if (num2 < players.Count)
						{
							num = 22379471;
							num6 = num;
						}
						else
						{
							num = 22379460;
							num6 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public bool ReorderKeyboardLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(keyboardLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateKeyboardLayout(int index, bool duplicateMaps)
		{
			if (keyboardLayouts != null && index >= 0)
			{
				if (index >= keyboardLayouts.Count)
				{
					goto IL_0023;
				}
				goto IL_00a5;
			}
			goto IL_017a;
			IL_017a:
			throw new ArgumentOutOfRangeException("index");
			IL_0127:
			InputLayout inputLayout = default(InputLayout);
			keyboardLayouts.Insert(index + 1, inputLayout);
			int num = 1554055422;
			goto IL_0028;
			IL_0023:
			num = 1554055423;
			goto IL_0028;
			IL_0028:
			int num2 = default(int);
			int id2 = default(int);
			int num3 = default(int);
			int id = default(int);
			while (true)
			{
				switch (num ^ 0x5CA100F6)
				{
				case 2:
					break;
				default:
					return;
				case 11:
					goto IL_0068;
				case 3:
					if (keyboardMaps[num2].layoutId == id2)
					{
						num3 = DuplicateKeyboardMap(num2);
						num = 1554055420;
						continue;
					}
					goto case 1;
				case 0:
					goto IL_00a5;
				case 1:
					num2--;
					num = 1554055410;
					continue;
				case 4:
					goto IL_010f;
				case 5:
					goto IL_0127;
				case 7:
					num2 = keyboardMaps.Count - 1;
					num = 1554055410;
					continue;
				case 10:
					if (num3 >= 0)
					{
						keyboardMaps[num3].layoutId = id;
						num = 1554055415;
						continue;
					}
					goto case 1;
				case 9:
					goto IL_017a;
				case 8:
					if (duplicateMaps)
					{
						id = inputLayout.id;
						id2 = keyboardLayouts[index].id;
						num = 1554055421;
						continue;
					}
					return;
				case 6:
					return;
				}
				break;
				IL_010f:
				int num4;
				if (num2 < 0)
				{
					num = 1554055408;
					num4 = num;
				}
				else
				{
					num = 1554055413;
					num4 = num;
				}
				continue;
				IL_0068:
				int num5;
				if (keyboardMaps == null)
				{
					num = 1554055408;
					num5 = num;
				}
				else
				{
					num = 1554055409;
					num5 = num;
				}
			}
			goto IL_0023;
			IL_00a5:
			inputLayout = keyboardLayouts[index].Clone();
			inputLayout.id = GetNewKeyboardLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetKeyboardLayoutNames());
			if (index == keyboardLayouts.Count - 1)
			{
				keyboardLayouts.Add(inputLayout);
				num = 1554055422;
				goto IL_0028;
			}
			goto IL_0127;
		}

		public int GetKeyboardLayoutMapCount(int id)
		{
			if (keyboardLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (keyboardMaps != null)
			{
				int num2 = 0;
				while (true)
				{
					int num3 = 1959215329;
					while (true)
					{
						switch (num3 ^ 0x74C740E0)
						{
						case 0:
							break;
						case 3:
							goto IL_0040;
						case 4:
							if (keyboardMaps[num2].layoutId == id)
							{
								num++;
								num3 = 1959215330;
								continue;
							}
							goto case 2;
						case 2:
							num2++;
							num3 = 1959215331;
							continue;
						case 1:
							num3 = 1959215331;
							continue;
						default:
							goto end_IL_0016;
						}
						break;
						IL_0040:
						int num4;
						if (num2 < keyboardMaps.Count)
						{
							num3 = 1959215332;
							num4 = num3;
						}
						else
						{
							num3 = 1959215333;
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

		public int GetKeyboardLayoutIndex(int id)
		{
			if (keyboardLayouts == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 1110230873;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x422CC759)
				{
				case 3:
					break;
				case 1:
					return 0;
				case 2:
					if (keyboardLayouts[num].id != id)
					{
						goto IL_004b;
					}
					return num;
				default:
					if (num >= keyboardLayouts.Count)
					{
						return -1;
					}
					goto case 2;
				}
				break;
				IL_004b:
				num++;
				num2 = 1110230873;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1110230872;
			goto IL_000d;
		}

		public string[] GetKeyboardLayoutNames()
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			string[] array = new string[keyboardLayouts.Count];
			int num = 0;
			while (num < keyboardLayouts.Count)
			{
				while (true)
				{
					array[num] = keyboardLayouts[num].name;
					int num2 = -591018587;
					while (true)
					{
						switch (num2 ^ -591018586)
						{
						case 0:
							num2 = -591018588;
							continue;
						case 2:
							break;
						case 3:
							num++;
							num2 = -591018585;
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

		public int[] GetKeyboardLayoutIds()
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			int[] array = new int[keyboardLayouts.Count];
			int num = 0;
			while (num < keyboardLayouts.Count)
			{
				while (true)
				{
					array[num] = keyboardLayouts[num].id;
					int num2 = 1131753280;
					while (true)
					{
						switch (num2 ^ 0x43752F40)
						{
						case 3:
							num2 = 1131753281;
							continue;
						case 1:
							break;
						case 0:
							num++;
							num2 = 1131753282;
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
				goto IL_0008;
			}
			int num = IndexOfKeyboardLayout(name);
			int num2;
			if (num < 0)
			{
				num2 = -12914210;
				goto IL_000d;
			}
			return keyboardLayouts[num].id;
			IL_0008:
			num2 = -12914211;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ -12914212)
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

		public int IndexOfKeyboardLayout(int id)
		{
			if (keyboardLayouts == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < keyboardLayouts.Count)
				{
					num2 = -1828599353;
					num3 = num2;
				}
				else
				{
					num2 = -1828599358;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1828599354)
					{
					case 2:
						num2 = -1828599353;
						continue;
					case 1:
						if (keyboardLayouts[num].id == id)
						{
							num2 = -1828599354;
							continue;
						}
						num++;
						num2 = -1828599355;
						continue;
					case 0:
						return num;
					case 3:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public int IndexOfKeyboardLayout(string name)
		{
			int num;
			int num2 = default(int);
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (keyboardLayouts == null)
				{
					num = -468457075;
				}
				else
				{
					num2 = 0;
					num = -468457073;
				}
				goto IL_0015;
			}
			goto IL_003e;
			IL_0015:
			while (true)
			{
				switch (num ^ -468457077)
				{
				case 0:
					break;
				case 2:
					goto IL_003e;
				case 4:
					goto IL_004f;
				case 6:
					return -1;
				case 1:
					return num2;
				case 5:
					goto IL_0086;
				default:
					return -1;
				}
				break;
				IL_0086:
				if (!keyboardLayouts[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					num2++;
					num = -468457073;
				}
				else
				{
					num = -468457078;
				}
				continue;
				IL_004f:
				int num3;
				if (num2 < keyboardLayouts.Count)
				{
					num = -468457074;
					num3 = num;
				}
				else
				{
					num = -468457080;
					num3 = num;
				}
			}
			goto IL_0010;
			IL_0010:
			num = -468457079;
			goto IL_0015;
			IL_003e:
			return -1;
		}

		public string GetKeyboardLayoutNameById(int id)
		{
			if (keyboardLayouts != null)
			{
				int num = 0;
				while (true)
				{
					int num2 = 762328802;
					while (true)
					{
						switch (num2 ^ 0x2D7036E6)
						{
						case 3:
							break;
						case 0:
							goto IL_0030;
						case 1:
							goto IL_004f;
						case 4:
							num2 = 762328806;
							continue;
						default:
							goto end_IL_000a;
						}
						break;
						IL_004f:
						if (keyboardLayouts[num].id == id)
						{
							return keyboardLayouts[num].name;
						}
						num++;
						num2 = 762328806;
						continue;
						IL_0030:
						int num3;
						if (num >= keyboardLayouts.Count)
						{
							num2 = 762328804;
							num3 = num2;
						}
						else
						{
							num2 = 762328807;
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
			mouseLayouts.Add(asWTBfYbeGKFQPgxKcIlfswQTbMv());
		}

		public void InsertMouseLayout(int index)
		{
			if (index >= 0)
			{
				if (index < mouseLayouts.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (-1242823634 ^ -1242823633)
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
			mouseLayouts.Insert(index, asWTBfYbeGKFQPgxKcIlfswQTbMv());
		}

		public void DeleteMouseLayout(int index)
		{
			if (mouseLayouts == null || index < 0)
			{
				goto IL_00e9;
			}
			if (index >= mouseLayouts.Count)
			{
				goto IL_0023;
			}
			goto IL_0128;
			IL_00e9:
			throw new ArgumentOutOfRangeException("index");
			IL_0128:
			int id = mouseLayouts[index].id;
			int num = 1805118613;
			goto IL_0028;
			IL_0023:
			num = 1805118623;
			goto IL_0028;
			IL_0028:
			Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x6B97EC96)
				{
				case 4:
					break;
				case 0:
					num = 1805118621;
					continue;
				case 7:
					cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate66;
					num2 = 0;
					num = 1805118611;
					continue;
				case 11:
					goto IL_008a;
				case 13:
					if (mouseMaps[num3].layoutId == id)
					{
						mouseMaps.RemoveAt(num3);
						num = 1805118622;
						continue;
					}
					goto case 8;
				case 3:
					if (mouseMaps != null)
					{
						num3 = mouseMaps.Count - 1;
						num = 1805118614;
						continue;
					}
					goto IL_010c;
				case 9:
					goto IL_00e9;
				case 8:
					num3--;
					num = 1805118621;
					continue;
				case 2:
					goto IL_010c;
				case 10:
					goto IL_0128;
				case 6:
					num2++;
					num = 1805118611;
					continue;
				case 12:
				{
					Player_Editor player_Editor = players[num2];
					if (player_Editor != null)
					{
						cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultMouseMaps, id);
						num = 1805118608;
						continue;
					}
					goto case 6;
				}
				case 5:
					goto IL_017c;
				case 1:
					if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate66 == null)
					{
						CS_0024_003C_003E9__CachedAnonymousMethodDelegate66 = delegate(List<Player_Editor.Mapping> P_0, int P_1)
						{
							if (P_0 == null)
							{
								goto IL_0003;
							}
							goto IL_0070;
							IL_0003:
							int num7 = 418504073;
							goto IL_0008;
							IL_0008:
							int num8 = default(int);
							while (true)
							{
								switch (num7 ^ 0x18F1DD8D)
								{
								case 5:
									break;
								case 4:
									return;
								case 2:
									P_0.RemoveAt(num8);
									num7 = 418504075;
									continue;
								case 0:
									if (P_0[num8] == null)
									{
										goto case 2;
									}
									goto IL_0050;
								case 1:
									goto IL_0070;
								case 6:
									num8--;
									num7 = 418504078;
									continue;
								default:
									if (num8 < 0)
									{
										return;
									}
									goto case 0;
								}
								break;
								IL_0050:
								int num9;
								if (P_0[num8].layoutId != P_1)
								{
									num7 = 418504075;
									num9 = num7;
								}
								else
								{
									num7 = 418504079;
									num9 = num7;
								}
							}
							goto IL_0003;
							IL_0070:
							num8 = P_0.Count - 1;
							num7 = 418504078;
							goto IL_0008;
						};
						num = 1805118609;
						continue;
					}
					goto case 7;
				default:
					mouseLayouts.RemoveAt(index);
					return;
				}
				break;
				IL_017c:
				int num4;
				if (num2 >= players.Count)
				{
					num = 1805118616;
					num4 = num;
				}
				else
				{
					num = 1805118618;
					num4 = num;
				}
				continue;
				IL_010c:
				int num5;
				if (players == null)
				{
					num = 1805118616;
					num5 = num;
				}
				else
				{
					num = 1805118615;
					num5 = num;
				}
				continue;
				IL_008a:
				int num6;
				if (num3 < 0)
				{
					num = 1805118612;
					num6 = num;
				}
				else
				{
					num = 1805118619;
					num6 = num;
				}
			}
			goto IL_0023;
		}

		public bool ReorderMouseLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mouseLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateMouseLayout(int index, bool duplicateMaps)
		{
			if (mouseLayouts != null)
			{
				int num2 = default(int);
				int id = default(int);
				int num3 = default(int);
				int id2 = default(int);
				InputLayout inputLayout = default(InputLayout);
				while (true)
				{
					int num = -211662641;
					while (true)
					{
						switch (num ^ -211662642)
						{
						case 9:
							break;
						default:
							return;
						case 13:
							if (mouseMaps[num2].layoutId == id)
							{
								num3 = DuplicateMouseMap(num2);
								num = -211662646;
								continue;
							}
							goto case 11;
						case 12:
							goto IL_0084;
						case 2:
							if (duplicateMaps)
							{
								id2 = inputLayout.id;
								num = -211662656;
								continue;
							}
							return;
						case 11:
							num2--;
							num = -211662642;
							continue;
						case 3:
							goto end_IL_000b;
						case 1:
							goto IL_00e0;
						case 4:
							goto IL_00f8;
						case 14:
							id = mouseLayouts[index].id;
							num = -211662650;
							continue;
						case 6:
							mouseMaps[num3].layoutId = id2;
							num = -211662651;
							continue;
						case 5:
							num2 = mouseMaps.Count - 1;
							num = -211662642;
							continue;
						case 10:
							inputLayout = mouseLayouts[index].Clone();
							inputLayout.id = GetNewMouseLayoutId();
							inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetMouseLayoutNames());
							if (index == mouseLayouts.Count - 1)
							{
								mouseLayouts.Add(inputLayout);
								num = -211662644;
								continue;
							}
							goto case 7;
						case 7:
							mouseLayouts.Insert(index + 1, inputLayout);
							num = -211662644;
							continue;
						case 8:
							goto IL_01d7;
						case 0:
							goto IL_01f3;
						case 15:
							return;
						}
						break;
						IL_01f3:
						int num4;
						if (num2 >= 0)
						{
							num = -211662653;
							num4 = num;
						}
						else
						{
							num = -211662655;
							num4 = num;
						}
						continue;
						IL_0084:
						int num5;
						if (index < mouseLayouts.Count)
						{
							num = -211662652;
							num5 = num;
						}
						else
						{
							num = -211662643;
							num5 = num;
						}
						continue;
						IL_00f8:
						int num6;
						if (num3 < 0)
						{
							num = -211662651;
							num6 = num;
						}
						else
						{
							num = -211662648;
							num6 = num;
						}
						continue;
						IL_01d7:
						int num7;
						if (mouseMaps != null)
						{
							num = -211662645;
							num7 = num;
						}
						else
						{
							num = -211662655;
							num7 = num;
						}
						continue;
						IL_00e0:
						int num8;
						if (index < 0)
						{
							num = -211662643;
							num8 = num;
						}
						else
						{
							num = -211662654;
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

		public int GetMouseLayoutMapCount(int id)
		{
			if (mouseLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (mouseMaps != null)
			{
				int num2 = 0;
				while (true)
				{
					int num3;
					int num4;
					if (num2 >= mouseMaps.Count)
					{
						num3 = -1138905678;
						num4 = num3;
					}
					else
					{
						num3 = -1138905676;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ -1138905674)
						{
						case 0:
							num3 = -1138905676;
							continue;
						case 2:
							break;
						case 1:
							goto end_IL_0020;
						case 5:
							num2++;
							num3 = -1138905673;
							continue;
						case 3:
							num++;
							num3 = -1138905677;
							continue;
						default:
							goto end_IL_006a;
						}
						int num5;
						if (mouseMaps[num2].layoutId != id)
						{
							num3 = -1138905677;
							num5 = num3;
						}
						else
						{
							num3 = -1138905675;
							num5 = num3;
						}
						continue;
						end_IL_0020:
						break;
					}
					continue;
					end_IL_006a:
					break;
				}
			}
			return num;
		}

		public int GetMouseLayoutIndex(int id)
		{
			if (mouseLayouts == null)
			{
				return 0;
			}
			int num = 0;
			while (num < mouseLayouts.Count)
			{
				while (true)
				{
					int num2;
					if (mouseLayouts[num].id == id)
					{
						num2 = 1509109140;
					}
					else
					{
						num++;
						num2 = 1509109141;
					}
					while (true)
					{
						switch (num2 ^ 0x59F32D94)
						{
						case 2:
							num2 = 1509109143;
							continue;
						case 3:
							break;
						case 0:
							return num;
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

		public string[] GetMouseLayoutNames()
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			string[] array = new string[mouseLayouts.Count];
			int num = 0;
			while (num < mouseLayouts.Count)
			{
				while (true)
				{
					array[num] = mouseLayouts[num].name;
					num++;
					int num2 = -673764819;
					while (true)
					{
						switch (num2 ^ -673764817)
						{
						case 0:
							num2 = -673764818;
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

		public int[] GetMouseLayoutIds()
		{
			if (mouseLayouts == null)
			{
				goto IL_0008;
			}
			int[] array = new int[mouseLayouts.Count];
			int num = 0;
			int num2 = 1201995636;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x47A4FF76)
				{
				case 3:
					break;
				case 4:
					return null;
				case 0:
					array[num] = mouseLayouts[num].id;
					num++;
					num2 = 1201995639;
					continue;
				case 2:
					num2 = 1201995639;
					continue;
				default:
					if (num >= mouseLayouts.Count)
					{
						return array;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1201995634;
			goto IL_000d;
		}

		public InputLayout GetMouseLayout(int index)
		{
			if (mouseLayouts != null && index >= 0)
			{
				while (true)
				{
					int num = -1678954407;
					while (true)
					{
						switch (num ^ -1678954408)
						{
						case 2:
							break;
						case 1:
							goto IL_002a;
						default:
							goto end_IL_000c;
						}
						break;
						IL_002a:
						if (index >= mouseLayouts.Count)
						{
							num = -1678954408;
							continue;
						}
						return mouseLayouts[index];
					}
					continue;
					end_IL_000c:
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
			int num2 = 644833009;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x266F5EF0)
				{
				case 2:
					break;
				case 3:
					return -1;
				case 0:
					if (mouseLayouts[num].id != id)
					{
						goto IL_004b;
					}
					return num;
				default:
					if (num >= mouseLayouts.Count)
					{
						return -1;
					}
					goto case 0;
				}
				break;
				IL_004b:
				num++;
				num2 = 644833009;
			}
			goto IL_0008;
			IL_0008:
			num2 = 644833011;
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
					num = 1929251223;
				}
				else
				{
					num2 = 0;
					num = 1929251219;
				}
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num ^ 0x72FE0997)
				{
				case 2:
					break;
				case 3:
					goto IL_0036;
				case 1:
					goto IL_0047;
				case 0:
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
				num = 1929251219;
			}
			goto IL_0010;
			IL_0010:
			num = 1929251220;
			goto IL_0015;
			IL_0036:
			return -1;
		}

		public string GetMouseLayoutNameById(int id)
		{
			if (mouseLayouts != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = 980753259;
					while (true)
					{
						switch (num ^ 0x3A751B69)
						{
						case 4:
							break;
						case 2:
							num2 = 0;
							num = 980753260;
							continue;
						case 5:
							goto IL_003e;
						case 1:
							return mouseLayouts[num2].name;
						case 3:
							goto IL_007a;
						default:
							goto end_IL_000b;
						}
						break;
						IL_007a:
						if (mouseLayouts[num2].id != id)
						{
							num2++;
							num = 980753260;
						}
						else
						{
							num = 980753256;
						}
						continue;
						IL_003e:
						int num3;
						if (num2 < mouseLayouts.Count)
						{
							num = 980753258;
							num3 = num;
						}
						else
						{
							num = 980753257;
							num3 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			return "Unknown";
		}

		public void AddCustomControllerLayout()
		{
			customControllerLayouts.Add(tSURnYCtXucFOhJJItwlMfXhOTs());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index >= 0)
			{
				if (index < customControllerLayouts.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (0x35DAE701 ^ 0x35DAE700)
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
			customControllerLayouts.Insert(index, tSURnYCtXucFOhJJItwlMfXhOTs());
		}

		public void DeleteCustomControllerLayout(int index)
		{
			if (customControllerLayouts == null || index < 0)
			{
				goto IL_006e;
			}
			if (index >= customControllerLayouts.Count)
			{
				goto IL_001d;
			}
			goto IL_0139;
			IL_016b:
			int num;
			int num2;
			if (players != null)
			{
				num = -884668372;
				num2 = num;
			}
			else
			{
				num = -884668370;
				num2 = num;
			}
			goto IL_0022;
			IL_006e:
			throw new ArgumentOutOfRangeException("index");
			IL_001d:
			num = -884668369;
			goto IL_0022;
			IL_0022:
			int num4 = default(int);
			int id = default(int);
			int num3 = default(int);
			Action<List<Player_Editor.Mapping>, int> cS_0024_003C_003E9__CachedAnonymousMethodDelegate = default(Action<List<Player_Editor.Mapping>, int>);
			Player_Editor player_Editor = default(Player_Editor);
			while (true)
			{
				switch (num ^ -884668372)
				{
				case 8:
					break;
				case 3:
					goto IL_006e;
				case 4:
					num = -884668371;
					continue;
				case 1:
					goto IL_0087;
				case 5:
					goto IL_00a9;
				case 0:
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
								int num8 = P_0.Count - 1;
								int num9 = -1899038251;
								while (true)
								{
									switch (num9 ^ -1899038256)
									{
									case 2:
										num9 = -1899038255;
										continue;
									case 1:
										break;
									case 3:
										P_0.RemoveAt(num8);
										num9 = -1899038256;
										continue;
									case 4:
										if (P_0[num8] != null)
										{
											int num10;
											if (P_0[num8].layoutId != P_1)
											{
												num9 = -1899038256;
												num10 = num9;
											}
											else
											{
												num9 = -1899038253;
												num10 = num9;
											}
											continue;
										}
										goto case 3;
									case 0:
										num8--;
										num9 = -1899038251;
										continue;
									default:
										if (num8 < 0)
										{
											return;
										}
										goto case 4;
									}
									break;
								}
							}
						};
						num = -884668379;
						continue;
					}
					goto case 9;
				case 12:
					goto IL_00e6;
				case 6:
					if (customControllerMaps[num4].layoutId == id)
					{
						customControllerMaps.RemoveAt(num4);
						num = -884668378;
						continue;
					}
					goto case 10;
				case 13:
					goto IL_0139;
				case 11:
					goto IL_016b;
				case 7:
					num3++;
					num = -884668371;
					continue;
				case 14:
					cS_0024_003C_003E9__CachedAnonymousMethodDelegate(player_Editor.defaultCustomControllerMaps, id);
					num = -884668373;
					continue;
				case 9:
					cS_0024_003C_003E9__CachedAnonymousMethodDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate68;
					num3 = 0;
					num = -884668376;
					continue;
				case 10:
					num4--;
					num = -884668375;
					continue;
				default:
					customControllerLayouts.RemoveAt(index);
					return;
				}
				break;
				IL_00e6:
				player_Editor = players[num3];
				int num5;
				if (player_Editor == null)
				{
					num = -884668373;
					num5 = num;
				}
				else
				{
					num = -884668382;
					num5 = num;
				}
				continue;
				IL_00a9:
				int num6;
				if (num4 < 0)
				{
					num = -884668377;
					num6 = num;
				}
				else
				{
					num = -884668374;
					num6 = num;
				}
				continue;
				IL_0087:
				int num7;
				if (num3 < players.Count)
				{
					num = -884668384;
					num7 = num;
				}
				else
				{
					num = -884668370;
					num7 = num;
				}
			}
			goto IL_001d;
			IL_0139:
			id = customControllerLayouts[index].id;
			if (customControllerMaps != null)
			{
				num4 = customControllerMaps.Count - 1;
				num = -884668375;
				goto IL_0022;
			}
			goto IL_016b;
		}

		public bool ReorderCustomControllerLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllerLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateCustomControllerLayout(int index, bool duplicateMaps)
		{
			if (customControllerLayouts == null || index < 0)
			{
				goto IL_006a;
			}
			if (index >= customControllerLayouts.Count)
			{
				goto IL_001d;
			}
			goto IL_0131;
			IL_0131:
			InputLayout inputLayout = customControllerLayouts[index].Clone();
			inputLayout.id = GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetCustomControllerLayoutNames());
			int num;
			if (index == customControllerLayouts.Count - 1)
			{
				customControllerLayouts.Add(inputLayout);
				num = -655647148;
				goto IL_0022;
			}
			goto IL_0091;
			IL_0091:
			customControllerLayouts.Insert(index + 1, inputLayout);
			num = -655647152;
			goto IL_0022;
			IL_001d:
			num = -655647151;
			goto IL_0022;
			IL_0022:
			int num3 = default(int);
			int id2 = default(int);
			int num2 = default(int);
			int id = default(int);
			while (true)
			{
				switch (num ^ -655647150)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					goto IL_006a;
				case 9:
					goto IL_007c;
				case 5:
					goto IL_0091;
				case 7:
					customControllerMaps[num3].layoutId = id2;
					num = -655647144;
					continue;
				case 2:
					if (duplicateMaps)
					{
						id2 = inputLayout.id;
						num = -655647149;
						continue;
					}
					return;
				case 4:
					if (customControllerMaps != null)
					{
						num2 = customControllerMaps.Count - 1;
						num = -655647141;
						continue;
					}
					return;
				case 12:
					goto IL_0101;
				case 10:
					num2--;
					num = -655647141;
					continue;
				case 11:
					goto IL_0131;
				case 6:
					num = -655647152;
					continue;
				case 1:
					id = customControllerLayouts[index].id;
					num = -655647146;
					continue;
				case 8:
					goto IL_01b6;
				case 13:
					return;
				}
				break;
				IL_01b6:
				int num4;
				if (customControllerMaps[num2].layoutId == id)
				{
					num = -655647138;
					num4 = num;
				}
				else
				{
					num = -655647144;
					num4 = num;
				}
				continue;
				IL_0101:
				num3 = DuplicateCustomControllerMap(num2);
				int num5;
				if (num3 < 0)
				{
					num = -655647144;
					num5 = num;
				}
				else
				{
					num = -655647147;
					num5 = num;
				}
				continue;
				IL_007c:
				int num6;
				if (num2 < 0)
				{
					num = -655647137;
					num6 = num;
				}
				else
				{
					num = -655647142;
					num6 = num;
				}
			}
			goto IL_001d;
			IL_006a:
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetCustomControllerLayoutMapCount(int id)
		{
			if (customControllerLayouts == null)
			{
				return 0;
			}
			int num = 0;
			if (customControllerMaps != null)
			{
				int num2 = 0;
				while (true)
				{
					int num3 = 931502975;
					while (true)
					{
						switch (num3 ^ 0x37859B79)
						{
						case 0:
							break;
						case 6:
							num3 = 931502968;
							continue;
						case 1:
							goto IL_004e;
						case 3:
							goto IL_006d;
						case 2:
							num++;
							num3 = 931502973;
							continue;
						case 4:
							num2++;
							num3 = 931502968;
							continue;
						default:
							goto end_IL_0019;
						}
						break;
						IL_006d:
						int num4;
						if (customControllerMaps[num2].layoutId != id)
						{
							num3 = 931502973;
							num4 = num3;
						}
						else
						{
							num3 = 931502971;
							num4 = num3;
						}
						continue;
						IL_004e:
						int num5;
						if (num2 >= customControllerMaps.Count)
						{
							num3 = 931502972;
							num5 = num3;
						}
						else
						{
							num3 = 931502970;
							num5 = num3;
						}
					}
					continue;
					end_IL_0019:
					break;
				}
			}
			return num;
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
				if (num >= customControllerLayouts.Count)
				{
					num2 = 665010582;
					num3 = num2;
				}
				else
				{
					num2 = 665010580;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x27A34196)
					{
					case 3:
						num2 = 665010580;
						continue;
					case 2:
						if (customControllerLayouts[num].id == id)
						{
							return num;
						}
						num++;
						num2 = 665010583;
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

		public string[] GetCustomControllerLayoutNames()
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			string[] array = new string[customControllerLayouts.Count];
			int num = 0;
			while (num < customControllerLayouts.Count)
			{
				while (true)
				{
					array[num] = customControllerLayouts[num].name;
					int num2 = 319706860;
					while (true)
					{
						switch (num2 ^ 0x130E56ED)
						{
						case 0:
							num2 = 319706862;
							continue;
						case 3:
							break;
						case 1:
							num++;
							num2 = 319706863;
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

		public int[] GetCustomControllerLayoutIds()
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			int[] array = new int[customControllerLayouts.Count];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= customControllerLayouts.Count)
				{
					num2 = 1427562989;
					num3 = num2;
				}
				else
				{
					num2 = 1427562990;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x5516E1EC)
					{
					case 0:
						num2 = 1427562990;
						continue;
					case 2:
						array[num] = customControllerLayouts[num].id;
						num++;
						num2 = 1427562991;
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

		public InputLayout GetCustomControllerLayout(int index)
		{
			if (customControllerLayouts != null && index >= 0)
			{
				while (true)
				{
					int num = -2022309675;
					while (true)
					{
						switch (num ^ -2022309673)
						{
						case 0:
							break;
						case 2:
							goto IL_002a;
						default:
							goto end_IL_000c;
						}
						break;
						IL_002a:
						if (index >= customControllerLayouts.Count)
						{
							num = -2022309674;
							continue;
						}
						return customControllerLayouts[index];
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			return null;
		}

		public InputLayout GetCustomControllerLayout(string name)
		{
			if (customControllerLayouts == null)
			{
				goto IL_0008;
			}
			int num = IndexOfCustomControllerLayout(name);
			int num2 = -909207993;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ -909207995)
			{
			case 0:
				break;
			case 1:
				return null;
			default:
				if (num < 0)
				{
					return null;
				}
				return customControllerLayouts[num];
			}
			goto IL_0008;
			IL_0008:
			num2 = -909207996;
			goto IL_000d;
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
				goto IL_0008;
			}
			int num = 0;
			int num2 = -612967114;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -612967113)
				{
				case 0:
					break;
				case 4:
					return -1;
				case 1:
				{
					int num3;
					if (num >= customControllerLayouts.Count)
					{
						num2 = -612967115;
						num3 = num2;
					}
					else
					{
						num2 = -612967116;
						num3 = num2;
					}
					continue;
				}
				case 3:
					if (customControllerLayouts[num].id == id)
					{
						return num;
					}
					num++;
					num2 = -612967114;
					continue;
				default:
					return -1;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -612967117;
			goto IL_000d;
		}

		public int IndexOfCustomControllerLayout(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (customControllerLayouts == null)
				{
					return -1;
				}
				num = 0;
				num2 = 249968784;
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0xEE63890)
				{
				case 3:
					break;
				case 4:
					goto IL_0036;
				case 1:
					goto IL_004b;
				case 0:
					goto IL_0072;
				default:
					return -1;
				}
				break;
				IL_0072:
				int num3;
				if (num < customControllerLayouts.Count)
				{
					num2 = 249968785;
					num3 = num2;
				}
				else
				{
					num2 = 249968786;
					num3 = num2;
				}
				continue;
				IL_004b:
				if (customControllerLayouts[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = 249968784;
			}
			goto IL_0010;
			IL_0010:
			num2 = 249968788;
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
						num2 = -1941246254;
						num3 = num2;
					}
					else
					{
						num2 = -1941246249;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1941246253)
						{
						case 3:
							num2 = -1941246249;
							continue;
						case 2:
							break;
						case 0:
							return customControllerLayouts[num].name;
						case 4:
							goto IL_0071;
						default:
							goto end_IL_0035;
						}
						break;
						IL_0071:
						if (customControllerLayouts[num].id != id)
						{
							num++;
							num2 = -1941246255;
						}
						else
						{
							num2 = -1941246253;
						}
					}
					continue;
					end_IL_0035:
					break;
				}
			}
			return "Unknown";
		}

		public string GetLayoutNameById(ControllerType controllerType, int id)
		{
			while (true)
			{
				int num = 1073002525;
				while (true)
				{
					switch (num ^ 0x3FF4B81C)
					{
					case 3:
						break;
					case 1:
						switch (controllerType)
						{
						default:
							num = 1073002524;
							continue;
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return GetKeyboardLayoutNameById(id);
						case ControllerType.Mouse:
							return GetMouseLayoutNameById(id);
						}
						goto default;
					case 0:
						if (controllerType != ControllerType.Custom)
						{
							num = 1073002526;
							continue;
						}
						return GetCustomControllerLayoutNameById(id);
					default:
						return GetJoystickLayoutNameById(id);
					case 2:
						throw new NotImplementedException();
					}
					break;
				}
			}
		}

		internal ControllerMap EejRxaQkJjVzdXNnYOzIknaBWSF(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			ControllerType type = P_0.type;
			while (true)
			{
				switch (-1937444826 ^ -1937444825)
				{
				case 2:
					continue;
				case 1:
					switch (type)
					{
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						return FindKeyboardMap_Game(P_1, P_2);
					case ControllerType.Mouse:
						return FindMouseMap_Game(P_1, P_2);
					case ControllerType.Custom:
						return MehHSdzwFfroqrFNXLiGTsJRIwK(P_1, ((CustomController)P_0).sourceControllerId, P_2);
					default:
						throw new NotImplementedException();
					}
					break;
				}
				break;
			}
			return xSmZEdTrKmvKQhUCylMqvdplEmLK((Joystick)P_0, P_1, P_2);
		}

		public ControllerMap_Editor GetJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return null;
			}
			int num = 0;
			while (num < joystickMaps.Count)
			{
				while (true)
				{
					if (joystickMaps[num].categoryId == categoryId && joystickMaps[num].layoutId == layoutId && StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
					{
						return joystickMaps[num];
					}
					num++;
					int num2 = -1907653020;
					while (true)
					{
						switch (num2 ^ -1907653020)
						{
						case 2:
							num2 = -1907653019;
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
			return null;
		}

		public ControllerMap_Editor GetJoystickMapById(int id, out int joystickMapIndex)
		{
			joystickMapIndex = -1;
			int num2 = default(int);
			while (true)
			{
				int num = 1973276365;
				while (true)
				{
					switch (num ^ 0x759DCECC)
					{
					case 2:
						break;
					case 1:
						if (joystickMaps == null)
						{
							num = 1973276360;
							continue;
						}
						num2 = 0;
						num = 1973276361;
						continue;
					case 0:
						return joystickMaps[num2];
					case 3:
						if (joystickMaps[num2].id != id)
						{
							num2++;
							num = 1973276361;
						}
						else
						{
							joystickMapIndex = num2;
							num = 1973276364;
						}
						continue;
					case 4:
						return null;
					default:
						if (num2 >= joystickMaps.Count)
						{
							return null;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public List<ControllerMap_Editor> GetJoystickMaps(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				return null;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= joystickMaps.Count)
				{
					num2 = -2065274626;
					num3 = num2;
				}
				else
				{
					num2 = -2065274627;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -2065274628)
					{
					case 3:
						num2 = -2065274627;
						continue;
					case 1:
						if (StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
						{
							list.Add(joystickMaps[num]);
							num2 = -2065274632;
							continue;
						}
						goto case 4;
					case 0:
						break;
					case 4:
						num++;
						num2 = -2065274628;
						continue;
					default:
						return list;
					}
					break;
				}
			}
		}

		public int GetJoystickMapId(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < joystickMaps.Count)
				{
					num2 = 1456919243;
					num3 = num2;
				}
				else
				{
					num2 = 1456919242;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x56D6D2CA)
					{
					case 2:
						num2 = 1456919243;
						continue;
					case 1:
						if (joystickMaps[num].categoryId == categoryId && joystickMaps[num].layoutId == layoutId && StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
						{
							return joystickMaps[num].id;
						}
						num++;
						num2 = 1456919241;
						continue;
					case 3:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public bool HasJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
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
					int num2;
					if (joystickMaps[num].categoryId == categoryId && joystickMaps[num].layoutId == layoutId)
					{
						num2 = 492687796;
						goto IL_0016;
					}
					goto IL_008d;
					IL_008d:
					num++;
					num2 = 492687799;
					goto IL_0016;
					IL_0016:
					while (true)
					{
						switch (num2 ^ 0x1D5DD1B6)
						{
						case 0:
							num2 = 492687797;
							continue;
						case 3:
							break;
						case 2:
							goto IL_0066;
						case 4:
							return true;
						default:
							goto end_IL_0037;
						}
						break;
						IL_0066:
						if (StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
						{
							num2 = 492687794;
							continue;
						}
						goto IL_008d;
					}
					continue;
					end_IL_0037:
					break;
				}
			}
			return false;
		}

		public bool HasJoystickMap(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1175312060;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1175312064)
				{
				case 0:
					break;
				case 2:
					if (StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
					{
						return true;
					}
					num++;
					num2 = -1175312063;
					continue;
				case 4:
					num2 = -1175312063;
					continue;
				case 3:
					return false;
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
			num2 = -1175312061;
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
					int num2;
					if (StringTools.ToGuid(joystickMaps[num].hardwareGuidString) == hardwareGuid)
					{
						num2 = -27562949;
						goto IL_0013;
					}
					goto IL_0076;
					IL_0013:
					while (true)
					{
						switch (num2 ^ -27562949)
						{
						case 2:
							num2 = -27562950;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0059;
						case 4:
							return true;
						default:
							goto end_IL_0034;
						}
						break;
						IL_0059:
						if (joystickMaps[num].categoryId == categoryId)
						{
							num2 = -27562945;
							continue;
						}
						goto IL_0076;
					}
					continue;
					IL_0076:
					num++;
					num2 = -27562952;
					goto IL_0013;
					continue;
					end_IL_0034:
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
			goto IL_0031;
			IL_0031:
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			int num = -1546793872;
			goto IL_0018;
			IL_0013:
			num = -1546793871;
			goto IL_0018;
			IL_0018:
			switch (num ^ -1546793872)
			{
			case 2:
				break;
			case 1:
				goto IL_0031;
			default:
				controllerMap_Editor.id = GetNewJoystickMapId();
				controllerMap_Editor.categoryId = categoryId;
				controllerMap_Editor.layoutId = layoutId;
				controllerMap_Editor.hardwareGuidString = joystickOrTemplateGuid.ToString();
				joystickMaps.Add(controllerMap_Editor);
				return false;
			}
			goto IL_0013;
		}

		public void DeleteJoystickMap(int id)
		{
			if (joystickMaps == null)
			{
				return;
			}
			while (true)
			{
				int num = joystickMaps.Count - 1;
				int num2 = 717532851;
				while (true)
				{
					switch (num2 ^ 0x2AC4AEB0)
					{
					case 2:
						num2 = 717532849;
						continue;
					case 1:
						break;
					case 4:
						num--;
						num2 = 717532851;
						continue;
					case 0:
						if (joystickMaps[num].id == id)
						{
							joystickMaps.RemoveAt(num);
							num2 = 717532852;
							continue;
						}
						goto case 4;
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

		public int DuplicateJoystickMap(int index)
		{
			if (joystickMaps != null && index >= 0)
			{
				if (index < joystickMaps.Count)
				{
					goto IL_004a;
				}
				while (true)
				{
					switch (-2094120140 ^ -2094120139)
					{
					case 2:
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
			ControllerMap_Editor controllerMap_Editor = joystickMaps[index].Clone();
			controllerMap_Editor.id = GetNewJoystickMapId();
			joystickMaps.Add(controllerMap_Editor);
			return joystickMaps.Count - 1;
		}

		internal JoystickMap ABAQieQmqspSHIkOXPSuKpjQbCg(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return xSmZEdTrKmvKQhUCylMqvdplEmLK(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap xSmZEdTrKmvKQhUCylMqvdplEmLK(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return xSmZEdTrKmvKQhUCylMqvdplEmLK(P_0.hardwareJoystickMapIdentifier, P_1, P_2);
		}

		private JoystickMap xSmZEdTrKmvKQhUCylMqvdplEmLK(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = default(HardwareJoystickMap);
			JoystickMap joystickMap = default(JoystickMap);
			JoystickMap result = default(JoystickMap);
			bool flag = default(bool);
			ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
			while (true)
			{
				int num = -1640768439;
				while (true)
				{
					int num6;
					int num7;
					switch (num ^ -1640768440)
					{
					case 0:
						break;
					case 1:
						hardwareJoystickMap = ReInput.KMGdcXDLnbZuPYvzFIqeDgBsQnv(guid);
						controllerMap_Editor = dqKPHkffJNGGsHuAoxrmsoxwQvSP(P_1, guid, P_2, false);
						if (controllerMap_Editor != null)
						{
							joystickMap = controllerMap_Editor.TyUTxlDNKLwRFZInoPVPjtZOZoL(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
							joystickMap.SetIdentity(guid, P_1, P_2);
							return joystickMap;
						}
						if (hardwareJoystickMap != null)
						{
							goto IL_0071;
						}
						goto IL_017d;
					default:
						{
							using (IEnumerator<Guid> enumerator = hardwareJoystickMap.TemplateGuids.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										Guid current = enumerator.Current;
										if (current == Guid.Empty)
										{
											break;
										}
										HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.GQIAEUrSKudAJFshKLEiDynhHAON(current);
										int num2;
										int num3;
										if (!(hardwareJoystickTemplateMap != null))
										{
											num2 = -1640768439;
											num3 = num2;
										}
										else
										{
											num2 = -1640768440;
											num3 = num2;
										}
										while (true)
										{
											switch (num2 ^ -1640768440)
											{
											case 3:
												num2 = -1640768434;
												continue;
											case 6:
												break;
											case 2:
												goto IL_0105;
											case 0:
												goto IL_012a;
											case 5:
												joystickMap.SetIdentity(guid, P_1, P_2);
												result = joystickMap;
												num2 = -1640768436;
												continue;
											default:
												goto end_IL_00bb;
											case 4:
												return result;
											}
											break;
											IL_012a:
											controllerMap_Editor = dqKPHkffJNGGsHuAoxrmsoxwQvSP(P_1, current, P_2, false);
											int num4;
											if (controllerMap_Editor == null)
											{
												num2 = -1640768439;
												num4 = num2;
											}
											else
											{
												num2 = -1640768438;
												num4 = num2;
											}
											continue;
											IL_0105:
											joystickMap = nBQvQxqpITmHJPVLHnwMLlIeBUp(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
											int num5;
											if (joystickMap == null)
											{
												num2 = -1640768439;
												num5 = num2;
											}
											else
											{
												num2 = -1640768435;
												num5 = num2;
											}
										}
										continue;
										end_IL_00bb:
										break;
									}
								}
							}
							goto IL_017d;
						}
						IL_018f:
						while (true)
						{
							switch (num6 ^ -1640768440)
							{
							case 3:
								break;
							case 1:
								goto IL_01b0;
							case 2:
								goto IL_01bd;
							case 4:
								goto IL_0201;
							default:
								return joystickMap;
							}
							break;
							IL_0201:
							if (!flag)
							{
								num6 = -1640768438;
								continue;
							}
							goto IL_020e;
							IL_020e:
							return JoystickMap.Blank(guid, P_1, P_2);
							IL_01bd:
							controllerMap_Editor = dqKPHkffJNGGsHuAoxrmsoxwQvSP(P_1, Guid.Empty, P_2, false);
							if (controllerMap_Editor != null)
							{
								joystickMap = controllerMap_Editor.TyUTxlDNKLwRFZInoPVPjtZOZoL(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
								joystickMap.SetIdentity(guid, P_1, P_2);
								if (joystickMap != null)
								{
									num6 = -1640768440;
									continue;
								}
							}
							goto IL_020e;
						}
						goto IL_018a;
						IL_01b0:
						num7 = 1;
						goto IL_01b4;
						IL_017d:
						if (!(guid == Guid.Empty))
						{
							goto IL_018a;
						}
						num7 = 0;
						goto IL_01b4;
						IL_018a:
						num6 = -1640768439;
						goto IL_018f;
						IL_01b4:
						flag = (byte)num7 != 0;
						num6 = -1640768436;
						goto IL_018f;
					}
					break;
					IL_0071:
					num = -1640768438;
				}
			}
		}

		private ControllerMap_Editor dqKPHkffJNGGsHuAoxrmsoxwQvSP(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			while (true)
			{
				int num = -1036513081;
				while (true)
				{
					switch (num ^ -1036513082)
					{
					case 0:
						break;
					case 1:
						if (joystickMap != null)
						{
							goto IL_002b;
						}
						if (P_3)
						{
							joystickMap = edqGOyPIbqxPjWduCebehfVtzRM(P_0, P_1, P_2);
							if (joystickMap != null)
							{
								return joystickMap;
							}
						}
						return null;
					default:
						return joystickMap;
					}
					break;
					IL_002b:
					num = -1036513084;
				}
			}
		}

		private ControllerMap_Editor edqGOyPIbqxPjWduCebehfVtzRM(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				kNCefiYXbcQmvFFPCzwqqkLJPnA(list, joystickLayouts);
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = -638969953;
					while (true)
					{
						switch (num ^ -638969955)
						{
						case 4:
							break;
						case 3:
							goto IL_005c;
						case 5:
							if (num2 >= list.Count)
							{
								num3 = 0;
								num = -638969958;
								continue;
							}
							goto IL_00bf;
						case 1:
							goto IL_008f;
						case 7:
							num = -638969956;
							continue;
						case 2:
							num2 = 0;
							num = -638969960;
							continue;
						case 6:
							goto IL_00bf;
						default:
							goto end_IL_0027;
						}
						break;
						IL_008f:
						int num4;
						if (num3 >= list.Count)
						{
							num = -638969955;
							num4 = num;
						}
						else
						{
							num = -638969954;
							num4 = num;
						}
						continue;
						IL_00bf:
						if (list[num2].categoryId == P_0)
						{
							return list[num2];
						}
						num2++;
						num = -638969960;
						continue;
						IL_005c:
						if (list[num3].categoryId == 0)
						{
							return list[num3];
						}
						num3++;
						num = -638969956;
					}
					continue;
					end_IL_0027:
					break;
				}
			}
			return null;
		}

		private JoystickMap nBQvQxqpITmHJPVLHnwMLlIeBUp(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			object[] array = default(object[]);
			string text = default(string);
			while (true)
			{
				int num = 1603848067;
				while (true)
				{
					switch (num ^ 0x5F98C782)
					{
					case 3:
						break;
					case 4:
						array[4] = "\nReason: ";
						array[5] = text;
						num = 1603848064;
						continue;
					case 0:
						array[2] = " to joystick ";
						array[3] = P_0.guid;
						num = 1603848070;
						continue;
					case 2:
						Logger.LogError(string.Concat(array));
						num = 1603848071;
						continue;
					case 1:
						if (!P_2.gXYtfQHDORUhFLHiQPsElDGjDcyi(controllerMap_Editor, P_3, P_0.guid, out text))
						{
							array = new object[6] { "Error remapping joystick template ", P_2.Guid, null, null, null, null };
							num = 1603848066;
							continue;
						}
						return controllerMap_Editor.TyUTxlDNKLwRFZInoPVPjtZOZoL(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					default:
						return null;
					}
					break;
				}
			}
		}

		private JoystickMap MDhkNhVlDNoalrEOYFkTguraTuN(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.KMGdcXDLnbZuPYvzFIqeDgBsQnv(P_0.hardwareGuid);
			HardwareJoystickMap hardwareJoystickMap2 = default(HardwareJoystickMap);
			int[] buttons = default(int[]);
			int[] axes = default(int[]);
			int num3 = default(int);
			string text = default(string);
			int result = default(int);
			int num4 = default(int);
			string name = default(string);
			while (true)
			{
				int num = -170755336;
				while (true)
				{
					switch (num ^ -170755335)
					{
					case 0:
						break;
					case 1:
						if (hardwareJoystickMap == null)
						{
							return null;
						}
						hardwareJoystickMap2 = ReInput.KMGdcXDLnbZuPYvzFIqeDgBsQnv(Guid.Empty);
						if (hardwareJoystickMap2 == null)
						{
							num = -170755334;
							continue;
						}
						hardwareJoystickMap.GetElementIdentifiersForControllerElements(P_1, false, out buttons, out axes);
						num = -170755333;
						continue;
					case 3:
						return null;
					default:
					{
						if (buttons == null && axes == null)
						{
							return null;
						}
						bool flag = false;
						List<int> list = new List<int>();
						using (IEnumerator<ActionElementMap> enumerator = P_0.AllMaps.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								while (true)
								{
									ActionElementMap current = enumerator.Current;
									int num2 = -170755343;
									while (true)
									{
										switch (num2 ^ -170755335)
										{
										case 0:
											num2 = -170755340;
											continue;
										case 9:
											if (num3 == 1)
											{
												goto IL_00e7;
											}
											goto case 4;
										case 11:
											num2 = -170755334;
											continue;
										case 3:
											flag = true;
											num2 = -170755329;
											continue;
										case 10:
											Logger.Log(text);
											if (int.TryParse(text, out result))
											{
												if (num3 != 0)
												{
													goto case 5;
												}
												if (result < buttons.Length)
												{
													current._elementIdentifierId = buttons[result];
													num2 = -170755342;
													continue;
												}
											}
											goto case 1;
										case 13:
											break;
										case 12:
											if (num4 >= 0)
											{
												if (num3 != 0)
												{
													goto case 9;
												}
												goto IL_0169;
											}
											goto case 1;
										case 2:
											if (num4 < 0)
											{
												num4 = name.IndexOf("axis", 0, StringComparison.OrdinalIgnoreCase);
												num3 = 1;
												num2 = -170755339;
												continue;
											}
											goto case 12;
										case 8:
										{
											ControllerElementIdentifier elementIdentifier = hardwareJoystickMap2.GetElementIdentifier(current._elementIdentifierId);
											if (elementIdentifier != null)
											{
												name = elementIdentifier.name;
												num2 = -170755330;
												continue;
											}
											goto case 1;
										}
										case 7:
											if (!string.IsNullOrEmpty(name))
											{
												num3 = 0;
												num4 = name.IndexOf("button", 0, StringComparison.OrdinalIgnoreCase);
												num2 = -170755333;
												continue;
											}
											goto case 1;
										case 1:
											list.Add(current.rOuBUzbbciWwktcpmiPWpQIKoaAa);
											num2 = -170755329;
											continue;
										case 5:
											if (result < axes.Length)
											{
												current._elementIdentifierId = axes[result];
												num2 = -170755334;
												continue;
											}
											goto case 1;
										case 4:
											text = Regex.Replace(name, "[^0-9]+", "");
											num2 = -170755341;
											continue;
										default:
											goto end_IL_0147;
										}
										break;
										IL_0169:
										int num5;
										if (buttons == null)
										{
											num2 = -170755336;
											num5 = num2;
										}
										else
										{
											num2 = -170755344;
											num5 = num2;
										}
										continue;
										IL_00e7:
										int num6;
										if (axes == null)
										{
											num2 = -170755336;
											num6 = num2;
										}
										else
										{
											num2 = -170755331;
											num6 = num2;
										}
									}
									continue;
									end_IL_0147:
									break;
								}
							}
						}
						int num7 = 0;
						while (num7 < list.Count)
						{
							while (true)
							{
								P_0.DeleteElementMap(list[num7]);
								num7++;
								int num8 = -170755333;
								while (true)
								{
									switch (num8 ^ -170755335)
									{
									case 0:
										num8 = -170755336;
										continue;
									case 1:
										break;
									default:
										goto end_IL_027c;
									}
									break;
								}
								continue;
								end_IL_027c:
								break;
							}
						}
						if (!flag)
						{
							return null;
						}
						return P_0;
					}
					}
					break;
				}
			}
		}

		public ControllerMap_Editor GetKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2 = 371188233;
				while (true)
				{
					switch (num2 ^ 0x161FE20B)
					{
					case 3:
						break;
					case 2:
						num2 = 371188235;
						continue;
					case 1:
						if (keyboardMaps[num].categoryId == categoryId && keyboardMaps[num].layoutId == layoutId)
						{
							return keyboardMaps[num];
						}
						num++;
						num2 = 371188235;
						continue;
					default:
						if (num >= keyboardMaps.Count)
						{
							return null;
						}
						goto case 1;
					}
					break;
				}
			}
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
					if (keyboardMaps[num].categoryId == categoryId)
					{
						num2 = -852266668;
						goto IL_0013;
					}
					goto IL_0071;
					IL_004b:
					if (keyboardMaps[num].layoutId == layoutId)
					{
						return keyboardMaps[num].id;
					}
					goto IL_0071;
					IL_0071:
					num++;
					num2 = -852266666;
					goto IL_0013;
					IL_0013:
					while (true)
					{
						switch (num2 ^ -852266667)
						{
						case 0:
							num2 = -852266665;
							continue;
						case 2:
							break;
						case 1:
							goto IL_004b;
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
				goto IL_0008;
			}
			int num = 0;
			int num2 = 704726538;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x2A01460A)
				{
				case 2:
					break;
				case 0:
				{
					int num3;
					if (num >= keyboardMaps.Count)
					{
						num2 = 704726543;
						num3 = num2;
					}
					else
					{
						num2 = 704726542;
						num3 = num2;
					}
					continue;
				}
				case 4:
					if (keyboardMaps[num].categoryId == categoryId && keyboardMaps[num].layoutId == layoutId)
					{
						num2 = 704726537;
						continue;
					}
					goto IL_00b1;
				case 1:
					return false;
				case 3:
					if (StringTools.ToGuid(keyboardMaps[num].hardwareGuidString) == hardwareGuid)
					{
						return true;
					}
					goto IL_00b1;
				default:
					{
						return false;
					}
					IL_00b1:
					num++;
					num2 = 704726538;
					continue;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 704726539;
			goto IL_000d;
		}

		public bool CreateKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				goto IL_0008;
			}
			goto IL_0044;
			IL_0008:
			int num = -1790944867;
			goto IL_000d;
			IL_000d:
			ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
			while (true)
			{
				switch (num ^ -1790944865)
				{
				case 0:
					break;
				case 2:
					keyboardMaps = new List<ControllerMap_Editor>();
					num = -1790944869;
					continue;
				case 4:
					goto IL_0044;
				case 1:
					controllerMap_Editor.id = GetNewKeyboardMapId();
					num = -1790944868;
					continue;
				case 3:
					controllerMap_Editor.categoryId = categoryId;
					controllerMap_Editor.layoutId = layoutId;
					num = -1790944870;
					continue;
				default:
					keyboardMaps.Add(controllerMap_Editor);
					return false;
				}
				break;
			}
			goto IL_0008;
			IL_0044:
			controllerMap_Editor = new ControllerMap_Editor();
			num = -1790944866;
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
				int num2 = -1017971405;
				while (true)
				{
					switch (num2 ^ -1017971407)
					{
					case 4:
						num2 = -1017971408;
						continue;
					case 5:
						keyboardMaps.RemoveAt(num);
						num2 = -1017971407;
						continue;
					case 3:
					{
						int num3;
						if (keyboardMaps[num].id == id)
						{
							num2 = -1017971404;
							num3 = num2;
						}
						else
						{
							num2 = -1017971407;
							num3 = num2;
						}
						continue;
					}
					case 0:
						num--;
						num2 = -1017971405;
						continue;
					case 1:
						break;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 3;
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
					switch (-1839595131 ^ -1839595132)
					{
					case 2:
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
			if (keyboardMaps == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= keyboardMaps.Count)
				{
					num2 = -502544165;
					num3 = num2;
				}
				else
				{
					num2 = -502544167;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -502544166)
					{
					case 0:
						num2 = -502544167;
						continue;
					case 3:
						if (keyboardMaps[num].id == id)
						{
							keyboardMapIndex = num;
							return keyboardMaps[num];
						}
						num++;
						num2 = -502544168;
						continue;
					case 2:
						break;
					default:
						return null;
					}
					break;
				}
			}
		}

		public KeyboardMap FindKeyboardMap_Game(int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = EthSUjOfCEJjDeZuqNYxywxsaTS(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.SdulnsJvJXcicAJaRRIxFADCpHO(containsActionDelegate);
				goto IL_0026;
			}
			goto IL_0057;
			IL_0057:
			keyboardMap = KeyboardMap.Blank(categoryId, layoutId);
			int num = -141560407;
			goto IL_002b;
			IL_0026:
			num = -141560405;
			goto IL_002b;
			IL_002b:
			while (true)
			{
				switch (num ^ -141560406)
				{
				case 2:
					break;
				case 1:
					keyboardMap.SetIdentity(categoryId, layoutId);
					num = -141560407;
					continue;
				case 0:
					goto IL_0057;
				default:
					return keyboardMap;
				}
				break;
			}
			goto IL_0026;
		}

		public bool HasKeyboardMapInCategory(int categoryId)
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
					if (keyboardMaps[num].categoryId == categoryId)
					{
						return true;
					}
					num++;
					int num2 = -985306212;
					while (true)
					{
						switch (num2 ^ -985306212)
						{
						case 2:
							num2 = -985306211;
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

		public bool HasKeyboardMapInLayout(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = 2055361293;
				while (true)
				{
					switch (num2 ^ 0x7A82530B)
					{
					case 4:
						break;
					case 6:
						num2 = 2055361288;
						continue;
					case 2:
						if (keyboardMaps[num].categoryId == categoryId)
						{
							num2 = 2055361290;
							continue;
						}
						goto IL_005e;
					case 0:
						return true;
					case 3:
					{
						int num3;
						if (num >= keyboardMaps.Count)
						{
							num2 = 2055361294;
							num3 = num2;
						}
						else
						{
							num2 = 2055361289;
							num3 = num2;
						}
						continue;
					}
					case 1:
						if (keyboardMaps[num].layoutId == layoutId)
						{
							num2 = 2055361291;
							continue;
						}
						goto IL_005e;
					default:
						{
							return false;
						}
						IL_005e:
						num++;
						num2 = 2055361288;
						continue;
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
					if (mouseMaps[num].categoryId == categoryId && mouseMaps[num].layoutId == layoutId)
					{
						return mouseMaps[num];
					}
					num++;
					int num2 = -470389684;
					while (true)
					{
						switch (num2 ^ -470389682)
						{
						case 0:
							num2 = -470389681;
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
			return null;
		}

		public int GetMouseMapId(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < mouseMaps.Count)
				{
					num2 = -1084156554;
					num3 = num2;
				}
				else
				{
					num2 = -1084156555;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1084156556)
					{
					case 3:
						num2 = -1084156554;
						continue;
					case 0:
						break;
					case 4:
						if (mouseMaps[num].layoutId == layoutId)
						{
							return mouseMaps[num].id;
						}
						goto IL_0079;
					case 2:
						if (mouseMaps[num].categoryId == categoryId)
						{
							num2 = -1084156560;
							continue;
						}
						goto IL_0079;
					default:
						{
							return -1;
						}
						IL_0079:
						num++;
						num2 = -1084156556;
						continue;
					}
					break;
				}
			}
		}

		public bool HasMouseMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < mouseMaps.Count)
				{
					num2 = -1292841736;
					num3 = num2;
				}
				else
				{
					num2 = -1292841733;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1292841734)
					{
					case 0:
						num2 = -1292841736;
						continue;
					case 2:
						if (mouseMaps[num].categoryId == categoryId)
						{
							num2 = -1292841735;
							continue;
						}
						goto IL_0081;
					case 5:
						if (StringTools.ToGuid(mouseMaps[num].hardwareGuidString) == hardwareGuid)
						{
							num2 = -1292841732;
							continue;
						}
						goto IL_0081;
					case 6:
						return true;
					case 4:
						break;
					case 3:
						if (mouseMaps[num].layoutId == layoutId)
						{
							num2 = -1292841729;
							continue;
						}
						goto IL_0081;
					default:
						{
							return false;
						}
						IL_0081:
						num++;
						num2 = -1292841730;
						continue;
					}
					break;
				}
			}
		}

		public bool CreateMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				mouseMaps = new List<ControllerMap_Editor>();
				goto IL_0013;
			}
			goto IL_0035;
			IL_0035:
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewMouseMapId();
			controllerMap_Editor.categoryId = categoryId;
			int num = -2028194543;
			goto IL_0018;
			IL_0013:
			num = -2028194541;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ -2028194542)
				{
				case 0:
					break;
				case 1:
					goto IL_0035;
				case 3:
					controllerMap_Editor.layoutId = layoutId;
					mouseMaps.Add(controllerMap_Editor);
					num = -2028194544;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_0013;
		}

		public void DeleteMouseMap(int id)
		{
			if (mouseMaps == null)
			{
				return;
			}
			while (true)
			{
				int num = mouseMaps.Count - 1;
				int num2 = 1810156557;
				while (true)
				{
					switch (num2 ^ 0x6BE4CC0E)
					{
					case 2:
						num2 = 1810156554;
						continue;
					case 4:
						break;
					case 1:
						num--;
						num2 = 1810156557;
						continue;
					case 0:
						if (mouseMaps[num].id == id)
						{
							mouseMaps.RemoveAt(num);
							num2 = 1810156559;
							continue;
						}
						goto case 1;
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

		public int DuplicateMouseMap(int index)
		{
			if (mouseMaps == null || index < 0)
			{
				goto IL_003c;
			}
			if (index >= mouseMaps.Count)
			{
				goto IL_001a;
			}
			goto IL_004e;
			IL_004e:
			ControllerMap_Editor controllerMap_Editor = mouseMaps[index].Clone();
			controllerMap_Editor.id = GetNewMouseMapId();
			int num = 289088940;
			goto IL_001f;
			IL_003c:
			throw new ArgumentOutOfRangeException("index");
			IL_001a:
			num = 289088942;
			goto IL_001f;
			IL_001f:
			switch (num ^ 0x113B25AD)
			{
			case 0:
				break;
			case 3:
				goto IL_003c;
			case 2:
				goto IL_004e;
			default:
				mouseMaps.Add(controllerMap_Editor);
				return mouseMaps.Count - 1;
			}
			goto IL_001a;
		}

		public ControllerMap_Editor GetMouseMapById(int id, out int mouseMapIndex)
		{
			mouseMapIndex = -1;
			if (mouseMaps == null)
			{
				goto IL_000b;
			}
			int num = 0;
			int num2 = 540741358;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num2 ^ 0x203B0EEE)
				{
				case 3:
					break;
				case 1:
					return null;
				case 2:
					if (mouseMaps[num].id != id)
					{
						goto IL_005c;
					}
					mouseMapIndex = num;
					return mouseMaps[num];
				default:
					if (num >= mouseMaps.Count)
					{
						return null;
					}
					goto case 2;
				}
				break;
				IL_005c:
				num++;
				num2 = 540741358;
			}
			goto IL_000b;
			IL_000b:
			num2 = 540741359;
			goto IL_0010;
		}

		public MouseMap FindMouseMap_Game(int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = EthSUjOfCEJjDeZuqNYxywxsaTS(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.ZuyHHsYuJPhMvykrNfAaAsRJVhK(containsActionDelegate);
				goto IL_0026;
			}
			goto IL_004c;
			IL_004c:
			mouseMap = MouseMap.Blank(categoryId, layoutId);
			int num = 498309442;
			goto IL_002b;
			IL_0026:
			num = 498309447;
			goto IL_002b;
			IL_002b:
			while (true)
			{
				switch (num ^ 0x1DB39946)
				{
				case 3:
					break;
				case 0:
					goto IL_004c;
				case 2:
					num = 498309442;
					continue;
				case 1:
					mouseMap.SetIdentity(categoryId, layoutId);
					num = 498309444;
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
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= mouseMaps.Count)
				{
					num2 = -2047447434;
					num3 = num2;
				}
				else
				{
					num2 = -2047447433;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -2047447434)
					{
					case 3:
						num2 = -2047447433;
						continue;
					case 1:
						if (mouseMaps[num].categoryId == categoryId)
						{
							return true;
						}
						num++;
						num2 = -2047447436;
						continue;
					case 2:
						break;
					default:
						return false;
					}
					break;
				}
			}
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
					int num2;
					if (mouseMaps[num].categoryId == categoryId && mouseMaps[num].layoutId == layoutId)
					{
						num2 = -584495182;
					}
					else
					{
						num++;
						num2 = -584495183;
					}
					while (true)
					{
						switch (num2 ^ -584495183)
						{
						case 2:
							num2 = -584495184;
							continue;
						case 1:
							break;
						case 3:
							return true;
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
			return false;
		}

		public ControllerMap_Editor GetCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				return null;
			}
			int num = 0;
			while (num < customControllerMaps.Count)
			{
				while (true)
				{
					int num2;
					if (customControllerMaps[num].categoryId == categoryId)
					{
						num2 = -104226875;
						goto IL_0016;
					}
					goto IL_005f;
					IL_0016:
					while (true)
					{
						switch (num2 ^ -104226873)
						{
						case 0:
							num2 = -104226876;
							continue;
						case 3:
							break;
						case 1:
							return customControllerMaps[num];
						case 2:
							goto IL_006a;
						default:
							goto end_IL_0037;
						}
						break;
						IL_006a:
						if (customControllerMaps[num].layoutId == layoutId && customControllerMaps[num].customControllerUid == controllerUid)
						{
							num2 = -104226874;
							continue;
						}
						goto IL_005f;
					}
					continue;
					IL_005f:
					num++;
					num2 = -104226877;
					goto IL_0016;
					continue;
					end_IL_0037:
					break;
				}
			}
			return null;
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
				int num2 = 368032239;
				while (true)
				{
					switch (num2 ^ 0x15EFB9EE)
					{
					case 2:
						break;
					case 1:
						num2 = 368032237;
						continue;
					case 0:
						if (customControllerMaps[num].id == mapId)
						{
							customControllerMapIndex = num;
							return customControllerMaps[num];
						}
						num++;
						num2 = 368032237;
						continue;
					default:
						if (num >= customControllerMaps.Count)
						{
							return null;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public List<ControllerMap_Editor> GetCustomControllerMaps(int controllerUid)
		{
			if (customControllerMaps == null)
			{
				goto IL_0008;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			int num = 0;
			int num2 = -1797717589;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1797717592)
				{
				case 0:
					break;
				case 1:
				{
					int num3;
					if (num < customControllerMaps.Count)
					{
						num2 = -1797717590;
						num3 = num2;
					}
					else
					{
						num2 = -1797717587;
						num3 = num2;
					}
					continue;
				}
				case 3:
					num2 = -1797717591;
					continue;
				case 6:
					return null;
				case 4:
					num++;
					num2 = -1797717591;
					continue;
				case 2:
					if (customControllerMaps[num].customControllerUid == controllerUid)
					{
						list.Add(customControllerMaps[num]);
						num2 = -1797717588;
						continue;
					}
					goto case 4;
				default:
					return list;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1797717586;
			goto IL_000d;
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
					if (customControllerMaps[num].categoryId == categoryId)
					{
						num2 = -205653912;
						goto IL_0016;
					}
					goto IL_0093;
					IL_0016:
					while (true)
					{
						switch (num2 ^ -205653910)
						{
						case 0:
							num2 = -205653909;
							continue;
						case 1:
							break;
						case 2:
							goto IL_0052;
						case 3:
							return customControllerMaps[num].id;
						default:
							goto end_IL_0037;
						}
						break;
						IL_0052:
						if (customControllerMaps[num].layoutId == layoutId && customControllerMaps[num].customControllerUid == controllerUid)
						{
							num2 = -205653911;
							continue;
						}
						goto IL_0093;
					}
					continue;
					IL_0093:
					num++;
					num2 = -205653906;
					goto IL_0016;
					continue;
					end_IL_0037:
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
				int num2 = 833918520;
				while (true)
				{
					switch (num2 ^ 0x31B4963C)
					{
					case 2:
						break;
					case 0:
						if (customControllerMaps[num].id == mapId)
						{
							return true;
						}
						goto IL_0048;
					case 3:
						if (customControllerMaps[num].categoryId == categoryId && customControllerMaps[num].layoutId == layoutId)
						{
							num2 = 833918524;
							continue;
						}
						goto IL_0048;
					case 4:
						num2 = 833918525;
						continue;
					default:
						{
							if (num >= customControllerMaps.Count)
							{
								return false;
							}
							goto case 3;
						}
						IL_0048:
						num++;
						num2 = 833918525;
						continue;
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
			while (num < customControllerMaps.Count)
			{
				while (true)
				{
					if (customControllerMaps[num].id == mapId)
					{
						return true;
					}
					num++;
					int num2 = -2010623472;
					while (true)
					{
						switch (num2 ^ -2010623472)
						{
						case 2:
							num2 = -2010623471;
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

		public bool HasCustomControllerMapInCategory(int controllerUid, int categoryId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			int num = 0;
			while (num < customControllerMaps.Count)
			{
				while (true)
				{
					if (customControllerMaps[num].customControllerUid == controllerUid && customControllerMaps[num].categoryId == categoryId)
					{
						return true;
					}
					num++;
					int num2 = -1923830009;
					while (true)
					{
						switch (num2 ^ -1923830011)
						{
						case 0:
							num2 = -1923830012;
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
			int num = 1986482649;
			goto IL_0018;
			IL_0013:
			num = 1986482651;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ 0x766751DA)
				{
				case 0:
					break;
				case 1:
					goto IL_0035;
				case 3:
					controllerMap_Editor.categoryId = categoryId;
					controllerMap_Editor.layoutId = layoutId;
					controllerMap_Editor.hardwareGuidString = string.Empty;
					controllerMap_Editor.customControllerUid = controllerUid;
					num = 1986482648;
					continue;
				default:
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
				int num2 = 530076206;
				while (true)
				{
					switch (num2 ^ 0x1F98522E)
					{
					case 4:
						num2 = 530076205;
						continue;
					case 3:
						break;
					case 1:
						if (customControllerMaps[num].id == mapId)
						{
							customControllerMaps.RemoveAt(num);
							num2 = 530076204;
							continue;
						}
						goto case 2;
					case 2:
						num--;
						num2 = 530076206;
						continue;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public int DuplicateCustomControllerMap(int index)
		{
			if (customControllerMaps != null)
			{
				ControllerMap_Editor controllerMap_Editor = default(ControllerMap_Editor);
				while (true)
				{
					int num = 959313521;
					while (true)
					{
						switch (num ^ 0x392DF675)
						{
						case 0:
							break;
						case 4:
							goto IL_002e;
						case 1:
							controllerMap_Editor = customControllerMaps[index].Clone();
							num = 959313527;
							continue;
						case 3:
							goto end_IL_0008;
						default:
							controllerMap_Editor.id = GetNewCustomControllerMapId();
							customControllerMaps.Add(controllerMap_Editor);
							return customControllerMaps.Count - 1;
						}
						break;
						IL_002e:
						if (index < 0)
						{
							goto end_IL_0008;
						}
						int num2;
						if (index >= customControllerMaps.Count)
						{
							num = 959313526;
							num2 = num;
						}
						else
						{
							num = 959313524;
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

		internal CustomControllerMap MehHSdzwFfroqrFNXLiGTsJRIwK(Guid P_0, int P_1, int P_2)
		{
			return MehHSdzwFfroqrFNXLiGTsJRIwK(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap MehHSdzwFfroqrFNXLiGTsJRIwK(int P_0, int P_1, int P_2)
		{
			return MehHSdzwFfroqrFNXLiGTsJRIwK(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap MehHSdzwFfroqrFNXLiGTsJRIwK(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = mesUcMBsplifnocsrcbehcdnWJj(P_1, id, P_2, false);
			if (controllerMap_Editor != null)
			{
				goto IL_001a;
			}
			CustomControllerMap customControllerMap = CustomControllerMap.Blank(id, P_1, P_2);
			int num = -1430176515;
			goto IL_001f;
			IL_001f:
			while (true)
			{
				switch (num ^ -1430176514)
				{
				case 0:
					break;
				case 3:
					customControllerMap.SetIdentity(id, P_1, P_2);
					num = -1430176516;
					continue;
				case 1:
					return customControllerMap;
				case 4:
					customControllerMap = controllerMap_Editor.tWxTCuxQtTvCiNyEQtHSPhPKIKL(ContainsAction, P_0);
					customControllerMap.SetIdentity(id, P_1, P_2);
					num = -1430176513;
					continue;
				default:
					return customControllerMap;
				}
				break;
			}
			goto IL_001a;
			IL_001a:
			num = -1430176518;
			goto IL_001f;
		}

		private ControllerMap_Editor mesUcMBsplifnocsrcbehcdnWJj(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor controllerMap_Editor = GetCustomControllerMap(P_0, P_1, P_2);
			while (true)
			{
				int num = -1950540991;
				while (true)
				{
					switch (num ^ -1950540989)
					{
					case 0:
						break;
					case 2:
						if (controllerMap_Editor != null)
						{
							return controllerMap_Editor;
						}
						if (P_3)
						{
							controllerMap_Editor = CNJluiqbUWuLNmQGsyDvnBjIrTM(P_0, P_1, P_2);
							if (controllerMap_Editor != null)
							{
								goto IL_003e;
							}
						}
						return null;
					default:
						return controllerMap_Editor;
					}
					break;
					IL_003e:
					num = -1950540990;
				}
			}
		}

		private ControllerMap_Editor CNJluiqbUWuLNmQGsyDvnBjIrTM(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				kNCefiYXbcQmvFFPCzwqqkLJPnA(list, customControllerLayouts);
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = 1031536951;
					while (true)
					{
						switch (num ^ 0x3D7C0132)
						{
						case 4:
							break;
						case 3:
							goto IL_0064;
						case 6:
							goto IL_007e;
						case 8:
							goto IL_0098;
						case 7:
							goto IL_00b0;
						case 5:
							num3 = 0;
							num = 1031536948;
							continue;
						case 2:
							num2 = 0;
							num = 1031536955;
							continue;
						case 9:
							num = 1031536945;
							continue;
						case 0:
							return list[num2];
						default:
							goto end_IL_0027;
						}
						break;
						IL_00b0:
						if (list[num3].categoryId == P_0)
						{
							return list[num3];
						}
						num3++;
						num = 1031536948;
						continue;
						IL_007e:
						int num4;
						if (num3 < list.Count)
						{
							num = 1031536949;
							num4 = num;
						}
						else
						{
							num = 1031536944;
							num4 = num;
						}
						continue;
						IL_0064:
						int num5;
						if (num2 >= list.Count)
						{
							num = 1031536947;
							num5 = num;
						}
						else
						{
							num = 1031536954;
							num5 = num;
						}
						continue;
						IL_0098:
						if (list[num2].categoryId == 0)
						{
							num = 1031536946;
							continue;
						}
						num2++;
						num = 1031536945;
					}
					continue;
					end_IL_0027:
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
			case ControllerType.Mouse:
				DeleteMouseMap(id);
				num = -1987528164;
				goto IL_0023;
			case ControllerType.Joystick:
				goto IL_0072;
			case ControllerType.Keyboard:
				goto IL_0081;
			case ControllerType.Custom:
				goto IL_0097;
				IL_0023:
				while (true)
				{
					switch (num ^ -1987528168)
					{
					case 8:
						num = -1987528162;
						continue;
					case 1:
						break;
					case 5:
						return;
					case 4:
						return;
					case 6:
						goto IL_0072;
					case 2:
						goto IL_0081;
					case 3:
						return;
					case 7:
						goto IL_0097;
					default:
						goto end_IL_0003;
					}
					break;
				}
				goto case ControllerType.Mouse;
				IL_0097:
				DeleteCustomControllerMap(id);
				num = -1987528165;
				goto IL_0023;
				IL_0081:
				DeleteKeyboardMap(id);
				num = -1987528163;
				goto IL_0023;
				IL_0072:
				DeleteJoystickMap(id);
				return;
				end_IL_0003:
				break;
			}
			throw new NotImplementedException();
		}

		public ControllerMap_Editor GetControllerMapByIndex(ControllerType controllerType, int index)
		{
			int num;
			switch (controllerType)
			{
			case ControllerType.Joystick:
				if (joystickMaps == null)
				{
					return null;
				}
				return joystickMaps[index];
			case ControllerType.Keyboard:
				if (keyboardMaps == null)
				{
					num = -2082698910;
					goto IL_0023;
				}
				return keyboardMaps[index];
			case ControllerType.Mouse:
				if (mouseMaps == null)
				{
					num = -2082698909;
					goto IL_0023;
				}
				return mouseMaps[index];
			case ControllerType.Custom:
				if (customControllerMaps == null)
				{
					return null;
				}
				return customControllerMaps[index];
			default:
				{
					throw new NotImplementedException();
				}
				IL_0023:
				while (true)
				{
					switch (num ^ -2082698911)
					{
					case 0:
						goto IL_001e;
					case 1:
						break;
					case 3:
						return null;
					default:
						return null;
					}
					break;
					IL_001e:
					num = -2082698912;
				}
				goto case ControllerType.Joystick;
			}
		}

		public ControllerMap_Editor GetControllerMapById(ControllerType controllerType, int id, out int controllerMapIndex)
		{
			switch (controllerType)
			{
			default:
				while (true)
				{
					switch (0x6A9A3082 ^ 0x6A9A3083)
					{
					case 0:
						continue;
					case 1:
						if (controllerType == ControllerType.Custom)
						{
							return GetCustomControllerMapById(id, out controllerMapIndex);
						}
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
			}
		}

		public int DuplicateControllerMap(ControllerType controllerType, int index)
		{
			switch (controllerType)
			{
			default:
				while (true)
				{
					int num = 351756032;
					while (true)
					{
						switch (num ^ 0x14F75F01)
						{
						case 2:
							break;
						case 1:
							goto IL_0036;
						default:
							goto end_IL_0014;
						case 0:
							throw new NotImplementedException();
						}
						break;
						IL_0036:
						if (controllerType != ControllerType.Custom)
						{
							num = 351756033;
							continue;
						}
						return DuplicateCustomControllerMap(index);
					}
					continue;
					end_IL_0014:
					break;
				}
				goto case ControllerType.Joystick;
			case ControllerType.Joystick:
				return DuplicateJoystickMap(index);
			case ControllerType.Keyboard:
				return DuplicateKeyboardMap(index);
			case ControllerType.Mouse:
				return DuplicateMouseMap(index);
			}
		}

		internal ControllerTemplateMap quXceAXtIYyNSwGxvhSIeOQfaAr(Guid P_0, int P_1, int P_2)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_1, P_0, P_2);
			if (joystickMap == null)
			{
				return null;
			}
			return joystickMap.GaAHbtiqBLdJLjtKRuPwZbTDYbv();
		}

		public void AddCustomController()
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
				goto IL_0013;
			}
			goto IL_0031;
			IL_0031:
			customControllers.Add(zfVjVLSnvKCOOFegDkxSQZkhTSQb());
			int num = -1905701612;
			goto IL_0018;
			IL_0013:
			num = -1905701609;
			goto IL_0018;
			IL_0018:
			switch (num ^ -1905701610)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0031;
			case 2:
				return;
			}
			goto IL_0013;
		}

		public void InsertCustomController(int index)
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
				goto IL_0013;
			}
			goto IL_003d;
			IL_003d:
			int num;
			int num2;
			if (index >= 0)
			{
				num = -310267011;
				num2 = num;
			}
			else
			{
				num = -310267016;
				num2 = num;
			}
			goto IL_0018;
			IL_0013:
			num = -310267015;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ -310267016)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					goto IL_003d;
				case 0:
					throw new ArgumentOutOfRangeException("index");
				case 5:
					goto IL_0064;
				case 2:
					customControllers.Insert(index, zfVjVLSnvKCOOFegDkxSQZkhTSQb());
					num = -310267013;
					continue;
				case 3:
					return;
				}
				break;
				IL_0064:
				int num3;
				if (index < customControllers.Count)
				{
					num = -310267014;
					num3 = num;
				}
				else
				{
					num = -310267016;
					num3 = num;
				}
			}
			goto IL_0013;
		}

		public void DeleteCustomController(int index)
		{
			if (customControllers == null || index < 0)
			{
				goto IL_00a8;
			}
			if (index >= customControllers.Count)
			{
				goto IL_0023;
			}
			goto IL_00d3;
			IL_00d3:
			int id = customControllers[index].id;
			int num = default(int);
			int num2;
			if (customControllerMaps != null)
			{
				num = customControllerMaps.Count - 1;
				num2 = 592486751;
				goto IL_0028;
			}
			goto IL_0105;
			IL_00a8:
			throw new ArgumentOutOfRangeException("index");
			IL_0023:
			num2 = 592486744;
			goto IL_0028;
			IL_0028:
			while (true)
			{
				switch (num2 ^ 0x2350A15A)
				{
				case 0:
					break;
				case 7:
					goto IL_005c;
				case 5:
					num2 = 592486747;
					continue;
				case 1:
					goto IL_0088;
				case 3:
					num--;
					num2 = 592486747;
					continue;
				case 2:
					goto IL_00a8;
				case 4:
					customControllerMaps.RemoveAt(num);
					num2 = 592486745;
					continue;
				case 8:
					goto IL_00d3;
				default:
					goto IL_0105;
				}
				break;
				IL_0088:
				int num3;
				if (num >= 0)
				{
					num2 = 592486749;
					num3 = num2;
				}
				else
				{
					num2 = 592486748;
					num3 = num2;
				}
				continue;
				IL_005c:
				int num4;
				if (customControllerMaps[num].customControllerUid == id)
				{
					num2 = 592486750;
					num4 = num2;
				}
				else
				{
					num2 = 592486745;
					num4 = num2;
				}
			}
			goto IL_0023;
			IL_0105:
			customControllers.RemoveAt(index);
		}

		public bool ReorderCustomController(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllers, index, offsetDown, offsetNow);
		}

		public void DuplicateCustomController(int index, bool duplicateMaps)
		{
			if (customControllers != null && index >= 0)
			{
				int num3 = default(int);
				int id = default(int);
				CustomController_Editor customController_Editor = default(CustomController_Editor);
				int id2 = default(int);
				while (true)
				{
					int num = 1315638559;
					while (true)
					{
						switch (num ^ 0x4E6B0D17)
						{
						case 4:
							break;
						default:
							return;
						case 1:
						{
							int num2 = DuplicateCustomControllerMap(num3);
							if (num2 >= 0)
							{
								customControllerMaps[num2].customControllerUid = id;
								num = 1315638546;
								continue;
							}
							goto case 5;
						}
						case 2:
							customControllers.Insert(index + 1, customController_Editor);
							num = 1315638555;
							continue;
						case 3:
							id2 = customControllers[index].id;
							num = 1315638551;
							continue;
						case 0:
							if (customControllerMaps != null)
							{
								num3 = customControllerMaps.Count - 1;
								num = 1315638556;
								continue;
							}
							return;
						case 7:
							goto end_IL_0012;
						case 12:
							if (duplicateMaps)
							{
								id = customController_Editor.id;
								num = 1315638548;
								continue;
							}
							return;
						case 13:
							goto IL_0112;
						case 9:
							customController_Editor.typeGuid = Guid.NewGuid();
							num = 1315638557;
							continue;
						case 5:
							num3--;
							num = 1315638556;
							continue;
						case 10:
							customController_Editor.name = StringTools.IterateName(customController_Editor.name, -1, GetCustomControllerNames());
							if (index == customControllers.Count - 1)
							{
								customControllers.Add(customController_Editor);
								num = 1315638555;
								continue;
							}
							goto case 2;
						case 8:
							goto IL_019e;
						case 14:
							customController_Editor = customControllers[index].Clone();
							customController_Editor.id = GetNewCustomControllerId();
							num = 1315638558;
							continue;
						case 11:
							goto IL_01e8;
						case 6:
							return;
						}
						break;
						IL_01e8:
						int num4;
						if (num3 < 0)
						{
							num = 1315638545;
							num4 = num;
						}
						else
						{
							num = 1315638554;
							num4 = num;
						}
						continue;
						IL_019e:
						int num5;
						if (index >= customControllers.Count)
						{
							num = 1315638544;
							num5 = num;
						}
						else
						{
							num = 1315638553;
							num5 = num;
						}
						continue;
						IL_0112:
						int num6;
						if (customControllerMaps[num3].customControllerUid != id2)
						{
							num = 1315638546;
							num6 = num;
						}
						else
						{
							num = 1315638550;
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
				int num2 = 661204397;
				while (true)
				{
					switch (num2 ^ 0x27692DAC)
					{
					case 5:
						break;
					case 1:
						if (customControllerMaps != null)
						{
							num3 = 0;
							num2 = 661204396;
							continue;
						}
						goto default;
					case 3:
						num3++;
						num2 = 661204396;
						continue;
					case 0:
					{
						int num4;
						if (num3 >= customControllerMaps.Count)
						{
							num2 = 661204398;
							num4 = num2;
						}
						else
						{
							num2 = 661204392;
							num4 = num2;
						}
						continue;
					}
					case 4:
						if (customControllerMaps[num3].customControllerUid == controllerUid)
						{
							num++;
							num2 = 661204399;
							continue;
						}
						goto case 3;
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
				goto IL_0008;
			}
			int num = 0;
			int num2 = -284888679;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -284888679)
				{
				case 3:
					break;
				case 1:
					return 0;
				case 2:
					if (customControllers[num].id != id)
					{
						goto IL_004b;
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
				IL_004b:
				num++;
				num2 = -284888679;
			}
			goto IL_0008;
			IL_0008:
			num2 = -284888680;
			goto IL_000d;
		}

		public string[] GetCustomControllerNames()
		{
			if (customControllers == null)
			{
				goto IL_0008;
			}
			string[] array = new string[customControllers.Count];
			int num = 0;
			int num2 = 83878682;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x4FFE31E)
				{
				case 0:
					break;
				case 2:
					return null;
				case 3:
					array[num] = customControllers[num].name;
					num++;
					num2 = 83878682;
					continue;
				case 4:
				{
					int num3;
					if (num < customControllers.Count)
					{
						num2 = 83878685;
						num3 = num2;
					}
					else
					{
						num2 = 83878687;
						num3 = num2;
					}
					continue;
				}
				default:
					return array;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 83878684;
			goto IL_000d;
		}

		public int[] GetCustomControllerIds()
		{
			if (customControllers == null)
			{
				return null;
			}
			int[] array = new int[customControllers.Count];
			int num = 0;
			while (num < customControllers.Count)
			{
				while (true)
				{
					array[num] = customControllers[num].id;
					int num2 = -374047481;
					while (true)
					{
						switch (num2 ^ -374047481)
						{
						case 3:
							num2 = -374047482;
							continue;
						case 1:
							break;
						case 0:
							num++;
							num2 = -374047483;
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
					array[num] = customControllers[num].typeGuid;
					num++;
					int num2 = 1493945019;
					while (true)
					{
						switch (num2 ^ 0x590BCABA)
						{
						case 0:
							num2 = 1493945016;
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

		public CustomController_Editor GetCustomController(int index)
		{
			if (customControllers == null || index < 0 || index >= customControllers.Count)
			{
				return null;
			}
			return customControllers[index];
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
				return -1;
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
					int num2 = -1904532421;
					while (true)
					{
						switch (num2 ^ -1904532421)
						{
						case 2:
							num2 = -1904532422;
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

		public int IndexOfCustomController(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (customControllers == null)
				{
					return -1;
				}
				num = 0;
				num2 = -2060361400;
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num2 ^ -2060361397)
				{
				case 4:
					break;
				case 1:
					goto IL_0036;
				case 3:
					goto IL_004b;
				case 0:
					goto IL_006a;
				default:
					return -1;
				}
				break;
				IL_006a:
				if (customControllers[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = -2060361400;
				continue;
				IL_004b:
				int num3;
				if (num < customControllers.Count)
				{
					num2 = -2060361397;
					num3 = num2;
				}
				else
				{
					num2 = -2060361399;
					num3 = num2;
				}
			}
			goto IL_0010;
			IL_0010:
			num2 = -2060361398;
			goto IL_0015;
			IL_0036:
			return -1;
		}

		public int IndexOfCustomController(Guid hardwareTypeGuid)
		{
			if (customControllers == null)
			{
				return -1;
			}
			int num = 0;
			while (num < customControllers.Count)
			{
				while (true)
				{
					if (customControllers[num].typeGuid == hardwareTypeGuid)
					{
						return num;
					}
					num++;
					int num2 = -909472943;
					while (true)
					{
						switch (num2 ^ -909472941)
						{
						case 0:
							num2 = -909472942;
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

		public string GetCustomControllerNameById(int id)
		{
			if (customControllers != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -320835050;
					while (true)
					{
						switch (num ^ -320835051)
						{
						case 0:
							break;
						case 2:
							goto IL_002e;
						case 4:
							goto IL_004d;
						case 3:
							num2 = 0;
							num = -320835049;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_004d:
						if (customControllers[num2].id == id)
						{
							return customControllers[num2].name;
						}
						num2++;
						num = -320835049;
						continue;
						IL_002e:
						int num3;
						if (num2 >= customControllers.Count)
						{
							num = -320835052;
							num3 = num;
						}
						else
						{
							num = -320835055;
							num3 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return "Unknown";
		}

		public void AddControllerMapLayoutManagerRuleSet()
		{
			controllerMapLayoutManagerRuleSets.Add(dyxuGoYmAlKZAxNhkdDEefQoqxS());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = 1558301882;
					while (true)
					{
						switch (num ^ 0x5CE1CCBB)
						{
						case 2:
							break;
						default:
							return;
						case 3:
							controllerMapLayoutManagerRuleSets.Insert(index, dyxuGoYmAlKZAxNhkdDEefQoqxS());
							num = 1558301887;
							continue;
						case 0:
							goto end_IL_0004;
						case 1:
							goto IL_0055;
						case 4:
							return;
						}
						break;
						IL_0055:
						int num2;
						if (index < controllerMapLayoutManagerRuleSets.Count)
						{
							num = 1558301880;
							num2 = num;
						}
						else
						{
							num = 1558301883;
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
			if (controllerMapLayoutManagerRuleSets == null || index < 0)
			{
				goto IL_00c9;
			}
			if (index >= controllerMapLayoutManagerRuleSets.Count)
			{
				goto IL_0023;
			}
			goto IL_0137;
			IL_0137:
			int id = controllerMapLayoutManagerRuleSets[index].id;
			int num = -1684226928;
			goto IL_0028;
			IL_00c9:
			throw new ArgumentOutOfRangeException("index");
			IL_0023:
			num = -1684226926;
			goto IL_0028;
			IL_0028:
			Player_Editor player_Editor = default(Player_Editor);
			int num2 = default(int);
			List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1684226927)
				{
				case 6:
					break;
				case 4:
					player_Editor = players[num2];
					num = -1684226924;
					continue;
				case 1:
					goto IL_0084;
				case 11:
					if (ruleSets[num3] != null && ruleSets[num3].id == id)
					{
						ruleSets.RemoveAt(num3);
						num = -1684226915;
						continue;
					}
					goto case 12;
				case 3:
					goto IL_00c9;
				case 5:
					if (player_Editor != null)
					{
						ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
						num = -1684226922;
						continue;
					}
					goto case 10;
				case 0:
					goto IL_00f7;
				case 12:
					num3--;
					num = -1684226927;
					continue;
				case 7:
					if (ruleSets != null)
					{
						num3 = ruleSets.Count - 1;
						num = -1684226927;
						continue;
					}
					goto case 10;
				case 9:
					goto IL_0137;
				case 10:
					num2++;
					num = -1684226916;
					continue;
				case 13:
					goto IL_0161;
				case 8:
					num2 = 0;
					num = -1684226916;
					continue;
				default:
					controllerMapLayoutManagerRuleSets.RemoveAt(index);
					return;
				}
				break;
				IL_0161:
				int num4;
				if (num2 >= players.Count)
				{
					num = -1684226925;
					num4 = num;
				}
				else
				{
					num = -1684226923;
					num4 = num;
				}
				continue;
				IL_00f7:
				int num5;
				if (num3 < 0)
				{
					num = -1684226917;
					num5 = num;
				}
				else
				{
					num = -1684226918;
					num5 = num;
				}
				continue;
				IL_0084:
				int num6;
				if (players != null)
				{
					num = -1684226919;
					num6 = num;
				}
				else
				{
					num = -1684226925;
					num6 = num;
				}
			}
			goto IL_0023;
		}

		public bool ReorderControllerMapLayoutManagerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapLayoutManagerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets != null)
			{
				ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = default(ControllerMapLayoutManager_RuleSet_Editor);
				while (true)
				{
					int num = 2091943286;
					while (true)
					{
						switch (num ^ 0x7CB0857E)
						{
						case 5:
							break;
						default:
							return;
						case 8:
							goto IL_0041;
						case 3:
							goto end_IL_0008;
						case 7:
							goto IL_0068;
						case 2:
							controllerMapLayoutManagerRuleSets.Insert(index + 1, controllerMapLayoutManager_RuleSet_Editor);
							num = 2091943295;
							continue;
						case 6:
							controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName(controllerMapLayoutManager_RuleSet_Editor.name, -1, GetControllerMapLayoutManagerRuleSetNames());
							if (index == controllerMapLayoutManagerRuleSets.Count - 1)
							{
								controllerMapLayoutManagerRuleSets.Add(controllerMapLayoutManager_RuleSet_Editor);
								num = 2091943290;
								continue;
							}
							goto case 2;
						case 0:
							controllerMapLayoutManager_RuleSet_Editor = controllerMapLayoutManagerRuleSets[index].Clone();
							controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
							num = 2091943288;
							continue;
						case 4:
							return;
						case 1:
							return;
						}
						break;
						IL_0068:
						int num2;
						if (index < controllerMapLayoutManagerRuleSets.Count)
						{
							num = 2091943294;
							num2 = num;
						}
						else
						{
							num = 2091943293;
							num2 = num;
						}
						continue;
						IL_0041:
						int num3;
						if (index < 0)
						{
							num = 2091943293;
							num3 = num;
						}
						else
						{
							num = 2091943289;
							num3 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public int GetControllerMapLayoutManagerRuleSetUsedCount(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
			int num6 = default(int);
			Player_Editor player_Editor = default(Player_Editor);
			int num3 = default(int);
			while (true)
			{
				int num2 = 286991739;
				while (true)
				{
					switch (num2 ^ 0x111B2572)
					{
					case 6:
						break;
					case 13:
						if (ruleSets[num6] != null)
						{
							int num8;
							if (ruleSets[num6].id == id)
							{
								num2 = 286991731;
								num8 = num2;
							}
							else
							{
								num2 = 286991738;
								num8 = num2;
							}
							continue;
						}
						goto case 8;
					case 12:
						player_Editor = players[num3];
						num2 = 286991730;
						continue;
					case 11:
						if (ruleSets != null)
						{
							num6 = ruleSets.Count - 1;
							num2 = 286991736;
							continue;
						}
						goto case 7;
					case 3:
						ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
						num2 = 286991737;
						continue;
					case 8:
						num6--;
						num2 = 286991736;
						continue;
					case 5:
						num2 = 286991728;
						continue;
					case 7:
						num3++;
						num2 = 286991728;
						continue;
					case 9:
						if (players != null)
						{
							num3 = 0;
							num2 = 286991735;
							continue;
						}
						goto default;
					case 1:
						num++;
						num2 = 286991738;
						continue;
					case 10:
					{
						int num7;
						if (num6 < 0)
						{
							num2 = 286991733;
							num7 = num2;
						}
						else
						{
							num2 = 286991743;
							num7 = num2;
						}
						continue;
					}
					case 0:
					{
						int num5;
						if (player_Editor != null)
						{
							num2 = 286991729;
							num5 = num2;
						}
						else
						{
							num2 = 286991733;
							num5 = num2;
						}
						continue;
					}
					case 2:
					{
						int num4;
						if (num3 < players.Count)
						{
							num2 = 286991742;
							num4 = num2;
						}
						else
						{
							num2 = 286991734;
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
				int num2 = 1351348368;
				while (true)
				{
					switch (num2 ^ 0x508BF094)
					{
					case 0:
						break;
					case 4:
						num2 = 1351348374;
						continue;
					case 1:
						return num;
					case 3:
						if (controllerMapLayoutManagerRuleSets[num].id != id)
						{
							num++;
							num2 = 1351348374;
						}
						else
						{
							num2 = 1351348373;
						}
						continue;
					default:
						if (num >= controllerMapLayoutManagerRuleSets.Count)
						{
							return -1;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public string[] GetControllerMapLayoutManagerRuleSetNames()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			string[] array = new string[controllerMapLayoutManagerRuleSets.Count];
			int num = 0;
			while (true)
			{
				int num2 = -1061636778;
				while (true)
				{
					switch (num2 ^ -1061636777)
					{
					case 0:
						break;
					case 1:
						num2 = -1061636780;
						continue;
					case 2:
						array[num] = controllerMapLayoutManagerRuleSets[num].name;
						num++;
						num2 = -1061636780;
						continue;
					default:
						if (num >= controllerMapLayoutManagerRuleSets.Count)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
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
					num2 = -1429429760;
					num3 = num2;
				}
				else
				{
					num2 = -1429429758;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1429429757)
					{
					case 0:
						num2 = -1429429760;
						continue;
					case 3:
						array[num] = controllerMapLayoutManagerRuleSets[num].id;
						num++;
						num2 = -1429429759;
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

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				return null;
			}
			return controllerMapLayoutManagerRuleSets[index];
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(string name)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				goto IL_0008;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(name);
			int num2;
			if (num < 0)
			{
				num2 = -798161067;
				goto IL_000d;
			}
			return controllerMapLayoutManagerRuleSets[num];
			IL_0008:
			num2 = -798161066;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ -798161068)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				return null;
			}
			goto IL_0008;
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
				num2 = 1355856479;
				goto IL_000d;
			}
			return controllerMapLayoutManagerRuleSets[num].id;
			IL_0008:
			num2 = 1355856478;
			goto IL_000d;
			IL_000d:
			switch (num2 ^ 0x50D0BA5F)
			{
			case 2:
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
			while (num < controllerMapLayoutManagerRuleSets.Count)
			{
				while (true)
				{
					if (controllerMapLayoutManagerRuleSets[num].id == id)
					{
						return num;
					}
					num++;
					int num2 = 2020071993;
					while (true)
					{
						switch (num2 ^ 0x7867DA3B)
						{
						case 0:
							num2 = 2020071994;
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

		public int IndexOfControllerMapLayoutManagerRuleSet(string name)
		{
			if (name != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -1204991124;
					while (true)
					{
						switch (num ^ -1204991123)
						{
						case 5:
							break;
						case 0:
							goto IL_0031;
						case 6:
							num = -1204991123;
							continue;
						case 3:
							goto end_IL_0003;
						case 1:
							goto IL_006c;
						case 4:
							goto IL_0080;
						default:
							return -1;
						}
						break;
						IL_0080:
						if (controllerMapLayoutManagerRuleSets[num2].name.Equals(name, StringComparison.OrdinalIgnoreCase))
						{
							return num2;
						}
						num2++;
						num = -1204991123;
						continue;
						IL_006c:
						if (!(name == string.Empty))
						{
							if (controllerMapLayoutManagerRuleSets == null)
							{
								return -1;
							}
							num2 = 0;
							num = -1204991125;
						}
						else
						{
							num = -1204991122;
						}
						continue;
						IL_0031:
						int num3;
						if (num2 < controllerMapLayoutManagerRuleSets.Count)
						{
							num = -1204991127;
							num3 = num;
						}
						else
						{
							num = -1204991121;
							num3 = num;
						}
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return -1;
		}

		public string GetControllerMapLayoutManagerRuleSetNameById(int id)
		{
			if (controllerMapLayoutManagerRuleSets != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = 2042601850;
					while (true)
					{
						switch (num ^ 0x79BFA178)
						{
						case 0:
							break;
						case 3:
							goto IL_002e;
						case 1:
							goto IL_004d;
						case 2:
							num2 = 0;
							num = 2042601851;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_004d:
						if (controllerMapLayoutManagerRuleSets[num2].id == id)
						{
							return controllerMapLayoutManagerRuleSets[num2].name;
						}
						num2++;
						num = 2042601851;
						continue;
						IL_002e:
						int num3;
						if (num2 >= controllerMapLayoutManagerRuleSets.Count)
						{
							num = 2042601852;
							num3 = num;
						}
						else
						{
							num = 2042601849;
							num3 = num;
						}
					}
					continue;
					end_IL_0008:
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
			controllerMapEnablerRuleSets.Add(kPvSZbTjVWghpQbsTYAeDHISaOI());
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
			IL_0046:
			controllerMapEnablerRuleSets.Insert(index, kPvSZbTjVWghpQbsTYAeDHISaOI());
			int num = 1962035796;
			goto IL_0017;
			IL_0012:
			num = 1962035798;
			goto IL_0017;
			IL_0017:
			switch (num ^ 0x74F24A57)
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

		public void DeleteControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets != null && index >= 0)
			{
				if (index >= controllerMapEnablerRuleSets.Count)
				{
					goto IL_0020;
				}
				goto IL_0088;
			}
			goto IL_0153;
			IL_0088:
			int id = controllerMapEnablerRuleSets[index].id;
			int num = default(int);
			int num2;
			if (players != null)
			{
				num = 0;
				num2 = 2031871628;
				goto IL_0025;
			}
			goto IL_0126;
			IL_0153:
			throw new ArgumentOutOfRangeException("index");
			IL_0020:
			num2 = 2031871621;
			goto IL_0025;
			IL_0025:
			List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x791BE687)
				{
				case 3:
					break;
				default:
					return;
				case 8:
				{
					Player_Editor player_Editor = players[num];
					if (player_Editor != null)
					{
						ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
						num2 = 2031871617;
						continue;
					}
					goto case 9;
				}
				case 1:
					goto IL_0088;
				case 4:
					goto IL_00b1;
				case 9:
					num++;
					num2 = 2031871628;
					continue;
				case 11:
					goto IL_00d8;
				case 0:
					if (ruleSets[num3] != null && ruleSets[num3].id == id)
					{
						ruleSets.RemoveAt(num3);
						num2 = 2031871629;
						continue;
					}
					goto case 10;
				case 5:
					goto IL_0126;
				case 6:
					if (ruleSets != null)
					{
						num3 = ruleSets.Count - 1;
						num2 = 2031871619;
						continue;
					}
					goto case 9;
				case 2:
					goto IL_0153;
				case 10:
					num3--;
					num2 = 2031871619;
					continue;
				case 7:
					return;
				}
				break;
				IL_00d8:
				int num4;
				if (num < players.Count)
				{
					num2 = 2031871631;
					num4 = num2;
				}
				else
				{
					num2 = 2031871618;
					num4 = num2;
				}
				continue;
				IL_00b1:
				int num5;
				if (num3 < 0)
				{
					num2 = 2031871630;
					num5 = num2;
				}
				else
				{
					num2 = 2031871623;
					num5 = num2;
				}
			}
			goto IL_0020;
			IL_0126:
			controllerMapEnablerRuleSets.RemoveAt(index);
			num2 = 2031871616;
			goto IL_0025;
		}

		public bool ReorderControllerMapEnablerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapEnablerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0)
			{
				goto IL_0056;
			}
			if (index >= controllerMapEnablerRuleSets.Count)
			{
				goto IL_001d;
			}
			goto IL_00cc;
			IL_00cc:
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = controllerMapEnablerRuleSets[index].Clone();
			int num = 1043185431;
			goto IL_0022;
			IL_0056:
			throw new ArgumentOutOfRangeException("index");
			IL_001d:
			num = 1043185433;
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num ^ 0x3E2DBF11)
				{
				case 7:
					break;
				default:
					return;
				case 8:
					goto IL_0056;
				case 3:
					goto IL_0068;
				case 6:
					controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
					num = 1043185428;
					continue;
				case 1:
					controllerMapEnablerRuleSets.Add(controllerMapEnabler_RuleSet_Editor);
					return;
				case 0:
					controllerMapEnablerRuleSets.Insert(index + 1, controllerMapEnabler_RuleSet_Editor);
					num = 1043185429;
					continue;
				case 2:
					goto IL_00cc;
				case 5:
					controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName(controllerMapEnabler_RuleSet_Editor.name, -1, GetControllerMapEnablerRuleSetNames());
					num = 1043185426;
					continue;
				case 4:
					return;
				}
				break;
				IL_0068:
				int num2;
				if (index != controllerMapEnablerRuleSets.Count - 1)
				{
					num = 1043185425;
					num2 = num;
				}
				else
				{
					num = 1043185424;
					num2 = num;
				}
			}
			goto IL_001d;
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
				List<Player_Editor.RuleSetMapping> ruleSets = default(List<Player_Editor.RuleSetMapping>);
				int num4 = default(int);
				while (true)
				{
					int num3 = -139170990;
					while (true)
					{
						switch (num3 ^ -139170987)
						{
						case 8:
							break;
						case 9:
							goto IL_0056;
						case 2:
							num2++;
							num3 = -139170980;
							continue;
						case 0:
							num3 = -139170992;
							continue;
						case 7:
							num3 = -139170980;
							continue;
						case 5:
							goto IL_008e;
						case 3:
							if (ruleSets[num4] != null && ruleSets[num4].id == id)
							{
								num++;
								num3 = -139170991;
								continue;
							}
							goto case 4;
						case 1:
						{
							Player_Editor player_Editor = players[num2];
							if (player_Editor != null)
							{
								ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
								if (ruleSets != null)
								{
									num4 = ruleSets.Count - 1;
									num3 = -139170987;
									continue;
								}
							}
							goto case 2;
						}
						case 4:
							num4--;
							num3 = -139170992;
							continue;
						default:
							goto end_IL_0019;
						}
						break;
						IL_008e:
						int num5;
						if (num4 >= 0)
						{
							num3 = -139170986;
							num5 = num3;
						}
						else
						{
							num3 = -139170985;
							num5 = num3;
						}
						continue;
						IL_0056:
						int num6;
						if (num2 < players.Count)
						{
							num3 = -139170988;
							num6 = num3;
						}
						else
						{
							num3 = -139170989;
							num6 = num3;
						}
					}
					continue;
					end_IL_0019:
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
			while (true)
			{
				int num2;
				int num3;
				if (num >= controllerMapEnablerRuleSets.Count)
				{
					num2 = 1553731904;
					num3 = num2;
				}
				else
				{
					num2 = 1553731905;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x5C9C1143)
					{
					case 0:
						num2 = 1553731905;
						continue;
					case 2:
						if (controllerMapEnablerRuleSets[num].id == id)
						{
							return num;
						}
						num++;
						num2 = 1553731906;
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

		public string[] GetControllerMapEnablerRuleSetNames()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				goto IL_0008;
			}
			string[] array = new string[controllerMapEnablerRuleSets.Count];
			int num = 0;
			int num2 = 619566284;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x24EDD4C9)
				{
				case 0:
					break;
				case 4:
					return null;
				case 5:
					num2 = 619566280;
					continue;
				case 3:
					num++;
					num2 = 619566280;
					continue;
				case 2:
					array[num] = controllerMapEnablerRuleSets[num].name;
					num2 = 619566282;
					continue;
				default:
					if (num >= controllerMapEnablerRuleSets.Count)
					{
						return array;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 619566285;
			goto IL_000d;
		}

		public int[] GetControllerMapEnablerRuleSetIds()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				goto IL_0008;
			}
			int[] array = new int[controllerMapEnablerRuleSets.Count];
			int num = 0;
			int num2 = 1099532912;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x41898A72)
				{
				case 3:
					break;
				case 4:
					return null;
				case 2:
					num2 = 1099532915;
					continue;
				case 0:
					array[num] = controllerMapEnablerRuleSets[num].id;
					num++;
					num2 = 1099532915;
					continue;
				default:
					if (num >= controllerMapEnablerRuleSets.Count)
					{
						return array;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1099532918;
			goto IL_000d;
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				return null;
			}
			return controllerMapEnablerRuleSets[index];
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
				return -1;
			}
			int num = IndexOfControllerMapEnablerRuleSet(name);
			if (num < 0)
			{
				return -1;
			}
			return controllerMapEnablerRuleSets[num].id;
		}

		public int IndexOfControllerMapEnablerRuleSet(int id)
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return -1;
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
					int num2 = -1957039914;
					while (true)
					{
						switch (num2 ^ -1957039913)
						{
						case 0:
							num2 = -1957039915;
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
			return -1;
		}

		public int IndexOfControllerMapEnablerRuleSet(string name)
		{
			int num = default(int);
			int num2;
			if (name != null)
			{
				if (name == string.Empty)
				{
					goto IL_0010;
				}
				if (controllerMapEnablerRuleSets == null)
				{
					return -1;
				}
				num = 0;
				num2 = 945691912;
				goto IL_0015;
			}
			goto IL_0032;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x385E1D09)
				{
				case 2:
					break;
				case 3:
					goto IL_0032;
				case 0:
					goto IL_0047;
				default:
					if (num >= controllerMapEnablerRuleSets.Count)
					{
						return -1;
					}
					goto IL_0047;
				}
				break;
				IL_0047:
				if (controllerMapEnablerRuleSets[num].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return num;
				}
				num++;
				num2 = 945691912;
			}
			goto IL_0010;
			IL_0010:
			num2 = 945691914;
			goto IL_0015;
			IL_0032:
			return -1;
		}

		public string GetControllerMapEnablerRuleSetNameById(int id)
		{
			if (controllerMapEnablerRuleSets != null)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < controllerMapEnablerRuleSets.Count)
					{
						num2 = 1328463075;
						num3 = num2;
					}
					else
					{
						num2 = 1328463073;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x4F2EBCE1)
						{
						case 3:
							num2 = 1328463075;
							continue;
						case 2:
							break;
						case 1:
							goto end_IL_0011;
						default:
							goto end_IL_005f;
						}
						if (controllerMapEnablerRuleSets[num].id == id)
						{
							return controllerMapEnablerRuleSets[num].name;
						}
						num++;
						num2 = 1328463072;
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
				int num = -873137026;
				while (true)
				{
					switch (num ^ -873137028)
					{
					case 0:
						break;
					case 2:
						goto IL_0025;
					default:
						return result;
					}
					break;
					IL_0025:
					customControllerLayoutIdCounter++;
					num = -873137027;
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

		private Player_Editor GSZeaxXpRdMLDgOmmHuwrCgsXjs()
		{
			Player_Editor player_Editor = new Player_Editor();
			while (true)
			{
				int num = 790075251;
				while (true)
				{
					switch (num ^ 0x2F179772)
					{
					case 3:
						break;
					case 1:
						player_Editor.id = GetNewPlayerId();
						player_Editor.name = StringTools.IterateName("Player", -1, GetPlayerNames());
						player_Editor.descriptiveName = player_Editor.name;
						num = 790075248;
						continue;
					case 2:
						player_Editor.startPlaying = true;
						num = 790075254;
						continue;
					case 4:
						if (players.Count == 1)
						{
							player_Editor.assignMouseOnStart = true;
							num = 790075250;
							continue;
						}
						goto default;
					default:
						player_Editor.assignKeyboardOnStart = true;
						player_Editor.controllerMapEnablerSettings = new Player_Editor.ControllerMapEnablerSettings();
						player_Editor.controllerMapLayoutManagerSettings = new Player_Editor.ControllerMapLayoutManagerSettings();
						return player_Editor;
					}
					break;
				}
			}
		}

		private InputAction qmmLkpyoMAPiNNUvjLGWnxdTDTy()
		{
			InputAction inputAction = new InputAction();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName("Action", -1, GetActionNames());
			inputAction.descriptiveName = inputAction.name;
			inputAction.type = InputActionType.Button;
			inputAction.userAssignable = true;
			inputAction.behaviorId = 0;
			return inputAction;
		}

		private InputCategory TRJwjOZSSTAKChaAiCgKPWJxOmQ()
		{
			InputCategory inputCategory = new InputCategory();
			inputCategory.id = GetNewActionCategoryId();
			inputCategory.name = StringTools.IterateName("Category", -1, GetActionCategoryNames());
			inputCategory.descriptiveName = inputCategory.name;
			inputCategory.userAssignable = true;
			return inputCategory;
		}

		private InputBehavior sQjLOUlHnCqbfWBVphJhsTFnFdc()
		{
			InputBehavior inputBehavior = new InputBehavior();
			inputBehavior.id = GetNewInputBehaviorId();
			inputBehavior.name = StringTools.IterateName("Behavior", -1, GetInputBehaviorNames());
			inputBehavior.digitalAxisSimulation = true;
			while (true)
			{
				int num = 547896602;
				while (true)
				{
					switch (num ^ 0x20A83D18)
					{
					case 3:
						break;
					case 2:
						inputBehavior.digitalAxisSnap = true;
						inputBehavior.digitalAxisInstantReverse = false;
						inputBehavior.digitalAxisGravity = 3f;
						inputBehavior.digitalAxisSensitivity = 3f;
						num = 547896604;
						continue;
					case 4:
						inputBehavior.mouseXYAxisMode = MouseXYAxisMode.MouseAxis;
						inputBehavior.mouseXYAxisSensitivity = 1f;
						inputBehavior.mouseOtherAxisMode = MouseOtherAxisMode.MouseAxis;
						num = 547896600;
						continue;
					case 0:
						inputBehavior.mouseOtherAxisSensitivity = 1f;
						num = 547896601;
						continue;
					default:
						inputBehavior.buttonDoublePressSpeed = 0.3f;
						inputBehavior.buttonShortPressTime = 0.25f;
						inputBehavior.buttonShortPressExpiresIn = 0f;
						inputBehavior.buttonLongPressTime = 1f;
						inputBehavior.buttonLongPressExpiresIn = 0f;
						inputBehavior.buttonDeadZone = 0.5f;
						inputBehavior.buttonDownBuffer = 0f;
						return inputBehavior;
					}
					break;
				}
			}
		}

		private InputMapCategory ecUyQZFJdpXDXsgxHLbjdNRNGMI()
		{
			InputMapCategory inputMapCategory = new InputMapCategory();
			inputMapCategory.id = GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName("Category", -1, GetMapCategoryNames());
			inputMapCategory.descriptiveName = inputMapCategory.name;
			inputMapCategory.userAssignable = true;
			inputMapCategory.checkConflictsWithAllCategories = true;
			return inputMapCategory;
		}

		private InputLayout jrcBygfzmVMHQPmYGgpgzbYkitSc()
		{
			InputLayout inputLayout = new InputLayout();
			while (true)
			{
				int num = 1620336921;
				while (true)
				{
					switch (num ^ 0x60946118)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						return inputLayout;
					}
					break;
					IL_0024:
					inputLayout.id = GetNewJoystickLayoutId();
					inputLayout.name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames());
					inputLayout.descriptiveName = inputLayout.name;
					num = 1620336920;
				}
			}
		}

		private InputLayout ITVOzABurSvFsagyZmuGYtbzJir()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewKeyboardLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames());
			while (true)
			{
				int num = 1564498118;
				while (true)
				{
					switch (num ^ 0x5D4058C4)
					{
					case 0:
						break;
					case 2:
						goto IL_0047;
					default:
						return inputLayout;
					}
					break;
					IL_0047:
					inputLayout.descriptiveName = inputLayout.name;
					num = 1564498117;
				}
			}
		}

		private InputLayout asWTBfYbeGKFQPgxKcIlfswQTbMv()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewMouseLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private InputLayout tSURnYCtXucFOhJJItwlMfXhOTs()
		{
			InputLayout inputLayout = new InputLayout();
			inputLayout.id = GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames());
			inputLayout.descriptiveName = inputLayout.name;
			return inputLayout;
		}

		private CustomController_Editor zfVjVLSnvKCOOFegDkxSQZkhTSQb()
		{
			CustomController_Editor customController_Editor = new CustomController_Editor();
			customController_Editor.id = GetNewCustomControllerId();
			customController_Editor.typeGuid = Guid.NewGuid();
			customController_Editor.name = StringTools.IterateName("CustomController", -1, GetCustomControllerNames());
			customController_Editor.descriptiveName = customController_Editor.name;
			return customController_Editor;
		}

		private ControllerMapLayoutManager_RuleSet_Editor dyxuGoYmAlKZAxNhkdDEefQoqxS()
		{
			ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = new ControllerMapLayoutManager_RuleSet_Editor();
			controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
			controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames());
			return controllerMapLayoutManager_RuleSet_Editor;
		}

		private ControllerMapEnabler_RuleSet_Editor kPvSZbTjVWghpQbsTYAeDHISaOI()
		{
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = new ControllerMapEnabler_RuleSet_Editor();
			controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
			controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames());
			return controllerMapEnabler_RuleSet_Editor;
		}

		private ControllerMap_Editor kvbIyBmFYvChuBCEzASnETXFXUAB(List<ControllerMap_Editor> P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			int num = 0;
			int num2 = -1825993784;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ -1825993781)
				{
				case 2:
					break;
				case 1:
					return null;
				case 4:
					return P_0[num];
				case 0:
					if (P_0[num].categoryId != P_1 || P_0[num].layoutId != P_2)
					{
						num++;
						num2 = -1825993784;
					}
					else
					{
						num2 = -1825993777;
					}
					continue;
				default:
					if (num >= P_0.Count)
					{
						return null;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = -1825993782;
			goto IL_0008;
		}

		private ControllerMap_Editor EthSUjOfCEJjDeZuqNYxywxsaTS(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = kvbIyBmFYvChuBCEzASnETXFXUAB(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = tGGvfeXWZunqaBgsWMyoDarqzfV(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor tGGvfeXWZunqaBgsWMyoDarqzfV(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = 1164850967;
					while (true)
					{
						switch (num ^ 0x456E3711)
						{
						case 0:
							break;
						case 5:
							goto IL_004a;
						case 1:
							goto IL_0064;
						case 4:
							if (num2 >= list.Count)
							{
								num3 = 0;
								num = 1164850964;
								continue;
							}
							goto IL_0097;
						case 2:
							goto IL_0097;
						case 6:
							kNCefiYXbcQmvFFPCzwqqkLJPnA(list, P_1);
							num2 = 0;
							num = 1164850965;
							continue;
						default:
							goto end_IL_0019;
						}
						break;
						IL_0097:
						if (list[num2].categoryId == P_2)
						{
							return list[num2];
						}
						num2++;
						num = 1164850965;
						continue;
						IL_0064:
						if (list[num3].categoryId == 0)
						{
							return list[num3];
						}
						num3++;
						num = 1164850964;
						continue;
						IL_004a:
						int num4;
						if (num3 < list.Count)
						{
							num = 1164850960;
							num4 = num;
						}
						else
						{
							num = 1164850962;
							num4 = num;
						}
					}
					continue;
					end_IL_0019:
					break;
				}
			}
			return null;
		}

		private void kNCefiYXbcQmvFFPCzwqqkLJPnA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			TUPMRcydglvgirjaQpWjIHGbxCi tUPMRcydglvgirjaQpWjIHGbxCi = new TUPMRcydglvgirjaQpWjIHGbxCi();
			tUPMRcydglvgirjaQpWjIHGbxCi.rIcvIroBgpDYMIGBXMTDQmCTMtX = P_1;
			if (P_0 == null)
			{
				return;
			}
			if (tUPMRcydglvgirjaQpWjIHGbxCi.rIcvIroBgpDYMIGBXMTDQmCTMtX == null)
			{
				while (true)
				{
					switch (-2040615082 ^ -2040615084)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			P_0.Sort(tUPMRcydglvgirjaQpWjIHGbxCi.zQqwCjxakTqscOJwCUDLKmcAaEe);
		}

		internal void YJaAHaimrHWIfKrgfWxeihnqrcza()
		{
			Players_readOnly = new ReadOnlyCollection<Player_Editor>(players);
			int num2 = default(int);
			while (true)
			{
				int num = -784266303;
				while (true)
				{
					switch (num ^ -784266300)
					{
					case 2:
						break;
					default:
						return;
					case 5:
						Actions_readOnly = new ReadOnlyCollection<InputAction>(actions);
						ActionCategories_readOnly = new ReadOnlyCollection<InputCategory>(actionCategories);
						num = -784266300;
						continue;
					case 3:
						CustomControllerLayouts_readOnly = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
						num = -784266302;
						continue;
					case 4:
						MouseLayouts_readOnly = new ReadOnlyCollection<InputLayout>(mouseLayouts);
						num = -784266297;
						continue;
					case 10:
						mapCategories[num2].YJaAHaimrHWIfKrgfWxeihnqrcza();
						num2++;
						num = -784266301;
						continue;
					case 6:
						JoystickMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
						KeyboardMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
						MouseMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
						CustomControllerMaps_readOnly = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
						ControllerMapLayoutManagerRuleSets_readOnly = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
						num = -784266296;
						continue;
					case 1:
						num2 = 0;
						num = -784266301;
						continue;
					case 8:
						KeyboardLayouts_readOnly = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
						num = -784266304;
						continue;
					case 13:
						JoystickLayouts_readOnly = new ReadOnlyCollection<InputLayout>(joystickLayouts);
						num = -784266292;
						continue;
					case 12:
					{
						ControllerMapEnablerRuleSets_readOnly = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
						int num4;
						if (mapCategories != null)
						{
							num = -784266299;
							num4 = num;
						}
						else
						{
							num = -784266291;
							num4 = num;
						}
						continue;
					}
					case 0:
						InputBehaviors_readOnly = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
						MapCategories_readOnly = new ReadOnlyCollection<InputMapCategory>(mapCategories);
						num = -784266295;
						continue;
					case 9:
						containsActionDelegate = ContainsAction;
						num = -784266289;
						continue;
					case 7:
					{
						int num3;
						if (num2 < mapCategories.Count)
						{
							num = -784266290;
							num3 = num;
						}
						else
						{
							num = -784266291;
							num3 = num;
						}
						continue;
					}
					case 11:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return QLHgQpZPcsnVUxynhqtqdKZxfLI.TOjOfzJeCUTmMnojBKzdzOKRule(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return QLHgQpZPcsnVUxynhqtqdKZxfLI.TOjOfzJeCUTmMnojBKzdzOKRule(orig, null, false);
		}

		[CompilerGenerated]
		private static void SkrjVSLMnBwshbrxbNMOtqozFMs(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = 2019667431;
				while (true)
				{
					switch (num2 ^ 0x7861ADE5)
					{
					case 5:
						num2 = 2019667428;
						continue;
					case 1:
						break;
					case 0:
						P_0.RemoveAt(num);
						num2 = 2019667427;
						continue;
					case 6:
						num--;
						num2 = 2019667425;
						continue;
					case 2:
						num2 = 2019667425;
						continue;
					case 3:
						if (P_0[num] != null)
						{
							int num3;
							if (P_0[num].categoryId == P_1)
							{
								num2 = 2019667429;
								num3 = num2;
							}
							else
							{
								num2 = 2019667427;
								num3 = num2;
							}
							continue;
						}
						goto case 0;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void SYdIQSxIpEOCFKxUChBuoNPxDdAC(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_007b;
			IL_0003:
			int num = 2106351228;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x7D8C5E7F)
				{
				case 4:
					break;
				case 5:
					if (P_0[num2] != null)
					{
						goto IL_003a;
					}
					goto case 0;
				case 0:
					P_0.RemoveAt(num2);
					num = 2106351229;
					continue;
				case 3:
					return;
				case 2:
					num2--;
					num = 2106351230;
					continue;
				case 6:
					goto IL_007b;
				default:
					if (num2 < 0)
					{
						return;
					}
					goto case 5;
				}
				break;
				IL_003a:
				int num3;
				if (P_0[num2].layoutId == P_1)
				{
					num = 2106351231;
					num3 = num;
				}
				else
				{
					num = 2106351229;
					num3 = num;
				}
			}
			goto IL_0003;
			IL_007b:
			num2 = P_0.Count - 1;
			num = 2106351230;
			goto IL_0008;
		}

		[CompilerGenerated]
		private static void ZEYbEZIQfwjkUZtDcYssLNXOajIA(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = 52533257;
				while (true)
				{
					switch (num2 ^ 0x3219808)
					{
					case 0:
						num2 = 52533260;
						continue;
					case 2:
						num--;
						num2 = 52533257;
						continue;
					case 3:
						if (P_0[num] != null)
						{
							int num3;
							if (P_0[num].layoutId == P_1)
							{
								num2 = 52533261;
								num3 = num2;
							}
							else
							{
								num2 = 52533258;
								num3 = num2;
							}
							continue;
						}
						goto case 5;
					case 4:
						break;
					case 5:
						P_0.RemoveAt(num);
						num2 = 52533258;
						continue;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void jfEJqjaFgHgzygCwKuoGOsDKsjy(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0070;
			IL_0003:
			int num = 418504073;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x18F1DD8D)
				{
				case 5:
					break;
				case 4:
					return;
				case 2:
					P_0.RemoveAt(num2);
					num = 418504075;
					continue;
				case 0:
					if (P_0[num2] == null)
					{
						goto case 2;
					}
					goto IL_0050;
				case 1:
					goto IL_0070;
				case 6:
					num2--;
					num = 418504078;
					continue;
				default:
					if (num2 < 0)
					{
						return;
					}
					goto case 0;
				}
				break;
				IL_0050:
				int num3;
				if (P_0[num2].layoutId != P_1)
				{
					num = 418504075;
					num3 = num;
				}
				else
				{
					num = 418504079;
					num3 = num;
				}
			}
			goto IL_0003;
			IL_0070:
			num2 = P_0.Count - 1;
			num = 418504078;
			goto IL_0008;
		}

		[CompilerGenerated]
		private static void RHqLzXDHdBqIbukMaAydtbNHNuv(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = P_0.Count - 1;
				int num2 = -1899038251;
				while (true)
				{
					switch (num2 ^ -1899038256)
					{
					case 2:
						num2 = -1899038255;
						continue;
					case 1:
						break;
					case 3:
						P_0.RemoveAt(num);
						num2 = -1899038256;
						continue;
					case 4:
						if (P_0[num] != null)
						{
							int num3;
							if (P_0[num].layoutId != P_1)
							{
								num2 = -1899038256;
								num3 = num2;
							}
							else
							{
								num2 = -1899038253;
								num3 = num2;
							}
							continue;
						}
						goto case 3;
					case 0:
						num--;
						num2 = -1899038251;
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
