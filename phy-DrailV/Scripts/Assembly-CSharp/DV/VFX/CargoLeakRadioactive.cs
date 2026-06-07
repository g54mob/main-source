using UnityEngine;

namespace DV.VFX
{
	public class CargoLeakRadioactive : CargoLeakBase
	{
		protected override void CalculateLeakedMass()
		{
			cargoMassLeaked = 0f;
		}

		protected override void SetupLeakColliders(GameObject colliderParentGO)
		{
		}

		protected override void ResetLeakColliders()
		{
		}

		protected override void ManageColliders()
		{
		}
	}
}
