using System;
using System.Reflection;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	[Serializable]
	public struct Point
	{
		public static readonly int OffsetOfPosition;

		public PointFlags Flags;

		public short MeshIndexA;

		public short MeshIndexB;

		public float2 Position;

		public short SharedPointID;

		public bool IsSmooth
		{
			readonly get
			{
				return (Flags & PointFlags.Smooth) != 0;
			}
			set
			{
				if (value)
				{
					Flags |= PointFlags.Smooth;
				}
				else
				{
					Flags &= ~PointFlags.Smooth;
				}
			}
		}

		public bool JoinProportionally
		{
			get
			{
				return (Flags & PointFlags.JoinProportionally) != 0;
			}
			set
			{
				if (value)
				{
					Flags |= PointFlags.JoinProportionally;
				}
				else
				{
					Flags &= ~PointFlags.JoinProportionally;
				}
			}
		}

		static Point()
		{
			OffsetOfPosition = UnsafeUtility.GetFieldOffset(typeof(Point).GetField("Position", BindingFlags.Instance | BindingFlags.Public));
		}

		public Point(float2 position, PointFlags flags)
		{
			Position = position;
			Flags = flags;
			MeshIndexA = -1;
			MeshIndexB = -1;
			SharedPointID = -1;
		}

		public Point(float2 position, bool smooth = true, bool proportional = false)
		{
			Position = position;
			MeshIndexA = -1;
			MeshIndexB = -1;
			SharedPointID = -1;
			Flags = PointFlags.None;
			if (smooth)
			{
				Flags |= PointFlags.Smooth;
			}
			if (proportional)
			{
				Flags |= PointFlags.JoinProportionally;
			}
		}

		public Point(float x, float y)
			: this(math.float2(x, y))
		{
		}

		public void ResetMeshReferences()
		{
			MeshIndexA = -1;
			MeshIndexB = -1;
		}

		public readonly Point Sharp()
		{
			Point result = this;
			result.IsSmooth = false;
			return result;
		}

		public readonly Point Smooth()
		{
			Point result = this;
			result.IsSmooth = true;
			return result;
		}
	}
}
