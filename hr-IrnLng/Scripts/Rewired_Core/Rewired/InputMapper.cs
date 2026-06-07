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
			private int CYBGYVfPDvCydagiBzJBExAfcuYb = -1;

			private ControllerMap fcPcTXdclCfFXHGkwVhNNBHdQNBk;

			private ActionElementMap QpHroVcBAvIEspKwhjviMOfxHIc;

			private AxisRange ajshIzfUwAeDCOeWaOMdzmrpLvn = AxisRange.Positive;

			private bool KwHYBxmBgLcIKzGXjrgdMieHfpr;

			public int actionId
			{
				get
				{
					return CYBGYVfPDvCydagiBzJBExAfcuYb;
				}
				set
				{
					if (!KlYkmqGtnfiHkXFiBnZqEISfKLp())
					{
						CYBGYVfPDvCydagiBzJBExAfcuYb = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(CYBGYVfPDvCydagiBzJBExAfcuYb);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!KlYkmqGtnfiHkXFiBnZqEISfKLp())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							CYBGYVfPDvCydagiBzJBExAfcuYb = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							CYBGYVfPDvCydagiBzJBExAfcuYb = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return fcPcTXdclCfFXHGkwVhNNBHdQNBk;
				}
				set
				{
					if (!KlYkmqGtnfiHkXFiBnZqEISfKLp())
					{
						fcPcTXdclCfFXHGkwVhNNBHdQNBk = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return QpHroVcBAvIEspKwhjviMOfxHIc;
				}
				set
				{
					if (!KlYkmqGtnfiHkXFiBnZqEISfKLp())
					{
						QpHroVcBAvIEspKwhjviMOfxHIc = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return ajshIzfUwAeDCOeWaOMdzmrpLvn;
				}
				set
				{
					if (!KlYkmqGtnfiHkXFiBnZqEISfKLp())
					{
						ajshIzfUwAeDCOeWaOMdzmrpLvn = value;
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

			internal void FlxqEpocWvmqCSUCWDljYZWesMc()
			{
				KwHYBxmBgLcIKzGXjrgdMieHfpr = true;
			}

			private bool KlYkmqGtnfiHkXFiBnZqEISfKLp()
			{
				if (KwHYBxmBgLcIKzGXjrgdMieHfpr)
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
				destination.CYBGYVfPDvCydagiBzJBExAfcuYb = source.CYBGYVfPDvCydagiBzJBExAfcuYb;
				destination.fcPcTXdclCfFXHGkwVhNNBHdQNBk = source.fcPcTXdclCfFXHGkwVhNNBHdQNBk;
				destination.QpHroVcBAvIEspKwhjviMOfxHIc = source.QpHroVcBAvIEspKwhjviMOfxHIc;
				destination.ajshIzfUwAeDCOeWaOMdzmrpLvn = source.ajshIzfUwAeDCOeWaOMdzmrpLvn;
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

		private enum qAvbcrAPTAsIdIdPWwRjlszKHosK
		{
			iVagMPQPsAhOEnIgnfwBTBghcvnf = 0,
			lUheQgkFbLQKQEdieYahYEkjWepw = 1,
			AIibOmPrwZKrnWTnbLOLmOCVeMJd = 2,
			tynisJilcqdJDLCHqrLbihJRVmK = 3,
			mCLBDicObUFJYzKpQhmpeWXqMxMU = 4,
			eAWbPiKFrWXIsIiKAlGssAvUdcaG = 5,
			dOVcnScAHwjRWTyhybbgsqlDbQr = 6
		}

		public enum Status
		{
			Idle = 0,
			Listening = 1,
			AwaitingResponse = 2
		}

		private class TavEBkePwEzmiEcYFdQZNHCJuWLD
		{
			private enum UpocTiIfqofGCVDtGdxSrZveNOqV
			{
				JEOIyDGudFFgqCSWHRUzTDJaDWTi = 0,
				BIrMAKXFUpbFUabBrlwyDYbEtiGZ = 1
			}

			private enum LBBgxbSJuRfBMsqqVJjKwskLThU
			{
				xHdBaRgdNDZThJOvnpmpFtvdLIun = 0,
				VwlqclaxWKpZxMQVmsSPTqUmNGr = 1
			}

			private class fDUiThhfaboRRHTPMhhysIVeQNk
			{
				private Player UoLXbrXQwBeLviIASurDpYTunPn;

				private int CYBGYVfPDvCydagiBzJBExAfcuYb;

				private Context JuQRLlwJkIFiWVJJEUKJrbjxdeQ;

				private ControllerType VkxeQjDVSfumjFSZdzmQHhgPgAwE;

				private int HOfXKstauKwTqpMsyTWXViZIbgl;

				private ControllerPollingInfo VjWRkiRVrvOlqnoPqCTFizqcoAu;

				private ModifierKeyFlags wDaZeqSOupdtjqsnOLPLLqlYXsh;

				public Player player => UoLXbrXQwBeLviIASurDpYTunPn;

				public int actionId => CYBGYVfPDvCydagiBzJBExAfcuYb;

				public Context mappingContext => JuQRLlwJkIFiWVJJEUKJrbjxdeQ;

				public ControllerType controllerType => VkxeQjDVSfumjFSZdzmQHhgPgAwE;

				public int controllerId => HOfXKstauKwTqpMsyTWXViZIbgl;

				public ControllerPollingInfo pollingInfo => VjWRkiRVrvOlqnoPqCTFizqcoAu;

				public ModifierKeyFlags modifierKeyFlags => wDaZeqSOupdtjqsnOLPLLqlYXsh;

				public AxisRange axisRange
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (pollingInfo.elementType == ControllerElementType.Axis)
						{
							result = ((JuQRLlwJkIFiWVJJEUKJrbjxdeQ.actionRange != AxisRange.Full) ? ((pollingInfo.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
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

				public void iDBXctPcOcjjzWbKaCnxuPiVNUc(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					VcHhfbFqwxAmqhwBHKVJpDjlfufe();
					UoLXbrXQwBeLviIASurDpYTunPn = P_0;
					CYBGYVfPDvCydagiBzJBExAfcuYb = P_1.actionId;
					VkxeQjDVSfumjFSZdzmQHhgPgAwE = P_1.controllerMap.controllerType;
					HOfXKstauKwTqpMsyTWXViZIbgl = P_1.controllerMap.controllerId;
					JuQRLlwJkIFiWVJJEUKJrbjxdeQ = P_1;
					VkxeQjDVSfumjFSZdzmQHhgPgAwE = P_1.controllerMap.controllerType;
					HOfXKstauKwTqpMsyTWXViZIbgl = P_1.controllerMap.controllerId;
					P_1.FlxqEpocWvmqCSUCWDljYZWesMc();
				}

				public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
				{
					UoLXbrXQwBeLviIASurDpYTunPn = null;
					CYBGYVfPDvCydagiBzJBExAfcuYb = -1;
					JuQRLlwJkIFiWVJJEUKJrbjxdeQ = null;
					VkxeQjDVSfumjFSZdzmQHhgPgAwE = ControllerType.Keyboard;
					HOfXKstauKwTqpMsyTWXViZIbgl = -1;
					VjWRkiRVrvOlqnoPqCTFizqcoAu = default(ControllerPollingInfo);
					wDaZeqSOupdtjqsnOLPLLqlYXsh = ModifierKeyFlags.None;
				}

				public ElementAssignment vbvDivjMjnnAUjUxitslikfgFHib(ControllerPollingInfo P_0)
				{
					VjWRkiRVrvOlqnoPqCTFizqcoAu = P_0;
					return vbvDivjMjnnAUjUxitslikfgFHib();
				}

				public ElementAssignment vbvDivjMjnnAUjUxitslikfgFHib(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					VjWRkiRVrvOlqnoPqCTFizqcoAu = P_0;
					wDaZeqSOupdtjqsnOLPLLqlYXsh = P_1;
					return vbvDivjMjnnAUjUxitslikfgFHib();
				}

				public ElementAssignment vbvDivjMjnnAUjUxitslikfgFHib()
				{
					return new ElementAssignment(controllerType, VjWRkiRVrvOlqnoPqCTFizqcoAu.elementType, VjWRkiRVrvOlqnoPqCTFizqcoAu.elementIdentifierId, axisRange, VjWRkiRVrvOlqnoPqCTFizqcoAu.keyboardKey, wDaZeqSOupdtjqsnOLPLLqlYXsh, CYBGYVfPDvCydagiBzJBExAfcuYb, (JuQRLlwJkIFiWVJJEUKJrbjxdeQ.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, invert: false, (JuQRLlwJkIFiWVJJEUKJrbjxdeQ.actionElementMapToReplace != null) ? JuQRLlwJkIFiWVJJEUKJrbjxdeQ.actionElementMapToReplace.id : (-1));
				}
			}

			private readonly InputMapper lNLlpcURMXkCiVBaiOQpguboCVx;

			private readonly Options kzdbGtaZbalKjNjNPilFCboBqiCU = new Options();

			private readonly fDUiThhfaboRRHTPMhhysIVeQNk CPcSoYBOrraoMGQsEJcgmzqjfsv = new fDUiThhfaboRRHTPMhhysIVeQNk();

			private readonly Dictionary<qAvbcrAPTAsIdIdPWwRjlszKHosK, SafeDelegate> ZgjzgPJrjPGZKdXiJjDEttxhQkd;

			private readonly Dictionary<string, SafeDelegate> NTYNGoTQOzFJZrckuhupCfFBdqcb;

			private Status SrvZYNxktLlImNGCfsAbTVvfSIb;

			private LBBgxbSJuRfBMsqqVJjKwskLThU fNFgZnCSpDQYdZfUmCVGnyMhshk;

			private double DCnGtoEqXXFJULpgdrXRbfCHyGIM;

			private bool bImQXrGLJydfUEMvxRVRDaWRUaG;

			private List<Player> rQSDhaUigfhxurjHGJcvRadBJZnc = new List<Player>();

			private readonly List<ControllerPollingInfo> MgVcyqCtvEGJKlUbBVPtnXqKXvA = new List<ControllerPollingInfo>();

			private ElementAssignment pyYBCTFXeEHjfTVkStPlCHmIJMIj;

			public Status status => SrvZYNxktLlImNGCfsAbTVvfSIb;

			public float timeRemaining
			{
				get
				{
					if (SrvZYNxktLlImNGCfsAbTVvfSIb == Status.Idle)
					{
						return 0f;
					}
					if (kzdbGtaZbalKjNjNPilFCboBqiCU.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, DCnGtoEqXXFJULpgdrXRbfCHyGIM + (double)kzdbGtaZbalKjNjNPilFCboBqiCU.timeout - ReInput.unscaledTime);
				}
			}

			public Context context
			{
				get
				{
					if (SrvZYNxktLlImNGCfsAbTVvfSIb == Status.Idle)
					{
						return null;
					}
					return CPcSoYBOrraoMGQsEJcgmzqjfsv.mappingContext;
				}
			}

			private bool checkTimer
			{
				get
				{
					if (bImQXrGLJydfUEMvxRVRDaWRUaG)
					{
						return false;
					}
					if (!(kzdbGtaZbalKjNjNPilFCboBqiCU.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public TavEBkePwEzmiEcYFdQZNHCJuWLD(InputMapper parent, Dictionary<qAvbcrAPTAsIdIdPWwRjlszKHosK, SafeDelegate> events)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (events == null)
				{
					throw new ArgumentNullException("events");
				}
				lNLlpcURMXkCiVBaiOQpguboCVx = parent;
				ZgjzgPJrjPGZKdXiJjDEttxhQkd = events;
				qXicwyGusjNQQcYXJuzNZoiogRa();
			}

			~TavEBkePwEzmiEcYFdQZNHCJuWLD()
			{
				IZajRJXNCaJgnMUrNvxXwynHiea();
			}

			public void xNRqfCbZrFcpJcVLMCeHrbgeubc(Context P_0, Options P_1)
			{
				if (SrvZYNxktLlImNGCfsAbTVvfSIb != Status.Idle)
				{
					tqmSbhAREzrLtBGIyatHfpPzMjld("User started a new listening session.");
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
				Options.Copy(P_1, kzdbGtaZbalKjNjNPilFCboBqiCU);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					rwEvSUqnNRCZvarvAxJoHcduIwf("No Action found for actionId: " + P_0.actionId);
					return;
				}
				CPcSoYBOrraoMGQsEJcgmzqjfsv.iDBXctPcOcjjzWbKaCnxuPiVNUc(player, P_0);
				SrvZYNxktLlImNGCfsAbTVvfSIb = Status.Listening;
				zaMEnxzNlEssmDGPyxRaeZFeEWt();
				IRaPzsSlJICPHIjejAbTEtXsbmC();
				yrgFCPHNeEMmcejrcvIktGlrCMfR();
				nxoLdpNQwOXYkdowUjhzuPquJX();
			}

			public void bnnFTcjNZXsFGeCRJSbZuNGLeOQg(string P_0)
			{
				if (SrvZYNxktLlImNGCfsAbTVvfSIb != Status.Idle)
				{
					tqmSbhAREzrLtBGIyatHfpPzMjld(P_0);
				}
			}

			private void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType P_0)
			{
				if (P_0 != UpdateLoopType.Update || SrvZYNxktLlImNGCfsAbTVvfSIb != Status.Listening)
				{
					return;
				}
				if (checkTimer && timeRemaining <= 0f)
				{
					UlIYGyNhZzbHgpxxEAlJPSIvfFT();
					return;
				}
				Controller controller = ReInput.controllers.GetController(CPcSoYBOrraoMGQsEJcgmzqjfsv.controllerType, CPcSoYBOrraoMGQsEJcgmzqjfsv.controllerId);
				ElementAssignment elementAssignment;
				if (controller == null)
				{
					rwEvSUqnNRCZvarvAxJoHcduIwf(string.Concat("Controller not found for type: ", CPcSoYBOrraoMGQsEJcgmzqjfsv.controllerType, " id: ", CPcSoYBOrraoMGQsEJcgmzqjfsv.controllerId));
				}
				else if (TTIobOQmDQBoVLKEBjzpigwrPacE(out elementAssignment) != UpocTiIfqofGCVDtGdxSrZveNOqV.JEOIyDGudFFgqCSWHRUzTDJaDWTi && UwkPBXXpbThkpdBrqhohvprEKUTI(elementAssignment) != UpocTiIfqofGCVDtGdxSrZveNOqV.JEOIyDGudFFgqCSWHRUzTDJaDWTi)
				{
					nBfHTbTscybxyigXkdzzLKmrFpj(elementAssignment);
				}
			}

			private void kRsmLOmlMaRMOrNxWdWeQYoLQoL()
			{
				if (SrvZYNxktLlImNGCfsAbTVvfSIb != Status.Idle)
				{
					qXicwyGusjNQQcYXJuzNZoiogRa();
					IZajRJXNCaJgnMUrNvxXwynHiea();
					enfjViMPXIfWUSKsSZXqERuAmVS();
				}
			}

			private void qXicwyGusjNQQcYXJuzNZoiogRa()
			{
				SrvZYNxktLlImNGCfsAbTVvfSIb = Status.Idle;
				DCnGtoEqXXFJULpgdrXRbfCHyGIM = 0.0;
				kzdbGtaZbalKjNjNPilFCboBqiCU.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				CPcSoYBOrraoMGQsEJcgmzqjfsv.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				pyYBCTFXeEHjfTVkStPlCHmIJMIj = default(ElementAssignment);
				fNFgZnCSpDQYdZfUmCVGnyMhshk = LBBgxbSJuRfBMsqqVJjKwskLThU.xHdBaRgdNDZThJOvnpmpFtvdLIun;
				bImQXrGLJydfUEMvxRVRDaWRUaG = false;
				rQSDhaUigfhxurjHGJcvRadBJZnc.Clear();
			}

			private UpocTiIfqofGCVDtGdxSrZveNOqV TTIobOQmDQBoVLKEBjzpigwrPacE(out ElementAssignment P_0)
			{
				if (!ZbYUbFEjSDJyGnaTkkMiVPqtfDNd(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return UpocTiIfqofGCVDtGdxSrZveNOqV.JEOIyDGudFFgqCSWHRUzTDJaDWTi;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !jVUAzTeTmpJbuegjIaHZFWMXBqvS(item, kzdbGtaZbalKjNjNPilFCboBqiCU))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return UpocTiIfqofGCVDtGdxSrZveNOqV.JEOIyDGudFFgqCSWHRUzTDJaDWTi;
				}
				if (!uFLatBWiPVEkhfNmCzxXihrUnGY(CPcSoYBOrraoMGQsEJcgmzqjfsv, controllerPollingInfo, kzdbGtaZbalKjNjNPilFCboBqiCU))
				{
					P_0 = default(ElementAssignment);
					return UpocTiIfqofGCVDtGdxSrZveNOqV.JEOIyDGudFFgqCSWHRUzTDJaDWTi;
				}
				P_0 = CPcSoYBOrraoMGQsEJcgmzqjfsv.vbvDivjMjnnAUjUxitslikfgFHib(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return UpocTiIfqofGCVDtGdxSrZveNOqV.BIrMAKXFUpbFUabBrlwyDYbEtiGZ;
			}

			private bool ZbYUbFEjSDJyGnaTkkMiVPqtfDNd(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = CPcSoYBOrraoMGQsEJcgmzqjfsv.controllerType;
				int controllerId = CPcSoYBOrraoMGQsEJcgmzqjfsv.controllerId;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = IpxzhpxEkcxNgEMbLMdzEAIMPeJ(out P_1);
					return true;
				}
				if (kzdbGtaZbalKjNjNPilFCboBqiCU.allowAxes)
				{
					if (kzdbGtaZbalKjNjNPilFCboBqiCU.allowButtons)
					{
						if (CPcSoYBOrraoMGQsEJcgmzqjfsv.player != null)
						{
							P_0 = CPcSoYBOrraoMGQsEJcgmzqjfsv.player.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(CPcSoYBOrraoMGQsEJcgmzqjfsv.controllerType, CPcSoYBOrraoMGQsEJcgmzqjfsv.controllerId);
						}
					}
					else if (CPcSoYBOrraoMGQsEJcgmzqjfsv.player != null)
					{
						P_0 = CPcSoYBOrraoMGQsEJcgmzqjfsv.player.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!kzdbGtaZbalKjNjNPilFCboBqiCU.allowButtons)
					{
						rwEvSUqnNRCZvarvAxJoHcduIwf("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (CPcSoYBOrraoMGQsEJcgmzqjfsv.player != null)
					{
						P_0 = CPcSoYBOrraoMGQsEJcgmzqjfsv.player.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> IpxzhpxEkcxNgEMbLMdzEAIMPeJ(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				MgVcyqCtvEGJKlUbBVPtnXqKXvA.Clear();
				if (!kzdbGtaZbalKjNjNPilFCboBqiCU.allowButtons)
				{
					return MgVcyqCtvEGJKlUbBVPtnXqKXvA;
				}
				MgVcyqCtvEGJKlUbBVPtnXqKXvA.Add(yWDDMvhZQneJNQhmNjWVlKrBdMx(kzdbGtaZbalKjNjNPilFCboBqiCU, out P_0));
				return MgVcyqCtvEGJKlUbBVPtnXqKXvA;
			}

			private ControllerPollingInfo yWDDMvhZQneJNQhmNjWVlKrBdMx(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = yWDDMvhZQneJNQhmNjWVlKrBdMx(P_0, out flag, out P_1, out text);
				if (flag)
				{
					zaMEnxzNlEssmDGPyxRaeZFeEWt();
				}
				return result;
			}

			private static ControllerPollingInfo yWDDMvhZQneJNQhmNjWVlKrBdMx(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
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

			private static bool jVUAzTeTmpJbuegjIaHZFWMXBqvS(ControllerPollingInfo P_0, Options P_1)
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
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.HjGJTXRnLBwtsxjXjEywPBxKFFJb<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool uFLatBWiPVEkhfNmCzxXihrUnGY(fDUiThhfaboRRHTPMhhysIVeQNk P_0, ControllerPollingInfo P_1, Options P_2)
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

			private void IRaPzsSlJICPHIjejAbTEtXsbmC()
			{
				if (!kzdbGtaZbalKjNjNPilFCboBqiCU.checkForConflicts)
				{
					return;
				}
				if (kzdbGtaZbalKjNjNPilFCboBqiCU.checkForConflictsWithSelf && CPcSoYBOrraoMGQsEJcgmzqjfsv.player != null)
				{
					ListTools.AddIfUnique(rQSDhaUigfhxurjHGJcvRadBJZnc, CPcSoYBOrraoMGQsEJcgmzqjfsv.player);
				}
				if (kzdbGtaZbalKjNjNPilFCboBqiCU.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(rQSDhaUigfhxurjHGJcvRadBJZnc, ReInput.players.SystemPlayer);
				}
				if (kzdbGtaZbalKjNjNPilFCboBqiCU.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(rQSDhaUigfhxurjHGJcvRadBJZnc, players[i]);
					}
				}
				else
				{
					if (kzdbGtaZbalKjNjNPilFCboBqiCU.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(kzdbGtaZbalKjNjNPilFCboBqiCU.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(rQSDhaUigfhxurjHGJcvRadBJZnc, allPlayers[j]);
						}
					}
				}
			}

			private UpocTiIfqofGCVDtGdxSrZveNOqV UwkPBXXpbThkpdBrqhohvprEKUTI(ElementAssignment P_0)
			{
				if (kzdbGtaZbalKjNjNPilFCboBqiCU.checkForConflicts && CPcSoYBOrraoMGQsEJcgmzqjfsv.player != null && qioBcmPkrbmOtiIVpJzBFcvnCDt(CPcSoYBOrraoMGQsEJcgmzqjfsv, P_0, rQSDhaUigfhxurjHGJcvRadBJZnc))
				{
					return AyalTPVZhZoKpauXsJFljsYcGIv(P_0);
				}
				return UpocTiIfqofGCVDtGdxSrZveNOqV.BIrMAKXFUpbFUabBrlwyDYbEtiGZ;
			}

			private static bool qioBcmPkrbmOtiIVpJzBFcvnCDt(fDUiThhfaboRRHTPMhhysIVeQNk P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.player == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!UvpmRaSbKcdOPLVEzMkHzpbrNqO(P_0, P_1, out var conflictCheck))
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

			private static bool CziSIWpMjOduKsiwCyiuxESJWUJ(fDUiThhfaboRRHTPMhhysIVeQNk P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.player == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!UvpmRaSbKcdOPLVEzMkHzpbrNqO(P_0, P_1, out var conflictCheck))
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

			private static IList<ElementAssignmentConflictInfo> hSicUhdJgvBDlGzKcNSOrWXclSlo(fDUiThhfaboRRHTPMhhysIVeQNk P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.player == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!UvpmRaSbKcdOPLVEzMkHzpbrNqO(P_0, P_1, out var conflictCheck))
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

			private static bool UvpmRaSbKcdOPLVEzMkHzpbrNqO(fDUiThhfaboRRHTPMhhysIVeQNk P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
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

			private static void waTFRqucGiavEOKaxwXQoiNdWqN(fDUiThhfaboRRHTPMhhysIVeQNk P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.player == null)
				{
					return;
				}
				if (!UvpmRaSbKcdOPLVEzMkHzpbrNqO(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void yrgFCPHNeEMmcejrcvIktGlrCMfR()
			{
				ReInput.UpdateEndedEvent -= iAnBBfDdWbgOiFHwNWqxFDtiXzYA;
				ReInput.UpdateEndedEvent += iAnBBfDdWbgOiFHwNWqxFDtiXzYA;
			}

			private void IZajRJXNCaJgnMUrNvxXwynHiea()
			{
				ReInput.UpdateEndedEvent -= iAnBBfDdWbgOiFHwNWqxFDtiXzYA;
			}

			private bool vFullWGoFcPltTudoQOMxuFcDGd(qAvbcrAPTAsIdIdPWwRjlszKHosK P_0)
			{
				SafeDelegate safeDelegate = ZgjzgPJrjPGZKdXiJjDEttxhQkd[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void AgazohBCwwQmSWNriLXkeujiaYu<T>(qAvbcrAPTAsIdIdPWwRjlszKHosK P_0, T P_1)
			{
				SafeAction<T> safeAction = (SafeAction<T>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void zaMEnxzNlEssmDGPyxRaeZFeEWt()
			{
				DCnGtoEqXXFJULpgdrXRbfCHyGIM = ReInput.unscaledTime;
			}

			private void rpTtfddMqjOnePCNCKLwxrnogvK()
			{
				bImQXrGLJydfUEMvxRVRDaWRUaG = true;
			}

			private void gHihFPVqZqFXTLZKkRxGUfTuCDFi(ActionElementMap P_0)
			{
				KcIMeRIuivDACzUtoKmUZlcJxim(P_0);
				kRsmLOmlMaRMOrNxWdWeQYoLQoL();
			}

			private void tqmSbhAREzrLtBGIyatHfpPzMjld(string P_0)
			{
				DPtMnfaxcdxAEAppqKInyzPTWHb(P_0);
				kRsmLOmlMaRMOrNxWdWeQYoLQoL();
			}

			private UpocTiIfqofGCVDtGdxSrZveNOqV AyalTPVZhZoKpauXsJFljsYcGIv(ElementAssignment P_0)
			{
				if (vFullWGoFcPltTudoQOMxuFcDGd(qAvbcrAPTAsIdIdPWwRjlszKHosK.dOVcnScAHwjRWTyhybbgsqlDbQr))
				{
					bool flag = CziSIWpMjOduKsiwCyiuxESJWUJ(CPcSoYBOrraoMGQsEJcgmzqjfsv, P_0, rQSDhaUigfhxurjHGJcvRadBJZnc);
					pyYBCTFXeEHjfTVkStPlCHmIJMIj = P_0;
					IList<ElementAssignmentConflictInfo> list = hSicUhdJgvBDlGzKcNSOrWXclSlo(CPcSoYBOrraoMGQsEJcgmzqjfsv, P_0, rQSDhaUigfhxurjHGJcvRadBJZnc);
					fNFgZnCSpDQYdZfUmCVGnyMhshk = LBBgxbSJuRfBMsqqVJjKwskLThU.VwlqclaxWKpZxMQVmsSPTqUmNGr;
					wmFXwoeHEsbrWjPGnNhSzajIcPhD();
					VcMUrJCIhJhAMUNEadrmkqOKOqIi(new ElementAssignmentInfo(CPcSoYBOrraoMGQsEJcgmzqjfsv.mappingContext.controllerMap, P_0), list, flag);
					return UpocTiIfqofGCVDtGdxSrZveNOqV.JEOIyDGudFFgqCSWHRUzTDJaDWTi;
				}
				return gxuLwbUIyHrvcwamEBEdtKMmWBW(kzdbGtaZbalKjNjNPilFCboBqiCU.defaultActionWhenConflictFound, P_0);
			}

			private UpocTiIfqofGCVDtGdxSrZveNOqV gxuLwbUIyHrvcwamEBEdtKMmWBW(ConflictResponse P_0, ElementAssignment P_1)
			{
				return gxuLwbUIyHrvcwamEBEdtKMmWBW(P_0, P_1, CziSIWpMjOduKsiwCyiuxESJWUJ(CPcSoYBOrraoMGQsEJcgmzqjfsv, P_1, rQSDhaUigfhxurjHGJcvRadBJZnc));
			}

			private UpocTiIfqofGCVDtGdxSrZveNOqV gxuLwbUIyHrvcwamEBEdtKMmWBW(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					tqmSbhAREzrLtBGIyatHfpPzMjld("Mapping assignment was canceled due to a conflict.");
					return UpocTiIfqofGCVDtGdxSrZveNOqV.JEOIyDGudFFgqCSWHRUzTDJaDWTi;
				case ConflictResponse.Replace:
					if (P_2)
					{
						tqmSbhAREzrLtBGIyatHfpPzMjld("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return UpocTiIfqofGCVDtGdxSrZveNOqV.JEOIyDGudFFgqCSWHRUzTDJaDWTi;
					}
					waTFRqucGiavEOKaxwXQoiNdWqN(CPcSoYBOrraoMGQsEJcgmzqjfsv, P_1, rQSDhaUigfhxurjHGJcvRadBJZnc);
					return UpocTiIfqofGCVDtGdxSrZveNOqV.BIrMAKXFUpbFUabBrlwyDYbEtiGZ;
				case ConflictResponse.Add:
					return UpocTiIfqofGCVDtGdxSrZveNOqV.BIrMAKXFUpbFUabBrlwyDYbEtiGZ;
				case ConflictResponse.Ignore:
					razheujEIwNoWDGgxnNmEFFlbLr();
					return UpocTiIfqofGCVDtGdxSrZveNOqV.JEOIyDGudFFgqCSWHRUzTDJaDWTi;
				default:
					throw new NotImplementedException();
				}
			}

			private void UlIYGyNhZzbHgpxxEAlJPSIvfFT()
			{
				WytcYgwttSLjraQplyhOGaMALzf();
				kRsmLOmlMaRMOrNxWdWeQYoLQoL();
			}

			private void rwEvSUqnNRCZvarvAxJoHcduIwf(string P_0)
			{
				zIfuGkQEIOwCCYEawotAkbRRvAL(P_0);
				kRsmLOmlMaRMOrNxWdWeQYoLQoL();
			}

			private void wmFXwoeHEsbrWjPGnNhSzajIcPhD()
			{
				rpTtfddMqjOnePCNCKLwxrnogvK();
				IZajRJXNCaJgnMUrNvxXwynHiea();
				SrvZYNxktLlImNGCfsAbTVvfSIb = Status.AwaitingResponse;
			}

			private void razheujEIwNoWDGgxnNmEFFlbLr()
			{
				SrvZYNxktLlImNGCfsAbTVvfSIb = Status.Listening;
				fNFgZnCSpDQYdZfUmCVGnyMhshk = LBBgxbSJuRfBMsqqVJjKwskLThU.xHdBaRgdNDZThJOvnpmpFtvdLIun;
				zaMEnxzNlEssmDGPyxRaeZFeEWt();
				yrgFCPHNeEMmcejrcvIktGlrCMfR();
			}

			private void nBfHTbTscybxyigXkdzzLKmrFpj(ElementAssignment P_0)
			{
				if (CPcSoYBOrraoMGQsEJcgmzqjfsv.mappingContext.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					gHihFPVqZqFXTLZKkRxGUfTuCDFi(result);
				}
				else
				{
					rwEvSUqnNRCZvarvAxJoHcduIwf("Failed to create element assignment.");
				}
			}

			private void KcIMeRIuivDACzUtoKmUZlcJxim(ActionElementMap P_0)
			{
				if (vFullWGoFcPltTudoQOMxuFcDGd(qAvbcrAPTAsIdIdPWwRjlszKHosK.iVagMPQPsAhOEnIgnfwBTBghcvnf))
				{
					AgazohBCwwQmSWNriLXkeujiaYu(qAvbcrAPTAsIdIdPWwRjlszKHosK.iVagMPQPsAhOEnIgnfwBTBghcvnf, new InputMappedEventData(lNLlpcURMXkCiVBaiOQpguboCVx, P_0));
				}
			}

			private void WytcYgwttSLjraQplyhOGaMALzf()
			{
				if (vFullWGoFcPltTudoQOMxuFcDGd(qAvbcrAPTAsIdIdPWwRjlszKHosK.tynisJilcqdJDLCHqrLbihJRVmK))
				{
					AgazohBCwwQmSWNriLXkeujiaYu(qAvbcrAPTAsIdIdPWwRjlszKHosK.tynisJilcqdJDLCHqrLbihJRVmK, new TimedOutEventData(lNLlpcURMXkCiVBaiOQpguboCVx));
				}
			}

			private void zIfuGkQEIOwCCYEawotAkbRRvAL(string P_0)
			{
				if (vFullWGoFcPltTudoQOMxuFcDGd(qAvbcrAPTAsIdIdPWwRjlszKHosK.lUheQgkFbLQKQEdieYahYEkjWepw))
				{
					AgazohBCwwQmSWNriLXkeujiaYu(qAvbcrAPTAsIdIdPWwRjlszKHosK.lUheQgkFbLQKQEdieYahYEkjWepw, new ErrorEventData(lNLlpcURMXkCiVBaiOQpguboCVx, P_0));
				}
			}

			private void DPtMnfaxcdxAEAppqKInyzPTWHb(string P_0)
			{
				if (vFullWGoFcPltTudoQOMxuFcDGd(qAvbcrAPTAsIdIdPWwRjlszKHosK.AIibOmPrwZKrnWTnbLOLmOCVeMJd))
				{
					AgazohBCwwQmSWNriLXkeujiaYu(qAvbcrAPTAsIdIdPWwRjlszKHosK.AIibOmPrwZKrnWTnbLOLmOCVeMJd, new CanceledEventData(lNLlpcURMXkCiVBaiOQpguboCVx, P_0));
				}
			}

			private void VcMUrJCIhJhAMUNEadrmkqOKOqIi(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				if (vFullWGoFcPltTudoQOMxuFcDGd(qAvbcrAPTAsIdIdPWwRjlszKHosK.dOVcnScAHwjRWTyhybbgsqlDbQr))
				{
					AgazohBCwwQmSWNriLXkeujiaYu(qAvbcrAPTAsIdIdPWwRjlszKHosK.dOVcnScAHwjRWTyhybbgsqlDbQr, new ConflictFoundEventData(lNLlpcURMXkCiVBaiOQpguboCVx, VPJXqOOfRUJjodYlzOWtNkLPFBg, P_0, P_1, P_2));
				}
			}

			private void nxoLdpNQwOXYkdowUjhzuPquJX()
			{
				if (vFullWGoFcPltTudoQOMxuFcDGd(qAvbcrAPTAsIdIdPWwRjlszKHosK.mCLBDicObUFJYzKpQhmpeWXqMxMU))
				{
					AgazohBCwwQmSWNriLXkeujiaYu(qAvbcrAPTAsIdIdPWwRjlszKHosK.mCLBDicObUFJYzKpQhmpeWXqMxMU, new StartedEventData(lNLlpcURMXkCiVBaiOQpguboCVx));
				}
			}

			private void enfjViMPXIfWUSKsSZXqERuAmVS()
			{
				if (vFullWGoFcPltTudoQOMxuFcDGd(qAvbcrAPTAsIdIdPWwRjlszKHosK.eAWbPiKFrWXIsIiKAlGssAvUdcaG))
				{
					AgazohBCwwQmSWNriLXkeujiaYu(qAvbcrAPTAsIdIdPWwRjlszKHosK.eAWbPiKFrWXIsIiKAlGssAvUdcaG, new StoppedEventData(lNLlpcURMXkCiVBaiOQpguboCVx));
				}
			}

			public void VPJXqOOfRUJjodYlzOWtNkLPFBg(ConflictResponse P_0)
			{
				if (SrvZYNxktLlImNGCfsAbTVvfSIb != Status.AwaitingResponse || fNFgZnCSpDQYdZfUmCVGnyMhshk != LBBgxbSJuRfBMsqqVJjKwskLThU.VwlqclaxWKpZxMQVmsSPTqUmNGr)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (gxuLwbUIyHrvcwamEBEdtKMmWBW(P_0, pyYBCTFXeEHjfTVkStPlCHmIJMIj) == UpocTiIfqofGCVDtGdxSrZveNOqV.BIrMAKXFUpbFUabBrlwyDYbEtiGZ)
					{
						nBfHTbTscybxyigXkdzzLKmrFpj(pyYBCTFXeEHjfTVkStPlCHmIJMIj);
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
			internal const string muZzdTbIcknRnTAWDUZFwrCDtKO = "isElementAllowed";

			private bool DwChRvHmAowtJMUPAkPGZvdJPUiY = true;

			private bool PLaYaPfwmPhWKlsaCVPcPSjHtTK = true;

			private bool JREGPpebBpjkLDvtfooQZCqMDex = true;

			private float kFKGgEALfLYJcGSRtsbXzkvvvPd;

			private bool XLnanlLjpNkGkdFlvzVceUFzOEo = true;

			private bool fzXVIgtIpARCOifVCmQTOUDFssD = true;

			private bool ffXSRVvcFVxYDNqaYnGSPwzBlVQ = true;

			private bool vBHbfrbEPrgjoBvuLUAgjshxCyv = true;

			private int[] zZKjxyaPTXsBBjgabsCgzosbdvN;

			private ConflictResponse VsHpWrdtOtRdtOqtFdQsYeOlWij = ConflictResponse.Replace;

			private bool WqlpAgAILRFFXJSKVEsyAFfCcVr;

			private bool oNtRgQdPgULqSMdQFFLcGPZvDRWC;

			private bool aHLXfjWFtmuQRxKiVLJoacGYlCt = true;

			private bool rNhboodzMSuPLuMgscpiiWAJRiF = true;

			private float YQYRmTUqQvaTZzQmXRSbmJEGWoz = 1f;

			private readonly Dictionary<string, SafeDelegate> NTYNGoTQOzFJZrckuhupCfFBdqcb = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			[CompilerGenerated]
			private static Action<Exception> qdLYUyQsQvyakjsHShAZOUUAbQq;

			public bool allowAxes
			{
				get
				{
					return DwChRvHmAowtJMUPAkPGZvdJPUiY;
				}
				set
				{
					DwChRvHmAowtJMUPAkPGZvdJPUiY = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return PLaYaPfwmPhWKlsaCVPcPSjHtTK;
				}
				set
				{
					PLaYaPfwmPhWKlsaCVPcPSjHtTK = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return JREGPpebBpjkLDvtfooQZCqMDex;
				}
				set
				{
					JREGPpebBpjkLDvtfooQZCqMDex = value;
				}
			}

			public float timeout
			{
				get
				{
					return kFKGgEALfLYJcGSRtsbXzkvvvPd;
				}
				set
				{
					kFKGgEALfLYJcGSRtsbXzkvvvPd = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return XLnanlLjpNkGkdFlvzVceUFzOEo;
				}
				set
				{
					XLnanlLjpNkGkdFlvzVceUFzOEo = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return fzXVIgtIpARCOifVCmQTOUDFssD;
				}
				set
				{
					fzXVIgtIpARCOifVCmQTOUDFssD = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return ffXSRVvcFVxYDNqaYnGSPwzBlVQ;
				}
				set
				{
					ffXSRVvcFVxYDNqaYnGSPwzBlVQ = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return vBHbfrbEPrgjoBvuLUAgjshxCyv;
				}
				set
				{
					vBHbfrbEPrgjoBvuLUAgjshxCyv = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return zZKjxyaPTXsBBjgabsCgzosbdvN;
				}
				set
				{
					zZKjxyaPTXsBBjgabsCgzosbdvN = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return VsHpWrdtOtRdtOqtFdQsYeOlWij;
				}
				set
				{
					VsHpWrdtOtRdtOqtFdQsYeOlWij = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return WqlpAgAILRFFXJSKVEsyAFfCcVr;
				}
				set
				{
					WqlpAgAILRFFXJSKVEsyAFfCcVr = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return oNtRgQdPgULqSMdQFFLcGPZvDRWC;
				}
				set
				{
					oNtRgQdPgULqSMdQFFLcGPZvDRWC = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return aHLXfjWFtmuQRxKiVLJoacGYlCt;
				}
				set
				{
					aHLXfjWFtmuQRxKiVLJoacGYlCt = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return rNhboodzMSuPLuMgscpiiWAJRiF;
				}
				set
				{
					rNhboodzMSuPLuMgscpiiWAJRiF = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return YQYRmTUqQvaTZzQmXRSbmJEGWoz;
				}
				set
				{
					YQYRmTUqQvaTZzQmXRSbmJEGWoz = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)NTYNGoTQOzFJZrckuhupCfFBdqcb["isElementAllowed"];
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
					NTYNGoTQOzFJZrckuhupCfFBdqcb["isElementAllowed"] = safePredicate;
				}
			}

			internal T HjGJTXRnLBwtsxjXjEywPBxKFFJb<T>(string P_0) where T : SafeDelegate
			{
				if (!NTYNGoTQOzFJZrckuhupCfFBdqcb.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as T;
			}

			public Options()
			{
				VcHhfbFqwxAmqhwBHKVJpDjlfufe();
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
				stringBuilder.Append("allowAxes = " + DwChRvHmAowtJMUPAkPGZvdJPUiY + "\n");
				stringBuilder.Append("allowButtons = " + PLaYaPfwmPhWKlsaCVPcPSjHtTK + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + JREGPpebBpjkLDvtfooQZCqMDex + "\n");
				stringBuilder.Append("timeout = " + kFKGgEALfLYJcGSRtsbXzkvvvPd + "\n");
				stringBuilder.Append("checkForConflicts = " + XLnanlLjpNkGkdFlvzVceUFzOEo + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + fzXVIgtIpARCOifVCmQTOUDFssD + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + ffXSRVvcFVxYDNqaYnGSPwzBlVQ + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + vBHbfrbEPrgjoBvuLUAgjshxCyv + "\n");
				if (zZKjxyaPTXsBBjgabsCgzosbdvN == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(zZKjxyaPTXsBBjgabsCgzosbdvN) + "\n");
				}
				stringBuilder.Append(string.Concat("defaultActionWhenConflictFound = ", VsHpWrdtOtRdtOqtFdQsYeOlWij, "\n"));
				stringBuilder.Append("ignoreMouseXAxis = " + WqlpAgAILRFFXJSKVEsyAFfCcVr);
				stringBuilder.Append("ignoreMouseYAxis = " + oNtRgQdPgULqSMdQFFLcGPZvDRWC);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + aHLXfjWFtmuQRxKiVLJoacGYlCt + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + rNhboodzMSuPLuMgscpiiWAJRiF + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + YQYRmTUqQvaTZzQmXRSbmJEGWoz + "\n");
				return stringBuilder.ToString();
			}

			internal void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
			{
				DwChRvHmAowtJMUPAkPGZvdJPUiY = true;
				PLaYaPfwmPhWKlsaCVPcPSjHtTK = true;
				JREGPpebBpjkLDvtfooQZCqMDex = true;
				kFKGgEALfLYJcGSRtsbXzkvvvPd = 0f;
				XLnanlLjpNkGkdFlvzVceUFzOEo = true;
				fzXVIgtIpARCOifVCmQTOUDFssD = true;
				ffXSRVvcFVxYDNqaYnGSPwzBlVQ = true;
				vBHbfrbEPrgjoBvuLUAgjshxCyv = true;
				zZKjxyaPTXsBBjgabsCgzosbdvN = null;
				VsHpWrdtOtRdtOqtFdQsYeOlWij = ConflictResponse.Replace;
				WqlpAgAILRFFXJSKVEsyAFfCcVr = false;
				oNtRgQdPgULqSMdQFFLcGPZvDRWC = false;
				aHLXfjWFtmuQRxKiVLJoacGYlCt = true;
				rNhboodzMSuPLuMgscpiiWAJRiF = true;
				YQYRmTUqQvaTZzQmXRSbmJEGWoz = 1f;
				List<string> list = new List<string>(NTYNGoTQOzFJZrckuhupCfFBdqcb.Keys);
				foreach (string item in list)
				{
					NTYNGoTQOzFJZrckuhupCfFBdqcb[item] = null;
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
				destination.DwChRvHmAowtJMUPAkPGZvdJPUiY = source.DwChRvHmAowtJMUPAkPGZvdJPUiY;
				destination.PLaYaPfwmPhWKlsaCVPcPSjHtTK = source.PLaYaPfwmPhWKlsaCVPcPSjHtTK;
				destination.JREGPpebBpjkLDvtfooQZCqMDex = source.JREGPpebBpjkLDvtfooQZCqMDex;
				destination.kFKGgEALfLYJcGSRtsbXzkvvvPd = source.kFKGgEALfLYJcGSRtsbXzkvvvPd;
				destination.XLnanlLjpNkGkdFlvzVceUFzOEo = source.XLnanlLjpNkGkdFlvzVceUFzOEo;
				destination.fzXVIgtIpARCOifVCmQTOUDFssD = source.fzXVIgtIpARCOifVCmQTOUDFssD;
				destination.ffXSRVvcFVxYDNqaYnGSPwzBlVQ = source.ffXSRVvcFVxYDNqaYnGSPwzBlVQ;
				destination.vBHbfrbEPrgjoBvuLUAgjshxCyv = source.vBHbfrbEPrgjoBvuLUAgjshxCyv;
				destination.zZKjxyaPTXsBBjgabsCgzosbdvN = ArrayTools.ShallowCopy(source.zZKjxyaPTXsBBjgabsCgzosbdvN);
				destination.VsHpWrdtOtRdtOqtFdQsYeOlWij = source.VsHpWrdtOtRdtOqtFdQsYeOlWij;
				destination.WqlpAgAILRFFXJSKVEsyAFfCcVr = source.WqlpAgAILRFFXJSKVEsyAFfCcVr;
				destination.oNtRgQdPgULqSMdQFFLcGPZvDRWC = source.oNtRgQdPgULqSMdQFFLcGPZvDRWC;
				destination.aHLXfjWFtmuQRxKiVLJoacGYlCt = source.aHLXfjWFtmuQRxKiVLJoacGYlCt;
				destination.rNhboodzMSuPLuMgscpiiWAJRiF = source.rNhboodzMSuPLuMgscpiiWAJRiF;
				destination.YQYRmTUqQvaTZzQmXRSbmJEGWoz = source.YQYRmTUqQvaTZzQmXRSbmJEGWoz;
				foreach (KeyValuePair<string, SafeDelegate> item in source.NTYNGoTQOzFJZrckuhupCfFBdqcb)
				{
					destination.NTYNGoTQOzFJZrckuhupCfFBdqcb[item.Key] = MiscTools.Clone(item.Value);
				}
			}

			[CompilerGenerated]
			private static void hvyIrTjrcPouvLHxkvEJTxoanpw(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
			}
		}

		private static InputMapper pEcSNMNyRjNgkciRzMRMgPmMISw;

		private static int KBmRqZxgIwbneAzLHYuHBnNFpMhs = 0;

		private readonly int fOQOVXasFwkdwdPkkEjXLhBXuvm;

		private readonly bool zxjdZacwGOLgISdqbOgoGYPhwOa;

		private readonly TavEBkePwEzmiEcYFdQZNHCJuWLD ngHnDVTamOUOhFObDOXuoUWKeqi;

		private Options kzdbGtaZbalKjNjNPilFCboBqiCU;

		private readonly Dictionary<qAvbcrAPTAsIdIdPWwRjlszKHosK, SafeDelegate> ZgjzgPJrjPGZKdXiJjDEttxhQkd = new Dictionary<qAvbcrAPTAsIdIdPWwRjlszKHosK, SafeDelegate>
		{
			{
				qAvbcrAPTAsIdIdPWwRjlszKHosK.iVagMPQPsAhOEnIgnfwBTBghcvnf,
				new SafeAction<InputMappedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
				})
			},
			{
				qAvbcrAPTAsIdIdPWwRjlszKHosK.lUheQgkFbLQKQEdieYahYEkjWepw,
				new SafeAction<ErrorEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
				})
			},
			{
				qAvbcrAPTAsIdIdPWwRjlszKHosK.AIibOmPrwZKrnWTnbLOLmOCVeMJd,
				new SafeAction<CanceledEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
				})
			},
			{
				qAvbcrAPTAsIdIdPWwRjlszKHosK.tynisJilcqdJDLCHqrLbihJRVmK,
				new SafeAction<TimedOutEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
				})
			},
			{
				qAvbcrAPTAsIdIdPWwRjlszKHosK.mCLBDicObUFJYzKpQhmpeWXqMxMU,
				new SafeAction<StartedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
				})
			},
			{
				qAvbcrAPTAsIdIdPWwRjlszKHosK.eAWbPiKFrWXIsIiKAlGssAvUdcaG,
				new SafeAction<StoppedEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
				})
			},
			{
				qAvbcrAPTAsIdIdPWwRjlszKHosK.dOVcnScAHwjRWTyhybbgsqlDbQr,
				new SafeAction<ConflictFoundEventData>(delegate(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
				})
			}
		};

		[CompilerGenerated]
		private static Action<Exception> WhflhTmdbfeimJaZHFpmDZdvwlst;

		[CompilerGenerated]
		private static Action<Exception> cwGOYhKwHMTRlLGgYYcQcxWZbHq;

		[CompilerGenerated]
		private static Action<Exception> ZnRWuXlHbTvfOmxtDBCcTJFUzCG;

		[CompilerGenerated]
		private static Action<Exception> qHBJmKNCVjycjQRAvhwoDOstoTn;

		[CompilerGenerated]
		private static Action<Exception> SntdUsfDSHIjtvOuCbxzDmwiDbGp;

		[CompilerGenerated]
		private static Action<Exception> hXecteAuDBMixCRzxtdbRatMBIs;

		[CompilerGenerated]
		private static Action<Exception> iZryCcsjDQStGUjgKEyckkGrBl;

		public static InputMapper Default => pEcSNMNyRjNgkciRzMRMgPmMISw ?? (pEcSNMNyRjNgkciRzMRMgPmMISw = new InputMapper(isDefault: true));

		public Options options
		{
			get
			{
				Options obj = kzdbGtaZbalKjNjNPilFCboBqiCU;
				if (obj == null)
				{
					if (!zxjdZacwGOLgISdqbOgoGYPhwOa)
					{
						return kzdbGtaZbalKjNjNPilFCboBqiCU = Default.options.Clone();
					}
					obj = (kzdbGtaZbalKjNjNPilFCboBqiCU = new Options());
				}
				return obj;
			}
			set
			{
				kzdbGtaZbalKjNjNPilFCboBqiCU = value;
			}
		}

		public Context mappingContext => ngHnDVTamOUOhFObDOXuoUWKeqi.context;

		public Status status => ngHnDVTamOUOhFObDOXuoUWKeqi.status;

		public float timeRemaining => ngHnDVTamOUOhFObDOXuoUWKeqi.timeRemaining;

		internal int id => fOQOVXasFwkdwdPkkEjXLhBXuvm;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.iVagMPQPsAhOEnIgnfwBTBghcvnf;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<InputMappedEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.iVagMPQPsAhOEnIgnfwBTBghcvnf;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<InputMappedEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.lUheQgkFbLQKQEdieYahYEkjWepw;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<ErrorEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.lUheQgkFbLQKQEdieYahYEkjWepw;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<ErrorEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.AIibOmPrwZKrnWTnbLOLmOCVeMJd;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<CanceledEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.AIibOmPrwZKrnWTnbLOLmOCVeMJd;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<CanceledEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.tynisJilcqdJDLCHqrLbihJRVmK;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<TimedOutEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.tynisJilcqdJDLCHqrLbihJRVmK;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<TimedOutEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.mCLBDicObUFJYzKpQhmpeWXqMxMU;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<StartedEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.mCLBDicObUFJYzKpQhmpeWXqMxMU;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<StartedEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.eAWbPiKFrWXIsIiKAlGssAvUdcaG;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<StoppedEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.eAWbPiKFrWXIsIiKAlGssAvUdcaG;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<StoppedEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.dOVcnScAHwjRWTyhybbgsqlDbQr;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<ConflictFoundEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					qAvbcrAPTAsIdIdPWwRjlszKHosK key = qAvbcrAPTAsIdIdPWwRjlszKHosK.dOVcnScAHwjRWTyhybbgsqlDbQr;
					ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] = (SafeAction<ConflictFoundEventData>)ZgjzgPJrjPGZKdXiJjDEttxhQkd[key] - value;
				}
			}
		}

		private static int KNMxRJeZWiKdGzItoYflumcIFyE()
		{
			int kBmRqZxgIwbneAzLHYuHBnNFpMhs = KBmRqZxgIwbneAzLHYuHBnNFpMhs;
			if (KBmRqZxgIwbneAzLHYuHBnNFpMhs == int.MaxValue)
			{
				KBmRqZxgIwbneAzLHYuHBnNFpMhs = 0;
			}
			else
			{
				KBmRqZxgIwbneAzLHYuHBnNFpMhs++;
			}
			return kBmRqZxgIwbneAzLHYuHBnNFpMhs;
		}

		public InputMapper()
			: this(isDefault: false)
		{
			fOQOVXasFwkdwdPkkEjXLhBXuvm = KNMxRJeZWiKdGzItoYflumcIFyE();
		}

		private InputMapper(bool isDefault)
		{
			zxjdZacwGOLgISdqbOgoGYPhwOa = isDefault;
			if (zxjdZacwGOLgISdqbOgoGYPhwOa)
			{
				kzdbGtaZbalKjNjNPilFCboBqiCU = new Options();
			}
			ngHnDVTamOUOhFObDOXuoUWKeqi = new TavEBkePwEzmiEcYFdQZNHCJuWLD(this, ZgjzgPJrjPGZKdXiJjDEttxhQkd);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<qAvbcrAPTAsIdIdPWwRjlszKHosK, SafeDelegate> item in ZgjzgPJrjPGZKdXiJjDEttxhQkd)
			{
				item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<qAvbcrAPTAsIdIdPWwRjlszKHosK, SafeDelegate> item in ZgjzgPJrjPGZKdXiJjDEttxhQkd)
			{
				item.Value.Clear();
			}
		}

		internal void NKfuamNqghDOVgeYqhJyYBycrIIQ(object P_0)
		{
		}

		internal void fuILBZnbGRHxiRdIBEropgiyUIT()
		{
		}

		public bool Start(Context mappingContext)
		{
			return xNRqfCbZrFcpJcVLMCeHrbgeubc(mappingContext, (kzdbGtaZbalKjNjNPilFCboBqiCU != null) ? kzdbGtaZbalKjNjNPilFCboBqiCU : Default.options);
		}

		public void Stop()
		{
			ngHnDVTamOUOhFObDOXuoUWKeqi.bnnFTcjNZXsFGeCRJSbZuNGLeOQg("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			fuILBZnbGRHxiRdIBEropgiyUIT();
			kzdbGtaZbalKjNjNPilFCboBqiCU = null;
		}

		private bool xNRqfCbZrFcpJcVLMCeHrbgeubc(Context P_0, Options P_1)
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
				ngHnDVTamOUOhFObDOXuoUWKeqi.xNRqfCbZrFcpJcVLMCeHrbgeubc(P_0, P_1);
				return true;
			}
			catch
			{
				ngHnDVTamOUOhFObDOXuoUWKeqi.bnnFTcjNZXsFGeCRJSbZuNGLeOQg("Failed to start due to an exception.");
				return false;
			}
		}

		[CompilerGenerated]
		private static void NqdcTKpAdLRalzDgqnwzkSilbEj(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
		}

		[CompilerGenerated]
		private static void qsNfcdCmDdxXmRWNuNAqiBfXDuaT(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
		}

		[CompilerGenerated]
		private static void HCjRgMcOseABsInvaqUAhgLrSMI(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
		}

		[CompilerGenerated]
		private static void sssQhakJqIyRgpjLbjipiZMtjDg(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
		}

		[CompilerGenerated]
		private static void QtQmyjYGEfXrJmKZnMQKMQjkTYU(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
		}

		[CompilerGenerated]
		private static void QdgHNBFsOSnNZyhuNRGBfoutRyG(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
		}

		[CompilerGenerated]
		private static void OzjoIivafdyAayncyQbPNpQTfyB(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
		}
	}
}
