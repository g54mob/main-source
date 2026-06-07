using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	[Serializable]
	[Flags]
	public enum EGrapplingHookTarget
	{
		None = 0,
		Terrain = 1,
		Obstacles = 2,
		CollectableObjects = 4,
		Enemies = 8,
		EnemyStructures = 0x10,
		OwnDrone = 0x20,
		NimbatusContainer = 0x40
	}
}
