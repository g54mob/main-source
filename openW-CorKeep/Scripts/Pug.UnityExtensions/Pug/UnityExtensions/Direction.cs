using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public struct Direction : IEquatable<Direction>
	{
		public enum Id : byte
		{
			zero = 0,
			forward = 1,
			left = 2,
			back = 3,
			right = 4,
			forward_left = 5,
			forward_right = 6,
			back_left = 7,
			back_right = 8
		}

		public struct Extended
		{
			public readonly Id id;

			public readonly Vector2 vec2;

			public readonly Vector2Int vec2i;

			public readonly Vector3 vec3;

			public readonly bool isH;

			public readonly bool isV;

			public readonly bool isP;

			public readonly bool is0;

			public readonly float angle;

			public readonly int axisSign;

			public readonly Id oppositeId;

			public readonly Id nextClockwiseId;

			public readonly FixedString32Bytes cuteName;

			public readonly FixedString32Bytes cuteName2;

			public Extended opposite => extendedArray[(uint)oppositeId];

			public Extended nextClockwise => extendedArray[(uint)nextClockwiseId];

			public Extended nextCounterClockwise => nextClockwise.opposite;

			internal Extended(Id e, Vector3 v, float a, FixedString32Bytes cuteName, FixedString32Bytes cuteName2, Id oppositeId, Id nextClockwiseID)
			{
				id = e;
				vec2 = new Vector2(v.x, v.z);
				vec2i = vec2.RoundToInt();
				vec3 = v;
				angle = a;
				isH = Mathf.Abs(v.x) > 0.5f;
				isV = Mathf.Abs(v.z) > 0.5f;
				isP = (isV ? (v.z > 0f) : (v.x > 0f));
				is0 = !isH && !isV;
				axisSign = Math.Sign(isH ? v.x : v.z);
				this.cuteName = cuteName;
				this.cuteName2 = cuteName2;
				this.oppositeId = oppositeId;
				nextClockwiseId = nextClockwiseID;
			}

			public static implicit operator Direction(Extended e)
			{
				return new Direction
				{
					id = e.id
				};
			}
		}

		public Id id;

		public static readonly Direction[] allFourClockwise;

		public static readonly Direction[] allEightClockwise;

		private static readonly Extended[] extendedArray;

		public Extended ext => extendedArray[(uint)id];

		public Vector2 vec2 => ext.vec2;

		public float2 f2 => ext.vec2;

		public Vector2Int vec2i => ext.vec2i;

		public int2 i2 => new int2(ext.vec2i.x, ext.vec2i.y);

		public Vector3 vec3 => ext.vec3;

		public float3 f3 => ext.vec3;

		public bool isH => ext.isH;

		public bool isV => ext.isV;

		public bool isP => ext.isP;

		public bool is0 => ext.is0;

		public float angle => ext.angle;

		public int axisSign => ext.axisSign;

		public Direction opposite => ext.opposite;

		public Direction nextClockwise => ext.nextClockwise;

		public Direction nextCounterClockwise => ext.nextCounterClockwise;

		public static Direction zero => new Direction
		{
			id = Id.zero
		};

		public static Direction forward => new Direction
		{
			id = Id.forward
		};

		public static Direction left => new Direction
		{
			id = Id.left
		};

		public static Direction back => new Direction
		{
			id = Id.back
		};

		public static Direction right => new Direction
		{
			id = Id.right
		};

		public static Direction forward_left => new Direction
		{
			id = Id.forward_left
		};

		public static Direction forward_right => new Direction
		{
			id = Id.forward_right
		};

		public static Direction back_left => new Direction
		{
			id = Id.back_left
		};

		public static Direction back_right => new Direction
		{
			id = Id.back_right
		};

		public static Direction[] allFourRandom
		{
			get
			{
				Direction[] array = new Direction[4];
				Array.Copy(allFourClockwise, array, 4);
				for (int i = 0; i < 4; i++)
				{
					Direction direction = array[i];
					int num = UnityEngine.Random.Range(i, 4);
					array[i] = array[num];
					array[num] = direction;
				}
				return array;
			}
		}

		public static NativeArray<Direction> AllFourClockwiseNativeArray(Allocator allocator)
		{
			NativeArray<Direction> result = new NativeArray<Direction>(4, allocator);
			result[0] = new Direction
			{
				id = Id.right
			};
			result[1] = new Direction
			{
				id = Id.back
			};
			result[2] = new Direction
			{
				id = Id.left
			};
			result[3] = new Direction
			{
				id = Id.forward
			};
			return result;
		}

		public static NativeArray<Direction> AllEightClockwiseNativeArray(Allocator allocator)
		{
			NativeArray<Direction> result = new NativeArray<Direction>(4, allocator);
			result[0] = new Direction
			{
				id = Id.right
			};
			result[1] = new Direction
			{
				id = Id.back_right
			};
			result[2] = new Direction
			{
				id = Id.back
			};
			result[3] = new Direction
			{
				id = Id.back_left
			};
			result[0] = new Direction
			{
				id = Id.left
			};
			result[1] = new Direction
			{
				id = Id.forward_left
			};
			result[2] = new Direction
			{
				id = Id.forward
			};
			result[3] = new Direction
			{
				id = Id.forward_right
			};
			return result;
		}

		static Direction()
		{
			allFourClockwise = new Direction[4] { right, back, left, forward };
			allEightClockwise = new Direction[8] { right, back_right, back, back_left, left, forward_left, forward, forward_right };
			extendedArray = new Extended[9]
			{
				new Extended(Id.zero, Vector3.zero, 0f, "◆", "◇", Id.zero, Id.zero),
				new Extended(Id.forward, Vector3.forward, 90f, "▲", "\u02c4", Id.back, Id.right),
				new Extended(Id.left, Vector3.left, 180f, "◀", "\u02c2", Id.right, Id.forward),
				new Extended(Id.back, Vector3.back, -90f, "▼", "\u02c5", Id.forward, Id.left),
				new Extended(Id.right, Vector3.right, 0f, "▶", "\u02c3", Id.left, Id.back),
				new Extended(Id.forward_left, Vector3.forward + Vector3.left, 135f, "", "", Id.zero, Id.zero),
				new Extended(Id.forward_right, Vector3.forward + Vector3.right, 45f, "", "", Id.zero, Id.zero),
				new Extended(Id.back_left, Vector3.back + Vector3.left, -135f, "", "", Id.zero, Id.zero),
				new Extended(Id.back_right, Vector3.back + Vector3.right, -45f, "", "", Id.zero, Id.zero)
			};
		}

		public static implicit operator Direction(Id id)
		{
			return new Direction
			{
				id = id
			};
		}

		public static Direction FromVector(int2 i2)
		{
			return FromVector(new Vector2(i2.x, i2.y), 0f);
		}

		public static Direction FromVector(Vector2 vec, float threshold = 0.25f)
		{
			float num = Mathf.Abs(vec.x);
			float num2 = Mathf.Abs(vec.y);
			if (num >= num2 && num > threshold)
			{
				if (!(vec.x > 0f))
				{
					return left;
				}
				return right;
			}
			if (num2 > num && num2 > threshold)
			{
				if (!(vec.y > 0f))
				{
					return back;
				}
				return forward;
			}
			return zero;
		}

		public static Direction FromVector(Vector3 vec, float threshold = 0.25f)
		{
			float num = Mathf.Abs(vec.x);
			float num2 = Mathf.Abs(vec.z);
			if (num >= num2 && num > threshold)
			{
				if (!(vec.x > 0f))
				{
					return left;
				}
				return right;
			}
			if (num2 > num && num2 > threshold)
			{
				if (!(vec.z > 0f))
				{
					return back;
				}
				return forward;
			}
			return zero;
		}

		public static Direction FromVector(float3 vec, float threshold = 0.25f)
		{
			float num = math.abs(vec.x);
			float num2 = math.abs(vec.z);
			if (num >= num2 && num > threshold)
			{
				if (!(vec.x > 0f))
				{
					return left;
				}
				return right;
			}
			if (num2 > num && num2 > threshold)
			{
				if (!(vec.z > 0f))
				{
					return back;
				}
				return forward;
			}
			return zero;
		}

		public static Direction FromVectorEightDirections(float3 vec, float threshold = 0.25f)
		{
			if (math.length(vec) < threshold)
			{
				return zero;
			}
			float3 float5 = math.normalize(vec);
			float num = math.degrees(math.atan2(float5.x, float5.z));
			num = (num + 360f) % 360f;
			if (num >= 337.5f || num < 22.5f)
			{
				return forward;
			}
			if (num >= 22.5f && num < 67.5f)
			{
				return forward_right;
			}
			if (num >= 67.5f && num < 112.5f)
			{
				return right;
			}
			if (num >= 112.5f && num < 157.5f)
			{
				return back_right;
			}
			if (num >= 157.5f && num < 202.5f)
			{
				return back;
			}
			if (num >= 202.5f && num < 247.5f)
			{
				return back_left;
			}
			if (num >= 247.5f && num < 292.5f)
			{
				return left;
			}
			if (num >= 292.5f && num < 337.5f)
			{
				return forward_left;
			}
			return zero;
		}

		public static Direction DominantSideOf(Vector3 v1, Vector3 v2)
		{
			float num = Mathf.Abs(v1.x - v2.x);
			float num2 = Mathf.Abs(v1.z - v2.z);
			if (num + num2 <= 1E-05f)
			{
				return zero;
			}
			if (num > num2)
			{
				if (v1.x < v2.x)
				{
					return left;
				}
				return right;
			}
			if (v1.z < v2.z)
			{
				return back;
			}
			return forward;
		}

		public static Direction NonDominantSideOf(Vector3 v1, Vector3 v2)
		{
			float num = Mathf.Abs(v1.x - v2.x);
			float num2 = Mathf.Abs(v1.z - v2.z);
			if (num + num2 <= 1E-05f)
			{
				return zero;
			}
			if (num < num2)
			{
				if (v1.x < v2.x)
				{
					return left;
				}
				return right;
			}
			if (v1.z < v2.z)
			{
				return back;
			}
			return forward;
		}

		public static Direction FromTo(Vector3 from, Vector3 to, float threshold = 0.25f)
		{
			return FromVector(to - from, threshold);
		}

		public static Direction FromStraightVector(Vector3Int vec)
		{
			if (!((vec.x == 0) ^ (vec.z == 0)))
			{
				return zero;
			}
			if (vec.z == 0)
			{
				if (vec.x <= 0)
				{
					return left;
				}
				return right;
			}
			if (vec.z <= 0)
			{
				return back;
			}
			return forward;
		}

		public static Direction FromVector_Strict_ZLeaning(Vector3 vec)
		{
			float num = Mathf.Abs(vec.x);
			float num2 = Mathf.Abs(vec.z);
			if (num > num2)
			{
				if (!(vec.x > 0f))
				{
					return left;
				}
				return right;
			}
			if (!(vec.z > 0f))
			{
				return back;
			}
			return forward;
		}

		public override string ToString()
		{
			return ext.cuteName.ToString();
		}

		public Vector3 FilterAxis(Vector3 vec)
		{
			return new Vector3(isH ? vec.x : 0f, vec.y, isV ? vec.z : 0f);
		}

		public float FilteredAxisValue(Vector3 vec)
		{
			if (!isH)
			{
				return vec.z;
			}
			return vec.x;
		}

		public int FilteredAxisValue(Vector3Int vec)
		{
			if (!isH)
			{
				return vec.z;
			}
			return vec.x;
		}

		public Vector3 ExcludeAxis(Vector3 vec)
		{
			return new Vector3(isH ? 0f : vec.x, vec.y, isV ? 0f : vec.z);
		}

		public float ExcludedAxisValue(Vector3 vec)
		{
			if (!isH)
			{
				return vec.x;
			}
			return vec.z;
		}

		public bool IsMovingAwayFrom(Vector3 movementOrigin, Vector3 targetPoint, float epsilonStepBack = 0f)
		{
			float num = FilteredAxisValue(movementOrigin);
			float num2 = FilteredAxisValue(targetPoint);
			if (num == num2)
			{
				return false;
			}
			return axisSign == Math.Sign(num - epsilonStepBack - num2);
		}

		public bool IsMovingTowards(Vector3Int movementOrigin, Vector3Int targetPoint)
		{
			int num = FilteredAxisValue(movementOrigin);
			int num2 = FilteredAxisValue(targetPoint);
			return axisSign == Math.Sign(num2 - num);
		}

		public bool IsMovingTowards(Vector3 movementOrigin, Vector3 targetPoint)
		{
			float num = FilteredAxisValue(movementOrigin);
			float num2 = FilteredAxisValue(targetPoint);
			return axisSign == Math.Sign(num2 - num);
		}

		public float SignedDistanceOnAxis(Vector3 to, Vector3 from)
		{
			float num = FilteredAxisValue(to);
			float num2 = FilteredAxisValue(from);
			return (float)axisSign * (num - num2);
		}

		public bool SameAxis(Direction other)
		{
			if (isH == other.isH)
			{
				return isV == other.isV;
			}
			return false;
		}

		public bool Equals(Direction other)
		{
			return id == other.id;
		}

		public override bool Equals(object obj)
		{
			if (obj is Direction other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)id;
		}

		public static bool operator ==(Direction d1, Direction d2)
		{
			return d1.Equals(d2);
		}

		public static bool operator !=(Direction d1, Direction d2)
		{
			return !d1.Equals(d2);
		}
	}
}
