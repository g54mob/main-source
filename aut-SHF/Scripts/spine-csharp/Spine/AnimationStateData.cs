using System.Collections.Generic;

namespace Spine
{
	public class AnimationStateData
	{
		public struct AnimationPair
		{
			public readonly Animation a1;

			public readonly Animation a2;

			public AnimationPair(Animation a1, Animation a2)
			{
				this.a1 = null;
				this.a2 = null;
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class AnimationPairComparer : IEqualityComparer<AnimationPair>
		{
			public static readonly AnimationPairComparer Instance;

			bool IEqualityComparer<AnimationPair>.Equals(AnimationPair x, AnimationPair y)
			{
				return false;
			}

			int IEqualityComparer<AnimationPair>.GetHashCode(AnimationPair obj)
			{
				return 0;
			}
		}

		internal SkeletonData skeletonData;

		private readonly Dictionary<AnimationPair, float> animationToMixTime;

		internal float defaultMix;

		public SkeletonData SkeletonData => null;

		public float DefaultMix
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimationStateData(SkeletonData skeletonData)
		{
		}

		public void SetMix(string fromName, string toName, float duration)
		{
		}

		public void SetMix(Animation from, Animation to, float duration)
		{
		}

		public float GetMix(Animation from, Animation to)
		{
			return 0f;
		}
	}
}
