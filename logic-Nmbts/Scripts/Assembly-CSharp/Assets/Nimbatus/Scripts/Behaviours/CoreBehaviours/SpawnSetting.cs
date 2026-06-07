using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public struct SpawnSetting
	{
		public InteractiveWorldObject ObjectToSpawn;

		public int MaxActive;

		public bool ContinuousBursts;

		[ShowIf("ContinuousBursts", true)]
		[Indent(1)]
		public int BurstSize;

		[ShowIf("ContinuousBursts", true)]
		[Indent(1)]
		public float BurstInterval;

		[ShowIf("ContinuousBursts", true)]
		[Indent(1)]
		public float CooldownMultiplier;

		public bool HasSpawnLimit;

		[ShowIf("HasSpawnLimit", true)]
		[Indent(1)]
		public int SpawnLimit;
	}
}
