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
			private int nqrNxyIjKJnAagqUPKmjCYvwkyMr = -1;

			private ControllerMap KQrkQkAkhknsIKIpiSyrmaMcHTQc;

			private ActionElementMap zdjUKsFGNDunnvoQlUFMbrGeIkeg;

			private AxisRange NeIAzKHKfyQvROIoaLnRGCEmArdab = AxisRange.Positive;

			private bool rCxpMQVgnbHMXbPnzbIJKnLAsxtgA;

			public int actionId
			{
				get
				{
					return nqrNxyIjKJnAagqUPKmjCYvwkyMr;
				}
				set
				{
					if (!jHgdLFzMmLjYvBcEPnGErfbqaMhjA())
					{
						nqrNxyIjKJnAagqUPKmjCYvwkyMr = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(nqrNxyIjKJnAagqUPKmjCYvwkyMr);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!jHgdLFzMmLjYvBcEPnGErfbqaMhjA())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							nqrNxyIjKJnAagqUPKmjCYvwkyMr = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							nqrNxyIjKJnAagqUPKmjCYvwkyMr = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return KQrkQkAkhknsIKIpiSyrmaMcHTQc;
				}
				set
				{
					if (!jHgdLFzMmLjYvBcEPnGErfbqaMhjA())
					{
						KQrkQkAkhknsIKIpiSyrmaMcHTQc = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return zdjUKsFGNDunnvoQlUFMbrGeIkeg;
				}
				set
				{
					if (!jHgdLFzMmLjYvBcEPnGErfbqaMhjA())
					{
						zdjUKsFGNDunnvoQlUFMbrGeIkeg = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return NeIAzKHKfyQvROIoaLnRGCEmArdab;
				}
				set
				{
					if (!jHgdLFzMmLjYvBcEPnGErfbqaMhjA())
					{
						NeIAzKHKfyQvROIoaLnRGCEmArdab = value;
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

			internal void uhLedAjVNVYAXfGcIiKHDptbdCciB()
			{
				rCxpMQVgnbHMXbPnzbIJKnLAsxtgA = true;
			}

			private bool jHgdLFzMmLjYvBcEPnGErfbqaMhjA()
			{
				if (rCxpMQVgnbHMXbPnzbIJKnLAsxtgA)
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
				destination.nqrNxyIjKJnAagqUPKmjCYvwkyMr = source.nqrNxyIjKJnAagqUPKmjCYvwkyMr;
				destination.KQrkQkAkhknsIKIpiSyrmaMcHTQc = source.KQrkQkAkhknsIKIpiSyrmaMcHTQc;
				destination.zdjUKsFGNDunnvoQlUFMbrGeIkeg = source.zdjUKsFGNDunnvoQlUFMbrGeIkeg;
				destination.NeIAzKHKfyQvROIoaLnRGCEmArdab = source.NeIAzKHKfyQvROIoaLnRGCEmArdab;
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

			private readonly Func<int, bool> HOePLUADKZmoeEXwUPxQunrtTMxM;

			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				if (HOePLUADKZmoeEXwUPxQunrtTMxM == null)
				{
					return false;
				}
				return HOePLUADKZmoeEXwUPxQunrtTMxM(maxInputFieldCount);
			}

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
				: base(P_0)
			{
				responseCallback = P_1;
				assignment = P_2;
				conflicts = P_3;
				isProtected = P_4;
				HOePLUADKZmoeEXwUPxQunrtTMxM = P_5;
			}
		}

		private enum VJTGTSokKuRocfWrAOiDPkEXhawM
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

		private class qEPnmRoPleZEbuJgPHpjBedULWBpA
		{
			private enum tLheQzgCFArAxRCaqDyLqZIsJxXdA
			{
				Quit = 0,
				Continue = 1
			}

			private enum THpkRNZuZbPCCrBDVvSlyluVhDFB
			{
				None = 0,
				ConflictChecking = 1
			}

			private class ThYAmJCsRrmqHqBQNBQrYFtFdEPFA
			{
				private Player lCfiWScnnnTbiyJkGiQrjCovDBxDb;

				private int nqrNxyIjKJnAagqUPKmjCYvwkyMr;

				private Context sLmAcWHjdqLhFNWjUuvdEMKevuIn;

				private ControllerType ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

				private int iaZAeHIptgfYnzhUoKmpmEkRtvpO;

				private ControllerPollingInfo asuAsTeDUNrcplOCyonrNuWzpgun;

				private ModifierKeyFlags LAWskThCRZDFawlWQqsxyYTLFVmX;

				public Player tYEyiSjpdwwbqdDLYhlcYJwwGWGV => lCfiWScnnnTbiyJkGiQrjCovDBxDb;

				public int BOmXoDplzfnHtyBjNJvkkPzUlWST => nqrNxyIjKJnAagqUPKmjCYvwkyMr;

				public Context HVchLFCJUSPzJAaEcYundsBrGUKMB => sLmAcWHjdqLhFNWjUuvdEMKevuIn;

				public ControllerType JZuBcglRGrLdTTkjRHBAWiKZgoVK => ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

				public int JMclHNzguIWZrgtWkveVPuuQQUBf => iaZAeHIptgfYnzhUoKmpmEkRtvpO;

				public ControllerPollingInfo AHSSUtPqcvqJNROVsCBCzMxzgtXCA => asuAsTeDUNrcplOCyonrNuWzpgun;

				public ModifierKeyFlags MDurbBArcFHwCWLdUdmBjIWvCLaCb => LAWskThCRZDFawlWQqsxyYTLFVmX;

				public AxisRange FEoZycLNoSqbclpCafPqBZPZZDeCA
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (AHSSUtPqcvqJNROVsCBCzMxzgtXCA.elementType == ControllerElementType.Axis)
						{
							result = ((sLmAcWHjdqLhFNWjUuvdEMKevuIn.actionRange != AxisRange.Full) ? ((AHSSUtPqcvqJNROVsCBCzMxzgtXCA.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
						}
						return result;
					}
				}

				public string NHLjLkPeTJXtABbXDyKbLagJXWmg
				{
					get
					{
						if (JZuBcglRGrLdTTkjRHBAWiKZgoVK == ControllerType.Keyboard && MDurbBArcFHwCWLdUdmBjIWvCLaCb != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(MDurbBArcFHwCWLdUdmBjIWvCLaCb)} + {AHSSUtPqcvqJNROVsCBCzMxzgtXCA.elementIdentifierName}";
						}
						string text = AHSSUtPqcvqJNROVsCBCzMxzgtXCA.elementIdentifierName;
						if (AHSSUtPqcvqJNROVsCBCzMxzgtXCA.elementType == ControllerElementType.Axis)
						{
							if (FEoZycLNoSqbclpCafPqBZPZZDeCA == AxisRange.Positive)
							{
								text += " +";
							}
							else if (FEoZycLNoSqbclpCafPqBZPZZDeCA == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				public void TlzckGoQDITHcUYaslQXPQBOhTwq(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					wJjPIIRJfHhEbGedUconecGfiwzgB();
					lCfiWScnnnTbiyJkGiQrjCovDBxDb = P_0;
					nqrNxyIjKJnAagqUPKmjCYvwkyMr = P_1.actionId;
					ueTsfWyPNTdEyAOjfZNcYrBGNSmq = P_1.controllerMap.controllerType;
					iaZAeHIptgfYnzhUoKmpmEkRtvpO = P_1.controllerMap.controllerId;
					sLmAcWHjdqLhFNWjUuvdEMKevuIn = P_1;
					ueTsfWyPNTdEyAOjfZNcYrBGNSmq = P_1.controllerMap.controllerType;
					iaZAeHIptgfYnzhUoKmpmEkRtvpO = P_1.controllerMap.controllerId;
					P_1.uhLedAjVNVYAXfGcIiKHDptbdCciB();
				}

				public void wJjPIIRJfHhEbGedUconecGfiwzgB()
				{
					lCfiWScnnnTbiyJkGiQrjCovDBxDb = null;
					nqrNxyIjKJnAagqUPKmjCYvwkyMr = -1;
					sLmAcWHjdqLhFNWjUuvdEMKevuIn = null;
					ueTsfWyPNTdEyAOjfZNcYrBGNSmq = ControllerType.Keyboard;
					iaZAeHIptgfYnzhUoKmpmEkRtvpO = -1;
					asuAsTeDUNrcplOCyonrNuWzpgun = default(ControllerPollingInfo);
					LAWskThCRZDFawlWQqsxyYTLFVmX = ModifierKeyFlags.None;
				}

				public ElementAssignment CTNQFGlPmTskREDVpCBZEDCGVRnMA(ControllerPollingInfo P_0)
				{
					asuAsTeDUNrcplOCyonrNuWzpgun = P_0;
					return CTNQFGlPmTskREDVpCBZEDCGVRnMA();
				}

				public ElementAssignment CTNQFGlPmTskREDVpCBZEDCGVRnMA(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					asuAsTeDUNrcplOCyonrNuWzpgun = P_0;
					LAWskThCRZDFawlWQqsxyYTLFVmX = P_1;
					return CTNQFGlPmTskREDVpCBZEDCGVRnMA();
				}

				public ElementAssignment CTNQFGlPmTskREDVpCBZEDCGVRnMA()
				{
					return new ElementAssignment(JZuBcglRGrLdTTkjRHBAWiKZgoVK, asuAsTeDUNrcplOCyonrNuWzpgun.elementType, asuAsTeDUNrcplOCyonrNuWzpgun.elementIdentifierId, FEoZycLNoSqbclpCafPqBZPZZDeCA, asuAsTeDUNrcplOCyonrNuWzpgun.keyboardKey, LAWskThCRZDFawlWQqsxyYTLFVmX, nqrNxyIjKJnAagqUPKmjCYvwkyMr, (sLmAcWHjdqLhFNWjUuvdEMKevuIn.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (sLmAcWHjdqLhFNWjUuvdEMKevuIn.actionElementMapToReplace != null) ? sLmAcWHjdqLhFNWjUuvdEMKevuIn.actionElementMapToReplace.id : (-1));
				}
			}

			private sealed class bdZHjrtCVdbhpFfiNwFzManJjWEF
			{
				public ActionElementMap AbGjhXZiBNwaTqzHHAhqutQOTkZw;

				internal bool FpuDpwGPFYSDUjzwhmLFuDDceaeVA(ElementAssignmentConflictInfo P_0)
				{
					return P_0.elementMapId == AbGjhXZiBNwaTqzHHAhqutQOTkZw.id;
				}
			}

			private sealed class fomGHJjVJsbXnmLnezWrAUEHwNyb
			{
				public qEPnmRoPleZEbuJgPHpjBedULWBpA zITtixdgVFWlEnpDnrTdnZsdTFkt;

				public ElementAssignmentInfo ILpQYmgDlBpdWjaGLSNevjiQhark;

				public IList<ElementAssignmentConflictInfo> eHLwZIcDiUaTJAiKbkRXxeAcidvs;

				public bool FnsZrChqqgLSESXlccyfHOHuEFOX;

				internal bool aOXFRXZYtRtCwHTMxXfPfPuHgJxB(int P_0)
				{
					return zITtixdgVFWlEnpDnrTdnZsdTFkt.iYuOyJnHLCpbHweihDVFeuBYXbBm(ILpQYmgDlBpdWjaGLSNevjiQhark, eHLwZIcDiUaTJAiKbkRXxeAcidvs, FnsZrChqqgLSESXlccyfHOHuEFOX, P_0);
				}
			}

			private readonly InputMapper WEvCOBjpQhIRpHaUkrxNLGKtAKdt;

			private readonly Options BTRQpUgGaOmyqnYvHEXtYXvdezIe = new Options();

			private readonly ThYAmJCsRrmqHqBQNBQrYFtFdEPFA lHOKPpuuaDqEBArWQRBIDmTqgVlm = new ThYAmJCsRrmqHqBQNBQrYFtFdEPFA();

			private readonly Dictionary<VJTGTSokKuRocfWrAOiDPkEXhawM, SafeDelegate> mtTDRmqMghxdPrvIRiigWHIkmclR;

			private readonly Dictionary<string, SafeDelegate> wlmBpHeaRPRhQkjUmcPFpWsEYqsqA;

			private Status nIZkYrSIzfDcLTAatFpXyLamMklj;

			private THpkRNZuZbPCCrBDVvSlyluVhDFB EZvzkQjCsfUooFbwspbcYVloIscr;

			private double ifXlCJHKGvCjZlWElkmbQXhEkKOw;

			private bool GWdpQhlUGSHBvANvimbfyNSPGAGb;

			private List<Player> SeskPFlcnLHplhYnCTdDiEOYbZft = new List<Player>();

			private readonly List<ControllerPollingInfo> vcdFVXhxoaQuNpokFAcJACcHvLMU = new List<ControllerPollingInfo>();

			private ElementAssignment KduPlymibcFLekPMWbqBpeHJpUOKA;

			public Status QATIbsEkzfPDVbMHBSDTYZNZIsaM => nIZkYrSIzfDcLTAatFpXyLamMklj;

			public float TLhiqzjVbqdzYUefSPWhdApvQOmF
			{
				get
				{
					if (nIZkYrSIzfDcLTAatFpXyLamMklj == Status.Idle)
					{
						return 0f;
					}
					if (BTRQpUgGaOmyqnYvHEXtYXvdezIe.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, ifXlCJHKGvCjZlWElkmbQXhEkKOw + (double)BTRQpUgGaOmyqnYvHEXtYXvdezIe.timeout - ReInput.unscaledTime);
				}
			}

			public Context SPtcBBnfEBKqFyFScRzNUjLpDwMC
			{
				get
				{
					if (nIZkYrSIzfDcLTAatFpXyLamMklj == Status.Idle)
					{
						return null;
					}
					return lHOKPpuuaDqEBArWQRBIDmTqgVlm.HVchLFCJUSPzJAaEcYundsBrGUKMB;
				}
			}

			private bool XLfcFUmHQdyeQmGxRyAbIAiNQQhJ
			{
				get
				{
					if (GWdpQhlUGSHBvANvimbfyNSPGAGb)
					{
						return false;
					}
					if (!(BTRQpUgGaOmyqnYvHEXtYXvdezIe.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public qEPnmRoPleZEbuJgPHpjBedULWBpA(InputMapper P_0, Dictionary<VJTGTSokKuRocfWrAOiDPkEXhawM, SafeDelegate> P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("events");
				}
				WEvCOBjpQhIRpHaUkrxNLGKtAKdt = P_0;
				mtTDRmqMghxdPrvIRiigWHIkmclR = P_1;
				VGCLZHztyTfZQiiaXRrQoHMhyexb();
			}

			protected virtual void ANNKHugeDGzbmYmFyhvbuPpYVvpn()
			{
				try
				{
					llOWmgqEFEeQiIWRFcOdOZOYtosdA();
				}
				finally
				{
					base.Finalize();
				}
			}

			public void YzxJYzIGUbUuQcUjIpyhOcHzsJaf(Context P_0, Options P_1)
			{
				if (nIZkYrSIzfDcLTAatFpXyLamMklj != Status.Idle)
				{
					WjSkOElJJTxpmZVykKGpQAcayhpt("User started a new listening session.");
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
				Options.Copy(P_1, BTRQpUgGaOmyqnYvHEXtYXvdezIe);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					EkYatPUHbeLikDTCSVUmYcjEpfC("No Action found for actionId: " + P_0.actionId);
					return;
				}
				lHOKPpuuaDqEBArWQRBIDmTqgVlm.TlzckGoQDITHcUYaslQXPQBOhTwq(player, P_0);
				nIZkYrSIzfDcLTAatFpXyLamMklj = Status.Listening;
				QkcdfUCeDkSBjJkhmOOCRminQTdg();
				rIDsHbxKGsiYlUUbrjlzzinqnWkA();
				JbGOzekJtuiSxtcZdfrKhjGTiIpyA();
				QpBsnQIMDQtTXqECqKAPKygpVFHJ();
			}

			public void GFVOuNwCKtSvZKjlBDSviRbIqASO(string P_0)
			{
				if (nIZkYrSIzfDcLTAatFpXyLamMklj != Status.Idle)
				{
					WjSkOElJJTxpmZVykKGpQAcayhpt(P_0);
				}
			}

			private void DsDuSUaDcVanpNAhDLIRqjKndMGi(UpdateLoopType P_0)
			{
				if (P_0 == UpdateLoopType.Update && nIZkYrSIzfDcLTAatFpXyLamMklj == Status.Listening)
				{
					ElementAssignment elementAssignment;
					if (XLfcFUmHQdyeQmGxRyAbIAiNQQhJ && TLhiqzjVbqdzYUefSPWhdApvQOmF <= 0f)
					{
						romErZspSPmhvtjXKcOjaSbobNLs();
					}
					else if (ReInput.controllers.GetController(lHOKPpuuaDqEBArWQRBIDmTqgVlm.JZuBcglRGrLdTTkjRHBAWiKZgoVK, lHOKPpuuaDqEBArWQRBIDmTqgVlm.JMclHNzguIWZrgtWkveVPuuQQUBf) == null)
					{
						EkYatPUHbeLikDTCSVUmYcjEpfC("Controller not found for type: " + lHOKPpuuaDqEBArWQRBIDmTqgVlm.JZuBcglRGrLdTTkjRHBAWiKZgoVK.ToString() + " id: " + lHOKPpuuaDqEBArWQRBIDmTqgVlm.JMclHNzguIWZrgtWkveVPuuQQUBf);
					}
					else if (mlybUvffWcGWQDFkkDAPuJHQgckNB(out elementAssignment) != tLheQzgCFArAxRCaqDyLqZIsJxXdA.Quit && tIWZiyaxmpHAmHrNmbRDMWGNqODX(elementAssignment) != tLheQzgCFArAxRCaqDyLqZIsJxXdA.Quit)
					{
						OpZXkUatjONXbugtkyEZqJXirTzK(elementAssignment);
					}
				}
			}

			private void JiWRycLAiMzKBxXtUYeevPxAIymj()
			{
				if (nIZkYrSIzfDcLTAatFpXyLamMklj != Status.Idle)
				{
					VGCLZHztyTfZQiiaXRrQoHMhyexb();
					llOWmgqEFEeQiIWRFcOdOZOYtosdA();
					JaRSLexIwuDBNGQrQaSyvLTXsIib();
				}
			}

			private void VGCLZHztyTfZQiiaXRrQoHMhyexb()
			{
				nIZkYrSIzfDcLTAatFpXyLamMklj = Status.Idle;
				ifXlCJHKGvCjZlWElkmbQXhEkKOw = 0.0;
				BTRQpUgGaOmyqnYvHEXtYXvdezIe.wJjPIIRJfHhEbGedUconecGfiwzgB();
				lHOKPpuuaDqEBArWQRBIDmTqgVlm.wJjPIIRJfHhEbGedUconecGfiwzgB();
				KduPlymibcFLekPMWbqBpeHJpUOKA = default(ElementAssignment);
				EZvzkQjCsfUooFbwspbcYVloIscr = THpkRNZuZbPCCrBDVvSlyluVhDFB.None;
				GWdpQhlUGSHBvANvimbfyNSPGAGb = false;
				SeskPFlcnLHplhYnCTdDiEOYbZft.Clear();
			}

			private tLheQzgCFArAxRCaqDyLqZIsJxXdA mlybUvffWcGWQDFkkDAPuJHQgckNB(out ElementAssignment P_0)
			{
				if (!oezjqBvTbQMPcfruAxQuyPuyFJtA(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Quit;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !QForCemFrXmVlwsHqbstnajIemnZ(item, BTRQpUgGaOmyqnYvHEXtYXvdezIe))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Quit;
				}
				if (!RMfXhspUAriPonACKaSnRPETpfOo(lHOKPpuuaDqEBArWQRBIDmTqgVlm, controllerPollingInfo, BTRQpUgGaOmyqnYvHEXtYXvdezIe))
				{
					P_0 = default(ElementAssignment);
					return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Quit;
				}
				P_0 = lHOKPpuuaDqEBArWQRBIDmTqgVlm.CTNQFGlPmTskREDVpCBZEDCGVRnMA(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Continue;
			}

			private bool oezjqBvTbQMPcfruAxQuyPuyFJtA(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = lHOKPpuuaDqEBArWQRBIDmTqgVlm.JZuBcglRGrLdTTkjRHBAWiKZgoVK;
				int controllerId = lHOKPpuuaDqEBArWQRBIDmTqgVlm.JMclHNzguIWZrgtWkveVPuuQQUBf;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = xBHgCOYJbQfxfhKZZuWJJpbRsmBOA(out P_1);
					return true;
				}
				if (BTRQpUgGaOmyqnYvHEXtYXvdezIe.allowAxes)
				{
					if (BTRQpUgGaOmyqnYvHEXtYXvdezIe.allowButtons)
					{
						if (lHOKPpuuaDqEBArWQRBIDmTqgVlm.tYEyiSjpdwwbqdDLYhlcYJwwGWGV != null)
						{
							P_0 = lHOKPpuuaDqEBArWQRBIDmTqgVlm.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(lHOKPpuuaDqEBArWQRBIDmTqgVlm.JZuBcglRGrLdTTkjRHBAWiKZgoVK, lHOKPpuuaDqEBArWQRBIDmTqgVlm.JMclHNzguIWZrgtWkveVPuuQQUBf);
						}
					}
					else if (lHOKPpuuaDqEBArWQRBIDmTqgVlm.tYEyiSjpdwwbqdDLYhlcYJwwGWGV != null)
					{
						P_0 = lHOKPpuuaDqEBArWQRBIDmTqgVlm.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!BTRQpUgGaOmyqnYvHEXtYXvdezIe.allowButtons)
					{
						EkYatPUHbeLikDTCSVUmYcjEpfC("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (lHOKPpuuaDqEBArWQRBIDmTqgVlm.tYEyiSjpdwwbqdDLYhlcYJwwGWGV != null)
					{
						P_0 = lHOKPpuuaDqEBArWQRBIDmTqgVlm.tYEyiSjpdwwbqdDLYhlcYJwwGWGV.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> xBHgCOYJbQfxfhKZZuWJJpbRsmBOA(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				vcdFVXhxoaQuNpokFAcJACcHvLMU.Clear();
				if (!BTRQpUgGaOmyqnYvHEXtYXvdezIe.allowButtons)
				{
					return vcdFVXhxoaQuNpokFAcJACcHvLMU;
				}
				vcdFVXhxoaQuNpokFAcJACcHvLMU.Add(DuzzxKYCRVGhIgESHBxjmUAGiSfgb(BTRQpUgGaOmyqnYvHEXtYXvdezIe, out P_0));
				return vcdFVXhxoaQuNpokFAcJACcHvLMU;
			}

			private ControllerPollingInfo DuzzxKYCRVGhIgESHBxjmUAGiSfgb(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = DuzzxKYCRVGhIgESHBxjmUAGiSfgb(P_0, out flag, out P_1, out text);
				if (flag)
				{
					QkcdfUCeDkSBjJkhmOOCRminQTdg();
				}
				return result;
			}

			private static ControllerPollingInfo DuzzxKYCRVGhIgESHBxjmUAGiSfgb(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
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

			private static bool QForCemFrXmVlwsHqbstnajIemnZ(ControllerPollingInfo P_0, Options P_1)
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
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.iQkTeamLEtgJhbJnpuLUknQPbJLHA<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool RMfXhspUAriPonACKaSnRPETpfOo(ThYAmJCsRrmqHqBQNBQrYFtFdEPFA P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.FEoZycLNoSqbclpCafPqBZPZZDeCA == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void rIDsHbxKGsiYlUUbrjlzzinqnWkA()
			{
				if (!BTRQpUgGaOmyqnYvHEXtYXvdezIe.checkForConflicts)
				{
					return;
				}
				if (BTRQpUgGaOmyqnYvHEXtYXvdezIe.checkForConflictsWithSelf && lHOKPpuuaDqEBArWQRBIDmTqgVlm.tYEyiSjpdwwbqdDLYhlcYJwwGWGV != null)
				{
					ListTools.AddIfUnique(SeskPFlcnLHplhYnCTdDiEOYbZft, lHOKPpuuaDqEBArWQRBIDmTqgVlm.tYEyiSjpdwwbqdDLYhlcYJwwGWGV);
				}
				if (BTRQpUgGaOmyqnYvHEXtYXvdezIe.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(SeskPFlcnLHplhYnCTdDiEOYbZft, ReInput.players.SystemPlayer);
				}
				if (BTRQpUgGaOmyqnYvHEXtYXvdezIe.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(SeskPFlcnLHplhYnCTdDiEOYbZft, players[i]);
					}
				}
				else
				{
					if (BTRQpUgGaOmyqnYvHEXtYXvdezIe.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(BTRQpUgGaOmyqnYvHEXtYXvdezIe.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(SeskPFlcnLHplhYnCTdDiEOYbZft, allPlayers[j]);
						}
					}
				}
			}

			private tLheQzgCFArAxRCaqDyLqZIsJxXdA tIWZiyaxmpHAmHrNmbRDMWGNqODX(ElementAssignment P_0)
			{
				if (BTRQpUgGaOmyqnYvHEXtYXvdezIe.checkForConflicts && lHOKPpuuaDqEBArWQRBIDmTqgVlm.tYEyiSjpdwwbqdDLYhlcYJwwGWGV != null && PMWHsTcmjXwuaydjtYlhoSCcNsbD(lHOKPpuuaDqEBArWQRBIDmTqgVlm, P_0, SeskPFlcnLHplhYnCTdDiEOYbZft))
				{
					return xAMWuswkclUXkelOoeBNYEpjMvlG(P_0);
				}
				return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Continue;
			}

			private static bool PMWHsTcmjXwuaydjtYlhoSCcNsbD(ThYAmJCsRrmqHqBQNBQrYFtFdEPFA P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.tYEyiSjpdwwbqdDLYhlcYJwwGWGV == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!dDPBxHxVGSwBEBbirFapSrUcmsSK(P_0, P_1, out var conflictCheck))
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

			private static bool jFMxhzQMVmJoTmBIKJlQATlOQkLJ(ThYAmJCsRrmqHqBQNBQrYFtFdEPFA P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.tYEyiSjpdwwbqdDLYhlcYJwwGWGV == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!dDPBxHxVGSwBEBbirFapSrUcmsSK(P_0, P_1, out var conflictCheck))
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

			private static IList<ElementAssignmentConflictInfo> AwEstMyJpLDhqKjkHllqIfoskOddA(ThYAmJCsRrmqHqBQNBQrYFtFdEPFA P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.tYEyiSjpdwwbqdDLYhlcYJwwGWGV == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!dDPBxHxVGSwBEBbirFapSrUcmsSK(P_0, P_1, out var conflictCheck))
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

			private static bool dDPBxHxVGSwBEBbirFapSrUcmsSK(ThYAmJCsRrmqHqBQNBQrYFtFdEPFA P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				if (P_0 == null || (player = P_0.tYEyiSjpdwwbqdDLYhlcYJwwGWGV) == null)
				{
					P_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				P_2 = P_1.ToElementAssignmentConflictCheck();
				P_2.playerId = player.id;
				P_2.controllerType = P_0.JZuBcglRGrLdTTkjRHBAWiKZgoVK;
				P_2.controllerId = P_0.JMclHNzguIWZrgtWkveVPuuQQUBf;
				P_2.controllerMapId = P_0.HVchLFCJUSPzJAaEcYundsBrGUKMB.controllerMap.id;
				P_2.controllerMapCategoryId = P_0.HVchLFCJUSPzJAaEcYundsBrGUKMB.controllerMap.categoryId;
				if (P_0.HVchLFCJUSPzJAaEcYundsBrGUKMB.actionElementMapToReplace != null)
				{
					P_2.elementMapId = P_0.HVchLFCJUSPzJAaEcYundsBrGUKMB.actionElementMapToReplace.id;
				}
				return true;
			}

			private static void JcUkdgPilwHQsSqwqaXrFlDURYiS(ThYAmJCsRrmqHqBQNBQrYFtFdEPFA P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.tYEyiSjpdwwbqdDLYhlcYJwwGWGV == null)
				{
					return;
				}
				if (!dDPBxHxVGSwBEBbirFapSrUcmsSK(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void JbGOzekJtuiSxtcZdfrKhjGTiIpyA()
			{
				ReInput.UpdateEndedEvent -= DsDuSUaDcVanpNAhDLIRqjKndMGi;
				ReInput.UpdateEndedEvent += DsDuSUaDcVanpNAhDLIRqjKndMGi;
			}

			private void llOWmgqEFEeQiIWRFcOdOZOYtosdA()
			{
				ReInput.UpdateEndedEvent -= DsDuSUaDcVanpNAhDLIRqjKndMGi;
			}

			private bool MBKGKrbsCUXHmHiLqzlmYtqdiOlR(VJTGTSokKuRocfWrAOiDPkEXhawM P_0)
			{
				SafeDelegate safeDelegate = mtTDRmqMghxdPrvIRiigWHIkmclR[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void lTQeVEivrQWYZMxZmPcKRTAhhWks<_0001>(VJTGTSokKuRocfWrAOiDPkEXhawM P_0, _0001 P_1)
			{
				SafeAction<_0001> safeAction = (SafeAction<_0001>)mtTDRmqMghxdPrvIRiigWHIkmclR[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void QkcdfUCeDkSBjJkhmOOCRminQTdg()
			{
				ifXlCJHKGvCjZlWElkmbQXhEkKOw = ReInput.unscaledTime;
			}

			private void UevMQUIrbZwAhNhwQkNEWOGpbgSf()
			{
				GWdpQhlUGSHBvANvimbfyNSPGAGb = true;
			}

			private bool iYuOyJnHLCpbHweihDVFeuBYXbBm(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
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
					if (IxxdfRahrYHQMghHianAOrNRgIvVA(elementType, axisRange, axisContribution, controller.GetElementById(P_0.elementIdentifier.id).type, P_0.axisRange, P_0.axisContribution))
					{
						num++;
					}
				}
				using (IEnumerator<ActionElementMap> enumerator = elementAssignmentConflictInfo.controllerMap.ElementMapsWithAction(actionId).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						bdZHjrtCVdbhpFfiNwFzManJjWEF bdZHjrtCVdbhpFfiNwFzManJjWEF2 = new bdZHjrtCVdbhpFfiNwFzManJjWEF();
						bdZHjrtCVdbhpFfiNwFzManJjWEF2.AbGjhXZiBNwaTqzHHAhqutQOTkZw = enumerator.Current;
						if (bdZHjrtCVdbhpFfiNwFzManJjWEF2.AbGjhXZiBNwaTqzHHAhqutQOTkZw.id != elementMap.id && ListTools.FindIndex(list, bdZHjrtCVdbhpFfiNwFzManJjWEF2.FpuDpwGPFYSDUjzwhmLFuDDceaeVA) < 0 && IxxdfRahrYHQMghHianAOrNRgIvVA(elementType, axisRange, axisContribution, bdZHjrtCVdbhpFfiNwFzManJjWEF2.AbGjhXZiBNwaTqzHHAhqutQOTkZw.elementType, bdZHjrtCVdbhpFfiNwFzManJjWEF2.AbGjhXZiBNwaTqzHHAhqutQOTkZw.axisRange, bdZHjrtCVdbhpFfiNwFzManJjWEF2.AbGjhXZiBNwaTqzHHAhqutQOTkZw.axisContribution))
						{
							num++;
						}
					}
				}
				return num < P_3;
			}

			private bool MoIfXdBpOdcTKXoaYdapiYmBNoBO(ThYAmJCsRrmqHqBQNBQrYFtFdEPFA P_0, ElementAssignment P_1, bool P_2, out string P_3)
			{
				if (P_0 == null)
				{
					P_3 = "Mapping is null reference.";
					return false;
				}
				List<Player> list = new List<Player> { P_0.tYEyiSjpdwwbqdDLYhlcYJwwGWGV };
				IList<ElementAssignmentConflictInfo> list2 = AwEstMyJpLDhqKjkHllqIfoskOddA(P_0, P_1, list);
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
				if (P_0.HVchLFCJUSPzJAaEcYundsBrGUKMB.actionElementMapToReplace == null)
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
				ActionElementMap actionElementMap2 = new ActionElementMap(P_0.HVchLFCJUSPzJAaEcYundsBrGUKMB.actionElementMapToReplace);
				JcUkdgPilwHQsSqwqaXrFlDURYiS(P_0, P_1, list);
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
				elementAssignmentConflictInfo.controllerMap.ReplaceOrCreateElementMap(ElementAssignment.CompleteAssignment(P_0.JZuBcglRGrLdTTkjRHBAWiKZgoVK, elementType, elementIdentifierId, axisRange, keyCode, modifierKeyFlags, actionId, axisContribution, invert));
				P_3 = null;
				return true;
			}

			private static bool IxxdfRahrYHQMghHianAOrNRgIvVA(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
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

			private void JdEbqgeyMEuvOERqueMkxjgblPBcA(ActionElementMap P_0)
			{
				bIiVFktnzTFkZCfLumJoFaZBUaykb(P_0);
				JiWRycLAiMzKBxXtUYeevPxAIymj();
			}

			private void WjSkOElJJTxpmZVykKGpQAcayhpt(string P_0)
			{
				crfxnWKksCDSDUZPfnsgVUEGOFJL(P_0);
				JiWRycLAiMzKBxXtUYeevPxAIymj();
			}

			private tLheQzgCFArAxRCaqDyLqZIsJxXdA xAMWuswkclUXkelOoeBNYEpjMvlG(ElementAssignment P_0)
			{
				if (MBKGKrbsCUXHmHiLqzlmYtqdiOlR(VJTGTSokKuRocfWrAOiDPkEXhawM.ConflictsFound))
				{
					bool flag = jFMxhzQMVmJoTmBIKJlQATlOQkLJ(lHOKPpuuaDqEBArWQRBIDmTqgVlm, P_0, SeskPFlcnLHplhYnCTdDiEOYbZft);
					KduPlymibcFLekPMWbqBpeHJpUOKA = P_0;
					IList<ElementAssignmentConflictInfo> list = AwEstMyJpLDhqKjkHllqIfoskOddA(lHOKPpuuaDqEBArWQRBIDmTqgVlm, P_0, SeskPFlcnLHplhYnCTdDiEOYbZft);
					EZvzkQjCsfUooFbwspbcYVloIscr = THpkRNZuZbPCCrBDVvSlyluVhDFB.ConflictChecking;
					PwjqqPBdLEBtThhgrUPeKgYTHshG();
					cMatvmdcmpupJIDcgKQYBalLzyIn(new ElementAssignmentInfo(lHOKPpuuaDqEBArWQRBIDmTqgVlm.HVchLFCJUSPzJAaEcYundsBrGUKMB.controllerMap, P_0), list, flag);
					return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Quit;
				}
				return VBWypGvrWrTfxoWVOpePYbzjDAQd(BTRQpUgGaOmyqnYvHEXtYXvdezIe.defaultActionWhenConflictFound, P_0);
			}

			private tLheQzgCFArAxRCaqDyLqZIsJxXdA VBWypGvrWrTfxoWVOpePYbzjDAQd(ConflictResponse P_0, ElementAssignment P_1)
			{
				return VBWypGvrWrTfxoWVOpePYbzjDAQd(P_0, P_1, jFMxhzQMVmJoTmBIKJlQATlOQkLJ(lHOKPpuuaDqEBArWQRBIDmTqgVlm, P_1, SeskPFlcnLHplhYnCTdDiEOYbZft));
			}

			private tLheQzgCFArAxRCaqDyLqZIsJxXdA VBWypGvrWrTfxoWVOpePYbzjDAQd(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					WjSkOElJJTxpmZVykKGpQAcayhpt("Mapping assignment was canceled due to a conflict.");
					return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Quit;
				case ConflictResponse.Replace:
					if (P_2)
					{
						WjSkOElJJTxpmZVykKGpQAcayhpt("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Quit;
					}
					JcUkdgPilwHQsSqwqaXrFlDURYiS(lHOKPpuuaDqEBArWQRBIDmTqgVlm, P_1, SeskPFlcnLHplhYnCTdDiEOYbZft);
					return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Continue;
				case ConflictResponse.Add:
					return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Continue;
				case ConflictResponse.Ignore:
					AmLBMTIxHEdpHXEIhEKSkzmijJrY();
					return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Quit;
				case ConflictResponse.Swap:
				{
					if (!MoIfXdBpOdcTKXoaYdapiYmBNoBO(lHOKPpuuaDqEBArWQRBIDmTqgVlm, P_1, P_2, out var text))
					{
						WjSkOElJJTxpmZVykKGpQAcayhpt(text);
						return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Quit;
					}
					return tLheQzgCFArAxRCaqDyLqZIsJxXdA.Continue;
				}
				default:
					throw new NotImplementedException();
				}
			}

			private void romErZspSPmhvtjXKcOjaSbobNLs()
			{
				rHVlZTPszqLHwcZazQFwjdxZxrhJ();
				JiWRycLAiMzKBxXtUYeevPxAIymj();
			}

			private void EkYatPUHbeLikDTCSVUmYcjEpfC(string P_0)
			{
				SeVBkHjpHgQGLYBOccXoZveUVvLw(P_0);
				JiWRycLAiMzKBxXtUYeevPxAIymj();
			}

			private void PwjqqPBdLEBtThhgrUPeKgYTHshG()
			{
				UevMQUIrbZwAhNhwQkNEWOGpbgSf();
				llOWmgqEFEeQiIWRFcOdOZOYtosdA();
				nIZkYrSIzfDcLTAatFpXyLamMklj = Status.AwaitingResponse;
			}

			private void AmLBMTIxHEdpHXEIhEKSkzmijJrY()
			{
				nIZkYrSIzfDcLTAatFpXyLamMklj = Status.Listening;
				EZvzkQjCsfUooFbwspbcYVloIscr = THpkRNZuZbPCCrBDVvSlyluVhDFB.None;
				QkcdfUCeDkSBjJkhmOOCRminQTdg();
				JbGOzekJtuiSxtcZdfrKhjGTiIpyA();
			}

			private void OpZXkUatjONXbugtkyEZqJXirTzK(ElementAssignment P_0)
			{
				if (lHOKPpuuaDqEBArWQRBIDmTqgVlm.HVchLFCJUSPzJAaEcYundsBrGUKMB.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					JdEbqgeyMEuvOERqueMkxjgblPBcA(result);
				}
				else
				{
					EkYatPUHbeLikDTCSVUmYcjEpfC("Failed to create element assignment.");
				}
			}

			private void bIiVFktnzTFkZCfLumJoFaZBUaykb(ActionElementMap P_0)
			{
				if (MBKGKrbsCUXHmHiLqzlmYtqdiOlR(VJTGTSokKuRocfWrAOiDPkEXhawM.InputMapped))
				{
					lTQeVEivrQWYZMxZmPcKRTAhhWks(VJTGTSokKuRocfWrAOiDPkEXhawM.InputMapped, new InputMappedEventData(WEvCOBjpQhIRpHaUkrxNLGKtAKdt, P_0));
				}
			}

			private void rHVlZTPszqLHwcZazQFwjdxZxrhJ()
			{
				if (MBKGKrbsCUXHmHiLqzlmYtqdiOlR(VJTGTSokKuRocfWrAOiDPkEXhawM.TimedOut))
				{
					lTQeVEivrQWYZMxZmPcKRTAhhWks(VJTGTSokKuRocfWrAOiDPkEXhawM.TimedOut, new TimedOutEventData(WEvCOBjpQhIRpHaUkrxNLGKtAKdt));
				}
			}

			private void SeVBkHjpHgQGLYBOccXoZveUVvLw(string P_0)
			{
				if (MBKGKrbsCUXHmHiLqzlmYtqdiOlR(VJTGTSokKuRocfWrAOiDPkEXhawM.Error))
				{
					lTQeVEivrQWYZMxZmPcKRTAhhWks(VJTGTSokKuRocfWrAOiDPkEXhawM.Error, new ErrorEventData(WEvCOBjpQhIRpHaUkrxNLGKtAKdt, P_0));
				}
			}

			private void crfxnWKksCDSDUZPfnsgVUEGOFJL(string P_0)
			{
				if (MBKGKrbsCUXHmHiLqzlmYtqdiOlR(VJTGTSokKuRocfWrAOiDPkEXhawM.Canceled))
				{
					lTQeVEivrQWYZMxZmPcKRTAhhWks(VJTGTSokKuRocfWrAOiDPkEXhawM.Canceled, new CanceledEventData(WEvCOBjpQhIRpHaUkrxNLGKtAKdt, P_0));
				}
			}

			private void cMatvmdcmpupJIDcgKQYBalLzyIn(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				fomGHJjVJsbXnmLnezWrAUEHwNyb fomGHJjVJsbXnmLnezWrAUEHwNyb2 = new fomGHJjVJsbXnmLnezWrAUEHwNyb();
				fomGHJjVJsbXnmLnezWrAUEHwNyb2.zITtixdgVFWlEnpDnrTdnZsdTFkt = this;
				fomGHJjVJsbXnmLnezWrAUEHwNyb2.ILpQYmgDlBpdWjaGLSNevjiQhark = P_0;
				fomGHJjVJsbXnmLnezWrAUEHwNyb2.eHLwZIcDiUaTJAiKbkRXxeAcidvs = P_1;
				fomGHJjVJsbXnmLnezWrAUEHwNyb2.FnsZrChqqgLSESXlccyfHOHuEFOX = P_2;
				if (MBKGKrbsCUXHmHiLqzlmYtqdiOlR(VJTGTSokKuRocfWrAOiDPkEXhawM.ConflictsFound))
				{
					lTQeVEivrQWYZMxZmPcKRTAhhWks(VJTGTSokKuRocfWrAOiDPkEXhawM.ConflictsFound, new ConflictFoundEventData(WEvCOBjpQhIRpHaUkrxNLGKtAKdt, oztykTdLezjKezRczljyabXKcHJp, fomGHJjVJsbXnmLnezWrAUEHwNyb2.ILpQYmgDlBpdWjaGLSNevjiQhark, fomGHJjVJsbXnmLnezWrAUEHwNyb2.eHLwZIcDiUaTJAiKbkRXxeAcidvs, fomGHJjVJsbXnmLnezWrAUEHwNyb2.FnsZrChqqgLSESXlccyfHOHuEFOX, fomGHJjVJsbXnmLnezWrAUEHwNyb2.aOXFRXZYtRtCwHTMxXfPfPuHgJxB));
				}
			}

			private void QpBsnQIMDQtTXqECqKAPKygpVFHJ()
			{
				if (MBKGKrbsCUXHmHiLqzlmYtqdiOlR(VJTGTSokKuRocfWrAOiDPkEXhawM.Started))
				{
					lTQeVEivrQWYZMxZmPcKRTAhhWks(VJTGTSokKuRocfWrAOiDPkEXhawM.Started, new StartedEventData(WEvCOBjpQhIRpHaUkrxNLGKtAKdt));
				}
			}

			private void JaRSLexIwuDBNGQrQaSyvLTXsIib()
			{
				if (MBKGKrbsCUXHmHiLqzlmYtqdiOlR(VJTGTSokKuRocfWrAOiDPkEXhawM.Stopped))
				{
					lTQeVEivrQWYZMxZmPcKRTAhhWks(VJTGTSokKuRocfWrAOiDPkEXhawM.Stopped, new StoppedEventData(WEvCOBjpQhIRpHaUkrxNLGKtAKdt));
				}
			}

			public void oztykTdLezjKezRczljyabXKcHJp(ConflictResponse P_0)
			{
				if (nIZkYrSIzfDcLTAatFpXyLamMklj != Status.AwaitingResponse || EZvzkQjCsfUooFbwspbcYVloIscr != THpkRNZuZbPCCrBDVvSlyluVhDFB.ConflictChecking)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (VBWypGvrWrTfxoWVOpePYbzjDAQd(P_0, KduPlymibcFLekPMWbqBpeHJpUOKA) == tLheQzgCFArAxRCaqDyLqZIsJxXdA.Continue)
					{
						OpZXkUatjONXbugtkyEZqJXirTzK(KduPlymibcFLekPMWbqBpeHJpUOKA);
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
			private sealed class aYZCdVAgwncesheFRpJRchjCqGzbA
			{
				public static readonly aYZCdVAgwncesheFRpJRchjCqGzbA _003C_003E9 = new aYZCdVAgwncesheFRpJRchjCqGzbA();

				public static Action<Exception> _003C_003E9__64_0;

				internal void rfPGPbRhBwgyOhZudGcHCUddiAAfA(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
				}
			}

			private bool yYglqKZYHODXMCcpInikSUEMeUgu = true;

			private bool ybhnWDIrnUHaPlzOgoFziwhIhiBk = true;

			private bool wiyxdkDWcJJIpXpVpLtIuffNDYaj = true;

			private float JuibhSpugvypQMxnnThhIUhclfLB;

			private bool gPFVZMeyxlsatlDUpudQRsoaUeue = true;

			private bool KPtdiTKUVcnhTyqzIeZrdiuQgaBy = true;

			private bool YyhHsuMXErCuETZIGMjqsIIIrhYx = true;

			private bool OdwYEGCQNPHhIFGVbzMMIAqQmdGb = true;

			private int[] IPbWsCPmCxKrYTJEoTLyOHEfrIpg;

			private ConflictResponse sMfAlKCSLJQPmOSPZvrYpjrchkfDb = ConflictResponse.Replace;

			private bool llTYNZhZGvdNQTjgLxYYjfIPgUfJ;

			private bool RtHeKtYrTghOJOyTXupShaEoTbEg;

			private bool JZlyYOlSEEOsBjfmTmWvVkFBvqfJ = true;

			private bool KbHVhZQgZqnLYmNIuQKUTzxSuBXE = true;

			private float legdeqrJbFJSArtkBJeTJlqFaYbt = 1f;

			internal const string TEpYGkEcnAcZyJwsNpifLRxEhBYi = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> wlmBpHeaRPRhQkjUmcPFpWsEYqsqA = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			public bool allowAxes
			{
				get
				{
					return yYglqKZYHODXMCcpInikSUEMeUgu;
				}
				set
				{
					yYglqKZYHODXMCcpInikSUEMeUgu = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return ybhnWDIrnUHaPlzOgoFziwhIhiBk;
				}
				set
				{
					ybhnWDIrnUHaPlzOgoFziwhIhiBk = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return wiyxdkDWcJJIpXpVpLtIuffNDYaj;
				}
				set
				{
					wiyxdkDWcJJIpXpVpLtIuffNDYaj = value;
				}
			}

			public float timeout
			{
				get
				{
					return JuibhSpugvypQMxnnThhIUhclfLB;
				}
				set
				{
					JuibhSpugvypQMxnnThhIUhclfLB = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return gPFVZMeyxlsatlDUpudQRsoaUeue;
				}
				set
				{
					gPFVZMeyxlsatlDUpudQRsoaUeue = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return KPtdiTKUVcnhTyqzIeZrdiuQgaBy;
				}
				set
				{
					KPtdiTKUVcnhTyqzIeZrdiuQgaBy = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return YyhHsuMXErCuETZIGMjqsIIIrhYx;
				}
				set
				{
					YyhHsuMXErCuETZIGMjqsIIIrhYx = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return OdwYEGCQNPHhIFGVbzMMIAqQmdGb;
				}
				set
				{
					OdwYEGCQNPHhIFGVbzMMIAqQmdGb = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return IPbWsCPmCxKrYTJEoTLyOHEfrIpg;
				}
				set
				{
					IPbWsCPmCxKrYTJEoTLyOHEfrIpg = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return sMfAlKCSLJQPmOSPZvrYpjrchkfDb;
				}
				set
				{
					sMfAlKCSLJQPmOSPZvrYpjrchkfDb = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return llTYNZhZGvdNQTjgLxYYjfIPgUfJ;
				}
				set
				{
					llTYNZhZGvdNQTjgLxYYjfIPgUfJ = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return RtHeKtYrTghOJOyTXupShaEoTbEg;
				}
				set
				{
					RtHeKtYrTghOJOyTXupShaEoTbEg = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return JZlyYOlSEEOsBjfmTmWvVkFBvqfJ;
				}
				set
				{
					JZlyYOlSEEOsBjfmTmWvVkFBvqfJ = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return KbHVhZQgZqnLYmNIuQKUTzxSuBXE;
				}
				set
				{
					KbHVhZQgZqnLYmNIuQKUTzxSuBXE = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return legdeqrJbFJSArtkBJeTJlqFaYbt;
				}
				set
				{
					legdeqrJbFJSArtkBJeTJlqFaYbt = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)wlmBpHeaRPRhQkjUmcPFpWsEYqsqA["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = aYZCdVAgwncesheFRpJRchjCqGzbA._003C_003E9.rfPGPbRhBwgyOhZudGcHCUddiAAfA;
					}
					wlmBpHeaRPRhQkjUmcPFpWsEYqsqA["isElementAllowed"] = safePredicate;
				}
			}

			internal _0001 iQkTeamLEtgJhbJnpuLUknQPbJLHA<_0001>(string P_0) where _0001 : SafeDelegate
			{
				if (!wlmBpHeaRPRhQkjUmcPFpWsEYqsqA.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as _0001;
			}

			public Options()
			{
				wJjPIIRJfHhEbGedUconecGfiwzgB();
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
				stringBuilder.Append("allowAxes = " + yYglqKZYHODXMCcpInikSUEMeUgu + "\n");
				stringBuilder.Append("allowButtons = " + ybhnWDIrnUHaPlzOgoFziwhIhiBk + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + wiyxdkDWcJJIpXpVpLtIuffNDYaj + "\n");
				stringBuilder.Append("timeout = " + JuibhSpugvypQMxnnThhIUhclfLB + "\n");
				stringBuilder.Append("checkForConflicts = " + gPFVZMeyxlsatlDUpudQRsoaUeue + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + KPtdiTKUVcnhTyqzIeZrdiuQgaBy + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + YyhHsuMXErCuETZIGMjqsIIIrhYx + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + OdwYEGCQNPHhIFGVbzMMIAqQmdGb + "\n");
				if (IPbWsCPmCxKrYTJEoTLyOHEfrIpg == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(IPbWsCPmCxKrYTJEoTLyOHEfrIpg) + "\n");
				}
				stringBuilder.Append("defaultActionWhenConflictFound = " + sMfAlKCSLJQPmOSPZvrYpjrchkfDb.ToString() + "\n");
				stringBuilder.Append("ignoreMouseXAxis = " + llTYNZhZGvdNQTjgLxYYjfIPgUfJ);
				stringBuilder.Append("ignoreMouseYAxis = " + RtHeKtYrTghOJOyTXupShaEoTbEg);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + JZlyYOlSEEOsBjfmTmWvVkFBvqfJ + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + KbHVhZQgZqnLYmNIuQKUTzxSuBXE + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + legdeqrJbFJSArtkBJeTJlqFaYbt + "\n");
				return stringBuilder.ToString();
			}

			internal void wJjPIIRJfHhEbGedUconecGfiwzgB()
			{
				yYglqKZYHODXMCcpInikSUEMeUgu = true;
				ybhnWDIrnUHaPlzOgoFziwhIhiBk = true;
				wiyxdkDWcJJIpXpVpLtIuffNDYaj = true;
				JuibhSpugvypQMxnnThhIUhclfLB = 0f;
				gPFVZMeyxlsatlDUpudQRsoaUeue = true;
				KPtdiTKUVcnhTyqzIeZrdiuQgaBy = true;
				YyhHsuMXErCuETZIGMjqsIIIrhYx = true;
				OdwYEGCQNPHhIFGVbzMMIAqQmdGb = true;
				IPbWsCPmCxKrYTJEoTLyOHEfrIpg = null;
				sMfAlKCSLJQPmOSPZvrYpjrchkfDb = ConflictResponse.Replace;
				llTYNZhZGvdNQTjgLxYYjfIPgUfJ = false;
				RtHeKtYrTghOJOyTXupShaEoTbEg = false;
				JZlyYOlSEEOsBjfmTmWvVkFBvqfJ = true;
				KbHVhZQgZqnLYmNIuQKUTzxSuBXE = true;
				legdeqrJbFJSArtkBJeTJlqFaYbt = 1f;
				foreach (string item in new List<string>(wlmBpHeaRPRhQkjUmcPFpWsEYqsqA.Keys))
				{
					wlmBpHeaRPRhQkjUmcPFpWsEYqsqA[item] = null;
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
				destination.yYglqKZYHODXMCcpInikSUEMeUgu = source.yYglqKZYHODXMCcpInikSUEMeUgu;
				destination.ybhnWDIrnUHaPlzOgoFziwhIhiBk = source.ybhnWDIrnUHaPlzOgoFziwhIhiBk;
				destination.wiyxdkDWcJJIpXpVpLtIuffNDYaj = source.wiyxdkDWcJJIpXpVpLtIuffNDYaj;
				destination.JuibhSpugvypQMxnnThhIUhclfLB = source.JuibhSpugvypQMxnnThhIUhclfLB;
				destination.gPFVZMeyxlsatlDUpudQRsoaUeue = source.gPFVZMeyxlsatlDUpudQRsoaUeue;
				destination.KPtdiTKUVcnhTyqzIeZrdiuQgaBy = source.KPtdiTKUVcnhTyqzIeZrdiuQgaBy;
				destination.YyhHsuMXErCuETZIGMjqsIIIrhYx = source.YyhHsuMXErCuETZIGMjqsIIIrhYx;
				destination.OdwYEGCQNPHhIFGVbzMMIAqQmdGb = source.OdwYEGCQNPHhIFGVbzMMIAqQmdGb;
				destination.IPbWsCPmCxKrYTJEoTLyOHEfrIpg = ArrayTools.ShallowCopy(source.IPbWsCPmCxKrYTJEoTLyOHEfrIpg);
				destination.sMfAlKCSLJQPmOSPZvrYpjrchkfDb = source.sMfAlKCSLJQPmOSPZvrYpjrchkfDb;
				destination.llTYNZhZGvdNQTjgLxYYjfIPgUfJ = source.llTYNZhZGvdNQTjgLxYYjfIPgUfJ;
				destination.RtHeKtYrTghOJOyTXupShaEoTbEg = source.RtHeKtYrTghOJOyTXupShaEoTbEg;
				destination.JZlyYOlSEEOsBjfmTmWvVkFBvqfJ = source.JZlyYOlSEEOsBjfmTmWvVkFBvqfJ;
				destination.KbHVhZQgZqnLYmNIuQKUTzxSuBXE = source.KbHVhZQgZqnLYmNIuQKUTzxSuBXE;
				destination.legdeqrJbFJSArtkBJeTJlqFaYbt = source.legdeqrJbFJSArtkBJeTJlqFaYbt;
				foreach (KeyValuePair<string, SafeDelegate> item in source.wlmBpHeaRPRhQkjUmcPFpWsEYqsqA)
				{
					destination.wlmBpHeaRPRhQkjUmcPFpWsEYqsqA[item.Key] = MiscTools.Clone(item.Value);
				}
			}
		}

		[Serializable]
		private sealed class gihAMCiteZRTUyRIgGZsRYuEhUouA
		{
			public static readonly gihAMCiteZRTUyRIgGZsRYuEhUouA _003C_003E9 = new gihAMCiteZRTUyRIgGZsRYuEhUouA();

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void zOAbXYFNYzhsHagsAbBwmwmGxwJjA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
			}

			internal void MEhOPXnsCfplpIMPBbaCJCAzsJMFb(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
			}

			internal void eWRlFxCilBxemBFBeakakLokdnsv(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
			}

			internal void reQJuKhmesLDbJNHoSpNLKkTdsEp(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
			}

			internal void olvJdmExEbVDoCslDrDPYIDOWqdQ(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
			}

			internal void tfWtQFuCfLnDYvWiZnhHDEVbIIWg(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
			}

			internal void qvHrvIfrijAwkIYNDBLoXLVLzgdW(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
			}
		}

		private static InputMapper OYQiqncsATCGrosbfEmmNOJBdCuX;

		private static int fxGaXscOVMhDlFhvBlRhBGySeCzCb;

		private readonly int MGobriTjpEhYdxtryXljuogCemez;

		private readonly bool IlRyXNFPlqWULOQJrDgAfFggUZoh;

		private readonly qEPnmRoPleZEbuJgPHpjBedULWBpA YbnEycFsxcqcokJXJgmQZRzLFugwA;

		private Options BTRQpUgGaOmyqnYvHEXtYXvdezIe;

		private readonly Dictionary<VJTGTSokKuRocfWrAOiDPkEXhawM, SafeDelegate> mtTDRmqMghxdPrvIRiigWHIkmclR = new Dictionary<VJTGTSokKuRocfWrAOiDPkEXhawM, SafeDelegate>
		{
			{
				VJTGTSokKuRocfWrAOiDPkEXhawM.InputMapped,
				new SafeAction<InputMappedEventData>(gihAMCiteZRTUyRIgGZsRYuEhUouA._003C_003E9.zOAbXYFNYzhsHagsAbBwmwmGxwJjA)
			},
			{
				VJTGTSokKuRocfWrAOiDPkEXhawM.Error,
				new SafeAction<ErrorEventData>(gihAMCiteZRTUyRIgGZsRYuEhUouA._003C_003E9.MEhOPXnsCfplpIMPBbaCJCAzsJMFb)
			},
			{
				VJTGTSokKuRocfWrAOiDPkEXhawM.Canceled,
				new SafeAction<CanceledEventData>(gihAMCiteZRTUyRIgGZsRYuEhUouA._003C_003E9.eWRlFxCilBxemBFBeakakLokdnsv)
			},
			{
				VJTGTSokKuRocfWrAOiDPkEXhawM.TimedOut,
				new SafeAction<TimedOutEventData>(gihAMCiteZRTUyRIgGZsRYuEhUouA._003C_003E9.reQJuKhmesLDbJNHoSpNLKkTdsEp)
			},
			{
				VJTGTSokKuRocfWrAOiDPkEXhawM.Started,
				new SafeAction<StartedEventData>(gihAMCiteZRTUyRIgGZsRYuEhUouA._003C_003E9.olvJdmExEbVDoCslDrDPYIDOWqdQ)
			},
			{
				VJTGTSokKuRocfWrAOiDPkEXhawM.Stopped,
				new SafeAction<StoppedEventData>(gihAMCiteZRTUyRIgGZsRYuEhUouA._003C_003E9.tfWtQFuCfLnDYvWiZnhHDEVbIIWg)
			},
			{
				VJTGTSokKuRocfWrAOiDPkEXhawM.ConflictsFound,
				new SafeAction<ConflictFoundEventData>(gihAMCiteZRTUyRIgGZsRYuEhUouA._003C_003E9.qvHrvIfrijAwkIYNDBLoXLVLzgdW)
			}
		};

		public static InputMapper Default => OYQiqncsATCGrosbfEmmNOJBdCuX ?? (OYQiqncsATCGrosbfEmmNOJBdCuX = new InputMapper(true));

		public Options options
		{
			get
			{
				Options obj = BTRQpUgGaOmyqnYvHEXtYXvdezIe;
				if (obj == null)
				{
					if (!IlRyXNFPlqWULOQJrDgAfFggUZoh)
					{
						return BTRQpUgGaOmyqnYvHEXtYXvdezIe = Default.options.Clone();
					}
					obj = (BTRQpUgGaOmyqnYvHEXtYXvdezIe = new Options());
				}
				return obj;
			}
			set
			{
				BTRQpUgGaOmyqnYvHEXtYXvdezIe = value;
			}
		}

		public Context mappingContext => YbnEycFsxcqcokJXJgmQZRzLFugwA.SPtcBBnfEBKqFyFScRzNUjLpDwMC;

		public Status status => YbnEycFsxcqcokJXJgmQZRzLFugwA.QATIbsEkzfPDVbMHBSDTYZNZIsaM;

		public float timeRemaining => YbnEycFsxcqcokJXJgmQZRzLFugwA.TLhiqzjVbqdzYUefSPWhdApvQOmF;

		internal int krsTtHLNxEdniCjaeNCXXDxqAnqr => MGobriTjpEhYdxtryXljuogCemez;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.InputMapped;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<InputMappedEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.InputMapped;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<InputMappedEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.Error;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<ErrorEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.Error;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<ErrorEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.Canceled;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<CanceledEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.Canceled;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<CanceledEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.TimedOut;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<TimedOutEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.TimedOut;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<TimedOutEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.Started;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<StartedEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.Started;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<StartedEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.Stopped;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<StoppedEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.Stopped;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<StoppedEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.ConflictsFound;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<ConflictFoundEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					VJTGTSokKuRocfWrAOiDPkEXhawM key = VJTGTSokKuRocfWrAOiDPkEXhawM.ConflictsFound;
					mtTDRmqMghxdPrvIRiigWHIkmclR[key] = (SafeAction<ConflictFoundEventData>)mtTDRmqMghxdPrvIRiigWHIkmclR[key] - value;
				}
			}
		}

		private static int hYyIGiFgSWgaLzDVyjzBVWHHMPQr()
		{
			int result = fxGaXscOVMhDlFhvBlRhBGySeCzCb;
			if (fxGaXscOVMhDlFhvBlRhBGySeCzCb == int.MaxValue)
			{
				fxGaXscOVMhDlFhvBlRhBGySeCzCb = 0;
				return result;
			}
			fxGaXscOVMhDlFhvBlRhBGySeCzCb++;
			return result;
		}

		public InputMapper()
			: this(false)
		{
			MGobriTjpEhYdxtryXljuogCemez = hYyIGiFgSWgaLzDVyjzBVWHHMPQr();
		}

		private InputMapper(bool P_0)
		{
			IlRyXNFPlqWULOQJrDgAfFggUZoh = P_0;
			if (IlRyXNFPlqWULOQJrDgAfFggUZoh)
			{
				BTRQpUgGaOmyqnYvHEXtYXvdezIe = new Options();
			}
			YbnEycFsxcqcokJXJgmQZRzLFugwA = new qEPnmRoPleZEbuJgPHpjBedULWBpA(this, mtTDRmqMghxdPrvIRiigWHIkmclR);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<VJTGTSokKuRocfWrAOiDPkEXhawM, SafeDelegate> item in mtTDRmqMghxdPrvIRiigWHIkmclR)
			{
				item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<VJTGTSokKuRocfWrAOiDPkEXhawM, SafeDelegate> item in mtTDRmqMghxdPrvIRiigWHIkmclR)
			{
				item.Value.Clear();
			}
		}

		internal void ctPGJZiYbDjuOohykJkCarNpBEAT(object P_0)
		{
		}

		internal void AfywmoUGJhazhRyeZntIEsDvHKXp()
		{
		}

		public bool Start(Context mappingContext)
		{
			return YzxJYzIGUbUuQcUjIpyhOcHzsJaf(mappingContext, (BTRQpUgGaOmyqnYvHEXtYXvdezIe != null) ? BTRQpUgGaOmyqnYvHEXtYXvdezIe : Default.options);
		}

		public void Stop()
		{
			YbnEycFsxcqcokJXJgmQZRzLFugwA.GFVOuNwCKtSvZKjlBDSviRbIqASO("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			AfywmoUGJhazhRyeZntIEsDvHKXp();
			BTRQpUgGaOmyqnYvHEXtYXvdezIe = null;
		}

		private bool YzxJYzIGUbUuQcUjIpyhOcHzsJaf(Context P_0, Options P_1)
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
				YbnEycFsxcqcokJXJgmQZRzLFugwA.YzxJYzIGUbUuQcUjIpyhOcHzsJaf(P_0, P_1);
				return true;
			}
			catch
			{
				YbnEycFsxcqcokJXJgmQZRzLFugwA.GFVOuNwCKtSvZKjlBDSviRbIqASO("Failed to start due to an exception.");
				return false;
			}
		}
	}
}
