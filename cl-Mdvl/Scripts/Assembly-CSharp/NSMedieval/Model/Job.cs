using System;
using NSEipix.Base;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class Job : NSEipix.Base.Model
	{
		[SerializeField]
		private JobType id;

		[SerializeField]
		private string[] goals;

		[SerializeField]
		private SkillType relatedSkill;

		[SerializeField]
		private LocKeys[] locKeys;

		public JobType JobType => id;

		public string[] Goals => goals;

		public SkillType RelatedSkill => relatedSkill;

		public LocKeys[] LocKeys => locKeys;

		public override string GetID()
		{
			return id.ToString();
		}
	}
}
