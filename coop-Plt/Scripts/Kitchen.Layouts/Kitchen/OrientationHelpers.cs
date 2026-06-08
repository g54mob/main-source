using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	public static class OrientationHelpers
	{
		public static Orientation[] All = new Orientation[4]
		{
			Orientation.Right,
			Orientation.Down,
			Orientation.Left,
			Orientation.Up
		};

		public static Orientation[] PreferredRotations = new Orientation[4]
		{
			Orientation.Up,
			Orientation.Right,
			Orientation.Left,
			Orientation.Down
		};

		private static Dictionary<Orientation, quaternion> Rotations;

		public static Orientation ToOrientation(this quaternion q)
		{
			return GetRelativeOrientation(Vector3.zero, math.mul(q, new float3(0f, 0f, 1f)));
		}

		public static Orientation RotateOrientation(this quaternion q, Orientation o)
		{
			return GetRelativeOrientation(Vector3.zero, math.mul(q, o.ToOffset()));
		}

		public static Orientation RotateCW(this Orientation o)
		{
			return o switch
			{
				Orientation.Right => Orientation.Down, 
				Orientation.Down => Orientation.Left, 
				Orientation.Left => Orientation.Up, 
				Orientation.Up => Orientation.Right, 
				_ => Orientation.Down, 
			};
		}

		public static Orientation RotateCCW(this Orientation o)
		{
			return o switch
			{
				Orientation.Right => Orientation.Up, 
				Orientation.Down => Orientation.Right, 
				Orientation.Left => Orientation.Down, 
				Orientation.Up => Orientation.Left, 
				_ => Orientation.Down, 
			};
		}

		public static Orientation Flip(this Orientation o)
		{
			return o switch
			{
				Orientation.Right => Orientation.Left, 
				Orientation.Down => Orientation.Up, 
				Orientation.Left => Orientation.Right, 
				Orientation.Up => Orientation.Down, 
				_ => Orientation.Down, 
			};
		}

		public static Orientation Combine(this Orientation o, Orientation o2)
		{
			return (Orientation)(((int)o + (int)o2 + 4) % 4);
		}

		public static Orientation GetRelativeOrientation(Vector3 start, Vector3 target)
		{
			if (start.x < target.x - 0.1f)
			{
				return Orientation.Right;
			}
			if (start.x > target.x + 0.1f)
			{
				return Orientation.Left;
			}
			if (start.z > target.z + 0.1f)
			{
				return Orientation.Down;
			}
			return Orientation.Up;
		}

		private static void BuildLookRotations()
		{
			Rotations = new Dictionary<Orientation, quaternion>();
			Orientation[] all = All;
			foreach (Orientation orientation in all)
			{
				quaternion value = quaternion.LookRotation(orientation.ToOffset(), new float3(0f, 1f, 0f));
				Rotations[orientation] = value;
			}
		}

		public static quaternion ToRotation(this Orientation o)
		{
			if (Rotations == null)
			{
				BuildLookRotations();
			}
			return Rotations[o];
		}

		public static Vector3 ToOffset(this Orientation o)
		{
			return o switch
			{
				Orientation.Right => Vector3.right, 
				Orientation.Down => Vector3.back, 
				Orientation.Left => Vector3.left, 
				Orientation.Up => Vector3.forward, 
				_ => Vector3.right, 
			};
		}
	}
}
