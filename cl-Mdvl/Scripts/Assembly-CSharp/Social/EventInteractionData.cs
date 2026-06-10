using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval;
using UnityEngine;

namespace Social
{
	[Serializable]
	public class EventInteractionData : Model
	{
		[NonSerialized]
		private static float devChanceToFire;

		[SerializeField]
		private string id;

		[SerializeField]
		private EventInteractionType eventInteractionType;

		[SerializeField]
		private float chanceToFire;

		[SerializeField]
		private List<WeightedOutcome> weightedOutcomes;

		public float ChanceToFire
		{
			get
			{
				if (!(devChanceToFire > 0f))
				{
					return chanceToFire;
				}
				return devChanceToFire;
			}
		}

		public EventInteractionType InteractionType => eventInteractionType;

		public List<WeightedOutcome> WeightedOutcomes => weightedOutcomes;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			devChanceToFire = 0f;
		}

		public override string GetID()
		{
			return id;
		}

		public static void SetDevChanceToFire(float value)
		{
			devChanceToFire = value;
		}
	}
}
