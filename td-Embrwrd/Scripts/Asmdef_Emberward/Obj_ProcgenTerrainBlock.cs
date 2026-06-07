using System.Collections.Generic;
using UnityEngine;

public class Obj_ProcgenTerrainBlock : MonoBehaviour
{
	public enum eExitDirectionType
	{
		NONE = 0,
		FRONT = 1,
		BACK = 2,
		LEFT = 3,
		RIGHT = 4
	}

	[SerializeField]
	private GameObject blockPrefab;

	[SerializeField]
	private Vector2 size;

	public void Init(Vector3Int pos, List<eExitDirectionType> exitDirections)
	{
	}

	private void ProcgenBlocks(List<eExitDirectionType> exitDirections)
	{
	}
}
