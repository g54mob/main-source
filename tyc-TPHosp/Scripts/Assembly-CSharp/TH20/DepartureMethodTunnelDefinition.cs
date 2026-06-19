using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DepartureMethodTunnelDefinition : DepartureMethodDefinition
	{
		public RuntimeAnimatorController CharacterAnimGraph;

		public override DepartureMethod Create(Character character, IDepartedCallback callback)
		{
			return new DepartureMethodTunnel(this, character, callback);
		}

		public override bool IsAvailable()
		{
			return DepartureTunnelComponent.RandomTunnel() != null;
		}
	}
}
