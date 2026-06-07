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
		private static class WQrUhGbSKUohArdfnPGupECxSBlw
		{
			[DefaultMember("Item")]
			private class tfhhvKrILJwRgzvYmSiFbeBSkARM
			{
				public enum PFIodniGImNxQYQcwvbMOpIpErUc
				{
					origId = 0,
					otherId = 1,
					finalId = 2
				}

				public int fSEkgEZqJTLbbuGvFMxGknJgZlam;

				public int gVzHnxHomYJAyjxzmqUYZIjrHEER;

				public int vFJRRzbpxRVPLshHPxFeASCuVkul;

				public int PJtLFmPBdaRxETzaUdTxyBAUuGxX
				{
					get
					{
						return P_0 switch
						{
							PFIodniGImNxQYQcwvbMOpIpErUc.origId => fSEkgEZqJTLbbuGvFMxGknJgZlam, 
							PFIodniGImNxQYQcwvbMOpIpErUc.otherId => gVzHnxHomYJAyjxzmqUYZIjrHEER, 
							PFIodniGImNxQYQcwvbMOpIpErUc.finalId => vFJRRzbpxRVPLshHPxFeASCuVkul, 
							_ => throw new NotImplementedException(), 
						};
					}
					set
					{
						switch (pFIodniGImNxQYQcwvbMOpIpErUc)
						{
						case PFIodniGImNxQYQcwvbMOpIpErUc.origId:
							fSEkgEZqJTLbbuGvFMxGknJgZlam = num;
							break;
						case PFIodniGImNxQYQcwvbMOpIpErUc.otherId:
							gVzHnxHomYJAyjxzmqUYZIjrHEER = num;
							break;
						case PFIodniGImNxQYQcwvbMOpIpErUc.finalId:
							vFJRRzbpxRVPLshHPxFeASCuVkul = num;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public tfhhvKrILJwRgzvYmSiFbeBSkARM(int P_0, int P_1, int P_2)
				{
					fSEkgEZqJTLbbuGvFMxGknJgZlam = P_0;
					gVzHnxHomYJAyjxzmqUYZIjrHEER = P_1;
					vFJRRzbpxRVPLshHPxFeASCuVkul = P_2;
				}

				public virtual string McmWixiHMYonaRLwcCOnEaPDJUhs()
				{
					return string.Concat(string.Concat("" + StringTools.WriteVar("origId", fSEkgEZqJTLbbuGvFMxGknJgZlam), StringTools.WriteVar("otherId", gVzHnxHomYJAyjxzmqUYZIjrHEER)), StringTools.WriteVar("finalId", vFJRRzbpxRVPLshHPxFeASCuVkul));
				}
			}

			private class xYqbgJJDYgqlPUrubRRshNKKePtQA<_0001>
			{
				public _0001 QrbicxKYbNtQHkRZnPyPBhRJqhhi;

				public _0001 qesshvxokjrtrYTsLtduhtxZhwaP;

				public tfhhvKrILJwRgzvYmSiFbeBSkARM.PFIodniGImNxQYQcwvbMOpIpErUc KCiEkNdEgbYOfGZndQVftTXvupPiA;

				public IList<_0001> gCzlHAIFruSyrDPyfTSXbPmbcLDX;

				public bool eQSnIrDLPcWbMhTmPFjWoRmWILiI;

				public xYqbgJJDYgqlPUrubRRshNKKePtQA(_0001 P_0, _0001 P_1, tfhhvKrILJwRgzvYmSiFbeBSkARM.PFIodniGImNxQYQcwvbMOpIpErUc P_2, IList<_0001> P_3, bool P_4)
				{
					QrbicxKYbNtQHkRZnPyPBhRJqhhi = P_0;
					qesshvxokjrtrYTsLtduhtxZhwaP = P_1;
					KCiEkNdEgbYOfGZndQVftTXvupPiA = P_2;
					gCzlHAIFruSyrDPyfTSXbPmbcLDX = P_3;
					eQSnIrDLPcWbMhTmPFjWoRmWILiI = P_4;
				}
			}

			[Serializable]
			private sealed class vFYQFnnHvNyOJSaBiBjXJFmvFxmY
			{
				public static readonly vFYQFnnHvNyOJSaBiBjXJFmvFxmY _003C_003E9 = new vFYQFnnHvNyOJSaBiBjXJFmvFxmY();

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

				internal int LDjdmKuIDHlwPPtQoDrxxpQLdKfIA(InputCategory P_0)
				{
					return P_0.id;
				}

				internal string ZddswDElgyoHjIKqzqbCyvDFGhAv(InputCategory P_0)
				{
					return P_0.name;
				}

				internal int tlidDHFIdJuofqEVSkPPeFXMwgYeb(InputCategory P_0, IList<InputCategory> P_1)
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

				internal int gNjNZCwHqDAWkDbOpzDnINLuKFNF(InputBehavior P_0)
				{
					return P_0.id;
				}

				internal string IlqOVZKWuDrCEQIgYXTZFNJHHAQu(InputBehavior P_0)
				{
					return P_0.name;
				}

				internal int RRQmsAsJMxaGhIwTmTGDYfWLdBtAA(InputBehavior P_0, IList<InputBehavior> P_1)
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

				internal int pOtYPTAtARdsRHUMVnNkbquxQgQy(InputAction P_0)
				{
					return P_0.id;
				}

				internal string AquNaEbxpCdSClWDsNeGDDqyAJkaA(InputAction P_0)
				{
					return P_0.name;
				}

				internal int NitVsmokebqFejybCKUGuCZgXpuP(InputAction P_0, IList<InputAction> P_1)
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

				internal int oRFbUqOJaxILbRJVoOaxUrucvYWG(InputMapCategory P_0)
				{
					return P_0.id;
				}

				internal string cOunYVraHgnLBcWeVEKZPCzHTaOw(InputMapCategory P_0)
				{
					return P_0.name;
				}

				internal int fbivVKZRdJsBxlXUjROSDAcuUAVf(InputMapCategory P_0, IList<InputMapCategory> P_1)
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

				internal int FwLHmPpDGFeCRBKiQZzYCorueIut(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string JFPeLurbkEqPaDDuqflDDEviJWIG(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int GQHhSjdxACrSgBSSVzOmHDxNoNaD(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int zocdXHaezHuVZFNEGaABNVJUliSUA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string zKVuQciIyuvJKmyOtRJuaMqYIggB(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int DdukPmNqvLbEsmFyNzDANKgWSSFJ(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int slicpxOxifawxbyddMRgrjWhOhuUA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string yOGbQpQMbYWqfFOFgAjtnsSGeatu(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int RxjMjEKBslBtplEVtufjkOlRhrQI(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int YIBZSiYpOFDWJytBqifpfGvlmCOS(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string aEWCAdzbsdNPpLsjROYdbTUamaux(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int oXbHidRIXJGFVbbexoZxCMCWsAcN(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int kKCeYZmPwXdUHUyvHdpliUDFSHth(CustomController_Editor P_0)
				{
					return P_0.id;
				}

				internal string hmKbtreEPiwDocaBQLdCIWpqjpSC(CustomController_Editor P_0)
				{
					return P_0.name;
				}

				internal int kdshwwhPHfVNpkZrSxevgVbmSCMR(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
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

				internal int ZbNjCvdCUmrUjxUvMplkCrZcELcX(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string lWXxNZpPtUGQWMhxuAmrVPCBkiNi(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int ZUMaNupGIJYXQLbChFhbBpifCSJtA(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
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

				internal int SnIQtbLDApFUVOTtTcffBHGlrYkG(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string wjyxwgQRFWfsVGDAogqOBcGHsnyj(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int jyFUhWubWxEqQPnkjbMBFbrkrCdX(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
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

				internal int dEkoSRBYTFeViijyvdnrcoWygUSAb(Player_Editor P_0)
				{
					return P_0.id;
				}

				internal string JGlAFsfMxoDWARtjtBYkmmhltsagA(Player_Editor P_0)
				{
					return P_0.name;
				}

				internal int AEKmCHzMKsBsyLaLhgMwHENDagFc(Player_Editor P_0, IList<Player_Editor> P_1)
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

				internal int GmyEtCEvbOJdicCkbOmaKWtnGKikB(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
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

				internal int jTTbhFKLqFCuMcFmynjpAteTdWQbA(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
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

				internal int HTsvXFRNLVWujUAUSZHraqLamSFL(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string xLjZAoaEdRpLDzutXKLHzKejZyHj(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int xRqSmgtEfLAqeMghzSFTGVeHBKKJ(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int hBPabdKpcUDDAaXFROiFVXZYRkVJ(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string YurcFWrWxeEjWIcXuBogOXeEwbCPA(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int cIrIdsOfVvUObGZchuNXfOKsTrGe(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int hTLuZYCsBXNAvbdHhoRwPBbBhvRq(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string eZvCuXopecLvyzlRZZadWCWhSfep(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int XrMbBxvSlHLcAdNBtEHvKgySjAEi(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int YIPwBsKWqqDgCGdYLzUReicAULHN(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string sYhFCQElVYOlWDmfkCjZMxQknHxaA(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int XDrAwNDaUGuVgXWNSdAfmlAvRdFO(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class mBUSXtSwBFHrTiJJmCIPmkwtuZnh
			{
				public UserData EpESGIPmcUFMzGnDpWsRlekExEOJ;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> qqBZnJEpBZNEtODTHbpvOKzPXQbD;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> ABPgpSAAdlnwthGvBvkzVgFpVcdCA;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> FgdAVOllySbKwcWqjtXmiwaiBtUAb;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> wTnoGsqSlYfCSEalbxtzgcwEHSuP;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> aqLJPVYjMmcytNvTAEhReBKyIqlLA;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> GVffiFBdYQDQguwIujmwIfTjOrnZA;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> rEjVGQFBimDwfferqZZIEXZGqqNk;

				public Func<ControllerType, List<tfhhvKrILJwRgzvYmSiFbeBSkARM>> TBhkaLerEKQptsbXHEaasNCYjkRfA;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> MLDhgOawKMWnYaMhSFExHelvSCbzA;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> euCFsCndFLsthjJDHAjrxwijsaJt;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> CcBdrllmKnSUDRmOMuIArJeZdJeq;

				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> XOLQjbkWdimEuQIkUaGrYhTPLztu;

				internal InputCategory hnUBXuhIJdIrbILMpkPpoMZtPcmPA(xYqbgJJDYgqlPUrubRRshNKKePtQA<InputCategory> P_0)
				{
					InputCategory inputCategory = JsonTools.Clone(P_0.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					InputCategory inputCategory2;
					if (P_0.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						inputCategory2 = P_0.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddActionCategory();
						inputCategory2 = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					inputCategory.id = inputCategory2.id;
					int index = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(inputCategory2);
					P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = inputCategory;
					return inputCategory;
				}

				internal InputBehavior vxcVMSKtnsOIhhLGUwfOhzDXzGIG(xYqbgJJDYgqlPUrubRRshNKKePtQA<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					InputBehavior inputBehavior2;
					if (P_0.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						inputBehavior2 = P_0.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddInputBehavior();
						inputBehavior2 = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(inputBehavior2);
					P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = inputBehavior;
					return inputBehavior;
				}

				internal InputAction EeZWoMHPqMaipoECBitbGXzgNjmOA(xYqbgJJDYgqlPUrubRRshNKKePtQA<InputAction> P_0)
				{
					UXXAYMfvJolsgCbquhzIscELaHWKA uXXAYMfvJolsgCbquhzIscELaHWKA = new UXXAYMfvJolsgCbquhzIscELaHWKA();
					uXXAYMfvJolsgCbquhzIscELaHWKA.PNyXcXAwuhDTcYmWteYiEFzCSdGh = P_0;
					InputAction inputAction = JsonTools.Clone(uXXAYMfvJolsgCbquhzIscELaHWKA.PNyXcXAwuhDTcYmWteYiEFzCSdGh.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					int num = qqBZnJEpBZNEtODTHbpvOKzPXQbD.Find(uXXAYMfvJolsgCbquhzIscELaHWKA.idcQSKNRBqnbrxPcMjlnyObypXLL)?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? 0;
					InputAction inputAction2;
					if (uXXAYMfvJolsgCbquhzIscELaHWKA.PNyXcXAwuhDTcYmWteYiEFzCSdGh.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						inputAction2 = uXXAYMfvJolsgCbquhzIscELaHWKA.PNyXcXAwuhDTcYmWteYiEFzCSdGh.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddAction(num);
						inputAction2 = uXXAYMfvJolsgCbquhzIscELaHWKA.PNyXcXAwuhDTcYmWteYiEFzCSdGh.gCzlHAIFruSyrDPyfTSXbPmbcLDX[uXXAYMfvJolsgCbquhzIscELaHWKA.PNyXcXAwuhDTcYmWteYiEFzCSdGh.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					int num2 = ABPgpSAAdlnwthGvBvkzVgFpVcdCA.Find(uXXAYMfvJolsgCbquhzIscELaHWKA.XoQFlmrCNxGjyeiLnIeKwOqhAuaLA)?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = num2;
					int index = uXXAYMfvJolsgCbquhzIscELaHWKA.PNyXcXAwuhDTcYmWteYiEFzCSdGh.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(inputAction2);
					uXXAYMfvJolsgCbquhzIscELaHWKA.PNyXcXAwuhDTcYmWteYiEFzCSdGh.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = inputAction;
					return inputAction;
				}

				internal InputLayout fJHrkKXldkgCOhoEknHrwswEZZpf(xYqbgJJDYgqlPUrubRRshNKKePtQA<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					InputLayout inputLayout2;
					if (P_0.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						inputLayout2 = P_0.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddKeyboardLayout();
						inputLayout2 = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(inputLayout2);
					P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout FLgKCdpQjrIpKgWINhkPLvzOmNqEA(xYqbgJJDYgqlPUrubRRshNKKePtQA<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					InputLayout inputLayout2;
					if (P_0.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						inputLayout2 = P_0.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddMouseLayout();
						inputLayout2 = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(inputLayout2);
					P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout PMWFSQqsfXysZnSTXbnkASpTqoLN(xYqbgJJDYgqlPUrubRRshNKKePtQA<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					InputLayout inputLayout2;
					if (P_0.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						inputLayout2 = P_0.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddJoystickLayout();
						inputLayout2 = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(inputLayout2);
					P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout tIZvSNApCazJZQcabQSbYNfVFejG(xYqbgJJDYgqlPUrubRRshNKKePtQA<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					InputLayout inputLayout2;
					if (P_0.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						inputLayout2 = P_0.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddCustomControllerLayout();
						inputLayout2 = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(inputLayout2);
					P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = inputLayout;
					return inputLayout;
				}

				internal List<tfhhvKrILJwRgzvYmSiFbeBSkARM> ffOEqXafxxlqjAckNXBCRnhIYLAO(ControllerType P_0)
				{
					return P_0 switch
					{
						ControllerType.Keyboard => FgdAVOllySbKwcWqjtXmiwaiBtUAb, 
						ControllerType.Mouse => wTnoGsqSlYfCSEalbxtzgcwEHSuP, 
						ControllerType.Joystick => aqLJPVYjMmcytNvTAEhReBKyIqlLA, 
						ControllerType.Custom => GVffiFBdYQDQguwIujmwIfTjOrnZA, 
						_ => throw new NotImplementedException(), 
					};
				}

				internal CustomController_Editor vkxlcrRlcdhWfVqXtBDrDhmwqyAPA(xYqbgJJDYgqlPUrubRRshNKKePtQA<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					CustomController_Editor customController_Editor2;
					if (P_0.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						customController_Editor2 = P_0.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddCustomController();
						customController_Editor2 = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(customController_Editor2);
					P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = customController_Editor;
					return customController_Editor;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor jQJcUCJhoearglgmlKMkbmjrDrydA(xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					bhTDTeCHZAkJjbcbcZcnCXMwLeqE bhTDTeCHZAkJjbcbcZcnCXMwLeqE2 = new bhTDTeCHZAkJjbcbcZcnCXMwLeqE();
					bhTDTeCHZAkJjbcbcZcnCXMwLeqE2.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(bhTDTeCHZAkJjbcbcZcnCXMwLeqE2.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
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
							INkLBGSqvwFAsgFgpVRTRugnLCRgA nkLBGSqvwFAsgFgpVRTRugnLCRgA = new INkLBGSqvwFAsgFgpVRTRugnLCRgA();
							nkLBGSqvwFAsgFgpVRTRugnLCRgA.QyqwGsEnoyNGHQEmWHUBEqhBFpHDA = bhTDTeCHZAkJjbcbcZcnCXMwLeqE2;
							nkLBGSqvwFAsgFgpVRTRugnLCRgA.uFxluvjSBxunDNeBQErdcDJuhFud = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = rEjVGQFBimDwfferqZZIEXZGqqNk.Find(nkLBGSqvwFAsgFgpVRTRugnLCRgA.ixJUGYUOrDcICEmjVvifgjaGmfwGb);
							if (tfhhvKrILJwRgzvYmSiFbeBSkARM2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + nkLBGSqvwFAsgFgpVRTRugnLCRgA.uFxluvjSBxunDNeBQErdcDJuhFud);
							}
							else
							{
								list.Add(tfhhvKrILJwRgzvYmSiFbeBSkARM2.vFJRRzbpxRVPLshHPxFeASCuVkul);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						apgkymrGdPuRsphckrEkcUjWugUl apgkymrGdPuRsphckrEkcUjWugUl2 = new apgkymrGdPuRsphckrEkcUjWugUl();
						apgkymrGdPuRsphckrEkcUjWugUl2.ppGlklkqfCEncJhwYJnrDBSidICP = bhTDTeCHZAkJjbcbcZcnCXMwLeqE2;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<tfhhvKrILJwRgzvYmSiFbeBSkARM> list2 = TBhkaLerEKQptsbXHEaasNCYjkRfA(controllerType);
							apgkymrGdPuRsphckrEkcUjWugUl2.ooXBoMceDBtHVsOjkGeHlXRvoKNx = controllerMapLayoutManager_Rule_Editor2.layoutId;
							tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = list2.Find(apgkymrGdPuRsphckrEkcUjWugUl2.FLtxDUgoOvYlTDbMUAkgdvYgqjESA);
							if (tfhhvKrILJwRgzvYmSiFbeBSkARM3 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + apgkymrGdPuRsphckrEkcUjWugUl2.ooXBoMceDBtHVsOjkGeHlXRvoKNx);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = tfhhvKrILJwRgzvYmSiFbeBSkARM3.vFJRRzbpxRVPLshHPxFeASCuVkul;
							}
						}
					}
					int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							davUjobXmrnQigaURGCIkdDLXrdq davUjobXmrnQigaURGCIkdDLXrdq2 = new davUjobXmrnQigaURGCIkdDLXrdq();
							davUjobXmrnQigaURGCIkdDLXrdq2.fJWdorJdYoyhmHKCAmNScqIrynIPA = bhTDTeCHZAkJjbcbcZcnCXMwLeqE2;
							List<tfhhvKrILJwRgzvYmSiFbeBSkARM> mLDhgOawKMWnYaMhSFExHelvSCbzA = MLDhgOawKMWnYaMhSFExHelvSCbzA;
							davUjobXmrnQigaURGCIkdDLXrdq2.TWbpEpFwynUHYhwPUlZbJtsRKiPv = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM4 = mLDhgOawKMWnYaMhSFExHelvSCbzA.Find(davUjobXmrnQigaURGCIkdDLXrdq2.slfYRVEtMTuUwpVaWSwRrajtPJrj);
							if (tfhhvKrILJwRgzvYmSiFbeBSkARM4 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + davUjobXmrnQigaURGCIkdDLXrdq2.TWbpEpFwynUHYhwPUlZbJtsRKiPv);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = tfhhvKrILJwRgzvYmSiFbeBSkARM4.vFJRRzbpxRVPLshHPxFeASCuVkul;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (bhTDTeCHZAkJjbcbcZcnCXMwLeqE2.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = bhTDTeCHZAkJjbcbcZcnCXMwLeqE2.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = bhTDTeCHZAkJjbcbcZcnCXMwLeqE2.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA.gCzlHAIFruSyrDPyfTSXbPmbcLDX[bhTDTeCHZAkJjbcbcZcnCXMwLeqE2.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = bhTDTeCHZAkJjbcbcZcnCXMwLeqE2.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					bhTDTeCHZAkJjbcbcZcnCXMwLeqE2.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				internal ControllerMapEnabler_RuleSet_Editor NCUtcaLNjwiyuXqnorNDKBYMfIZr(xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					uWjBZPhIyPCVocFKFRBEwUuuZpNnb uWjBZPhIyPCVocFKFRBEwUuuZpNnb2 = new uWjBZPhIyPCVocFKFRBEwUuuZpNnb();
					uWjBZPhIyPCVocFKFRBEwUuuZpNnb2.RFNJlDxykkaCufEyTPXhskmvyyKj = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(uWjBZPhIyPCVocFKFRBEwUuuZpNnb2.RFNJlDxykkaCufEyTPXhskmvyyKj.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
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
							ONyqEvLYJpCyDSEIfuUOKThGsyCm oNyqEvLYJpCyDSEIfuUOKThGsyCm = new ONyqEvLYJpCyDSEIfuUOKThGsyCm();
							oNyqEvLYJpCyDSEIfuUOKThGsyCm.hjAGMiyErDGvtJKiASKKuzLXBCKQ = uWjBZPhIyPCVocFKFRBEwUuuZpNnb2;
							oNyqEvLYJpCyDSEIfuUOKThGsyCm.QDtnCdILeVaByTkZBAQWvKlybMvaA = controllerMapEnabler_Rule_Editor.categoryIds[j];
							tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = rEjVGQFBimDwfferqZZIEXZGqqNk.Find(oNyqEvLYJpCyDSEIfuUOKThGsyCm.ormAiYyRAqfunNzqiXkOJIBbDKPc);
							if (tfhhvKrILJwRgzvYmSiFbeBSkARM2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + oNyqEvLYJpCyDSEIfuUOKThGsyCm.QDtnCdILeVaByTkZBAQWvKlybMvaA);
							}
							else
							{
								list.Add(tfhhvKrILJwRgzvYmSiFbeBSkARM2.vFJRRzbpxRVPLshHPxFeASCuVkul);
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
						List<tfhhvKrILJwRgzvYmSiFbeBSkARM> list2 = TBhkaLerEKQptsbXHEaasNCYjkRfA(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							yxNJACIYWnNrXLWNTGSIqXCkQlYw yxNJACIYWnNrXLWNTGSIqXCkQlYw2 = new yxNJACIYWnNrXLWNTGSIqXCkQlYw();
							yxNJACIYWnNrXLWNTGSIqXCkQlYw2.kMKBGLKVCwKLouqhRVOdbvjdNNbc = uWjBZPhIyPCVocFKFRBEwUuuZpNnb2;
							yxNJACIYWnNrXLWNTGSIqXCkQlYw2.jFtffSeoIdPZvbqyvzsrboVpdNmGA = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = list2.Find(yxNJACIYWnNrXLWNTGSIqXCkQlYw2.SxImxflfCTJKGagKAJorxTcUUhCj);
							if (tfhhvKrILJwRgzvYmSiFbeBSkARM3 == null)
							{
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + yxNJACIYWnNrXLWNTGSIqXCkQlYw2.jFtffSeoIdPZvbqyvzsrboVpdNmGA);
							}
							else
							{
								list3.Add(tfhhvKrILJwRgzvYmSiFbeBSkARM3.vFJRRzbpxRVPLshHPxFeASCuVkul);
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
							fpqPgrABBZvsXnBSHCICZYmvmFes fpqPgrABBZvsXnBSHCICZYmvmFes2 = new fpqPgrABBZvsXnBSHCICZYmvmFes();
							fpqPgrABBZvsXnBSHCICZYmvmFes2.OelvsAUDrFDSEZcPGfRDIvZMPtrD = uWjBZPhIyPCVocFKFRBEwUuuZpNnb2;
							List<tfhhvKrILJwRgzvYmSiFbeBSkARM> mLDhgOawKMWnYaMhSFExHelvSCbzA = MLDhgOawKMWnYaMhSFExHelvSCbzA;
							fpqPgrABBZvsXnBSHCICZYmvmFes2.HjtmgsKAYHTHLjHCIRoEQSTFpqX = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM4 = mLDhgOawKMWnYaMhSFExHelvSCbzA.Find(fpqPgrABBZvsXnBSHCICZYmvmFes2.fDKjGHATbESjcKblMZtyekOkYBfi);
							if (tfhhvKrILJwRgzvYmSiFbeBSkARM4 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + fpqPgrABBZvsXnBSHCICZYmvmFes2.HjtmgsKAYHTHLjHCIRoEQSTFpqX);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = tfhhvKrILJwRgzvYmSiFbeBSkARM4.vFJRRzbpxRVPLshHPxFeASCuVkul;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (uWjBZPhIyPCVocFKFRBEwUuuZpNnb2.RFNJlDxykkaCufEyTPXhskmvyyKj.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						controllerMapEnabler_RuleSet_Editor2 = uWjBZPhIyPCVocFKFRBEwUuuZpNnb2.RFNJlDxykkaCufEyTPXhskmvyyKj.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = uWjBZPhIyPCVocFKFRBEwUuuZpNnb2.RFNJlDxykkaCufEyTPXhskmvyyKj.gCzlHAIFruSyrDPyfTSXbPmbcLDX[uWjBZPhIyPCVocFKFRBEwUuuZpNnb2.RFNJlDxykkaCufEyTPXhskmvyyKj.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = uWjBZPhIyPCVocFKFRBEwUuuZpNnb2.RFNJlDxykkaCufEyTPXhskmvyyKj.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					uWjBZPhIyPCVocFKFRBEwUuuZpNnb2.RFNJlDxykkaCufEyTPXhskmvyyKj.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				internal Player_Editor sKXdQGEsveHjjCkMjzhEDgxUeabNb(xYqbgJJDYgqlPUrubRRshNKKePtQA<Player_Editor> P_0)
				{
					TfPHAiNexRHRBKSTNmhNzQkifmeX tfPHAiNexRHRBKSTNmhNzQkifmeX = new TfPHAiNexRHRBKSTNmhNzQkifmeX();
					tfPHAiNexRHRBKSTNmhNzQkifmeX.RbLgzOgrUbpDVNZMryWRWnsljOzF = this;
					tfPHAiNexRHRBKSTNmhNzQkifmeX.bqiqdiCMnDfAeuoDgCUyDjAvCysLA = P_0;
					Player_Editor player_Editor = JsonTools.Clone(tfPHAiNexRHRBKSTNmhNzQkifmeX.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					Action<List<Player_Editor.Mapping>, List<tfhhvKrILJwRgzvYmSiFbeBSkARM>> action = tfPHAiNexRHRBKSTNmhNzQkifmeX.lLXYyKaMDoLiCaatTHRlZcYIDIdiA;
					action(player_Editor.defaultKeyboardMaps, FgdAVOllySbKwcWqjtXmiwaiBtUAb);
					action(player_Editor.defaultMouseMaps, wTnoGsqSlYfCSEalbxtzgcwEHSuP);
					action(player_Editor.defaultJoystickMaps, aqLJPVYjMmcytNvTAEhReBKyIqlLA);
					action(player_Editor.defaultCustomControllerMaps, GVffiFBdYQDQguwIujmwIfTjOrnZA);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						gVqAHPhpbLlaGPrBPBYTRvReqrDkA gVqAHPhpbLlaGPrBPBYTRvReqrDkA2 = new gVqAHPhpbLlaGPrBPBYTRvReqrDkA();
						gVqAHPhpbLlaGPrBPBYTRvReqrDkA2.DvTkNzbqkCRDnxsWIkYBpiauTUoe = tfPHAiNexRHRBKSTNmhNzQkifmeX;
						gVqAHPhpbLlaGPrBPBYTRvReqrDkA2.KehNcObUTmMdiFwHrabRTyJIKjOH = player_Editor.startingCustomControllers[i];
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = MLDhgOawKMWnYaMhSFExHelvSCbzA.Find(gVqAHPhpbLlaGPrBPBYTRvReqrDkA2.RXmGIJkyXANLwWmfpWAqdKwUewKBA);
						gVqAHPhpbLlaGPrBPBYTRvReqrDkA2.KehNcObUTmMdiFwHrabRTyJIKjOH.sourceId = tfhhvKrILJwRgzvYmSiFbeBSkARM2?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						qkvhJVQxbHmQUIOMDXlElzHuuMtr qkvhJVQxbHmQUIOMDXlElzHuuMtr2 = new qkvhJVQxbHmQUIOMDXlElzHuuMtr();
						qkvhJVQxbHmQUIOMDXlElzHuuMtr2.ntfTKoLIlBIpzcnmhcddvlQYuzQM = tfPHAiNexRHRBKSTNmhNzQkifmeX;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							qkvhJVQxbHmQUIOMDXlElzHuuMtr2.UibpzJNHztwryWRLJaklPfBzhAZR = ruleSetMapping.id;
							tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = euCFsCndFLsthjJDHAjrxwijsaJt.Find(qkvhJVQxbHmQUIOMDXlElzHuuMtr2.epoJbmSlkIybnCyshWLuOBCJjVL);
							if (tfhhvKrILJwRgzvYmSiFbeBSkARM3 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + qkvhJVQxbHmQUIOMDXlElzHuuMtr2.UibpzJNHztwryWRLJaklPfBzhAZR);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = tfhhvKrILJwRgzvYmSiFbeBSkARM3.vFJRRzbpxRVPLshHPxFeASCuVkul;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						rgExEnpsKUcmckKXKTYSDwRXaovH rgExEnpsKUcmckKXKTYSDwRXaovH2 = new rgExEnpsKUcmckKXKTYSDwRXaovH();
						rgExEnpsKUcmckKXKTYSDwRXaovH2.UEsifpFlkupdljWRhLCwwmBeRUrWB = tfPHAiNexRHRBKSTNmhNzQkifmeX;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							rgExEnpsKUcmckKXKTYSDwRXaovH2.JPLJaGbRuDUkJhQRCWxGyjBVunSE = ruleSetMapping2.id;
							tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM4 = CcBdrllmKnSUDRmOMuIArJeZdJeq.Find(rgExEnpsKUcmckKXKTYSDwRXaovH2.yFClslnjvHISjhCvkgdCmwOFyulu);
							if (tfhhvKrILJwRgzvYmSiFbeBSkARM4 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + rgExEnpsKUcmckKXKTYSDwRXaovH2.JPLJaGbRuDUkJhQRCWxGyjBVunSE);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = tfhhvKrILJwRgzvYmSiFbeBSkARM4.vFJRRzbpxRVPLshHPxFeASCuVkul;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (tfPHAiNexRHRBKSTNmhNzQkifmeX.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						player_Editor2 = tfPHAiNexRHRBKSTNmhNzQkifmeX.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.qesshvxokjrtrYTsLtduhtxZhwaP;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.GmyEtCEvbOJdicCkbOmaKWtnGKikB;
						zgwQXfwjgjVPlVVztJjbmSImSotw(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						zgwQXfwjgjVPlVVztJjbmSImSotw(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						zgwQXfwjgjVPlVVztJjbmSImSotw(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						zgwQXfwjgjVPlVVztJjbmSImSotw(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						zgwQXfwjgjVPlVVztJjbmSImSotw(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.jTTbhFKLqFCuMcFmynjpAteTdWQbA);
						player_Editor = player_Editor3;
					}
					else
					{
						EpESGIPmcUFMzGnDpWsRlekExEOJ.AddPlayer();
						player_Editor2 = tfPHAiNexRHRBKSTNmhNzQkifmeX.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.gCzlHAIFruSyrDPyfTSXbPmbcLDX[tfPHAiNexRHRBKSTNmhNzQkifmeX.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = tfPHAiNexRHRBKSTNmhNzQkifmeX.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(player_Editor2);
					tfPHAiNexRHRBKSTNmhNzQkifmeX.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = player_Editor;
					return player_Editor;
				}
			}

			private sealed class UXXAYMfvJolsgCbquhzIscELaHWKA
			{
				public xYqbgJJDYgqlPUrubRRshNKKePtQA<InputAction> PNyXcXAwuhDTcYmWteYiEFzCSdGh;

				internal bool idcQSKNRBqnbrxPcMjlnyObypXLL(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(PNyXcXAwuhDTcYmWteYiEFzCSdGh.KCiEkNdEgbYOfGZndQVftTXvupPiA) == PNyXcXAwuhDTcYmWteYiEFzCSdGh.QrbicxKYbNtQHkRZnPyPBhRJqhhi.categoryId;
				}

				internal bool XoQFlmrCNxGjyeiLnIeKwOqhAuaLA(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(PNyXcXAwuhDTcYmWteYiEFzCSdGh.KCiEkNdEgbYOfGZndQVftTXvupPiA) == PNyXcXAwuhDTcYmWteYiEFzCSdGh.QrbicxKYbNtQHkRZnPyPBhRJqhhi.behaviorId;
				}
			}

			private sealed class yxNJACIYWnNrXLWNTGSIqXCkQlYw
			{
				public int jFtffSeoIdPZvbqyvzsrboVpdNmGA;

				public uWjBZPhIyPCVocFKFRBEwUuuZpNnb kMKBGLKVCwKLouqhRVOdbvjdNNbc;

				internal bool SxImxflfCTJKGagKAJorxTcUUhCj(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(kMKBGLKVCwKLouqhRVOdbvjdNNbc.RFNJlDxykkaCufEyTPXhskmvyyKj.KCiEkNdEgbYOfGZndQVftTXvupPiA) == jFtffSeoIdPZvbqyvzsrboVpdNmGA;
				}
			}

			private sealed class fpqPgrABBZvsXnBSHCICZYmvmFes
			{
				public int HjtmgsKAYHTHLjHCIRoEQSTFpqX;

				public uWjBZPhIyPCVocFKFRBEwUuuZpNnb OelvsAUDrFDSEZcPGfRDIvZMPtrD;

				internal bool fDKjGHATbESjcKblMZtyekOkYBfi(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(OelvsAUDrFDSEZcPGfRDIvZMPtrD.RFNJlDxykkaCufEyTPXhskmvyyKj.KCiEkNdEgbYOfGZndQVftTXvupPiA) == HjtmgsKAYHTHLjHCIRoEQSTFpqX;
				}
			}

			private sealed class TfPHAiNexRHRBKSTNmhNzQkifmeX
			{
				public xYqbgJJDYgqlPUrubRRshNKKePtQA<Player_Editor> bqiqdiCMnDfAeuoDgCUyDjAvCysLA;

				public mBUSXtSwBFHrTiJJmCIPmkwtuZnh RbLgzOgrUbpDVNZMryWRWnsljOzF;

				internal void lLXYyKaMDoLiCaatTHRlZcYIDIdiA(List<Player_Editor.Mapping> P_0, List<tfhhvKrILJwRgzvYmSiFbeBSkARM> P_1)
				{
					for (int i = 0; i < P_0.Count; i++)
					{
						ClTIaHwiUQtnjYwSphlnFiMxAJwEA clTIaHwiUQtnjYwSphlnFiMxAJwEA = new ClTIaHwiUQtnjYwSphlnFiMxAJwEA();
						clTIaHwiUQtnjYwSphlnFiMxAJwEA.IGFxFnKEFZaeAviKsSWVbRcsRvzH = this;
						clTIaHwiUQtnjYwSphlnFiMxAJwEA.SpCXZyksLVSmcPYLjFjzzDPwUGdu = P_0[i];
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = RbLgzOgrUbpDVNZMryWRWnsljOzF.rEjVGQFBimDwfferqZZIEXZGqqNk.Find(clTIaHwiUQtnjYwSphlnFiMxAJwEA.ZDorTnnsBiIGijOToLFNGFGJDHsKA);
						clTIaHwiUQtnjYwSphlnFiMxAJwEA.SpCXZyksLVSmcPYLjFjzzDPwUGdu.categoryId = tfhhvKrILJwRgzvYmSiFbeBSkARM2?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
						tfhhvKrILJwRgzvYmSiFbeBSkARM2 = P_1.Find(clTIaHwiUQtnjYwSphlnFiMxAJwEA.LQrPirCDtwAccMFLZoUqKyBGJHom);
						clTIaHwiUQtnjYwSphlnFiMxAJwEA.SpCXZyksLVSmcPYLjFjzzDPwUGdu.layoutId = tfhhvKrILJwRgzvYmSiFbeBSkARM2?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					}
				}
			}

			private sealed class ClTIaHwiUQtnjYwSphlnFiMxAJwEA
			{
				public Player_Editor.Mapping SpCXZyksLVSmcPYLjFjzzDPwUGdu;

				public TfPHAiNexRHRBKSTNmhNzQkifmeX IGFxFnKEFZaeAviKsSWVbRcsRvzH;

				internal bool ZDorTnnsBiIGijOToLFNGFGJDHsKA(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(IGFxFnKEFZaeAviKsSWVbRcsRvzH.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == SpCXZyksLVSmcPYLjFjzzDPwUGdu.categoryId;
				}

				internal bool LQrPirCDtwAccMFLZoUqKyBGJHom(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(IGFxFnKEFZaeAviKsSWVbRcsRvzH.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == SpCXZyksLVSmcPYLjFjzzDPwUGdu.layoutId;
				}
			}

			private sealed class gVqAHPhpbLlaGPrBPBYTRvReqrDkA
			{
				public Player_Editor.CreateControllerInfo KehNcObUTmMdiFwHrabRTyJIKjOH;

				public TfPHAiNexRHRBKSTNmhNzQkifmeX DvTkNzbqkCRDnxsWIkYBpiauTUoe;

				internal bool RXmGIJkyXANLwWmfpWAqdKwUewKBA(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(DvTkNzbqkCRDnxsWIkYBpiauTUoe.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == KehNcObUTmMdiFwHrabRTyJIKjOH.sourceId;
				}
			}

			private sealed class qkvhJVQxbHmQUIOMDXlElzHuuMtr
			{
				public int UibpzJNHztwryWRLJaklPfBzhAZR;

				public TfPHAiNexRHRBKSTNmhNzQkifmeX ntfTKoLIlBIpzcnmhcddvlQYuzQM;

				internal bool epoJbmSlkIybnCyshWLuOBCJjVL(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(ntfTKoLIlBIpzcnmhcddvlQYuzQM.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == UibpzJNHztwryWRLJaklPfBzhAZR;
				}
			}

			private sealed class rgExEnpsKUcmckKXKTYSDwRXaovH
			{
				public int JPLJaGbRuDUkJhQRCWxGyjBVunSE;

				public TfPHAiNexRHRBKSTNmhNzQkifmeX UEsifpFlkupdljWRhLCwwmBeRUrWB;

				internal bool yFClslnjvHISjhCvkgdCmwOFyulu(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(UEsifpFlkupdljWRhLCwwmBeRUrWB.bqiqdiCMnDfAeuoDgCUyDjAvCysLA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == JPLJaGbRuDUkJhQRCWxGyjBVunSE;
				}
			}

			private sealed class EvMhaLZFHITMIGZNruEwYJnBhMAX
			{
				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> HryhAnuaZVNOAGKSgflZeeNlblEf;

				public mBUSXtSwBFHrTiJJmCIPmkwtuZnh GlMEwQaJYnJwqcZqsuaiEwFBXzprB;

				internal int xFucZqGFCxXocfgtwCsqaGTLylXr(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					hRPZDBekTgOOQbiRmMEgppntwsLL hRPZDBekTgOOQbiRmMEgppntwsLL2 = new hRPZDBekTgOOQbiRmMEgppntwsLL();
					hRPZDBekTgOOQbiRmMEgppntwsLL2.hKbsUBYiQKzhjGcVCxTYZGCMnNyk = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = GlMEwQaJYnJwqcZqsuaiEwFBXzprB.rEjVGQFBimDwfferqZZIEXZGqqNk.Find(hRPZDBekTgOOQbiRmMEgppntwsLL2.GYqxYdUUcrPWmoGgADbUyKTTXXgl);
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = HryhAnuaZVNOAGKSgflZeeNlblEf.Find(hRPZDBekTgOOQbiRmMEgppntwsLL2.ESgUmOgSVbebBlmKgWTPidElxXlu);
						if (tfhhvKrILJwRgzvYmSiFbeBSkARM2 != null && tfhhvKrILJwRgzvYmSiFbeBSkARM2.vFJRRzbpxRVPLshHPxFeASCuVkul == P_1[i].categoryId && tfhhvKrILJwRgzvYmSiFbeBSkARM3 != null && tfhhvKrILJwRgzvYmSiFbeBSkARM3.vFJRRzbpxRVPLshHPxFeASCuVkul == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor xoGVkNzuuFktOVSfnGZxdaiUVtiD(xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMap_Editor> P_0)
				{
					MsBdasZsTtALARXugcuZGWeKBlmgb msBdasZsTtALARXugcuZGWeKBlmgb = new MsBdasZsTtALARXugcuZGWeKBlmgb();
					msBdasZsTtALARXugcuZGWeKBlmgb.nhLOaYcNVKqdvimuAsCjheLxKUug = P_0;
					msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir = JsonTools.Clone(msBdasZsTtALARXugcuZGWeKBlmgb.nhLOaYcNVKqdvimuAsCjheLxKUug.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = GlMEwQaJYnJwqcZqsuaiEwFBXzprB.rEjVGQFBimDwfferqZZIEXZGqqNk.Find(msBdasZsTtALARXugcuZGWeKBlmgb.xlGwBJvGhwEsfIjvohxfNPpyatlFb);
					tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = HryhAnuaZVNOAGKSgflZeeNlblEf.Find(msBdasZsTtALARXugcuZGWeKBlmgb.egpeqKNTjgCtuinFLVjgfHaovkFL);
					msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir.categoryId = tfhhvKrILJwRgzvYmSiFbeBSkARM2?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir.layoutId = tfhhvKrILJwRgzvYmSiFbeBSkARM3?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					for (int i = 0; i < msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir.actionElementMaps.Count; i++)
					{
						hWAsGnCvbWGjFQZdmBPRvfeqfypl hWAsGnCvbWGjFQZdmBPRvfeqfypl2 = new hWAsGnCvbWGjFQZdmBPRvfeqfypl();
						hWAsGnCvbWGjFQZdmBPRvfeqfypl2.CNlFYCPZuUFKEKLMCqlVIqQwmhlX = msBdasZsTtALARXugcuZGWeKBlmgb;
						hWAsGnCvbWGjFQZdmBPRvfeqfypl2.ucCADwITZyMhOhwvcGxshxRadSKHE = hWAsGnCvbWGjFQZdmBPRvfeqfypl2.CNlFYCPZuUFKEKLMCqlVIqQwmhlX.uOrUFcUCwHskIqpCFXMRKrKefWir.actionElementMaps[i];
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM4 = GlMEwQaJYnJwqcZqsuaiEwFBXzprB.XOLQjbkWdimEuQIkUaGrYhTPLztu.Find(hWAsGnCvbWGjFQZdmBPRvfeqfypl2.gSafMZmSFaJCZlqteFaJbIVLOkQi);
						hWAsGnCvbWGjFQZdmBPRvfeqfypl2.ucCADwITZyMhOhwvcGxshxRadSKHE._actionId = tfhhvKrILJwRgzvYmSiFbeBSkARM4?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
						hWAsGnCvbWGjFQZdmBPRvfeqfypl2.ucCADwITZyMhOhwvcGxshxRadSKHE._actionCategoryId = ((GlMEwQaJYnJwqcZqsuaiEwFBXzprB.EpESGIPmcUFMzGnDpWsRlekExEOJ.GetActionById(hWAsGnCvbWGjFQZdmBPRvfeqfypl2.ucCADwITZyMhOhwvcGxshxRadSKHE._actionId) != null) ? GlMEwQaJYnJwqcZqsuaiEwFBXzprB.EpESGIPmcUFMzGnDpWsRlekExEOJ.GetActionById(hWAsGnCvbWGjFQZdmBPRvfeqfypl2.ucCADwITZyMhOhwvcGxshxRadSKHE._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (msBdasZsTtALARXugcuZGWeKBlmgb.nhLOaYcNVKqdvimuAsCjheLxKUug.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						controllerMap_Editor = msBdasZsTtALARXugcuZGWeKBlmgb.nhLOaYcNVKqdvimuAsCjheLxKUug.qesshvxokjrtrYTsLtduhtxZhwaP;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.xRqSmgtEfLAqeMghzSFTGVeHBKKJ;
						zgwQXfwjgjVPlVVztJjbmSImSotw(controllerMap_Editor.actionElementMaps, msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir = controllerMap_Editor2;
					}
					else
					{
						GlMEwQaJYnJwqcZqsuaiEwFBXzprB.EpESGIPmcUFMzGnDpWsRlekExEOJ.CreateKeyboardMap(msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir.categoryId, msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir.layoutId);
						controllerMap_Editor = msBdasZsTtALARXugcuZGWeKBlmgb.nhLOaYcNVKqdvimuAsCjheLxKUug.gCzlHAIFruSyrDPyfTSXbPmbcLDX[msBdasZsTtALARXugcuZGWeKBlmgb.nhLOaYcNVKqdvimuAsCjheLxKUug.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir.id = controllerMap_Editor.id;
					int index = msBdasZsTtALARXugcuZGWeKBlmgb.nhLOaYcNVKqdvimuAsCjheLxKUug.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(controllerMap_Editor);
					msBdasZsTtALARXugcuZGWeKBlmgb.nhLOaYcNVKqdvimuAsCjheLxKUug.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir;
					return msBdasZsTtALARXugcuZGWeKBlmgb.uOrUFcUCwHskIqpCFXMRKrKefWir;
				}
			}

			private sealed class hRPZDBekTgOOQbiRmMEgppntwsLL
			{
				public ControllerMap_Editor hKbsUBYiQKzhjGcVCxTYZGCMnNyk;

				public Predicate<tfhhvKrILJwRgzvYmSiFbeBSkARM> bZIjjnVdNHCvTVGhqqNasTMNZeah;

				public Predicate<tfhhvKrILJwRgzvYmSiFbeBSkARM> AYCoErjTRRDsFFDeUiQJlPajBQtB;

				internal bool GYqxYdUUcrPWmoGgADbUyKTTXXgl(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.gVzHnxHomYJAyjxzmqUYZIjrHEER == hKbsUBYiQKzhjGcVCxTYZGCMnNyk.categoryId;
				}

				internal bool ESgUmOgSVbebBlmKgWTPidElxXlu(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.gVzHnxHomYJAyjxzmqUYZIjrHEER == hKbsUBYiQKzhjGcVCxTYZGCMnNyk.layoutId;
				}
			}

			private sealed class MsBdasZsTtALARXugcuZGWeKBlmgb
			{
				public xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMap_Editor> nhLOaYcNVKqdvimuAsCjheLxKUug;

				public ControllerMap_Editor uOrUFcUCwHskIqpCFXMRKrKefWir;

				internal bool xlGwBJvGhwEsfIjvohxfNPpyatlFb(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(nhLOaYcNVKqdvimuAsCjheLxKUug.KCiEkNdEgbYOfGZndQVftTXvupPiA) == uOrUFcUCwHskIqpCFXMRKrKefWir.categoryId;
				}

				internal bool egpeqKNTjgCtuinFLVjgfHaovkFL(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(nhLOaYcNVKqdvimuAsCjheLxKUug.KCiEkNdEgbYOfGZndQVftTXvupPiA) == uOrUFcUCwHskIqpCFXMRKrKefWir.layoutId;
				}
			}

			private sealed class QznikMCqZmkGITXGRauBhecwxHGs
			{
				public List<int> HeHzAbDbVNJTnNjerJmgyNcAlWtb;

				public mBUSXtSwBFHrTiJJmCIPmkwtuZnh EJmJDuvPejIIxgErPfsRTdpPqALab;

				internal InputMapCategory iaIZXKCcPQfCjrcwXdcQsummErZy(xYqbgJJDYgqlPUrubRRshNKKePtQA<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					InputMapCategory inputMapCategory2;
					if (P_0.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						inputMapCategory2 = P_0.qesshvxokjrtrYTsLtduhtxZhwaP;
					}
					else
					{
						EJmJDuvPejIIxgErPfsRTdpPqALab.EpESGIPmcUFMzGnDpWsRlekExEOJ.AddMapCategory();
						inputMapCategory2 = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					int num = P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(inputMapCategory2);
					if (P_0.KCiEkNdEgbYOfGZndQVftTXvupPiA == tfhhvKrILJwRgzvYmSiFbeBSkARM.PFIodniGImNxQYQcwvbMOpIpErUc.otherId)
					{
						HeHzAbDbVNJTnNjerJmgyNcAlWtb.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.gCzlHAIFruSyrDPyfTSXbPmbcLDX[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class hWAsGnCvbWGjFQZdmBPRvfeqfypl
			{
				public ActionElementMap ucCADwITZyMhOhwvcGxshxRadSKHE;

				public MsBdasZsTtALARXugcuZGWeKBlmgb CNlFYCPZuUFKEKLMCqlVIqQwmhlX;

				internal bool gSafMZmSFaJCZlqteFaJbIVLOkQi(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(CNlFYCPZuUFKEKLMCqlVIqQwmhlX.nhLOaYcNVKqdvimuAsCjheLxKUug.KCiEkNdEgbYOfGZndQVftTXvupPiA) == ucCADwITZyMhOhwvcGxshxRadSKHE._actionId;
				}
			}

			private sealed class zzhrABdEBfMJxuDQOlYQlaiOcGBW
			{
				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> DgpaQdJklNzLovbxGjYRCguoPZSi;

				public mBUSXtSwBFHrTiJJmCIPmkwtuZnh UQwVFLQxQUNwJWQMAnxLIhpBbkSU;

				internal int dQzSrbHhuifYLFkRlpNiwjsDPxQt(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					cyfawbUDiRQhhqesiPbCkisCONXk cyfawbUDiRQhhqesiPbCkisCONXk2 = new cyfawbUDiRQhhqesiPbCkisCONXk();
					cyfawbUDiRQhhqesiPbCkisCONXk2.AygZaYMKXGAicknflGLjemMVbMgW = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = UQwVFLQxQUNwJWQMAnxLIhpBbkSU.rEjVGQFBimDwfferqZZIEXZGqqNk.Find(cyfawbUDiRQhhqesiPbCkisCONXk2.eAwkBWXdhrGmvjaMKIlwzQgaovOAA);
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = DgpaQdJklNzLovbxGjYRCguoPZSi.Find(cyfawbUDiRQhhqesiPbCkisCONXk2.GbIhUrlhazHlNzYXgMbDyWlfrog);
						if (tfhhvKrILJwRgzvYmSiFbeBSkARM2 != null && tfhhvKrILJwRgzvYmSiFbeBSkARM2.vFJRRzbpxRVPLshHPxFeASCuVkul == P_1[i].categoryId && tfhhvKrILJwRgzvYmSiFbeBSkARM3 != null && tfhhvKrILJwRgzvYmSiFbeBSkARM3.vFJRRzbpxRVPLshHPxFeASCuVkul == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor wTPMTSEmQUFAvtiwjgHPtWFLnvCN(xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMap_Editor> P_0)
				{
					GKYwwaclMOIZEqrvlYALgbHNKGfd gKYwwaclMOIZEqrvlYALgbHNKGfd = new GKYwwaclMOIZEqrvlYALgbHNKGfd();
					gKYwwaclMOIZEqrvlYALgbHNKGfd.MzLPLsVFUwUmIHeFVGbpoTIJFmUdA = P_0;
					gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA = JsonTools.Clone(gKYwwaclMOIZEqrvlYALgbHNKGfd.MzLPLsVFUwUmIHeFVGbpoTIJFmUdA.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = UQwVFLQxQUNwJWQMAnxLIhpBbkSU.rEjVGQFBimDwfferqZZIEXZGqqNk.Find(gKYwwaclMOIZEqrvlYALgbHNKGfd.cMEczgBSqLgCKaCzDokpczRCKityb);
					tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = DgpaQdJklNzLovbxGjYRCguoPZSi.Find(gKYwwaclMOIZEqrvlYALgbHNKGfd.NUVnPlvKtGcOjytJugrbkFKNatCB);
					gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA.categoryId = tfhhvKrILJwRgzvYmSiFbeBSkARM2?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA.layoutId = tfhhvKrILJwRgzvYmSiFbeBSkARM3?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					for (int i = 0; i < gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA.actionElementMaps.Count; i++)
					{
						UPSVsgajnYUgmcSyBQDyViytihzv uPSVsgajnYUgmcSyBQDyViytihzv = new UPSVsgajnYUgmcSyBQDyViytihzv();
						uPSVsgajnYUgmcSyBQDyViytihzv.tXcAOJHSQuKLnSfhyzBonQMlVNikA = gKYwwaclMOIZEqrvlYALgbHNKGfd;
						uPSVsgajnYUgmcSyBQDyViytihzv.jrWQSXBBdzHtslJLUrvFJMazdFaK = uPSVsgajnYUgmcSyBQDyViytihzv.tXcAOJHSQuKLnSfhyzBonQMlVNikA.LYoTtBYKcHycmThDrhedhEbpjscWA.actionElementMaps[i];
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM4 = UQwVFLQxQUNwJWQMAnxLIhpBbkSU.XOLQjbkWdimEuQIkUaGrYhTPLztu.Find(uPSVsgajnYUgmcSyBQDyViytihzv.mZJaMabfmtroinMAwgEMMukFflsSA);
						uPSVsgajnYUgmcSyBQDyViytihzv.jrWQSXBBdzHtslJLUrvFJMazdFaK._actionId = tfhhvKrILJwRgzvYmSiFbeBSkARM4?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
						uPSVsgajnYUgmcSyBQDyViytihzv.jrWQSXBBdzHtslJLUrvFJMazdFaK._actionCategoryId = ((UQwVFLQxQUNwJWQMAnxLIhpBbkSU.EpESGIPmcUFMzGnDpWsRlekExEOJ.GetActionById(uPSVsgajnYUgmcSyBQDyViytihzv.jrWQSXBBdzHtslJLUrvFJMazdFaK._actionId) != null) ? UQwVFLQxQUNwJWQMAnxLIhpBbkSU.EpESGIPmcUFMzGnDpWsRlekExEOJ.GetActionById(uPSVsgajnYUgmcSyBQDyViytihzv.jrWQSXBBdzHtslJLUrvFJMazdFaK._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (gKYwwaclMOIZEqrvlYALgbHNKGfd.MzLPLsVFUwUmIHeFVGbpoTIJFmUdA.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						controllerMap_Editor = gKYwwaclMOIZEqrvlYALgbHNKGfd.MzLPLsVFUwUmIHeFVGbpoTIJFmUdA.qesshvxokjrtrYTsLtduhtxZhwaP;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.cIrIdsOfVvUObGZchuNXfOKsTrGe;
						zgwQXfwjgjVPlVVztJjbmSImSotw(controllerMap_Editor.actionElementMaps, gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA = controllerMap_Editor2;
					}
					else
					{
						UQwVFLQxQUNwJWQMAnxLIhpBbkSU.EpESGIPmcUFMzGnDpWsRlekExEOJ.CreateMouseMap(gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA.categoryId, gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA.layoutId);
						controllerMap_Editor = gKYwwaclMOIZEqrvlYALgbHNKGfd.MzLPLsVFUwUmIHeFVGbpoTIJFmUdA.gCzlHAIFruSyrDPyfTSXbPmbcLDX[gKYwwaclMOIZEqrvlYALgbHNKGfd.MzLPLsVFUwUmIHeFVGbpoTIJFmUdA.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA.id = controllerMap_Editor.id;
					int index = gKYwwaclMOIZEqrvlYALgbHNKGfd.MzLPLsVFUwUmIHeFVGbpoTIJFmUdA.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(controllerMap_Editor);
					gKYwwaclMOIZEqrvlYALgbHNKGfd.MzLPLsVFUwUmIHeFVGbpoTIJFmUdA.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA;
					return gKYwwaclMOIZEqrvlYALgbHNKGfd.LYoTtBYKcHycmThDrhedhEbpjscWA;
				}
			}

			private sealed class cyfawbUDiRQhhqesiPbCkisCONXk
			{
				public ControllerMap_Editor AygZaYMKXGAicknflGLjemMVbMgW;

				public Predicate<tfhhvKrILJwRgzvYmSiFbeBSkARM> sfVIxFBYmXUKmWqqIBeGcUERETptA;

				public Predicate<tfhhvKrILJwRgzvYmSiFbeBSkARM> OYXcBPnpsAMVTiCSYcZrvPtleMSAA;

				internal bool eAwkBWXdhrGmvjaMKIlwzQgaovOAA(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.gVzHnxHomYJAyjxzmqUYZIjrHEER == AygZaYMKXGAicknflGLjemMVbMgW.categoryId;
				}

				internal bool GbIhUrlhazHlNzYXgMbDyWlfrog(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.gVzHnxHomYJAyjxzmqUYZIjrHEER == AygZaYMKXGAicknflGLjemMVbMgW.layoutId;
				}
			}

			private sealed class GKYwwaclMOIZEqrvlYALgbHNKGfd
			{
				public xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMap_Editor> MzLPLsVFUwUmIHeFVGbpoTIJFmUdA;

				public ControllerMap_Editor LYoTtBYKcHycmThDrhedhEbpjscWA;

				internal bool cMEczgBSqLgCKaCzDokpczRCKityb(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(MzLPLsVFUwUmIHeFVGbpoTIJFmUdA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == LYoTtBYKcHycmThDrhedhEbpjscWA.categoryId;
				}

				internal bool NUVnPlvKtGcOjytJugrbkFKNatCB(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(MzLPLsVFUwUmIHeFVGbpoTIJFmUdA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == LYoTtBYKcHycmThDrhedhEbpjscWA.layoutId;
				}
			}

			private sealed class UPSVsgajnYUgmcSyBQDyViytihzv
			{
				public ActionElementMap jrWQSXBBdzHtslJLUrvFJMazdFaK;

				public GKYwwaclMOIZEqrvlYALgbHNKGfd tXcAOJHSQuKLnSfhyzBonQMlVNikA;

				internal bool mZJaMabfmtroinMAwgEMMukFflsSA(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(tXcAOJHSQuKLnSfhyzBonQMlVNikA.MzLPLsVFUwUmIHeFVGbpoTIJFmUdA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == jrWQSXBBdzHtslJLUrvFJMazdFaK._actionId;
				}
			}

			private sealed class KlWdoiIEdXQcrazSinfHsRrmMGKh
			{
				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> pfqHbRCrBtLVIyLGtgjJAvWvqOAM;

				public mBUSXtSwBFHrTiJJmCIPmkwtuZnh wiQcnMtymmmSIAgLmkOdoXFpgJQl;

				internal int MlvxmDmlNiUAxgLpBrHQtcPjkVGD(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					TFJPAmGyGhvCUOyscUaFmRmjxiSW tFJPAmGyGhvCUOyscUaFmRmjxiSW = new TFJPAmGyGhvCUOyscUaFmRmjxiSW();
					tFJPAmGyGhvCUOyscUaFmRmjxiSW.FkotxxEEBDNTDDOrlAqkIiMJublcA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = wiQcnMtymmmSIAgLmkOdoXFpgJQl.rEjVGQFBimDwfferqZZIEXZGqqNk.Find(tFJPAmGyGhvCUOyscUaFmRmjxiSW.jZYttgeTBNjKkZczlvHdTqVanDCi);
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = pfqHbRCrBtLVIyLGtgjJAvWvqOAM.Find(tFJPAmGyGhvCUOyscUaFmRmjxiSW.XpZuZPpdIOwtPYHavIeROmCVfyCj);
						if (tFJPAmGyGhvCUOyscUaFmRmjxiSW.FkotxxEEBDNTDDOrlAqkIiMJublcA.hardwareGuid == P_1[i].hardwareGuid && tfhhvKrILJwRgzvYmSiFbeBSkARM2 != null && tfhhvKrILJwRgzvYmSiFbeBSkARM2.vFJRRzbpxRVPLshHPxFeASCuVkul == P_1[i].categoryId && tfhhvKrILJwRgzvYmSiFbeBSkARM3 != null && tfhhvKrILJwRgzvYmSiFbeBSkARM3.vFJRRzbpxRVPLshHPxFeASCuVkul == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor iGVphLOrLHxtMTLTouLRxWhktNxF(xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMap_Editor> P_0)
				{
					HuCgvvtHmvcZglkSgmtwJpDfCzAk huCgvvtHmvcZglkSgmtwJpDfCzAk = new HuCgvvtHmvcZglkSgmtwJpDfCzAk();
					huCgvvtHmvcZglkSgmtwJpDfCzAk.oyDljGmboCyDwQgmCMTdWLYJdMIJ = P_0;
					huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh = JsonTools.Clone(huCgvvtHmvcZglkSgmtwJpDfCzAk.oyDljGmboCyDwQgmCMTdWLYJdMIJ.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = wiQcnMtymmmSIAgLmkOdoXFpgJQl.rEjVGQFBimDwfferqZZIEXZGqqNk.Find(huCgvvtHmvcZglkSgmtwJpDfCzAk.yxWxSbxWinsGXZUfAeIqjTBPGrGn);
					tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = pfqHbRCrBtLVIyLGtgjJAvWvqOAM.Find(huCgvvtHmvcZglkSgmtwJpDfCzAk.axrGaSFdQRPOHGpQnRRqFvjgqZRBA);
					huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh.categoryId = tfhhvKrILJwRgzvYmSiFbeBSkARM2?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh.layoutId = tfhhvKrILJwRgzvYmSiFbeBSkARM3?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					for (int i = 0; i < huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh.actionElementMaps.Count; i++)
					{
						FHHCRNAukxbdPJbfSAdEBsDUtdkvA fHHCRNAukxbdPJbfSAdEBsDUtdkvA = new FHHCRNAukxbdPJbfSAdEBsDUtdkvA();
						fHHCRNAukxbdPJbfSAdEBsDUtdkvA.IeWndfFBksAzdbpnmauncaLfgjAjc = huCgvvtHmvcZglkSgmtwJpDfCzAk;
						fHHCRNAukxbdPJbfSAdEBsDUtdkvA.ZAVcbpoHlaupDkVmAjuGWfBJZQmv = fHHCRNAukxbdPJbfSAdEBsDUtdkvA.IeWndfFBksAzdbpnmauncaLfgjAjc.NSMYqQtlrWlmnsSuvpzaoMCiehuh.actionElementMaps[i];
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM4 = wiQcnMtymmmSIAgLmkOdoXFpgJQl.XOLQjbkWdimEuQIkUaGrYhTPLztu.Find(fHHCRNAukxbdPJbfSAdEBsDUtdkvA.AuPWWwHHoyxEkwiRyIqQARmsvbqM);
						fHHCRNAukxbdPJbfSAdEBsDUtdkvA.ZAVcbpoHlaupDkVmAjuGWfBJZQmv._actionId = tfhhvKrILJwRgzvYmSiFbeBSkARM4?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
						fHHCRNAukxbdPJbfSAdEBsDUtdkvA.ZAVcbpoHlaupDkVmAjuGWfBJZQmv._actionCategoryId = ((wiQcnMtymmmSIAgLmkOdoXFpgJQl.EpESGIPmcUFMzGnDpWsRlekExEOJ.GetActionById(fHHCRNAukxbdPJbfSAdEBsDUtdkvA.ZAVcbpoHlaupDkVmAjuGWfBJZQmv._actionId) != null) ? wiQcnMtymmmSIAgLmkOdoXFpgJQl.EpESGIPmcUFMzGnDpWsRlekExEOJ.GetActionById(fHHCRNAukxbdPJbfSAdEBsDUtdkvA.ZAVcbpoHlaupDkVmAjuGWfBJZQmv._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (huCgvvtHmvcZglkSgmtwJpDfCzAk.oyDljGmboCyDwQgmCMTdWLYJdMIJ.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						controllerMap_Editor = huCgvvtHmvcZglkSgmtwJpDfCzAk.oyDljGmboCyDwQgmCMTdWLYJdMIJ.qesshvxokjrtrYTsLtduhtxZhwaP;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.XrMbBxvSlHLcAdNBtEHvKgySjAEi;
						zgwQXfwjgjVPlVVztJjbmSImSotw(controllerMap_Editor.actionElementMaps, huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh = controllerMap_Editor2;
					}
					else
					{
						wiQcnMtymmmSIAgLmkOdoXFpgJQl.EpESGIPmcUFMzGnDpWsRlekExEOJ.CreateJoystickMap(huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh.categoryId, huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh.hardwareGuid, huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh.layoutId);
						controllerMap_Editor = huCgvvtHmvcZglkSgmtwJpDfCzAk.oyDljGmboCyDwQgmCMTdWLYJdMIJ.gCzlHAIFruSyrDPyfTSXbPmbcLDX[huCgvvtHmvcZglkSgmtwJpDfCzAk.oyDljGmboCyDwQgmCMTdWLYJdMIJ.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh.id = controllerMap_Editor.id;
					int index = huCgvvtHmvcZglkSgmtwJpDfCzAk.oyDljGmboCyDwQgmCMTdWLYJdMIJ.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(controllerMap_Editor);
					huCgvvtHmvcZglkSgmtwJpDfCzAk.oyDljGmboCyDwQgmCMTdWLYJdMIJ.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh;
					return huCgvvtHmvcZglkSgmtwJpDfCzAk.NSMYqQtlrWlmnsSuvpzaoMCiehuh;
				}
			}

			private sealed class TFJPAmGyGhvCUOyscUaFmRmjxiSW
			{
				public ControllerMap_Editor FkotxxEEBDNTDDOrlAqkIiMJublcA;

				public Predicate<tfhhvKrILJwRgzvYmSiFbeBSkARM> VlEqhkaCBVzwNBewgHYCGOaBnREM;

				public Predicate<tfhhvKrILJwRgzvYmSiFbeBSkARM> ZncFZCThkZekUYXsMfvHDoFMNjgm;

				internal bool jZYttgeTBNjKkZczlvHdTqVanDCi(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.gVzHnxHomYJAyjxzmqUYZIjrHEER == FkotxxEEBDNTDDOrlAqkIiMJublcA.categoryId;
				}

				internal bool XpZuZPpdIOwtPYHavIeROmCVfyCj(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.gVzHnxHomYJAyjxzmqUYZIjrHEER == FkotxxEEBDNTDDOrlAqkIiMJublcA.layoutId;
				}
			}

			private sealed class HuCgvvtHmvcZglkSgmtwJpDfCzAk
			{
				public xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMap_Editor> oyDljGmboCyDwQgmCMTdWLYJdMIJ;

				public ControllerMap_Editor NSMYqQtlrWlmnsSuvpzaoMCiehuh;

				internal bool yxWxSbxWinsGXZUfAeIqjTBPGrGn(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(oyDljGmboCyDwQgmCMTdWLYJdMIJ.KCiEkNdEgbYOfGZndQVftTXvupPiA) == NSMYqQtlrWlmnsSuvpzaoMCiehuh.categoryId;
				}

				internal bool axrGaSFdQRPOHGpQnRRqFvjgqZRBA(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(oyDljGmboCyDwQgmCMTdWLYJdMIJ.KCiEkNdEgbYOfGZndQVftTXvupPiA) == NSMYqQtlrWlmnsSuvpzaoMCiehuh.layoutId;
				}
			}

			private sealed class FHHCRNAukxbdPJbfSAdEBsDUtdkvA
			{
				public ActionElementMap ZAVcbpoHlaupDkVmAjuGWfBJZQmv;

				public HuCgvvtHmvcZglkSgmtwJpDfCzAk IeWndfFBksAzdbpnmauncaLfgjAjc;

				internal bool AuPWWwHHoyxEkwiRyIqQARmsvbqM(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(IeWndfFBksAzdbpnmauncaLfgjAjc.oyDljGmboCyDwQgmCMTdWLYJdMIJ.KCiEkNdEgbYOfGZndQVftTXvupPiA) == ZAVcbpoHlaupDkVmAjuGWfBJZQmv._actionId;
				}
			}

			private sealed class ZMsqiTXuQglEqPnNnCmJcwRUWAeI
			{
				public List<tfhhvKrILJwRgzvYmSiFbeBSkARM> ZGdvTSQihRXeJlfvEcInmIcMRSBQ;

				public mBUSXtSwBFHrTiJJmCIPmkwtuZnh zEbeprmbgevfCXKRutEbZhrtFBpD;

				internal int qtmclpaHOOlwdbvmcYHBBlJPaGylb(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					xscluaHBbyXQXJydTtdHZfVgnlem xscluaHBbyXQXJydTtdHZfVgnlem2 = new xscluaHBbyXQXJydTtdHZfVgnlem();
					xscluaHBbyXQXJydTtdHZfVgnlem2.ZqFhQjSGdSZbsUJckPyGulghJpYD = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = zEbeprmbgevfCXKRutEbZhrtFBpD.MLDhgOawKMWnYaMhSFExHelvSCbzA.Find(xscluaHBbyXQXJydTtdHZfVgnlem2.XwWfYaGGMCJBejKmiiKmlxgxuKbPB);
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = zEbeprmbgevfCXKRutEbZhrtFBpD.rEjVGQFBimDwfferqZZIEXZGqqNk.Find(xscluaHBbyXQXJydTtdHZfVgnlem2.tPnrJLsdwPeTjFatIrEhjozDAhRaA);
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM4 = ZGdvTSQihRXeJlfvEcInmIcMRSBQ.Find(xscluaHBbyXQXJydTtdHZfVgnlem2.wfpdNiwPJlGAjsWPFbuHbFwvHGiEb);
						if (tfhhvKrILJwRgzvYmSiFbeBSkARM2 != null && tfhhvKrILJwRgzvYmSiFbeBSkARM2.vFJRRzbpxRVPLshHPxFeASCuVkul == P_1[i].customControllerUid && tfhhvKrILJwRgzvYmSiFbeBSkARM3 != null && tfhhvKrILJwRgzvYmSiFbeBSkARM3.vFJRRzbpxRVPLshHPxFeASCuVkul == P_1[i].categoryId && tfhhvKrILJwRgzvYmSiFbeBSkARM4 != null && tfhhvKrILJwRgzvYmSiFbeBSkARM4.vFJRRzbpxRVPLshHPxFeASCuVkul == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor QAKgBPJCMTzmgEnkpEsYuFyBZMLrA(xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMap_Editor> P_0)
				{
					QvmcquVDJOibTFVWtmDbZHTvApwS qvmcquVDJOibTFVWtmDbZHTvApwS = new QvmcquVDJOibTFVWtmDbZHTvApwS();
					qvmcquVDJOibTFVWtmDbZHTvApwS.aQHFkiKXoRitKJUMLIyPhPjBsvwI = P_0;
					qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA = JsonTools.Clone(qvmcquVDJOibTFVWtmDbZHTvApwS.aQHFkiKXoRitKJUMLIyPhPjBsvwI.QrbicxKYbNtQHkRZnPyPBhRJqhhi);
					tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = zEbeprmbgevfCXKRutEbZhrtFBpD.MLDhgOawKMWnYaMhSFExHelvSCbzA.Find(qvmcquVDJOibTFVWtmDbZHTvApwS.wBYdMAERxuuSylagfqebKXRTfMBk);
					tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM3 = zEbeprmbgevfCXKRutEbZhrtFBpD.rEjVGQFBimDwfferqZZIEXZGqqNk.Find(qvmcquVDJOibTFVWtmDbZHTvApwS.cbodMXdfBsoFlItumTOtZsaKLEQOA);
					tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM4 = ZGdvTSQihRXeJlfvEcInmIcMRSBQ.Find(qvmcquVDJOibTFVWtmDbZHTvApwS.qXbAejlhOqVJtQILOPAyLHVWoWQp);
					qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA.customControllerUid = tfhhvKrILJwRgzvYmSiFbeBSkARM2?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA.categoryId = tfhhvKrILJwRgzvYmSiFbeBSkARM3?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA.layoutId = tfhhvKrILJwRgzvYmSiFbeBSkARM4?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					for (int i = 0; i < qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA.actionElementMaps.Count; i++)
					{
						BFVUeIbdxADqQfLXPYreSVmOEgBY bFVUeIbdxADqQfLXPYreSVmOEgBY = new BFVUeIbdxADqQfLXPYreSVmOEgBY();
						bFVUeIbdxADqQfLXPYreSVmOEgBY.QfSaEYiHbclWeSTNZVCArpkEFVqL = qvmcquVDJOibTFVWtmDbZHTvApwS;
						bFVUeIbdxADqQfLXPYreSVmOEgBY.rDNuoeRnBAZMUWULbaJPKTgQMcZQ = bFVUeIbdxADqQfLXPYreSVmOEgBY.QfSaEYiHbclWeSTNZVCArpkEFVqL.jHMxOLjIicFhfeemGHJnCswiDuGaA.actionElementMaps[i];
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM5 = zEbeprmbgevfCXKRutEbZhrtFBpD.XOLQjbkWdimEuQIkUaGrYhTPLztu.Find(bFVUeIbdxADqQfLXPYreSVmOEgBY.TUHreyfanxKDLfUWvaZQwJBxsBdr);
						bFVUeIbdxADqQfLXPYreSVmOEgBY.rDNuoeRnBAZMUWULbaJPKTgQMcZQ._actionId = tfhhvKrILJwRgzvYmSiFbeBSkARM5?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
						bFVUeIbdxADqQfLXPYreSVmOEgBY.rDNuoeRnBAZMUWULbaJPKTgQMcZQ._actionCategoryId = ((zEbeprmbgevfCXKRutEbZhrtFBpD.EpESGIPmcUFMzGnDpWsRlekExEOJ.GetActionById(bFVUeIbdxADqQfLXPYreSVmOEgBY.rDNuoeRnBAZMUWULbaJPKTgQMcZQ._actionId) != null) ? zEbeprmbgevfCXKRutEbZhrtFBpD.EpESGIPmcUFMzGnDpWsRlekExEOJ.GetActionById(bFVUeIbdxADqQfLXPYreSVmOEgBY.rDNuoeRnBAZMUWULbaJPKTgQMcZQ._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (qvmcquVDJOibTFVWtmDbZHTvApwS.aQHFkiKXoRitKJUMLIyPhPjBsvwI.eQSnIrDLPcWbMhTmPFjWoRmWILiI)
					{
						controllerMap_Editor = qvmcquVDJOibTFVWtmDbZHTvApwS.aQHFkiKXoRitKJUMLIyPhPjBsvwI.qesshvxokjrtrYTsLtduhtxZhwaP;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.XDrAwNDaUGuVgXWNSdAfmlAvRdFO;
						zgwQXfwjgjVPlVVztJjbmSImSotw(controllerMap_Editor.actionElementMaps, qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA = controllerMap_Editor2;
					}
					else
					{
						zEbeprmbgevfCXKRutEbZhrtFBpD.EpESGIPmcUFMzGnDpWsRlekExEOJ.CreateCustomControllerMap(qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA.categoryId, qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA.customControllerUid, qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA.layoutId);
						controllerMap_Editor = qvmcquVDJOibTFVWtmDbZHTvApwS.aQHFkiKXoRitKJUMLIyPhPjBsvwI.gCzlHAIFruSyrDPyfTSXbPmbcLDX[qvmcquVDJOibTFVWtmDbZHTvApwS.aQHFkiKXoRitKJUMLIyPhPjBsvwI.gCzlHAIFruSyrDPyfTSXbPmbcLDX.Count - 1];
					}
					qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA.id = controllerMap_Editor.id;
					int index = qvmcquVDJOibTFVWtmDbZHTvApwS.aQHFkiKXoRitKJUMLIyPhPjBsvwI.gCzlHAIFruSyrDPyfTSXbPmbcLDX.IndexOf(controllerMap_Editor);
					qvmcquVDJOibTFVWtmDbZHTvApwS.aQHFkiKXoRitKJUMLIyPhPjBsvwI.gCzlHAIFruSyrDPyfTSXbPmbcLDX[index] = qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA;
					return qvmcquVDJOibTFVWtmDbZHTvApwS.jHMxOLjIicFhfeemGHJnCswiDuGaA;
				}
			}

			private sealed class lTNKpQZrLfQqxdThzeubxsaIiYTl
			{
				public int XrBDxSuaxEUKSzGhHssvGJbqqLYb;

				internal bool oZEREbfVKacZRXtPyYxGYAtBODED(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.gVzHnxHomYJAyjxzmqUYZIjrHEER == XrBDxSuaxEUKSzGhHssvGJbqqLYb;
				}
			}

			private sealed class xscluaHBbyXQXJydTtdHZfVgnlem
			{
				public ControllerMap_Editor ZqFhQjSGdSZbsUJckPyGulghJpYD;

				public Predicate<tfhhvKrILJwRgzvYmSiFbeBSkARM> nLUOUYMBtfkJhRuiEufeAEnVOyGr;

				public Predicate<tfhhvKrILJwRgzvYmSiFbeBSkARM> xKzaGJyWdsfcNwxVZVBbDoDKNZlU;

				public Predicate<tfhhvKrILJwRgzvYmSiFbeBSkARM> hEzpnZjDdPaTDIgVtKVmtEFKcdLx;

				internal bool XwWfYaGGMCJBejKmiiKmlxgxuKbPB(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.gVzHnxHomYJAyjxzmqUYZIjrHEER == ZqFhQjSGdSZbsUJckPyGulghJpYD.customControllerUid;
				}

				internal bool tPnrJLsdwPeTjFatIrEhjozDAhRaA(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.gVzHnxHomYJAyjxzmqUYZIjrHEER == ZqFhQjSGdSZbsUJckPyGulghJpYD.categoryId;
				}

				internal bool wfpdNiwPJlGAjsWPFbuHbFwvHGiEb(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.gVzHnxHomYJAyjxzmqUYZIjrHEER == ZqFhQjSGdSZbsUJckPyGulghJpYD.layoutId;
				}
			}

			private sealed class QvmcquVDJOibTFVWtmDbZHTvApwS
			{
				public xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMap_Editor> aQHFkiKXoRitKJUMLIyPhPjBsvwI;

				public ControllerMap_Editor jHMxOLjIicFhfeemGHJnCswiDuGaA;

				internal bool wBYdMAERxuuSylagfqebKXRTfMBk(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(aQHFkiKXoRitKJUMLIyPhPjBsvwI.KCiEkNdEgbYOfGZndQVftTXvupPiA) == jHMxOLjIicFhfeemGHJnCswiDuGaA.customControllerUid;
				}

				internal bool cbodMXdfBsoFlItumTOtZsaKLEQOA(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(aQHFkiKXoRitKJUMLIyPhPjBsvwI.KCiEkNdEgbYOfGZndQVftTXvupPiA) == jHMxOLjIicFhfeemGHJnCswiDuGaA.categoryId;
				}

				internal bool qXbAejlhOqVJtQILOPAyLHVWoWQp(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(aQHFkiKXoRitKJUMLIyPhPjBsvwI.KCiEkNdEgbYOfGZndQVftTXvupPiA) == jHMxOLjIicFhfeemGHJnCswiDuGaA.layoutId;
				}
			}

			private sealed class BFVUeIbdxADqQfLXPYreSVmOEgBY
			{
				public ActionElementMap rDNuoeRnBAZMUWULbaJPKTgQMcZQ;

				public QvmcquVDJOibTFVWtmDbZHTvApwS QfSaEYiHbclWeSTNZVCArpkEFVqL;

				internal bool TUHreyfanxKDLfUWvaZQwJBxsBdr(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(QfSaEYiHbclWeSTNZVCArpkEFVqL.aQHFkiKXoRitKJUMLIyPhPjBsvwI.KCiEkNdEgbYOfGZndQVftTXvupPiA) == rDNuoeRnBAZMUWULbaJPKTgQMcZQ._actionId;
				}
			}

			private sealed class bhTDTeCHZAkJjbcbcZcnCXMwLeqE
			{
				public xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMapLayoutManager_RuleSet_Editor> vvZfpmAjIcbVhrqhtWjSRtHVPPuXA;
			}

			private sealed class INkLBGSqvwFAsgFgpVRTRugnLCRgA
			{
				public int uFxluvjSBxunDNeBQErdcDJuhFud;

				public bhTDTeCHZAkJjbcbcZcnCXMwLeqE QyqwGsEnoyNGHQEmWHUBEqhBFpHDA;

				internal bool ixJUGYUOrDcICEmjVvifgjaGmfwGb(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(QyqwGsEnoyNGHQEmWHUBEqhBFpHDA.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == uFxluvjSBxunDNeBQErdcDJuhFud;
				}
			}

			private sealed class apgkymrGdPuRsphckrEkcUjWugUl
			{
				public int ooXBoMceDBtHVsOjkGeHlXRvoKNx;

				public bhTDTeCHZAkJjbcbcZcnCXMwLeqE ppGlklkqfCEncJhwYJnrDBSidICP;

				internal bool FLtxDUgoOvYlTDbMUAkgdvYgqjESA(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(ppGlklkqfCEncJhwYJnrDBSidICP.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == ooXBoMceDBtHVsOjkGeHlXRvoKNx;
				}
			}

			private sealed class davUjobXmrnQigaURGCIkdDLXrdq
			{
				public int TWbpEpFwynUHYhwPUlZbJtsRKiPv;

				public bhTDTeCHZAkJjbcbcZcnCXMwLeqE fJWdorJdYoyhmHKCAmNScqIrynIPA;

				internal bool slfYRVEtMTuUwpVaWSwRrajtPJrj(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(fJWdorJdYoyhmHKCAmNScqIrynIPA.vvZfpmAjIcbVhrqhtWjSRtHVPPuXA.KCiEkNdEgbYOfGZndQVftTXvupPiA) == TWbpEpFwynUHYhwPUlZbJtsRKiPv;
				}
			}

			private sealed class uWjBZPhIyPCVocFKFRBEwUuuZpNnb
			{
				public xYqbgJJDYgqlPUrubRRshNKKePtQA<ControllerMapEnabler_RuleSet_Editor> RFNJlDxykkaCufEyTPXhskmvyyKj;
			}

			private sealed class ONyqEvLYJpCyDSEIfuUOKThGsyCm
			{
				public int QDtnCdILeVaByTkZBAQWvKlybMvaA;

				public uWjBZPhIyPCVocFKFRBEwUuuZpNnb hjAGMiyErDGvtJKiASKKuzLXBCKQ;

				internal bool ormAiYyRAqfunNzqiXkOJIBbDKPc(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.cEYCuKeHrvSGaXRPJgWeYHPvfver(hjAGMiyErDGvtJKiASKKuzLXBCKQ.RFNJlDxykkaCufEyTPXhskmvyyKj.KCiEkNdEgbYOfGZndQVftTXvupPiA) == QDtnCdILeVaByTkZBAQWvKlybMvaA;
				}
			}

			private sealed class FnrMuzFekWaTkxvLAdALAjiPZJYj<_0001> where _0001 : class
			{
				public Func<_0001, int> LUDHcuMlWrEkQDkxMNzyZPBXrGEEb;
			}

			private sealed class hNFgjoxwqUmUfSFZxYwdHEaMdbCI<_0001> where _0001 : class
			{
				public _0001 tBJyaCFIwbHEEVEVDNAEUlKOXrtE;

				public FnrMuzFekWaTkxvLAdALAjiPZJYj<_0001> WdtBiCQsiCyrAZhDPFhfrUeJnkpX;

				internal bool YGgAbCXSKxfOAgqNeheOoCCbBQyo(tfhhvKrILJwRgzvYmSiFbeBSkARM P_0)
				{
					return P_0.vFJRRzbpxRVPLshHPxFeASCuVkul == WdtBiCQsiCyrAZhDPFhfrUeJnkpX.LUDHcuMlWrEkQDkxMNzyZPBXrGEEb(tBJyaCFIwbHEEVEVDNAEUlKOXrtE);
				}
			}

			public static UserData YsxTYhgCzaBgJABBfSUdGVUDnfWg(UserData P_0, UserData P_1, bool P_2)
			{
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh mBUSXtSwBFHrTiJJmCIPmkwtuZnh2 = new mBUSXtSwBFHrTiJJmCIPmkwtuZnh();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ = (P_2 ? P_0 : new UserData(false));
				if (P_1 != null)
				{
					mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.configVars = JsonTools.Clone(P_1.configVars);
				}
				else
				{
					mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.configVars = JsonTools.Clone(P_0.configVars);
				}
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.qqBZnJEpBZNEtODTHbpvOKzPXQbD = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Action Category", P_0.actionCategories, P_1?.actionCategories, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.actionCategories, P_2, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.qqBZnJEpBZNEtODTHbpvOKzPXQbD, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.LDjdmKuIDHlwPPtQoDrxxpQLdKfIA, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.ZddswDElgyoHjIKqzqbCyvDFGhAv, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.tlidDHFIdJuofqEVSkPPeFXMwgYeb, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.hnUBXuhIJdIrbILMpkPpoMZtPcmPA);
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.ABPgpSAAdlnwthGvBvkzVgFpVcdCA = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.inputBehaviors, P_2, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.ABPgpSAAdlnwthGvBvkzVgFpVcdCA, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.gNjNZCwHqDAWkDbOpzDnINLuKFNF, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.IlqOVZKWuDrCEQIgYXTZFNJHHAQu, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.RRQmsAsJMxaGhIwTmTGDYfWLdBtAA, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.vxcVMSKtnsOIhhLGUwfOhzDXzGIG);
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.XOLQjbkWdimEuQIkUaGrYhTPLztu = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Action", P_0.actions, P_1?.actions, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.actions, P_2, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.XOLQjbkWdimEuQIkUaGrYhTPLztu, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.pOtYPTAtARdsRHUMVnNkbquxQgQy, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.AquNaEbxpCdSClWDsNeGDDqyAJkaA, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.NitVsmokebqFejybCKUGuCZgXpuP, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EeZWoMHPqMaipoECBitbGXzgNjmOA);
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.rEjVGQFBimDwfferqZZIEXZGqqNk = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				QznikMCqZmkGITXGRauBhecwxHGs qznikMCqZmkGITXGRauBhecwxHGs = new QznikMCqZmkGITXGRauBhecwxHGs();
				qznikMCqZmkGITXGRauBhecwxHGs.EJmJDuvPejIIxgErPfsRTdpPqALab = mBUSXtSwBFHrTiJJmCIPmkwtuZnh2;
				qznikMCqZmkGITXGRauBhecwxHGs.HeHzAbDbVNJTnNjerJmgyNcAlWtb = new List<int>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Map Category", P_0.mapCategories, P_1?.mapCategories, qznikMCqZmkGITXGRauBhecwxHGs.EJmJDuvPejIIxgErPfsRTdpPqALab.EpESGIPmcUFMzGnDpWsRlekExEOJ.mapCategories, P_2, qznikMCqZmkGITXGRauBhecwxHGs.EJmJDuvPejIIxgErPfsRTdpPqALab.rEjVGQFBimDwfferqZZIEXZGqqNk, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.oRFbUqOJaxILbRJVoOaxUrucvYWG, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.cOunYVraHgnLBcWeVEKZPCzHTaOw, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.fbivVKZRdJsBxlXUjROSDAcuUAVf, qznikMCqZmkGITXGRauBhecwxHGs.iaIZXKCcPQfCjrcwXdcQsummErZy);
				for (int i = 0; i < qznikMCqZmkGITXGRauBhecwxHGs.HeHzAbDbVNJTnNjerJmgyNcAlWtb.Count; i++)
				{
					int index = qznikMCqZmkGITXGRauBhecwxHGs.HeHzAbDbVNJTnNjerJmgyNcAlWtb[i];
					InputMapCategory inputMapCategory = qznikMCqZmkGITXGRauBhecwxHGs.EJmJDuvPejIIxgErPfsRTdpPqALab.EpESGIPmcUFMzGnDpWsRlekExEOJ.mapCategories[index];
					for (int j = 0; j < inputMapCategory.HQIwDzjZWNXHJSQHQhDesQjCKGEg.Count; j++)
					{
						lTNKpQZrLfQqxdThzeubxsaIiYTl lTNKpQZrLfQqxdThzeubxsaIiYTl2 = new lTNKpQZrLfQqxdThzeubxsaIiYTl();
						lTNKpQZrLfQqxdThzeubxsaIiYTl2.XrBDxSuaxEUKSzGhHssvGJbqqLYb = inputMapCategory.HQIwDzjZWNXHJSQHQhDesQjCKGEg[j];
						tfhhvKrILJwRgzvYmSiFbeBSkARM tfhhvKrILJwRgzvYmSiFbeBSkARM2 = qznikMCqZmkGITXGRauBhecwxHGs.EJmJDuvPejIIxgErPfsRTdpPqALab.rEjVGQFBimDwfferqZZIEXZGqqNk.Find(lTNKpQZrLfQqxdThzeubxsaIiYTl2.oZEREbfVKacZRXtPyYxGYAtBODED);
						inputMapCategory.HQIwDzjZWNXHJSQHQhDesQjCKGEg[j] = tfhhvKrILJwRgzvYmSiFbeBSkARM2?.vFJRRzbpxRVPLshHPxFeASCuVkul ?? (-1);
					}
				}
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.FgdAVOllySbKwcWqjtXmiwaiBtUAb = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.keyboardLayouts, P_2, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.FgdAVOllySbKwcWqjtXmiwaiBtUAb, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.FwLHmPpDGFeCRBKiQZzYCorueIut, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.JFPeLurbkEqPaDDuqflDDEviJWIG, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.GQHhSjdxACrSgBSSVzOmHDxNoNaD, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.fJHrkKXldkgCOhoEknHrwswEZZpf);
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.wTnoGsqSlYfCSEalbxtzgcwEHSuP = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.mouseLayouts, P_2, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.wTnoGsqSlYfCSEalbxtzgcwEHSuP, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.zocdXHaezHuVZFNEGaABNVJUliSUA, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.zKVuQciIyuvJKmyOtRJuaMqYIggB, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.DdukPmNqvLbEsmFyNzDANKgWSSFJ, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.FLgKCdpQjrIpKgWINhkPLvzOmNqEA);
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.aqLJPVYjMmcytNvTAEhReBKyIqlLA = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.joystickLayouts, P_2, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.aqLJPVYjMmcytNvTAEhReBKyIqlLA, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.slicpxOxifawxbyddMRgrjWhOhuUA, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.yOGbQpQMbYWqfFOFgAjtnsSGeatu, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.RxjMjEKBslBtplEVtufjkOlRhrQI, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.PMWFSQqsfXysZnSTXbnkASpTqoLN);
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.GVffiFBdYQDQguwIujmwIfTjOrnZA = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.customControllerLayouts, P_2, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.GVffiFBdYQDQguwIujmwIfTjOrnZA, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.YIBZSiYpOFDWJytBqifpfGvlmCOS, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.aEWCAdzbsdNPpLsjROYdbTUamaux, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.oXbHidRIXJGFVbbexoZxCMCWsAcN, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.tIZvSNApCazJZQcabQSbYNfVFejG);
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.TBhkaLerEKQptsbXHEaasNCYjkRfA = mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.ffOEqXafxxlqjAckNXBCRnhIYLAO;
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.MLDhgOawKMWnYaMhSFExHelvSCbzA = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Custom Controller", P_0.customControllers, P_1?.customControllers, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.customControllers, P_2, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.MLDhgOawKMWnYaMhSFExHelvSCbzA, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.kKCeYZmPwXdUHUyvHdpliUDFSHth, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.hmKbtreEPiwDocaBQLdCIWpqjpSC, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.kdshwwhPHfVNpkZrSxevgVbmSCMR, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.vkxlcrRlcdhWfVqXtBDrDhmwqyAPA);
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.euCFsCndFLsthjJDHAjrxwijsaJt = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.controllerMapLayoutManagerRuleSets, P_2, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.euCFsCndFLsthjJDHAjrxwijsaJt, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.ZbNjCvdCUmrUjxUvMplkCrZcELcX, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.lWXxNZpPtUGQWMhxuAmrVPCBkiNi, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.ZUMaNupGIJYXQLbChFhbBpifCSJtA, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.jQJcUCJhoearglgmlKMkbmjrDrydA);
				mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.CcBdrllmKnSUDRmOMuIArJeZdJeq = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.controllerMapEnablerRuleSets, P_2, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.CcBdrllmKnSUDRmOMuIArJeZdJeq, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.SnIQtbLDApFUVOTtTcffBHGlrYkG, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.wjyxwgQRFWfsVGDAogqOBcGHsnyj, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.jyFUhWubWxEqQPnkjbMBFbrkrCdX, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.NCUtcaLNjwiyuXqnorNDKBYMfIZr);
				List<tfhhvKrILJwRgzvYmSiFbeBSkARM> list = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Player", P_0.players, P_1?.players, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ.players, P_2, list, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.dEkoSRBYTFeViijyvdnrcoWygUSAb, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.JGlAFsfMxoDWARtjtBYkmmhltsagA, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.AEKmCHzMKsBsyLaLhgMwHENDagFc, mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.sKXdQGEsveHjjCkMjzhEDgxUeabNb);
				List<tfhhvKrILJwRgzvYmSiFbeBSkARM> list2 = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				EvMhaLZFHITMIGZNruEwYJnBhMAX evMhaLZFHITMIGZNruEwYJnBhMAX = new EvMhaLZFHITMIGZNruEwYJnBhMAX();
				evMhaLZFHITMIGZNruEwYJnBhMAX.GlMEwQaJYnJwqcZqsuaiEwFBXzprB = mBUSXtSwBFHrTiJJmCIPmkwtuZnh2;
				evMhaLZFHITMIGZNruEwYJnBhMAX.HryhAnuaZVNOAGKSgflZeeNlblEf = evMhaLZFHITMIGZNruEwYJnBhMAX.GlMEwQaJYnJwqcZqsuaiEwFBXzprB.FgdAVOllySbKwcWqjtXmiwaiBtUAb;
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, evMhaLZFHITMIGZNruEwYJnBhMAX.GlMEwQaJYnJwqcZqsuaiEwFBXzprB.EpESGIPmcUFMzGnDpWsRlekExEOJ.keyboardMaps, P_2, list2, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.HTsvXFRNLVWujUAUSZHraqLamSFL, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.xLjZAoaEdRpLDzutXKLHzKejZyHj, evMhaLZFHITMIGZNruEwYJnBhMAX.xFucZqGFCxXocfgtwCsqaGTLylXr, evMhaLZFHITMIGZNruEwYJnBhMAX.xoGVkNzuuFktOVSfnGZxdaiUVtiD);
				List<tfhhvKrILJwRgzvYmSiFbeBSkARM> list3 = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				zzhrABdEBfMJxuDQOlYQlaiOcGBW zzhrABdEBfMJxuDQOlYQlaiOcGBW2 = new zzhrABdEBfMJxuDQOlYQlaiOcGBW();
				zzhrABdEBfMJxuDQOlYQlaiOcGBW2.UQwVFLQxQUNwJWQMAnxLIhpBbkSU = mBUSXtSwBFHrTiJJmCIPmkwtuZnh2;
				zzhrABdEBfMJxuDQOlYQlaiOcGBW2.DgpaQdJklNzLovbxGjYRCguoPZSi = zzhrABdEBfMJxuDQOlYQlaiOcGBW2.UQwVFLQxQUNwJWQMAnxLIhpBbkSU.wTnoGsqSlYfCSEalbxtzgcwEHSuP;
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, zzhrABdEBfMJxuDQOlYQlaiOcGBW2.UQwVFLQxQUNwJWQMAnxLIhpBbkSU.EpESGIPmcUFMzGnDpWsRlekExEOJ.mouseMaps, P_2, list3, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.hBPabdKpcUDDAaXFROiFVXZYRkVJ, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.YurcFWrWxeEjWIcXuBogOXeEwbCPA, zzhrABdEBfMJxuDQOlYQlaiOcGBW2.dQzSrbHhuifYLFkRlpNiwjsDPxQt, zzhrABdEBfMJxuDQOlYQlaiOcGBW2.wTPMTSEmQUFAvtiwjgHPtWFLnvCN);
				List<tfhhvKrILJwRgzvYmSiFbeBSkARM> list4 = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				KlWdoiIEdXQcrazSinfHsRrmMGKh klWdoiIEdXQcrazSinfHsRrmMGKh = new KlWdoiIEdXQcrazSinfHsRrmMGKh();
				klWdoiIEdXQcrazSinfHsRrmMGKh.wiQcnMtymmmSIAgLmkOdoXFpgJQl = mBUSXtSwBFHrTiJJmCIPmkwtuZnh2;
				klWdoiIEdXQcrazSinfHsRrmMGKh.pfqHbRCrBtLVIyLGtgjJAvWvqOAM = klWdoiIEdXQcrazSinfHsRrmMGKh.wiQcnMtymmmSIAgLmkOdoXFpgJQl.aqLJPVYjMmcytNvTAEhReBKyIqlLA;
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, klWdoiIEdXQcrazSinfHsRrmMGKh.wiQcnMtymmmSIAgLmkOdoXFpgJQl.EpESGIPmcUFMzGnDpWsRlekExEOJ.joystickMaps, P_2, list4, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.hTLuZYCsBXNAvbdHhoRwPBbBhvRq, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.eZvCuXopecLvyzlRZZadWCWhSfep, klWdoiIEdXQcrazSinfHsRrmMGKh.MlvxmDmlNiUAxgLpBrHQtcPjkVGD, klWdoiIEdXQcrazSinfHsRrmMGKh.iGVphLOrLHxtMTLTouLRxWhktNxF);
				List<tfhhvKrILJwRgzvYmSiFbeBSkARM> list5 = new List<tfhhvKrILJwRgzvYmSiFbeBSkARM>();
				ZMsqiTXuQglEqPnNnCmJcwRUWAeI zMsqiTXuQglEqPnNnCmJcwRUWAeI = new ZMsqiTXuQglEqPnNnCmJcwRUWAeI();
				zMsqiTXuQglEqPnNnCmJcwRUWAeI.zEbeprmbgevfCXKRutEbZhrtFBpD = mBUSXtSwBFHrTiJJmCIPmkwtuZnh2;
				zMsqiTXuQglEqPnNnCmJcwRUWAeI.ZGdvTSQihRXeJlfvEcInmIcMRSBQ = zMsqiTXuQglEqPnNnCmJcwRUWAeI.zEbeprmbgevfCXKRutEbZhrtFBpD.GVffiFBdYQDQguwIujmwIfTjOrnZA;
				zpfiRWkYGfPpsClMjhlMfrQsmQnRA("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, zMsqiTXuQglEqPnNnCmJcwRUWAeI.zEbeprmbgevfCXKRutEbZhrtFBpD.EpESGIPmcUFMzGnDpWsRlekExEOJ.customControllerMaps, P_2, list5, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.YIPwBsKWqqDgCGdYLzUReicAULHN, vFYQFnnHvNyOJSaBiBjXJFmvFxmY._003C_003E9.sYhFCQElVYOlWDmfkCjZMxQknHxaA, zMsqiTXuQglEqPnNnCmJcwRUWAeI.qtmclpaHOOlwdbvmcYHBBlJPaGylb, zMsqiTXuQglEqPnNnCmJcwRUWAeI.QAKgBPJCMTzmgEnkpEsYuFyBZMLrA);
				return mBUSXtSwBFHrTiJJmCIPmkwtuZnh2.EpESGIPmcUFMzGnDpWsRlekExEOJ;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void PNiDPPkhgrjcIBvGVUBDQjqTiJLib(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void zgwQXfwjgjVPlVVztJjbmSImSotw<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
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

			private static void zpfiRWkYGfPpsClMjhlMfrQsmQnRA<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<tfhhvKrILJwRgzvYmSiFbeBSkARM> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<xYqbgJJDYgqlPUrubRRshNKKePtQA<_0001>, _0001> P_9) where _0001 : class
			{
				FnrMuzFekWaTkxvLAdALAjiPZJYj<_0001> fnrMuzFekWaTkxvLAdALAjiPZJYj = new FnrMuzFekWaTkxvLAdALAjiPZJYj<_0001>();
				fnrMuzFekWaTkxvLAdALAjiPZJYj.LUDHcuMlWrEkQDkxMNzyZPBXrGEEb = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					_0001 val = P_1[i];
					if (P_4)
					{
						P_5.Add(new tfhhvKrILJwRgzvYmSiFbeBSkARM(fnrMuzFekWaTkxvLAdALAjiPZJYj.LUDHcuMlWrEkQDkxMNzyZPBXrGEEb(val), -1, fnrMuzFekWaTkxvLAdALAjiPZJYj.LUDHcuMlWrEkQDkxMNzyZPBXrGEEb(val)));
						continue;
					}
					_0001 arg = P_9(new xYqbgJJDYgqlPUrubRRshNKKePtQA<_0001>(val, null, tfhhvKrILJwRgzvYmSiFbeBSkARM.PFIodniGImNxQYQcwvbMOpIpErUc.origId, P_3, false));
					P_5.Add(new tfhhvKrILJwRgzvYmSiFbeBSkARM(fnrMuzFekWaTkxvLAdALAjiPZJYj.LUDHcuMlWrEkQDkxMNzyZPBXrGEEb(val), -1, fnrMuzFekWaTkxvLAdALAjiPZJYj.LUDHcuMlWrEkQDkxMNzyZPBXrGEEb(arg)));
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
						hNFgjoxwqUmUfSFZxYwdHEaMdbCI<_0001> hNFgjoxwqUmUfSFZxYwdHEaMdbCI2 = new hNFgjoxwqUmUfSFZxYwdHEaMdbCI<_0001>();
						hNFgjoxwqUmUfSFZxYwdHEaMdbCI2.WdtBiCQsiCyrAZhDPFhfrUeJnkpX = fnrMuzFekWaTkxvLAdALAjiPZJYj;
						_0001 val3 = P_3[num];
						hNFgjoxwqUmUfSFZxYwdHEaMdbCI2.tBJyaCFIwbHEEVEVDNAEUlKOXrtE = P_9(new xYqbgJJDYgqlPUrubRRshNKKePtQA<_0001>(val2, val3, tfhhvKrILJwRgzvYmSiFbeBSkARM.PFIodniGImNxQYQcwvbMOpIpErUc.otherId, P_3, true));
						P_5.Find(hNFgjoxwqUmUfSFZxYwdHEaMdbCI2.YGgAbCXSKxfOAgqNeheOoCCbBQyo).gVzHnxHomYJAyjxzmqUYZIjrHEER = hNFgjoxwqUmUfSFZxYwdHEaMdbCI2.WdtBiCQsiCyrAZhDPFhfrUeJnkpX.LUDHcuMlWrEkQDkxMNzyZPBXrGEEb(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						_0001 arg2 = P_9(new xYqbgJJDYgqlPUrubRRshNKKePtQA<_0001>(val2, null, tfhhvKrILJwRgzvYmSiFbeBSkARM.PFIodniGImNxQYQcwvbMOpIpErUc.otherId, P_3, false));
						P_5.Add(new tfhhvKrILJwRgzvYmSiFbeBSkARM(-1, fnrMuzFekWaTkxvLAdALAjiPZJYj.LUDHcuMlWrEkQDkxMNzyZPBXrGEEb(val2), fnrMuzFekWaTkxvLAdALAjiPZJYj.LUDHcuMlWrEkQDkxMNzyZPBXrGEEb(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}
		}

		[Serializable]
		private sealed class WyVMTJuINxidwkFmoAWpezCabNEab
		{
			public static readonly WyVMTJuINxidwkFmoAWpezCabNEab _003C_003E9 = new WyVMTJuINxidwkFmoAWpezCabNEab();

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__195_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__213_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__229_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__245_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__261_0;

			internal void UyWhUDSqswRfgfklVessnJXIuDcm(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void CNxNfZJSLUpXaLaYHoSdsILLcdLm(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void poYbDIEheEIaZpRfUSkNiwNBQMdk(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void AEBYrdhqbQUqwxeizdOYjxbpeDNZ(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void YYbZDVHeNZAuykYIvgmBsGyMWlOK(List<Player_Editor.Mapping> P_0, int P_1)
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

		private sealed class NcuXDhVawCXqBHdWsCPQFuveNBbab
		{
			public List<InputLayout> OmnzTUhAgpOOSqhrTakgcDOKRfQdA;

			internal int EkJgnvwSjRGCoURtFNCwliNkHcweA(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				VoDmKVEoANTlSUgQLxclvwkLehll voDmKVEoANTlSUgQLxclvwkLehll = new VoDmKVEoANTlSUgQLxclvwkLehll();
				voDmKVEoANTlSUgQLxclvwkLehll.QQMojYdZgUaNCXqHVqtcXlOMzOGd = P_0;
				voDmKVEoANTlSUgQLxclvwkLehll.QtAGPkJmwAnRRDeJlLwqHJEDNCEMA = P_1;
				int num = OmnzTUhAgpOOSqhrTakgcDOKRfQdA.FindIndex(voDmKVEoANTlSUgQLxclvwkLehll.UwghorRQJYHtxnHFUiANJfwiueOsA);
				int num2 = OmnzTUhAgpOOSqhrTakgcDOKRfQdA.FindIndex(voDmKVEoANTlSUgQLxclvwkLehll.HaIxmDURwCgQffJyhooNlusNMBGK);
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

		private sealed class VoDmKVEoANTlSUgQLxclvwkLehll
		{
			public ControllerMap_Editor QQMojYdZgUaNCXqHVqtcXlOMzOGd;

			public ControllerMap_Editor QtAGPkJmwAnRRDeJlLwqHJEDNCEMA;

			internal bool UwghorRQJYHtxnHFUiANJfwiueOsA(InputLayout P_0)
			{
				return P_0.id == QQMojYdZgUaNCXqHVqtcXlOMzOGd.id;
			}

			internal bool HaIxmDURwCgQffJyhooNlusNMBGK(InputLayout P_0)
			{
				return P_0.id == QtAGPkJmwAnRRDeJlLwqHJEDNCEMA.id;
			}
		}

		private sealed class IGEtPutzfekmYAWGXNifnwDFKcDF : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int DCStoZdWVpPjqfcTwdHSJhGSIgIY;

			private InputCategory OCfwQNJYrgkeUFjvDYzYlDtRhuou;

			private int zKRCQPhtmkcTwACBGbCPGlYqMOLTb;

			private string nwNMcTAZyIiRKEVDaAPohMZWXszM;

			public string KSTMhQxWQZavQzAbjqoudFcJkWVi;

			public UserData mboAHDXZRqXRDnjPMyxxTGTzFBSP;

			private int PmEyclaobUNdlToZwsTcgyyQmEMx;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return OCfwQNJYrgkeUFjvDYzYlDtRhuou;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return OCfwQNJYrgkeUFjvDYzYlDtRhuou;
				}
			}

			[DebuggerHidden]
			public IGEtPutzfekmYAWGXNifnwDFKcDF(int P_0)
			{
				DCStoZdWVpPjqfcTwdHSJhGSIgIY = P_0;
				zKRCQPhtmkcTwACBGbCPGlYqMOLTb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int dCStoZdWVpPjqfcTwdHSJhGSIgIY = DCStoZdWVpPjqfcTwdHSJhGSIgIY;
				UserData userData = mboAHDXZRqXRDnjPMyxxTGTzFBSP;
				if (dCStoZdWVpPjqfcTwdHSJhGSIgIY != 0)
				{
					if (dCStoZdWVpPjqfcTwdHSJhGSIgIY != 1)
					{
						return false;
					}
					DCStoZdWVpPjqfcTwdHSJhGSIgIY = -1;
					goto IL_0098;
				}
				DCStoZdWVpPjqfcTwdHSJhGSIgIY = -1;
				if (nwNMcTAZyIiRKEVDaAPohMZWXszM == null || nwNMcTAZyIiRKEVDaAPohMZWXszM == string.Empty)
				{
					return false;
				}
				if (userData.actionCategories == null)
				{
					return false;
				}
				PmEyclaobUNdlToZwsTcgyyQmEMx = 0;
				goto IL_00a8;
				IL_00a8:
				if (PmEyclaobUNdlToZwsTcgyyQmEMx < userData.actionCategories.Count)
				{
					if (userData.actionCategories[PmEyclaobUNdlToZwsTcgyyQmEMx].tag.Equals(nwNMcTAZyIiRKEVDaAPohMZWXszM, StringComparison.OrdinalIgnoreCase))
					{
						OCfwQNJYrgkeUFjvDYzYlDtRhuou = userData.actionCategories[PmEyclaobUNdlToZwsTcgyyQmEMx];
						DCStoZdWVpPjqfcTwdHSJhGSIgIY = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				PmEyclaobUNdlToZwsTcgyyQmEMx++;
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
				IGEtPutzfekmYAWGXNifnwDFKcDF iGEtPutzfekmYAWGXNifnwDFKcDF;
				if (DCStoZdWVpPjqfcTwdHSJhGSIgIY == -2 && zKRCQPhtmkcTwACBGbCPGlYqMOLTb == Environment.CurrentManagedThreadId)
				{
					DCStoZdWVpPjqfcTwdHSJhGSIgIY = 0;
					iGEtPutzfekmYAWGXNifnwDFKcDF = this;
				}
				else
				{
					iGEtPutzfekmYAWGXNifnwDFKcDF = new IGEtPutzfekmYAWGXNifnwDFKcDF(0);
					iGEtPutzfekmYAWGXNifnwDFKcDF.mboAHDXZRqXRDnjPMyxxTGTzFBSP = mboAHDXZRqXRDnjPMyxxTGTzFBSP;
				}
				iGEtPutzfekmYAWGXNifnwDFKcDF.nwNMcTAZyIiRKEVDaAPohMZWXszM = KSTMhQxWQZavQzAbjqoudFcJkWVi;
				return iGEtPutzfekmYAWGXNifnwDFKcDF;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class BtiaYjBJiRYVTyanUEOIFYasIWzSA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int CJXwSsbECIxOigssfoeJPQfiMwwu;

			private InputAction IHRgZrTXjftRWRvIzkHQwYEkcmxw;

			private int KTXDjzEoOgWFMekIUsTmkIrUAADIb;

			public UserData VGPGhehszaXlmHbznqbHgspXiZuhA;

			private string wbpaDakdgVMZVGcNkaBFOWGdFbBad;

			public string cpoaHpeAZQMYnUyfZvfeGVPvzLdrA;

			private int zLkLqJcfUrCEWYijrpXZAGONIHIw;

			private int OOUufqyuvgLfsIlofEwotiGJEzyl;

			private InputCategory bVwYqZzKgpBvxQqRUdEMsrwurKLm;

			private int piWHugmhMVVjONppeaaCNXqxhQPy;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return IHRgZrTXjftRWRvIzkHQwYEkcmxw;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return IHRgZrTXjftRWRvIzkHQwYEkcmxw;
				}
			}

			[DebuggerHidden]
			public BtiaYjBJiRYVTyanUEOIFYasIWzSA(int P_0)
			{
				CJXwSsbECIxOigssfoeJPQfiMwwu = P_0;
				KTXDjzEoOgWFMekIUsTmkIrUAADIb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int cJXwSsbECIxOigssfoeJPQfiMwwu = CJXwSsbECIxOigssfoeJPQfiMwwu;
				UserData vGPGhehszaXlmHbznqbHgspXiZuhA = VGPGhehszaXlmHbznqbHgspXiZuhA;
				if (cJXwSsbECIxOigssfoeJPQfiMwwu != 0)
				{
					if (cJXwSsbECIxOigssfoeJPQfiMwwu != 1)
					{
						return false;
					}
					CJXwSsbECIxOigssfoeJPQfiMwwu = -1;
					goto IL_00fd;
				}
				CJXwSsbECIxOigssfoeJPQfiMwwu = -1;
				if (vGPGhehszaXlmHbznqbHgspXiZuhA.actions == null || vGPGhehszaXlmHbznqbHgspXiZuhA.actionCategories == null)
				{
					return false;
				}
				if (wbpaDakdgVMZVGcNkaBFOWGdFbBad == null || wbpaDakdgVMZVGcNkaBFOWGdFbBad == string.Empty)
				{
					return false;
				}
				zLkLqJcfUrCEWYijrpXZAGONIHIw = vGPGhehszaXlmHbznqbHgspXiZuhA.actions.Count;
				OOUufqyuvgLfsIlofEwotiGJEzyl = 0;
				goto IL_0132;
				IL_0122:
				OOUufqyuvgLfsIlofEwotiGJEzyl++;
				goto IL_0132;
				IL_00fd:
				piWHugmhMVVjONppeaaCNXqxhQPy++;
				goto IL_010d;
				IL_010d:
				if (piWHugmhMVVjONppeaaCNXqxhQPy < zLkLqJcfUrCEWYijrpXZAGONIHIw)
				{
					if (bVwYqZzKgpBvxQqRUdEMsrwurKLm.id == vGPGhehszaXlmHbznqbHgspXiZuhA.actions[piWHugmhMVVjONppeaaCNXqxhQPy].categoryId)
					{
						IHRgZrTXjftRWRvIzkHQwYEkcmxw = vGPGhehszaXlmHbznqbHgspXiZuhA.actions[piWHugmhMVVjONppeaaCNXqxhQPy];
						CJXwSsbECIxOigssfoeJPQfiMwwu = 1;
						return true;
					}
					goto IL_00fd;
				}
				bVwYqZzKgpBvxQqRUdEMsrwurKLm = null;
				goto IL_0122;
				IL_0132:
				if (OOUufqyuvgLfsIlofEwotiGJEzyl < vGPGhehszaXlmHbznqbHgspXiZuhA.actionCategories.Count)
				{
					if (vGPGhehszaXlmHbznqbHgspXiZuhA.actionCategories[OOUufqyuvgLfsIlofEwotiGJEzyl].tag.Equals(wbpaDakdgVMZVGcNkaBFOWGdFbBad, StringComparison.OrdinalIgnoreCase))
					{
						bVwYqZzKgpBvxQqRUdEMsrwurKLm = vGPGhehszaXlmHbznqbHgspXiZuhA.actionCategories[OOUufqyuvgLfsIlofEwotiGJEzyl];
						piWHugmhMVVjONppeaaCNXqxhQPy = 0;
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
				BtiaYjBJiRYVTyanUEOIFYasIWzSA btiaYjBJiRYVTyanUEOIFYasIWzSA;
				if (CJXwSsbECIxOigssfoeJPQfiMwwu == -2 && KTXDjzEoOgWFMekIUsTmkIrUAADIb == Environment.CurrentManagedThreadId)
				{
					CJXwSsbECIxOigssfoeJPQfiMwwu = 0;
					btiaYjBJiRYVTyanUEOIFYasIWzSA = this;
				}
				else
				{
					btiaYjBJiRYVTyanUEOIFYasIWzSA = new BtiaYjBJiRYVTyanUEOIFYasIWzSA(0);
					btiaYjBJiRYVTyanUEOIFYasIWzSA.VGPGhehszaXlmHbznqbHgspXiZuhA = VGPGhehszaXlmHbznqbHgspXiZuhA;
				}
				btiaYjBJiRYVTyanUEOIFYasIWzSA.wbpaDakdgVMZVGcNkaBFOWGdFbBad = cpoaHpeAZQMYnUyfZvfeGVPvzLdrA;
				return btiaYjBJiRYVTyanUEOIFYasIWzSA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class zQVDgzmAohimyqZBQIywljDAirHD : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int HFsmyTxbgCxFVEbMaoirtAWvlIzX;

			private InputAction LpRvMJfceYAytTbByHCKjDvZXhud;

			private int ICjfHRdOxwfzXhhXHGpgXVaTtyzd;

			public UserData qDCBSSLuuZcMGVvrOoeXWGbAFWPdA;

			private bool VoLrXvvMShEIMSfiBxXEQaWPsuSl;

			public bool iajjOEBkFqaNzCuTCoaXbJXIIdhRd;

			private int mDkWxdsTTTlidmRAlrJzKYjcOXso;

			public int pxTJHSJYNMcIhlNdaCTfeTiUqZvjA;

			private IEnumerator<int> WcMHiyhTFjTCEpuYQsrREPNoFwyt;

			private int NANkTMouEdLOoeYOZvCYLzDyMmmw;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return LpRvMJfceYAytTbByHCKjDvZXhud;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return LpRvMJfceYAytTbByHCKjDvZXhud;
				}
			}

			[DebuggerHidden]
			public zQVDgzmAohimyqZBQIywljDAirHD(int P_0)
			{
				HFsmyTxbgCxFVEbMaoirtAWvlIzX = P_0;
				ICjfHRdOxwfzXhhXHGpgXVaTtyzd = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int hFsmyTxbgCxFVEbMaoirtAWvlIzX = HFsmyTxbgCxFVEbMaoirtAWvlIzX;
				if (hFsmyTxbgCxFVEbMaoirtAWvlIzX == -3 || hFsmyTxbgCxFVEbMaoirtAWvlIzX == 1)
				{
					try
					{
					}
					finally
					{
						ujsImLOOhfwJjsdDifPmEKJkAzTf();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int hFsmyTxbgCxFVEbMaoirtAWvlIzX = HFsmyTxbgCxFVEbMaoirtAWvlIzX;
					UserData userData = qDCBSSLuuZcMGVvrOoeXWGbAFWPdA;
					switch (hFsmyTxbgCxFVEbMaoirtAWvlIzX)
					{
					default:
						return false;
					case 0:
						HFsmyTxbgCxFVEbMaoirtAWvlIzX = -1;
						if (userData.actions == null || userData.actionCategories == null)
						{
							return false;
						}
						if (VoLrXvvMShEIMSfiBxXEQaWPsuSl)
						{
							WcMHiyhTFjTCEpuYQsrREPNoFwyt = userData.SortedActionIdsInCategory(mDkWxdsTTTlidmRAlrJzKYjcOXso).GetEnumerator();
							HFsmyTxbgCxFVEbMaoirtAWvlIzX = -3;
							goto IL_00a5;
						}
						NANkTMouEdLOoeYOZvCYLzDyMmmw = 0;
						goto IL_0123;
					case 1:
						HFsmyTxbgCxFVEbMaoirtAWvlIzX = -3;
						goto IL_00a5;
					case 2:
						{
							HFsmyTxbgCxFVEbMaoirtAWvlIzX = -1;
							goto IL_0111;
						}
						IL_0123:
						if (NANkTMouEdLOoeYOZvCYLzDyMmmw >= userData.actions.Count)
						{
							break;
						}
						if (userData.actions[NANkTMouEdLOoeYOZvCYLzDyMmmw].categoryId == mDkWxdsTTTlidmRAlrJzKYjcOXso)
						{
							LpRvMJfceYAytTbByHCKjDvZXhud = userData.actions[NANkTMouEdLOoeYOZvCYLzDyMmmw];
							HFsmyTxbgCxFVEbMaoirtAWvlIzX = 2;
							return true;
						}
						goto IL_0111;
						IL_0111:
						NANkTMouEdLOoeYOZvCYLzDyMmmw++;
						goto IL_0123;
						IL_00a5:
						while (WcMHiyhTFjTCEpuYQsrREPNoFwyt.MoveNext())
						{
							int current = WcMHiyhTFjTCEpuYQsrREPNoFwyt.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null)
							{
								LpRvMJfceYAytTbByHCKjDvZXhud = actionById;
								HFsmyTxbgCxFVEbMaoirtAWvlIzX = 1;
								return true;
							}
						}
						ujsImLOOhfwJjsdDifPmEKJkAzTf();
						WcMHiyhTFjTCEpuYQsrREPNoFwyt = null;
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

			private void ujsImLOOhfwJjsdDifPmEKJkAzTf()
			{
				HFsmyTxbgCxFVEbMaoirtAWvlIzX = -1;
				if (WcMHiyhTFjTCEpuYQsrREPNoFwyt != null)
				{
					WcMHiyhTFjTCEpuYQsrREPNoFwyt.Dispose();
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
				zQVDgzmAohimyqZBQIywljDAirHD zQVDgzmAohimyqZBQIywljDAirHD2;
				if (HFsmyTxbgCxFVEbMaoirtAWvlIzX == -2 && ICjfHRdOxwfzXhhXHGpgXVaTtyzd == Environment.CurrentManagedThreadId)
				{
					HFsmyTxbgCxFVEbMaoirtAWvlIzX = 0;
					zQVDgzmAohimyqZBQIywljDAirHD2 = this;
				}
				else
				{
					zQVDgzmAohimyqZBQIywljDAirHD2 = new zQVDgzmAohimyqZBQIywljDAirHD(0);
					zQVDgzmAohimyqZBQIywljDAirHD2.qDCBSSLuuZcMGVvrOoeXWGbAFWPdA = qDCBSSLuuZcMGVvrOoeXWGbAFWPdA;
				}
				zQVDgzmAohimyqZBQIywljDAirHD2.mDkWxdsTTTlidmRAlrJzKYjcOXso = pxTJHSJYNMcIhlNdaCTfeTiUqZvjA;
				zQVDgzmAohimyqZBQIywljDAirHD2.VoLrXvvMShEIMSfiBxXEQaWPsuSl = iajjOEBkFqaNzCuTCoaXbJXIIdhRd;
				return zQVDgzmAohimyqZBQIywljDAirHD2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class kydHIzccJeiemgnIkfXVirwLqhfcA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int yyZiknBilnfgNDeiOkHcNAKQEhzu;

			private InputAction mNugTWfpkzMEmfVHZsPLAsaCxqpYb;

			private int gBCiLVCBJzKMIzVbpaoFtXlfofRJA;

			public UserData xowZoCtWoUMUTsEEOuaKRFmIjRUS;

			private string oniSKTnseTELIEkTBxGBYfwmeCtl;

			public string PjXzNBvhikDOmDfXwopsKKvvmDal;

			private bool sidMDJgWSOKGENlqHPgAINnXiEuy;

			public bool YatDihOFwmReYtTBBBTUXMUamawN;

			private InputCategory zOOceOWyOJdJVMhxbdxVRQIFkKRG;

			private IEnumerator<int> QMJUEHPXZnbhffXCTyBnarjaQUei;

			private int pFsWIBJtHzNgVHzDtSnRyLegNzZ;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return mNugTWfpkzMEmfVHZsPLAsaCxqpYb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return mNugTWfpkzMEmfVHZsPLAsaCxqpYb;
				}
			}

			[DebuggerHidden]
			public kydHIzccJeiemgnIkfXVirwLqhfcA(int P_0)
			{
				yyZiknBilnfgNDeiOkHcNAKQEhzu = P_0;
				gBCiLVCBJzKMIzVbpaoFtXlfofRJA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = yyZiknBilnfgNDeiOkHcNAKQEhzu;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						MWCaUyiXxOEcHACzfGHZgQeTydCpA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = yyZiknBilnfgNDeiOkHcNAKQEhzu;
					UserData userData = xowZoCtWoUMUTsEEOuaKRFmIjRUS;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						yyZiknBilnfgNDeiOkHcNAKQEhzu = -1;
						if (userData.actions == null || userData.actionCategories == null)
						{
							return false;
						}
						if (oniSKTnseTELIEkTBxGBYfwmeCtl == null || oniSKTnseTELIEkTBxGBYfwmeCtl == string.Empty)
						{
							return false;
						}
						int num2 = userData.IndexOfActionCategory(oniSKTnseTELIEkTBxGBYfwmeCtl);
						if (num2 < 0)
						{
							return false;
						}
						zOOceOWyOJdJVMhxbdxVRQIFkKRG = userData.GetActionCategory(num2);
						if (sidMDJgWSOKGENlqHPgAINnXiEuy)
						{
							QMJUEHPXZnbhffXCTyBnarjaQUei = userData.SortedActionIdsInCategory(zOOceOWyOJdJVMhxbdxVRQIFkKRG.id).GetEnumerator();
							yyZiknBilnfgNDeiOkHcNAKQEhzu = -3;
							goto IL_00f2;
						}
						pFsWIBJtHzNgVHzDtSnRyLegNzZ = 0;
						goto IL_0175;
					}
					case 1:
						yyZiknBilnfgNDeiOkHcNAKQEhzu = -3;
						goto IL_00f2;
					case 2:
						{
							yyZiknBilnfgNDeiOkHcNAKQEhzu = -1;
							goto IL_0163;
						}
						IL_0175:
						if (pFsWIBJtHzNgVHzDtSnRyLegNzZ >= userData.actions.Count)
						{
							break;
						}
						if (userData.actions[pFsWIBJtHzNgVHzDtSnRyLegNzZ].categoryId == zOOceOWyOJdJVMhxbdxVRQIFkKRG.id)
						{
							mNugTWfpkzMEmfVHZsPLAsaCxqpYb = userData.actions[pFsWIBJtHzNgVHzDtSnRyLegNzZ];
							yyZiknBilnfgNDeiOkHcNAKQEhzu = 2;
							return true;
						}
						goto IL_0163;
						IL_00f2:
						while (QMJUEHPXZnbhffXCTyBnarjaQUei.MoveNext())
						{
							int current = QMJUEHPXZnbhffXCTyBnarjaQUei.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null)
							{
								mNugTWfpkzMEmfVHZsPLAsaCxqpYb = actionById;
								yyZiknBilnfgNDeiOkHcNAKQEhzu = 1;
								return true;
							}
						}
						MWCaUyiXxOEcHACzfGHZgQeTydCpA();
						QMJUEHPXZnbhffXCTyBnarjaQUei = null;
						break;
						IL_0163:
						pFsWIBJtHzNgVHzDtSnRyLegNzZ++;
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

			private void MWCaUyiXxOEcHACzfGHZgQeTydCpA()
			{
				yyZiknBilnfgNDeiOkHcNAKQEhzu = -1;
				if (QMJUEHPXZnbhffXCTyBnarjaQUei != null)
				{
					QMJUEHPXZnbhffXCTyBnarjaQUei.Dispose();
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
				kydHIzccJeiemgnIkfXVirwLqhfcA kydHIzccJeiemgnIkfXVirwLqhfcA2;
				if (yyZiknBilnfgNDeiOkHcNAKQEhzu == -2 && gBCiLVCBJzKMIzVbpaoFtXlfofRJA == Environment.CurrentManagedThreadId)
				{
					yyZiknBilnfgNDeiOkHcNAKQEhzu = 0;
					kydHIzccJeiemgnIkfXVirwLqhfcA2 = this;
				}
				else
				{
					kydHIzccJeiemgnIkfXVirwLqhfcA2 = new kydHIzccJeiemgnIkfXVirwLqhfcA(0);
					kydHIzccJeiemgnIkfXVirwLqhfcA2.xowZoCtWoUMUTsEEOuaKRFmIjRUS = xowZoCtWoUMUTsEEOuaKRFmIjRUS;
				}
				kydHIzccJeiemgnIkfXVirwLqhfcA2.oniSKTnseTELIEkTBxGBYfwmeCtl = PjXzNBvhikDOmDfXwopsKKvvmDal;
				kydHIzccJeiemgnIkfXVirwLqhfcA2.sidMDJgWSOKGENlqHPgAINnXiEuy = YatDihOFwmReYtTBBBTUXMUamawN;
				return kydHIzccJeiemgnIkfXVirwLqhfcA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class ZHgoNBekISVRTLPbuOlZapkvpbYq : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int AmQFJznJRsmnHMxlBEaayhHYxUsr;

			private InputMapCategory UmsDaphgORPinoedJcHCQzqewUhEA;

			private int hckdzzoTsQvPgDkjncQvspeaynfJ;

			private string rptvMHNoSvKzpWtAViGIUYbkKmmS;

			public string QvUfnBkfsjkiUsxbIxcPYDvwzHHS;

			public UserData ftZbIMkxtnIyWmhZWPaahoZAcWEHb;

			private int lOekusugPpNstHwyQzTgNAWfxrsi;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return UmsDaphgORPinoedJcHCQzqewUhEA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UmsDaphgORPinoedJcHCQzqewUhEA;
				}
			}

			[DebuggerHidden]
			public ZHgoNBekISVRTLPbuOlZapkvpbYq(int P_0)
			{
				AmQFJznJRsmnHMxlBEaayhHYxUsr = P_0;
				hckdzzoTsQvPgDkjncQvspeaynfJ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int amQFJznJRsmnHMxlBEaayhHYxUsr = AmQFJznJRsmnHMxlBEaayhHYxUsr;
				UserData userData = ftZbIMkxtnIyWmhZWPaahoZAcWEHb;
				if (amQFJznJRsmnHMxlBEaayhHYxUsr != 0)
				{
					if (amQFJznJRsmnHMxlBEaayhHYxUsr != 1)
					{
						return false;
					}
					AmQFJznJRsmnHMxlBEaayhHYxUsr = -1;
					goto IL_0098;
				}
				AmQFJznJRsmnHMxlBEaayhHYxUsr = -1;
				if (rptvMHNoSvKzpWtAViGIUYbkKmmS == null || rptvMHNoSvKzpWtAViGIUYbkKmmS == string.Empty)
				{
					return false;
				}
				if (userData.mapCategories == null)
				{
					return false;
				}
				lOekusugPpNstHwyQzTgNAWfxrsi = 0;
				goto IL_00a8;
				IL_00a8:
				if (lOekusugPpNstHwyQzTgNAWfxrsi < userData.mapCategories.Count)
				{
					if (userData.mapCategories[lOekusugPpNstHwyQzTgNAWfxrsi].tag.Equals(rptvMHNoSvKzpWtAViGIUYbkKmmS, StringComparison.OrdinalIgnoreCase))
					{
						UmsDaphgORPinoedJcHCQzqewUhEA = userData.mapCategories[lOekusugPpNstHwyQzTgNAWfxrsi];
						AmQFJznJRsmnHMxlBEaayhHYxUsr = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				lOekusugPpNstHwyQzTgNAWfxrsi++;
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
				ZHgoNBekISVRTLPbuOlZapkvpbYq zHgoNBekISVRTLPbuOlZapkvpbYq;
				if (AmQFJznJRsmnHMxlBEaayhHYxUsr == -2 && hckdzzoTsQvPgDkjncQvspeaynfJ == Environment.CurrentManagedThreadId)
				{
					AmQFJznJRsmnHMxlBEaayhHYxUsr = 0;
					zHgoNBekISVRTLPbuOlZapkvpbYq = this;
				}
				else
				{
					zHgoNBekISVRTLPbuOlZapkvpbYq = new ZHgoNBekISVRTLPbuOlZapkvpbYq(0);
					zHgoNBekISVRTLPbuOlZapkvpbYq.ftZbIMkxtnIyWmhZWPaahoZAcWEHb = ftZbIMkxtnIyWmhZWPaahoZAcWEHb;
				}
				zHgoNBekISVRTLPbuOlZapkvpbYq.rptvMHNoSvKzpWtAViGIUYbkKmmS = QvUfnBkfsjkiUsxbIxcPYDvwzHHS;
				return zHgoNBekISVRTLPbuOlZapkvpbYq;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class LTumRnbtubGPmEIOVNQmSvmFIkfw : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int RRgfjQzImoHvnFZkxcQDTDRprQtsA;

			private string spKEbxtOttNDepAWYhFKnMJQsgHM;

			private int nfSHBCvaoNClTsCFHTbeYFLwDWFz;

			public UserData PpRgPOHGbRPzkqJAOTKGxGTdyPTrA;

			private int YYPbIZhbXmboljLnbhnpfZowDhrwA;

			public int KPTYBJjOyieNgycpPdLhQzDANSBN;

			private IEnumerator<int> lsoQXPERCqaUOHFqINMZHnyuDgZJ;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return spKEbxtOttNDepAWYhFKnMJQsgHM;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return spKEbxtOttNDepAWYhFKnMJQsgHM;
				}
			}

			[DebuggerHidden]
			public LTumRnbtubGPmEIOVNQmSvmFIkfw(int P_0)
			{
				RRgfjQzImoHvnFZkxcQDTDRprQtsA = P_0;
				nfSHBCvaoNClTsCFHTbeYFLwDWFz = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int rRgfjQzImoHvnFZkxcQDTDRprQtsA = RRgfjQzImoHvnFZkxcQDTDRprQtsA;
				if (rRgfjQzImoHvnFZkxcQDTDRprQtsA == -3 || rRgfjQzImoHvnFZkxcQDTDRprQtsA == 1)
				{
					try
					{
					}
					finally
					{
						urLeJPdIZMYNUqkFtrscwgccAZBNA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int rRgfjQzImoHvnFZkxcQDTDRprQtsA = RRgfjQzImoHvnFZkxcQDTDRprQtsA;
					UserData ppRgPOHGbRPzkqJAOTKGxGTdyPTrA = PpRgPOHGbRPzkqJAOTKGxGTdyPTrA;
					switch (rRgfjQzImoHvnFZkxcQDTDRprQtsA)
					{
					default:
						return false;
					case 0:
						RRgfjQzImoHvnFZkxcQDTDRprQtsA = -1;
						if (ppRgPOHGbRPzkqJAOTKGxGTdyPTrA.actionCategories == null || ppRgPOHGbRPzkqJAOTKGxGTdyPTrA.actions == null)
						{
							return false;
						}
						lsoQXPERCqaUOHFqINMZHnyuDgZJ = ppRgPOHGbRPzkqJAOTKGxGTdyPTrA.actionCategoryMap.ActionIdsInCategory(YYPbIZhbXmboljLnbhnpfZowDhrwA).GetEnumerator();
						RRgfjQzImoHvnFZkxcQDTDRprQtsA = -3;
						break;
					case 1:
						RRgfjQzImoHvnFZkxcQDTDRprQtsA = -3;
						break;
					}
					while (lsoQXPERCqaUOHFqINMZHnyuDgZJ.MoveNext())
					{
						int current = lsoQXPERCqaUOHFqINMZHnyuDgZJ.Current;
						InputAction actionById = ppRgPOHGbRPzkqJAOTKGxGTdyPTrA.GetActionById(current);
						if (actionById != null)
						{
							spKEbxtOttNDepAWYhFKnMJQsgHM = actionById.descriptiveName;
							RRgfjQzImoHvnFZkxcQDTDRprQtsA = 1;
							return true;
						}
					}
					urLeJPdIZMYNUqkFtrscwgccAZBNA();
					lsoQXPERCqaUOHFqINMZHnyuDgZJ = null;
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

			private void urLeJPdIZMYNUqkFtrscwgccAZBNA()
			{
				RRgfjQzImoHvnFZkxcQDTDRprQtsA = -1;
				if (lsoQXPERCqaUOHFqINMZHnyuDgZJ != null)
				{
					lsoQXPERCqaUOHFqINMZHnyuDgZJ.Dispose();
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
				LTumRnbtubGPmEIOVNQmSvmFIkfw lTumRnbtubGPmEIOVNQmSvmFIkfw;
				if (RRgfjQzImoHvnFZkxcQDTDRprQtsA == -2 && nfSHBCvaoNClTsCFHTbeYFLwDWFz == Environment.CurrentManagedThreadId)
				{
					RRgfjQzImoHvnFZkxcQDTDRprQtsA = 0;
					lTumRnbtubGPmEIOVNQmSvmFIkfw = this;
				}
				else
				{
					lTumRnbtubGPmEIOVNQmSvmFIkfw = new LTumRnbtubGPmEIOVNQmSvmFIkfw(0);
					lTumRnbtubGPmEIOVNQmSvmFIkfw.PpRgPOHGbRPzkqJAOTKGxGTdyPTrA = PpRgPOHGbRPzkqJAOTKGxGTdyPTrA;
				}
				lTumRnbtubGPmEIOVNQmSvmFIkfw.YYPbIZhbXmboljLnbhnpfZowDhrwA = KPTYBJjOyieNgycpPdLhQzDANSBN;
				return lTumRnbtubGPmEIOVNQmSvmFIkfw;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class EgBxLrlYEWeBewaQZmWXRcfFVEfU : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int KLCXjkvxxbHRgWvzoUqkgvIgeuLb;

			private int IRaHLYmbXFvmjGcuqiyYJtjVryJG;

			private int CEFPLneccqNyRWuNfMybVjNeuPmy;

			public UserData jtQPbmfRNUyeZfKfQQlDzcEkdYie;

			private int NhAlpqCTmBKrxLlfehQTKrphFUaxA;

			public int TUlVYFbUsEuaozwYCLhvLlOOyQYc;

			private IEnumerator<int> GSWTsHiHukgUEXjxxVFaWrrCNnkS;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return IRaHLYmbXFvmjGcuqiyYJtjVryJG;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return IRaHLYmbXFvmjGcuqiyYJtjVryJG;
				}
			}

			[DebuggerHidden]
			public EgBxLrlYEWeBewaQZmWXRcfFVEfU(int P_0)
			{
				KLCXjkvxxbHRgWvzoUqkgvIgeuLb = P_0;
				CEFPLneccqNyRWuNfMybVjNeuPmy = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int kLCXjkvxxbHRgWvzoUqkgvIgeuLb = KLCXjkvxxbHRgWvzoUqkgvIgeuLb;
				if (kLCXjkvxxbHRgWvzoUqkgvIgeuLb == -3 || kLCXjkvxxbHRgWvzoUqkgvIgeuLb == 1)
				{
					try
					{
					}
					finally
					{
						RLpoivIioTNhNJtWjKeygSkkyUgJ();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int kLCXjkvxxbHRgWvzoUqkgvIgeuLb = KLCXjkvxxbHRgWvzoUqkgvIgeuLb;
					UserData userData = jtQPbmfRNUyeZfKfQQlDzcEkdYie;
					switch (kLCXjkvxxbHRgWvzoUqkgvIgeuLb)
					{
					default:
						return false;
					case 0:
						KLCXjkvxxbHRgWvzoUqkgvIgeuLb = -1;
						if (userData.actionCategories == null || userData.actions == null)
						{
							return false;
						}
						GSWTsHiHukgUEXjxxVFaWrrCNnkS = userData.actionCategoryMap.ActionIdsInCategory(NhAlpqCTmBKrxLlfehQTKrphFUaxA).GetEnumerator();
						KLCXjkvxxbHRgWvzoUqkgvIgeuLb = -3;
						break;
					case 1:
						KLCXjkvxxbHRgWvzoUqkgvIgeuLb = -3;
						break;
					}
					if (GSWTsHiHukgUEXjxxVFaWrrCNnkS.MoveNext())
					{
						int current = GSWTsHiHukgUEXjxxVFaWrrCNnkS.Current;
						IRaHLYmbXFvmjGcuqiyYJtjVryJG = current;
						KLCXjkvxxbHRgWvzoUqkgvIgeuLb = 1;
						return true;
					}
					RLpoivIioTNhNJtWjKeygSkkyUgJ();
					GSWTsHiHukgUEXjxxVFaWrrCNnkS = null;
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

			private void RLpoivIioTNhNJtWjKeygSkkyUgJ()
			{
				KLCXjkvxxbHRgWvzoUqkgvIgeuLb = -1;
				if (GSWTsHiHukgUEXjxxVFaWrrCNnkS != null)
				{
					GSWTsHiHukgUEXjxxVFaWrrCNnkS.Dispose();
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
				EgBxLrlYEWeBewaQZmWXRcfFVEfU egBxLrlYEWeBewaQZmWXRcfFVEfU;
				if (KLCXjkvxxbHRgWvzoUqkgvIgeuLb == -2 && CEFPLneccqNyRWuNfMybVjNeuPmy == Environment.CurrentManagedThreadId)
				{
					KLCXjkvxxbHRgWvzoUqkgvIgeuLb = 0;
					egBxLrlYEWeBewaQZmWXRcfFVEfU = this;
				}
				else
				{
					egBxLrlYEWeBewaQZmWXRcfFVEfU = new EgBxLrlYEWeBewaQZmWXRcfFVEfU(0);
					egBxLrlYEWeBewaQZmWXRcfFVEfU.jtQPbmfRNUyeZfKfQQlDzcEkdYie = jtQPbmfRNUyeZfKfQQlDzcEkdYie;
				}
				egBxLrlYEWeBewaQZmWXRcfFVEfU.NhAlpqCTmBKrxLlfehQTKrphFUaxA = TUlVYFbUsEuaozwYCLhvLlOOyQYc;
				return egBxLrlYEWeBewaQZmWXRcfFVEfU;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		private sealed class pcYFDtdIMBbdhcyUHkTBcAYglbAoe : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int QsTjbTxllDbPixuWAunBnrLmZgRJ;

			private string EvaWKupcjoOqeKLvVxGchuCshZSq;

			private int JGoHejjplVshBEcUJjEaNoHBBUnI;

			public UserData XUPnbWziBrUezKglRPQwTmBGJYql;

			private int OaSAfGClXozXFdiefRJSHMOBOdDqc;

			public int ZwlyjccODVDoSssDgrfVYtLioXMk;

			private IEnumerator<int> EowTDLdzqMmDCRDdYgzdAuWcVOBC;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return EvaWKupcjoOqeKLvVxGchuCshZSq;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return EvaWKupcjoOqeKLvVxGchuCshZSq;
				}
			}

			[DebuggerHidden]
			public pcYFDtdIMBbdhcyUHkTBcAYglbAoe(int P_0)
			{
				QsTjbTxllDbPixuWAunBnrLmZgRJ = P_0;
				JGoHejjplVshBEcUJjEaNoHBBUnI = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int qsTjbTxllDbPixuWAunBnrLmZgRJ = QsTjbTxllDbPixuWAunBnrLmZgRJ;
				if (qsTjbTxllDbPixuWAunBnrLmZgRJ == -3 || qsTjbTxllDbPixuWAunBnrLmZgRJ == 1)
				{
					try
					{
					}
					finally
					{
						HcVQhJfwxyiKVdMwntGQBgrHrwJq();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int qsTjbTxllDbPixuWAunBnrLmZgRJ = QsTjbTxllDbPixuWAunBnrLmZgRJ;
					UserData xUPnbWziBrUezKglRPQwTmBGJYql = XUPnbWziBrUezKglRPQwTmBGJYql;
					switch (qsTjbTxllDbPixuWAunBnrLmZgRJ)
					{
					default:
						return false;
					case 0:
						QsTjbTxllDbPixuWAunBnrLmZgRJ = -1;
						if (xUPnbWziBrUezKglRPQwTmBGJYql.actionCategories == null || xUPnbWziBrUezKglRPQwTmBGJYql.actions == null)
						{
							return false;
						}
						EowTDLdzqMmDCRDdYgzdAuWcVOBC = xUPnbWziBrUezKglRPQwTmBGJYql.actionCategoryMap.ActionIdsInCategory(OaSAfGClXozXFdiefRJSHMOBOdDqc).GetEnumerator();
						QsTjbTxllDbPixuWAunBnrLmZgRJ = -3;
						break;
					case 1:
						QsTjbTxllDbPixuWAunBnrLmZgRJ = -3;
						break;
					}
					while (EowTDLdzqMmDCRDdYgzdAuWcVOBC.MoveNext())
					{
						int current = EowTDLdzqMmDCRDdYgzdAuWcVOBC.Current;
						InputAction actionById = xUPnbWziBrUezKglRPQwTmBGJYql.GetActionById(current);
						if (actionById != null)
						{
							EvaWKupcjoOqeKLvVxGchuCshZSq = actionById.name;
							QsTjbTxllDbPixuWAunBnrLmZgRJ = 1;
							return true;
						}
					}
					HcVQhJfwxyiKVdMwntGQBgrHrwJq();
					EowTDLdzqMmDCRDdYgzdAuWcVOBC = null;
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

			private void HcVQhJfwxyiKVdMwntGQBgrHrwJq()
			{
				QsTjbTxllDbPixuWAunBnrLmZgRJ = -1;
				if (EowTDLdzqMmDCRDdYgzdAuWcVOBC != null)
				{
					EowTDLdzqMmDCRDdYgzdAuWcVOBC.Dispose();
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
				pcYFDtdIMBbdhcyUHkTBcAYglbAoe pcYFDtdIMBbdhcyUHkTBcAYglbAoe2;
				if (QsTjbTxllDbPixuWAunBnrLmZgRJ == -2 && JGoHejjplVshBEcUJjEaNoHBBUnI == Environment.CurrentManagedThreadId)
				{
					QsTjbTxllDbPixuWAunBnrLmZgRJ = 0;
					pcYFDtdIMBbdhcyUHkTBcAYglbAoe2 = this;
				}
				else
				{
					pcYFDtdIMBbdhcyUHkTBcAYglbAoe2 = new pcYFDtdIMBbdhcyUHkTBcAYglbAoe(0);
					pcYFDtdIMBbdhcyUHkTBcAYglbAoe2.XUPnbWziBrUezKglRPQwTmBGJYql = XUPnbWziBrUezKglRPQwTmBGJYql;
				}
				pcYFDtdIMBbdhcyUHkTBcAYglbAoe2.OaSAfGClXozXFdiefRJSHMOBOdDqc = ZwlyjccODVDoSssDgrfVYtLioXMk;
				return pcYFDtdIMBbdhcyUHkTBcAYglbAoe2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class jOzudtahYVgiYpUgFsjKQUVCtlxS : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int qQnViTnHYDZxRxIyBQhfdsOwizKcA;

			private InputCategory bbFyRXvcwTBTeLeLXvhnEFUrBvM;

			private int mugUQyeqLQJSXWCpkAxHQcXhQBju;

			private string vftZAMRQakkJmfudBcBdovTvOtQl;

			public string UmRZBSuXKIqkmatopXVhnVWwUHeh;

			public UserData QnQEOqXaBwmTitrdGnvyRbGAeucP;

			private int cYUbCaZlvsTtaLsZWBZBeWteWMdB;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return bbFyRXvcwTBTeLeLXvhnEFUrBvM;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return bbFyRXvcwTBTeLeLXvhnEFUrBvM;
				}
			}

			[DebuggerHidden]
			public jOzudtahYVgiYpUgFsjKQUVCtlxS(int P_0)
			{
				qQnViTnHYDZxRxIyBQhfdsOwizKcA = P_0;
				mugUQyeqLQJSXWCpkAxHQcXhQBju = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = qQnViTnHYDZxRxIyBQhfdsOwizKcA;
				UserData qnQEOqXaBwmTitrdGnvyRbGAeucP = QnQEOqXaBwmTitrdGnvyRbGAeucP;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					qQnViTnHYDZxRxIyBQhfdsOwizKcA = -1;
					goto IL_00b3;
				}
				qQnViTnHYDZxRxIyBQhfdsOwizKcA = -1;
				if (vftZAMRQakkJmfudBcBdovTvOtQl == null || vftZAMRQakkJmfudBcBdovTvOtQl == string.Empty)
				{
					return false;
				}
				if (qnQEOqXaBwmTitrdGnvyRbGAeucP.actionCategories == null)
				{
					return false;
				}
				cYUbCaZlvsTtaLsZWBZBeWteWMdB = 0;
				goto IL_00c3;
				IL_00c3:
				if (cYUbCaZlvsTtaLsZWBZBeWteWMdB < qnQEOqXaBwmTitrdGnvyRbGAeucP.actionCategories.Count)
				{
					if (qnQEOqXaBwmTitrdGnvyRbGAeucP.actionCategories[cYUbCaZlvsTtaLsZWBZBeWteWMdB].userAssignable && qnQEOqXaBwmTitrdGnvyRbGAeucP.actionCategories[cYUbCaZlvsTtaLsZWBZBeWteWMdB].tag.Equals(vftZAMRQakkJmfudBcBdovTvOtQl, StringComparison.OrdinalIgnoreCase))
					{
						bbFyRXvcwTBTeLeLXvhnEFUrBvM = qnQEOqXaBwmTitrdGnvyRbGAeucP.actionCategories[cYUbCaZlvsTtaLsZWBZBeWteWMdB];
						qQnViTnHYDZxRxIyBQhfdsOwizKcA = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				cYUbCaZlvsTtaLsZWBZBeWteWMdB++;
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
				jOzudtahYVgiYpUgFsjKQUVCtlxS jOzudtahYVgiYpUgFsjKQUVCtlxS2;
				if (qQnViTnHYDZxRxIyBQhfdsOwizKcA == -2 && mugUQyeqLQJSXWCpkAxHQcXhQBju == Environment.CurrentManagedThreadId)
				{
					qQnViTnHYDZxRxIyBQhfdsOwizKcA = 0;
					jOzudtahYVgiYpUgFsjKQUVCtlxS2 = this;
				}
				else
				{
					jOzudtahYVgiYpUgFsjKQUVCtlxS2 = new jOzudtahYVgiYpUgFsjKQUVCtlxS(0);
					jOzudtahYVgiYpUgFsjKQUVCtlxS2.QnQEOqXaBwmTitrdGnvyRbGAeucP = QnQEOqXaBwmTitrdGnvyRbGAeucP;
				}
				jOzudtahYVgiYpUgFsjKQUVCtlxS2.vftZAMRQakkJmfudBcBdovTvOtQl = UmRZBSuXKIqkmatopXVhnVWwUHeh;
				return jOzudtahYVgiYpUgFsjKQUVCtlxS2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class jpgAeiiaNyOIkAAZQaVIDMcDduFr : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int kRxtLtnGLEmOyhimZgLwdZpIwXbeA;

			private InputAction aWbDUfkjddobpVWPWmiBUNclyehq;

			private int sjPDCKeOVQsrybfBVsaUsEwtsZUC;

			public UserData ONqAyLcvrSegCIALohEgvPxUolfgA;

			private int ZRrnWcGXhiddzdcJgxlhYdlaafhcA;

			public int lLUHzjwVlmILhGvilEjxfiteSfLF;

			private bool sIChGYiUfbGWqoAmNzXBUGlnnYhe;

			public bool BeVqKpMNjfYYycvLjWwrVjdzaUpO;

			private InputCategory oVkQrkdtqnfkkkLwIEzZURcFpuWy;

			private IEnumerator<int> PgfeTQqkmPymdcDuRCcDJRLnJsLv;

			private int pChSuPtWCVVTkSwqoNMFzEjJsEqL;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return aWbDUfkjddobpVWPWmiBUNclyehq;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aWbDUfkjddobpVWPWmiBUNclyehq;
				}
			}

			[DebuggerHidden]
			public jpgAeiiaNyOIkAAZQaVIDMcDduFr(int P_0)
			{
				kRxtLtnGLEmOyhimZgLwdZpIwXbeA = P_0;
				sjPDCKeOVQsrybfBVsaUsEwtsZUC = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = kRxtLtnGLEmOyhimZgLwdZpIwXbeA;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						kliNIMCNaNCUkyMHAHcwtVaSmJUg();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = kRxtLtnGLEmOyhimZgLwdZpIwXbeA;
					UserData oNqAyLcvrSegCIALohEgvPxUolfgA = ONqAyLcvrSegCIALohEgvPxUolfgA;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						kRxtLtnGLEmOyhimZgLwdZpIwXbeA = -1;
						if (oNqAyLcvrSegCIALohEgvPxUolfgA.actions == null || oNqAyLcvrSegCIALohEgvPxUolfgA.actionCategories == null)
						{
							return false;
						}
						oVkQrkdtqnfkkkLwIEzZURcFpuWy = oNqAyLcvrSegCIALohEgvPxUolfgA.GetActionCategoryById(ZRrnWcGXhiddzdcJgxlhYdlaafhcA);
						if (oVkQrkdtqnfkkkLwIEzZURcFpuWy == null || !oVkQrkdtqnfkkkLwIEzZURcFpuWy.userAssignable)
						{
							return false;
						}
						if (sIChGYiUfbGWqoAmNzXBUGlnnYhe)
						{
							PgfeTQqkmPymdcDuRCcDJRLnJsLv = oNqAyLcvrSegCIALohEgvPxUolfgA.SortedActionIdsInCategory(oVkQrkdtqnfkkkLwIEzZURcFpuWy.id).GetEnumerator();
							kRxtLtnGLEmOyhimZgLwdZpIwXbeA = -3;
							goto IL_00e4;
						}
						pChSuPtWCVVTkSwqoNMFzEjJsEqL = 0;
						goto IL_0165;
					case 1:
						kRxtLtnGLEmOyhimZgLwdZpIwXbeA = -3;
						goto IL_00e4;
					case 2:
						{
							kRxtLtnGLEmOyhimZgLwdZpIwXbeA = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (PgfeTQqkmPymdcDuRCcDJRLnJsLv.MoveNext())
						{
							int current = PgfeTQqkmPymdcDuRCcDJRLnJsLv.Current;
							InputAction actionById = oNqAyLcvrSegCIALohEgvPxUolfgA.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								aWbDUfkjddobpVWPWmiBUNclyehq = actionById;
								kRxtLtnGLEmOyhimZgLwdZpIwXbeA = 1;
								return true;
							}
						}
						kliNIMCNaNCUkyMHAHcwtVaSmJUg();
						PgfeTQqkmPymdcDuRCcDJRLnJsLv = null;
						break;
						IL_0153:
						pChSuPtWCVVTkSwqoNMFzEjJsEqL++;
						goto IL_0165;
						IL_0165:
						if (pChSuPtWCVVTkSwqoNMFzEjJsEqL >= oNqAyLcvrSegCIALohEgvPxUolfgA.actions.Count)
						{
							break;
						}
						inputAction = oNqAyLcvrSegCIALohEgvPxUolfgA.actions[pChSuPtWCVVTkSwqoNMFzEjJsEqL];
						if (inputAction.categoryId == oVkQrkdtqnfkkkLwIEzZURcFpuWy.id && inputAction.userAssignable)
						{
							aWbDUfkjddobpVWPWmiBUNclyehq = inputAction;
							kRxtLtnGLEmOyhimZgLwdZpIwXbeA = 2;
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

			private void kliNIMCNaNCUkyMHAHcwtVaSmJUg()
			{
				kRxtLtnGLEmOyhimZgLwdZpIwXbeA = -1;
				if (PgfeTQqkmPymdcDuRCcDJRLnJsLv != null)
				{
					PgfeTQqkmPymdcDuRCcDJRLnJsLv.Dispose();
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
				jpgAeiiaNyOIkAAZQaVIDMcDduFr jpgAeiiaNyOIkAAZQaVIDMcDduFr2;
				if (kRxtLtnGLEmOyhimZgLwdZpIwXbeA == -2 && sjPDCKeOVQsrybfBVsaUsEwtsZUC == Environment.CurrentManagedThreadId)
				{
					kRxtLtnGLEmOyhimZgLwdZpIwXbeA = 0;
					jpgAeiiaNyOIkAAZQaVIDMcDduFr2 = this;
				}
				else
				{
					jpgAeiiaNyOIkAAZQaVIDMcDduFr2 = new jpgAeiiaNyOIkAAZQaVIDMcDduFr(0);
					jpgAeiiaNyOIkAAZQaVIDMcDduFr2.ONqAyLcvrSegCIALohEgvPxUolfgA = ONqAyLcvrSegCIALohEgvPxUolfgA;
				}
				jpgAeiiaNyOIkAAZQaVIDMcDduFr2.ZRrnWcGXhiddzdcJgxlhYdlaafhcA = lLUHzjwVlmILhGvilEjxfiteSfLF;
				jpgAeiiaNyOIkAAZQaVIDMcDduFr2.sIChGYiUfbGWqoAmNzXBUGlnnYhe = BeVqKpMNjfYYycvLjWwrVjdzaUpO;
				return jpgAeiiaNyOIkAAZQaVIDMcDduFr2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class uuPlHqwlnYgUQCXWguWAGCfiTWVDA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int pAVNPSQvCYurZYinqrFdQeLaqaJi;

			private InputAction VrKTURlbUVckGeXFfAZIRdQlrWjb;

			private int PUSDsNchqTPkUEvxfzvAKPMQcIqnc;

			public UserData XbRrlpnaNsmazeoLfSxsZhWHbGHG;

			private string HhZFchufRagsPhiiGdtdbBhymEcB;

			public string vCJxnsxofSyTSDuRaObeUQGyvQSB;

			private bool LjJYbceDKNaNdkCCkUdYHneWkCQz;

			public bool TkSbJNYNWIRpKhTNwnAhoFDiQYTJ;

			private InputCategory PbynVnyfMoGJLrVvOBuoVnQtHdpT;

			private IEnumerator<int> IywGoqUgasFrGAOwdtFItaokeBWl;

			private int hfPHzNmjCREFyDXOoJCKHjMwKVnxA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return VrKTURlbUVckGeXFfAZIRdQlrWjb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return VrKTURlbUVckGeXFfAZIRdQlrWjb;
				}
			}

			[DebuggerHidden]
			public uuPlHqwlnYgUQCXWguWAGCfiTWVDA(int P_0)
			{
				pAVNPSQvCYurZYinqrFdQeLaqaJi = P_0;
				PUSDsNchqTPkUEvxfzvAKPMQcIqnc = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = pAVNPSQvCYurZYinqrFdQeLaqaJi;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						sclReArbgRVcUzOJglaaJmOAYIoM();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = pAVNPSQvCYurZYinqrFdQeLaqaJi;
					UserData xbRrlpnaNsmazeoLfSxsZhWHbGHG = XbRrlpnaNsmazeoLfSxsZhWHbGHG;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						pAVNPSQvCYurZYinqrFdQeLaqaJi = -1;
						if (xbRrlpnaNsmazeoLfSxsZhWHbGHG.actions == null || xbRrlpnaNsmazeoLfSxsZhWHbGHG.actionCategories == null)
						{
							return false;
						}
						PbynVnyfMoGJLrVvOBuoVnQtHdpT = xbRrlpnaNsmazeoLfSxsZhWHbGHG.GetActionCategory(HhZFchufRagsPhiiGdtdbBhymEcB);
						if (PbynVnyfMoGJLrVvOBuoVnQtHdpT == null || !PbynVnyfMoGJLrVvOBuoVnQtHdpT.userAssignable)
						{
							return false;
						}
						if (LjJYbceDKNaNdkCCkUdYHneWkCQz)
						{
							IywGoqUgasFrGAOwdtFItaokeBWl = xbRrlpnaNsmazeoLfSxsZhWHbGHG.SortedActionIdsInCategory(PbynVnyfMoGJLrVvOBuoVnQtHdpT.id).GetEnumerator();
							pAVNPSQvCYurZYinqrFdQeLaqaJi = -3;
							goto IL_00e4;
						}
						hfPHzNmjCREFyDXOoJCKHjMwKVnxA = 0;
						goto IL_0165;
					case 1:
						pAVNPSQvCYurZYinqrFdQeLaqaJi = -3;
						goto IL_00e4;
					case 2:
						{
							pAVNPSQvCYurZYinqrFdQeLaqaJi = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (IywGoqUgasFrGAOwdtFItaokeBWl.MoveNext())
						{
							int current = IywGoqUgasFrGAOwdtFItaokeBWl.Current;
							InputAction actionById = xbRrlpnaNsmazeoLfSxsZhWHbGHG.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								VrKTURlbUVckGeXFfAZIRdQlrWjb = actionById;
								pAVNPSQvCYurZYinqrFdQeLaqaJi = 1;
								return true;
							}
						}
						sclReArbgRVcUzOJglaaJmOAYIoM();
						IywGoqUgasFrGAOwdtFItaokeBWl = null;
						break;
						IL_0153:
						hfPHzNmjCREFyDXOoJCKHjMwKVnxA++;
						goto IL_0165;
						IL_0165:
						if (hfPHzNmjCREFyDXOoJCKHjMwKVnxA >= xbRrlpnaNsmazeoLfSxsZhWHbGHG.actions.Count)
						{
							break;
						}
						inputAction = xbRrlpnaNsmazeoLfSxsZhWHbGHG.actions[hfPHzNmjCREFyDXOoJCKHjMwKVnxA];
						if (inputAction.categoryId == PbynVnyfMoGJLrVvOBuoVnQtHdpT.id && inputAction.userAssignable)
						{
							VrKTURlbUVckGeXFfAZIRdQlrWjb = inputAction;
							pAVNPSQvCYurZYinqrFdQeLaqaJi = 2;
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

			private void sclReArbgRVcUzOJglaaJmOAYIoM()
			{
				pAVNPSQvCYurZYinqrFdQeLaqaJi = -1;
				if (IywGoqUgasFrGAOwdtFItaokeBWl != null)
				{
					IywGoqUgasFrGAOwdtFItaokeBWl.Dispose();
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
				uuPlHqwlnYgUQCXWguWAGCfiTWVDA uuPlHqwlnYgUQCXWguWAGCfiTWVDA2;
				if (pAVNPSQvCYurZYinqrFdQeLaqaJi == -2 && PUSDsNchqTPkUEvxfzvAKPMQcIqnc == Environment.CurrentManagedThreadId)
				{
					pAVNPSQvCYurZYinqrFdQeLaqaJi = 0;
					uuPlHqwlnYgUQCXWguWAGCfiTWVDA2 = this;
				}
				else
				{
					uuPlHqwlnYgUQCXWguWAGCfiTWVDA2 = new uuPlHqwlnYgUQCXWguWAGCfiTWVDA(0);
					uuPlHqwlnYgUQCXWguWAGCfiTWVDA2.XbRrlpnaNsmazeoLfSxsZhWHbGHG = XbRrlpnaNsmazeoLfSxsZhWHbGHG;
				}
				uuPlHqwlnYgUQCXWguWAGCfiTWVDA2.HhZFchufRagsPhiiGdtdbBhymEcB = vCJxnsxofSyTSDuRaObeUQGyvQSB;
				uuPlHqwlnYgUQCXWguWAGCfiTWVDA2.LjJYbceDKNaNdkCCkUdYHneWkCQz = TkSbJNYNWIRpKhTNwnAhoFDiQYTJ;
				return uuPlHqwlnYgUQCXWguWAGCfiTWVDA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class VPPFDUGrgHtvSISaAHHgvGATFZjW : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int ZDCEzYvJqGoCFlPusHUyPVwORdkd;

			private InputMapCategory jGkdUJBTWCzNgNFKEeshMZviscHnA;

			private int luhXAaZEJqhUuZulODmAMHUhfdfm;

			private string akJgtCGjMzLjpGicfNjXnhrNiuNLA;

			public string BncVsXUcXZfvQaHXAcbfaPaExOPhA;

			public UserData DbYUJClyNpgBdutQXhCYfFrYNeOQ;

			private int sFCRjiUeaJCoKVNAtwrdjFBzEIGC;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return jGkdUJBTWCzNgNFKEeshMZviscHnA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return jGkdUJBTWCzNgNFKEeshMZviscHnA;
				}
			}

			[DebuggerHidden]
			public VPPFDUGrgHtvSISaAHHgvGATFZjW(int P_0)
			{
				ZDCEzYvJqGoCFlPusHUyPVwORdkd = P_0;
				luhXAaZEJqhUuZulODmAMHUhfdfm = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int zDCEzYvJqGoCFlPusHUyPVwORdkd = ZDCEzYvJqGoCFlPusHUyPVwORdkd;
				UserData dbYUJClyNpgBdutQXhCYfFrYNeOQ = DbYUJClyNpgBdutQXhCYfFrYNeOQ;
				if (zDCEzYvJqGoCFlPusHUyPVwORdkd != 0)
				{
					if (zDCEzYvJqGoCFlPusHUyPVwORdkd != 1)
					{
						return false;
					}
					ZDCEzYvJqGoCFlPusHUyPVwORdkd = -1;
					goto IL_00b3;
				}
				ZDCEzYvJqGoCFlPusHUyPVwORdkd = -1;
				if (akJgtCGjMzLjpGicfNjXnhrNiuNLA == null || akJgtCGjMzLjpGicfNjXnhrNiuNLA == string.Empty)
				{
					return false;
				}
				if (dbYUJClyNpgBdutQXhCYfFrYNeOQ.mapCategories == null)
				{
					return false;
				}
				sFCRjiUeaJCoKVNAtwrdjFBzEIGC = 0;
				goto IL_00c3;
				IL_00c3:
				if (sFCRjiUeaJCoKVNAtwrdjFBzEIGC < dbYUJClyNpgBdutQXhCYfFrYNeOQ.mapCategories.Count)
				{
					if (dbYUJClyNpgBdutQXhCYfFrYNeOQ.mapCategories[sFCRjiUeaJCoKVNAtwrdjFBzEIGC].userAssignable && dbYUJClyNpgBdutQXhCYfFrYNeOQ.mapCategories[sFCRjiUeaJCoKVNAtwrdjFBzEIGC].tag.Equals(akJgtCGjMzLjpGicfNjXnhrNiuNLA, StringComparison.OrdinalIgnoreCase))
					{
						jGkdUJBTWCzNgNFKEeshMZviscHnA = dbYUJClyNpgBdutQXhCYfFrYNeOQ.mapCategories[sFCRjiUeaJCoKVNAtwrdjFBzEIGC];
						ZDCEzYvJqGoCFlPusHUyPVwORdkd = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				sFCRjiUeaJCoKVNAtwrdjFBzEIGC++;
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
				VPPFDUGrgHtvSISaAHHgvGATFZjW vPPFDUGrgHtvSISaAHHgvGATFZjW;
				if (ZDCEzYvJqGoCFlPusHUyPVwORdkd == -2 && luhXAaZEJqhUuZulODmAMHUhfdfm == Environment.CurrentManagedThreadId)
				{
					ZDCEzYvJqGoCFlPusHUyPVwORdkd = 0;
					vPPFDUGrgHtvSISaAHHgvGATFZjW = this;
				}
				else
				{
					vPPFDUGrgHtvSISaAHHgvGATFZjW = new VPPFDUGrgHtvSISaAHHgvGATFZjW(0);
					vPPFDUGrgHtvSISaAHHgvGATFZjW.DbYUJClyNpgBdutQXhCYfFrYNeOQ = DbYUJClyNpgBdutQXhCYfFrYNeOQ;
				}
				vPPFDUGrgHtvSISaAHHgvGATFZjW.akJgtCGjMzLjpGicfNjXnhrNiuNLA = BncVsXUcXZfvQaHXAcbfaPaExOPhA;
				return vPPFDUGrgHtvSISaAHHgvGATFZjW;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class VMesOmbNJpcDYvaLFbljDmXQyoZMA : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int wkFcEDVrmzCofUCLjKDUPVbgGwdT;

			private InputCategory AIhnIGJXpOptFhHbFnYMEJEaDuNS;

			private int tBujzrOJtLyfrkcoMbWwFzDbADJIb;

			public UserData EvBNtUNLUDDnRjwYHNIePwgdHKZR;

			private int qrEuZJMLGZljzhpBUjQUnlOhjDPz;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return AIhnIGJXpOptFhHbFnYMEJEaDuNS;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return AIhnIGJXpOptFhHbFnYMEJEaDuNS;
				}
			}

			[DebuggerHidden]
			public VMesOmbNJpcDYvaLFbljDmXQyoZMA(int P_0)
			{
				wkFcEDVrmzCofUCLjKDUPVbgGwdT = P_0;
				tBujzrOJtLyfrkcoMbWwFzDbADJIb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = wkFcEDVrmzCofUCLjKDUPVbgGwdT;
				UserData evBNtUNLUDDnRjwYHNIePwgdHKZR = EvBNtUNLUDDnRjwYHNIePwgdHKZR;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					wkFcEDVrmzCofUCLjKDUPVbgGwdT = -1;
					goto IL_0070;
				}
				wkFcEDVrmzCofUCLjKDUPVbgGwdT = -1;
				if (evBNtUNLUDDnRjwYHNIePwgdHKZR.actionCategories == null)
				{
					return false;
				}
				qrEuZJMLGZljzhpBUjQUnlOhjDPz = 0;
				goto IL_0080;
				IL_0080:
				if (qrEuZJMLGZljzhpBUjQUnlOhjDPz < evBNtUNLUDDnRjwYHNIePwgdHKZR.actionCategories.Count)
				{
					if (evBNtUNLUDDnRjwYHNIePwgdHKZR.actionCategories[qrEuZJMLGZljzhpBUjQUnlOhjDPz].userAssignable)
					{
						AIhnIGJXpOptFhHbFnYMEJEaDuNS = evBNtUNLUDDnRjwYHNIePwgdHKZR.actionCategories[qrEuZJMLGZljzhpBUjQUnlOhjDPz];
						wkFcEDVrmzCofUCLjKDUPVbgGwdT = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				qrEuZJMLGZljzhpBUjQUnlOhjDPz++;
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
				VMesOmbNJpcDYvaLFbljDmXQyoZMA vMesOmbNJpcDYvaLFbljDmXQyoZMA;
				if (wkFcEDVrmzCofUCLjKDUPVbgGwdT == -2 && tBujzrOJtLyfrkcoMbWwFzDbADJIb == Environment.CurrentManagedThreadId)
				{
					wkFcEDVrmzCofUCLjKDUPVbgGwdT = 0;
					vMesOmbNJpcDYvaLFbljDmXQyoZMA = this;
				}
				else
				{
					vMesOmbNJpcDYvaLFbljDmXQyoZMA = new VMesOmbNJpcDYvaLFbljDmXQyoZMA(0);
					vMesOmbNJpcDYvaLFbljDmXQyoZMA.EvBNtUNLUDDnRjwYHNIePwgdHKZR = EvBNtUNLUDDnRjwYHNIePwgdHKZR;
				}
				return vMesOmbNJpcDYvaLFbljDmXQyoZMA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class ItyrNqPMlGFxgFfIKtWNoYeXGDdL : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int DTeZDlUEHTwAaaCPvHtNBgfgZLiS;

			private InputAction aorqzUYXLeezwWPqagvUglkKncpD;

			private int eyPmlbcJFjgHqKzcnEqvpFcIaIVS;

			public UserData LnszfdQVESaYsHHPHwMoPUvaNWTj;

			private int twdApPzdVOAEkgRdjMsdbQvpuSveA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return aorqzUYXLeezwWPqagvUglkKncpD;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aorqzUYXLeezwWPqagvUglkKncpD;
				}
			}

			[DebuggerHidden]
			public ItyrNqPMlGFxgFfIKtWNoYeXGDdL(int P_0)
			{
				DTeZDlUEHTwAaaCPvHtNBgfgZLiS = P_0;
				eyPmlbcJFjgHqKzcnEqvpFcIaIVS = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int dTeZDlUEHTwAaaCPvHtNBgfgZLiS = DTeZDlUEHTwAaaCPvHtNBgfgZLiS;
				UserData lnszfdQVESaYsHHPHwMoPUvaNWTj = LnszfdQVESaYsHHPHwMoPUvaNWTj;
				if (dTeZDlUEHTwAaaCPvHtNBgfgZLiS != 0)
				{
					if (dTeZDlUEHTwAaaCPvHtNBgfgZLiS != 1)
					{
						return false;
					}
					DTeZDlUEHTwAaaCPvHtNBgfgZLiS = -1;
					goto IL_007a;
				}
				DTeZDlUEHTwAaaCPvHtNBgfgZLiS = -1;
				if (lnszfdQVESaYsHHPHwMoPUvaNWTj.actions == null)
				{
					return false;
				}
				twdApPzdVOAEkgRdjMsdbQvpuSveA = 0;
				goto IL_008c;
				IL_008c:
				if (twdApPzdVOAEkgRdjMsdbQvpuSveA < lnszfdQVESaYsHHPHwMoPUvaNWTj.actions.Count)
				{
					InputAction inputAction = lnszfdQVESaYsHHPHwMoPUvaNWTj.actions[twdApPzdVOAEkgRdjMsdbQvpuSveA];
					InputCategory actionCategoryById = lnszfdQVESaYsHHPHwMoPUvaNWTj.GetActionCategoryById(inputAction.categoryId);
					if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
					{
						aorqzUYXLeezwWPqagvUglkKncpD = inputAction;
						DTeZDlUEHTwAaaCPvHtNBgfgZLiS = 1;
						return true;
					}
					goto IL_007a;
				}
				return false;
				IL_007a:
				twdApPzdVOAEkgRdjMsdbQvpuSveA++;
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
				ItyrNqPMlGFxgFfIKtWNoYeXGDdL ityrNqPMlGFxgFfIKtWNoYeXGDdL;
				if (DTeZDlUEHTwAaaCPvHtNBgfgZLiS == -2 && eyPmlbcJFjgHqKzcnEqvpFcIaIVS == Environment.CurrentManagedThreadId)
				{
					DTeZDlUEHTwAaaCPvHtNBgfgZLiS = 0;
					ityrNqPMlGFxgFfIKtWNoYeXGDdL = this;
				}
				else
				{
					ityrNqPMlGFxgFfIKtWNoYeXGDdL = new ItyrNqPMlGFxgFfIKtWNoYeXGDdL(0);
					ityrNqPMlGFxgFfIKtWNoYeXGDdL.LnszfdQVESaYsHHPHwMoPUvaNWTj = LnszfdQVESaYsHHPHwMoPUvaNWTj;
				}
				return ityrNqPMlGFxgFfIKtWNoYeXGDdL;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class xvdzENHSqYGQAKYnYHuCMbEeBrZt : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int aidqgiAsocDgdexBJQosIKVqisyB;

			private InputMapCategory FXZyikMIZgLtppqAzhaZqJiodDkEA;

			private int yNPQiHdoltVeBytRdVtLmfWtHE;

			public UserData lrhEJVBPJzyXvJfVwHRNEBbcpXtMA;

			private int HJFRZpuCAmkeMZpKSAHuoNikXrZd;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return FXZyikMIZgLtppqAzhaZqJiodDkEA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return FXZyikMIZgLtppqAzhaZqJiodDkEA;
				}
			}

			[DebuggerHidden]
			public xvdzENHSqYGQAKYnYHuCMbEeBrZt(int P_0)
			{
				aidqgiAsocDgdexBJQosIKVqisyB = P_0;
				yNPQiHdoltVeBytRdVtLmfWtHE = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = aidqgiAsocDgdexBJQosIKVqisyB;
				UserData userData = lrhEJVBPJzyXvJfVwHRNEBbcpXtMA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					aidqgiAsocDgdexBJQosIKVqisyB = -1;
					goto IL_0070;
				}
				aidqgiAsocDgdexBJQosIKVqisyB = -1;
				if (userData.mapCategories == null)
				{
					return false;
				}
				HJFRZpuCAmkeMZpKSAHuoNikXrZd = 0;
				goto IL_0080;
				IL_0080:
				if (HJFRZpuCAmkeMZpKSAHuoNikXrZd < userData.mapCategories.Count)
				{
					if (userData.mapCategories[HJFRZpuCAmkeMZpKSAHuoNikXrZd].userAssignable)
					{
						FXZyikMIZgLtppqAzhaZqJiodDkEA = userData.mapCategories[HJFRZpuCAmkeMZpKSAHuoNikXrZd];
						aidqgiAsocDgdexBJQosIKVqisyB = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				HJFRZpuCAmkeMZpKSAHuoNikXrZd++;
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
				xvdzENHSqYGQAKYnYHuCMbEeBrZt xvdzENHSqYGQAKYnYHuCMbEeBrZt2;
				if (aidqgiAsocDgdexBJQosIKVqisyB == -2 && yNPQiHdoltVeBytRdVtLmfWtHE == Environment.CurrentManagedThreadId)
				{
					aidqgiAsocDgdexBJQosIKVqisyB = 0;
					xvdzENHSqYGQAKYnYHuCMbEeBrZt2 = this;
				}
				else
				{
					xvdzENHSqYGQAKYnYHuCMbEeBrZt2 = new xvdzENHSqYGQAKYnYHuCMbEeBrZt(0);
					xvdzENHSqYGQAKYnYHuCMbEeBrZt2.lrhEJVBPJzyXvJfVwHRNEBbcpXtMA = lrhEJVBPJzyXvJfVwHRNEBbcpXtMA;
				}
				return xvdzENHSqYGQAKYnYHuCMbEeBrZt2;
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<ControllerMap_Editor> joystickMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> keyboardMaps = new List<ControllerMap_Editor>();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerMap_Editor> mouseMaps = new List<ControllerMap_Editor>();

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		internal IList<Player_Editor> WhOmmIcRUFeHIqIDYZllQSPokJqb
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

		internal IList<InputAction> LyEOFtBxvPSLXbFwoLxqMkIjoBlE
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

		internal IList<InputCategory> JtXNnsmuBiEVWZqEjMpnyztNcIoS
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

		internal IList<InputBehavior> YbzYsPuJpzPXgtcjtGIziNHtxZyRA
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

		internal IList<InputMapCategory> ygRYTfsGocfxIGZBHSvYRjhiFskx
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

		internal IList<InputLayout> kHvsAZqeDuhMuiGkaqbPPOvtaPMi
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

		internal IList<InputLayout> ClEQeDqNtemuIplHbJTHDjfTlidRA
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

		internal IList<InputLayout> XzWTHbSpUVMzZioAkaBWYWJANyDI
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

		internal IList<InputLayout> OHVCzYKpFwxJZMtNzIejndHtbCJW
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

		internal IList<ControllerMap_Editor> LwwMNeZpXniRSzMcHmuqpCyaiBTJ
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

		internal IList<ControllerMap_Editor> jjHjWHHXwaESDRcFnCrulBhFHPCc
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

		internal IList<ControllerMap_Editor> AdFDzYGbzZeMJceAtMkKsKLYqQLBA
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

		internal IList<ControllerMap_Editor> KnFIUhNDQwtzoPmijIWHbtETWeMU
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

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> mKnhrKRAUeOUgViCufMdrjBLigQY
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

		internal IList<ControllerMapEnabler_RuleSet_Editor> TaaXHtYsISrdXRhJaemughqfjsHtA
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

		internal IEnumerable<InputMapCategory> cOSkSqaekAaHTAbDMLClrWfrURzt
		{
			[IteratorStateMachine(typeof(xvdzENHSqYGQAKYnYHuCMbEeBrZt))]
			get
			{
				return new xvdzENHSqYGQAKYnYHuCMbEeBrZt(-2)
				{
					lrhEJVBPJzyXvJfVwHRNEBbcpXtMA = this
				};
			}
		}

		internal IEnumerable<InputCategory> WzzoDEmgtEkGcGbgECbutmJJSRCJ
		{
			[IteratorStateMachine(typeof(VMesOmbNJpcDYvaLFbljDmXQyoZMA))]
			get
			{
				return new VMesOmbNJpcDYvaLFbljDmXQyoZMA(-2)
				{
					EvBNtUNLUDDnRjwYHNIePwgdHKZR = this
				};
			}
		}

		internal IEnumerable<InputAction> GFQMYNoaBxIChmpWoRZwwhhOCxLc
		{
			[IteratorStateMachine(typeof(ItyrNqPMlGFxgFfIKtWNoYeXGDdL))]
			get
			{
				return new ItyrNqPMlGFxgFfIKtWNoYeXGDdL(-2)
				{
					LnszfdQVESaYsHHPHwMoPUvaNWTj = this
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

		[IteratorStateMachine(typeof(ZHgoNBekISVRTLPbuOlZapkvpbYq))]
		internal IEnumerable<InputMapCategory> ymDHWRhIsejizjOCFPCbgTgMDEnC(string P_0)
		{
			return new ZHgoNBekISVRTLPbuOlZapkvpbYq(-2)
			{
				ftZbIMkxtnIyWmhZWPaahoZAcWEHb = this,
				QvUfnBkfsjkiUsxbIxcPYDvwzHHS = P_0
			};
		}

		[IteratorStateMachine(typeof(VPPFDUGrgHtvSISaAHHgvGATFZjW))]
		internal IEnumerable<InputMapCategory> bDHlbybfxPOyHwfCzQXndmtcbKlR(string P_0)
		{
			return new VPPFDUGrgHtvSISaAHHgvGATFZjW(-2)
			{
				DbYUJClyNpgBdutQXhCYfFrYNeOQ = this,
				BncVsXUcXZfvQaHXAcbfaPaExOPhA = P_0
			};
		}

		[IteratorStateMachine(typeof(IGEtPutzfekmYAWGXNifnwDFKcDF))]
		internal IEnumerable<InputCategory> HajVFdSkBpxBklQmGSjTTHPlFJDk(string P_0)
		{
			return new IGEtPutzfekmYAWGXNifnwDFKcDF(-2)
			{
				mboAHDXZRqXRDnjPMyxxTGTzFBSP = this,
				KSTMhQxWQZavQzAbjqoudFcJkWVi = P_0
			};
		}

		[IteratorStateMachine(typeof(jOzudtahYVgiYpUgFsjKQUVCtlxS))]
		internal IEnumerable<InputCategory> vIOCXjqMSWRVAYfioBrOqwUuOYLb(string P_0)
		{
			return new jOzudtahYVgiYpUgFsjKQUVCtlxS(-2)
			{
				QnQEOqXaBwmTitrdGnvyRbGAeucP = this,
				UmRZBSuXKIqkmatopXVhnVWwUHeh = P_0
			};
		}

		[IteratorStateMachine(typeof(zQVDgzmAohimyqZBQIywljDAirHD))]
		internal IEnumerable<InputAction> xzSAYzvUNBdkhdYrDvboRIjPlMsu(int P_0, bool P_1)
		{
			return new zQVDgzmAohimyqZBQIywljDAirHD(-2)
			{
				qDCBSSLuuZcMGVvrOoeXWGbAFWPdA = this,
				pxTJHSJYNMcIhlNdaCTfeTiUqZvjA = P_0,
				iajjOEBkFqaNzCuTCoaXbJXIIdhRd = P_1
			};
		}

		[IteratorStateMachine(typeof(kydHIzccJeiemgnIkfXVirwLqhfcA))]
		internal IEnumerable<InputAction> VTMuOlZprxEzchkKIMMVjDuNORCQ(string P_0, bool P_1)
		{
			return new kydHIzccJeiemgnIkfXVirwLqhfcA(-2)
			{
				xowZoCtWoUMUTsEEOuaKRFmIjRUS = this,
				PjXzNBvhikDOmDfXwopsKKvvmDal = P_0,
				YatDihOFwmReYtTBBBTUXMUamawN = P_1
			};
		}

		[IteratorStateMachine(typeof(BtiaYjBJiRYVTyanUEOIFYasIWzSA))]
		internal IEnumerable<InputAction> gZgVcHWbUAXGgNYzpsvQjAircqQE(string P_0)
		{
			return new BtiaYjBJiRYVTyanUEOIFYasIWzSA(-2)
			{
				VGPGhehszaXlmHbznqbHgspXiZuhA = this,
				cpoaHpeAZQMYnUyfZvfeGVPvzLdrA = P_0
			};
		}

		[IteratorStateMachine(typeof(jpgAeiiaNyOIkAAZQaVIDMcDduFr))]
		internal IEnumerable<InputAction> YgQpGKDBAtOVTazhaGnoaTLJsou(int P_0, bool P_1)
		{
			return new jpgAeiiaNyOIkAAZQaVIDMcDduFr(-2)
			{
				ONqAyLcvrSegCIALohEgvPxUolfgA = this,
				lLUHzjwVlmILhGvilEjxfiteSfLF = P_0,
				BeVqKpMNjfYYycvLjWwrVjdzaUpO = P_1
			};
		}

		[IteratorStateMachine(typeof(uuPlHqwlnYgUQCXWguWAGCfiTWVDA))]
		internal IEnumerable<InputAction> hicuJieyokJxOSFYpmizlXJrHdvM(string P_0, bool P_1)
		{
			return new uuPlHqwlnYgUQCXWguWAGCfiTWVDA(-2)
			{
				XbRrlpnaNsmazeoLfSxsZhWHbGHG = this,
				vCJxnsxofSyTSDuRaObeUQGyvQSB = P_0,
				TkSbJNYNWIRpKhTNwnAhoFDiQYTJ = P_1
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
				Player_Editor player_Editor = htRXJaOHMfYZetgxXfXBajFqhNtW();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputCategory inputCategory = HnKhEDCBIHJXdtpvuyxCzsFIQMoi();
				inputCategory.name = "Default";
				inputCategory.descriptiveName = inputCategory.name;
				actionCategories.Add(inputCategory);
				actionCategoryMap.AddCategory(inputCategory.id);
				InputBehavior inputBehavior = aaJLnGvdQEZgAYapqjGOVwZDVGSr();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = hbNQdVQaVkAxRhtlZojFRkeTLxTn();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = FggyqZfdoGiEgbzXzacvBlFccpulc();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = IVyReevLjHoNYyJxsnZlJEQtmJDO();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = kysGnZquZDaMSjaQRTMZBkouhHMO();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = ajtwdoFzWGjpQZrADLlGFHbCdefbA();
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
				KeyboardMap item = keyboardMaps[i].TowmxrVCxqdBoaEtCUEoOvUPENnK(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].JcTUrqplioXFtAVanvZqpUBNDcGN(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(htRXJaOHMfYZetgxXfXBajFqhNtW());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, htRXJaOHMfYZetgxXfXBajFqhNtW());
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
			InputAction inputAction = GlaiWUKTjDThZGrxIQmhQKfsSGVk();
			inputAction.categoryId = categoryId;
			actions.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (actions != null)
			{
				InputAction inputAction = GlaiWUKTjDThZGrxIQmhQKfsSGVk();
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

		private int vUmlSTIQazuNsOKEvYKkOmVlsARp(int P_0, InputAction P_1)
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

		[IteratorStateMachine(typeof(pcYFDtdIMBbdhcyUHkTBcAYglbAoe))]
		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			return new pcYFDtdIMBbdhcyUHkTBcAYglbAoe(-2)
			{
				XUPnbWziBrUezKglRPQwTmBGJYql = this,
				ZwlyjccODVDoSssDgrfVYtLioXMk = id
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

		[IteratorStateMachine(typeof(LTumRnbtubGPmEIOVNQmSvmFIkfw))]
		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			return new LTumRnbtubGPmEIOVNQmSvmFIkfw(-2)
			{
				PpRgPOHGbRPzkqJAOTKGxGTdyPTrA = this,
				KPTYBJjOyieNgycpPdLhQzDANSBN = id
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

		[IteratorStateMachine(typeof(EgBxLrlYEWeBewaQZmWXRcfFVEfU))]
		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			return new EgBxLrlYEWeBewaQZmWXRcfFVEfU(-2)
			{
				jtQPbmfRNUyeZfKfQQlDzcEkdYie = this,
				TUlVYFbUsEuaozwYCLhvLlOOyQYc = id
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
			InputCategory inputCategory = HnKhEDCBIHJXdtpvuyxCzsFIQMoi();
			actionCategories.Add(inputCategory);
			actionCategoryMap.AddCategory(inputCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputCategory inputCategory = HnKhEDCBIHJXdtpvuyxCzsFIQMoi();
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
				int num = vUmlSTIQazuNsOKEvYKkOmVlsARp(id2, inputAction);
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
			inputBehaviors.Add(aaJLnGvdQEZgAYapqjGOVwZDVGSr());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, aaJLnGvdQEZgAYapqjGOVwZDVGSr());
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
			mapCategories.Add(hbNQdVQaVkAxRhtlZojFRkeTLxTn());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, hbNQdVQaVkAxRhtlZojFRkeTLxTn());
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
				Action<List<Player_Editor.Mapping>, int> action = WyVMTJuINxidwkFmoAWpezCabNEab._003C_003E9.UyWhUDSqswRfgfklVessnJXIuDcm;
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
			joystickLayouts.Add(FggyqZfdoGiEgbzXzacvBlFccpulc());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, FggyqZfdoGiEgbzXzacvBlFccpulc());
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
				Action<List<Player_Editor.Mapping>, int> action = WyVMTJuINxidwkFmoAWpezCabNEab._003C_003E9.CNxNfZJSLUpXaLaYHoSdsILLcdLm;
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
			keyboardLayouts.Add(IVyReevLjHoNYyJxsnZlJEQtmJDO());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, IVyReevLjHoNYyJxsnZlJEQtmJDO());
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
				Action<List<Player_Editor.Mapping>, int> action = WyVMTJuINxidwkFmoAWpezCabNEab._003C_003E9.poYbDIEheEIaZpRfUSkNiwNBQMdk;
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
			mouseLayouts.Add(kysGnZquZDaMSjaQRTMZBkouhHMO());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, kysGnZquZDaMSjaQRTMZBkouhHMO());
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
				Action<List<Player_Editor.Mapping>, int> action = WyVMTJuINxidwkFmoAWpezCabNEab._003C_003E9.AEBYrdhqbQUqwxeizdOYjxbpeDNZ;
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
			customControllerLayouts.Add(ajtwdoFzWGjpQZrADLlGFHbCdefbA());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, ajtwdoFzWGjpQZrADLlGFHbCdefbA());
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
				Action<List<Player_Editor.Mapping>, int> action = WyVMTJuINxidwkFmoAWpezCabNEab._003C_003E9.YYbZDVHeNZAuykYIvgmBsGyMWlOK;
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

		internal ControllerMap pmpsiHEijmkjdZKEijxiUJpJmdUO(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Joystick => gYrdCGSkLMLRiPRFTdAQQekZgBRu((Joystick)P_0, P_1, P_2), 
				ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
				ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
				ControllerType.Custom => TUkZAWXnygEsdIliJViGaMjbPySaA(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
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

		internal JoystickMap IsSxsOzFivKFteEYDNGZOMZSRJyK(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return RbbIQwDiJMwfUyLSWfhfSDREuGvh(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap gYrdCGSkLMLRiPRFTdAQQekZgBRu(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return RbbIQwDiJMwfUyLSWfhfSDREuGvh(P_0.MVIXvXRFIZGrairRwhdIAgMZlsrWA, P_1, P_2);
		}

		private JoystickMap RbbIQwDiJMwfUyLSWfhfSDREuGvh(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.MnZKOuxsGQgkNMhlMJfTFjrzgeMv(guid);
			ControllerMap_Editor controllerMap_Editor = xhMuzGBMyQXCyFgKFdLHznfXjvDr(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.OSThkEJgppwEqjnQYyOXrfqBhcdcA(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.YsLBXFCDDgIlyVeFqGIcutcVcGFY(guid, P_1, P_2);
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
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.RErcwJFraWnCUyvOExbBHYmECOoxA(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = xhMuzGBMyQXCyFgKFdLHznfXjvDr(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = cygfSSLDlQWeXQRTNFCEIlOdimWHA(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.YsLBXFCDDgIlyVeFqGIcutcVcGFY(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty || 1 == 0)
			{
				controllerMap_Editor = xhMuzGBMyQXCyFgKFdLHznfXjvDr(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.OSThkEJgppwEqjnQYyOXrfqBhcdcA(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.YsLBXFCDDgIlyVeFqGIcutcVcGFY(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.GTZCgEvpgmnzPgaEIBMstvYoxmHS(guid, P_1, P_2);
		}

		private ControllerMap_Editor xhMuzGBMyQXCyFgKFdLHznfXjvDr(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = ShODMjUDZlmITzKZdIEDOwwTximG(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor ShODMjUDZlmITzKZdIEDOwwTximG(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				pPGEAnVAUXeYvuYcFvSSMFRJDockA(list, joystickLayouts);
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

		private JoystickMap cygfSSLDlQWeXQRTNFCEIlOdimWHA(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.nagbKCPyMpbOktJuaXntqFEuRujR(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError("Error remapping joystick template " + P_2.Guid.ToString() + " to joystick " + P_0.guid.ToString() + "\nReason: " + text);
				return null;
			}
			return controllerMap_Editor.OSThkEJgppwEqjnQYyOXrfqBhcdcA(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap GJaaQDmhqMfXvgrLaxZVjszaRrjp(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.MnZKOuxsGQgkNMhlMJfTFjrzgeMv(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.MnZKOuxsGQgkNMhlMJfTFjrzgeMv(Guid.Empty);
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
				list.Add(allMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA);
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
			ControllerMap_Editor controllerMap_Editor = wMgeSUgVwsOWQailIFahVztcQapPA(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.TowmxrVCxqdBoaEtCUEoOvUPENnK(containsActionDelegate);
				keyboardMap.lhmIhSpdkcECAFPURkasENdaMkUtB(keyboard.sfymSjcVHxtWxMcRdJtqvPLgjYLfA, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.ICeymztTrSHKrrJarQRDqboVGMGg(keyboard.sfymSjcVHxtWxMcRdJtqvPLgjYLfA, categoryId, layoutId);
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
			ControllerMap_Editor controllerMap_Editor = wMgeSUgVwsOWQailIFahVztcQapPA(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.JcTUrqplioXFtAVanvZqpUBNDcGN(containsActionDelegate);
				mouseMap.IZOjGFEbwITsdGsLVPraZwyJCJpV(mouse.sfymSjcVHxtWxMcRdJtqvPLgjYLfA, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.IQssTQzcyoYodTRrMBCEQDqQSQxV(mouse.sfymSjcVHxtWxMcRdJtqvPLgjYLfA, categoryId, layoutId);
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

		internal CustomControllerMap CqogbileiizxaacONOYogivmsfYW(Guid P_0, int P_1, int P_2)
		{
			return ZgDFlOLLNvpIvSnkLbbLZJrSXHmx(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap TUkZAWXnygEsdIliJViGaMjbPySaA(int P_0, int P_1, int P_2)
		{
			return ZgDFlOLLNvpIvSnkLbbLZJrSXHmx(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap ZgDFlOLLNvpIvSnkLbbLZJrSXHmx(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = cdDaafKEYheQBedIAXDdtEIiMhgbB(P_1, id, P_2, false);
			if (controllerMap_Editor != null)
			{
				CustomControllerMap customControllerMap = controllerMap_Editor.BIIuUgkFOESqiyyOLEOfEKNSzPco(ContainsAction, P_0);
				customControllerMap.MLKeKTmEgxUcjbTeaqRCwxIzLZlC(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			CustomControllerMap customControllerMap2 = CustomControllerMap.RBnXPiSJXmxvELLXKDyMJPsNzbOR(P_0.typeGuid, id, P_1, P_2);
			customControllerMap2.MLKeKTmEgxUcjbTeaqRCwxIzLZlC(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap2;
		}

		private ControllerMap_Editor cdDaafKEYheQBedIAXDdtEIiMhgbB(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = EhoQZrzRLprgCgnqJpqmLJQPomsc(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor EhoQZrzRLprgCgnqJpqmLJQPomsc(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				pPGEAnVAUXeYvuYcFvSSMFRJDockA(list, customControllerLayouts);
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

		internal ControllerTemplateMap OJRmUMgkFJQpVOZBliLbYAWUlZmF(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.MJclTqidCJXjXgMbBehgUUoPankGA();
		}

		public void AddCustomController()
		{
			if (customControllers == null)
			{
				customControllers = new List<CustomController_Editor>();
			}
			customControllers.Add(mwzeAsMhvxKRPJMkisUSFXZboesF());
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
			customControllers.Insert(index, mwzeAsMhvxKRPJMkisUSFXZboesF());
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
			controllerMapLayoutManagerRuleSets.Add(CpULHRcjjmLIzbArzRKDDlQlautX());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, CpULHRcjjmLIzbArzRKDDlQlautX());
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
			controllerMapEnablerRuleSets.Add(LVsWyPnZpECMAWiFZAbJPGdvMkxt());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, LVsWyPnZpECMAWiFZAbJPGdvMkxt());
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

		private Player_Editor htRXJaOHMfYZetgxXfXBajFqhNtW()
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

		private InputAction GlaiWUKTjDThZGrxIQmhQKfsSGVk()
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

		private InputCategory HnKhEDCBIHJXdtpvuyxCzsFIQMoi()
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

		private InputBehavior aaJLnGvdQEZgAYapqjGOVwZDVGSr()
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

		private InputMapCategory hbNQdVQaVkAxRhtlZojFRkeTLxTn()
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

		private InputLayout FggyqZfdoGiEgbzXzacvBlFccpulc()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewJoystickLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout IVyReevLjHoNYyJxsnZlJEQtmJDO()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewKeyboardLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout kysGnZquZDaMSjaQRTMZBkouhHMO()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewMouseLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout ajtwdoFzWGjpQZrADLlGFHbCdefbA()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewCustomControllerLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private CustomController_Editor mwzeAsMhvxKRPJMkisUSFXZboesF()
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

		private ControllerMapLayoutManager_RuleSet_Editor CpULHRcjjmLIzbArzRKDDlQlautX()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor
			{
				id = GetNewControllerMapLayoutManagerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames())
			};
		}

		private ControllerMapEnabler_RuleSet_Editor LVsWyPnZpECMAWiFZAbJPGdvMkxt()
		{
			return new ControllerMapEnabler_RuleSet_Editor
			{
				id = GetNewControllerMapEnablerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames())
			};
		}

		private ControllerMap_Editor tyYyZgaXdxqFHJoufBYqgZIiCkQQ(List<ControllerMap_Editor> P_0, int P_1, int P_2)
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

		private ControllerMap_Editor wMgeSUgVwsOWQailIFahVztcQapPA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = tyYyZgaXdxqFHJoufBYqgZIiCkQQ(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = XkARxBakOwcdrTveSHZDSekdCSRO(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor XkARxBakOwcdrTveSHZDSekdCSRO(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				pPGEAnVAUXeYvuYcFvSSMFRJDockA(list, P_1);
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

		private void pPGEAnVAUXeYvuYcFvSSMFRJDockA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			NcuXDhVawCXqBHdWsCPQFuveNBbab ncuXDhVawCXqBHdWsCPQFuveNBbab = new NcuXDhVawCXqBHdWsCPQFuveNBbab();
			ncuXDhVawCXqBHdWsCPQFuveNBbab.OmnzTUhAgpOOSqhrTakgcDOKRfQdA = P_1;
			if (P_0 != null && ncuXDhVawCXqBHdWsCPQFuveNBbab.OmnzTUhAgpOOSqhrTakgcDOKRfQdA != null)
			{
				P_0.Sort(ncuXDhVawCXqBHdWsCPQFuveNBbab.EkJgnvwSjRGCoURtFNCwliNkHcweA);
			}
		}

		internal void PLfEyuYCVptvXshZdykOFkUTrMQx()
		{
			WhOmmIcRUFeHIqIDYZllQSPokJqb = new ReadOnlyCollection<Player_Editor>(players);
			LyEOFtBxvPSLXbFwoLxqMkIjoBlE = new ReadOnlyCollection<InputAction>(actions);
			JtXNnsmuBiEVWZqEjMpnyztNcIoS = new ReadOnlyCollection<InputCategory>(actionCategories);
			YbzYsPuJpzPXgtcjtGIziNHtxZyRA = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
			ygRYTfsGocfxIGZBHSvYRjhiFskx = new ReadOnlyCollection<InputMapCategory>(mapCategories);
			kHvsAZqeDuhMuiGkaqbPPOvtaPMi = new ReadOnlyCollection<InputLayout>(joystickLayouts);
			ClEQeDqNtemuIplHbJTHDjfTlidRA = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
			XzWTHbSpUVMzZioAkaBWYWJANyDI = new ReadOnlyCollection<InputLayout>(mouseLayouts);
			OHVCzYKpFwxJZMtNzIejndHtbCJW = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
			LwwMNeZpXniRSzMcHmuqpCyaiBTJ = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
			jjHjWHHXwaESDRcFnCrulBhFHPCc = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
			AdFDzYGbzZeMJceAtMkKsKLYqQLBA = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
			KnFIUhNDQwtzoPmijIWHbtETWeMU = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
			mKnhrKRAUeOUgViCufMdrjBLigQY = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
			TaaXHtYsISrdXRhJaemughqfjsHtA = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					mapCategories[i].rwveGsIHDmormzosMFmDHVougRau();
				}
			}
			containsActionDelegate = ContainsAction;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return WQrUhGbSKUohArdfnPGupECxSBlw.YsxTYhgCzaBgJABBfSUdGVUDnfWg(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return WQrUhGbSKUohArdfnPGupECxSBlw.YsxTYhgCzaBgJABBfSUdGVUDnfWg(orig, null, false);
		}
	}
}
