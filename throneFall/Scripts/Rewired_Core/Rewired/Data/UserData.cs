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
		private static class dBWeNSinAPMSsuxrqBtpUDILPeZk
		{
			[DefaultMember("Item")]
			private class EQMTLAegHWiDWcBWrbBOUDPgtUvn
			{
				public enum avjRWxrTQhVuPPOElqssnifNHKHO
				{
					origId = 0,
					otherId = 1,
					finalId = 2
				}

				public int OinPCWCkqCNaJlkbIhPVZvPGxROv;

				public int XHQBrhCsnDhHYingzZwFuzxTAywc;

				public int UXagnnFilWlyrvvXAgibstGKPJEPA;

				public int oTAhyVOzjSOgjCqeBAeQNQIgAdVE
				{
					get
					{
						return P_0 switch
						{
							avjRWxrTQhVuPPOElqssnifNHKHO.origId => OinPCWCkqCNaJlkbIhPVZvPGxROv, 
							avjRWxrTQhVuPPOElqssnifNHKHO.otherId => XHQBrhCsnDhHYingzZwFuzxTAywc, 
							avjRWxrTQhVuPPOElqssnifNHKHO.finalId => UXagnnFilWlyrvvXAgibstGKPJEPA, 
							_ => throw new NotImplementedException(), 
						};
					}
					set
					{
						switch (avjRWxrTQhVuPPOElqssnifNHKHO2)
						{
						case avjRWxrTQhVuPPOElqssnifNHKHO.origId:
							OinPCWCkqCNaJlkbIhPVZvPGxROv = num;
							break;
						case avjRWxrTQhVuPPOElqssnifNHKHO.otherId:
							XHQBrhCsnDhHYingzZwFuzxTAywc = num;
							break;
						case avjRWxrTQhVuPPOElqssnifNHKHO.finalId:
							UXagnnFilWlyrvvXAgibstGKPJEPA = num;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public EQMTLAegHWiDWcBWrbBOUDPgtUvn(int P_0, int P_1, int P_2)
				{
					OinPCWCkqCNaJlkbIhPVZvPGxROv = P_0;
					XHQBrhCsnDhHYingzZwFuzxTAywc = P_1;
					UXagnnFilWlyrvvXAgibstGKPJEPA = P_2;
				}

				public virtual string tMBCKdlPYNEFOAEyndLqjTHxWOXT()
				{
					return string.Concat(string.Concat("" + StringTools.WriteVar("origId", OinPCWCkqCNaJlkbIhPVZvPGxROv), StringTools.WriteVar("otherId", XHQBrhCsnDhHYingzZwFuzxTAywc)), StringTools.WriteVar("finalId", UXagnnFilWlyrvvXAgibstGKPJEPA));
				}
			}

			private class IgBCFFIHIjGYbsbgcSQvofWiUNHu<_0001>
			{
				public _0001 hHSeElCBhUiAnxdLaEOEbkHjzaTAB;

				public _0001 FlTDvwocioCFKVigEyEpIfMzkjCC;

				public EQMTLAegHWiDWcBWrbBOUDPgtUvn.avjRWxrTQhVuPPOElqssnifNHKHO pNJQYDJDastMNOhpwKvucKFLhVdG;

				public IList<_0001> PMObaMRavvLiNGNkmHbMQjgVdRnV;

				public bool PgxZRdSdZvKfoiieShSPKLmcdCMpA;

				public IgBCFFIHIjGYbsbgcSQvofWiUNHu(_0001 P_0, _0001 P_1, EQMTLAegHWiDWcBWrbBOUDPgtUvn.avjRWxrTQhVuPPOElqssnifNHKHO P_2, IList<_0001> P_3, bool P_4)
				{
					hHSeElCBhUiAnxdLaEOEbkHjzaTAB = P_0;
					FlTDvwocioCFKVigEyEpIfMzkjCC = P_1;
					pNJQYDJDastMNOhpwKvucKFLhVdG = P_2;
					PMObaMRavvLiNGNkmHbMQjgVdRnV = P_3;
					PgxZRdSdZvKfoiieShSPKLmcdCMpA = P_4;
				}
			}

			[Serializable]
			private sealed class QUnJklwLzEfXnNCHxZgYmiyBSnAn
			{
				public static readonly QUnJklwLzEfXnNCHxZgYmiyBSnAn _003C_003E9 = new QUnJklwLzEfXnNCHxZgYmiyBSnAn();

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

				internal int XBuzqKReKyGFpujpJrAagjpsAofs(InputActionCategory P_0)
				{
					return P_0.id;
				}

				internal string kvLGbDqVClQyQLFRsQBEbOQQJpkB(InputActionCategory P_0)
				{
					return P_0.name;
				}

				internal int ZKyMTWnqmQbLDCqPiSkRfQctFmdEA(InputActionCategory P_0, IList<InputActionCategory> P_1)
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

				internal int XBClvYtERSOvOWPxkCiafcFUXQxO(InputBehavior P_0)
				{
					return P_0.id;
				}

				internal string dUVjHTPmbUvvgJwCTWbQwNsvCYaC(InputBehavior P_0)
				{
					return P_0.name;
				}

				internal int eAtMGKpQLorSHRXAdFfAxiMhHEBL(InputBehavior P_0, IList<InputBehavior> P_1)
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

				internal int IaWAhVPxSYcThQdUOlKrKqiLFuov(InputAction P_0)
				{
					return P_0.id;
				}

				internal string vzZYBKkbUHltcaLEdnXXmqjEVlGE(InputAction P_0)
				{
					return P_0.name;
				}

				internal int gVYbQkfnimycKwNfDhNDCLDAldGCb(InputAction P_0, IList<InputAction> P_1)
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

				internal int BjmHHsVNogBhHMZDtTTixhgUfjmN(InputMapCategory P_0)
				{
					return P_0.id;
				}

				internal string FwPkbHiTmtkevreiWZqEojtxwuei(InputMapCategory P_0)
				{
					return P_0.name;
				}

				internal int GUJRJLYILMXVXuUPaOCNgpCCbOvP(InputMapCategory P_0, IList<InputMapCategory> P_1)
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

				internal int eogZjPeVMMlTnEIyBkUNbyrISqYI(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string eWcEIagfaHcHWAKwlJaWbmtAlDyeb(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int zgmKHvifhXpGEIGSYXabuHDtMyMk(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int EzNpSZfIjOsVhMeANVCOcNJewrgi(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string AEkTKQhoYlnGxtJooGQMfPIijSGFb(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int ouZFIuQLeYGYObvkYKiDYyyecYxOA(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int FSDDXjRnceRoBphbcOFxKUGJrwEi(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string ZEjVkdNsfJDNDgIBrQmqEEGgqmDDA(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int ilIfmMJPaiReVquDcbjmRFvdQrmt(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int pruwmeFXYUdYbbqVneeiOBrRYrcm(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string NVpTsxwtyguVJOcbOCZuUcQOAuCy(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int VmWylnGLLMCatIykwXYozXIkQZOj(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int XZljKRvHBMIAzDNqUuuqAJKveCHRA(CustomController_Editor P_0)
				{
					return P_0.id;
				}

				internal string ADvuFdrGGhgNnrwsPFCVbhCKVreEA(CustomController_Editor P_0)
				{
					return P_0.name;
				}

				internal int FKVUJuAJHkuaXYxtJtwiDblAKCwK(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
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

				internal int wLyqjdgCHhdVJebUFcwvdVOOHWAE(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string SOwBBPdkrDzdgQXfvSBqMkOzLqllA(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int eLhUpqoqEGsoiWxCkjasMlkFCGnIA(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
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

				internal int jDzhyxWqScOitFMXCchwikIRolCbA(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string JANcDkgLBLmCbvHQrNvLqSQlZyQN(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int SLsyqArVOmiPwSdwiXXKwdjWcMBKA(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
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

				internal int UmDiZvKHBCccKtmDweewHhYWSaaF(Player_Editor P_0)
				{
					return P_0.id;
				}

				internal string cqKxioLlprbvqeLvyRivFgzNEgQW(Player_Editor P_0)
				{
					return P_0.name;
				}

				internal int lwxRWEyYGrHwUCSikOjXoDWpvcGy(Player_Editor P_0, IList<Player_Editor> P_1)
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

				internal int ltZHAQywbXMLIVeuXvczjRhuUoOl(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
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

				internal int OkwvNNXgoGtVcQQyfWmstjuhsEiP(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
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

				internal int mkZcXPEpBSyrHDoMZhAwfVFYSmfxA(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string GDClhulEpQxGfijpWHLIjKyXpLjsA(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int SIZgeaeHjGPbKTVpeDDCxaujpFuX(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int UseZVzVtqBgwuzEPQabMakFyxRvp(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string jcYzWKcAtxQkczEPpGrlcCsoXzsq(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int DYYKoyDVpelbFTsDyjfGYDYSULwV(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int MkceKCBFHOgcDXeXiYhpIsdhFffPA(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string DoYWOBvicnaUIboNSExkevAdJlUXB(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int qIzgRniubEZeiarXubFkpAysBdeIA(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int rUyCtuZAsptZwDlSSADILngghXpo(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string XJKqiCmLTVChytChnKkAQOAGsDJr(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int avCzYJYjOXfsMKMVJzPmLgSTannaA(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class HpvjqnJtoIuQbndDldBUDpeLFqZS
			{
				public UserData jgngkWUxoNxoFJFTgPZKYgkaBxct;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> JiomnlLLhMegHjHPWRwearYjoLFab;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> hkgRgEDQhsPHDTarEfKsDaPJmkZL;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> oXGYxUoQoZMvQVskouKdXDqCrfqp;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> LMCAGynufBIYmiXvgmksgHkcqAQqA;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> PAwdgHXCvxNbVUiPJqqSaxUKyQHf;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> dGKWvLEBQLtPElHWfFbjYlPTwlVp;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> QWQVzEAharVPXiybbWvBhCJayxvK;

				public Func<ControllerType, List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>> oUIcYRDxWFYdBxlBGfdrBVYdywldB;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> xtsSBWrlCFWJaXOtBLoyVJjBCpTh;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> JdhApSsVtKSDZmDVGggcGLwJolnI;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> ptkTLzuqAuHdjAEQJBJRCUuezLOaB;

				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> woGVtgbnGtfAnBkFXNFqtPwtviZc;

				internal InputActionCategory WTKEYLuuKSmVSNzvxDjSVufdtKRU(IgBCFFIHIjGYbsbgcSQvofWiUNHu<InputActionCategory> P_0)
				{
					InputActionCategory inputActionCategory = JsonTools.Clone(P_0.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					InputActionCategory inputActionCategory2;
					if (P_0.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						inputActionCategory2 = P_0.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddActionCategory();
						inputActionCategory2 = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					inputActionCategory.id = inputActionCategory2.id;
					int index = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(inputActionCategory2);
					P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = inputActionCategory;
					return inputActionCategory;
				}

				internal InputBehavior SPTndQFQxfrdomnFXgpTdKhxDbexA(IgBCFFIHIjGYbsbgcSQvofWiUNHu<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					InputBehavior inputBehavior2;
					if (P_0.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						inputBehavior2 = P_0.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddInputBehavior();
						inputBehavior2 = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(inputBehavior2);
					P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = inputBehavior;
					return inputBehavior;
				}

				internal InputAction xPuCGOUTcDFJFznKAQomeYdGHhIt(IgBCFFIHIjGYbsbgcSQvofWiUNHu<InputAction> P_0)
				{
					phomDKiyHlXRKcmwlqbXHRIfPYeF phomDKiyHlXRKcmwlqbXHRIfPYeF2 = new phomDKiyHlXRKcmwlqbXHRIfPYeF();
					phomDKiyHlXRKcmwlqbXHRIfPYeF2.mgVDpFCXgeduGYNOqShtRndgyMgCA = P_0;
					InputAction inputAction = JsonTools.Clone(phomDKiyHlXRKcmwlqbXHRIfPYeF2.mgVDpFCXgeduGYNOqShtRndgyMgCA.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					int num = JiomnlLLhMegHjHPWRwearYjoLFab.Find(phomDKiyHlXRKcmwlqbXHRIfPYeF2.NVxqASKHxAWRDkwLoimRJvOsnfTA)?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? 0;
					InputAction inputAction2;
					if (phomDKiyHlXRKcmwlqbXHRIfPYeF2.mgVDpFCXgeduGYNOqShtRndgyMgCA.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						inputAction2 = phomDKiyHlXRKcmwlqbXHRIfPYeF2.mgVDpFCXgeduGYNOqShtRndgyMgCA.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddAction(num);
						inputAction2 = phomDKiyHlXRKcmwlqbXHRIfPYeF2.mgVDpFCXgeduGYNOqShtRndgyMgCA.PMObaMRavvLiNGNkmHbMQjgVdRnV[phomDKiyHlXRKcmwlqbXHRIfPYeF2.mgVDpFCXgeduGYNOqShtRndgyMgCA.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					int num2 = hkgRgEDQhsPHDTarEfKsDaPJmkZL.Find(phomDKiyHlXRKcmwlqbXHRIfPYeF2.czfHGcybXcQnCnVTabxRbicJuKCI)?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = num2;
					int index = phomDKiyHlXRKcmwlqbXHRIfPYeF2.mgVDpFCXgeduGYNOqShtRndgyMgCA.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(inputAction2);
					phomDKiyHlXRKcmwlqbXHRIfPYeF2.mgVDpFCXgeduGYNOqShtRndgyMgCA.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = inputAction;
					return inputAction;
				}

				internal InputLayout GzkFLOfGjvMNaPoKxXgcCPuaMJPQA(IgBCFFIHIjGYbsbgcSQvofWiUNHu<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					InputLayout inputLayout2;
					if (P_0.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						inputLayout2 = P_0.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddKeyboardLayout();
						inputLayout2 = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(inputLayout2);
					P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout wvJgubgpmsItuXCmIjRCWxpoFfQe(IgBCFFIHIjGYbsbgcSQvofWiUNHu<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					InputLayout inputLayout2;
					if (P_0.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						inputLayout2 = P_0.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddMouseLayout();
						inputLayout2 = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(inputLayout2);
					P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout mxpwDGpshQFvtiCFQwhlpCrrinxj(IgBCFFIHIjGYbsbgcSQvofWiUNHu<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					InputLayout inputLayout2;
					if (P_0.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						inputLayout2 = P_0.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddJoystickLayout();
						inputLayout2 = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(inputLayout2);
					P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout MyqLZQXxjzmAdBUaqJFybYFrqHZy(IgBCFFIHIjGYbsbgcSQvofWiUNHu<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					InputLayout inputLayout2;
					if (P_0.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						inputLayout2 = P_0.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddCustomControllerLayout();
						inputLayout2 = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(inputLayout2);
					P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = inputLayout;
					return inputLayout;
				}

				internal List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> YoxKfDvFxaJzJJbiWEuPwgzuNvae(ControllerType P_0)
				{
					return P_0 switch
					{
						ControllerType.Keyboard => oXGYxUoQoZMvQVskouKdXDqCrfqp, 
						ControllerType.Mouse => LMCAGynufBIYmiXvgmksgHkcqAQqA, 
						ControllerType.Joystick => PAwdgHXCvxNbVUiPJqqSaxUKyQHf, 
						ControllerType.Custom => dGKWvLEBQLtPElHWfFbjYlPTwlVp, 
						_ => throw new NotImplementedException(), 
					};
				}

				internal CustomController_Editor ItACrRQgsmlPNKDvsWeCOcjUsGwD(IgBCFFIHIjGYbsbgcSQvofWiUNHu<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					CustomController_Editor customController_Editor2;
					if (P_0.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						customController_Editor2 = P_0.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddCustomController(Guid.Empty);
						customController_Editor2 = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(customController_Editor2);
					P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = customController_Editor;
					return customController_Editor;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor GfiHMUCkephJMowuqRDdETrXqfCt(IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					KYsrtHXNZBRBtqXcnVEcxNHIDBWS kYsrtHXNZBRBtqXcnVEcxNHIDBWS = new KYsrtHXNZBRBtqXcnVEcxNHIDBWS();
					kYsrtHXNZBRBtqXcnVEcxNHIDBWS.UdmRgewnWjyWXdKfuydHCrZdBUUh = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(kYsrtHXNZBRBtqXcnVEcxNHIDBWS.UdmRgewnWjyWXdKfuydHCrZdBUUh.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
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
							vUDbORDrhpnSiCmfeEgKTiNBErxd vUDbORDrhpnSiCmfeEgKTiNBErxd2 = new vUDbORDrhpnSiCmfeEgKTiNBErxd();
							vUDbORDrhpnSiCmfeEgKTiNBErxd2.fnZaGckHsnaqnaDgANFGKfpbvfHld = kYsrtHXNZBRBtqXcnVEcxNHIDBWS;
							vUDbORDrhpnSiCmfeEgKTiNBErxd2.FXShBdwgOwxXdOQwHMNiBNLKxSKk = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = QWQVzEAharVPXiybbWvBhCJayxvK.Find(vUDbORDrhpnSiCmfeEgKTiNBErxd2.FimCmKHKxOmlcxtvUFtiWMqsfzYS);
							if (eQMTLAegHWiDWcBWrbBOUDPgtUvn == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + vUDbORDrhpnSiCmfeEgKTiNBErxd2.FXShBdwgOwxXdOQwHMNiBNLKxSKk);
							}
							else
							{
								list.Add(eQMTLAegHWiDWcBWrbBOUDPgtUvn.UXagnnFilWlyrvvXAgibstGKPJEPA);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						VgRFQwDkhMNTIjyavMwlnBhstkyWA vgRFQwDkhMNTIjyavMwlnBhstkyWA = new VgRFQwDkhMNTIjyavMwlnBhstkyWA();
						vgRFQwDkhMNTIjyavMwlnBhstkyWA.WhpAHpgzbBdzWjGsZnYiwhCSCSobA = kYsrtHXNZBRBtqXcnVEcxNHIDBWS;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> list2 = oUIcYRDxWFYdBxlBGfdrBVYdywldB(controllerType);
							vgRFQwDkhMNTIjyavMwlnBhstkyWA.VAoUWInmNWIofhIzttzOELHXFQlu = controllerMapLayoutManager_Rule_Editor2.layoutId;
							EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = list2.Find(vgRFQwDkhMNTIjyavMwlnBhstkyWA.eTYfIIxYCoYPrIMWJzNlKDQQfnkK);
							if (eQMTLAegHWiDWcBWrbBOUDPgtUvn2 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + vgRFQwDkhMNTIjyavMwlnBhstkyWA.VAoUWInmNWIofhIzttzOELHXFQlu);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = eQMTLAegHWiDWcBWrbBOUDPgtUvn2.UXagnnFilWlyrvvXAgibstGKPJEPA;
							}
						}
					}
					int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							CkUBVsgQgeEUOdqWWQBPTAZbkdFt ckUBVsgQgeEUOdqWWQBPTAZbkdFt = new CkUBVsgQgeEUOdqWWQBPTAZbkdFt();
							ckUBVsgQgeEUOdqWWQBPTAZbkdFt.KurMdfqyIfSOWHWQLIzBRWHTtVee = kYsrtHXNZBRBtqXcnVEcxNHIDBWS;
							List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> list3 = xtsSBWrlCFWJaXOtBLoyVJjBCpTh;
							ckUBVsgQgeEUOdqWWQBPTAZbkdFt.kQiwrEBgwdwgAkTJUAyuaubQsbsA = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn3 = list3.Find(ckUBVsgQgeEUOdqWWQBPTAZbkdFt.ZTKpOFTbGCeRGcPmBcFSWxrVpLFS);
							if (eQMTLAegHWiDWcBWrbBOUDPgtUvn3 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + ckUBVsgQgeEUOdqWWQBPTAZbkdFt.kQiwrEBgwdwgAkTJUAyuaubQsbsA);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = eQMTLAegHWiDWcBWrbBOUDPgtUvn3.UXagnnFilWlyrvvXAgibstGKPJEPA;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (kYsrtHXNZBRBtqXcnVEcxNHIDBWS.UdmRgewnWjyWXdKfuydHCrZdBUUh.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = kYsrtHXNZBRBtqXcnVEcxNHIDBWS.UdmRgewnWjyWXdKfuydHCrZdBUUh.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = kYsrtHXNZBRBtqXcnVEcxNHIDBWS.UdmRgewnWjyWXdKfuydHCrZdBUUh.PMObaMRavvLiNGNkmHbMQjgVdRnV[kYsrtHXNZBRBtqXcnVEcxNHIDBWS.UdmRgewnWjyWXdKfuydHCrZdBUUh.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = kYsrtHXNZBRBtqXcnVEcxNHIDBWS.UdmRgewnWjyWXdKfuydHCrZdBUUh.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					kYsrtHXNZBRBtqXcnVEcxNHIDBWS.UdmRgewnWjyWXdKfuydHCrZdBUUh.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				internal ControllerMapEnabler_RuleSet_Editor guzePciAbvuHKlQdrPcQbpEcDKpoA(IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					XiGfbBJZiWcSMOQQWSrPfVsphanL xiGfbBJZiWcSMOQQWSrPfVsphanL = new XiGfbBJZiWcSMOQQWSrPfVsphanL();
					xiGfbBJZiWcSMOQQWSrPfVsphanL.qXkhjZekahxPWgtwKIOaTDyHsogT = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(xiGfbBJZiWcSMOQQWSrPfVsphanL.qXkhjZekahxPWgtwKIOaTDyHsogT.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
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
							nVokvzWXqvNbjJMsdJDAxhaigkJB nVokvzWXqvNbjJMsdJDAxhaigkJB2 = new nVokvzWXqvNbjJMsdJDAxhaigkJB();
							nVokvzWXqvNbjJMsdJDAxhaigkJB2.WxrWakdKvIeEJITyZgZJRWHrpIiN = xiGfbBJZiWcSMOQQWSrPfVsphanL;
							nVokvzWXqvNbjJMsdJDAxhaigkJB2.rLWkdpXEkGmEOCtPWNeXKShIWVTh = controllerMapEnabler_Rule_Editor.categoryIds[j];
							EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = QWQVzEAharVPXiybbWvBhCJayxvK.Find(nVokvzWXqvNbjJMsdJDAxhaigkJB2.PhBlsadsLtiISUPtfETdgBMPTvcm);
							if (eQMTLAegHWiDWcBWrbBOUDPgtUvn == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + nVokvzWXqvNbjJMsdJDAxhaigkJB2.rLWkdpXEkGmEOCtPWNeXKShIWVTh);
							}
							else
							{
								list.Add(eQMTLAegHWiDWcBWrbBOUDPgtUvn.UXagnnFilWlyrvvXAgibstGKPJEPA);
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
						List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> list2 = oUIcYRDxWFYdBxlBGfdrBVYdywldB(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							NiyaGUViWkSNrGGZUPXVBnWKffsi niyaGUViWkSNrGGZUPXVBnWKffsi = new NiyaGUViWkSNrGGZUPXVBnWKffsi();
							niyaGUViWkSNrGGZUPXVBnWKffsi.TCxSdYXiDzvtjrxceQCHMWhDePbS = xiGfbBJZiWcSMOQQWSrPfVsphanL;
							niyaGUViWkSNrGGZUPXVBnWKffsi.QPYJTOdhYoaTVypukvRsEJPVPdWJ = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = list2.Find(niyaGUViWkSNrGGZUPXVBnWKffsi.vMlFOnKgYUhgcHjUABYqdOoykKqpB);
							if (eQMTLAegHWiDWcBWrbBOUDPgtUvn2 == null)
							{
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + niyaGUViWkSNrGGZUPXVBnWKffsi.QPYJTOdhYoaTVypukvRsEJPVPdWJ);
							}
							else
							{
								list3.Add(eQMTLAegHWiDWcBWrbBOUDPgtUvn2.UXagnnFilWlyrvvXAgibstGKPJEPA);
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
							IgXXfbHGJEAMxAwQOtRBlmqXVRSbA igXXfbHGJEAMxAwQOtRBlmqXVRSbA = new IgXXfbHGJEAMxAwQOtRBlmqXVRSbA();
							igXXfbHGJEAMxAwQOtRBlmqXVRSbA.xuKiBGJTNMukeQuwZOsIjTruRTPL = xiGfbBJZiWcSMOQQWSrPfVsphanL;
							List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> list4 = xtsSBWrlCFWJaXOtBLoyVJjBCpTh;
							igXXfbHGJEAMxAwQOtRBlmqXVRSbA.ozUnGyzOKLNanQYLPqMhlCIfdbKKA = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn3 = list4.Find(igXXfbHGJEAMxAwQOtRBlmqXVRSbA.ETfnPTXlRXEfENPzHSAjXmGGbOVO);
							if (eQMTLAegHWiDWcBWrbBOUDPgtUvn3 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + igXXfbHGJEAMxAwQOtRBlmqXVRSbA.ozUnGyzOKLNanQYLPqMhlCIfdbKKA);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = eQMTLAegHWiDWcBWrbBOUDPgtUvn3.UXagnnFilWlyrvvXAgibstGKPJEPA;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (xiGfbBJZiWcSMOQQWSrPfVsphanL.qXkhjZekahxPWgtwKIOaTDyHsogT.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						controllerMapEnabler_RuleSet_Editor2 = xiGfbBJZiWcSMOQQWSrPfVsphanL.qXkhjZekahxPWgtwKIOaTDyHsogT.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = xiGfbBJZiWcSMOQQWSrPfVsphanL.qXkhjZekahxPWgtwKIOaTDyHsogT.PMObaMRavvLiNGNkmHbMQjgVdRnV[xiGfbBJZiWcSMOQQWSrPfVsphanL.qXkhjZekahxPWgtwKIOaTDyHsogT.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = xiGfbBJZiWcSMOQQWSrPfVsphanL.qXkhjZekahxPWgtwKIOaTDyHsogT.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					xiGfbBJZiWcSMOQQWSrPfVsphanL.qXkhjZekahxPWgtwKIOaTDyHsogT.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				internal Player_Editor BtqkeCrIfdMtFzGAqBsVTzdGauTQ(IgBCFFIHIjGYbsbgcSQvofWiUNHu<Player_Editor> P_0)
				{
					cvgchmIUfYOezLNJYZoAfKkGNoQuA cvgchmIUfYOezLNJYZoAfKkGNoQuA2 = new cvgchmIUfYOezLNJYZoAfKkGNoQuA();
					cvgchmIUfYOezLNJYZoAfKkGNoQuA2.euiaIEDvGobGzBKIAmnMbhsqZxHXA = this;
					cvgchmIUfYOezLNJYZoAfKkGNoQuA2.OAHPeMBvRIvYhtXUjTpiUAHLyMTb = P_0;
					Player_Editor player_Editor = JsonTools.Clone(cvgchmIUfYOezLNJYZoAfKkGNoQuA2.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					Action<List<Player_Editor.Mapping>, List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>> action = cvgchmIUfYOezLNJYZoAfKkGNoQuA2.MdmeqMHlXpJykWbtYCOgOsWaZUNrA;
					action(player_Editor.defaultKeyboardMaps, oXGYxUoQoZMvQVskouKdXDqCrfqp);
					action(player_Editor.defaultMouseMaps, LMCAGynufBIYmiXvgmksgHkcqAQqA);
					action(player_Editor.defaultJoystickMaps, PAwdgHXCvxNbVUiPJqqSaxUKyQHf);
					action(player_Editor.defaultCustomControllerMaps, dGKWvLEBQLtPElHWfFbjYlPTwlVp);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						LEHbWDqMfYHLwkBNURhEODJEeztV lEHbWDqMfYHLwkBNURhEODJEeztV = new LEHbWDqMfYHLwkBNURhEODJEeztV();
						lEHbWDqMfYHLwkBNURhEODJEeztV.mKaGAduLoPxyTsPgBIbGKTiACPKO = cvgchmIUfYOezLNJYZoAfKkGNoQuA2;
						lEHbWDqMfYHLwkBNURhEODJEeztV.xxKetMjeLnTtUQSFuQvSLoFclAmAb = player_Editor.startingCustomControllers[i];
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = xtsSBWrlCFWJaXOtBLoyVJjBCpTh.Find(lEHbWDqMfYHLwkBNURhEODJEeztV.qFFyMPfHOZwZUNbnkPHrMusaoCyE);
						lEHbWDqMfYHLwkBNURhEODJEeztV.xxKetMjeLnTtUQSFuQvSLoFclAmAb.sourceId = eQMTLAegHWiDWcBWrbBOUDPgtUvn?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						NvMzSJXjnQxuwBBGQoTDGJxCSbHF nvMzSJXjnQxuwBBGQoTDGJxCSbHF = new NvMzSJXjnQxuwBBGQoTDGJxCSbHF();
						nvMzSJXjnQxuwBBGQoTDGJxCSbHF.WGOXxkGzfATMFxfuwXmkSgUkFlkZ = cvgchmIUfYOezLNJYZoAfKkGNoQuA2;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							nvMzSJXjnQxuwBBGQoTDGJxCSbHF.nyScXZKGlkgRWbRZIXtkTqZZzCznA = ruleSetMapping.id;
							EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = JdhApSsVtKSDZmDVGggcGLwJolnI.Find(nvMzSJXjnQxuwBBGQoTDGJxCSbHF.ZUQoWpvvdnLzFyEkntiOXFReuZfv);
							if (eQMTLAegHWiDWcBWrbBOUDPgtUvn2 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + nvMzSJXjnQxuwBBGQoTDGJxCSbHF.nyScXZKGlkgRWbRZIXtkTqZZzCznA);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = eQMTLAegHWiDWcBWrbBOUDPgtUvn2.UXagnnFilWlyrvvXAgibstGKPJEPA;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						YslCyjiaANnNSfrLNHZBgKPjqiTP yslCyjiaANnNSfrLNHZBgKPjqiTP = new YslCyjiaANnNSfrLNHZBgKPjqiTP();
						yslCyjiaANnNSfrLNHZBgKPjqiTP.rNTRPfwrohKtPRpJIZkvRZVfWMHG = cvgchmIUfYOezLNJYZoAfKkGNoQuA2;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							yslCyjiaANnNSfrLNHZBgKPjqiTP.qFifbKggmIklfgiOFrJTcXnzvmczA = ruleSetMapping2.id;
							EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn3 = ptkTLzuqAuHdjAEQJBJRCUuezLOaB.Find(yslCyjiaANnNSfrLNHZBgKPjqiTP.RNpGphyrLYjDzgtClgDNTOSvsXCc);
							if (eQMTLAegHWiDWcBWrbBOUDPgtUvn3 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + yslCyjiaANnNSfrLNHZBgKPjqiTP.qFifbKggmIklfgiOFrJTcXnzvmczA);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = eQMTLAegHWiDWcBWrbBOUDPgtUvn3.UXagnnFilWlyrvvXAgibstGKPJEPA;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (cvgchmIUfYOezLNJYZoAfKkGNoQuA2.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						player_Editor2 = cvgchmIUfYOezLNJYZoAfKkGNoQuA2.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.FlTDvwocioCFKVigEyEpIfMzkjCC;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.ltZHAQywbXMLIVeuXvczjRhuUoOl;
						GHDrzwvwmZmJMQlsmceWVOKbwVfb(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						GHDrzwvwmZmJMQlsmceWVOKbwVfb(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						GHDrzwvwmZmJMQlsmceWVOKbwVfb(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						GHDrzwvwmZmJMQlsmceWVOKbwVfb(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						GHDrzwvwmZmJMQlsmceWVOKbwVfb(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.OkwvNNXgoGtVcQQyfWmstjuhsEiP);
						player_Editor = player_Editor3;
					}
					else
					{
						jgngkWUxoNxoFJFTgPZKYgkaBxct.AddPlayer();
						player_Editor2 = cvgchmIUfYOezLNJYZoAfKkGNoQuA2.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.PMObaMRavvLiNGNkmHbMQjgVdRnV[cvgchmIUfYOezLNJYZoAfKkGNoQuA2.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = cvgchmIUfYOezLNJYZoAfKkGNoQuA2.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(player_Editor2);
					cvgchmIUfYOezLNJYZoAfKkGNoQuA2.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = player_Editor;
					return player_Editor;
				}
			}

			private sealed class phomDKiyHlXRKcmwlqbXHRIfPYeF
			{
				public IgBCFFIHIjGYbsbgcSQvofWiUNHu<InputAction> mgVDpFCXgeduGYNOqShtRndgyMgCA;

				internal bool NVxqASKHxAWRDkwLoimRJvOsnfTA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(mgVDpFCXgeduGYNOqShtRndgyMgCA.pNJQYDJDastMNOhpwKvucKFLhVdG) == mgVDpFCXgeduGYNOqShtRndgyMgCA.hHSeElCBhUiAnxdLaEOEbkHjzaTAB.categoryId;
				}

				internal bool czfHGcybXcQnCnVTabxRbicJuKCI(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(mgVDpFCXgeduGYNOqShtRndgyMgCA.pNJQYDJDastMNOhpwKvucKFLhVdG) == mgVDpFCXgeduGYNOqShtRndgyMgCA.hHSeElCBhUiAnxdLaEOEbkHjzaTAB.behaviorId;
				}
			}

			private sealed class NiyaGUViWkSNrGGZUPXVBnWKffsi
			{
				public int QPYJTOdhYoaTVypukvRsEJPVPdWJ;

				public XiGfbBJZiWcSMOQQWSrPfVsphanL TCxSdYXiDzvtjrxceQCHMWhDePbS;

				internal bool vMlFOnKgYUhgcHjUABYqdOoykKqpB(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(TCxSdYXiDzvtjrxceQCHMWhDePbS.qXkhjZekahxPWgtwKIOaTDyHsogT.pNJQYDJDastMNOhpwKvucKFLhVdG) == QPYJTOdhYoaTVypukvRsEJPVPdWJ;
				}
			}

			private sealed class IgXXfbHGJEAMxAwQOtRBlmqXVRSbA
			{
				public int ozUnGyzOKLNanQYLPqMhlCIfdbKKA;

				public XiGfbBJZiWcSMOQQWSrPfVsphanL xuKiBGJTNMukeQuwZOsIjTruRTPL;

				internal bool ETfnPTXlRXEfENPzHSAjXmGGbOVO(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(xuKiBGJTNMukeQuwZOsIjTruRTPL.qXkhjZekahxPWgtwKIOaTDyHsogT.pNJQYDJDastMNOhpwKvucKFLhVdG) == ozUnGyzOKLNanQYLPqMhlCIfdbKKA;
				}
			}

			private sealed class cvgchmIUfYOezLNJYZoAfKkGNoQuA
			{
				public IgBCFFIHIjGYbsbgcSQvofWiUNHu<Player_Editor> OAHPeMBvRIvYhtXUjTpiUAHLyMTb;

				public HpvjqnJtoIuQbndDldBUDpeLFqZS euiaIEDvGobGzBKIAmnMbhsqZxHXA;

				internal void MdmeqMHlXpJykWbtYCOgOsWaZUNrA(List<Player_Editor.Mapping> P_0, List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> P_1)
				{
					for (int i = 0; i < P_0.Count; i++)
					{
						hwyYnPzQVDSMFDAYwyQasQgDDMAE hwyYnPzQVDSMFDAYwyQasQgDDMAE2 = new hwyYnPzQVDSMFDAYwyQasQgDDMAE();
						hwyYnPzQVDSMFDAYwyQasQgDDMAE2.xvmlZvRlYQuRgayAvjXMGDiSuDVs = this;
						hwyYnPzQVDSMFDAYwyQasQgDDMAE2.rZrzKibdFGjVKMcFyjymHUVEdGFdb = P_0[i];
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = euiaIEDvGobGzBKIAmnMbhsqZxHXA.QWQVzEAharVPXiybbWvBhCJayxvK.Find(hwyYnPzQVDSMFDAYwyQasQgDDMAE2.wVSjzBsZzXdYUoFhyAMofOfOVQHA);
						hwyYnPzQVDSMFDAYwyQasQgDDMAE2.rZrzKibdFGjVKMcFyjymHUVEdGFdb.categoryId = eQMTLAegHWiDWcBWrbBOUDPgtUvn?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
						eQMTLAegHWiDWcBWrbBOUDPgtUvn = P_1.Find(hwyYnPzQVDSMFDAYwyQasQgDDMAE2.ifSGltRHvxEpKLjZEOvnjoTcHFAt);
						hwyYnPzQVDSMFDAYwyQasQgDDMAE2.rZrzKibdFGjVKMcFyjymHUVEdGFdb.layoutId = eQMTLAegHWiDWcBWrbBOUDPgtUvn?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					}
				}
			}

			private sealed class hwyYnPzQVDSMFDAYwyQasQgDDMAE
			{
				public Player_Editor.Mapping rZrzKibdFGjVKMcFyjymHUVEdGFdb;

				public cvgchmIUfYOezLNJYZoAfKkGNoQuA xvmlZvRlYQuRgayAvjXMGDiSuDVs;

				internal bool wVSjzBsZzXdYUoFhyAMofOfOVQHA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(xvmlZvRlYQuRgayAvjXMGDiSuDVs.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.pNJQYDJDastMNOhpwKvucKFLhVdG) == rZrzKibdFGjVKMcFyjymHUVEdGFdb.categoryId;
				}

				internal bool ifSGltRHvxEpKLjZEOvnjoTcHFAt(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(xvmlZvRlYQuRgayAvjXMGDiSuDVs.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.pNJQYDJDastMNOhpwKvucKFLhVdG) == rZrzKibdFGjVKMcFyjymHUVEdGFdb.layoutId;
				}
			}

			private sealed class LEHbWDqMfYHLwkBNURhEODJEeztV
			{
				public Player_Editor.CreateControllerInfo xxKetMjeLnTtUQSFuQvSLoFclAmAb;

				public cvgchmIUfYOezLNJYZoAfKkGNoQuA mKaGAduLoPxyTsPgBIbGKTiACPKO;

				internal bool qFFyMPfHOZwZUNbnkPHrMusaoCyE(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(mKaGAduLoPxyTsPgBIbGKTiACPKO.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.pNJQYDJDastMNOhpwKvucKFLhVdG) == xxKetMjeLnTtUQSFuQvSLoFclAmAb.sourceId;
				}
			}

			private sealed class NvMzSJXjnQxuwBBGQoTDGJxCSbHF
			{
				public int nyScXZKGlkgRWbRZIXtkTqZZzCznA;

				public cvgchmIUfYOezLNJYZoAfKkGNoQuA WGOXxkGzfATMFxfuwXmkSgUkFlkZ;

				internal bool ZUQoWpvvdnLzFyEkntiOXFReuZfv(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(WGOXxkGzfATMFxfuwXmkSgUkFlkZ.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.pNJQYDJDastMNOhpwKvucKFLhVdG) == nyScXZKGlkgRWbRZIXtkTqZZzCznA;
				}
			}

			private sealed class YslCyjiaANnNSfrLNHZBgKPjqiTP
			{
				public int qFifbKggmIklfgiOFrJTcXnzvmczA;

				public cvgchmIUfYOezLNJYZoAfKkGNoQuA rNTRPfwrohKtPRpJIZkvRZVfWMHG;

				internal bool RNpGphyrLYjDzgtClgDNTOSvsXCc(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(rNTRPfwrohKtPRpJIZkvRZVfWMHG.OAHPeMBvRIvYhtXUjTpiUAHLyMTb.pNJQYDJDastMNOhpwKvucKFLhVdG) == qFifbKggmIklfgiOFrJTcXnzvmczA;
				}
			}

			private sealed class vdzKtZCDANfvkRNIoTJhxbqrSkue
			{
				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> whZDBdptXKdmeBnCxncEBHVNkjaU;

				public HpvjqnJtoIuQbndDldBUDpeLFqZS dufEzOMaAuThMYcojaxhPoRlzsJm;

				internal int OVFCGaIVAaOiQqktvHtboVJlydpGA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					SYarKLhrBjtFkesFnJczQudFkcjI sYarKLhrBjtFkesFnJczQudFkcjI = new SYarKLhrBjtFkesFnJczQudFkcjI();
					sYarKLhrBjtFkesFnJczQudFkcjI.MbQHUJLMkDbGZHFTHkyHrgCiOpGhb = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = dufEzOMaAuThMYcojaxhPoRlzsJm.QWQVzEAharVPXiybbWvBhCJayxvK.Find(sYarKLhrBjtFkesFnJczQudFkcjI.bkVsTdJekgbkYxLoLAwPPKTflZCV);
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = whZDBdptXKdmeBnCxncEBHVNkjaU.Find(sYarKLhrBjtFkesFnJczQudFkcjI.vCLCGEdnPatQjyPSteOYHJGDtFTVA);
						if (eQMTLAegHWiDWcBWrbBOUDPgtUvn != null && eQMTLAegHWiDWcBWrbBOUDPgtUvn.UXagnnFilWlyrvvXAgibstGKPJEPA == P_1[i].categoryId && eQMTLAegHWiDWcBWrbBOUDPgtUvn2 != null && eQMTLAegHWiDWcBWrbBOUDPgtUvn2.UXagnnFilWlyrvvXAgibstGKPJEPA == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor EClphHmvyORToWWUeIXoSWkejRQp(IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMap_Editor> P_0)
				{
					vaiSfkADXguRyYGwnxOSxXqitMIJ vaiSfkADXguRyYGwnxOSxXqitMIJ2 = new vaiSfkADXguRyYGwnxOSxXqitMIJ();
					vaiSfkADXguRyYGwnxOSxXqitMIJ2.QyyiqWlbFNPHTbmcHybiWPHXAYIFA = P_0;
					vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ = JsonTools.Clone(vaiSfkADXguRyYGwnxOSxXqitMIJ2.QyyiqWlbFNPHTbmcHybiWPHXAYIFA.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = dufEzOMaAuThMYcojaxhPoRlzsJm.QWQVzEAharVPXiybbWvBhCJayxvK.Find(vaiSfkADXguRyYGwnxOSxXqitMIJ2.OxhdjNaadxHVXcwzdZmgjadUfpPvA);
					EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = whZDBdptXKdmeBnCxncEBHVNkjaU.Find(vaiSfkADXguRyYGwnxOSxXqitMIJ2.ZxWHIWSGLvMbSzjnEjYndOmGtlvdA);
					vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ.categoryId = eQMTLAegHWiDWcBWrbBOUDPgtUvn?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ.layoutId = eQMTLAegHWiDWcBWrbBOUDPgtUvn2?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					for (int i = 0; i < vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ.actionElementMaps.Count; i++)
					{
						UnrgKdRwjDCzddJdttEGaAgGJmNzA unrgKdRwjDCzddJdttEGaAgGJmNzA = new UnrgKdRwjDCzddJdttEGaAgGJmNzA();
						unrgKdRwjDCzddJdttEGaAgGJmNzA.lZGmEQCisDhZyRtGHchCbGUMdSDm = vaiSfkADXguRyYGwnxOSxXqitMIJ2;
						unrgKdRwjDCzddJdttEGaAgGJmNzA.RlhvswUDFvKEijofJWwnOzPHoYpv = unrgKdRwjDCzddJdttEGaAgGJmNzA.lZGmEQCisDhZyRtGHchCbGUMdSDm.VYYBryZisUJDadLCSPLYfmSQqKEQ.actionElementMaps[i];
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn3 = dufEzOMaAuThMYcojaxhPoRlzsJm.woGVtgbnGtfAnBkFXNFqtPwtviZc.Find(unrgKdRwjDCzddJdttEGaAgGJmNzA.BiJgRJxbQpUgzmZatQKYGAJlDOqIA);
						unrgKdRwjDCzddJdttEGaAgGJmNzA.RlhvswUDFvKEijofJWwnOzPHoYpv._actionId = eQMTLAegHWiDWcBWrbBOUDPgtUvn3?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
						unrgKdRwjDCzddJdttEGaAgGJmNzA.RlhvswUDFvKEijofJWwnOzPHoYpv._actionCategoryId = ((dufEzOMaAuThMYcojaxhPoRlzsJm.jgngkWUxoNxoFJFTgPZKYgkaBxct.GetActionById(unrgKdRwjDCzddJdttEGaAgGJmNzA.RlhvswUDFvKEijofJWwnOzPHoYpv._actionId) != null) ? dufEzOMaAuThMYcojaxhPoRlzsJm.jgngkWUxoNxoFJFTgPZKYgkaBxct.GetActionById(unrgKdRwjDCzddJdttEGaAgGJmNzA.RlhvswUDFvKEijofJWwnOzPHoYpv._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (vaiSfkADXguRyYGwnxOSxXqitMIJ2.QyyiqWlbFNPHTbmcHybiWPHXAYIFA.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						controllerMap_Editor = vaiSfkADXguRyYGwnxOSxXqitMIJ2.QyyiqWlbFNPHTbmcHybiWPHXAYIFA.FlTDvwocioCFKVigEyEpIfMzkjCC;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.SIZgeaeHjGPbKTVpeDDCxaujpFuX;
						GHDrzwvwmZmJMQlsmceWVOKbwVfb(controllerMap_Editor.actionElementMaps, vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ = controllerMap_Editor2;
					}
					else
					{
						dufEzOMaAuThMYcojaxhPoRlzsJm.jgngkWUxoNxoFJFTgPZKYgkaBxct.CreateKeyboardMap(vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ.categoryId, vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ.layoutId);
						controllerMap_Editor = vaiSfkADXguRyYGwnxOSxXqitMIJ2.QyyiqWlbFNPHTbmcHybiWPHXAYIFA.PMObaMRavvLiNGNkmHbMQjgVdRnV[vaiSfkADXguRyYGwnxOSxXqitMIJ2.QyyiqWlbFNPHTbmcHybiWPHXAYIFA.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ.id = controllerMap_Editor.id;
					int index = vaiSfkADXguRyYGwnxOSxXqitMIJ2.QyyiqWlbFNPHTbmcHybiWPHXAYIFA.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(controllerMap_Editor);
					vaiSfkADXguRyYGwnxOSxXqitMIJ2.QyyiqWlbFNPHTbmcHybiWPHXAYIFA.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ;
					return vaiSfkADXguRyYGwnxOSxXqitMIJ2.VYYBryZisUJDadLCSPLYfmSQqKEQ;
				}
			}

			private sealed class SYarKLhrBjtFkesFnJczQudFkcjI
			{
				public ControllerMap_Editor MbQHUJLMkDbGZHFTHkyHrgCiOpGhb;

				public Predicate<EQMTLAegHWiDWcBWrbBOUDPgtUvn> GqfpVzMjzYcnvOFOxvjzXxTvnDIX;

				public Predicate<EQMTLAegHWiDWcBWrbBOUDPgtUvn> rOlLEYmXDWnsQAiPJbnXWVFFUTiV;

				internal bool bkVsTdJekgbkYxLoLAwPPKTflZCV(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.XHQBrhCsnDhHYingzZwFuzxTAywc == MbQHUJLMkDbGZHFTHkyHrgCiOpGhb.categoryId;
				}

				internal bool vCLCGEdnPatQjyPSteOYHJGDtFTVA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.XHQBrhCsnDhHYingzZwFuzxTAywc == MbQHUJLMkDbGZHFTHkyHrgCiOpGhb.layoutId;
				}
			}

			private sealed class vaiSfkADXguRyYGwnxOSxXqitMIJ
			{
				public IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMap_Editor> QyyiqWlbFNPHTbmcHybiWPHXAYIFA;

				public ControllerMap_Editor VYYBryZisUJDadLCSPLYfmSQqKEQ;

				internal bool OxhdjNaadxHVXcwzdZmgjadUfpPvA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(QyyiqWlbFNPHTbmcHybiWPHXAYIFA.pNJQYDJDastMNOhpwKvucKFLhVdG) == VYYBryZisUJDadLCSPLYfmSQqKEQ.categoryId;
				}

				internal bool ZxWHIWSGLvMbSzjnEjYndOmGtlvdA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(QyyiqWlbFNPHTbmcHybiWPHXAYIFA.pNJQYDJDastMNOhpwKvucKFLhVdG) == VYYBryZisUJDadLCSPLYfmSQqKEQ.layoutId;
				}
			}

			private sealed class jjEAUGXHzphieGAdOzCKYjcENpif
			{
				public List<int> mWgqBASnbKyqrCSvfNOlHVVaCzqu;

				public HpvjqnJtoIuQbndDldBUDpeLFqZS bSBfWigmTalvHDlYKdVWEpYhWodD;

				internal InputMapCategory NpfhnENcBJIYFgcsEjzTeHeYNztgb(IgBCFFIHIjGYbsbgcSQvofWiUNHu<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					InputMapCategory inputMapCategory2;
					if (P_0.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						inputMapCategory2 = P_0.FlTDvwocioCFKVigEyEpIfMzkjCC;
					}
					else
					{
						bSBfWigmTalvHDlYKdVWEpYhWodD.jgngkWUxoNxoFJFTgPZKYgkaBxct.AddMapCategory();
						inputMapCategory2 = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					int num = P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(inputMapCategory2);
					if (P_0.pNJQYDJDastMNOhpwKvucKFLhVdG == EQMTLAegHWiDWcBWrbBOUDPgtUvn.avjRWxrTQhVuPPOElqssnifNHKHO.otherId)
					{
						mWgqBASnbKyqrCSvfNOlHVVaCzqu.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.PMObaMRavvLiNGNkmHbMQjgVdRnV[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class UnrgKdRwjDCzddJdttEGaAgGJmNzA
			{
				public ActionElementMap RlhvswUDFvKEijofJWwnOzPHoYpv;

				public vaiSfkADXguRyYGwnxOSxXqitMIJ lZGmEQCisDhZyRtGHchCbGUMdSDm;

				internal bool BiJgRJxbQpUgzmZatQKYGAJlDOqIA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(lZGmEQCisDhZyRtGHchCbGUMdSDm.QyyiqWlbFNPHTbmcHybiWPHXAYIFA.pNJQYDJDastMNOhpwKvucKFLhVdG) == RlhvswUDFvKEijofJWwnOzPHoYpv._actionId;
				}
			}

			private sealed class MgEcDJmVfyaiVjWYXJLmCufkUkvd
			{
				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> cwUfIvUWdKoWSoDzJJmGhAuGfXyw;

				public HpvjqnJtoIuQbndDldBUDpeLFqZS rBTDxHPfWZXFrLUGDOuUrPzhcxwk;

				internal int MgATsxKMqbibbWSDeaKbZoehEjkv(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					ZQOFCnFZyAxjZEfizuYBbVymdKxVA zQOFCnFZyAxjZEfizuYBbVymdKxVA = new ZQOFCnFZyAxjZEfizuYBbVymdKxVA();
					zQOFCnFZyAxjZEfizuYBbVymdKxVA.hKJaUOLDVBpRKbQnstMqDhEfpSQU = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = rBTDxHPfWZXFrLUGDOuUrPzhcxwk.QWQVzEAharVPXiybbWvBhCJayxvK.Find(zQOFCnFZyAxjZEfizuYBbVymdKxVA.VMRnRIYnRuTQHhWOHsIjdHiUfwaG);
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = cwUfIvUWdKoWSoDzJJmGhAuGfXyw.Find(zQOFCnFZyAxjZEfizuYBbVymdKxVA.twOoNWghbnpeRQpSKbtejyGPvxSMA);
						if (eQMTLAegHWiDWcBWrbBOUDPgtUvn != null && eQMTLAegHWiDWcBWrbBOUDPgtUvn.UXagnnFilWlyrvvXAgibstGKPJEPA == P_1[i].categoryId && eQMTLAegHWiDWcBWrbBOUDPgtUvn2 != null && eQMTLAegHWiDWcBWrbBOUDPgtUvn2.UXagnnFilWlyrvvXAgibstGKPJEPA == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor RdupeSRMILjDNcfokWUWEODbbOqG(IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMap_Editor> P_0)
				{
					tZrqMavMhVItpdyncdJHXRvdAuVJ tZrqMavMhVItpdyncdJHXRvdAuVJ2 = new tZrqMavMhVItpdyncdJHXRvdAuVJ();
					tZrqMavMhVItpdyncdJHXRvdAuVJ2.fwTrySMMvoPcSoBUkuwJHWpsiyS = P_0;
					tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO = JsonTools.Clone(tZrqMavMhVItpdyncdJHXRvdAuVJ2.fwTrySMMvoPcSoBUkuwJHWpsiyS.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = rBTDxHPfWZXFrLUGDOuUrPzhcxwk.QWQVzEAharVPXiybbWvBhCJayxvK.Find(tZrqMavMhVItpdyncdJHXRvdAuVJ2.FupZNqIrsSzQmPMzKbcmWBDgieTR);
					EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = cwUfIvUWdKoWSoDzJJmGhAuGfXyw.Find(tZrqMavMhVItpdyncdJHXRvdAuVJ2.sMrRFZycSyoJkxKlMLxeRfLzgcBHA);
					tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO.categoryId = eQMTLAegHWiDWcBWrbBOUDPgtUvn?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO.layoutId = eQMTLAegHWiDWcBWrbBOUDPgtUvn2?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					for (int i = 0; i < tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO.actionElementMaps.Count; i++)
					{
						jCxDQyvLzLdXUtVoCFSjeemVRlZFA jCxDQyvLzLdXUtVoCFSjeemVRlZFA2 = new jCxDQyvLzLdXUtVoCFSjeemVRlZFA();
						jCxDQyvLzLdXUtVoCFSjeemVRlZFA2.MhLeTXDnUpsmFkHtfIixlDEVjDAY = tZrqMavMhVItpdyncdJHXRvdAuVJ2;
						jCxDQyvLzLdXUtVoCFSjeemVRlZFA2.KEphaHMfjibgMEwRFQoYSwmHSdAgA = jCxDQyvLzLdXUtVoCFSjeemVRlZFA2.MhLeTXDnUpsmFkHtfIixlDEVjDAY.ylXCZLXReMNFEEDLwqxuvkfBCsMO.actionElementMaps[i];
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn3 = rBTDxHPfWZXFrLUGDOuUrPzhcxwk.woGVtgbnGtfAnBkFXNFqtPwtviZc.Find(jCxDQyvLzLdXUtVoCFSjeemVRlZFA2.TkkeXwwNqgNrUFoMnXLJZWaxliCl);
						jCxDQyvLzLdXUtVoCFSjeemVRlZFA2.KEphaHMfjibgMEwRFQoYSwmHSdAgA._actionId = eQMTLAegHWiDWcBWrbBOUDPgtUvn3?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
						jCxDQyvLzLdXUtVoCFSjeemVRlZFA2.KEphaHMfjibgMEwRFQoYSwmHSdAgA._actionCategoryId = ((rBTDxHPfWZXFrLUGDOuUrPzhcxwk.jgngkWUxoNxoFJFTgPZKYgkaBxct.GetActionById(jCxDQyvLzLdXUtVoCFSjeemVRlZFA2.KEphaHMfjibgMEwRFQoYSwmHSdAgA._actionId) != null) ? rBTDxHPfWZXFrLUGDOuUrPzhcxwk.jgngkWUxoNxoFJFTgPZKYgkaBxct.GetActionById(jCxDQyvLzLdXUtVoCFSjeemVRlZFA2.KEphaHMfjibgMEwRFQoYSwmHSdAgA._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (tZrqMavMhVItpdyncdJHXRvdAuVJ2.fwTrySMMvoPcSoBUkuwJHWpsiyS.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						controllerMap_Editor = tZrqMavMhVItpdyncdJHXRvdAuVJ2.fwTrySMMvoPcSoBUkuwJHWpsiyS.FlTDvwocioCFKVigEyEpIfMzkjCC;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.DYYKoyDVpelbFTsDyjfGYDYSULwV;
						GHDrzwvwmZmJMQlsmceWVOKbwVfb(controllerMap_Editor.actionElementMaps, tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO = controllerMap_Editor2;
					}
					else
					{
						rBTDxHPfWZXFrLUGDOuUrPzhcxwk.jgngkWUxoNxoFJFTgPZKYgkaBxct.CreateMouseMap(tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO.categoryId, tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO.layoutId);
						controllerMap_Editor = tZrqMavMhVItpdyncdJHXRvdAuVJ2.fwTrySMMvoPcSoBUkuwJHWpsiyS.PMObaMRavvLiNGNkmHbMQjgVdRnV[tZrqMavMhVItpdyncdJHXRvdAuVJ2.fwTrySMMvoPcSoBUkuwJHWpsiyS.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO.id = controllerMap_Editor.id;
					int index = tZrqMavMhVItpdyncdJHXRvdAuVJ2.fwTrySMMvoPcSoBUkuwJHWpsiyS.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(controllerMap_Editor);
					tZrqMavMhVItpdyncdJHXRvdAuVJ2.fwTrySMMvoPcSoBUkuwJHWpsiyS.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO;
					return tZrqMavMhVItpdyncdJHXRvdAuVJ2.ylXCZLXReMNFEEDLwqxuvkfBCsMO;
				}
			}

			private sealed class ZQOFCnFZyAxjZEfizuYBbVymdKxVA
			{
				public ControllerMap_Editor hKJaUOLDVBpRKbQnstMqDhEfpSQU;

				public Predicate<EQMTLAegHWiDWcBWrbBOUDPgtUvn> ZRaZrVWydSpAOXdcDzvBpdAlJWLH;

				public Predicate<EQMTLAegHWiDWcBWrbBOUDPgtUvn> pOqWdRklyLdmldzMBIWwCNhBQCyN;

				internal bool VMRnRIYnRuTQHhWOHsIjdHiUfwaG(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.XHQBrhCsnDhHYingzZwFuzxTAywc == hKJaUOLDVBpRKbQnstMqDhEfpSQU.categoryId;
				}

				internal bool twOoNWghbnpeRQpSKbtejyGPvxSMA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.XHQBrhCsnDhHYingzZwFuzxTAywc == hKJaUOLDVBpRKbQnstMqDhEfpSQU.layoutId;
				}
			}

			private sealed class tZrqMavMhVItpdyncdJHXRvdAuVJ
			{
				public IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMap_Editor> fwTrySMMvoPcSoBUkuwJHWpsiyS;

				public ControllerMap_Editor ylXCZLXReMNFEEDLwqxuvkfBCsMO;

				internal bool FupZNqIrsSzQmPMzKbcmWBDgieTR(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(fwTrySMMvoPcSoBUkuwJHWpsiyS.pNJQYDJDastMNOhpwKvucKFLhVdG) == ylXCZLXReMNFEEDLwqxuvkfBCsMO.categoryId;
				}

				internal bool sMrRFZycSyoJkxKlMLxeRfLzgcBHA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(fwTrySMMvoPcSoBUkuwJHWpsiyS.pNJQYDJDastMNOhpwKvucKFLhVdG) == ylXCZLXReMNFEEDLwqxuvkfBCsMO.layoutId;
				}
			}

			private sealed class jCxDQyvLzLdXUtVoCFSjeemVRlZFA
			{
				public ActionElementMap KEphaHMfjibgMEwRFQoYSwmHSdAgA;

				public tZrqMavMhVItpdyncdJHXRvdAuVJ MhLeTXDnUpsmFkHtfIixlDEVjDAY;

				internal bool TkkeXwwNqgNrUFoMnXLJZWaxliCl(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(MhLeTXDnUpsmFkHtfIixlDEVjDAY.fwTrySMMvoPcSoBUkuwJHWpsiyS.pNJQYDJDastMNOhpwKvucKFLhVdG) == KEphaHMfjibgMEwRFQoYSwmHSdAgA._actionId;
				}
			}

			private sealed class vAnoLsPvAMblXpovbfeQPiJAAOekA
			{
				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> AQBZtJFdNaeXaliEimEObBMHHCen;

				public HpvjqnJtoIuQbndDldBUDpeLFqZS PyhxKYmmyxYRqPJLzFdsPwNBUyyL;

				internal int bcAJTJhmhbidNftDUjkDnQcDxgiBA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					sPiuHsHAImpasVJajjeMFdiZjwqT sPiuHsHAImpasVJajjeMFdiZjwqT2 = new sPiuHsHAImpasVJajjeMFdiZjwqT();
					sPiuHsHAImpasVJajjeMFdiZjwqT2.cWLFtzDBLGywbIabsdudFbErkjPM = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = PyhxKYmmyxYRqPJLzFdsPwNBUyyL.QWQVzEAharVPXiybbWvBhCJayxvK.Find(sPiuHsHAImpasVJajjeMFdiZjwqT2.GorCJoIvDMXIOWOpoHcmqiVOxjwKA);
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = AQBZtJFdNaeXaliEimEObBMHHCen.Find(sPiuHsHAImpasVJajjeMFdiZjwqT2.uFyEOZHeUJtVzqByijPOibUanxajc);
						if (sPiuHsHAImpasVJajjeMFdiZjwqT2.cWLFtzDBLGywbIabsdudFbErkjPM.hardwareGuid == P_1[i].hardwareGuid && eQMTLAegHWiDWcBWrbBOUDPgtUvn != null && eQMTLAegHWiDWcBWrbBOUDPgtUvn.UXagnnFilWlyrvvXAgibstGKPJEPA == P_1[i].categoryId && eQMTLAegHWiDWcBWrbBOUDPgtUvn2 != null && eQMTLAegHWiDWcBWrbBOUDPgtUvn2.UXagnnFilWlyrvvXAgibstGKPJEPA == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor HxqfPPgDPUpYswGJlShEMWvSvjVIA(IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMap_Editor> P_0)
				{
					eEpFozamikqUEiMClwbrwkTVpTmF eEpFozamikqUEiMClwbrwkTVpTmF2 = new eEpFozamikqUEiMClwbrwkTVpTmF();
					eEpFozamikqUEiMClwbrwkTVpTmF2.XmiOTWnofDgREDMiBKTwrLItFhoX = P_0;
					eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA = JsonTools.Clone(eEpFozamikqUEiMClwbrwkTVpTmF2.XmiOTWnofDgREDMiBKTwrLItFhoX.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = PyhxKYmmyxYRqPJLzFdsPwNBUyyL.QWQVzEAharVPXiybbWvBhCJayxvK.Find(eEpFozamikqUEiMClwbrwkTVpTmF2.VgtgUlsfakJfdANdXxBzMiHzgdoY);
					EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = AQBZtJFdNaeXaliEimEObBMHHCen.Find(eEpFozamikqUEiMClwbrwkTVpTmF2.TGCMPScoQCjflifMehEhCSrGeHtO);
					eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA.categoryId = eQMTLAegHWiDWcBWrbBOUDPgtUvn?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA.layoutId = eQMTLAegHWiDWcBWrbBOUDPgtUvn2?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					for (int i = 0; i < eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA.actionElementMaps.Count; i++)
					{
						eXkUfPXycaGwlOYpLgoVPbNingSK eXkUfPXycaGwlOYpLgoVPbNingSK2 = new eXkUfPXycaGwlOYpLgoVPbNingSK();
						eXkUfPXycaGwlOYpLgoVPbNingSK2.hMrXCbWaOxKVMwhehheqHVhYjNge = eEpFozamikqUEiMClwbrwkTVpTmF2;
						eXkUfPXycaGwlOYpLgoVPbNingSK2.wpquDlvPfvkMljzuHqpXfdBzLKSy = eXkUfPXycaGwlOYpLgoVPbNingSK2.hMrXCbWaOxKVMwhehheqHVhYjNge.cjbbyWgMtJEALBpuqpwzBHESWkIGA.actionElementMaps[i];
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn3 = PyhxKYmmyxYRqPJLzFdsPwNBUyyL.woGVtgbnGtfAnBkFXNFqtPwtviZc.Find(eXkUfPXycaGwlOYpLgoVPbNingSK2.fliFgoOvazfAEJvJnndNmjaShrAmA);
						eXkUfPXycaGwlOYpLgoVPbNingSK2.wpquDlvPfvkMljzuHqpXfdBzLKSy._actionId = eQMTLAegHWiDWcBWrbBOUDPgtUvn3?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
						eXkUfPXycaGwlOYpLgoVPbNingSK2.wpquDlvPfvkMljzuHqpXfdBzLKSy._actionCategoryId = ((PyhxKYmmyxYRqPJLzFdsPwNBUyyL.jgngkWUxoNxoFJFTgPZKYgkaBxct.GetActionById(eXkUfPXycaGwlOYpLgoVPbNingSK2.wpquDlvPfvkMljzuHqpXfdBzLKSy._actionId) != null) ? PyhxKYmmyxYRqPJLzFdsPwNBUyyL.jgngkWUxoNxoFJFTgPZKYgkaBxct.GetActionById(eXkUfPXycaGwlOYpLgoVPbNingSK2.wpquDlvPfvkMljzuHqpXfdBzLKSy._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (eEpFozamikqUEiMClwbrwkTVpTmF2.XmiOTWnofDgREDMiBKTwrLItFhoX.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						controllerMap_Editor = eEpFozamikqUEiMClwbrwkTVpTmF2.XmiOTWnofDgREDMiBKTwrLItFhoX.FlTDvwocioCFKVigEyEpIfMzkjCC;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.qIzgRniubEZeiarXubFkpAysBdeIA;
						GHDrzwvwmZmJMQlsmceWVOKbwVfb(controllerMap_Editor.actionElementMaps, eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA = controllerMap_Editor2;
					}
					else
					{
						PyhxKYmmyxYRqPJLzFdsPwNBUyyL.jgngkWUxoNxoFJFTgPZKYgkaBxct.CreateJoystickMap(eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA.categoryId, eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA.hardwareGuid, eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA.layoutId);
						controllerMap_Editor = eEpFozamikqUEiMClwbrwkTVpTmF2.XmiOTWnofDgREDMiBKTwrLItFhoX.PMObaMRavvLiNGNkmHbMQjgVdRnV[eEpFozamikqUEiMClwbrwkTVpTmF2.XmiOTWnofDgREDMiBKTwrLItFhoX.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA.id = controllerMap_Editor.id;
					int index = eEpFozamikqUEiMClwbrwkTVpTmF2.XmiOTWnofDgREDMiBKTwrLItFhoX.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(controllerMap_Editor);
					eEpFozamikqUEiMClwbrwkTVpTmF2.XmiOTWnofDgREDMiBKTwrLItFhoX.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA;
					return eEpFozamikqUEiMClwbrwkTVpTmF2.cjbbyWgMtJEALBpuqpwzBHESWkIGA;
				}
			}

			private sealed class sPiuHsHAImpasVJajjeMFdiZjwqT
			{
				public ControllerMap_Editor cWLFtzDBLGywbIabsdudFbErkjPM;

				public Predicate<EQMTLAegHWiDWcBWrbBOUDPgtUvn> aatySatWNADSrUgizFXNbOaxXFin;

				public Predicate<EQMTLAegHWiDWcBWrbBOUDPgtUvn> adLEfCjQwKBLugNkCNwKroTHgDUic;

				internal bool GorCJoIvDMXIOWOpoHcmqiVOxjwKA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.XHQBrhCsnDhHYingzZwFuzxTAywc == cWLFtzDBLGywbIabsdudFbErkjPM.categoryId;
				}

				internal bool uFyEOZHeUJtVzqByijPOibUanxajc(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.XHQBrhCsnDhHYingzZwFuzxTAywc == cWLFtzDBLGywbIabsdudFbErkjPM.layoutId;
				}
			}

			private sealed class eEpFozamikqUEiMClwbrwkTVpTmF
			{
				public IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMap_Editor> XmiOTWnofDgREDMiBKTwrLItFhoX;

				public ControllerMap_Editor cjbbyWgMtJEALBpuqpwzBHESWkIGA;

				internal bool VgtgUlsfakJfdANdXxBzMiHzgdoY(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(XmiOTWnofDgREDMiBKTwrLItFhoX.pNJQYDJDastMNOhpwKvucKFLhVdG) == cjbbyWgMtJEALBpuqpwzBHESWkIGA.categoryId;
				}

				internal bool TGCMPScoQCjflifMehEhCSrGeHtO(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(XmiOTWnofDgREDMiBKTwrLItFhoX.pNJQYDJDastMNOhpwKvucKFLhVdG) == cjbbyWgMtJEALBpuqpwzBHESWkIGA.layoutId;
				}
			}

			private sealed class eXkUfPXycaGwlOYpLgoVPbNingSK
			{
				public ActionElementMap wpquDlvPfvkMljzuHqpXfdBzLKSy;

				public eEpFozamikqUEiMClwbrwkTVpTmF hMrXCbWaOxKVMwhehheqHVhYjNge;

				internal bool fliFgoOvazfAEJvJnndNmjaShrAmA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(hMrXCbWaOxKVMwhehheqHVhYjNge.XmiOTWnofDgREDMiBKTwrLItFhoX.pNJQYDJDastMNOhpwKvucKFLhVdG) == wpquDlvPfvkMljzuHqpXfdBzLKSy._actionId;
				}
			}

			private sealed class eFRhCVeSOzhUGkMVuOXEWZBmaYIz
			{
				public List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> gvMfNIHalQturaIzLjHgBlqaACtFA;

				public HpvjqnJtoIuQbndDldBUDpeLFqZS MVKrWntQtrsQeICYnMigyMbXANPo;

				internal int ZdDZzzOaSZLQDqmVFSZMQNtSGDQD(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					QJRKBsMbBrBiljAcWPaAHiNdQdOsc qJRKBsMbBrBiljAcWPaAHiNdQdOsc = new QJRKBsMbBrBiljAcWPaAHiNdQdOsc();
					qJRKBsMbBrBiljAcWPaAHiNdQdOsc.aikmZSJeYTqsAHcJfbODLinTzTqt = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = MVKrWntQtrsQeICYnMigyMbXANPo.xtsSBWrlCFWJaXOtBLoyVJjBCpTh.Find(qJRKBsMbBrBiljAcWPaAHiNdQdOsc.aHtuhwBRUJinKHCmfTRhKrkKAgHL);
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = MVKrWntQtrsQeICYnMigyMbXANPo.QWQVzEAharVPXiybbWvBhCJayxvK.Find(qJRKBsMbBrBiljAcWPaAHiNdQdOsc.UfGXRBrwoAGsRUdlNIDeCMndMzpnA);
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn3 = gvMfNIHalQturaIzLjHgBlqaACtFA.Find(qJRKBsMbBrBiljAcWPaAHiNdQdOsc.RUGupubKDqwtBvtBIMtYgHeVBQIeA);
						if (eQMTLAegHWiDWcBWrbBOUDPgtUvn != null && eQMTLAegHWiDWcBWrbBOUDPgtUvn.UXagnnFilWlyrvvXAgibstGKPJEPA == P_1[i].customControllerUid && eQMTLAegHWiDWcBWrbBOUDPgtUvn2 != null && eQMTLAegHWiDWcBWrbBOUDPgtUvn2.UXagnnFilWlyrvvXAgibstGKPJEPA == P_1[i].categoryId && eQMTLAegHWiDWcBWrbBOUDPgtUvn3 != null && eQMTLAegHWiDWcBWrbBOUDPgtUvn3.UXagnnFilWlyrvvXAgibstGKPJEPA == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor jKlbHJBmAYDTMijcylXFmSclYApL(IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMap_Editor> P_0)
				{
					vkZHQqAtJVWPdKpYwfrysCTHmbCw vkZHQqAtJVWPdKpYwfrysCTHmbCw2 = new vkZHQqAtJVWPdKpYwfrysCTHmbCw();
					vkZHQqAtJVWPdKpYwfrysCTHmbCw2.REqXdaXecUVHmCjUSfLMIRbrgcMFA = P_0;
					vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo = JsonTools.Clone(vkZHQqAtJVWPdKpYwfrysCTHmbCw2.REqXdaXecUVHmCjUSfLMIRbrgcMFA.hHSeElCBhUiAnxdLaEOEbkHjzaTAB);
					EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = MVKrWntQtrsQeICYnMigyMbXANPo.xtsSBWrlCFWJaXOtBLoyVJjBCpTh.Find(vkZHQqAtJVWPdKpYwfrysCTHmbCw2.FslGFIiTlpKJYbmsHejqmfTGnntwc);
					EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn2 = MVKrWntQtrsQeICYnMigyMbXANPo.QWQVzEAharVPXiybbWvBhCJayxvK.Find(vkZHQqAtJVWPdKpYwfrysCTHmbCw2.LjHwURoOZpkLPwlclNAaFNkwIeuj);
					EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn3 = gvMfNIHalQturaIzLjHgBlqaACtFA.Find(vkZHQqAtJVWPdKpYwfrysCTHmbCw2.RNQTQtaoAlgiBDpVTzPteHZgcIocA);
					vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo.customControllerUid = eQMTLAegHWiDWcBWrbBOUDPgtUvn?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo.categoryId = eQMTLAegHWiDWcBWrbBOUDPgtUvn2?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo.layoutId = eQMTLAegHWiDWcBWrbBOUDPgtUvn3?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					for (int i = 0; i < vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo.actionElementMaps.Count; i++)
					{
						owuvaAsivLmBgouJIOsplyqaquvv owuvaAsivLmBgouJIOsplyqaquvv2 = new owuvaAsivLmBgouJIOsplyqaquvv();
						owuvaAsivLmBgouJIOsplyqaquvv2.hTbZgIlPllczYPBVUeVJOkuqKVGN = vkZHQqAtJVWPdKpYwfrysCTHmbCw2;
						owuvaAsivLmBgouJIOsplyqaquvv2.QLsIenEBVVjuQJVtkGQvvyKoyxUb = owuvaAsivLmBgouJIOsplyqaquvv2.hTbZgIlPllczYPBVUeVJOkuqKVGN.CzbwZNmocfkYZtLsRDMgpKiWskuo.actionElementMaps[i];
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn4 = MVKrWntQtrsQeICYnMigyMbXANPo.woGVtgbnGtfAnBkFXNFqtPwtviZc.Find(owuvaAsivLmBgouJIOsplyqaquvv2.wFeAajkniewEhkYluSPBRVJVBqFe);
						owuvaAsivLmBgouJIOsplyqaquvv2.QLsIenEBVVjuQJVtkGQvvyKoyxUb._actionId = eQMTLAegHWiDWcBWrbBOUDPgtUvn4?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
						owuvaAsivLmBgouJIOsplyqaquvv2.QLsIenEBVVjuQJVtkGQvvyKoyxUb._actionCategoryId = ((MVKrWntQtrsQeICYnMigyMbXANPo.jgngkWUxoNxoFJFTgPZKYgkaBxct.GetActionById(owuvaAsivLmBgouJIOsplyqaquvv2.QLsIenEBVVjuQJVtkGQvvyKoyxUb._actionId) != null) ? MVKrWntQtrsQeICYnMigyMbXANPo.jgngkWUxoNxoFJFTgPZKYgkaBxct.GetActionById(owuvaAsivLmBgouJIOsplyqaquvv2.QLsIenEBVVjuQJVtkGQvvyKoyxUb._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (vkZHQqAtJVWPdKpYwfrysCTHmbCw2.REqXdaXecUVHmCjUSfLMIRbrgcMFA.PgxZRdSdZvKfoiieShSPKLmcdCMpA)
					{
						controllerMap_Editor = vkZHQqAtJVWPdKpYwfrysCTHmbCw2.REqXdaXecUVHmCjUSfLMIRbrgcMFA.FlTDvwocioCFKVigEyEpIfMzkjCC;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.avCzYJYjOXfsMKMVJzPmLgSTannaA;
						GHDrzwvwmZmJMQlsmceWVOKbwVfb(controllerMap_Editor.actionElementMaps, vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo = controllerMap_Editor2;
					}
					else
					{
						MVKrWntQtrsQeICYnMigyMbXANPo.jgngkWUxoNxoFJFTgPZKYgkaBxct.CreateCustomControllerMap(vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo.categoryId, vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo.customControllerUid, vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo.layoutId);
						controllerMap_Editor = vkZHQqAtJVWPdKpYwfrysCTHmbCw2.REqXdaXecUVHmCjUSfLMIRbrgcMFA.PMObaMRavvLiNGNkmHbMQjgVdRnV[vkZHQqAtJVWPdKpYwfrysCTHmbCw2.REqXdaXecUVHmCjUSfLMIRbrgcMFA.PMObaMRavvLiNGNkmHbMQjgVdRnV.Count - 1];
					}
					vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo.id = controllerMap_Editor.id;
					int index = vkZHQqAtJVWPdKpYwfrysCTHmbCw2.REqXdaXecUVHmCjUSfLMIRbrgcMFA.PMObaMRavvLiNGNkmHbMQjgVdRnV.IndexOf(controllerMap_Editor);
					vkZHQqAtJVWPdKpYwfrysCTHmbCw2.REqXdaXecUVHmCjUSfLMIRbrgcMFA.PMObaMRavvLiNGNkmHbMQjgVdRnV[index] = vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo;
					return vkZHQqAtJVWPdKpYwfrysCTHmbCw2.CzbwZNmocfkYZtLsRDMgpKiWskuo;
				}
			}

			private sealed class AceVGIScBiHINmcfopUaQhkehSvo
			{
				public int ghomzlrlgXtfqqXICzWtheHCAgrP;

				internal bool PPlNhpkhJfiXlcQphpHPCvYChGmhc(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.XHQBrhCsnDhHYingzZwFuzxTAywc == ghomzlrlgXtfqqXICzWtheHCAgrP;
				}
			}

			private sealed class QJRKBsMbBrBiljAcWPaAHiNdQdOsc
			{
				public ControllerMap_Editor aikmZSJeYTqsAHcJfbODLinTzTqt;

				public Predicate<EQMTLAegHWiDWcBWrbBOUDPgtUvn> UBpZaQHPviegHJKkJPyvGxrvGywYA;

				public Predicate<EQMTLAegHWiDWcBWrbBOUDPgtUvn> CVQoGPtWnjLilljXWBOkqqLubRVIA;

				public Predicate<EQMTLAegHWiDWcBWrbBOUDPgtUvn> AsYWRPywjYNLjNwPyORjEONePpdW;

				internal bool aHtuhwBRUJinKHCmfTRhKrkKAgHL(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.XHQBrhCsnDhHYingzZwFuzxTAywc == aikmZSJeYTqsAHcJfbODLinTzTqt.customControllerUid;
				}

				internal bool UfGXRBrwoAGsRUdlNIDeCMndMzpnA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.XHQBrhCsnDhHYingzZwFuzxTAywc == aikmZSJeYTqsAHcJfbODLinTzTqt.categoryId;
				}

				internal bool RUGupubKDqwtBvtBIMtYgHeVBQIeA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.XHQBrhCsnDhHYingzZwFuzxTAywc == aikmZSJeYTqsAHcJfbODLinTzTqt.layoutId;
				}
			}

			private sealed class vkZHQqAtJVWPdKpYwfrysCTHmbCw
			{
				public IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMap_Editor> REqXdaXecUVHmCjUSfLMIRbrgcMFA;

				public ControllerMap_Editor CzbwZNmocfkYZtLsRDMgpKiWskuo;

				internal bool FslGFIiTlpKJYbmsHejqmfTGnntwc(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(REqXdaXecUVHmCjUSfLMIRbrgcMFA.pNJQYDJDastMNOhpwKvucKFLhVdG) == CzbwZNmocfkYZtLsRDMgpKiWskuo.customControllerUid;
				}

				internal bool LjHwURoOZpkLPwlclNAaFNkwIeuj(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(REqXdaXecUVHmCjUSfLMIRbrgcMFA.pNJQYDJDastMNOhpwKvucKFLhVdG) == CzbwZNmocfkYZtLsRDMgpKiWskuo.categoryId;
				}

				internal bool RNQTQtaoAlgiBDpVTzPteHZgcIocA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(REqXdaXecUVHmCjUSfLMIRbrgcMFA.pNJQYDJDastMNOhpwKvucKFLhVdG) == CzbwZNmocfkYZtLsRDMgpKiWskuo.layoutId;
				}
			}

			private sealed class owuvaAsivLmBgouJIOsplyqaquvv
			{
				public ActionElementMap QLsIenEBVVjuQJVtkGQvvyKoyxUb;

				public vkZHQqAtJVWPdKpYwfrysCTHmbCw hTbZgIlPllczYPBVUeVJOkuqKVGN;

				internal bool wFeAajkniewEhkYluSPBRVJVBqFe(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(hTbZgIlPllczYPBVUeVJOkuqKVGN.REqXdaXecUVHmCjUSfLMIRbrgcMFA.pNJQYDJDastMNOhpwKvucKFLhVdG) == QLsIenEBVVjuQJVtkGQvvyKoyxUb._actionId;
				}
			}

			private sealed class KYsrtHXNZBRBtqXcnVEcxNHIDBWS
			{
				public IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMapLayoutManager_RuleSet_Editor> UdmRgewnWjyWXdKfuydHCrZdBUUh;
			}

			private sealed class vUDbORDrhpnSiCmfeEgKTiNBErxd
			{
				public int FXShBdwgOwxXdOQwHMNiBNLKxSKk;

				public KYsrtHXNZBRBtqXcnVEcxNHIDBWS fnZaGckHsnaqnaDgANFGKfpbvfHld;

				internal bool FimCmKHKxOmlcxtvUFtiWMqsfzYS(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(fnZaGckHsnaqnaDgANFGKfpbvfHld.UdmRgewnWjyWXdKfuydHCrZdBUUh.pNJQYDJDastMNOhpwKvucKFLhVdG) == FXShBdwgOwxXdOQwHMNiBNLKxSKk;
				}
			}

			private sealed class VgRFQwDkhMNTIjyavMwlnBhstkyWA
			{
				public int VAoUWInmNWIofhIzttzOELHXFQlu;

				public KYsrtHXNZBRBtqXcnVEcxNHIDBWS WhpAHpgzbBdzWjGsZnYiwhCSCSobA;

				internal bool eTYfIIxYCoYPrIMWJzNlKDQQfnkK(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(WhpAHpgzbBdzWjGsZnYiwhCSCSobA.UdmRgewnWjyWXdKfuydHCrZdBUUh.pNJQYDJDastMNOhpwKvucKFLhVdG) == VAoUWInmNWIofhIzttzOELHXFQlu;
				}
			}

			private sealed class CkUBVsgQgeEUOdqWWQBPTAZbkdFt
			{
				public int kQiwrEBgwdwgAkTJUAyuaubQsbsA;

				public KYsrtHXNZBRBtqXcnVEcxNHIDBWS KurMdfqyIfSOWHWQLIzBRWHTtVee;

				internal bool ZTKpOFTbGCeRGcPmBcFSWxrVpLFS(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(KurMdfqyIfSOWHWQLIzBRWHTtVee.UdmRgewnWjyWXdKfuydHCrZdBUUh.pNJQYDJDastMNOhpwKvucKFLhVdG) == kQiwrEBgwdwgAkTJUAyuaubQsbsA;
				}
			}

			private sealed class XiGfbBJZiWcSMOQQWSrPfVsphanL
			{
				public IgBCFFIHIjGYbsbgcSQvofWiUNHu<ControllerMapEnabler_RuleSet_Editor> qXkhjZekahxPWgtwKIOaTDyHsogT;
			}

			private sealed class nVokvzWXqvNbjJMsdJDAxhaigkJB
			{
				public int rLWkdpXEkGmEOCtPWNeXKShIWVTh;

				public XiGfbBJZiWcSMOQQWSrPfVsphanL WxrWakdKvIeEJITyZgZJRWHrpIiN;

				internal bool PhBlsadsLtiISUPtfETdgBMPTvcm(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.PVrTAQrntkepKMjFEonxpNNXChQCA(WxrWakdKvIeEJITyZgZJRWHrpIiN.qXkhjZekahxPWgtwKIOaTDyHsogT.pNJQYDJDastMNOhpwKvucKFLhVdG) == rLWkdpXEkGmEOCtPWNeXKShIWVTh;
				}
			}

			private sealed class efSJgpAtqBRJIoKbFdqQHpgdYRsrA<_0001> where _0001 : class
			{
				public Func<_0001, int> wDoEWiRMPyTbydduLaxluDApYTme;
			}

			private sealed class AfoiWkuluVVJLHVZeTlkeZqufHaF<_0001> where _0001 : class
			{
				public _0001 QqcLCQWaCmciqkIGSOCXbvtqeLZDb;

				public efSJgpAtqBRJIoKbFdqQHpgdYRsrA<_0001> xvWftEeLcZeNmtWDALuoExwxVqZV;

				internal bool fZLegEeEWsSYajQVpGaXfTENYAAMA(EQMTLAegHWiDWcBWrbBOUDPgtUvn P_0)
				{
					return P_0.UXagnnFilWlyrvvXAgibstGKPJEPA == xvWftEeLcZeNmtWDALuoExwxVqZV.wDoEWiRMPyTbydduLaxluDApYTme(QqcLCQWaCmciqkIGSOCXbvtqeLZDb);
				}
			}

			public static UserData lHWErldndplwnWZRwNZcxKVzcxidA(UserData P_0, UserData P_1, bool P_2)
			{
				HpvjqnJtoIuQbndDldBUDpeLFqZS hpvjqnJtoIuQbndDldBUDpeLFqZS = new HpvjqnJtoIuQbndDldBUDpeLFqZS();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct = (P_2 ? P_0 : new UserData(false));
				if (P_1 != null)
				{
					hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.configVars = JsonTools.Clone(P_1.configVars);
				}
				else
				{
					hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.configVars = JsonTools.Clone(P_0.configVars);
				}
				hpvjqnJtoIuQbndDldBUDpeLFqZS.JiomnlLLhMegHjHPWRwearYjoLFab = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Action Category", P_0.actionCategories, P_1?.actionCategories, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.actionCategories, P_2, hpvjqnJtoIuQbndDldBUDpeLFqZS.JiomnlLLhMegHjHPWRwearYjoLFab, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.XBuzqKReKyGFpujpJrAagjpsAofs, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.kvLGbDqVClQyQLFRsQBEbOQQJpkB, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.ZKyMTWnqmQbLDCqPiSkRfQctFmdEA, hpvjqnJtoIuQbndDldBUDpeLFqZS.WTKEYLuuKSmVSNzvxDjSVufdtKRU);
				hpvjqnJtoIuQbndDldBUDpeLFqZS.hkgRgEDQhsPHDTarEfKsDaPJmkZL = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.inputBehaviors, P_2, hpvjqnJtoIuQbndDldBUDpeLFqZS.hkgRgEDQhsPHDTarEfKsDaPJmkZL, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.XBClvYtERSOvOWPxkCiafcFUXQxO, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.dUVjHTPmbUvvgJwCTWbQwNsvCYaC, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.eAtMGKpQLorSHRXAdFfAxiMhHEBL, hpvjqnJtoIuQbndDldBUDpeLFqZS.SPTndQFQxfrdomnFXgpTdKhxDbexA);
				hpvjqnJtoIuQbndDldBUDpeLFqZS.woGVtgbnGtfAnBkFXNFqtPwtviZc = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Action", P_0.UVcfFVlFayKsvGbNtLWpsgDDKbny, P_1?.UVcfFVlFayKsvGbNtLWpsgDDKbny, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.UVcfFVlFayKsvGbNtLWpsgDDKbny, P_2, hpvjqnJtoIuQbndDldBUDpeLFqZS.woGVtgbnGtfAnBkFXNFqtPwtviZc, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.IaWAhVPxSYcThQdUOlKrKqiLFuov, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.vzZYBKkbUHltcaLEdnXXmqjEVlGE, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.gVYbQkfnimycKwNfDhNDCLDAldGCb, hpvjqnJtoIuQbndDldBUDpeLFqZS.xPuCGOUTcDFJFznKAQomeYdGHhIt);
				hpvjqnJtoIuQbndDldBUDpeLFqZS.QWQVzEAharVPXiybbWvBhCJayxvK = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				jjEAUGXHzphieGAdOzCKYjcENpif jjEAUGXHzphieGAdOzCKYjcENpif2 = new jjEAUGXHzphieGAdOzCKYjcENpif();
				jjEAUGXHzphieGAdOzCKYjcENpif2.bSBfWigmTalvHDlYKdVWEpYhWodD = hpvjqnJtoIuQbndDldBUDpeLFqZS;
				jjEAUGXHzphieGAdOzCKYjcENpif2.mWgqBASnbKyqrCSvfNOlHVVaCzqu = new List<int>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Map Category", P_0.mapCategories, P_1?.mapCategories, jjEAUGXHzphieGAdOzCKYjcENpif2.bSBfWigmTalvHDlYKdVWEpYhWodD.jgngkWUxoNxoFJFTgPZKYgkaBxct.mapCategories, P_2, jjEAUGXHzphieGAdOzCKYjcENpif2.bSBfWigmTalvHDlYKdVWEpYhWodD.QWQVzEAharVPXiybbWvBhCJayxvK, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.BjmHHsVNogBhHMZDtTTixhgUfjmN, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.FwPkbHiTmtkevreiWZqEojtxwuei, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.GUJRJLYILMXVXuUPaOCNgpCCbOvP, jjEAUGXHzphieGAdOzCKYjcENpif2.NpfhnENcBJIYFgcsEjzTeHeYNztgb);
				for (int i = 0; i < jjEAUGXHzphieGAdOzCKYjcENpif2.mWgqBASnbKyqrCSvfNOlHVVaCzqu.Count; i++)
				{
					int index = jjEAUGXHzphieGAdOzCKYjcENpif2.mWgqBASnbKyqrCSvfNOlHVVaCzqu[i];
					InputMapCategory inputMapCategory = jjEAUGXHzphieGAdOzCKYjcENpif2.bSBfWigmTalvHDlYKdVWEpYhWodD.jgngkWUxoNxoFJFTgPZKYgkaBxct.mapCategories[index];
					for (int j = 0; j < inputMapCategory.efzpKliGPQMmlDbKJMufZpEmlOmW.Count; j++)
					{
						AceVGIScBiHINmcfopUaQhkehSvo aceVGIScBiHINmcfopUaQhkehSvo = new AceVGIScBiHINmcfopUaQhkehSvo();
						aceVGIScBiHINmcfopUaQhkehSvo.ghomzlrlgXtfqqXICzWtheHCAgrP = inputMapCategory.efzpKliGPQMmlDbKJMufZpEmlOmW[j];
						EQMTLAegHWiDWcBWrbBOUDPgtUvn eQMTLAegHWiDWcBWrbBOUDPgtUvn = jjEAUGXHzphieGAdOzCKYjcENpif2.bSBfWigmTalvHDlYKdVWEpYhWodD.QWQVzEAharVPXiybbWvBhCJayxvK.Find(aceVGIScBiHINmcfopUaQhkehSvo.PPlNhpkhJfiXlcQphpHPCvYChGmhc);
						inputMapCategory.efzpKliGPQMmlDbKJMufZpEmlOmW[j] = eQMTLAegHWiDWcBWrbBOUDPgtUvn?.UXagnnFilWlyrvvXAgibstGKPJEPA ?? (-1);
					}
				}
				hpvjqnJtoIuQbndDldBUDpeLFqZS.oXGYxUoQoZMvQVskouKdXDqCrfqp = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.keyboardLayouts, P_2, hpvjqnJtoIuQbndDldBUDpeLFqZS.oXGYxUoQoZMvQVskouKdXDqCrfqp, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.eogZjPeVMMlTnEIyBkUNbyrISqYI, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.eWcEIagfaHcHWAKwlJaWbmtAlDyeb, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.zgmKHvifhXpGEIGSYXabuHDtMyMk, hpvjqnJtoIuQbndDldBUDpeLFqZS.GzkFLOfGjvMNaPoKxXgcCPuaMJPQA);
				hpvjqnJtoIuQbndDldBUDpeLFqZS.LMCAGynufBIYmiXvgmksgHkcqAQqA = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.mouseLayouts, P_2, hpvjqnJtoIuQbndDldBUDpeLFqZS.LMCAGynufBIYmiXvgmksgHkcqAQqA, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.EzNpSZfIjOsVhMeANVCOcNJewrgi, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.AEkTKQhoYlnGxtJooGQMfPIijSGFb, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.ouZFIuQLeYGYObvkYKiDYyyecYxOA, hpvjqnJtoIuQbndDldBUDpeLFqZS.wvJgubgpmsItuXCmIjRCWxpoFfQe);
				hpvjqnJtoIuQbndDldBUDpeLFqZS.PAwdgHXCvxNbVUiPJqqSaxUKyQHf = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.joystickLayouts, P_2, hpvjqnJtoIuQbndDldBUDpeLFqZS.PAwdgHXCvxNbVUiPJqqSaxUKyQHf, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.FSDDXjRnceRoBphbcOFxKUGJrwEi, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.ZEjVkdNsfJDNDgIBrQmqEEGgqmDDA, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.ilIfmMJPaiReVquDcbjmRFvdQrmt, hpvjqnJtoIuQbndDldBUDpeLFqZS.mxpwDGpshQFvtiCFQwhlpCrrinxj);
				hpvjqnJtoIuQbndDldBUDpeLFqZS.dGKWvLEBQLtPElHWfFbjYlPTwlVp = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.customControllerLayouts, P_2, hpvjqnJtoIuQbndDldBUDpeLFqZS.dGKWvLEBQLtPElHWfFbjYlPTwlVp, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.pruwmeFXYUdYbbqVneeiOBrRYrcm, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.NVpTsxwtyguVJOcbOCZuUcQOAuCy, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.VmWylnGLLMCatIykwXYozXIkQZOj, hpvjqnJtoIuQbndDldBUDpeLFqZS.MyqLZQXxjzmAdBUaqJFybYFrqHZy);
				hpvjqnJtoIuQbndDldBUDpeLFqZS.oUIcYRDxWFYdBxlBGfdrBVYdywldB = hpvjqnJtoIuQbndDldBUDpeLFqZS.YoxKfDvFxaJzJJbiWEuPwgzuNvae;
				hpvjqnJtoIuQbndDldBUDpeLFqZS.xtsSBWrlCFWJaXOtBLoyVJjBCpTh = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Custom Controller", P_0.customControllers, P_1?.customControllers, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.customControllers, P_2, hpvjqnJtoIuQbndDldBUDpeLFqZS.xtsSBWrlCFWJaXOtBLoyVJjBCpTh, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.XZljKRvHBMIAzDNqUuuqAJKveCHRA, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.ADvuFdrGGhgNnrwsPFCVbhCKVreEA, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.FKVUJuAJHkuaXYxtJtwiDblAKCwK, hpvjqnJtoIuQbndDldBUDpeLFqZS.ItACrRQgsmlPNKDvsWeCOcjUsGwD);
				hpvjqnJtoIuQbndDldBUDpeLFqZS.JdhApSsVtKSDZmDVGggcGLwJolnI = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.controllerMapLayoutManagerRuleSets, P_2, hpvjqnJtoIuQbndDldBUDpeLFqZS.JdhApSsVtKSDZmDVGggcGLwJolnI, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.wLyqjdgCHhdVJebUFcwvdVOOHWAE, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.SOwBBPdkrDzdgQXfvSBqMkOzLqllA, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.eLhUpqoqEGsoiWxCkjasMlkFCGnIA, hpvjqnJtoIuQbndDldBUDpeLFqZS.GfiHMUCkephJMowuqRDdETrXqfCt);
				hpvjqnJtoIuQbndDldBUDpeLFqZS.ptkTLzuqAuHdjAEQJBJRCUuezLOaB = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.controllerMapEnablerRuleSets, P_2, hpvjqnJtoIuQbndDldBUDpeLFqZS.ptkTLzuqAuHdjAEQJBJRCUuezLOaB, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.jDzhyxWqScOitFMXCchwikIRolCbA, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.JANcDkgLBLmCbvHQrNvLqSQlZyQN, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.SLsyqArVOmiPwSdwiXXKwdjWcMBKA, hpvjqnJtoIuQbndDldBUDpeLFqZS.guzePciAbvuHKlQdrPcQbpEcDKpoA);
				List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> list = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Player", P_0.players, P_1?.players, hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct.players, P_2, list, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.UmDiZvKHBCccKtmDweewHhYWSaaF, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.cqKxioLlprbvqeLvyRivFgzNEgQW, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.lwxRWEyYGrHwUCSikOjXoDWpvcGy, hpvjqnJtoIuQbndDldBUDpeLFqZS.BtqkeCrIfdMtFzGAqBsVTzdGauTQ);
				List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> list2 = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				vdzKtZCDANfvkRNIoTJhxbqrSkue vdzKtZCDANfvkRNIoTJhxbqrSkue2 = new vdzKtZCDANfvkRNIoTJhxbqrSkue();
				vdzKtZCDANfvkRNIoTJhxbqrSkue2.dufEzOMaAuThMYcojaxhPoRlzsJm = hpvjqnJtoIuQbndDldBUDpeLFqZS;
				vdzKtZCDANfvkRNIoTJhxbqrSkue2.whZDBdptXKdmeBnCxncEBHVNkjaU = vdzKtZCDANfvkRNIoTJhxbqrSkue2.dufEzOMaAuThMYcojaxhPoRlzsJm.oXGYxUoQoZMvQVskouKdXDqCrfqp;
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, vdzKtZCDANfvkRNIoTJhxbqrSkue2.dufEzOMaAuThMYcojaxhPoRlzsJm.jgngkWUxoNxoFJFTgPZKYgkaBxct.keyboardMaps, P_2, list2, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.mkZcXPEpBSyrHDoMZhAwfVFYSmfxA, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.GDClhulEpQxGfijpWHLIjKyXpLjsA, vdzKtZCDANfvkRNIoTJhxbqrSkue2.OVFCGaIVAaOiQqktvHtboVJlydpGA, vdzKtZCDANfvkRNIoTJhxbqrSkue2.EClphHmvyORToWWUeIXoSWkejRQp);
				List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> list3 = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				MgEcDJmVfyaiVjWYXJLmCufkUkvd mgEcDJmVfyaiVjWYXJLmCufkUkvd = new MgEcDJmVfyaiVjWYXJLmCufkUkvd();
				mgEcDJmVfyaiVjWYXJLmCufkUkvd.rBTDxHPfWZXFrLUGDOuUrPzhcxwk = hpvjqnJtoIuQbndDldBUDpeLFqZS;
				mgEcDJmVfyaiVjWYXJLmCufkUkvd.cwUfIvUWdKoWSoDzJJmGhAuGfXyw = mgEcDJmVfyaiVjWYXJLmCufkUkvd.rBTDxHPfWZXFrLUGDOuUrPzhcxwk.LMCAGynufBIYmiXvgmksgHkcqAQqA;
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, mgEcDJmVfyaiVjWYXJLmCufkUkvd.rBTDxHPfWZXFrLUGDOuUrPzhcxwk.jgngkWUxoNxoFJFTgPZKYgkaBxct.mouseMaps, P_2, list3, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.UseZVzVtqBgwuzEPQabMakFyxRvp, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.jcYzWKcAtxQkczEPpGrlcCsoXzsq, mgEcDJmVfyaiVjWYXJLmCufkUkvd.MgATsxKMqbibbWSDeaKbZoehEjkv, mgEcDJmVfyaiVjWYXJLmCufkUkvd.RdupeSRMILjDNcfokWUWEODbbOqG);
				List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> list4 = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				vAnoLsPvAMblXpovbfeQPiJAAOekA vAnoLsPvAMblXpovbfeQPiJAAOekA2 = new vAnoLsPvAMblXpovbfeQPiJAAOekA();
				vAnoLsPvAMblXpovbfeQPiJAAOekA2.PyhxKYmmyxYRqPJLzFdsPwNBUyyL = hpvjqnJtoIuQbndDldBUDpeLFqZS;
				vAnoLsPvAMblXpovbfeQPiJAAOekA2.AQBZtJFdNaeXaliEimEObBMHHCen = vAnoLsPvAMblXpovbfeQPiJAAOekA2.PyhxKYmmyxYRqPJLzFdsPwNBUyyL.PAwdgHXCvxNbVUiPJqqSaxUKyQHf;
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, vAnoLsPvAMblXpovbfeQPiJAAOekA2.PyhxKYmmyxYRqPJLzFdsPwNBUyyL.jgngkWUxoNxoFJFTgPZKYgkaBxct.joystickMaps, P_2, list4, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.MkceKCBFHOgcDXeXiYhpIsdhFffPA, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.DoYWOBvicnaUIboNSExkevAdJlUXB, vAnoLsPvAMblXpovbfeQPiJAAOekA2.bcAJTJhmhbidNftDUjkDnQcDxgiBA, vAnoLsPvAMblXpovbfeQPiJAAOekA2.HxqfPPgDPUpYswGJlShEMWvSvjVIA);
				List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> list5 = new List<EQMTLAegHWiDWcBWrbBOUDPgtUvn>();
				eFRhCVeSOzhUGkMVuOXEWZBmaYIz eFRhCVeSOzhUGkMVuOXEWZBmaYIz2 = new eFRhCVeSOzhUGkMVuOXEWZBmaYIz();
				eFRhCVeSOzhUGkMVuOXEWZBmaYIz2.MVKrWntQtrsQeICYnMigyMbXANPo = hpvjqnJtoIuQbndDldBUDpeLFqZS;
				eFRhCVeSOzhUGkMVuOXEWZBmaYIz2.gvMfNIHalQturaIzLjHgBlqaACtFA = eFRhCVeSOzhUGkMVuOXEWZBmaYIz2.MVKrWntQtrsQeICYnMigyMbXANPo.dGKWvLEBQLtPElHWfFbjYlPTwlVp;
				EaAtcEpnGqYpSDkUiuiDSUAEYJHI("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, eFRhCVeSOzhUGkMVuOXEWZBmaYIz2.MVKrWntQtrsQeICYnMigyMbXANPo.jgngkWUxoNxoFJFTgPZKYgkaBxct.customControllerMaps, P_2, list5, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.rUyCtuZAsptZwDlSSADILngghXpo, QUnJklwLzEfXnNCHxZgYmiyBSnAn._003C_003E9.XJKqiCmLTVChytChnKkAQOAGsDJr, eFRhCVeSOzhUGkMVuOXEWZBmaYIz2.ZdDZzzOaSZLQDqmVFSZMQNtSGDQD, eFRhCVeSOzhUGkMVuOXEWZBmaYIz2.jKlbHJBmAYDTMijcylXFmSclYApL);
				return hpvjqnJtoIuQbndDldBUDpeLFqZS.jgngkWUxoNxoFJFTgPZKYgkaBxct;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void gZJhbZxGieZbigGCIbKUMfklaBxIA(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void GHDrzwvwmZmJMQlsmceWVOKbwVfb<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
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

			private static void EaAtcEpnGqYpSDkUiuiDSUAEYJHI<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<EQMTLAegHWiDWcBWrbBOUDPgtUvn> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<IgBCFFIHIjGYbsbgcSQvofWiUNHu<_0001>, _0001> P_9) where _0001 : class
			{
				efSJgpAtqBRJIoKbFdqQHpgdYRsrA<_0001> efSJgpAtqBRJIoKbFdqQHpgdYRsrA2 = new efSJgpAtqBRJIoKbFdqQHpgdYRsrA<_0001>();
				efSJgpAtqBRJIoKbFdqQHpgdYRsrA2.wDoEWiRMPyTbydduLaxluDApYTme = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					_0001 val = P_1[i];
					if (P_4)
					{
						P_5.Add(new EQMTLAegHWiDWcBWrbBOUDPgtUvn(efSJgpAtqBRJIoKbFdqQHpgdYRsrA2.wDoEWiRMPyTbydduLaxluDApYTme(val), -1, efSJgpAtqBRJIoKbFdqQHpgdYRsrA2.wDoEWiRMPyTbydduLaxluDApYTme(val)));
						continue;
					}
					_0001 arg = P_9(new IgBCFFIHIjGYbsbgcSQvofWiUNHu<_0001>(val, null, EQMTLAegHWiDWcBWrbBOUDPgtUvn.avjRWxrTQhVuPPOElqssnifNHKHO.origId, P_3, false));
					P_5.Add(new EQMTLAegHWiDWcBWrbBOUDPgtUvn(efSJgpAtqBRJIoKbFdqQHpgdYRsrA2.wDoEWiRMPyTbydduLaxluDApYTme(val), -1, efSJgpAtqBRJIoKbFdqQHpgdYRsrA2.wDoEWiRMPyTbydduLaxluDApYTme(arg)));
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
						AfoiWkuluVVJLHVZeTlkeZqufHaF<_0001> afoiWkuluVVJLHVZeTlkeZqufHaF = new AfoiWkuluVVJLHVZeTlkeZqufHaF<_0001>();
						afoiWkuluVVJLHVZeTlkeZqufHaF.xvWftEeLcZeNmtWDALuoExwxVqZV = efSJgpAtqBRJIoKbFdqQHpgdYRsrA2;
						_0001 val3 = P_3[num];
						afoiWkuluVVJLHVZeTlkeZqufHaF.QqcLCQWaCmciqkIGSOCXbvtqeLZDb = P_9(new IgBCFFIHIjGYbsbgcSQvofWiUNHu<_0001>(val2, val3, EQMTLAegHWiDWcBWrbBOUDPgtUvn.avjRWxrTQhVuPPOElqssnifNHKHO.otherId, P_3, true));
						P_5.Find(afoiWkuluVVJLHVZeTlkeZqufHaF.fZLegEeEWsSYajQVpGaXfTENYAAMA).XHQBrhCsnDhHYingzZwFuzxTAywc = afoiWkuluVVJLHVZeTlkeZqufHaF.xvWftEeLcZeNmtWDALuoExwxVqZV.wDoEWiRMPyTbydduLaxluDApYTme(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						_0001 arg2 = P_9(new IgBCFFIHIjGYbsbgcSQvofWiUNHu<_0001>(val2, null, EQMTLAegHWiDWcBWrbBOUDPgtUvn.avjRWxrTQhVuPPOElqssnifNHKHO.otherId, P_3, false));
						P_5.Add(new EQMTLAegHWiDWcBWrbBOUDPgtUvn(-1, efSJgpAtqBRJIoKbFdqQHpgdYRsrA2.wDoEWiRMPyTbydduLaxluDApYTme(val2), efSJgpAtqBRJIoKbFdqQHpgdYRsrA2.wDoEWiRMPyTbydduLaxluDApYTme(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}
		}

		[Serializable]
		private sealed class lnusoProFmJEOfcsnLZgCySOPjwi
		{
			public static readonly lnusoProFmJEOfcsnLZgCySOPjwi _003C_003E9 = new lnusoProFmJEOfcsnLZgCySOPjwi();

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__199_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__217_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__233_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__249_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__265_0;

			internal void juChYCYLANWVrJoGIknyviRPFbNI(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void VjbawLXZBJwspMUKhMkccGRylyBi(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void DVqfYvQrNCVrtJmjpIOQBYIXDmst(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void kuGGMORWcFdDDYBqMQZGpvCiVBrV(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void WOKaqwLmZSragipBuHQWvhNbNSQB(List<Player_Editor.Mapping> P_0, int P_1)
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

		private sealed class CKzjjCpBGAANnccNRMCAKWvaTJDOA
		{
			public List<InputLayout> PGcboeFVlDuLmCQYrxYOYXTLXNkm;

			internal int fsYDEHsfZNGHqIIDpgzpFFbFJVaBB(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				MRBEzvGAaVZpOgcGoAssTzhbbuQNA mRBEzvGAaVZpOgcGoAssTzhbbuQNA = new MRBEzvGAaVZpOgcGoAssTzhbbuQNA();
				mRBEzvGAaVZpOgcGoAssTzhbbuQNA.PRlUretOVsstNBUBQiNSmNIquTEh = P_0;
				mRBEzvGAaVZpOgcGoAssTzhbbuQNA.NFuEjidxvViaxqlEsbdPnFKVpGZz = P_1;
				int num = PGcboeFVlDuLmCQYrxYOYXTLXNkm.FindIndex(mRBEzvGAaVZpOgcGoAssTzhbbuQNA.hESBaRnaJaiqIaQnvUqlzCLIGefq);
				int num2 = PGcboeFVlDuLmCQYrxYOYXTLXNkm.FindIndex(mRBEzvGAaVZpOgcGoAssTzhbbuQNA.zIaCVnGNxYpZkZzbjuiFPpFJJZJV);
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

		private sealed class MRBEzvGAaVZpOgcGoAssTzhbbuQNA
		{
			public ControllerMap_Editor PRlUretOVsstNBUBQiNSmNIquTEh;

			public ControllerMap_Editor NFuEjidxvViaxqlEsbdPnFKVpGZz;

			internal bool hESBaRnaJaiqIaQnvUqlzCLIGefq(InputLayout P_0)
			{
				return P_0.id == PRlUretOVsstNBUBQiNSmNIquTEh.id;
			}

			internal bool zIaCVnGNxYpZkZzbjuiFPpFJJZJV(InputLayout P_0)
			{
				return P_0.id == NFuEjidxvViaxqlEsbdPnFKVpGZz.id;
			}
		}

		private sealed class CnsNiBoCrBrmivjNjbeKHGdLGdIaA : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int qTKYNlebozZQotdAJcvkKsbaulbA;

			private InputCategory kjQceMuFxflnbrqNSbehdkBLgzbEA;

			private int deJmwTizOslGxHxpfgHkWiFkoitC;

			private string vBLaDLZccALTPIAIcdXGaGCZbOKq;

			public string kvjmZtpGqgWPdNPXuFVKftxsWFVo;

			public UserData toIpzEOUTHFAaOxvsGgxrxcxGabk;

			private int TOkcEjnkHyLIpulTMFcAksbhyOsL;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return kjQceMuFxflnbrqNSbehdkBLgzbEA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return kjQceMuFxflnbrqNSbehdkBLgzbEA;
				}
			}

			[DebuggerHidden]
			public CnsNiBoCrBrmivjNjbeKHGdLGdIaA(int P_0)
			{
				qTKYNlebozZQotdAJcvkKsbaulbA = P_0;
				deJmwTizOslGxHxpfgHkWiFkoitC = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = qTKYNlebozZQotdAJcvkKsbaulbA;
				UserData userData = toIpzEOUTHFAaOxvsGgxrxcxGabk;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					qTKYNlebozZQotdAJcvkKsbaulbA = -1;
					goto IL_0098;
				}
				qTKYNlebozZQotdAJcvkKsbaulbA = -1;
				if (vBLaDLZccALTPIAIcdXGaGCZbOKq == null || vBLaDLZccALTPIAIcdXGaGCZbOKq == string.Empty)
				{
					return false;
				}
				if (userData.actionCategories == null)
				{
					return false;
				}
				TOkcEjnkHyLIpulTMFcAksbhyOsL = 0;
				goto IL_00a8;
				IL_00a8:
				if (TOkcEjnkHyLIpulTMFcAksbhyOsL < userData.actionCategories.Count)
				{
					if (userData.actionCategories[TOkcEjnkHyLIpulTMFcAksbhyOsL].tag.Equals(vBLaDLZccALTPIAIcdXGaGCZbOKq, StringComparison.OrdinalIgnoreCase))
					{
						kjQceMuFxflnbrqNSbehdkBLgzbEA = userData.actionCategories[TOkcEjnkHyLIpulTMFcAksbhyOsL];
						qTKYNlebozZQotdAJcvkKsbaulbA = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				TOkcEjnkHyLIpulTMFcAksbhyOsL++;
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
				CnsNiBoCrBrmivjNjbeKHGdLGdIaA cnsNiBoCrBrmivjNjbeKHGdLGdIaA;
				if (qTKYNlebozZQotdAJcvkKsbaulbA == -2 && deJmwTizOslGxHxpfgHkWiFkoitC == Environment.CurrentManagedThreadId)
				{
					qTKYNlebozZQotdAJcvkKsbaulbA = 0;
					cnsNiBoCrBrmivjNjbeKHGdLGdIaA = this;
				}
				else
				{
					cnsNiBoCrBrmivjNjbeKHGdLGdIaA = new CnsNiBoCrBrmivjNjbeKHGdLGdIaA(0);
					cnsNiBoCrBrmivjNjbeKHGdLGdIaA.toIpzEOUTHFAaOxvsGgxrxcxGabk = toIpzEOUTHFAaOxvsGgxrxcxGabk;
				}
				cnsNiBoCrBrmivjNjbeKHGdLGdIaA.vBLaDLZccALTPIAIcdXGaGCZbOKq = kvjmZtpGqgWPdNPXuFVKftxsWFVo;
				return cnsNiBoCrBrmivjNjbeKHGdLGdIaA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class tXYYziHDeORVTsBtNfRFdBdeMnRbb : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int JfvpHmwoBTDCkJUOAoavcbnEVUUF;

			private InputAction hoyAWVVDZXTgvgzKsDnffnLWBEru;

			private int wkBegdhbieCAkccngStaQhRRAqKEc;

			public UserData LliDBSgoZHlVRbRkrxReDIUHoyoN;

			private string IJhzxccCreEuoCYPeURUHkkwQTVc;

			public string QDmcTRtURIPPBcaEZXGPTZSDkWqb;

			private int QlisRRQkDmCAmjObybkkDPErJlMOA;

			private int UYayAJZqbekKWtLbFSbQflAdHOqcA;

			private InputCategory yqKPKmLuLOViTZPRgJbxNJzWjHlg;

			private int ZMpguFlXatqoYUqWVZOqzyJyUpwX;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return hoyAWVVDZXTgvgzKsDnffnLWBEru;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return hoyAWVVDZXTgvgzKsDnffnLWBEru;
				}
			}

			[DebuggerHidden]
			public tXYYziHDeORVTsBtNfRFdBdeMnRbb(int P_0)
			{
				JfvpHmwoBTDCkJUOAoavcbnEVUUF = P_0;
				wkBegdhbieCAkccngStaQhRRAqKEc = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int jfvpHmwoBTDCkJUOAoavcbnEVUUF = JfvpHmwoBTDCkJUOAoavcbnEVUUF;
				UserData lliDBSgoZHlVRbRkrxReDIUHoyoN = LliDBSgoZHlVRbRkrxReDIUHoyoN;
				if (jfvpHmwoBTDCkJUOAoavcbnEVUUF != 0)
				{
					if (jfvpHmwoBTDCkJUOAoavcbnEVUUF != 1)
					{
						return false;
					}
					JfvpHmwoBTDCkJUOAoavcbnEVUUF = -1;
					goto IL_00fd;
				}
				JfvpHmwoBTDCkJUOAoavcbnEVUUF = -1;
				if (lliDBSgoZHlVRbRkrxReDIUHoyoN.UVcfFVlFayKsvGbNtLWpsgDDKbny == null || lliDBSgoZHlVRbRkrxReDIUHoyoN.actionCategories == null)
				{
					return false;
				}
				if (IJhzxccCreEuoCYPeURUHkkwQTVc == null || IJhzxccCreEuoCYPeURUHkkwQTVc == string.Empty)
				{
					return false;
				}
				QlisRRQkDmCAmjObybkkDPErJlMOA = lliDBSgoZHlVRbRkrxReDIUHoyoN.UVcfFVlFayKsvGbNtLWpsgDDKbny.Count;
				UYayAJZqbekKWtLbFSbQflAdHOqcA = 0;
				goto IL_0132;
				IL_0122:
				UYayAJZqbekKWtLbFSbQflAdHOqcA++;
				goto IL_0132;
				IL_00fd:
				ZMpguFlXatqoYUqWVZOqzyJyUpwX++;
				goto IL_010d;
				IL_010d:
				if (ZMpguFlXatqoYUqWVZOqzyJyUpwX < QlisRRQkDmCAmjObybkkDPErJlMOA)
				{
					if (yqKPKmLuLOViTZPRgJbxNJzWjHlg.id == lliDBSgoZHlVRbRkrxReDIUHoyoN.UVcfFVlFayKsvGbNtLWpsgDDKbny[ZMpguFlXatqoYUqWVZOqzyJyUpwX].categoryId)
					{
						hoyAWVVDZXTgvgzKsDnffnLWBEru = lliDBSgoZHlVRbRkrxReDIUHoyoN.UVcfFVlFayKsvGbNtLWpsgDDKbny[ZMpguFlXatqoYUqWVZOqzyJyUpwX];
						JfvpHmwoBTDCkJUOAoavcbnEVUUF = 1;
						return true;
					}
					goto IL_00fd;
				}
				yqKPKmLuLOViTZPRgJbxNJzWjHlg = null;
				goto IL_0122;
				IL_0132:
				if (UYayAJZqbekKWtLbFSbQflAdHOqcA < lliDBSgoZHlVRbRkrxReDIUHoyoN.actionCategories.Count)
				{
					if (lliDBSgoZHlVRbRkrxReDIUHoyoN.actionCategories[UYayAJZqbekKWtLbFSbQflAdHOqcA].tag.Equals(IJhzxccCreEuoCYPeURUHkkwQTVc, StringComparison.OrdinalIgnoreCase))
					{
						yqKPKmLuLOViTZPRgJbxNJzWjHlg = lliDBSgoZHlVRbRkrxReDIUHoyoN.actionCategories[UYayAJZqbekKWtLbFSbQflAdHOqcA];
						ZMpguFlXatqoYUqWVZOqzyJyUpwX = 0;
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
				tXYYziHDeORVTsBtNfRFdBdeMnRbb tXYYziHDeORVTsBtNfRFdBdeMnRbb2;
				if (JfvpHmwoBTDCkJUOAoavcbnEVUUF == -2 && wkBegdhbieCAkccngStaQhRRAqKEc == Environment.CurrentManagedThreadId)
				{
					JfvpHmwoBTDCkJUOAoavcbnEVUUF = 0;
					tXYYziHDeORVTsBtNfRFdBdeMnRbb2 = this;
				}
				else
				{
					tXYYziHDeORVTsBtNfRFdBdeMnRbb2 = new tXYYziHDeORVTsBtNfRFdBdeMnRbb(0);
					tXYYziHDeORVTsBtNfRFdBdeMnRbb2.LliDBSgoZHlVRbRkrxReDIUHoyoN = LliDBSgoZHlVRbRkrxReDIUHoyoN;
				}
				tXYYziHDeORVTsBtNfRFdBdeMnRbb2.IJhzxccCreEuoCYPeURUHkkwQTVc = QDmcTRtURIPPBcaEZXGPTZSDkWqb;
				return tXYYziHDeORVTsBtNfRFdBdeMnRbb2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class DQrbbrjDNUPIhwJpXAwIUYiHNDSo : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int rlbLTfXXFyrlpBdrQdvrHJxILUGBb;

			private InputAction mCdtNtgFhChxzWUsVBwNEWeogrGBA;

			private int DDfDmfgqPhMgBxjvbhWTrWlPrRkW;

			public UserData rDSAZlCrpOmszQYRywFnbBgjPitHb;

			private bool YGyTRVhXpWmwEhjVLOiioqUDfxVC;

			public bool cbpCOufKLlpUVFkGHeclFCklhNMic;

			private int OqRfmiGkMpdHvvmYZVLfPPfxcGf;

			public int GNIGLWjchkDxqtFPYwCPBReMIaTPA;

			private IEnumerator<int> swXzoLiOqElYsEEdiKPWBkjDbGUdA;

			private int BAXrvvxovXJXBUvBAUeymZcOctxH;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return mCdtNtgFhChxzWUsVBwNEWeogrGBA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return mCdtNtgFhChxzWUsVBwNEWeogrGBA;
				}
			}

			[DebuggerHidden]
			public DQrbbrjDNUPIhwJpXAwIUYiHNDSo(int P_0)
			{
				rlbLTfXXFyrlpBdrQdvrHJxILUGBb = P_0;
				DDfDmfgqPhMgBxjvbhWTrWlPrRkW = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = rlbLTfXXFyrlpBdrQdvrHJxILUGBb;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						oMakQgxmfLYmnNphClWNRrHnlhSc();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = rlbLTfXXFyrlpBdrQdvrHJxILUGBb;
					UserData userData = rDSAZlCrpOmszQYRywFnbBgjPitHb;
					switch (num)
					{
					default:
						return false;
					case 0:
						rlbLTfXXFyrlpBdrQdvrHJxILUGBb = -1;
						if (userData.UVcfFVlFayKsvGbNtLWpsgDDKbny == null || userData.actionCategories == null)
						{
							return false;
						}
						if (YGyTRVhXpWmwEhjVLOiioqUDfxVC)
						{
							swXzoLiOqElYsEEdiKPWBkjDbGUdA = userData.SortedActionIdsInCategory(OqRfmiGkMpdHvvmYZVLfPPfxcGf).GetEnumerator();
							rlbLTfXXFyrlpBdrQdvrHJxILUGBb = -3;
							goto IL_00a5;
						}
						BAXrvvxovXJXBUvBAUeymZcOctxH = 0;
						goto IL_0123;
					case 1:
						rlbLTfXXFyrlpBdrQdvrHJxILUGBb = -3;
						goto IL_00a5;
					case 2:
						{
							rlbLTfXXFyrlpBdrQdvrHJxILUGBb = -1;
							goto IL_0111;
						}
						IL_0123:
						if (BAXrvvxovXJXBUvBAUeymZcOctxH >= userData.UVcfFVlFayKsvGbNtLWpsgDDKbny.Count)
						{
							break;
						}
						if (userData.UVcfFVlFayKsvGbNtLWpsgDDKbny[BAXrvvxovXJXBUvBAUeymZcOctxH].categoryId == OqRfmiGkMpdHvvmYZVLfPPfxcGf)
						{
							mCdtNtgFhChxzWUsVBwNEWeogrGBA = userData.UVcfFVlFayKsvGbNtLWpsgDDKbny[BAXrvvxovXJXBUvBAUeymZcOctxH];
							rlbLTfXXFyrlpBdrQdvrHJxILUGBb = 2;
							return true;
						}
						goto IL_0111;
						IL_0111:
						BAXrvvxovXJXBUvBAUeymZcOctxH++;
						goto IL_0123;
						IL_00a5:
						while (swXzoLiOqElYsEEdiKPWBkjDbGUdA.MoveNext())
						{
							int current = swXzoLiOqElYsEEdiKPWBkjDbGUdA.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null)
							{
								mCdtNtgFhChxzWUsVBwNEWeogrGBA = actionById;
								rlbLTfXXFyrlpBdrQdvrHJxILUGBb = 1;
								return true;
							}
						}
						oMakQgxmfLYmnNphClWNRrHnlhSc();
						swXzoLiOqElYsEEdiKPWBkjDbGUdA = null;
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

			private void oMakQgxmfLYmnNphClWNRrHnlhSc()
			{
				rlbLTfXXFyrlpBdrQdvrHJxILUGBb = -1;
				if (swXzoLiOqElYsEEdiKPWBkjDbGUdA != null)
				{
					swXzoLiOqElYsEEdiKPWBkjDbGUdA.Dispose();
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
				DQrbbrjDNUPIhwJpXAwIUYiHNDSo dQrbbrjDNUPIhwJpXAwIUYiHNDSo;
				if (rlbLTfXXFyrlpBdrQdvrHJxILUGBb == -2 && DDfDmfgqPhMgBxjvbhWTrWlPrRkW == Environment.CurrentManagedThreadId)
				{
					rlbLTfXXFyrlpBdrQdvrHJxILUGBb = 0;
					dQrbbrjDNUPIhwJpXAwIUYiHNDSo = this;
				}
				else
				{
					dQrbbrjDNUPIhwJpXAwIUYiHNDSo = new DQrbbrjDNUPIhwJpXAwIUYiHNDSo(0);
					dQrbbrjDNUPIhwJpXAwIUYiHNDSo.rDSAZlCrpOmszQYRywFnbBgjPitHb = rDSAZlCrpOmszQYRywFnbBgjPitHb;
				}
				dQrbbrjDNUPIhwJpXAwIUYiHNDSo.OqRfmiGkMpdHvvmYZVLfPPfxcGf = GNIGLWjchkDxqtFPYwCPBReMIaTPA;
				dQrbbrjDNUPIhwJpXAwIUYiHNDSo.YGyTRVhXpWmwEhjVLOiioqUDfxVC = cbpCOufKLlpUVFkGHeclFCklhNMic;
				return dQrbbrjDNUPIhwJpXAwIUYiHNDSo;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class gtDenqclDQNkLIvrUootERGjSaAs : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int tEyMOjMJzajgmXcTOsrVsEhadnCJA;

			private InputAction qreYsESHyNahFHyRHDHGivJFmVOmA;

			private int rjdeFckmVLvQdSZbxoJXYwHwsZrH;

			public UserData gKzpMQHdECBmGFNVNSEbgSnLQwzSA;

			private string dDvvfvifBQGLoCGueiFxcjTIobPKc;

			public string NNpFORmHPPOvEQDfCUnmKUVJgeKI;

			private bool MCnAQmWTIyHcWkpmTjFGGiHegyYb;

			public bool nNorJOvqBbLgyaXYUWefhLQbTwEj;

			private InputCategory jrLDotZtqNqhxCOqoKoFGqomrfXN;

			private IEnumerator<int> OWUPhtgRrEkQgSinPLAzETSCgxWU;

			private int TRglzNCWeqNslQGJCwDjtBMXgiCgA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return qreYsESHyNahFHyRHDHGivJFmVOmA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return qreYsESHyNahFHyRHDHGivJFmVOmA;
				}
			}

			[DebuggerHidden]
			public gtDenqclDQNkLIvrUootERGjSaAs(int P_0)
			{
				tEyMOjMJzajgmXcTOsrVsEhadnCJA = P_0;
				rjdeFckmVLvQdSZbxoJXYwHwsZrH = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = tEyMOjMJzajgmXcTOsrVsEhadnCJA;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						GPVAFCKDKpjiRbPqgoItXuJnrbin();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = tEyMOjMJzajgmXcTOsrVsEhadnCJA;
					UserData userData = gKzpMQHdECBmGFNVNSEbgSnLQwzSA;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						tEyMOjMJzajgmXcTOsrVsEhadnCJA = -1;
						if (userData.UVcfFVlFayKsvGbNtLWpsgDDKbny == null || userData.actionCategories == null)
						{
							return false;
						}
						if (dDvvfvifBQGLoCGueiFxcjTIobPKc == null || dDvvfvifBQGLoCGueiFxcjTIobPKc == string.Empty)
						{
							return false;
						}
						int num2 = userData.IndexOfActionCategory(dDvvfvifBQGLoCGueiFxcjTIobPKc);
						if (num2 < 0)
						{
							return false;
						}
						jrLDotZtqNqhxCOqoKoFGqomrfXN = userData.GetActionCategory(num2);
						if (MCnAQmWTIyHcWkpmTjFGGiHegyYb)
						{
							OWUPhtgRrEkQgSinPLAzETSCgxWU = userData.SortedActionIdsInCategory(jrLDotZtqNqhxCOqoKoFGqomrfXN.id).GetEnumerator();
							tEyMOjMJzajgmXcTOsrVsEhadnCJA = -3;
							goto IL_00f2;
						}
						TRglzNCWeqNslQGJCwDjtBMXgiCgA = 0;
						goto IL_0175;
					}
					case 1:
						tEyMOjMJzajgmXcTOsrVsEhadnCJA = -3;
						goto IL_00f2;
					case 2:
						{
							tEyMOjMJzajgmXcTOsrVsEhadnCJA = -1;
							goto IL_0163;
						}
						IL_0175:
						if (TRglzNCWeqNslQGJCwDjtBMXgiCgA >= userData.UVcfFVlFayKsvGbNtLWpsgDDKbny.Count)
						{
							break;
						}
						if (userData.UVcfFVlFayKsvGbNtLWpsgDDKbny[TRglzNCWeqNslQGJCwDjtBMXgiCgA].categoryId == jrLDotZtqNqhxCOqoKoFGqomrfXN.id)
						{
							qreYsESHyNahFHyRHDHGivJFmVOmA = userData.UVcfFVlFayKsvGbNtLWpsgDDKbny[TRglzNCWeqNslQGJCwDjtBMXgiCgA];
							tEyMOjMJzajgmXcTOsrVsEhadnCJA = 2;
							return true;
						}
						goto IL_0163;
						IL_00f2:
						while (OWUPhtgRrEkQgSinPLAzETSCgxWU.MoveNext())
						{
							int current = OWUPhtgRrEkQgSinPLAzETSCgxWU.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null)
							{
								qreYsESHyNahFHyRHDHGivJFmVOmA = actionById;
								tEyMOjMJzajgmXcTOsrVsEhadnCJA = 1;
								return true;
							}
						}
						GPVAFCKDKpjiRbPqgoItXuJnrbin();
						OWUPhtgRrEkQgSinPLAzETSCgxWU = null;
						break;
						IL_0163:
						TRglzNCWeqNslQGJCwDjtBMXgiCgA++;
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

			private void GPVAFCKDKpjiRbPqgoItXuJnrbin()
			{
				tEyMOjMJzajgmXcTOsrVsEhadnCJA = -1;
				if (OWUPhtgRrEkQgSinPLAzETSCgxWU != null)
				{
					OWUPhtgRrEkQgSinPLAzETSCgxWU.Dispose();
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
				gtDenqclDQNkLIvrUootERGjSaAs gtDenqclDQNkLIvrUootERGjSaAs2;
				if (tEyMOjMJzajgmXcTOsrVsEhadnCJA == -2 && rjdeFckmVLvQdSZbxoJXYwHwsZrH == Environment.CurrentManagedThreadId)
				{
					tEyMOjMJzajgmXcTOsrVsEhadnCJA = 0;
					gtDenqclDQNkLIvrUootERGjSaAs2 = this;
				}
				else
				{
					gtDenqclDQNkLIvrUootERGjSaAs2 = new gtDenqclDQNkLIvrUootERGjSaAs(0);
					gtDenqclDQNkLIvrUootERGjSaAs2.gKzpMQHdECBmGFNVNSEbgSnLQwzSA = gKzpMQHdECBmGFNVNSEbgSnLQwzSA;
				}
				gtDenqclDQNkLIvrUootERGjSaAs2.dDvvfvifBQGLoCGueiFxcjTIobPKc = NNpFORmHPPOvEQDfCUnmKUVJgeKI;
				gtDenqclDQNkLIvrUootERGjSaAs2.MCnAQmWTIyHcWkpmTjFGGiHegyYb = nNorJOvqBbLgyaXYUWefhLQbTwEj;
				return gtDenqclDQNkLIvrUootERGjSaAs2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class XeAamNfbIOplacsdUFqTmDIRVrSI : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int sQSOZuLtOoyASQWoWQDqYyNMUpcd;

			private InputMapCategory EZAyhcazQqTiQjzSaWTJChJyWoQK;

			private int ztPCaYhdTMMOqGFiNGwptKQVtuGw;

			private string YMXpqvporxNnMWbIxzvjPmDnIGmhA;

			public string dUAMcVzDRaOwOYZpTNTtllXPlRhK;

			public UserData hWnEuWTxIvAmxbvVSroxYYTlEAKC;

			private int hdtbUBRMkWTTvhlfbRlFFKNUezUt;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return EZAyhcazQqTiQjzSaWTJChJyWoQK;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return EZAyhcazQqTiQjzSaWTJChJyWoQK;
				}
			}

			[DebuggerHidden]
			public XeAamNfbIOplacsdUFqTmDIRVrSI(int P_0)
			{
				sQSOZuLtOoyASQWoWQDqYyNMUpcd = P_0;
				ztPCaYhdTMMOqGFiNGwptKQVtuGw = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = sQSOZuLtOoyASQWoWQDqYyNMUpcd;
				UserData userData = hWnEuWTxIvAmxbvVSroxYYTlEAKC;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					sQSOZuLtOoyASQWoWQDqYyNMUpcd = -1;
					goto IL_0098;
				}
				sQSOZuLtOoyASQWoWQDqYyNMUpcd = -1;
				if (YMXpqvporxNnMWbIxzvjPmDnIGmhA == null || YMXpqvporxNnMWbIxzvjPmDnIGmhA == string.Empty)
				{
					return false;
				}
				if (userData.mapCategories == null)
				{
					return false;
				}
				hdtbUBRMkWTTvhlfbRlFFKNUezUt = 0;
				goto IL_00a8;
				IL_00a8:
				if (hdtbUBRMkWTTvhlfbRlFFKNUezUt < userData.mapCategories.Count)
				{
					if (userData.mapCategories[hdtbUBRMkWTTvhlfbRlFFKNUezUt].tag.Equals(YMXpqvporxNnMWbIxzvjPmDnIGmhA, StringComparison.OrdinalIgnoreCase))
					{
						EZAyhcazQqTiQjzSaWTJChJyWoQK = userData.mapCategories[hdtbUBRMkWTTvhlfbRlFFKNUezUt];
						sQSOZuLtOoyASQWoWQDqYyNMUpcd = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				hdtbUBRMkWTTvhlfbRlFFKNUezUt++;
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
				XeAamNfbIOplacsdUFqTmDIRVrSI xeAamNfbIOplacsdUFqTmDIRVrSI;
				if (sQSOZuLtOoyASQWoWQDqYyNMUpcd == -2 && ztPCaYhdTMMOqGFiNGwptKQVtuGw == Environment.CurrentManagedThreadId)
				{
					sQSOZuLtOoyASQWoWQDqYyNMUpcd = 0;
					xeAamNfbIOplacsdUFqTmDIRVrSI = this;
				}
				else
				{
					xeAamNfbIOplacsdUFqTmDIRVrSI = new XeAamNfbIOplacsdUFqTmDIRVrSI(0);
					xeAamNfbIOplacsdUFqTmDIRVrSI.hWnEuWTxIvAmxbvVSroxYYTlEAKC = hWnEuWTxIvAmxbvVSroxYYTlEAKC;
				}
				xeAamNfbIOplacsdUFqTmDIRVrSI.YMXpqvporxNnMWbIxzvjPmDnIGmhA = dUAMcVzDRaOwOYZpTNTtllXPlRhK;
				return xeAamNfbIOplacsdUFqTmDIRVrSI;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class inTCBQFOXjsrHEbHdVFsoLiogduBb : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int VgBLAUEJnlpxAupxnHicjflFQNBv;

			private string ZmkySrDBOVwiqLqieeqLdFHHubgJA;

			private int dJzTQqDZLkrnCsZPzpcRIhTWikcO;

			public UserData ZWMErnhQMcUpUPujnPXeegvCXQXyB;

			private int hPtQbUKdWUUzcltoOlLcebYBiZXB;

			public int LOIPPgNrYIyuKVbyDbinaCKCKwAG;

			private IEnumerator<int> RdHAJYUSUZlEAUNPLHYmZngNygOe;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return ZmkySrDBOVwiqLqieeqLdFHHubgJA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ZmkySrDBOVwiqLqieeqLdFHHubgJA;
				}
			}

			[DebuggerHidden]
			public inTCBQFOXjsrHEbHdVFsoLiogduBb(int P_0)
			{
				VgBLAUEJnlpxAupxnHicjflFQNBv = P_0;
				dJzTQqDZLkrnCsZPzpcRIhTWikcO = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int vgBLAUEJnlpxAupxnHicjflFQNBv = VgBLAUEJnlpxAupxnHicjflFQNBv;
				if (vgBLAUEJnlpxAupxnHicjflFQNBv == -3 || vgBLAUEJnlpxAupxnHicjflFQNBv == 1)
				{
					try
					{
					}
					finally
					{
						FZjWchtgcitkgTrjTpNnXJiBiUES();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int vgBLAUEJnlpxAupxnHicjflFQNBv = VgBLAUEJnlpxAupxnHicjflFQNBv;
					UserData zWMErnhQMcUpUPujnPXeegvCXQXyB = ZWMErnhQMcUpUPujnPXeegvCXQXyB;
					switch (vgBLAUEJnlpxAupxnHicjflFQNBv)
					{
					default:
						return false;
					case 0:
						VgBLAUEJnlpxAupxnHicjflFQNBv = -1;
						if (zWMErnhQMcUpUPujnPXeegvCXQXyB.actionCategories == null || zWMErnhQMcUpUPujnPXeegvCXQXyB.UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
						{
							return false;
						}
						RdHAJYUSUZlEAUNPLHYmZngNygOe = zWMErnhQMcUpUPujnPXeegvCXQXyB.actionCategoryMap.ActionIdsInCategory(hPtQbUKdWUUzcltoOlLcebYBiZXB).GetEnumerator();
						VgBLAUEJnlpxAupxnHicjflFQNBv = -3;
						break;
					case 1:
						VgBLAUEJnlpxAupxnHicjflFQNBv = -3;
						break;
					}
					while (RdHAJYUSUZlEAUNPLHYmZngNygOe.MoveNext())
					{
						int current = RdHAJYUSUZlEAUNPLHYmZngNygOe.Current;
						InputAction actionById = zWMErnhQMcUpUPujnPXeegvCXQXyB.GetActionById(current);
						if (actionById != null)
						{
							ZmkySrDBOVwiqLqieeqLdFHHubgJA = actionById.descriptiveName;
							VgBLAUEJnlpxAupxnHicjflFQNBv = 1;
							return true;
						}
					}
					FZjWchtgcitkgTrjTpNnXJiBiUES();
					RdHAJYUSUZlEAUNPLHYmZngNygOe = null;
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

			private void FZjWchtgcitkgTrjTpNnXJiBiUES()
			{
				VgBLAUEJnlpxAupxnHicjflFQNBv = -1;
				if (RdHAJYUSUZlEAUNPLHYmZngNygOe != null)
				{
					RdHAJYUSUZlEAUNPLHYmZngNygOe.Dispose();
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
				inTCBQFOXjsrHEbHdVFsoLiogduBb inTCBQFOXjsrHEbHdVFsoLiogduBb2;
				if (VgBLAUEJnlpxAupxnHicjflFQNBv == -2 && dJzTQqDZLkrnCsZPzpcRIhTWikcO == Environment.CurrentManagedThreadId)
				{
					VgBLAUEJnlpxAupxnHicjflFQNBv = 0;
					inTCBQFOXjsrHEbHdVFsoLiogduBb2 = this;
				}
				else
				{
					inTCBQFOXjsrHEbHdVFsoLiogduBb2 = new inTCBQFOXjsrHEbHdVFsoLiogduBb(0);
					inTCBQFOXjsrHEbHdVFsoLiogduBb2.ZWMErnhQMcUpUPujnPXeegvCXQXyB = ZWMErnhQMcUpUPujnPXeegvCXQXyB;
				}
				inTCBQFOXjsrHEbHdVFsoLiogduBb2.hPtQbUKdWUUzcltoOlLcebYBiZXB = LOIPPgNrYIyuKVbyDbinaCKCKwAG;
				return inTCBQFOXjsrHEbHdVFsoLiogduBb2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class csJjbwTTCMHhVLaSWqyFlXVXtzok : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int xdeKwHRkRRVvEZQubYYwjfQxIrlR;

			private int msnbhYATpNnBEvjQeYQtzzsivOiL;

			private int xnpcvxRTcKoKWUlztWSogUcYjjuE;

			public UserData LoaGjNdIJNpylFHVCfZsKOiFhIgV;

			private int gnabMJANhESGiThrJvUEuUSZminf;

			public int CPdHPBawDPmdZROorbCdNIefLgaD;

			private IEnumerator<int> fBTcmrbYHVHAgLlzlzjngcmgXMaNA;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return msnbhYATpNnBEvjQeYQtzzsivOiL;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return msnbhYATpNnBEvjQeYQtzzsivOiL;
				}
			}

			[DebuggerHidden]
			public csJjbwTTCMHhVLaSWqyFlXVXtzok(int P_0)
			{
				xdeKwHRkRRVvEZQubYYwjfQxIrlR = P_0;
				xnpcvxRTcKoKWUlztWSogUcYjjuE = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = xdeKwHRkRRVvEZQubYYwjfQxIrlR;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						QnznyhGggWNXmhUphlAuHzOHbmFj();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = xdeKwHRkRRVvEZQubYYwjfQxIrlR;
					UserData loaGjNdIJNpylFHVCfZsKOiFhIgV = LoaGjNdIJNpylFHVCfZsKOiFhIgV;
					switch (num)
					{
					default:
						return false;
					case 0:
						xdeKwHRkRRVvEZQubYYwjfQxIrlR = -1;
						if (loaGjNdIJNpylFHVCfZsKOiFhIgV.actionCategories == null || loaGjNdIJNpylFHVCfZsKOiFhIgV.UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
						{
							return false;
						}
						fBTcmrbYHVHAgLlzlzjngcmgXMaNA = loaGjNdIJNpylFHVCfZsKOiFhIgV.actionCategoryMap.ActionIdsInCategory(gnabMJANhESGiThrJvUEuUSZminf).GetEnumerator();
						xdeKwHRkRRVvEZQubYYwjfQxIrlR = -3;
						break;
					case 1:
						xdeKwHRkRRVvEZQubYYwjfQxIrlR = -3;
						break;
					}
					if (fBTcmrbYHVHAgLlzlzjngcmgXMaNA.MoveNext())
					{
						int current = fBTcmrbYHVHAgLlzlzjngcmgXMaNA.Current;
						msnbhYATpNnBEvjQeYQtzzsivOiL = current;
						xdeKwHRkRRVvEZQubYYwjfQxIrlR = 1;
						return true;
					}
					QnznyhGggWNXmhUphlAuHzOHbmFj();
					fBTcmrbYHVHAgLlzlzjngcmgXMaNA = null;
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

			private void QnznyhGggWNXmhUphlAuHzOHbmFj()
			{
				xdeKwHRkRRVvEZQubYYwjfQxIrlR = -1;
				if (fBTcmrbYHVHAgLlzlzjngcmgXMaNA != null)
				{
					fBTcmrbYHVHAgLlzlzjngcmgXMaNA.Dispose();
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
				csJjbwTTCMHhVLaSWqyFlXVXtzok csJjbwTTCMHhVLaSWqyFlXVXtzok2;
				if (xdeKwHRkRRVvEZQubYYwjfQxIrlR == -2 && xnpcvxRTcKoKWUlztWSogUcYjjuE == Environment.CurrentManagedThreadId)
				{
					xdeKwHRkRRVvEZQubYYwjfQxIrlR = 0;
					csJjbwTTCMHhVLaSWqyFlXVXtzok2 = this;
				}
				else
				{
					csJjbwTTCMHhVLaSWqyFlXVXtzok2 = new csJjbwTTCMHhVLaSWqyFlXVXtzok(0);
					csJjbwTTCMHhVLaSWqyFlXVXtzok2.LoaGjNdIJNpylFHVCfZsKOiFhIgV = LoaGjNdIJNpylFHVCfZsKOiFhIgV;
				}
				csJjbwTTCMHhVLaSWqyFlXVXtzok2.gnabMJANhESGiThrJvUEuUSZminf = CPdHPBawDPmdZROorbCdNIefLgaD;
				return csJjbwTTCMHhVLaSWqyFlXVXtzok2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		private sealed class qSgDyNvWjHOcuuiwdowdYWAJSFU : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int EBKDWnWYrplEVLdreCNvqnndQGXk;

			private string BBQLJYVIMAglrARVNdiJKIgmNJXo;

			private int fLmArtBLkTlFZiGIbAwtcdPKlYTYb;

			public UserData mNfgiADkgUlMqdalEndkfCmoOapt;

			private int hWqgtsqkBFcoksAuNubbOVrhbOi;

			public int MmzcmFBEfwJJqbdYeCnPVNbanaltA;

			private IEnumerator<int> BjWeRnArxrblpdGkjOFVObzeIYVzB;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return BBQLJYVIMAglrARVNdiJKIgmNJXo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return BBQLJYVIMAglrARVNdiJKIgmNJXo;
				}
			}

			[DebuggerHidden]
			public qSgDyNvWjHOcuuiwdowdYWAJSFU(int P_0)
			{
				EBKDWnWYrplEVLdreCNvqnndQGXk = P_0;
				fLmArtBLkTlFZiGIbAwtcdPKlYTYb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int eBKDWnWYrplEVLdreCNvqnndQGXk = EBKDWnWYrplEVLdreCNvqnndQGXk;
				if (eBKDWnWYrplEVLdreCNvqnndQGXk == -3 || eBKDWnWYrplEVLdreCNvqnndQGXk == 1)
				{
					try
					{
					}
					finally
					{
						mvjlvBMEjJaVTQfjNguLtpigdXkEA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int eBKDWnWYrplEVLdreCNvqnndQGXk = EBKDWnWYrplEVLdreCNvqnndQGXk;
					UserData userData = mNfgiADkgUlMqdalEndkfCmoOapt;
					switch (eBKDWnWYrplEVLdreCNvqnndQGXk)
					{
					default:
						return false;
					case 0:
						EBKDWnWYrplEVLdreCNvqnndQGXk = -1;
						if (userData.actionCategories == null || userData.UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
						{
							return false;
						}
						BjWeRnArxrblpdGkjOFVObzeIYVzB = userData.actionCategoryMap.ActionIdsInCategory(hWqgtsqkBFcoksAuNubbOVrhbOi).GetEnumerator();
						EBKDWnWYrplEVLdreCNvqnndQGXk = -3;
						break;
					case 1:
						EBKDWnWYrplEVLdreCNvqnndQGXk = -3;
						break;
					}
					while (BjWeRnArxrblpdGkjOFVObzeIYVzB.MoveNext())
					{
						int current = BjWeRnArxrblpdGkjOFVObzeIYVzB.Current;
						InputAction actionById = userData.GetActionById(current);
						if (actionById != null)
						{
							BBQLJYVIMAglrARVNdiJKIgmNJXo = actionById.name;
							EBKDWnWYrplEVLdreCNvqnndQGXk = 1;
							return true;
						}
					}
					mvjlvBMEjJaVTQfjNguLtpigdXkEA();
					BjWeRnArxrblpdGkjOFVObzeIYVzB = null;
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

			private void mvjlvBMEjJaVTQfjNguLtpigdXkEA()
			{
				EBKDWnWYrplEVLdreCNvqnndQGXk = -1;
				if (BjWeRnArxrblpdGkjOFVObzeIYVzB != null)
				{
					BjWeRnArxrblpdGkjOFVObzeIYVzB.Dispose();
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
				qSgDyNvWjHOcuuiwdowdYWAJSFU qSgDyNvWjHOcuuiwdowdYWAJSFU2;
				if (EBKDWnWYrplEVLdreCNvqnndQGXk == -2 && fLmArtBLkTlFZiGIbAwtcdPKlYTYb == Environment.CurrentManagedThreadId)
				{
					EBKDWnWYrplEVLdreCNvqnndQGXk = 0;
					qSgDyNvWjHOcuuiwdowdYWAJSFU2 = this;
				}
				else
				{
					qSgDyNvWjHOcuuiwdowdYWAJSFU2 = new qSgDyNvWjHOcuuiwdowdYWAJSFU(0);
					qSgDyNvWjHOcuuiwdowdYWAJSFU2.mNfgiADkgUlMqdalEndkfCmoOapt = mNfgiADkgUlMqdalEndkfCmoOapt;
				}
				qSgDyNvWjHOcuuiwdowdYWAJSFU2.hWqgtsqkBFcoksAuNubbOVrhbOi = MmzcmFBEfwJJqbdYeCnPVNbanaltA;
				return qSgDyNvWjHOcuuiwdowdYWAJSFU2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class AnWjyhJSACYxLRmTjkRpFhCotItb : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int pthQXFslYTDLePAsGeDcBNZXoCTgA;

			private InputCategory InpdbwdinnlNbWWfTbmzKniUoXCf;

			private int gkkYRuvwmIahtDJJqzhGSheqcyRhA;

			private string RLdaqfKfnPZXhkPhjkTtlwMFRnZvA;

			public string toXBlyAzCmAGNjNdGinylIJArmdkC;

			public UserData tEUJBFnuWQdUtbQMhcgBVAsMlgOh;

			private int rAKiqXcGrDeJeRjvLxRTnqQtlnuIA;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return InpdbwdinnlNbWWfTbmzKniUoXCf;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return InpdbwdinnlNbWWfTbmzKniUoXCf;
				}
			}

			[DebuggerHidden]
			public AnWjyhJSACYxLRmTjkRpFhCotItb(int P_0)
			{
				pthQXFslYTDLePAsGeDcBNZXoCTgA = P_0;
				gkkYRuvwmIahtDJJqzhGSheqcyRhA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = pthQXFslYTDLePAsGeDcBNZXoCTgA;
				UserData userData = tEUJBFnuWQdUtbQMhcgBVAsMlgOh;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					pthQXFslYTDLePAsGeDcBNZXoCTgA = -1;
					goto IL_00b3;
				}
				pthQXFslYTDLePAsGeDcBNZXoCTgA = -1;
				if (RLdaqfKfnPZXhkPhjkTtlwMFRnZvA == null || RLdaqfKfnPZXhkPhjkTtlwMFRnZvA == string.Empty)
				{
					return false;
				}
				if (userData.actionCategories == null)
				{
					return false;
				}
				rAKiqXcGrDeJeRjvLxRTnqQtlnuIA = 0;
				goto IL_00c3;
				IL_00c3:
				if (rAKiqXcGrDeJeRjvLxRTnqQtlnuIA < userData.actionCategories.Count)
				{
					if (userData.actionCategories[rAKiqXcGrDeJeRjvLxRTnqQtlnuIA].userAssignable && userData.actionCategories[rAKiqXcGrDeJeRjvLxRTnqQtlnuIA].tag.Equals(RLdaqfKfnPZXhkPhjkTtlwMFRnZvA, StringComparison.OrdinalIgnoreCase))
					{
						InpdbwdinnlNbWWfTbmzKniUoXCf = userData.actionCategories[rAKiqXcGrDeJeRjvLxRTnqQtlnuIA];
						pthQXFslYTDLePAsGeDcBNZXoCTgA = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				rAKiqXcGrDeJeRjvLxRTnqQtlnuIA++;
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
				AnWjyhJSACYxLRmTjkRpFhCotItb anWjyhJSACYxLRmTjkRpFhCotItb;
				if (pthQXFslYTDLePAsGeDcBNZXoCTgA == -2 && gkkYRuvwmIahtDJJqzhGSheqcyRhA == Environment.CurrentManagedThreadId)
				{
					pthQXFslYTDLePAsGeDcBNZXoCTgA = 0;
					anWjyhJSACYxLRmTjkRpFhCotItb = this;
				}
				else
				{
					anWjyhJSACYxLRmTjkRpFhCotItb = new AnWjyhJSACYxLRmTjkRpFhCotItb(0);
					anWjyhJSACYxLRmTjkRpFhCotItb.tEUJBFnuWQdUtbQMhcgBVAsMlgOh = tEUJBFnuWQdUtbQMhcgBVAsMlgOh;
				}
				anWjyhJSACYxLRmTjkRpFhCotItb.RLdaqfKfnPZXhkPhjkTtlwMFRnZvA = toXBlyAzCmAGNjNdGinylIJArmdkC;
				return anWjyhJSACYxLRmTjkRpFhCotItb;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class pdIwqUkdVsXSwKwAYnbUAKxebkTjA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int QgZerjhdaOSWcwnhKfCbaBZBNSdgc;

			private InputAction puEFbOcQcgUDsRNahzdSUoaJGNnTA;

			private int gQgpcEqJNplSWeynmFocsacwppTI;

			public UserData YGrEMSbsrtfBnhNslRMYsnChZtcOA;

			private int vqcnSkVCxLMUmLQiuVAeygzhMJIo;

			public int zThcYJAvUGOgEONwYMaxqrBGOkNu;

			private bool lQdvnkToVtAuxtSkbglRcBpLfxVtA;

			public bool RGCBqiPDRFcrjALuaoaCTPjpMePd;

			private InputCategory JcSzqkOGHPqSMZYxVHMZCVwSGvjx;

			private IEnumerator<int> lrURHNZhhLtKVLLnUzyZiPnBuZRs;

			private int JrvLaTqilYGXTKBWjhYakUylCsmb;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return puEFbOcQcgUDsRNahzdSUoaJGNnTA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return puEFbOcQcgUDsRNahzdSUoaJGNnTA;
				}
			}

			[DebuggerHidden]
			public pdIwqUkdVsXSwKwAYnbUAKxebkTjA(int P_0)
			{
				QgZerjhdaOSWcwnhKfCbaBZBNSdgc = P_0;
				gQgpcEqJNplSWeynmFocsacwppTI = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int qgZerjhdaOSWcwnhKfCbaBZBNSdgc = QgZerjhdaOSWcwnhKfCbaBZBNSdgc;
				if (qgZerjhdaOSWcwnhKfCbaBZBNSdgc == -3 || qgZerjhdaOSWcwnhKfCbaBZBNSdgc == 1)
				{
					try
					{
					}
					finally
					{
						jGJhkjCFMWvMtDqBojObpwMgkhim();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int qgZerjhdaOSWcwnhKfCbaBZBNSdgc = QgZerjhdaOSWcwnhKfCbaBZBNSdgc;
					UserData yGrEMSbsrtfBnhNslRMYsnChZtcOA = YGrEMSbsrtfBnhNslRMYsnChZtcOA;
					InputAction inputAction;
					switch (qgZerjhdaOSWcwnhKfCbaBZBNSdgc)
					{
					default:
						return false;
					case 0:
						QgZerjhdaOSWcwnhKfCbaBZBNSdgc = -1;
						if (yGrEMSbsrtfBnhNslRMYsnChZtcOA.UVcfFVlFayKsvGbNtLWpsgDDKbny == null || yGrEMSbsrtfBnhNslRMYsnChZtcOA.actionCategories == null)
						{
							return false;
						}
						JcSzqkOGHPqSMZYxVHMZCVwSGvjx = yGrEMSbsrtfBnhNslRMYsnChZtcOA.GetActionCategoryById(vqcnSkVCxLMUmLQiuVAeygzhMJIo);
						if (JcSzqkOGHPqSMZYxVHMZCVwSGvjx == null || !JcSzqkOGHPqSMZYxVHMZCVwSGvjx.userAssignable)
						{
							return false;
						}
						if (lQdvnkToVtAuxtSkbglRcBpLfxVtA)
						{
							lrURHNZhhLtKVLLnUzyZiPnBuZRs = yGrEMSbsrtfBnhNslRMYsnChZtcOA.SortedActionIdsInCategory(JcSzqkOGHPqSMZYxVHMZCVwSGvjx.id).GetEnumerator();
							QgZerjhdaOSWcwnhKfCbaBZBNSdgc = -3;
							goto IL_00e4;
						}
						JrvLaTqilYGXTKBWjhYakUylCsmb = 0;
						goto IL_0165;
					case 1:
						QgZerjhdaOSWcwnhKfCbaBZBNSdgc = -3;
						goto IL_00e4;
					case 2:
						{
							QgZerjhdaOSWcwnhKfCbaBZBNSdgc = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (lrURHNZhhLtKVLLnUzyZiPnBuZRs.MoveNext())
						{
							int current = lrURHNZhhLtKVLLnUzyZiPnBuZRs.Current;
							InputAction actionById = yGrEMSbsrtfBnhNslRMYsnChZtcOA.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								puEFbOcQcgUDsRNahzdSUoaJGNnTA = actionById;
								QgZerjhdaOSWcwnhKfCbaBZBNSdgc = 1;
								return true;
							}
						}
						jGJhkjCFMWvMtDqBojObpwMgkhim();
						lrURHNZhhLtKVLLnUzyZiPnBuZRs = null;
						break;
						IL_0153:
						JrvLaTqilYGXTKBWjhYakUylCsmb++;
						goto IL_0165;
						IL_0165:
						if (JrvLaTqilYGXTKBWjhYakUylCsmb >= yGrEMSbsrtfBnhNslRMYsnChZtcOA.UVcfFVlFayKsvGbNtLWpsgDDKbny.Count)
						{
							break;
						}
						inputAction = yGrEMSbsrtfBnhNslRMYsnChZtcOA.UVcfFVlFayKsvGbNtLWpsgDDKbny[JrvLaTqilYGXTKBWjhYakUylCsmb];
						if (inputAction.categoryId == JcSzqkOGHPqSMZYxVHMZCVwSGvjx.id && inputAction.userAssignable)
						{
							puEFbOcQcgUDsRNahzdSUoaJGNnTA = inputAction;
							QgZerjhdaOSWcwnhKfCbaBZBNSdgc = 2;
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

			private void jGJhkjCFMWvMtDqBojObpwMgkhim()
			{
				QgZerjhdaOSWcwnhKfCbaBZBNSdgc = -1;
				if (lrURHNZhhLtKVLLnUzyZiPnBuZRs != null)
				{
					lrURHNZhhLtKVLLnUzyZiPnBuZRs.Dispose();
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
				pdIwqUkdVsXSwKwAYnbUAKxebkTjA pdIwqUkdVsXSwKwAYnbUAKxebkTjA2;
				if (QgZerjhdaOSWcwnhKfCbaBZBNSdgc == -2 && gQgpcEqJNplSWeynmFocsacwppTI == Environment.CurrentManagedThreadId)
				{
					QgZerjhdaOSWcwnhKfCbaBZBNSdgc = 0;
					pdIwqUkdVsXSwKwAYnbUAKxebkTjA2 = this;
				}
				else
				{
					pdIwqUkdVsXSwKwAYnbUAKxebkTjA2 = new pdIwqUkdVsXSwKwAYnbUAKxebkTjA(0);
					pdIwqUkdVsXSwKwAYnbUAKxebkTjA2.YGrEMSbsrtfBnhNslRMYsnChZtcOA = YGrEMSbsrtfBnhNslRMYsnChZtcOA;
				}
				pdIwqUkdVsXSwKwAYnbUAKxebkTjA2.vqcnSkVCxLMUmLQiuVAeygzhMJIo = zThcYJAvUGOgEONwYMaxqrBGOkNu;
				pdIwqUkdVsXSwKwAYnbUAKxebkTjA2.lQdvnkToVtAuxtSkbglRcBpLfxVtA = RGCBqiPDRFcrjALuaoaCTPjpMePd;
				return pdIwqUkdVsXSwKwAYnbUAKxebkTjA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class itIEIrnpYqDNiVbhPuRAsTHDvhoT : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int FamookpIDTGXsFcMjvgmHSyabmRD;

			private InputAction FnvkVfLdUErcRqCfkBlANcItTPBo;

			private int icpjLRJjzEZhKrRopuIlHbavcFRK;

			public UserData ZaRlCLPuohpiGjlPHDzJEDEdPuqFA;

			private string lredTKdpBRiHhLBifkPpWyXHKOhgA;

			public string gUzYKHrYVzgbHtLMHWRfhNSpJpWt;

			private bool FOeBirEfLOlCwIWUFGuMHKWjhIRmc;

			public bool GKQgCbInXfHguCNuGOBhxZeXKgs;

			private InputCategory nVvNhczQEpjgmTyIQYPEzumrnoQh;

			private IEnumerator<int> uzwwOIAUVHhKBnhUTdPTIseroTci;

			private int WbtuetpbwONJktlUhbbMPEWTzofW;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return FnvkVfLdUErcRqCfkBlANcItTPBo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return FnvkVfLdUErcRqCfkBlANcItTPBo;
				}
			}

			[DebuggerHidden]
			public itIEIrnpYqDNiVbhPuRAsTHDvhoT(int P_0)
			{
				FamookpIDTGXsFcMjvgmHSyabmRD = P_0;
				icpjLRJjzEZhKrRopuIlHbavcFRK = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int famookpIDTGXsFcMjvgmHSyabmRD = FamookpIDTGXsFcMjvgmHSyabmRD;
				if (famookpIDTGXsFcMjvgmHSyabmRD == -3 || famookpIDTGXsFcMjvgmHSyabmRD == 1)
				{
					try
					{
					}
					finally
					{
						WxdYEXyoJFgDEcgNcuYqUZEYvYZj();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int famookpIDTGXsFcMjvgmHSyabmRD = FamookpIDTGXsFcMjvgmHSyabmRD;
					UserData zaRlCLPuohpiGjlPHDzJEDEdPuqFA = ZaRlCLPuohpiGjlPHDzJEDEdPuqFA;
					InputAction inputAction;
					switch (famookpIDTGXsFcMjvgmHSyabmRD)
					{
					default:
						return false;
					case 0:
						FamookpIDTGXsFcMjvgmHSyabmRD = -1;
						if (zaRlCLPuohpiGjlPHDzJEDEdPuqFA.UVcfFVlFayKsvGbNtLWpsgDDKbny == null || zaRlCLPuohpiGjlPHDzJEDEdPuqFA.actionCategories == null)
						{
							return false;
						}
						nVvNhczQEpjgmTyIQYPEzumrnoQh = zaRlCLPuohpiGjlPHDzJEDEdPuqFA.GetActionCategory(lredTKdpBRiHhLBifkPpWyXHKOhgA);
						if (nVvNhczQEpjgmTyIQYPEzumrnoQh == null || !nVvNhczQEpjgmTyIQYPEzumrnoQh.userAssignable)
						{
							return false;
						}
						if (FOeBirEfLOlCwIWUFGuMHKWjhIRmc)
						{
							uzwwOIAUVHhKBnhUTdPTIseroTci = zaRlCLPuohpiGjlPHDzJEDEdPuqFA.SortedActionIdsInCategory(nVvNhczQEpjgmTyIQYPEzumrnoQh.id).GetEnumerator();
							FamookpIDTGXsFcMjvgmHSyabmRD = -3;
							goto IL_00e4;
						}
						WbtuetpbwONJktlUhbbMPEWTzofW = 0;
						goto IL_0165;
					case 1:
						FamookpIDTGXsFcMjvgmHSyabmRD = -3;
						goto IL_00e4;
					case 2:
						{
							FamookpIDTGXsFcMjvgmHSyabmRD = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (uzwwOIAUVHhKBnhUTdPTIseroTci.MoveNext())
						{
							int current = uzwwOIAUVHhKBnhUTdPTIseroTci.Current;
							InputAction actionById = zaRlCLPuohpiGjlPHDzJEDEdPuqFA.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								FnvkVfLdUErcRqCfkBlANcItTPBo = actionById;
								FamookpIDTGXsFcMjvgmHSyabmRD = 1;
								return true;
							}
						}
						WxdYEXyoJFgDEcgNcuYqUZEYvYZj();
						uzwwOIAUVHhKBnhUTdPTIseroTci = null;
						break;
						IL_0153:
						WbtuetpbwONJktlUhbbMPEWTzofW++;
						goto IL_0165;
						IL_0165:
						if (WbtuetpbwONJktlUhbbMPEWTzofW >= zaRlCLPuohpiGjlPHDzJEDEdPuqFA.UVcfFVlFayKsvGbNtLWpsgDDKbny.Count)
						{
							break;
						}
						inputAction = zaRlCLPuohpiGjlPHDzJEDEdPuqFA.UVcfFVlFayKsvGbNtLWpsgDDKbny[WbtuetpbwONJktlUhbbMPEWTzofW];
						if (inputAction.categoryId == nVvNhczQEpjgmTyIQYPEzumrnoQh.id && inputAction.userAssignable)
						{
							FnvkVfLdUErcRqCfkBlANcItTPBo = inputAction;
							FamookpIDTGXsFcMjvgmHSyabmRD = 2;
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

			private void WxdYEXyoJFgDEcgNcuYqUZEYvYZj()
			{
				FamookpIDTGXsFcMjvgmHSyabmRD = -1;
				if (uzwwOIAUVHhKBnhUTdPTIseroTci != null)
				{
					uzwwOIAUVHhKBnhUTdPTIseroTci.Dispose();
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
				itIEIrnpYqDNiVbhPuRAsTHDvhoT itIEIrnpYqDNiVbhPuRAsTHDvhoT2;
				if (FamookpIDTGXsFcMjvgmHSyabmRD == -2 && icpjLRJjzEZhKrRopuIlHbavcFRK == Environment.CurrentManagedThreadId)
				{
					FamookpIDTGXsFcMjvgmHSyabmRD = 0;
					itIEIrnpYqDNiVbhPuRAsTHDvhoT2 = this;
				}
				else
				{
					itIEIrnpYqDNiVbhPuRAsTHDvhoT2 = new itIEIrnpYqDNiVbhPuRAsTHDvhoT(0);
					itIEIrnpYqDNiVbhPuRAsTHDvhoT2.ZaRlCLPuohpiGjlPHDzJEDEdPuqFA = ZaRlCLPuohpiGjlPHDzJEDEdPuqFA;
				}
				itIEIrnpYqDNiVbhPuRAsTHDvhoT2.lredTKdpBRiHhLBifkPpWyXHKOhgA = gUzYKHrYVzgbHtLMHWRfhNSpJpWt;
				itIEIrnpYqDNiVbhPuRAsTHDvhoT2.FOeBirEfLOlCwIWUFGuMHKWjhIRmc = GKQgCbInXfHguCNuGOBhxZeXKgs;
				return itIEIrnpYqDNiVbhPuRAsTHDvhoT2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class YMvXFhwtxbNtcwIGMjWkoVUyySUT : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int LMklgflrbQGWOOUNLNqpRonEXAsD;

			private InputMapCategory JXlGMkKwGLiNGqWXmzaBbTIesuzaA;

			private int uGLpLALzfxcPEFPzStCYBgHVBSQG;

			private string QoQegMGekeJfUOMPDgGnESBHJLDaA;

			public string EpxlmvVPkMcLIbNuCvOPSPQmVJHkA;

			public UserData QtseZeBsmOEAsyAzTfqBWOKOQYdeA;

			private int EQkAIonTsKGIzeCDZatsHkPebqcBb;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return JXlGMkKwGLiNGqWXmzaBbTIesuzaA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JXlGMkKwGLiNGqWXmzaBbTIesuzaA;
				}
			}

			[DebuggerHidden]
			public YMvXFhwtxbNtcwIGMjWkoVUyySUT(int P_0)
			{
				LMklgflrbQGWOOUNLNqpRonEXAsD = P_0;
				uGLpLALzfxcPEFPzStCYBgHVBSQG = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int lMklgflrbQGWOOUNLNqpRonEXAsD = LMklgflrbQGWOOUNLNqpRonEXAsD;
				UserData qtseZeBsmOEAsyAzTfqBWOKOQYdeA = QtseZeBsmOEAsyAzTfqBWOKOQYdeA;
				if (lMklgflrbQGWOOUNLNqpRonEXAsD != 0)
				{
					if (lMklgflrbQGWOOUNLNqpRonEXAsD != 1)
					{
						return false;
					}
					LMklgflrbQGWOOUNLNqpRonEXAsD = -1;
					goto IL_00b3;
				}
				LMklgflrbQGWOOUNLNqpRonEXAsD = -1;
				if (QoQegMGekeJfUOMPDgGnESBHJLDaA == null || QoQegMGekeJfUOMPDgGnESBHJLDaA == string.Empty)
				{
					return false;
				}
				if (qtseZeBsmOEAsyAzTfqBWOKOQYdeA.mapCategories == null)
				{
					return false;
				}
				EQkAIonTsKGIzeCDZatsHkPebqcBb = 0;
				goto IL_00c3;
				IL_00c3:
				if (EQkAIonTsKGIzeCDZatsHkPebqcBb < qtseZeBsmOEAsyAzTfqBWOKOQYdeA.mapCategories.Count)
				{
					if (qtseZeBsmOEAsyAzTfqBWOKOQYdeA.mapCategories[EQkAIonTsKGIzeCDZatsHkPebqcBb].userAssignable && qtseZeBsmOEAsyAzTfqBWOKOQYdeA.mapCategories[EQkAIonTsKGIzeCDZatsHkPebqcBb].tag.Equals(QoQegMGekeJfUOMPDgGnESBHJLDaA, StringComparison.OrdinalIgnoreCase))
					{
						JXlGMkKwGLiNGqWXmzaBbTIesuzaA = qtseZeBsmOEAsyAzTfqBWOKOQYdeA.mapCategories[EQkAIonTsKGIzeCDZatsHkPebqcBb];
						LMklgflrbQGWOOUNLNqpRonEXAsD = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				EQkAIonTsKGIzeCDZatsHkPebqcBb++;
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
				YMvXFhwtxbNtcwIGMjWkoVUyySUT yMvXFhwtxbNtcwIGMjWkoVUyySUT;
				if (LMklgflrbQGWOOUNLNqpRonEXAsD == -2 && uGLpLALzfxcPEFPzStCYBgHVBSQG == Environment.CurrentManagedThreadId)
				{
					LMklgflrbQGWOOUNLNqpRonEXAsD = 0;
					yMvXFhwtxbNtcwIGMjWkoVUyySUT = this;
				}
				else
				{
					yMvXFhwtxbNtcwIGMjWkoVUyySUT = new YMvXFhwtxbNtcwIGMjWkoVUyySUT(0);
					yMvXFhwtxbNtcwIGMjWkoVUyySUT.QtseZeBsmOEAsyAzTfqBWOKOQYdeA = QtseZeBsmOEAsyAzTfqBWOKOQYdeA;
				}
				yMvXFhwtxbNtcwIGMjWkoVUyySUT.QoQegMGekeJfUOMPDgGnESBHJLDaA = EpxlmvVPkMcLIbNuCvOPSPQmVJHkA;
				return yMvXFhwtxbNtcwIGMjWkoVUyySUT;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class rRGGPHxNHDCiJFBdidxMXKZPxQHfA : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int YgahEpBqitHKssIqjpyKlOiUJDWd;

			private InputCategory IwOpNgVIgToRAwcmeaqeanAAfyhsA;

			private int YJflfpDQQzDAiRInrThHSldJlPLB;

			public UserData tHyMuZnSwWjVVfqUQEpFtfSBvHem;

			private int mpgkbwiWhlKPYoVdVlTjrNTzLfvt;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return IwOpNgVIgToRAwcmeaqeanAAfyhsA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return IwOpNgVIgToRAwcmeaqeanAAfyhsA;
				}
			}

			[DebuggerHidden]
			public rRGGPHxNHDCiJFBdidxMXKZPxQHfA(int P_0)
			{
				YgahEpBqitHKssIqjpyKlOiUJDWd = P_0;
				YJflfpDQQzDAiRInrThHSldJlPLB = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int ygahEpBqitHKssIqjpyKlOiUJDWd = YgahEpBqitHKssIqjpyKlOiUJDWd;
				UserData userData = tHyMuZnSwWjVVfqUQEpFtfSBvHem;
				if (ygahEpBqitHKssIqjpyKlOiUJDWd != 0)
				{
					if (ygahEpBqitHKssIqjpyKlOiUJDWd != 1)
					{
						return false;
					}
					YgahEpBqitHKssIqjpyKlOiUJDWd = -1;
					goto IL_0070;
				}
				YgahEpBqitHKssIqjpyKlOiUJDWd = -1;
				if (userData.actionCategories == null)
				{
					return false;
				}
				mpgkbwiWhlKPYoVdVlTjrNTzLfvt = 0;
				goto IL_0080;
				IL_0080:
				if (mpgkbwiWhlKPYoVdVlTjrNTzLfvt < userData.actionCategories.Count)
				{
					if (userData.actionCategories[mpgkbwiWhlKPYoVdVlTjrNTzLfvt].userAssignable)
					{
						IwOpNgVIgToRAwcmeaqeanAAfyhsA = userData.actionCategories[mpgkbwiWhlKPYoVdVlTjrNTzLfvt];
						YgahEpBqitHKssIqjpyKlOiUJDWd = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				mpgkbwiWhlKPYoVdVlTjrNTzLfvt++;
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
				rRGGPHxNHDCiJFBdidxMXKZPxQHfA rRGGPHxNHDCiJFBdidxMXKZPxQHfA2;
				if (YgahEpBqitHKssIqjpyKlOiUJDWd == -2 && YJflfpDQQzDAiRInrThHSldJlPLB == Environment.CurrentManagedThreadId)
				{
					YgahEpBqitHKssIqjpyKlOiUJDWd = 0;
					rRGGPHxNHDCiJFBdidxMXKZPxQHfA2 = this;
				}
				else
				{
					rRGGPHxNHDCiJFBdidxMXKZPxQHfA2 = new rRGGPHxNHDCiJFBdidxMXKZPxQHfA(0);
					rRGGPHxNHDCiJFBdidxMXKZPxQHfA2.tHyMuZnSwWjVVfqUQEpFtfSBvHem = tHyMuZnSwWjVVfqUQEpFtfSBvHem;
				}
				return rRGGPHxNHDCiJFBdidxMXKZPxQHfA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class YmUdvADzwQxMvcrCyYWGNhsHWljK : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int WFsmgOYeiWBFiuhXweiIFiDXOqBEb;

			private InputAction vwQEIzRrhZANayzREaFpHzwBSQwW;

			private int RdAwjYpndaBjjOdtHodsSvgUfTAJ;

			public UserData HpCqFokjCGnDqUYKODfQafcXqLic;

			private int FzUxZnNVITJhtmdRjgovPqlEVRUv;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return vwQEIzRrhZANayzREaFpHzwBSQwW;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vwQEIzRrhZANayzREaFpHzwBSQwW;
				}
			}

			[DebuggerHidden]
			public YmUdvADzwQxMvcrCyYWGNhsHWljK(int P_0)
			{
				WFsmgOYeiWBFiuhXweiIFiDXOqBEb = P_0;
				RdAwjYpndaBjjOdtHodsSvgUfTAJ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int wFsmgOYeiWBFiuhXweiIFiDXOqBEb = WFsmgOYeiWBFiuhXweiIFiDXOqBEb;
				UserData hpCqFokjCGnDqUYKODfQafcXqLic = HpCqFokjCGnDqUYKODfQafcXqLic;
				if (wFsmgOYeiWBFiuhXweiIFiDXOqBEb != 0)
				{
					if (wFsmgOYeiWBFiuhXweiIFiDXOqBEb != 1)
					{
						return false;
					}
					WFsmgOYeiWBFiuhXweiIFiDXOqBEb = -1;
					goto IL_007a;
				}
				WFsmgOYeiWBFiuhXweiIFiDXOqBEb = -1;
				if (hpCqFokjCGnDqUYKODfQafcXqLic.UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
				{
					return false;
				}
				FzUxZnNVITJhtmdRjgovPqlEVRUv = 0;
				goto IL_008c;
				IL_008c:
				if (FzUxZnNVITJhtmdRjgovPqlEVRUv < hpCqFokjCGnDqUYKODfQafcXqLic.UVcfFVlFayKsvGbNtLWpsgDDKbny.Count)
				{
					InputAction inputAction = hpCqFokjCGnDqUYKODfQafcXqLic.UVcfFVlFayKsvGbNtLWpsgDDKbny[FzUxZnNVITJhtmdRjgovPqlEVRUv];
					InputCategory actionCategoryById = hpCqFokjCGnDqUYKODfQafcXqLic.GetActionCategoryById(inputAction.categoryId);
					if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
					{
						vwQEIzRrhZANayzREaFpHzwBSQwW = inputAction;
						WFsmgOYeiWBFiuhXweiIFiDXOqBEb = 1;
						return true;
					}
					goto IL_007a;
				}
				return false;
				IL_007a:
				FzUxZnNVITJhtmdRjgovPqlEVRUv++;
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
				YmUdvADzwQxMvcrCyYWGNhsHWljK ymUdvADzwQxMvcrCyYWGNhsHWljK;
				if (WFsmgOYeiWBFiuhXweiIFiDXOqBEb == -2 && RdAwjYpndaBjjOdtHodsSvgUfTAJ == Environment.CurrentManagedThreadId)
				{
					WFsmgOYeiWBFiuhXweiIFiDXOqBEb = 0;
					ymUdvADzwQxMvcrCyYWGNhsHWljK = this;
				}
				else
				{
					ymUdvADzwQxMvcrCyYWGNhsHWljK = new YmUdvADzwQxMvcrCyYWGNhsHWljK(0);
					ymUdvADzwQxMvcrCyYWGNhsHWljK.HpCqFokjCGnDqUYKODfQafcXqLic = HpCqFokjCGnDqUYKODfQafcXqLic;
				}
				return ymUdvADzwQxMvcrCyYWGNhsHWljK;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class OWDRfijMquBJoVFEEgMqHjaaezegb : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int jguHCVSLJgfysqlUksEQBKlEONVW;

			private InputMapCategory YJgBbcoQOIOYQSOuQHugcPLPTxBK;

			private int SwYxSdPuMCSixlyXBNHsMeShPufn;

			public UserData TdopBAFwJyPyOcDkDZSvjwDISNzu;

			private int aKIBqrqhEZXvkkBZcXuKvGkIqJTV;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return YJgBbcoQOIOYQSOuQHugcPLPTxBK;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return YJgBbcoQOIOYQSOuQHugcPLPTxBK;
				}
			}

			[DebuggerHidden]
			public OWDRfijMquBJoVFEEgMqHjaaezegb(int P_0)
			{
				jguHCVSLJgfysqlUksEQBKlEONVW = P_0;
				SwYxSdPuMCSixlyXBNHsMeShPufn = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = jguHCVSLJgfysqlUksEQBKlEONVW;
				UserData tdopBAFwJyPyOcDkDZSvjwDISNzu = TdopBAFwJyPyOcDkDZSvjwDISNzu;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					jguHCVSLJgfysqlUksEQBKlEONVW = -1;
					goto IL_0070;
				}
				jguHCVSLJgfysqlUksEQBKlEONVW = -1;
				if (tdopBAFwJyPyOcDkDZSvjwDISNzu.mapCategories == null)
				{
					return false;
				}
				aKIBqrqhEZXvkkBZcXuKvGkIqJTV = 0;
				goto IL_0080;
				IL_0080:
				if (aKIBqrqhEZXvkkBZcXuKvGkIqJTV < tdopBAFwJyPyOcDkDZSvjwDISNzu.mapCategories.Count)
				{
					if (tdopBAFwJyPyOcDkDZSvjwDISNzu.mapCategories[aKIBqrqhEZXvkkBZcXuKvGkIqJTV].userAssignable)
					{
						YJgBbcoQOIOYQSOuQHugcPLPTxBK = tdopBAFwJyPyOcDkDZSvjwDISNzu.mapCategories[aKIBqrqhEZXvkkBZcXuKvGkIqJTV];
						jguHCVSLJgfysqlUksEQBKlEONVW = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				aKIBqrqhEZXvkkBZcXuKvGkIqJTV++;
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
				OWDRfijMquBJoVFEEgMqHjaaezegb oWDRfijMquBJoVFEEgMqHjaaezegb;
				if (jguHCVSLJgfysqlUksEQBKlEONVW == -2 && SwYxSdPuMCSixlyXBNHsMeShPufn == Environment.CurrentManagedThreadId)
				{
					jguHCVSLJgfysqlUksEQBKlEONVW = 0;
					oWDRfijMquBJoVFEEgMqHjaaezegb = this;
				}
				else
				{
					oWDRfijMquBJoVFEEgMqHjaaezegb = new OWDRfijMquBJoVFEEgMqHjaaezegb(0);
					oWDRfijMquBJoVFEEgMqHjaaezegb.TdopBAFwJyPyOcDkDZSvjwDISNzu = TdopBAFwJyPyOcDkDZSvjwDISNzu;
				}
				return oWDRfijMquBJoVFEEgMqHjaaezegb;
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
		private List<InputAction> WUlhjZaINwnAyGNdZQJVGKYwpnnf;

		[NonSerialized]
		private bool WnFKzRZTXzHtNTYcFeoayTPZqKyI;

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

		internal IList<Player_Editor> veCQUcbOHBPDdzjQJpMsjmKQamdw
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

		internal IList<InputAction> gpnnaXWQhQMhjcqDhjGuCjyLpqDpA
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

		internal IList<InputCategory> cuPsxhDltymVGUamqqSVtzlIUBb
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

		internal IList<InputBehavior> fkWAQBbhvghoYowxyHFaklFJRRKS
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

		internal IList<InputMapCategory> NxuxafxxwliOaTVRCgiRaVrGoyEu
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

		internal IList<InputLayout> TXYIMRrJNjbCUjHirYdQkslVqaww
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

		internal IList<InputLayout> hbEABXzvlZXaiHHwRCIUofldgDw
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

		internal IList<InputLayout> yQxalfFLIGnvlPjMbfbNovXiCXxqA
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

		internal IList<InputLayout> zxcakKiPDnhIfyHPyrXypQZHiIjib
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

		internal IList<ControllerMap_Editor> skXBmmAUHirDepwiYYpxsYoIrqjGA
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

		internal IList<ControllerMap_Editor> EbQQZEEzHzUloSKmcGFkMIBvqHbW
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

		internal IList<ControllerMap_Editor> hPiVLGTWnEwxbtfWkzjVzPPieEpr
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

		internal IList<ControllerMap_Editor> vYkwnpWMZdOaIKeFqPxEYMedwAqf
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

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> HyCyNMODWfotSUnIrADsChRzWccP
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

		internal IList<ControllerMapEnabler_RuleSet_Editor> glRlIhTdAJKEpCDFzWpzWomXAirw
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

		internal IEnumerable<InputMapCategory> FeraMggrsVkahvZDNdZeGWnBIBJHA
		{
			[IteratorStateMachine(typeof(OWDRfijMquBJoVFEEgMqHjaaezegb))]
			get
			{
				return new OWDRfijMquBJoVFEEgMqHjaaezegb(-2)
				{
					TdopBAFwJyPyOcDkDZSvjwDISNzu = this
				};
			}
		}

		internal IEnumerable<InputCategory> vNSFWYdxmTpFGBDoFMLlOKRnoCmX
		{
			[IteratorStateMachine(typeof(rRGGPHxNHDCiJFBdidxMXKZPxQHfA))]
			get
			{
				return new rRGGPHxNHDCiJFBdidxMXKZPxQHfA(-2)
				{
					tHyMuZnSwWjVVfqUQEpFtfSBvHem = this
				};
			}
		}

		internal IEnumerable<InputAction> jvdraIlmaqDvujVnfhCSRSvqoMFU
		{
			[IteratorStateMachine(typeof(YmUdvADzwQxMvcrCyYWGNhsHWljK))]
			get
			{
				return new YmUdvADzwQxMvcrCyYWGNhsHWljK(-2)
				{
					HpCqFokjCGnDqUYKODfQafcXqLic = this
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

		private List<InputAction> UVcfFVlFayKsvGbNtLWpsgDDKbny
		{
			get
			{
				if (!ReInput.isReady)
				{
					return actions;
				}
				return WUlhjZaINwnAyGNdZQJVGKYwpnnf;
			}
		}

		[IteratorStateMachine(typeof(XeAamNfbIOplacsdUFqTmDIRVrSI))]
		internal IEnumerable<InputMapCategory> XCkSbMuYCtSSOiCYYFYDbDVabBNoA(string P_0)
		{
			return new XeAamNfbIOplacsdUFqTmDIRVrSI(-2)
			{
				hWnEuWTxIvAmxbvVSroxYYTlEAKC = this,
				dUAMcVzDRaOwOYZpTNTtllXPlRhK = P_0
			};
		}

		[IteratorStateMachine(typeof(YMvXFhwtxbNtcwIGMjWkoVUyySUT))]
		internal IEnumerable<InputMapCategory> GmeFAauFxCLVdbDIeINuSbwUQbDg(string P_0)
		{
			return new YMvXFhwtxbNtcwIGMjWkoVUyySUT(-2)
			{
				QtseZeBsmOEAsyAzTfqBWOKOQYdeA = this,
				EpxlmvVPkMcLIbNuCvOPSPQmVJHkA = P_0
			};
		}

		[IteratorStateMachine(typeof(CnsNiBoCrBrmivjNjbeKHGdLGdIaA))]
		internal IEnumerable<InputCategory> uQEslXDgmiqQKkYQTMDKmNJLxFfn(string P_0)
		{
			return new CnsNiBoCrBrmivjNjbeKHGdLGdIaA(-2)
			{
				toIpzEOUTHFAaOxvsGgxrxcxGabk = this,
				kvjmZtpGqgWPdNPXuFVKftxsWFVo = P_0
			};
		}

		[IteratorStateMachine(typeof(AnWjyhJSACYxLRmTjkRpFhCotItb))]
		internal IEnumerable<InputCategory> GNvQkJfLONnufFSfpgIqAHsAHGkMA(string P_0)
		{
			return new AnWjyhJSACYxLRmTjkRpFhCotItb(-2)
			{
				tEUJBFnuWQdUtbQMhcgBVAsMlgOh = this,
				toXBlyAzCmAGNjNdGinylIJArmdkC = P_0
			};
		}

		[IteratorStateMachine(typeof(DQrbbrjDNUPIhwJpXAwIUYiHNDSo))]
		internal IEnumerable<InputAction> CmbuedyqBQaVZgSrEeojeltbWSMr(int P_0, bool P_1)
		{
			return new DQrbbrjDNUPIhwJpXAwIUYiHNDSo(-2)
			{
				rDSAZlCrpOmszQYRywFnbBgjPitHb = this,
				GNIGLWjchkDxqtFPYwCPBReMIaTPA = P_0,
				cbpCOufKLlpUVFkGHeclFCklhNMic = P_1
			};
		}

		[IteratorStateMachine(typeof(gtDenqclDQNkLIvrUootERGjSaAs))]
		internal IEnumerable<InputAction> sgzcgrMTvmiASaQIZcXCAbyzZDiT(string P_0, bool P_1)
		{
			return new gtDenqclDQNkLIvrUootERGjSaAs(-2)
			{
				gKzpMQHdECBmGFNVNSEbgSnLQwzSA = this,
				NNpFORmHPPOvEQDfCUnmKUVJgeKI = P_0,
				nNorJOvqBbLgyaXYUWefhLQbTwEj = P_1
			};
		}

		[IteratorStateMachine(typeof(tXYYziHDeORVTsBtNfRFdBdeMnRbb))]
		internal IEnumerable<InputAction> XPDNnJDpnTzsECIQqBzHDIADsygMA(string P_0)
		{
			return new tXYYziHDeORVTsBtNfRFdBdeMnRbb(-2)
			{
				LliDBSgoZHlVRbRkrxReDIUHoyoN = this,
				QDmcTRtURIPPBcaEZXGPTZSDkWqb = P_0
			};
		}

		[IteratorStateMachine(typeof(pdIwqUkdVsXSwKwAYnbUAKxebkTjA))]
		internal IEnumerable<InputAction> fVVpcAFGNXnIvCbjkGfiDNTbcgMib(int P_0, bool P_1)
		{
			return new pdIwqUkdVsXSwKwAYnbUAKxebkTjA(-2)
			{
				YGrEMSbsrtfBnhNslRMYsnChZtcOA = this,
				zThcYJAvUGOgEONwYMaxqrBGOkNu = P_0,
				RGCBqiPDRFcrjALuaoaCTPjpMePd = P_1
			};
		}

		[IteratorStateMachine(typeof(itIEIrnpYqDNiVbhPuRAsTHDvhoT))]
		internal IEnumerable<InputAction> ITVAvgbScviYgNcKkCbuYEZFCnPZ(string P_0, bool P_1)
		{
			return new itIEIrnpYqDNiVbhPuRAsTHDvhoT(-2)
			{
				ZaRlCLPuohpiGjlPHDzJEDEdPuqFA = this,
				gUzYKHrYVzgbHtLMHWRfhNSpJpWt = P_0,
				GKQgCbInXfHguCNuGOBhxZeXKgs = P_1
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
				Player_Editor player_Editor = MFepWcZECuFwMqJnCpiYBBFCSTRT();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.key = "system_player";
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputActionCategory inputActionCategory = scvmXRXeIAvaDkqxbdbXiUNwMSCSA();
				inputActionCategory.name = "Default";
				inputActionCategory.descriptiveName = inputActionCategory.name;
				actionCategories.Add(inputActionCategory);
				actionCategoryMap.AddCategory(inputActionCategory.id);
				InputBehavior inputBehavior = ZkcTzScMGNTqcRvnvRhTwFrpOGid();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = OpcbsTKFTdNMxcapYIcUVwslVjbz();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = qpLUFBgeyNDfWilXwfzmHAPWJnObb();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = lfNUiHqxsYeaLbrGdAesaKXBVllb();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = LkVZILjHjIlWomMPGTFGsaeITEgL();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = TUADRuADKPaEyEvOIAcZeyjuYwDoA();
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
			for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
			{
				list.Add(UVcfFVlFayKsvGbNtLWpsgDDKbny[i]);
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
				KeyboardMap item = keyboardMaps[i].yGVEOpkUChcKQZjlJJTdMjSvcGRhb(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].oMsBTaytezqwLDsgkgQzYGVzAmeAA(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(MFepWcZECuFwMqJnCpiYBBFCSTRT());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, MFepWcZECuFwMqJnCpiYBBFCSTRT());
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
			InputAction inputAction = vDRdIKeFtMFsfXZhRLLcudfGRKhmA();
			inputAction.categoryId = categoryId;
			UVcfFVlFayKsvGbNtLWpsgDDKbny.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny != null)
			{
				InputAction inputAction = vDRdIKeFtMFsfXZhRLLcudfGRKhmA();
				inputAction.categoryId = categoryId;
				UVcfFVlFayKsvGbNtLWpsgDDKbny.Add(inputAction);
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
					UVcfFVlFayKsvGbNtLWpsgDDKbny.RemoveAt(num);
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
			if (num == UVcfFVlFayKsvGbNtLWpsgDDKbny.Count - 1)
			{
				UVcfFVlFayKsvGbNtLWpsgDDKbny.Add(inputAction);
				actionCategoryMap.AddAction(categoryId, inputAction.id);
				return UVcfFVlFayKsvGbNtLWpsgDDKbny.Count - 1;
			}
			UVcfFVlFayKsvGbNtLWpsgDDKbny.Insert(num + 1, inputAction);
			int num2 = actionCategoryMap.IndexOfAction(categoryId, actionId);
			actionCategoryMap.InsertAction(categoryId, inputAction.id, num2 + 1);
			return num + 1;
		}

		private int WcFuFJRkyuiEUXQMiXcxbRuRSZjD(int P_0, InputAction P_1)
		{
			if (IndexOfActionCategory(P_0) < 0)
			{
				return -1;
			}
			InputAction inputAction = P_1.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			UVcfFVlFayKsvGbNtLWpsgDDKbny.Add(inputAction);
			return UVcfFVlFayKsvGbNtLWpsgDDKbny.Count - 1;
		}

		public string[] GetActionNames()
		{
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return null;
			}
			string[] array = new string[UVcfFVlFayKsvGbNtLWpsgDDKbny.Count];
			for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
			{
				array[i] = UVcfFVlFayKsvGbNtLWpsgDDKbny[i].name;
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
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return 0;
			}
			for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
			{
				results.Add(UVcfFVlFayKsvGbNtLWpsgDDKbny[i].name);
			}
			return results.Count;
		}

		public int[] GetActionIds()
		{
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return null;
			}
			int[] array = new int[UVcfFVlFayKsvGbNtLWpsgDDKbny.Count];
			for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
			{
				array[i] = UVcfFVlFayKsvGbNtLWpsgDDKbny[i].id;
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
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return 0;
			}
			for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
			{
				results.Add(UVcfFVlFayKsvGbNtLWpsgDDKbny[i].id);
			}
			return results.Count;
		}

		public string GetActionNameById(int id)
		{
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
			{
				if (UVcfFVlFayKsvGbNtLWpsgDDKbny[i].id == id)
				{
					return UVcfFVlFayKsvGbNtLWpsgDDKbny[i].name;
				}
			}
			return string.Empty;
		}

		public InputAction GetAction(int index)
		{
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null || index < 0 || index >= UVcfFVlFayKsvGbNtLWpsgDDKbny.Count)
			{
				return null;
			}
			return UVcfFVlFayKsvGbNtLWpsgDDKbny[index];
		}

		public InputAction GetAction(string name)
		{
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return null;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return null;
			}
			return UVcfFVlFayKsvGbNtLWpsgDDKbny[num];
		}

		public InputAction GetActionById(int id)
		{
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return null;
			}
			for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
			{
				if (UVcfFVlFayKsvGbNtLWpsgDDKbny[i].id == id)
				{
					return UVcfFVlFayKsvGbNtLWpsgDDKbny[i];
				}
			}
			return null;
		}

		public int GetActionId(string name)
		{
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return -1;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return -1;
			}
			return UVcfFVlFayKsvGbNtLWpsgDDKbny[num].id;
		}

		public string[] GetSortedActionNamesInCategory(int id)
		{
			if (actionCategories == null || UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
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

		[IteratorStateMachine(typeof(qSgDyNvWjHOcuuiwdowdYWAJSFU))]
		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			return new qSgDyNvWjHOcuuiwdowdYWAJSFU(-2)
			{
				mNfgiADkgUlMqdalEndkfCmoOapt = this,
				MmzcmFBEfwJJqbdYeCnPVNbanaltA = id
			};
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (actionCategories == null || UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
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

		[IteratorStateMachine(typeof(inTCBQFOXjsrHEbHdVFsoLiogduBb))]
		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			return new inTCBQFOXjsrHEbHdVFsoLiogduBb(-2)
			{
				ZWMErnhQMcUpUPujnPXeegvCXQXyB = this,
				LOIPPgNrYIyuKVbyDbinaCKCKwAG = id
			};
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			if (actionCategories == null || UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
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

		[IteratorStateMachine(typeof(csJjbwTTCMHhVLaSWqyFlXVXtzok))]
		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			return new csJjbwTTCMHhVLaSWqyFlXVXtzok(-2)
			{
				LoaGjNdIJNpylFHVCfZsKOiFhIgV = this,
				CPdHPBawDPmdZROorbCdNIefLgaD = id
			};
		}

		public bool ContainsAction(int id)
		{
			return IndexOfAction(id) >= 0;
		}

		public int IndexOfAction(int id)
		{
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return -1;
			}
			for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
			{
				if (UVcfFVlFayKsvGbNtLWpsgDDKbny[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfAction(string name)
		{
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
			{
				if (UVcfFVlFayKsvGbNtLWpsgDDKbny[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddActionCategory()
		{
			InputActionCategory inputActionCategory = scvmXRXeIAvaDkqxbdbXiUNwMSCSA();
			actionCategories.Add(inputActionCategory);
			actionCategoryMap.AddCategory(inputActionCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputActionCategory inputActionCategory = scvmXRXeIAvaDkqxbdbXiUNwMSCSA();
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
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny != null)
			{
				for (int num = UVcfFVlFayKsvGbNtLWpsgDDKbny.Count - 1; num >= 0; num--)
				{
					if (UVcfFVlFayKsvGbNtLWpsgDDKbny[num].categoryId == id)
					{
						UVcfFVlFayKsvGbNtLWpsgDDKbny.RemoveAt(num);
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
			if (!duplicateActions || UVcfFVlFayKsvGbNtLWpsgDDKbny == null)
			{
				return;
			}
			int id = inputActionCategory.id;
			int id2 = actionCategories[index].id;
			List<int> list = new List<int>();
			for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
			{
				if (UVcfFVlFayKsvGbNtLWpsgDDKbny[i].categoryId == id2)
				{
					list.Add(i);
				}
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>(list.Count);
			for (int j = 0; j < list.Count; j++)
			{
				InputAction inputAction = UVcfFVlFayKsvGbNtLWpsgDDKbny[list[j]];
				int num = WcFuFJRkyuiEUXQMiXcxbRuRSZjD(id2, inputAction);
				if (num >= 0)
				{
					InputAction inputAction2 = UVcfFVlFayKsvGbNtLWpsgDDKbny[num];
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
			if (num >= 0 && UVcfFVlFayKsvGbNtLWpsgDDKbny[num].categoryId != newCategoryId)
			{
				actionCategoryMap.ChangeCategory(actionId, newCategoryId);
				UVcfFVlFayKsvGbNtLWpsgDDKbny[num].categoryId = newCategoryId;
			}
		}

		public int GetActionCategoryCount(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny != null)
			{
				for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
				{
					if (UVcfFVlFayKsvGbNtLWpsgDDKbny[i].categoryId == id)
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
			inputBehaviors.Add(ZkcTzScMGNTqcRvnvRhTwFrpOGid());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, ZkcTzScMGNTqcRvnvRhTwFrpOGid());
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = inputBehaviors[index].id;
			if (UVcfFVlFayKsvGbNtLWpsgDDKbny != null)
			{
				for (int i = 0; i < UVcfFVlFayKsvGbNtLWpsgDDKbny.Count; i++)
				{
					if (UVcfFVlFayKsvGbNtLWpsgDDKbny[i].behaviorId == id)
					{
						UVcfFVlFayKsvGbNtLWpsgDDKbny[i].behaviorId = 0;
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
			mapCategories.Add(OpcbsTKFTdNMxcapYIcUVwslVjbz());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, OpcbsTKFTdNMxcapYIcUVwslVjbz());
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
				Action<List<Player_Editor.Mapping>, int> action = lnusoProFmJEOfcsnLZgCySOPjwi._003C_003E9.juChYCYLANWVrJoGIknyviRPFbNI;
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
			joystickLayouts.Add(qpLUFBgeyNDfWilXwfzmHAPWJnObb());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, qpLUFBgeyNDfWilXwfzmHAPWJnObb());
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
				Action<List<Player_Editor.Mapping>, int> action = lnusoProFmJEOfcsnLZgCySOPjwi._003C_003E9.VjbawLXZBJwspMUKhMkccGRylyBi;
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
			keyboardLayouts.Add(lfNUiHqxsYeaLbrGdAesaKXBVllb());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, lfNUiHqxsYeaLbrGdAesaKXBVllb());
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
				Action<List<Player_Editor.Mapping>, int> action = lnusoProFmJEOfcsnLZgCySOPjwi._003C_003E9.DVqfYvQrNCVrtJmjpIOQBYIXDmst;
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
			mouseLayouts.Add(LkVZILjHjIlWomMPGTFGsaeITEgL());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, LkVZILjHjIlWomMPGTFGsaeITEgL());
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
				Action<List<Player_Editor.Mapping>, int> action = lnusoProFmJEOfcsnLZgCySOPjwi._003C_003E9.kuGGMORWcFdDDYBqMQZGpvCiVBrV;
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
			customControllerLayouts.Add(TUADRuADKPaEyEvOIAcZeyjuYwDoA());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, TUADRuADKPaEyEvOIAcZeyjuYwDoA());
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
				Action<List<Player_Editor.Mapping>, int> action = lnusoProFmJEOfcsnLZgCySOPjwi._003C_003E9.WOKaqwLmZSragipBuHQWvhNbNSQB;
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

		internal ControllerMap OeYxQTPxhjuQLWoMvQabxOxprQcK(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Joystick => HOUfLSHZDFkgOKHPGTiFhpwlDNfDA((Joystick)P_0, P_1, P_2), 
				ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
				ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
				ControllerType.Custom => yfDgYQQnkvFLLsPwIrQTpTtJiskJ(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
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

		internal JoystickMap vjxSDCeleuFaRjvAIINMqbVeGDKXA(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return arUDkuGJFJMJyloCPNygnJDqooXp(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap HOUfLSHZDFkgOKHPGTiFhpwlDNfDA(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return arUDkuGJFJMJyloCPNygnJDqooXp(P_0.dinBxJIeEQJSCuYZfbsBDoWdOsLN, P_1, P_2);
		}

		private JoystickMap arUDkuGJFJMJyloCPNygnJDqooXp(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.GZYjWVUdmdkTMPFsQxRGwNaiqIti(guid);
			ControllerMap_Editor controllerMap_Editor = MXfcUWcKaPneYHIGeQWOjGjZrtvic(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.pAwKSWYvZghjUcSpBDhKCkHvuoPC(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.lHmFtPiLDdbjONOBnpJxDLwelMlSb(guid, P_1, P_2);
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
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.CNgRtkFCcAwxwwHdhaQFCMvyjprj(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = MXfcUWcKaPneYHIGeQWOjGjZrtvic(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = ZINwTIOchTRAnTaRQkHNfWERKueS(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.lHmFtPiLDdbjONOBnpJxDLwelMlSb(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty || 1 == 0)
			{
				controllerMap_Editor = MXfcUWcKaPneYHIGeQWOjGjZrtvic(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.pAwKSWYvZghjUcSpBDhKCkHvuoPC(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.lHmFtPiLDdbjONOBnpJxDLwelMlSb(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.nkowMCslevcIhjWMTAPzAtOQOgnV(guid, P_1, P_2);
		}

		private ControllerMap_Editor MXfcUWcKaPneYHIGeQWOjGjZrtvic(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = vUhetzVuPkGDviZXyJDAjrsdadEw(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor vUhetzVuPkGDviZXyJDAjrsdadEw(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				MeheidAWKOrhBDbaMLRTafVjVyOGb(list, joystickLayouts);
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

		private JoystickMap ZINwTIOchTRAnTaRQkHNfWERKueS(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.MqLtsGIqAidWGwHmhBkkRnSMBoLU(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError("Error remapping joystick template " + P_2.Guid.ToString() + " to joystick " + P_0.guid.ToString() + "\nReason: " + text);
				return null;
			}
			return controllerMap_Editor.pAwKSWYvZghjUcSpBDhKCkHvuoPC(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap bxNwSRbLsNuyPbBXbFKWOxlEGdPs(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.GZYjWVUdmdkTMPFsQxRGwNaiqIti(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.GZYjWVUdmdkTMPFsQxRGwNaiqIti(Guid.Empty);
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
				list.Add(allMap.JtzYMpqdJGMyIjXIPHXXckWafklL);
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
			ControllerMap_Editor controllerMap_Editor = LVHcbICFonjhinvzXRfsGTpUiyFQ(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.yGVEOpkUChcKQZjlJJTdMjSvcGRhb(containsActionDelegate);
				keyboardMap.GqDRpEqcRhhskAYHKtNjsfcoqlaE(keyboard.XoTulHbRfmGIRZBImccjILWCKOlE, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.lwHEAnGmrTJeNiscEqBQoTmCfYjad(keyboard.XoTulHbRfmGIRZBImccjILWCKOlE, categoryId, layoutId);
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
			ControllerMap_Editor controllerMap_Editor = LVHcbICFonjhinvzXRfsGTpUiyFQ(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.oMsBTaytezqwLDsgkgQzYGVzAmeAA(containsActionDelegate);
				mouseMap.dlzevNTqnPDIDXVHKqMjiqevVmZD(mouse.XoTulHbRfmGIRZBImccjILWCKOlE, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.nZBfxCqZmvLSXObwPNbLnkamWNBL(mouse.XoTulHbRfmGIRZBImccjILWCKOlE, categoryId, layoutId);
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

		internal CustomControllerMap xzZXlosCixAPUxJWWZonNclMzMcH(Guid P_0, int P_1, int P_2)
		{
			return asiTeQCjBwrPNVJcIcWAadvqTSWf(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap yfDgYQQnkvFLLsPwIrQTpTtJiskJ(int P_0, int P_1, int P_2)
		{
			return asiTeQCjBwrPNVJcIcWAadvqTSWf(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap asiTeQCjBwrPNVJcIcWAadvqTSWf(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = JPqSxdVBGwhzzwxMUUsmnqUanPOK(P_1, id, P_2, false);
			if (controllerMap_Editor != null)
			{
				CustomControllerMap customControllerMap = controllerMap_Editor.gtfaamnMUBERQxBAYHZcBdRokBWAA(ContainsAction, P_0);
				customControllerMap.ladoOQdEOyshNeSJvtTJLetJKTLn(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			CustomControllerMap customControllerMap2 = CustomControllerMap.qJKjKoLhTncWyGTTPhxDqnodLhyP(P_0.typeGuid, id, P_1, P_2);
			customControllerMap2.ladoOQdEOyshNeSJvtTJLetJKTLn(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap2;
		}

		private ControllerMap_Editor JPqSxdVBGwhzzwxMUUsmnqUanPOK(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = zyBjyzsAFeuMaxglOYixiUPbWaCr(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor zyBjyzsAFeuMaxglOYixiUPbWaCr(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				MeheidAWKOrhBDbaMLRTafVjVyOGb(list, customControllerLayouts);
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

		internal ControllerTemplateMap pBaFIWjhVSKbtjFHiVzeydUqMjYsA(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.ltDFklnGCFQXWLFjCkYxdgnPomcQ();
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
			customControllers.Add(QXZDggmnfdaRdjcATOURaPekKBaxA(typeGuid));
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
			customControllers.Insert(index, QXZDggmnfdaRdjcATOURaPekKBaxA(typeGuid));
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
			controllerMapLayoutManagerRuleSets.Add(xyddZxfnbTtDhstKsXWJeMXZsPtb());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, xyddZxfnbTtDhstKsXWJeMXZsPtb());
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
			controllerMapEnablerRuleSets.Add(sFVKkLoHfPirgTyFSRcQmBzJVeNv());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, sFVKkLoHfPirgTyFSRcQmBzJVeNv());
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

		private Player_Editor MFepWcZECuFwMqJnCpiYBBFCSTRT()
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

		private InputAction vDRdIKeFtMFsfXZhRLLcudfGRKhmA()
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

		private InputActionCategory scvmXRXeIAvaDkqxbdbXiUNwMSCSA()
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

		private InputBehavior ZkcTzScMGNTqcRvnvRhTwFrpOGid()
		{
			return new InputBehavior
			{
				id = GetNewInputBehaviorId(),
				name = StringTools.IterateName("Behavior", -1, GetInputBehaviorNames()),
				digitalAxisSimulation = true,
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

		private InputMapCategory OpcbsTKFTdNMxcapYIcUVwslVjbz()
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

		private InputLayout qpLUFBgeyNDfWilXwfzmHAPWJnObb()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewJoystickLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout lfNUiHqxsYeaLbrGdAesaKXBVllb()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewKeyboardLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout LkVZILjHjIlWomMPGTFGsaeITEgL()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewMouseLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout TUADRuADKPaEyEvOIAcZeyjuYwDoA()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewCustomControllerLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private CustomController_Editor QXZDggmnfdaRdjcATOURaPekKBaxA(Guid P_0)
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

		private ControllerMapLayoutManager_RuleSet_Editor xyddZxfnbTtDhstKsXWJeMXZsPtb()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor
			{
				id = GetNewControllerMapLayoutManagerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames())
			};
		}

		private ControllerMapEnabler_RuleSet_Editor sFVKkLoHfPirgTyFSRcQmBzJVeNv()
		{
			return new ControllerMapEnabler_RuleSet_Editor
			{
				id = GetNewControllerMapEnablerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames())
			};
		}

		private ControllerMap_Editor SklAlcvfluXupWRygIRnVGGKauycA(List<ControllerMap_Editor> P_0, int P_1, int P_2)
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

		private ControllerMap_Editor LVHcbICFonjhinvzXRfsGTpUiyFQ(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = SklAlcvfluXupWRygIRnVGGKauycA(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = qbKLHOjOdiYHrAaTqSECtqBDWhMb(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor qbKLHOjOdiYHrAaTqSECtqBDWhMb(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				MeheidAWKOrhBDbaMLRTafVjVyOGb(list, P_1);
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

		private void MeheidAWKOrhBDbaMLRTafVjVyOGb(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			CKzjjCpBGAANnccNRMCAKWvaTJDOA cKzjjCpBGAANnccNRMCAKWvaTJDOA = new CKzjjCpBGAANnccNRMCAKWvaTJDOA();
			cKzjjCpBGAANnccNRMCAKWvaTJDOA.PGcboeFVlDuLmCQYrxYOYXTLXNkm = P_1;
			if (P_0 != null && cKzjjCpBGAANnccNRMCAKWvaTJDOA.PGcboeFVlDuLmCQYrxYOYXTLXNkm != null)
			{
				P_0.Sort(cKzjjCpBGAANnccNRMCAKWvaTJDOA.fsYDEHsfZNGHqIIDpgzpFFbFJVaBB);
			}
		}

		internal void ConlhwNdIwTcpOXGdDxKiLtjTVhb()
		{
			if (WnFKzRZTXzHtNTYcFeoayTPZqKyI)
			{
				return;
			}
			WUlhjZaINwnAyGNdZQJVGKYwpnnf = new List<InputAction>(actions.Count);
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i] == null)
				{
					WUlhjZaINwnAyGNdZQJVGKYwpnnf.Add(null);
				}
				WUlhjZaINwnAyGNdZQJVGKYwpnnf.Add(new InputAction(actions[i]));
			}
			veCQUcbOHBPDdzjQJpMsjmKQamdw = new ReadOnlyCollection<Player_Editor>(players);
			gpnnaXWQhQMhjcqDhjGuCjyLpqDpA = new ReadOnlyCollection<InputAction>(WUlhjZaINwnAyGNdZQJVGKYwpnnf);
			List<InputCategory> list = new List<InputCategory>((actionCategories != null) ? actionCategories.Count : 0);
			for (int j = 0; j < actionCategories.Count; j++)
			{
				list.Add(actionCategories[j]);
			}
			cuPsxhDltymVGUamqqSVtzlIUBb = new ReadOnlyCollection<InputCategory>(list);
			fkWAQBbhvghoYowxyHFaklFJRRKS = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
			NxuxafxxwliOaTVRCgiRaVrGoyEu = new ReadOnlyCollection<InputMapCategory>(mapCategories);
			TXYIMRrJNjbCUjHirYdQkslVqaww = new ReadOnlyCollection<InputLayout>(joystickLayouts);
			hbEABXzvlZXaiHHwRCIUofldgDw = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
			yQxalfFLIGnvlPjMbfbNovXiCXxqA = new ReadOnlyCollection<InputLayout>(mouseLayouts);
			zxcakKiPDnhIfyHPyrXypQZHiIjib = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
			skXBmmAUHirDepwiYYpxsYoIrqjGA = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
			EbQQZEEzHzUloSKmcGFkMIBvqHbW = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
			hPiVLGTWnEwxbtfWkzjVzPPieEpr = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
			vYkwnpWMZdOaIKeFqPxEYMedwAqf = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
			HyCyNMODWfotSUnIrADsChRzWccP = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
			glRlIhTdAJKEpCDFzWpzWomXAirw = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
			if (mapCategories != null)
			{
				for (int k = 0; k < mapCategories.Count; k++)
				{
					if (mapCategories[k] != null)
					{
						mapCategories[k].wOUyVBvxlpTwaBuEMwqATrEBsdyg();
					}
				}
			}
			if (actionCategories != null)
			{
				for (int l = 0; l < actionCategories.Count; l++)
				{
					if (actionCategories[l] != null)
					{
						actionCategories[l].wOUyVBvxlpTwaBuEMwqATrEBsdyg();
					}
				}
			}
			if (joystickLayouts != null)
			{
				for (int m = 0; m < joystickLayouts.Count; m++)
				{
					if (joystickLayouts[m] != null)
					{
						joystickLayouts[m].EjwXzgfRwWFXVgEjFOkecAxCWPrs();
					}
				}
			}
			if (keyboardLayouts != null)
			{
				for (int n = 0; n < keyboardLayouts.Count; n++)
				{
					if (keyboardLayouts[n] != null)
					{
						keyboardLayouts[n].EjwXzgfRwWFXVgEjFOkecAxCWPrs();
					}
				}
			}
			if (mouseLayouts != null)
			{
				for (int num = 0; num < mouseLayouts.Count; num++)
				{
					if (mouseLayouts[num] != null)
					{
						mouseLayouts[num].EjwXzgfRwWFXVgEjFOkecAxCWPrs();
					}
				}
			}
			if (customControllerLayouts != null)
			{
				for (int num2 = 0; num2 < customControllerLayouts.Count; num2++)
				{
					if (customControllerLayouts[num2] != null)
					{
						customControllerLayouts[num2].EjwXzgfRwWFXVgEjFOkecAxCWPrs();
					}
				}
			}
			if (WUlhjZaINwnAyGNdZQJVGKYwpnnf != null)
			{
				for (int num3 = 0; num3 < WUlhjZaINwnAyGNdZQJVGKYwpnnf.Count; num3++)
				{
					if (WUlhjZaINwnAyGNdZQJVGKYwpnnf[num3] != null)
					{
						WUlhjZaINwnAyGNdZQJVGKYwpnnf[num3].aTbcAviiUnBATXVIbBJPfHPZpgpYA();
					}
				}
			}
			containsActionDelegate = ContainsAction;
			WnFKzRZTXzHtNTYcFeoayTPZqKyI = true;
		}

		internal void zOarXVqOHXEMjKLFSBRILkeVfrwR()
		{
			if (!WnFKzRZTXzHtNTYcFeoayTPZqKyI)
			{
				return;
			}
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					if (mapCategories[i] != null)
					{
						mapCategories[i].QMlPfuEhVRBcvZEHmNFAVuJcZqRd();
					}
				}
			}
			if (WUlhjZaINwnAyGNdZQJVGKYwpnnf != null)
			{
				for (int j = 0; j < WUlhjZaINwnAyGNdZQJVGKYwpnnf.Count; j++)
				{
					if (WUlhjZaINwnAyGNdZQJVGKYwpnnf[j] != null)
					{
						WUlhjZaINwnAyGNdZQJVGKYwpnnf[j].PPfyWKkJPsWCIGoaVVtZksQcYwT();
					}
				}
			}
			WnFKzRZTXzHtNTYcFeoayTPZqKyI = false;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return dBWeNSinAPMSsuxrqBtpUDILPeZk.lHWErldndplwnWZRwNZcxKVzcxidA(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return dBWeNSinAPMSsuxrqBtpUDILPeZk.lHWErldndplwnWZRwNZcxKVzcxidA(orig, null, false);
		}
	}
}
