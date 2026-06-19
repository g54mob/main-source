using System;
using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[Serializable]
	internal class AnimationStack<T> : ITMPAnimation, ITMPParameterValidator where T : ITMPAnimation
	{
		public class AnimContext : IAnimationContext, IAnimationData, IAnimationFinished, IAnimationFinisher
		{
			private IAnimationContext context;

			private object customData;

			private Dictionary<int, bool> finishedDict;

			public IAnimatorContext AnimatorContext => null;

			public SegmentData SegmentData => default(SegmentData);

			public object CustomData => null;

			public AnimContext(IAnimationContext context, object customData)
			{
			}

			public void FinishAnimation(CharData cData)
			{
			}

			public bool Finished(int index)
			{
				return false;
			}

			public bool Finished(CharData cData)
			{
				return false;
			}

			public void ResetFinished(CharData cData)
			{
			}
		}

		[Serializable]
		public struct AnimPrefixTuple
		{
			public T animation;

			public string prefix;

			public AnimPrefixTuple(T animation, string prefix)
			{
				this.animation = default(T);
				this.prefix = null;
			}
		}

		public class Data
		{
			public Dictionary<ITMPAnimation, object> ObjectCache;

			public Dictionary<ITMPAnimation, IAnimationContext> ContextCache;
		}

		[SerializeField]
		protected List<AnimPrefixTuple> animations;

		internal List<AnimPrefixTuple> Animations => null;

		public virtual void Animate(CharData cData, IAnimationContext context)
		{
		}

		protected void PopulateContextCache(Data data, IAnimationContext context)
		{
		}

		public object GetNewCustomData()
		{
			return null;
		}

		public void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}

		public bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return false;
		}
	}
}
