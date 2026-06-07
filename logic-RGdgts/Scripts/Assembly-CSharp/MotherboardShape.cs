using System.Collections.Generic;
using UnityEngine;

public class MotherboardShape
{
	public struct NodeSlot
	{
		public NodeLink[] links;

		public bool isFullyConnected => false;

		public bool isConnectedBefore => false;

		public bool isConnectedAfter => false;

		public bool isBigSlot => false;

		public Vector2 position => default(Vector2);

		public Vector2Int texturePosition => default(Vector2Int);

		public Vector3 GetScenePosition(Vector3 motherboardPosition)
		{
			return default(Vector3);
		}

		public NodeSlot(int linksCount)
		{
			links = null;
		}
	}

	public struct NodeLink
	{
		public Node source;

		public Node target;

		public MotherboardSide sourceSide;

		public int sourceSlotIndex;

		public int sourceLinkIndex;

		public MotherboardSide targetSide;

		public int targetSlotIndex;

		public int targetLinkIndex;

		public bool isConnected => false;

		public Vector2 position => default(Vector2);

		public Vector2Int texturePosition => default(Vector2Int);

		public NodeLink(Node source, MotherboardSide sourceSide, int sourceSlotIndex, int sourceLinkIndex)
		{
			this.source = null;
			target = null;
			this.sourceSide = default(MotherboardSide);
			this.sourceSlotIndex = 0;
			this.sourceLinkIndex = 0;
			targetSide = default(MotherboardSide);
			targetSlotIndex = 0;
			targetLinkIndex = 0;
		}

		public NodeLink(Node source, Node target, MotherboardSide sourceSide, int sourceSlotIndex, int sourceLinkIndex, MotherboardSide targetSide, int targetSlotIndex, int targetLinkIndex)
		{
			this.source = null;
			this.target = null;
			this.sourceSide = default(MotherboardSide);
			this.sourceSlotIndex = 0;
			this.sourceLinkIndex = 0;
			this.targetSide = default(MotherboardSide);
			this.targetSlotIndex = 0;
			this.targetLinkIndex = 0;
		}

		public Vector3 GetScenePosition(Vector3 motherboardPosition)
		{
			return default(Vector3);
		}
	}

	public class Node
	{
		public MotherboardShape shape;

		public uint id;

		public MotherboardSectionEnum sectionEnum;

		public int rotation;

		public Vector2 position;

		public NodeSlot[] left;

		public NodeSlot[] right;

		public NodeSlot[] top;

		public NodeSlot[] bottom;

		private static NodeSlot[] emptySide;

		public MotherboardSection section
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2Int texturePosition => default(Vector2Int);

		public NodeSlot[] Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 GetScenePosition(Vector3 gadgetPosition)
		{
			return default(Vector3);
		}

		public Node()
		{
		}

		public Node(MotherboardShape shape, uint id, MotherboardSection section, int rotation)
		{
		}

		public MotherboardSection.SlotSprite GetSlotSprite(Motherboard.Layer layer, MotherboardSide side, int slotIndex)
		{
			return default(MotherboardSection.SlotSprite);
		}

		public MotherboardSection.SlotSprite[] GetSlotSprites(Motherboard.Layer layer, MotherboardSide side)
		{
			return null;
		}

		public void Connect(MotherboardSide slotSide, int slotIndex, int linkIndex, Node otherNode, int otherSlotIndex, int otherLinkIndex)
		{
		}

		public Vector2Int GetSize()
		{
			return default(Vector2Int);
		}
	}

	public Node rootNode;

	public List<Node> nodes;

	public MotherboardShape()
	{
	}

	public MotherboardShape(MotherboardSection rootSection, int rotation)
	{
	}

	public MotherboardShape Clone()
	{
		return null;
	}

	public Bounds GetBounds()
	{
		return default(Bounds);
	}

	public uint GetFreeNodeId()
	{
		return 0u;
	}

	public Node GetNode(uint id)
	{
		return null;
	}

	public Node AddNode(MotherboardSection section, int rotation)
	{
		return null;
	}

	public void RefreshNodePositions()
	{
	}

	private void _RefreshNodePosition(Node node, HashSet<uint> processedNodes)
	{
	}

	public List<HashSet<uint>> GetIslands()
	{
		return null;
	}

	private void _ScanIsland(Node node, HashSet<uint> island)
	{
	}

	private Node _FindNodeOutsideIslands(List<HashSet<uint>> islands)
	{
		return null;
	}

	public bool Validate()
	{
		return false;
	}
}
