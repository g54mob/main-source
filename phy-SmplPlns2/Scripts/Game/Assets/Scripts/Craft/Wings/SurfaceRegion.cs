using System.Collections.Generic;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public static class SurfaceRegion
	{
		public enum SliceType
		{
			StartRegion = 0,
			Slice = 1,
			EndRegion = 2
		}

		public struct Slice : IComparer<Slice>
		{
			public byte ControlSurface;

			public float3 Position;

			public int RegionIndex;

			public SliceType Type;

			public float Scale;

			public float SpanPosition;

			public float3 Up;

			public Slice(SliceType type, ControlSurface controlSurface, float pos, int id)
			{
				ControlSurface = controlSurface.SurfaceId;
				SpanPosition = pos;
				RegionIndex = id;
				Type = type;
				Position = default(float3);
				Up = default(float3);
				Scale = 1f;
			}

			readonly int IComparer<Slice>.Compare(Slice a, Slice b)
			{
				return a.SpanPosition.CompareTo(b.SpanPosition);
			}

			public void InterpolateFrom(WingSlice a, WingSlice b)
			{
				float t = math.unlerp(a.SpanPosition, b.SpanPosition, SpanPosition);
				Scale = math.lerp(a.Scale, b.Scale, t);
				Position = math.lerp(a.Position, b.Position, t);
				Up = math.lerp(a.Up, b.Up, t);
			}
		}

		public const int NoRegion = -1;

		public static void AddRegion(this NativeList<Slice> list, ControlSurface surface, float start, float end, int id)
		{
			list.Add(new Slice(SliceType.StartRegion, surface, start, id));
			list.Add(new Slice(SliceType.EndRegion, surface, end, id));
		}
	}
}
