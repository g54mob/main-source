using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired
{
	public sealed class InputMapper
	{
		public class Context
		{
			private int WtxqRhyewFhRCZexgGgTPAkliDAd;

			private ControllerMap xnhNfzyqGuCronbiVjqLrzXhjTDR;

			private ActionElementMap KaxTDdrGzDvRPWowWgyufgzhfSmfb;

			private AxisRange whWedHybHebOtxSEJTDdHkzxfrxw;

			private bool GZlaoDruTrxbpKABIxsvccmRvfdp;

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

			internal void NKBcKXzflFkdrvVAruarefQcmIkt()
			{
			}

			private bool QewHIOCTWValNSqewneyYoOrjOvAb()
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

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4)
				: base(null)
			{
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

				public Player EVSYfBRoRmlZGWzbtVEKHpHdIHIm => null;

				public int oRajQOHwRbMrJNwZiDDGjrEZUMQf => 0;

				public Context qYkEVCpesWbAtDCezhWRBzcJaIGKA => null;

				public ControllerType qwgjCbRzxrpcbcpGuDjyBQzIUaDs => default(ControllerType);

				public int ewwLiKFmCKbnVFhcViVbHODDzYHW => 0;

				public ControllerPollingInfo byAFfydmOrcNbayjDdRyuEIoJpDY => default(ControllerPollingInfo);

				public ModifierKeyFlags vumoKGoIRVLegjZXlOfdXDdaDhgk => default(ModifierKeyFlags);

				public AxisRange kHytYvdOKSYoCQbwRpoWYapCFjaG => default(AxisRange);

				public string cEVTolnLxPQycmAdyfMPITZGAFikA => null;

				public void gUxczTgMdKUcYRnCXamteWaCXJodc(Player P_0, Context P_1)
				{
				}

				public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
				{
				}

				public ElementAssignment vWTWEPBOTNFdpxCpQzIbCjjPTllg(ControllerPollingInfo P_0)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment vWTWEPBOTNFdpxCpQzIbCjjPTllg(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment vWTWEPBOTNFdpxCpQzIbCjjPTllg()
				{
					return default(ElementAssignment);
				}
			}

			private readonly InputMapper rBdHDCfDobOjBUqyNbBnmEluxEvZ;

			private readonly Options gWFkjNQjMYNHGCUHgmjPDBquGmEq;

			private readonly pmUzdMirAlhOtikpOkSpGPQLRyNe WyGOFkAEQFlDbtdojjqgGamralvG;

			private readonly Dictionary<iDoQDHIiwETMbCJizSppYbHEesMc, SafeDelegate> ZJHOjdYCFtQdnCcqeMUMPtxtyudC;

			private readonly Dictionary<string, SafeDelegate> FcyivYKfpDdWyGkqLAlfXrDVByow;

			private Status UfFxjysFLxRopyPKKKxvjAPfOIdq;

			private JfJEHVACqwRhFrlZYtHMrqJEYVpAA tCnjxBRPGxDZIwSvLBDKBCEjkluL;

			private double NVJLtSvqwpWmxGuvMYWPFSaDWVYC;

			private bool xHEguNZLuURcprclCUCLhmgJxSMO;

			private List<Player> jbmSbMXmRRagDHILbinjZznDLBrnA;

			private readonly List<ControllerPollingInfo> MLbFWYeVCcLRjKWMwoKzRVRYRPWz;

			private ElementAssignment lTgoqjCHRiwTSwsQvQWjxkPMCDSG;

			public Status zrBcGbaLGxobtIkzgrnbFBqUkYqH => default(Status);

			public float mIpClqFXZidSkqvJhszTGmWiVIchA => 0f;

			public Context nMdsvGVoiFsvlDBhLobjLROepJIM => null;

			private bool ovzlzRWrnpFRyZooyErBXaJCCIro => false;

			public ZvDhRYMRDsjbFHQHwDxDbYSTMUTD(InputMapper P_0, Dictionary<iDoQDHIiwETMbCJizSppYbHEesMc, SafeDelegate> P_1)
			{
			}

			~ZvDhRYMRDsjbFHQHwDxDbYSTMUTD()
			{
			}

			public void rIjUCmsjifmvcBNTbhJRFVmmqsqk(Context P_0, Options P_1)
			{
			}

			public void rIDxlGQcqdKUvtFpkiSHtGvVApWC(string P_0)
			{
			}

			private void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
			{
			}

			private void cfGxOdtHWEPUlSbBpwyOclSNIGkO()
			{
			}

			private void iqSeAMNoRFWAzJLKanbJnrgyPcwX()
			{
			}

			private muLFjORuycYLNbTjLtXMUDFJHdOk ZBgDviXzuwlLosmYoukzQDuneweg(out ElementAssignment P_0)
			{
				P_0 = default(ElementAssignment);
				return default(muLFjORuycYLNbTjLtXMUDFJHdOk);
			}

			private bool BMgikzJOrnrunEHNTBustCcfdPNn(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_0 = null;
				P_1 = default(ModifierKeyFlags);
				return false;
			}

			private IEnumerable<ControllerPollingInfo> GTVWPodPMAAJnvxgGijgUAOVuXu(out ModifierKeyFlags P_0)
			{
				P_0 = default(ModifierKeyFlags);
				return null;
			}

			private ControllerPollingInfo qxlemTiLhXOzsdeqcVKVZGjLCRzg(Options P_0, out ModifierKeyFlags P_1)
			{
				P_1 = default(ModifierKeyFlags);
				return default(ControllerPollingInfo);
			}

			private static ControllerPollingInfo qxlemTiLhXOzsdeqcVKVZGjLCRzg(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_1 = default(bool);
				P_2 = default(ModifierKeyFlags);
				P_3 = null;
				return default(ControllerPollingInfo);
			}

			private static bool rwcDKfKJUXixFBhHNYoHaWPRsDjF(ControllerPollingInfo P_0, Options P_1)
			{
				return false;
			}

			private static bool gJlDEpABixzHOdKijQoHaMvULvKsA(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ControllerPollingInfo P_1, Options P_2)
			{
				return false;
			}

			private void EfAedUDAmguPuxhsIdTPEgBiepCcb()
			{
			}

			private muLFjORuycYLNbTjLtXMUDFJHdOk WzEzLzOCWdfvEgAzPGfnNLfMtUVq(ElementAssignment P_0)
			{
				return default(muLFjORuycYLNbTjLtXMUDFJHdOk);
			}

			private static bool iJQNMOIxOVvDCXTDCJqRnFhnvZfP(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static bool WOITgoeQxaEwrAXmnTpqEJSPMWHBb(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static IList<ElementAssignmentConflictInfo> tzQsbRIENRAkAYeEuLCSgbXxMglm(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return null;
			}

			private static bool WaBOOKBtjOsDkgcQMSfXZQvlHaCP(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				P_2 = default(ElementAssignmentConflictCheck);
				return false;
			}

			private static void czMydpzERgypAziEXGtLKUcLbCoaA(pmUzdMirAlhOtikpOkSpGPQLRyNe P_0, ElementAssignment P_1, List<Player> P_2)
			{
			}

			private void seAsLvCVhutZBSdjWZowazoKIkpd()
			{
			}

			private void QoIfAjCldKxmQlDpmitXWAxXylyG()
			{
			}

			private bool vsUBJgRhuSRyEqtbZhHUPALeIIlY(iDoQDHIiwETMbCJizSppYbHEesMc P_0)
			{
				return false;
			}

			private void WkEIHNWRAChbzjbcJQHkWrAwQxsd<_0001>(iDoQDHIiwETMbCJizSppYbHEesMc P_0, _0001 P_1)
			{
			}

			private void rTuiuFsWYuMzTuNRFKakEmPsaOxu()
			{
			}

			private void hbnMJHcnNPaRLokTxCsmFevsdVCk()
			{
			}

			private void sgYvTbUUeSOqwuIORywGshHqTSPF(ActionElementMap P_0)
			{
			}

			private void faEZOLRrhTSQOwIdZucJFIRdpLlh(string P_0)
			{
			}

			private muLFjORuycYLNbTjLtXMUDFJHdOk QXILPfIkCbutOXmJHSChJPCmMMbq(ElementAssignment P_0)
			{
				return default(muLFjORuycYLNbTjLtXMUDFJHdOk);
			}

			private muLFjORuycYLNbTjLtXMUDFJHdOk kYEnrRNoJrUyXTDkrRTvBGAwCPAcA(ConflictResponse P_0, ElementAssignment P_1)
			{
				return default(muLFjORuycYLNbTjLtXMUDFJHdOk);
			}

			private muLFjORuycYLNbTjLtXMUDFJHdOk kYEnrRNoJrUyXTDkrRTvBGAwCPAcA(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				return default(muLFjORuycYLNbTjLtXMUDFJHdOk);
			}

			private void CfomYOUugJAARKrpvsmRrOipFNTd()
			{
			}

			private void zXwEVqllwtOTMPjlzmsgzuheqOrM(string P_0)
			{
			}

			private void cFtPvAtRpOqedAmQIFoYPszIZNjl()
			{
			}

			private void bVHeZOsPlOfWncyuIkoucwJxQLpqA()
			{
			}

			private void dSFlRNCVDYwLZTbJTgmpptwdJfvW(ElementAssignment P_0)
			{
			}

			private void OLoCEbROPZJUdKCpVjhWlaaLuLmi(ActionElementMap P_0)
			{
			}

			private void ErFnoEbeEcVwYNynYJuCevASTppQ()
			{
			}

			private void pNNuUURovyOzrrdwZEfGEOLNOvPab(string P_0)
			{
			}

			private void LNnxcXuQYWomptRbSaHOQArVDAVZ(string P_0)
			{
			}

			private void VVuowzZNSfoPvhVQHCeeEuEKmcGU(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
			}

			private void dmRxjNeEhKTIvHGkZzclNAFgoNNt()
			{
			}

			private void iJPeLUZsgwKsvhdgjmGmsOuQdsMeA()
			{
			}

			public void FwlzdKBdOphWUiECGxFWNhiFMZJgA(ConflictResponse P_0)
			{
			}
		}

		public class Options
		{
			[Serializable]
			private sealed class XHRfoWFoIjJDWPHpwFpnWoCRRYzsA
			{
				public static readonly XHRfoWFoIjJDWPHpwFpnWoCRRYzsA _003C_003E9;

				public static Action<Exception> _003C_003E9__64_0;

				internal void AZRCetBlgXZsuVOECCdTPAeWIUl(Exception P_0)
				{
				}
			}

			private bool NcszPLxzMMcRmhBvdCHKLlSVQjiC;

			private bool LypYmIebREXwtSOyNMUXhJWLhnLM;

			private bool FfoVexhUQNkgNkPbYFpcdrMGbXqmA;

			private float crwJiwJjUjcBHbvFSphLGVtbpptjA;

			private bool TmLREZAbKnmVXGcpAvGoGAPtSUaw;

			private bool lzfdhCkohgRQtgDBzuhFQuFHRaFcb;

			private bool lppljsocjnVqQakbnVkCnprNvtIe;

			private bool fmzhLTaqeFlwNyOcgXRiPirvGofr;

			private int[] rmjyHDnTotVheopmXQhYPxeiardo;

			private ConflictResponse XdhAaBgNfNdoQvhlkSBeuMYbAkpaA;

			private bool SHNCLCHRifBYuAqAAoJiVutIWepeb;

			private bool iCZjpeaIVanOpdxIaBWemBNrlDUp;

			private bool wIxzlFRiiOqrhQHWyKQBEzeUdvrV;

			private bool zkTLEMuifgnAcFfoTduqOVMVhcFeA;

			private float AbwHphdRFJotyIQOclIxtWDCLCtZ;

			internal const string eBheDtCqRKeuWFgGIeBBqMKoRhCCc = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> FcyivYKfpDdWyGkqLAlfXrDVByow;

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

			internal _0001 RhabjnUWqbcSFUiFGjBorUpCDgLI<_0001>(string P_0) where _0001 : SafeDelegate
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

			internal void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
			{
			}

			public static void Copy(Options source, Options destination)
			{
			}
		}

		[Serializable]
		private sealed class HYxVqTFzEZsHqkvgDriUVPPVCRoh
		{
			public static readonly HYxVqTFzEZsHqkvgDriUVPPVCRoh _003C_003E9;

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void GFICSHfXwdXRhVlQjpNWrGTJmZBg(Exception P_0)
			{
			}

			internal void tHbInSZoglQXVznjsChcVnXmZDKd(Exception P_0)
			{
			}

			internal void NtZqqoqLBDcCOihjNeESGhNdmpsmA(Exception P_0)
			{
			}

			internal void CvWbXpXIDockZclaBZEvWJeYqRKC(Exception P_0)
			{
			}

			internal void DOlgnUqihXwCbbHDcjteTquXipQB(Exception P_0)
			{
			}

			internal void AcISgOIAJVXGgEqSqeDdQzvcMYUN(Exception P_0)
			{
			}

			internal void BYXwVPLWKdPCIxrIwfAGKJcEcPff(Exception P_0)
			{
			}
		}

		private static InputMapper bPGhEsCmNTbAPJBiQCMCWwkESCog;

		private static int QNIaCncYjQEaJUXLuulPVkBZXMlx;

		private readonly int vdcIytEzXWnlFkMZVAPVOlZXoeusA;

		private readonly bool bUNMlOxMvahtnxWkITpuokDlDYoo;

		private readonly ZvDhRYMRDsjbFHQHwDxDbYSTMUTD dsrcrhWGJkXDSwKxoEKoQHAQzuyS;

		private Options gWFkjNQjMYNHGCUHgmjPDBquGmEq;

		private readonly Dictionary<iDoQDHIiwETMbCJizSppYbHEesMc, SafeDelegate> ZJHOjdYCFtQdnCcqeMUMPtxtyudC;

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

		internal int ZamYCQxLHAGKChjEHxjlKOSnIhez => 0;

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

		private static int GisbZxebqMwJbVAbJbTxoWiMyJEz()
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

		internal void DJDMIYAXIBXSkNSQNYTsdiMsYWAE(object P_0)
		{
		}

		internal void nBgCjbgvnncYTsqOqfXuEHgcnYRFb()
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

		private bool rIjUCmsjifmvcBNTbhJRFVmmqsqk(Context P_0, Options P_1)
		{
			return false;
		}
	}
}
