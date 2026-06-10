using System;
using NSEipix.Base;
using NSMedieval.State.WorkerJobs;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class GoalPreferenceLevelData : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private GoalPreferenceLevel goalPreferenceLevel;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private float relatedSkillMultiplier;

		[SerializeField]
		private string[] effectors;

		public GoalPreferenceLevel PreferenceLevel
		{
			get
			{
				if (goalPreferenceLevel != GoalPreferenceLevel.None)
				{
					return goalPreferenceLevel;
				}
				return GoalPreferenceLevel.Resentful;
			}
		}

		public LocKeys[] LocKeys => locKeys;

		public float RelatedSkillMultiplier => relatedSkillMultiplier;

		public string[] Effectors => effectors ?? (effectors = Array.Empty<string>());

		public override string GetID()
		{
			return id;
		}
	}
}
