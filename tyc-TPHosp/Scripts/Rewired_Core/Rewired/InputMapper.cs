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
			private int sRbRrhSYcsdTbzpQQADExfvLSkq = -1;

			private ControllerMap BwdkYrCIFNiRPDEpxxAUFyIFLij;

			private ActionElementMap mjzEQfLxlkhdwgeCyxQlUNQFQEU;

			private AxisRange EfYWjVYqZXEuEHMilAAgbdAVohH = AxisRange.Positive;

			private bool kdhBjPFeZEgDUgcpuKvoaKPbvrVo;

			public int actionId
			{
				get
				{
					return sRbRrhSYcsdTbzpQQADExfvLSkq;
				}
				set
				{
					if (!ohyTIAlaQmeVsCoAMdthUJtHfMZ())
					{
						sRbRrhSYcsdTbzpQQADExfvLSkq = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(sRbRrhSYcsdTbzpQQADExfvLSkq);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!ohyTIAlaQmeVsCoAMdthUJtHfMZ())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							sRbRrhSYcsdTbzpQQADExfvLSkq = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							sRbRrhSYcsdTbzpQQADExfvLSkq = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return BwdkYrCIFNiRPDEpxxAUFyIFLij;
				}
				set
				{
					if (!ohyTIAlaQmeVsCoAMdthUJtHfMZ())
					{
						BwdkYrCIFNiRPDEpxxAUFyIFLij = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return mjzEQfLxlkhdwgeCyxQlUNQFQEU;
				}
				set
				{
					if (!ohyTIAlaQmeVsCoAMdthUJtHfMZ())
					{
						mjzEQfLxlkhdwgeCyxQlUNQFQEU = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return EfYWjVYqZXEuEHMilAAgbdAVohH;
				}
				set
				{
					if (!ohyTIAlaQmeVsCoAMdthUJtHfMZ())
					{
						EfYWjVYqZXEuEHMilAAgbdAVohH = value;
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

			internal void hBVHlDDTvqvZQRIwXrjyWxxOQdK()
			{
				kdhBjPFeZEgDUgcpuKvoaKPbvrVo = true;
			}

			private bool ohyTIAlaQmeVsCoAMdthUJtHfMZ()
			{
				if (kdhBjPFeZEgDUgcpuKvoaKPbvrVo)
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
				destination.sRbRrhSYcsdTbzpQQADExfvLSkq = source.sRbRrhSYcsdTbzpQQADExfvLSkq;
				destination.BwdkYrCIFNiRPDEpxxAUFyIFLij = source.BwdkYrCIFNiRPDEpxxAUFyIFLij;
				destination.mjzEQfLxlkhdwgeCyxQlUNQFQEU = source.mjzEQfLxlkhdwgeCyxQlUNQFQEU;
				destination.EfYWjVYqZXEuEHMilAAgbdAVohH = source.EfYWjVYqZXEuEHMilAAgbdAVohH;
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

		private enum WkDKNFiZiZktrypdHARufyCmdaQF
		{
			AYAHddjPpVESViGDmuYMRLDvhRY = 0,
			RiXrdYetQWTzGifSHzocCSJcycN = 1,
			gsOnBSqbBUYqlJKNiABAglhvWSv = 2,
			XeZyFjHnFdQqRAAnpvPgyieddymi = 3,
			IWncyCTABLmPUmFcHqSuWmnWftk = 4,
			IKeKeAkzWHJtaxOaBYCxMsMwEyQ = 5,
			DHbPWcBarfSdYSGXfhlpsbMfftN = 6
		}

		public enum Status
		{
			Idle = 0,
			Listening = 1,
			AwaitingResponse = 2
		}

		private class zDZQuIoVFVdXmnnoKtESLOhfdIj
		{
			private enum bnygFFDtDbvCGnBnrVJOsISRSxj
			{
				rBwXZhzaEAOPuDcuQECceTsYPItB = 0,
				nYTbnofafcmwWijpsykpQnAZAmw = 1
			}

			private enum LPCXyMxFdTeYoNxRAHZecnIgcJW
			{
				DVDMTdEnkAaktJFJqNakDhECjSAS = 0,
				pSTfRDKDzNUmzPNbbGQClJpUFONM = 1
			}

			private class thURxGwRezLaXvQIefDgFaIsQiL
			{
				private Player kBpLQLyZZWEsvrnaXVjYtMyWIFB;

				private int sRbRrhSYcsdTbzpQQADExfvLSkq;

				private Context rryBiFXxZNokWWPnHeEYpWIHzqg;

				private ControllerType beJOxBqDtyzXnNjzgKyRzARzFSQ;

				private int hVLcwKGZNRwDcwqMxzBMRgucbhPa;

				private ControllerPollingInfo vqkmKQmFsuJzowoYdcCQqEKUSwU;

				private ModifierKeyFlags QaOwhKpQpcMhpjcMVDDKPLBmZPQ;

				public Player player => kBpLQLyZZWEsvrnaXVjYtMyWIFB;

				public int actionId => sRbRrhSYcsdTbzpQQADExfvLSkq;

				public Context mappingContext => rryBiFXxZNokWWPnHeEYpWIHzqg;

				public ControllerType controllerType => beJOxBqDtyzXnNjzgKyRzARzFSQ;

				public int controllerId => hVLcwKGZNRwDcwqMxzBMRgucbhPa;

				public ControllerPollingInfo pollingInfo => vqkmKQmFsuJzowoYdcCQqEKUSwU;

				public ModifierKeyFlags modifierKeyFlags => QaOwhKpQpcMhpjcMVDDKPLBmZPQ;

				public AxisRange axisRange
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (pollingInfo.elementType == ControllerElementType.Axis)
						{
							result = ((rryBiFXxZNokWWPnHeEYpWIHzqg.actionRange != AxisRange.Full) ? ((pollingInfo.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
						}
						return result;
					}
				}

				public string elementName
				{
					get
					{
						if (controllerType == ControllerType.Keyboard && modifierKeyFlags != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(modifierKeyFlags)} + {pollingInfo.elementIdentifierName}";
						}
						string text = pollingInfo.elementIdentifierName;
						if (pollingInfo.elementType == ControllerElementType.Axis)
						{
							if (axisRange == AxisRange.Positive)
							{
								text += " +";
							}
							else if (axisRange == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				public void EJpmrTgGvrhKjJnkpXbomYBpQTQ(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
					kBpLQLyZZWEsvrnaXVjYtMyWIFB = P_0;
					sRbRrhSYcsdTbzpQQADExfvLSkq = P_1.actionId;
					beJOxBqDtyzXnNjzgKyRzARzFSQ = P_1.controllerMap.controllerType;
					hVLcwKGZNRwDcwqMxzBMRgucbhPa = P_1.controllerMap.controllerId;
					rryBiFXxZNokWWPnHeEYpWIHzqg = P_1;
					beJOxBqDtyzXnNjzgKyRzARzFSQ = P_1.controllerMap.controllerType;
					hVLcwKGZNRwDcwqMxzBMRgucbhPa = P_1.controllerMap.controllerId;
					P_1.hBVHlDDTvqvZQRIwXrjyWxxOQdK();
				}

				public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
				{
					kBpLQLyZZWEsvrnaXVjYtMyWIFB = null;
					sRbRrhSYcsdTbzpQQADExfvLSkq = -1;
					rryBiFXxZNokWWPnHeEYpWIHzqg = null;
					beJOxBqDtyzXnNjzgKyRzARzFSQ = ControllerType.Keyboard;
					hVLcwKGZNRwDcwqMxzBMRgucbhPa = -1;
					vqkmKQmFsuJzowoYdcCQqEKUSwU = default(ControllerPollingInfo);
					QaOwhKpQpcMhpjcMVDDKPLBmZPQ = ModifierKeyFlags.None;
				}

				public ElementAssignment NoBPLLzcUicnKIHZckkqHiQKzFPK(ControllerPollingInfo P_0)
				{
					vqkmKQmFsuJzowoYdcCQqEKUSwU = P_0;
					return NoBPLLzcUicnKIHZckkqHiQKzFPK();
				}

				public ElementAssignment NoBPLLzcUicnKIHZckkqHiQKzFPK(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					vqkmKQmFsuJzowoYdcCQqEKUSwU = P_0;
					QaOwhKpQpcMhpjcMVDDKPLBmZPQ = P_1;
					return NoBPLLzcUicnKIHZckkqHiQKzFPK();
				}

				public ElementAssignment NoBPLLzcUicnKIHZckkqHiQKzFPK()
				{
					return new ElementAssignment(controllerType, vqkmKQmFsuJzowoYdcCQqEKUSwU.elementType, vqkmKQmFsuJzowoYdcCQqEKUSwU.elementIdentifierId, axisRange, vqkmKQmFsuJzowoYdcCQqEKUSwU.keyboardKey, QaOwhKpQpcMhpjcMVDDKPLBmZPQ, sRbRrhSYcsdTbzpQQADExfvLSkq, (rryBiFXxZNokWWPnHeEYpWIHzqg.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, invert: false, (rryBiFXxZNokWWPnHeEYpWIHzqg.actionElementMapToReplace != null) ? rryBiFXxZNokWWPnHeEYpWIHzqg.actionElementMapToReplace.id : (-1));
				}
			}

			private readonly InputMapper TKnWISxZiQPTaIhKpEMkcaWQSuD;

			private readonly Options QMFPjRsTYvchhgHfSNxIfTPWAky = new Options();

			private readonly thURxGwRezLaXvQIefDgFaIsQiL kIGEJaoJEelXAXqMHFkzqlRNwiF = new thURxGwRezLaXvQIefDgFaIsQiL();

			private readonly Dictionary<WkDKNFiZiZktrypdHARufyCmdaQF, SafeDelegate> xZDHLzcaKIsgGcrUCsXHdwSNtaR;

			private readonly Dictionary<string, SafeDelegate> fKwfjYboziBwVPmCrPayjlspNcMw;

			private Status mHHcGgMiTOBIOIDaaBmmdPgXSEJg;

			private LPCXyMxFdTeYoNxRAHZecnIgcJW FAlVqZbOCCUhjGnejdOFzcxHzsW;

			private double vfFRUIPUoKMeIeOScHBAvptzXYo;

			private bool RRArFIheJhWUCHDqoROWFZnpMme;

			private List<Player> PkkcLMhLxwQggcdPVsEwPBOlPRX = new List<Player>();

			private readonly List<ControllerPollingInfo> mdvJtOrCMFjzScCuAnNutWsoMRc = new List<ControllerPollingInfo>();

			private ElementAssignment NHkmtxylVZGEnWWEFtJmPJZqXEg;

			public Status status => mHHcGgMiTOBIOIDaaBmmdPgXSEJg;

			public float timeRemaining
			{
				get
				{
					if (mHHcGgMiTOBIOIDaaBmmdPgXSEJg == Status.Idle)
					{
						return 0f;
					}
					if (QMFPjRsTYvchhgHfSNxIfTPWAky.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, vfFRUIPUoKMeIeOScHBAvptzXYo + (double)QMFPjRsTYvchhgHfSNxIfTPWAky.timeout - ReInput.unscaledTime);
				}
			}

			public Context context
			{
				get
				{
					if (mHHcGgMiTOBIOIDaaBmmdPgXSEJg == Status.Idle)
					{
						return null;
					}
					return kIGEJaoJEelXAXqMHFkzqlRNwiF.mappingContext;
				}
			}

			private bool checkTimer
			{
				get
				{
					if (RRArFIheJhWUCHDqoROWFZnpMme)
					{
						return false;
					}
					if (!(QMFPjRsTYvchhgHfSNxIfTPWAky.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public zDZQuIoVFVdXmnnoKtESLOhfdIj(InputMapper parent, Dictionary<WkDKNFiZiZktrypdHARufyCmdaQF, SafeDelegate> events)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (events == null)
				{
					throw new ArgumentNullException("events");
				}
				TKnWISxZiQPTaIhKpEMkcaWQSuD = parent;
				xZDHLzcaKIsgGcrUCsXHdwSNtaR = events;
				OhOZdYxFTscbQxoVMmQSNNzYgeU();
			}

			~zDZQuIoVFVdXmnnoKtESLOhfdIj()
			{
				qMAygzaQdnWPlRcJIDbAkqQltsM();
			}

			public void PUfBGkQEoKKPRrTrZNGGdNNSToS(Context P_0, Options P_1)
			{
				if (mHHcGgMiTOBIOIDaaBmmdPgXSEJg != Status.Idle)
				{
					XkKeWXxMdibsfCSijZtAdQqNHfZ("User started a new listening session.");
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
				Options.Copy(P_1, QMFPjRsTYvchhgHfSNxIfTPWAky);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					NawCDmDuLYzifdXLNhxnNOCEAGZ("No Action found for actionId: " + P_0.actionId);
					return;
				}
				kIGEJaoJEelXAXqMHFkzqlRNwiF.EJpmrTgGvrhKjJnkpXbomYBpQTQ(player, P_0);
				mHHcGgMiTOBIOIDaaBmmdPgXSEJg = Status.Listening;
				PDqdTlMKeRJCuAjundevqmDEEyD();
				qUAkCKzalRtLFPAMaICIYuMQtcu();
				MvSPrnwEZFEJyDuHmgAzOESycIDB();
				PORaVZQAtpaUOfdQdjPmjveSPCb();
			}

			public void LZHqaCebyKfwGdPvSMfYlTrzOGyO(string P_0)
			{
				if (mHHcGgMiTOBIOIDaaBmmdPgXSEJg != Status.Idle)
				{
					XkKeWXxMdibsfCSijZtAdQqNHfZ(P_0);
				}
			}

			private void QTPiZFmnRsxmyQYmMuIoBQkOtfg(UpdateLoopType P_0)
			{
				if (P_0 != UpdateLoopType.Update || mHHcGgMiTOBIOIDaaBmmdPgXSEJg != Status.Listening)
				{
					return;
				}
				if (checkTimer && timeRemaining <= 0f)
				{
					avwilQeCikOomafBRodWNujFxPf();
					return;
				}
				Controller controller = ReInput.controllers.GetController(kIGEJaoJEelXAXqMHFkzqlRNwiF.controllerType, kIGEJaoJEelXAXqMHFkzqlRNwiF.controllerId);
				ElementAssignment elementAssignment;
				if (controller == null)
				{
					NawCDmDuLYzifdXLNhxnNOCEAGZ(string.Concat("Controller not found for type: ", kIGEJaoJEelXAXqMHFkzqlRNwiF.controllerType, " id: ", kIGEJaoJEelXAXqMHFkzqlRNwiF.controllerId));
				}
				else if (vkifOgdrwVMDPVKkSatkasNhZiOu(out elementAssignment) != bnygFFDtDbvCGnBnrVJOsISRSxj.rBwXZhzaEAOPuDcuQECceTsYPItB && wCEgmxesWMSDlbEZtyeaDbYwwIxq(elementAssignment) != bnygFFDtDbvCGnBnrVJOsISRSxj.rBwXZhzaEAOPuDcuQECceTsYPItB)
				{
					NINWeNmgTtlOmbJjbmpmTNFVWbT(elementAssignment);
				}
			}

			private void CIEJgfDYMtwMWeSfJfPZCQnbOtY()
			{
				if (mHHcGgMiTOBIOIDaaBmmdPgXSEJg != Status.Idle)
				{
					OhOZdYxFTscbQxoVMmQSNNzYgeU();
					qMAygzaQdnWPlRcJIDbAkqQltsM();
					CABKNGbcLNGeIBKINTDfKbDgdcs();
				}
			}

			private void OhOZdYxFTscbQxoVMmQSNNzYgeU()
			{
				mHHcGgMiTOBIOIDaaBmmdPgXSEJg = Status.Idle;
				vfFRUIPUoKMeIeOScHBAvptzXYo = 0.0;
				QMFPjRsTYvchhgHfSNxIfTPWAky.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				kIGEJaoJEelXAXqMHFkzqlRNwiF.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				NHkmtxylVZGEnWWEFtJmPJZqXEg = default(ElementAssignment);
				FAlVqZbOCCUhjGnejdOFzcxHzsW = LPCXyMxFdTeYoNxRAHZecnIgcJW.DVDMTdEnkAaktJFJqNakDhECjSAS;
				RRArFIheJhWUCHDqoROWFZnpMme = false;
				PkkcLMhLxwQggcdPVsEwPBOlPRX.Clear();
			}

			private bnygFFDtDbvCGnBnrVJOsISRSxj vkifOgdrwVMDPVKkSatkasNhZiOu(out ElementAssignment P_0)
			{
				if (!fvydnadbeWJgMurthKLdRBqHXfr(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return bnygFFDtDbvCGnBnrVJOsISRSxj.rBwXZhzaEAOPuDcuQECceTsYPItB;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !XfglUtyOFibWebvHdxBAOIjbMmJd(item, QMFPjRsTYvchhgHfSNxIfTPWAky))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return bnygFFDtDbvCGnBnrVJOsISRSxj.rBwXZhzaEAOPuDcuQECceTsYPItB;
				}
				if (!OspaNxzggAUdnmmKXYjUsHUwDhi(kIGEJaoJEelXAXqMHFkzqlRNwiF, controllerPollingInfo, QMFPjRsTYvchhgHfSNxIfTPWAky))
				{
					P_0 = default(ElementAssignment);
					return bnygFFDtDbvCGnBnrVJOsISRSxj.rBwXZhzaEAOPuDcuQECceTsYPItB;
				}
				P_0 = kIGEJaoJEelXAXqMHFkzqlRNwiF.NoBPLLzcUicnKIHZckkqHiQKzFPK(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return bnygFFDtDbvCGnBnrVJOsISRSxj.nYTbnofafcmwWijpsykpQnAZAmw;
			}

			private bool fvydnadbeWJgMurthKLdRBqHXfr(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = kIGEJaoJEelXAXqMHFkzqlRNwiF.controllerType;
				int controllerId = kIGEJaoJEelXAXqMHFkzqlRNwiF.controllerId;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = icPmKNOmVnGuyNpDCqlqYOzqMuv(out P_1);
					return true;
				}
				if (QMFPjRsTYvchhgHfSNxIfTPWAky.allowAxes)
				{
					if (QMFPjRsTYvchhgHfSNxIfTPWAky.allowButtons)
					{
						if (kIGEJaoJEelXAXqMHFkzqlRNwiF.player != null)
						{
							P_0 = kIGEJaoJEelXAXqMHFkzqlRNwiF.player.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(kIGEJaoJEelXAXqMHFkzqlRNwiF.controllerType, kIGEJaoJEelXAXqMHFkzqlRNwiF.controllerId);
						}
					}
					else if (kIGEJaoJEelXAXqMHFkzqlRNwiF.player != null)
					{
						P_0 = kIGEJaoJEelXAXqMHFkzqlRNwiF.player.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!QMFPjRsTYvchhgHfSNxIfTPWAky.allowButtons)
					{
						NawCDmDuLYzifdXLNhxnNOCEAGZ("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (kIGEJaoJEelXAXqMHFkzqlRNwiF.player != null)
					{
						P_0 = kIGEJaoJEelXAXqMHFkzqlRNwiF.player.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> icPmKNOmVnGuyNpDCqlqYOzqMuv(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				mdvJtOrCMFjzScCuAnNutWsoMRc.Clear();
				if (!QMFPjRsTYvchhgHfSNxIfTPWAky.allowButtons)
				{
					return mdvJtOrCMFjzScCuAnNutWsoMRc;
				}
				mdvJtOrCMFjzScCuAnNutWsoMRc.Add(ANpVfLOrfmiqLToKUCMSGjCrfWJC(QMFPjRsTYvchhgHfSNxIfTPWAky, out P_0));
				return mdvJtOrCMFjzScCuAnNutWsoMRc;
			}

			private ControllerPollingInfo ANpVfLOrfmiqLToKUCMSGjCrfWJC(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = ANpVfLOrfmiqLToKUCMSGjCrfWJC(P_0, out flag, out P_1, out text);
				if (flag)
				{
					PDqdTlMKeRJCuAjundevqmDEEyD();
				}
				return result;
			}

			private static ControllerPollingInfo ANpVfLOrfmiqLToKUCMSGjCrfWJC(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
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

			private static bool XfglUtyOFibWebvHdxBAOIjbMmJd(ControllerPollingInfo P_0, Options P_1)
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
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.hwwUwlmTsGSAcoHhsWapHMGwSRz<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool OspaNxzggAUdnmmKXYjUsHUwDhi(thURxGwRezLaXvQIefDgFaIsQiL P_0, ControllerPollingInfo P_1, Options P_2)
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

			private void qUAkCKzalRtLFPAMaICIYuMQtcu()
			{
				if (!QMFPjRsTYvchhgHfSNxIfTPWAky.checkForConflicts)
				{
					return;
				}
				if (QMFPjRsTYvchhgHfSNxIfTPWAky.checkForConflictsWithSelf && kIGEJaoJEelXAXqMHFkzqlRNwiF.player != null)
				{
					ListTools.AddIfUnique(PkkcLMhLxwQggcdPVsEwPBOlPRX, kIGEJaoJEelXAXqMHFkzqlRNwiF.player);
				}
				if (QMFPjRsTYvchhgHfSNxIfTPWAky.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(PkkcLMhLxwQggcdPVsEwPBOlPRX, ReInput.players.SystemPlayer);
				}
				if (QMFPjRsTYvchhgHfSNxIfTPWAky.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(PkkcLMhLxwQggcdPVsEwPBOlPRX, players[i]);
					}
				}
				else
				{
					if (QMFPjRsTYvchhgHfSNxIfTPWAky.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(QMFPjRsTYvchhgHfSNxIfTPWAky.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(PkkcLMhLxwQggcdPVsEwPBOlPRX, allPlayers[j]);
						}
					}
				}
			}

			private bnygFFDtDbvCGnBnrVJOsISRSxj wCEgmxesWMSDlbEZtyeaDbYwwIxq(ElementAssignment P_0)
			{
				if (QMFPjRsTYvchhgHfSNxIfTPWAky.checkForConflicts && kIGEJaoJEelXAXqMHFkzqlRNwiF.player != null && MsIJXMqOKupTfxhtmnMYNGPVLrR(kIGEJaoJEelXAXqMHFkzqlRNwiF, P_0, PkkcLMhLxwQggcdPVsEwPBOlPRX))
				{
					return qbWQJxoHGETVthahxHMkjdpQCgD(P_0);
				}
				return bnygFFDtDbvCGnBnrVJOsISRSxj.nYTbnofafcmwWijpsykpQnAZAmw;
			}

			private static bool MsIJXMqOKupTfxhtmnMYNGPVLrR(thURxGwRezLaXvQIefDgFaIsQiL P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.player == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!azBDCOzibppmXYTuwuYGfdUFiLq(P_0, P_1, out var conflictCheck))
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

			private static bool kmWdyoSmlNUZAjgOTgadvlnvIEp(thURxGwRezLaXvQIefDgFaIsQiL P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.player == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!azBDCOzibppmXYTuwuYGfdUFiLq(P_0, P_1, out var conflictCheck))
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

			private static IList<ElementAssignmentConflictInfo> XBUobNeYPckajevuIkYLQgcZwUN(thURxGwRezLaXvQIefDgFaIsQiL P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.player == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!azBDCOzibppmXYTuwuYGfdUFiLq(P_0, P_1, out var conflictCheck))
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

			private static bool azBDCOzibppmXYTuwuYGfdUFiLq(thURxGwRezLaXvQIefDgFaIsQiL P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				if (P_0 == null || (player = P_0.player) == null)
				{
					P_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				P_2 = P_1.ToElementAssignmentConflictCheck();
				P_2.playerId = player.id;
				P_2.controllerType = P_0.controllerType;
				P_2.controllerId = P_0.controllerId;
				P_2.controllerMapId = P_0.mappingContext.controllerMap.id;
				P_2.controllerMapCategoryId = P_0.mappingContext.controllerMap.categoryId;
				if (P_0.mappingContext.actionElementMapToReplace != null)
				{
					P_2.elementMapId = P_0.mappingContext.actionElementMapToReplace.id;
				}
				return true;
			}

			private static void WBMczrVIDHFprFbklamWiPDzgKK(thURxGwRezLaXvQIefDgFaIsQiL P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.player == null)
				{
					return;
				}
				if (!azBDCOzibppmXYTuwuYGfdUFiLq(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void MvSPrnwEZFEJyDuHmgAzOESycIDB()
			{
				ReInput.UpdateEndedEvent -= QTPiZFmnRsxmyQYmMuIoBQkOtfg;
				ReInput.UpdateEndedEvent += QTPiZFmnRsxmyQYmMuIoBQkOtfg;
			}

			private void qMAygzaQdnWPlRcJIDbAkqQltsM()
			{
				ReInput.UpdateEndedEvent -= QTPiZFmnRsxmyQYmMuIoBQkOtfg;
			}

			private bool XwCACyirqdXYnsCPpgSBCfobWMVU(WkDKNFiZiZktrypdHARufyCmdaQF P_0)
			{
				SafeDelegate safeDelegate = xZDHLzcaKIsgGcrUCsXHdwSNtaR[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void izAiDVoJXdFVSPjNdPRdejAMrME<T>(WkDKNFiZiZktrypdHARufyCmdaQF P_0, T P_1)
			{
				SafeAction<T> safeAction = (SafeAction<T>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void PDqdTlMKeRJCuAjundevqmDEEyD()
			{
				vfFRUIPUoKMeIeOScHBAvptzXYo = ReInput.unscaledTime;
			}

			private void XdRKPGnRuSlkYXjZQDnpsUMSju()
			{
				RRArFIheJhWUCHDqoROWFZnpMme = true;
			}

			private void AeWUmjqWwpeeRUGohibVDQeUGRvM(ActionElementMap P_0)
			{
				kpszNdttNohjQuiNxeaRTBNpRuM(P_0);
				CIEJgfDYMtwMWeSfJfPZCQnbOtY();
			}

			private void XkKeWXxMdibsfCSijZtAdQqNHfZ(string P_0)
			{
				ppvfVFQAWjStMZqBsSdRsXGzYHd(P_0);
				CIEJgfDYMtwMWeSfJfPZCQnbOtY();
			}

			private bnygFFDtDbvCGnBnrVJOsISRSxj qbWQJxoHGETVthahxHMkjdpQCgD(ElementAssignment P_0)
			{
				if (XwCACyirqdXYnsCPpgSBCfobWMVU(WkDKNFiZiZktrypdHARufyCmdaQF.DHbPWcBarfSdYSGXfhlpsbMfftN))
				{
					bool flag = kmWdyoSmlNUZAjgOTgadvlnvIEp(kIGEJaoJEelXAXqMHFkzqlRNwiF, P_0, PkkcLMhLxwQggcdPVsEwPBOlPRX);
					NHkmtxylVZGEnWWEFtJmPJZqXEg = P_0;
					IList<ElementAssignmentConflictInfo> list = XBUobNeYPckajevuIkYLQgcZwUN(kIGEJaoJEelXAXqMHFkzqlRNwiF, P_0, PkkcLMhLxwQggcdPVsEwPBOlPRX);
					FAlVqZbOCCUhjGnejdOFzcxHzsW = LPCXyMxFdTeYoNxRAHZecnIgcJW.pSTfRDKDzNUmzPNbbGQClJpUFONM;
					UVbwKKNxBlQTEgekmlDFfQMsBlN();
					tFqrZfpKxAtkKLeFnxvvunVqmwv(new ElementAssignmentInfo(kIGEJaoJEelXAXqMHFkzqlRNwiF.mappingContext.controllerMap, P_0), list, flag);
					return bnygFFDtDbvCGnBnrVJOsISRSxj.rBwXZhzaEAOPuDcuQECceTsYPItB;
				}
				return CbEgTLnbBMSQyzeOPUqobexIRTm(QMFPjRsTYvchhgHfSNxIfTPWAky.defaultActionWhenConflictFound, P_0);
			}

			private bnygFFDtDbvCGnBnrVJOsISRSxj CbEgTLnbBMSQyzeOPUqobexIRTm(ConflictResponse P_0, ElementAssignment P_1)
			{
				return CbEgTLnbBMSQyzeOPUqobexIRTm(P_0, P_1, kmWdyoSmlNUZAjgOTgadvlnvIEp(kIGEJaoJEelXAXqMHFkzqlRNwiF, P_1, PkkcLMhLxwQggcdPVsEwPBOlPRX));
			}

			private bnygFFDtDbvCGnBnrVJOsISRSxj CbEgTLnbBMSQyzeOPUqobexIRTm(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					XkKeWXxMdibsfCSijZtAdQqNHfZ("Mapping assignment was canceled due to a conflict.");
					return bnygFFDtDbvCGnBnrVJOsISRSxj.rBwXZhzaEAOPuDcuQECceTsYPItB;
				case ConflictResponse.Replace:
					if (P_2)
					{
						XkKeWXxMdibsfCSijZtAdQqNHfZ("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return bnygFFDtDbvCGnBnrVJOsISRSxj.rBwXZhzaEAOPuDcuQECceTsYPItB;
					}
					WBMczrVIDHFprFbklamWiPDzgKK(kIGEJaoJEelXAXqMHFkzqlRNwiF, P_1, PkkcLMhLxwQggcdPVsEwPBOlPRX);
					return bnygFFDtDbvCGnBnrVJOsISRSxj.nYTbnofafcmwWijpsykpQnAZAmw;
				case ConflictResponse.Add:
					return bnygFFDtDbvCGnBnrVJOsISRSxj.nYTbnofafcmwWijpsykpQnAZAmw;
				case ConflictResponse.Ignore:
					LGZaSGMkpzMsKYGOscxtbKiXwZTC();
					return bnygFFDtDbvCGnBnrVJOsISRSxj.rBwXZhzaEAOPuDcuQECceTsYPItB;
				default:
					throw new NotImplementedException();
				}
			}

			private void avwilQeCikOomafBRodWNujFxPf()
			{
				kiFnvGHBEJOtblARkhFFMTjufvF();
				CIEJgfDYMtwMWeSfJfPZCQnbOtY();
			}

			private void NawCDmDuLYzifdXLNhxnNOCEAGZ(string P_0)
			{
				RZFTBKxBjDeFODCYzoiZeDurmpt(P_0);
				CIEJgfDYMtwMWeSfJfPZCQnbOtY();
			}

			private void UVbwKKNxBlQTEgekmlDFfQMsBlN()
			{
				XdRKPGnRuSlkYXjZQDnpsUMSju();
				qMAygzaQdnWPlRcJIDbAkqQltsM();
				mHHcGgMiTOBIOIDaaBmmdPgXSEJg = Status.AwaitingResponse;
			}

			private void LGZaSGMkpzMsKYGOscxtbKiXwZTC()
			{
				mHHcGgMiTOBIOIDaaBmmdPgXSEJg = Status.Listening;
				FAlVqZbOCCUhjGnejdOFzcxHzsW = LPCXyMxFdTeYoNxRAHZecnIgcJW.DVDMTdEnkAaktJFJqNakDhECjSAS;
				PDqdTlMKeRJCuAjundevqmDEEyD();
				MvSPrnwEZFEJyDuHmgAzOESycIDB();
			}

			private void NINWeNmgTtlOmbJjbmpmTNFVWbT(ElementAssignment P_0)
			{
				if (kIGEJaoJEelXAXqMHFkzqlRNwiF.mappingContext.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					AeWUmjqWwpeeRUGohibVDQeUGRvM(result);
				}
				else
				{
					NawCDmDuLYzifdXLNhxnNOCEAGZ("Failed to create element assignment.");
				}
			}

			private void kpszNdttNohjQuiNxeaRTBNpRuM(ActionElementMap P_0)
			{
				if (XwCACyirqdXYnsCPpgSBCfobWMVU(WkDKNFiZiZktrypdHARufyCmdaQF.AYAHddjPpVESViGDmuYMRLDvhRY))
				{
					izAiDVoJXdFVSPjNdPRdejAMrME(WkDKNFiZiZktrypdHARufyCmdaQF.AYAHddjPpVESViGDmuYMRLDvhRY, new InputMappedEventData(TKnWISxZiQPTaIhKpEMkcaWQSuD, P_0));
				}
			}

			private void kiFnvGHBEJOtblARkhFFMTjufvF()
			{
				if (XwCACyirqdXYnsCPpgSBCfobWMVU(WkDKNFiZiZktrypdHARufyCmdaQF.XeZyFjHnFdQqRAAnpvPgyieddymi))
				{
					izAiDVoJXdFVSPjNdPRdejAMrME(WkDKNFiZiZktrypdHARufyCmdaQF.XeZyFjHnFdQqRAAnpvPgyieddymi, new TimedOutEventData(TKnWISxZiQPTaIhKpEMkcaWQSuD));
				}
			}

			private void RZFTBKxBjDeFODCYzoiZeDurmpt(string P_0)
			{
				if (XwCACyirqdXYnsCPpgSBCfobWMVU(WkDKNFiZiZktrypdHARufyCmdaQF.RiXrdYetQWTzGifSHzocCSJcycN))
				{
					izAiDVoJXdFVSPjNdPRdejAMrME(WkDKNFiZiZktrypdHARufyCmdaQF.RiXrdYetQWTzGifSHzocCSJcycN, new ErrorEventData(TKnWISxZiQPTaIhKpEMkcaWQSuD, P_0));
				}
			}

			private void ppvfVFQAWjStMZqBsSdRsXGzYHd(string P_0)
			{
				if (XwCACyirqdXYnsCPpgSBCfobWMVU(WkDKNFiZiZktrypdHARufyCmdaQF.gsOnBSqbBUYqlJKNiABAglhvWSv))
				{
					izAiDVoJXdFVSPjNdPRdejAMrME(WkDKNFiZiZktrypdHARufyCmdaQF.gsOnBSqbBUYqlJKNiABAglhvWSv, new CanceledEventData(TKnWISxZiQPTaIhKpEMkcaWQSuD, P_0));
				}
			}

			private void tFqrZfpKxAtkKLeFnxvvunVqmwv(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				if (XwCACyirqdXYnsCPpgSBCfobWMVU(WkDKNFiZiZktrypdHARufyCmdaQF.DHbPWcBarfSdYSGXfhlpsbMfftN))
				{
					izAiDVoJXdFVSPjNdPRdejAMrME(WkDKNFiZiZktrypdHARufyCmdaQF.DHbPWcBarfSdYSGXfhlpsbMfftN, new ConflictFoundEventData(TKnWISxZiQPTaIhKpEMkcaWQSuD, lfhkDMflIEeplqhooWHBBGLvhXf, P_0, P_1, P_2));
				}
			}

			private void PORaVZQAtpaUOfdQdjPmjveSPCb()
			{
				if (XwCACyirqdXYnsCPpgSBCfobWMVU(WkDKNFiZiZktrypdHARufyCmdaQF.IWncyCTABLmPUmFcHqSuWmnWftk))
				{
					izAiDVoJXdFVSPjNdPRdejAMrME(WkDKNFiZiZktrypdHARufyCmdaQF.IWncyCTABLmPUmFcHqSuWmnWftk, new StartedEventData(TKnWISxZiQPTaIhKpEMkcaWQSuD));
				}
			}

			private void CABKNGbcLNGeIBKINTDfKbDgdcs()
			{
				if (XwCACyirqdXYnsCPpgSBCfobWMVU(WkDKNFiZiZktrypdHARufyCmdaQF.IKeKeAkzWHJtaxOaBYCxMsMwEyQ))
				{
					izAiDVoJXdFVSPjNdPRdejAMrME(WkDKNFiZiZktrypdHARufyCmdaQF.IKeKeAkzWHJtaxOaBYCxMsMwEyQ, new StoppedEventData(TKnWISxZiQPTaIhKpEMkcaWQSuD));
				}
			}

			public void lfhkDMflIEeplqhooWHBBGLvhXf(ConflictResponse P_0)
			{
				if (mHHcGgMiTOBIOIDaaBmmdPgXSEJg != Status.AwaitingResponse || FAlVqZbOCCUhjGnejdOFzcxHzsW != LPCXyMxFdTeYoNxRAHZecnIgcJW.pSTfRDKDzNUmzPNbbGQClJpUFONM)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (CbEgTLnbBMSQyzeOPUqobexIRTm(P_0, NHkmtxylVZGEnWWEFtJmPJZqXEg) == bnygFFDtDbvCGnBnrVJOsISRSxj.nYTbnofafcmwWijpsykpQnAZAmw)
					{
						NINWeNmgTtlOmbJjbmpmTNFVWbT(NHkmtxylVZGEnWWEFtJmPJZqXEg);
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
			internal const string IaxCAvUiTlyGlGfiGSOQwohttvw = "isElementAllowed";

			private bool tzorwTRKjllOLBoxFBsJpzEtKbE = true;

			private bool rcxlbWYpDvOLEcISpFNSDtvhAtz = true;

			private bool xhizYfBxGkGKuOEBuwRpXchcLpW = true;

			private float CaOzyOtWCJdySFngJiIFtOLibJz;

			private bool fpTTuHsMaGnnmqZmeRAtqIqNUOU = true;

			private bool RpjgWGUanJdoMfZnTeiOMcghzan = true;

			private bool XRxDydCmmGMrDELUBMSTLoInAtuD = true;

			private bool ZVvWFgMqPkOgpEAMOClebISPsJM = true;

			private int[] VNrEAXFKgYJtVUHQjiKDfjPOjgJ;

			private ConflictResponse jinGrTfQtyaExXTXUGEpUEhPBmHH = ConflictResponse.Replace;

			private bool aGDBUGhNaIEiNSGuQAQjhIEqlqVa;

			private bool SJMgmzKVXDoWtTyUeLjNIeHdXiG;

			private bool KezmPVztadZrGmUsAHLYeTDetxF = true;

			private bool XbRZaMUtvPkJFlFAzbzfcjjzwWb = true;

			private float yDymIjzXNoZXBaRsSNycyWssYlD = 1f;

			private readonly Dictionary<string, SafeDelegate> fKwfjYboziBwVPmCrPayjlspNcMw = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			[CompilerGenerated]
			private static Action<Exception> CJthRozlPiPZkgiQDbPAQnradBI;

			public bool allowAxes
			{
				get
				{
					return tzorwTRKjllOLBoxFBsJpzEtKbE;
				}
				set
				{
					tzorwTRKjllOLBoxFBsJpzEtKbE = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return rcxlbWYpDvOLEcISpFNSDtvhAtz;
				}
				set
				{
					rcxlbWYpDvOLEcISpFNSDtvhAtz = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return xhizYfBxGkGKuOEBuwRpXchcLpW;
				}
				set
				{
					xhizYfBxGkGKuOEBuwRpXchcLpW = value;
				}
			}

			public float timeout
			{
				get
				{
					return CaOzyOtWCJdySFngJiIFtOLibJz;
				}
				set
				{
					CaOzyOtWCJdySFngJiIFtOLibJz = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return fpTTuHsMaGnnmqZmeRAtqIqNUOU;
				}
				set
				{
					fpTTuHsMaGnnmqZmeRAtqIqNUOU = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return RpjgWGUanJdoMfZnTeiOMcghzan;
				}
				set
				{
					RpjgWGUanJdoMfZnTeiOMcghzan = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return XRxDydCmmGMrDELUBMSTLoInAtuD;
				}
				set
				{
					XRxDydCmmGMrDELUBMSTLoInAtuD = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return ZVvWFgMqPkOgpEAMOClebISPsJM;
				}
				set
				{
					ZVvWFgMqPkOgpEAMOClebISPsJM = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return VNrEAXFKgYJtVUHQjiKDfjPOjgJ;
				}
				set
				{
					VNrEAXFKgYJtVUHQjiKDfjPOjgJ = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return jinGrTfQtyaExXTXUGEpUEhPBmHH;
				}
				set
				{
					jinGrTfQtyaExXTXUGEpUEhPBmHH = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return aGDBUGhNaIEiNSGuQAQjhIEqlqVa;
				}
				set
				{
					aGDBUGhNaIEiNSGuQAQjhIEqlqVa = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return SJMgmzKVXDoWtTyUeLjNIeHdXiG;
				}
				set
				{
					SJMgmzKVXDoWtTyUeLjNIeHdXiG = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return KezmPVztadZrGmUsAHLYeTDetxF;
				}
				set
				{
					KezmPVztadZrGmUsAHLYeTDetxF = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return XbRZaMUtvPkJFlFAzbzfcjjzwWb;
				}
				set
				{
					XbRZaMUtvPkJFlFAzbzfcjjzwWb = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return yDymIjzXNoZXBaRsSNycyWssYlD;
				}
				set
				{
					yDymIjzXNoZXBaRsSNycyWssYlD = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)fKwfjYboziBwVPmCrPayjlspNcMw["isElementAllowed"];
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
					fKwfjYboziBwVPmCrPayjlspNcMw["isElementAllowed"] = safePredicate;
				}
			}

			internal T hwwUwlmTsGSAcoHhsWapHMGwSRz<T>(string P_0) where T : SafeDelegate
			{
				if (!fKwfjYboziBwVPmCrPayjlspNcMw.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as T;
			}

			public Options()
			{
				dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
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
				stringBuilder.Append("allowAxes = " + tzorwTRKjllOLBoxFBsJpzEtKbE + "\n");
				stringBuilder.Append("allowButtons = " + rcxlbWYpDvOLEcISpFNSDtvhAtz + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + xhizYfBxGkGKuOEBuwRpXchcLpW + "\n");
				stringBuilder.Append("timeout = " + CaOzyOtWCJdySFngJiIFtOLibJz + "\n");
				stringBuilder.Append("checkForConflicts = " + fpTTuHsMaGnnmqZmeRAtqIqNUOU + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + RpjgWGUanJdoMfZnTeiOMcghzan + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + XRxDydCmmGMrDELUBMSTLoInAtuD + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + ZVvWFgMqPkOgpEAMOClebISPsJM + "\n");
				if (VNrEAXFKgYJtVUHQjiKDfjPOjgJ == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(VNrEAXFKgYJtVUHQjiKDfjPOjgJ) + "\n");
				}
				stringBuilder.Append(string.Concat("defaultActionWhenConflictFound = ", jinGrTfQtyaExXTXUGEpUEhPBmHH, "\n"));
				stringBuilder.Append("ignoreMouseXAxis = " + aGDBUGhNaIEiNSGuQAQjhIEqlqVa);
				stringBuilder.Append("ignoreMouseYAxis = " + SJMgmzKVXDoWtTyUeLjNIeHdXiG);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + KezmPVztadZrGmUsAHLYeTDetxF + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + XbRZaMUtvPkJFlFAzbzfcjjzwWb + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + yDymIjzXNoZXBaRsSNycyWssYlD + "\n");
				return stringBuilder.ToString();
			}

			internal void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				tzorwTRKjllOLBoxFBsJpzEtKbE = true;
				rcxlbWYpDvOLEcISpFNSDtvhAtz = true;
				xhizYfBxGkGKuOEBuwRpXchcLpW = true;
				CaOzyOtWCJdySFngJiIFtOLibJz = 0f;
				fpTTuHsMaGnnmqZmeRAtqIqNUOU = true;
				RpjgWGUanJdoMfZnTeiOMcghzan = true;
				XRxDydCmmGMrDELUBMSTLoInAtuD = true;
				ZVvWFgMqPkOgpEAMOClebISPsJM = true;
				VNrEAXFKgYJtVUHQjiKDfjPOjgJ = null;
				jinGrTfQtyaExXTXUGEpUEhPBmHH = ConflictResponse.Replace;
				aGDBUGhNaIEiNSGuQAQjhIEqlqVa = false;
				SJMgmzKVXDoWtTyUeLjNIeHdXiG = false;
				KezmPVztadZrGmUsAHLYeTDetxF = true;
				XbRZaMUtvPkJFlFAzbzfcjjzwWb = true;
				yDymIjzXNoZXBaRsSNycyWssYlD = 1f;
				List<string> list = new List<string>(fKwfjYboziBwVPmCrPayjlspNcMw.Keys);
				foreach (string item in list)
				{
					fKwfjYboziBwVPmCrPayjlspNcMw[item] = null;
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
				destination.tzorwTRKjllOLBoxFBsJpzEtKbE = source.tzorwTRKjllOLBoxFBsJpzEtKbE;
				destination.rcxlbWYpDvOLEcISpFNSDtvhAtz = source.rcxlbWYpDvOLEcISpFNSDtvhAtz;
				destination.xhizYfBxGkGKuOEBuwRpXchcLpW = source.xhizYfBxGkGKuOEBuwRpXchcLpW;
				destination.CaOzyOtWCJdySFngJiIFtOLibJz = source.CaOzyOtWCJdySFngJiIFtOLibJz;
				destination.fpTTuHsMaGnnmqZmeRAtqIqNUOU = source.fpTTuHsMaGnnmqZmeRAtqIqNUOU;
				destination.RpjgWGUanJdoMfZnTeiOMcghzan = source.RpjgWGUanJdoMfZnTeiOMcghzan;
				destination.XRxDydCmmGMrDELUBMSTLoInAtuD = source.XRxDydCmmGMrDELUBMSTLoInAtuD;
				destination.ZVvWFgMqPkOgpEAMOClebISPsJM = source.ZVvWFgMqPkOgpEAMOClebISPsJM;
				destination.VNrEAXFKgYJtVUHQjiKDfjPOjgJ = ArrayTools.ShallowCopy(source.VNrEAXFKgYJtVUHQjiKDfjPOjgJ);
				destination.jinGrTfQtyaExXTXUGEpUEhPBmHH = source.jinGrTfQtyaExXTXUGEpUEhPBmHH;
				destination.aGDBUGhNaIEiNSGuQAQjhIEqlqVa = source.aGDBUGhNaIEiNSGuQAQjhIEqlqVa;
				destination.SJMgmzKVXDoWtTyUeLjNIeHdXiG = source.SJMgmzKVXDoWtTyUeLjNIeHdXiG;
				destination.KezmPVztadZrGmUsAHLYeTDetxF = source.KezmPVztadZrGmUsAHLYeTDetxF;
				destination.XbRZaMUtvPkJFlFAzbzfcjjzwWb = source.XbRZaMUtvPkJFlFAzbzfcjjzwWb;
				destination.yDymIjzXNoZXBaRsSNycyWssYlD = source.yDymIjzXNoZXBaRsSNycyWssYlD;
				foreach (KeyValuePair<string, SafeDelegate> item in source.fKwfjYboziBwVPmCrPayjlspNcMw)
				{
					destination.fKwfjYboziBwVPmCrPayjlspNcMw[item.Key] = MiscTools.Clone(item.Value);
				}
			}

			[CompilerGenerated]
			private static void TrGyYnYWDOsDxOeBzrlGTsFAWxW(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
			}
		}

		private static InputMapper NsGEioaOmaBNobdbukRVCkFCuYKO;

		private static int sYQDDvhCnrKSolgzMUaGKhazgWJx = 0;

		private readonly int PlelmdDdXfDJygQhpLAQBGklNoO;

		private readonly bool ZqBosQHDrLLuSXQQwoEdYhuDCRM;

		private readonly zDZQuIoVFVdXmnnoKtESLOhfdIj BwdbszCgJFrtbrILAWZtumbwfwAa;

		private Options QMFPjRsTYvchhgHfSNxIfTPWAky;

		private readonly Dictionary<WkDKNFiZiZktrypdHARufyCmdaQF, SafeDelegate> xZDHLzcaKIsgGcrUCsXHdwSNtaR = new Dictionary<WkDKNFiZiZktrypdHARufyCmdaQF, SafeDelegate>
		{
			{
				WkDKNFiZiZktrypdHARufyCmdaQF.AYAHddjPpVESViGDmuYMRLDvhRY,
				new SafeAction<InputMappedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
				})
			},
			{
				WkDKNFiZiZktrypdHARufyCmdaQF.RiXrdYetQWTzGifSHzocCSJcycN,
				new SafeAction<ErrorEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
				})
			},
			{
				WkDKNFiZiZktrypdHARufyCmdaQF.gsOnBSqbBUYqlJKNiABAglhvWSv,
				new SafeAction<CanceledEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
				})
			},
			{
				WkDKNFiZiZktrypdHARufyCmdaQF.XeZyFjHnFdQqRAAnpvPgyieddymi,
				new SafeAction<TimedOutEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
				})
			},
			{
				WkDKNFiZiZktrypdHARufyCmdaQF.IWncyCTABLmPUmFcHqSuWmnWftk,
				new SafeAction<StartedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
				})
			},
			{
				WkDKNFiZiZktrypdHARufyCmdaQF.IKeKeAkzWHJtaxOaBYCxMsMwEyQ,
				new SafeAction<StoppedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
				})
			},
			{
				WkDKNFiZiZktrypdHARufyCmdaQF.DHbPWcBarfSdYSGXfhlpsbMfftN,
				new SafeAction<ConflictFoundEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
				})
			}
		};

		[CompilerGenerated]
		private static Action<Exception> clDYovXIRuFfiYxZQzgxFAfNhHE;

		[CompilerGenerated]
		private static Action<Exception> GMUjmsdqRVqHRAZkBEOFiCKrAlO;

		[CompilerGenerated]
		private static Action<Exception> xWtfVpEAAEIKKdpVATSjOZuqaKin;

		[CompilerGenerated]
		private static Action<Exception> CuxsraehqcBBnFzwaUhfNpVJmUD;

		[CompilerGenerated]
		private static Action<Exception> ohFNtQgufMrUlDPMHEjeyWNlCrmj;

		[CompilerGenerated]
		private static Action<Exception> VbWBeYhyXOxlSVXrgfsxXKbeIWM;

		[CompilerGenerated]
		private static Action<Exception> EudIHqBtECzYpNADrIYxshPgjtH;

		public static InputMapper Default => NsGEioaOmaBNobdbukRVCkFCuYKO ?? (NsGEioaOmaBNobdbukRVCkFCuYKO = new InputMapper(isDefault: true));

		public Options options
		{
			get
			{
				Options obj = QMFPjRsTYvchhgHfSNxIfTPWAky;
				if (obj == null)
				{
					if (!ZqBosQHDrLLuSXQQwoEdYhuDCRM)
					{
						return QMFPjRsTYvchhgHfSNxIfTPWAky = Default.options.Clone();
					}
					obj = (QMFPjRsTYvchhgHfSNxIfTPWAky = new Options());
				}
				return obj;
			}
			set
			{
				QMFPjRsTYvchhgHfSNxIfTPWAky = value;
			}
		}

		public Context mappingContext => BwdbszCgJFrtbrILAWZtumbwfwAa.context;

		public Status status => BwdbszCgJFrtbrILAWZtumbwfwAa.status;

		public float timeRemaining => BwdbszCgJFrtbrILAWZtumbwfwAa.timeRemaining;

		internal int id => PlelmdDdXfDJygQhpLAQBGklNoO;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.AYAHddjPpVESViGDmuYMRLDvhRY;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<InputMappedEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.AYAHddjPpVESViGDmuYMRLDvhRY;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<InputMappedEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.RiXrdYetQWTzGifSHzocCSJcycN;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<ErrorEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.RiXrdYetQWTzGifSHzocCSJcycN;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<ErrorEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.gsOnBSqbBUYqlJKNiABAglhvWSv;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<CanceledEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.gsOnBSqbBUYqlJKNiABAglhvWSv;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<CanceledEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.XeZyFjHnFdQqRAAnpvPgyieddymi;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<TimedOutEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.XeZyFjHnFdQqRAAnpvPgyieddymi;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<TimedOutEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.IWncyCTABLmPUmFcHqSuWmnWftk;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<StartedEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.IWncyCTABLmPUmFcHqSuWmnWftk;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<StartedEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.IKeKeAkzWHJtaxOaBYCxMsMwEyQ;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<StoppedEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.IKeKeAkzWHJtaxOaBYCxMsMwEyQ;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<StoppedEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.DHbPWcBarfSdYSGXfhlpsbMfftN;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<ConflictFoundEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					WkDKNFiZiZktrypdHARufyCmdaQF key = WkDKNFiZiZktrypdHARufyCmdaQF.DHbPWcBarfSdYSGXfhlpsbMfftN;
					xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] = (SafeAction<ConflictFoundEventData>)xZDHLzcaKIsgGcrUCsXHdwSNtaR[key] - value;
				}
			}
		}

		private static int eugCYxVqcvgjSwFPhmOiuhRgtVm()
		{
			int result = sYQDDvhCnrKSolgzMUaGKhazgWJx;
			if (sYQDDvhCnrKSolgzMUaGKhazgWJx == int.MaxValue)
			{
				sYQDDvhCnrKSolgzMUaGKhazgWJx = 0;
			}
			else
			{
				sYQDDvhCnrKSolgzMUaGKhazgWJx++;
			}
			return result;
		}

		public InputMapper()
			: this(isDefault: false)
		{
			PlelmdDdXfDJygQhpLAQBGklNoO = eugCYxVqcvgjSwFPhmOiuhRgtVm();
		}

		private InputMapper(bool isDefault)
		{
			ZqBosQHDrLLuSXQQwoEdYhuDCRM = isDefault;
			if (ZqBosQHDrLLuSXQQwoEdYhuDCRM)
			{
				QMFPjRsTYvchhgHfSNxIfTPWAky = new Options();
			}
			BwdbszCgJFrtbrILAWZtumbwfwAa = new zDZQuIoVFVdXmnnoKtESLOhfdIj(this, xZDHLzcaKIsgGcrUCsXHdwSNtaR);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<WkDKNFiZiZktrypdHARufyCmdaQF, SafeDelegate> item in xZDHLzcaKIsgGcrUCsXHdwSNtaR)
			{
				item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<WkDKNFiZiZktrypdHARufyCmdaQF, SafeDelegate> item in xZDHLzcaKIsgGcrUCsXHdwSNtaR)
			{
				item.Value.Clear();
			}
		}

		internal void fNDFPMmLJsSzDjeijYZpPlJARYy(object P_0)
		{
		}

		internal void RaiBqtSrdQruqYOqINGxbSDIqAb()
		{
		}

		public bool Start(Context mappingContext)
		{
			return PUfBGkQEoKKPRrTrZNGGdNNSToS(mappingContext, (QMFPjRsTYvchhgHfSNxIfTPWAky != null) ? QMFPjRsTYvchhgHfSNxIfTPWAky : Default.options);
		}

		public void Stop()
		{
			BwdbszCgJFrtbrILAWZtumbwfwAa.LZHqaCebyKfwGdPvSMfYlTrzOGyO("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			RaiBqtSrdQruqYOqINGxbSDIqAb();
			QMFPjRsTYvchhgHfSNxIfTPWAky = null;
		}

		private bool PUfBGkQEoKKPRrTrZNGGdNNSToS(Context P_0, Options P_1)
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
				BwdbszCgJFrtbrILAWZtumbwfwAa.PUfBGkQEoKKPRrTrZNGGdNNSToS(P_0, P_1);
				return true;
			}
			catch
			{
				BwdbszCgJFrtbrILAWZtumbwfwAa.LZHqaCebyKfwGdPvSMfYlTrzOGyO("Failed to start due to an exception.");
				return false;
			}
		}

		[CompilerGenerated]
		private static void vdDPquUVhIygxunWnvPcgIvBxCP(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
		}

		[CompilerGenerated]
		private static void GVnqNLNJumCigNUfxLKlLJWjhoO(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
		}

		[CompilerGenerated]
		private static void zNxksABFhJnoBRTGjiDxpmVwYch(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
		}

		[CompilerGenerated]
		private static void SzGEIICPVFTVuPujqAkoIabHBFEO(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
		}

		[CompilerGenerated]
		private static void ygPbZfhOeeXZltGgUfNUIYKVCc(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
		}

		[CompilerGenerated]
		private static void cJIikxaUDJGYTjUVGFEFhDZFfRG(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
		}

		[CompilerGenerated]
		private static void ogJflSISCqWfuQbWjjlGGHjttils(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
		}
	}
}
