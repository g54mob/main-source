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
			private int sYJRVeNfkEmVSVMYmgDbWMYSrmAd = -1;

			private ControllerMap FBoVVchtCakVtTCnbKZVVHSBWMzK;

			private ActionElementMap BSfOLfVCrzaaQJItJpHQMBiPhxwi;

			private AxisRange TJwMmcJRGqHfPeEmhqJVbYNntxShA = AxisRange.Positive;

			private bool GoRUltsgUjYVoXfEIutCDGturwlB;

			public int actionId
			{
				get
				{
					return sYJRVeNfkEmVSVMYmgDbWMYSrmAd;
				}
				set
				{
					if (!EBXkAPZzhChSxdWppAfCoqdndpCv())
					{
						sYJRVeNfkEmVSVMYmgDbWMYSrmAd = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(sYJRVeNfkEmVSVMYmgDbWMYSrmAd);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!EBXkAPZzhChSxdWppAfCoqdndpCv())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							sYJRVeNfkEmVSVMYmgDbWMYSrmAd = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							sYJRVeNfkEmVSVMYmgDbWMYSrmAd = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return FBoVVchtCakVtTCnbKZVVHSBWMzK;
				}
				set
				{
					if (!EBXkAPZzhChSxdWppAfCoqdndpCv())
					{
						FBoVVchtCakVtTCnbKZVVHSBWMzK = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return BSfOLfVCrzaaQJItJpHQMBiPhxwi;
				}
				set
				{
					if (!EBXkAPZzhChSxdWppAfCoqdndpCv())
					{
						BSfOLfVCrzaaQJItJpHQMBiPhxwi = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return TJwMmcJRGqHfPeEmhqJVbYNntxShA;
				}
				set
				{
					if (!EBXkAPZzhChSxdWppAfCoqdndpCv())
					{
						TJwMmcJRGqHfPeEmhqJVbYNntxShA = value;
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

			internal void asPxrrUfTLGJUdWDOJkBxpwZgknHb()
			{
				GoRUltsgUjYVoXfEIutCDGturwlB = true;
			}

			private bool EBXkAPZzhChSxdWppAfCoqdndpCv()
			{
				if (GoRUltsgUjYVoXfEIutCDGturwlB)
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
				destination.sYJRVeNfkEmVSVMYmgDbWMYSrmAd = source.sYJRVeNfkEmVSVMYmgDbWMYSrmAd;
				destination.FBoVVchtCakVtTCnbKZVVHSBWMzK = source.FBoVVchtCakVtTCnbKZVVHSBWMzK;
				destination.BSfOLfVCrzaaQJItJpHQMBiPhxwi = source.BSfOLfVCrzaaQJItJpHQMBiPhxwi;
				destination.TJwMmcJRGqHfPeEmhqJVbYNntxShA = source.TJwMmcJRGqHfPeEmhqJVbYNntxShA;
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

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4)
				: base(P_0)
			{
				responseCallback = P_1;
				assignment = P_2;
				conflicts = P_3;
				isProtected = P_4;
			}
		}

		private enum MGtACJNVIlQSuUmWlUrtRXeaTawG
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

		private class dppjtCFjgjaMfHGtqCNPcOkvHtJz
		{
			private enum kIXdRqztWPKujvivFzGlXRLTFSPn
			{
				Quit = 0,
				Continue = 1
			}

			private enum OWnKnWwTdMfnKSSAcEXsiAqubIZeA
			{
				None = 0,
				ConflictChecking = 1
			}

			private class LICVlyQEjkgpAiunwewkRttUTSEpA
			{
				private Player DsazGynabEZfvHpnEoEnpeuIELmM;

				private int mkrGJgHocQwCFFarpqyDUJkMirub;

				private Context VBtVRugAtUdgDGLywIUaHXfVJiPP;

				private ControllerType leWboadhmzgCnbEonjPbZOCSAfSi;

				private int pliGIhfpcuvgNXviuOrFnrXjEnSH;

				private ControllerPollingInfo BFIKpoDOFwWBYXNnZRoHCzrDHmrX;

				private ModifierKeyFlags YpOUzxoCzyIkIHNIWguFcmEVnApwA;

				public Player fDOuIBgGgybcYrexSUEKmsyMCohd => DsazGynabEZfvHpnEoEnpeuIELmM;

				public int CGpcGASfmTjNlKXwbIAIPLSayjtTA => mkrGJgHocQwCFFarpqyDUJkMirub;

				public Context JdANzzNwanduuHVEQHXpDTutPvxJ => VBtVRugAtUdgDGLywIUaHXfVJiPP;

				public ControllerType gKeTJHtLKgSjXeTyVkQUxWWzMLcP => leWboadhmzgCnbEonjPbZOCSAfSi;

				public int wyIvxFQRBjuePPRbunsmVFJcBdIl => pliGIhfpcuvgNXviuOrFnrXjEnSH;

				public ControllerPollingInfo QjiCrcjApWdpHPMUWeLSPAuifoHKA => BFIKpoDOFwWBYXNnZRoHCzrDHmrX;

				public ModifierKeyFlags BsrTGGxJdvPklsGHKkNgCQhzdJJJA => YpOUzxoCzyIkIHNIWguFcmEVnApwA;

				public AxisRange XVLmDSEhUTfZSHfAkAufXfkcjJIFA
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (QjiCrcjApWdpHPMUWeLSPAuifoHKA.elementType == ControllerElementType.Axis)
						{
							result = ((VBtVRugAtUdgDGLywIUaHXfVJiPP.actionRange != AxisRange.Full) ? ((QjiCrcjApWdpHPMUWeLSPAuifoHKA.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
						}
						return result;
					}
				}

				public string ADCoYDoppvecmoCEoKcrhLEXLXJo
				{
					get
					{
						if (gKeTJHtLKgSjXeTyVkQUxWWzMLcP == ControllerType.Keyboard && BsrTGGxJdvPklsGHKkNgCQhzdJJJA != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(BsrTGGxJdvPklsGHKkNgCQhzdJJJA)} + {QjiCrcjApWdpHPMUWeLSPAuifoHKA.elementIdentifierName}";
						}
						string text = QjiCrcjApWdpHPMUWeLSPAuifoHKA.elementIdentifierName;
						if (QjiCrcjApWdpHPMUWeLSPAuifoHKA.elementType == ControllerElementType.Axis)
						{
							if (XVLmDSEhUTfZSHfAkAufXfkcjJIFA == AxisRange.Positive)
							{
								text += " +";
							}
							else if (XVLmDSEhUTfZSHfAkAufXfkcjJIFA == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				public void lMAzecBzSKvzDDdqXWCkLVeeWsC(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					cvjDMOdWHpOiWzveFAuDkIlbITyT();
					DsazGynabEZfvHpnEoEnpeuIELmM = P_0;
					mkrGJgHocQwCFFarpqyDUJkMirub = P_1.actionId;
					leWboadhmzgCnbEonjPbZOCSAfSi = P_1.controllerMap.controllerType;
					pliGIhfpcuvgNXviuOrFnrXjEnSH = P_1.controllerMap.controllerId;
					VBtVRugAtUdgDGLywIUaHXfVJiPP = P_1;
					leWboadhmzgCnbEonjPbZOCSAfSi = P_1.controllerMap.controllerType;
					pliGIhfpcuvgNXviuOrFnrXjEnSH = P_1.controllerMap.controllerId;
					P_1.asPxrrUfTLGJUdWDOJkBxpwZgknHb();
				}

				public void cvjDMOdWHpOiWzveFAuDkIlbITyT()
				{
					DsazGynabEZfvHpnEoEnpeuIELmM = null;
					mkrGJgHocQwCFFarpqyDUJkMirub = -1;
					VBtVRugAtUdgDGLywIUaHXfVJiPP = null;
					leWboadhmzgCnbEonjPbZOCSAfSi = ControllerType.Keyboard;
					pliGIhfpcuvgNXviuOrFnrXjEnSH = -1;
					BFIKpoDOFwWBYXNnZRoHCzrDHmrX = default(ControllerPollingInfo);
					YpOUzxoCzyIkIHNIWguFcmEVnApwA = ModifierKeyFlags.None;
				}

				public ElementAssignment hewpwPDVPicFblKGoDPkfblvxxyeA(ControllerPollingInfo P_0)
				{
					BFIKpoDOFwWBYXNnZRoHCzrDHmrX = P_0;
					return cCphqRlByImJsvwqrJfdxPMuStgV();
				}

				public ElementAssignment FpjeJlsZIDqyDnqfUvEJOqKpWqki(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					BFIKpoDOFwWBYXNnZRoHCzrDHmrX = P_0;
					YpOUzxoCzyIkIHNIWguFcmEVnApwA = P_1;
					return cCphqRlByImJsvwqrJfdxPMuStgV();
				}

				public ElementAssignment cCphqRlByImJsvwqrJfdxPMuStgV()
				{
					return new ElementAssignment(gKeTJHtLKgSjXeTyVkQUxWWzMLcP, BFIKpoDOFwWBYXNnZRoHCzrDHmrX.elementType, BFIKpoDOFwWBYXNnZRoHCzrDHmrX.elementIdentifierId, XVLmDSEhUTfZSHfAkAufXfkcjJIFA, BFIKpoDOFwWBYXNnZRoHCzrDHmrX.keyboardKey, YpOUzxoCzyIkIHNIWguFcmEVnApwA, mkrGJgHocQwCFFarpqyDUJkMirub, (VBtVRugAtUdgDGLywIUaHXfVJiPP.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (VBtVRugAtUdgDGLywIUaHXfVJiPP.actionElementMapToReplace != null) ? VBtVRugAtUdgDGLywIUaHXfVJiPP.actionElementMapToReplace.id : (-1));
				}
			}

			private readonly InputMapper NJsiaFtHkmVeiWqnazqldYTbPdsK;

			private readonly Options IufqWGFBpatzyEWouMPuQDheroyD = new Options();

			private readonly LICVlyQEjkgpAiunwewkRttUTSEpA dqKeDPFLEgXqXrupqRhUPyMjsHwWA = new LICVlyQEjkgpAiunwewkRttUTSEpA();

			private readonly Dictionary<MGtACJNVIlQSuUmWlUrtRXeaTawG, SafeDelegate> EikNZBHhFHKDmMOEmmxQWwLKIkGA;

			private readonly Dictionary<string, SafeDelegate> GedetoRmewxvKEWgLRFxYAZebxsF;

			private Status vmMHWiqEOwMcdnEwtqmACFlNwYsi;

			private OWnKnWwTdMfnKSSAcEXsiAqubIZeA aDCdscsPfNigJgEghAkBznNnAXpgb;

			private double FHJdthkndqgGcysQqbZvGWyYYjiMA;

			private bool nURqIndxuoLyTzEXbLmNnGQigKuq;

			private List<Player> pGzbOnJtWwecNhLNghMQaYRQajDlc = new List<Player>();

			private readonly List<ControllerPollingInfo> bMqrTMitjqcPBMnFYVgftrCxZkPw = new List<ControllerPollingInfo>();

			private ElementAssignment sgaypZIxOmQiDedKOGDhdiBHZmWNA;

			public Status OLJSuCkDAyLhOcLTJzJrRLfYvJct => vmMHWiqEOwMcdnEwtqmACFlNwYsi;

			public float NfVQFmTVMnjCiAYQPMBNplQWPYGq
			{
				get
				{
					if (vmMHWiqEOwMcdnEwtqmACFlNwYsi == Status.Idle)
					{
						return 0f;
					}
					if (IufqWGFBpatzyEWouMPuQDheroyD.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, FHJdthkndqgGcysQqbZvGWyYYjiMA + (double)IufqWGFBpatzyEWouMPuQDheroyD.timeout - ReInput.unscaledTime);
				}
			}

			public Context slPMYZQGeBSPWjEpuTevqUjMANsj
			{
				get
				{
					if (vmMHWiqEOwMcdnEwtqmACFlNwYsi == Status.Idle)
					{
						return null;
					}
					return dqKeDPFLEgXqXrupqRhUPyMjsHwWA.JdANzzNwanduuHVEQHXpDTutPvxJ;
				}
			}

			private bool ZHCEmEpSUEPkbLESwngzErPeRvkv
			{
				get
				{
					if (nURqIndxuoLyTzEXbLmNnGQigKuq)
					{
						return false;
					}
					if (!(IufqWGFBpatzyEWouMPuQDheroyD.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public dppjtCFjgjaMfHGtqCNPcOkvHtJz(InputMapper P_0, Dictionary<MGtACJNVIlQSuUmWlUrtRXeaTawG, SafeDelegate> P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("events");
				}
				NJsiaFtHkmVeiWqnazqldYTbPdsK = P_0;
				EikNZBHhFHKDmMOEmmxQWwLKIkGA = P_1;
				IQBXZEBZzmJhwVxSivMphRokwBQl();
			}

			protected virtual void TUtFzRBdQjznqVpTasnciMfkjFZBb()
			{
				try
				{
					NnaTqwHFXyqfFkrikFQijeEYDZIqA();
				}
				finally
				{
					base.Finalize();
				}
			}

			public void iMIGXsUhjrQwAfEuqDAgHeYCiamhA(Context P_0, Options P_1)
			{
				if (vmMHWiqEOwMcdnEwtqmACFlNwYsi != Status.Idle)
				{
					ATLaDdgkIhgVLEROlPQfFcyaUXZEA("User started a new listening session.");
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
				Options.Copy(P_1, IufqWGFBpatzyEWouMPuQDheroyD);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					oPMqKdWNmkNXLIMhnOdMtCTsxAkC("No Action found for actionId: " + P_0.actionId);
					return;
				}
				dqKeDPFLEgXqXrupqRhUPyMjsHwWA.lMAzecBzSKvzDDdqXWCkLVeeWsC(player, P_0);
				vmMHWiqEOwMcdnEwtqmACFlNwYsi = Status.Listening;
				LDfBMbavJTMhquUEdlnuKyGNHVtrA();
				nXvZRfxAWIYjVSfRXINzeZavihae();
				FgcpBPxwPDGZUJlPCifDYPRPyQYd();
				ElHsBKkTMSlGiCQFtwLsJKLrBeqGA();
			}

			public void TBOcnnHRoApyhohsipDpPykVCXUAA(string P_0)
			{
				if (vmMHWiqEOwMcdnEwtqmACFlNwYsi != Status.Idle)
				{
					ATLaDdgkIhgVLEROlPQfFcyaUXZEA(P_0);
				}
			}

			private void vOWsvKfJVHZNYbEvJEoQumvZrULX(UpdateLoopType P_0)
			{
				if (P_0 == UpdateLoopType.Update && vmMHWiqEOwMcdnEwtqmACFlNwYsi == Status.Listening)
				{
					ElementAssignment elementAssignment;
					if (ZHCEmEpSUEPkbLESwngzErPeRvkv && NfVQFmTVMnjCiAYQPMBNplQWPYGq <= 0f)
					{
						bfUZeyPorTntMTgLdIWsmIydkSTT();
					}
					else if (ReInput.controllers.GetController(dqKeDPFLEgXqXrupqRhUPyMjsHwWA.gKeTJHtLKgSjXeTyVkQUxWWzMLcP, dqKeDPFLEgXqXrupqRhUPyMjsHwWA.wyIvxFQRBjuePPRbunsmVFJcBdIl) == null)
					{
						oPMqKdWNmkNXLIMhnOdMtCTsxAkC("Controller not found for type: " + dqKeDPFLEgXqXrupqRhUPyMjsHwWA.gKeTJHtLKgSjXeTyVkQUxWWzMLcP.ToString() + " id: " + dqKeDPFLEgXqXrupqRhUPyMjsHwWA.wyIvxFQRBjuePPRbunsmVFJcBdIl);
					}
					else if (JHdVLGaqkApCIloWNpJgazKSWpeQ(out elementAssignment) != kIXdRqztWPKujvivFzGlXRLTFSPn.Quit && DDUqtteFaAUwFUgMJRkGOEqcDDrT(elementAssignment) != kIXdRqztWPKujvivFzGlXRLTFSPn.Quit)
					{
						kKBcEWbgYfVGwalitNwvOhExogSvA(elementAssignment);
					}
				}
			}

			private void KfXfwlayqhibiwInBNrlZSBGpuMBA()
			{
				if (vmMHWiqEOwMcdnEwtqmACFlNwYsi != Status.Idle)
				{
					IQBXZEBZzmJhwVxSivMphRokwBQl();
					NnaTqwHFXyqfFkrikFQijeEYDZIqA();
					iJmvHaEpsdeAdghIvwljdtoyJXVBb();
				}
			}

			private void IQBXZEBZzmJhwVxSivMphRokwBQl()
			{
				vmMHWiqEOwMcdnEwtqmACFlNwYsi = Status.Idle;
				FHJdthkndqgGcysQqbZvGWyYYjiMA = 0.0;
				IufqWGFBpatzyEWouMPuQDheroyD.wzhxusTiYodGnFSYuXgSgClPNgjJ();
				dqKeDPFLEgXqXrupqRhUPyMjsHwWA.cvjDMOdWHpOiWzveFAuDkIlbITyT();
				sgaypZIxOmQiDedKOGDhdiBHZmWNA = default(ElementAssignment);
				aDCdscsPfNigJgEghAkBznNnAXpgb = OWnKnWwTdMfnKSSAcEXsiAqubIZeA.None;
				nURqIndxuoLyTzEXbLmNnGQigKuq = false;
				pGzbOnJtWwecNhLNghMQaYRQajDlc.Clear();
			}

			private kIXdRqztWPKujvivFzGlXRLTFSPn JHdVLGaqkApCIloWNpJgazKSWpeQ(out ElementAssignment P_0)
			{
				if (!OjGBSZgknmZxJPkieqfuJmCCltttA(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return kIXdRqztWPKujvivFzGlXRLTFSPn.Quit;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !exrKswzfcXFNZFWNdSQQOHvzJvd(item, IufqWGFBpatzyEWouMPuQDheroyD))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return kIXdRqztWPKujvivFzGlXRLTFSPn.Quit;
				}
				if (!RmBakNFSCmeDemUgWcQgDZmibMFtb(dqKeDPFLEgXqXrupqRhUPyMjsHwWA, controllerPollingInfo, IufqWGFBpatzyEWouMPuQDheroyD))
				{
					P_0 = default(ElementAssignment);
					return kIXdRqztWPKujvivFzGlXRLTFSPn.Quit;
				}
				P_0 = dqKeDPFLEgXqXrupqRhUPyMjsHwWA.hewpwPDVPicFblKGoDPkfblvxxyeA(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return kIXdRqztWPKujvivFzGlXRLTFSPn.Continue;
			}

			private bool OjGBSZgknmZxJPkieqfuJmCCltttA(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = dqKeDPFLEgXqXrupqRhUPyMjsHwWA.gKeTJHtLKgSjXeTyVkQUxWWzMLcP;
				int controllerId = dqKeDPFLEgXqXrupqRhUPyMjsHwWA.wyIvxFQRBjuePPRbunsmVFJcBdIl;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = mmwUdDJGbcHMARJRcJyvHqVfVhVH(out P_1);
					return true;
				}
				if (IufqWGFBpatzyEWouMPuQDheroyD.allowAxes)
				{
					if (IufqWGFBpatzyEWouMPuQDheroyD.allowButtons)
					{
						if (dqKeDPFLEgXqXrupqRhUPyMjsHwWA.fDOuIBgGgybcYrexSUEKmsyMCohd != null)
						{
							P_0 = dqKeDPFLEgXqXrupqRhUPyMjsHwWA.fDOuIBgGgybcYrexSUEKmsyMCohd.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(dqKeDPFLEgXqXrupqRhUPyMjsHwWA.gKeTJHtLKgSjXeTyVkQUxWWzMLcP, dqKeDPFLEgXqXrupqRhUPyMjsHwWA.wyIvxFQRBjuePPRbunsmVFJcBdIl);
						}
					}
					else if (dqKeDPFLEgXqXrupqRhUPyMjsHwWA.fDOuIBgGgybcYrexSUEKmsyMCohd != null)
					{
						P_0 = dqKeDPFLEgXqXrupqRhUPyMjsHwWA.fDOuIBgGgybcYrexSUEKmsyMCohd.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!IufqWGFBpatzyEWouMPuQDheroyD.allowButtons)
					{
						oPMqKdWNmkNXLIMhnOdMtCTsxAkC("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (dqKeDPFLEgXqXrupqRhUPyMjsHwWA.fDOuIBgGgybcYrexSUEKmsyMCohd != null)
					{
						P_0 = dqKeDPFLEgXqXrupqRhUPyMjsHwWA.fDOuIBgGgybcYrexSUEKmsyMCohd.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> mmwUdDJGbcHMARJRcJyvHqVfVhVH(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				bMqrTMitjqcPBMnFYVgftrCxZkPw.Clear();
				if (!IufqWGFBpatzyEWouMPuQDheroyD.allowButtons)
				{
					return bMqrTMitjqcPBMnFYVgftrCxZkPw;
				}
				bMqrTMitjqcPBMnFYVgftrCxZkPw.Add(wIrMRXyHPWbIPfclMRKoCoQggxODb(IufqWGFBpatzyEWouMPuQDheroyD, out P_0));
				return bMqrTMitjqcPBMnFYVgftrCxZkPw;
			}

			private ControllerPollingInfo wIrMRXyHPWbIPfclMRKoCoQggxODb(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = cnUczGeQxZDOAPGyuBPFIYKdvjFJc(P_0, out flag, out P_1, out text);
				if (flag)
				{
					LDfBMbavJTMhquUEdlnuKyGNHVtrA();
				}
				return result;
			}

			private static ControllerPollingInfo cnUczGeQxZDOAPGyuBPFIYKdvjFJc(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
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
						P_3 = Keyboard.ModifierKeyFlagsToString(modifierKeyFlags);
					}
				}
				return default(ControllerPollingInfo);
			}

			private static bool exrKswzfcXFNZFWNdSQQOHvzJvd(ControllerPollingInfo P_0, Options P_1)
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
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.zRuzfabttzRtRjhcvSHfwifAnhwg<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool RmBakNFSCmeDemUgWcQgDZmibMFtb(LICVlyQEjkgpAiunwewkRttUTSEpA P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.XVLmDSEhUTfZSHfAkAufXfkcjJIFA == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void nXvZRfxAWIYjVSfRXINzeZavihae()
			{
				if (!IufqWGFBpatzyEWouMPuQDheroyD.checkForConflicts)
				{
					return;
				}
				if (IufqWGFBpatzyEWouMPuQDheroyD.checkForConflictsWithSelf && dqKeDPFLEgXqXrupqRhUPyMjsHwWA.fDOuIBgGgybcYrexSUEKmsyMCohd != null)
				{
					ListTools.AddIfUnique(pGzbOnJtWwecNhLNghMQaYRQajDlc, dqKeDPFLEgXqXrupqRhUPyMjsHwWA.fDOuIBgGgybcYrexSUEKmsyMCohd);
				}
				if (IufqWGFBpatzyEWouMPuQDheroyD.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(pGzbOnJtWwecNhLNghMQaYRQajDlc, ReInput.players.SystemPlayer);
				}
				if (IufqWGFBpatzyEWouMPuQDheroyD.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(pGzbOnJtWwecNhLNghMQaYRQajDlc, players[i]);
					}
				}
				else
				{
					if (IufqWGFBpatzyEWouMPuQDheroyD.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(IufqWGFBpatzyEWouMPuQDheroyD.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(pGzbOnJtWwecNhLNghMQaYRQajDlc, allPlayers[j]);
						}
					}
				}
			}

			private kIXdRqztWPKujvivFzGlXRLTFSPn DDUqtteFaAUwFUgMJRkGOEqcDDrT(ElementAssignment P_0)
			{
				if (IufqWGFBpatzyEWouMPuQDheroyD.checkForConflicts && dqKeDPFLEgXqXrupqRhUPyMjsHwWA.fDOuIBgGgybcYrexSUEKmsyMCohd != null && wTRdTgIwGlYatRHencIhZXmqnwUH(dqKeDPFLEgXqXrupqRhUPyMjsHwWA, P_0, pGzbOnJtWwecNhLNghMQaYRQajDlc))
				{
					return VZEFmVoviqbdEXFsufSSebJYPnRt(P_0);
				}
				return kIXdRqztWPKujvivFzGlXRLTFSPn.Continue;
			}

			private static bool wTRdTgIwGlYatRHencIhZXmqnwUH(LICVlyQEjkgpAiunwewkRttUTSEpA P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.fDOuIBgGgybcYrexSUEKmsyMCohd == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!iwtluIWSMnSxtapZcXZNCADLujFm(P_0, P_1, out var conflictCheck))
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

			private static bool BQfMhEVXEKdPfSZMFAJrfqMkRwWA(LICVlyQEjkgpAiunwewkRttUTSEpA P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.fDOuIBgGgybcYrexSUEKmsyMCohd == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!iwtluIWSMnSxtapZcXZNCADLujFm(P_0, P_1, out var conflictCheck))
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

			private static IList<ElementAssignmentConflictInfo> dYXJKJLfFlqYihiUEJcPqQvpKNSI(LICVlyQEjkgpAiunwewkRttUTSEpA P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.fDOuIBgGgybcYrexSUEKmsyMCohd == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!iwtluIWSMnSxtapZcXZNCADLujFm(P_0, P_1, out var conflictCheck))
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

			private static bool iwtluIWSMnSxtapZcXZNCADLujFm(LICVlyQEjkgpAiunwewkRttUTSEpA P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				if (P_0 == null || (player = P_0.fDOuIBgGgybcYrexSUEKmsyMCohd) == null)
				{
					P_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				P_2 = P_1.ToElementAssignmentConflictCheck();
				P_2.playerId = player.id;
				P_2.controllerType = P_0.gKeTJHtLKgSjXeTyVkQUxWWzMLcP;
				P_2.controllerId = P_0.wyIvxFQRBjuePPRbunsmVFJcBdIl;
				P_2.controllerMapId = P_0.JdANzzNwanduuHVEQHXpDTutPvxJ.controllerMap.id;
				P_2.controllerMapCategoryId = P_0.JdANzzNwanduuHVEQHXpDTutPvxJ.controllerMap.categoryId;
				if (P_0.JdANzzNwanduuHVEQHXpDTutPvxJ.actionElementMapToReplace != null)
				{
					P_2.elementMapId = P_0.JdANzzNwanduuHVEQHXpDTutPvxJ.actionElementMapToReplace.id;
				}
				return true;
			}

			private static void eCMXYSqwwWDMubZhhMqsWaokBIsI(LICVlyQEjkgpAiunwewkRttUTSEpA P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.fDOuIBgGgybcYrexSUEKmsyMCohd == null)
				{
					return;
				}
				if (!iwtluIWSMnSxtapZcXZNCADLujFm(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void FgcpBPxwPDGZUJlPCifDYPRPyQYd()
			{
				ReInput.UpdateEndedEvent -= vOWsvKfJVHZNYbEvJEoQumvZrULX;
				ReInput.UpdateEndedEvent += vOWsvKfJVHZNYbEvJEoQumvZrULX;
			}

			private void NnaTqwHFXyqfFkrikFQijeEYDZIqA()
			{
				ReInput.UpdateEndedEvent -= vOWsvKfJVHZNYbEvJEoQumvZrULX;
			}

			private bool vIOfaFgnjrELyPBOAnKajjXiBosb(MGtACJNVIlQSuUmWlUrtRXeaTawG P_0)
			{
				SafeDelegate safeDelegate = EikNZBHhFHKDmMOEmmxQWwLKIkGA[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void SOsHDaiwNlDShddsVxBBQFqgsabh<_0001>(MGtACJNVIlQSuUmWlUrtRXeaTawG P_0, _0001 P_1)
			{
				SafeAction<_0001> safeAction = (SafeAction<_0001>)EikNZBHhFHKDmMOEmmxQWwLKIkGA[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void LDfBMbavJTMhquUEdlnuKyGNHVtrA()
			{
				FHJdthkndqgGcysQqbZvGWyYYjiMA = ReInput.unscaledTime;
			}

			private void XxxVpYGbTPNoyuuqcVBZJJSdsjIy()
			{
				nURqIndxuoLyTzEXbLmNnGQigKuq = true;
			}

			private void ToPswxqlfVIntJkmRqMEQLtHZuyl(ActionElementMap P_0)
			{
				tLEXfreSpYDItqZFjgxLKLgBfXs(P_0);
				KfXfwlayqhibiwInBNrlZSBGpuMBA();
			}

			private void ATLaDdgkIhgVLEROlPQfFcyaUXZEA(string P_0)
			{
				KimHwPelaXkawoAXIkPRRHCQhqUl(P_0);
				KfXfwlayqhibiwInBNrlZSBGpuMBA();
			}

			private kIXdRqztWPKujvivFzGlXRLTFSPn VZEFmVoviqbdEXFsufSSebJYPnRt(ElementAssignment P_0)
			{
				if (vIOfaFgnjrELyPBOAnKajjXiBosb(MGtACJNVIlQSuUmWlUrtRXeaTawG.ConflictsFound))
				{
					bool flag = BQfMhEVXEKdPfSZMFAJrfqMkRwWA(dqKeDPFLEgXqXrupqRhUPyMjsHwWA, P_0, pGzbOnJtWwecNhLNghMQaYRQajDlc);
					sgaypZIxOmQiDedKOGDhdiBHZmWNA = P_0;
					IList<ElementAssignmentConflictInfo> list = dYXJKJLfFlqYihiUEJcPqQvpKNSI(dqKeDPFLEgXqXrupqRhUPyMjsHwWA, P_0, pGzbOnJtWwecNhLNghMQaYRQajDlc);
					aDCdscsPfNigJgEghAkBznNnAXpgb = OWnKnWwTdMfnKSSAcEXsiAqubIZeA.ConflictChecking;
					CeZApYlvObjMtzRyebWxNHaciofU();
					pTUpJcHaYGCJwcUYjXxcoZcMSlAPA(new ElementAssignmentInfo(dqKeDPFLEgXqXrupqRhUPyMjsHwWA.JdANzzNwanduuHVEQHXpDTutPvxJ.controllerMap, P_0), list, flag);
					return kIXdRqztWPKujvivFzGlXRLTFSPn.Quit;
				}
				return ilJecbQMjBsQAHOfyTuWeBmSyUML(IufqWGFBpatzyEWouMPuQDheroyD.defaultActionWhenConflictFound, P_0);
			}

			private kIXdRqztWPKujvivFzGlXRLTFSPn ilJecbQMjBsQAHOfyTuWeBmSyUML(ConflictResponse P_0, ElementAssignment P_1)
			{
				return WogXrGGmCVrtUlQsgjFQzNIVaZTEA(P_0, P_1, BQfMhEVXEKdPfSZMFAJrfqMkRwWA(dqKeDPFLEgXqXrupqRhUPyMjsHwWA, P_1, pGzbOnJtWwecNhLNghMQaYRQajDlc));
			}

			private kIXdRqztWPKujvivFzGlXRLTFSPn WogXrGGmCVrtUlQsgjFQzNIVaZTEA(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					ATLaDdgkIhgVLEROlPQfFcyaUXZEA("Mapping assignment was canceled due to a conflict.");
					return kIXdRqztWPKujvivFzGlXRLTFSPn.Quit;
				case ConflictResponse.Replace:
					if (P_2)
					{
						ATLaDdgkIhgVLEROlPQfFcyaUXZEA("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return kIXdRqztWPKujvivFzGlXRLTFSPn.Quit;
					}
					eCMXYSqwwWDMubZhhMqsWaokBIsI(dqKeDPFLEgXqXrupqRhUPyMjsHwWA, P_1, pGzbOnJtWwecNhLNghMQaYRQajDlc);
					return kIXdRqztWPKujvivFzGlXRLTFSPn.Continue;
				case ConflictResponse.Add:
					return kIXdRqztWPKujvivFzGlXRLTFSPn.Continue;
				case ConflictResponse.Ignore:
					PesHcffPajBedxeJWWfLgRdSiKmiA();
					return kIXdRqztWPKujvivFzGlXRLTFSPn.Quit;
				default:
					throw new NotImplementedException();
				}
			}

			private void bfUZeyPorTntMTgLdIWsmIydkSTT()
			{
				epeWHsIJWKskepdtDbnDhnLDqXkS();
				KfXfwlayqhibiwInBNrlZSBGpuMBA();
			}

			private void oPMqKdWNmkNXLIMhnOdMtCTsxAkC(string P_0)
			{
				pABBtmgKuSPrSRfBLmxXIylIkyfq(P_0);
				KfXfwlayqhibiwInBNrlZSBGpuMBA();
			}

			private void CeZApYlvObjMtzRyebWxNHaciofU()
			{
				XxxVpYGbTPNoyuuqcVBZJJSdsjIy();
				NnaTqwHFXyqfFkrikFQijeEYDZIqA();
				vmMHWiqEOwMcdnEwtqmACFlNwYsi = Status.AwaitingResponse;
			}

			private void PesHcffPajBedxeJWWfLgRdSiKmiA()
			{
				vmMHWiqEOwMcdnEwtqmACFlNwYsi = Status.Listening;
				aDCdscsPfNigJgEghAkBznNnAXpgb = OWnKnWwTdMfnKSSAcEXsiAqubIZeA.None;
				LDfBMbavJTMhquUEdlnuKyGNHVtrA();
				FgcpBPxwPDGZUJlPCifDYPRPyQYd();
			}

			private void kKBcEWbgYfVGwalitNwvOhExogSvA(ElementAssignment P_0)
			{
				if (dqKeDPFLEgXqXrupqRhUPyMjsHwWA.JdANzzNwanduuHVEQHXpDTutPvxJ.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					ToPswxqlfVIntJkmRqMEQLtHZuyl(result);
				}
				else
				{
					oPMqKdWNmkNXLIMhnOdMtCTsxAkC("Failed to create element assignment.");
				}
			}

			private void tLEXfreSpYDItqZFjgxLKLgBfXs(ActionElementMap P_0)
			{
				if (vIOfaFgnjrELyPBOAnKajjXiBosb(MGtACJNVIlQSuUmWlUrtRXeaTawG.InputMapped))
				{
					SOsHDaiwNlDShddsVxBBQFqgsabh(MGtACJNVIlQSuUmWlUrtRXeaTawG.InputMapped, new InputMappedEventData(NJsiaFtHkmVeiWqnazqldYTbPdsK, P_0));
				}
			}

			private void epeWHsIJWKskepdtDbnDhnLDqXkS()
			{
				if (vIOfaFgnjrELyPBOAnKajjXiBosb(MGtACJNVIlQSuUmWlUrtRXeaTawG.TimedOut))
				{
					SOsHDaiwNlDShddsVxBBQFqgsabh(MGtACJNVIlQSuUmWlUrtRXeaTawG.TimedOut, new TimedOutEventData(NJsiaFtHkmVeiWqnazqldYTbPdsK));
				}
			}

			private void pABBtmgKuSPrSRfBLmxXIylIkyfq(string P_0)
			{
				if (vIOfaFgnjrELyPBOAnKajjXiBosb(MGtACJNVIlQSuUmWlUrtRXeaTawG.Error))
				{
					SOsHDaiwNlDShddsVxBBQFqgsabh(MGtACJNVIlQSuUmWlUrtRXeaTawG.Error, new ErrorEventData(NJsiaFtHkmVeiWqnazqldYTbPdsK, P_0));
				}
			}

			private void KimHwPelaXkawoAXIkPRRHCQhqUl(string P_0)
			{
				if (vIOfaFgnjrELyPBOAnKajjXiBosb(MGtACJNVIlQSuUmWlUrtRXeaTawG.Canceled))
				{
					SOsHDaiwNlDShddsVxBBQFqgsabh(MGtACJNVIlQSuUmWlUrtRXeaTawG.Canceled, new CanceledEventData(NJsiaFtHkmVeiWqnazqldYTbPdsK, P_0));
				}
			}

			private void pTUpJcHaYGCJwcUYjXxcoZcMSlAPA(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				if (vIOfaFgnjrELyPBOAnKajjXiBosb(MGtACJNVIlQSuUmWlUrtRXeaTawG.ConflictsFound))
				{
					SOsHDaiwNlDShddsVxBBQFqgsabh(MGtACJNVIlQSuUmWlUrtRXeaTawG.ConflictsFound, new ConflictFoundEventData(NJsiaFtHkmVeiWqnazqldYTbPdsK, IpwbeXyuGBBbyqStuxNDtYWvFsdU, P_0, P_1, P_2));
				}
			}

			private void ElHsBKkTMSlGiCQFtwLsJKLrBeqGA()
			{
				if (vIOfaFgnjrELyPBOAnKajjXiBosb(MGtACJNVIlQSuUmWlUrtRXeaTawG.Started))
				{
					SOsHDaiwNlDShddsVxBBQFqgsabh(MGtACJNVIlQSuUmWlUrtRXeaTawG.Started, new StartedEventData(NJsiaFtHkmVeiWqnazqldYTbPdsK));
				}
			}

			private void iJmvHaEpsdeAdghIvwljdtoyJXVBb()
			{
				if (vIOfaFgnjrELyPBOAnKajjXiBosb(MGtACJNVIlQSuUmWlUrtRXeaTawG.Stopped))
				{
					SOsHDaiwNlDShddsVxBBQFqgsabh(MGtACJNVIlQSuUmWlUrtRXeaTawG.Stopped, new StoppedEventData(NJsiaFtHkmVeiWqnazqldYTbPdsK));
				}
			}

			public void IpwbeXyuGBBbyqStuxNDtYWvFsdU(ConflictResponse P_0)
			{
				if (vmMHWiqEOwMcdnEwtqmACFlNwYsi != Status.AwaitingResponse || aDCdscsPfNigJgEghAkBznNnAXpgb != OWnKnWwTdMfnKSSAcEXsiAqubIZeA.ConflictChecking)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (ilJecbQMjBsQAHOfyTuWeBmSyUML(P_0, sgaypZIxOmQiDedKOGDhdiBHZmWNA) == kIXdRqztWPKujvivFzGlXRLTFSPn.Continue)
					{
						kKBcEWbgYfVGwalitNwvOhExogSvA(sgaypZIxOmQiDedKOGDhdiBHZmWNA);
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
			private sealed class vQhccQIrlmzOcBxWswtfzJotydfo
			{
				public static readonly vQhccQIrlmzOcBxWswtfzJotydfo _003C_003E9 = new vQhccQIrlmzOcBxWswtfzJotydfo();

				public static Action<Exception> _003C_003E9__64_0;

				internal void tsQkuzDgBLHOXPhBerBVmskytTaF(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
				}
			}

			private bool xJxlSUALcEvwehsxPkCvCVFOiAwE = true;

			private bool gUyzOPVquhsiOoHgAPrGKTayEsjj = true;

			private bool AIJgaPEATUDyDZhYkHjHSsnMmnheb = true;

			private float jBGiSZADEugEWfZVRfgNgakvXqJAA;

			private bool HwLrdNXhExZWZyvnziQuPcMXJCRB = true;

			private bool DpaLQFhLIeMwKQFVpzgYdzAuMbaL = true;

			private bool YwjCvdMIVYPYFyEGpVXsXgYzfrEN = true;

			private bool yvuaSoCyWFMwKKoNlZjcfkdCOgGoA = true;

			private int[] JtplgqFWOBAdesVSEIbUdTIYQvVK;

			private ConflictResponse bzNDWWoBHlNMcwQCmvdQdmKpaCIbA = ConflictResponse.Replace;

			private bool bOewfuRnCNkRAfJnWskriajAkocx;

			private bool dzoafhcJUTgTQonprkRGzLnNZRVFA;

			private bool OeLwDJHOXpdcDBiUHDUoxicClJjw = true;

			private bool RdIDtwRrqDvEroWRvoBQVwXWsvmX = true;

			private float VnfvWrZzoxJHQNbRMvdcnRJKwqNu = 1f;

			internal const string OoSzWDxdmjzXJXUGBWllXSPanpUH = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> OdKIzGhTSbnOOACNelVjjHshoKn = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			public bool allowAxes
			{
				get
				{
					return xJxlSUALcEvwehsxPkCvCVFOiAwE;
				}
				set
				{
					xJxlSUALcEvwehsxPkCvCVFOiAwE = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return gUyzOPVquhsiOoHgAPrGKTayEsjj;
				}
				set
				{
					gUyzOPVquhsiOoHgAPrGKTayEsjj = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return AIJgaPEATUDyDZhYkHjHSsnMmnheb;
				}
				set
				{
					AIJgaPEATUDyDZhYkHjHSsnMmnheb = value;
				}
			}

			public float timeout
			{
				get
				{
					return jBGiSZADEugEWfZVRfgNgakvXqJAA;
				}
				set
				{
					jBGiSZADEugEWfZVRfgNgakvXqJAA = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return HwLrdNXhExZWZyvnziQuPcMXJCRB;
				}
				set
				{
					HwLrdNXhExZWZyvnziQuPcMXJCRB = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return DpaLQFhLIeMwKQFVpzgYdzAuMbaL;
				}
				set
				{
					DpaLQFhLIeMwKQFVpzgYdzAuMbaL = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return YwjCvdMIVYPYFyEGpVXsXgYzfrEN;
				}
				set
				{
					YwjCvdMIVYPYFyEGpVXsXgYzfrEN = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return yvuaSoCyWFMwKKoNlZjcfkdCOgGoA;
				}
				set
				{
					yvuaSoCyWFMwKKoNlZjcfkdCOgGoA = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return JtplgqFWOBAdesVSEIbUdTIYQvVK;
				}
				set
				{
					JtplgqFWOBAdesVSEIbUdTIYQvVK = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return bzNDWWoBHlNMcwQCmvdQdmKpaCIbA;
				}
				set
				{
					bzNDWWoBHlNMcwQCmvdQdmKpaCIbA = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return bOewfuRnCNkRAfJnWskriajAkocx;
				}
				set
				{
					bOewfuRnCNkRAfJnWskriajAkocx = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return dzoafhcJUTgTQonprkRGzLnNZRVFA;
				}
				set
				{
					dzoafhcJUTgTQonprkRGzLnNZRVFA = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return OeLwDJHOXpdcDBiUHDUoxicClJjw;
				}
				set
				{
					OeLwDJHOXpdcDBiUHDUoxicClJjw = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return RdIDtwRrqDvEroWRvoBQVwXWsvmX;
				}
				set
				{
					RdIDtwRrqDvEroWRvoBQVwXWsvmX = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return VnfvWrZzoxJHQNbRMvdcnRJKwqNu;
				}
				set
				{
					VnfvWrZzoxJHQNbRMvdcnRJKwqNu = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)OdKIzGhTSbnOOACNelVjjHshoKn["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = vQhccQIrlmzOcBxWswtfzJotydfo._003C_003E9.tsQkuzDgBLHOXPhBerBVmskytTaF;
					}
					OdKIzGhTSbnOOACNelVjjHshoKn["isElementAllowed"] = safePredicate;
				}
			}

			internal _0001 zRuzfabttzRtRjhcvSHfwifAnhwg<_0001>(string P_0) where _0001 : SafeDelegate
			{
				if (!OdKIzGhTSbnOOACNelVjjHshoKn.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as _0001;
			}

			public Options()
			{
				wzhxusTiYodGnFSYuXgSgClPNgjJ();
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
				stringBuilder.Append("allowAxes = " + xJxlSUALcEvwehsxPkCvCVFOiAwE + "\n");
				stringBuilder.Append("allowButtons = " + gUyzOPVquhsiOoHgAPrGKTayEsjj + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + AIJgaPEATUDyDZhYkHjHSsnMmnheb + "\n");
				stringBuilder.Append("timeout = " + jBGiSZADEugEWfZVRfgNgakvXqJAA + "\n");
				stringBuilder.Append("checkForConflicts = " + HwLrdNXhExZWZyvnziQuPcMXJCRB + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + DpaLQFhLIeMwKQFVpzgYdzAuMbaL + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + YwjCvdMIVYPYFyEGpVXsXgYzfrEN + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + yvuaSoCyWFMwKKoNlZjcfkdCOgGoA + "\n");
				if (JtplgqFWOBAdesVSEIbUdTIYQvVK == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(JtplgqFWOBAdesVSEIbUdTIYQvVK) + "\n");
				}
				stringBuilder.Append("defaultActionWhenConflictFound = " + bzNDWWoBHlNMcwQCmvdQdmKpaCIbA.ToString() + "\n");
				stringBuilder.Append("ignoreMouseXAxis = " + bOewfuRnCNkRAfJnWskriajAkocx);
				stringBuilder.Append("ignoreMouseYAxis = " + dzoafhcJUTgTQonprkRGzLnNZRVFA);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + OeLwDJHOXpdcDBiUHDUoxicClJjw + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + RdIDtwRrqDvEroWRvoBQVwXWsvmX + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + VnfvWrZzoxJHQNbRMvdcnRJKwqNu + "\n");
				return stringBuilder.ToString();
			}

			internal void wzhxusTiYodGnFSYuXgSgClPNgjJ()
			{
				xJxlSUALcEvwehsxPkCvCVFOiAwE = true;
				gUyzOPVquhsiOoHgAPrGKTayEsjj = true;
				AIJgaPEATUDyDZhYkHjHSsnMmnheb = true;
				jBGiSZADEugEWfZVRfgNgakvXqJAA = 0f;
				HwLrdNXhExZWZyvnziQuPcMXJCRB = true;
				DpaLQFhLIeMwKQFVpzgYdzAuMbaL = true;
				YwjCvdMIVYPYFyEGpVXsXgYzfrEN = true;
				yvuaSoCyWFMwKKoNlZjcfkdCOgGoA = true;
				JtplgqFWOBAdesVSEIbUdTIYQvVK = null;
				bzNDWWoBHlNMcwQCmvdQdmKpaCIbA = ConflictResponse.Replace;
				bOewfuRnCNkRAfJnWskriajAkocx = false;
				dzoafhcJUTgTQonprkRGzLnNZRVFA = false;
				OeLwDJHOXpdcDBiUHDUoxicClJjw = true;
				RdIDtwRrqDvEroWRvoBQVwXWsvmX = true;
				VnfvWrZzoxJHQNbRMvdcnRJKwqNu = 1f;
				foreach (string item in new List<string>(OdKIzGhTSbnOOACNelVjjHshoKn.Keys))
				{
					OdKIzGhTSbnOOACNelVjjHshoKn[item] = null;
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
				destination.xJxlSUALcEvwehsxPkCvCVFOiAwE = source.xJxlSUALcEvwehsxPkCvCVFOiAwE;
				destination.gUyzOPVquhsiOoHgAPrGKTayEsjj = source.gUyzOPVquhsiOoHgAPrGKTayEsjj;
				destination.AIJgaPEATUDyDZhYkHjHSsnMmnheb = source.AIJgaPEATUDyDZhYkHjHSsnMmnheb;
				destination.jBGiSZADEugEWfZVRfgNgakvXqJAA = source.jBGiSZADEugEWfZVRfgNgakvXqJAA;
				destination.HwLrdNXhExZWZyvnziQuPcMXJCRB = source.HwLrdNXhExZWZyvnziQuPcMXJCRB;
				destination.DpaLQFhLIeMwKQFVpzgYdzAuMbaL = source.DpaLQFhLIeMwKQFVpzgYdzAuMbaL;
				destination.YwjCvdMIVYPYFyEGpVXsXgYzfrEN = source.YwjCvdMIVYPYFyEGpVXsXgYzfrEN;
				destination.yvuaSoCyWFMwKKoNlZjcfkdCOgGoA = source.yvuaSoCyWFMwKKoNlZjcfkdCOgGoA;
				destination.JtplgqFWOBAdesVSEIbUdTIYQvVK = ArrayTools.ShallowCopy(source.JtplgqFWOBAdesVSEIbUdTIYQvVK);
				destination.bzNDWWoBHlNMcwQCmvdQdmKpaCIbA = source.bzNDWWoBHlNMcwQCmvdQdmKpaCIbA;
				destination.bOewfuRnCNkRAfJnWskriajAkocx = source.bOewfuRnCNkRAfJnWskriajAkocx;
				destination.dzoafhcJUTgTQonprkRGzLnNZRVFA = source.dzoafhcJUTgTQonprkRGzLnNZRVFA;
				destination.OeLwDJHOXpdcDBiUHDUoxicClJjw = source.OeLwDJHOXpdcDBiUHDUoxicClJjw;
				destination.RdIDtwRrqDvEroWRvoBQVwXWsvmX = source.RdIDtwRrqDvEroWRvoBQVwXWsvmX;
				destination.VnfvWrZzoxJHQNbRMvdcnRJKwqNu = source.VnfvWrZzoxJHQNbRMvdcnRJKwqNu;
				foreach (KeyValuePair<string, SafeDelegate> item in source.OdKIzGhTSbnOOACNelVjjHshoKn)
				{
					destination.OdKIzGhTSbnOOACNelVjjHshoKn[item.Key] = MiscTools.Clone(item.Value);
				}
			}
		}

		[Serializable]
		private sealed class lsXBNXAcvWzpGsbZLbfEWUdnfrweA
		{
			public static readonly lsXBNXAcvWzpGsbZLbfEWUdnfrweA _003C_003E9 = new lsXBNXAcvWzpGsbZLbfEWUdnfrweA();

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void XBDIXZhmejerwGBljWEopFrMWWXaB(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
			}

			internal void eUFHwByVPVXuLdEVKPcdzaesDaWp(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
			}

			internal void SHKavuKiDdvrUqkdivuyMtAxAAZI(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
			}

			internal void vdAHJUeeGQmpalgdZusCpQNOYZGiA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
			}

			internal void DlvQAIdNGTlzndbVSJDhEjagWlJn(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
			}

			internal void ACoRggmPBxkIZEkpQwdMpZfJcaRf(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
			}

			internal void tnewwrAnlCeXFyVAJFLqRjTnyazi(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
			}
		}

		private static InputMapper wAXhlrNJwSCXIfWYfdHPjfsFtDEHb;

		private static int MiDIsJUDePjkeYGTatiTbNHJGCTu;

		private readonly int zrUjDxyEswiCLXlfFRHBSBkvOBnD;

		private readonly bool pRsIzOoRSWUjDJXrazOhaakYkTdU;

		private readonly dppjtCFjgjaMfHGtqCNPcOkvHtJz VDypKrpCvwbQQfLeKonXWMlTRUTTA;

		private Options ZFRCvqKMmyZjfDLCdgSyvqRWIvMx;

		private readonly Dictionary<MGtACJNVIlQSuUmWlUrtRXeaTawG, SafeDelegate> sfpezpVggXgJvhYefkacaHBShuOE = new Dictionary<MGtACJNVIlQSuUmWlUrtRXeaTawG, SafeDelegate>
		{
			{
				MGtACJNVIlQSuUmWlUrtRXeaTawG.InputMapped,
				new SafeAction<InputMappedEventData>(lsXBNXAcvWzpGsbZLbfEWUdnfrweA._003C_003E9.XBDIXZhmejerwGBljWEopFrMWWXaB)
			},
			{
				MGtACJNVIlQSuUmWlUrtRXeaTawG.Error,
				new SafeAction<ErrorEventData>(lsXBNXAcvWzpGsbZLbfEWUdnfrweA._003C_003E9.eUFHwByVPVXuLdEVKPcdzaesDaWp)
			},
			{
				MGtACJNVIlQSuUmWlUrtRXeaTawG.Canceled,
				new SafeAction<CanceledEventData>(lsXBNXAcvWzpGsbZLbfEWUdnfrweA._003C_003E9.SHKavuKiDdvrUqkdivuyMtAxAAZI)
			},
			{
				MGtACJNVIlQSuUmWlUrtRXeaTawG.TimedOut,
				new SafeAction<TimedOutEventData>(lsXBNXAcvWzpGsbZLbfEWUdnfrweA._003C_003E9.vdAHJUeeGQmpalgdZusCpQNOYZGiA)
			},
			{
				MGtACJNVIlQSuUmWlUrtRXeaTawG.Started,
				new SafeAction<StartedEventData>(lsXBNXAcvWzpGsbZLbfEWUdnfrweA._003C_003E9.DlvQAIdNGTlzndbVSJDhEjagWlJn)
			},
			{
				MGtACJNVIlQSuUmWlUrtRXeaTawG.Stopped,
				new SafeAction<StoppedEventData>(lsXBNXAcvWzpGsbZLbfEWUdnfrweA._003C_003E9.ACoRggmPBxkIZEkpQwdMpZfJcaRf)
			},
			{
				MGtACJNVIlQSuUmWlUrtRXeaTawG.ConflictsFound,
				new SafeAction<ConflictFoundEventData>(lsXBNXAcvWzpGsbZLbfEWUdnfrweA._003C_003E9.tnewwrAnlCeXFyVAJFLqRjTnyazi)
			}
		};

		public static InputMapper Default => wAXhlrNJwSCXIfWYfdHPjfsFtDEHb ?? (wAXhlrNJwSCXIfWYfdHPjfsFtDEHb = new InputMapper(true));

		public Options options
		{
			get
			{
				Options obj = ZFRCvqKMmyZjfDLCdgSyvqRWIvMx;
				if (obj == null)
				{
					if (!pRsIzOoRSWUjDJXrazOhaakYkTdU)
					{
						return ZFRCvqKMmyZjfDLCdgSyvqRWIvMx = Default.options.Clone();
					}
					obj = (ZFRCvqKMmyZjfDLCdgSyvqRWIvMx = new Options());
				}
				return obj;
			}
			set
			{
				ZFRCvqKMmyZjfDLCdgSyvqRWIvMx = value;
			}
		}

		public Context mappingContext => VDypKrpCvwbQQfLeKonXWMlTRUTTA.slPMYZQGeBSPWjEpuTevqUjMANsj;

		public Status status => VDypKrpCvwbQQfLeKonXWMlTRUTTA.OLJSuCkDAyLhOcLTJzJrRLfYvJct;

		public float timeRemaining => VDypKrpCvwbQQfLeKonXWMlTRUTTA.NfVQFmTVMnjCiAYQPMBNplQWPYGq;

		internal int CxqKTIDBcrfXaVCMcYxjzSorDaJF => zrUjDxyEswiCLXlfFRHBSBkvOBnD;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.InputMapped;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<InputMappedEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.InputMapped;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<InputMappedEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.Error;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<ErrorEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.Error;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<ErrorEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.Canceled;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<CanceledEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.Canceled;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<CanceledEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.TimedOut;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<TimedOutEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.TimedOut;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<TimedOutEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.Started;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<StartedEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.Started;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<StartedEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.Stopped;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<StoppedEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.Stopped;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<StoppedEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.ConflictsFound;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<ConflictFoundEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					MGtACJNVIlQSuUmWlUrtRXeaTawG key = MGtACJNVIlQSuUmWlUrtRXeaTawG.ConflictsFound;
					sfpezpVggXgJvhYefkacaHBShuOE[key] = (SafeAction<ConflictFoundEventData>)sfpezpVggXgJvhYefkacaHBShuOE[key] - value;
				}
			}
		}

		private static int vdTpEmaUhvWSuiAGuqLLFVdSVgfo()
		{
			int miDIsJUDePjkeYGTatiTbNHJGCTu = MiDIsJUDePjkeYGTatiTbNHJGCTu;
			if (MiDIsJUDePjkeYGTatiTbNHJGCTu == int.MaxValue)
			{
				MiDIsJUDePjkeYGTatiTbNHJGCTu = 0;
				return miDIsJUDePjkeYGTatiTbNHJGCTu;
			}
			MiDIsJUDePjkeYGTatiTbNHJGCTu++;
			return miDIsJUDePjkeYGTatiTbNHJGCTu;
		}

		public InputMapper()
			: this(false)
		{
			zrUjDxyEswiCLXlfFRHBSBkvOBnD = vdTpEmaUhvWSuiAGuqLLFVdSVgfo();
		}

		private InputMapper(bool P_0)
		{
			pRsIzOoRSWUjDJXrazOhaakYkTdU = P_0;
			if (pRsIzOoRSWUjDJXrazOhaakYkTdU)
			{
				ZFRCvqKMmyZjfDLCdgSyvqRWIvMx = new Options();
			}
			VDypKrpCvwbQQfLeKonXWMlTRUTTA = new dppjtCFjgjaMfHGtqCNPcOkvHtJz(this, sfpezpVggXgJvhYefkacaHBShuOE);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<MGtACJNVIlQSuUmWlUrtRXeaTawG, SafeDelegate> item in sfpezpVggXgJvhYefkacaHBShuOE)
			{
				item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<MGtACJNVIlQSuUmWlUrtRXeaTawG, SafeDelegate> item in sfpezpVggXgJvhYefkacaHBShuOE)
			{
				item.Value.Clear();
			}
		}

		internal void aqzFqFgGwjHcoksyxmecWvMJSRiB(object P_0)
		{
		}

		internal void nIIItZgqMrQEDCrOvdpaceZEDvCGb()
		{
		}

		public bool Start(Context mappingContext)
		{
			return POaPoLbDzWIEtyzSixZtRnqwpHOD(mappingContext, (ZFRCvqKMmyZjfDLCdgSyvqRWIvMx != null) ? ZFRCvqKMmyZjfDLCdgSyvqRWIvMx : Default.options);
		}

		public void Stop()
		{
			VDypKrpCvwbQQfLeKonXWMlTRUTTA.TBOcnnHRoApyhohsipDpPykVCXUAA("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			nIIItZgqMrQEDCrOvdpaceZEDvCGb();
			ZFRCvqKMmyZjfDLCdgSyvqRWIvMx = null;
		}

		private bool POaPoLbDzWIEtyzSixZtRnqwpHOD(Context P_0, Options P_1)
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
				VDypKrpCvwbQQfLeKonXWMlTRUTTA.iMIGXsUhjrQwAfEuqDAgHeYCiamhA(P_0, P_1);
				return true;
			}
			catch
			{
				VDypKrpCvwbQQfLeKonXWMlTRUTTA.TBOcnnHRoApyhohsipDpPykVCXUAA("Failed to start due to an exception.");
				return false;
			}
		}
	}
}
