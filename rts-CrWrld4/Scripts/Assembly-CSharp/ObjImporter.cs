using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ObjImporter
{
	public SplitMode SplitMode;

	internal List<Vector3> Vertices;

	internal List<Vector3> Normals;

	internal List<Vector2> UVs;

	public GameObject Load(Stream input)
	{
		return null;
	}
}
