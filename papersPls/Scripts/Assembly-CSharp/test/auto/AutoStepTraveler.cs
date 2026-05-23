using data;
using haxe.lang;
using play.day;

namespace test.auto
{
	public class AutoStepTraveler : Enum
	{
		public static readonly AutoStepTraveler Cleanup;

		public static readonly AutoStepTraveler WaitForBoothWorking;

		public static readonly AutoStepTraveler ApplyActionOrInterrogation;

		public static readonly AutoStepTraveler ApplyNextManualStep;

		public static readonly AutoStepTraveler Interrogate;

		public static readonly AutoStepTraveler UnfloatAllPossible;

		public static readonly AutoStepTraveler GiveAllPossible;

		public static readonly AutoStepTraveler ApplyPoison;

		public static readonly AutoStepTraveler DetainIfPossible;

		public static readonly AutoStepTraveler ExploreAllPapers;

		public static readonly AutoStepTraveler ConfiscatePassport;

		public static readonly AutoStepTraveler ConfiscatePassport_PutInFiler;

		public static readonly AutoStepTraveler BusyWithBorder;

		public static readonly AutoStepTraveler FinishEmptyBooth;

		protected static readonly string[] __hx_constructs;

		protected AutoStepTraveler(int index)
			: base(0)
		{
		}

		public static AutoStepTraveler Basic(AutoStepBasic basicStep)
		{
			return null;
		}

		public static AutoStepTraveler Interrogate_InspectErrors(object errorPair)
		{
			return null;
		}

		public static AutoStepTraveler Correlate(object factPathPair)
		{
			return null;
		}

		public static AutoStepTraveler Correlate_InspectFacts(object factPathPair)
		{
			return null;
		}

		public static AutoStepTraveler InterrogateOrCorrelate(object factPathPair)
		{
			return null;
		}

		public static AutoStepTraveler StampAllPossible(StampApprovalKind approvalKind)
		{
			return null;
		}

		public static AutoStepTraveler StampSequence(string deskItemId, StampApprovalKind approvalKind)
		{
			return null;
		}

		public static AutoStepTraveler StampSequence_ToggleStampBar(bool open)
		{
			return null;
		}

		public static AutoStepTraveler StampSequence_MoveDeskItemUnderStamp(string deskItemId, StampApprovalKind approvalKind)
		{
			return null;
		}

		public static AutoStepTraveler StampSequence_ClickStamp(StampApprovalKind approvalKind)
		{
			return null;
		}

		public static AutoStepTraveler ClickEngineAction(EngineAction engineAction)
		{
			return null;
		}

		public static AutoStepTraveler CarouselSetFocus(string deskItemId)
		{
			return null;
		}

		public static AutoStepTraveler Give(string deskItemId)
		{
			return null;
		}

		public static AutoStepTraveler WaitForDeskItemToAppear(string deskItemId)
		{
			return null;
		}

		public static AutoStepTraveler ConfiscatePassport_ToggleFiler(bool open)
		{
			return null;
		}

		public static AutoStepTraveler SnipeEnemies(bool tranq)
		{
			return null;
		}
	}
}
