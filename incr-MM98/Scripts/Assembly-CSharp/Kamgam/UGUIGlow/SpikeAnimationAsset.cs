using UnityEngine;

namespace Kamgam.UGUIGlow
{
	[CreateAssetMenu(fileName = "UGUI Glow SpikeAnimation", menuName = "UGUI Glow/Animation > Spike", order = 403)]
	public class SpikeAnimationAsset : GlowAnimationAsset
	{
		[SerializeField]
		[Range(-20f, 20f)]
		protected float _speed = 1f;

		[SerializeField]
		[Range(-1f, 20f)]
		protected float _scale = 1f;

		[SerializeField]
		[Range(1f, 10f)]
		protected int _frequency = 1;

		[SerializeField]
		protected SinusMode _sinusMode = SinusMode.ClampPositive;

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
						(_animation as SpikeAnimation).Speed = _speed;
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
						(_animation as SpikeAnimation).Scale = _scale;
					}
				}
			}
		}

		public int Frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				if (_frequency != value)
				{
					_frequency = value;
					if (_animation != null)
					{
						(_animation as SpikeAnimation).Frequency = _frequency;
					}
				}
			}
		}

		public SinusMode SinusMode
		{
			get
			{
				return _sinusMode;
			}
			set
			{
				if (_sinusMode != value)
				{
					_sinusMode = value;
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
			SpikeAnimation animation = getAnimation<SpikeAnimation>(out createdNewCopy);
			if (createdNewCopy)
			{
				copyTo(animation);
			}
			return animation;
		}

		protected void copyTo(SpikeAnimation animation)
		{
			animation.Frequency = Frequency;
			animation.Speed = Speed;
			animation.Scale = Scale;
			animation.SinusMode = SinusMode;
			animation.MoveInside = MoveInside;
		}
	}
}
