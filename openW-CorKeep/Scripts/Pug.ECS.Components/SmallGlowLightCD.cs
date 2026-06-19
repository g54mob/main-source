using Unity.Entities;
using UnityEngine;

public struct SmallGlowLightCD : IComponentData, IQueryTypeParameter
{
	public Color color;

	public float intensity;
}
