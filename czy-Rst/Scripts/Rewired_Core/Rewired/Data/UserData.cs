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
		private static class LSVRohvqGLufEzRsnpASzJwQVplX
		{
			[DefaultMember("Item")]
			private class eFJIulbtZIHHuzVNqxYhzJhpFoLN
			{
				public enum IkeBrYocAnODfKzBeBrJCTHKqQbk
				{
					origId = 0,
					otherId = 1,
					finalId = 2
				}

				public int kwsxlbPjcSkHlydcFiGoHyzXXxsu;

				public int lVZZmSZiaLXScpukgqOuPZDQmmAq;

				public int gkdQJIzCzIDwTytONjxEAbiVzNwh;

				public int OIXYIPXzttPpERxfAAXRutapnszT
				{
					get
					{
						return P_0 switch
						{
							IkeBrYocAnODfKzBeBrJCTHKqQbk.origId => kwsxlbPjcSkHlydcFiGoHyzXXxsu, 
							IkeBrYocAnODfKzBeBrJCTHKqQbk.otherId => lVZZmSZiaLXScpukgqOuPZDQmmAq, 
							IkeBrYocAnODfKzBeBrJCTHKqQbk.finalId => gkdQJIzCzIDwTytONjxEAbiVzNwh, 
							_ => throw new NotImplementedException(), 
						};
					}
					set
					{
						switch (ikeBrYocAnODfKzBeBrJCTHKqQbk)
						{
						case IkeBrYocAnODfKzBeBrJCTHKqQbk.origId:
							kwsxlbPjcSkHlydcFiGoHyzXXxsu = num;
							break;
						case IkeBrYocAnODfKzBeBrJCTHKqQbk.otherId:
							lVZZmSZiaLXScpukgqOuPZDQmmAq = num;
							break;
						case IkeBrYocAnODfKzBeBrJCTHKqQbk.finalId:
							gkdQJIzCzIDwTytONjxEAbiVzNwh = num;
							break;
						default:
							throw new NotImplementedException();
						}
					}
				}

				public eFJIulbtZIHHuzVNqxYhzJhpFoLN(int P_0, int P_1, int P_2)
				{
					kwsxlbPjcSkHlydcFiGoHyzXXxsu = P_0;
					lVZZmSZiaLXScpukgqOuPZDQmmAq = P_1;
					gkdQJIzCzIDwTytONjxEAbiVzNwh = P_2;
				}

				public virtual string DXGqrGkJIXuvmNmtwAMHKgheAgviA()
				{
					return string.Concat(string.Concat("" + StringTools.WriteVar("origId", kwsxlbPjcSkHlydcFiGoHyzXXxsu), StringTools.WriteVar("otherId", lVZZmSZiaLXScpukgqOuPZDQmmAq)), StringTools.WriteVar("finalId", gkdQJIzCzIDwTytONjxEAbiVzNwh));
				}
			}

			private class cYIhjwRJAbarRxYntUPKJXypBljV<_0001>
			{
				public _0001 JmVlBWAzRCxDPyIGrXutTcvkAPfm;

				public _0001 dGQWoGnpumNrrOJbFivKEdXmNCqdA;

				public eFJIulbtZIHHuzVNqxYhzJhpFoLN.IkeBrYocAnODfKzBeBrJCTHKqQbk PEEFbqOcgugMjjZkfGBLPJxCaDPHb;

				public IList<_0001> bhVeIrhShdJczTRbrsGlEjSFKnNDB;

				public bool rKoqRGNPlrMOxdpDDXAykCXnyiwb;

				public cYIhjwRJAbarRxYntUPKJXypBljV(_0001 P_0, _0001 P_1, eFJIulbtZIHHuzVNqxYhzJhpFoLN.IkeBrYocAnODfKzBeBrJCTHKqQbk P_2, IList<_0001> P_3, bool P_4)
				{
					JmVlBWAzRCxDPyIGrXutTcvkAPfm = P_0;
					dGQWoGnpumNrrOJbFivKEdXmNCqdA = P_1;
					PEEFbqOcgugMjjZkfGBLPJxCaDPHb = P_2;
					bhVeIrhShdJczTRbrsGlEjSFKnNDB = P_3;
					rKoqRGNPlrMOxdpDDXAykCXnyiwb = P_4;
				}
			}

			[Serializable]
			private sealed class uIqTtGxRnWyMNQaGulinXGUUXAaj
			{
				public static readonly uIqTtGxRnWyMNQaGulinXGUUXAaj _003C_003E9 = new uIqTtGxRnWyMNQaGulinXGUUXAaj();

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

				internal int lPvZApGHqqxrLttqEwwVBHVjQMBt(InputActionCategory P_0)
				{
					return P_0.id;
				}

				internal string SMowhInKXztHOIAOljDoAJwFfnLz(InputActionCategory P_0)
				{
					return P_0.name;
				}

				internal int nSdcltmwkGcOdPBKdejqMFWsvMDS(InputActionCategory P_0, IList<InputActionCategory> P_1)
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

				internal int frZOzhkOFUCiuRAqvapXCVxNsoFr(InputBehavior P_0)
				{
					return P_0.id;
				}

				internal string HOUXAqEZgCFKACJrUyNpDCbaYmWt(InputBehavior P_0)
				{
					return P_0.name;
				}

				internal int IUuvddaHKoEWveGWoEYnLUmqgrjLA(InputBehavior P_0, IList<InputBehavior> P_1)
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

				internal int mmDOYwEDYOfoZIJPNJDOyfKIHMOfb(InputAction P_0)
				{
					return P_0.id;
				}

				internal string HTWzvzlsjNtQWdhSmZaoLzOHHdoO(InputAction P_0)
				{
					return P_0.name;
				}

				internal int GMVrvTevwsfDcjKmCxQocZhBIDmt(InputAction P_0, IList<InputAction> P_1)
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

				internal int xWtgxRKiiwWqbPFIyBSPGuQLhLWn(InputMapCategory P_0)
				{
					return P_0.id;
				}

				internal string vrMzXwzJPzvJPwmlJpErVEDmDMEkA(InputMapCategory P_0)
				{
					return P_0.name;
				}

				internal int ucCecgZOTAsudffIvLBoXmiHGqLq(InputMapCategory P_0, IList<InputMapCategory> P_1)
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

				internal int GSbIFefSdOUeDLlWUrYcKPhZcAeF(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string AKxfDNbOsDeIuHxzsnvbXHlVtVGC(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int PVlgMAfspJteyBvFHhlGPmfqCxqj(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int yrQJSmqZnWWFBZABYdWjHHhnQQYTA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string eSrbjxqHIfejTyZntFZtgJmbQeyx(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int KiUvzLDitIhzgqnEXfCeDDCrmKDF(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int rKYkaUONeuFotBywnAXQItwChTwTA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string vKaTAkInCHobpDKrctiDbEwzSifh(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int OSFBwfYDukJzphwKdoGLmVRiHUUf(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int JJbLDTMLUQbWViLIcehDkjFAbiMZA(InputLayout P_0)
				{
					return P_0.id;
				}

				internal string nigVYnZiiRRxPMeVrEFfnqXeOaW(InputLayout P_0)
				{
					return P_0.name;
				}

				internal int xQPIJCNHOEJiDnKxhXyDQIchsJof(InputLayout P_0, IList<InputLayout> P_1)
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

				internal int tNeddguHRMcdNYPbTAbPbouuNcveA(CustomController_Editor P_0)
				{
					return P_0.id;
				}

				internal string iSsBiAgbWjjoZwmpSQLoUeiHoZES(CustomController_Editor P_0)
				{
					return P_0.name;
				}

				internal int rCYHpXLpFqXUpZGkIgTFaIDHwrMl(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
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

				internal int MhxAVWhbSrJMnHriGQzKkAhhFddyC(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string utrapkllCZYkCQiYgUnZDwvuWDtc(ControllerMapLayoutManager_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int OwBIBmbEEqRUWJPjBzJTnKSVgLxA(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
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

				internal int PluPFGFOCqXmBUbURAoRFtcAVHeM(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.id;
				}

				internal string fGEmCNCHNNxJHAJRoaciDhaeWAyP(ControllerMapEnabler_RuleSet_Editor P_0)
				{
					return P_0.name;
				}

				internal int oRtJkluWeyglMVlnbWCpPVrZyFzC(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
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

				internal int ubYAFoGHTCmTwSeflqrRgmeVSgKdA(Player_Editor P_0)
				{
					return P_0.id;
				}

				internal string UANkOZKlvvJSQjrkzSGCoWHOMMmX(Player_Editor P_0)
				{
					return P_0.name;
				}

				internal int BLsBpffRYpVXwPfdvmowDTegTAeW(Player_Editor P_0, IList<Player_Editor> P_1)
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

				internal int XlUFwflZlXhluCalMMcAYYNloiwn(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
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

				internal int gtbasYAuSLkANTvwijTDGYureABb(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
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

				internal int QwAmTeTRJWMQbYZhWHmZmhuBSKHC(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string cRZCyFustSnqZbSoVGWjdUEApnFf(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int oWCPfBfPnMIiwUGulgWtKqWcgzAU(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int iyhuFOAuVLPrOmURZgFlPlJzjQBe(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string BnVfGvxNbzabGjuWcXsGSPInPVMBA(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int jgZXVNSHtwfGxGVUbrcnlwgDunOT(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int qwhppxCLNGNMbrMmtyzYLZucDoBC(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string dHurcbmuFnheQhWXTwROCkIVRyAb(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int CvcaBInjhADwUhnSpGlZYdWfXYIJ(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

				internal int LnfQULASyfpyYIoXPPAxiOAdAdLp(ControllerMap_Editor P_0)
				{
					return P_0.id;
				}

				internal string xAPHNbjQDTOlEaYyosrtnMsFtxdM(ControllerMap_Editor P_0)
				{
					return P_0.name;
				}

				internal int CZXdaqTKDDLLmDWBYMUTqkNMBHHF(ActionElementMap P_0, IList<ActionElementMap> P_1)
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

			private sealed class hywDDOGBuCFLDuASmWChqMOUGKds
			{
				public UserData JriDYpZqsZXijWMTrEIxxKQrZESd;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> xPlYfWEvbUHuhWiQVjlVUOiederj;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> RUnEalIpbgGetKQmXysLdutQIQpab;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> GIJMrrveDXEgLMdhdFjIeOwPNGCE;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> nrVdTPadkZxyMWurltaBqWfjqdwG;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> xPxCWyQMWpbajPtCYglpKLiNoYrKA;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> HALFdydJABmIuosZaGsYcxxOJDhCA;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> aBHUKrVkBjmUjzkSwRnoEjmdIWRD;

				public Func<ControllerType, List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>> YzJjCioiCXAzlyOUBsaSmmrvIgLf;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> FKzDjdoLQXGfSaKoIECNsuRCNqbXA;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> zyicfphbNWNhnLtYBGjVzpGILGHcA;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> PxktMrpSaScLFLLEURexGEaKbiR;

				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> SKfweCgxnvICyWYvYOXZYCtiERry;

				internal InputActionCategory sHFtgavuYSekiKrckeIbyiBwAmhv(cYIhjwRJAbarRxYntUPKJXypBljV<InputActionCategory> P_0)
				{
					InputActionCategory inputActionCategory = JsonTools.Clone(P_0.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					InputActionCategory inputActionCategory2;
					if (P_0.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						inputActionCategory2 = P_0.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddActionCategory();
						inputActionCategory2 = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					inputActionCategory.id = inputActionCategory2.id;
					int index = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(inputActionCategory2);
					P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = inputActionCategory;
					return inputActionCategory;
				}

				internal InputBehavior wDOWlxWalxIuMxaOGkoclwFuFZST(cYIhjwRJAbarRxYntUPKJXypBljV<InputBehavior> P_0)
				{
					InputBehavior inputBehavior = JsonTools.Clone(P_0.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					InputBehavior inputBehavior2;
					if (P_0.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						inputBehavior2 = P_0.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddInputBehavior();
						inputBehavior2 = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					inputBehavior.id = inputBehavior2.id;
					int index = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(inputBehavior2);
					P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = inputBehavior;
					return inputBehavior;
				}

				internal InputAction TBrSzrFZqTsarglPXfpBCFVVFBmqA(cYIhjwRJAbarRxYntUPKJXypBljV<InputAction> P_0)
				{
					XypGNhvbPdSmqlEnkmzeaomkKdSq xypGNhvbPdSmqlEnkmzeaomkKdSq = new XypGNhvbPdSmqlEnkmzeaomkKdSq();
					xypGNhvbPdSmqlEnkmzeaomkKdSq.OKWKzyEaUmZcwEBzfwcOSHllwBEd = P_0;
					InputAction inputAction = JsonTools.Clone(xypGNhvbPdSmqlEnkmzeaomkKdSq.OKWKzyEaUmZcwEBzfwcOSHllwBEd.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					int num = xPlYfWEvbUHuhWiQVjlVUOiederj.Find(xypGNhvbPdSmqlEnkmzeaomkKdSq.dFOTVfBhJfVzdxunWjpNmkDTTXJU)?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? 0;
					InputAction inputAction2;
					if (xypGNhvbPdSmqlEnkmzeaomkKdSq.OKWKzyEaUmZcwEBzfwcOSHllwBEd.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						inputAction2 = xypGNhvbPdSmqlEnkmzeaomkKdSq.OKWKzyEaUmZcwEBzfwcOSHllwBEd.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddAction(num);
						inputAction2 = xypGNhvbPdSmqlEnkmzeaomkKdSq.OKWKzyEaUmZcwEBzfwcOSHllwBEd.bhVeIrhShdJczTRbrsGlEjSFKnNDB[xypGNhvbPdSmqlEnkmzeaomkKdSq.OKWKzyEaUmZcwEBzfwcOSHllwBEd.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					int num2 = RUnEalIpbgGetKQmXysLdutQIQpab.Find(xypGNhvbPdSmqlEnkmzeaomkKdSq.GtmCeRddJwkhkgoAniasqMGYDAkYA)?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? 0;
					inputAction.id = inputAction2.id;
					if (num != inputAction2.categoryId)
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.ChangeActionCategory(inputAction2.id, num);
					}
					inputAction.categoryId = num;
					inputAction.behaviorId = num2;
					int index = xypGNhvbPdSmqlEnkmzeaomkKdSq.OKWKzyEaUmZcwEBzfwcOSHllwBEd.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(inputAction2);
					xypGNhvbPdSmqlEnkmzeaomkKdSq.OKWKzyEaUmZcwEBzfwcOSHllwBEd.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = inputAction;
					return inputAction;
				}

				internal InputLayout sllcTlZlvvcZSfZRsjGZwEfdjrlD(cYIhjwRJAbarRxYntUPKJXypBljV<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					InputLayout inputLayout2;
					if (P_0.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						inputLayout2 = P_0.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddKeyboardLayout();
						inputLayout2 = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(inputLayout2);
					P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout SjGCRAAjvwFlKVSPZQelUrRrcbwEb(cYIhjwRJAbarRxYntUPKJXypBljV<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					InputLayout inputLayout2;
					if (P_0.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						inputLayout2 = P_0.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddMouseLayout();
						inputLayout2 = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(inputLayout2);
					P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout EisGFduInEjiDajAZyrIaCJahUPvA(cYIhjwRJAbarRxYntUPKJXypBljV<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					InputLayout inputLayout2;
					if (P_0.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						inputLayout2 = P_0.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddJoystickLayout();
						inputLayout2 = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(inputLayout2);
					P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = inputLayout;
					return inputLayout;
				}

				internal InputLayout sFjAgvWdxzQhZYtttrCRUYpiTnrw(cYIhjwRJAbarRxYntUPKJXypBljV<InputLayout> P_0)
				{
					InputLayout inputLayout = JsonTools.Clone(P_0.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					InputLayout inputLayout2;
					if (P_0.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						inputLayout2 = P_0.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddCustomControllerLayout();
						inputLayout2 = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					inputLayout.id = inputLayout2.id;
					int index = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(inputLayout2);
					P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = inputLayout;
					return inputLayout;
				}

				internal List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> gDufdgiangPitIGdIZBiaFTCnpEvB(ControllerType P_0)
				{
					return P_0 switch
					{
						ControllerType.Keyboard => GIJMrrveDXEgLMdhdFjIeOwPNGCE, 
						ControllerType.Mouse => nrVdTPadkZxyMWurltaBqWfjqdwG, 
						ControllerType.Joystick => xPxCWyQMWpbajPtCYglpKLiNoYrKA, 
						ControllerType.Custom => HALFdydJABmIuosZaGsYcxxOJDhCA, 
						_ => throw new NotImplementedException(), 
					};
				}

				internal CustomController_Editor wGXztYPlksBWhLrQhdJZhnYPAMMcA(cYIhjwRJAbarRxYntUPKJXypBljV<CustomController_Editor> P_0)
				{
					CustomController_Editor customController_Editor = JsonTools.Clone(P_0.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					CustomController_Editor customController_Editor2;
					if (P_0.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						customController_Editor2 = P_0.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddCustomController(Guid.Empty);
						customController_Editor2 = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					customController_Editor.id = customController_Editor2.id;
					int index = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(customController_Editor2);
					P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = customController_Editor;
					return customController_Editor;
				}

				internal ControllerMapLayoutManager_RuleSet_Editor uMfzjrDqgfmmupGfpSpSnWVCHPqF(cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMapLayoutManager_RuleSet_Editor> P_0)
				{
					sNpbAsKKJPgVLtDziEZJIgrLHvcP sNpbAsKKJPgVLtDziEZJIgrLHvcP2 = new sNpbAsKKJPgVLtDziEZJIgrLHvcP();
					sNpbAsKKJPgVLtDziEZJIgrLHvcP2.morhaRbOWvbFriyqdjhknVtibboAA = P_0;
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(sNpbAsKKJPgVLtDziEZJIgrLHvcP2.morhaRbOWvbFriyqdjhknVtibboAA.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
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
							VJYyQhKUxzCsgFAxzNLxcBKYfqBS vJYyQhKUxzCsgFAxzNLxcBKYfqBS = new VJYyQhKUxzCsgFAxzNLxcBKYfqBS();
							vJYyQhKUxzCsgFAxzNLxcBKYfqBS.BtYvtFIgOpBFXSndOGitWbNuHNFG = sNpbAsKKJPgVLtDziEZJIgrLHvcP2;
							vJYyQhKUxzCsgFAxzNLxcBKYfqBS.tfNaSOrPSeaqFXohOMnBiUdXRBmL = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
							eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(vJYyQhKUxzCsgFAxzNLxcBKYfqBS.fznNHpMrlUeIYmuyBUqXdOQhBsiK);
							if (eFJIulbtZIHHuzVNqxYhzJhpFoLN2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + vJYyQhKUxzCsgFAxzNLxcBKYfqBS.tfNaSOrPSeaqFXohOMnBiUdXRBmL);
							}
							else
							{
								list.Add(eFJIulbtZIHHuzVNqxYhzJhpFoLN2.gkdQJIzCzIDwTytONjxEAbiVzNwh);
							}
						}
						controllerMapLayoutManager_Rule_Editor.categoryIds = list;
					}
					int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int k = 0; k < num3; k++)
					{
						zsKhhJfelEckilFfcbzEeJDdBUKw zsKhhJfelEckilFfcbzEeJDdBUKw2 = new zsKhhJfelEckilFfcbzEeJDdBUKw();
						zsKhhJfelEckilFfcbzEeJDdBUKw2.gmogvKudvZYmsJxsKXPTHswNqVQE = sNpbAsKKJPgVLtDziEZJIgrLHvcP2;
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
						if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
						{
							ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
							List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> list2 = YzJjCioiCXAzlyOUBsaSmmrvIgLf(controllerType);
							zsKhhJfelEckilFfcbzEeJDdBUKw2.jGprvpwJLIZRgyeggeerbnDAiBZG = controllerMapLayoutManager_Rule_Editor2.layoutId;
							eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = list2.Find(zsKhhJfelEckilFfcbzEeJDdBUKw2.YLDnShsPUagnRVqZEoqQfygDNZAt);
							if (eFJIulbtZIHHuzVNqxYhzJhpFoLN3 == null)
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + zsKhhJfelEckilFfcbzEeJDdBUKw2.jGprvpwJLIZRgyeggeerbnDAiBZG);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor2.layoutId = eFJIulbtZIHHuzVNqxYhzJhpFoLN3.gkdQJIzCzIDwTytONjxEAbiVzNwh;
							}
						}
					}
					int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
					for (int l = 0; l < num4; l++)
					{
						ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
						if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
						{
							uUZRmPtTmeudewXFVjYswMhogJdR uUZRmPtTmeudewXFVjYswMhogJdR2 = new uUZRmPtTmeudewXFVjYswMhogJdR();
							uUZRmPtTmeudewXFVjYswMhogJdR2.eMojbAlRCpGleQRRUNTcuUmGuJWR = sNpbAsKKJPgVLtDziEZJIgrLHvcP2;
							List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> fKzDjdoLQXGfSaKoIECNsuRCNqbXA = FKzDjdoLQXGfSaKoIECNsuRCNqbXA;
							uUZRmPtTmeudewXFVjYswMhogJdR2.KVZtROPvyuFUKfyASJIFJYrwCgXE = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN4 = fKzDjdoLQXGfSaKoIECNsuRCNqbXA.Find(uUZRmPtTmeudewXFVjYswMhogJdR2.lmRLAsAPKOGomEzxOGYjrtTOenvQA);
							if (eFJIulbtZIHHuzVNqxYhzJhpFoLN4 == null)
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + uUZRmPtTmeudewXFVjYswMhogJdR2.KVZtROPvyuFUKfyASJIFJYrwCgXE);
							}
							else
							{
								controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = eFJIulbtZIHHuzVNqxYhzJhpFoLN4.gkdQJIzCzIDwTytONjxEAbiVzNwh;
							}
						}
					}
					ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
					if (sNpbAsKKJPgVLtDziEZJIgrLHvcP2.morhaRbOWvbFriyqdjhknVtibboAA.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						controllerMapLayoutManager_RuleSet_Editor2 = sNpbAsKKJPgVLtDziEZJIgrLHvcP2.morhaRbOWvbFriyqdjhknVtibboAA.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddControllerMapLayoutManagerRuleSet();
						controllerMapLayoutManager_RuleSet_Editor2 = sNpbAsKKJPgVLtDziEZJIgrLHvcP2.morhaRbOWvbFriyqdjhknVtibboAA.bhVeIrhShdJczTRbrsGlEjSFKnNDB[sNpbAsKKJPgVLtDziEZJIgrLHvcP2.morhaRbOWvbFriyqdjhknVtibboAA.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
					int index = sNpbAsKKJPgVLtDziEZJIgrLHvcP2.morhaRbOWvbFriyqdjhknVtibboAA.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
					sNpbAsKKJPgVLtDziEZJIgrLHvcP2.morhaRbOWvbFriyqdjhknVtibboAA.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = controllerMapLayoutManager_RuleSet_Editor;
					return controllerMapLayoutManager_RuleSet_Editor;
				}

				internal ControllerMapEnabler_RuleSet_Editor UZayCHPenlcXiVkqkhafIHyjcMJL(cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMapEnabler_RuleSet_Editor> P_0)
				{
					xzPgQeCtcEATuZLTJUJoESEeqFHp xzPgQeCtcEATuZLTJUJoESEeqFHp2 = new xzPgQeCtcEATuZLTJUJoESEeqFHp();
					xzPgQeCtcEATuZLTJUJoESEeqFHp2.WfdCGcrjsvbietUfJbRXmwKUSuEk = P_0;
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(xzPgQeCtcEATuZLTJUJoESEeqFHp2.WfdCGcrjsvbietUfJbRXmwKUSuEk.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
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
							BmIwJUHvDeSqNGeRlrQuIBNpMQWM bmIwJUHvDeSqNGeRlrQuIBNpMQWM = new BmIwJUHvDeSqNGeRlrQuIBNpMQWM();
							bmIwJUHvDeSqNGeRlrQuIBNpMQWM.sdqZcLwbIQxrzJbIMMAqknBywZAD = xzPgQeCtcEATuZLTJUJoESEeqFHp2;
							bmIwJUHvDeSqNGeRlrQuIBNpMQWM.HhFCRQIIaAETkXBURuSmNfLHhwnIA = controllerMapEnabler_Rule_Editor.categoryIds[j];
							eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(bmIwJUHvDeSqNGeRlrQuIBNpMQWM.dpUDlFcyBhtlmNcacLIITTwGjuWh);
							if (eFJIulbtZIHHuzVNqxYhzJhpFoLN2 == null)
							{
								Logger.LogError("No new Map Category Id found for old id: " + bmIwJUHvDeSqNGeRlrQuIBNpMQWM.HhFCRQIIaAETkXBURuSmNfLHhwnIA);
							}
							else
							{
								list.Add(eFJIulbtZIHHuzVNqxYhzJhpFoLN2.gkdQJIzCzIDwTytONjxEAbiVzNwh);
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
						List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> list2 = YzJjCioiCXAzlyOUBsaSmmrvIgLf(controllerType);
						List<int> list3 = new List<int>();
						int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
						for (int l = 0; l < num3; l++)
						{
							dDzCLdcCAantJaFUhBCaMewuFLQQB dDzCLdcCAantJaFUhBCaMewuFLQQB2 = new dDzCLdcCAantJaFUhBCaMewuFLQQB();
							dDzCLdcCAantJaFUhBCaMewuFLQQB2.pQadItMONlbYZcsntvTyMzLMslBEA = xzPgQeCtcEATuZLTJUJoESEeqFHp2;
							dDzCLdcCAantJaFUhBCaMewuFLQQB2.qGDfonslWaPZrzOzhdyVjTzAlKem = controllerMapEnabler_Rule_Editor2.layoutIds[l];
							eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = list2.Find(dDzCLdcCAantJaFUhBCaMewuFLQQB2.JSkruExCKETmMyGFKHHJvJUlfsGDA);
							if (eFJIulbtZIHHuzVNqxYhzJhpFoLN3 == null)
							{
								Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + dDzCLdcCAantJaFUhBCaMewuFLQQB2.qGDfonslWaPZrzOzhdyVjTzAlKem);
							}
							else
							{
								list3.Add(eFJIulbtZIHHuzVNqxYhzJhpFoLN3.gkdQJIzCzIDwTytONjxEAbiVzNwh);
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
							irQOQvUDUOdHnlJLVCcKXImKzuWB irQOQvUDUOdHnlJLVCcKXImKzuWB2 = new irQOQvUDUOdHnlJLVCcKXImKzuWB();
							irQOQvUDUOdHnlJLVCcKXImKzuWB2.PdNqzjMOJADIUNIvCprzOHKhlHrf = xzPgQeCtcEATuZLTJUJoESEeqFHp2;
							List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> fKzDjdoLQXGfSaKoIECNsuRCNqbXA = FKzDjdoLQXGfSaKoIECNsuRCNqbXA;
							irQOQvUDUOdHnlJLVCcKXImKzuWB2.ChVcnXaGEXjBFaTMARJCGWoiLZegA = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
							eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN4 = fKzDjdoLQXGfSaKoIECNsuRCNqbXA.Find(irQOQvUDUOdHnlJLVCcKXImKzuWB2.iHiyKmSeTPKvsGZwKNiAySoXcMhm);
							if (eFJIulbtZIHHuzVNqxYhzJhpFoLN4 == null)
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
								Logger.LogError("No new Custom Controller found for old id: " + irQOQvUDUOdHnlJLVCcKXImKzuWB2.ChVcnXaGEXjBFaTMARJCGWoiLZegA);
							}
							else
							{
								controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = eFJIulbtZIHHuzVNqxYhzJhpFoLN4.gkdQJIzCzIDwTytONjxEAbiVzNwh;
							}
						}
					}
					ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
					if (xzPgQeCtcEATuZLTJUJoESEeqFHp2.WfdCGcrjsvbietUfJbRXmwKUSuEk.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						controllerMapEnabler_RuleSet_Editor2 = xzPgQeCtcEATuZLTJUJoESEeqFHp2.WfdCGcrjsvbietUfJbRXmwKUSuEk.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddControllerMapEnablerRuleSet();
						controllerMapEnabler_RuleSet_Editor2 = xzPgQeCtcEATuZLTJUJoESEeqFHp2.WfdCGcrjsvbietUfJbRXmwKUSuEk.bhVeIrhShdJczTRbrsGlEjSFKnNDB[xzPgQeCtcEATuZLTJUJoESEeqFHp2.WfdCGcrjsvbietUfJbRXmwKUSuEk.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
					int index = xzPgQeCtcEATuZLTJUJoESEeqFHp2.WfdCGcrjsvbietUfJbRXmwKUSuEk.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(controllerMapEnabler_RuleSet_Editor2);
					xzPgQeCtcEATuZLTJUJoESEeqFHp2.WfdCGcrjsvbietUfJbRXmwKUSuEk.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = controllerMapEnabler_RuleSet_Editor;
					return controllerMapEnabler_RuleSet_Editor;
				}

				internal Player_Editor nlpjVbmZfvinrkUFnQncqAHHSApR(cYIhjwRJAbarRxYntUPKJXypBljV<Player_Editor> P_0)
				{
					UFbWQLXtZCNMXCQPLdTzbAgJORwC uFbWQLXtZCNMXCQPLdTzbAgJORwC = new UFbWQLXtZCNMXCQPLdTzbAgJORwC();
					uFbWQLXtZCNMXCQPLdTzbAgJORwC.WEjbShwMcahZLHRUdaCrWKdIFftG = this;
					uFbWQLXtZCNMXCQPLdTzbAgJORwC.kOExsHCktIaGokmWqGWGwdcOWGqMA = P_0;
					Player_Editor player_Editor = JsonTools.Clone(uFbWQLXtZCNMXCQPLdTzbAgJORwC.kOExsHCktIaGokmWqGWGwdcOWGqMA.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					Action<List<Player_Editor.Mapping>, List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>> action = uFbWQLXtZCNMXCQPLdTzbAgJORwC.ijhZalcABdPhYyMiBVrXTbcrasrs;
					action(player_Editor.defaultKeyboardMaps, GIJMrrveDXEgLMdhdFjIeOwPNGCE);
					action(player_Editor.defaultMouseMaps, nrVdTPadkZxyMWurltaBqWfjqdwG);
					action(player_Editor.defaultJoystickMaps, xPxCWyQMWpbajPtCYglpKLiNoYrKA);
					action(player_Editor.defaultCustomControllerMaps, HALFdydJABmIuosZaGsYcxxOJDhCA);
					for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
					{
						lVEHEcxffKTcMnOCLtYvtNzVJXTJ lVEHEcxffKTcMnOCLtYvtNzVJXTJ2 = new lVEHEcxffKTcMnOCLtYvtNzVJXTJ();
						lVEHEcxffKTcMnOCLtYvtNzVJXTJ2.UZftDWxlsNDrlfOdUesvjjQDlhek = uFbWQLXtZCNMXCQPLdTzbAgJORwC;
						lVEHEcxffKTcMnOCLtYvtNzVJXTJ2.HcLAnrpJPhUxsDrKngNpRrdjafKl = player_Editor.startingCustomControllers[i];
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = FKzDjdoLQXGfSaKoIECNsuRCNqbXA.Find(lVEHEcxffKTcMnOCLtYvtNzVJXTJ2.QUKbDwBkBNnDkEGadjQSIrKZtWIWB);
						lVEHEcxffKTcMnOCLtYvtNzVJXTJ2.HcLAnrpJPhUxsDrKngNpRrdjafKl.sourceId = eFJIulbtZIHHuzVNqxYhzJhpFoLN2?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					}
					List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
					for (int j = 0; j < ruleSets.Count; j++)
					{
						zpNfCkBGdKHOQTQNLsnsnzbFZarv zpNfCkBGdKHOQTQNLsnsnzbFZarv2 = new zpNfCkBGdKHOQTQNLsnsnzbFZarv();
						zpNfCkBGdKHOQTQNLsnsnzbFZarv2.itJCPYPxsEthssbrrxFFlstxTUtB = uFbWQLXtZCNMXCQPLdTzbAgJORwC;
						Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
						if (ruleSetMapping != null)
						{
							zpNfCkBGdKHOQTQNLsnsnzbFZarv2.BeRuPmHFjqyMuMSSFoYRBpzEqfJh = ruleSetMapping.id;
							eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = zyicfphbNWNhnLtYBGjVzpGILGHcA.Find(zpNfCkBGdKHOQTQNLsnsnzbFZarv2.zDRdrKubddTQvrvrsVdfetzxnfNx);
							if (eFJIulbtZIHHuzVNqxYhzJhpFoLN3 == null)
							{
								Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + zpNfCkBGdKHOQTQNLsnsnzbFZarv2.BeRuPmHFjqyMuMSSFoYRBpzEqfJh);
								continue;
							}
							ruleSetMapping = ruleSetMapping.Clone();
							ruleSetMapping.id = eFJIulbtZIHHuzVNqxYhzJhpFoLN3.gkdQJIzCzIDwTytONjxEAbiVzNwh;
							list.Add(ruleSetMapping);
						}
					}
					player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
					List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
					List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
					for (int k = 0; k < ruleSets2.Count; k++)
					{
						cEgSVApSCZEiqguCKsMkDXzbyUdJB cEgSVApSCZEiqguCKsMkDXzbyUdJB2 = new cEgSVApSCZEiqguCKsMkDXzbyUdJB();
						cEgSVApSCZEiqguCKsMkDXzbyUdJB2.DgQGoOrQutlbpCmWRdOCfwlcdwjoA = uFbWQLXtZCNMXCQPLdTzbAgJORwC;
						Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
						if (ruleSetMapping2 != null)
						{
							cEgSVApSCZEiqguCKsMkDXzbyUdJB2.IQdEfntHwWUaVdcLUbMwwqPwvQKn = ruleSetMapping2.id;
							eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN4 = PxktMrpSaScLFLLEURexGEaKbiR.Find(cEgSVApSCZEiqguCKsMkDXzbyUdJB2.rCszvUjTfOkQxpnmyixufcaaAGzib);
							if (eFJIulbtZIHHuzVNqxYhzJhpFoLN4 == null)
							{
								Logger.LogError("No new Controller Map Enabler Set found for old id: " + cEgSVApSCZEiqguCKsMkDXzbyUdJB2.IQdEfntHwWUaVdcLUbMwwqPwvQKn);
								continue;
							}
							ruleSetMapping2 = ruleSetMapping2.Clone();
							ruleSetMapping2.id = eFJIulbtZIHHuzVNqxYhzJhpFoLN4.gkdQJIzCzIDwTytONjxEAbiVzNwh;
							list2.Add(ruleSetMapping2);
						}
					}
					player_Editor.controllerMapEnablerSettings.ruleSets = list2;
					Player_Editor player_Editor2;
					if (uFbWQLXtZCNMXCQPLdTzbAgJORwC.kOExsHCktIaGokmWqGWGwdcOWGqMA.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						player_Editor2 = uFbWQLXtZCNMXCQPLdTzbAgJORwC.kOExsHCktIaGokmWqGWGwdcOWGqMA.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
						Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
						player_Editor3.defaultKeyboardMaps.Clear();
						player_Editor3.defaultMouseMaps.Clear();
						player_Editor3.defaultJoystickMaps.Clear();
						player_Editor3.defaultCustomControllerMaps.Clear();
						player_Editor3.startingCustomControllers.Clear();
						Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.XlUFwflZlXhluCalMMcAYYNloiwn;
						sKSTYAeyawARtFjmbMnVqigNxAtX(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
						sKSTYAeyawARtFjmbMnVqigNxAtX(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
						sKSTYAeyawARtFjmbMnVqigNxAtX(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
						sKSTYAeyawARtFjmbMnVqigNxAtX(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
						sKSTYAeyawARtFjmbMnVqigNxAtX(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.gtbasYAuSLkANTvwijTDGYureABb);
						player_Editor = player_Editor3;
					}
					else
					{
						JriDYpZqsZXijWMTrEIxxKQrZESd.AddPlayer();
						player_Editor2 = uFbWQLXtZCNMXCQPLdTzbAgJORwC.kOExsHCktIaGokmWqGWGwdcOWGqMA.bhVeIrhShdJczTRbrsGlEjSFKnNDB[uFbWQLXtZCNMXCQPLdTzbAgJORwC.kOExsHCktIaGokmWqGWGwdcOWGqMA.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					player_Editor.id = player_Editor2.id;
					int index = uFbWQLXtZCNMXCQPLdTzbAgJORwC.kOExsHCktIaGokmWqGWGwdcOWGqMA.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(player_Editor2);
					uFbWQLXtZCNMXCQPLdTzbAgJORwC.kOExsHCktIaGokmWqGWGwdcOWGqMA.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = player_Editor;
					return player_Editor;
				}
			}

			private sealed class XypGNhvbPdSmqlEnkmzeaomkKdSq
			{
				public cYIhjwRJAbarRxYntUPKJXypBljV<InputAction> OKWKzyEaUmZcwEBzfwcOSHllwBEd;

				internal bool dFOTVfBhJfVzdxunWjpNmkDTTXJU(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(OKWKzyEaUmZcwEBzfwcOSHllwBEd.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == OKWKzyEaUmZcwEBzfwcOSHllwBEd.JmVlBWAzRCxDPyIGrXutTcvkAPfm.categoryId;
				}

				internal bool GtmCeRddJwkhkgoAniasqMGYDAkYA(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(OKWKzyEaUmZcwEBzfwcOSHllwBEd.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == OKWKzyEaUmZcwEBzfwcOSHllwBEd.JmVlBWAzRCxDPyIGrXutTcvkAPfm.behaviorId;
				}
			}

			private sealed class dDzCLdcCAantJaFUhBCaMewuFLQQB
			{
				public int qGDfonslWaPZrzOzhdyVjTzAlKem;

				public xzPgQeCtcEATuZLTJUJoESEeqFHp pQadItMONlbYZcsntvTyMzLMslBEA;

				internal bool JSkruExCKETmMyGFKHHJvJUlfsGDA(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(pQadItMONlbYZcsntvTyMzLMslBEA.WfdCGcrjsvbietUfJbRXmwKUSuEk.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == qGDfonslWaPZrzOzhdyVjTzAlKem;
				}
			}

			private sealed class irQOQvUDUOdHnlJLVCcKXImKzuWB
			{
				public int ChVcnXaGEXjBFaTMARJCGWoiLZegA;

				public xzPgQeCtcEATuZLTJUJoESEeqFHp PdNqzjMOJADIUNIvCprzOHKhlHrf;

				internal bool iHiyKmSeTPKvsGZwKNiAySoXcMhm(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(PdNqzjMOJADIUNIvCprzOHKhlHrf.WfdCGcrjsvbietUfJbRXmwKUSuEk.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == ChVcnXaGEXjBFaTMARJCGWoiLZegA;
				}
			}

			private sealed class UFbWQLXtZCNMXCQPLdTzbAgJORwC
			{
				public cYIhjwRJAbarRxYntUPKJXypBljV<Player_Editor> kOExsHCktIaGokmWqGWGwdcOWGqMA;

				public hywDDOGBuCFLDuASmWChqMOUGKds WEjbShwMcahZLHRUdaCrWKdIFftG;

				internal void ijhZalcABdPhYyMiBVrXTbcrasrs(List<Player_Editor.Mapping> P_0, List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> P_1)
				{
					for (int i = 0; i < P_0.Count; i++)
					{
						HldExmDcKDkrpoKVdDbJDVydGpuZB hldExmDcKDkrpoKVdDbJDVydGpuZB = new HldExmDcKDkrpoKVdDbJDVydGpuZB();
						hldExmDcKDkrpoKVdDbJDVydGpuZB.NKpoLSGFUGboIpoRmdWjBfOVuhbfA = this;
						hldExmDcKDkrpoKVdDbJDVydGpuZB.NLkPOHkKRYcugNXCnidRrinPampEA = P_0[i];
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = WEjbShwMcahZLHRUdaCrWKdIFftG.aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(hldExmDcKDkrpoKVdDbJDVydGpuZB.AIYSCArSVbzIwbeIyLLvMBkgMreU);
						hldExmDcKDkrpoKVdDbJDVydGpuZB.NLkPOHkKRYcugNXCnidRrinPampEA.categoryId = eFJIulbtZIHHuzVNqxYhzJhpFoLN2?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
						eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = P_1.Find(hldExmDcKDkrpoKVdDbJDVydGpuZB.OMNUQCStrzSJqMhWTqmQSEdbrjmi);
						hldExmDcKDkrpoKVdDbJDVydGpuZB.NLkPOHkKRYcugNXCnidRrinPampEA.layoutId = eFJIulbtZIHHuzVNqxYhzJhpFoLN2?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					}
				}
			}

			private sealed class HldExmDcKDkrpoKVdDbJDVydGpuZB
			{
				public Player_Editor.Mapping NLkPOHkKRYcugNXCnidRrinPampEA;

				public UFbWQLXtZCNMXCQPLdTzbAgJORwC NKpoLSGFUGboIpoRmdWjBfOVuhbfA;

				internal bool AIYSCArSVbzIwbeIyLLvMBkgMreU(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(NKpoLSGFUGboIpoRmdWjBfOVuhbfA.kOExsHCktIaGokmWqGWGwdcOWGqMA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == NLkPOHkKRYcugNXCnidRrinPampEA.categoryId;
				}

				internal bool OMNUQCStrzSJqMhWTqmQSEdbrjmi(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(NKpoLSGFUGboIpoRmdWjBfOVuhbfA.kOExsHCktIaGokmWqGWGwdcOWGqMA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == NLkPOHkKRYcugNXCnidRrinPampEA.layoutId;
				}
			}

			private sealed class lVEHEcxffKTcMnOCLtYvtNzVJXTJ
			{
				public Player_Editor.CreateControllerInfo HcLAnrpJPhUxsDrKngNpRrdjafKl;

				public UFbWQLXtZCNMXCQPLdTzbAgJORwC UZftDWxlsNDrlfOdUesvjjQDlhek;

				internal bool QUKbDwBkBNnDkEGadjQSIrKZtWIWB(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(UZftDWxlsNDrlfOdUesvjjQDlhek.kOExsHCktIaGokmWqGWGwdcOWGqMA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == HcLAnrpJPhUxsDrKngNpRrdjafKl.sourceId;
				}
			}

			private sealed class zpNfCkBGdKHOQTQNLsnsnzbFZarv
			{
				public int BeRuPmHFjqyMuMSSFoYRBpzEqfJh;

				public UFbWQLXtZCNMXCQPLdTzbAgJORwC itJCPYPxsEthssbrrxFFlstxTUtB;

				internal bool zDRdrKubddTQvrvrsVdfetzxnfNx(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(itJCPYPxsEthssbrrxFFlstxTUtB.kOExsHCktIaGokmWqGWGwdcOWGqMA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == BeRuPmHFjqyMuMSSFoYRBpzEqfJh;
				}
			}

			private sealed class cEgSVApSCZEiqguCKsMkDXzbyUdJB
			{
				public int IQdEfntHwWUaVdcLUbMwwqPwvQKn;

				public UFbWQLXtZCNMXCQPLdTzbAgJORwC DgQGoOrQutlbpCmWRdOCfwlcdwjoA;

				internal bool rCszvUjTfOkQxpnmyixufcaaAGzib(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(DgQGoOrQutlbpCmWRdOCfwlcdwjoA.kOExsHCktIaGokmWqGWGwdcOWGqMA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == IQdEfntHwWUaVdcLUbMwwqPwvQKn;
				}
			}

			private sealed class DSyatsHDDXKKGsMWtqSQeONggkGDB
			{
				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> KpSicIyMBMNEAQEZspEtqWnMRTGj;

				public hywDDOGBuCFLDuASmWChqMOUGKds XmiFtdLASibsaEXjgYyAMmhqOTzsA;

				internal int cBUdPFMHAuPwqdhkgkGEustwNJFj(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					erfiKcmJJpqMUzWUoJYGxJJSqWLs erfiKcmJJpqMUzWUoJYGxJJSqWLs2 = new erfiKcmJJpqMUzWUoJYGxJJSqWLs();
					erfiKcmJJpqMUzWUoJYGxJJSqWLs2.ajNjjuGLiBzjvKYYYngcTEidVpeJ = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = XmiFtdLASibsaEXjgYyAMmhqOTzsA.aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(erfiKcmJJpqMUzWUoJYGxJJSqWLs2.VcYpTMIegejHkHipWNtcfgdmObevA);
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = KpSicIyMBMNEAQEZspEtqWnMRTGj.Find(erfiKcmJJpqMUzWUoJYGxJJSqWLs2.VTKNnzoqBiDrXbnVeFTvSiwCLjtJA);
						if (eFJIulbtZIHHuzVNqxYhzJhpFoLN2 != null && eFJIulbtZIHHuzVNqxYhzJhpFoLN2.gkdQJIzCzIDwTytONjxEAbiVzNwh == P_1[i].categoryId && eFJIulbtZIHHuzVNqxYhzJhpFoLN3 != null && eFJIulbtZIHHuzVNqxYhzJhpFoLN3.gkdQJIzCzIDwTytONjxEAbiVzNwh == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor wlgGTgndiUiRGXeDtbYJndKrPpsQ(cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMap_Editor> P_0)
				{
					HSpJtBXiJkeTARtzizsjCDUdnJow hSpJtBXiJkeTARtzizsjCDUdnJow = new HSpJtBXiJkeTARtzizsjCDUdnJow();
					hSpJtBXiJkeTARtzizsjCDUdnJow.umbTbvuURZafbiBnQBcZrgfIHeeGA = P_0;
					hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP = JsonTools.Clone(hSpJtBXiJkeTARtzizsjCDUdnJow.umbTbvuURZafbiBnQBcZrgfIHeeGA.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = XmiFtdLASibsaEXjgYyAMmhqOTzsA.aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(hSpJtBXiJkeTARtzizsjCDUdnJow.iPmQQubipxcwtnyyqmvVZmTJVRly);
					eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = KpSicIyMBMNEAQEZspEtqWnMRTGj.Find(hSpJtBXiJkeTARtzizsjCDUdnJow.ffRlWlJtZzUGkksmDPCAxXCFBLDH);
					hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP.categoryId = eFJIulbtZIHHuzVNqxYhzJhpFoLN2?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP.layoutId = eFJIulbtZIHHuzVNqxYhzJhpFoLN3?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					for (int i = 0; i < hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP.actionElementMaps.Count; i++)
					{
						esstKSEhzNOvZAbqwXovbBCVJQpM esstKSEhzNOvZAbqwXovbBCVJQpM2 = new esstKSEhzNOvZAbqwXovbBCVJQpM();
						esstKSEhzNOvZAbqwXovbBCVJQpM2.JvHCVfERqFkCCfKFfOzlHEqhJFvBc = hSpJtBXiJkeTARtzizsjCDUdnJow;
						esstKSEhzNOvZAbqwXovbBCVJQpM2.dDkOUXBIRzbfEmKwKepAHzxSRaXvA = esstKSEhzNOvZAbqwXovbBCVJQpM2.JvHCVfERqFkCCfKFfOzlHEqhJFvBc.vPVRIZEbySXcMcnVVxQrWMkPmeiP.actionElementMaps[i];
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN4 = XmiFtdLASibsaEXjgYyAMmhqOTzsA.SKfweCgxnvICyWYvYOXZYCtiERry.Find(esstKSEhzNOvZAbqwXovbBCVJQpM2.rxMmCwuLErPdHrpzyPNhrdxewLQG);
						esstKSEhzNOvZAbqwXovbBCVJQpM2.dDkOUXBIRzbfEmKwKepAHzxSRaXvA._actionId = eFJIulbtZIHHuzVNqxYhzJhpFoLN4?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
						esstKSEhzNOvZAbqwXovbBCVJQpM2.dDkOUXBIRzbfEmKwKepAHzxSRaXvA._actionCategoryId = ((XmiFtdLASibsaEXjgYyAMmhqOTzsA.JriDYpZqsZXijWMTrEIxxKQrZESd.GetActionById(esstKSEhzNOvZAbqwXovbBCVJQpM2.dDkOUXBIRzbfEmKwKepAHzxSRaXvA._actionId) != null) ? XmiFtdLASibsaEXjgYyAMmhqOTzsA.JriDYpZqsZXijWMTrEIxxKQrZESd.GetActionById(esstKSEhzNOvZAbqwXovbBCVJQpM2.dDkOUXBIRzbfEmKwKepAHzxSRaXvA._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (hSpJtBXiJkeTARtzizsjCDUdnJow.umbTbvuURZafbiBnQBcZrgfIHeeGA.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						controllerMap_Editor = hSpJtBXiJkeTARtzizsjCDUdnJow.umbTbvuURZafbiBnQBcZrgfIHeeGA.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.oWCPfBfPnMIiwUGulgWtKqWcgzAU;
						sKSTYAeyawARtFjmbMnVqigNxAtX(controllerMap_Editor.actionElementMaps, hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP = controllerMap_Editor2;
					}
					else
					{
						XmiFtdLASibsaEXjgYyAMmhqOTzsA.JriDYpZqsZXijWMTrEIxxKQrZESd.CreateKeyboardMap(hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP.categoryId, hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP.layoutId);
						controllerMap_Editor = hSpJtBXiJkeTARtzizsjCDUdnJow.umbTbvuURZafbiBnQBcZrgfIHeeGA.bhVeIrhShdJczTRbrsGlEjSFKnNDB[hSpJtBXiJkeTARtzizsjCDUdnJow.umbTbvuURZafbiBnQBcZrgfIHeeGA.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP.id = controllerMap_Editor.id;
					int index = hSpJtBXiJkeTARtzizsjCDUdnJow.umbTbvuURZafbiBnQBcZrgfIHeeGA.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(controllerMap_Editor);
					hSpJtBXiJkeTARtzizsjCDUdnJow.umbTbvuURZafbiBnQBcZrgfIHeeGA.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP;
					return hSpJtBXiJkeTARtzizsjCDUdnJow.vPVRIZEbySXcMcnVVxQrWMkPmeiP;
				}
			}

			private sealed class erfiKcmJJpqMUzWUoJYGxJJSqWLs
			{
				public ControllerMap_Editor ajNjjuGLiBzjvKYYYngcTEidVpeJ;

				public Predicate<eFJIulbtZIHHuzVNqxYhzJhpFoLN> ofisUGZgxIGUBFVLqGoQqXbeWbsx;

				public Predicate<eFJIulbtZIHHuzVNqxYhzJhpFoLN> VCmnOptyTIVpkXiISssixGbUbvOk;

				internal bool VcYpTMIegejHkHipWNtcfgdmObevA(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.lVZZmSZiaLXScpukgqOuPZDQmmAq == ajNjjuGLiBzjvKYYYngcTEidVpeJ.categoryId;
				}

				internal bool VTKNnzoqBiDrXbnVeFTvSiwCLjtJA(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.lVZZmSZiaLXScpukgqOuPZDQmmAq == ajNjjuGLiBzjvKYYYngcTEidVpeJ.layoutId;
				}
			}

			private sealed class HSpJtBXiJkeTARtzizsjCDUdnJow
			{
				public cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMap_Editor> umbTbvuURZafbiBnQBcZrgfIHeeGA;

				public ControllerMap_Editor vPVRIZEbySXcMcnVVxQrWMkPmeiP;

				internal bool iPmQQubipxcwtnyyqmvVZmTJVRly(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(umbTbvuURZafbiBnQBcZrgfIHeeGA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == vPVRIZEbySXcMcnVVxQrWMkPmeiP.categoryId;
				}

				internal bool ffRlWlJtZzUGkksmDPCAxXCFBLDH(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(umbTbvuURZafbiBnQBcZrgfIHeeGA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == vPVRIZEbySXcMcnVVxQrWMkPmeiP.layoutId;
				}
			}

			private sealed class XWNabrFQBvFAMQRTRKotbzCJfrYdA
			{
				public List<int> IKbCehLxfKHZJNHoyKVUqidtIFKX;

				public hywDDOGBuCFLDuASmWChqMOUGKds ZNAAQJAdmueGbdIuiHcrJtVyoeHKc;

				internal InputMapCategory dEgWsxYnTTbZtjKhHuEyirUFBoNF(cYIhjwRJAbarRxYntUPKJXypBljV<InputMapCategory> P_0)
				{
					InputMapCategory inputMapCategory = JsonTools.Clone(P_0.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					InputMapCategory inputMapCategory2;
					if (P_0.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						inputMapCategory2 = P_0.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
					}
					else
					{
						ZNAAQJAdmueGbdIuiHcrJtVyoeHKc.JriDYpZqsZXijWMTrEIxxKQrZESd.AddMapCategory();
						inputMapCategory2 = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					int num = P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(inputMapCategory2);
					if (P_0.PEEFbqOcgugMjjZkfGBLPJxCaDPHb == eFJIulbtZIHHuzVNqxYhzJhpFoLN.IkeBrYocAnODfKzBeBrJCTHKqQbk.otherId)
					{
						IKbCehLxfKHZJNHoyKVUqidtIFKX.Add(num);
					}
					inputMapCategory.id = inputMapCategory2.id;
					P_0.bhVeIrhShdJczTRbrsGlEjSFKnNDB[num] = inputMapCategory;
					return inputMapCategory;
				}
			}

			private sealed class esstKSEhzNOvZAbqwXovbBCVJQpM
			{
				public ActionElementMap dDkOUXBIRzbfEmKwKepAHzxSRaXvA;

				public HSpJtBXiJkeTARtzizsjCDUdnJow JvHCVfERqFkCCfKFfOzlHEqhJFvBc;

				internal bool rxMmCwuLErPdHrpzyPNhrdxewLQG(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(JvHCVfERqFkCCfKFfOzlHEqhJFvBc.umbTbvuURZafbiBnQBcZrgfIHeeGA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == dDkOUXBIRzbfEmKwKepAHzxSRaXvA._actionId;
				}
			}

			private sealed class cBFVVafBHehFzEiLIsOmRdUxOmTFb
			{
				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> SlZlwEFKtUllopziQdatGPADlnMj;

				public hywDDOGBuCFLDuASmWChqMOUGKds RSYrQeYYIBfyFYGDGtVjUBJeFSSt;

				internal int aXjNGiZwtyEJGDAhZHYcWKeGNKhA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					jVHdVIOBqQEmpsBjwGZuihQvCuHX jVHdVIOBqQEmpsBjwGZuihQvCuHX2 = new jVHdVIOBqQEmpsBjwGZuihQvCuHX();
					jVHdVIOBqQEmpsBjwGZuihQvCuHX2.PBONrrUjVRFoiuuetdNXFiyooocgb = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = RSYrQeYYIBfyFYGDGtVjUBJeFSSt.aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(jVHdVIOBqQEmpsBjwGZuihQvCuHX2.zGYZMrJfneoqvqsDSnlSUwKLxJYM);
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = SlZlwEFKtUllopziQdatGPADlnMj.Find(jVHdVIOBqQEmpsBjwGZuihQvCuHX2.TfHdghjStjIFxHhPPmoTZnoUeXaz);
						if (eFJIulbtZIHHuzVNqxYhzJhpFoLN2 != null && eFJIulbtZIHHuzVNqxYhzJhpFoLN2.gkdQJIzCzIDwTytONjxEAbiVzNwh == P_1[i].categoryId && eFJIulbtZIHHuzVNqxYhzJhpFoLN3 != null && eFJIulbtZIHHuzVNqxYhzJhpFoLN3.gkdQJIzCzIDwTytONjxEAbiVzNwh == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor vxxUCxMHWDAWrhWpxhBfCjboSBYY(cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMap_Editor> P_0)
				{
					JpsCpVmQnPPQBmoctzKcamNwEaxt jpsCpVmQnPPQBmoctzKcamNwEaxt = new JpsCpVmQnPPQBmoctzKcamNwEaxt();
					jpsCpVmQnPPQBmoctzKcamNwEaxt.NyhSKLZlGpkoAPPSXRxXgrgcLCCs = P_0;
					jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY = JsonTools.Clone(jpsCpVmQnPPQBmoctzKcamNwEaxt.NyhSKLZlGpkoAPPSXRxXgrgcLCCs.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = RSYrQeYYIBfyFYGDGtVjUBJeFSSt.aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(jpsCpVmQnPPQBmoctzKcamNwEaxt.bgsIuPFwqAlCOIDoLRmZlPfdKWvl);
					eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = SlZlwEFKtUllopziQdatGPADlnMj.Find(jpsCpVmQnPPQBmoctzKcamNwEaxt.YumBaulFWkgyUhwgFXmVsybsdAlhA);
					jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY.categoryId = eFJIulbtZIHHuzVNqxYhzJhpFoLN2?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY.layoutId = eFJIulbtZIHHuzVNqxYhzJhpFoLN3?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					for (int i = 0; i < jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY.actionElementMaps.Count; i++)
					{
						RTurvZuThVayqeMlXQXWDoYYpPbR rTurvZuThVayqeMlXQXWDoYYpPbR = new RTurvZuThVayqeMlXQXWDoYYpPbR();
						rTurvZuThVayqeMlXQXWDoYYpPbR.uyQhXkUQQnfRfbLiuSZCCMmAPbsw = jpsCpVmQnPPQBmoctzKcamNwEaxt;
						rTurvZuThVayqeMlXQXWDoYYpPbR.cNsLgkBoluRIipdUMEvxNaWQZDsV = rTurvZuThVayqeMlXQXWDoYYpPbR.uyQhXkUQQnfRfbLiuSZCCMmAPbsw.IwCQcoEooOKksLIOdfaDdWNOTOuY.actionElementMaps[i];
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN4 = RSYrQeYYIBfyFYGDGtVjUBJeFSSt.SKfweCgxnvICyWYvYOXZYCtiERry.Find(rTurvZuThVayqeMlXQXWDoYYpPbR.xwhKZFfcquxkqCqRihMaaJWiPXmS);
						rTurvZuThVayqeMlXQXWDoYYpPbR.cNsLgkBoluRIipdUMEvxNaWQZDsV._actionId = eFJIulbtZIHHuzVNqxYhzJhpFoLN4?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
						rTurvZuThVayqeMlXQXWDoYYpPbR.cNsLgkBoluRIipdUMEvxNaWQZDsV._actionCategoryId = ((RSYrQeYYIBfyFYGDGtVjUBJeFSSt.JriDYpZqsZXijWMTrEIxxKQrZESd.GetActionById(rTurvZuThVayqeMlXQXWDoYYpPbR.cNsLgkBoluRIipdUMEvxNaWQZDsV._actionId) != null) ? RSYrQeYYIBfyFYGDGtVjUBJeFSSt.JriDYpZqsZXijWMTrEIxxKQrZESd.GetActionById(rTurvZuThVayqeMlXQXWDoYYpPbR.cNsLgkBoluRIipdUMEvxNaWQZDsV._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (jpsCpVmQnPPQBmoctzKcamNwEaxt.NyhSKLZlGpkoAPPSXRxXgrgcLCCs.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						controllerMap_Editor = jpsCpVmQnPPQBmoctzKcamNwEaxt.NyhSKLZlGpkoAPPSXRxXgrgcLCCs.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.jgZXVNSHtwfGxGVUbrcnlwgDunOT;
						sKSTYAeyawARtFjmbMnVqigNxAtX(controllerMap_Editor.actionElementMaps, jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY = controllerMap_Editor2;
					}
					else
					{
						RSYrQeYYIBfyFYGDGtVjUBJeFSSt.JriDYpZqsZXijWMTrEIxxKQrZESd.CreateMouseMap(jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY.categoryId, jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY.layoutId);
						controllerMap_Editor = jpsCpVmQnPPQBmoctzKcamNwEaxt.NyhSKLZlGpkoAPPSXRxXgrgcLCCs.bhVeIrhShdJczTRbrsGlEjSFKnNDB[jpsCpVmQnPPQBmoctzKcamNwEaxt.NyhSKLZlGpkoAPPSXRxXgrgcLCCs.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY.id = controllerMap_Editor.id;
					int index = jpsCpVmQnPPQBmoctzKcamNwEaxt.NyhSKLZlGpkoAPPSXRxXgrgcLCCs.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(controllerMap_Editor);
					jpsCpVmQnPPQBmoctzKcamNwEaxt.NyhSKLZlGpkoAPPSXRxXgrgcLCCs.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY;
					return jpsCpVmQnPPQBmoctzKcamNwEaxt.IwCQcoEooOKksLIOdfaDdWNOTOuY;
				}
			}

			private sealed class jVHdVIOBqQEmpsBjwGZuihQvCuHX
			{
				public ControllerMap_Editor PBONrrUjVRFoiuuetdNXFiyooocgb;

				public Predicate<eFJIulbtZIHHuzVNqxYhzJhpFoLN> dmhcaacVuQTYyTKbUoyyHQyahhhWA;

				public Predicate<eFJIulbtZIHHuzVNqxYhzJhpFoLN> BbtOocnsRDLRUyNfINFppHBSkCfc;

				internal bool zGYZMrJfneoqvqsDSnlSUwKLxJYM(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.lVZZmSZiaLXScpukgqOuPZDQmmAq == PBONrrUjVRFoiuuetdNXFiyooocgb.categoryId;
				}

				internal bool TfHdghjStjIFxHhPPmoTZnoUeXaz(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.lVZZmSZiaLXScpukgqOuPZDQmmAq == PBONrrUjVRFoiuuetdNXFiyooocgb.layoutId;
				}
			}

			private sealed class JpsCpVmQnPPQBmoctzKcamNwEaxt
			{
				public cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMap_Editor> NyhSKLZlGpkoAPPSXRxXgrgcLCCs;

				public ControllerMap_Editor IwCQcoEooOKksLIOdfaDdWNOTOuY;

				internal bool bgsIuPFwqAlCOIDoLRmZlPfdKWvl(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(NyhSKLZlGpkoAPPSXRxXgrgcLCCs.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == IwCQcoEooOKksLIOdfaDdWNOTOuY.categoryId;
				}

				internal bool YumBaulFWkgyUhwgFXmVsybsdAlhA(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(NyhSKLZlGpkoAPPSXRxXgrgcLCCs.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == IwCQcoEooOKksLIOdfaDdWNOTOuY.layoutId;
				}
			}

			private sealed class RTurvZuThVayqeMlXQXWDoYYpPbR
			{
				public ActionElementMap cNsLgkBoluRIipdUMEvxNaWQZDsV;

				public JpsCpVmQnPPQBmoctzKcamNwEaxt uyQhXkUQQnfRfbLiuSZCCMmAPbsw;

				internal bool xwhKZFfcquxkqCqRihMaaJWiPXmS(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(uyQhXkUQQnfRfbLiuSZCCMmAPbsw.NyhSKLZlGpkoAPPSXRxXgrgcLCCs.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == cNsLgkBoluRIipdUMEvxNaWQZDsV._actionId;
				}
			}

			private sealed class BIgAcLUNECeGnhywwFxnHqxVqmOHb
			{
				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> iFGiwmFOXgqHAycRhOnbaAkAEuYwA;

				public hywDDOGBuCFLDuASmWChqMOUGKds degnEjdyLvwcQCKggkIJcihEMKYH;

				internal int RrXeQuclnbSfdeOUJlbqvlCCACYL(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					AfpaLTBGUuiSGDGviRqlVcECoOOiA afpaLTBGUuiSGDGviRqlVcECoOOiA = new AfpaLTBGUuiSGDGviRqlVcECoOOiA();
					afpaLTBGUuiSGDGviRqlVcECoOOiA.MhERuSKRXIRVVBBcfAwSCsawkFnzA = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = degnEjdyLvwcQCKggkIJcihEMKYH.aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(afpaLTBGUuiSGDGviRqlVcECoOOiA.kaqqFNoFJUvJkLyglteZVutJDZCJ);
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = iFGiwmFOXgqHAycRhOnbaAkAEuYwA.Find(afpaLTBGUuiSGDGviRqlVcECoOOiA.UQbxfuvcETuZHSSjdKVpYeygFAAf);
						if (afpaLTBGUuiSGDGviRqlVcECoOOiA.MhERuSKRXIRVVBBcfAwSCsawkFnzA.hardwareGuid == P_1[i].hardwareGuid && eFJIulbtZIHHuzVNqxYhzJhpFoLN2 != null && eFJIulbtZIHHuzVNqxYhzJhpFoLN2.gkdQJIzCzIDwTytONjxEAbiVzNwh == P_1[i].categoryId && eFJIulbtZIHHuzVNqxYhzJhpFoLN3 != null && eFJIulbtZIHHuzVNqxYhzJhpFoLN3.gkdQJIzCzIDwTytONjxEAbiVzNwh == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor hijmRiUiVEvZKBCOcgxpbNLPHztj(cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMap_Editor> P_0)
				{
					ETmBcYIdaeDDktpFmklEgDvCDLYYA eTmBcYIdaeDDktpFmklEgDvCDLYYA = new ETmBcYIdaeDDktpFmklEgDvCDLYYA();
					eTmBcYIdaeDDktpFmklEgDvCDLYYA.fBnwszcGfHAqqGpbKuQBKsysTvCK = P_0;
					eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI = JsonTools.Clone(eTmBcYIdaeDDktpFmklEgDvCDLYYA.fBnwszcGfHAqqGpbKuQBKsysTvCK.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = degnEjdyLvwcQCKggkIJcihEMKYH.aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(eTmBcYIdaeDDktpFmklEgDvCDLYYA.hYqMZQdnuuBELVlkWnCMbotyVZIm);
					eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = iFGiwmFOXgqHAycRhOnbaAkAEuYwA.Find(eTmBcYIdaeDDktpFmklEgDvCDLYYA.fzDellbQEIqOJrIPbiXUhINZyjBr);
					eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI.categoryId = eFJIulbtZIHHuzVNqxYhzJhpFoLN2?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI.layoutId = eFJIulbtZIHHuzVNqxYhzJhpFoLN3?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					for (int i = 0; i < eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI.actionElementMaps.Count; i++)
					{
						QtVAaEOcwFtDFLkCzxwhidxmPgTA qtVAaEOcwFtDFLkCzxwhidxmPgTA = new QtVAaEOcwFtDFLkCzxwhidxmPgTA();
						qtVAaEOcwFtDFLkCzxwhidxmPgTA.DAmBmMCPafRzpJjgqBsDMyrJHDILA = eTmBcYIdaeDDktpFmklEgDvCDLYYA;
						qtVAaEOcwFtDFLkCzxwhidxmPgTA.hHsKCivGnzFIypOokeAUpfyuuBc = qtVAaEOcwFtDFLkCzxwhidxmPgTA.DAmBmMCPafRzpJjgqBsDMyrJHDILA.ENuTJhxfKXxhlidedjAEwgwPOryI.actionElementMaps[i];
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN4 = degnEjdyLvwcQCKggkIJcihEMKYH.SKfweCgxnvICyWYvYOXZYCtiERry.Find(qtVAaEOcwFtDFLkCzxwhidxmPgTA.FwdRiLTkgjdPikEAieEaYcKNbPkN);
						qtVAaEOcwFtDFLkCzxwhidxmPgTA.hHsKCivGnzFIypOokeAUpfyuuBc._actionId = eFJIulbtZIHHuzVNqxYhzJhpFoLN4?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
						qtVAaEOcwFtDFLkCzxwhidxmPgTA.hHsKCivGnzFIypOokeAUpfyuuBc._actionCategoryId = ((degnEjdyLvwcQCKggkIJcihEMKYH.JriDYpZqsZXijWMTrEIxxKQrZESd.GetActionById(qtVAaEOcwFtDFLkCzxwhidxmPgTA.hHsKCivGnzFIypOokeAUpfyuuBc._actionId) != null) ? degnEjdyLvwcQCKggkIJcihEMKYH.JriDYpZqsZXijWMTrEIxxKQrZESd.GetActionById(qtVAaEOcwFtDFLkCzxwhidxmPgTA.hHsKCivGnzFIypOokeAUpfyuuBc._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (eTmBcYIdaeDDktpFmklEgDvCDLYYA.fBnwszcGfHAqqGpbKuQBKsysTvCK.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						controllerMap_Editor = eTmBcYIdaeDDktpFmklEgDvCDLYYA.fBnwszcGfHAqqGpbKuQBKsysTvCK.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.CvcaBInjhADwUhnSpGlZYdWfXYIJ;
						sKSTYAeyawARtFjmbMnVqigNxAtX(controllerMap_Editor.actionElementMaps, eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI = controllerMap_Editor2;
					}
					else
					{
						degnEjdyLvwcQCKggkIJcihEMKYH.JriDYpZqsZXijWMTrEIxxKQrZESd.CreateJoystickMap(eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI.categoryId, eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI.hardwareGuid, eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI.layoutId);
						controllerMap_Editor = eTmBcYIdaeDDktpFmklEgDvCDLYYA.fBnwszcGfHAqqGpbKuQBKsysTvCK.bhVeIrhShdJczTRbrsGlEjSFKnNDB[eTmBcYIdaeDDktpFmklEgDvCDLYYA.fBnwszcGfHAqqGpbKuQBKsysTvCK.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI.id = controllerMap_Editor.id;
					int index = eTmBcYIdaeDDktpFmklEgDvCDLYYA.fBnwszcGfHAqqGpbKuQBKsysTvCK.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(controllerMap_Editor);
					eTmBcYIdaeDDktpFmklEgDvCDLYYA.fBnwszcGfHAqqGpbKuQBKsysTvCK.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI;
					return eTmBcYIdaeDDktpFmklEgDvCDLYYA.ENuTJhxfKXxhlidedjAEwgwPOryI;
				}
			}

			private sealed class AfpaLTBGUuiSGDGviRqlVcECoOOiA
			{
				public ControllerMap_Editor MhERuSKRXIRVVBBcfAwSCsawkFnzA;

				public Predicate<eFJIulbtZIHHuzVNqxYhzJhpFoLN> KEsvkJuLWOlLJJljsOcqSKUkfhKG;

				public Predicate<eFJIulbtZIHHuzVNqxYhzJhpFoLN> EpEOdtLFcIcKISClOrghLIfxeran;

				internal bool kaqqFNoFJUvJkLyglteZVutJDZCJ(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.lVZZmSZiaLXScpukgqOuPZDQmmAq == MhERuSKRXIRVVBBcfAwSCsawkFnzA.categoryId;
				}

				internal bool UQbxfuvcETuZHSSjdKVpYeygFAAf(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.lVZZmSZiaLXScpukgqOuPZDQmmAq == MhERuSKRXIRVVBBcfAwSCsawkFnzA.layoutId;
				}
			}

			private sealed class ETmBcYIdaeDDktpFmklEgDvCDLYYA
			{
				public cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMap_Editor> fBnwszcGfHAqqGpbKuQBKsysTvCK;

				public ControllerMap_Editor ENuTJhxfKXxhlidedjAEwgwPOryI;

				internal bool hYqMZQdnuuBELVlkWnCMbotyVZIm(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(fBnwszcGfHAqqGpbKuQBKsysTvCK.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == ENuTJhxfKXxhlidedjAEwgwPOryI.categoryId;
				}

				internal bool fzDellbQEIqOJrIPbiXUhINZyjBr(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(fBnwszcGfHAqqGpbKuQBKsysTvCK.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == ENuTJhxfKXxhlidedjAEwgwPOryI.layoutId;
				}
			}

			private sealed class QtVAaEOcwFtDFLkCzxwhidxmPgTA
			{
				public ActionElementMap hHsKCivGnzFIypOokeAUpfyuuBc;

				public ETmBcYIdaeDDktpFmklEgDvCDLYYA DAmBmMCPafRzpJjgqBsDMyrJHDILA;

				internal bool FwdRiLTkgjdPikEAieEaYcKNbPkN(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(DAmBmMCPafRzpJjgqBsDMyrJHDILA.fBnwszcGfHAqqGpbKuQBKsysTvCK.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == hHsKCivGnzFIypOokeAUpfyuuBc._actionId;
				}
			}

			private sealed class EQKhQmJkMndYmVnEfYWhuovxmJwL
			{
				public List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> KjRmXpYJzILfTxHiIEARsREvqpBk;

				public hywDDOGBuCFLDuASmWChqMOUGKds qJHbfYgNbfFpSHJDqDjLaFBIRfdz;

				internal int joGFmCDnORdczdtdALJlnnvTUwaJA(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
				{
					mXWglXHKTnXEHJflJfnpBOlVaPkjA mXWglXHKTnXEHJflJfnpBOlVaPkjA2 = new mXWglXHKTnXEHJflJfnpBOlVaPkjA();
					mXWglXHKTnXEHJflJfnpBOlVaPkjA2.ArpmFtCZMLPPeYsEyBJauKTIhmWH = P_0;
					for (int i = 0; i < P_1.Count; i++)
					{
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = qJHbfYgNbfFpSHJDqDjLaFBIRfdz.FKzDjdoLQXGfSaKoIECNsuRCNqbXA.Find(mXWglXHKTnXEHJflJfnpBOlVaPkjA2.AYqERVWiQVEZoGangGSCJjWDIizfb);
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = qJHbfYgNbfFpSHJDqDjLaFBIRfdz.aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(mXWglXHKTnXEHJflJfnpBOlVaPkjA2.uqBicDawyGLhJFwbMMGBbBuaRqJC);
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN4 = KjRmXpYJzILfTxHiIEARsREvqpBk.Find(mXWglXHKTnXEHJflJfnpBOlVaPkjA2.dZIMFwvRkcAbcxIJCqnJmKWHwefA);
						if (eFJIulbtZIHHuzVNqxYhzJhpFoLN2 != null && eFJIulbtZIHHuzVNqxYhzJhpFoLN2.gkdQJIzCzIDwTytONjxEAbiVzNwh == P_1[i].customControllerUid && eFJIulbtZIHHuzVNqxYhzJhpFoLN3 != null && eFJIulbtZIHHuzVNqxYhzJhpFoLN3.gkdQJIzCzIDwTytONjxEAbiVzNwh == P_1[i].categoryId && eFJIulbtZIHHuzVNqxYhzJhpFoLN4 != null && eFJIulbtZIHHuzVNqxYhzJhpFoLN4.gkdQJIzCzIDwTytONjxEAbiVzNwh == P_1[i].layoutId)
						{
							return i;
						}
					}
					return -1;
				}

				internal ControllerMap_Editor NWiEScKRKUfmmfTflwsuBWKwmsNk(cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMap_Editor> P_0)
				{
					DZWjWBLGNTkUDFfHlyOZXYpELreH dZWjWBLGNTkUDFfHlyOZXYpELreH = new DZWjWBLGNTkUDFfHlyOZXYpELreH();
					dZWjWBLGNTkUDFfHlyOZXYpELreH.drlQJZOooAuUwVVJTWrVzTweAkcb = P_0;
					dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk = JsonTools.Clone(dZWjWBLGNTkUDFfHlyOZXYpELreH.drlQJZOooAuUwVVJTWrVzTweAkcb.JmVlBWAzRCxDPyIGrXutTcvkAPfm);
					eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = qJHbfYgNbfFpSHJDqDjLaFBIRfdz.FKzDjdoLQXGfSaKoIECNsuRCNqbXA.Find(dZWjWBLGNTkUDFfHlyOZXYpELreH.hWecMhIdzrszgjollwQFWunoXBHj);
					eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN3 = qJHbfYgNbfFpSHJDqDjLaFBIRfdz.aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(dZWjWBLGNTkUDFfHlyOZXYpELreH.hvCkDgdDJbzDpnqdmdMJkiEvSwSNA);
					eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN4 = KjRmXpYJzILfTxHiIEARsREvqpBk.Find(dZWjWBLGNTkUDFfHlyOZXYpELreH.fLsfKupUjgFlaGIhWGEgXlzfuSxb);
					dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk.customControllerUid = eFJIulbtZIHHuzVNqxYhzJhpFoLN2?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk.categoryId = eFJIulbtZIHHuzVNqxYhzJhpFoLN3?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk.layoutId = eFJIulbtZIHHuzVNqxYhzJhpFoLN4?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					for (int i = 0; i < dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk.actionElementMaps.Count; i++)
					{
						CctVillpVJopErMhTzfKAWsdKuNd cctVillpVJopErMhTzfKAWsdKuNd = new CctVillpVJopErMhTzfKAWsdKuNd();
						cctVillpVJopErMhTzfKAWsdKuNd.VzuTcrsnQzIfkMMkFSOevYndbawF = dZWjWBLGNTkUDFfHlyOZXYpELreH;
						cctVillpVJopErMhTzfKAWsdKuNd.uFbvzZDeNFjUWGzUlaPxSpMniKXM = cctVillpVJopErMhTzfKAWsdKuNd.VzuTcrsnQzIfkMMkFSOevYndbawF.eDaiauhoCdjDhogbOHFBOFWTULUk.actionElementMaps[i];
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN5 = qJHbfYgNbfFpSHJDqDjLaFBIRfdz.SKfweCgxnvICyWYvYOXZYCtiERry.Find(cctVillpVJopErMhTzfKAWsdKuNd.AafVjRbWpyTBHfcHpmFqopdWvQdK);
						cctVillpVJopErMhTzfKAWsdKuNd.uFbvzZDeNFjUWGzUlaPxSpMniKXM._actionId = eFJIulbtZIHHuzVNqxYhzJhpFoLN5?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
						cctVillpVJopErMhTzfKAWsdKuNd.uFbvzZDeNFjUWGzUlaPxSpMniKXM._actionCategoryId = ((qJHbfYgNbfFpSHJDqDjLaFBIRfdz.JriDYpZqsZXijWMTrEIxxKQrZESd.GetActionById(cctVillpVJopErMhTzfKAWsdKuNd.uFbvzZDeNFjUWGzUlaPxSpMniKXM._actionId) != null) ? qJHbfYgNbfFpSHJDqDjLaFBIRfdz.JriDYpZqsZXijWMTrEIxxKQrZESd.GetActionById(cctVillpVJopErMhTzfKAWsdKuNd.uFbvzZDeNFjUWGzUlaPxSpMniKXM._actionId).categoryId : 0);
					}
					ControllerMap_Editor controllerMap_Editor;
					if (dZWjWBLGNTkUDFfHlyOZXYpELreH.drlQJZOooAuUwVVJTWrVzTweAkcb.rKoqRGNPlrMOxdpDDXAykCXnyiwb)
					{
						controllerMap_Editor = dZWjWBLGNTkUDFfHlyOZXYpELreH.drlQJZOooAuUwVVJTWrVzTweAkcb.dGQWoGnpumNrrOJbFivKEdXmNCqdA;
						ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk);
						controllerMap_Editor2.actionElementMaps.Clear();
						Func<ActionElementMap, IList<ActionElementMap>, int> func = uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.CZXdaqTKDDLLmDWBYMUTqkNMBHHF;
						sKSTYAeyawARtFjmbMnVqigNxAtX(controllerMap_Editor.actionElementMaps, dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
						dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk = controllerMap_Editor2;
					}
					else
					{
						qJHbfYgNbfFpSHJDqDjLaFBIRfdz.JriDYpZqsZXijWMTrEIxxKQrZESd.CreateCustomControllerMap(dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk.categoryId, dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk.customControllerUid, dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk.layoutId);
						controllerMap_Editor = dZWjWBLGNTkUDFfHlyOZXYpELreH.drlQJZOooAuUwVVJTWrVzTweAkcb.bhVeIrhShdJczTRbrsGlEjSFKnNDB[dZWjWBLGNTkUDFfHlyOZXYpELreH.drlQJZOooAuUwVVJTWrVzTweAkcb.bhVeIrhShdJczTRbrsGlEjSFKnNDB.Count - 1];
					}
					dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk.id = controllerMap_Editor.id;
					int index = dZWjWBLGNTkUDFfHlyOZXYpELreH.drlQJZOooAuUwVVJTWrVzTweAkcb.bhVeIrhShdJczTRbrsGlEjSFKnNDB.IndexOf(controllerMap_Editor);
					dZWjWBLGNTkUDFfHlyOZXYpELreH.drlQJZOooAuUwVVJTWrVzTweAkcb.bhVeIrhShdJczTRbrsGlEjSFKnNDB[index] = dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk;
					return dZWjWBLGNTkUDFfHlyOZXYpELreH.eDaiauhoCdjDhogbOHFBOFWTULUk;
				}
			}

			private sealed class irnCenFDLezutojwfHiPEbCDxcBvB
			{
				public int UOlUeQgFaJaKGzoLPAuEECtBACDbb;

				internal bool lDmaEYjPHlpqXJxuyQOwKnemQcOQ(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.lVZZmSZiaLXScpukgqOuPZDQmmAq == UOlUeQgFaJaKGzoLPAuEECtBACDbb;
				}
			}

			private sealed class mXWglXHKTnXEHJflJfnpBOlVaPkjA
			{
				public ControllerMap_Editor ArpmFtCZMLPPeYsEyBJauKTIhmWH;

				public Predicate<eFJIulbtZIHHuzVNqxYhzJhpFoLN> goiJejCbDwLjrPhhMtRMQXogMGMd;

				public Predicate<eFJIulbtZIHHuzVNqxYhzJhpFoLN> gHLJJwijhtBaFbwKNkTRIPvjPnnWA;

				public Predicate<eFJIulbtZIHHuzVNqxYhzJhpFoLN> wXBccmldxKwLgIYZlWUXnxWrLHHB;

				internal bool AYqERVWiQVEZoGangGSCJjWDIizfb(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.lVZZmSZiaLXScpukgqOuPZDQmmAq == ArpmFtCZMLPPeYsEyBJauKTIhmWH.customControllerUid;
				}

				internal bool uqBicDawyGLhJFwbMMGBbBuaRqJC(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.lVZZmSZiaLXScpukgqOuPZDQmmAq == ArpmFtCZMLPPeYsEyBJauKTIhmWH.categoryId;
				}

				internal bool dZIMFwvRkcAbcxIJCqnJmKWHwefA(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.lVZZmSZiaLXScpukgqOuPZDQmmAq == ArpmFtCZMLPPeYsEyBJauKTIhmWH.layoutId;
				}
			}

			private sealed class DZWjWBLGNTkUDFfHlyOZXYpELreH
			{
				public cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMap_Editor> drlQJZOooAuUwVVJTWrVzTweAkcb;

				public ControllerMap_Editor eDaiauhoCdjDhogbOHFBOFWTULUk;

				internal bool hWecMhIdzrszgjollwQFWunoXBHj(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(drlQJZOooAuUwVVJTWrVzTweAkcb.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == eDaiauhoCdjDhogbOHFBOFWTULUk.customControllerUid;
				}

				internal bool hvCkDgdDJbzDpnqdmdMJkiEvSwSNA(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(drlQJZOooAuUwVVJTWrVzTweAkcb.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == eDaiauhoCdjDhogbOHFBOFWTULUk.categoryId;
				}

				internal bool fLsfKupUjgFlaGIhWGEgXlzfuSxb(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(drlQJZOooAuUwVVJTWrVzTweAkcb.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == eDaiauhoCdjDhogbOHFBOFWTULUk.layoutId;
				}
			}

			private sealed class CctVillpVJopErMhTzfKAWsdKuNd
			{
				public ActionElementMap uFbvzZDeNFjUWGzUlaPxSpMniKXM;

				public DZWjWBLGNTkUDFfHlyOZXYpELreH VzuTcrsnQzIfkMMkFSOevYndbawF;

				internal bool AafVjRbWpyTBHfcHpmFqopdWvQdK(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(VzuTcrsnQzIfkMMkFSOevYndbawF.drlQJZOooAuUwVVJTWrVzTweAkcb.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == uFbvzZDeNFjUWGzUlaPxSpMniKXM._actionId;
				}
			}

			private sealed class sNpbAsKKJPgVLtDziEZJIgrLHvcP
			{
				public cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMapLayoutManager_RuleSet_Editor> morhaRbOWvbFriyqdjhknVtibboAA;
			}

			private sealed class VJYyQhKUxzCsgFAxzNLxcBKYfqBS
			{
				public int tfNaSOrPSeaqFXohOMnBiUdXRBmL;

				public sNpbAsKKJPgVLtDziEZJIgrLHvcP BtYvtFIgOpBFXSndOGitWbNuHNFG;

				internal bool fznNHpMrlUeIYmuyBUqXdOQhBsiK(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(BtYvtFIgOpBFXSndOGitWbNuHNFG.morhaRbOWvbFriyqdjhknVtibboAA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == tfNaSOrPSeaqFXohOMnBiUdXRBmL;
				}
			}

			private sealed class zsKhhJfelEckilFfcbzEeJDdBUKw
			{
				public int jGprvpwJLIZRgyeggeerbnDAiBZG;

				public sNpbAsKKJPgVLtDziEZJIgrLHvcP gmogvKudvZYmsJxsKXPTHswNqVQE;

				internal bool YLDnShsPUagnRVqZEoqQfygDNZAt(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(gmogvKudvZYmsJxsKXPTHswNqVQE.morhaRbOWvbFriyqdjhknVtibboAA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == jGprvpwJLIZRgyeggeerbnDAiBZG;
				}
			}

			private sealed class uUZRmPtTmeudewXFVjYswMhogJdR
			{
				public int KVZtROPvyuFUKfyASJIFJYrwCgXE;

				public sNpbAsKKJPgVLtDziEZJIgrLHvcP eMojbAlRCpGleQRRUNTcuUmGuJWR;

				internal bool lmRLAsAPKOGomEzxOGYjrtTOenvQA(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(eMojbAlRCpGleQRRUNTcuUmGuJWR.morhaRbOWvbFriyqdjhknVtibboAA.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == KVZtROPvyuFUKfyASJIFJYrwCgXE;
				}
			}

			private sealed class xzPgQeCtcEATuZLTJUJoESEeqFHp
			{
				public cYIhjwRJAbarRxYntUPKJXypBljV<ControllerMapEnabler_RuleSet_Editor> WfdCGcrjsvbietUfJbRXmwKUSuEk;
			}

			private sealed class BmIwJUHvDeSqNGeRlrQuIBNpMQWM
			{
				public int HhFCRQIIaAETkXBURuSmNfLHhwnIA;

				public xzPgQeCtcEATuZLTJUJoESEeqFHp sdqZcLwbIQxrzJbIMMAqknBywZAD;

				internal bool dpUDlFcyBhtlmNcacLIITTwGjuWh(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.hkgtfirpqmOkXsAZmvCUbrUAHeP(sdqZcLwbIQxrzJbIMMAqknBywZAD.WfdCGcrjsvbietUfJbRXmwKUSuEk.PEEFbqOcgugMjjZkfGBLPJxCaDPHb) == HhFCRQIIaAETkXBURuSmNfLHhwnIA;
				}
			}

			private sealed class ItZNgWDQsZmMwpeaSnahWpCspFCl<_0001> where _0001 : class
			{
				public Func<_0001, int> KRpArXaOMmwgQtmmGQhOkNfinyUeA;
			}

			private sealed class erjrURtHmNkbzQUGtQaXRTYzHNAJ<_0001> where _0001 : class
			{
				public _0001 gFfhOtBVQqZcSHZVNLvwMTHbfdnK;

				public ItZNgWDQsZmMwpeaSnahWpCspFCl<_0001> TbVMdpUQaHanSJFQVrDLpRIeQDzJ;

				internal bool PeKNorZDUcbXWuEPipiwoaiIqeaK(eFJIulbtZIHHuzVNqxYhzJhpFoLN P_0)
				{
					return P_0.gkdQJIzCzIDwTytONjxEAbiVzNwh == TbVMdpUQaHanSJFQVrDLpRIeQDzJ.KRpArXaOMmwgQtmmGQhOkNfinyUeA(gFfhOtBVQqZcSHZVNLvwMTHbfdnK);
				}
			}

			public static UserData XTZEeCaFhjTFVQzSvArFEilqXpYf(UserData P_0, UserData P_1, bool P_2)
			{
				hywDDOGBuCFLDuASmWChqMOUGKds hywDDOGBuCFLDuASmWChqMOUGKds2 = new hywDDOGBuCFLDuASmWChqMOUGKds();
				if (P_0 == null)
				{
					throw new ArgumentNullException("orig");
				}
				P_0 = JsonTools.Clone(P_0);
				P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
				hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd = (P_2 ? P_0 : new UserData(false));
				if (P_1 != null)
				{
					hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.configVars = JsonTools.Clone(P_1.configVars);
				}
				else
				{
					hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.configVars = JsonTools.Clone(P_0.configVars);
				}
				hywDDOGBuCFLDuASmWChqMOUGKds2.xPlYfWEvbUHuhWiQVjlVUOiederj = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Action Category", P_0.actionCategories, P_1?.actionCategories, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.actionCategories, P_2, hywDDOGBuCFLDuASmWChqMOUGKds2.xPlYfWEvbUHuhWiQVjlVUOiederj, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.lPvZApGHqqxrLttqEwwVBHVjQMBt, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.SMowhInKXztHOIAOljDoAJwFfnLz, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.nSdcltmwkGcOdPBKdejqMFWsvMDS, hywDDOGBuCFLDuASmWChqMOUGKds2.sHFtgavuYSekiKrckeIbyiBwAmhv);
				hywDDOGBuCFLDuASmWChqMOUGKds2.RUnEalIpbgGetKQmXysLdutQIQpab = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.inputBehaviors, P_2, hywDDOGBuCFLDuASmWChqMOUGKds2.RUnEalIpbgGetKQmXysLdutQIQpab, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.frZOzhkOFUCiuRAqvapXCVxNsoFr, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.HOUXAqEZgCFKACJrUyNpDCbaYmWt, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.IUuvddaHKoEWveGWoEYnLUmqgrjLA, hywDDOGBuCFLDuASmWChqMOUGKds2.wDOWlxWalxIuMxaOGkoclwFuFZST);
				hywDDOGBuCFLDuASmWChqMOUGKds2.SKfweCgxnvICyWYvYOXZYCtiERry = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Action", P_0.cnjJGampiqifPHPSycEOPktSoDLW, P_1?.cnjJGampiqifPHPSycEOPktSoDLW, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.cnjJGampiqifPHPSycEOPktSoDLW, P_2, hywDDOGBuCFLDuASmWChqMOUGKds2.SKfweCgxnvICyWYvYOXZYCtiERry, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.mmDOYwEDYOfoZIJPNJDOyfKIHMOfb, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.HTWzvzlsjNtQWdhSmZaoLzOHHdoO, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.GMVrvTevwsfDcjKmCxQocZhBIDmt, hywDDOGBuCFLDuASmWChqMOUGKds2.TBrSzrFZqTsarglPXfpBCFVVFBmqA);
				hywDDOGBuCFLDuASmWChqMOUGKds2.aBHUKrVkBjmUjzkSwRnoEjmdIWRD = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				XWNabrFQBvFAMQRTRKotbzCJfrYdA xWNabrFQBvFAMQRTRKotbzCJfrYdA = new XWNabrFQBvFAMQRTRKotbzCJfrYdA();
				xWNabrFQBvFAMQRTRKotbzCJfrYdA.ZNAAQJAdmueGbdIuiHcrJtVyoeHKc = hywDDOGBuCFLDuASmWChqMOUGKds2;
				xWNabrFQBvFAMQRTRKotbzCJfrYdA.IKbCehLxfKHZJNHoyKVUqidtIFKX = new List<int>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Map Category", P_0.mapCategories, P_1?.mapCategories, xWNabrFQBvFAMQRTRKotbzCJfrYdA.ZNAAQJAdmueGbdIuiHcrJtVyoeHKc.JriDYpZqsZXijWMTrEIxxKQrZESd.mapCategories, P_2, xWNabrFQBvFAMQRTRKotbzCJfrYdA.ZNAAQJAdmueGbdIuiHcrJtVyoeHKc.aBHUKrVkBjmUjzkSwRnoEjmdIWRD, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.xWtgxRKiiwWqbPFIyBSPGuQLhLWn, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.vrMzXwzJPzvJPwmlJpErVEDmDMEkA, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.ucCecgZOTAsudffIvLBoXmiHGqLq, xWNabrFQBvFAMQRTRKotbzCJfrYdA.dEgWsxYnTTbZtjKhHuEyirUFBoNF);
				for (int i = 0; i < xWNabrFQBvFAMQRTRKotbzCJfrYdA.IKbCehLxfKHZJNHoyKVUqidtIFKX.Count; i++)
				{
					int index = xWNabrFQBvFAMQRTRKotbzCJfrYdA.IKbCehLxfKHZJNHoyKVUqidtIFKX[i];
					InputMapCategory inputMapCategory = xWNabrFQBvFAMQRTRKotbzCJfrYdA.ZNAAQJAdmueGbdIuiHcrJtVyoeHKc.JriDYpZqsZXijWMTrEIxxKQrZESd.mapCategories[index];
					for (int j = 0; j < inputMapCategory.EoujvItaTKDTFCLPObvMEsufOqUWA.Count; j++)
					{
						irnCenFDLezutojwfHiPEbCDxcBvB irnCenFDLezutojwfHiPEbCDxcBvB2 = new irnCenFDLezutojwfHiPEbCDxcBvB();
						irnCenFDLezutojwfHiPEbCDxcBvB2.UOlUeQgFaJaKGzoLPAuEECtBACDbb = inputMapCategory.EoujvItaTKDTFCLPObvMEsufOqUWA[j];
						eFJIulbtZIHHuzVNqxYhzJhpFoLN eFJIulbtZIHHuzVNqxYhzJhpFoLN2 = xWNabrFQBvFAMQRTRKotbzCJfrYdA.ZNAAQJAdmueGbdIuiHcrJtVyoeHKc.aBHUKrVkBjmUjzkSwRnoEjmdIWRD.Find(irnCenFDLezutojwfHiPEbCDxcBvB2.lDmaEYjPHlpqXJxuyQOwKnemQcOQ);
						inputMapCategory.EoujvItaTKDTFCLPObvMEsufOqUWA[j] = eFJIulbtZIHHuzVNqxYhzJhpFoLN2?.gkdQJIzCzIDwTytONjxEAbiVzNwh ?? (-1);
					}
				}
				hywDDOGBuCFLDuASmWChqMOUGKds2.GIJMrrveDXEgLMdhdFjIeOwPNGCE = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.keyboardLayouts, P_2, hywDDOGBuCFLDuASmWChqMOUGKds2.GIJMrrveDXEgLMdhdFjIeOwPNGCE, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.GSbIFefSdOUeDLlWUrYcKPhZcAeF, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.AKxfDNbOsDeIuHxzsnvbXHlVtVGC, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.PVlgMAfspJteyBvFHhlGPmfqCxqj, hywDDOGBuCFLDuASmWChqMOUGKds2.sllcTlZlvvcZSfZRsjGZwEfdjrlD);
				hywDDOGBuCFLDuASmWChqMOUGKds2.nrVdTPadkZxyMWurltaBqWfjqdwG = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.mouseLayouts, P_2, hywDDOGBuCFLDuASmWChqMOUGKds2.nrVdTPadkZxyMWurltaBqWfjqdwG, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.yrQJSmqZnWWFBZABYdWjHHhnQQYTA, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.eSrbjxqHIfejTyZntFZtgJmbQeyx, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.KiUvzLDitIhzgqnEXfCeDDCrmKDF, hywDDOGBuCFLDuASmWChqMOUGKds2.SjGCRAAjvwFlKVSPZQelUrRrcbwEb);
				hywDDOGBuCFLDuASmWChqMOUGKds2.xPxCWyQMWpbajPtCYglpKLiNoYrKA = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.joystickLayouts, P_2, hywDDOGBuCFLDuASmWChqMOUGKds2.xPxCWyQMWpbajPtCYglpKLiNoYrKA, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.rKYkaUONeuFotBywnAXQItwChTwTA, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.vKaTAkInCHobpDKrctiDbEwzSifh, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.OSFBwfYDukJzphwKdoGLmVRiHUUf, hywDDOGBuCFLDuASmWChqMOUGKds2.EisGFduInEjiDajAZyrIaCJahUPvA);
				hywDDOGBuCFLDuASmWChqMOUGKds2.HALFdydJABmIuosZaGsYcxxOJDhCA = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.customControllerLayouts, P_2, hywDDOGBuCFLDuASmWChqMOUGKds2.HALFdydJABmIuosZaGsYcxxOJDhCA, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.JJbLDTMLUQbWViLIcehDkjFAbiMZA, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.nigVYnZiiRRxPMeVrEFfnqXeOaW, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.xQPIJCNHOEJiDnKxhXyDQIchsJof, hywDDOGBuCFLDuASmWChqMOUGKds2.sFjAgvWdxzQhZYtttrCRUYpiTnrw);
				hywDDOGBuCFLDuASmWChqMOUGKds2.YzJjCioiCXAzlyOUBsaSmmrvIgLf = hywDDOGBuCFLDuASmWChqMOUGKds2.gDufdgiangPitIGdIZBiaFTCnpEvB;
				hywDDOGBuCFLDuASmWChqMOUGKds2.FKzDjdoLQXGfSaKoIECNsuRCNqbXA = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Custom Controller", P_0.customControllers, P_1?.customControllers, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.customControllers, P_2, hywDDOGBuCFLDuASmWChqMOUGKds2.FKzDjdoLQXGfSaKoIECNsuRCNqbXA, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.tNeddguHRMcdNYPbTAbPbouuNcveA, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.iSsBiAgbWjjoZwmpSQLoUeiHoZES, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.rCYHpXLpFqXUpZGkIgTFaIDHwrMl, hywDDOGBuCFLDuASmWChqMOUGKds2.wGXztYPlksBWhLrQhdJZhnYPAMMcA);
				hywDDOGBuCFLDuASmWChqMOUGKds2.zyicfphbNWNhnLtYBGjVzpGILGHcA = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.controllerMapLayoutManagerRuleSets, P_2, hywDDOGBuCFLDuASmWChqMOUGKds2.zyicfphbNWNhnLtYBGjVzpGILGHcA, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.MhxAVWhbSrJMnHriGQzKkAhhFddyC, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.utrapkllCZYkCQiYgUnZDwvuWDtc, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.OwBIBmbEEqRUWJPjBzJTnKSVgLxA, hywDDOGBuCFLDuASmWChqMOUGKds2.uMfzjrDqgfmmupGfpSpSnWVCHPqF);
				hywDDOGBuCFLDuASmWChqMOUGKds2.PxktMrpSaScLFLLEURexGEaKbiR = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.controllerMapEnablerRuleSets, P_2, hywDDOGBuCFLDuASmWChqMOUGKds2.PxktMrpSaScLFLLEURexGEaKbiR, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.PluPFGFOCqXmBUbURAoRFtcAVHeM, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.fGEmCNCHNNxJHAJRoaciDhaeWAyP, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.oRtJkluWeyglMVlnbWCpPVrZyFzC, hywDDOGBuCFLDuASmWChqMOUGKds2.UZayCHPenlcXiVkqkhafIHyjcMJL);
				List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> list = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Player", P_0.players, P_1?.players, hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd.players, P_2, list, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.ubYAFoGHTCmTwSeflqrRgmeVSgKdA, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.UANkOZKlvvJSQjrkzSGCoWHOMMmX, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.BLsBpffRYpVXwPfdvmowDTegTAeW, hywDDOGBuCFLDuASmWChqMOUGKds2.nlpjVbmZfvinrkUFnQncqAHHSApR);
				List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> list2 = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				DSyatsHDDXKKGsMWtqSQeONggkGDB dSyatsHDDXKKGsMWtqSQeONggkGDB = new DSyatsHDDXKKGsMWtqSQeONggkGDB();
				dSyatsHDDXKKGsMWtqSQeONggkGDB.XmiFtdLASibsaEXjgYyAMmhqOTzsA = hywDDOGBuCFLDuASmWChqMOUGKds2;
				dSyatsHDDXKKGsMWtqSQeONggkGDB.KpSicIyMBMNEAQEZspEtqWnMRTGj = dSyatsHDDXKKGsMWtqSQeONggkGDB.XmiFtdLASibsaEXjgYyAMmhqOTzsA.GIJMrrveDXEgLMdhdFjIeOwPNGCE;
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, dSyatsHDDXKKGsMWtqSQeONggkGDB.XmiFtdLASibsaEXjgYyAMmhqOTzsA.JriDYpZqsZXijWMTrEIxxKQrZESd.keyboardMaps, P_2, list2, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.QwAmTeTRJWMQbYZhWHmZmhuBSKHC, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.cRZCyFustSnqZbSoVGWjdUEApnFf, dSyatsHDDXKKGsMWtqSQeONggkGDB.cBUdPFMHAuPwqdhkgkGEustwNJFj, dSyatsHDDXKKGsMWtqSQeONggkGDB.wlgGTgndiUiRGXeDtbYJndKrPpsQ);
				List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> list3 = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				cBFVVafBHehFzEiLIsOmRdUxOmTFb cBFVVafBHehFzEiLIsOmRdUxOmTFb2 = new cBFVVafBHehFzEiLIsOmRdUxOmTFb();
				cBFVVafBHehFzEiLIsOmRdUxOmTFb2.RSYrQeYYIBfyFYGDGtVjUBJeFSSt = hywDDOGBuCFLDuASmWChqMOUGKds2;
				cBFVVafBHehFzEiLIsOmRdUxOmTFb2.SlZlwEFKtUllopziQdatGPADlnMj = cBFVVafBHehFzEiLIsOmRdUxOmTFb2.RSYrQeYYIBfyFYGDGtVjUBJeFSSt.nrVdTPadkZxyMWurltaBqWfjqdwG;
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, cBFVVafBHehFzEiLIsOmRdUxOmTFb2.RSYrQeYYIBfyFYGDGtVjUBJeFSSt.JriDYpZqsZXijWMTrEIxxKQrZESd.mouseMaps, P_2, list3, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.iyhuFOAuVLPrOmURZgFlPlJzjQBe, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.BnVfGvxNbzabGjuWcXsGSPInPVMBA, cBFVVafBHehFzEiLIsOmRdUxOmTFb2.aXjNGiZwtyEJGDAhZHYcWKeGNKhA, cBFVVafBHehFzEiLIsOmRdUxOmTFb2.vxxUCxMHWDAWrhWpxhBfCjboSBYY);
				List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> list4 = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				BIgAcLUNECeGnhywwFxnHqxVqmOHb bIgAcLUNECeGnhywwFxnHqxVqmOHb = new BIgAcLUNECeGnhywwFxnHqxVqmOHb();
				bIgAcLUNECeGnhywwFxnHqxVqmOHb.degnEjdyLvwcQCKggkIJcihEMKYH = hywDDOGBuCFLDuASmWChqMOUGKds2;
				bIgAcLUNECeGnhywwFxnHqxVqmOHb.iFGiwmFOXgqHAycRhOnbaAkAEuYwA = bIgAcLUNECeGnhywwFxnHqxVqmOHb.degnEjdyLvwcQCKggkIJcihEMKYH.xPxCWyQMWpbajPtCYglpKLiNoYrKA;
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, bIgAcLUNECeGnhywwFxnHqxVqmOHb.degnEjdyLvwcQCKggkIJcihEMKYH.JriDYpZqsZXijWMTrEIxxKQrZESd.joystickMaps, P_2, list4, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.qwhppxCLNGNMbrMmtyzYLZucDoBC, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.dHurcbmuFnheQhWXTwROCkIVRyAb, bIgAcLUNECeGnhywwFxnHqxVqmOHb.RrXeQuclnbSfdeOUJlbqvlCCACYL, bIgAcLUNECeGnhywwFxnHqxVqmOHb.hijmRiUiVEvZKBCOcgxpbNLPHztj);
				List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> list5 = new List<eFJIulbtZIHHuzVNqxYhzJhpFoLN>();
				EQKhQmJkMndYmVnEfYWhuovxmJwL eQKhQmJkMndYmVnEfYWhuovxmJwL = new EQKhQmJkMndYmVnEfYWhuovxmJwL();
				eQKhQmJkMndYmVnEfYWhuovxmJwL.qJHbfYgNbfFpSHJDqDjLaFBIRfdz = hywDDOGBuCFLDuASmWChqMOUGKds2;
				eQKhQmJkMndYmVnEfYWhuovxmJwL.KjRmXpYJzILfTxHiIEARsREvqpBk = eQKhQmJkMndYmVnEfYWhuovxmJwL.qJHbfYgNbfFpSHJDqDjLaFBIRfdz.HALFdydJABmIuosZaGsYcxxOJDhCA;
				iuLEUxaaQumlkEGHddzcTtgdXwboB("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, eQKhQmJkMndYmVnEfYWhuovxmJwL.qJHbfYgNbfFpSHJDqDjLaFBIRfdz.JriDYpZqsZXijWMTrEIxxKQrZESd.customControllerMaps, P_2, list5, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.LnfQULASyfpyYIoXPPAxiOAdAdLp, uIqTtGxRnWyMNQaGulinXGUUXAaj._003C_003E9.xAPHNbjQDTOlEaYyosrtnMsFtxdM, eQKhQmJkMndYmVnEfYWhuovxmJwL.joGFmCDnORdczdtdALJlnnvTUwaJA, eQKhQmJkMndYmVnEfYWhuovxmJwL.NWiEScKRKUfmmfTflwsuBWKwmsNk);
				return hywDDOGBuCFLDuASmWChqMOUGKds2.JriDYpZqsZXijWMTrEIxxKQrZESd;
			}

			[Conditional("DEBUG_IMPORT")]
			private static void WUOeWssJywvcWnIVLIJvnoAuizBiA(object P_0)
			{
				Logger.Log("[DEBUG_IMPORT] " + P_0);
			}

			private static void sKSTYAeyawARtFjmbMnVqigNxAtX<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
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

			private static void iuLEUxaaQumlkEGHddzcTtgdXwboB<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<eFJIulbtZIHHuzVNqxYhzJhpFoLN> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<cYIhjwRJAbarRxYntUPKJXypBljV<_0001>, _0001> P_9) where _0001 : class
			{
				ItZNgWDQsZmMwpeaSnahWpCspFCl<_0001> itZNgWDQsZmMwpeaSnahWpCspFCl = new ItZNgWDQsZmMwpeaSnahWpCspFCl<_0001>();
				itZNgWDQsZmMwpeaSnahWpCspFCl.KRpArXaOMmwgQtmmGQhOkNfinyUeA = P_6;
				for (int i = 0; i < P_1.Count; i++)
				{
					_0001 val = P_1[i];
					if (P_4)
					{
						P_5.Add(new eFJIulbtZIHHuzVNqxYhzJhpFoLN(itZNgWDQsZmMwpeaSnahWpCspFCl.KRpArXaOMmwgQtmmGQhOkNfinyUeA(val), -1, itZNgWDQsZmMwpeaSnahWpCspFCl.KRpArXaOMmwgQtmmGQhOkNfinyUeA(val)));
						continue;
					}
					_0001 arg = P_9(new cYIhjwRJAbarRxYntUPKJXypBljV<_0001>(val, null, eFJIulbtZIHHuzVNqxYhzJhpFoLN.IkeBrYocAnODfKzBeBrJCTHKqQbk.origId, P_3, false));
					P_5.Add(new eFJIulbtZIHHuzVNqxYhzJhpFoLN(itZNgWDQsZmMwpeaSnahWpCspFCl.KRpArXaOMmwgQtmmGQhOkNfinyUeA(val), -1, itZNgWDQsZmMwpeaSnahWpCspFCl.KRpArXaOMmwgQtmmGQhOkNfinyUeA(arg)));
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
						erjrURtHmNkbzQUGtQaXRTYzHNAJ<_0001> erjrURtHmNkbzQUGtQaXRTYzHNAJ2 = new erjrURtHmNkbzQUGtQaXRTYzHNAJ<_0001>();
						erjrURtHmNkbzQUGtQaXRTYzHNAJ2.TbVMdpUQaHanSJFQVrDLpRIeQDzJ = itZNgWDQsZmMwpeaSnahWpCspFCl;
						_0001 val3 = P_3[num];
						erjrURtHmNkbzQUGtQaXRTYzHNAJ2.gFfhOtBVQqZcSHZVNLvwMTHbfdnK = P_9(new cYIhjwRJAbarRxYntUPKJXypBljV<_0001>(val2, val3, eFJIulbtZIHHuzVNqxYhzJhpFoLN.IkeBrYocAnODfKzBeBrJCTHKqQbk.otherId, P_3, true));
						P_5.Find(erjrURtHmNkbzQUGtQaXRTYzHNAJ2.PeKNorZDUcbXWuEPipiwoaiIqeaK).lVZZmSZiaLXScpukgqOuPZDQmmAq = erjrURtHmNkbzQUGtQaXRTYzHNAJ2.TbVMdpUQaHanSJFQVrDLpRIeQDzJ.KRpArXaOMmwgQtmmGQhOkNfinyUeA(val2);
						string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
					}
					else
					{
						_0001 arg2 = P_9(new cYIhjwRJAbarRxYntUPKJXypBljV<_0001>(val2, null, eFJIulbtZIHHuzVNqxYhzJhpFoLN.IkeBrYocAnODfKzBeBrJCTHKqQbk.otherId, P_3, false));
						P_5.Add(new eFJIulbtZIHHuzVNqxYhzJhpFoLN(-1, itZNgWDQsZmMwpeaSnahWpCspFCl.KRpArXaOMmwgQtmmGQhOkNfinyUeA(val2), itZNgWDQsZmMwpeaSnahWpCspFCl.KRpArXaOMmwgQtmmGQhOkNfinyUeA(arg2)));
						string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
						Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
					}
				}
			}
		}

		[Serializable]
		private sealed class NvjHouyFkXhoVwtyYCVAdiHxfUEA
		{
			public static readonly NvjHouyFkXhoVwtyYCVAdiHxfUEA _003C_003E9 = new NvjHouyFkXhoVwtyYCVAdiHxfUEA();

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__199_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__217_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__233_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__249_0;

			public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__265_0;

			internal void DMZkQfJRKVAxNOqLPBdFCJdEvvtn(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void dAwpDaSETBfLBeHJymFXBNxtYNffA(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void tKnxVGDCJCGcTOseiRvvcraKEcYH(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void KdHnDtQCsBIurBmxDtEpMOktBfFGA(List<Player_Editor.Mapping> P_0, int P_1)
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

			internal void eeHzRLINeHSWMtZalAOtEhZcFfix(List<Player_Editor.Mapping> P_0, int P_1)
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

		private sealed class utsKclqzMUiLLteMOFvlrYHbtvtI
		{
			public List<InputLayout> xXdmTDOpxFsJOXxZeTxfbvhGxzIC;

			internal int NhTtbkhoVTguWVGKqsDIqcDUFdSv(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
			{
				yDCOCOLIoNMkefjVjgrZYuVaMWmQ yDCOCOLIoNMkefjVjgrZYuVaMWmQ2 = new yDCOCOLIoNMkefjVjgrZYuVaMWmQ();
				yDCOCOLIoNMkefjVjgrZYuVaMWmQ2.lDgjpXafBmRRrGJSTaxnLpmnkAoO = P_0;
				yDCOCOLIoNMkefjVjgrZYuVaMWmQ2.nQpMeBqftHPqPigTxgmsciqMAkfo = P_1;
				int num = xXdmTDOpxFsJOXxZeTxfbvhGxzIC.FindIndex(yDCOCOLIoNMkefjVjgrZYuVaMWmQ2.FaReimhoFeQHsVfsoBDOiAfbTUPHc);
				int num2 = xXdmTDOpxFsJOXxZeTxfbvhGxzIC.FindIndex(yDCOCOLIoNMkefjVjgrZYuVaMWmQ2.HahqySZxzQitUEPkivoyoapWCffW);
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

		private sealed class yDCOCOLIoNMkefjVjgrZYuVaMWmQ
		{
			public ControllerMap_Editor lDgjpXafBmRRrGJSTaxnLpmnkAoO;

			public ControllerMap_Editor nQpMeBqftHPqPigTxgmsciqMAkfo;

			internal bool FaReimhoFeQHsVfsoBDOiAfbTUPHc(InputLayout P_0)
			{
				return P_0.id == lDgjpXafBmRRrGJSTaxnLpmnkAoO.id;
			}

			internal bool HahqySZxzQitUEPkivoyoapWCffW(InputLayout P_0)
			{
				return P_0.id == nQpMeBqftHPqPigTxgmsciqMAkfo.id;
			}
		}

		private sealed class ccxikuJtxBjGQUmAoJxtiwRIGVejA : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int EvUthysadqsyeviuDrbMDLSggWTdA;

			private InputCategory KaXPHplmhdeIRhuAJJxWhCzGTFPhA;

			private int BZSSTJlLhelQsUdogexmCjMvBABjb;

			private string DtSGBgSVgWikfBnLpAcjjHeMFkqAb;

			public string SkmueWwCcobqNCWUzECnMeFptzvk;

			public UserData LzNKUbHYFJeaSVqijEHYHUCwVcVdA;

			private int hCjEZKBwHaroZRfWHFGxdXFEcEElB;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return KaXPHplmhdeIRhuAJJxWhCzGTFPhA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return KaXPHplmhdeIRhuAJJxWhCzGTFPhA;
				}
			}

			[DebuggerHidden]
			public ccxikuJtxBjGQUmAoJxtiwRIGVejA(int P_0)
			{
				EvUthysadqsyeviuDrbMDLSggWTdA = P_0;
				BZSSTJlLhelQsUdogexmCjMvBABjb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int evUthysadqsyeviuDrbMDLSggWTdA = EvUthysadqsyeviuDrbMDLSggWTdA;
				UserData lzNKUbHYFJeaSVqijEHYHUCwVcVdA = LzNKUbHYFJeaSVqijEHYHUCwVcVdA;
				if (evUthysadqsyeviuDrbMDLSggWTdA != 0)
				{
					if (evUthysadqsyeviuDrbMDLSggWTdA != 1)
					{
						return false;
					}
					EvUthysadqsyeviuDrbMDLSggWTdA = -1;
					goto IL_0098;
				}
				EvUthysadqsyeviuDrbMDLSggWTdA = -1;
				if (DtSGBgSVgWikfBnLpAcjjHeMFkqAb == null || DtSGBgSVgWikfBnLpAcjjHeMFkqAb == string.Empty)
				{
					return false;
				}
				if (lzNKUbHYFJeaSVqijEHYHUCwVcVdA.actionCategories == null)
				{
					return false;
				}
				hCjEZKBwHaroZRfWHFGxdXFEcEElB = 0;
				goto IL_00a8;
				IL_00a8:
				if (hCjEZKBwHaroZRfWHFGxdXFEcEElB < lzNKUbHYFJeaSVqijEHYHUCwVcVdA.actionCategories.Count)
				{
					if (lzNKUbHYFJeaSVqijEHYHUCwVcVdA.actionCategories[hCjEZKBwHaroZRfWHFGxdXFEcEElB].tag.Equals(DtSGBgSVgWikfBnLpAcjjHeMFkqAb, StringComparison.OrdinalIgnoreCase))
					{
						KaXPHplmhdeIRhuAJJxWhCzGTFPhA = lzNKUbHYFJeaSVqijEHYHUCwVcVdA.actionCategories[hCjEZKBwHaroZRfWHFGxdXFEcEElB];
						EvUthysadqsyeviuDrbMDLSggWTdA = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				hCjEZKBwHaroZRfWHFGxdXFEcEElB++;
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
				ccxikuJtxBjGQUmAoJxtiwRIGVejA ccxikuJtxBjGQUmAoJxtiwRIGVejA2;
				if (EvUthysadqsyeviuDrbMDLSggWTdA == -2 && BZSSTJlLhelQsUdogexmCjMvBABjb == Environment.CurrentManagedThreadId)
				{
					EvUthysadqsyeviuDrbMDLSggWTdA = 0;
					ccxikuJtxBjGQUmAoJxtiwRIGVejA2 = this;
				}
				else
				{
					ccxikuJtxBjGQUmAoJxtiwRIGVejA2 = new ccxikuJtxBjGQUmAoJxtiwRIGVejA(0);
					ccxikuJtxBjGQUmAoJxtiwRIGVejA2.LzNKUbHYFJeaSVqijEHYHUCwVcVdA = LzNKUbHYFJeaSVqijEHYHUCwVcVdA;
				}
				ccxikuJtxBjGQUmAoJxtiwRIGVejA2.DtSGBgSVgWikfBnLpAcjjHeMFkqAb = SkmueWwCcobqNCWUzECnMeFptzvk;
				return ccxikuJtxBjGQUmAoJxtiwRIGVejA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class TIBADBQcHIsLjfoUKSBogRrfNjjd : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int zauVCcdBsHpwEGkDXdTKDgBPGtaS;

			private InputAction HffOpoKkRVALLJnFrcaOYKdFVaDHA;

			private int AWENNSwaystROrgHFieTOFfNUKqj;

			public UserData dwfulrnFiZsOhsjMeYyBooIIGHEg;

			private string yEeDOHFzCgjdGmNRtzBfKiKbhynpA;

			public string cMESNqqlIFhsxgxfAJGjxchCgSeCb;

			private int iuncikZaPmihYDckxFjReeyJgJcnb;

			private int mJbtJqGtugxDoosMAanpSwNmiQUd;

			private InputCategory CCNKmNQMZKninEzGxmQIiVPNfXPn;

			private int pciZNmsVutLCuRUXSPILYfpvLdMi;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return HffOpoKkRVALLJnFrcaOYKdFVaDHA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return HffOpoKkRVALLJnFrcaOYKdFVaDHA;
				}
			}

			[DebuggerHidden]
			public TIBADBQcHIsLjfoUKSBogRrfNjjd(int P_0)
			{
				zauVCcdBsHpwEGkDXdTKDgBPGtaS = P_0;
				AWENNSwaystROrgHFieTOFfNUKqj = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = zauVCcdBsHpwEGkDXdTKDgBPGtaS;
				UserData userData = dwfulrnFiZsOhsjMeYyBooIIGHEg;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					zauVCcdBsHpwEGkDXdTKDgBPGtaS = -1;
					goto IL_00fd;
				}
				zauVCcdBsHpwEGkDXdTKDgBPGtaS = -1;
				if (userData.cnjJGampiqifPHPSycEOPktSoDLW == null || userData.actionCategories == null)
				{
					return false;
				}
				if (yEeDOHFzCgjdGmNRtzBfKiKbhynpA == null || yEeDOHFzCgjdGmNRtzBfKiKbhynpA == string.Empty)
				{
					return false;
				}
				iuncikZaPmihYDckxFjReeyJgJcnb = userData.cnjJGampiqifPHPSycEOPktSoDLW.Count;
				mJbtJqGtugxDoosMAanpSwNmiQUd = 0;
				goto IL_0132;
				IL_0122:
				mJbtJqGtugxDoosMAanpSwNmiQUd++;
				goto IL_0132;
				IL_00fd:
				pciZNmsVutLCuRUXSPILYfpvLdMi++;
				goto IL_010d;
				IL_010d:
				if (pciZNmsVutLCuRUXSPILYfpvLdMi < iuncikZaPmihYDckxFjReeyJgJcnb)
				{
					if (CCNKmNQMZKninEzGxmQIiVPNfXPn.id == userData.cnjJGampiqifPHPSycEOPktSoDLW[pciZNmsVutLCuRUXSPILYfpvLdMi].categoryId)
					{
						HffOpoKkRVALLJnFrcaOYKdFVaDHA = userData.cnjJGampiqifPHPSycEOPktSoDLW[pciZNmsVutLCuRUXSPILYfpvLdMi];
						zauVCcdBsHpwEGkDXdTKDgBPGtaS = 1;
						return true;
					}
					goto IL_00fd;
				}
				CCNKmNQMZKninEzGxmQIiVPNfXPn = null;
				goto IL_0122;
				IL_0132:
				if (mJbtJqGtugxDoosMAanpSwNmiQUd < userData.actionCategories.Count)
				{
					if (userData.actionCategories[mJbtJqGtugxDoosMAanpSwNmiQUd].tag.Equals(yEeDOHFzCgjdGmNRtzBfKiKbhynpA, StringComparison.OrdinalIgnoreCase))
					{
						CCNKmNQMZKninEzGxmQIiVPNfXPn = userData.actionCategories[mJbtJqGtugxDoosMAanpSwNmiQUd];
						pciZNmsVutLCuRUXSPILYfpvLdMi = 0;
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
				TIBADBQcHIsLjfoUKSBogRrfNjjd tIBADBQcHIsLjfoUKSBogRrfNjjd;
				if (zauVCcdBsHpwEGkDXdTKDgBPGtaS == -2 && AWENNSwaystROrgHFieTOFfNUKqj == Environment.CurrentManagedThreadId)
				{
					zauVCcdBsHpwEGkDXdTKDgBPGtaS = 0;
					tIBADBQcHIsLjfoUKSBogRrfNjjd = this;
				}
				else
				{
					tIBADBQcHIsLjfoUKSBogRrfNjjd = new TIBADBQcHIsLjfoUKSBogRrfNjjd(0);
					tIBADBQcHIsLjfoUKSBogRrfNjjd.dwfulrnFiZsOhsjMeYyBooIIGHEg = dwfulrnFiZsOhsjMeYyBooIIGHEg;
				}
				tIBADBQcHIsLjfoUKSBogRrfNjjd.yEeDOHFzCgjdGmNRtzBfKiKbhynpA = cMESNqqlIFhsxgxfAJGjxchCgSeCb;
				return tIBADBQcHIsLjfoUKSBogRrfNjjd;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class nbkTGUcxTWMpNnDqSBpxhdWWdvovA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int JuuymKOHPkhMNYKaZjqWqVZDLuip;

			private InputAction URyCgCjrxSIYVBNpOnbcrAAflNsQ;

			private int voaiyUlfXdlHdyxquZmgQTXKxLAh;

			public UserData JONsKYahGEBeLBMojEoGyQMiIZJe;

			private bool gwhaeuBmLUIRgZmyEqFFjPOIBRnWA;

			public bool EFotEXBdZdxezloLxxIIniAuGxyn;

			private int wqdSuDzQIOEKzmuaVKReOYhuLJoh;

			public int isLinvpgjwMQUAREBTliaUYZOLdJ;

			private IEnumerator<int> ShYTbwfsPQhHYXuUpUKfoXkSeLgC;

			private int vSUHWCeCzBAgtIHSBeVDwBAVJQZpA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return URyCgCjrxSIYVBNpOnbcrAAflNsQ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return URyCgCjrxSIYVBNpOnbcrAAflNsQ;
				}
			}

			[DebuggerHidden]
			public nbkTGUcxTWMpNnDqSBpxhdWWdvovA(int P_0)
			{
				JuuymKOHPkhMNYKaZjqWqVZDLuip = P_0;
				voaiyUlfXdlHdyxquZmgQTXKxLAh = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int juuymKOHPkhMNYKaZjqWqVZDLuip = JuuymKOHPkhMNYKaZjqWqVZDLuip;
				if (juuymKOHPkhMNYKaZjqWqVZDLuip == -3 || juuymKOHPkhMNYKaZjqWqVZDLuip == 1)
				{
					try
					{
					}
					finally
					{
						AhhcVPiqmPzzDJMsZqmuGwXdyPJgB();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int juuymKOHPkhMNYKaZjqWqVZDLuip = JuuymKOHPkhMNYKaZjqWqVZDLuip;
					UserData jONsKYahGEBeLBMojEoGyQMiIZJe = JONsKYahGEBeLBMojEoGyQMiIZJe;
					switch (juuymKOHPkhMNYKaZjqWqVZDLuip)
					{
					default:
						return false;
					case 0:
						JuuymKOHPkhMNYKaZjqWqVZDLuip = -1;
						if (jONsKYahGEBeLBMojEoGyQMiIZJe.cnjJGampiqifPHPSycEOPktSoDLW == null || jONsKYahGEBeLBMojEoGyQMiIZJe.actionCategories == null)
						{
							return false;
						}
						if (gwhaeuBmLUIRgZmyEqFFjPOIBRnWA)
						{
							ShYTbwfsPQhHYXuUpUKfoXkSeLgC = jONsKYahGEBeLBMojEoGyQMiIZJe.SortedActionIdsInCategory(wqdSuDzQIOEKzmuaVKReOYhuLJoh).GetEnumerator();
							JuuymKOHPkhMNYKaZjqWqVZDLuip = -3;
							goto IL_00a5;
						}
						vSUHWCeCzBAgtIHSBeVDwBAVJQZpA = 0;
						goto IL_0123;
					case 1:
						JuuymKOHPkhMNYKaZjqWqVZDLuip = -3;
						goto IL_00a5;
					case 2:
						{
							JuuymKOHPkhMNYKaZjqWqVZDLuip = -1;
							goto IL_0111;
						}
						IL_0123:
						if (vSUHWCeCzBAgtIHSBeVDwBAVJQZpA >= jONsKYahGEBeLBMojEoGyQMiIZJe.cnjJGampiqifPHPSycEOPktSoDLW.Count)
						{
							break;
						}
						if (jONsKYahGEBeLBMojEoGyQMiIZJe.cnjJGampiqifPHPSycEOPktSoDLW[vSUHWCeCzBAgtIHSBeVDwBAVJQZpA].categoryId == wqdSuDzQIOEKzmuaVKReOYhuLJoh)
						{
							URyCgCjrxSIYVBNpOnbcrAAflNsQ = jONsKYahGEBeLBMojEoGyQMiIZJe.cnjJGampiqifPHPSycEOPktSoDLW[vSUHWCeCzBAgtIHSBeVDwBAVJQZpA];
							JuuymKOHPkhMNYKaZjqWqVZDLuip = 2;
							return true;
						}
						goto IL_0111;
						IL_0111:
						vSUHWCeCzBAgtIHSBeVDwBAVJQZpA++;
						goto IL_0123;
						IL_00a5:
						while (ShYTbwfsPQhHYXuUpUKfoXkSeLgC.MoveNext())
						{
							int current = ShYTbwfsPQhHYXuUpUKfoXkSeLgC.Current;
							InputAction actionById = jONsKYahGEBeLBMojEoGyQMiIZJe.GetActionById(current);
							if (actionById != null)
							{
								URyCgCjrxSIYVBNpOnbcrAAflNsQ = actionById;
								JuuymKOHPkhMNYKaZjqWqVZDLuip = 1;
								return true;
							}
						}
						AhhcVPiqmPzzDJMsZqmuGwXdyPJgB();
						ShYTbwfsPQhHYXuUpUKfoXkSeLgC = null;
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

			private void AhhcVPiqmPzzDJMsZqmuGwXdyPJgB()
			{
				JuuymKOHPkhMNYKaZjqWqVZDLuip = -1;
				if (ShYTbwfsPQhHYXuUpUKfoXkSeLgC != null)
				{
					ShYTbwfsPQhHYXuUpUKfoXkSeLgC.Dispose();
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
				nbkTGUcxTWMpNnDqSBpxhdWWdvovA nbkTGUcxTWMpNnDqSBpxhdWWdvovA2;
				if (JuuymKOHPkhMNYKaZjqWqVZDLuip == -2 && voaiyUlfXdlHdyxquZmgQTXKxLAh == Environment.CurrentManagedThreadId)
				{
					JuuymKOHPkhMNYKaZjqWqVZDLuip = 0;
					nbkTGUcxTWMpNnDqSBpxhdWWdvovA2 = this;
				}
				else
				{
					nbkTGUcxTWMpNnDqSBpxhdWWdvovA2 = new nbkTGUcxTWMpNnDqSBpxhdWWdvovA(0);
					nbkTGUcxTWMpNnDqSBpxhdWWdvovA2.JONsKYahGEBeLBMojEoGyQMiIZJe = JONsKYahGEBeLBMojEoGyQMiIZJe;
				}
				nbkTGUcxTWMpNnDqSBpxhdWWdvovA2.wqdSuDzQIOEKzmuaVKReOYhuLJoh = isLinvpgjwMQUAREBTliaUYZOLdJ;
				nbkTGUcxTWMpNnDqSBpxhdWWdvovA2.gwhaeuBmLUIRgZmyEqFFjPOIBRnWA = EFotEXBdZdxezloLxxIIniAuGxyn;
				return nbkTGUcxTWMpNnDqSBpxhdWWdvovA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class WiEUdZxsTCVQlLgmPrWOdzeoUpgG : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA;

			private InputAction SVzLbKHgBLKIndOHKIRvMzvOjguc;

			private int JsekEFpvRTOrLNUuifNotWjvIHVG;

			public UserData KYwlhzObMIIPmSLUKfBAlGTEBADkA;

			private string ZjuUIwdBqWkCuDnfsKWeIxElFxYb;

			public string jBmhueEvZFRxmOPiNiPLXtrKQIuoA;

			private bool mRuUtxTsRiRqCtRwpjiodWEtnOSq;

			public bool HglHArewLziRExGRFADWSPcsrvyu;

			private InputCategory RgMJbIEusNIvRPdnthdqdySnDJhF;

			private IEnumerator<int> sKXcMWhLdEOrWRtuOBZAfUaRfRgU;

			private int jhjSmmDEosKRNPFADgCEGYyQyKkiA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return SVzLbKHgBLKIndOHKIRvMzvOjguc;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return SVzLbKHgBLKIndOHKIRvMzvOjguc;
				}
			}

			[DebuggerHidden]
			public WiEUdZxsTCVQlLgmPrWOdzeoUpgG(int P_0)
			{
				ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA = P_0;
				JsekEFpvRTOrLNUuifNotWjvIHVG = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int zmdbJGXdjoiNKSJWVGqkKNTdyTsJA = ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA;
				if (zmdbJGXdjoiNKSJWVGqkKNTdyTsJA == -3 || zmdbJGXdjoiNKSJWVGqkKNTdyTsJA == 1)
				{
					try
					{
					}
					finally
					{
						gGQmllVpGxAZpGghxkNIiureIZMkA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int zmdbJGXdjoiNKSJWVGqkKNTdyTsJA = ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA;
					UserData kYwlhzObMIIPmSLUKfBAlGTEBADkA = KYwlhzObMIIPmSLUKfBAlGTEBADkA;
					switch (zmdbJGXdjoiNKSJWVGqkKNTdyTsJA)
					{
					default:
						return false;
					case 0:
					{
						ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA = -1;
						if (kYwlhzObMIIPmSLUKfBAlGTEBADkA.cnjJGampiqifPHPSycEOPktSoDLW == null || kYwlhzObMIIPmSLUKfBAlGTEBADkA.actionCategories == null)
						{
							return false;
						}
						if (ZjuUIwdBqWkCuDnfsKWeIxElFxYb == null || ZjuUIwdBqWkCuDnfsKWeIxElFxYb == string.Empty)
						{
							return false;
						}
						int num = kYwlhzObMIIPmSLUKfBAlGTEBADkA.IndexOfActionCategory(ZjuUIwdBqWkCuDnfsKWeIxElFxYb);
						if (num < 0)
						{
							return false;
						}
						RgMJbIEusNIvRPdnthdqdySnDJhF = kYwlhzObMIIPmSLUKfBAlGTEBADkA.GetActionCategory(num);
						if (mRuUtxTsRiRqCtRwpjiodWEtnOSq)
						{
							sKXcMWhLdEOrWRtuOBZAfUaRfRgU = kYwlhzObMIIPmSLUKfBAlGTEBADkA.SortedActionIdsInCategory(RgMJbIEusNIvRPdnthdqdySnDJhF.id).GetEnumerator();
							ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA = -3;
							goto IL_00f2;
						}
						jhjSmmDEosKRNPFADgCEGYyQyKkiA = 0;
						goto IL_0175;
					}
					case 1:
						ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA = -3;
						goto IL_00f2;
					case 2:
						{
							ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA = -1;
							goto IL_0163;
						}
						IL_0175:
						if (jhjSmmDEosKRNPFADgCEGYyQyKkiA >= kYwlhzObMIIPmSLUKfBAlGTEBADkA.cnjJGampiqifPHPSycEOPktSoDLW.Count)
						{
							break;
						}
						if (kYwlhzObMIIPmSLUKfBAlGTEBADkA.cnjJGampiqifPHPSycEOPktSoDLW[jhjSmmDEosKRNPFADgCEGYyQyKkiA].categoryId == RgMJbIEusNIvRPdnthdqdySnDJhF.id)
						{
							SVzLbKHgBLKIndOHKIRvMzvOjguc = kYwlhzObMIIPmSLUKfBAlGTEBADkA.cnjJGampiqifPHPSycEOPktSoDLW[jhjSmmDEosKRNPFADgCEGYyQyKkiA];
							ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA = 2;
							return true;
						}
						goto IL_0163;
						IL_00f2:
						while (sKXcMWhLdEOrWRtuOBZAfUaRfRgU.MoveNext())
						{
							int current = sKXcMWhLdEOrWRtuOBZAfUaRfRgU.Current;
							InputAction actionById = kYwlhzObMIIPmSLUKfBAlGTEBADkA.GetActionById(current);
							if (actionById != null)
							{
								SVzLbKHgBLKIndOHKIRvMzvOjguc = actionById;
								ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA = 1;
								return true;
							}
						}
						gGQmllVpGxAZpGghxkNIiureIZMkA();
						sKXcMWhLdEOrWRtuOBZAfUaRfRgU = null;
						break;
						IL_0163:
						jhjSmmDEosKRNPFADgCEGYyQyKkiA++;
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

			private void gGQmllVpGxAZpGghxkNIiureIZMkA()
			{
				ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA = -1;
				if (sKXcMWhLdEOrWRtuOBZAfUaRfRgU != null)
				{
					sKXcMWhLdEOrWRtuOBZAfUaRfRgU.Dispose();
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
				WiEUdZxsTCVQlLgmPrWOdzeoUpgG wiEUdZxsTCVQlLgmPrWOdzeoUpgG;
				if (ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA == -2 && JsekEFpvRTOrLNUuifNotWjvIHVG == Environment.CurrentManagedThreadId)
				{
					ZmdbJGXdjoiNKSJWVGqkKNTdyTsJA = 0;
					wiEUdZxsTCVQlLgmPrWOdzeoUpgG = this;
				}
				else
				{
					wiEUdZxsTCVQlLgmPrWOdzeoUpgG = new WiEUdZxsTCVQlLgmPrWOdzeoUpgG(0);
					wiEUdZxsTCVQlLgmPrWOdzeoUpgG.KYwlhzObMIIPmSLUKfBAlGTEBADkA = KYwlhzObMIIPmSLUKfBAlGTEBADkA;
				}
				wiEUdZxsTCVQlLgmPrWOdzeoUpgG.ZjuUIwdBqWkCuDnfsKWeIxElFxYb = jBmhueEvZFRxmOPiNiPLXtrKQIuoA;
				wiEUdZxsTCVQlLgmPrWOdzeoUpgG.mRuUtxTsRiRqCtRwpjiodWEtnOSq = HglHArewLziRExGRFADWSPcsrvyu;
				return wiEUdZxsTCVQlLgmPrWOdzeoUpgG;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class nZBeTyFoIKSKKJdaNNAyGJgAQtytA : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int SFPGxREIhkBNqBLTfRVVGbYWJoOqc;

			private InputMapCategory wkDpFZjnCebcaAqRtoXohtnxaeuZ;

			private int ZiSGhvHqRUGpKCLvFSlOcYyoWEgcc;

			private string cbAPVUiVfxQoiNaTwdoKcknsZoGU;

			public string ZiFViymADakXcRaiMlQMQSpKfJXS;

			public UserData DKsCtfAuhnjbBjwmZCuGbhqEacmec;

			private int PuqOzmYIwSoJLmeauCiewtvRATmr;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return wkDpFZjnCebcaAqRtoXohtnxaeuZ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wkDpFZjnCebcaAqRtoXohtnxaeuZ;
				}
			}

			[DebuggerHidden]
			public nZBeTyFoIKSKKJdaNNAyGJgAQtytA(int P_0)
			{
				SFPGxREIhkBNqBLTfRVVGbYWJoOqc = P_0;
				ZiSGhvHqRUGpKCLvFSlOcYyoWEgcc = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int sFPGxREIhkBNqBLTfRVVGbYWJoOqc = SFPGxREIhkBNqBLTfRVVGbYWJoOqc;
				UserData dKsCtfAuhnjbBjwmZCuGbhqEacmec = DKsCtfAuhnjbBjwmZCuGbhqEacmec;
				if (sFPGxREIhkBNqBLTfRVVGbYWJoOqc != 0)
				{
					if (sFPGxREIhkBNqBLTfRVVGbYWJoOqc != 1)
					{
						return false;
					}
					SFPGxREIhkBNqBLTfRVVGbYWJoOqc = -1;
					goto IL_0098;
				}
				SFPGxREIhkBNqBLTfRVVGbYWJoOqc = -1;
				if (cbAPVUiVfxQoiNaTwdoKcknsZoGU == null || cbAPVUiVfxQoiNaTwdoKcknsZoGU == string.Empty)
				{
					return false;
				}
				if (dKsCtfAuhnjbBjwmZCuGbhqEacmec.mapCategories == null)
				{
					return false;
				}
				PuqOzmYIwSoJLmeauCiewtvRATmr = 0;
				goto IL_00a8;
				IL_00a8:
				if (PuqOzmYIwSoJLmeauCiewtvRATmr < dKsCtfAuhnjbBjwmZCuGbhqEacmec.mapCategories.Count)
				{
					if (dKsCtfAuhnjbBjwmZCuGbhqEacmec.mapCategories[PuqOzmYIwSoJLmeauCiewtvRATmr].tag.Equals(cbAPVUiVfxQoiNaTwdoKcknsZoGU, StringComparison.OrdinalIgnoreCase))
					{
						wkDpFZjnCebcaAqRtoXohtnxaeuZ = dKsCtfAuhnjbBjwmZCuGbhqEacmec.mapCategories[PuqOzmYIwSoJLmeauCiewtvRATmr];
						SFPGxREIhkBNqBLTfRVVGbYWJoOqc = 1;
						return true;
					}
					goto IL_0098;
				}
				return false;
				IL_0098:
				PuqOzmYIwSoJLmeauCiewtvRATmr++;
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
				nZBeTyFoIKSKKJdaNNAyGJgAQtytA nZBeTyFoIKSKKJdaNNAyGJgAQtytA2;
				if (SFPGxREIhkBNqBLTfRVVGbYWJoOqc == -2 && ZiSGhvHqRUGpKCLvFSlOcYyoWEgcc == Environment.CurrentManagedThreadId)
				{
					SFPGxREIhkBNqBLTfRVVGbYWJoOqc = 0;
					nZBeTyFoIKSKKJdaNNAyGJgAQtytA2 = this;
				}
				else
				{
					nZBeTyFoIKSKKJdaNNAyGJgAQtytA2 = new nZBeTyFoIKSKKJdaNNAyGJgAQtytA(0);
					nZBeTyFoIKSKKJdaNNAyGJgAQtytA2.DKsCtfAuhnjbBjwmZCuGbhqEacmec = DKsCtfAuhnjbBjwmZCuGbhqEacmec;
				}
				nZBeTyFoIKSKKJdaNNAyGJgAQtytA2.cbAPVUiVfxQoiNaTwdoKcknsZoGU = ZiFViymADakXcRaiMlQMQSpKfJXS;
				return nZBeTyFoIKSKKJdaNNAyGJgAQtytA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class MzMaUhPRunGBnyKjqCoVyUmzDoAC : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int npUfohRIhzjWcxoowrhZUxVWAllU;

			private string jrlvkCUIMHPeISzlbnjuolMMBKWD;

			private int ZkwnFbWRukEojXGizbgrubJeIUm;

			public UserData zHFMpQPAMsEqkxUsyKOXNlBUinhg;

			private int VdyXbQLNvAWzByboPaekNpXAXYhq;

			public int lFHGqHSJKIqDmINzEZaQBPmRwsyM;

			private IEnumerator<int> vxQVtpDmEXgSmgNYYpQvrkTAsYqLA;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return jrlvkCUIMHPeISzlbnjuolMMBKWD;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return jrlvkCUIMHPeISzlbnjuolMMBKWD;
				}
			}

			[DebuggerHidden]
			public MzMaUhPRunGBnyKjqCoVyUmzDoAC(int P_0)
			{
				npUfohRIhzjWcxoowrhZUxVWAllU = P_0;
				ZkwnFbWRukEojXGizbgrubJeIUm = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = npUfohRIhzjWcxoowrhZUxVWAllU;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						bFiLCSmyyoXDWEimCGIEoUGUibyF();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = npUfohRIhzjWcxoowrhZUxVWAllU;
					UserData userData = zHFMpQPAMsEqkxUsyKOXNlBUinhg;
					switch (num)
					{
					default:
						return false;
					case 0:
						npUfohRIhzjWcxoowrhZUxVWAllU = -1;
						if (userData.actionCategories == null || userData.cnjJGampiqifPHPSycEOPktSoDLW == null)
						{
							return false;
						}
						vxQVtpDmEXgSmgNYYpQvrkTAsYqLA = userData.actionCategoryMap.ActionIdsInCategory(VdyXbQLNvAWzByboPaekNpXAXYhq).GetEnumerator();
						npUfohRIhzjWcxoowrhZUxVWAllU = -3;
						break;
					case 1:
						npUfohRIhzjWcxoowrhZUxVWAllU = -3;
						break;
					}
					while (vxQVtpDmEXgSmgNYYpQvrkTAsYqLA.MoveNext())
					{
						int current = vxQVtpDmEXgSmgNYYpQvrkTAsYqLA.Current;
						InputAction actionById = userData.GetActionById(current);
						if (actionById != null)
						{
							jrlvkCUIMHPeISzlbnjuolMMBKWD = actionById.descriptiveName;
							npUfohRIhzjWcxoowrhZUxVWAllU = 1;
							return true;
						}
					}
					bFiLCSmyyoXDWEimCGIEoUGUibyF();
					vxQVtpDmEXgSmgNYYpQvrkTAsYqLA = null;
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

			private void bFiLCSmyyoXDWEimCGIEoUGUibyF()
			{
				npUfohRIhzjWcxoowrhZUxVWAllU = -1;
				if (vxQVtpDmEXgSmgNYYpQvrkTAsYqLA != null)
				{
					vxQVtpDmEXgSmgNYYpQvrkTAsYqLA.Dispose();
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
				MzMaUhPRunGBnyKjqCoVyUmzDoAC mzMaUhPRunGBnyKjqCoVyUmzDoAC;
				if (npUfohRIhzjWcxoowrhZUxVWAllU == -2 && ZkwnFbWRukEojXGizbgrubJeIUm == Environment.CurrentManagedThreadId)
				{
					npUfohRIhzjWcxoowrhZUxVWAllU = 0;
					mzMaUhPRunGBnyKjqCoVyUmzDoAC = this;
				}
				else
				{
					mzMaUhPRunGBnyKjqCoVyUmzDoAC = new MzMaUhPRunGBnyKjqCoVyUmzDoAC(0);
					mzMaUhPRunGBnyKjqCoVyUmzDoAC.zHFMpQPAMsEqkxUsyKOXNlBUinhg = zHFMpQPAMsEqkxUsyKOXNlBUinhg;
				}
				mzMaUhPRunGBnyKjqCoVyUmzDoAC.VdyXbQLNvAWzByboPaekNpXAXYhq = lFHGqHSJKIqDmINzEZaQBPmRwsyM;
				return mzMaUhPRunGBnyKjqCoVyUmzDoAC;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class CbAQPHOEGCQXfCCBVIfqMmtGBDEAA : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int BRdNKgKRFDCeyUkhiLnPKLegBcVj;

			private int MhsfYnCHBZpCscoPfnDIIEOCzLBSd;

			private int FCsbPYjMRWZNwNTukpHZOJqDgBYZA;

			public UserData bDdORuwPNTXFTSWCBMmHpACEAoEu;

			private int EIzAUsHtLEddKBUaEbkhlXiWcALRA;

			public int yjCvsolXqTQDBMULgAidoBssZlIN;

			private IEnumerator<int> BHSBeGLGJNxxMcHcaeaGNWAbwrGm;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return MhsfYnCHBZpCscoPfnDIIEOCzLBSd;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return MhsfYnCHBZpCscoPfnDIIEOCzLBSd;
				}
			}

			[DebuggerHidden]
			public CbAQPHOEGCQXfCCBVIfqMmtGBDEAA(int P_0)
			{
				BRdNKgKRFDCeyUkhiLnPKLegBcVj = P_0;
				FCsbPYjMRWZNwNTukpHZOJqDgBYZA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int bRdNKgKRFDCeyUkhiLnPKLegBcVj = BRdNKgKRFDCeyUkhiLnPKLegBcVj;
				if (bRdNKgKRFDCeyUkhiLnPKLegBcVj == -3 || bRdNKgKRFDCeyUkhiLnPKLegBcVj == 1)
				{
					try
					{
					}
					finally
					{
						qeufAYHgcMLuIchosikZfgiGWVhQA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int bRdNKgKRFDCeyUkhiLnPKLegBcVj = BRdNKgKRFDCeyUkhiLnPKLegBcVj;
					UserData userData = bDdORuwPNTXFTSWCBMmHpACEAoEu;
					switch (bRdNKgKRFDCeyUkhiLnPKLegBcVj)
					{
					default:
						return false;
					case 0:
						BRdNKgKRFDCeyUkhiLnPKLegBcVj = -1;
						if (userData.actionCategories == null || userData.cnjJGampiqifPHPSycEOPktSoDLW == null)
						{
							return false;
						}
						BHSBeGLGJNxxMcHcaeaGNWAbwrGm = userData.actionCategoryMap.ActionIdsInCategory(EIzAUsHtLEddKBUaEbkhlXiWcALRA).GetEnumerator();
						BRdNKgKRFDCeyUkhiLnPKLegBcVj = -3;
						break;
					case 1:
						BRdNKgKRFDCeyUkhiLnPKLegBcVj = -3;
						break;
					}
					if (BHSBeGLGJNxxMcHcaeaGNWAbwrGm.MoveNext())
					{
						int current = BHSBeGLGJNxxMcHcaeaGNWAbwrGm.Current;
						MhsfYnCHBZpCscoPfnDIIEOCzLBSd = current;
						BRdNKgKRFDCeyUkhiLnPKLegBcVj = 1;
						return true;
					}
					qeufAYHgcMLuIchosikZfgiGWVhQA();
					BHSBeGLGJNxxMcHcaeaGNWAbwrGm = null;
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

			private void qeufAYHgcMLuIchosikZfgiGWVhQA()
			{
				BRdNKgKRFDCeyUkhiLnPKLegBcVj = -1;
				if (BHSBeGLGJNxxMcHcaeaGNWAbwrGm != null)
				{
					BHSBeGLGJNxxMcHcaeaGNWAbwrGm.Dispose();
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
				CbAQPHOEGCQXfCCBVIfqMmtGBDEAA cbAQPHOEGCQXfCCBVIfqMmtGBDEAA;
				if (BRdNKgKRFDCeyUkhiLnPKLegBcVj == -2 && FCsbPYjMRWZNwNTukpHZOJqDgBYZA == Environment.CurrentManagedThreadId)
				{
					BRdNKgKRFDCeyUkhiLnPKLegBcVj = 0;
					cbAQPHOEGCQXfCCBVIfqMmtGBDEAA = this;
				}
				else
				{
					cbAQPHOEGCQXfCCBVIfqMmtGBDEAA = new CbAQPHOEGCQXfCCBVIfqMmtGBDEAA(0);
					cbAQPHOEGCQXfCCBVIfqMmtGBDEAA.bDdORuwPNTXFTSWCBMmHpACEAoEu = bDdORuwPNTXFTSWCBMmHpACEAoEu;
				}
				cbAQPHOEGCQXfCCBVIfqMmtGBDEAA.EIzAUsHtLEddKBUaEbkhlXiWcALRA = yjCvsolXqTQDBMULgAidoBssZlIN;
				return cbAQPHOEGCQXfCCBVIfqMmtGBDEAA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		private sealed class MUZTeBAeUtAnQDntvHfVtQaTDoxgb : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int iNHfeYNjCthYxEWoxsBYCTDcmyfKA;

			private string jQNedhGgWKSPLNzQGzucnjQhxLxk;

			private int BRfKWSKkiTuapFjDgtKCQIhudcrt;

			public UserData QByTMhAUcUneQadsVdwPCoEvIUPp;

			private int VrRTBGzGiVHmEpVBhhGIkMvkrRwaA;

			public int exaJuyJlJqyWMiZqbahuqFLrSiJL;

			private IEnumerator<int> fvTkpEuhPjOlLRrFTMmeUVgZaWhE;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return jQNedhGgWKSPLNzQGzucnjQhxLxk;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return jQNedhGgWKSPLNzQGzucnjQhxLxk;
				}
			}

			[DebuggerHidden]
			public MUZTeBAeUtAnQDntvHfVtQaTDoxgb(int P_0)
			{
				iNHfeYNjCthYxEWoxsBYCTDcmyfKA = P_0;
				BRfKWSKkiTuapFjDgtKCQIhudcrt = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = iNHfeYNjCthYxEWoxsBYCTDcmyfKA;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						EgcRIqRTbPiPhXxoCIpaYGQrztKS();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = iNHfeYNjCthYxEWoxsBYCTDcmyfKA;
					UserData qByTMhAUcUneQadsVdwPCoEvIUPp = QByTMhAUcUneQadsVdwPCoEvIUPp;
					switch (num)
					{
					default:
						return false;
					case 0:
						iNHfeYNjCthYxEWoxsBYCTDcmyfKA = -1;
						if (qByTMhAUcUneQadsVdwPCoEvIUPp.actionCategories == null || qByTMhAUcUneQadsVdwPCoEvIUPp.cnjJGampiqifPHPSycEOPktSoDLW == null)
						{
							return false;
						}
						fvTkpEuhPjOlLRrFTMmeUVgZaWhE = qByTMhAUcUneQadsVdwPCoEvIUPp.actionCategoryMap.ActionIdsInCategory(VrRTBGzGiVHmEpVBhhGIkMvkrRwaA).GetEnumerator();
						iNHfeYNjCthYxEWoxsBYCTDcmyfKA = -3;
						break;
					case 1:
						iNHfeYNjCthYxEWoxsBYCTDcmyfKA = -3;
						break;
					}
					while (fvTkpEuhPjOlLRrFTMmeUVgZaWhE.MoveNext())
					{
						int current = fvTkpEuhPjOlLRrFTMmeUVgZaWhE.Current;
						InputAction actionById = qByTMhAUcUneQadsVdwPCoEvIUPp.GetActionById(current);
						if (actionById != null)
						{
							jQNedhGgWKSPLNzQGzucnjQhxLxk = actionById.name;
							iNHfeYNjCthYxEWoxsBYCTDcmyfKA = 1;
							return true;
						}
					}
					EgcRIqRTbPiPhXxoCIpaYGQrztKS();
					fvTkpEuhPjOlLRrFTMmeUVgZaWhE = null;
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

			private void EgcRIqRTbPiPhXxoCIpaYGQrztKS()
			{
				iNHfeYNjCthYxEWoxsBYCTDcmyfKA = -1;
				if (fvTkpEuhPjOlLRrFTMmeUVgZaWhE != null)
				{
					fvTkpEuhPjOlLRrFTMmeUVgZaWhE.Dispose();
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
				MUZTeBAeUtAnQDntvHfVtQaTDoxgb mUZTeBAeUtAnQDntvHfVtQaTDoxgb;
				if (iNHfeYNjCthYxEWoxsBYCTDcmyfKA == -2 && BRfKWSKkiTuapFjDgtKCQIhudcrt == Environment.CurrentManagedThreadId)
				{
					iNHfeYNjCthYxEWoxsBYCTDcmyfKA = 0;
					mUZTeBAeUtAnQDntvHfVtQaTDoxgb = this;
				}
				else
				{
					mUZTeBAeUtAnQDntvHfVtQaTDoxgb = new MUZTeBAeUtAnQDntvHfVtQaTDoxgb(0);
					mUZTeBAeUtAnQDntvHfVtQaTDoxgb.QByTMhAUcUneQadsVdwPCoEvIUPp = QByTMhAUcUneQadsVdwPCoEvIUPp;
				}
				mUZTeBAeUtAnQDntvHfVtQaTDoxgb.VrRTBGzGiVHmEpVBhhGIkMvkrRwaA = exaJuyJlJqyWMiZqbahuqFLrSiJL;
				return mUZTeBAeUtAnQDntvHfVtQaTDoxgb;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<string>)this).GetEnumerator();
			}
		}

		private sealed class ongxWBQbKYOtBQOzcgzsaNHxmDmw : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int DbgFcwvAGFZmOKndFKKHsenWScfV;

			private InputCategory yiueIPuXvxXKDVGsKyyKrQKLxSyV;

			private int YUhoJtigaEWZjSMtvylDjMafEizd;

			private string fRcTtEctnRwwRMqzoEGEZipSFcdG;

			public string PuQKOTeIgmdojEinpiJLvjLeMKSE;

			public UserData JaBZekmsaINEVquXmaxggtoFmFuT;

			private int RLNRvoFdWFeCCyBcUKTcTwusLxWe;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return yiueIPuXvxXKDVGsKyyKrQKLxSyV;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return yiueIPuXvxXKDVGsKyyKrQKLxSyV;
				}
			}

			[DebuggerHidden]
			public ongxWBQbKYOtBQOzcgzsaNHxmDmw(int P_0)
			{
				DbgFcwvAGFZmOKndFKKHsenWScfV = P_0;
				YUhoJtigaEWZjSMtvylDjMafEizd = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int dbgFcwvAGFZmOKndFKKHsenWScfV = DbgFcwvAGFZmOKndFKKHsenWScfV;
				UserData jaBZekmsaINEVquXmaxggtoFmFuT = JaBZekmsaINEVquXmaxggtoFmFuT;
				if (dbgFcwvAGFZmOKndFKKHsenWScfV != 0)
				{
					if (dbgFcwvAGFZmOKndFKKHsenWScfV != 1)
					{
						return false;
					}
					DbgFcwvAGFZmOKndFKKHsenWScfV = -1;
					goto IL_00b3;
				}
				DbgFcwvAGFZmOKndFKKHsenWScfV = -1;
				if (fRcTtEctnRwwRMqzoEGEZipSFcdG == null || fRcTtEctnRwwRMqzoEGEZipSFcdG == string.Empty)
				{
					return false;
				}
				if (jaBZekmsaINEVquXmaxggtoFmFuT.actionCategories == null)
				{
					return false;
				}
				RLNRvoFdWFeCCyBcUKTcTwusLxWe = 0;
				goto IL_00c3;
				IL_00c3:
				if (RLNRvoFdWFeCCyBcUKTcTwusLxWe < jaBZekmsaINEVquXmaxggtoFmFuT.actionCategories.Count)
				{
					if (jaBZekmsaINEVquXmaxggtoFmFuT.actionCategories[RLNRvoFdWFeCCyBcUKTcTwusLxWe].userAssignable && jaBZekmsaINEVquXmaxggtoFmFuT.actionCategories[RLNRvoFdWFeCCyBcUKTcTwusLxWe].tag.Equals(fRcTtEctnRwwRMqzoEGEZipSFcdG, StringComparison.OrdinalIgnoreCase))
					{
						yiueIPuXvxXKDVGsKyyKrQKLxSyV = jaBZekmsaINEVquXmaxggtoFmFuT.actionCategories[RLNRvoFdWFeCCyBcUKTcTwusLxWe];
						DbgFcwvAGFZmOKndFKKHsenWScfV = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				RLNRvoFdWFeCCyBcUKTcTwusLxWe++;
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
				ongxWBQbKYOtBQOzcgzsaNHxmDmw ongxWBQbKYOtBQOzcgzsaNHxmDmw2;
				if (DbgFcwvAGFZmOKndFKKHsenWScfV == -2 && YUhoJtigaEWZjSMtvylDjMafEizd == Environment.CurrentManagedThreadId)
				{
					DbgFcwvAGFZmOKndFKKHsenWScfV = 0;
					ongxWBQbKYOtBQOzcgzsaNHxmDmw2 = this;
				}
				else
				{
					ongxWBQbKYOtBQOzcgzsaNHxmDmw2 = new ongxWBQbKYOtBQOzcgzsaNHxmDmw(0);
					ongxWBQbKYOtBQOzcgzsaNHxmDmw2.JaBZekmsaINEVquXmaxggtoFmFuT = JaBZekmsaINEVquXmaxggtoFmFuT;
				}
				ongxWBQbKYOtBQOzcgzsaNHxmDmw2.fRcTtEctnRwwRMqzoEGEZipSFcdG = PuQKOTeIgmdojEinpiJLvjLeMKSE;
				return ongxWBQbKYOtBQOzcgzsaNHxmDmw2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class LjLHnMfPhupUmNVnLubslVkvYnSb : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int alAWCWuiiOvxAseoXHvUgtjWahJK;

			private InputAction DaDQhxZuwgcRMMLjiiVrDjMSlfBI;

			private int KElFUflfXxfCiprozoAFNSOnEJhJA;

			public UserData yRsvDhkHdlknBSQzcZTdOWyuZpUg;

			private int DFzlIXIZnPllMSmhjXxVBjNsxFkH;

			public int ZKcshmBbWGtZsBYdNRvYVvrDjMpV;

			private bool DBuURLUXMhJXbubwkgkLiVoCRxQB;

			public bool nUBckFFQLTKVPGBQtQvdEyzBwyplb;

			private InputCategory voPNDeJZNTbasYcDYVGizMkDVjNg;

			private IEnumerator<int> DaXemoInxFwfvGywVdtyJGDYPthS;

			private int jgsXuNpiyCQntHwOakwzTlmuTeIQ;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return DaDQhxZuwgcRMMLjiiVrDjMSlfBI;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DaDQhxZuwgcRMMLjiiVrDjMSlfBI;
				}
			}

			[DebuggerHidden]
			public LjLHnMfPhupUmNVnLubslVkvYnSb(int P_0)
			{
				alAWCWuiiOvxAseoXHvUgtjWahJK = P_0;
				KElFUflfXxfCiprozoAFNSOnEJhJA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = alAWCWuiiOvxAseoXHvUgtjWahJK;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						HcOgCUgPKUiANAQUIjqQZMeVrCQiB();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = alAWCWuiiOvxAseoXHvUgtjWahJK;
					UserData userData = yRsvDhkHdlknBSQzcZTdOWyuZpUg;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						alAWCWuiiOvxAseoXHvUgtjWahJK = -1;
						if (userData.cnjJGampiqifPHPSycEOPktSoDLW == null || userData.actionCategories == null)
						{
							return false;
						}
						voPNDeJZNTbasYcDYVGizMkDVjNg = userData.GetActionCategoryById(DFzlIXIZnPllMSmhjXxVBjNsxFkH);
						if (voPNDeJZNTbasYcDYVGizMkDVjNg == null || !voPNDeJZNTbasYcDYVGizMkDVjNg.userAssignable)
						{
							return false;
						}
						if (DBuURLUXMhJXbubwkgkLiVoCRxQB)
						{
							DaXemoInxFwfvGywVdtyJGDYPthS = userData.SortedActionIdsInCategory(voPNDeJZNTbasYcDYVGizMkDVjNg.id).GetEnumerator();
							alAWCWuiiOvxAseoXHvUgtjWahJK = -3;
							goto IL_00e4;
						}
						jgsXuNpiyCQntHwOakwzTlmuTeIQ = 0;
						goto IL_0165;
					case 1:
						alAWCWuiiOvxAseoXHvUgtjWahJK = -3;
						goto IL_00e4;
					case 2:
						{
							alAWCWuiiOvxAseoXHvUgtjWahJK = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (DaXemoInxFwfvGywVdtyJGDYPthS.MoveNext())
						{
							int current = DaXemoInxFwfvGywVdtyJGDYPthS.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								DaDQhxZuwgcRMMLjiiVrDjMSlfBI = actionById;
								alAWCWuiiOvxAseoXHvUgtjWahJK = 1;
								return true;
							}
						}
						HcOgCUgPKUiANAQUIjqQZMeVrCQiB();
						DaXemoInxFwfvGywVdtyJGDYPthS = null;
						break;
						IL_0153:
						jgsXuNpiyCQntHwOakwzTlmuTeIQ++;
						goto IL_0165;
						IL_0165:
						if (jgsXuNpiyCQntHwOakwzTlmuTeIQ >= userData.cnjJGampiqifPHPSycEOPktSoDLW.Count)
						{
							break;
						}
						inputAction = userData.cnjJGampiqifPHPSycEOPktSoDLW[jgsXuNpiyCQntHwOakwzTlmuTeIQ];
						if (inputAction.categoryId == voPNDeJZNTbasYcDYVGizMkDVjNg.id && inputAction.userAssignable)
						{
							DaDQhxZuwgcRMMLjiiVrDjMSlfBI = inputAction;
							alAWCWuiiOvxAseoXHvUgtjWahJK = 2;
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

			private void HcOgCUgPKUiANAQUIjqQZMeVrCQiB()
			{
				alAWCWuiiOvxAseoXHvUgtjWahJK = -1;
				if (DaXemoInxFwfvGywVdtyJGDYPthS != null)
				{
					DaXemoInxFwfvGywVdtyJGDYPthS.Dispose();
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
				LjLHnMfPhupUmNVnLubslVkvYnSb ljLHnMfPhupUmNVnLubslVkvYnSb;
				if (alAWCWuiiOvxAseoXHvUgtjWahJK == -2 && KElFUflfXxfCiprozoAFNSOnEJhJA == Environment.CurrentManagedThreadId)
				{
					alAWCWuiiOvxAseoXHvUgtjWahJK = 0;
					ljLHnMfPhupUmNVnLubslVkvYnSb = this;
				}
				else
				{
					ljLHnMfPhupUmNVnLubslVkvYnSb = new LjLHnMfPhupUmNVnLubslVkvYnSb(0);
					ljLHnMfPhupUmNVnLubslVkvYnSb.yRsvDhkHdlknBSQzcZTdOWyuZpUg = yRsvDhkHdlknBSQzcZTdOWyuZpUg;
				}
				ljLHnMfPhupUmNVnLubslVkvYnSb.DFzlIXIZnPllMSmhjXxVBjNsxFkH = ZKcshmBbWGtZsBYdNRvYVvrDjMpV;
				ljLHnMfPhupUmNVnLubslVkvYnSb.DBuURLUXMhJXbubwkgkLiVoCRxQB = nUBckFFQLTKVPGBQtQvdEyzBwyplb;
				return ljLHnMfPhupUmNVnLubslVkvYnSb;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class QiLxGUamMmqtUMCqOUphTYnQRcGJ : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int vvnzVZuuUHKlSSrdwrqBemsraJps;

			private InputAction zfqEXCGiAAqWpnmwnjetgAumIvfn;

			private int QrmbAoKIxKQskleEoohCHaOkmMhrA;

			public UserData pPMtZaOugfZJmaCYQhgysXyuMUSr;

			private string DcfwjdifBFcDJSFzidQYLfnCjuPiA;

			public string CAybnosVfdYIdchLKMcUAeeeBNor;

			private bool tuhFNUmVvWvOhXXbXldghoeqycbe;

			public bool cSJThbcavFlaUpKKzFTyWqrxJqCt;

			private InputCategory FGwJyRmRSjdYUKEZTMPxSKAciJuw;

			private IEnumerator<int> CQdGPxPvRVFCxqHVEGcgbxAwYKOv;

			private int mQyBBOaEsChmGimHcwatKqcKBQNWA;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return zfqEXCGiAAqWpnmwnjetgAumIvfn;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return zfqEXCGiAAqWpnmwnjetgAumIvfn;
				}
			}

			[DebuggerHidden]
			public QiLxGUamMmqtUMCqOUphTYnQRcGJ(int P_0)
			{
				vvnzVZuuUHKlSSrdwrqBemsraJps = P_0;
				QrmbAoKIxKQskleEoohCHaOkmMhrA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = vvnzVZuuUHKlSSrdwrqBemsraJps;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						wiwhkLjRxFemLpSFbHgVxoKXPMbd();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = vvnzVZuuUHKlSSrdwrqBemsraJps;
					UserData userData = pPMtZaOugfZJmaCYQhgysXyuMUSr;
					InputAction inputAction;
					switch (num)
					{
					default:
						return false;
					case 0:
						vvnzVZuuUHKlSSrdwrqBemsraJps = -1;
						if (userData.cnjJGampiqifPHPSycEOPktSoDLW == null || userData.actionCategories == null)
						{
							return false;
						}
						FGwJyRmRSjdYUKEZTMPxSKAciJuw = userData.GetActionCategory(DcfwjdifBFcDJSFzidQYLfnCjuPiA);
						if (FGwJyRmRSjdYUKEZTMPxSKAciJuw == null || !FGwJyRmRSjdYUKEZTMPxSKAciJuw.userAssignable)
						{
							return false;
						}
						if (tuhFNUmVvWvOhXXbXldghoeqycbe)
						{
							CQdGPxPvRVFCxqHVEGcgbxAwYKOv = userData.SortedActionIdsInCategory(FGwJyRmRSjdYUKEZTMPxSKAciJuw.id).GetEnumerator();
							vvnzVZuuUHKlSSrdwrqBemsraJps = -3;
							goto IL_00e4;
						}
						mQyBBOaEsChmGimHcwatKqcKBQNWA = 0;
						goto IL_0165;
					case 1:
						vvnzVZuuUHKlSSrdwrqBemsraJps = -3;
						goto IL_00e4;
					case 2:
						{
							vvnzVZuuUHKlSSrdwrqBemsraJps = -1;
							goto IL_0153;
						}
						IL_00e4:
						while (CQdGPxPvRVFCxqHVEGcgbxAwYKOv.MoveNext())
						{
							int current = CQdGPxPvRVFCxqHVEGcgbxAwYKOv.Current;
							InputAction actionById = userData.GetActionById(current);
							if (actionById != null && actionById.userAssignable)
							{
								zfqEXCGiAAqWpnmwnjetgAumIvfn = actionById;
								vvnzVZuuUHKlSSrdwrqBemsraJps = 1;
								return true;
							}
						}
						wiwhkLjRxFemLpSFbHgVxoKXPMbd();
						CQdGPxPvRVFCxqHVEGcgbxAwYKOv = null;
						break;
						IL_0153:
						mQyBBOaEsChmGimHcwatKqcKBQNWA++;
						goto IL_0165;
						IL_0165:
						if (mQyBBOaEsChmGimHcwatKqcKBQNWA >= userData.cnjJGampiqifPHPSycEOPktSoDLW.Count)
						{
							break;
						}
						inputAction = userData.cnjJGampiqifPHPSycEOPktSoDLW[mQyBBOaEsChmGimHcwatKqcKBQNWA];
						if (inputAction.categoryId == FGwJyRmRSjdYUKEZTMPxSKAciJuw.id && inputAction.userAssignable)
						{
							zfqEXCGiAAqWpnmwnjetgAumIvfn = inputAction;
							vvnzVZuuUHKlSSrdwrqBemsraJps = 2;
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

			private void wiwhkLjRxFemLpSFbHgVxoKXPMbd()
			{
				vvnzVZuuUHKlSSrdwrqBemsraJps = -1;
				if (CQdGPxPvRVFCxqHVEGcgbxAwYKOv != null)
				{
					CQdGPxPvRVFCxqHVEGcgbxAwYKOv.Dispose();
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
				QiLxGUamMmqtUMCqOUphTYnQRcGJ qiLxGUamMmqtUMCqOUphTYnQRcGJ;
				if (vvnzVZuuUHKlSSrdwrqBemsraJps == -2 && QrmbAoKIxKQskleEoohCHaOkmMhrA == Environment.CurrentManagedThreadId)
				{
					vvnzVZuuUHKlSSrdwrqBemsraJps = 0;
					qiLxGUamMmqtUMCqOUphTYnQRcGJ = this;
				}
				else
				{
					qiLxGUamMmqtUMCqOUphTYnQRcGJ = new QiLxGUamMmqtUMCqOUphTYnQRcGJ(0);
					qiLxGUamMmqtUMCqOUphTYnQRcGJ.pPMtZaOugfZJmaCYQhgysXyuMUSr = pPMtZaOugfZJmaCYQhgysXyuMUSr;
				}
				qiLxGUamMmqtUMCqOUphTYnQRcGJ.DcfwjdifBFcDJSFzidQYLfnCjuPiA = CAybnosVfdYIdchLKMcUAeeeBNor;
				qiLxGUamMmqtUMCqOUphTYnQRcGJ.tuhFNUmVvWvOhXXbXldghoeqycbe = cSJThbcavFlaUpKKzFTyWqrxJqCt;
				return qiLxGUamMmqtUMCqOUphTYnQRcGJ;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class uSuiiMbnfzEtEpZFJHHJHEkrekmJ : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int zajaIOFkzQxveOLZSUOGAyWVYvMx;

			private InputMapCategory nJezMDtCUNuPgFwAttyammunKfNf;

			private int ERQlYbQRrpSFaWByFYghsWdYGfcu;

			private string yfVmVtRLkgCEsJJKGrDElNdCuhxn;

			public string ueyTMYIYwWqtsOjdNZloeGovjWhi;

			public UserData ezvecXhFkUhDELeaYHpqzhmZXgNV;

			private int obhQfPmLyKbjTjsWUvsJFWjdlYEp;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return nJezMDtCUNuPgFwAttyammunKfNf;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return nJezMDtCUNuPgFwAttyammunKfNf;
				}
			}

			[DebuggerHidden]
			public uSuiiMbnfzEtEpZFJHHJHEkrekmJ(int P_0)
			{
				zajaIOFkzQxveOLZSUOGAyWVYvMx = P_0;
				ERQlYbQRrpSFaWByFYghsWdYGfcu = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = zajaIOFkzQxveOLZSUOGAyWVYvMx;
				UserData userData = ezvecXhFkUhDELeaYHpqzhmZXgNV;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					zajaIOFkzQxveOLZSUOGAyWVYvMx = -1;
					goto IL_00b3;
				}
				zajaIOFkzQxveOLZSUOGAyWVYvMx = -1;
				if (yfVmVtRLkgCEsJJKGrDElNdCuhxn == null || yfVmVtRLkgCEsJJKGrDElNdCuhxn == string.Empty)
				{
					return false;
				}
				if (userData.mapCategories == null)
				{
					return false;
				}
				obhQfPmLyKbjTjsWUvsJFWjdlYEp = 0;
				goto IL_00c3;
				IL_00c3:
				if (obhQfPmLyKbjTjsWUvsJFWjdlYEp < userData.mapCategories.Count)
				{
					if (userData.mapCategories[obhQfPmLyKbjTjsWUvsJFWjdlYEp].userAssignable && userData.mapCategories[obhQfPmLyKbjTjsWUvsJFWjdlYEp].tag.Equals(yfVmVtRLkgCEsJJKGrDElNdCuhxn, StringComparison.OrdinalIgnoreCase))
					{
						nJezMDtCUNuPgFwAttyammunKfNf = userData.mapCategories[obhQfPmLyKbjTjsWUvsJFWjdlYEp];
						zajaIOFkzQxveOLZSUOGAyWVYvMx = 1;
						return true;
					}
					goto IL_00b3;
				}
				return false;
				IL_00b3:
				obhQfPmLyKbjTjsWUvsJFWjdlYEp++;
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
				uSuiiMbnfzEtEpZFJHHJHEkrekmJ uSuiiMbnfzEtEpZFJHHJHEkrekmJ2;
				if (zajaIOFkzQxveOLZSUOGAyWVYvMx == -2 && ERQlYbQRrpSFaWByFYghsWdYGfcu == Environment.CurrentManagedThreadId)
				{
					zajaIOFkzQxveOLZSUOGAyWVYvMx = 0;
					uSuiiMbnfzEtEpZFJHHJHEkrekmJ2 = this;
				}
				else
				{
					uSuiiMbnfzEtEpZFJHHJHEkrekmJ2 = new uSuiiMbnfzEtEpZFJHHJHEkrekmJ(0);
					uSuiiMbnfzEtEpZFJHHJHEkrekmJ2.ezvecXhFkUhDELeaYHpqzhmZXgNV = ezvecXhFkUhDELeaYHpqzhmZXgNV;
				}
				uSuiiMbnfzEtEpZFJHHJHEkrekmJ2.yfVmVtRLkgCEsJJKGrDElNdCuhxn = ueyTMYIYwWqtsOjdNZloeGovjWhi;
				return uSuiiMbnfzEtEpZFJHHJHEkrekmJ2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
			}
		}

		private sealed class JAHqCqizBLFgpILklcNpjSpCoibK : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
		{
			private int wBhwMdIUinBmwteRmPgVIJoJSzgl;

			private InputCategory ifRBgDAPmJkyytXljxtTMacJMsZJ;

			private int ofkxEYSMApkgqMvDaGCMbrVWCZnq;

			public UserData NavJjqmKySOAjeLVDbJucAoMiBMcb;

			private int MydGwJvVrtcwazGmESxUWbpmLQVh;

			InputCategory IEnumerator<InputCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return ifRBgDAPmJkyytXljxtTMacJMsZJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ifRBgDAPmJkyytXljxtTMacJMsZJ;
				}
			}

			[DebuggerHidden]
			public JAHqCqizBLFgpILklcNpjSpCoibK(int P_0)
			{
				wBhwMdIUinBmwteRmPgVIJoJSzgl = P_0;
				ofkxEYSMApkgqMvDaGCMbrVWCZnq = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = wBhwMdIUinBmwteRmPgVIJoJSzgl;
				UserData navJjqmKySOAjeLVDbJucAoMiBMcb = NavJjqmKySOAjeLVDbJucAoMiBMcb;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					wBhwMdIUinBmwteRmPgVIJoJSzgl = -1;
					goto IL_0070;
				}
				wBhwMdIUinBmwteRmPgVIJoJSzgl = -1;
				if (navJjqmKySOAjeLVDbJucAoMiBMcb.actionCategories == null)
				{
					return false;
				}
				MydGwJvVrtcwazGmESxUWbpmLQVh = 0;
				goto IL_0080;
				IL_0080:
				if (MydGwJvVrtcwazGmESxUWbpmLQVh < navJjqmKySOAjeLVDbJucAoMiBMcb.actionCategories.Count)
				{
					if (navJjqmKySOAjeLVDbJucAoMiBMcb.actionCategories[MydGwJvVrtcwazGmESxUWbpmLQVh].userAssignable)
					{
						ifRBgDAPmJkyytXljxtTMacJMsZJ = navJjqmKySOAjeLVDbJucAoMiBMcb.actionCategories[MydGwJvVrtcwazGmESxUWbpmLQVh];
						wBhwMdIUinBmwteRmPgVIJoJSzgl = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				MydGwJvVrtcwazGmESxUWbpmLQVh++;
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
				JAHqCqizBLFgpILklcNpjSpCoibK jAHqCqizBLFgpILklcNpjSpCoibK;
				if (wBhwMdIUinBmwteRmPgVIJoJSzgl == -2 && ofkxEYSMApkgqMvDaGCMbrVWCZnq == Environment.CurrentManagedThreadId)
				{
					wBhwMdIUinBmwteRmPgVIJoJSzgl = 0;
					jAHqCqizBLFgpILklcNpjSpCoibK = this;
				}
				else
				{
					jAHqCqizBLFgpILklcNpjSpCoibK = new JAHqCqizBLFgpILklcNpjSpCoibK(0);
					jAHqCqizBLFgpILklcNpjSpCoibK.NavJjqmKySOAjeLVDbJucAoMiBMcb = NavJjqmKySOAjeLVDbJucAoMiBMcb;
				}
				return jAHqCqizBLFgpILklcNpjSpCoibK;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputCategory>)this).GetEnumerator();
			}
		}

		private sealed class sEZpQdMEmAMQPlZHveHtukAYpkVX : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
		{
			private int gQxmTtTXmQJeElrElxrjBJfGsUxr;

			private InputAction RkVhUGIbfBsWInTYFScGkrASypEj;

			private int vxDVPrgLpmXuDRdiWRxDrSEDMFou;

			public UserData peZyVmrkfUYGfHRDDPUQXsBKpIvP;

			private int zrBjGEEXMVOkNhmIsPnUcgFHPxyu;

			InputAction IEnumerator<InputAction>.Current
			{
				[DebuggerHidden]
				get
				{
					return RkVhUGIbfBsWInTYFScGkrASypEj;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RkVhUGIbfBsWInTYFScGkrASypEj;
				}
			}

			[DebuggerHidden]
			public sEZpQdMEmAMQPlZHveHtukAYpkVX(int P_0)
			{
				gQxmTtTXmQJeElrElxrjBJfGsUxr = P_0;
				vxDVPrgLpmXuDRdiWRxDrSEDMFou = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = gQxmTtTXmQJeElrElxrjBJfGsUxr;
				UserData userData = peZyVmrkfUYGfHRDDPUQXsBKpIvP;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					gQxmTtTXmQJeElrElxrjBJfGsUxr = -1;
					goto IL_007a;
				}
				gQxmTtTXmQJeElrElxrjBJfGsUxr = -1;
				if (userData.cnjJGampiqifPHPSycEOPktSoDLW == null)
				{
					return false;
				}
				zrBjGEEXMVOkNhmIsPnUcgFHPxyu = 0;
				goto IL_008c;
				IL_008c:
				if (zrBjGEEXMVOkNhmIsPnUcgFHPxyu < userData.cnjJGampiqifPHPSycEOPktSoDLW.Count)
				{
					InputAction inputAction = userData.cnjJGampiqifPHPSycEOPktSoDLW[zrBjGEEXMVOkNhmIsPnUcgFHPxyu];
					InputCategory actionCategoryById = userData.GetActionCategoryById(inputAction.categoryId);
					if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
					{
						RkVhUGIbfBsWInTYFScGkrASypEj = inputAction;
						gQxmTtTXmQJeElrElxrjBJfGsUxr = 1;
						return true;
					}
					goto IL_007a;
				}
				return false;
				IL_007a:
				zrBjGEEXMVOkNhmIsPnUcgFHPxyu++;
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
				sEZpQdMEmAMQPlZHveHtukAYpkVX sEZpQdMEmAMQPlZHveHtukAYpkVX2;
				if (gQxmTtTXmQJeElrElxrjBJfGsUxr == -2 && vxDVPrgLpmXuDRdiWRxDrSEDMFou == Environment.CurrentManagedThreadId)
				{
					gQxmTtTXmQJeElrElxrjBJfGsUxr = 0;
					sEZpQdMEmAMQPlZHveHtukAYpkVX2 = this;
				}
				else
				{
					sEZpQdMEmAMQPlZHveHtukAYpkVX2 = new sEZpQdMEmAMQPlZHveHtukAYpkVX(0);
					sEZpQdMEmAMQPlZHveHtukAYpkVX2.peZyVmrkfUYGfHRDDPUQXsBKpIvP = peZyVmrkfUYGfHRDDPUQXsBKpIvP;
				}
				return sEZpQdMEmAMQPlZHveHtukAYpkVX2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<InputAction>)this).GetEnumerator();
			}
		}

		private sealed class sKGBWDyScawkIUgNFwJXCWWtjZSU : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
		{
			private int XNzjJqTRDsRYIhfFtRprggLRkhrX;

			private InputMapCategory uVdRSTtFASHxcETdDbjVyLvSqhfHA;

			private int shRfDQMWeSDSFmClIGLTrkjmUbJe;

			public UserData zKteTjYdZkAHidjtCPVYYbdLYlVv;

			private int SvFRVCxFYRrUOfYWhrHzYUWRpqxE;

			InputMapCategory IEnumerator<InputMapCategory>.Current
			{
				[DebuggerHidden]
				get
				{
					return uVdRSTtFASHxcETdDbjVyLvSqhfHA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return uVdRSTtFASHxcETdDbjVyLvSqhfHA;
				}
			}

			[DebuggerHidden]
			public sKGBWDyScawkIUgNFwJXCWWtjZSU(int P_0)
			{
				XNzjJqTRDsRYIhfFtRprggLRkhrX = P_0;
				shRfDQMWeSDSFmClIGLTrkjmUbJe = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int xNzjJqTRDsRYIhfFtRprggLRkhrX = XNzjJqTRDsRYIhfFtRprggLRkhrX;
				UserData userData = zKteTjYdZkAHidjtCPVYYbdLYlVv;
				if (xNzjJqTRDsRYIhfFtRprggLRkhrX != 0)
				{
					if (xNzjJqTRDsRYIhfFtRprggLRkhrX != 1)
					{
						return false;
					}
					XNzjJqTRDsRYIhfFtRprggLRkhrX = -1;
					goto IL_0070;
				}
				XNzjJqTRDsRYIhfFtRprggLRkhrX = -1;
				if (userData.mapCategories == null)
				{
					return false;
				}
				SvFRVCxFYRrUOfYWhrHzYUWRpqxE = 0;
				goto IL_0080;
				IL_0080:
				if (SvFRVCxFYRrUOfYWhrHzYUWRpqxE < userData.mapCategories.Count)
				{
					if (userData.mapCategories[SvFRVCxFYRrUOfYWhrHzYUWRpqxE].userAssignable)
					{
						uVdRSTtFASHxcETdDbjVyLvSqhfHA = userData.mapCategories[SvFRVCxFYRrUOfYWhrHzYUWRpqxE];
						XNzjJqTRDsRYIhfFtRprggLRkhrX = 1;
						return true;
					}
					goto IL_0070;
				}
				return false;
				IL_0070:
				SvFRVCxFYRrUOfYWhrHzYUWRpqxE++;
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
				sKGBWDyScawkIUgNFwJXCWWtjZSU sKGBWDyScawkIUgNFwJXCWWtjZSU2;
				if (XNzjJqTRDsRYIhfFtRprggLRkhrX == -2 && shRfDQMWeSDSFmClIGLTrkjmUbJe == Environment.CurrentManagedThreadId)
				{
					XNzjJqTRDsRYIhfFtRprggLRkhrX = 0;
					sKGBWDyScawkIUgNFwJXCWWtjZSU2 = this;
				}
				else
				{
					sKGBWDyScawkIUgNFwJXCWWtjZSU2 = new sKGBWDyScawkIUgNFwJXCWWtjZSU(0);
					sKGBWDyScawkIUgNFwJXCWWtjZSU2.zKteTjYdZkAHidjtCPVYYbdLYlVv = zKteTjYdZkAHidjtCPVYYbdLYlVv;
				}
				return sKGBWDyScawkIUgNFwJXCWWtjZSU2;
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
		private List<InputAction> oFmkOkdmHmIMScRgIHVyenuEvBNbc;

		[NonSerialized]
		private bool kvASzcESPfmObWvxQxpPZCxUOJEF;

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

		internal IList<Player_Editor> RsZazJyYPNugVeFNMaHRGPaHgKVT
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

		internal IList<InputAction> WeqHLeVbbIgIHnwAuHHBAYCCEWfK
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

		internal IList<InputCategory> CPdUaLyUPxRDERAVzytFodNwfogbA
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

		internal IList<InputBehavior> BwVLvqyvbefVydNmpeEFfPjMdharA
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

		internal IList<InputMapCategory> zjvLfOagottnMWWpDdziNFuLUWue
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

		internal IList<InputLayout> jnBjdsmCJfKdamrrgpehBFRAYCEY
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

		internal IList<InputLayout> VJownyunvtuwYrsMnuBxtPTujAvT
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

		internal IList<InputLayout> KdoYsIOYnUIuBuRPcmGeOlsdbRFE
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

		internal IList<InputLayout> RidNSlOJEffwHGQAxCFRhanGkjNl
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

		internal IList<ControllerMap_Editor> OqQHpFZNoegsGflwRwHUdSkXEeBG
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

		internal IList<ControllerMap_Editor> uqVAghDHLnpIERCpzhEVfpnaEjJWA
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

		internal IList<ControllerMap_Editor> LBbyfFWrfQCcBcJPdkIoGlgrwVJE
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

		internal IList<ControllerMap_Editor> JMpeRYFRIxXzqDGnxEAztuyeZQIt
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

		internal IList<ControllerMapLayoutManager_RuleSet_Editor> lkDskxBSXxOEwXZlmYVVtrOkIaGG
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

		internal IList<ControllerMapEnabler_RuleSet_Editor> KxUMSKMWUDBlBNIWaEsWzWQUCIPKA
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

		internal IEnumerable<InputMapCategory> xOsvgDsqBXTyZYWcOKaTpDFIzxjF
		{
			[IteratorStateMachine(typeof(sKGBWDyScawkIUgNFwJXCWWtjZSU))]
			get
			{
				return new sKGBWDyScawkIUgNFwJXCWWtjZSU(-2)
				{
					zKteTjYdZkAHidjtCPVYYbdLYlVv = this
				};
			}
		}

		internal IEnumerable<InputCategory> ZBXjztcovFyzyGvuMShUvlMeqWGd
		{
			[IteratorStateMachine(typeof(JAHqCqizBLFgpILklcNpjSpCoibK))]
			get
			{
				return new JAHqCqizBLFgpILklcNpjSpCoibK(-2)
				{
					NavJjqmKySOAjeLVDbJucAoMiBMcb = this
				};
			}
		}

		internal IEnumerable<InputAction> RkwdTdaSsmuUEqeoaiDjicPtfghuA
		{
			[IteratorStateMachine(typeof(sEZpQdMEmAMQPlZHveHtukAYpkVX))]
			get
			{
				return new sEZpQdMEmAMQPlZHveHtukAYpkVX(-2)
				{
					peZyVmrkfUYGfHRDDPUQXsBKpIvP = this
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

		private List<InputAction> cnjJGampiqifPHPSycEOPktSoDLW
		{
			get
			{
				if (!ReInput.isReady)
				{
					return actions;
				}
				return oFmkOkdmHmIMScRgIHVyenuEvBNbc;
			}
		}

		[IteratorStateMachine(typeof(nZBeTyFoIKSKKJdaNNAyGJgAQtytA))]
		internal IEnumerable<InputMapCategory> brhCYlltEvAbixJVTrZwuHflaldQ(string P_0)
		{
			return new nZBeTyFoIKSKKJdaNNAyGJgAQtytA(-2)
			{
				DKsCtfAuhnjbBjwmZCuGbhqEacmec = this,
				ZiFViymADakXcRaiMlQMQSpKfJXS = P_0
			};
		}

		[IteratorStateMachine(typeof(uSuiiMbnfzEtEpZFJHHJHEkrekmJ))]
		internal IEnumerable<InputMapCategory> whdesFibbOmkXbeXlTVBejPJZorAc(string P_0)
		{
			return new uSuiiMbnfzEtEpZFJHHJHEkrekmJ(-2)
			{
				ezvecXhFkUhDELeaYHpqzhmZXgNV = this,
				ueyTMYIYwWqtsOjdNZloeGovjWhi = P_0
			};
		}

		[IteratorStateMachine(typeof(ccxikuJtxBjGQUmAoJxtiwRIGVejA))]
		internal IEnumerable<InputCategory> AYBcIgYQuyAzofBXYpInDllAozDL(string P_0)
		{
			return new ccxikuJtxBjGQUmAoJxtiwRIGVejA(-2)
			{
				LzNKUbHYFJeaSVqijEHYHUCwVcVdA = this,
				SkmueWwCcobqNCWUzECnMeFptzvk = P_0
			};
		}

		[IteratorStateMachine(typeof(ongxWBQbKYOtBQOzcgzsaNHxmDmw))]
		internal IEnumerable<InputCategory> ywodJmeRSVDPTKTookJBkJIBgiIn(string P_0)
		{
			return new ongxWBQbKYOtBQOzcgzsaNHxmDmw(-2)
			{
				JaBZekmsaINEVquXmaxggtoFmFuT = this,
				PuQKOTeIgmdojEinpiJLvjLeMKSE = P_0
			};
		}

		[IteratorStateMachine(typeof(nbkTGUcxTWMpNnDqSBpxhdWWdvovA))]
		internal IEnumerable<InputAction> ykITMqpVIMgtcredTnSUDPHcqgQb(int P_0, bool P_1)
		{
			return new nbkTGUcxTWMpNnDqSBpxhdWWdvovA(-2)
			{
				JONsKYahGEBeLBMojEoGyQMiIZJe = this,
				isLinvpgjwMQUAREBTliaUYZOLdJ = P_0,
				EFotEXBdZdxezloLxxIIniAuGxyn = P_1
			};
		}

		[IteratorStateMachine(typeof(WiEUdZxsTCVQlLgmPrWOdzeoUpgG))]
		internal IEnumerable<InputAction> AXgNZSXzzyNhazxBImQvpYSsTjAR(string P_0, bool P_1)
		{
			return new WiEUdZxsTCVQlLgmPrWOdzeoUpgG(-2)
			{
				KYwlhzObMIIPmSLUKfBAlGTEBADkA = this,
				jBmhueEvZFRxmOPiNiPLXtrKQIuoA = P_0,
				HglHArewLziRExGRFADWSPcsrvyu = P_1
			};
		}

		[IteratorStateMachine(typeof(TIBADBQcHIsLjfoUKSBogRrfNjjd))]
		internal IEnumerable<InputAction> tDEaGuQLrXPNsDeNvMgebEiYbUUz(string P_0)
		{
			return new TIBADBQcHIsLjfoUKSBogRrfNjjd(-2)
			{
				dwfulrnFiZsOhsjMeYyBooIIGHEg = this,
				cMESNqqlIFhsxgxfAJGjxchCgSeCb = P_0
			};
		}

		[IteratorStateMachine(typeof(LjLHnMfPhupUmNVnLubslVkvYnSb))]
		internal IEnumerable<InputAction> TdWBFrIVFPWlZJksvkeJauncpGgX(int P_0, bool P_1)
		{
			return new LjLHnMfPhupUmNVnLubslVkvYnSb(-2)
			{
				yRsvDhkHdlknBSQzcZTdOWyuZpUg = this,
				ZKcshmBbWGtZsBYdNRvYVvrDjMpV = P_0,
				nUBckFFQLTKVPGBQtQvdEyzBwyplb = P_1
			};
		}

		[IteratorStateMachine(typeof(QiLxGUamMmqtUMCqOUphTYnQRcGJ))]
		internal IEnumerable<InputAction> eFQQMVotetlfOGzDlMcVfObGYVpN(string P_0, bool P_1)
		{
			return new QiLxGUamMmqtUMCqOUphTYnQRcGJ(-2)
			{
				pPMtZaOugfZJmaCYQhgysXyuMUSr = this,
				CAybnosVfdYIdchLKMcUAeeeBNor = P_0,
				cSJThbcavFlaUpKKzFTyWqrxJqCt = P_1
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
				Player_Editor player_Editor = eQjPIDEJSqgXidRiXahvkwbLavzV();
				player_Editor.name = "System";
				player_Editor.descriptiveName = player_Editor.name;
				player_Editor.key = "system_player";
				player_Editor.id = 9999999;
				player_Editor.startPlaying = true;
				player_Editor.assignMouseOnStart = true;
				player_Editor.assignKeyboardOnStart = true;
				player_Editor.excludeFromControllerAutoAssignment = true;
				players.Add(player_Editor);
				InputActionCategory inputActionCategory = WqsqueMQMMXetzlisuiylxzxqwoJ();
				inputActionCategory.name = "Default";
				inputActionCategory.descriptiveName = inputActionCategory.name;
				actionCategories.Add(inputActionCategory);
				actionCategoryMap.AddCategory(inputActionCategory.id);
				InputBehavior inputBehavior = xFjDgxdxKLCsEEKcFeWqlFnggweEe();
				inputBehavior.name = "Default";
				inputBehaviors.Add(inputBehavior);
				InputMapCategory inputMapCategory = aBxZjmKTXdzFHzoLDjPnTUhgFNVe();
				inputMapCategory.name = "Default";
				inputMapCategory.descriptiveName = inputMapCategory.name;
				mapCategories.Add(inputMapCategory);
				InputLayout inputLayout = QgOmxqltkZaEqzKSbQcRfIrZGLmBA();
				inputLayout.name = "Default";
				inputLayout.descriptiveName = inputLayout.name;
				joystickLayouts.Add(inputLayout);
				InputLayout inputLayout2 = BAUUnLtMfYuLMivesMTJVkiWDvTz();
				inputLayout2.name = "Default";
				inputLayout2.descriptiveName = inputLayout2.name;
				keyboardLayouts.Add(inputLayout2);
				InputLayout inputLayout3 = hyAbywDeVYrSGbzBBvOnFFGDltEyA();
				inputLayout3.name = "Default";
				inputLayout3.descriptiveName = inputLayout3.name;
				mouseLayouts.Add(inputLayout3);
				InputLayout inputLayout4 = fnZQoBJZGLKnSZZLDmhgTOBtVUtq();
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
			for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
			{
				list.Add(cnjJGampiqifPHPSycEOPktSoDLW[i]);
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
				KeyboardMap item = keyboardMaps[i].YROfdGTAIjtRoiwcEINMYpqcwCpJ(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public List<MouseMap> GetMouseMaps_Copy()
		{
			List<MouseMap> list = new List<MouseMap>();
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				MouseMap item = mouseMaps[i].GXxRaZrloxhXlGJlrUTMvMvifSCz(containsActionDelegate);
				list.Add(item);
			}
			return list;
		}

		public void AddPlayer()
		{
			players.Add(eQjPIDEJSqgXidRiXahvkwbLavzV());
		}

		public void InsertPlayer(int index)
		{
			if (index < 0 || index >= players.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			players.Insert(index, eQjPIDEJSqgXidRiXahvkwbLavzV());
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
			InputAction inputAction = FIIphlUKfQZVVUtmSKNFQbHLclVI();
			inputAction.categoryId = categoryId;
			cnjJGampiqifPHPSycEOPktSoDLW.Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
		}

		public void InsertAction(int categoryId, int actionId)
		{
			if (cnjJGampiqifPHPSycEOPktSoDLW != null)
			{
				InputAction inputAction = FIIphlUKfQZVVUtmSKNFQbHLclVI();
				inputAction.categoryId = categoryId;
				cnjJGampiqifPHPSycEOPktSoDLW.Add(inputAction);
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
					cnjJGampiqifPHPSycEOPktSoDLW.RemoveAt(num);
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
			if (num == cnjJGampiqifPHPSycEOPktSoDLW.Count - 1)
			{
				cnjJGampiqifPHPSycEOPktSoDLW.Add(inputAction);
				actionCategoryMap.AddAction(categoryId, inputAction.id);
				return cnjJGampiqifPHPSycEOPktSoDLW.Count - 1;
			}
			cnjJGampiqifPHPSycEOPktSoDLW.Insert(num + 1, inputAction);
			int num2 = actionCategoryMap.IndexOfAction(categoryId, actionId);
			actionCategoryMap.InsertAction(categoryId, inputAction.id, num2 + 1);
			return num + 1;
		}

		private int mXExVwYdegoFmGfTlYGKCRzKAmRN(int P_0, InputAction P_1)
		{
			if (IndexOfActionCategory(P_0) < 0)
			{
				return -1;
			}
			InputAction inputAction = P_1.Clone();
			inputAction.id = GetNewActionId();
			inputAction.name = StringTools.IterateName(inputAction.name, -1, GetActionNames());
			cnjJGampiqifPHPSycEOPktSoDLW.Add(inputAction);
			return cnjJGampiqifPHPSycEOPktSoDLW.Count - 1;
		}

		public string[] GetActionNames()
		{
			if (cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return null;
			}
			string[] array = new string[cnjJGampiqifPHPSycEOPktSoDLW.Count];
			for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
			{
				array[i] = cnjJGampiqifPHPSycEOPktSoDLW[i].name;
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
			if (cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return 0;
			}
			for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
			{
				results.Add(cnjJGampiqifPHPSycEOPktSoDLW[i].name);
			}
			return results.Count;
		}

		public int[] GetActionIds()
		{
			if (cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return null;
			}
			int[] array = new int[cnjJGampiqifPHPSycEOPktSoDLW.Count];
			for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
			{
				array[i] = cnjJGampiqifPHPSycEOPktSoDLW[i].id;
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
			if (cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return 0;
			}
			for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
			{
				results.Add(cnjJGampiqifPHPSycEOPktSoDLW[i].id);
			}
			return results.Count;
		}

		public string GetActionNameById(int id)
		{
			if (cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
			{
				if (cnjJGampiqifPHPSycEOPktSoDLW[i].id == id)
				{
					return cnjJGampiqifPHPSycEOPktSoDLW[i].name;
				}
			}
			return string.Empty;
		}

		public InputAction GetAction(int index)
		{
			if (cnjJGampiqifPHPSycEOPktSoDLW == null || index < 0 || index >= cnjJGampiqifPHPSycEOPktSoDLW.Count)
			{
				return null;
			}
			return cnjJGampiqifPHPSycEOPktSoDLW[index];
		}

		public InputAction GetAction(string name)
		{
			if (cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return null;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return null;
			}
			return cnjJGampiqifPHPSycEOPktSoDLW[num];
		}

		public InputAction GetActionById(int id)
		{
			if (cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return null;
			}
			for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
			{
				if (cnjJGampiqifPHPSycEOPktSoDLW[i].id == id)
				{
					return cnjJGampiqifPHPSycEOPktSoDLW[i];
				}
			}
			return null;
		}

		public int GetActionId(string name)
		{
			if (cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return -1;
			}
			int num = IndexOfAction(name);
			if (num < 0)
			{
				return -1;
			}
			return cnjJGampiqifPHPSycEOPktSoDLW[num].id;
		}

		public string[] GetSortedActionNamesInCategory(int id)
		{
			if (actionCategories == null || cnjJGampiqifPHPSycEOPktSoDLW == null)
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

		[IteratorStateMachine(typeof(MUZTeBAeUtAnQDntvHfVtQaTDoxgb))]
		public IEnumerable<string> SortedActionNamesInCategory(int id)
		{
			return new MUZTeBAeUtAnQDntvHfVtQaTDoxgb(-2)
			{
				QByTMhAUcUneQadsVdwPCoEvIUPp = this,
				exaJuyJlJqyWMiZqbahuqFLrSiJL = id
			};
		}

		public string[] GetSortedActionDescriptiveNamesInCategory(int id)
		{
			if (actionCategories == null || cnjJGampiqifPHPSycEOPktSoDLW == null)
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

		[IteratorStateMachine(typeof(MzMaUhPRunGBnyKjqCoVyUmzDoAC))]
		public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
		{
			return new MzMaUhPRunGBnyKjqCoVyUmzDoAC(-2)
			{
				zHFMpQPAMsEqkxUsyKOXNlBUinhg = this,
				lFHGqHSJKIqDmINzEZaQBPmRwsyM = id
			};
		}

		public int[] GetSortedActionIdsInCategory(int id)
		{
			if (actionCategories == null || cnjJGampiqifPHPSycEOPktSoDLW == null)
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

		[IteratorStateMachine(typeof(CbAQPHOEGCQXfCCBVIfqMmtGBDEAA))]
		public IEnumerable<int> SortedActionIdsInCategory(int id)
		{
			return new CbAQPHOEGCQXfCCBVIfqMmtGBDEAA(-2)
			{
				bDdORuwPNTXFTSWCBMmHpACEAoEu = this,
				yjCvsolXqTQDBMULgAidoBssZlIN = id
			};
		}

		public bool ContainsAction(int id)
		{
			return IndexOfAction(id) >= 0;
		}

		public int IndexOfAction(int id)
		{
			if (cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return -1;
			}
			for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
			{
				if (cnjJGampiqifPHPSycEOPktSoDLW[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOfAction(string name)
		{
			if (cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return -1;
			}
			if (name == null || name == string.Empty)
			{
				return -1;
			}
			for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
			{
				if (cnjJGampiqifPHPSycEOPktSoDLW[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					return i;
				}
			}
			return -1;
		}

		public void AddActionCategory()
		{
			InputActionCategory inputActionCategory = WqsqueMQMMXetzlisuiylxzxqwoJ();
			actionCategories.Add(inputActionCategory);
			actionCategoryMap.AddCategory(inputActionCategory.id);
		}

		public void InsertActionCategory(int index)
		{
			if (index < 0 || index >= actionCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			InputActionCategory inputActionCategory = WqsqueMQMMXetzlisuiylxzxqwoJ();
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
			if (cnjJGampiqifPHPSycEOPktSoDLW != null)
			{
				for (int num = cnjJGampiqifPHPSycEOPktSoDLW.Count - 1; num >= 0; num--)
				{
					if (cnjJGampiqifPHPSycEOPktSoDLW[num].categoryId == id)
					{
						cnjJGampiqifPHPSycEOPktSoDLW.RemoveAt(num);
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
			if (!duplicateActions || cnjJGampiqifPHPSycEOPktSoDLW == null)
			{
				return;
			}
			int id = inputActionCategory.id;
			int id2 = actionCategories[index].id;
			List<int> list = new List<int>();
			for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
			{
				if (cnjJGampiqifPHPSycEOPktSoDLW[i].categoryId == id2)
				{
					list.Add(i);
				}
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>(list.Count);
			for (int j = 0; j < list.Count; j++)
			{
				InputAction inputAction = cnjJGampiqifPHPSycEOPktSoDLW[list[j]];
				int num = mXExVwYdegoFmGfTlYGKCRzKAmRN(id2, inputAction);
				if (num >= 0)
				{
					InputAction inputAction2 = cnjJGampiqifPHPSycEOPktSoDLW[num];
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
			if (num >= 0 && cnjJGampiqifPHPSycEOPktSoDLW[num].categoryId != newCategoryId)
			{
				actionCategoryMap.ChangeCategory(actionId, newCategoryId);
				cnjJGampiqifPHPSycEOPktSoDLW[num].categoryId = newCategoryId;
			}
		}

		public int GetActionCategoryCount(int id)
		{
			if (actionCategories == null)
			{
				return 0;
			}
			int num = 0;
			if (cnjJGampiqifPHPSycEOPktSoDLW != null)
			{
				for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
				{
					if (cnjJGampiqifPHPSycEOPktSoDLW[i].categoryId == id)
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
			inputBehaviors.Add(xFjDgxdxKLCsEEKcFeWqlFnggweEe());
		}

		public void InsertInputBehavior(int index)
		{
			if (index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			inputBehaviors.Insert(index, xFjDgxdxKLCsEEKcFeWqlFnggweEe());
		}

		public void DeleteInputBehavior(int index)
		{
			if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int id = inputBehaviors[index].id;
			if (cnjJGampiqifPHPSycEOPktSoDLW != null)
			{
				for (int i = 0; i < cnjJGampiqifPHPSycEOPktSoDLW.Count; i++)
				{
					if (cnjJGampiqifPHPSycEOPktSoDLW[i].behaviorId == id)
					{
						cnjJGampiqifPHPSycEOPktSoDLW[i].behaviorId = 0;
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
			mapCategories.Add(aBxZjmKTXdzFHzoLDjPnTUhgFNVe());
		}

		public void InsertMapCategory(int index)
		{
			if (index < 0 || index >= mapCategories.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mapCategories.Insert(index, aBxZjmKTXdzFHzoLDjPnTUhgFNVe());
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
				Action<List<Player_Editor.Mapping>, int> action = NvjHouyFkXhoVwtyYCVAdiHxfUEA._003C_003E9.DMZkQfJRKVAxNOqLPBdFCJdEvvtn;
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
			joystickLayouts.Add(QgOmxqltkZaEqzKSbQcRfIrZGLmBA());
		}

		public void InsertJoystickLayout(int index)
		{
			if (index < 0 || index >= joystickLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			joystickLayouts.Insert(index, QgOmxqltkZaEqzKSbQcRfIrZGLmBA());
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
				Action<List<Player_Editor.Mapping>, int> action = NvjHouyFkXhoVwtyYCVAdiHxfUEA._003C_003E9.dAwpDaSETBfLBeHJymFXBNxtYNffA;
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
			keyboardLayouts.Add(BAUUnLtMfYuLMivesMTJVkiWDvTz());
		}

		public void InsertKeyboardLayout(int index)
		{
			if (index < 0 || index >= keyboardLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			keyboardLayouts.Insert(index, BAUUnLtMfYuLMivesMTJVkiWDvTz());
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
				Action<List<Player_Editor.Mapping>, int> action = NvjHouyFkXhoVwtyYCVAdiHxfUEA._003C_003E9.tKnxVGDCJCGcTOseiRvvcraKEcYH;
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
			mouseLayouts.Add(hyAbywDeVYrSGbzBBvOnFFGDltEyA());
		}

		public void InsertMouseLayout(int index)
		{
			if (index < 0 || index >= mouseLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			mouseLayouts.Insert(index, hyAbywDeVYrSGbzBBvOnFFGDltEyA());
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
				Action<List<Player_Editor.Mapping>, int> action = NvjHouyFkXhoVwtyYCVAdiHxfUEA._003C_003E9.KdHnDtQCsBIurBmxDtEpMOktBfFGA;
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
			customControllerLayouts.Add(fnZQoBJZGLKnSZZLDmhgTOBtVUtq());
		}

		public void InsertCustomControllerLayout(int index)
		{
			if (index < 0 || index >= customControllerLayouts.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			customControllerLayouts.Insert(index, fnZQoBJZGLKnSZZLDmhgTOBtVUtq());
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
				Action<List<Player_Editor.Mapping>, int> action = NvjHouyFkXhoVwtyYCVAdiHxfUEA._003C_003E9.eeHzRLINeHSWMtZalAOtEhZcFfix;
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

		internal ControllerMap gpTdgMWdIjjfKTDdirChMNOgXGTB(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Joystick => xDZwXbEkVZRakTvMLrpwClMerKHh((Joystick)P_0, P_1, P_2), 
				ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
				ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
				ControllerType.Custom => KXAiRfDQanCwvlzzVuoqYkPCLMYm(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
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

		internal JoystickMap FsSixdhmefXtbeXeRCdQMdHnbsXb(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			return IgXZAJDWFHyYAsOBSxKBWkvpApxl(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
		}

		internal JoystickMap xDZwXbEkVZRakTvMLrpwClMerKHh(Joystick P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return IgXZAJDWFHyYAsOBSxKBWkvpApxl(P_0.LzsnegTLQWBrmlNOuxzsmKwkuQvn, P_1, P_2);
		}

		private JoystickMap IgXZAJDWFHyYAsOBSxKBWkvpApxl(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
		{
			Guid guid = P_0.guid;
			HardwareJoystickMap hardwareJoystickMap = ReInput.qkTHQiTDunCNmEArTSopkNQhEEJOA(guid);
			ControllerMap_Editor controllerMap_Editor = mIylPrNurBJeeNHyFFwrpVJcTaHF(P_1, guid, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.XPfAnzHTbqwKcKbBUJQlpnMiMSnpA(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.XTpYHeGcBlGFaDvKiULEiPImeNLK(guid, P_1, P_2);
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
					HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.ybfHyZdOwUYBOlroeLxodrHdUXLSA(templateGuid);
					if (!(hardwareJoystickTemplateMap != null))
					{
						continue;
					}
					controllerMap_Editor = mIylPrNurBJeeNHyFFwrpVJcTaHF(P_1, templateGuid, P_2, false);
					if (controllerMap_Editor != null)
					{
						JoystickMap joystickMap = vWMFFliTxDUaLCEYVbCcBOyOTQKdb(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
						if (joystickMap != null)
						{
							joystickMap.XTpYHeGcBlGFaDvKiULEiPImeNLK(guid, P_1, P_2);
							return joystickMap;
						}
					}
				}
			}
			if (guid == Guid.Empty || 1 == 0)
			{
				controllerMap_Editor = mIylPrNurBJeeNHyFFwrpVJcTaHF(P_1, Guid.Empty, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = controllerMap_Editor.XPfAnzHTbqwKcKbBUJQlpnMiMSnpA(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
					joystickMap.XTpYHeGcBlGFaDvKiULEiPImeNLK(guid, P_1, P_2);
					if (joystickMap != null)
					{
						return joystickMap;
					}
				}
			}
			return JoystickMap.FfZldRzgvSdPWmHQzEEUzcZhYDeA(guid, P_1, P_2);
		}

		private ControllerMap_Editor mIylPrNurBJeeNHyFFwrpVJcTaHF(int P_0, Guid P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
			if (P_3)
			{
				joystickMap = DkaIfKAtJmknDlPGhQAbYoUgPJgH(P_0, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor DkaIfKAtJmknDlPGhQAbYoUgPJgH(int P_0, Guid P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
			if (list != null && list.Count > 0)
			{
				akaDbSNbGCIuzajxVAtgYtdyOCuh(list, joystickLayouts);
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

		private JoystickMap vWMFFliTxDUaLCEYVbCcBOyOTQKdb(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
		{
			if (P_2 == null)
			{
				return null;
			}
			ControllerMap_Editor controllerMap_Editor = P_1.Clone();
			if (!P_2.qUXgnBaKyMbezYjknJFiicDQsjl(controllerMap_Editor, P_3, P_0.guid, out var text))
			{
				Logger.LogError("Error remapping joystick template " + P_2.Guid.ToString() + " to joystick " + P_0.guid.ToString() + "\nReason: " + text);
				return null;
			}
			return controllerMap_Editor.XPfAnzHTbqwKcKbBUJQlpnMiMSnpA(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
		}

		private JoystickMap PCEjkScmdLNavaMMaVvlhReFTdpg(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
		{
			if (P_0 == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap = ReInput.qkTHQiTDunCNmEArTSopkNQhEEJOA(P_0.hardwareGuid);
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			HardwareJoystickMap hardwareJoystickMap2 = ReInput.qkTHQiTDunCNmEArTSopkNQhEEJOA(Guid.Empty);
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
				list.Add(allMap.xYazCGhLJSNpewHjYMCgVGmvJCJk);
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
			ControllerMap_Editor controllerMap_Editor = tMMIBzBugtcAKmSgUkkJpGDBQWjP(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
			KeyboardMap keyboardMap;
			if (controllerMap_Editor != null)
			{
				keyboardMap = controllerMap_Editor.YROfdGTAIjtRoiwcEINMYpqcwCpJ(containsActionDelegate);
				keyboardMap.wlIBqldtkdkAYbZRTmwAzXJvVMWlA(keyboard.lcQyDEaPLwhlbiUKrOtQaptBTwRjc, categoryId, layoutId);
			}
			else
			{
				keyboardMap = KeyboardMap.VAEnbEnWtHBalrdrrAWtkeGcduIdA(keyboard.lcQyDEaPLwhlbiUKrOtQaptBTwRjc, categoryId, layoutId);
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
			ControllerMap_Editor controllerMap_Editor = tMMIBzBugtcAKmSgUkkJpGDBQWjP(mouseMaps, mouseLayouts, categoryId, layoutId, false);
			MouseMap mouseMap;
			if (controllerMap_Editor != null)
			{
				mouseMap = controllerMap_Editor.GXxRaZrloxhXlGJlrUTMvMvifSCz(containsActionDelegate);
				mouseMap.TgwdJmHKoJwyrESMJmpUgFWHojpoB(mouse.lcQyDEaPLwhlbiUKrOtQaptBTwRjc, categoryId, layoutId);
			}
			else
			{
				mouseMap = MouseMap.HsWpYztryjDgjTsaGEGyAuWhNivW(mouse.lcQyDEaPLwhlbiUKrOtQaptBTwRjc, categoryId, layoutId);
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

		internal CustomControllerMap VUEGkVdxebQlmPeRVmAAMgTFLROKA(Guid P_0, int P_1, int P_2)
		{
			return IhhEareNFgsOjORdLCfddBHxaniGb(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
		}

		internal CustomControllerMap KXAiRfDQanCwvlzzVuoqYkPCLMYm(int P_0, int P_1, int P_2)
		{
			return IhhEareNFgsOjORdLCfddBHxaniGb(GetCustomControllerById(P_1), P_0, P_2);
		}

		private CustomControllerMap IhhEareNFgsOjORdLCfddBHxaniGb(CustomController_Editor P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			int id = P_0.id;
			ControllerMap_Editor controllerMap_Editor = jGnPtYQSCmKUFbhRBIRBEpepcFwU(P_1, id, P_2, false);
			if (controllerMap_Editor != null)
			{
				CustomControllerMap customControllerMap = controllerMap_Editor.YDaqTJeQMHMyicyZPeUHIenjsbym(ContainsAction, P_0);
				customControllerMap.LjeArvcYCmRMpfvMaoswgaDMorho(P_0.typeGuid, id, P_1, P_2);
				return customControllerMap;
			}
			CustomControllerMap customControllerMap2 = CustomControllerMap.MVHnYJGaDhkxSLeIEDskEDGaPFUOA(P_0.typeGuid, id, P_1, P_2);
			customControllerMap2.LjeArvcYCmRMpfvMaoswgaDMorho(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap2;
		}

		private ControllerMap_Editor jGnPtYQSCmKUFbhRBIRBEpepcFwU(int P_0, int P_1, int P_2, bool P_3)
		{
			ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
			if (P_3)
			{
				customControllerMap = DMURBEhXFsjmYgmHDxgMLhfsUTcf(P_0, P_1, P_2);
				if (customControllerMap != null)
				{
					return customControllerMap;
				}
			}
			return null;
		}

		private ControllerMap_Editor DMURBEhXFsjmYgmHDxgMLhfsUTcf(int P_0, int P_1, int P_2)
		{
			List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
			if (list != null && list.Count > 0)
			{
				akaDbSNbGCIuzajxVAtgYtdyOCuh(list, customControllerLayouts);
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

		internal ControllerTemplateMap DHthsvsHDYAzJCbSfokDMgqdJYkJ(Guid P_0, int P_1, int P_2)
		{
			return GetJoystickMap(P_1, P_0, P_2)?.LkYMwKszEBuhkSxcNHTWOqDWWSGP();
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
			customControllers.Add(wfQLoTjmpzwOPrGBGBDuayElkzOT(typeGuid));
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
			customControllers.Insert(index, wfQLoTjmpzwOPrGBGBDuayElkzOT(typeGuid));
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
			controllerMapLayoutManagerRuleSets.Add(BSaWOmigrjxGrtFidUObHQmIrCtw());
		}

		public void InsertControllerMapLayoutManagerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapLayoutManagerRuleSets.Insert(index, BSaWOmigrjxGrtFidUObHQmIrCtw());
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
			controllerMapEnablerRuleSets.Add(KQAlpcnkbPXYKWBYPMfdXyHYuCru());
		}

		public void InsertControllerMapEnablerRuleSet(int index)
		{
			if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			controllerMapEnablerRuleSets.Insert(index, KQAlpcnkbPXYKWBYPMfdXyHYuCru());
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

		private Player_Editor eQjPIDEJSqgXidRiXahvkwbLavzV()
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

		private InputAction FIIphlUKfQZVVUtmSKNFQbHLclVI()
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

		private InputActionCategory WqsqueMQMMXetzlisuiylxzxqwoJ()
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

		private InputBehavior xFjDgxdxKLCsEEKcFeWqlFnggweEe()
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

		private InputMapCategory aBxZjmKTXdzFHzoLDjPnTUhgFNVe()
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

		private InputLayout QgOmxqltkZaEqzKSbQcRfIrZGLmBA()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewJoystickLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetJoystickLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout BAUUnLtMfYuLMivesMTJVkiWDvTz()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewKeyboardLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout hyAbywDeVYrSGbzBBvOnFFGDltEyA()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewMouseLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetMouseLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private InputLayout fnZQoBJZGLKnSZZLDmhgTOBtVUtq()
		{
			InputLayout obj = new InputLayout
			{
				id = GetNewCustomControllerLayoutId(),
				name = StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames())
			};
			obj.descriptiveName = obj.name;
			return obj;
		}

		private CustomController_Editor wfQLoTjmpzwOPrGBGBDuayElkzOT(Guid P_0)
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

		private ControllerMapLayoutManager_RuleSet_Editor BSaWOmigrjxGrtFidUObHQmIrCtw()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor
			{
				id = GetNewControllerMapLayoutManagerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames())
			};
		}

		private ControllerMapEnabler_RuleSet_Editor KQAlpcnkbPXYKWBYPMfdXyHYuCru()
		{
			return new ControllerMapEnabler_RuleSet_Editor
			{
				id = GetNewControllerMapEnablerRuleSetId(),
				name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames())
			};
		}

		private ControllerMap_Editor aBioOLoMvwEDFDwhfbSGgpeViWIcA(List<ControllerMap_Editor> P_0, int P_1, int P_2)
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

		private ControllerMap_Editor tMMIBzBugtcAKmSgUkkJpGDBQWjP(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
		{
			ControllerMap_Editor controllerMap_Editor = aBioOLoMvwEDFDwhfbSGgpeViWIcA(P_0, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
			if (P_4)
			{
				controllerMap_Editor = GnaTqesvIhSfvDMjUFTtGPMAWgPS(P_0, P_1, P_2, P_3);
				if (controllerMap_Editor != null)
				{
					return controllerMap_Editor;
				}
			}
			return null;
		}

		private ControllerMap_Editor GnaTqesvIhSfvDMjUFTtGPMAWgPS(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
		{
			List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
			if (list != null && list.Count > 0)
			{
				akaDbSNbGCIuzajxVAtgYtdyOCuh(list, P_1);
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

		private void akaDbSNbGCIuzajxVAtgYtdyOCuh(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
		{
			utsKclqzMUiLLteMOFvlrYHbtvtI utsKclqzMUiLLteMOFvlrYHbtvtI2 = new utsKclqzMUiLLteMOFvlrYHbtvtI();
			utsKclqzMUiLLteMOFvlrYHbtvtI2.xXdmTDOpxFsJOXxZeTxfbvhGxzIC = P_1;
			if (P_0 != null && utsKclqzMUiLLteMOFvlrYHbtvtI2.xXdmTDOpxFsJOXxZeTxfbvhGxzIC != null)
			{
				P_0.Sort(utsKclqzMUiLLteMOFvlrYHbtvtI2.NhTtbkhoVTguWVGKqsDIqcDUFdSv);
			}
		}

		internal void yBqzMWUbfqGaCAVGykOEdZvydxhWA()
		{
			if (kvASzcESPfmObWvxQxpPZCxUOJEF)
			{
				return;
			}
			oFmkOkdmHmIMScRgIHVyenuEvBNbc = new List<InputAction>(actions.Count);
			for (int i = 0; i < actions.Count; i++)
			{
				if (actions[i] == null)
				{
					oFmkOkdmHmIMScRgIHVyenuEvBNbc.Add(null);
				}
				oFmkOkdmHmIMScRgIHVyenuEvBNbc.Add(new InputAction(actions[i]));
			}
			RsZazJyYPNugVeFNMaHRGPaHgKVT = new ReadOnlyCollection<Player_Editor>(players);
			WeqHLeVbbIgIHnwAuHHBAYCCEWfK = new ReadOnlyCollection<InputAction>(oFmkOkdmHmIMScRgIHVyenuEvBNbc);
			List<InputCategory> list = new List<InputCategory>((actionCategories != null) ? actionCategories.Count : 0);
			for (int j = 0; j < actionCategories.Count; j++)
			{
				list.Add(actionCategories[j]);
			}
			CPdUaLyUPxRDERAVzytFodNwfogbA = new ReadOnlyCollection<InputCategory>(list);
			BwVLvqyvbefVydNmpeEFfPjMdharA = new ReadOnlyCollection<InputBehavior>(inputBehaviors);
			zjvLfOagottnMWWpDdziNFuLUWue = new ReadOnlyCollection<InputMapCategory>(mapCategories);
			jnBjdsmCJfKdamrrgpehBFRAYCEY = new ReadOnlyCollection<InputLayout>(joystickLayouts);
			VJownyunvtuwYrsMnuBxtPTujAvT = new ReadOnlyCollection<InputLayout>(keyboardLayouts);
			KdoYsIOYnUIuBuRPcmGeOlsdbRFE = new ReadOnlyCollection<InputLayout>(mouseLayouts);
			RidNSlOJEffwHGQAxCFRhanGkjNl = new ReadOnlyCollection<InputLayout>(customControllerLayouts);
			OqQHpFZNoegsGflwRwHUdSkXEeBG = new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps);
			uqVAghDHLnpIERCpzhEVfpnaEjJWA = new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps);
			LBbyfFWrfQCcBcJPdkIoGlgrwVJE = new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps);
			JMpeRYFRIxXzqDGnxEAztuyeZQIt = new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps);
			lkDskxBSXxOEwXZlmYVVtrOkIaGG = new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets);
			KxUMSKMWUDBlBNIWaEsWzWQUCIPKA = new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets);
			if (mapCategories != null)
			{
				for (int k = 0; k < mapCategories.Count; k++)
				{
					if (mapCategories[k] != null)
					{
						mapCategories[k].SCZFJskqbhgaUMQdLhtpliFYOYAoA();
					}
				}
			}
			if (actionCategories != null)
			{
				for (int l = 0; l < actionCategories.Count; l++)
				{
					if (actionCategories[l] != null)
					{
						actionCategories[l].SCZFJskqbhgaUMQdLhtpliFYOYAoA();
					}
				}
			}
			if (joystickLayouts != null)
			{
				for (int m = 0; m < joystickLayouts.Count; m++)
				{
					if (joystickLayouts[m] != null)
					{
						joystickLayouts[m].eurMFZskNUorrhkDAbZqDHMBfTPb();
					}
				}
			}
			if (keyboardLayouts != null)
			{
				for (int n = 0; n < keyboardLayouts.Count; n++)
				{
					if (keyboardLayouts[n] != null)
					{
						keyboardLayouts[n].eurMFZskNUorrhkDAbZqDHMBfTPb();
					}
				}
			}
			if (mouseLayouts != null)
			{
				for (int num = 0; num < mouseLayouts.Count; num++)
				{
					if (mouseLayouts[num] != null)
					{
						mouseLayouts[num].eurMFZskNUorrhkDAbZqDHMBfTPb();
					}
				}
			}
			if (customControllerLayouts != null)
			{
				for (int num2 = 0; num2 < customControllerLayouts.Count; num2++)
				{
					if (customControllerLayouts[num2] != null)
					{
						customControllerLayouts[num2].eurMFZskNUorrhkDAbZqDHMBfTPb();
					}
				}
			}
			if (oFmkOkdmHmIMScRgIHVyenuEvBNbc != null)
			{
				for (int num3 = 0; num3 < oFmkOkdmHmIMScRgIHVyenuEvBNbc.Count; num3++)
				{
					if (oFmkOkdmHmIMScRgIHVyenuEvBNbc[num3] != null)
					{
						oFmkOkdmHmIMScRgIHVyenuEvBNbc[num3].MLesfYxEUrsbrQYFeMQuyjtUNGXM();
					}
				}
			}
			containsActionDelegate = ContainsAction;
			kvASzcESPfmObWvxQxpPZCxUOJEF = true;
		}

		internal void ZXvdcqdsNZSlLZBUVvStsrOKhLSS()
		{
			if (!kvASzcESPfmObWvxQxpPZCxUOJEF)
			{
				return;
			}
			if (mapCategories != null)
			{
				for (int i = 0; i < mapCategories.Count; i++)
				{
					if (mapCategories[i] != null)
					{
						mapCategories[i].mAqZoFXqnVcuPOeZjbIzJuWzIjtCA();
					}
				}
			}
			if (oFmkOkdmHmIMScRgIHVyenuEvBNbc != null)
			{
				for (int j = 0; j < oFmkOkdmHmIMScRgIHVyenuEvBNbc.Count; j++)
				{
					if (oFmkOkdmHmIMScRgIHVyenuEvBNbc[j] != null)
					{
						oFmkOkdmHmIMScRgIHVyenuEvBNbc[j].pvUSDzPtZBdveDYnfMxQusCNuIMm();
					}
				}
			}
			kvASzcESPfmObWvxQxpPZCxUOJEF = false;
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
		{
			return LSVRohvqGLufEzRsnpASzJwQVplX.XTZEeCaFhjTFVQzSvArFEilqXpYf(orig, other, preserveOrigIds);
		}

		[CustomObfuscation(rename = false)]
		internal static UserData Compact(UserData orig)
		{
			return LSVRohvqGLufEzRsnpASzJwQVplX.XTZEeCaFhjTFVQzSvArFEilqXpYf(orig, null, false);
		}
	}
}
