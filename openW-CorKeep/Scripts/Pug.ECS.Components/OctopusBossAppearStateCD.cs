using Pug.UnityExtensions;
using Unity.Entities;

public struct OctopusBossAppearStateCD : IComponentData, IQueryTypeParameter
{
	public int internalState;

	public float appearDuration;

	public ThreadSafeTimerSimple timer;
}
