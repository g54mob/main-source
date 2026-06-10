using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class NPCSkillGroup
	{
		[SerializeField]
		private string groupName;

		[SerializeField]
		private List<WorkerSkill> skills;

		[SerializeField]
		private bool canBeNone;

		public string GroupName => groupName;

		public List<WorkerSkill> Skills => skills;

		public bool CanBeNone => canBeNone;
	}
}
