using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct EnrageStateCD : IComponentData, IQueryTypeParameter
{
	public enum InternalState
	{
		Init = 0,
		PlayingAnimation = 1
	}

	[GhostField]
	public bool isEnraged;

	public InternalState internalState;

	public ThreadSafeTimerSimple timer;
}
