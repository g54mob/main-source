using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-200)]
public class RandomInstancing : MonoBehaviour
{
	public GameObject m_Prefab;

	public int m_PoolSize;

	public int m_InstancesPerTile;

	public bool m_RandomPosition;

	public bool m_RandomOrientation;

	public float m_Height;

	public int m_BaseHash;

	public float m_Size;

	private List<Transform> m_Instances;

	private int m_Used;

	private int m_LocX;

	private int m_LocZ;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private void UpdateInstances()
	{
	}

	private int UpdateTileInstances(int i, int j)
	{
		return 0;
	}

	private static int Hash2(int i, int j)
	{
		return 0;
	}

	private static float Random(ref int seed)
	{
		return 0f;
	}
}
