using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Prop))]
	[RequireComponent(typeof(Inventory))]
	public class GameItemProcess : AttachedBehaviour
	{
		public static HashSet<GameItemProcess> AllGameItemProcesses;

		public string sourceType;

		public string targetType;

		public string[] worksInSchedules;

		public int maxAmount;

		public bool worksInBatches;

		public bool needsActor;

		public string skill;

		public string verb;

		public bool endProduct;

		public float duration;

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		private void GameItemProcess_UsageFinished(object sender, UsageEventArgs e)
		{
		}
	}
}
