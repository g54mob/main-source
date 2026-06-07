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
			private int WtxqRhyewFhRCZexgGgTPAkliDAd = -1;

			private ControllerMap xnhNfzyqGuCronbiVjqLrzXhjTDR;

			private ActionElementMap KaxTDdrGzDvRPWowWgyufgzhfSmfb;

			private AxisRange whWedHybHebOtxSEJTDdHkzxfrxw = AxisRange.Positive;

			private bool GZlaoDruTrxbpKABIxsvccmRvfdp;

			public int actionId
			{
				get
				{
					return WtxqRhyewFhRCZexgGgTPAkliDAd;
				}
				set
				{
					if (!QewHIOCTWValNSqewneyYoOrjOvAb())
					{
						WtxqRhyewFhRCZexgGgTPAkliDAd = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(WtxqRhyewFhRCZexgGgTPAkliDAd);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!QewHIOCTWValNSqewneyYoOrjOvAb())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							WtxqRhyewFhRCZexgGgTPAkliDAd = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							WtxqRhyewFhRCZexgGgTPAkliDAd = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return xnhNfzyqGuCronbiVjqLrzXhjTDR;
				}
				set
				{
					if (!QewHIOCTWValNSqewneyYoOrjOvAb())
					{
						xnhNfzyqGuCronbiVjqLrzXhjTDR = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return KaxTDdrGzDvRPWowWgyufgzhfSmfb;
				}
				set
				{
					if (!QewHIOCTWValNSqewneyYoOrjOvAb())
					{
						KaxTDdrGzDvRPWowWgyufgzhfSmfb = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return whWedHybHebOtxSEJTDdHkzxfrxw;
				}
				set
				{
					if (!QewHIOCTWValNSqewneyYoOrjOvAb())
					{
						whWedHybHebOtxSEJTDdHkzxfrxw = value;
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

			internal void NKBcKXzflFkdrvVAruarefQcmIkt()
			{
				GZlaoDruTrxbpKABIxsvccmRvfdp = true;
			}

			private bool QewHIOCTWValNSqewneyYoOrjOvAb()
			{
				if (GZlaoDruTrxbpKABIxsvccmRvfdp)
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
				destination.WtxqRhyewFhRCZexgGgTPAkliDAd = source.WtxqRhyewFhRCZexgGgTPAkliDAd;
				destination.xnhNfzyqGuCronbiVjqLrzXhjTDR = source.xnhNfzyqGuCronbiVjqLrzXhjTDR;
				destination.KaxTDdrGzDvRPWowWgyufgzhfSmfb = source.KaxTDdrGzDvRPWowWgyufgzhfSmfb;
				destination.whWedHybHebOtxSEJTDdHkzxfrxw = source.whWedHybHebOtxSEJTDdHkzxfrxw;
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

		private enum iDoQDHIiwETMbCJizSppYbHEesMc
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

		private class ZvDhRYMRDsjbFHQHwDxDbYSTMUTD
		{
			private enum muLFjORuycYLNbTjLtXMUDFJHdOk
			{
				Quit = 0,
				Continue = 1
			}

			private enum JfJEHVACqwRhFrlZYtHMrqJEYVpAA
			{
				None = 0,
				ConflictChecking = 1
			}

			private class pmUzdMirAlhOtikpOkSpGPQLRyNe
			{
				private Player UvBXHObDlZYGHHCzDkZZTJyJLvx;

				private int WtxqRhyewFhRCZexgGgTPAkliDAd;

				private Context TvyapNatNkCCbRwPhJLJlPhnekMtA;

				private ControllerType FHHqpHICfRrjYzaZOfxGJuaReWmv;

				private int JJTApEccBgIfJOWwHYEPwbJOOnbjA;

				private ControllerPollingInfo VOcFbIStcPxDDEWoPSFXGKryckwR;

				private ModifierKeyFlags ckQxpADOjVaaMJciryKJvIwODZeCA;

				public Player EVSYfBRoRmlZGWzbtVEKHpHdIHIm => UvBXHObDlZYGHHCzDkZZTJyJLvx;

				public int oRajQOHwRbMrJNwZiDDGjrEZUMQf => WtxqRhyewFhRCZexgGgTPAkliDAd;

				public Context qYkEVCpesWbAtDCezhWRBzcJaIGKA => TvyapNatNkCCbRwPhJLJlPhnekMtA;

				public ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs => FHHqpHICfRrjYzaZOfxGJuaReWmv;

				public int ewwLiKFmCKbnVFhcViVbHODDzYHW => JJTApEccBgIfJOWwHYEPwbJOOnbjA;

				public ControllerPollingInfo byAFfydmOrcNbayjDdRyuEIoJpDY => VOcFbIStcPxDDEWoPSFXGKryckwR;

				public ModifierKeyFlags vumoKGoIRVLegjZXlOfdXDdaDhgk => ckQxpADOjVaaMJciryKJvIwODZeCA;

				public AxisRange kHytYvdOKSYoCQbwRpoWYapCFjaG
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (byAFfydmOrcNbayjDdRyuEIoJpDY.elementType == ControllerElementType.Axis)
						{
							result = ((TvyapNatNkCCbRwPhJLJlPhnekMtA.actionRange != AxisRange.Full) ? ((byAFfydmOrcNbayjDdRyuEIoJpDY.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
						}
						return result;
					}
				}

				public string cEVTolnLxPQycmAdyfMPITZGAFikA
				{
					get
					{
						if (qwgjCbRzxrpcbcpGuDjyBQzIUaDs == ControllerType.Keyboard && vumoKGoIRVLegjZXlOfdXDdaDhgk != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(vumoKGoIRVLegjZXlOfdXDdaDhgk)} + {byAFfydmOrcNbayjDdRyuEIoJpDY.elementIdentifierName}";
						}
						string text = byAFfydmOrcNbayjDdRyuEIoJpDY.elementIdentifierName;
						if (byAFfydmOrcNbayjDdRyuEIoJpDY.elementType == ControllerElementType.Axis)
						{
							if (kHytYvdOKSYoCQbwRpoWYapCFjaG == AxisRange.Positive)
							{
								text += " +";
							}
							else if (kHytYvdOKSYoCQbwRpoWYapCFjaG == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				public void gUxczTgMdKUcYRnCXamteWaCXJodc(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
					UvBXHObDlZYGHHCzDkZZTJyJLvx = P_0;
					WtxqRhyewFhRCZexgGgTPAkliDAd = P_1.actionId;
					FHHqpHICfRrjYzaZOfxGJuaReWmv = P_1.controllerMap.controllerType;
					JJTApEccBgIfJOWwHYEPwbJOOnbjA = P_1.controllerMap.controllerId;
					TvyapNatNkCCbRwPhJLJlPhnekMtA = P_1;
					FHHqpHICfRrjYzaZOfxGJuaReWmv = P_1.controllerMap.controllerType;
					JJTApEccBgIfJOWwHYEPwbJOOnbjA = P_1.controllerMap.controllerId;
					P_1.NKBcKXzflFkdrvVAruarefQcmIkt();
				}

				public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
				{
					UvBXHObDlZYGHHCzDkZZTJyJLvx = null;
					WtxqRhyewFhRCZexgGgTPAkliDAd = -1;
					TvyapNatNkCCbRwPhJLJlPhnekMtA = null;
					FHHqpHICfRrjYzaZOfxGJuaReWmv = ControllerType.Keyboard;
					JJTApEccBgIfJOWwHYEPwbJOOnbjA = -1;
					VOcFbIStcPxDDEWoPSFXGKryckwR = default(ControllerPollingInfo);
					ckQxpADOjVaaMJciryKJvIwODZeCA = ModifierKeyFlags.None;
				}

				public ElementAssignment vWTWEPBOTNFdpxCpQzIbCjjPTllg(ControllerPollingInfo P_0)
				{
					VOcFbIStcPxDDEWoPSFXGKryckwR = P_0;
					return vWTWEPBOTNFdpxCpQzIbCjjPTllg();
				}

				public ElementAssignment vWTWEPBOTNFdpxCpQzIbCjjPTllg(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					VOcFbIStcPxDDEWoPSFXGKryckwR = P_0;
					ckQxpADOjVaaMJciryKJvIwODZeCA = P_1;
					return vWTWEPBOTNFdpxCpQzIbCjjPTllg();
				}

				public ElementAssignment vWTWEPBOTNFdpxCpQzIbCjjPTllg()
				{
					return new ElementAssignment(qwgjCbRzxrpcbcpGuDjyBQzIUaDs, VOcFbIStcPxDDEWoPSFXGKryckwR.elementType, VOcFbIStcPxDDEWoPSFXGKryckwR.elementIdentifierId, kHytYvdOKSYoCQbwRpoWYapCFjaG, VOcFbIStcPxDDEWoPSFXGKryckwR.keyboardKey, ckQxpADOjVaaMJciryKJvIwODZeCA, WtxqRhyewFhRCZexgGgTPAkliDAd, (TvyapNatNkCCbRwPhJLJlPhnekMtA.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (TvyapNatNkCCbRwPhJLJlPhnekMtA.actionElementMapToReplace != null) ? TvyapNatNkCCbRwPhJLJlPhnekMtA.actionElementMapToReplace.id : (-1));
				}
			}

			private readonly InputMapper rBdHDCfDobOjBUqyNbBnmEluxEvZ;

			private readonly Options gWFkjNQjMYNHGCUHgmjPDBquGmEq = new Options();

			private readonly pmUzdMirAlhOtikpOkSpGPQLRyNe WyGOFkAEQFlDbtdojjqgGamralvG = new pmUzdMirAlhOtikpOkSpGPQLRyNe();

			private readonly Dictionary<iDoQDHIiwETMbCJizSppYbHEesMc, SafeDelegate> ZJHOjdYCFtQdnCcqeMUMPtxtyudC;

			private readonly Dictionary<string, SafeDelegate> FcyivYKfpDdWyGkqLAlfXrDVByow;

			private Status UfFxjysFLxRopyPKKKxvjAPfOIdq;

			private JfJEHVACqwRhFrlZYtHMrqJEYVpAA tCnjxBRPGxDZIwSvLBDKBCEjkluL;

			private double NVJLtSvqwpWmxGuvMYWPFSaDWVYC;

			private bool xHEguNZLuURcprclCUCLhmgJxSMO;

			private List<Player> jbmSbMXmRRagDHILbinjZznDLBrnA = new List<Player>();

			private readonly List<ControllerPollingInfo> MLbFWYeVCcLRjKWMwoKzRVRYRPWz = new List<ControllerPollingInfo>();

			private ElementAssignment lTgoqjCHRiwTSwsQvQWjxkPMCDSG;

			public Status zrBcGbaLGxobtIkzgrnbFBqUkYqH => UfFxjysFLxRopyPKKKxvjAPfOIdq;

			public float mIpClqFXZidSkqvJhszTGmWiVIchA
			{
				get
				{
					if (UfFxjysFLxRopyPKKKxvjAPfOIdq == Status.Idle)
					{
						return 0f;
					}
					if (gWFkjNQjMYNHGCUHgmjPDBquGmEq.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, NVJLtSvqwpWmxGuvMYWPFSaDWVYC + (double)gWFkjNQjMYNHGCUHgmjPDBquGmEq.timeout - ReInput.unscaledTime);
				}
			}

			public Context nMdsvGVoiFsvlDBhLobjLROepJIM
			{
				get
				{
					if (UfFxjysFLxRopyPKKKxvjAPfOIdq == Status.Idle)
					{
						return null;
					}
					return WyGOFkAEQFlDbtdojjqgGamralvG.qYkEVCpesWbAtDCezhWRBzcJaIGKA;
				}
			}

			private bool ovzlzRWrnpFRyZooyErBXaJCCIro
			{
				get
				{
					if (xHEguNZLuURcprclCUCLhmgJxSMO)
					{
						return false;
					}
					if (!(gWFkjNQjMYNHGCUHgmjPDBquGmEq.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public ZvDhRYMRDsjbFHQHwDxDbYSTMUTD(InputMapper P_0, Dictionary<iDoQDHIiwETMbCJizSppYbHEesMc, SafeDelegate> P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("events");
				}
				rBdHDCfDobOjBUqyNbBnmEluxEvZ = P_0;
				ZJHOjdYCFtQdnCcqeMUMPtxtyudC = P_1;
				iqSeAMNoRFWAzJLKanbJnrgyPcwX();
			}

			protected virtual void hQVInFWrTMOWfdrNDZJGjCGXxatd()
			{
				try
				{
					QoIfAjCldKxmQlDpmitXWAxXylyG();
				}
				finally
				{
					base.Finalize();
				}
			}

			public void rIjUCmsjifmvcBNTbhJRFVmmqsqk(Context P_0, Options P_1)
			{
				if (UfFxjysFLxRopyPKKKxvjAPfOIdq != Status.Idle)
				{
					faEZOLRrhTSQOwIdZucJFIRdpLlh("User started a new listening session.");
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
				Options.Copy(P_1, gWFkjNQjMYNHGCUHgmjPDBquGmEq);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					zXwEVqllwtOTMPjlzmsgzuheqOrM("No Action found for actionId: " + P_0.actionId);
					return;
				}
				WyGOFkAEQFlDbtdojjqgGamralvG.gUxczTgMdKUcYRnCXamteWaCXJodc(player, P_0);
				UfFxjysFLxRopyPKKKxvjAPfOIdq = Status.Listening;
				rTuiuFsWYuMzTuNRFKakEmPsaOxu();
				EfAedUDAmguPuxhsIdTPEgBiepCcb();
				seAsLvCVhutZBSdjWZowazoKIkpd();
				dmRxjNeEhKTIvHGkZzclNAFgoNNt();
			}

			public void rIDxlGQcqdKUvtFpkiSHtGvVApWC(string P_0)
			{
				if (UfFxjysFLxRopyPKKKxvjAPfOIdq != Status.Idle)
				{
					faEZOLRrhTSQOwIdZucJFIRdpLlh(P_0);
				}
			}

			private void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
			{
				if (P_0 == UpdateLoopType.Update && UfFxjysFLxRopyPKKKxvjAPfOIdq == Status.Listening)
				{
					ElementAssignment elementAssignment;
					if (ovzlzRWrnpFRyZooyErBXaJCCIro && mIpClqFXZidSkqvJhszTGmWiVIchA <= 0f)
					{
						CfomYOUugJAARKrpvsmRrOipFNTd();
					}
					else if (ReInput.controllers.GetController(WyGOFkAEQFlDbtdojjqgGamralvG.qwgjCbRzxrpcbcpGuDjyBQzIUaDs, WyGOFkAEQFlDbtdojjqgGamralvG.ewwLiKFmCKbnVFhcViVbHODDzYHW) == null)
					{
						zXwEVqllwtOTMPjlzmsgzuheqOrM("Controller not found for type: " + WyGOFkAEQFlDbtdojjqgGamralvG.qwgjCbRzxrpcbcpGuDjyBQzIUaDs.ToString() + " id: " + WyGOFkAEQFlDbtdojjqgGamralvG.ewwLiKFmCKbnVFhcViVbHODDzYHW);
					}
					else if (ZBgDviXzuwlLosmYoukzQDuneweg(out elementAssignment) != muLFjORuycYLNbTjLtXMUDFJHdOk.Quit && WzEzLzOCWdfvEgAzPGfnNLfMtUVq(elementAssignment) != muLFjORuycYLNbTjLtXMUDFJHdOk.Quit)
					{
						dSFlRNCVDYwLZTbJTgmpptwdJfvW(elementAssignment);
					}
				}
			}

			private void cfGxOdtHWEPUlSbBpwyOclSNIGkO()
			{
				if (UfFxjysFLxRopyPKKKxvjAPfOIdq != Status.Idle)
				{
					iqSeAMNoRFWAzJLKanbJnrgyPcwX();
					QoIfAjCldKxmQlDpmitXWAxXylyG();
					iJPeLUZsgwKsvhdgjmGmsOuQdsMeA();
				}
			}

			private void iqSeAMNoRFWAzJLKanbJnrgyPcwX()
			{
				UfFxjysFLxRopyPKKKxvjAPfOIdq = Status.Idle;
				NVJLtSvqwpWmxGuvMYWPFSaDWVYC = 0.0;
				gWFkjNQjMYNHGCUHgmjPDBquGmEq.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
				WyGOFkAEQFlDbtdojjqgGamralvG.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
				lTgoqjCHRiwTSwsQvQWjxkPMCDSG = default(ElementAssignment);
				tCnjxBRPGxDZIwSvLBDKBCEjkluL = JfJEHVACqwRhFrlZYtHMrqJEYVpAA.None;
				xHEguNZLuURcprclCUCLhmgJxSMO = false;
				jbmSbMXmRRagDHILbinjZznDLBrnA.Clear();
			}

			private muLFjORuycYLNbTjLtXMUDFJHdOk ZBgDviXzuwlLosmYoukzQDuneweg(out ElementAssignment P_0)
			{
				if (!BMgikzJOrnrunEHNTBustCcfdPNn(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return muLFjORuycYLNbTjLtXMUDFJHdOk.Quit;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !rwcDKfKJUXixFBhHNYoHaWPRsDjF(item, gWFkjNQjMYNHGCUHgmjPDBquGmEq))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return muLFjORuycYLNbTjLtXMUDFJHdOk.Quit;
				}
				if (!gJlDEpABixzHOdKijQoHaMvULvKsA(WyGOFkAEQFlDbtdojjqgGamralvG, controllerPollingInfo, gWFkjNQjMYNHGCUHgmjPDBquGmEq))
				{
					P_0 = default(ElementAssignment);
					return muLFjORuycYLNbTjLtXMUDFJHdOk.Quit;
				}
				P_0 = WyGOFkAEQFlDbtdojjqgGamralvG.vWTWEPBOTNFdpxCpQzIbCjjPTllg(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return muLFjORuycYLNbTjLtXMUDFJHdOk.Continue;
			}

			private bool BMgikzJOrnrunEHNTBustCcfdPNn(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = WyGOFkAEQFlDbtdojjqgGamralvG.qwgjCbRzxrpcbcpGuDjyBQzIUaDs;
				int controllerId = WyGOFkAEQFlDbtdojjqgGamralvG.ewwLiKFmCKbnVFhcViVbHODDzYHW;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = GTVWPodPMAAJnvxgGijgUAOVuXu(out P_1);
					return true;
				}
				if (gWFkjNQjMYNHGCUHgmjPDBquGmEq.allowAxes)
				{
					if (gWFkjNQjMYNHGCUHgmjPDBquGmEq.allowButtons)
					{
						if (WyGOFkAEQFlDbtdojjqgGamralvG.EVSYfBRoRmlZGWzbtVEKHpHdIHIm != null)
						{
							P_0 = WyGOFkAEQFlDbtdojjqgGamralvG.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(WyGOFkAEQFlDbtdojjqgGamralvG.qwgjCbRzxrpcbcpGuDjyBQzIUaDs, WyGOFkAEQFlDbtdojjqgGamralvG.ewwLiKFmCKbnVFhcViVbHODDzYHW);
						}
					}
					else if (WyGOFkAEQFlDbtdojjqgGamralvG.EVSYfBRoRmlZGWzbtVEKHpHdIHIm != null)
					{
						P_0 = WyGOFkAEQFlDbtdojjqgGamralvG.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!gWFkjNQjMYNHGCUHgmjPDBquGmEq.allowButtons)
					{
						zXwEVqllwtOTMPjlzmsgzuheqOrM("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (WyGOFkAEQFlDbtdojjqgGamralvG.EVSYfBRoRmlZGWzbtVEKHpHdIHIm != null)
					{
						P_0 = WyGOFkAEQFlDbtdojjqgGamralvG.EVSYfBRoRmlZGWzbtVEKHpHdIHIm.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> GTVWPodPMAAJnvxgGijgUAOVuXu(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				MLbFWYeVCcLRjKWMwoKzRVRYRPWz.Clear();
				if (!gWFkjNQjMYNHGCUHgmjPDBquGmEq.allowButtons)
				{
					return MLbFWYeVCcLRjKWMwoKzRVRYRPWz;
				}
				MLbFWYeVCcLRjKWMwoKzRVRYRPWz.Add(qxlemTiLhXOzsdeqcVKVZGjLCRzg(gWFkjNQjMYNHGCUHgmjPDBquGmEq, out P_0));
				return MLbFWYeVCcLRjKWMwoKzRVRYRPWz;
			}

			private ControllerPollingInfo qxlemTiLhXOzsdeqcVKVZGjLCRzg(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = qxlemTiLhXOzsdeqcVKVZGjLCRzg(P_0, out flag, out P_1, out text);
				if (flag)
				{
					rTuiuFsWYuMzTuNRFKakEmPsaOxu();
				}
				return result;
			}

			private static ControllerPollingInfo qxlemTiLhXOzsdeqcVKVZGjLCRzg(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
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

			private static bool rwcDKfKJUXixFBhHNYoHaWPRsDjF(ControllerPollingInfo P_0, Options P_1)
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
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.RhabjnUWqbcSFUiFGjBorUpCDgLI<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool gJlDEpABixzHOdKijQoHaMvULvKsA(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.kHytYvdOKSYoCQbwRpoWYapCFjaG == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void EfAedUDAmguPuxhsIdTPEgBiepCcb()
			{
				if (!gWFkjNQjMYNHGCUHgmjPDBquGmEq.checkForConflicts)
				{
					return;
				}
				if (gWFkjNQjMYNHGCUHgmjPDBquGmEq.checkForConflictsWithSelf && WyGOFkAEQFlDbtdojjqgGamralvG.EVSYfBRoRmlZGWzbtVEKHpHdIHIm != null)
				{
					ListTools.AddIfUnique(jbmSbMXmRRagDHILbinjZznDLBrnA, WyGOFkAEQFlDbtdojjqgGamralvG.EVSYfBRoRmlZGWzbtVEKHpHdIHIm);
				}
				if (gWFkjNQjMYNHGCUHgmjPDBquGmEq.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(jbmSbMXmRRagDHILbinjZznDLBrnA, ReInput.players.SystemPlayer);
				}
				if (gWFkjNQjMYNHGCUHgmjPDBquGmEq.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(jbmSbMXmRRagDHILbinjZznDLBrnA, players[i]);
					}
				}
				else
				{
					if (gWFkjNQjMYNHGCUHgmjPDBquGmEq.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(gWFkjNQjMYNHGCUHgmjPDBquGmEq.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(jbmSbMXmRRagDHILbinjZznDLBrnA, allPlayers[j]);
						}
					}
				}
			}

			private muLFjORuycYLNbTjLtXMUDFJHdOk WzEzLzOCWdfvEgAzPGfnNLfMtUVq(ElementAssignment P_0)
			{
				if (gWFkjNQjMYNHGCUHgmjPDBquGmEq.checkForConflicts && WyGOFkAEQFlDbtdojjqgGamralvG.EVSYfBRoRmlZGWzbtVEKHpHdIHIm != null && iJQNMOIxOVvDCXTDCJqRnFhnvZfP(WyGOFkAEQFlDbtdojjqgGamralvG, P_0, jbmSbMXmRRagDHILbinjZznDLBrnA))
				{
					return QXILPfIkCbutOXmJHSChJPCmMMbq(P_0);
				}
				return muLFjORuycYLNbTjLtXMUDFJHdOk.Continue;
			}

			private static bool iJQNMOIxOVvDCXTDCJqRnFhnvZfP(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.EVSYfBRoRmlZGWzbtVEKHpHdIHIm == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!WaBOOKBtjOsDkgcQMSfXZQvlHaCP(P_0, P_1, out var conflictCheck))
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

			private static bool WOITgoeQxaEwrAXmnTpqEJSPMWHBb(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.EVSYfBRoRmlZGWzbtVEKHpHdIHIm == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!WaBOOKBtjOsDkgcQMSfXZQvlHaCP(P_0, P_1, out var conflictCheck))
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

			private static IList<ElementAssignmentConflictInfo> tzQsbRIENRAkAYeEuLCSgbXxMglm(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.EVSYfBRoRmlZGWzbtVEKHpHdIHIm == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!WaBOOKBtjOsDkgcQMSfXZQvlHaCP(P_0, P_1, out var conflictCheck))
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

			private static bool WaBOOKBtjOsDkgcQMSfXZQvlHaCP(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				if (P_0 == null || (player = P_0.EVSYfBRoRmlZGWzbtVEKHpHdIHIm) == null)
				{
					P_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				P_2 = P_1.ToElementAssignmentConflictCheck();
				P_2.playerId = player.id;
				P_2.controllerType = P_0.qwgjCbRzxrpcbcpGuDjyBQzIUaDs;
				P_2.controllerId = P_0.ewwLiKFmCKbnVFhcViVbHODDzYHW;
				P_2.controllerMapId = P_0.qYkEVCpesWbAtDCezhWRBzcJaIGKA.controllerMap.id;
				P_2.controllerMapCategoryId = P_0.qYkEVCpesWbAtDCezhWRBzcJaIGKA.controllerMap.categoryId;
				if (P_0.qYkEVCpesWbAtDCezhWRBzcJaIGKA.actionElementMapToReplace != null)
				{
					P_2.elementMapId = P_0.qYkEVCpesWbAtDCezhWRBzcJaIGKA.actionElementMapToReplace.id;
				}
				return true;
			}

			private static void czMydpzERgypAziEXGtLKUcLbCoaA(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.EVSYfBRoRmlZGWzbtVEKHpHdIHIm == null)
				{
					return;
				}
				if (!WaBOOKBtjOsDkgcQMSfXZQvlHaCP(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void seAsLvCVhutZBSdjWZowazoKIkpd()
			{
				ReInput.UpdateEndedEvent -= sOLNzBCCbZmFXkMugfndpShqgrUP;
				ReInput.UpdateEndedEvent += sOLNzBCCbZmFXkMugfndpShqgrUP;
			}

			private void QoIfAjCldKxmQlDpmitXWAxXylyG()
			{
				ReInput.UpdateEndedEvent -= sOLNzBCCbZmFXkMugfndpShqgrUP;
			}

			private bool vsUBJgRhuSRyEqtbZhHUPALeIIlY(iDoQDHIiwETMbCJizSppYbHEesMc P_0)
			{
				SafeDelegate safeDelegate = ZJHOjdYCFtQdnCcqeMUMPtxtyudC[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void WkEIHNWRAChbzjbcJQHkWrAwQxsd<_0001>(iDoQDHIiwETMbCJizSppYbHEesMc P_0, _0001 P_1)
			{
				SafeAction<_0001> safeAction = (SafeAction<_0001>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void rTuiuFsWYuMzTuNRFKakEmPsaOxu()
			{
				NVJLtSvqwpWmxGuvMYWPFSaDWVYC = ReInput.unscaledTime;
			}

			private void hbnMJHcnNPaRLokTxCsmFevsdVCk()
			{
				xHEguNZLuURcprclCUCLhmgJxSMO = true;
			}

			private void sgYvTbUUeSOqwuIORywGshHqTSPF(ActionElementMap P_0)
			{
				OLoCEbROPZJUdKCpVjhWlaaLuLmi(P_0);
				cfGxOdtHWEPUlSbBpwyOclSNIGkO();
			}

			private void faEZOLRrhTSQOwIdZucJFIRdpLlh(string P_0)
			{
				LNnxcXuQYWomptRbSaHOQArVDAVZ(P_0);
				cfGxOdtHWEPUlSbBpwyOclSNIGkO();
			}

			private muLFjORuycYLNbTjLtXMUDFJHdOk QXILPfIkCbutOXmJHSChJPCmMMbq(ElementAssignment P_0)
			{
				if (vsUBJgRhuSRyEqtbZhHUPALeIIlY(iDoQDHIiwETMbCJizSppYbHEesMc.ConflictsFound))
				{
					bool flag = WOITgoeQxaEwrAXmnTpqEJSPMWHBb(WyGOFkAEQFlDbtdojjqgGamralvG, P_0, jbmSbMXmRRagDHILbinjZznDLBrnA);
					lTgoqjCHRiwTSwsQvQWjxkPMCDSG = P_0;
					IList<ElementAssignmentConflictInfo> list = tzQsbRIENRAkAYeEuLCSgbXxMglm(WyGOFkAEQFlDbtdojjqgGamralvG, P_0, jbmSbMXmRRagDHILbinjZznDLBrnA);
					tCnjxBRPGxDZIwSvLBDKBCEjkluL = JfJEHVACqwRhFrlZYtHMrqJEYVpAA.ConflictChecking;
					cFtPvAtRpOqedAmQIFoYPszIZNjl();
					VVuowzZNSfoPvhVQHCeeEuEKmcGU(new ElementAssignmentInfo(WyGOFkAEQFlDbtdojjqgGamralvG.qYkEVCpesWbAtDCezhWRBzcJaIGKA.controllerMap, P_0), list, flag);
					return muLFjORuycYLNbTjLtXMUDFJHdOk.Quit;
				}
				return kYEnrRNoJrUyXTDkrRTvBGAwCPAcA(gWFkjNQjMYNHGCUHgmjPDBquGmEq.defaultActionWhenConflictFound, P_0);
			}

			private muLFjORuycYLNbTjLtXMUDFJHdOk kYEnrRNoJrUyXTDkrRTvBGAwCPAcA(ConflictResponse P_0, ElementAssignment P_1)
			{
				return kYEnrRNoJrUyXTDkrRTvBGAwCPAcA(P_0, P_1, WOITgoeQxaEwrAXmnTpqEJSPMWHBb(WyGOFkAEQFlDbtdojjqgGamralvG, P_1, jbmSbMXmRRagDHILbinjZznDLBrnA));
			}

			private muLFjORuycYLNbTjLtXMUDFJHdOk kYEnrRNoJrUyXTDkrRTvBGAwCPAcA(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					faEZOLRrhTSQOwIdZucJFIRdpLlh("Mapping assignment was canceled due to a conflict.");
					return muLFjORuycYLNbTjLtXMUDFJHdOk.Quit;
				case ConflictResponse.Replace:
					if (P_2)
					{
						faEZOLRrhTSQOwIdZucJFIRdpLlh("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return muLFjORuycYLNbTjLtXMUDFJHdOk.Quit;
					}
					czMydpzERgypAziEXGtLKUcLbCoaA(WyGOFkAEQFlDbtdojjqgGamralvG, P_1, jbmSbMXmRRagDHILbinjZznDLBrnA);
					return muLFjORuycYLNbTjLtXMUDFJHdOk.Continue;
				case ConflictResponse.Add:
					return muLFjORuycYLNbTjLtXMUDFJHdOk.Continue;
				case ConflictResponse.Ignore:
					bVHeZOsPlOfWncyuIkoucwJxQLpqA();
					return muLFjORuycYLNbTjLtXMUDFJHdOk.Quit;
				default:
					throw new NotImplementedException();
				}
			}

			private void CfomYOUugJAARKrpvsmRrOipFNTd()
			{
				ErFnoEbeEcVwYNynYJuCevASTppQ();
				cfGxOdtHWEPUlSbBpwyOclSNIGkO();
			}

			private void zXwEVqllwtOTMPjlzmsgzuheqOrM(string P_0)
			{
				pNNuUURovyOzrrdwZEfGEOLNOvPab(P_0);
				cfGxOdtHWEPUlSbBpwyOclSNIGkO();
			}

			private void cFtPvAtRpOqedAmQIFoYPszIZNjl()
			{
				hbnMJHcnNPaRLokTxCsmFevsdVCk();
				QoIfAjCldKxmQlDpmitXWAxXylyG();
				UfFxjysFLxRopyPKKKxvjAPfOIdq = Status.AwaitingResponse;
			}

			private void bVHeZOsPlOfWncyuIkoucwJxQLpqA()
			{
				UfFxjysFLxRopyPKKKxvjAPfOIdq = Status.Listening;
				tCnjxBRPGxDZIwSvLBDKBCEjkluL = JfJEHVACqwRhFrlZYtHMrqJEYVpAA.None;
				rTuiuFsWYuMzTuNRFKakEmPsaOxu();
				seAsLvCVhutZBSdjWZowazoKIkpd();
			}

			private void dSFlRNCVDYwLZTbJTgmpptwdJfvW(ElementAssignment P_0)
			{
				if (WyGOFkAEQFlDbtdojjqgGamralvG.qYkEVCpesWbAtDCezhWRBzcJaIGKA.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					sgYvTbUUeSOqwuIORywGshHqTSPF(result);
				}
				else
				{
					zXwEVqllwtOTMPjlzmsgzuheqOrM("Failed to create element assignment.");
				}
			}

			private void OLoCEbROPZJUdKCpVjhWlaaLuLmi(ActionElementMap P_0)
			{
				if (vsUBJgRhuSRyEqtbZhHUPALeIIlY(iDoQDHIiwETMbCJizSppYbHEesMc.InputMapped))
				{
					WkEIHNWRAChbzjbcJQHkWrAwQxsd(iDoQDHIiwETMbCJizSppYbHEesMc.InputMapped, new InputMappedEventData(rBdHDCfDobOjBUqyNbBnmEluxEvZ, P_0));
				}
			}

			private void ErFnoEbeEcVwYNynYJuCevASTppQ()
			{
				if (vsUBJgRhuSRyEqtbZhHUPALeIIlY(iDoQDHIiwETMbCJizSppYbHEesMc.TimedOut))
				{
					WkEIHNWRAChbzjbcJQHkWrAwQxsd(iDoQDHIiwETMbCJizSppYbHEesMc.TimedOut, new TimedOutEventData(rBdHDCfDobOjBUqyNbBnmEluxEvZ));
				}
			}

			private void pNNuUURovyOzrrdwZEfGEOLNOvPab(string P_0)
			{
				if (vsUBJgRhuSRyEqtbZhHUPALeIIlY(iDoQDHIiwETMbCJizSppYbHEesMc.Error))
				{
					WkEIHNWRAChbzjbcJQHkWrAwQxsd(iDoQDHIiwETMbCJizSppYbHEesMc.Error, new ErrorEventData(rBdHDCfDobOjBUqyNbBnmEluxEvZ, P_0));
				}
			}

			private void LNnxcXuQYWomptRbSaHOQArVDAVZ(string P_0)
			{
				if (vsUBJgRhuSRyEqtbZhHUPALeIIlY(iDoQDHIiwETMbCJizSppYbHEesMc.Canceled))
				{
					WkEIHNWRAChbzjbcJQHkWrAwQxsd(iDoQDHIiwETMbCJizSppYbHEesMc.Canceled, new CanceledEventData(rBdHDCfDobOjBUqyNbBnmEluxEvZ, P_0));
				}
			}

			private void VVuowzZNSfoPvhVQHCeeEuEKmcGU(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				if (vsUBJgRhuSRyEqtbZhHUPALeIIlY(iDoQDHIiwETMbCJizSppYbHEesMc.ConflictsFound))
				{
					WkEIHNWRAChbzjbcJQHkWrAwQxsd(iDoQDHIiwETMbCJizSppYbHEesMc.ConflictsFound, new ConflictFoundEventData(rBdHDCfDobOjBUqyNbBnmEluxEvZ, FwlzdKBdOphWUiECGxFWNhiFMZJgA, P_0, P_1, P_2));
				}
			}

			private void dmRxjNeEhKTIvHGkZzclNAFgoNNt()
			{
				if (vsUBJgRhuSRyEqtbZhHUPALeIIlY(iDoQDHIiwETMbCJizSppYbHEesMc.Started))
				{
					WkEIHNWRAChbzjbcJQHkWrAwQxsd(iDoQDHIiwETMbCJizSppYbHEesMc.Started, new StartedEventData(rBdHDCfDobOjBUqyNbBnmEluxEvZ));
				}
			}

			private void iJPeLUZsgwKsvhdgjmGmsOuQdsMeA()
			{
				if (vsUBJgRhuSRyEqtbZhHUPALeIIlY(iDoQDHIiwETMbCJizSppYbHEesMc.Stopped))
				{
					WkEIHNWRAChbzjbcJQHkWrAwQxsd(iDoQDHIiwETMbCJizSppYbHEesMc.Stopped, new StoppedEventData(rBdHDCfDobOjBUqyNbBnmEluxEvZ));
				}
			}

			public void FwlzdKBdOphWUiECGxFWNhiFMZJgA(ConflictResponse P_0)
			{
				if (UfFxjysFLxRopyPKKKxvjAPfOIdq != Status.AwaitingResponse || tCnjxBRPGxDZIwSvLBDKBCEjkluL != JfJEHVACqwRhFrlZYtHMrqJEYVpAA.ConflictChecking)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (kYEnrRNoJrUyXTDkrRTvBGAwCPAcA(P_0, lTgoqjCHRiwTSwsQvQWjxkPMCDSG) == muLFjORuycYLNbTjLtXMUDFJHdOk.Continue)
					{
						dSFlRNCVDYwLZTbJTgmpptwdJfvW(lTgoqjCHRiwTSwsQvQWjxkPMCDSG);
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
			private sealed class XHRfoWFoIjJDWPHpwFpnWoCRRYzsA
			{
				public static readonly XHRfoWFoIjJDWPHpwFpnWoCRRYzsA _003C_003E9 = new XHRfoWFoIjJDWPHpwFpnWoCRRYzsA();

				public static Action<Exception> _003C_003E9__64_0;

				internal void AZRCetBlgXZsuVOECCdTPAeWIUl(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
				}
			}

			private bool NcszPLxzMMcRmhBvdCHKLlSVQjiC = true;

			private bool LypYmIebREXwtSOyNMUXhJWLhnLM = true;

			private bool FfoVexhUQNkgNkPbYFpcdrMGbXqmA = true;

			private float crwJiwJjUjcBHbvFSphLGVtbpptjA;

			private bool TmLREZAbKnmVXGcpAvGoGAPtSUaw = true;

			private bool lzfdhCkohgRQtgDBzuhFQuFHRaFcb = true;

			private bool lppljsocjnVqQakbnVkCnprNvtIe = true;

			private bool fmzhLTaqeFlwNyOcgXRiPirvGofr = true;

			private int[] rmjyHDnTotVheopmXQhYPxeiardo;

			private ConflictResponse XdhAaBgNfNdoQvhlkSBeuMYbAkpaA = ConflictResponse.Replace;

			private bool SHNCLCHRifBYuAqAAoJiVutIWepeb;

			private bool iCZjpeaIVanOpdxIaBWemBNrlDUp;

			private bool wIxzlFRiiOqrhQHWyKQBEzeUdvrV = true;

			private bool zkTLEMuifgnAcFfoTduqOVMVhcFeA = true;

			private float AbwHphdRFJotyIQOclIxtWDCLCtZ = 1f;

			internal const string eBheDtCqRKeuWFgGIeBBqMKoRhCCc = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> FcyivYKfpDdWyGkqLAlfXrDVByow = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			public bool allowAxes
			{
				get
				{
					return NcszPLxzMMcRmhBvdCHKLlSVQjiC;
				}
				set
				{
					NcszPLxzMMcRmhBvdCHKLlSVQjiC = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return LypYmIebREXwtSOyNMUXhJWLhnLM;
				}
				set
				{
					LypYmIebREXwtSOyNMUXhJWLhnLM = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return FfoVexhUQNkgNkPbYFpcdrMGbXqmA;
				}
				set
				{
					FfoVexhUQNkgNkPbYFpcdrMGbXqmA = value;
				}
			}

			public float timeout
			{
				get
				{
					return crwJiwJjUjcBHbvFSphLGVtbpptjA;
				}
				set
				{
					crwJiwJjUjcBHbvFSphLGVtbpptjA = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return TmLREZAbKnmVXGcpAvGoGAPtSUaw;
				}
				set
				{
					TmLREZAbKnmVXGcpAvGoGAPtSUaw = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return lzfdhCkohgRQtgDBzuhFQuFHRaFcb;
				}
				set
				{
					lzfdhCkohgRQtgDBzuhFQuFHRaFcb = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return lppljsocjnVqQakbnVkCnprNvtIe;
				}
				set
				{
					lppljsocjnVqQakbnVkCnprNvtIe = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return fmzhLTaqeFlwNyOcgXRiPirvGofr;
				}
				set
				{
					fmzhLTaqeFlwNyOcgXRiPirvGofr = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return rmjyHDnTotVheopmXQhYPxeiardo;
				}
				set
				{
					rmjyHDnTotVheopmXQhYPxeiardo = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return XdhAaBgNfNdoQvhlkSBeuMYbAkpaA;
				}
				set
				{
					XdhAaBgNfNdoQvhlkSBeuMYbAkpaA = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return SHNCLCHRifBYuAqAAoJiVutIWepeb;
				}
				set
				{
					SHNCLCHRifBYuAqAAoJiVutIWepeb = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return iCZjpeaIVanOpdxIaBWemBNrlDUp;
				}
				set
				{
					iCZjpeaIVanOpdxIaBWemBNrlDUp = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return wIxzlFRiiOqrhQHWyKQBEzeUdvrV;
				}
				set
				{
					wIxzlFRiiOqrhQHWyKQBEzeUdvrV = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return zkTLEMuifgnAcFfoTduqOVMVhcFeA;
				}
				set
				{
					zkTLEMuifgnAcFfoTduqOVMVhcFeA = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return AbwHphdRFJotyIQOclIxtWDCLCtZ;
				}
				set
				{
					AbwHphdRFJotyIQOclIxtWDCLCtZ = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)FcyivYKfpDdWyGkqLAlfXrDVByow["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = XHRfoWFoIjJDWPHpwFpnWoCRRYzsA._003C_003E9.AZRCetBlgXZsuVOECCdTPAeWIUl;
					}
					FcyivYKfpDdWyGkqLAlfXrDVByow["isElementAllowed"] = safePredicate;
				}
			}

			internal _0001 RhabjnUWqbcSFUiFGjBorUpCDgLI<_0001>(string P_0) where _0001 : SafeDelegate
			{
				if (!FcyivYKfpDdWyGkqLAlfXrDVByow.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as _0001;
			}

			public Options()
			{
				HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
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
				stringBuilder.Append("allowAxes = " + NcszPLxzMMcRmhBvdCHKLlSVQjiC + "\n");
				stringBuilder.Append("allowButtons = " + LypYmIebREXwtSOyNMUXhJWLhnLM + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + FfoVexhUQNkgNkPbYFpcdrMGbXqmA + "\n");
				stringBuilder.Append("timeout = " + crwJiwJjUjcBHbvFSphLGVtbpptjA + "\n");
				stringBuilder.Append("checkForConflicts = " + TmLREZAbKnmVXGcpAvGoGAPtSUaw + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + lzfdhCkohgRQtgDBzuhFQuFHRaFcb + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + lppljsocjnVqQakbnVkCnprNvtIe + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + fmzhLTaqeFlwNyOcgXRiPirvGofr + "\n");
				if (rmjyHDnTotVheopmXQhYPxeiardo == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(rmjyHDnTotVheopmXQhYPxeiardo) + "\n");
				}
				stringBuilder.Append("defaultActionWhenConflictFound = " + XdhAaBgNfNdoQvhlkSBeuMYbAkpaA.ToString() + "\n");
				stringBuilder.Append("ignoreMouseXAxis = " + SHNCLCHRifBYuAqAAoJiVutIWepeb);
				stringBuilder.Append("ignoreMouseYAxis = " + iCZjpeaIVanOpdxIaBWemBNrlDUp);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + wIxzlFRiiOqrhQHWyKQBEzeUdvrV + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + zkTLEMuifgnAcFfoTduqOVMVhcFeA + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + AbwHphdRFJotyIQOclIxtWDCLCtZ + "\n");
				return stringBuilder.ToString();
			}

			internal void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
			{
				NcszPLxzMMcRmhBvdCHKLlSVQjiC = true;
				LypYmIebREXwtSOyNMUXhJWLhnLM = true;
				FfoVexhUQNkgNkPbYFpcdrMGbXqmA = true;
				crwJiwJjUjcBHbvFSphLGVtbpptjA = 0f;
				TmLREZAbKnmVXGcpAvGoGAPtSUaw = true;
				lzfdhCkohgRQtgDBzuhFQuFHRaFcb = true;
				lppljsocjnVqQakbnVkCnprNvtIe = true;
				fmzhLTaqeFlwNyOcgXRiPirvGofr = true;
				rmjyHDnTotVheopmXQhYPxeiardo = null;
				XdhAaBgNfNdoQvhlkSBeuMYbAkpaA = ConflictResponse.Replace;
				SHNCLCHRifBYuAqAAoJiVutIWepeb = false;
				iCZjpeaIVanOpdxIaBWemBNrlDUp = false;
				wIxzlFRiiOqrhQHWyKQBEzeUdvrV = true;
				zkTLEMuifgnAcFfoTduqOVMVhcFeA = true;
				AbwHphdRFJotyIQOclIxtWDCLCtZ = 1f;
				foreach (string item in new List<string>(FcyivYKfpDdWyGkqLAlfXrDVByow.Keys))
				{
					FcyivYKfpDdWyGkqLAlfXrDVByow[item] = null;
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
				destination.NcszPLxzMMcRmhBvdCHKLlSVQjiC = source.NcszPLxzMMcRmhBvdCHKLlSVQjiC;
				destination.LypYmIebREXwtSOyNMUXhJWLhnLM = source.LypYmIebREXwtSOyNMUXhJWLhnLM;
				destination.FfoVexhUQNkgNkPbYFpcdrMGbXqmA = source.FfoVexhUQNkgNkPbYFpcdrMGbXqmA;
				destination.crwJiwJjUjcBHbvFSphLGVtbpptjA = source.crwJiwJjUjcBHbvFSphLGVtbpptjA;
				destination.TmLREZAbKnmVXGcpAvGoGAPtSUaw = source.TmLREZAbKnmVXGcpAvGoGAPtSUaw;
				destination.lzfdhCkohgRQtgDBzuhFQuFHRaFcb = source.lzfdhCkohgRQtgDBzuhFQuFHRaFcb;
				destination.lppljsocjnVqQakbnVkCnprNvtIe = source.lppljsocjnVqQakbnVkCnprNvtIe;
				destination.fmzhLTaqeFlwNyOcgXRiPirvGofr = source.fmzhLTaqeFlwNyOcgXRiPirvGofr;
				destination.rmjyHDnTotVheopmXQhYPxeiardo = ArrayTools.ShallowCopy(source.rmjyHDnTotVheopmXQhYPxeiardo);
				destination.XdhAaBgNfNdoQvhlkSBeuMYbAkpaA = source.XdhAaBgNfNdoQvhlkSBeuMYbAkpaA;
				destination.SHNCLCHRifBYuAqAAoJiVutIWepeb = source.SHNCLCHRifBYuAqAAoJiVutIWepeb;
				destination.iCZjpeaIVanOpdxIaBWemBNrlDUp = source.iCZjpeaIVanOpdxIaBWemBNrlDUp;
				destination.wIxzlFRiiOqrhQHWyKQBEzeUdvrV = source.wIxzlFRiiOqrhQHWyKQBEzeUdvrV;
				destination.zkTLEMuifgnAcFfoTduqOVMVhcFeA = source.zkTLEMuifgnAcFfoTduqOVMVhcFeA;
				destination.AbwHphdRFJotyIQOclIxtWDCLCtZ = source.AbwHphdRFJotyIQOclIxtWDCLCtZ;
				foreach (KeyValuePair<string, SafeDelegate> item in source.FcyivYKfpDdWyGkqLAlfXrDVByow)
				{
					destination.FcyivYKfpDdWyGkqLAlfXrDVByow[item.Key] = MiscTools.Clone(item.Value);
				}
			}
		}

		[Serializable]
		private sealed class HYxVqTFzEZsHqkvgDriUVPPVCRoh
		{
			public static readonly HYxVqTFzEZsHqkvgDriUVPPVCRoh _003C_003E9 = new HYxVqTFzEZsHqkvgDriUVPPVCRoh();

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void GFICSHfXwdXRhVlQjpNWrGTJmZBg(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
			}

			internal void tHbInSZoglQXVznjsChcVnXmZDKd(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
			}

			internal void NtZqqoqLBDcCOihjNeESGhNdmpsmA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
			}

			internal void CvWbXpXIDockZclaBZEvWJeYqRKC(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
			}

			internal void DOlgnUqihXwCbbHDcjteTquXipQB(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
			}

			internal void AcISgOIAJVXGgEqSqeDdQzvcMYUN(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
			}

			internal void BYXwVPLWKdPCIxrIwfAGKJcEcPff(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
			}
		}

		private static InputMapper bPGhEsCmNTbAPJBiQCMCWwkESCog;

		private static int QNIaCncYjQEaJUXLuulPVkBZXMlx;

		private readonly int vdcIytEzXWnlFkMZVAPVOlZXoeusA;

		private readonly bool bUNMlOxMvahtnxWkITpuokDlDYoo;

		private readonly ZvDhRYMRDsjbFHQHwDxDbYSTMUTD dsrcrhWGJkXDSwKxoEKoQHAQzuyS;

		private Options gWFkjNQjMYNHGCUHgmjPDBquGmEq;

		private readonly Dictionary<iDoQDHIiwETMbCJizSppYbHEesMc, SafeDelegate> ZJHOjdYCFtQdnCcqeMUMPtxtyudC = new Dictionary<iDoQDHIiwETMbCJizSppYbHEesMc, SafeDelegate>
		{
			{
				iDoQDHIiwETMbCJizSppYbHEesMc.InputMapped,
				new SafeAction<InputMappedEventData>(HYxVqTFzEZsHqkvgDriUVPPVCRoh._003C_003E9.GFICSHfXwdXRhVlQjpNWrGTJmZBg)
			},
			{
				iDoQDHIiwETMbCJizSppYbHEesMc.Error,
				new SafeAction<ErrorEventData>(HYxVqTFzEZsHqkvgDriUVPPVCRoh._003C_003E9.tHbInSZoglQXVznjsChcVnXmZDKd)
			},
			{
				iDoQDHIiwETMbCJizSppYbHEesMc.Canceled,
				new SafeAction<CanceledEventData>(HYxVqTFzEZsHqkvgDriUVPPVCRoh._003C_003E9.NtZqqoqLBDcCOihjNeESGhNdmpsmA)
			},
			{
				iDoQDHIiwETMbCJizSppYbHEesMc.TimedOut,
				new SafeAction<TimedOutEventData>(HYxVqTFzEZsHqkvgDriUVPPVCRoh._003C_003E9.CvWbXpXIDockZclaBZEvWJeYqRKC)
			},
			{
				iDoQDHIiwETMbCJizSppYbHEesMc.Started,
				new SafeAction<StartedEventData>(HYxVqTFzEZsHqkvgDriUVPPVCRoh._003C_003E9.DOlgnUqihXwCbbHDcjteTquXipQB)
			},
			{
				iDoQDHIiwETMbCJizSppYbHEesMc.Stopped,
				new SafeAction<StoppedEventData>(HYxVqTFzEZsHqkvgDriUVPPVCRoh._003C_003E9.AcISgOIAJVXGgEqSqeDdQzvcMYUN)
			},
			{
				iDoQDHIiwETMbCJizSppYbHEesMc.ConflictsFound,
				new SafeAction<ConflictFoundEventData>(HYxVqTFzEZsHqkvgDriUVPPVCRoh._003C_003E9.BYXwVPLWKdPCIxrIwfAGKJcEcPff)
			}
		};

		public static InputMapper Default => bPGhEsCmNTbAPJBiQCMCWwkESCog ?? (bPGhEsCmNTbAPJBiQCMCWwkESCog = new InputMapper(true));

		public Options options
		{
			get
			{
				Options obj = gWFkjNQjMYNHGCUHgmjPDBquGmEq;
				if (obj == null)
				{
					if (!bUNMlOxMvahtnxWkITpuokDlDYoo)
					{
						return gWFkjNQjMYNHGCUHgmjPDBquGmEq = Default.options.Clone();
					}
					obj = (gWFkjNQjMYNHGCUHgmjPDBquGmEq = new Options());
				}
				return obj;
			}
			set
			{
				gWFkjNQjMYNHGCUHgmjPDBquGmEq = value;
			}
		}

		public Context mappingContext => dsrcrhWGJkXDSwKxoEKoQHAQzuyS.nMdsvGVoiFsvlDBhLobjLROepJIM;

		public Status status => dsrcrhWGJkXDSwKxoEKoQHAQzuyS.zrBcGbaLGxobtIkzgrnbFBqUkYqH;

		public float timeRemaining => dsrcrhWGJkXDSwKxoEKoQHAQzuyS.mIpClqFXZidSkqvJhszTGmWiVIchA;

		internal int ZamYCQxLHAGKChjEHxjlKOSnIhez => vdcIytEzXWnlFkMZVAPVOlZXoeusA;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.InputMapped;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<InputMappedEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.InputMapped;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<InputMappedEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.Error;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<ErrorEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.Error;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<ErrorEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.Canceled;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<CanceledEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.Canceled;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<CanceledEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.TimedOut;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<TimedOutEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.TimedOut;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<TimedOutEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.Started;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<StartedEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.Started;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<StartedEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.Stopped;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<StoppedEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.Stopped;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<StoppedEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.ConflictsFound;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<ConflictFoundEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					iDoQDHIiwETMbCJizSppYbHEesMc key = iDoQDHIiwETMbCJizSppYbHEesMc.ConflictsFound;
					ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] = (SafeAction<ConflictFoundEventData>)ZJHOjdYCFtQdnCcqeMUMPtxtyudC[key] - value;
				}
			}
		}

		private static int GisbZxebqMwJbVAbJbTxoWiMyJEz()
		{
			int qNIaCncYjQEaJUXLuulPVkBZXMlx = QNIaCncYjQEaJUXLuulPVkBZXMlx;
			if (QNIaCncYjQEaJUXLuulPVkBZXMlx == int.MaxValue)
			{
				QNIaCncYjQEaJUXLuulPVkBZXMlx = 0;
				return qNIaCncYjQEaJUXLuulPVkBZXMlx;
			}
			QNIaCncYjQEaJUXLuulPVkBZXMlx++;
			return qNIaCncYjQEaJUXLuulPVkBZXMlx;
		}

		public InputMapper()
			: this(false)
		{
			vdcIytEzXWnlFkMZVAPVOlZXoeusA = GisbZxebqMwJbVAbJbTxoWiMyJEz();
		}

		private InputMapper(bool P_0)
		{
			bUNMlOxMvahtnxWkITpuokDlDYoo = P_0;
			if (bUNMlOxMvahtnxWkITpuokDlDYoo)
			{
				gWFkjNQjMYNHGCUHgmjPDBquGmEq = new Options();
			}
			dsrcrhWGJkXDSwKxoEKoQHAQzuyS = new ZvDhRYMRDsjbFHQHwDxDbYSTMUTD(this, ZJHOjdYCFtQdnCcqeMUMPtxtyudC);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<iDoQDHIiwETMbCJizSppYbHEesMc, SafeDelegate> item in ZJHOjdYCFtQdnCcqeMUMPtxtyudC)
			{
				item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<iDoQDHIiwETMbCJizSppYbHEesMc, SafeDelegate> item in ZJHOjdYCFtQdnCcqeMUMPtxtyudC)
			{
				item.Value.Clear();
			}
		}

		internal void DJDMIYAXIBXSkNSQNYTsdiMsYWAE(object P_0)
		{
		}

		internal void nBgCjbgvnncYTsqOqfXuEHgcnYRFb()
		{
		}

		public bool Start(Context mappingContext)
		{
			return rIjUCmsjifmvcBNTbhJRFVmmqsqk(mappingContext, (gWFkjNQjMYNHGCUHgmjPDBquGmEq != null) ? gWFkjNQjMYNHGCUHgmjPDBquGmEq : Default.options);
		}

		public void Stop()
		{
			dsrcrhWGJkXDSwKxoEKoQHAQzuyS.rIDxlGQcqdKUvtFpkiSHtGvVApWC("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			nBgCjbgvnncYTsqOqfXuEHgcnYRFb();
			gWFkjNQjMYNHGCUHgmjPDBquGmEq = null;
		}

		private bool rIjUCmsjifmvcBNTbhJRFVmmqsqk(Context P_0, Options P_1)
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
				dsrcrhWGJkXDSwKxoEKoQHAQzuyS.rIjUCmsjifmvcBNTbhJRFVmmqsqk(P_0, P_1);
				return true;
			}
			catch
			{
				dsrcrhWGJkXDSwKxoEKoQHAQzuyS.rIDxlGQcqdKUvtFpkiSHtGvVApWC("Failed to start due to an exception.");
				return false;
			}
		}
	}
}
