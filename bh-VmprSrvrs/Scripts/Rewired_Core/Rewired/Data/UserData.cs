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
		private static class AowcPeIwcyEcmbkTaJmoQGDnslczb
		{
			[DefaultMember("Item")]
			private class vEwoLkmSlvCSAsvqKkwXEsCFiiUU
			{
				public enum PHPWhFhDyYOUZHktMTDdzulyuyXc
				{
					origId = 0,
					otherId = 1,
					finalId = 2
				}

				public int fUDUsqKCxbEbHlGZtiSEVBUvbLbj;

				public int eauRTZYKIepHEaZNWOmWiVosTqNU;

				public int tkGAvDcBPdRWvdOjlrRajTBrTxxV;

				public int LMkExMQyZCTyuAxOihvbLgXBGmudA
				{
					get
					{
						return 0;
					}
					set
					{
					}
				}

				public vEwoLkmSlvCSAsvqKkwXEsCFiiUU(int P_0, int P_1, int P_2)
				{
				}

				public override string ToString()
				{
					return null;
				}
			}

			private class zubuYfEceCNutoEKZYnoyfJZtrgM<_0001>
			{
				public _0001 UoiCGHPCRdhkzEbfZntLbwUgIWsec;

				public _0001 sZnIRBskMRYuXFuSzMZaYNwGrYnT;

				public vEwoLkmSlvCSAsvqKkwXEsCFiiUU.PHPWhFhDyYOUZHktMTDdzulyuyXc GFbXEtFgMHHVVgOJRkdbNiEskZObb;

				public IList<_0001> kZiqvqBUVCNtLMPMDloDSglwytSQ;

				public bool eSZPUXUgpEkJqmECdRrELRlBiaxkA;

				public zubuYfEceCNutoEKZYnoyfJZtrgM(_0001 P_0, _0001 P_1, vEwoLkmSlvCSAsvqKkwXEsCFiiUU.PHPWhFhDyYOUZHktMTDdzulyuyXc P_2, IList<_0001> P_3, bool P_4)
				{
				}
			}

			[Serializable]
			private sealed class tgTaBfeFAprjfDjaGVtFofXuPEhd
			{
				public static readonly tgTaBfeFAprjfDjaGVtFofXuPEhd _003C_003E9;

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

				internal int oTAPfaTbWBbsvjaJiIUhsksNHCCyA(InputActionCategory P_0)
				{
					return 0;
				}

				internal string JmPjABmubWpkoJUpXAfYxJZpUjKV(InputActionCategory P_0)
				{
					return null;
				}

				internal int yWOBeshgExjUPYlpFXCIhWfOAEQK(InputActionCategory P_0, IList<InputActionCategory> P_1)
				{
					return 0;
				}

				internal int ijkfccjxmxZAZQNsBFhSpMzxmUEb(InputBehavior P_0)
				{
					return 0;
				}

				internal string KGthhtXAYlLBkHIAyInTgmKISgLY(InputBehavior P_0)
				{
					return null;
				}

				internal int TnTECsxDeDDZFeDjMUwDMrNWCjigb(InputBehavior P_0, IList<InputBehavior> P_1)
				{
					return 0;
				}

				internal int roqgfrgPqtqtrGAupPfaaObctKBpA(InputAction P_0)
				{
					return 0;
				}

				internal string CLxgKmedNmjTyguxYnWIYcbblfpiA(InputAction P_0)
				{
					return null;
				}

				internal int LMidKYarWBRIEBiBcHmGbZYgzZbRb(InputAction P_0, IList<InputAction> P_1)
				{
					return 0;
				}

				internal int kUOTKEVENZFdXIvAAwHtlIhdRnVg(InputMapCategory P_0)
				{
					return 0;
				}

				internal string apngivgJhCGClbtCrAyFUyuKcQDoA(InputMapCategory P_0)
				{
					return null;
				}

				internal int hApLhpSBdfhkXwEvFizQqdTjcuSU(InputMapCategory P_0, IList<InputMapCategory> P_1)
				{
					return 0;
				}

				internal int BzCpErioetTgvEbCohBCbVcxvurv(InputLayout P_0)
				{
					return 0;
				}

				internal string JDQYYuaSIcnhWYUvMBGTqerxpAVE(InputLayout P_0)
				{
					return null;
				}

				internal int CITDHuiXqowYLSmtNRwzcSUJSbCb(InputLayout P_0, IList<InputLayout> P_1)
				{
					return 0;
				}

				internal int vrxvnllYHntUzKqaqSaXkhAZXQVp(InputLayout P_0)
				{
					return 0;
				}

				internal string bKSGFqfiqYaAbzXQBpZNZHRVczvF(InputLayout P_0)
				{
					return null;
				}

				internal int ZFnGgAWUmvcEItFUvLEGyCdBImQX(InputLayout P_0, IList<InputLayout> P_1)
				{
					return 0;
				}

				internal int qLbvFVJXMRUxNjxDHGzwAGPqHTxp(InputLayout P_0)
				{
					return 0;
				}

				internal string uRZasTHqJixPPEqnAZkjGCHPIIwm(InputLayout P_0)
				{
					return null;
				}

				internal int TSkkwKHWFJAKXohmJAOfPsLQJgFE(InputLayout P_0, IList<InputLayout> P_1)
				{
					return 0;
				}

				internal int YKYGaIhTidIZfnnjInFrjIqmimTGb(InputLayout P_0)
				{
					return 0;
				}

				internal string whPeDXubQFGIZAsDfSczQOFhcUlQ(InputLayout P_0)
				{
					return null;
				}

				internal int mystVFSjutWanggKVxBjryFRagpL(InputLayout P_0, IList<InputLayout> P_1)
				{
					return 0;
				}

				internal int ilFQxhppgtsxPNGbrDGlPRKKojiG(CustomController_Editor P_0)
				{
					return 0;
				}

				internal string jLRJCHpCgKzEdjVEqxDQtlNxNKRi(CustomController_Editor P_0)
				{
					return null;
				}

				internal int iDnZSKUajRpUPULRuFApbRorcmRFb(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
				{
					return 0;
				}

				internal int XFCQiFcXyMMTDqURcQRkrOUxtttQ(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return 0;
				}

				internal string nwMaBxmjJydLskVLWMwvkoLAsEYsA(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return null;
				}

				internal int VXXboIkUkbUrkWTkXTfzIPhksMAk(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
				{
					return 0;
				}

				internal int OqBeJNYarRAmrFjopSCpaPhcVdnh(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return 0;
				}

				internal string uNpBFURYfqiefTnoWUAQyvBYIxnl(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return null;
				}

				internal int hYOqXknecFhDeMrGXqYBmwidmMwL(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
				{
					return 0;
				}

				internal int bfnGyjIBtxxOYfGIPZRrDCVhcaXIA(Player_Editor P_0)
				{
					return 0;
				}

				internal string HhutrSViZWxHyeaVFcceiDiieCtCb(Player_Editor P_0)
				{
					return null;
				}

				internal int YIRADwwAkACGGSqQDMwEgxXCUDnj(Player_Editor P_0, IList<Player_Editor> P_1)
				{
					return 0;
				}

				internal int IHrXLqaORiIcWBGKoUAqhAkHdkbfA(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
				{
					return 0;
				}

				internal int fWMDtrPPApvuyQbYUDhhbopEslHK(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
				{
					return 0;
				}

				internal int FybcLzMNhvhTLbTiaKbfeDYhlIILc(ControllerMap_Editor P_0)
				{
					return 0;
				}

				internal string xJktCUxDFtufamRVrsROIlGenDUE(ControllerMap_Editor P_0)
				{
					return null;
				}

				internal int tUbifOqPmlZTMRPsBqSTxpdUdLNe(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					return 0;
				}

				internal int dEYVoBFRAmWFyhXlzGuFuQEJzOGi(ControllerMap_Editor P_0)
				{
					return 0;
				}

				internal string WUsUzwqLXYkiajhhGcSgiefTmNVwA(ControllerMap_Editor P_0)
				{
					return null;
				}

				internal int cKyskUBABRJiPLYlJOEPYuVdjbFJ(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					return 0;
				}

				internal int fyScMyNUvxJKZqNhFwMekHuMFZMiA(ControllerMap_Editor P_0)
				{
					return 0;
				}

				internal string camWLbzZKMmzUosxjMOzjtDoRWvi(ControllerMap_Editor P_0)
				{
					return null;
				}

				internal int VVVFlJgzNlInimZtBmnnrDjJJwTJ(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					return 0;
				}

				internal int WnWdjWHBIWUxuRTclquPjFvHFdIuA(ControllerMap_Editor P_0)
				{
					return 0;
				}

				internal string sWqysmulvavoqrIBYqPDUoHtLbcw(ControllerMap_Editor P_0)
				{
					return null;
				}

				internal int XBiMupEQcgGoSULfiqzxTKBmNSAG(ActionElementMap P_0, IList<ActionElementMap> P_1)
				{
					return 0;
				}
			}

			private sealed class kcPoDSRIdnEddftRCsRhVjIaUyhB
			{
				public UserData ImVaQeKiWqGQFPWnXvcPStbHCBBo;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> sPQjEPNHHfIoVFStjRDrpRZEzOmH;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> CxAWFyXuJDVfHZnFrgUvbFKeBKejb;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> BjmhQgsqAuHkQBCSDlweNFrpKFJW;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> uysCtUlzJicRgHeHLVnnVXbZgBxk;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> yuQrjtPMsOlzJSotocLPsgZxXWyr;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> KSkMCnExasVVCvCcOAWuIASwDZwu;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> rCkfxqGeOSvlXwiXAbPAzPENSqQi;

				public Func<ControllerType, List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU>> RgoYhdrdgwFFXvmrpPEoFeRDsWGO;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> OhWzWehmmwQusFSXcyHvVwgccTkJ;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> ewTMYwsWbtWqRoJnrjRfIKpmKCUx;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> CaKTBNcdkHFszQYauexGICzArVpG;

				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> ZkEjDRvdFYTZGPYGgcjjlZEWRWcf;

				internal InputActionCategory ngyIbueqBptiILRjGWDLBAeAcOal(zubuYfEceCNutoEKZYnoyfJZtrgM<InputActionCategory> P_0)
				{
					return null;
				}

				internal InputBehavior tBhvskFiTQZDyeMrySHECJgEZcPm(zubuYfEceCNutoEKZYnoyfJZtrgM<InputBehavior> P_0)
				{
					return null;
				}

				internal InputAction CIEEEwGKCsohBvrcpLRfcokprHtkA(zubuYfEceCNutoEKZYnoyfJZtrgM<InputAction> P_0)
				{
					return null;
				}

				internal InputLayout jGEHuuEGXQfxuqvkWtFlBCfHLlsn(zubuYfEceCNutoEKZYnoyfJZtrgM<InputLayout> P_0)
				{
					return null;
				}

				internal InputLayout FNnsoVgVLDCwkFtwtIKNWtyZidnQ(zubuYfEceCNutoEKZYnoyfJZtrgM<InputLayout> P_0)
				{
					return null;
				}

				internal InputLayout LPHYasdCHvfpzAeldbPgyruWPQWRA(zubuYfEceCNutoEKZYnoyfJZtrgM<InputLayout> P_0)
				{
					return null;
				}

				internal InputLayout tKEFkgTLXKyihLEIFuxnbfGGhssh(zubuYfEceCNutoEKZYnoyfJZtrgM<InputLayout> P_0)
				{
					return null;
				}

				internal List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> fhVmAtxERVcvFiBUnSdCdgsRnfJHA(ControllerType P_0)
				{
					return null;
				}

				internal CustomController_Editor tKyDOHEbCXMFXStpDEhpGIvpCQXhA(zubuYfEceCNutoEKZYnoyfJZtrgM<CustomController_Editor> P_0)
				{
					return null;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor lmKQKsACBUjSGuAZRcOuGeocTGhG(zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					return null;
				}

				internal ControllerMapEnabler_RuleSet_Editor LhTFmEKGFOarCYnDMlJZvuXJHuYu(zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					return null;
				}

				internal Player_Editor qlOwmezoLGJmDdKcZuPWFzsnbUky(zubuYfEceCNutoEKZYnoyfJZtrgM<Player_Editor> P_0)
				{
					return null;
				}
			}

			private sealed class WtOTuyeLlAfbYmoMQvXYNPPKAhVu
			{
				public zubuYfEceCNutoEKZYnoyfJZtrgM<InputAction> NsxdjhZfSPzGMNTsNsOsfQyRouTv;

				internal bool gDnjmsQJfCicHqPMkARjVQcnrTEq(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool XqPnBEsxvLdqShLtDuCIrRjknKts(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class axSruyLpuFgodCzdfdmQDyBpZTTK
			{
				public int jDcyRkpNoHyCNwvMBhAdKSUqtdtm;

				public uUsurtBzIrBGWCtihLlCrfzCCXWHA oJTnwuXnOKVvvlYzHjIhOsZmvQtB;

				internal bool SzHChLyCclgGqpneyPjfSLtVUaBO(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class fntbuRLefpmTtmpyhaIWaJpchCdH
			{
				public int LgaOOAnsKyKarUklcjqqzGJWROdm;

				public uUsurtBzIrBGWCtihLlCrfzCCXWHA OwXduPDdpYAqQPUmHENvheLdzeV;

				internal bool fFTVqpJcbgLRKHNJgvAkDNRhuqwE(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class ThUCfAOOBxEKhVStrsNJUOnbWQvQ
			{
				public zubuYfEceCNutoEKZYnoyfJZtrgM<Player_Editor> xSbjNUXOPhMDOpofWDckSXJwIMxDA;

				public kcPoDSRIdnEddftRCsRhVjIaUyhB TAIcYmbZwZcstExcRPSRzJnmOBcu;

				internal void nlCCusrRfEEWghlVhLphidZDTysl(List<Player_Editor.Mapping> P_0, List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> P_1)
				{
				}
			}

			private sealed class APQqGptqwsaqJBPoZVHzewNclxlAA
			{
				public Player_Editor.Mapping UOJfrQdnxzenSaOpTwZvgOOJfceKb;

				public ThUCfAOOBxEKhVStrsNJUOnbWQvQ MDMHnJDbqfxqgoiiMoeNASbbbLyK;

				internal bool ZBrJdPcVdUqFYqmtQujFpYPKJnzq(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool NmixAXJJGOFSCHfzvISatGrRjnle(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class ewttdtuzNhIlkwgfbswJUPKlkLCr
			{
				public Player_Editor.CreateControllerInfo MDevLqaXvQPoMEIlVbCRoaAVlcFx;

				public ThUCfAOOBxEKhVStrsNJUOnbWQvQ DtCGePkKNgMbXgaEsKnRCvpdtlph;

				internal bool RZlocjzBtgSQMNmHPLegQwzTiENw(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class uhkOdfPCDftTeXQungNGWrMbGuoz
			{
				public int UkyBjzYXDFhHEPujzQSxyFAwqlUJ;

				public ThUCfAOOBxEKhVStrsNJUOnbWQvQ lTwjYAURTniXBvMmFZWdCJvTLJJD;

				internal bool gdkOlTrBFUVKTeSrUHhDJGlXtEUc(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class tFVeiHeeceTlYqnloJsWecKShWaTA
			{
				public int NMQzJyaAOdePveTicfkYPFqCmKVv;

				public ThUCfAOOBxEKhVStrsNJUOnbWQvQ UClbPNIgWINiVkTrrYkoQXWILsokA;

				internal bool wgNDMLmsZheVPaCNIXXQZkPCoIws(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class IsTOKpKufymLcBZzPLwafJsWtqJQ
			{
				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> HpbBDubrOpUiHNqWELVWHUQyNVkb;

				public kcPoDSRIdnEddftRCsRhVjIaUyhB GjXxMsMUoJlfMWsGWsAgRaCIOTkr;

				internal int bdlSjQBaeVfGUqPXMeAyDjCCOZKn(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					return 0;
				}

				internal ControllerMap_Editor xqNdujodQpdBeUUsPgoxMLlLxrvH(zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMap_Editor> P_0)
				{
					return null;
				}
			}

			private sealed class fsYsvvhOnOgLqDijIOqkeKmjaUUib
			{
				public ControllerMap_Editor hIsIIvPMPwyEPNczgFYKyRFZRaxJ;

				public Predicate<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> dzHPvBSeThLPjUPyAYhkXPCIhprg;

				public Predicate<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> AAZKHggKnzOwQUQvoEbYQYEefkLL;

				internal bool IypEkPgXWDBMSRrUqMNEdTACxfjBb(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool IPxBQeejrHwsnBiqKSrJuFLwCdcrA(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class ONUvMACSrHtGaUoQIEQRzWfNKFvt
			{
				public zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMap_Editor> nfEymCtfRarPxrKmoOpqGMCckfvc;

				public ControllerMap_Editor uQwcvEhRQxIhskbylrkLrdDhgsrgb;

				internal bool zKFDpxCqVWejRhwTdULfuyklpRmab(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool agTUsEMbMwFAvFVfOxcYFztQXGw(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class UwkPEiBLdWhJsMXibjSXCetznxVT
			{
				public List<int> FIMPakKINhEHrICRMktiXvATTrFK;

				public kcPoDSRIdnEddftRCsRhVjIaUyhB IGtrpCeWGVcNNPvPrLQHIecIuoSx;

				internal InputMapCategory iyVviUTxcmejZoGhfYrQVhFrBoMe(zubuYfEceCNutoEKZYnoyfJZtrgM<InputMapCategory> P_0)
				{
					return null;
				}
			}

			private sealed class hYZAQTZWFwBnnHNREnmROFdvKqch
			{
				public ActionElementMap ueLHlYCYhSYgibFZkARwGUIqwgApA;

				public ONUvMACSrHtGaUoQIEQRzWfNKFvt AsqnimGMUqzRyHjyuOJHrtRrcPar;

				internal bool cVlPCpzioIMataOvMxgJQHIEoHNk(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class bvyJkrcVdDTGHzguyTuOAJzTLoQP
			{
				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> DeiUeTAPNxyUOsLYyVTAjvglbHVC;

				public kcPoDSRIdnEddftRCsRhVjIaUyhB YNfdphaZcecxpzJwySPNajaGzUXIA;

				internal int ztqakFSnACJcnCnzNriyZNjMRTRg(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					return 0;
				}

				internal ControllerMap_Editor uuGFdiLBqqzDFwKSFabLWYUUdXJt(zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMap_Editor> P_0)
				{
					return null;
				}
			}

			private sealed class eXkOiHPeIxgJRfhUKdxIPunVEaSs
			{
				public ControllerMap_Editor CXpGMmfNjaPhOLzDJanvPJDCvmdOA;

				public Predicate<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> qJSqFvIBKzNJGDQQqCWYgdHWPbeCb;

				public Predicate<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> KBEtNjwZScYOnvvuujclWsmeePVl;

				internal bool cfvRveWkJDAvPflkmfHoHzfhkJZrA(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool GjiZLecZJQCQFSantOnlcRgyVTte(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class GMXCcQtALyXNzpFTHkxEHtsQkdyh
			{
				public zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMap_Editor> MxMixWGeyWqloMedjAXpDPHMpATIb;

				public ControllerMap_Editor JdvdDlfLArexKSSdXKYfdumyxKbw;

				internal bool anZuLCUEUbbXsJNZxyKfCoQPGKuW(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool LYNZrzmytNjnofZinYIpPjGWYUoI(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class WpJdKMAbByxxAqvIzNxoewvkQJwAA
			{
				public ActionElementMap lMRkGzOJrTCUKevmkFGHkbdoZUbH;

				public GMXCcQtALyXNzpFTHkxEHtsQkdyh vtxSkhRzwYgINowVGOxsfONgshjr;

				internal bool iCIvgQstYPOrMDugAAkUHRjWuDvn(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class OiDHlWJcqtRVDxWDQFLHHCAtmeZI
			{
				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> rEzOHfNHbTfMerveTbPJpWTyEsXeA;

				public kcPoDSRIdnEddftRCsRhVjIaUyhB slBMdagwOUdDuTchUMUdXAEahYNt;

				internal int IsrFdbxVKgDHvzxbNPWMWtgAWPSA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					return 0;
				}

				internal ControllerMap_Editor iIKBrdLdnjAwkOjxEPGTQpslBFcR(zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMap_Editor> P_0)
				{
					return null;
				}
			}

			private sealed class TDSiuONPgJbFkVySSLSJFMhseKFbA
			{
				public ControllerMap_Editor DOvAJJIFvhqMpWCNXCWcoHDGaJmCb;

				public Predicate<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> XGPEXEjFfrwahKeSWkQUtEhWftDs;

				public Predicate<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> ZpttGmQAGjCpkLWYqaBRmGAJFjfHA;

				internal bool jBFDZYxydlitCIOVTLLnomGxLPDf(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool BMGGJbuEiuIdtBtQRGqNnJVCFVLiA(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class JTJNBHwFKJIQGeqiKeJyGmWIkZXNB
			{
				public zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMap_Editor> oaIFferLNcbaORSGuwKhvpNSXkXl;

				public ControllerMap_Editor RPDAmmkqPayeNpcSFZVcZzJpdQbn;

				internal bool yzNEgHCsARIDnZIZkYagVCMECNXcb(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool wZiZUkgGwpYXbwxqDnbaSssjkdKw(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class FFYbbxDWONwFdOgHqiBIHJEBDNdcA
			{
				public ActionElementMap XbEDBJvhLGaunfVCqaSQnCQCPezt;

				public JTJNBHwFKJIQGeqiKeJyGmWIkZXNB GEPgTPOmQOjyDavREdYhXNCvKLPS;

				internal bool ErEkjKAyMUguExJbGIrKjEndTJfI(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class BMzEUvEXsWePUUzhVcPFVSSDaSxf
			{
				public List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> BCmNkcTBubEbfeXVcaxzDtAZcUUE;

				public kcPoDSRIdnEddftRCsRhVjIaUyhB zGqKFHfGXGyNkCAgSPsnmowydZoG;

				internal int mwxUTFSKwkUjLioIaslZSjWpDuzs(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					return 0;
				}

				internal ControllerMap_Editor QYFWpzLaoxSnKolURlQEudrYsaIQ(zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMap_Editor> P_0)
				{
					return null;
				}
			}

			private sealed class pQKsBmAkrDtwVqULZQrjGvbFssUL
			{
				public int BOQnFZfQriPzgcidrGgqtFGvMkQi;

				internal bool sWNfmNeafUzLfSKLKeEGnoFMeYZH(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class xbCFSpEbSQExRCYzGFVhaUEhLjmB
			{
				public ControllerMap_Editor BqMTGsXjswQUUHUfQfoKTYgcxyZG;

				public Predicate<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> jOXmIgPqTDSBJYWGmVXedjsCEQNG;

				public Predicate<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> tNatwlhoDSLzplBrrKtnoqSRXxep;

				public Predicate<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> ffsJbpsoHlnxzFRxPotsUrYRDnOf;

				internal bool TzZXqGZduwsMCRPCOysaUnhzdssaA(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool vloBadhrClEzHMCXoeurQfaYFlQh(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool signfKtXnJXtFdfzzAiNsopqgmjF(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class QtpWDASlPkfRjWakXSBpuMCiJHrh
			{
				public zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMap_Editor> cmYtaWNuMhjKcIigxwdVMjqOKWhJ;

				public ControllerMap_Editor fKHTfvsjOMwUXxiAapslbBbvAKVL;

				internal bool wDFaHaBBPKsrGiwIZoUzzjIARLAx(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool aBrVcjiEpMaGPkaWMCmbVThFKsFKA(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}

				internal bool qVsARBuLqUWWNTBfoqzcuoKVaoBg(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class BDOiUgefVkneusBpvgXulYpPwOEQ
			{
				public ActionElementMap tzYkIIUlfiuTaFXfLIrHfmxJdOUS;

				public QtpWDASlPkfRjWakXSBpuMCiJHrh SAVypipvHAVVCRWdjuUMOAbVrmjI;

				internal bool PXYJWAaaHFCYxipoFfbCDVWoEpgfA(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class dGYpFnNKrilgjcVCIfPbnPGdpQnG
			{
				public zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMapLayoutManager_RuleSet_Editor> xQSXFEiwsUlSHhpVVtHIEpMGHxtr;
			}

			private sealed class KjnerqHwDGfFIOwURszLFDlydmQn
			{
				public int qqRJLoBuXSflUKCogihDNArEBhR;

				public dGYpFnNKrilgjcVCIfPbnPGdpQnG UvpMQMTEKKbOrLLYsXyPtBqWSBUp;

				internal bool muYBygbLFxDLsdbLzrIdySlJgVnkA(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class cOnWHCsbDjizUgEMWSXyLRsDDAZt
			{
				public int qJQCWwfMfpOmhfGJGQDZInGwuMYf;

				public dGYpFnNKrilgjcVCIfPbnPGdpQnG nTFXTDpeHsfZCOsQovftkKFbAuVw;

				internal bool JIqEnkBbiLPkpHMmmBMwFSFapXVHb(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class dcscRSHoARbuEjbmzXuAaZOWmLwkA
			{
				public int PZkHqNKREDFAsmwxeubzgClUeYWy;

				public dGYpFnNKrilgjcVCIfPbnPGdpQnG bMPwGVaMgOWoMBZegTrOBdDeYNNX;

				internal bool wicgdxgLcvphOgiGaRwZQCwyHlsZ(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class uUsurtBzIrBGWCtihLlCrfzCCXWHA
			{
				public zubuYfEceCNutoEKZYnoyfJZtrgM<ControllerMapEnabler_RuleSet_Editor> NWqvjsjKYmtIgPSpftdXermtIJO;
			}

			private sealed class OLrjwXWYjPwxxFCcTNsEvymPKKTv
			{
				public int UAaUmBTsEnTCEGMrnGuSWdobMucT;

				public uUsurtBzIrBGWCtihLlCrfzCCXWHA fJLcdEbPXzsUTMbGosCYTMOYsKJg;

				internal bool sodcBWtHhQacUUmPKzZcmPLkreHJ(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			private sealed class FieeFcEIgLxGceNiwJDDfpcOlBsc<_0001> where _0001 : class
			{
				public Func<_0001, int> PRIpOULYeFepqhiDooHoyhGSCuTaA;
			}

			private sealed class jnKQvYeVSydFVVBtBFadkIdZADZgA<_0001> where _0001 : class
			{
				public _0001 xYSAVuOedNUAmQbkfjpQzagFnnej;

				public FieeFcEIgLxGceNiwJDDfpcOlBsc<_0001> YCqrRkFcEgdpgOglpQBvQZvWdSwQ;

				internal bool WlfgnkYbmHasilKdGoHIXRTulstS(vEwoLkmSlvCSAsvqKkwXEsCFiiUU P_0)
				{
					return false;
				}
			}

			public static UserData YuezKJzfZOEYfJlpNVeftnUIHRLy(UserData P_0, UserData P_1, bool P_2)
			{
				return null;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void NshljzhpGPpliyXwfHhTKftAzhSp(object P_0)
			{
			}

			private static void vjzjjRhsGJcIBKVNBvLtDoPffEyBA<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
			{
			}

			private static void dMmpluxYkVkuITKuBwHEUTXpamkl<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<vEwoLkmSlvCSAsvqKkwXEsCFiiUU> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<zubuYfEceCNutoEKZYnoyfJZtrgM<_0001>, _0001> P_9) where _0001 : class
			{
			}
		}

		[Serializable]
		private sealed class YTWekxhjnRySAvExMihfGZXftGTF
		{
			public static readonly YTWekxhjnRySAvExMihfGZXftGTF _003C_003E9;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__199_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__217_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__233_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__249_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__265_0;

			internal void YmavrsUaowoejPuivFFrxrUelpwU(List<Player_Editor.Mapping> P_0, int P_1)
			{
			}

			internal void qwVEabjHfabGvfMoJQtnJwGkDDokb(List<Player_Editor.Mapping> P_0, int P_1)
			{
			}

			internal void yeQEJLSpFxJktXZfKddTZbNmWLTL(List<Player_Editor.Mapping> P_0, int P_1)
			{
			}

			internal void TsCWoPCfizrHUCmncKPrTnXfGYe(List<Player_Editor.Mapping> P_0, int P_1)
			{
			}

			internal void dHiDoWViIgIPgbeTLemRnpuYahjOA(List<Player_Editor.Mapping> P_0, int P_1)
			{
			}
		}

		private sealed class bHJlyBjmCzlvGyzcQvLGMgJHpcsb
		{
			public List<InputLayout> wYWgmOBRRgWfeQQiMPxFvCIaNbNsA;

			internal int GFyKBzqtPkxQiArCOMBcLeaetcZk(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				return 0;
			}
		}

		private sealed class tapfdTKxGqiPEmbiFMTtlaaAIOpIA
		{
			public ControllerMap_Editor yfJTSKzJxPQtJXBtdIZRmmPXIxhm;

			public ControllerMap_Editor iMCrKGdfLmGGprmeHYKKTTTmKocs;

			internal bool AymqVvnUhHsAQafDQCfkJzQjfACwA(InputLayout P_0)
			{
				return false;
			}

			internal bool MVMBHZFQHxodynBTEKLWDWKyejwCA(InputLayout P_0)
			{
				return false;
			}
		}

		private sealed class zFCoThiKZcKBgjLnKgZFgXqiCNrDb : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int JzpHAbtDJBwbSsWHnpZcyAvWwSIw;

			private InputCategory JVcBwyeaFACJvevvHjNsCtCBqLEuc;

			private int GxpKmOuNLFbTKJFXWWZSBIjREWCab;

			private string YOlTgdHhKzVbBGRiHeALksFsiofgb;

			public string HeJDsZzCYPhdlLCjJuwVlcuJfbyG;

			public UserData CggvneKqzyalwQjVZbjygznYrwOgA;

			private int sGUMgHfOlPDhbwcrhfiLEuyAaONGb;

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
			public zFCoThiKZcKBgjLnKgZFgXqiCNrDb(int P_0)
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

		private sealed class OIentYTrKnzNByPFcaGABxuJBqwl : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int cYPkfbkaMwlfaFQclKZuulazeztK;

			private InputAction IBQIOtfPbkjSpGoobRWeGhYNbiAHc;

			private int ZXrcqVfTUTuSmmDNheAjdlUbdOvDA;

			public UserData kxKdLwoxlqidXlXGUTmhTiXqkEHv;

			private string ddLtpQueoVBsuQsiHGdPINlRleuIA;

			public string nfbKsxrNecTrVwHKcHkBIPCciYhWA;

			private int pXEPupYdfPuvkrVXHZrVFRfMDAlD;

			private int bFUYHjNVRNeTIrJByUCBpsRCwrNI;

			private InputCategory FjiSTKPMdldpJDZpXEmkVskxAZSEA;

			private int aAPkNdzCEQSoWYufiduhnQoTVQLe;

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
			public OIentYTrKnzNByPFcaGABxuJBqwl(int P_0)
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

		private sealed class wHBdxNHxrvlgfRqDqRRBhOnkipneb : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int MuDFCBLdlJRshBODtQSgFikncLnL;

			private InputAction ZJZRUFqRIbTTxIMecPaEQedZJgtk;

			private int oQZxJBoJbApsVlAPOptUvweavzPp;

			public UserData WkoXjRtSThGsdMVfZeCgZzbSCtOi;

			private bool zACsBpxBdnQEOvQHmDjzkLdmAZubA;

			public bool JNFbWQIBpYleXgvyVAJoMExMAzzEA;

			private int pvAiNYkZobgDTvmZtTeWvROWsLzr;

			public int dYeNLuewDNXYsLjdzdCAVbhpCKow;

			private IEnumerator<int> VHraopwUYtuVyOKLZmyNFEaowvth;

			private int qSxsjPfuVyMdTAHrhyzbkCtphOIW;

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
			public wHBdxNHxrvlgfRqDqRRBhOnkipneb(int P_0)
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

			private void XESqiCpvQcmyzLhXtWUARXoYVPCh()
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

		private sealed class ZGdfEGonqfSDBSPWpDTyWXDYYerF : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int SQOEdJMbRLMlyRwdfWoGisSVJFhg;

			private InputAction JdKkPgOpOoZKTcldqqlXhHEajljg;

			private int IxFXYPwrRsFvCIFLSPEJOUfBWEbB;

			public UserData BsPMpmZgihIZGDNjwzUcOaocAfCK;

			private string OQLbSDgsnzjCmKnEBeiapzGZLacj;

			public string gfZpJnkLzyCkSdGBnTrfASQkSMfTA;

			private bool lrTkMkCDvLfhgigTJtISHQfBROBtA;

			public bool QCSAfudrhKmjwpgkzudoDfVMOnlpA;

			private InputCategory IzneVzTGmWHnCYIHkFGeWfVQNmDb;

			private IEnumerator<int> riafcJwiBngTmMgLcpEeGXDbJall;

			private int sZInapGcKTSYvCOjhqJmvSFiSUzh;

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
			public ZGdfEGonqfSDBSPWpDTyWXDYYerF(int P_0)
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

			private void tCzfSqDIyEhIXIpYRqhuEPMiMPPpb()
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

		private sealed class sxalkjbIelCXiikHpLuGDqPwrnhbb : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int TEqlGUHhVLFSUCWqpYhtSWrpzkNp;

			private InputMapCategory bMeFyIEeuNhvKatyFarAzMEZBgtQA;

			private int EmnlWqxSxrJecUXMenTizKZosOfr;

			private string fZnwpVxHZODlUAniUQWoTPOCeINI;

			public string IhawvnvizDAjSUlXkkZurmQoDdOi;

			public UserData OOFrMiDiDMtibjJVlWYoKYLYcmzO;

			private int OpFAGbeNUpyzxlOHEhEOVrChjXxy;

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
			public sxalkjbIelCXiikHpLuGDqPwrnhbb(int P_0)
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

		private sealed class JvjbXeAOlYMBBdvnGiepTaxBoBVy : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int qpdWdoWLsEJIIaJFAZwjtiiabOgl;

			private string ayGEXPLiamYucHFKPRMWZgYeLqBI;

			private int UxBUsQVTfRZPGaLxQXWAWlCpKyFJ;

			public UserData qIsbTBKiqVGBKoQDIbgfyCsmfisJA;

			private int AhREEJEXDvNchlWPhICCgheaHQujA;

			public int wBabNGKRmzsGSkVKipWwBeBtVixTA;

			private IEnumerator<int> uuhfMiQmmsvRQKkrsaqXeHcgOArgb;

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
			public JvjbXeAOlYMBBdvnGiepTaxBoBVy(int P_0)
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

			private void whDqCRjsMVETkPCRggxkHldcqjfl()
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

		private sealed class PjttKFLsehJRqPkErHFMrGaoPwPC : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int SMYcxZIvajZOLYCUgdtzQTSfHUM;

			private int XFLmhoGnjgDFUtzuTBvsfLtXeZVv;

			private int SgZGoPBNhdWWGUzHYejhaaPfTBZy;

			public UserData qWCzEppxcqOrvRxVvknUKrzueJIc;

			private int LcEQldIctzuicVjJuOQDsTFeCIEW;

			public int robKNzobUsGWvFWqIFIFhHBIcjFdb;

			private IEnumerator<int> AKvBoTCzzikwsjqJExOuytvTksLT;

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
			public PjttKFLsehJRqPkErHFMrGaoPwPC(int P_0)
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

			private void fgRxhRKSKhdratzRYlKnDKFoWFgo()
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

		private sealed class FZyGBOTkoGZkuuXAHVLdrATtBosBA : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int fVqVBRUVySrZDBuJNlbqmXiGfwkR;

			private string iJmNyuBmvTLrCUzAkVGYYzXFjieb;

			private int WzCrURVYAuppPKDaKAHwjuUKRgiW;

			public UserData NZHaCiRQMtopsxVnfKavpEzFSLAh;

			private int CQqGeFcFCiGliatqBzguzhYKvNzu;

			public int hTBcobKYDZVdajmiVxUGBlwTyYEn;

			private IEnumerator<int> sWmCRBzCDKbJpAKObPkYcjkbdgyVb;

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
			public FZyGBOTkoGZkuuXAHVLdrATtBosBA(int P_0)
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

			private void NnTAxfAMVuCSTaEXbkDUgzxzLjXfc()
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

		private sealed class zRDjlAJNgzqQhHzAEVsMNcwTFadm : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int EZDBnjqeGajqaREOtoBdFCwacesC;

			private InputCategory xBHSxYlBDORBtCjDijUaeYdxwKvnA;

			private int NQSXEKpmEbNRfBHhHhKNOGhFIGscA;

			private string szFkVJvERoctpXjJATaewxNsGZwp;

			public string IWnarEjMwPBeJEJRFaAteWIbYUHxB;

			public UserData SSuDBfbPSpwJptLeYUZOBgRzvBjr;

			private int WhgqUhUjRgpQidzNscmIqhPCBBDR;

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
			public zRDjlAJNgzqQhHzAEVsMNcwTFadm(int P_0)
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

		private sealed class GrkmcgkCrLgmsAfuvTEBYngBXCas : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int bspCvDfKAtayuxhXlPfkTVUcsWGL;

			private InputAction QByjSgSyCRdjaXbQKGKLqfhuerCCA;

			private int RyIcVgiffQBHYyCPBFylqtjBLHiS;

			public UserData vNZKIabCVSfrdDYKAnaJlmHEFoZK;

			private int AzSUDOZjTysBaRAGHFxnwukIBplt;

			public int YLFCYvWuoleKKIGUxBTgPmIpiOwlA;

			private bool YxFzWGTTtIMJhbUMSKWOFDoqJveI;

			public bool iYwNTWNfpgXKvYlnLgBDgBEOAwitA;

			private InputCategory gOoycUMRjucMKZvFojzIMApnPCQK;

			private IEnumerator<int> OeoDDtLbJseUNNVsfHbGwIgozueI;

			private int yfTELEesCbjyZBUbChSTdiRCssBfb;

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
			public GrkmcgkCrLgmsAfuvTEBYngBXCas(int P_0)
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

			private void YUvLbRGpadCFjDLnBTEaibXNYENUA()
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

		private sealed class BhwCbVtcpDfByVHhoyAFuKMgDNXh : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int ynMgkMvCyiyoaNCYUcMtaTJXGJawA;

			private InputAction igZXkJDKwbaDRkSXFUGHTcXMSpaV;

			private int TVVodnLWZnsfAnQjQeLeZxjMTMqn;

			public UserData wMzAnzPGCGMCLnjEwMaGNVkQQUHE;

			private string EYUbPchqdwvrtZqKOtoomoOiZsOO;

			public string JcFETxjmxOVoTthwqmYqbCTOVFhJ;

			private bool eWUcWDfirpEccAmslpZDKBBIcVeK;

			public bool tRiGAcfbBmrbimznLBvEznSNamFn;

			private InputCategory MNFtJAlXmYVTiPFkfJrHdtbMFFfT;

			private IEnumerator<int> VrGUsuKRxghJHhiusVCMWqrMhQBn;

			private int fNPoDRnhSxtLkbuqOQNVVUNcSzMf;

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
			public BhwCbVtcpDfByVHhoyAFuKMgDNXh(int P_0)
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

			private void pjJMRrcujixZUybnBxVxYbTpPSwj()
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

		private sealed class daPLhTiqTEJLkeUiznIfkqPVmujf : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int kEUivZhENngmSbGekciiXPblhxVOA;

			private InputMapCategory mKFaKGuOyoGlGYpjXkZKPhFTiGIV;

			private int XurefcJHDOOQYRLDjmYRzDYgzzdAA;

			private string zgufkudGUBgFKNIfilbwQIYonjafA;

			public string hCXcmNDDChbMUFRCdjNWNyZXxzyg;

			public UserData zfMZMIwaOxjmuCqBwQRWYLPpiaGBA;

			private int piIbYYetMximfmetiFMpuoIHqONWA;

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
			public daPLhTiqTEJLkeUiznIfkqPVmujf(int P_0)
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

		private sealed class UiDEnzHfmEIBJNLXbYTGKOsmQyl : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int hUGjveBwCAAbYcmeAtIbzrDhltns;

			private InputCategory njiVQIJUhsnLSoALLTDvpLMvYlGE;

			private int jDXldXDpsWqhKXKcIreqWkgqiTox;

			public UserData MvKtYhfgUtTSXzUojjvAfrVsRpFJ;

			private int BcMjAOaRhMvgSyJyuqrwrALCBxME;

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
			public UiDEnzHfmEIBJNLXbYTGKOsmQyl(int P_0)
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

		private sealed class dFmhpkHVQdaVjbcuPpfJRPhgBaAdb : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int tSYCmyAGYvAfwOkpZwNDFcOqNUixA;

			private InputAction ODqWiLNRpwnRcobltoYiRrrssQTd;

			private int uuafqwhoXHpttYfLsoZtKFnpTBpQ;

			public UserData whmekbmRNrNHRQbqnQwayfoaDAwJA;

			private int urexzHVbeaXppktlKpLaFtuxRtfQ;

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
			public dFmhpkHVQdaVjbcuPpfJRPhgBaAdb(int P_0)
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

		private sealed class rijpjYxAALftsZrqrplhthzNDXRI : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int CNKKFtWdxNCIgquGLvAVDAafpGai;

			private InputMapCategory pcQdlIFyszqyGDQKjmPvowWccnqz;

			private int vHeOLPLQcbIYhxzXuuCzQGDOKNQF;

			public UserData iPEJpcTbhFOlGkpKevYcnOQrnZOi;

			private int FBsdkZyRcqhRibujBPTBcdpdhhmWB;

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
			public rijpjYxAALftsZrqrplhthzNDXRI(int P_0)
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
		private List<InputAction> bmVtrnqmdNSZyWdDwWdQGuNPPLMM;

		[NonSerialized]
		private bool dzVhrQPjIPpJRDSicPpbqMFeGFqb;

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

		internal IList<Player_Editor> AlyIJKzbgitejphosbEphaBheQKO
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

		internal IList<InputAction> JCBkslUDJdRMbgBdKEfzvbzetUkX
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

		internal IList<InputCategory> HTQgFEjstYfUsFEyHqNtSRsYSqdUA
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

		internal IList<InputBehavior> CYqDKfAlNJwOGioXZkgxeyAkXhnN
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

		internal IList<InputMapCategory> ujAgMBdNUAoSoJDpvDCGioejIRpf
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

		internal IList<InputLayout> kFeErSbxTSaUajEpCYZoqqAkUHUB
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

		internal IList<InputLayout> YNPjStzKNYCniJqtHtvPjSeMvSqnA
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

		internal IList<InputLayout> VDLbbZFNujoVhvJmUZIElzOLGdMp
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

		internal IList<InputLayout> SECcmcXbxOtkjZCbJAuhdUMyuwEOA
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

		internal IList<ControllerMap_Editor> LynauAIcvJZzcqwMxVWkEsxprQYp
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

		internal IList<ControllerMap_Editor> jomZlcEbYCXccYSxRcrdOGTIlhSC
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

		internal IList<ControllerMap_Editor> CYYVSgHoDxPRvbcgHKxAtTGHuqWJ
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

		internal IList<ControllerMap_Editor> MMCqmJMIsCAyKGVCNYeVYqTWfMJM
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

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> ogwZhcITsAZJOOwoWqjvIkSMImPi
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

		internal IList<ControllerMapEnabler_RuleSet_Editor> VZlcnRAVciwwzSUxKMQmUxfuAEQDA
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

		internal IEnumerable<InputMapCategory> ekNAGWxNOaCCdNEleKwrMMsoDbqq
		{
			[IteratorStateMachine(typeof(rijpjYxAALftsZrqrplhthzNDXRI))]
			get
			{
				return null;
			}
		}

		internal IEnumerable<InputCategory> UZiCiWjUTwpSqDKMyiidSMISaRbb
		{
			[IteratorStateMachine(typeof(UiDEnzHfmEIBJNLXbYTGKOsmQyl))]
			get
			{
				return null;
			}
		}

		internal IEnumerable<InputAction> GHXaZarGcFNPwvZPAxwNRcmLqImd
		{
			[IteratorStateMachine(typeof(dFmhpkHVQdaVjbcuPpfJRPhgBaAdb))]
			get
			{
				return null;
			}
		}

		public int playerCount => 0;

		private List<InputAction> tiAWbzzOMTVwlSUhWgcgsQEgtJQQ => null;

		[IteratorStateMachine(typeof(sxalkjbIelCXiikHpLuGDqPwrnhbb))]
		internal IEnumerable<InputMapCategory> cJSvacoqwUyaIwBkfrwMZiSHbBiK(string P_0)
		{
			return null;
		}

		[IteratorStateMachine(typeof(daPLhTiqTEJLkeUiznIfkqPVmujf))]
		internal IEnumerable<InputMapCategory> fAWsLSgSThuxrdFiPsdpOwodPyyn(string P_0)
		{
			return null;
		}

		[IteratorStateMachine(typeof(zFCoThiKZcKBgjLnKgZFgXqiCNrDb))]
		internal IEnumerable<InputCategory> HcyjddXECTwlQaWoieyRarKqbmOi(string P_0)
		{
			return null;
		}

		[IteratorStateMachine(typeof(zRDjlAJNgzqQhHzAEVsMNcwTFadm))]
		internal IEnumerable<InputCategory> zvRwLztiGaAhzHFDUhIlRlHraYLe(string P_0)
		{
			return null;
		}

		[IteratorStateMachine(typeof(wHBdxNHxrvlgfRqDqRRBhOnkipneb))]
		internal IEnumerable<InputAction> zUDkuDmVrtxPZaBXfFoqgcyGBexm(int P_0, bool P_1)
		{
			return null;
		}

		[IteratorStateMachine(typeof(ZGdfEGonqfSDBSPWpDTyWXDYYerF))]
		internal IEnumerable<InputAction> TyLBeZGSLZJoSqcomOmTFSpDSbRuB(string P_0, bool P_1)
		{
			return null;
		}

		[IteratorStateMachine(typeof(OIentYTrKnzNByPFcaGABxuJBqwl))]
		internal IEnumerable<InputAction> kWfdmhNiByOkGSgoDJEMGSHirABV(string P_0)
		{
			return null;
		}

		[IteratorStateMachine(typeof(GrkmcgkCrLgmsAfuvTEBYngBXCas))]
		internal IEnumerable<InputAction> ACpuRoZhrimNrSVODGEzHADWGEfD(int P_0, bool P_1)
		{
			return null;
		}

		[IteratorStateMachine(typeof(BhwCbVtcpDfByVHhoyAFuKMgDNXh))]
		internal IEnumerable<InputAction> jHtbrGihGINskDBiZQCjIGGerLwtA(string P_0, bool P_1)
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

		private int tvfemlVKAFAGIZKcXhgiptGqjoGEA(int P_0, InputAction P_1)
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

		[IteratorStateMachine(typeof(FZyGBOTkoGZkuuXAHVLdrATtBosBA))]
		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			return null;
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			return null;
		}

		[IteratorStateMachine(typeof(JvjbXeAOlYMBBdvnGiepTaxBoBVy))]
		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			return null;
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			return null;
		}

		[IteratorStateMachine(typeof(PjttKFLsehJRqPkErHFMrGaoPwPC))]
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

		internal ControllerMap lpgKYjBaJKabBImmIDrajDqOFcDi(Controller P_0, int P_1, int P_2)
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

		internal JoystickMap IqNJgycmIPYDTpTqlsoNjnEJxLzH(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return null;
		}

		internal JoystickMap cBiHfgVtJsMKSStqnLnSdtYQhlCC(Joystick P_0, int P_1, int P_2)
		{
			return null;
		}

		private JoystickMap RzwoIYStAgvyobkekZErpSOLUkid(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return null;
		}

		private ControllerMap_Editor bETCQaUSYkPIIUQcjtrRAgoArBMX(int P_0, Guid P_1, int P_2, bool P_3)
		{
			return null;
		}

		private ControllerMap_Editor UCHpfFThqJvlrybIVgXsltXKTvLb(int P_0, Guid P_1, int P_2)
		{
			return null;
		}

		private JoystickMap calpygUwJoPzpRfxhckSxWPkECDN(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			return null;
		}

		private JoystickMap EktUedjnWqUPPjkfMjMHKCatZNoK(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
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

		internal CustomControllerMap GnxnVSiJIMFyKlcwvPciJMkjKZDp(Guid P_0, int P_1, int P_2)
		{
			return null;
		}

		internal CustomControllerMap PXdSqaCzGYDpXweWnVQEhrqsVQJT(int P_0, int P_1, int P_2)
		{
			return null;
		}

		private CustomControllerMap BgSMFoOPrVKLPZnEphFNkycZBprp(CustomController_Editor P_0, int P_1, int P_2)
		{
			return null;
		}

		private ControllerMap_Editor eCIHMZbNaJaRvRkkrlntnVNVCZjZ(int P_0, int P_1, int P_2, bool P_3)
		{
			return null;
		}

		private ControllerMap_Editor EfhyHMkdtNemHtTgdVaeiOxYKahE(int P_0, int P_1, int P_2)
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

		internal ControllerTemplateMap QjWQeufVjjHtdHqtLUmjxaHHVVhk(Guid P_0, int P_1, int P_2)
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

		private Player_Editor jSYExEdTcHOAYmaHtBZDzDSzQnunA()
		{
			return null;
		}

		private InputAction IKhBYgTWJrkAvPARgGipHlwfBkUtA()
		{
			return null;
		}

		private InputActionCategory JIDBxnPoEjKBNsNDMWwOOMLDwChf()
		{
			return null;
		}

		private InputBehavior yeGtZuukqgFbkTaTKVkEqkEEQwTu()
		{
			return null;
		}

		private InputMapCategory hdCdipNqrUFqxwSBlULRekrUALUDA()
		{
			return null;
		}

		private InputLayout JdpfIrbgGmlFCNsvTWAdWKUlgLngb()
		{
			return null;
		}

		private InputLayout EYtkSQuMJbiMuefFYCpbIsBsWvKDb()
		{
			return null;
		}

		private InputLayout mXboFrhPrxDRccaizGiVcmnfrrROB()
		{
			return null;
		}

		private InputLayout ynyDRUOVwidkaFEyfqDKdkcIFEugB()
		{
			return null;
		}

		private CustomController_Editor rJzibSsBgWnAdcgmwpJITgxVjwDm(Guid P_0)
		{
			return null;
		}

		private ControllerMapLayoutManager_RuleSet_Editor APNErfnPJOFFFcoJDkkRCoZsUCecb()
		{
			return null;
		}

		private ControllerMapEnabler_RuleSet_Editor PSbeOzEuXcIJccVrFjVJOqmtyKgwB()
		{
			return null;
		}

		private ControllerMap_Editor vXFgrACtPBcSvvQGBNocHVLtUMFIb(List<ControllerMap_Editor> P_0, int P_1, int P_2)
		{
			return null;
		}

		private ControllerMap_Editor yirWguOfYAIBsjBVcmIrMTehhQsX(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			return null;
		}

		private ControllerMap_Editor ZFLkPtpDmGIuPKSGuatTDtfgxiKjA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			return null;
		}

		private void pRXcoPYMuryFJrlGtYaWfIGAwEdr(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
		}

		internal void dgLDtVFXNNVzwWqnEKskgxUEaxiR()
		{
		}

		internal void AWWBntehAmwFhOibfcrNVyjcJmFF()
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
