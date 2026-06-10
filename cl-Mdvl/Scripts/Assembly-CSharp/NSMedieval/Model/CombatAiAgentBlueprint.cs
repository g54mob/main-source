using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class CombatAiAgentBlueprint : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string description;

		[SerializeField]
		private string[] goals;

		[SerializeField]
		private string[] sensors;

		[SerializeField]
		private string[] reactions;

		[SerializeField]
		private bool isAggressive;

		public bool IsAggressive => isAggressive;

		public string Description => description;

		public string[] Goals => goals;

		public string[] Sensors => sensors;

		public string[] Reactions => reactions;

		public override string GetID()
		{
			return id;
		}
	}
}
