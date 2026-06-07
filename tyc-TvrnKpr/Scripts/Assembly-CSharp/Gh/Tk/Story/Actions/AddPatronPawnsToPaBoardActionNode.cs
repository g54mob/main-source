using Gh.Tk.Story.Config;
using UnityEngine;
using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.Actions
{
	[InitializeOnGameStarted]
	public class AddPatronPawnsToPaBoardActionNode : ConnectedStoryNode, IAddPatronsPawnsConfig
	{
		[Tooltip("if -1, it's indefinite")]
		public int daysToBeActive;

		public int perDayChance;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection modifyPatrons;

		private const int _daysToAddInAdvance = 2;

		[field: SerializeField]
		[field: Range(1f, 5f)]
		[field: Header("Add patrons Config")]
		public int minTier { get; set; }

		[field: SerializeField]
		[field: Range(1f, 5f)]
		public int maxTier { get; set; }

		[field: SerializeField]
		public int amountPerTier { get; set; }

		[field: SerializeField]
		public int amountPerTierMargin { get; set; }

		[field: SerializeField]
		[field: Range(0f, 24f)]
		public int targetHour { get; set; }

		[field: SerializeField]
		public int targetHourMargin { get; set; }

		[field: SerializeField]
		public int hourSpread { get; set; }

		private string TargetDayKey => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void AddPawnsForDay(int dayOffset = 0)
		{
		}

		private void OnDayChanged(ActiveStory story)
		{
		}
	}
}
