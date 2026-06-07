using System;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPanel : MonoBehaviour
{
	public class ShieldData
	{
		public BaseUnitManager unit;

		public int dist2;

		public ShieldData()
		{
		}

		public ShieldData(int cellX, int cellY, BaseUnitManager unit)
		{
		}
	}

	[NonSerialized]
	public bool dirty;

	private Mesh mesh;

	private MeshFilter meshFilter;

	private float v;

	private Vector3[] vertices;

	private int[] triangles;

	public List<ShieldData>[] shieldDataArray;

	public int GetShield(int cellX, int cellY)
	{
		return 0;
	}

	public List<ShieldData> GetShieldDataList(int cellX, int cellY)
	{
		return null;
	}

	public void InsertShieldData(int cellX, int cellY, BaseUnitManager unit)
	{
	}

	public void RemoveShieldData(int cellX, int cellY, BaseUnitManager unit)
	{
	}

	public ShieldData GetNearestShieldData(int cellX, int cellY)
	{
		return null;
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private bool IsEdge(int x, int y)
	{
		return false;
	}

	public void UpdateMesh()
	{
	}
}
