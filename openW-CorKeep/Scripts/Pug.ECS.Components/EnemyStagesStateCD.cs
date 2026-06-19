using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct EnemyStagesStateCD : IComponentData, IQueryTypeParameter
{
	public enum InternalState
	{
		Init = 0,
		PlayingAnimation = 1
	}

	public InternalState internalState;

	[GhostField]
	public int currentStage;

	[GhostField]
	public int maxStages;

	public ThreadSafeTimerSimple timer;

	public float lowestMultiplier;

	private const float DefaultMinMultiplier = 0.3f;

	private const float DefaultMaxMultiplier = 1f;

	public int GetCurrentStage(float normalizedHealth)
	{
		if (maxStages <= 1)
		{
			return 0;
		}
		float num = 1f / (float)maxStages;
		normalizedHealth = math.max(0.001f, normalizedHealth);
		return math.clamp((int)(normalizedHealth / num), 0, maxStages - 1);
	}

	public readonly float GetMultiplierDecreasingAsHealthDecreases()
	{
		if (maxStages <= 1)
		{
			return 1f;
		}
		float t = (float)currentStage / (float)(maxStages - 1);
		return math.lerp((lowestMultiplier == 0f) ? 0.3f : lowestMultiplier, 1f, t);
	}
}
