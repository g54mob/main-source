using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class SkillTag : NSEipix.Base.Model
	{
		[SerializeField]
		private SkillType id;

		[SerializeField]
		private List<ActionTagType> tags;

		public SkillType Id => id;

		public List<ActionTagType> Tags => tags;

		public override string GetID()
		{
			return id.ToString();
		}
	}
}
