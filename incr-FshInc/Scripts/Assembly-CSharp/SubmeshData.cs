using System;
using System.Collections.Generic;

[Serializable]
public class SubmeshData
{
	public SharedMaterialData sharedMaterialData;

	public List<int> tris = new List<int>();

	public SubmeshData(SharedMaterialData data)
	{
		sharedMaterialData = data;
	}
}
