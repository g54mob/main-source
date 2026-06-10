using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class HumanPreset : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<NPCItemGroup> itemGroups;

		[SerializeField]
		private List<NPCSkillGroup> skillGroups;

		public List<NPCItemGroup> ItemGroups => itemGroups;

		public List<NPCSkillGroup> SkillGroups => skillGroups;

		public override string GetID()
		{
			return id;
		}
	}
}
