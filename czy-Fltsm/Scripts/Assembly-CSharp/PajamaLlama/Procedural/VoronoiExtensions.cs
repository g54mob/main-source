using External.Zalgo2462.VoronoiLib.Structures;
using UnityEngine;

namespace PajamaLlama.Procedural
{
	public static class VoronoiExtensions
	{
		public static Vector2 ToVector2(this VPoint vPoint)
		{
			return new Vector2((float)vPoint.X, (float)vPoint.Y);
		}

		public static bool IsOnOrOutsideBounds(this VPoint vPoint, Rect bounds)
		{
			if (!(vPoint.X <= (double)bounds.xMin) && !((double)bounds.xMax <= vPoint.X) && !(vPoint.Y <= (double)bounds.yMin))
			{
				return (double)bounds.yMax <= vPoint.Y;
			}
			return true;
		}

		public static bool TryGetBoundsCollision(this VPoint vPoint, Rect bounds, out Vector2 collision)
		{
			bool result = false;
			collision = Vector2.zero;
			if (vPoint.X <= (double)bounds.xMin)
			{
				collision.x = bounds.xMin;
				result = true;
			}
			else if ((double)bounds.xMax <= vPoint.X)
			{
				collision.x = bounds.xMax;
				result = true;
			}
			if (vPoint.Y <= (double)bounds.yMin)
			{
				collision.y = bounds.xMin;
				result = true;
			}
			else if ((double)bounds.yMax <= vPoint.Y)
			{
				collision.y = bounds.xMax;
				result = true;
			}
			return result;
		}

		public static void Flip(this VEdge edge)
		{
			VPoint start = edge.Start;
			edge.Start = edge.End;
			edge.End = start;
		}

		public static float SignedAngle(this VEdge edge, VEdge other)
		{
			Vector2 vector;
			Vector2 to;
			if (edge.End == other.Start)
			{
				vector = edge.Start.ToVector2() - edge.End.ToVector2();
				to = other.End.ToVector2() - other.Start.ToVector2();
			}
			else
			{
				if (edge.Start != other.End)
				{
					return 0f;
				}
				vector = edge.End.ToVector2() - edge.Start.ToVector2();
				to = other.Start.ToVector2() - other.End.ToVector2();
			}
			return Vector2.SignedAngle(vector, to);
		}
	}
}
