using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	[Serializable]
	[Flags]
	public enum ESensorDetectionType
	{
		None = 0,
		Enemies = 1,
		EnemyStructures = 2,
		Terrain = 4,
		Obstacles = 8,
		CollectableObject = 0x10,
		OwnDrone = 0x20,
		DangerZone = 0x40,
		AccelerationPad = 0x80,
		DecelerationPad = 0x100,
		Resources = 0x200,
		Projectiles = 0x400,
		MissionTarget = 0x800,
		NimbatusContainer = 0x1000,
		SumoBorder = 0x48,
		AllObstacles = 0x4D
	}
}
