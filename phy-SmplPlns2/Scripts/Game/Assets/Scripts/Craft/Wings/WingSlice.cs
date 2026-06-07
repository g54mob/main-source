using Assets.Scripts.Craft.Wings.Airfoils;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public class WingSlice
	{
		public IAirfoil Airfoil;

		public int ChordSamples;

		public int ColliderSamples;

		public uint ControlSurfaceMask;

		public float3 Position;

		public float Scale;

		public bool SmoothJoin;

		public float SpanPosition;

		public float3 Up;

		public float3 SpanVec;

		public bool SupportsControlSurfaces;

		public (float3 Leading, float3 Trailing) Edges
		{
			get
			{
				float3 float5 = 0.5f * Scale * math.forward();
				return (Leading: Position + float5, Trailing: Position - float5);
			}
		}

		public float3 QuarterChord => Position + math.float3(0f, 0f, 0.25f * Scale);

		public WingSlice()
		{
		}

		public WingSlice(WingSlice cloneFrom)
		{
			Airfoil = cloneFrom.Airfoil;
			ChordSamples = cloneFrom.ChordSamples;
			ColliderSamples = cloneFrom.ColliderSamples;
			ControlSurfaceMask = cloneFrom.ControlSurfaceMask;
			Position = cloneFrom.Position;
			Scale = cloneFrom.Scale;
			SmoothJoin = cloneFrom.SmoothJoin;
			SpanPosition = cloneFrom.SpanPosition;
			Up = cloneFrom.Up;
			SpanVec = cloneFrom.SpanVec;
			SupportsControlSurfaces = cloneFrom.SupportsControlSurfaces;
		}

		public void AddSurface(ControlSurface surface)
		{
			ControlSurfaceMask |= (uint)(1 << (int)surface.SurfaceId);
		}

		public float MeshToSliceChord(float pos)
		{
			return (pos - Position.z) / Scale;
		}
	}
}
