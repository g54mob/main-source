using System;
using Factory;
using Factory.Pools;
using UnityEngine;

[System.Serializable]
[Factory.Serializable(1)]
public class RoadTileMesh : IReusable
{
	[Serialize(true, typeof(MeshSerializer))]
	public Mesh roadMesh;

	[Serialize(true, typeof(MeshSerializer))]
	public Mesh outlineMesh;

	[Serialize(true, typeof(MeshSerializer))]
	public Mesh dashedOutlineMesh;

	public void Reset()
	{
		roadMesh = null;
		outlineMesh = null;
		dashedOutlineMesh = null;
	}

	public void ApplyMeshOverrides(RoadTileMesh overrides)
	{
		if (overrides.roadMesh != null)
		{
			roadMesh = overrides.roadMesh;
		}
		if (overrides.outlineMesh != null)
		{
			outlineMesh = overrides.outlineMesh;
		}
		if (overrides.dashedOutlineMesh != null)
		{
			dashedOutlineMesh = overrides.dashedOutlineMesh;
		}
	}
}
