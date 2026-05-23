using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public sealed class InputMapper
	{
		public class Context
		{
			private int mecAvOSCkKTUzDMSKLpGqHuOJBZ = -1;

			private ControllerMap JdetZGSYAxuUPraClBlCSLMWOmU;

			private ActionElementMap ipcPpQHebCyxuIFYuOhfFscSDfr;

			private AxisRange ORRYCyGQPzowEtoVbQfooaVIMXi = AxisRange.Positive;

			private bool opqFCidZJywDAhKxeolcaVpqNEsC;

			public int actionId
			{
				get
				{
					return mecAvOSCkKTUzDMSKLpGqHuOJBZ;
				}
				set
				{
					if (mOrcqprUQEbTcotWIYrfFcPKnbe())
					{
						while (true)
						{
							switch (0x62778341 ^ 0x62778343)
							{
							case 0:
								continue;
							case 2:
								return;
							}
							break;
						}
					}
					mecAvOSCkKTUzDMSKLpGqHuOJBZ = value;
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(mecAvOSCkKTUzDMSKLpGqHuOJBZ);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (mOrcqprUQEbTcotWIYrfFcPKnbe())
					{
						return;
					}
					while (true)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						int num;
						if (action == null)
						{
							mecAvOSCkKTUzDMSKLpGqHuOJBZ = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
							num = -1701299603;
							goto IL_000e;
						}
						goto IL_0061;
						IL_000e:
						while (true)
						{
							switch (num ^ -1701299607)
							{
							case 3:
								num = -1701299608;
								continue;
							default:
								return;
							case 1:
								break;
							case 2:
								goto IL_0061;
							case 4:
								return;
							case 0:
								return;
							}
							break;
						}
						continue;
						IL_0061:
						mecAvOSCkKTUzDMSKLpGqHuOJBZ = action.id;
						num = -1701299607;
						goto IL_000e;
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return JdetZGSYAxuUPraClBlCSLMWOmU;
				}
				set
				{
					if (!mOrcqprUQEbTcotWIYrfFcPKnbe())
					{
						JdetZGSYAxuUPraClBlCSLMWOmU = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return ipcPpQHebCyxuIFYuOhfFscSDfr;
				}
				set
				{
					if (!mOrcqprUQEbTcotWIYrfFcPKnbe())
					{
						ipcPpQHebCyxuIFYuOhfFscSDfr = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return ORRYCyGQPzowEtoVbQfooaVIMXi;
				}
				set
				{
					if (!mOrcqprUQEbTcotWIYrfFcPKnbe())
					{
						ORRYCyGQPzowEtoVbQfooaVIMXi = value;
					}
				}
			}

			public Context()
			{
			}

			private Context(Context source)
				: this()
			{
				while (true)
				{
					int num = 1672309911;
					while (true)
					{
						switch (num ^ 0x63AD6C96)
						{
						case 2:
							break;
						case 1:
						{
							int num2;
							if (source == null)
							{
								num = 1672309909;
								num2 = num;
							}
							else
							{
								num = 1672309910;
								num2 = num;
							}
							continue;
						}
						case 3:
							throw new ArgumentNullException("source");
						default:
							Copy(source, this);
							return;
						}
						break;
					}
				}
			}

			public Context Clone()
			{
				return new Context(this);
			}

			internal void lVOUSoXYpQJOYtyyJniiNkDHvOt()
			{
				opqFCidZJywDAhKxeolcaVpqNEsC = true;
			}

			private bool mOrcqprUQEbTcotWIYrfFcPKnbe()
			{
				if (opqFCidZJywDAhKxeolcaVpqNEsC)
				{
					Logger.LogError("Context is read-only and cannot be modified after Input Mapper has been started.");
					return true;
				}
				return false;
			}

			public static void Copy(Context source, Context destination)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				while (true)
				{
					int num;
					int num2;
					if (destination != null)
					{
						num = -1703396447;
						num2 = num;
					}
					else
					{
						num = -1703396441;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1703396444)
						{
						case 4:
							num = -1703396442;
							continue;
						case 5:
							destination.mecAvOSCkKTUzDMSKLpGqHuOJBZ = source.mecAvOSCkKTUzDMSKLpGqHuOJBZ;
							num = -1703396444;
							continue;
						case 3:
							throw new ArgumentNullException("destination");
						case 2:
							break;
						case 0:
							destination.JdetZGSYAxuUPraClBlCSLMWOmU = source.JdetZGSYAxuUPraClBlCSLMWOmU;
							destination.ipcPpQHebCyxuIFYuOhfFscSDfr = source.ipcPpQHebCyxuIFYuOhfFscSDfr;
							num = -1703396443;
							continue;
						default:
							destination.ORRYCyGQPzowEtoVbQfooaVIMXi = source.ORRYCyGQPzowEtoVbQfooaVIMXi;
							return;
						}
						break;
					}
				}
			}
		}

		public enum ConflictResponse
		{
			Cancel = 0,
			Replace = 1,
			Add = 2,
			Ignore = 3
		}

		public abstract class EventData
		{
			public readonly InputMapper inputMapper;

			internal EventData(InputMapper inputMapper)
			{
				this.inputMapper = inputMapper;
			}
		}

		public class InputMappedEventData : EventData
		{
			public readonly ActionElementMap actionElementMap;

			internal InputMappedEventData(InputMapper mapper, ActionElementMap actionElementMap)
				: base(mapper)
			{
				this.actionElementMap = actionElementMap;
			}
		}

		public class CanceledEventData : EventData
		{
			public readonly string message;

			internal CanceledEventData(InputMapper mapper, string message)
				: base(mapper)
			{
				this.message = message;
			}
		}

		public class ErrorEventData : EventData
		{
			public readonly string message;

			internal ErrorEventData(InputMapper mapper, string message)
				: base(mapper)
			{
				while (true)
				{
					int num = -1434105661;
					while (true)
					{
						switch (num ^ -1434105663)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0025;
						case 1:
							return;
						}
						break;
						IL_0025:
						this.message = message;
						num = -1434105664;
					}
				}
			}
		}

		public class TimedOutEventData : EventData
		{
			internal TimedOutEventData(InputMapper mapper)
				: base(mapper)
			{
			}
		}

		public class StartedEventData : EventData
		{
			internal StartedEventData(InputMapper mapper)
				: base(mapper)
			{
			}
		}

		public class StoppedEventData : EventData
		{
			internal StoppedEventData(InputMapper mapper)
				: base(mapper)
			{
			}
		}

		public class ConflictFoundEventData : EventData
		{
			public readonly Action<ConflictResponse> responseCallback;

			public readonly ElementAssignmentInfo assignment;

			public readonly IList<ElementAssignmentConflictInfo> conflicts;

			public readonly bool isProtected;

			internal ConflictFoundEventData(InputMapper mapper, Action<ConflictResponse> responseCallback, ElementAssignmentInfo assignment, IList<ElementAssignmentConflictInfo> conflicts, bool isProtected)
				: base(mapper)
			{
				this.responseCallback = responseCallback;
				this.assignment = assignment;
				this.conflicts = conflicts;
				this.isProtected = isProtected;
			}
		}

		private enum UXYouNakldlxUGpBJZwRfsHbFnY
		{
			OmJJiAbuTlMOWIkAgcVQUFjQEAm = 0,
			VoYMRlwACsraKOTYBiskDczbVjo = 1,
			gzLqQnynNiJYtnZJePCSdCDkTrO = 2,
			VLEgdOXdNXEqLkwpfjLktnYglPD = 3,
			ECstDpRUIjTqYIfJBeeiBNYZPCXD = 4,
			OyxFxlwKPbfcFNqcNGJfFiIzZsh = 5,
			PNsOoVDscRjIIcOTxLbztPuczOy = 6
		}

		public enum Status
		{
			Idle = 0,
			Listening = 1,
			AwaitingResponse = 2
		}

		private class xlOJLpgJJfXVaPWsEGwGQOBixwQ
		{
			private enum ohUXXWfZssPClVYzQxQvgfSVcCm
			{
				xbpoFKhAMiHPoxbuCFYiAMKDcbSD = 0,
				jESAGZsozYRyAOXvqeivTgkAVcR = 1
			}

			private enum RGjyCYPYxluyfyGrtLVAbXariyK
			{
				TCGihQKDgeeGtvEXifcuojmabzj = 0,
				vgIbcuPrbvHqzdJhfvSSOCJLtfa = 1
			}

			private class NwTBVHLrJkTpiloHvLCuTsuTrZX
			{
				private Player wVmxupsXoTmxeBeKFxYheQCHgkk;

				private int mecAvOSCkKTUzDMSKLpGqHuOJBZ;

				private Context xKtEDyBLZjygWwghTOQMNuqQPHDe;

				private ControllerType xRMUSowrwSVmfxjnqwQXevUgxsr;

				private int ruGCBfCWNtGZeTUKxKBCHIMxrSyL;

				private ControllerPollingInfo lDdCZddqmCfteXCQzyIOcdqLiDtb;

				private ModifierKeyFlags EuXSHfxCxOKWtPSMReFOETpbVgh;

				public Player player
				{
					get
					{
						return wVmxupsXoTmxeBeKFxYheQCHgkk;
					}
				}

				public int actionId
				{
					get
					{
						return mecAvOSCkKTUzDMSKLpGqHuOJBZ;
					}
				}

				public Context mappingContext
				{
					get
					{
						return xKtEDyBLZjygWwghTOQMNuqQPHDe;
					}
				}

				public ControllerType controllerType
				{
					get
					{
						return xRMUSowrwSVmfxjnqwQXevUgxsr;
					}
				}

				public int controllerId
				{
					get
					{
						return ruGCBfCWNtGZeTUKxKBCHIMxrSyL;
					}
				}

				public ControllerPollingInfo pollingInfo
				{
					get
					{
						return lDdCZddqmCfteXCQzyIOcdqLiDtb;
					}
				}

				public ModifierKeyFlags modifierKeyFlags
				{
					get
					{
						return EuXSHfxCxOKWtPSMReFOETpbVgh;
					}
				}

				public AxisRange axisRange
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
						while (true)
						{
							int num = 1229402542;
							while (true)
							{
								switch (num ^ 0x494731AF)
								{
								case 5:
									break;
								case 4:
									result = AxisRange.Full;
									num = 1229402543;
									continue;
								case 6:
									if (controllerPollingInfo.elementType == ControllerElementType.Axis)
									{
										int num2;
										if (xKtEDyBLZjygWwghTOQMNuqQPHDe.actionRange == AxisRange.Full)
										{
											num = 1229402539;
											num2 = num;
										}
										else
										{
											num = 1229402541;
											num2 = num;
										}
										continue;
									}
									goto default;
								case 0:
									num = 1229402540;
									continue;
								case 1:
									controllerPollingInfo = pollingInfo;
									num = 1229402537;
									continue;
								case 2:
									result = ((pollingInfo.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
									num = 1229402540;
									continue;
								default:
									return result;
								}
								break;
							}
						}
					}
				}

				public string elementName
				{
					get
					{
						if (controllerType == ControllerType.Keyboard && modifierKeyFlags != ModifierKeyFlags.None)
						{
							goto IL_0010;
						}
						string text = pollingInfo.elementIdentifierName;
						int num;
						int num2;
						if (pollingInfo.elementType != ControllerElementType.Axis)
						{
							num = 1769150327;
							num2 = num;
						}
						else
						{
							num = 1769150326;
							num2 = num;
						}
						goto IL_0015;
						IL_0010:
						num = 1769150320;
						goto IL_0015;
						IL_0015:
						while (true)
						{
							switch (num ^ 0x69731774)
							{
							case 0:
								break;
							case 4:
								return string.Format("{0} + {1}", Keyboard.ModifierKeyFlagsToString(modifierKeyFlags), pollingInfo.elementIdentifierName);
							case 1:
								if (axisRange == AxisRange.Negative)
								{
									text += " -";
									num = 1769150327;
									continue;
								}
								goto default;
							case 2:
								if (axisRange == AxisRange.Positive)
								{
									text += " +";
									num = 1769150327;
									continue;
								}
								goto case 1;
							default:
								return text;
							}
							break;
						}
						goto IL_0010;
					}
				}

				public void YJaAHaimrHWIfKrgfWxeihnqrcza(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						goto IL_0008;
					}
					goto IL_004c;
					IL_0008:
					int num = -381151684;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num ^ -381151681)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							mecAvOSCkKTUzDMSKLpGqHuOJBZ = P_1.actionId;
							num = -381151686;
							continue;
						case 4:
							goto IL_004c;
						case 6:
							xKtEDyBLZjygWwghTOQMNuqQPHDe = P_1;
							xRMUSowrwSVmfxjnqwQXevUgxsr = P_1.controllerMap.controllerType;
							ruGCBfCWNtGZeTUKxKBCHIMxrSyL = P_1.controllerMap.controllerId;
							P_1.lVOUSoXYpQJOYtyyJniiNkDHvOt();
							num = -381151681;
							continue;
						case 3:
							throw new ArgumentNullException("controllerMap");
						case 5:
							xRMUSowrwSVmfxjnqwQXevUgxsr = P_1.controllerMap.controllerType;
							ruGCBfCWNtGZeTUKxKBCHIMxrSyL = P_1.controllerMap.controllerId;
							num = -381151687;
							continue;
						case 0:
							return;
						}
						break;
					}
					goto IL_0008;
					IL_004c:
					nympziBLtYDUiPlWNRoEGqbSPfa();
					wVmxupsXoTmxeBeKFxYheQCHgkk = P_0;
					num = -381151682;
					goto IL_000d;
				}

				public void nympziBLtYDUiPlWNRoEGqbSPfa()
				{
					wVmxupsXoTmxeBeKFxYheQCHgkk = null;
					mecAvOSCkKTUzDMSKLpGqHuOJBZ = -1;
					xKtEDyBLZjygWwghTOQMNuqQPHDe = null;
					xRMUSowrwSVmfxjnqwQXevUgxsr = ControllerType.Keyboard;
					ruGCBfCWNtGZeTUKxKBCHIMxrSyL = -1;
					lDdCZddqmCfteXCQzyIOcdqLiDtb = default(ControllerPollingInfo);
					EuXSHfxCxOKWtPSMReFOETpbVgh = ModifierKeyFlags.None;
				}

				public ElementAssignment FhSaQydICWxGOvbPcwjexviqweu(ControllerPollingInfo P_0)
				{
					lDdCZddqmCfteXCQzyIOcdqLiDtb = P_0;
					return FhSaQydICWxGOvbPcwjexviqweu();
				}

				public ElementAssignment FhSaQydICWxGOvbPcwjexviqweu(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					lDdCZddqmCfteXCQzyIOcdqLiDtb = P_0;
					EuXSHfxCxOKWtPSMReFOETpbVgh = P_1;
					return FhSaQydICWxGOvbPcwjexviqweu();
				}

				public ElementAssignment FhSaQydICWxGOvbPcwjexviqweu()
				{
					return new ElementAssignment(controllerType, lDdCZddqmCfteXCQzyIOcdqLiDtb.elementType, lDdCZddqmCfteXCQzyIOcdqLiDtb.elementIdentifierId, axisRange, lDdCZddqmCfteXCQzyIOcdqLiDtb.keyboardKey, EuXSHfxCxOKWtPSMReFOETpbVgh, mecAvOSCkKTUzDMSKLpGqHuOJBZ, (xKtEDyBLZjygWwghTOQMNuqQPHDe.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (xKtEDyBLZjygWwghTOQMNuqQPHDe.actionElementMapToReplace != null) ? xKtEDyBLZjygWwghTOQMNuqQPHDe.actionElementMapToReplace.id : (-1));
				}
			}

			private readonly InputMapper HQqdfhbximGRqAmWjsGgpbsZYxai;

			private readonly Options MGWGRaaUsLnBlOlSCboSclEJLTF = new Options();

			private readonly NwTBVHLrJkTpiloHvLCuTsuTrZX gIZiNOqOAUJCvbMmHalEdlHWTGw = new NwTBVHLrJkTpiloHvLCuTsuTrZX();

			private readonly Dictionary<UXYouNakldlxUGpBJZwRfsHbFnY, SafeDelegate> dZGokImSjoemMGGmOJRNqoGONls;

			private readonly Dictionary<string, SafeDelegate> nRnbOfaWdIOaTEWGnsecocCmxTd;

			private Status aVAzLFOVTwEIIeAagBoqWuSMwpm;

			private RGjyCYPYxluyfyGrtLVAbXariyK HngDxilgQmbwjsagxMCXiPLELnh;

			private float pLGxTvJaeesjQEGSciDKsxLuPnH;

			private bool VXFjOijMeJDEAHfZqvVYOvfuEjFk;

			private List<Player> DqtoJzdwDWPOsAOrFfygWfukmws = new List<Player>();

			private readonly List<ControllerPollingInfo> oVuZsffNUnwzYUeuEMVsiCKzdgZi = new List<ControllerPollingInfo>();

			private ElementAssignment NIlKGCoBBfSEroMIDVVyMTvpbkT;

			public Status status
			{
				get
				{
					return aVAzLFOVTwEIIeAagBoqWuSMwpm;
				}
			}

			public float timeRemaining
			{
				get
				{
					if (aVAzLFOVTwEIIeAagBoqWuSMwpm == Status.Idle)
					{
						return 0f;
					}
					if (MGWGRaaUsLnBlOlSCboSclEJLTF.timeout <= 0f)
					{
						return 0f;
					}
					return MathTools.Max(0f, pLGxTvJaeesjQEGSciDKsxLuPnH + MGWGRaaUsLnBlOlSCboSclEJLTF.timeout - ReInput.unscaledTime);
				}
			}

			public Context context
			{
				get
				{
					if (aVAzLFOVTwEIIeAagBoqWuSMwpm == Status.Idle)
					{
						return null;
					}
					return gIZiNOqOAUJCvbMmHalEdlHWTGw.mappingContext;
				}
			}

			private bool checkTimer
			{
				get
				{
					if (VXFjOijMeJDEAHfZqvVYOvfuEjFk)
					{
						return false;
					}
					if (!(MGWGRaaUsLnBlOlSCboSclEJLTF.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public xlOJLpgJJfXVaPWsEGwGQOBixwQ(InputMapper parent, Dictionary<UXYouNakldlxUGpBJZwRfsHbFnY, SafeDelegate> events)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (events == null)
				{
					throw new ArgumentNullException("events");
				}
				HQqdfhbximGRqAmWjsGgpbsZYxai = parent;
				dZGokImSjoemMGGmOJRNqoGONls = events;
				CbNIcrvnFQKuUFKiCEsYAUrFeFbZ();
			}

			~xlOJLpgJJfXVaPWsEGwGQOBixwQ()
			{
				kzXBhGyWjBTlrtFPYjrYpJaqJnh();
			}

			public void HTeWiJSswgFIFVAtPBCSclhPFDl(Context P_0, Options P_1)
			{
				if (aVAzLFOVTwEIIeAagBoqWuSMwpm != Status.Idle)
				{
					goto IL_000b;
				}
				goto IL_00f3;
				IL_000b:
				int num = -753786718;
				goto IL_0010;
				IL_0010:
				Player player = default(Player);
				while (true)
				{
					switch (num ^ -753786712)
					{
					case 8:
						break;
					case 10:
						DkZlmFflkYehgwevpfIMaArUCcI("User started a new listening session.");
						num = -753786707;
						continue;
					case 9:
						if (P_1 == null)
						{
							throw new ArgumentNullException("options");
						}
						goto case 2;
					case 2:
						P_0 = P_0.Clone();
						Options.Copy(P_1, MGWGRaaUsLnBlOlSCboSclEJLTF);
						player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
						if (ReInput.mapping.GetAction(P_0.actionId) == null)
						{
							DNdKpXPlwkBxjLiJVdllDGsZRdkV("No Action found for actionId: " + P_0.actionId);
							return;
						}
						goto case 0;
					case 6:
						goto IL_00d7;
					case 5:
						goto IL_00f3;
					case 0:
						gIZiNOqOAUJCvbMmHalEdlHWTGw.YJaAHaimrHWIfKrgfWxeihnqrcza(player, P_0);
						aVAzLFOVTwEIIeAagBoqWuSMwpm = Status.Listening;
						num = -753786705;
						continue;
					case 1:
						throw new ArgumentNullException("controllerMap");
					case 7:
						LDnfGqAcIbYDmoxjrPhlvzERejy();
						uUJhRbpAahxvBvZWqGvIJGEJIAN();
						num = -753786709;
						continue;
					case 3:
						IpBMZCiRRpTeWUBEiCBfTyHblcV();
						num = -753786708;
						continue;
					default:
						RbUvVsAKdFieYTFMpRjguLEDMgC();
						return;
					}
					break;
				}
				goto IL_000b;
				IL_00f3:
				if (P_0 == null)
				{
					throw new ArgumentNullException("context");
				}
				goto IL_00d7;
				IL_00d7:
				int num2;
				if (P_0.controllerMap == null)
				{
					num = -753786711;
					num2 = num;
				}
				else
				{
					num = -753786719;
					num2 = num;
				}
				goto IL_0010;
			}

			public void XTKZapaesauuSnehMdoOWqLizpV(string P_0)
			{
				if (aVAzLFOVTwEIIeAagBoqWuSMwpm == Status.Idle)
				{
					goto IL_0008;
				}
				goto IL_0032;
				IL_0008:
				int num = 349433322;
				goto IL_000d;
				IL_000d:
				switch (num ^ 0x14D3EDEB)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 3:
					goto IL_0032;
				case 2:
					return;
				}
				goto IL_0008;
				IL_0032:
				DkZlmFflkYehgwevpfIMaArUCcI(P_0);
				num = 349433321;
				goto IL_000d;
			}

			private void UZSQFwoMfSAzsmmSKmseCCiJWWD(UpdateLoopType P_0)
			{
				if (P_0 != UpdateLoopType.Update)
				{
					return;
				}
				ElementAssignment elementAssignment = default(ElementAssignment);
				while (true)
				{
					int num;
					int num2;
					if (aVAzLFOVTwEIIeAagBoqWuSMwpm == Status.Listening)
					{
						num = 477174148;
						num2 = num;
					}
					else
					{
						num = 477174155;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x1C71198E)
						{
						case 7:
							num = 477174150;
							continue;
						case 0:
							if (timeRemaining <= 0f)
							{
								gUlQHbocwIkoqUNlFzMISNvIsuC();
								num = 477174159;
								continue;
							}
							goto case 3;
						case 2:
							if (tRpcfNzBijCFTIemMnhwmxtUXBvI(out elementAssignment) == ohUXXWfZssPClVYzQxQvgfSVcCm.xbpoFKhAMiHPoxbuCFYiAMKDcbSD)
							{
								return;
							}
							goto case 4;
						case 1:
							return;
						case 8:
							break;
						case 9:
							return;
						case 3:
						{
							Controller controller = ReInput.controllers.GetController(gIZiNOqOAUJCvbMmHalEdlHWTGw.controllerType, gIZiNOqOAUJCvbMmHalEdlHWTGw.controllerId);
							if (controller == null)
							{
								DNdKpXPlwkBxjLiJVdllDGsZRdkV(string.Concat("Controller not found for type: ", gIZiNOqOAUJCvbMmHalEdlHWTGw.controllerType, " id: ", gIZiNOqOAUJCvbMmHalEdlHWTGw.controllerId));
								num = 477174151;
								continue;
							}
							goto case 2;
						}
						case 4:
							if (cKLdHGmmOuLFbcZHhEyggmknJbG(elementAssignment) == ohUXXWfZssPClVYzQxQvgfSVcCm.xbpoFKhAMiHPoxbuCFYiAMKDcbSD)
							{
								return;
							}
							goto default;
						case 10:
						{
							int num3;
							if (checkTimer)
							{
								num = 477174158;
								num3 = num;
							}
							else
							{
								num = 477174157;
								num3 = num;
							}
							continue;
						}
						case 5:
							return;
						default:
							BCEDcumkTDGFyXaljbtsIZrKCbg(elementAssignment);
							return;
						}
						break;
					}
				}
			}

			private void GUDzwCHJALfoEQNzBBdJDJLeotpg()
			{
				if (aVAzLFOVTwEIIeAagBoqWuSMwpm == Status.Idle)
				{
					return;
				}
				while (true)
				{
					CbNIcrvnFQKuUFKiCEsYAUrFeFbZ();
					kzXBhGyWjBTlrtFPYjrYpJaqJnh();
					int num = 1927067104;
					while (true)
					{
						switch (num ^ 0x72DCB5E1)
						{
						case 0:
							goto IL_0009;
						case 2:
							break;
						default:
							CZCgztxDuzvWQfZETTBvRcpfINTb();
							return;
						}
						break;
						IL_0009:
						num = 1927067107;
					}
				}
			}

			private void CbNIcrvnFQKuUFKiCEsYAUrFeFbZ()
			{
				aVAzLFOVTwEIIeAagBoqWuSMwpm = Status.Idle;
				pLGxTvJaeesjQEGSciDKsxLuPnH = 0f;
				MGWGRaaUsLnBlOlSCboSclEJLTF.nympziBLtYDUiPlWNRoEGqbSPfa();
				gIZiNOqOAUJCvbMmHalEdlHWTGw.nympziBLtYDUiPlWNRoEGqbSPfa();
				NIlKGCoBBfSEroMIDVVyMTvpbkT = default(ElementAssignment);
				HngDxilgQmbwjsagxMCXiPLELnh = RGjyCYPYxluyfyGrtLVAbXariyK.TCGihQKDgeeGtvEXifcuojmabzj;
				VXFjOijMeJDEAHfZqvVYOvfuEjFk = false;
				DqtoJzdwDWPOsAOrFfygWfukmws.Clear();
			}

			private ohUXXWfZssPClVYzQxQvgfSVcCm tRpcfNzBijCFTIemMnhwmxtUXBvI(out ElementAssignment P_0)
			{
				IEnumerable<ControllerPollingInfo> enumerable;
				ModifierKeyFlags modifierKeyFlags;
				if (!dCtmIEdnvalHKWvnfEOtWOlGmvS(out enumerable, out modifierKeyFlags))
				{
					goto IL_000c;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				int num = -1456440241;
				goto IL_0011;
				IL_0011:
				switch (num ^ -1456440242)
				{
				case 0:
					break;
				case 2:
					P_0 = default(ElementAssignment);
					return ohUXXWfZssPClVYzQxQvgfSVcCm.xbpoFKhAMiHPoxbuCFYiAMKDcbSD;
				default:
				{
					using (IEnumerator<ControllerPollingInfo> enumerator = enumerable.GetEnumerator())
					{
						ControllerPollingInfo current = default(ControllerPollingInfo);
						while (true)
						{
							IL_0076:
							int num2;
							int num3;
							if (!enumerator.MoveNext())
							{
								num2 = -1456440244;
								num3 = num2;
							}
							else
							{
								num2 = -1456440246;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ -1456440242)
								{
								case 0:
									num2 = -1456440246;
									continue;
								default:
									goto end_IL_0051;
								case 5:
									break;
								case 3:
									if (current.success)
									{
										int num4;
										if (!NGhrZIkXPYMyeTRufBeEXVNcNdi(current, MGWGRaaUsLnBlOlSCboSclEJLTF))
										{
											num2 = -1456440241;
											num4 = num2;
										}
										else
										{
											num2 = -1456440245;
											num4 = num2;
										}
										continue;
									}
									break;
								case 1:
									controllerPollingInfo = current;
									num2 = -1456440244;
									continue;
								case 4:
									current = enumerator.Current;
									num2 = -1456440243;
									continue;
								case 2:
									goto end_IL_0051;
								}
								goto IL_0076;
								continue;
								end_IL_0051:
								break;
							}
							break;
						}
					}
					if (!controllerPollingInfo.success)
					{
						P_0 = default(ElementAssignment);
						return ohUXXWfZssPClVYzQxQvgfSVcCm.xbpoFKhAMiHPoxbuCFYiAMKDcbSD;
					}
					if (!EZsGcMDzqcvzbUSAJIrMbtqIvITZ(gIZiNOqOAUJCvbMmHalEdlHWTGw, controllerPollingInfo, MGWGRaaUsLnBlOlSCboSclEJLTF))
					{
						P_0 = default(ElementAssignment);
						return ohUXXWfZssPClVYzQxQvgfSVcCm.xbpoFKhAMiHPoxbuCFYiAMKDcbSD;
					}
					P_0 = gIZiNOqOAUJCvbMmHalEdlHWTGw.FhSaQydICWxGOvbPcwjexviqweu(controllerPollingInfo);
					P_0.modifierKeyFlags = modifierKeyFlags;
					return ohUXXWfZssPClVYzQxQvgfSVcCm.jESAGZsozYRyAOXvqeivTgkAVcR;
				}
				}
				goto IL_000c;
				IL_000c:
				num = -1456440244;
				goto IL_0011;
			}

			private bool dCtmIEdnvalHKWvnfEOtWOlGmvS(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = default(ControllerType);
				int controllerId = default(int);
				while (true)
				{
					int num = -561879579;
					while (true)
					{
						switch (num ^ -561879575)
						{
						case 9:
							break;
						case 0:
							P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
							goto case 7;
						case 10:
							P_0 = sUUxoCSLCTyEqzZfObccHPWlNcI(out P_1);
							return true;
						case 4:
						{
							int num2;
							if (MGWGRaaUsLnBlOlSCboSclEJLTF.allowButtons)
							{
								num = -561879582;
								num2 = num;
							}
							else
							{
								num = -561879569;
								num2 = num;
							}
							continue;
						}
						case 8:
						{
							int num4;
							if (gIZiNOqOAUJCvbMmHalEdlHWTGw.player != null)
							{
								num = -561879576;
								num4 = num;
							}
							else
							{
								num = -561879575;
								num4 = num;
							}
							continue;
						}
						case 12:
							controllerType = gIZiNOqOAUJCvbMmHalEdlHWTGw.controllerType;
							controllerId = gIZiNOqOAUJCvbMmHalEdlHWTGw.controllerId;
							if (controllerType != ControllerType.Keyboard)
							{
								if (!MGWGRaaUsLnBlOlSCboSclEJLTF.allowAxes)
								{
									goto case 4;
								}
								if (MGWGRaaUsLnBlOlSCboSclEJLTF.allowButtons)
								{
									int num3;
									if (gIZiNOqOAUJCvbMmHalEdlHWTGw.player != null)
									{
										num = -561879574;
										num3 = num;
									}
									else
									{
										num = -561879580;
										num3 = num;
									}
									continue;
								}
								goto case 8;
							}
							num = -561879581;
							continue;
						case 6:
							DNdKpXPlwkBxjLiJVdllDGsZRdkV("You must enable listening for at least one element type.");
							num = -561879573;
							continue;
						case 11:
							if (gIZiNOqOAUJCvbMmHalEdlHWTGw.player == null)
							{
								goto case 5;
							}
							P_0 = gIZiNOqOAUJCvbMmHalEdlHWTGw.player.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
							goto case 7;
						case 13:
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(gIZiNOqOAUJCvbMmHalEdlHWTGw.controllerType, gIZiNOqOAUJCvbMmHalEdlHWTGw.controllerId);
							goto case 7;
						case 5:
							P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
							goto case 7;
						case 3:
							P_0 = gIZiNOqOAUJCvbMmHalEdlHWTGw.player.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
							goto case 7;
						case 1:
							P_0 = gIZiNOqOAUJCvbMmHalEdlHWTGw.player.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
							num = -561879570;
							continue;
						default:
							P_0 = null;
							return false;
						case 7:
							return true;
						}
						break;
					}
				}
			}

			private IEnumerable<ControllerPollingInfo> sUUxoCSLCTyEqzZfObccHPWlNcI(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				oVuZsffNUnwzYUeuEMVsiCKzdgZi.Clear();
				if (!MGWGRaaUsLnBlOlSCboSclEJLTF.allowButtons)
				{
					goto IL_001b;
				}
				oVuZsffNUnwzYUeuEMVsiCKzdgZi.Add(EHkOyqEHrMkyTfFQOGkKcviefxo(MGWGRaaUsLnBlOlSCboSclEJLTF, out P_0));
				int num = -1959690785;
				goto IL_0020;
				IL_0020:
				switch (num ^ -1959690787)
				{
				case 0:
					break;
				case 1:
					return oVuZsffNUnwzYUeuEMVsiCKzdgZi;
				default:
					return oVuZsffNUnwzYUeuEMVsiCKzdgZi;
				}
				goto IL_001b;
				IL_001b:
				num = -1959690788;
				goto IL_0020;
			}

			private ControllerPollingInfo EHkOyqEHrMkyTfFQOGkKcviefxo(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = EHkOyqEHrMkyTfFQOGkKcviefxo(P_0, out flag, out P_1, out text);
				while (true)
				{
					int num = 2023282677;
					while (true)
					{
						switch (num ^ 0x7898D7F6)
						{
						case 0:
							break;
						case 3:
						{
							int num2;
							if (!flag)
							{
								num = 2023282679;
								num2 = num;
							}
							else
							{
								num = 2023282676;
								num2 = num;
							}
							continue;
						}
						case 2:
							LDnfGqAcIbYDmoxjrPhlvzERejy();
							num = 2023282679;
							continue;
						default:
							return result;
						}
						break;
					}
				}
			}

			private static ControllerPollingInfo EHkOyqEHrMkyTfFQOGkKcviefxo(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_3 = string.Empty;
				P_1 = false;
				P_2 = ModifierKeyFlags.None;
				int num = 0;
				ControllerPollingInfo result = default(ControllerPollingInfo);
				ControllerPollingInfo result2 = default(ControllerPollingInfo);
				ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
				IEnumerator<ControllerPollingInfo> enumerator = ReInput.controllers.Keyboard.PollForAllKeys().GetEnumerator();
				try
				{
					KeyCode keyboardKey = default(KeyCode);
					ControllerPollingInfo current = default(ControllerPollingInfo);
					while (true)
					{
						IL_006a:
						int num2;
						int num3;
						if (enumerator.MoveNext())
						{
							num2 = 1153039647;
							num3 = num2;
						}
						else
						{
							num2 = 1153039643;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x44B9FD1A)
							{
							case 3:
								num2 = 1153039647;
								continue;
							default:
								goto end_IL_003e;
							case 2:
								break;
							case 4:
								modifierKeyFlags |= Keyboard.KeyCodeToModifierKeyFlags(keyboardKey);
								num++;
								num2 = 1153039640;
								continue;
							case 6:
								result2 = current;
								num2 = 1153039646;
								continue;
							case 5:
								current = enumerator.Current;
								keyboardKey = current.keyboardKey;
								if (keyboardKey == KeyCode.AltGr)
								{
									break;
								}
								if (Keyboard.IsModifierKey(current.keyboardKey))
								{
									int num4;
									if (num != 0)
									{
										num2 = 1153039646;
										num4 = num2;
									}
									else
									{
										num2 = 1153039644;
										num4 = num2;
									}
									continue;
								}
								goto case 0;
							case 0:
								if (result.keyboardKey == KeyCode.None)
								{
									result = current;
									num2 = 1153039640;
									continue;
								}
								break;
							case 1:
								goto end_IL_003e;
							}
							goto IL_006a;
							continue;
							end_IL_003e:
							break;
						}
						break;
					}
				}
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_0102:
							int num5 = 1153039640;
							while (true)
							{
								switch (num5 ^ 0x44B9FD1A)
								{
								case 0:
									break;
								default:
									goto end_IL_0107;
								case 2:
									goto IL_0120;
								case 1:
									goto end_IL_0107;
								}
								goto IL_0102;
								IL_0120:
								enumerator.Dispose();
								num5 = 1153039643;
								continue;
								end_IL_0107:
								break;
							}
							break;
						}
					}
				}
				if (result.keyboardKey != KeyCode.None)
				{
					goto IL_0138;
				}
				int num6;
				if (num > 0)
				{
					P_1 = true;
					num6 = 1153039645;
					goto IL_013d;
				}
				goto IL_0269;
				IL_0138:
				num6 = 1153039634;
				goto IL_013d;
				IL_013d:
				while (true)
				{
					switch (num6 ^ 0x44B9FD1A)
					{
					case 0:
						break;
					case 9:
						goto IL_0175;
					case 6:
						goto IL_0199;
					case 1:
						return result;
					case 8:
						goto IL_01c3;
					case 7:
						goto IL_01fd;
					case 3:
						return result2;
					case 5:
						P_3 = Keyboard.ModifierKeyFlagsToString(modifierKeyFlags);
						num6 = 1153039646;
						continue;
					case 2:
						goto IL_0241;
					default:
						goto IL_0269;
					}
					break;
					IL_0241:
					if (ReInput.controllers.Keyboard.GetKeyTimePressed(result2.keyboardKey) >= P_0.holdDurationToMapKeyboardModifierKeyAsPrimary)
					{
						num6 = 1153039641;
						continue;
					}
					goto IL_0217;
					IL_0217:
					P_3 = Keyboard.GetKeyName(result2.keyboardKey);
					num6 = 1153039646;
					continue;
					IL_01fd:
					int num7;
					if (num == 1)
					{
						num6 = 1153039635;
						num7 = num6;
					}
					else
					{
						num6 = 1153039647;
						num7 = num6;
					}
					continue;
					IL_0199:
					if (!P_0.allowKeyboardKeysWithModifiers)
					{
						num6 = 1153039643;
						continue;
					}
					P_2 = modifierKeyFlags;
					return result;
					IL_0175:
					if (P_0.allowKeyboardModifierKeyAsPrimary)
					{
						int num8;
						if (!P_0.allowKeyboardKeysWithModifiers)
						{
							num6 = 1153039641;
							num8 = num6;
						}
						else
						{
							num6 = 1153039640;
							num8 = num6;
						}
						continue;
					}
					goto IL_0217;
					IL_01c3:
					if (!ReInput.controllers.Keyboard.GetKeyDown(result.keyboardKey))
					{
						return default(ControllerPollingInfo);
					}
					int num9;
					if (num != 0)
					{
						num6 = 1153039644;
						num9 = num6;
					}
					else
					{
						num6 = 1153039643;
						num9 = num6;
					}
				}
				goto IL_0138;
				IL_0269:
				return default(ControllerPollingInfo);
			}

			private static bool NGhrZIkXPYMyeTRufBeEXVNcNdi(ControllerPollingInfo P_0, Options P_1)
			{
				if (!P_1.allowAxes && P_0.elementType == ControllerElementType.Axis)
				{
					return false;
				}
				if (!P_1.allowButtons && P_0.elementType == ControllerElementType.Button)
				{
					return false;
				}
				if (P_0.controllerType == ControllerType.Mouse && P_0.elementType == ControllerElementType.Axis)
				{
					int num;
					switch (P_0.elementIndex)
					{
					case 0:
						if (!P_1.ignoreMouseXAxis)
						{
							break;
						}
						num = -1688781888;
						goto IL_0057;
					case 1:
						{
							if (!P_1.ignoreMouseYAxis)
							{
								break;
							}
							num = -1688781886;
							goto IL_0057;
						}
						IL_0057:
						while (true)
						{
							switch (num ^ -1688781887)
							{
							case 0:
								goto IL_0052;
							case 2:
								break;
							case 1:
								return true;
							default:
								return true;
							}
							break;
							IL_0052:
							num = -1688781885;
						}
						goto case 0;
					}
				}
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.pxbBXUyIaiMgcCSlqyLnQFalqSY<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool EZsGcMDzqcvzbUSAJIrMbtqIvITZ(NwTBVHLrJkTpiloHvLCuTsuTrZX P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.axisRange == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void uUJhRbpAahxvBvZWqGvIJGEJIAN()
			{
				if (!MGWGRaaUsLnBlOlSCboSclEJLTF.checkForConflicts)
				{
					goto IL_0010;
				}
				goto IL_0121;
				IL_0010:
				int num = 1926653660;
				goto IL_0015;
				IL_0015:
				IList<Player> allPlayers = default(IList<Player>);
				int num2 = default(int);
				IList<Player> players = default(IList<Player>);
				int num3 = default(int);
				int count = default(int);
				while (true)
				{
					switch (num ^ 0x72D666D0)
					{
					case 0:
						break;
					default:
						return;
					case 8:
						ListTools.AddIfUnique(DqtoJzdwDWPOsAOrFfygWfukmws, allPlayers[num2]);
						num = 1926653649;
						continue;
					case 5:
						if (MGWGRaaUsLnBlOlSCboSclEJLTF.checkForConflictsWithSystemPlayer)
						{
							ListTools.AddIfUnique(DqtoJzdwDWPOsAOrFfygWfukmws, ReInput.players.SystemPlayer);
							num = 1926653654;
							continue;
						}
						goto IL_00db;
					case 4:
						players = ReInput.players.Players;
						num3 = 0;
						num = 1926653661;
						continue;
					case 13:
						if (num3 >= players.Count)
						{
							return;
						}
						goto case 10;
					case 6:
						goto IL_00db;
					case 9:
						if (MGWGRaaUsLnBlOlSCboSclEJLTF.checkForConflictsWithPlayerIds != null)
						{
							allPlayers = ReInput.players.AllPlayers;
							num = 1926653659;
							continue;
						}
						return;
					case 3:
						goto IL_0121;
					case 2:
						if (gIZiNOqOAUJCvbMmHalEdlHWTGw.player != null)
						{
							ListTools.AddIfUnique(DqtoJzdwDWPOsAOrFfygWfukmws, gIZiNOqOAUJCvbMmHalEdlHWTGw.player);
							num = 1926653653;
							continue;
						}
						goto case 5;
					case 10:
						ListTools.AddIfUnique(DqtoJzdwDWPOsAOrFfygWfukmws, players[num3]);
						num3++;
						num = 1926653661;
						continue;
					case 12:
						return;
					case 1:
						num2++;
						num = 1926653663;
						continue;
					case 7:
						goto IL_01af;
					case 11:
						count = allPlayers.Count;
						num2 = 0;
						num = 1926653663;
						continue;
					case 15:
						goto IL_01f6;
					case 14:
						return;
					}
					break;
					IL_01f6:
					int num4;
					if (num2 >= count)
					{
						num = 1926653662;
						num4 = num;
					}
					else
					{
						num = 1926653655;
						num4 = num;
					}
					continue;
					IL_01af:
					int num5;
					if (!ArrayTools.Contains(MGWGRaaUsLnBlOlSCboSclEJLTF.checkForConflictsWithPlayerIds, allPlayers[num2].id))
					{
						num = 1926653649;
						num5 = num;
					}
					else
					{
						num = 1926653656;
						num5 = num;
					}
					continue;
					IL_00db:
					int num6;
					if (!MGWGRaaUsLnBlOlSCboSclEJLTF.checkForConflictsWithAllPlayers)
					{
						num = 1926653657;
						num6 = num;
					}
					else
					{
						num = 1926653652;
						num6 = num;
					}
				}
				goto IL_0010;
				IL_0121:
				int num7;
				if (MGWGRaaUsLnBlOlSCboSclEJLTF.checkForConflictsWithSelf)
				{
					num = 1926653650;
					num7 = num;
				}
				else
				{
					num = 1926653653;
					num7 = num;
				}
				goto IL_0015;
			}

			private ohUXXWfZssPClVYzQxQvgfSVcCm cKLdHGmmOuLFbcZHhEyggmknJbG(ElementAssignment P_0)
			{
				if (MGWGRaaUsLnBlOlSCboSclEJLTF.checkForConflicts)
				{
					while (true)
					{
						int num = -853153551;
						while (true)
						{
							switch (num ^ -853153552)
							{
							case 2:
								break;
							case 1:
								goto IL_002b;
							default:
								goto IL_003f;
							}
							break;
							IL_003f:
							if (!CZRQexcLCIhvpFDpakrGfGofAokL(gIZiNOqOAUJCvbMmHalEdlHWTGw, P_0, DqtoJzdwDWPOsAOrFfygWfukmws))
							{
								goto end_IL_000d;
							}
							return unVPnIkOCahXlHkbnxXkaUJXBto(P_0);
							IL_002b:
							if (gIZiNOqOAUJCvbMmHalEdlHWTGw.player == null)
							{
								goto end_IL_000d;
							}
							num = -853153552;
						}
						continue;
						end_IL_000d:
						break;
					}
				}
				return ohUXXWfZssPClVYzQxQvgfSVcCm.jESAGZsozYRyAOXvqeivTgkAVcR;
			}

			private static bool CZRQexcLCIhvpFDpakrGfGofAokL(NwTBVHLrJkTpiloHvLCuTsuTrZX P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 != null)
				{
					int num2 = default(int);
					ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
					while (true)
					{
						int num = -556197547;
						while (true)
						{
							switch (num ^ -556197551)
							{
							case 5:
								break;
							case 1:
								goto IL_0034;
							case 3:
								return false;
							case 4:
								goto IL_005b;
							case 6:
								goto IL_006a;
							case 0:
								goto end_IL_0006;
							default:
								if (num2 >= P_2.Count)
								{
									return false;
								}
								goto IL_006a;
							}
							break;
							IL_006a:
							if (P_2[num2].controllers.conflictChecking.DoesElementAssignmentConflict(conflictCheck))
							{
								return true;
							}
							num2++;
							num = -556197549;
							continue;
							IL_005b:
							int num3;
							if (P_0.player == null)
							{
								num = -556197551;
							}
							else if (P_2 != null)
							{
								num = -556197552;
								num3 = num;
							}
							else
							{
								num = -556197550;
								num3 = num;
							}
							continue;
							IL_0034:
							if (P_2.Count == 0)
							{
								num = -556197550;
								continue;
							}
							if (!ulWqcbtRrVDfXhaimKgCPigUNPRU(P_0, P_1, out conflictCheck))
							{
								return false;
							}
							num2 = 0;
							num = -556197549;
						}
						continue;
						end_IL_0006:
						break;
					}
				}
				return false;
			}

			private static bool mEHzMHSijhuCUTDINZwzuAHaIhAH(NwTBVHLrJkTpiloHvLCuTsuTrZX P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null)
				{
					goto IL_0031;
				}
				if (P_0.player == null)
				{
					goto IL_000b;
				}
				int num;
				ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
				int num2 = default(int);
				if (P_2 != null)
				{
					if (P_2.Count == 0)
					{
						num = -1166222581;
					}
					else
					{
						if (!ulWqcbtRrVDfXhaimKgCPigUNPRU(P_0, P_1, out conflictCheck))
						{
							return false;
						}
						num2 = 0;
						num = -1166222582;
					}
					goto IL_0010;
				}
				goto IL_0051;
				IL_0031:
				return false;
				IL_0051:
				return false;
				IL_000b:
				num = -1166222579;
				goto IL_0010;
				IL_0010:
				int num4;
				switch (num ^ -1166222583)
				{
				case 0:
					break;
				case 4:
					goto IL_0031;
				case 2:
					goto IL_0051;
				default:
				{
					IEnumerator<ElementAssignmentConflictInfo> enumerator = P_2[num2].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							if (!enumerator.Current.isUserAssignable)
							{
								return true;
							}
						}
					}
					finally
					{
						if (enumerator != null)
						{
							while (true)
							{
								IL_00d2:
								int num3 = -1166222584;
								while (true)
								{
									switch (num3 ^ -1166222583)
									{
									case 0:
										break;
									default:
										goto end_IL_00d7;
									case 1:
										goto IL_00f0;
									case 2:
										goto end_IL_00d7;
									}
									goto IL_00d2;
									IL_00f0:
									enumerator.Dispose();
									num3 = -1166222581;
									continue;
									end_IL_00d7:
									break;
								}
								break;
							}
						}
					}
					num2++;
					goto IL_0103;
				}
				case 3:
					goto IL_0121;
					IL_0121:
					if (num2 < P_2.Count)
					{
						goto default;
					}
					num4 = -1166222581;
					goto IL_0108;
					IL_0103:
					num4 = -1166222584;
					goto IL_0108;
					IL_0108:
					switch (num4 ^ -1166222583)
					{
					case 0:
						break;
					case 1:
						goto IL_0121;
					default:
						return false;
					}
					goto IL_0103;
				}
				goto IL_000b;
			}

			private static IList<ElementAssignmentConflictInfo> ZoRSMwoPAEurdYgKOCSPDEGOtUa(NwTBVHLrJkTpiloHvLCuTsuTrZX P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null)
				{
					goto IL_0039;
				}
				if (P_0.player == null)
				{
					goto IL_000b;
				}
				int num;
				ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
				List<ElementAssignmentConflictInfo> list = default(List<ElementAssignmentConflictInfo>);
				if (P_2 != null)
				{
					if (P_2.Count == 0)
					{
						num = -617756399;
					}
					else if (!ulWqcbtRrVDfXhaimKgCPigUNPRU(P_0, P_1, out conflictCheck))
					{
						num = -617756396;
					}
					else
					{
						list = new List<ElementAssignmentConflictInfo>();
						num = -617756394;
					}
					goto IL_0010;
				}
				goto IL_004d;
				IL_0039:
				return null;
				IL_004d:
				return null;
				IL_000b:
				num = -617756395;
				goto IL_0010;
				IL_0010:
				int num2 = default(int);
				while (true)
				{
					int num4;
					switch (num ^ -617756400)
					{
					case 3:
						break;
					case 5:
						goto IL_0039;
					case 1:
						goto IL_004d;
					case 6:
						num2 = 0;
						num = -617756398;
						continue;
					case 4:
						return null;
					default:
					{
						using (IEnumerator<ElementAssignmentConflictInfo> enumerator = P_2[num2].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								while (true)
								{
									ElementAssignmentConflictInfo current = enumerator.Current;
									list.Add(current);
									int num3 = -617756399;
									while (true)
									{
										switch (num3 ^ -617756400)
										{
										case 0:
											num3 = -617756398;
											continue;
										case 2:
											break;
										default:
											goto end_IL_00c3;
										}
										break;
									}
									continue;
									end_IL_00c3:
									break;
								}
							}
						}
						num2++;
						goto IL_00f4;
					}
					case 2:
						goto IL_0112;
						IL_00f4:
						num4 = -617756399;
						goto IL_00f9;
						IL_00f9:
						switch (num4 ^ -617756400)
						{
						case 2:
							break;
						case 1:
							goto IL_0112;
						default:
							return list;
						}
						goto IL_00f4;
						IL_0112:
						if (num2 < P_2.Count)
						{
							goto default;
						}
						num4 = -617756400;
						goto IL_00f9;
					}
					break;
				}
				goto IL_000b;
			}

			private static bool ulWqcbtRrVDfXhaimKgCPigUNPRU(NwTBVHLrJkTpiloHvLCuTsuTrZX P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				int num;
				if (P_0 != null)
				{
					if ((player = P_0.player) == null)
					{
						goto IL_000d;
					}
					P_2 = P_1.ToElementAssignmentConflictCheck();
					num = 598702146;
					goto IL_0012;
				}
				goto IL_003e;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x23AF7843)
					{
					case 0:
						break;
					case 3:
						goto IL_003e;
					case 1:
						P_2.playerId = player.id;
						num = 598702145;
						continue;
					case 6:
						P_2.controllerMapId = P_0.mappingContext.controllerMap.id;
						num = 598702151;
						continue;
					case 4:
						P_2.controllerMapCategoryId = P_0.mappingContext.controllerMap.categoryId;
						if (P_0.mappingContext.actionElementMapToReplace != null)
						{
							P_2.elementMapId = P_0.mappingContext.actionElementMapToReplace.id;
							num = 598702150;
							continue;
						}
						goto default;
					case 2:
						P_2.controllerType = P_0.controllerType;
						P_2.controllerId = P_0.controllerId;
						num = 598702149;
						continue;
					default:
						return true;
					}
					break;
				}
				goto IL_000d;
				IL_003e:
				P_2 = default(ElementAssignmentConflictCheck);
				return false;
				IL_000d:
				num = 598702144;
				goto IL_0012;
			}

			private static void MjFvPEZFPxxVhhWkhAaMlHfemxf(NwTBVHLrJkTpiloHvLCuTsuTrZX P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 != null)
				{
					if (P_0.player == null)
					{
						goto IL_000b;
					}
					goto IL_0087;
				}
				return;
				IL_0087:
				ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
				if (!ulWqcbtRrVDfXhaimKgCPigUNPRU(P_0, P_1, out conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				goto IL_0041;
				IL_000b:
				int num = 1119986166;
				goto IL_0010;
				IL_0010:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x42C1A1F4)
					{
					case 4:
						break;
					default:
						return;
					case 2:
						return;
					case 0:
						goto IL_0041;
					case 5:
						P_2[num2].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
						num2++;
						num = 1119986167;
						continue;
					case 3:
						goto IL_006d;
					case 6:
						goto IL_0087;
					case 1:
						return;
					}
					break;
					IL_006d:
					int num3;
					if (num2 >= P_2.Count)
					{
						num = 1119986165;
						num3 = num;
					}
					else
					{
						num = 1119986161;
						num3 = num;
					}
				}
				goto IL_000b;
				IL_0041:
				num2 = 0;
				num = 1119986167;
				goto IL_0010;
			}

			private void IpBMZCiRRpTeWUBEiCBfTyHblcV()
			{
				ReInput.UpdateEndedEvent -= UZSQFwoMfSAzsmmSKmseCCiJWWD;
				ReInput.UpdateEndedEvent += UZSQFwoMfSAzsmmSKmseCCiJWWD;
			}

			private void kzXBhGyWjBTlrtFPYjrYpJaqJnh()
			{
				ReInput.UpdateEndedEvent -= UZSQFwoMfSAzsmmSKmseCCiJWWD;
			}

			private bool JCVdrTvvkLIOjcSFfKtPoFETbzo(UXYouNakldlxUGpBJZwRfsHbFnY P_0)
			{
				SafeDelegate safeDelegate = dZGokImSjoemMGGmOJRNqoGONls[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void qaRmscmPBZVJYfZftZFplyrZnud<T>(UXYouNakldlxUGpBJZwRfsHbFnY P_0, T P_1)
			{
				SafeAction<T> safeAction = (SafeAction<T>)dZGokImSjoemMGGmOJRNqoGONls[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void LDnfGqAcIbYDmoxjrPhlvzERejy()
			{
				pLGxTvJaeesjQEGSciDKsxLuPnH = ReInput.unscaledTime;
			}

			private void VqsidoSoZGnlegwjTPBrunuJAOHG()
			{
				VXFjOijMeJDEAHfZqvVYOvfuEjFk = true;
			}

			private void UqFTZQqAyLuCXwkuvreLBEIFBcW(ActionElementMap P_0)
			{
				mBjiBErFHYBjWMkNxDiTAVvsLwz(P_0);
				while (true)
				{
					int num = -603752142;
					while (true)
					{
						switch (num ^ -603752141)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0025;
						case 0:
							return;
						}
						break;
						IL_0025:
						GUDzwCHJALfoEQNzBBdJDJLeotpg();
						num = -603752141;
					}
				}
			}

			private void DkZlmFflkYehgwevpfIMaArUCcI(string P_0)
			{
				nCyvIyCiYXbQKpQXorMHzNmuftAi(P_0);
				GUDzwCHJALfoEQNzBBdJDJLeotpg();
			}

			private ohUXXWfZssPClVYzQxQvgfSVcCm unVPnIkOCahXlHkbnxXkaUJXBto(ElementAssignment P_0)
			{
				if (JCVdrTvvkLIOjcSFfKtPoFETbzo(UXYouNakldlxUGpBJZwRfsHbFnY.PNsOoVDscRjIIcOTxLbztPuczOy))
				{
					bool flag = mEHzMHSijhuCUTDINZwzuAHaIhAH(gIZiNOqOAUJCvbMmHalEdlHWTGw, P_0, DqtoJzdwDWPOsAOrFfygWfukmws);
					NIlKGCoBBfSEroMIDVVyMTvpbkT = P_0;
					IList<ElementAssignmentConflictInfo> list = ZoRSMwoPAEurdYgKOCSPDEGOtUa(gIZiNOqOAUJCvbMmHalEdlHWTGw, P_0, DqtoJzdwDWPOsAOrFfygWfukmws);
					HngDxilgQmbwjsagxMCXiPLELnh = RGjyCYPYxluyfyGrtLVAbXariyK.vgIbcuPrbvHqzdJhfvSSOCJLtfa;
					IPgLPvBhlHdWOeGkkjpRBoqjhiok();
					ngnlUObIAicrGgdihUxdAbVvvTVN(new ElementAssignmentInfo(gIZiNOqOAUJCvbMmHalEdlHWTGw.mappingContext.controllerMap, P_0), list, flag);
					return ohUXXWfZssPClVYzQxQvgfSVcCm.xbpoFKhAMiHPoxbuCFYiAMKDcbSD;
				}
				return SoZrLwjiJqHQgKBANWIiSyFVJsTq(MGWGRaaUsLnBlOlSCboSclEJLTF.defaultActionWhenConflictFound, P_0);
			}

			private ohUXXWfZssPClVYzQxQvgfSVcCm SoZrLwjiJqHQgKBANWIiSyFVJsTq(ConflictResponse P_0, ElementAssignment P_1)
			{
				return SoZrLwjiJqHQgKBANWIiSyFVJsTq(P_0, P_1, mEHzMHSijhuCUTDINZwzuAHaIhAH(gIZiNOqOAUJCvbMmHalEdlHWTGw, P_1, DqtoJzdwDWPOsAOrFfygWfukmws));
			}

			private ohUXXWfZssPClVYzQxQvgfSVcCm SoZrLwjiJqHQgKBANWIiSyFVJsTq(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				int num;
				switch (P_0)
				{
				default:
					num = -1701803781;
					goto IL_001d;
				case ConflictResponse.Cancel:
					goto IL_0043;
				case ConflictResponse.Replace:
					if (P_2)
					{
						DkZlmFflkYehgwevpfIMaArUCcI("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						num = -1701803783;
						goto IL_001d;
					}
					MjFvPEZFPxxVhhWkhAaMlHfemxf(gIZiNOqOAUJCvbMmHalEdlHWTGw, P_1, DqtoJzdwDWPOsAOrFfygWfukmws);
					return ohUXXWfZssPClVYzQxQvgfSVcCm.jESAGZsozYRyAOXvqeivTgkAVcR;
				case ConflictResponse.Add:
					return ohUXXWfZssPClVYzQxQvgfSVcCm.jESAGZsozYRyAOXvqeivTgkAVcR;
				case ConflictResponse.Ignore:
					{
						VfYAtzbQvTdoWVaEgMfzYHEQMcsA();
						return ohUXXWfZssPClVYzQxQvgfSVcCm.xbpoFKhAMiHPoxbuCFYiAMKDcbSD;
					}
					IL_001d:
					switch (num ^ -1701803783)
					{
					case 3:
						break;
					case 1:
						goto IL_0043;
					default:
						return ohUXXWfZssPClVYzQxQvgfSVcCm.xbpoFKhAMiHPoxbuCFYiAMKDcbSD;
					case 2:
						throw new NotImplementedException();
					}
					goto default;
					IL_0043:
					DkZlmFflkYehgwevpfIMaArUCcI("Mapping assignment was canceled due to a conflict.");
					return ohUXXWfZssPClVYzQxQvgfSVcCm.xbpoFKhAMiHPoxbuCFYiAMKDcbSD;
				}
			}

			private void gUlQHbocwIkoqUNlFzMISNvIsuC()
			{
				ocYrWbPNQlIQtBhLaBnPDBHtgQgr();
				GUDzwCHJALfoEQNzBBdJDJLeotpg();
			}

			private void DNdKpXPlwkBxjLiJVdllDGsZRdkV(string P_0)
			{
				BYAwobnkzzBDKdhQjKwJLpCipCQt(P_0);
				while (true)
				{
					int num = 1180126512;
					while (true)
					{
						switch (num ^ 0x46574D31)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0025;
						case 0:
							return;
						}
						break;
						IL_0025:
						GUDzwCHJALfoEQNzBBdJDJLeotpg();
						num = 1180126513;
					}
				}
			}

			private void IPgLPvBhlHdWOeGkkjpRBoqjhiok()
			{
				VqsidoSoZGnlegwjTPBrunuJAOHG();
				while (true)
				{
					int num = 827020573;
					while (true)
					{
						switch (num ^ 0x314B551F)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0024;
						case 1:
							return;
						}
						break;
						IL_0024:
						kzXBhGyWjBTlrtFPYjrYpJaqJnh();
						aVAzLFOVTwEIIeAagBoqWuSMwpm = Status.AwaitingResponse;
						num = 827020574;
					}
				}
			}

			private void VfYAtzbQvTdoWVaEgMfzYHEQMcsA()
			{
				aVAzLFOVTwEIIeAagBoqWuSMwpm = Status.Listening;
				HngDxilgQmbwjsagxMCXiPLELnh = RGjyCYPYxluyfyGrtLVAbXariyK.TCGihQKDgeeGtvEXifcuojmabzj;
				while (true)
				{
					int num = 870409842;
					while (true)
					{
						switch (num ^ 0x33E16673)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							LDnfGqAcIbYDmoxjrPhlvzERejy();
							num = 870409840;
							continue;
						case 3:
							IpBMZCiRRpTeWUBEiCBfTyHblcV();
							num = 870409841;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}

			private void BCEDcumkTDGFyXaljbtsIZrKCbg(ElementAssignment P_0)
			{
				ActionElementMap result;
				if (gIZiNOqOAUJCvbMmHalEdlHWTGw.mappingContext.controllerMap.ReplaceOrCreateElementMap(P_0, out result))
				{
					UqFTZQqAyLuCXwkuvreLBEIFBcW(result);
				}
				else
				{
					DNdKpXPlwkBxjLiJVdllDGsZRdkV("Failed to create element assignment.");
				}
			}

			private void mBjiBErFHYBjWMkNxDiTAVvsLwz(ActionElementMap P_0)
			{
				if (JCVdrTvvkLIOjcSFfKtPoFETbzo(UXYouNakldlxUGpBJZwRfsHbFnY.OmJJiAbuTlMOWIkAgcVQUFjQEAm))
				{
					qaRmscmPBZVJYfZftZFplyrZnud(UXYouNakldlxUGpBJZwRfsHbFnY.OmJJiAbuTlMOWIkAgcVQUFjQEAm, new InputMappedEventData(HQqdfhbximGRqAmWjsGgpbsZYxai, P_0));
				}
			}

			private void ocYrWbPNQlIQtBhLaBnPDBHtgQgr()
			{
				if (JCVdrTvvkLIOjcSFfKtPoFETbzo(UXYouNakldlxUGpBJZwRfsHbFnY.VLEgdOXdNXEqLkwpfjLktnYglPD))
				{
					qaRmscmPBZVJYfZftZFplyrZnud(UXYouNakldlxUGpBJZwRfsHbFnY.VLEgdOXdNXEqLkwpfjLktnYglPD, new TimedOutEventData(HQqdfhbximGRqAmWjsGgpbsZYxai));
				}
			}

			private void BYAwobnkzzBDKdhQjKwJLpCipCQt(string P_0)
			{
				if (!JCVdrTvvkLIOjcSFfKtPoFETbzo(UXYouNakldlxUGpBJZwRfsHbFnY.VoYMRlwACsraKOTYBiskDczbVjo))
				{
					while (true)
					{
						switch (0x4B604086 ^ 0x4B604087)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				qaRmscmPBZVJYfZftZFplyrZnud(UXYouNakldlxUGpBJZwRfsHbFnY.VoYMRlwACsraKOTYBiskDczbVjo, new ErrorEventData(HQqdfhbximGRqAmWjsGgpbsZYxai, P_0));
			}

			private void nCyvIyCiYXbQKpQXorMHzNmuftAi(string P_0)
			{
				if (JCVdrTvvkLIOjcSFfKtPoFETbzo(UXYouNakldlxUGpBJZwRfsHbFnY.gzLqQnynNiJYtnZJePCSdCDkTrO))
				{
					qaRmscmPBZVJYfZftZFplyrZnud(UXYouNakldlxUGpBJZwRfsHbFnY.gzLqQnynNiJYtnZJePCSdCDkTrO, new CanceledEventData(HQqdfhbximGRqAmWjsGgpbsZYxai, P_0));
				}
			}

			private void ngnlUObIAicrGgdihUxdAbVvvTVN(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				if (!JCVdrTvvkLIOjcSFfKtPoFETbzo(UXYouNakldlxUGpBJZwRfsHbFnY.PNsOoVDscRjIIcOTxLbztPuczOy))
				{
					while (true)
					{
						switch (-1237897064 ^ -1237897062)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				qaRmscmPBZVJYfZftZFplyrZnud(UXYouNakldlxUGpBJZwRfsHbFnY.PNsOoVDscRjIIcOTxLbztPuczOy, new ConflictFoundEventData(HQqdfhbximGRqAmWjsGgpbsZYxai, zKcwRdtVCiVejUgkovCTEizmsoA, P_0, P_1, P_2));
			}

			private void RbUvVsAKdFieYTFMpRjguLEDMgC()
			{
				if (!JCVdrTvvkLIOjcSFfKtPoFETbzo(UXYouNakldlxUGpBJZwRfsHbFnY.ECstDpRUIjTqYIfJBeeiBNYZPCXD))
				{
					while (true)
					{
						switch (-2142239704 ^ -2142239703)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				qaRmscmPBZVJYfZftZFplyrZnud(UXYouNakldlxUGpBJZwRfsHbFnY.ECstDpRUIjTqYIfJBeeiBNYZPCXD, new StartedEventData(HQqdfhbximGRqAmWjsGgpbsZYxai));
			}

			private void CZCgztxDuzvWQfZETTBvRcpfINTb()
			{
				if (JCVdrTvvkLIOjcSFfKtPoFETbzo(UXYouNakldlxUGpBJZwRfsHbFnY.OyxFxlwKPbfcFNqcNGJfFiIzZsh))
				{
					qaRmscmPBZVJYfZftZFplyrZnud(UXYouNakldlxUGpBJZwRfsHbFnY.OyxFxlwKPbfcFNqcNGJfFiIzZsh, new StoppedEventData(HQqdfhbximGRqAmWjsGgpbsZYxai));
				}
			}

			public void zKcwRdtVCiVejUgkovCTEizmsoA(ConflictResponse P_0)
			{
				if (aVAzLFOVTwEIIeAagBoqWuSMwpm != Status.AwaitingResponse || HngDxilgQmbwjsagxMCXiPLELnh != RGjyCYPYxluyfyGrtLVAbXariyK.vgIbcuPrbvHqzdJhfvSSOCJLtfa)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (SoZrLwjiJqHQgKBANWIiSyFVJsTq(P_0, NIlKGCoBBfSEroMIDVVyMTvpbkT) == ohUXXWfZssPClVYzQxQvgfSVcCm.jESAGZsozYRyAOXvqeivTgkAVcR)
					{
						BCEDcumkTDGFyXaljbtsIZrKCbg(NIlKGCoBBfSEroMIDVVyMTvpbkT);
					}
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in the conflict check user response callback.\n" + ex);
				}
			}
		}

		public class Options
		{
			internal const string KMuFpSYtLXgEvcaeMRQEIpVwhAV = "isElementAllowed";

			private bool vRtHFcZElDYoHvxzJReNkEiatUd = true;

			private bool niaxElEkPPyCWQpSdfBWKLNqrES = true;

			private bool lvdXQAVuGOKCqiqXgkkhKTRtHsd = true;

			private float IgbiKRnnKathmzTrgmoOckoKjWk;

			private bool rbKOqysLAwCpqMMHmaZzfiQOebla = true;

			private bool BoeaJreUnvzkMNHfFbmUtNOwoJAR = true;

			private bool VguVAAGgAyhZAySqZAHaYueoQaJ = true;

			private bool NBwMjcSIwGVAgwbWYcSzHaoMqTgf = true;

			private int[] JBivnsZHgajLBmLKbyaXoojNBIq;

			private ConflictResponse dOcCUeSDnApKvtHHKCszLcRQaFc = ConflictResponse.Replace;

			private bool mSMFdpjtegqgJJumWWGruJuhEBkO;

			private bool GRSDNJGqNhYsKzVeUURdLrEAFuT;

			private bool OyyTJidQqHdTSiCiGbHAmtdnJAw = true;

			private bool PaMqgjMtbpawJFvAzBdtfjZmRLM = true;

			private float olrcBUbxXEwXVNAgIPPyvjWtwvci = 1f;

			private readonly Dictionary<string, SafeDelegate> nRnbOfaWdIOaTEWGnsecocCmxTd = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			[CompilerGenerated]
			private static Action<Exception> UioTSLrlZQEXgOsMPnnSNqTfIIb;

			public bool allowAxes
			{
				get
				{
					return vRtHFcZElDYoHvxzJReNkEiatUd;
				}
				set
				{
					vRtHFcZElDYoHvxzJReNkEiatUd = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return niaxElEkPPyCWQpSdfBWKLNqrES;
				}
				set
				{
					niaxElEkPPyCWQpSdfBWKLNqrES = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return lvdXQAVuGOKCqiqXgkkhKTRtHsd;
				}
				set
				{
					lvdXQAVuGOKCqiqXgkkhKTRtHsd = value;
				}
			}

			public float timeout
			{
				get
				{
					return IgbiKRnnKathmzTrgmoOckoKjWk;
				}
				set
				{
					IgbiKRnnKathmzTrgmoOckoKjWk = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return rbKOqysLAwCpqMMHmaZzfiQOebla;
				}
				set
				{
					rbKOqysLAwCpqMMHmaZzfiQOebla = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return BoeaJreUnvzkMNHfFbmUtNOwoJAR;
				}
				set
				{
					BoeaJreUnvzkMNHfFbmUtNOwoJAR = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return VguVAAGgAyhZAySqZAHaYueoQaJ;
				}
				set
				{
					VguVAAGgAyhZAySqZAHaYueoQaJ = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return NBwMjcSIwGVAgwbWYcSzHaoMqTgf;
				}
				set
				{
					NBwMjcSIwGVAgwbWYcSzHaoMqTgf = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return JBivnsZHgajLBmLKbyaXoojNBIq;
				}
				set
				{
					JBivnsZHgajLBmLKbyaXoojNBIq = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return dOcCUeSDnApKvtHHKCszLcRQaFc;
				}
				set
				{
					dOcCUeSDnApKvtHHKCszLcRQaFc = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return mSMFdpjtegqgJJumWWGruJuhEBkO;
				}
				set
				{
					mSMFdpjtegqgJJumWWGruJuhEBkO = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return GRSDNJGqNhYsKzVeUURdLrEAFuT;
				}
				set
				{
					GRSDNJGqNhYsKzVeUURdLrEAFuT = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return OyyTJidQqHdTSiCiGbHAmtdnJAw;
				}
				set
				{
					OyyTJidQqHdTSiCiGbHAmtdnJAw = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return PaMqgjMtbpawJFvAzBdtfjZmRLM;
				}
				set
				{
					PaMqgjMtbpawJFvAzBdtfjZmRLM = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return olrcBUbxXEwXVNAgIPPyvjWtwvci;
				}
				set
				{
					olrcBUbxXEwXVNAgIPPyvjWtwvci = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)nRnbOfaWdIOaTEWGnsecocCmxTd["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					while (true)
					{
						int num = 829743171;
						while (true)
						{
							switch (num ^ 0x3174E040)
							{
							case 0:
								break;
							case 3:
							{
								int num2;
								if (safePredicate != null)
								{
									num = 829743170;
									num2 = num;
								}
								else
								{
									num = 829743169;
									num2 = num;
								}
								continue;
							}
							case 2:
								safePredicate.ExceptionHandler = delegate(Exception P_0)
								{
									ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
								};
								num = 829743169;
								continue;
							default:
								nRnbOfaWdIOaTEWGnsecocCmxTd["isElementAllowed"] = safePredicate;
								return;
							}
							break;
						}
					}
				}
			}

			internal T pxbBXUyIaiMgcCSlqyLnQFalqSY<T>(string P_0) where T : SafeDelegate
			{
				SafeDelegate value;
				if (!nRnbOfaWdIOaTEWGnsecocCmxTd.TryGetValue(P_0, out value))
				{
					return null;
				}
				return value as T;
			}

			public Options()
			{
				nympziBLtYDUiPlWNRoEGqbSPfa();
			}

			private Options(Options source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				Copy(source, this);
			}

			public Options Clone()
			{
				return new Options(this);
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("Options:\n");
				stringBuilder.Append("allowAxes = " + vRtHFcZElDYoHvxzJReNkEiatUd + "\n");
				while (true)
				{
					int num = -1721947314;
					while (true)
					{
						switch (num ^ -1721947320)
						{
						case 2:
							break;
						case 7:
							stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(JBivnsZHgajLBmLKbyaXoojNBIq) + "\n");
							num = -1721947319;
							continue;
						case 1:
							stringBuilder.Append(string.Concat("defaultActionWhenConflictFound = ", dOcCUeSDnApKvtHHKCszLcRQaFc, "\n"));
							num = -1721947317;
							continue;
						case 3:
							stringBuilder.Append("ignoreMouseXAxis = " + mSMFdpjtegqgJJumWWGruJuhEBkO);
							stringBuilder.Append("ignoreMouseYAxis = " + GRSDNJGqNhYsKzVeUURdLrEAFuT);
							num = -1721947315;
							continue;
						case 6:
							stringBuilder.Append("allowButtons = " + niaxElEkPPyCWQpSdfBWKLNqrES + "\n");
							num = -1721947328;
							continue;
						case 8:
							stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + lvdXQAVuGOKCqiqXgkkhKTRtHsd + "\n");
							stringBuilder.Append("timeout = " + IgbiKRnnKathmzTrgmoOckoKjWk + "\n");
							stringBuilder.Append("checkForConflicts = " + rbKOqysLAwCpqMMHmaZzfiQOebla + "\n");
							num = -1721947316;
							continue;
						case 5:
							stringBuilder.Append("allowKeyboardKeysWithModifiers = " + OyyTJidQqHdTSiCiGbHAmtdnJAw + "\n");
							stringBuilder.Append("allowKeyboardModifierAsPrimary = " + PaMqgjMtbpawJFvAzBdtfjZmRLM + "\n");
							num = -1721947320;
							continue;
						case 4:
							stringBuilder.Append("checkForConflictsWithAllPlayers = " + BoeaJreUnvzkMNHfFbmUtNOwoJAR + "\n");
							stringBuilder.Append("checkForConflictsWithSelf = " + VguVAAGgAyhZAySqZAHaYueoQaJ + "\n");
							stringBuilder.Append("checkForConflictsWithSystemPlayer = " + NBwMjcSIwGVAgwbWYcSzHaoMqTgf + "\n");
							if (JBivnsZHgajLBmLKbyaXoojNBIq == null)
							{
								stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
								num = -1721947319;
								continue;
							}
							goto case 7;
						default:
							stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + olrcBUbxXEwXVNAgIPPyvjWtwvci + "\n");
							return stringBuilder.ToString();
						}
						break;
					}
				}
			}

			internal void nympziBLtYDUiPlWNRoEGqbSPfa()
			{
				vRtHFcZElDYoHvxzJReNkEiatUd = true;
				niaxElEkPPyCWQpSdfBWKLNqrES = true;
				lvdXQAVuGOKCqiqXgkkhKTRtHsd = true;
				IgbiKRnnKathmzTrgmoOckoKjWk = 0f;
				rbKOqysLAwCpqMMHmaZzfiQOebla = true;
				while (true)
				{
					int num = 1941092965;
					while (true)
					{
						switch (num ^ 0x73B2BA64)
						{
						case 2:
							break;
						case 1:
							BoeaJreUnvzkMNHfFbmUtNOwoJAR = true;
							VguVAAGgAyhZAySqZAHaYueoQaJ = true;
							num = 1941092964;
							continue;
						case 0:
							NBwMjcSIwGVAgwbWYcSzHaoMqTgf = true;
							JBivnsZHgajLBmLKbyaXoojNBIq = null;
							dOcCUeSDnApKvtHHKCszLcRQaFc = ConflictResponse.Replace;
							mSMFdpjtegqgJJumWWGruJuhEBkO = false;
							GRSDNJGqNhYsKzVeUURdLrEAFuT = false;
							OyyTJidQqHdTSiCiGbHAmtdnJAw = true;
							num = 1941092967;
							continue;
						default:
						{
							PaMqgjMtbpawJFvAzBdtfjZmRLM = true;
							olrcBUbxXEwXVNAgIPPyvjWtwvci = 1f;
							List<string> list = new List<string>(nRnbOfaWdIOaTEWGnsecocCmxTd.Keys);
							using (List<string>.Enumerator enumerator = list.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										string current = enumerator.Current;
										nRnbOfaWdIOaTEWGnsecocCmxTd[current] = null;
										int num2 = 1941092966;
										while (true)
										{
											switch (num2 ^ 0x73B2BA64)
											{
											case 0:
												num2 = 1941092965;
												continue;
											case 1:
												break;
											default:
												goto end_IL_00d9;
											}
											break;
										}
										continue;
										end_IL_00d9:
										break;
									}
								}
								return;
							}
						}
						}
						break;
					}
				}
			}

			public static void Copy(Options source, Options destination)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				while (true)
				{
					int num;
					int num2;
					if (destination != null)
					{
						num = -1177777672;
						num2 = num;
					}
					else
					{
						num = -1177777671;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1177777666)
						{
						case 4:
							num = -1177777665;
							continue;
						case 6:
							destination.vRtHFcZElDYoHvxzJReNkEiatUd = source.vRtHFcZElDYoHvxzJReNkEiatUd;
							destination.niaxElEkPPyCWQpSdfBWKLNqrES = source.niaxElEkPPyCWQpSdfBWKLNqrES;
							destination.lvdXQAVuGOKCqiqXgkkhKTRtHsd = source.lvdXQAVuGOKCqiqXgkkhKTRtHsd;
							num = -1177777669;
							continue;
						case 0:
							destination.dOcCUeSDnApKvtHHKCszLcRQaFc = source.dOcCUeSDnApKvtHHKCszLcRQaFc;
							destination.mSMFdpjtegqgJJumWWGruJuhEBkO = source.mSMFdpjtegqgJJumWWGruJuhEBkO;
							destination.GRSDNJGqNhYsKzVeUURdLrEAFuT = source.GRSDNJGqNhYsKzVeUURdLrEAFuT;
							destination.OyyTJidQqHdTSiCiGbHAmtdnJAw = source.OyyTJidQqHdTSiCiGbHAmtdnJAw;
							num = -1177777668;
							continue;
						case 1:
							break;
						case 2:
							destination.PaMqgjMtbpawJFvAzBdtfjZmRLM = source.PaMqgjMtbpawJFvAzBdtfjZmRLM;
							num = -1177777667;
							continue;
						case 5:
							destination.IgbiKRnnKathmzTrgmoOckoKjWk = source.IgbiKRnnKathmzTrgmoOckoKjWk;
							destination.rbKOqysLAwCpqMMHmaZzfiQOebla = source.rbKOqysLAwCpqMMHmaZzfiQOebla;
							destination.BoeaJreUnvzkMNHfFbmUtNOwoJAR = source.BoeaJreUnvzkMNHfFbmUtNOwoJAR;
							destination.VguVAAGgAyhZAySqZAHaYueoQaJ = source.VguVAAGgAyhZAySqZAHaYueoQaJ;
							destination.NBwMjcSIwGVAgwbWYcSzHaoMqTgf = source.NBwMjcSIwGVAgwbWYcSzHaoMqTgf;
							destination.JBivnsZHgajLBmLKbyaXoojNBIq = ArrayTools.ShallowCopy(source.JBivnsZHgajLBmLKbyaXoojNBIq);
							num = -1177777666;
							continue;
						case 7:
							throw new ArgumentNullException("destination");
						default:
						{
							destination.olrcBUbxXEwXVNAgIPPyvjWtwvci = source.olrcBUbxXEwXVNAgIPPyvjWtwvci;
							using (Dictionary<string, SafeDelegate>.Enumerator enumerator = source.nRnbOfaWdIOaTEWGnsecocCmxTd.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										KeyValuePair<string, SafeDelegate> current = enumerator.Current;
										int num3 = -1177777667;
										while (true)
										{
											switch (num3 ^ -1177777666)
											{
											case 0:
												num3 = -1177777665;
												continue;
											case 1:
												break;
											case 3:
												destination.nRnbOfaWdIOaTEWGnsecocCmxTd[current.Key] = MiscTools.Clone(current.Value);
												num3 = -1177777668;
												continue;
											default:
												goto end_IL_0180;
											}
											break;
										}
										continue;
										end_IL_0180:
										break;
									}
								}
								return;
							}
						}
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static void VDXrsWIOReNIxaRFttRIKOrLQgj(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
			}
		}

		private static InputMapper LDwDTzcqSaJaAJzktFPjtpIxftC;

		private static int yyRdqIEdvRRWoOnhAbeUyuGapvs = 0;

		private readonly int NSjeQKhFJTlDoDGngvEElQKKyTlz;

		private readonly bool DKKsJhVovhSPQzaEeMupVTQYArh;

		private readonly xlOJLpgJJfXVaPWsEGwGQOBixwQ VccATGwRZfmxpmjVYmFvhxHzNPx;

		private Options MGWGRaaUsLnBlOlSCboSclEJLTF;

		private readonly Dictionary<UXYouNakldlxUGpBJZwRfsHbFnY, SafeDelegate> dZGokImSjoemMGGmOJRNqoGONls = new Dictionary<UXYouNakldlxUGpBJZwRfsHbFnY, SafeDelegate>
		{
			{
				UXYouNakldlxUGpBJZwRfsHbFnY.OmJJiAbuTlMOWIkAgcVQUFjQEAm,
				new SafeAction<InputMappedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
				})
			},
			{
				UXYouNakldlxUGpBJZwRfsHbFnY.VoYMRlwACsraKOTYBiskDczbVjo,
				new SafeAction<ErrorEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
				})
			},
			{
				UXYouNakldlxUGpBJZwRfsHbFnY.gzLqQnynNiJYtnZJePCSdCDkTrO,
				new SafeAction<CanceledEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
				})
			},
			{
				UXYouNakldlxUGpBJZwRfsHbFnY.VLEgdOXdNXEqLkwpfjLktnYglPD,
				new SafeAction<TimedOutEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
				})
			},
			{
				UXYouNakldlxUGpBJZwRfsHbFnY.ECstDpRUIjTqYIfJBeeiBNYZPCXD,
				new SafeAction<StartedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
				})
			},
			{
				UXYouNakldlxUGpBJZwRfsHbFnY.OyxFxlwKPbfcFNqcNGJfFiIzZsh,
				new SafeAction<StoppedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
				})
			},
			{
				UXYouNakldlxUGpBJZwRfsHbFnY.PNsOoVDscRjIIcOTxLbztPuczOy,
				new SafeAction<ConflictFoundEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
				})
			}
		};

		[CompilerGenerated]
		private static Action<Exception> iYWKlIDjIWSBoqTbAufnGzoIkMf;

		[CompilerGenerated]
		private static Action<Exception> KMVSMNlcVvJaRclgBWSJrxykfCh;

		[CompilerGenerated]
		private static Action<Exception> decyKaUSyEGKbHNDKSnEMCGvfDT;

		[CompilerGenerated]
		private static Action<Exception> OaciNJiksQpXpqpsqstbBUbOMJaC;

		[CompilerGenerated]
		private static Action<Exception> iTIUNfkrngADvbAMBtQwnvUyAPT;

		[CompilerGenerated]
		private static Action<Exception> TODKqlbTiotlvzHBygnoMXgfGhn;

		[CompilerGenerated]
		private static Action<Exception> KHuwdLJfGgThnfYBrbOxhYxvFWc;

		public static InputMapper Default
		{
			get
			{
				return LDwDTzcqSaJaAJzktFPjtpIxftC ?? (LDwDTzcqSaJaAJzktFPjtpIxftC = new InputMapper(true));
			}
		}

		public Options options
		{
			get
			{
				Options obj = MGWGRaaUsLnBlOlSCboSclEJLTF;
				if (obj == null)
				{
					if (!DKKsJhVovhSPQzaEeMupVTQYArh)
					{
						return MGWGRaaUsLnBlOlSCboSclEJLTF = Default.options.Clone();
					}
					obj = (MGWGRaaUsLnBlOlSCboSclEJLTF = new Options());
				}
				return obj;
			}
			set
			{
				MGWGRaaUsLnBlOlSCboSclEJLTF = value;
			}
		}

		public Context mappingContext
		{
			get
			{
				return VccATGwRZfmxpmjVYmFvhxHzNPx.context;
			}
		}

		public Status status
		{
			get
			{
				return VccATGwRZfmxpmjVYmFvhxHzNPx.status;
			}
		}

		public float timeRemaining
		{
			get
			{
				return VccATGwRZfmxpmjVYmFvhxHzNPx.timeRemaining;
			}
		}

		internal int id
		{
			get
			{
				return NSjeQKhFJTlDoDGngvEElQKKyTlz;
			}
		}

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.OmJJiAbuTlMOWIkAgcVQUFjQEAm;
					dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<InputMappedEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] + value;
				}
			}
			remove
			{
				if (value == null)
				{
					goto IL_0003;
				}
				goto IL_0031;
				IL_0003:
				int num = 606708377;
				goto IL_0008;
				IL_0008:
				UXYouNakldlxUGpBJZwRfsHbFnY key = default(UXYouNakldlxUGpBJZwRfsHbFnY);
				while (true)
				{
					switch (num ^ 0x2429A298)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						return;
					case 3:
						goto IL_0031;
					case 4:
						dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<InputMappedEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] - value;
						num = 606708378;
						continue;
					case 2:
						return;
					}
					break;
				}
				goto IL_0003;
				IL_0031:
				key = UXYouNakldlxUGpBJZwRfsHbFnY.OmJJiAbuTlMOWIkAgcVQUFjQEAm;
				num = 606708380;
				goto IL_0008;
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.VoYMRlwACsraKOTYBiskDczbVjo;
					dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<ErrorEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] + value;
				}
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.VoYMRlwACsraKOTYBiskDczbVjo;
					int num = -855928055;
					while (true)
					{
						switch (num ^ -855928056)
						{
						case 0:
							goto IL_0004;
						case 2:
							break;
						default:
							dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<ErrorEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] - value;
							return;
						}
						break;
						IL_0004:
						num = -855928054;
					}
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value == null)
				{
					while (true)
					{
						switch (0x12433096 ^ 0x12433097)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.gzLqQnynNiJYtnZJePCSdCDkTrO;
				dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<CanceledEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] + value;
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.gzLqQnynNiJYtnZJePCSdCDkTrO;
					dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<CanceledEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] - value;
					int num = 1130185571;
					while (true)
					{
						switch (num ^ 0x435D4363)
						{
						case 2:
							goto IL_0004;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_0004:
						num = 1130185570;
					}
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.VLEgdOXdNXEqLkwpfjLktnYglPD;
					dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<TimedOutEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.VLEgdOXdNXEqLkwpfjLktnYglPD;
					dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<TimedOutEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.ECstDpRUIjTqYIfJBeeiBNYZPCXD;
					dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<StartedEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] + value;
				}
			}
			remove
			{
				if (value == null)
				{
					goto IL_0003;
				}
				goto IL_002d;
				IL_0003:
				int num = -1051534169;
				goto IL_0008;
				IL_0008:
				switch (num ^ -1051534171)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 1:
					goto IL_002d;
				case 3:
					return;
				}
				goto IL_0003;
				IL_002d:
				UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.ECstDpRUIjTqYIfJBeeiBNYZPCXD;
				dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<StartedEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] - value;
				num = -1051534170;
				goto IL_0008;
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.OyxFxlwKPbfcFNqcNGJfFiIzZsh;
					dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<StoppedEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.OyxFxlwKPbfcFNqcNGJfFiIzZsh;
					dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<StoppedEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.PNsOoVDscRjIIcOTxLbztPuczOy;
					int num = 994811638;
					while (true)
					{
						switch (num ^ 0x3B4B9EF6)
						{
						case 2:
							goto IL_0004;
						case 1:
							break;
						default:
							dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<ConflictFoundEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] + value;
							return;
						}
						break;
						IL_0004:
						num = 994811639;
					}
				}
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					UXYouNakldlxUGpBJZwRfsHbFnY key = UXYouNakldlxUGpBJZwRfsHbFnY.PNsOoVDscRjIIcOTxLbztPuczOy;
					int num = -1654093256;
					while (true)
					{
						switch (num ^ -1654093256)
						{
						case 2:
							num = -1654093253;
							continue;
						default:
							return;
						case 3:
							break;
						case 0:
							dZGokImSjoemMGGmOJRNqoGONls[key] = (SafeAction<ConflictFoundEventData>)dZGokImSjoemMGGmOJRNqoGONls[key] - value;
							num = -1654093255;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		private static int oSterGHJiHAfEQCDtGKaynxpmaXj()
		{
			int result = yyRdqIEdvRRWoOnhAbeUyuGapvs;
			if (yyRdqIEdvRRWoOnhAbeUyuGapvs == int.MaxValue)
			{
				yyRdqIEdvRRWoOnhAbeUyuGapvs = 0;
			}
			else
			{
				while (true)
				{
					yyRdqIEdvRRWoOnhAbeUyuGapvs++;
					int num = 385402068;
					while (true)
					{
						switch (num ^ 0x16F8C4D6)
						{
						case 0:
							num = 385402071;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0038;
						}
						break;
					}
					continue;
					end_IL_0038:
					break;
				}
			}
			return result;
		}

		public InputMapper()
			: this(false)
		{
			NSjeQKhFJTlDoDGngvEElQKKyTlz = oSterGHJiHAfEQCDtGKaynxpmaXj();
		}

		private InputMapper(bool isDefault)
		{
			while (true)
			{
				int num = -1081526784;
				while (true)
				{
					switch (num ^ -1081526783)
					{
					case 2:
						break;
					case 1:
						DKKsJhVovhSPQzaEeMupVTQYArh = isDefault;
						if (DKKsJhVovhSPQzaEeMupVTQYArh)
						{
							goto IL_015f;
						}
						goto default;
					default:
						VccATGwRZfmxpmjVYmFvhxHzNPx = new xlOJLpgJJfXVaPWsEGwGQOBixwQ(this, dZGokImSjoemMGGmOJRNqoGONls);
						return;
					}
					break;
					IL_015f:
					MGWGRaaUsLnBlOlSCboSclEJLTF = new Options();
					num = -1081526783;
				}
			}
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			using (Dictionary<UXYouNakldlxUGpBJZwRfsHbFnY, SafeDelegate>.Enumerator enumerator = dZGokImSjoemMGGmOJRNqoGONls.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						enumerator.Current.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
						int num = 1121159742;
						while (true)
						{
							switch (num ^ 0x42D38A3E)
							{
							case 2:
								num = 1121159743;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0030;
							}
							break;
						}
						continue;
						end_IL_0030:
						break;
					}
				}
			}
		}

		public void RemoveAllEventListeners()
		{
			using (Dictionary<UXYouNakldlxUGpBJZwRfsHbFnY, SafeDelegate>.Enumerator enumerator = dZGokImSjoemMGGmOJRNqoGONls.GetEnumerator())
			{
				while (true)
				{
					int num;
					int num2;
					if (enumerator.MoveNext())
					{
						num = -1291195439;
						num2 = num;
					}
					else
					{
						num = -1291195437;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1291195440)
						{
						case 0:
							num = -1291195439;
							continue;
						default:
							return;
						case 1:
							enumerator.Current.Value.Clear();
							num = -1291195438;
							continue;
						case 2:
							break;
						case 3:
							return;
						}
						break;
					}
				}
			}
		}

		internal void zWtctQqVWItTFVwpSHzIIbjJbBi(object P_0)
		{
		}

		internal void DMpFHIFChubqcsamAnCjkwhDQjQl()
		{
		}

		public bool Start(Context mappingContext)
		{
			return HTeWiJSswgFIFVAtPBCSclhPFDl(mappingContext, (MGWGRaaUsLnBlOlSCboSclEJLTF != null) ? MGWGRaaUsLnBlOlSCboSclEJLTF : Default.options);
		}

		public void Stop()
		{
			VccATGwRZfmxpmjVYmFvhxHzNPx.XTKZapaesauuSnehMdoOWqLizpV("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			while (true)
			{
				int num = -1539172146;
				while (true)
				{
					switch (num ^ -1539172147)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						DMpFHIFChubqcsamAnCjkwhDQjQl();
						num = -1539172147;
						continue;
					case 0:
						MGWGRaaUsLnBlOlSCboSclEJLTF = null;
						num = -1539172148;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private bool HTeWiJSswgFIFVAtPBCSclhPFDl(Context P_0, Options P_1)
		{
			if (!ReInput.isReady)
			{
				return false;
			}
			if (P_0 == null)
			{
				Logger.LogError("The Context cannot be null.");
				return false;
			}
			if (P_0.controllerMap == null)
			{
				goto IL_0020;
			}
			int num;
			if (P_0.actionElementMapToReplace != null && !P_0.controllerMap.ContainsElementMap(P_0.actionElementMapToReplace))
			{
				num = 473920201;
				goto IL_0025;
			}
			try
			{
				VccATGwRZfmxpmjVYmFvhxHzNPx.HTeWiJSswgFIFVAtPBCSclhPFDl(P_0, P_1);
				return true;
			}
			catch
			{
				while (true)
				{
					int num2 = 473920200;
					while (true)
					{
						switch (num2 ^ 0x1C3F72C9)
						{
						case 2:
							break;
						case 1:
							goto IL_00b3;
						default:
							return false;
						}
						break;
						IL_00b3:
						VccATGwRZfmxpmjVYmFvhxHzNPx.XTKZapaesauuSnehMdoOWqLizpV("Failed to start due to an exception.");
						num2 = 473920201;
					}
				}
			}
			IL_0025:
			while (true)
			{
				switch (num ^ 0x1C3F72C9)
				{
				case 2:
					break;
				case 1:
					goto IL_0042;
				case 3:
					return false;
				default:
					Logger.LogError("The Action Element Map must belong to the same Controller Map you are passing in.");
					return false;
				}
				break;
				IL_0042:
				Logger.LogError("The Controller Map cannot be null.");
				num = 473920202;
			}
			goto IL_0020;
			IL_0020:
			num = 473920200;
			goto IL_0025;
		}

		[CompilerGenerated]
		private static void rjUdsJYSdwEkbBQIhWfuVpROzKko(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
		}

		[CompilerGenerated]
		private static void IouyBqDasSqmwbPjfCKjSfakNjb(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
		}

		[CompilerGenerated]
		private static void tBCiNVZOPZercCbJfMoHdoIKPpTv(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
		}

		[CompilerGenerated]
		private static void GtPvUxNCFjJZuMitasmypFLOlef(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
		}

		[CompilerGenerated]
		private static void wJlgoqfurSHqXDJjcIIFVgqVcuNf(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
		}

		[CompilerGenerated]
		private static void uiRtPSuRLvCIDVZRGTBHiIjInez(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
		}

		[CompilerGenerated]
		private static void kmOcMlKkWWgjiDkAfMvWUDZgzBK(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
		}
	}
}
