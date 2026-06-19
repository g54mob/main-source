using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct SnakeBossCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int internalState;

	public float appearTimer;

	public BlobAssetReference<Collider> collider;

	public ThreadSafeTimerSimple goingToPlayerCooldownTimer;

	public Entity targetPlayerEntity;

	public float3 targetPointAroundPlayer;

	public float3 startPointWhenMovingToPlayer;

	public int pointsAroundPlayerCount;

	public int amountOfSegmentsRemainingToEnrage;

	[GhostField]
	public float projectileCooldownTimer;

	[GhostField]
	public bool isAboveWater;

	public float defeatSoundEffectDelay;

	public bool hasPlayedDefeatSoundEffect;
}
