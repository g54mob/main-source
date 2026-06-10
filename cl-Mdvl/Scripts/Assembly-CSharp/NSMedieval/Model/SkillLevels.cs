using System;
using NSEipix.Base;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class SkillLevels : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private SkillType skillId;

		[SerializeField]
		private float[] levels;

		public SkillType SkillId => skillId;

		public float[] Levels => levels;

		public override string GetID()
		{
			if (string.IsNullOrEmpty(id))
			{
				id = skillId.ToString();
			}
			return id;
		}
	}
}
