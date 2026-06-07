using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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
		private static class WquogmuBBBkNdXGeUqtASnxnLNKq
		{
			[DefaultMember("Item")]
			private class beukNuiOoMtNFZXULtVdSyJSSFaG
			{
				public enum BURnnLtJTtAlYqmPFAUVbuOfQUKk
				{
					origId = 0,
					otherId = 1,
					finalId = 2
				}

				public int nhDRbsOXfSTpICuqiwroDHwoAZJcA;

				public int siqcSXGgjDsmBJwsXxRecOOxOQjG;

				public int rvMBOHdgcSqhasACwNUMifxuVRNvA;

				public int TiVMSvMcpfXrZjnvEiBEPfGWIQxB
				{
					get
					{
						return P_0 switch
						{
							BURnnLtJTtAlYqmPFAUVbuOfQUKk.origId => nhDRbsOXfSTpICuqiwroDHwoAZJcA, 
							BURnnLtJTtAlYqmPFAUVbuOfQUKk.otherId => siqcSXGgjDsmBJwsXxRecOOxOQjG, 
							BURnnLtJTtAlYqmPFAUVbuOfQUKk.finalId => rvMBOHdgcSqhasACwNUMifxuVRNvA, 
							_ => throw new NotImplementedException(), 
						};
					}
					set
					{
						switch (bURnnLtJTtAlYqmPFAUVbuOfQUKk)
						{
						case BURnnLtJTtAlYqmPFAUVbuOfQUKk.origId:
							nhDRbsOXfSTpICuqiwroDHwoAZJcA = num;
							break;
						case BURnnLtJTtAlYqmPFAUVbuOfQUKk.otherId:
							siqcSXGgjDsmBJwsXxRecOOxOQjG = num;
							break;
						case BURnnLtJTtAlYqmPFAUVbuOfQUKk.finalId:
							rvMBOHdgcSqhasACwNUMifxuVRNvA = num;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public beukNuiOoMtNFZXULtVdSyJSSFaG(int P_0, int P_1, int P_2)
				{
					nhDRbsOXfSTpICuqiwroDHwoAZJcA = P_0;
					siqcSXGgjDsmBJwsXxRecOOxOQjG = P_1;
					rvMBOHdgcSqhasACwNUMifxuVRNvA = P_2;
				}

				public virtual string WljfqDvEZPHDDzMxLdtVlwuNYyUG()
				{
					return string.Concat(string.Concat("" + StringTools.WriteVar("origId", nhDRbsOXfSTpICuqiwroDHwoAZJcA), StringTools.WriteVar("otherId", siqcSXGgjDsmBJwsXxRecOOxOQjG)), StringTools.WriteVar("finalId", rvMBOHdgcSqhasACwNUMifxuVRNvA));
				}
			}

			private class jJztNzSTXhVHmDpnYqoUuGrIcJKO<_0001>
			{
				public _0001 QWkDtBfJwYdVwRIIMAovmagXqoSzA;

				public _0001 iBjeADkdmcFdOwnyqIFKEOlNasFE;

				public beukNuiOoMtNFZXULtVdSyJSSFaG.BURnnLtJTtAlYqmPFAUVbuOfQUKk MXxludPObokqQvZiMmLXwWmxpleI;

				public IList<_0001> gciSLeDmTlUiItEnSljjEjPhhBmr;

				public bool gSBFmTESQpqitOZdyGiuiFVKGGZUA;

				public jJztNzSTXhVHmDpnYqoUuGrIcJKO(_0001 P_0, _0001 P_1, beukNuiOoMtNFZXULtVdSyJSSFaG.BURnnLtJTtAlYqmPFAUVbuOfQUKk P_2, IList<_0001> P_3, bool P_4)
				{
					QWkDtBfJwYdVwRIIMAovmagXqoSzA = P_0;
					iBjeADkdmcFdOwnyqIFKEOlNasFE = P_1;
					MXxludPObokqQvZiMmLXwWmxpleI = P_2;
					gciSLeDmTlUiItEnSljjEjPhhBmr = P_3;
					gSBFmTESQpqitOZdyGiuiFVKGGZUA = P_4;
				}
			}

			[Serializable]
			private sealed class jtVfVXySyCNEusvAXAWzakLzcjLv
			{
				public static readonly jtVfVXySyCNEusvAXAWzakLzcjLv _003C_003E9 = new jtVfVXySyCNEusvAXAWzakLzcjLv();

				public static Func<InputActionCategory, int> _003C_003E9__0_0;

				public static Func<InputActionCategory, string> _003C_003E9__0_1;

				public static Func<InputActionCategory, IList<InputActionCategory>, int> _003C_003E9__0_2;

				public static Func<InputBehavior, int> _003C_003E9__0_4;

				public static Func<InputBehavior, string> _003C_003E9__0_5;

				public static Func<InputBehavior, IList<InputBehavior>, int> _003C_003E9__0_6;

				public static Func<InputAction, int> _003C_003E9__0_8;

				public static Func<InputAction, string> _003C_003E9__0_9;

				public static Func<InputAction, IList<InputAction>, int> _003C_003E9__0_10;

				public static Func<InputMapCategory, int> _003C_003E9__0_47;

				public static Func<InputMapCategory, string> _003C_003E9__0_48;

				public static Func<InputMapCategory, IList<InputMapCategory>, int> _003C_003E9__0_49;

				public static Func<InputLayout, int> _003C_003E9__0_12;

				public static Func<InputLayout, string> _003C_003E9__0_13;

				public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_14;

				public static Func<InputLayout, int> _003C_003E9__0_16;

				public static Func<InputLayout, string> _003C_003E9__0_17;

				public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_18;

				public static Func<InputLayout, int> _003C_003E9__0_20;

				public static Func<InputLayout, string> _003C_003E9__0_21;

				public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_22;

				public static Func<InputLayout, int> _003C_003E9__0_24;

				public static Func<InputLayout, string> _003C_003E9__0_25;

				public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_26;

				public static Func<CustomController_Editor, int> _003C_003E9__0_29;

				public static Func<CustomController_Editor, string> _003C_003E9__0_30;

				public static Func<CustomController_Editor, IList<CustomController_Editor>, int> _003C_003E9__0_31;

				public static Func<ControllerMapLayoutManager_RuleSet_Editor, int> _003C_003E9__0_33;

				public static Func<ControllerMapLayoutManager_RuleSet_Editor, string> _003C_003E9__0_34;

				public static Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> _003C_003E9__0_35;

				public static Func<ControllerMapEnabler_RuleSet_Editor, int> _003C_003E9__0_37;

				public static Func<ControllerMapEnabler_RuleSet_Editor, string> _003C_003E9__0_38;

				public static Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> _003C_003E9__0_39;

				public static Func<Player_Editor, int> _003C_003E9__0_41;

				public static Func<Player_Editor, string> _003C_003E9__0_42;

				public static Func<Player_Editor, IList<Player_Editor>, int> _003C_003E9__0_43;

				public static Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> _003C_003E9__0_64;

				public static Func<Player_Editor.CreateControllerInfo, IList<Player_Editor.CreateControllerInfo>, int> _003C_003E9__0_65;

				public static Func<ControllerMap_Editor, int> _003C_003E9__0_66;

				public static Func<ControllerMap_Editor, string> _003C_003E9__0_67;

				public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_75;

				public static Func<ControllerMap_Editor, int> _003C_003E9__0_76;

				public static Func<ControllerMap_Editor, string> _003C_003E9__0_77;

				public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_85;

				public static Func<ControllerMap_Editor, int> _003C_003E9__0_86;

				public static Func<ControllerMap_Editor, string> _003C_003E9__0_87;

				public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_95;

				public static Func<ControllerMap_Editor, int> _003C_003E9__0_96;

				public static Func<ControllerMap_Editor, string> _003C_003E9__0_97;

				public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_107;

				internal int soUQsaJKtqBAqNninTlFsjEChqiN(InputActionCategory P_0)
				{
					return P_0.id;
				}

				internal string ZVNfHamStxHnMiUAKkmAfxBaTgVc(InputActionCategory P_0)
				{
					return P_0.name;
				}

				internal int ylMrsgdmhODCEhxSGeYoFtNBUmmMA(InputActionCategory P_0, IList<InputActionCategory> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int eRmeImtcCAfyJedoIkQLkpkqqOskA(InputBehavior P_0)
				{
					return P_0.id;
				}

				internal string QvoElsBxGvuhhsjfxspIkgTlOhAA(InputBehavior P_0)
				{
					return P_0.name;
				}

				internal int JmRnoOlXweaIQwQnRxzZrzgHFMoB(InputBehavior P_0, IList<InputBehavior> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int hysaUrLKFGSYwztXspmKGcZxjwtP(InputAction P_0)
				{
					return P_0.id;
				}

				internal string YtOpqEemVBsrFTIcVTgKyFxsNFNB(InputAction P_0)
				{
					return P_0.name;
				}

				internal int XrkfJMpcncKpXZzkjInkZqyeGzVV(InputAction P_0, IList<InputAction> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int eFOKqEPXliruWzWKZOlLjTPgjnru(InputMapCategory P_0)
				{
					return P_0.id;
				}

				internal string mvEDzkyOfCpkBQxevtfsaYJJivOA(InputMapCategory P_0)
				{
					return P_0.name;
				}

				internal int nGrnyvMiOMJGKFCWYJeoyBjarSkX(InputMapCategory P_0, IList<InputMapCategory> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int VJGuWlqjLExwafUrnpGyrfUaVSNx(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string XWUIvGifrFQWHzjhRnEjkkMsvZdu(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int AHGHuBqSuRQPHbKZiCCUiRsFQgHw(InputLayout P_0, IList<InputLayout> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int xmvExzbawAxoyxRVtnZnybqQoHrl(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string dQYMnkfdJjVBgGMpWPcxHNjQFGTfA(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int RunkzESPvMBHHKptgyYacBXClEox(InputLayout P_0, IList<InputLayout> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int qsdmxTFhXaOiGMDuQauCQkrdzRXg(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string atBvBLNDiRNWWlsOVYsLICxCghUL(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int DomKPwHEzyPxMJeIUZZVFHGFAptm(InputLayout P_0, IList<InputLayout> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int IvUdZGXJVWkqyKPQHeAFEzWnrQhW(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string wVTzRDgJhsWfYzVsmojVEbxqQmXO(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int yKsSAVQWQWcpeFhfUriHzWzSSRBk(InputLayout P_0, IList<InputLayout> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int iOHDbvdASKlVaysnwAERFDtFKWStA(CustomController_Editor P_0)
				{
					return P_0.id;
				}

				internal string xQXmeDblXbBGsMbjdDaaztpqAbtCA(CustomController_Editor P_0)
				{
					return P_0.name;
				}

				internal int wAlzSSMnIitkEfwajHsFBACqKybG(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int XxCRnDgLVlqBWTCsvSvWnfyaBPXE(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string zOOgkbKsuBPopJcyLqfDdmvXBeeeb(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int PLZYQAkHDKtdzjOHMDWJEKLxFCgBb(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int GQHiLREfHmuzooaOklTBwQtnFhVgA(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string sYvCeUDNCJOZwCkLZIDsPexXpqTCb(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int bLOSRkfpBeyWpjJvYCnrcrUwJSOO(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int tdXBtUHKGhVZIczYUjZDtpeMuhJ(Player_Editor P_0)
				{
					return P_0.id;
				}

				internal string PBsEMGJmadmTnRWcAfeYJgQbbkJq(Player_Editor P_0)
				{
					return P_0.name;
				}

				internal int QtXmliazRbNfNtEzUjTqyqfTDcPDA(Player_Editor P_0, IList<Player_Editor> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				internal int MxnoUsmSaZJpLgBzpNvAvFWGcKRu(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i].categoryId == P_0.categoryId && P_1[i].layoutId == P_0.layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal int pGMxonTXhQACdxjlLoWVhvFXLMzx(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i].sourceId == P_0.sourceId)
						{
							return i;
						}
					}
					return -1;
				}

				internal int TifFwpiUACqaOCuHCrmXwDaTgaeJc(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string vPmeWKplsMkBeBtycRdrMwZbmRiM(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int nFfJTQuqgKQkDkFuUGdvejRNOXhAb(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._keyboardKeyCode == P_0._keyboardKeyCode && P_1[i]._modifierKey1 == P_0._modifierKey1 && P_1[i]._modifierKey2 == P_0._modifierKey2 && P_1[i]._modifierKey3 == P_0._modifierKey3 && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}

				internal int fFAuiDZVpDxjrMTEkQZvgLoSrReX(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string CpqETqmLsrZLxQCWBTQYutPAnDxK(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int uXaoBIVMoqwoIiKIErHbSqhaDJlz(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}

				internal int tiSFjcDZMMKvWFZAWwDKSwMDxhwIA(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string gDoYpbdkvtELJFpGkBLFKtvtwrLHA(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int PJXdqDJmaQOfvcVAeUtPdzFEUjcdE(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}

				internal int MsUEKQZdljAMjaZBsPfdZYZWAZyr(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string aGqPYksMSNPUbGFoNWTnKrviHKOk(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int PhkUzdQCNRAdNEtEdJhHEThKrdeAc(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					for (int i = 0; i < P_1.Count; i++)
					{
						if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
						{
							return i;
						}
					}
					return -1;
				}
			}

			private sealed class ifVDRDNRlQIrefGUREftbZZhpiIyA
			{
				public UserData YRXeVoHSlVhzOtaQIifrpSNOPtnyA;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> eSORCJPckUozOacQerIHdpdHrREY;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> GMUoAeNBomHSMkccaEPZPsaxeqEgA;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> VTsuIoaDpNVgRaffGvaABsLabnxy;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> qMuErAhjkHhLjaywDIYFOZVXIODec;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> uOSQCpDANjSrGhIxvSYdqbSckCQe;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> SiijEtKCRPeMVGATPRUUQocdrkQI;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> fgivMcCczvWCIHMgDBmehdkCQusCA;

				public Func<ControllerType, List<beukNuiOoMtNFZXULtVdSyJSSFaG>> HeqCbzDnDFYyCBQWoqXKDpxYBwcW;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> UwSvdwbWBHVZtqqunbXVHkYhUtOH;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> kgRtGkgAOMThAXdYuERFQyHbgVoF;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> QdMByZaeLskgyPbFnFnctALHeRTEb;

				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> HwGqJUzgajaHWazbfvTNxckLfSaB;

				internal InputActionCategory ducjzrkyPACjZyeoTHTvJgUJzKSN(jJztNzSTXhVHmDpnYqoUuGrIcJKO<InputActionCategory> P_0)
				{
					InputActionCategory inputActionCategory = JsonTools.Clone(P_0.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					InputActionCategory inputActionCategory2;
					if (P_0.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						inputActionCategory2 = P_0.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddActionCategory();
						inputActionCategory2 = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					inputActionCategory.id = inputActionCategory2.id;
					int index = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(inputActionCategory2);
					P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = inputActionCategory;
					return inputActionCategory;
				}

				internal InputBehavior pafuAwJewjamjcXEluFqAEWHkznNA(jJztNzSTXhVHmDpnYqoUuGrIcJKO<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					InputBehavior inputBehavior2;
					if (P_0.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						inputBehavior2 = P_0.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddInputBehavior();
						inputBehavior2 = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(inputBehavior2);
					P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = inputBehavior;
					return inputBehavior;
				}

				internal InputAction WdCdsqSYdHMzKIpZsIZXmNOmfLLf(jJztNzSTXhVHmDpnYqoUuGrIcJKO<InputAction> P_0)
				{
					IjMPnesnEvCyPZWdZUzcNhrLTdnl ijMPnesnEvCyPZWdZUzcNhrLTdnl = new IjMPnesnEvCyPZWdZUzcNhrLTdnl();
					ijMPnesnEvCyPZWdZUzcNhrLTdnl.PtzeMlfNbqwjLGsFQNTEizKOBOvVA = P_0;
					InputAction inputAction = JsonTools.Clone(ijMPnesnEvCyPZWdZUzcNhrLTdnl.PtzeMlfNbqwjLGsFQNTEizKOBOvVA.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					int num = eSORCJPckUozOacQerIHdpdHrREY.Find(ijMPnesnEvCyPZWdZUzcNhrLTdnl.kynXbyOExvPASBzzzKBRLSrwpulB)?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? 0;
					InputAction inputAction2;
					if (ijMPnesnEvCyPZWdZUzcNhrLTdnl.PtzeMlfNbqwjLGsFQNTEizKOBOvVA.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						inputAction2 = ijMPnesnEvCyPZWdZUzcNhrLTdnl.PtzeMlfNbqwjLGsFQNTEizKOBOvVA.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddAction(num);
						inputAction2 = ijMPnesnEvCyPZWdZUzcNhrLTdnl.PtzeMlfNbqwjLGsFQNTEizKOBOvVA.gciSLeDmTlUiItEnSljjEjPhhBmr[ijMPnesnEvCyPZWdZUzcNhrLTdnl.PtzeMlfNbqwjLGsFQNTEizKOBOvVA.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					int num2 = GMUoAeNBomHSMkccaEPZPsaxeqEgA.Find(ijMPnesnEvCyPZWdZUzcNhrLTdnl.XKJehAofIqPxZYAAGTTuniTtsPBL)?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = num2;
					int index = ijMPnesnEvCyPZWdZUzcNhrLTdnl.PtzeMlfNbqwjLGsFQNTEizKOBOvVA.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(inputAction2);
					ijMPnesnEvCyPZWdZUzcNhrLTdnl.PtzeMlfNbqwjLGsFQNTEizKOBOvVA.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = inputAction;
					return inputAction;
				}

				internal InputLayout bzKamscIsfMUjERHhXQZiHRiEJEXb(jJztNzSTXhVHmDpnYqoUuGrIcJKO<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					InputLayout inputLayout2;
					if (P_0.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						inputLayout2 = P_0.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddKeyboardLayout();
						inputLayout2 = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(inputLayout2);
					P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout TUpHiRwCiwJMhiPXmPzvSJMMXeDk(jJztNzSTXhVHmDpnYqoUuGrIcJKO<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					InputLayout inputLayout2;
					if (P_0.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						inputLayout2 = P_0.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddMouseLayout();
						inputLayout2 = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(inputLayout2);
					P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout ZTJDOentuYINiRSOaMGMlOAHglwE(jJztNzSTXhVHmDpnYqoUuGrIcJKO<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					InputLayout inputLayout2;
					if (P_0.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						inputLayout2 = P_0.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddJoystickLayout();
						inputLayout2 = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(inputLayout2);
					P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout fXGNyaRbujgPkskhQQhBlnkRIJWbA(jJztNzSTXhVHmDpnYqoUuGrIcJKO<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					InputLayout inputLayout2;
					if (P_0.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						inputLayout2 = P_0.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddCustomControllerLayout();
						inputLayout2 = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(inputLayout2);
					P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = inputLayout;
					return inputLayout;
				}

				internal List<beukNuiOoMtNFZXULtVdSyJSSFaG> rBTxeffckgSgOgDfabyoqEMOEZts(ControllerType P_0)
				{
					return P_0 switch
					{
						ControllerType.Keyboard => VTsuIoaDpNVgRaffGvaABsLabnxy, 
						ControllerType.Mouse => qMuErAhjkHhLjaywDIYFOZVXIODec, 
						ControllerType.Joystick => uOSQCpDANjSrGhIxvSYdqbSckCQe, 
						ControllerType.Custom => SiijEtKCRPeMVGATPRUUQocdrkQI, 
						_ => throw new NotImplementedException(), 
					};
				}

				internal CustomController_Editor zqxxBPCvckgAavWOwyLeSTivmbVA(jJztNzSTXhVHmDpnYqoUuGrIcJKO<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					CustomController_Editor customController_Editor2;
					if (P_0.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						customController_Editor2 = P_0.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddCustomController(Guid.Empty);
						customController_Editor2 = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(customController_Editor2);
					P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = customController_Editor;
					return customController_Editor;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor lUMixqGTftqCXJDpISbIKhIlMdJx(jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					nVAnErJCAHqUsXqlThgXjyooJRJU nVAnErJCAHqUsXqlThgXjyooJRJU2 = new nVAnErJCAHqUsXqlThgXjyooJRJU();
					nVAnErJCAHqUsXqlThgXjyooJRJU2.nSUcJCqrNtnsCIjkQQkmKeqRVcXj = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(nVAnErJCAHqUsXqlThgXjyooJRJU2.nSUcJCqrNtnsCIjkQQkmKeqRVcXj.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					int num = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int i = 0; i < num; i++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor = controllerMapLayoutManager_RuleSet_Editor.rules[i];
						if (controllerMapLayoutManager_Rule_Editor == null || controllerMapLayoutManager_Rule_Editor.categoryIds == null)
						{
							continue;
						}
						List<int> list = new List<int>();
						int num2 = ((controllerMapLayoutManager_Rule_Editor.categoryIds != null) ? controllerMapLayoutManager_Rule_Editor.categoryIds.Count : 0);
						for (int j = 0; j < num2; j++)
						{
							IvOOkAXylTcRFntOrydYTZvpQgMA ivOOkAXylTcRFntOrydYTZvpQgMA = new IvOOkAXylTcRFntOrydYTZvpQgMA();
							ivOOkAXylTcRFntOrydYTZvpQgMA.SrrExCaXblQjgKydhnpvmfITIzwJA = nVAnErJCAHqUsXqlThgXjyooJRJU2;
							ivOOkAXylTcRFntOrydYTZvpQgMA.qxyfcHiqRswIojmtxBpDVZsuEtFr = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = fgivMcCczvWCIHMgDBmehdkCQusCA.Find(ivOOkAXylTcRFntOrydYTZvpQgMA.uJSAPeRZiCjulEJmeSVDIzJIdTPK);
							if (beukNuiOoMtNFZXULtVdSyJSSFaG2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + ivOOkAXylTcRFntOrydYTZvpQgMA.qxyfcHiqRswIojmtxBpDVZsuEtFr);
							}
							else
							{
								list.Add(beukNuiOoMtNFZXULtVdSyJSSFaG2.rvMBOHdgcSqhasACwNUMifxuVRNvA);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						grlCdQbmaGnYPOFvHhAMFPSUyqdBA grlCdQbmaGnYPOFvHhAMFPSUyqdBA2 = new grlCdQbmaGnYPOFvHhAMFPSUyqdBA();
						grlCdQbmaGnYPOFvHhAMFPSUyqdBA2.zrHfsBBrwHHgZDjdedyNIelswIlDc = nVAnErJCAHqUsXqlThgXjyooJRJU2;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<beukNuiOoMtNFZXULtVdSyJSSFaG> list2 = HeqCbzDnDFYyCBQWoqXKDpxYBwcW(controllerType);
							grlCdQbmaGnYPOFvHhAMFPSUyqdBA2.ubUXhibKIYybmWUiREJpWkmzVAut = controllerMapLayoutManager_Rule_Editor2.layoutId;
							beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = list2.Find(grlCdQbmaGnYPOFvHhAMFPSUyqdBA2.PXmbAuhgXqQBcjETvbLUESbsObxcA);
							if (beukNuiOoMtNFZXULtVdSyJSSFaG3 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + grlCdQbmaGnYPOFvHhAMFPSUyqdBA2.ubUXhibKIYybmWUiREJpWkmzVAut);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = beukNuiOoMtNFZXULtVdSyJSSFaG3.rvMBOHdgcSqhasACwNUMifxuVRNvA;
							}
						}
					}
					int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							lIqmGMsdfgiLXIIRwJdiDNgLqfSw lIqmGMsdfgiLXIIRwJdiDNgLqfSw2 = new lIqmGMsdfgiLXIIRwJdiDNgLqfSw();
							lIqmGMsdfgiLXIIRwJdiDNgLqfSw2.rrNvbPknTlDwJiwHloQaZVpxtldl = nVAnErJCAHqUsXqlThgXjyooJRJU2;
							List<beukNuiOoMtNFZXULtVdSyJSSFaG> uwSvdwbWBHVZtqqunbXVHkYhUtOH = UwSvdwbWBHVZtqqunbXVHkYhUtOH;
							lIqmGMsdfgiLXIIRwJdiDNgLqfSw2.DiiPgXUxlulMdJQJtgKLyPHBeHwf = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG4 = uwSvdwbWBHVZtqqunbXVHkYhUtOH.Find(lIqmGMsdfgiLXIIRwJdiDNgLqfSw2.ayycSxFlDETEZHWbnmhnSjEvHTYz);
							if (beukNuiOoMtNFZXULtVdSyJSSFaG4 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + lIqmGMsdfgiLXIIRwJdiDNgLqfSw2.DiiPgXUxlulMdJQJtgKLyPHBeHwf);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = beukNuiOoMtNFZXULtVdSyJSSFaG4.rvMBOHdgcSqhasACwNUMifxuVRNvA;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (nVAnErJCAHqUsXqlThgXjyooJRJU2.nSUcJCqrNtnsCIjkQQkmKeqRVcXj.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = nVAnErJCAHqUsXqlThgXjyooJRJU2.nSUcJCqrNtnsCIjkQQkmKeqRVcXj.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = nVAnErJCAHqUsXqlThgXjyooJRJU2.nSUcJCqrNtnsCIjkQQkmKeqRVcXj.gciSLeDmTlUiItEnSljjEjPhhBmr[nVAnErJCAHqUsXqlThgXjyooJRJU2.nSUcJCqrNtnsCIjkQQkmKeqRVcXj.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = nVAnErJCAHqUsXqlThgXjyooJRJU2.nSUcJCqrNtnsCIjkQQkmKeqRVcXj.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					nVAnErJCAHqUsXqlThgXjyooJRJU2.nSUcJCqrNtnsCIjkQQkmKeqRVcXj.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				internal ControllerMapEnabler_RuleSet_Editor PEVDeQAOmzhODejeiXSdTzfBCEgFc(jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					aimYqlTLvUbCLlPBoiGihiJVbhqw aimYqlTLvUbCLlPBoiGihiJVbhqw2 = new aimYqlTLvUbCLlPBoiGihiJVbhqw();
					aimYqlTLvUbCLlPBoiGihiJVbhqw2.FxEeGvmXbfLWJHtrudmHFsThuVpk = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(aimYqlTLvUbCLlPBoiGihiJVbhqw2.FxEeGvmXbfLWJHtrudmHFsThuVpk.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					int num = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
					for (int i = 0; i < num; i++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor = controllerMapEnabler_RuleSet_Editor.rules[i];
						if (controllerMapEnabler_Rule_Editor == null || controllerMapEnabler_Rule_Editor.categoryIds == null)
						{
							continue;
						}
						List<int> list = new List<int>();
						for (int j = 0; j < controllerMapEnabler_Rule_Editor.categoryIds.Count; j++)
						{
							QUtHLHOGWgWoMkPmEbwIbGlSwtkc qUtHLHOGWgWoMkPmEbwIbGlSwtkc = new QUtHLHOGWgWoMkPmEbwIbGlSwtkc();
							qUtHLHOGWgWoMkPmEbwIbGlSwtkc.dAJwBUjGcAcJYDrfjptuqXeFCGzfb = aimYqlTLvUbCLlPBoiGihiJVbhqw2;
							qUtHLHOGWgWoMkPmEbwIbGlSwtkc.YcyNSNHgzQpKJdnEuvhcGIWsYAMk = controllerMapEnabler_Rule_Editor.categoryIds[j];
							beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = fgivMcCczvWCIHMgDBmehdkCQusCA.Find(qUtHLHOGWgWoMkPmEbwIbGlSwtkc.eufQTUzlStaVLEbwFogIeopdNZlXA);
							if (beukNuiOoMtNFZXULtVdSyJSSFaG2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + qUtHLHOGWgWoMkPmEbwIbGlSwtkc.YcyNSNHgzQpKJdnEuvhcGIWsYAMk);
							}
							else
							{
								list.Add(beukNuiOoMtNFZXULtVdSyJSSFaG2.rvMBOHdgcSqhasACwNUMifxuVRNvA);
							}
						}
						controllerMapEnabler_Rule_Editor.categoryIds = list;
					}
					int num2 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num2; k++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor2 = controllerMapEnabler_RuleSet_Editor.rules[k];
						if (controllerMapEnabler_Rule_Editor2 == null || controllerMapEnabler_Rule_Editor2.layoutIds == null)
						{
							continue;
						}
						ControllerType controllerType = controllerMapEnabler_Rule_Editor2.controllerSetSelector.controllerType;
						List<beukNuiOoMtNFZXULtVdSyJSSFaG> list2 = HeqCbzDnDFYyCBQWoqXKDpxYBwcW(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							cgOJOsXjHwVOgnzOinnyFnnurHdL cgOJOsXjHwVOgnzOinnyFnnurHdL2 = new cgOJOsXjHwVOgnzOinnyFnnurHdL();
							cgOJOsXjHwVOgnzOinnyFnnurHdL2.eRZKAuJySrnieAflAMeiGjMzwRen = aimYqlTLvUbCLlPBoiGihiJVbhqw2;
							cgOJOsXjHwVOgnzOinnyFnnurHdL2.bawmIivjXwtLCRfdYDVJGuwdFwZL = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = list2.Find(cgOJOsXjHwVOgnzOinnyFnnurHdL2.GMLapNAiBUprhPOZpNyNrIBWtWlz);
							if (beukNuiOoMtNFZXULtVdSyJSSFaG3 == null)
							{
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + cgOJOsXjHwVOgnzOinnyFnnurHdL2.bawmIivjXwtLCRfdYDVJGuwdFwZL);
							}
							else
							{
								list3.Add(beukNuiOoMtNFZXULtVdSyJSSFaG3.rvMBOHdgcSqhasACwNUMifxuVRNvA);
							}
						}
						controllerMapEnabler_Rule_Editor2.layoutIds = list3;
					}
					int num4 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
					for (int m = 0; m < num4; m++)
					{
						ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor3 = controllerMapEnabler_RuleSet_Editor.rules[m];
						if (controllerMapEnabler_Rule_Editor3 != null && controllerMapEnabler_Rule_Editor3.controllerSetSelector != null && controllerMapEnabler_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							rPvUGFFQIGsHeTvLwoxouuHthPFy rPvUGFFQIGsHeTvLwoxouuHthPFy2 = new rPvUGFFQIGsHeTvLwoxouuHthPFy();
							rPvUGFFQIGsHeTvLwoxouuHthPFy2.OEcHogRcAUyfnzkxtAupxhYEFHWw = aimYqlTLvUbCLlPBoiGihiJVbhqw2;
							List<beukNuiOoMtNFZXULtVdSyJSSFaG> uwSvdwbWBHVZtqqunbXVHkYhUtOH = UwSvdwbWBHVZtqqunbXVHkYhUtOH;
							rPvUGFFQIGsHeTvLwoxouuHthPFy2.ZbcofYpXJNrvcnRWvHoAfptZWfRR = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG4 = uwSvdwbWBHVZtqqunbXVHkYhUtOH.Find(rPvUGFFQIGsHeTvLwoxouuHthPFy2.dWXronJfYDXsVeFefeiSBJjisQCKA);
							if (beukNuiOoMtNFZXULtVdSyJSSFaG4 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + rPvUGFFQIGsHeTvLwoxouuHthPFy2.ZbcofYpXJNrvcnRWvHoAfptZWfRR);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = beukNuiOoMtNFZXULtVdSyJSSFaG4.rvMBOHdgcSqhasACwNUMifxuVRNvA;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (aimYqlTLvUbCLlPBoiGihiJVbhqw2.FxEeGvmXbfLWJHtrudmHFsThuVpk.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						controllerMapEnabler_RuleSet_Editor2 = aimYqlTLvUbCLlPBoiGihiJVbhqw2.FxEeGvmXbfLWJHtrudmHFsThuVpk.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = aimYqlTLvUbCLlPBoiGihiJVbhqw2.FxEeGvmXbfLWJHtrudmHFsThuVpk.gciSLeDmTlUiItEnSljjEjPhhBmr[aimYqlTLvUbCLlPBoiGihiJVbhqw2.FxEeGvmXbfLWJHtrudmHFsThuVpk.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = aimYqlTLvUbCLlPBoiGihiJVbhqw2.FxEeGvmXbfLWJHtrudmHFsThuVpk.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					aimYqlTLvUbCLlPBoiGihiJVbhqw2.FxEeGvmXbfLWJHtrudmHFsThuVpk.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				internal Player_Editor aSMHbwlSqlVAUIAVICIaPpKoDwQT(jJztNzSTXhVHmDpnYqoUuGrIcJKO<Player_Editor> P_0)
				{
					DXUgWCItmQAvofqMiSOlTMTqTuXnA dXUgWCItmQAvofqMiSOlTMTqTuXnA = new DXUgWCItmQAvofqMiSOlTMTqTuXnA();
					dXUgWCItmQAvofqMiSOlTMTqTuXnA.DeKileBpXyWDyIrFSOVtSnBhdnEEb = this;
					dXUgWCItmQAvofqMiSOlTMTqTuXnA.zNdeIFHqUOgHEOCQVvUHKphtoHPE = P_0;
					Player_Editor player_Editor = JsonTools.Clone(dXUgWCItmQAvofqMiSOlTMTqTuXnA.zNdeIFHqUOgHEOCQVvUHKphtoHPE.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					Action<List<Player_Editor.Mapping>, List<beukNuiOoMtNFZXULtVdSyJSSFaG>> action = dXUgWCItmQAvofqMiSOlTMTqTuXnA.lbGgHujWIbbjlDEgwecDYunEiQUXA;
					action(player_Editor.defaultKeyboardMaps, VTsuIoaDpNVgRaffGvaABsLabnxy);
					action(player_Editor.defaultMouseMaps, qMuErAhjkHhLjaywDIYFOZVXIODec);
					action(player_Editor.defaultJoystickMaps, uOSQCpDANjSrGhIxvSYdqbSckCQe);
					action(player_Editor.defaultCustomControllerMaps, SiijEtKCRPeMVGATPRUUQocdrkQI);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						qGnIKloLeAWrdHGIeHddYoyokjmR qGnIKloLeAWrdHGIeHddYoyokjmR2 = new qGnIKloLeAWrdHGIeHddYoyokjmR();
						qGnIKloLeAWrdHGIeHddYoyokjmR2.PICJbToPtLknSXWlfULjWFPysRJR = dXUgWCItmQAvofqMiSOlTMTqTuXnA;
						qGnIKloLeAWrdHGIeHddYoyokjmR2.AhcDSccwSjEgTazQGdHdEuwUcEtIb = player_Editor.startingCustomControllers[i];
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = UwSvdwbWBHVZtqqunbXVHkYhUtOH.Find(qGnIKloLeAWrdHGIeHddYoyokjmR2.TJfDmprGGDfPLmXyYbsKWlXMiVxG);
						qGnIKloLeAWrdHGIeHddYoyokjmR2.AhcDSccwSjEgTazQGdHdEuwUcEtIb.sourceId = beukNuiOoMtNFZXULtVdSyJSSFaG2?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						iTmUPdDsREoGhqHNeQuyWehqGEWg iTmUPdDsREoGhqHNeQuyWehqGEWg2 = new iTmUPdDsREoGhqHNeQuyWehqGEWg();
						iTmUPdDsREoGhqHNeQuyWehqGEWg2.hkyVMIInsCdZGMLtGCCROupMPjpv = dXUgWCItmQAvofqMiSOlTMTqTuXnA;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							iTmUPdDsREoGhqHNeQuyWehqGEWg2.ObwCwjgWweTWXimUqEJRrsghiEkjb = ruleSetMapping.id;
							beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = kgRtGkgAOMThAXdYuERFQyHbgVoF.Find(iTmUPdDsREoGhqHNeQuyWehqGEWg2.oFmNnXbJoliiGFJdViWnXQyQXJuR);
							if (beukNuiOoMtNFZXULtVdSyJSSFaG3 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + iTmUPdDsREoGhqHNeQuyWehqGEWg2.ObwCwjgWweTWXimUqEJRrsghiEkjb);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = beukNuiOoMtNFZXULtVdSyJSSFaG3.rvMBOHdgcSqhasACwNUMifxuVRNvA;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						rFXXPVeADFjSTWGCjVbaoJeRYiMX rFXXPVeADFjSTWGCjVbaoJeRYiMX2 = new rFXXPVeADFjSTWGCjVbaoJeRYiMX();
						rFXXPVeADFjSTWGCjVbaoJeRYiMX2.AcjsbFmappBPWekIsFtYGZuBQUYGA = dXUgWCItmQAvofqMiSOlTMTqTuXnA;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							rFXXPVeADFjSTWGCjVbaoJeRYiMX2.LRSdCuDipEpgaoPXnkneSFMHskdEA = ruleSetMapping2.id;
							beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG4 = QdMByZaeLskgyPbFnFnctALHeRTEb.Find(rFXXPVeADFjSTWGCjVbaoJeRYiMX2.wAHjZKyuECiEPXoGXIdaHzhHgoCe);
							if (beukNuiOoMtNFZXULtVdSyJSSFaG4 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + rFXXPVeADFjSTWGCjVbaoJeRYiMX2.LRSdCuDipEpgaoPXnkneSFMHskdEA);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = beukNuiOoMtNFZXULtVdSyJSSFaG4.rvMBOHdgcSqhasACwNUMifxuVRNvA;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (dXUgWCItmQAvofqMiSOlTMTqTuXnA.zNdeIFHqUOgHEOCQVvUHKphtoHPE.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						player_Editor2 = dXUgWCItmQAvofqMiSOlTMTqTuXnA.zNdeIFHqUOgHEOCQVvUHKphtoHPE.iBjeADkdmcFdOwnyqIFKEOlNasFE;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.MxnoUsmSaZJpLgBzpNvAvFWGcKRu;
						lrzABLdfLqzrAbmIOApLBnEusyMD(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						lrzABLdfLqzrAbmIOApLBnEusyMD(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						lrzABLdfLqzrAbmIOApLBnEusyMD(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						lrzABLdfLqzrAbmIOApLBnEusyMD(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						lrzABLdfLqzrAbmIOApLBnEusyMD(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.pGMxonTXhQACdxjlLoWVhvFXLMzx);
						player_Editor = player_Editor3;
					}
					else
					{
						YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddPlayer();
						player_Editor2 = dXUgWCItmQAvofqMiSOlTMTqTuXnA.zNdeIFHqUOgHEOCQVvUHKphtoHPE.gciSLeDmTlUiItEnSljjEjPhhBmr[dXUgWCItmQAvofqMiSOlTMTqTuXnA.zNdeIFHqUOgHEOCQVvUHKphtoHPE.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = dXUgWCItmQAvofqMiSOlTMTqTuXnA.zNdeIFHqUOgHEOCQVvUHKphtoHPE.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(player_Editor2);
					dXUgWCItmQAvofqMiSOlTMTqTuXnA.zNdeIFHqUOgHEOCQVvUHKphtoHPE.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = player_Editor;
					return player_Editor;
				}
			}

			private sealed class IjMPnesnEvCyPZWdZUzcNhrLTdnl
			{
				public jJztNzSTXhVHmDpnYqoUuGrIcJKO<InputAction> PtzeMlfNbqwjLGsFQNTEizKOBOvVA;

				internal bool kynXbyOExvPASBzzzKBRLSrwpulB(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(PtzeMlfNbqwjLGsFQNTEizKOBOvVA.MXxludPObokqQvZiMmLXwWmxpleI) == PtzeMlfNbqwjLGsFQNTEizKOBOvVA.QWkDtBfJwYdVwRIIMAovmagXqoSzA.categoryId;
				}

				internal bool XKJehAofIqPxZYAAGTTuniTtsPBL(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(PtzeMlfNbqwjLGsFQNTEizKOBOvVA.MXxludPObokqQvZiMmLXwWmxpleI) == PtzeMlfNbqwjLGsFQNTEizKOBOvVA.QWkDtBfJwYdVwRIIMAovmagXqoSzA.behaviorId;
				}
			}

			private sealed class cgOJOsXjHwVOgnzOinnyFnnurHdL
			{
				public int bawmIivjXwtLCRfdYDVJGuwdFwZL;

				public aimYqlTLvUbCLlPBoiGihiJVbhqw eRZKAuJySrnieAflAMeiGjMzwRen;

				internal bool GMLapNAiBUprhPOZpNyNrIBWtWlz(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(eRZKAuJySrnieAflAMeiGjMzwRen.FxEeGvmXbfLWJHtrudmHFsThuVpk.MXxludPObokqQvZiMmLXwWmxpleI) == bawmIivjXwtLCRfdYDVJGuwdFwZL;
				}
			}

			private sealed class rPvUGFFQIGsHeTvLwoxouuHthPFy
			{
				public int ZbcofYpXJNrvcnRWvHoAfptZWfRR;

				public aimYqlTLvUbCLlPBoiGihiJVbhqw OEcHogRcAUyfnzkxtAupxhYEFHWw;

				internal bool dWXronJfYDXsVeFefeiSBJjisQCKA(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(OEcHogRcAUyfnzkxtAupxhYEFHWw.FxEeGvmXbfLWJHtrudmHFsThuVpk.MXxludPObokqQvZiMmLXwWmxpleI) == ZbcofYpXJNrvcnRWvHoAfptZWfRR;
				}
			}

			private sealed class DXUgWCItmQAvofqMiSOlTMTqTuXnA
			{
				public jJztNzSTXhVHmDpnYqoUuGrIcJKO<Player_Editor> zNdeIFHqUOgHEOCQVvUHKphtoHPE;

				public ifVDRDNRlQIrefGUREftbZZhpiIyA DeKileBpXyWDyIrFSOVtSnBhdnEEb;

				internal void lbGgHujWIbbjlDEgwecDYunEiQUXA(List<Player_Editor.Mapping> P_0, List<beukNuiOoMtNFZXULtVdSyJSSFaG> P_1)
				{
					for (int i = 0; i < P_0.Count; i++)
					{
						IuSrzrlXqXBQCiZREYNXopXtFDZc iuSrzrlXqXBQCiZREYNXopXtFDZc = new IuSrzrlXqXBQCiZREYNXopXtFDZc();
						iuSrzrlXqXBQCiZREYNXopXtFDZc.GZQQkZVXBCEXpJiJTEvlErVuLvAL = this;
						iuSrzrlXqXBQCiZREYNXopXtFDZc.SXLCuGbGUYAGTjvGIgYDSRwwnSCo = P_0[i];
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = DeKileBpXyWDyIrFSOVtSnBhdnEEb.fgivMcCczvWCIHMgDBmehdkCQusCA.Find(iuSrzrlXqXBQCiZREYNXopXtFDZc.RynCfBeWlbqVXHAURwPnpbwNZeZd);
						iuSrzrlXqXBQCiZREYNXopXtFDZc.SXLCuGbGUYAGTjvGIgYDSRwwnSCo.categoryId = beukNuiOoMtNFZXULtVdSyJSSFaG2?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
						beukNuiOoMtNFZXULtVdSyJSSFaG2 = P_1.Find(iuSrzrlXqXBQCiZREYNXopXtFDZc.JUogULZwelNaDqVQcaXOvaaMNDLx);
						iuSrzrlXqXBQCiZREYNXopXtFDZc.SXLCuGbGUYAGTjvGIgYDSRwwnSCo.layoutId = beukNuiOoMtNFZXULtVdSyJSSFaG2?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					}
				}
			}

			private sealed class IuSrzrlXqXBQCiZREYNXopXtFDZc
			{
				public Player_Editor.Mapping SXLCuGbGUYAGTjvGIgYDSRwwnSCo;

				public DXUgWCItmQAvofqMiSOlTMTqTuXnA GZQQkZVXBCEXpJiJTEvlErVuLvAL;

				internal bool RynCfBeWlbqVXHAURwPnpbwNZeZd(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(GZQQkZVXBCEXpJiJTEvlErVuLvAL.zNdeIFHqUOgHEOCQVvUHKphtoHPE.MXxludPObokqQvZiMmLXwWmxpleI) == SXLCuGbGUYAGTjvGIgYDSRwwnSCo.categoryId;
				}

				internal bool JUogULZwelNaDqVQcaXOvaaMNDLx(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(GZQQkZVXBCEXpJiJTEvlErVuLvAL.zNdeIFHqUOgHEOCQVvUHKphtoHPE.MXxludPObokqQvZiMmLXwWmxpleI) == SXLCuGbGUYAGTjvGIgYDSRwwnSCo.layoutId;
				}
			}

			private sealed class qGnIKloLeAWrdHGIeHddYoyokjmR
			{
				public Player_Editor.CreateControllerInfo AhcDSccwSjEgTazQGdHdEuwUcEtIb;

				public DXUgWCItmQAvofqMiSOlTMTqTuXnA PICJbToPtLknSXWlfULjWFPysRJR;

				internal bool TJfDmprGGDfPLmXyYbsKWlXMiVxG(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(PICJbToPtLknSXWlfULjWFPysRJR.zNdeIFHqUOgHEOCQVvUHKphtoHPE.MXxludPObokqQvZiMmLXwWmxpleI) == AhcDSccwSjEgTazQGdHdEuwUcEtIb.sourceId;
				}
			}

			private sealed class iTmUPdDsREoGhqHNeQuyWehqGEWg
			{
				public int ObwCwjgWweTWXimUqEJRrsghiEkjb;

				public DXUgWCItmQAvofqMiSOlTMTqTuXnA hkyVMIInsCdZGMLtGCCROupMPjpv;

				internal bool oFmNnXbJoliiGFJdViWnXQyQXJuR(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(hkyVMIInsCdZGMLtGCCROupMPjpv.zNdeIFHqUOgHEOCQVvUHKphtoHPE.MXxludPObokqQvZiMmLXwWmxpleI) == ObwCwjgWweTWXimUqEJRrsghiEkjb;
				}
			}

			private sealed class rFXXPVeADFjSTWGCjVbaoJeRYiMX
			{
				public int LRSdCuDipEpgaoPXnkneSFMHskdEA;

				public DXUgWCItmQAvofqMiSOlTMTqTuXnA AcjsbFmappBPWekIsFtYGZuBQUYGA;

				internal bool wAHjZKyuECiEPXoGXIdaHzhHgoCe(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(AcjsbFmappBPWekIsFtYGZuBQUYGA.zNdeIFHqUOgHEOCQVvUHKphtoHPE.MXxludPObokqQvZiMmLXwWmxpleI) == LRSdCuDipEpgaoPXnkneSFMHskdEA;
				}
			}

			private sealed class KrRrPpCdAXaXpuhQWvgEhYSBYplf
			{
				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> PRzjaXnkGIFbtcWHBZEhPtkxqndN;

				public ifVDRDNRlQIrefGUREftbZZhpiIyA OVTnteWlBmEvHpCjXRjOXpaDxaKk;

				internal int jIjdxGJtJcabTAHgHmTQXTuNdzwx(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					dmWEHjdSKtoihTAILhXSSGIhgacP dmWEHjdSKtoihTAILhXSSGIhgacP2 = new dmWEHjdSKtoihTAILhXSSGIhgacP();
					dmWEHjdSKtoihTAILhXSSGIhgacP2.zXuivzRQnHeDYeVIzUSkmejOCnPQ = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = OVTnteWlBmEvHpCjXRjOXpaDxaKk.fgivMcCczvWCIHMgDBmehdkCQusCA.Find(dmWEHjdSKtoihTAILhXSSGIhgacP2.YHpbLZVIheRvNEofrqYiRxiNTJXr);
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = PRzjaXnkGIFbtcWHBZEhPtkxqndN.Find(dmWEHjdSKtoihTAILhXSSGIhgacP2.YovAfktXEqnHqHgPXsohLqzhPJSq);
						if (beukNuiOoMtNFZXULtVdSyJSSFaG2 != null && beukNuiOoMtNFZXULtVdSyJSSFaG2.rvMBOHdgcSqhasACwNUMifxuVRNvA == P_1[i].categoryId && beukNuiOoMtNFZXULtVdSyJSSFaG3 != null && beukNuiOoMtNFZXULtVdSyJSSFaG3.rvMBOHdgcSqhasACwNUMifxuVRNvA == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor ntPPIbgkbArIvjcNEPvVQkVYCRXy(jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMap_Editor> P_0)
				{
					CqWjXMIgIspLvnVrNFwbjcBAduZf cqWjXMIgIspLvnVrNFwbjcBAduZf = new CqWjXMIgIspLvnVrNFwbjcBAduZf();
					cqWjXMIgIspLvnVrNFwbjcBAduZf.fUKePmpOSBQAMQmhhpZROQytsEVm = P_0;
					cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF = JsonTools.Clone(cqWjXMIgIspLvnVrNFwbjcBAduZf.fUKePmpOSBQAMQmhhpZROQytsEVm.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = OVTnteWlBmEvHpCjXRjOXpaDxaKk.fgivMcCczvWCIHMgDBmehdkCQusCA.Find(cqWjXMIgIspLvnVrNFwbjcBAduZf.lUDGMnoewtAKYHjkNyMXyuSuLpWQ);
					beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = PRzjaXnkGIFbtcWHBZEhPtkxqndN.Find(cqWjXMIgIspLvnVrNFwbjcBAduZf.qWuEhcIWKzVqTEcwuqqCGTDacvaW);
					cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF.categoryId = beukNuiOoMtNFZXULtVdSyJSSFaG2?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF.layoutId = beukNuiOoMtNFZXULtVdSyJSSFaG3?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					for (int i = 0; i < cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF.actionElementMaps.Count; i++)
					{
						hmDcvPGXcVycyUmaLsmrOMXqPgKcb hmDcvPGXcVycyUmaLsmrOMXqPgKcb2 = new hmDcvPGXcVycyUmaLsmrOMXqPgKcb();
						hmDcvPGXcVycyUmaLsmrOMXqPgKcb2.OkoLjoIjjVyKxcVsxWflxinataQk = cqWjXMIgIspLvnVrNFwbjcBAduZf;
						hmDcvPGXcVycyUmaLsmrOMXqPgKcb2.mBNBYKIbSjLTvWIidfKAEWmpDCmdb = hmDcvPGXcVycyUmaLsmrOMXqPgKcb2.OkoLjoIjjVyKxcVsxWflxinataQk.cNuIGITxvIYLnSFPcrvnffhcEtXF.actionElementMaps[i];
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG4 = OVTnteWlBmEvHpCjXRjOXpaDxaKk.HwGqJUzgajaHWazbfvTNxckLfSaB.Find(hmDcvPGXcVycyUmaLsmrOMXqPgKcb2.yFpjopjpRhMpmNNtTyXdUgwBGHjm);
						hmDcvPGXcVycyUmaLsmrOMXqPgKcb2.mBNBYKIbSjLTvWIidfKAEWmpDCmdb._actionId = beukNuiOoMtNFZXULtVdSyJSSFaG4?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
						hmDcvPGXcVycyUmaLsmrOMXqPgKcb2.mBNBYKIbSjLTvWIidfKAEWmpDCmdb._actionCategoryId = ((OVTnteWlBmEvHpCjXRjOXpaDxaKk.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.GetActionById(hmDcvPGXcVycyUmaLsmrOMXqPgKcb2.mBNBYKIbSjLTvWIidfKAEWmpDCmdb._actionId) != null) ? OVTnteWlBmEvHpCjXRjOXpaDxaKk.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.GetActionById(hmDcvPGXcVycyUmaLsmrOMXqPgKcb2.mBNBYKIbSjLTvWIidfKAEWmpDCmdb._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (cqWjXMIgIspLvnVrNFwbjcBAduZf.fUKePmpOSBQAMQmhhpZROQytsEVm.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						controllerMap_Editor = cqWjXMIgIspLvnVrNFwbjcBAduZf.fUKePmpOSBQAMQmhhpZROQytsEVm.iBjeADkdmcFdOwnyqIFKEOlNasFE;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.nFfJTQuqgKQkDkFuUGdvejRNOXhAb;
						lrzABLdfLqzrAbmIOApLBnEusyMD(controllerMap_Editor.actionElementMaps, cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF = controllerMap_Editor2;
					}
					else
					{
						OVTnteWlBmEvHpCjXRjOXpaDxaKk.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.CreateKeyboardMap(cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF.categoryId, cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF.layoutId);
						controllerMap_Editor = cqWjXMIgIspLvnVrNFwbjcBAduZf.fUKePmpOSBQAMQmhhpZROQytsEVm.gciSLeDmTlUiItEnSljjEjPhhBmr[cqWjXMIgIspLvnVrNFwbjcBAduZf.fUKePmpOSBQAMQmhhpZROQytsEVm.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF.id = controllerMap_Editor.id;
					int index = cqWjXMIgIspLvnVrNFwbjcBAduZf.fUKePmpOSBQAMQmhhpZROQytsEVm.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(controllerMap_Editor);
					cqWjXMIgIspLvnVrNFwbjcBAduZf.fUKePmpOSBQAMQmhhpZROQytsEVm.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF;
					return cqWjXMIgIspLvnVrNFwbjcBAduZf.cNuIGITxvIYLnSFPcrvnffhcEtXF;
				}
			}

			private sealed class dmWEHjdSKtoihTAILhXSSGIhgacP
			{
				public ControllerMap_Editor zXuivzRQnHeDYeVIzUSkmejOCnPQ;

				public Predicate<beukNuiOoMtNFZXULtVdSyJSSFaG> reLsuZAFiWEacAxPNOPGwFeJUDNeA;

				public Predicate<beukNuiOoMtNFZXULtVdSyJSSFaG> QbBShyapQERdPjeSxWPqQiunyZbp;

				internal bool YHpbLZVIheRvNEofrqYiRxiNTJXr(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.siqcSXGgjDsmBJwsXxRecOOxOQjG == zXuivzRQnHeDYeVIzUSkmejOCnPQ.categoryId;
				}

				internal bool YovAfktXEqnHqHgPXsohLqzhPJSq(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.siqcSXGgjDsmBJwsXxRecOOxOQjG == zXuivzRQnHeDYeVIzUSkmejOCnPQ.layoutId;
				}
			}

			private sealed class CqWjXMIgIspLvnVrNFwbjcBAduZf
			{
				public jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMap_Editor> fUKePmpOSBQAMQmhhpZROQytsEVm;

				public ControllerMap_Editor cNuIGITxvIYLnSFPcrvnffhcEtXF;

				internal bool lUDGMnoewtAKYHjkNyMXyuSuLpWQ(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(fUKePmpOSBQAMQmhhpZROQytsEVm.MXxludPObokqQvZiMmLXwWmxpleI) == cNuIGITxvIYLnSFPcrvnffhcEtXF.categoryId;
				}

				internal bool qWuEhcIWKzVqTEcwuqqCGTDacvaW(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(fUKePmpOSBQAMQmhhpZROQytsEVm.MXxludPObokqQvZiMmLXwWmxpleI) == cNuIGITxvIYLnSFPcrvnffhcEtXF.layoutId;
				}
			}

			private sealed class CmivTcNFMrulznoPaNOhMjLmHitj
			{
				public List<int> PSOLagUroCilqtEsTnyELHiWUjjS;

				public ifVDRDNRlQIrefGUREftbZZhpiIyA UwpAPIccxqsZCyfguDEnEFGBdQov;

				internal InputMapCategory iDZIYgXhSHlROLEpwNLcRlHmydis(jJztNzSTXhVHmDpnYqoUuGrIcJKO<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					InputMapCategory inputMapCategory2;
					if (P_0.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						inputMapCategory2 = P_0.iBjeADkdmcFdOwnyqIFKEOlNasFE;
					}
					else
					{
						UwpAPIccxqsZCyfguDEnEFGBdQov.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.AddMapCategory();
						inputMapCategory2 = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					int num = P_0.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(inputMapCategory2);
					if (P_0.MXxludPObokqQvZiMmLXwWmxpleI == beukNuiOoMtNFZXULtVdSyJSSFaG.BURnnLtJTtAlYqmPFAUVbuOfQUKk.otherId)
					{
						PSOLagUroCilqtEsTnyELHiWUjjS.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.gciSLeDmTlUiItEnSljjEjPhhBmr[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class hmDcvPGXcVycyUmaLsmrOMXqPgKcb
			{
				public ActionElementMap mBNBYKIbSjLTvWIidfKAEWmpDCmdb;

				public CqWjXMIgIspLvnVrNFwbjcBAduZf OkoLjoIjjVyKxcVsxWflxinataQk;

				internal bool yFpjopjpRhMpmNNtTyXdUgwBGHjm(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(OkoLjoIjjVyKxcVsxWflxinataQk.fUKePmpOSBQAMQmhhpZROQytsEVm.MXxludPObokqQvZiMmLXwWmxpleI) == mBNBYKIbSjLTvWIidfKAEWmpDCmdb._actionId;
				}
			}

			private sealed class bGuVEhiMnuzBMIFcfhjaUcDIKkeL
			{
				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> ZxmJvXMzsMFLJXFghbMzJnFgYDjUA;

				public ifVDRDNRlQIrefGUREftbZZhpiIyA IqhAJrBhLVKQooPHbaWxbCEFUwdO;

				internal int nRoXTRQIdjyomnlKYomUTYNRKnbn(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					sMoabDiRhGNyAVYvDOykPRREZQmCA sMoabDiRhGNyAVYvDOykPRREZQmCA2 = new sMoabDiRhGNyAVYvDOykPRREZQmCA();
					sMoabDiRhGNyAVYvDOykPRREZQmCA2.ShpdjsBDGTEWTIGqWduBgLdTcSNbb = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = IqhAJrBhLVKQooPHbaWxbCEFUwdO.fgivMcCczvWCIHMgDBmehdkCQusCA.Find(sMoabDiRhGNyAVYvDOykPRREZQmCA2.exrGriKcymMLYAHVvExOjNbmtgbg);
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = ZxmJvXMzsMFLJXFghbMzJnFgYDjUA.Find(sMoabDiRhGNyAVYvDOykPRREZQmCA2.YzilogwVqhEnQfyVmPxDwBbbivBR);
						if (beukNuiOoMtNFZXULtVdSyJSSFaG2 != null && beukNuiOoMtNFZXULtVdSyJSSFaG2.rvMBOHdgcSqhasACwNUMifxuVRNvA == P_1[i].categoryId && beukNuiOoMtNFZXULtVdSyJSSFaG3 != null && beukNuiOoMtNFZXULtVdSyJSSFaG3.rvMBOHdgcSqhasACwNUMifxuVRNvA == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor gfEIgNXVEBmbMVfVCgJxWexRfkhC(jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMap_Editor> P_0)
				{
					IPDmxSpYuXmyyYCyGvtaBeIXTWKV iPDmxSpYuXmyyYCyGvtaBeIXTWKV = new IPDmxSpYuXmyyYCyGvtaBeIXTWKV();
					iPDmxSpYuXmyyYCyGvtaBeIXTWKV.EKKSjIQNyzYTvlSLkCnNJpTFcFvd = P_0;
					iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR = JsonTools.Clone(iPDmxSpYuXmyyYCyGvtaBeIXTWKV.EKKSjIQNyzYTvlSLkCnNJpTFcFvd.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = IqhAJrBhLVKQooPHbaWxbCEFUwdO.fgivMcCczvWCIHMgDBmehdkCQusCA.Find(iPDmxSpYuXmyyYCyGvtaBeIXTWKV.gxZeEYCqfQcYtmjooBjLUpoIeoSg);
					beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = ZxmJvXMzsMFLJXFghbMzJnFgYDjUA.Find(iPDmxSpYuXmyyYCyGvtaBeIXTWKV.ZINmszclHiuOzUnayDLTFNyBWySW);
					iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR.categoryId = beukNuiOoMtNFZXULtVdSyJSSFaG2?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR.layoutId = beukNuiOoMtNFZXULtVdSyJSSFaG3?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					for (int i = 0; i < iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR.actionElementMaps.Count; i++)
					{
						KOLfJKzdeJFMFGYpireSohZvztKM kOLfJKzdeJFMFGYpireSohZvztKM = new KOLfJKzdeJFMFGYpireSohZvztKM();
						kOLfJKzdeJFMFGYpireSohZvztKM.ljvPjzFjVlpPYBayXfcQjntvBDTDA = iPDmxSpYuXmyyYCyGvtaBeIXTWKV;
						kOLfJKzdeJFMFGYpireSohZvztKM.hvTHDlYRimqpNPLExdOpecXdkzLy = kOLfJKzdeJFMFGYpireSohZvztKM.ljvPjzFjVlpPYBayXfcQjntvBDTDA.PhxyJpDivYEWJjYUSuHNfjSzsmHR.actionElementMaps[i];
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG4 = IqhAJrBhLVKQooPHbaWxbCEFUwdO.HwGqJUzgajaHWazbfvTNxckLfSaB.Find(kOLfJKzdeJFMFGYpireSohZvztKM.yhKPxQiCtuUYHeiFVflcLjRHdbVq);
						kOLfJKzdeJFMFGYpireSohZvztKM.hvTHDlYRimqpNPLExdOpecXdkzLy._actionId = beukNuiOoMtNFZXULtVdSyJSSFaG4?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
						kOLfJKzdeJFMFGYpireSohZvztKM.hvTHDlYRimqpNPLExdOpecXdkzLy._actionCategoryId = ((IqhAJrBhLVKQooPHbaWxbCEFUwdO.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.GetActionById(kOLfJKzdeJFMFGYpireSohZvztKM.hvTHDlYRimqpNPLExdOpecXdkzLy._actionId) != null) ? IqhAJrBhLVKQooPHbaWxbCEFUwdO.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.GetActionById(kOLfJKzdeJFMFGYpireSohZvztKM.hvTHDlYRimqpNPLExdOpecXdkzLy._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (iPDmxSpYuXmyyYCyGvtaBeIXTWKV.EKKSjIQNyzYTvlSLkCnNJpTFcFvd.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						controllerMap_Editor = iPDmxSpYuXmyyYCyGvtaBeIXTWKV.EKKSjIQNyzYTvlSLkCnNJpTFcFvd.iBjeADkdmcFdOwnyqIFKEOlNasFE;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.uXaoBIVMoqwoIiKIErHbSqhaDJlz;
						lrzABLdfLqzrAbmIOApLBnEusyMD(controllerMap_Editor.actionElementMaps, iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR = controllerMap_Editor2;
					}
					else
					{
						IqhAJrBhLVKQooPHbaWxbCEFUwdO.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.CreateMouseMap(iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR.categoryId, iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR.layoutId);
						controllerMap_Editor = iPDmxSpYuXmyyYCyGvtaBeIXTWKV.EKKSjIQNyzYTvlSLkCnNJpTFcFvd.gciSLeDmTlUiItEnSljjEjPhhBmr[iPDmxSpYuXmyyYCyGvtaBeIXTWKV.EKKSjIQNyzYTvlSLkCnNJpTFcFvd.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR.id = controllerMap_Editor.id;
					int index = iPDmxSpYuXmyyYCyGvtaBeIXTWKV.EKKSjIQNyzYTvlSLkCnNJpTFcFvd.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(controllerMap_Editor);
					iPDmxSpYuXmyyYCyGvtaBeIXTWKV.EKKSjIQNyzYTvlSLkCnNJpTFcFvd.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR;
					return iPDmxSpYuXmyyYCyGvtaBeIXTWKV.PhxyJpDivYEWJjYUSuHNfjSzsmHR;
				}
			}

			private sealed class sMoabDiRhGNyAVYvDOykPRREZQmCA
			{
				public ControllerMap_Editor ShpdjsBDGTEWTIGqWduBgLdTcSNbb;

				public Predicate<beukNuiOoMtNFZXULtVdSyJSSFaG> asOkKrEJhQyRHqQnpPUwnAtBHROh;

				public Predicate<beukNuiOoMtNFZXULtVdSyJSSFaG> UCGYCloEjJFdmkEPzNsVgAKzsWrdb;

				internal bool exrGriKcymMLYAHVvExOjNbmtgbg(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.siqcSXGgjDsmBJwsXxRecOOxOQjG == ShpdjsBDGTEWTIGqWduBgLdTcSNbb.categoryId;
				}

				internal bool YzilogwVqhEnQfyVmPxDwBbbivBR(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.siqcSXGgjDsmBJwsXxRecOOxOQjG == ShpdjsBDGTEWTIGqWduBgLdTcSNbb.layoutId;
				}
			}

			private sealed class IPDmxSpYuXmyyYCyGvtaBeIXTWKV
			{
				public jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMap_Editor> EKKSjIQNyzYTvlSLkCnNJpTFcFvd;

				public ControllerMap_Editor PhxyJpDivYEWJjYUSuHNfjSzsmHR;

				internal bool gxZeEYCqfQcYtmjooBjLUpoIeoSg(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(EKKSjIQNyzYTvlSLkCnNJpTFcFvd.MXxludPObokqQvZiMmLXwWmxpleI) == PhxyJpDivYEWJjYUSuHNfjSzsmHR.categoryId;
				}

				internal bool ZINmszclHiuOzUnayDLTFNyBWySW(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(EKKSjIQNyzYTvlSLkCnNJpTFcFvd.MXxludPObokqQvZiMmLXwWmxpleI) == PhxyJpDivYEWJjYUSuHNfjSzsmHR.layoutId;
				}
			}

			private sealed class KOLfJKzdeJFMFGYpireSohZvztKM
			{
				public ActionElementMap hvTHDlYRimqpNPLExdOpecXdkzLy;

				public IPDmxSpYuXmyyYCyGvtaBeIXTWKV ljvPjzFjVlpPYBayXfcQjntvBDTDA;

				internal bool yhKPxQiCtuUYHeiFVflcLjRHdbVq(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(ljvPjzFjVlpPYBayXfcQjntvBDTDA.EKKSjIQNyzYTvlSLkCnNJpTFcFvd.MXxludPObokqQvZiMmLXwWmxpleI) == hvTHDlYRimqpNPLExdOpecXdkzLy._actionId;
				}
			}

			private sealed class SZJNyOBjJQwuUOomVtUzNJaoWQzP
			{
				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> fexwRjZUjatSjSVLGMVzdpbrAMnD;

				public ifVDRDNRlQIrefGUREftbZZhpiIyA ezBubgscptPEzidYRELLjNwfjcvsA;

				internal int EMugszjqafdsIMjAidWgdULjdebxA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					LEVFQZTXcuhnyKtBDIrBdTtdutQ lEVFQZTXcuhnyKtBDIrBdTtdutQ = new LEVFQZTXcuhnyKtBDIrBdTtdutQ();
					lEVFQZTXcuhnyKtBDIrBdTtdutQ.LwrmlBFAUEininngObTMLUtTalKiA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = ezBubgscptPEzidYRELLjNwfjcvsA.fgivMcCczvWCIHMgDBmehdkCQusCA.Find(lEVFQZTXcuhnyKtBDIrBdTtdutQ.zeHEyOxrISeTJblkYmUXwRkgIhdiA);
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = fexwRjZUjatSjSVLGMVzdpbrAMnD.Find(lEVFQZTXcuhnyKtBDIrBdTtdutQ.HREdfdbyLTSEeagvCTjhhxpDKtdjA);
						if (lEVFQZTXcuhnyKtBDIrBdTtdutQ.LwrmlBFAUEininngObTMLUtTalKiA.hardwareGuid == P_1[i].hardwareGuid && beukNuiOoMtNFZXULtVdSyJSSFaG2 != null && beukNuiOoMtNFZXULtVdSyJSSFaG2.rvMBOHdgcSqhasACwNUMifxuVRNvA == P_1[i].categoryId && beukNuiOoMtNFZXULtVdSyJSSFaG3 != null && beukNuiOoMtNFZXULtVdSyJSSFaG3.rvMBOHdgcSqhasACwNUMifxuVRNvA == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor yvQZgnLkCERudveADHNtIBIcQhIr(jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMap_Editor> P_0)
				{
					BqDalFmhdofiXFAZTGoIwjyrhnzs bqDalFmhdofiXFAZTGoIwjyrhnzs = new BqDalFmhdofiXFAZTGoIwjyrhnzs();
					bqDalFmhdofiXFAZTGoIwjyrhnzs.edKRsqvHcVDCRhevzZrFobnXffvAb = P_0;
					bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc = JsonTools.Clone(bqDalFmhdofiXFAZTGoIwjyrhnzs.edKRsqvHcVDCRhevzZrFobnXffvAb.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = ezBubgscptPEzidYRELLjNwfjcvsA.fgivMcCczvWCIHMgDBmehdkCQusCA.Find(bqDalFmhdofiXFAZTGoIwjyrhnzs.iGJbDDauzwImypwibDzGImsFLbfV);
					beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = fexwRjZUjatSjSVLGMVzdpbrAMnD.Find(bqDalFmhdofiXFAZTGoIwjyrhnzs.iEelgioBFOgveTYJGsmEAgIuaLoy);
					bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.categoryId = beukNuiOoMtNFZXULtVdSyJSSFaG2?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.layoutId = beukNuiOoMtNFZXULtVdSyJSSFaG3?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					for (int i = 0; i < bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.actionElementMaps.Count; i++)
					{
						BzCzSfBmbcxJgpEavDSeEVoOnvVCA bzCzSfBmbcxJgpEavDSeEVoOnvVCA = new BzCzSfBmbcxJgpEavDSeEVoOnvVCA();
						bzCzSfBmbcxJgpEavDSeEVoOnvVCA.AHelZQfLhXgCLuVRZQNNoDmzwhD = bqDalFmhdofiXFAZTGoIwjyrhnzs;
						bzCzSfBmbcxJgpEavDSeEVoOnvVCA.NcGbaBkdolKXqaGhvRJaMvyJzCTNA = bzCzSfBmbcxJgpEavDSeEVoOnvVCA.AHelZQfLhXgCLuVRZQNNoDmzwhD.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.actionElementMaps[i];
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG4 = ezBubgscptPEzidYRELLjNwfjcvsA.HwGqJUzgajaHWazbfvTNxckLfSaB.Find(bzCzSfBmbcxJgpEavDSeEVoOnvVCA.CnCCRGhGxtMLDpAORtPqcdJalhXrA);
						bzCzSfBmbcxJgpEavDSeEVoOnvVCA.NcGbaBkdolKXqaGhvRJaMvyJzCTNA._actionId = beukNuiOoMtNFZXULtVdSyJSSFaG4?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
						bzCzSfBmbcxJgpEavDSeEVoOnvVCA.NcGbaBkdolKXqaGhvRJaMvyJzCTNA._actionCategoryId = ((ezBubgscptPEzidYRELLjNwfjcvsA.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.GetActionById(bzCzSfBmbcxJgpEavDSeEVoOnvVCA.NcGbaBkdolKXqaGhvRJaMvyJzCTNA._actionId) != null) ? ezBubgscptPEzidYRELLjNwfjcvsA.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.GetActionById(bzCzSfBmbcxJgpEavDSeEVoOnvVCA.NcGbaBkdolKXqaGhvRJaMvyJzCTNA._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (bqDalFmhdofiXFAZTGoIwjyrhnzs.edKRsqvHcVDCRhevzZrFobnXffvAb.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						controllerMap_Editor = bqDalFmhdofiXFAZTGoIwjyrhnzs.edKRsqvHcVDCRhevzZrFobnXffvAb.iBjeADkdmcFdOwnyqIFKEOlNasFE;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.PJXdqDJmaQOfvcVAeUtPdzFEUjcdE;
						lrzABLdfLqzrAbmIOApLBnEusyMD(controllerMap_Editor.actionElementMaps, bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc = controllerMap_Editor2;
					}
					else
					{
						ezBubgscptPEzidYRELLjNwfjcvsA.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.CreateJoystickMap(bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.categoryId, bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.hardwareGuid, bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.layoutId);
						controllerMap_Editor = bqDalFmhdofiXFAZTGoIwjyrhnzs.edKRsqvHcVDCRhevzZrFobnXffvAb.gciSLeDmTlUiItEnSljjEjPhhBmr[bqDalFmhdofiXFAZTGoIwjyrhnzs.edKRsqvHcVDCRhevzZrFobnXffvAb.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.id = controllerMap_Editor.id;
					int index = bqDalFmhdofiXFAZTGoIwjyrhnzs.edKRsqvHcVDCRhevzZrFobnXffvAb.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(controllerMap_Editor);
					bqDalFmhdofiXFAZTGoIwjyrhnzs.edKRsqvHcVDCRhevzZrFobnXffvAb.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc;
					return bqDalFmhdofiXFAZTGoIwjyrhnzs.VvFGZqhuiDgDEgGxiIAOvFzrmsLFc;
				}
			}

			private sealed class LEVFQZTXcuhnyKtBDIrBdTtdutQ
			{
				public ControllerMap_Editor LwrmlBFAUEininngObTMLUtTalKiA;

				public Predicate<beukNuiOoMtNFZXULtVdSyJSSFaG> PcNvrGbKIEQFinqfNVjobDTRRBdv;

				public Predicate<beukNuiOoMtNFZXULtVdSyJSSFaG> LqvCUmARrQaIbcsbjGOtcqijWDZBB;

				internal bool zeHEyOxrISeTJblkYmUXwRkgIhdiA(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.siqcSXGgjDsmBJwsXxRecOOxOQjG == LwrmlBFAUEininngObTMLUtTalKiA.categoryId;
				}

				internal bool HREdfdbyLTSEeagvCTjhhxpDKtdjA(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.siqcSXGgjDsmBJwsXxRecOOxOQjG == LwrmlBFAUEininngObTMLUtTalKiA.layoutId;
				}
			}

			private sealed class BqDalFmhdofiXFAZTGoIwjyrhnzs
			{
				public jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMap_Editor> edKRsqvHcVDCRhevzZrFobnXffvAb;

				public ControllerMap_Editor VvFGZqhuiDgDEgGxiIAOvFzrmsLFc;

				internal bool iGJbDDauzwImypwibDzGImsFLbfV(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(edKRsqvHcVDCRhevzZrFobnXffvAb.MXxludPObokqQvZiMmLXwWmxpleI) == VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.categoryId;
				}

				internal bool iEelgioBFOgveTYJGsmEAgIuaLoy(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(edKRsqvHcVDCRhevzZrFobnXffvAb.MXxludPObokqQvZiMmLXwWmxpleI) == VvFGZqhuiDgDEgGxiIAOvFzrmsLFc.layoutId;
				}
			}

			private sealed class BzCzSfBmbcxJgpEavDSeEVoOnvVCA
			{
				public ActionElementMap NcGbaBkdolKXqaGhvRJaMvyJzCTNA;

				public BqDalFmhdofiXFAZTGoIwjyrhnzs AHelZQfLhXgCLuVRZQNNoDmzwhD;

				internal bool CnCCRGhGxtMLDpAORtPqcdJalhXrA(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(AHelZQfLhXgCLuVRZQNNoDmzwhD.edKRsqvHcVDCRhevzZrFobnXffvAb.MXxludPObokqQvZiMmLXwWmxpleI) == NcGbaBkdolKXqaGhvRJaMvyJzCTNA._actionId;
				}
			}

			private sealed class XRfAbbhETbrPJEjWIObhpBmCfQHsA
			{
				public List<beukNuiOoMtNFZXULtVdSyJSSFaG> PXqKkoXKwYplaHvkjCfNJyJOWCaW;

				public ifVDRDNRlQIrefGUREftbZZhpiIyA vusMjXxdihMBxfHRBAQZBsAvBFCSA;

				internal int mNvgTZWITXOfUVGjjCqzGVekDCDU(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					fjlHcMYNQvQxkxbvgQEdeVuyopXP fjlHcMYNQvQxkxbvgQEdeVuyopXP2 = new fjlHcMYNQvQxkxbvgQEdeVuyopXP();
					fjlHcMYNQvQxkxbvgQEdeVuyopXP2.TtKRysHaFLIbFCaWXHigSHMnaXtxA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = vusMjXxdihMBxfHRBAQZBsAvBFCSA.UwSvdwbWBHVZtqqunbXVHkYhUtOH.Find(fjlHcMYNQvQxkxbvgQEdeVuyopXP2.BeVVvORqVVbQJgCdTInAGbPwAKIZ);
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = vusMjXxdihMBxfHRBAQZBsAvBFCSA.fgivMcCczvWCIHMgDBmehdkCQusCA.Find(fjlHcMYNQvQxkxbvgQEdeVuyopXP2.lrqVohrJdKmjQtTejGdNOqELjtcR);
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG4 = PXqKkoXKwYplaHvkjCfNJyJOWCaW.Find(fjlHcMYNQvQxkxbvgQEdeVuyopXP2.mwgZQUrzUouQSMxOiBapqoThAXRI);
						if (beukNuiOoMtNFZXULtVdSyJSSFaG2 != null && beukNuiOoMtNFZXULtVdSyJSSFaG2.rvMBOHdgcSqhasACwNUMifxuVRNvA == P_1[i].customControllerUid && beukNuiOoMtNFZXULtVdSyJSSFaG3 != null && beukNuiOoMtNFZXULtVdSyJSSFaG3.rvMBOHdgcSqhasACwNUMifxuVRNvA == P_1[i].categoryId && beukNuiOoMtNFZXULtVdSyJSSFaG4 != null && beukNuiOoMtNFZXULtVdSyJSSFaG4.rvMBOHdgcSqhasACwNUMifxuVRNvA == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor EmZWapBZLMKnNRzvKZjgqETTKQgk(jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMap_Editor> P_0)
				{
					AIpJhUULAHcGcdzPKvHFetkvifHM aIpJhUULAHcGcdzPKvHFetkvifHM = new AIpJhUULAHcGcdzPKvHFetkvifHM();
					aIpJhUULAHcGcdzPKvHFetkvifHM.oRWVMWVlrGzAxnQNwrprKuOHivRk = P_0;
					aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA = JsonTools.Clone(aIpJhUULAHcGcdzPKvHFetkvifHM.oRWVMWVlrGzAxnQNwrprKuOHivRk.QWkDtBfJwYdVwRIIMAovmagXqoSzA);
					beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = vusMjXxdihMBxfHRBAQZBsAvBFCSA.UwSvdwbWBHVZtqqunbXVHkYhUtOH.Find(aIpJhUULAHcGcdzPKvHFetkvifHM.qGLbgcFXevdYNtVpYOZLGriLmzcTA);
					beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG3 = vusMjXxdihMBxfHRBAQZBsAvBFCSA.fgivMcCczvWCIHMgDBmehdkCQusCA.Find(aIpJhUULAHcGcdzPKvHFetkvifHM.gIpZajaNKvjFKTwxFbCFRNTIUYxh);
					beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG4 = PXqKkoXKwYplaHvkjCfNJyJOWCaW.Find(aIpJhUULAHcGcdzPKvHFetkvifHM.epqzrDyJZpbxQbwGxxjWSaiItCvwA);
					aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA.customControllerUid = beukNuiOoMtNFZXULtVdSyJSSFaG2?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA.categoryId = beukNuiOoMtNFZXULtVdSyJSSFaG3?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA.layoutId = beukNuiOoMtNFZXULtVdSyJSSFaG4?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					for (int i = 0; i < aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA.actionElementMaps.Count; i++)
					{
						HGQUPgoVePvGzBFWqVQUxmJSmwmP hGQUPgoVePvGzBFWqVQUxmJSmwmP = new HGQUPgoVePvGzBFWqVQUxmJSmwmP();
						hGQUPgoVePvGzBFWqVQUxmJSmwmP.OjXTRahcedeoLfiGwEbgvIZQkFDdb = aIpJhUULAHcGcdzPKvHFetkvifHM;
						hGQUPgoVePvGzBFWqVQUxmJSmwmP.xAYjGWYANPovTmGXSmfzdZCXgmFb = hGQUPgoVePvGzBFWqVQUxmJSmwmP.OjXTRahcedeoLfiGwEbgvIZQkFDdb.ryLuixuHzbvNKQarzGuRGtPsKihgA.actionElementMaps[i];
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG5 = vusMjXxdihMBxfHRBAQZBsAvBFCSA.HwGqJUzgajaHWazbfvTNxckLfSaB.Find(hGQUPgoVePvGzBFWqVQUxmJSmwmP.BCUvFCisKovEyVFZYuauHbcbJXGg);
						hGQUPgoVePvGzBFWqVQUxmJSmwmP.xAYjGWYANPovTmGXSmfzdZCXgmFb._actionId = beukNuiOoMtNFZXULtVdSyJSSFaG5?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
						hGQUPgoVePvGzBFWqVQUxmJSmwmP.xAYjGWYANPovTmGXSmfzdZCXgmFb._actionCategoryId = ((vusMjXxdihMBxfHRBAQZBsAvBFCSA.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.GetActionById(hGQUPgoVePvGzBFWqVQUxmJSmwmP.xAYjGWYANPovTmGXSmfzdZCXgmFb._actionId) != null) ? vusMjXxdihMBxfHRBAQZBsAvBFCSA.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.GetActionById(hGQUPgoVePvGzBFWqVQUxmJSmwmP.xAYjGWYANPovTmGXSmfzdZCXgmFb._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (aIpJhUULAHcGcdzPKvHFetkvifHM.oRWVMWVlrGzAxnQNwrprKuOHivRk.gSBFmTESQpqitOZdyGiuiFVKGGZUA)
					{
						controllerMap_Editor = aIpJhUULAHcGcdzPKvHFetkvifHM.oRWVMWVlrGzAxnQNwrprKuOHivRk.iBjeADkdmcFdOwnyqIFKEOlNasFE;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.PhkUzdQCNRAdNEtEdJhHEThKrdeAc;
						lrzABLdfLqzrAbmIOApLBnEusyMD(controllerMap_Editor.actionElementMaps, aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA = controllerMap_Editor2;
					}
					else
					{
						vusMjXxdihMBxfHRBAQZBsAvBFCSA.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.CreateCustomControllerMap(aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA.categoryId, aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA.customControllerUid, aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA.layoutId);
						controllerMap_Editor = aIpJhUULAHcGcdzPKvHFetkvifHM.oRWVMWVlrGzAxnQNwrprKuOHivRk.gciSLeDmTlUiItEnSljjEjPhhBmr[aIpJhUULAHcGcdzPKvHFetkvifHM.oRWVMWVlrGzAxnQNwrprKuOHivRk.gciSLeDmTlUiItEnSljjEjPhhBmr.Count - 1];
					}
					aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA.id = controllerMap_Editor.id;
					int index = aIpJhUULAHcGcdzPKvHFetkvifHM.oRWVMWVlrGzAxnQNwrprKuOHivRk.gciSLeDmTlUiItEnSljjEjPhhBmr.IndexOf(controllerMap_Editor);
					aIpJhUULAHcGcdzPKvHFetkvifHM.oRWVMWVlrGzAxnQNwrprKuOHivRk.gciSLeDmTlUiItEnSljjEjPhhBmr[index] = aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA;
					return aIpJhUULAHcGcdzPKvHFetkvifHM.ryLuixuHzbvNKQarzGuRGtPsKihgA;
				}
			}

			private sealed class fSIiHgODAeKpGDCiWJdHEvXIIUcf
			{
				public int HTORKFtatPpwtNCZcYFEdosuCimkA;

				internal bool ofRQWVkNMlAIqjMgBDvkGtbPzWnFA(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.siqcSXGgjDsmBJwsXxRecOOxOQjG == HTORKFtatPpwtNCZcYFEdosuCimkA;
				}
			}

			private sealed class fjlHcMYNQvQxkxbvgQEdeVuyopXP
			{
				public ControllerMap_Editor TtKRysHaFLIbFCaWXHigSHMnaXtxA;

				public Predicate<beukNuiOoMtNFZXULtVdSyJSSFaG> jpDtBqZQayezQxBnzQUWfqSHTmhx;

				public Predicate<beukNuiOoMtNFZXULtVdSyJSSFaG> pwaTZtjGcdAbqILWakSDcKyKPvOJ;

				public Predicate<beukNuiOoMtNFZXULtVdSyJSSFaG> tfqwgxqHiUEAaegWKjtKYAsCFraDA;

				internal bool BeVVvORqVVbQJgCdTInAGbPwAKIZ(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.siqcSXGgjDsmBJwsXxRecOOxOQjG == TtKRysHaFLIbFCaWXHigSHMnaXtxA.customControllerUid;
				}

				internal bool lrqVohrJdKmjQtTejGdNOqELjtcR(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.siqcSXGgjDsmBJwsXxRecOOxOQjG == TtKRysHaFLIbFCaWXHigSHMnaXtxA.categoryId;
				}

				internal bool mwgZQUrzUouQSMxOiBapqoThAXRI(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.siqcSXGgjDsmBJwsXxRecOOxOQjG == TtKRysHaFLIbFCaWXHigSHMnaXtxA.layoutId;
				}
			}

			private sealed class AIpJhUULAHcGcdzPKvHFetkvifHM
			{
				public jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMap_Editor> oRWVMWVlrGzAxnQNwrprKuOHivRk;

				public ControllerMap_Editor ryLuixuHzbvNKQarzGuRGtPsKihgA;

				internal bool qGLbgcFXevdYNtVpYOZLGriLmzcTA(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(oRWVMWVlrGzAxnQNwrprKuOHivRk.MXxludPObokqQvZiMmLXwWmxpleI) == ryLuixuHzbvNKQarzGuRGtPsKihgA.customControllerUid;
				}

				internal bool gIpZajaNKvjFKTwxFbCFRNTIUYxh(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(oRWVMWVlrGzAxnQNwrprKuOHivRk.MXxludPObokqQvZiMmLXwWmxpleI) == ryLuixuHzbvNKQarzGuRGtPsKihgA.categoryId;
				}

				internal bool epqzrDyJZpbxQbwGxxjWSaiItCvwA(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(oRWVMWVlrGzAxnQNwrprKuOHivRk.MXxludPObokqQvZiMmLXwWmxpleI) == ryLuixuHzbvNKQarzGuRGtPsKihgA.layoutId;
				}
			}

			private sealed class HGQUPgoVePvGzBFWqVQUxmJSmwmP
			{
				public ActionElementMap xAYjGWYANPovTmGXSmfzdZCXgmFb;

				public AIpJhUULAHcGcdzPKvHFetkvifHM OjXTRahcedeoLfiGwEbgvIZQkFDdb;

				internal bool BCUvFCisKovEyVFZYuauHbcbJXGg(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(OjXTRahcedeoLfiGwEbgvIZQkFDdb.oRWVMWVlrGzAxnQNwrprKuOHivRk.MXxludPObokqQvZiMmLXwWmxpleI) == xAYjGWYANPovTmGXSmfzdZCXgmFb._actionId;
				}
			}

			private sealed class nVAnErJCAHqUsXqlThgXjyooJRJU
			{
				public jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMapLayoutManager_RuleSet_Editor> nSUcJCqrNtnsCIjkQQkmKeqRVcXj;
			}

			private sealed class IvOOkAXylTcRFntOrydYTZvpQgMA
			{
				public int qxyfcHiqRswIojmtxBpDVZsuEtFr;

				public nVAnErJCAHqUsXqlThgXjyooJRJU SrrExCaXblQjgKydhnpvmfITIzwJA;

				internal bool uJSAPeRZiCjulEJmeSVDIzJIdTPK(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(SrrExCaXblQjgKydhnpvmfITIzwJA.nSUcJCqrNtnsCIjkQQkmKeqRVcXj.MXxludPObokqQvZiMmLXwWmxpleI) == qxyfcHiqRswIojmtxBpDVZsuEtFr;
				}
			}

			private sealed class grlCdQbmaGnYPOFvHhAMFPSUyqdBA
			{
				public int ubUXhibKIYybmWUiREJpWkmzVAut;

				public nVAnErJCAHqUsXqlThgXjyooJRJU zrHfsBBrwHHgZDjdedyNIelswIlDc;

				internal bool PXmbAuhgXqQBcjETvbLUESbsObxcA(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(zrHfsBBrwHHgZDjdedyNIelswIlDc.nSUcJCqrNtnsCIjkQQkmKeqRVcXj.MXxludPObokqQvZiMmLXwWmxpleI) == ubUXhibKIYybmWUiREJpWkmzVAut;
				}
			}

			private sealed class lIqmGMsdfgiLXIIRwJdiDNgLqfSw
			{
				public int DiiPgXUxlulMdJQJtgKLyPHBeHwf;

				public nVAnErJCAHqUsXqlThgXjyooJRJU rrNvbPknTlDwJiwHloQaZVpxtldl;

				internal bool ayycSxFlDETEZHWbnmhnSjEvHTYz(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(rrNvbPknTlDwJiwHloQaZVpxtldl.nSUcJCqrNtnsCIjkQQkmKeqRVcXj.MXxludPObokqQvZiMmLXwWmxpleI) == DiiPgXUxlulMdJQJtgKLyPHBeHwf;
				}
			}

			private sealed class aimYqlTLvUbCLlPBoiGihiJVbhqw
			{
				public jJztNzSTXhVHmDpnYqoUuGrIcJKO<ControllerMapEnabler_RuleSet_Editor> FxEeGvmXbfLWJHtrudmHFsThuVpk;
			}

			private sealed class QUtHLHOGWgWoMkPmEbwIbGlSwtkc
			{
				public int YcyNSNHgzQpKJdnEuvhcGIWsYAMk;

				public aimYqlTLvUbCLlPBoiGihiJVbhqw dAJwBUjGcAcJYDrfjptuqXeFCGzfb;

				internal bool eufQTUzlStaVLEbwFogIeopdNZlXA(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.uVRzbaxjaccyVrqAoYDUdBepzjFx(dAJwBUjGcAcJYDrfjptuqXeFCGzfb.FxEeGvmXbfLWJHtrudmHFsThuVpk.MXxludPObokqQvZiMmLXwWmxpleI) == YcyNSNHgzQpKJdnEuvhcGIWsYAMk;
				}
			}

			private sealed class XociJPAKdJNYZNbknmQztoHLvBzp<_0001> where _0001 : class
			{
				public Func<_0001, int> JQGzROHXryAgfAcqzMhCgouVSVzF;
			}

			private sealed class bSMaxUGipXrSIqgGWLrPqwTMArveb<_0001> where _0001 : class
			{
				public _0001 heSsfkUpDeuxbhxXsHcmxlWQEPQn;

				public XociJPAKdJNYZNbknmQztoHLvBzp<_0001> AjsZGsVvxDBKdpEAmNGREmHPsaOR;

				internal bool QzfbFegSTsGLpqUEJnWuMVllOUNdb(beukNuiOoMtNFZXULtVdSyJSSFaG P_0)
				{
					return P_0.rvMBOHdgcSqhasACwNUMifxuVRNvA == AjsZGsVvxDBKdpEAmNGREmHPsaOR.JQGzROHXryAgfAcqzMhCgouVSVzF(heSsfkUpDeuxbhxXsHcmxlWQEPQn);
				}
			}

			public static UserData UKgdORFdedojcqcIOUhLopgNJpxsA(UserData P_0, UserData P_1, bool P_2)
			{
				ifVDRDNRlQIrefGUREftbZZhpiIyA ifVDRDNRlQIrefGUREftbZZhpiIyA2 = new ifVDRDNRlQIrefGUREftbZZhpiIyA();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA = (P_2 ? P_0 : new UserData(false));
				if (P_1 != null)
				{
					ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.configVars = JsonTools.Clone(P_1.configVars);
				}
				else
				{
					ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.configVars = JsonTools.Clone(P_0.configVars);
				}
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.eSORCJPckUozOacQerIHdpdHrREY = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Action Category", P_0.actionCategories, P_1?.actionCategories, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.actionCategories, P_2, ifVDRDNRlQIrefGUREftbZZhpiIyA2.eSORCJPckUozOacQerIHdpdHrREY, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.soUQsaJKtqBAqNninTlFsjEChqiN, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.ZVNfHamStxHnMiUAKkmAfxBaTgVc, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.ylMrsgdmhODCEhxSGeYoFtNBUmmMA, ifVDRDNRlQIrefGUREftbZZhpiIyA2.ducjzrkyPACjZyeoTHTvJgUJzKSN);
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.GMUoAeNBomHSMkccaEPZPsaxeqEgA = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.inputBehaviors, P_2, ifVDRDNRlQIrefGUREftbZZhpiIyA2.GMUoAeNBomHSMkccaEPZPsaxeqEgA, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.eRmeImtcCAfyJedoIkQLkpkqqOskA, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.QvoElsBxGvuhhsjfxspIkgTlOhAA, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.JmRnoOlXweaIQwQnRxzZrzgHFMoB, ifVDRDNRlQIrefGUREftbZZhpiIyA2.pafuAwJewjamjcXEluFqAEWHkznNA);
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.HwGqJUzgajaHWazbfvTNxckLfSaB = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Action", P_0.dUYEBfdxdeFmejEEDExIosmzBhsr, P_1?.dUYEBfdxdeFmejEEDExIosmzBhsr, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.dUYEBfdxdeFmejEEDExIosmzBhsr, P_2, ifVDRDNRlQIrefGUREftbZZhpiIyA2.HwGqJUzgajaHWazbfvTNxckLfSaB, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.hysaUrLKFGSYwztXspmKGcZxjwtP, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.YtOpqEemVBsrFTIcVTgKyFxsNFNB, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.XrkfJMpcncKpXZzkjInkZqyeGzVV, ifVDRDNRlQIrefGUREftbZZhpiIyA2.WdCdsqSYdHMzKIpZsIZXmNOmfLLf);
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.fgivMcCczvWCIHMgDBmehdkCQusCA = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				CmivTcNFMrulznoPaNOhMjLmHitj cmivTcNFMrulznoPaNOhMjLmHitj = new CmivTcNFMrulznoPaNOhMjLmHitj();
				cmivTcNFMrulznoPaNOhMjLmHitj.UwpAPIccxqsZCyfguDEnEFGBdQov = ifVDRDNRlQIrefGUREftbZZhpiIyA2;
				cmivTcNFMrulznoPaNOhMjLmHitj.PSOLagUroCilqtEsTnyELHiWUjjS = new List<int>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Map Category", P_0.mapCategories, P_1?.mapCategories, cmivTcNFMrulznoPaNOhMjLmHitj.UwpAPIccxqsZCyfguDEnEFGBdQov.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.mapCategories, P_2, cmivTcNFMrulznoPaNOhMjLmHitj.UwpAPIccxqsZCyfguDEnEFGBdQov.fgivMcCczvWCIHMgDBmehdkCQusCA, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.eFOKqEPXliruWzWKZOlLjTPgjnru, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.mvEDzkyOfCpkBQxevtfsaYJJivOA, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.nGrnyvMiOMJGKFCWYJeoyBjarSkX, cmivTcNFMrulznoPaNOhMjLmHitj.iDZIYgXhSHlROLEpwNLcRlHmydis);
				for (int i = 0; i < cmivTcNFMrulznoPaNOhMjLmHitj.PSOLagUroCilqtEsTnyELHiWUjjS.Count; i++)
				{
					int index = cmivTcNFMrulznoPaNOhMjLmHitj.PSOLagUroCilqtEsTnyELHiWUjjS[i];
					InputMapCategory inputMapCategory = cmivTcNFMrulznoPaNOhMjLmHitj.UwpAPIccxqsZCyfguDEnEFGBdQov.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.mapCategories[index];
					for (int j = 0; j < inputMapCategory.JVVOzLwROUVfugiBddCMJRlYAMxBb.Count; j++)
					{
						fSIiHgODAeKpGDCiWJdHEvXIIUcf fSIiHgODAeKpGDCiWJdHEvXIIUcf2 = new fSIiHgODAeKpGDCiWJdHEvXIIUcf();
						fSIiHgODAeKpGDCiWJdHEvXIIUcf2.HTORKFtatPpwtNCZcYFEdosuCimkA = inputMapCategory.JVVOzLwROUVfugiBddCMJRlYAMxBb[j];
						beukNuiOoMtNFZXULtVdSyJSSFaG beukNuiOoMtNFZXULtVdSyJSSFaG2 = cmivTcNFMrulznoPaNOhMjLmHitj.UwpAPIccxqsZCyfguDEnEFGBdQov.fgivMcCczvWCIHMgDBmehdkCQusCA.Find(fSIiHgODAeKpGDCiWJdHEvXIIUcf2.ofRQWVkNMlAIqjMgBDvkGtbPzWnFA);
						inputMapCategory.JVVOzLwROUVfugiBddCMJRlYAMxBb[j] = beukNuiOoMtNFZXULtVdSyJSSFaG2?.rvMBOHdgcSqhasACwNUMifxuVRNvA ?? (-1);
					}
				}
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.VTsuIoaDpNVgRaffGvaABsLabnxy = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.keyboardLayouts, P_2, ifVDRDNRlQIrefGUREftbZZhpiIyA2.VTsuIoaDpNVgRaffGvaABsLabnxy, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.VJGuWlqjLExwafUrnpGyrfUaVSNx, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.XWUIvGifrFQWHzjhRnEjkkMsvZdu, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.AHGHuBqSuRQPHbKZiCCUiRsFQgHw, ifVDRDNRlQIrefGUREftbZZhpiIyA2.bzKamscIsfMUjERHhXQZiHRiEJEXb);
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.qMuErAhjkHhLjaywDIYFOZVXIODec = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.mouseLayouts, P_2, ifVDRDNRlQIrefGUREftbZZhpiIyA2.qMuErAhjkHhLjaywDIYFOZVXIODec, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.xmvExzbawAxoyxRVtnZnybqQoHrl, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.dQYMnkfdJjVBgGMpWPcxHNjQFGTfA, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.RunkzESPvMBHHKptgyYacBXClEox, ifVDRDNRlQIrefGUREftbZZhpiIyA2.TUpHiRwCiwJMhiPXmPzvSJMMXeDk);
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.uOSQCpDANjSrGhIxvSYdqbSckCQe = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.joystickLayouts, P_2, ifVDRDNRlQIrefGUREftbZZhpiIyA2.uOSQCpDANjSrGhIxvSYdqbSckCQe, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.qsdmxTFhXaOiGMDuQauCQkrdzRXg, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.atBvBLNDiRNWWlsOVYsLICxCghUL, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.DomKPwHEzyPxMJeIUZZVFHGFAptm, ifVDRDNRlQIrefGUREftbZZhpiIyA2.ZTJDOentuYINiRSOaMGMlOAHglwE);
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.SiijEtKCRPeMVGATPRUUQocdrkQI = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.customControllerLayouts, P_2, ifVDRDNRlQIrefGUREftbZZhpiIyA2.SiijEtKCRPeMVGATPRUUQocdrkQI, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.IvUdZGXJVWkqyKPQHeAFEzWnrQhW, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.wVTzRDgJhsWfYzVsmojVEbxqQmXO, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.yKsSAVQWQWcpeFhfUriHzWzSSRBk, ifVDRDNRlQIrefGUREftbZZhpiIyA2.fXGNyaRbujgPkskhQQhBlnkRIJWbA);
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.HeqCbzDnDFYyCBQWoqXKDpxYBwcW = ifVDRDNRlQIrefGUREftbZZhpiIyA2.rBTxeffckgSgOgDfabyoqEMOEZts;
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.UwSvdwbWBHVZtqqunbXVHkYhUtOH = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Custom Controller", P_0.customControllers, P_1?.customControllers, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.customControllers, P_2, ifVDRDNRlQIrefGUREftbZZhpiIyA2.UwSvdwbWBHVZtqqunbXVHkYhUtOH, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.iOHDbvdASKlVaysnwAERFDtFKWStA, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.xQXmeDblXbBGsMbjdDaaztpqAbtCA, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.wAlzSSMnIitkEfwajHsFBACqKybG, ifVDRDNRlQIrefGUREftbZZhpiIyA2.zqxxBPCvckgAavWOwyLeSTivmbVA);
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.kgRtGkgAOMThAXdYuERFQyHbgVoF = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.controllerMapLayoutManagerRuleSets, P_2, ifVDRDNRlQIrefGUREftbZZhpiIyA2.kgRtGkgAOMThAXdYuERFQyHbgVoF, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.XxCRnDgLVlqBWTCsvSvWnfyaBPXE, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.zOOgkbKsuBPopJcyLqfDdmvXBeeeb, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.PLZYQAkHDKtdzjOHMDWJEKLxFCgBb, ifVDRDNRlQIrefGUREftbZZhpiIyA2.lUMixqGTftqCXJDpISbIKhIlMdJx);
				ifVDRDNRlQIrefGUREftbZZhpiIyA2.QdMByZaeLskgyPbFnFnctALHeRTEb = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.controllerMapEnablerRuleSets, P_2, ifVDRDNRlQIrefGUREftbZZhpiIyA2.QdMByZaeLskgyPbFnFnctALHeRTEb, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.GQHiLREfHmuzooaOklTBwQtnFhVgA, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.sYvCeUDNCJOZwCkLZIDsPexXpqTCb, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.bLOSRkfpBeyWpjJvYCnrcrUwJSOO, ifVDRDNRlQIrefGUREftbZZhpiIyA2.PEVDeQAOmzhODejeiXSdTzfBCEgFc);
				List<beukNuiOoMtNFZXULtVdSyJSSFaG> list = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Player", P_0.players, P_1?.players, ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.players, P_2, list, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.tdXBtUHKGhVZIczYUjZDtpeMuhJ, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.PBsEMGJmadmTnRWcAfeYJgQbbkJq, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.QtXmliazRbNfNtEzUjTqyqfTDcPDA, ifVDRDNRlQIrefGUREftbZZhpiIyA2.aSMHbwlSqlVAUIAVICIaPpKoDwQT);
				List<beukNuiOoMtNFZXULtVdSyJSSFaG> list2 = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				KrRrPpCdAXaXpuhQWvgEhYSBYplf krRrPpCdAXaXpuhQWvgEhYSBYplf = new KrRrPpCdAXaXpuhQWvgEhYSBYplf();
				krRrPpCdAXaXpuhQWvgEhYSBYplf.OVTnteWlBmEvHpCjXRjOXpaDxaKk = ifVDRDNRlQIrefGUREftbZZhpiIyA2;
				krRrPpCdAXaXpuhQWvgEhYSBYplf.PRzjaXnkGIFbtcWHBZEhPtkxqndN = krRrPpCdAXaXpuhQWvgEhYSBYplf.OVTnteWlBmEvHpCjXRjOXpaDxaKk.VTsuIoaDpNVgRaffGvaABsLabnxy;
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, krRrPpCdAXaXpuhQWvgEhYSBYplf.OVTnteWlBmEvHpCjXRjOXpaDxaKk.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.keyboardMaps, P_2, list2, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.TifFwpiUACqaOCuHCrmXwDaTgaeJc, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.vPmeWKplsMkBeBtycRdrMwZbmRiM, krRrPpCdAXaXpuhQWvgEhYSBYplf.jIjdxGJtJcabTAHgHmTQXTuNdzwx, krRrPpCdAXaXpuhQWvgEhYSBYplf.ntPPIbgkbArIvjcNEPvVQkVYCRXy);
				List<beukNuiOoMtNFZXULtVdSyJSSFaG> list3 = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				bGuVEhiMnuzBMIFcfhjaUcDIKkeL bGuVEhiMnuzBMIFcfhjaUcDIKkeL2 = new bGuVEhiMnuzBMIFcfhjaUcDIKkeL();
				bGuVEhiMnuzBMIFcfhjaUcDIKkeL2.IqhAJrBhLVKQooPHbaWxbCEFUwdO = ifVDRDNRlQIrefGUREftbZZhpiIyA2;
				bGuVEhiMnuzBMIFcfhjaUcDIKkeL2.ZxmJvXMzsMFLJXFghbMzJnFgYDjUA = bGuVEhiMnuzBMIFcfhjaUcDIKkeL2.IqhAJrBhLVKQooPHbaWxbCEFUwdO.qMuErAhjkHhLjaywDIYFOZVXIODec;
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, bGuVEhiMnuzBMIFcfhjaUcDIKkeL2.IqhAJrBhLVKQooPHbaWxbCEFUwdO.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.mouseMaps, P_2, list3, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.fFAuiDZVpDxjrMTEkQZvgLoSrReX, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.CpqETqmLsrZLxQCWBTQYutPAnDxK, bGuVEhiMnuzBMIFcfhjaUcDIKkeL2.nRoXTRQIdjyomnlKYomUTYNRKnbn, bGuVEhiMnuzBMIFcfhjaUcDIKkeL2.gfEIgNXVEBmbMVfVCgJxWexRfkhC);
				List<beukNuiOoMtNFZXULtVdSyJSSFaG> list4 = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				SZJNyOBjJQwuUOomVtUzNJaoWQzP sZJNyOBjJQwuUOomVtUzNJaoWQzP = new SZJNyOBjJQwuUOomVtUzNJaoWQzP();
				sZJNyOBjJQwuUOomVtUzNJaoWQzP.ezBubgscptPEzidYRELLjNwfjcvsA = ifVDRDNRlQIrefGUREftbZZhpiIyA2;
				sZJNyOBjJQwuUOomVtUzNJaoWQzP.fexwRjZUjatSjSVLGMVzdpbrAMnD = sZJNyOBjJQwuUOomVtUzNJaoWQzP.ezBubgscptPEzidYRELLjNwfjcvsA.uOSQCpDANjSrGhIxvSYdqbSckCQe;
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, sZJNyOBjJQwuUOomVtUzNJaoWQzP.ezBubgscptPEzidYRELLjNwfjcvsA.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.joystickMaps, P_2, list4, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.tiSFjcDZMMKvWFZAWwDKSwMDxhwIA, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.gDoYpbdkvtELJFpGkBLFKtvtwrLHA, sZJNyOBjJQwuUOomVtUzNJaoWQzP.EMugszjqafdsIMjAidWgdULjdebxA, sZJNyOBjJQwuUOomVtUzNJaoWQzP.yvQZgnLkCERudveADHNtIBIcQhIr);
				List<beukNuiOoMtNFZXULtVdSyJSSFaG> list5 = new List<beukNuiOoMtNFZXULtVdSyJSSFaG>();
				XRfAbbhETbrPJEjWIObhpBmCfQHsA xRfAbbhETbrPJEjWIObhpBmCfQHsA = new XRfAbbhETbrPJEjWIObhpBmCfQHsA();
				xRfAbbhETbrPJEjWIObhpBmCfQHsA.vusMjXxdihMBxfHRBAQZBsAvBFCSA = ifVDRDNRlQIrefGUREftbZZhpiIyA2;
				xRfAbbhETbrPJEjWIObhpBmCfQHsA.PXqKkoXKwYplaHvkjCfNJyJOWCaW = xRfAbbhETbrPJEjWIObhpBmCfQHsA.vusMjXxdihMBxfHRBAQZBsAvBFCSA.SiijEtKCRPeMVGATPRUUQocdrkQI;
				rOoWtqrTNsRARqBLQOGkGzIuQcMF("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, xRfAbbhETbrPJEjWIObhpBmCfQHsA.vusMjXxdihMBxfHRBAQZBsAvBFCSA.YRXeVoHSlVhzOtaQIifrpSNOPtnyA.customControllerMaps, P_2, list5, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.MsUEKQZdljAMjaZBsPfdZYZWAZyr, jtVfVXySyCNEusvAXAWzakLzcjLv._003C_003E9.aGqPYksMSNPUbGFoNWTnKrviHKOk, xRfAbbhETbrPJEjWIObhpBmCfQHsA.mNvgTZWITXOfUVGjjCqzGVekDCDU, xRfAbbhETbrPJEjWIObhpBmCfQHsA.EmZWapBZLMKnNRzvKZjgqETTKQgk);
				return ifVDRDNRlQIrefGUREftbZZhpiIyA2.YRXeVoHSlVhzOtaQIifrpSNOPtnyA;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void TkbUXjfdRiCyxVFweakhIBoHHhiE(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void lrzABLdfLqzrAbmIOApLBnEusyMD<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
			{
				for (int i = 0; i < P_0.Count; i++)
				{
					P_2.Add(P_0[i]);
				}
				if (P_1 == null)
				{
					return;
				}
				for (int j = 0; j < P_1.Count; j++)
				{
					_0001 val = P_1[j];
					int num = P_3(val, P_2);
					if (num >= 0)
					{
						P_2[num] = val;
					}
					else
					{
						P_2.Add(val);
					}
				}
			}

			private static void rOoWtqrTNsRARqBLQOGkGzIuQcMF<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<beukNuiOoMtNFZXULtVdSyJSSFaG> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<jJztNzSTXhVHmDpnYqoUuGrIcJKO<_0001>, _0001> P_9) where _0001 : class
			{
				XociJPAKdJNYZNbknmQztoHLvBzp<_0001> xociJPAKdJNYZNbknmQztoHLvBzp = new XociJPAKdJNYZNbknmQztoHLvBzp<_0001>();
				xociJPAKdJNYZNbknmQztoHLvBzp.JQGzROHXryAgfAcqzMhCgouVSVzF = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					_0001 val = P_1[i];
					if (P_4)
					{
						P_5.Add(new beukNuiOoMtNFZXULtVdSyJSSFaG(xociJPAKdJNYZNbknmQztoHLvBzp.JQGzROHXryAgfAcqzMhCgouVSVzF(val), -1, xociJPAKdJNYZNbknmQztoHLvBzp.JQGzROHXryAgfAcqzMhCgouVSVzF(val)));
						continue;
					}
					_0001 arg = P_9(new jJztNzSTXhVHmDpnYqoUuGrIcJKO<_0001>(val, null, beukNuiOoMtNFZXULtVdSyJSSFaG.BURnnLtJTtAlYqmPFAUVbuOfQUKk.origId, P_3, false));
					P_5.Add(new beukNuiOoMtNFZXULtVdSyJSSFaG(xociJPAKdJNYZNbknmQztoHLvBzp.JQGzROHXryAgfAcqzMhCgouVSVzF(val), -1, xociJPAKdJNYZNbknmQztoHLvBzp.JQGzROHXryAgfAcqzMhCgouVSVzF(arg)));
				}
				if (P_2 == null)
				{
					return;
				}
				for (int j = 0; j < P_2.Count; j++)
				{
					_0001 val2 = P_2[j];
					int num = P_8(val2, P_3);
					if (num >= 0)
					{
						bSMaxUGipXrSIqgGWLrPqwTMArveb<_0001> bSMaxUGipXrSIqgGWLrPqwTMArveb2 = new bSMaxUGipXrSIqgGWLrPqwTMArveb<_0001>();
						bSMaxUGipXrSIqgGWLrPqwTMArveb2.AjsZGsVvxDBKdpEAmNGREmHPsaOR = xociJPAKdJNYZNbknmQztoHLvBzp;
						_0001 val3 = P_3[num];
						bSMaxUGipXrSIqgGWLrPqwTMArveb2.heSsfkUpDeuxbhxXsHcmxlWQEPQn = P_9(new jJztNzSTXhVHmDpnYqoUuGrIcJKO<_0001>(val2, val3, beukNuiOoMtNFZXULtVdSyJSSFaG.BURnnLtJTtAlYqmPFAUVbuOfQUKk.otherId, P_3, true));
						P_5.Find(bSMaxUGipXrSIqgGWLrPqwTMArveb2.QzfbFegSTsGLpqUEJnWuMVllOUNdb).siqcSXGgjDsmBJwsXxRecOOxOQjG = bSMaxUGipXrSIqgGWLrPqwTMArveb2.AjsZGsVvxDBKdpEAmNGREmHPsaOR.JQGzROHXryAgfAcqzMhCgouVSVzF(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						_0001 arg2 = P_9(new jJztNzSTXhVHmDpnYqoUuGrIcJKO<_0001>(val2, null, beukNuiOoMtNFZXULtVdSyJSSFaG.BURnnLtJTtAlYqmPFAUVbuOfQUKk.otherId, P_3, false));
						P_5.Add(new beukNuiOoMtNFZXULtVdSyJSSFaG(-1, xociJPAKdJNYZNbknmQztoHLvBzp.JQGzROHXryAgfAcqzMhCgouVSVzF(val2), xociJPAKdJNYZNbknmQztoHLvBzp.JQGzROHXryAgfAcqzMhCgouVSVzF(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}
		}

		[Serializable]
		private sealed class KPYXPzrHQmXXTKUvLpjZWujwaDxX
		{
			public static readonly KPYXPzrHQmXXTKUvLpjZWujwaDxX _003C_003E9 = new KPYXPzrHQmXXTKUvLpjZWujwaDxX();

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__199_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__217_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__233_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__249_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__265_0;

			internal void SrcOWmWADDPniiuJyObBhWyxTtMi(List<Player_Editor.Mapping> P_0, int P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				for (int num = P_0.Count - 1; num >= 0; num--)
				{
					if (P_0[num] == null || P_0[num].categoryId == P_1)
					{
						P_0.RemoveAt(num);
					}
				}
			}

			internal void eIRbHjBKITfzqDbTFkuBkycKZtMN(List<Player_Editor.Mapping> P_0, int P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				for (int num = P_0.Count - 1; num >= 0; num--)
				{
					if (P_0[num] == null || P_0[num].layoutId == P_1)
					{
						P_0.RemoveAt(num);
					}
				}
			}

			internal void sxUKlPEDMEnewgAcDGkfZVxxwsvm(List<Player_Editor.Mapping> P_0, int P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				for (int num = P_0.Count - 1; num >= 0; num--)
				{
					if (P_0[num] == null || P_0[num].layoutId == P_1)
					{
						P_0.RemoveAt(num);
					}
				}
			}

			internal void BfcgloFipPQIElztcuxfljvYpFum(List<Player_Editor.Mapping> P_0, int P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				for (int num = P_0.Count - 1; num >= 0; num--)
				{
					if (P_0[num] == null || P_0[num].layoutId == P_1)
					{
						P_0.RemoveAt(num);
					}
				}
			}

			internal void rgVPGEJjFHudWDgIOpxolYcLTHkc(List<Player_Editor.Mapping> P_0, int P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				for (int num = P_0.Count - 1; num >= 0; num--)
				{
					if (P_0[num] == null || P_0[num].layoutId == P_1)
					{
						P_0.RemoveAt(num);
					}
				}
			}
		}

		private sealed class tkZDUeleHCsCkJnUdzutURUEqVQX
		{
			public List<InputLayout> ogSCBYXHwXnWpvuJPAihYWavDHfp;

			internal int UVyjhlsRAZLYlbgCJSVQNlCtpBpN(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				pFrgYLQKtTciZCHNEeGPDlGbZgXRB pFrgYLQKtTciZCHNEeGPDlGbZgXRB2 = new pFrgYLQKtTciZCHNEeGPDlGbZgXRB();
				pFrgYLQKtTciZCHNEeGPDlGbZgXRB2.yEDnnCvPKszoImCweQAzsbrWuyVH = P_0;
				pFrgYLQKtTciZCHNEeGPDlGbZgXRB2.oRAdWOFbmFqriKEJKqLgcXtrSGYFb = P_1;
				int num = ogSCBYXHwXnWpvuJPAihYWavDHfp.FindIndex(pFrgYLQKtTciZCHNEeGPDlGbZgXRB2.SfmsLjhMUwnWTRyEVakMpelmeUsd);
				int num2 = ogSCBYXHwXnWpvuJPAihYWavDHfp.FindIndex(pFrgYLQKtTciZCHNEeGPDlGbZgXRB2.UiGAgXSckQtSxqxmTISgRBupPJYr);
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

		private sealed class pFrgYLQKtTciZCHNEeGPDlGbZgXRB
		{
			public ControllerMap_Editor yEDnnCvPKszoImCweQAzsbrWuyVH;

			public ControllerMap_Editor oRAdWOFbmFqriKEJKqLgcXtrSGYFb;

			internal bool SfmsLjhMUwnWTRyEVakMpelmeUsd(InputLayout P_0)
			{
				return P_0.id == yEDnnCvPKszoImCweQAzsbrWuyVH.id;
			}

			internal bool UiGAgXSckQtSxqxmTISgRBupPJYr(InputLayout P_0)
			{
				return P_0.id == oRAdWOFbmFqriKEJKqLgcXtrSGYFb.id;
			}
		}

		private sealed class hCAapfmuJBcdtMGmFUJfNYrrhCFD : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int XhnbgjjelqYbBFqWgCDMefHNgNwL;

			private InputCategory PIaADioVgrwsqSNAonUOjLmnlfao;

			private int UepBKSgopyuBVgiqNEIkCPJMuhom;

			private string WNjPolHufGINGzGDUcXxaPrzTSPW;

			public string NzNRkThytkMWgmXKOpLvzlKGJmAH;

			public UserData SCeKwyAHIJSLtxhcGiGSlXVPKLqG;

			private int qAOBfBrIEgCgiHIYmfldgeQPBslw;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return PIaADioVgrwsqSNAonUOjLmnlfao;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return PIaADioVgrwsqSNAonUOjLmnlfao;
				}
			}

			[DebuggerHidden]
			public hCAapfmuJBcdtMGmFUJfNYrrhCFD(int P_0)
			{
				XhnbgjjelqYbBFqWgCDMefHNgNwL = P_0;
				UepBKSgopyuBVgiqNEIkCPJMuhom = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				XhnbgjjelqYbBFqWgCDMefHNgNwL = -2;
			}

			private bool MoveNext()
			{
				int xhnbgjjelqYbBFqWgCDMefHNgNwL = XhnbgjjelqYbBFqWgCDMefHNgNwL;
				UserData sCeKwyAHIJSLtxhcGiGSlXVPKLqG = SCeKwyAHIJSLtxhcGiGSlXVPKLqG;
				if (xhnbgjjelqYbBFqWgCDMefHNgNwL != 0)
				{
					if (xhnbgjjelqYbBFqWgCDMefHNgNwL != 1)
					{
						return false;
					}
					XhnbgjjelqYbBFqWgCDMefHNgNwL = -1;
					goto IL_0098;
				}
				XhnbgjjelqYbBFqWgCDMefHNgNwL = -1;
				if (WNjPolHufGINGzGDUcXxaPrzTSPW == null || WNjPolHufGINGzGDUcXxaPrzTSPW == string.Empty)
				{
					return false;
				}
				if (sCeKwyAHIJSLtxhcGiGSlXVPKLqG.actionCategories == null)
				{
					return false;
				}
				qAOBfBrIEgCgiHIYmfldgeQPBslw = 0;
				goto IL_00a8;
				IL_00a8:
				if (qAOBfBrIEgCgiHIYmfldgeQPBslw < sCeKwyAHIJSLtxhcGiGSlXVPKLqG.actionCategories.Count)
				{
					if (sCeKwyAHIJSLtxhcGiGSlXVPKLqG.actionCategories[qAOBfBrIEgCgiHIYmfldgeQPBslw].tag.Equals(WNjPolHufGINGzGDUcXxaPrzTSPW, StringComparison.OrdinalIgnoreCase))
					{
						PIaADioVgrwsqSNAonUOjLmnlfao = sCeKwyAHIJSLtxhcGiGSlXVPKLqG.actionCategories[qAOBfBrIEgCgiHIYmfldgeQPBslw];
						XhnbgjjelqYbBFqWgCDMefHNgNwL = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				qAOBfBrIEgCgiHIYmfldgeQPBslw++;
				goto IL_00a8;
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

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				hCAapfmuJBcdtMGmFUJfNYrrhCFD hCAapfmuJBcdtMGmFUJfNYrrhCFD2;
				if (XhnbgjjelqYbBFqWgCDMefHNgNwL == -2 && UepBKSgopyuBVgiqNEIkCPJMuhom == Environment.CurrentManagedThreadId)
				{
					XhnbgjjelqYbBFqWgCDMefHNgNwL = 0;
					hCAapfmuJBcdtMGmFUJfNYrrhCFD2 = this;
				}
				else
				{
					hCAapfmuJBcdtMGmFUJfNYrrhCFD2 = new hCAapfmuJBcdtMGmFUJfNYrrhCFD(0);
					hCAapfmuJBcdtMGmFUJfNYrrhCFD2.SCeKwyAHIJSLtxhcGiGSlXVPKLqG = SCeKwyAHIJSLtxhcGiGSlXVPKLqG;
				}
				hCAapfmuJBcdtMGmFUJfNYrrhCFD2.WNjPolHufGINGzGDUcXxaPrzTSPW = NzNRkThytkMWgmXKOpLvzlKGJmAH;
				return hCAapfmuJBcdtMGmFUJfNYrrhCFD2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class QTgUMCDgbOFEGBTclOfanNUUgjOib : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int odLIhneztXKgxwNJeGhAiIEuTNJe;

			private InputAction MdOClzXDWBvvsPbZCGNWBjssfWuJA;

			private int JivFTZBddoyPfKBuaxTFEnsmvkNUA;

			public UserData aiKGcmDoGFZKOuWvFzpNSHztSupeA;

			private string raJWNCubLoVTlbBFIeOnJlXUUbKm;

			public string dvxHHhhNKRYBWTnOztbxBeSlmCJf;

			private int hlIMqlOgMwcPfbCyOSSDSJtPZpHVA;

			private int fxASbzXmwavFVGOmrKZrbnvHpQzW;

			private InputCategory TbcakKHVMEKcAuOYQhACXaOapAgK;

			private int abRjLtzNbphjHrjPtnqTlKqEbrhcA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return MdOClzXDWBvvsPbZCGNWBjssfWuJA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return MdOClzXDWBvvsPbZCGNWBjssfWuJA;
				}
			}

			[DebuggerHidden]
			public QTgUMCDgbOFEGBTclOfanNUUgjOib(int P_0)
			{
				odLIhneztXKgxwNJeGhAiIEuTNJe = P_0;
				JivFTZBddoyPfKBuaxTFEnsmvkNUA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				TbcakKHVMEKcAuOYQhACXaOapAgK = null;
				odLIhneztXKgxwNJeGhAiIEuTNJe = -2;
			}

			private bool MoveNext()
			{
				int num = odLIhneztXKgxwNJeGhAiIEuTNJe;
				UserData userData = aiKGcmDoGFZKOuWvFzpNSHztSupeA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					odLIhneztXKgxwNJeGhAiIEuTNJe = -1;
					goto IL_00fd;
				}
				odLIhneztXKgxwNJeGhAiIEuTNJe = -1;
				if (userData.dUYEBfdxdeFmejEEDExIosmzBhsr == null || userData.actionCategories == null)
				{
					return false;
				}
				if (raJWNCubLoVTlbBFIeOnJlXUUbKm == null || raJWNCubLoVTlbBFIeOnJlXUUbKm == string.Empty)
				{
					return false;
				}
				hlIMqlOgMwcPfbCyOSSDSJtPZpHVA = userData.dUYEBfdxdeFmejEEDExIosmzBhsr.Count;
				fxASbzXmwavFVGOmrKZrbnvHpQzW = 0;
				goto IL_0132;
				IL_0122:
				fxASbzXmwavFVGOmrKZrbnvHpQzW++;
				goto IL_0132;
				IL_00fd:
				abRjLtzNbphjHrjPtnqTlKqEbrhcA++;
				goto IL_010d;
				IL_010d:
				if (abRjLtzNbphjHrjPtnqTlKqEbrhcA < hlIMqlOgMwcPfbCyOSSDSJtPZpHVA)
				{
					if (TbcakKHVMEKcAuOYQhACXaOapAgK.id == userData.dUYEBfdxdeFmejEEDExIosmzBhsr[abRjLtzNbphjHrjPtnqTlKqEbrhcA].categoryId)
					{
						MdOClzXDWBvvsPbZCGNWBjssfWuJA = userData.dUYEBfdxdeFmejEEDExIosmzBhsr[abRjLtzNbphjHrjPtnqTlKqEbrhcA];
						odLIhneztXKgxwNJeGhAiIEuTNJe = 1;
						return true;
					}
					goto IL_00fd;
				}
				TbcakKHVMEKcAuOYQhACXaOapAgK = null;
				goto IL_0122;
				IL_0132:
				if (fxASbzXmwavFVGOmrKZrbnvHpQzW < userData.actionCategories.Count)
				{
					if (userData.actionCategories[fxASbzXmwavFVGOmrKZrbnvHpQzW].tag.Equals(raJWNCubLoVTlbBFIeOnJlXUUbKm, StringComparison.OrdinalIgnoreCase))
					{
						TbcakKHVMEKcAuOYQhACXaOapAgK = userData.actionCategories[fxASbzXmwavFVGOmrKZrbnvHpQzW];
						abRjLtzNbphjHrjPtnqTlKqEbrhcA = 0;
						goto IL_010d;
					}
					goto IL_0122;
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

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				QTgUMCDgbOFEGBTclOfanNUUgjOib qTgUMCDgbOFEGBTclOfanNUUgjOib;
				if (odLIhneztXKgxwNJeGhAiIEuTNJe == -2 && JivFTZBddoyPfKBuaxTFEnsmvkNUA == Environment.CurrentManagedThreadId)
				{
					odLIhneztXKgxwNJeGhAiIEuTNJe = 0;
					qTgUMCDgbOFEGBTclOfanNUUgjOib = this;
				}
				else
				{
					qTgUMCDgbOFEGBTclOfanNUUgjOib = new QTgUMCDgbOFEGBTclOfanNUUgjOib(0);
					qTgUMCDgbOFEGBTclOfanNUUgjOib.aiKGcmDoGFZKOuWvFzpNSHztSupeA = aiKGcmDoGFZKOuWvFzpNSHztSupeA;
				}
				qTgUMCDgbOFEGBTclOfanNUUgjOib.raJWNCubLoVTlbBFIeOnJlXUUbKm = dvxHHhhNKRYBWTnOztbxBeSlmCJf;
				return qTgUMCDgbOFEGBTclOfanNUUgjOib;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class qCDYlDpIQQCXgPTefqMpYMZrTDLT : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int WpBriTToEmgaogVouhNYLpAemQZT;

			private InputAction RsBlcHcwwQBmwlXtdlIwWlZQlpXy;

			private int ktBqIHgOAzRIWULuZuLgtpYbFynE;

			public UserData IsuSoJdZkESjytQSKCfCRLFRbscq;

			private bool lIYwQvpGOCxdXMtkzcwJssHjrXOJ;

			public bool TXLcrUdEOrHNOoTHAvAEgSNXpRPeA;

			private int tMYahUeLtGyjAGawgzIgzyoVzwRe;

			public int vLebauBasmtmfpyMcYyejLTibwIGb;

			private IEnumerator<int> LUtTRvqbrQwRvljiYPndVaYlEGRIA;

			private int alrAhNlPkPUlYjCQesXJqFImkRmE;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return RsBlcHcwwQBmwlXtdlIwWlZQlpXy;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RsBlcHcwwQBmwlXtdlIwWlZQlpXy;
				}
			}

			[DebuggerHidden]
			public qCDYlDpIQQCXgPTefqMpYMZrTDLT(int P_0)
			{
				WpBriTToEmgaogVouhNYLpAemQZT = P_0;
				ktBqIHgOAzRIWULuZuLgtpYbFynE = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int wpBriTToEmgaogVouhNYLpAemQZT = WpBriTToEmgaogVouhNYLpAemQZT;
				if (wpBriTToEmgaogVouhNYLpAemQZT == -3 || wpBriTToEmgaogVouhNYLpAemQZT == 1)
				{
					try
					{
					}
					finally
					{
						LxOTKCnEzNFCqycumDFcPXSPzAuJ();
					}
				}
				LUtTRvqbrQwRvljiYPndVaYlEGRIA = null;
				WpBriTToEmgaogVouhNYLpAemQZT = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int wpBriTToEmgaogVouhNYLpAemQZT = WpBriTToEmgaogVouhNYLpAemQZT;
					UserData isuSoJdZkESjytQSKCfCRLFRbscq = IsuSoJdZkESjytQSKCfCRLFRbscq;
					switch (wpBriTToEmgaogVouhNYLpAemQZT)
					{
					default:
						return false;
					case 0:
						WpBriTToEmgaogVouhNYLpAemQZT = -1;
						if (isuSoJdZkESjytQSKCfCRLFRbscq.dUYEBfdxdeFmejEEDExIosmzBhsr == null || isuSoJdZkESjytQSKCfCRLFRbscq.actionCategories == null)
						{
							return false;
						}
						if (lIYwQvpGOCxdXMtkzcwJssHjrXOJ)
						{
							LUtTRvqbrQwRvljiYPndVaYlEGRIA = isuSoJdZkESjytQSKCfCRLFRbscq.SortedActionIdsInCategory(tMYahUeLtGyjAGawgzIgzyoVzwRe).GetEnumerator();
							WpBriTToEmgaogVouhNYLpAemQZT = -3;
							goto IL_00a5;
						}
						alrAhNlPkPUlYjCQesXJqFImkRmE = 0;
						goto IL_0123;
					case 1:
						WpBriTToEmgaogVouhNYLpAemQZT = -3;
						goto IL_00a5;
					case 2:
						{
							WpBriTToEmgaogVouhNYLpAemQZT = -1;
							goto IL_0111;
						}
						IL_0123:
						if (alrAhNlPkPUlYjCQesXJqFImkRmE >= isuSoJdZkESjytQSKCfCRLFRbscq.dUYEBfdxdeFmejEEDExIosmzBhsr.Count)
						{
							break;
						}
						if (isuSoJdZkESjytQSKCfCRLFRbscq.dUYEBfdxdeFmejEEDExIosmzBhsr[alrAhNlPkPUlYjCQesXJqFImkRmE].categoryId == tMYahUeLtGyjAGawgzIgzyoVzwRe)
						{
							RsBlcHcwwQBmwlXtdlIwWlZQlpXy = isuSoJdZkESjytQSKCfCRLFRbscq.dUYEBfdxdeFmejEEDExIosmzBhsr[alrAhNlPkPUlYjCQesXJqFImkRmE];
							WpBriTToEmgaogVouhNYLpAemQZT = 2;
							return true;
						}
						goto IL_0111;
						IL_0111:
						alrAhNlPkPUlYjCQesXJqFImkRmE++;
						goto IL_0123;
						IL_00a5:
						while (LUtTRvqbrQwRvljiYPndVaYlEGRIA.MoveNext())
						{
							int current = LUtTRvqbrQwRvljiYPndVaYlEGRIA.Current;
							InputAction actionById = isuSoJdZkESjytQSKCfCRLFRbscq.GetActionById(current);
							if (actionById != null)
							{
								RsBlcHcwwQBmwlXtdlIwWlZQlpXy = actionById;
								WpBriTToEmgaogVouhNYLpAemQZT = 1;
								return true;
							}
						}
						LxOTKCnEzNFCqycumDFcPXSPzAuJ();
						LUtTRvqbrQwRvljiYPndVaYlEGRIA = null;
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

			private void LxOTKCnEzNFCqycumDFcPXSPzAuJ()
			{
				WpBriTToEmgaogVouhNYLpAemQZT = -1;
				if (LUtTRvqbrQwRvljiYPndVaYlEGRIA != null)
				{
					LUtTRvqbrQwRvljiYPndVaYlEGRIA.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				qCDYlDpIQQCXgPTefqMpYMZrTDLT qCDYlDpIQQCXgPTefqMpYMZrTDLT2;
				if (WpBriTToEmgaogVouhNYLpAemQZT == -2 && ktBqIHgOAzRIWULuZuLgtpYbFynE == Environment.CurrentManagedThreadId)
				{
					WpBriTToEmgaogVouhNYLpAemQZT = 0;
					qCDYlDpIQQCXgPTefqMpYMZrTDLT2 = this;
				}
				else
				{
					qCDYlDpIQQCXgPTefqMpYMZrTDLT2 = new qCDYlDpIQQCXgPTefqMpYMZrTDLT(0);
					qCDYlDpIQQCXgPTefqMpYMZrTDLT2.IsuSoJdZkESjytQSKCfCRLFRbscq = IsuSoJdZkESjytQSKCfCRLFRbscq;
				}
				qCDYlDpIQQCXgPTefqMpYMZrTDLT2.tMYahUeLtGyjAGawgzIgzyoVzwRe = vLebauBasmtmfpyMcYyejLTibwIGb;
				qCDYlDpIQQCXgPTefqMpYMZrTDLT2.lIYwQvpGOCxdXMtkzcwJssHjrXOJ = TXLcrUdEOrHNOoTHAvAEgSNXpRPeA;
				return qCDYlDpIQQCXgPTefqMpYMZrTDLT2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class TUdJOUcXSCfbCpHwimQMGexPYqZU : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int ERMrrDUwaoJvrcvMaSPsasACntTq;

			private InputAction DgMuTeQLbRhcYLZOfhtlrPethVVeA;

			private int YKDJeScKATIqwEleHoYunOeGIumsA;

			public UserData RJTrzcXFVWQbRwiIteiMWFKhcewEA;

			private string WuRUELwlGSeEjrkdIyvUbuwYQrOx;

			public string cCBuWrcCiDRfZvEumanTSHkpejNK;

			private bool xQRxiySMscOfnLwcETisANZOiUtD;

			public bool EcUGywxrCtSItLrXqckKlnwXJdVF;

			private InputCategory ScnLBDLidTOyqfmxEqQgUBFWxbUU;

			private IEnumerator<int> nScLQVuDmYxZjtignfcAEIbgOvFP;

			private int kdEtYxWvxmfpmhnKmlzOtSlrewXG;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return DgMuTeQLbRhcYLZOfhtlrPethVVeA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DgMuTeQLbRhcYLZOfhtlrPethVVeA;
				}
			}

			[DebuggerHidden]
			public TUdJOUcXSCfbCpHwimQMGexPYqZU(int P_0)
			{
				ERMrrDUwaoJvrcvMaSPsasACntTq = P_0;
				YKDJeScKATIqwEleHoYunOeGIumsA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int eRMrrDUwaoJvrcvMaSPsasACntTq = ERMrrDUwaoJvrcvMaSPsasACntTq;
				if (eRMrrDUwaoJvrcvMaSPsasACntTq == -3 || eRMrrDUwaoJvrcvMaSPsasACntTq == 1)
				{
					try
					{
					}
					finally
					{
						tcxehwCvZhnpSOkvQYsULgyZUfdv();
					}
				}
				ScnLBDLidTOyqfmxEqQgUBFWxbUU = null;
				nScLQVuDmYxZjtignfcAEIbgOvFP = null;
				ERMrrDUwaoJvrcvMaSPsasACntTq = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int eRMrrDUwaoJvrcvMaSPsasACntTq = ERMrrDUwaoJvrcvMaSPsasACntTq;
					UserData rJTrzcXFVWQbRwiIteiMWFKhcewEA = RJTrzcXFVWQbRwiIteiMWFKhcewEA;
					switch (eRMrrDUwaoJvrcvMaSPsasACntTq)
					{
					default:
						return false;
					case 0:
					{
						ERMrrDUwaoJvrcvMaSPsasACntTq = -1;
						if (rJTrzcXFVWQbRwiIteiMWFKhcewEA.dUYEBfdxdeFmejEEDExIosmzBhsr == null || rJTrzcXFVWQbRwiIteiMWFKhcewEA.actionCategories == null)
						{
							return false;
						}
						if (WuRUELwlGSeEjrkdIyvUbuwYQrOx == null || WuRUELwlGSeEjrkdIyvUbuwYQrOx == string.Empty)
						{
							return false;
						}
						int num = rJTrzcXFVWQbRwiIteiMWFKhcewEA.IndexOfActionCategory(WuRUELwlGSeEjrkdIyvUbuwYQrOx);
						if (num < 0)
						{
							return false;
						}
						ScnLBDLidTOyqfmxEqQgUBFWxbUU = rJTrzcXFVWQbRwiIteiMWFKhcewEA.GetActionCategory(num);
						if (xQRxiySMscOfnLwcETisANZOiUtD)
						{
							nScLQVuDmYxZjtignfcAEIbgOvFP = rJTrzcXFVWQbRwiIteiMWFKhcewEA.SortedActionIdsInCategory(ScnLBDLidTOyqfmxEqQgUBFWxbUU.id).GetEnumerator();
							ERMrrDUwaoJvrcvMaSPsasACntTq = -3;
							goto IL_00f2;
						}
						kdEtYxWvxmfpmhnKmlzOtSlrewXG = 0;
						goto IL_0175;
					}
					case 1:
						ERMrrDUwaoJvrcvMaSPsasACntTq = -3;
						goto IL_00f2;
					case 2:
						{
							ERMrrDUwaoJvrcvMaSPsasACntTq = -1;
							goto IL_0163;
						}
						IL_0175:
						if (kdEtYxWvxmfpmhnKmlzOtSlrewXG >= rJTrzcXFVWQbRwiIteiMWFKhcewEA.dUYEBfdxdeFmejEEDExIosmzBhsr.Count)
						{
							break;
						}
						if (rJTrzcXFVWQbRwiIteiMWFKhcewEA.dUYEBfdxdeFmejEEDExIosmzBhsr[kdEtYxWvxmfpmhnKmlzOtSlrewXG].categoryId == ScnLBDLidTOyqfmxEqQgUBFWxbUU.id)
						{
							DgMuTeQLbRhcYLZOfhtlrPethVVeA = rJTrzcXFVWQbRwiIteiMWFKhcewEA.dUYEBfdxdeFmejEEDExIosmzBhsr[kdEtYxWvxmfpmhnKmlzOtSlrewXG];
							ERMrrDUwaoJvrcvMaSPsasACntTq = 2;
							return true;
						}
						goto IL_0163;
						IL_00f2:
						while (nScLQVuDmYxZjtignfcAEIbgOvFP.MoveNext())
						{
							int current = nScLQVuDmYxZjtignfcAEIbgOvFP.Current;
							InputAction actionById = rJTrzcXFVWQbRwiIteiMWFKhcewEA.GetActionById(current);
							if (actionById != null)
							{
								DgMuTeQLbRhcYLZOfhtlrPethVVeA = actionById;
								ERMrrDUwaoJvrcvMaSPsasACntTq = 1;
								return true;
							}
						}
						tcxehwCvZhnpSOkvQYsULgyZUfdv();
						nScLQVuDmYxZjtignfcAEIbgOvFP = null;
						break;
						IL_0163:
						kdEtYxWvxmfpmhnKmlzOtSlrewXG++;
						goto IL_0175;
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

			private void tcxehwCvZhnpSOkvQYsULgyZUfdv()
			{
				ERMrrDUwaoJvrcvMaSPsasACntTq = -1;
				if (nScLQVuDmYxZjtignfcAEIbgOvFP != null)
				{
					nScLQVuDmYxZjtignfcAEIbgOvFP.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				TUdJOUcXSCfbCpHwimQMGexPYqZU tUdJOUcXSCfbCpHwimQMGexPYqZU;
				if (ERMrrDUwaoJvrcvMaSPsasACntTq == -2 && YKDJeScKATIqwEleHoYunOeGIumsA == Environment.CurrentManagedThreadId)
				{
					ERMrrDUwaoJvrcvMaSPsasACntTq = 0;
					tUdJOUcXSCfbCpHwimQMGexPYqZU = this;
				}
				else
				{
					tUdJOUcXSCfbCpHwimQMGexPYqZU = new TUdJOUcXSCfbCpHwimQMGexPYqZU(0);
					tUdJOUcXSCfbCpHwimQMGexPYqZU.RJTrzcXFVWQbRwiIteiMWFKhcewEA = RJTrzcXFVWQbRwiIteiMWFKhcewEA;
				}
				tUdJOUcXSCfbCpHwimQMGexPYqZU.WuRUELwlGSeEjrkdIyvUbuwYQrOx = cCBuWrcCiDRfZvEumanTSHkpejNK;
				tUdJOUcXSCfbCpHwimQMGexPYqZU.xQRxiySMscOfnLwcETisANZOiUtD = EcUGywxrCtSItLrXqckKlnwXJdVF;
				return tUdJOUcXSCfbCpHwimQMGexPYqZU;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class wEyPWxpXcAkWhRkXgdPyibKpXoLd : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int NDorzMXyjslEPdLsyaALUEBoSpfm;

			private InputMapCategory lYcBxKeXRiOTJQjDSoGkGtaSQmFj;

			private int QWnpnszMwWPCjljVbAiWfzwpwjTC;

			private string dCnrTPxCehTyZjMFJDLGXzwPNMhn;

			public string YUasNxjqCaGdPchmfurSNvczQbcwA;

			public UserData ITHjdcHikbBPeGMwcPZWQNlJQaRL;

			private int SOZnTpTAzQbMsCqoPTTcDyyyffXf;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return lYcBxKeXRiOTJQjDSoGkGtaSQmFj;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return lYcBxKeXRiOTJQjDSoGkGtaSQmFj;
				}
			}

			[DebuggerHidden]
			public wEyPWxpXcAkWhRkXgdPyibKpXoLd(int P_0)
			{
				NDorzMXyjslEPdLsyaALUEBoSpfm = P_0;
				QWnpnszMwWPCjljVbAiWfzwpwjTC = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				NDorzMXyjslEPdLsyaALUEBoSpfm = -2;
			}

			private bool MoveNext()
			{
				int nDorzMXyjslEPdLsyaALUEBoSpfm = NDorzMXyjslEPdLsyaALUEBoSpfm;
				UserData iTHjdcHikbBPeGMwcPZWQNlJQaRL = ITHjdcHikbBPeGMwcPZWQNlJQaRL;
				if (nDorzMXyjslEPdLsyaALUEBoSpfm != 0)
				{
					if (nDorzMXyjslEPdLsyaALUEBoSpfm != 1)
					{
						return false;
					}
					NDorzMXyjslEPdLsyaALUEBoSpfm = -1;
					goto IL_0098;
				}
				NDorzMXyjslEPdLsyaALUEBoSpfm = -1;
				if (dCnrTPxCehTyZjMFJDLGXzwPNMhn == null || dCnrTPxCehTyZjMFJDLGXzwPNMhn == string.Empty)
				{
					return false;
				}
				if (iTHjdcHikbBPeGMwcPZWQNlJQaRL.mapCategories == null)
				{
					return false;
				}
				SOZnTpTAzQbMsCqoPTTcDyyyffXf = 0;
				goto IL_00a8;
				IL_00a8:
				if (SOZnTpTAzQbMsCqoPTTcDyyyffXf < iTHjdcHikbBPeGMwcPZWQNlJQaRL.mapCategories.Count)
				{
					if (iTHjdcHikbBPeGMwcPZWQNlJQaRL.mapCategories[SOZnTpTAzQbMsCqoPTTcDyyyffXf].tag.Equals(dCnrTPxCehTyZjMFJDLGXzwPNMhn, StringComparison.OrdinalIgnoreCase))
					{
						lYcBxKeXRiOTJQjDSoGkGtaSQmFj = iTHjdcHikbBPeGMwcPZWQNlJQaRL.mapCategories[SOZnTpTAzQbMsCqoPTTcDyyyffXf];
						NDorzMXyjslEPdLsyaALUEBoSpfm = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				SOZnTpTAzQbMsCqoPTTcDyyyffXf++;
				goto IL_00a8;
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

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				wEyPWxpXcAkWhRkXgdPyibKpXoLd wEyPWxpXcAkWhRkXgdPyibKpXoLd2;
				if (NDorzMXyjslEPdLsyaALUEBoSpfm == -2 && QWnpnszMwWPCjljVbAiWfzwpwjTC == Environment.CurrentManagedThreadId)
				{
					NDorzMXyjslEPdLsyaALUEBoSpfm = 0;
					wEyPWxpXcAkWhRkXgdPyibKpXoLd2 = this;
				}
				else
				{
					wEyPWxpXcAkWhRkXgdPyibKpXoLd2 = new wEyPWxpXcAkWhRkXgdPyibKpXoLd(0);
					wEyPWxpXcAkWhRkXgdPyibKpXoLd2.ITHjdcHikbBPeGMwcPZWQNlJQaRL = ITHjdcHikbBPeGMwcPZWQNlJQaRL;
				}
				wEyPWxpXcAkWhRkXgdPyibKpXoLd2.dCnrTPxCehTyZjMFJDLGXzwPNMhn = YUasNxjqCaGdPchmfurSNvczQbcwA;
				return wEyPWxpXcAkWhRkXgdPyibKpXoLd2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class ZKnEyiFOQzsiCMWWZnxLNlJSChxIA : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int subrpqAxkzPoPLBiDdWTboSlWJKn;

			private string uKGSrHDpPJlzraWxQgIsXrezffvS;

			private int QNZzhORPOiByHDNYHUhwMvewcazH;

			public UserData gVuaGRaSByhiDnBcRNjHWcMtIYAtA;

			private int GRunJCYecYDyvOuSoNkbkClrmKSb;

			public int mBcqbCNEHGjvZwKlrZTKiNryhORs;

			private IEnumerator<int> gfbbqcQNeBmKZlCvxjbpDUhzgaZd;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return uKGSrHDpPJlzraWxQgIsXrezffvS;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return uKGSrHDpPJlzraWxQgIsXrezffvS;
				}
			}

			[DebuggerHidden]
			public ZKnEyiFOQzsiCMWWZnxLNlJSChxIA(int P_0)
			{
				subrpqAxkzPoPLBiDdWTboSlWJKn = P_0;
				QNZzhORPOiByHDNYHUhwMvewcazH = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = subrpqAxkzPoPLBiDdWTboSlWJKn;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						kCBwNDnqduedvcrwhvpGBwBvBAHP();
					}
				}
				gfbbqcQNeBmKZlCvxjbpDUhzgaZd = null;
				subrpqAxkzPoPLBiDdWTboSlWJKn = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = subrpqAxkzPoPLBiDdWTboSlWJKn;
					UserData userData = gVuaGRaSByhiDnBcRNjHWcMtIYAtA;
					switch (num)
					{
					default:
						return false;
					case 0:
						subrpqAxkzPoPLBiDdWTboSlWJKn = -1;
						if (userData.actionCategories == null || userData.dUYEBfdxdeFmejEEDExIosmzBhsr == null)
						{
							return false;
						}
						gfbbqcQNeBmKZlCvxjbpDUhzgaZd = userData.actionCategoryMap.ActionIdsInCategory(GRunJCYecYDyvOuSoNkbkClrmKSb).GetEnumerator();
						subrpqAxkzPoPLBiDdWTboSlWJKn = -3;
						break;
					case 1:
						subrpqAxkzPoPLBiDdWTboSlWJKn = -3;
						break;
					}
					while (gfbbqcQNeBmKZlCvxjbpDUhzgaZd.MoveNext())
					{
						int current = gfbbqcQNeBmKZlCvxjbpDUhzgaZd.Current;
						InputAction actionById = userData.GetActionById(current);
						if (actionById != null)
						{
							uKGSrHDpPJlzraWxQgIsXrezffvS = actionById.descriptiveName;
							subrpqAxkzPoPLBiDdWTboSlWJKn = 1;
							return true;
						}
					}
					kCBwNDnqduedvcrwhvpGBwBvBAHP();
					gfbbqcQNeBmKZlCvxjbpDUhzgaZd = null;
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

			private void kCBwNDnqduedvcrwhvpGBwBvBAHP()
			{
				subrpqAxkzPoPLBiDdWTboSlWJKn = -1;
				if (gfbbqcQNeBmKZlCvxjbpDUhzgaZd != null)
				{
					gfbbqcQNeBmKZlCvxjbpDUhzgaZd.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				ZKnEyiFOQzsiCMWWZnxLNlJSChxIA zKnEyiFOQzsiCMWWZnxLNlJSChxIA;
				if (subrpqAxkzPoPLBiDdWTboSlWJKn == -2 && QNZzhORPOiByHDNYHUhwMvewcazH == Environment.CurrentManagedThreadId)
				{
					subrpqAxkzPoPLBiDdWTboSlWJKn = 0;
					zKnEyiFOQzsiCMWWZnxLNlJSChxIA = this;
				}
				else
				{
					zKnEyiFOQzsiCMWWZnxLNlJSChxIA = new ZKnEyiFOQzsiCMWWZnxLNlJSChxIA(0);
					zKnEyiFOQzsiCMWWZnxLNlJSChxIA.gVuaGRaSByhiDnBcRNjHWcMtIYAtA = gVuaGRaSByhiDnBcRNjHWcMtIYAtA;
				}
				zKnEyiFOQzsiCMWWZnxLNlJSChxIA.GRunJCYecYDyvOuSoNkbkClrmKSb = mBcqbCNEHGjvZwKlrZTKiNryhORs;
				return zKnEyiFOQzsiCMWWZnxLNlJSChxIA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class PHjDKYZFBKcsIHoHofSiQzghAdlUA : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int YpYhJbDxSNAcFuJrXoiPndzHppaO;

			private int ZCFCCwAKxHwHZWAHUctYxMDCpMvi;

			private int KVZFdXSkSzBYlkkRuZHirgqxxPB;

			public UserData kECJGnnTGXQrimJMwtjTUnZpnMfM;

			private int JbYYWzOHGKPfvyZwrBQjovbhwbkm;

			public int fSzwjzijxFnylmBITJbUDtGTFlSb;

			private IEnumerator<int> McvfLXDQAFHFdDCqILHYesTeUSidE;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return ZCFCCwAKxHwHZWAHUctYxMDCpMvi;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ZCFCCwAKxHwHZWAHUctYxMDCpMvi;
				}
			}

			[DebuggerHidden]
			public PHjDKYZFBKcsIHoHofSiQzghAdlUA(int P_0)
			{
				YpYhJbDxSNAcFuJrXoiPndzHppaO = P_0;
				KVZFdXSkSzBYlkkRuZHirgqxxPB = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int ypYhJbDxSNAcFuJrXoiPndzHppaO = YpYhJbDxSNAcFuJrXoiPndzHppaO;
				if (ypYhJbDxSNAcFuJrXoiPndzHppaO == -3 || ypYhJbDxSNAcFuJrXoiPndzHppaO == 1)
				{
					try
					{
					}
					finally
					{
						fXRUsHMrjKMkhSLiTFlRJZzxlfUF();
					}
				}
				McvfLXDQAFHFdDCqILHYesTeUSidE = null;
				YpYhJbDxSNAcFuJrXoiPndzHppaO = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int ypYhJbDxSNAcFuJrXoiPndzHppaO = YpYhJbDxSNAcFuJrXoiPndzHppaO;
					UserData userData = kECJGnnTGXQrimJMwtjTUnZpnMfM;
					switch (ypYhJbDxSNAcFuJrXoiPndzHppaO)
					{
					default:
						return false;
					case 0:
						YpYhJbDxSNAcFuJrXoiPndzHppaO = -1;
						if (userData.actionCategories == null || userData.dUYEBfdxdeFmejEEDExIosmzBhsr == null)
						{
							return false;
						}
						McvfLXDQAFHFdDCqILHYesTeUSidE = userData.actionCategoryMap.ActionIdsInCategory(JbYYWzOHGKPfvyZwrBQjovbhwbkm).GetEnumerator();
						YpYhJbDxSNAcFuJrXoiPndzHppaO = -3;
						break;
					case 1:
						YpYhJbDxSNAcFuJrXoiPndzHppaO = -3;
						break;
					}
					if (McvfLXDQAFHFdDCqILHYesTeUSidE.MoveNext())
					{
						int current = McvfLXDQAFHFdDCqILHYesTeUSidE.Current;
						ZCFCCwAKxHwHZWAHUctYxMDCpMvi = current;
						YpYhJbDxSNAcFuJrXoiPndzHppaO = 1;
						return true;
					}
					fXRUsHMrjKMkhSLiTFlRJZzxlfUF();
					McvfLXDQAFHFdDCqILHYesTeUSidE = null;
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

			private void fXRUsHMrjKMkhSLiTFlRJZzxlfUF()
			{
				YpYhJbDxSNAcFuJrXoiPndzHppaO = -1;
				if (McvfLXDQAFHFdDCqILHYesTeUSidE != null)
				{
					McvfLXDQAFHFdDCqILHYesTeUSidE.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				PHjDKYZFBKcsIHoHofSiQzghAdlUA pHjDKYZFBKcsIHoHofSiQzghAdlUA;
				if (YpYhJbDxSNAcFuJrXoiPndzHppaO == -2 && KVZFdXSkSzBYlkkRuZHirgqxxPB == Environment.CurrentManagedThreadId)
				{
					YpYhJbDxSNAcFuJrXoiPndzHppaO = 0;
					pHjDKYZFBKcsIHoHofSiQzghAdlUA = this;
				}
				else
				{
					pHjDKYZFBKcsIHoHofSiQzghAdlUA = new PHjDKYZFBKcsIHoHofSiQzghAdlUA(0);
					pHjDKYZFBKcsIHoHofSiQzghAdlUA.kECJGnnTGXQrimJMwtjTUnZpnMfM = kECJGnnTGXQrimJMwtjTUnZpnMfM;
				}
				pHjDKYZFBKcsIHoHofSiQzghAdlUA.JbYYWzOHGKPfvyZwrBQjovbhwbkm = fSzwjzijxFnylmBITJbUDtGTFlSb;
				return pHjDKYZFBKcsIHoHofSiQzghAdlUA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		private sealed class RhssdQLBmlPaxLfTKYAPhxogOVOD : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int hPkuyDMMPvuLKctaGukWezWXUcGJ;

			private string uroDsaPUXEpuqthYblYiCJRCHNOT;

			private int QnAfOZeNhHsWYpdHNEICvjqJlSUGb;

			public UserData TALjHgRvrCTFvCmamcDDfnNMPmqsA;

			private int CqkZcFqvAROxjNLAQrwIbcANnmPD;

			public int plFFLfDSkarMjuGXICJcFNEiIoahB;

			private IEnumerator<int> eJmgqNKtmzzwqrMdizxcjvGovISo;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return uroDsaPUXEpuqthYblYiCJRCHNOT;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return uroDsaPUXEpuqthYblYiCJRCHNOT;
				}
			}

			[DebuggerHidden]
			public RhssdQLBmlPaxLfTKYAPhxogOVOD(int P_0)
			{
				hPkuyDMMPvuLKctaGukWezWXUcGJ = P_0;
				QnAfOZeNhHsWYpdHNEICvjqJlSUGb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = hPkuyDMMPvuLKctaGukWezWXUcGJ;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						BXTSjtCDsRhdQpHifxKqbCTWWXzN();
					}
				}
				eJmgqNKtmzzwqrMdizxcjvGovISo = null;
				hPkuyDMMPvuLKctaGukWezWXUcGJ = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = hPkuyDMMPvuLKctaGukWezWXUcGJ;
					UserData tALjHgRvrCTFvCmamcDDfnNMPmqsA = TALjHgRvrCTFvCmamcDDfnNMPmqsA;
					switch (num)
					{
					default:
						return false;
					case 0:
						hPkuyDMMPvuLKctaGukWezWXUcGJ = -1;
						if (tALjHgRvrCTFvCmamcDDfnNMPmqsA.actionCategories == null || tALjHgRvrCTFvCmamcDDfnNMPmqsA.dUYEBfdxdeFmejEEDExIosmzBhsr == null)
						{
							return false;
						}
						eJmgqNKtmzzwqrMdizxcjvGovISo = tALjHgRvrCTFvCmamcDDfnNMPmqsA.actionCategoryMap.ActionIdsInCategory(CqkZcFqvAROxjNLAQrwIbcANnmPD).GetEnumerator();
						hPkuyDMMPvuLKctaGukWezWXUcGJ = -3;
						break;
					case 1:
						hPkuyDMMPvuLKctaGukWezWXUcGJ = -3;
						break;
					}
					while (eJmgqNKtmzzwqrMdizxcjvGovISo.MoveNext())
					{
						int current = eJmgqNKtmzzwqrMdizxcjvGovISo.Current;
						InputAction actionById = tALjHgRvrCTFvCmamcDDfnNMPmqsA.GetActionById(current);
						if (actionById != null)
						{
							uroDsaPUXEpuqthYblYiCJRCHNOT = actionById.name;
							hPkuyDMMPvuLKctaGukWezWXUcGJ = 1;
							return true;
						}
					}
					BXTSjtCDsRhdQpHifxKqbCTWWXzN();
					eJmgqNKtmzzwqrMdizxcjvGovISo = null;
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

			private void BXTSjtCDsRhdQpHifxKqbCTWWXzN()
			{
				hPkuyDMMPvuLKctaGukWezWXUcGJ = -1;
				if (eJmgqNKtmzzwqrMdizxcjvGovISo != null)
				{
					eJmgqNKtmzzwqrMdizxcjvGovISo.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				RhssdQLBmlPaxLfTKYAPhxogOVOD rhssdQLBmlPaxLfTKYAPhxogOVOD;
				if (hPkuyDMMPvuLKctaGukWezWXUcGJ == -2 && QnAfOZeNhHsWYpdHNEICvjqJlSUGb == Environment.CurrentManagedThreadId)
				{
					hPkuyDMMPvuLKctaGukWezWXUcGJ = 0;
					rhssdQLBmlPaxLfTKYAPhxogOVOD = this;
				}
				else
				{
					rhssdQLBmlPaxLfTKYAPhxogOVOD = new RhssdQLBmlPaxLfTKYAPhxogOVOD(0);
					rhssdQLBmlPaxLfTKYAPhxogOVOD.TALjHgRvrCTFvCmamcDDfnNMPmqsA = TALjHgRvrCTFvCmamcDDfnNMPmqsA;
				}
				rhssdQLBmlPaxLfTKYAPhxogOVOD.CqkZcFqvAROxjNLAQrwIbcANnmPD = plFFLfDSkarMjuGXICJcFNEiIoahB;
				return rhssdQLBmlPaxLfTKYAPhxogOVOD;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class hOBEEwLFeQRoSmtpVMwODCCAjhDd : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int EiHlgfehXFbYretnyEbJXtiniYYy;

			private InputCategory hbJWkEjjolqXyniJtNeWIAReqCXL;

			private int TLUWoQlmlWUaqoOCQqFnAUZUJgGs;

			private string enDFRVAzuZnMiEkuDMfUDadlXnUOA;

			public string EqpgUUHlJuYTGBumGmZPAAaFugtpA;

			public UserData UHoetUbxgGkwKITlNUmdNjletLTb;

			private int KWiaPtfCkBGWrVOivLvwdmhZrrzdA;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return hbJWkEjjolqXyniJtNeWIAReqCXL;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return hbJWkEjjolqXyniJtNeWIAReqCXL;
				}
			}

			[DebuggerHidden]
			public hOBEEwLFeQRoSmtpVMwODCCAjhDd(int P_0)
			{
				EiHlgfehXFbYretnyEbJXtiniYYy = P_0;
				TLUWoQlmlWUaqoOCQqFnAUZUJgGs = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				EiHlgfehXFbYretnyEbJXtiniYYy = -2;
			}

			private bool MoveNext()
			{
				int eiHlgfehXFbYretnyEbJXtiniYYy = EiHlgfehXFbYretnyEbJXtiniYYy;
				UserData uHoetUbxgGkwKITlNUmdNjletLTb = UHoetUbxgGkwKITlNUmdNjletLTb;
				if (eiHlgfehXFbYretnyEbJXtiniYYy != 0)
				{
					if (eiHlgfehXFbYretnyEbJXtiniYYy != 1)
					{
						return false;
					}
					EiHlgfehXFbYretnyEbJXtiniYYy = -1;
					goto IL_00b3;
				}
				EiHlgfehXFbYretnyEbJXtiniYYy = -1;
				if (enDFRVAzuZnMiEkuDMfUDadlXnUOA == null || enDFRVAzuZnMiEkuDMfUDadlXnUOA == string.Empty)
				{
					return false;
				}
				if (uHoetUbxgGkwKITlNUmdNjletLTb.actionCategories == null)
				{
					return false;
				}
				KWiaPtfCkBGWrVOivLvwdmhZrrzdA = 0;
				goto IL_00c3;
				IL_00c3:
				if (KWiaPtfCkBGWrVOivLvwdmhZrrzdA < uHoetUbxgGkwKITlNUmdNjletLTb.actionCategories.Count)
				{
					if (uHoetUbxgGkwKITlNUmdNjletLTb.actionCategories[KWiaPtfCkBGWrVOivLvwdmhZrrzdA].userAssignable && uHoetUbxgGkwKITlNUmdNjletLTb.actionCategories[KWiaPtfCkBGWrVOivLvwdmhZrrzdA].tag.Equals(enDFRVAzuZnMiEkuDMfUDadlXnUOA, StringComparison.OrdinalIgnoreCase))
					{
						hbJWkEjjolqXyniJtNeWIAReqCXL = uHoetUbxgGkwKITlNUmdNjletLTb.actionCategories[KWiaPtfCkBGWrVOivLvwdmhZrrzdA];
						EiHlgfehXFbYretnyEbJXtiniYYy = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				KWiaPtfCkBGWrVOivLvwdmhZrrzdA++;
				goto IL_00c3;
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

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				hOBEEwLFeQRoSmtpVMwODCCAjhDd hOBEEwLFeQRoSmtpVMwODCCAjhDd2;
				if (EiHlgfehXFbYretnyEbJXtiniYYy == -2 && TLUWoQlmlWUaqoOCQqFnAUZUJgGs == Environment.CurrentManagedThreadId)
				{
					EiHlgfehXFbYretnyEbJXtiniYYy = 0;
					hOBEEwLFeQRoSmtpVMwODCCAjhDd2 = this;
				}
				else
				{
					hOBEEwLFeQRoSmtpVMwODCCAjhDd2 = new hOBEEwLFeQRoSmtpVMwODCCAjhDd(0);
					hOBEEwLFeQRoSmtpVMwODCCAjhDd2.UHoetUbxgGkwKITlNUmdNjletLTb = UHoetUbxgGkwKITlNUmdNjletLTb;
				}
				hOBEEwLFeQRoSmtpVMwODCCAjhDd2.enDFRVAzuZnMiEkuDMfUDadlXnUOA = EqpgUUHlJuYTGBumGmZPAAaFugtpA;
				return hOBEEwLFeQRoSmtpVMwODCCAjhDd2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class EuqWHserIoKJlhbHenZdUOOYUeEq : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int ltvDGRnTlAyNhAlyeRyMPxajAloK;

			private InputAction IkaaKkjShmhMtUsxLhDbgaJpMXaoA;

			private int RDIsDeaiIhImPdVsOVpVPqHASfGoA;

			public UserData dQXCnsIfezLQyothNcmpDlpLhrzTA;

			private int CeOTrQLNgTULvqjjAHcHatGRSNVT;

			public int YsDpGtSwNIrWLzpvsKwKkJummsIJ;

			private bool UFFyCYDEKnupeYfrRdJwDVKvafGfA;

			public bool yjuulIPBYRxGuhhEYGtxNqHXYWKD;

			private InputCategory aPmwPKQRIVOZBuDifCiuKSLqBluCA;

			private IEnumerator<int> GEqmejRUsJPXQkZagDAqiOClaVKaA;

			private int uBRmKrenuUXImtSdRVveinnZUtRB;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return IkaaKkjShmhMtUsxLhDbgaJpMXaoA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return IkaaKkjShmhMtUsxLhDbgaJpMXaoA;
				}
			}

			[DebuggerHidden]
			public EuqWHserIoKJlhbHenZdUOOYUeEq(int P_0)
			{
				ltvDGRnTlAyNhAlyeRyMPxajAloK = P_0;
				RDIsDeaiIhImPdVsOVpVPqHASfGoA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = ltvDGRnTlAyNhAlyeRyMPxajAloK;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						GHpYBHMGPMieaiOYAPoYfHxAyenH();
					}
				}
				aPmwPKQRIVOZBuDifCiuKSLqBluCA = null;
				GEqmejRUsJPXQkZagDAqiOClaVKaA = null;
				ltvDGRnTlAyNhAlyeRyMPxajAloK = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = ltvDGRnTlAyNhAlyeRyMPxajAloK;
					UserData userData = dQXCnsIfezLQyothNcmpDlpLhrzTA;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						ltvDGRnTlAyNhAlyeRyMPxajAloK = -1;
						if (userData.dUYEBfdxdeFmejEEDExIosmzBhsr == null || userData.actionCategories == null)
						{
							return false;
						}
						aPmwPKQRIVOZBuDifCiuKSLqBluCA = userData.GetActionCategoryById(CeOTrQLNgTULvqjjAHcHatGRSNVT);
						if (aPmwPKQRIVOZBuDifCiuKSLqBluCA == null || !aPmwPKQRIVOZBuDifCiuKSLqBluCA.userAssignable)
						{
							return false;
						}
						if (UFFyCYDEKnupeYfrRdJwDVKvafGfA)
						{
							GEqmejRUsJPXQkZagDAqiOClaVKaA = userData.SortedActionIdsInCategory(aPmwPKQRIVOZBuDifCiuKSLqBluCA.id).GetEnumerator();
							ltvDGRnTlAyNhAlyeRyMPxajAloK = -3;
							goto IL_00e4;
						}
						uBRmKrenuUXImtSdRVveinnZUtRB = 0;
						goto IL_0165;
					case 1:
						ltvDGRnTlAyNhAlyeRyMPxajAloK = -3;
						goto IL_00e4;
					case 2:
						{
							ltvDGRnTlAyNhAlyeRyMPxajAloK = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (GEqmejRUsJPXQkZagDAqiOClaVKaA.MoveNext())
						{
							int current = GEqmejRUsJPXQkZagDAqiOClaVKaA.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								IkaaKkjShmhMtUsxLhDbgaJpMXaoA = actionById;
								ltvDGRnTlAyNhAlyeRyMPxajAloK = 1;
								return true;
							}
						}
						GHpYBHMGPMieaiOYAPoYfHxAyenH();
						GEqmejRUsJPXQkZagDAqiOClaVKaA = null;
						break;
						IL_0153:
						uBRmKrenuUXImtSdRVveinnZUtRB++;
						goto IL_0165;
						IL_0165:
						if (uBRmKrenuUXImtSdRVveinnZUtRB >= userData.dUYEBfdxdeFmejEEDExIosmzBhsr.Count)
						{
							break;
						}
						inputAction = userData.dUYEBfdxdeFmejEEDExIosmzBhsr[uBRmKrenuUXImtSdRVveinnZUtRB];
						if (inputAction.categoryId == aPmwPKQRIVOZBuDifCiuKSLqBluCA.id && inputAction.userAssignable)
						{
							IkaaKkjShmhMtUsxLhDbgaJpMXaoA = inputAction;
							ltvDGRnTlAyNhAlyeRyMPxajAloK = 2;
							return true;
						}
						goto IL_0153;
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

			private void GHpYBHMGPMieaiOYAPoYfHxAyenH()
			{
				ltvDGRnTlAyNhAlyeRyMPxajAloK = -1;
				if (GEqmejRUsJPXQkZagDAqiOClaVKaA != null)
				{
					GEqmejRUsJPXQkZagDAqiOClaVKaA.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				EuqWHserIoKJlhbHenZdUOOYUeEq euqWHserIoKJlhbHenZdUOOYUeEq;
				if (ltvDGRnTlAyNhAlyeRyMPxajAloK == -2 && RDIsDeaiIhImPdVsOVpVPqHASfGoA == Environment.CurrentManagedThreadId)
				{
					ltvDGRnTlAyNhAlyeRyMPxajAloK = 0;
					euqWHserIoKJlhbHenZdUOOYUeEq = this;
				}
				else
				{
					euqWHserIoKJlhbHenZdUOOYUeEq = new EuqWHserIoKJlhbHenZdUOOYUeEq(0);
					euqWHserIoKJlhbHenZdUOOYUeEq.dQXCnsIfezLQyothNcmpDlpLhrzTA = dQXCnsIfezLQyothNcmpDlpLhrzTA;
				}
				euqWHserIoKJlhbHenZdUOOYUeEq.CeOTrQLNgTULvqjjAHcHatGRSNVT = YsDpGtSwNIrWLzpvsKwKkJummsIJ;
				euqWHserIoKJlhbHenZdUOOYUeEq.UFFyCYDEKnupeYfrRdJwDVKvafGfA = yjuulIPBYRxGuhhEYGtxNqHXYWKD;
				return euqWHserIoKJlhbHenZdUOOYUeEq;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class RUwItTtbXsbCjjyylcnrGqujxnrHB : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int oOmPQEhRFZBriqhRXRFpRdIxdQjA;

			private InputAction wyVPUBZqLWqNCHdmWBOnFfxJVKUF;

			private int BNTANxXCoASiTAmIZMVOJBTPkbEj;

			public UserData gofEflNjnvPzFEeSvtLsLJzHxytM;

			private string QgYEgoijOZsSwEupDJdKGccArKqlc;

			public string PiHUznnmIjmgWUjBbfzWBttNKnVlA;

			private bool sPSFLRCfEKeVhNfZsQCrBAxHpQIYA;

			public bool dpcfbanifZAafDbYOmGkvOuMQZlI;

			private InputCategory YvFuzGrdFhiRniKRoaKlfiVBjSRH;

			private IEnumerator<int> BLEJskArUDgoCQcVbGJiKCLNmilN;

			private int lORmTJlOlOTWdWsZLnZnPFhjtsir;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return wyVPUBZqLWqNCHdmWBOnFfxJVKUF;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wyVPUBZqLWqNCHdmWBOnFfxJVKUF;
				}
			}

			[DebuggerHidden]
			public RUwItTtbXsbCjjyylcnrGqujxnrHB(int P_0)
			{
				oOmPQEhRFZBriqhRXRFpRdIxdQjA = P_0;
				BNTANxXCoASiTAmIZMVOJBTPkbEj = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = oOmPQEhRFZBriqhRXRFpRdIxdQjA;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						hTPufhknQZbGVgLIOacNASxgQpQZA();
					}
				}
				YvFuzGrdFhiRniKRoaKlfiVBjSRH = null;
				BLEJskArUDgoCQcVbGJiKCLNmilN = null;
				oOmPQEhRFZBriqhRXRFpRdIxdQjA = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = oOmPQEhRFZBriqhRXRFpRdIxdQjA;
					UserData userData = gofEflNjnvPzFEeSvtLsLJzHxytM;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						oOmPQEhRFZBriqhRXRFpRdIxdQjA = -1;
						if (userData.dUYEBfdxdeFmejEEDExIosmzBhsr == null || userData.actionCategories == null)
						{
							return false;
						}
						YvFuzGrdFhiRniKRoaKlfiVBjSRH = userData.GetActionCategory(QgYEgoijOZsSwEupDJdKGccArKqlc);
						if (YvFuzGrdFhiRniKRoaKlfiVBjSRH == null || !YvFuzGrdFhiRniKRoaKlfiVBjSRH.userAssignable)
						{
							return false;
						}
						if (sPSFLRCfEKeVhNfZsQCrBAxHpQIYA)
						{
							BLEJskArUDgoCQcVbGJiKCLNmilN = userData.SortedActionIdsInCategory(YvFuzGrdFhiRniKRoaKlfiVBjSRH.id).GetEnumerator();
							oOmPQEhRFZBriqhRXRFpRdIxdQjA = -3;
							goto IL_00e4;
						}
						lORmTJlOlOTWdWsZLnZnPFhjtsir = 0;
						goto IL_0165;
					case 1:
						oOmPQEhRFZBriqhRXRFpRdIxdQjA = -3;
						goto IL_00e4;
					case 2:
						{
							oOmPQEhRFZBriqhRXRFpRdIxdQjA = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (BLEJskArUDgoCQcVbGJiKCLNmilN.MoveNext())
						{
							int current = BLEJskArUDgoCQcVbGJiKCLNmilN.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								wyVPUBZqLWqNCHdmWBOnFfxJVKUF = actionById;
								oOmPQEhRFZBriqhRXRFpRdIxdQjA = 1;
								return true;
							}
						}
						hTPufhknQZbGVgLIOacNASxgQpQZA();
						BLEJskArUDgoCQcVbGJiKCLNmilN = null;
						break;
						IL_0153:
						lORmTJlOlOTWdWsZLnZnPFhjtsir++;
						goto IL_0165;
						IL_0165:
						if (lORmTJlOlOTWdWsZLnZnPFhjtsir >= userData.dUYEBfdxdeFmejEEDExIosmzBhsr.Count)
						{
							break;
						}
						inputAction = userData.dUYEBfdxdeFmejEEDExIosmzBhsr[lORmTJlOlOTWdWsZLnZnPFhjtsir];
						if (inputAction.categoryId == YvFuzGrdFhiRniKRoaKlfiVBjSRH.id && inputAction.userAssignable)
						{
							wyVPUBZqLWqNCHdmWBOnFfxJVKUF = inputAction;
							oOmPQEhRFZBriqhRXRFpRdIxdQjA = 2;
							return true;
						}
						goto IL_0153;
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

			private void hTPufhknQZbGVgLIOacNASxgQpQZA()
			{
				oOmPQEhRFZBriqhRXRFpRdIxdQjA = -1;
				if (BLEJskArUDgoCQcVbGJiKCLNmilN != null)
				{
					BLEJskArUDgoCQcVbGJiKCLNmilN.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				RUwItTtbXsbCjjyylcnrGqujxnrHB rUwItTtbXsbCjjyylcnrGqujxnrHB;
				if (oOmPQEhRFZBriqhRXRFpRdIxdQjA == -2 && BNTANxXCoASiTAmIZMVOJBTPkbEj == Environment.CurrentManagedThreadId)
				{
					oOmPQEhRFZBriqhRXRFpRdIxdQjA = 0;
					rUwItTtbXsbCjjyylcnrGqujxnrHB = this;
				}
				else
				{
					rUwItTtbXsbCjjyylcnrGqujxnrHB = new RUwItTtbXsbCjjyylcnrGqujxnrHB(0);
					rUwItTtbXsbCjjyylcnrGqujxnrHB.gofEflNjnvPzFEeSvtLsLJzHxytM = gofEflNjnvPzFEeSvtLsLJzHxytM;
				}
				rUwItTtbXsbCjjyylcnrGqujxnrHB.QgYEgoijOZsSwEupDJdKGccArKqlc = PiHUznnmIjmgWUjBbfzWBttNKnVlA;
				rUwItTtbXsbCjjyylcnrGqujxnrHB.sPSFLRCfEKeVhNfZsQCrBAxHpQIYA = dpcfbanifZAafDbYOmGkvOuMQZlI;
				return rUwItTtbXsbCjjyylcnrGqujxnrHB;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class vkRscHwBixgctFDZineBrobYQWXCA : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int wSSkDrwHGHoNnZVtbcSFHmsXehd;

			private InputMapCategory wULbnKAaLHvWDbQICYEeTFfQPywr;

			private int PQpdCyFfwzCpXEeemLVfKBmjBZHIA;

			private string nYuBZqCBzqMmRzaOdryWImwvEJQu;

			public string xaVtDTHDpIpEJcObozqoLjnWQHWP;

			public UserData lgKDmCgwtYeVbRfatcEwgItmRYwWA;

			private int jcGaxKxJhQnDoZXEvaLJuQqWluvT;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return wULbnKAaLHvWDbQICYEeTFfQPywr;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wULbnKAaLHvWDbQICYEeTFfQPywr;
				}
			}

			[DebuggerHidden]
			public vkRscHwBixgctFDZineBrobYQWXCA(int P_0)
			{
				wSSkDrwHGHoNnZVtbcSFHmsXehd = P_0;
				PQpdCyFfwzCpXEeemLVfKBmjBZHIA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				wSSkDrwHGHoNnZVtbcSFHmsXehd = -2;
			}

			private bool MoveNext()
			{
				int num = wSSkDrwHGHoNnZVtbcSFHmsXehd;
				UserData userData = lgKDmCgwtYeVbRfatcEwgItmRYwWA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					wSSkDrwHGHoNnZVtbcSFHmsXehd = -1;
					goto IL_00b3;
				}
				wSSkDrwHGHoNnZVtbcSFHmsXehd = -1;
				if (nYuBZqCBzqMmRzaOdryWImwvEJQu == null || nYuBZqCBzqMmRzaOdryWImwvEJQu == string.Empty)
				{
					return false;
				}
				if (userData.mapCategories == null)
				{
					return false;
				}
				jcGaxKxJhQnDoZXEvaLJuQqWluvT = 0;
				goto IL_00c3;
				IL_00c3:
				if (jcGaxKxJhQnDoZXEvaLJuQqWluvT < userData.mapCategories.Count)
				{
					if (userData.mapCategories[jcGaxKxJhQnDoZXEvaLJuQqWluvT].userAssignable && userData.mapCategories[jcGaxKxJhQnDoZXEvaLJuQqWluvT].tag.Equals(nYuBZqCBzqMmRzaOdryWImwvEJQu, StringComparison.OrdinalIgnoreCase))
					{
						wULbnKAaLHvWDbQICYEeTFfQPywr = userData.mapCategories[jcGaxKxJhQnDoZXEvaLJuQqWluvT];
						wSSkDrwHGHoNnZVtbcSFHmsXehd = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				jcGaxKxJhQnDoZXEvaLJuQqWluvT++;
				goto IL_00c3;
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

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				vkRscHwBixgctFDZineBrobYQWXCA vkRscHwBixgctFDZineBrobYQWXCA2;
				if (wSSkDrwHGHoNnZVtbcSFHmsXehd == -2 && PQpdCyFfwzCpXEeemLVfKBmjBZHIA == Environment.CurrentManagedThreadId)
				{
					wSSkDrwHGHoNnZVtbcSFHmsXehd = 0;
					vkRscHwBixgctFDZineBrobYQWXCA2 = this;
				}
				else
				{
					vkRscHwBixgctFDZineBrobYQWXCA2 = new vkRscHwBixgctFDZineBrobYQWXCA(0);
					vkRscHwBixgctFDZineBrobYQWXCA2.lgKDmCgwtYeVbRfatcEwgItmRYwWA = lgKDmCgwtYeVbRfatcEwgItmRYwWA;
				}
				vkRscHwBixgctFDZineBrobYQWXCA2.nYuBZqCBzqMmRzaOdryWImwvEJQu = xaVtDTHDpIpEJcObozqoLjnWQHWP;
				return vkRscHwBixgctFDZineBrobYQWXCA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class YccgoxfPMDCfScHuYeFrOjmzsCSP : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int vGCWBcPzilCmXPJtBBLPjlegPYJe;

			private InputCategory jZimoATXxFFKNZZzAEpNjdbiBcsM;

			private int tXXAJoHLkdEHJiRgVnGWIQMrvkGe;

			public UserData EIEjlhzwnMkVEUcFskKyjOdpjpzH;

			private int DfOFKOilsfyWHLOgjddIrMgTGbyIA;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return jZimoATXxFFKNZZzAEpNjdbiBcsM;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return jZimoATXxFFKNZZzAEpNjdbiBcsM;
				}
			}

			[DebuggerHidden]
			public YccgoxfPMDCfScHuYeFrOjmzsCSP(int P_0)
			{
				vGCWBcPzilCmXPJtBBLPjlegPYJe = P_0;
				tXXAJoHLkdEHJiRgVnGWIQMrvkGe = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				vGCWBcPzilCmXPJtBBLPjlegPYJe = -2;
			}

			private bool MoveNext()
			{
				int num = vGCWBcPzilCmXPJtBBLPjlegPYJe;
				UserData eIEjlhzwnMkVEUcFskKyjOdpjpzH = EIEjlhzwnMkVEUcFskKyjOdpjpzH;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					vGCWBcPzilCmXPJtBBLPjlegPYJe = -1;
					goto IL_0070;
				}
				vGCWBcPzilCmXPJtBBLPjlegPYJe = -1;
				if (eIEjlhzwnMkVEUcFskKyjOdpjpzH.actionCategories == null)
				{
					return false;
				}
				DfOFKOilsfyWHLOgjddIrMgTGbyIA = 0;
				goto IL_0080;
				IL_0080:
				if (DfOFKOilsfyWHLOgjddIrMgTGbyIA < eIEjlhzwnMkVEUcFskKyjOdpjpzH.actionCategories.Count)
				{
					if (eIEjlhzwnMkVEUcFskKyjOdpjpzH.actionCategories[DfOFKOilsfyWHLOgjddIrMgTGbyIA].userAssignable)
					{
						jZimoATXxFFKNZZzAEpNjdbiBcsM = eIEjlhzwnMkVEUcFskKyjOdpjpzH.actionCategories[DfOFKOilsfyWHLOgjddIrMgTGbyIA];
						vGCWBcPzilCmXPJtBBLPjlegPYJe = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				DfOFKOilsfyWHLOgjddIrMgTGbyIA++;
				goto IL_0080;
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

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				YccgoxfPMDCfScHuYeFrOjmzsCSP yccgoxfPMDCfScHuYeFrOjmzsCSP;
				if (vGCWBcPzilCmXPJtBBLPjlegPYJe == -2 && tXXAJoHLkdEHJiRgVnGWIQMrvkGe == Environment.CurrentManagedThreadId)
				{
					vGCWBcPzilCmXPJtBBLPjlegPYJe = 0;
					yccgoxfPMDCfScHuYeFrOjmzsCSP = this;
				}
				else
				{
					yccgoxfPMDCfScHuYeFrOjmzsCSP = new YccgoxfPMDCfScHuYeFrOjmzsCSP(0);
					yccgoxfPMDCfScHuYeFrOjmzsCSP.EIEjlhzwnMkVEUcFskKyjOdpjpzH = EIEjlhzwnMkVEUcFskKyjOdpjpzH;
				}
				return yccgoxfPMDCfScHuYeFrOjmzsCSP;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class fAobMgTJhWCiuXkTWOcdBfZdPIaq : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int tsSBLuAPxOFMdLHQQUUnyDenBwWY;

			private InputAction AWqktLFDmPfCvJLMqkbMiDTjtEvLB;

			private int gfyZmpdaomWoxdcfpWBrYBiixTUA;

			public UserData gowHtGughUeKzzNQkjQQgGEnyIqB;

			private int wmgWHPLUZLYUeNdYHSTGVVGmFQTi;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return AWqktLFDmPfCvJLMqkbMiDTjtEvLB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return AWqktLFDmPfCvJLMqkbMiDTjtEvLB;
				}
			}

			[DebuggerHidden]
			public fAobMgTJhWCiuXkTWOcdBfZdPIaq(int P_0)
			{
				tsSBLuAPxOFMdLHQQUUnyDenBwWY = P_0;
				gfyZmpdaomWoxdcfpWBrYBiixTUA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				tsSBLuAPxOFMdLHQQUUnyDenBwWY = -2;
			}

			private bool MoveNext()
			{
				int num = tsSBLuAPxOFMdLHQQUUnyDenBwWY;
				UserData userData = gowHtGughUeKzzNQkjQQgGEnyIqB;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					tsSBLuAPxOFMdLHQQUUnyDenBwWY = -1;
					goto IL_007a;
				}
				tsSBLuAPxOFMdLHQQUUnyDenBwWY = -1;
				if (userData.dUYEBfdxdeFmejEEDExIosmzBhsr == null)
				{
					return false;
				}
				wmgWHPLUZLYUeNdYHSTGVVGmFQTi = 0;
				goto IL_008c;
				IL_008c:
				if (wmgWHPLUZLYUeNdYHSTGVVGmFQTi < userData.dUYEBfdxdeFmejEEDExIosmzBhsr.Count)
				{
					InputAction inputAction = userData.dUYEBfdxdeFmejEEDExIosmzBhsr[wmgWHPLUZLYUeNdYHSTGVVGmFQTi];
					InputCategory actionCategoryById = userData.GetActionCategoryById(inputAction.categoryId);
					if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
					{
						AWqktLFDmPfCvJLMqkbMiDTjtEvLB = inputAction;
						tsSBLuAPxOFMdLHQQUUnyDenBwWY = 1;
						return true;
					}
					goto IL_007a;
				}
				return false;
				IL_007a:
				wmgWHPLUZLYUeNdYHSTGVVGmFQTi++;
				goto IL_008c;
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

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				fAobMgTJhWCiuXkTWOcdBfZdPIaq fAobMgTJhWCiuXkTWOcdBfZdPIaq2;
				if (tsSBLuAPxOFMdLHQQUUnyDenBwWY == -2 && gfyZmpdaomWoxdcfpWBrYBiixTUA == Environment.CurrentManagedThreadId)
				{
					tsSBLuAPxOFMdLHQQUUnyDenBwWY = 0;
					fAobMgTJhWCiuXkTWOcdBfZdPIaq2 = this;
				}
				else
				{
					fAobMgTJhWCiuXkTWOcdBfZdPIaq2 = new fAobMgTJhWCiuXkTWOcdBfZdPIaq(0);
					fAobMgTJhWCiuXkTWOcdBfZdPIaq2.gowHtGughUeKzzNQkjQQgGEnyIqB = gowHtGughUeKzzNQkjQQgGEnyIqB;
				}
				return fAobMgTJhWCiuXkTWOcdBfZdPIaq2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class nSpnEIrllseWhdyFyuoLkpNGjzhoA : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int CtMhdpSfGuZhzDQROgcpRXCsKFMq;

			private InputMapCategory vjSClKwcPCeNTnwriQWBybqpsHKN;

			private int lUktfHReDCMdgAYWrAfRKRlBJkaS;

			public UserData ysGOcuLgKkptPLThpDqSzjmymJeN;

			private int TIqFJZobTXigxPWICASjduXmZLSk;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjSClKwcPCeNTnwriQWBybqpsHKN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjSClKwcPCeNTnwriQWBybqpsHKN;
				}
			}

			[DebuggerHidden]
			public nSpnEIrllseWhdyFyuoLkpNGjzhoA(int P_0)
			{
				CtMhdpSfGuZhzDQROgcpRXCsKFMq = P_0;
				lUktfHReDCMdgAYWrAfRKRlBJkaS = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				CtMhdpSfGuZhzDQROgcpRXCsKFMq = -2;
			}

			private bool MoveNext()
			{
				int ctMhdpSfGuZhzDQROgcpRXCsKFMq = CtMhdpSfGuZhzDQROgcpRXCsKFMq;
				UserData userData = ysGOcuLgKkptPLThpDqSzjmymJeN;
				if (ctMhdpSfGuZhzDQROgcpRXCsKFMq != 0)
				{
					if (ctMhdpSfGuZhzDQROgcpRXCsKFMq != 1)
					{
						return false;
					}
					CtMhdpSfGuZhzDQROgcpRXCsKFMq = -1;
					goto IL_0070;
				}
				CtMhdpSfGuZhzDQROgcpRXCsKFMq = -1;
				if (userData.mapCategories == null)
				{
					return false;
				}
				TIqFJZobTXigxPWICASjduXmZLSk = 0;
				goto IL_0080;
				IL_0080:
				if (TIqFJZobTXigxPWICASjduXmZLSk < userData.mapCategories.Count)
				{
					if (userData.mapCategories[TIqFJZobTXigxPWICASjduXmZLSk].userAssignable)
					{
						vjSClKwcPCeNTnwriQWBybqpsHKN = userData.mapCategories[TIqFJZobTXigxPWICASjduXmZLSk];
						CtMhdpSfGuZhzDQROgcpRXCsKFMq = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				TIqFJZobTXigxPWICASjduXmZLSk++;
				goto IL_0080;
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

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				nSpnEIrllseWhdyFyuoLkpNGjzhoA nSpnEIrllseWhdyFyuoLkpNGjzhoA2;
				if (CtMhdpSfGuZhzDQROgcpRXCsKFMq == -2 && lUktfHReDCMdgAYWrAfRKRlBJkaS == Environment.CurrentManagedThreadId)
				{
					CtMhdpSfGuZhzDQROgcpRXCsKFMq = 0;
					nSpnEIrllseWhdyFyuoLkpNGjzhoA2 = this;
				}
				else
				{
					nSpnEIrllseWhdyFyuoLkpNGjzhoA2 = new nSpnEIrllseWhdyFyuoLkpNGjzhoA(0);
					nSpnEIrllseWhdyFyuoLkpNGjzhoA2.ysGOcuLgKkptPLThpDqSzjmymJeN = ysGOcuLgKkptPLThpDqSzjmymJeN;
				}
				return nSpnEIrllseWhdyFyuoLkpNGjzhoA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ConfigVars configVars = new ConfigVars();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Player_Editor> players = new List<Player_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputAction> actions = new List<InputAction>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputActionCategory> actionCategories = new List<InputActionCategory>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ActionCategoryMap actionCategoryMap = new ActionCategoryMap();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputBehavior> inputBehaviors = new List<InputBehavior>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputMapCategory> mapCategories = new List<InputMapCategory>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> joystickLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> keyboardLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> mouseLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> customControllerLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> joystickMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = new List<ControllerMapLayoutManager_RuleSet_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = new List<ControllerMapEnabler_RuleSet_Editor>();

		[NonSerialized]
		private List<InputAction> vWVCaxumKigQbhTsviQaKApAlEkm;

		[NonSerialized]
		private bool pLbfMlBwEbxOCcSpvLOTuPwlegxK;

		[CompilerGenerated]
		private IList<Player_Editor> _003CPlayers_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputAction> _003CActions_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputCategory> _003CActionCategories_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputBehavior> _003CInputBehaviors_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputMapCategory> _003CMapCategories_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputLayout> _003CJoystickLayouts_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputLayout> _003CKeyboardLayouts_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputLayout> _003CMouseLayouts_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<InputLayout> _003CCustomControllerLayouts_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMap_Editor> _003CJoystickMaps_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMap_Editor> _003CKeyboardMaps_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMap_Editor> _003CMouseMaps_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMap_Editor> _003CCustomControllerMaps_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMapLayoutManager_RuleSet_Editor> _003CControllerMapLayoutManagerRuleSets_readOnly_003Ek__BackingField;

		[CompilerGenerated]
		private IList<ControllerMapEnabler_RuleSet_Editor> _003CControllerMapEnablerRuleSets_readOnly_003Ek__BackingField;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int playerIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int actionIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mouseMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int customControllerIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int controllerMapLayoutManagerSetIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int controllerMapEnablerSetIdCounter;

		private Func<int, bool> containsActionDelegate;

		internal IList<Player_Editor> CqaNhCrdUVQUcSQVbyoNlYtceigM
		{
			[CompilerGenerated]
			get
			{
				return _003CPlayers_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CPlayers_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputAction> VaDuPnYBoMFyibPERDuLkhTlWuIhA
		{
			[CompilerGenerated]
			get
			{
				return _003CActions_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CActions_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputCategory> LoOqAGbQBjtFnniPYMnBZCQLGLRk
		{
			[CompilerGenerated]
			get
			{
				return _003CActionCategories_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CActionCategories_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputBehavior> KokCrrxpkaAdDBNiACbXBaixTNTz
		{
			[CompilerGenerated]
			get
			{
				return _003CInputBehaviors_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CInputBehaviors_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputMapCategory> wuGtLRtEtfVDbcPSweQijoAgHePsA
		{
			[CompilerGenerated]
			get
			{
				return _003CMapCategories_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CMapCategories_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputLayout> cvgExnntIhRPLMCdFQNlmESfWgjt
		{
			[CompilerGenerated]
			get
			{
				return _003CJoystickLayouts_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CJoystickLayouts_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputLayout> GSNhjDviRjWrcNOBUmtTKEGPebOC
		{
			[CompilerGenerated]
			get
			{
				return _003CKeyboardLayouts_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CKeyboardLayouts_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputLayout> NcJhMPdNZOlgsICFZmXcVrgYwDsAA
		{
			[CompilerGenerated]
			get
			{
				return _003CMouseLayouts_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CMouseLayouts_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<InputLayout> CaAiXgdBGntDcTkAAmlNzWqxBMobb
		{
			[CompilerGenerated]
			get
			{
				return _003CCustomControllerLayouts_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CCustomControllerLayouts_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMap_Editor> DOpgNMKCAoJSbhTtwwPEDEZclwycA
		{
			[CompilerGenerated]
			get
			{
				return _003CJoystickMaps_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CJoystickMaps_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMap_Editor> xokNyuUAYlauzpPfOWdRUVsPkLer
		{
			[CompilerGenerated]
			get
			{
				return _003CKeyboardMaps_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CKeyboardMaps_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMap_Editor> SgYxwcRWoIkTmIZXGNWefHaKAtwG
		{
			[CompilerGenerated]
			get
			{
				return _003CMouseMaps_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CMouseMaps_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMap_Editor> KVAPzXYVDlHSDlvCYdtbMxCRcfth
		{
			[CompilerGenerated]
			get
			{
				return _003CCustomControllerMaps_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CCustomControllerMaps_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> sXyskiETLlUcXvzBBNbRGvcZesbS
		{
			[CompilerGenerated]
			get
			{
				return _003CControllerMapLayoutManagerRuleSets_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CControllerMapLayoutManagerRuleSets_readOnly_003Ek__BackingField = list;
			}
		}

		internal IList<ControllerMapEnabler_RuleSet_Editor> DMfbKDFtBXDvwzwORBtYOpFrgXoj
		{
			[CompilerGenerated]
			get
			{
				return _003CControllerMapEnablerRuleSets_readOnly_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CControllerMapEnablerRuleSets_readOnly_003Ek__BackingField = list;
			}
		}

		public ConfigVars ConfigVars => configVars;

		internal IEnumerable<InputMapCategory> aSTsbQripLQnkehMvmdPQlYdNDYn
		{
			[IteratorStateMachine(typeof(nSpnEIrllseWhdyFyuoLkpNGjzhoA))]
			get
			{
				return new nSpnEIrllseWhdyFyuoLkpNGjzhoA(-2)
				{
					ysGOcuLgKkptPLThpDqSzjmymJeN = this
				};
			}
		}

		internal IEnumerable<InputCategory> KAiMncrsnNEWXstzdovMQxgVWErs
		{
			[IteratorStateMachine(typeof(YccgoxfPMDCfScHuYeFrOjmzsCSP))]
			get
			{
				return new YccgoxfPMDCfScHuYeFrOjmzsCSP(-2)
				{
					EIEjlhzwnMkVEUcFskKyjOdpjpzH = this
				};
			}
		}

		internal IEnumerable<InputAction> YUZlBidKvqDkbKIwBribvBUMREMmA
		{
			[IteratorStateMachine(typeof(fAobMgTJhWCiuXkTWOcdBfZdPIaq))]
			get
			{
				return new fAobMgTJhWCiuXkTWOcdBfZdPIaq(-2)
				{
					gowHtGughUeKzzNQkjQQgGEnyIqB = this
				};
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

		private List<InputAction> dUYEBfdxdeFmejEEDExIosmzBhsr
		{
			get
			{
				if (!ReInput.isReady)
				{
					return actions;
				}
				return vWVCaxumKigQbhTsviQaKApAlEkm;
			}
		}

		[IteratorStateMachine(typeof(wEyPWxpXcAkWhRkXgdPyibKpXoLd))]
		internal IEnumerable<InputMapCategory> aRYLCgulFjrJPPvLaEceDskWmNAX(string P_0)
		{
			return new wEyPWxpXcAkWhRkXgdPyibKpXoLd(-2)
			{
				ITHjdcHikbBPeGMwcPZWQNlJQaRL = this,
				YUasNxjqCaGdPchmfurSNvczQbcwA = P_0
			};
		}

		[IteratorStateMachine(typeof(vkRscHwBixgctFDZineBrobYQWXCA))]
		internal IEnumerable<InputMapCategory> pCUwiCecgAWkqKdJSCiLCIGsGYKX(string P_0)
		{
			return new vkRscHwBixgctFDZineBrobYQWXCA(-2)
			{
				lgKDmCgwtYeVbRfatcEwgItmRYwWA = this,
				xaVtDTHDpIpEJcObozqoLjnWQHWP = P_0
			};
		}

		[IteratorStateMachine(typeof(hCAapfmuJBcdtMGmFUJfNYrrhCFD))]
		internal IEnumerable<InputCategory> DFeMMhHXrycLZJbBjqbjyBsdOByU(string P_0)
		{
			return new hCAapfmuJBcdtMGmFUJfNYrrhCFD(-2)
			{
				SCeKwyAHIJSLtxhcGiGSlXVPKLqG = this,
				NzNRkThytkMWgmXKOpLvzlKGJmAH = P_0
			};
		}

		[IteratorStateMachine(typeof(hOBEEwLFeQRoSmtpVMwODCCAjhDd))]
		internal IEnumerable<InputCategory> hnRlNdlAPVvdecjiXvmDRgJuqKnU(string P_0)
		{
			return new hOBEEwLFeQRoSmtpVMwODCCAjhDd(-2)
			{
				UHoetUbxgGkwKITlNUmdNjletLTb = this,
				EqpgUUHlJuYTGBumGmZPAAaFugtpA = P_0
			};
		}

		[IteratorStateMachine(typeof(qCDYlDpIQQCXgPTefqMpYMZrTDLT))]
		internal IEnumerable<InputAction> nqFZFTwmWGEYEePmwSKWGsYLJWPzA(int P_0, bool P_1)
		{
			return new qCDYlDpIQQCXgPTefqMpYMZrTDLT(-2)
			{
				IsuSoJdZkESjytQSKCfCRLFRbscq = this,
				vLebauBasmtmfpyMcYyejLTibwIGb = P_0,
				TXLcrUdEOrHNOoTHAvAEgSNXpRPeA = P_1
			};
		}

		[IteratorStateMachine(typeof(TUdJOUcXSCfbCpHwimQMGexPYqZU))]
		internal IEnumerable<InputAction> FgJAVNWJioLPVPlFfmnbYoRNwFdW(string P_0, bool P_1)
		{
			return new TUdJOUcXSCfbCpHwimQMGexPYqZU(-2)
			{
				RJTrzcXFVWQbRwiIteiMWFKhcewEA = this,
				cCBuWrcCiDRfZvEumanTSHkpejNK = P_0,
				EcUGywxrCtSItLrXqckKlnwXJdVF = P_1
			};
		}

		[IteratorStateMachine(typeof(QTgUMCDgbOFEGBTclOfanNUUgjOib))]
		internal IEnumerable<InputAction> gfjQCxFfoRVfFvsZWlLiYErxAqbEA(string P_0)
		{
			return new QTgUMCDgbOFEGBTclOfanNUUgjOib(-2)
			{
				aiKGcmDoGFZKOuWvFzpNSHztSupeA = this,
				dvxHHhhNKRYBWTnOztbxBeSlmCJf = P_0
			};
		}

		[IteratorStateMachine(typeof(EuqWHserIoKJlhbHenZdUOOYUeEq))]
		internal IEnumerable<InputAction> IfrONmBqIVDBecdyKDTZKLmDmaDpA(int P_0, bool P_1)
		{
			return new EuqWHserIoKJlhbHenZdUOOYUeEq(-2)
			{
				dQXCnsIfezLQyothNcmpDlpLhrzTA = this,
				YsDpGtSwNIrWLzpvsKwKkJummsIJ = P_0,
				yjuulIPBYRxGuhhEYGtxNqHXYWKD = P_1
			};
		}

		[IteratorStateMachine(typeof(RUwItTtbXsbCjjyylcnrGqujxnrHB))]
		internal IEnumerable<InputAction> benaUAnmbtCPxewRQgVBqIcpJnARA(string P_0, bool P_1)
		{
			return new RUwItTtbXsbCjjyylcnrGqujxnrHB(-2)
			{
				gofEflNjnvPzFEeSvtLsLJzHxytM = this,
				PiHUznnmIjmgWUjBbfzWBttNKnVlA = P_0,
				dpcfbanifZAafDbYOmGkvOuMQZlI = P_1
			};
		}

		public UserData()
			: this(true)
		{
		}

		private UserData(bool P_0)
		{
			if (P_0)
			{
				configVars.updateLoop = UpdateLoopSetting.Update;
				configVars.defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;
				configVars.defaultJoystickAxis2DSensitivityType = AxisSensitivity2DType.Radial;
				Player_Editor player_Editor = dSWUrEXDBiGjFZTwqOGhNFygaZSQ();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.key = "system_player";
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputActionCategory inputActionCategory = JrJFkvBeXSYrCBWsJkNaOsaKiSDdA();
				inputActionCategory.name = "Default";
				inputActionCategory.descriptiveName = inputActionCategory.name;
				actionCategories.Add(inputActionCategory);
				actionCategoryMap.AddCategory(inputActionCategory.id);
				InputBehavior inputBehavior = uYGqZaqXmZKMzemgLfzoasUFADzD();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = rdAjTdATClPZgtVeclYtdqRcFzaPB();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = DcjefxwIzZOmJJzISfZDQRqmWpNx();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = MdptHUyuIGdDhGktRczTgxJhNrgD();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = ukzmLhlHKEeXpHLVwlIheYPcLcxi();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = kswsLUEfNVEZznlXomCocAIYvqEv();
				inputLayout4.name = "Default";
				inputLayout4.descriptiveName = inputLayout4.name;
				customControllerLayouts.Add(inputLayout3);
			}
		}

		[CustomObfuscation(rename = false)]
		internal void SetDefaultValuesOnCreation()
		{
			configVars.platformVars_osxStandalone = new ConfigVars.PlatformVars_OSXStandalone();
			configVars.platformVars_osxStandalone.useAppleGameController = true;
			configVars.platformVars_windowsStandalone = new ConfigVars.PlatformVars_WindowsStandalone();
			configVars.platformVars_windowsStandalone.useWindowsGamingInput = true;
			configVars.keyCombinationOverrideMode = KeyCombinationOverrideMode.Cancel;
			configVars.generateKeyEventsOnKeyCombinationOverride = true;
		}

		public List<InputAction> GetActions_Copy()
		{
			List<InputAction> list = new List<InputAction>();
			for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
			{
				list.Add(dUYEBfdxdeFmejEEDExIosmzBhsr[i]);
			}
			return list;
		}

		public List<InputBehavior> GetInputBehaviors_Copy()
		{
			List<InputBehavior> list = new List<InputBehavior>();
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				list.Add(inputBehaviors[i].Clone());
			}
			return list;
		}

		public List<KeyboardMap> GetKeyboardMaps_Copy()
		{
			List<KeyboardMap> list = new List<KeyboardMap>();
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				KeyboardMap item = keyboardMaps[i].DQbdpZSwBvYBLWqsrAfEfpnXmASpA(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].BLSwEYiEfripYkuhKxoESxePUqzr(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(dSWUrEXDBiGjFZTwqOGhNFygaZSQ());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, dSWUrEXDBiGjFZTwqOGhNFygaZSQ());
		}

		public void DeletePlayer(int index)
		{
			if (players == null || index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.RemoveAt(index);
		}

		public bool ReorderPlayer(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(players, index, offsetDown, offsetNow);
		}

		public void DuplicatePlayer(int index)
		{
			if (players == null || index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			Player_Editor player_Editor = players[index].Clone();
			player_Editor.id = GetNewPlayerId();
			player_Editor.name = StringTools.IterateName(player_Editor.name, -1, GetPlayerNames());
			player_Editor.assignMouseOnStart = false;
			if (index == players.Count - 1)
			{
				players.Add(player_Editor);
			}
			else
			{
				players.Insert(index + 1, player_Editor);
			}
		}

		public string[] GetPlayerNames()
		{
			if (players == null)
			{
				return null;
			}
			string[] array = new string[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				array[i] = players[i].name;
			}
			return array;
		}

		public int GetPlayerNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (players == null)
			{
				return 0;
			}
			for (int i = 0; i < players.Count; i++)
			{
				results.Add(players[i].name);
			}
			return results.Count;
		}

		public int[] GetPlayerIds()
		{
			if (players == null)
			{
				return null;
			}
			int[] array = new int[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				array[i] = players[i].id;
			}
			return array;
		}

		public int[] GetPlayerRuntimeIds()
		{
			if (players == null)
			{
				return null;
			}
			int[] array = new int[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				if (i == 0)
				{
					array[i] = 9999999;
				}
				else
				{
					array[i] = i - 1;
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
			results.Clear();
			if (players == null)
			{
				return 0;
			}
			for (int i = 0; i < players.Count; i++)
			{
				if (i == 0)
				{
					results.Add(9999999);
				}
				else
				{
					results.Add(i - 1);
				}
			}
			return results.Count;
		}

		public string GetPlayerNameById(int id)
		{
			if (players == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < players.Count; i++)
			{
				if (players[i].id == id)
				{
					return players[i].name;
				}
			}
			return string.Empty;
		}

		public Player_Editor GetPlayer(int index)
		{
			if (players == null || index < 0 || index >= players.Count)
			{
				return null;
			}
			return players[index];
		}

		public int GetPlayerId(string name)
		{
			if (players == null)
			{
				return -1;
			}
			for (int i = 0; i < players.Count; i++)
			{
				if (players[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return players[i].id;
				}
			}
			return -1;
		}

		public bool IsMouseAssigned()
		{
			if (players == null)
			{
				return false;
			}
			int count = players.Count;
			for (int i = 0; i < count; i++)
			{
				if (players[i].assignMouseOnStart)
				{
					return true;
				}
			}
			return false;
		}

		public void ClearMouseAssignments()
		{
			if (players != null)
			{
				int count = players.Count;
				for (int i = 0; i < count; i++)
				{
					players[i].assignMouseOnStart = false;
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
			for (int i = 0; i < count; i++)
			{
				if (players[i].assignKeyboardOnStart)
				{
					return true;
				}
			}
			return false;
		}

		public void ClearKeyboardAssignments()
		{
			if (players != null)
			{
				int count = players.Count;
				for (int i = 0; i < count; i++)
				{
					players[i].assignKeyboardOnStart = false;
				}
			}
		}

		public void AddAction(int categoryId)
		{
			InputAction inputAction = CAlflkcFiEDjmUesbIpPkjYmWOifA();
			inputAction.categoryId = categoryId;
			dUYEBfdxdeFmejEEDExIosmzBhsr.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (dUYEBfdxdeFmejEEDExIosmzBhsr != null)
			{
				InputAction inputAction = CAlflkcFiEDjmUesbIpPkjYmWOifA();
				inputAction.categoryId = categoryId;
				dUYEBfdxdeFmejEEDExIosmzBhsr.Add(inputAction);
				int index = actionCategoryMap.IndexOfAction(categoryId, actionId);
				actionCategoryMap.InsertAction(categoryId, inputAction.id, index);
			}
		}

		public void DeleteAction(int categoryId, int actionId)
		{
			if (IndexOfActionCategory(categoryId) >= 0)
			{
				int num = IndexOfAction(actionId);
				if (num >= 0)
				{
					dUYEBfdxdeFmejEEDExIosmzBhsr.RemoveAt(num);
					actionCategoryMap.RemoveAction(categoryId, actionId);
				}
			}
		}

		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			return actionCategoryMap.ReorderAction(categoryId, actionId, offsetDown, offsetNow);
		}

		public int DuplicateAction_FromButton(int categoryId, int actionId)
		{
			if (IndexOfActionCategory(categoryId) < 0)
			{
				return -1;
			}
			int num = IndexOfAction(actionId);
			if (num < 0)
			{
				return -1;
			}
			InputAction actionById = GetActionById(actionId);
			if (actionById == null)
			{
				return -1;
			}
			InputAction inputAction = actionById.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			if (num == dUYEBfdxdeFmejEEDExIosmzBhsr.Count - 1)
			{
				dUYEBfdxdeFmejEEDExIosmzBhsr.Add(inputAction);
				actionCategoryMap.AddAction(categoryId, inputAction.id);
				return dUYEBfdxdeFmejEEDExIosmzBhsr.Count - 1;
			}
			dUYEBfdxdeFmejEEDExIosmzBhsr.Insert(num + 1, inputAction);
			int num2 = actionCategoryMap.IndexOfAction(categoryId, actionId);
			actionCategoryMap.InsertAction(categoryId, inputAction.id, num2 + 1);
			return num + 1;
		}

		private int vfdHbxBtgslNTqDAujOafkpSImgb(int P_0, InputAction P_1)
		{
			if (IndexOfActionCategory(P_0) < 0)
			{
				return -1;
			}
			InputAction inputAction = P_1.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			dUYEBfdxdeFmejEEDExIosmzBhsr.Add(inputAction);
			return dUYEBfdxdeFmejEEDExIosmzBhsr.Count - 1;
		}

		public string[] GetActionNames()
		{
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return null;
			}
			string[] array = new string[dUYEBfdxdeFmejEEDExIosmzBhsr.Count];
			for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
			{
				array[i] = dUYEBfdxdeFmejEEDExIosmzBhsr[i].name;
			}
			return array;
		}

		public int GetActionNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return 0;
			}
			for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
			{
				results.Add(dUYEBfdxdeFmejEEDExIosmzBhsr[i].name);
			}
			return results.Count;
		}

		public int[] GetActionIds()
		{
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return null;
			}
			int[] array = new int[dUYEBfdxdeFmejEEDExIosmzBhsr.Count];
			for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
			{
				array[i] = dUYEBfdxdeFmejEEDExIosmzBhsr[i].id;
			}
			return array;
		}

		public int GetActionIds(IList<int> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return 0;
			}
			for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
			{
				results.Add(dUYEBfdxdeFmejEEDExIosmzBhsr[i].id);
			}
			return results.Count;
		}

		public string GetActionNameById(int id)
		{
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
			{
				if (dUYEBfdxdeFmejEEDExIosmzBhsr[i].id == id)
				{
					return dUYEBfdxdeFmejEEDExIosmzBhsr[i].name;
				}
			}
			return string.Empty;
		}

		public InputAction GetAction(int index)
		{
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null || index < 0 || index >= dUYEBfdxdeFmejEEDExIosmzBhsr.Count)
			{
				return null;
			}
			return dUYEBfdxdeFmejEEDExIosmzBhsr[index];
		}

		public InputAction GetAction(string name)
		{
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return null;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return null;
			}
			return dUYEBfdxdeFmejEEDExIosmzBhsr[num];
		}

		public InputAction GetActionById(int id)
		{
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return null;
			}
			for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
			{
				if (dUYEBfdxdeFmejEEDExIosmzBhsr[i].id == id)
				{
					return dUYEBfdxdeFmejEEDExIosmzBhsr[i];
				}
			}
			return null;
		}

		public int GetActionId(string name)
		{
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return -1;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return -1;
			}
			return dUYEBfdxdeFmejEEDExIosmzBhsr[num].id;
		}

		public string[] GetSortedActionNamesInCategory(int id)
		{
			if (actionCategories == null || dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
			{
				InputAction actionById = GetActionById(item);
				if (actionById != null)
				{
					list.Add(actionById.name);
				}
			}
			return list.ToArray();
		}

		[IteratorStateMachine(typeof(RhssdQLBmlPaxLfTKYAPhxogOVOD))]
		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			return new RhssdQLBmlPaxLfTKYAPhxogOVOD(-2)
			{
				TALjHgRvrCTFvCmamcDDfnNMPmqsA = this,
				plFFLfDSkarMjuGXICJcFNEiIoahB = id
			};
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (actionCategories == null || dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
			{
				InputAction actionById = GetActionById(item);
				if (actionById != null)
				{
					list.Add(actionById.descriptiveName);
				}
			}
			return list.ToArray();
		}

		[IteratorStateMachine(typeof(ZKnEyiFOQzsiCMWWZnxLNlJSChxIA))]
		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			return new ZKnEyiFOQzsiCMWWZnxLNlJSChxIA(-2)
			{
				gVuaGRaSByhiDnBcRNjHWcMtIYAtA = this,
				mBcqbCNEHGjvZwKlrZTKiNryhORs = id
			};
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			if (actionCategories == null || dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return null;
			}
			List<int> list = new List<int>();
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
			{
				list.Add(item);
			}
			return list.ToArray();
		}

		[IteratorStateMachine(typeof(PHjDKYZFBKcsIHoHofSiQzghAdlUA))]
		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			return new PHjDKYZFBKcsIHoHofSiQzghAdlUA(-2)
			{
				kECJGnnTGXQrimJMwtjTUnZpnMfM = this,
				fSzwjzijxFnylmBITJbUDtGTFlSb = id
			};
		}

		public bool ContainsAction(int id)
		{
			return IndexOfAction(id) >= 0;
		}

		public int IndexOfAction(int id)
		{
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return -1;
			}
			for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
			{
				if (dUYEBfdxdeFmejEEDExIosmzBhsr[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfAction(string name)
		{
			if (dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
			{
				if (dUYEBfdxdeFmejEEDExIosmzBhsr[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddActionCategory()
		{
			InputActionCategory inputActionCategory = JrJFkvBeXSYrCBWsJkNaOsaKiSDdA();
			actionCategories.Add(inputActionCategory);
			actionCategoryMap.AddCategory(inputActionCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputActionCategory inputActionCategory = JrJFkvBeXSYrCBWsJkNaOsaKiSDdA();
			actionCategories.Insert(index, inputActionCategory);
			actionCategoryMap.AddCategory(inputActionCategory.id);
		}

		public void DeleteActionCategory(int index)
		{
			if (actionCategories == null || index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = actionCategories[index].id;
			actionCategoryMap.RemoveCategory(id);
			if (dUYEBfdxdeFmejEEDExIosmzBhsr != null)
			{
				for (int num = dUYEBfdxdeFmejEEDExIosmzBhsr.Count - 1; num >= 0; num--)
				{
					if (dUYEBfdxdeFmejEEDExIosmzBhsr[num].categoryId == id)
					{
						dUYEBfdxdeFmejEEDExIosmzBhsr.RemoveAt(num);
					}
				}
			}
			actionCategories.RemoveAt(index);
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
			if (actionCategories == null || index < 0 || index >= actionCategories.Count)
			{
				return;
			}
			InputActionCategory inputActionCategory = new InputActionCategory(actionCategories[index]);
			inputActionCategory.id = GetNewActionCategoryId();
			inputActionCategory.name = StringTools.IterateName(inputActionCategory.name, -1, GetActionCategoryNames());
			if (index == actionCategories.Count - 1)
			{
				actionCategories.Add(inputActionCategory);
			}
			else
			{
				actionCategories.Insert(index + 1, inputActionCategory);
			}
			actionCategoryMap.AddCategory(inputActionCategory.id);
			if (!duplicateActions || dUYEBfdxdeFmejEEDExIosmzBhsr == null)
			{
				return;
			}
			int id = inputActionCategory.id;
			int id2 = actionCategories[index].id;
			List<int> list = new List<int>();
			for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
			{
				if (dUYEBfdxdeFmejEEDExIosmzBhsr[i].categoryId == id2)
				{
					list.Add(i);
				}
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>(list.Count);
			for (int j = 0; j < list.Count; j++)
			{
				InputAction inputAction = dUYEBfdxdeFmejEEDExIosmzBhsr[list[j]];
				int num = vfdHbxBtgslNTqDAujOafkpSImgb(id2, inputAction);
				if (num >= 0)
				{
					InputAction inputAction2 = dUYEBfdxdeFmejEEDExIosmzBhsr[num];
					inputAction2.categoryId = id;
					dictionary.Add(inputAction.id, inputAction2.id);
				}
			}
			foreach (int item in actionCategoryMap.ActionIdsInCategory(id2))
			{
				if (dictionary.TryGetValue(item, out var value))
				{
					actionCategoryMap.AddAction(id, value);
				}
			}
		}

		public void ChangeActionCategory(int actionId, int newCategoryId)
		{
			int num = IndexOfAction(actionId);
			if (num >= 0 && dUYEBfdxdeFmejEEDExIosmzBhsr[num].categoryId != newCategoryId)
			{
				actionCategoryMap.ChangeCategory(actionId, newCategoryId);
				dUYEBfdxdeFmejEEDExIosmzBhsr[num].categoryId = newCategoryId;
			}
		}

		public int GetActionCategoryCount(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (dUYEBfdxdeFmejEEDExIosmzBhsr != null)
			{
				for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
				{
					if (dUYEBfdxdeFmejEEDExIosmzBhsr[i].categoryId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetActionCategoryIndex(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetActionCategoryNames()
		{
			if (actionCategories == null)
			{
				return null;
			}
			string[] array = new string[actionCategories.Count];
			for (int i = 0; i < actionCategories.Count; i++)
			{
				array[i] = actionCategories[i].name;
			}
			return array;
		}

		public int[] GetActionCategoryIds()
		{
			if (actionCategories == null)
			{
				return null;
			}
			int[] array = new int[actionCategories.Count];
			for (int i = 0; i < actionCategories.Count; i++)
			{
				array[i] = actionCategories[i].id;
			}
			return array;
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
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].id == id)
				{
					return actionCategories[i].name;
				}
			}
			return string.Empty;
		}

		public int IndexOfActionCategory(int id)
		{
			if (actionCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfActionCategory(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (actionCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < actionCategories.Count; i++)
			{
				if (actionCategories[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
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
			inputBehaviors.Add(uYGqZaqXmZKMzemgLfzoasUFADzD());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, uYGqZaqXmZKMzemgLfzoasUFADzD());
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = inputBehaviors[index].id;
			if (dUYEBfdxdeFmejEEDExIosmzBhsr != null)
			{
				for (int i = 0; i < dUYEBfdxdeFmejEEDExIosmzBhsr.Count; i++)
				{
					if (dUYEBfdxdeFmejEEDExIosmzBhsr[i].behaviorId == id)
					{
						dUYEBfdxdeFmejEEDExIosmzBhsr[i].behaviorId = 0;
					}
				}
			}
			inputBehaviors.RemoveAt(index);
		}

		public bool ReorderInputBehavior(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(inputBehaviors, index, offsetDown, offsetNow);
		}

		public void DuplicateInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputBehavior inputBehavior = inputBehaviors[index].Clone();
			inputBehavior.id = GetNewInputBehaviorId();
			inputBehavior.name = StringTools.IterateName(inputBehavior.name, -1, GetInputBehaviorNames());
			if (index == inputBehaviors.Count - 1)
			{
				inputBehaviors.Add(inputBehavior);
			}
			else
			{
				inputBehaviors.Insert(index + 1, inputBehavior);
			}
		}

		public string[] GetInputBehaviorNames()
		{
			if (inputBehaviors == null)
			{
				return null;
			}
			string[] array = new string[inputBehaviors.Count];
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				array[i] = inputBehaviors[i].name;
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
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				array[i] = inputBehaviors[i].id;
			}
			return array;
		}

		public InputBehavior GetInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				return null;
			}
			return inputBehaviors[index];
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
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				if (inputBehaviors[i].id == id)
				{
					return inputBehaviors[i];
				}
			}
			return null;
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
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				if (inputBehaviors[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfInputBehavior(string name)
		{
			if (inputBehaviors == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				if (inputBehaviors[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddMapCategory()
		{
			mapCategories.Add(rdAjTdATClPZgtVeclYtdqRcFzaPB());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, rdAjTdATClPZgtVeclYtdqRcFzaPB());
		}

		public void DeleteMapCategory(int index)
		{
			if (mapCategories == null || index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = mapCategories[index].id;
			if (joystickMaps != null)
			{
				for (int num = joystickMaps.Count - 1; num >= 0; num--)
				{
					if (joystickMaps[num].categoryId == id)
					{
						joystickMaps.RemoveAt(num);
					}
				}
			}
			if (keyboardMaps != null)
			{
				for (int num2 = keyboardMaps.Count - 1; num2 >= 0; num2--)
				{
					if (keyboardMaps[num2].categoryId == id)
					{
						keyboardMaps.RemoveAt(num2);
					}
				}
			}
			if (mouseMaps != null)
			{
				for (int num3 = mouseMaps.Count - 1; num3 >= 0; num3--)
				{
					if (mouseMaps[num3].categoryId == id)
					{
						mouseMaps.RemoveAt(num3);
					}
				}
			}
			if (customControllerMaps != null)
			{
				for (int num4 = customControllerMaps.Count - 1; num4 >= 0; num4--)
				{
					if (customControllerMaps[num4].categoryId == id)
					{
						customControllerMaps.RemoveAt(num4);
					}
				}
			}
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					InputMapCategory inputMapCategory = mapCategories[i];
					if (inputMapCategory.checkConflictsCategoryIds == null)
					{
						continue;
					}
					for (int j = 0; j < inputMapCategory.checkConflictsCategoryIds.Count; j++)
					{
						if (inputMapCategory.checkConflictsCategoryIds[j] == id)
						{
							inputMapCategory.checkConflictsCategoryIds.RemoveAt(j);
						}
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = KPYXPzrHQmXXTKUvLpjZWujwaDxX._003C_003E9.SrcOWmWADDPniiuJyObBhWyxTtMi;
				for (int k = 0; k < players.Count; k++)
				{
					Player_Editor player_Editor = players[k];
					if (player_Editor != null)
					{
						action(player_Editor.defaultKeyboardMaps, id);
						action(player_Editor.defaultMouseMaps, id);
						action(player_Editor.defaultJoystickMaps, id);
						action(player_Editor.defaultCustomControllerMaps, id);
					}
				}
			}
			mapCategories.RemoveAt(index);
		}

		public bool ReorderMapCategory(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mapCategories, index, offsetDown, offsetNow);
		}

		public void DuplicateMapCategory(int index, bool duplicateMaps)
		{
			if (mapCategories == null || index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputMapCategory inputMapCategory = new InputMapCategory(mapCategories[index]);
			inputMapCategory.id = GetNewMapCategoryId();
			inputMapCategory.name = StringTools.IterateName(inputMapCategory.name, -1, GetMapCategoryNames());
			if (index == mapCategories.Count - 1)
			{
				mapCategories.Add(inputMapCategory);
			}
			else
			{
				mapCategories.Insert(index + 1, inputMapCategory);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputMapCategory.id;
			int id2 = mapCategories[index].id;
			if (joystickMaps != null)
			{
				for (int num = joystickMaps.Count - 1; num >= 0; num--)
				{
					if (joystickMaps[num].categoryId == id2)
					{
						int num2 = DuplicateJoystickMap(num);
						if (num2 >= 0)
						{
							joystickMaps[num2].categoryId = id;
						}
					}
				}
			}
			if (keyboardMaps != null)
			{
				for (int num3 = keyboardMaps.Count - 1; num3 >= 0; num3--)
				{
					if (keyboardMaps[num3].categoryId == id2)
					{
						int num4 = DuplicateKeyboardMap(num3);
						if (num4 >= 0)
						{
							keyboardMaps[num4].categoryId = id;
						}
					}
				}
			}
			if (mouseMaps != null)
			{
				for (int num5 = mouseMaps.Count - 1; num5 >= 0; num5--)
				{
					if (mouseMaps[num5].categoryId == id2)
					{
						int num6 = DuplicateMouseMap(num5);
						if (num6 >= 0)
						{
							mouseMaps[num6].categoryId = id;
						}
					}
				}
			}
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num7 = customControllerMaps.Count - 1; num7 >= 0; num7--)
			{
				if (customControllerMaps[num7].categoryId == id2)
				{
					int num8 = DuplicateCustomControllerMap(num7);
					if (num8 >= 0)
					{
						customControllerMaps[num8].categoryId = id;
					}
				}
			}
		}

		public int GetMapCategoryMapCount(int id)
		{
			if (mapCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (joystickMaps != null)
			{
				for (int i = 0; i < joystickMaps.Count; i++)
				{
					if (joystickMaps[i].categoryId == id)
					{
						num++;
					}
				}
			}
			if (keyboardMaps != null)
			{
				for (int j = 0; j < keyboardMaps.Count; j++)
				{
					if (keyboardMaps[j].categoryId == id)
					{
						num++;
					}
				}
			}
			if (mouseMaps != null)
			{
				for (int k = 0; k < mouseMaps.Count; k++)
				{
					if (mouseMaps[k].categoryId == id)
					{
						num++;
					}
				}
			}
			if (customControllerMaps != null)
			{
				for (int l = 0; l < customControllerMaps.Count; l++)
				{
					if (customControllerMaps[l].categoryId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetMapCategoryIndex(int id)
		{
			if (mapCategories == null)
			{
				return 0;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetMapCategoryNames()
		{
			if (mapCategories == null)
			{
				return null;
			}
			string[] array = new string[mapCategories.Count];
			for (int i = 0; i < mapCategories.Count; i++)
			{
				array[i] = mapCategories[i].name;
			}
			return array;
		}

		public int[] GetMapCategoryIds()
		{
			if (mapCategories == null)
			{
				return null;
			}
			int[] array = new int[mapCategories.Count];
			for (int i = 0; i < mapCategories.Count; i++)
			{
				array[i] = mapCategories[i].id;
			}
			return array;
		}

		public InputMapCategory GetMapCategory(int index)
		{
			if (mapCategories == null || index < 0 || index >= mapCategories.Count)
			{
				return null;
			}
			return mapCategories[index];
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
				return null;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return mapCategories[i];
				}
			}
			return null;
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
				return string.Empty;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return mapCategories[i].name;
				}
			}
			return string.Empty;
		}

		public int IndexOfMapCategory(int id)
		{
			if (mapCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfMapCategory(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (mapCategories == null)
			{
				return -1;
			}
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetLayoutNames(ControllerType controllerType)
		{
			return controllerType switch
			{
				ControllerType.Keyboard => GetKeyboardLayoutNames(), 
				ControllerType.Mouse => GetMouseLayoutNames(), 
				ControllerType.Joystick => GetJoystickLayoutNames(), 
				ControllerType.Custom => GetCustomControllerLayoutNames(), 
				_ => throw new NotImplementedException(), 
			};
		}

		public int[] GetLayoutIds(ControllerType controllerType)
		{
			return controllerType switch
			{
				ControllerType.Keyboard => GetKeyboardLayoutIds(), 
				ControllerType.Mouse => GetMouseLayoutIds(), 
				ControllerType.Joystick => GetJoystickLayoutIds(), 
				ControllerType.Custom => GetCustomControllerLayoutIds(), 
				_ => throw new NotImplementedException(), 
			};
		}

		public void AddJoystickLayout()
		{
			joystickLayouts.Add(DcjefxwIzZOmJJzISfZDQRqmWpNx());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, DcjefxwIzZOmJJzISfZDQRqmWpNx());
		}

		public void DeleteJoystickLayout(int index)
		{
			if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = joystickLayouts[index].id;
			if (joystickMaps != null)
			{
				for (int num = joystickMaps.Count - 1; num >= 0; num--)
				{
					if (joystickMaps[num].layoutId == id)
					{
						joystickMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = KPYXPzrHQmXXTKUvLpjZWujwaDxX._003C_003E9.eIRbHjBKITfzqDbTFkuBkycKZtMN;
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor != null)
					{
						action(player_Editor.defaultJoystickMaps, id);
					}
				}
			}
			joystickLayouts.RemoveAt(index);
		}

		public bool ReorderJoystickLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(joystickLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateJoystickLayout(int index, bool duplicateMaps)
		{
			if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = joystickLayouts[index].Clone();
			inputLayout.id = GetNewJoystickLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetJoystickLayoutNames());
			if (index == joystickLayouts.Count - 1)
			{
				joystickLayouts.Add(inputLayout);
			}
			else
			{
				joystickLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = joystickLayouts[index].id;
			if (joystickMaps == null)
			{
				return;
			}
			for (int num = joystickMaps.Count - 1; num >= 0; num--)
			{
				if (joystickMaps[num].layoutId == id2)
				{
					int num2 = DuplicateJoystickMap(num);
					if (num2 >= 0)
					{
						joystickMaps[num2].layoutId = id;
					}
				}
			}
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
				for (int i = 0; i < joystickMaps.Count; i++)
				{
					if (joystickMaps[i].layoutId == id)
					{
						num++;
					}
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
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				if (joystickLayouts[i].id == id)
				{
					return i;
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
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				array[i] = joystickLayouts[i].name;
			}
			return array;
		}

		public int[] GetJoystickLayoutIds()
		{
			if (joystickLayouts == null)
			{
				return null;
			}
			int[] array = new int[joystickLayouts.Count];
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				array[i] = joystickLayouts[i].id;
			}
			return array;
		}

		public InputLayout GetJoystickLayout(int index)
		{
			if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
			{
				return null;
			}
			return joystickLayouts[index];
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
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				if (joystickLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfJoystickLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (joystickLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				if (joystickLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetJoystickLayoutNameById(int id)
		{
			if (joystickLayouts != null)
			{
				for (int i = 0; i < joystickLayouts.Count; i++)
				{
					if (joystickLayouts[i].id == id)
					{
						return joystickLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddKeyboardLayout()
		{
			keyboardLayouts.Add(MdptHUyuIGdDhGktRczTgxJhNrgD());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, MdptHUyuIGdDhGktRczTgxJhNrgD());
		}

		public void DeleteKeyboardLayout(int index)
		{
			if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = keyboardLayouts[index].id;
			if (keyboardMaps != null)
			{
				for (int num = keyboardMaps.Count - 1; num >= 0; num--)
				{
					if (keyboardMaps[num].layoutId == id)
					{
						keyboardMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = KPYXPzrHQmXXTKUvLpjZWujwaDxX._003C_003E9.sxUKlPEDMEnewgAcDGkfZVxxwsvm;
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor != null)
					{
						action(player_Editor.defaultKeyboardMaps, id);
					}
				}
			}
			keyboardLayouts.RemoveAt(index);
		}

		public bool ReorderKeyboardLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(keyboardLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateKeyboardLayout(int index, bool duplicateMaps)
		{
			if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = keyboardLayouts[index].Clone();
			inputLayout.id = GetNewKeyboardLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetKeyboardLayoutNames());
			if (index == keyboardLayouts.Count - 1)
			{
				keyboardLayouts.Add(inputLayout);
			}
			else
			{
				keyboardLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = keyboardLayouts[index].id;
			if (keyboardMaps == null)
			{
				return;
			}
			for (int num = keyboardMaps.Count - 1; num >= 0; num--)
			{
				if (keyboardMaps[num].layoutId == id2)
				{
					int num2 = DuplicateKeyboardMap(num);
					if (num2 >= 0)
					{
						keyboardMaps[num2].layoutId = id;
					}
				}
			}
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
				for (int i = 0; i < keyboardMaps.Count; i++)
				{
					if (keyboardMaps[i].layoutId == id)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetKeyboardLayoutIndex(int id)
		{
			if (keyboardLayouts == null)
			{
				return 0;
			}
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				if (keyboardLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetKeyboardLayoutNames()
		{
			if (keyboardLayouts == null)
			{
				return null;
			}
			string[] array = new string[keyboardLayouts.Count];
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				array[i] = keyboardLayouts[i].name;
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
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				array[i] = keyboardLayouts[i].id;
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
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				if (keyboardLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfKeyboardLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (keyboardLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				if (keyboardLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetKeyboardLayoutNameById(int id)
		{
			if (keyboardLayouts != null)
			{
				for (int i = 0; i < keyboardLayouts.Count; i++)
				{
					if (keyboardLayouts[i].id == id)
					{
						return keyboardLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddMouseLayout()
		{
			mouseLayouts.Add(ukzmLhlHKEeXpHLVwlIheYPcLcxi());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, ukzmLhlHKEeXpHLVwlIheYPcLcxi());
		}

		public void DeleteMouseLayout(int index)
		{
			if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = mouseLayouts[index].id;
			if (mouseMaps != null)
			{
				for (int num = mouseMaps.Count - 1; num >= 0; num--)
				{
					if (mouseMaps[num].layoutId == id)
					{
						mouseMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = KPYXPzrHQmXXTKUvLpjZWujwaDxX._003C_003E9.BfcgloFipPQIElztcuxfljvYpFum;
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor != null)
					{
						action(player_Editor.defaultMouseMaps, id);
					}
				}
			}
			mouseLayouts.RemoveAt(index);
		}

		public bool ReorderMouseLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(mouseLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateMouseLayout(int index, bool duplicateMaps)
		{
			if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = mouseLayouts[index].Clone();
			inputLayout.id = GetNewMouseLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetMouseLayoutNames());
			if (index == mouseLayouts.Count - 1)
			{
				mouseLayouts.Add(inputLayout);
			}
			else
			{
				mouseLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = mouseLayouts[index].id;
			if (mouseMaps == null)
			{
				return;
			}
			for (int num = mouseMaps.Count - 1; num >= 0; num--)
			{
				if (mouseMaps[num].layoutId == id2)
				{
					int num2 = DuplicateMouseMap(num);
					if (num2 >= 0)
					{
						mouseMaps[num2].layoutId = id;
					}
				}
			}
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
				for (int i = 0; i < mouseMaps.Count; i++)
				{
					if (mouseMaps[i].layoutId == id)
					{
						num++;
					}
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
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				if (mouseLayouts[i].id == id)
				{
					return i;
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
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				array[i] = mouseLayouts[i].name;
			}
			return array;
		}

		public int[] GetMouseLayoutIds()
		{
			if (mouseLayouts == null)
			{
				return null;
			}
			int[] array = new int[mouseLayouts.Count];
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				array[i] = mouseLayouts[i].id;
			}
			return array;
		}

		public InputLayout GetMouseLayout(int index)
		{
			if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
			{
				return null;
			}
			return mouseLayouts[index];
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
				return -1;
			}
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				if (mouseLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfMouseLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (mouseLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				if (mouseLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetMouseLayoutNameById(int id)
		{
			if (mouseLayouts != null)
			{
				for (int i = 0; i < mouseLayouts.Count; i++)
				{
					if (mouseLayouts[i].id == id)
					{
						return mouseLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddCustomControllerLayout()
		{
			customControllerLayouts.Add(kswsLUEfNVEZznlXomCocAIYvqEv());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, kswsLUEfNVEZznlXomCocAIYvqEv());
		}

		public void DeleteCustomControllerLayout(int index)
		{
			if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = customControllerLayouts[index].id;
			if (customControllerMaps != null)
			{
				for (int num = customControllerMaps.Count - 1; num >= 0; num--)
				{
					if (customControllerMaps[num].layoutId == id)
					{
						customControllerMaps.RemoveAt(num);
					}
				}
			}
			if (players != null)
			{
				Action<List<Player_Editor.Mapping>, int> action = KPYXPzrHQmXXTKUvLpjZWujwaDxX._003C_003E9.rgVPGEJjFHudWDgIOpxolYcLTHkc;
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor != null)
					{
						action(player_Editor.defaultCustomControllerMaps, id);
					}
				}
			}
			customControllerLayouts.RemoveAt(index);
		}

		public bool ReorderCustomControllerLayout(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllerLayouts, index, offsetDown, offsetNow);
		}

		public void DuplicateCustomControllerLayout(int index, bool duplicateMaps)
		{
			if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputLayout inputLayout = customControllerLayouts[index].Clone();
			inputLayout.id = GetNewCustomControllerLayoutId();
			inputLayout.name = StringTools.IterateName(inputLayout.name, -1, GetCustomControllerLayoutNames());
			if (index == customControllerLayouts.Count - 1)
			{
				customControllerLayouts.Add(inputLayout);
			}
			else
			{
				customControllerLayouts.Insert(index + 1, inputLayout);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = inputLayout.id;
			int id2 = customControllerLayouts[index].id;
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].layoutId == id2)
				{
					int num2 = DuplicateCustomControllerMap(num);
					if (num2 >= 0)
					{
						customControllerMaps[num2].layoutId = id;
					}
				}
			}
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
				for (int i = 0; i < customControllerMaps.Count; i++)
				{
					if (customControllerMaps[i].layoutId == id)
					{
						num++;
					}
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
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				if (customControllerLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetCustomControllerLayoutNames()
		{
			if (customControllerLayouts == null)
			{
				return null;
			}
			string[] array = new string[customControllerLayouts.Count];
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				array[i] = customControllerLayouts[i].name;
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
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				array[i] = customControllerLayouts[i].id;
			}
			return array;
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
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				if (customControllerLayouts[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfCustomControllerLayout(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (customControllerLayouts == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				if (customControllerLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetCustomControllerLayoutNameById(int id)
		{
			if (customControllerLayouts != null)
			{
				for (int i = 0; i < customControllerLayouts.Count; i++)
				{
					if (customControllerLayouts[i].id == id)
					{
						return customControllerLayouts[i].name;
					}
				}
			}
			return "Unknown";
		}

		public string GetLayoutNameById(ControllerType controllerType, int id)
		{
			return controllerType switch
			{
				ControllerType.Joystick => GetJoystickLayoutNameById(id), 
				ControllerType.Keyboard => GetKeyboardLayoutNameById(id), 
				ControllerType.Mouse => GetMouseLayoutNameById(id), 
				ControllerType.Custom => GetCustomControllerLayoutNameById(id), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal ControllerMap vniVhbPNujcZYbXBXYJYpZOHjbtl(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Joystick => yZmJysTiAJlrPpOSedEsHtLLwPgAA((Joystick)P_0, P_1, P_2), 
				ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
				ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
				ControllerType.Custom => DgbFjiULnlYfIPOraXwotTKzqNpf(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public ControllerMap_Editor GetJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return null;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return joystickMaps[i];
				}
			}
			return null;
		}

		public ControllerMap_Editor GetJoystickMapById(int id, out int joystickMapIndex)
		{
			joystickMapIndex = -1;
			if (joystickMaps == null)
			{
				return null;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].id == id)
				{
					joystickMapIndex = i;
					return joystickMaps[i];
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
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					list.Add(joystickMaps[i]);
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
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return joystickMaps[i].id;
				}
			}
			return -1;
		}

		public bool HasJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasJoystickMap(Guid hardwareGuid)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasJoystickMapInCategory(Guid hardwareGuid, int categoryId)
		{
			if (joystickMaps == null)
			{
				return false;
			}
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid && joystickMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateJoystickMap(int categoryId, Guid joystickOrTemplateGuid, int layoutId)
		{
			if (joystickMaps == null)
			{
				joystickMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewJoystickMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			controllerMap_Editor.hardwareGuidString = joystickOrTemplateGuid.ToString();
			joystickMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteJoystickMap(int id)
		{
			if (joystickMaps == null)
			{
				return;
			}
			for (int num = joystickMaps.Count - 1; num >= 0; num--)
			{
				if (joystickMaps[num].id == id)
				{
					joystickMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateJoystickMap(int index)
		{
			if (joystickMaps == null || index < 0 || index >= joystickMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = joystickMaps[index].Clone();
			controllerMap_Editor.id = GetNewJoystickMapId();
			joystickMaps.Add(controllerMap_Editor);
			return joystickMaps.Count - 1;
		}

		internal JoystickMap ATPxcsuMveBpAQADaPtbnWoSQNVV(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return BCsLNUSyQDgOlWlHfzAZrFqQGqSJA(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap yZmJysTiAJlrPpOSedEsHtLLwPgAA(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return BCsLNUSyQDgOlWlHfzAZrFqQGqSJA(P_0.AfDBidYDTALZBDbSZzCaFMdBJkKeA, P_1, P_2);
		}

		private JoystickMap BCsLNUSyQDgOlWlHfzAZrFqQGqSJA(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.bWsYGlWoxdfYJcOviJwdunJOwNcL(guid);
			ControllerMap_Editor controllerMap_Editor = vaVIjqHEhRKtJOhPomuhgQWFnhiJA(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.UOKtQmMdeccMNXUBdtmfGdRDeHMJ(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.UKGCInAZAfYaFxvMNcnAuPNTdQmAb(guid, P_1, P_2);
				return joystickMap;
			}
			if (hardwareJoystickMap != null)
			{
				foreach (Guid templateGuid in hardwareJoystickMap.TemplateGuids)
				{
					if (templateGuid == Guid.Empty)
					{
						continue;
					}
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.hcOivUPjVCvgdJumTCstMWcUnqVc(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = vaVIjqHEhRKtJOhPomuhgQWFnhiJA(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = qhjDUiUmQJIlmoErodlavrzbeerd(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.UKGCInAZAfYaFxvMNcnAuPNTdQmAb(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty)
			{
				controllerMap_Editor = vaVIjqHEhRKtJOhPomuhgQWFnhiJA(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.UOKtQmMdeccMNXUBdtmfGdRDeHMJ(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.UKGCInAZAfYaFxvMNcnAuPNTdQmAb(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.QGQzxeoUrvqTgKgBjcpIIMruduyiA(guid, P_1, P_2);
		}

		private ControllerMap_Editor vaVIjqHEhRKtJOhPomuhgQWFnhiJA(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = GYHJQFBKCqnSqTnQKcfddDZBqdNM(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor GYHJQFBKCqnSqTnQKcfddDZBqdNM(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				jUZdTViGVWtoISGraFriLtwViaDeA(list, joystickLayouts);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == P_0)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		private JoystickMap qhjDUiUmQJIlmoErodlavrzbeerd(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.xbxZTwGmXmGgZIVrBuILoJxkDaCzA(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError("Error remapping joystick template " + P_2.Guid.ToString() + " to joystick " + P_0.guid.ToString() + "\nReason: " + text);
				return null;
			}
			return controllerMap_Editor.UOKtQmMdeccMNXUBdtmfGdRDeHMJ(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap SavWfvlXlPvWGCfQTgadINUuafWX(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.bWsYGlWoxdfYJcOviJwdunJOwNcL(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.bWsYGlWoxdfYJcOviJwdunJOwNcL(Guid.Empty);
			if (hardwareJoystickMap2 == null)
			{
				return null;
			}
			hardwareJoystickMap.GetElementIdentifiersForControllerElements(P_1, isDefaultMap: false, out var buttons, out var axes);
			if (buttons == null && axes == null)
			{
				return null;
			}
			bool flag = false;
			List<int> list = new List<int>();
			foreach (ActionElementMap allMap in P_0.AllMaps)
			{
				ControllerElementIdentifier elementIdentifier = hardwareJoystickMap2.GetElementIdentifier(allMap._elementIdentifierId);
				if (elementIdentifier != null)
				{
					string text = elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					if (!string.IsNullOrEmpty(text))
					{
						int num = 0;
						int num2 = text.IndexOf("button", 0, StringComparison.OrdinalIgnoreCase);
						if (num2 < 0)
						{
							num2 = text.IndexOf("axis", 0, StringComparison.OrdinalIgnoreCase);
							num = 1;
						}
						if (num2 >= 0 && (num != 0 || buttons != null) && (num != 1 || axes != null))
						{
							string text2 = Regex.Replace(text, "[^0-9]+", "");
							Logger.Log(text2);
							if (int.TryParse(text2, out var result))
							{
								if (num == 0)
								{
									if (result < buttons.Length)
									{
										allMap._elementIdentifierId = buttons[result];
										goto IL_011f;
									}
								}
								else if (result < axes.Length)
								{
									allMap._elementIdentifierId = axes[result];
									goto IL_011f;
								}
							}
						}
					}
				}
				list.Add(allMap.gjHUlVyQSQsjZEOHtHfmeehEQpiIA);
				continue;
				IL_011f:
				flag = true;
			}
			for (int i = 0; i < list.Count; i++)
			{
				P_0.DeleteElementMap(list[i]);
			}
			if (!flag)
			{
				return null;
			}
			return P_0;
		}

		public ControllerMap_Editor GetKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return null;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
				{
					return keyboardMaps[i];
				}
			}
			return null;
		}

		public int GetKeyboardMapId(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				return -1;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
				{
					return keyboardMaps[i].id;
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
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId && StringTools.ToGuid(keyboardMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateKeyboardMap(int categoryId, int layoutId)
		{
			if (keyboardMaps == null)
			{
				keyboardMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewKeyboardMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			keyboardMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteKeyboardMap(int id)
		{
			if (keyboardMaps == null)
			{
				return;
			}
			for (int num = keyboardMaps.Count - 1; num >= 0; num--)
			{
				if (keyboardMaps[num].id == id)
				{
					keyboardMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateKeyboardMap(int index)
		{
			if (keyboardMaps == null || index < 0 || index >= keyboardMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
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
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].id == id)
				{
					keyboardMapIndex = i;
					return keyboardMaps[i];
				}
			}
			return null;
		}

		public KeyboardMap FindKeyboardMap_Game(Keyboard keyboard, int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = gupXemOsrzmrjQkuhTGTEvIykaUi(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.DQbdpZSwBvYBLWqsrAfEfpnXmASpA(containsActionDelegate);
				keyboardMap.tTrqhemBzriyvvTmkZtEoOACeTzc(keyboard.qapLJarKYePKdgQROGMwYujqCcvB, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.MitadNEcsVptWOBpQJnpDDXTaMvGb(keyboard.qapLJarKYePKdgQROGMwYujqCcvB, categoryId, layoutId);
			}
			return keyboardMap;
		}

		public bool HasKeyboardMapInCategory(int categoryId)
		{
			if (keyboardMaps == null)
			{
				return false;
			}
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId)
				{
					return true;
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
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
				{
					return true;
				}
			}
			return false;
		}

		public ControllerMap_Editor GetMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return null;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
				{
					return mouseMaps[i];
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
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
				{
					return mouseMaps[i].id;
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
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId && StringTools.ToGuid(mouseMaps[i].hardwareGuidString) == hardwareGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateMouseMap(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				mouseMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewMouseMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			mouseMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteMouseMap(int id)
		{
			if (mouseMaps == null)
			{
				return;
			}
			for (int num = mouseMaps.Count - 1; num >= 0; num--)
			{
				if (mouseMaps[num].id == id)
				{
					mouseMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateMouseMap(int index)
		{
			if (mouseMaps == null || index < 0 || index >= mouseMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = mouseMaps[index].Clone();
			controllerMap_Editor.id = GetNewMouseMapId();
			mouseMaps.Add(controllerMap_Editor);
			return mouseMaps.Count - 1;
		}

		public ControllerMap_Editor GetMouseMapById(int id, out int mouseMapIndex)
		{
			mouseMapIndex = -1;
			if (mouseMaps == null)
			{
				return null;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].id == id)
				{
					mouseMapIndex = i;
					return mouseMaps[i];
				}
			}
			return null;
		}

		public MouseMap FindMouseMap_Game(Mouse mouse, int categoryId, int layoutId)
		{
			ControllerMap_Editor controllerMap_Editor = gupXemOsrzmrjQkuhTGTEvIykaUi(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.BLSwEYiEfripYkuhKxoESxePUqzr(containsActionDelegate);
				mouseMap.WYDBctXArXGxCohOgKdYiZTTLmCK(mouse.qapLJarKYePKdgQROGMwYujqCcvB, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.KMtKRacDvbhYEhVwvclsvpNAaEMcA(mouse.qapLJarKYePKdgQROGMwYujqCcvB, categoryId, layoutId);
			}
			return mouseMap;
		}

		public bool HasMouseMapInCategory(int categoryId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasMouseMapInLayout(int categoryId, int layoutId)
		{
			if (mouseMaps == null)
			{
				return false;
			}
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
				{
					return true;
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
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].customControllerUid == controllerUid)
				{
					return customControllerMaps[i];
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
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].id == mapId)
				{
					customControllerMapIndex = i;
					return customControllerMaps[i];
				}
			}
			return null;
		}

		public List<ControllerMap_Editor> GetCustomControllerMaps(int controllerUid)
		{
			if (customControllerMaps == null)
			{
				return null;
			}
			List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].customControllerUid == controllerUid)
				{
					list.Add(customControllerMaps[i]);
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
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].customControllerUid == controllerUid)
				{
					return customControllerMaps[i].id;
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
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].id == mapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasCustomControllerMap(int mapId)
		{
			if (customControllerMaps == null)
			{
				return false;
			}
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].id == mapId)
				{
					return true;
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
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].customControllerUid == controllerUid && customControllerMaps[i].categoryId == categoryId)
				{
					return true;
				}
			}
			return false;
		}

		public bool CreateCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			if (customControllerMaps == null)
			{
				customControllerMaps = new List<ControllerMap_Editor>();
			}
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = GetNewCustomControllerMapId();
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			controllerMap_Editor.hardwareGuidString = string.Empty;
			controllerMap_Editor.customControllerUid = controllerUid;
			customControllerMaps.Add(controllerMap_Editor);
			return false;
		}

		public void DeleteCustomControllerMap(int mapId)
		{
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].id == mapId)
				{
					customControllerMaps.RemoveAt(num);
				}
			}
		}

		public int DuplicateCustomControllerMap(int index)
		{
			if (customControllerMaps == null || index < 0 || index >= customControllerMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMap_Editor controllerMap_Editor = customControllerMaps[index].Clone();
			controllerMap_Editor.id = GetNewCustomControllerMapId();
			customControllerMaps.Add(controllerMap_Editor);
			return customControllerMaps.Count - 1;
		}

		internal CustomControllerMap YpviIYgbXxNRlWPVezMWDIbmbhlc(Guid P_0, int P_1, int P_2)
		{
			return FCQgfsCHAuqeMoxxgMdvmnCAVXDJ(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap DgbFjiULnlYfIPOraXwotTKzqNpf(int P_0, int P_1, int P_2)
		{
			return FCQgfsCHAuqeMoxxgMdvmnCAVXDJ(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap FCQgfsCHAuqeMoxxgMdvmnCAVXDJ(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = qcGBbVPLRmNqkToDkxuDxAbAQdDo(P_1, id, P_2, false);
			if (controllerMap_Editor != null)
			{
				CustomControllerMap customControllerMap = controllerMap_Editor.JfNABWpIDNBIHbWBornZlxgSSBTgA(ContainsAction, P_0);
				customControllerMap.CATPnwnPFymyUPgAJpLcNQCzeNCS(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			CustomControllerMap customControllerMap2 = CustomControllerMap.TNybGMHEEnuLhzpMldXmhoTTqjfkA(P_0.typeGuid, id, P_1, P_2);
			customControllerMap2.CATPnwnPFymyUPgAJpLcNQCzeNCS(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap2;
		}

		private ControllerMap_Editor qcGBbVPLRmNqkToDkxuDxAbAQdDo(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = WunENXsyQynZlOkgmeSQkhwJasFeA(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor WunENXsyQynZlOkgmeSQkhwJasFeA(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				jUZdTViGVWtoISGraFriLtwViaDeA(list, customControllerLayouts);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == P_0)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		public void DeleteControllerMap(ControllerType controllerType, int id)
		{
			switch (controllerType)
			{
			case ControllerType.Joystick:
				DeleteJoystickMap(id);
				break;
			case ControllerType.Keyboard:
				DeleteKeyboardMap(id);
				break;
			case ControllerType.Mouse:
				DeleteMouseMap(id);
				break;
			case ControllerType.Custom:
				DeleteCustomControllerMap(id);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public ControllerMap_Editor GetControllerMapByIndex(ControllerType controllerType, int index)
		{
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
					return null;
				}
				return keyboardMaps[index];
			case ControllerType.Mouse:
				if (mouseMaps == null)
				{
					return null;
				}
				return mouseMaps[index];
			case ControllerType.Custom:
				if (customControllerMaps == null)
				{
					return null;
				}
				return customControllerMaps[index];
			default:
				throw new NotImplementedException();
			}
		}

		public ControllerMap_Editor GetControllerMapById(ControllerType controllerType, int id, out int controllerMapIndex)
		{
			return controllerType switch
			{
				ControllerType.Joystick => GetJoystickMapById(id, out controllerMapIndex), 
				ControllerType.Keyboard => GetKeyboardMapById(id, out controllerMapIndex), 
				ControllerType.Mouse => GetMouseMapById(id, out controllerMapIndex), 
				ControllerType.Custom => GetCustomControllerMapById(id, out controllerMapIndex), 
				_ => throw new NotImplementedException(), 
			};
		}

		public int DuplicateControllerMap(ControllerType controllerType, int index)
		{
			return controllerType switch
			{
				ControllerType.Joystick => DuplicateJoystickMap(index), 
				ControllerType.Keyboard => DuplicateKeyboardMap(index), 
				ControllerType.Mouse => DuplicateMouseMap(index), 
				ControllerType.Custom => DuplicateCustomControllerMap(index), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal ControllerTemplateMap ICUczwpuGWZamujSGnDFlMnUjjLo(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.MtrboDhSBRWVPcVgmGaWfESlGsbJA();
		}

		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void AddCustomController()
		{
			AddCustomController(Guid.NewGuid());
		}

		public void AddCustomController(Guid typeGuid)
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			customControllers.Add(fxbhXWcpwzEEwBrNpMgaNrVITDrR(typeGuid));
		}

		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void InsertCustomController(int index)
		{
			InsertCustomController(index, Guid.NewGuid());
		}

		public void InsertCustomController(int index, Guid typeGuid)
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			if (index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllers.Insert(index, fxbhXWcpwzEEwBrNpMgaNrVITDrR(typeGuid));
		}

		public void DeleteCustomController(int index)
		{
			if (customControllers == null || index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = customControllers[index].id;
			if (customControllerMaps != null)
			{
				for (int num = customControllerMaps.Count - 1; num >= 0; num--)
				{
					if (customControllerMaps[num].customControllerUid == id)
					{
						customControllerMaps.RemoveAt(num);
					}
				}
			}
			customControllers.RemoveAt(index);
		}

		public bool ReorderCustomController(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(customControllers, index, offsetDown, offsetNow);
		}

		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void DuplicateCustomController(int index, bool duplicateMaps)
		{
			DuplicateCustomController(index, duplicateMaps, Guid.NewGuid());
		}

		public void DuplicateCustomController(int index, bool duplicateMaps, Guid typeGuid)
		{
			if (customControllers == null || index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			CustomController_Editor customController_Editor = customControllers[index].Clone();
			customController_Editor.id = GetNewCustomControllerId();
			customController_Editor.typeGuid = typeGuid;
			customController_Editor.name = StringTools.IterateName(customController_Editor.name, -1, GetCustomControllerNames());
			if (index == customControllers.Count - 1)
			{
				customControllers.Add(customController_Editor);
			}
			else
			{
				customControllers.Insert(index + 1, customController_Editor);
			}
			if (!duplicateMaps)
			{
				return;
			}
			int id = customController_Editor.id;
			int id2 = customControllers[index].id;
			if (customControllerMaps == null)
			{
				return;
			}
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].customControllerUid == id2)
				{
					int num2 = DuplicateCustomControllerMap(num);
					if (num2 >= 0)
					{
						customControllerMaps[num2].customControllerUid = id;
					}
				}
			}
		}

		public int GetCustomControllerMapCount(int controllerUid)
		{
			if (customControllers == null)
			{
				return 0;
			}
			int num = 0;
			if (customControllerMaps != null)
			{
				for (int i = 0; i < customControllerMaps.Count; i++)
				{
					if (customControllerMaps[i].customControllerUid == controllerUid)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetCustomControllerIndex(int id)
		{
			if (customControllers == null)
			{
				return 0;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetCustomControllerNames()
		{
			if (customControllers == null)
			{
				return null;
			}
			string[] array = new string[customControllers.Count];
			for (int i = 0; i < customControllers.Count; i++)
			{
				array[i] = customControllers[i].name;
			}
			return array;
		}

		public int[] GetCustomControllerIds()
		{
			if (customControllers == null)
			{
				return null;
			}
			int[] array = new int[customControllers.Count];
			for (int i = 0; i < customControllers.Count; i++)
			{
				array[i] = customControllers[i].id;
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
			for (int i = 0; i < customControllers.Count; i++)
			{
				array[i] = customControllers[i].typeGuid;
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
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfCustomController(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (customControllers == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfCustomController(Guid hardwareTypeGuid)
		{
			if (customControllers == null)
			{
				return -1;
			}
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].typeGuid == hardwareTypeGuid)
				{
					return i;
				}
			}
			return -1;
		}

		public string GetCustomControllerNameById(int id)
		{
			if (customControllers != null)
			{
				for (int i = 0; i < customControllers.Count; i++)
				{
					if (customControllers[i].id == id)
					{
						return customControllers[i].name;
					}
				}
			}
			return "Unknown";
		}

		public void AddControllerMapLayoutManagerRuleSet()
		{
			controllerMapLayoutManagerRuleSets.Add(AkHKbrnmrzgYKXwOGpdRmxajsMxB());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, AkHKbrnmrzgYKXwOGpdRmxajsMxB());
		}

		public void DeleteControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = controllerMapLayoutManagerRuleSets[index].id;
			if (players != null)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num = ruleSets.Count - 1; num >= 0; num--)
					{
						if (ruleSets[num] != null && ruleSets[num].id == id)
						{
							ruleSets.RemoveAt(num);
						}
					}
				}
			}
			controllerMapLayoutManagerRuleSets.RemoveAt(index);
		}

		public bool ReorderControllerMapLayoutManagerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapLayoutManagerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapLayoutManagerRuleSet(int index)
		{
			if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = controllerMapLayoutManagerRuleSets[index].Clone();
			controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
			controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName(controllerMapLayoutManager_RuleSet_Editor.name, -1, GetControllerMapLayoutManagerRuleSetNames());
			if (index == controllerMapLayoutManagerRuleSets.Count - 1)
			{
				controllerMapLayoutManagerRuleSets.Add(controllerMapLayoutManager_RuleSet_Editor);
			}
			else
			{
				controllerMapLayoutManagerRuleSets.Insert(index + 1, controllerMapLayoutManager_RuleSet_Editor);
			}
		}

		public int GetControllerMapLayoutManagerRuleSetUsedCount(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			int num = 0;
			if (players != null)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num2 = ruleSets.Count - 1; num2 >= 0; num2--)
					{
						if (ruleSets[num2] != null && ruleSets[num2].id == id)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		public int GetControllerMapLayoutManagerRuleSetIndex(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return 0;
			}
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (controllerMapLayoutManagerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetControllerMapLayoutManagerRuleSetNames()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			string[] array = new string[controllerMapLayoutManagerRuleSets.Count];
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				array[i] = controllerMapLayoutManagerRuleSets[i].name;
			}
			return array;
		}

		public int[] GetControllerMapLayoutManagerRuleSetIds()
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return null;
			}
			int[] array = new int[controllerMapLayoutManagerRuleSets.Count];
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				array[i] = controllerMapLayoutManagerRuleSets[i].id;
			}
			return array;
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
				return -1;
			}
			int num = IndexOfControllerMapLayoutManagerRuleSet(name);
			if (num < 0)
			{
				return -1;
			}
			return controllerMapLayoutManagerRuleSets[num].id;
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(int id)
		{
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (controllerMapLayoutManagerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (controllerMapLayoutManagerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (controllerMapLayoutManagerRuleSets[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetControllerMapLayoutManagerRuleSetNameById(int id)
		{
			if (controllerMapLayoutManagerRuleSets != null)
			{
				for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
				{
					if (controllerMapLayoutManagerRuleSets[i].id == id)
					{
						return controllerMapLayoutManagerRuleSets[i].name;
					}
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
			controllerMapEnablerRuleSets.Add(XszClfuDcDditCaIekKbkwYbzwEJA());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, XszClfuDcDditCaIekKbkwYbzwEJA());
		}

		public void DeleteControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = controllerMapEnablerRuleSets[index].id;
			if (players != null)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num = ruleSets.Count - 1; num >= 0; num--)
					{
						if (ruleSets[num] != null && ruleSets[num].id == id)
						{
							ruleSets.RemoveAt(num);
						}
					}
				}
			}
			controllerMapEnablerRuleSets.RemoveAt(index);
		}

		public bool ReorderControllerMapEnablerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(controllerMapEnablerRuleSets, index, offsetDown, offsetNow);
		}

		public void DuplicateControllerMapEnablerRuleSet(int index)
		{
			if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = controllerMapEnablerRuleSets[index].Clone();
			controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
			controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName(controllerMapEnabler_RuleSet_Editor.name, -1, GetControllerMapEnablerRuleSetNames());
			if (index == controllerMapEnablerRuleSets.Count - 1)
			{
				controllerMapEnablerRuleSets.Add(controllerMapEnabler_RuleSet_Editor);
			}
			else
			{
				controllerMapEnablerRuleSets.Insert(index + 1, controllerMapEnabler_RuleSet_Editor);
			}
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
				for (int i = 0; i < players.Count; i++)
				{
					Player_Editor player_Editor = players[i];
					if (player_Editor == null)
					{
						continue;
					}
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
					if (ruleSets == null)
					{
						continue;
					}
					for (int num2 = ruleSets.Count - 1; num2 >= 0; num2--)
					{
						if (ruleSets[num2] != null && ruleSets[num2].id == id)
						{
							num++;
						}
					}
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
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				if (controllerMapEnablerRuleSets[i].id == id)
				{
					return i;
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
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				array[i] = controllerMapEnablerRuleSets[i].name;
			}
			return array;
		}

		public int[] GetControllerMapEnablerRuleSetIds()
		{
			if (controllerMapEnablerRuleSets == null)
			{
				return null;
			}
			int[] array = new int[controllerMapEnablerRuleSets.Count];
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				array[i] = controllerMapEnablerRuleSets[i].id;
			}
			return array;
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
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				if (controllerMapEnablerRuleSets[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfControllerMapEnablerRuleSet(string name)
		{
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			if (controllerMapEnablerRuleSets == null)
			{
				return -1;
			}
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				if (controllerMapEnablerRuleSets[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public string GetControllerMapEnablerRuleSetNameById(int id)
		{
			if (controllerMapEnablerRuleSets != null)
			{
				for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
				{
					if (controllerMapEnablerRuleSets[i].id == id)
					{
						return controllerMapEnablerRuleSets[i].name;
					}
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
			customControllerLayoutIdCounter++;
			return result;
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

		private Player_Editor dSWUrEXDBiGjFZTwqOGhNFygaZSQ()
		{
			Player_Editor player_Editor = new Player_Editor();
			player_Editor.id = GetNewPlayerId();
			player_Editor.name = StringTools.IterateName("Player", -1, GetPlayerNames());
			player_Editor.descriptiveName = player_Editor.name;
			player_Editor.startPlaying = true;
			if (players.Count == 1)
			{
				player_Editor.assignMouseOnStart = true;
			}
			player_Editor.assignKeyboardOnStart = true;
			player_Editor.controllerMapEnablerSettings = new Player_Editor.ControllerMapEnablerSettings();
			player_Editor.controllerMapLayoutManagerSettings = new Player_Editor.ControllerMapLayoutManagerSettings();
			return player_Editor;
		}

		private InputAction CAlflkcFiEDjmUesbIpPkjYmWOifA()
		{
			InputAction obj = new InputAction
			{
				id = GetNewActionId(),
				name = StringTools.IterateName("Action", -1, GetActionNames())
			};
			obj.descriptiveName = obj.name;
			obj.type = InputActionType.Button;
			obj.userAssignable = true;
			obj.behaviorId = 0;
			return obj;
		}

		private InputActionCategory JrJFkvBeXSYrCBWsJkNaOsaKiSDdA()
		{
			InputActionCategory obj = new InputActionCategory
			{
				id = GetNewActionCategoryId(),
				name = StringTools.IterateName("Category", -1, GetActionCategoryNames())
			};
			obj.descriptiveName = obj.name;
			obj.userAssignable = true;
			return obj;
		}

		private InputBehavior uYGqZaqXmZKMzemgLfzoasUFADzD()
		{
			return new InputBehavior
			{
				id = GetNewInputBehaviorId(),
				name = StringTools.IterateName("Behavior", -1, GetInputBehaviorNames()),
				digitalAxisSimulation = false,
				digitalAxisSnap = true,
				digitalAxisInstantReverse = false,
				digitalAxisGravity = 3f,
				digitalAxisSensitivity = 3f,
				mouseXYAxisMode = MouseXYAxisMode.MouseAxis,
				mouseXYAxisSensitivity = 1f,
				mouseOtherAxisMode = MouseOtherAxisMode.MouseAxis,
				mouseOtherAxisSensitivity = 1f,
				buttonDoublePressSpeed = 0.3f,
				buttonShortPressTime = 0.25f,
				buttonShortPressExpiresIn = 0f,
				buttonLongPressTime = 1f,
				buttonLongPressExpiresIn = 0f,
				buttonDeadZone = 0.5f,
				buttonDownBuffer = 0f
			};
		}

		private InputMapCategory rdAjTdATClPZgtVeclYtdqRcFzaPB()
		{
			InputMapCategory obj = new InputMapCategory
			{
				id = GetNewMapCategoryId(),
				name = StringTools.IterateName("Category", -1, GetMapCategoryNames())
			};
			obj.descriptiveName = obj.name;
			obj.userAssignable = true;
			obj.checkConflictsWithAllCategories = true;
			return obj;
		}

		private InputLayout DcjefxwIzZOmJJzISfZDQRqmWpNx()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewJoystickLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout MdptHUyuIGdDhGktRczTgxJhNrgD()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewKeyboardLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout ukzmLhlHKEeXpHLVwlIheYPcLcxi()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewMouseLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout kswsLUEfNVEZznlXomCocAIYvqEv()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewCustomControllerLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private CustomController_Editor fxbhXWcpwzEEwBrNpMgaNrVITDrR(Guid P_0)
		{
			CustomController_Editor obj = new CustomController_Editor
			{
				id = GetNewCustomControllerId(),
				typeGuid = P_0,
				name = StringTools.IterateName("CustomController", -1, GetCustomControllerNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private ControllerMapLayoutManager_RuleSet_Editor AkHKbrnmrzgYKXwOGpdRmxajsMxB()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor
			{
				id = GetNewControllerMapLayoutManagerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames())
			};
		}

		private ControllerMapEnabler_RuleSet_Editor XszClfuDcDditCaIekKbkwYbzwEJA()
		{
			return new ControllerMapEnabler_RuleSet_Editor
			{
				id = GetNewControllerMapEnablerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames())
			};
		}

		private ControllerMap_Editor bhFCWIbFmgxlwfilYdpKZUzauutu(List<ControllerMap_Editor> P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].categoryId == P_1 && P_0[i].layoutId == P_2)
				{
					return P_0[i];
				}
			}
			return null;
		}

		private ControllerMap_Editor gupXemOsrzmrjQkuhTGTEvIykaUi(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = bhFCWIbFmgxlwfilYdpKZUzauutu(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = DVHohjtVDbFaQnBxtmHnpLTdYbol(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor DVHohjtVDbFaQnBxtmHnpLTdYbol(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				jUZdTViGVWtoISGraFriLtwViaDeA(list, P_1);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].categoryId == P_2)
					{
						return list[i];
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].categoryId == 0)
					{
						return list[j];
					}
				}
			}
			return null;
		}

		private void jUZdTViGVWtoISGraFriLtwViaDeA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			tkZDUeleHCsCkJnUdzutURUEqVQX tkZDUeleHCsCkJnUdzutURUEqVQX2 = new tkZDUeleHCsCkJnUdzutURUEqVQX();
			tkZDUeleHCsCkJnUdzutURUEqVQX2.ogSCBYXHwXnWpvuJPAihYWavDHfp = P_1;
			if (P_0 != null && tkZDUeleHCsCkJnUdzutURUEqVQX2.ogSCBYXHwXnWpvuJPAihYWavDHfp != null)
			{
				P_0.Sort(tkZDUeleHCsCkJnUdzutURUEqVQX2.UVyjhlsRAZLYlbgCJSVQNlCtpBpN);
			}
		}

		internal void faJMRTZidkItkjWNXbCIguRTTWpB()
		{
			if (pLbfMlBwEbxOCcSpvLOTuPwlegxK)
			{
				return;
			}
			vWVCaxumKigQbhTsviQaKApAlEkm = new List<InputAction>(actions.Count);
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i] == null)
				{
					vWVCaxumKigQbhTsviQaKApAlEkm.Add(null);
				}
				vWVCaxumKigQbhTsviQaKApAlEkm.Add(new InputAction(actions[i]));
			}
			CqaNhCrdUVQUcSQVbyoNlYtceigM = new ReadOnlyCollection<Player_Editor>(players);
			VaDuPnYBoMFyibPERDuLkhTlWuIhA = new ReadOnlyCollection<InputAction>(vWVCaxumKigQbhTsviQaKApAlEkm);
			List<InputCategory> list = new List<InputCategory>((actionCategories != null) ? actionCategories.Count : 0);
			for (int j = 0; j < actionCategories.Count; j++)
			{
				list.Add(actionCategories[j]);
			}
			LoOqAGbQBjtFnniPYMnBZCQLGLRk = new ReadOnlyCollection<InputCategory>(list);
			KokCrrxpkaAdDBNiACbXBaixTNTz = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
			wuGtLRtEtfVDbcPSweQijoAgHePsA = new ReadOnlyCollection<InputMapCategory>(mapCategories);
			cvgExnntIhRPLMCdFQNlmESfWgjt = new ReadOnlyCollection<InputLayout>(joystickLayouts);
			GSNhjDviRjWrcNOBUmtTKEGPebOC = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
			NcJhMPdNZOlgsICFZmXcVrgYwDsAA = new ReadOnlyCollection<InputLayout>(mouseLayouts);
			CaAiXgdBGntDcTkAAmlNzWqxBMobb = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
			DOpgNMKCAoJSbhTtwwPEDEZclwycA = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
			xokNyuUAYlauzpPfOWdRUVsPkLer = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
			SgYxwcRWoIkTmIZXGNWefHaKAtwG = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
			KVAPzXYVDlHSDlvCYdtbMxCRcfth = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
			sXyskiETLlUcXvzBBNbRGvcZesbS = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
			DMfbKDFtBXDvwzwORBtYOpFrgXoj = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
			if (mapCategories != null)
			{
				for (int k = 0; k < mapCategories.Count; k++)
				{
					if (mapCategories[k] != null)
					{
						mapCategories[k].NAyVYtzaEfONhahjqQAdVIOhqgzK();
					}
				}
			}
			if (actionCategories != null)
			{
				for (int l = 0; l < actionCategories.Count; l++)
				{
					if (actionCategories[l] != null)
					{
						actionCategories[l].NAyVYtzaEfONhahjqQAdVIOhqgzK();
					}
				}
			}
			if (joystickLayouts != null)
			{
				for (int m = 0; m < joystickLayouts.Count; m++)
				{
					if (joystickLayouts[m] != null)
					{
						joystickLayouts[m].fIUUIApNfUaIAIZwlwUHqmEmCPkaA();
					}
				}
			}
			if (keyboardLayouts != null)
			{
				for (int n = 0; n < keyboardLayouts.Count; n++)
				{
					if (keyboardLayouts[n] != null)
					{
						keyboardLayouts[n].fIUUIApNfUaIAIZwlwUHqmEmCPkaA();
					}
				}
			}
			if (mouseLayouts != null)
			{
				for (int num = 0; num < mouseLayouts.Count; num++)
				{
					if (mouseLayouts[num] != null)
					{
						mouseLayouts[num].fIUUIApNfUaIAIZwlwUHqmEmCPkaA();
					}
				}
			}
			if (customControllerLayouts != null)
			{
				for (int num2 = 0; num2 < customControllerLayouts.Count; num2++)
				{
					if (customControllerLayouts[num2] != null)
					{
						customControllerLayouts[num2].fIUUIApNfUaIAIZwlwUHqmEmCPkaA();
					}
				}
			}
			if (vWVCaxumKigQbhTsviQaKApAlEkm != null)
			{
				for (int num3 = 0; num3 < vWVCaxumKigQbhTsviQaKApAlEkm.Count; num3++)
				{
					if (vWVCaxumKigQbhTsviQaKApAlEkm[num3] != null)
					{
						vWVCaxumKigQbhTsviQaKApAlEkm[num3].XSBrGDocNzGNEumBNLvaXDirZiqU();
					}
				}
			}
			containsActionDelegate = ContainsAction;
			pLbfMlBwEbxOCcSpvLOTuPwlegxK = true;
		}

		internal void UmALgfynAXERyFdAwJxrNJDjSlxmA()
		{
			if (!pLbfMlBwEbxOCcSpvLOTuPwlegxK)
			{
				return;
			}
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					if (mapCategories[i] != null)
					{
						mapCategories[i].rPyGMUcMLMKquPkOtbvPcDKZHMI();
					}
				}
			}
			if (vWVCaxumKigQbhTsviQaKApAlEkm != null)
			{
				for (int j = 0; j < vWVCaxumKigQbhTsviQaKApAlEkm.Count; j++)
				{
					if (vWVCaxumKigQbhTsviQaKApAlEkm[j] != null)
					{
						vWVCaxumKigQbhTsviQaKApAlEkm[j].sHnLjgWYIHHPZjxUAzGWJNoySllc();
					}
				}
			}
			pLbfMlBwEbxOCcSpvLOTuPwlegxK = false;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return WquogmuBBBkNdXGeUqtASnxnLNKq.UKgdORFdedojcqcIOUhLopgNJpxsA(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return WquogmuBBBkNdXGeUqtASnxnLNKq.UKgdORFdedojcqcIOUhLopgNJpxsA(orig, null, false);
		}
	}
}
