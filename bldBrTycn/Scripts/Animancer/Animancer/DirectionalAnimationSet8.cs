using System;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Directional Animation Set/8 Directions", order = 421)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/DirectionalAnimationSet8")]
	public class DirectionalAnimationSet8 : DirectionalAnimationSet
	{
		public static class Diagonals
		{
			public const float OneOverSqrt2 = 0.70710677f;

			public static Vector2 UpRight => new Vector2(0.70710677f, 0.70710677f);

			public static Vector2 DownRight => new Vector2(0.70710677f, -0.70710677f);

			public static Vector2 DownLeft => new Vector2(-0.70710677f, -0.70710677f);

			public static Vector2 UpLeft => new Vector2(-0.70710677f, 0.70710677f);
		}

		public new enum Direction
		{
			Up = 0,
			Right = 1,
			Down = 2,
			Left = 3,
			UpRight = 4,
			DownRight = 5,
			DownLeft = 6,
			UpLeft = 7
		}

		[SerializeField]
		private AnimationClip _UpRight;

		[SerializeField]
		private AnimationClip _DownRight;

		[SerializeField]
		private AnimationClip _DownLeft;

		[SerializeField]
		private AnimationClip _UpLeft;

		public AnimationClip UpRight
		{
			get
			{
				return _UpRight;
			}
			set
			{
				_UpRight = value;
			}
		}

		public AnimationClip DownRight
		{
			get
			{
				return _DownRight;
			}
			set
			{
				_DownRight = value;
			}
		}

		public AnimationClip DownLeft
		{
			get
			{
				return _DownLeft;
			}
			set
			{
				_DownLeft = value;
			}
		}

		public AnimationClip UpLeft
		{
			get
			{
				return _UpLeft;
			}
			set
			{
				_UpLeft = value;
			}
		}

		public override int ClipCount => 8;

		public override AnimationClip GetClip(Vector2 direction)
		{
			float num = Mathf.Atan2(direction.y, direction.x);
			return (Mathf.RoundToInt(8f * num / (MathF.PI * 2f) + 8f) % 8) switch
			{
				0 => base.Right, 
				1 => _UpRight, 
				2 => base.Up, 
				3 => _UpLeft, 
				4 => base.Left, 
				5 => _DownLeft, 
				6 => base.Down, 
				7 => _DownRight, 
				_ => throw new ArgumentOutOfRangeException("Invalid octant"), 
			};
		}

		protected override string GetDirectionName(int direction)
		{
			Direction direction2 = (Direction)direction;
			return direction2.ToString();
		}

		public AnimationClip GetClip(Direction direction)
		{
			return direction switch
			{
				Direction.Up => base.Up, 
				Direction.Right => base.Right, 
				Direction.Down => base.Down, 
				Direction.Left => base.Left, 
				Direction.UpRight => _UpRight, 
				Direction.DownRight => _DownRight, 
				Direction.DownLeft => _DownLeft, 
				Direction.UpLeft => _UpLeft, 
				_ => throw AnimancerUtilities.CreateUnsupportedArgumentException(direction), 
			};
		}

		public override AnimationClip GetClip(int direction)
		{
			return GetClip((Direction)direction);
		}

		public void SetClip(Direction direction, AnimationClip clip)
		{
			switch (direction)
			{
			case Direction.Up:
				base.Up = clip;
				break;
			case Direction.Right:
				base.Right = clip;
				break;
			case Direction.Down:
				base.Down = clip;
				break;
			case Direction.Left:
				base.Left = clip;
				break;
			case Direction.UpRight:
				UpRight = clip;
				break;
			case Direction.DownRight:
				DownRight = clip;
				break;
			case Direction.DownLeft:
				DownLeft = clip;
				break;
			case Direction.UpLeft:
				UpLeft = clip;
				break;
			default:
				throw AnimancerUtilities.CreateUnsupportedArgumentException(direction);
			}
		}

		public override void SetClip(int direction, AnimationClip clip)
		{
			SetClip((Direction)direction, clip);
		}

		public static Vector2 DirectionToVector(Direction direction)
		{
			return direction switch
			{
				Direction.Up => Vector2.up, 
				Direction.Right => Vector2.right, 
				Direction.Down => Vector2.down, 
				Direction.Left => Vector2.left, 
				Direction.UpRight => Diagonals.UpRight, 
				Direction.DownRight => Diagonals.DownRight, 
				Direction.DownLeft => Diagonals.DownLeft, 
				Direction.UpLeft => Diagonals.UpLeft, 
				_ => throw AnimancerUtilities.CreateUnsupportedArgumentException(direction), 
			};
		}

		public override Vector2 GetDirection(int direction)
		{
			return DirectionToVector((Direction)direction);
		}

		public new static Direction VectorToDirection(Vector2 vector)
		{
			float num = Mathf.Atan2(vector.y, vector.x);
			return (Mathf.RoundToInt(8f * num / (MathF.PI * 2f) + 8f) % 8) switch
			{
				0 => Direction.Right, 
				1 => Direction.UpRight, 
				2 => Direction.Up, 
				3 => Direction.UpLeft, 
				4 => Direction.Left, 
				5 => Direction.DownLeft, 
				6 => Direction.Down, 
				7 => Direction.DownRight, 
				_ => throw new ArgumentOutOfRangeException("Invalid octant"), 
			};
		}

		public new static Vector2 SnapVectorToDirection(Vector2 vector)
		{
			float magnitude = vector.magnitude;
			vector = DirectionToVector(VectorToDirection(vector)) * magnitude;
			return vector;
		}

		public override Vector2 Snap(Vector2 vector)
		{
			return SnapVectorToDirection(vector);
		}
	}
}
