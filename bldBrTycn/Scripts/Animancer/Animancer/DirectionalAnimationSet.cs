using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Directional Animation Set/4 Directions", order = 420)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/DirectionalAnimationSet")]
	public class DirectionalAnimationSet : ScriptableObject, IAnimationClipSource
	{
		public enum Direction
		{
			Up = 0,
			Right = 1,
			Down = 2,
			Left = 3
		}

		[SerializeField]
		private AnimationClip _Up;

		[SerializeField]
		private AnimationClip _Right;

		[SerializeField]
		private AnimationClip _Down;

		[SerializeField]
		private AnimationClip _Left;

		public AnimationClip Up
		{
			get
			{
				return _Up;
			}
			set
			{
				_Up = value;
			}
		}

		public AnimationClip Right
		{
			get
			{
				return _Right;
			}
			set
			{
				_Right = value;
			}
		}

		public AnimationClip Down
		{
			get
			{
				return _Down;
			}
			set
			{
				_Down = value;
			}
		}

		public AnimationClip Left
		{
			get
			{
				return _Left;
			}
			set
			{
				_Left = value;
			}
		}

		public virtual int ClipCount => 4;

		[Conditional("UNITY_ASSERTIONS")]
		public void AllowSetClips(bool allow = true)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		public void AssertCanSetClips()
		{
		}

		public virtual AnimationClip GetClip(Vector2 direction)
		{
			if (direction.x >= 0f)
			{
				if (direction.y >= 0f)
				{
					if (!(direction.x > direction.y))
					{
						return _Up;
					}
					return _Right;
				}
				if (!(direction.x > 0f - direction.y))
				{
					return _Down;
				}
				return _Right;
			}
			if (direction.y >= 0f)
			{
				if (!(direction.x < 0f - direction.y))
				{
					return _Up;
				}
				return _Left;
			}
			if (!(direction.x < direction.y))
			{
				return _Down;
			}
			return _Left;
		}

		protected virtual string GetDirectionName(int direction)
		{
			Direction direction2 = (Direction)direction;
			return direction2.ToString();
		}

		public AnimationClip GetClip(Direction direction)
		{
			return direction switch
			{
				Direction.Up => _Up, 
				Direction.Right => _Right, 
				Direction.Down => _Down, 
				Direction.Left => _Left, 
				_ => throw AnimancerUtilities.CreateUnsupportedArgumentException(direction), 
			};
		}

		public virtual AnimationClip GetClip(int direction)
		{
			return GetClip((Direction)direction);
		}

		public void SetClip(Direction direction, AnimationClip clip)
		{
			switch (direction)
			{
			case Direction.Up:
				Up = clip;
				break;
			case Direction.Right:
				Right = clip;
				break;
			case Direction.Down:
				Down = clip;
				break;
			case Direction.Left:
				Left = clip;
				break;
			default:
				throw AnimancerUtilities.CreateUnsupportedArgumentException(direction);
			}
		}

		public virtual void SetClip(int direction, AnimationClip clip)
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
				_ => throw AnimancerUtilities.CreateUnsupportedArgumentException(direction), 
			};
		}

		public virtual Vector2 GetDirection(int direction)
		{
			return DirectionToVector((Direction)direction);
		}

		public static Direction VectorToDirection(Vector2 vector)
		{
			if (vector.x >= 0f)
			{
				if (vector.y >= 0f)
				{
					if (!(vector.x > vector.y))
					{
						return Direction.Up;
					}
					return Direction.Right;
				}
				if (!(vector.x > 0f - vector.y))
				{
					return Direction.Down;
				}
				return Direction.Right;
			}
			if (vector.y >= 0f)
			{
				if (!(vector.x < 0f - vector.y))
				{
					return Direction.Up;
				}
				return Direction.Left;
			}
			if (!(vector.x < vector.y))
			{
				return Direction.Down;
			}
			return Direction.Left;
		}

		public static Vector2 SnapVectorToDirection(Vector2 vector)
		{
			float magnitude = vector.magnitude;
			vector = DirectionToVector(VectorToDirection(vector)) * magnitude;
			return vector;
		}

		public virtual Vector2 Snap(Vector2 vector)
		{
			return SnapVectorToDirection(vector);
		}

		public void AddClips(AnimationClip[] clips, int index)
		{
			int clipCount = ClipCount;
			for (int i = 0; i < clipCount; i++)
			{
				clips[index + i] = GetClip(i);
			}
		}

		public void GetAnimationClips(List<AnimationClip> clips)
		{
			int clipCount = ClipCount;
			for (int i = 0; i < clipCount; i++)
			{
				clips.Add(GetClip(i));
			}
		}

		public void AddDirections(Vector2[] directions, int index)
		{
			int clipCount = ClipCount;
			for (int i = 0; i < clipCount; i++)
			{
				directions[index + i] = GetDirection(i);
			}
		}

		public void AddClipsAndDirections(AnimationClip[] clips, Vector2[] directions, int index)
		{
			AddClips(clips, index);
			AddDirections(directions, index);
		}
	}
}
