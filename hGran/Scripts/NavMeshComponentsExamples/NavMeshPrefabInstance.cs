using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[ExecuteInEditMode]
[DefaultExecutionOrder(-102)]
public class NavMeshPrefabInstance : MonoBehaviour
{
	[SerializeField]
	private NavMeshData m_NavMesh;

	[SerializeField]
	private bool m_FollowTransform;

	private NavMeshDataInstance m_Instance;

	private static readonly List<NavMeshPrefabInstance> s_TrackedInstances;

	private Vector3 m_Position;

	private Quaternion m_Rotation;

	public NavMeshData navMeshData
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool followTransform
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static List<NavMeshPrefabInstance> trackedInstances => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void UpdateInstance()
	{
	}

	private void AddInstance()
	{
	}

	private void AddTracking()
	{
	}

	private void RemoveTracking()
	{
	}

	private void SetFollowTransform(bool value)
	{
	}

	private bool HasMoved()
	{
		return false;
	}

	private static void UpdateTrackedInstances()
	{
	}
}
