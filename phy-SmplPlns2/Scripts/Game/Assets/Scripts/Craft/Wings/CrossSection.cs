using System;
using System.Text;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public struct CrossSection
	{
		[Flags]
		public enum CrossSectionFlags : byte
		{
			None = 0,
			Smooth = 1
		}

		public const float LocalLeadingEdge = 0.5f;

		public const float LocalTrailingEdge = -0.5f;

		public NativeAirfoil.ReadOnly Airfoil;

		public CrossSectionFlags Flags;

		public float3 Up;

		public float3 Position;

		public float SpanPosition;

		public NativeList<Point> Points;

		public float Scale;

		public int MaxSharedPointId;

		public bool IsSmoothed
		{
			readonly get
			{
				return (Flags & CrossSectionFlags.Smooth) != 0;
			}
			set
			{
				if (value)
				{
					Flags |= CrossSectionFlags.Smooth;
				}
				else
				{
					Flags &= ~CrossSectionFlags.Smooth;
				}
			}
		}

		public readonly float4x3 SliceTransform => math.float4x3(math.float4(0f, 0f, Scale, 0f), math.float4(Up * Scale, 0f), math.float4(Position, 1f));

		public bool HasPoints => Points.Length != 0;

		public void Clear()
		{
			Points.Clear();
			Position = default(float3);
			Up = math.up();
			Scale = 1f;
			IsSmoothed = false;
		}

		public void CopyFrom(CrossSection other)
		{
			CopySettingsFrom(other);
			Points.CopyFrom(in other.Points);
		}

		public void CopySettingsFrom(CrossSection other)
		{
			Flags = other.Flags;
			Position = other.Position;
			Up = other.Up;
			Scale = other.Scale;
			Airfoil = other.Airfoil;
		}

		public readonly float3 GetMeshPosition(Point point)
		{
			return SliceToMeshPos(point.Position);
		}

		public readonly float2 MeshToSlicePos(float3 position)
		{
			position -= Position;
			position /= Scale;
			return math.float2(position.z, math.dot(position, Up));
		}

		public readonly float3 SliceToMeshPos(float2 position)
		{
			position *= Scale;
			return Position + position.x * math.forward() + position.y * Up;
		}

		public readonly float MeshToSliceChord(float pos)
		{
			return (pos - Position.z) / Scale;
		}

		public readonly Point InterpolatePoint(int pointBefore, float chordPos)
		{
			NativeList<Point> points = Points;
			Point point = points[(pointBefore + points.Length - 1) % points.Length];
			Point point2 = points[pointBefore];
			return new Point(math.lerp(point.Position, point2.Position, math.unlerp(point.Position.x, point2.Position.x, chordPos)), PointFlags.None);
		}

		public bool GetCutoutRange(float start, float end, SurfaceLocation location, out int startIndex, out int endIndex)
		{
			startIndex = -1;
			endIndex = -1;
			int num = 0;
			float num2 = Points[0].Position.x;
			for (int i = 1; i < Points.Length; i++)
			{
				float x = Points[i].Position.x;
				if (x < num2)
				{
					num2 = x;
					num = i;
				}
			}
			switch (location)
			{
			case SurfaceLocation.TrailingEdge:
			{
				for (int k = 0; k < Points.Length; k++)
				{
					if (Points[k].Position.x < start)
					{
						startIndex = k;
						break;
					}
				}
				if (startIndex == -1)
				{
					return false;
				}
				for (int l = startIndex; l < Points.Length; l++)
				{
					if (Points[l].Position.x > end)
					{
						endIndex = l;
						break;
					}
				}
				if (endIndex == -1)
				{
					return false;
				}
				break;
			}
			case SurfaceLocation.LeadingEdge:
			{
				for (int m = 0; m < Points.Length; m++)
				{
					if (Points[m].Position.x < end)
					{
						endIndex = m;
						break;
					}
				}
				if (endIndex == -1)
				{
					return false;
				}
				for (int num3 = Points.Length - 1; num3 >= endIndex; num3--)
				{
					if (Points[num3].Position.x < start)
					{
						startIndex = num3 + 1;
						break;
					}
				}
				if (startIndex == -1)
				{
					return false;
				}
				break;
			}
			case SurfaceLocation.TopSurface:
			{
				for (int n = 0; n < Points.Length; n++)
				{
					if (Points[n].Position.x < start)
					{
						startIndex = n;
						break;
					}
				}
				if (startIndex == -1)
				{
					return false;
				}
				endIndex = startIndex;
				while (endIndex <= num && !(Points[endIndex].Position.x < end))
				{
					endIndex++;
				}
				break;
			}
			case SurfaceLocation.BottomSurface:
			{
				for (int j = num; j < Points.Length; j++)
				{
					if (Points[j].Position.x > start)
					{
						startIndex = j;
						break;
					}
				}
				if (startIndex == -1)
				{
					return false;
				}
				endIndex = startIndex;
				while (endIndex < Points.Length && !(Points[endIndex].Position.x > end))
				{
					endIndex++;
				}
				break;
			}
			default:
				throw new NotImplementedException();
			}
			return true;
		}

		public LoopCutout? GetCutout(float start, float end, SurfaceLocation location)
		{
			if (!GetCutoutRange(start, end, location, out var startIndex, out var endIndex))
			{
				return null;
			}
			Point startPoint = InterpolatePoint(startIndex, start);
			Point endPoint = InterpolatePoint(endIndex, end);
			return new LoopCutout(Points.AsArray(), startPoint, endPoint, startIndex, endIndex);
		}

		public string DebugPoints()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < Points.Length; i++)
			{
				float2 position = Points[i].Position;
				stringBuilder.AppendLine($"{position.x},{position.y}");
			}
			return stringBuilder.ToString();
		}
	}
}
