using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.TMPAnimations;

namespace TMPEffects.Parameters
{
	internal class OffsetBundleImpl
	{
		private bool cache;

		private ITMPOffsetProvider provider;

		private float uniformity;

		private bool ignoreAnimatorScaling;

		private bool zeroBasedOffset;

		private OffsetCache offsetCache;

		public bool Cache
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ITMPOffsetProvider Provider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Uniformity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IgnoreAnimatorScaling
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ZeroBasedOffset
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void ClearCache()
		{
		}

		public float GetOffset(CharData cData, IAnimatorDataProvider animatorData, ITMPSegmentData segmentData = null)
		{
			return 0f;
		}

		public float GetOffset(CharData cData, IAnimationContext context)
		{
			return 0f;
		}
	}
}
