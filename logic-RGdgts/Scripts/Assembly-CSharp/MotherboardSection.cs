using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu]
public class MotherboardSection : ScriptableObject
{
	[Serializable]
	public struct SlotSideSprite
	{
		public Sprite noConnections;

		public Sprite oneConnectionSelf;

		public Sprite oneConnectionOther;

		public Sprite twoConnections;

		public Sprite threeConnections;

		public bool IsNull => false;

		public bool IsShared => false;
	}

	[Serializable]
	public struct SlotSprite
	{
		public Vector2Int position;

		public Sprite solderableSlot;

		public Sprite solderedSlot;

		public Sprite halfBeforeSoldered;

		public Sprite halfAfterSoldered;

		public Sprite halfBeforeAndAfterSoldered;

		public SlotSideSprite beforeSideSprite;

		public SlotSideSprite afterSideSprite;

		public bool isBigSlot => false;

		public int GetLinksCount()
		{
			return 0;
		}

		public int GetLinkWidth()
		{
			return 0;
		}
	}

	[Serializable]
	public class Layer
	{
		public Sprite center;

		public SlotSprite[] left;

		public SlotSprite[] right;

		public SlotSprite[] top;

		public SlotSprite[] bottom;

		public SlotSprite[] Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool GetAdiacentSlotBefore(MotherboardSide side, int slotIndex, out MotherboardSide adiacentSide, out int adiacentSlotIndex)
		{
			adiacentSide = default(MotherboardSide);
			adiacentSlotIndex = default(int);
			return false;
		}

		public bool GetAdiacentSlotAfter(MotherboardSide side, int slotIndex, out MotherboardSide adiacentSide, out int adiacentSlotIndex)
		{
			adiacentSide = default(MotherboardSide);
			adiacentSlotIndex = default(int);
			return false;
		}

		public bool GetAdiacentLinkBefore(MotherboardSide side, int slotIndex, int linkIndex, out MotherboardSide adiacentSide, out int adiacentSlotIndex, out int adiacentLinkIndex)
		{
			adiacentSide = default(MotherboardSide);
			adiacentSlotIndex = default(int);
			adiacentLinkIndex = default(int);
			return false;
		}

		public bool GetAdiacentLinkAfter(MotherboardSide side, int slotIndex, int linkIndex, out MotherboardSide adiacentSide, out int adiacentSlotIndex, out int adiacentLinkIndex)
		{
			adiacentSide = default(MotherboardSide);
			adiacentSlotIndex = default(int);
			adiacentLinkIndex = default(int);
			return false;
		}
	}

	public const int slotWidth = 80;

	private static SlotSprite[] emptySlots;

	public Vector2Int size;

	public bool flipAssets;

	public Layer bottom;

	public Layer pcb;

	public Layer cover;

	public Layer bottomExtra;

	public Layer pcbExtra;

	public Layer coverExtra;

	public Layer mixMap;

	public MotherboardSectionEnum id;

	public Layer Item => null;

	private void SetAsInvalid()
	{
	}

	public Vector2Int GetPosition(Vector2Int position, int rotation)
	{
		return default(Vector2Int);
	}

	public Vector2Int InverseGetPosition(Vector2Int position, int rotation)
	{
		return default(Vector2Int);
	}

	public Vector2Int GetSlotLinkPosition(MotherboardSide side, int slotIndex, int linkIndex, int rotation)
	{
		return default(Vector2Int);
	}

	public RectInt GetRect(RectInt rect, int rotation)
	{
		return default(RectInt);
	}
}
