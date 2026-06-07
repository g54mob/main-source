using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired
{
	public sealed class InputMapper
	{
		public class Context
		{
			private int cbNahQLtUKGddASpstRgBDxSpnvf;

			private ControllerMap HEqasElhUoEdQGFSxPVOUafNYQEI;

			private ActionElementMap LBzpoBNFlfDIpKCvXwoDZrBBBzRK;

			private AxisRange PjuSDYFJfiBLyNMRzeOCAJwbXrphA;

			private bool IzDvvLkgPdckmMGOUZriYwzmuxJP;

			public int actionId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public string actionName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return default(AxisRange);
				}
				set
				{
				}
			}

			public Context()
			{
			}

			private Context(Context P_0)
			{
			}

			public Context Clone()
			{
				return null;
			}

			internal void wnFsGZKOeJffjLGoEZxMchPJRgUW()
			{
			}

			private bool IkXEdbKHCQJuMHsKtluFcrIjDzxdb()
			{
				return false;
			}

			public static void Copy(Context source, Context destination)
			{
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
			}
		}

		public class InputMappedEventData : EventData
		{
			public readonly ActionElementMap actionElementMap;

			internal InputMappedEventData(InputMapper P_0, ActionElementMap P_1)
				: base(null)
			{
			}
		}

		public class CanceledEventData : EventData
		{
			public readonly string message;

			internal CanceledEventData(InputMapper P_0, string P_1)
				: base(null)
			{
			}
		}

		public class ErrorEventData : EventData
		{
			public readonly string message;

			internal ErrorEventData(InputMapper P_0, string P_1)
				: base(null)
			{
			}
		}

		public class TimedOutEventData : EventData
		{
			internal TimedOutEventData(InputMapper P_0)
				: base(null)
			{
			}
		}

		public class StartedEventData : EventData
		{
			internal StartedEventData(InputMapper P_0)
				: base(null)
			{
			}
		}

		public class StoppedEventData : EventData
		{
			internal StoppedEventData(InputMapper P_0)
				: base(null)
			{
			}
		}

		public class ConflictFoundEventData : EventData
		{
			public readonly Action<ConflictResponse> responseCallback;

			public readonly ElementAssignmentInfo assignment;

			public readonly IList<ElementAssignmentConflictInfo> conflicts;

			public readonly bool isProtected;

			private readonly Func<int, bool> AHMguJTPOcdJgwWpgswUzzGyuqyL;

			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				return false;
			}

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
				: base(null)
			{
			}
		}

		private enum MaxcdfXqenWcNTUDrWVsCtgeqNTQ
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

		private class nmbEUqPNJdEHCEpAyQQUnLHrngsH
		{
			private enum iXLiMlnhkLOAMqQSZVclEalHOaVB
			{
				Quit = 0,
				Continue = 1
			}

			private enum YCfhIiHmUEfNtqFvwxYbQtVwqOidb
			{
				None = 0,
				ConflictChecking = 1
			}

			private class XqKpEQSpGiANftVOqgvfmwUQrCbt
			{
				private Player TTsQiIlRSKlQSURKOnaakDHALtLk;

				private int wZidphDXBCSHtCvFrbHzDrcUayWF;

				private Context ZbQoKBaCAKYgrZBIaRbiOStVesXB;

				private ControllerType pIAScUpPMrErCuPNfcoaUujYEYxi;

				private int xGkjGNdKDeRluGvDcJRQgsinGrzf;

				private ControllerPollingInfo VgKEYSbPuiipnHYSPWxWYXAXoqCkA;

				private ModifierKeyFlags UKIPQVyhWaQGpMmfYufCtQxTIlOl;

				public Player hOUVTgkBxuXSradPYfJDvjFOxMAP => null;

				public int WarnekQJuXzeKKDufXDBMptspaEe => 0;

				public Context VCWWQFHSRnrOFWRvQeCsAADlPLOUA => null;

				public ControllerType aIwLwvpRfkLPcpvZFRnPsdjrhRHP => default(ControllerType);

				public int cWGAQpEHszQpqApCegQtUccoRBhI => 0;

				public ControllerPollingInfo UKkfAQzExMXiOStmYYPfKRjwwyfB => default(ControllerPollingInfo);

				public ModifierKeyFlags VTdoimlPCdxuSnmkUWplBYCtTtcg => default(ModifierKeyFlags);

				public AxisRange XqRtmwKMrLztdYIxmJbsEsDmrVpt => default(AxisRange);

				public string EeCPrrgkInOPTvbnqxLqscvDeRmo => null;

				public void rjYvKMwHCEhoIEBagIMPejuivcRgA(Player P_0, Context P_1)
				{
				}

				public void qrtBrqcjubeWpGkPgBRQFxMtrPXdB()
				{
				}

				public ElementAssignment rbqvLdTQkoUlUidlksIrwhUfEnDEA(ControllerPollingInfo P_0)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment TdcNBUgzFgUoJiACZqChNvlUGZBA(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment aDjdNpgdNOQbXkqHlHimLobmzxTHA()
				{
					return default(ElementAssignment);
				}
			}

			private sealed class aQtzdOIdksDbQFdNofJIaNNEcKhuB
			{
				public ActionElementMap QcuQHQsomgyviTRmXOyxqlcLkFxH;

				internal bool RWEMPnMRpIurOVvHBpDWkrHeOnbo(ElementAssignmentConflictInfo P_0)
				{
					return false;
				}
			}

			private sealed class scEeoqhYjbhvuqYnFYYbLNqkCDsLA
			{
				public nmbEUqPNJdEHCEpAyQQUnLHrngsH euvNvHOLHyBcwLxJRTeWpbcMssfY;

				public ElementAssignmentInfo yvvEqHkmrHMjTwabxtLVfGnAxbSH;

				public IList<ElementAssignmentConflictInfo> RiOuMxqQcEGQicWgHQXjyRAICyGG;

				public bool GLWItPGoNiOFdbVmZGvEuMEQzLoy;

				internal bool QKnCYpqqckXsGrjdlrSEbhlSSpsi(int P_0)
				{
					return false;
				}
			}

			private readonly InputMapper FjaHpddMJyxNZFAEyJwkuRedPLJs;

			private readonly Options AMtTTqHCoeZJVZBjceZxNLuiIfJS;

			private readonly XqKpEQSpGiANftVOqgvfmwUQrCbt jkCGsdNMnqvAgtoAikkXrPjvCTLKA;

			private readonly Dictionary<MaxcdfXqenWcNTUDrWVsCtgeqNTQ, SafeDelegate> UsqunbBHQRCiyHzrOpjgXmRZEYJeA;

			private readonly Dictionary<string, SafeDelegate> UivFXWVZmaLefDCzLEZaFwispkTK;

			private Status ltAkwOucnoarIgqDndWVLfANmXZF;

			private YCfhIiHmUEfNtqFvwxYbQtVwqOidb mcMVORwMfBWoSPFgdljMiiDvPuCe;

			private double NzZOJtgGurwPZblozKcuJPQtzPkA;

			private bool lMTzpPleVmqScqIaxMSKuxhqBQRq;

			private List<Player> bKtehTxKjkhEuGRejlFTHLioJjyS;

			private readonly List<ControllerPollingInfo> dTsywqiyEexlwFniOIpwigpzSukw;

			private ElementAssignment gGiRQrWWzcUtqvzxAMcwlzaZokvf;

			public Status AHTMNocGzgqDbzowTmIoYoWObZBQ => default(Status);

			public float HhZycCValbawDaTbZVWKJabIWGrEA => 0f;

			public Context oBJpRzSXxDgjRcIZgQeAdIsQMTwB => null;

			private bool RlYAToBbhIEAWvSjekbmxFwcGzDgb => false;

			public nmbEUqPNJdEHCEpAyQQUnLHrngsH(InputMapper P_0, Dictionary<MaxcdfXqenWcNTUDrWVsCtgeqNTQ, SafeDelegate> P_1)
			{
			}

			~nmbEUqPNJdEHCEpAyQQUnLHrngsH()
			{
			}

			public void cNODgMfCEzGMlZiVupTxSdnGNeHTA(Context P_0, Options P_1)
			{
			}

			public void XdIiQTFVBUaGYwLXwdSorRTXUPbO(string P_0)
			{
			}

			private void xRQJvmdiWJjJrkKcPfnXhKPNAxee(UpdateLoopType P_0)
			{
			}

			private void KGNkZXsuXlrLLFZCJiecLumKIczR()
			{
			}

			private void OOJsqyNPCctnJWCtmCkkEsJqVirmA()
			{
			}

			private iXLiMlnhkLOAMqQSZVclEalHOaVB VynMwwizTCKghwjpLbApJdvKybHpA(out ElementAssignment P_0)
			{
				P_0 = default(ElementAssignment);
				return default(iXLiMlnhkLOAMqQSZVclEalHOaVB);
			}

			private bool AiUDvjeQAwBVgvyLeqtfnsdMrlQK(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_0 = null;
				P_1 = default(ModifierKeyFlags);
				return false;
			}

			private IEnumerable<ControllerPollingInfo> mGwhjfTlGozwpKnwmMuaOQmrPnwk(out ModifierKeyFlags P_0)
			{
				P_0 = default(ModifierKeyFlags);
				return null;
			}

			private ControllerPollingInfo silSgfeTsUHgydKSEgBhjZxkFjnv(Options P_0, out ModifierKeyFlags P_1)
			{
				P_1 = default(ModifierKeyFlags);
				return default(ControllerPollingInfo);
			}

			private static ControllerPollingInfo emSiGaMbEZNwhXwDgVUSPKjxOjiR(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_1 = default(bool);
				P_2 = default(ModifierKeyFlags);
				P_3 = null;
				return default(ControllerPollingInfo);
			}

			private static bool uLnYqewYOkrfcIawBHcLNLlpopMs(ControllerPollingInfo P_0, Options P_1)
			{
				return false;
			}

			private static bool LgBFVhQYfstRJPDRWGPnSKRdACkKA(XqKpEQSpGiANftVOqgvfmwUQrCbt P_0, ControllerPollingInfo P_1, Options P_2)
			{
				return false;
			}

			private void bcrilRlvnGeoqBBAXIFybqajwaTS()
			{
			}

			private iXLiMlnhkLOAMqQSZVclEalHOaVB PdKNUPmMTMmmoFohJAhHNALaNxUJ(ElementAssignment P_0)
			{
				return default(iXLiMlnhkLOAMqQSZVclEalHOaVB);
			}

			private static bool omHQWQYBNfqwWCnZhxYmMvZellbF(XqKpEQSpGiANftVOqgvfmwUQrCbt P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static bool FuMnMRPfiMIJqFjcEyNMemHOhLVy(XqKpEQSpGiANftVOqgvfmwUQrCbt P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static IList<ElementAssignmentConflictInfo> rVToAxHzkrUFBaBzGdSQzjEjZOjq(XqKpEQSpGiANftVOqgvfmwUQrCbt P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return null;
			}

			private static bool qWnUtyCxGhczUjaQaOMUXkaRoxgE(XqKpEQSpGiANftVOqgvfmwUQrCbt P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				P_2 = default(ElementAssignmentConflictCheck);
				return false;
			}

			private static void cKWRryylBMuvHkdGpzZfLDVqVXLN(XqKpEQSpGiANftVOqgvfmwUQrCbt P_0, ElementAssignment P_1, List<Player> P_2)
			{
			}

			private void JZoaGxnVDVLyvAFMMqrIRAqJBsbcA()
			{
			}

			private void DeqmPERyywILupuHwgTpjNtElJfu()
			{
			}

			private bool hcKAMWeEOzwwqAXcOsuBmCUsCBPhA(MaxcdfXqenWcNTUDrWVsCtgeqNTQ P_0)
			{
				return false;
			}

			private void KlmcmIeQJdjnKFaQPJqQXZuoiiUpA<_0001>(MaxcdfXqenWcNTUDrWVsCtgeqNTQ P_0, _0001 P_1)
			{
			}

			private void JWnqtHvWqPTRHPkfzawxvFdJrPIS()
			{
			}

			private void NvrOIqMSsJtUFtUNeIAUGQhvapny()
			{
			}

			private bool FxagkMjGzqtbvyxpbYvgaqebrorE(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
			{
				return false;
			}

			private bool fhsONsxhpqGWrfLwWHpcjseNtVfD(XqKpEQSpGiANftVOqgvfmwUQrCbt P_0, ElementAssignment P_1, bool P_2, out string P_3)
			{
				P_3 = null;
				return false;
			}

			private static bool BjLRizobOmZTlLtYUGQQbIToWeZc(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
			{
				return false;
			}

			private void XSVxBFgSCFAHQaIXZXBLsTOFoJVrA(ActionElementMap P_0)
			{
			}

			private void CSJsBywrvSxewGlvCPsvfNibLsrA(string P_0)
			{
			}

			private iXLiMlnhkLOAMqQSZVclEalHOaVB HORqvgqRbgXbCEDIwDeLjuyKzcye(ElementAssignment P_0)
			{
				return default(iXLiMlnhkLOAMqQSZVclEalHOaVB);
			}

			private iXLiMlnhkLOAMqQSZVclEalHOaVB aHTbTRFQIDJgjTCAkiINwnTCZupuA(ConflictResponse P_0, ElementAssignment P_1)
			{
				return default(iXLiMlnhkLOAMqQSZVclEalHOaVB);
			}

			private iXLiMlnhkLOAMqQSZVclEalHOaVB IrmRYwEFvRuNbmyLavKTsVzBSLwU(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				return default(iXLiMlnhkLOAMqQSZVclEalHOaVB);
			}

			private void bVMsLCXpENCJdeAqzOJlIdTctIuoc()
			{
			}

			private void gyWaHuGWmeazcPUllZRHmFxgEjRw(string P_0)
			{
			}

			private void KFcCmgzvGjgGbaTLsHaAWRlosUNB()
			{
			}

			private void HVokTBNIPtlEAzimSlgUnPUYpGTV()
			{
			}

			private void shRDbiqZlnTmZqkTzPbwcmxjeQtk(ElementAssignment P_0)
			{
			}

			private void pEFemBlAxdFhlohuDvhsGnamVvuP(ActionElementMap P_0)
			{
			}

			private void aKioqWKkzWcGDJiGFlkUjgoVgNNrA()
			{
			}

			private void rEPGhAiNJWHBrUayXmEEThUCuGGI(string P_0)
			{
			}

			private void WCasWxcCtTSwTxaXUdUUInRMfife(string P_0)
			{
			}

			private void xySvoMLwxOvIDPDnlDazGQHKDfrQ(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
			}

			private void SuNxgeqfnMQkLTGezjIzEKkvpgBFb()
			{
			}

			private void sOaPaACOXtayImTpfewqaYTqPfgm()
			{
			}

			public void GeueRvcQnDjVFFnOuIWKMgxbvwOGA(ConflictResponse P_0)
			{
			}
		}

		public class Options
		{
			[Serializable]
			private sealed class tUlDBmnbQyskFOBvixsccNXnqnAo
			{
				public static readonly tUlDBmnbQyskFOBvixsccNXnqnAo _003C_003E9;

				public static Action<Exception> _003C_003E9__64_0;

				internal void lNGZwZRyZFlJoAuTycgEbXOenNZC(Exception P_0)
				{
				}
			}

			private bool zBrQXcKKcKRbFySTPdHkNmsUgKBf;

			private bool yYqYwtVqTrIOvlAFWIRPJPVwQJGG;

			private bool EfLjVrEkeYOYkmsfomyGhdMKynGt;

			private float bfGCnvYUhizkjKHwREbOKhRfcycnA;

			private bool XPZAQBBKYhutnfrCzavZAGNRMFny;

			private bool BxikbdrghwcIzDbmnjoTwOrknANX;

			private bool MXhIcZCglEmrgxfwpGabGjDrrqrD;

			private bool iPgfnScixHuUzlgutpkpjLUIWqxp;

			private int[] FSnuBYPxnFRHLpCjSHkPdajGnQmVA;

			private ConflictResponse jHDEjkDyctHgTvvhgigJGqrjeKvnA;

			private bool dRiVnOHhOJIutaKLAnIqzGjQyWPd;

			private bool xNcFALDchHfptJqUdlMRNWCRvLyFA;

			private bool AhNFMnVgpzXdgGdsJHcxwGZAXMYh;

			private bool HoSBCUeZBZXwGMtohlQXTKcKXhXwA;

			private float FLtplNLPPhPbxCHiGiixcUoGByygA;

			internal const string QrUKTvjTLdJZmUhnDLuTWoxcblrc = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> SKndfTYZmGZdpBqhXoGCswcomDli;

			public bool allowAxes
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool allowButtons
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public float timeout
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return default(ConflictResponse);
				}
				set
				{
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal _0001 bdiEUEbtMpBnQglKjwFkvvXGubNN<_0001>(string P_0) where _0001 : SafeDelegate
			{
				return null;
			}

			public Options()
			{
			}

			private Options(Options P_0)
			{
			}

			public Options Clone()
			{
				return null;
			}

			public override string ToString()
			{
				return null;
			}

			internal void iuzQtATrzwXNUQjViKeNjFEJXmGh()
			{
			}

			public static void Copy(Options source, Options destination)
			{
			}
		}

		[Serializable]
		private sealed class fhJuGpWKZSZDxxwBNytDZOmhbYPd
		{
			public static readonly fhJuGpWKZSZDxxwBNytDZOmhbYPd _003C_003E9;

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void FYFJyjcLZrcTPIvCYCJpQfCMaYgdA(Exception P_0)
			{
			}

			internal void oZLgRtobuTjLyoZsCCaueCPiJudn(Exception P_0)
			{
			}

			internal void WrUNSYMOchXOjhIGefslXihjSOqX(Exception P_0)
			{
			}

			internal void fXQkwyaDnGWNFpgMHyfZVJiAJRnV(Exception P_0)
			{
			}

			internal void DUzypgbjfLtTIwkyMWKiLrLeCfen(Exception P_0)
			{
			}

			internal void KDaBsEgGknFMwfJPOGtLcauFDosJb(Exception P_0)
			{
			}

			internal void xNkRrRMfMKELgvlQBYDfYgSveZGD(Exception P_0)
			{
			}
		}

		private static InputMapper seRdCBATVWTdzNUbljKIDaFXqLtvA;

		private static int UTzEtSzJHYXXTaqcxyMugqHGMkd;

		private readonly int pcIEKBantkFQziMIPWWEUHepDOMOA;

		private readonly bool pimfOsianGwGeAVSiomgbFTWcZYu;

		private readonly nmbEUqPNJdEHCEpAyQQUnLHrngsH PAovnLvyQuHydSBJWDyQFiADpSqv;

		private Options PZRAAwWBiRHWeGfHrVbWighAzlQB;

		private readonly Dictionary<MaxcdfXqenWcNTUDrWVsCtgeqNTQ, SafeDelegate> gNvDrTDzZZGlqqAvvnIvdhyUhffw;

		public static InputMapper Default => null;

		public Options options
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Context mappingContext => null;

		public Status status => default(Status);

		public float timeRemaining => 0f;

		internal int GBepjaDMmrLwNYMpyXWcybxvLXgd => 0;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private static int hdFvlCqBAdpwZtynqQEOMoUGaySX()
		{
			return 0;
		}

		public InputMapper()
		{
		}

		private InputMapper(bool P_0)
		{
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
		}

		public void RemoveAllEventListeners()
		{
		}

		internal void uVvmVCsFpdadTnHFfepfVJYDXOap(object P_0)
		{
		}

		internal void bfAhCteohdwiibLnvCsnmbeYllzgb()
		{
		}

		public bool Start(Context mappingContext)
		{
			return false;
		}

		public void Stop()
		{
		}

		public void Clear()
		{
		}

		private bool NLoyzjlwEQqAYpfQcIceKRUomhxU(Context P_0, Options P_1)
		{
			return false;
		}
	}
}
