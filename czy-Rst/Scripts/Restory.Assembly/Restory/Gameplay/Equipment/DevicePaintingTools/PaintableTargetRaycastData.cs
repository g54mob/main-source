using System;
using UnityEngine;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	[Serializable]
	public class PaintableTargetRaycastData
	{
		public PaintableElement PaintableElement;

		public Vector2Int[] HitTextureCoordinates;

		public int ValidCoordinatesCount;

		public bool HasLineSegment;

		public bool SegmentHasStartCap;

		public Vector2Int SegmentStartTextureCoordinate;

		public Vector2Int SegmentEndTextureCoordinate;
	}
}
