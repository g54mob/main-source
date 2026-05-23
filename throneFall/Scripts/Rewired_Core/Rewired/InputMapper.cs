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
			private int BTtXuuBdulRurEwHJhYxLXqndLUM = -1;

			private ControllerMap wWQmwqxLPNpqKSgqWgmTIMyeGydJA;

			private ActionElementMap oOZwjhBqBWCotUTPicRUaBEcNXcEA;

			private AxisRange sqWPMmHMNLhyoTLdKxmRHhtGVkMg = AxisRange.Positive;

			private bool xLnAjjagvWOGcfOyxPOlfKkkHJygB;

			public int actionId
			{
				get
				{
					return BTtXuuBdulRurEwHJhYxLXqndLUM;
				}
				set
				{
					if (!bsfnJFLggjjQEkwkIgBKdnXQqZGN())
					{
						BTtXuuBdulRurEwHJhYxLXqndLUM = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(BTtXuuBdulRurEwHJhYxLXqndLUM);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!bsfnJFLggjjQEkwkIgBKdnXQqZGN())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							BTtXuuBdulRurEwHJhYxLXqndLUM = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							BTtXuuBdulRurEwHJhYxLXqndLUM = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return wWQmwqxLPNpqKSgqWgmTIMyeGydJA;
				}
				set
				{
					if (!bsfnJFLggjjQEkwkIgBKdnXQqZGN())
					{
						wWQmwqxLPNpqKSgqWgmTIMyeGydJA = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return oOZwjhBqBWCotUTPicRUaBEcNXcEA;
				}
				set
				{
					if (!bsfnJFLggjjQEkwkIgBKdnXQqZGN())
					{
						oOZwjhBqBWCotUTPicRUaBEcNXcEA = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return sqWPMmHMNLhyoTLdKxmRHhtGVkMg;
				}
				set
				{
					if (!bsfnJFLggjjQEkwkIgBKdnXQqZGN())
					{
						sqWPMmHMNLhyoTLdKxmRHhtGVkMg = value;
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

			internal void FVbKUxSIAoPHtVFOdQyBgMUgYHzk()
			{
				xLnAjjagvWOGcfOyxPOlfKkkHJygB = true;
			}

			private bool bsfnJFLggjjQEkwkIgBKdnXQqZGN()
			{
				if (xLnAjjagvWOGcfOyxPOlfKkkHJygB)
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
				destination.BTtXuuBdulRurEwHJhYxLXqndLUM = source.BTtXuuBdulRurEwHJhYxLXqndLUM;
				destination.wWQmwqxLPNpqKSgqWgmTIMyeGydJA = source.wWQmwqxLPNpqKSgqWgmTIMyeGydJA;
				destination.oOZwjhBqBWCotUTPicRUaBEcNXcEA = source.oOZwjhBqBWCotUTPicRUaBEcNXcEA;
				destination.sqWPMmHMNLhyoTLdKxmRHhtGVkMg = source.sqWPMmHMNLhyoTLdKxmRHhtGVkMg;
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

			private readonly Func<int, bool> rToyCnBsiRpegkhLFNCTpzRXMLVj;

			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				if (rToyCnBsiRpegkhLFNCTpzRXMLVj == null)
				{
					return false;
				}
				return rToyCnBsiRpegkhLFNCTpzRXMLVj(maxInputFieldCount);
			}

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
				: base(P_0)
			{
				responseCallback = P_1;
				assignment = P_2;
				conflicts = P_3;
				isProtected = P_4;
				rToyCnBsiRpegkhLFNCTpzRXMLVj = P_5;
			}
		}

		private enum nsJBvFfLUOFQVYRvInopgMdHhtsuA
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

		private class UyNtIIRFfUgkEdOgZElLCxObMRJNB
		{
			private enum PqvewkbCHmBqMjsosZylNSpqmyZeA
			{
				Quit = 0,
				Continue = 1
			}

			private enum hpNYTQqGmdaltDqLXJhutwIPQcPn
			{
				None = 0,
				ConflictChecking = 1
			}

			private class mYmEVsKKkVhlfnEkXcQcmVLzUmUX
			{
				private Player enQsSsppujbLEICatGGrAwKEdfoZB;

				private int LOAgjLhVhtjelwGbYUIgHFdpaErQA;

				private Context ulLkowuOuzMikLirLRyoYjXqGIVK;

				private ControllerType GAezKshueUEyEythWJRxSecdIwMn;

				private int KVErdjrBnXlliIbdXUaHkNbQCmCeA;

				private ControllerPollingInfo cOsCicRCGVHZpMDcslYHDrPkAWzl;

				private ModifierKeyFlags zRyWpbiDsXiVrCkPdCmPxfacqStI;

				public Player UdmhNYgwLXDtbNodrWkMjvWrnuhGA => enQsSsppujbLEICatGGrAwKEdfoZB;

				public int bNDFbGIwdmuRACovIGmKYSqLDVlaA => LOAgjLhVhtjelwGbYUIgHFdpaErQA;

				public Context okmSapBExYCwPEZVthtdSHWAHbtr => ulLkowuOuzMikLirLRyoYjXqGIVK;

				public ControllerType FPMqyLhTMXlkijzQwymWsmkWtkod => GAezKshueUEyEythWJRxSecdIwMn;

				public int LIqpCRWAWCPieETsNqLkYKhTZpAX => KVErdjrBnXlliIbdXUaHkNbQCmCeA;

				public ControllerPollingInfo nCCMpmnqchAroGkZrnNCKBWTAIXt => cOsCicRCGVHZpMDcslYHDrPkAWzl;

				public ModifierKeyFlags gnNtiKxhkMDXICnUplnmqNJOXrDOA => zRyWpbiDsXiVrCkPdCmPxfacqStI;

				public AxisRange cdfaUYWuXiXzhItVHOJjWlIFhJAh
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (nCCMpmnqchAroGkZrnNCKBWTAIXt.elementType == ControllerElementType.Axis)
						{
							result = ((ulLkowuOuzMikLirLRyoYjXqGIVK.actionRange != AxisRange.Full) ? ((nCCMpmnqchAroGkZrnNCKBWTAIXt.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
						}
						return result;
					}
				}

				public string jvonXJgZgGWmJrTHDDGnsOomknFV
				{
					get
					{
						if (FPMqyLhTMXlkijzQwymWsmkWtkod == ControllerType.Keyboard && gnNtiKxhkMDXICnUplnmqNJOXrDOA != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(gnNtiKxhkMDXICnUplnmqNJOXrDOA)} + {nCCMpmnqchAroGkZrnNCKBWTAIXt.elementIdentifierName}";
						}
						string text = nCCMpmnqchAroGkZrnNCKBWTAIXt.elementIdentifierName;
						if (nCCMpmnqchAroGkZrnNCKBWTAIXt.elementType == ControllerElementType.Axis)
						{
							if (cdfaUYWuXiXzhItVHOJjWlIFhJAh == AxisRange.Positive)
							{
								text += " +";
							}
							else if (cdfaUYWuXiXzhItVHOJjWlIFhJAh == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				public void OBcGfcCmyhhMSxKMTjfOCdzeZQyJb(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					HDHClSvBEYYkvcankRyTbxFSjRif();
					enQsSsppujbLEICatGGrAwKEdfoZB = P_0;
					LOAgjLhVhtjelwGbYUIgHFdpaErQA = P_1.actionId;
					GAezKshueUEyEythWJRxSecdIwMn = P_1.controllerMap.controllerType;
					KVErdjrBnXlliIbdXUaHkNbQCmCeA = P_1.controllerMap.controllerId;
					ulLkowuOuzMikLirLRyoYjXqGIVK = P_1;
					GAezKshueUEyEythWJRxSecdIwMn = P_1.controllerMap.controllerType;
					KVErdjrBnXlliIbdXUaHkNbQCmCeA = P_1.controllerMap.controllerId;
					P_1.FVbKUxSIAoPHtVFOdQyBgMUgYHzk();
				}

				public void HDHClSvBEYYkvcankRyTbxFSjRif()
				{
					enQsSsppujbLEICatGGrAwKEdfoZB = null;
					LOAgjLhVhtjelwGbYUIgHFdpaErQA = -1;
					ulLkowuOuzMikLirLRyoYjXqGIVK = null;
					GAezKshueUEyEythWJRxSecdIwMn = ControllerType.Keyboard;
					KVErdjrBnXlliIbdXUaHkNbQCmCeA = -1;
					cOsCicRCGVHZpMDcslYHDrPkAWzl = default(ControllerPollingInfo);
					zRyWpbiDsXiVrCkPdCmPxfacqStI = ModifierKeyFlags.None;
				}

				public ElementAssignment QjSXXBTvEHFoAwdLJpogmcXOHxsi(ControllerPollingInfo P_0)
				{
					cOsCicRCGVHZpMDcslYHDrPkAWzl = P_0;
					return LlZbPZhavzOLHgzvOcJjanmVALmQ();
				}

				public ElementAssignment mJTkTfwqHiJuaqIalvXHZXqWnawW(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					cOsCicRCGVHZpMDcslYHDrPkAWzl = P_0;
					zRyWpbiDsXiVrCkPdCmPxfacqStI = P_1;
					return LlZbPZhavzOLHgzvOcJjanmVALmQ();
				}

				public ElementAssignment LlZbPZhavzOLHgzvOcJjanmVALmQ()
				{
					return new ElementAssignment(FPMqyLhTMXlkijzQwymWsmkWtkod, cOsCicRCGVHZpMDcslYHDrPkAWzl.elementType, cOsCicRCGVHZpMDcslYHDrPkAWzl.elementIdentifierId, cdfaUYWuXiXzhItVHOJjWlIFhJAh, cOsCicRCGVHZpMDcslYHDrPkAWzl.keyboardKey, zRyWpbiDsXiVrCkPdCmPxfacqStI, LOAgjLhVhtjelwGbYUIgHFdpaErQA, (ulLkowuOuzMikLirLRyoYjXqGIVK.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (ulLkowuOuzMikLirLRyoYjXqGIVK.actionElementMapToReplace != null) ? ulLkowuOuzMikLirLRyoYjXqGIVK.actionElementMapToReplace.id : (-1));
				}
			}

			private sealed class BWPbBiUSCXNRCvRxJwqZJMGLclWG
			{
				public ActionElementMap zuAyYqejENcUqXgMiXnmsijyoYMR;

				internal bool qEeRuHOGBlFBATtfkyfFyiMXALCt(ElementAssignmentConflictInfo P_0)
				{
					return P_0.elementMapId == zuAyYqejENcUqXgMiXnmsijyoYMR.id;
				}
			}

			private sealed class NJucsCAVZONoaMGTyizoFKvJGrPs
			{
				public UyNtIIRFfUgkEdOgZElLCxObMRJNB HBBnRfIdaZWIiZzhuRHUxzUfKWMB;

				public ElementAssignmentInfo PJFPEvgaKeueBmrRGsSAjowtxDnW;

				public IList<ElementAssignmentConflictInfo> sViXaJwSOzEiqyKWkzpewCLzOgdt;

				public bool vmpbbeAdkZjfAtCfsSiXsPjlbOZe;

				internal bool lcLvEFyGMJwdUrMVCEWNlagxhaDEA(int P_0)
				{
					return HBBnRfIdaZWIiZzhuRHUxzUfKWMB.qqYhgmfycFgPnyhTYofzixlEAVCY(PJFPEvgaKeueBmrRGsSAjowtxDnW, sViXaJwSOzEiqyKWkzpewCLzOgdt, vmpbbeAdkZjfAtCfsSiXsPjlbOZe, P_0);
				}
			}

			private readonly InputMapper cXGzDTfYjTAJVRqyTNTfyrnYLnsn;

			private readonly Options teXXDMZGYPvdDPSBLYuqRlxTOLgX = new Options();

			private readonly mYmEVsKKkVhlfnEkXcQcmVLzUmUX WQekEZRFmZycqfafHVzGduNKdFgh = new mYmEVsKKkVhlfnEkXcQcmVLzUmUX();

			private readonly Dictionary<nsJBvFfLUOFQVYRvInopgMdHhtsuA, SafeDelegate> vmUGoRcXompMelLZjpGbIBEfeokvB;

			private readonly Dictionary<string, SafeDelegate> jbNxTkRyfXgfpJEBsNnrJSnTFPgx;

			private Status IHeywmcvDFrEYmhfAHEKJcLkpQkP;

			private hpNYTQqGmdaltDqLXJhutwIPQcPn ZvyeRusfiaFighTpEtCPospIHhrbb;

			private double wQjEQhaqsBIIJtnNXHjpHRKjKRcRA;

			private bool WXpfCfruvZsyikGYWxlLwmqJqSeG;

			private List<Player> WtJlnupRZtakiYOhKmASFdwBZLSb = new List<Player>();

			private readonly List<ControllerPollingInfo> OAMaIEwlkVRPeJJGfQohcleGOCXJ = new List<ControllerPollingInfo>();

			private ElementAssignment ZsQYwRIHfDeRczNCbdXxhvusAiCd;

			public Status pojLdUsdRZdyfhaEmnUrWqBprQkG => IHeywmcvDFrEYmhfAHEKJcLkpQkP;

			public float eThyDiVWDQYyVVkJifUNuPerkRKI
			{
				get
				{
					if (IHeywmcvDFrEYmhfAHEKJcLkpQkP == Status.Idle)
					{
						return 0f;
					}
					if (teXXDMZGYPvdDPSBLYuqRlxTOLgX.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, wQjEQhaqsBIIJtnNXHjpHRKjKRcRA + (double)teXXDMZGYPvdDPSBLYuqRlxTOLgX.timeout - ReInput.unscaledTime);
				}
			}

			public Context XTpppVUipwBUhmswHPxxvDVfQcgV
			{
				get
				{
					if (IHeywmcvDFrEYmhfAHEKJcLkpQkP == Status.Idle)
					{
						return null;
					}
					return WQekEZRFmZycqfafHVzGduNKdFgh.okmSapBExYCwPEZVthtdSHWAHbtr;
				}
			}

			private bool qxaAPGbJZpMiOEFPHxKxNjbBEFmq
			{
				get
				{
					if (WXpfCfruvZsyikGYWxlLwmqJqSeG)
					{
						return false;
					}
					if (!(teXXDMZGYPvdDPSBLYuqRlxTOLgX.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public UyNtIIRFfUgkEdOgZElLCxObMRJNB(InputMapper P_0, Dictionary<nsJBvFfLUOFQVYRvInopgMdHhtsuA, SafeDelegate> P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("events");
				}
				cXGzDTfYjTAJVRqyTNTfyrnYLnsn = P_0;
				vmUGoRcXompMelLZjpGbIBEfeokvB = P_1;
				hWfotOPsNHTlRYXyRVEfgUSVKJYD();
			}

			protected virtual void aHmOFbfTDWbVeeUaJJFwZXqTbALE()
			{
				try
				{
					eRSXfaXbQHrlqxCnTaxahEqfCvIM();
				}
				finally
				{
					base.Finalize();
				}
			}

			public void HUqdumEQuWSuhyaxHyswlvkbWUeN(Context P_0, Options P_1)
			{
				if (IHeywmcvDFrEYmhfAHEKJcLkpQkP != Status.Idle)
				{
					zlhDavykFSIXqDIRYumxIjEFTfRmA("User started a new listening session.");
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
				Options.Copy(P_1, teXXDMZGYPvdDPSBLYuqRlxTOLgX);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					FKgcFQgIOHqVsdXVECyIYekPVRaJc("No Action found for actionId: " + P_0.actionId);
					return;
				}
				WQekEZRFmZycqfafHVzGduNKdFgh.OBcGfcCmyhhMSxKMTjfOCdzeZQyJb(player, P_0);
				IHeywmcvDFrEYmhfAHEKJcLkpQkP = Status.Listening;
				aIThajpBYohSJHGLOBmgrlisphvg();
				OULXyltABlzAcLTeuOixjPfESOmX();
				uSYBEBBxfsTSjjGwfFODgDfgeKMGB();
				bCtqJAqVDrUGDTsGCxLsURnQSsii();
			}

			public void sqyMfzDjAjuVSadkRzvQzOyydORB(string P_0)
			{
				if (IHeywmcvDFrEYmhfAHEKJcLkpQkP != Status.Idle)
				{
					zlhDavykFSIXqDIRYumxIjEFTfRmA(P_0);
				}
			}

			private void OJiRRIfwAguLhgPucwKEfoDqdcHfA(UpdateLoopType P_0)
			{
				if (P_0 == UpdateLoopType.Update && IHeywmcvDFrEYmhfAHEKJcLkpQkP == Status.Listening)
				{
					ElementAssignment elementAssignment;
					if (qxaAPGbJZpMiOEFPHxKxNjbBEFmq && eThyDiVWDQYyVVkJifUNuPerkRKI <= 0f)
					{
						ShgHEaZgimrKxWRCGuuydrKOyJDk();
					}
					else if (ReInput.controllers.GetController(WQekEZRFmZycqfafHVzGduNKdFgh.FPMqyLhTMXlkijzQwymWsmkWtkod, WQekEZRFmZycqfafHVzGduNKdFgh.LIqpCRWAWCPieETsNqLkYKhTZpAX) == null)
					{
						FKgcFQgIOHqVsdXVECyIYekPVRaJc("Controller not found for type: " + WQekEZRFmZycqfafHVzGduNKdFgh.FPMqyLhTMXlkijzQwymWsmkWtkod.ToString() + " id: " + WQekEZRFmZycqfafHVzGduNKdFgh.LIqpCRWAWCPieETsNqLkYKhTZpAX);
					}
					else if (kKNmUIuAzlOdnkIPgpIghDelNSgL(out elementAssignment) != PqvewkbCHmBqMjsosZylNSpqmyZeA.Quit && cqwtRtsGvpaAadHToZfARwWLBtlY(elementAssignment) != PqvewkbCHmBqMjsosZylNSpqmyZeA.Quit)
					{
						TptzMyuJeQSFuitUAQjtwyLSKSYb(elementAssignment);
					}
				}
			}

			private void zxRXfmejUazJUPouIXjKZplcIUvA()
			{
				if (IHeywmcvDFrEYmhfAHEKJcLkpQkP != Status.Idle)
				{
					hWfotOPsNHTlRYXyRVEfgUSVKJYD();
					eRSXfaXbQHrlqxCnTaxahEqfCvIM();
					PXQmQkWavSUdOeaJWHXvqlSDftRy();
				}
			}

			private void hWfotOPsNHTlRYXyRVEfgUSVKJYD()
			{
				IHeywmcvDFrEYmhfAHEKJcLkpQkP = Status.Idle;
				wQjEQhaqsBIIJtnNXHjpHRKjKRcRA = 0.0;
				teXXDMZGYPvdDPSBLYuqRlxTOLgX.ZmJVUyPTTRgtSSBVLqfWvlPmBhniA();
				WQekEZRFmZycqfafHVzGduNKdFgh.HDHClSvBEYYkvcankRyTbxFSjRif();
				ZsQYwRIHfDeRczNCbdXxhvusAiCd = default(ElementAssignment);
				ZvyeRusfiaFighTpEtCPospIHhrbb = hpNYTQqGmdaltDqLXJhutwIPQcPn.None;
				WXpfCfruvZsyikGYWxlLwmqJqSeG = false;
				WtJlnupRZtakiYOhKmASFdwBZLSb.Clear();
			}

			private PqvewkbCHmBqMjsosZylNSpqmyZeA kKNmUIuAzlOdnkIPgpIghDelNSgL(out ElementAssignment P_0)
			{
				if (!tVwjBFumPZtabdlDRBsBpcuvRpHc(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return PqvewkbCHmBqMjsosZylNSpqmyZeA.Quit;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !HzHDIOeVyDVVoMOYkXHMRlwWMJpn(item, teXXDMZGYPvdDPSBLYuqRlxTOLgX))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return PqvewkbCHmBqMjsosZylNSpqmyZeA.Quit;
				}
				if (!uNrDHNGHsLZJTBrGxeaFOMcYgGJE(WQekEZRFmZycqfafHVzGduNKdFgh, controllerPollingInfo, teXXDMZGYPvdDPSBLYuqRlxTOLgX))
				{
					P_0 = default(ElementAssignment);
					return PqvewkbCHmBqMjsosZylNSpqmyZeA.Quit;
				}
				P_0 = WQekEZRFmZycqfafHVzGduNKdFgh.QjSXXBTvEHFoAwdLJpogmcXOHxsi(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return PqvewkbCHmBqMjsosZylNSpqmyZeA.Continue;
			}

			private bool tVwjBFumPZtabdlDRBsBpcuvRpHc(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = WQekEZRFmZycqfafHVzGduNKdFgh.FPMqyLhTMXlkijzQwymWsmkWtkod;
				int controllerId = WQekEZRFmZycqfafHVzGduNKdFgh.LIqpCRWAWCPieETsNqLkYKhTZpAX;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = HaOZrTFmiVoHfUfOBphrGkfYczFz(out P_1);
					return true;
				}
				if (teXXDMZGYPvdDPSBLYuqRlxTOLgX.allowAxes)
				{
					if (teXXDMZGYPvdDPSBLYuqRlxTOLgX.allowButtons)
					{
						if (WQekEZRFmZycqfafHVzGduNKdFgh.UdmhNYgwLXDtbNodrWkMjvWrnuhGA != null)
						{
							P_0 = WQekEZRFmZycqfafHVzGduNKdFgh.UdmhNYgwLXDtbNodrWkMjvWrnuhGA.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(WQekEZRFmZycqfafHVzGduNKdFgh.FPMqyLhTMXlkijzQwymWsmkWtkod, WQekEZRFmZycqfafHVzGduNKdFgh.LIqpCRWAWCPieETsNqLkYKhTZpAX);
						}
					}
					else if (WQekEZRFmZycqfafHVzGduNKdFgh.UdmhNYgwLXDtbNodrWkMjvWrnuhGA != null)
					{
						P_0 = WQekEZRFmZycqfafHVzGduNKdFgh.UdmhNYgwLXDtbNodrWkMjvWrnuhGA.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!teXXDMZGYPvdDPSBLYuqRlxTOLgX.allowButtons)
					{
						FKgcFQgIOHqVsdXVECyIYekPVRaJc("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (WQekEZRFmZycqfafHVzGduNKdFgh.UdmhNYgwLXDtbNodrWkMjvWrnuhGA != null)
					{
						P_0 = WQekEZRFmZycqfafHVzGduNKdFgh.UdmhNYgwLXDtbNodrWkMjvWrnuhGA.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> HaOZrTFmiVoHfUfOBphrGkfYczFz(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				OAMaIEwlkVRPeJJGfQohcleGOCXJ.Clear();
				if (!teXXDMZGYPvdDPSBLYuqRlxTOLgX.allowButtons)
				{
					return OAMaIEwlkVRPeJJGfQohcleGOCXJ;
				}
				OAMaIEwlkVRPeJJGfQohcleGOCXJ.Add(PrNanNurYlMPwzGqtmbkfpoLJJAL(teXXDMZGYPvdDPSBLYuqRlxTOLgX, out P_0));
				return OAMaIEwlkVRPeJJGfQohcleGOCXJ;
			}

			private ControllerPollingInfo PrNanNurYlMPwzGqtmbkfpoLJJAL(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = BziIHGWyKsCAlTHdFbTDPqcKByNf(P_0, out flag, out P_1, out text);
				if (flag)
				{
					aIThajpBYohSJHGLOBmgrlisphvg();
				}
				return result;
			}

			private static ControllerPollingInfo BziIHGWyKsCAlTHdFbTDPqcKByNf(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
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

			private static bool HzHDIOeVyDVVoMOYkXHMRlwWMJpn(ControllerPollingInfo P_0, Options P_1)
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
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.IpICQeibsSnDGnakUYyfetClDTqrA<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool uNrDHNGHsLZJTBrGxeaFOMcYgGJE(mYmEVsKKkVhlfnEkXcQcmVLzUmUX P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.cdfaUYWuXiXzhItVHOJjWlIFhJAh == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void OULXyltABlzAcLTeuOixjPfESOmX()
			{
				if (!teXXDMZGYPvdDPSBLYuqRlxTOLgX.checkForConflicts)
				{
					return;
				}
				if (teXXDMZGYPvdDPSBLYuqRlxTOLgX.checkForConflictsWithSelf && WQekEZRFmZycqfafHVzGduNKdFgh.UdmhNYgwLXDtbNodrWkMjvWrnuhGA != null)
				{
					ListTools.AddIfUnique(WtJlnupRZtakiYOhKmASFdwBZLSb, WQekEZRFmZycqfafHVzGduNKdFgh.UdmhNYgwLXDtbNodrWkMjvWrnuhGA);
				}
				if (teXXDMZGYPvdDPSBLYuqRlxTOLgX.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(WtJlnupRZtakiYOhKmASFdwBZLSb, ReInput.players.SystemPlayer);
				}
				if (teXXDMZGYPvdDPSBLYuqRlxTOLgX.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(WtJlnupRZtakiYOhKmASFdwBZLSb, players[i]);
					}
				}
				else
				{
					if (teXXDMZGYPvdDPSBLYuqRlxTOLgX.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(teXXDMZGYPvdDPSBLYuqRlxTOLgX.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(WtJlnupRZtakiYOhKmASFdwBZLSb, allPlayers[j]);
						}
					}
				}
			}

			private PqvewkbCHmBqMjsosZylNSpqmyZeA cqwtRtsGvpaAadHToZfARwWLBtlY(ElementAssignment P_0)
			{
				if (teXXDMZGYPvdDPSBLYuqRlxTOLgX.checkForConflicts && WQekEZRFmZycqfafHVzGduNKdFgh.UdmhNYgwLXDtbNodrWkMjvWrnuhGA != null && NElyQqUkdEOOWOCbSpCdMQKFbVEz(WQekEZRFmZycqfafHVzGduNKdFgh, P_0, WtJlnupRZtakiYOhKmASFdwBZLSb))
				{
					return gSajqVithTKjnMRzXIcUpWvldFXo(P_0);
				}
				return PqvewkbCHmBqMjsosZylNSpqmyZeA.Continue;
			}

			private static bool NElyQqUkdEOOWOCbSpCdMQKFbVEz(mYmEVsKKkVhlfnEkXcQcmVLzUmUX P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.UdmhNYgwLXDtbNodrWkMjvWrnuhGA == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!NPLpKGMKHOHQGbSKHItVHPpyJSHsA(P_0, P_1, out var conflictCheck))
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

			private static bool miqGllfPSbfxkBTMJrsTfsSzdxkob(mYmEVsKKkVhlfnEkXcQcmVLzUmUX P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.UdmhNYgwLXDtbNodrWkMjvWrnuhGA == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!NPLpKGMKHOHQGbSKHItVHPpyJSHsA(P_0, P_1, out var conflictCheck))
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

			private static IList<ElementAssignmentConflictInfo> EIdxgHLLEELwRgSThJpPfJZOAsAHA(mYmEVsKKkVhlfnEkXcQcmVLzUmUX P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.UdmhNYgwLXDtbNodrWkMjvWrnuhGA == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!NPLpKGMKHOHQGbSKHItVHPpyJSHsA(P_0, P_1, out var conflictCheck))
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

			private static bool NPLpKGMKHOHQGbSKHItVHPpyJSHsA(mYmEVsKKkVhlfnEkXcQcmVLzUmUX P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				if (P_0 == null || (player = P_0.UdmhNYgwLXDtbNodrWkMjvWrnuhGA) == null)
				{
					P_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				P_2 = P_1.ToElementAssignmentConflictCheck();
				P_2.playerId = player.id;
				P_2.controllerType = P_0.FPMqyLhTMXlkijzQwymWsmkWtkod;
				P_2.controllerId = P_0.LIqpCRWAWCPieETsNqLkYKhTZpAX;
				P_2.controllerMapId = P_0.okmSapBExYCwPEZVthtdSHWAHbtr.controllerMap.id;
				P_2.controllerMapCategoryId = P_0.okmSapBExYCwPEZVthtdSHWAHbtr.controllerMap.categoryId;
				if (P_0.okmSapBExYCwPEZVthtdSHWAHbtr.actionElementMapToReplace != null)
				{
					P_2.elementMapId = P_0.okmSapBExYCwPEZVthtdSHWAHbtr.actionElementMapToReplace.id;
				}
				return true;
			}

			private static void JrsrQGwzOtDdRqcqUkMqNUYXvEuI(mYmEVsKKkVhlfnEkXcQcmVLzUmUX P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.UdmhNYgwLXDtbNodrWkMjvWrnuhGA == null)
				{
					return;
				}
				if (!NPLpKGMKHOHQGbSKHItVHPpyJSHsA(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void uSYBEBBxfsTSjjGwfFODgDfgeKMGB()
			{
				ReInput.UpdateEndedEvent -= OJiRRIfwAguLhgPucwKEfoDqdcHfA;
				ReInput.UpdateEndedEvent += OJiRRIfwAguLhgPucwKEfoDqdcHfA;
			}

			private void eRSXfaXbQHrlqxCnTaxahEqfCvIM()
			{
				ReInput.UpdateEndedEvent -= OJiRRIfwAguLhgPucwKEfoDqdcHfA;
			}

			private bool YTegKmhaqEVOmdWCjuPKHuNHfxmmA(nsJBvFfLUOFQVYRvInopgMdHhtsuA P_0)
			{
				SafeDelegate safeDelegate = vmUGoRcXompMelLZjpGbIBEfeokvB[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void bDKCysumzMwNWeoiuJBNVxrTAXzL<_0001>(nsJBvFfLUOFQVYRvInopgMdHhtsuA P_0, _0001 P_1)
			{
				SafeAction<_0001> safeAction = (SafeAction<_0001>)vmUGoRcXompMelLZjpGbIBEfeokvB[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void aIThajpBYohSJHGLOBmgrlisphvg()
			{
				wQjEQhaqsBIIJtnNXHjpHRKjKRcRA = ReInput.unscaledTime;
			}

			private void oCXItAGYsakMHjboXzPFQadSPyAE()
			{
				WXpfCfruvZsyikGYWxlLwmqJqSeG = true;
			}

			private bool qqYhgmfycFgPnyhTYofzixlEAVCY(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
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
					if (abviLNeTXBCbfRWPdBrJxXBDDqqT(elementType, axisRange, axisContribution, controller.GetElementById(P_0.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid).type, P_0.axisRange, P_0.axisContribution))
					{
						num++;
					}
				}
				using (IEnumerator<ActionElementMap> enumerator = elementAssignmentConflictInfo.controllerMap.ElementMapsWithAction(actionId).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						BWPbBiUSCXNRCvRxJwqZJMGLclWG bWPbBiUSCXNRCvRxJwqZJMGLclWG = new BWPbBiUSCXNRCvRxJwqZJMGLclWG();
						bWPbBiUSCXNRCvRxJwqZJMGLclWG.zuAyYqejENcUqXgMiXnmsijyoYMR = enumerator.Current;
						if (bWPbBiUSCXNRCvRxJwqZJMGLclWG.zuAyYqejENcUqXgMiXnmsijyoYMR.id != elementMap.id && ListTools.FindIndex(list, bWPbBiUSCXNRCvRxJwqZJMGLclWG.qEeRuHOGBlFBATtfkyfFyiMXALCt) < 0 && abviLNeTXBCbfRWPdBrJxXBDDqqT(elementType, axisRange, axisContribution, bWPbBiUSCXNRCvRxJwqZJMGLclWG.zuAyYqejENcUqXgMiXnmsijyoYMR.elementType, bWPbBiUSCXNRCvRxJwqZJMGLclWG.zuAyYqejENcUqXgMiXnmsijyoYMR.axisRange, bWPbBiUSCXNRCvRxJwqZJMGLclWG.zuAyYqejENcUqXgMiXnmsijyoYMR.axisContribution))
						{
							num++;
						}
					}
				}
				return num < P_3;
			}

			private bool OAKqQAteNTYofjYpzaojtWhemNQx(mYmEVsKKkVhlfnEkXcQcmVLzUmUX P_0, ElementAssignment P_1, bool P_2, out string P_3)
			{
				if (P_0 == null)
				{
					P_3 = "Mapping is null reference.";
					return false;
				}
				List<Player> list = new List<Player> { P_0.UdmhNYgwLXDtbNodrWkMjvWrnuhGA };
				IList<ElementAssignmentConflictInfo> list2 = EIdxgHLLEELwRgSThJpPfJZOAsAHA(P_0, P_1, list);
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
				if (P_0.okmSapBExYCwPEZVthtdSHWAHbtr.actionElementMapToReplace == null)
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
				ActionElementMap actionElementMap2 = new ActionElementMap(P_0.okmSapBExYCwPEZVthtdSHWAHbtr.actionElementMapToReplace);
				JrsrQGwzOtDdRqcqUkMqNUYXvEuI(P_0, P_1, list);
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
				elementAssignmentConflictInfo.controllerMap.ReplaceOrCreateElementMap(ElementAssignment.CompleteAssignment(P_0.FPMqyLhTMXlkijzQwymWsmkWtkod, elementType, elementIdentifierId, axisRange, keyCode, modifierKeyFlags, actionId, axisContribution, invert));
				P_3 = null;
				return true;
			}

			private static bool abviLNeTXBCbfRWPdBrJxXBDDqqT(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
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

			private void sDbLlvqQkontMMMhigsQHkXufcaL(ActionElementMap P_0)
			{
				STleotgfFAKZtbyCaiObYWhMLFPRc(P_0);
				zxRXfmejUazJUPouIXjKZplcIUvA();
			}

			private void zlhDavykFSIXqDIRYumxIjEFTfRmA(string P_0)
			{
				hWGVkJsluojwFtnElhGZMGulXHSq(P_0);
				zxRXfmejUazJUPouIXjKZplcIUvA();
			}

			private PqvewkbCHmBqMjsosZylNSpqmyZeA gSajqVithTKjnMRzXIcUpWvldFXo(ElementAssignment P_0)
			{
				if (YTegKmhaqEVOmdWCjuPKHuNHfxmmA(nsJBvFfLUOFQVYRvInopgMdHhtsuA.ConflictsFound))
				{
					bool flag = miqGllfPSbfxkBTMJrsTfsSzdxkob(WQekEZRFmZycqfafHVzGduNKdFgh, P_0, WtJlnupRZtakiYOhKmASFdwBZLSb);
					ZsQYwRIHfDeRczNCbdXxhvusAiCd = P_0;
					IList<ElementAssignmentConflictInfo> list = EIdxgHLLEELwRgSThJpPfJZOAsAHA(WQekEZRFmZycqfafHVzGduNKdFgh, P_0, WtJlnupRZtakiYOhKmASFdwBZLSb);
					ZvyeRusfiaFighTpEtCPospIHhrbb = hpNYTQqGmdaltDqLXJhutwIPQcPn.ConflictChecking;
					jorjQKjeXGqKAwQnPKmbMFCXnYjn();
					KlygaiPOVtBfFJIJWaFsEQEhaFMy(new ElementAssignmentInfo(WQekEZRFmZycqfafHVzGduNKdFgh.okmSapBExYCwPEZVthtdSHWAHbtr.controllerMap, P_0), list, flag);
					return PqvewkbCHmBqMjsosZylNSpqmyZeA.Quit;
				}
				return RTvAJfGNukuOdMKoJfjEzMKhgIWCA(teXXDMZGYPvdDPSBLYuqRlxTOLgX.defaultActionWhenConflictFound, P_0);
			}

			private PqvewkbCHmBqMjsosZylNSpqmyZeA RTvAJfGNukuOdMKoJfjEzMKhgIWCA(ConflictResponse P_0, ElementAssignment P_1)
			{
				return neGUdIIeVevOpohvBdfEcpkipZNI(P_0, P_1, miqGllfPSbfxkBTMJrsTfsSzdxkob(WQekEZRFmZycqfafHVzGduNKdFgh, P_1, WtJlnupRZtakiYOhKmASFdwBZLSb));
			}

			private PqvewkbCHmBqMjsosZylNSpqmyZeA neGUdIIeVevOpohvBdfEcpkipZNI(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					zlhDavykFSIXqDIRYumxIjEFTfRmA("Mapping assignment was canceled due to a conflict.");
					return PqvewkbCHmBqMjsosZylNSpqmyZeA.Quit;
				case ConflictResponse.Replace:
					if (P_2)
					{
						zlhDavykFSIXqDIRYumxIjEFTfRmA("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return PqvewkbCHmBqMjsosZylNSpqmyZeA.Quit;
					}
					JrsrQGwzOtDdRqcqUkMqNUYXvEuI(WQekEZRFmZycqfafHVzGduNKdFgh, P_1, WtJlnupRZtakiYOhKmASFdwBZLSb);
					return PqvewkbCHmBqMjsosZylNSpqmyZeA.Continue;
				case ConflictResponse.Add:
					return PqvewkbCHmBqMjsosZylNSpqmyZeA.Continue;
				case ConflictResponse.Ignore:
					eiURxkJleEkFOjUJhXQNdRGjiakh();
					return PqvewkbCHmBqMjsosZylNSpqmyZeA.Quit;
				case ConflictResponse.Swap:
				{
					if (!OAKqQAteNTYofjYpzaojtWhemNQx(WQekEZRFmZycqfafHVzGduNKdFgh, P_1, P_2, out var text))
					{
						zlhDavykFSIXqDIRYumxIjEFTfRmA(text);
						return PqvewkbCHmBqMjsosZylNSpqmyZeA.Quit;
					}
					return PqvewkbCHmBqMjsosZylNSpqmyZeA.Continue;
				}
				default:
					throw new NotImplementedException();
				}
			}

			private void ShgHEaZgimrKxWRCGuuydrKOyJDk()
			{
				LsYshgYkPzwWHkIiqLuXcozivduI();
				zxRXfmejUazJUPouIXjKZplcIUvA();
			}

			private void FKgcFQgIOHqVsdXVECyIYekPVRaJc(string P_0)
			{
				QSpEYykprjStfYEOyQBTJqDdKXll(P_0);
				zxRXfmejUazJUPouIXjKZplcIUvA();
			}

			private void jorjQKjeXGqKAwQnPKmbMFCXnYjn()
			{
				oCXItAGYsakMHjboXzPFQadSPyAE();
				eRSXfaXbQHrlqxCnTaxahEqfCvIM();
				IHeywmcvDFrEYmhfAHEKJcLkpQkP = Status.AwaitingResponse;
			}

			private void eiURxkJleEkFOjUJhXQNdRGjiakh()
			{
				IHeywmcvDFrEYmhfAHEKJcLkpQkP = Status.Listening;
				ZvyeRusfiaFighTpEtCPospIHhrbb = hpNYTQqGmdaltDqLXJhutwIPQcPn.None;
				aIThajpBYohSJHGLOBmgrlisphvg();
				uSYBEBBxfsTSjjGwfFODgDfgeKMGB();
			}

			private void TptzMyuJeQSFuitUAQjtwyLSKSYb(ElementAssignment P_0)
			{
				if (WQekEZRFmZycqfafHVzGduNKdFgh.okmSapBExYCwPEZVthtdSHWAHbtr.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					sDbLlvqQkontMMMhigsQHkXufcaL(result);
				}
				else
				{
					FKgcFQgIOHqVsdXVECyIYekPVRaJc("Failed to create element assignment.");
				}
			}

			private void STleotgfFAKZtbyCaiObYWhMLFPRc(ActionElementMap P_0)
			{
				if (YTegKmhaqEVOmdWCjuPKHuNHfxmmA(nsJBvFfLUOFQVYRvInopgMdHhtsuA.InputMapped))
				{
					bDKCysumzMwNWeoiuJBNVxrTAXzL(nsJBvFfLUOFQVYRvInopgMdHhtsuA.InputMapped, new InputMappedEventData(cXGzDTfYjTAJVRqyTNTfyrnYLnsn, P_0));
				}
			}

			private void LsYshgYkPzwWHkIiqLuXcozivduI()
			{
				if (YTegKmhaqEVOmdWCjuPKHuNHfxmmA(nsJBvFfLUOFQVYRvInopgMdHhtsuA.TimedOut))
				{
					bDKCysumzMwNWeoiuJBNVxrTAXzL(nsJBvFfLUOFQVYRvInopgMdHhtsuA.TimedOut, new TimedOutEventData(cXGzDTfYjTAJVRqyTNTfyrnYLnsn));
				}
			}

			private void QSpEYykprjStfYEOyQBTJqDdKXll(string P_0)
			{
				if (YTegKmhaqEVOmdWCjuPKHuNHfxmmA(nsJBvFfLUOFQVYRvInopgMdHhtsuA.Error))
				{
					bDKCysumzMwNWeoiuJBNVxrTAXzL(nsJBvFfLUOFQVYRvInopgMdHhtsuA.Error, new ErrorEventData(cXGzDTfYjTAJVRqyTNTfyrnYLnsn, P_0));
				}
			}

			private void hWGVkJsluojwFtnElhGZMGulXHSq(string P_0)
			{
				if (YTegKmhaqEVOmdWCjuPKHuNHfxmmA(nsJBvFfLUOFQVYRvInopgMdHhtsuA.Canceled))
				{
					bDKCysumzMwNWeoiuJBNVxrTAXzL(nsJBvFfLUOFQVYRvInopgMdHhtsuA.Canceled, new CanceledEventData(cXGzDTfYjTAJVRqyTNTfyrnYLnsn, P_0));
				}
			}

			private void KlygaiPOVtBfFJIJWaFsEQEhaFMy(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				NJucsCAVZONoaMGTyizoFKvJGrPs nJucsCAVZONoaMGTyizoFKvJGrPs = new NJucsCAVZONoaMGTyizoFKvJGrPs();
				nJucsCAVZONoaMGTyizoFKvJGrPs.HBBnRfIdaZWIiZzhuRHUxzUfKWMB = this;
				nJucsCAVZONoaMGTyizoFKvJGrPs.PJFPEvgaKeueBmrRGsSAjowtxDnW = P_0;
				nJucsCAVZONoaMGTyizoFKvJGrPs.sViXaJwSOzEiqyKWkzpewCLzOgdt = P_1;
				nJucsCAVZONoaMGTyizoFKvJGrPs.vmpbbeAdkZjfAtCfsSiXsPjlbOZe = P_2;
				if (YTegKmhaqEVOmdWCjuPKHuNHfxmmA(nsJBvFfLUOFQVYRvInopgMdHhtsuA.ConflictsFound))
				{
					bDKCysumzMwNWeoiuJBNVxrTAXzL(nsJBvFfLUOFQVYRvInopgMdHhtsuA.ConflictsFound, new ConflictFoundEventData(cXGzDTfYjTAJVRqyTNTfyrnYLnsn, hqKFTKiHbwtRglyrHhBIasdOSzTc, nJucsCAVZONoaMGTyizoFKvJGrPs.PJFPEvgaKeueBmrRGsSAjowtxDnW, nJucsCAVZONoaMGTyizoFKvJGrPs.sViXaJwSOzEiqyKWkzpewCLzOgdt, nJucsCAVZONoaMGTyizoFKvJGrPs.vmpbbeAdkZjfAtCfsSiXsPjlbOZe, nJucsCAVZONoaMGTyizoFKvJGrPs.lcLvEFyGMJwdUrMVCEWNlagxhaDEA));
				}
			}

			private void bCtqJAqVDrUGDTsGCxLsURnQSsii()
			{
				if (YTegKmhaqEVOmdWCjuPKHuNHfxmmA(nsJBvFfLUOFQVYRvInopgMdHhtsuA.Started))
				{
					bDKCysumzMwNWeoiuJBNVxrTAXzL(nsJBvFfLUOFQVYRvInopgMdHhtsuA.Started, new StartedEventData(cXGzDTfYjTAJVRqyTNTfyrnYLnsn));
				}
			}

			private void PXQmQkWavSUdOeaJWHXvqlSDftRy()
			{
				if (YTegKmhaqEVOmdWCjuPKHuNHfxmmA(nsJBvFfLUOFQVYRvInopgMdHhtsuA.Stopped))
				{
					bDKCysumzMwNWeoiuJBNVxrTAXzL(nsJBvFfLUOFQVYRvInopgMdHhtsuA.Stopped, new StoppedEventData(cXGzDTfYjTAJVRqyTNTfyrnYLnsn));
				}
			}

			public void hqKFTKiHbwtRglyrHhBIasdOSzTc(ConflictResponse P_0)
			{
				if (IHeywmcvDFrEYmhfAHEKJcLkpQkP != Status.AwaitingResponse || ZvyeRusfiaFighTpEtCPospIHhrbb != hpNYTQqGmdaltDqLXJhutwIPQcPn.ConflictChecking)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (RTvAJfGNukuOdMKoJfjEzMKhgIWCA(P_0, ZsQYwRIHfDeRczNCbdXxhvusAiCd) == PqvewkbCHmBqMjsosZylNSpqmyZeA.Continue)
					{
						TptzMyuJeQSFuitUAQjtwyLSKSYb(ZsQYwRIHfDeRczNCbdXxhvusAiCd);
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
			private sealed class SCLFdSxmJBAaZADsJJbliDWOHAjL
			{
				public static readonly SCLFdSxmJBAaZADsJJbliDWOHAjL _003C_003E9 = new SCLFdSxmJBAaZADsJJbliDWOHAjL();

				public static Action<Exception> _003C_003E9__64_0;

				internal void CByrRtZvKqCJcItAJhFZpNEVHNmu(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
				}
			}

			private bool SvXVQGQROtHhDivvekUhLwdfpMkw = true;

			private bool FROUAJDhxMukrhpfzvbWPIYLzkdt = true;

			private bool fpcHXeIYvpcqOiFPOBTknTlWHtMA = true;

			private float AricvJCVDPwIpGoEipYHzfQIEYDFA;

			private bool sIxbUpcFgEyNvGnqAPWMDYYcWdGdA = true;

			private bool alGleJzQJZKUzJsSADLQaPaRoiuq = true;

			private bool nPFgWjIuQlSAqhRNSEvmEKaGNHWU = true;

			private bool PyIlokyHXkijFvGZUXuenRtjIWDB = true;

			private int[] uABFacZiBkFbXvWTbDRAygofwuPP;

			private ConflictResponse WotCzScaGYKKRzRFLRNUwviEUuQT = ConflictResponse.Replace;

			private bool AkAqLuBONyBmvCkuhnGthWXtVGes;

			private bool WZSWtJXBQuLtyioFKbWKALmgbJyb;

			private bool bbrQHHJBSOshcEOZcySyaFMfKbpr = true;

			private bool cxiaYoHjbsSGCzVQMwrOKAttzFoS = true;

			private float eTJzphFHbAZcnAFSxCHieNdpOTXk = 1f;

			internal const string vkmrGNznjUvzeYBFqwyjAmxVBZMp = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> pXTCbfgESrAllcLTAmTLzshQTUGBB = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			public bool allowAxes
			{
				get
				{
					return SvXVQGQROtHhDivvekUhLwdfpMkw;
				}
				set
				{
					SvXVQGQROtHhDivvekUhLwdfpMkw = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return FROUAJDhxMukrhpfzvbWPIYLzkdt;
				}
				set
				{
					FROUAJDhxMukrhpfzvbWPIYLzkdt = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return fpcHXeIYvpcqOiFPOBTknTlWHtMA;
				}
				set
				{
					fpcHXeIYvpcqOiFPOBTknTlWHtMA = value;
				}
			}

			public float timeout
			{
				get
				{
					return AricvJCVDPwIpGoEipYHzfQIEYDFA;
				}
				set
				{
					AricvJCVDPwIpGoEipYHzfQIEYDFA = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return sIxbUpcFgEyNvGnqAPWMDYYcWdGdA;
				}
				set
				{
					sIxbUpcFgEyNvGnqAPWMDYYcWdGdA = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return alGleJzQJZKUzJsSADLQaPaRoiuq;
				}
				set
				{
					alGleJzQJZKUzJsSADLQaPaRoiuq = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return nPFgWjIuQlSAqhRNSEvmEKaGNHWU;
				}
				set
				{
					nPFgWjIuQlSAqhRNSEvmEKaGNHWU = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return PyIlokyHXkijFvGZUXuenRtjIWDB;
				}
				set
				{
					PyIlokyHXkijFvGZUXuenRtjIWDB = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return uABFacZiBkFbXvWTbDRAygofwuPP;
				}
				set
				{
					uABFacZiBkFbXvWTbDRAygofwuPP = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return WotCzScaGYKKRzRFLRNUwviEUuQT;
				}
				set
				{
					WotCzScaGYKKRzRFLRNUwviEUuQT = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return AkAqLuBONyBmvCkuhnGthWXtVGes;
				}
				set
				{
					AkAqLuBONyBmvCkuhnGthWXtVGes = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return WZSWtJXBQuLtyioFKbWKALmgbJyb;
				}
				set
				{
					WZSWtJXBQuLtyioFKbWKALmgbJyb = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return bbrQHHJBSOshcEOZcySyaFMfKbpr;
				}
				set
				{
					bbrQHHJBSOshcEOZcySyaFMfKbpr = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return cxiaYoHjbsSGCzVQMwrOKAttzFoS;
				}
				set
				{
					cxiaYoHjbsSGCzVQMwrOKAttzFoS = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return eTJzphFHbAZcnAFSxCHieNdpOTXk;
				}
				set
				{
					eTJzphFHbAZcnAFSxCHieNdpOTXk = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)pXTCbfgESrAllcLTAmTLzshQTUGBB["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = SCLFdSxmJBAaZADsJJbliDWOHAjL._003C_003E9.CByrRtZvKqCJcItAJhFZpNEVHNmu;
					}
					pXTCbfgESrAllcLTAmTLzshQTUGBB["isElementAllowed"] = safePredicate;
				}
			}

			internal _0001 IpICQeibsSnDGnakUYyfetClDTqrA<_0001>(string P_0) where _0001 : SafeDelegate
			{
				if (!pXTCbfgESrAllcLTAmTLzshQTUGBB.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as _0001;
			}

			public Options()
			{
				ZmJVUyPTTRgtSSBVLqfWvlPmBhniA();
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
				stringBuilder.Append("allowAxes = " + SvXVQGQROtHhDivvekUhLwdfpMkw + "\n");
				stringBuilder.Append("allowButtons = " + FROUAJDhxMukrhpfzvbWPIYLzkdt + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + fpcHXeIYvpcqOiFPOBTknTlWHtMA + "\n");
				stringBuilder.Append("timeout = " + AricvJCVDPwIpGoEipYHzfQIEYDFA + "\n");
				stringBuilder.Append("checkForConflicts = " + sIxbUpcFgEyNvGnqAPWMDYYcWdGdA + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + alGleJzQJZKUzJsSADLQaPaRoiuq + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + nPFgWjIuQlSAqhRNSEvmEKaGNHWU + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + PyIlokyHXkijFvGZUXuenRtjIWDB + "\n");
				if (uABFacZiBkFbXvWTbDRAygofwuPP == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(uABFacZiBkFbXvWTbDRAygofwuPP) + "\n");
				}
				stringBuilder.Append("defaultActionWhenConflictFound = " + WotCzScaGYKKRzRFLRNUwviEUuQT.ToString() + "\n");
				stringBuilder.Append("ignoreMouseXAxis = " + AkAqLuBONyBmvCkuhnGthWXtVGes);
				stringBuilder.Append("ignoreMouseYAxis = " + WZSWtJXBQuLtyioFKbWKALmgbJyb);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + bbrQHHJBSOshcEOZcySyaFMfKbpr + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + cxiaYoHjbsSGCzVQMwrOKAttzFoS + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + eTJzphFHbAZcnAFSxCHieNdpOTXk + "\n");
				return stringBuilder.ToString();
			}

			internal void ZmJVUyPTTRgtSSBVLqfWvlPmBhniA()
			{
				SvXVQGQROtHhDivvekUhLwdfpMkw = true;
				FROUAJDhxMukrhpfzvbWPIYLzkdt = true;
				fpcHXeIYvpcqOiFPOBTknTlWHtMA = true;
				AricvJCVDPwIpGoEipYHzfQIEYDFA = 0f;
				sIxbUpcFgEyNvGnqAPWMDYYcWdGdA = true;
				alGleJzQJZKUzJsSADLQaPaRoiuq = true;
				nPFgWjIuQlSAqhRNSEvmEKaGNHWU = true;
				PyIlokyHXkijFvGZUXuenRtjIWDB = true;
				uABFacZiBkFbXvWTbDRAygofwuPP = null;
				WotCzScaGYKKRzRFLRNUwviEUuQT = ConflictResponse.Replace;
				AkAqLuBONyBmvCkuhnGthWXtVGes = false;
				WZSWtJXBQuLtyioFKbWKALmgbJyb = false;
				bbrQHHJBSOshcEOZcySyaFMfKbpr = true;
				cxiaYoHjbsSGCzVQMwrOKAttzFoS = true;
				eTJzphFHbAZcnAFSxCHieNdpOTXk = 1f;
				foreach (string item in new List<string>(pXTCbfgESrAllcLTAmTLzshQTUGBB.Keys))
				{
					pXTCbfgESrAllcLTAmTLzshQTUGBB[item] = null;
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
				destination.SvXVQGQROtHhDivvekUhLwdfpMkw = source.SvXVQGQROtHhDivvekUhLwdfpMkw;
				destination.FROUAJDhxMukrhpfzvbWPIYLzkdt = source.FROUAJDhxMukrhpfzvbWPIYLzkdt;
				destination.fpcHXeIYvpcqOiFPOBTknTlWHtMA = source.fpcHXeIYvpcqOiFPOBTknTlWHtMA;
				destination.AricvJCVDPwIpGoEipYHzfQIEYDFA = source.AricvJCVDPwIpGoEipYHzfQIEYDFA;
				destination.sIxbUpcFgEyNvGnqAPWMDYYcWdGdA = source.sIxbUpcFgEyNvGnqAPWMDYYcWdGdA;
				destination.alGleJzQJZKUzJsSADLQaPaRoiuq = source.alGleJzQJZKUzJsSADLQaPaRoiuq;
				destination.nPFgWjIuQlSAqhRNSEvmEKaGNHWU = source.nPFgWjIuQlSAqhRNSEvmEKaGNHWU;
				destination.PyIlokyHXkijFvGZUXuenRtjIWDB = source.PyIlokyHXkijFvGZUXuenRtjIWDB;
				destination.uABFacZiBkFbXvWTbDRAygofwuPP = ArrayTools.ShallowCopy(source.uABFacZiBkFbXvWTbDRAygofwuPP);
				destination.WotCzScaGYKKRzRFLRNUwviEUuQT = source.WotCzScaGYKKRzRFLRNUwviEUuQT;
				destination.AkAqLuBONyBmvCkuhnGthWXtVGes = source.AkAqLuBONyBmvCkuhnGthWXtVGes;
				destination.WZSWtJXBQuLtyioFKbWKALmgbJyb = source.WZSWtJXBQuLtyioFKbWKALmgbJyb;
				destination.bbrQHHJBSOshcEOZcySyaFMfKbpr = source.bbrQHHJBSOshcEOZcySyaFMfKbpr;
				destination.cxiaYoHjbsSGCzVQMwrOKAttzFoS = source.cxiaYoHjbsSGCzVQMwrOKAttzFoS;
				destination.eTJzphFHbAZcnAFSxCHieNdpOTXk = source.eTJzphFHbAZcnAFSxCHieNdpOTXk;
				foreach (KeyValuePair<string, SafeDelegate> item in source.pXTCbfgESrAllcLTAmTLzshQTUGBB)
				{
					destination.pXTCbfgESrAllcLTAmTLzshQTUGBB[item.Key] = MiscTools.Clone(item.Value);
				}
			}
		}

		[Serializable]
		private sealed class QatikLWwwnpnbtFEgiBEFLBAmHoLA
		{
			public static readonly QatikLWwwnpnbtFEgiBEFLBAmHoLA _003C_003E9 = new QatikLWwwnpnbtFEgiBEFLBAmHoLA();

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void kfzwFRuzcAfFPEgGxsdyIDajqiDE(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
			}

			internal void TMjOaLcTUsIZwodKlNlxwASJsIQu(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
			}

			internal void xfeVDsCSMUmtjfYiVUXqZiyWTaPS(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
			}

			internal void EDkeSoaVsvjLjneuoKAfFbYhdQlc(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
			}

			internal void ucFzqEjPLsxuScJYjpKtHSCXPURF(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
			}

			internal void frMAseagSIwkuRvtpgSGDknccCNSA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
			}

			internal void AfIORbSeapicqchPaQjogKhISWlcA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
			}
		}

		private static InputMapper FRhBInXNjhiVbFBPAynTPmWoCxSNA;

		private static int rRrGhBWXhutiLBdIJpEDkpjqOuXM;

		private readonly int YPiCWxmOPFXajQOwmQfRRptSgonhA;

		private readonly bool UAWpjUyGBjgGkIwsJaXtavUvtjzBA;

		private readonly UyNtIIRFfUgkEdOgZElLCxObMRJNB kJQlYvpkaJKcbCxhfVPZDFOieyDe;

		private Options eopDOmYKxRvhYQNXYAiyixjpAFSs;

		private readonly Dictionary<nsJBvFfLUOFQVYRvInopgMdHhtsuA, SafeDelegate> FcZHRrGDneruwakLUlMkGppHnRULb = new Dictionary<nsJBvFfLUOFQVYRvInopgMdHhtsuA, SafeDelegate>
		{
			{
				nsJBvFfLUOFQVYRvInopgMdHhtsuA.InputMapped,
				new SafeAction<InputMappedEventData>(QatikLWwwnpnbtFEgiBEFLBAmHoLA._003C_003E9.kfzwFRuzcAfFPEgGxsdyIDajqiDE)
			},
			{
				nsJBvFfLUOFQVYRvInopgMdHhtsuA.Error,
				new SafeAction<ErrorEventData>(QatikLWwwnpnbtFEgiBEFLBAmHoLA._003C_003E9.TMjOaLcTUsIZwodKlNlxwASJsIQu)
			},
			{
				nsJBvFfLUOFQVYRvInopgMdHhtsuA.Canceled,
				new SafeAction<CanceledEventData>(QatikLWwwnpnbtFEgiBEFLBAmHoLA._003C_003E9.xfeVDsCSMUmtjfYiVUXqZiyWTaPS)
			},
			{
				nsJBvFfLUOFQVYRvInopgMdHhtsuA.TimedOut,
				new SafeAction<TimedOutEventData>(QatikLWwwnpnbtFEgiBEFLBAmHoLA._003C_003E9.EDkeSoaVsvjLjneuoKAfFbYhdQlc)
			},
			{
				nsJBvFfLUOFQVYRvInopgMdHhtsuA.Started,
				new SafeAction<StartedEventData>(QatikLWwwnpnbtFEgiBEFLBAmHoLA._003C_003E9.ucFzqEjPLsxuScJYjpKtHSCXPURF)
			},
			{
				nsJBvFfLUOFQVYRvInopgMdHhtsuA.Stopped,
				new SafeAction<StoppedEventData>(QatikLWwwnpnbtFEgiBEFLBAmHoLA._003C_003E9.frMAseagSIwkuRvtpgSGDknccCNSA)
			},
			{
				nsJBvFfLUOFQVYRvInopgMdHhtsuA.ConflictsFound,
				new SafeAction<ConflictFoundEventData>(QatikLWwwnpnbtFEgiBEFLBAmHoLA._003C_003E9.AfIORbSeapicqchPaQjogKhISWlcA)
			}
		};

		public static InputMapper Default => FRhBInXNjhiVbFBPAynTPmWoCxSNA ?? (FRhBInXNjhiVbFBPAynTPmWoCxSNA = new InputMapper(true));

		public Options options
		{
			get
			{
				Options obj = eopDOmYKxRvhYQNXYAiyixjpAFSs;
				if (obj == null)
				{
					if (!UAWpjUyGBjgGkIwsJaXtavUvtjzBA)
					{
						return eopDOmYKxRvhYQNXYAiyixjpAFSs = Default.options.Clone();
					}
					obj = (eopDOmYKxRvhYQNXYAiyixjpAFSs = new Options());
				}
				return obj;
			}
			set
			{
				eopDOmYKxRvhYQNXYAiyixjpAFSs = value;
			}
		}

		public Context mappingContext => kJQlYvpkaJKcbCxhfVPZDFOieyDe.XTpppVUipwBUhmswHPxxvDVfQcgV;

		public Status status => kJQlYvpkaJKcbCxhfVPZDFOieyDe.pojLdUsdRZdyfhaEmnUrWqBprQkG;

		public float timeRemaining => kJQlYvpkaJKcbCxhfVPZDFOieyDe.eThyDiVWDQYyVVkJifUNuPerkRKI;

		internal int rvKyzOVKCENpBAtRLignuhmAWhVu => YPiCWxmOPFXajQOwmQfRRptSgonhA;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.InputMapped;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<InputMappedEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.InputMapped;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<InputMappedEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.Error;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<ErrorEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.Error;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<ErrorEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.Canceled;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<CanceledEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.Canceled;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<CanceledEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.TimedOut;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<TimedOutEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.TimedOut;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<TimedOutEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.Started;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<StartedEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.Started;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<StartedEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.Stopped;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<StoppedEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.Stopped;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<StoppedEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.ConflictsFound;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<ConflictFoundEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nsJBvFfLUOFQVYRvInopgMdHhtsuA key = nsJBvFfLUOFQVYRvInopgMdHhtsuA.ConflictsFound;
					FcZHRrGDneruwakLUlMkGppHnRULb[key] = (SafeAction<ConflictFoundEventData>)FcZHRrGDneruwakLUlMkGppHnRULb[key] - value;
				}
			}
		}

		private static int UJhbYesWoEIfBlYNNzSXAGZvGDnG()
		{
			int result = rRrGhBWXhutiLBdIJpEDkpjqOuXM;
			if (rRrGhBWXhutiLBdIJpEDkpjqOuXM == int.MaxValue)
			{
				rRrGhBWXhutiLBdIJpEDkpjqOuXM = 0;
				return result;
			}
			rRrGhBWXhutiLBdIJpEDkpjqOuXM++;
			return result;
		}

		public InputMapper()
			: this(false)
		{
			YPiCWxmOPFXajQOwmQfRRptSgonhA = UJhbYesWoEIfBlYNNzSXAGZvGDnG();
		}

		private InputMapper(bool P_0)
		{
			UAWpjUyGBjgGkIwsJaXtavUvtjzBA = P_0;
			if (UAWpjUyGBjgGkIwsJaXtavUvtjzBA)
			{
				eopDOmYKxRvhYQNXYAiyixjpAFSs = new Options();
			}
			kJQlYvpkaJKcbCxhfVPZDFOieyDe = new UyNtIIRFfUgkEdOgZElLCxObMRJNB(this, FcZHRrGDneruwakLUlMkGppHnRULb);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<nsJBvFfLUOFQVYRvInopgMdHhtsuA, SafeDelegate> item in FcZHRrGDneruwakLUlMkGppHnRULb)
			{
				item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<nsJBvFfLUOFQVYRvInopgMdHhtsuA, SafeDelegate> item in FcZHRrGDneruwakLUlMkGppHnRULb)
			{
				item.Value.Clear();
			}
		}

		internal void HpFBsykyVOSXXEjbGhOqVHJqJqBSA(object P_0)
		{
		}

		internal void WPwKnTuzDOSIsPCBKFwgvedfXwQL()
		{
		}

		public bool Start(Context mappingContext)
		{
			return qYAUgBbmihcWSzhsPbFbFEBNjREYA(mappingContext, (eopDOmYKxRvhYQNXYAiyixjpAFSs != null) ? eopDOmYKxRvhYQNXYAiyixjpAFSs : Default.options);
		}

		public void Stop()
		{
			kJQlYvpkaJKcbCxhfVPZDFOieyDe.sqyMfzDjAjuVSadkRzvQzOyydORB("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			WPwKnTuzDOSIsPCBKFwgvedfXwQL();
			eopDOmYKxRvhYQNXYAiyixjpAFSs = null;
		}

		private bool qYAUgBbmihcWSzhsPbFbFEBNjREYA(Context P_0, Options P_1)
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
				kJQlYvpkaJKcbCxhfVPZDFOieyDe.HUqdumEQuWSuhyaxHyswlvkbWUeN(P_0, P_1);
				return true;
			}
			catch
			{
				kJQlYvpkaJKcbCxhfVPZDFOieyDe.sqyMfzDjAjuVSadkRzvQzOyydORB("Failed to start due to an exception.");
				return false;
			}
		}
	}
}
