using System.Text;
using UnityEngine;
using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.Config
{
	[InitializeOnGameStarted]
	public class PatronNeedConfigNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		public string needType;

		[Tooltip("If set to true, this need may randomly see increased needs from time to time.")]
		public bool enableRandomNeedIncreases;

		[Tooltip("if true, this is a need that should be on all pawns - used to keep only essential needs when generating some story patrons")]
		public bool isBasicNeed;

		public bool vipOnly;

		public bool enableReputationCheck;

		[DropDownChoice(typeof(StoryHelper), "GetNamedDayCurves")]
		public string dayPatternPreset;

		[Tooltip("The max percentage of patrons who will get this need adjusted by the dayPattern")]
		public int maxPercentage;

		[Tooltip("The max percentage of patrons who will get this need adjusted by the dayPattern if the need is used as an impromptu need")]
		public int impromputMaxPercentage;

		public int minTier;

		public int maxTier;

		[Tooltip("When specified, this is the percentage of patrons who already get this need that will have it marked as 'optional' instead of required, meaning they visit the tavern, even if the need cannot me met.")]
		public int[] optionalNeedPercentagePerTier;

		[Header("Minimum Attendance")]
		[Tooltip("The minimum number of visitors (if they exist) and respecting min/maxTier that should have this need without reputation gates.")]
		public int[] minimumAttendancePerTier;

		[Tooltip("Use sparingly, this will set all other needs to optional when calculating minimum attendance")]
		public bool setAllOtherNeedsToOptionalForMinimumAttendance;

		[Header("OverrideNodes")]
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection racePercentageOverrides;

		private static string _notEnoughReputationReasonKey;

		private const string _reputationCurveName = "ReputationDistribution";

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Actor_ActorSpawned(object sender, EventArgs<Actor> e)
		{
		}

		protected virtual void OnPatronSpawned(Patron patron, PatronNeedData needData)
		{
		}

		public AnimationCurve GetEffectiveDayPattern()
		{
			return null;
		}

		public bool ShouldAddToPatron(string race, int tier, int hourOfDay, bool onlyImpromptuNeeds = false)
		{
			return false;
		}

		private bool CanTavernSatisfyNeed(out string reasonKey)
		{
			reasonKey = null;
			return false;
		}

		protected virtual bool IsNeedMet(PatronPopulationData pawn, PatronNeedData needData, out string reasonKey, bool ignoreSecondaryNeeds = false)
		{
			reasonKey = null;
			return false;
		}

		public bool WillVisit(PatronPopulationData pawn, PatronNeedData needData, out string reasonKey, bool ignoreIsOptionalSettingOnNeeds = false)
		{
			reasonKey = null;
			return false;
		}

		public TooltipData GetToolTip(PatronPopulationData pawn, PatronNeedData needData)
		{
			return null;
		}

		public virtual string GetNeedTitleKey(int patronTier)
		{
			return null;
		}

		public void AppendSecondaryNeedTooltipInfo(StringBuilder sb, PatronNeedData needData, out bool shownAReason)
		{
			shownAReason = default(bool);
		}

		private (int, TooltipData) GetEffectiveReputation(PatronPopulationData pawn, PatronNeedData needData, bool createTooltip = false)
		{
			return default((int, TooltipData));
		}

		private int GetTargetReputation(PatronPopulationData pawn)
		{
			return 0;
		}

		internal virtual PatronNeedData CreatePatronNeedData(PatronPopulationData pawn)
		{
			return null;
		}

		public virtual void AddSecondaryNeeds(PatronPopulationData pawn, PatronNeedData data, bool tryForceSecondaryNeed)
		{
		}
	}
}
