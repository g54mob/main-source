using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

public struct WaterSpreaderCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple timer;

	public int2 position;
}
