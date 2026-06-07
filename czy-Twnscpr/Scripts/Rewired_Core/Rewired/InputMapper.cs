using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Utils;

namespace Rewired
{
	public sealed class InputMapper
	{
		public class Context
		{
			private int TQYOZDQbURTgwLWUxEJkbkWTlFD;

			private ControllerMap eqICMNAeQqPWKbMtCpCcRRFJaxS;

			private ActionElementMap FeYiPXLTkPIhbGgQLvbXOErDbfb;

			private AxisRange tEzBPpCXruzFPvzcIHGMjHbTtQu;

			private bool XdGBivBxlbeHDIntPpcCMFstJAw;

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

			private Context(Context source)
			{
			}

			public Context Clone()
			{
				return null;
			}

			internal void OGcdTxAXNJpoHBnwupfSpWIILzt()
			{
			}

			private bool DhZBlglmsRvefaAMprzXOAEVrlo()
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
			Ignore = 3
		}

		public abstract class EventData
		{
			public readonly InputMapper inputMapper;

			internal EventData(InputMapper inputMapper)
			{
			}
		}

		public class InputMappedEventData : EventData
		{
			public readonly ActionElementMap actionElementMap;

			internal InputMappedEventData(InputMapper mapper, ActionElementMap actionElementMap)
				: base(null)
			{
			}
		}

		public class CanceledEventData : EventData
		{
			public readonly string message;

			internal CanceledEventData(InputMapper mapper, string message)
				: base(null)
			{
			}
		}

		public class ErrorEventData : EventData
		{
			public readonly string message;

			internal ErrorEventData(InputMapper mapper, string message)
				: base(null)
			{
			}
		}

		public class TimedOutEventData : EventData
		{
			internal TimedOutEventData(InputMapper mapper)
				: base(null)
			{
			}
		}

		public class StartedEventData : EventData
		{
			internal StartedEventData(InputMapper mapper)
				: base(null)
			{
			}
		}

		public class StoppedEventData : EventData
		{
			internal StoppedEventData(InputMapper mapper)
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

			internal ConflictFoundEventData(InputMapper mapper, Action<ConflictResponse> responseCallback, ElementAssignmentInfo assignment, IList<ElementAssignmentConflictInfo> conflicts, bool isProtected)
				: base(null)
			{
			}
		}

		private enum pjaivfgcCurUqQrpyUZWqUryQNf
		{
			rlzJTlLpwhuZQaMLuxgVUaFUpe = 0,
			gNeMVegQmzpOFSCGsDgGhMewOVaX = 1,
			DmvFPowxtxhualRqDKhiaeSpvOE = 2,
			iEgThZVVlAjZGcofKBJAodTdAHDd = 3,
			nQKULgNqNkLYRURbmwtKMTQWYHX = 4,
			jJDiWcspqwPUhXSwisIDYZtaCFd = 5,
			qhSftYBUsInhLyjLMrMXsSbdOuu = 6
		}

		public enum Status
		{
			Idle = 0,
			Listening = 1,
			AwaitingResponse = 2
		}

		private class KegmMkwLzmhqnBmyfaWcENSzMlSD
		{
			private enum KRhmsuorMaqhWcxdsdHeQWxuMuK
			{
				MVXSrDxCytsyrlcqhAWUaFPEgpAG = 0,
				MZmDLAhaJDsZFcUlVzmHPGtJeFDC = 1
			}

			private enum fOUcfsmoEoEmrhWCCLpHYThuUbG
			{
				kWwOvXSVQftLstpRDMaKvWdpfrv = 0,
				ORqCtdgDDuCBeHtxBOSmnPSdGdus = 1
			}

			private class rDEJmtotXZiyRcTqjbuqCJNriLc
			{
				private Player FcOGyfuEtfnVeFmuqZdutvFYIsk;

				private int TQYOZDQbURTgwLWUxEJkbkWTlFD;

				private Context MlXQufJCfsINPsQlkMMozUtTHTL;

				private ControllerType ODiTVfklXHDoeIfdJEahPbsrzhzs;

				private int OAqYXyYxxoyErUWWGBOiLsNcUok;

				private ControllerPollingInfo UrFKxasyAXUqpSpEQAFkwAnGBTd;

				private ModifierKeyFlags fapEFihATXBtwNbWkLXiFIcqsin;

				public Player player => null;

				public int actionId => 0;

				public Context mappingContext => null;

				public ControllerType controllerType => default(ControllerType);

				public int controllerId => 0;

				public ControllerPollingInfo pollingInfo => default(ControllerPollingInfo);

				public ModifierKeyFlags modifierKeyFlags => default(ModifierKeyFlags);

				public AxisRange axisRange => default(AxisRange);

				public string elementName => null;

				public void nKQbCtkHPOPnqlOqEQhEesshditg(Player P_0, Context P_1)
				{
				}

				public void CKSoitBPjLqWpFGpwBNgDbvTrVm()
				{
				}

				public ElementAssignment iuuRntrgsBmYDjkXNlkCqDhlYsk(ControllerPollingInfo P_0)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment iuuRntrgsBmYDjkXNlkCqDhlYsk(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment iuuRntrgsBmYDjkXNlkCqDhlYsk()
				{
					return default(ElementAssignment);
				}
			}

			private readonly InputMapper cFEBywhZYxtgpybAYsIGoOnAlzo;

			private readonly Options vSgsHraqqIxSoQtrhjduflsIUTT;

			private readonly rDEJmtotXZiyRcTqjbuqCJNriLc RihJlGsEiPQsXpyYoaqRcteXmHs;

			private readonly Dictionary<pjaivfgcCurUqQrpyUZWqUryQNf, SafeDelegate> STifjPqOgjmJNCvSbaRpronVLXa;

			private readonly Dictionary<string, SafeDelegate> QKFAHuFoFPwVEGUOWLuMFdRlvFjR;

			private Status HigOHSEmplvIBwioVkiSDmNHdxq;

			private fOUcfsmoEoEmrhWCCLpHYThuUbG kaKAMbhvqhJEoQggShQzvxQFfHpt;

			private double OFmMswZoGdGTRCCWTaReQdQdCtDw;

			private bool mnEVnpvCEHpLijPRbTyVBurqjHo;

			private List<Player> yELGKovDnTlpbQKpsqpGBJvlsee;

			private readonly List<ControllerPollingInfo> BdUebybWscBAROPklfTCpqXaGqPd;

			private ElementAssignment eCLrLRuqrobtauxUqIDGFEykCjHJ;

			public Status status => default(Status);

			public float timeRemaining => 0f;

			public Context context => null;

			private bool checkTimer => false;

			public KegmMkwLzmhqnBmyfaWcENSzMlSD(InputMapper parent, Dictionary<pjaivfgcCurUqQrpyUZWqUryQNf, SafeDelegate> events)
			{
			}

			~KegmMkwLzmhqnBmyfaWcENSzMlSD()
			{
			}

			public void eaCduIGlWnoCUPmzuAvihlsUVqj(Context P_0, Options P_1)
			{
			}

			public void afeNSaqmGhoBFjvtbHpaZEGnpzX(string P_0)
			{
			}

			private void jSmUMfkZCZCZfiMnleEGJnwKIqT(UpdateLoopType P_0)
			{
			}

			private void pIfbiPHTiSFILUItabCnOyQvlMd()
			{
			}

			private void pgnlyEdlmTJJdFuqtwqgZcYCNzz()
			{
			}

			private KRhmsuorMaqhWcxdsdHeQWxuMuK GKJawIbrAaTmGQmiripKMmiLKPhB(out ElementAssignment P_0)
			{
				P_0 = default(ElementAssignment);
				return default(KRhmsuorMaqhWcxdsdHeQWxuMuK);
			}

			private bool IXXNPhjBjmeFrQtEKEVRxcTAoEd(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_0 = null;
				P_1 = default(ModifierKeyFlags);
				return false;
			}

			private IEnumerable<ControllerPollingInfo> DCohshKrrIBTblNPdFpUgGKaqDCh(out ModifierKeyFlags P_0)
			{
				P_0 = default(ModifierKeyFlags);
				return null;
			}

			private ControllerPollingInfo xtIyDbKwBDCXAtsYzlUkfPhpybw(Options P_0, out ModifierKeyFlags P_1)
			{
				P_1 = default(ModifierKeyFlags);
				return default(ControllerPollingInfo);
			}

			private static ControllerPollingInfo xtIyDbKwBDCXAtsYzlUkfPhpybw(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_1 = default(bool);
				P_2 = default(ModifierKeyFlags);
				P_3 = null;
				return default(ControllerPollingInfo);
			}

			private static bool kfHqwNovbBxbtXLXIhZmCHGzgVg(ControllerPollingInfo P_0, Options P_1)
			{
				return false;
			}

			private static bool lmMxnPvfOdaKkYzQmRpcuBzqNIR(rDEJmtotXZiyRcTqjbuqCJNriLc P_0, ControllerPollingInfo P_1, Options P_2)
			{
				return false;
			}

			private void LvZSmQlAwqAWlpCZbEmwSBEeGFL()
			{
			}

			private KRhmsuorMaqhWcxdsdHeQWxuMuK NifbKNhsczNsgiuRKFyMbKhcGjS(ElementAssignment P_0)
			{
				return default(KRhmsuorMaqhWcxdsdHeQWxuMuK);
			}

			private static bool jmpllqscZZUFsHdkJrPgJdVVkDi(rDEJmtotXZiyRcTqjbuqCJNriLc P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static bool PgdNNMKwFsngTZcGaIuJvLGlGbO(rDEJmtotXZiyRcTqjbuqCJNriLc P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static IList<ElementAssignmentConflictInfo> gWpQDfkrvHdXoEteluSvYMBTajs(rDEJmtotXZiyRcTqjbuqCJNriLc P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return null;
			}

			private static bool JeyhNsrBJKYaMikNZyVsdlgFTXH(rDEJmtotXZiyRcTqjbuqCJNriLc P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				P_2 = default(ElementAssignmentConflictCheck);
				return false;
			}

			private static void dBnGyNTljesdoxOgKmCkeyepzWl(rDEJmtotXZiyRcTqjbuqCJNriLc P_0, ElementAssignment P_1, List<Player> P_2)
			{
			}

			private void dAznTNycveYmtEfBXaWDGixwvvu()
			{
			}

			private void RLhVIPqWBSfywtBVzzxiiixjnJj()
			{
			}

			private bool scvfkEKrUQcpygiPkMQzdpHcWdqx(pjaivfgcCurUqQrpyUZWqUryQNf P_0)
			{
				return false;
			}

			private void FthFbxydbYmsRvJFAIVJHgpKczjP<T>(pjaivfgcCurUqQrpyUZWqUryQNf P_0, T P_1)
			{
			}

			private void kJTBJzMqCscAjsftSfJHiHgIrMu()
			{
			}

			private void oDKkHjOdGHYpnirYwTZpvpXSYFN()
			{
			}

			private void pDxZUHiGAALJUaXgGNxxIPJOmxE(ActionElementMap P_0)
			{
			}

			private void ckljyzfdXJhVgwRoIrzehiRHMSg(string P_0)
			{
			}

			private KRhmsuorMaqhWcxdsdHeQWxuMuK DBfqNFeySlgciZbqWJWgpQhGbcT(ElementAssignment P_0)
			{
				return default(KRhmsuorMaqhWcxdsdHeQWxuMuK);
			}

			private KRhmsuorMaqhWcxdsdHeQWxuMuK pbfIvrvhhflwxBAmiEwYdQySyRg(ConflictResponse P_0, ElementAssignment P_1)
			{
				return default(KRhmsuorMaqhWcxdsdHeQWxuMuK);
			}

			private KRhmsuorMaqhWcxdsdHeQWxuMuK pbfIvrvhhflwxBAmiEwYdQySyRg(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				return default(KRhmsuorMaqhWcxdsdHeQWxuMuK);
			}

			private void XOVFJwwmMLUBhAhLyUjeJNUHxaA()
			{
			}

			private void FPqEyPYdUYqBXRexjBGPzWKlyA(string P_0)
			{
			}

			private void jVSCHqBfLGzqTUxoJpSpzVfqyKy()
			{
			}

			private void gMadacUgHKgTDDqIZkrBaYHPDkow()
			{
			}

			private void iOgzGvoDxMQjpHgbIEtIgFsPHYos(ElementAssignment P_0)
			{
			}

			private void HjRWvRxotZAGPWJXQlgjZIstpVv(ActionElementMap P_0)
			{
			}

			private void LhcVjsFeywdOsJnLZznxWYAoWsq()
			{
			}

			private void yEkbqifsHyyJBrhQMesvunFfULK(string P_0)
			{
			}

			private void WqONHtAUcIhQJfhHNEQnyGtbnjU(string P_0)
			{
			}

			private void WLTFMXdemxEqDxFgArAJivMmJLX(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
			}

			private void wPsYHfYWXOJxRDPCKzDCzPFYiFQ()
			{
			}

			private void pAiwyTpAcglLNdEhyXERYabsVGR()
			{
			}

			public void UZICPoxUmfXsgGRePUwnPAmlwcW(ConflictResponse P_0)
			{
			}
		}

		public class Options
		{
			internal const string zfEsqNODbKgtgmVaxAvmsYSpAaP = "isElementAllowed";

			private bool EZXmErFZNUQlMzafgTZtlBztYpv;

			private bool EcOJZeUujIleVWTQQTpoZdClGpQ;

			private bool QHRBAXJnkFvKxcRLToZXXTSekNl;

			private float dTZTQjpwRhAtpxnYJeqqbvwTEsp;

			private bool MqmrGvgEqpQZzAHHLPhXkZXFfbz;

			private bool qqCcEgYbPwTBJDaxmloyUGLxIBOB;

			private bool sXQgGBQAEzgEAJoCoCIrtPhxRAH;

			private bool uQZozAQQHAtfUqAtJQLKrlVRRcL;

			private int[] cpKmMzXuKhsoMgxUAgljtokUYHy;

			private ConflictResponse YnMBZzeQPZubwQbPzzYLrQWDnTiN;

			private bool RLkchipDEbIPOmgapUMFSTlyRTk;

			private bool lSyABECnMyNaLrgzdRBsOFCJkeP;

			private bool dzSKczxVUGmPLGemzBrimbiwBIm;

			private bool qBqlBkKFWuJVQTAJOboXaAilZPO;

			private float FDZBUFtrnNxyEKbcjDVMoYDemfk;

			private readonly Dictionary<string, SafeDelegate> QKFAHuFoFPwVEGUOWLuMFdRlvFjR;

			[CompilerGenerated]
			private static Action<Exception> lKMFeKhHrXgqvALOaEtuAwYoCQfc;

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

			internal T CqDSUPuPMzanhdKbVKoVzRduJmMa<T>(string P_0) where T : SafeDelegate
			{
				return null;
			}

			public Options()
			{
			}

			private Options(Options source)
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

			internal void CKSoitBPjLqWpFGpwBNgDbvTrVm()
			{
			}

			public static void Copy(Options source, Options destination)
			{
			}

			[CompilerGenerated]
			private static void kqfVgTMLfxikidsJSfnwtZyYwSd(Exception P_0)
			{
			}
		}

		private static InputMapper iyjhAIiEQFGydRvfLhBrkesaltbL;

		private static int LXpbvPeCHYSpjNErzpsuQpZvHryR;

		private readonly int ggFCBTTpdMkVtMfdWgUeDPNtgVz;

		private readonly bool cKgWgiJbLawZFflCTiaLCzJBpqf;

		private readonly KegmMkwLzmhqnBmyfaWcENSzMlSD ecUFKRbgfgMMuvkBhOTLQyYoGJrU;

		private Options vSgsHraqqIxSoQtrhjduflsIUTT;

		private readonly Dictionary<pjaivfgcCurUqQrpyUZWqUryQNf, SafeDelegate> STifjPqOgjmJNCvSbaRpronVLXa;

		[CompilerGenerated]
		private static Action<Exception> ZQeqaNFKeVgqxwajradTPkxPsCf;

		[CompilerGenerated]
		private static Action<Exception> pNpRyCfNxsTVAmAqaOebelrrWpj;

		[CompilerGenerated]
		private static Action<Exception> KWKktRWkwzBbPdRRrpMBlLPqClPu;

		[CompilerGenerated]
		private static Action<Exception> hoCYHWmxWRwwkvpwJdBZFJcNNhk;

		[CompilerGenerated]
		private static Action<Exception> HceSRioqHnjrqFbQcynGPisbXSBO;

		[CompilerGenerated]
		private static Action<Exception> ortPexWgrMFalfJPzkETpvwhcz;

		[CompilerGenerated]
		private static Action<Exception> fvWyREHLybSUilnRYIGPapuyAAk;

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

		internal int id => 0;

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

		private static int NzPmLZHBYYMtTGXXQUFAoroewMJ()
		{
			return 0;
		}

		public InputMapper()
		{
		}

		private InputMapper(bool isDefault)
		{
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
		}

		public void RemoveAllEventListeners()
		{
		}

		internal void ITeinwaAnXXOEJgmQeDHKVqWZxBE(object P_0)
		{
		}

		internal void gFJEITEWLvDQtaEwbhMFtLmACbYH()
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

		private bool eaCduIGlWnoCUPmzuAvihlsUVqj(Context P_0, Options P_1)
		{
			return false;
		}

		[CompilerGenerated]
		private static void IdcdnMOpVxFBuBWCGQzOGyGRlKik(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void pAKNvjFTOFKFtnExWcOJCZtnKTnG(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void UvwIIIXhUQMbypLKCohAvZJTvXX(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void fZpZiuXmjuRonIjnVzkOkVATQgf(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void RxRltCrTTZZUwNrjDCfQKddOeJW(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void LKdGWZiKzajLOTkHdZNbnMiTwAh(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void BGiaDqKSwJAAdyZGESrwkTYlUJGA(Exception P_0)
		{
		}
	}
}
