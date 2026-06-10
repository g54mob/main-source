using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class GoalPreference : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string[] formerIds;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private string[] relatedGoals;

		[SerializeField]
		private JobType relatedJobs;

		[SerializeField]
		private SkillType relatedSkill;

		public override string[] FormerIDs => formerIds;

		public LocKeys[] LocKeys => locKeys;

		public JobType RelatedJobs => relatedJobs;

		public SkillType RelatedSkill => relatedSkill;

		public override string GetID()
		{
			return id;
		}

		public bool IsRelatedToJob(JobType jobType)
		{
			return relatedJobs.HasFlag(jobType);
		}

		public bool IsRelatedToSkill(SkillType skillType)
		{
			return relatedSkill == skillType;
		}

		public bool IsRelatedToGoal(string goalId)
		{
			string[] array = relatedGoals;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == goalId)
				{
					return true;
				}
			}
			return false;
		}

		public JobType[] GetRelatedJobs()
		{
			List<JobType> list = new List<JobType>();
			JobType[] allJobTypes = EnumValues.AllJobTypes;
			foreach (JobType jobType in allJobTypes)
			{
				if ((relatedJobs & jobType) != JobType.None)
				{
					list.Add(jobType);
				}
			}
			return list.ToArray();
		}
	}
}
