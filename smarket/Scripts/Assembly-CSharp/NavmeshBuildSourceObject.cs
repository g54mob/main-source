using UnityEngine;
using UnityEngine.AI;

public class NavmeshBuildSourceObject : MonoBehaviour
{
	public int Index;

	[SerializeField]
	private Vector3 m_Size;

	[SerializeField]
	private Vector3 m_Offset;

	[SerializeField]
	private NavMeshBuildSourceShape m_Shape;

	[SerializeField]
	private MeshFilter m_MeshSource;

	[SerializeField]
	private int m_Area;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public NavMeshBuildSource GetSource()
	{
		return default(NavMeshBuildSource);
	}
}
