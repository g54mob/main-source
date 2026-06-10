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
			private int CijfVweIqbvViXAEzqkELDhcHIR;

			private ControllerMap rAbbicgqWKQOAQlOWnWEeduwIaQG;

			private ActionElementMap CorvUahBrxVJjOhKFoUdcNSaclnJ;

			private AxisRange cuCvqSsXPQKZZvaREteiDEysAdc;

			private bool IldkzAlpPTtnZOIjBNYmiINAHIq;

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

			internal void TvVjCVxnIxxZSrolqOonexjzrdU()
			{
			}

			private bool IowHRVReIzDxncfEtXGzmfzeMtc()
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

		private enum ecNBJQYhkGvBwUjvcBsaIQKRpZzD
		{
			qqKgZmfXVIEaVLKMTlLIafFeNMyG = 0,
			lsNpVBCoYFTzTKRGoBNaiBPHRLu = 1,
			SWIZtNKhHByuyxkZJanCAGxKNxOw = 2,
			fiFVkszgXeSeYiJzGuAkMHqWLtH = 3,
			ubxbeZetCImYTsYBqEPsBgctfKHR = 4,
			qckBmROHIOmBnHNseXxbcxMFaNv = 5,
			fRvvVxflqsymZgCFMMUlGBOIZEq = 6
		}

		public enum Status
		{
			Idle = 0,
			Listening = 1,
			AwaitingResponse = 2
		}

		private class JjXsBZGeRGblfHFabJhQgxhYvnGt
		{
			private enum XAiHyxcqZGoluJVsLJiLGHKNavlO
			{
				TYsFRyLWOFdDjvEovxLilhirCrW = 0,
				DAXvlQUrvvONXUtXvDffiOaPPLt = 1
			}

			private enum skSyrzZBychKEiWJvHHGuSzxPif
			{
				bANLksuTeREfmxvNVHxsLpYEtSv = 0,
				VFXDiMhpNGQwyllfMvvUbdbhdZm = 1
			}

			private class JZDASbbnGIubroLCuZVJrMKsDwt
			{
				private Player GvbAEQGJJPtOgFdmijEOTtulCyiG;

				private int CijfVweIqbvViXAEzqkELDhcHIR;

				private Context JFqkyMlFVCpSBkZhstjWPjKqRLR;

				private ControllerType BUBbyESKvfplkrdvXFKZHEBGbit;

				private int LvNigBeOHUHpbkESSgiOurkLsUwi;

				private ControllerPollingInfo XysFiFAacbiJhERCEBlMbMYvTNth;

				private ModifierKeyFlags gvUmwPTqhvWmgTUEohkItzJVUmh;

				public Player player => null;

				public int actionId => 0;

				public Context mappingContext => null;

				public ControllerType controllerType => default(ControllerType);

				public int controllerId => 0;

				public ControllerPollingInfo pollingInfo => default(ControllerPollingInfo);

				public ModifierKeyFlags modifierKeyFlags => default(ModifierKeyFlags);

				public AxisRange axisRange => default(AxisRange);

				public string elementName => null;

				public void yevEaEOpxaTseresMwWwEaZGFmnj(Player P_0, Context P_1)
				{
				}

				public void DcbUeIfyTfvTrRQxceAMfGCsJNs()
				{
				}

				public ElementAssignment dlVRxOJEMdXgDrdFTiXcSnOQOks(ControllerPollingInfo P_0)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment dlVRxOJEMdXgDrdFTiXcSnOQOks(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					return default(ElementAssignment);
				}

				public ElementAssignment dlVRxOJEMdXgDrdFTiXcSnOQOks()
				{
					return default(ElementAssignment);
				}
			}

			private readonly InputMapper fMdHWLVUiLPbjetAYCnsIeSxnvw;

			private readonly Options mjXpzOGbEwHLoGQbhYNSFnRhDtH;

			private readonly JZDASbbnGIubroLCuZVJrMKsDwt GoUANvSxCrAnDtkEihNrEIJebBeg;

			private readonly Dictionary<ecNBJQYhkGvBwUjvcBsaIQKRpZzD, SafeDelegate> HaHeVeExQFDORQAIzSaXHCQkADwk;

			private readonly Dictionary<string, SafeDelegate> VmsxGFInmbITUCScQJMgRwWAXNv;

			private Status CRPQsvgaBZDwTfqmPmZyjScqzfs;

			private skSyrzZBychKEiWJvHHGuSzxPif zprqwKLWnHRXccgGCtRZFdguRih;

			private double JKFIWXfNwDQmJUJMJegUVVzUrIL;

			private bool vyEgtYaZmgYgHRlPRJsGvUVCdhJ;

			private List<Player> bpeWaTTFRlqefSpjghFuvOKQMwu;

			private readonly List<ControllerPollingInfo> AWbFRNBsIKkHHCDcfmaaRLqFeiBa;

			private ElementAssignment rgynFiSnBCyMwmwUcqtgpuLJxiZ;

			public Status status => default(Status);

			public float timeRemaining => 0f;

			public Context context => null;

			private bool checkTimer => false;

			public JjXsBZGeRGblfHFabJhQgxhYvnGt(InputMapper parent, Dictionary<ecNBJQYhkGvBwUjvcBsaIQKRpZzD, SafeDelegate> events)
			{
			}

			~JjXsBZGeRGblfHFabJhQgxhYvnGt()
			{
			}

			public void vVtoVlkZiDvtMZKduOjGVNXlCRf(Context P_0, Options P_1)
			{
			}

			public void bWZyLVETsHACDpErpBGIzSbUMvF(string P_0)
			{
			}

			private void oDVbwUgIfbSDvfmIInVcyfSKnKRm(UpdateLoopType P_0)
			{
			}

			private void gsQQNqfISudCJkMbgLURooxIbprX()
			{
			}

			private void efAGZBGRXjjWFHBqhmRKYtJjrFzV()
			{
			}

			private XAiHyxcqZGoluJVsLJiLGHKNavlO FMaGhpBaQGvMEmqlrCgoMJhoBCn(out ElementAssignment P_0)
			{
				P_0 = default(ElementAssignment);
				return default(XAiHyxcqZGoluJVsLJiLGHKNavlO);
			}

			private bool NBqHzeDJtFDzDnQvSOzvMzTaUkKa(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_0 = null;
				P_1 = default(ModifierKeyFlags);
				return false;
			}

			private IEnumerable<ControllerPollingInfo> OvPGrWgXBwYntpFRrCMekJpHePOJ(out ModifierKeyFlags P_0)
			{
				P_0 = default(ModifierKeyFlags);
				return null;
			}

			private ControllerPollingInfo kInfvWuxhjAnIdAbhfjWLeSKbZu(Options P_0, out ModifierKeyFlags P_1)
			{
				P_1 = default(ModifierKeyFlags);
				return default(ControllerPollingInfo);
			}

			private static ControllerPollingInfo kInfvWuxhjAnIdAbhfjWLeSKbZu(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_1 = default(bool);
				P_2 = default(ModifierKeyFlags);
				P_3 = null;
				return default(ControllerPollingInfo);
			}

			private static bool njcEpiMtPryYvTBHWkbEyupMHii(ControllerPollingInfo P_0, Options P_1)
			{
				return false;
			}

			private static bool muxIFuXvcZsRaKPSwUGKGrSNlAJ(JZDASbbnGIubroLCuZVJrMKsDwt P_0, ControllerPollingInfo P_1, Options P_2)
			{
				return false;
			}

			private void AuKDkJFLiCWHUovQRFpGGouFpIPY()
			{
			}

			private XAiHyxcqZGoluJVsLJiLGHKNavlO CkYmkLGGzJrqzaRjCFavLOPTfYX(ElementAssignment P_0)
			{
				return default(XAiHyxcqZGoluJVsLJiLGHKNavlO);
			}

			private static bool sxCzZXOfAzTsqTFlTcYCpxWoroi(JZDASbbnGIubroLCuZVJrMKsDwt P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static bool AcGqrvsZnYcoFTQYupZnNDnGjjKb(JZDASbbnGIubroLCuZVJrMKsDwt P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return false;
			}

			private static IList<ElementAssignmentConflictInfo> bNGvFWQlNxGiiOBopjQVyYicfFs(JZDASbbnGIubroLCuZVJrMKsDwt P_0, ElementAssignment P_1, List<Player> P_2)
			{
				return null;
			}

			private static bool SpXzBXZOdafLWeNcZpNGHbIcqBN(JZDASbbnGIubroLCuZVJrMKsDwt P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				P_2 = default(ElementAssignmentConflictCheck);
				return false;
			}

			private static void wkOPusbbNSSloztyILRUAbXKnht(JZDASbbnGIubroLCuZVJrMKsDwt P_0, ElementAssignment P_1, List<Player> P_2)
			{
			}

			private void mRMjpkAOJOjTfOPZJrZrooIZlxq()
			{
			}

			private void UbOmRiOGtkjiengFfGKIWYCCsRr()
			{
			}

			private bool zdSAlfLgiiqhysDIWlPHTaNvfXw(ecNBJQYhkGvBwUjvcBsaIQKRpZzD P_0)
			{
				return false;
			}

			private void IZQBRMWmLuDnDnWFYqgtEPYfgxfa<T>(ecNBJQYhkGvBwUjvcBsaIQKRpZzD P_0, T P_1)
			{
			}

			private void zHkAbOEcIYdjtCgjESIhmQilVfyd()
			{
			}

			private void fPfCEWiwRtSVjDqlmNozgJGJrUDL()
			{
			}

			private void iSMcreAuLiGUOmcQUOgHqcMzccW(ActionElementMap P_0)
			{
			}

			private void zpKAMKTkpbDAgymuIVGCJDwkpAc(string P_0)
			{
			}

			private XAiHyxcqZGoluJVsLJiLGHKNavlO WmSzWiQPQHdvaDmxIAumVOprbbu(ElementAssignment P_0)
			{
				return default(XAiHyxcqZGoluJVsLJiLGHKNavlO);
			}

			private XAiHyxcqZGoluJVsLJiLGHKNavlO emQyyWXhLDeXnBhYkticFBvzAwT(ConflictResponse P_0, ElementAssignment P_1)
			{
				return default(XAiHyxcqZGoluJVsLJiLGHKNavlO);
			}

			private XAiHyxcqZGoluJVsLJiLGHKNavlO emQyyWXhLDeXnBhYkticFBvzAwT(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				return default(XAiHyxcqZGoluJVsLJiLGHKNavlO);
			}

			private void KvacvLAhefOGtUnTmpUQhcbecqEa()
			{
			}

			private void vMgESlAvoLdRelXTkaQtdnCApzqu(string P_0)
			{
			}

			private void islTuZnItoBiLKYiRlIXNOGXNyw()
			{
			}

			private void pgXeORkztmlADeKCTgYnwPeiCimi()
			{
			}

			private void hDJmoSUPTacknZxTWKiqtBBwYuo(ElementAssignment P_0)
			{
			}

			private void IzyLXkFNPxNaVMbHGHfRzAPYaNl(ActionElementMap P_0)
			{
			}

			private void OERynTxeCMXckTJDJdSJEuxPdUeN()
			{
			}

			private void tALQVTLjvUfbHrsKUpRHCLwAfMI(string P_0)
			{
			}

			private void PYrmvWywGwPaXxDHPCnRKKKActSX(string P_0)
			{
			}

			private void RIkUpeDJSZDLDdHsWfQlaSdDJRND(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
			}

			private void jYVmoGmlbccOJBJUCbQsNFidGgQE()
			{
			}

			private void gaNGCXaByAQcHwlKuBkhTyBRHBJT()
			{
			}

			public void VipomZTmCLEWyOEyJijRzmFEakK(ConflictResponse P_0)
			{
			}
		}

		public class Options
		{
			internal const string wntjSqqFPgYywiBufrjEUkhKyQB = "isElementAllowed";

			private bool TQqwhOnlbcaTYrxtmgcHPIYWhdx;

			private bool BKtNzRaZRqqUNSPIUcVCrlxQSPI;

			private bool NrmstwrNWvWslwFLFmBrhPxNhah;

			private float aFmcrzdDYXvHjqvrRhJAvFCuUSyh;

			private bool LaDVTUYESVGDpJYXPoijEvkiDpzI;

			private bool zJtFsVeUjABGNZFdiUFWwgeEGFGe;

			private bool jDtaiocTyFLBIuWCyKvDzkQMVKV;

			private bool ncjhYMeWclionfqYzMxtTTGidVuN;

			private int[] lXnnQCjzyJItQoaSCwLDPlPhbKu;

			private ConflictResponse PpdvCGatshiCslFrzxFruGdeBgu;

			private bool UtHkYXPwyBKCMoOirtElysULJDe;

			private bool qQFcuzkWNWgIHItcxDurzgqiZwX;

			private bool qudmaGBBacQjJGpexGyWUfZFVQu;

			private bool fzFxXLcadQiKGALUGFUhaYraMXEK;

			private float SKwHgsVkVxddMbYybtgqIGeHnvo;

			private readonly Dictionary<string, SafeDelegate> VmsxGFInmbITUCScQJMgRwWAXNv;

			[CompilerGenerated]
			private static Action<Exception> mFdLrpTjFrbjhiGOkTWGqqfRHIv;

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

			internal T ZtigQqQcaLsojOCvJhZzbCKRqtE<T>(string P_0) where T : SafeDelegate
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

			internal void DcbUeIfyTfvTrRQxceAMfGCsJNs()
			{
			}

			public static void Copy(Options source, Options destination)
			{
			}

			[CompilerGenerated]
			private static void ngIStueBuXxUmePSYMKCpZDlGut(Exception P_0)
			{
			}
		}

		private static InputMapper zDUAuxExcfohrNlfXRqZQKTFXfx;

		private static int SzUVaXapAemIfUlDrJMQJsMIzke;

		private readonly int nneglgdKLsFnhAdzQnzQjgsSIRl;

		private readonly bool liJXaJxcxSxhXxJSFmJpiLyiMdv;

		private readonly JjXsBZGeRGblfHFabJhQgxhYvnGt hdhcynIFdOBaDoFlfynnGnoJTjo;

		private Options mjXpzOGbEwHLoGQbhYNSFnRhDtH;

		private readonly Dictionary<ecNBJQYhkGvBwUjvcBsaIQKRpZzD, SafeDelegate> HaHeVeExQFDORQAIzSaXHCQkADwk;

		[CompilerGenerated]
		private static Action<Exception> QbTWSsdAKxorjsknrQStbTEoKGd;

		[CompilerGenerated]
		private static Action<Exception> qIGnrhTPJCWEEwzuwGfXKXIOiQh;

		[CompilerGenerated]
		private static Action<Exception> JOzBGmoHQZjiBVPTbLdxdlcDKtX;

		[CompilerGenerated]
		private static Action<Exception> awpkufMDcpprqtGkXvItnJTqqFy;

		[CompilerGenerated]
		private static Action<Exception> YsFbdJGPxNqaevsGkQMuEdZEUtT;

		[CompilerGenerated]
		private static Action<Exception> doGELBXViVaXchtFTeIwBzQPojtT;

		[CompilerGenerated]
		private static Action<Exception> yDzoGfvMKPbXkBhBQXhpbGDROSiM;

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

		private static int ITeGKirVggiNPCZDMAbsAWTZBqJ()
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

		internal void NzVTiTSXBjPeWJdyIejztDTladR(object P_0)
		{
		}

		internal void pnakawmyrXoMdmCabBphiRLncbSI()
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

		private bool vVtoVlkZiDvtMZKduOjGVNXlCRf(Context P_0, Options P_1)
		{
			return false;
		}

		[CompilerGenerated]
		private static void DkTGPbsJnRZIqIhEWlSuAGpwbCuH(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void gszDNAjqifGmfjOxMdsljKGQZLx(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void ThPcutahRslXbBrPcKRDITmGkhbH(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void oNYIBnlZPMzlBIlpZPePKfBwepa(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void GjgeNUeVddjWMVRnTfdNTkExNsLN(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void MFGMuyMlJAgwIfBBvSyDoBRqhknp(Exception P_0)
		{
		}

		[CompilerGenerated]
		private static void EiBtHFcESvNjdRSOEEFMfvNINQC(Exception P_0)
		{
		}
	}
}
