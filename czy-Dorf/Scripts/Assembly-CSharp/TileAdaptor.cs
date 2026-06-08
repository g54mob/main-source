using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileAdaptor : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public GroupType adaptiveType;

		internal bool _003CAdaptTileToSlot_003Eb__2(ElementGroupSegment x)
		{
			return x.GroupType == adaptiveType;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<ElementGroupSegment, bool> _003C_003E9__2_0;

		public static Func<ElementGroupSegment, GroupType> _003C_003E9__2_1;

		internal bool _003CAdaptTileToSlot_003Eb__2_0(ElementGroupSegment x)
		{
			return x.GroupType.constraining;
		}

		internal GroupType _003CAdaptTileToSlot_003Eb__2_1(ElementGroupSegment x)
		{
			return x.GroupType;
		}
	}

	[SerializeField]
	private TileFactory tileFactory;

	[SerializeField]
	private ElementGroupSegmentAdaptor elementGroupSegmentAdaptor;

	public void AdaptTileToSlot(Tile tileToPlace, TileSlot targetTileSlot, int rotationDirection = 1, int initialRotation = 0)
	{
		List<ElementGroupSegment> source = new List<ElementGroupSegment>(tileToPlace.AllElementGroupSegments);
		using List<GroupType>.Enumerator enumerator = Enumerable.ToList(Enumerable.Distinct(Enumerable.Select(Enumerable.ToList(Enumerable.Where(source, (ElementGroupSegment x) => x.GroupType.constraining)), (ElementGroupSegment x) => x.GroupType))).GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass2_0();
			CS_0024_003C_003E8__locals2.adaptiveType = enumerator.Current;
			ElementGroupSegment elementGroupSegment = Enumerable.First(source, (ElementGroupSegment x) => x.GroupType == CS_0024_003C_003E8__locals2.adaptiveType);
			int num = ElementGroupSegmentFitter.SubVariantCount(elementGroupSegment.PrimaryVariant);
			for (int num2 = 0; num2 < num * 2; num2++)
			{
				int num3 = (elementGroupSegment.SubVariant + num2 * rotationDirection + num) % num;
				if (num3 != elementGroupSegment.SubVariant)
				{
					Debug.Log($"variant {elementGroupSegment.PrimaryVariant}-{elementGroupSegment.SubVariant} doesn't work, switching to {elementGroupSegment.PrimaryVariant}-{num3}");
					AdaptTileToSegment(tileToPlace, elementGroupSegment, num3, rotationDirection);
				}
				int num4 = ((num2 == 0) ? (tileToPlace.RotationIndex + initialRotation) : ((rotationDirection != 1) ? 5 : 0));
				Debug.Log($"Adapt Tile, startRotation: {num4}, direction: {rotationDirection}, variant: {num2}->{num3}");
				for (int num5 = num4; num5 < 6 && num5 >= 0; num5 += rotationDirection)
				{
					if (TileFitter.TileFitsInSlotAtRotation(tileToPlace, targetTileSlot, num5))
					{
						Debug.Log($"rotation found! {num5}");
						tileToPlace.RotateTo(num5);
						return;
					}
				}
				Debug.Log("no rotation fits");
			}
		}
	}

	private void AdaptTileToSegment(Tile tileToPlace, ElementGroupSegment adaptiveSegment, int wantedVariant, int rotationDirection = 1)
	{
	}

	private void RotateEdgeConstellation(List<int> edgeConstellation, int rotationAmount)
	{
		for (int i = 0; i < edgeConstellation.Count; i++)
		{
			edgeConstellation[i] = (edgeConstellation[i] + rotationAmount + 6) % 6;
		}
	}

	public int RotateTileToFitInSlot(Tile tileToRotate, TileSlot targetSlot, int rotationDirection = 1, bool animate = true)
	{
		for (int i = 0; i < 6; i++)
		{
			if (TileFitter.TileFitsInSlot(tileToRotate, targetSlot, -i * rotationDirection))
			{
				tileToRotate.Rotate(i * rotationDirection, animate);
				return i * rotationDirection;
			}
		}
		return 0;
	}
}
