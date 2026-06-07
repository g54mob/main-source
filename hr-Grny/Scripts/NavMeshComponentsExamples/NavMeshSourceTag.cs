using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DefaultExecutionOrder(-200)]
public class NavMeshSourceTag : MonoBehaviour
{
	public static List<MeshFilter> m_Meshes;

	public static List<Terrain> m_Terrains;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public static void Collect(ref List<NavMeshBuildSource> sources)
	{
	}
}
