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
			private int aFSIQwQYqyPBHHEDSjRsyEyRyXyn = -1;

			private ControllerMap FftWiicJoGJFkBFaJxaAjcyGyoTk;

			private ActionElementMap PYqdLfYLNRlPJFCNxhINikYGIHMSA;

			private AxisRange TgdalmfUTQoCKIEbEHwAOkpviPuYB = AxisRange.Positive;

			private bool KUMTjvrLtTzIGZzymVNwvoenTDCk;

			public int actionId
			{
				get
				{
					return aFSIQwQYqyPBHHEDSjRsyEyRyXyn;
				}
				set
				{
					if (!IiOXNFEykygrmzZwRSOJWHJigLeAA())
					{
						aFSIQwQYqyPBHHEDSjRsyEyRyXyn = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(aFSIQwQYqyPBHHEDSjRsyEyRyXyn);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!IiOXNFEykygrmzZwRSOJWHJigLeAA())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							aFSIQwQYqyPBHHEDSjRsyEyRyXyn = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							aFSIQwQYqyPBHHEDSjRsyEyRyXyn = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return FftWiicJoGJFkBFaJxaAjcyGyoTk;
				}
				set
				{
					if (!IiOXNFEykygrmzZwRSOJWHJigLeAA())
					{
						FftWiicJoGJFkBFaJxaAjcyGyoTk = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return PYqdLfYLNRlPJFCNxhINikYGIHMSA;
				}
				set
				{
					if (!IiOXNFEykygrmzZwRSOJWHJigLeAA())
					{
						PYqdLfYLNRlPJFCNxhINikYGIHMSA = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return TgdalmfUTQoCKIEbEHwAOkpviPuYB;
				}
				set
				{
					if (!IiOXNFEykygrmzZwRSOJWHJigLeAA())
					{
						TgdalmfUTQoCKIEbEHwAOkpviPuYB = value;
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

			internal void wlOKyfPMYfTyVOuUaTFKBMEAkORO()
			{
				KUMTjvrLtTzIGZzymVNwvoenTDCk = true;
			}

			private bool IiOXNFEykygrmzZwRSOJWHJigLeAA()
			{
				if (KUMTjvrLtTzIGZzymVNwvoenTDCk)
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
				destination.aFSIQwQYqyPBHHEDSjRsyEyRyXyn = source.aFSIQwQYqyPBHHEDSjRsyEyRyXyn;
				destination.FftWiicJoGJFkBFaJxaAjcyGyoTk = source.FftWiicJoGJFkBFaJxaAjcyGyoTk;
				destination.PYqdLfYLNRlPJFCNxhINikYGIHMSA = source.PYqdLfYLNRlPJFCNxhINikYGIHMSA;
				destination.TgdalmfUTQoCKIEbEHwAOkpviPuYB = source.TgdalmfUTQoCKIEbEHwAOkpviPuYB;
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

		private enum IdgRBTQYGXtErALnLvMihdplbGMl
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

		private class pLgBkIEphHWVyDwoOQgQOoAqZRbl
		{
			private enum gcQKIeibFzVpwhiuvpuydphWuonH
			{
				Quit = 0,
				Continue = 1
			}

			private enum WdwZaGxZgqFKDYJHIRwdIkUtFohM
			{
				None = 0,
				ConflictChecking = 1
			}

			private class ZLFHkmLmgKUSPcwaKCTvRyLNJsaw
			{
				private Player RyzeUwmauoAeeXOeqNXcLUSVNnMU;

				private int yvlNfHSWfoVGFBlpZBlpiWlJGzNf;

				private Context DViCxqhuueLiIYvuEpwhvLxWCUtC;

				private ControllerType pKHemsicoZAHmfxdVPOadRkFgiyY;

				private int xEdBpjivyKQUdTpmYbWNNdcakoMc;

				private ControllerPollingInfo XBVxguMoGUImNjVadODOioPQkGJPA;

				private ModifierKeyFlags UITiydlHwITkBZDJecXSIqyQoiTt;

				public Player jkXnkYnqVKEKNfQdsnjVEkYBcyZE => RyzeUwmauoAeeXOeqNXcLUSVNnMU;

				public int YZiDeKXiptmMyDxnBhgLpAkbeLZo => yvlNfHSWfoVGFBlpZBlpiWlJGzNf;

				public Context ZZFcwjEgtDzVvJPNkAuofbGoobVab => DViCxqhuueLiIYvuEpwhvLxWCUtC;

				public ControllerType cehEIBkJJKhUMuvrnIdLHfomTnQw => pKHemsicoZAHmfxdVPOadRkFgiyY;

				public int esRueZLYmVNFEDuRACmdnfWjhFue => xEdBpjivyKQUdTpmYbWNNdcakoMc;

				public ControllerPollingInfo UMjNHwauryYDGTgZeybHnLSzQMzg => XBVxguMoGUImNjVadODOioPQkGJPA;

				public ModifierKeyFlags TyiQuAkEwHioaoiCiygzeMFyfjtp => UITiydlHwITkBZDJecXSIqyQoiTt;

				public AxisRange XsOASQBTHnpuTqFJQFViLjOttlwmA
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (UMjNHwauryYDGTgZeybHnLSzQMzg.elementType == ControllerElementType.Axis)
						{
							result = ((DViCxqhuueLiIYvuEpwhvLxWCUtC.actionRange != AxisRange.Full) ? ((UMjNHwauryYDGTgZeybHnLSzQMzg.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
						}
						return result;
					}
				}

				public string AhFhHFhmNLPhfmRiMPmsTgBMhYlD
				{
					get
					{
						if (cehEIBkJJKhUMuvrnIdLHfomTnQw == ControllerType.Keyboard && TyiQuAkEwHioaoiCiygzeMFyfjtp != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(TyiQuAkEwHioaoiCiygzeMFyfjtp)} + {UMjNHwauryYDGTgZeybHnLSzQMzg.elementIdentifierName}";
						}
						string text = UMjNHwauryYDGTgZeybHnLSzQMzg.elementIdentifierName;
						if (UMjNHwauryYDGTgZeybHnLSzQMzg.elementType == ControllerElementType.Axis)
						{
							if (XsOASQBTHnpuTqFJQFViLjOttlwmA == AxisRange.Positive)
							{
								text += " +";
							}
							else if (XsOASQBTHnpuTqFJQFViLjOttlwmA == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				public void pJJFbazmcklNoTFMKqJFWAjrSnUi(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					oRkUZQgXCTpBBpsbpjxQeAVsgtOoA();
					RyzeUwmauoAeeXOeqNXcLUSVNnMU = P_0;
					yvlNfHSWfoVGFBlpZBlpiWlJGzNf = P_1.actionId;
					pKHemsicoZAHmfxdVPOadRkFgiyY = P_1.controllerMap.controllerType;
					xEdBpjivyKQUdTpmYbWNNdcakoMc = P_1.controllerMap.controllerId;
					DViCxqhuueLiIYvuEpwhvLxWCUtC = P_1;
					pKHemsicoZAHmfxdVPOadRkFgiyY = P_1.controllerMap.controllerType;
					xEdBpjivyKQUdTpmYbWNNdcakoMc = P_1.controllerMap.controllerId;
					P_1.wlOKyfPMYfTyVOuUaTFKBMEAkORO();
				}

				public void oRkUZQgXCTpBBpsbpjxQeAVsgtOoA()
				{
					RyzeUwmauoAeeXOeqNXcLUSVNnMU = null;
					yvlNfHSWfoVGFBlpZBlpiWlJGzNf = -1;
					DViCxqhuueLiIYvuEpwhvLxWCUtC = null;
					pKHemsicoZAHmfxdVPOadRkFgiyY = ControllerType.Keyboard;
					xEdBpjivyKQUdTpmYbWNNdcakoMc = -1;
					XBVxguMoGUImNjVadODOioPQkGJPA = default(ControllerPollingInfo);
					UITiydlHwITkBZDJecXSIqyQoiTt = ModifierKeyFlags.None;
				}

				public ElementAssignment tAzcdRIuGGacuCnPWkwxZVJqqXCXA(ControllerPollingInfo P_0)
				{
					XBVxguMoGUImNjVadODOioPQkGJPA = P_0;
					return czutxDkVxmAanvOxHVOqZHyhmXEq();
				}

				public ElementAssignment TsufQhdNqzPQFnubaUCTeoisyFIC(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					XBVxguMoGUImNjVadODOioPQkGJPA = P_0;
					UITiydlHwITkBZDJecXSIqyQoiTt = P_1;
					return czutxDkVxmAanvOxHVOqZHyhmXEq();
				}

				public ElementAssignment czutxDkVxmAanvOxHVOqZHyhmXEq()
				{
					return new ElementAssignment(cehEIBkJJKhUMuvrnIdLHfomTnQw, XBVxguMoGUImNjVadODOioPQkGJPA.elementType, XBVxguMoGUImNjVadODOioPQkGJPA.elementIdentifierId, XsOASQBTHnpuTqFJQFViLjOttlwmA, XBVxguMoGUImNjVadODOioPQkGJPA.keyboardKey, UITiydlHwITkBZDJecXSIqyQoiTt, yvlNfHSWfoVGFBlpZBlpiWlJGzNf, (DViCxqhuueLiIYvuEpwhvLxWCUtC.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (DViCxqhuueLiIYvuEpwhvLxWCUtC.actionElementMapToReplace != null) ? DViCxqhuueLiIYvuEpwhvLxWCUtC.actionElementMapToReplace.id : (-1));
				}
			}

			private readonly InputMapper JgharZaedOOifWJgWxEkLpzcbzKM;

			private readonly Options YQqhgYAdKQBExKAFIRdhaLbhDRQV = new Options();

			private readonly ZLFHkmLmgKUSPcwaKCTvRyLNJsaw lJLNMTQONObDWkLoIOuDQEqmjjQq = new ZLFHkmLmgKUSPcwaKCTvRyLNJsaw();

			private readonly Dictionary<IdgRBTQYGXtErALnLvMihdplbGMl, SafeDelegate> SSbQDFYMuhbNMYeXoeDguRKSSiUm;

			private readonly Dictionary<string, SafeDelegate> UkapJkQHnOjCXGiPxxkyelrpQDYw;

			private Status nSJWFalFPAbvgjnnFuFDsoDGaAUDA;

			private WdwZaGxZgqFKDYJHIRwdIkUtFohM kGTxKotDgbLhKKjvVBDOBFniBfRFA;

			private double NbMiklvAaUhyjiMVWalgsUGJVOMJ;

			private bool jrAGBrIyrKiVSqnEDGqUtLsrkkKKA;

			private List<Player> dkiLZlcQFKLHEZTGJwxLcLtprVhw = new List<Player>();

			private readonly List<ControllerPollingInfo> ftjFCQchuOkeSLWYavLqVueyfGrBA = new List<ControllerPollingInfo>();

			private ElementAssignment cJdkaHZpRIcTYySRmXogCybKQSqx;

			public Status AFCFdGxUZGYHNwdQpgkgrrHBlfEY => nSJWFalFPAbvgjnnFuFDsoDGaAUDA;

			public float FLEgQoWWNLhztCXZrEqIFLmRlqouA
			{
				get
				{
					if (nSJWFalFPAbvgjnnFuFDsoDGaAUDA == Status.Idle)
					{
						return 0f;
					}
					if (YQqhgYAdKQBExKAFIRdhaLbhDRQV.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, NbMiklvAaUhyjiMVWalgsUGJVOMJ + (double)YQqhgYAdKQBExKAFIRdhaLbhDRQV.timeout - ReInput.unscaledTime);
				}
			}

			public Context kITmTDezzxeBjcwGcQcYgJJFqES
			{
				get
				{
					if (nSJWFalFPAbvgjnnFuFDsoDGaAUDA == Status.Idle)
					{
						return null;
					}
					return lJLNMTQONObDWkLoIOuDQEqmjjQq.ZZFcwjEgtDzVvJPNkAuofbGoobVab;
				}
			}

			private bool NoRTnYcNPybXoGNFKNHcduhcrJSlc
			{
				get
				{
					if (jrAGBrIyrKiVSqnEDGqUtLsrkkKKA)
					{
						return false;
					}
					if (!(YQqhgYAdKQBExKAFIRdhaLbhDRQV.timeout > 0f))
					{
						return false;
					}
					return true;
				}
			}

			public pLgBkIEphHWVyDwoOQgQOoAqZRbl(InputMapper P_0, Dictionary<IdgRBTQYGXtErALnLvMihdplbGMl, SafeDelegate> P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("events");
				}
				JgharZaedOOifWJgWxEkLpzcbzKM = P_0;
				SSbQDFYMuhbNMYeXoeDguRKSSiUm = P_1;
				QkKKYGAZeMmNbXjVAUdmHmEjUcyj();
			}

			protected virtual void FOyQaTeHHPfYffBMAMElkYXrHnrX()
			{
				try
				{
					ZGtExwYpCOgEAcWjICbnIUcLbbmn();
				}
				finally
				{
					base.Finalize();
				}
			}

			public void ejZwOqFhkLCLPbzdYzptbUyLcUGWA(Context P_0, Options P_1)
			{
				if (nSJWFalFPAbvgjnnFuFDsoDGaAUDA != Status.Idle)
				{
					AxGUbhfALDuBSXCXVBbiAnGpvdrQ("User started a new listening session.");
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
				Options.Copy(P_1, YQqhgYAdKQBExKAFIRdhaLbhDRQV);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					gwRbpGXTKYgNQCwHVzjDDjkbJNGP("No Action found for actionId: " + P_0.actionId);
					return;
				}
				lJLNMTQONObDWkLoIOuDQEqmjjQq.pJJFbazmcklNoTFMKqJFWAjrSnUi(player, P_0);
				nSJWFalFPAbvgjnnFuFDsoDGaAUDA = Status.Listening;
				HxwIJtodUhpSrUkLJjEbINaCadVQ();
				begOxxqWLafFYApqfftiQhhcYbAm();
				FCxkZJaTjvxvRLUcoVNOmSjQYSqf();
				WrSESKGpNgKhvIMAHKgdAntocAGlA();
			}

			public void XfPPafUQzeDLekfjGmkmGSOCxraRA(string P_0)
			{
				if (nSJWFalFPAbvgjnnFuFDsoDGaAUDA != Status.Idle)
				{
					AxGUbhfALDuBSXCXVBbiAnGpvdrQ(P_0);
				}
			}

			private void vRMzWriAbSwXajcEbRRYEPQKcvlc(UpdateLoopType P_0)
			{
				if (P_0 == UpdateLoopType.Update && nSJWFalFPAbvgjnnFuFDsoDGaAUDA == Status.Listening)
				{
					ElementAssignment elementAssignment;
					if (NoRTnYcNPybXoGNFKNHcduhcrJSlc && FLEgQoWWNLhztCXZrEqIFLmRlqouA <= 0f)
					{
						xyHKxmCxmpYRJFzMXvRpSKQsgphK();
					}
					else if (ReInput.controllers.GetController(lJLNMTQONObDWkLoIOuDQEqmjjQq.cehEIBkJJKhUMuvrnIdLHfomTnQw, lJLNMTQONObDWkLoIOuDQEqmjjQq.esRueZLYmVNFEDuRACmdnfWjhFue) == null)
					{
						gwRbpGXTKYgNQCwHVzjDDjkbJNGP("Controller not found for type: " + lJLNMTQONObDWkLoIOuDQEqmjjQq.cehEIBkJJKhUMuvrnIdLHfomTnQw.ToString() + " id: " + lJLNMTQONObDWkLoIOuDQEqmjjQq.esRueZLYmVNFEDuRACmdnfWjhFue);
					}
					else if (RbeHKAnnncclDJzTtcihdMwDIPUKA(out elementAssignment) != gcQKIeibFzVpwhiuvpuydphWuonH.Quit && TaBBttlqteLdUSvJnMqTmHWbobDn(elementAssignment) != gcQKIeibFzVpwhiuvpuydphWuonH.Quit)
					{
						weYKVSdoLVapfzMtJOTgZJyspIyP(elementAssignment);
					}
				}
			}

			private void KIUrtdrFvBkEvKZmfcWysphVPSmT()
			{
				if (nSJWFalFPAbvgjnnFuFDsoDGaAUDA != Status.Idle)
				{
					QkKKYGAZeMmNbXjVAUdmHmEjUcyj();
					ZGtExwYpCOgEAcWjICbnIUcLbbmn();
					sMvHOcVprRrbwlDZFUGmBXKzPzpv();
				}
			}

			private void QkKKYGAZeMmNbXjVAUdmHmEjUcyj()
			{
				nSJWFalFPAbvgjnnFuFDsoDGaAUDA = Status.Idle;
				NbMiklvAaUhyjiMVWalgsUGJVOMJ = 0.0;
				YQqhgYAdKQBExKAFIRdhaLbhDRQV.iwgbacWpTUeScZvLOUeRKeFAQxVS();
				lJLNMTQONObDWkLoIOuDQEqmjjQq.oRkUZQgXCTpBBpsbpjxQeAVsgtOoA();
				cJdkaHZpRIcTYySRmXogCybKQSqx = default(ElementAssignment);
				kGTxKotDgbLhKKjvVBDOBFniBfRFA = WdwZaGxZgqFKDYJHIRwdIkUtFohM.None;
				jrAGBrIyrKiVSqnEDGqUtLsrkkKKA = false;
				dkiLZlcQFKLHEZTGJwxLcLtprVhw.Clear();
			}

			private gcQKIeibFzVpwhiuvpuydphWuonH RbeHKAnnncclDJzTtcihdMwDIPUKA(out ElementAssignment P_0)
			{
				if (!YmBLBTpxaYtOMsfdSdKxMryLdZBBA(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return gcQKIeibFzVpwhiuvpuydphWuonH.Quit;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !whgweIzvmIqWQXbUbMLZeAqwHkNf(item, YQqhgYAdKQBExKAFIRdhaLbhDRQV))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return gcQKIeibFzVpwhiuvpuydphWuonH.Quit;
				}
				if (!NFYMnRJNDGfodfOnkWtrNhAkkwhCA(lJLNMTQONObDWkLoIOuDQEqmjjQq, controllerPollingInfo, YQqhgYAdKQBExKAFIRdhaLbhDRQV))
				{
					P_0 = default(ElementAssignment);
					return gcQKIeibFzVpwhiuvpuydphWuonH.Quit;
				}
				P_0 = lJLNMTQONObDWkLoIOuDQEqmjjQq.tAzcdRIuGGacuCnPWkwxZVJqqXCXA(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return gcQKIeibFzVpwhiuvpuydphWuonH.Continue;
			}

			private bool YmBLBTpxaYtOMsfdSdKxMryLdZBBA(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = lJLNMTQONObDWkLoIOuDQEqmjjQq.cehEIBkJJKhUMuvrnIdLHfomTnQw;
				int controllerId = lJLNMTQONObDWkLoIOuDQEqmjjQq.esRueZLYmVNFEDuRACmdnfWjhFue;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = mIvRvBGjcOmSXHZWIiPqlAzwnnbI(out P_1);
					return true;
				}
				if (YQqhgYAdKQBExKAFIRdhaLbhDRQV.allowAxes)
				{
					if (YQqhgYAdKQBExKAFIRdhaLbhDRQV.allowButtons)
					{
						if (lJLNMTQONObDWkLoIOuDQEqmjjQq.jkXnkYnqVKEKNfQdsnjVEkYBcyZE != null)
						{
							P_0 = lJLNMTQONObDWkLoIOuDQEqmjjQq.jkXnkYnqVKEKNfQdsnjVEkYBcyZE.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(lJLNMTQONObDWkLoIOuDQEqmjjQq.cehEIBkJJKhUMuvrnIdLHfomTnQw, lJLNMTQONObDWkLoIOuDQEqmjjQq.esRueZLYmVNFEDuRACmdnfWjhFue);
						}
					}
					else if (lJLNMTQONObDWkLoIOuDQEqmjjQq.jkXnkYnqVKEKNfQdsnjVEkYBcyZE != null)
					{
						P_0 = lJLNMTQONObDWkLoIOuDQEqmjjQq.jkXnkYnqVKEKNfQdsnjVEkYBcyZE.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!YQqhgYAdKQBExKAFIRdhaLbhDRQV.allowButtons)
					{
						gwRbpGXTKYgNQCwHVzjDDjkbJNGP("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (lJLNMTQONObDWkLoIOuDQEqmjjQq.jkXnkYnqVKEKNfQdsnjVEkYBcyZE != null)
					{
						P_0 = lJLNMTQONObDWkLoIOuDQEqmjjQq.jkXnkYnqVKEKNfQdsnjVEkYBcyZE.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> mIvRvBGjcOmSXHZWIiPqlAzwnnbI(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				ftjFCQchuOkeSLWYavLqVueyfGrBA.Clear();
				if (!YQqhgYAdKQBExKAFIRdhaLbhDRQV.allowButtons)
				{
					return ftjFCQchuOkeSLWYavLqVueyfGrBA;
				}
				ftjFCQchuOkeSLWYavLqVueyfGrBA.Add(wfiaWPDnIylhAyimujdtsYerVZuy(YQqhgYAdKQBExKAFIRdhaLbhDRQV, out P_0));
				return ftjFCQchuOkeSLWYavLqVueyfGrBA;
			}

			private ControllerPollingInfo wfiaWPDnIylhAyimujdtsYerVZuy(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = cQJPuQTYgxUrNCWjWMyMsYogTSvF(P_0, out flag, out P_1, out text);
				if (flag)
				{
					HxwIJtodUhpSrUkLJjEbINaCadVQ();
				}
				return result;
			}

			private static ControllerPollingInfo cQJPuQTYgxUrNCWjWMyMsYogTSvF(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
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

			private static bool whgweIzvmIqWQXbUbMLZeAqwHkNf(ControllerPollingInfo P_0, Options P_1)
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
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.dYnyygkNqHcKqbacTlrsOBADHJQV<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool NFYMnRJNDGfodfOnkWtrNhAkkwhCA(ZLFHkmLmgKUSPcwaKCTvRyLNJsaw P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.XsOASQBTHnpuTqFJQFViLjOttlwmA == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void begOxxqWLafFYApqfftiQhhcYbAm()
			{
				if (!YQqhgYAdKQBExKAFIRdhaLbhDRQV.checkForConflicts)
				{
					return;
				}
				if (YQqhgYAdKQBExKAFIRdhaLbhDRQV.checkForConflictsWithSelf && lJLNMTQONObDWkLoIOuDQEqmjjQq.jkXnkYnqVKEKNfQdsnjVEkYBcyZE != null)
				{
					ListTools.AddIfUnique(dkiLZlcQFKLHEZTGJwxLcLtprVhw, lJLNMTQONObDWkLoIOuDQEqmjjQq.jkXnkYnqVKEKNfQdsnjVEkYBcyZE);
				}
				if (YQqhgYAdKQBExKAFIRdhaLbhDRQV.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(dkiLZlcQFKLHEZTGJwxLcLtprVhw, ReInput.players.SystemPlayer);
				}
				if (YQqhgYAdKQBExKAFIRdhaLbhDRQV.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(dkiLZlcQFKLHEZTGJwxLcLtprVhw, players[i]);
					}
				}
				else
				{
					if (YQqhgYAdKQBExKAFIRdhaLbhDRQV.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(YQqhgYAdKQBExKAFIRdhaLbhDRQV.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(dkiLZlcQFKLHEZTGJwxLcLtprVhw, allPlayers[j]);
						}
					}
				}
			}

			private gcQKIeibFzVpwhiuvpuydphWuonH TaBBttlqteLdUSvJnMqTmHWbobDn(ElementAssignment P_0)
			{
				if (YQqhgYAdKQBExKAFIRdhaLbhDRQV.checkForConflicts && lJLNMTQONObDWkLoIOuDQEqmjjQq.jkXnkYnqVKEKNfQdsnjVEkYBcyZE != null && mQMajyNDjJfSoJzvDDucrhGpHTcg(lJLNMTQONObDWkLoIOuDQEqmjjQq, P_0, dkiLZlcQFKLHEZTGJwxLcLtprVhw))
				{
					return FdPQaJjCnWGzJRPxYxUFQAhZBItI(P_0);
				}
				return gcQKIeibFzVpwhiuvpuydphWuonH.Continue;
			}

			private static bool mQMajyNDjJfSoJzvDDucrhGpHTcg(ZLFHkmLmgKUSPcwaKCTvRyLNJsaw P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.jkXnkYnqVKEKNfQdsnjVEkYBcyZE == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!mZgqJOJTPRxYksArIiQUsdgQGMfe(P_0, P_1, out var conflictCheck))
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

			private static bool FsFVfxMMImEyKOdKizpWXYQJpaUl(ZLFHkmLmgKUSPcwaKCTvRyLNJsaw P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.jkXnkYnqVKEKNfQdsnjVEkYBcyZE == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!mZgqJOJTPRxYksArIiQUsdgQGMfe(P_0, P_1, out var conflictCheck))
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

			private static IList<ElementAssignmentConflictInfo> tvQCMNARGJBFzfwPmQaEKJVcPgmy(ZLFHkmLmgKUSPcwaKCTvRyLNJsaw P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.jkXnkYnqVKEKNfQdsnjVEkYBcyZE == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!mZgqJOJTPRxYksArIiQUsdgQGMfe(P_0, P_1, out var conflictCheck))
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

			private static bool mZgqJOJTPRxYksArIiQUsdgQGMfe(ZLFHkmLmgKUSPcwaKCTvRyLNJsaw P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				if (P_0 == null || (player = P_0.jkXnkYnqVKEKNfQdsnjVEkYBcyZE) == null)
				{
					P_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				P_2 = P_1.ToElementAssignmentConflictCheck();
				P_2.playerId = player.id;
				P_2.controllerType = P_0.cehEIBkJJKhUMuvrnIdLHfomTnQw;
				P_2.controllerId = P_0.esRueZLYmVNFEDuRACmdnfWjhFue;
				P_2.controllerMapId = P_0.ZZFcwjEgtDzVvJPNkAuofbGoobVab.controllerMap.id;
				P_2.controllerMapCategoryId = P_0.ZZFcwjEgtDzVvJPNkAuofbGoobVab.controllerMap.categoryId;
				if (P_0.ZZFcwjEgtDzVvJPNkAuofbGoobVab.actionElementMapToReplace != null)
				{
					P_2.elementMapId = P_0.ZZFcwjEgtDzVvJPNkAuofbGoobVab.actionElementMapToReplace.id;
				}
				return true;
			}

			private static void egRkZYnbbqAsrrdaZHfdCgSlLjWRA(ZLFHkmLmgKUSPcwaKCTvRyLNJsaw P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.jkXnkYnqVKEKNfQdsnjVEkYBcyZE == null)
				{
					return;
				}
				if (!mZgqJOJTPRxYksArIiQUsdgQGMfe(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void FCxkZJaTjvxvRLUcoVNOmSjQYSqf()
			{
				ReInput.UpdateEndedEvent -= vRMzWriAbSwXajcEbRRYEPQKcvlc;
				ReInput.UpdateEndedEvent += vRMzWriAbSwXajcEbRRYEPQKcvlc;
			}

			private void ZGtExwYpCOgEAcWjICbnIUcLbbmn()
			{
				ReInput.UpdateEndedEvent -= vRMzWriAbSwXajcEbRRYEPQKcvlc;
			}

			private bool dfFiRedmqPhCQPNMsALDZWZbfxSj(IdgRBTQYGXtErALnLvMihdplbGMl P_0)
			{
				SafeDelegate safeDelegate = SSbQDFYMuhbNMYeXoeDguRKSSiUm[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void ILhSXmzKnXaEmhWmxIOQmNzzOjVg<_0001>(IdgRBTQYGXtErALnLvMihdplbGMl P_0, _0001 P_1)
			{
				SafeAction<_0001> safeAction = (SafeAction<_0001>)SSbQDFYMuhbNMYeXoeDguRKSSiUm[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void HxwIJtodUhpSrUkLJjEbINaCadVQ()
			{
				NbMiklvAaUhyjiMVWalgsUGJVOMJ = ReInput.unscaledTime;
			}

			private void PQshcIXhWbOPlmUdUwWMxHuiCHiq()
			{
				jrAGBrIyrKiVSqnEDGqUtLsrkkKKA = true;
			}

			private void XUKEpjbtczuIkaDvhzdVwsRCsvSAA(ActionElementMap P_0)
			{
				pCGScfkTDLyHRnlSfZNkvIfjhBnW(P_0);
				KIUrtdrFvBkEvKZmfcWysphVPSmT();
			}

			private void AxGUbhfALDuBSXCXVBbiAnGpvdrQ(string P_0)
			{
				WEjAGLfhqbBFlodKyfHGEheLJXcPA(P_0);
				KIUrtdrFvBkEvKZmfcWysphVPSmT();
			}

			private gcQKIeibFzVpwhiuvpuydphWuonH FdPQaJjCnWGzJRPxYxUFQAhZBItI(ElementAssignment P_0)
			{
				if (dfFiRedmqPhCQPNMsALDZWZbfxSj(IdgRBTQYGXtErALnLvMihdplbGMl.ConflictsFound))
				{
					bool flag = FsFVfxMMImEyKOdKizpWXYQJpaUl(lJLNMTQONObDWkLoIOuDQEqmjjQq, P_0, dkiLZlcQFKLHEZTGJwxLcLtprVhw);
					cJdkaHZpRIcTYySRmXogCybKQSqx = P_0;
					IList<ElementAssignmentConflictInfo> list = tvQCMNARGJBFzfwPmQaEKJVcPgmy(lJLNMTQONObDWkLoIOuDQEqmjjQq, P_0, dkiLZlcQFKLHEZTGJwxLcLtprVhw);
					kGTxKotDgbLhKKjvVBDOBFniBfRFA = WdwZaGxZgqFKDYJHIRwdIkUtFohM.ConflictChecking;
					KXUcjSkPyVrcwddlYzHmxOXrGqNC();
					xaZEAskELmMshFMHhXGvpnANFJuUb(new ElementAssignmentInfo(lJLNMTQONObDWkLoIOuDQEqmjjQq.ZZFcwjEgtDzVvJPNkAuofbGoobVab.controllerMap, P_0), list, flag);
					return gcQKIeibFzVpwhiuvpuydphWuonH.Quit;
				}
				return yHCuldJKotfnJTaaWieXfYYNEUscA(YQqhgYAdKQBExKAFIRdhaLbhDRQV.defaultActionWhenConflictFound, P_0);
			}

			private gcQKIeibFzVpwhiuvpuydphWuonH yHCuldJKotfnJTaaWieXfYYNEUscA(ConflictResponse P_0, ElementAssignment P_1)
			{
				return GRfKiSXeXhcIHGztEhkJlTwCOxfy(P_0, P_1, FsFVfxMMImEyKOdKizpWXYQJpaUl(lJLNMTQONObDWkLoIOuDQEqmjjQq, P_1, dkiLZlcQFKLHEZTGJwxLcLtprVhw));
			}

			private gcQKIeibFzVpwhiuvpuydphWuonH GRfKiSXeXhcIHGztEhkJlTwCOxfy(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					AxGUbhfALDuBSXCXVBbiAnGpvdrQ("Mapping assignment was canceled due to a conflict.");
					return gcQKIeibFzVpwhiuvpuydphWuonH.Quit;
				case ConflictResponse.Replace:
					if (P_2)
					{
						AxGUbhfALDuBSXCXVBbiAnGpvdrQ("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return gcQKIeibFzVpwhiuvpuydphWuonH.Quit;
					}
					egRkZYnbbqAsrrdaZHfdCgSlLjWRA(lJLNMTQONObDWkLoIOuDQEqmjjQq, P_1, dkiLZlcQFKLHEZTGJwxLcLtprVhw);
					return gcQKIeibFzVpwhiuvpuydphWuonH.Continue;
				case ConflictResponse.Add:
					return gcQKIeibFzVpwhiuvpuydphWuonH.Continue;
				case ConflictResponse.Ignore:
					HXxrndOvnDDHqkgYuTMYSnFHzkWN();
					return gcQKIeibFzVpwhiuvpuydphWuonH.Quit;
				default:
					throw new NotImplementedException();
				}
			}

			private void xyHKxmCxmpYRJFzMXvRpSKQsgphK()
			{
				aIlGGqHmZwILhnjybfEGeRrMXxAnA();
				KIUrtdrFvBkEvKZmfcWysphVPSmT();
			}

			private void gwRbpGXTKYgNQCwHVzjDDjkbJNGP(string P_0)
			{
				teUqtmbavgAMZFMUxMiIeHFXAUHV(P_0);
				KIUrtdrFvBkEvKZmfcWysphVPSmT();
			}

			private void KXUcjSkPyVrcwddlYzHmxOXrGqNC()
			{
				PQshcIXhWbOPlmUdUwWMxHuiCHiq();
				ZGtExwYpCOgEAcWjICbnIUcLbbmn();
				nSJWFalFPAbvgjnnFuFDsoDGaAUDA = Status.AwaitingResponse;
			}

			private void HXxrndOvnDDHqkgYuTMYSnFHzkWN()
			{
				nSJWFalFPAbvgjnnFuFDsoDGaAUDA = Status.Listening;
				kGTxKotDgbLhKKjvVBDOBFniBfRFA = WdwZaGxZgqFKDYJHIRwdIkUtFohM.None;
				HxwIJtodUhpSrUkLJjEbINaCadVQ();
				FCxkZJaTjvxvRLUcoVNOmSjQYSqf();
			}

			private void weYKVSdoLVapfzMtJOTgZJyspIyP(ElementAssignment P_0)
			{
				if (lJLNMTQONObDWkLoIOuDQEqmjjQq.ZZFcwjEgtDzVvJPNkAuofbGoobVab.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					XUKEpjbtczuIkaDvhzdVwsRCsvSAA(result);
				}
				else
				{
					gwRbpGXTKYgNQCwHVzjDDjkbJNGP("Failed to create element assignment.");
				}
			}

			private void pCGScfkTDLyHRnlSfZNkvIfjhBnW(ActionElementMap P_0)
			{
				if (dfFiRedmqPhCQPNMsALDZWZbfxSj(IdgRBTQYGXtErALnLvMihdplbGMl.InputMapped))
				{
					ILhSXmzKnXaEmhWmxIOQmNzzOjVg(IdgRBTQYGXtErALnLvMihdplbGMl.InputMapped, new InputMappedEventData(JgharZaedOOifWJgWxEkLpzcbzKM, P_0));
				}
			}

			private void aIlGGqHmZwILhnjybfEGeRrMXxAnA()
			{
				if (dfFiRedmqPhCQPNMsALDZWZbfxSj(IdgRBTQYGXtErALnLvMihdplbGMl.TimedOut))
				{
					ILhSXmzKnXaEmhWmxIOQmNzzOjVg(IdgRBTQYGXtErALnLvMihdplbGMl.TimedOut, new TimedOutEventData(JgharZaedOOifWJgWxEkLpzcbzKM));
				}
			}

			private void teUqtmbavgAMZFMUxMiIeHFXAUHV(string P_0)
			{
				if (dfFiRedmqPhCQPNMsALDZWZbfxSj(IdgRBTQYGXtErALnLvMihdplbGMl.Error))
				{
					ILhSXmzKnXaEmhWmxIOQmNzzOjVg(IdgRBTQYGXtErALnLvMihdplbGMl.Error, new ErrorEventData(JgharZaedOOifWJgWxEkLpzcbzKM, P_0));
				}
			}

			private void WEjAGLfhqbBFlodKyfHGEheLJXcPA(string P_0)
			{
				if (dfFiRedmqPhCQPNMsALDZWZbfxSj(IdgRBTQYGXtErALnLvMihdplbGMl.Canceled))
				{
					ILhSXmzKnXaEmhWmxIOQmNzzOjVg(IdgRBTQYGXtErALnLvMihdplbGMl.Canceled, new CanceledEventData(JgharZaedOOifWJgWxEkLpzcbzKM, P_0));
				}
			}

			private void xaZEAskELmMshFMHhXGvpnANFJuUb(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				if (dfFiRedmqPhCQPNMsALDZWZbfxSj(IdgRBTQYGXtErALnLvMihdplbGMl.ConflictsFound))
				{
					ILhSXmzKnXaEmhWmxIOQmNzzOjVg(IdgRBTQYGXtErALnLvMihdplbGMl.ConflictsFound, new ConflictFoundEventData(JgharZaedOOifWJgWxEkLpzcbzKM, EIdLhBjiNdPUfwQoKugUPeowbURbA, P_0, P_1, P_2));
				}
			}

			private void WrSESKGpNgKhvIMAHKgdAntocAGlA()
			{
				if (dfFiRedmqPhCQPNMsALDZWZbfxSj(IdgRBTQYGXtErALnLvMihdplbGMl.Started))
				{
					ILhSXmzKnXaEmhWmxIOQmNzzOjVg(IdgRBTQYGXtErALnLvMihdplbGMl.Started, new StartedEventData(JgharZaedOOifWJgWxEkLpzcbzKM));
				}
			}

			private void sMvHOcVprRrbwlDZFUGmBXKzPzpv()
			{
				if (dfFiRedmqPhCQPNMsALDZWZbfxSj(IdgRBTQYGXtErALnLvMihdplbGMl.Stopped))
				{
					ILhSXmzKnXaEmhWmxIOQmNzzOjVg(IdgRBTQYGXtErALnLvMihdplbGMl.Stopped, new StoppedEventData(JgharZaedOOifWJgWxEkLpzcbzKM));
				}
			}

			public void EIdLhBjiNdPUfwQoKugUPeowbURbA(ConflictResponse P_0)
			{
				if (nSJWFalFPAbvgjnnFuFDsoDGaAUDA != Status.AwaitingResponse || kGTxKotDgbLhKKjvVBDOBFniBfRFA != WdwZaGxZgqFKDYJHIRwdIkUtFohM.ConflictChecking)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (yHCuldJKotfnJTaaWieXfYYNEUscA(P_0, cJdkaHZpRIcTYySRmXogCybKQSqx) == gcQKIeibFzVpwhiuvpuydphWuonH.Continue)
					{
						weYKVSdoLVapfzMtJOTgZJyspIyP(cJdkaHZpRIcTYySRmXogCybKQSqx);
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
			private sealed class vuallMsYuYNnzLzPSVAsNsWaGFFw
			{
				public static readonly vuallMsYuYNnzLzPSVAsNsWaGFFw _003C_003E9 = new vuallMsYuYNnzLzPSVAsNsWaGFFw();

				public static Action<Exception> _003C_003E9__64_0;

				internal void lXGbfCUSjHmSqPECpMCCAOCpJYBB(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
				}
			}

			private bool xgywEMVxYaCqzhQbfVNeqqrFMXCF = true;

			private bool yAvesRIalDRLJaLneEiPkuQzBeFw = true;

			private bool IcIQlNVrIoJFSxeFGhEACCHZzVZZ = true;

			private float xHJvHPZZLAUjZXfKnYLWKdUmTOjS;

			private bool TSAashUUgHwnBqUoTPGBzBMIdziq = true;

			private bool DSlWPuaFjIzBoSYPDWJGBcdnujME = true;

			private bool MZewoxNCUahmIioJRoLrtAqucNgt = true;

			private bool kpnMDkbTDxEXTagQBQIhQIBXRMow = true;

			private int[] JPkBtkIXPlYAfyCZsWSZXbcRhgbBA;

			private ConflictResponse jFWWFApVEPcljkoFQAQDLLakhgsW = ConflictResponse.Replace;

			private bool brlncrYPrUVFGzgayPmURFFnMCp;

			private bool vstMujQLJtatHhDkHfwPnyTURxdo;

			private bool YCjpDKJQPhOMVFVbPzhTCIBVhVp = true;

			private bool JJLUsqEmllHxkamGVOoNPflPkROdA = true;

			private float HhciFjOLtTkcRXhYyWQrBgdZMUxP = 1f;

			internal const string OFkiBlwzRbKSUXFdcbusntbMBaOA = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> SIwNvxNFOwSoHKcLdfIYZLfjBIqDA = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			public bool allowAxes
			{
				get
				{
					return xgywEMVxYaCqzhQbfVNeqqrFMXCF;
				}
				set
				{
					xgywEMVxYaCqzhQbfVNeqqrFMXCF = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return yAvesRIalDRLJaLneEiPkuQzBeFw;
				}
				set
				{
					yAvesRIalDRLJaLneEiPkuQzBeFw = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return IcIQlNVrIoJFSxeFGhEACCHZzVZZ;
				}
				set
				{
					IcIQlNVrIoJFSxeFGhEACCHZzVZZ = value;
				}
			}

			public float timeout
			{
				get
				{
					return xHJvHPZZLAUjZXfKnYLWKdUmTOjS;
				}
				set
				{
					xHJvHPZZLAUjZXfKnYLWKdUmTOjS = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return TSAashUUgHwnBqUoTPGBzBMIdziq;
				}
				set
				{
					TSAashUUgHwnBqUoTPGBzBMIdziq = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return DSlWPuaFjIzBoSYPDWJGBcdnujME;
				}
				set
				{
					DSlWPuaFjIzBoSYPDWJGBcdnujME = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return MZewoxNCUahmIioJRoLrtAqucNgt;
				}
				set
				{
					MZewoxNCUahmIioJRoLrtAqucNgt = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return kpnMDkbTDxEXTagQBQIhQIBXRMow;
				}
				set
				{
					kpnMDkbTDxEXTagQBQIhQIBXRMow = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return JPkBtkIXPlYAfyCZsWSZXbcRhgbBA;
				}
				set
				{
					JPkBtkIXPlYAfyCZsWSZXbcRhgbBA = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return jFWWFApVEPcljkoFQAQDLLakhgsW;
				}
				set
				{
					jFWWFApVEPcljkoFQAQDLLakhgsW = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return brlncrYPrUVFGzgayPmURFFnMCp;
				}
				set
				{
					brlncrYPrUVFGzgayPmURFFnMCp = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return vstMujQLJtatHhDkHfwPnyTURxdo;
				}
				set
				{
					vstMujQLJtatHhDkHfwPnyTURxdo = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return YCjpDKJQPhOMVFVbPzhTCIBVhVp;
				}
				set
				{
					YCjpDKJQPhOMVFVbPzhTCIBVhVp = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return JJLUsqEmllHxkamGVOoNPflPkROdA;
				}
				set
				{
					JJLUsqEmllHxkamGVOoNPflPkROdA = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return HhciFjOLtTkcRXhYyWQrBgdZMUxP;
				}
				set
				{
					HhciFjOLtTkcRXhYyWQrBgdZMUxP = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)SIwNvxNFOwSoHKcLdfIYZLfjBIqDA["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = vuallMsYuYNnzLzPSVAsNsWaGFFw._003C_003E9.lXGbfCUSjHmSqPECpMCCAOCpJYBB;
					}
					SIwNvxNFOwSoHKcLdfIYZLfjBIqDA["isElementAllowed"] = safePredicate;
				}
			}

			internal _0001 dYnyygkNqHcKqbacTlrsOBADHJQV<_0001>(string P_0) where _0001 : SafeDelegate
			{
				if (!SIwNvxNFOwSoHKcLdfIYZLfjBIqDA.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as _0001;
			}

			public Options()
			{
				iwgbacWpTUeScZvLOUeRKeFAQxVS();
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
				stringBuilder.Append("allowAxes = " + xgywEMVxYaCqzhQbfVNeqqrFMXCF + "\n");
				stringBuilder.Append("allowButtons = " + yAvesRIalDRLJaLneEiPkuQzBeFw + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + IcIQlNVrIoJFSxeFGhEACCHZzVZZ + "\n");
				stringBuilder.Append("timeout = " + xHJvHPZZLAUjZXfKnYLWKdUmTOjS + "\n");
				stringBuilder.Append("checkForConflicts = " + TSAashUUgHwnBqUoTPGBzBMIdziq + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + DSlWPuaFjIzBoSYPDWJGBcdnujME + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + MZewoxNCUahmIioJRoLrtAqucNgt + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + kpnMDkbTDxEXTagQBQIhQIBXRMow + "\n");
				if (JPkBtkIXPlYAfyCZsWSZXbcRhgbBA == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(JPkBtkIXPlYAfyCZsWSZXbcRhgbBA) + "\n");
				}
				stringBuilder.Append("defaultActionWhenConflictFound = " + jFWWFApVEPcljkoFQAQDLLakhgsW.ToString() + "\n");
				stringBuilder.Append("ignoreMouseXAxis = " + brlncrYPrUVFGzgayPmURFFnMCp);
				stringBuilder.Append("ignoreMouseYAxis = " + vstMujQLJtatHhDkHfwPnyTURxdo);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + YCjpDKJQPhOMVFVbPzhTCIBVhVp + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + JJLUsqEmllHxkamGVOoNPflPkROdA + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + HhciFjOLtTkcRXhYyWQrBgdZMUxP + "\n");
				return stringBuilder.ToString();
			}

			internal void iwgbacWpTUeScZvLOUeRKeFAQxVS()
			{
				xgywEMVxYaCqzhQbfVNeqqrFMXCF = true;
				yAvesRIalDRLJaLneEiPkuQzBeFw = true;
				IcIQlNVrIoJFSxeFGhEACCHZzVZZ = true;
				xHJvHPZZLAUjZXfKnYLWKdUmTOjS = 0f;
				TSAashUUgHwnBqUoTPGBzBMIdziq = true;
				DSlWPuaFjIzBoSYPDWJGBcdnujME = true;
				MZewoxNCUahmIioJRoLrtAqucNgt = true;
				kpnMDkbTDxEXTagQBQIhQIBXRMow = true;
				JPkBtkIXPlYAfyCZsWSZXbcRhgbBA = null;
				jFWWFApVEPcljkoFQAQDLLakhgsW = ConflictResponse.Replace;
				brlncrYPrUVFGzgayPmURFFnMCp = false;
				vstMujQLJtatHhDkHfwPnyTURxdo = false;
				YCjpDKJQPhOMVFVbPzhTCIBVhVp = true;
				JJLUsqEmllHxkamGVOoNPflPkROdA = true;
				HhciFjOLtTkcRXhYyWQrBgdZMUxP = 1f;
				foreach (string item in new List<string>(SIwNvxNFOwSoHKcLdfIYZLfjBIqDA.Keys))
				{
					SIwNvxNFOwSoHKcLdfIYZLfjBIqDA[item] = null;
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
				destination.xgywEMVxYaCqzhQbfVNeqqrFMXCF = source.xgywEMVxYaCqzhQbfVNeqqrFMXCF;
				destination.yAvesRIalDRLJaLneEiPkuQzBeFw = source.yAvesRIalDRLJaLneEiPkuQzBeFw;
				destination.IcIQlNVrIoJFSxeFGhEACCHZzVZZ = source.IcIQlNVrIoJFSxeFGhEACCHZzVZZ;
				destination.xHJvHPZZLAUjZXfKnYLWKdUmTOjS = source.xHJvHPZZLAUjZXfKnYLWKdUmTOjS;
				destination.TSAashUUgHwnBqUoTPGBzBMIdziq = source.TSAashUUgHwnBqUoTPGBzBMIdziq;
				destination.DSlWPuaFjIzBoSYPDWJGBcdnujME = source.DSlWPuaFjIzBoSYPDWJGBcdnujME;
				destination.MZewoxNCUahmIioJRoLrtAqucNgt = source.MZewoxNCUahmIioJRoLrtAqucNgt;
				destination.kpnMDkbTDxEXTagQBQIhQIBXRMow = source.kpnMDkbTDxEXTagQBQIhQIBXRMow;
				destination.JPkBtkIXPlYAfyCZsWSZXbcRhgbBA = ArrayTools.ShallowCopy(source.JPkBtkIXPlYAfyCZsWSZXbcRhgbBA);
				destination.jFWWFApVEPcljkoFQAQDLLakhgsW = source.jFWWFApVEPcljkoFQAQDLLakhgsW;
				destination.brlncrYPrUVFGzgayPmURFFnMCp = source.brlncrYPrUVFGzgayPmURFFnMCp;
				destination.vstMujQLJtatHhDkHfwPnyTURxdo = source.vstMujQLJtatHhDkHfwPnyTURxdo;
				destination.YCjpDKJQPhOMVFVbPzhTCIBVhVp = source.YCjpDKJQPhOMVFVbPzhTCIBVhVp;
				destination.JJLUsqEmllHxkamGVOoNPflPkROdA = source.JJLUsqEmllHxkamGVOoNPflPkROdA;
				destination.HhciFjOLtTkcRXhYyWQrBgdZMUxP = source.HhciFjOLtTkcRXhYyWQrBgdZMUxP;
				foreach (KeyValuePair<string, SafeDelegate> sIwNvxNFOwSoHKcLdfIYZLfjBIqDum in source.SIwNvxNFOwSoHKcLdfIYZLfjBIqDA)
				{
					destination.SIwNvxNFOwSoHKcLdfIYZLfjBIqDA[sIwNvxNFOwSoHKcLdfIYZLfjBIqDum.Key] = MiscTools.Clone(sIwNvxNFOwSoHKcLdfIYZLfjBIqDum.Value);
				}
			}
		}

		[Serializable]
		private sealed class dLYYqZPEweMrBqfMxWkJuPLoTTKf
		{
			public static readonly dLYYqZPEweMrBqfMxWkJuPLoTTKf _003C_003E9 = new dLYYqZPEweMrBqfMxWkJuPLoTTKf();

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void JVUQMLncrPgKpbHaeCxzaxDGRuxsb(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
			}

			internal void oXCSkVbUSjkPUdUwyieQPWdtCCaC(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
			}

			internal void AOLbryDyCBsSZyEgMqAteNqcGgzQ(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
			}

			internal void hxXRKQbGJyBIpicklqRVcwbfDtgmB(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
			}

			internal void HRegZOkPBryQsnkImHocfcAlVJdSA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
			}

			internal void MznSIablUHFZWQipaZzNRpnWYGvi(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
			}

			internal void tQddkxZiXyNIowHxpcbHtlDoMDTc(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
			}
		}

		private static InputMapper ohKVklMJdaSyFYbLXmtGNBGGGhuP;

		private static int YBATMRDlWzZkjGYTWPFCBzJUqUbC;

		private readonly int rXNuXdxQDGZMFFMwtcXEmUxckWPj;

		private readonly bool llpPECbDLwzFMRjaAIlgIKGLxpJf;

		private readonly pLgBkIEphHWVyDwoOQgQOoAqZRbl RafCDvJogYlzJVRtoKWEVeNCXalFA;

		private Options RzYiYiDxrYCYsNDMTjGjNjQXFAuf;

		private readonly Dictionary<IdgRBTQYGXtErALnLvMihdplbGMl, SafeDelegate> gLonhnYSvnNmYnnZNZfnKedDJZej = new Dictionary<IdgRBTQYGXtErALnLvMihdplbGMl, SafeDelegate>
		{
			{
				IdgRBTQYGXtErALnLvMihdplbGMl.InputMapped,
				new SafeAction<InputMappedEventData>(dLYYqZPEweMrBqfMxWkJuPLoTTKf._003C_003E9.JVUQMLncrPgKpbHaeCxzaxDGRuxsb)
			},
			{
				IdgRBTQYGXtErALnLvMihdplbGMl.Error,
				new SafeAction<ErrorEventData>(dLYYqZPEweMrBqfMxWkJuPLoTTKf._003C_003E9.oXCSkVbUSjkPUdUwyieQPWdtCCaC)
			},
			{
				IdgRBTQYGXtErALnLvMihdplbGMl.Canceled,
				new SafeAction<CanceledEventData>(dLYYqZPEweMrBqfMxWkJuPLoTTKf._003C_003E9.AOLbryDyCBsSZyEgMqAteNqcGgzQ)
			},
			{
				IdgRBTQYGXtErALnLvMihdplbGMl.TimedOut,
				new SafeAction<TimedOutEventData>(dLYYqZPEweMrBqfMxWkJuPLoTTKf._003C_003E9.hxXRKQbGJyBIpicklqRVcwbfDtgmB)
			},
			{
				IdgRBTQYGXtErALnLvMihdplbGMl.Started,
				new SafeAction<StartedEventData>(dLYYqZPEweMrBqfMxWkJuPLoTTKf._003C_003E9.HRegZOkPBryQsnkImHocfcAlVJdSA)
			},
			{
				IdgRBTQYGXtErALnLvMihdplbGMl.Stopped,
				new SafeAction<StoppedEventData>(dLYYqZPEweMrBqfMxWkJuPLoTTKf._003C_003E9.MznSIablUHFZWQipaZzNRpnWYGvi)
			},
			{
				IdgRBTQYGXtErALnLvMihdplbGMl.ConflictsFound,
				new SafeAction<ConflictFoundEventData>(dLYYqZPEweMrBqfMxWkJuPLoTTKf._003C_003E9.tQddkxZiXyNIowHxpcbHtlDoMDTc)
			}
		};

		public static InputMapper Default => ohKVklMJdaSyFYbLXmtGNBGGGhuP ?? (ohKVklMJdaSyFYbLXmtGNBGGGhuP = new InputMapper(true));

		public Options options
		{
			get
			{
				Options obj = RzYiYiDxrYCYsNDMTjGjNjQXFAuf;
				if (obj == null)
				{
					if (!llpPECbDLwzFMRjaAIlgIKGLxpJf)
					{
						return RzYiYiDxrYCYsNDMTjGjNjQXFAuf = Default.options.Clone();
					}
					obj = (RzYiYiDxrYCYsNDMTjGjNjQXFAuf = new Options());
				}
				return obj;
			}
			set
			{
				RzYiYiDxrYCYsNDMTjGjNjQXFAuf = value;
			}
		}

		public Context mappingContext => RafCDvJogYlzJVRtoKWEVeNCXalFA.kITmTDezzxeBjcwGcQcYgJJFqES;

		public Status status => RafCDvJogYlzJVRtoKWEVeNCXalFA.AFCFdGxUZGYHNwdQpgkgrrHBlfEY;

		public float timeRemaining => RafCDvJogYlzJVRtoKWEVeNCXalFA.FLEgQoWWNLhztCXZrEqIFLmRlqouA;

		internal int GDlZvMSHIJQxrFzFCdegLaiqIntr => rXNuXdxQDGZMFFMwtcXEmUxckWPj;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.InputMapped;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<InputMappedEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.InputMapped;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<InputMappedEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.Error;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<ErrorEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.Error;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<ErrorEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.Canceled;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<CanceledEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.Canceled;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<CanceledEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.TimedOut;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<TimedOutEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.TimedOut;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<TimedOutEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.Started;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<StartedEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.Started;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<StartedEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.Stopped;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<StoppedEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.Stopped;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<StoppedEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.ConflictsFound;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<ConflictFoundEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					IdgRBTQYGXtErALnLvMihdplbGMl key = IdgRBTQYGXtErALnLvMihdplbGMl.ConflictsFound;
					gLonhnYSvnNmYnnZNZfnKedDJZej[key] = (SafeAction<ConflictFoundEventData>)gLonhnYSvnNmYnnZNZfnKedDJZej[key] - value;
				}
			}
		}

		private static int laKCPehvuPQnlTkRUMeGOjZZsELUA()
		{
			int yBATMRDlWzZkjGYTWPFCBzJUqUbC = YBATMRDlWzZkjGYTWPFCBzJUqUbC;
			if (YBATMRDlWzZkjGYTWPFCBzJUqUbC == int.MaxValue)
			{
				YBATMRDlWzZkjGYTWPFCBzJUqUbC = 0;
				return yBATMRDlWzZkjGYTWPFCBzJUqUbC;
			}
			YBATMRDlWzZkjGYTWPFCBzJUqUbC++;
			return yBATMRDlWzZkjGYTWPFCBzJUqUbC;
		}

		public InputMapper()
			: this(false)
		{
			rXNuXdxQDGZMFFMwtcXEmUxckWPj = laKCPehvuPQnlTkRUMeGOjZZsELUA();
		}

		private InputMapper(bool P_0)
		{
			llpPECbDLwzFMRjaAIlgIKGLxpJf = P_0;
			if (llpPECbDLwzFMRjaAIlgIKGLxpJf)
			{
				RzYiYiDxrYCYsNDMTjGjNjQXFAuf = new Options();
			}
			RafCDvJogYlzJVRtoKWEVeNCXalFA = new pLgBkIEphHWVyDwoOQgQOoAqZRbl(this, gLonhnYSvnNmYnnZNZfnKedDJZej);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<IdgRBTQYGXtErALnLvMihdplbGMl, SafeDelegate> item in gLonhnYSvnNmYnnZNZfnKedDJZej)
			{
				item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<IdgRBTQYGXtErALnLvMihdplbGMl, SafeDelegate> item in gLonhnYSvnNmYnnZNZfnKedDJZej)
			{
				item.Value.Clear();
			}
		}

		internal void swmCOcdONBePdkLnXDozsnXUkLlF(object P_0)
		{
		}

		internal void zfVzsLtnHLCdSbQNHzAdiAvDiBirA()
		{
		}

		public bool Start(Context mappingContext)
		{
			return PlvCMZmGymJxiqqwKJIidMBfbJcAA(mappingContext, (RzYiYiDxrYCYsNDMTjGjNjQXFAuf != null) ? RzYiYiDxrYCYsNDMTjGjNjQXFAuf : Default.options);
		}

		public void Stop()
		{
			RafCDvJogYlzJVRtoKWEVeNCXalFA.XfPPafUQzeDLekfjGmkmGSOCxraRA("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			zfVzsLtnHLCdSbQNHzAdiAvDiBirA();
			RzYiYiDxrYCYsNDMTjGjNjQXFAuf = null;
		}

		private bool PlvCMZmGymJxiqqwKJIidMBfbJcAA(Context P_0, Options P_1)
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
				RafCDvJogYlzJVRtoKWEVeNCXalFA.ejZwOqFhkLCLPbzdYzptbUyLcUGWA(P_0, P_1);
				return true;
			}
			catch
			{
				RafCDvJogYlzJVRtoKWEVeNCXalFA.XfPPafUQzeDLekfjGmkmGSOCxraRA("Failed to start due to an exception.");
				return false;
			}
		}
	}
}
