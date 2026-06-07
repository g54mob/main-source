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
			private int ZUoDkTcclUigIzTjeFLCXFMQOaU = -1;

			private ControllerMap yAkjWJqxMpaNcNJFRMpKjoUYObX;

			private ActionElementMap ZMyFiThavUYSPabNIllhoHeWbegK;

			private AxisRange dkXaLlyqDtDHvDufFaCqdLiKcNxg = AxisRange.Positive;

			private bool BxkVLvlCVmksheKkQLjigmvgFDd;

			public int actionId
			{
				get
				{
					return ZUoDkTcclUigIzTjeFLCXFMQOaU;
				}
				set
				{
					if (!BsxsrqNJIEciTQoXmbnxaxJSAmv())
					{
						ZUoDkTcclUigIzTjeFLCXFMQOaU = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(ZUoDkTcclUigIzTjeFLCXFMQOaU);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (BsxsrqNJIEciTQoXmbnxaxJSAmv())
					{
						return;
					}
					while (true)
					{
						InputAction action = ReInput.mapping.GetAction(value);
						int num;
						int num2;
						if (action != null)
						{
							num = 1740642345;
							num2 = num;
						}
						else
						{
							num = 1740642346;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x67C0182B)
							{
							case 0:
								num = 1740642350;
								continue;
							default:
								return;
							case 2:
								ZUoDkTcclUigIzTjeFLCXFMQOaU = action.id;
								num = 1740642351;
								continue;
							case 3:
								Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
								return;
							case 1:
								ZUoDkTcclUigIzTjeFLCXFMQOaU = -1;
								num = 1740642344;
								continue;
							case 5:
								break;
							case 4:
								return;
							}
							break;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return yAkjWJqxMpaNcNJFRMpKjoUYObX;
				}
				set
				{
					if (!BsxsrqNJIEciTQoXmbnxaxJSAmv())
					{
						yAkjWJqxMpaNcNJFRMpKjoUYObX = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return ZMyFiThavUYSPabNIllhoHeWbegK;
				}
				set
				{
					if (BsxsrqNJIEciTQoXmbnxaxJSAmv())
					{
						goto IL_0008;
					}
					goto IL_0032;
					IL_0008:
					int num = -1466159808;
					goto IL_000d;
					IL_000d:
					switch (num ^ -1466159806)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						return;
					case 3:
						goto IL_0032;
					case 1:
						return;
					}
					goto IL_0008;
					IL_0032:
					ZMyFiThavUYSPabNIllhoHeWbegK = value;
					num = -1466159805;
					goto IL_000d;
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return dkXaLlyqDtDHvDufFaCqdLiKcNxg;
				}
				set
				{
					if (BsxsrqNJIEciTQoXmbnxaxJSAmv())
					{
						return;
					}
					while (true)
					{
						dkXaLlyqDtDHvDufFaCqdLiKcNxg = value;
						int num = -1864535243;
						while (true)
						{
							switch (num ^ -1864535241)
							{
							case 0:
								goto IL_0009;
							default:
								return;
							case 1:
								break;
							case 2:
								return;
							}
							break;
							IL_0009:
							num = -1864535242;
						}
					}
				}
			}

			public Context()
			{
			}

			private Context(Context source)
				: this()
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				Copy(source, this);
			}

			public Context Clone()
			{
				return new Context(this);
			}

			internal void YLQJupdNdUwetJwpvvzoqLTPuCy()
			{
				BxkVLvlCVmksheKkQLjigmvgFDd = true;
			}

			private bool BsxsrqNJIEciTQoXmbnxaxJSAmv()
			{
				if (BxkVLvlCVmksheKkQLjigmvgFDd)
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
				while (destination != null)
				{
					while (true)
					{
						IL_0045:
						destination.ZUoDkTcclUigIzTjeFLCXFMQOaU = source.ZUoDkTcclUigIzTjeFLCXFMQOaU;
						destination.yAkjWJqxMpaNcNJFRMpKjoUYObX = source.yAkjWJqxMpaNcNJFRMpKjoUYObX;
						int num = -1305441825;
						while (true)
						{
							switch (num ^ -1305441827)
							{
							case 0:
								num = -1305441826;
								continue;
							case 3:
								break;
							case 1:
								goto IL_0045;
							default:
								destination.ZMyFiThavUYSPabNIllhoHeWbegK = source.ZMyFiThavUYSPabNIllhoHeWbegK;
								destination.dkXaLlyqDtDHvDufFaCqdLiKcNxg = source.dkXaLlyqDtDHvDufFaCqdLiKcNxg;
								return;
							}
							break;
						}
						break;
					}
				}
				throw new ArgumentNullException("destination");
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
				this.message = message;
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

		private enum faAxcnEMyhMvEgkmlLQaUGonSiw
		{
			xAPQdNJoHdLlriIRSdcQlihMhVf = 0,
			grUBokGUZoYzRePQzgyPslflUhm = 1,
			ZhBjTyGHBmJlWBqUKVYQKMXyEaL = 2,
			oVKApXvPXTQVqIawNRPcUMAelYY = 3,
			racJEwnVOzQXhmYAxvkeyHURrNS = 4,
			lZfOpoEACbElLnFflcCbeRwfKGs = 5,
			grqEvWbQoBkhrWeSJPfnUhwcWDt = 6
		}

		public enum Status
		{
			Idle = 0,
			Listening = 1,
			AwaitingResponse = 2
		}

		private class ItUQksAXJzmVAthYgOGArPZuoVr
		{
			private enum YGLayqMclxGhNcZYVxvBSWFtlDW
			{
				SAnbvHBkQiQmXBqhcsEefNWVdkP = 0,
				IdGRGOISrELIjaPgAaovaKmAYrW = 1
			}

			private enum FMAiIqJDIPAiYUEzvCnsyBexJET
			{
				iOlZgcuFwLCPNAjSgaSDuxucio = 0,
				GxUdsbfTrrVJADmoPKaSbaNVeuz = 1
			}

			private class weGWVrUOkAjXRopXNKrSTPUkdtEg
			{
				private Player JIqiIfYNWcNgEfGpdhnEBWMXlMl;

				private int ZUoDkTcclUigIzTjeFLCXFMQOaU;

				private Context OwpxKldwFjhZzSdmlfWQdFqAnKAe;

				private ControllerType CiEHnIGrjScHYHuMEoDVXvEgwiy;

				private int WuIXWewTRtkXNcGHNDHMpyChWRj;

				private ControllerPollingInfo ALrSUeCekIMEPeoZDaGYIdsBmIw;

				private ModifierKeyFlags tmDdGydFlWVbCarXzSZWfplxDpyN;

				public Player player
				{
					get
					{
						return JIqiIfYNWcNgEfGpdhnEBWMXlMl;
					}
				}

				public int actionId
				{
					get
					{
						return ZUoDkTcclUigIzTjeFLCXFMQOaU;
					}
				}

				public Context mappingContext
				{
					get
					{
						return OwpxKldwFjhZzSdmlfWQdFqAnKAe;
					}
				}

				public ControllerType controllerType
				{
					get
					{
						return CiEHnIGrjScHYHuMEoDVXvEgwiy;
					}
				}

				public int controllerId
				{
					get
					{
						return WuIXWewTRtkXNcGHNDHMpyChWRj;
					}
				}

				public ControllerPollingInfo pollingInfo
				{
					get
					{
						return ALrSUeCekIMEPeoZDaGYIdsBmIw;
					}
				}

				public ModifierKeyFlags modifierKeyFlags
				{
					get
					{
						return tmDdGydFlWVbCarXzSZWfplxDpyN;
					}
				}

				public AxisRange axisRange
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (pollingInfo.elementType == ControllerElementType.Axis)
						{
							if (OwpxKldwFjhZzSdmlfWQdFqAnKAe.actionRange == AxisRange.Full)
							{
								goto IL_001f;
							}
							goto IL_005a;
						}
						goto IL_0071;
						IL_005a:
						ControllerPollingInfo controllerPollingInfo = pollingInfo;
						int num = 730680887;
						goto IL_0024;
						IL_001f:
						num = 730680883;
						goto IL_0024;
						IL_0024:
						while (true)
						{
							switch (num ^ 0x2B8D4E37)
							{
							case 2:
								break;
							case 0:
								result = ((controllerPollingInfo.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
								num = 730680886;
								continue;
							case 3:
								goto IL_005a;
							case 4:
								result = AxisRange.Full;
								num = 730680886;
								continue;
							default:
								goto IL_0071;
							}
							break;
						}
						goto IL_001f;
						IL_0071:
						return result;
					}
				}

				public string elementName
				{
					get
					{
						if (controllerType == ControllerType.Keyboard)
						{
							goto IL_0008;
						}
						goto IL_007b;
						IL_0008:
						int num = 1238549005;
						goto IL_000d;
						IL_000d:
						string text = default(string);
						while (true)
						{
							switch (num ^ 0x49D2C208)
							{
							case 4:
								break;
							case 2:
								num = 1238549001;
								continue;
							case 3:
								text += " +";
								num = 1238549002;
								continue;
							case 5:
								goto IL_004f;
							case 0:
								if (axisRange == AxisRange.Negative)
								{
									text += " -";
									num = 1238549001;
									continue;
								}
								goto IL_00d6;
							default:
								goto IL_00d6;
							}
							break;
						}
						goto IL_0008;
						IL_00d6:
						return text;
						IL_004f:
						if (modifierKeyFlags != ModifierKeyFlags.None)
						{
							return string.Format("{0} + {1}", Keyboard.ModifierKeyFlagsToString(modifierKeyFlags), pollingInfo.elementIdentifierName);
						}
						goto IL_007b;
						IL_007b:
						text = pollingInfo.elementIdentifierName;
						if (pollingInfo.elementType == ControllerElementType.Axis)
						{
							int num2;
							if (axisRange == AxisRange.Positive)
							{
								num = 1238549003;
								num2 = num;
							}
							else
							{
								num = 1238549000;
								num2 = num;
							}
							goto IL_000d;
						}
						goto IL_00d6;
					}
				}

				public void dFyvOnKBbTYzKLbxHBbiIGdcrpeH(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					while (true)
					{
						QYwkAfdRMMgAPnyPzHFUdcsKUPp();
						JIqiIfYNWcNgEfGpdhnEBWMXlMl = P_0;
						ZUoDkTcclUigIzTjeFLCXFMQOaU = P_1.actionId;
						int num = -1927142805;
						while (true)
						{
							switch (num ^ -1927142801)
							{
							case 3:
								num = -1927142803;
								continue;
							case 2:
								break;
							case 0:
								WuIXWewTRtkXNcGHNDHMpyChWRj = P_1.controllerMap.controllerId;
								OwpxKldwFjhZzSdmlfWQdFqAnKAe = P_1;
								CiEHnIGrjScHYHuMEoDVXvEgwiy = P_1.controllerMap.controllerType;
								WuIXWewTRtkXNcGHNDHMpyChWRj = P_1.controllerMap.controllerId;
								num = -1927142802;
								continue;
							case 4:
								CiEHnIGrjScHYHuMEoDVXvEgwiy = P_1.controllerMap.controllerType;
								num = -1927142801;
								continue;
							default:
								P_1.YLQJupdNdUwetJwpvvzoqLTPuCy();
								return;
							}
							break;
						}
					}
				}

				public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
				{
					JIqiIfYNWcNgEfGpdhnEBWMXlMl = null;
					ZUoDkTcclUigIzTjeFLCXFMQOaU = -1;
					OwpxKldwFjhZzSdmlfWQdFqAnKAe = null;
					CiEHnIGrjScHYHuMEoDVXvEgwiy = ControllerType.Keyboard;
					WuIXWewTRtkXNcGHNDHMpyChWRj = -1;
					ALrSUeCekIMEPeoZDaGYIdsBmIw = default(ControllerPollingInfo);
					tmDdGydFlWVbCarXzSZWfplxDpyN = ModifierKeyFlags.None;
				}

				public ElementAssignment yYMdnbTOcOMjrRGiCcoZGytydnZ(ControllerPollingInfo P_0)
				{
					ALrSUeCekIMEPeoZDaGYIdsBmIw = P_0;
					return yYMdnbTOcOMjrRGiCcoZGytydnZ();
				}

				public ElementAssignment yYMdnbTOcOMjrRGiCcoZGytydnZ(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					ALrSUeCekIMEPeoZDaGYIdsBmIw = P_0;
					while (true)
					{
						int num = 921226627;
						while (true)
						{
							switch (num ^ 0x36E8CD82)
							{
							case 0:
								break;
							case 1:
								goto IL_0025;
							default:
								return yYMdnbTOcOMjrRGiCcoZGytydnZ();
							}
							break;
							IL_0025:
							tmDdGydFlWVbCarXzSZWfplxDpyN = P_1;
							num = 921226624;
						}
					}
				}

				public ElementAssignment yYMdnbTOcOMjrRGiCcoZGytydnZ()
				{
					return new ElementAssignment(controllerType, ALrSUeCekIMEPeoZDaGYIdsBmIw.elementType, ALrSUeCekIMEPeoZDaGYIdsBmIw.elementIdentifierId, axisRange, ALrSUeCekIMEPeoZDaGYIdsBmIw.keyboardKey, tmDdGydFlWVbCarXzSZWfplxDpyN, ZUoDkTcclUigIzTjeFLCXFMQOaU, (OwpxKldwFjhZzSdmlfWQdFqAnKAe.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (OwpxKldwFjhZzSdmlfWQdFqAnKAe.actionElementMapToReplace != null) ? OwpxKldwFjhZzSdmlfWQdFqAnKAe.actionElementMapToReplace.id : (-1));
				}
			}

			private readonly InputMapper eOotmcFksuDgVSpJBCGwMaaBooj;

			private readonly Options pEIFnFEQaFUOzicvqvSVFbpPGQx = new Options();

			private readonly weGWVrUOkAjXRopXNKrSTPUkdtEg JNPjmACApSaljZJRpqnjSvfUMgz = new weGWVrUOkAjXRopXNKrSTPUkdtEg();

			private readonly Dictionary<faAxcnEMyhMvEgkmlLQaUGonSiw, SafeDelegate> IZMpIDCaOoTDpeuVuNTFPPeKSXd;

			private readonly Dictionary<string, SafeDelegate> GPtVhmAObWFmwajBToKyVWQsEHe;

			private Status PUMDGGaqFmelxRWvWgqkmjKIJclq;

			private FMAiIqJDIPAiYUEzvCnsyBexJET kOiIunTgAyfSIOMfBYUVXcHQhUo;

			private float CuMiuhtgxwNbJoXmMXScBDWycGb;

			private bool oHNQVxDqyHdtjFDQKvXSmjfkOiA;

			private List<Player> cOlEOaBUJKPlZetqtguufTyurJl = new List<Player>();

			private readonly List<ControllerPollingInfo> VLsUrsHpOjyMtocroNRgDwKjTjI = new List<ControllerPollingInfo>();

			private ElementAssignment wtfXPSKRzEnKdORAbLeZttpdoEo;

			public Status status
			{
				get
				{
					return PUMDGGaqFmelxRWvWgqkmjKIJclq;
				}
			}

			public float timeRemaining
			{
				get
				{
					if (PUMDGGaqFmelxRWvWgqkmjKIJclq == Status.Idle)
					{
						return 0f;
					}
					if (pEIFnFEQaFUOzicvqvSVFbpPGQx.timeout <= 0f)
					{
						return 0f;
					}
					return MathTools.Max(0f, CuMiuhtgxwNbJoXmMXScBDWycGb + pEIFnFEQaFUOzicvqvSVFbpPGQx.timeout - ReInput.unscaledTime);
				}
			}

			public Context context
			{
				get
				{
					if (PUMDGGaqFmelxRWvWgqkmjKIJclq == Status.Idle)
					{
						return null;
					}
					return JNPjmACApSaljZJRpqnjSvfUMgz.mappingContext;
				}
			}

			private bool checkTimer
			{
				get
				{
					if (oHNQVxDqyHdtjFDQKvXSmjfkOiA)
					{
						return false;
					}
					if (!(pEIFnFEQaFUOzicvqvSVFbpPGQx.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public ItUQksAXJzmVAthYgOGArPZuoVr(InputMapper parent, Dictionary<faAxcnEMyhMvEgkmlLQaUGonSiw, SafeDelegate> events)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (events == null)
				{
					throw new ArgumentNullException("events");
				}
				eOotmcFksuDgVSpJBCGwMaaBooj = parent;
				IZMpIDCaOoTDpeuVuNTFPPeKSXd = events;
				fdRsbcBkTGgTdtCzqFoIhThTjIkI();
			}

			~ItUQksAXJzmVAthYgOGArPZuoVr()
			{
				HAHDMLMNzLnmMNPAqVbEAdmmbQeJ();
			}

			public void gvigjQaykylkiDxmhkUQKBzXkGmr(Context P_0, Options P_1)
			{
				if (PUMDGGaqFmelxRWvWgqkmjKIJclq != Status.Idle)
				{
					uoJuMbXdlQZaUWppZdVKFIpQDKl("User started a new listening session.");
					goto IL_0013;
				}
				goto IL_0078;
				IL_0078:
				int num;
				int num2;
				if (P_0 == null)
				{
					num = -1972557893;
					num2 = num;
				}
				else
				{
					num = -1972557897;
					num2 = num;
				}
				goto IL_0018;
				IL_0013:
				num = -1972557899;
				goto IL_0018;
				IL_0018:
				Player player = default(Player);
				while (true)
				{
					switch (num ^ -1972557890)
					{
					case 8:
						break;
					case 6:
						num = -1972557889;
						continue;
					case 0:
						Options.Copy(P_1, pEIFnFEQaFUOzicvqvSVFbpPGQx);
						num = -1972557895;
						continue;
					case 11:
						goto IL_0078;
					case 2:
						return;
					case 1:
						if (ReInput.mapping.GetAction(P_0.actionId) == null)
						{
							uWppuAnRkeaYMhWYjEpjFpaVuctm("No Action found for actionId: " + P_0.actionId);
							num = -1972557892;
							continue;
						}
						goto case 12;
					case 5:
						throw new ArgumentNullException("context");
					case 9:
						if (P_0.controllerMap == null)
						{
							throw new ArgumentNullException("controllerMap");
						}
						goto case 4;
					case 10:
						P_0 = P_0.Clone();
						num = -1972557890;
						continue;
					case 4:
						if (P_1 == null)
						{
							throw new ArgumentNullException("options");
						}
						goto case 10;
					case 12:
						JNPjmACApSaljZJRpqnjSvfUMgz.dFyvOnKBbTYzKLbxHBbiIGdcrpeH(player, P_0);
						PUMDGGaqFmelxRWvWgqkmjKIJclq = Status.Listening;
						num = -1972557891;
						continue;
					case 7:
						player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
						num = -1972557896;
						continue;
					default:
						yFdpBtebWzVyJAkwHJlxAcELoqb();
						BsRQOeNhmvUQuBuTCdEMeJSPELUB();
						hpPJbHINLbcWVyElSCGrcsfzawr();
						aKEAMryUfZcJxBrNVOzebDUDHxZa();
						return;
					}
					break;
				}
				goto IL_0013;
			}

			public void iKEYBuCkLgBybRgmepySnHDkqrS(string P_0)
			{
				if (PUMDGGaqFmelxRWvWgqkmjKIJclq == Status.Idle)
				{
					while (true)
					{
						switch (0x12E684FA ^ 0x12E684F8)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				uoJuMbXdlQZaUWppZdVKFIpQDKl(P_0);
			}

			private void rdEJYvExbWYUXSDuseVgzyXPBhA(UpdateLoopType P_0)
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
					if (PUMDGGaqFmelxRWvWgqkmjKIJclq != Status.Listening)
					{
						num = -614919572;
						num2 = num;
					}
					else
					{
						num = -614919569;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -614919572)
						{
						case 6:
							num = -614919580;
							continue;
						default:
							return;
						case 3:
							if (checkTimer && timeRemaining <= 0f)
							{
								FEvJqwAHqSHoTqTIlfQGpfVEfDR();
								return;
							}
							goto case 2;
						case 7:
							eeCaOrSKJVUjLfweHOpcnQtEbLnK(elementAssignment);
							num = -614919571;
							continue;
						case 4:
							if (QPjkmYBRajwDsEbtwhheWndGASu(out elementAssignment) == YGLayqMclxGhNcZYVxvBSWFtlDW.SAnbvHBkQiQmXBqhcsEefNWVdkP)
							{
								return;
							}
							goto case 5;
						case 0:
							return;
						case 5:
							if (HxFIQRAlYsqdCEWVLiHuZFevakX(elementAssignment) == YGLayqMclxGhNcZYVxvBSWFtlDW.SAnbvHBkQiQmXBqhcsEefNWVdkP)
							{
								return;
							}
							goto case 7;
						case 8:
							break;
						case 2:
						{
							Controller controller = ReInput.controllers.GetController(JNPjmACApSaljZJRpqnjSvfUMgz.controllerType, JNPjmACApSaljZJRpqnjSvfUMgz.controllerId);
							if (controller == null)
							{
								uWppuAnRkeaYMhWYjEpjFpaVuctm(string.Concat("Controller not found for type: ", JNPjmACApSaljZJRpqnjSvfUMgz.controllerType, " id: ", JNPjmACApSaljZJRpqnjSvfUMgz.controllerId));
								return;
							}
							goto case 4;
						}
						case 1:
							return;
						}
						break;
					}
				}
			}

			private void huLDbFcfCNXRtuaevwhVfiLuQmy()
			{
				if (PUMDGGaqFmelxRWvWgqkmjKIJclq == Status.Idle)
				{
					goto IL_0008;
				}
				goto IL_0032;
				IL_0008:
				int num = 430279167;
				goto IL_000d;
				IL_000d:
				switch (num ^ 0x19A589FE)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0032;
				case 0:
					return;
				}
				goto IL_0008;
				IL_0032:
				fdRsbcBkTGgTdtCzqFoIhThTjIkI();
				HAHDMLMNzLnmMNPAqVbEAdmmbQeJ();
				xmEqecTMoxYrvZqDxhDvgqjrdWUe();
				num = 430279166;
				goto IL_000d;
			}

			private void fdRsbcBkTGgTdtCzqFoIhThTjIkI()
			{
				PUMDGGaqFmelxRWvWgqkmjKIJclq = Status.Idle;
				while (true)
				{
					int num = 391061123;
					while (true)
					{
						switch (num ^ 0x174F1E86)
						{
						case 4:
							break;
						default:
							return;
						case 5:
							CuMiuhtgxwNbJoXmMXScBDWycGb = 0f;
							pEIFnFEQaFUOzicvqvSVFbpPGQx.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
							num = 391061125;
							continue;
						case 1:
							kOiIunTgAyfSIOMfBYUVXcHQhUo = FMAiIqJDIPAiYUEzvCnsyBexJET.iOlZgcuFwLCPNAjSgaSDuxucio;
							oHNQVxDqyHdtjFDQKvXSmjfkOiA = false;
							num = 391061126;
							continue;
						case 3:
							JNPjmACApSaljZJRpqnjSvfUMgz.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
							wtfXPSKRzEnKdORAbLeZttpdoEo = default(ElementAssignment);
							num = 391061127;
							continue;
						case 0:
							cOlEOaBUJKPlZetqtguufTyurJl.Clear();
							num = 391061124;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}

			private YGLayqMclxGhNcZYVxvBSWFtlDW QPjkmYBRajwDsEbtwhheWndGASu(out ElementAssignment P_0)
			{
				IEnumerable<ControllerPollingInfo> enumerable;
				ModifierKeyFlags modifierKeyFlags;
				if (!UBjrDHDjjmnsfurcLKSttNtEntL(out enumerable, out modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return YGLayqMclxGhNcZYVxvBSWFtlDW.SAnbvHBkQiQmXBqhcsEefNWVdkP;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				using (IEnumerator<ControllerPollingInfo> enumerator = enumerable.GetEnumerator())
				{
					ControllerPollingInfo current = default(ControllerPollingInfo);
					while (true)
					{
						IL_0086:
						int num;
						int num2;
						if (enumerator.MoveNext())
						{
							num = 157455631;
							num2 = num;
						}
						else
						{
							num = 157455629;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x962950C)
							{
							case 0:
								num = 157455631;
								continue;
							default:
								goto end_IL_002c;
							case 3:
							{
								current = enumerator.Current;
								int num3;
								if (current.success)
								{
									num = 157455630;
									num3 = num;
								}
								else
								{
									num = 157455624;
									num3 = num;
								}
								continue;
							}
							case 2:
								if (!mpquVJEHSOjVnnILjVUxiRueGhs(current, pEIFnFEQaFUOzicvqvSVFbpPGQx))
								{
									controllerPollingInfo = current;
									num = 157455629;
									continue;
								}
								break;
							case 4:
								break;
							case 1:
								goto end_IL_002c;
							}
							goto IL_0086;
							continue;
							end_IL_002c:
							break;
						}
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					goto IL_00be;
				}
				int num4;
				if (!xHeZhLLLuopGMyLXrazGcEabKFQG(JNPjmACApSaljZJRpqnjSvfUMgz, controllerPollingInfo, pEIFnFEQaFUOzicvqvSVFbpPGQx))
				{
					P_0 = default(ElementAssignment);
					num4 = 157455631;
				}
				else
				{
					P_0 = JNPjmACApSaljZJRpqnjSvfUMgz.yYMdnbTOcOMjrRGiCcoZGytydnZ(controllerPollingInfo);
					P_0.modifierKeyFlags = modifierKeyFlags;
					num4 = 157455629;
				}
				goto IL_00c3;
				IL_00be:
				num4 = 157455630;
				goto IL_00c3;
				IL_00c3:
				switch (num4 ^ 0x962950C)
				{
				case 0:
					break;
				case 2:
					return YGLayqMclxGhNcZYVxvBSWFtlDW.SAnbvHBkQiQmXBqhcsEefNWVdkP;
				case 3:
					return YGLayqMclxGhNcZYVxvBSWFtlDW.SAnbvHBkQiQmXBqhcsEefNWVdkP;
				default:
					return YGLayqMclxGhNcZYVxvBSWFtlDW.IdGRGOISrELIjaPgAaovaKmAYrW;
				}
				goto IL_00be;
			}

			private bool UBjrDHDjjmnsfurcLKSttNtEntL(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = JNPjmACApSaljZJRpqnjSvfUMgz.controllerType;
				int controllerId = default(int);
				while (true)
				{
					int num = 1366780957;
					while (true)
					{
						switch (num ^ 0x51776C1A)
						{
						case 5:
							break;
						case 8:
							P_0 = JNPjmACApSaljZJRpqnjSvfUMgz.player.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
							goto case 2;
						case 1:
							P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
							goto case 2;
						case 10:
							P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
							goto case 2;
						case 9:
							if (pEIFnFEQaFUOzicvqvSVFbpPGQx.allowButtons)
							{
								int num2;
								if (JNPjmACApSaljZJRpqnjSvfUMgz.player == null)
								{
									num = 1366780955;
									num2 = num;
								}
								else
								{
									num = 1366780946;
									num2 = num;
								}
								continue;
							}
							goto default;
						case 6:
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(JNPjmACApSaljZJRpqnjSvfUMgz.controllerType, JNPjmACApSaljZJRpqnjSvfUMgz.controllerId);
							num = 1366780952;
							continue;
						case 11:
						{
							int num3;
							if (JNPjmACApSaljZJRpqnjSvfUMgz.player == null)
							{
								num = 1366780944;
								num3 = num;
							}
							else
							{
								num = 1366780953;
								num3 = num;
							}
							continue;
						}
						case 4:
							return true;
						case 7:
							controllerId = JNPjmACApSaljZJRpqnjSvfUMgz.controllerId;
							if (controllerType != ControllerType.Keyboard)
							{
								if (!pEIFnFEQaFUOzicvqvSVFbpPGQx.allowAxes)
								{
									goto case 9;
								}
								if (!pEIFnFEQaFUOzicvqvSVFbpPGQx.allowButtons)
								{
									goto case 11;
								}
								if (JNPjmACApSaljZJRpqnjSvfUMgz.player == null)
								{
									goto case 6;
								}
								P_0 = JNPjmACApSaljZJRpqnjSvfUMgz.player.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
								goto case 2;
							}
							P_0 = LiSgtfkNtVTbJVHUapVoyhJbOBH(out P_1);
							num = 1366780958;
							continue;
						case 3:
							P_0 = JNPjmACApSaljZJRpqnjSvfUMgz.player.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
							goto case 2;
						default:
							uWppuAnRkeaYMhWYjEpjFpaVuctm("You must enable listening for at least one element type.");
							P_0 = null;
							return false;
						case 2:
							return true;
						}
						break;
					}
				}
			}

			private IEnumerable<ControllerPollingInfo> LiSgtfkNtVTbJVHUapVoyhJbOBH(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				VLsUrsHpOjyMtocroNRgDwKjTjI.Clear();
				if (!pEIFnFEQaFUOzicvqvSVFbpPGQx.allowButtons)
				{
					return VLsUrsHpOjyMtocroNRgDwKjTjI;
				}
				VLsUrsHpOjyMtocroNRgDwKjTjI.Add(rzgFjfiEbYfXmRcXwgQEGNqeJwlZ(pEIFnFEQaFUOzicvqvSVFbpPGQx, out P_0));
				return VLsUrsHpOjyMtocroNRgDwKjTjI;
			}

			private ControllerPollingInfo rzgFjfiEbYfXmRcXwgQEGNqeJwlZ(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = rzgFjfiEbYfXmRcXwgQEGNqeJwlZ(P_0, out flag, out P_1, out text);
				if (flag)
				{
					yFdpBtebWzVyJAkwHJlxAcELoqb();
				}
				return result;
			}

			private static ControllerPollingInfo rzgFjfiEbYfXmRcXwgQEGNqeJwlZ(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_3 = string.Empty;
				P_1 = false;
				int num3 = default(int);
				ControllerPollingInfo result3 = default(ControllerPollingInfo);
				while (true)
				{
					int num = -1155399075;
					while (true)
					{
						ControllerPollingInfo result;
						ControllerPollingInfo result2;
						ModifierKeyFlags modifierKeyFlags;
						int num6;
						switch (num ^ -1155399076)
						{
						case 0:
							break;
						case 1:
							goto IL_0028;
						default:
							{
								result = default(ControllerPollingInfo);
								result2 = default(ControllerPollingInfo);
								modifierKeyFlags = ModifierKeyFlags.None;
								using (IEnumerator<ControllerPollingInfo> enumerator = ReInput.controllers.Keyboard.PollForAllKeys().GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										while (true)
										{
											ControllerPollingInfo current = enumerator.Current;
											KeyCode keyboardKey = current.keyboardKey;
											int num2 = -1155399078;
											while (true)
											{
												switch (num2 ^ -1155399076)
												{
												case 7:
													num2 = -1155399079;
													continue;
												case 1:
													break;
												case 2:
													if (num3 == 0)
													{
														result2 = current;
														num2 = -1155399080;
														continue;
													}
													goto case 4;
												case 4:
													modifierKeyFlags |= Keyboard.KeyCodeToModifierKeyFlags(keyboardKey);
													num3++;
													num2 = -1155399073;
													continue;
												case 0:
													result = current;
													num2 = -1155399073;
													continue;
												case 5:
													goto end_IL_0066;
												case 6:
													goto IL_00f8;
												default:
													goto end_IL_00dc;
												}
												int num4;
												if (result.keyboardKey != KeyCode.None)
												{
													num2 = -1155399073;
													num4 = num2;
												}
												else
												{
													num2 = -1155399076;
													num4 = num2;
												}
												continue;
												IL_00f8:
												if (keyboardKey == KeyCode.AltGr)
												{
													goto end_IL_00dc;
												}
												int num5;
												if (Keyboard.IsModifierKey(current.keyboardKey))
												{
													num2 = -1155399074;
													num5 = num2;
												}
												else
												{
													num2 = -1155399075;
													num5 = num2;
												}
												continue;
												end_IL_0066:
												break;
											}
											continue;
											end_IL_00dc:
											break;
										}
									}
								}
								if (result.keyboardKey != KeyCode.None)
								{
									goto IL_0146;
								}
								if (num3 > 0)
								{
									P_1 = true;
									if (num3 == 1)
									{
										if (P_0.allowKeyboardModifierKeyAsPrimary)
										{
											if (!P_0.allowKeyboardKeysWithModifiers)
											{
												goto IL_0199;
											}
											if (P_0.holdDurationToMapKeyboardModifierKeyAsPrimary <= 0f)
											{
												num6 = -1155399077;
												goto IL_014b;
											}
											if (ReInput.controllers.Keyboard.GetKeyTimePressed(result2.keyboardKey) >= P_0.holdDurationToMapKeyboardModifierKeyAsPrimary)
											{
												return result2;
											}
										}
										P_3 = Keyboard.GetKeyName(result2.keyboardKey);
										num6 = -1155399075;
										goto IL_014b;
									}
									goto IL_0183;
								}
								goto IL_023f;
							}
							IL_014b:
							while (true)
							{
								switch (num6 ^ -1155399076)
								{
								case 0:
									break;
								case 8:
									goto IL_0183;
								case 1:
									num6 = -1155399078;
									continue;
								case 7:
									goto IL_0199;
								case 3:
									goto IL_01f6;
								case 9:
									return result;
								case 6:
									goto IL_023f;
								case 4:
									goto IL_0251;
								case 2:
									return default(ControllerPollingInfo);
								default:
									return result3;
								}
								break;
								IL_0251:
								if (!ReInput.controllers.Keyboard.GetKeyDown(result.keyboardKey))
								{
									num6 = -1155399074;
									continue;
								}
								if (num3 != 0)
								{
									if (P_0.allowKeyboardKeysWithModifiers)
									{
										P_2 = modifierKeyFlags;
										num6 = -1155399083;
									}
									else
									{
										num6 = -1155399073;
									}
									continue;
								}
								goto IL_01f6;
								IL_01f6:
								return result;
							}
							goto IL_0146;
							IL_0199:
							if (!ReInput.controllers.Keyboard.GetKeyDown(result2.keyboardKey))
							{
								return default(ControllerPollingInfo);
							}
							return result2;
							IL_0183:
							P_3 = Keyboard.ModifierKeyFlagsToString(modifierKeyFlags);
							num6 = -1155399078;
							goto IL_014b;
							IL_0146:
							num6 = -1155399080;
							goto IL_014b;
							IL_023f:
							result3 = default(ControllerPollingInfo);
							num6 = -1155399079;
							goto IL_014b;
						}
						break;
						IL_0028:
						P_2 = ModifierKeyFlags.None;
						num3 = 0;
						num = -1155399074;
					}
				}
			}

			private static bool mpquVJEHSOjVnnILjVUxiRueGhs(ControllerPollingInfo P_0, Options P_1)
			{
				if (!P_1.allowAxes)
				{
					goto IL_000b;
				}
				goto IL_00a1;
				IL_000b:
				int num = 1726529137;
				goto IL_0010;
				IL_0010:
				while (true)
				{
					switch (num ^ 0x66E8BE70)
					{
					case 7:
						break;
					case 6:
						goto IL_0040;
					case 3:
						goto IL_0051;
					case 0:
						return false;
					case 1:
						goto IL_008c;
					case 5:
						return false;
					case 4:
						goto IL_00b3;
					default:
						return true;
					}
					break;
					IL_008c:
					if (P_0.elementType == ControllerElementType.Axis)
					{
						num = 1726529141;
						continue;
					}
					goto IL_00a1;
					IL_00b3:
					if (P_1.ignoreMouseXAxis)
					{
						return true;
					}
					goto IL_00d1;
					IL_0051:
					switch (P_0.elementIndex)
					{
					case 0:
						break;
					case 1:
						goto IL_00bd;
					default:
						goto IL_00d1;
					}
					goto IL_00b3;
					IL_00bd:
					if (P_1.ignoreMouseYAxis)
					{
						num = 1726529138;
						continue;
					}
					goto IL_00d1;
					IL_0040:
					if (P_0.elementType == ControllerElementType.Button)
					{
						num = 1726529136;
						continue;
					}
					goto IL_0072;
				}
				goto IL_000b;
				IL_00d1:
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.CGpBWVWneghQHaJmUgivxiynrQN<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
				IL_0072:
				if (P_0.controllerType == ControllerType.Mouse && P_0.elementType == ControllerElementType.Axis)
				{
					num = 1726529139;
					goto IL_0010;
				}
				goto IL_00d1;
				IL_00a1:
				if (!P_1.allowButtons)
				{
					num = 1726529142;
					goto IL_0010;
				}
				goto IL_0072;
			}

			private static bool xHeZhLLLuopGMyLXrazGcEabKFQG(weGWVrUOkAjXRopXNKrSTPUkdtEg P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					goto IL_0008;
				}
				int num;
				if (P_0.axisRange == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment)
				{
					num = 1089658375;
					goto IL_000d;
				}
				goto IL_004b;
				IL_000d:
				switch (num ^ 0x40F2DE05)
				{
				case 0:
					break;
				case 1:
					return true;
				default:
					goto IL_003f;
				}
				goto IL_0008;
				IL_0008:
				num = 1089658372;
				goto IL_000d;
				IL_003f:
				if (P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				goto IL_004b;
				IL_004b:
				return true;
			}

			private void BsRQOeNhmvUQuBuTCdEMeJSPELUB()
			{
				if (!pEIFnFEQaFUOzicvqvSVFbpPGQx.checkForConflicts)
				{
					goto IL_0010;
				}
				goto IL_01f8;
				IL_0010:
				int num = 920372670;
				goto IL_0015;
				IL_0015:
				IList<Player> players = default(IList<Player>);
				int num3 = default(int);
				IList<Player> allPlayers = default(IList<Player>);
				int count = default(int);
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x36DBC5B3)
					{
					case 7:
						break;
					default:
						return;
					case 1:
						goto IL_0065;
					case 0:
						players = ReInput.players.Players;
						num3 = 0;
						num = 920372657;
						continue;
					case 15:
						goto IL_009a;
					case 14:
						goto IL_00b3;
					case 3:
						if (pEIFnFEQaFUOzicvqvSVFbpPGQx.checkForConflictsWithPlayerIds != null)
						{
							allPlayers = ReInput.players.AllPlayers;
							count = allPlayers.Count;
							num2 = 0;
							num = 920372668;
							continue;
						}
						return;
					case 8:
						ListTools.AddIfUnique(cOlEOaBUJKPlZetqtguufTyurJl, players[num3]);
						num3++;
						num = 920372657;
						continue;
					case 4:
						goto IL_0136;
					case 10:
						ListTools.AddIfUnique(cOlEOaBUJKPlZetqtguufTyurJl, allPlayers[num2]);
						num = 920372671;
						continue;
					case 13:
						return;
					case 9:
						if (JNPjmACApSaljZJRpqnjSvfUMgz.player != null)
						{
							ListTools.AddIfUnique(cOlEOaBUJKPlZetqtguufTyurJl, JNPjmACApSaljZJRpqnjSvfUMgz.player);
							num = 920372658;
							continue;
						}
						goto IL_0065;
					case 2:
						if (num3 >= players.Count)
						{
							return;
						}
						goto case 8;
					case 12:
						num2++;
						num = 920372668;
						continue;
					case 11:
						ListTools.AddIfUnique(cOlEOaBUJKPlZetqtguufTyurJl, ReInput.players.SystemPlayer);
						num = 920372663;
						continue;
					case 5:
						goto IL_01f8;
					case 6:
						return;
					}
					break;
					IL_0136:
					int num4;
					if (pEIFnFEQaFUOzicvqvSVFbpPGQx.checkForConflictsWithAllPlayers)
					{
						num = 920372659;
						num4 = num;
					}
					else
					{
						num = 920372656;
						num4 = num;
					}
					continue;
					IL_009a:
					int num5;
					if (num2 < count)
					{
						num = 920372669;
						num5 = num;
					}
					else
					{
						num = 920372661;
						num5 = num;
					}
					continue;
					IL_0065:
					int num6;
					if (!pEIFnFEQaFUOzicvqvSVFbpPGQx.checkForConflictsWithSystemPlayer)
					{
						num = 920372663;
						num6 = num;
					}
					else
					{
						num = 920372664;
						num6 = num;
					}
					continue;
					IL_00b3:
					int num7;
					if (!ArrayTools.Contains(pEIFnFEQaFUOzicvqvSVFbpPGQx.checkForConflictsWithPlayerIds, allPlayers[num2].id))
					{
						num = 920372671;
						num7 = num;
					}
					else
					{
						num = 920372665;
						num7 = num;
					}
				}
				goto IL_0010;
				IL_01f8:
				int num8;
				if (!pEIFnFEQaFUOzicvqvSVFbpPGQx.checkForConflictsWithSelf)
				{
					num = 920372658;
					num8 = num;
				}
				else
				{
					num = 920372666;
					num8 = num;
				}
				goto IL_0015;
			}

			private YGLayqMclxGhNcZYVxvBSWFtlDW HxFIQRAlYsqdCEWVLiHuZFevakX(ElementAssignment P_0)
			{
				if (pEIFnFEQaFUOzicvqvSVFbpPGQx.checkForConflicts && JNPjmACApSaljZJRpqnjSvfUMgz.player != null)
				{
					while (true)
					{
						int num = -492989298;
						while (true)
						{
							switch (num ^ -492989300)
							{
							case 0:
								break;
							case 2:
								goto IL_0038;
							default:
								return RVNggLInQicyCtUaZAZgTuDDdsvb(P_0);
							}
							break;
							IL_0038:
							if (!thHJzcEfQWGYIfdeUXrUiraEpnnP(JNPjmACApSaljZJRpqnjSvfUMgz, P_0, cOlEOaBUJKPlZetqtguufTyurJl))
							{
								goto end_IL_001a;
							}
							num = -492989299;
						}
						continue;
						end_IL_001a:
						break;
					}
				}
				return YGLayqMclxGhNcZYVxvBSWFtlDW.IdGRGOISrELIjaPgAaovaKmAYrW;
			}

			private static bool thHJzcEfQWGYIfdeUXrUiraEpnnP(weGWVrUOkAjXRopXNKrSTPUkdtEg P_0, ElementAssignment P_1, List<Player> P_2)
			{
				int num;
				if (P_0 != null)
				{
					if (P_0.player == null)
					{
						goto IL_000b;
					}
					int num2;
					if (P_2 != null)
					{
						num = -2021135408;
						num2 = num;
					}
					else
					{
						num = -2021135404;
						num2 = num;
					}
					goto IL_0010;
				}
				goto IL_0067;
				IL_0010:
				int num3 = default(int);
				ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
				while (true)
				{
					switch (num ^ -2021135408)
					{
					case 5:
						break;
					case 3:
						return false;
					case 0:
						goto IL_0044;
					case 4:
						return false;
					case 1:
						goto IL_0067;
					case 2:
						goto IL_007d;
					default:
						if (num3 >= P_2.Count)
						{
							return false;
						}
						goto IL_007d;
					}
					break;
					IL_007d:
					if (P_2[num3].controllers.conflictChecking.DoesElementAssignmentConflict(conflictCheck))
					{
						return true;
					}
					num3++;
					num = -2021135402;
					continue;
					IL_0044:
					if (P_2.Count == 0)
					{
						num = -2021135404;
					}
					else if (HyQgbwDJdTfSeFOnYjcQNRoSNYOK(P_0, P_1, out conflictCheck))
					{
						num3 = 0;
						num = -2021135402;
					}
					else
					{
						num = -2021135405;
					}
				}
				goto IL_000b;
				IL_000b:
				num = -2021135407;
				goto IL_0010;
				IL_0067:
				return false;
			}

			private static bool NbJjNUekfdatnDxHtRmnFZLdssJj(weGWVrUOkAjXRopXNKrSTPUkdtEg P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 != null)
				{
					int num2 = default(int);
					ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
					while (true)
					{
						int num = -1549830260;
						while (true)
						{
							switch (num ^ -1549830263)
							{
							case 2:
								break;
							case 1:
								goto IL_0031;
							case 4:
								goto end_IL_0003;
							case 6:
								return false;
							case 5:
								goto IL_0070;
							default:
								foreach (ElementAssignmentConflictInfo item in P_2[num2].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck))
								{
									if (!item.isUserAssignable)
									{
										return true;
									}
								}
								num2++;
								goto case 3;
							case 3:
								if (num2 >= P_2.Count)
								{
									return false;
								}
								goto default;
							}
							break;
							IL_0070:
							if (P_0.player != null)
							{
								if (P_2 != null)
								{
									if (P_2.Count != 0)
									{
										if (!HyQgbwDJdTfSeFOnYjcQNRoSNYOK(P_0, P_1, out conflictCheck))
										{
											num = -1549830257;
											continue;
										}
										num2 = 0;
										num = -1549830262;
									}
									else
									{
										num = -1549830264;
									}
									continue;
								}
								goto IL_0031;
							}
							num = -1549830259;
							continue;
							IL_0031:
							return false;
						}
						continue;
						end_IL_0003:
						break;
					}
				}
				return false;
			}

			private static IList<ElementAssignmentConflictInfo> okXLhrAZbMLCNsloeWTUkIYXmvH(weGWVrUOkAjXRopXNKrSTPUkdtEg P_0, ElementAssignment P_1, List<Player> P_2)
			{
				ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
				int num;
				List<ElementAssignmentConflictInfo> list = default(List<ElementAssignmentConflictInfo>);
				if (P_0 != null)
				{
					if (P_0.player == null)
					{
						goto IL_000b;
					}
					if (P_2 != null)
					{
						if (P_2.Count != 0)
						{
							if (!HyQgbwDJdTfSeFOnYjcQNRoSNYOK(P_0, P_1, out conflictCheck))
							{
								num = 2005661099;
							}
							else
							{
								list = new List<ElementAssignmentConflictInfo>();
								num = 2005661098;
							}
						}
						else
						{
							num = 2005661096;
						}
						goto IL_0010;
					}
					goto IL_0043;
				}
				goto IL_0057;
				IL_0057:
				return null;
				IL_0043:
				return null;
				IL_000b:
				num = 2005661101;
				goto IL_0010;
				IL_0010:
				int num2 = default(int);
				int num3;
				switch (num ^ 0x778BF5A9)
				{
				case 5:
					break;
				case 3:
					num2 = 0;
					goto IL_011c;
				case 1:
					goto IL_0043;
				case 4:
					goto IL_0057;
				case 2:
					return null;
				default:
					{
						using (IEnumerator<ElementAssignmentConflictInfo> enumerator = P_2[num2].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck).GetEnumerator())
						{
							while (true)
							{
								IL_00d2:
								int num4;
								int num5;
								if (!enumerator.MoveNext())
								{
									num4 = 2005661097;
									num5 = num4;
								}
								else
								{
									num4 = 2005661096;
									num5 = num4;
								}
								while (true)
								{
									switch (num4 ^ 0x778BF5A9)
									{
									case 2:
										num4 = 2005661096;
										continue;
									default:
										goto end_IL_009f;
									case 1:
									{
										ElementAssignmentConflictInfo current = enumerator.Current;
										list.Add(current);
										num4 = 2005661098;
										continue;
									}
									case 3:
										break;
									case 0:
										goto end_IL_009f;
									}
									goto IL_00d2;
									continue;
									end_IL_009f:
									break;
								}
								break;
							}
						}
						num2++;
						goto IL_00fe;
					}
					IL_011c:
					if (num2 < P_2.Count)
					{
						goto default;
					}
					num3 = 2005661097;
					goto IL_0103;
					IL_00fe:
					num3 = 2005661096;
					goto IL_0103;
					IL_0103:
					switch (num3 ^ 0x778BF5A9)
					{
					case 2:
						break;
					case 1:
						goto IL_011c;
					default:
						return list;
					}
					goto IL_00fe;
				}
				goto IL_000b;
			}

			private static bool HyQgbwDJdTfSeFOnYjcQNRoSNYOK(weGWVrUOkAjXRopXNKrSTPUkdtEg P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				int num;
				if (P_0 != null)
				{
					Player player;
					if ((player = P_0.player) == null)
					{
						goto IL_0013;
					}
					P_2 = P_1.ToElementAssignmentConflictCheck();
					P_2.playerId = player.id;
					num = -1789061072;
					goto IL_0018;
				}
				goto IL_00be;
				IL_0018:
				while (true)
				{
					switch (num ^ -1789061069)
					{
					case 4:
						break;
					case 2:
						P_2.elementMapId = P_0.mappingContext.actionElementMapToReplace.id;
						num = -1789061069;
						continue;
					case 3:
						goto IL_0059;
					case 1:
						goto IL_00be;
					default:
						return true;
					}
					break;
					IL_0059:
					P_2.controllerType = P_0.controllerType;
					P_2.controllerId = P_0.controllerId;
					P_2.controllerMapId = P_0.mappingContext.controllerMap.id;
					P_2.controllerMapCategoryId = P_0.mappingContext.controllerMap.categoryId;
					int num2;
					if (P_0.mappingContext.actionElementMapToReplace != null)
					{
						num = -1789061071;
						num2 = num;
					}
					else
					{
						num = -1789061069;
						num2 = num;
					}
				}
				goto IL_0013;
				IL_00be:
				P_2 = default(ElementAssignmentConflictCheck);
				return false;
				IL_0013:
				num = -1789061070;
				goto IL_0018;
			}

			private static void bXPaGRhfTtjoCcLvPvsSpOjmKakb(weGWVrUOkAjXRopXNKrSTPUkdtEg P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 != null)
				{
					if (P_0.player == null)
					{
						goto IL_000b;
					}
					goto IL_0042;
				}
				return;
				IL_0039:
				int num = 0;
				int num2 = 1141656051;
				goto IL_0010;
				IL_000b:
				num2 = 1141656052;
				goto IL_0010;
				IL_0010:
				ElementAssignmentConflictCheck conflictCheck = default(ElementAssignmentConflictCheck);
				while (true)
				{
					switch (num2 ^ 0x440C49F6)
					{
					case 4:
						break;
					case 3:
						goto IL_0039;
					case 1:
						goto IL_0042;
					case 2:
						return;
					case 0:
						P_2[num].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
						num++;
						num2 = 1141656051;
						continue;
					case 6:
						return;
					default:
						if (num >= P_2.Count)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
				goto IL_000b;
				IL_0042:
				if (!HyQgbwDJdTfSeFOnYjcQNRoSNYOK(P_0, P_1, out conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					num2 = 1141656048;
					goto IL_0010;
				}
				goto IL_0039;
			}

			private void hpPJbHINLbcWVyElSCGrcsfzawr()
			{
				ReInput.UpdateEndedEvent -= rdEJYvExbWYUXSDuseVgzyXPBhA;
				ReInput.UpdateEndedEvent += rdEJYvExbWYUXSDuseVgzyXPBhA;
			}

			private void HAHDMLMNzLnmMNPAqVbEAdmmbQeJ()
			{
				ReInput.UpdateEndedEvent -= rdEJYvExbWYUXSDuseVgzyXPBhA;
			}

			private bool yfPkTALFeHxyOKxQTCyDRbWXalb(faAxcnEMyhMvEgkmlLQaUGonSiw P_0)
			{
				SafeDelegate safeDelegate = IZMpIDCaOoTDpeuVuNTFPPeKSXd[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void XaHrQjGBFFshbJoEZXjfIBsPkOo<T>(faAxcnEMyhMvEgkmlLQaUGonSiw P_0, T P_1)
			{
				SafeAction<T> safeAction = (SafeAction<T>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[P_0];
				while (true)
				{
					int num = 520467460;
					while (true)
					{
						switch (num ^ 0x1F05B400)
						{
						case 0:
							break;
						default:
							return;
						case 4:
						{
							int num2;
							if (safeAction.Count != 0)
							{
								num = 520467459;
								num2 = num;
							}
							else
							{
								num = 520467458;
								num2 = num;
							}
							continue;
						}
						case 2:
							return;
						case 3:
							safeAction.Invoke(P_1);
							num = 520467457;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}

			private void yFdpBtebWzVyJAkwHJlxAcELoqb()
			{
				CuMiuhtgxwNbJoXmMXScBDWycGb = ReInput.unscaledTime;
			}

			private void mPininuPFKlQNQlufTFfTJmHAVSa()
			{
				oHNQVxDqyHdtjFDQKvXSmjfkOiA = true;
			}

			private void jIRMULSacHcJqIhzJDbNgtCHCrTK(ActionElementMap P_0)
			{
				VytchDPqPObShosYPgcZCvrsiIui(P_0);
				huLDbFcfCNXRtuaevwhVfiLuQmy();
			}

			private void uoJuMbXdlQZaUWppZdVKFIpQDKl(string P_0)
			{
				YmaAJdwxARBjthXGSFEFVMikuyZ(P_0);
				huLDbFcfCNXRtuaevwhVfiLuQmy();
			}

			private YGLayqMclxGhNcZYVxvBSWFtlDW RVNggLInQicyCtUaZAZgTuDDdsvb(ElementAssignment P_0)
			{
				if (yfPkTALFeHxyOKxQTCyDRbWXalb(faAxcnEMyhMvEgkmlLQaUGonSiw.grqEvWbQoBkhrWeSJPfnUhwcWDt))
				{
					while (true)
					{
						int num = -1170125284;
						while (true)
						{
							switch (num ^ -1170125282)
							{
							case 0:
								break;
							case 2:
								goto IL_0027;
							default:
								return YGLayqMclxGhNcZYVxvBSWFtlDW.SAnbvHBkQiQmXBqhcsEefNWVdkP;
							}
							break;
							IL_0027:
							bool flag = NbJjNUekfdatnDxHtRmnFZLdssJj(JNPjmACApSaljZJRpqnjSvfUMgz, P_0, cOlEOaBUJKPlZetqtguufTyurJl);
							wtfXPSKRzEnKdORAbLeZttpdoEo = P_0;
							IList<ElementAssignmentConflictInfo> list = okXLhrAZbMLCNsloeWTUkIYXmvH(JNPjmACApSaljZJRpqnjSvfUMgz, P_0, cOlEOaBUJKPlZetqtguufTyurJl);
							kOiIunTgAyfSIOMfBYUVXcHQhUo = FMAiIqJDIPAiYUEzvCnsyBexJET.GxUdsbfTrrVJADmoPKaSbaNVeuz;
							jqqGUmdIxJDbhgatInxNbBqlndtI();
							KgfGPHZGGecSljNlNLxpxMXpzSUf(new ElementAssignmentInfo(JNPjmACApSaljZJRpqnjSvfUMgz.mappingContext.controllerMap, P_0), list, flag);
							num = -1170125281;
						}
					}
				}
				return fwNHIzPEXsgpDHhVrzGmiBXVhvMp(pEIFnFEQaFUOzicvqvSVFbpPGQx.defaultActionWhenConflictFound, P_0);
			}

			private YGLayqMclxGhNcZYVxvBSWFtlDW fwNHIzPEXsgpDHhVrzGmiBXVhvMp(ConflictResponse P_0, ElementAssignment P_1)
			{
				return fwNHIzPEXsgpDHhVrzGmiBXVhvMp(P_0, P_1, NbJjNUekfdatnDxHtRmnFZLdssJj(JNPjmACApSaljZJRpqnjSvfUMgz, P_1, cOlEOaBUJKPlZetqtguufTyurJl));
			}

			private YGLayqMclxGhNcZYVxvBSWFtlDW fwNHIzPEXsgpDHhVrzGmiBXVhvMp(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				while (true)
				{
					int num = -1701153240;
					while (true)
					{
						switch (num ^ -1701153237)
						{
						case 0:
							break;
						case 3:
							switch (P_0)
							{
							case ConflictResponse.Add:
								return YGLayqMclxGhNcZYVxvBSWFtlDW.IdGRGOISrELIjaPgAaovaKmAYrW;
							case ConflictResponse.Ignore:
								ggMwaeannHxRnWUNAUhzimAEhnd();
								num = -1701153233;
								continue;
							case ConflictResponse.Cancel:
								break;
							case ConflictResponse.Replace:
								if (!P_2)
								{
									bXPaGRhfTtjoCcLvPvsSpOjmKakb(JNPjmACApSaljZJRpqnjSvfUMgz, P_1, cOlEOaBUJKPlZetqtguufTyurJl);
									return YGLayqMclxGhNcZYVxvBSWFtlDW.IdGRGOISrELIjaPgAaovaKmAYrW;
								}
								uoJuMbXdlQZaUWppZdVKFIpQDKl("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
								num = -1701153239;
								continue;
							default:
								throw new NotImplementedException();
							}
							goto case 1;
						case 2:
							return YGLayqMclxGhNcZYVxvBSWFtlDW.SAnbvHBkQiQmXBqhcsEefNWVdkP;
						case 1:
							uoJuMbXdlQZaUWppZdVKFIpQDKl("Mapping assignment was canceled due to a conflict.");
							return YGLayqMclxGhNcZYVxvBSWFtlDW.SAnbvHBkQiQmXBqhcsEefNWVdkP;
						default:
							return YGLayqMclxGhNcZYVxvBSWFtlDW.SAnbvHBkQiQmXBqhcsEefNWVdkP;
						}
						break;
					}
				}
			}

			private void FEvJqwAHqSHoTqTIlfQGpfVEfDR()
			{
				JcIMDqfwWjixOxuAYllPyrPxSXt();
				huLDbFcfCNXRtuaevwhVfiLuQmy();
			}

			private void uWppuAnRkeaYMhWYjEpjFpaVuctm(string P_0)
			{
				mqGgtsIVfhxctrZFVjsJmGAiRPVO(P_0);
				huLDbFcfCNXRtuaevwhVfiLuQmy();
			}

			private void jqqGUmdIxJDbhgatInxNbBqlndtI()
			{
				mPininuPFKlQNQlufTFfTJmHAVSa();
				HAHDMLMNzLnmMNPAqVbEAdmmbQeJ();
				PUMDGGaqFmelxRWvWgqkmjKIJclq = Status.AwaitingResponse;
			}

			private void ggMwaeannHxRnWUNAUhzimAEhnd()
			{
				PUMDGGaqFmelxRWvWgqkmjKIJclq = Status.Listening;
				kOiIunTgAyfSIOMfBYUVXcHQhUo = FMAiIqJDIPAiYUEzvCnsyBexJET.iOlZgcuFwLCPNAjSgaSDuxucio;
				yFdpBtebWzVyJAkwHJlxAcELoqb();
				hpPJbHINLbcWVyElSCGrcsfzawr();
			}

			private void eeCaOrSKJVUjLfweHOpcnQtEbLnK(ElementAssignment P_0)
			{
				ActionElementMap result;
				if (JNPjmACApSaljZJRpqnjSvfUMgz.mappingContext.controllerMap.ReplaceOrCreateElementMap(P_0, out result))
				{
					goto IL_001a;
				}
				goto IL_004b;
				IL_001a:
				int num = 604212326;
				goto IL_001f;
				IL_001f:
				switch (num ^ 0x24038C67)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					jIRMULSacHcJqIhzJDbNgtCHCrTK(result);
					return;
				case 2:
					goto IL_004b;
				case 3:
					return;
				}
				goto IL_001a;
				IL_004b:
				uWppuAnRkeaYMhWYjEpjFpaVuctm("Failed to create element assignment.");
				num = 604212324;
				goto IL_001f;
			}

			private void VytchDPqPObShosYPgcZCvrsiIui(ActionElementMap P_0)
			{
				if (!yfPkTALFeHxyOKxQTCyDRbWXalb(faAxcnEMyhMvEgkmlLQaUGonSiw.xAPQdNJoHdLlriIRSdcQlihMhVf))
				{
					while (true)
					{
						switch (0x27C0CABF ^ 0x27C0CABE)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				XaHrQjGBFFshbJoEZXjfIBsPkOo(faAxcnEMyhMvEgkmlLQaUGonSiw.xAPQdNJoHdLlriIRSdcQlihMhVf, new InputMappedEventData(eOotmcFksuDgVSpJBCGwMaaBooj, P_0));
			}

			private void JcIMDqfwWjixOxuAYllPyrPxSXt()
			{
				if (!yfPkTALFeHxyOKxQTCyDRbWXalb(faAxcnEMyhMvEgkmlLQaUGonSiw.oVKApXvPXTQVqIawNRPcUMAelYY))
				{
					while (true)
					{
						switch (-2012710333 ^ -2012710334)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				XaHrQjGBFFshbJoEZXjfIBsPkOo(faAxcnEMyhMvEgkmlLQaUGonSiw.oVKApXvPXTQVqIawNRPcUMAelYY, new TimedOutEventData(eOotmcFksuDgVSpJBCGwMaaBooj));
			}

			private void mqGgtsIVfhxctrZFVjsJmGAiRPVO(string P_0)
			{
				if (!yfPkTALFeHxyOKxQTCyDRbWXalb(faAxcnEMyhMvEgkmlLQaUGonSiw.grUBokGUZoYzRePQzgyPslflUhm))
				{
					return;
				}
				while (true)
				{
					XaHrQjGBFFshbJoEZXjfIBsPkOo(faAxcnEMyhMvEgkmlLQaUGonSiw.grUBokGUZoYzRePQzgyPslflUhm, new ErrorEventData(eOotmcFksuDgVSpJBCGwMaaBooj, P_0));
					int num = 1041803763;
					while (true)
					{
						switch (num ^ 0x3E18A9F3)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = 1041803762;
					}
				}
			}

			private void YmaAJdwxARBjthXGSFEFVMikuyZ(string P_0)
			{
				if (!yfPkTALFeHxyOKxQTCyDRbWXalb(faAxcnEMyhMvEgkmlLQaUGonSiw.ZhBjTyGHBmJlWBqUKVYQKMXyEaL))
				{
					while (true)
					{
						switch (0x4DBE025A ^ 0x4DBE0258)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				XaHrQjGBFFshbJoEZXjfIBsPkOo(faAxcnEMyhMvEgkmlLQaUGonSiw.ZhBjTyGHBmJlWBqUKVYQKMXyEaL, new CanceledEventData(eOotmcFksuDgVSpJBCGwMaaBooj, P_0));
			}

			private void KgfGPHZGGecSljNlNLxpxMXpzSUf(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				if (yfPkTALFeHxyOKxQTCyDRbWXalb(faAxcnEMyhMvEgkmlLQaUGonSiw.grqEvWbQoBkhrWeSJPfnUhwcWDt))
				{
					XaHrQjGBFFshbJoEZXjfIBsPkOo(faAxcnEMyhMvEgkmlLQaUGonSiw.grqEvWbQoBkhrWeSJPfnUhwcWDt, new ConflictFoundEventData(eOotmcFksuDgVSpJBCGwMaaBooj, MuibUqGXMaSFQfgpEbSLWxnokfZw, P_0, P_1, P_2));
				}
			}

			private void aKEAMryUfZcJxBrNVOzebDUDHxZa()
			{
				if (!yfPkTALFeHxyOKxQTCyDRbWXalb(faAxcnEMyhMvEgkmlLQaUGonSiw.racJEwnVOzQXhmYAxvkeyHURrNS))
				{
					while (true)
					{
						switch (-1267923445 ^ -1267923446)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				XaHrQjGBFFshbJoEZXjfIBsPkOo(faAxcnEMyhMvEgkmlLQaUGonSiw.racJEwnVOzQXhmYAxvkeyHURrNS, new StartedEventData(eOotmcFksuDgVSpJBCGwMaaBooj));
			}

			private void xmEqecTMoxYrvZqDxhDvgqjrdWUe()
			{
				if (yfPkTALFeHxyOKxQTCyDRbWXalb(faAxcnEMyhMvEgkmlLQaUGonSiw.lZfOpoEACbElLnFflcCbeRwfKGs))
				{
					XaHrQjGBFFshbJoEZXjfIBsPkOo(faAxcnEMyhMvEgkmlLQaUGonSiw.lZfOpoEACbElLnFflcCbeRwfKGs, new StoppedEventData(eOotmcFksuDgVSpJBCGwMaaBooj));
				}
			}

			public void MuibUqGXMaSFQfgpEbSLWxnokfZw(ConflictResponse P_0)
			{
				if (PUMDGGaqFmelxRWvWgqkmjKIJclq == Status.AwaitingResponse)
				{
					while (true)
					{
						int num = -1327326096;
						while (true)
						{
							switch (num ^ -1327326095)
							{
							case 2:
								break;
							case 1:
								goto IL_0027;
							default:
								goto end_IL_0009;
							}
							break;
							IL_0027:
							if (kOiIunTgAyfSIOMfBYUVXcHQhUo != FMAiIqJDIPAiYUEzvCnsyBexJET.GxUdsbfTrrVJADmoPKaSbaNVeuz)
							{
								num = -1327326095;
								continue;
							}
							try
							{
								if (fwNHIzPEXsgpDHhVrzGmiBXVhvMp(P_0, wtfXPSKRzEnKdORAbLeZttpdoEo) != YGLayqMclxGhNcZYVxvBSWFtlDW.IdGRGOISrELIjaPgAaovaKmAYrW)
								{
									return;
								}
								while (true)
								{
									int num2 = -1327326096;
									while (true)
									{
										switch (num2 ^ -1327326095)
										{
										case 2:
											break;
										default:
											return;
										case 1:
											goto IL_0070;
										case 0:
											return;
										}
										break;
										IL_0070:
										eeCaOrSKJVUjLfweHOpcnQtEbLnK(wtfXPSKRzEnKdORAbLeZttpdoEo);
										num2 = -1327326095;
									}
								}
							}
							catch (Exception ex)
							{
								Logger.LogError("An exception occurred in the conflict check user response callback.\n" + ex);
								return;
							}
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
			}
		}

		public class Options
		{
			internal const string vZmwsVsKJHjjIKRjoWOAIqVcXTU = "isElementAllowed";

			private bool GNvYGbrvlBrbsHaGbJnHFgbcoVk = true;

			private bool YWccXogsLNFrzzoDFcRUbjTfyJZj = true;

			private bool EvnCRDavIWBdJbAOGSyjHxTitpys = true;

			private float pgvMRONrQcRUVDIcMssWPnqKGRxi;

			private bool EJYEtrQkGiAvHuiYYRLrQdCEisw = true;

			private bool yZqSQcijlnsBljmatwuAyCMydCVe = true;

			private bool weyQoRcqtqOfoUPWnQcLfkMkDLG = true;

			private bool ibqRkbukiOYxPAqLswQlTuaGuWd = true;

			private int[] ulkaenzXqygwyHGNPlyDWNbFpHr;

			private ConflictResponse URaHotyudAxKEHpEgOctmPLCSrd = ConflictResponse.Replace;

			private bool BwOVycPVcgtFmKhvaYOzoTilwIv;

			private bool loYNGKmMTpVVpVkdwFTpqXCGBdOA;

			private bool xKsDIbkRyPckbWcdkPBCzCdxGNpi = true;

			private bool ulYInakRnxJtexfXJdhfYoRkRGN = true;

			private float XXxsWFDnVSBougZrsEPwAlYjaavb = 1f;

			private readonly Dictionary<string, SafeDelegate> GPtVhmAObWFmwajBToKyVWQsEHe = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			[CompilerGenerated]
			private static Action<Exception> fFwdPYRtJSdyRfsNrkdOyiNrdFem;

			public bool allowAxes
			{
				get
				{
					return GNvYGbrvlBrbsHaGbJnHFgbcoVk;
				}
				set
				{
					GNvYGbrvlBrbsHaGbJnHFgbcoVk = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return YWccXogsLNFrzzoDFcRUbjTfyJZj;
				}
				set
				{
					YWccXogsLNFrzzoDFcRUbjTfyJZj = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return EvnCRDavIWBdJbAOGSyjHxTitpys;
				}
				set
				{
					EvnCRDavIWBdJbAOGSyjHxTitpys = value;
				}
			}

			public float timeout
			{
				get
				{
					return pgvMRONrQcRUVDIcMssWPnqKGRxi;
				}
				set
				{
					pgvMRONrQcRUVDIcMssWPnqKGRxi = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return EJYEtrQkGiAvHuiYYRLrQdCEisw;
				}
				set
				{
					EJYEtrQkGiAvHuiYYRLrQdCEisw = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return yZqSQcijlnsBljmatwuAyCMydCVe;
				}
				set
				{
					yZqSQcijlnsBljmatwuAyCMydCVe = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return weyQoRcqtqOfoUPWnQcLfkMkDLG;
				}
				set
				{
					weyQoRcqtqOfoUPWnQcLfkMkDLG = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return ibqRkbukiOYxPAqLswQlTuaGuWd;
				}
				set
				{
					ibqRkbukiOYxPAqLswQlTuaGuWd = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return ulkaenzXqygwyHGNPlyDWNbFpHr;
				}
				set
				{
					ulkaenzXqygwyHGNPlyDWNbFpHr = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return URaHotyudAxKEHpEgOctmPLCSrd;
				}
				set
				{
					URaHotyudAxKEHpEgOctmPLCSrd = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return BwOVycPVcgtFmKhvaYOzoTilwIv;
				}
				set
				{
					BwOVycPVcgtFmKhvaYOzoTilwIv = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return loYNGKmMTpVVpVkdwFTpqXCGBdOA;
				}
				set
				{
					loYNGKmMTpVVpVkdwFTpqXCGBdOA = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return xKsDIbkRyPckbWcdkPBCzCdxGNpi;
				}
				set
				{
					xKsDIbkRyPckbWcdkPBCzCdxGNpi = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return ulYInakRnxJtexfXJdhfYoRkRGN;
				}
				set
				{
					ulYInakRnxJtexfXJdhfYoRkRGN = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return XXxsWFDnVSBougZrsEPwAlYjaavb;
				}
				set
				{
					XXxsWFDnVSBougZrsEPwAlYjaavb = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)GPtVhmAObWFmwajBToKyVWQsEHe["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = delegate(Exception P_0)
						{
							ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
						};
					}
					GPtVhmAObWFmwajBToKyVWQsEHe["isElementAllowed"] = safePredicate;
				}
			}

			internal T CGpBWVWneghQHaJmUgivxiynrQN<T>(string P_0) where T : SafeDelegate
			{
				SafeDelegate value;
				T result = default(T);
				if (!GPtVhmAObWFmwajBToKyVWQsEHe.TryGetValue(P_0, out value))
				{
					while (true)
					{
						int num = 2132395351;
						while (true)
						{
							switch (num ^ 0x7F19C556)
							{
							case 2:
								break;
							case 1:
								goto IL_002e;
							default:
								return result;
							}
							break;
							IL_002e:
							result = null;
							num = 2132395350;
						}
					}
				}
				return value as T;
			}

			public Options()
			{
				QYwkAfdRMMgAPnyPzHFUdcsKUPp();
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
				stringBuilder.Append("allowAxes = " + GNvYGbrvlBrbsHaGbJnHFgbcoVk + "\n");
				stringBuilder.Append("allowButtons = " + YWccXogsLNFrzzoDFcRUbjTfyJZj + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + EvnCRDavIWBdJbAOGSyjHxTitpys + "\n");
				stringBuilder.Append("timeout = " + pgvMRONrQcRUVDIcMssWPnqKGRxi + "\n");
				stringBuilder.Append("checkForConflicts = " + EJYEtrQkGiAvHuiYYRLrQdCEisw + "\n");
				while (true)
				{
					int num = 707501652;
					while (true)
					{
						switch (num ^ 0x2A2B9E55)
						{
						case 4:
							break;
						case 1:
							stringBuilder.Append("checkForConflictsWithAllPlayers = " + yZqSQcijlnsBljmatwuAyCMydCVe + "\n");
							num = 707501654;
							continue;
						case 2:
							if (ulkaenzXqygwyHGNPlyDWNbFpHr == null)
							{
								stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
								num = 707501651;
								continue;
							}
							goto case 0;
						case 6:
							stringBuilder.Append(string.Concat("defaultActionWhenConflictFound = ", URaHotyudAxKEHpEgOctmPLCSrd, "\n"));
							stringBuilder.Append("ignoreMouseXAxis = " + BwOVycPVcgtFmKhvaYOzoTilwIv);
							stringBuilder.Append("ignoreMouseYAxis = " + loYNGKmMTpVVpVkdwFTpqXCGBdOA);
							num = 707501648;
							continue;
						case 5:
							stringBuilder.Append("allowKeyboardKeysWithModifiers = " + xKsDIbkRyPckbWcdkPBCzCdxGNpi + "\n");
							stringBuilder.Append("allowKeyboardModifierAsPrimary = " + ulYInakRnxJtexfXJdhfYoRkRGN + "\n");
							num = 707501650;
							continue;
						case 0:
							stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(ulkaenzXqygwyHGNPlyDWNbFpHr) + "\n");
							num = 707501651;
							continue;
						case 3:
							stringBuilder.Append("checkForConflictsWithSelf = " + weyQoRcqtqOfoUPWnQcLfkMkDLG + "\n");
							stringBuilder.Append("checkForConflictsWithSystemPlayer = " + ibqRkbukiOYxPAqLswQlTuaGuWd + "\n");
							num = 707501655;
							continue;
						default:
							stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + XXxsWFDnVSBougZrsEPwAlYjaavb + "\n");
							return stringBuilder.ToString();
						}
						break;
					}
				}
			}

			internal void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
			{
				GNvYGbrvlBrbsHaGbJnHFgbcoVk = true;
				YWccXogsLNFrzzoDFcRUbjTfyJZj = true;
				EvnCRDavIWBdJbAOGSyjHxTitpys = true;
				while (true)
				{
					int num = 566646429;
					while (true)
					{
						switch (num ^ 0x21C6569F)
						{
						case 0:
							break;
						case 2:
							pgvMRONrQcRUVDIcMssWPnqKGRxi = 0f;
							EJYEtrQkGiAvHuiYYRLrQdCEisw = true;
							yZqSQcijlnsBljmatwuAyCMydCVe = true;
							num = 566646430;
							continue;
						case 1:
							weyQoRcqtqOfoUPWnQcLfkMkDLG = true;
							ibqRkbukiOYxPAqLswQlTuaGuWd = true;
							ulkaenzXqygwyHGNPlyDWNbFpHr = null;
							num = 566646428;
							continue;
						default:
						{
							URaHotyudAxKEHpEgOctmPLCSrd = ConflictResponse.Replace;
							BwOVycPVcgtFmKhvaYOzoTilwIv = false;
							loYNGKmMTpVVpVkdwFTpqXCGBdOA = false;
							xKsDIbkRyPckbWcdkPBCzCdxGNpi = true;
							ulYInakRnxJtexfXJdhfYoRkRGN = true;
							XXxsWFDnVSBougZrsEPwAlYjaavb = 1f;
							List<string> list = new List<string>(GPtVhmAObWFmwajBToKyVWQsEHe.Keys);
							using (List<string>.Enumerator enumerator = list.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										string current = enumerator.Current;
										int num2 = 566646431;
										while (true)
										{
											switch (num2 ^ 0x21C6569F)
											{
											case 3:
												num2 = 566646430;
												continue;
											case 1:
												break;
											case 0:
												GPtVhmAObWFmwajBToKyVWQsEHe[current] = null;
												num2 = 566646429;
												continue;
											default:
												goto end_IL_00dd;
											}
											break;
										}
										continue;
										end_IL_00dd:
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
					goto IL_0003;
				}
				goto IL_0074;
				IL_0003:
				int num = -942274492;
				goto IL_0008;
				IL_0008:
				while (true)
				{
					switch (num ^ -942274491)
					{
					case 5:
						break;
					case 3:
						destination.yZqSQcijlnsBljmatwuAyCMydCVe = source.yZqSQcijlnsBljmatwuAyCMydCVe;
						destination.weyQoRcqtqOfoUPWnQcLfkMkDLG = source.weyQoRcqtqOfoUPWnQcLfkMkDLG;
						destination.ibqRkbukiOYxPAqLswQlTuaGuWd = source.ibqRkbukiOYxPAqLswQlTuaGuWd;
						destination.ulkaenzXqygwyHGNPlyDWNbFpHr = ArrayTools.ShallowCopy(source.ulkaenzXqygwyHGNPlyDWNbFpHr);
						num = -942274495;
						continue;
					case 0:
						goto IL_0074;
					case 2:
						goto IL_008c;
					case 7:
						destination.YWccXogsLNFrzzoDFcRUbjTfyJZj = source.YWccXogsLNFrzzoDFcRUbjTfyJZj;
						num = -942274493;
						continue;
					case 1:
						throw new ArgumentNullException("source");
					case 6:
						destination.EvnCRDavIWBdJbAOGSyjHxTitpys = source.EvnCRDavIWBdJbAOGSyjHxTitpys;
						destination.pgvMRONrQcRUVDIcMssWPnqKGRxi = source.pgvMRONrQcRUVDIcMssWPnqKGRxi;
						destination.EJYEtrQkGiAvHuiYYRLrQdCEisw = source.EJYEtrQkGiAvHuiYYRLrQdCEisw;
						num = -942274490;
						continue;
					default:
					{
						destination.URaHotyudAxKEHpEgOctmPLCSrd = source.URaHotyudAxKEHpEgOctmPLCSrd;
						destination.BwOVycPVcgtFmKhvaYOzoTilwIv = source.BwOVycPVcgtFmKhvaYOzoTilwIv;
						destination.loYNGKmMTpVVpVkdwFTpqXCGBdOA = source.loYNGKmMTpVVpVkdwFTpqXCGBdOA;
						destination.xKsDIbkRyPckbWcdkPBCzCdxGNpi = source.xKsDIbkRyPckbWcdkPBCzCdxGNpi;
						destination.ulYInakRnxJtexfXJdhfYoRkRGN = source.ulYInakRnxJtexfXJdhfYoRkRGN;
						destination.XXxsWFDnVSBougZrsEPwAlYjaavb = source.XXxsWFDnVSBougZrsEPwAlYjaavb;
						using (Dictionary<string, SafeDelegate>.Enumerator enumerator = source.GPtVhmAObWFmwajBToKyVWQsEHe.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								while (true)
								{
									KeyValuePair<string, SafeDelegate> current = enumerator.Current;
									destination.GPtVhmAObWFmwajBToKyVWQsEHe[current.Key] = MiscTools.Clone(current.Value);
									int num2 = -942274492;
									while (true)
									{
										switch (num2 ^ -942274491)
										{
										case 0:
											num2 = -942274489;
											continue;
										case 2:
											break;
										default:
											goto end_IL_016f;
										}
										break;
									}
									continue;
									end_IL_016f:
									break;
								}
							}
							return;
						}
					}
					}
					break;
				}
				goto IL_0003;
				IL_0074:
				if (destination == null)
				{
					throw new ArgumentNullException("destination");
				}
				goto IL_008c;
				IL_008c:
				destination.GNvYGbrvlBrbsHaGbJnHFgbcoVk = source.GNvYGbrvlBrbsHaGbJnHFgbcoVk;
				num = -942274494;
				goto IL_0008;
			}

			[CompilerGenerated]
			private static void mwHbuFuJBgiaYGRMZzvSrdxZdJw(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
			}
		}

		private static InputMapper gePIlGMmtUuQJnaTMLFTWnhtmcu;

		private static int TbDhfBsHjBGdJykcocaYNzEaReh = 0;

		private readonly int yqpuVRltBNNgBaGgBpISfmAaJKs;

		private readonly bool swKKCuxPptWajLiBONyngfGMnas;

		private readonly ItUQksAXJzmVAthYgOGArPZuoVr mFqMEHItJdAqEYEUgVxhKiJpMJe;

		private Options pEIFnFEQaFUOzicvqvSVFbpPGQx;

		private readonly Dictionary<faAxcnEMyhMvEgkmlLQaUGonSiw, SafeDelegate> IZMpIDCaOoTDpeuVuNTFPPeKSXd = new Dictionary<faAxcnEMyhMvEgkmlLQaUGonSiw, SafeDelegate>
		{
			{
				faAxcnEMyhMvEgkmlLQaUGonSiw.xAPQdNJoHdLlriIRSdcQlihMhVf,
				new SafeAction<InputMappedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
				})
			},
			{
				faAxcnEMyhMvEgkmlLQaUGonSiw.grUBokGUZoYzRePQzgyPslflUhm,
				new SafeAction<ErrorEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
				})
			},
			{
				faAxcnEMyhMvEgkmlLQaUGonSiw.ZhBjTyGHBmJlWBqUKVYQKMXyEaL,
				new SafeAction<CanceledEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
				})
			},
			{
				faAxcnEMyhMvEgkmlLQaUGonSiw.oVKApXvPXTQVqIawNRPcUMAelYY,
				new SafeAction<TimedOutEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
				})
			},
			{
				faAxcnEMyhMvEgkmlLQaUGonSiw.racJEwnVOzQXhmYAxvkeyHURrNS,
				new SafeAction<StartedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
				})
			},
			{
				faAxcnEMyhMvEgkmlLQaUGonSiw.lZfOpoEACbElLnFflcCbeRwfKGs,
				new SafeAction<StoppedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
				})
			},
			{
				faAxcnEMyhMvEgkmlLQaUGonSiw.grqEvWbQoBkhrWeSJPfnUhwcWDt,
				new SafeAction<ConflictFoundEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
				})
			}
		};

		[CompilerGenerated]
		private static Action<Exception> RlQDqHdnOGRwXAjqovjvtcoCuNu;

		[CompilerGenerated]
		private static Action<Exception> daZcRQdZLfKNcBUbrcIVBWyceJaD;

		[CompilerGenerated]
		private static Action<Exception> IMcfHZuGCenebnwEqEYfzISjcoY;

		[CompilerGenerated]
		private static Action<Exception> ziuyIEKZgAqwOBMhCqzxtdlWtGn;

		[CompilerGenerated]
		private static Action<Exception> PEKRcxSbkifUDFBgnvjyOvEcZDW;

		[CompilerGenerated]
		private static Action<Exception> cyPpxoBXosrOAPNMKkrilggvqke;

		[CompilerGenerated]
		private static Action<Exception> rHwbuUazOsBEKqTINKMxbWjHpNpI;

		public static InputMapper Default
		{
			get
			{
				return gePIlGMmtUuQJnaTMLFTWnhtmcu ?? (gePIlGMmtUuQJnaTMLFTWnhtmcu = new InputMapper(true));
			}
		}

		public Options options
		{
			get
			{
				Options obj = pEIFnFEQaFUOzicvqvSVFbpPGQx;
				if (obj == null)
				{
					Options result = default(Options);
					Options options = default(Options);
					while (true)
					{
						int num = -917249231;
						while (true)
						{
							switch (num ^ -917249229)
							{
							case 4:
								break;
							case 2:
								goto IL_0030;
							case 1:
								result = (pEIFnFEQaFUOzicvqvSVFbpPGQx = Default.options.Clone());
								num = -917249232;
								continue;
							case 3:
								return result;
							default:
								goto end_IL_000a;
							}
							break;
							IL_0030:
							if (!swKKCuxPptWajLiBONyngfGMnas)
							{
								num = -917249230;
								continue;
							}
							options = (pEIFnFEQaFUOzicvqvSVFbpPGQx = new Options());
							num = -917249229;
						}
						continue;
						end_IL_000a:
						break;
					}
					obj = options;
				}
				return obj;
			}
			set
			{
				pEIFnFEQaFUOzicvqvSVFbpPGQx = value;
			}
		}

		public Context mappingContext
		{
			get
			{
				return mFqMEHItJdAqEYEUgVxhKiJpMJe.context;
			}
		}

		public Status status
		{
			get
			{
				return mFqMEHItJdAqEYEUgVxhKiJpMJe.status;
			}
		}

		public float timeRemaining
		{
			get
			{
				return mFqMEHItJdAqEYEUgVxhKiJpMJe.timeRemaining;
			}
		}

		internal int id
		{
			get
			{
				return yqpuVRltBNNgBaGgBpISfmAaJKs;
			}
		}

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.xAPQdNJoHdLlriIRSdcQlihMhVf;
					IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<InputMappedEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] + value;
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
					faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.xAPQdNJoHdLlriIRSdcQlihMhVf;
					IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<InputMappedEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] - value;
					int num = -942020243;
					while (true)
					{
						switch (num ^ -942020241)
						{
						case 0:
							goto IL_0004;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0004:
						num = -942020242;
					}
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.grUBokGUZoYzRePQzgyPslflUhm;
					int num = -285962289;
					while (true)
					{
						switch (num ^ -285962292)
						{
						case 0:
							num = -285962290;
							continue;
						default:
							return;
						case 2:
							break;
						case 3:
							IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<ErrorEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] + value;
							num = -285962291;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
			remove
			{
				if (value == null)
				{
					while (true)
					{
						switch (0x7D6E1216 ^ 0x7D6E1217)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.grUBokGUZoYzRePQzgyPslflUhm;
				IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<ErrorEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] - value;
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.ZhBjTyGHBmJlWBqUKVYQKMXyEaL;
					int num = -2107020402;
					while (true)
					{
						switch (num ^ -2107020401)
						{
						case 0:
							goto IL_0004;
						case 2:
							break;
						default:
							IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<CanceledEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] + value;
							return;
						}
						break;
						IL_0004:
						num = -2107020403;
					}
				}
			}
			remove
			{
				if (value == null)
				{
					while (true)
					{
						switch (-1707069407 ^ -1707069408)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.ZhBjTyGHBmJlWBqUKVYQKMXyEaL;
				IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<CanceledEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] - value;
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.oVKApXvPXTQVqIawNRPcUMAelYY;
					IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<TimedOutEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] + value;
					int num = -1917681868;
					while (true)
					{
						switch (num ^ -1917681868)
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
						num = -1917681867;
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
					faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.oVKApXvPXTQVqIawNRPcUMAelYY;
					IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<TimedOutEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] - value;
					int num = -935848280;
					while (true)
					{
						switch (num ^ -935848279)
						{
						case 0:
							goto IL_0004;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_0004:
						num = -935848277;
					}
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value == null)
				{
					goto IL_0003;
				}
				goto IL_002d;
				IL_0003:
				int num = -1273475565;
				goto IL_0008;
				IL_0008:
				switch (num ^ -1273475567)
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
				faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.racJEwnVOzQXhmYAxvkeyHURrNS;
				IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<StartedEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] + value;
				num = -1273475566;
				goto IL_0008;
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				while (true)
				{
					faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.racJEwnVOzQXhmYAxvkeyHURrNS;
					int num = 1064400485;
					while (true)
					{
						switch (num ^ 0x3F717664)
						{
						case 0:
							num = 1064400487;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<StartedEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] - value;
							num = 1064400486;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.lZfOpoEACbElLnFflcCbeRwfKGs;
					IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<StoppedEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] + value;
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
					faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.lZfOpoEACbElLnFflcCbeRwfKGs;
					IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<StoppedEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] - value;
					int num = 1725418908;
					while (true)
					{
						switch (num ^ 0x66D7CD9C)
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
						num = 1725418909;
					}
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value == null)
				{
					goto IL_0003;
				}
				goto IL_002d;
				IL_0003:
				int num = -1828609281;
				goto IL_0008;
				IL_0008:
				faAxcnEMyhMvEgkmlLQaUGonSiw key = default(faAxcnEMyhMvEgkmlLQaUGonSiw);
				switch (num ^ -1828609283)
				{
				case 3:
					break;
				case 2:
					return;
				case 1:
					goto IL_002d;
				default:
					IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<ConflictFoundEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] + value;
					return;
				}
				goto IL_0003;
				IL_002d:
				key = faAxcnEMyhMvEgkmlLQaUGonSiw.grqEvWbQoBkhrWeSJPfnUhwcWDt;
				num = -1828609283;
				goto IL_0008;
			}
			remove
			{
				if (value != null)
				{
					faAxcnEMyhMvEgkmlLQaUGonSiw key = faAxcnEMyhMvEgkmlLQaUGonSiw.grqEvWbQoBkhrWeSJPfnUhwcWDt;
					IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] = (SafeAction<ConflictFoundEventData>)IZMpIDCaOoTDpeuVuNTFPPeKSXd[key] - value;
				}
			}
		}

		private static int BThZuPfeyPZGvyTGVEUqMQfrbtK()
		{
			int tbDhfBsHjBGdJykcocaYNzEaReh = TbDhfBsHjBGdJykcocaYNzEaReh;
			if (TbDhfBsHjBGdJykcocaYNzEaReh == int.MaxValue)
			{
				TbDhfBsHjBGdJykcocaYNzEaReh = 0;
			}
			else
			{
				while (true)
				{
					TbDhfBsHjBGdJykcocaYNzEaReh++;
					int num = 1877803610;
					while (true)
					{
						switch (num ^ 0x6FED025A)
						{
						case 2:
							num = 1877803611;
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
			return tbDhfBsHjBGdJykcocaYNzEaReh;
		}

		public InputMapper()
			: this(false)
		{
			yqpuVRltBNNgBaGgBpISfmAaJKs = BThZuPfeyPZGvyTGVEUqMQfrbtK();
		}

		private InputMapper(bool isDefault)
		{
			while (true)
			{
				int num = -581414150;
				while (true)
				{
					switch (num ^ -581414149)
					{
					case 2:
						break;
					case 1:
						swKKCuxPptWajLiBONyngfGMnas = isDefault;
						num = -581414149;
						continue;
					case 0:
						if (swKKCuxPptWajLiBONyngfGMnas)
						{
							pEIFnFEQaFUOzicvqvSVFbpPGQx = new Options();
							num = -581414152;
							continue;
						}
						goto default;
					default:
						mFqMEHItJdAqEYEUgVxhKiJpMJe = new ItUQksAXJzmVAthYgOGArPZuoVr(this, IZMpIDCaOoTDpeuVuNTFPPeKSXd);
						return;
					}
					break;
				}
			}
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			using (Dictionary<faAxcnEMyhMvEgkmlLQaUGonSiw, SafeDelegate>.Enumerator enumerator = IZMpIDCaOoTDpeuVuNTFPPeKSXd.GetEnumerator())
			{
				while (true)
				{
					int num;
					int num2;
					if (enumerator.MoveNext())
					{
						num = 1433867989;
						num2 = num;
					}
					else
					{
						num = 1433867990;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x557716D4)
						{
						case 0:
							num = 1433867989;
							continue;
						default:
							return;
						case 1:
							enumerator.Current.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
							num = 1433867991;
							continue;
						case 3:
							break;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		public void RemoveAllEventListeners()
		{
			using (Dictionary<faAxcnEMyhMvEgkmlLQaUGonSiw, SafeDelegate>.Enumerator enumerator = IZMpIDCaOoTDpeuVuNTFPPeKSXd.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						enumerator.Current.Value.Clear();
						int num = -796481443;
						while (true)
						{
							switch (num ^ -796481441)
							{
							case 0:
								num = -796481442;
								continue;
							case 1:
								break;
							default:
								goto end_IL_002c;
							}
							break;
						}
						continue;
						end_IL_002c:
						break;
					}
				}
			}
		}

		internal void GIKzQkGZMISAqnzCRVBbtlQBgjC(object P_0)
		{
		}

		internal void mZnVCVeOzgRHPCBtaZAtNklHikFK()
		{
		}

		public bool Start(Context mappingContext)
		{
			return gvigjQaykylkiDxmhkUQKBzXkGmr(mappingContext, (pEIFnFEQaFUOzicvqvSVFbpPGQx != null) ? pEIFnFEQaFUOzicvqvSVFbpPGQx : Default.options);
		}

		public void Stop()
		{
			mFqMEHItJdAqEYEUgVxhKiJpMJe.iKEYBuCkLgBybRgmepySnHDkqrS("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			mZnVCVeOzgRHPCBtaZAtNklHikFK();
			pEIFnFEQaFUOzicvqvSVFbpPGQx = null;
		}

		private bool gvigjQaykylkiDxmhkUQKBzXkGmr(Context P_0, Options P_1)
		{
			if (!ReInput.isReady)
			{
				return false;
			}
			if (P_0 == null)
			{
				goto IL_000c;
			}
			int num3;
			if (P_0.controllerMap != null)
			{
				if (P_0.actionElementMapToReplace == null || P_0.controllerMap.ContainsElementMap(P_0.actionElementMapToReplace))
				{
					bool result = default(bool);
					try
					{
						mFqMEHItJdAqEYEUgVxhKiJpMJe.gvigjQaykylkiDxmhkUQKBzXkGmr(P_0, P_1);
						while (true)
						{
							IL_00a6:
							int num = -242097758;
							while (true)
							{
								switch (num ^ -242097757)
								{
								case 0:
									break;
								default:
									goto end_IL_00ab;
								case 1:
									goto IL_00c4;
								case 2:
									goto end_IL_00ab;
								}
								goto IL_00a6;
								IL_00c4:
								result = true;
								num = -242097759;
								continue;
								end_IL_00ab:
								break;
							}
							break;
						}
					}
					catch
					{
						mFqMEHItJdAqEYEUgVxhKiJpMJe.iKEYBuCkLgBybRgmepySnHDkqrS("Failed to start due to an exception.");
						while (true)
						{
							IL_00e0:
							int num2 = -242097759;
							while (true)
							{
								switch (num2 ^ -242097757)
								{
								case 0:
									break;
								default:
									goto end_IL_00e5;
								case 2:
									goto IL_00fe;
								case 1:
									goto end_IL_00e5;
								}
								goto IL_00e0;
								IL_00fe:
								result = false;
								num2 = -242097758;
								continue;
								end_IL_00e5:
								break;
							}
							break;
						}
					}
					return result;
				}
				num3 = -242097757;
			}
			else
			{
				num3 = -242097753;
			}
			goto IL_0011;
			IL_000c:
			num3 = -242097760;
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num3 ^ -242097757)
				{
				case 5:
					break;
				case 3:
					Logger.LogError("The Context cannot be null.");
					num3 = -242097758;
					continue;
				case 2:
					return false;
				case 1:
					return false;
				case 4:
					Logger.LogError("The Controller Map cannot be null.");
					num3 = -242097759;
					continue;
				default:
					Logger.LogError("The Action Element Map must belong to the same Controller Map you are passing in.");
					return false;
				}
				break;
			}
			goto IL_000c;
		}

		[CompilerGenerated]
		private static void UVQTpWqMvgFZQiYVDcnwWmBAcBdH(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
		}

		[CompilerGenerated]
		private static void vOalFrpgXOTEVTikVYelbkzwSww(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
		}

		[CompilerGenerated]
		private static void UGSMGGdoJLEUJdHOFggXZHGKsyUk(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
		}

		[CompilerGenerated]
		private static void noDgYwrTVzaYXmKwIoywKUHGvkc(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
		}

		[CompilerGenerated]
		private static void NTblrvDAjQvNqpjmShMLsUaFSzW(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
		}

		[CompilerGenerated]
		private static void FFPdSLaSTfXlqRzKaZTFPThMWnyO(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
		}

		[CompilerGenerated]
		private static void XTIPKmePSKQOVbaPZbrCrUZmpMH(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
		}
	}
}
