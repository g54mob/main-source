using System;
using UnityEngine;
using UnityEngine.Animations;

namespace GameCreator.Runtime.Characters.Animim
{
	public class GesturePlayableBehaviour : TAnimimPlayableBehaviour
	{
		[field: NonSerialized]
		internal int AnimationClipHash { get; }

		public GesturePlayableBehaviour(AnimationClip animationClip, AvatarMask avatarMask, BlendMode blendMode, AnimimGraph animimGraph, ConfigGesture config)
			: base(avatarMask, blendMode, animimGraph, config)
		{
			AnimationClipHash = animationClip.GetHashCode();
			base.AnimatorPlayable = AnimatorControllerPlayable.Create(animimGraph.Graph, TAnimimPlayableBehaviour.CreateController(animationClip));
		}

		public GesturePlayableBehaviour()
			: base(null, BlendMode.Blend, null, null)
		{
		}
	}
}
