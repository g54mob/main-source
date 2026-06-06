using UnityEngine;

namespace Kamgam.UGUIGlow
{
	[CreateAssetMenu(fileName = "UGUI Glow JitterAnimation", menuName = "UGUI Glow/Animation > Jitter", order = 403)]
	public class JitterAnimationAsset : GlowAnimationAsset
	{
		[SerializeField]
		[Range(0f, 10f)]
		protected float _speed = 1f;

		[SerializeField]
		[Range(-1f, 20f)]
		protected float _scale = 1f;

		[SerializeField]
		[Tooltip("EXPERIMENTAL: If enabled then it moves the inside vertices too.")]
		protected bool _moveInside;

		public float Speed
		{
			get
			{
				return _speed;
			}
			set
			{
				if (_speed != value)
				{
					_speed = value;
					if (_animation != null)
					{
						(_animation as JitterAnimation).Speed = _speed;
					}
				}
			}
		}

		public float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				if (_scale != value)
				{
					_scale = value;
					if (_animation != null)
					{
						(_animation as JitterAnimation).Scale = _scale;
					}
				}
			}
		}

		public bool MoveInside
		{
			get
			{
				return _moveInside;
			}
			set
			{
				if (_moveInside != value)
				{
					_moveInside = value;
				}
			}
		}

		public override IGlowAnimation GetAnimation()
		{
			bool createdNewCopy;
			JitterAnimation animation = getAnimation<JitterAnimation>(out createdNewCopy);
			if (createdNewCopy)
			{
				copyTo(animation);
			}
			return animation;
		}

		protected void copyTo(JitterAnimation animation)
		{
			animation.Speed = Speed;
			animation.Scale = Scale;
			animation.MoveInside = MoveInside;
		}
	}
}
