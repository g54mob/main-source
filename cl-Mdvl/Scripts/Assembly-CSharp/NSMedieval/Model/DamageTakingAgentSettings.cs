using System;
using NSEipix.Base;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class DamageTakingAgentSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private DamageTakingAgentType id;

		[SerializeField]
		private string[] onDamageTakenEffectors;

		[SerializeField]
		private bool absoluteHitChance;

		[SerializeField]
		private float accidentallyHitChance;

		public DamageTakingAgentType AgentType => id;

		public string[] OnDamageTakenEffectors => onDamageTakenEffectors;

		public bool AbsoluteHitChance => absoluteHitChance;

		public float AccidentallyHitChance => accidentallyHitChance;

		public override string GetID()
		{
			return id.ToString();
		}
	}
}
