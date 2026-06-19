using BehaviorDesigner.Runtime;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InteractionFilterWithinRadius : InteractionFilter
	{
		[SerializeField]
		private float _radius;

		[SerializeField]
		private SharedVector3 _position;

		public override bool IsValid(ObjectInteraction interaction, Character character)
		{
			Vector3 a = (_position.IsShared ? _position.Value : character.Position);
			if (_enabled)
			{
				if (character != null)
				{
					return Vector3.Distance(a, interaction.WorldStartPosition) <= _radius;
				}
				return false;
			}
			return true;
		}
	}
}
