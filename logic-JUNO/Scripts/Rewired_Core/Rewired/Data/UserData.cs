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
		private static class SkqigAaSReBCXzHgXElbhXcqydLeA
		{
			[DefaultMember("Item")]
			private class pBawuQolMdjklghDCGlKaZbDiwpdb
			{
				public enum XmVdHpntFUqyoWuHKSOagHJccsFT
				{
					origId = 0,
					otherId = 1,
					finalId = 2
				}

				public int jzDhyQEqzrcJcybafvCDKSljnkYg;

				public int gsqverUIpgWdltzmADzPvzFqPagx;

				public int fjCCrbwylroUSoEwzUvBsyEpfiGE;

				public int FGgbQgASmCLMPIJfAqskOKqGXsDKB
				{
					get
					{
						return P_0 switch
						{
							XmVdHpntFUqyoWuHKSOagHJccsFT.origId => jzDhyQEqzrcJcybafvCDKSljnkYg, 
							XmVdHpntFUqyoWuHKSOagHJccsFT.otherId => gsqverUIpgWdltzmADzPvzFqPagx, 
							XmVdHpntFUqyoWuHKSOagHJccsFT.finalId => fjCCrbwylroUSoEwzUvBsyEpfiGE, 
							_ => throw new NotImplementedException(), 
						};
					}
					set
					{
						switch (xmVdHpntFUqyoWuHKSOagHJccsFT)
						{
						case XmVdHpntFUqyoWuHKSOagHJccsFT.origId:
							jzDhyQEqzrcJcybafvCDKSljnkYg = num;
							break;
						case XmVdHpntFUqyoWuHKSOagHJccsFT.otherId:
							gsqverUIpgWdltzmADzPvzFqPagx = num;
							break;
						case XmVdHpntFUqyoWuHKSOagHJccsFT.finalId:
							fjCCrbwylroUSoEwzUvBsyEpfiGE = num;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public pBawuQolMdjklghDCGlKaZbDiwpdb(int P_0, int P_1, int P_2)
				{
					jzDhyQEqzrcJcybafvCDKSljnkYg = P_0;
					gsqverUIpgWdltzmADzPvzFqPagx = P_1;
					fjCCrbwylroUSoEwzUvBsyEpfiGE = P_2;
				}

				public virtual string AFdGjlvMLaBKdZtlWUbuwqxMvyFM()
				{
					return string.Concat(string.Concat("" + StringTools.WriteVar("origId", jzDhyQEqzrcJcybafvCDKSljnkYg), StringTools.WriteVar("otherId", gsqverUIpgWdltzmADzPvzFqPagx)), StringTools.WriteVar("finalId", fjCCrbwylroUSoEwzUvBsyEpfiGE));
				}
			}

			private class tsrLrNQkDKVAWrqpJnarpxwZfrNk<_0001>
			{
				public _0001 ClgpBfRiGnCqWaKEFoUEvjOIUsFC;

				public _0001 gbvjerAmdBQOqdMppVMrVPNGLQGgA;

				public pBawuQolMdjklghDCGlKaZbDiwpdb.XmVdHpntFUqyoWuHKSOagHJccsFT OgjsbVPCjFotsZfkNMuatUlsIVxq;

				public IList<_0001> wzkzUMXuoWGZwTytFdoKNaEajvvj;

				public bool euLavXUKtCnBOplilyJJWMiBcdSe;

				public tsrLrNQkDKVAWrqpJnarpxwZfrNk(_0001 P_0, _0001 P_1, pBawuQolMdjklghDCGlKaZbDiwpdb.XmVdHpntFUqyoWuHKSOagHJccsFT P_2, IList<_0001> P_3, bool P_4)
				{
					ClgpBfRiGnCqWaKEFoUEvjOIUsFC = P_0;
					gbvjerAmdBQOqdMppVMrVPNGLQGgA = P_1;
					OgjsbVPCjFotsZfkNMuatUlsIVxq = P_2;
					wzkzUMXuoWGZwTytFdoKNaEajvvj = P_3;
					euLavXUKtCnBOplilyJJWMiBcdSe = P_4;
				}
			}

			[Serializable]
			private sealed class zmBPtlwhonJVUSZSCUKWjpYaAVYR
			{
				public static readonly zmBPtlwhonJVUSZSCUKWjpYaAVYR _003C_003E9 = new zmBPtlwhonJVUSZSCUKWjpYaAVYR();

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

				internal int ZGmrLEjFKbJNQTZwQKEoLBwKeWJF(InputCategory P_0)
				{
					return P_0.id;
				}

				internal string RJoEnNIBtUUecwClDmOJVMhKnDcAA(InputCategory P_0)
				{
					return P_0.name;
				}

				internal int dOvOMLNQqpkFmAvAefyOtabXPQao(InputCategory P_0, IList<InputCategory> P_1)
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

				internal int wkiaAOpjUnMtnNVoRjYcoXplwyvT(InputBehavior P_0)
				{
					return P_0.id;
				}

				internal string QRfdYPDHjvndRpAzqduEGtpBKiqec(InputBehavior P_0)
				{
					return P_0.name;
				}

				internal int VyJAdYBjFHWtsMSOEvjAoocSxbXTA(InputBehavior P_0, IList<InputBehavior> P_1)
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

				internal int tssjIPZbVjMRSNBBtugvZMQsNEqq(InputAction P_0)
				{
					return P_0.id;
				}

				internal string QMbelEckwiilDBxOfIZZHzIbrpHIE(InputAction P_0)
				{
					return P_0.name;
				}

				internal int RLohtszJzXactkngoivHmEbtCLEHb(InputAction P_0, IList<InputAction> P_1)
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

				internal int wyQbmaJrdVnrwHZSCbqeuLYvLhoI(InputMapCategory P_0)
				{
					return P_0.id;
				}

				internal string slbEXNuhAAzyGuEjbdhCgjJYlCoeA(InputMapCategory P_0)
				{
					return P_0.name;
				}

				internal int vXxgVHAjCvJHodLQZwXZxnmfuIxK(InputMapCategory P_0, IList<InputMapCategory> P_1)
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

				internal int JZKCoFkVHrtaWTFdoODRoEZrbeKX(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string FcYCpgoVdanHnFPdGKSGvEVtQraY(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int GnOyhtyUkgAvxBfFbKCztwpUGFOk(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int libpSRnfiflaCVJBahpYjatRcIoBA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string lHQbJCdRZKWfCkvpXkVMOCaDgHUK(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int PZvrvsKBfzkYtkZnhjERlYKXBsnX(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int cOnPkhFDpBORauqwXcwdBNwgWFGoA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string gIHFVpNeXgVgsNcGKCGoXawPcYVJ(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int RTiXRYPWpPgpwlbSTZFeAVJKHnwj(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int GCKIFiHFJlQhSktKMNOwDORkuysV(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string iyTByxovCFaakVjarvvcNoujEVMj(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int cbsQGfSgCvwgEnAlPHuksdiHocCV(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int khPAjHrnExFCMeCnncIunCkIlmPkA(CustomController_Editor P_0)
				{
					return P_0.id;
				}

				internal string dITgMntWNWDmAqXleebPetchPJwF(CustomController_Editor P_0)
				{
					return P_0.name;
				}

				internal int sWfsnqCDMTIywBFegRLqPOBzXuwtA(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
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

				internal int RHQYPxgDRQRpqvDscqInilnfahEdA(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string xqGmVwwubstNJKeiEdhojosQIClC(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int HONYAycFmpufJBdFFYEsNrAicthH(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
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

				internal int OJFBTpUjTRLgKGOGhhXmgrccDRMsA(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string gMbeHuFYWgCsIWZMGJoNnyMSWgUg(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int nBWBfYxDsRVgPTFbRbDSxzZnueVj(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
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

				internal int dblDXZURShdsfdqfXlAqSYyzsucGA(Player_Editor P_0)
				{
					return P_0.id;
				}

				internal string JkwmGiNviWjdZnwsJCrjCWBcpYUp(Player_Editor P_0)
				{
					return P_0.name;
				}

				internal int ElThLKqrJGgNxBAvJhZRrtgYWMKQ(Player_Editor P_0, IList<Player_Editor> P_1)
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

				internal int YftRuYsfgiAEjKYnouThGuJTEmCDb(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
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

				internal int jxCkUDTJtrBnVBrtYSkywqIQekmi(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
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

				internal int VWpiDZIOflvduGJMwoEmIAjdGsph(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string xiiaMcbQafCGIjvinmnARRAoxvrKA(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int pyfCLoewyhnOdMAeZAtAmEKSQpyq(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int tvMwovRddakCHkGMrLwQbqtFjqbK(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string MXePGEmPcSTEPmqOWOBldUWDUHkX(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int uOqFbkRDgDezyAhCDCVGZVitWdcr(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int vWWzBMPSKfmhebBILXpnvEPYbRtV(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string wSaxoRfJnEYkzfCUjXrsolsmJoSF(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int PNAohagszwyDkxGLHrytyGTZLynA(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int ImAhMuNatYqXJSLHngzEQDIZOnhV(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string wcqTNOmsEahKPoreQDGEFLonCjXiA(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int TxcdlVIHLeuKrNETwrmmWcKoPDfG(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class iyHDOdNXdduiIklEEnHYWyWkKiFj
			{
				public UserData IHnDMLMzsmkidSGNsrMNLWBPDkMA;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> iWCQkfZRyhygiWyMnEBeeRgQxSTf;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> IvMokQLccLNLoUaifUFmYSfuaGNy;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> TjwIYCibZmxkzWjwBaBtSAUfXHcd;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> iNqveFxyDgAiRGuMRSWqMUUFkxYC;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> qMSyWJTQTIQDqRAUaaIMFfidcKRcb;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> WsgtdBWNVyejthuRWhDvPVfsyTTu;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> rimOtUGrnGTBoruPAuJZqbnNYqzd;

				public Func<ControllerType, List<pBawuQolMdjklghDCGlKaZbDiwpdb>> XoahDbcVwFhqJcKrKNpXQcRlObbA;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> EfWPjWvRNwKODWwacmjeWvPgkkFw;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> uQJSzGoUCjfKebdOhhIwdDYkNUrhA;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> CFUmLtgRUXpZIFTcgzzBPGDGtGSG;

				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> FVOgazjhyQHphsQzuChyDgbFKVDmb;

				internal InputCategory pGFlYqiuQTkWwFFPVsawycdiyIUX(tsrLrNQkDKVAWrqpJnarpxwZfrNk<InputCategory> P_0)
				{
					InputCategory inputCategory = JsonTools.Clone(P_0.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					InputCategory inputCategory2;
					if (P_0.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						inputCategory2 = P_0.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddActionCategory();
						inputCategory2 = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					inputCategory.id = inputCategory2.id;
					int index = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(inputCategory2);
					P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = inputCategory;
					return inputCategory;
				}

				internal InputBehavior nDzIVWJkqMrNRfGQsHTXVUPOPpoh(tsrLrNQkDKVAWrqpJnarpxwZfrNk<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					InputBehavior inputBehavior2;
					if (P_0.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						inputBehavior2 = P_0.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddInputBehavior();
						inputBehavior2 = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(inputBehavior2);
					P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = inputBehavior;
					return inputBehavior;
				}

				internal InputAction AXKDjUYflonHykqFjMYctpHncPGy(tsrLrNQkDKVAWrqpJnarpxwZfrNk<InputAction> P_0)
				{
					CRCmVEggOYzVrbhnCiONBSoYMhmfb cRCmVEggOYzVrbhnCiONBSoYMhmfb = new CRCmVEggOYzVrbhnCiONBSoYMhmfb();
					cRCmVEggOYzVrbhnCiONBSoYMhmfb.LhjWLTBnYDorWWNTDTtcaJZDuqEB = P_0;
					InputAction inputAction = JsonTools.Clone(cRCmVEggOYzVrbhnCiONBSoYMhmfb.LhjWLTBnYDorWWNTDTtcaJZDuqEB.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					int num = iWCQkfZRyhygiWyMnEBeeRgQxSTf.Find(cRCmVEggOYzVrbhnCiONBSoYMhmfb.aJxgRMJEOOhSarnfciCuhMRKxVlVB)?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? 0;
					InputAction inputAction2;
					if (cRCmVEggOYzVrbhnCiONBSoYMhmfb.LhjWLTBnYDorWWNTDTtcaJZDuqEB.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						inputAction2 = cRCmVEggOYzVrbhnCiONBSoYMhmfb.LhjWLTBnYDorWWNTDTtcaJZDuqEB.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddAction(num);
						inputAction2 = cRCmVEggOYzVrbhnCiONBSoYMhmfb.LhjWLTBnYDorWWNTDTtcaJZDuqEB.wzkzUMXuoWGZwTytFdoKNaEajvvj[cRCmVEggOYzVrbhnCiONBSoYMhmfb.LhjWLTBnYDorWWNTDTtcaJZDuqEB.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					int num2 = IvMokQLccLNLoUaifUFmYSfuaGNy.Find(cRCmVEggOYzVrbhnCiONBSoYMhmfb.LUDSeicoQPgKvgVKTGJXasMsDSMEA)?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = num2;
					int index = cRCmVEggOYzVrbhnCiONBSoYMhmfb.LhjWLTBnYDorWWNTDTtcaJZDuqEB.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(inputAction2);
					cRCmVEggOYzVrbhnCiONBSoYMhmfb.LhjWLTBnYDorWWNTDTtcaJZDuqEB.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = inputAction;
					return inputAction;
				}

				internal InputLayout pMEyMkWiCSVGNnJwOQliIArFdlXd(tsrLrNQkDKVAWrqpJnarpxwZfrNk<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					InputLayout inputLayout2;
					if (P_0.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						inputLayout2 = P_0.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddKeyboardLayout();
						inputLayout2 = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(inputLayout2);
					P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout TRxxJvgAmRjQVdGVliDMKLXHknGzA(tsrLrNQkDKVAWrqpJnarpxwZfrNk<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					InputLayout inputLayout2;
					if (P_0.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						inputLayout2 = P_0.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddMouseLayout();
						inputLayout2 = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(inputLayout2);
					P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout TqDrHIhYexTsUlWSdIShgUBSSLvj(tsrLrNQkDKVAWrqpJnarpxwZfrNk<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					InputLayout inputLayout2;
					if (P_0.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						inputLayout2 = P_0.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddJoystickLayout();
						inputLayout2 = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(inputLayout2);
					P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout lpAwgYVegScYKUcfPcvggzvAszHr(tsrLrNQkDKVAWrqpJnarpxwZfrNk<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					InputLayout inputLayout2;
					if (P_0.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						inputLayout2 = P_0.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddCustomControllerLayout();
						inputLayout2 = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(inputLayout2);
					P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = inputLayout;
					return inputLayout;
				}

				internal List<pBawuQolMdjklghDCGlKaZbDiwpdb> xlXtxXtOuHXwmKybrcOLpyHLxPwl(ControllerType P_0)
				{
					return P_0 switch
					{
						ControllerType.Keyboard => TjwIYCibZmxkzWjwBaBtSAUfXHcd, 
						ControllerType.Mouse => iNqveFxyDgAiRGuMRSWqMUUFkxYC, 
						ControllerType.Joystick => qMSyWJTQTIQDqRAUaaIMFfidcKRcb, 
						ControllerType.Custom => WsgtdBWNVyejthuRWhDvPVfsyTTu, 
						_ => throw new NotImplementedException(), 
					};
				}

				internal CustomController_Editor lhcBhzgIdPEvoqZYHlkyrPGnUUqTA(tsrLrNQkDKVAWrqpJnarpxwZfrNk<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					CustomController_Editor customController_Editor2;
					if (P_0.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						customController_Editor2 = P_0.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddCustomController();
						customController_Editor2 = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(customController_Editor2);
					P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = customController_Editor;
					return customController_Editor;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor fnEbhYItrAkLfxYvDjhbNLDqFVWX(tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					jNKIJHJOOyRKGlXjIgoagTztnRGj jNKIJHJOOyRKGlXjIgoagTztnRGj2 = new jNKIJHJOOyRKGlXjIgoagTztnRGj();
					jNKIJHJOOyRKGlXjIgoagTztnRGj2.hpARkksCTYqyowbcVIGLLltOnrOr = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(jNKIJHJOOyRKGlXjIgoagTztnRGj2.hpARkksCTYqyowbcVIGLLltOnrOr.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
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
							EkpbMOhFsERxpMFpDpsIAIEKcoxSB ekpbMOhFsERxpMFpDpsIAIEKcoxSB = new EkpbMOhFsERxpMFpDpsIAIEKcoxSB();
							ekpbMOhFsERxpMFpDpsIAIEKcoxSB.MRvvqpXfcGyeSKdzkhMRyXvMNnkb = jNKIJHJOOyRKGlXjIgoagTztnRGj2;
							ekpbMOhFsERxpMFpDpsIAIEKcoxSB.qcyyFnmxHLJJYFUdqjVkWuvnRpIk = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(ekpbMOhFsERxpMFpDpsIAIEKcoxSB.uQCDPAJRwbpnJypylBfiXEAFEJAo);
							if (pBawuQolMdjklghDCGlKaZbDiwpdb2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + ekpbMOhFsERxpMFpDpsIAIEKcoxSB.qcyyFnmxHLJJYFUdqjVkWuvnRpIk);
							}
							else
							{
								list.Add(pBawuQolMdjklghDCGlKaZbDiwpdb2.fjCCrbwylroUSoEwzUvBsyEpfiGE);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						ohMvksskvtPlvphWoKpZUDXkEkFA ohMvksskvtPlvphWoKpZUDXkEkFA2 = new ohMvksskvtPlvphWoKpZUDXkEkFA();
						ohMvksskvtPlvphWoKpZUDXkEkFA2.pSFydNfiGuhgzDzewccynaTtesgC = jNKIJHJOOyRKGlXjIgoagTztnRGj2;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<pBawuQolMdjklghDCGlKaZbDiwpdb> list2 = XoahDbcVwFhqJcKrKNpXQcRlObbA(controllerType);
							ohMvksskvtPlvphWoKpZUDXkEkFA2.yrYdpKxfCvstAoogOFBWNTzgsItH = controllerMapLayoutManager_Rule_Editor2.layoutId;
							pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = list2.Find(ohMvksskvtPlvphWoKpZUDXkEkFA2.XEsKIGtfLDZSAFoFgHHhLXehmLkn);
							if (pBawuQolMdjklghDCGlKaZbDiwpdb3 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + ohMvksskvtPlvphWoKpZUDXkEkFA2.yrYdpKxfCvstAoogOFBWNTzgsItH);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = pBawuQolMdjklghDCGlKaZbDiwpdb3.fjCCrbwylroUSoEwzUvBsyEpfiGE;
							}
						}
					}
					int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							nduioacprRYudyfBrcrXAzjCJTDy nduioacprRYudyfBrcrXAzjCJTDy2 = new nduioacprRYudyfBrcrXAzjCJTDy();
							nduioacprRYudyfBrcrXAzjCJTDy2.fnZozhkrBWOUfCnNcieJAUssRTqX = jNKIJHJOOyRKGlXjIgoagTztnRGj2;
							List<pBawuQolMdjklghDCGlKaZbDiwpdb> efWPjWvRNwKODWwacmjeWvPgkkFw = EfWPjWvRNwKODWwacmjeWvPgkkFw;
							nduioacprRYudyfBrcrXAzjCJTDy2.JTcdPhhApPEsJMdMsqoiEtGSsAxzA = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb4 = efWPjWvRNwKODWwacmjeWvPgkkFw.Find(nduioacprRYudyfBrcrXAzjCJTDy2.kEgJKJTBPflPfjTtuhvKBAFicbXZ);
							if (pBawuQolMdjklghDCGlKaZbDiwpdb4 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + nduioacprRYudyfBrcrXAzjCJTDy2.JTcdPhhApPEsJMdMsqoiEtGSsAxzA);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = pBawuQolMdjklghDCGlKaZbDiwpdb4.fjCCrbwylroUSoEwzUvBsyEpfiGE;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (jNKIJHJOOyRKGlXjIgoagTztnRGj2.hpARkksCTYqyowbcVIGLLltOnrOr.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = jNKIJHJOOyRKGlXjIgoagTztnRGj2.hpARkksCTYqyowbcVIGLLltOnrOr.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = jNKIJHJOOyRKGlXjIgoagTztnRGj2.hpARkksCTYqyowbcVIGLLltOnrOr.wzkzUMXuoWGZwTytFdoKNaEajvvj[jNKIJHJOOyRKGlXjIgoagTztnRGj2.hpARkksCTYqyowbcVIGLLltOnrOr.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = jNKIJHJOOyRKGlXjIgoagTztnRGj2.hpARkksCTYqyowbcVIGLLltOnrOr.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					jNKIJHJOOyRKGlXjIgoagTztnRGj2.hpARkksCTYqyowbcVIGLLltOnrOr.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				internal ControllerMapEnabler_RuleSet_Editor XZBwoKTiWuNzLMkQSVOohqVdebx(tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					mqylOJJcdjHardFZphcNIiIIKRtHA mqylOJJcdjHardFZphcNIiIIKRtHA2 = new mqylOJJcdjHardFZphcNIiIIKRtHA();
					mqylOJJcdjHardFZphcNIiIIKRtHA2.DCIMpNscnCFNvjxtfsyeAmEiBYom = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(mqylOJJcdjHardFZphcNIiIIKRtHA2.DCIMpNscnCFNvjxtfsyeAmEiBYom.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
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
							WutgRlSUAZBPSjETRHtDzeXPmWwrA wutgRlSUAZBPSjETRHtDzeXPmWwrA = new WutgRlSUAZBPSjETRHtDzeXPmWwrA();
							wutgRlSUAZBPSjETRHtDzeXPmWwrA.pCDXPqviNrOZsRrlmbuBUtnEmYoD = mqylOJJcdjHardFZphcNIiIIKRtHA2;
							wutgRlSUAZBPSjETRHtDzeXPmWwrA.MaoZVdDzjrAwpVnQzsdPDKBvikHT = controllerMapEnabler_Rule_Editor.categoryIds[j];
							pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(wutgRlSUAZBPSjETRHtDzeXPmWwrA.cXrXnwbpMIQonBhgSHoxfcmmTxwQ);
							if (pBawuQolMdjklghDCGlKaZbDiwpdb2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + wutgRlSUAZBPSjETRHtDzeXPmWwrA.MaoZVdDzjrAwpVnQzsdPDKBvikHT);
							}
							else
							{
								list.Add(pBawuQolMdjklghDCGlKaZbDiwpdb2.fjCCrbwylroUSoEwzUvBsyEpfiGE);
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
						List<pBawuQolMdjklghDCGlKaZbDiwpdb> list2 = XoahDbcVwFhqJcKrKNpXQcRlObbA(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							geOATIgRPJnQCHVCtnzHAWarnFqoA geOATIgRPJnQCHVCtnzHAWarnFqoA2 = new geOATIgRPJnQCHVCtnzHAWarnFqoA();
							geOATIgRPJnQCHVCtnzHAWarnFqoA2.kjBKtOLRKMpYUgjjZeMLVEXmFzfl = mqylOJJcdjHardFZphcNIiIIKRtHA2;
							geOATIgRPJnQCHVCtnzHAWarnFqoA2.tIgRgEnlLZDwsxhfRSBcDkreBnWm = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = list2.Find(geOATIgRPJnQCHVCtnzHAWarnFqoA2.CAFdfrwNxxaBGaXQmgyBXMONwiVb);
							if (pBawuQolMdjklghDCGlKaZbDiwpdb3 == null)
							{
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + geOATIgRPJnQCHVCtnzHAWarnFqoA2.tIgRgEnlLZDwsxhfRSBcDkreBnWm);
							}
							else
							{
								list3.Add(pBawuQolMdjklghDCGlKaZbDiwpdb3.fjCCrbwylroUSoEwzUvBsyEpfiGE);
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
							tsfSwvNCJfUDUpZobfQNrUgwjGIf tsfSwvNCJfUDUpZobfQNrUgwjGIf2 = new tsfSwvNCJfUDUpZobfQNrUgwjGIf();
							tsfSwvNCJfUDUpZobfQNrUgwjGIf2.SKskHKRyUbotPTrpyYhAgyVXrYTj = mqylOJJcdjHardFZphcNIiIIKRtHA2;
							List<pBawuQolMdjklghDCGlKaZbDiwpdb> efWPjWvRNwKODWwacmjeWvPgkkFw = EfWPjWvRNwKODWwacmjeWvPgkkFw;
							tsfSwvNCJfUDUpZobfQNrUgwjGIf2.DFwvBuhNZuswCXIOccKvccKGPGME = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb4 = efWPjWvRNwKODWwacmjeWvPgkkFw.Find(tsfSwvNCJfUDUpZobfQNrUgwjGIf2.baXuUFBvSwzaxQdeedwfOeatueNw);
							if (pBawuQolMdjklghDCGlKaZbDiwpdb4 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + tsfSwvNCJfUDUpZobfQNrUgwjGIf2.DFwvBuhNZuswCXIOccKvccKGPGME);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = pBawuQolMdjklghDCGlKaZbDiwpdb4.fjCCrbwylroUSoEwzUvBsyEpfiGE;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (mqylOJJcdjHardFZphcNIiIIKRtHA2.DCIMpNscnCFNvjxtfsyeAmEiBYom.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						controllerMapEnabler_RuleSet_Editor2 = mqylOJJcdjHardFZphcNIiIIKRtHA2.DCIMpNscnCFNvjxtfsyeAmEiBYom.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = mqylOJJcdjHardFZphcNIiIIKRtHA2.DCIMpNscnCFNvjxtfsyeAmEiBYom.wzkzUMXuoWGZwTytFdoKNaEajvvj[mqylOJJcdjHardFZphcNIiIIKRtHA2.DCIMpNscnCFNvjxtfsyeAmEiBYom.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = mqylOJJcdjHardFZphcNIiIIKRtHA2.DCIMpNscnCFNvjxtfsyeAmEiBYom.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					mqylOJJcdjHardFZphcNIiIIKRtHA2.DCIMpNscnCFNvjxtfsyeAmEiBYom.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				internal Player_Editor woYoTKpHaOZIqusZTfCJKbJbVKPy(tsrLrNQkDKVAWrqpJnarpxwZfrNk<Player_Editor> P_0)
				{
					BzMAcHEyphqUeWEztCUGNYtlUQIc bzMAcHEyphqUeWEztCUGNYtlUQIc = new BzMAcHEyphqUeWEztCUGNYtlUQIc();
					bzMAcHEyphqUeWEztCUGNYtlUQIc.VEWvECtJgBUHMHEJRJdWiuAiVPPk = this;
					bzMAcHEyphqUeWEztCUGNYtlUQIc.bMjGsmbFwpYfrNaEOpttORwgmUIqA = P_0;
					Player_Editor player_Editor = JsonTools.Clone(bzMAcHEyphqUeWEztCUGNYtlUQIc.bMjGsmbFwpYfrNaEOpttORwgmUIqA.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					Action<List<Player_Editor.Mapping>, List<pBawuQolMdjklghDCGlKaZbDiwpdb>> action = bzMAcHEyphqUeWEztCUGNYtlUQIc.ppCZfYpSXKkPsimahkcuhyCDiIVD;
					action(player_Editor.defaultKeyboardMaps, TjwIYCibZmxkzWjwBaBtSAUfXHcd);
					action(player_Editor.defaultMouseMaps, iNqveFxyDgAiRGuMRSWqMUUFkxYC);
					action(player_Editor.defaultJoystickMaps, qMSyWJTQTIQDqRAUaaIMFfidcKRcb);
					action(player_Editor.defaultCustomControllerMaps, WsgtdBWNVyejthuRWhDvPVfsyTTu);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						cpjmCHuokhADFIvUrNpCcLfzlLvBb cpjmCHuokhADFIvUrNpCcLfzlLvBb2 = new cpjmCHuokhADFIvUrNpCcLfzlLvBb();
						cpjmCHuokhADFIvUrNpCcLfzlLvBb2.RbAfdvkIbycuaAvreLRUZVWxbbMUA = bzMAcHEyphqUeWEztCUGNYtlUQIc;
						cpjmCHuokhADFIvUrNpCcLfzlLvBb2.UgJOAqMIEbxhDVCXkJYAhnhBkcQB = player_Editor.startingCustomControllers[i];
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = EfWPjWvRNwKODWwacmjeWvPgkkFw.Find(cpjmCHuokhADFIvUrNpCcLfzlLvBb2.NudWDFzGQyakfaUuDspvMLGXZSagA);
						cpjmCHuokhADFIvUrNpCcLfzlLvBb2.UgJOAqMIEbxhDVCXkJYAhnhBkcQB.sourceId = pBawuQolMdjklghDCGlKaZbDiwpdb2?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						yQmVCJDIufvzVAuBrKIBFgftOqDn yQmVCJDIufvzVAuBrKIBFgftOqDn2 = new yQmVCJDIufvzVAuBrKIBFgftOqDn();
						yQmVCJDIufvzVAuBrKIBFgftOqDn2.zMqKRkMiWnKpyyphJITgFkmVFDcg = bzMAcHEyphqUeWEztCUGNYtlUQIc;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							yQmVCJDIufvzVAuBrKIBFgftOqDn2.GgmETQIuZZlbCpKhFScpErskfbH = ruleSetMapping.id;
							pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = uQJSzGoUCjfKebdOhhIwdDYkNUrhA.Find(yQmVCJDIufvzVAuBrKIBFgftOqDn2.sJmffdfWgStzadKpKMOEQjtRtMtg);
							if (pBawuQolMdjklghDCGlKaZbDiwpdb3 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + yQmVCJDIufvzVAuBrKIBFgftOqDn2.GgmETQIuZZlbCpKhFScpErskfbH);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = pBawuQolMdjklghDCGlKaZbDiwpdb3.fjCCrbwylroUSoEwzUvBsyEpfiGE;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						daDgXbcbNwpLbgsOobVFnfbSFQRU daDgXbcbNwpLbgsOobVFnfbSFQRU2 = new daDgXbcbNwpLbgsOobVFnfbSFQRU();
						daDgXbcbNwpLbgsOobVFnfbSFQRU2.MyxQgtgPdEKGoMJCrrhzYJrSFiLkA = bzMAcHEyphqUeWEztCUGNYtlUQIc;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							daDgXbcbNwpLbgsOobVFnfbSFQRU2.TAOAMuchbWrWifFwOhFxEPYnWgRA = ruleSetMapping2.id;
							pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb4 = CFUmLtgRUXpZIFTcgzzBPGDGtGSG.Find(daDgXbcbNwpLbgsOobVFnfbSFQRU2.mmFcrhJgmdfleapyKRIHjOcFKQHnb);
							if (pBawuQolMdjklghDCGlKaZbDiwpdb4 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + daDgXbcbNwpLbgsOobVFnfbSFQRU2.TAOAMuchbWrWifFwOhFxEPYnWgRA);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = pBawuQolMdjklghDCGlKaZbDiwpdb4.fjCCrbwylroUSoEwzUvBsyEpfiGE;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (bzMAcHEyphqUeWEztCUGNYtlUQIc.bMjGsmbFwpYfrNaEOpttORwgmUIqA.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						player_Editor2 = bzMAcHEyphqUeWEztCUGNYtlUQIc.bMjGsmbFwpYfrNaEOpttORwgmUIqA.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.YftRuYsfgiAEjKYnouThGuJTEmCDb;
						zCvFMbJjzXQmgAHcPrEadMkebAXlB(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						zCvFMbJjzXQmgAHcPrEadMkebAXlB(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						zCvFMbJjzXQmgAHcPrEadMkebAXlB(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						zCvFMbJjzXQmgAHcPrEadMkebAXlB(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						zCvFMbJjzXQmgAHcPrEadMkebAXlB(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.jxCkUDTJtrBnVBrtYSkywqIQekmi);
						player_Editor = player_Editor3;
					}
					else
					{
						IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddPlayer();
						player_Editor2 = bzMAcHEyphqUeWEztCUGNYtlUQIc.bMjGsmbFwpYfrNaEOpttORwgmUIqA.wzkzUMXuoWGZwTytFdoKNaEajvvj[bzMAcHEyphqUeWEztCUGNYtlUQIc.bMjGsmbFwpYfrNaEOpttORwgmUIqA.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = bzMAcHEyphqUeWEztCUGNYtlUQIc.bMjGsmbFwpYfrNaEOpttORwgmUIqA.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(player_Editor2);
					bzMAcHEyphqUeWEztCUGNYtlUQIc.bMjGsmbFwpYfrNaEOpttORwgmUIqA.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = player_Editor;
					return player_Editor;
				}
			}

			private sealed class CRCmVEggOYzVrbhnCiONBSoYMhmfb
			{
				public tsrLrNQkDKVAWrqpJnarpxwZfrNk<InputAction> LhjWLTBnYDorWWNTDTtcaJZDuqEB;

				internal bool aJxgRMJEOOhSarnfciCuhMRKxVlVB(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(LhjWLTBnYDorWWNTDTtcaJZDuqEB.OgjsbVPCjFotsZfkNMuatUlsIVxq) == LhjWLTBnYDorWWNTDTtcaJZDuqEB.ClgpBfRiGnCqWaKEFoUEvjOIUsFC.categoryId;
				}

				internal bool LUDSeicoQPgKvgVKTGJXasMsDSMEA(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(LhjWLTBnYDorWWNTDTtcaJZDuqEB.OgjsbVPCjFotsZfkNMuatUlsIVxq) == LhjWLTBnYDorWWNTDTtcaJZDuqEB.ClgpBfRiGnCqWaKEFoUEvjOIUsFC.behaviorId;
				}
			}

			private sealed class geOATIgRPJnQCHVCtnzHAWarnFqoA
			{
				public int tIgRgEnlLZDwsxhfRSBcDkreBnWm;

				public mqylOJJcdjHardFZphcNIiIIKRtHA kjBKtOLRKMpYUgjjZeMLVEXmFzfl;

				internal bool CAFdfrwNxxaBGaXQmgyBXMONwiVb(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(kjBKtOLRKMpYUgjjZeMLVEXmFzfl.DCIMpNscnCFNvjxtfsyeAmEiBYom.OgjsbVPCjFotsZfkNMuatUlsIVxq) == tIgRgEnlLZDwsxhfRSBcDkreBnWm;
				}
			}

			private sealed class tsfSwvNCJfUDUpZobfQNrUgwjGIf
			{
				public int DFwvBuhNZuswCXIOccKvccKGPGME;

				public mqylOJJcdjHardFZphcNIiIIKRtHA SKskHKRyUbotPTrpyYhAgyVXrYTj;

				internal bool baXuUFBvSwzaxQdeedwfOeatueNw(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(SKskHKRyUbotPTrpyYhAgyVXrYTj.DCIMpNscnCFNvjxtfsyeAmEiBYom.OgjsbVPCjFotsZfkNMuatUlsIVxq) == DFwvBuhNZuswCXIOccKvccKGPGME;
				}
			}

			private sealed class BzMAcHEyphqUeWEztCUGNYtlUQIc
			{
				public tsrLrNQkDKVAWrqpJnarpxwZfrNk<Player_Editor> bMjGsmbFwpYfrNaEOpttORwgmUIqA;

				public iyHDOdNXdduiIklEEnHYWyWkKiFj VEWvECtJgBUHMHEJRJdWiuAiVPPk;

				internal void ppCZfYpSXKkPsimahkcuhyCDiIVD(List<Player_Editor.Mapping> P_0, List<pBawuQolMdjklghDCGlKaZbDiwpdb> P_1)
				{
					for (int i = 0; i < P_0.Count; i++)
					{
						QrSzbNtnByIWiScVByIglpyufpQo qrSzbNtnByIWiScVByIglpyufpQo = new QrSzbNtnByIWiScVByIglpyufpQo();
						qrSzbNtnByIWiScVByIglpyufpQo.EdCoAxFDPvFTVlxFYcbKDKOhbtTx = this;
						qrSzbNtnByIWiScVByIglpyufpQo.CSBKMalyGntXxDaYPZKyPVxnjePn = P_0[i];
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = VEWvECtJgBUHMHEJRJdWiuAiVPPk.rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(qrSzbNtnByIWiScVByIglpyufpQo.DKdFCrckQGRhdJzCKdiCzkwWadIpA);
						qrSzbNtnByIWiScVByIglpyufpQo.CSBKMalyGntXxDaYPZKyPVxnjePn.categoryId = pBawuQolMdjklghDCGlKaZbDiwpdb2?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
						pBawuQolMdjklghDCGlKaZbDiwpdb2 = P_1.Find(qrSzbNtnByIWiScVByIglpyufpQo.LnwdIvRsuMHrdGKIhwLdqcpBmvYX);
						qrSzbNtnByIWiScVByIglpyufpQo.CSBKMalyGntXxDaYPZKyPVxnjePn.layoutId = pBawuQolMdjklghDCGlKaZbDiwpdb2?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					}
				}
			}

			private sealed class QrSzbNtnByIWiScVByIglpyufpQo
			{
				public Player_Editor.Mapping CSBKMalyGntXxDaYPZKyPVxnjePn;

				public BzMAcHEyphqUeWEztCUGNYtlUQIc EdCoAxFDPvFTVlxFYcbKDKOhbtTx;

				internal bool DKdFCrckQGRhdJzCKdiCzkwWadIpA(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(EdCoAxFDPvFTVlxFYcbKDKOhbtTx.bMjGsmbFwpYfrNaEOpttORwgmUIqA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == CSBKMalyGntXxDaYPZKyPVxnjePn.categoryId;
				}

				internal bool LnwdIvRsuMHrdGKIhwLdqcpBmvYX(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(EdCoAxFDPvFTVlxFYcbKDKOhbtTx.bMjGsmbFwpYfrNaEOpttORwgmUIqA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == CSBKMalyGntXxDaYPZKyPVxnjePn.layoutId;
				}
			}

			private sealed class cpjmCHuokhADFIvUrNpCcLfzlLvBb
			{
				public Player_Editor.CreateControllerInfo UgJOAqMIEbxhDVCXkJYAhnhBkcQB;

				public BzMAcHEyphqUeWEztCUGNYtlUQIc RbAfdvkIbycuaAvreLRUZVWxbbMUA;

				internal bool NudWDFzGQyakfaUuDspvMLGXZSagA(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(RbAfdvkIbycuaAvreLRUZVWxbbMUA.bMjGsmbFwpYfrNaEOpttORwgmUIqA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == UgJOAqMIEbxhDVCXkJYAhnhBkcQB.sourceId;
				}
			}

			private sealed class yQmVCJDIufvzVAuBrKIBFgftOqDn
			{
				public int GgmETQIuZZlbCpKhFScpErskfbH;

				public BzMAcHEyphqUeWEztCUGNYtlUQIc zMqKRkMiWnKpyyphJITgFkmVFDcg;

				internal bool sJmffdfWgStzadKpKMOEQjtRtMtg(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(zMqKRkMiWnKpyyphJITgFkmVFDcg.bMjGsmbFwpYfrNaEOpttORwgmUIqA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == GgmETQIuZZlbCpKhFScpErskfbH;
				}
			}

			private sealed class daDgXbcbNwpLbgsOobVFnfbSFQRU
			{
				public int TAOAMuchbWrWifFwOhFxEPYnWgRA;

				public BzMAcHEyphqUeWEztCUGNYtlUQIc MyxQgtgPdEKGoMJCrrhzYJrSFiLkA;

				internal bool mmFcrhJgmdfleapyKRIHjOcFKQHnb(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(MyxQgtgPdEKGoMJCrrhzYJrSFiLkA.bMjGsmbFwpYfrNaEOpttORwgmUIqA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == TAOAMuchbWrWifFwOhFxEPYnWgRA;
				}
			}

			private sealed class MBTynBEEKqurBAPUJxSlqjDYbkmQ
			{
				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> VxtgVtfaAzdkREJZIUSYQVfyjBcP;

				public iyHDOdNXdduiIklEEnHYWyWkKiFj YeNstIQGHTQBhXgjEtNzWcrUuJHr;

				internal int bbwlmTOTRgitencULVtwOnOrNxz(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					vUSnKHtMYKdjFjUCYjpnJiZyfKtZ vUSnKHtMYKdjFjUCYjpnJiZyfKtZ2 = new vUSnKHtMYKdjFjUCYjpnJiZyfKtZ();
					vUSnKHtMYKdjFjUCYjpnJiZyfKtZ2.prmbpPBIzuwKqGZAsvSHzymHnFMr = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = YeNstIQGHTQBhXgjEtNzWcrUuJHr.rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(vUSnKHtMYKdjFjUCYjpnJiZyfKtZ2.KctnTrVAxPImhyKlugSZAktYgpYCA);
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = VxtgVtfaAzdkREJZIUSYQVfyjBcP.Find(vUSnKHtMYKdjFjUCYjpnJiZyfKtZ2.EwfDfAvnOVQOUlNTYUaECvgmMbTs);
						if (pBawuQolMdjklghDCGlKaZbDiwpdb2 != null && pBawuQolMdjklghDCGlKaZbDiwpdb2.fjCCrbwylroUSoEwzUvBsyEpfiGE == P_1[i].categoryId && pBawuQolMdjklghDCGlKaZbDiwpdb3 != null && pBawuQolMdjklghDCGlKaZbDiwpdb3.fjCCrbwylroUSoEwzUvBsyEpfiGE == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor tKTCTLgwpxBqDPyZJdsuLSELzqAF(tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMap_Editor> P_0)
				{
					YLCpvcEzSXbkBBrvMqXQarYPCVAr yLCpvcEzSXbkBBrvMqXQarYPCVAr = new YLCpvcEzSXbkBBrvMqXQarYPCVAr();
					yLCpvcEzSXbkBBrvMqXQarYPCVAr.fNOaPShAIwMJkuOjqDJaGTtymmQzA = P_0;
					yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA = JsonTools.Clone(yLCpvcEzSXbkBBrvMqXQarYPCVAr.fNOaPShAIwMJkuOjqDJaGTtymmQzA.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = YeNstIQGHTQBhXgjEtNzWcrUuJHr.rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(yLCpvcEzSXbkBBrvMqXQarYPCVAr.hOJhOVwyeATVapFcSVSonoNtNDLR);
					pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = VxtgVtfaAzdkREJZIUSYQVfyjBcP.Find(yLCpvcEzSXbkBBrvMqXQarYPCVAr.uCgrkOKgCOFzxgtslNetBiQhJvlm);
					yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA.categoryId = pBawuQolMdjklghDCGlKaZbDiwpdb2?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA.layoutId = pBawuQolMdjklghDCGlKaZbDiwpdb3?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					for (int i = 0; i < yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA.actionElementMaps.Count; i++)
					{
						vRVbdzRsiPvApGgOiyCOVAzpWVRA vRVbdzRsiPvApGgOiyCOVAzpWVRA2 = new vRVbdzRsiPvApGgOiyCOVAzpWVRA();
						vRVbdzRsiPvApGgOiyCOVAzpWVRA2.KuaSZEQxtstnLSsJeMQKiOyrZcBm = yLCpvcEzSXbkBBrvMqXQarYPCVAr;
						vRVbdzRsiPvApGgOiyCOVAzpWVRA2.gwHkKsWXGUuCDoscsqGbHbjggohCA = vRVbdzRsiPvApGgOiyCOVAzpWVRA2.KuaSZEQxtstnLSsJeMQKiOyrZcBm.miqiSoJRdlHFNoiFfxhGqlareqOHA.actionElementMaps[i];
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb4 = YeNstIQGHTQBhXgjEtNzWcrUuJHr.FVOgazjhyQHphsQzuChyDgbFKVDmb.Find(vRVbdzRsiPvApGgOiyCOVAzpWVRA2.ozvCoBpZDSgeQdCfCIyUGRlAyeiqA);
						vRVbdzRsiPvApGgOiyCOVAzpWVRA2.gwHkKsWXGUuCDoscsqGbHbjggohCA._actionId = pBawuQolMdjklghDCGlKaZbDiwpdb4?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
						vRVbdzRsiPvApGgOiyCOVAzpWVRA2.gwHkKsWXGUuCDoscsqGbHbjggohCA._actionCategoryId = ((YeNstIQGHTQBhXgjEtNzWcrUuJHr.IHnDMLMzsmkidSGNsrMNLWBPDkMA.GetActionById(vRVbdzRsiPvApGgOiyCOVAzpWVRA2.gwHkKsWXGUuCDoscsqGbHbjggohCA._actionId) != null) ? YeNstIQGHTQBhXgjEtNzWcrUuJHr.IHnDMLMzsmkidSGNsrMNLWBPDkMA.GetActionById(vRVbdzRsiPvApGgOiyCOVAzpWVRA2.gwHkKsWXGUuCDoscsqGbHbjggohCA._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (yLCpvcEzSXbkBBrvMqXQarYPCVAr.fNOaPShAIwMJkuOjqDJaGTtymmQzA.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						controllerMap_Editor = yLCpvcEzSXbkBBrvMqXQarYPCVAr.fNOaPShAIwMJkuOjqDJaGTtymmQzA.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.pyfCLoewyhnOdMAeZAtAmEKSQpyq;
						zCvFMbJjzXQmgAHcPrEadMkebAXlB(controllerMap_Editor.actionElementMaps, yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA = controllerMap_Editor2;
					}
					else
					{
						YeNstIQGHTQBhXgjEtNzWcrUuJHr.IHnDMLMzsmkidSGNsrMNLWBPDkMA.CreateKeyboardMap(yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA.categoryId, yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA.layoutId);
						controllerMap_Editor = yLCpvcEzSXbkBBrvMqXQarYPCVAr.fNOaPShAIwMJkuOjqDJaGTtymmQzA.wzkzUMXuoWGZwTytFdoKNaEajvvj[yLCpvcEzSXbkBBrvMqXQarYPCVAr.fNOaPShAIwMJkuOjqDJaGTtymmQzA.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA.id = controllerMap_Editor.id;
					int index = yLCpvcEzSXbkBBrvMqXQarYPCVAr.fNOaPShAIwMJkuOjqDJaGTtymmQzA.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(controllerMap_Editor);
					yLCpvcEzSXbkBBrvMqXQarYPCVAr.fNOaPShAIwMJkuOjqDJaGTtymmQzA.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA;
					return yLCpvcEzSXbkBBrvMqXQarYPCVAr.miqiSoJRdlHFNoiFfxhGqlareqOHA;
				}
			}

			private sealed class vUSnKHtMYKdjFjUCYjpnJiZyfKtZ
			{
				public ControllerMap_Editor prmbpPBIzuwKqGZAsvSHzymHnFMr;

				public Predicate<pBawuQolMdjklghDCGlKaZbDiwpdb> xVZqstUSabzeARQXANfrAOnMrqSI;

				public Predicate<pBawuQolMdjklghDCGlKaZbDiwpdb> EfHvFKabExcrrRZSeVgZNeliBlkQ;

				internal bool KctnTrVAxPImhyKlugSZAktYgpYCA(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.gsqverUIpgWdltzmADzPvzFqPagx == prmbpPBIzuwKqGZAsvSHzymHnFMr.categoryId;
				}

				internal bool EwfDfAvnOVQOUlNTYUaECvgmMbTs(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.gsqverUIpgWdltzmADzPvzFqPagx == prmbpPBIzuwKqGZAsvSHzymHnFMr.layoutId;
				}
			}

			private sealed class YLCpvcEzSXbkBBrvMqXQarYPCVAr
			{
				public tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMap_Editor> fNOaPShAIwMJkuOjqDJaGTtymmQzA;

				public ControllerMap_Editor miqiSoJRdlHFNoiFfxhGqlareqOHA;

				internal bool hOJhOVwyeATVapFcSVSonoNtNDLR(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(fNOaPShAIwMJkuOjqDJaGTtymmQzA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == miqiSoJRdlHFNoiFfxhGqlareqOHA.categoryId;
				}

				internal bool uCgrkOKgCOFzxgtslNetBiQhJvlm(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(fNOaPShAIwMJkuOjqDJaGTtymmQzA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == miqiSoJRdlHFNoiFfxhGqlareqOHA.layoutId;
				}
			}

			private sealed class QVcvlGPnSYWdHNPDdiXKBrEvHbmIA
			{
				public List<int> VkWipIYogvmXWVBqSoOhSYnVBjci;

				public iyHDOdNXdduiIklEEnHYWyWkKiFj QgryImmZdJxtmWrohFrMBXPQiQdg;

				internal InputMapCategory iWLdKWTuGcTYmvXtjqRVWAYpaNpCA(tsrLrNQkDKVAWrqpJnarpxwZfrNk<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					InputMapCategory inputMapCategory2;
					if (P_0.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						inputMapCategory2 = P_0.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
					}
					else
					{
						QgryImmZdJxtmWrohFrMBXPQiQdg.IHnDMLMzsmkidSGNsrMNLWBPDkMA.AddMapCategory();
						inputMapCategory2 = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					int num = P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(inputMapCategory2);
					if (P_0.OgjsbVPCjFotsZfkNMuatUlsIVxq == pBawuQolMdjklghDCGlKaZbDiwpdb.XmVdHpntFUqyoWuHKSOagHJccsFT.otherId)
					{
						VkWipIYogvmXWVBqSoOhSYnVBjci.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.wzkzUMXuoWGZwTytFdoKNaEajvvj[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class vRVbdzRsiPvApGgOiyCOVAzpWVRA
			{
				public ActionElementMap gwHkKsWXGUuCDoscsqGbHbjggohCA;

				public YLCpvcEzSXbkBBrvMqXQarYPCVAr KuaSZEQxtstnLSsJeMQKiOyrZcBm;

				internal bool ozvCoBpZDSgeQdCfCIyUGRlAyeiqA(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(KuaSZEQxtstnLSsJeMQKiOyrZcBm.fNOaPShAIwMJkuOjqDJaGTtymmQzA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == gwHkKsWXGUuCDoscsqGbHbjggohCA._actionId;
				}
			}

			private sealed class hgiiLBDkSVjycgwXmttZkPSPmylyA
			{
				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> PCgcphKZcbmUfdeqkrCMelSxzpeR;

				public iyHDOdNXdduiIklEEnHYWyWkKiFj CKthQBNwVuoHCEVVgTKUqXBMkIsM;

				internal int rTsZEdWhtEbsWHuSNoLtYqWOHNsI(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					cBarpJFvErtcoenkEadLWIQToFhg cBarpJFvErtcoenkEadLWIQToFhg2 = new cBarpJFvErtcoenkEadLWIQToFhg();
					cBarpJFvErtcoenkEadLWIQToFhg2.EBdlbSZHYomPtinoVOiwGqyEdiIcA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = CKthQBNwVuoHCEVVgTKUqXBMkIsM.rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(cBarpJFvErtcoenkEadLWIQToFhg2.sGpXUMUZeFuBagOTeSCxwIYdDRefA);
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = PCgcphKZcbmUfdeqkrCMelSxzpeR.Find(cBarpJFvErtcoenkEadLWIQToFhg2.SDeahQatiAyvkNDRlNKwdDuohJIV);
						if (pBawuQolMdjklghDCGlKaZbDiwpdb2 != null && pBawuQolMdjklghDCGlKaZbDiwpdb2.fjCCrbwylroUSoEwzUvBsyEpfiGE == P_1[i].categoryId && pBawuQolMdjklghDCGlKaZbDiwpdb3 != null && pBawuQolMdjklghDCGlKaZbDiwpdb3.fjCCrbwylroUSoEwzUvBsyEpfiGE == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor mQKaCWbXLkOtgspzLggAbBrdGDmbc(tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMap_Editor> P_0)
				{
					WhNnnqfriotSIkOuPfVNONZGcGTJ whNnnqfriotSIkOuPfVNONZGcGTJ = new WhNnnqfriotSIkOuPfVNONZGcGTJ();
					whNnnqfriotSIkOuPfVNONZGcGTJ.CwKcIweYXQHPBDUAnaOoKQsEIMywA = P_0;
					whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw = JsonTools.Clone(whNnnqfriotSIkOuPfVNONZGcGTJ.CwKcIweYXQHPBDUAnaOoKQsEIMywA.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = CKthQBNwVuoHCEVVgTKUqXBMkIsM.rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(whNnnqfriotSIkOuPfVNONZGcGTJ.ogDlmyIWrvitTQJglNDaJrfBNURW);
					pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = PCgcphKZcbmUfdeqkrCMelSxzpeR.Find(whNnnqfriotSIkOuPfVNONZGcGTJ.FAJslXwoXHJnXueIxRDkAvtACXXD);
					whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw.categoryId = pBawuQolMdjklghDCGlKaZbDiwpdb2?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw.layoutId = pBawuQolMdjklghDCGlKaZbDiwpdb3?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					for (int i = 0; i < whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw.actionElementMaps.Count; i++)
					{
						CJPhtejlooHVpAkflZodklIeXDBbA cJPhtejlooHVpAkflZodklIeXDBbA = new CJPhtejlooHVpAkflZodklIeXDBbA();
						cJPhtejlooHVpAkflZodklIeXDBbA.fRfMFVTBBOCmcAfgSlilHeyiizOWB = whNnnqfriotSIkOuPfVNONZGcGTJ;
						cJPhtejlooHVpAkflZodklIeXDBbA.zNZbHBOwuPkgzdiCuOCMzaMiyPSm = cJPhtejlooHVpAkflZodklIeXDBbA.fRfMFVTBBOCmcAfgSlilHeyiizOWB.PcdhsVDgjxKHtXDEVMNsydZaQAEw.actionElementMaps[i];
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb4 = CKthQBNwVuoHCEVVgTKUqXBMkIsM.FVOgazjhyQHphsQzuChyDgbFKVDmb.Find(cJPhtejlooHVpAkflZodklIeXDBbA.mdOpJyyCzZuLrSsHUmlNUFSYyNYn);
						cJPhtejlooHVpAkflZodklIeXDBbA.zNZbHBOwuPkgzdiCuOCMzaMiyPSm._actionId = pBawuQolMdjklghDCGlKaZbDiwpdb4?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
						cJPhtejlooHVpAkflZodklIeXDBbA.zNZbHBOwuPkgzdiCuOCMzaMiyPSm._actionCategoryId = ((CKthQBNwVuoHCEVVgTKUqXBMkIsM.IHnDMLMzsmkidSGNsrMNLWBPDkMA.GetActionById(cJPhtejlooHVpAkflZodklIeXDBbA.zNZbHBOwuPkgzdiCuOCMzaMiyPSm._actionId) != null) ? CKthQBNwVuoHCEVVgTKUqXBMkIsM.IHnDMLMzsmkidSGNsrMNLWBPDkMA.GetActionById(cJPhtejlooHVpAkflZodklIeXDBbA.zNZbHBOwuPkgzdiCuOCMzaMiyPSm._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (whNnnqfriotSIkOuPfVNONZGcGTJ.CwKcIweYXQHPBDUAnaOoKQsEIMywA.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						controllerMap_Editor = whNnnqfriotSIkOuPfVNONZGcGTJ.CwKcIweYXQHPBDUAnaOoKQsEIMywA.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.uOqFbkRDgDezyAhCDCVGZVitWdcr;
						zCvFMbJjzXQmgAHcPrEadMkebAXlB(controllerMap_Editor.actionElementMaps, whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw = controllerMap_Editor2;
					}
					else
					{
						CKthQBNwVuoHCEVVgTKUqXBMkIsM.IHnDMLMzsmkidSGNsrMNLWBPDkMA.CreateMouseMap(whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw.categoryId, whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw.layoutId);
						controllerMap_Editor = whNnnqfriotSIkOuPfVNONZGcGTJ.CwKcIweYXQHPBDUAnaOoKQsEIMywA.wzkzUMXuoWGZwTytFdoKNaEajvvj[whNnnqfriotSIkOuPfVNONZGcGTJ.CwKcIweYXQHPBDUAnaOoKQsEIMywA.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw.id = controllerMap_Editor.id;
					int index = whNnnqfriotSIkOuPfVNONZGcGTJ.CwKcIweYXQHPBDUAnaOoKQsEIMywA.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(controllerMap_Editor);
					whNnnqfriotSIkOuPfVNONZGcGTJ.CwKcIweYXQHPBDUAnaOoKQsEIMywA.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw;
					return whNnnqfriotSIkOuPfVNONZGcGTJ.PcdhsVDgjxKHtXDEVMNsydZaQAEw;
				}
			}

			private sealed class cBarpJFvErtcoenkEadLWIQToFhg
			{
				public ControllerMap_Editor EBdlbSZHYomPtinoVOiwGqyEdiIcA;

				public Predicate<pBawuQolMdjklghDCGlKaZbDiwpdb> ecQzcVASrbVfrGJreqNPwdyWzbFR;

				public Predicate<pBawuQolMdjklghDCGlKaZbDiwpdb> ASYCmJcJbiaGWoIBeuukZoVkacaj;

				internal bool sGpXUMUZeFuBagOTeSCxwIYdDRefA(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.gsqverUIpgWdltzmADzPvzFqPagx == EBdlbSZHYomPtinoVOiwGqyEdiIcA.categoryId;
				}

				internal bool SDeahQatiAyvkNDRlNKwdDuohJIV(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.gsqverUIpgWdltzmADzPvzFqPagx == EBdlbSZHYomPtinoVOiwGqyEdiIcA.layoutId;
				}
			}

			private sealed class WhNnnqfriotSIkOuPfVNONZGcGTJ
			{
				public tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMap_Editor> CwKcIweYXQHPBDUAnaOoKQsEIMywA;

				public ControllerMap_Editor PcdhsVDgjxKHtXDEVMNsydZaQAEw;

				internal bool ogDlmyIWrvitTQJglNDaJrfBNURW(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(CwKcIweYXQHPBDUAnaOoKQsEIMywA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == PcdhsVDgjxKHtXDEVMNsydZaQAEw.categoryId;
				}

				internal bool FAJslXwoXHJnXueIxRDkAvtACXXD(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(CwKcIweYXQHPBDUAnaOoKQsEIMywA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == PcdhsVDgjxKHtXDEVMNsydZaQAEw.layoutId;
				}
			}

			private sealed class CJPhtejlooHVpAkflZodklIeXDBbA
			{
				public ActionElementMap zNZbHBOwuPkgzdiCuOCMzaMiyPSm;

				public WhNnnqfriotSIkOuPfVNONZGcGTJ fRfMFVTBBOCmcAfgSlilHeyiizOWB;

				internal bool mdOpJyyCzZuLrSsHUmlNUFSYyNYn(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(fRfMFVTBBOCmcAfgSlilHeyiizOWB.CwKcIweYXQHPBDUAnaOoKQsEIMywA.OgjsbVPCjFotsZfkNMuatUlsIVxq) == zNZbHBOwuPkgzdiCuOCMzaMiyPSm._actionId;
				}
			}

			private sealed class ORDwEuTEXfBnyqiyIClUOejphiuS
			{
				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> lBzvaLFOYNyiLwFDVdKCkdocOkcs;

				public iyHDOdNXdduiIklEEnHYWyWkKiFj oBNfPUyxdQJqNUCYCBAaGhEsCYcE;

				internal int URaaQZdZmSdVwmUOpCXXJlUqCNuk(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					JCUcTsgNRRpvLYSnShNOdMKusAoZA jCUcTsgNRRpvLYSnShNOdMKusAoZA = new JCUcTsgNRRpvLYSnShNOdMKusAoZA();
					jCUcTsgNRRpvLYSnShNOdMKusAoZA.BDxEexNOGrBwENWsTfBzYqwQRFTk = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = oBNfPUyxdQJqNUCYCBAaGhEsCYcE.rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(jCUcTsgNRRpvLYSnShNOdMKusAoZA.rtJiKutWexWBjLiwHUishUzfXtwh);
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = lBzvaLFOYNyiLwFDVdKCkdocOkcs.Find(jCUcTsgNRRpvLYSnShNOdMKusAoZA.XUotZseTcjTKqMhXBtGDgwBCTaFB);
						if (jCUcTsgNRRpvLYSnShNOdMKusAoZA.BDxEexNOGrBwENWsTfBzYqwQRFTk.hardwareGuid == P_1[i].hardwareGuid && pBawuQolMdjklghDCGlKaZbDiwpdb2 != null && pBawuQolMdjklghDCGlKaZbDiwpdb2.fjCCrbwylroUSoEwzUvBsyEpfiGE == P_1[i].categoryId && pBawuQolMdjklghDCGlKaZbDiwpdb3 != null && pBawuQolMdjklghDCGlKaZbDiwpdb3.fjCCrbwylroUSoEwzUvBsyEpfiGE == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor ikIgBqVEwdOTTFSLMTGXNLnnNVmb(tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMap_Editor> P_0)
				{
					VaDZgvkXrHdyrjgPGHAxjFjmGZqeA vaDZgvkXrHdyrjgPGHAxjFjmGZqeA = new VaDZgvkXrHdyrjgPGHAxjFjmGZqeA();
					vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.kUEqUArSsyHEtCyfetIyaRuETWeG = P_0;
					vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB = JsonTools.Clone(vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.kUEqUArSsyHEtCyfetIyaRuETWeG.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = oBNfPUyxdQJqNUCYCBAaGhEsCYcE.rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.cbFnHzutnXrdAHSisejlHDbUjHscb);
					pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = lBzvaLFOYNyiLwFDVdKCkdocOkcs.Find(vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.eAyslEusTdFtSfBLJmafTMZjPxrT);
					vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB.categoryId = pBawuQolMdjklghDCGlKaZbDiwpdb2?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB.layoutId = pBawuQolMdjklghDCGlKaZbDiwpdb3?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					for (int i = 0; i < vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB.actionElementMaps.Count; i++)
					{
						NbGMMJBirXSYCDdosKbFYCdHAFQP nbGMMJBirXSYCDdosKbFYCdHAFQP = new NbGMMJBirXSYCDdosKbFYCdHAFQP();
						nbGMMJBirXSYCDdosKbFYCdHAFQP.IAZeufiEbYKYeqvyQVPkpKzbwRyrA = vaDZgvkXrHdyrjgPGHAxjFjmGZqeA;
						nbGMMJBirXSYCDdosKbFYCdHAFQP.JeAaOjpBkYIDYcwzgFHHoCnYgMAm = nbGMMJBirXSYCDdosKbFYCdHAFQP.IAZeufiEbYKYeqvyQVPkpKzbwRyrA.NwRVCimohoSuJihBFOpTWqknIEvB.actionElementMaps[i];
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb4 = oBNfPUyxdQJqNUCYCBAaGhEsCYcE.FVOgazjhyQHphsQzuChyDgbFKVDmb.Find(nbGMMJBirXSYCDdosKbFYCdHAFQP.MQqJeaAjUGAxUsMYgXNAaKrRXOdb);
						nbGMMJBirXSYCDdosKbFYCdHAFQP.JeAaOjpBkYIDYcwzgFHHoCnYgMAm._actionId = pBawuQolMdjklghDCGlKaZbDiwpdb4?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
						nbGMMJBirXSYCDdosKbFYCdHAFQP.JeAaOjpBkYIDYcwzgFHHoCnYgMAm._actionCategoryId = ((oBNfPUyxdQJqNUCYCBAaGhEsCYcE.IHnDMLMzsmkidSGNsrMNLWBPDkMA.GetActionById(nbGMMJBirXSYCDdosKbFYCdHAFQP.JeAaOjpBkYIDYcwzgFHHoCnYgMAm._actionId) != null) ? oBNfPUyxdQJqNUCYCBAaGhEsCYcE.IHnDMLMzsmkidSGNsrMNLWBPDkMA.GetActionById(nbGMMJBirXSYCDdosKbFYCdHAFQP.JeAaOjpBkYIDYcwzgFHHoCnYgMAm._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.kUEqUArSsyHEtCyfetIyaRuETWeG.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						controllerMap_Editor = vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.kUEqUArSsyHEtCyfetIyaRuETWeG.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.PNAohagszwyDkxGLHrytyGTZLynA;
						zCvFMbJjzXQmgAHcPrEadMkebAXlB(controllerMap_Editor.actionElementMaps, vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB = controllerMap_Editor2;
					}
					else
					{
						oBNfPUyxdQJqNUCYCBAaGhEsCYcE.IHnDMLMzsmkidSGNsrMNLWBPDkMA.CreateJoystickMap(vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB.categoryId, vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB.hardwareGuid, vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB.layoutId);
						controllerMap_Editor = vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.kUEqUArSsyHEtCyfetIyaRuETWeG.wzkzUMXuoWGZwTytFdoKNaEajvvj[vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.kUEqUArSsyHEtCyfetIyaRuETWeG.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB.id = controllerMap_Editor.id;
					int index = vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.kUEqUArSsyHEtCyfetIyaRuETWeG.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(controllerMap_Editor);
					vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.kUEqUArSsyHEtCyfetIyaRuETWeG.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB;
					return vaDZgvkXrHdyrjgPGHAxjFjmGZqeA.NwRVCimohoSuJihBFOpTWqknIEvB;
				}
			}

			private sealed class JCUcTsgNRRpvLYSnShNOdMKusAoZA
			{
				public ControllerMap_Editor BDxEexNOGrBwENWsTfBzYqwQRFTk;

				public Predicate<pBawuQolMdjklghDCGlKaZbDiwpdb> REZftsxUzzMUEZvnEpQDmGAShrsd;

				public Predicate<pBawuQolMdjklghDCGlKaZbDiwpdb> NrEIWWMzzSRHiApgyMUildHIxARA;

				internal bool rtJiKutWexWBjLiwHUishUzfXtwh(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.gsqverUIpgWdltzmADzPvzFqPagx == BDxEexNOGrBwENWsTfBzYqwQRFTk.categoryId;
				}

				internal bool XUotZseTcjTKqMhXBtGDgwBCTaFB(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.gsqverUIpgWdltzmADzPvzFqPagx == BDxEexNOGrBwENWsTfBzYqwQRFTk.layoutId;
				}
			}

			private sealed class VaDZgvkXrHdyrjgPGHAxjFjmGZqeA
			{
				public tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMap_Editor> kUEqUArSsyHEtCyfetIyaRuETWeG;

				public ControllerMap_Editor NwRVCimohoSuJihBFOpTWqknIEvB;

				internal bool cbFnHzutnXrdAHSisejlHDbUjHscb(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(kUEqUArSsyHEtCyfetIyaRuETWeG.OgjsbVPCjFotsZfkNMuatUlsIVxq) == NwRVCimohoSuJihBFOpTWqknIEvB.categoryId;
				}

				internal bool eAyslEusTdFtSfBLJmafTMZjPxrT(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(kUEqUArSsyHEtCyfetIyaRuETWeG.OgjsbVPCjFotsZfkNMuatUlsIVxq) == NwRVCimohoSuJihBFOpTWqknIEvB.layoutId;
				}
			}

			private sealed class NbGMMJBirXSYCDdosKbFYCdHAFQP
			{
				public ActionElementMap JeAaOjpBkYIDYcwzgFHHoCnYgMAm;

				public VaDZgvkXrHdyrjgPGHAxjFjmGZqeA IAZeufiEbYKYeqvyQVPkpKzbwRyrA;

				internal bool MQqJeaAjUGAxUsMYgXNAaKrRXOdb(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(IAZeufiEbYKYeqvyQVPkpKzbwRyrA.kUEqUArSsyHEtCyfetIyaRuETWeG.OgjsbVPCjFotsZfkNMuatUlsIVxq) == JeAaOjpBkYIDYcwzgFHHoCnYgMAm._actionId;
				}
			}

			private sealed class RgltLyGJoYOhHHYQPlOXAzOLsOmc
			{
				public List<pBawuQolMdjklghDCGlKaZbDiwpdb> LDsbsALBgbVsErlqiRlyAnIHrubY;

				public iyHDOdNXdduiIklEEnHYWyWkKiFj nlcfJbnLwECjJVwBWEVejSLynFPL;

				internal int eWrPexGQFirNivjjyDaWFTvtggIrA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					jpbuKwYZGKiVQVarzExShgzlRyEe jpbuKwYZGKiVQVarzExShgzlRyEe2 = new jpbuKwYZGKiVQVarzExShgzlRyEe();
					jpbuKwYZGKiVQVarzExShgzlRyEe2.HxGoiABNBquJlQmYAkFRIGTgglwo = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = nlcfJbnLwECjJVwBWEVejSLynFPL.EfWPjWvRNwKODWwacmjeWvPgkkFw.Find(jpbuKwYZGKiVQVarzExShgzlRyEe2.XZVrPuByDcrinGkhUltlFMYbKaFQ);
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = nlcfJbnLwECjJVwBWEVejSLynFPL.rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(jpbuKwYZGKiVQVarzExShgzlRyEe2.xtiiQTzpdbezmJsCmbaeXfPYXhlJ);
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb4 = LDsbsALBgbVsErlqiRlyAnIHrubY.Find(jpbuKwYZGKiVQVarzExShgzlRyEe2.ezaAYwhUJJproiUtdTOIxITuilGd);
						if (pBawuQolMdjklghDCGlKaZbDiwpdb2 != null && pBawuQolMdjklghDCGlKaZbDiwpdb2.fjCCrbwylroUSoEwzUvBsyEpfiGE == P_1[i].customControllerUid && pBawuQolMdjklghDCGlKaZbDiwpdb3 != null && pBawuQolMdjklghDCGlKaZbDiwpdb3.fjCCrbwylroUSoEwzUvBsyEpfiGE == P_1[i].categoryId && pBawuQolMdjklghDCGlKaZbDiwpdb4 != null && pBawuQolMdjklghDCGlKaZbDiwpdb4.fjCCrbwylroUSoEwzUvBsyEpfiGE == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor YuJoIDBDVjaHdartJKVXhuAWasfAA(tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMap_Editor> P_0)
				{
					IBzexkEDGahPQAPVDkZwdUtogRWAA bzexkEDGahPQAPVDkZwdUtogRWAA = new IBzexkEDGahPQAPVDkZwdUtogRWAA();
					bzexkEDGahPQAPVDkZwdUtogRWAA.auOQqyRbCjFPRBZblbTKFBHOGcEh = P_0;
					bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE = JsonTools.Clone(bzexkEDGahPQAPVDkZwdUtogRWAA.auOQqyRbCjFPRBZblbTKFBHOGcEh.ClgpBfRiGnCqWaKEFoUEvjOIUsFC);
					pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = nlcfJbnLwECjJVwBWEVejSLynFPL.EfWPjWvRNwKODWwacmjeWvPgkkFw.Find(bzexkEDGahPQAPVDkZwdUtogRWAA.sBAuMCPiSuHrBxvGVNyUodIOFvrc);
					pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb3 = nlcfJbnLwECjJVwBWEVejSLynFPL.rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(bzexkEDGahPQAPVDkZwdUtogRWAA.cEhODFyDQAteybjxMrzqUNCPSkky);
					pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb4 = LDsbsALBgbVsErlqiRlyAnIHrubY.Find(bzexkEDGahPQAPVDkZwdUtogRWAA.yrqhXjqRuSencICwqrmhvxtRqMgD);
					bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE.customControllerUid = pBawuQolMdjklghDCGlKaZbDiwpdb2?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE.categoryId = pBawuQolMdjklghDCGlKaZbDiwpdb3?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE.layoutId = pBawuQolMdjklghDCGlKaZbDiwpdb4?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					for (int i = 0; i < bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE.actionElementMaps.Count; i++)
					{
						BjILVQgoCuJdXpEWrAYrmREFIqhj bjILVQgoCuJdXpEWrAYrmREFIqhj = new BjILVQgoCuJdXpEWrAYrmREFIqhj();
						bjILVQgoCuJdXpEWrAYrmREFIqhj.CzBJNMjsyKhbhCYQdtiVLCBLrYQD = bzexkEDGahPQAPVDkZwdUtogRWAA;
						bjILVQgoCuJdXpEWrAYrmREFIqhj.dAIHviFAAcXvNiAWROeABcMFNMjOB = bjILVQgoCuJdXpEWrAYrmREFIqhj.CzBJNMjsyKhbhCYQdtiVLCBLrYQD.rbRylPkpVMQqoqdOkiKmyQvbIweE.actionElementMaps[i];
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb5 = nlcfJbnLwECjJVwBWEVejSLynFPL.FVOgazjhyQHphsQzuChyDgbFKVDmb.Find(bjILVQgoCuJdXpEWrAYrmREFIqhj.BBIirgytoHyuAniPTtuFYBlgoxVS);
						bjILVQgoCuJdXpEWrAYrmREFIqhj.dAIHviFAAcXvNiAWROeABcMFNMjOB._actionId = pBawuQolMdjklghDCGlKaZbDiwpdb5?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
						bjILVQgoCuJdXpEWrAYrmREFIqhj.dAIHviFAAcXvNiAWROeABcMFNMjOB._actionCategoryId = ((nlcfJbnLwECjJVwBWEVejSLynFPL.IHnDMLMzsmkidSGNsrMNLWBPDkMA.GetActionById(bjILVQgoCuJdXpEWrAYrmREFIqhj.dAIHviFAAcXvNiAWROeABcMFNMjOB._actionId) != null) ? nlcfJbnLwECjJVwBWEVejSLynFPL.IHnDMLMzsmkidSGNsrMNLWBPDkMA.GetActionById(bjILVQgoCuJdXpEWrAYrmREFIqhj.dAIHviFAAcXvNiAWROeABcMFNMjOB._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (bzexkEDGahPQAPVDkZwdUtogRWAA.auOQqyRbCjFPRBZblbTKFBHOGcEh.euLavXUKtCnBOplilyJJWMiBcdSe)
					{
						controllerMap_Editor = bzexkEDGahPQAPVDkZwdUtogRWAA.auOQqyRbCjFPRBZblbTKFBHOGcEh.gbvjerAmdBQOqdMppVMrVPNGLQGgA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.TxcdlVIHLeuKrNETwrmmWcKoPDfG;
						zCvFMbJjzXQmgAHcPrEadMkebAXlB(controllerMap_Editor.actionElementMaps, bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE = controllerMap_Editor2;
					}
					else
					{
						nlcfJbnLwECjJVwBWEVejSLynFPL.IHnDMLMzsmkidSGNsrMNLWBPDkMA.CreateCustomControllerMap(bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE.categoryId, bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE.customControllerUid, bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE.layoutId);
						controllerMap_Editor = bzexkEDGahPQAPVDkZwdUtogRWAA.auOQqyRbCjFPRBZblbTKFBHOGcEh.wzkzUMXuoWGZwTytFdoKNaEajvvj[bzexkEDGahPQAPVDkZwdUtogRWAA.auOQqyRbCjFPRBZblbTKFBHOGcEh.wzkzUMXuoWGZwTytFdoKNaEajvvj.Count - 1];
					}
					bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE.id = controllerMap_Editor.id;
					int index = bzexkEDGahPQAPVDkZwdUtogRWAA.auOQqyRbCjFPRBZblbTKFBHOGcEh.wzkzUMXuoWGZwTytFdoKNaEajvvj.IndexOf(controllerMap_Editor);
					bzexkEDGahPQAPVDkZwdUtogRWAA.auOQqyRbCjFPRBZblbTKFBHOGcEh.wzkzUMXuoWGZwTytFdoKNaEajvvj[index] = bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE;
					return bzexkEDGahPQAPVDkZwdUtogRWAA.rbRylPkpVMQqoqdOkiKmyQvbIweE;
				}
			}

			private sealed class bQYxgCCMERcRsixgBCVssRGTZyjFA
			{
				public int ByCCJjnThwxhNnbLxERreKlrhUbhA;

				internal bool owDIBtyeAMGBUJhaQOjNcmkKXmku(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.gsqverUIpgWdltzmADzPvzFqPagx == ByCCJjnThwxhNnbLxERreKlrhUbhA;
				}
			}

			private sealed class jpbuKwYZGKiVQVarzExShgzlRyEe
			{
				public ControllerMap_Editor HxGoiABNBquJlQmYAkFRIGTgglwo;

				public Predicate<pBawuQolMdjklghDCGlKaZbDiwpdb> vfXNeANBqBoSgBYjqGazejDQODeL;

				public Predicate<pBawuQolMdjklghDCGlKaZbDiwpdb> jEaMJFliiYsTGoOMvwsklJjNtdHR;

				public Predicate<pBawuQolMdjklghDCGlKaZbDiwpdb> vHespHosefXYOQEfLjPdTrrVFmvC;

				internal bool XZVrPuByDcrinGkhUltlFMYbKaFQ(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.gsqverUIpgWdltzmADzPvzFqPagx == HxGoiABNBquJlQmYAkFRIGTgglwo.customControllerUid;
				}

				internal bool xtiiQTzpdbezmJsCmbaeXfPYXhlJ(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.gsqverUIpgWdltzmADzPvzFqPagx == HxGoiABNBquJlQmYAkFRIGTgglwo.categoryId;
				}

				internal bool ezaAYwhUJJproiUtdTOIxITuilGd(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.gsqverUIpgWdltzmADzPvzFqPagx == HxGoiABNBquJlQmYAkFRIGTgglwo.layoutId;
				}
			}

			private sealed class IBzexkEDGahPQAPVDkZwdUtogRWAA
			{
				public tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMap_Editor> auOQqyRbCjFPRBZblbTKFBHOGcEh;

				public ControllerMap_Editor rbRylPkpVMQqoqdOkiKmyQvbIweE;

				internal bool sBAuMCPiSuHrBxvGVNyUodIOFvrc(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(auOQqyRbCjFPRBZblbTKFBHOGcEh.OgjsbVPCjFotsZfkNMuatUlsIVxq) == rbRylPkpVMQqoqdOkiKmyQvbIweE.customControllerUid;
				}

				internal bool cEhODFyDQAteybjxMrzqUNCPSkky(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(auOQqyRbCjFPRBZblbTKFBHOGcEh.OgjsbVPCjFotsZfkNMuatUlsIVxq) == rbRylPkpVMQqoqdOkiKmyQvbIweE.categoryId;
				}

				internal bool yrqhXjqRuSencICwqrmhvxtRqMgD(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(auOQqyRbCjFPRBZblbTKFBHOGcEh.OgjsbVPCjFotsZfkNMuatUlsIVxq) == rbRylPkpVMQqoqdOkiKmyQvbIweE.layoutId;
				}
			}

			private sealed class BjILVQgoCuJdXpEWrAYrmREFIqhj
			{
				public ActionElementMap dAIHviFAAcXvNiAWROeABcMFNMjOB;

				public IBzexkEDGahPQAPVDkZwdUtogRWAA CzBJNMjsyKhbhCYQdtiVLCBLrYQD;

				internal bool BBIirgytoHyuAniPTtuFYBlgoxVS(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(CzBJNMjsyKhbhCYQdtiVLCBLrYQD.auOQqyRbCjFPRBZblbTKFBHOGcEh.OgjsbVPCjFotsZfkNMuatUlsIVxq) == dAIHviFAAcXvNiAWROeABcMFNMjOB._actionId;
				}
			}

			private sealed class jNKIJHJOOyRKGlXjIgoagTztnRGj
			{
				public tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMapLayoutManager_RuleSet_Editor> hpARkksCTYqyowbcVIGLLltOnrOr;
			}

			private sealed class EkpbMOhFsERxpMFpDpsIAIEKcoxSB
			{
				public int qcyyFnmxHLJJYFUdqjVkWuvnRpIk;

				public jNKIJHJOOyRKGlXjIgoagTztnRGj MRvvqpXfcGyeSKdzkhMRyXvMNnkb;

				internal bool uQCDPAJRwbpnJypylBfiXEAFEJAo(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(MRvvqpXfcGyeSKdzkhMRyXvMNnkb.hpARkksCTYqyowbcVIGLLltOnrOr.OgjsbVPCjFotsZfkNMuatUlsIVxq) == qcyyFnmxHLJJYFUdqjVkWuvnRpIk;
				}
			}

			private sealed class ohMvksskvtPlvphWoKpZUDXkEkFA
			{
				public int yrYdpKxfCvstAoogOFBWNTzgsItH;

				public jNKIJHJOOyRKGlXjIgoagTztnRGj pSFydNfiGuhgzDzewccynaTtesgC;

				internal bool XEsKIGtfLDZSAFoFgHHhLXehmLkn(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(pSFydNfiGuhgzDzewccynaTtesgC.hpARkksCTYqyowbcVIGLLltOnrOr.OgjsbVPCjFotsZfkNMuatUlsIVxq) == yrYdpKxfCvstAoogOFBWNTzgsItH;
				}
			}

			private sealed class nduioacprRYudyfBrcrXAzjCJTDy
			{
				public int JTcdPhhApPEsJMdMsqoiEtGSsAxzA;

				public jNKIJHJOOyRKGlXjIgoagTztnRGj fnZozhkrBWOUfCnNcieJAUssRTqX;

				internal bool kEgJKJTBPflPfjTtuhvKBAFicbXZ(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(fnZozhkrBWOUfCnNcieJAUssRTqX.hpARkksCTYqyowbcVIGLLltOnrOr.OgjsbVPCjFotsZfkNMuatUlsIVxq) == JTcdPhhApPEsJMdMsqoiEtGSsAxzA;
				}
			}

			private sealed class mqylOJJcdjHardFZphcNIiIIKRtHA
			{
				public tsrLrNQkDKVAWrqpJnarpxwZfrNk<ControllerMapEnabler_RuleSet_Editor> DCIMpNscnCFNvjxtfsyeAmEiBYom;
			}

			private sealed class WutgRlSUAZBPSjETRHtDzeXPmWwrA
			{
				public int MaoZVdDzjrAwpVnQzsdPDKBvikHT;

				public mqylOJJcdjHardFZphcNIiIIKRtHA pCDXPqviNrOZsRrlmbuBUtnEmYoD;

				internal bool cXrXnwbpMIQonBhgSHoxfcmmTxwQ(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.oyRrxKboYRnOpDUXlThtmtBgLRIe(pCDXPqviNrOZsRrlmbuBUtnEmYoD.DCIMpNscnCFNvjxtfsyeAmEiBYom.OgjsbVPCjFotsZfkNMuatUlsIVxq) == MaoZVdDzjrAwpVnQzsdPDKBvikHT;
				}
			}

			private sealed class NTmRivSgpqhHppgcyiASGuUUkhkYA<_0001> where _0001 : class
			{
				public Func<_0001, int> DbCyjgZcTRfJBbywiiKzrzvOhowaA;
			}

			private sealed class dhYrkTylLmXuUKAfTdurhKuDZmmc<_0001> where _0001 : class
			{
				public _0001 bIYzdYUbRDsvXRdHlAoJmSPZkbFo;

				public NTmRivSgpqhHppgcyiASGuUUkhkYA<_0001> OijQSeRrFcFVBNYAbSByVORAAtLE;

				internal bool veZEPYBJBSJwyYAwEXURiiFkEfA(pBawuQolMdjklghDCGlKaZbDiwpdb P_0)
				{
					return P_0.fjCCrbwylroUSoEwzUvBsyEpfiGE == OijQSeRrFcFVBNYAbSByVORAAtLE.DbCyjgZcTRfJBbywiiKzrzvOhowaA(bIYzdYUbRDsvXRdHlAoJmSPZkbFo);
				}
			}

			public static UserData KwiKfbxuUjcMaQGNgtipopEjBkjb(UserData P_0, UserData P_1, bool P_2)
			{
				iyHDOdNXdduiIklEEnHYWyWkKiFj iyHDOdNXdduiIklEEnHYWyWkKiFj2 = new iyHDOdNXdduiIklEEnHYWyWkKiFj();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA = (P_2 ? P_0 : new UserData(false));
				if (P_1 != null)
				{
					iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.configVars = JsonTools.Clone(P_1.configVars);
				}
				else
				{
					iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.configVars = JsonTools.Clone(P_0.configVars);
				}
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.iWCQkfZRyhygiWyMnEBeeRgQxSTf = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Action Category", P_0.actionCategories, P_1?.actionCategories, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.actionCategories, P_2, iyHDOdNXdduiIklEEnHYWyWkKiFj2.iWCQkfZRyhygiWyMnEBeeRgQxSTf, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.ZGmrLEjFKbJNQTZwQKEoLBwKeWJF, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.RJoEnNIBtUUecwClDmOJVMhKnDcAA, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.dOvOMLNQqpkFmAvAefyOtabXPQao, iyHDOdNXdduiIklEEnHYWyWkKiFj2.pGFlYqiuQTkWwFFPVsawycdiyIUX);
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.IvMokQLccLNLoUaifUFmYSfuaGNy = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.inputBehaviors, P_2, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IvMokQLccLNLoUaifUFmYSfuaGNy, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.wkiaAOpjUnMtnNVoRjYcoXplwyvT, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.QRfdYPDHjvndRpAzqduEGtpBKiqec, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.VyJAdYBjFHWtsMSOEvjAoocSxbXTA, iyHDOdNXdduiIklEEnHYWyWkKiFj2.nDzIVWJkqMrNRfGQsHTXVUPOPpoh);
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.FVOgazjhyQHphsQzuChyDgbFKVDmb = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Action", P_0.actions, P_1?.actions, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.actions, P_2, iyHDOdNXdduiIklEEnHYWyWkKiFj2.FVOgazjhyQHphsQzuChyDgbFKVDmb, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.tssjIPZbVjMRSNBBtugvZMQsNEqq, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.QMbelEckwiilDBxOfIZZHzIbrpHIE, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.RLohtszJzXactkngoivHmEbtCLEHb, iyHDOdNXdduiIklEEnHYWyWkKiFj2.AXKDjUYflonHykqFjMYctpHncPGy);
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.rimOtUGrnGTBoruPAuJZqbnNYqzd = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				QVcvlGPnSYWdHNPDdiXKBrEvHbmIA qVcvlGPnSYWdHNPDdiXKBrEvHbmIA = new QVcvlGPnSYWdHNPDdiXKBrEvHbmIA();
				qVcvlGPnSYWdHNPDdiXKBrEvHbmIA.QgryImmZdJxtmWrohFrMBXPQiQdg = iyHDOdNXdduiIklEEnHYWyWkKiFj2;
				qVcvlGPnSYWdHNPDdiXKBrEvHbmIA.VkWipIYogvmXWVBqSoOhSYnVBjci = new List<int>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Map Category", P_0.mapCategories, P_1?.mapCategories, qVcvlGPnSYWdHNPDdiXKBrEvHbmIA.QgryImmZdJxtmWrohFrMBXPQiQdg.IHnDMLMzsmkidSGNsrMNLWBPDkMA.mapCategories, P_2, qVcvlGPnSYWdHNPDdiXKBrEvHbmIA.QgryImmZdJxtmWrohFrMBXPQiQdg.rimOtUGrnGTBoruPAuJZqbnNYqzd, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.wyQbmaJrdVnrwHZSCbqeuLYvLhoI, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.slbEXNuhAAzyGuEjbdhCgjJYlCoeA, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.vXxgVHAjCvJHodLQZwXZxnmfuIxK, qVcvlGPnSYWdHNPDdiXKBrEvHbmIA.iWLdKWTuGcTYmvXtjqRVWAYpaNpCA);
				for (int i = 0; i < qVcvlGPnSYWdHNPDdiXKBrEvHbmIA.VkWipIYogvmXWVBqSoOhSYnVBjci.Count; i++)
				{
					int index = qVcvlGPnSYWdHNPDdiXKBrEvHbmIA.VkWipIYogvmXWVBqSoOhSYnVBjci[i];
					InputMapCategory inputMapCategory = qVcvlGPnSYWdHNPDdiXKBrEvHbmIA.QgryImmZdJxtmWrohFrMBXPQiQdg.IHnDMLMzsmkidSGNsrMNLWBPDkMA.mapCategories[index];
					for (int j = 0; j < inputMapCategory.XnRdXlkMIvsqKSVPsQWvIpqZqpuk.Count; j++)
					{
						bQYxgCCMERcRsixgBCVssRGTZyjFA bQYxgCCMERcRsixgBCVssRGTZyjFA2 = new bQYxgCCMERcRsixgBCVssRGTZyjFA();
						bQYxgCCMERcRsixgBCVssRGTZyjFA2.ByCCJjnThwxhNnbLxERreKlrhUbhA = inputMapCategory.XnRdXlkMIvsqKSVPsQWvIpqZqpuk[j];
						pBawuQolMdjklghDCGlKaZbDiwpdb pBawuQolMdjklghDCGlKaZbDiwpdb2 = qVcvlGPnSYWdHNPDdiXKBrEvHbmIA.QgryImmZdJxtmWrohFrMBXPQiQdg.rimOtUGrnGTBoruPAuJZqbnNYqzd.Find(bQYxgCCMERcRsixgBCVssRGTZyjFA2.owDIBtyeAMGBUJhaQOjNcmkKXmku);
						inputMapCategory.XnRdXlkMIvsqKSVPsQWvIpqZqpuk[j] = pBawuQolMdjklghDCGlKaZbDiwpdb2?.fjCCrbwylroUSoEwzUvBsyEpfiGE ?? (-1);
					}
				}
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.TjwIYCibZmxkzWjwBaBtSAUfXHcd = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.keyboardLayouts, P_2, iyHDOdNXdduiIklEEnHYWyWkKiFj2.TjwIYCibZmxkzWjwBaBtSAUfXHcd, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.JZKCoFkVHrtaWTFdoODRoEZrbeKX, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.FcYCpgoVdanHnFPdGKSGvEVtQraY, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.GnOyhtyUkgAvxBfFbKCztwpUGFOk, iyHDOdNXdduiIklEEnHYWyWkKiFj2.pMEyMkWiCSVGNnJwOQliIArFdlXd);
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.iNqveFxyDgAiRGuMRSWqMUUFkxYC = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.mouseLayouts, P_2, iyHDOdNXdduiIklEEnHYWyWkKiFj2.iNqveFxyDgAiRGuMRSWqMUUFkxYC, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.libpSRnfiflaCVJBahpYjatRcIoBA, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.lHQbJCdRZKWfCkvpXkVMOCaDgHUK, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.PZvrvsKBfzkYtkZnhjERlYKXBsnX, iyHDOdNXdduiIklEEnHYWyWkKiFj2.TRxxJvgAmRjQVdGVliDMKLXHknGzA);
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.qMSyWJTQTIQDqRAUaaIMFfidcKRcb = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.joystickLayouts, P_2, iyHDOdNXdduiIklEEnHYWyWkKiFj2.qMSyWJTQTIQDqRAUaaIMFfidcKRcb, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.cOnPkhFDpBORauqwXcwdBNwgWFGoA, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.gIHFVpNeXgVgsNcGKCGoXawPcYVJ, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.RTiXRYPWpPgpwlbSTZFeAVJKHnwj, iyHDOdNXdduiIklEEnHYWyWkKiFj2.TqDrHIhYexTsUlWSdIShgUBSSLvj);
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.WsgtdBWNVyejthuRWhDvPVfsyTTu = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.customControllerLayouts, P_2, iyHDOdNXdduiIklEEnHYWyWkKiFj2.WsgtdBWNVyejthuRWhDvPVfsyTTu, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.GCKIFiHFJlQhSktKMNOwDORkuysV, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.iyTByxovCFaakVjarvvcNoujEVMj, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.cbsQGfSgCvwgEnAlPHuksdiHocCV, iyHDOdNXdduiIklEEnHYWyWkKiFj2.lpAwgYVegScYKUcfPcvggzvAszHr);
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.XoahDbcVwFhqJcKrKNpXQcRlObbA = iyHDOdNXdduiIklEEnHYWyWkKiFj2.xlXtxXtOuHXwmKybrcOLpyHLxPwl;
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.EfWPjWvRNwKODWwacmjeWvPgkkFw = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Custom Controller", P_0.customControllers, P_1?.customControllers, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.customControllers, P_2, iyHDOdNXdduiIklEEnHYWyWkKiFj2.EfWPjWvRNwKODWwacmjeWvPgkkFw, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.khPAjHrnExFCMeCnncIunCkIlmPkA, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.dITgMntWNWDmAqXleebPetchPJwF, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.sWfsnqCDMTIywBFegRLqPOBzXuwtA, iyHDOdNXdduiIklEEnHYWyWkKiFj2.lhcBhzgIdPEvoqZYHlkyrPGnUUqTA);
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.uQJSzGoUCjfKebdOhhIwdDYkNUrhA = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.controllerMapLayoutManagerRuleSets, P_2, iyHDOdNXdduiIklEEnHYWyWkKiFj2.uQJSzGoUCjfKebdOhhIwdDYkNUrhA, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.RHQYPxgDRQRpqvDscqInilnfahEdA, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.xqGmVwwubstNJKeiEdhojosQIClC, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.HONYAycFmpufJBdFFYEsNrAicthH, iyHDOdNXdduiIklEEnHYWyWkKiFj2.fnEbhYItrAkLfxYvDjhbNLDqFVWX);
				iyHDOdNXdduiIklEEnHYWyWkKiFj2.CFUmLtgRUXpZIFTcgzzBPGDGtGSG = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.controllerMapEnablerRuleSets, P_2, iyHDOdNXdduiIklEEnHYWyWkKiFj2.CFUmLtgRUXpZIFTcgzzBPGDGtGSG, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.OJFBTpUjTRLgKGOGhhXmgrccDRMsA, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.gMbeHuFYWgCsIWZMGJoNnyMSWgUg, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.nBWBfYxDsRVgPTFbRbDSxzZnueVj, iyHDOdNXdduiIklEEnHYWyWkKiFj2.XZBwoKTiWuNzLMkQSVOohqVdebx);
				List<pBawuQolMdjklghDCGlKaZbDiwpdb> list = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Player", P_0.players, P_1?.players, iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA.players, P_2, list, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.dblDXZURShdsfdqfXlAqSYyzsucGA, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.JkwmGiNviWjdZnwsJCrjCWBcpYUp, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.ElThLKqrJGgNxBAvJhZRrtgYWMKQ, iyHDOdNXdduiIklEEnHYWyWkKiFj2.woYoTKpHaOZIqusZTfCJKbJbVKPy);
				List<pBawuQolMdjklghDCGlKaZbDiwpdb> list2 = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				MBTynBEEKqurBAPUJxSlqjDYbkmQ mBTynBEEKqurBAPUJxSlqjDYbkmQ = new MBTynBEEKqurBAPUJxSlqjDYbkmQ();
				mBTynBEEKqurBAPUJxSlqjDYbkmQ.YeNstIQGHTQBhXgjEtNzWcrUuJHr = iyHDOdNXdduiIklEEnHYWyWkKiFj2;
				mBTynBEEKqurBAPUJxSlqjDYbkmQ.VxtgVtfaAzdkREJZIUSYQVfyjBcP = mBTynBEEKqurBAPUJxSlqjDYbkmQ.YeNstIQGHTQBhXgjEtNzWcrUuJHr.TjwIYCibZmxkzWjwBaBtSAUfXHcd;
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, mBTynBEEKqurBAPUJxSlqjDYbkmQ.YeNstIQGHTQBhXgjEtNzWcrUuJHr.IHnDMLMzsmkidSGNsrMNLWBPDkMA.keyboardMaps, P_2, list2, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.VWpiDZIOflvduGJMwoEmIAjdGsph, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.xiiaMcbQafCGIjvinmnARRAoxvrKA, mBTynBEEKqurBAPUJxSlqjDYbkmQ.bbwlmTOTRgitencULVtwOnOrNxz, mBTynBEEKqurBAPUJxSlqjDYbkmQ.tKTCTLgwpxBqDPyZJdsuLSELzqAF);
				List<pBawuQolMdjklghDCGlKaZbDiwpdb> list3 = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				hgiiLBDkSVjycgwXmttZkPSPmylyA hgiiLBDkSVjycgwXmttZkPSPmylyA2 = new hgiiLBDkSVjycgwXmttZkPSPmylyA();
				hgiiLBDkSVjycgwXmttZkPSPmylyA2.CKthQBNwVuoHCEVVgTKUqXBMkIsM = iyHDOdNXdduiIklEEnHYWyWkKiFj2;
				hgiiLBDkSVjycgwXmttZkPSPmylyA2.PCgcphKZcbmUfdeqkrCMelSxzpeR = hgiiLBDkSVjycgwXmttZkPSPmylyA2.CKthQBNwVuoHCEVVgTKUqXBMkIsM.iNqveFxyDgAiRGuMRSWqMUUFkxYC;
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, hgiiLBDkSVjycgwXmttZkPSPmylyA2.CKthQBNwVuoHCEVVgTKUqXBMkIsM.IHnDMLMzsmkidSGNsrMNLWBPDkMA.mouseMaps, P_2, list3, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.tvMwovRddakCHkGMrLwQbqtFjqbK, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.MXePGEmPcSTEPmqOWOBldUWDUHkX, hgiiLBDkSVjycgwXmttZkPSPmylyA2.rTsZEdWhtEbsWHuSNoLtYqWOHNsI, hgiiLBDkSVjycgwXmttZkPSPmylyA2.mQKaCWbXLkOtgspzLggAbBrdGDmbc);
				List<pBawuQolMdjklghDCGlKaZbDiwpdb> list4 = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				ORDwEuTEXfBnyqiyIClUOejphiuS oRDwEuTEXfBnyqiyIClUOejphiuS = new ORDwEuTEXfBnyqiyIClUOejphiuS();
				oRDwEuTEXfBnyqiyIClUOejphiuS.oBNfPUyxdQJqNUCYCBAaGhEsCYcE = iyHDOdNXdduiIklEEnHYWyWkKiFj2;
				oRDwEuTEXfBnyqiyIClUOejphiuS.lBzvaLFOYNyiLwFDVdKCkdocOkcs = oRDwEuTEXfBnyqiyIClUOejphiuS.oBNfPUyxdQJqNUCYCBAaGhEsCYcE.qMSyWJTQTIQDqRAUaaIMFfidcKRcb;
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, oRDwEuTEXfBnyqiyIClUOejphiuS.oBNfPUyxdQJqNUCYCBAaGhEsCYcE.IHnDMLMzsmkidSGNsrMNLWBPDkMA.joystickMaps, P_2, list4, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.vWWzBMPSKfmhebBILXpnvEPYbRtV, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.wSaxoRfJnEYkzfCUjXrsolsmJoSF, oRDwEuTEXfBnyqiyIClUOejphiuS.URaaQZdZmSdVwmUOpCXXJlUqCNuk, oRDwEuTEXfBnyqiyIClUOejphiuS.ikIgBqVEwdOTTFSLMTGXNLnnNVmb);
				List<pBawuQolMdjklghDCGlKaZbDiwpdb> list5 = new List<pBawuQolMdjklghDCGlKaZbDiwpdb>();
				RgltLyGJoYOhHHYQPlOXAzOLsOmc rgltLyGJoYOhHHYQPlOXAzOLsOmc = new RgltLyGJoYOhHHYQPlOXAzOLsOmc();
				rgltLyGJoYOhHHYQPlOXAzOLsOmc.nlcfJbnLwECjJVwBWEVejSLynFPL = iyHDOdNXdduiIklEEnHYWyWkKiFj2;
				rgltLyGJoYOhHHYQPlOXAzOLsOmc.LDsbsALBgbVsErlqiRlyAnIHrubY = rgltLyGJoYOhHHYQPlOXAzOLsOmc.nlcfJbnLwECjJVwBWEVejSLynFPL.WsgtdBWNVyejthuRWhDvPVfsyTTu;
				zLkvEGncBZbYdCUPHuCVPJghduLmA("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, rgltLyGJoYOhHHYQPlOXAzOLsOmc.nlcfJbnLwECjJVwBWEVejSLynFPL.IHnDMLMzsmkidSGNsrMNLWBPDkMA.customControllerMaps, P_2, list5, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.ImAhMuNatYqXJSLHngzEQDIZOnhV, zmBPtlwhonJVUSZSCUKWjpYaAVYR._003C_003E9.wcqTNOmsEahKPoreQDGEFLonCjXiA, rgltLyGJoYOhHHYQPlOXAzOLsOmc.eWrPexGQFirNivjjyDaWFTvtggIrA, rgltLyGJoYOhHHYQPlOXAzOLsOmc.YuJoIDBDVjaHdartJKVXhuAWasfAA);
				return iyHDOdNXdduiIklEEnHYWyWkKiFj2.IHnDMLMzsmkidSGNsrMNLWBPDkMA;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void HulUWRbHfBWFNzPZbhmYFPEGtlfBA(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void zCvFMbJjzXQmgAHcPrEadMkebAXlB<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
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

			private static void zLkvEGncBZbYdCUPHuCVPJghduLmA<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<pBawuQolMdjklghDCGlKaZbDiwpdb> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<tsrLrNQkDKVAWrqpJnarpxwZfrNk<_0001>, _0001> P_9) where _0001 : class
			{
				NTmRivSgpqhHppgcyiASGuUUkhkYA<_0001> nTmRivSgpqhHppgcyiASGuUUkhkYA = new NTmRivSgpqhHppgcyiASGuUUkhkYA<_0001>();
				nTmRivSgpqhHppgcyiASGuUUkhkYA.DbCyjgZcTRfJBbywiiKzrzvOhowaA = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					_0001 val = P_1[i];
					if (P_4)
					{
						P_5.Add(new pBawuQolMdjklghDCGlKaZbDiwpdb(nTmRivSgpqhHppgcyiASGuUUkhkYA.DbCyjgZcTRfJBbywiiKzrzvOhowaA(val), -1, nTmRivSgpqhHppgcyiASGuUUkhkYA.DbCyjgZcTRfJBbywiiKzrzvOhowaA(val)));
						continue;
					}
					_0001 arg = P_9(new tsrLrNQkDKVAWrqpJnarpxwZfrNk<_0001>(val, null, pBawuQolMdjklghDCGlKaZbDiwpdb.XmVdHpntFUqyoWuHKSOagHJccsFT.origId, P_3, false));
					P_5.Add(new pBawuQolMdjklghDCGlKaZbDiwpdb(nTmRivSgpqhHppgcyiASGuUUkhkYA.DbCyjgZcTRfJBbywiiKzrzvOhowaA(val), -1, nTmRivSgpqhHppgcyiASGuUUkhkYA.DbCyjgZcTRfJBbywiiKzrzvOhowaA(arg)));
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
						dhYrkTylLmXuUKAfTdurhKuDZmmc<_0001> dhYrkTylLmXuUKAfTdurhKuDZmmc2 = new dhYrkTylLmXuUKAfTdurhKuDZmmc<_0001>();
						dhYrkTylLmXuUKAfTdurhKuDZmmc2.OijQSeRrFcFVBNYAbSByVORAAtLE = nTmRivSgpqhHppgcyiASGuUUkhkYA;
						_0001 val3 = P_3[num];
						dhYrkTylLmXuUKAfTdurhKuDZmmc2.bIYzdYUbRDsvXRdHlAoJmSPZkbFo = P_9(new tsrLrNQkDKVAWrqpJnarpxwZfrNk<_0001>(val2, val3, pBawuQolMdjklghDCGlKaZbDiwpdb.XmVdHpntFUqyoWuHKSOagHJccsFT.otherId, P_3, true));
						P_5.Find(dhYrkTylLmXuUKAfTdurhKuDZmmc2.veZEPYBJBSJwyYAwEXURiiFkEfA).gsqverUIpgWdltzmADzPvzFqPagx = dhYrkTylLmXuUKAfTdurhKuDZmmc2.OijQSeRrFcFVBNYAbSByVORAAtLE.DbCyjgZcTRfJBbywiiKzrzvOhowaA(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						_0001 arg2 = P_9(new tsrLrNQkDKVAWrqpJnarpxwZfrNk<_0001>(val2, null, pBawuQolMdjklghDCGlKaZbDiwpdb.XmVdHpntFUqyoWuHKSOagHJccsFT.otherId, P_3, false));
						P_5.Add(new pBawuQolMdjklghDCGlKaZbDiwpdb(-1, nTmRivSgpqhHppgcyiASGuUUkhkYA.DbCyjgZcTRfJBbywiiKzrzvOhowaA(val2), nTmRivSgpqhHppgcyiASGuUUkhkYA.DbCyjgZcTRfJBbywiiKzrzvOhowaA(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}
		}

		[Serializable]
		private sealed class EsWFCLxgKNCanojfEHviVFyhPvix
		{
			public static readonly EsWFCLxgKNCanojfEHviVFyhPvix _003C_003E9 = new EsWFCLxgKNCanojfEHviVFyhPvix();

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__195_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__213_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__229_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__245_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__261_0;

			internal void YBJuROJxDKeFzzsGdVnwZlXRSKmB(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void GuFILTKSmUKjPZFtCXmyMtIiYtgb(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void tUBmXONjhibtUjXkwElWSkfEAaZW(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void KHCJibosuyfXzdhvBLzTSBBeOdrSA(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void GSgQCLCGJvlxdyDcPLBICYvRuXoC(List<Player_Editor.Mapping> P_0, int P_1)
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

		private sealed class RFjkWrMetwyTGHALUOcFIlFjOjFx
		{
			public List<InputLayout> YpqIYUykfDdbVqNqnrHprDqVxJoX;

			internal int MQYWehlNkvsnhAiobeprANrvtYOgA(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				HiAjNxZXsdcFIOBpfCyYZObGYFMB hiAjNxZXsdcFIOBpfCyYZObGYFMB = new HiAjNxZXsdcFIOBpfCyYZObGYFMB();
				hiAjNxZXsdcFIOBpfCyYZObGYFMB.MnNfSKgmQoNxTZevtBIrhhPBVVyE = P_0;
				hiAjNxZXsdcFIOBpfCyYZObGYFMB.CnRqYivQfsqeKcUYBGVvtIaGEiyV = P_1;
				int num = YpqIYUykfDdbVqNqnrHprDqVxJoX.FindIndex(hiAjNxZXsdcFIOBpfCyYZObGYFMB.KtbwjrKeKkTWavdGqLrOFKGbkEyX);
				int num2 = YpqIYUykfDdbVqNqnrHprDqVxJoX.FindIndex(hiAjNxZXsdcFIOBpfCyYZObGYFMB.RdVoBqDxNeTojtrVHBUBVAjGywGc);
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

		private sealed class HiAjNxZXsdcFIOBpfCyYZObGYFMB
		{
			public ControllerMap_Editor MnNfSKgmQoNxTZevtBIrhhPBVVyE;

			public ControllerMap_Editor CnRqYivQfsqeKcUYBGVvtIaGEiyV;

			internal bool KtbwjrKeKkTWavdGqLrOFKGbkEyX(InputLayout P_0)
			{
				return P_0.id == MnNfSKgmQoNxTZevtBIrhhPBVVyE.id;
			}

			internal bool RdVoBqDxNeTojtrVHBUBVAjGywGc(InputLayout P_0)
			{
				return P_0.id == CnRqYivQfsqeKcUYBGVvtIaGEiyV.id;
			}
		}

		private sealed class UdZmkmwXgSBhDIjXlaEgVxQIaSxE : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int RFDgmHiKyRealfYoKklVxqoNQIeF;

			private InputCategory CgkhXNOlmOKFVDcqltUXPfTIzYYP;

			private int joEpHJiCzOFoxjECXqbGzLeVdwpQA;

			private string nSUanHBNpyPgVEQYFGwthBrHDGBOb;

			public string OwSFUPwZahFBXxozNZPvBUkAMetC;

			public UserData yUfSlLSSJGobYpKeyDeajjjkpTwC;

			private int ZpHklrntgecMsDLMQzadYhMRuikR;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return CgkhXNOlmOKFVDcqltUXPfTIzYYP;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return CgkhXNOlmOKFVDcqltUXPfTIzYYP;
				}
			}

			[DebuggerHidden]
			public UdZmkmwXgSBhDIjXlaEgVxQIaSxE(int P_0)
			{
				RFDgmHiKyRealfYoKklVxqoNQIeF = P_0;
				joEpHJiCzOFoxjECXqbGzLeVdwpQA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int rFDgmHiKyRealfYoKklVxqoNQIeF = RFDgmHiKyRealfYoKklVxqoNQIeF;
				UserData userData = yUfSlLSSJGobYpKeyDeajjjkpTwC;
				if (rFDgmHiKyRealfYoKklVxqoNQIeF != 0)
				{
					if (rFDgmHiKyRealfYoKklVxqoNQIeF != 1)
					{
						return false;
					}
					RFDgmHiKyRealfYoKklVxqoNQIeF = -1;
					goto IL_0098;
				}
				RFDgmHiKyRealfYoKklVxqoNQIeF = -1;
				if (nSUanHBNpyPgVEQYFGwthBrHDGBOb == null || nSUanHBNpyPgVEQYFGwthBrHDGBOb == string.Empty)
				{
					return false;
				}
				if (userData.actionCategories == null)
				{
					return false;
				}
				ZpHklrntgecMsDLMQzadYhMRuikR = 0;
				goto IL_00a8;
				IL_00a8:
				if (ZpHklrntgecMsDLMQzadYhMRuikR < userData.actionCategories.Count)
				{
					if (userData.actionCategories[ZpHklrntgecMsDLMQzadYhMRuikR].tag.Equals(nSUanHBNpyPgVEQYFGwthBrHDGBOb, StringComparison.OrdinalIgnoreCase))
					{
						CgkhXNOlmOKFVDcqltUXPfTIzYYP = userData.actionCategories[ZpHklrntgecMsDLMQzadYhMRuikR];
						RFDgmHiKyRealfYoKklVxqoNQIeF = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				ZpHklrntgecMsDLMQzadYhMRuikR++;
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
				UdZmkmwXgSBhDIjXlaEgVxQIaSxE udZmkmwXgSBhDIjXlaEgVxQIaSxE;
				if (RFDgmHiKyRealfYoKklVxqoNQIeF == -2 && joEpHJiCzOFoxjECXqbGzLeVdwpQA == Environment.CurrentManagedThreadId)
				{
					RFDgmHiKyRealfYoKklVxqoNQIeF = 0;
					udZmkmwXgSBhDIjXlaEgVxQIaSxE = this;
				}
				else
				{
					udZmkmwXgSBhDIjXlaEgVxQIaSxE = new UdZmkmwXgSBhDIjXlaEgVxQIaSxE(0);
					udZmkmwXgSBhDIjXlaEgVxQIaSxE.yUfSlLSSJGobYpKeyDeajjjkpTwC = yUfSlLSSJGobYpKeyDeajjjkpTwC;
				}
				udZmkmwXgSBhDIjXlaEgVxQIaSxE.nSUanHBNpyPgVEQYFGwthBrHDGBOb = OwSFUPwZahFBXxozNZPvBUkAMetC;
				return udZmkmwXgSBhDIjXlaEgVxQIaSxE;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class FWrMBdAJprnoYuVwcAdNylCtUePr : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int QMSGZkiOJckjdkKtDfPWplHhxASr;

			private InputAction MoQWMpOWeXssDHgFPxmPGdghfIZBA;

			private int OxGokpdqXSxiRmMRyXyzuVPVsDzj;

			public UserData FkCqcknIyCZQffnqHcQUCMTMWfMt;

			private string evukKwcCnzccIbeUYuyUmumQANArA;

			public string kItMItBJMqfhaywknUrjpcpkBtVM;

			private int hFlMMRzNMFziJIKkPULSkZcKhMcF;

			private int SsZDqovtyGlStIRxButvFvgSqBWV;

			private InputCategory tOhjlVwtdPbIwKwCiSpTYlOxIZvX;

			private int tOTvdgvrTtIOXZKwCtTRvzWyMopq;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return MoQWMpOWeXssDHgFPxmPGdghfIZBA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return MoQWMpOWeXssDHgFPxmPGdghfIZBA;
				}
			}

			[DebuggerHidden]
			public FWrMBdAJprnoYuVwcAdNylCtUePr(int P_0)
			{
				QMSGZkiOJckjdkKtDfPWplHhxASr = P_0;
				OxGokpdqXSxiRmMRyXyzuVPVsDzj = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int qMSGZkiOJckjdkKtDfPWplHhxASr = QMSGZkiOJckjdkKtDfPWplHhxASr;
				UserData fkCqcknIyCZQffnqHcQUCMTMWfMt = FkCqcknIyCZQffnqHcQUCMTMWfMt;
				if (qMSGZkiOJckjdkKtDfPWplHhxASr != 0)
				{
					if (qMSGZkiOJckjdkKtDfPWplHhxASr != 1)
					{
						return false;
					}
					QMSGZkiOJckjdkKtDfPWplHhxASr = -1;
					goto IL_00fd;
				}
				QMSGZkiOJckjdkKtDfPWplHhxASr = -1;
				if (fkCqcknIyCZQffnqHcQUCMTMWfMt.actions == null || fkCqcknIyCZQffnqHcQUCMTMWfMt.actionCategories == null)
				{
					return false;
				}
				if (evukKwcCnzccIbeUYuyUmumQANArA == null || evukKwcCnzccIbeUYuyUmumQANArA == string.Empty)
				{
					return false;
				}
				hFlMMRzNMFziJIKkPULSkZcKhMcF = fkCqcknIyCZQffnqHcQUCMTMWfMt.actions.Count;
				SsZDqovtyGlStIRxButvFvgSqBWV = 0;
				goto IL_0132;
				IL_0122:
				SsZDqovtyGlStIRxButvFvgSqBWV++;
				goto IL_0132;
				IL_00fd:
				tOTvdgvrTtIOXZKwCtTRvzWyMopq++;
				goto IL_010d;
				IL_010d:
				if (tOTvdgvrTtIOXZKwCtTRvzWyMopq < hFlMMRzNMFziJIKkPULSkZcKhMcF)
				{
					if (tOhjlVwtdPbIwKwCiSpTYlOxIZvX.id == fkCqcknIyCZQffnqHcQUCMTMWfMt.actions[tOTvdgvrTtIOXZKwCtTRvzWyMopq].categoryId)
					{
						MoQWMpOWeXssDHgFPxmPGdghfIZBA = fkCqcknIyCZQffnqHcQUCMTMWfMt.actions[tOTvdgvrTtIOXZKwCtTRvzWyMopq];
						QMSGZkiOJckjdkKtDfPWplHhxASr = 1;
						return true;
					}
					goto IL_00fd;
				}
				tOhjlVwtdPbIwKwCiSpTYlOxIZvX = null;
				goto IL_0122;
				IL_0132:
				if (SsZDqovtyGlStIRxButvFvgSqBWV < fkCqcknIyCZQffnqHcQUCMTMWfMt.actionCategories.Count)
				{
					if (fkCqcknIyCZQffnqHcQUCMTMWfMt.actionCategories[SsZDqovtyGlStIRxButvFvgSqBWV].tag.Equals(evukKwcCnzccIbeUYuyUmumQANArA, StringComparison.OrdinalIgnoreCase))
					{
						tOhjlVwtdPbIwKwCiSpTYlOxIZvX = fkCqcknIyCZQffnqHcQUCMTMWfMt.actionCategories[SsZDqovtyGlStIRxButvFvgSqBWV];
						tOTvdgvrTtIOXZKwCtTRvzWyMopq = 0;
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
				FWrMBdAJprnoYuVwcAdNylCtUePr fWrMBdAJprnoYuVwcAdNylCtUePr;
				if (QMSGZkiOJckjdkKtDfPWplHhxASr == -2 && OxGokpdqXSxiRmMRyXyzuVPVsDzj == Environment.CurrentManagedThreadId)
				{
					QMSGZkiOJckjdkKtDfPWplHhxASr = 0;
					fWrMBdAJprnoYuVwcAdNylCtUePr = this;
				}
				else
				{
					fWrMBdAJprnoYuVwcAdNylCtUePr = new FWrMBdAJprnoYuVwcAdNylCtUePr(0);
					fWrMBdAJprnoYuVwcAdNylCtUePr.FkCqcknIyCZQffnqHcQUCMTMWfMt = FkCqcknIyCZQffnqHcQUCMTMWfMt;
				}
				fWrMBdAJprnoYuVwcAdNylCtUePr.evukKwcCnzccIbeUYuyUmumQANArA = kItMItBJMqfhaywknUrjpcpkBtVM;
				return fWrMBdAJprnoYuVwcAdNylCtUePr;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class dXMAVxxsZXHwxmaUsjPtNEXBGStM : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int ZLhAxXkqboIcKjOVKcHaSXewCaHcb;

			private InputAction ZvMwHEaqxijYtFSkCgeDPSnKpbKH;

			private int EzkkfPacNWGSIdwkzhjbxWtIEBDW;

			public UserData ahLXrCYCblvPRBSscVnEqWNDoXbG;

			private bool RHWcejgXMXlNPSpLnEDTwilUGveE;

			public bool wdmSXArOUGeeaerGEcFIhlzPnXxT;

			private int exheoxzmUryHagKHBdicBiVhNpOrA;

			public int dDIASIQUMcafmEdcKBscbnEBLxPOb;

			private IEnumerator<int> IzXSdyqhGHGlHIxHkkYKSirdYWCMA;

			private int RhYXGWjVJLlpncQBharNnwlvJKYp;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return ZvMwHEaqxijYtFSkCgeDPSnKpbKH;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ZvMwHEaqxijYtFSkCgeDPSnKpbKH;
				}
			}

			[DebuggerHidden]
			public dXMAVxxsZXHwxmaUsjPtNEXBGStM(int P_0)
			{
				ZLhAxXkqboIcKjOVKcHaSXewCaHcb = P_0;
				EzkkfPacNWGSIdwkzhjbxWtIEBDW = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int zLhAxXkqboIcKjOVKcHaSXewCaHcb = ZLhAxXkqboIcKjOVKcHaSXewCaHcb;
				if (zLhAxXkqboIcKjOVKcHaSXewCaHcb == -3 || zLhAxXkqboIcKjOVKcHaSXewCaHcb == 1)
				{
					try
					{
					}
					finally
					{
						yMlJRPVkIFBsEsMsQExbgjMpcxub();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int zLhAxXkqboIcKjOVKcHaSXewCaHcb = ZLhAxXkqboIcKjOVKcHaSXewCaHcb;
					UserData userData = ahLXrCYCblvPRBSscVnEqWNDoXbG;
					switch (zLhAxXkqboIcKjOVKcHaSXewCaHcb)
					{
					default:
						return false;
					case 0:
						ZLhAxXkqboIcKjOVKcHaSXewCaHcb = -1;
						if (userData.actions == null || userData.actionCategories == null)
						{
							return false;
						}
						if (RHWcejgXMXlNPSpLnEDTwilUGveE)
						{
							IzXSdyqhGHGlHIxHkkYKSirdYWCMA = userData.SortedActionIdsInCategory(exheoxzmUryHagKHBdicBiVhNpOrA).GetEnumerator();
							ZLhAxXkqboIcKjOVKcHaSXewCaHcb = -3;
							goto IL_00a5;
						}
						RhYXGWjVJLlpncQBharNnwlvJKYp = 0;
						goto IL_0123;
					case 1:
						ZLhAxXkqboIcKjOVKcHaSXewCaHcb = -3;
						goto IL_00a5;
					case 2:
						{
							ZLhAxXkqboIcKjOVKcHaSXewCaHcb = -1;
							goto IL_0111;
						}
						IL_0123:
						if (RhYXGWjVJLlpncQBharNnwlvJKYp >= userData.actions.Count)
						{
							break;
						}
						if (userData.actions[RhYXGWjVJLlpncQBharNnwlvJKYp].categoryId == exheoxzmUryHagKHBdicBiVhNpOrA)
						{
							ZvMwHEaqxijYtFSkCgeDPSnKpbKH = userData.actions[RhYXGWjVJLlpncQBharNnwlvJKYp];
							ZLhAxXkqboIcKjOVKcHaSXewCaHcb = 2;
							return true;
						}
						goto IL_0111;
						IL_0111:
						RhYXGWjVJLlpncQBharNnwlvJKYp++;
						goto IL_0123;
						IL_00a5:
						while (IzXSdyqhGHGlHIxHkkYKSirdYWCMA.MoveNext())
						{
							int current = IzXSdyqhGHGlHIxHkkYKSirdYWCMA.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null)
							{
								ZvMwHEaqxijYtFSkCgeDPSnKpbKH = actionById;
								ZLhAxXkqboIcKjOVKcHaSXewCaHcb = 1;
								return true;
							}
						}
						yMlJRPVkIFBsEsMsQExbgjMpcxub();
						IzXSdyqhGHGlHIxHkkYKSirdYWCMA = null;
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

			private void yMlJRPVkIFBsEsMsQExbgjMpcxub()
			{
				ZLhAxXkqboIcKjOVKcHaSXewCaHcb = -1;
				if (IzXSdyqhGHGlHIxHkkYKSirdYWCMA != null)
				{
					IzXSdyqhGHGlHIxHkkYKSirdYWCMA.Dispose();
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
				dXMAVxxsZXHwxmaUsjPtNEXBGStM dXMAVxxsZXHwxmaUsjPtNEXBGStM2;
				if (ZLhAxXkqboIcKjOVKcHaSXewCaHcb == -2 && EzkkfPacNWGSIdwkzhjbxWtIEBDW == Environment.CurrentManagedThreadId)
				{
					ZLhAxXkqboIcKjOVKcHaSXewCaHcb = 0;
					dXMAVxxsZXHwxmaUsjPtNEXBGStM2 = this;
				}
				else
				{
					dXMAVxxsZXHwxmaUsjPtNEXBGStM2 = new dXMAVxxsZXHwxmaUsjPtNEXBGStM(0);
					dXMAVxxsZXHwxmaUsjPtNEXBGStM2.ahLXrCYCblvPRBSscVnEqWNDoXbG = ahLXrCYCblvPRBSscVnEqWNDoXbG;
				}
				dXMAVxxsZXHwxmaUsjPtNEXBGStM2.exheoxzmUryHagKHBdicBiVhNpOrA = dDIASIQUMcafmEdcKBscbnEBLxPOb;
				dXMAVxxsZXHwxmaUsjPtNEXBGStM2.RHWcejgXMXlNPSpLnEDTwilUGveE = wdmSXArOUGeeaerGEcFIhlzPnXxT;
				return dXMAVxxsZXHwxmaUsjPtNEXBGStM2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class kByMgbdcOYDXbcPLAggGDPOGXHPH : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int gfCbdnGNlFgYKTJdiYZjhTcNRFZm;

			private InputAction mrfQUAgMzNerlaHEvFuYRCKoxSVtA;

			private int svNrAHSgQHPlHJUkDSBYfFXqrFnQ;

			public UserData fihIQhepomxYusRjcJLojWsDnqLb;

			private string gGvRHMuxnxzPyEpChSEHaUlvAHuB;

			public string DPQccZsBhKzupTMMATFvuUVaMWQp;

			private bool gOeAMBcrDyFdVIXbadDHiuBoOuCYB;

			public bool UTsnrnZhfIBBJnHUviaLdqqpSCWV;

			private InputCategory riTzAWHZhfCfSIyTJSFStkQQIdnD;

			private IEnumerator<int> IgCDTTSMCDQWotHVfhLoYJHromQr;

			private int tUGPAAIqcbcQlVumxjMwEBbjdlLt;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return mrfQUAgMzNerlaHEvFuYRCKoxSVtA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return mrfQUAgMzNerlaHEvFuYRCKoxSVtA;
				}
			}

			[DebuggerHidden]
			public kByMgbdcOYDXbcPLAggGDPOGXHPH(int P_0)
			{
				gfCbdnGNlFgYKTJdiYZjhTcNRFZm = P_0;
				svNrAHSgQHPlHJUkDSBYfFXqrFnQ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = gfCbdnGNlFgYKTJdiYZjhTcNRFZm;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						EqPPZypiYeLKhQiXLcOnyKMNDsjb();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = gfCbdnGNlFgYKTJdiYZjhTcNRFZm;
					UserData userData = fihIQhepomxYusRjcJLojWsDnqLb;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						gfCbdnGNlFgYKTJdiYZjhTcNRFZm = -1;
						if (userData.actions == null || userData.actionCategories == null)
						{
							return false;
						}
						if (gGvRHMuxnxzPyEpChSEHaUlvAHuB == null || gGvRHMuxnxzPyEpChSEHaUlvAHuB == string.Empty)
						{
							return false;
						}
						int num2 = userData.IndexOfActionCategory(gGvRHMuxnxzPyEpChSEHaUlvAHuB);
						if (num2 < 0)
						{
							return false;
						}
						riTzAWHZhfCfSIyTJSFStkQQIdnD = userData.GetActionCategory(num2);
						if (gOeAMBcrDyFdVIXbadDHiuBoOuCYB)
						{
							IgCDTTSMCDQWotHVfhLoYJHromQr = userData.SortedActionIdsInCategory(riTzAWHZhfCfSIyTJSFStkQQIdnD.id).GetEnumerator();
							gfCbdnGNlFgYKTJdiYZjhTcNRFZm = -3;
							goto IL_00f2;
						}
						tUGPAAIqcbcQlVumxjMwEBbjdlLt = 0;
						goto IL_0175;
					}
					case 1:
						gfCbdnGNlFgYKTJdiYZjhTcNRFZm = -3;
						goto IL_00f2;
					case 2:
						{
							gfCbdnGNlFgYKTJdiYZjhTcNRFZm = -1;
							goto IL_0163;
						}
						IL_0175:
						if (tUGPAAIqcbcQlVumxjMwEBbjdlLt >= userData.actions.Count)
						{
							break;
						}
						if (userData.actions[tUGPAAIqcbcQlVumxjMwEBbjdlLt].categoryId == riTzAWHZhfCfSIyTJSFStkQQIdnD.id)
						{
							mrfQUAgMzNerlaHEvFuYRCKoxSVtA = userData.actions[tUGPAAIqcbcQlVumxjMwEBbjdlLt];
							gfCbdnGNlFgYKTJdiYZjhTcNRFZm = 2;
							return true;
						}
						goto IL_0163;
						IL_00f2:
						while (IgCDTTSMCDQWotHVfhLoYJHromQr.MoveNext())
						{
							int current = IgCDTTSMCDQWotHVfhLoYJHromQr.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null)
							{
								mrfQUAgMzNerlaHEvFuYRCKoxSVtA = actionById;
								gfCbdnGNlFgYKTJdiYZjhTcNRFZm = 1;
								return true;
							}
						}
						EqPPZypiYeLKhQiXLcOnyKMNDsjb();
						IgCDTTSMCDQWotHVfhLoYJHromQr = null;
						break;
						IL_0163:
						tUGPAAIqcbcQlVumxjMwEBbjdlLt++;
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

			private void EqPPZypiYeLKhQiXLcOnyKMNDsjb()
			{
				gfCbdnGNlFgYKTJdiYZjhTcNRFZm = -1;
				if (IgCDTTSMCDQWotHVfhLoYJHromQr != null)
				{
					IgCDTTSMCDQWotHVfhLoYJHromQr.Dispose();
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
				kByMgbdcOYDXbcPLAggGDPOGXHPH kByMgbdcOYDXbcPLAggGDPOGXHPH2;
				if (gfCbdnGNlFgYKTJdiYZjhTcNRFZm == -2 && svNrAHSgQHPlHJUkDSBYfFXqrFnQ == Environment.CurrentManagedThreadId)
				{
					gfCbdnGNlFgYKTJdiYZjhTcNRFZm = 0;
					kByMgbdcOYDXbcPLAggGDPOGXHPH2 = this;
				}
				else
				{
					kByMgbdcOYDXbcPLAggGDPOGXHPH2 = new kByMgbdcOYDXbcPLAggGDPOGXHPH(0);
					kByMgbdcOYDXbcPLAggGDPOGXHPH2.fihIQhepomxYusRjcJLojWsDnqLb = fihIQhepomxYusRjcJLojWsDnqLb;
				}
				kByMgbdcOYDXbcPLAggGDPOGXHPH2.gGvRHMuxnxzPyEpChSEHaUlvAHuB = DPQccZsBhKzupTMMATFvuUVaMWQp;
				kByMgbdcOYDXbcPLAggGDPOGXHPH2.gOeAMBcrDyFdVIXbadDHiuBoOuCYB = UTsnrnZhfIBBJnHUviaLdqqpSCWV;
				return kByMgbdcOYDXbcPLAggGDPOGXHPH2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class NoxDKPjrZiDcYlXyYbESPEWsPVsFA : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int QIDSIteHOCAWCCeyvbRbaQvVquILA;

			private InputMapCategory YPdoxjfeZnfVqHywjMgZFHElCuLXA;

			private int rfxoftrbgmUszTyFZFqNWEwtAZAc;

			private string djwHFBQjNRwQsMpJhalNisBviKSzA;

			public string MOBoPJrdoHBHVueumVkYqbTpzbtL;

			public UserData twILLCeseRoBTtyUaJNbYazjjgqU;

			private int hinvEuxDUDaMgTKxmUrxfqwaNBMH;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return YPdoxjfeZnfVqHywjMgZFHElCuLXA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return YPdoxjfeZnfVqHywjMgZFHElCuLXA;
				}
			}

			[DebuggerHidden]
			public NoxDKPjrZiDcYlXyYbESPEWsPVsFA(int P_0)
			{
				QIDSIteHOCAWCCeyvbRbaQvVquILA = P_0;
				rfxoftrbgmUszTyFZFqNWEwtAZAc = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int qIDSIteHOCAWCCeyvbRbaQvVquILA = QIDSIteHOCAWCCeyvbRbaQvVquILA;
				UserData userData = twILLCeseRoBTtyUaJNbYazjjgqU;
				if (qIDSIteHOCAWCCeyvbRbaQvVquILA != 0)
				{
					if (qIDSIteHOCAWCCeyvbRbaQvVquILA != 1)
					{
						return false;
					}
					QIDSIteHOCAWCCeyvbRbaQvVquILA = -1;
					goto IL_0098;
				}
				QIDSIteHOCAWCCeyvbRbaQvVquILA = -1;
				if (djwHFBQjNRwQsMpJhalNisBviKSzA == null || djwHFBQjNRwQsMpJhalNisBviKSzA == string.Empty)
				{
					return false;
				}
				if (userData.mapCategories == null)
				{
					return false;
				}
				hinvEuxDUDaMgTKxmUrxfqwaNBMH = 0;
				goto IL_00a8;
				IL_00a8:
				if (hinvEuxDUDaMgTKxmUrxfqwaNBMH < userData.mapCategories.Count)
				{
					if (userData.mapCategories[hinvEuxDUDaMgTKxmUrxfqwaNBMH].tag.Equals(djwHFBQjNRwQsMpJhalNisBviKSzA, StringComparison.OrdinalIgnoreCase))
					{
						YPdoxjfeZnfVqHywjMgZFHElCuLXA = userData.mapCategories[hinvEuxDUDaMgTKxmUrxfqwaNBMH];
						QIDSIteHOCAWCCeyvbRbaQvVquILA = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				hinvEuxDUDaMgTKxmUrxfqwaNBMH++;
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
				NoxDKPjrZiDcYlXyYbESPEWsPVsFA noxDKPjrZiDcYlXyYbESPEWsPVsFA;
				if (QIDSIteHOCAWCCeyvbRbaQvVquILA == -2 && rfxoftrbgmUszTyFZFqNWEwtAZAc == Environment.CurrentManagedThreadId)
				{
					QIDSIteHOCAWCCeyvbRbaQvVquILA = 0;
					noxDKPjrZiDcYlXyYbESPEWsPVsFA = this;
				}
				else
				{
					noxDKPjrZiDcYlXyYbESPEWsPVsFA = new NoxDKPjrZiDcYlXyYbESPEWsPVsFA(0);
					noxDKPjrZiDcYlXyYbESPEWsPVsFA.twILLCeseRoBTtyUaJNbYazjjgqU = twILLCeseRoBTtyUaJNbYazjjgqU;
				}
				noxDKPjrZiDcYlXyYbESPEWsPVsFA.djwHFBQjNRwQsMpJhalNisBviKSzA = MOBoPJrdoHBHVueumVkYqbTpzbtL;
				return noxDKPjrZiDcYlXyYbESPEWsPVsFA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class LqnAIrcijNeexMQXxCzbtcWQHGVaA : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int FyftqSqGlYUAqThvNczQplpyAyXp;

			private string cBoFnNcoNSolCbHokmDFLzJkGxGA;

			private int zYRAOAyftpIOOaMfrYBlovzruJdD;

			public UserData PSAQEADGcnfYzaDFeKdNeuhiCvnAA;

			private int IcEmGBgbUATzmtEyNIKwrGmxZvHE;

			public int OtSjAHqQbOMRlgzczgiqqDjDtorR;

			private IEnumerator<int> hOdgOTcBLEGpFHPxEutQDdAhppbld;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return cBoFnNcoNSolCbHokmDFLzJkGxGA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return cBoFnNcoNSolCbHokmDFLzJkGxGA;
				}
			}

			[DebuggerHidden]
			public LqnAIrcijNeexMQXxCzbtcWQHGVaA(int P_0)
			{
				FyftqSqGlYUAqThvNczQplpyAyXp = P_0;
				zYRAOAyftpIOOaMfrYBlovzruJdD = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int fyftqSqGlYUAqThvNczQplpyAyXp = FyftqSqGlYUAqThvNczQplpyAyXp;
				if (fyftqSqGlYUAqThvNczQplpyAyXp == -3 || fyftqSqGlYUAqThvNczQplpyAyXp == 1)
				{
					try
					{
					}
					finally
					{
						qKKNQZPOOkFgXwsCFaVhAiAngxnGA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int fyftqSqGlYUAqThvNczQplpyAyXp = FyftqSqGlYUAqThvNczQplpyAyXp;
					UserData pSAQEADGcnfYzaDFeKdNeuhiCvnAA = PSAQEADGcnfYzaDFeKdNeuhiCvnAA;
					switch (fyftqSqGlYUAqThvNczQplpyAyXp)
					{
					default:
						return false;
					case 0:
						FyftqSqGlYUAqThvNczQplpyAyXp = -1;
						if (pSAQEADGcnfYzaDFeKdNeuhiCvnAA.actionCategories == null || pSAQEADGcnfYzaDFeKdNeuhiCvnAA.actions == null)
						{
							return false;
						}
						hOdgOTcBLEGpFHPxEutQDdAhppbld = pSAQEADGcnfYzaDFeKdNeuhiCvnAA.actionCategoryMap.ActionIdsInCategory(IcEmGBgbUATzmtEyNIKwrGmxZvHE).GetEnumerator();
						FyftqSqGlYUAqThvNczQplpyAyXp = -3;
						break;
					case 1:
						FyftqSqGlYUAqThvNczQplpyAyXp = -3;
						break;
					}
					while (hOdgOTcBLEGpFHPxEutQDdAhppbld.MoveNext())
					{
						int current = hOdgOTcBLEGpFHPxEutQDdAhppbld.Current;
						InputAction actionById = pSAQEADGcnfYzaDFeKdNeuhiCvnAA.GetActionById(current);
						if (actionById != null)
						{
							cBoFnNcoNSolCbHokmDFLzJkGxGA = actionById.descriptiveName;
							FyftqSqGlYUAqThvNczQplpyAyXp = 1;
							return true;
						}
					}
					qKKNQZPOOkFgXwsCFaVhAiAngxnGA();
					hOdgOTcBLEGpFHPxEutQDdAhppbld = null;
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

			private void qKKNQZPOOkFgXwsCFaVhAiAngxnGA()
			{
				FyftqSqGlYUAqThvNczQplpyAyXp = -1;
				if (hOdgOTcBLEGpFHPxEutQDdAhppbld != null)
				{
					hOdgOTcBLEGpFHPxEutQDdAhppbld.Dispose();
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
				LqnAIrcijNeexMQXxCzbtcWQHGVaA lqnAIrcijNeexMQXxCzbtcWQHGVaA;
				if (FyftqSqGlYUAqThvNczQplpyAyXp == -2 && zYRAOAyftpIOOaMfrYBlovzruJdD == Environment.CurrentManagedThreadId)
				{
					FyftqSqGlYUAqThvNczQplpyAyXp = 0;
					lqnAIrcijNeexMQXxCzbtcWQHGVaA = this;
				}
				else
				{
					lqnAIrcijNeexMQXxCzbtcWQHGVaA = new LqnAIrcijNeexMQXxCzbtcWQHGVaA(0);
					lqnAIrcijNeexMQXxCzbtcWQHGVaA.PSAQEADGcnfYzaDFeKdNeuhiCvnAA = PSAQEADGcnfYzaDFeKdNeuhiCvnAA;
				}
				lqnAIrcijNeexMQXxCzbtcWQHGVaA.IcEmGBgbUATzmtEyNIKwrGmxZvHE = OtSjAHqQbOMRlgzczgiqqDjDtorR;
				return lqnAIrcijNeexMQXxCzbtcWQHGVaA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class QZQDQjqlBcDcvabZnFvODxBCwaVY : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int KiJWkpcMmNquWQmtKxIhOIZzOwGj;

			private int EondIClVWdlKqGZxYmJPhmHQSBdw;

			private int CbQcOhAldEnJQdOOLQRaphtnylCCA;

			public UserData rZREAicBIuHVAhNXgZbKXlCdiRWAA;

			private int VNHcaqBLhrtUqoNwCuxKjXHqvaGHA;

			public int TrgASToUPeQRbbrhkhkcdjLVpAoW;

			private IEnumerator<int> UVVMGBjHtUvvJPQsRanzoUZBZKYj;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return EondIClVWdlKqGZxYmJPhmHQSBdw;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return EondIClVWdlKqGZxYmJPhmHQSBdw;
				}
			}

			[DebuggerHidden]
			public QZQDQjqlBcDcvabZnFvODxBCwaVY(int P_0)
			{
				KiJWkpcMmNquWQmtKxIhOIZzOwGj = P_0;
				CbQcOhAldEnJQdOOLQRaphtnylCCA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int kiJWkpcMmNquWQmtKxIhOIZzOwGj = KiJWkpcMmNquWQmtKxIhOIZzOwGj;
				if (kiJWkpcMmNquWQmtKxIhOIZzOwGj == -3 || kiJWkpcMmNquWQmtKxIhOIZzOwGj == 1)
				{
					try
					{
					}
					finally
					{
						DIkrQhNdjrecGPwTLDxpQMEbOUSS();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int kiJWkpcMmNquWQmtKxIhOIZzOwGj = KiJWkpcMmNquWQmtKxIhOIZzOwGj;
					UserData userData = rZREAicBIuHVAhNXgZbKXlCdiRWAA;
					switch (kiJWkpcMmNquWQmtKxIhOIZzOwGj)
					{
					default:
						return false;
					case 0:
						KiJWkpcMmNquWQmtKxIhOIZzOwGj = -1;
						if (userData.actionCategories == null || userData.actions == null)
						{
							return false;
						}
						UVVMGBjHtUvvJPQsRanzoUZBZKYj = userData.actionCategoryMap.ActionIdsInCategory(VNHcaqBLhrtUqoNwCuxKjXHqvaGHA).GetEnumerator();
						KiJWkpcMmNquWQmtKxIhOIZzOwGj = -3;
						break;
					case 1:
						KiJWkpcMmNquWQmtKxIhOIZzOwGj = -3;
						break;
					}
					if (UVVMGBjHtUvvJPQsRanzoUZBZKYj.MoveNext())
					{
						int current = UVVMGBjHtUvvJPQsRanzoUZBZKYj.Current;
						EondIClVWdlKqGZxYmJPhmHQSBdw = current;
						KiJWkpcMmNquWQmtKxIhOIZzOwGj = 1;
						return true;
					}
					DIkrQhNdjrecGPwTLDxpQMEbOUSS();
					UVVMGBjHtUvvJPQsRanzoUZBZKYj = null;
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

			private void DIkrQhNdjrecGPwTLDxpQMEbOUSS()
			{
				KiJWkpcMmNquWQmtKxIhOIZzOwGj = -1;
				if (UVVMGBjHtUvvJPQsRanzoUZBZKYj != null)
				{
					UVVMGBjHtUvvJPQsRanzoUZBZKYj.Dispose();
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
				QZQDQjqlBcDcvabZnFvODxBCwaVY qZQDQjqlBcDcvabZnFvODxBCwaVY;
				if (KiJWkpcMmNquWQmtKxIhOIZzOwGj == -2 && CbQcOhAldEnJQdOOLQRaphtnylCCA == Environment.CurrentManagedThreadId)
				{
					KiJWkpcMmNquWQmtKxIhOIZzOwGj = 0;
					qZQDQjqlBcDcvabZnFvODxBCwaVY = this;
				}
				else
				{
					qZQDQjqlBcDcvabZnFvODxBCwaVY = new QZQDQjqlBcDcvabZnFvODxBCwaVY(0);
					qZQDQjqlBcDcvabZnFvODxBCwaVY.rZREAicBIuHVAhNXgZbKXlCdiRWAA = rZREAicBIuHVAhNXgZbKXlCdiRWAA;
				}
				qZQDQjqlBcDcvabZnFvODxBCwaVY.VNHcaqBLhrtUqoNwCuxKjXHqvaGHA = TrgASToUPeQRbbrhkhkcdjLVpAoW;
				return qZQDQjqlBcDcvabZnFvODxBCwaVY;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		private sealed class hVDOSvPODtiAusFTIymUypayBXKr : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int MUfcNccaxbOfAdBhmVEfLfOffbHB;

			private string IYhGRycroCdZtWzsvHndDKijBtkiA;

			private int nWllkkJnRcCWLFbMyrjzmOpbVG;

			public UserData XrKZaQoIYTGLeMrwdCbrkhbRhuMeb;

			private int ODPmuCaVAEeqIiizZweBoUiLHXdq;

			public int DaqmiibrEbrPJiuMQeOYsbbbHGecA;

			private IEnumerator<int> EKlGXJcNckZpZTYQiHNcgnYvtvhd;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return IYhGRycroCdZtWzsvHndDKijBtkiA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return IYhGRycroCdZtWzsvHndDKijBtkiA;
				}
			}

			[DebuggerHidden]
			public hVDOSvPODtiAusFTIymUypayBXKr(int P_0)
			{
				MUfcNccaxbOfAdBhmVEfLfOffbHB = P_0;
				nWllkkJnRcCWLFbMyrjzmOpbVG = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int mUfcNccaxbOfAdBhmVEfLfOffbHB = MUfcNccaxbOfAdBhmVEfLfOffbHB;
				if (mUfcNccaxbOfAdBhmVEfLfOffbHB == -3 || mUfcNccaxbOfAdBhmVEfLfOffbHB == 1)
				{
					try
					{
					}
					finally
					{
						LIEgqJhauOulGapdLwjJRjJGlMhGb();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int mUfcNccaxbOfAdBhmVEfLfOffbHB = MUfcNccaxbOfAdBhmVEfLfOffbHB;
					UserData xrKZaQoIYTGLeMrwdCbrkhbRhuMeb = XrKZaQoIYTGLeMrwdCbrkhbRhuMeb;
					switch (mUfcNccaxbOfAdBhmVEfLfOffbHB)
					{
					default:
						return false;
					case 0:
						MUfcNccaxbOfAdBhmVEfLfOffbHB = -1;
						if (xrKZaQoIYTGLeMrwdCbrkhbRhuMeb.actionCategories == null || xrKZaQoIYTGLeMrwdCbrkhbRhuMeb.actions == null)
						{
							return false;
						}
						EKlGXJcNckZpZTYQiHNcgnYvtvhd = xrKZaQoIYTGLeMrwdCbrkhbRhuMeb.actionCategoryMap.ActionIdsInCategory(ODPmuCaVAEeqIiizZweBoUiLHXdq).GetEnumerator();
						MUfcNccaxbOfAdBhmVEfLfOffbHB = -3;
						break;
					case 1:
						MUfcNccaxbOfAdBhmVEfLfOffbHB = -3;
						break;
					}
					while (EKlGXJcNckZpZTYQiHNcgnYvtvhd.MoveNext())
					{
						int current = EKlGXJcNckZpZTYQiHNcgnYvtvhd.Current;
						InputAction actionById = xrKZaQoIYTGLeMrwdCbrkhbRhuMeb.GetActionById(current);
						if (actionById != null)
						{
							IYhGRycroCdZtWzsvHndDKijBtkiA = actionById.name;
							MUfcNccaxbOfAdBhmVEfLfOffbHB = 1;
							return true;
						}
					}
					LIEgqJhauOulGapdLwjJRjJGlMhGb();
					EKlGXJcNckZpZTYQiHNcgnYvtvhd = null;
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

			private void LIEgqJhauOulGapdLwjJRjJGlMhGb()
			{
				MUfcNccaxbOfAdBhmVEfLfOffbHB = -1;
				if (EKlGXJcNckZpZTYQiHNcgnYvtvhd != null)
				{
					EKlGXJcNckZpZTYQiHNcgnYvtvhd.Dispose();
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
				hVDOSvPODtiAusFTIymUypayBXKr hVDOSvPODtiAusFTIymUypayBXKr2;
				if (MUfcNccaxbOfAdBhmVEfLfOffbHB == -2 && nWllkkJnRcCWLFbMyrjzmOpbVG == Environment.CurrentManagedThreadId)
				{
					MUfcNccaxbOfAdBhmVEfLfOffbHB = 0;
					hVDOSvPODtiAusFTIymUypayBXKr2 = this;
				}
				else
				{
					hVDOSvPODtiAusFTIymUypayBXKr2 = new hVDOSvPODtiAusFTIymUypayBXKr(0);
					hVDOSvPODtiAusFTIymUypayBXKr2.XrKZaQoIYTGLeMrwdCbrkhbRhuMeb = XrKZaQoIYTGLeMrwdCbrkhbRhuMeb;
				}
				hVDOSvPODtiAusFTIymUypayBXKr2.ODPmuCaVAEeqIiizZweBoUiLHXdq = DaqmiibrEbrPJiuMQeOYsbbbHGecA;
				return hVDOSvPODtiAusFTIymUypayBXKr2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class biidAxnNMbPqLbbyzILLuzPBNlPE : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int ykuhrNciFdpAUprnzcMaPMwhHqsk;

			private InputCategory bCqhXBYAdCafQudjjKYsZlhBsdVU;

			private int iNfDLypDEgLiUKwyGgWOgjpcNzXK;

			private string zIgnBSAQvCUozpgeduscMjtoEieiA;

			public string YPQEMWvXFaNErupkJwjsRmChmPAe;

			public UserData YTVtDgEWYAuPlfyuqWoljFiHEQST;

			private int kfPgWAWmqOwOiZDhsuMOMFmdDeup;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return bCqhXBYAdCafQudjjKYsZlhBsdVU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return bCqhXBYAdCafQudjjKYsZlhBsdVU;
				}
			}

			[DebuggerHidden]
			public biidAxnNMbPqLbbyzILLuzPBNlPE(int P_0)
			{
				ykuhrNciFdpAUprnzcMaPMwhHqsk = P_0;
				iNfDLypDEgLiUKwyGgWOgjpcNzXK = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = ykuhrNciFdpAUprnzcMaPMwhHqsk;
				UserData yTVtDgEWYAuPlfyuqWoljFiHEQST = YTVtDgEWYAuPlfyuqWoljFiHEQST;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					ykuhrNciFdpAUprnzcMaPMwhHqsk = -1;
					goto IL_00b3;
				}
				ykuhrNciFdpAUprnzcMaPMwhHqsk = -1;
				if (zIgnBSAQvCUozpgeduscMjtoEieiA == null || zIgnBSAQvCUozpgeduscMjtoEieiA == string.Empty)
				{
					return false;
				}
				if (yTVtDgEWYAuPlfyuqWoljFiHEQST.actionCategories == null)
				{
					return false;
				}
				kfPgWAWmqOwOiZDhsuMOMFmdDeup = 0;
				goto IL_00c3;
				IL_00c3:
				if (kfPgWAWmqOwOiZDhsuMOMFmdDeup < yTVtDgEWYAuPlfyuqWoljFiHEQST.actionCategories.Count)
				{
					if (yTVtDgEWYAuPlfyuqWoljFiHEQST.actionCategories[kfPgWAWmqOwOiZDhsuMOMFmdDeup].userAssignable && yTVtDgEWYAuPlfyuqWoljFiHEQST.actionCategories[kfPgWAWmqOwOiZDhsuMOMFmdDeup].tag.Equals(zIgnBSAQvCUozpgeduscMjtoEieiA, StringComparison.OrdinalIgnoreCase))
					{
						bCqhXBYAdCafQudjjKYsZlhBsdVU = yTVtDgEWYAuPlfyuqWoljFiHEQST.actionCategories[kfPgWAWmqOwOiZDhsuMOMFmdDeup];
						ykuhrNciFdpAUprnzcMaPMwhHqsk = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				kfPgWAWmqOwOiZDhsuMOMFmdDeup++;
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
				biidAxnNMbPqLbbyzILLuzPBNlPE biidAxnNMbPqLbbyzILLuzPBNlPE2;
				if (ykuhrNciFdpAUprnzcMaPMwhHqsk == -2 && iNfDLypDEgLiUKwyGgWOgjpcNzXK == Environment.CurrentManagedThreadId)
				{
					ykuhrNciFdpAUprnzcMaPMwhHqsk = 0;
					biidAxnNMbPqLbbyzILLuzPBNlPE2 = this;
				}
				else
				{
					biidAxnNMbPqLbbyzILLuzPBNlPE2 = new biidAxnNMbPqLbbyzILLuzPBNlPE(0);
					biidAxnNMbPqLbbyzILLuzPBNlPE2.YTVtDgEWYAuPlfyuqWoljFiHEQST = YTVtDgEWYAuPlfyuqWoljFiHEQST;
				}
				biidAxnNMbPqLbbyzILLuzPBNlPE2.zIgnBSAQvCUozpgeduscMjtoEieiA = YPQEMWvXFaNErupkJwjsRmChmPAe;
				return biidAxnNMbPqLbbyzILLuzPBNlPE2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class rVlJxgjaGCIlfCDQotyZpeIYFOlHA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int yUoEKrkjMeXbxzpvhlgrhwRNtdTP;

			private InputAction kZuBJzbDkBWwaPJCsBhUcXKaWIRL;

			private int wPSKBOtIJyfZtjZifLSLKeseIwwi;

			public UserData AHjmnVlzqqfHBMSAAmlljQNRfLBn;

			private int NyqZFgVmcScAanzIMlIyszBxGJFW;

			public int bIFAGlnWMCOzmISmLNvcRQOrKmrw;

			private bool kpFqxKnLLVhkbszZhAgOsaygHwHm;

			public bool TkEGJlFHiTXjrCiODTVmHzHgUoHGA;

			private InputCategory wcnIiwcknDdJrRupimQOowEMtQmCA;

			private IEnumerator<int> LCqbjWtNfhxXieBpfdPYipveHSbPA;

			private int lweTTDgNCjgbYWdiIuSbHXZEMGcB;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return kZuBJzbDkBWwaPJCsBhUcXKaWIRL;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return kZuBJzbDkBWwaPJCsBhUcXKaWIRL;
				}
			}

			[DebuggerHidden]
			public rVlJxgjaGCIlfCDQotyZpeIYFOlHA(int P_0)
			{
				yUoEKrkjMeXbxzpvhlgrhwRNtdTP = P_0;
				wPSKBOtIJyfZtjZifLSLKeseIwwi = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = yUoEKrkjMeXbxzpvhlgrhwRNtdTP;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						cEdYWGFpDvbCtmOassBnNHSRYKwL();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = yUoEKrkjMeXbxzpvhlgrhwRNtdTP;
					UserData aHjmnVlzqqfHBMSAAmlljQNRfLBn = AHjmnVlzqqfHBMSAAmlljQNRfLBn;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						yUoEKrkjMeXbxzpvhlgrhwRNtdTP = -1;
						if (aHjmnVlzqqfHBMSAAmlljQNRfLBn.actions == null || aHjmnVlzqqfHBMSAAmlljQNRfLBn.actionCategories == null)
						{
							return false;
						}
						wcnIiwcknDdJrRupimQOowEMtQmCA = aHjmnVlzqqfHBMSAAmlljQNRfLBn.GetActionCategoryById(NyqZFgVmcScAanzIMlIyszBxGJFW);
						if (wcnIiwcknDdJrRupimQOowEMtQmCA == null || !wcnIiwcknDdJrRupimQOowEMtQmCA.userAssignable)
						{
							return false;
						}
						if (kpFqxKnLLVhkbszZhAgOsaygHwHm)
						{
							LCqbjWtNfhxXieBpfdPYipveHSbPA = aHjmnVlzqqfHBMSAAmlljQNRfLBn.SortedActionIdsInCategory(wcnIiwcknDdJrRupimQOowEMtQmCA.id).GetEnumerator();
							yUoEKrkjMeXbxzpvhlgrhwRNtdTP = -3;
							goto IL_00e4;
						}
						lweTTDgNCjgbYWdiIuSbHXZEMGcB = 0;
						goto IL_0165;
					case 1:
						yUoEKrkjMeXbxzpvhlgrhwRNtdTP = -3;
						goto IL_00e4;
					case 2:
						{
							yUoEKrkjMeXbxzpvhlgrhwRNtdTP = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (LCqbjWtNfhxXieBpfdPYipveHSbPA.MoveNext())
						{
							int current = LCqbjWtNfhxXieBpfdPYipveHSbPA.Current;
							InputAction actionById = aHjmnVlzqqfHBMSAAmlljQNRfLBn.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								kZuBJzbDkBWwaPJCsBhUcXKaWIRL = actionById;
								yUoEKrkjMeXbxzpvhlgrhwRNtdTP = 1;
								return true;
							}
						}
						cEdYWGFpDvbCtmOassBnNHSRYKwL();
						LCqbjWtNfhxXieBpfdPYipveHSbPA = null;
						break;
						IL_0153:
						lweTTDgNCjgbYWdiIuSbHXZEMGcB++;
						goto IL_0165;
						IL_0165:
						if (lweTTDgNCjgbYWdiIuSbHXZEMGcB >= aHjmnVlzqqfHBMSAAmlljQNRfLBn.actions.Count)
						{
							break;
						}
						inputAction = aHjmnVlzqqfHBMSAAmlljQNRfLBn.actions[lweTTDgNCjgbYWdiIuSbHXZEMGcB];
						if (inputAction.categoryId == wcnIiwcknDdJrRupimQOowEMtQmCA.id && inputAction.userAssignable)
						{
							kZuBJzbDkBWwaPJCsBhUcXKaWIRL = inputAction;
							yUoEKrkjMeXbxzpvhlgrhwRNtdTP = 2;
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

			private void cEdYWGFpDvbCtmOassBnNHSRYKwL()
			{
				yUoEKrkjMeXbxzpvhlgrhwRNtdTP = -1;
				if (LCqbjWtNfhxXieBpfdPYipveHSbPA != null)
				{
					LCqbjWtNfhxXieBpfdPYipveHSbPA.Dispose();
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
				rVlJxgjaGCIlfCDQotyZpeIYFOlHA rVlJxgjaGCIlfCDQotyZpeIYFOlHA2;
				if (yUoEKrkjMeXbxzpvhlgrhwRNtdTP == -2 && wPSKBOtIJyfZtjZifLSLKeseIwwi == Environment.CurrentManagedThreadId)
				{
					yUoEKrkjMeXbxzpvhlgrhwRNtdTP = 0;
					rVlJxgjaGCIlfCDQotyZpeIYFOlHA2 = this;
				}
				else
				{
					rVlJxgjaGCIlfCDQotyZpeIYFOlHA2 = new rVlJxgjaGCIlfCDQotyZpeIYFOlHA(0);
					rVlJxgjaGCIlfCDQotyZpeIYFOlHA2.AHjmnVlzqqfHBMSAAmlljQNRfLBn = AHjmnVlzqqfHBMSAAmlljQNRfLBn;
				}
				rVlJxgjaGCIlfCDQotyZpeIYFOlHA2.NyqZFgVmcScAanzIMlIyszBxGJFW = bIFAGlnWMCOzmISmLNvcRQOrKmrw;
				rVlJxgjaGCIlfCDQotyZpeIYFOlHA2.kpFqxKnLLVhkbszZhAgOsaygHwHm = TkEGJlFHiTXjrCiODTVmHzHgUoHGA;
				return rVlJxgjaGCIlfCDQotyZpeIYFOlHA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class uQKBMaefkcrpDVHZUstTaXBhycnP : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int bUKEAIVPAkZTGEjpEYyqgfbzSVhC;

			private InputAction DyBQTQomowNYbkbCThQEnjLcZygj;

			private int DyDodPgKjnKTJzHuHLMRpvwrrcAr;

			public UserData BiWCynyxMQNPksbKJUvnzbNMsXfr;

			private string HmyKamnnshDbflwpYCFoDFtxDAkQ;

			public string hONmafktzPTaCZkfbneawPefHbck;

			private bool DCUjuanZJtoasSjHQLOXVaCDvgoT;

			public bool TNDETZZHFsIcDljCAitqWwjdqaru;

			private InputCategory XUdcrrjPrAmmMhuPwDFzbyxgVPJd;

			private IEnumerator<int> YUrcLcJbzEwqDUsLPtIVJoAbPGyQ;

			private int zyIRaPdJJbtifROLEGnHbPipQvJeA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return DyBQTQomowNYbkbCThQEnjLcZygj;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DyBQTQomowNYbkbCThQEnjLcZygj;
				}
			}

			[DebuggerHidden]
			public uQKBMaefkcrpDVHZUstTaXBhycnP(int P_0)
			{
				bUKEAIVPAkZTGEjpEYyqgfbzSVhC = P_0;
				DyDodPgKjnKTJzHuHLMRpvwrrcAr = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = bUKEAIVPAkZTGEjpEYyqgfbzSVhC;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						wIgfrCAetrcHPHhOiQFbvnoWTwYac();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = bUKEAIVPAkZTGEjpEYyqgfbzSVhC;
					UserData biWCynyxMQNPksbKJUvnzbNMsXfr = BiWCynyxMQNPksbKJUvnzbNMsXfr;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						bUKEAIVPAkZTGEjpEYyqgfbzSVhC = -1;
						if (biWCynyxMQNPksbKJUvnzbNMsXfr.actions == null || biWCynyxMQNPksbKJUvnzbNMsXfr.actionCategories == null)
						{
							return false;
						}
						XUdcrrjPrAmmMhuPwDFzbyxgVPJd = biWCynyxMQNPksbKJUvnzbNMsXfr.GetActionCategory(HmyKamnnshDbflwpYCFoDFtxDAkQ);
						if (XUdcrrjPrAmmMhuPwDFzbyxgVPJd == null || !XUdcrrjPrAmmMhuPwDFzbyxgVPJd.userAssignable)
						{
							return false;
						}
						if (DCUjuanZJtoasSjHQLOXVaCDvgoT)
						{
							YUrcLcJbzEwqDUsLPtIVJoAbPGyQ = biWCynyxMQNPksbKJUvnzbNMsXfr.SortedActionIdsInCategory(XUdcrrjPrAmmMhuPwDFzbyxgVPJd.id).GetEnumerator();
							bUKEAIVPAkZTGEjpEYyqgfbzSVhC = -3;
							goto IL_00e4;
						}
						zyIRaPdJJbtifROLEGnHbPipQvJeA = 0;
						goto IL_0165;
					case 1:
						bUKEAIVPAkZTGEjpEYyqgfbzSVhC = -3;
						goto IL_00e4;
					case 2:
						{
							bUKEAIVPAkZTGEjpEYyqgfbzSVhC = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (YUrcLcJbzEwqDUsLPtIVJoAbPGyQ.MoveNext())
						{
							int current = YUrcLcJbzEwqDUsLPtIVJoAbPGyQ.Current;
							InputAction actionById = biWCynyxMQNPksbKJUvnzbNMsXfr.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								DyBQTQomowNYbkbCThQEnjLcZygj = actionById;
								bUKEAIVPAkZTGEjpEYyqgfbzSVhC = 1;
								return true;
							}
						}
						wIgfrCAetrcHPHhOiQFbvnoWTwYac();
						YUrcLcJbzEwqDUsLPtIVJoAbPGyQ = null;
						break;
						IL_0153:
						zyIRaPdJJbtifROLEGnHbPipQvJeA++;
						goto IL_0165;
						IL_0165:
						if (zyIRaPdJJbtifROLEGnHbPipQvJeA >= biWCynyxMQNPksbKJUvnzbNMsXfr.actions.Count)
						{
							break;
						}
						inputAction = biWCynyxMQNPksbKJUvnzbNMsXfr.actions[zyIRaPdJJbtifROLEGnHbPipQvJeA];
						if (inputAction.categoryId == XUdcrrjPrAmmMhuPwDFzbyxgVPJd.id && inputAction.userAssignable)
						{
							DyBQTQomowNYbkbCThQEnjLcZygj = inputAction;
							bUKEAIVPAkZTGEjpEYyqgfbzSVhC = 2;
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

			private void wIgfrCAetrcHPHhOiQFbvnoWTwYac()
			{
				bUKEAIVPAkZTGEjpEYyqgfbzSVhC = -1;
				if (YUrcLcJbzEwqDUsLPtIVJoAbPGyQ != null)
				{
					YUrcLcJbzEwqDUsLPtIVJoAbPGyQ.Dispose();
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
				uQKBMaefkcrpDVHZUstTaXBhycnP uQKBMaefkcrpDVHZUstTaXBhycnP2;
				if (bUKEAIVPAkZTGEjpEYyqgfbzSVhC == -2 && DyDodPgKjnKTJzHuHLMRpvwrrcAr == Environment.CurrentManagedThreadId)
				{
					bUKEAIVPAkZTGEjpEYyqgfbzSVhC = 0;
					uQKBMaefkcrpDVHZUstTaXBhycnP2 = this;
				}
				else
				{
					uQKBMaefkcrpDVHZUstTaXBhycnP2 = new uQKBMaefkcrpDVHZUstTaXBhycnP(0);
					uQKBMaefkcrpDVHZUstTaXBhycnP2.BiWCynyxMQNPksbKJUvnzbNMsXfr = BiWCynyxMQNPksbKJUvnzbNMsXfr;
				}
				uQKBMaefkcrpDVHZUstTaXBhycnP2.HmyKamnnshDbflwpYCFoDFtxDAkQ = hONmafktzPTaCZkfbneawPefHbck;
				uQKBMaefkcrpDVHZUstTaXBhycnP2.DCUjuanZJtoasSjHQLOXVaCDvgoT = TNDETZZHFsIcDljCAitqWwjdqaru;
				return uQKBMaefkcrpDVHZUstTaXBhycnP2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class JwESKWZOnfgIJQwleomfVqkWCdRU : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int VaPAFUwxIaSVChnKSmQzxGrNgjUO;

			private InputMapCategory batOFXQMNoEshREVeYXmlsHdVIpv;

			private int hQkaKkQGGUEOdeVymroXUcmyjLDMA;

			private string mDIQaOkyNZmScarfLFGULbLQfSnDA;

			public string PqbWMNZIKpEdZeeKeAKqrmIBepnL;

			public UserData NeJiOGyMIHGwsqGVdLrZXUVDrGcX;

			private int iCFWUuJKjrfuBRsEDTMmTefugwii;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return batOFXQMNoEshREVeYXmlsHdVIpv;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return batOFXQMNoEshREVeYXmlsHdVIpv;
				}
			}

			[DebuggerHidden]
			public JwESKWZOnfgIJQwleomfVqkWCdRU(int P_0)
			{
				VaPAFUwxIaSVChnKSmQzxGrNgjUO = P_0;
				hQkaKkQGGUEOdeVymroXUcmyjLDMA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int vaPAFUwxIaSVChnKSmQzxGrNgjUO = VaPAFUwxIaSVChnKSmQzxGrNgjUO;
				UserData neJiOGyMIHGwsqGVdLrZXUVDrGcX = NeJiOGyMIHGwsqGVdLrZXUVDrGcX;
				if (vaPAFUwxIaSVChnKSmQzxGrNgjUO != 0)
				{
					if (vaPAFUwxIaSVChnKSmQzxGrNgjUO != 1)
					{
						return false;
					}
					VaPAFUwxIaSVChnKSmQzxGrNgjUO = -1;
					goto IL_00b3;
				}
				VaPAFUwxIaSVChnKSmQzxGrNgjUO = -1;
				if (mDIQaOkyNZmScarfLFGULbLQfSnDA == null || mDIQaOkyNZmScarfLFGULbLQfSnDA == string.Empty)
				{
					return false;
				}
				if (neJiOGyMIHGwsqGVdLrZXUVDrGcX.mapCategories == null)
				{
					return false;
				}
				iCFWUuJKjrfuBRsEDTMmTefugwii = 0;
				goto IL_00c3;
				IL_00c3:
				if (iCFWUuJKjrfuBRsEDTMmTefugwii < neJiOGyMIHGwsqGVdLrZXUVDrGcX.mapCategories.Count)
				{
					if (neJiOGyMIHGwsqGVdLrZXUVDrGcX.mapCategories[iCFWUuJKjrfuBRsEDTMmTefugwii].userAssignable && neJiOGyMIHGwsqGVdLrZXUVDrGcX.mapCategories[iCFWUuJKjrfuBRsEDTMmTefugwii].tag.Equals(mDIQaOkyNZmScarfLFGULbLQfSnDA, StringComparison.OrdinalIgnoreCase))
					{
						batOFXQMNoEshREVeYXmlsHdVIpv = neJiOGyMIHGwsqGVdLrZXUVDrGcX.mapCategories[iCFWUuJKjrfuBRsEDTMmTefugwii];
						VaPAFUwxIaSVChnKSmQzxGrNgjUO = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				iCFWUuJKjrfuBRsEDTMmTefugwii++;
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
				JwESKWZOnfgIJQwleomfVqkWCdRU jwESKWZOnfgIJQwleomfVqkWCdRU;
				if (VaPAFUwxIaSVChnKSmQzxGrNgjUO == -2 && hQkaKkQGGUEOdeVymroXUcmyjLDMA == Environment.CurrentManagedThreadId)
				{
					VaPAFUwxIaSVChnKSmQzxGrNgjUO = 0;
					jwESKWZOnfgIJQwleomfVqkWCdRU = this;
				}
				else
				{
					jwESKWZOnfgIJQwleomfVqkWCdRU = new JwESKWZOnfgIJQwleomfVqkWCdRU(0);
					jwESKWZOnfgIJQwleomfVqkWCdRU.NeJiOGyMIHGwsqGVdLrZXUVDrGcX = NeJiOGyMIHGwsqGVdLrZXUVDrGcX;
				}
				jwESKWZOnfgIJQwleomfVqkWCdRU.mDIQaOkyNZmScarfLFGULbLQfSnDA = PqbWMNZIKpEdZeeKeAKqrmIBepnL;
				return jwESKWZOnfgIJQwleomfVqkWCdRU;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class ZtvEHybeYTJyBrVYrCEqfIxHMKprA : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int oWrkTUljRjpqMaKFwUHlfPfbAZq;

			private InputCategory EpsZDCUIiibOKgpgrEpFgooHpKfWB;

			private int fVvPalPJyzlYsqkriEvbBYbcehzQ;

			public UserData WbAhcKcEHzNMAMtXvYhnTlUwIitxA;

			private int uUPeQDZIBlyOwhIOiMdRNJwetnvJ;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return EpsZDCUIiibOKgpgrEpFgooHpKfWB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return EpsZDCUIiibOKgpgrEpFgooHpKfWB;
				}
			}

			[DebuggerHidden]
			public ZtvEHybeYTJyBrVYrCEqfIxHMKprA(int P_0)
			{
				oWrkTUljRjpqMaKFwUHlfPfbAZq = P_0;
				fVvPalPJyzlYsqkriEvbBYbcehzQ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = oWrkTUljRjpqMaKFwUHlfPfbAZq;
				UserData wbAhcKcEHzNMAMtXvYhnTlUwIitxA = WbAhcKcEHzNMAMtXvYhnTlUwIitxA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					oWrkTUljRjpqMaKFwUHlfPfbAZq = -1;
					goto IL_0070;
				}
				oWrkTUljRjpqMaKFwUHlfPfbAZq = -1;
				if (wbAhcKcEHzNMAMtXvYhnTlUwIitxA.actionCategories == null)
				{
					return false;
				}
				uUPeQDZIBlyOwhIOiMdRNJwetnvJ = 0;
				goto IL_0080;
				IL_0080:
				if (uUPeQDZIBlyOwhIOiMdRNJwetnvJ < wbAhcKcEHzNMAMtXvYhnTlUwIitxA.actionCategories.Count)
				{
					if (wbAhcKcEHzNMAMtXvYhnTlUwIitxA.actionCategories[uUPeQDZIBlyOwhIOiMdRNJwetnvJ].userAssignable)
					{
						EpsZDCUIiibOKgpgrEpFgooHpKfWB = wbAhcKcEHzNMAMtXvYhnTlUwIitxA.actionCategories[uUPeQDZIBlyOwhIOiMdRNJwetnvJ];
						oWrkTUljRjpqMaKFwUHlfPfbAZq = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				uUPeQDZIBlyOwhIOiMdRNJwetnvJ++;
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
				ZtvEHybeYTJyBrVYrCEqfIxHMKprA ztvEHybeYTJyBrVYrCEqfIxHMKprA;
				if (oWrkTUljRjpqMaKFwUHlfPfbAZq == -2 && fVvPalPJyzlYsqkriEvbBYbcehzQ == Environment.CurrentManagedThreadId)
				{
					oWrkTUljRjpqMaKFwUHlfPfbAZq = 0;
					ztvEHybeYTJyBrVYrCEqfIxHMKprA = this;
				}
				else
				{
					ztvEHybeYTJyBrVYrCEqfIxHMKprA = new ZtvEHybeYTJyBrVYrCEqfIxHMKprA(0);
					ztvEHybeYTJyBrVYrCEqfIxHMKprA.WbAhcKcEHzNMAMtXvYhnTlUwIitxA = WbAhcKcEHzNMAMtXvYhnTlUwIitxA;
				}
				return ztvEHybeYTJyBrVYrCEqfIxHMKprA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class IPbFCsDQuaSyrLHBohASrWEWZiXAA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int DqnEXrVEAriDpcBSFlAGdsHnkpSo;

			private InputAction aKaAjWRZCELTzKZMEgDHUNHPEBVkA;

			private int eUYCddtNUHFRdiMfFUvsLPAZgyvGb;

			public UserData VlbgzrVTkhJfCDGJpTxgpRSvbjZb;

			private int lPwozToGjqvlpXeINJegeCPwqEFk;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return aKaAjWRZCELTzKZMEgDHUNHPEBVkA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aKaAjWRZCELTzKZMEgDHUNHPEBVkA;
				}
			}

			[DebuggerHidden]
			public IPbFCsDQuaSyrLHBohASrWEWZiXAA(int P_0)
			{
				DqnEXrVEAriDpcBSFlAGdsHnkpSo = P_0;
				eUYCddtNUHFRdiMfFUvsLPAZgyvGb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int dqnEXrVEAriDpcBSFlAGdsHnkpSo = DqnEXrVEAriDpcBSFlAGdsHnkpSo;
				UserData vlbgzrVTkhJfCDGJpTxgpRSvbjZb = VlbgzrVTkhJfCDGJpTxgpRSvbjZb;
				if (dqnEXrVEAriDpcBSFlAGdsHnkpSo != 0)
				{
					if (dqnEXrVEAriDpcBSFlAGdsHnkpSo != 1)
					{
						return false;
					}
					DqnEXrVEAriDpcBSFlAGdsHnkpSo = -1;
					goto IL_007a;
				}
				DqnEXrVEAriDpcBSFlAGdsHnkpSo = -1;
				if (vlbgzrVTkhJfCDGJpTxgpRSvbjZb.actions == null)
				{
					return false;
				}
				lPwozToGjqvlpXeINJegeCPwqEFk = 0;
				goto IL_008c;
				IL_008c:
				if (lPwozToGjqvlpXeINJegeCPwqEFk < vlbgzrVTkhJfCDGJpTxgpRSvbjZb.actions.Count)
				{
					InputAction inputAction = vlbgzrVTkhJfCDGJpTxgpRSvbjZb.actions[lPwozToGjqvlpXeINJegeCPwqEFk];
					InputCategory actionCategoryById = vlbgzrVTkhJfCDGJpTxgpRSvbjZb.GetActionCategoryById(inputAction.categoryId);
					if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
					{
						aKaAjWRZCELTzKZMEgDHUNHPEBVkA = inputAction;
						DqnEXrVEAriDpcBSFlAGdsHnkpSo = 1;
						return true;
					}
					goto IL_007a;
				}
				return false;
				IL_007a:
				lPwozToGjqvlpXeINJegeCPwqEFk++;
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
				IPbFCsDQuaSyrLHBohASrWEWZiXAA pbFCsDQuaSyrLHBohASrWEWZiXAA;
				if (DqnEXrVEAriDpcBSFlAGdsHnkpSo == -2 && eUYCddtNUHFRdiMfFUvsLPAZgyvGb == Environment.CurrentManagedThreadId)
				{
					DqnEXrVEAriDpcBSFlAGdsHnkpSo = 0;
					pbFCsDQuaSyrLHBohASrWEWZiXAA = this;
				}
				else
				{
					pbFCsDQuaSyrLHBohASrWEWZiXAA = new IPbFCsDQuaSyrLHBohASrWEWZiXAA(0);
					pbFCsDQuaSyrLHBohASrWEWZiXAA.VlbgzrVTkhJfCDGJpTxgpRSvbjZb = VlbgzrVTkhJfCDGJpTxgpRSvbjZb;
				}
				return pbFCsDQuaSyrLHBohASrWEWZiXAA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class pOijXBEbtsStROasyFqZFwcteRdMA : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int srpxcqRqlMulfgCczGppemsvdQCiA;

			private InputMapCategory PACmjyJNWQSscfeNRBTUWLCdebKW;

			private int JGdOcCxKUGCNGyCETaiGNlpudalX;

			public UserData lUksQFYJYBDwqpLOGwaIjrDlrxDS;

			private int HgGYjNnUNQRfPNvcafjlSnrflonk;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return PACmjyJNWQSscfeNRBTUWLCdebKW;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return PACmjyJNWQSscfeNRBTUWLCdebKW;
				}
			}

			[DebuggerHidden]
			public pOijXBEbtsStROasyFqZFwcteRdMA(int P_0)
			{
				srpxcqRqlMulfgCczGppemsvdQCiA = P_0;
				JGdOcCxKUGCNGyCETaiGNlpudalX = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = srpxcqRqlMulfgCczGppemsvdQCiA;
				UserData userData = lUksQFYJYBDwqpLOGwaIjrDlrxDS;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					srpxcqRqlMulfgCczGppemsvdQCiA = -1;
					goto IL_0070;
				}
				srpxcqRqlMulfgCczGppemsvdQCiA = -1;
				if (userData.mapCategories == null)
				{
					return false;
				}
				HgGYjNnUNQRfPNvcafjlSnrflonk = 0;
				goto IL_0080;
				IL_0080:
				if (HgGYjNnUNQRfPNvcafjlSnrflonk < userData.mapCategories.Count)
				{
					if (userData.mapCategories[HgGYjNnUNQRfPNvcafjlSnrflonk].userAssignable)
					{
						PACmjyJNWQSscfeNRBTUWLCdebKW = userData.mapCategories[HgGYjNnUNQRfPNvcafjlSnrflonk];
						srpxcqRqlMulfgCczGppemsvdQCiA = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				HgGYjNnUNQRfPNvcafjlSnrflonk++;
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
				pOijXBEbtsStROasyFqZFwcteRdMA pOijXBEbtsStROasyFqZFwcteRdMA2;
				if (srpxcqRqlMulfgCczGppemsvdQCiA == -2 && JGdOcCxKUGCNGyCETaiGNlpudalX == Environment.CurrentManagedThreadId)
				{
					srpxcqRqlMulfgCczGppemsvdQCiA = 0;
					pOijXBEbtsStROasyFqZFwcteRdMA2 = this;
				}
				else
				{
					pOijXBEbtsStROasyFqZFwcteRdMA2 = new pOijXBEbtsStROasyFqZFwcteRdMA(0);
					pOijXBEbtsStROasyFqZFwcteRdMA2.lUksQFYJYBDwqpLOGwaIjrDlrxDS = lUksQFYJYBDwqpLOGwaIjrDlrxDS;
				}
				return pOijXBEbtsStROasyFqZFwcteRdMA2;
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

		internal IList<Player_Editor> EUylEkfoKkBUEodVsyHiwCsvjWhO
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

		internal IList<InputAction> PEFTXXILkxxfGxTGEcImyNOuGVDG
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

		internal IList<InputCategory> RZGeymbvACCaHRQDBiCaiOLWZaWWA
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

		internal IList<InputBehavior> UUgGtNfJqXCkbBfaVYhsajngoxYJA
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

		internal IList<InputMapCategory> ckIHfthJnEQqFUQQhKHZpqLnWNQH
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

		internal IList<InputLayout> soeahDnvWEUInkXpARYGfVZaEGgH
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

		internal IList<InputLayout> GRVglZafkGhPDbzQDTqQNLFHEITLb
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

		internal IList<InputLayout> XCFOJdLTNnjYWkByIFJXmtPtnpXA
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

		internal IList<InputLayout> ABMPfALCxGYKrCWXBvyTJnHswxzb
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

		internal IList<ControllerMap_Editor> DPhLsVGYcRTLkxnsrVlQDYDvWfvB
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

		internal IList<ControllerMap_Editor> bSksfGWqOInULFPpNhryLhvYdQlH
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

		internal IList<ControllerMap_Editor> WwGivMRIatrbOicZHeFTokxPOujw
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

		internal IList<ControllerMap_Editor> YtGZDhCqPUgExXXhPMxAZZiEaCmM
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

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> wNmyHEQABQnYbDbNWtFgNWnQOlmF
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

		internal IList<ControllerMapEnabler_RuleSet_Editor> BuniSdZyNkRGAZDCCqFpFCMgSAxr
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

		internal IEnumerable<InputMapCategory> oiHpIwpGjoatCGcGufkeHCJobTZl
		{
			[IteratorStateMachine(typeof(pOijXBEbtsStROasyFqZFwcteRdMA))]
			get
			{
				return new pOijXBEbtsStROasyFqZFwcteRdMA(-2)
				{
					lUksQFYJYBDwqpLOGwaIjrDlrxDS = this
				};
			}
		}

		internal IEnumerable<InputCategory> KFyBrCxYbinHtSBhkthvBkfYdkgCA
		{
			[IteratorStateMachine(typeof(ZtvEHybeYTJyBrVYrCEqfIxHMKprA))]
			get
			{
				return new ZtvEHybeYTJyBrVYrCEqfIxHMKprA(-2)
				{
					WbAhcKcEHzNMAMtXvYhnTlUwIitxA = this
				};
			}
		}

		internal IEnumerable<InputAction> YLNHPIpRrTbKXqcoCsqOIIPXcNNi
		{
			[IteratorStateMachine(typeof(IPbFCsDQuaSyrLHBohASrWEWZiXAA))]
			get
			{
				return new IPbFCsDQuaSyrLHBohASrWEWZiXAA(-2)
				{
					VlbgzrVTkhJfCDGJpTxgpRSvbjZb = this
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

		[IteratorStateMachine(typeof(NoxDKPjrZiDcYlXyYbESPEWsPVsFA))]
		internal IEnumerable<InputMapCategory> ojAMOEysTWIgjjfDpcqBCxhBdvFU(string P_0)
		{
			return new NoxDKPjrZiDcYlXyYbESPEWsPVsFA(-2)
			{
				twILLCeseRoBTtyUaJNbYazjjgqU = this,
				MOBoPJrdoHBHVueumVkYqbTpzbtL = P_0
			};
		}

		[IteratorStateMachine(typeof(JwESKWZOnfgIJQwleomfVqkWCdRU))]
		internal IEnumerable<InputMapCategory> xZUzmwibstpRAiiJLDuciRLjDiRyA(string P_0)
		{
			return new JwESKWZOnfgIJQwleomfVqkWCdRU(-2)
			{
				NeJiOGyMIHGwsqGVdLrZXUVDrGcX = this,
				PqbWMNZIKpEdZeeKeAKqrmIBepnL = P_0
			};
		}

		[IteratorStateMachine(typeof(UdZmkmwXgSBhDIjXlaEgVxQIaSxE))]
		internal IEnumerable<InputCategory> DWwKxTVidLKgzrWJmhUEvPfmrKnF(string P_0)
		{
			return new UdZmkmwXgSBhDIjXlaEgVxQIaSxE(-2)
			{
				yUfSlLSSJGobYpKeyDeajjjkpTwC = this,
				OwSFUPwZahFBXxozNZPvBUkAMetC = P_0
			};
		}

		[IteratorStateMachine(typeof(biidAxnNMbPqLbbyzILLuzPBNlPE))]
		internal IEnumerable<InputCategory> dfFVQLfuJowRSUrsKinwKCjvebmG(string P_0)
		{
			return new biidAxnNMbPqLbbyzILLuzPBNlPE(-2)
			{
				YTVtDgEWYAuPlfyuqWoljFiHEQST = this,
				YPQEMWvXFaNErupkJwjsRmChmPAe = P_0
			};
		}

		[IteratorStateMachine(typeof(dXMAVxxsZXHwxmaUsjPtNEXBGStM))]
		internal IEnumerable<InputAction> pSHNxtuOutXDmtiPrKTrzPMSgNAC(int P_0, bool P_1)
		{
			return new dXMAVxxsZXHwxmaUsjPtNEXBGStM(-2)
			{
				ahLXrCYCblvPRBSscVnEqWNDoXbG = this,
				dDIASIQUMcafmEdcKBscbnEBLxPOb = P_0,
				wdmSXArOUGeeaerGEcFIhlzPnXxT = P_1
			};
		}

		[IteratorStateMachine(typeof(kByMgbdcOYDXbcPLAggGDPOGXHPH))]
		internal IEnumerable<InputAction> NnHeJtGFsRRYnvgXwGhKJzQQRtcY(string P_0, bool P_1)
		{
			return new kByMgbdcOYDXbcPLAggGDPOGXHPH(-2)
			{
				fihIQhepomxYusRjcJLojWsDnqLb = this,
				DPQccZsBhKzupTMMATFvuUVaMWQp = P_0,
				UTsnrnZhfIBBJnHUviaLdqqpSCWV = P_1
			};
		}

		[IteratorStateMachine(typeof(FWrMBdAJprnoYuVwcAdNylCtUePr))]
		internal IEnumerable<InputAction> wwbAeZBwigwufXpTFHIHJHciAKwv(string P_0)
		{
			return new FWrMBdAJprnoYuVwcAdNylCtUePr(-2)
			{
				FkCqcknIyCZQffnqHcQUCMTMWfMt = this,
				kItMItBJMqfhaywknUrjpcpkBtVM = P_0
			};
		}

		[IteratorStateMachine(typeof(rVlJxgjaGCIlfCDQotyZpeIYFOlHA))]
		internal IEnumerable<InputAction> MjzPYWTIViYYAByoNZxkChQKEFGg(int P_0, bool P_1)
		{
			return new rVlJxgjaGCIlfCDQotyZpeIYFOlHA(-2)
			{
				AHjmnVlzqqfHBMSAAmlljQNRfLBn = this,
				bIFAGlnWMCOzmISmLNvcRQOrKmrw = P_0,
				TkEGJlFHiTXjrCiODTVmHzHgUoHGA = P_1
			};
		}

		[IteratorStateMachine(typeof(uQKBMaefkcrpDVHZUstTaXBhycnP))]
		internal IEnumerable<InputAction> hLjeOmjntEKAZURVTGLgTedgcDLhA(string P_0, bool P_1)
		{
			return new uQKBMaefkcrpDVHZUstTaXBhycnP(-2)
			{
				BiWCynyxMQNPksbKJUvnzbNMsXfr = this,
				hONmafktzPTaCZkfbneawPefHbck = P_0,
				TNDETZZHFsIcDljCAitqWwjdqaru = P_1
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
				Player_Editor player_Editor = pMUkQoBnLXMybzmoltSGGmlbdlTO();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputCategory inputCategory = DJHeuXRwNpywwhRaUJCHZMpDqIIH();
				inputCategory.name = "Default";
				inputCategory.descriptiveName = inputCategory.name;
				actionCategories.Add(inputCategory);
				actionCategoryMap.AddCategory(inputCategory.id);
				InputBehavior inputBehavior = aWAzyWuxXcMXTCmcKrvRhgnGIcuW();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = reMXARRYrKQeKjuFxUdQvDKYLFpk();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = TjfkfPcZnmvdrnPAPbJoGVjdOXSTA();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = WBzhloqQktZkXuqsUguwvlusulrv();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = wUxwaJhAStMxHhbVxXhYbQWnzjaV();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = omoGwmCVBilIVTlTvJIFtPLRDIPW();
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
				KeyboardMap item = keyboardMaps[i].DtJplVINApQfcgyaPlrBoiCGqZZA(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].XfWiykqIpULysKOtRAuxVNnIQEgV(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(pMUkQoBnLXMybzmoltSGGmlbdlTO());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, pMUkQoBnLXMybzmoltSGGmlbdlTO());
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
			InputAction inputAction = GOzthWNqgfoSEEcHmzRmmJwbmahD();
			inputAction.categoryId = categoryId;
			actions.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (actions != null)
			{
				InputAction inputAction = GOzthWNqgfoSEEcHmzRmmJwbmahD();
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

		private int hRnBRVJJlBNwjbYNiHxhMurokidAc(int P_0, InputAction P_1)
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

		[IteratorStateMachine(typeof(hVDOSvPODtiAusFTIymUypayBXKr))]
		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			return new hVDOSvPODtiAusFTIymUypayBXKr(-2)
			{
				XrKZaQoIYTGLeMrwdCbrkhbRhuMeb = this,
				DaqmiibrEbrPJiuMQeOYsbbbHGecA = id
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

		[IteratorStateMachine(typeof(LqnAIrcijNeexMQXxCzbtcWQHGVaA))]
		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			return new LqnAIrcijNeexMQXxCzbtcWQHGVaA(-2)
			{
				PSAQEADGcnfYzaDFeKdNeuhiCvnAA = this,
				OtSjAHqQbOMRlgzczgiqqDjDtorR = id
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

		[IteratorStateMachine(typeof(QZQDQjqlBcDcvabZnFvODxBCwaVY))]
		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			return new QZQDQjqlBcDcvabZnFvODxBCwaVY(-2)
			{
				rZREAicBIuHVAhNXgZbKXlCdiRWAA = this,
				TrgASToUPeQRbbrhkhkcdjLVpAoW = id
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
			InputCategory inputCategory = DJHeuXRwNpywwhRaUJCHZMpDqIIH();
			actionCategories.Add(inputCategory);
			actionCategoryMap.AddCategory(inputCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputCategory inputCategory = DJHeuXRwNpywwhRaUJCHZMpDqIIH();
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
				int num = hRnBRVJJlBNwjbYNiHxhMurokidAc(id2, inputAction);
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
			inputBehaviors.Add(aWAzyWuxXcMXTCmcKrvRhgnGIcuW());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, aWAzyWuxXcMXTCmcKrvRhgnGIcuW());
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
			mapCategories.Add(reMXARRYrKQeKjuFxUdQvDKYLFpk());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, reMXARRYrKQeKjuFxUdQvDKYLFpk());
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
				Action<List<Player_Editor.Mapping>, int> action = EsWFCLxgKNCanojfEHviVFyhPvix._003C_003E9.YBJuROJxDKeFzzsGdVnwZlXRSKmB;
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
			joystickLayouts.Add(TjfkfPcZnmvdrnPAPbJoGVjdOXSTA());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, TjfkfPcZnmvdrnPAPbJoGVjdOXSTA());
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
				Action<List<Player_Editor.Mapping>, int> action = EsWFCLxgKNCanojfEHviVFyhPvix._003C_003E9.GuFILTKSmUKjPZFtCXmyMtIiYtgb;
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
			keyboardLayouts.Add(WBzhloqQktZkXuqsUguwvlusulrv());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, WBzhloqQktZkXuqsUguwvlusulrv());
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
				Action<List<Player_Editor.Mapping>, int> action = EsWFCLxgKNCanojfEHviVFyhPvix._003C_003E9.tUBmXONjhibtUjXkwElWSkfEAaZW;
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
			mouseLayouts.Add(wUxwaJhAStMxHhbVxXhYbQWnzjaV());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, wUxwaJhAStMxHhbVxXhYbQWnzjaV());
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
				Action<List<Player_Editor.Mapping>, int> action = EsWFCLxgKNCanojfEHviVFyhPvix._003C_003E9.KHCJibosuyfXzdhvBLzTSBBeOdrSA;
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
			customControllerLayouts.Add(omoGwmCVBilIVTlTvJIFtPLRDIPW());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, omoGwmCVBilIVTlTvJIFtPLRDIPW());
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
				Action<List<Player_Editor.Mapping>, int> action = EsWFCLxgKNCanojfEHviVFyhPvix._003C_003E9.GSgQCLCGJvlxdyDcPLBICYvRuXoC;
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

		internal ControllerMap pPgpuDFygCUisHKHQWpvgEBAJPeK(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Joystick => ofgceWFBKkrijXmMdOMJaICYoztJ((Joystick)P_0, P_1, P_2), 
				ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
				ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
				ControllerType.Custom => FOpnPAIEvAFTsdbpngFJvcNiJQaEb(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
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

		internal JoystickMap MVHgjIqDhLqNwgZLhrRSmTtNpiSk(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return JHucRkMNAoOHNoPZuuUgsqxTDCFjA(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap ofgceWFBKkrijXmMdOMJaICYoztJ(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return JHucRkMNAoOHNoPZuuUgsqxTDCFjA(P_0.WYDKuDMKHxTQphWMOKOFEJkODYZEA, P_1, P_2);
		}

		private JoystickMap JHucRkMNAoOHNoPZuuUgsqxTDCFjA(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.IGEHkEuFsqJKrUsbmEUhfZlcQsHB(guid);
			ControllerMap_Editor controllerMap_Editor = fbNfcMOxXiqFbDNhxiKGDBJKFzhe(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.GzWVrEYsmRkfzhyPqGfWHqUUaGBW(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.KIjQZgTMEqlhoZGSLhjVSAODydzA(guid, P_1, P_2);
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
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.JygnrFiMhuenDfjLmROYbiKJJoKeA(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = fbNfcMOxXiqFbDNhxiKGDBJKFzhe(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = gEdVZKAqqoJTOCIStNrTcrwaChil(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.KIjQZgTMEqlhoZGSLhjVSAODydzA(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty || 1 == 0)
			{
				controllerMap_Editor = fbNfcMOxXiqFbDNhxiKGDBJKFzhe(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.GzWVrEYsmRkfzhyPqGfWHqUUaGBW(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.KIjQZgTMEqlhoZGSLhjVSAODydzA(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.KxOlJQwGhYKpCgBPwhupJvotQUvj(guid, P_1, P_2);
		}

		private ControllerMap_Editor fbNfcMOxXiqFbDNhxiKGDBJKFzhe(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = EeZcMlZEQVQBMxCQLdxUBqMUDRSnA(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor EeZcMlZEQVQBMxCQLdxUBqMUDRSnA(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				bJTPbjEPUxvmigpEpbIByxvAEVIE(list, joystickLayouts);
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

		private JoystickMap gEdVZKAqqoJTOCIStNrTcrwaChil(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.rDhNTMGcTZvWndevGAdgCGizEYTn(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError("Error remapping joystick template " + P_2.Guid.ToString() + " to joystick " + P_0.guid.ToString() + "\nReason: " + text);
				return null;
			}
			return controllerMap_Editor.GzWVrEYsmRkfzhyPqGfWHqUUaGBW(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap CdvxmHxvyiqUaqWQAaBANLChZjXF(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.IGEHkEuFsqJKrUsbmEUhfZlcQsHB(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.IGEHkEuFsqJKrUsbmEUhfZlcQsHB(Guid.Empty);
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
				list.Add(allMap.kzHrLfsGRteEloHDejoDrezLTRte);
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
			ControllerMap_Editor controllerMap_Editor = aQxNBGMYxYQfBaXwqlPeNuNbMvHL(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.DtJplVINApQfcgyaPlrBoiCGqZZA(containsActionDelegate);
				keyboardMap.xDzzsQwzjWrlDDiXpbLnCjJHLUieb(keyboard.gLbADvCdALkEcLIQPhWpjDrhhunKA, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.QzFzdDuccugshrrKBtQQCEKWyaRb(keyboard.gLbADvCdALkEcLIQPhWpjDrhhunKA, categoryId, layoutId);
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
			ControllerMap_Editor controllerMap_Editor = aQxNBGMYxYQfBaXwqlPeNuNbMvHL(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.XfWiykqIpULysKOtRAuxVNnIQEgV(containsActionDelegate);
				mouseMap.UwPYVJHSdykFaKKEdFCtjAMSefFaA(mouse.gLbADvCdALkEcLIQPhWpjDrhhunKA, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.IutFGGubdGcNoGJysPpFgsIVHoRbb(mouse.gLbADvCdALkEcLIQPhWpjDrhhunKA, categoryId, layoutId);
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

		internal CustomControllerMap YmbxuyuXpSmSheLBzftpCALfaFcqA(Guid P_0, int P_1, int P_2)
		{
			return HnISkAWIGDbnyESlpNMQzpLDPbSNA(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap FOpnPAIEvAFTsdbpngFJvcNiJQaEb(int P_0, int P_1, int P_2)
		{
			return HnISkAWIGDbnyESlpNMQzpLDPbSNA(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap HnISkAWIGDbnyESlpNMQzpLDPbSNA(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = kWYkjhXZFZwbIlKPrAioqzkPDrQK(P_1, id, P_2, false);
			if (controllerMap_Editor != null)
			{
				CustomControllerMap customControllerMap = controllerMap_Editor.LLDeDgrsVgGTzsaDrDdiAirNEhKsA(ContainsAction, P_0);
				customControllerMap.QsXlCWfVTNticjuMODNXQONqflPF(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			CustomControllerMap customControllerMap2 = CustomControllerMap.JvsHWcJkUQLUTXzMkcTLfkOAgVihA(P_0.typeGuid, id, P_1, P_2);
			customControllerMap2.QsXlCWfVTNticjuMODNXQONqflPF(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap2;
		}

		private ControllerMap_Editor kWYkjhXZFZwbIlKPrAioqzkPDrQK(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = MNdaXrsaEPwOHebgvfWhHpbQWGMiA(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor MNdaXrsaEPwOHebgvfWhHpbQWGMiA(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				bJTPbjEPUxvmigpEpbIByxvAEVIE(list, customControllerLayouts);
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

		internal ControllerTemplateMap KEvHIvSAbvNISdOVKPguruDeXAM(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.YgfcEwhlFhKEWeigjOIlJgMOoJAlA();
		}

		public void AddCustomController()
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			customControllers.Add(ctmTByBkaZBmWVxjCxHBxCrqvICR());
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
			customControllers.Insert(index, ctmTByBkaZBmWVxjCxHBxCrqvICR());
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
			controllerMapLayoutManagerRuleSets.Add(GVFbENbXcQxbgfnqPZjQdMuqGQVdA());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, GVFbENbXcQxbgfnqPZjQdMuqGQVdA());
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
			controllerMapEnablerRuleSets.Add(PzxgzJoxquktNUuCfvSWlwJgwOVN());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, PzxgzJoxquktNUuCfvSWlwJgwOVN());
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

		private Player_Editor pMUkQoBnLXMybzmoltSGGmlbdlTO()
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

		private InputAction GOzthWNqgfoSEEcHmzRmmJwbmahD()
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

		private InputCategory DJHeuXRwNpywwhRaUJCHZMpDqIIH()
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

		private InputBehavior aWAzyWuxXcMXTCmcKrvRhgnGIcuW()
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

		private InputMapCategory reMXARRYrKQeKjuFxUdQvDKYLFpk()
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

		private InputLayout TjfkfPcZnmvdrnPAPbJoGVjdOXSTA()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewJoystickLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout WBzhloqQktZkXuqsUguwvlusulrv()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewKeyboardLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout wUxwaJhAStMxHhbVxXhYbQWnzjaV()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewMouseLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout omoGwmCVBilIVTlTvJIFtPLRDIPW()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewCustomControllerLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private CustomController_Editor ctmTByBkaZBmWVxjCxHBxCrqvICR()
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

		private ControllerMapLayoutManager_RuleSet_Editor GVFbENbXcQxbgfnqPZjQdMuqGQVdA()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor
			{
				id = GetNewControllerMapLayoutManagerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames())
			};
		}

		private ControllerMapEnabler_RuleSet_Editor PzxgzJoxquktNUuCfvSWlwJgwOVN()
		{
			return new ControllerMapEnabler_RuleSet_Editor
			{
				id = GetNewControllerMapEnablerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames())
			};
		}

		private ControllerMap_Editor tBDmMehwyRosWBOrBsvrOqebUMeX(List<ControllerMap_Editor> P_0, int P_1, int P_2)
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

		private ControllerMap_Editor aQxNBGMYxYQfBaXwqlPeNuNbMvHL(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = tBDmMehwyRosWBOrBsvrOqebUMeX(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = JhZfoZBbZYwWasNfgxqKWoYcQshjA(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor JhZfoZBbZYwWasNfgxqKWoYcQshjA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				bJTPbjEPUxvmigpEpbIByxvAEVIE(list, P_1);
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

		private void bJTPbjEPUxvmigpEpbIByxvAEVIE(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			RFjkWrMetwyTGHALUOcFIlFjOjFx rFjkWrMetwyTGHALUOcFIlFjOjFx = new RFjkWrMetwyTGHALUOcFIlFjOjFx();
			rFjkWrMetwyTGHALUOcFIlFjOjFx.YpqIYUykfDdbVqNqnrHprDqVxJoX = P_1;
			if (P_0 != null && rFjkWrMetwyTGHALUOcFIlFjOjFx.YpqIYUykfDdbVqNqnrHprDqVxJoX != null)
			{
				P_0.Sort(rFjkWrMetwyTGHALUOcFIlFjOjFx.MQYWehlNkvsnhAiobeprANrvtYOgA);
			}
		}

		internal void FIoTzaLiABjUAwDEDTJFlnqAPkqp()
		{
			EUylEkfoKkBUEodVsyHiwCsvjWhO = new ReadOnlyCollection<Player_Editor>(players);
			PEFTXXILkxxfGxTGEcImyNOuGVDG = new ReadOnlyCollection<InputAction>(actions);
			RZGeymbvACCaHRQDBiCaiOLWZaWWA = new ReadOnlyCollection<InputCategory>(actionCategories);
			UUgGtNfJqXCkbBfaVYhsajngoxYJA = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
			ckIHfthJnEQqFUQQhKHZpqLnWNQH = new ReadOnlyCollection<InputMapCategory>(mapCategories);
			soeahDnvWEUInkXpARYGfVZaEGgH = new ReadOnlyCollection<InputLayout>(joystickLayouts);
			GRVglZafkGhPDbzQDTqQNLFHEITLb = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
			XCFOJdLTNnjYWkByIFJXmtPtnpXA = new ReadOnlyCollection<InputLayout>(mouseLayouts);
			ABMPfALCxGYKrCWXBvyTJnHswxzb = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
			DPhLsVGYcRTLkxnsrVlQDYDvWfvB = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
			bSksfGWqOInULFPpNhryLhvYdQlH = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
			WwGivMRIatrbOicZHeFTokxPOujw = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
			YtGZDhCqPUgExXXhPMxAZZiEaCmM = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
			wNmyHEQABQnYbDbNWtFgNWnQOlmF = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
			BuniSdZyNkRGAZDCCqFpFCMgSAxr = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					mapCategories[i].rSyTHyXkIGbMpdytsNHCjJWnyvKP();
				}
			}
			containsActionDelegate = ContainsAction;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return SkqigAaSReBCXzHgXElbhXcqydLeA.KwiKfbxuUjcMaQGNgtipopEjBkjb(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return SkqigAaSReBCXzHgXElbhXcqydLeA.KwiKfbxuUjcMaQGNgtipopEjBkjb(orig, null, false);
		}
	}
}
