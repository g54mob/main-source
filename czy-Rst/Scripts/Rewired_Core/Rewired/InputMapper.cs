using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public sealed class InputMapper
	{
		public class Context
		{
			private int pzsTiZOwEhDAXDGGSJAIgHIcxjyL = -1;

			private ControllerMap AlVXeXmgFJITeNgnBRvmxqUreYDX;

			private ActionElementMap AbASOzETkMFTOJSuhInkyqdnlOPb;

			private AxisRange WcRKeFYoXPkAOAPcXamgstNJDnecA = AxisRange.Positive;

			private bool LReGwCppJGbKYDdXcVHWzCxOhxIe;

			public int actionId
			{
				get
				{
					return pzsTiZOwEhDAXDGGSJAIgHIcxjyL;
				}
				set
				{
					if (!JjinAyOtmvOpkfqnFhSbCUzDhxwLA())
					{
						pzsTiZOwEhDAXDGGSJAIgHIcxjyL = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(pzsTiZOwEhDAXDGGSJAIgHIcxjyL);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!JjinAyOtmvOpkfqnFhSbCUzDhxwLA())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							pzsTiZOwEhDAXDGGSJAIgHIcxjyL = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							pzsTiZOwEhDAXDGGSJAIgHIcxjyL = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return AlVXeXmgFJITeNgnBRvmxqUreYDX;
				}
				set
				{
					if (!JjinAyOtmvOpkfqnFhSbCUzDhxwLA())
					{
						AlVXeXmgFJITeNgnBRvmxqUreYDX = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return AbASOzETkMFTOJSuhInkyqdnlOPb;
				}
				set
				{
					if (!JjinAyOtmvOpkfqnFhSbCUzDhxwLA())
					{
						AbASOzETkMFTOJSuhInkyqdnlOPb = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return WcRKeFYoXPkAOAPcXamgstNJDnecA;
				}
				set
				{
					if (!JjinAyOtmvOpkfqnFhSbCUzDhxwLA())
					{
						WcRKeFYoXPkAOAPcXamgstNJDnecA = value;
					}
				}
			}

			public Context()
			{
			}

			private Context(Context P_0)
				: this()
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("source");
				}
				Copy(P_0, this);
			}

			public Context Clone()
			{
				return new Context(this);
			}

			internal void bJyczCcROcIcLVKNeuXyFDqhiwNbb()
			{
				LReGwCppJGbKYDdXcVHWzCxOhxIe = true;
			}

			private bool JjinAyOtmvOpkfqnFhSbCUzDhxwLA()
			{
				if (LReGwCppJGbKYDdXcVHWzCxOhxIe)
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
				if (destination == null)
				{
					throw new ArgumentNullException("destination");
				}
				destination.pzsTiZOwEhDAXDGGSJAIgHIcxjyL = source.pzsTiZOwEhDAXDGGSJAIgHIcxjyL;
				destination.AlVXeXmgFJITeNgnBRvmxqUreYDX = source.AlVXeXmgFJITeNgnBRvmxqUreYDX;
				destination.AbASOzETkMFTOJSuhInkyqdnlOPb = source.AbASOzETkMFTOJSuhInkyqdnlOPb;
				destination.WcRKeFYoXPkAOAPcXamgstNJDnecA = source.WcRKeFYoXPkAOAPcXamgstNJDnecA;
			}
		}

		public enum ConflictResponse
		{
			Cancel = 0,
			Replace = 1,
			Add = 2,
			Ignore = 3,
			Swap = 4
		}

		public abstract class EventData
		{
			public readonly InputMapper inputMapper;

			internal EventData(InputMapper P_0)
			{
				inputMapper = P_0;
			}
		}

		public class InputMappedEventData : EventData
		{
			public readonly ActionElementMap actionElementMap;

			internal InputMappedEventData(InputMapper P_0, ActionElementMap P_1)
				: base(P_0)
			{
				actionElementMap = P_1;
			}
		}

		public class CanceledEventData : EventData
		{
			public readonly string message;

			internal CanceledEventData(InputMapper P_0, string P_1)
				: base(P_0)
			{
				message = P_1;
			}
		}

		public class ErrorEventData : EventData
		{
			public readonly string message;

			internal ErrorEventData(InputMapper P_0, string P_1)
				: base(P_0)
			{
				message = P_1;
			}
		}

		public class TimedOutEventData : EventData
		{
			internal TimedOutEventData(InputMapper P_0)
				: base(P_0)
			{
			}
		}

		public class StartedEventData : EventData
		{
			internal StartedEventData(InputMapper P_0)
				: base(P_0)
			{
			}
		}

		public class StoppedEventData : EventData
		{
			internal StoppedEventData(InputMapper P_0)
				: base(P_0)
			{
			}
		}

		public class ConflictFoundEventData : EventData
		{
			public readonly Action<ConflictResponse> responseCallback;

			public readonly ElementAssignmentInfo assignment;

			public readonly IList<ElementAssignmentConflictInfo> conflicts;

			public readonly bool isProtected;

			private readonly Func<int, bool> HpnzNWUViTKuAfbOAKMiCfvOMglR;

			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				if (HpnzNWUViTKuAfbOAKMiCfvOMglR == null)
				{
					return false;
				}
				return HpnzNWUViTKuAfbOAKMiCfvOMglR(maxInputFieldCount);
			}

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
				: base(P_0)
			{
				responseCallback = P_1;
				assignment = P_2;
				conflicts = P_3;
				isProtected = P_4;
				HpnzNWUViTKuAfbOAKMiCfvOMglR = P_5;
			}
		}

		private enum ReCANcMASIdCrKkDVtpMlFHMFzYC
		{
			InputMapped = 0,
			Error = 1,
			Canceled = 2,
			TimedOut = 3,
			Started = 4,
			Stopped = 5,
			ConflictsFound = 6
		}

		public enum Status
		{
			Idle = 0,
			Listening = 1,
			AwaitingResponse = 2
		}

		private class ieKntKIlEYZdqFrNMqcuKiTXdMfE
		{
			private enum leoFeDqQNiFfwdChpIjMjqBpwGxU
			{
				Quit = 0,
				Continue = 1
			}

			private enum PgQpvjrYuzqIBGXCGTaZCbwSzAfN
			{
				None = 0,
				ConflictChecking = 1
			}

			private class QSnFbTeVaNXWBogrQFRJGLjjeSiCc
			{
				private Player OZjxHooozDcoPZpmmRScRauoTEeb;

				private int ntDSJyMHvtRNRRPcXJbLeaJcJcBS;

				private Context UuONUHxmonNHOCUaIpoZjwnfogll;

				private ControllerType cGhjdBmqYMVOkbkuVCSwlGdiEGkD;

				private int oJJbEMkvtBsIGHluIcbyjNDNeGkeb;

				private ControllerPollingInfo CFpMhTURCPysLRzntVwicczlcQFi;

				private ModifierKeyFlags PnzEnCKvyRSFLbJKkzBqKxUtfONcA;

				public Player uopsOvleFNCpPdWsuzaxAQwkQwXI => OZjxHooozDcoPZpmmRScRauoTEeb;

				public int JCGQYlXEhewkePDuHzPppwOEhkFF => ntDSJyMHvtRNRRPcXJbLeaJcJcBS;

				public Context KwtIpMQIvOEVbHZSkzaQjrsBaTTdA => UuONUHxmonNHOCUaIpoZjwnfogll;

				public ControllerType nEJgHsIiDHMIMmqsrrfbhTMPNTMHA => cGhjdBmqYMVOkbkuVCSwlGdiEGkD;

				public int tXpviwNvYKBWUJjdKYITpeJGkVkx => oJJbEMkvtBsIGHluIcbyjNDNeGkeb;

				public ControllerPollingInfo VRBKwZuminStORuGeqfjfuqCkLxh => CFpMhTURCPysLRzntVwicczlcQFi;

				public ModifierKeyFlags QUkZpOwmWWooGyRiWiHFyrDeVjbb => PnzEnCKvyRSFLbJKkzBqKxUtfONcA;

				public AxisRange OvcHTrDnZgogRLwWSSDYnCaIgZkW
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (VRBKwZuminStORuGeqfjfuqCkLxh.elementType == ControllerElementType.Axis)
						{
							result = ((UuONUHxmonNHOCUaIpoZjwnfogll.actionRange != AxisRange.Full) ? ((VRBKwZuminStORuGeqfjfuqCkLxh.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
						}
						return result;
					}
				}

				public string RktekqpXoYHvxaMOABXWVEWzVdmc
				{
					get
					{
						if (nEJgHsIiDHMIMmqsrrfbhTMPNTMHA == ControllerType.Keyboard && QUkZpOwmWWooGyRiWiHFyrDeVjbb != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(QUkZpOwmWWooGyRiWiHFyrDeVjbb)} + {VRBKwZuminStORuGeqfjfuqCkLxh.elementIdentifierName}";
						}
						string text = VRBKwZuminStORuGeqfjfuqCkLxh.elementIdentifierName;
						if (VRBKwZuminStORuGeqfjfuqCkLxh.elementType == ControllerElementType.Axis)
						{
							if (OvcHTrDnZgogRLwWSSDYnCaIgZkW == AxisRange.Positive)
							{
								text += " +";
							}
							else if (OvcHTrDnZgogRLwWSSDYnCaIgZkW == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				public void cHxCLVfAkzvpmHhVUyRdUEBOJaMQ(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					tVONObsmAWGJVfkqhGdwAKzFoBOPA();
					OZjxHooozDcoPZpmmRScRauoTEeb = P_0;
					ntDSJyMHvtRNRRPcXJbLeaJcJcBS = P_1.actionId;
					cGhjdBmqYMVOkbkuVCSwlGdiEGkD = P_1.controllerMap.controllerType;
					oJJbEMkvtBsIGHluIcbyjNDNeGkeb = P_1.controllerMap.controllerId;
					UuONUHxmonNHOCUaIpoZjwnfogll = P_1;
					cGhjdBmqYMVOkbkuVCSwlGdiEGkD = P_1.controllerMap.controllerType;
					oJJbEMkvtBsIGHluIcbyjNDNeGkeb = P_1.controllerMap.controllerId;
					P_1.bJyczCcROcIcLVKNeuXyFDqhiwNbb();
				}

				public void tVONObsmAWGJVfkqhGdwAKzFoBOPA()
				{
					OZjxHooozDcoPZpmmRScRauoTEeb = null;
					ntDSJyMHvtRNRRPcXJbLeaJcJcBS = -1;
					UuONUHxmonNHOCUaIpoZjwnfogll = null;
					cGhjdBmqYMVOkbkuVCSwlGdiEGkD = ControllerType.Keyboard;
					oJJbEMkvtBsIGHluIcbyjNDNeGkeb = -1;
					CFpMhTURCPysLRzntVwicczlcQFi = default(ControllerPollingInfo);
					PnzEnCKvyRSFLbJKkzBqKxUtfONcA = ModifierKeyFlags.None;
				}

				public ElementAssignment auPKuoAJCTFayflIKMeNkHxZNjUZ(ControllerPollingInfo P_0)
				{
					CFpMhTURCPysLRzntVwicczlcQFi = P_0;
					return hxUrqmsdvlFghkncBVGCMZQWCdABA();
				}

				public ElementAssignment QXYyJQlnRuTbGvwzqAkouPCXONCL(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					CFpMhTURCPysLRzntVwicczlcQFi = P_0;
					PnzEnCKvyRSFLbJKkzBqKxUtfONcA = P_1;
					return hxUrqmsdvlFghkncBVGCMZQWCdABA();
				}

				public ElementAssignment hxUrqmsdvlFghkncBVGCMZQWCdABA()
				{
					return new ElementAssignment(nEJgHsIiDHMIMmqsrrfbhTMPNTMHA, CFpMhTURCPysLRzntVwicczlcQFi.elementType, CFpMhTURCPysLRzntVwicczlcQFi.elementIdentifierId, OvcHTrDnZgogRLwWSSDYnCaIgZkW, CFpMhTURCPysLRzntVwicczlcQFi.keyboardKey, PnzEnCKvyRSFLbJKkzBqKxUtfONcA, ntDSJyMHvtRNRRPcXJbLeaJcJcBS, (UuONUHxmonNHOCUaIpoZjwnfogll.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (UuONUHxmonNHOCUaIpoZjwnfogll.actionElementMapToReplace != null) ? UuONUHxmonNHOCUaIpoZjwnfogll.actionElementMapToReplace.id : (-1));
				}
			}

			private sealed class fIKgCRFEQFfiwcasQfjspeoGnMgCb
			{
				public ActionElementMap VaZtTFbKGBxfGWIZtixRLhLhcPuL;

				internal bool CzhdokIDBlNqiVKmpnbeqTgWmlcdb(ElementAssignmentConflictInfo P_0)
				{
					return P_0.elementMapId == VaZtTFbKGBxfGWIZtixRLhLhcPuL.id;
				}
			}

			private sealed class rVtPPrVWJUsaCVxKzsaHodBMsLfS
			{
				public ieKntKIlEYZdqFrNMqcuKiTXdMfE vpGcKQdJrRHtAsUidJAyaSNCukexB;

				public ElementAssignmentInfo lXKplYhgWkTlffAYXiRhOHGsDzHiA;

				public IList<ElementAssignmentConflictInfo> EibVhyfIgbHoQfRLbgVHDtpgCmTd;

				public bool JmjxMIHLfPxWHcpZjdTiHJrsGFbeA;

				internal bool HiCnkCxSCFGCmaGRDLRmSIWuMEpD(int P_0)
				{
					return vpGcKQdJrRHtAsUidJAyaSNCukexB.UeVLHToRiXmrPpjQNmMKJiDPnzgH(lXKplYhgWkTlffAYXiRhOHGsDzHiA, EibVhyfIgbHoQfRLbgVHDtpgCmTd, JmjxMIHLfPxWHcpZjdTiHJrsGFbeA, P_0);
				}
			}

			private readonly InputMapper CIJkCcmtiXozjGvrMGaWTZPXJgQD;

			private readonly Options FQQwvVUGMHMtjYCVOlRokZMQbCUb = new Options();

			private readonly QSnFbTeVaNXWBogrQFRJGLjjeSiCc umdZNiUmFVgZGotxUUMrKGMVAZGbA = new QSnFbTeVaNXWBogrQFRJGLjjeSiCc();

			private readonly Dictionary<ReCANcMASIdCrKkDVtpMlFHMFzYC, SafeDelegate> NxRJBqUamqvKGAIIsFzSgNkbAkEG;

			private readonly Dictionary<string, SafeDelegate> XGMyfVAhUPAxRYAmnoWQyFfIbDMD;

			private Status aSzDRyjRMPtyCrcxRZhjodxziWAb;

			private PgQpvjrYuzqIBGXCGTaZCbwSzAfN vjbgGFdtyiXcIWDiLBzeVhTRDpDK;

			private double MgkvhKjmePzDvaoMUmwEePewjnGK;

			private bool sJkgSCsLdFkHQdwBRVqoFFUCrUWu;

			private List<Player> shMYACcsNLxJARbPVTdlosBSCnbx = new List<Player>();

			private readonly List<ControllerPollingInfo> gLRHJbdcwNdoQAsVmYRYBQCDmazt = new List<ControllerPollingInfo>();

			private ElementAssignment xNRApwAJRVKHAyyGmxuIUsXhheoy;

			public Status PdgEqxkxVTdEVBaPFtyCinvCqLMub => aSzDRyjRMPtyCrcxRZhjodxziWAb;

			public float MKmeDRKjFOYdjMTMpIycLdUyGMix
			{
				get
				{
					if (aSzDRyjRMPtyCrcxRZhjodxziWAb == Status.Idle)
					{
						return 0f;
					}
					if (FQQwvVUGMHMtjYCVOlRokZMQbCUb.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, MgkvhKjmePzDvaoMUmwEePewjnGK + (double)FQQwvVUGMHMtjYCVOlRokZMQbCUb.timeout - ReInput.unscaledTime);
				}
			}

			public Context pCqBKmBbdwibLbrfIjsSZUjsLCUgA
			{
				get
				{
					if (aSzDRyjRMPtyCrcxRZhjodxziWAb == Status.Idle)
					{
						return null;
					}
					return umdZNiUmFVgZGotxUUMrKGMVAZGbA.KwtIpMQIvOEVbHZSkzaQjrsBaTTdA;
				}
			}

			private bool MjfQmdgqJnDHaBhGQGHCboJGRhCOA
			{
				get
				{
					if (sJkgSCsLdFkHQdwBRVqoFFUCrUWu)
					{
						return false;
					}
					if (!(FQQwvVUGMHMtjYCVOlRokZMQbCUb.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public ieKntKIlEYZdqFrNMqcuKiTXdMfE(InputMapper P_0, Dictionary<ReCANcMASIdCrKkDVtpMlFHMFzYC, SafeDelegate> P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("events");
				}
				CIJkCcmtiXozjGvrMGaWTZPXJgQD = P_0;
				NxRJBqUamqvKGAIIsFzSgNkbAkEG = P_1;
				DKkCNpIKaZTibRTYUjGGrTwSrmcrA();
			}

			protected virtual void AMSwrkgHTUcObDbPUtUJusrQyRvsA()
			{
				try
				{
					AFZfoXhAALNAEEogQyrNQYYcDLqMA();
				}
				finally
				{
					base.Finalize();
				}
			}

			public void bnpQZBVCyACVLrZgOevBKcCoZoOn(Context P_0, Options P_1)
			{
				if (aSzDRyjRMPtyCrcxRZhjodxziWAb != Status.Idle)
				{
					FtaVbOzmPQqYIDkGLnAMASkAFwbg("User started a new listening session.");
				}
				if (P_0 == null)
				{
					throw new ArgumentNullException("context");
				}
				if (P_0.controllerMap == null)
				{
					throw new ArgumentNullException("controllerMap");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("options");
				}
				P_0 = P_0.Clone();
				Options.Copy(P_1, FQQwvVUGMHMtjYCVOlRokZMQbCUb);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					tqbuqpHYqHalOQEMHhThFCWClcUE("No Action found for actionId: " + P_0.actionId);
					return;
				}
				umdZNiUmFVgZGotxUUMrKGMVAZGbA.cHxCLVfAkzvpmHhVUyRdUEBOJaMQ(player, P_0);
				aSzDRyjRMPtyCrcxRZhjodxziWAb = Status.Listening;
				YDQeKKiyEabGdLGCDdSVeCMCnXJtB();
				kAIZSYeFSjbAAKfmphEIOFmZyFGd();
				MDTvpmuzgefVPRvSqNRwgXErexqD();
				TnwHBvdzVhibbYlVVXmNxmVJksAo();
			}

			public void OefapYaCxlIBuWtoOJmAZSsnrHegA(string P_0)
			{
				if (aSzDRyjRMPtyCrcxRZhjodxziWAb != Status.Idle)
				{
					FtaVbOzmPQqYIDkGLnAMASkAFwbg(P_0);
				}
			}

			private void wYhuTrydGgiwVtyhlZCtOOtfAdbK(UpdateLoopType P_0)
			{
				if (P_0 == UpdateLoopType.Update && aSzDRyjRMPtyCrcxRZhjodxziWAb == Status.Listening)
				{
					ElementAssignment elementAssignment;
					if (MjfQmdgqJnDHaBhGQGHCboJGRhCOA && MKmeDRKjFOYdjMTMpIycLdUyGMix <= 0f)
					{
						iChCsJDGimSMRGZPPLpPjIeXNCxdA();
					}
					else if (ReInput.controllers.GetController(umdZNiUmFVgZGotxUUMrKGMVAZGbA.nEJgHsIiDHMIMmqsrrfbhTMPNTMHA, umdZNiUmFVgZGotxUUMrKGMVAZGbA.tXpviwNvYKBWUJjdKYITpeJGkVkx) == null)
					{
						tqbuqpHYqHalOQEMHhThFCWClcUE("Controller not found for type: " + umdZNiUmFVgZGotxUUMrKGMVAZGbA.nEJgHsIiDHMIMmqsrrfbhTMPNTMHA.ToString() + " id: " + umdZNiUmFVgZGotxUUMrKGMVAZGbA.tXpviwNvYKBWUJjdKYITpeJGkVkx);
					}
					else if (KZMFJraxblCzJEpIkpwDsMEkklKCc(out elementAssignment) != leoFeDqQNiFfwdChpIjMjqBpwGxU.Quit && OpaiEtIzxpdWSYWhmOfcGuMNxHJ(elementAssignment) != leoFeDqQNiFfwdChpIjMjqBpwGxU.Quit)
					{
						hdozExdIPOhlxgzcVbXYBkUPGyidA(elementAssignment);
					}
				}
			}

			private void DNutgKpCbKhAdDWxlzAQgQLgXgkX()
			{
				if (aSzDRyjRMPtyCrcxRZhjodxziWAb != Status.Idle)
				{
					DKkCNpIKaZTibRTYUjGGrTwSrmcrA();
					AFZfoXhAALNAEEogQyrNQYYcDLqMA();
					tRREFPfZtGlzuJtCVgWKzZgOUNpUA();
				}
			}

			private void DKkCNpIKaZTibRTYUjGGrTwSrmcrA()
			{
				aSzDRyjRMPtyCrcxRZhjodxziWAb = Status.Idle;
				MgkvhKjmePzDvaoMUmwEePewjnGK = 0.0;
				FQQwvVUGMHMtjYCVOlRokZMQbCUb.zOllVIANVXKsHXIFYqdsMhFzFRdB();
				umdZNiUmFVgZGotxUUMrKGMVAZGbA.tVONObsmAWGJVfkqhGdwAKzFoBOPA();
				xNRApwAJRVKHAyyGmxuIUsXhheoy = default(ElementAssignment);
				vjbgGFdtyiXcIWDiLBzeVhTRDpDK = PgQpvjrYuzqIBGXCGTaZCbwSzAfN.None;
				sJkgSCsLdFkHQdwBRVqoFFUCrUWu = false;
				shMYACcsNLxJARbPVTdlosBSCnbx.Clear();
			}

			private leoFeDqQNiFfwdChpIjMjqBpwGxU KZMFJraxblCzJEpIkpwDsMEkklKCc(out ElementAssignment P_0)
			{
				if (!PJbZMwdWgHdQUuyiEoQZOmAcLjFq(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return leoFeDqQNiFfwdChpIjMjqBpwGxU.Quit;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !dfYxixtgiZmXOXMZjSyxcUjXhNND(item, FQQwvVUGMHMtjYCVOlRokZMQbCUb))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return leoFeDqQNiFfwdChpIjMjqBpwGxU.Quit;
				}
				if (!CdoxmkBqLDCoxCCcszrBhocHFIhbA(umdZNiUmFVgZGotxUUMrKGMVAZGbA, controllerPollingInfo, FQQwvVUGMHMtjYCVOlRokZMQbCUb))
				{
					P_0 = default(ElementAssignment);
					return leoFeDqQNiFfwdChpIjMjqBpwGxU.Quit;
				}
				P_0 = umdZNiUmFVgZGotxUUMrKGMVAZGbA.auPKuoAJCTFayflIKMeNkHxZNjUZ(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return leoFeDqQNiFfwdChpIjMjqBpwGxU.Continue;
			}

			private bool PJbZMwdWgHdQUuyiEoQZOmAcLjFq(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = umdZNiUmFVgZGotxUUMrKGMVAZGbA.nEJgHsIiDHMIMmqsrrfbhTMPNTMHA;
				int controllerId = umdZNiUmFVgZGotxUUMrKGMVAZGbA.tXpviwNvYKBWUJjdKYITpeJGkVkx;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = zKJODeWyNJuGHLbNEktMdeBPPbvj(out P_1);
					return true;
				}
				if (FQQwvVUGMHMtjYCVOlRokZMQbCUb.allowAxes)
				{
					if (FQQwvVUGMHMtjYCVOlRokZMQbCUb.allowButtons)
					{
						if (umdZNiUmFVgZGotxUUMrKGMVAZGbA.uopsOvleFNCpPdWsuzaxAQwkQwXI != null)
						{
							P_0 = umdZNiUmFVgZGotxUUMrKGMVAZGbA.uopsOvleFNCpPdWsuzaxAQwkQwXI.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(umdZNiUmFVgZGotxUUMrKGMVAZGbA.nEJgHsIiDHMIMmqsrrfbhTMPNTMHA, umdZNiUmFVgZGotxUUMrKGMVAZGbA.tXpviwNvYKBWUJjdKYITpeJGkVkx);
						}
					}
					else if (umdZNiUmFVgZGotxUUMrKGMVAZGbA.uopsOvleFNCpPdWsuzaxAQwkQwXI != null)
					{
						P_0 = umdZNiUmFVgZGotxUUMrKGMVAZGbA.uopsOvleFNCpPdWsuzaxAQwkQwXI.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!FQQwvVUGMHMtjYCVOlRokZMQbCUb.allowButtons)
					{
						tqbuqpHYqHalOQEMHhThFCWClcUE("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (umdZNiUmFVgZGotxUUMrKGMVAZGbA.uopsOvleFNCpPdWsuzaxAQwkQwXI != null)
					{
						P_0 = umdZNiUmFVgZGotxUUMrKGMVAZGbA.uopsOvleFNCpPdWsuzaxAQwkQwXI.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> zKJODeWyNJuGHLbNEktMdeBPPbvj(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				gLRHJbdcwNdoQAsVmYRYBQCDmazt.Clear();
				if (!FQQwvVUGMHMtjYCVOlRokZMQbCUb.allowButtons)
				{
					return gLRHJbdcwNdoQAsVmYRYBQCDmazt;
				}
				gLRHJbdcwNdoQAsVmYRYBQCDmazt.Add(hcGKBevjKbQvIsKjsadTSCEUppcn(FQQwvVUGMHMtjYCVOlRokZMQbCUb, out P_0));
				return gLRHJbdcwNdoQAsVmYRYBQCDmazt;
			}

			private ControllerPollingInfo hcGKBevjKbQvIsKjsadTSCEUppcn(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = ftrXbzXxawapVKhqWzscmNINrnby(P_0, out flag, out P_1, out text);
				if (flag)
				{
					YDQeKKiyEabGdLGCDdSVeCMCnXJtB();
				}
				return result;
			}

			private static ControllerPollingInfo ftrXbzXxawapVKhqWzscmNINrnby(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_3 = string.Empty;
				P_1 = false;
				P_2 = ModifierKeyFlags.None;
				int num = 0;
				ControllerPollingInfo result = default(ControllerPollingInfo);
				ControllerPollingInfo result2 = default(ControllerPollingInfo);
				ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
				foreach (ControllerPollingInfo item in ReInput.controllers.Keyboard.PollForAllKeys())
				{
					KeyCode keyboardKey = item.keyboardKey;
					if (keyboardKey == KeyCode.AltGr)
					{
						continue;
					}
					if (Keyboard.IsModifierKey(item.keyboardKey))
					{
						if (num == 0)
						{
							result2 = item;
						}
						modifierKeyFlags |= Keyboard.KeyCodeToModifierKeyFlags(keyboardKey);
						num++;
					}
					else if (result.keyboardKey == KeyCode.None)
					{
						result = item;
					}
				}
				if (result.keyboardKey != KeyCode.None)
				{
					if (!ReInput.controllers.Keyboard.GetKeyDown(result.keyboardKey))
					{
						return default(ControllerPollingInfo);
					}
					if (num == 0 || !P_0.allowKeyboardKeysWithModifiers)
					{
						return result;
					}
					P_2 = modifierKeyFlags;
					return result;
				}
				if (num > 0)
				{
					P_1 = true;
					if (num == 1)
					{
						if (P_0.allowKeyboardModifierKeyAsPrimary)
						{
							if (!P_0.allowKeyboardKeysWithModifiers || P_0.holdDurationToMapKeyboardModifierKeyAsPrimary <= 0f)
							{
								if (!ReInput.controllers.Keyboard.GetKeyDown(result2.keyboardKey))
								{
									return default(ControllerPollingInfo);
								}
								return result2;
							}
							if (ReInput.controllers.Keyboard.GetKeyTimePressed(result2.keyboardKey) >= (double)P_0.holdDurationToMapKeyboardModifierKeyAsPrimary)
							{
								return result2;
							}
						}
						P_3 = Keyboard.GetKeyName(result2.keyboardKey);
					}
					else
					{
						P_3 = Keyboard.ModifierKeyFlagsToString(modifierKeyFlags, getShortName: false);
					}
				}
				return default(ControllerPollingInfo);
			}

			private static bool dfYxixtgiZmXOXMZjSyxcUjXhNND(ControllerPollingInfo P_0, Options P_1)
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
					switch (P_0.elementIndex)
					{
					case 0:
						if (P_1.ignoreMouseXAxis)
						{
							return true;
						}
						break;
					case 1:
						if (P_1.ignoreMouseYAxis)
						{
							return true;
						}
						break;
					}
				}
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.mbJvfBoeiMkSejApNllSAGykfDEg<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool CdoxmkBqLDCoxCCcszrBhocHFIhbA(QSnFbTeVaNXWBogrQFRJGLjjeSiCc P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.OvcHTrDnZgogRLwWSSDYnCaIgZkW == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void kAIZSYeFSjbAAKfmphEIOFmZyFGd()
			{
				if (!FQQwvVUGMHMtjYCVOlRokZMQbCUb.checkForConflicts)
				{
					return;
				}
				if (FQQwvVUGMHMtjYCVOlRokZMQbCUb.checkForConflictsWithSelf && umdZNiUmFVgZGotxUUMrKGMVAZGbA.uopsOvleFNCpPdWsuzaxAQwkQwXI != null)
				{
					ListTools.AddIfUnique(shMYACcsNLxJARbPVTdlosBSCnbx, umdZNiUmFVgZGotxUUMrKGMVAZGbA.uopsOvleFNCpPdWsuzaxAQwkQwXI);
				}
				if (FQQwvVUGMHMtjYCVOlRokZMQbCUb.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(shMYACcsNLxJARbPVTdlosBSCnbx, ReInput.players.SystemPlayer);
				}
				if (FQQwvVUGMHMtjYCVOlRokZMQbCUb.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(shMYACcsNLxJARbPVTdlosBSCnbx, players[i]);
					}
				}
				else
				{
					if (FQQwvVUGMHMtjYCVOlRokZMQbCUb.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(FQQwvVUGMHMtjYCVOlRokZMQbCUb.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(shMYACcsNLxJARbPVTdlosBSCnbx, allPlayers[j]);
						}
					}
				}
			}

			private leoFeDqQNiFfwdChpIjMjqBpwGxU OpaiEtIzxpdWSYWhmOfcGuMNxHJ(ElementAssignment P_0)
			{
				if (FQQwvVUGMHMtjYCVOlRokZMQbCUb.checkForConflicts && umdZNiUmFVgZGotxUUMrKGMVAZGbA.uopsOvleFNCpPdWsuzaxAQwkQwXI != null && rQmvNFPbhCxiqTsVDBKCpioSlevc(umdZNiUmFVgZGotxUUMrKGMVAZGbA, P_0, shMYACcsNLxJARbPVTdlosBSCnbx))
				{
					return UatVnwhBpBBABTGcAavraCXsRxnW(P_0);
				}
				return leoFeDqQNiFfwdChpIjMjqBpwGxU.Continue;
			}

			private static bool rQmvNFPbhCxiqTsVDBKCpioSlevc(QSnFbTeVaNXWBogrQFRJGLjjeSiCc P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.uopsOvleFNCpPdWsuzaxAQwkQwXI == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!rDGpurXgLECleusHAuskgWHtPutr(P_0, P_1, out var conflictCheck))
				{
					return false;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					if (P_2[i].controllers.conflictChecking.DoesElementAssignmentConflict(conflictCheck))
					{
						return true;
					}
				}
				return false;
			}

			private static bool EtvSZAQCSxGFQYZIglIyHeLgZtAC(QSnFbTeVaNXWBogrQFRJGLjjeSiCc P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.uopsOvleFNCpPdWsuzaxAQwkQwXI == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!rDGpurXgLECleusHAuskgWHtPutr(P_0, P_1, out var conflictCheck))
				{
					return false;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					foreach (ElementAssignmentConflictInfo item in P_2[i].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck))
					{
						if (!item.isUserAssignable)
						{
							return true;
						}
					}
				}
				return false;
			}

			private static IList<ElementAssignmentConflictInfo> iuXJgxMUIcTlqtEmeqcwKnLfOaTA(QSnFbTeVaNXWBogrQFRJGLjjeSiCc P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.uopsOvleFNCpPdWsuzaxAQwkQwXI == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!rDGpurXgLECleusHAuskgWHtPutr(P_0, P_1, out var conflictCheck))
				{
					return null;
				}
				List<ElementAssignmentConflictInfo> list = new List<ElementAssignmentConflictInfo>();
				for (int i = 0; i < P_2.Count; i++)
				{
					foreach (ElementAssignmentConflictInfo item in P_2[i].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck))
					{
						list.Add(item);
					}
				}
				return list;
			}

			private static bool rDGpurXgLECleusHAuskgWHtPutr(QSnFbTeVaNXWBogrQFRJGLjjeSiCc P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				if (P_0 == null || (player = P_0.uopsOvleFNCpPdWsuzaxAQwkQwXI) == null)
				{
					P_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				P_2 = P_1.ToElementAssignmentConflictCheck();
				P_2.playerId = player.id;
				P_2.controllerType = P_0.nEJgHsIiDHMIMmqsrrfbhTMPNTMHA;
				P_2.controllerId = P_0.tXpviwNvYKBWUJjdKYITpeJGkVkx;
				P_2.controllerMapId = P_0.KwtIpMQIvOEVbHZSkzaQjrsBaTTdA.controllerMap.id;
				P_2.controllerMapCategoryId = P_0.KwtIpMQIvOEVbHZSkzaQjrsBaTTdA.controllerMap.categoryId;
				if (P_0.KwtIpMQIvOEVbHZSkzaQjrsBaTTdA.actionElementMapToReplace != null)
				{
					P_2.elementMapId = P_0.KwtIpMQIvOEVbHZSkzaQjrsBaTTdA.actionElementMapToReplace.id;
				}
				return true;
			}

			private static void zmtZOtnIfpHofkblDQxTSumWqXCrA(QSnFbTeVaNXWBogrQFRJGLjjeSiCc P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.uopsOvleFNCpPdWsuzaxAQwkQwXI == null)
				{
					return;
				}
				if (!rDGpurXgLECleusHAuskgWHtPutr(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void MDTvpmuzgefVPRvSqNRwgXErexqD()
			{
				ReInput.UpdateEndedEvent -= wYhuTrydGgiwVtyhlZCtOOtfAdbK;
				ReInput.UpdateEndedEvent += wYhuTrydGgiwVtyhlZCtOOtfAdbK;
			}

			private void AFZfoXhAALNAEEogQyrNQYYcDLqMA()
			{
				ReInput.UpdateEndedEvent -= wYhuTrydGgiwVtyhlZCtOOtfAdbK;
			}

			private bool mZzbHRtusQdZIXDScCdfTbUEDeYd(ReCANcMASIdCrKkDVtpMlFHMFzYC P_0)
			{
				SafeDelegate safeDelegate = NxRJBqUamqvKGAIIsFzSgNkbAkEG[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void DiDBgJhnxEwbidefzWxmmuTQakZH<_0001>(ReCANcMASIdCrKkDVtpMlFHMFzYC P_0, _0001 P_1)
			{
				SafeAction<_0001> safeAction = (SafeAction<_0001>)NxRJBqUamqvKGAIIsFzSgNkbAkEG[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void YDQeKKiyEabGdLGCDdSVeCMCnXJtB()
			{
				MgkvhKjmePzDvaoMUmwEePewjnGK = ReInput.unscaledTime;
			}

			private void KQEAvvHDAoNBfYgcSJuqjlCJdpkab()
			{
				sJkgSCsLdFkHQdwBRVqoFFUCrUWu = true;
			}

			private bool UeVLHToRiXmrPpjQNmMKJiDPnzgH(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
			{
				if (P_3 < 0)
				{
					P_3 = 0;
				}
				if (P_0 == null || P_1 == null)
				{
					return false;
				}
				if (P_2)
				{
					return false;
				}
				ActionElementMap elementMap = P_0.elementMap;
				if (elementMap == null)
				{
					return false;
				}
				List<ElementAssignmentConflictInfo> list = new List<ElementAssignmentConflictInfo>();
				for (int i = 0; i < P_1.Count; i++)
				{
					if (P_1[i].playerId == P_0.player.id)
					{
						list.Add(P_1[i]);
					}
				}
				if (list.Count > 1)
				{
					return false;
				}
				ElementAssignmentConflictInfo elementAssignmentConflictInfo = list[0];
				if (elementAssignmentConflictInfo.elementMap == null)
				{
					return false;
				}
				if (!elementAssignmentConflictInfo.isConflict)
				{
					return false;
				}
				if (elementAssignmentConflictInfo.playerId != P_0.player.id)
				{
					return false;
				}
				int actionId = elementAssignmentConflictInfo.elementMap.actionId;
				Pole axisContribution = elementAssignmentConflictInfo.elementMap.axisContribution;
				AxisRange axisRange = elementMap.axisRange;
				ControllerElementType elementType = elementMap.elementType;
				if (elementType == elementAssignmentConflictInfo.elementMap.elementType && elementType == ControllerElementType.Axis)
				{
					if (axisRange != elementAssignmentConflictInfo.elementMap.axisRange)
					{
						if (axisRange == AxisRange.Full)
						{
							axisRange = AxisRange.Positive;
						}
						else if (elementAssignmentConflictInfo.elementMap.axisRange != AxisRange.Full)
						{
						}
					}
				}
				else if (elementType == ControllerElementType.Axis && (elementAssignmentConflictInfo.elementMap.elementType == ControllerElementType.Button || (elementAssignmentConflictInfo.elementMap.elementType == ControllerElementType.Axis && elementAssignmentConflictInfo.elementMap.axisRange != AxisRange.Full)) && axisRange == AxisRange.Full)
				{
					axisRange = AxisRange.Positive;
				}
				int num = 0;
				if (P_0.action.id == elementAssignmentConflictInfo.actionId && P_0.controllerMap == elementAssignmentConflictInfo.controllerMap)
				{
					Controller controller = ReInput.controllers.GetController(P_0.controllerType, P_0.controllerId);
					if (SJqyLkvNBPIiVWFIwwrwQgtQHWYV(elementType, axisRange, axisContribution, controller.GetElementById(P_0.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid).type, P_0.axisRange, P_0.axisContribution))
					{
						num++;
					}
				}
				using (IEnumerator<ActionElementMap> enumerator = elementAssignmentConflictInfo.controllerMap.ElementMapsWithAction(actionId).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						fIKgCRFEQFfiwcasQfjspeoGnMgCb fIKgCRFEQFfiwcasQfjspeoGnMgCb2 = new fIKgCRFEQFfiwcasQfjspeoGnMgCb();
						fIKgCRFEQFfiwcasQfjspeoGnMgCb2.VaZtTFbKGBxfGWIZtixRLhLhcPuL = enumerator.Current;
						if (fIKgCRFEQFfiwcasQfjspeoGnMgCb2.VaZtTFbKGBxfGWIZtixRLhLhcPuL.id != elementMap.id && ListTools.FindIndex(list, fIKgCRFEQFfiwcasQfjspeoGnMgCb2.CzhdokIDBlNqiVKmpnbeqTgWmlcdb) < 0 && SJqyLkvNBPIiVWFIwwrwQgtQHWYV(elementType, axisRange, axisContribution, fIKgCRFEQFfiwcasQfjspeoGnMgCb2.VaZtTFbKGBxfGWIZtixRLhLhcPuL.elementType, fIKgCRFEQFfiwcasQfjspeoGnMgCb2.VaZtTFbKGBxfGWIZtixRLhLhcPuL.axisRange, fIKgCRFEQFfiwcasQfjspeoGnMgCb2.VaZtTFbKGBxfGWIZtixRLhLhcPuL.axisContribution))
						{
							num++;
						}
					}
				}
				return num < P_3;
			}

			private bool cINCphiYTNEVLgNqkBhSHSPzOdmwA(QSnFbTeVaNXWBogrQFRJGLjjeSiCc P_0, ElementAssignment P_1, bool P_2, out string P_3)
			{
				if (P_0 == null)
				{
					P_3 = "Mapping is null reference.";
					return false;
				}
				List<Player> list = new List<Player> { P_0.uopsOvleFNCpPdWsuzaxAQwkQwXI };
				IList<ElementAssignmentConflictInfo> list2 = iuXJgxMUIcTlqtEmeqcwKnLfOaTA(P_0, P_1, list);
				int count = list2.Count;
				if (count == 0)
				{
					P_3 = "Swap was canceled because no conflicts were found.";
					return false;
				}
				if (count > 1)
				{
					P_3 = "Swap was canceled because more than one conflict was found.";
					return false;
				}
				if (P_2)
				{
					P_3 = "Swap was canceled due to a protected conflict that cannot be replaced.";
					return false;
				}
				if (P_0.KwtIpMQIvOEVbHZSkzaQjrsBaTTdA.actionElementMapToReplace == null)
				{
					P_3 = "Swap was canceled because this is not a replacement assignment.";
					return false;
				}
				ElementAssignmentConflictInfo elementAssignmentConflictInfo = list2[0];
				if (!elementAssignmentConflictInfo.isConflict)
				{
					P_3 = "Swap was canceled because conflict was invalid.";
					return false;
				}
				ActionElementMap actionElementMap = new ActionElementMap(elementAssignmentConflictInfo.elementMap);
				if (actionElementMap == null)
				{
					P_3 = "Swap was canceled because conflict ActionElementMap was null.";
					return false;
				}
				ActionElementMap actionElementMap2 = new ActionElementMap(P_0.KwtIpMQIvOEVbHZSkzaQjrsBaTTdA.actionElementMapToReplace);
				zmtZOtnIfpHofkblDQxTSumWqXCrA(P_0, P_1, list);
				int actionId = actionElementMap.actionId;
				Pole axisContribution = actionElementMap.axisContribution;
				bool invert = actionElementMap.invert;
				AxisRange axisRange = actionElementMap2.axisRange;
				ControllerElementType elementType = actionElementMap2.elementType;
				int elementIdentifierId = actionElementMap2.elementIdentifierId;
				KeyCode keyCode = actionElementMap2.keyCode;
				ModifierKeyFlags modifierKeyFlags = actionElementMap2.modifierKeyFlags;
				if (elementType == actionElementMap.elementType && elementType == ControllerElementType.Axis)
				{
					if (axisRange != actionElementMap.axisRange)
					{
						if (axisRange == AxisRange.Full)
						{
							axisRange = AxisRange.Positive;
						}
						else if (actionElementMap.axisRange != AxisRange.Full)
						{
						}
					}
				}
				else if (elementType == ControllerElementType.Axis && (actionElementMap.elementType == ControllerElementType.Button || (actionElementMap.elementType == ControllerElementType.Axis && actionElementMap.axisRange != AxisRange.Full)) && axisRange == AxisRange.Full)
				{
					axisRange = AxisRange.Positive;
				}
				if (elementType != ControllerElementType.Axis || axisRange != AxisRange.Full)
				{
					invert = false;
				}
				elementAssignmentConflictInfo.controllerMap.ReplaceOrCreateElementMap(ElementAssignment.CompleteAssignment(P_0.nEJgHsIiDHMIMmqsrrfbhTMPNTMHA, elementType, elementIdentifierId, axisRange, keyCode, modifierKeyFlags, actionId, axisContribution, invert));
				P_3 = null;
				return true;
			}

			private static bool SJqyLkvNBPIiVWFIwwrwQgtQHWYV(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
			{
				if ((P_0 == ControllerElementType.Button || (P_0 == ControllerElementType.Axis && P_1 != AxisRange.Full)) && (P_3 == ControllerElementType.Button || (P_3 == ControllerElementType.Axis && P_4 != AxisRange.Full)) && P_5 == P_2)
				{
					return true;
				}
				if (P_0 == ControllerElementType.Axis && P_1 == AxisRange.Full && P_3 == ControllerElementType.Axis && P_4 == AxisRange.Full)
				{
					return true;
				}
				return false;
			}

			private void WPeieKhvyeKSqLRkfddreHblQJCn(ActionElementMap P_0)
			{
				cYmBAOyFFWuILnBZdHJCvlZOjphX(P_0);
				DNutgKpCbKhAdDWxlzAQgQLgXgkX();
			}

			private void FtaVbOzmPQqYIDkGLnAMASkAFwbg(string P_0)
			{
				RbXLgunmYgRrdgLzwJPyhGAktCeF(P_0);
				DNutgKpCbKhAdDWxlzAQgQLgXgkX();
			}

			private leoFeDqQNiFfwdChpIjMjqBpwGxU UatVnwhBpBBABTGcAavraCXsRxnW(ElementAssignment P_0)
			{
				if (mZzbHRtusQdZIXDScCdfTbUEDeYd(ReCANcMASIdCrKkDVtpMlFHMFzYC.ConflictsFound))
				{
					bool flag = EtvSZAQCSxGFQYZIglIyHeLgZtAC(umdZNiUmFVgZGotxUUMrKGMVAZGbA, P_0, shMYACcsNLxJARbPVTdlosBSCnbx);
					xNRApwAJRVKHAyyGmxuIUsXhheoy = P_0;
					IList<ElementAssignmentConflictInfo> list = iuXJgxMUIcTlqtEmeqcwKnLfOaTA(umdZNiUmFVgZGotxUUMrKGMVAZGbA, P_0, shMYACcsNLxJARbPVTdlosBSCnbx);
					vjbgGFdtyiXcIWDiLBzeVhTRDpDK = PgQpvjrYuzqIBGXCGTaZCbwSzAfN.ConflictChecking;
					JxkrDpqaLCAjsnWeYutAvWsMkaDQ();
					uVvFTLEvDxCgxAfKTbWXbIyycxcGA(new ElementAssignmentInfo(umdZNiUmFVgZGotxUUMrKGMVAZGbA.KwtIpMQIvOEVbHZSkzaQjrsBaTTdA.controllerMap, P_0), list, flag);
					return leoFeDqQNiFfwdChpIjMjqBpwGxU.Quit;
				}
				return nFqQkABhusZpBVttEukhALayccubA(FQQwvVUGMHMtjYCVOlRokZMQbCUb.defaultActionWhenConflictFound, P_0);
			}

			private leoFeDqQNiFfwdChpIjMjqBpwGxU nFqQkABhusZpBVttEukhALayccubA(ConflictResponse P_0, ElementAssignment P_1)
			{
				return BsPchbBuNwCKDezeWxgpHTQtsNzLA(P_0, P_1, EtvSZAQCSxGFQYZIglIyHeLgZtAC(umdZNiUmFVgZGotxUUMrKGMVAZGbA, P_1, shMYACcsNLxJARbPVTdlosBSCnbx));
			}

			private leoFeDqQNiFfwdChpIjMjqBpwGxU BsPchbBuNwCKDezeWxgpHTQtsNzLA(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					FtaVbOzmPQqYIDkGLnAMASkAFwbg("Mapping assignment was canceled due to a conflict.");
					return leoFeDqQNiFfwdChpIjMjqBpwGxU.Quit;
				case ConflictResponse.Replace:
					if (P_2)
					{
						FtaVbOzmPQqYIDkGLnAMASkAFwbg("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return leoFeDqQNiFfwdChpIjMjqBpwGxU.Quit;
					}
					zmtZOtnIfpHofkblDQxTSumWqXCrA(umdZNiUmFVgZGotxUUMrKGMVAZGbA, P_1, shMYACcsNLxJARbPVTdlosBSCnbx);
					return leoFeDqQNiFfwdChpIjMjqBpwGxU.Continue;
				case ConflictResponse.Add:
					return leoFeDqQNiFfwdChpIjMjqBpwGxU.Continue;
				case ConflictResponse.Ignore:
					IcVVmKOPtSbHocqDkFCwcCvCkMUGc();
					return leoFeDqQNiFfwdChpIjMjqBpwGxU.Quit;
				case ConflictResponse.Swap:
				{
					if (!cINCphiYTNEVLgNqkBhSHSPzOdmwA(umdZNiUmFVgZGotxUUMrKGMVAZGbA, P_1, P_2, out var text))
					{
						FtaVbOzmPQqYIDkGLnAMASkAFwbg(text);
						return leoFeDqQNiFfwdChpIjMjqBpwGxU.Quit;
					}
					return leoFeDqQNiFfwdChpIjMjqBpwGxU.Continue;
				}
				default:
					throw new NotImplementedException();
				}
			}

			private void iChCsJDGimSMRGZPPLpPjIeXNCxdA()
			{
				jNFgNPePVjPXpEppKnCuUTHAhBSjB();
				DNutgKpCbKhAdDWxlzAQgQLgXgkX();
			}

			private void tqbuqpHYqHalOQEMHhThFCWClcUE(string P_0)
			{
				uGsztLdbfdSuFNoZjAxiyplqgeVK(P_0);
				DNutgKpCbKhAdDWxlzAQgQLgXgkX();
			}

			private void JxkrDpqaLCAjsnWeYutAvWsMkaDQ()
			{
				KQEAvvHDAoNBfYgcSJuqjlCJdpkab();
				AFZfoXhAALNAEEogQyrNQYYcDLqMA();
				aSzDRyjRMPtyCrcxRZhjodxziWAb = Status.AwaitingResponse;
			}

			private void IcVVmKOPtSbHocqDkFCwcCvCkMUGc()
			{
				aSzDRyjRMPtyCrcxRZhjodxziWAb = Status.Listening;
				vjbgGFdtyiXcIWDiLBzeVhTRDpDK = PgQpvjrYuzqIBGXCGTaZCbwSzAfN.None;
				YDQeKKiyEabGdLGCDdSVeCMCnXJtB();
				MDTvpmuzgefVPRvSqNRwgXErexqD();
			}

			private void hdozExdIPOhlxgzcVbXYBkUPGyidA(ElementAssignment P_0)
			{
				if (umdZNiUmFVgZGotxUUMrKGMVAZGbA.KwtIpMQIvOEVbHZSkzaQjrsBaTTdA.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					WPeieKhvyeKSqLRkfddreHblQJCn(result);
				}
				else
				{
					tqbuqpHYqHalOQEMHhThFCWClcUE("Failed to create element assignment.");
				}
			}

			private void cYmBAOyFFWuILnBZdHJCvlZOjphX(ActionElementMap P_0)
			{
				if (mZzbHRtusQdZIXDScCdfTbUEDeYd(ReCANcMASIdCrKkDVtpMlFHMFzYC.InputMapped))
				{
					DiDBgJhnxEwbidefzWxmmuTQakZH(ReCANcMASIdCrKkDVtpMlFHMFzYC.InputMapped, new InputMappedEventData(CIJkCcmtiXozjGvrMGaWTZPXJgQD, P_0));
				}
			}

			private void jNFgNPePVjPXpEppKnCuUTHAhBSjB()
			{
				if (mZzbHRtusQdZIXDScCdfTbUEDeYd(ReCANcMASIdCrKkDVtpMlFHMFzYC.TimedOut))
				{
					DiDBgJhnxEwbidefzWxmmuTQakZH(ReCANcMASIdCrKkDVtpMlFHMFzYC.TimedOut, new TimedOutEventData(CIJkCcmtiXozjGvrMGaWTZPXJgQD));
				}
			}

			private void uGsztLdbfdSuFNoZjAxiyplqgeVK(string P_0)
			{
				if (mZzbHRtusQdZIXDScCdfTbUEDeYd(ReCANcMASIdCrKkDVtpMlFHMFzYC.Error))
				{
					DiDBgJhnxEwbidefzWxmmuTQakZH(ReCANcMASIdCrKkDVtpMlFHMFzYC.Error, new ErrorEventData(CIJkCcmtiXozjGvrMGaWTZPXJgQD, P_0));
				}
			}

			private void RbXLgunmYgRrdgLzwJPyhGAktCeF(string P_0)
			{
				if (mZzbHRtusQdZIXDScCdfTbUEDeYd(ReCANcMASIdCrKkDVtpMlFHMFzYC.Canceled))
				{
					DiDBgJhnxEwbidefzWxmmuTQakZH(ReCANcMASIdCrKkDVtpMlFHMFzYC.Canceled, new CanceledEventData(CIJkCcmtiXozjGvrMGaWTZPXJgQD, P_0));
				}
			}

			private void uVvFTLEvDxCgxAfKTbWXbIyycxcGA(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				rVtPPrVWJUsaCVxKzsaHodBMsLfS rVtPPrVWJUsaCVxKzsaHodBMsLfS2 = new rVtPPrVWJUsaCVxKzsaHodBMsLfS();
				rVtPPrVWJUsaCVxKzsaHodBMsLfS2.vpGcKQdJrRHtAsUidJAyaSNCukexB = this;
				rVtPPrVWJUsaCVxKzsaHodBMsLfS2.lXKplYhgWkTlffAYXiRhOHGsDzHiA = P_0;
				rVtPPrVWJUsaCVxKzsaHodBMsLfS2.EibVhyfIgbHoQfRLbgVHDtpgCmTd = P_1;
				rVtPPrVWJUsaCVxKzsaHodBMsLfS2.JmjxMIHLfPxWHcpZjdTiHJrsGFbeA = P_2;
				if (mZzbHRtusQdZIXDScCdfTbUEDeYd(ReCANcMASIdCrKkDVtpMlFHMFzYC.ConflictsFound))
				{
					DiDBgJhnxEwbidefzWxmmuTQakZH(ReCANcMASIdCrKkDVtpMlFHMFzYC.ConflictsFound, new ConflictFoundEventData(CIJkCcmtiXozjGvrMGaWTZPXJgQD, HfHYocljJctCxsafUjamBHKVscVCA, rVtPPrVWJUsaCVxKzsaHodBMsLfS2.lXKplYhgWkTlffAYXiRhOHGsDzHiA, rVtPPrVWJUsaCVxKzsaHodBMsLfS2.EibVhyfIgbHoQfRLbgVHDtpgCmTd, rVtPPrVWJUsaCVxKzsaHodBMsLfS2.JmjxMIHLfPxWHcpZjdTiHJrsGFbeA, rVtPPrVWJUsaCVxKzsaHodBMsLfS2.HiCnkCxSCFGCmaGRDLRmSIWuMEpD));
				}
			}

			private void TnwHBvdzVhibbYlVVXmNxmVJksAo()
			{
				if (mZzbHRtusQdZIXDScCdfTbUEDeYd(ReCANcMASIdCrKkDVtpMlFHMFzYC.Started))
				{
					DiDBgJhnxEwbidefzWxmmuTQakZH(ReCANcMASIdCrKkDVtpMlFHMFzYC.Started, new StartedEventData(CIJkCcmtiXozjGvrMGaWTZPXJgQD));
				}
			}

			private void tRREFPfZtGlzuJtCVgWKzZgOUNpUA()
			{
				if (mZzbHRtusQdZIXDScCdfTbUEDeYd(ReCANcMASIdCrKkDVtpMlFHMFzYC.Stopped))
				{
					DiDBgJhnxEwbidefzWxmmuTQakZH(ReCANcMASIdCrKkDVtpMlFHMFzYC.Stopped, new StoppedEventData(CIJkCcmtiXozjGvrMGaWTZPXJgQD));
				}
			}

			public void HfHYocljJctCxsafUjamBHKVscVCA(ConflictResponse P_0)
			{
				if (aSzDRyjRMPtyCrcxRZhjodxziWAb != Status.AwaitingResponse || vjbgGFdtyiXcIWDiLBzeVhTRDpDK != PgQpvjrYuzqIBGXCGTaZCbwSzAfN.ConflictChecking)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (nFqQkABhusZpBVttEukhALayccubA(P_0, xNRApwAJRVKHAyyGmxuIUsXhheoy) == leoFeDqQNiFfwdChpIjMjqBpwGxU.Continue)
					{
						hdozExdIPOhlxgzcVbXYBkUPGyidA(xNRApwAJRVKHAyyGmxuIUsXhheoy);
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
			[Serializable]
			private sealed class wWSWgduZmXEpdNsWYSUSFLaFqrHs
			{
				public static readonly wWSWgduZmXEpdNsWYSUSFLaFqrHs _003C_003E9 = new wWSWgduZmXEpdNsWYSUSFLaFqrHs();

				public static Action<Exception> _003C_003E9__64_0;

				internal void sQxeSUCEKujoQBUFOVYiIegOpxWL(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
				}
			}

			private bool uZOtvLDSdhIhSxoClVHEoFQywWIE = true;

			private bool fCPvsNCrtMLRkykaqspEikUCEZNB = true;

			private bool DGeTkaBRWhvNEhLMEfYaGYhgfdHXA = true;

			private float wClUSmDBPFobZBiXvwFoYeyZbezgA;

			private bool UnynnAEkKWwxFaxgDDDhziobTrsk = true;

			private bool GSJTNowbZDFnXMGLLnQdDmOUWGYp = true;

			private bool DfYnKKNpEjjTMaMUJsANdgQDkbgU = true;

			private bool tsRVSDfpPmCDJhaXPMGViCbiqeoPc = true;

			private int[] URAgeVYiRgfQnfkCwkKhNBUswYvcA;

			private ConflictResponse saoSUnfPWIerdmtWMzKzBZUNjSyV = ConflictResponse.Replace;

			private bool qzFaiTKiDqvVThjrkyLUMmhyHeAt;

			private bool mvBvfUCFNqIsRibtZoovpxtnyHpY;

			private bool HIsdycIVMQlMQFzChPtFPhcgATPdA = true;

			private bool MHnqdLGphuAbqasNRhwbfzNoQhSR = true;

			private float QNIESKIMbIjgNvJBywIDMXXoBarBb = 1f;

			internal const string RytvSsqxnKGCENrCvxZArtZWrCsL = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> DDIUrYTEGxUJNOKErAAgDZLQmPgL = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			public bool allowAxes
			{
				get
				{
					return uZOtvLDSdhIhSxoClVHEoFQywWIE;
				}
				set
				{
					uZOtvLDSdhIhSxoClVHEoFQywWIE = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return fCPvsNCrtMLRkykaqspEikUCEZNB;
				}
				set
				{
					fCPvsNCrtMLRkykaqspEikUCEZNB = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return DGeTkaBRWhvNEhLMEfYaGYhgfdHXA;
				}
				set
				{
					DGeTkaBRWhvNEhLMEfYaGYhgfdHXA = value;
				}
			}

			public float timeout
			{
				get
				{
					return wClUSmDBPFobZBiXvwFoYeyZbezgA;
				}
				set
				{
					wClUSmDBPFobZBiXvwFoYeyZbezgA = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return UnynnAEkKWwxFaxgDDDhziobTrsk;
				}
				set
				{
					UnynnAEkKWwxFaxgDDDhziobTrsk = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return GSJTNowbZDFnXMGLLnQdDmOUWGYp;
				}
				set
				{
					GSJTNowbZDFnXMGLLnQdDmOUWGYp = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return DfYnKKNpEjjTMaMUJsANdgQDkbgU;
				}
				set
				{
					DfYnKKNpEjjTMaMUJsANdgQDkbgU = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return tsRVSDfpPmCDJhaXPMGViCbiqeoPc;
				}
				set
				{
					tsRVSDfpPmCDJhaXPMGViCbiqeoPc = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return URAgeVYiRgfQnfkCwkKhNBUswYvcA;
				}
				set
				{
					URAgeVYiRgfQnfkCwkKhNBUswYvcA = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return saoSUnfPWIerdmtWMzKzBZUNjSyV;
				}
				set
				{
					saoSUnfPWIerdmtWMzKzBZUNjSyV = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return qzFaiTKiDqvVThjrkyLUMmhyHeAt;
				}
				set
				{
					qzFaiTKiDqvVThjrkyLUMmhyHeAt = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return mvBvfUCFNqIsRibtZoovpxtnyHpY;
				}
				set
				{
					mvBvfUCFNqIsRibtZoovpxtnyHpY = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return HIsdycIVMQlMQFzChPtFPhcgATPdA;
				}
				set
				{
					HIsdycIVMQlMQFzChPtFPhcgATPdA = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return MHnqdLGphuAbqasNRhwbfzNoQhSR;
				}
				set
				{
					MHnqdLGphuAbqasNRhwbfzNoQhSR = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return QNIESKIMbIjgNvJBywIDMXXoBarBb;
				}
				set
				{
					QNIESKIMbIjgNvJBywIDMXXoBarBb = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)DDIUrYTEGxUJNOKErAAgDZLQmPgL["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = wWSWgduZmXEpdNsWYSUSFLaFqrHs._003C_003E9.sQxeSUCEKujoQBUFOVYiIegOpxWL;
					}
					DDIUrYTEGxUJNOKErAAgDZLQmPgL["isElementAllowed"] = safePredicate;
				}
			}

			internal _0001 mbJvfBoeiMkSejApNllSAGykfDEg<_0001>(string P_0) where _0001 : SafeDelegate
			{
				if (!DDIUrYTEGxUJNOKErAAgDZLQmPgL.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as _0001;
			}

			public Options()
			{
				zOllVIANVXKsHXIFYqdsMhFzFRdB();
			}

			private Options(Options P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("source");
				}
				Copy(P_0, this);
			}

			public Options Clone()
			{
				return new Options(this);
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("Options:\n");
				stringBuilder.Append("allowAxes = " + uZOtvLDSdhIhSxoClVHEoFQywWIE + "\n");
				stringBuilder.Append("allowButtons = " + fCPvsNCrtMLRkykaqspEikUCEZNB + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + DGeTkaBRWhvNEhLMEfYaGYhgfdHXA + "\n");
				stringBuilder.Append("timeout = " + wClUSmDBPFobZBiXvwFoYeyZbezgA + "\n");
				stringBuilder.Append("checkForConflicts = " + UnynnAEkKWwxFaxgDDDhziobTrsk + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + GSJTNowbZDFnXMGLLnQdDmOUWGYp + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + DfYnKKNpEjjTMaMUJsANdgQDkbgU + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + tsRVSDfpPmCDJhaXPMGViCbiqeoPc + "\n");
				if (URAgeVYiRgfQnfkCwkKhNBUswYvcA == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(URAgeVYiRgfQnfkCwkKhNBUswYvcA) + "\n");
				}
				stringBuilder.Append("defaultActionWhenConflictFound = " + saoSUnfPWIerdmtWMzKzBZUNjSyV.ToString() + "\n");
				stringBuilder.Append("ignoreMouseXAxis = " + qzFaiTKiDqvVThjrkyLUMmhyHeAt);
				stringBuilder.Append("ignoreMouseYAxis = " + mvBvfUCFNqIsRibtZoovpxtnyHpY);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + HIsdycIVMQlMQFzChPtFPhcgATPdA + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + MHnqdLGphuAbqasNRhwbfzNoQhSR + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + QNIESKIMbIjgNvJBywIDMXXoBarBb + "\n");
				return stringBuilder.ToString();
			}

			internal void zOllVIANVXKsHXIFYqdsMhFzFRdB()
			{
				uZOtvLDSdhIhSxoClVHEoFQywWIE = true;
				fCPvsNCrtMLRkykaqspEikUCEZNB = true;
				DGeTkaBRWhvNEhLMEfYaGYhgfdHXA = true;
				wClUSmDBPFobZBiXvwFoYeyZbezgA = 0f;
				UnynnAEkKWwxFaxgDDDhziobTrsk = true;
				GSJTNowbZDFnXMGLLnQdDmOUWGYp = true;
				DfYnKKNpEjjTMaMUJsANdgQDkbgU = true;
				tsRVSDfpPmCDJhaXPMGViCbiqeoPc = true;
				URAgeVYiRgfQnfkCwkKhNBUswYvcA = null;
				saoSUnfPWIerdmtWMzKzBZUNjSyV = ConflictResponse.Replace;
				qzFaiTKiDqvVThjrkyLUMmhyHeAt = false;
				mvBvfUCFNqIsRibtZoovpxtnyHpY = false;
				HIsdycIVMQlMQFzChPtFPhcgATPdA = true;
				MHnqdLGphuAbqasNRhwbfzNoQhSR = true;
				QNIESKIMbIjgNvJBywIDMXXoBarBb = 1f;
				foreach (string item in new List<string>(DDIUrYTEGxUJNOKErAAgDZLQmPgL.Keys))
				{
					DDIUrYTEGxUJNOKErAAgDZLQmPgL[item] = null;
				}
			}

			public static void Copy(Options source, Options destination)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				if (destination == null)
				{
					throw new ArgumentNullException("destination");
				}
				destination.uZOtvLDSdhIhSxoClVHEoFQywWIE = source.uZOtvLDSdhIhSxoClVHEoFQywWIE;
				destination.fCPvsNCrtMLRkykaqspEikUCEZNB = source.fCPvsNCrtMLRkykaqspEikUCEZNB;
				destination.DGeTkaBRWhvNEhLMEfYaGYhgfdHXA = source.DGeTkaBRWhvNEhLMEfYaGYhgfdHXA;
				destination.wClUSmDBPFobZBiXvwFoYeyZbezgA = source.wClUSmDBPFobZBiXvwFoYeyZbezgA;
				destination.UnynnAEkKWwxFaxgDDDhziobTrsk = source.UnynnAEkKWwxFaxgDDDhziobTrsk;
				destination.GSJTNowbZDFnXMGLLnQdDmOUWGYp = source.GSJTNowbZDFnXMGLLnQdDmOUWGYp;
				destination.DfYnKKNpEjjTMaMUJsANdgQDkbgU = source.DfYnKKNpEjjTMaMUJsANdgQDkbgU;
				destination.tsRVSDfpPmCDJhaXPMGViCbiqeoPc = source.tsRVSDfpPmCDJhaXPMGViCbiqeoPc;
				destination.URAgeVYiRgfQnfkCwkKhNBUswYvcA = ArrayTools.ShallowCopy(source.URAgeVYiRgfQnfkCwkKhNBUswYvcA);
				destination.saoSUnfPWIerdmtWMzKzBZUNjSyV = source.saoSUnfPWIerdmtWMzKzBZUNjSyV;
				destination.qzFaiTKiDqvVThjrkyLUMmhyHeAt = source.qzFaiTKiDqvVThjrkyLUMmhyHeAt;
				destination.mvBvfUCFNqIsRibtZoovpxtnyHpY = source.mvBvfUCFNqIsRibtZoovpxtnyHpY;
				destination.HIsdycIVMQlMQFzChPtFPhcgATPdA = source.HIsdycIVMQlMQFzChPtFPhcgATPdA;
				destination.MHnqdLGphuAbqasNRhwbfzNoQhSR = source.MHnqdLGphuAbqasNRhwbfzNoQhSR;
				destination.QNIESKIMbIjgNvJBywIDMXXoBarBb = source.QNIESKIMbIjgNvJBywIDMXXoBarBb;
				foreach (KeyValuePair<string, SafeDelegate> item in source.DDIUrYTEGxUJNOKErAAgDZLQmPgL)
				{
					destination.DDIUrYTEGxUJNOKErAAgDZLQmPgL[item.Key] = MiscTools.Clone(item.Value);
				}
			}
		}

		[Serializable]
		private sealed class eiwXKuHsyvIsXkjFvGyninlFzGGL
		{
			public static readonly eiwXKuHsyvIsXkjFvGyninlFzGGL _003C_003E9 = new eiwXKuHsyvIsXkjFvGyninlFzGGL();

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void AAeWJctgrWKUlJzrkEhZnOtmcSbjA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
			}

			internal void bcmHryvdMwiqUnuFuleIZzmSuUul(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
			}

			internal void HkfgDIFKYKQLZcnCMMXqgAcJMhMb(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
			}

			internal void czvsLntKJhGMlaNpxWDfasByBNqp(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
			}

			internal void EnKGQrgqJkjQegzTgQiALicWcvjRA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
			}

			internal void FcFDWXpMnOLkCMutkPTtBFhvoYxe(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
			}

			internal void sNNwrKDaqlCLOiLWbGkPidPPFsROA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
			}
		}

		private static InputMapper xcaudSGHhjpwTOkUDoWiHHgjZwsL;

		private static int JAqUcoPHbkaHfOjBSYHuTmHjvOtN;

		private readonly int qAjdgEtbTDVTRNohvoIauxZTSvTF;

		private readonly bool aIBGWdfHFntxGRDrWIrAOZkaZcJL;

		private readonly ieKntKIlEYZdqFrNMqcuKiTXdMfE CUVKUWyPkLedJTVkaCWeiTrtrOxp;

		private Options AcinBZNTlZGDkXCCNFhDVfXmQhiS;

		private readonly Dictionary<ReCANcMASIdCrKkDVtpMlFHMFzYC, SafeDelegate> xMSkRSSIfgBrExnUHRvRMaZulCgf = new Dictionary<ReCANcMASIdCrKkDVtpMlFHMFzYC, SafeDelegate>
		{
			{
				ReCANcMASIdCrKkDVtpMlFHMFzYC.InputMapped,
				new SafeAction<InputMappedEventData>(eiwXKuHsyvIsXkjFvGyninlFzGGL._003C_003E9.AAeWJctgrWKUlJzrkEhZnOtmcSbjA)
			},
			{
				ReCANcMASIdCrKkDVtpMlFHMFzYC.Error,
				new SafeAction<ErrorEventData>(eiwXKuHsyvIsXkjFvGyninlFzGGL._003C_003E9.bcmHryvdMwiqUnuFuleIZzmSuUul)
			},
			{
				ReCANcMASIdCrKkDVtpMlFHMFzYC.Canceled,
				new SafeAction<CanceledEventData>(eiwXKuHsyvIsXkjFvGyninlFzGGL._003C_003E9.HkfgDIFKYKQLZcnCMMXqgAcJMhMb)
			},
			{
				ReCANcMASIdCrKkDVtpMlFHMFzYC.TimedOut,
				new SafeAction<TimedOutEventData>(eiwXKuHsyvIsXkjFvGyninlFzGGL._003C_003E9.czvsLntKJhGMlaNpxWDfasByBNqp)
			},
			{
				ReCANcMASIdCrKkDVtpMlFHMFzYC.Started,
				new SafeAction<StartedEventData>(eiwXKuHsyvIsXkjFvGyninlFzGGL._003C_003E9.EnKGQrgqJkjQegzTgQiALicWcvjRA)
			},
			{
				ReCANcMASIdCrKkDVtpMlFHMFzYC.Stopped,
				new SafeAction<StoppedEventData>(eiwXKuHsyvIsXkjFvGyninlFzGGL._003C_003E9.FcFDWXpMnOLkCMutkPTtBFhvoYxe)
			},
			{
				ReCANcMASIdCrKkDVtpMlFHMFzYC.ConflictsFound,
				new SafeAction<ConflictFoundEventData>(eiwXKuHsyvIsXkjFvGyninlFzGGL._003C_003E9.sNNwrKDaqlCLOiLWbGkPidPPFsROA)
			}
		};

		public static InputMapper Default => xcaudSGHhjpwTOkUDoWiHHgjZwsL ?? (xcaudSGHhjpwTOkUDoWiHHgjZwsL = new InputMapper(true));

		public Options options
		{
			get
			{
				Options obj = AcinBZNTlZGDkXCCNFhDVfXmQhiS;
				if (obj == null)
				{
					if (!aIBGWdfHFntxGRDrWIrAOZkaZcJL)
					{
						return AcinBZNTlZGDkXCCNFhDVfXmQhiS = Default.options.Clone();
					}
					obj = (AcinBZNTlZGDkXCCNFhDVfXmQhiS = new Options());
				}
				return obj;
			}
			set
			{
				AcinBZNTlZGDkXCCNFhDVfXmQhiS = value;
			}
		}

		public Context mappingContext => CUVKUWyPkLedJTVkaCWeiTrtrOxp.pCqBKmBbdwibLbrfIjsSZUjsLCUgA;

		public Status status => CUVKUWyPkLedJTVkaCWeiTrtrOxp.PdgEqxkxVTdEVBaPFtyCinvCqLMub;

		public float timeRemaining => CUVKUWyPkLedJTVkaCWeiTrtrOxp.MKmeDRKjFOYdjMTMpIycLdUyGMix;

		internal int TZLCItOSWMGThPGxOfJONUOXRwfe => qAjdgEtbTDVTRNohvoIauxZTSvTF;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.InputMapped;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<InputMappedEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.InputMapped;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<InputMappedEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.Error;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<ErrorEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.Error;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<ErrorEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.Canceled;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<CanceledEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.Canceled;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<CanceledEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.TimedOut;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<TimedOutEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.TimedOut;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<TimedOutEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.Started;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<StartedEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.Started;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<StartedEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.Stopped;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<StoppedEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.Stopped;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<StoppedEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.ConflictsFound;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<ConflictFoundEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					ReCANcMASIdCrKkDVtpMlFHMFzYC key = ReCANcMASIdCrKkDVtpMlFHMFzYC.ConflictsFound;
					xMSkRSSIfgBrExnUHRvRMaZulCgf[key] = (SafeAction<ConflictFoundEventData>)xMSkRSSIfgBrExnUHRvRMaZulCgf[key] - value;
				}
			}
		}

		private static int yVkKWDvowEfjdkiQIdcylfhuEsXeA()
		{
			int jAqUcoPHbkaHfOjBSYHuTmHjvOtN = JAqUcoPHbkaHfOjBSYHuTmHjvOtN;
			if (JAqUcoPHbkaHfOjBSYHuTmHjvOtN == int.MaxValue)
			{
				JAqUcoPHbkaHfOjBSYHuTmHjvOtN = 0;
				return jAqUcoPHbkaHfOjBSYHuTmHjvOtN;
			}
			JAqUcoPHbkaHfOjBSYHuTmHjvOtN++;
			return jAqUcoPHbkaHfOjBSYHuTmHjvOtN;
		}

		public InputMapper()
			: this(false)
		{
			qAjdgEtbTDVTRNohvoIauxZTSvTF = yVkKWDvowEfjdkiQIdcylfhuEsXeA();
		}

		private InputMapper(bool P_0)
		{
			aIBGWdfHFntxGRDrWIrAOZkaZcJL = P_0;
			if (aIBGWdfHFntxGRDrWIrAOZkaZcJL)
			{
				AcinBZNTlZGDkXCCNFhDVfXmQhiS = new Options();
			}
			CUVKUWyPkLedJTVkaCWeiTrtrOxp = new ieKntKIlEYZdqFrNMqcuKiTXdMfE(this, xMSkRSSIfgBrExnUHRvRMaZulCgf);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<ReCANcMASIdCrKkDVtpMlFHMFzYC, SafeDelegate> item in xMSkRSSIfgBrExnUHRvRMaZulCgf)
			{
				item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<ReCANcMASIdCrKkDVtpMlFHMFzYC, SafeDelegate> item in xMSkRSSIfgBrExnUHRvRMaZulCgf)
			{
				item.Value.Clear();
			}
		}

		internal void rTGVoHxJGEwlxsucJLsZuhhdQMrE(object P_0)
		{
		}

		internal void iivldqrqVACdMOmERoYXMnJeinkp()
		{
		}

		public bool Start(Context mappingContext)
		{
			return MEBTyKukKtxoqavgKQAXhzuOpaVB(mappingContext, (AcinBZNTlZGDkXCCNFhDVfXmQhiS != null) ? AcinBZNTlZGDkXCCNFhDVfXmQhiS : Default.options);
		}

		public void Stop()
		{
			CUVKUWyPkLedJTVkaCWeiTrtrOxp.OefapYaCxlIBuWtoOJmAZSsnrHegA("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			iivldqrqVACdMOmERoYXMnJeinkp();
			AcinBZNTlZGDkXCCNFhDVfXmQhiS = null;
		}

		private bool MEBTyKukKtxoqavgKQAXhzuOpaVB(Context P_0, Options P_1)
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
				Logger.LogError("The Controller Map cannot be null.");
				return false;
			}
			if (P_0.actionElementMapToReplace != null && !P_0.controllerMap.ContainsElementMap(P_0.actionElementMapToReplace))
			{
				Logger.LogError("The Action Element Map must belong to the same Controller Map you are passing in.");
				return false;
			}
			try
			{
				CUVKUWyPkLedJTVkaCWeiTrtrOxp.bnpQZBVCyACVLrZgOevBKcCoZoOn(P_0, P_1);
				return true;
			}
			catch
			{
				CUVKUWyPkLedJTVkaCWeiTrtrOxp.OefapYaCxlIBuWtoOJmAZSsnrHegA("Failed to start due to an exception.");
				return false;
			}
		}
	}
}
