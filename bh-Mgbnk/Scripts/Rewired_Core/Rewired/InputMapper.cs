using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired
{
	public sealed class InputMapper
	{
		public class Context
		{
			private int fHaHveldDwCshELfJrFxNkpnedufb;

			private ControllerMap EuVCvuVSiUfwUBHIIFxRGpjsmUXcb;

			private ActionElementMap ApAJkrtcsLRynZTfoWCKasZoHzSm;

			private AxisRange SFrEeobaGLjedQHJQsZhugkAfuHB;

			private bool LFcRijYCANbMeFZApBHvvxlDjjYNA;

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

			internal void lbiENrkCtxoPrUCqxFHFhTTqxwNSA()
			{
			}

			private bool BriggBrkBuESWvCUCECECYQKdlgh()
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

			private readonly Func<int, bool> HbbhohzqHSpTqjKtVKtFWOCPgonG;

			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				return false;
			}

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
				: base(null)
			{
			}
		}

		private enum NxCNwPpsrDISVIDTUwhffJsDbVSCA
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

		private class acMMLQlAKPNcINZMPrgTMUPSrffn
		{
			private enum hxcwxeDDezSeCxkYiinjlzeajCxm
			{
				Quit = 0,
				Continue = 1
			}

			private enum LjQRQYOERmpuhSvzXaJuGMZBKDbf
			{
				None = 0,
				ConflictChecking = 1
			}

			private class UZzDfmaDBOfrpaIMBLXkBcCjDGsQ
			{
				private Player SAFKNeXANwPLYJkMjdDrXHRfWBWp;

				private int rqHomZvjSoigxNsTIEVocqwtuaNw;

				private Context YrOVpwAtZiGouGmFXUpcrPKweypO;

				private ControllerType sOrDJgHJRXcoEHtLWMGzptfpKSyPA;

				private int sGDdszFDKASleiJFNblPjBwiSEkWb;

				private ControllerPollingInfo MxpFCexvrILbvLfUkVFNytAkuYPj;

				private ModifierKeyFlags LelBXhMyPWixfVSnpHbLYwluEQLm;

				public Player gBtpIKAmqKAtvhkXhpxGQvLjwWLp => null;

				public int BASxcWeLIxBZMJFBCgzYxAlVaxJt => 0;

				public Context GnjLxRpIrPiFbJdLzehJnNLMHZqB => null;

				public ControllerType jVBlSHHHaCafogWHkKlWDqpINBOR => default(ControllerType);

				public int lVrETBFefJokiRDAFiQysrmXBLsBb => 0;

				public ControllerPollingInfo LaVVogHuJuvzsBYbdrqItiDXGyrhA => default(ControllerPollingInfo);

				public ModifierKeyFlags UAOklEHYZFBZAosyvJgauYCUvVvT => default(ModifierKeyFlags);

				public AxisRange OqKhWiborxPfZsdZjNzefJRAXeRA => default(AxisRange);

				public string VtdCUXdIRZggFWkrBuTjnTtsZFnaA => null;

				public void sPhlmaWRFsgCGjDmRHwWqYcBHwIeA(Player P_0, Context P_1)
				{
				}

				public void tHEgqQJbnNkMdlPyexRRSYdULiED()
				{
				}

				public ElementAssignment wKDCDDlzBQXgEphLLqRyXOHWvCCC(ControllerPollingInfo P_0)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment GgCSKzIrwnKuexaCnUMXcEdShGGeA(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment doKAJFLAOmXJDvMJYYOpVlsLpjYg()
				{
					return default(ElementAssignment);
				}
			}

			private sealed class paAePaahKYTZWcNoJrJwkDgVGuUc
			{
				public ActionElementMap LIThZoSmzEsCiIMoaDcuVvwqtyin;

				internal bool GghKIZgfaaIBSKeBiGpBCJNXNnmzA(ElementAssignmentConflictInfo P_0)
				{
					return false;
				}
			}

			private sealed class nMjxAKqfiVLjcNHpcFicmmgZBRrm
			{
				public acMMLQlAKPNcINZMPrgTMUPSrffn fhKCajkIKSOSeMyNcPYVWeovQwkv;

				public ElementAssignmentInfo dVIfJlICdhJeZerrACTCfAhRjvPMb;

				public IList<ElementAssignmentConflictInfo> IfrihTGbvmZgozJisbeeXtUhuYLV;

				public bool XYtubbwgEKBbnsIogNBTJOIrHDpkA;

				internal bool DbMnLJSNdMxvKmIfSILFKOrfMAbIA(int P_0)
				{
					return false;
				}
			}

			private readonly InputMapper GFNgUBRjOWVPTApUHKIbJDuOdJAgA;

			private readonly Options NIYECAlLjSwvBEstPBlqeSgBwfGr;

			private readonly UZzDfmaDBOfrpaIMBLXkBcCjDGsQ qdrfpNbNkEeRiedYFAQKEBpOBTQhA;

			private readonly Dictionary<NxCNwPpsrDISVIDTUwhffJsDbVSCA, SafeDelegate> DFVlpXfQZryYcAyhhRXxuBLwYUCR;

			private readonly Dictionary<string, SafeDelegate> NpIFQopfEABjzhEpkLanCqqNunYnA;

			private Status mFrExeIzuKDSAdKZSfTQdiImPiKhb;

			private LjQRQYOERmpuhSvzXaJuGMZBKDbf zsfWSuUyRddesMWFEfXFLxqIGTDy;

			private double IzuwRxWrJSmGTwrnTEuhwRDdvdUQ;

			private bool gWcobfVWMGujszkmQqMNXBzHFAEt;

			private List<Player> woKaevDLeYeZyJLqGfJCebwXbfvL;

			private readonly List<ControllerPollingInfo> ytJrJGABnUFmeUwBnNbvNcvQsSvF;

			private ElementAssignment tQXTQToYqCaukeJvjwQjScmiqpgK;

			public Status LuyIIWEwmObclmZcumOfpHIpETQQ => default(Status);

			public float INmbgUliGJYZhGdBeuIPNdLlQfgh => 0f;

			public Context xUwZoLuMInuUzbcIZlgpMbGnLEUN => null;

			private bool UlhMlGBqHikpWPxLNZldiwpFfsQE => false;

			public acMMLQlAKPNcINZMPrgTMUPSrffn(InputMapper P_0, Dictionary<NxCNwPpsrDISVIDTUwhffJsDbVSCA, SafeDelegate> P_1)
			{
			}

			~acMMLQlAKPNcINZMPrgTMUPSrffn()
			{
			}

			public void xDtrXooZsVuSfvVOLteuIlubuFIh(Context P_0, Options P_1)
			{
			}

			public void WgxTKxzIIakPSxcHJmFrUNLwXjgl(string P_0)
			{
			}

			private void mhhAWYBXvvUJlmzYaATMiQGwSAlWA(UpdateLoopType P_0)
			{
			}

			private void ZqeCJfOlOVvULYsIoGbtgqkjgpsf()
			{
			}

			private void NceExUnDDWFBHIJtTJAlEPHFLksLb()
			{
			}

			private hxcwxeDDezSeCxkYiinjlzeajCxm KLWzQYAbEmIKbpQhasocUSprcdEFA(out ElementAssignment P_0)
			{
				P_0 = default(ElementAssignment);
				return default(hxcwxeDDezSeCxkYiinjlzeajCxm);
			}

			private bool XLdoeHYPJKzPooiVFQcaGMxbjVZE(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_0 = null;
				P_1 = default(ModifierKeyFlags);
				return false;
			}

			private IEnumerable<ControllerPollingInfo> hdDiqDzLHUiJdZfoVyqnvswAjThs(out ModifierKeyFlags P_0)
			{
				P_0 = default(ModifierKeyFlags);
				return null;
			}

			private ControllerPollingInfo dOrjDPSnsBWibsSIfvegOxtFbwOB(Options P_0, out ModifierKeyFlags P_1)
			{
				P_1 = default(ModifierKeyFlags);
				return default(ControllerPollingInfo);
			}

			private static ControllerPollingInfo nvpTyOkFPjShlGVZLczBipNWrrTc(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_1 = default(bool);
				P_2 = default(ModifierKeyFlags);
				P_3 = null;
				return default(ControllerPollingInfo);
			}

			private static bool psELJUWSJGWDmDquoAQYyTnWHpPT(ControllerPollingInfo P_0, Options P_1)
			{
				return false;
			}

			private static bool YTcGYNodeWFtNIBRfhLwrBPQSGng(UZzDfmaDBOfrpaIMBLXkBcCjDGsQ P_0, ControllerPollingInfo P_1, Options P_2)
			{
				return false;
			}

			private void ajOihdXukiVWaWPWiLtnWBuYKqKQ()
			{
			}

			private hxcwxeDDezSeCxkYiinjlzeajCxm GafkShUWOkfUwCzvijwGuJPVkNLs(ElementAssignment P_0)
			{
				return default(hxcwxeDDezSeCxkYiinjlzeajCxm);
			}

			private static bool zIqfResnAPiAUDCRAXTxvkZXFvweA(UZzDfmaDBOfrpaIMBLXkBcCjDGsQ P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static bool QgzlujtspcKnkComhvzZLHPnbFYx(UZzDfmaDBOfrpaIMBLXkBcCjDGsQ P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static IList<ElementAssignmentConflictInfo> aSwIzJjUnRWsJpZnzryPOSKOVUer(UZzDfmaDBOfrpaIMBLXkBcCjDGsQ P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return null;
			}

			private static bool vMCFDIbsoVgYQfqscDyRrqeWcilVB(UZzDfmaDBOfrpaIMBLXkBcCjDGsQ P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				P_2 = default(ElementAssignmentConflictCheck);
				return false;
			}

			private static void rupcvKYdIggFVnsQUwtuanHZjZYy(UZzDfmaDBOfrpaIMBLXkBcCjDGsQ P_0, ElementAssignment P_1, List<Player> P_2)
			{
			}

			private void IWTNNPFHYrwCrNiYvBLVoqkadmebA()
			{
			}

			private void ARPMGgrahYAvqsSLTBnkYCxvFLmeA()
			{
			}

			private bool cidoHeOuHFJGqBbqvdEWkJAHoRMFA(NxCNwPpsrDISVIDTUwhffJsDbVSCA P_0)
			{
				return false;
			}

			private void ZABUhqOcGJhJCjfMwbGJLaqJnqVbb<_0001>(NxCNwPpsrDISVIDTUwhffJsDbVSCA P_0, _0001 P_1)
			{
			}

			private void MQQCmdFIxlthLOHlEWIiQXpgqPDw()
			{
			}

			private void UiIbPIqFthgiDBeZJisJAfhMEnugb()
			{
			}

			private bool YnVXncFKDIbHnepbElsfBVgMNjgbb(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
			{
				return false;
			}

			private bool sQFcXECVkODwhqoBfxvfQQmaodeNA(UZzDfmaDBOfrpaIMBLXkBcCjDGsQ P_0, ElementAssignment P_1, bool P_2, out string P_3)
			{
				P_3 = null;
				return false;
			}

			private static bool OCcaGVhCcGntrtUdxIaZCESiLQWMb(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
			{
				return false;
			}

			private void SSoYEpIHfrpdYXbVwpuKgFIkVhMj(ActionElementMap P_0)
			{
			}

			private void JcozjbKuyTIZeRabUrzxCUZLpPhw(string P_0)
			{
			}

			private hxcwxeDDezSeCxkYiinjlzeajCxm KIzWrZWoWYjplPoDBsnUMJetkdvv(ElementAssignment P_0)
			{
				return default(hxcwxeDDezSeCxkYiinjlzeajCxm);
			}

			private hxcwxeDDezSeCxkYiinjlzeajCxm nRsYMhcLJjMBlPdURglEUjFtciqX(ConflictResponse P_0, ElementAssignment P_1)
			{
				return default(hxcwxeDDezSeCxkYiinjlzeajCxm);
			}

			private hxcwxeDDezSeCxkYiinjlzeajCxm XUXBTEmTulgdzbJBLyyMNktimLvt(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				return default(hxcwxeDDezSeCxkYiinjlzeajCxm);
			}

			private void wpdcEgjCTdEflKFoOTbcKCTCnGhJA()
			{
			}

			private void tejqACmnbYBPoUVtEJdGXczVBxEhA(string P_0)
			{
			}

			private void RpcwPMNLyFYMCfsFZcbzEdFRPuTqA()
			{
			}

			private void WOBYwdlnYDeTOmHszMvPMQKzGJGI()
			{
			}

			private void duawCQOsaZIWPzQHQDlxLjlQkIiK(ElementAssignment P_0)
			{
			}

			private void gValzzHXiNDLxfrekVNtzDuNnpzO(ActionElementMap P_0)
			{
			}

			private void fEFAlagbekGkLflEiROZsXeaVLQiA()
			{
			}

			private void uUiVZuKSQsafdNEaiIONAsAdAcTBb(string P_0)
			{
			}

			private void ZtREtXYhFtksXksaxwRFnyllSney(string P_0)
			{
			}

			private void qYbveSncvmDFrYxLAIokbNTntsmB(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
			}

			private void LvwfDIOutsIrJIoLGoDgbkcYmUAF()
			{
			}

			private void xYPxhwoBQLSwMxYtWIsbTpHFNppg()
			{
			}

			public void HrJYEFIvinlGXwUCHwGPNErCjiHW(ConflictResponse P_0)
			{
			}
		}

		public class Options
		{
			[Serializable]
			private sealed class aeGWBQBsBKKqFNAhNJMfZfDABrHAA
			{
				public static readonly aeGWBQBsBKKqFNAhNJMfZfDABrHAA _003C_003E9;

				public static Action<Exception> _003C_003E9__64_0;

				internal void wNrAMxjpvnZDkxDoJrQZKWFFWdMLA(Exception P_0)
				{
				}
			}

			private bool csGfRMeqlkLrRraZcOLxgIkngeEcA;

			private bool jLFKTJrpUPLebmSRrrqEsiNJGQHAA;

			private bool NymERTilpkaaahwrZCQHEGOrijPv;

			private float efbcFRobyYEwlBirsBcJIDJCwVnG;

			private bool QgsQXttsPZtJziUKOkPKlxTetLwX;

			private bool GGDGdDkPeCsWngIoCrUMeNxfHUWrB;

			private bool HoOzXlmPruaOgkNnWHikGphCPxmKA;

			private bool pjRmXwAkIbaErcHoWWOwKkMxqHkk;

			private int[] QIQGyfLmndvHgqrnEAEDPrxWOjEb;

			private ConflictResponse whqcBKGAtFQMNgddPEsSVxdGGGqi;

			private bool gHJBCscfexewlslMphVtnAIzpwAGA;

			private bool mhBZabjWcbNFfxZWAkLOdOYmVbxg;

			private bool XQybKHKbxTzhukVtalxsTTXvNRBhA;

			private bool QOfTqopEudSGAochEcPCfqsnnGUG;

			private float MEUwUzzgCBBLdPbavxWiDLmxegxW;

			internal const string HGxaXRiLUVvxufJfoMdfXfaNSnktA = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> PQSmepyNjgbhzWjtsQQJDdwZSysk;

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

			internal _0001 mpFsByJnFNOJQnnAAZlvCIZrlxIO<_0001>(string P_0) where _0001 : SafeDelegate
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

			internal void vqKJVsjXoGMfYFehXjsSKUWaRHLmA()
			{
			}

			public static void Copy(Options source, Options destination)
			{
			}
		}

		[Serializable]
		private sealed class abealZkULwCjtCameCIApqKYpdGfb
		{
			public static readonly abealZkULwCjtCameCIApqKYpdGfb _003C_003E9;

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void KswzCNMxCVnIBLvAztbczcYlfQbQ(Exception P_0)
			{
			}

			internal void bqyfbJWxbtIXifzezkwvpXDFyicz(Exception P_0)
			{
			}

			internal void HypJEasprFgxnckWJFMqovpEpSjV(Exception P_0)
			{
			}

			internal void mQfpxGMWkkvgLeyUaRUUyLynXjiG(Exception P_0)
			{
			}

			internal void WUKcAQHgqvbfKxgedefhqGNPdStH(Exception P_0)
			{
			}

			internal void XZFpneQsbZwkuUfVtdJGhBcsxypW(Exception P_0)
			{
			}

			internal void wWZfWfCuPiViwHozePqoQboQJmDSA(Exception P_0)
			{
			}
		}

		private static InputMapper fEcRHtthGmXulEezUqDHVDTmRSqF;

		private static int NXgTaTiJMndoRWCiNyPHRhwiTMjR;

		private readonly int qOfsFxOXsCuwtZPUiTuJqLiSbWTdA;

		private readonly bool wbJhiUbCygICqvDUZgCjzIHlOHXIA;

		private readonly acMMLQlAKPNcINZMPrgTMUPSrffn YlFsdtZVuYOhbDZepAVeeWTaEhHB;

		private Options SZiWRcsXIEkjGHhbCaxeBVifozsEb;

		private readonly Dictionary<NxCNwPpsrDISVIDTUwhffJsDbVSCA, SafeDelegate> jaGOApljOjmscvfhKXJmWnwpxzkS;

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

		internal int JiPHyQnibPhbDNrfHfppcTpEYXrIA => 0;

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

		private static int uMoqqtKLtZWHBubJLiDvdScniZwB()
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

		internal void vCEqpeAewLLZTmfTAQDqweYuDSncA(object P_0)
		{
		}

		internal void wUrLaPScaPIDwUuhOQnoOwoxzMwI()
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

		private bool ECZljXVDHstQIqgETyQzvcABvxut(Context P_0, Options P_1)
		{
			return false;
		}
	}
}
