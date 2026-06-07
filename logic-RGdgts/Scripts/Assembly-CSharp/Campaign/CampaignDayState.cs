using System;
using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.StateMachines;

namespace Campaign
{
	public class CampaignDayState : FSMState
	{
		[Serializable]
		public class Configuration
		{
			public List<GameplayInteraction> lockInteractions;

			public List<GameplayInteraction> unlockInteractions;

			public List<CampaignAction> actions;
		}

		public Configuration configuration;

		private int currentActionIndex;

		public override void OnValidate(Graph assignedGraph)
		{
		}

		protected override void OnEnter()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnExit()
		{
		}

		protected override void OnPause()
		{
		}

		private void StartAction(int actionIndex)
		{
		}
	}
}
