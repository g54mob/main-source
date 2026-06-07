using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
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
						return 0;
					}
					set
					{
					}
				}

				public pbaiftYdiKclxwXxYyVWHvgdPtuh(int P_0, int P_1, int P_2)
				{
				}

				public override string ToString()
				{
					return null;
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
				}
			}

			[Serializable]
			private sealed class rZBdHIgGSMIYEnHuMUZACzNAagTSA
			{
				public static readonly rZBdHIgGSMIYEnHuMUZACzNAagTSA _003C_003E9;

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
					return 0;
				}

				internal string XTFfOEMGqtbTTTPiVkrFgxbJvMuS(InputActionCategory P_0)
				{
					return null;
				}

				internal int kjSUkhHNHETCcANsDRVLoiZgvpcM(InputActionCategory P_0, IList<InputActionCategory> P_1)
				{
					return 0;
				}

				internal int wWieShiTcAOchkKMNIZqQgqNpLkVA(InputBehavior P_0)
				{
					return 0;
				}

				internal string UzpIQoxhNEaiJXbPiZbAxEcmYPxn(InputBehavior P_0)
				{
					return null;
				}

				internal int RSPbjxZNtadqyhJgIEkWyypcGKYRA(InputBehavior P_0, IList<InputBehavior> P_1)
				{
					return 0;
				}

				internal int peIIwVjdEOESiGrlNdpHvXUXvrQ(InputAction P_0)
				{
					return 0;
				}

				internal string CUrarbWnCZheVhkoYkITXpJXESNrA(InputAction P_0)
				{
					return null;
				}

				internal int VtqdLKBFzqdliiQjwkBFEwCJyMFd(InputAction P_0, IList<InputAction> P_1)
				{
					return 0;
				}

				internal int ulKAkRGhDqEgstQaKMcoNgHLekbUA(InputMapCategory P_0)
				{
					return 0;
				}

				internal string ervHxwUEabgrYjpHjBsMzUCiRprp(InputMapCategory P_0)
				{
					return null;
				}

				internal int zfjykosuqGHAwqYwRxoFdahTGVkw(InputMapCategory P_0, IList<InputMapCategory> P_1)
				{
					return 0;
				}

				internal int FhKqGkMHlMGgYHMLwmLHUwOFKTBKA(InputLayout P_0)
				{
					return 0;
				}

				internal string BCUDjDAANHMCzIWXEFNIZrERPWdTA(InputLayout P_0)
				{
					return null;
				}

				internal int CMEfkIKIWZbPtpMjrlPlXnugobJtA(InputLayout P_0, IList<InputLayout> P_1)
				{
					return 0;
				}

				internal int lOxAhuZIxYzeGSBxuqvKhEqjzXzH(InputLayout P_0)
				{
					return 0;
				}

				internal string jVAVtrNQddJHApRTJEnMAmlnQHZr(InputLayout P_0)
				{
					return null;
				}

				internal int LazcjXcqDGLVjqjHfhTBydXbHBykA(InputLayout P_0, IList<InputLayout> P_1)
				{
					return 0;
				}

				internal int suhueOpPXqGEqdfWXfYdFahMypZf(InputLayout P_0)
				{
					return 0;
				}

				internal string ooJmFGhDQVnKmYVmCDxmNAxlxQWK(InputLayout P_0)
				{
					return null;
				}

				internal int NnodTtArJunfsSgaHLUypACwkmzmA(InputLayout P_0, IList<InputLayout> P_1)
				{
					return 0;
				}

				internal int KUaDVhbzgGaSJxkwELchJMTIBnFc(InputLayout P_0)
				{
					return 0;
				}

				internal string mYFLRCCiXyGzqHIMtmgoLWpRCnRCA(InputLayout P_0)
				{
					return null;
				}

				internal int sHurEYaxyGCtEoJFJFjiqTdjTuFL(InputLayout P_0, IList<InputLayout> P_1)
				{
					return 0;
				}

				internal int wUDDdocRiOEFUcHXBvBshMtyeJEqc(CustomController_Editor P_0)
				{
					return 0;
				}

				internal string bURUeUZGnvnYQjvNgspJoGlLoadp(CustomController_Editor P_0)
				{
					return null;
				}

				internal int aCthqBcwguxJcQEhmQgqKYzHNnzc(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
				{
					return 0;
				}

				internal int JaOTRWEJpxcNkaeQsLZjqdyNKABG(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return 0;
				}

				internal string tJAGusCqQZqoLTLAMukelLxugnos(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return null;
				}

				internal int PiRNOZUSxGEdZQThXRRoFbRCYLqP(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
				{
					return 0;
				}

				internal int UPTaXMAexwldAYHkpWAsghxSqgJTA(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return 0;
				}

				internal string osfFyPnxiNHUQBlzKUJXphdmlnHm(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return null;
				}

				internal int zhYrRtNQlcmKVAERJpcMlgSBzRSq(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
				{
					return 0;
				}

				internal int fbfdTegRoCnvzbnTRqFmAEjJGLljA(Player_Editor P_0)
				{
					return 0;
				}

				internal string DzeGvFhaSvifHqLADeDzIxMUhRXf(Player_Editor P_0)
				{
					return null;
				}

				internal int KxRUxnQYjlNdfIwDVKsRtYlezaJL(Player_Editor P_0, IList<Player_Editor> P_1)
				{
					return 0;
				}

				internal int AYxkQtIIWBZUlRDvwMMjsWqhFpJE(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
				{
					return 0;
				}

				internal int fJUmusbLPCAEPCrLYbTksnLgLLfW(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
				{
					return 0;
				}

				internal int BizFeuaeiQjyqZNxyDvsbQsHInwAb(ControllerMap_Editor P_0)
				{
					return 0;
				}

				internal string jwieGVbFIOdBYxgKjNmYiFDIMEexb(ControllerMap_Editor P_0)
				{
					return null;
				}

				internal int nlzBJZkGYUBqdSLQRsqWsxVuECxfA(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					return 0;
				}

				internal int dBMquGlVRJuxTxcabCOGHxupqMwIA(ControllerMap_Editor P_0)
				{
					return 0;
				}

				internal string IloOepQQtfZyNriJOSudlTKxufbE(ControllerMap_Editor P_0)
				{
					return null;
				}

				internal int cVuuJRroSshqaDneFEMIgPvDbGlYA(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					return 0;
				}

				internal int biODtnlEgAyjsifkXYOdlrUiVgeX(ControllerMap_Editor P_0)
				{
					return 0;
				}

				internal string ggylrcNwDfHVrukkdpIqcsbCqqVT(ControllerMap_Editor P_0)
				{
					return null;
				}

				internal int PkNIkUWMKOVvBoQsZYosoWRzSexs(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					return 0;
				}

				internal int MSKIPUtZDtCPpHndhqDKAPivOToe(ControllerMap_Editor P_0)
				{
					return 0;
				}

				internal string mjiDWtSirXPiZbUmCPrSRjfFQOOD(ControllerMap_Editor P_0)
				{
					return null;
				}

				internal int JeoQfgadvDAbbaCkaLeoWCnAeimeb(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					return 0;
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
					return null;
				}

				internal InputBehavior nefvCrxqYbXsRmqisIKPPwGqFezs(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputBehavior> P_0)
				{
					return null;
				}

				internal InputAction CXUdnggNTLGcCtzMzRowfCqFqLSb(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputAction> P_0)
				{
					return null;
				}

				internal InputLayout bZIHujsQIhEEXeCxWaRkBKDfpOUxA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputLayout> P_0)
				{
					return null;
				}

				internal InputLayout FSnBYMKdKcXZZBEvtGTUNuCdSGDL(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputLayout> P_0)
				{
					return null;
				}

				internal InputLayout VqBFnnVAYSYqOeaerRqpmAqubkce(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputLayout> P_0)
				{
					return null;
				}

				internal InputLayout nvCTgzvJQtvROLpHVcmuGscodCWAb(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputLayout> P_0)
				{
					return null;
				}

				internal List<pbaiftYdiKclxwXxYyVWHvgdPtuh> bzNxtgBOMmIrcBqJftpJtUUvGDxG(ControllerType P_0)
				{
					return null;
				}

				internal CustomController_Editor nvoCjSgrDsgRcUecTBveLnXLAnlKA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<CustomController_Editor> P_0)
				{
					return null;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor zTOAjdgkXlUAbNcDLCqfaRUgWsBRB(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					return null;
				}

				internal ControllerMapEnabler_RuleSet_Editor ZYVIyDyHAvLKdShYSENWCyrtiTuIA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					return null;
				}

				internal Player_Editor oUSJVfJEjdPGirFvTXDDWsINvwAj(hLnxJwqHptLEGiSLBxmvbWzdYyQF<Player_Editor> P_0)
				{
					return null;
				}
			}

			private sealed class MMSHilOAwbKKfyLBORTFGFryGPtk
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputAction> TNdEOmxmNaXvpXAjDBShDwSjpTzkA;

				internal bool ycfATlkYgpgBggJJwWTaIkAFuygr(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool NPLeyDYrgwXHxbTyLKdLqaXEfDXJ(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class ejOXuphJzcRcIWHopFkDYhzTtyzO
			{
				public int bCosgrNKxmbPqwCDBKLmHlyYQXHD;

				public olaMmqrRwGfelIhzpdYLwlHmuHgj qwPwCpnKsrWyEzmPLAtNZTOUhOiO;

				internal bool QGHktQIehWunTfhhaGtoBHTzEVfaA(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class btprYOlFiSHZEuDhtZaPlDJARQLx
			{
				public int ZZszzDDafXglWBEkwPbpEyhyUwJbb;

				public olaMmqrRwGfelIhzpdYLwlHmuHgj UDgHqtHvgSkbVfKHmhXIXiIxpECWA;

				internal bool fATvomtgyBNmfHsIeRhdKppBkVSx(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class RYSDKHcwYWBjAXJsrvXSRkNXmbPS
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<Player_Editor> jnneNLxjWOsxdvciQcgvHqnSApBU;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA NfOitvNkdueBOUBjDeOOFgZQKoAdb;

				internal void tUEDBfFoszOvFxQMjihwBdphTVEnA(List<Player_Editor.Mapping> P_0, List<pbaiftYdiKclxwXxYyVWHvgdPtuh> P_1)
				{
				}
			}

			private sealed class IQWrciTRbFHNuZqtJLHejFtKkYXl
			{
				public Player_Editor.Mapping OPhIHMDiUgUxzWcZRPchFcPxRElA;

				public RYSDKHcwYWBjAXJsrvXSRkNXmbPS WcKxyWzlzSKUBgZnEetEHLBVEoAf;

				internal bool LepQSQSauvdghglwUzOEkdpmaWNQ(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool TTyAGEGxSdxcvPFivkWlMksjKALWA(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class akhEUqOSvWAfRwBipocKHBaFCggS
			{
				public Player_Editor.CreateControllerInfo WcalOpKYetIyhGZwPDOErsclINxw;

				public RYSDKHcwYWBjAXJsrvXSRkNXmbPS HnWBhIfULBrpmToBwQCQlFFJgKJrA;

				internal bool TgjNQqBtyXfepXgYXGsfNGXfKlpx(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class kYwUGubUIIuANLajbaDRRdeLnBSM
			{
				public int KVukewitKylGtFuyvuCsriuWwNqx;

				public RYSDKHcwYWBjAXJsrvXSRkNXmbPS vmcsWDozKMdJmpeTBPToVPtnBibgA;

				internal bool cdaBvGbHYfqqydeJiQJSlAodlOkXc(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class naDVfWUhyZSdhnaGicYPjclibsYc
			{
				public int XtIKEnYkRYFwYyojiCyLSqQiVllt;

				public RYSDKHcwYWBjAXJsrvXSRkNXmbPS OdvkkGGTWvXcyPafrkwlMqymLWQe;

				internal bool mZVctOECKIUgskXEYUNZKrnuQjOO(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class WNPdiiupcRaoTTwSPyAtwHMkDnlG
			{
				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> DrzeeShFcKNbVQHvKFNGXEyYLefXA;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA CxLnsnkdkwYHdMHVUOlrEaOcqtKD;

				internal int fdnnlTdwvibfpihIYoClEnqgQyik(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					return 0;
				}

				internal ControllerMap_Editor nPNtAaCLFUBYZOJrDCcaFsJfPOTW(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> P_0)
				{
					return null;
				}
			}

			private sealed class boIOqgDgchulJwGkMuRtZwKInImJ
			{
				public ControllerMap_Editor zxgAniClXTLZgZBaajFLtlvbmkBOA;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> hhTtmGejMYPeEQizSRCfMXyuTCBT;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> IFHwzjIGaYhdjWHuowGHPByYvAdt;

				internal bool WpmTQdHDegjdJhRyJLVDAuEkSHYB(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool AQddFvZiYyDgImdNWnBGUprOSfWE(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class QsYbGJggairMFSjRQBGCegTrMePq
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> tAMGNvJHqVaAaYbZoXOegDwAOXXwA;

				public ControllerMap_Editor opkEZndLlCCXpfvDviWNohvVXBRB;

				internal bool lvDCalOCgtGibcYcGRAyfIKDioGd(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool exqEzxgsaxOkxXzWrCffeFVXYqkJA(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class KJotlfnskfsxVSRrrKHWLTsJGZzd
			{
				public List<int> FXGWizaNKIxxSSJWSdwjCYchwHrk;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA AZpETFMcPuyXuJeIhUJCRXIyXruh;

				internal InputMapCategory wHTbEdbfkDSNaLgJjMIThKHTIamRA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<InputMapCategory> P_0)
				{
					return null;
				}
			}

			private sealed class zhBJlCxYUHpyGHsGOVbYPlBRJlOS
			{
				public ActionElementMap kBWUZmiirJOBlKYiZplHcBENiyG;

				public QsYbGJggairMFSjRQBGCegTrMePq EoiBYreVRZqjLDJpoZzUyOrTaoQI;

				internal bool cKjBmekTzbTpMOcJOyzYeHiqGNbAb(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class fliJGeUXiupUkdonmoPLZkNtLHak
			{
				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> HcwcjKmWWEeTrFoGmoFMGgJHKYxCb;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA KsvGgldljXSGENtFiRvIaOtsrSld;

				internal int hMwOLYekNjLqWIlgRZfvUpRcikfO(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					return 0;
				}

				internal ControllerMap_Editor kLMBIbdqpVxacqQDRwrCLrieigxv(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> P_0)
				{
					return null;
				}
			}

			private sealed class eIckfOvqZSeaefjXIQtXGQLpbPibA
			{
				public ControllerMap_Editor CdrvxdDiJCGxFjMZppsRMbqQVNZA;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> swUoAkoVJGwGxJPPyOaFcwnkKpKF;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> UeAlAqWsNZqbAnXdkTrmVlYEnBrV;

				internal bool gbxKjduoAqCIydifyJNzwCRTsPvL(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool CxyyunMJYxevsSRxlSSqtDrSFsBt(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class YtDxlPDzWJkgKxuYRjyROZQcBpAI
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> SIMUVHgFltiYTKzinQLkKrjoLbdy;

				public ControllerMap_Editor XClgwvbPDKKHpQkkBISikIjQzyRD;

				internal bool etBqQFegDSgjDBnQvKiiJrizhoUf(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool VhVxkyKJhweORebYjaYgSCawpxWy(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class MQRdBKPSCNSkjnVVnbwxpNLMmSQD
			{
				public ActionElementMap vtDABaAgUmLltCiqEsJIPhRAGgLRc;

				public YtDxlPDzWJkgKxuYRjyROZQcBpAI lMxDrwdllnhjuifCYjAdaerYCCBS;

				internal bool aDCLtNSCBeMlpJodEgsTAYZgogBH(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class UXFTiHxhzYFiejrCOoPGgSkKPDrlc
			{
				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> tbnawahQiyfXPpslJHNIwuzYRwpC;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA qUNqfdCCXpqAJRewGFGaHEsSJzrDb;

				internal int WRqgkiCHQxuigrpwrKVZKBRSCdbVA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					return 0;
				}

				internal ControllerMap_Editor aXWhyglWaSbVDGMuOeCMFVCHFcYBA(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> P_0)
				{
					return null;
				}
			}

			private sealed class NcEcBFnrlmpwHLdPWHGIjYJIBvpcA
			{
				public ControllerMap_Editor DRfekKvoyOtJCGYIZUttCvSskpEd;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> JzZrrZDGeCFBYYsBQhgHorBuGAvgA;

				public Predicate<pbaiftYdiKclxwXxYyVWHvgdPtuh> HQbKIrauNGcWJLpPoJVEvdcrCIHFA;

				internal bool bEBfeBDWkWHNbOUORBBcbumDTkpU(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool JTSKzgEgnZWASFMZBJkMkMvyvshX(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class BMZoMYSrLkfLtkexGLPjvYgOwMlk
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> uFItkzJjGTOAhDJFmfacCqryIezpA;

				public ControllerMap_Editor TqRGHxEzSVmXqzxPNWJbWnvRRhRM;

				internal bool gVhDKSvZucrWMDGqcqdPBumVchU(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool igqlptIdDUapQyzgDrhvBdUPMQeg(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class FAMNKwhiHwIVIgMUsYRHuEalmqHNA
			{
				public ActionElementMap NEANaQFZUpjJIhANgTEVkZgwHFLq;

				public BMZoMYSrLkfLtkexGLPjvYgOwMlk YbRcySmwHzJNyiXQOFScUPcJAkrV;

				internal bool ApIkPVuXHppTxvKsOhAFumNJbmNr(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class JTvHfeujdxhNxJQuPNgKyUilhPDQA
			{
				public List<pbaiftYdiKclxwXxYyVWHvgdPtuh> JDkdqxjdIIAtYncEuameWCNzqZsFb;

				public yDXgPSFzJKEjAVzcCWeQWwNOfpAAA lzcVxCZtShaFBYDpEaXanLEWfIQHA;

				internal int sJlieWelIRYxamBzabISVgaRPYVE(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					return 0;
				}

				internal ControllerMap_Editor ShJWxqhzvMKFtyTWDELZbDYyNusc(hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> P_0)
				{
					return null;
				}
			}

			private sealed class rpOyYdeDywWOaigKPQEwFmBtJscG
			{
				public int JRCVYKXNNRdiRcudnPKvqJaTtnww;

				internal bool mjNUIWYZezAWSWkGIssLgndaQXtR(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
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
					return false;
				}

				internal bool lUksoyBgJSYzcIvCcGowDyYchuaS(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool qXsLOBFPwmkHwxFkvbMAnmJKHZFz(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class OMtZzPeycNEvEWftNjKofamWRcFN
			{
				public hLnxJwqHptLEGiSLBxmvbWzdYyQF<ControllerMap_Editor> guAsUFbPVKKGVWjnhFcSDrEqnSPl;

				public ControllerMap_Editor fVNQyeGLZxlTojzRgTtaioXFkjrv;

				internal bool icBIavfsOheCdyATTCMafayciyyEb(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool iEhTUoMbidntislVGwHsYQPrLIvl(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}

				internal bool skaorCUldlOjiDuuoBidlmozfHfIA(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class JCQTTdUVWDSYLuRaflZreBNzYvgQ
			{
				public ActionElementMap rGUthVkygPcSJTTuHfkIseNbhgsL;

				public OMtZzPeycNEvEWftNjKofamWRcFN MfRqNxVzEdUopHImfGiVFPBhCGDEb;

				internal bool RiIjFTMFUmFvAaZzNbEFAFaISUWL(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
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
					return false;
				}
			}

			private sealed class cRbkbXSUIUgEbmPDOZVtSxGjlWtg
			{
				public int swCnxjFmcEMhUfgIMsOCHvoUGZwp;

				public dZUvAutCcTNMAyYNQilmeqoHHSDV xmJHkIPLSLcsxSGRsxhenTpPiVjU;

				internal bool BanCzxXlipDKIGnuYYltDxNiwrlA(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
				}
			}

			private sealed class hemqEXIHmkNVhfljdaHFEckmeuEj
			{
				public int RgcDuMgdVqbtVaDeyypmfUPmpxkN;

				public dZUvAutCcTNMAyYNQilmeqoHHSDV jTTrvOGnVjLAzFxyirZBKhzCoxDc;

				internal bool moLEkithaEMjDsPZqyMnJQBCWDUE(pbaiftYdiKclxwXxYyVWHvgdPtuh P_0)
				{
					return false;
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
					return false;
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
					return false;
				}
			}

			public static UserData GLuKQSLpIrfrSKVqXkeucXgaYqrv(UserData P_0, UserData P_1, bool P_2)
			{
				return null;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void TNbYZiXWNuOTNyfnrvQOBgJcOMyk(object P_0)
			{
			}

			private static void lWbWrITCNsCbuIKUDXRgSKfZxdCR<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
			{
			}

			private static void dTgMKrDmpiPFpXgtPHFTDKxNhJGO<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<pbaiftYdiKclxwXxYyVWHvgdPtuh> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<hLnxJwqHptLEGiSLBxmvbWzdYyQF<_0001>, _0001> P_9) where _0001 : class
			{
			}
		}

		[Serializable]
		private sealed class KmWpPgLLukIJrpAVCBgaAZnDlCnIA
		{
			public static readonly KmWpPgLLukIJrpAVCBgaAZnDlCnIA _003C_003E9;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__199_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__217_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__233_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__249_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__265_0;

			internal void GTgUcruAfTPBKFolnNeaumiKEiOm(List<Player_Editor.Mapping> P_0, int P_1)
			{
			}

			internal void oBwXifmmPQfYSqbWbricryhYsEz(List<Player_Editor.Mapping> P_0, int P_1)
			{
			}

			internal void gBGdxKAaySvySGDCISdQCErAJrfMA(List<Player_Editor.Mapping> P_0, int P_1)
			{
			}

			internal void RDeIrfIjLXmQqgUBdveKeshytMyFc(List<Player_Editor.Mapping> P_0, int P_1)
			{
			}

			internal void dYycJPbTJPVcTeBERLaKwVAwHGHT(List<Player_Editor.Mapping> P_0, int P_1)
			{
			}
		}

		private sealed class fjTgItaHxApYEQguultGgHQxZOSUA
		{
			public List<InputLayout> iOIJZxjQZbKFCVlGajIRTeGbEdq;

			internal int YayexcWqwTXIZKIcSGUnGZYIPYxk(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				return 0;
			}
		}

		private sealed class rFxDIKumDTSwluJxXhDqqjQczrFU
		{
			public ControllerMap_Editor gAXvuBPDsijPoVKwpXJMjGrllnNl;

			public ControllerMap_Editor aTQkIRVoWXdlGDprTEWVIAjCkLKSA;

			internal bool EiacEcRlyetJfktIUtzluNaZjtqh(InputLayout P_0)
			{
				return false;
			}

			internal bool WkGiBCyMAAAaDJgQYPGNKaqIdGCt(InputLayout P_0)
			{
				return false;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public laOsDuMvIZoIRnicQVqCSJEAcqXG(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public QxuoQHxFTYCYiAkIaQgJbKGtWmSWA(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public iyTEIBBiFUNFIoKKuJdOTJBIIgBG(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void JbSVpFPQXHLRGNgSpSlNCFMmJamv()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public LzxBSRMUwSDfebMSpyXfDLpmtpHSA(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void ndtnbCitxvdoAdJHBdkvKwZueMtC()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public qIgBbuXAxSFkRuWKtNoXfVnATYBr(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public XKzEclkPwbXuwhXaMFseCELrtgfX(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void mYFqVKXrHopdDFTAoLcjEuBMHwPm()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return 0;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public VGdgQXDjvSUgwSFdpPNVFuiCXyddb(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void baPWCMuELCWxPlKGIQFaIIxAbaGQ()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public FGabuJpItvlZRwCBJyFcsYjNuBIR(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void TSHEJueYpZzPiWAjkVeDuHrlGfbf()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public loLCMBlYdEZuMBiVWLyHKqMfiPVg(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public CpiLZvSdywuZZINlhaQCHzSrShKp(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void KlfMFGufvMdmYFOuHOUvkxnldchI()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public FzqbnEHZrkVWXrRAcGsSqbaKYwhJA(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void vWLodeGAiHbUvHcoFbfmMFxBgsApA()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public hgRreASoKdDaVatdnFnmahbxnXToA(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public ObeIogCZmDazgPNKJZOKnViSTZIAA(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public dqKblzFmMiWFqhADvjYWVDMDtqC(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
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
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public pXrVCHRYLmuITTljfIfiwYVhjezt(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}

			[DebuggerHidden]
			IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ConfigVars configVars;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Player_Editor> players;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputAction> actions;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputActionCategory> actionCategories;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ActionCategoryMap actionCategoryMap;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputBehavior> inputBehaviors;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputMapCategory> mapCategories;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> joystickLayouts;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> keyboardLayouts;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> mouseLayouts;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputLayout> customControllerLayouts;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> joystickMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> keyboardMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> mouseMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> customControllerMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CustomController_Editor> customControllers;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets;

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
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<InputAction> BDLvTqacMWHeQAewQmniAkLORpMGb
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<InputCategory> ZmWayRBOslTvXKHlPxFwIPKsfTVJA
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<InputBehavior> CHwlwnFYDknvMsEYRkgZrwCKIPLb
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<InputMapCategory> kWSpTYDgTfmDHLUsnrDJbZABxhFs
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<InputLayout> uasGjggZybOPfmhZOYGCifMIJfvQA
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<InputLayout> KsFxPkZyQnAOBqWeVdhEHDQgJbEN
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<InputLayout> PcVhUEvtdAfwGrqpOqOBoActLCcn
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<InputLayout> MbUiHxbssjHZMTXkNQgmHhgIvRoO
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<ControllerMap_Editor> ZHbGPXmPmwlKZyYXdLYnJCXBBzeBA
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<ControllerMap_Editor> xRazglcLypJkLKFBNIsqdTkmEEkoA
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<ControllerMap_Editor> CHImmblKGQkrMnFtXBYDeEurAFox
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<ControllerMap_Editor> WtEXcWoPfhZNvESDNsLWDbfsdtjn
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> uZkOsbusllearjOvMjswpNouhpzcb
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		internal IList<ControllerMapEnabler_RuleSet_Editor> PgxIWmrrvHXOpWkMCMlJVTrObmzb
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public ConfigVars ConfigVars => null;

		internal IEnumerable<InputMapCategory> awVOjRJJZJEvYRhmqAugFrECBEWo
		{
			[IteratorStateMachine(typeof(pXrVCHRYLmuITTljfIfiwYVhjezt))]
			get
			{
				return null;
			}
		}

		internal IEnumerable<InputCategory> OgeCvvCRBRqEjUBXcMstfDsyRZxpA
		{
			[IteratorStateMachine(typeof(ObeIogCZmDazgPNKJZOKnViSTZIAA))]
			get
			{
				return null;
			}
		}

		internal IEnumerable<InputAction> YyRwHhTyPersPbKCYWjGScUbGFCz
		{
			[IteratorStateMachine(typeof(dqKblzFmMiWFqhADvjYWVDMDtqC))]
			get
			{
				return null;
			}
		}

		public int playerCount => 0;

		private List<InputAction> rXMIXmZVqgXfOWciWmGdzMuYaZcG => null;

		[IteratorStateMachine(typeof(qIgBbuXAxSFkRuWKtNoXfVnATYBr))]
		internal IEnumerable<InputMapCategory> cWGxChMMjjCZfgujpDvJWkgxaKCW(string P_0)
		{
			return null;
		}

		[IteratorStateMachine(typeof(hgRreASoKdDaVatdnFnmahbxnXToA))]
		internal IEnumerable<InputMapCategory> fFIgdFAOYQWWAdsjJbfgXWQJDPWh(string P_0)
		{
			return null;
		}

		[IteratorStateMachine(typeof(laOsDuMvIZoIRnicQVqCSJEAcqXG))]
		internal IEnumerable<InputCategory> DemXSmhlZuCXlcNbwewUlwkWBCau(string P_0)
		{
			return null;
		}

		[IteratorStateMachine(typeof(loLCMBlYdEZuMBiVWLyHKqMfiPVg))]
		internal IEnumerable<InputCategory> hKXYTiLotDhfMZSIAjfuOJHNgJhV(string P_0)
		{
			return null;
		}

		[IteratorStateMachine(typeof(iyTEIBBiFUNFIoKKuJdOTJBIIgBG))]
		internal IEnumerable<InputAction> llXoDYIaeAHCaKeIbDDpIzSfgTHKb(int P_0, bool P_1)
		{
			return null;
		}

		[IteratorStateMachine(typeof(LzxBSRMUwSDfebMSpyXfDLpmtpHSA))]
		internal IEnumerable<InputAction> RHJTdCsKbaLsvklPwcKOLJfiUurD(string P_0, bool P_1)
		{
			return null;
		}

		[IteratorStateMachine(typeof(QxuoQHxFTYCYiAkIaQgJbKGtWmSWA))]
		internal IEnumerable<InputAction> ujpuGarHQXSddElzRQUTVElGCvft(string P_0)
		{
			return null;
		}

		[IteratorStateMachine(typeof(CpiLZvSdywuZZINlhaQCHzSrShKp))]
		internal IEnumerable<InputAction> IDrZVnjRiPTFCACCBVAoGRogphTO(int P_0, bool P_1)
		{
			return null;
		}

		[IteratorStateMachine(typeof(FzqbnEHZrkVWXrRAcGsSqbaKYwhJA))]
		internal IEnumerable<InputAction> bYvURWLXXxFVhDdlDGefNglOcInB(string P_0, bool P_1)
		{
			return null;
		}

		public UserData()
		{
		}

		private UserData(bool P_0)
		{
		}

		[CustomObfuscation(rename = false)]
		internal void SetDefaultValuesOnCreation()
		{
		}

		public List<InputAction> GetActions_Copy()
		{
			return null;
		}

		public List<InputBehavior> GetInputBehaviors_Copy()
		{
			return null;
		}

		public List<KeyboardMap> GetKeyboardMaps_Copy()
		{
			return null;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			return null;
		}

		public void AddPlayer()
		{
		}

		public void InsertPlayer(int index)
		{
		}

		public void DeletePlayer(int index)
		{
		}

		public bool ReorderPlayer(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicatePlayer(int index)
		{
		}

		public string[] GetPlayerNames()
		{
			return null;
		}

		public int GetPlayerNames(IList<string> results)
		{
			return 0;
		}

		public int[] GetPlayerIds()
		{
			return null;
		}

		public int[] GetPlayerRuntimeIds()
		{
			return null;
		}

		public int GetPlayerRuntimeIds(IList<int> results)
		{
			return 0;
		}

		public string GetPlayerNameById(int id)
		{
			return null;
		}

		public Player_Editor GetPlayer(int index)
		{
			return null;
		}

		public int GetPlayerId(string name)
		{
			return 0;
		}

		public bool IsMouseAssigned()
		{
			return false;
		}

		public void ClearMouseAssignments()
		{
		}

		public bool IsKeyboardAssigned()
		{
			return false;
		}

		public void ClearKeyboardAssignments()
		{
		}

		public void AddAction(int categoryId)
		{
		}

		public void InsertAction(int categoryId, int actionId)
		{
		}

		public void DeleteAction(int categoryId, int actionId)
		{
		}

		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public int DuplicateAction_FromButton(int categoryId, int actionId)
		{
			return 0;
		}

		private int rKjCTsfaFyKnjFrpLlcfeuaWCNqT(int P_0, InputAction P_1)
		{
			return 0;
		}

		public string[] GetActionNames()
		{
			return null;
		}

		public int GetActionNames(IList<string> results)
		{
			return 0;
		}

		public int[] GetActionIds()
		{
			return null;
		}

		public int GetActionIds(IList<int> results)
		{
			return 0;
		}

		public string GetActionNameById(int id)
		{
			return null;
		}

		public InputAction GetAction(int index)
		{
			return null;
		}

		public InputAction GetAction(string name)
		{
			return null;
		}

		public InputAction GetActionById(int id)
		{
			return null;
		}

		public int GetActionId(string name)
		{
			return 0;
		}

		public string[] GetSortedActionNamesInCategory(int id)
		{
			return null;
		}

		[IteratorStateMachine(typeof(FGabuJpItvlZRwCBJyFcsYjNuBIR))]
		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			return null;
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			return null;
		}

		[IteratorStateMachine(typeof(XKzEclkPwbXuwhXaMFseCELrtgfX))]
		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			return null;
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			return null;
		}

		[IteratorStateMachine(typeof(VGdgQXDjvSUgwSFdpPNVFuiCXyddb))]
		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			return null;
		}

		public bool ContainsAction(int id)
		{
			return false;
		}

		public int IndexOfAction(int id)
		{
			return 0;
		}

		public int IndexOfAction(string name)
		{
			return 0;
		}

		public void AddActionCategory()
		{
		}

		public void InsertActionCategory(int index)
		{
		}

		public void DeleteActionCategory(int index)
		{
		}

		public bool ReorderActionCategory(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateActionCategory(int index, bool duplicateActions)
		{
		}

		public void ChangeActionCategory(int actionId, int newCategoryId)
		{
		}

		public int GetActionCategoryCount(int id)
		{
			return 0;
		}

		public int GetActionCategoryIndex(int id)
		{
			return 0;
		}

		public string[] GetActionCategoryNames()
		{
			return null;
		}

		public int[] GetActionCategoryIds()
		{
			return null;
		}

		public InputCategory GetActionCategory(int index)
		{
			return null;
		}

		public InputCategory GetActionCategory(string name)
		{
			return null;
		}

		public InputCategory GetActionCategoryById(int id)
		{
			return null;
		}

		public int GetActionCategoryId(string name)
		{
			return 0;
		}

		public string GetActionCategoryNameById(int id)
		{
			return null;
		}

		public int IndexOfActionCategory(int id)
		{
			return 0;
		}

		public int IndexOfActionCategory(string name)
		{
			return 0;
		}

		public int GetActionCategoryCount()
		{
			return 0;
		}

		public void AddInputBehavior()
		{
		}

		public void InsertInputBehavior(int index)
		{
		}

		public void DeleteInputBehavior(int index)
		{
		}

		public bool ReorderInputBehavior(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateInputBehavior(int index)
		{
		}

		public string[] GetInputBehaviorNames()
		{
			return null;
		}

		public int[] GetInputBehaviorIds()
		{
			return null;
		}

		public InputBehavior GetInputBehavior(int index)
		{
			return null;
		}

		public InputBehavior GetInputBehavior(string name)
		{
			return null;
		}

		public InputBehavior GetInputBehaviorById(int id)
		{
			return null;
		}

		public int GetInputBehaviorId(string name)
		{
			return 0;
		}

		public int IndexOfInputBehavior(int id)
		{
			return 0;
		}

		public int IndexOfInputBehavior(string name)
		{
			return 0;
		}

		public void AddMapCategory()
		{
		}

		public void InsertMapCategory(int index)
		{
		}

		public void DeleteMapCategory(int index)
		{
		}

		public bool ReorderMapCategory(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateMapCategory(int index, bool duplicateMaps)
		{
		}

		public int GetMapCategoryMapCount(int id)
		{
			return 0;
		}

		public int GetMapCategoryIndex(int id)
		{
			return 0;
		}

		public string[] GetMapCategoryNames()
		{
			return null;
		}

		public int[] GetMapCategoryIds()
		{
			return null;
		}

		public InputMapCategory GetMapCategory(int index)
		{
			return null;
		}

		public InputMapCategory GetMapCategory(string name)
		{
			return null;
		}

		public InputMapCategory GetMapCategoryById(int id)
		{
			return null;
		}

		public int GetMapCategoryId(string name)
		{
			return 0;
		}

		public string GetMapCategoryNameById(int id)
		{
			return null;
		}

		public int IndexOfMapCategory(int id)
		{
			return 0;
		}

		public int IndexOfMapCategory(string name)
		{
			return 0;
		}

		public string[] GetLayoutNames(ControllerType controllerType)
		{
			return null;
		}

		public int[] GetLayoutIds(ControllerType controllerType)
		{
			return null;
		}

		public void AddJoystickLayout()
		{
		}

		public void InsertJoystickLayout(int index)
		{
		}

		public void DeleteJoystickLayout(int index)
		{
		}

		public bool ReorderJoystickLayout(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateJoystickLayout(int index, bool duplicateMaps)
		{
		}

		public int GetJoystickLayoutMapCount(int id)
		{
			return 0;
		}

		public int GetJoystickLayoutIndex(int id)
		{
			return 0;
		}

		public string[] GetJoystickLayoutNames()
		{
			return null;
		}

		public int[] GetJoystickLayoutIds()
		{
			return null;
		}

		public InputLayout GetJoystickLayout(int index)
		{
			return null;
		}

		public InputLayout GetJoystickLayout(string name)
		{
			return null;
		}

		public InputLayout GetJoystickLayoutById(int id)
		{
			return null;
		}

		public int GetJoystickLayoutId(string name)
		{
			return 0;
		}

		public int IndexOfJoystickLayout(int id)
		{
			return 0;
		}

		public int IndexOfJoystickLayout(string name)
		{
			return 0;
		}

		public string GetJoystickLayoutNameById(int id)
		{
			return null;
		}

		public void AddKeyboardLayout()
		{
		}

		public void InsertKeyboardLayout(int index)
		{
		}

		public void DeleteKeyboardLayout(int index)
		{
		}

		public bool ReorderKeyboardLayout(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateKeyboardLayout(int index, bool duplicateMaps)
		{
		}

		public int GetKeyboardLayoutMapCount(int id)
		{
			return 0;
		}

		public int GetKeyboardLayoutIndex(int id)
		{
			return 0;
		}

		public string[] GetKeyboardLayoutNames()
		{
			return null;
		}

		public int[] GetKeyboardLayoutIds()
		{
			return null;
		}

		public InputLayout GetKeyboardLayout(int index)
		{
			return null;
		}

		public InputLayout GetKeyboardLayout(string name)
		{
			return null;
		}

		public InputLayout GetKeyboardLayoutById(int id)
		{
			return null;
		}

		public int GetKeyboardLayoutId(string name)
		{
			return 0;
		}

		public int IndexOfKeyboardLayout(int id)
		{
			return 0;
		}

		public int IndexOfKeyboardLayout(string name)
		{
			return 0;
		}

		public string GetKeyboardLayoutNameById(int id)
		{
			return null;
		}

		public void AddMouseLayout()
		{
		}

		public void InsertMouseLayout(int index)
		{
		}

		public void DeleteMouseLayout(int index)
		{
		}

		public bool ReorderMouseLayout(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateMouseLayout(int index, bool duplicateMaps)
		{
		}

		public int GetMouseLayoutMapCount(int id)
		{
			return 0;
		}

		public int GetMouseLayoutIndex(int id)
		{
			return 0;
		}

		public string[] GetMouseLayoutNames()
		{
			return null;
		}

		public int[] GetMouseLayoutIds()
		{
			return null;
		}

		public InputLayout GetMouseLayout(int index)
		{
			return null;
		}

		public InputLayout GetMouseLayout(string name)
		{
			return null;
		}

		public InputLayout GetMouseLayoutById(int id)
		{
			return null;
		}

		public int GetMouseLayoutId(string name)
		{
			return 0;
		}

		public int IndexOfMouseLayout(int id)
		{
			return 0;
		}

		public int IndexOfMouseLayout(string name)
		{
			return 0;
		}

		public string GetMouseLayoutNameById(int id)
		{
			return null;
		}

		public void AddCustomControllerLayout()
		{
		}

		public void InsertCustomControllerLayout(int index)
		{
		}

		public void DeleteCustomControllerLayout(int index)
		{
		}

		public bool ReorderCustomControllerLayout(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateCustomControllerLayout(int index, bool duplicateMaps)
		{
		}

		public int GetCustomControllerLayoutMapCount(int id)
		{
			return 0;
		}

		public int GetCustomControllerLayoutIndex(int id)
		{
			return 0;
		}

		public string[] GetCustomControllerLayoutNames()
		{
			return null;
		}

		public int[] GetCustomControllerLayoutIds()
		{
			return null;
		}

		public InputLayout GetCustomControllerLayout(int index)
		{
			return null;
		}

		public InputLayout GetCustomControllerLayout(string name)
		{
			return null;
		}

		public InputLayout GetCustomControllerLayoutById(int id)
		{
			return null;
		}

		public int GetCustomControllerLayoutId(string name)
		{
			return 0;
		}

		public int IndexOfCustomControllerLayout(int id)
		{
			return 0;
		}

		public int IndexOfCustomControllerLayout(string name)
		{
			return 0;
		}

		public string GetCustomControllerLayoutNameById(int id)
		{
			return null;
		}

		public string GetLayoutNameById(ControllerType controllerType, int id)
		{
			return null;
		}

		internal ControllerMap zQmRzuxxMzBJuAOvKUHvmpMofonu(Controller P_0, int P_1, int P_2)
		{
			return null;
		}

		public ControllerMap_Editor GetJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			return null;
		}

		public ControllerMap_Editor GetJoystickMapById(int id, out int joystickMapIndex)
		{
			joystickMapIndex = default(int);
			return null;
		}

		public List<ControllerMap_Editor> GetJoystickMaps(Guid hardwareGuid)
		{
			return null;
		}

		public int GetJoystickMapId(int categoryId, Guid hardwareGuid, int layoutId)
		{
			return 0;
		}

		public bool HasJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			return false;
		}

		public bool HasJoystickMap(Guid hardwareGuid)
		{
			return false;
		}

		public bool HasJoystickMapInCategory(Guid hardwareGuid, int categoryId)
		{
			return false;
		}

		public bool CreateJoystickMap(int categoryId, Guid joystickOrTemplateGuid, int layoutId)
		{
			return false;
		}

		public void DeleteJoystickMap(int id)
		{
		}

		public int DuplicateJoystickMap(int index)
		{
			return 0;
		}

		internal JoystickMap WPVOclMlLgNtstndhCwCmTydQORu(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return null;
		}

		internal JoystickMap cEwcgjjduDknbeUijZLXUaDeJMmZ(Joystick P_0, int P_1, int P_2)
		{
			return null;
		}

		private JoystickMap PGcERRoVkZhOPEbzaHLisselgpEHb(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return null;
		}

		private ControllerMap_Editor jBTgxxuaVNajhAxphArIFJSwIcsWA(int P_0, Guid P_1, int P_2, bool P_3)
		{
			return null;
		}

		private ControllerMap_Editor OdReOUIlysgIYAyaRjgMygHcNaNmA(int P_0, Guid P_1, int P_2)
		{
			return null;
		}

		private JoystickMap ggbTVbosKNQWWZBcbkXHkvtCvYth(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			return null;
		}

		private JoystickMap AwbQbyZXTXvvipboSGrOHdWXJcWw(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			return null;
		}

		public ControllerMap_Editor GetKeyboardMap(int categoryId, int layoutId)
		{
			return null;
		}

		public int GetKeyboardMapId(int categoryId, int layoutId)
		{
			return 0;
		}

		public bool HasKeyboardMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			return false;
		}

		public bool CreateKeyboardMap(int categoryId, int layoutId)
		{
			return false;
		}

		public void DeleteKeyboardMap(int id)
		{
		}

		public int DuplicateKeyboardMap(int index)
		{
			return 0;
		}

		public ControllerMap_Editor GetKeyboardMapById(int id, out int keyboardMapIndex)
		{
			keyboardMapIndex = default(int);
			return null;
		}

		public KeyboardMap FindKeyboardMap_Game(Keyboard keyboard, int categoryId, int layoutId)
		{
			return null;
		}

		public bool HasKeyboardMapInCategory(int categoryId)
		{
			return false;
		}

		public bool HasKeyboardMapInLayout(int categoryId, int layoutId)
		{
			return false;
		}

		public ControllerMap_Editor GetMouseMap(int categoryId, int layoutId)
		{
			return null;
		}

		public int GetMouseMapId(int categoryId, int layoutId)
		{
			return 0;
		}

		public bool HasMouseMap(int categoryId, Guid hardwareGuid, int layoutId)
		{
			return false;
		}

		public bool CreateMouseMap(int categoryId, int layoutId)
		{
			return false;
		}

		public void DeleteMouseMap(int id)
		{
		}

		public int DuplicateMouseMap(int index)
		{
			return 0;
		}

		public ControllerMap_Editor GetMouseMapById(int id, out int mouseMapIndex)
		{
			mouseMapIndex = default(int);
			return null;
		}

		public MouseMap FindMouseMap_Game(Mouse mouse, int categoryId, int layoutId)
		{
			return null;
		}

		public bool HasMouseMapInCategory(int categoryId)
		{
			return false;
		}

		public bool HasMouseMapInLayout(int categoryId, int layoutId)
		{
			return false;
		}

		public ControllerMap_Editor GetCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			return null;
		}

		public ControllerMap_Editor GetCustomControllerMapById(int mapId, out int customControllerMapIndex)
		{
			customControllerMapIndex = default(int);
			return null;
		}

		public List<ControllerMap_Editor> GetCustomControllerMaps(int controllerUid)
		{
			return null;
		}

		public int GetCustomControllerMapId(int categoryId, int controllerUid, int layoutId)
		{
			return 0;
		}

		public bool HasCustomControllerMap(int mapId, int categoryId, int layoutId)
		{
			return false;
		}

		public bool HasCustomControllerMap(int mapId)
		{
			return false;
		}

		public bool HasCustomControllerMapInCategory(int controllerUid, int categoryId)
		{
			return false;
		}

		public bool CreateCustomControllerMap(int categoryId, int controllerUid, int layoutId)
		{
			return false;
		}

		public void DeleteCustomControllerMap(int mapId)
		{
		}

		public int DuplicateCustomControllerMap(int index)
		{
			return 0;
		}

		internal CustomControllerMap CtlgoRWNZjPivjmbrsinEqCNgeri(Guid P_0, int P_1, int P_2)
		{
			return null;
		}

		internal CustomControllerMap RifLOhoZwdAImmgTfQyFqnUIpNjg(int P_0, int P_1, int P_2)
		{
			return null;
		}

		private CustomControllerMap FaYaHlwggyIigVQRlpTYtEOzQUXp(CustomController_Editor P_0, int P_1, int P_2)
		{
			return null;
		}

		private ControllerMap_Editor eOpnYtonskVCiDjvrJiuaddceZm(int P_0, int P_1, int P_2, bool P_3)
		{
			return null;
		}

		private ControllerMap_Editor AbrGPQhOayKFPptSxxZprfuqipTrA(int P_0, int P_1, int P_2)
		{
			return null;
		}

		public void DeleteControllerMap(ControllerType controllerType, int id)
		{
		}

		public ControllerMap_Editor GetControllerMapByIndex(ControllerType controllerType, int index)
		{
			return null;
		}

		public ControllerMap_Editor GetControllerMapById(ControllerType controllerType, int id, out int controllerMapIndex)
		{
			controllerMapIndex = default(int);
			return null;
		}

		public int DuplicateControllerMap(ControllerType controllerType, int index)
		{
			return 0;
		}

		internal ControllerTemplateMap OWKJfjNzsEBgUBrwFaOawApxSgNn(Guid P_0, int P_1, int P_2)
		{
			return null;
		}

		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void AddCustomController()
		{
		}

		public void AddCustomController(Guid typeGuid)
		{
		}

		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void InsertCustomController(int index)
		{
		}

		public void InsertCustomController(int index, Guid typeGuid)
		{
		}

		public void DeleteCustomController(int index)
		{
		}

		public bool ReorderCustomController(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
		public void DuplicateCustomController(int index, bool duplicateMaps)
		{
		}

		public void DuplicateCustomController(int index, bool duplicateMaps, Guid typeGuid)
		{
		}

		public int GetCustomControllerMapCount(int controllerUid)
		{
			return 0;
		}

		public int GetCustomControllerIndex(int id)
		{
			return 0;
		}

		public string[] GetCustomControllerNames()
		{
			return null;
		}

		public int[] GetCustomControllerIds()
		{
			return null;
		}

		public Guid[] GetCustomControllerGuids()
		{
			return null;
		}

		public CustomController_Editor GetCustomController(int index)
		{
			return null;
		}

		public CustomController_Editor GetCustomController(string name)
		{
			return null;
		}

		public CustomController_Editor GetCustomControllerById(int id)
		{
			return null;
		}

		public CustomController_Editor GetCustomControllerByHardwareTypeGuid(Guid hardwareTypeGuid)
		{
			return null;
		}

		public int GetCustomControllerId(string name)
		{
			return 0;
		}

		public int IndexOfCustomController(int id)
		{
			return 0;
		}

		public int IndexOfCustomController(string name)
		{
			return 0;
		}

		public int IndexOfCustomController(Guid hardwareTypeGuid)
		{
			return 0;
		}

		public string GetCustomControllerNameById(int id)
		{
			return null;
		}

		public void AddControllerMapLayoutManagerRuleSet()
		{
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
		}

		public void DeleteControllerMapLayoutManagerRuleSet(int index)
		{
		}

		public bool ReorderControllerMapLayoutManagerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateControllerMapLayoutManagerRuleSet(int index)
		{
		}

		public int GetControllerMapLayoutManagerRuleSetUsedCount(int id)
		{
			return 0;
		}

		public int GetControllerMapLayoutManagerRuleSetIndex(int id)
		{
			return 0;
		}

		public string[] GetControllerMapLayoutManagerRuleSetNames()
		{
			return null;
		}

		public int[] GetControllerMapLayoutManagerRuleSetIds()
		{
			return null;
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(int index)
		{
			return null;
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(string name)
		{
			return null;
		}

		public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSetById(int id)
		{
			return null;
		}

		public int GetControllerMapLayoutManagerRuleSetId(string name)
		{
			return 0;
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(int id)
		{
			return 0;
		}

		public int IndexOfControllerMapLayoutManagerRuleSet(string name)
		{
			return 0;
		}

		public string GetControllerMapLayoutManagerRuleSetNameById(int id)
		{
			return null;
		}

		public int GetControllerMapLayoutManagerRuleSetCount()
		{
			return 0;
		}

		public void AddControllerMapEnablerRuleSet()
		{
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
		}

		public void DeleteControllerMapEnablerRuleSet(int index)
		{
		}

		public bool ReorderControllerMapEnablerRuleSet(int index, bool offsetDown, bool offsetNow)
		{
			return false;
		}

		public void DuplicateControllerMapEnablerRuleSet(int index)
		{
		}

		public int GetControllerMapEnablerRuleSetUsedCount(int id)
		{
			return 0;
		}

		public int GetControllerMapEnablerRuleSetIndex(int id)
		{
			return 0;
		}

		public string[] GetControllerMapEnablerRuleSetNames()
		{
			return null;
		}

		public int[] GetControllerMapEnablerRuleSetIds()
		{
			return null;
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(int index)
		{
			return null;
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(string name)
		{
			return null;
		}

		public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSetById(int id)
		{
			return null;
		}

		public int GetControllerMapEnablerRuleSetId(string name)
		{
			return 0;
		}

		public int IndexOfControllerMapEnablerRuleSet(int id)
		{
			return 0;
		}

		public int IndexOfControllerMapEnablerRuleSet(string name)
		{
			return 0;
		}

		public string GetControllerMapEnablerRuleSetNameById(int id)
		{
			return null;
		}

		public int GetControllerMapEnablerRuleSetCount()
		{
			return 0;
		}

		public int GetNewPlayerId()
		{
			return 0;
		}

		public int GetNewActionId()
		{
			return 0;
		}

		public int GetNewActionCategoryId()
		{
			return 0;
		}

		public int GetNewInputBehaviorId()
		{
			return 0;
		}

		public int GetNewMapCategoryId()
		{
			return 0;
		}

		public int GetNewJoystickLayoutId()
		{
			return 0;
		}

		public int GetNewKeyboardLayoutId()
		{
			return 0;
		}

		public int GetNewMouseLayoutId()
		{
			return 0;
		}

		public int GetNewCustomControllerLayoutId()
		{
			return 0;
		}

		public int GetNewJoystickMapId()
		{
			return 0;
		}

		public int GetNewKeyboardMapId()
		{
			return 0;
		}

		public int GetNewMouseMapId()
		{
			return 0;
		}

		public int GetNewCustomControllerMapId()
		{
			return 0;
		}

		public int GetNewCustomControllerId()
		{
			return 0;
		}

		public int GetNewControllerMapLayoutManagerRuleSetId()
		{
			return 0;
		}

		public int GetNewControllerMapEnablerRuleSetId()
		{
			return 0;
		}

		private Player_Editor bMqQXhxpidxfbkMdSPUoUwVIYOcA()
		{
			return null;
		}

		private InputAction AVhftbtpOCItSPtUkKemexEDrPsr()
		{
			return null;
		}

		private InputActionCategory BXRCuoivpEFlcZwEOgCZEPaKpNRzb()
		{
			return null;
		}

		private InputBehavior gBKsetWorVEHZBmWCwyLfWgiRzxH()
		{
			return null;
		}

		private InputMapCategory ddOGPgfEmxqDYaAQdBPGkbDmRgsGA()
		{
			return null;
		}

		private InputLayout XCdpwEERaNyDjkgdLYgyRCuZkeVL()
		{
			return null;
		}

		private InputLayout EHbblLOHKEknDxsWAVhotHlKDSiFA()
		{
			return null;
		}

		private InputLayout witcriZTmQilPiutfkiQjGTJCSjt()
		{
			return null;
		}

		private InputLayout gSoqHosvaBTVCOlfnVjNvYbtfBWf()
		{
			return null;
		}

		private CustomController_Editor twbcHHCOYnqAKoQjczrRMoHhkElS(Guid P_0)
		{
			return null;
		}

		private ControllerMapLayoutManager_RuleSet_Editor IQNdKePAUtDmcAiMNMmCDftESxULB()
		{
			return null;
		}

		private ControllerMapEnabler_RuleSet_Editor RntnkfQCtDkZINiqhZSBrCRSjQgc()
		{
			return null;
		}

		private ControllerMap_Editor pXnMPNtQeixWUfLJOgtKphZivjiA(List<ControllerMap_Editor> P_0, int P_1, int P_2)
		{
			return null;
		}

		private ControllerMap_Editor gXdNZnuNPtktBbUoiUByTGyPnpWe(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			return null;
		}

		private ControllerMap_Editor LaBaVgDhhzjPyMCVwQpEasLWwFgW(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			return null;
		}

		private void roLDJAaglAzmgrDTbgaDfcooJbNrA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
		}

		internal void haVEMEnjGwwMTYvaOdejpHcywGYu()
		{
		}

		internal void IJQYwmIOuZPNQKGehzwMMTRYGqtM()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return null;
		}
	}
}
