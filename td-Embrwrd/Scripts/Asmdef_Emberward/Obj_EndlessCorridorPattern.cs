using System;
using System.Collections.Generic;
using UnityEngine;

public class Obj_EndlessCorridorPattern : MonoBehaviour
{
	[Serializable]
	public class PortalNodeEntry
	{
		public eDoorFlags type;

		public GameObject node;
	}

	[SerializeField]
	private eDoorFlags doorFlags;

	[SerializeField]
	private Transform node_OtherItems;

	[SerializeField]
	private int size;

	[SerializeField]
	private List<PortalNodeEntry> portalNodeEntries;

	private GameObject blockPrefab;

	private bool isHavePortal;

	private int[,] Tiles;

	public bool IsHavePortal => false;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetBlockPrefab(GameObject prefab)
	{
	}

	public void TogglePortal(bool isOn)
	{
	}

	public void OverrideDoorFlags(eDoorFlags newDoorFlags)
	{
	}

	public void GenerateWallCubes()
	{
	}

	public Transform GetPortalNodeOnDoorSide(eDoorFlags doorSide)
	{
		return null;
	}

	public Transform GetPortalBasedOnPreviousCell(Vector3 previousCellPos)
	{
		return null;
	}

	private void OnDrawGizmos()
	{
	}

	public void Init(int roomSize, eDoorFlags doorFlags)
	{
	}

	private void BuildSouth(int size, bool hasDoor)
	{
	}

	private void BuildNorth(int size, bool hasDoor)
	{
	}

	private void BuildWest(int size, bool hasDoor)
	{
	}

	private void BuildEast(int size, bool hasDoor)
	{
	}

	private void CalcDoorRegion(int size, out int start, out int width)
	{
		start = default(int);
		width = default(int);
	}
}
