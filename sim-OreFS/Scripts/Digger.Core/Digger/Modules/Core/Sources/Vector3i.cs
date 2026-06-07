using System;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources
{
	[Serializable]
	public struct Vector3i
	{
		public int x;

		public int y;

		public int z;

		public static readonly Vector3i zero = new Vector3i(0, 0, 0);

		public static readonly Vector3i one = new Vector3i(1, 1, 1);

		public static readonly Vector3i two = new Vector3i(2, 2, 2);

		public static readonly Vector3i forward = new Vector3i(0, 0, 1);

		public static readonly Vector3i back = new Vector3i(0, 0, -1);

		public static readonly Vector3i up = new Vector3i(0, 1, 0);

		public static readonly Vector3i down = new Vector3i(0, -1, 0);

		public static readonly Vector3i left = new Vector3i(-1, 0, 0);

		public static readonly Vector3i right = new Vector3i(1, 0, 0);

		public static readonly Vector3i forward_right = new Vector3i(1, 0, 1);

		public static readonly Vector3i forward_left = new Vector3i(-1, 0, 1);

		public static readonly Vector3i forward_up = new Vector3i(0, 1, 1);

		public static readonly Vector3i forward_down = new Vector3i(0, -1, 1);

		public static readonly Vector3i back_right = new Vector3i(1, 0, -1);

		public static readonly Vector3i back_left = new Vector3i(-1, 0, -1);

		public static readonly Vector3i back_up = new Vector3i(0, 1, -1);

		public static readonly Vector3i back_down = new Vector3i(0, -1, -1);

		public static readonly Vector3i up_right = new Vector3i(1, 1, 0);

		public static readonly Vector3i up_left = new Vector3i(-1, 1, 0);

		public static readonly Vector3i down_right = new Vector3i(1, -1, 0);

		public static readonly Vector3i down_left = new Vector3i(-1, -1, 0);

		public static readonly Vector3i forward_right_up = new Vector3i(1, 1, 1);

		public static readonly Vector3i forward_right_down = new Vector3i(1, -1, 1);

		public static readonly Vector3i forward_left_up = new Vector3i(-1, 1, 1);

		public static readonly Vector3i forward_left_down = new Vector3i(-1, -1, 1);

		public static readonly Vector3i back_right_up = new Vector3i(1, 1, -1);

		public static readonly Vector3i back_right_down = new Vector3i(1, -1, -1);

		public static readonly Vector3i back_left_up = new Vector3i(-1, 1, -1);

		public static readonly Vector3i back_left_down = new Vector3i(-1, -1, -1);

		public static readonly Vector3i[] directions = new Vector3i[6] { left, right, back, forward, down, up };

		public static readonly Vector3i[] allDirections = new Vector3i[26]
		{
			left, right, back, forward, down, up, forward_right, forward_left, forward_up, forward_down,
			back_right, back_left, back_up, back_down, up_right, up_left, down_right, down_left, forward_right_up, forward_right_down,
			forward_left_up, forward_left_down, back_right_up, back_right_down, back_left_up, back_left_down
		};

		public static readonly Vector3i[] allDirectionsOrdered = new Vector3i[26]
		{
			forward_right_up, forward_right_down, forward_left_up, forward_left_down, back_right_up, back_right_down, back_left_up, back_left_down, forward_right, forward_left,
			forward_up, forward_down, back_right, back_left, back_up, back_down, up_right, up_left, down_right, down_left,
			left, right, back, forward, down, up
		};

		public static readonly Vector3i[] planeDirections = new Vector3i[8] { left, right, back, forward, forward_right, forward_left, back_right, back_left };

		public static readonly Vector3i[] planeDirectionsStraight = new Vector3i[4] { left, right, back, forward };

		public static readonly Vector3i[] planeDirectionsStraightDown = new Vector3i[4] { down_left, down_right, back_down, forward_down };

		public float MagnitudeSquared => x * x + y * y + z * z;

		public int this[int i]
		{
			get
			{
				return i switch
				{
					0 => x, 
					1 => y, 
					2 => z, 
					_ => throw new ArgumentOutOfRangeException($"There is no value at {i} index."), 
				};
			}
			set
			{
				if (i == 0)
				{
					x = value;
				}
				if (i == 1)
				{
					y = value;
				}
				if (i == 2)
				{
					z = value;
				}
				throw new ArgumentOutOfRangeException($"There is no value at {i} index.");
			}
		}

		public static int IndexOfDirection(Vector3i direction)
		{
			return Array.IndexOf(allDirections, direction);
		}

		public static bool AreNeighbours(Vector3i a, Vector3i b)
		{
			if ((a.x == b.x || a.x == b.x + 1 || a.x == b.x - 1) && (a.y == b.y || a.y == b.y + 1 || a.y == b.y - 1))
			{
				if (a.z != b.z && a.z != b.z + 1)
				{
					return a.z == b.z - 1;
				}
				return true;
			}
			return false;
		}

		public static Vector3i GetNeighbourDirection(Vector3i a, Vector3i b)
		{
			return b - a;
		}

		public Vector3i(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3i(float x, float y, float z)
		{
			this.x = (int)x;
			this.y = (int)y;
			this.z = (int)z;
		}

		public Vector3i(double x, double y, double z)
		{
			this.x = (int)x;
			this.y = (int)y;
			this.z = (int)z;
		}

		public Vector3i(Vector3 v)
		{
			x = (int)v.x;
			y = (int)v.y;
			z = (int)v.z;
		}

		public static int DistanceSquared(Vector3i a, Vector3i b)
		{
			int num = b.x - a.x;
			int num2 = b.y - a.y;
			int num3 = b.z - a.z;
			return num * num + num2 * num2 + num3 * num3;
		}

		public int DistanceSquared(Vector3i v)
		{
			return DistanceSquared(this, v);
		}

		public static int FlatDistanceSquared(Vector3i a, Vector3i b)
		{
			int num = b.x - a.x;
			int num2 = b.z - a.z;
			return num * num + num2 * num2;
		}

		public int FlatDistanceSquared(Vector3i v)
		{
			return FlatDistanceSquared(this, v);
		}

		public static float Distance(Vector3i a, Vector3i b)
		{
			int num = b.x - a.x;
			int num2 = b.y - a.y;
			int num3 = b.z - a.z;
			return Mathf.Sqrt(num * num + num2 * num2 + num3 * num3);
		}

		public float Distance(Vector3i v)
		{
			return Distance(this, v);
		}

		public bool IsInCubeArea(Vector3i cubeCenter, int cubeRadius)
		{
			int num = x - cubeCenter.x;
			if (-cubeRadius <= num && num <= cubeRadius)
			{
				num = y - cubeCenter.y;
				if (-cubeRadius <= num && num <= cubeRadius)
				{
					num = z - cubeCenter.z;
					if (-cubeRadius <= num && num <= cubeRadius)
					{
						return true;
					}
				}
			}
			return false;
		}

		public int3 ToInt3()
		{
			return new int3(x, y, z);
		}

		public override int GetHashCode()
		{
			return x ^ (y << 2) ^ (z >> 2);
		}

		public override bool Equals(object other)
		{
			if (!(other is Vector3i vector3i))
			{
				return false;
			}
			if (x == vector3i.x && y == vector3i.y)
			{
				return z == vector3i.z;
			}
			return false;
		}

		public bool Equals(Vector3i vector)
		{
			if (x == vector.x && y == vector.y)
			{
				return z == vector.z;
			}
			return false;
		}

		public override string ToString()
		{
			return "Vector3i(" + x + " " + y + " " + z + ")";
		}

		public static bool operator ==(Vector3i a, Vector3i b)
		{
			if (a.x == b.x && a.y == b.y)
			{
				return a.z == b.z;
			}
			return false;
		}

		public static bool operator !=(Vector3i a, Vector3i b)
		{
			if (a.x == b.x && a.y == b.y)
			{
				return a.z != b.z;
			}
			return true;
		}

		public static Vector3i operator -(Vector3i a, Vector3i b)
		{
			return new Vector3i(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static Vector3i operator -(Vector3i a)
		{
			return new Vector3i(-a.x, -a.y, -a.z);
		}

		public static Vector3i operator +(Vector3i a, Vector3i b)
		{
			return new Vector3i(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Vector3i operator *(Vector3i a, int b)
		{
			return new Vector3i(a.x * b, a.y * b, a.z * b);
		}

		public static Vector3i operator *(int b, Vector3i a)
		{
			return new Vector3i(a.x * b, a.y * b, a.z * b);
		}

		public static Vector3i operator /(Vector3i a, int b)
		{
			return new Vector3i(a.x / b, a.y / b, a.z / b);
		}

		public static Vector3 operator *(Vector3i a, float b)
		{
			return new Vector3((float)a.x * b, (float)a.y * b, (float)a.z * b);
		}

		public static Vector3 operator *(float b, Vector3i a)
		{
			return new Vector3((float)a.x * b, (float)a.y * b, (float)a.z * b);
		}

		public static bool operator <(Vector3i a, Vector3i b)
		{
			if (a.x < b.x && a.y < b.y)
			{
				return a.z < b.z;
			}
			return false;
		}

		public static bool operator >(Vector3i a, Vector3i b)
		{
			if (a.x > b.x && a.y > b.y)
			{
				return a.z > b.z;
			}
			return false;
		}

		public static bool operator <=(Vector3i a, Vector3i b)
		{
			if (a.x <= b.x && a.y <= b.y)
			{
				return a.z <= b.z;
			}
			return false;
		}

		public static bool operator >=(Vector3i a, Vector3i b)
		{
			if (a.x >= b.x && a.y >= b.y)
			{
				return a.z >= b.z;
			}
			return false;
		}

		public static implicit operator Vector3(Vector3i v)
		{
			return new Vector3(v.x, v.y, v.z);
		}
	}
}
