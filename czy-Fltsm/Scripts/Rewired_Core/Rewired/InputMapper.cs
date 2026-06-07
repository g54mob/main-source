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
			private int ujTsJIBAfpAlgKpYxQkILTLHpFTGb = -1;

			private ControllerMap BXuRJUdwOHEhTlqriQMaOwPWRcov;

			private ActionElementMap VCfZYNPuCIifgpbQSGtpCDtEDTnMA;

			private AxisRange TAogIETlYTcFlexmaLesDtAoNBNK = AxisRange.Positive;

			private bool ENBfSVhqsSLLxvvvDBgSqANhIJzAb;

			public int actionId
			{
				get
				{
					return ujTsJIBAfpAlgKpYxQkILTLHpFTGb;
				}
				set
				{
					if (!CvXbIxPJthZBDTsbyjpjxxmyYXHs())
					{
						ujTsJIBAfpAlgKpYxQkILTLHpFTGb = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(ujTsJIBAfpAlgKpYxQkILTLHpFTGb);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!CvXbIxPJthZBDTsbyjpjxxmyYXHs())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							ujTsJIBAfpAlgKpYxQkILTLHpFTGb = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							ujTsJIBAfpAlgKpYxQkILTLHpFTGb = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return BXuRJUdwOHEhTlqriQMaOwPWRcov;
				}
				set
				{
					if (!CvXbIxPJthZBDTsbyjpjxxmyYXHs())
					{
						BXuRJUdwOHEhTlqriQMaOwPWRcov = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return VCfZYNPuCIifgpbQSGtpCDtEDTnMA;
				}
				set
				{
					if (!CvXbIxPJthZBDTsbyjpjxxmyYXHs())
					{
						VCfZYNPuCIifgpbQSGtpCDtEDTnMA = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return TAogIETlYTcFlexmaLesDtAoNBNK;
				}
				set
				{
					if (!CvXbIxPJthZBDTsbyjpjxxmyYXHs())
					{
						TAogIETlYTcFlexmaLesDtAoNBNK = value;
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

			internal void kUHzhTWIPaKagsoJToNuewfYEpqI()
			{
				ENBfSVhqsSLLxvvvDBgSqANhIJzAb = true;
			}

			private bool CvXbIxPJthZBDTsbyjpjxxmyYXHs()
			{
				if (ENBfSVhqsSLLxvvvDBgSqANhIJzAb)
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
				destination.ujTsJIBAfpAlgKpYxQkILTLHpFTGb = source.ujTsJIBAfpAlgKpYxQkILTLHpFTGb;
				destination.BXuRJUdwOHEhTlqriQMaOwPWRcov = source.BXuRJUdwOHEhTlqriQMaOwPWRcov;
				destination.VCfZYNPuCIifgpbQSGtpCDtEDTnMA = source.VCfZYNPuCIifgpbQSGtpCDtEDTnMA;
				destination.TAogIETlYTcFlexmaLesDtAoNBNK = source.TAogIETlYTcFlexmaLesDtAoNBNK;
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

			private readonly Func<int, bool> COsFDnNrRxivoNWfOdqXnklGWIEb;

			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				if (COsFDnNrRxivoNWfOdqXnklGWIEb == null)
				{
					return false;
				}
				return COsFDnNrRxivoNWfOdqXnklGWIEb(maxInputFieldCount);
			}

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
				: base(P_0)
			{
				responseCallback = P_1;
				assignment = P_2;
				conflicts = P_3;
				isProtected = P_4;
				COsFDnNrRxivoNWfOdqXnklGWIEb = P_5;
			}
		}

		private enum UFviGzcFJWPLWtkesVKCqYMzytfbA
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

		private class zYhvzoDJuIbfNnExrDRygnpoAZKKA
		{
			private enum gCLlNYbtIaEfDVNrSWAIAwKCkeCo
			{
				Quit = 0,
				Continue = 1
			}

			private enum MchbriitlhvuuglGvtJPljzzWcUv
			{
				None = 0,
				ConflictChecking = 1
			}

			private class HKIrSWQzxTgLaMjntkOVgesRieVd
			{
				private Player RPuXtSjtnvgURxDfBskAcqnPIdlr;

				private int qKmBUrBDktvxqBlcoqqRwHQNqUauA;

				private Context VItFRAebfnVpvePqbfGXdQaMbUYbb;

				private ControllerType jBCwzOjkbUSnLXVgqprYEQNXcyZS;

				private int xuqMMLbokTiolGnypBScDiOKqcHWB;

				private ControllerPollingInfo BYKbpAVaRBOImvFdEBgofZyQQSkhA;

				private ModifierKeyFlags UrGbWFihcXpQorKKBmGmjLuAmskd;

				public Player rPAAyebsULGegjRiGRQxNftnFmwnb => RPuXtSjtnvgURxDfBskAcqnPIdlr;

				public int EbtmCaEIearGDfLmwqYpSvFzHswK => qKmBUrBDktvxqBlcoqqRwHQNqUauA;

				public Context DHYzEZTQmQjzEbSYTBBIOVralXah => VItFRAebfnVpvePqbfGXdQaMbUYbb;

				public ControllerType eauNbhtHABoDzKQwKEenqdLqczbq => jBCwzOjkbUSnLXVgqprYEQNXcyZS;

				public int qGKrndCnJUfnvIzjpSzBEQQzQpNoA => xuqMMLbokTiolGnypBScDiOKqcHWB;

				public ControllerPollingInfo IqqFOMdmzdFcnihEFXVzqKznMSEfb => BYKbpAVaRBOImvFdEBgofZyQQSkhA;

				public ModifierKeyFlags PPfXZujjrObITWjJVYTBLViuWxSv => UrGbWFihcXpQorKKBmGmjLuAmskd;

				public AxisRange VnPJMgUvMkSKybdWdaeCSxzljOBH
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (IqqFOMdmzdFcnihEFXVzqKznMSEfb.elementType == ControllerElementType.Axis)
						{
							result = ((VItFRAebfnVpvePqbfGXdQaMbUYbb.actionRange != AxisRange.Full) ? ((IqqFOMdmzdFcnihEFXVzqKznMSEfb.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
						}
						return result;
					}
				}

				public string OzCRmxmPzKxWOCzQdmuWkDJQtiCH
				{
					get
					{
						if (eauNbhtHABoDzKQwKEenqdLqczbq == ControllerType.Keyboard && PPfXZujjrObITWjJVYTBLViuWxSv != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(PPfXZujjrObITWjJVYTBLViuWxSv)} + {IqqFOMdmzdFcnihEFXVzqKznMSEfb.elementIdentifierName}";
						}
						string text = IqqFOMdmzdFcnihEFXVzqKznMSEfb.elementIdentifierName;
						if (IqqFOMdmzdFcnihEFXVzqKznMSEfb.elementType == ControllerElementType.Axis)
						{
							if (VnPJMgUvMkSKybdWdaeCSxzljOBH == AxisRange.Positive)
							{
								text += " +";
							}
							else if (VnPJMgUvMkSKybdWdaeCSxzljOBH == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				public void jCADSIfcbbOZVRhHtkRbtlAvhSnsA(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					sorAWolERSsrsNZwKSIsvvkqehhy();
					RPuXtSjtnvgURxDfBskAcqnPIdlr = P_0;
					qKmBUrBDktvxqBlcoqqRwHQNqUauA = P_1.actionId;
					jBCwzOjkbUSnLXVgqprYEQNXcyZS = P_1.controllerMap.controllerType;
					xuqMMLbokTiolGnypBScDiOKqcHWB = P_1.controllerMap.controllerId;
					VItFRAebfnVpvePqbfGXdQaMbUYbb = P_1;
					jBCwzOjkbUSnLXVgqprYEQNXcyZS = P_1.controllerMap.controllerType;
					xuqMMLbokTiolGnypBScDiOKqcHWB = P_1.controllerMap.controllerId;
					P_1.kUHzhTWIPaKagsoJToNuewfYEpqI();
				}

				public void sorAWolERSsrsNZwKSIsvvkqehhy()
				{
					RPuXtSjtnvgURxDfBskAcqnPIdlr = null;
					qKmBUrBDktvxqBlcoqqRwHQNqUauA = -1;
					VItFRAebfnVpvePqbfGXdQaMbUYbb = null;
					jBCwzOjkbUSnLXVgqprYEQNXcyZS = ControllerType.Keyboard;
					xuqMMLbokTiolGnypBScDiOKqcHWB = -1;
					BYKbpAVaRBOImvFdEBgofZyQQSkhA = default(ControllerPollingInfo);
					UrGbWFihcXpQorKKBmGmjLuAmskd = ModifierKeyFlags.None;
				}

				public ElementAssignment vHsgXlBkFTYODDiCpCDRevcmPNvv(ControllerPollingInfo P_0)
				{
					BYKbpAVaRBOImvFdEBgofZyQQSkhA = P_0;
					return iilaKfbaklgQWRYysmtCezDbhHvw();
				}

				public ElementAssignment JjnhsVymSkzllZSlXfnmXlHawgbS(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					BYKbpAVaRBOImvFdEBgofZyQQSkhA = P_0;
					UrGbWFihcXpQorKKBmGmjLuAmskd = P_1;
					return iilaKfbaklgQWRYysmtCezDbhHvw();
				}

				public ElementAssignment iilaKfbaklgQWRYysmtCezDbhHvw()
				{
					return new ElementAssignment(eauNbhtHABoDzKQwKEenqdLqczbq, BYKbpAVaRBOImvFdEBgofZyQQSkhA.elementType, BYKbpAVaRBOImvFdEBgofZyQQSkhA.elementIdentifierId, VnPJMgUvMkSKybdWdaeCSxzljOBH, BYKbpAVaRBOImvFdEBgofZyQQSkhA.keyboardKey, UrGbWFihcXpQorKKBmGmjLuAmskd, qKmBUrBDktvxqBlcoqqRwHQNqUauA, (VItFRAebfnVpvePqbfGXdQaMbUYbb.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (VItFRAebfnVpvePqbfGXdQaMbUYbb.actionElementMapToReplace != null) ? VItFRAebfnVpvePqbfGXdQaMbUYbb.actionElementMapToReplace.id : (-1));
				}
			}

			private sealed class kUrCrKUrBBWXXAQqbIUuPmxvcNXh
			{
				public ActionElementMap QHaSjGaHPFeBzfkTKaTVSuUOtUPAA;

				internal bool DEYsDjAFKbSIXgckQFWycSdhhVRn(ElementAssignmentConflictInfo P_0)
				{
					return P_0.elementMapId == QHaSjGaHPFeBzfkTKaTVSuUOtUPAA.id;
				}
			}

			private sealed class gJGDQwMfYChMttlYEsJPZICnppEo
			{
				public zYhvzoDJuIbfNnExrDRygnpoAZKKA copMJBUfwDDftcTcQdPapSYDWTNH;

				public ElementAssignmentInfo sgvrtVyiXyntEDJQiEgxHbBDEBesA;

				public IList<ElementAssignmentConflictInfo> RVQtBzuONdaxhCRPSmLTgXyXEyahA;

				public bool OvYWPQEkcVyyUCLcOgqseyFZpUBc;

				internal bool EanytfoPNNlmTYOMcTmshoTXOeYX(int P_0)
				{
					return copMJBUfwDDftcTcQdPapSYDWTNH.LdeKVMrGdHRAuRrAcCDWmlSmeNLp(sgvrtVyiXyntEDJQiEgxHbBDEBesA, RVQtBzuONdaxhCRPSmLTgXyXEyahA, OvYWPQEkcVyyUCLcOgqseyFZpUBc, P_0);
				}
			}

			private readonly InputMapper BTcTmpbioZfMAjqfdWzMuoQwNdvgb;

			private readonly Options GRvUcwViDNJoEwWGjcERRkCthFrBA = new Options();

			private readonly HKIrSWQzxTgLaMjntkOVgesRieVd vQDBtsRMPqhzxYxnVdnifNeXtpSA = new HKIrSWQzxTgLaMjntkOVgesRieVd();

			private readonly Dictionary<UFviGzcFJWPLWtkesVKCqYMzytfbA, SafeDelegate> MLoDNnfBvoMDxHgSRoySrJjOwqbfA;

			private readonly Dictionary<string, SafeDelegate> MBxvqAHmeTrwocsGAnPSFEUfJTzq;

			private Status vjCvNUgICZgLJPQmuVcrFqcAjQvX;

			private MchbriitlhvuuglGvtJPljzzWcUv cyQIqKsLzsdbxeBisOegsNSeivsx;

			private double FCVlrXompZYZWWwYnfVSXnhRiZfZ;

			private bool lyREQHfQiJjdvPBRwhNkglFjGyxP;

			private List<Player> rjaMNynITAvtbfLdsAvYDEIlZKjB = new List<Player>();

			private readonly List<ControllerPollingInfo> xqqZMmcMvVAsxknPPwNEgVteIBCh = new List<ControllerPollingInfo>();

			private ElementAssignment wwetRxWBINzrhMEALVuYdAGUYHFm;

			public Status UbRwgmicOHatqWsPIZOSKcoRDrrP => vjCvNUgICZgLJPQmuVcrFqcAjQvX;

			public float NwZXyAVvEGZPYitKMROgmCTTjkJP
			{
				get
				{
					if (vjCvNUgICZgLJPQmuVcrFqcAjQvX == Status.Idle)
					{
						return 0f;
					}
					if (GRvUcwViDNJoEwWGjcERRkCthFrBA.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, FCVlrXompZYZWWwYnfVSXnhRiZfZ + (double)GRvUcwViDNJoEwWGjcERRkCthFrBA.timeout - ReInput.unscaledTime);
				}
			}

			public Context qGHOOlYGiueJwXRtnxVCfUgDAcfM
			{
				get
				{
					if (vjCvNUgICZgLJPQmuVcrFqcAjQvX == Status.Idle)
					{
						return null;
					}
					return vQDBtsRMPqhzxYxnVdnifNeXtpSA.DHYzEZTQmQjzEbSYTBBIOVralXah;
				}
			}

			private bool TaSuwevxMnhlXnVAzoSWDKSrXqfK
			{
				get
				{
					if (lyREQHfQiJjdvPBRwhNkglFjGyxP)
					{
						return false;
					}
					return GRvUcwViDNJoEwWGjcERRkCthFrBA.timeout > 0f;
				}
			}

			public zYhvzoDJuIbfNnExrDRygnpoAZKKA(InputMapper P_0, Dictionary<UFviGzcFJWPLWtkesVKCqYMzytfbA, SafeDelegate> P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("events");
				}
				BTcTmpbioZfMAjqfdWzMuoQwNdvgb = P_0;
				MLoDNnfBvoMDxHgSRoySrJjOwqbfA = P_1;
				ITLRIkFGlTGOGhsOxlaEkRbxIJDK();
			}

			protected virtual void DVzzrcfExIwGMBXUzlRbRaQflAXB()
			{
				try
				{
					HDowdCVaRTmRdWCgnGMZvqBVdFJm();
				}
				finally
				{
					base.Finalize();
				}
			}

			public void qRQTmAUjxYrOeTBurCQVpjDRqKbs(Context P_0, Options P_1)
			{
				if (vjCvNUgICZgLJPQmuVcrFqcAjQvX != Status.Idle)
				{
					SoLjBBkrYKOQnlGQcCMMhvfjqnSu("User started a new listening session.");
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
				Options.Copy(P_1, GRvUcwViDNJoEwWGjcERRkCthFrBA);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					qoUggkDGTVGQbMeSiRUrHcVpLXnuA("No Action found for actionId: " + P_0.actionId);
					return;
				}
				vQDBtsRMPqhzxYxnVdnifNeXtpSA.jCADSIfcbbOZVRhHtkRbtlAvhSnsA(player, P_0);
				vjCvNUgICZgLJPQmuVcrFqcAjQvX = Status.Listening;
				VgnYLHfFJsqJUkBAmJdRzeTUdlmGA();
				hixtZBjEOlhHdehbSyYEvTYeaStP();
				NfkItrDhokVZoOdvLjgsrTYAMIJpA();
				QpPVGiexAzLBYgbNwaRFIBQcYObS();
			}

			public void LAruPDdqlvoNNJafFQEfmjUzeXk(string P_0)
			{
				if (vjCvNUgICZgLJPQmuVcrFqcAjQvX != Status.Idle)
				{
					SoLjBBkrYKOQnlGQcCMMhvfjqnSu(P_0);
				}
			}

			private void jKOPgqfHFiDWyZtrGcalnbkAJaCJA(UpdateLoopType P_0)
			{
				if (P_0 == UpdateLoopType.Update && vjCvNUgICZgLJPQmuVcrFqcAjQvX == Status.Listening)
				{
					ElementAssignment elementAssignment;
					if (TaSuwevxMnhlXnVAzoSWDKSrXqfK && NwZXyAVvEGZPYitKMROgmCTTjkJP <= 0f)
					{
						dHMuvSLfhoqdatCRoQsBpftudgAy();
					}
					else if (ReInput.controllers.GetController(vQDBtsRMPqhzxYxnVdnifNeXtpSA.eauNbhtHABoDzKQwKEenqdLqczbq, vQDBtsRMPqhzxYxnVdnifNeXtpSA.qGKrndCnJUfnvIzjpSzBEQQzQpNoA) == null)
					{
						qoUggkDGTVGQbMeSiRUrHcVpLXnuA("Controller not found for type: " + vQDBtsRMPqhzxYxnVdnifNeXtpSA.eauNbhtHABoDzKQwKEenqdLqczbq.ToString() + " id: " + vQDBtsRMPqhzxYxnVdnifNeXtpSA.qGKrndCnJUfnvIzjpSzBEQQzQpNoA);
					}
					else if (BKjLtsuaobZdsHEqAXJRpDONXQbD(out elementAssignment) != gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Quit && HBIaoPyWizFHjgaCSHLbAXzdpbuCB(elementAssignment) != gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Quit)
					{
						oTQQeeyCOMTIcHqeiwWWwTmqQVGb(elementAssignment);
					}
				}
			}

			private void UTNmiJueEUkoUczkAnGMXYGBSXVD()
			{
				if (vjCvNUgICZgLJPQmuVcrFqcAjQvX != Status.Idle)
				{
					ITLRIkFGlTGOGhsOxlaEkRbxIJDK();
					HDowdCVaRTmRdWCgnGMZvqBVdFJm();
					kmyVSUGoJKBBNZIBivyYcnOjxETc();
				}
			}

			private void ITLRIkFGlTGOGhsOxlaEkRbxIJDK()
			{
				vjCvNUgICZgLJPQmuVcrFqcAjQvX = Status.Idle;
				FCVlrXompZYZWWwYnfVSXnhRiZfZ = 0.0;
				GRvUcwViDNJoEwWGjcERRkCthFrBA.aJzxjCLwGRmyVfzOpuVfjpgCVnuM();
				vQDBtsRMPqhzxYxnVdnifNeXtpSA.sorAWolERSsrsNZwKSIsvvkqehhy();
				wwetRxWBINzrhMEALVuYdAGUYHFm = default(ElementAssignment);
				cyQIqKsLzsdbxeBisOegsNSeivsx = MchbriitlhvuuglGvtJPljzzWcUv.None;
				lyREQHfQiJjdvPBRwhNkglFjGyxP = false;
				rjaMNynITAvtbfLdsAvYDEIlZKjB.Clear();
			}

			private gCLlNYbtIaEfDVNrSWAIAwKCkeCo BKjLtsuaobZdsHEqAXJRpDONXQbD(out ElementAssignment P_0)
			{
				if (!QAmCtzqbZictHGijjhBdpJHFPFoe(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Quit;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !oZrBtkGwtLRYxnhXEuttLDXuNJauA(item, GRvUcwViDNJoEwWGjcERRkCthFrBA))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Quit;
				}
				if (!TAVcbxIALVGENssxRADsEnhmcIgB(vQDBtsRMPqhzxYxnVdnifNeXtpSA, controllerPollingInfo, GRvUcwViDNJoEwWGjcERRkCthFrBA))
				{
					P_0 = default(ElementAssignment);
					return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Quit;
				}
				P_0 = vQDBtsRMPqhzxYxnVdnifNeXtpSA.vHsgXlBkFTYODDiCpCDRevcmPNvv(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Continue;
			}

			private bool QAmCtzqbZictHGijjhBdpJHFPFoe(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = vQDBtsRMPqhzxYxnVdnifNeXtpSA.eauNbhtHABoDzKQwKEenqdLqczbq;
				int controllerId = vQDBtsRMPqhzxYxnVdnifNeXtpSA.qGKrndCnJUfnvIzjpSzBEQQzQpNoA;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = sVctSxVVjHFUibyXfjFOUXYckvWt(out P_1);
					return true;
				}
				if (GRvUcwViDNJoEwWGjcERRkCthFrBA.allowAxes)
				{
					if (GRvUcwViDNJoEwWGjcERRkCthFrBA.allowButtons)
					{
						if (vQDBtsRMPqhzxYxnVdnifNeXtpSA.rPAAyebsULGegjRiGRQxNftnFmwnb != null)
						{
							P_0 = vQDBtsRMPqhzxYxnVdnifNeXtpSA.rPAAyebsULGegjRiGRQxNftnFmwnb.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(vQDBtsRMPqhzxYxnVdnifNeXtpSA.eauNbhtHABoDzKQwKEenqdLqczbq, vQDBtsRMPqhzxYxnVdnifNeXtpSA.qGKrndCnJUfnvIzjpSzBEQQzQpNoA);
						}
					}
					else if (vQDBtsRMPqhzxYxnVdnifNeXtpSA.rPAAyebsULGegjRiGRQxNftnFmwnb != null)
					{
						P_0 = vQDBtsRMPqhzxYxnVdnifNeXtpSA.rPAAyebsULGegjRiGRQxNftnFmwnb.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!GRvUcwViDNJoEwWGjcERRkCthFrBA.allowButtons)
					{
						qoUggkDGTVGQbMeSiRUrHcVpLXnuA("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (vQDBtsRMPqhzxYxnVdnifNeXtpSA.rPAAyebsULGegjRiGRQxNftnFmwnb != null)
					{
						P_0 = vQDBtsRMPqhzxYxnVdnifNeXtpSA.rPAAyebsULGegjRiGRQxNftnFmwnb.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> sVctSxVVjHFUibyXfjFOUXYckvWt(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				xqqZMmcMvVAsxknPPwNEgVteIBCh.Clear();
				if (!GRvUcwViDNJoEwWGjcERRkCthFrBA.allowButtons)
				{
					return xqqZMmcMvVAsxknPPwNEgVteIBCh;
				}
				xqqZMmcMvVAsxknPPwNEgVteIBCh.Add(cAjDIluSJzVexGxzFSARvcHzPQDI(GRvUcwViDNJoEwWGjcERRkCthFrBA, out P_0));
				return xqqZMmcMvVAsxknPPwNEgVteIBCh;
			}

			private ControllerPollingInfo cAjDIluSJzVexGxzFSARvcHzPQDI(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = mOQhcFKpeoZwGmihwZehJDcSJWdA(P_0, out flag, out P_1, out text);
				if (flag)
				{
					VgnYLHfFJsqJUkBAmJdRzeTUdlmGA();
				}
				return result;
			}

			private static ControllerPollingInfo mOQhcFKpeoZwGmihwZehJDcSJWdA(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
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

			private static bool oZrBtkGwtLRYxnhXEuttLDXuNJauA(ControllerPollingInfo P_0, Options P_1)
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
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.xdkFhSAprUKSNCDdGaUGOrjaJBGld<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool TAVcbxIALVGENssxRADsEnhmcIgB(HKIrSWQzxTgLaMjntkOVgesRieVd P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.VnPJMgUvMkSKybdWdaeCSxzljOBH == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void hixtZBjEOlhHdehbSyYEvTYeaStP()
			{
				if (!GRvUcwViDNJoEwWGjcERRkCthFrBA.checkForConflicts)
				{
					return;
				}
				if (GRvUcwViDNJoEwWGjcERRkCthFrBA.checkForConflictsWithSelf && vQDBtsRMPqhzxYxnVdnifNeXtpSA.rPAAyebsULGegjRiGRQxNftnFmwnb != null)
				{
					ListTools.AddIfUnique(rjaMNynITAvtbfLdsAvYDEIlZKjB, vQDBtsRMPqhzxYxnVdnifNeXtpSA.rPAAyebsULGegjRiGRQxNftnFmwnb);
				}
				if (GRvUcwViDNJoEwWGjcERRkCthFrBA.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(rjaMNynITAvtbfLdsAvYDEIlZKjB, ReInput.players.SystemPlayer);
				}
				if (GRvUcwViDNJoEwWGjcERRkCthFrBA.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(rjaMNynITAvtbfLdsAvYDEIlZKjB, players[i]);
					}
				}
				else
				{
					if (GRvUcwViDNJoEwWGjcERRkCthFrBA.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(GRvUcwViDNJoEwWGjcERRkCthFrBA.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(rjaMNynITAvtbfLdsAvYDEIlZKjB, allPlayers[j]);
						}
					}
				}
			}

			private gCLlNYbtIaEfDVNrSWAIAwKCkeCo HBIaoPyWizFHjgaCSHLbAXzdpbuCB(ElementAssignment P_0)
			{
				if (GRvUcwViDNJoEwWGjcERRkCthFrBA.checkForConflicts && vQDBtsRMPqhzxYxnVdnifNeXtpSA.rPAAyebsULGegjRiGRQxNftnFmwnb != null && sRFvtUAUsAFDPtJeeXsCASvbSZXt(vQDBtsRMPqhzxYxnVdnifNeXtpSA, P_0, rjaMNynITAvtbfLdsAvYDEIlZKjB))
				{
					return LhMERvopsXXomxfgpBCnerCDGXWPA(P_0);
				}
				return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Continue;
			}

			private static bool sRFvtUAUsAFDPtJeeXsCASvbSZXt(HKIrSWQzxTgLaMjntkOVgesRieVd P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.rPAAyebsULGegjRiGRQxNftnFmwnb == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!qfnsbeQyAYdDPICBrfJaFJUWZUYlA(P_0, P_1, out var conflictCheck))
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

			private static bool TkKDMFCBHxRqtUaTRPOsoehTnbxIA(HKIrSWQzxTgLaMjntkOVgesRieVd P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.rPAAyebsULGegjRiGRQxNftnFmwnb == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!qfnsbeQyAYdDPICBrfJaFJUWZUYlA(P_0, P_1, out var conflictCheck))
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

			private static IList<ElementAssignmentConflictInfo> fjTYFnLzPIUpORsYNrNulxqgxwZp(HKIrSWQzxTgLaMjntkOVgesRieVd P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.rPAAyebsULGegjRiGRQxNftnFmwnb == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!qfnsbeQyAYdDPICBrfJaFJUWZUYlA(P_0, P_1, out var conflictCheck))
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

			private static bool qfnsbeQyAYdDPICBrfJaFJUWZUYlA(HKIrSWQzxTgLaMjntkOVgesRieVd P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				if (P_0 == null || (player = P_0.rPAAyebsULGegjRiGRQxNftnFmwnb) == null)
				{
					P_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				P_2 = P_1.ToElementAssignmentConflictCheck();
				P_2.playerId = player.id;
				P_2.controllerType = P_0.eauNbhtHABoDzKQwKEenqdLqczbq;
				P_2.controllerId = P_0.qGKrndCnJUfnvIzjpSzBEQQzQpNoA;
				P_2.controllerMapId = P_0.DHYzEZTQmQjzEbSYTBBIOVralXah.controllerMap.id;
				P_2.controllerMapCategoryId = P_0.DHYzEZTQmQjzEbSYTBBIOVralXah.controllerMap.categoryId;
				if (P_0.DHYzEZTQmQjzEbSYTBBIOVralXah.actionElementMapToReplace != null)
				{
					P_2.elementMapId = P_0.DHYzEZTQmQjzEbSYTBBIOVralXah.actionElementMapToReplace.id;
				}
				return true;
			}

			private static void qSWISwehmjIkIBqbcEnLBGfxjzdK(HKIrSWQzxTgLaMjntkOVgesRieVd P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.rPAAyebsULGegjRiGRQxNftnFmwnb == null)
				{
					return;
				}
				if (!qfnsbeQyAYdDPICBrfJaFJUWZUYlA(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void NfkItrDhokVZoOdvLjgsrTYAMIJpA()
			{
				ReInput.UpdateEndedEvent -= jKOPgqfHFiDWyZtrGcalnbkAJaCJA;
				ReInput.UpdateEndedEvent += jKOPgqfHFiDWyZtrGcalnbkAJaCJA;
			}

			private void HDowdCVaRTmRdWCgnGMZvqBVdFJm()
			{
				ReInput.UpdateEndedEvent -= jKOPgqfHFiDWyZtrGcalnbkAJaCJA;
			}

			private bool tJQBxOCcnICVjfzNfNbjbksadbCtd(UFviGzcFJWPLWtkesVKCqYMzytfbA P_0)
			{
				SafeDelegate safeDelegate = MLoDNnfBvoMDxHgSRoySrJjOwqbfA[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void QaqFZMhaoCOMRDHpCIrilTUrbMemb<_0001>(UFviGzcFJWPLWtkesVKCqYMzytfbA P_0, _0001 P_1)
			{
				SafeAction<_0001> safeAction = (SafeAction<_0001>)MLoDNnfBvoMDxHgSRoySrJjOwqbfA[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void VgnYLHfFJsqJUkBAmJdRzeTUdlmGA()
			{
				FCVlrXompZYZWWwYnfVSXnhRiZfZ = ReInput.unscaledTime;
			}

			private void VMlpPqCcHylmUKcyrNTuSeNikRLT()
			{
				lyREQHfQiJjdvPBRwhNkglFjGyxP = true;
			}

			private bool LdeKVMrGdHRAuRrAcCDWmlSmeNLp(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
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
					if (RYRHujidGZEiuiqIVgBcXhcvRupBb(elementType, axisRange, axisContribution, controller.GetElementById(P_0.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid).type, P_0.axisRange, P_0.axisContribution))
					{
						num++;
					}
				}
				using (IEnumerator<ActionElementMap> enumerator = elementAssignmentConflictInfo.controllerMap.ElementMapsWithAction(actionId).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						kUrCrKUrBBWXXAQqbIUuPmxvcNXh kUrCrKUrBBWXXAQqbIUuPmxvcNXh2 = new kUrCrKUrBBWXXAQqbIUuPmxvcNXh();
						kUrCrKUrBBWXXAQqbIUuPmxvcNXh2.QHaSjGaHPFeBzfkTKaTVSuUOtUPAA = enumerator.Current;
						if (kUrCrKUrBBWXXAQqbIUuPmxvcNXh2.QHaSjGaHPFeBzfkTKaTVSuUOtUPAA.id != elementMap.id && ListTools.FindIndex(list, kUrCrKUrBBWXXAQqbIUuPmxvcNXh2.DEYsDjAFKbSIXgckQFWycSdhhVRn) < 0 && RYRHujidGZEiuiqIVgBcXhcvRupBb(elementType, axisRange, axisContribution, kUrCrKUrBBWXXAQqbIUuPmxvcNXh2.QHaSjGaHPFeBzfkTKaTVSuUOtUPAA.elementType, kUrCrKUrBBWXXAQqbIUuPmxvcNXh2.QHaSjGaHPFeBzfkTKaTVSuUOtUPAA.axisRange, kUrCrKUrBBWXXAQqbIUuPmxvcNXh2.QHaSjGaHPFeBzfkTKaTVSuUOtUPAA.axisContribution))
						{
							num++;
						}
					}
				}
				return num < P_3;
			}

			private bool fAqohivsQLIdaWncDCOAjrEQBZVYA(HKIrSWQzxTgLaMjntkOVgesRieVd P_0, ElementAssignment P_1, bool P_2, out string P_3)
			{
				if (P_0 == null)
				{
					P_3 = "Mapping is null reference.";
					return false;
				}
				List<Player> list = new List<Player> { P_0.rPAAyebsULGegjRiGRQxNftnFmwnb };
				IList<ElementAssignmentConflictInfo> list2 = fjTYFnLzPIUpORsYNrNulxqgxwZp(P_0, P_1, list);
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
				if (P_0.DHYzEZTQmQjzEbSYTBBIOVralXah.actionElementMapToReplace == null)
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
				ActionElementMap actionElementMap2 = new ActionElementMap(P_0.DHYzEZTQmQjzEbSYTBBIOVralXah.actionElementMapToReplace);
				qSWISwehmjIkIBqbcEnLBGfxjzdK(P_0, P_1, list);
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
				elementAssignmentConflictInfo.controllerMap.ReplaceOrCreateElementMap(ElementAssignment.CompleteAssignment(P_0.eauNbhtHABoDzKQwKEenqdLqczbq, elementType, elementIdentifierId, axisRange, keyCode, modifierKeyFlags, actionId, axisContribution, invert));
				P_3 = null;
				return true;
			}

			private static bool RYRHujidGZEiuiqIVgBcXhcvRupBb(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
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

			private void PsXyHDkUxcsdRlviISwnVJgKdadI(ActionElementMap P_0)
			{
				jFDDFRnrCGfQeJFJKCuUYYUpyNWq(P_0);
				UTNmiJueEUkoUczkAnGMXYGBSXVD();
			}

			private void SoLjBBkrYKOQnlGQcCMMhvfjqnSu(string P_0)
			{
				OgcvNdqavaUpAIZNLweeSwFDuLNx(P_0);
				UTNmiJueEUkoUczkAnGMXYGBSXVD();
			}

			private gCLlNYbtIaEfDVNrSWAIAwKCkeCo LhMERvopsXXomxfgpBCnerCDGXWPA(ElementAssignment P_0)
			{
				if (tJQBxOCcnICVjfzNfNbjbksadbCtd(UFviGzcFJWPLWtkesVKCqYMzytfbA.ConflictsFound))
				{
					bool flag = TkKDMFCBHxRqtUaTRPOsoehTnbxIA(vQDBtsRMPqhzxYxnVdnifNeXtpSA, P_0, rjaMNynITAvtbfLdsAvYDEIlZKjB);
					wwetRxWBINzrhMEALVuYdAGUYHFm = P_0;
					IList<ElementAssignmentConflictInfo> list = fjTYFnLzPIUpORsYNrNulxqgxwZp(vQDBtsRMPqhzxYxnVdnifNeXtpSA, P_0, rjaMNynITAvtbfLdsAvYDEIlZKjB);
					cyQIqKsLzsdbxeBisOegsNSeivsx = MchbriitlhvuuglGvtJPljzzWcUv.ConflictChecking;
					ILRDpgxuYCpVNBmadSKYARvnhWeS();
					dLMBVQBNUvSqUgKTitaDKixZPGBH(new ElementAssignmentInfo(vQDBtsRMPqhzxYxnVdnifNeXtpSA.DHYzEZTQmQjzEbSYTBBIOVralXah.controllerMap, P_0), list, flag);
					return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Quit;
				}
				return yeNagBWdtuVHchevnfFbHpvLUCZUA(GRvUcwViDNJoEwWGjcERRkCthFrBA.defaultActionWhenConflictFound, P_0);
			}

			private gCLlNYbtIaEfDVNrSWAIAwKCkeCo yeNagBWdtuVHchevnfFbHpvLUCZUA(ConflictResponse P_0, ElementAssignment P_1)
			{
				return YQkvfgGiUiqieXxajJAbqODChxOF(P_0, P_1, TkKDMFCBHxRqtUaTRPOsoehTnbxIA(vQDBtsRMPqhzxYxnVdnifNeXtpSA, P_1, rjaMNynITAvtbfLdsAvYDEIlZKjB));
			}

			private gCLlNYbtIaEfDVNrSWAIAwKCkeCo YQkvfgGiUiqieXxajJAbqODChxOF(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					SoLjBBkrYKOQnlGQcCMMhvfjqnSu("Mapping assignment was canceled due to a conflict.");
					return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Quit;
				case ConflictResponse.Replace:
					if (P_2)
					{
						SoLjBBkrYKOQnlGQcCMMhvfjqnSu("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Quit;
					}
					qSWISwehmjIkIBqbcEnLBGfxjzdK(vQDBtsRMPqhzxYxnVdnifNeXtpSA, P_1, rjaMNynITAvtbfLdsAvYDEIlZKjB);
					return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Continue;
				case ConflictResponse.Add:
					return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Continue;
				case ConflictResponse.Ignore:
					JEkgHLZwtSdhNEBFVxNiriFTggzf();
					return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Quit;
				case ConflictResponse.Swap:
				{
					if (!fAqohivsQLIdaWncDCOAjrEQBZVYA(vQDBtsRMPqhzxYxnVdnifNeXtpSA, P_1, P_2, out var text))
					{
						SoLjBBkrYKOQnlGQcCMMhvfjqnSu(text);
						return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Quit;
					}
					return gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Continue;
				}
				default:
					throw new NotImplementedException();
				}
			}

			private void dHMuvSLfhoqdatCRoQsBpftudgAy()
			{
				oRkTpAUCinbJAVclSrPquAEEjpvu();
				UTNmiJueEUkoUczkAnGMXYGBSXVD();
			}

			private void qoUggkDGTVGQbMeSiRUrHcVpLXnuA(string P_0)
			{
				pVTklCubgtmyipxRQTluFciDsKgP(P_0);
				UTNmiJueEUkoUczkAnGMXYGBSXVD();
			}

			private void ILRDpgxuYCpVNBmadSKYARvnhWeS()
			{
				VMlpPqCcHylmUKcyrNTuSeNikRLT();
				HDowdCVaRTmRdWCgnGMZvqBVdFJm();
				vjCvNUgICZgLJPQmuVcrFqcAjQvX = Status.AwaitingResponse;
			}

			private void JEkgHLZwtSdhNEBFVxNiriFTggzf()
			{
				vjCvNUgICZgLJPQmuVcrFqcAjQvX = Status.Listening;
				cyQIqKsLzsdbxeBisOegsNSeivsx = MchbriitlhvuuglGvtJPljzzWcUv.None;
				VgnYLHfFJsqJUkBAmJdRzeTUdlmGA();
				NfkItrDhokVZoOdvLjgsrTYAMIJpA();
			}

			private void oTQQeeyCOMTIcHqeiwWWwTmqQVGb(ElementAssignment P_0)
			{
				if (vQDBtsRMPqhzxYxnVdnifNeXtpSA.DHYzEZTQmQjzEbSYTBBIOVralXah.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					PsXyHDkUxcsdRlviISwnVJgKdadI(result);
				}
				else
				{
					qoUggkDGTVGQbMeSiRUrHcVpLXnuA("Failed to create element assignment.");
				}
			}

			private void jFDDFRnrCGfQeJFJKCuUYYUpyNWq(ActionElementMap P_0)
			{
				if (tJQBxOCcnICVjfzNfNbjbksadbCtd(UFviGzcFJWPLWtkesVKCqYMzytfbA.InputMapped))
				{
					QaqFZMhaoCOMRDHpCIrilTUrbMemb(UFviGzcFJWPLWtkesVKCqYMzytfbA.InputMapped, new InputMappedEventData(BTcTmpbioZfMAjqfdWzMuoQwNdvgb, P_0));
				}
			}

			private void oRkTpAUCinbJAVclSrPquAEEjpvu()
			{
				if (tJQBxOCcnICVjfzNfNbjbksadbCtd(UFviGzcFJWPLWtkesVKCqYMzytfbA.TimedOut))
				{
					QaqFZMhaoCOMRDHpCIrilTUrbMemb(UFviGzcFJWPLWtkesVKCqYMzytfbA.TimedOut, new TimedOutEventData(BTcTmpbioZfMAjqfdWzMuoQwNdvgb));
				}
			}

			private void pVTklCubgtmyipxRQTluFciDsKgP(string P_0)
			{
				if (tJQBxOCcnICVjfzNfNbjbksadbCtd(UFviGzcFJWPLWtkesVKCqYMzytfbA.Error))
				{
					QaqFZMhaoCOMRDHpCIrilTUrbMemb(UFviGzcFJWPLWtkesVKCqYMzytfbA.Error, new ErrorEventData(BTcTmpbioZfMAjqfdWzMuoQwNdvgb, P_0));
				}
			}

			private void OgcvNdqavaUpAIZNLweeSwFDuLNx(string P_0)
			{
				if (tJQBxOCcnICVjfzNfNbjbksadbCtd(UFviGzcFJWPLWtkesVKCqYMzytfbA.Canceled))
				{
					QaqFZMhaoCOMRDHpCIrilTUrbMemb(UFviGzcFJWPLWtkesVKCqYMzytfbA.Canceled, new CanceledEventData(BTcTmpbioZfMAjqfdWzMuoQwNdvgb, P_0));
				}
			}

			private void dLMBVQBNUvSqUgKTitaDKixZPGBH(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				gJGDQwMfYChMttlYEsJPZICnppEo gJGDQwMfYChMttlYEsJPZICnppEo2 = new gJGDQwMfYChMttlYEsJPZICnppEo();
				gJGDQwMfYChMttlYEsJPZICnppEo2.copMJBUfwDDftcTcQdPapSYDWTNH = this;
				gJGDQwMfYChMttlYEsJPZICnppEo2.sgvrtVyiXyntEDJQiEgxHbBDEBesA = P_0;
				gJGDQwMfYChMttlYEsJPZICnppEo2.RVQtBzuONdaxhCRPSmLTgXyXEyahA = P_1;
				gJGDQwMfYChMttlYEsJPZICnppEo2.OvYWPQEkcVyyUCLcOgqseyFZpUBc = P_2;
				if (tJQBxOCcnICVjfzNfNbjbksadbCtd(UFviGzcFJWPLWtkesVKCqYMzytfbA.ConflictsFound))
				{
					QaqFZMhaoCOMRDHpCIrilTUrbMemb(UFviGzcFJWPLWtkesVKCqYMzytfbA.ConflictsFound, new ConflictFoundEventData(BTcTmpbioZfMAjqfdWzMuoQwNdvgb, WCsmbfuSuscWPIxAdZqNcXdaSidc, gJGDQwMfYChMttlYEsJPZICnppEo2.sgvrtVyiXyntEDJQiEgxHbBDEBesA, gJGDQwMfYChMttlYEsJPZICnppEo2.RVQtBzuONdaxhCRPSmLTgXyXEyahA, gJGDQwMfYChMttlYEsJPZICnppEo2.OvYWPQEkcVyyUCLcOgqseyFZpUBc, gJGDQwMfYChMttlYEsJPZICnppEo2.EanytfoPNNlmTYOMcTmshoTXOeYX));
				}
			}

			private void QpPVGiexAzLBYgbNwaRFIBQcYObS()
			{
				if (tJQBxOCcnICVjfzNfNbjbksadbCtd(UFviGzcFJWPLWtkesVKCqYMzytfbA.Started))
				{
					QaqFZMhaoCOMRDHpCIrilTUrbMemb(UFviGzcFJWPLWtkesVKCqYMzytfbA.Started, new StartedEventData(BTcTmpbioZfMAjqfdWzMuoQwNdvgb));
				}
			}

			private void kmyVSUGoJKBBNZIBivyYcnOjxETc()
			{
				if (tJQBxOCcnICVjfzNfNbjbksadbCtd(UFviGzcFJWPLWtkesVKCqYMzytfbA.Stopped))
				{
					QaqFZMhaoCOMRDHpCIrilTUrbMemb(UFviGzcFJWPLWtkesVKCqYMzytfbA.Stopped, new StoppedEventData(BTcTmpbioZfMAjqfdWzMuoQwNdvgb));
				}
			}

			public void WCsmbfuSuscWPIxAdZqNcXdaSidc(ConflictResponse P_0)
			{
				if (vjCvNUgICZgLJPQmuVcrFqcAjQvX != Status.AwaitingResponse || cyQIqKsLzsdbxeBisOegsNSeivsx != MchbriitlhvuuglGvtJPljzzWcUv.ConflictChecking)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (yeNagBWdtuVHchevnfFbHpvLUCZUA(P_0, wwetRxWBINzrhMEALVuYdAGUYHFm) == gCLlNYbtIaEfDVNrSWAIAwKCkeCo.Continue)
					{
						oTQQeeyCOMTIcHqeiwWWwTmqQVGb(wwetRxWBINzrhMEALVuYdAGUYHFm);
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
			private sealed class zEjqajjrARRQNrIBnbiQmrIkTlyd
			{
				public static readonly zEjqajjrARRQNrIBnbiQmrIkTlyd _003C_003E9 = new zEjqajjrARRQNrIBnbiQmrIkTlyd();

				public static Action<Exception> _003C_003E9__64_0;

				internal void fOIPoPRIHuPWppLRjwhsdZpnPthm(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
				}
			}

			private bool xGtvraCNBryoMZvoKBkEBJSRSEpQ = true;

			private bool ueuXlfRouWVfaGpmDHZfTMrbtuqn = true;

			private bool MWHmCbUBQbrplDUCrlTwxuYXHpmC = true;

			private float jGIAhtCxWNTLezFHEynofjhaUAWh;

			private bool FVXGjNGFbYrQaYQhqQwfSMhKfjPUA = true;

			private bool XlgQDfveQTgZeegTmJtjHsHdecpib = true;

			private bool ODljjNWeHvmPrOHUmtFNIIPggXZW = true;

			private bool ikaAMCyAhoxcoURckzrDhiuTQtZD = true;

			private int[] BklarWXsAykwUOsAZdTfyjDTiHKj;

			private ConflictResponse reFUsygXVWBZUAJQltLdyBXqyMBh = ConflictResponse.Replace;

			private bool dlkoaSBfMmQdgDKnNYsEzbgLsAbX;

			private bool rMahXMXIYyYyDBxYyBnwWmYsfYEb;

			private bool SaLNudVrFGoyfhmOCNONqCbBdpaiA = true;

			private bool RwSvOWJxgcVnRUUDoNydAuODBzbI = true;

			private float PPrEuLPmjAUMmpZrRzTTsWdPKiKE = 1f;

			internal const string CkWpfthbwCZixdjIQfGQeAWnfPBUA = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> GbpcCFeYBrOwoaPCUfvqAaOxDUHwA = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			public bool allowAxes
			{
				get
				{
					return xGtvraCNBryoMZvoKBkEBJSRSEpQ;
				}
				set
				{
					xGtvraCNBryoMZvoKBkEBJSRSEpQ = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return ueuXlfRouWVfaGpmDHZfTMrbtuqn;
				}
				set
				{
					ueuXlfRouWVfaGpmDHZfTMrbtuqn = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return MWHmCbUBQbrplDUCrlTwxuYXHpmC;
				}
				set
				{
					MWHmCbUBQbrplDUCrlTwxuYXHpmC = value;
				}
			}

			public float timeout
			{
				get
				{
					return jGIAhtCxWNTLezFHEynofjhaUAWh;
				}
				set
				{
					jGIAhtCxWNTLezFHEynofjhaUAWh = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return FVXGjNGFbYrQaYQhqQwfSMhKfjPUA;
				}
				set
				{
					FVXGjNGFbYrQaYQhqQwfSMhKfjPUA = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return XlgQDfveQTgZeegTmJtjHsHdecpib;
				}
				set
				{
					XlgQDfveQTgZeegTmJtjHsHdecpib = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return ODljjNWeHvmPrOHUmtFNIIPggXZW;
				}
				set
				{
					ODljjNWeHvmPrOHUmtFNIIPggXZW = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return ikaAMCyAhoxcoURckzrDhiuTQtZD;
				}
				set
				{
					ikaAMCyAhoxcoURckzrDhiuTQtZD = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return BklarWXsAykwUOsAZdTfyjDTiHKj;
				}
				set
				{
					BklarWXsAykwUOsAZdTfyjDTiHKj = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return reFUsygXVWBZUAJQltLdyBXqyMBh;
				}
				set
				{
					reFUsygXVWBZUAJQltLdyBXqyMBh = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return dlkoaSBfMmQdgDKnNYsEzbgLsAbX;
				}
				set
				{
					dlkoaSBfMmQdgDKnNYsEzbgLsAbX = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return rMahXMXIYyYyDBxYyBnwWmYsfYEb;
				}
				set
				{
					rMahXMXIYyYyDBxYyBnwWmYsfYEb = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return SaLNudVrFGoyfhmOCNONqCbBdpaiA;
				}
				set
				{
					SaLNudVrFGoyfhmOCNONqCbBdpaiA = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return RwSvOWJxgcVnRUUDoNydAuODBzbI;
				}
				set
				{
					RwSvOWJxgcVnRUUDoNydAuODBzbI = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return PPrEuLPmjAUMmpZrRzTTsWdPKiKE;
				}
				set
				{
					PPrEuLPmjAUMmpZrRzTTsWdPKiKE = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)GbpcCFeYBrOwoaPCUfvqAaOxDUHwA["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = zEjqajjrARRQNrIBnbiQmrIkTlyd._003C_003E9.fOIPoPRIHuPWppLRjwhsdZpnPthm;
					}
					GbpcCFeYBrOwoaPCUfvqAaOxDUHwA["isElementAllowed"] = safePredicate;
				}
			}

			internal _0001 xdkFhSAprUKSNCDdGaUGOrjaJBGld<_0001>(string P_0) where _0001 : SafeDelegate
			{
				if (!GbpcCFeYBrOwoaPCUfvqAaOxDUHwA.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as _0001;
			}

			public Options()
			{
				aJzxjCLwGRmyVfzOpuVfjpgCVnuM();
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
				stringBuilder.Append("allowAxes = " + xGtvraCNBryoMZvoKBkEBJSRSEpQ + "\n");
				stringBuilder.Append("allowButtons = " + ueuXlfRouWVfaGpmDHZfTMrbtuqn + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + MWHmCbUBQbrplDUCrlTwxuYXHpmC + "\n");
				stringBuilder.Append("timeout = " + jGIAhtCxWNTLezFHEynofjhaUAWh + "\n");
				stringBuilder.Append("checkForConflicts = " + FVXGjNGFbYrQaYQhqQwfSMhKfjPUA + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + XlgQDfveQTgZeegTmJtjHsHdecpib + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + ODljjNWeHvmPrOHUmtFNIIPggXZW + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + ikaAMCyAhoxcoURckzrDhiuTQtZD + "\n");
				if (BklarWXsAykwUOsAZdTfyjDTiHKj == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(BklarWXsAykwUOsAZdTfyjDTiHKj) + "\n");
				}
				stringBuilder.Append("defaultActionWhenConflictFound = " + reFUsygXVWBZUAJQltLdyBXqyMBh.ToString() + "\n");
				stringBuilder.Append("ignoreMouseXAxis = " + dlkoaSBfMmQdgDKnNYsEzbgLsAbX);
				stringBuilder.Append("ignoreMouseYAxis = " + rMahXMXIYyYyDBxYyBnwWmYsfYEb);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + SaLNudVrFGoyfhmOCNONqCbBdpaiA + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + RwSvOWJxgcVnRUUDoNydAuODBzbI + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + PPrEuLPmjAUMmpZrRzTTsWdPKiKE + "\n");
				return stringBuilder.ToString();
			}

			internal void aJzxjCLwGRmyVfzOpuVfjpgCVnuM()
			{
				xGtvraCNBryoMZvoKBkEBJSRSEpQ = true;
				ueuXlfRouWVfaGpmDHZfTMrbtuqn = true;
				MWHmCbUBQbrplDUCrlTwxuYXHpmC = true;
				jGIAhtCxWNTLezFHEynofjhaUAWh = 0f;
				FVXGjNGFbYrQaYQhqQwfSMhKfjPUA = true;
				XlgQDfveQTgZeegTmJtjHsHdecpib = true;
				ODljjNWeHvmPrOHUmtFNIIPggXZW = true;
				ikaAMCyAhoxcoURckzrDhiuTQtZD = true;
				BklarWXsAykwUOsAZdTfyjDTiHKj = null;
				reFUsygXVWBZUAJQltLdyBXqyMBh = ConflictResponse.Replace;
				dlkoaSBfMmQdgDKnNYsEzbgLsAbX = false;
				rMahXMXIYyYyDBxYyBnwWmYsfYEb = false;
				SaLNudVrFGoyfhmOCNONqCbBdpaiA = true;
				RwSvOWJxgcVnRUUDoNydAuODBzbI = true;
				PPrEuLPmjAUMmpZrRzTTsWdPKiKE = 1f;
				foreach (string item in new List<string>(GbpcCFeYBrOwoaPCUfvqAaOxDUHwA.Keys))
				{
					GbpcCFeYBrOwoaPCUfvqAaOxDUHwA[item] = null;
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
				destination.xGtvraCNBryoMZvoKBkEBJSRSEpQ = source.xGtvraCNBryoMZvoKBkEBJSRSEpQ;
				destination.ueuXlfRouWVfaGpmDHZfTMrbtuqn = source.ueuXlfRouWVfaGpmDHZfTMrbtuqn;
				destination.MWHmCbUBQbrplDUCrlTwxuYXHpmC = source.MWHmCbUBQbrplDUCrlTwxuYXHpmC;
				destination.jGIAhtCxWNTLezFHEynofjhaUAWh = source.jGIAhtCxWNTLezFHEynofjhaUAWh;
				destination.FVXGjNGFbYrQaYQhqQwfSMhKfjPUA = source.FVXGjNGFbYrQaYQhqQwfSMhKfjPUA;
				destination.XlgQDfveQTgZeegTmJtjHsHdecpib = source.XlgQDfveQTgZeegTmJtjHsHdecpib;
				destination.ODljjNWeHvmPrOHUmtFNIIPggXZW = source.ODljjNWeHvmPrOHUmtFNIIPggXZW;
				destination.ikaAMCyAhoxcoURckzrDhiuTQtZD = source.ikaAMCyAhoxcoURckzrDhiuTQtZD;
				destination.BklarWXsAykwUOsAZdTfyjDTiHKj = ArrayTools.ShallowCopy(source.BklarWXsAykwUOsAZdTfyjDTiHKj);
				destination.reFUsygXVWBZUAJQltLdyBXqyMBh = source.reFUsygXVWBZUAJQltLdyBXqyMBh;
				destination.dlkoaSBfMmQdgDKnNYsEzbgLsAbX = source.dlkoaSBfMmQdgDKnNYsEzbgLsAbX;
				destination.rMahXMXIYyYyDBxYyBnwWmYsfYEb = source.rMahXMXIYyYyDBxYyBnwWmYsfYEb;
				destination.SaLNudVrFGoyfhmOCNONqCbBdpaiA = source.SaLNudVrFGoyfhmOCNONqCbBdpaiA;
				destination.RwSvOWJxgcVnRUUDoNydAuODBzbI = source.RwSvOWJxgcVnRUUDoNydAuODBzbI;
				destination.PPrEuLPmjAUMmpZrRzTTsWdPKiKE = source.PPrEuLPmjAUMmpZrRzTTsWdPKiKE;
				foreach (KeyValuePair<string, SafeDelegate> item in source.GbpcCFeYBrOwoaPCUfvqAaOxDUHwA)
				{
					destination.GbpcCFeYBrOwoaPCUfvqAaOxDUHwA[item.Key] = MiscTools.Clone(item.Value);
				}
			}
		}

		[Serializable]
		private sealed class bZLHXrIunfhykAkHOhbvBfyaSLdv
		{
			public static readonly bZLHXrIunfhykAkHOhbvBfyaSLdv _003C_003E9 = new bZLHXrIunfhykAkHOhbvBfyaSLdv();

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void NdBJDfggSScoKhjxJGfDSiNVaIVc(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
			}

			internal void odLRDlmIVoTIlLiZLWBUsOfnQVPl(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
			}

			internal void CSWUeCMJNIvieQDhbUzLLUJqNqQU(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
			}

			internal void neQVGkkCWnymKYhWGiLfFYVVvdFC(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
			}

			internal void XpbOOcxQYakRNFnTBNaMTEjxhDEq(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
			}

			internal void AByhTEkcXCPnzdesEHundaAqYSIxA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
			}

			internal void nVmpgJUsvfAxdIyMUSVTGESkXSmv(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
			}
		}

		private static InputMapper egTnJPPdmnAIaakQeaToatnMLrVV;

		private static int YcJgIlYMsmptWgVZnjcayCYYskIS;

		private readonly int hCKFxHiaGNFbqHpbbKHgBZEywsqMb;

		private readonly bool tZoOYaoPGlDXtfptbnjCvqjHrhyx;

		private readonly zYhvzoDJuIbfNnExrDRygnpoAZKKA HimSWVxtSJZxabipZldeNyUAsiCD;

		private Options BARLpWWJaPJyPbNWiNYZwYSLLMXI;

		private readonly Dictionary<UFviGzcFJWPLWtkesVKCqYMzytfbA, SafeDelegate> aQxZiPXniiapjFyUalqNxRSVmXDR = new Dictionary<UFviGzcFJWPLWtkesVKCqYMzytfbA, SafeDelegate>
		{
			{
				UFviGzcFJWPLWtkesVKCqYMzytfbA.InputMapped,
				new SafeAction<InputMappedEventData>(bZLHXrIunfhykAkHOhbvBfyaSLdv._003C_003E9.NdBJDfggSScoKhjxJGfDSiNVaIVc)
			},
			{
				UFviGzcFJWPLWtkesVKCqYMzytfbA.Error,
				new SafeAction<ErrorEventData>(bZLHXrIunfhykAkHOhbvBfyaSLdv._003C_003E9.odLRDlmIVoTIlLiZLWBUsOfnQVPl)
			},
			{
				UFviGzcFJWPLWtkesVKCqYMzytfbA.Canceled,
				new SafeAction<CanceledEventData>(bZLHXrIunfhykAkHOhbvBfyaSLdv._003C_003E9.CSWUeCMJNIvieQDhbUzLLUJqNqQU)
			},
			{
				UFviGzcFJWPLWtkesVKCqYMzytfbA.TimedOut,
				new SafeAction<TimedOutEventData>(bZLHXrIunfhykAkHOhbvBfyaSLdv._003C_003E9.neQVGkkCWnymKYhWGiLfFYVVvdFC)
			},
			{
				UFviGzcFJWPLWtkesVKCqYMzytfbA.Started,
				new SafeAction<StartedEventData>(bZLHXrIunfhykAkHOhbvBfyaSLdv._003C_003E9.XpbOOcxQYakRNFnTBNaMTEjxhDEq)
			},
			{
				UFviGzcFJWPLWtkesVKCqYMzytfbA.Stopped,
				new SafeAction<StoppedEventData>(bZLHXrIunfhykAkHOhbvBfyaSLdv._003C_003E9.AByhTEkcXCPnzdesEHundaAqYSIxA)
			},
			{
				UFviGzcFJWPLWtkesVKCqYMzytfbA.ConflictsFound,
				new SafeAction<ConflictFoundEventData>(bZLHXrIunfhykAkHOhbvBfyaSLdv._003C_003E9.nVmpgJUsvfAxdIyMUSVTGESkXSmv)
			}
		};

		public static InputMapper Default => egTnJPPdmnAIaakQeaToatnMLrVV ?? (egTnJPPdmnAIaakQeaToatnMLrVV = new InputMapper(true));

		public Options options
		{
			get
			{
				Options obj = BARLpWWJaPJyPbNWiNYZwYSLLMXI;
				if (obj == null)
				{
					if (!tZoOYaoPGlDXtfptbnjCvqjHrhyx)
					{
						return BARLpWWJaPJyPbNWiNYZwYSLLMXI = Default.options.Clone();
					}
					obj = (BARLpWWJaPJyPbNWiNYZwYSLLMXI = new Options());
				}
				return obj;
			}
			set
			{
				BARLpWWJaPJyPbNWiNYZwYSLLMXI = value;
			}
		}

		public Context mappingContext => HimSWVxtSJZxabipZldeNyUAsiCD.qGHOOlYGiueJwXRtnxVCfUgDAcfM;

		public Status status => HimSWVxtSJZxabipZldeNyUAsiCD.UbRwgmicOHatqWsPIZOSKcoRDrrP;

		public float timeRemaining => HimSWVxtSJZxabipZldeNyUAsiCD.NwZXyAVvEGZPYitKMROgmCTTjkJP;

		internal int EHgSKiDZTGfgKhXUzPWUuiHaezSl => hCKFxHiaGNFbqHpbbKHgBZEywsqMb;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.InputMapped;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<InputMappedEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.InputMapped;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<InputMappedEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.Error;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<ErrorEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.Error;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<ErrorEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.Canceled;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<CanceledEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.Canceled;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<CanceledEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.TimedOut;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<TimedOutEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.TimedOut;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<TimedOutEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.Started;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<StartedEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.Started;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<StartedEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.Stopped;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<StoppedEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.Stopped;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<StoppedEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.ConflictsFound;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<ConflictFoundEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					UFviGzcFJWPLWtkesVKCqYMzytfbA key = UFviGzcFJWPLWtkesVKCqYMzytfbA.ConflictsFound;
					aQxZiPXniiapjFyUalqNxRSVmXDR[key] = (SafeAction<ConflictFoundEventData>)aQxZiPXniiapjFyUalqNxRSVmXDR[key] - value;
				}
			}
		}

		private static int rhHYWYiGbWLkQUsGfTxaEIoFIIui()
		{
			int ycJgIlYMsmptWgVZnjcayCYYskIS = YcJgIlYMsmptWgVZnjcayCYYskIS;
			if (YcJgIlYMsmptWgVZnjcayCYYskIS == int.MaxValue)
			{
				YcJgIlYMsmptWgVZnjcayCYYskIS = 0;
				return ycJgIlYMsmptWgVZnjcayCYYskIS;
			}
			YcJgIlYMsmptWgVZnjcayCYYskIS++;
			return ycJgIlYMsmptWgVZnjcayCYYskIS;
		}

		public InputMapper()
			: this(false)
		{
			hCKFxHiaGNFbqHpbbKHgBZEywsqMb = rhHYWYiGbWLkQUsGfTxaEIoFIIui();
		}

		private InputMapper(bool P_0)
		{
			tZoOYaoPGlDXtfptbnjCvqjHrhyx = P_0;
			if (tZoOYaoPGlDXtfptbnjCvqjHrhyx)
			{
				BARLpWWJaPJyPbNWiNYZwYSLLMXI = new Options();
			}
			HimSWVxtSJZxabipZldeNyUAsiCD = new zYhvzoDJuIbfNnExrDRygnpoAZKKA(this, aQxZiPXniiapjFyUalqNxRSVmXDR);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<UFviGzcFJWPLWtkesVKCqYMzytfbA, SafeDelegate> item in aQxZiPXniiapjFyUalqNxRSVmXDR)
			{
				item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<UFviGzcFJWPLWtkesVKCqYMzytfbA, SafeDelegate> item in aQxZiPXniiapjFyUalqNxRSVmXDR)
			{
				item.Value.Clear();
			}
		}

		internal void qptFTOAeOEtCGLCsuMcFFDiCSoSNb(object P_0)
		{
		}

		internal void xbYFlreUAWAPxsXKcCdFfpIBsPVw()
		{
		}

		public bool Start(Context mappingContext)
		{
			return JzqwXhnSlpeRHIptjLxKGtwphZFs(mappingContext, (BARLpWWJaPJyPbNWiNYZwYSLLMXI != null) ? BARLpWWJaPJyPbNWiNYZwYSLLMXI : Default.options);
		}

		public void Stop()
		{
			HimSWVxtSJZxabipZldeNyUAsiCD.LAruPDdqlvoNNJafFQEfmjUzeXk("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			xbYFlreUAWAPxsXKcCdFfpIBsPVw();
			BARLpWWJaPJyPbNWiNYZwYSLLMXI = null;
		}

		private bool JzqwXhnSlpeRHIptjLxKGtwphZFs(Context P_0, Options P_1)
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
				HimSWVxtSJZxabipZldeNyUAsiCD.qRQTmAUjxYrOeTBurCQVpjDRqKbs(P_0, P_1);
				return true;
			}
			catch
			{
				HimSWVxtSJZxabipZldeNyUAsiCD.LAruPDdqlvoNNJafFQEfmjUzeXk("Failed to start due to an exception.");
				return false;
			}
		}
	}
}
