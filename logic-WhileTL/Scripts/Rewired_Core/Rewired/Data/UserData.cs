using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
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
		private static class ubELeQxzedANpjJHRTnfUdKEgAPiA
		{
			[DefaultMember("Item")]
			private class naeysWMfgDkESCeaTYbVssEIgNkC
			{
				public enum XlJHxfRmRgfLLLIPvOHDAqHpQdXd
				{
					origId = 0,
					otherId = 1,
					finalId = 2
				}

				public int bmqimowZKrsaIyFXOaYfpVJPXVby;

				public int tSPdAcroqZjcPqEvARGyLeBpUxNS;

				public int SjEjFwwGNljwQGLGXgFgUQHUHziX;

				public int eLqQPipDQCccAcJjGtKnPvdLRJXEb
				{
					get
					{
						return P_0 switch
						{
							XlJHxfRmRgfLLLIPvOHDAqHpQdXd.origId => bmqimowZKrsaIyFXOaYfpVJPXVby, 
							XlJHxfRmRgfLLLIPvOHDAqHpQdXd.otherId => tSPdAcroqZjcPqEvARGyLeBpUxNS, 
							XlJHxfRmRgfLLLIPvOHDAqHpQdXd.finalId => SjEjFwwGNljwQGLGXgFgUQHUHziX, 
							_ => throw new NotImplementedException(), 
						};
					}
					set
					{
						switch (xlJHxfRmRgfLLLIPvOHDAqHpQdXd)
						{
						case XlJHxfRmRgfLLLIPvOHDAqHpQdXd.origId:
							bmqimowZKrsaIyFXOaYfpVJPXVby = sjEjFwwGNljwQGLGXgFgUQHUHziX;
							break;
						case XlJHxfRmRgfLLLIPvOHDAqHpQdXd.otherId:
							tSPdAcroqZjcPqEvARGyLeBpUxNS = sjEjFwwGNljwQGLGXgFgUQHUHziX;
							break;
						case XlJHxfRmRgfLLLIPvOHDAqHpQdXd.finalId:
							SjEjFwwGNljwQGLGXgFgUQHUHziX = sjEjFwwGNljwQGLGXgFgUQHUHziX;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public naeysWMfgDkESCeaTYbVssEIgNkC(int P_0, int P_1, int P_2)
				{
					bmqimowZKrsaIyFXOaYfpVJPXVby = P_0;
					tSPdAcroqZjcPqEvARGyLeBpUxNS = P_1;
					SjEjFwwGNljwQGLGXgFgUQHUHziX = P_2;
				}

				public virtual string CyzqcuFQjIOjJglpJutjbTLGdstH()
				{
					return string.Concat(string.Concat("" + StringTools.WriteVar("origId", bmqimowZKrsaIyFXOaYfpVJPXVby), StringTools.WriteVar("otherId", tSPdAcroqZjcPqEvARGyLeBpUxNS)), StringTools.WriteVar("finalId", SjEjFwwGNljwQGLGXgFgUQHUHziX));
				}
			}

			private class COlXJLLTpYjFgrOQKhipKOgkSfLb<_0001>
			{
				public _0001 RmOoKpupDqaCsgEWZYwNAvRuupFG;

				public _0001 SFKYdjydKMbVRuEXRAxcVuAsVtbc;

				public naeysWMfgDkESCeaTYbVssEIgNkC.XlJHxfRmRgfLLLIPvOHDAqHpQdXd PWFxOJmPgKpqjyyCqfPOnHWAOauV;

				public IList<_0001> arWJGMXUoMCDxFIjfvIIOBKhLsIM;

				public bool xcvOrTYbmmVmlbUMmsexGVgGGvFJ;

				public COlXJLLTpYjFgrOQKhipKOgkSfLb(_0001 P_0, _0001 P_1, naeysWMfgDkESCeaTYbVssEIgNkC.XlJHxfRmRgfLLLIPvOHDAqHpQdXd P_2, IList<_0001> P_3, bool P_4)
				{
					RmOoKpupDqaCsgEWZYwNAvRuupFG = P_0;
					SFKYdjydKMbVRuEXRAxcVuAsVtbc = P_1;
					PWFxOJmPgKpqjyyCqfPOnHWAOauV = P_2;
					arWJGMXUoMCDxFIjfvIIOBKhLsIM = P_3;
					xcvOrTYbmmVmlbUMmsexGVgGGvFJ = P_4;
				}
			}

			[Serializable]
			private sealed class oOVkNZXHcqSDjwPQagCySEDwaPbEA
			{
				public static readonly oOVkNZXHcqSDjwPQagCySEDwaPbEA _003C_003E9 = new oOVkNZXHcqSDjwPQagCySEDwaPbEA();

				public static Func<InputCategory, int> _003C_003E9__0_0;

				public static Func<InputCategory, string> _003C_003E9__0_1;

				public static Func<InputCategory, IList<InputCategory>, int> _003C_003E9__0_2;

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

				internal int fVBffgzqCuHWCcAuYfGxXGObFruwA(InputCategory P_0)
				{
					return P_0.id;
				}

				internal string ssysioHrvdnBJDimEjFateVzdBUt(InputCategory P_0)
				{
					return P_0.name;
				}

				internal int XbDzAlZSochJICAdDIoVsPlQziaF(InputCategory P_0, IList<InputCategory> P_1)
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

				internal int fkjrkawcwlMwCswfCxDYHFflqMKi(InputBehavior P_0)
				{
					return P_0.id;
				}

				internal string RUJwahIoaIGSsCKrGSlUmogfWGAN(InputBehavior P_0)
				{
					return P_0.name;
				}

				internal int ZJGvTDUiCJWEQQDdyDjlAlnTXoHA(InputBehavior P_0, IList<InputBehavior> P_1)
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

				internal int HuDNVyJwbjcqHlUwdotHncfvsCTM(InputAction P_0)
				{
					return P_0.id;
				}

				internal string gSLqBRcgfMgbcSlqlGqAESuBULntA(InputAction P_0)
				{
					return P_0.name;
				}

				internal int BxGSIdSotcLBhkFcicHueIlBrsMPA(InputAction P_0, IList<InputAction> P_1)
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

				internal int KbQGFJpVZcuFDsumNCYsFHDijuVJ(InputMapCategory P_0)
				{
					return P_0.id;
				}

				internal string uaYMOtMTOMwBvKaYaMSfNrZUeNDeA(InputMapCategory P_0)
				{
					return P_0.name;
				}

				internal int GZQiSjBCcouzXGWhNFlEBbaZvskK(InputMapCategory P_0, IList<InputMapCategory> P_1)
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

				internal int iriOKkTkugcEeIyUPEzwrLLXktum(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string YtrshpwtKQGJSrYFlRnkprdBBRdb(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int qiDymroVfSmwvTylUfvROJNlzgCB(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int FEgKFmLuGkHkNbGwIPkIVOlKTkxw(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string IzgFVPTCwGkDifLlEXDtZTxyxGgj(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int yDSntdrXykjUmdRhcNfyHGPnSqLt(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int MEKsevlELiOCWYfDRRNCJdoJfoXcA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string clfEPeSusAXoQFqWCJPgocKfGMNv(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int eQWHNsZKfWQblXPbeoEgdyhuFVSP(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int lzyKLeefcUdXpSTumzDqlnscgBBfA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string WKCOPTKENKdaCAETNwbOCbUyXviP(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int ZHvplYtyOIWTHbSrOKZXxXmPiFgc(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int HEZVLxgJgWWfJLtLxfamdJEPQOPR(CustomController_Editor P_0)
				{
					return P_0.id;
				}

				internal string OfAVRjGqpqDQkwlONEJnEBqvGKDhA(CustomController_Editor P_0)
				{
					return P_0.name;
				}

				internal int dPoqgAPTdreAnpAQentYHNldCNvS(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
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

				internal int klfLqgQhiTiFDErZFtPqfkZrwGbgA(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string yFxOFvuQBonWFoCpWgoAhSfKEiGd(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int fTBrqFxKImgEIIoFLYVbnrakukzp(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
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

				internal int JMlPZRCjMTexTUtxtXGaNiRjjXfS(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string maUDCNXrrnXjsqoPEeEBssFTIGqy(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int LuUwaDwsKzCydfNsfZudhDCqlDVVA(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
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

				internal int KubIVKNpDpNJyLyMPNJQRnzURrQE(Player_Editor P_0)
				{
					return P_0.id;
				}

				internal string DAbpzoECUOxBPdNttahCKJVxDTWn(Player_Editor P_0)
				{
					return P_0.name;
				}

				internal int RTXKeqpAaSeJpsrFKKiVRhlDYBNB(Player_Editor P_0, IList<Player_Editor> P_1)
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

				internal int NgDptdzigZeGDCNCsulsoIHVEEpAA(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
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

				internal int noBOIqBmTohubTCydMGuiAfBILoW(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
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

				internal int eZSvlLMzAIVOsUWrVrHYWDqlKiFe(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string DJHYAxoTNgBdqLTWfADCoWiowuJT(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int TewtCIsnWgbZcdVrYxwXjDRrwFRA(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int vOVfSSowhbNHHadEokFkmMnznVTR(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string cWYIgSAzpMJvcmdmaADEFTvMkgmfb(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int aROKhLKKMoAGJdhQNheUDEwbREikb(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int vePKqoBmrcGhqUZqAhJWkgduimbBA(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string nmtttQzwujxuZZxumEcbRSMZxBxj(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int TWqnNBQIEfuJUZaWDVBdhGrgBIyw(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int avchtMKaIFNWwdEdeamxKMSNQcCLb(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string RtTuLJqSANzJTShUiQceBigiMFah(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int ifXUqFvKtxQoMkANTguFgauFlaGI(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class MtqLPYjleoyKTNbJwvQWqyzwbWBN
			{
				public UserData IFDDKeJIEmeYGaoGSTsIfyPWqzDbA;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> RUqquvLLtZDzGxLVnXxWOupKTRjQ;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> NuZDIjDUealLMjwWsfizLRKzIPFxA;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> MwWLJQNRaVxrAUeMPBvoLHlVrWwt;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> WCtYBmkubRRJSsoEzjhMdgTVpKOy;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> ecCTkVPxWTgwUGdQOPrhsgSuUkgq;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> dYZlMEMoVHKhKFLRYThxkRItzwek;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> ussiyYSPRqjoHtxOoVPnKsFxlheI;

				public Func<ControllerType, List<naeysWMfgDkESCeaTYbVssEIgNkC>> vAjCRwTtAPmcoQCNkAxiBIXHVjsW;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> ZQIKkxhUpImtGuwviXNuiBQxSRqE;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> CJmRvtXkQKsdjgmKLAcjDAKCeEkV;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> JsGNpsNCEeLeEurtPHnqMIyMUTgI;

				public List<naeysWMfgDkESCeaTYbVssEIgNkC> PPqHGhArjGsRvAFQxCaHuyxdMDDM;

				internal InputCategory CsLgFVcnNAdXkdXQcJxDaZfOKPUlb(COlXJLLTpYjFgrOQKhipKOgkSfLb<InputCategory> P_0)
				{
					InputCategory inputCategory = JsonTools.Clone(P_0.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					InputCategory inputCategory2;
					if (P_0.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						inputCategory2 = P_0.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddActionCategory();
						inputCategory2 = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					inputCategory.id = inputCategory2.id;
					int index = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(inputCategory2);
					P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = inputCategory;
					return inputCategory;
				}

				internal InputBehavior BTbAoChaCamklaXtaWCGsYDKsbRNb(COlXJLLTpYjFgrOQKhipKOgkSfLb<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					InputBehavior inputBehavior2;
					if (P_0.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						inputBehavior2 = P_0.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddInputBehavior();
						inputBehavior2 = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(inputBehavior2);
					P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = inputBehavior;
					return inputBehavior;
				}

				internal InputAction QYvJJVOAhWekxlBXkNkwrfEljokBA(COlXJLLTpYjFgrOQKhipKOgkSfLb<InputAction> P_0)
				{
					WjnesqdURFqLIGIwBYqrbkHjYTDnA wjnesqdURFqLIGIwBYqrbkHjYTDnA = new WjnesqdURFqLIGIwBYqrbkHjYTDnA();
					wjnesqdURFqLIGIwBYqrbkHjYTDnA.ONbUGVygaIdiSjlJgQAtVcNacpEbA = P_0;
					InputAction inputAction = JsonTools.Clone(wjnesqdURFqLIGIwBYqrbkHjYTDnA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					int num = RUqquvLLtZDzGxLVnXxWOupKTRjQ.Find(wjnesqdURFqLIGIwBYqrbkHjYTDnA.LuFZTIbiNVWJXlnVYfxzhOnPBIVr)?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? 0;
					InputAction inputAction2;
					if (wjnesqdURFqLIGIwBYqrbkHjYTDnA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						inputAction2 = wjnesqdURFqLIGIwBYqrbkHjYTDnA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddAction(num);
						inputAction2 = wjnesqdURFqLIGIwBYqrbkHjYTDnA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[wjnesqdURFqLIGIwBYqrbkHjYTDnA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					int num2 = NuZDIjDUealLMjwWsfizLRKzIPFxA.Find(wjnesqdURFqLIGIwBYqrbkHjYTDnA.MXuHpVaIpnOXrUWDRKqCeooubLDgA)?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = num2;
					int index = wjnesqdURFqLIGIwBYqrbkHjYTDnA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(inputAction2);
					wjnesqdURFqLIGIwBYqrbkHjYTDnA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = inputAction;
					return inputAction;
				}

				internal InputLayout MAztabAgodVhCTMBOSDxrXexOTDI(COlXJLLTpYjFgrOQKhipKOgkSfLb<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					InputLayout inputLayout2;
					if (P_0.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						inputLayout2 = P_0.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddKeyboardLayout();
						inputLayout2 = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(inputLayout2);
					P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout ruxXLejwWmHnuxKrbcCXjKdSaJtF(COlXJLLTpYjFgrOQKhipKOgkSfLb<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					InputLayout inputLayout2;
					if (P_0.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						inputLayout2 = P_0.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddMouseLayout();
						inputLayout2 = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(inputLayout2);
					P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout RutmZBlscJJrolMEFLdTIVQSqPdW(COlXJLLTpYjFgrOQKhipKOgkSfLb<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					InputLayout inputLayout2;
					if (P_0.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						inputLayout2 = P_0.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddJoystickLayout();
						inputLayout2 = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(inputLayout2);
					P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout SlXvAcxCuiJJEtJFtxBlAklCGniaA(COlXJLLTpYjFgrOQKhipKOgkSfLb<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					InputLayout inputLayout2;
					if (P_0.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						inputLayout2 = P_0.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddCustomControllerLayout();
						inputLayout2 = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(inputLayout2);
					P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = inputLayout;
					return inputLayout;
				}

				internal List<naeysWMfgDkESCeaTYbVssEIgNkC> uzHYwttavPugdZDDdaFDRdyfCaDn(ControllerType P_0)
				{
					return P_0 switch
					{
						ControllerType.Keyboard => MwWLJQNRaVxrAUeMPBvoLHlVrWwt, 
						ControllerType.Mouse => WCtYBmkubRRJSsoEzjhMdgTVpKOy, 
						ControllerType.Joystick => ecCTkVPxWTgwUGdQOPrhsgSuUkgq, 
						ControllerType.Custom => dYZlMEMoVHKhKFLRYThxkRItzwek, 
						_ => throw new NotImplementedException(), 
					};
				}

				internal CustomController_Editor APwXdPgSRsMBWiqwxuSWmfoVfQnb(COlXJLLTpYjFgrOQKhipKOgkSfLb<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					CustomController_Editor customController_Editor2;
					if (P_0.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						customController_Editor2 = P_0.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddCustomController();
						customController_Editor2 = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(customController_Editor2);
					P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = customController_Editor;
					return customController_Editor;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor krKmvZwdnNLMQZHGgcKllaVeoHkF(COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					HuMKznqQlRKeauEkgdBjKZAAhMrqA huMKznqQlRKeauEkgdBjKZAAhMrqA = new HuMKznqQlRKeauEkgdBjKZAAhMrqA();
					huMKznqQlRKeauEkgdBjKZAAhMrqA.ONbUGVygaIdiSjlJgQAtVcNacpEbA = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(huMKznqQlRKeauEkgdBjKZAAhMrqA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.RmOoKpupDqaCsgEWZYwNAvRuupFG);
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
							hksURpqVSUiPzUrGiiLfnLaYAJrY hksURpqVSUiPzUrGiiLfnLaYAJrY2 = new hksURpqVSUiPzUrGiiLfnLaYAJrY();
							hksURpqVSUiPzUrGiiLfnLaYAJrY2.krwBwNIFJeWSnjxOvAxPanVBByDc = huMKznqQlRKeauEkgdBjKZAAhMrqA;
							hksURpqVSUiPzUrGiiLfnLaYAJrY2.mLQhHiRLebgeJPwOwxiMFAHuXWao = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(hksURpqVSUiPzUrGiiLfnLaYAJrY2.FAPfoIKvTTZoaOXVwvnmTisCoNnib);
							if (naeysWMfgDkESCeaTYbVssEIgNkC2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + hksURpqVSUiPzUrGiiLfnLaYAJrY2.mLQhHiRLebgeJPwOwxiMFAHuXWao);
							}
							else
							{
								list.Add(naeysWMfgDkESCeaTYbVssEIgNkC2.SjEjFwwGNljwQGLGXgFgUQHUHziX);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						WBVddsbPkyICHxMvYUedXjdnnggF wBVddsbPkyICHxMvYUedXjdnnggF = new WBVddsbPkyICHxMvYUedXjdnnggF();
						wBVddsbPkyICHxMvYUedXjdnnggF.oVIrsHWonOBqLIvRHMYTghobDJngc = huMKznqQlRKeauEkgdBjKZAAhMrqA;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<naeysWMfgDkESCeaTYbVssEIgNkC> list2 = vAjCRwTtAPmcoQCNkAxiBIXHVjsW(controllerType);
							wBVddsbPkyICHxMvYUedXjdnnggF.mLQhHiRLebgeJPwOwxiMFAHuXWao = controllerMapLayoutManager_Rule_Editor2.layoutId;
							naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = list2.Find(wBVddsbPkyICHxMvYUedXjdnnggF.YPoWwDPQrvpXVtcTuXkRnEGWQdii);
							if (naeysWMfgDkESCeaTYbVssEIgNkC3 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + wBVddsbPkyICHxMvYUedXjdnnggF.mLQhHiRLebgeJPwOwxiMFAHuXWao);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = naeysWMfgDkESCeaTYbVssEIgNkC3.SjEjFwwGNljwQGLGXgFgUQHUHziX;
							}
						}
					}
					int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							FDCSZoFwbUVLoibpBOMjiqsMjfeT fDCSZoFwbUVLoibpBOMjiqsMjfeT = new FDCSZoFwbUVLoibpBOMjiqsMjfeT();
							fDCSZoFwbUVLoibpBOMjiqsMjfeT.ZUpNrZznCjWIRtHDSILnhuGYdYtPA = huMKznqQlRKeauEkgdBjKZAAhMrqA;
							List<naeysWMfgDkESCeaTYbVssEIgNkC> zQIKkxhUpImtGuwviXNuiBQxSRqE = ZQIKkxhUpImtGuwviXNuiBQxSRqE;
							fDCSZoFwbUVLoibpBOMjiqsMjfeT.mLQhHiRLebgeJPwOwxiMFAHuXWao = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC4 = zQIKkxhUpImtGuwviXNuiBQxSRqE.Find(fDCSZoFwbUVLoibpBOMjiqsMjfeT.bvXbESoVHdfvSlAUpfAZDywOBUlR);
							if (naeysWMfgDkESCeaTYbVssEIgNkC4 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + fDCSZoFwbUVLoibpBOMjiqsMjfeT.mLQhHiRLebgeJPwOwxiMFAHuXWao);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = naeysWMfgDkESCeaTYbVssEIgNkC4.SjEjFwwGNljwQGLGXgFgUQHUHziX;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (huMKznqQlRKeauEkgdBjKZAAhMrqA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = huMKznqQlRKeauEkgdBjKZAAhMrqA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = huMKznqQlRKeauEkgdBjKZAAhMrqA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[huMKznqQlRKeauEkgdBjKZAAhMrqA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = huMKznqQlRKeauEkgdBjKZAAhMrqA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					huMKznqQlRKeauEkgdBjKZAAhMrqA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				internal ControllerMapEnabler_RuleSet_Editor GkFVPeSCZseNjkxPQZHXNVRPKQnI(COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					MFpQWWvnmNzyXiBPoLAXXRJYPVy mFpQWWvnmNzyXiBPoLAXXRJYPVy = new MFpQWWvnmNzyXiBPoLAXXRJYPVy();
					mFpQWWvnmNzyXiBPoLAXXRJYPVy.ONbUGVygaIdiSjlJgQAtVcNacpEbA = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(mFpQWWvnmNzyXiBPoLAXXRJYPVy.ONbUGVygaIdiSjlJgQAtVcNacpEbA.RmOoKpupDqaCsgEWZYwNAvRuupFG);
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
							UNXlJvFEFIJjDEnqzweJQfXBckiP uNXlJvFEFIJjDEnqzweJQfXBckiP = new UNXlJvFEFIJjDEnqzweJQfXBckiP();
							uNXlJvFEFIJjDEnqzweJQfXBckiP.JTrQfGBDXyKtzqdJoaVHhVyRTcxi = mFpQWWvnmNzyXiBPoLAXXRJYPVy;
							uNXlJvFEFIJjDEnqzweJQfXBckiP.mLQhHiRLebgeJPwOwxiMFAHuXWao = controllerMapEnabler_Rule_Editor.categoryIds[j];
							naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(uNXlJvFEFIJjDEnqzweJQfXBckiP.HUNPLNdlKdDIzopVCNvijkiQCKGx);
							if (naeysWMfgDkESCeaTYbVssEIgNkC2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + uNXlJvFEFIJjDEnqzweJQfXBckiP.mLQhHiRLebgeJPwOwxiMFAHuXWao);
							}
							else
							{
								list.Add(naeysWMfgDkESCeaTYbVssEIgNkC2.SjEjFwwGNljwQGLGXgFgUQHUHziX);
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
						List<naeysWMfgDkESCeaTYbVssEIgNkC> list2 = vAjCRwTtAPmcoQCNkAxiBIXHVjsW(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							AniWXKURoKmXiBRbtNbZLzGTaxoL aniWXKURoKmXiBRbtNbZLzGTaxoL = new AniWXKURoKmXiBRbtNbZLzGTaxoL();
							aniWXKURoKmXiBRbtNbZLzGTaxoL.rmBsORwpQCxKjSbPNCZTcGQDbWqv = mFpQWWvnmNzyXiBPoLAXXRJYPVy;
							aniWXKURoKmXiBRbtNbZLzGTaxoL.mLQhHiRLebgeJPwOwxiMFAHuXWao = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = list2.Find(aniWXKURoKmXiBRbtNbZLzGTaxoL.WISjcycUnyboWEOgWCdYbniGiIDUA);
							if (naeysWMfgDkESCeaTYbVssEIgNkC3 == null)
							{
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + aniWXKURoKmXiBRbtNbZLzGTaxoL.mLQhHiRLebgeJPwOwxiMFAHuXWao);
							}
							else
							{
								list3.Add(naeysWMfgDkESCeaTYbVssEIgNkC3.SjEjFwwGNljwQGLGXgFgUQHUHziX);
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
							jRqSmaOmYCVwGtahSennfdTYmeFPA jRqSmaOmYCVwGtahSennfdTYmeFPA2 = new jRqSmaOmYCVwGtahSennfdTYmeFPA();
							jRqSmaOmYCVwGtahSennfdTYmeFPA2.yPhkuYgcOlKWjgyaKKwlTrKBBqei = mFpQWWvnmNzyXiBPoLAXXRJYPVy;
							List<naeysWMfgDkESCeaTYbVssEIgNkC> zQIKkxhUpImtGuwviXNuiBQxSRqE = ZQIKkxhUpImtGuwviXNuiBQxSRqE;
							jRqSmaOmYCVwGtahSennfdTYmeFPA2.mLQhHiRLebgeJPwOwxiMFAHuXWao = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC4 = zQIKkxhUpImtGuwviXNuiBQxSRqE.Find(jRqSmaOmYCVwGtahSennfdTYmeFPA2.cufkkYslqlHotLpWFlHKpxapCmZe);
							if (naeysWMfgDkESCeaTYbVssEIgNkC4 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + jRqSmaOmYCVwGtahSennfdTYmeFPA2.mLQhHiRLebgeJPwOwxiMFAHuXWao);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = naeysWMfgDkESCeaTYbVssEIgNkC4.SjEjFwwGNljwQGLGXgFgUQHUHziX;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (mFpQWWvnmNzyXiBPoLAXXRJYPVy.ONbUGVygaIdiSjlJgQAtVcNacpEbA.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						controllerMapEnabler_RuleSet_Editor2 = mFpQWWvnmNzyXiBPoLAXXRJYPVy.ONbUGVygaIdiSjlJgQAtVcNacpEbA.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = mFpQWWvnmNzyXiBPoLAXXRJYPVy.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[mFpQWWvnmNzyXiBPoLAXXRJYPVy.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = mFpQWWvnmNzyXiBPoLAXXRJYPVy.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					mFpQWWvnmNzyXiBPoLAXXRJYPVy.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				internal Player_Editor mFpFbkhkmtxSJCWrNiHIrZVKCEYQ(COlXJLLTpYjFgrOQKhipKOgkSfLb<Player_Editor> P_0)
				{
					nuhiufpYdiEKqwkXcMODaSYEqYzU nuhiufpYdiEKqwkXcMODaSYEqYzU2 = new nuhiufpYdiEKqwkXcMODaSYEqYzU();
					nuhiufpYdiEKqwkXcMODaSYEqYzU2.xGlHwoJFlODLYhkhlLZqApYkNhdS = this;
					nuhiufpYdiEKqwkXcMODaSYEqYzU2.ONbUGVygaIdiSjlJgQAtVcNacpEbA = P_0;
					Player_Editor player_Editor = JsonTools.Clone(nuhiufpYdiEKqwkXcMODaSYEqYzU2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					Action<List<Player_Editor.Mapping>, List<naeysWMfgDkESCeaTYbVssEIgNkC>> action = nuhiufpYdiEKqwkXcMODaSYEqYzU2.OTEbBKbWwtqFzTiqjdkGHsRAblqJA;
					action(player_Editor.defaultKeyboardMaps, MwWLJQNRaVxrAUeMPBvoLHlVrWwt);
					action(player_Editor.defaultMouseMaps, WCtYBmkubRRJSsoEzjhMdgTVpKOy);
					action(player_Editor.defaultJoystickMaps, ecCTkVPxWTgwUGdQOPrhsgSuUkgq);
					action(player_Editor.defaultCustomControllerMaps, dYZlMEMoVHKhKFLRYThxkRItzwek);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						tNwDdZfHqtPctSRqiScXoUNAvIbhA tNwDdZfHqtPctSRqiScXoUNAvIbhA2 = new tNwDdZfHqtPctSRqiScXoUNAvIbhA();
						tNwDdZfHqtPctSRqiScXoUNAvIbhA2.ZPIkvplwROMqhgOqbvPXKnAvIAjjA = nuhiufpYdiEKqwkXcMODaSYEqYzU2;
						tNwDdZfHqtPctSRqiScXoUNAvIbhA2.yMxlTPVDIQhbwEFgwysEQZOQcWuo = player_Editor.startingCustomControllers[i];
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = ZQIKkxhUpImtGuwviXNuiBQxSRqE.Find(tNwDdZfHqtPctSRqiScXoUNAvIbhA2.npSlgoYPUzaOfefftOhVmEjyGiviA);
						tNwDdZfHqtPctSRqiScXoUNAvIbhA2.yMxlTPVDIQhbwEFgwysEQZOQcWuo.sourceId = naeysWMfgDkESCeaTYbVssEIgNkC2?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						IyMzOZCQFaPypCNylGIXGyBZiRTy iyMzOZCQFaPypCNylGIXGyBZiRTy = new IyMzOZCQFaPypCNylGIXGyBZiRTy();
						iyMzOZCQFaPypCNylGIXGyBZiRTy.ahNpmKPcgEuexwOLfSIZRoOsGZGq = nuhiufpYdiEKqwkXcMODaSYEqYzU2;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							iyMzOZCQFaPypCNylGIXGyBZiRTy.ZamYCQxLHAGKChjEHxjlKOSnIhez = ruleSetMapping.id;
							naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = CJmRvtXkQKsdjgmKLAcjDAKCeEkV.Find(iyMzOZCQFaPypCNylGIXGyBZiRTy.lsGirvyJylGgTDEmEDMZoHhioTCh);
							if (naeysWMfgDkESCeaTYbVssEIgNkC3 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + iyMzOZCQFaPypCNylGIXGyBZiRTy.ZamYCQxLHAGKChjEHxjlKOSnIhez);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = naeysWMfgDkESCeaTYbVssEIgNkC3.SjEjFwwGNljwQGLGXgFgUQHUHziX;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						wjYazHQKogZqvNsjzJvaXkZeSYtF wjYazHQKogZqvNsjzJvaXkZeSYtF2 = new wjYazHQKogZqvNsjzJvaXkZeSYtF();
						wjYazHQKogZqvNsjzJvaXkZeSYtF2.ZMdLMwpzExANImNNhEJGpgwyrykv = nuhiufpYdiEKqwkXcMODaSYEqYzU2;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							wjYazHQKogZqvNsjzJvaXkZeSYtF2.ZamYCQxLHAGKChjEHxjlKOSnIhez = ruleSetMapping2.id;
							naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC4 = JsGNpsNCEeLeEurtPHnqMIyMUTgI.Find(wjYazHQKogZqvNsjzJvaXkZeSYtF2.ZPAWhQUEWEJOReYDIRxNhjMDJJfs);
							if (naeysWMfgDkESCeaTYbVssEIgNkC4 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + wjYazHQKogZqvNsjzJvaXkZeSYtF2.ZamYCQxLHAGKChjEHxjlKOSnIhez);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = naeysWMfgDkESCeaTYbVssEIgNkC4.SjEjFwwGNljwQGLGXgFgUQHUHziX;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (nuhiufpYdiEKqwkXcMODaSYEqYzU2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						player_Editor2 = nuhiufpYdiEKqwkXcMODaSYEqYzU2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.NgDptdzigZeGDCNCsulsoIHVEEpAA;
						FlvdJyYhDrWEcQVBPTNtHIlHoKmt(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						FlvdJyYhDrWEcQVBPTNtHIlHoKmt(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						FlvdJyYhDrWEcQVBPTNtHIlHoKmt(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						FlvdJyYhDrWEcQVBPTNtHIlHoKmt(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						FlvdJyYhDrWEcQVBPTNtHIlHoKmt(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.noBOIqBmTohubTCydMGuiAfBILoW);
						player_Editor = player_Editor3;
					}
					else
					{
						IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddPlayer();
						player_Editor2 = nuhiufpYdiEKqwkXcMODaSYEqYzU2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[nuhiufpYdiEKqwkXcMODaSYEqYzU2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = nuhiufpYdiEKqwkXcMODaSYEqYzU2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(player_Editor2);
					nuhiufpYdiEKqwkXcMODaSYEqYzU2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = player_Editor;
					return player_Editor;
				}
			}

			private sealed class WjnesqdURFqLIGIwBYqrbkHjYTDnA
			{
				public COlXJLLTpYjFgrOQKhipKOgkSfLb<InputAction> ONbUGVygaIdiSjlJgQAtVcNacpEbA;

				internal bool LuFZTIbiNVWJXlnVYfxzhOnPBIVr(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == ONbUGVygaIdiSjlJgQAtVcNacpEbA.RmOoKpupDqaCsgEWZYwNAvRuupFG.categoryId;
				}

				internal bool MXuHpVaIpnOXrUWDRKqCeooubLDgA(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == ONbUGVygaIdiSjlJgQAtVcNacpEbA.RmOoKpupDqaCsgEWZYwNAvRuupFG.behaviorId;
				}
			}

			private sealed class AniWXKURoKmXiBRbtNbZLzGTaxoL
			{
				public int mLQhHiRLebgeJPwOwxiMFAHuXWao;

				public MFpQWWvnmNzyXiBPoLAXXRJYPVy rmBsORwpQCxKjSbPNCZTcGQDbWqv;

				internal bool WISjcycUnyboWEOgWCdYbniGiIDUA(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(rmBsORwpQCxKjSbPNCZTcGQDbWqv.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == mLQhHiRLebgeJPwOwxiMFAHuXWao;
				}
			}

			private sealed class jRqSmaOmYCVwGtahSennfdTYmeFPA
			{
				public int mLQhHiRLebgeJPwOwxiMFAHuXWao;

				public MFpQWWvnmNzyXiBPoLAXXRJYPVy yPhkuYgcOlKWjgyaKKwlTrKBBqei;

				internal bool cufkkYslqlHotLpWFlHKpxapCmZe(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(yPhkuYgcOlKWjgyaKKwlTrKBBqei.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == mLQhHiRLebgeJPwOwxiMFAHuXWao;
				}
			}

			private sealed class nuhiufpYdiEKqwkXcMODaSYEqYzU
			{
				public COlXJLLTpYjFgrOQKhipKOgkSfLb<Player_Editor> ONbUGVygaIdiSjlJgQAtVcNacpEbA;

				public MtqLPYjleoyKTNbJwvQWqyzwbWBN xGlHwoJFlODLYhkhlLZqApYkNhdS;

				internal void OTEbBKbWwtqFzTiqjdkGHsRAblqJA(List<Player_Editor.Mapping> P_0, List<naeysWMfgDkESCeaTYbVssEIgNkC> P_1)
				{
					for (int i = 0; i < P_0.Count; i++)
					{
						ChPtbqRXvJkoNUBFkzeFsTPCPSUS chPtbqRXvJkoNUBFkzeFsTPCPSUS = new ChPtbqRXvJkoNUBFkzeFsTPCPSUS();
						chPtbqRXvJkoNUBFkzeFsTPCPSUS.HdeaPytJIyTjfiRswWSGzYbTiqgK = this;
						chPtbqRXvJkoNUBFkzeFsTPCPSUS.YLJbohgdlHESdLrwdXTReYVqfJdf = P_0[i];
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = xGlHwoJFlODLYhkhlLZqApYkNhdS.ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(chPtbqRXvJkoNUBFkzeFsTPCPSUS.pBxiGwdlusROOHcxrtgUiCWqMGag);
						chPtbqRXvJkoNUBFkzeFsTPCPSUS.YLJbohgdlHESdLrwdXTReYVqfJdf.categoryId = naeysWMfgDkESCeaTYbVssEIgNkC2?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
						naeysWMfgDkESCeaTYbVssEIgNkC2 = P_1.Find(chPtbqRXvJkoNUBFkzeFsTPCPSUS.UCnAvqXNaGaWketqUlSwlKrXKByNA);
						chPtbqRXvJkoNUBFkzeFsTPCPSUS.YLJbohgdlHESdLrwdXTReYVqfJdf.layoutId = naeysWMfgDkESCeaTYbVssEIgNkC2?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					}
				}
			}

			private sealed class ChPtbqRXvJkoNUBFkzeFsTPCPSUS
			{
				public Player_Editor.Mapping YLJbohgdlHESdLrwdXTReYVqfJdf;

				public nuhiufpYdiEKqwkXcMODaSYEqYzU HdeaPytJIyTjfiRswWSGzYbTiqgK;

				internal bool pBxiGwdlusROOHcxrtgUiCWqMGag(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(HdeaPytJIyTjfiRswWSGzYbTiqgK.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == YLJbohgdlHESdLrwdXTReYVqfJdf.categoryId;
				}

				internal bool UCnAvqXNaGaWketqUlSwlKrXKByNA(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(HdeaPytJIyTjfiRswWSGzYbTiqgK.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == YLJbohgdlHESdLrwdXTReYVqfJdf.layoutId;
				}
			}

			private sealed class tNwDdZfHqtPctSRqiScXoUNAvIbhA
			{
				public Player_Editor.CreateControllerInfo yMxlTPVDIQhbwEFgwysEQZOQcWuo;

				public nuhiufpYdiEKqwkXcMODaSYEqYzU ZPIkvplwROMqhgOqbvPXKnAvIAjjA;

				internal bool npSlgoYPUzaOfefftOhVmEjyGiviA(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ZPIkvplwROMqhgOqbvPXKnAvIAjjA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == yMxlTPVDIQhbwEFgwysEQZOQcWuo.sourceId;
				}
			}

			private sealed class IyMzOZCQFaPypCNylGIXGyBZiRTy
			{
				public int ZamYCQxLHAGKChjEHxjlKOSnIhez;

				public nuhiufpYdiEKqwkXcMODaSYEqYzU ahNpmKPcgEuexwOLfSIZRoOsGZGq;

				internal bool lsGirvyJylGgTDEmEDMZoHhioTCh(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ahNpmKPcgEuexwOLfSIZRoOsGZGq.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == ZamYCQxLHAGKChjEHxjlKOSnIhez;
				}
			}

			private sealed class wjYazHQKogZqvNsjzJvaXkZeSYtF
			{
				public int ZamYCQxLHAGKChjEHxjlKOSnIhez;

				public nuhiufpYdiEKqwkXcMODaSYEqYzU ZMdLMwpzExANImNNhEJGpgwyrykv;

				internal bool ZPAWhQUEWEJOReYDIRxNhjMDJJfs(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ZMdLMwpzExANImNNhEJGpgwyrykv.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == ZamYCQxLHAGKChjEHxjlKOSnIhez;
				}
			}

			private sealed class jVZMwDHQLZFNjbeYWPMcwxqpSdFC
			{
				public List<naeysWMfgDkESCeaTYbVssEIgNkC> gtUPcNngmINQuYkUuFlZeYhYBlmHb;

				public MtqLPYjleoyKTNbJwvQWqyzwbWBN BqGZidPkKujaxhyjjmYBYrFWKDRI;

				internal int yURYSGnQDVJzBcOvVirmmljBOhoT(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					YGWVupdoUWhEbWITdidCSNGDSHlF yGWVupdoUWhEbWITdidCSNGDSHlF = new YGWVupdoUWhEbWITdidCSNGDSHlF();
					yGWVupdoUWhEbWITdidCSNGDSHlF.yMxlTPVDIQhbwEFgwysEQZOQcWuo = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = BqGZidPkKujaxhyjjmYBYrFWKDRI.ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(yGWVupdoUWhEbWITdidCSNGDSHlF.qczFIHmBVfPcmEjxhiqeCfYXEWCO);
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = gtUPcNngmINQuYkUuFlZeYhYBlmHb.Find(yGWVupdoUWhEbWITdidCSNGDSHlF.TDPrezOnfKNDUeGyaGYxhQVccXzrA);
						if (naeysWMfgDkESCeaTYbVssEIgNkC2 != null && naeysWMfgDkESCeaTYbVssEIgNkC2.SjEjFwwGNljwQGLGXgFgUQHUHziX == P_1[i].categoryId && naeysWMfgDkESCeaTYbVssEIgNkC3 != null && naeysWMfgDkESCeaTYbVssEIgNkC3.SjEjFwwGNljwQGLGXgFgUQHUHziX == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor cRTGWJbzzkmuBSZZlnsIMMTWerzd(COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMap_Editor> P_0)
				{
					bPpQoxAOAzLTIeiUsJoBhYMfqCPu bPpQoxAOAzLTIeiUsJoBhYMfqCPu2 = new bPpQoxAOAzLTIeiUsJoBhYMfqCPu();
					bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.ONbUGVygaIdiSjlJgQAtVcNacpEbA = P_0;
					bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA = JsonTools.Clone(bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = BqGZidPkKujaxhyjjmYBYrFWKDRI.ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.VVPPjLLmcIhoYHJhWPJbVBMMCkpZ);
					naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = gtUPcNngmINQuYkUuFlZeYhYBlmHb.Find(bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.ndtEyrrmJlFfHuzvVKXKigbQVEJO);
					bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId = naeysWMfgDkESCeaTYbVssEIgNkC2?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId = naeysWMfgDkESCeaTYbVssEIgNkC3?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					for (int i = 0; i < bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps.Count; i++)
					{
						ALagsxwySjbWPfKfXXTMDfqcEkbi aLagsxwySjbWPfKfXXTMDfqcEkbi = new ALagsxwySjbWPfKfXXTMDfqcEkbi();
						aLagsxwySjbWPfKfXXTMDfqcEkbi.mutAMoSDgjAYPczYsZGUgRmOWOvc = bPpQoxAOAzLTIeiUsJoBhYMfqCPu2;
						aLagsxwySjbWPfKfXXTMDfqcEkbi.YLJbohgdlHESdLrwdXTReYVqfJdf = aLagsxwySjbWPfKfXXTMDfqcEkbi.mutAMoSDgjAYPczYsZGUgRmOWOvc.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps[i];
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC4 = BqGZidPkKujaxhyjjmYBYrFWKDRI.PPqHGhArjGsRvAFQxCaHuyxdMDDM.Find(aLagsxwySjbWPfKfXXTMDfqcEkbi.pIkxfUvRlcJQJgOlHFTiEAXcyGlHA);
						aLagsxwySjbWPfKfXXTMDfqcEkbi.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId = naeysWMfgDkESCeaTYbVssEIgNkC4?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
						aLagsxwySjbWPfKfXXTMDfqcEkbi.YLJbohgdlHESdLrwdXTReYVqfJdf._actionCategoryId = ((BqGZidPkKujaxhyjjmYBYrFWKDRI.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.GetActionById(aLagsxwySjbWPfKfXXTMDfqcEkbi.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId) != null) ? BqGZidPkKujaxhyjjmYBYrFWKDRI.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.GetActionById(aLagsxwySjbWPfKfXXTMDfqcEkbi.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						controllerMap_Editor = bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.TewtCIsnWgbZcdVrYxwXjDRrwFRA;
						FlvdJyYhDrWEcQVBPTNtHIlHoKmt(controllerMap_Editor.actionElementMaps, bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA = controllerMap_Editor2;
					}
					else
					{
						BqGZidPkKujaxhyjjmYBYrFWKDRI.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.CreateKeyboardMap(bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId, bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId);
						controllerMap_Editor = bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA.id = controllerMap_Editor.id;
					int index = bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(controllerMap_Editor);
					bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA;
					return bPpQoxAOAzLTIeiUsJoBhYMfqCPu2.FqefGyTnmogMCBmJVkgZDrphAUbeA;
				}
			}

			private sealed class YGWVupdoUWhEbWITdidCSNGDSHlF
			{
				public ControllerMap_Editor yMxlTPVDIQhbwEFgwysEQZOQcWuo;

				public Predicate<naeysWMfgDkESCeaTYbVssEIgNkC> FBTSeYsVDdfmPeJmWPFVQNECRvTt;

				public Predicate<naeysWMfgDkESCeaTYbVssEIgNkC> DvQBzWCiRTUIZJKdwZiTYqUFPUTs;

				internal bool qczFIHmBVfPcmEjxhiqeCfYXEWCO(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.tSPdAcroqZjcPqEvARGyLeBpUxNS == yMxlTPVDIQhbwEFgwysEQZOQcWuo.categoryId;
				}

				internal bool TDPrezOnfKNDUeGyaGYxhQVccXzrA(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.tSPdAcroqZjcPqEvARGyLeBpUxNS == yMxlTPVDIQhbwEFgwysEQZOQcWuo.layoutId;
				}
			}

			private sealed class bPpQoxAOAzLTIeiUsJoBhYMfqCPu
			{
				public COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMap_Editor> ONbUGVygaIdiSjlJgQAtVcNacpEbA;

				public ControllerMap_Editor FqefGyTnmogMCBmJVkgZDrphAUbeA;

				internal bool VVPPjLLmcIhoYHJhWPJbVBMMCkpZ(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId;
				}

				internal bool ndtEyrrmJlFfHuzvVKXKigbQVEJO(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId;
				}
			}

			private sealed class lFZYoaiGvVADFkbDkIehOCudYqth
			{
				public List<int> nlwiyfnqsCbETyMciTXehwLnaNtd;

				public MtqLPYjleoyKTNbJwvQWqyzwbWBN tumGMqEalshGxISRJirUAUNHyfMPb;

				internal InputMapCategory WmeuzrRcqtCijFavgzxfoCAWwOOvA(COlXJLLTpYjFgrOQKhipKOgkSfLb<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					InputMapCategory inputMapCategory2;
					if (P_0.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						inputMapCategory2 = P_0.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
					}
					else
					{
						tumGMqEalshGxISRJirUAUNHyfMPb.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.AddMapCategory();
						inputMapCategory2 = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					int num = P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(inputMapCategory2);
					if (P_0.PWFxOJmPgKpqjyyCqfPOnHWAOauV == naeysWMfgDkESCeaTYbVssEIgNkC.XlJHxfRmRgfLLLIPvOHDAqHpQdXd.otherId)
					{
						nlwiyfnqsCbETyMciTXehwLnaNtd.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.arWJGMXUoMCDxFIjfvIIOBKhLsIM[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class ALagsxwySjbWPfKfXXTMDfqcEkbi
			{
				public ActionElementMap YLJbohgdlHESdLrwdXTReYVqfJdf;

				public bPpQoxAOAzLTIeiUsJoBhYMfqCPu mutAMoSDgjAYPczYsZGUgRmOWOvc;

				internal bool pIkxfUvRlcJQJgOlHFTiEAXcyGlHA(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(mutAMoSDgjAYPczYsZGUgRmOWOvc.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == YLJbohgdlHESdLrwdXTReYVqfJdf._actionId;
				}
			}

			private sealed class YljftjDhYKDJXDSkVvPgDIwIVEjfb
			{
				public List<naeysWMfgDkESCeaTYbVssEIgNkC> gtUPcNngmINQuYkUuFlZeYhYBlmHb;

				public MtqLPYjleoyKTNbJwvQWqyzwbWBN egIQaaqJvXQLtjekMNqHYqSJAUSM;

				internal int JhswkKsPLilFdTtKhqfSWAepcLHt(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					VFwhCXtEYTTPPfBpfXIXfxzKAtUd vFwhCXtEYTTPPfBpfXIXfxzKAtUd = new VFwhCXtEYTTPPfBpfXIXfxzKAtUd();
					vFwhCXtEYTTPPfBpfXIXfxzKAtUd.yMxlTPVDIQhbwEFgwysEQZOQcWuo = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = egIQaaqJvXQLtjekMNqHYqSJAUSM.ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(vFwhCXtEYTTPPfBpfXIXfxzKAtUd.hqvJiRPPNIholDpoykkXzsZZLgsLA);
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = gtUPcNngmINQuYkUuFlZeYhYBlmHb.Find(vFwhCXtEYTTPPfBpfXIXfxzKAtUd.RWSeZNrufFYbnIGwmAKtRFtGpAly);
						if (naeysWMfgDkESCeaTYbVssEIgNkC2 != null && naeysWMfgDkESCeaTYbVssEIgNkC2.SjEjFwwGNljwQGLGXgFgUQHUHziX == P_1[i].categoryId && naeysWMfgDkESCeaTYbVssEIgNkC3 != null && naeysWMfgDkESCeaTYbVssEIgNkC3.SjEjFwwGNljwQGLGXgFgUQHUHziX == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor RwnXobjCmgMNUnUSOEDbIcUCCZWL(COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMap_Editor> P_0)
				{
					ZUgphOSHVSrKUqiuQzNnImHbAtAH zUgphOSHVSrKUqiuQzNnImHbAtAH = new ZUgphOSHVSrKUqiuQzNnImHbAtAH();
					zUgphOSHVSrKUqiuQzNnImHbAtAH.ONbUGVygaIdiSjlJgQAtVcNacpEbA = P_0;
					zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA = JsonTools.Clone(zUgphOSHVSrKUqiuQzNnImHbAtAH.ONbUGVygaIdiSjlJgQAtVcNacpEbA.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = egIQaaqJvXQLtjekMNqHYqSJAUSM.ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(zUgphOSHVSrKUqiuQzNnImHbAtAH.jlUuBuhRCIeUClsfdjXqCKKNUKfhA);
					naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = gtUPcNngmINQuYkUuFlZeYhYBlmHb.Find(zUgphOSHVSrKUqiuQzNnImHbAtAH.jJnFClatRnCENKlxqqnaFzfAtBxlc);
					zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId = naeysWMfgDkESCeaTYbVssEIgNkC2?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId = naeysWMfgDkESCeaTYbVssEIgNkC3?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					for (int i = 0; i < zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps.Count; i++)
					{
						uemOHNWfgzJKIYBfZzyyEMaowzCc uemOHNWfgzJKIYBfZzyyEMaowzCc2 = new uemOHNWfgzJKIYBfZzyyEMaowzCc();
						uemOHNWfgzJKIYBfZzyyEMaowzCc2.KJXGANehYgTFIiIMGWpoBwOfUBCBA = zUgphOSHVSrKUqiuQzNnImHbAtAH;
						uemOHNWfgzJKIYBfZzyyEMaowzCc2.YLJbohgdlHESdLrwdXTReYVqfJdf = uemOHNWfgzJKIYBfZzyyEMaowzCc2.KJXGANehYgTFIiIMGWpoBwOfUBCBA.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps[i];
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC4 = egIQaaqJvXQLtjekMNqHYqSJAUSM.PPqHGhArjGsRvAFQxCaHuyxdMDDM.Find(uemOHNWfgzJKIYBfZzyyEMaowzCc2.gZEEMTVqreuZrFSGtHudkdcAyBhO);
						uemOHNWfgzJKIYBfZzyyEMaowzCc2.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId = naeysWMfgDkESCeaTYbVssEIgNkC4?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
						uemOHNWfgzJKIYBfZzyyEMaowzCc2.YLJbohgdlHESdLrwdXTReYVqfJdf._actionCategoryId = ((egIQaaqJvXQLtjekMNqHYqSJAUSM.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.GetActionById(uemOHNWfgzJKIYBfZzyyEMaowzCc2.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId) != null) ? egIQaaqJvXQLtjekMNqHYqSJAUSM.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.GetActionById(uemOHNWfgzJKIYBfZzyyEMaowzCc2.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (zUgphOSHVSrKUqiuQzNnImHbAtAH.ONbUGVygaIdiSjlJgQAtVcNacpEbA.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						controllerMap_Editor = zUgphOSHVSrKUqiuQzNnImHbAtAH.ONbUGVygaIdiSjlJgQAtVcNacpEbA.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.aROKhLKKMoAGJdhQNheUDEwbREikb;
						FlvdJyYhDrWEcQVBPTNtHIlHoKmt(controllerMap_Editor.actionElementMaps, zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA = controllerMap_Editor2;
					}
					else
					{
						egIQaaqJvXQLtjekMNqHYqSJAUSM.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.CreateMouseMap(zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId, zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId);
						controllerMap_Editor = zUgphOSHVSrKUqiuQzNnImHbAtAH.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[zUgphOSHVSrKUqiuQzNnImHbAtAH.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA.id = controllerMap_Editor.id;
					int index = zUgphOSHVSrKUqiuQzNnImHbAtAH.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(controllerMap_Editor);
					zUgphOSHVSrKUqiuQzNnImHbAtAH.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA;
					return zUgphOSHVSrKUqiuQzNnImHbAtAH.FqefGyTnmogMCBmJVkgZDrphAUbeA;
				}
			}

			private sealed class VFwhCXtEYTTPPfBpfXIXfxzKAtUd
			{
				public ControllerMap_Editor yMxlTPVDIQhbwEFgwysEQZOQcWuo;

				public Predicate<naeysWMfgDkESCeaTYbVssEIgNkC> ARjDIfrPRKlnfdtKjAeqSibaMtwJ;

				public Predicate<naeysWMfgDkESCeaTYbVssEIgNkC> ymUjQJqoImsdOxOYQgogKbxzNLQk;

				internal bool hqvJiRPPNIholDpoykkXzsZZLgsLA(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.tSPdAcroqZjcPqEvARGyLeBpUxNS == yMxlTPVDIQhbwEFgwysEQZOQcWuo.categoryId;
				}

				internal bool RWSeZNrufFYbnIGwmAKtRFtGpAly(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.tSPdAcroqZjcPqEvARGyLeBpUxNS == yMxlTPVDIQhbwEFgwysEQZOQcWuo.layoutId;
				}
			}

			private sealed class ZUgphOSHVSrKUqiuQzNnImHbAtAH
			{
				public COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMap_Editor> ONbUGVygaIdiSjlJgQAtVcNacpEbA;

				public ControllerMap_Editor FqefGyTnmogMCBmJVkgZDrphAUbeA;

				internal bool jlUuBuhRCIeUClsfdjXqCKKNUKfhA(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId;
				}

				internal bool jJnFClatRnCENKlxqqnaFzfAtBxlc(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId;
				}
			}

			private sealed class uemOHNWfgzJKIYBfZzyyEMaowzCc
			{
				public ActionElementMap YLJbohgdlHESdLrwdXTReYVqfJdf;

				public ZUgphOSHVSrKUqiuQzNnImHbAtAH KJXGANehYgTFIiIMGWpoBwOfUBCBA;

				internal bool gZEEMTVqreuZrFSGtHudkdcAyBhO(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(KJXGANehYgTFIiIMGWpoBwOfUBCBA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == YLJbohgdlHESdLrwdXTReYVqfJdf._actionId;
				}
			}

			private sealed class YEgaotVGdOymiSBThPVMEyohwjUC
			{
				public List<naeysWMfgDkESCeaTYbVssEIgNkC> gtUPcNngmINQuYkUuFlZeYhYBlmHb;

				public MtqLPYjleoyKTNbJwvQWqyzwbWBN RVBecluoohFyYctQAGZTxUUNpZRKA;

				internal int fQoPLZGVvPioDGOYWtMcKVLMIeVd(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					EnScWmMdzKJFShMwNFviIoMIaEar enScWmMdzKJFShMwNFviIoMIaEar = new EnScWmMdzKJFShMwNFviIoMIaEar();
					enScWmMdzKJFShMwNFviIoMIaEar.yMxlTPVDIQhbwEFgwysEQZOQcWuo = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = RVBecluoohFyYctQAGZTxUUNpZRKA.ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(enScWmMdzKJFShMwNFviIoMIaEar.OoXTchZcWbCSwdEBRfedhwhZdOeY);
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = gtUPcNngmINQuYkUuFlZeYhYBlmHb.Find(enScWmMdzKJFShMwNFviIoMIaEar.syVesNsWlJukOhsAhsQkCwUMKaQQ);
						if (enScWmMdzKJFShMwNFviIoMIaEar.yMxlTPVDIQhbwEFgwysEQZOQcWuo.hardwareGuid == P_1[i].hardwareGuid && naeysWMfgDkESCeaTYbVssEIgNkC2 != null && naeysWMfgDkESCeaTYbVssEIgNkC2.SjEjFwwGNljwQGLGXgFgUQHUHziX == P_1[i].categoryId && naeysWMfgDkESCeaTYbVssEIgNkC3 != null && naeysWMfgDkESCeaTYbVssEIgNkC3.SjEjFwwGNljwQGLGXgFgUQHUHziX == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor VlmpRhwiaGAbSMMLZDtcYWgbQhDo(COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMap_Editor> P_0)
				{
					wZczgsTjByfIeelDprtdXSuPyCLbA wZczgsTjByfIeelDprtdXSuPyCLbA2 = new wZczgsTjByfIeelDprtdXSuPyCLbA();
					wZczgsTjByfIeelDprtdXSuPyCLbA2.ONbUGVygaIdiSjlJgQAtVcNacpEbA = P_0;
					wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA = JsonTools.Clone(wZczgsTjByfIeelDprtdXSuPyCLbA2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = RVBecluoohFyYctQAGZTxUUNpZRKA.ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(wZczgsTjByfIeelDprtdXSuPyCLbA2.oVuGTcdxkPBlYHHrFcnbYUNMxAan);
					naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = gtUPcNngmINQuYkUuFlZeYhYBlmHb.Find(wZczgsTjByfIeelDprtdXSuPyCLbA2.heoXWeLgtMYcUgtQbdBpJWyjkxRB);
					wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId = naeysWMfgDkESCeaTYbVssEIgNkC2?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId = naeysWMfgDkESCeaTYbVssEIgNkC3?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					for (int i = 0; i < wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps.Count; i++)
					{
						tKRieKmsRSTRWOHRHdkTyXnrexHP tKRieKmsRSTRWOHRHdkTyXnrexHP2 = new tKRieKmsRSTRWOHRHdkTyXnrexHP();
						tKRieKmsRSTRWOHRHdkTyXnrexHP2.bXJUnzvxVUgPzLhrFLxHRwFGuPxL = wZczgsTjByfIeelDprtdXSuPyCLbA2;
						tKRieKmsRSTRWOHRHdkTyXnrexHP2.YLJbohgdlHESdLrwdXTReYVqfJdf = tKRieKmsRSTRWOHRHdkTyXnrexHP2.bXJUnzvxVUgPzLhrFLxHRwFGuPxL.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps[i];
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC4 = RVBecluoohFyYctQAGZTxUUNpZRKA.PPqHGhArjGsRvAFQxCaHuyxdMDDM.Find(tKRieKmsRSTRWOHRHdkTyXnrexHP2.HmDFYTXHpFaUtQkkqQmuTfWWrszI);
						tKRieKmsRSTRWOHRHdkTyXnrexHP2.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId = naeysWMfgDkESCeaTYbVssEIgNkC4?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
						tKRieKmsRSTRWOHRHdkTyXnrexHP2.YLJbohgdlHESdLrwdXTReYVqfJdf._actionCategoryId = ((RVBecluoohFyYctQAGZTxUUNpZRKA.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.GetActionById(tKRieKmsRSTRWOHRHdkTyXnrexHP2.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId) != null) ? RVBecluoohFyYctQAGZTxUUNpZRKA.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.GetActionById(tKRieKmsRSTRWOHRHdkTyXnrexHP2.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (wZczgsTjByfIeelDprtdXSuPyCLbA2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						controllerMap_Editor = wZczgsTjByfIeelDprtdXSuPyCLbA2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.TWqnNBQIEfuJUZaWDVBdhGrgBIyw;
						FlvdJyYhDrWEcQVBPTNtHIlHoKmt(controllerMap_Editor.actionElementMaps, wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA = controllerMap_Editor2;
					}
					else
					{
						RVBecluoohFyYctQAGZTxUUNpZRKA.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.CreateJoystickMap(wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId, wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA.hardwareGuid, wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId);
						controllerMap_Editor = wZczgsTjByfIeelDprtdXSuPyCLbA2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[wZczgsTjByfIeelDprtdXSuPyCLbA2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA.id = controllerMap_Editor.id;
					int index = wZczgsTjByfIeelDprtdXSuPyCLbA2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(controllerMap_Editor);
					wZczgsTjByfIeelDprtdXSuPyCLbA2.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA;
					return wZczgsTjByfIeelDprtdXSuPyCLbA2.FqefGyTnmogMCBmJVkgZDrphAUbeA;
				}
			}

			private sealed class EnScWmMdzKJFShMwNFviIoMIaEar
			{
				public ControllerMap_Editor yMxlTPVDIQhbwEFgwysEQZOQcWuo;

				public Predicate<naeysWMfgDkESCeaTYbVssEIgNkC> CchmEndRdCaEkifeccGyvXqvoPXO;

				public Predicate<naeysWMfgDkESCeaTYbVssEIgNkC> xDbITWIbvNiIjcDbECUApWflGPlKB;

				internal bool OoXTchZcWbCSwdEBRfedhwhZdOeY(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.tSPdAcroqZjcPqEvARGyLeBpUxNS == yMxlTPVDIQhbwEFgwysEQZOQcWuo.categoryId;
				}

				internal bool syVesNsWlJukOhsAhsQkCwUMKaQQ(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.tSPdAcroqZjcPqEvARGyLeBpUxNS == yMxlTPVDIQhbwEFgwysEQZOQcWuo.layoutId;
				}
			}

			private sealed class wZczgsTjByfIeelDprtdXSuPyCLbA
			{
				public COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMap_Editor> ONbUGVygaIdiSjlJgQAtVcNacpEbA;

				public ControllerMap_Editor FqefGyTnmogMCBmJVkgZDrphAUbeA;

				internal bool oVuGTcdxkPBlYHHrFcnbYUNMxAan(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId;
				}

				internal bool heoXWeLgtMYcUgtQbdBpJWyjkxRB(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId;
				}
			}

			private sealed class tKRieKmsRSTRWOHRHdkTyXnrexHP
			{
				public ActionElementMap YLJbohgdlHESdLrwdXTReYVqfJdf;

				public wZczgsTjByfIeelDprtdXSuPyCLbA bXJUnzvxVUgPzLhrFLxHRwFGuPxL;

				internal bool HmDFYTXHpFaUtQkkqQmuTfWWrszI(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(bXJUnzvxVUgPzLhrFLxHRwFGuPxL.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == YLJbohgdlHESdLrwdXTReYVqfJdf._actionId;
				}
			}

			private sealed class cQpReCgmFFjmhJZFmMZvTPcRfYiDb
			{
				public List<naeysWMfgDkESCeaTYbVssEIgNkC> gtUPcNngmINQuYkUuFlZeYhYBlmHb;

				public MtqLPYjleoyKTNbJwvQWqyzwbWBN LxJCmlSAMaCeafGiqCrUhcsSBfRMA;

				internal int aNHrXcUOZCglRmaPheLmtpibLZfJ(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					MsqUEUffZNOiEsqCkwivqKXkHawn msqUEUffZNOiEsqCkwivqKXkHawn = new MsqUEUffZNOiEsqCkwivqKXkHawn();
					msqUEUffZNOiEsqCkwivqKXkHawn.yMxlTPVDIQhbwEFgwysEQZOQcWuo = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = LxJCmlSAMaCeafGiqCrUhcsSBfRMA.ZQIKkxhUpImtGuwviXNuiBQxSRqE.Find(msqUEUffZNOiEsqCkwivqKXkHawn.xAMHRfrYEmLHXGrUJvZLlicHLSFC);
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = LxJCmlSAMaCeafGiqCrUhcsSBfRMA.ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(msqUEUffZNOiEsqCkwivqKXkHawn.tzNYlPWeruPUiuhgWTfzElqNWrsp);
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC4 = gtUPcNngmINQuYkUuFlZeYhYBlmHb.Find(msqUEUffZNOiEsqCkwivqKXkHawn.KqLCDQEGAhHBLnHsqGHLVNTaqHQrA);
						if (naeysWMfgDkESCeaTYbVssEIgNkC2 != null && naeysWMfgDkESCeaTYbVssEIgNkC2.SjEjFwwGNljwQGLGXgFgUQHUHziX == P_1[i].customControllerUid && naeysWMfgDkESCeaTYbVssEIgNkC3 != null && naeysWMfgDkESCeaTYbVssEIgNkC3.SjEjFwwGNljwQGLGXgFgUQHUHziX == P_1[i].categoryId && naeysWMfgDkESCeaTYbVssEIgNkC4 != null && naeysWMfgDkESCeaTYbVssEIgNkC4.SjEjFwwGNljwQGLGXgFgUQHUHziX == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor DGKqLdlmWinreIUWbBTUjxNlhAqy(COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMap_Editor> P_0)
				{
					LSIbxUBmVAZiAESCXMjKZIUfehMl lSIbxUBmVAZiAESCXMjKZIUfehMl = new LSIbxUBmVAZiAESCXMjKZIUfehMl();
					lSIbxUBmVAZiAESCXMjKZIUfehMl.ONbUGVygaIdiSjlJgQAtVcNacpEbA = P_0;
					lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA = JsonTools.Clone(lSIbxUBmVAZiAESCXMjKZIUfehMl.ONbUGVygaIdiSjlJgQAtVcNacpEbA.RmOoKpupDqaCsgEWZYwNAvRuupFG);
					naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = LxJCmlSAMaCeafGiqCrUhcsSBfRMA.ZQIKkxhUpImtGuwviXNuiBQxSRqE.Find(lSIbxUBmVAZiAESCXMjKZIUfehMl.NkcYqrzmZYaRcTEvNiiJUSGdebZt);
					naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC3 = LxJCmlSAMaCeafGiqCrUhcsSBfRMA.ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(lSIbxUBmVAZiAESCXMjKZIUfehMl.jrBWTpTllNVBjZTeozBGloAJVKcg);
					naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC4 = gtUPcNngmINQuYkUuFlZeYhYBlmHb.Find(lSIbxUBmVAZiAESCXMjKZIUfehMl.ZdkPHvzPZSBtBuVCjQeEwtjpnFze);
					lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA.customControllerUid = naeysWMfgDkESCeaTYbVssEIgNkC2?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId = naeysWMfgDkESCeaTYbVssEIgNkC3?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId = naeysWMfgDkESCeaTYbVssEIgNkC4?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					for (int i = 0; i < lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps.Count; i++)
					{
						TPbgUTfYsjqxinNUilGzFmJBlBOyB tPbgUTfYsjqxinNUilGzFmJBlBOyB = new TPbgUTfYsjqxinNUilGzFmJBlBOyB();
						tPbgUTfYsjqxinNUilGzFmJBlBOyB.jlsDoqgVqsqDDzbtMoIFBWguxsvp = lSIbxUBmVAZiAESCXMjKZIUfehMl;
						tPbgUTfYsjqxinNUilGzFmJBlBOyB.YLJbohgdlHESdLrwdXTReYVqfJdf = tPbgUTfYsjqxinNUilGzFmJBlBOyB.jlsDoqgVqsqDDzbtMoIFBWguxsvp.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps[i];
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC5 = LxJCmlSAMaCeafGiqCrUhcsSBfRMA.PPqHGhArjGsRvAFQxCaHuyxdMDDM.Find(tPbgUTfYsjqxinNUilGzFmJBlBOyB.hTQjyXfncCEqgKkqhLznaJeDkBC);
						tPbgUTfYsjqxinNUilGzFmJBlBOyB.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId = naeysWMfgDkESCeaTYbVssEIgNkC5?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
						tPbgUTfYsjqxinNUilGzFmJBlBOyB.YLJbohgdlHESdLrwdXTReYVqfJdf._actionCategoryId = ((LxJCmlSAMaCeafGiqCrUhcsSBfRMA.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.GetActionById(tPbgUTfYsjqxinNUilGzFmJBlBOyB.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId) != null) ? LxJCmlSAMaCeafGiqCrUhcsSBfRMA.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.GetActionById(tPbgUTfYsjqxinNUilGzFmJBlBOyB.YLJbohgdlHESdLrwdXTReYVqfJdf._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (lSIbxUBmVAZiAESCXMjKZIUfehMl.ONbUGVygaIdiSjlJgQAtVcNacpEbA.xcvOrTYbmmVmlbUMmsexGVgGGvFJ)
					{
						controllerMap_Editor = lSIbxUBmVAZiAESCXMjKZIUfehMl.ONbUGVygaIdiSjlJgQAtVcNacpEbA.SFKYdjydKMbVRuEXRAxcVuAsVtbc;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.ifXUqFvKtxQoMkANTguFgauFlaGI;
						FlvdJyYhDrWEcQVBPTNtHIlHoKmt(controllerMap_Editor.actionElementMaps, lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA = controllerMap_Editor2;
					}
					else
					{
						LxJCmlSAMaCeafGiqCrUhcsSBfRMA.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.CreateCustomControllerMap(lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId, lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA.customControllerUid, lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId);
						controllerMap_Editor = lSIbxUBmVAZiAESCXMjKZIUfehMl.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[lSIbxUBmVAZiAESCXMjKZIUfehMl.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.Count - 1];
					}
					lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA.id = controllerMap_Editor.id;
					int index = lSIbxUBmVAZiAESCXMjKZIUfehMl.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM.IndexOf(controllerMap_Editor);
					lSIbxUBmVAZiAESCXMjKZIUfehMl.ONbUGVygaIdiSjlJgQAtVcNacpEbA.arWJGMXUoMCDxFIjfvIIOBKhLsIM[index] = lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA;
					return lSIbxUBmVAZiAESCXMjKZIUfehMl.FqefGyTnmogMCBmJVkgZDrphAUbeA;
				}
			}

			private sealed class OUXbFkaWkfBgBFSSEcoCtgnLIzCrB
			{
				public int tSPdAcroqZjcPqEvARGyLeBpUxNS;

				internal bool pDSxeHBHdbTwWrFWETSfkmoSTgOp(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.tSPdAcroqZjcPqEvARGyLeBpUxNS == tSPdAcroqZjcPqEvARGyLeBpUxNS;
				}
			}

			private sealed class MsqUEUffZNOiEsqCkwivqKXkHawn
			{
				public ControllerMap_Editor yMxlTPVDIQhbwEFgwysEQZOQcWuo;

				public Predicate<naeysWMfgDkESCeaTYbVssEIgNkC> CkEGvbItgZrAsacIWuGBMQVclZWq;

				public Predicate<naeysWMfgDkESCeaTYbVssEIgNkC> uGabsXDWBqxoZcIEQWJZQBdVVEjM;

				public Predicate<naeysWMfgDkESCeaTYbVssEIgNkC> gFBujmvsYkAytbOjqCpHtyuqtXik;

				internal bool xAMHRfrYEmLHXGrUJvZLlicHLSFC(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.tSPdAcroqZjcPqEvARGyLeBpUxNS == yMxlTPVDIQhbwEFgwysEQZOQcWuo.customControllerUid;
				}

				internal bool tzNYlPWeruPUiuhgWTfzElqNWrsp(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.tSPdAcroqZjcPqEvARGyLeBpUxNS == yMxlTPVDIQhbwEFgwysEQZOQcWuo.categoryId;
				}

				internal bool KqLCDQEGAhHBLnHsqGHLVNTaqHQrA(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.tSPdAcroqZjcPqEvARGyLeBpUxNS == yMxlTPVDIQhbwEFgwysEQZOQcWuo.layoutId;
				}
			}

			private sealed class LSIbxUBmVAZiAESCXMjKZIUfehMl
			{
				public COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMap_Editor> ONbUGVygaIdiSjlJgQAtVcNacpEbA;

				public ControllerMap_Editor FqefGyTnmogMCBmJVkgZDrphAUbeA;

				internal bool NkcYqrzmZYaRcTEvNiiJUSGdebZt(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == FqefGyTnmogMCBmJVkgZDrphAUbeA.customControllerUid;
				}

				internal bool jrBWTpTllNVBjZTeozBGloAJVKcg(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == FqefGyTnmogMCBmJVkgZDrphAUbeA.categoryId;
				}

				internal bool ZdkPHvzPZSBtBuVCjQeEwtjpnFze(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == FqefGyTnmogMCBmJVkgZDrphAUbeA.layoutId;
				}
			}

			private sealed class TPbgUTfYsjqxinNUilGzFmJBlBOyB
			{
				public ActionElementMap YLJbohgdlHESdLrwdXTReYVqfJdf;

				public LSIbxUBmVAZiAESCXMjKZIUfehMl jlsDoqgVqsqDDzbtMoIFBWguxsvp;

				internal bool hTQjyXfncCEqgKkqhLznaJeDkBC(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(jlsDoqgVqsqDDzbtMoIFBWguxsvp.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == YLJbohgdlHESdLrwdXTReYVqfJdf._actionId;
				}
			}

			private sealed class HuMKznqQlRKeauEkgdBjKZAAhMrqA
			{
				public COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMapLayoutManager_RuleSet_Editor> ONbUGVygaIdiSjlJgQAtVcNacpEbA;
			}

			private sealed class hksURpqVSUiPzUrGiiLfnLaYAJrY
			{
				public int mLQhHiRLebgeJPwOwxiMFAHuXWao;

				public HuMKznqQlRKeauEkgdBjKZAAhMrqA krwBwNIFJeWSnjxOvAxPanVBByDc;

				internal bool FAPfoIKvTTZoaOXVwvnmTisCoNnib(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(krwBwNIFJeWSnjxOvAxPanVBByDc.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == mLQhHiRLebgeJPwOwxiMFAHuXWao;
				}
			}

			private sealed class WBVddsbPkyICHxMvYUedXjdnnggF
			{
				public int mLQhHiRLebgeJPwOwxiMFAHuXWao;

				public HuMKznqQlRKeauEkgdBjKZAAhMrqA oVIrsHWonOBqLIvRHMYTghobDJngc;

				internal bool YPoWwDPQrvpXVtcTuXkRnEGWQdii(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(oVIrsHWonOBqLIvRHMYTghobDJngc.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == mLQhHiRLebgeJPwOwxiMFAHuXWao;
				}
			}

			private sealed class FDCSZoFwbUVLoibpBOMjiqsMjfeT
			{
				public int mLQhHiRLebgeJPwOwxiMFAHuXWao;

				public HuMKznqQlRKeauEkgdBjKZAAhMrqA ZUpNrZznCjWIRtHDSILnhuGYdYtPA;

				internal bool bvXbESoVHdfvSlAUpfAZDywOBUlR(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(ZUpNrZznCjWIRtHDSILnhuGYdYtPA.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == mLQhHiRLebgeJPwOwxiMFAHuXWao;
				}
			}

			private sealed class MFpQWWvnmNzyXiBPoLAXXRJYPVy
			{
				public COlXJLLTpYjFgrOQKhipKOgkSfLb<ControllerMapEnabler_RuleSet_Editor> ONbUGVygaIdiSjlJgQAtVcNacpEbA;
			}

			private sealed class UNXlJvFEFIJjDEnqzweJQfXBckiP
			{
				public int mLQhHiRLebgeJPwOwxiMFAHuXWao;

				public MFpQWWvnmNzyXiBPoLAXXRJYPVy JTrQfGBDXyKtzqdJoaVHhVyRTcxi;

				internal bool HUNPLNdlKdDIzopVCNvijkiQCKGx(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.wBgVECvNnnPzuAKlDGDoAWwKEEhT(JTrQfGBDXyKtzqdJoaVHhVyRTcxi.ONbUGVygaIdiSjlJgQAtVcNacpEbA.PWFxOJmPgKpqjyyCqfPOnHWAOauV) == mLQhHiRLebgeJPwOwxiMFAHuXWao;
				}
			}

			private sealed class HudzXUiRsZcNYXnJQHzXuSiEuhDq<_0001> where _0001 : class
			{
				public Func<_0001, int> ckpkGohbkvQrTkMXAycIHIwCClSA;
			}

			private sealed class onZbzzeykPDjfznEofCLdWzOITRP<_0001> where _0001 : class
			{
				public _0001 FqefGyTnmogMCBmJVkgZDrphAUbeA;

				public HudzXUiRsZcNYXnJQHzXuSiEuhDq<_0001> tumGMqEalshGxISRJirUAUNHyfMPb;

				internal bool GJeAJdILuLVOccUfhIjNzESyPANE(naeysWMfgDkESCeaTYbVssEIgNkC P_0)
				{
					return P_0.SjEjFwwGNljwQGLGXgFgUQHUHziX == tumGMqEalshGxISRJirUAUNHyfMPb.ckpkGohbkvQrTkMXAycIHIwCClSA(FqefGyTnmogMCBmJVkgZDrphAUbeA);
				}
			}

			public static UserData vZqRRYviGPiQjlKBnPeuANBeHCxEA(UserData P_0, UserData P_1, bool P_2)
			{
				MtqLPYjleoyKTNbJwvQWqyzwbWBN mtqLPYjleoyKTNbJwvQWqyzwbWBN = new MtqLPYjleoyKTNbJwvQWqyzwbWBN();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA = (P_2 ? P_0 : new UserData(false));
				if (P_1 != null)
				{
					mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.configVars = JsonTools.Clone(P_1.configVars);
				}
				else
				{
					mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.configVars = JsonTools.Clone(P_0.configVars);
				}
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.RUqquvLLtZDzGxLVnXxWOupKTRjQ = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Action Category", P_0.actionCategories, P_1?.actionCategories, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.actionCategories, P_2, mtqLPYjleoyKTNbJwvQWqyzwbWBN.RUqquvLLtZDzGxLVnXxWOupKTRjQ, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.fVBffgzqCuHWCcAuYfGxXGObFruwA, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.ssysioHrvdnBJDimEjFateVzdBUt, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.XbDzAlZSochJICAdDIoVsPlQziaF, mtqLPYjleoyKTNbJwvQWqyzwbWBN.CsLgFVcnNAdXkdXQcJxDaZfOKPUlb);
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.NuZDIjDUealLMjwWsfizLRKzIPFxA = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.inputBehaviors, P_2, mtqLPYjleoyKTNbJwvQWqyzwbWBN.NuZDIjDUealLMjwWsfizLRKzIPFxA, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.fkjrkawcwlMwCswfCxDYHFflqMKi, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.RUJwahIoaIGSsCKrGSlUmogfWGAN, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.ZJGvTDUiCJWEQQDdyDjlAlnTXoHA, mtqLPYjleoyKTNbJwvQWqyzwbWBN.BTbAoChaCamklaXtaWCGsYDKsbRNb);
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.PPqHGhArjGsRvAFQxCaHuyxdMDDM = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Action", P_0.actions, P_1?.actions, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.actions, P_2, mtqLPYjleoyKTNbJwvQWqyzwbWBN.PPqHGhArjGsRvAFQxCaHuyxdMDDM, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.HuDNVyJwbjcqHlUwdotHncfvsCTM, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.gSLqBRcgfMgbcSlqlGqAESuBULntA, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.BxGSIdSotcLBhkFcicHueIlBrsMPA, mtqLPYjleoyKTNbJwvQWqyzwbWBN.QYvJJVOAhWekxlBXkNkwrfEljokBA);
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.ussiyYSPRqjoHtxOoVPnKsFxlheI = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				lFZYoaiGvVADFkbDkIehOCudYqth lFZYoaiGvVADFkbDkIehOCudYqth2 = new lFZYoaiGvVADFkbDkIehOCudYqth();
				lFZYoaiGvVADFkbDkIehOCudYqth2.tumGMqEalshGxISRJirUAUNHyfMPb = mtqLPYjleoyKTNbJwvQWqyzwbWBN;
				lFZYoaiGvVADFkbDkIehOCudYqth2.nlwiyfnqsCbETyMciTXehwLnaNtd = new List<int>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Map Category", P_0.mapCategories, P_1?.mapCategories, lFZYoaiGvVADFkbDkIehOCudYqth2.tumGMqEalshGxISRJirUAUNHyfMPb.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.mapCategories, P_2, lFZYoaiGvVADFkbDkIehOCudYqth2.tumGMqEalshGxISRJirUAUNHyfMPb.ussiyYSPRqjoHtxOoVPnKsFxlheI, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.KbQGFJpVZcuFDsumNCYsFHDijuVJ, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.uaYMOtMTOMwBvKaYaMSfNrZUeNDeA, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.GZQiSjBCcouzXGWhNFlEBbaZvskK, lFZYoaiGvVADFkbDkIehOCudYqth2.WmeuzrRcqtCijFavgzxfoCAWwOOvA);
				for (int i = 0; i < lFZYoaiGvVADFkbDkIehOCudYqth2.nlwiyfnqsCbETyMciTXehwLnaNtd.Count; i++)
				{
					int index = lFZYoaiGvVADFkbDkIehOCudYqth2.nlwiyfnqsCbETyMciTXehwLnaNtd[i];
					InputMapCategory inputMapCategory = lFZYoaiGvVADFkbDkIehOCudYqth2.tumGMqEalshGxISRJirUAUNHyfMPb.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.mapCategories[index];
					for (int j = 0; j < inputMapCategory.PWekGiBsxoKNDMYZSDuzyDDgagy.Count; j++)
					{
						OUXbFkaWkfBgBFSSEcoCtgnLIzCrB oUXbFkaWkfBgBFSSEcoCtgnLIzCrB = new OUXbFkaWkfBgBFSSEcoCtgnLIzCrB();
						oUXbFkaWkfBgBFSSEcoCtgnLIzCrB.tSPdAcroqZjcPqEvARGyLeBpUxNS = inputMapCategory.PWekGiBsxoKNDMYZSDuzyDDgagy[j];
						naeysWMfgDkESCeaTYbVssEIgNkC naeysWMfgDkESCeaTYbVssEIgNkC2 = lFZYoaiGvVADFkbDkIehOCudYqth2.tumGMqEalshGxISRJirUAUNHyfMPb.ussiyYSPRqjoHtxOoVPnKsFxlheI.Find(oUXbFkaWkfBgBFSSEcoCtgnLIzCrB.pDSxeHBHdbTwWrFWETSfkmoSTgOp);
						inputMapCategory.PWekGiBsxoKNDMYZSDuzyDDgagy[j] = naeysWMfgDkESCeaTYbVssEIgNkC2?.SjEjFwwGNljwQGLGXgFgUQHUHziX ?? (-1);
					}
				}
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.MwWLJQNRaVxrAUeMPBvoLHlVrWwt = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.keyboardLayouts, P_2, mtqLPYjleoyKTNbJwvQWqyzwbWBN.MwWLJQNRaVxrAUeMPBvoLHlVrWwt, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.iriOKkTkugcEeIyUPEzwrLLXktum, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.YtrshpwtKQGJSrYFlRnkprdBBRdb, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.qiDymroVfSmwvTylUfvROJNlzgCB, mtqLPYjleoyKTNbJwvQWqyzwbWBN.MAztabAgodVhCTMBOSDxrXexOTDI);
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.WCtYBmkubRRJSsoEzjhMdgTVpKOy = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.mouseLayouts, P_2, mtqLPYjleoyKTNbJwvQWqyzwbWBN.WCtYBmkubRRJSsoEzjhMdgTVpKOy, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.FEgKFmLuGkHkNbGwIPkIVOlKTkxw, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.IzgFVPTCwGkDifLlEXDtZTxyxGgj, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.yDSntdrXykjUmdRhcNfyHGPnSqLt, mtqLPYjleoyKTNbJwvQWqyzwbWBN.ruxXLejwWmHnuxKrbcCXjKdSaJtF);
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.ecCTkVPxWTgwUGdQOPrhsgSuUkgq = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.joystickLayouts, P_2, mtqLPYjleoyKTNbJwvQWqyzwbWBN.ecCTkVPxWTgwUGdQOPrhsgSuUkgq, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.MEKsevlELiOCWYfDRRNCJdoJfoXcA, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.clfEPeSusAXoQFqWCJPgocKfGMNv, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.eQWHNsZKfWQblXPbeoEgdyhuFVSP, mtqLPYjleoyKTNbJwvQWqyzwbWBN.RutmZBlscJJrolMEFLdTIVQSqPdW);
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.dYZlMEMoVHKhKFLRYThxkRItzwek = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.customControllerLayouts, P_2, mtqLPYjleoyKTNbJwvQWqyzwbWBN.dYZlMEMoVHKhKFLRYThxkRItzwek, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.lzyKLeefcUdXpSTumzDqlnscgBBfA, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.WKCOPTKENKdaCAETNwbOCbUyXviP, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.ZHvplYtyOIWTHbSrOKZXxXmPiFgc, mtqLPYjleoyKTNbJwvQWqyzwbWBN.SlXvAcxCuiJJEtJFtxBlAklCGniaA);
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.vAjCRwTtAPmcoQCNkAxiBIXHVjsW = mtqLPYjleoyKTNbJwvQWqyzwbWBN.uzHYwttavPugdZDDdaFDRdyfCaDn;
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.ZQIKkxhUpImtGuwviXNuiBQxSRqE = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Custom Controller", P_0.customControllers, P_1?.customControllers, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.customControllers, P_2, mtqLPYjleoyKTNbJwvQWqyzwbWBN.ZQIKkxhUpImtGuwviXNuiBQxSRqE, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.HEZVLxgJgWWfJLtLxfamdJEPQOPR, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.OfAVRjGqpqDQkwlONEJnEBqvGKDhA, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.dPoqgAPTdreAnpAQentYHNldCNvS, mtqLPYjleoyKTNbJwvQWqyzwbWBN.APwXdPgSRsMBWiqwxuSWmfoVfQnb);
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.CJmRvtXkQKsdjgmKLAcjDAKCeEkV = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.controllerMapLayoutManagerRuleSets, P_2, mtqLPYjleoyKTNbJwvQWqyzwbWBN.CJmRvtXkQKsdjgmKLAcjDAKCeEkV, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.klfLqgQhiTiFDErZFtPqfkZrwGbgA, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.yFxOFvuQBonWFoCpWgoAhSfKEiGd, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.fTBrqFxKImgEIIoFLYVbnrakukzp, mtqLPYjleoyKTNbJwvQWqyzwbWBN.krKmvZwdnNLMQZHGgcKllaVeoHkF);
				mtqLPYjleoyKTNbJwvQWqyzwbWBN.JsGNpsNCEeLeEurtPHnqMIyMUTgI = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.controllerMapEnablerRuleSets, P_2, mtqLPYjleoyKTNbJwvQWqyzwbWBN.JsGNpsNCEeLeEurtPHnqMIyMUTgI, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.JMlPZRCjMTexTUtxtXGaNiRjjXfS, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.maUDCNXrrnXjsqoPEeEBssFTIGqy, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.LuUwaDwsKzCydfNsfZudhDCqlDVVA, mtqLPYjleoyKTNbJwvQWqyzwbWBN.GkFVPeSCZseNjkxPQZHXNVRPKQnI);
				List<naeysWMfgDkESCeaTYbVssEIgNkC> list = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Player", P_0.players, P_1?.players, mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.players, P_2, list, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.KubIVKNpDpNJyLyMPNJQRnzURrQE, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.DAbpzoECUOxBPdNttahCKJVxDTWn, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.RTXKeqpAaSeJpsrFKKiVRhlDYBNB, mtqLPYjleoyKTNbJwvQWqyzwbWBN.mFpFbkhkmtxSJCWrNiHIrZVKCEYQ);
				List<naeysWMfgDkESCeaTYbVssEIgNkC> list2 = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				jVZMwDHQLZFNjbeYWPMcwxqpSdFC jVZMwDHQLZFNjbeYWPMcwxqpSdFC2 = new jVZMwDHQLZFNjbeYWPMcwxqpSdFC();
				jVZMwDHQLZFNjbeYWPMcwxqpSdFC2.BqGZidPkKujaxhyjjmYBYrFWKDRI = mtqLPYjleoyKTNbJwvQWqyzwbWBN;
				jVZMwDHQLZFNjbeYWPMcwxqpSdFC2.gtUPcNngmINQuYkUuFlZeYhYBlmHb = jVZMwDHQLZFNjbeYWPMcwxqpSdFC2.BqGZidPkKujaxhyjjmYBYrFWKDRI.MwWLJQNRaVxrAUeMPBvoLHlVrWwt;
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, jVZMwDHQLZFNjbeYWPMcwxqpSdFC2.BqGZidPkKujaxhyjjmYBYrFWKDRI.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.keyboardMaps, P_2, list2, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.eZSvlLMzAIVOsUWrVrHYWDqlKiFe, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.DJHYAxoTNgBdqLTWfADCoWiowuJT, jVZMwDHQLZFNjbeYWPMcwxqpSdFC2.yURYSGnQDVJzBcOvVirmmljBOhoT, jVZMwDHQLZFNjbeYWPMcwxqpSdFC2.cRTGWJbzzkmuBSZZlnsIMMTWerzd);
				List<naeysWMfgDkESCeaTYbVssEIgNkC> list3 = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				YljftjDhYKDJXDSkVvPgDIwIVEjfb yljftjDhYKDJXDSkVvPgDIwIVEjfb = new YljftjDhYKDJXDSkVvPgDIwIVEjfb();
				yljftjDhYKDJXDSkVvPgDIwIVEjfb.egIQaaqJvXQLtjekMNqHYqSJAUSM = mtqLPYjleoyKTNbJwvQWqyzwbWBN;
				yljftjDhYKDJXDSkVvPgDIwIVEjfb.gtUPcNngmINQuYkUuFlZeYhYBlmHb = yljftjDhYKDJXDSkVvPgDIwIVEjfb.egIQaaqJvXQLtjekMNqHYqSJAUSM.WCtYBmkubRRJSsoEzjhMdgTVpKOy;
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, yljftjDhYKDJXDSkVvPgDIwIVEjfb.egIQaaqJvXQLtjekMNqHYqSJAUSM.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.mouseMaps, P_2, list3, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.vOVfSSowhbNHHadEokFkmMnznVTR, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.cWYIgSAzpMJvcmdmaADEFTvMkgmfb, yljftjDhYKDJXDSkVvPgDIwIVEjfb.JhswkKsPLilFdTtKhqfSWAepcLHt, yljftjDhYKDJXDSkVvPgDIwIVEjfb.RwnXobjCmgMNUnUSOEDbIcUCCZWL);
				List<naeysWMfgDkESCeaTYbVssEIgNkC> list4 = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				YEgaotVGdOymiSBThPVMEyohwjUC yEgaotVGdOymiSBThPVMEyohwjUC = new YEgaotVGdOymiSBThPVMEyohwjUC();
				yEgaotVGdOymiSBThPVMEyohwjUC.RVBecluoohFyYctQAGZTxUUNpZRKA = mtqLPYjleoyKTNbJwvQWqyzwbWBN;
				yEgaotVGdOymiSBThPVMEyohwjUC.gtUPcNngmINQuYkUuFlZeYhYBlmHb = yEgaotVGdOymiSBThPVMEyohwjUC.RVBecluoohFyYctQAGZTxUUNpZRKA.ecCTkVPxWTgwUGdQOPrhsgSuUkgq;
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, yEgaotVGdOymiSBThPVMEyohwjUC.RVBecluoohFyYctQAGZTxUUNpZRKA.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.joystickMaps, P_2, list4, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.vePKqoBmrcGhqUZqAhJWkgduimbBA, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.nmtttQzwujxuZZxumEcbRSMZxBxj, yEgaotVGdOymiSBThPVMEyohwjUC.fQoPLZGVvPioDGOYWtMcKVLMIeVd, yEgaotVGdOymiSBThPVMEyohwjUC.VlmpRhwiaGAbSMMLZDtcYWgbQhDo);
				List<naeysWMfgDkESCeaTYbVssEIgNkC> list5 = new List<naeysWMfgDkESCeaTYbVssEIgNkC>();
				cQpReCgmFFjmhJZFmMZvTPcRfYiDb cQpReCgmFFjmhJZFmMZvTPcRfYiDb2 = new cQpReCgmFFjmhJZFmMZvTPcRfYiDb();
				cQpReCgmFFjmhJZFmMZvTPcRfYiDb2.LxJCmlSAMaCeafGiqCrUhcsSBfRMA = mtqLPYjleoyKTNbJwvQWqyzwbWBN;
				cQpReCgmFFjmhJZFmMZvTPcRfYiDb2.gtUPcNngmINQuYkUuFlZeYhYBlmHb = cQpReCgmFFjmhJZFmMZvTPcRfYiDb2.LxJCmlSAMaCeafGiqCrUhcsSBfRMA.dYZlMEMoVHKhKFLRYThxkRItzwek;
				gvgboVPMeQvpTRMMBMcrRsRJHEHL("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, cQpReCgmFFjmhJZFmMZvTPcRfYiDb2.LxJCmlSAMaCeafGiqCrUhcsSBfRMA.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA.customControllerMaps, P_2, list5, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.avchtMKaIFNWwdEdeamxKMSNQcCLb, oOVkNZXHcqSDjwPQagCySEDwaPbEA._003C_003E9.RtTuLJqSANzJTShUiQceBigiMFah, cQpReCgmFFjmhJZFmMZvTPcRfYiDb2.aNHrXcUOZCglRmaPheLmtpibLZfJ, cQpReCgmFFjmhJZFmMZvTPcRfYiDb2.DGKqLdlmWinreIUWbBTUjxNlhAqy);
				return mtqLPYjleoyKTNbJwvQWqyzwbWBN.IFDDKeJIEmeYGaoGSTsIfyPWqzDbA;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void yaIKZhTiBUmSNqRdpOTAlLFxNfdp(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void FlvdJyYhDrWEcQVBPTNtHIlHoKmt<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
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

			private static void gvgboVPMeQvpTRMMBMcrRsRJHEHL<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<naeysWMfgDkESCeaTYbVssEIgNkC> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<COlXJLLTpYjFgrOQKhipKOgkSfLb<_0001>, _0001> P_9) where _0001 : class
			{
				HudzXUiRsZcNYXnJQHzXuSiEuhDq<_0001> hudzXUiRsZcNYXnJQHzXuSiEuhDq = new HudzXUiRsZcNYXnJQHzXuSiEuhDq<_0001>();
				hudzXUiRsZcNYXnJQHzXuSiEuhDq.ckpkGohbkvQrTkMXAycIHIwCClSA = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					_0001 val = P_1[i];
					if (P_4)
					{
						P_5.Add(new naeysWMfgDkESCeaTYbVssEIgNkC(hudzXUiRsZcNYXnJQHzXuSiEuhDq.ckpkGohbkvQrTkMXAycIHIwCClSA(val), -1, hudzXUiRsZcNYXnJQHzXuSiEuhDq.ckpkGohbkvQrTkMXAycIHIwCClSA(val)));
						continue;
					}
					_0001 arg = P_9(new COlXJLLTpYjFgrOQKhipKOgkSfLb<_0001>(val, null, naeysWMfgDkESCeaTYbVssEIgNkC.XlJHxfRmRgfLLLIPvOHDAqHpQdXd.origId, P_3, false));
					P_5.Add(new naeysWMfgDkESCeaTYbVssEIgNkC(hudzXUiRsZcNYXnJQHzXuSiEuhDq.ckpkGohbkvQrTkMXAycIHIwCClSA(val), -1, hudzXUiRsZcNYXnJQHzXuSiEuhDq.ckpkGohbkvQrTkMXAycIHIwCClSA(arg)));
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
						onZbzzeykPDjfznEofCLdWzOITRP<_0001> onZbzzeykPDjfznEofCLdWzOITRP2 = new onZbzzeykPDjfznEofCLdWzOITRP<_0001>();
						onZbzzeykPDjfznEofCLdWzOITRP2.tumGMqEalshGxISRJirUAUNHyfMPb = hudzXUiRsZcNYXnJQHzXuSiEuhDq;
						_0001 val3 = P_3[num];
						onZbzzeykPDjfznEofCLdWzOITRP2.FqefGyTnmogMCBmJVkgZDrphAUbeA = P_9(new COlXJLLTpYjFgrOQKhipKOgkSfLb<_0001>(val2, val3, naeysWMfgDkESCeaTYbVssEIgNkC.XlJHxfRmRgfLLLIPvOHDAqHpQdXd.otherId, P_3, true));
						P_5.Find(onZbzzeykPDjfznEofCLdWzOITRP2.GJeAJdILuLVOccUfhIjNzESyPANE).tSPdAcroqZjcPqEvARGyLeBpUxNS = onZbzzeykPDjfznEofCLdWzOITRP2.tumGMqEalshGxISRJirUAUNHyfMPb.ckpkGohbkvQrTkMXAycIHIwCClSA(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						_0001 arg2 = P_9(new COlXJLLTpYjFgrOQKhipKOgkSfLb<_0001>(val2, null, naeysWMfgDkESCeaTYbVssEIgNkC.XlJHxfRmRgfLLLIPvOHDAqHpQdXd.otherId, P_3, false));
						P_5.Add(new naeysWMfgDkESCeaTYbVssEIgNkC(-1, hudzXUiRsZcNYXnJQHzXuSiEuhDq.ckpkGohbkvQrTkMXAycIHIwCClSA(val2), hudzXUiRsZcNYXnJQHzXuSiEuhDq.ckpkGohbkvQrTkMXAycIHIwCClSA(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}
		}

		[Serializable]
		private sealed class wicHmXkfiOHNToMhGtLoOUfZQNqe
		{
			public static readonly wicHmXkfiOHNToMhGtLoOUfZQNqe _003C_003E9 = new wicHmXkfiOHNToMhGtLoOUfZQNqe();

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__195_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__213_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__229_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__245_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__261_0;

			internal void NgYSsyPwknmarFWlTVlXqdbNXkZe(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void mMdEsqgrMVREIUfnbciXkahvCPZe(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void IzzdrapQKUTLFmDXmGNBGDokKoyIA(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void UMgqUsqTcRHuWbWBDpFkBkVEwsJV(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void YPfEUaumFmXaENjfvEavveAlrUBS(List<Player_Editor.Mapping> P_0, int P_1)
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

		private sealed class lOFDYnFgCfrYqVxqEwWPVKdXQEPL
		{
			public List<InputLayout> HTzDQCCHqejxnEHdtVLStAPmrwAF;

			internal int qqHtaRJqxiqcDooJAYEFrAbGGcNk(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				jzghBVWuvqxplKuTvWajYwdenjXd jzghBVWuvqxplKuTvWajYwdenjXd2 = new jzghBVWuvqxplKuTvWajYwdenjXd();
				jzghBVWuvqxplKuTvWajYwdenjXd2.VOqXZFpkfqxthtpirTSkjkUIXYWh = P_0;
				jzghBVWuvqxplKuTvWajYwdenjXd2.tHnucPZgaWBgGGxeQZvKhnVcDwSp = P_1;
				int num = HTzDQCCHqejxnEHdtVLStAPmrwAF.FindIndex(jzghBVWuvqxplKuTvWajYwdenjXd2.OuuKdnlcqrMKKGWKAjHJiAjmbcFv);
				int num2 = HTzDQCCHqejxnEHdtVLStAPmrwAF.FindIndex(jzghBVWuvqxplKuTvWajYwdenjXd2.lqXGsxRfRRirwIOsHmbBoVQVJCMj);
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

		private sealed class jzghBVWuvqxplKuTvWajYwdenjXd
		{
			public ControllerMap_Editor VOqXZFpkfqxthtpirTSkjkUIXYWh;

			public ControllerMap_Editor tHnucPZgaWBgGGxeQZvKhnVcDwSp;

			internal bool OuuKdnlcqrMKKGWKAjHJiAjmbcFv(InputLayout P_0)
			{
				return P_0.id == VOqXZFpkfqxthtpirTSkjkUIXYWh.id;
			}

			internal bool lqXGsxRfRRirwIOsHmbBoVQVJCMj(InputLayout P_0)
			{
				return P_0.id == tHnucPZgaWBgGGxeQZvKhnVcDwSp.id;
			}
		}

		private sealed class yWlgTkdIFNHGhQbalMiaYSisGFtS : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputCategory USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			private string hIsTTgMcJDwwbFwfjrcyfPezNUQC;

			public string SdneKSDMLwNqVBTPrwJYGNkjUDeS;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public yWlgTkdIFNHGhQbalMiaYSisGFtS(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_0098;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (hIsTTgMcJDwwbFwfjrcyfPezNUQC == null || hIsTTgMcJDwwbFwfjrcyfPezNUQC == string.Empty)
				{
					return false;
				}
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null)
				{
					return false;
				}
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_00a8;
				IL_00a8:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories.Count)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg].tag.Equals(hIsTTgMcJDwwbFwfjrcyfPezNUQC, StringComparison.OrdinalIgnoreCase))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg];
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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
				yWlgTkdIFNHGhQbalMiaYSisGFtS yWlgTkdIFNHGhQbalMiaYSisGFtS2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					yWlgTkdIFNHGhQbalMiaYSisGFtS2 = this;
				}
				else
				{
					yWlgTkdIFNHGhQbalMiaYSisGFtS2 = new yWlgTkdIFNHGhQbalMiaYSisGFtS(0);
					yWlgTkdIFNHGhQbalMiaYSisGFtS2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				yWlgTkdIFNHGhQbalMiaYSisGFtS2.hIsTTgMcJDwwbFwfjrcyfPezNUQC = SdneKSDMLwNqVBTPrwJYGNkjUDeS;
				return yWlgTkdIFNHGhQbalMiaYSisGFtS2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class pDXQDlFGSwndgmLZmhWNhgaXEDTv : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputAction USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private string hIsTTgMcJDwwbFwfjrcyfPezNUQC;

			public string SdneKSDMLwNqVBTPrwJYGNkjUDeS;

			private int AzjpTBfORLLkcEMtsUpzMFLQjkqbA;

			private int eolRghqutZOOIGqvOFTzJOGfYTsn;

			private InputCategory LNlTzosWHfJSlgBdZbNMgCOPRzYOA;

			private int GMqtCaMlQBCNVPqPhjaGBGDgwvTfA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public pDXQDlFGSwndgmLZmhWNhgaXEDTv(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_00fd;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actions == null || gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null)
				{
					return false;
				}
				if (hIsTTgMcJDwwbFwfjrcyfPezNUQC == null || hIsTTgMcJDwwbFwfjrcyfPezNUQC == string.Empty)
				{
					return false;
				}
				AzjpTBfORLLkcEMtsUpzMFLQjkqbA = gZXxEqHwrHYIyUJtInpLwgTukJaY.actions.Count;
				eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
				goto IL_0132;
				IL_0122:
				eolRghqutZOOIGqvOFTzJOGfYTsn++;
				goto IL_0132;
				IL_00fd:
				GMqtCaMlQBCNVPqPhjaGBGDgwvTfA++;
				goto IL_010d;
				IL_010d:
				if (GMqtCaMlQBCNVPqPhjaGBGDgwvTfA < AzjpTBfORLLkcEMtsUpzMFLQjkqbA)
				{
					if (LNlTzosWHfJSlgBdZbNMgCOPRzYOA.id == gZXxEqHwrHYIyUJtInpLwgTukJaY.actions[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA].categoryId)
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.actions[GMqtCaMlQBCNVPqPhjaGBGDgwvTfA];
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_00fd;
				}
				LNlTzosWHfJSlgBdZbNMgCOPRzYOA = null;
				goto IL_0122;
				IL_0132:
				if (eolRghqutZOOIGqvOFTzJOGfYTsn < gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories.Count)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories[eolRghqutZOOIGqvOFTzJOGfYTsn].tag.Equals(hIsTTgMcJDwwbFwfjrcyfPezNUQC, StringComparison.OrdinalIgnoreCase))
					{
						LNlTzosWHfJSlgBdZbNMgCOPRzYOA = gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories[eolRghqutZOOIGqvOFTzJOGfYTsn];
						GMqtCaMlQBCNVPqPhjaGBGDgwvTfA = 0;
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
				pDXQDlFGSwndgmLZmhWNhgaXEDTv pDXQDlFGSwndgmLZmhWNhgaXEDTv2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					pDXQDlFGSwndgmLZmhWNhgaXEDTv2 = this;
				}
				else
				{
					pDXQDlFGSwndgmLZmhWNhgaXEDTv2 = new pDXQDlFGSwndgmLZmhWNhgaXEDTv(0);
					pDXQDlFGSwndgmLZmhWNhgaXEDTv2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				pDXQDlFGSwndgmLZmhWNhgaXEDTv2.hIsTTgMcJDwwbFwfjrcyfPezNUQC = SdneKSDMLwNqVBTPrwJYGNkjUDeS;
				return pDXQDlFGSwndgmLZmhWNhgaXEDTv2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class BGeINzeKqECRRoBpanKdEednCtdX : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputAction USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private bool CjWVZeZcJyhVOGCFZLXmKlVwfVYKA;

			public bool OIgJIcPCbXGFHAFjMxiLYtrtKZuP;

			private int tfuONqHHaukqbwOzWbCAHLNaTcOq;

			public int ReqdoUDpdFtntvHXUspFdnTqlVgdb;

			private IEnumerator<int> otVuTclWHkLrdVIElDnnPoApusjv;

			private int eolRghqutZOOIGqvOFTzJOGfYTsn;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public BGeINzeKqECRRoBpanKdEednCtdX(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
				{
					try
					{
					}
					finally
					{
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actions == null || gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null)
						{
							return false;
						}
						if (CjWVZeZcJyhVOGCFZLXmKlVwfVYKA)
						{
							otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.SortedActionIdsInCategory(tfuONqHHaukqbwOzWbCAHLNaTcOq).GetEnumerator();
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
							goto IL_00a5;
						}
						eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
						goto IL_0123;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_00a5;
					case 2:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_0111;
						}
						IL_0123:
						if (eolRghqutZOOIGqvOFTzJOGfYTsn >= gZXxEqHwrHYIyUJtInpLwgTukJaY.actions.Count)
						{
							break;
						}
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actions[eolRghqutZOOIGqvOFTzJOGfYTsn].categoryId == tfuONqHHaukqbwOzWbCAHLNaTcOq)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.actions[eolRghqutZOOIGqvOFTzJOGfYTsn];
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
							return true;
						}
						goto IL_0111;
						IL_0111:
						eolRghqutZOOIGqvOFTzJOGfYTsn++;
						goto IL_0123;
						IL_00a5:
						while (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
						{
							int current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
							InputAction actionById = gZXxEqHwrHYIyUJtInpLwgTukJaY.GetActionById(current);
							if (actionById != null)
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = actionById;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
						}
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
						otVuTclWHkLrdVIElDnnPoApusjv = null;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (otVuTclWHkLrdVIElDnnPoApusjv != null)
				{
					otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
				BGeINzeKqECRRoBpanKdEednCtdX bGeINzeKqECRRoBpanKdEednCtdX;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					bGeINzeKqECRRoBpanKdEednCtdX = this;
				}
				else
				{
					bGeINzeKqECRRoBpanKdEednCtdX = new BGeINzeKqECRRoBpanKdEednCtdX(0);
					bGeINzeKqECRRoBpanKdEednCtdX.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				bGeINzeKqECRRoBpanKdEednCtdX.tfuONqHHaukqbwOzWbCAHLNaTcOq = ReqdoUDpdFtntvHXUspFdnTqlVgdb;
				bGeINzeKqECRRoBpanKdEednCtdX.CjWVZeZcJyhVOGCFZLXmKlVwfVYKA = OIgJIcPCbXGFHAFjMxiLYtrtKZuP;
				return bGeINzeKqECRRoBpanKdEednCtdX;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class YIQUofkkpRAJNmxeEmYEQIsmyxHI : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputAction USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private string QDsthxMKKQeaNCbxsqeqkljMaAwoA;

			public string XNOnKwZLHfqrNvUAmazlNJqCHHbQ;

			private bool CjWVZeZcJyhVOGCFZLXmKlVwfVYKA;

			public bool OIgJIcPCbXGFHAFjMxiLYtrtKZuP;

			private InputCategory YSPRVTMrwbOpJLYleIAzsimGiNvdA;

			private IEnumerator<int> kdOQxMRxfBprWWxzhobszTGNskAP;

			private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public YIQUofkkpRAJNmxeEmYEQIsmyxHI(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
				{
					try
					{
					}
					finally
					{
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actions == null || gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null)
						{
							return false;
						}
						if (QDsthxMKKQeaNCbxsqeqkljMaAwoA == null || QDsthxMKKQeaNCbxsqeqkljMaAwoA == string.Empty)
						{
							return false;
						}
						int num = gZXxEqHwrHYIyUJtInpLwgTukJaY.IndexOfActionCategory(QDsthxMKKQeaNCbxsqeqkljMaAwoA);
						if (num < 0)
						{
							return false;
						}
						YSPRVTMrwbOpJLYleIAzsimGiNvdA = gZXxEqHwrHYIyUJtInpLwgTukJaY.GetActionCategory(num);
						if (CjWVZeZcJyhVOGCFZLXmKlVwfVYKA)
						{
							kdOQxMRxfBprWWxzhobszTGNskAP = gZXxEqHwrHYIyUJtInpLwgTukJaY.SortedActionIdsInCategory(YSPRVTMrwbOpJLYleIAzsimGiNvdA.id).GetEnumerator();
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
							goto IL_00f2;
						}
						AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
						goto IL_0175;
					}
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_00f2;
					case 2:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_0163;
						}
						IL_0175:
						if (AEpFbNhiazpfukEJmuNHcDAbfQLWA >= gZXxEqHwrHYIyUJtInpLwgTukJaY.actions.Count)
						{
							break;
						}
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actions[AEpFbNhiazpfukEJmuNHcDAbfQLWA].categoryId == YSPRVTMrwbOpJLYleIAzsimGiNvdA.id)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.actions[AEpFbNhiazpfukEJmuNHcDAbfQLWA];
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
							return true;
						}
						goto IL_0163;
						IL_00f2:
						while (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
						{
							int current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
							InputAction actionById = gZXxEqHwrHYIyUJtInpLwgTukJaY.GetActionById(current);
							if (actionById != null)
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = actionById;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
						}
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
						kdOQxMRxfBprWWxzhobszTGNskAP = null;
						break;
						IL_0163:
						AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (kdOQxMRxfBprWWxzhobszTGNskAP != null)
				{
					kdOQxMRxfBprWWxzhobszTGNskAP.Dispose();
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
				YIQUofkkpRAJNmxeEmYEQIsmyxHI yIQUofkkpRAJNmxeEmYEQIsmyxHI;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					yIQUofkkpRAJNmxeEmYEQIsmyxHI = this;
				}
				else
				{
					yIQUofkkpRAJNmxeEmYEQIsmyxHI = new YIQUofkkpRAJNmxeEmYEQIsmyxHI(0);
					yIQUofkkpRAJNmxeEmYEQIsmyxHI.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				yIQUofkkpRAJNmxeEmYEQIsmyxHI.QDsthxMKKQeaNCbxsqeqkljMaAwoA = XNOnKwZLHfqrNvUAmazlNJqCHHbQ;
				yIQUofkkpRAJNmxeEmYEQIsmyxHI.CjWVZeZcJyhVOGCFZLXmKlVwfVYKA = OIgJIcPCbXGFHAFjMxiLYtrtKZuP;
				return yIQUofkkpRAJNmxeEmYEQIsmyxHI;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class zXNEMRhosfphioNDUREARVmCUemoA : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputMapCategory USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			private string hIsTTgMcJDwwbFwfjrcyfPezNUQC;

			public string SdneKSDMLwNqVBTPrwJYGNkjUDeS;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public zXNEMRhosfphioNDUREARVmCUemoA(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_0098;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (hIsTTgMcJDwwbFwfjrcyfPezNUQC == null || hIsTTgMcJDwwbFwfjrcyfPezNUQC == string.Empty)
				{
					return false;
				}
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories == null)
				{
					return false;
				}
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_00a8;
				IL_00a8:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories.Count)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg].tag.Equals(hIsTTgMcJDwwbFwfjrcyfPezNUQC, StringComparison.OrdinalIgnoreCase))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg];
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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
				zXNEMRhosfphioNDUREARVmCUemoA zXNEMRhosfphioNDUREARVmCUemoA2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					zXNEMRhosfphioNDUREARVmCUemoA2 = this;
				}
				else
				{
					zXNEMRhosfphioNDUREARVmCUemoA2 = new zXNEMRhosfphioNDUREARVmCUemoA(0);
					zXNEMRhosfphioNDUREARVmCUemoA2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				zXNEMRhosfphioNDUREARVmCUemoA2.hIsTTgMcJDwwbFwfjrcyfPezNUQC = SdneKSDMLwNqVBTPrwJYGNkjUDeS;
				return zXNEMRhosfphioNDUREARVmCUemoA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class lJLGKbbxIEDhTCMmpaxrGvaHadRoc : IDisposable, IEnumerable, IEnumerator, IEnumerable<string>, IEnumerator<string>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private string USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int ZamYCQxLHAGKChjEHxjlKOSnIhez;

			public int vQmsjtvoFotxHZloWoeMKlqyugXT;

			private IEnumerator<int> otVuTclWHkLrdVIElDnnPoApusjv;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public lJLGKbbxIEDhTCMmpaxrGvaHadRoc(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
				{
					try
					{
					}
					finally
					{
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null || gZXxEqHwrHYIyUJtInpLwgTukJaY.actions == null)
						{
							return false;
						}
						otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategoryMap.ActionIdsInCategory(ZamYCQxLHAGKChjEHxjlKOSnIhez).GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						break;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						break;
					}
					while (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
					{
						int current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
						InputAction actionById = gZXxEqHwrHYIyUJtInpLwgTukJaY.GetActionById(current);
						if (actionById != null)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = actionById.descriptiveName;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
					}
					xrMgkdBFpRjKpJIbZTZinfoAczuP();
					otVuTclWHkLrdVIElDnnPoApusjv = null;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (otVuTclWHkLrdVIElDnnPoApusjv != null)
				{
					otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
				lJLGKbbxIEDhTCMmpaxrGvaHadRoc lJLGKbbxIEDhTCMmpaxrGvaHadRoc2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					lJLGKbbxIEDhTCMmpaxrGvaHadRoc2 = this;
				}
				else
				{
					lJLGKbbxIEDhTCMmpaxrGvaHadRoc2 = new lJLGKbbxIEDhTCMmpaxrGvaHadRoc(0);
					lJLGKbbxIEDhTCMmpaxrGvaHadRoc2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				lJLGKbbxIEDhTCMmpaxrGvaHadRoc2.ZamYCQxLHAGKChjEHxjlKOSnIhez = vQmsjtvoFotxHZloWoeMKlqyugXT;
				return lJLGKbbxIEDhTCMmpaxrGvaHadRoc2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class qtekEhbtytntNsOsdGvOfabmAXTgb : IDisposable, IEnumerable, IEnumerator, IEnumerable<int>, IEnumerator<int>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private int USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int ZamYCQxLHAGKChjEHxjlKOSnIhez;

			public int vQmsjtvoFotxHZloWoeMKlqyugXT;

			private IEnumerator<int> otVuTclWHkLrdVIElDnnPoApusjv;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public qtekEhbtytntNsOsdGvOfabmAXTgb(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
				{
					try
					{
					}
					finally
					{
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null || gZXxEqHwrHYIyUJtInpLwgTukJaY.actions == null)
						{
							return false;
						}
						otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategoryMap.ActionIdsInCategory(ZamYCQxLHAGKChjEHxjlKOSnIhez).GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						break;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						break;
					}
					if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
					{
						int current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					xrMgkdBFpRjKpJIbZTZinfoAczuP();
					otVuTclWHkLrdVIElDnnPoApusjv = null;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (otVuTclWHkLrdVIElDnnPoApusjv != null)
				{
					otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
				qtekEhbtytntNsOsdGvOfabmAXTgb qtekEhbtytntNsOsdGvOfabmAXTgb2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					qtekEhbtytntNsOsdGvOfabmAXTgb2 = this;
				}
				else
				{
					qtekEhbtytntNsOsdGvOfabmAXTgb2 = new qtekEhbtytntNsOsdGvOfabmAXTgb(0);
					qtekEhbtytntNsOsdGvOfabmAXTgb2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				qtekEhbtytntNsOsdGvOfabmAXTgb2.ZamYCQxLHAGKChjEHxjlKOSnIhez = vQmsjtvoFotxHZloWoeMKlqyugXT;
				return qtekEhbtytntNsOsdGvOfabmAXTgb2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		private sealed class ZLvMGvWMesUPQmlwCnmUnIEUHkAU : IDisposable, IEnumerable, IEnumerator, IEnumerable<string>, IEnumerator<string>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private string USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int ZamYCQxLHAGKChjEHxjlKOSnIhez;

			public int vQmsjtvoFotxHZloWoeMKlqyugXT;

			private IEnumerator<int> otVuTclWHkLrdVIElDnnPoApusjv;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public ZLvMGvWMesUPQmlwCnmUnIEUHkAU(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
				{
					try
					{
					}
					finally
					{
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null || gZXxEqHwrHYIyUJtInpLwgTukJaY.actions == null)
						{
							return false;
						}
						otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategoryMap.ActionIdsInCategory(ZamYCQxLHAGKChjEHxjlKOSnIhez).GetEnumerator();
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						break;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						break;
					}
					while (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
					{
						int current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
						InputAction actionById = gZXxEqHwrHYIyUJtInpLwgTukJaY.GetActionById(current);
						if (actionById != null)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = actionById.name;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
							return true;
						}
					}
					xrMgkdBFpRjKpJIbZTZinfoAczuP();
					otVuTclWHkLrdVIElDnnPoApusjv = null;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (otVuTclWHkLrdVIElDnnPoApusjv != null)
				{
					otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
				ZLvMGvWMesUPQmlwCnmUnIEUHkAU zLvMGvWMesUPQmlwCnmUnIEUHkAU;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					zLvMGvWMesUPQmlwCnmUnIEUHkAU = this;
				}
				else
				{
					zLvMGvWMesUPQmlwCnmUnIEUHkAU = new ZLvMGvWMesUPQmlwCnmUnIEUHkAU(0);
					zLvMGvWMesUPQmlwCnmUnIEUHkAU.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				zLvMGvWMesUPQmlwCnmUnIEUHkAU.ZamYCQxLHAGKChjEHxjlKOSnIhez = vQmsjtvoFotxHZloWoeMKlqyugXT;
				return zLvMGvWMesUPQmlwCnmUnIEUHkAU;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class RAGjdagagmGEfvUMfUCTzXspyePF : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputCategory USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			private string hIsTTgMcJDwwbFwfjrcyfPezNUQC;

			public string SdneKSDMLwNqVBTPrwJYGNkjUDeS;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public RAGjdagagmGEfvUMfUCTzXspyePF(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_00b3;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (hIsTTgMcJDwwbFwfjrcyfPezNUQC == null || hIsTTgMcJDwwbFwfjrcyfPezNUQC == string.Empty)
				{
					return false;
				}
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null)
				{
					return false;
				}
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_00c3;
				IL_00c3:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories.Count)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg].userAssignable && gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg].tag.Equals(hIsTTgMcJDwwbFwfjrcyfPezNUQC, StringComparison.OrdinalIgnoreCase))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg];
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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
				RAGjdagagmGEfvUMfUCTzXspyePF rAGjdagagmGEfvUMfUCTzXspyePF;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					rAGjdagagmGEfvUMfUCTzXspyePF = this;
				}
				else
				{
					rAGjdagagmGEfvUMfUCTzXspyePF = new RAGjdagagmGEfvUMfUCTzXspyePF(0);
					rAGjdagagmGEfvUMfUCTzXspyePF.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				rAGjdagagmGEfvUMfUCTzXspyePF.hIsTTgMcJDwwbFwfjrcyfPezNUQC = SdneKSDMLwNqVBTPrwJYGNkjUDeS;
				return rAGjdagagmGEfvUMfUCTzXspyePF;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class LEDDQkqedTigTOSreiyRavqglhdM : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputAction USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int tfuONqHHaukqbwOzWbCAHLNaTcOq;

			public int ReqdoUDpdFtntvHXUspFdnTqlVgdb;

			private bool CjWVZeZcJyhVOGCFZLXmKlVwfVYKA;

			public bool OIgJIcPCbXGFHAFjMxiLYtrtKZuP;

			private InputCategory YSPRVTMrwbOpJLYleIAzsimGiNvdA;

			private IEnumerator<int> kdOQxMRxfBprWWxzhobszTGNskAP;

			private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public LEDDQkqedTigTOSreiyRavqglhdM(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
				{
					try
					{
					}
					finally
					{
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					InputAction inputAction;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actions == null || gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null)
						{
							return false;
						}
						YSPRVTMrwbOpJLYleIAzsimGiNvdA = gZXxEqHwrHYIyUJtInpLwgTukJaY.GetActionCategoryById(tfuONqHHaukqbwOzWbCAHLNaTcOq);
						if (YSPRVTMrwbOpJLYleIAzsimGiNvdA == null || !YSPRVTMrwbOpJLYleIAzsimGiNvdA.userAssignable)
						{
							return false;
						}
						if (CjWVZeZcJyhVOGCFZLXmKlVwfVYKA)
						{
							kdOQxMRxfBprWWxzhobszTGNskAP = gZXxEqHwrHYIyUJtInpLwgTukJaY.SortedActionIdsInCategory(YSPRVTMrwbOpJLYleIAzsimGiNvdA.id).GetEnumerator();
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
							goto IL_00e4;
						}
						AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
						goto IL_0165;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_00e4;
					case 2:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
						{
							int current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
							InputAction actionById = gZXxEqHwrHYIyUJtInpLwgTukJaY.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = actionById;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
						}
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
						kdOQxMRxfBprWWxzhobszTGNskAP = null;
						break;
						IL_0153:
						AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
						goto IL_0165;
						IL_0165:
						if (AEpFbNhiazpfukEJmuNHcDAbfQLWA >= gZXxEqHwrHYIyUJtInpLwgTukJaY.actions.Count)
						{
							break;
						}
						inputAction = gZXxEqHwrHYIyUJtInpLwgTukJaY.actions[AEpFbNhiazpfukEJmuNHcDAbfQLWA];
						if (inputAction.categoryId == YSPRVTMrwbOpJLYleIAzsimGiNvdA.id && inputAction.userAssignable)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = inputAction;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (kdOQxMRxfBprWWxzhobszTGNskAP != null)
				{
					kdOQxMRxfBprWWxzhobszTGNskAP.Dispose();
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
				LEDDQkqedTigTOSreiyRavqglhdM lEDDQkqedTigTOSreiyRavqglhdM;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					lEDDQkqedTigTOSreiyRavqglhdM = this;
				}
				else
				{
					lEDDQkqedTigTOSreiyRavqglhdM = new LEDDQkqedTigTOSreiyRavqglhdM(0);
					lEDDQkqedTigTOSreiyRavqglhdM.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				lEDDQkqedTigTOSreiyRavqglhdM.tfuONqHHaukqbwOzWbCAHLNaTcOq = ReqdoUDpdFtntvHXUspFdnTqlVgdb;
				lEDDQkqedTigTOSreiyRavqglhdM.CjWVZeZcJyhVOGCFZLXmKlVwfVYKA = OIgJIcPCbXGFHAFjMxiLYtrtKZuP;
				return lEDDQkqedTigTOSreiyRavqglhdM;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class WHeFAmKcXtXyvqPwAOpJXddTqLxkA : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputAction USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private string kbvdcsQoaNfwCsMMqLjeECuxQnug;

			public string ELwaljHXSZhsCGbrJqdYYpwEWWeT;

			private bool CjWVZeZcJyhVOGCFZLXmKlVwfVYKA;

			public bool OIgJIcPCbXGFHAFjMxiLYtrtKZuP;

			private InputCategory YSPRVTMrwbOpJLYleIAzsimGiNvdA;

			private IEnumerator<int> kdOQxMRxfBprWWxzhobszTGNskAP;

			private int AEpFbNhiazpfukEJmuNHcDAbfQLWA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public WHeFAmKcXtXyvqPwAOpJXddTqLxkA(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
				{
					try
					{
					}
					finally
					{
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					InputAction inputAction;
					switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
					{
					default:
						return false;
					case 0:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actions == null || gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null)
						{
							return false;
						}
						YSPRVTMrwbOpJLYleIAzsimGiNvdA = gZXxEqHwrHYIyUJtInpLwgTukJaY.GetActionCategory(kbvdcsQoaNfwCsMMqLjeECuxQnug);
						if (YSPRVTMrwbOpJLYleIAzsimGiNvdA == null || !YSPRVTMrwbOpJLYleIAzsimGiNvdA.userAssignable)
						{
							return false;
						}
						if (CjWVZeZcJyhVOGCFZLXmKlVwfVYKA)
						{
							kdOQxMRxfBprWWxzhobszTGNskAP = gZXxEqHwrHYIyUJtInpLwgTukJaY.SortedActionIdsInCategory(YSPRVTMrwbOpJLYleIAzsimGiNvdA.id).GetEnumerator();
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
							goto IL_00e4;
						}
						AEpFbNhiazpfukEJmuNHcDAbfQLWA = 0;
						goto IL_0165;
					case 1:
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
						goto IL_00e4;
					case 2:
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (kdOQxMRxfBprWWxzhobszTGNskAP.MoveNext())
						{
							int current = kdOQxMRxfBprWWxzhobszTGNskAP.Current;
							InputAction actionById = gZXxEqHwrHYIyUJtInpLwgTukJaY.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = actionById;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
						}
						xrMgkdBFpRjKpJIbZTZinfoAczuP();
						kdOQxMRxfBprWWxzhobszTGNskAP = null;
						break;
						IL_0153:
						AEpFbNhiazpfukEJmuNHcDAbfQLWA++;
						goto IL_0165;
						IL_0165:
						if (AEpFbNhiazpfukEJmuNHcDAbfQLWA >= gZXxEqHwrHYIyUJtInpLwgTukJaY.actions.Count)
						{
							break;
						}
						inputAction = gZXxEqHwrHYIyUJtInpLwgTukJaY.actions[AEpFbNhiazpfukEJmuNHcDAbfQLWA];
						if (inputAction.categoryId == YSPRVTMrwbOpJLYleIAzsimGiNvdA.id && inputAction.userAssignable)
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = inputAction;
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
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

			private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (kdOQxMRxfBprWWxzhobszTGNskAP != null)
				{
					kdOQxMRxfBprWWxzhobszTGNskAP.Dispose();
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
				WHeFAmKcXtXyvqPwAOpJXddTqLxkA wHeFAmKcXtXyvqPwAOpJXddTqLxkA;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					wHeFAmKcXtXyvqPwAOpJXddTqLxkA = this;
				}
				else
				{
					wHeFAmKcXtXyvqPwAOpJXddTqLxkA = new WHeFAmKcXtXyvqPwAOpJXddTqLxkA(0);
					wHeFAmKcXtXyvqPwAOpJXddTqLxkA.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				wHeFAmKcXtXyvqPwAOpJXddTqLxkA.kbvdcsQoaNfwCsMMqLjeECuxQnug = ELwaljHXSZhsCGbrJqdYYpwEWWeT;
				wHeFAmKcXtXyvqPwAOpJXddTqLxkA.CjWVZeZcJyhVOGCFZLXmKlVwfVYKA = OIgJIcPCbXGFHAFjMxiLYtrtKZuP;
				return wHeFAmKcXtXyvqPwAOpJXddTqLxkA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class vFsYIUAAKgxNbCJKcckbKtKyfCJFA : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputMapCategory USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			private string hIsTTgMcJDwwbFwfjrcyfPezNUQC;

			public string SdneKSDMLwNqVBTPrwJYGNkjUDeS;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public vFsYIUAAKgxNbCJKcckbKtKyfCJFA(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_00b3;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (hIsTTgMcJDwwbFwfjrcyfPezNUQC == null || hIsTTgMcJDwwbFwfjrcyfPezNUQC == string.Empty)
				{
					return false;
				}
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories == null)
				{
					return false;
				}
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_00c3;
				IL_00c3:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories.Count)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg].userAssignable && gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg].tag.Equals(hIsTTgMcJDwwbFwfjrcyfPezNUQC, StringComparison.OrdinalIgnoreCase))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg];
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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
				vFsYIUAAKgxNbCJKcckbKtKyfCJFA vFsYIUAAKgxNbCJKcckbKtKyfCJFA2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					vFsYIUAAKgxNbCJKcckbKtKyfCJFA2 = this;
				}
				else
				{
					vFsYIUAAKgxNbCJKcckbKtKyfCJFA2 = new vFsYIUAAKgxNbCJKcckbKtKyfCJFA(0);
					vFsYIUAAKgxNbCJKcckbKtKyfCJFA2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				vFsYIUAAKgxNbCJKcckbKtKyfCJFA2.hIsTTgMcJDwwbFwfjrcyfPezNUQC = SdneKSDMLwNqVBTPrwJYGNkjUDeS;
				return vFsYIUAAKgxNbCJKcckbKtKyfCJFA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class zZRbJyAfnWgrlatdktQwjHVGhxBdd : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputCategory USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public zZRbJyAfnWgrlatdktQwjHVGhxBdd(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_0070;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories == null)
				{
					return false;
				}
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_0080;
				IL_0080:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories.Count)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg].userAssignable)
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.actionCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg];
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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
				zZRbJyAfnWgrlatdktQwjHVGhxBdd zZRbJyAfnWgrlatdktQwjHVGhxBdd2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					zZRbJyAfnWgrlatdktQwjHVGhxBdd2 = this;
				}
				else
				{
					zZRbJyAfnWgrlatdktQwjHVGhxBdd2 = new zZRbJyAfnWgrlatdktQwjHVGhxBdd(0);
					zZRbJyAfnWgrlatdktQwjHVGhxBdd2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				return zZRbJyAfnWgrlatdktQwjHVGhxBdd2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class uiVeOcbHJxNtFBDuecYIaZwfwNPRb : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputAction USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public uiVeOcbHJxNtFBDuecYIaZwfwNPRb(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_007a;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.actions == null)
				{
					return false;
				}
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_008c;
				IL_008c:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.actions.Count)
				{
					InputAction inputAction = gZXxEqHwrHYIyUJtInpLwgTukJaY.actions[aWiJmJHWwqZlYdpLUbqxiFaJSHeg];
					InputCategory actionCategoryById = gZXxEqHwrHYIyUJtInpLwgTukJaY.GetActionCategoryById(inputAction.categoryId);
					if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = inputAction;
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_007a;
				}
				return false;
				IL_007a:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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
				uiVeOcbHJxNtFBDuecYIaZwfwNPRb uiVeOcbHJxNtFBDuecYIaZwfwNPRb2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					uiVeOcbHJxNtFBDuecYIaZwfwNPRb2 = this;
				}
				else
				{
					uiVeOcbHJxNtFBDuecYIaZwfwNPRb2 = new uiVeOcbHJxNtFBDuecYIaZwfwNPRb(0);
					uiVeOcbHJxNtFBDuecYIaZwfwNPRb2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				return uiVeOcbHJxNtFBDuecYIaZwfwNPRb2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class HfWiZLRoIxfwfSrBmvsBjmOLnujw : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private InputMapCategory USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public UserData GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public HfWiZLRoIxfwfSrBmvsBjmOLnujw(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				UserData gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_0070;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories == null)
				{
					return false;
				}
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_0080;
				IL_0080:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories.Count)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg].userAssignable)
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.mapCategories[aWiJmJHWwqZlYdpLUbqxiFaJSHeg];
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
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
				HfWiZLRoIxfwfSrBmvsBjmOLnujw hfWiZLRoIxfwfSrBmvsBjmOLnujw;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					hfWiZLRoIxfwfSrBmvsBjmOLnujw = this;
				}
				else
				{
					hfWiZLRoIxfwfSrBmvsBjmOLnujw = new HfWiZLRoIxfwfSrBmvsBjmOLnujw(0);
					hfWiZLRoIxfwfSrBmvsBjmOLnujw.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				return hfWiZLRoIxfwfSrBmvsBjmOLnujw;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ActionCategoryMap actionCategoryMap = new ActionCategoryMap();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputBehavior> inputBehaviors = new List<InputBehavior>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputLayout> customControllerLayouts = new List<InputLayout>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> joystickMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> keyboardMaps = new List<ControllerMap_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMap_Editor> mouseMaps = new List<ControllerMap_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int joystickLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int keyboardMapIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int controllerMapEnablerSetIdCounter;

		private Func<int, bool> containsActionDelegate;

		internal IList<Player_Editor> JKsoUwCAgkKhpVANcbhaqhyjGJigA
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

		internal IList<InputAction> QDXMXrSykXUDnNdCiilyBrJmWitT
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

		internal IList<InputCategory> BAgNKIlyRMbqWavPnoaTeSjTjVQe
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

		internal IList<InputBehavior> MqfUdVKHJlEpTjqfHVfcRoQnkImbb
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

		internal IList<InputMapCategory> QuihPWUtmEWgykttrhznkpfVggkj
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

		internal IList<InputLayout> yBTaVIXvmjEEfhJlhBHueVPUIbWKA
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

		internal IList<InputLayout> LYtZzJfhxYpFJjFfpNDBCkzpAabGA
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

		internal IList<InputLayout> SyOlkdhWLOiYUyuPjpjpThGFglOkA
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

		internal IList<InputLayout> cLzyDISHGQRgTCDOxAXAHqSfGEtJA
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

		internal IList<ControllerMap_Editor> dvqllZWxXFsPPvqkuXCaUyqNUach
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

		internal IList<ControllerMap_Editor> JbtGsUMFDTqvOoKBSDpHpYQgUWUb
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

		internal IList<ControllerMap_Editor> ZbedeDphKABXNczfHVqugZgllmTkA
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

		internal IList<ControllerMap_Editor> MfPBwnUqsfBwDSajQlDisorHmKun
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

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> YAgjrAugjAhVpzfFrgvgyjfxiteh
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

		internal IList<ControllerMapEnabler_RuleSet_Editor> KIAnNDdzzPNhliCIPRHTYfnevKVp
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

		internal IEnumerable<InputMapCategory> srnxGjiCzcThxiGlxKeBziqfQiqH => new HfWiZLRoIxfwfSrBmvsBjmOLnujw(-2)
		{
			GZXxEqHwrHYIyUJtInpLwgTukJaY = this
		};

		internal IEnumerable<InputCategory> xcDmYzOqkxbCiEDuYWumnJhpjpFW => new zZRbJyAfnWgrlatdktQwjHVGhxBdd(-2)
		{
			GZXxEqHwrHYIyUJtInpLwgTukJaY = this
		};

		internal IEnumerable<InputAction> nOBeigZAIJHlBPazEdpSHuHflsdkA => new uiVeOcbHJxNtFBDuecYIaZwfwNPRb(-2)
		{
			GZXxEqHwrHYIyUJtInpLwgTukJaY = this
		};

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

		internal IEnumerable<InputMapCategory> wpboJwwNGJmYiwVLqNPFNDHfbaKo(string P_0)
		{
			return new zXNEMRhosfphioNDUREARVmCUemoA(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				SdneKSDMLwNqVBTPrwJYGNkjUDeS = P_0
			};
		}

		internal IEnumerable<InputMapCategory> YUjGphbQdSfXfWvwZXgXfRCYcbAEA(string P_0)
		{
			return new vFsYIUAAKgxNbCJKcckbKtKyfCJFA(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				SdneKSDMLwNqVBTPrwJYGNkjUDeS = P_0
			};
		}

		internal IEnumerable<InputCategory> OnMPQXxheXYkvEvqoPDpiOiodhdW(string P_0)
		{
			return new yWlgTkdIFNHGhQbalMiaYSisGFtS(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				SdneKSDMLwNqVBTPrwJYGNkjUDeS = P_0
			};
		}

		internal IEnumerable<InputCategory> uRldOsoyFtCfBHYmOYGmPMpcIJOH(string P_0)
		{
			return new RAGjdagagmGEfvUMfUCTzXspyePF(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				SdneKSDMLwNqVBTPrwJYGNkjUDeS = P_0
			};
		}

		internal IEnumerable<InputAction> PdViJRIXmdlkJefoQEdnWvycLKwA(int P_0, bool P_1)
		{
			return new BGeINzeKqECRRoBpanKdEednCtdX(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				ReqdoUDpdFtntvHXUspFdnTqlVgdb = P_0,
				OIgJIcPCbXGFHAFjMxiLYtrtKZuP = P_1
			};
		}

		internal IEnumerable<InputAction> PdViJRIXmdlkJefoQEdnWvycLKwA(string P_0, bool P_1)
		{
			return new YIQUofkkpRAJNmxeEmYEQIsmyxHI(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				XNOnKwZLHfqrNvUAmazlNJqCHHbQ = P_0,
				OIgJIcPCbXGFHAFjMxiLYtrtKZuP = P_1
			};
		}

		internal IEnumerable<InputAction> SjGUBRUluMnJNKhqdgFPZOWjSHlr(string P_0)
		{
			return new pDXQDlFGSwndgmLZmhWNhgaXEDTv(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				SdneKSDMLwNqVBTPrwJYGNkjUDeS = P_0
			};
		}

		internal IEnumerable<InputAction> mXTEGDBSePHkAbgekLJbnebreZGbA(int P_0, bool P_1)
		{
			return new LEDDQkqedTigTOSreiyRavqglhdM(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				ReqdoUDpdFtntvHXUspFdnTqlVgdb = P_0,
				OIgJIcPCbXGFHAFjMxiLYtrtKZuP = P_1
			};
		}

		internal IEnumerable<InputAction> mXTEGDBSePHkAbgekLJbnebreZGbA(string P_0, bool P_1)
		{
			return new WHeFAmKcXtXyvqPwAOpJXddTqLxkA(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				ELwaljHXSZhsCGbrJqdYYpwEWWeT = P_0,
				OIgJIcPCbXGFHAFjMxiLYtrtKZuP = P_1
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
				Player_Editor player_Editor = yUmALvgxwtsmmyoKAWvEWRFwXeF();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputCategory inputCategory = xWSQWakGGJgjbKUgaVOfcPqotHbf();
				inputCategory.name = "Default";
				inputCategory.descriptiveName = inputCategory.name;
				actionCategories.Add(inputCategory);
				actionCategoryMap.AddCategory(inputCategory.id);
				InputBehavior inputBehavior = GqnjbFDQNUdGQdjJmpCTYESsLnK();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = CsVOEodBUybfwuHXtWauKACgGbRV();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = HhxFQPGFsKmblxegyPyzdIZDJWTRA();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = yiYeppbiJZFFRydGhdxvnwSYaGzF();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = GcPdoIetuPxmbJXFiVlqTfhhEYVF();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = FDBzPpuKtnYycjjSmkfbnjgWfkYi();
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
		}

		public List<InputAction> GetActions_Copy()
		{
			List<InputAction> list = new List<InputAction>();
			for (int i = 0; i < actions.Count; i++)
			{
				list.Add(actions[i]);
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
				KeyboardMap item = keyboardMaps[i].cNjhZNjuLYCMZSfYvGBoaUExXoHN(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].vErEpNsUDYHqQujXrmVrfsYqfAJt(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(yUmALvgxwtsmmyoKAWvEWRFwXeF());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, yUmALvgxwtsmmyoKAWvEWRFwXeF());
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
			InputAction inputAction = GctxKYGDUTezeRPLLNMLItogxuhp();
			inputAction.categoryId = categoryId;
			actions.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (actions != null)
			{
				InputAction inputAction = GctxKYGDUTezeRPLLNMLItogxuhp();
				inputAction.categoryId = categoryId;
				actions.Add(inputAction);
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
					actions.RemoveAt(num);
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
			if (num == actions.Count - 1)
			{
				actions.Add(inputAction);
				actionCategoryMap.AddAction(categoryId, inputAction.id);
				return actions.Count - 1;
			}
			actions.Insert(num + 1, inputAction);
			int num2 = actionCategoryMap.IndexOfAction(categoryId, actionId);
			actionCategoryMap.InsertAction(categoryId, inputAction.id, num2 + 1);
			return num + 1;
		}

		private int DCaXHaALjbtOEKXTzqAxWzRbmgcW(int P_0, InputAction P_1)
		{
			if (IndexOfActionCategory(P_0) < 0)
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
				return null;
			}
			string[] array = new string[actions.Count];
			for (int i = 0; i < actions.Count; i++)
			{
				array[i] = actions[i].name;
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
			if (actions == null)
			{
				return 0;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				results.Add(actions[i].name);
			}
			return results.Count;
		}

		public int[] GetActionIds()
		{
			if (actions == null)
			{
				return null;
			}
			int[] array = new int[actions.Count];
			for (int i = 0; i < actions.Count; i++)
			{
				array[i] = actions[i].id;
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
			if (actions == null)
			{
				return 0;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				results.Add(actions[i].id);
			}
			return results.Count;
		}

		public string GetActionNameById(int id)
		{
			if (actions == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i].id == id)
				{
					return actions[i].name;
				}
			}
			return string.Empty;
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
				return null;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i].id == id)
				{
					return actions[i];
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

		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			return new ZLvMGvWMesUPQmlwCnmUnIEUHkAU(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				vQmsjtvoFotxHZloWoeMKlqyugXT = id
			};
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (actionCategories == null || actions == null)
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

		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			return new lJLGKbbxIEDhTCMmpaxrGvaHadRoc(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				vQmsjtvoFotxHZloWoeMKlqyugXT = id
			};
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			if (actionCategories == null || actions == null)
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

		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			return new qtekEhbtytntNsOsdGvOfabmAXTgb(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				vQmsjtvoFotxHZloWoeMKlqyugXT = id
			};
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
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfAction(string name)
		{
			if (actions == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddActionCategory()
		{
			InputCategory inputCategory = xWSQWakGGJgjbKUgaVOfcPqotHbf();
			actionCategories.Add(inputCategory);
			actionCategoryMap.AddCategory(inputCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputCategory inputCategory = xWSQWakGGJgjbKUgaVOfcPqotHbf();
			actionCategories.Insert(index, inputCategory);
			actionCategoryMap.AddCategory(inputCategory.id);
		}

		public void DeleteActionCategory(int index)
		{
			if (actionCategories == null || index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = actionCategories[index].id;
			actionCategoryMap.RemoveCategory(id);
			if (actions != null)
			{
				for (int num = actions.Count - 1; num >= 0; num--)
				{
					if (actions[num].categoryId == id)
					{
						actions.RemoveAt(num);
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
			InputCategory inputCategory = new InputCategory(actionCategories[index]);
			inputCategory.id = GetNewActionCategoryId();
			inputCategory.name = StringTools.IterateName(inputCategory.name, -1, GetActionCategoryNames());
			if (index == actionCategories.Count - 1)
			{
				actionCategories.Add(inputCategory);
			}
			else
			{
				actionCategories.Insert(index + 1, inputCategory);
			}
			actionCategoryMap.AddCategory(inputCategory.id);
			if (!duplicateActions || actions == null)
			{
				return;
			}
			int id = inputCategory.id;
			int id2 = actionCategories[index].id;
			List<int> list = new List<int>();
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i].categoryId == id2)
				{
					list.Add(i);
				}
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>(list.Count);
			for (int j = 0; j < list.Count; j++)
			{
				InputAction inputAction = actions[list[j]];
				int num = DCaXHaALjbtOEKXTzqAxWzRbmgcW(id2, inputAction);
				if (num >= 0)
				{
					InputAction inputAction2 = actions[num];
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
			if (actions != null)
			{
				for (int i = 0; i < actions.Count; i++)
				{
					if (actions[i].categoryId == id)
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
			inputBehaviors.Add(GqnjbFDQNUdGQdjJmpCTYESsLnK());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, GqnjbFDQNUdGQdjJmpCTYESsLnK());
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = inputBehaviors[index].id;
			if (actions != null)
			{
				for (int i = 0; i < actions.Count; i++)
				{
					if (actions[i].behaviorId == id)
					{
						actions[i].behaviorId = 0;
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
			mapCategories.Add(CsVOEodBUybfwuHXtWauKACgGbRV());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, CsVOEodBUybfwuHXtWauKACgGbRV());
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
				Action<List<Player_Editor.Mapping>, int> action = wicHmXkfiOHNToMhGtLoOUfZQNqe._003C_003E9.NgYSsyPwknmarFWlTVlXqdbNXkZe;
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
			joystickLayouts.Add(HhxFQPGFsKmblxegyPyzdIZDJWTRA());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, HhxFQPGFsKmblxegyPyzdIZDJWTRA());
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
				Action<List<Player_Editor.Mapping>, int> action = wicHmXkfiOHNToMhGtLoOUfZQNqe._003C_003E9.mMdEsqgrMVREIUfnbciXkahvCPZe;
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
			keyboardLayouts.Add(yiYeppbiJZFFRydGhdxvnwSYaGzF());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, yiYeppbiJZFFRydGhdxvnwSYaGzF());
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
				Action<List<Player_Editor.Mapping>, int> action = wicHmXkfiOHNToMhGtLoOUfZQNqe._003C_003E9.IzzdrapQKUTLFmDXmGNBGDokKoyIA;
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
			mouseLayouts.Add(GcPdoIetuPxmbJXFiVlqTfhhEYVF());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, GcPdoIetuPxmbJXFiVlqTfhhEYVF());
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
				Action<List<Player_Editor.Mapping>, int> action = wicHmXkfiOHNToMhGtLoOUfZQNqe._003C_003E9.UMgqUsqTcRHuWbWBDpFkBkVEwsJV;
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
			customControllerLayouts.Add(FDBzPpuKtnYycjjSmkfbnjgWfkYi());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, FDBzPpuKtnYycjjSmkfbnjgWfkYi());
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
				Action<List<Player_Editor.Mapping>, int> action = wicHmXkfiOHNToMhGtLoOUfZQNqe._003C_003E9.YPfEUaumFmXaENjfvEavveAlrUBS;
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

		internal ControllerMap gpidnRqlHkndAPBFkaLBVVnkohYm(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Joystick => HetfeQvTGnionvvgSERhKCeYNRCzA((Joystick)P_0, P_1, P_2), 
				ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
				ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
				ControllerType.Custom => opgKaKVcPgBILvSltCnRcmUcNLJab(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
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

		internal JoystickMap gQDlKZqpgrEymKXajHXzlgcdzNnF(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return HetfeQvTGnionvvgSERhKCeYNRCzA(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap HetfeQvTGnionvvgSERhKCeYNRCzA(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return HetfeQvTGnionvvgSERhKCeYNRCzA(P_0.QffiBMTMryEswOxOSXKFrNXqjHhj, P_1, P_2);
		}

		private JoystickMap HetfeQvTGnionvvgSERhKCeYNRCzA(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.iCFBeqngbahtgGTVxrPduMQZXdmW(guid);
			ControllerMap_Editor controllerMap_Editor = JbFunDPTXOroJqrsAIadZqgNFQVBA(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.hNNtIWnsAISQeBKHEYlQOIQtmvAI(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.BTTeANcpZxbIKMGHTZlOfKJhVHSmA(guid, P_1, P_2);
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
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.wgDfcpFFKvqeeKkPsJPdHHqsdbZZA(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = JbFunDPTXOroJqrsAIadZqgNFQVBA(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = TMRykQOGSUWdmTWnxfdVmHDXMbyU(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.BTTeANcpZxbIKMGHTZlOfKJhVHSmA(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty || 1 == 0)
			{
				controllerMap_Editor = JbFunDPTXOroJqrsAIadZqgNFQVBA(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.hNNtIWnsAISQeBKHEYlQOIQtmvAI(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.BTTeANcpZxbIKMGHTZlOfKJhVHSmA(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.WzvmTWEFCkKUnRYLvufrwGixUEhp(guid, P_1, P_2);
		}

		private ControllerMap_Editor JbFunDPTXOroJqrsAIadZqgNFQVBA(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = YNzmDPbjthHTGWpUqoSnCfUGBwLS(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor YNzmDPbjthHTGWpUqoSnCfUGBwLS(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				MCDCqXuTltoIUDevmoGnVgCcJaBx(list, joystickLayouts);
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

		private JoystickMap TMRykQOGSUWdmTWnxfdVmHDXMbyU(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.SiLXRhvlGKjByHOMkjlXFMPAdHdyA(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError("Error remapping joystick template " + P_2.Guid.ToString() + " to joystick " + P_0.guid.ToString() + "\nReason: " + text);
				return null;
			}
			return controllerMap_Editor.hNNtIWnsAISQeBKHEYlQOIQtmvAI(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap cOoKcGjjLMiWClekszrETioHDNScA(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.iCFBeqngbahtgGTVxrPduMQZXdmW(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.iCFBeqngbahtgGTVxrPduMQZXdmW(Guid.Empty);
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
					string name = elementIdentifier.name;
					if (!string.IsNullOrEmpty(name))
					{
						int num = 0;
						int num2 = name.IndexOf("button", 0, StringComparison.OrdinalIgnoreCase);
						if (num2 < 0)
						{
							num2 = name.IndexOf("axis", 0, StringComparison.OrdinalIgnoreCase);
							num = 1;
						}
						if (num2 >= 0 && (num != 0 || buttons != null) && (num != 1 || axes != null))
						{
							string text = Regex.Replace(name, "[^0-9]+", "");
							Logger.Log(text);
							if (int.TryParse(text, out var result))
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
				list.Add(allMap.HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
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
			ControllerMap_Editor controllerMap_Editor = gapkbeUvNadmwexKEWZABzZWTMY(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.cNjhZNjuLYCMZSfYvGBoaUExXoHN(containsActionDelegate);
				keyboardMap.BTTeANcpZxbIKMGHTZlOfKJhVHSmA(keyboard.ajOkBXCGxlWjiAJvaOHxjyadfWfu, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.WzvmTWEFCkKUnRYLvufrwGixUEhp(keyboard.ajOkBXCGxlWjiAJvaOHxjyadfWfu, categoryId, layoutId);
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
			ControllerMap_Editor controllerMap_Editor = gapkbeUvNadmwexKEWZABzZWTMY(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.vErEpNsUDYHqQujXrmVrfsYqfAJt(containsActionDelegate);
				mouseMap.BTTeANcpZxbIKMGHTZlOfKJhVHSmA(mouse.ajOkBXCGxlWjiAJvaOHxjyadfWfu, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.WzvmTWEFCkKUnRYLvufrwGixUEhp(mouse.ajOkBXCGxlWjiAJvaOHxjyadfWfu, categoryId, layoutId);
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

		internal CustomControllerMap opgKaKVcPgBILvSltCnRcmUcNLJab(Guid P_0, int P_1, int P_2)
		{
			return opgKaKVcPgBILvSltCnRcmUcNLJab(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap opgKaKVcPgBILvSltCnRcmUcNLJab(int P_0, int P_1, int P_2)
		{
			return opgKaKVcPgBILvSltCnRcmUcNLJab(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap opgKaKVcPgBILvSltCnRcmUcNLJab(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = OJdsBTdoBaOmGaWoYpveQjhIbAMC(P_1, id, P_2, false);
			if (controllerMap_Editor != null)
			{
				CustomControllerMap customControllerMap = controllerMap_Editor.RMujDTJbbEkVZHFwyceZAuSllfUgb(ContainsAction, P_0);
				customControllerMap.BTTeANcpZxbIKMGHTZlOfKJhVHSmA(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			CustomControllerMap customControllerMap2 = CustomControllerMap.WzvmTWEFCkKUnRYLvufrwGixUEhp(P_0.typeGuid, id, P_1, P_2);
			customControllerMap2.BTTeANcpZxbIKMGHTZlOfKJhVHSmA(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap2;
		}

		private ControllerMap_Editor OJdsBTdoBaOmGaWoYpveQjhIbAMC(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = wyIHIFKClVSokeKgApekOagnbMVy(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor wyIHIFKClVSokeKgApekOagnbMVy(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				MCDCqXuTltoIUDevmoGnVgCcJaBx(list, customControllerLayouts);
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

		internal ControllerTemplateMap AFQSZpvOSBQRtoEFNfZZVBBCrtkW(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.oKBKVEIzNCapqdIgxAUzoKSmASoCA();
		}

		public void AddCustomController()
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			customControllers.Add(TuWDxcollVtmdqUInFgZaHxEEzPeA());
		}

		public void InsertCustomController(int index)
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			if (index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllers.Insert(index, TuWDxcollVtmdqUInFgZaHxEEzPeA());
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

		public void DuplicateCustomController(int index, bool duplicateMaps)
		{
			if (customControllers == null || index < 0 || index >= customControllers.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			CustomController_Editor customController_Editor = customControllers[index].Clone();
			customController_Editor.id = GetNewCustomControllerId();
			customController_Editor.typeGuid = Guid.NewGuid();
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
			controllerMapLayoutManagerRuleSets.Add(JjiYeHipOsTdvtUDKxIZVmRNuEZm());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, JjiYeHipOsTdvtUDKxIZVmRNuEZm());
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
			controllerMapEnablerRuleSets.Add(UAoswQjMXZYKOYABzNXrgFPdRMHF());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, UAoswQjMXZYKOYABzNXrgFPdRMHF());
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

		private Player_Editor yUmALvgxwtsmmyoKAWvEWRFwXeF()
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

		private InputAction GctxKYGDUTezeRPLLNMLItogxuhp()
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

		private InputCategory xWSQWakGGJgjbKUgaVOfcPqotHbf()
		{
			InputCategory obj = new InputCategory
			{
				id = GetNewActionCategoryId(),
				name = StringTools.IterateName("Category", -1, GetActionCategoryNames())
			};
			obj.descriptiveName = obj.name;
			obj.userAssignable = true;
			return obj;
		}

		private InputBehavior GqnjbFDQNUdGQdjJmpCTYESsLnK()
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

		private InputMapCategory CsVOEodBUybfwuHXtWauKACgGbRV()
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

		private InputLayout HhxFQPGFsKmblxegyPyzdIZDJWTRA()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewJoystickLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout yiYeppbiJZFFRydGhdxvnwSYaGzF()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewKeyboardLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout GcPdoIetuPxmbJXFiVlqTfhhEYVF()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewMouseLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout FDBzPpuKtnYycjjSmkfbnjgWfkYi()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewCustomControllerLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private CustomController_Editor TuWDxcollVtmdqUInFgZaHxEEzPeA()
		{
			CustomController_Editor obj = new CustomController_Editor
			{
				id = GetNewCustomControllerId(),
				typeGuid = Guid.NewGuid(),
				name = StringTools.IterateName("CustomController", -1, GetCustomControllerNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private ControllerMapLayoutManager_RuleSet_Editor JjiYeHipOsTdvtUDKxIZVmRNuEZm()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor
			{
				id = GetNewControllerMapLayoutManagerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames())
			};
		}

		private ControllerMapEnabler_RuleSet_Editor UAoswQjMXZYKOYABzNXrgFPdRMHF()
		{
			return new ControllerMapEnabler_RuleSet_Editor
			{
				id = GetNewControllerMapEnablerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames())
			};
		}

		private ControllerMap_Editor AkmGKmKtGssDZWhuBYTkwkYerzBp(List<ControllerMap_Editor> P_0, int P_1, int P_2)
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

		private ControllerMap_Editor gapkbeUvNadmwexKEWZABzZWTMY(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = AkmGKmKtGssDZWhuBYTkwkYerzBp(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = RWDToDblTfPTBJiQgBlfaZaPWJSG(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor RWDToDblTfPTBJiQgBlfaZaPWJSG(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				MCDCqXuTltoIUDevmoGnVgCcJaBx(list, P_1);
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

		private void MCDCqXuTltoIUDevmoGnVgCcJaBx(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			lOFDYnFgCfrYqVxqEwWPVKdXQEPL lOFDYnFgCfrYqVxqEwWPVKdXQEPL2 = new lOFDYnFgCfrYqVxqEwWPVKdXQEPL();
			lOFDYnFgCfrYqVxqEwWPVKdXQEPL2.HTzDQCCHqejxnEHdtVLStAPmrwAF = P_1;
			if (P_0 != null && lOFDYnFgCfrYqVxqEwWPVKdXQEPL2.HTzDQCCHqejxnEHdtVLStAPmrwAF != null)
			{
				P_0.Sort(lOFDYnFgCfrYqVxqEwWPVKdXQEPL2.qqHtaRJqxiqcDooJAYEFrAbGGcNk);
			}
		}

		internal void gUxczTgMdKUcYRnCXamteWaCXJodc()
		{
			JKsoUwCAgkKhpVANcbhaqhyjGJigA = new ReadOnlyCollection<Player_Editor>(players);
			QDXMXrSykXUDnNdCiilyBrJmWitT = new ReadOnlyCollection<InputAction>(actions);
			BAgNKIlyRMbqWavPnoaTeSjTjVQe = new ReadOnlyCollection<InputCategory>(actionCategories);
			MqfUdVKHJlEpTjqfHVfcRoQnkImbb = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
			QuihPWUtmEWgykttrhznkpfVggkj = new ReadOnlyCollection<InputMapCategory>(mapCategories);
			yBTaVIXvmjEEfhJlhBHueVPUIbWKA = new ReadOnlyCollection<InputLayout>(joystickLayouts);
			LYtZzJfhxYpFJjFfpNDBCkzpAabGA = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
			SyOlkdhWLOiYUyuPjpjpThGFglOkA = new ReadOnlyCollection<InputLayout>(mouseLayouts);
			cLzyDISHGQRgTCDOxAXAHqSfGEtJA = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
			dvqllZWxXFsPPvqkuXCaUyqNUach = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
			JbtGsUMFDTqvOoKBSDpHpYQgUWUb = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
			ZbedeDphKABXNczfHVqugZgllmTkA = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
			MfPBwnUqsfBwDSajQlDisorHmKun = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
			YAgjrAugjAhVpzfFrgvgyjfxiteh = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
			KIAnNDdzzPNhliCIPRHTYfnevKVp = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					mapCategories[i].gUxczTgMdKUcYRnCXamteWaCXJodc();
				}
			}
			containsActionDelegate = ContainsAction;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return ubELeQxzedANpjJHRTnfUdKEgAPiA.vZqRRYviGPiQjlKBnPeuANBeHCxEA(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return ubELeQxzedANpjJHRTnfUdKEgAPiA.vZqRRYviGPiQjlKBnPeuANBeHCxEA(orig, null, false);
		}
	}
}
