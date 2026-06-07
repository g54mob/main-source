using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class AutocompleteCheckListItemClickRequirementNode : CheckListItemClickRequirementNode
	{
		private static float _lastTick;

		[Range(0f, 60f)]
		public float autoCompleteInMinutes;

		public string playerPrefsKey;

		[Tooltip("If additional time >0, the ThanksForPlayingDialog will show when timer expires.")]
		public float additionalTimeMinutes;

		private string TimeoutRemainingKey => null;

		private string IsAutoCompletedKey => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void UpdateCountdown(float deltaSeconds, ActiveStory story)
		{
		}

		private float GetTimeOutRemainingInMinutesF(ActiveStory story)
		{
			return 0f;
		}

		public override string GetLabelPostfixKey(ActiveStory story)
		{
			return null;
		}

		private string GetTimeoutLabelKey(ActiveStory story)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		protected void AddAdditionalTime(ActiveStory story)
		{
		}
	}
}
