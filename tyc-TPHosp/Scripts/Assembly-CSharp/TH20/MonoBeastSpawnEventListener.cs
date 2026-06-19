using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MonoBeastSpawnEventListener : MonoBehaviour
	{
		public Patient Owner { private get; set; }

		protected void SpawnBeast(AnimationEvent animationEvent)
		{
			if (Owner != null && Owner.RoomUsing != null && Owner.RoomUsing.Definition.IsHospitalOrBay && DebugVars.EnableMonoBeasts.Value)
			{
				Owner.Level.MonoBeastManager.SpawnBeast(Owner.Position, Owner.RotationY, Owner.RoomUsing);
			}
		}
	}
}
