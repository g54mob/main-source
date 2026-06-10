using System;
using UnityEngine;

namespace NSMedieval.GlobalStats
{
	[Serializable]
	public class GlobalStatTrigger
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private float value;

		[SerializeField]
		private string offerObjective;

		[SerializeField]
		private string showBbt;

		[SerializeField]
		private bool startShowing;

		[SerializeField]
		private bool skipAcceptButton;

		[SerializeField]
		private string startEvent;

		[SerializeField]
		private string unlockAchievementOnTrigger;

		public string ID => id;

		public float Value => value;

		public string OfferObjective => offerObjective;

		public bool StartShowing => startShowing;

		public string StartEvent => startEvent;

		public string UnlockAchievementOnTrigger => unlockAchievementOnTrigger;

		public string ShowBbt => showBbt;

		public bool SkipAcceptButton => skipAcceptButton;
	}
}
