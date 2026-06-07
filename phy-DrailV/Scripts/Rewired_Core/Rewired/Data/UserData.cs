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
		private static class NESlgRZGJpioPWtcyNENFepJIOVL
		{
			[DefaultMember("Item")]
			private class yyAxRDZNDsMbpQvGxZHwJtmcRMfJ
			{
				public enum YChXseGFUVZKknkYzbuIofGRIXZGA
				{
					origId = 0,
					otherId = 1,
					finalId = 2
				}

				public int ScxlhjYsjYZgNenjJqHujcAmBhT;

				public int KcHFLnCVOTzHfVZZpukUwUwsOxTwA;

				public int tZUQhjEdVfXpubmmojIITceXnFwl;

				public int TOeQjtXAmEJKcihHdegXiMOIfTTY
				{
					get
					{
						switch (P_0)
						{
						case YChXseGFUVZKknkYzbuIofGRIXZGA.origId:
							return ScxlhjYsjYZgNenjJqHujcAmBhT;
						case YChXseGFUVZKknkYzbuIofGRIXZGA.otherId:
							return KcHFLnCVOTzHfVZZpukUwUwsOxTwA;
						case YChXseGFUVZKknkYzbuIofGRIXZGA.finalId:
							return tZUQhjEdVfXpubmmojIITceXnFwl;
						default:
							throw new NotImplementedException();
						}
					}
					set
					{
						switch (yChXseGFUVZKknkYzbuIofGRIXZGA)
						{
						case YChXseGFUVZKknkYzbuIofGRIXZGA.origId:
							ScxlhjYsjYZgNenjJqHujcAmBhT = num;
							break;
						case YChXseGFUVZKknkYzbuIofGRIXZGA.otherId:
							KcHFLnCVOTzHfVZZpukUwUwsOxTwA = num;
							break;
						case YChXseGFUVZKknkYzbuIofGRIXZGA.finalId:
							tZUQhjEdVfXpubmmojIITceXnFwl = num;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public yyAxRDZNDsMbpQvGxZHwJtmcRMfJ(int P_0, int P_1, int P_2)
				{
					ScxlhjYsjYZgNenjJqHujcAmBhT = P_0;
					KcHFLnCVOTzHfVZZpukUwUwsOxTwA = P_1;
					tZUQhjEdVfXpubmmojIITceXnFwl = P_2;
				}

				public virtual string zhvSrttkLSIzbfVTkvOZAisVnpncb()
				{
					return string.Concat(string.Concat("" + StringTools.WriteVar("origId", ScxlhjYsjYZgNenjJqHujcAmBhT), StringTools.WriteVar("otherId", KcHFLnCVOTzHfVZZpukUwUwsOxTwA)), StringTools.WriteVar("finalId", tZUQhjEdVfXpubmmojIITceXnFwl));
				}
			}

			private class gaNgZAlYQXyWCKaSgYHXpdgoCJNe<_0001>
			{
				public _0001 qVIhdeCzBaNPQTeesZwdZeelnoFX;

				public _0001 nOFhTuQEBAVAzPVeoRwZEwBhwPjO;

				public yyAxRDZNDsMbpQvGxZHwJtmcRMfJ.YChXseGFUVZKknkYzbuIofGRIXZGA aNVDzOSlSERVZPtqDlrcwarJBwwo;

				public IList<_0001> LuIZRJvCFAsNCmXoUkqHLxUygUEb;

				public bool EzjQDYoKAsnaPCJwFoITRwVRQAPy;

				public gaNgZAlYQXyWCKaSgYHXpdgoCJNe(_0001 P_0, _0001 P_1, yyAxRDZNDsMbpQvGxZHwJtmcRMfJ.YChXseGFUVZKknkYzbuIofGRIXZGA P_2, IList<_0001> P_3, bool P_4)
				{
					qVIhdeCzBaNPQTeesZwdZeelnoFX = P_0;
					nOFhTuQEBAVAzPVeoRwZEwBhwPjO = P_1;
					aNVDzOSlSERVZPtqDlrcwarJBwwo = P_2;
					LuIZRJvCFAsNCmXoUkqHLxUygUEb = P_3;
					EzjQDYoKAsnaPCJwFoITRwVRQAPy = P_4;
				}
			}

			[Serializable]
			private sealed class idpEEcAXjmWbOodRjUcatjPJOyGiA
			{
				public static readonly idpEEcAXjmWbOodRjUcatjPJOyGiA _003C_003E9 = new idpEEcAXjmWbOodRjUcatjPJOyGiA();

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

				internal int MmJgvOTchqbaevGDzmaBXftadhsD(InputActionCategory P_0)
				{
					return P_0.id;
				}

				internal string PBsrzfzBPrBWhqiUbzBOcxmoCVMy(InputActionCategory P_0)
				{
					return P_0.name;
				}

				internal int sKXPeibZCshEibNJajqbixGTIvaIA(InputActionCategory P_0, IList<InputActionCategory> P_1)
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

				internal int WtzGutOjQvLliNzOdjFeAuEaBeOs(InputBehavior P_0)
				{
					return P_0.id;
				}

				internal string ylZpSguuUQfRQthJlRYehKDaSRAK(InputBehavior P_0)
				{
					return P_0.name;
				}

				internal int gITGwCaDWKcdyflpScxZCXYfaTujB(InputBehavior P_0, IList<InputBehavior> P_1)
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

				internal int gKRYOdngLvDczKdKAILbioEoCUDDA(InputAction P_0)
				{
					return P_0.id;
				}

				internal string HcVxfGGwNOmYWngICCQkXkFOeVjn(InputAction P_0)
				{
					return P_0.name;
				}

				internal int eNUZnukpNmyCBTeSFjvULuQOWqGy(InputAction P_0, IList<InputAction> P_1)
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

				internal int rOOeSRglubclVjUuGiMeGodVdTvA(InputMapCategory P_0)
				{
					return P_0.id;
				}

				internal string FDORdoaoMYcxPtaNDqHHEiwPRnBH(InputMapCategory P_0)
				{
					return P_0.name;
				}

				internal int lqGHDcfWnmWprzBosdmyAPXAhejB(InputMapCategory P_0, IList<InputMapCategory> P_1)
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

				internal int TuyLjvnKzolwCzixmDTEwgoKrfwC(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string lqzgxgCNNSdvrCBoyulHcgSyrLPW(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int RRREldEDdYaLGKgCpfBHRTgaUlqnA(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int evyWBntcMoXtuIAZhKcWMOmDqfJc(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string bIcrIYhAGUHHWJWPtttLJYWnpfyZ(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int ZuYoOmJIyyxSOSNCJNpOIcisiNRE(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int nvYlmaHCfqdGqlbrqJfiGORCJuXv(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string JonQktwgMQhRuwgexdrCAvdkoOVmA(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int FhEEdvbBKECWJiJaZqKYyCznRiId(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int QckAslQSoGoARdMwPvQGkZgzPGZg(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string rHSCTWIwxGRDgEvbsCFinZvhhnwjA(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int mrleqiVMSSArjWWitnezsFaUgqPEA(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int yHFMHaSTUUUadsObECQEgDlIEwXE(CustomController_Editor P_0)
				{
					return P_0.id;
				}

				internal string dIGQewqOBgpQELHeufJLJJVmEmJK(CustomController_Editor P_0)
				{
					return P_0.name;
				}

				internal int USurCZrNGnvGLMkxVJDwEAusREtg(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
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

				internal int LBpjgxagGVshjCVvqrbMrWguWKxH(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string NppFPCKzqogAiFmofYOWmrhTFIYP(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int SWLjiSFkcgtAkbOxqtPNivXfkpzi(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
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

				internal int wPfOQGagQLQgpjELQphCYuukFshj(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string XdKHHGhiLdHQWHdzxVmhxesCFAgFA(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int sKClVGKmajDsJyWSMOFNSAxpZuJF(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
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

				internal int brrjDAxZNdqwCafGkkxiMQODiDOo(Player_Editor P_0)
				{
					return P_0.id;
				}

				internal string mDnkmbuaaOsRhKRPKJImVcegLYGi(Player_Editor P_0)
				{
					return P_0.name;
				}

				internal int yqPkTvNUgMMNnVfXnPkKUJMYlQBM(Player_Editor P_0, IList<Player_Editor> P_1)
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

				internal int ePNbcgbFCJGbnEfaBVHIKfkOOAtCB(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
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

				internal int EXLTJphRzwhWBaRIGpiEpyWMGHus(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
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

				internal int BjMMwWqcVMRiWxcgiTDyZmssFEHS(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string oaXTfiMhdgkKUckeYFfgdWZjGyDy(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int ibommJCMFedOpYVnnVuUyWqCysNI(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int IyFbuLFCLhYersVmXopUghOwYZRx(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string NZMtVtyFOGEKkHEKJjusSOCPkkKb(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int HUIyWowuRijfMOceaCesPToUCbeg(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int YUHhEnpVIcKTKjQOnbymjSankujC(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string QCvgPZZtMtManiFEDKcZUErOPlxy(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int kgcsgKchgzdNkkkwkVfNUiQvzCoDA(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int LykixZCxiFfnWpDgPSzBFdPXkOKE(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string cqFJbICpiDiGjdjNRFuGnYFdiEwWA(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int VBJSZMFHXbsruHqxkGSdpjHYZpCQ(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class lYbESakveqfQSFPBhMVsTOTLLfVbA
			{
				public UserData jJFJfGtcIkdwFLyodCskdwTNtZOB;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> eyingmhBJLCLkIrxYTAmLcQNFqpm;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> qKDBBwsoOocyiAHmBNCRgIrshXBdA;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> rMCKHVjOWJUdszJamHECUaKMiCwo;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> jTdQWfUWVBeleRisYbXwowkSOGWt;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> PfWrhYlfqZZcqjmgxRMDtfvpkveL;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> MBHRuBszjBARgqbfhJIRzftmntmf;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> NBeZbRqhdodYzhGqHhpLRBucjbeLA;

				public Func<ControllerType, List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>> CXbfSxFlyJxZOohxRrJIhUsKJdgEA;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> uaWjHqTKaECJugDYVdnWRnecAAspA;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> dtyoYabKuKtDHPLsgYcXSThBTAar;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> iBUPAdvPsugieTgZaCpMHNVPqKipA;

				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> ycNDoowLUPNTBtwIsGdftWwWXDR;

				internal InputActionCategory rvBMtSXArSdcYqPucIXfCGEZaZWFA(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<InputActionCategory> P_0)
				{
					InputActionCategory inputActionCategory = JsonTools.Clone(P_0.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					InputActionCategory inputActionCategory2;
					if (P_0.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						inputActionCategory2 = P_0.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddActionCategory();
						inputActionCategory2 = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					inputActionCategory.id = inputActionCategory2.id;
					int index = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(inputActionCategory2);
					P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = inputActionCategory;
					return inputActionCategory;
				}

				internal InputBehavior aklAvFSpgiMRXkNVbnguNxivjdXx(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					InputBehavior inputBehavior2;
					if (P_0.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						inputBehavior2 = P_0.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddInputBehavior();
						inputBehavior2 = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(inputBehavior2);
					P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = inputBehavior;
					return inputBehavior;
				}

				internal InputAction nirZGEoNNKWXHSijLVSCgAzmTusU(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<InputAction> P_0)
				{
					RzcYNRRGLVtkzADcbfmnOnxfVSiy rzcYNRRGLVtkzADcbfmnOnxfVSiy = new RzcYNRRGLVtkzADcbfmnOnxfVSiy();
					rzcYNRRGLVtkzADcbfmnOnxfVSiy.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc = P_0;
					InputAction inputAction = JsonTools.Clone(rzcYNRRGLVtkzADcbfmnOnxfVSiy.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					int num = eyingmhBJLCLkIrxYTAmLcQNFqpm.Find(rzcYNRRGLVtkzADcbfmnOnxfVSiy.yxVKKHTMjXaklSUlhNPFoJWOIVRf)?.tZUQhjEdVfXpubmmojIITceXnFwl ?? 0;
					InputAction inputAction2;
					if (rzcYNRRGLVtkzADcbfmnOnxfVSiy.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						inputAction2 = rzcYNRRGLVtkzADcbfmnOnxfVSiy.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddAction(num);
						inputAction2 = rzcYNRRGLVtkzADcbfmnOnxfVSiy.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[rzcYNRRGLVtkzADcbfmnOnxfVSiy.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					int num2 = qKDBBwsoOocyiAHmBNCRgIrshXBdA.Find(rzcYNRRGLVtkzADcbfmnOnxfVSiy.vogkdCYDuhgMPxvSgWSefBknZhBF)?.tZUQhjEdVfXpubmmojIITceXnFwl ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = num2;
					int index = rzcYNRRGLVtkzADcbfmnOnxfVSiy.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(inputAction2);
					rzcYNRRGLVtkzADcbfmnOnxfVSiy.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = inputAction;
					return inputAction;
				}

				internal InputLayout bkrngyekChJwkeClvmwTuZVqeSXM(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					InputLayout inputLayout2;
					if (P_0.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						inputLayout2 = P_0.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddKeyboardLayout();
						inputLayout2 = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(inputLayout2);
					P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout KrdZElXFaqxyUAAXYgCrouUZXafs(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					InputLayout inputLayout2;
					if (P_0.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						inputLayout2 = P_0.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddMouseLayout();
						inputLayout2 = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(inputLayout2);
					P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout clfIyMFCeHGVKQgnuXUdBzUHZehC(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					InputLayout inputLayout2;
					if (P_0.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						inputLayout2 = P_0.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddJoystickLayout();
						inputLayout2 = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(inputLayout2);
					P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout zoLPetZpOyaqeOvxYfjLTMOVxKql(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					InputLayout inputLayout2;
					if (P_0.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						inputLayout2 = P_0.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddCustomControllerLayout();
						inputLayout2 = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(inputLayout2);
					P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = inputLayout;
					return inputLayout;
				}

				internal List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> VIXTJoDsCZBBDsSnIMUjGWPwpuTs(ControllerType P_0)
				{
					switch (P_0)
					{
					case ControllerType.Keyboard:
						return rMCKHVjOWJUdszJamHECUaKMiCwo;
					case ControllerType.Mouse:
						return jTdQWfUWVBeleRisYbXwowkSOGWt;
					case ControllerType.Joystick:
						return PfWrhYlfqZZcqjmgxRMDtfvpkveL;
					case ControllerType.Custom:
						return MBHRuBszjBARgqbfhJIRzftmntmf;
					default:
						throw new NotImplementedException();
					}
				}

				internal CustomController_Editor jmiIIsGDkyalnjXCAJQaWrSUXnAuA(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					CustomController_Editor customController_Editor2;
					if (P_0.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						customController_Editor2 = P_0.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddCustomController(Guid.Empty);
						customController_Editor2 = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(customController_Editor2);
					P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = customController_Editor;
					return customController_Editor;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor ZaYQvECpRLsyswJoPQEXsiRjgayjA(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					iGqxXQiLVfnvGYUmzjCSqIwSxCCu iGqxXQiLVfnvGYUmzjCSqIwSxCCu2 = new iGqxXQiLVfnvGYUmzjCSqIwSxCCu();
					iGqxXQiLVfnvGYUmzjCSqIwSxCCu2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(iGqxXQiLVfnvGYUmzjCSqIwSxCCu2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.qVIhdeCzBaNPQTeesZwdZeelnoFX);
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
							LRFCNZuAfDzJhiviwOEwYKDPdHvdA lRFCNZuAfDzJhiviwOEwYKDPdHvdA = new LRFCNZuAfDzJhiviwOEwYKDPdHvdA();
							lRFCNZuAfDzJhiviwOEwYKDPdHvdA.TNokMlcLtgKxmGbLYMePjMMQdVaO = iGqxXQiLVfnvGYUmzjCSqIwSxCCu2;
							lRFCNZuAfDzJhiviwOEwYKDPdHvdA.BUVIlhzUfJRniawFBWmKIevGUydb = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(lRFCNZuAfDzJhiviwOEwYKDPdHvdA.erBdbNRunBMPCoTrJSFQnQHJRZvp);
							if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + lRFCNZuAfDzJhiviwOEwYKDPdHvdA.BUVIlhzUfJRniawFBWmKIevGUydb);
							}
							else
							{
								list.Add(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2.tZUQhjEdVfXpubmmojIITceXnFwl);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						jYLKwjZPpkUdfAQadPmVMpGyFzkZ jYLKwjZPpkUdfAQadPmVMpGyFzkZ2 = new jYLKwjZPpkUdfAQadPmVMpGyFzkZ();
						jYLKwjZPpkUdfAQadPmVMpGyFzkZ2.ZYUxwUiFLIBBzCbNkwLtiBOMDDnh = iGqxXQiLVfnvGYUmzjCSqIwSxCCu2;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> list2 = CXbfSxFlyJxZOohxRrJIhUsKJdgEA(controllerType);
							jYLKwjZPpkUdfAQadPmVMpGyFzkZ2.BUVIlhzUfJRniawFBWmKIevGUydb = controllerMapLayoutManager_Rule_Editor2.layoutId;
							yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = list2.Find(jYLKwjZPpkUdfAQadPmVMpGyFzkZ2.nzywXKxNVtuMzMtdLhlpsqzRbUcEA);
							if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + jYLKwjZPpkUdfAQadPmVMpGyFzkZ2.BUVIlhzUfJRniawFBWmKIevGUydb);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3.tZUQhjEdVfXpubmmojIITceXnFwl;
							}
						}
					}
					int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							oNQdfvXeUOcxkVKHIBztEgLbyLac oNQdfvXeUOcxkVKHIBztEgLbyLac2 = new oNQdfvXeUOcxkVKHIBztEgLbyLac();
							oNQdfvXeUOcxkVKHIBztEgLbyLac2.gLvcQMNbydpYpCgxjrFTlUpXOhvk = iGqxXQiLVfnvGYUmzjCSqIwSxCCu2;
							List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> list3 = uaWjHqTKaECJugDYVdnWRnecAAspA;
							oNQdfvXeUOcxkVKHIBztEgLbyLac2.BUVIlhzUfJRniawFBWmKIevGUydb = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 = list3.Find(oNQdfvXeUOcxkVKHIBztEgLbyLac2.SeNgHTAQljbUcxMcULofDIFHKWdIA);
							if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + oNQdfvXeUOcxkVKHIBztEgLbyLac2.BUVIlhzUfJRniawFBWmKIevGUydb);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4.tZUQhjEdVfXpubmmojIITceXnFwl;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (iGqxXQiLVfnvGYUmzjCSqIwSxCCu2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = iGqxXQiLVfnvGYUmzjCSqIwSxCCu2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = iGqxXQiLVfnvGYUmzjCSqIwSxCCu2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[iGqxXQiLVfnvGYUmzjCSqIwSxCCu2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = iGqxXQiLVfnvGYUmzjCSqIwSxCCu2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					iGqxXQiLVfnvGYUmzjCSqIwSxCCu2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				internal ControllerMapEnabler_RuleSet_Editor vtZnQpgAdqXHJDKxnZvtUWkQTKvX(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					raOJvMukogMNzgKnEEitijNrsoji raOJvMukogMNzgKnEEitijNrsoji2 = new raOJvMukogMNzgKnEEitijNrsoji();
					raOJvMukogMNzgKnEEitijNrsoji2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(raOJvMukogMNzgKnEEitijNrsoji2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.qVIhdeCzBaNPQTeesZwdZeelnoFX);
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
							BGBGmsdVLApoEbtSeHAneaCiJhiW bGBGmsdVLApoEbtSeHAneaCiJhiW = new BGBGmsdVLApoEbtSeHAneaCiJhiW();
							bGBGmsdVLApoEbtSeHAneaCiJhiW.qqzqNXtqlghbBLhtHmCncNLWBXxz = raOJvMukogMNzgKnEEitijNrsoji2;
							bGBGmsdVLApoEbtSeHAneaCiJhiW.BUVIlhzUfJRniawFBWmKIevGUydb = controllerMapEnabler_Rule_Editor.categoryIds[j];
							yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(bGBGmsdVLApoEbtSeHAneaCiJhiW.slZMMUFHenfqVBalxNiSoBHZFGGs);
							if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + bGBGmsdVLApoEbtSeHAneaCiJhiW.BUVIlhzUfJRniawFBWmKIevGUydb);
							}
							else
							{
								list.Add(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2.tZUQhjEdVfXpubmmojIITceXnFwl);
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
						List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> list2 = CXbfSxFlyJxZOohxRrJIhUsKJdgEA(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							lqyQXTeAASmSGipROPytQMrMarmh lqyQXTeAASmSGipROPytQMrMarmh2 = new lqyQXTeAASmSGipROPytQMrMarmh();
							lqyQXTeAASmSGipROPytQMrMarmh2.QVVsnUALcEeUFddnwqfhglrbKEqyB = raOJvMukogMNzgKnEEitijNrsoji2;
							lqyQXTeAASmSGipROPytQMrMarmh2.BUVIlhzUfJRniawFBWmKIevGUydb = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = list2.Find(lqyQXTeAASmSGipROPytQMrMarmh2.jZWbhrOVIiZEwxBAzXjuadVXOZVj);
							if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 == null)
							{
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + lqyQXTeAASmSGipROPytQMrMarmh2.BUVIlhzUfJRniawFBWmKIevGUydb);
							}
							else
							{
								list3.Add(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3.tZUQhjEdVfXpubmmojIITceXnFwl);
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
							uYZRBsuTPysgSWxIMmTpdfBNcSSEA uYZRBsuTPysgSWxIMmTpdfBNcSSEA2 = new uYZRBsuTPysgSWxIMmTpdfBNcSSEA();
							uYZRBsuTPysgSWxIMmTpdfBNcSSEA2.HMvgnDaSsfBbLgRWnRsJWAbMtZgEA = raOJvMukogMNzgKnEEitijNrsoji2;
							List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> list4 = uaWjHqTKaECJugDYVdnWRnecAAspA;
							uYZRBsuTPysgSWxIMmTpdfBNcSSEA2.BUVIlhzUfJRniawFBWmKIevGUydb = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 = list4.Find(uYZRBsuTPysgSWxIMmTpdfBNcSSEA2.ZdbJhTWlRzguHFqXaFXyioWepCRjb);
							if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + uYZRBsuTPysgSWxIMmTpdfBNcSSEA2.BUVIlhzUfJRniawFBWmKIevGUydb);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4.tZUQhjEdVfXpubmmojIITceXnFwl;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (raOJvMukogMNzgKnEEitijNrsoji2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						controllerMapEnabler_RuleSet_Editor2 = raOJvMukogMNzgKnEEitijNrsoji2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = raOJvMukogMNzgKnEEitijNrsoji2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[raOJvMukogMNzgKnEEitijNrsoji2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = raOJvMukogMNzgKnEEitijNrsoji2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					raOJvMukogMNzgKnEEitijNrsoji2.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				internal Player_Editor VpfebDVGCxdnOzFLebyeueVHIOqc(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<Player_Editor> P_0)
				{
					AmahNfjshcYWWjrHWOqoPcZSSfYM amahNfjshcYWWjrHWOqoPcZSSfYM = new AmahNfjshcYWWjrHWOqoPcZSSfYM();
					amahNfjshcYWWjrHWOqoPcZSSfYM.WqhcWzbpVMUmadMJCZpInNvtWjjkA = this;
					amahNfjshcYWWjrHWOqoPcZSSfYM.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc = P_0;
					Player_Editor player_Editor = JsonTools.Clone(amahNfjshcYWWjrHWOqoPcZSSfYM.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					Action<List<Player_Editor.Mapping>, List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>> action = amahNfjshcYWWjrHWOqoPcZSSfYM.hdYFOBKNCriwPWyWUsActAgTNhofA;
					action(player_Editor.defaultKeyboardMaps, rMCKHVjOWJUdszJamHECUaKMiCwo);
					action(player_Editor.defaultMouseMaps, jTdQWfUWVBeleRisYbXwowkSOGWt);
					action(player_Editor.defaultJoystickMaps, PfWrhYlfqZZcqjmgxRMDtfvpkveL);
					action(player_Editor.defaultCustomControllerMaps, MBHRuBszjBARgqbfhJIRzftmntmf);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						jWFDtMPKzqbGDCWVODjgVDoCGkxn jWFDtMPKzqbGDCWVODjgVDoCGkxn2 = new jWFDtMPKzqbGDCWVODjgVDoCGkxn();
						jWFDtMPKzqbGDCWVODjgVDoCGkxn2.etCouCNxrOHBYZKhQxlyZjaQCpAb = amahNfjshcYWWjrHWOqoPcZSSfYM;
						jWFDtMPKzqbGDCWVODjgVDoCGkxn2.VwpBgMvWwAXYQzeWHeKuTetHBYkFA = player_Editor.startingCustomControllers[i];
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = uaWjHqTKaECJugDYVdnWRnecAAspA.Find(jWFDtMPKzqbGDCWVODjgVDoCGkxn2.YFUrCfgfmbjyXJMVOJCjxbOtfqjo);
						jWFDtMPKzqbGDCWVODjgVDoCGkxn2.VwpBgMvWwAXYQzeWHeKuTetHBYkFA.sourceId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						gbdEVeiROlNPCEFPvhRkTcsqaeqsA gbdEVeiROlNPCEFPvhRkTcsqaeqsA2 = new gbdEVeiROlNPCEFPvhRkTcsqaeqsA();
						gbdEVeiROlNPCEFPvhRkTcsqaeqsA2.LkHxnFrINQZmZDbRQgCzQrofBbKe = amahNfjshcYWWjrHWOqoPcZSSfYM;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							gbdEVeiROlNPCEFPvhRkTcsqaeqsA2.krsTtHLNxEdniCjaeNCXXDxqAnqr = ruleSetMapping.id;
							yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = dtyoYabKuKtDHPLsgYcXSThBTAar.Find(gbdEVeiROlNPCEFPvhRkTcsqaeqsA2.ApWXvqMPIzChnbmQhOpbfpGtlkKiA);
							if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + gbdEVeiROlNPCEFPvhRkTcsqaeqsA2.krsTtHLNxEdniCjaeNCXXDxqAnqr);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3.tZUQhjEdVfXpubmmojIITceXnFwl;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						uWdKgaNOwpfpaFLILLGpdsXntNXc uWdKgaNOwpfpaFLILLGpdsXntNXc2 = new uWdKgaNOwpfpaFLILLGpdsXntNXc();
						uWdKgaNOwpfpaFLILLGpdsXntNXc2.gDrJEvXewlcMaHWdOzLkeHTviqyI = amahNfjshcYWWjrHWOqoPcZSSfYM;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							uWdKgaNOwpfpaFLILLGpdsXntNXc2.krsTtHLNxEdniCjaeNCXXDxqAnqr = ruleSetMapping2.id;
							yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 = iBUPAdvPsugieTgZaCpMHNVPqKipA.Find(uWdKgaNOwpfpaFLILLGpdsXntNXc2.etQawXcaqUpQhPVrjpihctrMNWri);
							if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + uWdKgaNOwpfpaFLILLGpdsXntNXc2.krsTtHLNxEdniCjaeNCXXDxqAnqr);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4.tZUQhjEdVfXpubmmojIITceXnFwl;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (amahNfjshcYWWjrHWOqoPcZSSfYM.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						player_Editor2 = amahNfjshcYWWjrHWOqoPcZSSfYM.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.ePNbcgbFCJGbnEfaBVHIKfkOOAtCB;
						eUtdQbbknnlfUrtdsIrTxEIYWCinA(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						eUtdQbbknnlfUrtdsIrTxEIYWCinA(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						eUtdQbbknnlfUrtdsIrTxEIYWCinA(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						eUtdQbbknnlfUrtdsIrTxEIYWCinA(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						eUtdQbbknnlfUrtdsIrTxEIYWCinA(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.EXLTJphRzwhWBaRIGpiEpyWMGHus);
						player_Editor = player_Editor3;
					}
					else
					{
						jJFJfGtcIkdwFLyodCskdwTNtZOB.AddPlayer();
						player_Editor2 = amahNfjshcYWWjrHWOqoPcZSSfYM.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[amahNfjshcYWWjrHWOqoPcZSSfYM.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = amahNfjshcYWWjrHWOqoPcZSSfYM.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(player_Editor2);
					amahNfjshcYWWjrHWOqoPcZSSfYM.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = player_Editor;
					return player_Editor;
				}
			}

			private sealed class RzcYNRRGLVtkzADcbfmnOnxfVSiy
			{
				public gaNgZAlYQXyWCKaSgYHXpdgoCJNe<InputAction> bKpDPEBSUWmZyeIhbHaLlYeEnhUcc;

				internal bool yxVKKHTMjXaklSUlhNPFoJWOIVRf(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.qVIhdeCzBaNPQTeesZwdZeelnoFX.categoryId;
				}

				internal bool vogkdCYDuhgMPxvSgWSefBknZhBF(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.qVIhdeCzBaNPQTeesZwdZeelnoFX.behaviorId;
				}
			}

			private sealed class lqyQXTeAASmSGipROPytQMrMarmh
			{
				public int BUVIlhzUfJRniawFBWmKIevGUydb;

				public raOJvMukogMNzgKnEEitijNrsoji QVVsnUALcEeUFddnwqfhglrbKEqyB;

				internal bool jZWbhrOVIiZEwxBAzXjuadVXOZVj(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(QVVsnUALcEeUFddnwqfhglrbKEqyB.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == BUVIlhzUfJRniawFBWmKIevGUydb;
				}
			}

			private sealed class uYZRBsuTPysgSWxIMmTpdfBNcSSEA
			{
				public int BUVIlhzUfJRniawFBWmKIevGUydb;

				public raOJvMukogMNzgKnEEitijNrsoji HMvgnDaSsfBbLgRWnRsJWAbMtZgEA;

				internal bool ZdbJhTWlRzguHFqXaFXyioWepCRjb(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(HMvgnDaSsfBbLgRWnRsJWAbMtZgEA.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == BUVIlhzUfJRniawFBWmKIevGUydb;
				}
			}

			private sealed class AmahNfjshcYWWjrHWOqoPcZSSfYM
			{
				public gaNgZAlYQXyWCKaSgYHXpdgoCJNe<Player_Editor> bKpDPEBSUWmZyeIhbHaLlYeEnhUcc;

				public lYbESakveqfQSFPBhMVsTOTLLfVbA WqhcWzbpVMUmadMJCZpInNvtWjjkA;

				internal void hdYFOBKNCriwPWyWUsActAgTNhofA(List<Player_Editor.Mapping> P_0, List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> P_1)
				{
					for (int i = 0; i < P_0.Count; i++)
					{
						VdymdOSoMliMmjaKswAStZzBIyEd vdymdOSoMliMmjaKswAStZzBIyEd = new VdymdOSoMliMmjaKswAStZzBIyEd();
						vdymdOSoMliMmjaKswAStZzBIyEd.cMuZErBnqoXQPBvCNtgcmYGGkeoP = this;
						vdymdOSoMliMmjaKswAStZzBIyEd.hIRcayGSVFVtXIyAOejzVjenKtdeA = P_0[i];
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = WqhcWzbpVMUmadMJCZpInNvtWjjkA.NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(vdymdOSoMliMmjaKswAStZzBIyEd.GlpTxvXrAaGokyLGEYZcbEptcKyp);
						vdymdOSoMliMmjaKswAStZzBIyEd.hIRcayGSVFVtXIyAOejzVjenKtdeA.categoryId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = P_1.Find(vdymdOSoMliMmjaKswAStZzBIyEd.jmzacnGzIGDdCBGOKheGPJMEuTiEb);
						vdymdOSoMliMmjaKswAStZzBIyEd.hIRcayGSVFVtXIyAOejzVjenKtdeA.layoutId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					}
				}
			}

			private sealed class VdymdOSoMliMmjaKswAStZzBIyEd
			{
				public Player_Editor.Mapping hIRcayGSVFVtXIyAOejzVjenKtdeA;

				public AmahNfjshcYWWjrHWOqoPcZSSfYM cMuZErBnqoXQPBvCNtgcmYGGkeoP;

				internal bool GlpTxvXrAaGokyLGEYZcbEptcKyp(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(cMuZErBnqoXQPBvCNtgcmYGGkeoP.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == hIRcayGSVFVtXIyAOejzVjenKtdeA.categoryId;
				}

				internal bool jmzacnGzIGDdCBGOKheGPJMEuTiEb(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(cMuZErBnqoXQPBvCNtgcmYGGkeoP.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == hIRcayGSVFVtXIyAOejzVjenKtdeA.layoutId;
				}
			}

			private sealed class jWFDtMPKzqbGDCWVODjgVDoCGkxn
			{
				public Player_Editor.CreateControllerInfo VwpBgMvWwAXYQzeWHeKuTetHBYkFA;

				public AmahNfjshcYWWjrHWOqoPcZSSfYM etCouCNxrOHBYZKhQxlyZjaQCpAb;

				internal bool YFUrCfgfmbjyXJMVOJCjxbOtfqjo(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(etCouCNxrOHBYZKhQxlyZjaQCpAb.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == VwpBgMvWwAXYQzeWHeKuTetHBYkFA.sourceId;
				}
			}

			private sealed class gbdEVeiROlNPCEFPvhRkTcsqaeqsA
			{
				public int krsTtHLNxEdniCjaeNCXXDxqAnqr;

				public AmahNfjshcYWWjrHWOqoPcZSSfYM LkHxnFrINQZmZDbRQgCzQrofBbKe;

				internal bool ApWXvqMPIzChnbmQhOpbfpGtlkKiA(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(LkHxnFrINQZmZDbRQgCzQrofBbKe.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == krsTtHLNxEdniCjaeNCXXDxqAnqr;
				}
			}

			private sealed class uWdKgaNOwpfpaFLILLGpdsXntNXc
			{
				public int krsTtHLNxEdniCjaeNCXXDxqAnqr;

				public AmahNfjshcYWWjrHWOqoPcZSSfYM gDrJEvXewlcMaHWdOzLkeHTviqyI;

				internal bool etQawXcaqUpQhPVrjpihctrMNWri(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(gDrJEvXewlcMaHWdOzLkeHTviqyI.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == krsTtHLNxEdniCjaeNCXXDxqAnqr;
				}
			}

			private sealed class VYbgzMbEHbLrPnsPeZEDyYGdNQmK
			{
				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> VwIbCEZiYAlZWrKoJLDrHLSRnHcl;

				public lYbESakveqfQSFPBhMVsTOTLLfVbA uMOQSonVyolMBWPTOlCtBkaJfATv;

				internal int NyHTjVXppPCVrJJLcPDMbnUSxwuf(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					iSkLrWOCFXVATWUNlXbBNWIDzNdH iSkLrWOCFXVATWUNlXbBNWIDzNdH2 = new iSkLrWOCFXVATWUNlXbBNWIDzNdH();
					iSkLrWOCFXVATWUNlXbBNWIDzNdH2.VwpBgMvWwAXYQzeWHeKuTetHBYkFA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = uMOQSonVyolMBWPTOlCtBkaJfATv.NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(iSkLrWOCFXVATWUNlXbBNWIDzNdH2.LztrUQEAzbysSrKFADUYdLfYbUIeb);
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = VwIbCEZiYAlZWrKoJLDrHLSRnHcl.Find(iSkLrWOCFXVATWUNlXbBNWIDzNdH2.eUDtJmaBRWaZuRrSDkBZJuwlBqpI);
						if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 != null && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2.tZUQhjEdVfXpubmmojIITceXnFwl == P_1[i].categoryId && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 != null && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3.tZUQhjEdVfXpubmmojIITceXnFwl == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor XoLrVARmHmqNjhLnWHLkLhjFsgfn(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMap_Editor> P_0)
				{
					LgmwpztCDWCULaNgtlsuwDvoaaEg lgmwpztCDWCULaNgtlsuwDvoaaEg = new LgmwpztCDWCULaNgtlsuwDvoaaEg();
					lgmwpztCDWCULaNgtlsuwDvoaaEg.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc = P_0;
					lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb = JsonTools.Clone(lgmwpztCDWCULaNgtlsuwDvoaaEg.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = uMOQSonVyolMBWPTOlCtBkaJfATv.NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(lgmwpztCDWCULaNgtlsuwDvoaaEg.cMXgMMxgOEPusoiZdnZPInnZcbdF);
					yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = VwIbCEZiYAlZWrKoJLDrHLSRnHcl.Find(lgmwpztCDWCULaNgtlsuwDvoaaEg.YdsrkOLvliGlDFZwmvaufYLcSHeb);
					lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					for (int i = 0; i < lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps.Count; i++)
					{
						eQtgicwpjfLXAzBbriSiRbLGXhRW eQtgicwpjfLXAzBbriSiRbLGXhRW2 = new eQtgicwpjfLXAzBbriSiRbLGXhRW();
						eQtgicwpjfLXAzBbriSiRbLGXhRW2.ZQlpPrmExzYnpFDPHTzgvYcZLSQV = lgmwpztCDWCULaNgtlsuwDvoaaEg;
						eQtgicwpjfLXAzBbriSiRbLGXhRW2.hIRcayGSVFVtXIyAOejzVjenKtdeA = eQtgicwpjfLXAzBbriSiRbLGXhRW2.ZQlpPrmExzYnpFDPHTzgvYcZLSQV.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps[i];
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 = uMOQSonVyolMBWPTOlCtBkaJfATv.ycNDoowLUPNTBtwIsGdftWwWXDR.Find(eQtgicwpjfLXAzBbriSiRbLGXhRW2.GmsizZBBWcvhnNBFijwYJaevUnlI);
						eQtgicwpjfLXAzBbriSiRbLGXhRW2.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
						eQtgicwpjfLXAzBbriSiRbLGXhRW2.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionCategoryId = ((uMOQSonVyolMBWPTOlCtBkaJfATv.jJFJfGtcIkdwFLyodCskdwTNtZOB.GetActionById(eQtgicwpjfLXAzBbriSiRbLGXhRW2.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId) != null) ? uMOQSonVyolMBWPTOlCtBkaJfATv.jJFJfGtcIkdwFLyodCskdwTNtZOB.GetActionById(eQtgicwpjfLXAzBbriSiRbLGXhRW2.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (lgmwpztCDWCULaNgtlsuwDvoaaEg.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						controllerMap_Editor = lgmwpztCDWCULaNgtlsuwDvoaaEg.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.ibommJCMFedOpYVnnVuUyWqCysNI;
						eUtdQbbknnlfUrtdsIrTxEIYWCinA(controllerMap_Editor.actionElementMaps, lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb = controllerMap_Editor2;
					}
					else
					{
						uMOQSonVyolMBWPTOlCtBkaJfATv.jJFJfGtcIkdwFLyodCskdwTNtZOB.CreateKeyboardMap(lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId, lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId);
						controllerMap_Editor = lgmwpztCDWCULaNgtlsuwDvoaaEg.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[lgmwpztCDWCULaNgtlsuwDvoaaEg.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb.id = controllerMap_Editor.id;
					int index = lgmwpztCDWCULaNgtlsuwDvoaaEg.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(controllerMap_Editor);
					lgmwpztCDWCULaNgtlsuwDvoaaEg.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb;
					return lgmwpztCDWCULaNgtlsuwDvoaaEg.iGuDrRtOeabaCVzOkSzpIOGsUjhb;
				}
			}

			private sealed class iSkLrWOCFXVATWUNlXbBNWIDzNdH
			{
				public ControllerMap_Editor VwpBgMvWwAXYQzeWHeKuTetHBYkFA;

				public Predicate<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> sEDhrDCGvnFfjPGCrxUbHjjZdbBO;

				public Predicate<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> qeYgsTiwrXytdlgFBpObgRrjGMNSB;

				internal bool LztrUQEAzbysSrKFADUYdLfYbUIeb(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.KcHFLnCVOTzHfVZZpukUwUwsOxTwA == VwpBgMvWwAXYQzeWHeKuTetHBYkFA.categoryId;
				}

				internal bool eUDtJmaBRWaZuRrSDkBZJuwlBqpI(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.KcHFLnCVOTzHfVZZpukUwUwsOxTwA == VwpBgMvWwAXYQzeWHeKuTetHBYkFA.layoutId;
				}
			}

			private sealed class LgmwpztCDWCULaNgtlsuwDvoaaEg
			{
				public gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMap_Editor> bKpDPEBSUWmZyeIhbHaLlYeEnhUcc;

				public ControllerMap_Editor iGuDrRtOeabaCVzOkSzpIOGsUjhb;

				internal bool cMXgMMxgOEPusoiZdnZPInnZcbdF(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId;
				}

				internal bool YdsrkOLvliGlDFZwmvaufYLcSHeb(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId;
				}
			}

			private sealed class JCEwkZeQTDJaJkXYMbcgVVJCMcmI
			{
				public List<int> MUgMzeLVIOAIrXVaNtrKiIHoEwbEA;

				public lYbESakveqfQSFPBhMVsTOTLLfVbA AloPijsBZmbeLdpbsHGuXsudtcMG;

				internal InputMapCategory xCmwjyblGxNRPHdVNPNVTvhFYpCf(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					InputMapCategory inputMapCategory2;
					if (P_0.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						inputMapCategory2 = P_0.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
					}
					else
					{
						AloPijsBZmbeLdpbsHGuXsudtcMG.jJFJfGtcIkdwFLyodCskdwTNtZOB.AddMapCategory();
						inputMapCategory2 = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					int num = P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(inputMapCategory2);
					if (P_0.aNVDzOSlSERVZPtqDlrcwarJBwwo == yyAxRDZNDsMbpQvGxZHwJtmcRMfJ.YChXseGFUVZKknkYzbuIofGRIXZGA.otherId)
					{
						MUgMzeLVIOAIrXVaNtrKiIHoEwbEA.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.LuIZRJvCFAsNCmXoUkqHLxUygUEb[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class eQtgicwpjfLXAzBbriSiRbLGXhRW
			{
				public ActionElementMap hIRcayGSVFVtXIyAOejzVjenKtdeA;

				public LgmwpztCDWCULaNgtlsuwDvoaaEg ZQlpPrmExzYnpFDPHTzgvYcZLSQV;

				internal bool GmsizZBBWcvhnNBFijwYJaevUnlI(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(ZQlpPrmExzYnpFDPHTzgvYcZLSQV.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId;
				}
			}

			private sealed class mPSEHKXGPYhSaPhIBNJnBXFuAZlm
			{
				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> VwIbCEZiYAlZWrKoJLDrHLSRnHcl;

				public lYbESakveqfQSFPBhMVsTOTLLfVbA JWUzrtUJJBsURObAhGKnRflGaOKT;

				internal int aQounLYxpstADahsCzEaBhZkaFDbA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					lUOiioeGyqSFeVLgjJMfQRXicZvAA lUOiioeGyqSFeVLgjJMfQRXicZvAA2 = new lUOiioeGyqSFeVLgjJMfQRXicZvAA();
					lUOiioeGyqSFeVLgjJMfQRXicZvAA2.VwpBgMvWwAXYQzeWHeKuTetHBYkFA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = JWUzrtUJJBsURObAhGKnRflGaOKT.NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(lUOiioeGyqSFeVLgjJMfQRXicZvAA2.MtlbWQrhEYFDmIKsREbbxywSamac);
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = VwIbCEZiYAlZWrKoJLDrHLSRnHcl.Find(lUOiioeGyqSFeVLgjJMfQRXicZvAA2.mgCXfEFyNJnQZpYKLuZBQOOLSgjJ);
						if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 != null && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2.tZUQhjEdVfXpubmmojIITceXnFwl == P_1[i].categoryId && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 != null && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3.tZUQhjEdVfXpubmmojIITceXnFwl == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor qFhsEqTdYqUtcWLctOyTLYpPHECJ(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMap_Editor> P_0)
				{
					ZHrYixYpdzeZAHcbcBPpHEQdlBLTA zHrYixYpdzeZAHcbcBPpHEQdlBLTA = new ZHrYixYpdzeZAHcbcBPpHEQdlBLTA();
					zHrYixYpdzeZAHcbcBPpHEQdlBLTA.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc = P_0;
					zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb = JsonTools.Clone(zHrYixYpdzeZAHcbcBPpHEQdlBLTA.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = JWUzrtUJJBsURObAhGKnRflGaOKT.NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(zHrYixYpdzeZAHcbcBPpHEQdlBLTA.MBCUlxBmuKdOcIeXWcfCTRpAGQrz);
					yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = VwIbCEZiYAlZWrKoJLDrHLSRnHcl.Find(zHrYixYpdzeZAHcbcBPpHEQdlBLTA.IaxFRaCHddMzrANZHCDUmhQywVrV);
					zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					for (int i = 0; i < zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps.Count; i++)
					{
						VgnwitEvwnvafVatYKBHxLUVqBZd vgnwitEvwnvafVatYKBHxLUVqBZd = new VgnwitEvwnvafVatYKBHxLUVqBZd();
						vgnwitEvwnvafVatYKBHxLUVqBZd.xaNERWJPwuEgkllezsNKnGrmXHOT = zHrYixYpdzeZAHcbcBPpHEQdlBLTA;
						vgnwitEvwnvafVatYKBHxLUVqBZd.hIRcayGSVFVtXIyAOejzVjenKtdeA = vgnwitEvwnvafVatYKBHxLUVqBZd.xaNERWJPwuEgkllezsNKnGrmXHOT.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps[i];
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 = JWUzrtUJJBsURObAhGKnRflGaOKT.ycNDoowLUPNTBtwIsGdftWwWXDR.Find(vgnwitEvwnvafVatYKBHxLUVqBZd.RYXSAbcFkayNidwCIPPnDRDZKtG);
						vgnwitEvwnvafVatYKBHxLUVqBZd.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
						vgnwitEvwnvafVatYKBHxLUVqBZd.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionCategoryId = ((JWUzrtUJJBsURObAhGKnRflGaOKT.jJFJfGtcIkdwFLyodCskdwTNtZOB.GetActionById(vgnwitEvwnvafVatYKBHxLUVqBZd.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId) != null) ? JWUzrtUJJBsURObAhGKnRflGaOKT.jJFJfGtcIkdwFLyodCskdwTNtZOB.GetActionById(vgnwitEvwnvafVatYKBHxLUVqBZd.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (zHrYixYpdzeZAHcbcBPpHEQdlBLTA.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						controllerMap_Editor = zHrYixYpdzeZAHcbcBPpHEQdlBLTA.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.HUIyWowuRijfMOceaCesPToUCbeg;
						eUtdQbbknnlfUrtdsIrTxEIYWCinA(controllerMap_Editor.actionElementMaps, zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb = controllerMap_Editor2;
					}
					else
					{
						JWUzrtUJJBsURObAhGKnRflGaOKT.jJFJfGtcIkdwFLyodCskdwTNtZOB.CreateMouseMap(zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId, zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId);
						controllerMap_Editor = zHrYixYpdzeZAHcbcBPpHEQdlBLTA.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[zHrYixYpdzeZAHcbcBPpHEQdlBLTA.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb.id = controllerMap_Editor.id;
					int index = zHrYixYpdzeZAHcbcBPpHEQdlBLTA.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(controllerMap_Editor);
					zHrYixYpdzeZAHcbcBPpHEQdlBLTA.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb;
					return zHrYixYpdzeZAHcbcBPpHEQdlBLTA.iGuDrRtOeabaCVzOkSzpIOGsUjhb;
				}
			}

			private sealed class lUOiioeGyqSFeVLgjJMfQRXicZvAA
			{
				public ControllerMap_Editor VwpBgMvWwAXYQzeWHeKuTetHBYkFA;

				public Predicate<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> bilHyiNbMOIHqAqTUAOqJYlvAmbB;

				public Predicate<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> RPMNOpGmEyKdmYqKlIjMTCHoVJCC;

				internal bool MtlbWQrhEYFDmIKsREbbxywSamac(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.KcHFLnCVOTzHfVZZpukUwUwsOxTwA == VwpBgMvWwAXYQzeWHeKuTetHBYkFA.categoryId;
				}

				internal bool mgCXfEFyNJnQZpYKLuZBQOOLSgjJ(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.KcHFLnCVOTzHfVZZpukUwUwsOxTwA == VwpBgMvWwAXYQzeWHeKuTetHBYkFA.layoutId;
				}
			}

			private sealed class ZHrYixYpdzeZAHcbcBPpHEQdlBLTA
			{
				public gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMap_Editor> bKpDPEBSUWmZyeIhbHaLlYeEnhUcc;

				public ControllerMap_Editor iGuDrRtOeabaCVzOkSzpIOGsUjhb;

				internal bool MBCUlxBmuKdOcIeXWcfCTRpAGQrz(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId;
				}

				internal bool IaxFRaCHddMzrANZHCDUmhQywVrV(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId;
				}
			}

			private sealed class VgnwitEvwnvafVatYKBHxLUVqBZd
			{
				public ActionElementMap hIRcayGSVFVtXIyAOejzVjenKtdeA;

				public ZHrYixYpdzeZAHcbcBPpHEQdlBLTA xaNERWJPwuEgkllezsNKnGrmXHOT;

				internal bool RYXSAbcFkayNidwCIPPnDRDZKtG(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(xaNERWJPwuEgkllezsNKnGrmXHOT.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId;
				}
			}

			private sealed class DHpuhbaiCktViLslprcwOKgWJTwk
			{
				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> VwIbCEZiYAlZWrKoJLDrHLSRnHcl;

				public lYbESakveqfQSFPBhMVsTOTLLfVbA qmPduZKCLvXuLKcDbtifVvUCZhXe;

				internal int MnyOEOmJjVkNdtiadOJUTJoJuYDU(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					AZwESfoxQYPIDfEidlcoSdDBhboN aZwESfoxQYPIDfEidlcoSdDBhboN = new AZwESfoxQYPIDfEidlcoSdDBhboN();
					aZwESfoxQYPIDfEidlcoSdDBhboN.VwpBgMvWwAXYQzeWHeKuTetHBYkFA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = qmPduZKCLvXuLKcDbtifVvUCZhXe.NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(aZwESfoxQYPIDfEidlcoSdDBhboN.dXNVUmdYmzenGUKnsKQXciASDSyCA);
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = VwIbCEZiYAlZWrKoJLDrHLSRnHcl.Find(aZwESfoxQYPIDfEidlcoSdDBhboN.HXlTCAJOJHAoKEqQqMANCvLaeYV);
						if (aZwESfoxQYPIDfEidlcoSdDBhboN.VwpBgMvWwAXYQzeWHeKuTetHBYkFA.hardwareGuid == P_1[i].hardwareGuid && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 != null && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2.tZUQhjEdVfXpubmmojIITceXnFwl == P_1[i].categoryId && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 != null && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3.tZUQhjEdVfXpubmmojIITceXnFwl == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor uUwAsmSsEQCWmibrwuBMDZXknhLrA(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMap_Editor> P_0)
				{
					SZltDeNqwCSQlWlKfmzTzkmXmjoG sZltDeNqwCSQlWlKfmzTzkmXmjoG = new SZltDeNqwCSQlWlKfmzTzkmXmjoG();
					sZltDeNqwCSQlWlKfmzTzkmXmjoG.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc = P_0;
					sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb = JsonTools.Clone(sZltDeNqwCSQlWlKfmzTzkmXmjoG.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = qmPduZKCLvXuLKcDbtifVvUCZhXe.NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(sZltDeNqwCSQlWlKfmzTzkmXmjoG.TmwEgvRSIZKfwwgJwHnRFAiRAUwK);
					yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = VwIbCEZiYAlZWrKoJLDrHLSRnHcl.Find(sZltDeNqwCSQlWlKfmzTzkmXmjoG.UngFKLjAYCflUERVEPXvZMxyUonpA);
					sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					for (int i = 0; i < sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps.Count; i++)
					{
						SQwoJEqbuAqiSmarBycnEmeagyOm sQwoJEqbuAqiSmarBycnEmeagyOm = new SQwoJEqbuAqiSmarBycnEmeagyOm();
						sQwoJEqbuAqiSmarBycnEmeagyOm.OGTZJkFmxGCFPGcXqJdfHAcZGmfnA = sZltDeNqwCSQlWlKfmzTzkmXmjoG;
						sQwoJEqbuAqiSmarBycnEmeagyOm.hIRcayGSVFVtXIyAOejzVjenKtdeA = sQwoJEqbuAqiSmarBycnEmeagyOm.OGTZJkFmxGCFPGcXqJdfHAcZGmfnA.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps[i];
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 = qmPduZKCLvXuLKcDbtifVvUCZhXe.ycNDoowLUPNTBtwIsGdftWwWXDR.Find(sQwoJEqbuAqiSmarBycnEmeagyOm.oIVWIIjyDJhBTjYSNquOUPrDVjlv);
						sQwoJEqbuAqiSmarBycnEmeagyOm.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
						sQwoJEqbuAqiSmarBycnEmeagyOm.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionCategoryId = ((qmPduZKCLvXuLKcDbtifVvUCZhXe.jJFJfGtcIkdwFLyodCskdwTNtZOB.GetActionById(sQwoJEqbuAqiSmarBycnEmeagyOm.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId) != null) ? qmPduZKCLvXuLKcDbtifVvUCZhXe.jJFJfGtcIkdwFLyodCskdwTNtZOB.GetActionById(sQwoJEqbuAqiSmarBycnEmeagyOm.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (sZltDeNqwCSQlWlKfmzTzkmXmjoG.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						controllerMap_Editor = sZltDeNqwCSQlWlKfmzTzkmXmjoG.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.kgcsgKchgzdNkkkwkVfNUiQvzCoDA;
						eUtdQbbknnlfUrtdsIrTxEIYWCinA(controllerMap_Editor.actionElementMaps, sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb = controllerMap_Editor2;
					}
					else
					{
						qmPduZKCLvXuLKcDbtifVvUCZhXe.jJFJfGtcIkdwFLyodCskdwTNtZOB.CreateJoystickMap(sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId, sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb.hardwareGuid, sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId);
						controllerMap_Editor = sZltDeNqwCSQlWlKfmzTzkmXmjoG.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[sZltDeNqwCSQlWlKfmzTzkmXmjoG.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb.id = controllerMap_Editor.id;
					int index = sZltDeNqwCSQlWlKfmzTzkmXmjoG.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(controllerMap_Editor);
					sZltDeNqwCSQlWlKfmzTzkmXmjoG.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb;
					return sZltDeNqwCSQlWlKfmzTzkmXmjoG.iGuDrRtOeabaCVzOkSzpIOGsUjhb;
				}
			}

			private sealed class AZwESfoxQYPIDfEidlcoSdDBhboN
			{
				public ControllerMap_Editor VwpBgMvWwAXYQzeWHeKuTetHBYkFA;

				public Predicate<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> tYdtvmNyRSLRSLvOJSkMstLubTFu;

				public Predicate<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> GhrbELHeNNErTcyDdHiuFxILXVhW;

				internal bool dXNVUmdYmzenGUKnsKQXciASDSyCA(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.KcHFLnCVOTzHfVZZpukUwUwsOxTwA == VwpBgMvWwAXYQzeWHeKuTetHBYkFA.categoryId;
				}

				internal bool HXlTCAJOJHAoKEqQqMANCvLaeYV(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.KcHFLnCVOTzHfVZZpukUwUwsOxTwA == VwpBgMvWwAXYQzeWHeKuTetHBYkFA.layoutId;
				}
			}

			private sealed class SZltDeNqwCSQlWlKfmzTzkmXmjoG
			{
				public gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMap_Editor> bKpDPEBSUWmZyeIhbHaLlYeEnhUcc;

				public ControllerMap_Editor iGuDrRtOeabaCVzOkSzpIOGsUjhb;

				internal bool TmwEgvRSIZKfwwgJwHnRFAiRAUwK(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId;
				}

				internal bool UngFKLjAYCflUERVEPXvZMxyUonpA(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId;
				}
			}

			private sealed class SQwoJEqbuAqiSmarBycnEmeagyOm
			{
				public ActionElementMap hIRcayGSVFVtXIyAOejzVjenKtdeA;

				public SZltDeNqwCSQlWlKfmzTzkmXmjoG OGTZJkFmxGCFPGcXqJdfHAcZGmfnA;

				internal bool oIVWIIjyDJhBTjYSNquOUPrDVjlv(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(OGTZJkFmxGCFPGcXqJdfHAcZGmfnA.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId;
				}
			}

			private sealed class QjRJiAhrQLsqfsiPuvFwYLuqvPQX
			{
				public List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> VwIbCEZiYAlZWrKoJLDrHLSRnHcl;

				public lYbESakveqfQSFPBhMVsTOTLLfVbA ygTZDaiqaoUJSEmYBIDshrRVqnJT;

				internal int PWDxcvcqnShDvLpzMIYUqSHkRJrV(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					ufBidnGrLDPQEBsiAKksUjwOQgQhc ufBidnGrLDPQEBsiAKksUjwOQgQhc2 = new ufBidnGrLDPQEBsiAKksUjwOQgQhc();
					ufBidnGrLDPQEBsiAKksUjwOQgQhc2.VwpBgMvWwAXYQzeWHeKuTetHBYkFA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = ygTZDaiqaoUJSEmYBIDshrRVqnJT.uaWjHqTKaECJugDYVdnWRnecAAspA.Find(ufBidnGrLDPQEBsiAKksUjwOQgQhc2.QXWKMmJhqiFsnffPcwZdDeTUQLBGA);
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = ygTZDaiqaoUJSEmYBIDshrRVqnJT.NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(ufBidnGrLDPQEBsiAKksUjwOQgQhc2.YcTmsSeLNklqGXfYdNvVHHXYtYwh);
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 = VwIbCEZiYAlZWrKoJLDrHLSRnHcl.Find(ufBidnGrLDPQEBsiAKksUjwOQgQhc2.ztVAmRuAszBcjsjKJCrbBMedUFIaA);
						if (yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 != null && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2.tZUQhjEdVfXpubmmojIITceXnFwl == P_1[i].customControllerUid && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 != null && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3.tZUQhjEdVfXpubmmojIITceXnFwl == P_1[i].categoryId && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 != null && yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4.tZUQhjEdVfXpubmmojIITceXnFwl == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor gxWAQiBHiuMzUlPkKzlywUqmQIyj(gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMap_Editor> P_0)
				{
					VTDAspitZlZfEgkUqblUDrehJmCLB vTDAspitZlZfEgkUqblUDrehJmCLB = new VTDAspitZlZfEgkUqblUDrehJmCLB();
					vTDAspitZlZfEgkUqblUDrehJmCLB.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc = P_0;
					vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb = JsonTools.Clone(vTDAspitZlZfEgkUqblUDrehJmCLB.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.qVIhdeCzBaNPQTeesZwdZeelnoFX);
					yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = ygTZDaiqaoUJSEmYBIDshrRVqnJT.uaWjHqTKaECJugDYVdnWRnecAAspA.Find(vTDAspitZlZfEgkUqblUDrehJmCLB.qAkvfiNchKHPMkjHapAdLafuAtZkA);
					yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3 = ygTZDaiqaoUJSEmYBIDshrRVqnJT.NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(vTDAspitZlZfEgkUqblUDrehJmCLB.UNJyZinPPXsaPcWMXuVkyTvYLNcn);
					yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4 = VwIbCEZiYAlZWrKoJLDrHLSRnHcl.Find(vTDAspitZlZfEgkUqblUDrehJmCLB.kaqmGQPkjQeyDRCtIuioliYaGdpFA);
					vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb.customControllerUid = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ3?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ4?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					for (int i = 0; i < vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps.Count; i++)
					{
						UpuRWLBgzpRhNWjZCYgXynZigzlk upuRWLBgzpRhNWjZCYgXynZigzlk = new UpuRWLBgzpRhNWjZCYgXynZigzlk();
						upuRWLBgzpRhNWjZCYgXynZigzlk.SomlilbGWicqnCVJvwgfUWRpLwtU = vTDAspitZlZfEgkUqblUDrehJmCLB;
						upuRWLBgzpRhNWjZCYgXynZigzlk.hIRcayGSVFVtXIyAOejzVjenKtdeA = upuRWLBgzpRhNWjZCYgXynZigzlk.SomlilbGWicqnCVJvwgfUWRpLwtU.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps[i];
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ5 = ygTZDaiqaoUJSEmYBIDshrRVqnJT.ycNDoowLUPNTBtwIsGdftWwWXDR.Find(upuRWLBgzpRhNWjZCYgXynZigzlk.WXHEFtjRRgKpOVSkXoVVkHRngXLz);
						upuRWLBgzpRhNWjZCYgXynZigzlk.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ5?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
						upuRWLBgzpRhNWjZCYgXynZigzlk.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionCategoryId = ((ygTZDaiqaoUJSEmYBIDshrRVqnJT.jJFJfGtcIkdwFLyodCskdwTNtZOB.GetActionById(upuRWLBgzpRhNWjZCYgXynZigzlk.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId) != null) ? ygTZDaiqaoUJSEmYBIDshrRVqnJT.jJFJfGtcIkdwFLyodCskdwTNtZOB.GetActionById(upuRWLBgzpRhNWjZCYgXynZigzlk.hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (vTDAspitZlZfEgkUqblUDrehJmCLB.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.EzjQDYoKAsnaPCJwFoITRwVRQAPy)
					{
						controllerMap_Editor = vTDAspitZlZfEgkUqblUDrehJmCLB.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.nOFhTuQEBAVAzPVeoRwZEwBhwPjO;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.VBJSZMFHXbsruHqxkGSdpjHYZpCQ;
						eUtdQbbknnlfUrtdsIrTxEIYWCinA(controllerMap_Editor.actionElementMaps, vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb = controllerMap_Editor2;
					}
					else
					{
						ygTZDaiqaoUJSEmYBIDshrRVqnJT.jJFJfGtcIkdwFLyodCskdwTNtZOB.CreateCustomControllerMap(vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId, vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb.customControllerUid, vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId);
						controllerMap_Editor = vTDAspitZlZfEgkUqblUDrehJmCLB.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[vTDAspitZlZfEgkUqblUDrehJmCLB.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.Count - 1];
					}
					vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb.id = controllerMap_Editor.id;
					int index = vTDAspitZlZfEgkUqblUDrehJmCLB.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb.IndexOf(controllerMap_Editor);
					vTDAspitZlZfEgkUqblUDrehJmCLB.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.LuIZRJvCFAsNCmXoUkqHLxUygUEb[index] = vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb;
					return vTDAspitZlZfEgkUqblUDrehJmCLB.iGuDrRtOeabaCVzOkSzpIOGsUjhb;
				}
			}

			private sealed class gkedyFlHHWdziWAzcjAGBITmVlfK
			{
				public int KcHFLnCVOTzHfVZZpukUwUwsOxTwA;

				internal bool SuWhxElmRdHuqKEojeDFbLRVkqYJ(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.KcHFLnCVOTzHfVZZpukUwUwsOxTwA == KcHFLnCVOTzHfVZZpukUwUwsOxTwA;
				}
			}

			private sealed class ufBidnGrLDPQEBsiAKksUjwOQgQhc
			{
				public ControllerMap_Editor VwpBgMvWwAXYQzeWHeKuTetHBYkFA;

				public Predicate<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> rKNoggeSZTlOIRkpiqzGHaIhJGhB;

				public Predicate<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> VxkzfSzavcfTlHesrOvfZSSKfWrDA;

				public Predicate<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> LwTywrJaiwHWNAmXDZgdmYZtjykC;

				internal bool QXWKMmJhqiFsnffPcwZdDeTUQLBGA(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.KcHFLnCVOTzHfVZZpukUwUwsOxTwA == VwpBgMvWwAXYQzeWHeKuTetHBYkFA.customControllerUid;
				}

				internal bool YcTmsSeLNklqGXfYdNvVHHXYtYwh(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.KcHFLnCVOTzHfVZZpukUwUwsOxTwA == VwpBgMvWwAXYQzeWHeKuTetHBYkFA.categoryId;
				}

				internal bool ztVAmRuAszBcjsjKJCrbBMedUFIaA(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.KcHFLnCVOTzHfVZZpukUwUwsOxTwA == VwpBgMvWwAXYQzeWHeKuTetHBYkFA.layoutId;
				}
			}

			private sealed class VTDAspitZlZfEgkUqblUDrehJmCLB
			{
				public gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMap_Editor> bKpDPEBSUWmZyeIhbHaLlYeEnhUcc;

				public ControllerMap_Editor iGuDrRtOeabaCVzOkSzpIOGsUjhb;

				internal bool qAkvfiNchKHPMkjHapAdLafuAtZkA(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == iGuDrRtOeabaCVzOkSzpIOGsUjhb.customControllerUid;
				}

				internal bool UNJyZinPPXsaPcWMXuVkyTvYLNcn(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == iGuDrRtOeabaCVzOkSzpIOGsUjhb.categoryId;
				}

				internal bool kaqmGQPkjQeyDRCtIuioliYaGdpFA(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == iGuDrRtOeabaCVzOkSzpIOGsUjhb.layoutId;
				}
			}

			private sealed class UpuRWLBgzpRhNWjZCYgXynZigzlk
			{
				public ActionElementMap hIRcayGSVFVtXIyAOejzVjenKtdeA;

				public VTDAspitZlZfEgkUqblUDrehJmCLB SomlilbGWicqnCVJvwgfUWRpLwtU;

				internal bool WXHEFtjRRgKpOVSkXoVVkHRngXLz(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(SomlilbGWicqnCVJvwgfUWRpLwtU.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == hIRcayGSVFVtXIyAOejzVjenKtdeA._actionId;
				}
			}

			private sealed class iGqxXQiLVfnvGYUmzjCSqIwSxCCu
			{
				public gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMapLayoutManager_RuleSet_Editor> bKpDPEBSUWmZyeIhbHaLlYeEnhUcc;
			}

			private sealed class LRFCNZuAfDzJhiviwOEwYKDPdHvdA
			{
				public int BUVIlhzUfJRniawFBWmKIevGUydb;

				public iGqxXQiLVfnvGYUmzjCSqIwSxCCu TNokMlcLtgKxmGbLYMePjMMQdVaO;

				internal bool erBdbNRunBMPCoTrJSFQnQHJRZvp(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(TNokMlcLtgKxmGbLYMePjMMQdVaO.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == BUVIlhzUfJRniawFBWmKIevGUydb;
				}
			}

			private sealed class jYLKwjZPpkUdfAQadPmVMpGyFzkZ
			{
				public int BUVIlhzUfJRniawFBWmKIevGUydb;

				public iGqxXQiLVfnvGYUmzjCSqIwSxCCu ZYUxwUiFLIBBzCbNkwLtiBOMDDnh;

				internal bool nzywXKxNVtuMzMtdLhlpsqzRbUcEA(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(ZYUxwUiFLIBBzCbNkwLtiBOMDDnh.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == BUVIlhzUfJRniawFBWmKIevGUydb;
				}
			}

			private sealed class oNQdfvXeUOcxkVKHIBztEgLbyLac
			{
				public int BUVIlhzUfJRniawFBWmKIevGUydb;

				public iGqxXQiLVfnvGYUmzjCSqIwSxCCu gLvcQMNbydpYpCgxjrFTlUpXOhvk;

				internal bool SeNgHTAQljbUcxMcULofDIFHKWdIA(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(gLvcQMNbydpYpCgxjrFTlUpXOhvk.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == BUVIlhzUfJRniawFBWmKIevGUydb;
				}
			}

			private sealed class raOJvMukogMNzgKnEEitijNrsoji
			{
				public gaNgZAlYQXyWCKaSgYHXpdgoCJNe<ControllerMapEnabler_RuleSet_Editor> bKpDPEBSUWmZyeIhbHaLlYeEnhUcc;
			}

			private sealed class BGBGmsdVLApoEbtSeHAneaCiJhiW
			{
				public int BUVIlhzUfJRniawFBWmKIevGUydb;

				public raOJvMukogMNzgKnEEitijNrsoji qqzqNXtqlghbBLhtHmCncNLWBXxz;

				internal bool slZMMUFHenfqVBalxNiSoBHZFGGs(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.HfqDDVXoZhEzIzsBwhZEJFHJIWnj(qqzqNXtqlghbBLhtHmCncNLWBXxz.bKpDPEBSUWmZyeIhbHaLlYeEnhUcc.aNVDzOSlSERVZPtqDlrcwarJBwwo) == BUVIlhzUfJRniawFBWmKIevGUydb;
				}
			}

			private sealed class OaGhAmitqdVxndQpTzeuaaBfwOynA<_0001> where _0001 : class
			{
				public Func<_0001, int> PpoGzBDgDeinDFkiuUUAQBzjfCxO;
			}

			private sealed class uJkKcjBQsfexqpKFyLDGpLVibuoX<_0001> where _0001 : class
			{
				public _0001 iGuDrRtOeabaCVzOkSzpIOGsUjhb;

				public OaGhAmitqdVxndQpTzeuaaBfwOynA<_0001> AloPijsBZmbeLdpbsHGuXsudtcMG;

				internal bool zSaFBUcFfBaumaTkWdotHedfdRJMB(yyAxRDZNDsMbpQvGxZHwJtmcRMfJ P_0)
				{
					return P_0.tZUQhjEdVfXpubmmojIITceXnFwl == AloPijsBZmbeLdpbsHGuXsudtcMG.PpoGzBDgDeinDFkiuUUAQBzjfCxO(iGuDrRtOeabaCVzOkSzpIOGsUjhb);
				}
			}

			public static UserData IdwGKNJkaXjzHIJrWUaMXhwlhIpX(UserData P_0, UserData P_1, bool P_2)
			{
				lYbESakveqfQSFPBhMVsTOTLLfVbA lYbESakveqfQSFPBhMVsTOTLLfVbA2 = new lYbESakveqfQSFPBhMVsTOTLLfVbA();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB = (P_2 ? P_0 : new UserData(false));
				if (P_1 != null)
				{
					lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.configVars = JsonTools.Clone(P_1.configVars);
				}
				else
				{
					lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.configVars = JsonTools.Clone(P_0.configVars);
				}
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.eyingmhBJLCLkIrxYTAmLcQNFqpm = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Action Category", P_0.actionCategories, P_1?.actionCategories, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.actionCategories, P_2, lYbESakveqfQSFPBhMVsTOTLLfVbA2.eyingmhBJLCLkIrxYTAmLcQNFqpm, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.MmJgvOTchqbaevGDzmaBXftadhsD, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.PBsrzfzBPrBWhqiUbzBOcxmoCVMy, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.sKXPeibZCshEibNJajqbixGTIvaIA, lYbESakveqfQSFPBhMVsTOTLLfVbA2.rvBMtSXArSdcYqPucIXfCGEZaZWFA);
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.qKDBBwsoOocyiAHmBNCRgIrshXBdA = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.inputBehaviors, P_2, lYbESakveqfQSFPBhMVsTOTLLfVbA2.qKDBBwsoOocyiAHmBNCRgIrshXBdA, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.WtzGutOjQvLliNzOdjFeAuEaBeOs, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.ylZpSguuUQfRQthJlRYehKDaSRAK, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.gITGwCaDWKcdyflpScxZCXYfaTujB, lYbESakveqfQSFPBhMVsTOTLLfVbA2.aklAvFSpgiMRXkNVbnguNxivjdXx);
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.ycNDoowLUPNTBtwIsGdftWwWXDR = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Action", P_0.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA, P_1?.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA, P_2, lYbESakveqfQSFPBhMVsTOTLLfVbA2.ycNDoowLUPNTBtwIsGdftWwWXDR, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.gKRYOdngLvDczKdKAILbioEoCUDDA, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.HcVxfGGwNOmYWngICCQkXkFOeVjn, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.eNUZnukpNmyCBTeSFjvULuQOWqGy, lYbESakveqfQSFPBhMVsTOTLLfVbA2.nirZGEoNNKWXHSijLVSCgAzmTusU);
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.NBeZbRqhdodYzhGqHhpLRBucjbeLA = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				JCEwkZeQTDJaJkXYMbcgVVJCMcmI jCEwkZeQTDJaJkXYMbcgVVJCMcmI = new JCEwkZeQTDJaJkXYMbcgVVJCMcmI();
				jCEwkZeQTDJaJkXYMbcgVVJCMcmI.AloPijsBZmbeLdpbsHGuXsudtcMG = lYbESakveqfQSFPBhMVsTOTLLfVbA2;
				jCEwkZeQTDJaJkXYMbcgVVJCMcmI.MUgMzeLVIOAIrXVaNtrKiIHoEwbEA = new List<int>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Map Category", P_0.mapCategories, P_1?.mapCategories, jCEwkZeQTDJaJkXYMbcgVVJCMcmI.AloPijsBZmbeLdpbsHGuXsudtcMG.jJFJfGtcIkdwFLyodCskdwTNtZOB.mapCategories, P_2, jCEwkZeQTDJaJkXYMbcgVVJCMcmI.AloPijsBZmbeLdpbsHGuXsudtcMG.NBeZbRqhdodYzhGqHhpLRBucjbeLA, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.rOOeSRglubclVjUuGiMeGodVdTvA, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.FDORdoaoMYcxPtaNDqHHEiwPRnBH, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.lqGHDcfWnmWprzBosdmyAPXAhejB, jCEwkZeQTDJaJkXYMbcgVVJCMcmI.xCmwjyblGxNRPHdVNPNVTvhFYpCf);
				for (int i = 0; i < jCEwkZeQTDJaJkXYMbcgVVJCMcmI.MUgMzeLVIOAIrXVaNtrKiIHoEwbEA.Count; i++)
				{
					int index = jCEwkZeQTDJaJkXYMbcgVVJCMcmI.MUgMzeLVIOAIrXVaNtrKiIHoEwbEA[i];
					InputMapCategory inputMapCategory = jCEwkZeQTDJaJkXYMbcgVVJCMcmI.AloPijsBZmbeLdpbsHGuXsudtcMG.jJFJfGtcIkdwFLyodCskdwTNtZOB.mapCategories[index];
					for (int j = 0; j < inputMapCategory.wCAilTYMKtKpdaHmwnpOyjsEQggr.Count; j++)
					{
						gkedyFlHHWdziWAzcjAGBITmVlfK gkedyFlHHWdziWAzcjAGBITmVlfK2 = new gkedyFlHHWdziWAzcjAGBITmVlfK();
						gkedyFlHHWdziWAzcjAGBITmVlfK2.KcHFLnCVOTzHfVZZpukUwUwsOxTwA = inputMapCategory.wCAilTYMKtKpdaHmwnpOyjsEQggr[j];
						yyAxRDZNDsMbpQvGxZHwJtmcRMfJ yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2 = jCEwkZeQTDJaJkXYMbcgVVJCMcmI.AloPijsBZmbeLdpbsHGuXsudtcMG.NBeZbRqhdodYzhGqHhpLRBucjbeLA.Find(gkedyFlHHWdziWAzcjAGBITmVlfK2.SuWhxElmRdHuqKEojeDFbLRVkqYJ);
						inputMapCategory.wCAilTYMKtKpdaHmwnpOyjsEQggr[j] = yyAxRDZNDsMbpQvGxZHwJtmcRMfJ2?.tZUQhjEdVfXpubmmojIITceXnFwl ?? (-1);
					}
				}
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.rMCKHVjOWJUdszJamHECUaKMiCwo = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.keyboardLayouts, P_2, lYbESakveqfQSFPBhMVsTOTLLfVbA2.rMCKHVjOWJUdszJamHECUaKMiCwo, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.TuyLjvnKzolwCzixmDTEwgoKrfwC, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.lqzgxgCNNSdvrCBoyulHcgSyrLPW, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.RRREldEDdYaLGKgCpfBHRTgaUlqnA, lYbESakveqfQSFPBhMVsTOTLLfVbA2.bkrngyekChJwkeClvmwTuZVqeSXM);
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.jTdQWfUWVBeleRisYbXwowkSOGWt = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.mouseLayouts, P_2, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jTdQWfUWVBeleRisYbXwowkSOGWt, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.evyWBntcMoXtuIAZhKcWMOmDqfJc, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.bIcrIYhAGUHHWJWPtttLJYWnpfyZ, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.ZuYoOmJIyyxSOSNCJNpOIcisiNRE, lYbESakveqfQSFPBhMVsTOTLLfVbA2.KrdZElXFaqxyUAAXYgCrouUZXafs);
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.PfWrhYlfqZZcqjmgxRMDtfvpkveL = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.joystickLayouts, P_2, lYbESakveqfQSFPBhMVsTOTLLfVbA2.PfWrhYlfqZZcqjmgxRMDtfvpkveL, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.nvYlmaHCfqdGqlbrqJfiGORCJuXv, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.JonQktwgMQhRuwgexdrCAvdkoOVmA, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.FhEEdvbBKECWJiJaZqKYyCznRiId, lYbESakveqfQSFPBhMVsTOTLLfVbA2.clfIyMFCeHGVKQgnuXUdBzUHZehC);
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.MBHRuBszjBARgqbfhJIRzftmntmf = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.customControllerLayouts, P_2, lYbESakveqfQSFPBhMVsTOTLLfVbA2.MBHRuBszjBARgqbfhJIRzftmntmf, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.QckAslQSoGoARdMwPvQGkZgzPGZg, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.rHSCTWIwxGRDgEvbsCFinZvhhnwjA, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.mrleqiVMSSArjWWitnezsFaUgqPEA, lYbESakveqfQSFPBhMVsTOTLLfVbA2.zoLPetZpOyaqeOvxYfjLTMOVxKql);
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.CXbfSxFlyJxZOohxRrJIhUsKJdgEA = lYbESakveqfQSFPBhMVsTOTLLfVbA2.VIXTJoDsCZBBDsSnIMUjGWPwpuTs;
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.uaWjHqTKaECJugDYVdnWRnecAAspA = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Custom Controller", P_0.customControllers, P_1?.customControllers, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.customControllers, P_2, lYbESakveqfQSFPBhMVsTOTLLfVbA2.uaWjHqTKaECJugDYVdnWRnecAAspA, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.yHFMHaSTUUUadsObECQEgDlIEwXE, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.dIGQewqOBgpQELHeufJLJJVmEmJK, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.USurCZrNGnvGLMkxVJDwEAusREtg, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jmiIIsGDkyalnjXCAJQaWrSUXnAuA);
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.dtyoYabKuKtDHPLsgYcXSThBTAar = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.controllerMapLayoutManagerRuleSets, P_2, lYbESakveqfQSFPBhMVsTOTLLfVbA2.dtyoYabKuKtDHPLsgYcXSThBTAar, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.LBpjgxagGVshjCVvqrbMrWguWKxH, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.NppFPCKzqogAiFmofYOWmrhTFIYP, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.SWLjiSFkcgtAkbOxqtPNivXfkpzi, lYbESakveqfQSFPBhMVsTOTLLfVbA2.ZaYQvECpRLsyswJoPQEXsiRjgayjA);
				lYbESakveqfQSFPBhMVsTOTLLfVbA2.iBUPAdvPsugieTgZaCpMHNVPqKipA = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.controllerMapEnablerRuleSets, P_2, lYbESakveqfQSFPBhMVsTOTLLfVbA2.iBUPAdvPsugieTgZaCpMHNVPqKipA, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.wPfOQGagQLQgpjELQphCYuukFshj, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.XdKHHGhiLdHQWHdzxVmhxesCFAgFA, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.sKClVGKmajDsJyWSMOFNSAxpZuJF, lYbESakveqfQSFPBhMVsTOTLLfVbA2.vtZnQpgAdqXHJDKxnZvtUWkQTKvX);
				List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> list = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Player", P_0.players, P_1?.players, lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB.players, P_2, list, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.brrjDAxZNdqwCafGkkxiMQODiDOo, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.mDnkmbuaaOsRhKRPKJImVcegLYGi, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.yqPkTvNUgMMNnVfXnPkKUJMYlQBM, lYbESakveqfQSFPBhMVsTOTLLfVbA2.VpfebDVGCxdnOzFLebyeueVHIOqc);
				List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> list2 = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				VYbgzMbEHbLrPnsPeZEDyYGdNQmK vYbgzMbEHbLrPnsPeZEDyYGdNQmK = new VYbgzMbEHbLrPnsPeZEDyYGdNQmK();
				vYbgzMbEHbLrPnsPeZEDyYGdNQmK.uMOQSonVyolMBWPTOlCtBkaJfATv = lYbESakveqfQSFPBhMVsTOTLLfVbA2;
				vYbgzMbEHbLrPnsPeZEDyYGdNQmK.VwIbCEZiYAlZWrKoJLDrHLSRnHcl = vYbgzMbEHbLrPnsPeZEDyYGdNQmK.uMOQSonVyolMBWPTOlCtBkaJfATv.rMCKHVjOWJUdszJamHECUaKMiCwo;
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, vYbgzMbEHbLrPnsPeZEDyYGdNQmK.uMOQSonVyolMBWPTOlCtBkaJfATv.jJFJfGtcIkdwFLyodCskdwTNtZOB.keyboardMaps, P_2, list2, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.BjMMwWqcVMRiWxcgiTDyZmssFEHS, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.oaXTfiMhdgkKUckeYFfgdWZjGyDy, vYbgzMbEHbLrPnsPeZEDyYGdNQmK.NyHTjVXppPCVrJJLcPDMbnUSxwuf, vYbgzMbEHbLrPnsPeZEDyYGdNQmK.XoLrVARmHmqNjhLnWHLkLhjFsgfn);
				List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> list3 = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				mPSEHKXGPYhSaPhIBNJnBXFuAZlm mPSEHKXGPYhSaPhIBNJnBXFuAZlm2 = new mPSEHKXGPYhSaPhIBNJnBXFuAZlm();
				mPSEHKXGPYhSaPhIBNJnBXFuAZlm2.JWUzrtUJJBsURObAhGKnRflGaOKT = lYbESakveqfQSFPBhMVsTOTLLfVbA2;
				mPSEHKXGPYhSaPhIBNJnBXFuAZlm2.VwIbCEZiYAlZWrKoJLDrHLSRnHcl = mPSEHKXGPYhSaPhIBNJnBXFuAZlm2.JWUzrtUJJBsURObAhGKnRflGaOKT.jTdQWfUWVBeleRisYbXwowkSOGWt;
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, mPSEHKXGPYhSaPhIBNJnBXFuAZlm2.JWUzrtUJJBsURObAhGKnRflGaOKT.jJFJfGtcIkdwFLyodCskdwTNtZOB.mouseMaps, P_2, list3, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.IyFbuLFCLhYersVmXopUghOwYZRx, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.NZMtVtyFOGEKkHEKJjusSOCPkkKb, mPSEHKXGPYhSaPhIBNJnBXFuAZlm2.aQounLYxpstADahsCzEaBhZkaFDbA, mPSEHKXGPYhSaPhIBNJnBXFuAZlm2.qFhsEqTdYqUtcWLctOyTLYpPHECJ);
				List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> list4 = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				DHpuhbaiCktViLslprcwOKgWJTwk dHpuhbaiCktViLslprcwOKgWJTwk = new DHpuhbaiCktViLslprcwOKgWJTwk();
				dHpuhbaiCktViLslprcwOKgWJTwk.qmPduZKCLvXuLKcDbtifVvUCZhXe = lYbESakveqfQSFPBhMVsTOTLLfVbA2;
				dHpuhbaiCktViLslprcwOKgWJTwk.VwIbCEZiYAlZWrKoJLDrHLSRnHcl = dHpuhbaiCktViLslprcwOKgWJTwk.qmPduZKCLvXuLKcDbtifVvUCZhXe.PfWrhYlfqZZcqjmgxRMDtfvpkveL;
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, dHpuhbaiCktViLslprcwOKgWJTwk.qmPduZKCLvXuLKcDbtifVvUCZhXe.jJFJfGtcIkdwFLyodCskdwTNtZOB.joystickMaps, P_2, list4, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.YUHhEnpVIcKTKjQOnbymjSankujC, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.QCvgPZZtMtManiFEDKcZUErOPlxy, dHpuhbaiCktViLslprcwOKgWJTwk.MnyOEOmJjVkNdtiadOJUTJoJuYDU, dHpuhbaiCktViLslprcwOKgWJTwk.uUwAsmSsEQCWmibrwuBMDZXknhLrA);
				List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> list5 = new List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ>();
				QjRJiAhrQLsqfsiPuvFwYLuqvPQX qjRJiAhrQLsqfsiPuvFwYLuqvPQX = new QjRJiAhrQLsqfsiPuvFwYLuqvPQX();
				qjRJiAhrQLsqfsiPuvFwYLuqvPQX.ygTZDaiqaoUJSEmYBIDshrRVqnJT = lYbESakveqfQSFPBhMVsTOTLLfVbA2;
				qjRJiAhrQLsqfsiPuvFwYLuqvPQX.VwIbCEZiYAlZWrKoJLDrHLSRnHcl = qjRJiAhrQLsqfsiPuvFwYLuqvPQX.ygTZDaiqaoUJSEmYBIDshrRVqnJT.MBHRuBszjBARgqbfhJIRzftmntmf;
				XRaXySrtSWIQdgSwsHuFWPqKGJXU("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, qjRJiAhrQLsqfsiPuvFwYLuqvPQX.ygTZDaiqaoUJSEmYBIDshrRVqnJT.jJFJfGtcIkdwFLyodCskdwTNtZOB.customControllerMaps, P_2, list5, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.LykixZCxiFfnWpDgPSzBFdPXkOKE, idpEEcAXjmWbOodRjUcatjPJOyGiA._003C_003E9.cqFJbICpiDiGjdjNRFuGnYFdiEwWA, qjRJiAhrQLsqfsiPuvFwYLuqvPQX.PWDxcvcqnShDvLpzMIYUqSHkRJrV, qjRJiAhrQLsqfsiPuvFwYLuqvPQX.gxWAQiBHiuMzUlPkKzlywUqmQIyj);
				return lYbESakveqfQSFPBhMVsTOTLLfVbA2.jJFJfGtcIkdwFLyodCskdwTNtZOB;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void LrWAduhnVAfLpNJCUjSmccUadFrC(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void eUtdQbbknnlfUrtdsIrTxEIYWCinA<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
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

			private static void XRaXySrtSWIQdgSwsHuFWPqKGJXU<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<yyAxRDZNDsMbpQvGxZHwJtmcRMfJ> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<gaNgZAlYQXyWCKaSgYHXpdgoCJNe<_0001>, _0001> P_9) where _0001 : class
			{
				OaGhAmitqdVxndQpTzeuaaBfwOynA<_0001> oaGhAmitqdVxndQpTzeuaaBfwOynA = new OaGhAmitqdVxndQpTzeuaaBfwOynA<_0001>();
				oaGhAmitqdVxndQpTzeuaaBfwOynA.PpoGzBDgDeinDFkiuUUAQBzjfCxO = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					_0001 val = P_1[i];
					if (P_4)
					{
						P_5.Add(new yyAxRDZNDsMbpQvGxZHwJtmcRMfJ(oaGhAmitqdVxndQpTzeuaaBfwOynA.PpoGzBDgDeinDFkiuUUAQBzjfCxO(val), -1, oaGhAmitqdVxndQpTzeuaaBfwOynA.PpoGzBDgDeinDFkiuUUAQBzjfCxO(val)));
						continue;
					}
					_0001 arg = P_9(new gaNgZAlYQXyWCKaSgYHXpdgoCJNe<_0001>(val, null, yyAxRDZNDsMbpQvGxZHwJtmcRMfJ.YChXseGFUVZKknkYzbuIofGRIXZGA.origId, P_3, false));
					P_5.Add(new yyAxRDZNDsMbpQvGxZHwJtmcRMfJ(oaGhAmitqdVxndQpTzeuaaBfwOynA.PpoGzBDgDeinDFkiuUUAQBzjfCxO(val), -1, oaGhAmitqdVxndQpTzeuaaBfwOynA.PpoGzBDgDeinDFkiuUUAQBzjfCxO(arg)));
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
						uJkKcjBQsfexqpKFyLDGpLVibuoX<_0001> uJkKcjBQsfexqpKFyLDGpLVibuoX2 = new uJkKcjBQsfexqpKFyLDGpLVibuoX<_0001>();
						uJkKcjBQsfexqpKFyLDGpLVibuoX2.AloPijsBZmbeLdpbsHGuXsudtcMG = oaGhAmitqdVxndQpTzeuaaBfwOynA;
						_0001 val3 = P_3[num];
						uJkKcjBQsfexqpKFyLDGpLVibuoX2.iGuDrRtOeabaCVzOkSzpIOGsUjhb = P_9(new gaNgZAlYQXyWCKaSgYHXpdgoCJNe<_0001>(val2, val3, yyAxRDZNDsMbpQvGxZHwJtmcRMfJ.YChXseGFUVZKknkYzbuIofGRIXZGA.otherId, P_3, true));
						P_5.Find(uJkKcjBQsfexqpKFyLDGpLVibuoX2.zSaFBUcFfBaumaTkWdotHedfdRJMB).KcHFLnCVOTzHfVZZpukUwUwsOxTwA = uJkKcjBQsfexqpKFyLDGpLVibuoX2.AloPijsBZmbeLdpbsHGuXsudtcMG.PpoGzBDgDeinDFkiuUUAQBzjfCxO(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						_0001 arg2 = P_9(new gaNgZAlYQXyWCKaSgYHXpdgoCJNe<_0001>(val2, null, yyAxRDZNDsMbpQvGxZHwJtmcRMfJ.YChXseGFUVZKknkYzbuIofGRIXZGA.otherId, P_3, false));
						P_5.Add(new yyAxRDZNDsMbpQvGxZHwJtmcRMfJ(-1, oaGhAmitqdVxndQpTzeuaaBfwOynA.PpoGzBDgDeinDFkiuUUAQBzjfCxO(val2), oaGhAmitqdVxndQpTzeuaaBfwOynA.PpoGzBDgDeinDFkiuUUAQBzjfCxO(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}
		}

		[Serializable]
		private sealed class FfuOSESqBYfwvFtkpLBUBftIfMuiA
		{
			public static readonly FfuOSESqBYfwvFtkpLBUBftIfMuiA _003C_003E9 = new FfuOSESqBYfwvFtkpLBUBftIfMuiA();

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__199_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__217_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__233_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__249_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__265_0;

			internal void anRdVxWtIjDxmoWKRdCYBYGpLnZiA(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void xohsVtUwDbBWfxAgkCsNGRhjOWhH(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void AphkGIWQUZLfmWKdsjSjSQHeUzBH(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void NeUdcYnmWwFFyRCQgnGGnmVGacUX(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void wcgHAbhQZylmxPmhGdunGEpHRizKc(List<Player_Editor.Mapping> P_0, int P_1)
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

		private sealed class wtfELDhWCecxWGMDJRSuvXQGyKTpB
		{
			public List<InputLayout> yCjqQXgJUcuSRtXNKEfkuzuncbMT;

			internal int RZZhgWtLAqzPjRyKpishqLOFrQVr(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				kWZeFyrLytGJbCSKaZgAMeKpPxGRA kWZeFyrLytGJbCSKaZgAMeKpPxGRA2 = new kWZeFyrLytGJbCSKaZgAMeKpPxGRA();
				kWZeFyrLytGJbCSKaZgAMeKpPxGRA2.cLwWUIFFJkYELAfQMrjOynpLvFSp = P_0;
				kWZeFyrLytGJbCSKaZgAMeKpPxGRA2.EYxlxKdKWUPYipWWxXVcknevqWWh = P_1;
				int num = yCjqQXgJUcuSRtXNKEfkuzuncbMT.FindIndex(kWZeFyrLytGJbCSKaZgAMeKpPxGRA2.xQoqBaZDWjKdozKsjAJlIvSfksTYA);
				int num2 = yCjqQXgJUcuSRtXNKEfkuzuncbMT.FindIndex(kWZeFyrLytGJbCSKaZgAMeKpPxGRA2.GZJoTalPzVZHEvjCwkMhvpvCPPIr);
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

		private sealed class kWZeFyrLytGJbCSKaZgAMeKpPxGRA
		{
			public ControllerMap_Editor cLwWUIFFJkYELAfQMrjOynpLvFSp;

			public ControllerMap_Editor EYxlxKdKWUPYipWWxXVcknevqWWh;

			internal bool xQoqBaZDWjKdozKsjAJlIvSfksTYA(InputLayout P_0)
			{
				return P_0.id == cLwWUIFFJkYELAfQMrjOynpLvFSp.id;
			}

			internal bool GZJoTalPzVZHEvjCwkMhvpvCPPIr(InputLayout P_0)
			{
				return P_0.id == EYxlxKdKWUPYipWWxXVcknevqWWh.id;
			}
		}

		private sealed class wUgjoADwxhLfDXPHrytwWYqXaGWf : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputCategory vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			private string GiYDMCcMONvVCiaWWsZIuJqycBAR;

			public string tvTXNTppqPDhYkrUlpahZVEoTeDc;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public wUgjoADwxhLfDXPHrytwWYqXaGWf(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_0098;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (GiYDMCcMONvVCiaWWsZIuJqycBAR == null || GiYDMCcMONvVCiaWWsZIuJqycBAR == string.Empty)
				{
					return false;
				}
				if (userData.actionCategories == null)
				{
					return false;
				}
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_00a8;
				IL_00a8:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < userData.actionCategories.Count)
				{
					if (userData.actionCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA].tag.Equals(GiYDMCcMONvVCiaWWsZIuJqycBAR, StringComparison.OrdinalIgnoreCase))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = userData.actionCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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
				wUgjoADwxhLfDXPHrytwWYqXaGWf wUgjoADwxhLfDXPHrytwWYqXaGWf2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					wUgjoADwxhLfDXPHrytwWYqXaGWf2 = this;
				}
				else
				{
					wUgjoADwxhLfDXPHrytwWYqXaGWf2 = new wUgjoADwxhLfDXPHrytwWYqXaGWf(0);
					wUgjoADwxhLfDXPHrytwWYqXaGWf2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				wUgjoADwxhLfDXPHrytwWYqXaGWf2.GiYDMCcMONvVCiaWWsZIuJqycBAR = tvTXNTppqPDhYkrUlpahZVEoTeDc;
				return wUgjoADwxhLfDXPHrytwWYqXaGWf2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class FCIqVhgwkmJhoKAnDtPpYrUktuRR : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputAction vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private string GiYDMCcMONvVCiaWWsZIuJqycBAR;

			public string tvTXNTppqPDhYkrUlpahZVEoTeDc;

			private int fPrWlUJCdFXcChXLXRIXBNsNmbik;

			private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

			private InputCategory webmIxEtbvlPHXmVeveiXBhAkhIX;

			private int tdwXqnewaJsEvqbhYEOsNMqnLdFN;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public FCIqVhgwkmJhoKAnDtPpYrUktuRR(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_00fd;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null || userData.actionCategories == null)
				{
					return false;
				}
				if (GiYDMCcMONvVCiaWWsZIuJqycBAR == null || GiYDMCcMONvVCiaWWsZIuJqycBAR == string.Empty)
				{
					return false;
				}
				fPrWlUJCdFXcChXLXRIXBNsNmbik = userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count;
				PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
				goto IL_0132;
				IL_0122:
				PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
				goto IL_0132;
				IL_00fd:
				tdwXqnewaJsEvqbhYEOsNMqnLdFN++;
				goto IL_010d;
				IL_010d:
				if (tdwXqnewaJsEvqbhYEOsNMqnLdFN < fPrWlUJCdFXcChXLXRIXBNsNmbik)
				{
					if (webmIxEtbvlPHXmVeveiXBhAkhIX.id == userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[tdwXqnewaJsEvqbhYEOsNMqnLdFN].categoryId)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[tdwXqnewaJsEvqbhYEOsNMqnLdFN];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_00fd;
				}
				webmIxEtbvlPHXmVeveiXBhAkhIX = null;
				goto IL_0122;
				IL_0132:
				if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < userData.actionCategories.Count)
				{
					if (userData.actionCategories[PrfhaiCANHhjwtWLxlpNIHvkLSmF].tag.Equals(GiYDMCcMONvVCiaWWsZIuJqycBAR, StringComparison.OrdinalIgnoreCase))
					{
						webmIxEtbvlPHXmVeveiXBhAkhIX = userData.actionCategories[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
						tdwXqnewaJsEvqbhYEOsNMqnLdFN = 0;
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
				FCIqVhgwkmJhoKAnDtPpYrUktuRR fCIqVhgwkmJhoKAnDtPpYrUktuRR;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					fCIqVhgwkmJhoKAnDtPpYrUktuRR = this;
				}
				else
				{
					fCIqVhgwkmJhoKAnDtPpYrUktuRR = new FCIqVhgwkmJhoKAnDtPpYrUktuRR(0);
					fCIqVhgwkmJhoKAnDtPpYrUktuRR.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				fCIqVhgwkmJhoKAnDtPpYrUktuRR.GiYDMCcMONvVCiaWWsZIuJqycBAR = tvTXNTppqPDhYkrUlpahZVEoTeDc;
				return fCIqVhgwkmJhoKAnDtPpYrUktuRR;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class fTrLiIGLlimUcUrSVumfTPEJYaEd : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputAction vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private bool jmGYGnfmhcoPwtsdgtPUkekhkDOu;

			public bool jFyDQdfhJBKebrdTfpYpfTImrPaVA;

			private int YicGLhjEfmBcRHjNhglgCZojwiWl;

			public int iHalSNRgFNFOFuRrjdNjqMefbVaZ;

			private IEnumerator<int> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

			private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public fTrLiIGLlimUcUrSVumfTPEJYaEd(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null || userData.actionCategories == null)
						{
							return false;
						}
						if (jmGYGnfmhcoPwtsdgtPUkekhkDOu)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = userData.SortedActionIdsInCategory(YicGLhjEfmBcRHjNhglgCZojwiWl).GetEnumerator();
							hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
							goto IL_00a5;
						}
						PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
						goto IL_0123;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_00a5;
					case 2:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_0111;
						}
						IL_0123:
						if (PrfhaiCANHhjwtWLxlpNIHvkLSmF >= userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count)
						{
							break;
						}
						if (userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].categoryId == YicGLhjEfmBcRHjNhglgCZojwiWl)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
							return true;
						}
						goto IL_0111;
						IL_0111:
						PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
						goto IL_0123;
						IL_00a5:
						while (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
						{
							int current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null)
							{
								vjnbYLtrPMftzpjohNfommerCnGo = actionById;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
						}
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

			private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
				{
					XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
				fTrLiIGLlimUcUrSVumfTPEJYaEd fTrLiIGLlimUcUrSVumfTPEJYaEd2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					fTrLiIGLlimUcUrSVumfTPEJYaEd2 = this;
				}
				else
				{
					fTrLiIGLlimUcUrSVumfTPEJYaEd2 = new fTrLiIGLlimUcUrSVumfTPEJYaEd(0);
					fTrLiIGLlimUcUrSVumfTPEJYaEd2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				fTrLiIGLlimUcUrSVumfTPEJYaEd2.YicGLhjEfmBcRHjNhglgCZojwiWl = iHalSNRgFNFOFuRrjdNjqMefbVaZ;
				fTrLiIGLlimUcUrSVumfTPEJYaEd2.jmGYGnfmhcoPwtsdgtPUkekhkDOu = jFyDQdfhJBKebrdTfpYpfTImrPaVA;
				return fTrLiIGLlimUcUrSVumfTPEJYaEd2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class EqLDPxELTsRYwaipUXoZpVdjExCeb : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputAction vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private string xGyiSuiCaWNorKXVHYCOeFAZGMki;

			public string aEALexpfdjOQfOFoZPQTMORVLqll;

			private bool jmGYGnfmhcoPwtsdgtPUkekhkDOu;

			public bool jFyDQdfhJBKebrdTfpYpfTImrPaVA;

			private InputCategory nwBCBAucIrUpxaFZRBuBxwTTgThV;

			private IEnumerator<int> LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

			private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public EqLDPxELTsRYwaipUXoZpVdjExCeb(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null || userData.actionCategories == null)
						{
							return false;
						}
						if (xGyiSuiCaWNorKXVHYCOeFAZGMki == null || xGyiSuiCaWNorKXVHYCOeFAZGMki == string.Empty)
						{
							return false;
						}
						int num2 = userData.IndexOfActionCategory(xGyiSuiCaWNorKXVHYCOeFAZGMki);
						if (num2 < 0)
						{
							return false;
						}
						nwBCBAucIrUpxaFZRBuBxwTTgThV = userData.GetActionCategory(num2);
						if (jmGYGnfmhcoPwtsdgtPUkekhkDOu)
						{
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = userData.SortedActionIdsInCategory(nwBCBAucIrUpxaFZRBuBxwTTgThV.id).GetEnumerator();
							hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
							goto IL_00f2;
						}
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
						goto IL_0175;
					}
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_00f2;
					case 2:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_0163;
						}
						IL_0175:
						if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA >= userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count)
						{
							break;
						}
						if (userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA].categoryId == nwBCBAucIrUpxaFZRBuBxwTTgThV.id)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA];
							hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
							return true;
						}
						goto IL_0163;
						IL_00f2:
						while (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
						{
							int current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null)
							{
								vjnbYLtrPMftzpjohNfommerCnGo = actionById;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
						}
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
						LTEsUPlDRPIUwfjPOBEMaAhKHeOx = null;
						break;
						IL_0163:
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
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

			private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx != null)
				{
					LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Dispose();
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
				EqLDPxELTsRYwaipUXoZpVdjExCeb eqLDPxELTsRYwaipUXoZpVdjExCeb;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					eqLDPxELTsRYwaipUXoZpVdjExCeb = this;
				}
				else
				{
					eqLDPxELTsRYwaipUXoZpVdjExCeb = new EqLDPxELTsRYwaipUXoZpVdjExCeb(0);
					eqLDPxELTsRYwaipUXoZpVdjExCeb.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				eqLDPxELTsRYwaipUXoZpVdjExCeb.xGyiSuiCaWNorKXVHYCOeFAZGMki = aEALexpfdjOQfOFoZPQTMORVLqll;
				eqLDPxELTsRYwaipUXoZpVdjExCeb.jmGYGnfmhcoPwtsdgtPUkekhkDOu = jFyDQdfhJBKebrdTfpYpfTImrPaVA;
				return eqLDPxELTsRYwaipUXoZpVdjExCeb;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class lZQWBEGfKoIVHEEfSYJhjnzBnCWm : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputMapCategory vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			private string GiYDMCcMONvVCiaWWsZIuJqycBAR;

			public string tvTXNTppqPDhYkrUlpahZVEoTeDc;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public lZQWBEGfKoIVHEEfSYJhjnzBnCWm(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_0098;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (GiYDMCcMONvVCiaWWsZIuJqycBAR == null || GiYDMCcMONvVCiaWWsZIuJqycBAR == string.Empty)
				{
					return false;
				}
				if (userData.mapCategories == null)
				{
					return false;
				}
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_00a8;
				IL_00a8:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < userData.mapCategories.Count)
				{
					if (userData.mapCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA].tag.Equals(GiYDMCcMONvVCiaWWsZIuJqycBAR, StringComparison.OrdinalIgnoreCase))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = userData.mapCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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
				lZQWBEGfKoIVHEEfSYJhjnzBnCWm lZQWBEGfKoIVHEEfSYJhjnzBnCWm2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					lZQWBEGfKoIVHEEfSYJhjnzBnCWm2 = this;
				}
				else
				{
					lZQWBEGfKoIVHEEfSYJhjnzBnCWm2 = new lZQWBEGfKoIVHEEfSYJhjnzBnCWm(0);
					lZQWBEGfKoIVHEEfSYJhjnzBnCWm2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				lZQWBEGfKoIVHEEfSYJhjnzBnCWm2.GiYDMCcMONvVCiaWWsZIuJqycBAR = tvTXNTppqPDhYkrUlpahZVEoTeDc;
				return lZQWBEGfKoIVHEEfSYJhjnzBnCWm2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class WrJFhTvFHTpNkNuBpcZIYMBspkqs : IDisposable, IEnumerable, IEnumerator, IEnumerable<string>, IEnumerator<string>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private string vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int krsTtHLNxEdniCjaeNCXXDxqAnqr;

			public int AuyeagPCbeWgzmSEfGIkRYTpomJk;

			private IEnumerator<int> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public WrJFhTvFHTpNkNuBpcZIYMBspkqs(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (userData.actionCategories == null || userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
						{
							return false;
						}
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = userData.actionCategoryMap.ActionIdsInCategory(krsTtHLNxEdniCjaeNCXXDxqAnqr).GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						break;
					}
					while (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
					{
						int current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
						InputAction actionById = userData.GetActionById(current);
						if (actionById != null)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = actionById.descriptiveName;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
					}
					MoEEbuduDHenVCeJgyjQicJHJnqHb();
					XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

			private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
				{
					XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
				WrJFhTvFHTpNkNuBpcZIYMBspkqs wrJFhTvFHTpNkNuBpcZIYMBspkqs;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					wrJFhTvFHTpNkNuBpcZIYMBspkqs = this;
				}
				else
				{
					wrJFhTvFHTpNkNuBpcZIYMBspkqs = new WrJFhTvFHTpNkNuBpcZIYMBspkqs(0);
					wrJFhTvFHTpNkNuBpcZIYMBspkqs.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				wrJFhTvFHTpNkNuBpcZIYMBspkqs.krsTtHLNxEdniCjaeNCXXDxqAnqr = AuyeagPCbeWgzmSEfGIkRYTpomJk;
				return wrJFhTvFHTpNkNuBpcZIYMBspkqs;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class AbNGVxAaSwLTwidEMbwrjkiVBqeuA : IDisposable, IEnumerable, IEnumerator, IEnumerable<int>, IEnumerator<int>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private int vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int krsTtHLNxEdniCjaeNCXXDxqAnqr;

			public int AuyeagPCbeWgzmSEfGIkRYTpomJk;

			private IEnumerator<int> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public AbNGVxAaSwLTwidEMbwrjkiVBqeuA(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (userData.actionCategories == null || userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
						{
							return false;
						}
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = userData.actionCategoryMap.ActionIdsInCategory(krsTtHLNxEdniCjaeNCXXDxqAnqr).GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						break;
					}
					if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
					{
						int current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
						vjnbYLtrPMftzpjohNfommerCnGo = current;
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					MoEEbuduDHenVCeJgyjQicJHJnqHb();
					XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

			private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
				{
					XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
				AbNGVxAaSwLTwidEMbwrjkiVBqeuA abNGVxAaSwLTwidEMbwrjkiVBqeuA;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					abNGVxAaSwLTwidEMbwrjkiVBqeuA = this;
				}
				else
				{
					abNGVxAaSwLTwidEMbwrjkiVBqeuA = new AbNGVxAaSwLTwidEMbwrjkiVBqeuA(0);
					abNGVxAaSwLTwidEMbwrjkiVBqeuA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				abNGVxAaSwLTwidEMbwrjkiVBqeuA.krsTtHLNxEdniCjaeNCXXDxqAnqr = AuyeagPCbeWgzmSEfGIkRYTpomJk;
				return abNGVxAaSwLTwidEMbwrjkiVBqeuA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		private sealed class CCQazjmVCNdgHQyooPyCaCdWoFNo : IDisposable, IEnumerable, IEnumerator, IEnumerable<string>, IEnumerator<string>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private string vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int krsTtHLNxEdniCjaeNCXXDxqAnqr;

			public int AuyeagPCbeWgzmSEfGIkRYTpomJk;

			private IEnumerator<int> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public CCQazjmVCNdgHQyooPyCaCdWoFNo(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (userData.actionCategories == null || userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
						{
							return false;
						}
						XJDKKrLVzmqpRqpsWNhTQGvqEorq = userData.actionCategoryMap.ActionIdsInCategory(krsTtHLNxEdniCjaeNCXXDxqAnqr).GetEnumerator();
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						break;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						break;
					}
					while (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
					{
						int current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
						InputAction actionById = userData.GetActionById(current);
						if (actionById != null)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = actionById.name;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
							return true;
						}
					}
					MoEEbuduDHenVCeJgyjQicJHJnqHb();
					XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

			private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
				{
					XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
				CCQazjmVCNdgHQyooPyCaCdWoFNo cCQazjmVCNdgHQyooPyCaCdWoFNo;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					cCQazjmVCNdgHQyooPyCaCdWoFNo = this;
				}
				else
				{
					cCQazjmVCNdgHQyooPyCaCdWoFNo = new CCQazjmVCNdgHQyooPyCaCdWoFNo(0);
					cCQazjmVCNdgHQyooPyCaCdWoFNo.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				cCQazjmVCNdgHQyooPyCaCdWoFNo.krsTtHLNxEdniCjaeNCXXDxqAnqr = AuyeagPCbeWgzmSEfGIkRYTpomJk;
				return cCQazjmVCNdgHQyooPyCaCdWoFNo;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class kHvDQpcfEgeeQdHkpDgjIzEoImAN : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputCategory vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			private string GiYDMCcMONvVCiaWWsZIuJqycBAR;

			public string tvTXNTppqPDhYkrUlpahZVEoTeDc;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public kHvDQpcfEgeeQdHkpDgjIzEoImAN(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_00b3;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (GiYDMCcMONvVCiaWWsZIuJqycBAR == null || GiYDMCcMONvVCiaWWsZIuJqycBAR == string.Empty)
				{
					return false;
				}
				if (userData.actionCategories == null)
				{
					return false;
				}
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_00c3;
				IL_00c3:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < userData.actionCategories.Count)
				{
					if (userData.actionCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA].userAssignable && userData.actionCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA].tag.Equals(GiYDMCcMONvVCiaWWsZIuJqycBAR, StringComparison.OrdinalIgnoreCase))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = userData.actionCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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
				kHvDQpcfEgeeQdHkpDgjIzEoImAN kHvDQpcfEgeeQdHkpDgjIzEoImAN2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					kHvDQpcfEgeeQdHkpDgjIzEoImAN2 = this;
				}
				else
				{
					kHvDQpcfEgeeQdHkpDgjIzEoImAN2 = new kHvDQpcfEgeeQdHkpDgjIzEoImAN(0);
					kHvDQpcfEgeeQdHkpDgjIzEoImAN2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				kHvDQpcfEgeeQdHkpDgjIzEoImAN2.GiYDMCcMONvVCiaWWsZIuJqycBAR = tvTXNTppqPDhYkrUlpahZVEoTeDc;
				return kHvDQpcfEgeeQdHkpDgjIzEoImAN2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class PJYKUNPTBWsiJyDIWnzgHDUaarNo : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputAction vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int YicGLhjEfmBcRHjNhglgCZojwiWl;

			public int iHalSNRgFNFOFuRrjdNjqMefbVaZ;

			private bool jmGYGnfmhcoPwtsdgtPUkekhkDOu;

			public bool jFyDQdfhJBKebrdTfpYpfTImrPaVA;

			private InputCategory nwBCBAucIrUpxaFZRBuBxwTTgThV;

			private IEnumerator<int> LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

			private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public PJYKUNPTBWsiJyDIWnzgHDUaarNo(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null || userData.actionCategories == null)
						{
							return false;
						}
						nwBCBAucIrUpxaFZRBuBxwTTgThV = userData.GetActionCategoryById(YicGLhjEfmBcRHjNhglgCZojwiWl);
						if (nwBCBAucIrUpxaFZRBuBxwTTgThV == null || !nwBCBAucIrUpxaFZRBuBxwTTgThV.userAssignable)
						{
							return false;
						}
						if (jmGYGnfmhcoPwtsdgtPUkekhkDOu)
						{
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = userData.SortedActionIdsInCategory(nwBCBAucIrUpxaFZRBuBxwTTgThV.id).GetEnumerator();
							hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
							goto IL_00e4;
						}
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
						goto IL_0165;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_00e4;
					case 2:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
						{
							int current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								vjnbYLtrPMftzpjohNfommerCnGo = actionById;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
						}
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
						LTEsUPlDRPIUwfjPOBEMaAhKHeOx = null;
						break;
						IL_0153:
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
						goto IL_0165;
						IL_0165:
						if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA >= userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count)
						{
							break;
						}
						inputAction = userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA];
						if (inputAction.categoryId == nwBCBAucIrUpxaFZRBuBxwTTgThV.id && inputAction.userAssignable)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = inputAction;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
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

			private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx != null)
				{
					LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Dispose();
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
				PJYKUNPTBWsiJyDIWnzgHDUaarNo pJYKUNPTBWsiJyDIWnzgHDUaarNo;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					pJYKUNPTBWsiJyDIWnzgHDUaarNo = this;
				}
				else
				{
					pJYKUNPTBWsiJyDIWnzgHDUaarNo = new PJYKUNPTBWsiJyDIWnzgHDUaarNo(0);
					pJYKUNPTBWsiJyDIWnzgHDUaarNo.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				pJYKUNPTBWsiJyDIWnzgHDUaarNo.YicGLhjEfmBcRHjNhglgCZojwiWl = iHalSNRgFNFOFuRrjdNjqMefbVaZ;
				pJYKUNPTBWsiJyDIWnzgHDUaarNo.jmGYGnfmhcoPwtsdgtPUkekhkDOu = jFyDQdfhJBKebrdTfpYpfTImrPaVA;
				return pJYKUNPTBWsiJyDIWnzgHDUaarNo;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class CqQekqAWQAyfVfgxBePqdfoZLqkbb : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputAction vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private string ZklqyzoXOFMIiVOuZqzSXtLkQtul;

			public string bviaicAlsPiLsPnZquZuCHTVLAeAA;

			private bool jmGYGnfmhcoPwtsdgtPUkekhkDOu;

			public bool jFyDQdfhJBKebrdTfpYpfTImrPaVA;

			private InputCategory nwBCBAucIrUpxaFZRBuBxwTTgThV;

			private IEnumerator<int> LTEsUPlDRPIUwfjPOBEMaAhKHeOx;

			private int jvxdoEIJKbJWSnuzXZhzUFhyeYVdA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public CqQekqAWQAyfVfgxBePqdfoZLqkbb(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
					UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null || userData.actionCategories == null)
						{
							return false;
						}
						nwBCBAucIrUpxaFZRBuBxwTTgThV = userData.GetActionCategory(ZklqyzoXOFMIiVOuZqzSXtLkQtul);
						if (nwBCBAucIrUpxaFZRBuBxwTTgThV == null || !nwBCBAucIrUpxaFZRBuBxwTTgThV.userAssignable)
						{
							return false;
						}
						if (jmGYGnfmhcoPwtsdgtPUkekhkDOu)
						{
							LTEsUPlDRPIUwfjPOBEMaAhKHeOx = userData.SortedActionIdsInCategory(nwBCBAucIrUpxaFZRBuBxwTTgThV.id).GetEnumerator();
							hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
							goto IL_00e4;
						}
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA = 0;
						goto IL_0165;
					case 1:
						hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
						goto IL_00e4;
					case 2:
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (LTEsUPlDRPIUwfjPOBEMaAhKHeOx.MoveNext())
						{
							int current = LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								vjnbYLtrPMftzpjohNfommerCnGo = actionById;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
						}
						MoEEbuduDHenVCeJgyjQicJHJnqHb();
						LTEsUPlDRPIUwfjPOBEMaAhKHeOx = null;
						break;
						IL_0153:
						jvxdoEIJKbJWSnuzXZhzUFhyeYVdA++;
						goto IL_0165;
						IL_0165:
						if (jvxdoEIJKbJWSnuzXZhzUFhyeYVdA >= userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count)
						{
							break;
						}
						inputAction = userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[jvxdoEIJKbJWSnuzXZhzUFhyeYVdA];
						if (inputAction.categoryId == nwBCBAucIrUpxaFZRBuBxwTTgThV.id && inputAction.userAssignable)
						{
							vjnbYLtrPMftzpjohNfommerCnGo = inputAction;
							hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
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

			private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (LTEsUPlDRPIUwfjPOBEMaAhKHeOx != null)
				{
					LTEsUPlDRPIUwfjPOBEMaAhKHeOx.Dispose();
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
				CqQekqAWQAyfVfgxBePqdfoZLqkbb cqQekqAWQAyfVfgxBePqdfoZLqkbb;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					cqQekqAWQAyfVfgxBePqdfoZLqkbb = this;
				}
				else
				{
					cqQekqAWQAyfVfgxBePqdfoZLqkbb = new CqQekqAWQAyfVfgxBePqdfoZLqkbb(0);
					cqQekqAWQAyfVfgxBePqdfoZLqkbb.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				cqQekqAWQAyfVfgxBePqdfoZLqkbb.ZklqyzoXOFMIiVOuZqzSXtLkQtul = bviaicAlsPiLsPnZquZuCHTVLAeAA;
				cqQekqAWQAyfVfgxBePqdfoZLqkbb.jmGYGnfmhcoPwtsdgtPUkekhkDOu = jFyDQdfhJBKebrdTfpYpfTImrPaVA;
				return cqQekqAWQAyfVfgxBePqdfoZLqkbb;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class ytvpjyNhrVvFPQnQCxGOpjbudDSZ : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputMapCategory vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			private string GiYDMCcMONvVCiaWWsZIuJqycBAR;

			public string tvTXNTppqPDhYkrUlpahZVEoTeDc;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public ytvpjyNhrVvFPQnQCxGOpjbudDSZ(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_00b3;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (GiYDMCcMONvVCiaWWsZIuJqycBAR == null || GiYDMCcMONvVCiaWWsZIuJqycBAR == string.Empty)
				{
					return false;
				}
				if (userData.mapCategories == null)
				{
					return false;
				}
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_00c3;
				IL_00c3:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < userData.mapCategories.Count)
				{
					if (userData.mapCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA].userAssignable && userData.mapCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA].tag.Equals(GiYDMCcMONvVCiaWWsZIuJqycBAR, StringComparison.OrdinalIgnoreCase))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = userData.mapCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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
				ytvpjyNhrVvFPQnQCxGOpjbudDSZ ytvpjyNhrVvFPQnQCxGOpjbudDSZ2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					ytvpjyNhrVvFPQnQCxGOpjbudDSZ2 = this;
				}
				else
				{
					ytvpjyNhrVvFPQnQCxGOpjbudDSZ2 = new ytvpjyNhrVvFPQnQCxGOpjbudDSZ(0);
					ytvpjyNhrVvFPQnQCxGOpjbudDSZ2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				ytvpjyNhrVvFPQnQCxGOpjbudDSZ2.GiYDMCcMONvVCiaWWsZIuJqycBAR = tvTXNTppqPDhYkrUlpahZVEoTeDc;
				return ytvpjyNhrVvFPQnQCxGOpjbudDSZ2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class HOIGrGJETpfYeVrpaEhmvNsRUPDBA : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputCategory>, IEnumerator<InputCategory>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputCategory vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public HOIGrGJETpfYeVrpaEhmvNsRUPDBA(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_0070;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (userData.actionCategories == null)
				{
					return false;
				}
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_0080;
				IL_0080:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < userData.actionCategories.Count)
				{
					if (userData.actionCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA].userAssignable)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = userData.actionCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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
				HOIGrGJETpfYeVrpaEhmvNsRUPDBA hOIGrGJETpfYeVrpaEhmvNsRUPDBA;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					hOIGrGJETpfYeVrpaEhmvNsRUPDBA = this;
				}
				else
				{
					hOIGrGJETpfYeVrpaEhmvNsRUPDBA = new HOIGrGJETpfYeVrpaEhmvNsRUPDBA(0);
					hOIGrGJETpfYeVrpaEhmvNsRUPDBA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return hOIGrGJETpfYeVrpaEhmvNsRUPDBA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class uGfPHUoqogFCqMIqIWeRYBBQRpMA : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputAction>, IEnumerator<InputAction>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputAction vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public uGfPHUoqogFCqMIqIWeRYBBQRpMA(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_007a;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
				{
					return false;
				}
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_008c;
				IL_008c:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count)
				{
					InputAction inputAction = userData.wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
					InputCategory actionCategoryById = userData.GetActionCategoryById(inputAction.categoryId);
					if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = inputAction;
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_007a;
				}
				return false;
				IL_007a:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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
				uGfPHUoqogFCqMIqIWeRYBBQRpMA uGfPHUoqogFCqMIqIWeRYBBQRpMA2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					uGfPHUoqogFCqMIqIWeRYBBQRpMA2 = this;
				}
				else
				{
					uGfPHUoqogFCqMIqIWeRYBBQRpMA2 = new uGfPHUoqogFCqMIqIWeRYBBQRpMA(0);
					uGfPHUoqogFCqMIqIWeRYBBQRpMA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return uGfPHUoqogFCqMIqIWeRYBBQRpMA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class iDFXBfAsuMgzDjBYOrYCuERwWiwm : IDisposable, IEnumerable, IEnumerator, IEnumerable<InputMapCategory>, IEnumerator<InputMapCategory>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private InputMapCategory vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public UserData zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public iDFXBfAsuMgzDjBYOrYCuERwWiwm(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				UserData userData = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_0070;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (userData.mapCategories == null)
				{
					return false;
				}
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_0080;
				IL_0080:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < userData.mapCategories.Count)
				{
					if (userData.mapCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA].userAssignable)
					{
						vjnbYLtrPMftzpjohNfommerCnGo = userData.mapCategories[XFqmAWzGaybkkIOLbVBNhzaWDOgGA];
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
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
				iDFXBfAsuMgzDjBYOrYCuERwWiwm iDFXBfAsuMgzDjBYOrYCuERwWiwm2;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					iDFXBfAsuMgzDjBYOrYCuERwWiwm2 = this;
				}
				else
				{
					iDFXBfAsuMgzDjBYOrYCuERwWiwm2 = new iDFXBfAsuMgzDjBYOrYCuERwWiwm(0);
					iDFXBfAsuMgzDjBYOrYCuERwWiwm2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return iDFXBfAsuMgzDjBYOrYCuERwWiwm2;
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Player_Editor> players = new List<Player_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<InputAction> actions = new List<InputAction>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<InputActionCategory> actionCategories = new List<InputActionCategory>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ActionCategoryMap actionCategoryMap = new ActionCategoryMap();

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMap_Editor> mouseMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> customControllerMaps = new List<ControllerMap_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<CustomController_Editor> customControllers = new List<CustomController_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = new List<ControllerMapLayoutManager_RuleSet_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = new List<ControllerMapEnabler_RuleSet_Editor>();

		[NonSerialized]
		private List<InputAction> zRcuiQUEIzPxqYjNaidlibUKlCET;

		[NonSerialized]
		private bool UvSafGBOtEtLMPqeBMIcKWcraLoIb;

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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int actionIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int actionCategoryIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int inputBehaviorIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int mapCategoryIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int joystickLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int keyboardLayoutIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int mouseLayoutIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int customControllerMapIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int customControllerIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int controllerMapLayoutManagerSetIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int controllerMapEnablerSetIdCounter;

		private Func<int, bool> containsActionDelegate;

		internal IList<Player_Editor> yhcwtnieSsbrJKctPqNEcbZsdLgXA
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

		internal IList<InputAction> fnNZJkeCWXyzDoxsTZOAAgexcJnk
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

		internal IList<InputCategory> qxyjMLNBYWZSwZzFSLKdrtbOBxEw
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

		internal IList<InputBehavior> rGjyLCitzrOObLkFmVwQpVjeMXug
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

		internal IList<InputMapCategory> lruXsPcWAWjxGBlDUNNZnTEWBoyU
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

		internal IList<InputLayout> NlNaENDnIzgxZWSTCErASEuHhxEeA
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

		internal IList<InputLayout> ophacAZxHKjutYjRQtbxJHCwNyxm
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

		internal IList<InputLayout> hBAdSuJlJAlcuHhfCVrZSwpMnQII
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

		internal IList<InputLayout> PcpQfFqzcIJnvzCgAvPkYCfmJCtS
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

		internal IList<ControllerMap_Editor> QeymiMgXFLKBnUmSZEdAfDFMPYaUA
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

		internal IList<ControllerMap_Editor> aKhfDtgYnJRJVLbmfSrLsAdbNYKS
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

		internal IList<ControllerMap_Editor> kyaFnYfFqQrmxiERwZAAEGTkuqRPA
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

		internal IList<ControllerMap_Editor> hcZIvkcoUlPDjGzDfzjQfjKlYGipb
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

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> pXqqkXAwXGECTKvpIGYYzeAaCgqt
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

		internal IList<ControllerMapEnabler_RuleSet_Editor> pzKIPMVNeJAgFRaagpQtHESlCzDI
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

		internal IEnumerable<InputMapCategory> BodQcsUAJmdsPhNyMLsbCwDeQGcqA => new iDFXBfAsuMgzDjBYOrYCuERwWiwm(-2)
		{
			zITtixdgVFWlEnpDnrTdnZsdTFkt = this
		};

		internal IEnumerable<InputCategory> CFRVjkcSCfvtIhAEzQrUgQCitLJC => new HOIGrGJETpfYeVrpaEhmvNsRUPDBA(-2)
		{
			zITtixdgVFWlEnpDnrTdnZsdTFkt = this
		};

		internal IEnumerable<InputAction> UlPDdjkpoBvQbNsLtJDuElsmuwvOA => new uGfPHUoqogFCqMIqIWeRYBBQRpMA(-2)
		{
			zITtixdgVFWlEnpDnrTdnZsdTFkt = this
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

		private List<InputAction> wDjDFLXAnqjEgKDqFzJZjcmMBRJzA
		{
			get
			{
				if (!ReInput.isReady)
				{
					return actions;
				}
				return zRcuiQUEIzPxqYjNaidlibUKlCET;
			}
		}

		internal IEnumerable<InputMapCategory> NmhYvbKLkDZZOXyxHChpARemeuIT(string P_0)
		{
			return new lZQWBEGfKoIVHEEfSYJhjnzBnCWm(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				tvTXNTppqPDhYkrUlpahZVEoTeDc = P_0
			};
		}

		internal IEnumerable<InputMapCategory> nyzktcyjHWFeLYGMggYfEuvPHbYHb(string P_0)
		{
			return new ytvpjyNhrVvFPQnQCxGOpjbudDSZ(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				tvTXNTppqPDhYkrUlpahZVEoTeDc = P_0
			};
		}

		internal IEnumerable<InputCategory> dQCVrIVQyNTLXlGWJhuBbVMblFff(string P_0)
		{
			return new wUgjoADwxhLfDXPHrytwWYqXaGWf(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				tvTXNTppqPDhYkrUlpahZVEoTeDc = P_0
			};
		}

		internal IEnumerable<InputCategory> LObdgfFOfdZvzEiKzEqMyQCneAElA(string P_0)
		{
			return new kHvDQpcfEgeeQdHkpDgjIzEoImAN(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				tvTXNTppqPDhYkrUlpahZVEoTeDc = P_0
			};
		}

		internal IEnumerable<InputAction> aGhijMhepwzAQVtDXCaFRBQdETMCA(int P_0, bool P_1)
		{
			return new fTrLiIGLlimUcUrSVumfTPEJYaEd(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				iHalSNRgFNFOFuRrjdNjqMefbVaZ = P_0,
				jFyDQdfhJBKebrdTfpYpfTImrPaVA = P_1
			};
		}

		internal IEnumerable<InputAction> aGhijMhepwzAQVtDXCaFRBQdETMCA(string P_0, bool P_1)
		{
			return new EqLDPxELTsRYwaipUXoZpVdjExCeb(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				aEALexpfdjOQfOFoZPQTMORVLqll = P_0,
				jFyDQdfhJBKebrdTfpYpfTImrPaVA = P_1
			};
		}

		internal IEnumerable<InputAction> bgOUPOarCMFGtvkASappiSzoeXluA(string P_0)
		{
			return new FCIqVhgwkmJhoKAnDtPpYrUktuRR(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				tvTXNTppqPDhYkrUlpahZVEoTeDc = P_0
			};
		}

		internal IEnumerable<InputAction> BZREHtACTFaaCCmDzKPeWJyFEAF(int P_0, bool P_1)
		{
			return new PJYKUNPTBWsiJyDIWnzgHDUaarNo(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				iHalSNRgFNFOFuRrjdNjqMefbVaZ = P_0,
				jFyDQdfhJBKebrdTfpYpfTImrPaVA = P_1
			};
		}

		internal IEnumerable<InputAction> BZREHtACTFaaCCmDzKPeWJyFEAF(string P_0, bool P_1)
		{
			return new CqQekqAWQAyfVfgxBePqdfoZLqkbb(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				bviaicAlsPiLsPnZquZuCHTVLAeAA = P_0,
				jFyDQdfhJBKebrdTfpYpfTImrPaVA = P_1
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
				Player_Editor player_Editor = HEKgBANjPcPPYXoYrqyVRUuUoiyP();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.key = "system_player";
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputActionCategory inputActionCategory = QTIjVBEokVARTfpiDPpRmtcxhnpSA();
				inputActionCategory.name = "Default";
				inputActionCategory.descriptiveName = inputActionCategory.name;
				actionCategories.Add(inputActionCategory);
				actionCategoryMap.AddCategory(inputActionCategory.id);
				InputBehavior inputBehavior = xXiEaqtLbFDpmnEToOScUxjJxkls();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = tOLQHjXdjgLUYZifYBaOIPhpLrXzA();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = oXhbTWrNQMvCZJnANACVVNcMeUTAA();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = TfQPjqNfWTCgfiRgAQRBTuFZQkloA();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = vlNSwJAnCHeWJwNnRQfSUPAaqQHs();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = uaHUuuUTXhUtAYaJZAMZEuVZunEoA();
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
			for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
			{
				list.Add(wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i]);
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
				KeyboardMap item = keyboardMaps[i].VfFQINZtAexbMlkINnEgflcJgLHA(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].UzzaGqAbQvNipRxKNrJDetJpEXSc(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(HEKgBANjPcPPYXoYrqyVRUuUoiyP());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, HEKgBANjPcPPYXoYrqyVRUuUoiyP());
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
			InputAction inputAction = vldZiTqiaFzIWsWzwGedJoTrHoxw();
			inputAction.categoryId = categoryId;
			wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA != null)
			{
				InputAction inputAction = vldZiTqiaFzIWsWzwGedJoTrHoxw();
				inputAction.categoryId = categoryId;
				wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Add(inputAction);
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
					wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.RemoveAt(num);
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
			if (num == wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count - 1)
			{
				wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Add(inputAction);
				actionCategoryMap.AddAction(categoryId, inputAction.id);
				return wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count - 1;
			}
			wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Insert(num + 1, inputAction);
			int num2 = actionCategoryMap.IndexOfAction(categoryId, actionId);
			actionCategoryMap.InsertAction(categoryId, inputAction.id, num2 + 1);
			return num + 1;
		}

		private int gteQZfotXxxRarIlQohRZJmsgKef(int P_0, InputAction P_1)
		{
			if (IndexOfActionCategory(P_0) < 0)
			{
				return -1;
			}
			InputAction inputAction = P_1.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Add(inputAction);
			return wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count - 1;
		}

		public string[] GetActionNames()
		{
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return null;
			}
			string[] array = new string[wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count];
			for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
			{
				array[i] = wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].name;
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
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return 0;
			}
			for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
			{
				results.Add(wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].name);
			}
			return results.Count;
		}

		public int[] GetActionIds()
		{
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return null;
			}
			int[] array = new int[wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count];
			for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
			{
				array[i] = wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].id;
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
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return 0;
			}
			for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
			{
				results.Add(wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].id);
			}
			return results.Count;
		}

		public string GetActionNameById(int id)
		{
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
			{
				if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].id == id)
				{
					return wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].name;
				}
			}
			return string.Empty;
		}

		public InputAction GetAction(int index)
		{
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null || index < 0 || index >= wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count)
			{
				return null;
			}
			return wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[index];
		}

		public InputAction GetAction(string name)
		{
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return null;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return null;
			}
			return wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[num];
		}

		public InputAction GetActionById(int id)
		{
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return null;
			}
			for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
			{
				if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].id == id)
				{
					return wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i];
				}
			}
			return null;
		}

		public int GetActionId(string name)
		{
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return -1;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return -1;
			}
			return wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[num].id;
		}

		public string[] GetSortedActionNamesInCategory(int id)
		{
			if (actionCategories == null || wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
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
			return new CCQazjmVCNdgHQyooPyCaCdWoFNo(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				AuyeagPCbeWgzmSEfGIkRYTpomJk = id
			};
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (actionCategories == null || wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
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
			return new WrJFhTvFHTpNkNuBpcZIYMBspkqs(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				AuyeagPCbeWgzmSEfGIkRYTpomJk = id
			};
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			if (actionCategories == null || wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
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
			return new AbNGVxAaSwLTwidEMbwrjkiVBqeuA(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				AuyeagPCbeWgzmSEfGIkRYTpomJk = id
			};
		}

		public bool ContainsAction(int id)
		{
			return IndexOfAction(id) >= 0;
		}

		public int IndexOfAction(int id)
		{
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return -1;
			}
			for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
			{
				if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfAction(string name)
		{
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
			{
				if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddActionCategory()
		{
			InputActionCategory inputActionCategory = QTIjVBEokVARTfpiDPpRmtcxhnpSA();
			actionCategories.Add(inputActionCategory);
			actionCategoryMap.AddCategory(inputActionCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputActionCategory inputActionCategory = QTIjVBEokVARTfpiDPpRmtcxhnpSA();
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
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA != null)
			{
				for (int num = wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count - 1; num >= 0; num--)
				{
					if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[num].categoryId == id)
					{
						wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.RemoveAt(num);
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
			if (!duplicateActions || wDjDFLXAnqjEgKDqFzJZjcmMBRJzA == null)
			{
				return;
			}
			int id = inputActionCategory.id;
			int id2 = actionCategories[index].id;
			List<int> list = new List<int>();
			for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
			{
				if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].categoryId == id2)
				{
					list.Add(i);
				}
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>(list.Count);
			for (int j = 0; j < list.Count; j++)
			{
				InputAction inputAction = wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[list[j]];
				int num = gteQZfotXxxRarIlQohRZJmsgKef(id2, inputAction);
				if (num >= 0)
				{
					InputAction inputAction2 = wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[num];
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
			if (num >= 0 && wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[num].categoryId != newCategoryId)
			{
				actionCategoryMap.ChangeCategory(actionId, newCategoryId);
				wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[num].categoryId = newCategoryId;
			}
		}

		public int GetActionCategoryCount(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA != null)
			{
				for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
				{
					if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].categoryId == id)
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
			inputBehaviors.Add(xXiEaqtLbFDpmnEToOScUxjJxkls());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, xXiEaqtLbFDpmnEToOScUxjJxkls());
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = inputBehaviors[index].id;
			if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA != null)
			{
				for (int i = 0; i < wDjDFLXAnqjEgKDqFzJZjcmMBRJzA.Count; i++)
				{
					if (wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].behaviorId == id)
					{
						wDjDFLXAnqjEgKDqFzJZjcmMBRJzA[i].behaviorId = 0;
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
			mapCategories.Add(tOLQHjXdjgLUYZifYBaOIPhpLrXzA());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, tOLQHjXdjgLUYZifYBaOIPhpLrXzA());
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
				Action<List<Player_Editor.Mapping>, int> action = FfuOSESqBYfwvFtkpLBUBftIfMuiA._003C_003E9.anRdVxWtIjDxmoWKRdCYBYGpLnZiA;
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
			switch (controllerType)
			{
			case ControllerType.Keyboard:
				return GetKeyboardLayoutNames();
			case ControllerType.Mouse:
				return GetMouseLayoutNames();
			case ControllerType.Joystick:
				return GetJoystickLayoutNames();
			case ControllerType.Custom:
				return GetCustomControllerLayoutNames();
			default:
				throw new NotImplementedException();
			}
		}

		public int[] GetLayoutIds(ControllerType controllerType)
		{
			switch (controllerType)
			{
			case ControllerType.Keyboard:
				return GetKeyboardLayoutIds();
			case ControllerType.Mouse:
				return GetMouseLayoutIds();
			case ControllerType.Joystick:
				return GetJoystickLayoutIds();
			case ControllerType.Custom:
				return GetCustomControllerLayoutIds();
			default:
				throw new NotImplementedException();
			}
		}

		public void AddJoystickLayout()
		{
			joystickLayouts.Add(oXhbTWrNQMvCZJnANACVVNcMeUTAA());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, oXhbTWrNQMvCZJnANACVVNcMeUTAA());
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
				Action<List<Player_Editor.Mapping>, int> action = FfuOSESqBYfwvFtkpLBUBftIfMuiA._003C_003E9.xohsVtUwDbBWfxAgkCsNGRhjOWhH;
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
			keyboardLayouts.Add(TfQPjqNfWTCgfiRgAQRBTuFZQkloA());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, TfQPjqNfWTCgfiRgAQRBTuFZQkloA());
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
				Action<List<Player_Editor.Mapping>, int> action = FfuOSESqBYfwvFtkpLBUBftIfMuiA._003C_003E9.AphkGIWQUZLfmWKdsjSjSQHeUzBH;
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
			mouseLayouts.Add(vlNSwJAnCHeWJwNnRQfSUPAaqQHs());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, vlNSwJAnCHeWJwNnRQfSUPAaqQHs());
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
				Action<List<Player_Editor.Mapping>, int> action = FfuOSESqBYfwvFtkpLBUBftIfMuiA._003C_003E9.NeUdcYnmWwFFyRCQgnGGnmVGacUX;
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
			customControllerLayouts.Add(uaHUuuUTXhUtAYaJZAMZEuVZunEoA());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, uaHUuuUTXhUtAYaJZAMZEuVZunEoA());
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
				Action<List<Player_Editor.Mapping>, int> action = FfuOSESqBYfwvFtkpLBUBftIfMuiA._003C_003E9.wcgHAbhQZylmxPmhGdunGEpHRizKc;
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

		internal ControllerMap XLaZeIAcluXGguEpDszvQZYdfxQf(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			switch (P_0.type)
			{
			case ControllerType.Joystick:
				return gUxChVRBsjPPDWpUfylXVbZXrBYU((Joystick)P_0, P_1, P_2);
			case ControllerType.Keyboard:
				return FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2);
			case ControllerType.Mouse:
				return FindMouseMap_Game((Mouse)P_0, P_1, P_2);
			case ControllerType.Custom:
				return DSafZsvlKsnfESZPCZvSdrEpJHPB(P_1, ((CustomController)P_0).sourceControllerId, P_2);
			default:
				throw new NotImplementedException();
			}
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

		internal JoystickMap ThFVCIAcQrTgApfKAhfPqPZibRvK(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return gUxChVRBsjPPDWpUfylXVbZXrBYU(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap gUxChVRBsjPPDWpUfylXVbZXrBYU(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return gUxChVRBsjPPDWpUfylXVbZXrBYU(P_0.bjQMBlBXcRlCreyzIvpwhaxSthq, P_1, P_2);
		}

		private JoystickMap gUxChVRBsjPPDWpUfylXVbZXrBYU(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.nxdVctUnUdySmaGmpwfGQasImYFq(guid);
			ControllerMap_Editor controllerMap_Editor = seRcLEtxVSHxhJAZfAcPMXLYUMBD(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.YWFumXVloODvOcNrxeiyTOluUqWu(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.akFcZMRBxxMvoxUzyuXkRTwgFiAL(guid, P_1, P_2);
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
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.diDqtoglemKhtlGtYUWzRokAEaDQ(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = seRcLEtxVSHxhJAZfAcPMXLYUMBD(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = cqJrTZuqoWUkGeSDETqrrBoOxOmG(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.akFcZMRBxxMvoxUzyuXkRTwgFiAL(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty || 1 == 0)
			{
				controllerMap_Editor = seRcLEtxVSHxhJAZfAcPMXLYUMBD(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.YWFumXVloODvOcNrxeiyTOluUqWu(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.akFcZMRBxxMvoxUzyuXkRTwgFiAL(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.nwnGfJyTiuAlTAipWVNZSlXoRWpgA(guid, P_1, P_2);
		}

		private ControllerMap_Editor seRcLEtxVSHxhJAZfAcPMXLYUMBD(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = nxlVtAZkBzNuozecXfMVcLbByyBkA(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor nxlVtAZkBzNuozecXfMVcLbByyBkA(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				bmPSVOSxRxEXcywHNEKBKZjrvgLP(list, joystickLayouts);
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

		private JoystickMap cqJrTZuqoWUkGeSDETqrrBoOxOmG(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.bzBWCkBhyIdyYsaeDfXdNriXIRps(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError("Error remapping joystick template " + P_2.Guid.ToString() + " to joystick " + P_0.guid.ToString() + "\nReason: " + text);
				return null;
			}
			return controllerMap_Editor.YWFumXVloODvOcNrxeiyTOluUqWu(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap VXeVDTTHtGmlyOKABHFkUYBAiTAV(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.nxdVctUnUdySmaGmpwfGQasImYFq(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.nxdVctUnUdySmaGmpwfGQasImYFq(Guid.Empty);
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
				list.Add(allMap.kqvbpTxWGdGtrNRdxLepeZkwTJDn);
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
			ControllerMap_Editor controllerMap_Editor = PEsglqCuLFGEIHPPpBkbErCWqPKu(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.VfFQINZtAexbMlkINnEgflcJgLHA(containsActionDelegate);
				keyboardMap.akFcZMRBxxMvoxUzyuXkRTwgFiAL(keyboard.FZUSYXsTFrKCEfDGTdZDqHMyUGhC, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.nwnGfJyTiuAlTAipWVNZSlXoRWpgA(keyboard.FZUSYXsTFrKCEfDGTdZDqHMyUGhC, categoryId, layoutId);
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
			ControllerMap_Editor controllerMap_Editor = PEsglqCuLFGEIHPPpBkbErCWqPKu(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.UzzaGqAbQvNipRxKNrJDetJpEXSc(containsActionDelegate);
				mouseMap.akFcZMRBxxMvoxUzyuXkRTwgFiAL(mouse.FZUSYXsTFrKCEfDGTdZDqHMyUGhC, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.nwnGfJyTiuAlTAipWVNZSlXoRWpgA(mouse.FZUSYXsTFrKCEfDGTdZDqHMyUGhC, categoryId, layoutId);
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

		internal CustomControllerMap DSafZsvlKsnfESZPCZvSdrEpJHPB(Guid P_0, int P_1, int P_2)
		{
			return DSafZsvlKsnfESZPCZvSdrEpJHPB(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap DSafZsvlKsnfESZPCZvSdrEpJHPB(int P_0, int P_1, int P_2)
		{
			return DSafZsvlKsnfESZPCZvSdrEpJHPB(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap DSafZsvlKsnfESZPCZvSdrEpJHPB(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = htzHbGNSEwJrmDaufQLSHJWLLpGp(P_1, id, P_2, false);
			if (controllerMap_Editor != null)
			{
				CustomControllerMap customControllerMap = controllerMap_Editor.mwoVkYpKHOaqlauALHWxDvrBmfUjB(ContainsAction, P_0);
				customControllerMap.akFcZMRBxxMvoxUzyuXkRTwgFiAL(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			CustomControllerMap customControllerMap2 = CustomControllerMap.nwnGfJyTiuAlTAipWVNZSlXoRWpgA(P_0.typeGuid, id, P_1, P_2);
			customControllerMap2.akFcZMRBxxMvoxUzyuXkRTwgFiAL(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap2;
		}

		private ControllerMap_Editor htzHbGNSEwJrmDaufQLSHJWLLpGp(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = FvCrQMenNTenGJxOjZJYZUFueINt(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor FvCrQMenNTenGJxOjZJYZUFueINt(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				bmPSVOSxRxEXcywHNEKBKZjrvgLP(list, customControllerLayouts);
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
			switch (controllerType)
			{
			case ControllerType.Joystick:
				return GetJoystickMapById(id, out controllerMapIndex);
			case ControllerType.Keyboard:
				return GetKeyboardMapById(id, out controllerMapIndex);
			case ControllerType.Mouse:
				return GetMouseMapById(id, out controllerMapIndex);
			case ControllerType.Custom:
				return GetCustomControllerMapById(id, out controllerMapIndex);
			default:
				throw new NotImplementedException();
			}
		}

		public int DuplicateControllerMap(ControllerType controllerType, int index)
		{
			switch (controllerType)
			{
			case ControllerType.Joystick:
				return DuplicateJoystickMap(index);
			case ControllerType.Keyboard:
				return DuplicateKeyboardMap(index);
			case ControllerType.Mouse:
				return DuplicateMouseMap(index);
			case ControllerType.Custom:
				return DuplicateCustomControllerMap(index);
			default:
				throw new NotImplementedException();
			}
		}

		internal ControllerTemplateMap jcCaVuCDoTXbHtXjaiblxMqPhtkZA(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.AvvvRLGQXSQqYsTTpbdZOOOzipNW();
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
			customControllers.Add(alCifDCJCHVkBVcPYIQltSsJzgFD(typeGuid));
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
			customControllers.Insert(index, alCifDCJCHVkBVcPYIQltSsJzgFD(typeGuid));
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
			controllerMapLayoutManagerRuleSets.Add(mZwrsYCPkoWWVUGvfiftGSsUMKNk());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, mZwrsYCPkoWWVUGvfiftGSsUMKNk());
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
			controllerMapEnablerRuleSets.Add(dXwYtLVQjRufqbcjUsdTjqcyKTPU());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, dXwYtLVQjRufqbcjUsdTjqcyKTPU());
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

		private Player_Editor HEKgBANjPcPPYXoYrqyVRUuUoiyP()
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

		private InputAction vldZiTqiaFzIWsWzwGedJoTrHoxw()
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

		private InputActionCategory QTIjVBEokVARTfpiDPpRmtcxhnpSA()
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

		private InputBehavior xXiEaqtLbFDpmnEToOScUxjJxkls()
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

		private InputMapCategory tOLQHjXdjgLUYZifYBaOIPhpLrXzA()
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

		private InputLayout oXhbTWrNQMvCZJnANACVVNcMeUTAA()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewJoystickLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout TfQPjqNfWTCgfiRgAQRBTuFZQkloA()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewKeyboardLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout vlNSwJAnCHeWJwNnRQfSUPAaqQHs()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewMouseLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout uaHUuuUTXhUtAYaJZAMZEuVZunEoA()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewCustomControllerLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private CustomController_Editor alCifDCJCHVkBVcPYIQltSsJzgFD(Guid P_0)
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

		private ControllerMapLayoutManager_RuleSet_Editor mZwrsYCPkoWWVUGvfiftGSsUMKNk()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor
			{
				id = GetNewControllerMapLayoutManagerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames())
			};
		}

		private ControllerMapEnabler_RuleSet_Editor dXwYtLVQjRufqbcjUsdTjqcyKTPU()
		{
			return new ControllerMapEnabler_RuleSet_Editor
			{
				id = GetNewControllerMapEnablerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames())
			};
		}

		private ControllerMap_Editor tsNFjKgsmxchAxEqSpQjWpferPIA(List<ControllerMap_Editor> P_0, int P_1, int P_2)
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

		private ControllerMap_Editor PEsglqCuLFGEIHPPpBkbErCWqPKu(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = tsNFjKgsmxchAxEqSpQjWpferPIA(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = gTPxYAPEvrdspIusZKbNLfNQjIGUA(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor gTPxYAPEvrdspIusZKbNLfNQjIGUA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				bmPSVOSxRxEXcywHNEKBKZjrvgLP(list, P_1);
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

		private void bmPSVOSxRxEXcywHNEKBKZjrvgLP(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			wtfELDhWCecxWGMDJRSuvXQGyKTpB wtfELDhWCecxWGMDJRSuvXQGyKTpB2 = new wtfELDhWCecxWGMDJRSuvXQGyKTpB();
			wtfELDhWCecxWGMDJRSuvXQGyKTpB2.yCjqQXgJUcuSRtXNKEfkuzuncbMT = P_1;
			if (P_0 != null && wtfELDhWCecxWGMDJRSuvXQGyKTpB2.yCjqQXgJUcuSRtXNKEfkuzuncbMT != null)
			{
				P_0.Sort(wtfELDhWCecxWGMDJRSuvXQGyKTpB2.RZZhgWtLAqzPjRyKpishqLOFrQVr);
			}
		}

		internal void zweOkwOYzJmmdPKMUZyDxJxHpxON()
		{
			if (UvSafGBOtEtLMPqeBMIcKWcraLoIb)
			{
				return;
			}
			zRcuiQUEIzPxqYjNaidlibUKlCET = new List<InputAction>(actions.Count);
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i] == null)
				{
					zRcuiQUEIzPxqYjNaidlibUKlCET.Add(null);
				}
				zRcuiQUEIzPxqYjNaidlibUKlCET.Add(new InputAction(actions[i]));
			}
			yhcwtnieSsbrJKctPqNEcbZsdLgXA = new ReadOnlyCollection<Player_Editor>(players);
			fnNZJkeCWXyzDoxsTZOAAgexcJnk = new ReadOnlyCollection<InputAction>(zRcuiQUEIzPxqYjNaidlibUKlCET);
			List<InputCategory> list = new List<InputCategory>((actionCategories != null) ? actionCategories.Count : 0);
			for (int j = 0; j < actionCategories.Count; j++)
			{
				list.Add(actionCategories[j]);
			}
			qxyjMLNBYWZSwZzFSLKdrtbOBxEw = new ReadOnlyCollection<InputCategory>(list);
			rGjyLCitzrOObLkFmVwQpVjeMXug = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
			lruXsPcWAWjxGBlDUNNZnTEWBoyU = new ReadOnlyCollection<InputMapCategory>(mapCategories);
			NlNaENDnIzgxZWSTCErASEuHhxEeA = new ReadOnlyCollection<InputLayout>(joystickLayouts);
			ophacAZxHKjutYjRQtbxJHCwNyxm = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
			hBAdSuJlJAlcuHhfCVrZSwpMnQII = new ReadOnlyCollection<InputLayout>(mouseLayouts);
			PcpQfFqzcIJnvzCgAvPkYCfmJCtS = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
			QeymiMgXFLKBnUmSZEdAfDFMPYaUA = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
			aKhfDtgYnJRJVLbmfSrLsAdbNYKS = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
			kyaFnYfFqQrmxiERwZAAEGTkuqRPA = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
			hcZIvkcoUlPDjGzDfzjQfjKlYGipb = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
			pXqqkXAwXGECTKvpIGYYzeAaCgqt = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
			pzKIPMVNeJAgFRaagpQtHESlCzDI = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
			if (mapCategories != null)
			{
				for (int k = 0; k < mapCategories.Count; k++)
				{
					if (mapCategories[k] != null)
					{
						mapCategories[k].zweOkwOYzJmmdPKMUZyDxJxHpxON();
					}
				}
			}
			if (actionCategories != null)
			{
				for (int l = 0; l < actionCategories.Count; l++)
				{
					if (actionCategories[l] != null)
					{
						actionCategories[l].zweOkwOYzJmmdPKMUZyDxJxHpxON();
					}
				}
			}
			if (joystickLayouts != null)
			{
				for (int m = 0; m < joystickLayouts.Count; m++)
				{
					if (joystickLayouts[m] != null)
					{
						joystickLayouts[m].zweOkwOYzJmmdPKMUZyDxJxHpxON();
					}
				}
			}
			if (keyboardLayouts != null)
			{
				for (int n = 0; n < keyboardLayouts.Count; n++)
				{
					if (keyboardLayouts[n] != null)
					{
						keyboardLayouts[n].zweOkwOYzJmmdPKMUZyDxJxHpxON();
					}
				}
			}
			if (mouseLayouts != null)
			{
				for (int num = 0; num < mouseLayouts.Count; num++)
				{
					if (mouseLayouts[num] != null)
					{
						mouseLayouts[num].zweOkwOYzJmmdPKMUZyDxJxHpxON();
					}
				}
			}
			if (customControllerLayouts != null)
			{
				for (int num2 = 0; num2 < customControllerLayouts.Count; num2++)
				{
					if (customControllerLayouts[num2] != null)
					{
						customControllerLayouts[num2].zweOkwOYzJmmdPKMUZyDxJxHpxON();
					}
				}
			}
			if (zRcuiQUEIzPxqYjNaidlibUKlCET != null)
			{
				for (int num3 = 0; num3 < zRcuiQUEIzPxqYjNaidlibUKlCET.Count; num3++)
				{
					if (zRcuiQUEIzPxqYjNaidlibUKlCET[num3] != null)
					{
						zRcuiQUEIzPxqYjNaidlibUKlCET[num3].zweOkwOYzJmmdPKMUZyDxJxHpxON();
					}
				}
			}
			containsActionDelegate = ContainsAction;
			UvSafGBOtEtLMPqeBMIcKWcraLoIb = true;
		}

		internal void vjLugohvsLblZuxYcbzfaOVaQPnA()
		{
			if (!UvSafGBOtEtLMPqeBMIcKWcraLoIb)
			{
				return;
			}
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					if (mapCategories[i] != null)
					{
						mapCategories[i].vjLugohvsLblZuxYcbzfaOVaQPnA();
					}
				}
			}
			if (zRcuiQUEIzPxqYjNaidlibUKlCET != null)
			{
				for (int j = 0; j < zRcuiQUEIzPxqYjNaidlibUKlCET.Count; j++)
				{
					if (zRcuiQUEIzPxqYjNaidlibUKlCET[j] != null)
					{
						zRcuiQUEIzPxqYjNaidlibUKlCET[j].vjLugohvsLblZuxYcbzfaOVaQPnA();
					}
				}
			}
			UvSafGBOtEtLMPqeBMIcKWcraLoIb = false;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return NESlgRZGJpioPWtcyNENFepJIOVL.IdwGKNJkaXjzHIJrWUaMXhwlhIpX(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return NESlgRZGJpioPWtcyNENFepJIOVL.IdwGKNJkaXjzHIJrWUaMXhwlhIpX(orig, null, false);
		}
	}
}
