using System;
using UnityEngine;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public readonly struct PathLineSegment : IEquatable<PathLineSegment>
	{
		public Vector2 Start { get; }

		public Vector2 End { get; }

		public float Length { get; }

		public PathLineSegment(Vector2 start, Vector2 end)
		{
			Start = default(Vector2);
			End = default(Vector2);
			Length = 0f;
		}

		public bool Equals(PathLineSegment other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
