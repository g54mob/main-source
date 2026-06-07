using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class BuildableCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		private BuildableProperties _buildableProperties;

		public bool IsMet()
		{
			return Community.PlayerCommunity.ReturnHasBuildable(_buildableProperties);
		}
	}
}
