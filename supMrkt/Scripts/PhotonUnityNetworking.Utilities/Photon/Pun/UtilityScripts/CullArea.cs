using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun.UtilityScripts
{
	public class CullArea : MonoBehaviour
	{
		private const int MAX_NUMBER_OF_ALLOWED_CELLS = 250;

		public const int MAX_NUMBER_OF_SUBDIVISIONS = 3;

		public readonly byte FIRST_GROUP_ID;

		public readonly int[] SUBDIVISION_FIRST_LEVEL_ORDER;

		public readonly int[] SUBDIVISION_SECOND_LEVEL_ORDER;

		public readonly int[] SUBDIVISION_THIRD_LEVEL_ORDER;

		public Vector2 Center;

		public Vector2 Size;

		public Vector2[] Subdivisions;

		public int NumberOfSubdivisions;

		public bool YIsUpAxis;

		public bool RecreateCellHierarchy;

		private byte idCounter;

		public int CellCount { get; private set; }

		public CellTree CellTree { get; private set; }

		public Dictionary<int, GameObject> Map { get; private set; }

		private void Awake()
		{
		}

		public void OnDrawGizmos()
		{
		}

		private void CreateCellHierarchy()
		{
		}

		private void CreateChildCells(CellTreeNode parent, int cellLevelInHierarchy)
		{
		}

		private void DrawCells()
		{
		}

		private bool IsCellCountAllowed()
		{
			return false;
		}

		public List<byte> GetActiveCells(Vector3 position)
		{
			return null;
		}
	}
}
