using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun.UtilityScripts
{
	public class CellTreeNode
	{
		public enum ENodeType : byte
		{
			Root = 0,
			Node = 1,
			Leaf = 2
		}

		public byte Id;

		public Vector3 Center;

		public Vector3 Size;

		public Vector3 TopLeft;

		public Vector3 BottomRight;

		public ENodeType NodeType;

		public CellTreeNode Parent;

		public List<CellTreeNode> Childs;

		private float maxDistance;

		public CellTreeNode()
		{
		}

		public CellTreeNode(byte id, ENodeType nodeType, CellTreeNode parent)
		{
		}

		public void AddChild(CellTreeNode child)
		{
		}

		public void Draw()
		{
		}

		public void GetActiveCells(List<byte> activeCells, bool yIsUpAxis, Vector3 position)
		{
		}

		public bool IsPointInsideCell(bool yIsUpAxis, Vector3 point)
		{
			return false;
		}

		public bool IsPointNearCell(bool yIsUpAxis, Vector3 point)
		{
			return false;
		}
	}
}
