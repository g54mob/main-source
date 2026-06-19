using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

internal struct ProceduralTerrainDataCD : IComponentData, IQueryTypeParameter
{
	public int2 Position;

	public int2 Size;

	public Entity SubMapEntity;

	public NativeArray<Color32> Data;
}
