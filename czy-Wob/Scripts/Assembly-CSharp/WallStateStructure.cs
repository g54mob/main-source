using System;
using UnityEngine;

[Serializable]
public class WallStateStructure
{
	public ConnectorLabel label;

	public GameObject mappedObject;

	public bool isFloor;

	public bool isTopOfPen;

	public Vector3Int gridCellOffset = Vector3Int.zero;
}
