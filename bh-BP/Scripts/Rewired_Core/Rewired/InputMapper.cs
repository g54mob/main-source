using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired
{
	public sealed class InputMapper
	{
		public class Context
		{
			private int gfTrVFvaDddrIDYgsjhdfATaCCTfb;

			private ControllerMap ZbaVXBFmmVGbpALRxDJZTqXdEzcDA;

			private ActionElementMap VezLKGrgsQRbQYJoDgaAcWdnFUjlA;

			private AxisRange VWsipLfwTLwiLPSwpIfLQCsHYeRh;

			private bool WGLHIIOAASbPJfKRGmzrGPHDGWfhc;

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

			internal void mSVfzOuIxkEaWHshGxpVhGdbCBgW()
			{
			}

			private bool WJDSaDpJjSZtcaPdnuWmugqVMZpB()
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

			private readonly Func<int, bool> IYUFWUlgFHbuFwpimjiDwhsAnFKX;

			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				return false;
			}

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
				: base(null)
			{
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

				public Player zrYHivOjqJAuOuIAKPTYyJpcfvcBA => null;

				public int MFpcArerEaAYxYNIpCXGAVFKiSuRA => 0;

				public Context PdAxqEhhOEdmoUOaQKPzVlbPckeI => null;

				public ControllerType iXcVggNGaFagZtXSJHLQpUTXOafR => default(ControllerType);

				public int cJASvkyonCrrFSrPguuuNNGQIoBDA => 0;

				public ControllerPollingInfo OvodMLfBDxgwTsQiCMOUhJbGaVCgb => default(ControllerPollingInfo);

				public ModifierKeyFlags PmlpLpPvZGBWhfOnWMWcEuyNUuOT => default(ModifierKeyFlags);

				public AxisRange NPJDvfsjusWjIIeuajDnXfdOHaRv => default(AxisRange);

				public string AcIvwqMcZSjnajOiiYbdlMHtbgCo => null;

				public void pWIIMLMMFvgBbjOfmiOGDgMASNzNB(Player P_0, Context P_1)
				{
				}

				public void oOhQDdXhLMdzEwOCLFNDywKXuBxF()
				{
				}

				public ElementAssignment pEuqqgpknFCOxcxgmGFofqcPSrfH(ControllerPollingInfo P_0)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment RPtEiSfKqcVvZbsBCCyFuEXZshtDA(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment iCpuKgTIxzWaayKIhoUlrLhEEPpe()
				{
					return default(ElementAssignment);
				}
			}

			private sealed class iPbEPLcxQDCqlnGfoFoJKrPKjCZg
			{
				public ActionElementMap ODkrzPWIzDsFJXldRfSahtIrWZZM;

				internal bool TjIuwksRcnUFtPdIXEBLzkvIQSPo(ElementAssignmentConflictInfo P_0)
				{
					return false;
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
					return false;
				}
			}

			private readonly InputMapper BxgNuwJJOVVQoNqRaMmzrhSPRkzT;

			private readonly Options ITprcphhjVwsoRtikbLsYnUUSEbr;

			private readonly NPCvIPqtDFckInDFcfLsjKkyxbPj xVKaZqnugFxvHtHFmmqKejLJAsxhA;

			private readonly Dictionary<SFjgWozprAIRiZZQlnBdHOGIaujCA, SafeDelegate> KNwIPwxLZwyBBFjaChrljGfjJtheA;

			private readonly Dictionary<string, SafeDelegate> KXzRqBzkEVbgKiRaNJYdIAIEHKvZA;

			private Status zMGrXPKvuRDVbsGIjhnQBOuvoJnhb;

			private KphdnMVRpmuQJRiqOTowrbIpEEH sDYDqVbMDelbRaDOjjxDirEERsKcE;

			private double TGPDpMfOFBlHmalosbUfdKdKaOrwB;

			private bool vtBENOBSLDhxLazmhUvTfFsQnAdh;

			private List<Player> jVbdMKVZcNHhXALbpIHEIUYIaIKQ;

			private readonly List<ControllerPollingInfo> dMgHwvCRtZQFXRdaIdarnHxXRpGD;

			private ElementAssignment yzefwsmBqBduRvFyGICjsJAlVkFK;

			public Status IYBqYpWomNccKbYrROLfFAkeGslQ => default(Status);

			public float DzJHnBduJETHwHAmNWLJjATkhjJr => 0f;

			public Context qeXZOkmiIkuXMmdTgmCpaIkinffo => null;

			private bool PUIwpQZuWtdxfIswuvxvIAFQWfec => false;

			public tTnMlrhwMWbbvWdVieULFcxPOCSz(InputMapper P_0, Dictionary<SFjgWozprAIRiZZQlnBdHOGIaujCA, SafeDelegate> P_1)
			{
			}

			~tTnMlrhwMWbbvWdVieULFcxPOCSz()
			{
			}

			public void cSYVPLkXIElQisGAsBiuiVIcLmrE(Context P_0, Options P_1)
			{
			}

			public void NCOclEboGlrWhsxYeKDpgSzniUTI(string P_0)
			{
			}

			private void joIyytPThubKKgUPNbvUmiknGdAKA(UpdateLoopType P_0)
			{
			}

			private void UzBiiYEzOSsUmLTXTudzAlOoLkVf()
			{
			}

			private void QrRPafhSJZCzwSomqsUfzhhMFmHm()
			{
			}

			private aIXdVRdTueaxnVeDLsRfcHIdnrSFB LHbRUlYLGrFFMgEeFHSeqzDyTEjt(out ElementAssignment P_0)
			{
				P_0 = default(ElementAssignment);
				return default(aIXdVRdTueaxnVeDLsRfcHIdnrSFB);
			}

			private bool EySCAoORFXmwDfQGspusiOZqjMuw(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_0 = null;
				P_1 = default(ModifierKeyFlags);
				return false;
			}

			private IEnumerable<ControllerPollingInfo> wzwpQcnmHTiKAOBtsvQlPmWBYsSR(out ModifierKeyFlags P_0)
			{
				P_0 = default(ModifierKeyFlags);
				return null;
			}

			private ControllerPollingInfo qXdLRiQgbpXfDpiZGHhkieJAdMTt(Options P_0, out ModifierKeyFlags P_1)
			{
				P_1 = default(ModifierKeyFlags);
				return default(ControllerPollingInfo);
			}

			private static ControllerPollingInfo auGfVxiENwdFCZbOiyOPQNHJrICP(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_1 = default(bool);
				P_2 = default(ModifierKeyFlags);
				P_3 = null;
				return default(ControllerPollingInfo);
			}

			private static bool ouhjjrMVJNWEDMTlLaaWYnJZQOuT(ControllerPollingInfo P_0, Options P_1)
			{
				return false;
			}

			private static bool ZZTBoqehcHAIcFIWGVNmDofLFjUJA(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ControllerPollingInfo P_1, Options P_2)
			{
				return false;
			}

			private void fehsHQRnkdVZHJrFBlZtuWCVaRrQ()
			{
			}

			private aIXdVRdTueaxnVeDLsRfcHIdnrSFB VCApsSGZOffXHLfoTxAEWOvGhmus(ElementAssignment P_0)
			{
				return default(aIXdVRdTueaxnVeDLsRfcHIdnrSFB);
			}

			private static bool uTHRrTeiAIiDjQbGfyxbBVfOvWTR(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static bool BmAjUMdPpbKkXNRzMtZFxftmCefX(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static IList<ElementAssignmentConflictInfo> tkVlZinznSWruyduWeGHkgkPfrJPA(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return null;
			}

			private static bool sjntfjeYcIADjvIziCCNIKWzjRMYA(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				P_2 = default(ElementAssignmentConflictCheck);
				return false;
			}

			private static void cVWQXbAJKlITusOZzRDaMYbQqGhm(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, List<Player> P_2)
			{
			}

			private void BGygnsBgYwwFASQDMbfVKIErGNTbA()
			{
			}

			private void HcomGVtwjLoTFlGIwDhaoQHkciJK()
			{
			}

			private bool deGjhFKSHGJFNMcfAGyAhzwGAqxFA(SFjgWozprAIRiZZQlnBdHOGIaujCA P_0)
			{
				return false;
			}

			private void YUmFHBQbGGhKfjqXVzqJnQGMZTcpA<_0001>(SFjgWozprAIRiZZQlnBdHOGIaujCA P_0, _0001 P_1)
			{
			}

			private void BJbAEAPRbwuheBdctKmemqBtTowV()
			{
			}

			private void TKrbilcOzefaedbAeBKVRNRVhSPv()
			{
			}

			private bool BjsaLDIZZPxECeamjWKpOlKLMIBbb(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
			{
				return false;
			}

			private bool bzgZzlBEqRSdGbXCIQFxqdWpeEJbA(NPCvIPqtDFckInDFcfLsjKkyxbPj P_0, ElementAssignment P_1, bool P_2, out string P_3)
			{
				P_3 = null;
				return false;
			}

			private static bool FxDaguHUcJnqASJoOhGLPmiWdtvAb(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
			{
				return false;
			}

			private void JnNorCUJComdfKaKFRzMEActsJbJ(ActionElementMap P_0)
			{
			}

			private void CNLeHQfYwGvAHWImfPJvwodKZoSV(string P_0)
			{
			}

			private aIXdVRdTueaxnVeDLsRfcHIdnrSFB ZhQGPkFYQTuoMFUYsiNKYyWoFAIHA(ElementAssignment P_0)
			{
				return default(aIXdVRdTueaxnVeDLsRfcHIdnrSFB);
			}

			private aIXdVRdTueaxnVeDLsRfcHIdnrSFB iYViAKyTZmVpUOBoaUdKyxewHnJe(ConflictResponse P_0, ElementAssignment P_1)
			{
				return default(aIXdVRdTueaxnVeDLsRfcHIdnrSFB);
			}

			private aIXdVRdTueaxnVeDLsRfcHIdnrSFB WOglYlsHwwguMowCeYxQbFDvoKSh(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				return default(aIXdVRdTueaxnVeDLsRfcHIdnrSFB);
			}

			private void jKMwZXnfZekuQKRvtPogqDpPxfSi()
			{
			}

			private void ciQgadaKbTBMZHxwzgTOblHMoYnU(string P_0)
			{
			}

			private void UkVFnpKHoAiFtiiOawXrwVzdALoZB()
			{
			}

			private void ZkyqgApZYAdTnbGlSofTwXmapFtl()
			{
			}

			private void qYRcGbUouCdFmKqYphfpYrPHFRBtA(ElementAssignment P_0)
			{
			}

			private void rbBlZCNWiODMKunrJSxzJzCSUTWJ(ActionElementMap P_0)
			{
			}

			private void iVkPrBcVknfdsgELXJoVdmUdFkpiA()
			{
			}

			private void tbDdxZWwMbzgACbrPGePCXcaGHaDA(string P_0)
			{
			}

			private void IdeTTiYNFukritylAxrDHsHeDKBKA(string P_0)
			{
			}

			private void nHUTcXnbmhMqcPkgjeweTfhmEVBj(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
			}

			private void QLVVPjWcPpBDuRDrjWscRCAXRPnf()
			{
			}

			private void mrsRINaLSANpncBkdeJdjjrIsTMl()
			{
			}

			public void CcwfkuSbcghseJtFgtMZLlJJsHuIA(ConflictResponse P_0)
			{
			}
		}

		public class Options
		{
			[Serializable]
			private sealed class nlxcgfFPXVuZiMWqiuqhjLzVnSoo
			{
				public static readonly nlxcgfFPXVuZiMWqiuqhjLzVnSoo _003C_003E9;

				public static Action<Exception> _003C_003E9__64_0;

				internal void vsSyoGhHdafGLJOduSePYcrMfAxXA(Exception P_0)
				{
				}
			}

			private bool levTrbkplrLswiuQJBfbISMohFlcA;

			private bool khcntejPUMLdGdpIWuQAEbpEireAA;

			private bool AbHAagiLjnAjDHeuiSuPgccsrCugb;

			private float fbEWGcgutXBGnYvZVlPrilFxXQwA;

			private bool JqBhxSrwPWtKOtyPvipKHPndxkNX;

			private bool FjkWFyTooDIDAKXrjjqCrzJUTdtWA;

			private bool WinBvAAujfXPJKnqbDGgsZJRTWPKA;

			private bool aQgBSBOYqwtpWbmxbEoakamgeVNab;

			private int[] FNhioDhIswcMybOcOczUfNTojzKC;

			private ConflictResponse bYXGxDUrnWRuMfevowIcxBIJlBZb;

			private bool dOkzePrEkutdAuzREnzlsZkmTDnk;

			private bool jsqBhYdJweEQAewZpnCOPBorkeCTA;

			private bool EzBzmurNbEdeLkIiDnFaIdbyzqghA;

			private bool DsGdeZdOHaVGhfbqdIAIZSQcYRze;

			private float FUbYmKlqEECXMGjdEsyixfIsBeEK;

			internal const string OOYXzoBbYUWwDAQiRSPdVpYQiQRu = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> MvvJEOwJjjbiKLigNSaNdKIIxZNk;

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

			internal _0001 fdoFbVRRFGOGjyoXtYLtwcvkwWdO<_0001>(string P_0) where _0001 : SafeDelegate
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

			internal void wLjmvHfwoNMgfUakqgSUGkshQgumA()
			{
			}

			public static void Copy(Options source, Options destination)
			{
			}
		}

		[Serializable]
		private sealed class bzFaLmsrLddgYCnxPBqQZGwJOCbfb
		{
			public static readonly bzFaLmsrLddgYCnxPBqQZGwJOCbfb _003C_003E9;

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void FHVPpcSeAMeaqWcNOsTmJOqqcpKCA(Exception P_0)
			{
			}

			internal void qgJtDsSJfkkWPqPzKkQvvzpWRtRk(Exception P_0)
			{
			}

			internal void MOMmeLqlrCgyEnNHyhqwIqTBNtKV(Exception P_0)
			{
			}

			internal void fICFJjAfidIearlDDifAaGOqImVwA(Exception P_0)
			{
			}

			internal void DLjSMdPomqsrvkpYMQUjWpKICGUC(Exception P_0)
			{
			}

			internal void UckHNPYObEWnHDLKKCjCFvItJZCx(Exception P_0)
			{
			}

			internal void jsityKaEVhKjXzzoXSAeBdSXURmT(Exception P_0)
			{
			}
		}

		private static InputMapper qBHljYnOKlOVSXgmdCIBxIhxuNDF;

		private static int ObViYkylIyBlcHPpmEpZanOixfWOb;

		private readonly int vDOFfMIDqVgxEfGHNgOJfIILVtacb;

		private readonly bool vXusKvMZijBJRGHTqYotamheHieW;

		private readonly tTnMlrhwMWbbvWdVieULFcxPOCSz RfwGOYLJvZNVKASrAyyFMenhzeYG;

		private Options RgDepPByCZUeljCktXPoOlMsmYJEb;

		private readonly Dictionary<SFjgWozprAIRiZZQlnBdHOGIaujCA, SafeDelegate> ysnhaOxLOomrBkBqtyzkcTWmkYBS;

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

		internal int YegRYhbNbQhyyOYswQBrdRFDNaSM => 0;

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

		private static int ddHCrDQjTMXZotiwmCBBXuUuNvwe()
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

		internal void okngPBWhwQLAqtNGrsnuWLmnctCcA(object P_0)
		{
		}

		internal void fbWpyVSgBEDViLaAhuIseYcmIUPe()
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

		private bool XuylJaPEHntPtbkTkXaxBHeSwWJT(Context P_0, Options P_1)
		{
			return false;
		}
	}
}
