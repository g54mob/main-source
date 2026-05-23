using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Tools
{
	[CreateAssetMenu(fileName = "AchievementList", menuName = "MoreMountains/Achievement List")]
	public class MMAchievementList : ScriptableObject
	{
		public string AchievementsListID = "AchievementsList";

		public List<MMAchievement> Achievements;

		private MMReferenceHolder<MMAchievementList> _instances;

		public static MMAchievementList Any => MMReferenceHolder<MMAchievementList>.Any;

		public virtual void ResetAchievements()
		{
			Debug.LogFormat("Reset Achievements");
			MMAchievementManager.ResetAchievements(AchievementsListID);
		}

		protected virtual void OnEnable()
		{
			_instances.Reference(this);
		}

		protected virtual void OnDisable()
		{
			_instances.Dispose();
		}
	}
}
