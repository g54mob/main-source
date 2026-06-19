using System.Collections.Generic;
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
				return cache;
			}
			set
			{
				cache = value;
			}
		}

		public ITMPOffsetProvider Provider
		{
			get
			{
				return provider;
			}
			set
			{
				provider = value;
				ClearCache();
			}
		}

		public float Uniformity
		{
			get
			{
				return uniformity;
			}
			set
			{
				uniformity = value;
				ClearCache();
			}
		}

		public bool IgnoreAnimatorScaling
		{
			get
			{
				return ignoreAnimatorScaling;
			}
			set
			{
				ignoreAnimatorScaling = value;
				ClearCache();
			}
		}

		public bool ZeroBasedOffset
		{
			get
			{
				return zeroBasedOffset;
			}
			set
			{
				zeroBasedOffset = value;
				ClearCache();
			}
		}

		public void ClearCache()
		{
			offsetCache.ClearCache();
		}

		public OffsetBundleImpl()
		{
			offsetCache = default(OffsetCache);
			offsetCache.offset = new Dictionary<CharData, float>();
		}

		public float GetOffset(CharData cData, IAnimatorDataProvider animatorData, ITMPSegmentData segmentData = null)
		{
			if (Cache && offsetCache.GetOffset(cData, out var cOffset))
			{
				return cOffset;
			}
			if (segmentData == null)
			{
				segmentData = TMPAnimationUtility.GetMockedSegment(animatorData.Animator.TextComponent.GetParsedText().Length, animatorData.Animator.CharData);
			}
			cOffset = Provider.GetOffset(cData, segmentData, animatorData, IgnoreAnimatorScaling);
			if (ZeroBasedOffset)
			{
				float min;
				float max;
				if (Cache)
				{
					if (!offsetCache.GetMinMaxOffset(out min, out max))
					{
						Provider.GetMinMaxOffset(out min, out max, segmentData, animatorData);
						offsetCache.CacheMinMax(min, max);
					}
				}
				else
				{
					Provider.GetMinMaxOffset(out min, out max, segmentData, animatorData);
				}
				float num = cOffset - min;
				float num2 = max - min;
				cOffset = ((!(Uniformity >= 0f)) ? (num2 - num) : num);
			}
			cOffset *= Uniformity;
			if (Cache)
			{
				offsetCache.CacheOffset(cData, cOffset);
			}
			return cOffset;
		}

		public float GetOffset(CharData cData, IAnimationContext context)
		{
			return GetOffset(cData, context.AnimatorContext, context.SegmentData);
		}
	}
}
