using Unity.Entities;
using UnityEngine;

public struct ActAsLightSourceWhenHeldInHandCD : IComponentData, IQueryTypeParameter
{
	public Color color;

	public int range;
}
