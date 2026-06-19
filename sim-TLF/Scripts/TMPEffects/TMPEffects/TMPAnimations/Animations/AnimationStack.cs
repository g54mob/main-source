using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

			private Dictionary<int, bool> finishedDict = new Dictionary<int, bool>();

			public IAnimatorContext AnimatorContext => context.AnimatorContext;

			public SegmentData SegmentData => context.SegmentData;

			public object CustomData => customData;

			public AnimContext(IAnimationContext context, object customData)
			{
				this.context = context;
				this.customData = customData;
			}

			public void FinishAnimation(CharData cData)
			{
				finishedDict[cData.info.index] = true;
			}

			public bool Finished(int index)
			{
				return finishedDict[index];
			}

			public bool Finished(CharData cData)
			{
				return finishedDict[cData.info.index];
			}

			public void ResetFinished(CharData cData)
			{
				finishedDict[cData.info.index] = false;
			}
		}

		[Serializable]
		public struct AnimPrefixTuple
		{
			public T animation;

			public string prefix;

			public AnimPrefixTuple(T animation, string prefix)
			{
				this.animation = animation;
				this.prefix = prefix;
			}
		}

		public class Data
		{
			public Dictionary<ITMPAnimation, object> ObjectCache = new Dictionary<ITMPAnimation, object>();

			public Dictionary<ITMPAnimation, IAnimationContext> ContextCache = new Dictionary<ITMPAnimation, IAnimationContext>();
		}

		[SerializeField]
		protected List<AnimPrefixTuple> animations = new List<AnimPrefixTuple>();

		internal List<AnimPrefixTuple> Animations => animations;

		public virtual void Animate(CharData cData, IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			PopulateContextCache(data, context);
			foreach (AnimPrefixTuple animation2 in animations)
			{
				if (animation2.animation != null)
				{
					T animation = animation2.animation;
					animation.Animate(cData, data.ContextCache[animation2.animation]);
				}
			}
		}

		protected void PopulateContextCache(Data data, IAnimationContext context)
		{
			if (data.ContextCache.Count != 0)
			{
				return;
			}
			foreach (AnimPrefixTuple animation in animations)
			{
				if (animation.animation != null)
				{
					AnimContext value = new AnimContext(context, data.ObjectCache[animation.animation]);
					data.ContextCache[animation.animation] = value;
				}
			}
		}

		public object GetNewCustomData()
		{
			Data data = new Data();
			foreach (AnimPrefixTuple animation2 in animations)
			{
				if (animation2.animation != null)
				{
					Dictionary<ITMPAnimation, object> objectCache = data.ObjectCache;
					object key = animation2.animation;
					T animation = animation2.animation;
					objectCache[(ITMPAnimation)key] = animation.GetNewCustomData();
				}
			}
			return data;
		}

		public void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			Data data = customData as Data;
			foreach (AnimPrefixTuple anim in animations)
			{
				if (anim.animation != null)
				{
					ReadOnlyDictionary<string, string> parameters2 = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>(from x in parameters
						where x.Key.StartsWith(anim.prefix)
						select new KeyValuePair<string, string>(x.Key.Substring(anim.prefix.Length), x.Value)));
					T animation = anim.animation;
					animation.SetParameters(data.ObjectCache[anim.animation], parameters2, keywordDatabase);
				}
			}
		}

		public bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			foreach (AnimPrefixTuple anim in animations)
			{
				if (anim.animation != null)
				{
					ReadOnlyDictionary<string, string> parameters2 = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>(from x in parameters
						where x.Key.StartsWith(anim.prefix)
						select new KeyValuePair<string, string>(x.Key.Substring(anim.prefix.Length), x.Value)));
					T animation = anim.animation;
					if (!animation.ValidateParameters(parameters2, keywordDatabase))
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
