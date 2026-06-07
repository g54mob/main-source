using UnityEngine;

namespace Kamgam.UGUIGlow
{
	[CreateAssetMenu(fileName = "UGUI Glow PulseAnimation", menuName = "UGUI Glow/Animation > Pulse", order = 403)]
	public class PulseAnimationAsset : GlowAnimationAsset
	{
		[SerializeField]
		[Tooltip("Total duration of one pulse cycle (flash + fade) in seconds.")]
		[Range(0.1f, 10f)]
		protected float _pulseDuration = 1f;

		[SerializeField]
		[Tooltip("Duration of the hard flash at the start of the pulse in seconds.")]
		[Range(0.01f, 1f)]
		protected float _flashDuration = 0.05f;

		[SerializeField]
		[Tooltip("Maximum alpha value at the peak of the pulse.")]
		[Range(0f, 1f)]
		protected float _maxAlpha = 1f;

		[SerializeField]
		[Tooltip("Minimum alpha value at the end of the fade.")]
		[Range(0f, 1f)]
		protected float _minAlpha;

		public float PulseDuration
		{
			get
			{
				return _pulseDuration;
			}
			set
			{
				if (_pulseDuration != value)
				{
					_pulseDuration = value;
					if (_animation != null)
					{
						(_animation as PulseAnimation).PulseDuration = _pulseDuration;
					}
				}
			}
		}

		public float FlashDuration
		{
			get
			{
				return _flashDuration;
			}
			set
			{
				if (_flashDuration != value)
				{
					_flashDuration = value;
					if (_animation != null)
					{
						(_animation as PulseAnimation).FlashDuration = _flashDuration;
					}
				}
			}
		}

		public float MaxAlpha
		{
			get
			{
				return _maxAlpha;
			}
			set
			{
				if (_maxAlpha != value)
				{
					_maxAlpha = value;
					if (_animation != null)
					{
						(_animation as PulseAnimation).MaxAlpha = _maxAlpha;
					}
				}
			}
		}

		public float MinAlpha
		{
			get
			{
				return _minAlpha;
			}
			set
			{
				if (_minAlpha != value)
				{
					_minAlpha = value;
					if (_animation != null)
					{
						(_animation as PulseAnimation).MinAlpha = _minAlpha;
					}
				}
			}
		}

		public override IGlowAnimation GetAnimation()
		{
			bool createdNewCopy;
			PulseAnimation animation = getAnimation<PulseAnimation>(out createdNewCopy);
			if (createdNewCopy)
			{
				copyTo(animation);
			}
			return animation;
		}

		protected void copyTo(PulseAnimation animation)
		{
			animation.PulseDuration = PulseDuration;
			animation.FlashDuration = FlashDuration;
			animation.MaxAlpha = MaxAlpha;
			animation.MinAlpha = MinAlpha;
		}
	}
}
