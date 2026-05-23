#define ENABLE_DEBUG_LOGS
using NaughtyAttributes;
using UnityEngine;
using Utils;

public class VertexCounter : MonoBehaviour
{
	[Button(null, EButtonEnableMode.Always)]
	public void Count()
	{
		int num = 0;
		MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			if ((bool)meshFilter.sharedMesh)
			{
				num += meshFilter.sharedMesh.vertices.Length;
			}
		}
		this.Log($"Counted Vertices: {num}", "Count", 18);
	}
}
