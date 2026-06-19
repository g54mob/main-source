using System;
using Pug.UnityExtensions;
using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonAreaCD : IComponentData, IQueryTypeParameter
	{
		public uint seed;

		public int radius;

		public int placementRadius;

		public float shapeAmp;

		public float shapeFreq;

		public bool blockSpawns;

		public bool defineShapeByRooms;

		public readonly float GetRadiusIncludingShape(float angle)
		{
			float num = (defineShapeByRooms ? 0f : shapeAmp);
			return (float)radius * (1f + num * MathUtilities.SquiggleNoise(angle, MathF.PI * 2f, shapeFreq, seed));
		}

		public readonly float GetMaxRadiusIncludingShape()
		{
			float num = (defineShapeByRooms ? 0f : shapeAmp);
			return (float)radius * (1f + num);
		}
	}
}
