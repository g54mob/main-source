using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TileFitter
{
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public List<GroupType> tileSuppliedEdges;

		public List<GroupType> tileSlotSuppliedEdges;

		internal bool _003CTileFitsInSlot_003Eb__2(GroupType x)
		{
			return tileSuppliedEdges.Contains(x);
		}

		internal bool _003CTileFitsInSlot_003Eb__3(GroupType x)
		{
			return tileSlotSuppliedEdges.Contains(x);
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<GroupType, bool> _003C_003E9__0_0;

		public static Func<GroupType, bool> _003C_003E9__0_1;

		internal bool _003CTileFitsInSlot_003Eb__0_0(GroupType x)
		{
			return x.constraining;
		}

		internal bool _003CTileFitsInSlot_003Eb__0_1(GroupType x)
		{
			return x.constraining;
		}
	}

	public static bool TileFitsInSlot(Tile tileToCheck, TileSlot slotToCheck, int additionalRotation = 0)
	{
		if (slotToCheck == null)
		{
			return false;
		}
		for (int i = 0; i < 6; i++)
		{
			_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass0_0();
			int directionIndex = (i + additionalRotation + 6) % 6;
			List<GroupType> edgeTypes = tileToCheck.GetEdgeTypes(directionIndex, Space.World, TileEdgeType.NonHybrid);
			List<GroupType> edgeTypes2 = slotToCheck.GetEdgeTypes(i, TileEdgeType.NonHybrid);
			Tile tile = slotToCheck.NeighborTiles[i];
			List<GroupType> list = Enumerable.ToList(Enumerable.Where(edgeTypes, (GroupType x) => x.constraining));
			List<GroupType> list2 = Enumerable.ToList(Enumerable.Where(edgeTypes2, (GroupType x) => x.constraining));
			CS_0024_003C_003E8__locals4.tileSuppliedEdges = tileToCheck.GetEdgeTypes(directionIndex, Space.World);
			CS_0024_003C_003E8__locals4.tileSlotSuppliedEdges = slotToCheck.GetEdgeTypes(i);
			if (list2.Count > 0 && !Enumerable.All(list2, (GroupType x) => CS_0024_003C_003E8__locals4.tileSuppliedEdges.Contains(x)))
			{
				return false;
			}
			if (list.Count > 0 && (bool)tile && !Enumerable.All(list, (GroupType x) => CS_0024_003C_003E8__locals4.tileSlotSuppliedEdges.Contains(x)))
			{
				return false;
			}
		}
		return true;
	}

	public static bool TileFitsInSlotAtRotation(Tile tileToCheck, TileSlot targetSlot, int overwriteRotation)
	{
		return TileFitsInSlot(tileToCheck, targetSlot, tileToCheck.RotationIndex - overwriteRotation);
	}

	public static bool TileFitsInSlotAnyRotation(Tile tileToCheck, TileSlot targetSlot)
	{
		for (int i = 0; i < 6; i++)
		{
			if (TileFitsInSlot(tileToCheck, targetSlot, i))
			{
				return true;
			}
		}
		return false;
	}

	public static int MatchingTileEdgeCount(Tile tileToCheck, int additionalRotation = 0)
	{
		int num = 0;
		for (int i = 0; i < 6; i++)
		{
			int directionIndex = (i - additionalRotation + 6) % 6;
			Tile neighbor = tileToCheck.GetNeighbor(i, Space.World);
			if (neighbor == null)
			{
				num++;
				continue;
			}
			GroupType groupType = tileToCheck.GetElementGroup(directionIndex, Space.World)?.GroupType;
			GroupType groupType2 = neighbor.GetElementGroup((i + 3) % 6, Space.World)?.GroupType;
			if (groupType == groupType2)
			{
				num++;
			}
			else if (groupType != null && groupType2 != null && (groupType == neighbor.GetElementGroup((i + 3) % 6, Space.World, groupType)?.GroupType || groupType2 == tileToCheck.GetElementGroup(directionIndex, Space.World, groupType2)?.GroupType))
			{
				num++;
			}
			else if ((tileToCheck.GetHybridEdges(directionIndex, Space.World).Count > 0 && groupType2 == null) || (neighbor.GetHybridEdges((i + 3) % 6, Space.World).Count > 0 && groupType == null))
			{
				num++;
			}
		}
		return num;
	}
}
