using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class BackgroundCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		private DrifterAttributesEffect _background;

		[SerializeField]
		[Tooltip("Is the condition met when the background is in the 'Player' community (false) or when it is not in the 'Player' community (true)")]
		private bool _notInPlayerCommunity;

		public bool IsMet()
		{
			foreach (Agent agent in Community.PlayerCommunity.Agents)
			{
				if ((agent.IsAlive && agent.Descriptor.PresentBackground == _background) || agent.Descriptor.PastBackground == _background)
				{
					return !_notInPlayerCommunity;
				}
			}
			return _notInPlayerCommunity;
		}
	}
}
