using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DefaultExecutionOrder(-100)]
public class NavmeshBuildRegistry : MonoBehaviour
{
	private NavMeshData m_NavmeshData;

	private Bounds m_LocalBounds;

	private List<NavmeshBuildSourceObject> m_SourceObjects;

	private List<NavMeshBuildSource> m_Sources;

	private bool m_IsQuitting;

	public static NavmeshBuildRegistry Instance { get; private set; }

	public NavMeshData NavmeshData => null;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void Initialize()
	{
	}

	private void Awake()
	{
	}

	public void SetBounds(Bounds bounds)
	{
	}

	private void OnApplicationQuit()
	{
	}

	public void Clear()
	{
	}

	public void Register(NavmeshBuildSourceObject obj)
	{
	}

	public void Unregister(NavmeshBuildSourceObject obj)
	{
	}

	public void UpdateSource(NavmeshBuildSourceObject obj)
	{
	}

	public void Rebuild()
	{
	}

	public AsyncOperation RebuildAsync()
	{
		return null;
	}
}
