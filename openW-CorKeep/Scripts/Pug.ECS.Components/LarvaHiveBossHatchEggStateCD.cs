using Pug.UnityExtensions;
using Unity.Entities;

public struct LarvaHiveBossHatchEggStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple eggCooldownTimer;
}
