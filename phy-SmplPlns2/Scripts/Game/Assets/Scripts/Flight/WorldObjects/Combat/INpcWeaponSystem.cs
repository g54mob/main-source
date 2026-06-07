using Assets.Scripts.Flight.Combat;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public interface INpcWeaponSystem
	{
		bool IsDisabled { get; }

		Vector3 Position { get; }

		void Arm();

		void Disable();

		void InitializeTargetingSystem(NpcTargetingSystem targetingSystem);
	}
}
