using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class ChemicalStateCondition : NimbatusCondition
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		public List<EChemicalState> AllowedStates = new List<EChemicalState>();

		protected override void OnInit()
		{
			HealthPool = HealthPool ?? OwnWorldObject.HealthPool;
		}

		public override bool IsTrue()
		{
			return AllowedStates.Contains(HealthPool.CurrentState);
		}
	}
}
