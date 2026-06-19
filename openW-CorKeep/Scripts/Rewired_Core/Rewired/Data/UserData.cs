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
		private static class EskyvNObxRJJiyGJHmdeDbNECElB
		{
			[DefaultMember("Item")]
			private class pbaiftYdiKclxwXxYyVWHvgdPtuh
			{
				public enum RyLVxEXwlbAxkVclGMDuydCElJWU
				{
					origId = 0,
					otherId = 1,
					finalId = 2
				}

				public int fLLSdnuJFADpgItIzHaLTCyRkWHdA;

				public int agwikYysLXmatilUKiOTjqIGRQff;

				public int rVMGOWUROKEvOjFcxbRfeorZKMBIb;

				public int VtodQNmJObtFZYRDmhvkKYdfRuOg
				{
					get
					{
						return P_0 switch
						{
							RyLVxEXwlbAxkVclGMDuydCElJWU.origId => fLLSdnuJFADpgItIzHaLTCyRkWHdA, 
							RyLVxEXwlbAxkVclGMDuydCElJWU.otherId => agwikYysLXmatilUKiOTjqIGRQff, 
							RyLVxEXwlbAxkVclGMDuydCElJWU.finalId => rVMGOWUROKEvOjFcxbRfeorZKMBIb, 
							_ => throw new NotImplementedException(), 
						};
					}
					set
					{
						switch (ryLVxEXwlbAxkVclGMDuydCElJWU)
						{
						case RyLVxEXwlbAxkVclGMDuydCElJWU.origId:
							fLLSdnuJFADpgItIzHaLTCyRkWHdA = num;
							break;
						case RyLVxEXwlbAxkVclGMDuydCElJWU.otherId:
							agwikYysLXmatilUKiOTjqIGRQff = num;
							break;
						case RyLVxEXwlbAxkVclGMDuydCElJWU.finalId:
							rVMGOWUROKEvOjFcxbRfeorZKMBIb = num;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public pbaiftYdiKclxwXxYyVWHvgdPtuh(int P_0, int P_1, int P_2)
				{
					fLLSdnuJFADpgItIzHaLTCyRkWHdA = P_0;
					agwikYysLXmatilUKiOTjqIGRQff = P_1;
					rVMGOWUROKEvOjFcxbRfeorZKMBIb = P_2;
				}

				public virtual string OGhpCMLluRZQbYRcYmbyyHowDwWF()
				{
					return string.Concat(string.Concat("" + StringTools.WriteVar("origId", fLLSdnuJFADpgItIzHaLTCyRkWHdA), StringTools.WriteVar("otherId", agwikYysLXmatilUKiOTjqIGRQff)), StringTools.WriteVar("finalId", rVMGOWUROKEvOjFcxbRfeorZKMBIb));
				}
			}

			private class hLnxJwqHptLEGiSLBxmvbWzdYyQF<_0001>
			{
				public _0001 KReenCbMSGfFYIrcJybCQrgyTpEmA;

				public _0001 mgvyKSUvZsJNkZHVxVphLZCuppDI;

				public pbaiftYdiKclxwXxYyVWHvgdPtuh.RyLVxEXwlbAxkVclGMDuydCElJWU YafjDixcJyoPiIDEDKrsbfeKtesQ;

				public IList<_0001> ugeCEhvlErURwUnLJqiIDYRYOHwl;

				public bool eNVHoUeKebisNsWFxFjTIUJnkLJkA;

				public hLnxJwqHptLEGiSLBxmvbWzdYyQF(_0001 P_0, _0001 P_1, pbaiftYdiKclxwXxYyVWHvgdPtuh.RyLVxEXwlbAxkVclGMDuydCElJWU P_2, IList<_0001> P_3, bool P_4)
				{
					KReenCbMSGfFYIrcJybCQrgyTpEmA = P_0;
					mgvyKSUvZsJNkZHVxVphLZCuppDI = P_1;
					YafjDixcJyoPiIDEDKrsbfeKtesQ = P_2;
					ugeCEhvlErURwUnLJqiIDYRYOHwl = P_3;
					eNVHoUeKebisNsWFxFjTIUJnkLJkA = P_4;
				}
			}

			[Serializable]
			private sealed class rZBdHIgGSMIYEnHuMUZACzNAagTSA
			{
				public static readonly rZBdHIgGSMIYEnHuMUZACzNAagTSA _003C_003E9 = new rZBdHIgGSMIYEnHuMUZACzNAagTSA();

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

				internal int qmSUkvlUBsHJMytGoCFuzYWzzioH(InputActionCategory P_0)
				{
					return P_0.id;
				}

				internal string XTFfOEMGqtbTTTPiVkrFgxbJvMuS(InputActionCategory P_0)
				{
					return P_0.name;
				}

				internal int kjSUkhHNHETCcANsDRVLoiZgvpcM(InputActionCategory P_0, IList<InputActionCategory> P_1)
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

				internal int wWieShiTcAOchkKMNIZqQgqNpLkVA(InputBehavior P_0)
				{
					return P_0.id;
				}

				internal string UzpIQoxhNEaiJXbPiZbAxEcmYPxn(InputBehavior P_0)
				{
					return P_0.name;
				}

				internal int RSPbjxZNtadqyhJgIEkWyypcGKYRA(InputBehavior P_0, IList<InputBehavior> P_1)
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

				internal int peIIwVjdEOESiGrlNdpHvXUXvrQ(InputAction P_0)
				{
					return P_0.id;
				}

				internal string CUrarbWnCZheVhkoYkITXpJXESNrA(InputAction P_0)
				{
					return P_0.name;
				}

				internal int VtqdLKBFzqdliiQjwkBFEwCJyMFd(InputAction P_0, IList<InputAction> P_1)
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

				internal int ulKAkRGhDqEgstQaKMcoNgHLekbUA(InputMapCategory P_0)
				{
					return P_0.id;
				}

				internal string ervHxwUEabgrYjpHjBsMzUCiRprp(InputMapCategory P_0)
				{
					return P_0.name;
				}

				internal int zfjykosuqGHAwqYwRxoFdahTGVkw(InputMapCategory P_0, IList<InputMapCategory> P_1)
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

				internal int FhKqGkMHlMGgYHMLwmLHUwOFKTBKA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string BCUDjDAANHMCzIWXEFNIZrERPWdTA(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int CMEfkIKIWZbPtpMjrlPlXnugobJtA(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int lOxAhuZIxYzeGSBxuqvKhEqjzXzH(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string jVAVtrNQddJHApRTJEnMAmlnQHZr(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int LazcjXcqDGLVjqjHfhTBydXbHBykA(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int suhueOpPXqGEqdfWXfYdFahMypZf(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string ooJmFGhDQVnKmYVmCDxmNAxlxQWK(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int NnodTtArJunfsSgaHLUypACwkmzmA(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int KUaDVhbzgGaSJxkwELchJMTIBnFc(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string mYFLRCCiXyGzqHIMtmgoLWpRCnRCA(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int sHurEYaxyGCtEoJFJFjiqTdjTuFL(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int wUDDdocRiOEFUcHXBvBshMtyeJEqc(CustomController_Editor P_0)
				{
					return P_0.id;
				}

				internal string bURUeUZGnvnYQjvNgspJoGlLoadp(CustomController_Editor P_0)
				{
					return P_0.name;
				}

				internal int aCthqBcwguxJcQEhmQgqKYzHNnzc(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
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

				internal int JaOTRWEJpxcNkaeQsLZjqdyNKABG(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string tJAGusCqQZqoLTLAMukelLxugnos(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int PiRNOZUSxGEdZQThXRRoFbRCYLqP(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
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

				internal int UPTaXMAexwldAYHkpWAsghxSqgJTA(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string osfFyPnxiNHUQBlzKUJXphdmlnHm(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int zhYrRtNQlcmKVAERJpcMlgSBzRSq(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
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

				internal int fbfdTegRoCnvzbnTRqFmAEjJGLljA(Player_Editor P_0)
				{
					return P_0.id;
				}

				internal string DzeGvFhaSvifHqLADeDzIxMUhRXf(Player_Editor P_0)
				{
					return P_0.name;
				}

				internal int KxRUxnQYjlNdfIwDVKsRtYlezaJL(Player_Editor P_0, IList<Player_Editor> P_1)
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

				internal int AYxkQtIIWBZUlRDvwMMjsWqhFpJE(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
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

				internal int fJUmusbLPCAEPCrLYbTksnLgLLfW(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
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

				internal int BizFeuaeiQjyqZNxyDvsbQsHInwAb(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string jwieGVbFIOdBYxgKjNmYiFDIMEexb(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int nlzBJZkGYUBqdSLQRsqWsxVuECxfA(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int dBMquGlVRJuxTxcabCOGHxupqMwIA(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string IloOepQQtfZyNriJOSudlTKxufbE(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int cVuuJRroSshqaDneFEMIgPvDbGlYA(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int biODtnlEgAyjsifkXYOdlrUiVgeX(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string ggylrcNwDfHVrukkdpIqcsbCqqVT(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int PkNIkUWMKOVvBoQsZYosoWRzSexs(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int MSKIPUtZDtCPpHndhqDKAPivOToe(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string mjiDWtSirXPiZbUmCPrSRjfFQOOD(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int JeoQfgadvDAbbaCkaLeoWCnAeimeb(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class yDXgPSFzJKEjAVzcCWeQWwNOfpAAA
			{
				public UserData WTFJLvaaRHgbqhJkZHcYxBZjdqlzA;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> mqCVGMbcSCojuFmqzFPwyKjiCOAx;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> GjMyzhlCFsGRaXWBlArqAsrQzgEG;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> FxgoWvWQTLGarRwFRjrlKYRLAktW;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> kHohpHRzYDIRXRrSFaHgCEXfbDFjA;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> gLQYTsjAvfIuqGKgsRWYhTtJpmSi;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> UncjVugpjBgMdrjrQGVjTSgOeVUf;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> tdauQhwBXdZCoizKKphLymwdEtsbA;

				public Func<ControllerType, List<pbaiftYdiKclxwXxYyVWHvgdPtuh>> PZeKdiPktDBgwfSetHSrWtfddbiN;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> UYCxRzZdDLLGFBARcsLyCWFWDgOg;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> akBryfUMqSHSqyPclTYsVgRKltsh;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> GgGoeKMevukuQSPlmiwDfTTgqOXgb;

				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> HVOspKBCEzGwfZERalougkmkdkIcA;

				internal InputActionCategory tZobfeeGfGPObQHGSrYORWSwHJYKA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputActionCategory> P_0)
				{
					InputActionCategory inputActionCategory = JsonTools.Clone(P_0.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					InputActionCategory inputActionCategory2;
					if (P_0.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						inputActionCategory2 = P_0.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddActionCategory();
						inputActionCategory2 = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					inputActionCategory.id = inputActionCategory2.id;
					int index = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(inputActionCategory2);
					P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = inputActionCategory;
					return inputActionCategory;
				}

				internal InputBehavior nefvCrxqYbXsRmqisIKPPwGqFezs(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					InputBehavior inputBehavior2;
					if (P_0.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						inputBehavior2 = P_0.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddInputBehavior();
						inputBehavior2 = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(inputBehavior2);
					P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = inputBehavior;
					return inputBehavior;
				}

				internal InputAction CXUdnggNTLGcCtzMzRowfCqFqLSb(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputAction> P_0)
				{
					MMSHilOAwbKKfyLBORTFGFryGPtk mMSHilOAwbKKfyLBORTFGFryGPtk = new MMSHilOAwbKKfyLBORTFGFryGPtk();
					mMSHilOAwbKKfyLBORTFGFryGPtk.TNdEOmxmNaXvpXAjDBShDwSjpTzkA = P_0;
					InputAction inputAction = JsonTools.Clone(mMSHilOAwbKKfyLBORTFGFryGPtk.TNdEOmxmNaXvpXAjDBShDwSjpTzkA.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					int num = mqCVGMbcSCojuFmqzFPwyKjiCOAx.Find(mMSHilOAwbKKfyLBORTFGFryGPtk.ycfATlkYgpgBggJJwWTaIkAFuygr)?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? 0;
					InputAction inputAction2;
					if (mMSHilOAwbKKfyLBORTFGFryGPtk.TNdEOmxmNaXvpXAjDBShDwSjpTzkA.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						inputAction2 = mMSHilOAwbKKfyLBORTFGFryGPtk.TNdEOmxmNaXvpXAjDBShDwSjpTzkA.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddAction(num);
						inputAction2 = mMSHilOAwbKKfyLBORTFGFryGPtk.TNdEOmxmNaXvpXAjDBShDwSjpTzkA.ugeCEhvlErURwUnLJqiIDYRYOHwl[mMSHilOAwbKKfyLBORTFGFryGPtk.TNdEOmxmNaXvpXAjDBShDwSjpTzkA.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					int num2 = GjMyzhlCFsGRaXWBlArqAsrQzgEG.Find(mMSHilOAwbKKfyLBORTFGFryGPtk.NPLeyDYrgwXHxbTyLKdLqaXEfDXJ)?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = num2;
					int index = mMSHilOAwbKKfyLBORTFGFryGPtk.TNdEOmxmNaXvpXAjDBShDwSjpTzkA.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(inputAction2);
					mMSHilOAwbKKfyLBORTFGFryGPtk.TNdEOmxmNaXvpXAjDBShDwSjpTzkA.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = inputAction;
					return inputAction;
				}

				internal InputLayout bZIHujsQIhEEXeCxWaRkBKDfpOUxA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					InputLayout inputLayout2;
					if (P_0.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						inputLayout2 = P_0.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddKeyboardLayout();
						inputLayout2 = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(inputLayout2);
					P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout FSnBYMKdKcXZZBEvtGTUNuCdSGDL(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					InputLayout inputLayout2;
					if (P_0.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						inputLayout2 = P_0.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddMouseLayout();
						inputLayout2 = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(inputLayout2);
					P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout VqBFnnVAYSYqOeaerRqpmAqubkce(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					InputLayout inputLayout2;
					if (P_0.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						inputLayout2 = P_0.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddJoystickLayout();
						inputLayout2 = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(inputLayout2);
					P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout nvCTgzvJQtvROLpHVcmuGscodCWAb(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					InputLayout inputLayout2;
					if (P_0.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						inputLayout2 = P_0.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddCustomControllerLayout();
						inputLayout2 = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(inputLayout2);
					P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = inputLayout;
					return inputLayout;
				}

				internal List<pbaiftYdiKclxwXxYyVWHvgdPtuh> bzNxtgBOMmIrcBqJftpJtUUvGDxG(ControllerType P_0)
				{
					return P_0 switch
					{
						ControllerType.Keyboard => FxgoWvWQTLGarRwFRjrlKYRLAktW, 
						ControllerType.Mouse => kHohpHRzYDIRXRrSFaHgCEXfbDFjA, 
						ControllerType.Joystick => gLQYTsjAvfIuqGKgsRWYhTtJpmSi, 
						ControllerType.Custom => UncjVugpjBgMdrjrQGVjTSgOeVUf, 
						_ => throw new NotImplementedException(), 
					};
				}

				internal CustomController_Editor nvoCjSgrDsgRcUecTBveLnXLAnlKA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					CustomController_Editor customController_Editor2;
					if (P_0.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						customController_Editor2 = P_0.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddCustomController(Guid.Empty);
						customController_Editor2 = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(customController_Editor2);
					P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = customController_Editor;
					return customController_Editor;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor zTOAjdgkXlUAbNcDLCqfaRUgWsBRB(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					dZUvAutCcTNMAyYNQilmeqoHHSDV dZUvAutCcTNMAyYNQilmeqoHHSDV2 = new dZUvAutCcTNMAyYNQilmeqoHHSDV();
					dZUvAutCcTNMAyYNQilmeqoHHSDV2.jpAaxDAbNphxwjKrHLbRDuWiKfDD = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(dZUvAutCcTNMAyYNQilmeqoHHSDV2.jpAaxDAbNphxwjKrHLbRDuWiKfDD.KReenCbMSGfFYIrcJybCQrgyTpEmA);
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
							YWhdKnvmWhcwfAbHPXnIWNJCFTaM yWhdKnvmWhcwfAbHPXnIWNJCFTaM = new YWhdKnvmWhcwfAbHPXnIWNJCFTaM();
							yWhdKnvmWhcwfAbHPXnIWNJCFTaM.KKthlPlbHppvSVFNareWeIGwLeuM = dZUvAutCcTNMAyYNQilmeqoHHSDV2;
							yWhdKnvmWhcwfAbHPXnIWNJCFTaM.sxufaEASncEUKOWLyKykJUkTnkBAb = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = tdauQhwBXdZCoizKKphLymwdEtsbA.Find(yWhdKnvmWhcwfAbHPXnIWNJCFTaM.sLAZDtbSCCinFxKgpOaiDDVdckRG);
							if (pbaiftYdiKclxwXxYyVWHvgdPtuh2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + yWhdKnvmWhcwfAbHPXnIWNJCFTaM.sxufaEASncEUKOWLyKykJUkTnkBAb);
							}
							else
							{
								list.Add(pbaiftYdiKclxwXxYyVWHvgdPtuh2.rVMGOWUROKEvOjFcxbRfeorZKMBIb);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						cRbkbXSUIUgEbmPDOZVtSxGjlWtg cRbkbXSUIUgEbmPDOZVtSxGjlWtg2 = new cRbkbXSUIUgEbmPDOZVtSxGjlWtg();
						cRbkbXSUIUgEbmPDOZVtSxGjlWtg2.xmJHkIPLSLcsxSGRsxhenTpPiVjU = dZUvAutCcTNMAyYNQilmeqoHHSDV2;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<pbaiftYdiKclxwXxYyVWHvgdPtuh> list2 = PZeKdiPktDBgwfSetHSrWtfddbiN(controllerType);
							cRbkbXSUIUgEbmPDOZVtSxGjlWtg2.swCnxjFmcEMhUfgIMsOCHvoUGZwp = controllerMapLayoutManager_Rule_Editor2.layoutId;
							pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = list2.Find(cRbkbXSUIUgEbmPDOZVtSxGjlWtg2.BanCzxXlipDKIGnuYYltDxNiwrlA);
							if (pbaiftYdiKclxwXxYyVWHvgdPtuh3 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + cRbkbXSUIUgEbmPDOZVtSxGjlWtg2.swCnxjFmcEMhUfgIMsOCHvoUGZwp);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = pbaiftYdiKclxwXxYyVWHvgdPtuh3.rVMGOWUROKEvOjFcxbRfeorZKMBIb;
							}
						}
					}
					int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							hemqEXIHmkNVhfljdaHFEckmeuEj hemqEXIHmkNVhfljdaHFEckmeuEj2 = new hemqEXIHmkNVhfljdaHFEckmeuEj();
							hemqEXIHmkNVhfljdaHFEckmeuEj2.jTTrvOGnVjLAzFxyirZBKhzCoxDc = dZUvAutCcTNMAyYNQilmeqoHHSDV2;
							List<pbaiftYdiKclxwXxYyVWHvgdPtuh> uYCxRzZdDLLGFBARcsLyCWFWDgOg = UYCxRzZdDLLGFBARcsLyCWFWDgOg;
							hemqEXIHmkNVhfljdaHFEckmeuEj2.RgcDuMgdVqbtVaDeyypmfUPmpxkN = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh4 = uYCxRzZdDLLGFBARcsLyCWFWDgOg.Find(hemqEXIHmkNVhfljdaHFEckmeuEj2.moLEkithaEMjDsPZqyMnJQBCWDUE);
							if (pbaiftYdiKclxwXxYyVWHvgdPtuh4 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + hemqEXIHmkNVhfljdaHFEckmeuEj2.RgcDuMgdVqbtVaDeyypmfUPmpxkN);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = pbaiftYdiKclxwXxYyVWHvgdPtuh4.rVMGOWUROKEvOjFcxbRfeorZKMBIb;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (dZUvAutCcTNMAyYNQilmeqoHHSDV2.jpAaxDAbNphxwjKrHLbRDuWiKfDD.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = dZUvAutCcTNMAyYNQilmeqoHHSDV2.jpAaxDAbNphxwjKrHLbRDuWiKfDD.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = dZUvAutCcTNMAyYNQilmeqoHHSDV2.jpAaxDAbNphxwjKrHLbRDuWiKfDD.ugeCEhvlErURwUnLJqiIDYRYOHwl[dZUvAutCcTNMAyYNQilmeqoHHSDV2.jpAaxDAbNphxwjKrHLbRDuWiKfDD.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = dZUvAutCcTNMAyYNQilmeqoHHSDV2.jpAaxDAbNphxwjKrHLbRDuWiKfDD.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					dZUvAutCcTNMAyYNQilmeqoHHSDV2.jpAaxDAbNphxwjKrHLbRDuWiKfDD.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				internal ControllerMapEnabler_RuleSet_Editor ZYVIyDyHAvLKdShYSENWCyrtiTuIA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					olaMmqrRwGfelIhzpdYLwlHmuHgj olaMmqrRwGfelIhzpdYLwlHmuHgj2 = new olaMmqrRwGfelIhzpdYLwlHmuHgj();
					olaMmqrRwGfelIhzpdYLwlHmuHgj2.XxIgYghITtWIbBaFzLbwoODMknxZ = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(olaMmqrRwGfelIhzpdYLwlHmuHgj2.XxIgYghITtWIbBaFzLbwoODMknxZ.KReenCbMSGfFYIrcJybCQrgyTpEmA);
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
							QudBPWqGmojYYVwpRqgHiQOvjsxG qudBPWqGmojYYVwpRqgHiQOvjsxG = new QudBPWqGmojYYVwpRqgHiQOvjsxG();
							qudBPWqGmojYYVwpRqgHiQOvjsxG.fWXPHTNuCYRVaKoJmDqNiUcctLnUA = olaMmqrRwGfelIhzpdYLwlHmuHgj2;
							qudBPWqGmojYYVwpRqgHiQOvjsxG.OfwLaGzsHEzXlEVcxknDRYvLLDOg = controllerMapEnabler_Rule_Editor.categoryIds[j];
							pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = tdauQhwBXdZCoizKKphLymwdEtsbA.Find(qudBPWqGmojYYVwpRqgHiQOvjsxG.qRrWLDXpmvoJfCnWObnbaflCBAhbb);
							if (pbaiftYdiKclxwXxYyVWHvgdPtuh2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + qudBPWqGmojYYVwpRqgHiQOvjsxG.OfwLaGzsHEzXlEVcxknDRYvLLDOg);
							}
							else
							{
								list.Add(pbaiftYdiKclxwXxYyVWHvgdPtuh2.rVMGOWUROKEvOjFcxbRfeorZKMBIb);
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
						List<pbaiftYdiKclxwXxYyVWHvgdPtuh> list2 = PZeKdiPktDBgwfSetHSrWtfddbiN(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							ejOXuphJzcRcIWHopFkDYhzTtyzO ejOXuphJzcRcIWHopFkDYhzTtyzO2 = new ejOXuphJzcRcIWHopFkDYhzTtyzO();
							ejOXuphJzcRcIWHopFkDYhzTtyzO2.qwPwCpnKsrWyEzmPLAtNZTOUhOiO = olaMmqrRwGfelIhzpdYLwlHmuHgj2;
							ejOXuphJzcRcIWHopFkDYhzTtyzO2.bCosgrNKxmbPqwCDBKLmHlyYQXHD = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = list2.Find(ejOXuphJzcRcIWHopFkDYhzTtyzO2.QGHktQIehWunTfhhaGtoBHTzEVfaA);
							if (pbaiftYdiKclxwXxYyVWHvgdPtuh3 == null)
							{
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + ejOXuphJzcRcIWHopFkDYhzTtyzO2.bCosgrNKxmbPqwCDBKLmHlyYQXHD);
							}
							else
							{
								list3.Add(pbaiftYdiKclxwXxYyVWHvgdPtuh3.rVMGOWUROKEvOjFcxbRfeorZKMBIb);
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
							btprYOlFiSHZEuDhtZaPlDJARQLx btprYOlFiSHZEuDhtZaPlDJARQLx2 = new btprYOlFiSHZEuDhtZaPlDJARQLx();
							btprYOlFiSHZEuDhtZaPlDJARQLx2.UDgHqtHvgSkbVfKHmhXIXiIxpECWA = olaMmqrRwGfelIhzpdYLwlHmuHgj2;
							List<pbaiftYdiKclxwXxYyVWHvgdPtuh> uYCxRzZdDLLGFBARcsLyCWFWDgOg = UYCxRzZdDLLGFBARcsLyCWFWDgOg;
							btprYOlFiSHZEuDhtZaPlDJARQLx2.ZZszzDDafXglWBEkwPbpEyhyUwJbb = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh4 = uYCxRzZdDLLGFBARcsLyCWFWDgOg.Find(btprYOlFiSHZEuDhtZaPlDJARQLx2.fATvomtgyBNmfHsIeRhdKppBkVSx);
							if (pbaiftYdiKclxwXxYyVWHvgdPtuh4 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + btprYOlFiSHZEuDhtZaPlDJARQLx2.ZZszzDDafXglWBEkwPbpEyhyUwJbb);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = pbaiftYdiKclxwXxYyVWHvgdPtuh4.rVMGOWUROKEvOjFcxbRfeorZKMBIb;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (olaMmqrRwGfelIhzpdYLwlHmuHgj2.XxIgYghITtWIbBaFzLbwoODMknxZ.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						controllerMapEnabler_RuleSet_Editor2 = olaMmqrRwGfelIhzpdYLwlHmuHgj2.XxIgYghITtWIbBaFzLbwoODMknxZ.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = olaMmqrRwGfelIhzpdYLwlHmuHgj2.XxIgYghITtWIbBaFzLbwoODMknxZ.ugeCEhvlErURwUnLJqiIDYRYOHwl[olaMmqrRwGfelIhzpdYLwlHmuHgj2.XxIgYghITtWIbBaFzLbwoODMknxZ.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = olaMmqrRwGfelIhzpdYLwlHmuHgj2.XxIgYghITtWIbBaFzLbwoODMknxZ.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					olaMmqrRwGfelIhzpdYLwlHmuHgj2.XxIgYghITtWIbBaFzLbwoODMknxZ.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				internal Player_Editor oUSJVfJEjdPGirFvTXDDWsINvwAj(hLnxJwqHptLEGiSLBxmvbWzdYyQF<Player_Editor> P_0)
				{
					RYSDKHcwYWBjAXJsrvXSRkNXmbPS rYSDKHcwYWBjAXJsrvXSRkNXmbPS = new RYSDKHcwYWBjAXJsrvXSRkNXmbPS();
					rYSDKHcwYWBjAXJsrvXSRkNXmbPS.NfOitvNkdueBOUBjDeOOFgZQKoAdb = this;
					rYSDKHcwYWBjAXJsrvXSRkNXmbPS.jnneNLxjWOsxdvciQcgvHqnSApBU = P_0;
					Player_Editor player_Editor = JsonTools.Clone(rYSDKHcwYWBjAXJsrvXSRkNXmbPS.jnneNLxjWOsxdvciQcgvHqnSApBU.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					Action<List<Player_Editor.Mapping>, List<pbaiftYdiKclxwXxYyVWHvgdPtuh>> action = rYSDKHcwYWBjAXJsrvXSRkNXmbPS.tUEDBfFoszOvFxQMjihwBdphTVEnA;
					action(player_Editor.defaultKeyboardMaps, FxgoWvWQTLGarRwFRjrlKYRLAktW);
					action(player_Editor.defaultMouseMaps, kHohpHRzYDIRXRrSFaHgCEXfbDFjA);
					action(player_Editor.defaultJoystickMaps, gLQYTsjAvfIuqGKgsRWYhTtJpmSi);
					action(player_Editor.defaultCustomControllerMaps, UncjVugpjBgMdrjrQGVjTSgOeVUf);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						akhEUqOSvWAfRwBipocKHBaFCggS akhEUqOSvWAfRwBipocKHBaFCggS2 = new akhEUqOSvWAfRwBipocKHBaFCggS();
						akhEUqOSvWAfRwBipocKHBaFCggS2.HnWBhIfULBrpmToBwQCQlFFJgKJrA = rYSDKHcwYWBjAXJsrvXSRkNXmbPS;
						akhEUqOSvWAfRwBipocKHBaFCggS2.WcalOpKYetIyhGZwPDOErsclINxw = player_Editor.startingCustomControllers[i];
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = UYCxRzZdDLLGFBARcsLyCWFWDgOg.Find(akhEUqOSvWAfRwBipocKHBaFCggS2.TgjNQqBtyXfepXgYXGsfNGXfKlpx);
						akhEUqOSvWAfRwBipocKHBaFCggS2.WcalOpKYetIyhGZwPDOErsclINxw.sourceId = pbaiftYdiKclxwXxYyVWHvgdPtuh2?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						kYwUGubUIIuANLajbaDRRdeLnBSM kYwUGubUIIuANLajbaDRRdeLnBSM2 = new kYwUGubUIIuANLajbaDRRdeLnBSM();
						kYwUGubUIIuANLajbaDRRdeLnBSM2.vmcsWDozKMdJmpeTBPToVPtnBibgA = rYSDKHcwYWBjAXJsrvXSRkNXmbPS;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							kYwUGubUIIuANLajbaDRRdeLnBSM2.KVukewitKylGtFuyvuCsriuWwNqx = ruleSetMapping.id;
							pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = akBryfUMqSHSqyPclTYsVgRKltsh.Find(kYwUGubUIIuANLajbaDRRdeLnBSM2.cdaBvGbHYfqqydeJiQJSlAodlOkXc);
							if (pbaiftYdiKclxwXxYyVWHvgdPtuh3 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + kYwUGubUIIuANLajbaDRRdeLnBSM2.KVukewitKylGtFuyvuCsriuWwNqx);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = pbaiftYdiKclxwXxYyVWHvgdPtuh3.rVMGOWUROKEvOjFcxbRfeorZKMBIb;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						naDVfWUhyZSdhnaGicYPjclibsYc naDVfWUhyZSdhnaGicYPjclibsYc2 = new naDVfWUhyZSdhnaGicYPjclibsYc();
						naDVfWUhyZSdhnaGicYPjclibsYc2.OdvkkGGTWvXcyPafrkwlMqymLWQe = rYSDKHcwYWBjAXJsrvXSRkNXmbPS;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							naDVfWUhyZSdhnaGicYPjclibsYc2.XtIKEnYkRYFwYyojiCyLSqQiVllt = ruleSetMapping2.id;
							pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh4 = GgGoeKMevukuQSPlmiwDfTTgqOXgb.Find(naDVfWUhyZSdhnaGicYPjclibsYc2.mZVctOECKIUgskXEYUNZKrnuQjOO);
							if (pbaiftYdiKclxwXxYyVWHvgdPtuh4 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + naDVfWUhyZSdhnaGicYPjclibsYc2.XtIKEnYkRYFwYyojiCyLSqQiVllt);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = pbaiftYdiKclxwXxYyVWHvgdPtuh4.rVMGOWUROKEvOjFcxbRfeorZKMBIb;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (rYSDKHcwYWBjAXJsrvXSRkNXmbPS.jnneNLxjWOsxdvciQcgvHqnSApBU.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						player_Editor2 = rYSDKHcwYWBjAXJsrvXSRkNXmbPS.jnneNLxjWOsxdvciQcgvHqnSApBU.mgvyKSUvZsJNkZHVxVphLZCuppDI;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.AYxkQtIIWBZUlRDvwMMjsWqhFpJE;
						lWbWrITCNsCbuIKUDXRgSKfZxdCR(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						lWbWrITCNsCbuIKUDXRgSKfZxdCR(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						lWbWrITCNsCbuIKUDXRgSKfZxdCR(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						lWbWrITCNsCbuIKUDXRgSKfZxdCR(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						lWbWrITCNsCbuIKUDXRgSKfZxdCR(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.fJUmusbLPCAEPCrLYbTksnLgLLfW);
						player_Editor = player_Editor3;
					}
					else
					{
						WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddPlayer();
						player_Editor2 = rYSDKHcwYWBjAXJsrvXSRkNXmbPS.jnneNLxjWOsxdvciQcgvHqnSApBU.ugeCEhvlErURwUnLJqiIDYRYOHwl[rYSDKHcwYWBjAXJsrvXSRkNXmbPS.jnneNLxjWOsxdvciQcgvHqnSApBU.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = rYSDKHcwYWBjAXJsrvXSRkNXmbPS.jnneNLxjWOsxdvciQcgvHqnSApBU.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(player_Editor2);
					rYSDKHcwYWBjAXJsrvXSRkNXmbPS.jnneNLxjWOsxdvciQcgvHqnSApBU.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = player_Editor;
					return player_Editor;
				}
			}

			private sealed class MMSHilOAwbKKfyLBORTFGFryGPtk
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputAction> TNdEOmxmNaXvpXAjDBShDwSjpTzkA;

				internal bool ycfATlkYgpgBggJJwWTaIkAFuygr(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(TNdEOmxmNaXvpXAjDBShDwSjpTzkA.YafjDixcJyoPiIDEDKrsbfeKtesQ) == TNdEOmxmNaXvpXAjDBShDwSjpTzkA.KReenCbMSGfFYIrcJybCQrgyTpEmA.categoryId;
				}

				internal bool NPLeyDYrgwXHxbTyLKdLqaXEfDXJ(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(TNdEOmxmNaXvpXAjDBShDwSjpTzkA.YafjDixcJyoPiIDEDKrsbfeKtesQ) == TNdEOmxmNaXvpXAjDBShDwSjpTzkA.KReenCbMSGfFYIrcJybCQrgyTpEmA.behaviorId;
				}
			}

			private sealed class ejOXuphJzcRcIWHopFkDYhzTtyzO
			{
				public int bCosgrNKxmbPqwCDBKLmHlyYQXHD;

				public olaMmqrRwGfelIhzpdYLwlHmuHgj qwPwCpnKsrWyEzmPLAtNZTOUhOiO;

				internal bool QGHktQIehWunTfhhaGtoBHTzEVfaA(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(qwPwCpnKsrWyEzmPLAtNZTOUhOiO.XxIgYghITtWIbBaFzLbwoODMknxZ.YafjDixcJyoPiIDEDKrsbfeKtesQ) == bCosgrNKxmbPqwCDBKLmHlyYQXHD;
				}
			}

			private sealed class btprYOlFiSHZEuDhtZaPlDJARQLx
			{
				public int ZZszzDDafXglWBEkwPbpEyhyUwJbb;

				public olaMmqrRwGfelIhzpdYLwlHmuHgj UDgHqtHvgSkbVfKHmhXIXiIxpECWA;

				internal bool fATvomtgyBNmfHsIeRhdKppBkVSx(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(UDgHqtHvgSkbVfKHmhXIXiIxpECWA.XxIgYghITtWIbBaFzLbwoODMknxZ.YafjDixcJyoPiIDEDKrsbfeKtesQ) == ZZszzDDafXglWBEkwPbpEyhyUwJbb;
				}
			}

			private sealed class RYSDKHcwYWBjAXJsrvXSRkNXmbPS
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<Player_Editor> jnneNLxjWOsxdvciQcgvHqnSApBU;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA NfOitvNkdueBOUBjDeOOFgZQKoAdb;

				internal void tUEDBfFoszOvFxQMjihwBdphTVEnA(List<Player_Editor.Mapping> P_0, List<pbaiftYdiKclxwXxYyVWHvgdPtuh> P_1)
				{
					for (int i = 0; i < P_0.Count; i++)
					{
						IQWrciTRbFHNuZqtJLHejFtKkYXl iQWrciTRbFHNuZqtJLHejFtKkYXl = new IQWrciTRbFHNuZqtJLHejFtKkYXl();
						iQWrciTRbFHNuZqtJLHejFtKkYXl.WcKxyWzlzSKUBgZnEetEHLBVEoAf = this;
						iQWrciTRbFHNuZqtJLHejFtKkYXl.OPhIHMDiUgUxzWcZRPchFcPxRElA = P_0[i];
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = NfOitvNkdueBOUBjDeOOFgZQKoAdb.tdauQhwBXdZCoizKKphLymwdEtsbA.Find(iQWrciTRbFHNuZqtJLHejFtKkYXl.LepQSQSauvdghglwUzOEkdpmaWNQ);
						iQWrciTRbFHNuZqtJLHejFtKkYXl.OPhIHMDiUgUxzWcZRPchFcPxRElA.categoryId = pbaiftYdiKclxwXxYyVWHvgdPtuh2?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
						pbaiftYdiKclxwXxYyVWHvgdPtuh2 = P_1.Find(iQWrciTRbFHNuZqtJLHejFtKkYXl.TTyAGEGxSdxcvPFivkWlMksjKALWA);
						iQWrciTRbFHNuZqtJLHejFtKkYXl.OPhIHMDiUgUxzWcZRPchFcPxRElA.layoutId = pbaiftYdiKclxwXxYyVWHvgdPtuh2?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					}
				}
			}

			private sealed class IQWrciTRbFHNuZqtJLHejFtKkYXl
			{
				public Player_Editor.Mapping OPhIHMDiUgUxzWcZRPchFcPxRElA;

				public RYSDKHcwYWBjAXJsrvXSRkNXmbPS WcKxyWzlzSKUBgZnEetEHLBVEoAf;

				internal bool LepQSQSauvdghglwUzOEkdpmaWNQ(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(WcKxyWzlzSKUBgZnEetEHLBVEoAf.jnneNLxjWOsxdvciQcgvHqnSApBU.YafjDixcJyoPiIDEDKrsbfeKtesQ) == OPhIHMDiUgUxzWcZRPchFcPxRElA.categoryId;
				}

				internal bool TTyAGEGxSdxcvPFivkWlMksjKALWA(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(WcKxyWzlzSKUBgZnEetEHLBVEoAf.jnneNLxjWOsxdvciQcgvHqnSApBU.YafjDixcJyoPiIDEDKrsbfeKtesQ) == OPhIHMDiUgUxzWcZRPchFcPxRElA.layoutId;
				}
			}

			private sealed class akhEUqOSvWAfRwBipocKHBaFCggS
			{
				public Player_Editor.CreateControllerInfo WcalOpKYetIyhGZwPDOErsclINxw;

				public RYSDKHcwYWBjAXJsrvXSRkNXmbPS HnWBhIfULBrpmToBwQCQlFFJgKJrA;

				internal bool TgjNQqBtyXfepXgYXGsfNGXfKlpx(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(HnWBhIfULBrpmToBwQCQlFFJgKJrA.jnneNLxjWOsxdvciQcgvHqnSApBU.YafjDixcJyoPiIDEDKrsbfeKtesQ) == WcalOpKYetIyhGZwPDOErsclINxw.sourceId;
				}
			}

			private sealed class kYwUGubUIIuANLajbaDRRdeLnBSM
			{
				public int KVukewitKylGtFuyvuCsriuWwNqx;

				public RYSDKHcwYWBjAXJsrvXSRkNXmbPS vmcsWDozKMdJmpeTBPToVPtnBibgA;

				internal bool cdaBvGbHYfqqydeJiQJSlAodlOkXc(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(vmcsWDozKMdJmpeTBPToVPtnBibgA.jnneNLxjWOsxdvciQcgvHqnSApBU.YafjDixcJyoPiIDEDKrsbfeKtesQ) == KVukewitKylGtFuyvuCsriuWwNqx;
				}
			}

			private sealed class naDVfWUhyZSdhnaGicYPjclibsYc
			{
				public int XtIKEnYkRYFwYyojiCyLSqQiVllt;

				public RYSDKHcwYWBjAXJsrvXSRkNXmbPS OdvkkGGTWvXcyPafrkwlMqymLWQe;

				internal bool mZVctOECKIUgskXEYUNZKrnuQjOO(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(OdvkkGGTWvXcyPafrkwlMqymLWQe.jnneNLxjWOsxdvciQcgvHqnSApBU.YafjDixcJyoPiIDEDKrsbfeKtesQ) == XtIKEnYkRYFwYyojiCyLSqQiVllt;
				}
			}

			private sealed class WNPdiiupcRaoTTwSPyAtwHMkDnlG
			{
				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> DrzeeShFcKNbVQHvKFNGXEyYLefXA;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA CxLnsnkdkwYHdMHVUOlrEaOcqtKD;

				internal int fdnnlTdwvibfpihIYoClEnqgQyik(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					boIOqgDgchulJwGkMuRtZwKInImJ boIOqgDgchulJwGkMuRtZwKInImJ2 = new boIOqgDgchulJwGkMuRtZwKInImJ();
					boIOqgDgchulJwGkMuRtZwKInImJ2.zxgAniClXTLZgZBaajFLtlvbmkBOA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = CxLnsnkdkwYHdMHVUOlrEaOcqtKD.tdauQhwBXdZCoizKKphLymwdEtsbA.Find(boIOqgDgchulJwGkMuRtZwKInImJ2.WpmTQdHDegjdJhRyJLVDAuEkSHYB);
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = DrzeeShFcKNbVQHvKFNGXEyYLefXA.Find(boIOqgDgchulJwGkMuRtZwKInImJ2.AQddFvZiYyDgImdNWnBGUprOSfWE);
						if (pbaiftYdiKclxwXxYyVWHvgdPtuh2 != null && pbaiftYdiKclxwXxYyVWHvgdPtuh2.rVMGOWUROKEvOjFcxbRfeorZKMBIb == P_1[i].categoryId && pbaiftYdiKclxwXxYyVWHvgdPtuh3 != null && pbaiftYdiKclxwXxYyVWHvgdPtuh3.rVMGOWUROKEvOjFcxbRfeorZKMBIb == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor nPNtAaCLFUBYZOJrDCcaFsJfPOTW(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> P_0)
				{
					QsYbGJggairMFSjRQBGCegTrMePq qsYbGJggairMFSjRQBGCegTrMePq = new QsYbGJggairMFSjRQBGCegTrMePq();
					qsYbGJggairMFSjRQBGCegTrMePq.tAMGNvJHqVaAaYbZoXOegDwAOXXwA = P_0;
					qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB = JsonTools.Clone(qsYbGJggairMFSjRQBGCegTrMePq.tAMGNvJHqVaAaYbZoXOegDwAOXXwA.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = CxLnsnkdkwYHdMHVUOlrEaOcqtKD.tdauQhwBXdZCoizKKphLymwdEtsbA.Find(qsYbGJggairMFSjRQBGCegTrMePq.lvDCalOCgtGibcYcGRAyfIKDioGd);
					pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = DrzeeShFcKNbVQHvKFNGXEyYLefXA.Find(qsYbGJggairMFSjRQBGCegTrMePq.exqEzxgsaxOkxXzWrCffeFVXYqkJA);
					qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB.categoryId = pbaiftYdiKclxwXxYyVWHvgdPtuh2?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB.layoutId = pbaiftYdiKclxwXxYyVWHvgdPtuh3?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					for (int i = 0; i < qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB.actionElementMaps.Count; i++)
					{
						zhBJlCxYUHpyGHsGOVbYPlBRJlOS zhBJlCxYUHpyGHsGOVbYPlBRJlOS2 = new zhBJlCxYUHpyGHsGOVbYPlBRJlOS();
						zhBJlCxYUHpyGHsGOVbYPlBRJlOS2.EoiBYreVRZqjLDJpoZzUyOrTaoQI = qsYbGJggairMFSjRQBGCegTrMePq;
						zhBJlCxYUHpyGHsGOVbYPlBRJlOS2.kBWUZmiirJOBlKYiZplHcBENiyG = zhBJlCxYUHpyGHsGOVbYPlBRJlOS2.EoiBYreVRZqjLDJpoZzUyOrTaoQI.opkEZndLlCCXpfvDviWNohvVXBRB.actionElementMaps[i];
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh4 = CxLnsnkdkwYHdMHVUOlrEaOcqtKD.HVOspKBCEzGwfZERalougkmkdkIcA.Find(zhBJlCxYUHpyGHsGOVbYPlBRJlOS2.cKjBmekTzbTpMOcJOyzYeHiqGNbAb);
						zhBJlCxYUHpyGHsGOVbYPlBRJlOS2.kBWUZmiirJOBlKYiZplHcBENiyG._actionId = pbaiftYdiKclxwXxYyVWHvgdPtuh4?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
						zhBJlCxYUHpyGHsGOVbYPlBRJlOS2.kBWUZmiirJOBlKYiZplHcBENiyG._actionCategoryId = ((CxLnsnkdkwYHdMHVUOlrEaOcqtKD.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.GetActionById(zhBJlCxYUHpyGHsGOVbYPlBRJlOS2.kBWUZmiirJOBlKYiZplHcBENiyG._actionId) != null) ? CxLnsnkdkwYHdMHVUOlrEaOcqtKD.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.GetActionById(zhBJlCxYUHpyGHsGOVbYPlBRJlOS2.kBWUZmiirJOBlKYiZplHcBENiyG._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (qsYbGJggairMFSjRQBGCegTrMePq.tAMGNvJHqVaAaYbZoXOegDwAOXXwA.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						controllerMap_Editor = qsYbGJggairMFSjRQBGCegTrMePq.tAMGNvJHqVaAaYbZoXOegDwAOXXwA.mgvyKSUvZsJNkZHVxVphLZCuppDI;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.nlzBJZkGYUBqdSLQRsqWsxVuECxfA;
						lWbWrITCNsCbuIKUDXRgSKfZxdCR(controllerMap_Editor.actionElementMaps, qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB = controllerMap_Editor2;
					}
					else
					{
						CxLnsnkdkwYHdMHVUOlrEaOcqtKD.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.CreateKeyboardMap(qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB.categoryId, qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB.layoutId);
						controllerMap_Editor = qsYbGJggairMFSjRQBGCegTrMePq.tAMGNvJHqVaAaYbZoXOegDwAOXXwA.ugeCEhvlErURwUnLJqiIDYRYOHwl[qsYbGJggairMFSjRQBGCegTrMePq.tAMGNvJHqVaAaYbZoXOegDwAOXXwA.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB.id = controllerMap_Editor.id;
					int index = qsYbGJggairMFSjRQBGCegTrMePq.tAMGNvJHqVaAaYbZoXOegDwAOXXwA.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(controllerMap_Editor);
					qsYbGJggairMFSjRQBGCegTrMePq.tAMGNvJHqVaAaYbZoXOegDwAOXXwA.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB;
					return qsYbGJggairMFSjRQBGCegTrMePq.opkEZndLlCCXpfvDviWNohvVXBRB;
				}
			}

			private sealed class boIOqgDgchulJwGkMuRtZwKInImJ
			{
				public ControllerMap_Editor zxgAniClXTLZgZBaajFLtlvbmkBOA;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> hhTtmGejMYPeEQizSRCfMXyuTCBT;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> IFHwzjIGaYhdjWHuowGHPByYvAdt;

				internal bool WpmTQdHDegjdJhRyJLVDAuEkSHYB(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.agwikYysLXmatilUKiOTjqIGRQff == zxgAniClXTLZgZBaajFLtlvbmkBOA.categoryId;
				}

				internal bool AQddFvZiYyDgImdNWnBGUprOSfWE(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.agwikYysLXmatilUKiOTjqIGRQff == zxgAniClXTLZgZBaajFLtlvbmkBOA.layoutId;
				}
			}

			private sealed class QsYbGJggairMFSjRQBGCegTrMePq
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> tAMGNvJHqVaAaYbZoXOegDwAOXXwA;

				public ControllerMap_Editor opkEZndLlCCXpfvDviWNohvVXBRB;

				internal bool lvDCalOCgtGibcYcGRAyfIKDioGd(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(tAMGNvJHqVaAaYbZoXOegDwAOXXwA.YafjDixcJyoPiIDEDKrsbfeKtesQ) == opkEZndLlCCXpfvDviWNohvVXBRB.categoryId;
				}

				internal bool exqEzxgsaxOkxXzWrCffeFVXYqkJA(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(tAMGNvJHqVaAaYbZoXOegDwAOXXwA.YafjDixcJyoPiIDEDKrsbfeKtesQ) == opkEZndLlCCXpfvDviWNohvVXBRB.layoutId;
				}
			}

			private sealed class KJotlfnskfsxVSRrrKHWLTsJGZzd
			{
				public List<int> FXGWizaNKIxxSSJWSdwjCYchwHrk;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA AZpETFMcPuyXuJeIhUJCRXIyXruh;

				internal InputMapCategory wHTbEdbfkDSNaLgJjMIThKHTIamRA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					InputMapCategory inputMapCategory2;
					if (P_0.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						inputMapCategory2 = P_0.mgvyKSUvZsJNkZHVxVphLZCuppDI;
					}
					else
					{
						AZpETFMcPuyXuJeIhUJCRXIyXruh.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.AddMapCategory();
						inputMapCategory2 = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					int num = P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(inputMapCategory2);
					if (P_0.YafjDixcJyoPiIDEDKrsbfeKtesQ == pbaiftYdiKclxwXxYyVWHvgdPtuh.RyLVxEXwlbAxkVclGMDuydCElJWU.otherId)
					{
						FXGWizaNKIxxSSJWSdwjCYchwHrk.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.ugeCEhvlErURwUnLJqiIDYRYOHwl[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class zhBJlCxYUHpyGHsGOVbYPlBRJlOS
			{
				public ActionElementMap kBWUZmiirJOBlKYiZplHcBENiyG;

				public QsYbGJggairMFSjRQBGCegTrMePq EoiBYreVRZqjLDJpoZzUyOrTaoQI;

				internal bool cKjBmekTzbTpMOcJOyzYeHiqGNbAb(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(EoiBYreVRZqjLDJpoZzUyOrTaoQI.tAMGNvJHqVaAaYbZoXOegDwAOXXwA.YafjDixcJyoPiIDEDKrsbfeKtesQ) == kBWUZmiirJOBlKYiZplHcBENiyG._actionId;
				}
			}

			private sealed class fliJGeUXiupUkdonmoPLZkNtLHak
			{
				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> HcwcjKmWWEeTrFoGmoFMGgJHKYxCb;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA KsvGgldljXSGENtFiRvIaOtsrSld;

				internal int hMwOLYekNjLqWIlgRZfvUpRcikfO(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					eIckfOvqZSeaefjXIQtXGQLpbPibA eIckfOvqZSeaefjXIQtXGQLpbPibA2 = new eIckfOvqZSeaefjXIQtXGQLpbPibA();
					eIckfOvqZSeaefjXIQtXGQLpbPibA2.CdrvxdDiJCGxFjMZppsRMbqQVNZA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = KsvGgldljXSGENtFiRvIaOtsrSld.tdauQhwBXdZCoizKKphLymwdEtsbA.Find(eIckfOvqZSeaefjXIQtXGQLpbPibA2.gbxKjduoAqCIydifyJNzwCRTsPvL);
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = HcwcjKmWWEeTrFoGmoFMGgJHKYxCb.Find(eIckfOvqZSeaefjXIQtXGQLpbPibA2.CxyyunMJYxevsSRxlSSqtDrSFsBt);
						if (pbaiftYdiKclxwXxYyVWHvgdPtuh2 != null && pbaiftYdiKclxwXxYyVWHvgdPtuh2.rVMGOWUROKEvOjFcxbRfeorZKMBIb == P_1[i].categoryId && pbaiftYdiKclxwXxYyVWHvgdPtuh3 != null && pbaiftYdiKclxwXxYyVWHvgdPtuh3.rVMGOWUROKEvOjFcxbRfeorZKMBIb == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor kLMBIbdqpVxacqQDRwrCLrieigxv(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> P_0)
				{
					YtDxlPDzWJkgKxuYRjyROZQcBpAI ytDxlPDzWJkgKxuYRjyROZQcBpAI = new YtDxlPDzWJkgKxuYRjyROZQcBpAI();
					ytDxlPDzWJkgKxuYRjyROZQcBpAI.SIMUVHgFltiYTKzinQLkKrjoLbdy = P_0;
					ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD = JsonTools.Clone(ytDxlPDzWJkgKxuYRjyROZQcBpAI.SIMUVHgFltiYTKzinQLkKrjoLbdy.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = KsvGgldljXSGENtFiRvIaOtsrSld.tdauQhwBXdZCoizKKphLymwdEtsbA.Find(ytDxlPDzWJkgKxuYRjyROZQcBpAI.etBqQFegDSgjDBnQvKiiJrizhoUf);
					pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = HcwcjKmWWEeTrFoGmoFMGgJHKYxCb.Find(ytDxlPDzWJkgKxuYRjyROZQcBpAI.VhVxkyKJhweORebYjaYgSCawpxWy);
					ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD.categoryId = pbaiftYdiKclxwXxYyVWHvgdPtuh2?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD.layoutId = pbaiftYdiKclxwXxYyVWHvgdPtuh3?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					for (int i = 0; i < ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD.actionElementMaps.Count; i++)
					{
						MQRdBKPSCNSkjnVVnbwxpNLMmSQD mQRdBKPSCNSkjnVVnbwxpNLMmSQD = new MQRdBKPSCNSkjnVVnbwxpNLMmSQD();
						mQRdBKPSCNSkjnVVnbwxpNLMmSQD.lMxDrwdllnhjuifCYjAdaerYCCBS = ytDxlPDzWJkgKxuYRjyROZQcBpAI;
						mQRdBKPSCNSkjnVVnbwxpNLMmSQD.vtDABaAgUmLltCiqEsJIPhRAGgLRc = mQRdBKPSCNSkjnVVnbwxpNLMmSQD.lMxDrwdllnhjuifCYjAdaerYCCBS.XClgwvbPDKKHpQkkBISikIjQzyRD.actionElementMaps[i];
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh4 = KsvGgldljXSGENtFiRvIaOtsrSld.HVOspKBCEzGwfZERalougkmkdkIcA.Find(mQRdBKPSCNSkjnVVnbwxpNLMmSQD.aDCLtNSCBeMlpJodEgsTAYZgogBH);
						mQRdBKPSCNSkjnVVnbwxpNLMmSQD.vtDABaAgUmLltCiqEsJIPhRAGgLRc._actionId = pbaiftYdiKclxwXxYyVWHvgdPtuh4?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
						mQRdBKPSCNSkjnVVnbwxpNLMmSQD.vtDABaAgUmLltCiqEsJIPhRAGgLRc._actionCategoryId = ((KsvGgldljXSGENtFiRvIaOtsrSld.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.GetActionById(mQRdBKPSCNSkjnVVnbwxpNLMmSQD.vtDABaAgUmLltCiqEsJIPhRAGgLRc._actionId) != null) ? KsvGgldljXSGENtFiRvIaOtsrSld.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.GetActionById(mQRdBKPSCNSkjnVVnbwxpNLMmSQD.vtDABaAgUmLltCiqEsJIPhRAGgLRc._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (ytDxlPDzWJkgKxuYRjyROZQcBpAI.SIMUVHgFltiYTKzinQLkKrjoLbdy.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						controllerMap_Editor = ytDxlPDzWJkgKxuYRjyROZQcBpAI.SIMUVHgFltiYTKzinQLkKrjoLbdy.mgvyKSUvZsJNkZHVxVphLZCuppDI;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.cVuuJRroSshqaDneFEMIgPvDbGlYA;
						lWbWrITCNsCbuIKUDXRgSKfZxdCR(controllerMap_Editor.actionElementMaps, ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD = controllerMap_Editor2;
					}
					else
					{
						KsvGgldljXSGENtFiRvIaOtsrSld.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.CreateMouseMap(ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD.categoryId, ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD.layoutId);
						controllerMap_Editor = ytDxlPDzWJkgKxuYRjyROZQcBpAI.SIMUVHgFltiYTKzinQLkKrjoLbdy.ugeCEhvlErURwUnLJqiIDYRYOHwl[ytDxlPDzWJkgKxuYRjyROZQcBpAI.SIMUVHgFltiYTKzinQLkKrjoLbdy.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD.id = controllerMap_Editor.id;
					int index = ytDxlPDzWJkgKxuYRjyROZQcBpAI.SIMUVHgFltiYTKzinQLkKrjoLbdy.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(controllerMap_Editor);
					ytDxlPDzWJkgKxuYRjyROZQcBpAI.SIMUVHgFltiYTKzinQLkKrjoLbdy.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD;
					return ytDxlPDzWJkgKxuYRjyROZQcBpAI.XClgwvbPDKKHpQkkBISikIjQzyRD;
				}
			}

			private sealed class eIckfOvqZSeaefjXIQtXGQLpbPibA
			{
				public ControllerMap_Editor CdrvxdDiJCGxFjMZppsRMbqQVNZA;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> swUoAkoVJGwGxJPPyOaFcwnkKpKF;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> UeAlAqWsNZqbAnXdkTrmVlYEnBrV;

				internal bool gbxKjduoAqCIydifyJNzwCRTsPvL(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.agwikYysLXmatilUKiOTjqIGRQff == CdrvxdDiJCGxFjMZppsRMbqQVNZA.categoryId;
				}

				internal bool CxyyunMJYxevsSRxlSSqtDrSFsBt(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.agwikYysLXmatilUKiOTjqIGRQff == CdrvxdDiJCGxFjMZppsRMbqQVNZA.layoutId;
				}
			}

			private sealed class YtDxlPDzWJkgKxuYRjyROZQcBpAI
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> SIMUVHgFltiYTKzinQLkKrjoLbdy;

				public ControllerMap_Editor XClgwvbPDKKHpQkkBISikIjQzyRD;

				internal bool etBqQFegDSgjDBnQvKiiJrizhoUf(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(SIMUVHgFltiYTKzinQLkKrjoLbdy.YafjDixcJyoPiIDEDKrsbfeKtesQ) == XClgwvbPDKKHpQkkBISikIjQzyRD.categoryId;
				}

				internal bool VhVxkyKJhweORebYjaYgSCawpxWy(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(SIMUVHgFltiYTKzinQLkKrjoLbdy.YafjDixcJyoPiIDEDKrsbfeKtesQ) == XClgwvbPDKKHpQkkBISikIjQzyRD.layoutId;
				}
			}

			private sealed class MQRdBKPSCNSkjnVVnbwxpNLMmSQD
			{
				public ActionElementMap vtDABaAgUmLltCiqEsJIPhRAGgLRc;

				public YtDxlPDzWJkgKxuYRjyROZQcBpAI lMxDrwdllnhjuifCYjAdaerYCCBS;

				internal bool aDCLtNSCBeMlpJodEgsTAYZgogBH(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(lMxDrwdllnhjuifCYjAdaerYCCBS.SIMUVHgFltiYTKzinQLkKrjoLbdy.YafjDixcJyoPiIDEDKrsbfeKtesQ) == vtDABaAgUmLltCiqEsJIPhRAGgLRc._actionId;
				}
			}

			private sealed class UXFTiHxhzYFiejrCOoPGgSkKPDrlc
			{
				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> tbnawahQiyfXPpslJHNIwuzYRwpC;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA qUNqfdCCXpqAJRewGFGaHEsSJzrDb;

				internal int WRqgkiCHQxuigrpwrKVZKBRSCdbVA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					NcEcBFnrlmpwHLdPWHGIjYJIBvpcA ncEcBFnrlmpwHLdPWHGIjYJIBvpcA = new NcEcBFnrlmpwHLdPWHGIjYJIBvpcA();
					ncEcBFnrlmpwHLdPWHGIjYJIBvpcA.DRfekKvoyOtJCGYIZUttCvSskpEd = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = qUNqfdCCXpqAJRewGFGaHEsSJzrDb.tdauQhwBXdZCoizKKphLymwdEtsbA.Find(ncEcBFnrlmpwHLdPWHGIjYJIBvpcA.bEBfeBDWkWHNbOUORBBcbumDTkpU);
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = tbnawahQiyfXPpslJHNIwuzYRwpC.Find(ncEcBFnrlmpwHLdPWHGIjYJIBvpcA.JTSKzgEgnZWASFMZBJkMkMvyvshX);
						if (ncEcBFnrlmpwHLdPWHGIjYJIBvpcA.DRfekKvoyOtJCGYIZUttCvSskpEd.hardwareGuid == P_1[i].hardwareGuid && pbaiftYdiKclxwXxYyVWHvgdPtuh2 != null && pbaiftYdiKclxwXxYyVWHvgdPtuh2.rVMGOWUROKEvOjFcxbRfeorZKMBIb == P_1[i].categoryId && pbaiftYdiKclxwXxYyVWHvgdPtuh3 != null && pbaiftYdiKclxwXxYyVWHvgdPtuh3.rVMGOWUROKEvOjFcxbRfeorZKMBIb == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor aXWhyglWaSbVDGMuOeCMFVCHFcYBA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> P_0)
				{
					BMZoMYSrLkfLtkexGLPjvYgOwMlk bMZoMYSrLkfLtkexGLPjvYgOwMlk = new BMZoMYSrLkfLtkexGLPjvYgOwMlk();
					bMZoMYSrLkfLtkexGLPjvYgOwMlk.uFItkzJjGTOAhDJFmfacCqryIezpA = P_0;
					bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM = JsonTools.Clone(bMZoMYSrLkfLtkexGLPjvYgOwMlk.uFItkzJjGTOAhDJFmfacCqryIezpA.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = qUNqfdCCXpqAJRewGFGaHEsSJzrDb.tdauQhwBXdZCoizKKphLymwdEtsbA.Find(bMZoMYSrLkfLtkexGLPjvYgOwMlk.gVhDKSvZucrWMDGqcqdPBumVchU);
					pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = tbnawahQiyfXPpslJHNIwuzYRwpC.Find(bMZoMYSrLkfLtkexGLPjvYgOwMlk.igqlptIdDUapQyzgDrhvBdUPMQeg);
					bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM.categoryId = pbaiftYdiKclxwXxYyVWHvgdPtuh2?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM.layoutId = pbaiftYdiKclxwXxYyVWHvgdPtuh3?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					for (int i = 0; i < bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM.actionElementMaps.Count; i++)
					{
						FAMNKwhiHwIVIgMUsYRHuEalmqHNA fAMNKwhiHwIVIgMUsYRHuEalmqHNA = new FAMNKwhiHwIVIgMUsYRHuEalmqHNA();
						fAMNKwhiHwIVIgMUsYRHuEalmqHNA.YbRcySmwHzJNyiXQOFScUPcJAkrV = bMZoMYSrLkfLtkexGLPjvYgOwMlk;
						fAMNKwhiHwIVIgMUsYRHuEalmqHNA.NEANaQFZUpjJIhANgTEVkZgwHFLq = fAMNKwhiHwIVIgMUsYRHuEalmqHNA.YbRcySmwHzJNyiXQOFScUPcJAkrV.TqRGHxEzSVmXqzxPNWJbWnvRRhRM.actionElementMaps[i];
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh4 = qUNqfdCCXpqAJRewGFGaHEsSJzrDb.HVOspKBCEzGwfZERalougkmkdkIcA.Find(fAMNKwhiHwIVIgMUsYRHuEalmqHNA.ApIkPVuXHppTxvKsOhAFumNJbmNr);
						fAMNKwhiHwIVIgMUsYRHuEalmqHNA.NEANaQFZUpjJIhANgTEVkZgwHFLq._actionId = pbaiftYdiKclxwXxYyVWHvgdPtuh4?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
						fAMNKwhiHwIVIgMUsYRHuEalmqHNA.NEANaQFZUpjJIhANgTEVkZgwHFLq._actionCategoryId = ((qUNqfdCCXpqAJRewGFGaHEsSJzrDb.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.GetActionById(fAMNKwhiHwIVIgMUsYRHuEalmqHNA.NEANaQFZUpjJIhANgTEVkZgwHFLq._actionId) != null) ? qUNqfdCCXpqAJRewGFGaHEsSJzrDb.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.GetActionById(fAMNKwhiHwIVIgMUsYRHuEalmqHNA.NEANaQFZUpjJIhANgTEVkZgwHFLq._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (bMZoMYSrLkfLtkexGLPjvYgOwMlk.uFItkzJjGTOAhDJFmfacCqryIezpA.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						controllerMap_Editor = bMZoMYSrLkfLtkexGLPjvYgOwMlk.uFItkzJjGTOAhDJFmfacCqryIezpA.mgvyKSUvZsJNkZHVxVphLZCuppDI;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.PkNIkUWMKOVvBoQsZYosoWRzSexs;
						lWbWrITCNsCbuIKUDXRgSKfZxdCR(controllerMap_Editor.actionElementMaps, bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM = controllerMap_Editor2;
					}
					else
					{
						qUNqfdCCXpqAJRewGFGaHEsSJzrDb.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.CreateJoystickMap(bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM.categoryId, bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM.hardwareGuid, bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM.layoutId);
						controllerMap_Editor = bMZoMYSrLkfLtkexGLPjvYgOwMlk.uFItkzJjGTOAhDJFmfacCqryIezpA.ugeCEhvlErURwUnLJqiIDYRYOHwl[bMZoMYSrLkfLtkexGLPjvYgOwMlk.uFItkzJjGTOAhDJFmfacCqryIezpA.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM.id = controllerMap_Editor.id;
					int index = bMZoMYSrLkfLtkexGLPjvYgOwMlk.uFItkzJjGTOAhDJFmfacCqryIezpA.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(controllerMap_Editor);
					bMZoMYSrLkfLtkexGLPjvYgOwMlk.uFItkzJjGTOAhDJFmfacCqryIezpA.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM;
					return bMZoMYSrLkfLtkexGLPjvYgOwMlk.TqRGHxEzSVmXqzxPNWJbWnvRRhRM;
				}
			}

			private sealed class NcEcBFnrlmpwHLdPWHGIjYJIBvpcA
			{
				public ControllerMap_Editor DRfekKvoyOtJCGYIZUttCvSskpEd;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> JzZrrZDGeCFBYYsBQhgHorBuGAvgA;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> HQbKIrauNGcWJLpPoJVEvdcrCIHFA;

				internal bool bEBfeBDWkWHNbOUORBBcbumDTkpU(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.agwikYysLXmatilUKiOTjqIGRQff == DRfekKvoyOtJCGYIZUttCvSskpEd.categoryId;
				}

				internal bool JTSKzgEgnZWASFMZBJkMkMvyvshX(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.agwikYysLXmatilUKiOTjqIGRQff == DRfekKvoyOtJCGYIZUttCvSskpEd.layoutId;
				}
			}

			private sealed class BMZoMYSrLkfLtkexGLPjvYgOwMlk
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> uFItkzJjGTOAhDJFmfacCqryIezpA;

				public ControllerMap_Editor TqRGHxEzSVmXqzxPNWJbWnvRRhRM;

				internal bool gVhDKSvZucrWMDGqcqdPBumVchU(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(uFItkzJjGTOAhDJFmfacCqryIezpA.YafjDixcJyoPiIDEDKrsbfeKtesQ) == TqRGHxEzSVmXqzxPNWJbWnvRRhRM.categoryId;
				}

				internal bool igqlptIdDUapQyzgDrhvBdUPMQeg(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(uFItkzJjGTOAhDJFmfacCqryIezpA.YafjDixcJyoPiIDEDKrsbfeKtesQ) == TqRGHxEzSVmXqzxPNWJbWnvRRhRM.layoutId;
				}
			}

			private sealed class FAMNKwhiHwIVIgMUsYRHuEalmqHNA
			{
				public ActionElementMap NEANaQFZUpjJIhANgTEVkZgwHFLq;

				public BMZoMYSrLkfLtkexGLPjvYgOwMlk YbRcySmwHzJNyiXQOFScUPcJAkrV;

				internal bool ApIkPVuXHppTxvKsOhAFumNJbmNr(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(YbRcySmwHzJNyiXQOFScUPcJAkrV.uFItkzJjGTOAhDJFmfacCqryIezpA.YafjDixcJyoPiIDEDKrsbfeKtesQ) == NEANaQFZUpjJIhANgTEVkZgwHFLq._actionId;
				}
			}

			private sealed class JTvHfeujdxhNxJQuPNgKyUilhPDQA
			{
				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> JDkdqxjdIIAtYncEuameWCNzqZsFb;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA lzcVxCZtShaFBYDpEaXanLEWfIQHA;

				internal int sJlieWelIRYxamBzabISVgaRPYVE(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					nPbfaDaesvbhEmWJrZNGxvkPMkLdA nPbfaDaesvbhEmWJrZNGxvkPMkLdA2 = new nPbfaDaesvbhEmWJrZNGxvkPMkLdA();
					nPbfaDaesvbhEmWJrZNGxvkPMkLdA2.FqGVepjaxVFdjcJqMFdVjOUJGOpJB = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = lzcVxCZtShaFBYDpEaXanLEWfIQHA.UYCxRzZdDLLGFBARcsLyCWFWDgOg.Find(nPbfaDaesvbhEmWJrZNGxvkPMkLdA2.RGVDSXjhkPhTxDRfKePrDBGXFqUe);
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = lzcVxCZtShaFBYDpEaXanLEWfIQHA.tdauQhwBXdZCoizKKphLymwdEtsbA.Find(nPbfaDaesvbhEmWJrZNGxvkPMkLdA2.lUksoyBgJSYzcIvCcGowDyYchuaS);
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh4 = JDkdqxjdIIAtYncEuameWCNzqZsFb.Find(nPbfaDaesvbhEmWJrZNGxvkPMkLdA2.qXsLOBFPwmkHwxFkvbMAnmJKHZFz);
						if (pbaiftYdiKclxwXxYyVWHvgdPtuh2 != null && pbaiftYdiKclxwXxYyVWHvgdPtuh2.rVMGOWUROKEvOjFcxbRfeorZKMBIb == P_1[i].customControllerUid && pbaiftYdiKclxwXxYyVWHvgdPtuh3 != null && pbaiftYdiKclxwXxYyVWHvgdPtuh3.rVMGOWUROKEvOjFcxbRfeorZKMBIb == P_1[i].categoryId && pbaiftYdiKclxwXxYyVWHvgdPtuh4 != null && pbaiftYdiKclxwXxYyVWHvgdPtuh4.rVMGOWUROKEvOjFcxbRfeorZKMBIb == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor ShJWxqhzvMKFtyTWDELZbDYyNusc(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> P_0)
				{
					OMtZzPeycNEvEWftNjKofamWRcFN oMtZzPeycNEvEWftNjKofamWRcFN = new OMtZzPeycNEvEWftNjKofamWRcFN();
					oMtZzPeycNEvEWftNjKofamWRcFN.guAsUFbPVKKGVWjnhFcSDrEqnSPl = P_0;
					oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv = JsonTools.Clone(oMtZzPeycNEvEWftNjKofamWRcFN.guAsUFbPVKKGVWjnhFcSDrEqnSPl.KReenCbMSGfFYIrcJybCQrgyTpEmA);
					pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = lzcVxCZtShaFBYDpEaXanLEWfIQHA.UYCxRzZdDLLGFBARcsLyCWFWDgOg.Find(oMtZzPeycNEvEWftNjKofamWRcFN.icBIavfsOheCdyATTCMafayciyyEb);
					pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh3 = lzcVxCZtShaFBYDpEaXanLEWfIQHA.tdauQhwBXdZCoizKKphLymwdEtsbA.Find(oMtZzPeycNEvEWftNjKofamWRcFN.iEhTUoMbidntislVGwHsYQPrLIvl);
					pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh4 = JDkdqxjdIIAtYncEuameWCNzqZsFb.Find(oMtZzPeycNEvEWftNjKofamWRcFN.skaorCUldlOjiDuuoBidlmozfHfIA);
					oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv.customControllerUid = pbaiftYdiKclxwXxYyVWHvgdPtuh2?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv.categoryId = pbaiftYdiKclxwXxYyVWHvgdPtuh3?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv.layoutId = pbaiftYdiKclxwXxYyVWHvgdPtuh4?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					for (int i = 0; i < oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv.actionElementMaps.Count; i++)
					{
						JCQTTdUVWDSYLuRaflZreBNzYvgQ jCQTTdUVWDSYLuRaflZreBNzYvgQ = new JCQTTdUVWDSYLuRaflZreBNzYvgQ();
						jCQTTdUVWDSYLuRaflZreBNzYvgQ.MfRqNxVzEdUopHImfGiVFPBhCGDEb = oMtZzPeycNEvEWftNjKofamWRcFN;
						jCQTTdUVWDSYLuRaflZreBNzYvgQ.rGUthVkygPcSJTTuHfkIseNbhgsL = jCQTTdUVWDSYLuRaflZreBNzYvgQ.MfRqNxVzEdUopHImfGiVFPBhCGDEb.fVNQyeGLZxlTojzRgTtaioXFkjrv.actionElementMaps[i];
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh5 = lzcVxCZtShaFBYDpEaXanLEWfIQHA.HVOspKBCEzGwfZERalougkmkdkIcA.Find(jCQTTdUVWDSYLuRaflZreBNzYvgQ.RiIjFTMFUmFvAaZzNbEFAFaISUWL);
						jCQTTdUVWDSYLuRaflZreBNzYvgQ.rGUthVkygPcSJTTuHfkIseNbhgsL._actionId = pbaiftYdiKclxwXxYyVWHvgdPtuh5?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
						jCQTTdUVWDSYLuRaflZreBNzYvgQ.rGUthVkygPcSJTTuHfkIseNbhgsL._actionCategoryId = ((lzcVxCZtShaFBYDpEaXanLEWfIQHA.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.GetActionById(jCQTTdUVWDSYLuRaflZreBNzYvgQ.rGUthVkygPcSJTTuHfkIseNbhgsL._actionId) != null) ? lzcVxCZtShaFBYDpEaXanLEWfIQHA.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.GetActionById(jCQTTdUVWDSYLuRaflZreBNzYvgQ.rGUthVkygPcSJTTuHfkIseNbhgsL._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (oMtZzPeycNEvEWftNjKofamWRcFN.guAsUFbPVKKGVWjnhFcSDrEqnSPl.eNVHoUeKebisNsWFxFjTIUJnkLJkA)
					{
						controllerMap_Editor = oMtZzPeycNEvEWftNjKofamWRcFN.guAsUFbPVKKGVWjnhFcSDrEqnSPl.mgvyKSUvZsJNkZHVxVphLZCuppDI;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.JeoQfgadvDAbbaCkaLeoWCnAeimeb;
						lWbWrITCNsCbuIKUDXRgSKfZxdCR(controllerMap_Editor.actionElementMaps, oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv = controllerMap_Editor2;
					}
					else
					{
						lzcVxCZtShaFBYDpEaXanLEWfIQHA.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.CreateCustomControllerMap(oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv.categoryId, oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv.customControllerUid, oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv.layoutId);
						controllerMap_Editor = oMtZzPeycNEvEWftNjKofamWRcFN.guAsUFbPVKKGVWjnhFcSDrEqnSPl.ugeCEhvlErURwUnLJqiIDYRYOHwl[oMtZzPeycNEvEWftNjKofamWRcFN.guAsUFbPVKKGVWjnhFcSDrEqnSPl.ugeCEhvlErURwUnLJqiIDYRYOHwl.Count - 1];
					}
					oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv.id = controllerMap_Editor.id;
					int index = oMtZzPeycNEvEWftNjKofamWRcFN.guAsUFbPVKKGVWjnhFcSDrEqnSPl.ugeCEhvlErURwUnLJqiIDYRYOHwl.IndexOf(controllerMap_Editor);
					oMtZzPeycNEvEWftNjKofamWRcFN.guAsUFbPVKKGVWjnhFcSDrEqnSPl.ugeCEhvlErURwUnLJqiIDYRYOHwl[index] = oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv;
					return oMtZzPeycNEvEWftNjKofamWRcFN.fVNQyeGLZxlTojzRgTtaioXFkjrv;
				}
			}

			private sealed class rpOyYdeDywWOaigKPQEwFmBtJscG
			{
				public int JRCVYKXNNRdiRcudnPKvqJaTtnww;

				internal bool mjNUIWYZezAWSWkGIssLgndaQXtR(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.agwikYysLXmatilUKiOTjqIGRQff == JRCVYKXNNRdiRcudnPKvqJaTtnww;
				}
			}

			private sealed class nPbfaDaesvbhEmWJrZNGxvkPMkLdA
			{
				public ControllerMap_Editor FqGVepjaxVFdjcJqMFdVjOUJGOpJB;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> bRXpJrpPAgojcQoNgDVluvOuwlby;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> nssBtoTGExWpOvHyphtctmXdAySd;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> bbsSyqIuGCHGQXUwHmifHcgfjqgP;

				internal bool RGVDSXjhkPhTxDRfKePrDBGXFqUe(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.agwikYysLXmatilUKiOTjqIGRQff == FqGVepjaxVFdjcJqMFdVjOUJGOpJB.customControllerUid;
				}

				internal bool lUksoyBgJSYzcIvCcGowDyYchuaS(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.agwikYysLXmatilUKiOTjqIGRQff == FqGVepjaxVFdjcJqMFdVjOUJGOpJB.categoryId;
				}

				internal bool qXsLOBFPwmkHwxFkvbMAnmJKHZFz(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.agwikYysLXmatilUKiOTjqIGRQff == FqGVepjaxVFdjcJqMFdVjOUJGOpJB.layoutId;
				}
			}

			private sealed class OMtZzPeycNEvEWftNjKofamWRcFN
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> guAsUFbPVKKGVWjnhFcSDrEqnSPl;

				public ControllerMap_Editor fVNQyeGLZxlTojzRgTtaioXFkjrv;

				internal bool icBIavfsOheCdyATTCMafayciyyEb(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(guAsUFbPVKKGVWjnhFcSDrEqnSPl.YafjDixcJyoPiIDEDKrsbfeKtesQ) == fVNQyeGLZxlTojzRgTtaioXFkjrv.customControllerUid;
				}

				internal bool iEhTUoMbidntislVGwHsYQPrLIvl(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(guAsUFbPVKKGVWjnhFcSDrEqnSPl.YafjDixcJyoPiIDEDKrsbfeKtesQ) == fVNQyeGLZxlTojzRgTtaioXFkjrv.categoryId;
				}

				internal bool skaorCUldlOjiDuuoBidlmozfHfIA(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(guAsUFbPVKKGVWjnhFcSDrEqnSPl.YafjDixcJyoPiIDEDKrsbfeKtesQ) == fVNQyeGLZxlTojzRgTtaioXFkjrv.layoutId;
				}
			}

			private sealed class JCQTTdUVWDSYLuRaflZreBNzYvgQ
			{
				public ActionElementMap rGUthVkygPcSJTTuHfkIseNbhgsL;

				public OMtZzPeycNEvEWftNjKofamWRcFN MfRqNxVzEdUopHImfGiVFPBhCGDEb;

				internal bool RiIjFTMFUmFvAaZzNbEFAFaISUWL(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(MfRqNxVzEdUopHImfGiVFPBhCGDEb.guAsUFbPVKKGVWjnhFcSDrEqnSPl.YafjDixcJyoPiIDEDKrsbfeKtesQ) == rGUthVkygPcSJTTuHfkIseNbhgsL._actionId;
				}
			}

			private sealed class dZUvAutCcTNMAyYNQilmeqoHHSDV
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMapLayoutManager_RuleSet_Editor> jpAaxDAbNphxwjKrHLbRDuWiKfDD;
			}

			private sealed class YWhdKnvmWhcwfAbHPXnIWNJCFTaM
			{
				public int sxufaEASncEUKOWLyKykJUkTnkBAb;

				public dZUvAutCcTNMAyYNQilmeqoHHSDV KKthlPlbHppvSVFNareWeIGwLeuM;

				internal bool sLAZDtbSCCinFxKgpOaiDDVdckRG(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(KKthlPlbHppvSVFNareWeIGwLeuM.jpAaxDAbNphxwjKrHLbRDuWiKfDD.YafjDixcJyoPiIDEDKrsbfeKtesQ) == sxufaEASncEUKOWLyKykJUkTnkBAb;
				}
			}

			private sealed class cRbkbXSUIUgEbmPDOZVtSxGjlWtg
			{
				public int swCnxjFmcEMhUfgIMsOCHvoUGZwp;

				public dZUvAutCcTNMAyYNQilmeqoHHSDV xmJHkIPLSLcsxSGRsxhenTpPiVjU;

				internal bool BanCzxXlipDKIGnuYYltDxNiwrlA(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(xmJHkIPLSLcsxSGRsxhenTpPiVjU.jpAaxDAbNphxwjKrHLbRDuWiKfDD.YafjDixcJyoPiIDEDKrsbfeKtesQ) == swCnxjFmcEMhUfgIMsOCHvoUGZwp;
				}
			}

			private sealed class hemqEXIHmkNVhfljdaHFEckmeuEj
			{
				public int RgcDuMgdVqbtVaDeyypmfUPmpxkN;

				public dZUvAutCcTNMAyYNQilmeqoHHSDV jTTrvOGnVjLAzFxyirZBKhzCoxDc;

				internal bool moLEkithaEMjDsPZqyMnJQBCWDUE(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(jTTrvOGnVjLAzFxyirZBKhzCoxDc.jpAaxDAbNphxwjKrHLbRDuWiKfDD.YafjDixcJyoPiIDEDKrsbfeKtesQ) == RgcDuMgdVqbtVaDeyypmfUPmpxkN;
				}
			}

			private sealed class olaMmqrRwGfelIhzpdYLwlHmuHgj
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMapEnabler_RuleSet_Editor> XxIgYghITtWIbBaFzLbwoODMknxZ;
			}

			private sealed class QudBPWqGmojYYVwpRqgHiQOvjsxG
			{
				public int OfwLaGzsHEzXlEVcxknDRYvLLDOg;

				public olaMmqrRwGfelIhzpdYLwlHmuHgj fWXPHTNuCYRVaKoJmDqNiUcctLnUA;

				internal bool qRrWLDXpmvoJfCnWObnbaflCBAhbb(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.gYDLhzDUAwRgpKGednSfaloEZgDy(fWXPHTNuCYRVaKoJmDqNiUcctLnUA.XxIgYghITtWIbBaFzLbwoODMknxZ.YafjDixcJyoPiIDEDKrsbfeKtesQ) == OfwLaGzsHEzXlEVcxknDRYvLLDOg;
				}
			}

			private sealed class BvsfZGajZJaGbqxKeZZIczBuUCdr<_0001> where _0001 : class
			{
				public Func<_0001, int> RoEtiRllxeYHBdUOkDnrdqokTytG;
			}

			private sealed class xSCHfBSXFBxIgZqkDcswivLnOufQA<_0001> where _0001 : class
			{
				public _0001 jhOwflmQxyElJATzrHpLkhAvTQOo;

				public BvsfZGajZJaGbqxKeZZIczBuUCdr<_0001> KdoJCptvPTbWHUmexBRsRqJgizOq;

				internal bool MUdIBjiFxcyRBxoiOdVTbCtEcXLeb(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return P_0.rVMGOWUROKEvOjFcxbRfeorZKMBIb == KdoJCptvPTbWHUmexBRsRqJgizOq.RoEtiRllxeYHBdUOkDnrdqokTytG(jhOwflmQxyElJATzrHpLkhAvTQOo);
				}
			}

			public static UserData GLuKQSLpIrfrSKVqXkeucXgaYqrv(UserData P_0, UserData P_1, bool P_2)
			{
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2 = new yDXgPSFzJKEjAVzcCWeQWwNOfpAAA();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA = (P_2 ? P_0 : new UserData(false));
				if (P_1 != null)
				{
					yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.configVars = JsonTools.Clone(P_1.configVars);
				}
				else
				{
					yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.configVars = JsonTools.Clone(P_0.configVars);
				}
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.mqCVGMbcSCojuFmqzFPwyKjiCOAx = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Action Category", P_0.actionCategories, P_1?.actionCategories, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.actionCategories, P_2, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.mqCVGMbcSCojuFmqzFPwyKjiCOAx, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.qmSUkvlUBsHJMytGoCFuzYWzzioH, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.XTFfOEMGqtbTTTPiVkrFgxbJvMuS, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.kjSUkhHNHETCcANsDRVLoiZgvpcM, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.tZobfeeGfGPObQHGSrYORWSwHJYKA);
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.GjMyzhlCFsGRaXWBlArqAsrQzgEG = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.inputBehaviors, P_2, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.GjMyzhlCFsGRaXWBlArqAsrQzgEG, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.wWieShiTcAOchkKMNIZqQgqNpLkVA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.UzpIQoxhNEaiJXbPiZbAxEcmYPxn, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.RSPbjxZNtadqyhJgIEkWyypcGKYRA, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.nefvCrxqYbXsRmqisIKPPwGqFezs);
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.HVOspKBCEzGwfZERalougkmkdkIcA = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Action", P_0.rXMIXmZVqgXfOWciWmGdzMuYaZcG, P_1?.rXMIXmZVqgXfOWciWmGdzMuYaZcG, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.rXMIXmZVqgXfOWciWmGdzMuYaZcG, P_2, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.HVOspKBCEzGwfZERalougkmkdkIcA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.peIIwVjdEOESiGrlNdpHvXUXvrQ, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.CUrarbWnCZheVhkoYkITXpJXESNrA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.VtqdLKBFzqdliiQjwkBFEwCJyMFd, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.CXUdnggNTLGcCtzMzRowfCqFqLSb);
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.tdauQhwBXdZCoizKKphLymwdEtsbA = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				KJotlfnskfsxVSRrrKHWLTsJGZzd kJotlfnskfsxVSRrrKHWLTsJGZzd = new KJotlfnskfsxVSRrrKHWLTsJGZzd();
				kJotlfnskfsxVSRrrKHWLTsJGZzd.AZpETFMcPuyXuJeIhUJCRXIyXruh = yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2;
				kJotlfnskfsxVSRrrKHWLTsJGZzd.FXGWizaNKIxxSSJWSdwjCYchwHrk = new List<int>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Map Category", P_0.mapCategories, P_1?.mapCategories, kJotlfnskfsxVSRrrKHWLTsJGZzd.AZpETFMcPuyXuJeIhUJCRXIyXruh.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.mapCategories, P_2, kJotlfnskfsxVSRrrKHWLTsJGZzd.AZpETFMcPuyXuJeIhUJCRXIyXruh.tdauQhwBXdZCoizKKphLymwdEtsbA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.ulKAkRGhDqEgstQaKMcoNgHLekbUA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.ervHxwUEabgrYjpHjBsMzUCiRprp, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.zfjykosuqGHAwqYwRxoFdahTGVkw, kJotlfnskfsxVSRrrKHWLTsJGZzd.wHTbEdbfkDSNaLgJjMIThKHTIamRA);
				for (int i = 0; i < kJotlfnskfsxVSRrrKHWLTsJGZzd.FXGWizaNKIxxSSJWSdwjCYchwHrk.Count; i++)
				{
					int index = kJotlfnskfsxVSRrrKHWLTsJGZzd.FXGWizaNKIxxSSJWSdwjCYchwHrk[i];
					InputMapCategory inputMapCategory = kJotlfnskfsxVSRrrKHWLTsJGZzd.AZpETFMcPuyXuJeIhUJCRXIyXruh.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.mapCategories[index];
					for (int j = 0; j < inputMapCategory.VsTsjCSqoYfzEfBboOJteWttoNhoA.Count; j++)
					{
						rpOyYdeDywWOaigKPQEwFmBtJscG rpOyYdeDywWOaigKPQEwFmBtJscG2 = new rpOyYdeDywWOaigKPQEwFmBtJscG();
						rpOyYdeDywWOaigKPQEwFmBtJscG2.JRCVYKXNNRdiRcudnPKvqJaTtnww = inputMapCategory.VsTsjCSqoYfzEfBboOJteWttoNhoA[j];
						pbaiftYdiKclxwXxYyVWHvgdPtuh pbaiftYdiKclxwXxYyVWHvgdPtuh2 = kJotlfnskfsxVSRrrKHWLTsJGZzd.AZpETFMcPuyXuJeIhUJCRXIyXruh.tdauQhwBXdZCoizKKphLymwdEtsbA.Find(rpOyYdeDywWOaigKPQEwFmBtJscG2.mjNUIWYZezAWSWkGIssLgndaQXtR);
						inputMapCategory.VsTsjCSqoYfzEfBboOJteWttoNhoA[j] = pbaiftYdiKclxwXxYyVWHvgdPtuh2?.rVMGOWUROKEvOjFcxbRfeorZKMBIb ?? (-1);
					}
				}
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.FxgoWvWQTLGarRwFRjrlKYRLAktW = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.keyboardLayouts, P_2, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.FxgoWvWQTLGarRwFRjrlKYRLAktW, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.FhKqGkMHlMGgYHMLwmLHUwOFKTBKA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.BCUDjDAANHMCzIWXEFNIZrERPWdTA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.CMEfkIKIWZbPtpMjrlPlXnugobJtA, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.bZIHujsQIhEEXeCxWaRkBKDfpOUxA);
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.kHohpHRzYDIRXRrSFaHgCEXfbDFjA = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.mouseLayouts, P_2, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.kHohpHRzYDIRXRrSFaHgCEXfbDFjA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.lOxAhuZIxYzeGSBxuqvKhEqjzXzH, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.jVAVtrNQddJHApRTJEnMAmlnQHZr, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.LazcjXcqDGLVjqjHfhTBydXbHBykA, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.FSnBYMKdKcXZZBEvtGTUNuCdSGDL);
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.gLQYTsjAvfIuqGKgsRWYhTtJpmSi = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.joystickLayouts, P_2, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.gLQYTsjAvfIuqGKgsRWYhTtJpmSi, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.suhueOpPXqGEqdfWXfYdFahMypZf, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.ooJmFGhDQVnKmYVmCDxmNAxlxQWK, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.NnodTtArJunfsSgaHLUypACwkmzmA, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.VqBFnnVAYSYqOeaerRqpmAqubkce);
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.UncjVugpjBgMdrjrQGVjTSgOeVUf = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.customControllerLayouts, P_2, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.UncjVugpjBgMdrjrQGVjTSgOeVUf, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.KUaDVhbzgGaSJxkwELchJMTIBnFc, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.mYFLRCCiXyGzqHIMtmgoLWpRCnRCA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.sHurEYaxyGCtEoJFJFjiqTdjTuFL, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.nvCTgzvJQtvROLpHVcmuGscodCWAb);
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.PZeKdiPktDBgwfSetHSrWtfddbiN = yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.bzNxtgBOMmIrcBqJftpJtUUvGDxG;
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.UYCxRzZdDLLGFBARcsLyCWFWDgOg = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Custom Controller", P_0.customControllers, P_1?.customControllers, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.customControllers, P_2, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.UYCxRzZdDLLGFBARcsLyCWFWDgOg, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.wUDDdocRiOEFUcHXBvBshMtyeJEqc, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.bURUeUZGnvnYQjvNgspJoGlLoadp, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.aCthqBcwguxJcQEhmQgqKYzHNnzc, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.nvoCjSgrDsgRcUecTBveLnXLAnlKA);
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.akBryfUMqSHSqyPclTYsVgRKltsh = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.controllerMapLayoutManagerRuleSets, P_2, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.akBryfUMqSHSqyPclTYsVgRKltsh, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.JaOTRWEJpxcNkaeQsLZjqdyNKABG, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.tJAGusCqQZqoLTLAMukelLxugnos, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.PiRNOZUSxGEdZQThXRRoFbRCYLqP, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.zTOAjdgkXlUAbNcDLCqfaRUgWsBRB);
				yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.GgGoeKMevukuQSPlmiwDfTTgqOXgb = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.controllerMapEnablerRuleSets, P_2, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.GgGoeKMevukuQSPlmiwDfTTgqOXgb, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.UPTaXMAexwldAYHkpWAsghxSqgJTA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.osfFyPnxiNHUQBlzKUJXphdmlnHm, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.zhYrRtNQlcmKVAERJpcMlgSBzRSq, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.ZYVIyDyHAvLKdShYSENWCyrtiTuIA);
				List<pbaiftYdiKclxwXxYyVWHvgdPtuh> list = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Player", P_0.players, P_1?.players, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.players, P_2, list, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.fbfdTegRoCnvzbnTRqFmAEjJGLljA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.DzeGvFhaSvifHqLADeDzIxMUhRXf, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.KxRUxnQYjlNdfIwDVKsRtYlezaJL, yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.oUSJVfJEjdPGirFvTXDDWsINvwAj);
				List<pbaiftYdiKclxwXxYyVWHvgdPtuh> list2 = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				WNPdiiupcRaoTTwSPyAtwHMkDnlG wNPdiiupcRaoTTwSPyAtwHMkDnlG = new WNPdiiupcRaoTTwSPyAtwHMkDnlG();
				wNPdiiupcRaoTTwSPyAtwHMkDnlG.CxLnsnkdkwYHdMHVUOlrEaOcqtKD = yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2;
				wNPdiiupcRaoTTwSPyAtwHMkDnlG.DrzeeShFcKNbVQHvKFNGXEyYLefXA = wNPdiiupcRaoTTwSPyAtwHMkDnlG.CxLnsnkdkwYHdMHVUOlrEaOcqtKD.FxgoWvWQTLGarRwFRjrlKYRLAktW;
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, wNPdiiupcRaoTTwSPyAtwHMkDnlG.CxLnsnkdkwYHdMHVUOlrEaOcqtKD.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.keyboardMaps, P_2, list2, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.BizFeuaeiQjyqZNxyDvsbQsHInwAb, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.jwieGVbFIOdBYxgKjNmYiFDIMEexb, wNPdiiupcRaoTTwSPyAtwHMkDnlG.fdnnlTdwvibfpihIYoClEnqgQyik, wNPdiiupcRaoTTwSPyAtwHMkDnlG.nPNtAaCLFUBYZOJrDCcaFsJfPOTW);
				List<pbaiftYdiKclxwXxYyVWHvgdPtuh> list3 = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				fliJGeUXiupUkdonmoPLZkNtLHak fliJGeUXiupUkdonmoPLZkNtLHak2 = new fliJGeUXiupUkdonmoPLZkNtLHak();
				fliJGeUXiupUkdonmoPLZkNtLHak2.KsvGgldljXSGENtFiRvIaOtsrSld = yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2;
				fliJGeUXiupUkdonmoPLZkNtLHak2.HcwcjKmWWEeTrFoGmoFMGgJHKYxCb = fliJGeUXiupUkdonmoPLZkNtLHak2.KsvGgldljXSGENtFiRvIaOtsrSld.kHohpHRzYDIRXRrSFaHgCEXfbDFjA;
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, fliJGeUXiupUkdonmoPLZkNtLHak2.KsvGgldljXSGENtFiRvIaOtsrSld.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.mouseMaps, P_2, list3, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.dBMquGlVRJuxTxcabCOGHxupqMwIA, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.IloOepQQtfZyNriJOSudlTKxufbE, fliJGeUXiupUkdonmoPLZkNtLHak2.hMwOLYekNjLqWIlgRZfvUpRcikfO, fliJGeUXiupUkdonmoPLZkNtLHak2.kLMBIbdqpVxacqQDRwrCLrieigxv);
				List<pbaiftYdiKclxwXxYyVWHvgdPtuh> list4 = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				UXFTiHxhzYFiejrCOoPGgSkKPDrlc uXFTiHxhzYFiejrCOoPGgSkKPDrlc = new UXFTiHxhzYFiejrCOoPGgSkKPDrlc();
				uXFTiHxhzYFiejrCOoPGgSkKPDrlc.qUNqfdCCXpqAJRewGFGaHEsSJzrDb = yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2;
				uXFTiHxhzYFiejrCOoPGgSkKPDrlc.tbnawahQiyfXPpslJHNIwuzYRwpC = uXFTiHxhzYFiejrCOoPGgSkKPDrlc.qUNqfdCCXpqAJRewGFGaHEsSJzrDb.gLQYTsjAvfIuqGKgsRWYhTtJpmSi;
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, uXFTiHxhzYFiejrCOoPGgSkKPDrlc.qUNqfdCCXpqAJRewGFGaHEsSJzrDb.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.joystickMaps, P_2, list4, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.biODtnlEgAyjsifkXYOdlrUiVgeX, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.ggylrcNwDfHVrukkdpIqcsbCqqVT, uXFTiHxhzYFiejrCOoPGgSkKPDrlc.WRqgkiCHQxuigrpwrKVZKBRSCdbVA, uXFTiHxhzYFiejrCOoPGgSkKPDrlc.aXWhyglWaSbVDGMuOeCMFVCHFcYBA);
				List<pbaiftYdiKclxwXxYyVWHvgdPtuh> list5 = new List<pbaiftYdiKclxwXxYyVWHvgdPtuh>();
				JTvHfeujdxhNxJQuPNgKyUilhPDQA jTvHfeujdxhNxJQuPNgKyUilhPDQA = new JTvHfeujdxhNxJQuPNgKyUilhPDQA();
				jTvHfeujdxhNxJQuPNgKyUilhPDQA.lzcVxCZtShaFBYDpEaXanLEWfIQHA = yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2;
				jTvHfeujdxhNxJQuPNgKyUilhPDQA.JDkdqxjdIIAtYncEuameWCNzqZsFb = jTvHfeujdxhNxJQuPNgKyUilhPDQA.lzcVxCZtShaFBYDpEaXanLEWfIQHA.UncjVugpjBgMdrjrQGVjTSgOeVUf;
				dTgMKrDmpiPFpXgtPHFTDKxNhJGO("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, jTvHfeujdxhNxJQuPNgKyUilhPDQA.lzcVxCZtShaFBYDpEaXanLEWfIQHA.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA.customControllerMaps, P_2, list5, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.MSKIPUtZDtCPpHndhqDKAPivOToe, rZBdHIgGSMIYEnHuMUZACzNAagTSA._003C_003E9.mjiDWtSirXPiZbUmCPrSRjfFQOOD, jTvHfeujdxhNxJQuPNgKyUilhPDQA.sJlieWelIRYxamBzabISVgaRPYVE, jTvHfeujdxhNxJQuPNgKyUilhPDQA.ShJWxqhzvMKFtyTWDELZbDYyNusc);
				return yDXgPSFzJKEjAVzcCWeQWwNOfpAAA2.WTFJLvaaRHgbqhJkZHcYxBZjdqlzA;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void TNbYZiXWNuOTNyfnrvQOBgJcOMyk(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void lWbWrITCNsCbuIKUDXRgSKfZxdCR<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
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

			private static void dTgMKrDmpiPFpXgtPHFTDKxNhJGO<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<pbaiftYdiKclxwXxYyVWHvgdPtuh> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<hLnxJwqHptLEGiSLBxmvbWzdYyQF<_0001>, _0001> P_9) where _0001 : class
			{
				BvsfZGajZJaGbqxKeZZIczBuUCdr<_0001> bvsfZGajZJaGbqxKeZZIczBuUCdr = new BvsfZGajZJaGbqxKeZZIczBuUCdr<_0001>();
				bvsfZGajZJaGbqxKeZZIczBuUCdr.RoEtiRllxeYHBdUOkDnrdqokTytG = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					_0001 val = P_1[i];
					if (P_4)
					{
						P_5.Add(new pbaiftYdiKclxwXxYyVWHvgdPtuh(bvsfZGajZJaGbqxKeZZIczBuUCdr.RoEtiRllxeYHBdUOkDnrdqokTytG(val), -1, bvsfZGajZJaGbqxKeZZIczBuUCdr.RoEtiRllxeYHBdUOkDnrdqokTytG(val)));
						continue;
					}
					_0001 arg = P_9(new hLnxJwqHptLEGiSLBxmvbWzdYyQF<_0001>(val, null, pbaiftYdiKclxwXxYyVWHvgdPtuh.RyLVxEXwlbAxkVclGMDuydCElJWU.origId, P_3, false));
					P_5.Add(new pbaiftYdiKclxwXxYyVWHvgdPtuh(bvsfZGajZJaGbqxKeZZIczBuUCdr.RoEtiRllxeYHBdUOkDnrdqokTytG(val), -1, bvsfZGajZJaGbqxKeZZIczBuUCdr.RoEtiRllxeYHBdUOkDnrdqokTytG(arg)));
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
						xSCHfBSXFBxIgZqkDcswivLnOufQA<_0001> xSCHfBSXFBxIgZqkDcswivLnOufQA2 = new xSCHfBSXFBxIgZqkDcswivLnOufQA<_0001>();
						xSCHfBSXFBxIgZqkDcswivLnOufQA2.KdoJCptvPTbWHUmexBRsRqJgizOq = bvsfZGajZJaGbqxKeZZIczBuUCdr;
						_0001 val3 = P_3[num];
						xSCHfBSXFBxIgZqkDcswivLnOufQA2.jhOwflmQxyElJATzrHpLkhAvTQOo = P_9(new hLnxJwqHptLEGiSLBxmvbWzdYyQF<_0001>(val2, val3, pbaiftYdiKclxwXxYyVWHvgdPtuh.RyLVxEXwlbAxkVclGMDuydCElJWU.otherId, P_3, true));
						P_5.Find(xSCHfBSXFBxIgZqkDcswivLnOufQA2.MUdIBjiFxcyRBxoiOdVTbCtEcXLeb).agwikYysLXmatilUKiOTjqIGRQff = xSCHfBSXFBxIgZqkDcswivLnOufQA2.KdoJCptvPTbWHUmexBRsRqJgizOq.RoEtiRllxeYHBdUOkDnrdqokTytG(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						_0001 arg2 = P_9(new hLnxJwqHptLEGiSLBxmvbWzdYyQF<_0001>(val2, null, pbaiftYdiKclxwXxYyVWHvgdPtuh.RyLVxEXwlbAxkVclGMDuydCElJWU.otherId, P_3, false));
						P_5.Add(new pbaiftYdiKclxwXxYyVWHvgdPtuh(-1, bvsfZGajZJaGbqxKeZZIczBuUCdr.RoEtiRllxeYHBdUOkDnrdqokTytG(val2), bvsfZGajZJaGbqxKeZZIczBuUCdr.RoEtiRllxeYHBdUOkDnrdqokTytG(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}
		}

		[Serializable]
		private sealed class KmWpPgLLukIJrpAVCBgaAZnDlCnIA
		{
			public static readonly KmWpPgLLukIJrpAVCBgaAZnDlCnIA _003C_003E9 = new KmWpPgLLukIJrpAVCBgaAZnDlCnIA();

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__199_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__217_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__233_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__249_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__265_0;

			internal void GTgUcruAfTPBKFolnNeaumiKEiOm(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void oBwXifmmPQfYSqbWbricryhYsEz(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void gBGdxKAaySvySGDCISdQCErAJrfMA(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void RDeIrfIjLXmQqgUBdveKeshytMyFc(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void dYycJPbTJPVcTeBERLaKwVAwHGHT(List<Player_Editor.Mapping> P_0, int P_1)
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

		private sealed class fjTgItaHxApYEQguultGgHQxZOSUA
		{
			public List<InputLayout> iOIJZxjQZbKFCVlGajIRTeGbEdq;

			internal int YayexcWqwTXIZKIcSGUnGZYIPYxk(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				rFxDIKumDTSwluJxXhDqqjQczrFU rFxDIKumDTSwluJxXhDqqjQczrFU2 = new rFxDIKumDTSwluJxXhDqqjQczrFU();
				rFxDIKumDTSwluJxXhDqqjQczrFU2.gAXvuBPDsijPoVKwpXJMjGrllnNl = P_0;
				rFxDIKumDTSwluJxXhDqqjQczrFU2.aTQkIRVoWXdlGDprTEWVIAjCkLKSA = P_1;
				int num = iOIJZxjQZbKFCVlGajIRTeGbEdq.FindIndex(rFxDIKumDTSwluJxXhDqqjQczrFU2.EiacEcRlyetJfktIUtzluNaZjtqh);
				int num2 = iOIJZxjQZbKFCVlGajIRTeGbEdq.FindIndex(rFxDIKumDTSwluJxXhDqqjQczrFU2.WkGiBCyMAAAaDJgQYPGNKaqIdGCt);
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

		private sealed class rFxDIKumDTSwluJxXhDqqjQczrFU
		{
			public ControllerMap_Editor gAXvuBPDsijPoVKwpXJMjGrllnNl;

			public ControllerMap_Editor aTQkIRVoWXdlGDprTEWVIAjCkLKSA;

			internal bool EiacEcRlyetJfktIUtzluNaZjtqh(InputLayout P_0)
			{
				return P_0.id == gAXvuBPDsijPoVKwpXJMjGrllnNl.id;
			}

			internal bool WkGiBCyMAAAaDJgQYPGNKaqIdGCt(InputLayout P_0)
			{
				return P_0.id == aTQkIRVoWXdlGDprTEWVIAjCkLKSA.id;
			}
		}

		private sealed class laOsDuMvIZoIRnicQVqCSJEAcqXG : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int XGzpRgLiMijSvgeEdEVtGtLwprqFb;

			private InputCategory BKqLdbKSCngsItqdlPRpkgUUcIiC;

			private int CjlVKJEjEwBwdZIKCQDBTOVfShgP;

			private string KrxHhidHNUUniUAfXdSGbYrGwVTy;

			public string DcJVyQTLLaCVIVIkLDqAquIlhCQv;

			public UserData GaeQRdkJqVWiPUIsFpDhyjLyPjsF;

			private int mzYNvUTSwmYrIqlyzowGhUashczg;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return BKqLdbKSCngsItqdlPRpkgUUcIiC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return BKqLdbKSCngsItqdlPRpkgUUcIiC;
				}
			}

			[DebuggerHidden]
			public laOsDuMvIZoIRnicQVqCSJEAcqXG(int P_0)
			{
				XGzpRgLiMijSvgeEdEVtGtLwprqFb = P_0;
				CjlVKJEjEwBwdZIKCQDBTOVfShgP = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				XGzpRgLiMijSvgeEdEVtGtLwprqFb = -2;
			}

			private bool MoveNext()
			{
				int xGzpRgLiMijSvgeEdEVtGtLwprqFb = XGzpRgLiMijSvgeEdEVtGtLwprqFb;
				UserData gaeQRdkJqVWiPUIsFpDhyjLyPjsF = GaeQRdkJqVWiPUIsFpDhyjLyPjsF;
				if (xGzpRgLiMijSvgeEdEVtGtLwprqFb != 0)
				{
					if (xGzpRgLiMijSvgeEdEVtGtLwprqFb != 1)
					{
						return false;
					}
					XGzpRgLiMijSvgeEdEVtGtLwprqFb = -1;
					goto IL_0098;
				}
				XGzpRgLiMijSvgeEdEVtGtLwprqFb = -1;
				if (KrxHhidHNUUniUAfXdSGbYrGwVTy == null || KrxHhidHNUUniUAfXdSGbYrGwVTy == string.Empty)
				{
					return false;
				}
				if (gaeQRdkJqVWiPUIsFpDhyjLyPjsF.actionCategories == null)
				{
					return false;
				}
				mzYNvUTSwmYrIqlyzowGhUashczg = 0;
				goto IL_00a8;
				IL_00a8:
				if (mzYNvUTSwmYrIqlyzowGhUashczg < gaeQRdkJqVWiPUIsFpDhyjLyPjsF.actionCategories.Count)
				{
					if (gaeQRdkJqVWiPUIsFpDhyjLyPjsF.actionCategories[mzYNvUTSwmYrIqlyzowGhUashczg].tag.Equals(KrxHhidHNUUniUAfXdSGbYrGwVTy, StringComparison.OrdinalIgnoreCase))
					{
						BKqLdbKSCngsItqdlPRpkgUUcIiC = gaeQRdkJqVWiPUIsFpDhyjLyPjsF.actionCategories[mzYNvUTSwmYrIqlyzowGhUashczg];
						XGzpRgLiMijSvgeEdEVtGtLwprqFb = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				mzYNvUTSwmYrIqlyzowGhUashczg++;
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
				laOsDuMvIZoIRnicQVqCSJEAcqXG laOsDuMvIZoIRnicQVqCSJEAcqXG2;
				if (XGzpRgLiMijSvgeEdEVtGtLwprqFb == -2 && CjlVKJEjEwBwdZIKCQDBTOVfShgP == Environment.CurrentManagedThreadId)
				{
					XGzpRgLiMijSvgeEdEVtGtLwprqFb = 0;
					laOsDuMvIZoIRnicQVqCSJEAcqXG2 = this;
				}
				else
				{
					laOsDuMvIZoIRnicQVqCSJEAcqXG2 = new laOsDuMvIZoIRnicQVqCSJEAcqXG(0);
					laOsDuMvIZoIRnicQVqCSJEAcqXG2.GaeQRdkJqVWiPUIsFpDhyjLyPjsF = GaeQRdkJqVWiPUIsFpDhyjLyPjsF;
				}
				laOsDuMvIZoIRnicQVqCSJEAcqXG2.KrxHhidHNUUniUAfXdSGbYrGwVTy = DcJVyQTLLaCVIVIkLDqAquIlhCQv;
				return laOsDuMvIZoIRnicQVqCSJEAcqXG2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class QxuoQHxFTYCYiAkIaQgJbKGtWmSWA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int cHZQecCZBLKGBLWhrRrjzJAVYUFH;

			private InputAction ACnIczIyHrUYyXdVOLjqckVKZqk;

			private int LirDLGRmTgAPLsJCxnUaaewPAlTGA;

			public UserData yIIeefElaDGQahvDSrwiKSxCUzzt;

			private string hdHWEFYNjiTILUTdZvrMUvTdNNGK;

			public string tArFveNifLGSactXaloIQPmMIzXaA;

			private int riIXqskHwqqRFrTIDZuoSGvgDuFY;

			private int jAKrhwjaUmXDxhJMewQMwAngbNpKA;

			private InputCategory BxekSRhjuSAdcBSaDgkdIKOTaOmJ;

			private int iFDBTccZHbbtjWOfaizqDooGjctYB;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return ACnIczIyHrUYyXdVOLjqckVKZqk;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ACnIczIyHrUYyXdVOLjqckVKZqk;
				}
			}

			[DebuggerHidden]
			public QxuoQHxFTYCYiAkIaQgJbKGtWmSWA(int P_0)
			{
				cHZQecCZBLKGBLWhrRrjzJAVYUFH = P_0;
				LirDLGRmTgAPLsJCxnUaaewPAlTGA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				BxekSRhjuSAdcBSaDgkdIKOTaOmJ = null;
				cHZQecCZBLKGBLWhrRrjzJAVYUFH = -2;
			}

			private bool MoveNext()
			{
				int num = cHZQecCZBLKGBLWhrRrjzJAVYUFH;
				UserData userData = yIIeefElaDGQahvDSrwiKSxCUzzt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					cHZQecCZBLKGBLWhrRrjzJAVYUFH = -1;
					goto IL_00fd;
				}
				cHZQecCZBLKGBLWhrRrjzJAVYUFH = -1;
				if (userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG == null || userData.actionCategories == null)
				{
					return false;
				}
				if (hdHWEFYNjiTILUTdZvrMUvTdNNGK == null || hdHWEFYNjiTILUTdZvrMUvTdNNGK == string.Empty)
				{
					return false;
				}
				riIXqskHwqqRFrTIDZuoSGvgDuFY = userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count;
				jAKrhwjaUmXDxhJMewQMwAngbNpKA = 0;
				goto IL_0132;
				IL_0122:
				jAKrhwjaUmXDxhJMewQMwAngbNpKA++;
				goto IL_0132;
				IL_00fd:
				iFDBTccZHbbtjWOfaizqDooGjctYB++;
				goto IL_010d;
				IL_010d:
				if (iFDBTccZHbbtjWOfaizqDooGjctYB < riIXqskHwqqRFrTIDZuoSGvgDuFY)
				{
					if (BxekSRhjuSAdcBSaDgkdIKOTaOmJ.id == userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG[iFDBTccZHbbtjWOfaizqDooGjctYB].categoryId)
					{
						ACnIczIyHrUYyXdVOLjqckVKZqk = userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG[iFDBTccZHbbtjWOfaizqDooGjctYB];
						cHZQecCZBLKGBLWhrRrjzJAVYUFH = 1;
						return true;
					}
					goto IL_00fd;
				}
				BxekSRhjuSAdcBSaDgkdIKOTaOmJ = null;
				goto IL_0122;
				IL_0132:
				if (jAKrhwjaUmXDxhJMewQMwAngbNpKA < userData.actionCategories.Count)
				{
					if (userData.actionCategories[jAKrhwjaUmXDxhJMewQMwAngbNpKA].tag.Equals(hdHWEFYNjiTILUTdZvrMUvTdNNGK, StringComparison.OrdinalIgnoreCase))
					{
						BxekSRhjuSAdcBSaDgkdIKOTaOmJ = userData.actionCategories[jAKrhwjaUmXDxhJMewQMwAngbNpKA];
						iFDBTccZHbbtjWOfaizqDooGjctYB = 0;
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
				QxuoQHxFTYCYiAkIaQgJbKGtWmSWA qxuoQHxFTYCYiAkIaQgJbKGtWmSWA;
				if (cHZQecCZBLKGBLWhrRrjzJAVYUFH == -2 && LirDLGRmTgAPLsJCxnUaaewPAlTGA == Environment.CurrentManagedThreadId)
				{
					cHZQecCZBLKGBLWhrRrjzJAVYUFH = 0;
					qxuoQHxFTYCYiAkIaQgJbKGtWmSWA = this;
				}
				else
				{
					qxuoQHxFTYCYiAkIaQgJbKGtWmSWA = new QxuoQHxFTYCYiAkIaQgJbKGtWmSWA(0);
					qxuoQHxFTYCYiAkIaQgJbKGtWmSWA.yIIeefElaDGQahvDSrwiKSxCUzzt = yIIeefElaDGQahvDSrwiKSxCUzzt;
				}
				qxuoQHxFTYCYiAkIaQgJbKGtWmSWA.hdHWEFYNjiTILUTdZvrMUvTdNNGK = tArFveNifLGSactXaloIQPmMIzXaA;
				return qxuoQHxFTYCYiAkIaQgJbKGtWmSWA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class iyTEIBBiFUNFIoKKuJdOTJBIIgBG : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int SLXWaKtMusqgCHGOfUChAKUFyTZv;

			private InputAction LwJwgKWVOAcsMAzVamPZFOBlySDK;

			private int qpJwqGOiBrXNaxCPOjjXyEYOWkhF;

			public UserData MVyOsEBZMQqzUWWuHdmlYEZwNrep;

			private bool lfUoLoDtwKpBxjnIgtWupoXUajOi;

			public bool BSDfrLuuwxARayspBKTnNpVqCSPFA;

			private int vKSmtLQYfEsoupgGfayNyxgyssRK;

			public int dHcIgjGaKeMqLTMwhdpJCdTRrfMx;

			private IEnumerator<int> PyxNPsQOVShPPUNENdgSjWCOTFLJA;

			private int snlOQKTdSFSliQjuhbJafFJPatuu;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return LwJwgKWVOAcsMAzVamPZFOBlySDK;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return LwJwgKWVOAcsMAzVamPZFOBlySDK;
				}
			}

			[DebuggerHidden]
			public iyTEIBBiFUNFIoKKuJdOTJBIIgBG(int P_0)
			{
				SLXWaKtMusqgCHGOfUChAKUFyTZv = P_0;
				qpJwqGOiBrXNaxCPOjjXyEYOWkhF = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int sLXWaKtMusqgCHGOfUChAKUFyTZv = SLXWaKtMusqgCHGOfUChAKUFyTZv;
				if (sLXWaKtMusqgCHGOfUChAKUFyTZv == -3 || sLXWaKtMusqgCHGOfUChAKUFyTZv == 1)
				{
					try
					{
					}
					finally
					{
						JbSVpFPQXHLRGNgSpSlNCFMmJamv();
					}
				}
				PyxNPsQOVShPPUNENdgSjWCOTFLJA = null;
				SLXWaKtMusqgCHGOfUChAKUFyTZv = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int sLXWaKtMusqgCHGOfUChAKUFyTZv = SLXWaKtMusqgCHGOfUChAKUFyTZv;
					UserData mVyOsEBZMQqzUWWuHdmlYEZwNrep = MVyOsEBZMQqzUWWuHdmlYEZwNrep;
					switch (sLXWaKtMusqgCHGOfUChAKUFyTZv)
					{
					default:
						return false;
					case 0:
						SLXWaKtMusqgCHGOfUChAKUFyTZv = -1;
						if (mVyOsEBZMQqzUWWuHdmlYEZwNrep.rXMIXmZVqgXfOWciWmGdzMuYaZcG == null || mVyOsEBZMQqzUWWuHdmlYEZwNrep.actionCategories == null)
						{
							return false;
						}
						if (lfUoLoDtwKpBxjnIgtWupoXUajOi)
						{
							PyxNPsQOVShPPUNENdgSjWCOTFLJA = mVyOsEBZMQqzUWWuHdmlYEZwNrep.SortedActionIdsInCategory(vKSmtLQYfEsoupgGfayNyxgyssRK).GetEnumerator();
							SLXWaKtMusqgCHGOfUChAKUFyTZv = -3;
							goto IL_00a5;
						}
						snlOQKTdSFSliQjuhbJafFJPatuu = 0;
						goto IL_0123;
					case 1:
						SLXWaKtMusqgCHGOfUChAKUFyTZv = -3;
						goto IL_00a5;
					case 2:
						{
							SLXWaKtMusqgCHGOfUChAKUFyTZv = -1;
							goto IL_0111;
						}
						IL_0123:
						if (snlOQKTdSFSliQjuhbJafFJPatuu >= mVyOsEBZMQqzUWWuHdmlYEZwNrep.rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count)
						{
							break;
						}
						if (mVyOsEBZMQqzUWWuHdmlYEZwNrep.rXMIXmZVqgXfOWciWmGdzMuYaZcG[snlOQKTdSFSliQjuhbJafFJPatuu].categoryId == vKSmtLQYfEsoupgGfayNyxgyssRK)
						{
							LwJwgKWVOAcsMAzVamPZFOBlySDK = mVyOsEBZMQqzUWWuHdmlYEZwNrep.rXMIXmZVqgXfOWciWmGdzMuYaZcG[snlOQKTdSFSliQjuhbJafFJPatuu];
							SLXWaKtMusqgCHGOfUChAKUFyTZv = 2;
							return true;
						}
						goto IL_0111;
						IL_0111:
						snlOQKTdSFSliQjuhbJafFJPatuu++;
						goto IL_0123;
						IL_00a5:
						while (PyxNPsQOVShPPUNENdgSjWCOTFLJA.MoveNext())
						{
							int current = PyxNPsQOVShPPUNENdgSjWCOTFLJA.Current;
							InputAction actionById = mVyOsEBZMQqzUWWuHdmlYEZwNrep.GetActionById(current);
							if (actionById != null)
							{
								LwJwgKWVOAcsMAzVamPZFOBlySDK = actionById;
								SLXWaKtMusqgCHGOfUChAKUFyTZv = 1;
								return true;
							}
						}
						JbSVpFPQXHLRGNgSpSlNCFMmJamv();
						PyxNPsQOVShPPUNENdgSjWCOTFLJA = null;
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

			private void JbSVpFPQXHLRGNgSpSlNCFMmJamv()
			{
				SLXWaKtMusqgCHGOfUChAKUFyTZv = -1;
				if (PyxNPsQOVShPPUNENdgSjWCOTFLJA != null)
				{
					PyxNPsQOVShPPUNENdgSjWCOTFLJA.Dispose();
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
				iyTEIBBiFUNFIoKKuJdOTJBIIgBG iyTEIBBiFUNFIoKKuJdOTJBIIgBG2;
				if (SLXWaKtMusqgCHGOfUChAKUFyTZv == -2 && qpJwqGOiBrXNaxCPOjjXyEYOWkhF == Environment.CurrentManagedThreadId)
				{
					SLXWaKtMusqgCHGOfUChAKUFyTZv = 0;
					iyTEIBBiFUNFIoKKuJdOTJBIIgBG2 = this;
				}
				else
				{
					iyTEIBBiFUNFIoKKuJdOTJBIIgBG2 = new iyTEIBBiFUNFIoKKuJdOTJBIIgBG(0);
					iyTEIBBiFUNFIoKKuJdOTJBIIgBG2.MVyOsEBZMQqzUWWuHdmlYEZwNrep = MVyOsEBZMQqzUWWuHdmlYEZwNrep;
				}
				iyTEIBBiFUNFIoKKuJdOTJBIIgBG2.vKSmtLQYfEsoupgGfayNyxgyssRK = dHcIgjGaKeMqLTMwhdpJCdTRrfMx;
				iyTEIBBiFUNFIoKKuJdOTJBIIgBG2.lfUoLoDtwKpBxjnIgtWupoXUajOi = BSDfrLuuwxARayspBKTnNpVqCSPFA;
				return iyTEIBBiFUNFIoKKuJdOTJBIIgBG2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class LzxBSRMUwSDfebMSpyXfDLpmtpHSA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int MpSUpAuJIcklTHbmhFERkrQpyoFbA;

			private InputAction XCGQNzkVTHfeiabowscMsuaSvYJT;

			private int WIVeaHhUmZQiYVCGGOTHAZsjstmQA;

			public UserData FoTshbxtfUGhbDsimqnpJeUQBhceA;

			private string QpXmECMkgCOAZQzDLluhsQqjQoIy;

			public string cbTcwqOvkLVZhWnSfdkiFaeEfLNm;

			private bool zOBhLjwdssiATojENzEVBuDhnpjW;

			public bool SdEQUfZaavKaDeDzbbnvugjaGoNj;

			private InputCategory WGheHArtZXbeYJGVXpXPDTLtwaEiA;

			private IEnumerator<int> pXsWMYODEMXJBOiCqRvpDsdFfwFr;

			private int mgKWGmcGBauhGUCcpEglguxCYlNZ;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return XCGQNzkVTHfeiabowscMsuaSvYJT;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return XCGQNzkVTHfeiabowscMsuaSvYJT;
				}
			}

			[DebuggerHidden]
			public LzxBSRMUwSDfebMSpyXfDLpmtpHSA(int P_0)
			{
				MpSUpAuJIcklTHbmhFERkrQpyoFbA = P_0;
				WIVeaHhUmZQiYVCGGOTHAZsjstmQA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int mpSUpAuJIcklTHbmhFERkrQpyoFbA = MpSUpAuJIcklTHbmhFERkrQpyoFbA;
				if (mpSUpAuJIcklTHbmhFERkrQpyoFbA == -3 || mpSUpAuJIcklTHbmhFERkrQpyoFbA == 1)
				{
					try
					{
					}
					finally
					{
						ndtnbCitxvdoAdJHBdkvKwZueMtC();
					}
				}
				WGheHArtZXbeYJGVXpXPDTLtwaEiA = null;
				pXsWMYODEMXJBOiCqRvpDsdFfwFr = null;
				MpSUpAuJIcklTHbmhFERkrQpyoFbA = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int mpSUpAuJIcklTHbmhFERkrQpyoFbA = MpSUpAuJIcklTHbmhFERkrQpyoFbA;
					UserData foTshbxtfUGhbDsimqnpJeUQBhceA = FoTshbxtfUGhbDsimqnpJeUQBhceA;
					switch (mpSUpAuJIcklTHbmhFERkrQpyoFbA)
					{
					default:
						return false;
					case 0:
					{
						MpSUpAuJIcklTHbmhFERkrQpyoFbA = -1;
						if (foTshbxtfUGhbDsimqnpJeUQBhceA.rXMIXmZVqgXfOWciWmGdzMuYaZcG == null || foTshbxtfUGhbDsimqnpJeUQBhceA.actionCategories == null)
						{
							return false;
						}
						if (QpXmECMkgCOAZQzDLluhsQqjQoIy == null || QpXmECMkgCOAZQzDLluhsQqjQoIy == string.Empty)
						{
							return false;
						}
						int num = foTshbxtfUGhbDsimqnpJeUQBhceA.IndexOfActionCategory(QpXmECMkgCOAZQzDLluhsQqjQoIy);
						if (num < 0)
						{
							return false;
						}
						WGheHArtZXbeYJGVXpXPDTLtwaEiA = foTshbxtfUGhbDsimqnpJeUQBhceA.GetActionCategory(num);
						if (zOBhLjwdssiATojENzEVBuDhnpjW)
						{
							pXsWMYODEMXJBOiCqRvpDsdFfwFr = foTshbxtfUGhbDsimqnpJeUQBhceA.SortedActionIdsInCategory(WGheHArtZXbeYJGVXpXPDTLtwaEiA.id).GetEnumerator();
							MpSUpAuJIcklTHbmhFERkrQpyoFbA = -3;
							goto IL_00f2;
						}
						mgKWGmcGBauhGUCcpEglguxCYlNZ = 0;
						goto IL_0175;
					}
					case 1:
						MpSUpAuJIcklTHbmhFERkrQpyoFbA = -3;
						goto IL_00f2;
					case 2:
						{
							MpSUpAuJIcklTHbmhFERkrQpyoFbA = -1;
							goto IL_0163;
						}
						IL_0175:
						if (mgKWGmcGBauhGUCcpEglguxCYlNZ >= foTshbxtfUGhbDsimqnpJeUQBhceA.rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count)
						{
							break;
						}
						if (foTshbxtfUGhbDsimqnpJeUQBhceA.rXMIXmZVqgXfOWciWmGdzMuYaZcG[mgKWGmcGBauhGUCcpEglguxCYlNZ].categoryId == WGheHArtZXbeYJGVXpXPDTLtwaEiA.id)
						{
							XCGQNzkVTHfeiabowscMsuaSvYJT = foTshbxtfUGhbDsimqnpJeUQBhceA.rXMIXmZVqgXfOWciWmGdzMuYaZcG[mgKWGmcGBauhGUCcpEglguxCYlNZ];
							MpSUpAuJIcklTHbmhFERkrQpyoFbA = 2;
							return true;
						}
						goto IL_0163;
						IL_00f2:
						while (pXsWMYODEMXJBOiCqRvpDsdFfwFr.MoveNext())
						{
							int current = pXsWMYODEMXJBOiCqRvpDsdFfwFr.Current;
							InputAction actionById = foTshbxtfUGhbDsimqnpJeUQBhceA.GetActionById(current);
							if (actionById != null)
							{
								XCGQNzkVTHfeiabowscMsuaSvYJT = actionById;
								MpSUpAuJIcklTHbmhFERkrQpyoFbA = 1;
								return true;
							}
						}
						ndtnbCitxvdoAdJHBdkvKwZueMtC();
						pXsWMYODEMXJBOiCqRvpDsdFfwFr = null;
						break;
						IL_0163:
						mgKWGmcGBauhGUCcpEglguxCYlNZ++;
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

			private void ndtnbCitxvdoAdJHBdkvKwZueMtC()
			{
				MpSUpAuJIcklTHbmhFERkrQpyoFbA = -1;
				if (pXsWMYODEMXJBOiCqRvpDsdFfwFr != null)
				{
					pXsWMYODEMXJBOiCqRvpDsdFfwFr.Dispose();
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
				LzxBSRMUwSDfebMSpyXfDLpmtpHSA lzxBSRMUwSDfebMSpyXfDLpmtpHSA;
				if (MpSUpAuJIcklTHbmhFERkrQpyoFbA == -2 && WIVeaHhUmZQiYVCGGOTHAZsjstmQA == Environment.CurrentManagedThreadId)
				{
					MpSUpAuJIcklTHbmhFERkrQpyoFbA = 0;
					lzxBSRMUwSDfebMSpyXfDLpmtpHSA = this;
				}
				else
				{
					lzxBSRMUwSDfebMSpyXfDLpmtpHSA = new LzxBSRMUwSDfebMSpyXfDLpmtpHSA(0);
					lzxBSRMUwSDfebMSpyXfDLpmtpHSA.FoTshbxtfUGhbDsimqnpJeUQBhceA = FoTshbxtfUGhbDsimqnpJeUQBhceA;
				}
				lzxBSRMUwSDfebMSpyXfDLpmtpHSA.QpXmECMkgCOAZQzDLluhsQqjQoIy = cbTcwqOvkLVZhWnSfdkiFaeEfLNm;
				lzxBSRMUwSDfebMSpyXfDLpmtpHSA.zOBhLjwdssiATojENzEVBuDhnpjW = SdEQUfZaavKaDeDzbbnvugjaGoNj;
				return lzxBSRMUwSDfebMSpyXfDLpmtpHSA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class qIgBbuXAxSFkRuWKtNoXfVnATYBr : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int NbunnDvxUyxzjAmbpfskXpHFPRfK;

			private InputMapCategory juuDLvAzyvMhbzrByrZLFirMJLgA;

			private int AubldjBAiODvNIiJcKRzmobURvHq;

			private string fGvsRMVQIhfilMCfWQKrIHkoZLhO;

			public string WYytVwBRgesdjGbUckcxkfkERcyw;

			public UserData QrDbwzvfIrHAMhHSriEdJQhgRXPP;

			private int UQPfGynLzWCOwpCXAUPvCgBVsHYA;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return juuDLvAzyvMhbzrByrZLFirMJLgA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return juuDLvAzyvMhbzrByrZLFirMJLgA;
				}
			}

			[DebuggerHidden]
			public qIgBbuXAxSFkRuWKtNoXfVnATYBr(int P_0)
			{
				NbunnDvxUyxzjAmbpfskXpHFPRfK = P_0;
				AubldjBAiODvNIiJcKRzmobURvHq = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				NbunnDvxUyxzjAmbpfskXpHFPRfK = -2;
			}

			private bool MoveNext()
			{
				int nbunnDvxUyxzjAmbpfskXpHFPRfK = NbunnDvxUyxzjAmbpfskXpHFPRfK;
				UserData qrDbwzvfIrHAMhHSriEdJQhgRXPP = QrDbwzvfIrHAMhHSriEdJQhgRXPP;
				if (nbunnDvxUyxzjAmbpfskXpHFPRfK != 0)
				{
					if (nbunnDvxUyxzjAmbpfskXpHFPRfK != 1)
					{
						return false;
					}
					NbunnDvxUyxzjAmbpfskXpHFPRfK = -1;
					goto IL_0098;
				}
				NbunnDvxUyxzjAmbpfskXpHFPRfK = -1;
				if (fGvsRMVQIhfilMCfWQKrIHkoZLhO == null || fGvsRMVQIhfilMCfWQKrIHkoZLhO == string.Empty)
				{
					return false;
				}
				if (qrDbwzvfIrHAMhHSriEdJQhgRXPP.mapCategories == null)
				{
					return false;
				}
				UQPfGynLzWCOwpCXAUPvCgBVsHYA = 0;
				goto IL_00a8;
				IL_00a8:
				if (UQPfGynLzWCOwpCXAUPvCgBVsHYA < qrDbwzvfIrHAMhHSriEdJQhgRXPP.mapCategories.Count)
				{
					if (qrDbwzvfIrHAMhHSriEdJQhgRXPP.mapCategories[UQPfGynLzWCOwpCXAUPvCgBVsHYA].tag.Equals(fGvsRMVQIhfilMCfWQKrIHkoZLhO, StringComparison.OrdinalIgnoreCase))
					{
						juuDLvAzyvMhbzrByrZLFirMJLgA = qrDbwzvfIrHAMhHSriEdJQhgRXPP.mapCategories[UQPfGynLzWCOwpCXAUPvCgBVsHYA];
						NbunnDvxUyxzjAmbpfskXpHFPRfK = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				UQPfGynLzWCOwpCXAUPvCgBVsHYA++;
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
				qIgBbuXAxSFkRuWKtNoXfVnATYBr qIgBbuXAxSFkRuWKtNoXfVnATYBr2;
				if (NbunnDvxUyxzjAmbpfskXpHFPRfK == -2 && AubldjBAiODvNIiJcKRzmobURvHq == Environment.CurrentManagedThreadId)
				{
					NbunnDvxUyxzjAmbpfskXpHFPRfK = 0;
					qIgBbuXAxSFkRuWKtNoXfVnATYBr2 = this;
				}
				else
				{
					qIgBbuXAxSFkRuWKtNoXfVnATYBr2 = new qIgBbuXAxSFkRuWKtNoXfVnATYBr(0);
					qIgBbuXAxSFkRuWKtNoXfVnATYBr2.QrDbwzvfIrHAMhHSriEdJQhgRXPP = QrDbwzvfIrHAMhHSriEdJQhgRXPP;
				}
				qIgBbuXAxSFkRuWKtNoXfVnATYBr2.fGvsRMVQIhfilMCfWQKrIHkoZLhO = WYytVwBRgesdjGbUckcxkfkERcyw;
				return qIgBbuXAxSFkRuWKtNoXfVnATYBr2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class XKzEclkPwbXuwhXaMFseCELrtgfX : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int oQxWtvgxIhSqvgVMIqTkwZWSAGKO;

			private string eiGRrGlNfNXjTVSZVGJRWuiQdcrr;

			private int KIZozJjcucNidgDuKjNVXRcVejjv;

			public UserData sxaiAAiqzmTuncyOAeisvsUYjFWy;

			private int EzRblMsHKGcPSclQnwQXihOKitESA;

			public int ieegMNtduUhOxRNWaIErfruJJTBE;

			private IEnumerator<int> kLhBtnmVhHxsrGQaaTqCUOEIlxLt;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return eiGRrGlNfNXjTVSZVGJRWuiQdcrr;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return eiGRrGlNfNXjTVSZVGJRWuiQdcrr;
				}
			}

			[DebuggerHidden]
			public XKzEclkPwbXuwhXaMFseCELrtgfX(int P_0)
			{
				oQxWtvgxIhSqvgVMIqTkwZWSAGKO = P_0;
				KIZozJjcucNidgDuKjNVXRcVejjv = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = oQxWtvgxIhSqvgVMIqTkwZWSAGKO;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						mYFqVKXrHopdDFTAoLcjEuBMHwPm();
					}
				}
				kLhBtnmVhHxsrGQaaTqCUOEIlxLt = null;
				oQxWtvgxIhSqvgVMIqTkwZWSAGKO = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = oQxWtvgxIhSqvgVMIqTkwZWSAGKO;
					UserData userData = sxaiAAiqzmTuncyOAeisvsUYjFWy;
					switch (num)
					{
					default:
						return false;
					case 0:
						oQxWtvgxIhSqvgVMIqTkwZWSAGKO = -1;
						if (userData.actionCategories == null || userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
						{
							return false;
						}
						kLhBtnmVhHxsrGQaaTqCUOEIlxLt = userData.actionCategoryMap.ActionIdsInCategory(EzRblMsHKGcPSclQnwQXihOKitESA).GetEnumerator();
						oQxWtvgxIhSqvgVMIqTkwZWSAGKO = -3;
						break;
					case 1:
						oQxWtvgxIhSqvgVMIqTkwZWSAGKO = -3;
						break;
					}
					while (kLhBtnmVhHxsrGQaaTqCUOEIlxLt.MoveNext())
					{
						int current = kLhBtnmVhHxsrGQaaTqCUOEIlxLt.Current;
						InputAction actionById = userData.GetActionById(current);
						if (actionById != null)
						{
							eiGRrGlNfNXjTVSZVGJRWuiQdcrr = actionById.descriptiveName;
							oQxWtvgxIhSqvgVMIqTkwZWSAGKO = 1;
							return true;
						}
					}
					mYFqVKXrHopdDFTAoLcjEuBMHwPm();
					kLhBtnmVhHxsrGQaaTqCUOEIlxLt = null;
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

			private void mYFqVKXrHopdDFTAoLcjEuBMHwPm()
			{
				oQxWtvgxIhSqvgVMIqTkwZWSAGKO = -1;
				if (kLhBtnmVhHxsrGQaaTqCUOEIlxLt != null)
				{
					kLhBtnmVhHxsrGQaaTqCUOEIlxLt.Dispose();
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
				XKzEclkPwbXuwhXaMFseCELrtgfX xKzEclkPwbXuwhXaMFseCELrtgfX;
				if (oQxWtvgxIhSqvgVMIqTkwZWSAGKO == -2 && KIZozJjcucNidgDuKjNVXRcVejjv == Environment.CurrentManagedThreadId)
				{
					oQxWtvgxIhSqvgVMIqTkwZWSAGKO = 0;
					xKzEclkPwbXuwhXaMFseCELrtgfX = this;
				}
				else
				{
					xKzEclkPwbXuwhXaMFseCELrtgfX = new XKzEclkPwbXuwhXaMFseCELrtgfX(0);
					xKzEclkPwbXuwhXaMFseCELrtgfX.sxaiAAiqzmTuncyOAeisvsUYjFWy = sxaiAAiqzmTuncyOAeisvsUYjFWy;
				}
				xKzEclkPwbXuwhXaMFseCELrtgfX.EzRblMsHKGcPSclQnwQXihOKitESA = ieegMNtduUhOxRNWaIErfruJJTBE;
				return xKzEclkPwbXuwhXaMFseCELrtgfX;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class VGdgQXDjvSUgwSFdpPNVFuiCXyddb : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int QVGEVodRgDZenBRVMbjqwHfaCqwM;

			private int JaVEfxsXyFuPxztfLvxjewHvaAtj;

			private int QZBbVEdEkIixdERCYfnwcntZFaxib;

			public UserData sjWBYggFuPajWITaAdgkKFHDAVfgc;

			private int ZDMIPaswyELUHPrYqGNYzLvYfpii;

			public int pRtijaUjTRgnGBxxYUiWYezibOzT;

			private IEnumerator<int> IVzfVYcGcVyVTdkIIzAdnDTvGNjJA;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return JaVEfxsXyFuPxztfLvxjewHvaAtj;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JaVEfxsXyFuPxztfLvxjewHvaAtj;
				}
			}

			[DebuggerHidden]
			public VGdgQXDjvSUgwSFdpPNVFuiCXyddb(int P_0)
			{
				QVGEVodRgDZenBRVMbjqwHfaCqwM = P_0;
				QZBbVEdEkIixdERCYfnwcntZFaxib = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int qVGEVodRgDZenBRVMbjqwHfaCqwM = QVGEVodRgDZenBRVMbjqwHfaCqwM;
				if (qVGEVodRgDZenBRVMbjqwHfaCqwM == -3 || qVGEVodRgDZenBRVMbjqwHfaCqwM == 1)
				{
					try
					{
					}
					finally
					{
						baPWCMuELCWxPlKGIQFaIIxAbaGQ();
					}
				}
				IVzfVYcGcVyVTdkIIzAdnDTvGNjJA = null;
				QVGEVodRgDZenBRVMbjqwHfaCqwM = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int qVGEVodRgDZenBRVMbjqwHfaCqwM = QVGEVodRgDZenBRVMbjqwHfaCqwM;
					UserData userData = sjWBYggFuPajWITaAdgkKFHDAVfgc;
					switch (qVGEVodRgDZenBRVMbjqwHfaCqwM)
					{
					default:
						return false;
					case 0:
						QVGEVodRgDZenBRVMbjqwHfaCqwM = -1;
						if (userData.actionCategories == null || userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
						{
							return false;
						}
						IVzfVYcGcVyVTdkIIzAdnDTvGNjJA = userData.actionCategoryMap.ActionIdsInCategory(ZDMIPaswyELUHPrYqGNYzLvYfpii).GetEnumerator();
						QVGEVodRgDZenBRVMbjqwHfaCqwM = -3;
						break;
					case 1:
						QVGEVodRgDZenBRVMbjqwHfaCqwM = -3;
						break;
					}
					if (IVzfVYcGcVyVTdkIIzAdnDTvGNjJA.MoveNext())
					{
						int current = IVzfVYcGcVyVTdkIIzAdnDTvGNjJA.Current;
						JaVEfxsXyFuPxztfLvxjewHvaAtj = current;
						QVGEVodRgDZenBRVMbjqwHfaCqwM = 1;
						return true;
					}
					baPWCMuELCWxPlKGIQFaIIxAbaGQ();
					IVzfVYcGcVyVTdkIIzAdnDTvGNjJA = null;
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

			private void baPWCMuELCWxPlKGIQFaIIxAbaGQ()
			{
				QVGEVodRgDZenBRVMbjqwHfaCqwM = -1;
				if (IVzfVYcGcVyVTdkIIzAdnDTvGNjJA != null)
				{
					IVzfVYcGcVyVTdkIIzAdnDTvGNjJA.Dispose();
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
				VGdgQXDjvSUgwSFdpPNVFuiCXyddb vGdgQXDjvSUgwSFdpPNVFuiCXyddb;
				if (QVGEVodRgDZenBRVMbjqwHfaCqwM == -2 && QZBbVEdEkIixdERCYfnwcntZFaxib == Environment.CurrentManagedThreadId)
				{
					QVGEVodRgDZenBRVMbjqwHfaCqwM = 0;
					vGdgQXDjvSUgwSFdpPNVFuiCXyddb = this;
				}
				else
				{
					vGdgQXDjvSUgwSFdpPNVFuiCXyddb = new VGdgQXDjvSUgwSFdpPNVFuiCXyddb(0);
					vGdgQXDjvSUgwSFdpPNVFuiCXyddb.sjWBYggFuPajWITaAdgkKFHDAVfgc = sjWBYggFuPajWITaAdgkKFHDAVfgc;
				}
				vGdgQXDjvSUgwSFdpPNVFuiCXyddb.ZDMIPaswyELUHPrYqGNYzLvYfpii = pRtijaUjTRgnGBxxYUiWYezibOzT;
				return vGdgQXDjvSUgwSFdpPNVFuiCXyddb;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		private sealed class FGabuJpItvlZRwCBJyFcsYjNuBIR : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int fKimjIianbqziPpYXtsjnwMgXcGi;

			private string aWudmvgdjQZiIKQsiKXXdRFxGKYTA;

			private int MGKHQIlKPXEEgQUnOGHzHowkWXAtA;

			public UserData XgNBZtghJShXLQhUdyOiLeTjOnkgb;

			private int CPcALKWnBVEEHfmfTRodIgmAaiVOb;

			public int zmZFVoiFOqIMXgrfPTEJkIWdptkvA;

			private IEnumerator<int> mjaekWJqKloiSEKDjMsFisAZUHUn;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return aWudmvgdjQZiIKQsiKXXdRFxGKYTA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aWudmvgdjQZiIKQsiKXXdRFxGKYTA;
				}
			}

			[DebuggerHidden]
			public FGabuJpItvlZRwCBJyFcsYjNuBIR(int P_0)
			{
				fKimjIianbqziPpYXtsjnwMgXcGi = P_0;
				MGKHQIlKPXEEgQUnOGHzHowkWXAtA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = fKimjIianbqziPpYXtsjnwMgXcGi;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						TSHEJueYpZzPiWAjkVeDuHrlGfbf();
					}
				}
				mjaekWJqKloiSEKDjMsFisAZUHUn = null;
				fKimjIianbqziPpYXtsjnwMgXcGi = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = fKimjIianbqziPpYXtsjnwMgXcGi;
					UserData xgNBZtghJShXLQhUdyOiLeTjOnkgb = XgNBZtghJShXLQhUdyOiLeTjOnkgb;
					switch (num)
					{
					default:
						return false;
					case 0:
						fKimjIianbqziPpYXtsjnwMgXcGi = -1;
						if (xgNBZtghJShXLQhUdyOiLeTjOnkgb.actionCategories == null || xgNBZtghJShXLQhUdyOiLeTjOnkgb.rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
						{
							return false;
						}
						mjaekWJqKloiSEKDjMsFisAZUHUn = xgNBZtghJShXLQhUdyOiLeTjOnkgb.actionCategoryMap.ActionIdsInCategory(CPcALKWnBVEEHfmfTRodIgmAaiVOb).GetEnumerator();
						fKimjIianbqziPpYXtsjnwMgXcGi = -3;
						break;
					case 1:
						fKimjIianbqziPpYXtsjnwMgXcGi = -3;
						break;
					}
					while (mjaekWJqKloiSEKDjMsFisAZUHUn.MoveNext())
					{
						int current = mjaekWJqKloiSEKDjMsFisAZUHUn.Current;
						InputAction actionById = xgNBZtghJShXLQhUdyOiLeTjOnkgb.GetActionById(current);
						if (actionById != null)
						{
							aWudmvgdjQZiIKQsiKXXdRFxGKYTA = actionById.name;
							fKimjIianbqziPpYXtsjnwMgXcGi = 1;
							return true;
						}
					}
					TSHEJueYpZzPiWAjkVeDuHrlGfbf();
					mjaekWJqKloiSEKDjMsFisAZUHUn = null;
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

			private void TSHEJueYpZzPiWAjkVeDuHrlGfbf()
			{
				fKimjIianbqziPpYXtsjnwMgXcGi = -1;
				if (mjaekWJqKloiSEKDjMsFisAZUHUn != null)
				{
					mjaekWJqKloiSEKDjMsFisAZUHUn.Dispose();
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
				FGabuJpItvlZRwCBJyFcsYjNuBIR fGabuJpItvlZRwCBJyFcsYjNuBIR;
				if (fKimjIianbqziPpYXtsjnwMgXcGi == -2 && MGKHQIlKPXEEgQUnOGHzHowkWXAtA == Environment.CurrentManagedThreadId)
				{
					fKimjIianbqziPpYXtsjnwMgXcGi = 0;
					fGabuJpItvlZRwCBJyFcsYjNuBIR = this;
				}
				else
				{
					fGabuJpItvlZRwCBJyFcsYjNuBIR = new FGabuJpItvlZRwCBJyFcsYjNuBIR(0);
					fGabuJpItvlZRwCBJyFcsYjNuBIR.XgNBZtghJShXLQhUdyOiLeTjOnkgb = XgNBZtghJShXLQhUdyOiLeTjOnkgb;
				}
				fGabuJpItvlZRwCBJyFcsYjNuBIR.CPcALKWnBVEEHfmfTRodIgmAaiVOb = zmZFVoiFOqIMXgrfPTEJkIWdptkvA;
				return fGabuJpItvlZRwCBJyFcsYjNuBIR;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class loLCMBlYdEZuMBiVWLyHKqMfiPVg : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int EGFYweMIbLpGTFcNjtoaUGoItZIK;

			private InputCategory jeFEDHFVWpevISKSyKshRJRTfpDl;

			private int XpAQoRBlLKfeQHTcVCOKKTTfXhWFA;

			private string qGViNYHDAHpQGFnYSaozAtlQkmMab;

			public string AJbGKJHCvsZNsBSUJcWmTwasKjpP;

			public UserData MnsCugTOJMLkOtsrCRuTQFtDiVHl;

			private int MYgHRueNSJzEZnmKmmaHbWnoDqjP;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return jeFEDHFVWpevISKSyKshRJRTfpDl;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return jeFEDHFVWpevISKSyKshRJRTfpDl;
				}
			}

			[DebuggerHidden]
			public loLCMBlYdEZuMBiVWLyHKqMfiPVg(int P_0)
			{
				EGFYweMIbLpGTFcNjtoaUGoItZIK = P_0;
				XpAQoRBlLKfeQHTcVCOKKTTfXhWFA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				EGFYweMIbLpGTFcNjtoaUGoItZIK = -2;
			}

			private bool MoveNext()
			{
				int eGFYweMIbLpGTFcNjtoaUGoItZIK = EGFYweMIbLpGTFcNjtoaUGoItZIK;
				UserData mnsCugTOJMLkOtsrCRuTQFtDiVHl = MnsCugTOJMLkOtsrCRuTQFtDiVHl;
				if (eGFYweMIbLpGTFcNjtoaUGoItZIK != 0)
				{
					if (eGFYweMIbLpGTFcNjtoaUGoItZIK != 1)
					{
						return false;
					}
					EGFYweMIbLpGTFcNjtoaUGoItZIK = -1;
					goto IL_00b3;
				}
				EGFYweMIbLpGTFcNjtoaUGoItZIK = -1;
				if (qGViNYHDAHpQGFnYSaozAtlQkmMab == null || qGViNYHDAHpQGFnYSaozAtlQkmMab == string.Empty)
				{
					return false;
				}
				if (mnsCugTOJMLkOtsrCRuTQFtDiVHl.actionCategories == null)
				{
					return false;
				}
				MYgHRueNSJzEZnmKmmaHbWnoDqjP = 0;
				goto IL_00c3;
				IL_00c3:
				if (MYgHRueNSJzEZnmKmmaHbWnoDqjP < mnsCugTOJMLkOtsrCRuTQFtDiVHl.actionCategories.Count)
				{
					if (mnsCugTOJMLkOtsrCRuTQFtDiVHl.actionCategories[MYgHRueNSJzEZnmKmmaHbWnoDqjP].userAssignable && mnsCugTOJMLkOtsrCRuTQFtDiVHl.actionCategories[MYgHRueNSJzEZnmKmmaHbWnoDqjP].tag.Equals(qGViNYHDAHpQGFnYSaozAtlQkmMab, StringComparison.OrdinalIgnoreCase))
					{
						jeFEDHFVWpevISKSyKshRJRTfpDl = mnsCugTOJMLkOtsrCRuTQFtDiVHl.actionCategories[MYgHRueNSJzEZnmKmmaHbWnoDqjP];
						EGFYweMIbLpGTFcNjtoaUGoItZIK = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				MYgHRueNSJzEZnmKmmaHbWnoDqjP++;
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
				loLCMBlYdEZuMBiVWLyHKqMfiPVg loLCMBlYdEZuMBiVWLyHKqMfiPVg2;
				if (EGFYweMIbLpGTFcNjtoaUGoItZIK == -2 && XpAQoRBlLKfeQHTcVCOKKTTfXhWFA == Environment.CurrentManagedThreadId)
				{
					EGFYweMIbLpGTFcNjtoaUGoItZIK = 0;
					loLCMBlYdEZuMBiVWLyHKqMfiPVg2 = this;
				}
				else
				{
					loLCMBlYdEZuMBiVWLyHKqMfiPVg2 = new loLCMBlYdEZuMBiVWLyHKqMfiPVg(0);
					loLCMBlYdEZuMBiVWLyHKqMfiPVg2.MnsCugTOJMLkOtsrCRuTQFtDiVHl = MnsCugTOJMLkOtsrCRuTQFtDiVHl;
				}
				loLCMBlYdEZuMBiVWLyHKqMfiPVg2.qGViNYHDAHpQGFnYSaozAtlQkmMab = AJbGKJHCvsZNsBSUJcWmTwasKjpP;
				return loLCMBlYdEZuMBiVWLyHKqMfiPVg2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class CpiLZvSdywuZZINlhaQCHzSrShKp : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int fozDASBjFGmTTnnUferzdSwWDLkuA;

			private InputAction SemkUvoIPiTOXFrZCJQIjOJCBWodA;

			private int PHQtBdYVmjTsvkHCXdwmvDRrEiQdA;

			public UserData psVkpdRiQxMOANEHYQbEmqrczwpT;

			private int EhOUrRfMWZEVPdVZXCrqlxCiOMLHA;

			public int KuJtaxihTMhnqKDcfXvYbuKRfMkb;

			private bool GIPMGDhhmdsrUruVUPGHIzYEciMr;

			public bool aHqsODlowZpsMCbcRNqWYGqiByOf;

			private InputCategory yrsPPDyqoVbFpGTGcBdTpLPDnkgNA;

			private IEnumerator<int> UBqxymbvKNpLcLOCjEPLljECqYQm;

			private int gANDePCbNEhBcbKuAOEODfzCoVjCc;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return SemkUvoIPiTOXFrZCJQIjOJCBWodA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return SemkUvoIPiTOXFrZCJQIjOJCBWodA;
				}
			}

			[DebuggerHidden]
			public CpiLZvSdywuZZINlhaQCHzSrShKp(int P_0)
			{
				fozDASBjFGmTTnnUferzdSwWDLkuA = P_0;
				PHQtBdYVmjTsvkHCXdwmvDRrEiQdA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = fozDASBjFGmTTnnUferzdSwWDLkuA;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						KlfMFGufvMdmYFOuHOUvkxnldchI();
					}
				}
				yrsPPDyqoVbFpGTGcBdTpLPDnkgNA = null;
				UBqxymbvKNpLcLOCjEPLljECqYQm = null;
				fozDASBjFGmTTnnUferzdSwWDLkuA = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = fozDASBjFGmTTnnUferzdSwWDLkuA;
					UserData userData = psVkpdRiQxMOANEHYQbEmqrczwpT;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						fozDASBjFGmTTnnUferzdSwWDLkuA = -1;
						if (userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG == null || userData.actionCategories == null)
						{
							return false;
						}
						yrsPPDyqoVbFpGTGcBdTpLPDnkgNA = userData.GetActionCategoryById(EhOUrRfMWZEVPdVZXCrqlxCiOMLHA);
						if (yrsPPDyqoVbFpGTGcBdTpLPDnkgNA == null || !yrsPPDyqoVbFpGTGcBdTpLPDnkgNA.userAssignable)
						{
							return false;
						}
						if (GIPMGDhhmdsrUruVUPGHIzYEciMr)
						{
							UBqxymbvKNpLcLOCjEPLljECqYQm = userData.SortedActionIdsInCategory(yrsPPDyqoVbFpGTGcBdTpLPDnkgNA.id).GetEnumerator();
							fozDASBjFGmTTnnUferzdSwWDLkuA = -3;
							goto IL_00e4;
						}
						gANDePCbNEhBcbKuAOEODfzCoVjCc = 0;
						goto IL_0165;
					case 1:
						fozDASBjFGmTTnnUferzdSwWDLkuA = -3;
						goto IL_00e4;
					case 2:
						{
							fozDASBjFGmTTnnUferzdSwWDLkuA = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (UBqxymbvKNpLcLOCjEPLljECqYQm.MoveNext())
						{
							int current = UBqxymbvKNpLcLOCjEPLljECqYQm.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								SemkUvoIPiTOXFrZCJQIjOJCBWodA = actionById;
								fozDASBjFGmTTnnUferzdSwWDLkuA = 1;
								return true;
							}
						}
						KlfMFGufvMdmYFOuHOUvkxnldchI();
						UBqxymbvKNpLcLOCjEPLljECqYQm = null;
						break;
						IL_0153:
						gANDePCbNEhBcbKuAOEODfzCoVjCc++;
						goto IL_0165;
						IL_0165:
						if (gANDePCbNEhBcbKuAOEODfzCoVjCc >= userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count)
						{
							break;
						}
						inputAction = userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG[gANDePCbNEhBcbKuAOEODfzCoVjCc];
						if (inputAction.categoryId == yrsPPDyqoVbFpGTGcBdTpLPDnkgNA.id && inputAction.userAssignable)
						{
							SemkUvoIPiTOXFrZCJQIjOJCBWodA = inputAction;
							fozDASBjFGmTTnnUferzdSwWDLkuA = 2;
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

			private void KlfMFGufvMdmYFOuHOUvkxnldchI()
			{
				fozDASBjFGmTTnnUferzdSwWDLkuA = -1;
				if (UBqxymbvKNpLcLOCjEPLljECqYQm != null)
				{
					UBqxymbvKNpLcLOCjEPLljECqYQm.Dispose();
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
				CpiLZvSdywuZZINlhaQCHzSrShKp cpiLZvSdywuZZINlhaQCHzSrShKp;
				if (fozDASBjFGmTTnnUferzdSwWDLkuA == -2 && PHQtBdYVmjTsvkHCXdwmvDRrEiQdA == Environment.CurrentManagedThreadId)
				{
					fozDASBjFGmTTnnUferzdSwWDLkuA = 0;
					cpiLZvSdywuZZINlhaQCHzSrShKp = this;
				}
				else
				{
					cpiLZvSdywuZZINlhaQCHzSrShKp = new CpiLZvSdywuZZINlhaQCHzSrShKp(0);
					cpiLZvSdywuZZINlhaQCHzSrShKp.psVkpdRiQxMOANEHYQbEmqrczwpT = psVkpdRiQxMOANEHYQbEmqrczwpT;
				}
				cpiLZvSdywuZZINlhaQCHzSrShKp.EhOUrRfMWZEVPdVZXCrqlxCiOMLHA = KuJtaxihTMhnqKDcfXvYbuKRfMkb;
				cpiLZvSdywuZZINlhaQCHzSrShKp.GIPMGDhhmdsrUruVUPGHIzYEciMr = aHqsODlowZpsMCbcRNqWYGqiByOf;
				return cpiLZvSdywuZZINlhaQCHzSrShKp;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class FzqbnEHZrkVWXrRAcGsSqbaKYwhJA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int gSUVXLBdrLCDXBfRAaAacYntYcEY;

			private InputAction wZVJtIhblMmpgeIxXItQInFwOJQe;

			private int NkFKuqbPMIYvbjxkOXZnAEZehDEH;

			public UserData itbEdihuJbfhvfvomEIJHYruXvhaA;

			private string EHSfuvXBoXiIIJFRALitUpkMHVeOA;

			public string XDTQjeZKovYymfmbgtwhuqdaBoNN;

			private bool eJMgTGRRoMeJJIUdphNQRPbgjZOM;

			public bool nokAhtNPUNoSLqGsBrxFsqslJTnM;

			private InputCategory WsParDXddjmbJZLpddMWqcBiycJl;

			private IEnumerator<int> LOSBnjaEwBedmhDtkGIXXKHmahrM;

			private int fSTULIXnLUDGNIdnSVMQuMbWBnooA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return wZVJtIhblMmpgeIxXItQInFwOJQe;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wZVJtIhblMmpgeIxXItQInFwOJQe;
				}
			}

			[DebuggerHidden]
			public FzqbnEHZrkVWXrRAcGsSqbaKYwhJA(int P_0)
			{
				gSUVXLBdrLCDXBfRAaAacYntYcEY = P_0;
				NkFKuqbPMIYvbjxkOXZnAEZehDEH = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = gSUVXLBdrLCDXBfRAaAacYntYcEY;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						vWLodeGAiHbUvHcoFbfmMFxBgsApA();
					}
				}
				WsParDXddjmbJZLpddMWqcBiycJl = null;
				LOSBnjaEwBedmhDtkGIXXKHmahrM = null;
				gSUVXLBdrLCDXBfRAaAacYntYcEY = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = gSUVXLBdrLCDXBfRAaAacYntYcEY;
					UserData userData = itbEdihuJbfhvfvomEIJHYruXvhaA;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						gSUVXLBdrLCDXBfRAaAacYntYcEY = -1;
						if (userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG == null || userData.actionCategories == null)
						{
							return false;
						}
						WsParDXddjmbJZLpddMWqcBiycJl = userData.GetActionCategory(EHSfuvXBoXiIIJFRALitUpkMHVeOA);
						if (WsParDXddjmbJZLpddMWqcBiycJl == null || !WsParDXddjmbJZLpddMWqcBiycJl.userAssignable)
						{
							return false;
						}
						if (eJMgTGRRoMeJJIUdphNQRPbgjZOM)
						{
							LOSBnjaEwBedmhDtkGIXXKHmahrM = userData.SortedActionIdsInCategory(WsParDXddjmbJZLpddMWqcBiycJl.id).GetEnumerator();
							gSUVXLBdrLCDXBfRAaAacYntYcEY = -3;
							goto IL_00e4;
						}
						fSTULIXnLUDGNIdnSVMQuMbWBnooA = 0;
						goto IL_0165;
					case 1:
						gSUVXLBdrLCDXBfRAaAacYntYcEY = -3;
						goto IL_00e4;
					case 2:
						{
							gSUVXLBdrLCDXBfRAaAacYntYcEY = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (LOSBnjaEwBedmhDtkGIXXKHmahrM.MoveNext())
						{
							int current = LOSBnjaEwBedmhDtkGIXXKHmahrM.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								wZVJtIhblMmpgeIxXItQInFwOJQe = actionById;
								gSUVXLBdrLCDXBfRAaAacYntYcEY = 1;
								return true;
							}
						}
						vWLodeGAiHbUvHcoFbfmMFxBgsApA();
						LOSBnjaEwBedmhDtkGIXXKHmahrM = null;
						break;
						IL_0153:
						fSTULIXnLUDGNIdnSVMQuMbWBnooA++;
						goto IL_0165;
						IL_0165:
						if (fSTULIXnLUDGNIdnSVMQuMbWBnooA >= userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count)
						{
							break;
						}
						inputAction = userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG[fSTULIXnLUDGNIdnSVMQuMbWBnooA];
						if (inputAction.categoryId == WsParDXddjmbJZLpddMWqcBiycJl.id && inputAction.userAssignable)
						{
							wZVJtIhblMmpgeIxXItQInFwOJQe = inputAction;
							gSUVXLBdrLCDXBfRAaAacYntYcEY = 2;
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

			private void vWLodeGAiHbUvHcoFbfmMFxBgsApA()
			{
				gSUVXLBdrLCDXBfRAaAacYntYcEY = -1;
				if (LOSBnjaEwBedmhDtkGIXXKHmahrM != null)
				{
					LOSBnjaEwBedmhDtkGIXXKHmahrM.Dispose();
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
				FzqbnEHZrkVWXrRAcGsSqbaKYwhJA fzqbnEHZrkVWXrRAcGsSqbaKYwhJA;
				if (gSUVXLBdrLCDXBfRAaAacYntYcEY == -2 && NkFKuqbPMIYvbjxkOXZnAEZehDEH == Environment.CurrentManagedThreadId)
				{
					gSUVXLBdrLCDXBfRAaAacYntYcEY = 0;
					fzqbnEHZrkVWXrRAcGsSqbaKYwhJA = this;
				}
				else
				{
					fzqbnEHZrkVWXrRAcGsSqbaKYwhJA = new FzqbnEHZrkVWXrRAcGsSqbaKYwhJA(0);
					fzqbnEHZrkVWXrRAcGsSqbaKYwhJA.itbEdihuJbfhvfvomEIJHYruXvhaA = itbEdihuJbfhvfvomEIJHYruXvhaA;
				}
				fzqbnEHZrkVWXrRAcGsSqbaKYwhJA.EHSfuvXBoXiIIJFRALitUpkMHVeOA = XDTQjeZKovYymfmbgtwhuqdaBoNN;
				fzqbnEHZrkVWXrRAcGsSqbaKYwhJA.eJMgTGRRoMeJJIUdphNQRPbgjZOM = nokAhtNPUNoSLqGsBrxFsqslJTnM;
				return fzqbnEHZrkVWXrRAcGsSqbaKYwhJA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class hgRreASoKdDaVatdnFnmahbxnXToA : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int ubCcOSHxYMtXhKSbukrnIhZTaQxQ;

			private InputMapCategory wvDgrPYdrPTIhSjmPnNHMkhjFxwS;

			private int NLjOznhQOhdltRIVdKGmSmCISXhB;

			private string haXBtYkVgVstCWoicxjCJuWcGAUA;

			public string zdBxHOnDXQOApBwFdMzXSchvfCKdA;

			public UserData hAYlsRItHWwHPEhGqfJBJFlJWBoz;

			private int vXYrLOXDCYHGCyyGmMGijAkbbLhG;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return wvDgrPYdrPTIhSjmPnNHMkhjFxwS;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wvDgrPYdrPTIhSjmPnNHMkhjFxwS;
				}
			}

			[DebuggerHidden]
			public hgRreASoKdDaVatdnFnmahbxnXToA(int P_0)
			{
				ubCcOSHxYMtXhKSbukrnIhZTaQxQ = P_0;
				NLjOznhQOhdltRIVdKGmSmCISXhB = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				ubCcOSHxYMtXhKSbukrnIhZTaQxQ = -2;
			}

			private bool MoveNext()
			{
				int num = ubCcOSHxYMtXhKSbukrnIhZTaQxQ;
				UserData userData = hAYlsRItHWwHPEhGqfJBJFlJWBoz;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					ubCcOSHxYMtXhKSbukrnIhZTaQxQ = -1;
					goto IL_00b3;
				}
				ubCcOSHxYMtXhKSbukrnIhZTaQxQ = -1;
				if (haXBtYkVgVstCWoicxjCJuWcGAUA == null || haXBtYkVgVstCWoicxjCJuWcGAUA == string.Empty)
				{
					return false;
				}
				if (userData.mapCategories == null)
				{
					return false;
				}
				vXYrLOXDCYHGCyyGmMGijAkbbLhG = 0;
				goto IL_00c3;
				IL_00c3:
				if (vXYrLOXDCYHGCyyGmMGijAkbbLhG < userData.mapCategories.Count)
				{
					if (userData.mapCategories[vXYrLOXDCYHGCyyGmMGijAkbbLhG].userAssignable && userData.mapCategories[vXYrLOXDCYHGCyyGmMGijAkbbLhG].tag.Equals(haXBtYkVgVstCWoicxjCJuWcGAUA, StringComparison.OrdinalIgnoreCase))
					{
						wvDgrPYdrPTIhSjmPnNHMkhjFxwS = userData.mapCategories[vXYrLOXDCYHGCyyGmMGijAkbbLhG];
						ubCcOSHxYMtXhKSbukrnIhZTaQxQ = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				vXYrLOXDCYHGCyyGmMGijAkbbLhG++;
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
				hgRreASoKdDaVatdnFnmahbxnXToA hgRreASoKdDaVatdnFnmahbxnXToA2;
				if (ubCcOSHxYMtXhKSbukrnIhZTaQxQ == -2 && NLjOznhQOhdltRIVdKGmSmCISXhB == Environment.CurrentManagedThreadId)
				{
					ubCcOSHxYMtXhKSbukrnIhZTaQxQ = 0;
					hgRreASoKdDaVatdnFnmahbxnXToA2 = this;
				}
				else
				{
					hgRreASoKdDaVatdnFnmahbxnXToA2 = new hgRreASoKdDaVatdnFnmahbxnXToA(0);
					hgRreASoKdDaVatdnFnmahbxnXToA2.hAYlsRItHWwHPEhGqfJBJFlJWBoz = hAYlsRItHWwHPEhGqfJBJFlJWBoz;
				}
				hgRreASoKdDaVatdnFnmahbxnXToA2.haXBtYkVgVstCWoicxjCJuWcGAUA = zdBxHOnDXQOApBwFdMzXSchvfCKdA;
				return hgRreASoKdDaVatdnFnmahbxnXToA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class ObeIogCZmDazgPNKJZOKnViSTZIAA : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int zlMYobbCFnKQjyyjQCLwqOrPCwFH;

			private InputCategory tWyxuZdjFViWhqOXZPmykXdFjJwg;

			private int bCPImEzjlvFMlXrjKHgzXQSIdwOT;

			public UserData SKIdReHkVQoscbgdrbGXyRhAuCtI;

			private int FeKFQNEAKxfEjAqOecyjXqomuqmdc;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return tWyxuZdjFViWhqOXZPmykXdFjJwg;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return tWyxuZdjFViWhqOXZPmykXdFjJwg;
				}
			}

			[DebuggerHidden]
			public ObeIogCZmDazgPNKJZOKnViSTZIAA(int P_0)
			{
				zlMYobbCFnKQjyyjQCLwqOrPCwFH = P_0;
				bCPImEzjlvFMlXrjKHgzXQSIdwOT = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				zlMYobbCFnKQjyyjQCLwqOrPCwFH = -2;
			}

			private bool MoveNext()
			{
				int num = zlMYobbCFnKQjyyjQCLwqOrPCwFH;
				UserData sKIdReHkVQoscbgdrbGXyRhAuCtI = SKIdReHkVQoscbgdrbGXyRhAuCtI;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					zlMYobbCFnKQjyyjQCLwqOrPCwFH = -1;
					goto IL_0070;
				}
				zlMYobbCFnKQjyyjQCLwqOrPCwFH = -1;
				if (sKIdReHkVQoscbgdrbGXyRhAuCtI.actionCategories == null)
				{
					return false;
				}
				FeKFQNEAKxfEjAqOecyjXqomuqmdc = 0;
				goto IL_0080;
				IL_0080:
				if (FeKFQNEAKxfEjAqOecyjXqomuqmdc < sKIdReHkVQoscbgdrbGXyRhAuCtI.actionCategories.Count)
				{
					if (sKIdReHkVQoscbgdrbGXyRhAuCtI.actionCategories[FeKFQNEAKxfEjAqOecyjXqomuqmdc].userAssignable)
					{
						tWyxuZdjFViWhqOXZPmykXdFjJwg = sKIdReHkVQoscbgdrbGXyRhAuCtI.actionCategories[FeKFQNEAKxfEjAqOecyjXqomuqmdc];
						zlMYobbCFnKQjyyjQCLwqOrPCwFH = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				FeKFQNEAKxfEjAqOecyjXqomuqmdc++;
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
				ObeIogCZmDazgPNKJZOKnViSTZIAA obeIogCZmDazgPNKJZOKnViSTZIAA;
				if (zlMYobbCFnKQjyyjQCLwqOrPCwFH == -2 && bCPImEzjlvFMlXrjKHgzXQSIdwOT == Environment.CurrentManagedThreadId)
				{
					zlMYobbCFnKQjyyjQCLwqOrPCwFH = 0;
					obeIogCZmDazgPNKJZOKnViSTZIAA = this;
				}
				else
				{
					obeIogCZmDazgPNKJZOKnViSTZIAA = new ObeIogCZmDazgPNKJZOKnViSTZIAA(0);
					obeIogCZmDazgPNKJZOKnViSTZIAA.SKIdReHkVQoscbgdrbGXyRhAuCtI = SKIdReHkVQoscbgdrbGXyRhAuCtI;
				}
				return obeIogCZmDazgPNKJZOKnViSTZIAA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class dqKblzFmMiWFqhADvjYWVDMDtqC : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int nnUHfYyDpSGZumoPHJGnjarQhCic;

			private InputAction QcadnEifCRfURdskcfgdSKDEIFnxB;

			private int kLgbXxLCWuAYOYXQcdJgFTXFvcPaA;

			public UserData mYgdRsSDAUBmgCrljAwtgrYGllIKA;

			private int kOuEbUlibTAtCahwAFOxSlKFKGNj;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return QcadnEifCRfURdskcfgdSKDEIFnxB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return QcadnEifCRfURdskcfgdSKDEIFnxB;
				}
			}

			[DebuggerHidden]
			public dqKblzFmMiWFqhADvjYWVDMDtqC(int P_0)
			{
				nnUHfYyDpSGZumoPHJGnjarQhCic = P_0;
				kLgbXxLCWuAYOYXQcdJgFTXFvcPaA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				nnUHfYyDpSGZumoPHJGnjarQhCic = -2;
			}

			private bool MoveNext()
			{
				int num = nnUHfYyDpSGZumoPHJGnjarQhCic;
				UserData userData = mYgdRsSDAUBmgCrljAwtgrYGllIKA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					nnUHfYyDpSGZumoPHJGnjarQhCic = -1;
					goto IL_007a;
				}
				nnUHfYyDpSGZumoPHJGnjarQhCic = -1;
				if (userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
				{
					return false;
				}
				kOuEbUlibTAtCahwAFOxSlKFKGNj = 0;
				goto IL_008c;
				IL_008c:
				if (kOuEbUlibTAtCahwAFOxSlKFKGNj < userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count)
				{
					InputAction inputAction = userData.rXMIXmZVqgXfOWciWmGdzMuYaZcG[kOuEbUlibTAtCahwAFOxSlKFKGNj];
					InputCategory actionCategoryById = userData.GetActionCategoryById(inputAction.categoryId);
					if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
					{
						QcadnEifCRfURdskcfgdSKDEIFnxB = inputAction;
						nnUHfYyDpSGZumoPHJGnjarQhCic = 1;
						return true;
					}
					goto IL_007a;
				}
				return false;
				IL_007a:
				kOuEbUlibTAtCahwAFOxSlKFKGNj++;
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
				dqKblzFmMiWFqhADvjYWVDMDtqC dqKblzFmMiWFqhADvjYWVDMDtqC2;
				if (nnUHfYyDpSGZumoPHJGnjarQhCic == -2 && kLgbXxLCWuAYOYXQcdJgFTXFvcPaA == Environment.CurrentManagedThreadId)
				{
					nnUHfYyDpSGZumoPHJGnjarQhCic = 0;
					dqKblzFmMiWFqhADvjYWVDMDtqC2 = this;
				}
				else
				{
					dqKblzFmMiWFqhADvjYWVDMDtqC2 = new dqKblzFmMiWFqhADvjYWVDMDtqC(0);
					dqKblzFmMiWFqhADvjYWVDMDtqC2.mYgdRsSDAUBmgCrljAwtgrYGllIKA = mYgdRsSDAUBmgCrljAwtgrYGllIKA;
				}
				return dqKblzFmMiWFqhADvjYWVDMDtqC2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class pXrVCHRYLmuITTljfIfiwYVhjezt : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int CSWZbmetqwNbTwInNtvYIEGTWGSp;

			private InputMapCategory vDGSkNMbHGRMfITVpZlmxwUCIIYC;

			private int pyopbKpelKmfAnEsummoZtbkjncR;

			public UserData aQCScdxJuycpfavFaEzfubaZyGgM;

			private int FEeTjIAxRVsSFwgcFNFOuHrHUcQg;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return vDGSkNMbHGRMfITVpZlmxwUCIIYC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vDGSkNMbHGRMfITVpZlmxwUCIIYC;
				}
			}

			[DebuggerHidden]
			public pXrVCHRYLmuITTljfIfiwYVhjezt(int P_0)
			{
				CSWZbmetqwNbTwInNtvYIEGTWGSp = P_0;
				pyopbKpelKmfAnEsummoZtbkjncR = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				CSWZbmetqwNbTwInNtvYIEGTWGSp = -2;
			}

			private bool MoveNext()
			{
				int cSWZbmetqwNbTwInNtvYIEGTWGSp = CSWZbmetqwNbTwInNtvYIEGTWGSp;
				UserData userData = aQCScdxJuycpfavFaEzfubaZyGgM;
				if (cSWZbmetqwNbTwInNtvYIEGTWGSp != 0)
				{
					if (cSWZbmetqwNbTwInNtvYIEGTWGSp != 1)
					{
						return false;
					}
					CSWZbmetqwNbTwInNtvYIEGTWGSp = -1;
					goto IL_0070;
				}
				CSWZbmetqwNbTwInNtvYIEGTWGSp = -1;
				if (userData.mapCategories == null)
				{
					return false;
				}
				FEeTjIAxRVsSFwgcFNFOuHrHUcQg = 0;
				goto IL_0080;
				IL_0080:
				if (FEeTjIAxRVsSFwgcFNFOuHrHUcQg < userData.mapCategories.Count)
				{
					if (userData.mapCategories[FEeTjIAxRVsSFwgcFNFOuHrHUcQg].userAssignable)
					{
						vDGSkNMbHGRMfITVpZlmxwUCIIYC = userData.mapCategories[FEeTjIAxRVsSFwgcFNFOuHrHUcQg];
						CSWZbmetqwNbTwInNtvYIEGTWGSp = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				FEeTjIAxRVsSFwgcFNFOuHrHUcQg++;
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
				pXrVCHRYLmuITTljfIfiwYVhjezt pXrVCHRYLmuITTljfIfiwYVhjezt2;
				if (CSWZbmetqwNbTwInNtvYIEGTWGSp == -2 && pyopbKpelKmfAnEsummoZtbkjncR == Environment.CurrentManagedThreadId)
				{
					CSWZbmetqwNbTwInNtvYIEGTWGSp = 0;
					pXrVCHRYLmuITTljfIfiwYVhjezt2 = this;
				}
				else
				{
					pXrVCHRYLmuITTljfIfiwYVhjezt2 = new pXrVCHRYLmuITTljfIfiwYVhjezt(0);
					pXrVCHRYLmuITTljfIfiwYVhjezt2.aQCScdxJuycpfavFaEzfubaZyGgM = aQCScdxJuycpfavFaEzfubaZyGgM;
				}
				return pXrVCHRYLmuITTljfIfiwYVhjezt2;
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
		private List<InputAction> fuFSvuUmxckhFEbUulSBLJpnyPii;

		[NonSerialized]
		private bool hmhEOeGpmnDKshHXgkBcPvaGQhzSb;

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

		internal IList<Player_Editor> EviYdZZAcXSKWfhzsldcaszNDheN
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

		internal IList<InputAction> BDLvTqacMWHeQAewQmniAkLORpMGb
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

		internal IList<InputCategory> ZmWayRBOslTvXKHlPxFwIPKsfTVJA
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

		internal IList<InputBehavior> CHwlwnFYDknvMsEYRkgZrwCKIPLb
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

		internal IList<InputMapCategory> kWSpTYDgTfmDHLUsnrDJbZABxhFs
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

		internal IList<InputLayout> uasGjggZybOPfmhZOYGCifMIJfvQA
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

		internal IList<InputLayout> KsFxPkZyQnAOBqWeVdhEHDQgJbEN
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

		internal IList<InputLayout> PcVhUEvtdAfwGrqpOqOBoActLCcn
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

		internal IList<InputLayout> MbUiHxbssjHZMTXkNQgmHhgIvRoO
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

		internal IList<ControllerMap_Editor> ZHbGPXmPmwlKZyYXdLYnJCXBBzeBA
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

		internal IList<ControllerMap_Editor> xRazglcLypJkLKFBNIsqdTkmEEkoA
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

		internal IList<ControllerMap_Editor> CHImmblKGQkrMnFtXBYDeEurAFox
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

		internal IList<ControllerMap_Editor> WtEXcWoPfhZNvESDNsLWDbfsdtjn
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

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> uZkOsbusllearjOvMjswpNouhpzcb
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

		internal IList<ControllerMapEnabler_RuleSet_Editor> PgxIWmrrvHXOpWkMCMlJVTrObmzb
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

		internal IEnumerable<InputMapCategory> awVOjRJJZJEvYRhmqAugFrECBEWo
		{
			[IteratorStateMachine(typeof(pXrVCHRYLmuITTljfIfiwYVhjezt))]
			get
			{
				return new pXrVCHRYLmuITTljfIfiwYVhjezt(-2)
				{
					aQCScdxJuycpfavFaEzfubaZyGgM = this
				};
			}
		}

		internal IEnumerable<InputCategory> OgeCvvCRBRqEjUBXcMstfDsyRZxpA
		{
			[IteratorStateMachine(typeof(ObeIogCZmDazgPNKJZOKnViSTZIAA))]
			get
			{
				return new ObeIogCZmDazgPNKJZOKnViSTZIAA(-2)
				{
					SKIdReHkVQoscbgdrbGXyRhAuCtI = this
				};
			}
		}

		internal IEnumerable<InputAction> YyRwHhTyPersPbKCYWjGScUbGFCz
		{
			[IteratorStateMachine(typeof(dqKblzFmMiWFqhADvjYWVDMDtqC))]
			get
			{
				return new dqKblzFmMiWFqhADvjYWVDMDtqC(-2)
				{
					mYgdRsSDAUBmgCrljAwtgrYGllIKA = this
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

		private List<InputAction> rXMIXmZVqgXfOWciWmGdzMuYaZcG
		{
			get
			{
				if (!ReInput.isReady)
				{
					return actions;
				}
				return fuFSvuUmxckhFEbUulSBLJpnyPii;
			}
		}

		[IteratorStateMachine(typeof(qIgBbuXAxSFkRuWKtNoXfVnATYBr))]
		internal IEnumerable<InputMapCategory> cWGxChMMjjCZfgujpDvJWkgxaKCW(string P_0)
		{
			return new qIgBbuXAxSFkRuWKtNoXfVnATYBr(-2)
			{
				QrDbwzvfIrHAMhHSriEdJQhgRXPP = this,
				WYytVwBRgesdjGbUckcxkfkERcyw = P_0
			};
		}

		[IteratorStateMachine(typeof(hgRreASoKdDaVatdnFnmahbxnXToA))]
		internal IEnumerable<InputMapCategory> fFIgdFAOYQWWAdsjJbfgXWQJDPWh(string P_0)
		{
			return new hgRreASoKdDaVatdnFnmahbxnXToA(-2)
			{
				hAYlsRItHWwHPEhGqfJBJFlJWBoz = this,
				zdBxHOnDXQOApBwFdMzXSchvfCKdA = P_0
			};
		}

		[IteratorStateMachine(typeof(laOsDuMvIZoIRnicQVqCSJEAcqXG))]
		internal IEnumerable<InputCategory> DemXSmhlZuCXlcNbwewUlwkWBCau(string P_0)
		{
			return new laOsDuMvIZoIRnicQVqCSJEAcqXG(-2)
			{
				GaeQRdkJqVWiPUIsFpDhyjLyPjsF = this,
				DcJVyQTLLaCVIVIkLDqAquIlhCQv = P_0
			};
		}

		[IteratorStateMachine(typeof(loLCMBlYdEZuMBiVWLyHKqMfiPVg))]
		internal IEnumerable<InputCategory> hKXYTiLotDhfMZSIAjfuOJHNgJhV(string P_0)
		{
			return new loLCMBlYdEZuMBiVWLyHKqMfiPVg(-2)
			{
				MnsCugTOJMLkOtsrCRuTQFtDiVHl = this,
				AJbGKJHCvsZNsBSUJcWmTwasKjpP = P_0
			};
		}

		[IteratorStateMachine(typeof(iyTEIBBiFUNFIoKKuJdOTJBIIgBG))]
		internal IEnumerable<InputAction> llXoDYIaeAHCaKeIbDDpIzSfgTHKb(int P_0, bool P_1)
		{
			return new iyTEIBBiFUNFIoKKuJdOTJBIIgBG(-2)
			{
				MVyOsEBZMQqzUWWuHdmlYEZwNrep = this,
				dHcIgjGaKeMqLTMwhdpJCdTRrfMx = P_0,
				BSDfrLuuwxARayspBKTnNpVqCSPFA = P_1
			};
		}

		[IteratorStateMachine(typeof(LzxBSRMUwSDfebMSpyXfDLpmtpHSA))]
		internal IEnumerable<InputAction> RHJTdCsKbaLsvklPwcKOLJfiUurD(string P_0, bool P_1)
		{
			return new LzxBSRMUwSDfebMSpyXfDLpmtpHSA(-2)
			{
				FoTshbxtfUGhbDsimqnpJeUQBhceA = this,
				cbTcwqOvkLVZhWnSfdkiFaeEfLNm = P_0,
				SdEQUfZaavKaDeDzbbnvugjaGoNj = P_1
			};
		}

		[IteratorStateMachine(typeof(QxuoQHxFTYCYiAkIaQgJbKGtWmSWA))]
		internal IEnumerable<InputAction> ujpuGarHQXSddElzRQUTVElGCvft(string P_0)
		{
			return new QxuoQHxFTYCYiAkIaQgJbKGtWmSWA(-2)
			{
				yIIeefElaDGQahvDSrwiKSxCUzzt = this,
				tArFveNifLGSactXaloIQPmMIzXaA = P_0
			};
		}

		[IteratorStateMachine(typeof(CpiLZvSdywuZZINlhaQCHzSrShKp))]
		internal IEnumerable<InputAction> IDrZVnjRiPTFCACCBVAoGRogphTO(int P_0, bool P_1)
		{
			return new CpiLZvSdywuZZINlhaQCHzSrShKp(-2)
			{
				psVkpdRiQxMOANEHYQbEmqrczwpT = this,
				KuJtaxihTMhnqKDcfXvYbuKRfMkb = P_0,
				aHqsODlowZpsMCbcRNqWYGqiByOf = P_1
			};
		}

		[IteratorStateMachine(typeof(FzqbnEHZrkVWXrRAcGsSqbaKYwhJA))]
		internal IEnumerable<InputAction> bYvURWLXXxFVhDdlDGefNglOcInB(string P_0, bool P_1)
		{
			return new FzqbnEHZrkVWXrRAcGsSqbaKYwhJA(-2)
			{
				itbEdihuJbfhvfvomEIJHYruXvhaA = this,
				XDTQjeZKovYymfmbgtwhuqdaBoNN = P_0,
				nokAhtNPUNoSLqGsBrxFsqslJTnM = P_1
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
				Player_Editor player_Editor = bMqQXhxpidxfbkMdSPUoUwVIYOcA();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.key = "system_player";
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputActionCategory inputActionCategory = BXRCuoivpEFlcZwEOgCZEPaKpNRzb();
				inputActionCategory.name = "Default";
				inputActionCategory.descriptiveName = inputActionCategory.name;
				actionCategories.Add(inputActionCategory);
				actionCategoryMap.AddCategory(inputActionCategory.id);
				InputBehavior inputBehavior = gBKsetWorVEHZBmWCwyLfWgiRzxH();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = ddOGPgfEmxqDYaAQdBPGkbDmRgsGA();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = XCdpwEERaNyDjkgdLYgyRCuZkeVL();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = EHbblLOHKEknDxsWAVhotHlKDSiFA();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = witcriZTmQilPiutfkiQjGTJCSjt();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = gSoqHosvaBTVCOlfnVjNvYbtfBWf();
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
			for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
			{
				list.Add(rXMIXmZVqgXfOWciWmGdzMuYaZcG[i]);
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
				KeyboardMap item = keyboardMaps[i].PsrktCybljmFnxvWynqvaoreCHOP(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].TGOeeBURFzzgmBJNVvllPdwqgpdt(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(bMqQXhxpidxfbkMdSPUoUwVIYOcA());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, bMqQXhxpidxfbkMdSPUoUwVIYOcA());
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
			InputAction inputAction = AVhftbtpOCItSPtUkKemexEDrPsr();
			inputAction.categoryId = categoryId;
			rXMIXmZVqgXfOWciWmGdzMuYaZcG.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG != null)
			{
				InputAction inputAction = AVhftbtpOCItSPtUkKemexEDrPsr();
				inputAction.categoryId = categoryId;
				rXMIXmZVqgXfOWciWmGdzMuYaZcG.Add(inputAction);
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
					rXMIXmZVqgXfOWciWmGdzMuYaZcG.RemoveAt(num);
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
			if (num == rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count - 1)
			{
				rXMIXmZVqgXfOWciWmGdzMuYaZcG.Add(inputAction);
				actionCategoryMap.AddAction(categoryId, inputAction.id);
				return rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count - 1;
			}
			rXMIXmZVqgXfOWciWmGdzMuYaZcG.Insert(num + 1, inputAction);
			int num2 = actionCategoryMap.IndexOfAction(categoryId, actionId);
			actionCategoryMap.InsertAction(categoryId, inputAction.id, num2 + 1);
			return num + 1;
		}

		private int rKjCTsfaFyKnjFrpLlcfeuaWCNqT(int P_0, InputAction P_1)
		{
			if (IndexOfActionCategory(P_0) < 0)
			{
				return -1;
			}
			InputAction inputAction = P_1.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			rXMIXmZVqgXfOWciWmGdzMuYaZcG.Add(inputAction);
			return rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count - 1;
		}

		public string[] GetActionNames()
		{
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return null;
			}
			string[] array = new string[rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count];
			for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
			{
				array[i] = rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].name;
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
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return 0;
			}
			for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
			{
				results.Add(rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].name);
			}
			return results.Count;
		}

		public int[] GetActionIds()
		{
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return null;
			}
			int[] array = new int[rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count];
			for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
			{
				array[i] = rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].id;
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
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return 0;
			}
			for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
			{
				results.Add(rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].id);
			}
			return results.Count;
		}

		public string GetActionNameById(int id)
		{
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
			{
				if (rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].id == id)
				{
					return rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].name;
				}
			}
			return string.Empty;
		}

		public InputAction GetAction(int index)
		{
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null || index < 0 || index >= rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count)
			{
				return null;
			}
			return rXMIXmZVqgXfOWciWmGdzMuYaZcG[index];
		}

		public InputAction GetAction(string name)
		{
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return null;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return null;
			}
			return rXMIXmZVqgXfOWciWmGdzMuYaZcG[num];
		}

		public InputAction GetActionById(int id)
		{
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return null;
			}
			for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
			{
				if (rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].id == id)
				{
					return rXMIXmZVqgXfOWciWmGdzMuYaZcG[i];
				}
			}
			return null;
		}

		public int GetActionId(string name)
		{
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return -1;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return -1;
			}
			return rXMIXmZVqgXfOWciWmGdzMuYaZcG[num].id;
		}

		public string[] GetSortedActionNamesInCategory(int id)
		{
			if (actionCategories == null || rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
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

		[IteratorStateMachine(typeof(FGabuJpItvlZRwCBJyFcsYjNuBIR))]
		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			return new FGabuJpItvlZRwCBJyFcsYjNuBIR(-2)
			{
				XgNBZtghJShXLQhUdyOiLeTjOnkgb = this,
				zmZFVoiFOqIMXgrfPTEJkIWdptkvA = id
			};
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (actionCategories == null || rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
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

		[IteratorStateMachine(typeof(XKzEclkPwbXuwhXaMFseCELrtgfX))]
		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			return new XKzEclkPwbXuwhXaMFseCELrtgfX(-2)
			{
				sxaiAAiqzmTuncyOAeisvsUYjFWy = this,
				ieegMNtduUhOxRNWaIErfruJJTBE = id
			};
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			if (actionCategories == null || rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
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

		[IteratorStateMachine(typeof(VGdgQXDjvSUgwSFdpPNVFuiCXyddb))]
		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			return new VGdgQXDjvSUgwSFdpPNVFuiCXyddb(-2)
			{
				sjWBYggFuPajWITaAdgkKFHDAVfgc = this,
				pRtijaUjTRgnGBxxYUiWYezibOzT = id
			};
		}

		public bool ContainsAction(int id)
		{
			return IndexOfAction(id) >= 0;
		}

		public int IndexOfAction(int id)
		{
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return -1;
			}
			for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
			{
				if (rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfAction(string name)
		{
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
			{
				if (rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddActionCategory()
		{
			InputActionCategory inputActionCategory = BXRCuoivpEFlcZwEOgCZEPaKpNRzb();
			actionCategories.Add(inputActionCategory);
			actionCategoryMap.AddCategory(inputActionCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputActionCategory inputActionCategory = BXRCuoivpEFlcZwEOgCZEPaKpNRzb();
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
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG != null)
			{
				for (int num = rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count - 1; num >= 0; num--)
				{
					if (rXMIXmZVqgXfOWciWmGdzMuYaZcG[num].categoryId == id)
					{
						rXMIXmZVqgXfOWciWmGdzMuYaZcG.RemoveAt(num);
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
			if (!duplicateActions || rXMIXmZVqgXfOWciWmGdzMuYaZcG == null)
			{
				return;
			}
			int id = inputActionCategory.id;
			int id2 = actionCategories[index].id;
			List<int> list = new List<int>();
			for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
			{
				if (rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].categoryId == id2)
				{
					list.Add(i);
				}
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>(list.Count);
			for (int j = 0; j < list.Count; j++)
			{
				InputAction inputAction = rXMIXmZVqgXfOWciWmGdzMuYaZcG[list[j]];
				int num = rKjCTsfaFyKnjFrpLlcfeuaWCNqT(id2, inputAction);
				if (num >= 0)
				{
					InputAction inputAction2 = rXMIXmZVqgXfOWciWmGdzMuYaZcG[num];
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
			if (num >= 0 && rXMIXmZVqgXfOWciWmGdzMuYaZcG[num].categoryId != newCategoryId)
			{
				actionCategoryMap.ChangeCategory(actionId, newCategoryId);
				rXMIXmZVqgXfOWciWmGdzMuYaZcG[num].categoryId = newCategoryId;
			}
		}

		public int GetActionCategoryCount(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG != null)
			{
				for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
				{
					if (rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].categoryId == id)
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
			inputBehaviors.Add(gBKsetWorVEHZBmWCwyLfWgiRzxH());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, gBKsetWorVEHZBmWCwyLfWgiRzxH());
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = inputBehaviors[index].id;
			if (rXMIXmZVqgXfOWciWmGdzMuYaZcG != null)
			{
				for (int i = 0; i < rXMIXmZVqgXfOWciWmGdzMuYaZcG.Count; i++)
				{
					if (rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].behaviorId == id)
					{
						rXMIXmZVqgXfOWciWmGdzMuYaZcG[i].behaviorId = 0;
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
			mapCategories.Add(ddOGPgfEmxqDYaAQdBPGkbDmRgsGA());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, ddOGPgfEmxqDYaAQdBPGkbDmRgsGA());
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
				Action<List<Player_Editor.Mapping>, int> action = KmWpPgLLukIJrpAVCBgaAZnDlCnIA._003C_003E9.GTgUcruAfTPBKFolnNeaumiKEiOm;
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
			joystickLayouts.Add(XCdpwEERaNyDjkgdLYgyRCuZkeVL());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, XCdpwEERaNyDjkgdLYgyRCuZkeVL());
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
				Action<List<Player_Editor.Mapping>, int> action = KmWpPgLLukIJrpAVCBgaAZnDlCnIA._003C_003E9.oBwXifmmPQfYSqbWbricryhYsEz;
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
			keyboardLayouts.Add(EHbblLOHKEknDxsWAVhotHlKDSiFA());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, EHbblLOHKEknDxsWAVhotHlKDSiFA());
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
				Action<List<Player_Editor.Mapping>, int> action = KmWpPgLLukIJrpAVCBgaAZnDlCnIA._003C_003E9.gBGdxKAaySvySGDCISdQCErAJrfMA;
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
			mouseLayouts.Add(witcriZTmQilPiutfkiQjGTJCSjt());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, witcriZTmQilPiutfkiQjGTJCSjt());
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
				Action<List<Player_Editor.Mapping>, int> action = KmWpPgLLukIJrpAVCBgaAZnDlCnIA._003C_003E9.RDeIrfIjLXmQqgUBdveKeshytMyFc;
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
			customControllerLayouts.Add(gSoqHosvaBTVCOlfnVjNvYbtfBWf());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, gSoqHosvaBTVCOlfnVjNvYbtfBWf());
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
				Action<List<Player_Editor.Mapping>, int> action = KmWpPgLLukIJrpAVCBgaAZnDlCnIA._003C_003E9.dYycJPbTJPVcTeBERLaKwVAwHGHT;
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

		internal ControllerMap zQmRzuxxMzBJuAOvKUHvmpMofonu(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Joystick => cEwcgjjduDknbeUijZLXUaDeJMmZ((Joystick)P_0, P_1, P_2), 
				ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
				ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
				ControllerType.Custom => RifLOhoZwdAImmgTfQyFqnUIpNjg(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
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

		internal JoystickMap WPVOclMlLgNtstndhCwCmTydQORu(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return PGcERRoVkZhOPEbzaHLisselgpEHb(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap cEwcgjjduDknbeUijZLXUaDeJMmZ(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return PGcERRoVkZhOPEbzaHLisselgpEHb(P_0.YLCwakRxQZFrcauCaNHIKvwulUt, P_1, P_2);
		}

		private JoystickMap PGcERRoVkZhOPEbzaHLisselgpEHb(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.hSqOsssNAbtRpBPgfYBSveZbjBck(guid);
			ControllerMap_Editor controllerMap_Editor = jBTgxxuaVNajhAxphArIFJSwIcsWA(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.QlQxGpqPGwcahumzquyUFHosjuMd(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.GLEkUqlfshOazMuuCsyjQMDeWVkQ(guid, P_1, P_2);
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
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.tAGkXVjNFWdkDejSUJuRDGQpkRgL(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = jBTgxxuaVNajhAxphArIFJSwIcsWA(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = ggbTVbosKNQWWZBcbkXHkvtCvYth(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.GLEkUqlfshOazMuuCsyjQMDeWVkQ(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty)
			{
				controllerMap_Editor = jBTgxxuaVNajhAxphArIFJSwIcsWA(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.QlQxGpqPGwcahumzquyUFHosjuMd(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.GLEkUqlfshOazMuuCsyjQMDeWVkQ(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.CJCLlbCvZdqNSnSfcrefXBbDHzmX(guid, P_1, P_2);
		}

		private ControllerMap_Editor jBTgxxuaVNajhAxphArIFJSwIcsWA(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = OdReOUIlysgIYAyaRjgMygHcNaNmA(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor OdReOUIlysgIYAyaRjgMygHcNaNmA(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				roLDJAaglAzmgrDTbgaDfcooJbNrA(list, joystickLayouts);
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

		private JoystickMap ggbTVbosKNQWWZBcbkXHkvtCvYth(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.xChOLxcNhexwriqZGkFeKQdHKjCM(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError("Error remapping joystick template " + P_2.Guid.ToString() + " to joystick " + P_0.guid.ToString() + "\nReason: " + text);
				return null;
			}
			return controllerMap_Editor.QlQxGpqPGwcahumzquyUFHosjuMd(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap AwbQbyZXTXvvipboSGrOHdWXJcWw(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.hSqOsssNAbtRpBPgfYBSveZbjBck(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.hSqOsssNAbtRpBPgfYBSveZbjBck(Guid.Empty);
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
				list.Add(allMap.oETQtUYpoAHvrDdxockLYpfjFkywA);
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
			ControllerMap_Editor controllerMap_Editor = gXdNZnuNPtktBbUoiUByTGyPnpWe(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.PsrktCybljmFnxvWynqvaoreCHOP(containsActionDelegate);
				keyboardMap.zWnkBhMoXfqJFSFjdKcndeWzpWxl(keyboard.savDJAJJykdFgIDmPSBdENeZaLumA, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.YDfKfWCnUJFlcsnXDeXOChJkeRvu(keyboard.savDJAJJykdFgIDmPSBdENeZaLumA, categoryId, layoutId);
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
			ControllerMap_Editor controllerMap_Editor = gXdNZnuNPtktBbUoiUByTGyPnpWe(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.TGOeeBURFzzgmBJNVvllPdwqgpdt(containsActionDelegate);
				mouseMap.CcPDEmlnZPKAcBNmxVbnnDVuhWEO(mouse.savDJAJJykdFgIDmPSBdENeZaLumA, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.ANjGDdEBPdEoyOMAokkZuXRxPUIc(mouse.savDJAJJykdFgIDmPSBdENeZaLumA, categoryId, layoutId);
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

		internal CustomControllerMap CtlgoRWNZjPivjmbrsinEqCNgeri(Guid P_0, int P_1, int P_2)
		{
			return FaYaHlwggyIigVQRlpTYtEOzQUXp(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap RifLOhoZwdAImmgTfQyFqnUIpNjg(int P_0, int P_1, int P_2)
		{
			return FaYaHlwggyIigVQRlpTYtEOzQUXp(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap FaYaHlwggyIigVQRlpTYtEOzQUXp(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = eOpnYtonskVCiDjvrJiuaddceZm(P_1, id, P_2, false);
			if (controllerMap_Editor != null)
			{
				CustomControllerMap customControllerMap = controllerMap_Editor.FADDpRNvePMvlrhgpoFiyjozErHI(ContainsAction, P_0);
				customControllerMap.SxPTvxNoleYgessaEBETBKQEvGOqA(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			CustomControllerMap customControllerMap2 = CustomControllerMap.PhiOTwnerjFBmSkwgINpfZEiwpoc(P_0.typeGuid, id, P_1, P_2);
			customControllerMap2.SxPTvxNoleYgessaEBETBKQEvGOqA(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap2;
		}

		private ControllerMap_Editor eOpnYtonskVCiDjvrJiuaddceZm(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = AbrGPQhOayKFPptSxxZprfuqipTrA(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor AbrGPQhOayKFPptSxxZprfuqipTrA(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				roLDJAaglAzmgrDTbgaDfcooJbNrA(list, customControllerLayouts);
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

		internal ControllerTemplateMap OWKJfjNzsEBgUBrwFaOawApxSgNn(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.AjykIxTdFiJlnZAlDlrRgYGFplWA();
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
			customControllers.Add(twbcHHCOYnqAKoQjczrRMoHhkElS(typeGuid));
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
			customControllers.Insert(index, twbcHHCOYnqAKoQjczrRMoHhkElS(typeGuid));
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
			controllerMapLayoutManagerRuleSets.Add(IQNdKePAUtDmcAiMNMmCDftESxULB());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, IQNdKePAUtDmcAiMNMmCDftESxULB());
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
			controllerMapEnablerRuleSets.Add(RntnkfQCtDkZINiqhZSBrCRSjQgc());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, RntnkfQCtDkZINiqhZSBrCRSjQgc());
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

		private Player_Editor bMqQXhxpidxfbkMdSPUoUwVIYOcA()
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

		private InputAction AVhftbtpOCItSPtUkKemexEDrPsr()
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

		private InputActionCategory BXRCuoivpEFlcZwEOgCZEPaKpNRzb()
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

		private InputBehavior gBKsetWorVEHZBmWCwyLfWgiRzxH()
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

		private InputMapCategory ddOGPgfEmxqDYaAQdBPGkbDmRgsGA()
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

		private InputLayout XCdpwEERaNyDjkgdLYgyRCuZkeVL()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewJoystickLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout EHbblLOHKEknDxsWAVhotHlKDSiFA()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewKeyboardLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout witcriZTmQilPiutfkiQjGTJCSjt()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewMouseLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout gSoqHosvaBTVCOlfnVjNvYbtfBWf()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewCustomControllerLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private CustomController_Editor twbcHHCOYnqAKoQjczrRMoHhkElS(Guid P_0)
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

		private ControllerMapLayoutManager_RuleSet_Editor IQNdKePAUtDmcAiMNMmCDftESxULB()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor
			{
				id = GetNewControllerMapLayoutManagerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames())
			};
		}

		private ControllerMapEnabler_RuleSet_Editor RntnkfQCtDkZINiqhZSBrCRSjQgc()
		{
			return new ControllerMapEnabler_RuleSet_Editor
			{
				id = GetNewControllerMapEnablerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames())
			};
		}

		private ControllerMap_Editor pXnMPNtQeixWUfLJOgtKphZivjiA(List<ControllerMap_Editor> P_0, int P_1, int P_2)
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

		private ControllerMap_Editor gXdNZnuNPtktBbUoiUByTGyPnpWe(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = pXnMPNtQeixWUfLJOgtKphZivjiA(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = LaBaVgDhhzjPyMCVwQpEasLWwFgW(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor LaBaVgDhhzjPyMCVwQpEasLWwFgW(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				roLDJAaglAzmgrDTbgaDfcooJbNrA(list, P_1);
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

		private void roLDJAaglAzmgrDTbgaDfcooJbNrA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			fjTgItaHxApYEQguultGgHQxZOSUA fjTgItaHxApYEQguultGgHQxZOSUA2 = new fjTgItaHxApYEQguultGgHQxZOSUA();
			fjTgItaHxApYEQguultGgHQxZOSUA2.iOIJZxjQZbKFCVlGajIRTeGbEdq = P_1;
			if (P_0 != null && fjTgItaHxApYEQguultGgHQxZOSUA2.iOIJZxjQZbKFCVlGajIRTeGbEdq != null)
			{
				P_0.Sort(fjTgItaHxApYEQguultGgHQxZOSUA2.YayexcWqwTXIZKIcSGUnGZYIPYxk);
			}
		}

		internal void haVEMEnjGwwMTYvaOdejpHcywGYu()
		{
			if (hmhEOeGpmnDKshHXgkBcPvaGQhzSb)
			{
				return;
			}
			fuFSvuUmxckhFEbUulSBLJpnyPii = new List<InputAction>(actions.Count);
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i] == null)
				{
					fuFSvuUmxckhFEbUulSBLJpnyPii.Add(null);
				}
				fuFSvuUmxckhFEbUulSBLJpnyPii.Add(new InputAction(actions[i]));
			}
			EviYdZZAcXSKWfhzsldcaszNDheN = new ReadOnlyCollection<Player_Editor>(players);
			BDLvTqacMWHeQAewQmniAkLORpMGb = new ReadOnlyCollection<InputAction>(fuFSvuUmxckhFEbUulSBLJpnyPii);
			List<InputCategory> list = new List<InputCategory>((actionCategories != null) ? actionCategories.Count : 0);
			for (int j = 0; j < actionCategories.Count; j++)
			{
				list.Add(actionCategories[j]);
			}
			ZmWayRBOslTvXKHlPxFwIPKsfTVJA = new ReadOnlyCollection<InputCategory>(list);
			CHwlwnFYDknvMsEYRkgZrwCKIPLb = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
			kWSpTYDgTfmDHLUsnrDJbZABxhFs = new ReadOnlyCollection<InputMapCategory>(mapCategories);
			uasGjggZybOPfmhZOYGCifMIJfvQA = new ReadOnlyCollection<InputLayout>(joystickLayouts);
			KsFxPkZyQnAOBqWeVdhEHDQgJbEN = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
			PcVhUEvtdAfwGrqpOqOBoActLCcn = new ReadOnlyCollection<InputLayout>(mouseLayouts);
			MbUiHxbssjHZMTXkNQgmHhgIvRoO = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
			ZHbGPXmPmwlKZyYXdLYnJCXBBzeBA = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
			xRazglcLypJkLKFBNIsqdTkmEEkoA = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
			CHImmblKGQkrMnFtXBYDeEurAFox = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
			WtEXcWoPfhZNvESDNsLWDbfsdtjn = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
			uZkOsbusllearjOvMjswpNouhpzcb = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
			PgxIWmrrvHXOpWkMCMlJVTrObmzb = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
			if (mapCategories != null)
			{
				for (int k = 0; k < mapCategories.Count; k++)
				{
					if (mapCategories[k] != null)
					{
						mapCategories[k].ZzoVDiFcIzGOVDvNlITWKiMIFbjy();
					}
				}
			}
			if (actionCategories != null)
			{
				for (int l = 0; l < actionCategories.Count; l++)
				{
					if (actionCategories[l] != null)
					{
						actionCategories[l].ZzoVDiFcIzGOVDvNlITWKiMIFbjy();
					}
				}
			}
			if (joystickLayouts != null)
			{
				for (int m = 0; m < joystickLayouts.Count; m++)
				{
					if (joystickLayouts[m] != null)
					{
						joystickLayouts[m].fmOrYBZOFQQUysQAinBulUGFSOqm();
					}
				}
			}
			if (keyboardLayouts != null)
			{
				for (int n = 0; n < keyboardLayouts.Count; n++)
				{
					if (keyboardLayouts[n] != null)
					{
						keyboardLayouts[n].fmOrYBZOFQQUysQAinBulUGFSOqm();
					}
				}
			}
			if (mouseLayouts != null)
			{
				for (int num = 0; num < mouseLayouts.Count; num++)
				{
					if (mouseLayouts[num] != null)
					{
						mouseLayouts[num].fmOrYBZOFQQUysQAinBulUGFSOqm();
					}
				}
			}
			if (customControllerLayouts != null)
			{
				for (int num2 = 0; num2 < customControllerLayouts.Count; num2++)
				{
					if (customControllerLayouts[num2] != null)
					{
						customControllerLayouts[num2].fmOrYBZOFQQUysQAinBulUGFSOqm();
					}
				}
			}
			if (fuFSvuUmxckhFEbUulSBLJpnyPii != null)
			{
				for (int num3 = 0; num3 < fuFSvuUmxckhFEbUulSBLJpnyPii.Count; num3++)
				{
					if (fuFSvuUmxckhFEbUulSBLJpnyPii[num3] != null)
					{
						fuFSvuUmxckhFEbUulSBLJpnyPii[num3].NTPvCyCpmjJwhTblSmBPIyeUdwSb();
					}
				}
			}
			containsActionDelegate = ContainsAction;
			hmhEOeGpmnDKshHXgkBcPvaGQhzSb = true;
		}

		internal void IJQYwmIOuZPNQKGehzwMMTRYGqtM()
		{
			if (!hmhEOeGpmnDKshHXgkBcPvaGQhzSb)
			{
				return;
			}
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					if (mapCategories[i] != null)
					{
						mapCategories[i].jBXBmBeKAZaSYPFvJNoUCmXvWKCW();
					}
				}
			}
			if (fuFSvuUmxckhFEbUulSBLJpnyPii != null)
			{
				for (int j = 0; j < fuFSvuUmxckhFEbUulSBLJpnyPii.Count; j++)
				{
					if (fuFSvuUmxckhFEbUulSBLJpnyPii[j] != null)
					{
						fuFSvuUmxckhFEbUulSBLJpnyPii[j].uFhDwxaAuBcVrMQZXRaxMdBHvHns();
					}
				}
			}
			hmhEOeGpmnDKshHXgkBcPvaGQhzSb = false;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return EskyvNObxRJJiyGJHmdeDbNECElB.GLuKQSLpIrfrSKVqXkeucXgaYqrv(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return EskyvNObxRJJiyGJHmdeDbNECElB.GLuKQSLpIrfrSKVqXkeucXgaYqrv(orig, null, false);
		}
	}
}
