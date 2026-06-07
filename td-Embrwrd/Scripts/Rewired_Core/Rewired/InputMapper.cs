using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired
{
	public sealed class InputMapper
	{
		public class Context
		{
			private int icpbzeegvhcHtdsgefxNaebRWrzS;

			private ControllerMap FASngiQCkBBQpjRsxLnhfvmYOIdB;

			private ActionElementMap JDTwptqgIYFPrrbmZpqoyKXWhdZo;

			private AxisRange TCYhIeeqQTwAqMeKlsMtovyscvbgA;

			private bool AGpqjlNtsOvAyvODKlaHbTzvdnBh;

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

			internal void cSzFXnjRFgQaxoZbOEzbVnFUPkEy()
			{
			}

			private bool KzrSoVqCjhntOHRDzfucMGKyKblT()
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

			private readonly Func<int, bool> OYaNdbgfnLaEuGHyomkvCGUfueqjA;

			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				return false;
			}

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
				: base(null)
			{
			}
		}

		private enum ICLypLoTHIvhZwXOnTbPbeyhCRJP
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

		private class fRJDiGaZkYLTAfdXqKPhUiVwdNgj
		{
			private enum oCzxwwKEwcJrORVaFPiDpHiSQEem
			{
				Quit = 0,
				Continue = 1
			}

			private enum YjBSDOJEztSYbmakcLACICVfVYaT
			{
				None = 0,
				ConflictChecking = 1
			}

			private class HSgHNubrdTlKdSXViQxSFZYLNGrR
			{
				private Player DjWDUmGhtdeyUprHOWtLRFPJwBTN;

				private int mFEuDPuBwbiVvrLOhmnAywuLUkWy;

				private Context NEZjteZHxtDxaoVQaZVCdEKQwleJ;

				private ControllerType bXaCVaGkjSDHOTuAtKuLzWrJBCxV;

				private int ltAcfKGszXQsjdQNuPbcZgZcAzJB;

				private ControllerPollingInfo HfcvJemJDLAilxTZZGzheUWQCmOIA;

				private ModifierKeyFlags KVuiBtLnbRHZxhHiKwdtUHlSkQST;

				public Player druOkQHlWBETfBjYABewWgPPkQKQ => null;

				public int UzJkRWjmRuscUnAbbTlkltKrxrUC => 0;

				public Context XIyGZzaKmIdHVpXoAIAJvxHqbRMJA => null;

				public ControllerType cAGmhRUOENaSeYAKTBFigZduxJBPA => default(ControllerType);

				public int iaHTFjeREQFczlNudiSbOszEVhbA => 0;

				public ControllerPollingInfo QsOkHmYfrtCkyvfsGhCapOFnGiaJA => default(ControllerPollingInfo);

				public ModifierKeyFlags BjHtuKMXfQwFEGPlKGAUcCGaJRyy => default(ModifierKeyFlags);

				public AxisRange FvrFvYChKyUalQziqobXhdHpZVhQA => default(AxisRange);

				public string IqiAVFXnbAPTKAepcxFEHnFOZDkd => null;

				public void twkmZiTrhbnaAtinciQiMRcpUaPv(Player P_0, Context P_1)
				{
				}

				public void aUFZaEMRBQhBdCDOBhZfwGEmpZLTA()
				{
				}

				public ElementAssignment jICfAZakHFiaQuXooQCGWLUwhfXeb(ControllerPollingInfo P_0)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment DMLIpvTfMqHtmTIHImvjuKhgUhXL(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment aiXyYNYNqhDcBPDAvTkRRtzhFdRW()
				{
					return default(ElementAssignment);
				}
			}

			private sealed class wVHBskalFZbqOrMAexJhpqLnOAzz
			{
				public ActionElementMap IDGbPcVxNDirikTfHxOCRQuYScho;

				internal bool DMmkYBxEOdGqYcJENAFjHKXnRjrM(ElementAssignmentConflictInfo P_0)
				{
					return false;
				}
			}

			private sealed class ahszjGthQSVgstJsBnACiFgzoLaO
			{
				public fRJDiGaZkYLTAfdXqKPhUiVwdNgj aMRgcftxgZOfiuGEBxgjQxsJeorx;

				public ElementAssignmentInfo qLHPrZNFobBHHoofBrsIijJfjQCA;

				public IList<ElementAssignmentConflictInfo> VUobWZJgDfeViJplZUQOZuYVhMIW;

				public bool GxolkxdSqPcKdANbNhrhIZCNfBwHb;

				internal bool IvRDJHXjDLMuSKCmpCrfSwxDNIqy(int P_0)
				{
					return false;
				}
			}

			private readonly InputMapper VWAaSRSzeHjeXiHNmiyXBjykQPXt;

			private readonly Options QrTbMAwvNNwEVstauvXGeuixwjVr;

			private readonly HSgHNubrdTlKdSXViQxSFZYLNGrR nWqNlLoJMRkHeKiHcekyjYrccPBJA;

			private readonly Dictionary<ICLypLoTHIvhZwXOnTbPbeyhCRJP, SafeDelegate> YMYxZVesrahzsmJcYxCJenPQEqRG;

			private readonly Dictionary<string, SafeDelegate> YWVBCyuzmRcWvwLoPFGJsmabAxDr;

			private Status rkkbhcLvGPqjILtQdolcsVYQhwXV;

			private YjBSDOJEztSYbmakcLACICVfVYaT eXuSmaFlkmTkwsYObbtbJelsFBMf;

			private double TdjVXvNfPBnTDEcqgGRXeNLVhJrc;

			private bool zWhBchkAiVbZcAPvjUKrbDlarWHhc;

			private List<Player> zvZqwvYIEFTTktOfxoDgcsyhvHqk;

			private readonly List<ControllerPollingInfo> xqGAfIbHxRdquUgdMRpXEZheKmawA;

			private ElementAssignment szIfZTlwYZMTuKVoORUFSRiUKgbQ;

			public Status UzfKEYBNYNFUjQutDPGFllKLfVNp => default(Status);

			public float DCfDtwAgEAzvFUcuJzUbIVfPuAtPA => 0f;

			public Context iYrieJlwUojKjXDNuGDWUUEFAeFd => null;

			private bool TygYKIKjMjFZKdUsiXjFcPmnjbRw => false;

			public fRJDiGaZkYLTAfdXqKPhUiVwdNgj(InputMapper P_0, Dictionary<ICLypLoTHIvhZwXOnTbPbeyhCRJP, SafeDelegate> P_1)
			{
			}

			~fRJDiGaZkYLTAfdXqKPhUiVwdNgj()
			{
			}

			public void eYeWrgxonAZNtLxKcwVEYDxXAkHgA(Context P_0, Options P_1)
			{
			}

			public void XFksZrmxadLBKFsQoKSNYqLEkTnn(string P_0)
			{
			}

			private void pliAkUULReeapJRvRpdmQWoIMduC(UpdateLoopType P_0)
			{
			}

			private void CcdpQnPYaGhEXkuNLwcTuokJagjt()
			{
			}

			private void YTnFbMyqdNHsBvdmatkJBtBpvibM()
			{
			}

			private oCzxwwKEwcJrORVaFPiDpHiSQEem VHFknKRFmvhzxXfwZzEOUenNChDBA(out ElementAssignment P_0)
			{
				P_0 = default(ElementAssignment);
				return default(oCzxwwKEwcJrORVaFPiDpHiSQEem);
			}

			private bool YXqqcBDEzXwKoMmCkJqGQSvTMzSV(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_0 = null;
				P_1 = default(ModifierKeyFlags);
				return false;
			}

			private IEnumerable<ControllerPollingInfo> mzAqXTwBdVHyftnrgEMZhqsyUHyv(out ModifierKeyFlags P_0)
			{
				P_0 = default(ModifierKeyFlags);
				return null;
			}

			private ControllerPollingInfo idJHvXEZJxcliHADaIROkKbmrdfDB(Options P_0, out ModifierKeyFlags P_1)
			{
				P_1 = default(ModifierKeyFlags);
				return default(ControllerPollingInfo);
			}

			private static ControllerPollingInfo qUcPXGjGfeBrxmUIcfQtFobeczqbb(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_1 = default(bool);
				P_2 = default(ModifierKeyFlags);
				P_3 = null;
				return default(ControllerPollingInfo);
			}

			private static bool euJBdQRApVKqkxInFseugRjaUlAT(ControllerPollingInfo P_0, Options P_1)
			{
				return false;
			}

			private static bool PZxRKBfjCVzwFgHSCqRAjQJqeYchA(HSgHNubrdTlKdSXViQxSFZYLNGrR P_0, ControllerPollingInfo P_1, Options P_2)
			{
				return false;
			}

			private void tdDcjxIzGlVneiLLLeDPGmsqlwLp()
			{
			}

			private oCzxwwKEwcJrORVaFPiDpHiSQEem VcwCsjTAsxElgmwmHGMsoSNjKNWU(ElementAssignment P_0)
			{
				return default(oCzxwwKEwcJrORVaFPiDpHiSQEem);
			}

			private static bool wQdBNypFiGGpMvUKtczFhzRhrzhRA(HSgHNubrdTlKdSXViQxSFZYLNGrR P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static bool NJueBdsFLjKYwgYjKFwhDkTTByZF(HSgHNubrdTlKdSXViQxSFZYLNGrR P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static IList<ElementAssignmentConflictInfo> vhxxLZmxNUPOXTzwSUQtKkQqIHdk(HSgHNubrdTlKdSXViQxSFZYLNGrR P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return null;
			}

			private static bool qBBhChsIAnuKEkbwKahgNmAaZsi(HSgHNubrdTlKdSXViQxSFZYLNGrR P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				P_2 = default(ElementAssignmentConflictCheck);
				return false;
			}

			private static void kyaFaMVUezguBLtDhCBOqHFhjZRY(HSgHNubrdTlKdSXViQxSFZYLNGrR P_0, ElementAssignment P_1, List<Player> P_2)
			{
			}

			private void NdAVPTCLiqrPbthZErYjyloSgLfJ()
			{
			}

			private void NcKmYgskDDAEqAXIgVVECJbVwNtv()
			{
			}

			private bool lBiXDsTCtIjtwzHpWaXuDZKfThVh(ICLypLoTHIvhZwXOnTbPbeyhCRJP P_0)
			{
				return false;
			}

			private void EvQpzeDGqIqHQVDPTeThefcnHqEP<_0001>(ICLypLoTHIvhZwXOnTbPbeyhCRJP P_0, _0001 P_1)
			{
			}

			private void PLHekdSYVwGQDsxghpyGSOrQqLUr()
			{
			}

			private void RNNhBShZTcHVHOBAoFWzdfnehrtjA()
			{
			}

			private bool LfSjSuOnpBuinLoPzUCPNgygbtzi(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
			{
				return false;
			}

			private bool bVAFfMOMlVHvnUKWGHMNKuyGdOpE(HSgHNubrdTlKdSXViQxSFZYLNGrR P_0, ElementAssignment P_1, bool P_2, out string P_3)
			{
				P_3 = null;
				return false;
			}

			private static bool PtdYtHHGKVWXxowtGEVbUOWvMLND(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
			{
				return false;
			}

			private void BTnZSbZAhyOOEjqYTEBgEcAQaNLqA(ActionElementMap P_0)
			{
			}

			private void EHnxbxTFGAqLmrIurRBHUGDxELyr(string P_0)
			{
			}

			private oCzxwwKEwcJrORVaFPiDpHiSQEem LbsjMRZhmHGmbvcSwRcoWGgLKxcs(ElementAssignment P_0)
			{
				return default(oCzxwwKEwcJrORVaFPiDpHiSQEem);
			}

			private oCzxwwKEwcJrORVaFPiDpHiSQEem qezbKbajjsWlxdhXgKImIIXJlajjA(ConflictResponse P_0, ElementAssignment P_1)
			{
				return default(oCzxwwKEwcJrORVaFPiDpHiSQEem);
			}

			private oCzxwwKEwcJrORVaFPiDpHiSQEem OrCFHIjmUafQbBLQmMCygBfBGBuBc(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				return default(oCzxwwKEwcJrORVaFPiDpHiSQEem);
			}

			private void zkqFUcsDjmRWbdalhSRECjTqaAyJA()
			{
			}

			private void ufsCpYtmRNaoqsFezHZaJddjrRRI(string P_0)
			{
			}

			private void UGxHHYIgQYpBOXoCiNWTbCTjawUj()
			{
			}

			private void XnCMKnuosIATKMldKQilUmIPQCJU()
			{
			}

			private void acvssAHVKChvPFxQjhzJLIlyjqtX(ElementAssignment P_0)
			{
			}

			private void hyxzyxEMWGkibLorPbZTnawxxRmh(ActionElementMap P_0)
			{
			}

			private void yvIGjgdTCbUZXVVJPoRfRWkYXpDk()
			{
			}

			private void rvxNUeTsZlOqntheDustgUKNkcAC(string P_0)
			{
			}

			private void MCIDhTRJnyjDVCGfQKhlIztCBrtrb(string P_0)
			{
			}

			private void vncCdkjgKfguPxumrCsIvlJVcfjoA(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
			}

			private void IrvZxCHcInDdNeufzFKKDhquwgFiA()
			{
			}

			private void grWHrmjHsILzCDaarcaRCTBjlZecA()
			{
			}

			public void YcCtIJJNQovIVOpTwNCtFytgIcKy(ConflictResponse P_0)
			{
			}
		}

		public class Options
		{
			[Serializable]
			private sealed class dmVPIUKerTGlRdxeyLqZPZZcJfWlA
			{
				public static readonly dmVPIUKerTGlRdxeyLqZPZZcJfWlA _003C_003E9;

				public static Action<Exception> _003C_003E9__64_0;

				internal void hmsAjjwFqieuwhjdycDpCLhjbHHG(Exception P_0)
				{
				}
			}

			private bool dBZDHQlbXzLEFBOQLFrFHqkLseVEA;

			private bool ahYHHDaJsETXdYbQAaCmoOLbhGGz;

			private bool OenoMXjJJzBZyJngydavIhMNGpIeA;

			private float jEeXeHzuGVlfdbmlZefpYlFiawyz;

			private bool PnvFPrsNfQmIdKFLrCtmzpRATBdx;

			private bool FFEzXvGIKFfdxixwriuOZxCpUDDB;

			private bool CEPPPhdJmhpdaWbgdOZMdhrgbvzh;

			private bool gQCReuZmWiGDjWlvlMmYWOEPikxCA;

			private int[] DTNGQabgYyJCRbWqCmigAPjhPCygc;

			private ConflictResponse rcbZcSVNFEkpJIicsEisHRlsIMzAb;

			private bool dlEUcqySiyFXnVHaCdSDYMsFsdZe;

			private bool jSMRTzyqMyHgdJVPzYTyjDYMFKal;

			private bool OvvYBsoJyMKsztadPLKuVFhLDYRc;

			private bool VxeZVayGggbdUkOhvhQcfjsaLrDOc;

			private float PXFiczaQoMbwlbkfMgmQXroHEeuX;

			internal const string ULqNgLEqKIAvwxoTFFeZfgBphclG = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> YSZuTfbnPrOyjcJqNgnvJbylaXvj;

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

			internal _0001 pdKVZqOgnYkBYPjHvBDDEGZJnQBk<_0001>(string P_0) where _0001 : SafeDelegate
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

			internal void gmNRewgVWJUOGtbmkKHaAmGQBOOK()
			{
			}

			public static void Copy(Options source, Options destination)
			{
			}
		}

		[Serializable]
		private sealed class nSxvRThtszAdnOprJkhswUvathZe
		{
			public static readonly nSxvRThtszAdnOprJkhswUvathZe _003C_003E9;

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void JktLpDHxuCOMTbzJGMHYhlWVdUsBA(Exception P_0)
			{
			}

			internal void tzgLHATwyjyPVxGGSNJmLlortG(Exception P_0)
			{
			}

			internal void MoiKgyzvFIAIjAeNiAuYoOnuOScW(Exception P_0)
			{
			}

			internal void rjyMnGPNIhHQRcGRRxzqkooNHRftA(Exception P_0)
			{
			}

			internal void PrHbwYOiEkgKOVQhYbKPoUJzEzky(Exception P_0)
			{
			}

			internal void ECOvIiTqTCXaiuFKMbxePeiQaasq(Exception P_0)
			{
			}

			internal void rCLYrFfzlHTyLIcNKIMTpqujqKxA(Exception P_0)
			{
			}
		}

		private static InputMapper qfpyNbaryrkkzogingItERHIWPdWA;

		private static int QyrcjHrbkuPDDgrzipLvLjyMIboL;

		private readonly int lDkNznLjAZBJbneZTcYlizigOOSO;

		private readonly bool jSLiGQXExyveCvVkQyLUvLJCBAKA;

		private readonly fRJDiGaZkYLTAfdXqKPhUiVwdNgj PiWEanIWdXcddHjIFSmhckCpIOsrb;

		private Options DafFbyzCoFGMOjeqvIHGZdsVRhfY;

		private readonly Dictionary<ICLypLoTHIvhZwXOnTbPbeyhCRJP, SafeDelegate> uPROhfcOwgDRkTcanvwIIoaJvxhg;

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

		internal int CeCBuMokJUgKZBloeSBJrPxmnZyaA => 0;

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

		private static int rjhfquiFtOvpTnQiqoWzfbMhVsKgB()
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

		internal void yjHfOsZSOSooHUDQdtoGkKGIOasl(object P_0)
		{
		}

		internal void xhcxVDJiIAZfosxoxTyWMioRevtu()
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

		private bool JrSxMNWCfpGdQWnZcreVvIYrSdnT(Context P_0, Options P_1)
		{
			return false;
		}
	}
}
