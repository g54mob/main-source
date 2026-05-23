using System.Collections.Generic;
using UnityEngine;

public class MeshListAsset : ScriptableObject
{
	public List<Mesh> meshes;

	public void OnEnable()
	{
		if (meshes == null)
		{
			meshes = new List<Mesh>();
		}
	}
}
