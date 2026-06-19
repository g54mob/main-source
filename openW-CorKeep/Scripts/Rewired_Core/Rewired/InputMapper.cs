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
			private int gfTrVFvaDddrIDYgsjhdfATaCCTfb = -1;

			private ControllerMap ZbaVXBFmmVGbpALRxDJZTqXdEzcDA;

			private ActionElementMap VezLKGrgsQRbQYJoDgaAcWdnFUjlA;

			private AxisRange VWsipLfwTLwiLPSwpIfLQCsHYeRh = AxisRange.Positive;

			private bool WGLHIIOAASbPJfKRGmzrGPHDGWfhc;

			public int actionId
			{
				get
				{
					return gfTrVFvaDddrIDYgsjhdfATaCCTfb;
				}
				set
				{
					if (!WJDSaDpJjSZtcaPdnuWmugqVMZpB())
					{
						gfTrVFvaDddrIDYgsjhdfATaCCTfb = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(gfTrVFvaDddrIDYgsjhdfATaCCTfb);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!WJDSaDpJjSZtcaPdnuWmugqVMZpB())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							gfTrVFvaDddrIDYgsjhdfATaCCTfb = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							gfTrVFvaDddrIDYgsjhdfATaCCTfb = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return ZbaVXBFmmVGbpALRxDJZTqXdEzcDA;
				}
				set
				{
					if (!WJDSaDpJjSZtcaPdnuWmugqVMZpB())
					{
						ZbaVXBFmmVGbpALRxDJZTqXdEzcDA = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return VezLKGrgsQRbQYJoDgaAcWdnFUjlA;
				}
				set
				{
					if (!WJDSaDpJjSZtcaPdnuWmugqVMZpB())
					{
						VezLKGrgsQRbQYJoDgaAcWdnFUjlA = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return VWsipLfwTLwiLPSwpIfLQCsHYeRh;
				}
				set
				{
					if (!WJDSaDpJjSZtcaPdnuWmugqVMZpB())
					{
						VWsipLfwTLwiLPSwpIfLQCsHYeRh = value;
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

			internal void mSVfzOuIxkEaWHshGxpVhGdbCBgW()
			{
				WGLHIIOAASbPJfKRGmzrGPHDGWfhc = true;
			}

			private bool WJDSaDpJjSZtcaPdnuWmugqVMZpB()
			{
				if (WGLHIIOAASbPJfKRGmzrGPHDGWfhc)
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
				destination.gfTrVFvaDddrIDYgsjhdfATaCCTfb = source.gfTrVFvaDddrIDYgsjhdfATaCCTfb;
				destination.ZbaVXBFmmVGbpALRxDJZTqXdEzcDA = source.ZbaVXBFmmVGbpALRxDJZTqXdEzcDA;
				destination.VezLKGrgsQRbQYJoDgaAcWdnFUjlA = source.VezLKGrgsQRbQYJoDgaAcWdnFUjlA;
				destination.VWsipLfwTLwiLPSwpIfLQCsHYeRh = source.VWsipLfwTLwiLPSwpIfLQCsHYeRh;
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

			private readonly Func<int, bool> IYUFWUlgFHbuFwpimjiDwhsAnFKX;

			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				if (IYUFWUlgFHbuFwpimjiDwhsAnFKX == null)
				{
					return false;
				}
				return IYUFWUlgFHbuFwpimjiDwhsAnFKX(maxInputFieldCount);
			}

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
				: base(P_0)
			{
				responseCallback = P_1;
				assignment = P_2;
				conflicts = P_3;
				isProtected = P_4;
				IYUFWUlgFHbuFwpimjiDwhsAnFKX = P_5;
			}
		}

		private enum SFjgWozprAIRiZZQlnBdHOGIaujCA
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

		private class tTnMlrhwMWbbvWdVieULFcxPOCSz
		{
			private enum aIXdVRdTueaxnVeDLsRfcHIdnrSFB
			{
				Quit = 0,
				Continue = 1
			}

			private enum KphdnMVRpmuQJRiqOTowrbIpEEH
			{
				None = 0,
				ConflictChecking = 1
			}

			private class NPCvIPqtDFckInDFcfLsjKkyxbPj
			{
				private Player NmaPnVFFNvPMtUlFCfhxldpqsahP;

				private int igkjMynJSjijSCOKzgboMxIoVBsw;

				private Context HHhFNXGwVrfpFDNMmRHyFsipGXSbA;

				private ControllerType rxGqjHNIRQcrfigAnNenENJomtBqA;

				private int jziVUSTpOXToPSZKeTRRjwOZupZM;

				private ControllerPollingInfo LYWpVXtzRvSCsUDPNnFEWqleVeiA;

				private ModifierKeyFlags OvQfMEMOPDjZSGuiQlPLyOZbtzgJ;

				public Player zrYHivOjqJAuOuIAKPTYyJpcfvcBA => NmaPnVFFNvPMtUlFCfhxldpqsahP;

				public int MFpcArerEaAYxYNIpCXGAVFKiSuRA => igkjMynJSjijSCOKzgboMxIoVBsw;

				public Context PdAxqEhhOEdmoUOaQKPzVlbPckeI => HHhFNXGwVrfpFDNMmRHyFsipGXSbA;

				public ControllerType iXcVggNGaFagZtXSJHLQpUTXOafR => rxGqjHNIRQcrfigAnNenENJomtBqA;

				public int cJASvkyonCrrFSrPguuuNNGQIoBDA => jziVUSTpOXToPSZKeTRRjwOZupZM;

				public ControllerPollingInfo OvodMLfBDxgwTsQiCMOUhJbGaVCgb => LYWpVXtzRvSCsUDPNnFEWqleVeiA;

				public ModifierKeyFlags PmlpLpPvZGBWhfOnWMWcEuyNUuOT => OvQfMEMOPDjZSGuiQlPLyOZbtzgJ;

				public AxisRange NPJDvfsjusWjIIeuajDnXfdOHaRv
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (OvodMLfBDxgwTsQiCMOUhJbGaVCgb.elementType == ControllerElementType.Axis)
						{
							result = ((HHhFNXGwVrfpFDNMmRHyFsipGXSbA.actionRange != AxisRange.Full) ? ((OvodMLfBDxgwTsQiCMOUhJbGaVCgb.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
						}
						return result;
					}
				}

				public string AcIvwqMcZSjnajOiiYbdlMHtbgCo
				{
					get
					{
						if (iXcVggNGaFagZtXSJHLQpUTXOafR == ControllerType.Keyboard && PmlpLpPvZGBWhfOnWMWcEuyNUuOT != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(PmlpLpPvZGBWhfOnWMWcEuyNUuOT)} + {OvodMLfBDxgwTsQiCMOUhJbGaVCgb.elementIdentifierName}";
						}
						string text = OvodMLfBDxgwTsQiCMOUhJbGaVCgb.elementIdentifierName;
						if (OvodMLfBDxgwTsQiCMOUhJbGaVCgb.elementType == ControllerElementType.Axis)
						{
							if (NPJDvfsjusWjIIeuajDnXfdOHaRv == AxisRange.Positive)
							{
								text += " +";
							}
							else if (NPJDvfsjusWjIIeuajDnXfdOHaRv == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				public void pWIIMLMMFvgBbjOfmiOGDgMASNzNB(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					oOhQDdXhLMdzEwOCLFNDywKXuBxF();
					NmaPnVFFNvPMtUlFCfhxldpqsahP = P_0;
					igkjMynJSjijSCOKzgboMxIoVBsw = P_1.actionId;
					rxGqjHNIRQcrfigAnNenENJomtBqA = P_1.controllerMap.controllerType;
					jziVUSTpOXToPSZKeTRRjwOZupZM = P_1.controllerMap.controllerId;
					HHhFNXGwVrfpFDNMmRHyFsipGXSbA = P_1;
					rxGqjHNIRQcrfigAnNenENJomtBqA = P_1.controllerMap.controllerType;
					jziVUSTpOXToPSZKeTRRjwOZupZM = P_1.controllerMap.controllerId;
					P_1.mSVfzOuIxkEaWHshGxpVhGdbCBgW();
				}

				public void oOhQDdXhLMdzEwOCLFNDywKXuBxF()
				{
					NmaPnVFFNvPMtUlFCfhxldpqsahP = null;
					igkjMynJSjijSCOKzgboMxIoVBsw = -1;
					HHhFNXGwVrfpFDNMmRHyFsipGXSbA = null;
					rxGqjHNIRQcrfigAnNenENJomtBqA = ControllerType.Keyboard;
					jziVUSTpOXToPSZKeTRRjwOZupZM = -1;
					LYWpVXtzRvSCsUDPNnFEWqleVeiA = default(ControllerPollingInfo);
					OvQfMEMOPDjZSGuiQlPLyOZbtzgJ = ModifierKeyFlags.None;
				}

				public ElementAssignment pEuqqgpknFCOxcxgmGFofqcPSrfH(ControllerPollingInfo P_0)
				{
					LYWpVXtzRvSCsUDPNnFEWqleVeiA = P_0;
					return iCpuKgTIxzWaayKIhoUlrLhEEPpe();
				}

				public ElementAssignment RPtEiSfKqcVvZbsBCCyFuEXZshtDA(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					LYWpVXtzRvSCsUDPNnFEWqleVeiA = P_0;
					OvQfMEMOPDjZSGuiQlPLyOZbtzgJ = P_1;
					return iCpuKgTIxzWaayKIhoUlrLhEEPpe();
				}

				public ElementAssignment iCpuKgTIxzWaayKIhoUlrLhEEPpe()
				{
					return new ElementAssignment(iXcVggNGaFagZtXSJHLQpUTXOafR, LYWpVXtzRvSCsUDPNnFEWqleVeiA.elementType, LYWpVXtzRvSCsUDPNnFEWqleVeiA.elementIdentifierId, NPJDvfsjusWjIIeuajDnXfdOHaRv, LYWpVXtzRvSCsUDPNnFEWqleVeiA.keyboardKey, OvQfMEMOPDjZSGuiQlPLyOZbtzgJ, igkjMynJSjijSCOKzgboMxIoVBsw, (HHhFNXGwVrfpFDNMmRHyFsipGXSbA.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (HHhFNXGwVrfpFDNMmRHyFsipGXSbA.actionElementMapToReplace != null) ? HHhFNXGwVrfpFDNMmRHyFsipGXSbA.actionElementMapToReplace.id : (-1));
				}
			}

			private sealed class iPbEPLcxQDCqlnGfoFoJKrPKjCZg
			{
				public ActionElementMap ODkrzPWIzDsFJXldRfSahtIrWZZM;

				internal bool TjIuwksRcnUFtPdIXEBLzkvIQSPo(ElementAssignmentConflictInfo P_0)
				{
					return P_0.elementMapId == ODkrzPWIzDsFJXldRfSahtIrWZZM.id;
				}
			}

			private sealed class qDMRczegzAOPXGerRIqkOUfAwhKf
			{
				public tTnMlrhwMWbbvWdVieULFcxPOCSz amtGoCyROLHCLBlERyNDsQEkRDFl;

				public ElementAssignmentInfo gKtSlUShncaluEegbdhQhsRceOiXB;

				public IList<ElementAssignmentConflictInfo> PXKPHeEfvpZjDiNtXBEcdZiyiziV;

				public bool YuQKNMwHERByYpXbXehPfhowGcAkA;

				internal bool SvnnleKodTxsrbHmdhbHJyFmnbKIA(int P_0)
				{
					return amtGoCyROLHCLBlERyNDsQEkRDFl.BjsaLDIZZPxECeamjWKpOlKLMIBbb(gKtSlUShncaluEegbdhQhsRceOiXB, PXKPHeEfvpZjDiNtXBEcdZiyiziV, YuQKNMwHERByYpXbXehPfhowGcAkA, P_0);
				}
			}

			private readonly InputMapper BxgNuwJJOVVQoNqRaMmzrhSPRkzT;

			private readonly Options ITprcphhjVwsoRtikbLsYnUUSEbr = new Options();

			private readonly NPCvIPqtDFckInDFcfLsjKkyxbPj xVKaZqnugFxvHtHFmmqKejLJAsxhA = new NPCvIPqtDFckInDFcfLsjKkyxbPj();

			private readonly Dictionary<SFjgWozprAIRiZZQlnBdHOGIaujCA, SafeDelegate> KNwIPwxLZwyBBFjaChrljGfjJtheA;

			private readonly Dictionary<string, SafeDelegate> KXzRqBzkEVbgKiRaNJYdIAIEHKvZA;

			private Status zMGrXPKvuRDVbsGIjhnQBOuvoJnhb;

			private KphdnMVRpmuQJRiqOTowrbIpEEH sDYDqVbMDelbRaDOjjxDirEERsKcE;

			private double TGPDpMfOFBlHmalosbUfdKdKaOrwB;

			private bool vtBENOBSLDhxLazmhUvTfFsQnAdh;

			private List<Player> jVbdMKVZcNHhXALbpIHEIUYIaIKQ = new List<Player>();

			private readonly List<ControllerPollingInfo> dMgHwvCRtZQFXRdaIdarnHxXRpGD = new List<ControllerPollingInfo>();

			private ElementAssignment yzefwsmBqBduRvFyGICjsJAlVkFK;

			public Status IYBqYpWomNccKbYrROLfFAkeGslQ => zMGrXPKvuRDVbsGIjhnQBOuvoJnhb;

			public float DzJHnBduJETHwHAmNWLJjATkhjJr
			{
				get
				{
					if (zMGrXPKvuRDVbsGIjhnQBOuvoJnhb == Status.Idle)
					{
						return 0f;
					}
					if (ITprcphhjVwsoRtikbLsYnUUSEbr.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, TGPDpMfOFBlHmalosbUfdKdKaOrwB + (double)ITprcphhjVwsoRtikbLsYnUUSEbr.timeout - ReInput.unscaledTime);
				}
			}

			public Context qeXZOkmiIkuXMmdTgmCpaIkinffo
			{
				get
				{
					if (zMGrXPKvuRDVbsGIjhnQBOuvoJnhb == Status.Idle)
					{
						return null;
					}
					return xVKaZqnugFxvHtHFmmqKejLJAsxhA.PdAxqEhhOEdmoUOaQKPzVlbPckeI;
				}
			}

			private bool PUIwpQZuWtdxfIswuvxvIAFQWfec
			{
				get
				{
					if (vtBENOBSLDhxLazmhUvTfFsQnAdh)
					{
						return false;
					}
					return ITprcphhjVwsoRtikbLsYnUUSEbr.timeout > 0f;
				}
			}

			public tTnMlrhwMWbbvWdVieULFcxPOCSz(InputMapper P_0, Dictionary<SFjgWozprAIRiZZQlnBdHOGIaujCA, SafeDelegate> P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("events");
				}
				BxgNuwJJOVVQoNqRaMmzrhSPRkzT = P_0;
				KNwIPwxLZwyBBFjaChrljGfjJtheA = P_1;
				QrRPafhSJZCzwSomqsUfzhhMFmHm();
			}

			protected virtual void FTzfqyDEoOGywcyjayliWkcCgoSI()
			{
				try
				{
					HcomGVtwjLoTFlGIwDhaoQHkciJK();
				}
				finally
				{
					base.Finalize();
				}
			}

			public void cSYVPLkXIElQisGAsBiuiVIcLmrE(Context P_0, Options P_1)
			{
				if (zMGrXPKvuRDVbsGIjhnQBOuvoJnhb != Status.Idle)
				{
					CNLeHQfYwGvAHWImfPJvwodKZoSV("User started a new listening session.");
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
				Options.Copy(P_1, ITprcphhjVwsoRtikbLsYnUUSEbr);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					ciQgadaKbTBMZHxwzgTOblHMoYnU("No Action found for actionId: " + P_0.actionId);
					return;
				}
				xVKaZqnugFxvHtHFmmqKejLJAsxhA.pWIIMLMMFvgBbjOfmiOGDgMASNzNB(player, P_0);
				zMGrXPKvuRDVbsGIjhnQBOuvoJnhb = Status.Listening;
				BJbAEAPRbwuheBdctKmemqBtTowV();
				fehsHQRnkdVZHJrFBlZtuWCVaRrQ();
				BGygnsBgYwwFASQDMbfVKIErGNTbA();
				QLVVPjWcPpBDuRDrjWscRCAXRPnf();
			}

			public void NCOclEboGlrWhsxYeKDpgSzniUTI(string P_0)
			{
				if (zMGrXPKvuRDVbsGIjhnQBOuvoJnhb != Status.Idle)
				{
					CNLeHQfYwGvAHWImfPJvwodKZoSV(P_0);
				}
			}

			private void joIyytPThubKKgUPNbvUmiknGdAKA(UpdateLoopType P_0)
			{
				if (P_0 == UpdateLoopType.Update && zMGrXPKvuRDVbsGIjhnQBOuvoJnhb == Status.Listening)
				{
					ElementAssignment elementAssignment;
					if (PUIwpQZuWtdxfIswuvxvIAFQWfec && DzJHnBduJETHwHAmNWLJjATkhjJr <= 0f)
					{
						jKMwZXnfZekuQKRvtPogqDpPxfSi();
					}
					else if (ReInput.controllers.GetController(xVKaZqnugFxvHtHFmmqKejLJAsxhA.iXcVggNGaFagZtXSJHLQpUTXOafR, xVKaZqnugFxvHtHFmmqKejLJAsxhA.cJASvkyonCrrFSrPguuuNNGQIoBDA) == null)
					{
						ciQgadaKbTBMZHxwzgTOblHMoYnU("Controller not found for type: " + xVKaZqnugFxvHtHFmmqKejLJAsxhA.iXcVggNGaFagZtXSJHLQpUTXOafR.ToString() + " id: " + xVKaZqnugFxvHtHFmmqKejLJAsxhA.cJASvkyonCrrFSrPguuuNNGQIoBDA);
					}
					else if (LHbRUlYLGrFFMgEeFHSeqzDyTEjt(out elementAssignment) != aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Quit && VCApsSGZOffXHLfoTxAEWOvGhmus(elementAssignment) != aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Quit)
					{
						qYRcGbUouCdFmKqYphfpYrPHFRBtA(elementAssignment);
					}
				}
			}

			private void UzBiiYEzOSsUmLTXTudzAlOoLkVf()
			{
				if (zMGrXPKvuRDVbsGIjhnQBOuvoJnhb != Status.Idle)
				{
					QrRPafhSJZCzwSomqsUfzhhMFmHm();
					HcomGVtwjLoTFlGIwDhaoQHkciJK();
					mrsRINaLSANpncBkdeJdjjrIsTMl();
				}
			}

			private void QrRPafhSJZCzwSomqsUfzhhMFmHm()
			{
				zMGrXPKvuRDVbsGIjhnQBOuvoJnhb = Status.Idle;
				TGPDpMfOFBlHmalosbUfdKdKaOrwB = 0.0;
				ITprcphhjVwsoRtikbLsYnUUSEbr.wLjmvHfwoNMgfUakqgSUGkshQgumA();
				xVKaZqnugFxvHtHFmmqKejLJAsxhA.oOhQDdXhLMdzEwOCLFNDywKXuBxF();
				yzefwsmBqBduRvFyGICjsJAlVkFK = default(ElementAssignment);
				sDYDqVbMDelbRaDOjjxDirEERsKcE = KphdnMVRpmuQJRiqOTowrbIpEEH.None;
				vtBENOBSLDhxLazmhUvTfFsQnAdh = false;
				jVbdMKVZcNHhXALbpIHEIUYIaIKQ.Clear();
			}

			private aIXdVRdTueaxnVeDLsRfcHIdnrSFB LHbRUlYLGrFFMgEeFHSeqzDyTEjt(out ElementAssignment P_0)
			{
				if (!EySCAoORFXmwDfQGspusiOZqjMuw(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Quit;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !ouhjjrMVJNWEDMTlLaaWYnJZQOuT(item, ITprcphhjVwsoRtikbLsYnUUSEbr))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Quit;
				}
				if (!ZZTBoqehcHAIcFIWGVNmDofLFjUJA(xVKaZqnugFxvHtHFmmqKejLJAsxhA, controllerPollingInfo, ITprcphhjVwsoRtikbLsYnUUSEbr))
				{
					P_0 = default(ElementAssignment);
					return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Quit;
				}
				P_0 = xVKaZqnugFxvHtHFmmqKejLJAsxhA.pEuqqgpknFCOxcxgmGFofqcPSrfH(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Continue;
			}

			private bool EySCAoORFXmwDfQGspusiOZqjMuw(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = xVKaZqnugFxvHtHFmmqKejLJAsxhA.iXcVggNGaFagZtXSJHLQpUTXOafR;
				int controllerId = xVKaZqnugFxvHtHFmmqKejLJAsxhA.cJASvkyonCrrFSrPguuuNNGQIoBDA;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = wzwpQcnmHTiKAOBtsvQlPmWBYsSR(out P_1);
					return true;
				}
				if (ITprcphhjVwsoRtikbLsYnUUSEbr.allowAxes)
				{
					if (ITprcphhjVwsoRtikbLsYnUUSEbr.allowButtons)
					{
						if (xVKaZqnugFxvHtHFmmqKejLJAsxhA.zrYHivOjqJAuOuIAKPTYyJpcfvcBA != null)
						{
							P_0 = xVKaZqnugFxvHtHFmmqKejLJAsxhA.zrYHivOjqJAuOuIAKPTYyJpcfvcBA.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(xVKaZqnugFxvHtHFmmqKejLJAsxhA.iXcVggNGaFagZtXSJHLQpUTXOafR, xVKaZqnugFxvHtHFmmqKejLJAsxhA.cJASvkyonCrrFSrPguuuNNGQIoBDA);
						}
					}
					else if (xVKaZqnugFxvHtHFmmqKejLJAsxhA.zrYHivOjqJAuOuIAKPTYyJpcfvcBA != null)
					{
						P_0 = xVKaZqnugFxvHtHFmmqKejLJAsxhA.zrYHivOjqJAuOuIAKPTYyJpcfvcBA.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!ITprcphhjVwsoRtikbLsYnUUSEbr.allowButtons)
					{
						ciQgadaKbTBMZHxwzgTOblHMoYnU("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (xVKaZqnugFxvHtHFmmqKejLJAsxhA.zrYHivOjqJAuOuIAKPTYyJpcfvcBA != null)
					{
						P_0 = xVKaZqnugFxvHtHFmmqKejLJAsxhA.zrYHivOjqJAuOuIAKPTYyJpcfvcBA.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> wzwpQcnmHTiKAOBtsvQlPmWBYsSR(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				dMgHwvCRtZQFXRdaIdarnHxXRpGD.Clear();
				if (!ITprcphhjVwsoRtikbLsYnUUSEbr.allowButtons)
				{
					return dMgHwvCRtZQFXRdaIdarnHxXRpGD;
				}
				dMgHwvCRtZQFXRdaIdarnHxXRpGD.Add(qXdLRiQgbpXfDpiZGHhkieJAdMTt(ITprcphhjVwsoRtikbLsYnUUSEbr, out P_0));
				return dMgHwvCRtZQFXRdaIdarnHxXRpGD;
			}

			private ControllerPollingInfo qXdLRiQgbpXfDpiZGHhkieJAdMTt(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = auGfVxiENwdFCZbOiyOPQNHJrICP(P_0, out flag, out P_1, out text);
				if (flag)
				{
					BJbAEAPRbwuheBdctKmemqBtTowV();
				}
				return result;
			}

			private static ControllerPollingInfo auGfVxiENwdFCZbOiyOPQNHJrICP(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
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

			private static bool ouhjjrMVJNWEDMTlLaaWYnJZQOuT(ControllerPollingInfo P_0, Options P_1)
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
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.fdoFbVRRFGOGjyoXtYLtwcvkwWdO<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool ZZTBoqehcHAIcFIWGVNmDofLFjUJA(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.NPJDvfsjusWjIIeuajDnXfdOHaRv == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void fehsHQRnkdVZHJrFBlZtuWCVaRrQ()
			{
				if (!ITprcphhjVwsoRtikbLsYnUUSEbr.checkForConflicts)
				{
					return;
				}
				if (ITprcphhjVwsoRtikbLsYnUUSEbr.checkForConflictsWithSelf && xVKaZqnugFxvHtHFmmqKejLJAsxhA.zrYHivOjqJAuOuIAKPTYyJpcfvcBA != null)
				{
					ListTools.AddIfUnique(jVbdMKVZcNHhXALbpIHEIUYIaIKQ, xVKaZqnugFxvHtHFmmqKejLJAsxhA.zrYHivOjqJAuOuIAKPTYyJpcfvcBA);
				}
				if (ITprcphhjVwsoRtikbLsYnUUSEbr.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(jVbdMKVZcNHhXALbpIHEIUYIaIKQ, ReInput.players.SystemPlayer);
				}
				if (ITprcphhjVwsoRtikbLsYnUUSEbr.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(jVbdMKVZcNHhXALbpIHEIUYIaIKQ, players[i]);
					}
				}
				else
				{
					if (ITprcphhjVwsoRtikbLsYnUUSEbr.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(ITprcphhjVwsoRtikbLsYnUUSEbr.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(jVbdMKVZcNHhXALbpIHEIUYIaIKQ, allPlayers[j]);
						}
					}
				}
			}

			private aIXdVRdTueaxnVeDLsRfcHIdnrSFB VCApsSGZOffXHLfoTxAEWOvGhmus(ElementAssignment P_0)
			{
				if (ITprcphhjVwsoRtikbLsYnUUSEbr.checkForConflicts && xVKaZqnugFxvHtHFmmqKejLJAsxhA.zrYHivOjqJAuOuIAKPTYyJpcfvcBA != null && uTHRrTeiAIiDjQbGfyxbBVfOvWTR(xVKaZqnugFxvHtHFmmqKejLJAsxhA, P_0, jVbdMKVZcNHhXALbpIHEIUYIaIKQ))
				{
					return ZhQGPkFYQTuoMFUYsiNKYyWoFAIHA(P_0);
				}
				return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Continue;
			}

			private static bool uTHRrTeiAIiDjQbGfyxbBVfOvWTR(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.zrYHivOjqJAuOuIAKPTYyJpcfvcBA == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!sjntfjeYcIADjvIziCCNIKWzjRMYA(P_0, P_1, out var conflictCheck))
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

			private static bool BmAjUMdPpbKkXNRzMtZFxftmCefX(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.zrYHivOjqJAuOuIAKPTYyJpcfvcBA == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!sjntfjeYcIADjvIziCCNIKWzjRMYA(P_0, P_1, out var conflictCheck))
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

			private static IList<ElementAssignmentConflictInfo> tkVlZinznSWruyduWeGHkgkPfrJPA(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.zrYHivOjqJAuOuIAKPTYyJpcfvcBA == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!sjntfjeYcIADjvIziCCNIKWzjRMYA(P_0, P_1, out var conflictCheck))
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

			private static bool sjntfjeYcIADjvIziCCNIKWzjRMYA(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				if (P_0 == null || (player = P_0.zrYHivOjqJAuOuIAKPTYyJpcfvcBA) == null)
				{
					P_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				P_2 = P_1.ToElementAssignmentConflictCheck();
				P_2.playerId = player.id;
				P_2.controllerType = P_0.iXcVggNGaFagZtXSJHLQpUTXOafR;
				P_2.controllerId = P_0.cJASvkyonCrrFSrPguuuNNGQIoBDA;
				P_2.controllerMapId = P_0.PdAxqEhhOEdmoUOaQKPzVlbPckeI.controllerMap.id;
				P_2.controllerMapCategoryId = P_0.PdAxqEhhOEdmoUOaQKPzVlbPckeI.controllerMap.categoryId;
				if (P_0.PdAxqEhhOEdmoUOaQKPzVlbPckeI.actionElementMapToReplace != null)
				{
					P_2.elementMapId = P_0.PdAxqEhhOEdmoUOaQKPzVlbPckeI.actionElementMapToReplace.id;
				}
				return true;
			}

			private static void cVWQXbAJKlITusOZzRDaMYbQqGhm(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.zrYHivOjqJAuOuIAKPTYyJpcfvcBA == null)
				{
					return;
				}
				if (!sjntfjeYcIADjvIziCCNIKWzjRMYA(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void BGygnsBgYwwFASQDMbfVKIErGNTbA()
			{
				ReInput.UpdateEndedEvent -= joIyytPThubKKgUPNbvUmiknGdAKA;
				ReInput.UpdateEndedEvent += joIyytPThubKKgUPNbvUmiknGdAKA;
			}

			private void HcomGVtwjLoTFlGIwDhaoQHkciJK()
			{
				ReInput.UpdateEndedEvent -= joIyytPThubKKgUPNbvUmiknGdAKA;
			}

			private bool deGjhFKSHGJFNMcfAGyAhzwGAqxFA(SFjgWozprAIRiZZQlnBdHOGIaujCA P_0)
			{
				SafeDelegate safeDelegate = KNwIPwxLZwyBBFjaChrljGfjJtheA[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void YUmFHBQbGGhKfjqXVzqJnQGMZTcpA<_0001>(SFjgWozprAIRiZZQlnBdHOGIaujCA P_0, _0001 P_1)
			{
				SafeAction<_0001> safeAction = (SafeAction<_0001>)KNwIPwxLZwyBBFjaChrljGfjJtheA[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void BJbAEAPRbwuheBdctKmemqBtTowV()
			{
				TGPDpMfOFBlHmalosbUfdKdKaOrwB = ReInput.unscaledTime;
			}

			private void TKrbilcOzefaedbAeBKVRNRVhSPv()
			{
				vtBENOBSLDhxLazmhUvTfFsQnAdh = true;
			}

			private bool BjsaLDIZZPxECeamjWKpOlKLMIBbb(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
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
					if (FxDaguHUcJnqASJoOhGLPmiWdtvAb(elementType, axisRange, axisContribution, controller.GetElementById(P_0.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid).type, P_0.axisRange, P_0.axisContribution))
					{
						num++;
					}
				}
				using (IEnumerator<ActionElementMap> enumerator = elementAssignmentConflictInfo.controllerMap.ElementMapsWithAction(actionId).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						iPbEPLcxQDCqlnGfoFoJKrPKjCZg iPbEPLcxQDCqlnGfoFoJKrPKjCZg2 = new iPbEPLcxQDCqlnGfoFoJKrPKjCZg();
						iPbEPLcxQDCqlnGfoFoJKrPKjCZg2.ODkrzPWIzDsFJXldRfSahtIrWZZM = enumerator.Current;
						if (iPbEPLcxQDCqlnGfoFoJKrPKjCZg2.ODkrzPWIzDsFJXldRfSahtIrWZZM.id != elementMap.id && ListTools.FindIndex(list, iPbEPLcxQDCqlnGfoFoJKrPKjCZg2.TjIuwksRcnUFtPdIXEBLzkvIQSPo) < 0 && FxDaguHUcJnqASJoOhGLPmiWdtvAb(elementType, axisRange, axisContribution, iPbEPLcxQDCqlnGfoFoJKrPKjCZg2.ODkrzPWIzDsFJXldRfSahtIrWZZM.elementType, iPbEPLcxQDCqlnGfoFoJKrPKjCZg2.ODkrzPWIzDsFJXldRfSahtIrWZZM.axisRange, iPbEPLcxQDCqlnGfoFoJKrPKjCZg2.ODkrzPWIzDsFJXldRfSahtIrWZZM.axisContribution))
						{
							num++;
						}
					}
				}
				return num < P_3;
			}

			private bool bzgZzlBEqRSdGbXCIQFxqdWpeEJbA(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, bool P_2, out string P_3)
			{
				if (P_0 == null)
				{
					P_3 = "Mapping is null reference.";
					return false;
				}
				List<Player> list = new List<Player> { P_0.zrYHivOjqJAuOuIAKPTYyJpcfvcBA };
				IList<ElementAssignmentConflictInfo> list2 = tkVlZinznSWruyduWeGHkgkPfrJPA(P_0, P_1, list);
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
				if (P_0.PdAxqEhhOEdmoUOaQKPzVlbPckeI.actionElementMapToReplace == null)
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
				ActionElementMap actionElementMap2 = new ActionElementMap(P_0.PdAxqEhhOEdmoUOaQKPzVlbPckeI.actionElementMapToReplace);
				cVWQXbAJKlITusOZzRDaMYbQqGhm(P_0, P_1, list);
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
				elementAssignmentConflictInfo.controllerMap.ReplaceOrCreateElementMap(ElementAssignment.CompleteAssignment(P_0.iXcVggNGaFagZtXSJHLQpUTXOafR, elementType, elementIdentifierId, axisRange, keyCode, modifierKeyFlags, actionId, axisContribution, invert));
				P_3 = null;
				return true;
			}

			private static bool FxDaguHUcJnqASJoOhGLPmiWdtvAb(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
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

			private void JnNorCUJComdfKaKFRzMEActsJbJ(ActionElementMap P_0)
			{
				rbBlZCNWiODMKunrJSxzJzCSUTWJ(P_0);
				UzBiiYEzOSsUmLTXTudzAlOoLkVf();
			}

			private void CNLeHQfYwGvAHWImfPJvwodKZoSV(string P_0)
			{
				IdeTTiYNFukritylAxrDHsHeDKBKA(P_0);
				UzBiiYEzOSsUmLTXTudzAlOoLkVf();
			}

			private aIXdVRdTueaxnVeDLsRfcHIdnrSFB ZhQGPkFYQTuoMFUYsiNKYyWoFAIHA(ElementAssignment P_0)
			{
				if (deGjhFKSHGJFNMcfAGyAhzwGAqxFA(SFjgWozprAIRiZZQlnBdHOGIaujCA.ConflictsFound))
				{
					bool flag = BmAjUMdPpbKkXNRzMtZFxftmCefX(xVKaZqnugFxvHtHFmmqKejLJAsxhA, P_0, jVbdMKVZcNHhXALbpIHEIUYIaIKQ);
					yzefwsmBqBduRvFyGICjsJAlVkFK = P_0;
					IList<ElementAssignmentConflictInfo> list = tkVlZinznSWruyduWeGHkgkPfrJPA(xVKaZqnugFxvHtHFmmqKejLJAsxhA, P_0, jVbdMKVZcNHhXALbpIHEIUYIaIKQ);
					sDYDqVbMDelbRaDOjjxDirEERsKcE = KphdnMVRpmuQJRiqOTowrbIpEEH.ConflictChecking;
					UkVFnpKHoAiFtiiOawXrwVzdALoZB();
					nHUTcXnbmhMqcPkgjeweTfhmEVBj(new ElementAssignmentInfo(xVKaZqnugFxvHtHFmmqKejLJAsxhA.PdAxqEhhOEdmoUOaQKPzVlbPckeI.controllerMap, P_0), list, flag);
					return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Quit;
				}
				return iYViAKyTZmVpUOBoaUdKyxewHnJe(ITprcphhjVwsoRtikbLsYnUUSEbr.defaultActionWhenConflictFound, P_0);
			}

			private aIXdVRdTueaxnVeDLsRfcHIdnrSFB iYViAKyTZmVpUOBoaUdKyxewHnJe(ConflictResponse P_0, ElementAssignment P_1)
			{
				return WOglYlsHwwguMowCeYxQbFDvoKSh(P_0, P_1, BmAjUMdPpbKkXNRzMtZFxftmCefX(xVKaZqnugFxvHtHFmmqKejLJAsxhA, P_1, jVbdMKVZcNHhXALbpIHEIUYIaIKQ));
			}

			private aIXdVRdTueaxnVeDLsRfcHIdnrSFB WOglYlsHwwguMowCeYxQbFDvoKSh(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					CNLeHQfYwGvAHWImfPJvwodKZoSV("Mapping assignment was canceled due to a conflict.");
					return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Quit;
				case ConflictResponse.Replace:
					if (P_2)
					{
						CNLeHQfYwGvAHWImfPJvwodKZoSV("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Quit;
					}
					cVWQXbAJKlITusOZzRDaMYbQqGhm(xVKaZqnugFxvHtHFmmqKejLJAsxhA, P_1, jVbdMKVZcNHhXALbpIHEIUYIaIKQ);
					return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Continue;
				case ConflictResponse.Add:
					return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Continue;
				case ConflictResponse.Ignore:
					ZkyqgApZYAdTnbGlSofTwXmapFtl();
					return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Quit;
				case ConflictResponse.Swap:
				{
					if (!bzgZzlBEqRSdGbXCIQFxqdWpeEJbA(xVKaZqnugFxvHtHFmmqKejLJAsxhA, P_1, P_2, out var text))
					{
						CNLeHQfYwGvAHWImfPJvwodKZoSV(text);
						return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Quit;
					}
					return aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Continue;
				}
				default:
					throw new NotImplementedException();
				}
			}

			private void jKMwZXnfZekuQKRvtPogqDpPxfSi()
			{
				iVkPrBcVknfdsgELXJoVdmUdFkpiA();
				UzBiiYEzOSsUmLTXTudzAlOoLkVf();
			}

			private void ciQgadaKbTBMZHxwzgTOblHMoYnU(string P_0)
			{
				tbDdxZWwMbzgACbrPGePCXcaGHaDA(P_0);
				UzBiiYEzOSsUmLTXTudzAlOoLkVf();
			}

			private void UkVFnpKHoAiFtiiOawXrwVzdALoZB()
			{
				TKrbilcOzefaedbAeBKVRNRVhSPv();
				HcomGVtwjLoTFlGIwDhaoQHkciJK();
				zMGrXPKvuRDVbsGIjhnQBOuvoJnhb = Status.AwaitingResponse;
			}

			private void ZkyqgApZYAdTnbGlSofTwXmapFtl()
			{
				zMGrXPKvuRDVbsGIjhnQBOuvoJnhb = Status.Listening;
				sDYDqVbMDelbRaDOjjxDirEERsKcE = KphdnMVRpmuQJRiqOTowrbIpEEH.None;
				BJbAEAPRbwuheBdctKmemqBtTowV();
				BGygnsBgYwwFASQDMbfVKIErGNTbA();
			}

			private void qYRcGbUouCdFmKqYphfpYrPHFRBtA(ElementAssignment P_0)
			{
				if (xVKaZqnugFxvHtHFmmqKejLJAsxhA.PdAxqEhhOEdmoUOaQKPzVlbPckeI.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					JnNorCUJComdfKaKFRzMEActsJbJ(result);
				}
				else
				{
					ciQgadaKbTBMZHxwzgTOblHMoYnU("Failed to create element assignment.");
				}
			}

			private void rbBlZCNWiODMKunrJSxzJzCSUTWJ(ActionElementMap P_0)
			{
				if (deGjhFKSHGJFNMcfAGyAhzwGAqxFA(SFjgWozprAIRiZZQlnBdHOGIaujCA.InputMapped))
				{
					YUmFHBQbGGhKfjqXVzqJnQGMZTcpA(SFjgWozprAIRiZZQlnBdHOGIaujCA.InputMapped, new InputMappedEventData(BxgNuwJJOVVQoNqRaMmzrhSPRkzT, P_0));
				}
			}

			private void iVkPrBcVknfdsgELXJoVdmUdFkpiA()
			{
				if (deGjhFKSHGJFNMcfAGyAhzwGAqxFA(SFjgWozprAIRiZZQlnBdHOGIaujCA.TimedOut))
				{
					YUmFHBQbGGhKfjqXVzqJnQGMZTcpA(SFjgWozprAIRiZZQlnBdHOGIaujCA.TimedOut, new TimedOutEventData(BxgNuwJJOVVQoNqRaMmzrhSPRkzT));
				}
			}

			private void tbDdxZWwMbzgACbrPGePCXcaGHaDA(string P_0)
			{
				if (deGjhFKSHGJFNMcfAGyAhzwGAqxFA(SFjgWozprAIRiZZQlnBdHOGIaujCA.Error))
				{
					YUmFHBQbGGhKfjqXVzqJnQGMZTcpA(SFjgWozprAIRiZZQlnBdHOGIaujCA.Error, new ErrorEventData(BxgNuwJJOVVQoNqRaMmzrhSPRkzT, P_0));
				}
			}

			private void IdeTTiYNFukritylAxrDHsHeDKBKA(string P_0)
			{
				if (deGjhFKSHGJFNMcfAGyAhzwGAqxFA(SFjgWozprAIRiZZQlnBdHOGIaujCA.Canceled))
				{
					YUmFHBQbGGhKfjqXVzqJnQGMZTcpA(SFjgWozprAIRiZZQlnBdHOGIaujCA.Canceled, new CanceledEventData(BxgNuwJJOVVQoNqRaMmzrhSPRkzT, P_0));
				}
			}

			private void nHUTcXnbmhMqcPkgjeweTfhmEVBj(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				qDMRczegzAOPXGerRIqkOUfAwhKf qDMRczegzAOPXGerRIqkOUfAwhKf2 = new qDMRczegzAOPXGerRIqkOUfAwhKf();
				qDMRczegzAOPXGerRIqkOUfAwhKf2.amtGoCyROLHCLBlERyNDsQEkRDFl = this;
				qDMRczegzAOPXGerRIqkOUfAwhKf2.gKtSlUShncaluEegbdhQhsRceOiXB = P_0;
				qDMRczegzAOPXGerRIqkOUfAwhKf2.PXKPHeEfvpZjDiNtXBEcdZiyiziV = P_1;
				qDMRczegzAOPXGerRIqkOUfAwhKf2.YuQKNMwHERByYpXbXehPfhowGcAkA = P_2;
				if (deGjhFKSHGJFNMcfAGyAhzwGAqxFA(SFjgWozprAIRiZZQlnBdHOGIaujCA.ConflictsFound))
				{
					YUmFHBQbGGhKfjqXVzqJnQGMZTcpA(SFjgWozprAIRiZZQlnBdHOGIaujCA.ConflictsFound, new ConflictFoundEventData(BxgNuwJJOVVQoNqRaMmzrhSPRkzT, CcwfkuSbcghseJtFgtMZLlJJsHuIA, qDMRczegzAOPXGerRIqkOUfAwhKf2.gKtSlUShncaluEegbdhQhsRceOiXB, qDMRczegzAOPXGerRIqkOUfAwhKf2.PXKPHeEfvpZjDiNtXBEcdZiyiziV, qDMRczegzAOPXGerRIqkOUfAwhKf2.YuQKNMwHERByYpXbXehPfhowGcAkA, qDMRczegzAOPXGerRIqkOUfAwhKf2.SvnnleKodTxsrbHmdhbHJyFmnbKIA));
				}
			}

			private void QLVVPjWcPpBDuRDrjWscRCAXRPnf()
			{
				if (deGjhFKSHGJFNMcfAGyAhzwGAqxFA(SFjgWozprAIRiZZQlnBdHOGIaujCA.Started))
				{
					YUmFHBQbGGhKfjqXVzqJnQGMZTcpA(SFjgWozprAIRiZZQlnBdHOGIaujCA.Started, new StartedEventData(BxgNuwJJOVVQoNqRaMmzrhSPRkzT));
				}
			}

			private void mrsRINaLSANpncBkdeJdjjrIsTMl()
			{
				if (deGjhFKSHGJFNMcfAGyAhzwGAqxFA(SFjgWozprAIRiZZQlnBdHOGIaujCA.Stopped))
				{
					YUmFHBQbGGhKfjqXVzqJnQGMZTcpA(SFjgWozprAIRiZZQlnBdHOGIaujCA.Stopped, new StoppedEventData(BxgNuwJJOVVQoNqRaMmzrhSPRkzT));
				}
			}

			public void CcwfkuSbcghseJtFgtMZLlJJsHuIA(ConflictResponse P_0)
			{
				if (zMGrXPKvuRDVbsGIjhnQBOuvoJnhb != Status.AwaitingResponse || sDYDqVbMDelbRaDOjjxDirEERsKcE != KphdnMVRpmuQJRiqOTowrbIpEEH.ConflictChecking)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (iYViAKyTZmVpUOBoaUdKyxewHnJe(P_0, yzefwsmBqBduRvFyGICjsJAlVkFK) == aIXdVRdTueaxnVeDLsRfcHIdnrSFB.Continue)
					{
						qYRcGbUouCdFmKqYphfpYrPHFRBtA(yzefwsmBqBduRvFyGICjsJAlVkFK);
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
			private sealed class nlxcgfFPXVuZiMWqiuqhjLzVnSoo
			{
				public static readonly nlxcgfFPXVuZiMWqiuqhjLzVnSoo _003C_003E9 = new nlxcgfFPXVuZiMWqiuqhjLzVnSoo();

				public static Action<Exception> _003C_003E9__64_0;

				internal void vsSyoGhHdafGLJOduSePYcrMfAxXA(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
				}
			}

			private bool levTrbkplrLswiuQJBfbISMohFlcA = true;

			private bool khcntejPUMLdGdpIWuQAEbpEireAA = true;

			private bool AbHAagiLjnAjDHeuiSuPgccsrCugb = true;

			private float fbEWGcgutXBGnYvZVlPrilFxXQwA;

			private bool JqBhxSrwPWtKOtyPvipKHPndxkNX = true;

			private bool FjkWFyTooDIDAKXrjjqCrzJUTdtWA = true;

			private bool WinBvAAujfXPJKnqbDGgsZJRTWPKA = true;

			private bool aQgBSBOYqwtpWbmxbEoakamgeVNab = true;

			private int[] FNhioDhIswcMybOcOczUfNTojzKC;

			private ConflictResponse bYXGxDUrnWRuMfevowIcxBIJlBZb = ConflictResponse.Replace;

			private bool dOkzePrEkutdAuzREnzlsZkmTDnk;

			private bool jsqBhYdJweEQAewZpnCOPBorkeCTA;

			private bool EzBzmurNbEdeLkIiDnFaIdbyzqghA = true;

			private bool DsGdeZdOHaVGhfbqdIAIZSQcYRze = true;

			private float FUbYmKlqEECXMGjdEsyixfIsBeEK = 1f;

			internal const string OOYXzoBbYUWwDAQiRSPdVpYQiQRu = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> MvvJEOwJjjbiKLigNSaNdKIIxZNk = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			public bool allowAxes
			{
				get
				{
					return levTrbkplrLswiuQJBfbISMohFlcA;
				}
				set
				{
					levTrbkplrLswiuQJBfbISMohFlcA = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return khcntejPUMLdGdpIWuQAEbpEireAA;
				}
				set
				{
					khcntejPUMLdGdpIWuQAEbpEireAA = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return AbHAagiLjnAjDHeuiSuPgccsrCugb;
				}
				set
				{
					AbHAagiLjnAjDHeuiSuPgccsrCugb = value;
				}
			}

			public float timeout
			{
				get
				{
					return fbEWGcgutXBGnYvZVlPrilFxXQwA;
				}
				set
				{
					fbEWGcgutXBGnYvZVlPrilFxXQwA = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return JqBhxSrwPWtKOtyPvipKHPndxkNX;
				}
				set
				{
					JqBhxSrwPWtKOtyPvipKHPndxkNX = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return FjkWFyTooDIDAKXrjjqCrzJUTdtWA;
				}
				set
				{
					FjkWFyTooDIDAKXrjjqCrzJUTdtWA = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return WinBvAAujfXPJKnqbDGgsZJRTWPKA;
				}
				set
				{
					WinBvAAujfXPJKnqbDGgsZJRTWPKA = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return aQgBSBOYqwtpWbmxbEoakamgeVNab;
				}
				set
				{
					aQgBSBOYqwtpWbmxbEoakamgeVNab = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return FNhioDhIswcMybOcOczUfNTojzKC;
				}
				set
				{
					FNhioDhIswcMybOcOczUfNTojzKC = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return bYXGxDUrnWRuMfevowIcxBIJlBZb;
				}
				set
				{
					bYXGxDUrnWRuMfevowIcxBIJlBZb = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return dOkzePrEkutdAuzREnzlsZkmTDnk;
				}
				set
				{
					dOkzePrEkutdAuzREnzlsZkmTDnk = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return jsqBhYdJweEQAewZpnCOPBorkeCTA;
				}
				set
				{
					jsqBhYdJweEQAewZpnCOPBorkeCTA = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return EzBzmurNbEdeLkIiDnFaIdbyzqghA;
				}
				set
				{
					EzBzmurNbEdeLkIiDnFaIdbyzqghA = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return DsGdeZdOHaVGhfbqdIAIZSQcYRze;
				}
				set
				{
					DsGdeZdOHaVGhfbqdIAIZSQcYRze = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return FUbYmKlqEECXMGjdEsyixfIsBeEK;
				}
				set
				{
					FUbYmKlqEECXMGjdEsyixfIsBeEK = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)MvvJEOwJjjbiKLigNSaNdKIIxZNk["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = nlxcgfFPXVuZiMWqiuqhjLzVnSoo._003C_003E9.vsSyoGhHdafGLJOduSePYcrMfAxXA;
					}
					MvvJEOwJjjbiKLigNSaNdKIIxZNk["isElementAllowed"] = safePredicate;
				}
			}

			internal _0001 fdoFbVRRFGOGjyoXtYLtwcvkwWdO<_0001>(string P_0) where _0001 : SafeDelegate
			{
				if (!MvvJEOwJjjbiKLigNSaNdKIIxZNk.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as _0001;
			}

			public Options()
			{
				wLjmvHfwoNMgfUakqgSUGkshQgumA();
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
				stringBuilder.Append("allowAxes = " + levTrbkplrLswiuQJBfbISMohFlcA + "\n");
				stringBuilder.Append("allowButtons = " + khcntejPUMLdGdpIWuQAEbpEireAA + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + AbHAagiLjnAjDHeuiSuPgccsrCugb + "\n");
				stringBuilder.Append("timeout = " + fbEWGcgutXBGnYvZVlPrilFxXQwA + "\n");
				stringBuilder.Append("checkForConflicts = " + JqBhxSrwPWtKOtyPvipKHPndxkNX + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + FjkWFyTooDIDAKXrjjqCrzJUTdtWA + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + WinBvAAujfXPJKnqbDGgsZJRTWPKA + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + aQgBSBOYqwtpWbmxbEoakamgeVNab + "\n");
				if (FNhioDhIswcMybOcOczUfNTojzKC == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(FNhioDhIswcMybOcOczUfNTojzKC) + "\n");
				}
				stringBuilder.Append("defaultActionWhenConflictFound = " + bYXGxDUrnWRuMfevowIcxBIJlBZb.ToString() + "\n");
				stringBuilder.Append("ignoreMouseXAxis = " + dOkzePrEkutdAuzREnzlsZkmTDnk);
				stringBuilder.Append("ignoreMouseYAxis = " + jsqBhYdJweEQAewZpnCOPBorkeCTA);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + EzBzmurNbEdeLkIiDnFaIdbyzqghA + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + DsGdeZdOHaVGhfbqdIAIZSQcYRze + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + FUbYmKlqEECXMGjdEsyixfIsBeEK + "\n");
				return stringBuilder.ToString();
			}

			internal void wLjmvHfwoNMgfUakqgSUGkshQgumA()
			{
				levTrbkplrLswiuQJBfbISMohFlcA = true;
				khcntejPUMLdGdpIWuQAEbpEireAA = true;
				AbHAagiLjnAjDHeuiSuPgccsrCugb = true;
				fbEWGcgutXBGnYvZVlPrilFxXQwA = 0f;
				JqBhxSrwPWtKOtyPvipKHPndxkNX = true;
				FjkWFyTooDIDAKXrjjqCrzJUTdtWA = true;
				WinBvAAujfXPJKnqbDGgsZJRTWPKA = true;
				aQgBSBOYqwtpWbmxbEoakamgeVNab = true;
				FNhioDhIswcMybOcOczUfNTojzKC = null;
				bYXGxDUrnWRuMfevowIcxBIJlBZb = ConflictResponse.Replace;
				dOkzePrEkutdAuzREnzlsZkmTDnk = false;
				jsqBhYdJweEQAewZpnCOPBorkeCTA = false;
				EzBzmurNbEdeLkIiDnFaIdbyzqghA = true;
				DsGdeZdOHaVGhfbqdIAIZSQcYRze = true;
				FUbYmKlqEECXMGjdEsyixfIsBeEK = 1f;
				foreach (string item in new List<string>(MvvJEOwJjjbiKLigNSaNdKIIxZNk.Keys))
				{
					MvvJEOwJjjbiKLigNSaNdKIIxZNk[item] = null;
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
				destination.levTrbkplrLswiuQJBfbISMohFlcA = source.levTrbkplrLswiuQJBfbISMohFlcA;
				destination.khcntejPUMLdGdpIWuQAEbpEireAA = source.khcntejPUMLdGdpIWuQAEbpEireAA;
				destination.AbHAagiLjnAjDHeuiSuPgccsrCugb = source.AbHAagiLjnAjDHeuiSuPgccsrCugb;
				destination.fbEWGcgutXBGnYvZVlPrilFxXQwA = source.fbEWGcgutXBGnYvZVlPrilFxXQwA;
				destination.JqBhxSrwPWtKOtyPvipKHPndxkNX = source.JqBhxSrwPWtKOtyPvipKHPndxkNX;
				destination.FjkWFyTooDIDAKXrjjqCrzJUTdtWA = source.FjkWFyTooDIDAKXrjjqCrzJUTdtWA;
				destination.WinBvAAujfXPJKnqbDGgsZJRTWPKA = source.WinBvAAujfXPJKnqbDGgsZJRTWPKA;
				destination.aQgBSBOYqwtpWbmxbEoakamgeVNab = source.aQgBSBOYqwtpWbmxbEoakamgeVNab;
				destination.FNhioDhIswcMybOcOczUfNTojzKC = ArrayTools.ShallowCopy(source.FNhioDhIswcMybOcOczUfNTojzKC);
				destination.bYXGxDUrnWRuMfevowIcxBIJlBZb = source.bYXGxDUrnWRuMfevowIcxBIJlBZb;
				destination.dOkzePrEkutdAuzREnzlsZkmTDnk = source.dOkzePrEkutdAuzREnzlsZkmTDnk;
				destination.jsqBhYdJweEQAewZpnCOPBorkeCTA = source.jsqBhYdJweEQAewZpnCOPBorkeCTA;
				destination.EzBzmurNbEdeLkIiDnFaIdbyzqghA = source.EzBzmurNbEdeLkIiDnFaIdbyzqghA;
				destination.DsGdeZdOHaVGhfbqdIAIZSQcYRze = source.DsGdeZdOHaVGhfbqdIAIZSQcYRze;
				destination.FUbYmKlqEECXMGjdEsyixfIsBeEK = source.FUbYmKlqEECXMGjdEsyixfIsBeEK;
				foreach (KeyValuePair<string, SafeDelegate> item in source.MvvJEOwJjjbiKLigNSaNdKIIxZNk)
				{
					destination.MvvJEOwJjjbiKLigNSaNdKIIxZNk[item.Key] = MiscTools.Clone(item.Value);
				}
			}
		}

		[Serializable]
		private sealed class bzFaLmsrLddgYCnxPBqQZGwJOCbfb
		{
			public static readonly bzFaLmsrLddgYCnxPBqQZGwJOCbfb _003C_003E9 = new bzFaLmsrLddgYCnxPBqQZGwJOCbfb();

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void FHVPpcSeAMeaqWcNOsTmJOqqcpKCA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
			}

			internal void qgJtDsSJfkkWPqPzKkQvvzpWRtRk(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
			}

			internal void MOMmeLqlrCgyEnNHyhqwIqTBNtKV(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
			}

			internal void fICFJjAfidIearlDDifAaGOqImVwA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
			}

			internal void DLjSMdPomqsrvkpYMQUjWpKICGUC(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
			}

			internal void UckHNPYObEWnHDLKKCjCFvItJZCx(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
			}

			internal void jsityKaEVhKjXzzoXSAeBdSXURmT(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
			}
		}

		private static InputMapper qBHljYnOKlOVSXgmdCIBxIhxuNDF;

		private static int ObViYkylIyBlcHPpmEpZanOixfWOb;

		private readonly int vDOFfMIDqVgxEfGHNgOJfIILVtacb;

		private readonly bool vXusKvMZijBJRGHTqYotamheHieW;

		private readonly tTnMlrhwMWbbvWdVieULFcxPOCSz RfwGOYLJvZNVKASrAyyFMenhzeYG;

		private Options RgDepPByCZUeljCktXPoOlMsmYJEb;

		private readonly Dictionary<SFjgWozprAIRiZZQlnBdHOGIaujCA, SafeDelegate> ysnhaOxLOomrBkBqtyzkcTWmkYBS = new Dictionary<SFjgWozprAIRiZZQlnBdHOGIaujCA, SafeDelegate>
		{
			{
				SFjgWozprAIRiZZQlnBdHOGIaujCA.InputMapped,
				new SafeAction<InputMappedEventData>(bzFaLmsrLddgYCnxPBqQZGwJOCbfb._003C_003E9.FHVPpcSeAMeaqWcNOsTmJOqqcpKCA)
			},
			{
				SFjgWozprAIRiZZQlnBdHOGIaujCA.Error,
				new SafeAction<ErrorEventData>(bzFaLmsrLddgYCnxPBqQZGwJOCbfb._003C_003E9.qgJtDsSJfkkWPqPzKkQvvzpWRtRk)
			},
			{
				SFjgWozprAIRiZZQlnBdHOGIaujCA.Canceled,
				new SafeAction<CanceledEventData>(bzFaLmsrLddgYCnxPBqQZGwJOCbfb._003C_003E9.MOMmeLqlrCgyEnNHyhqwIqTBNtKV)
			},
			{
				SFjgWozprAIRiZZQlnBdHOGIaujCA.TimedOut,
				new SafeAction<TimedOutEventData>(bzFaLmsrLddgYCnxPBqQZGwJOCbfb._003C_003E9.fICFJjAfidIearlDDifAaGOqImVwA)
			},
			{
				SFjgWozprAIRiZZQlnBdHOGIaujCA.Started,
				new SafeAction<StartedEventData>(bzFaLmsrLddgYCnxPBqQZGwJOCbfb._003C_003E9.DLjSMdPomqsrvkpYMQUjWpKICGUC)
			},
			{
				SFjgWozprAIRiZZQlnBdHOGIaujCA.Stopped,
				new SafeAction<StoppedEventData>(bzFaLmsrLddgYCnxPBqQZGwJOCbfb._003C_003E9.UckHNPYObEWnHDLKKCjCFvItJZCx)
			},
			{
				SFjgWozprAIRiZZQlnBdHOGIaujCA.ConflictsFound,
				new SafeAction<ConflictFoundEventData>(bzFaLmsrLddgYCnxPBqQZGwJOCbfb._003C_003E9.jsityKaEVhKjXzzoXSAeBdSXURmT)
			}
		};

		public static InputMapper Default => qBHljYnOKlOVSXgmdCIBxIhxuNDF ?? (qBHljYnOKlOVSXgmdCIBxIhxuNDF = new InputMapper(true));

		public Options options
		{
			get
			{
				Options obj = RgDepPByCZUeljCktXPoOlMsmYJEb;
				if (obj == null)
				{
					if (!vXusKvMZijBJRGHTqYotamheHieW)
					{
						return RgDepPByCZUeljCktXPoOlMsmYJEb = Default.options.Clone();
					}
					obj = (RgDepPByCZUeljCktXPoOlMsmYJEb = new Options());
				}
				return obj;
			}
			set
			{
				RgDepPByCZUeljCktXPoOlMsmYJEb = value;
			}
		}

		public Context mappingContext => RfwGOYLJvZNVKASrAyyFMenhzeYG.qeXZOkmiIkuXMmdTgmCpaIkinffo;

		public Status status => RfwGOYLJvZNVKASrAyyFMenhzeYG.IYBqYpWomNccKbYrROLfFAkeGslQ;

		public float timeRemaining => RfwGOYLJvZNVKASrAyyFMenhzeYG.DzJHnBduJETHwHAmNWLJjATkhjJr;

		internal int YegRYhbNbQhyyOYswQBrdRFDNaSM => vDOFfMIDqVgxEfGHNgOJfIILVtacb;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.InputMapped;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<InputMappedEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.InputMapped;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<InputMappedEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.Error;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<ErrorEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.Error;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<ErrorEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.Canceled;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<CanceledEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.Canceled;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<CanceledEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.TimedOut;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<TimedOutEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.TimedOut;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<TimedOutEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.Started;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<StartedEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.Started;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<StartedEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.Stopped;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<StoppedEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.Stopped;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<StoppedEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.ConflictsFound;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<ConflictFoundEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					SFjgWozprAIRiZZQlnBdHOGIaujCA key = SFjgWozprAIRiZZQlnBdHOGIaujCA.ConflictsFound;
					ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] = (SafeAction<ConflictFoundEventData>)ysnhaOxLOomrBkBqtyzkcTWmkYBS[key] - value;
				}
			}
		}

		private static int ddHCrDQjTMXZotiwmCBBXuUuNvwe()
		{
			int obViYkylIyBlcHPpmEpZanOixfWOb = ObViYkylIyBlcHPpmEpZanOixfWOb;
			if (ObViYkylIyBlcHPpmEpZanOixfWOb == int.MaxValue)
			{
				ObViYkylIyBlcHPpmEpZanOixfWOb = 0;
				return obViYkylIyBlcHPpmEpZanOixfWOb;
			}
			ObViYkylIyBlcHPpmEpZanOixfWOb++;
			return obViYkylIyBlcHPpmEpZanOixfWOb;
		}

		public InputMapper()
			: this(false)
		{
			vDOFfMIDqVgxEfGHNgOJfIILVtacb = ddHCrDQjTMXZotiwmCBBXuUuNvwe();
		}

		private InputMapper(bool P_0)
		{
			vXusKvMZijBJRGHTqYotamheHieW = P_0;
			if (vXusKvMZijBJRGHTqYotamheHieW)
			{
				RgDepPByCZUeljCktXPoOlMsmYJEb = new Options();
			}
			RfwGOYLJvZNVKASrAyyFMenhzeYG = new tTnMlrhwMWbbvWdVieULFcxPOCSz(this, ysnhaOxLOomrBkBqtyzkcTWmkYBS);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<SFjgWozprAIRiZZQlnBdHOGIaujCA, SafeDelegate> ysnhaOxLOomrBkBqtyzkcTWmkYB in ysnhaOxLOomrBkBqtyzkcTWmkYBS)
			{
				ysnhaOxLOomrBkBqtyzkcTWmkYB.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<SFjgWozprAIRiZZQlnBdHOGIaujCA, SafeDelegate> ysnhaOxLOomrBkBqtyzkcTWmkYB in ysnhaOxLOomrBkBqtyzkcTWmkYBS)
			{
				ysnhaOxLOomrBkBqtyzkcTWmkYB.Value.Clear();
			}
		}

		internal void okngPBWhwQLAqtNGrsnuWLmnctCcA(object P_0)
		{
		}

		internal void fbWpyVSgBEDViLaAhuIseYcmIUPe()
		{
		}

		public bool Start(Context mappingContext)
		{
			return XuylJaPEHntPtbkTkXaxBHeSwWJT(mappingContext, (RgDepPByCZUeljCktXPoOlMsmYJEb != null) ? RgDepPByCZUeljCktXPoOlMsmYJEb : Default.options);
		}

		public void Stop()
		{
			RfwGOYLJvZNVKASrAyyFMenhzeYG.NCOclEboGlrWhsxYeKDpgSzniUTI("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			fbWpyVSgBEDViLaAhuIseYcmIUPe();
			RgDepPByCZUeljCktXPoOlMsmYJEb = null;
		}

		private bool XuylJaPEHntPtbkTkXaxBHeSwWJT(Context P_0, Options P_1)
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
				RfwGOYLJvZNVKASrAyyFMenhzeYG.cSYVPLkXIElQisGAsBiuiVIcLmrE(P_0, P_1);
				return true;
			}
			catch
			{
				RfwGOYLJvZNVKASrAyyFMenhzeYG.NCOclEboGlrWhsxYeKDpgSzniUTI("Failed to start due to an exception.");
				return false;
			}
		}
	}
}
