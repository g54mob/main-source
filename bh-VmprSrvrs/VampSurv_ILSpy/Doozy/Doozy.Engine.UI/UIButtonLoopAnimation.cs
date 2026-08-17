using System;
using Doozy.Engine.UI.Animation;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI;

[Serializable]
public class UIButtonLoopAnimation
{
	public UIAnimation Animation;

	public bool Enabled;

	public bool IsPlaying;

	public ButtonLoopAnimationType LoopAnimationType;

	public bool LoadSelectedPresetAtRuntime;

	public string PresetCategory;

	public string PresetName;

	public UIButtonLoopAnimation(ButtonLoopAnimationType loopAnimationType)
	{
		LoopAnimationType = loopAnimationType;
		UIAnimation uIAnimation = null;
		uIAnimation.Reset(AnimationType.Loop);
		Animation = uIAnimation;
		IsPlaying = false;
	}

	public void LoadPreset()
	{
		UIAnimations instance = UIAnimations.Instance;
		UIAnimationDatabase uIAnimationDatabase = instance.Loop.Get(PresetCategory);
		UIAnimationData uIAnimationData = uIAnimationDatabase.Get(PresetName);
		if ((object)uIAnimationData != null && ((UnityEngine.Object)uIAnimationData).m_CachedPtr != (IntPtr)0)
		{
			UIAnimation animation = uIAnimationData.Animation.Copy();
			Animation = animation;
		}
	}

	public void LoadPreset(string presetCategory, string presetName)
	{
		UIAnimations instance = UIAnimations.Instance;
		UIAnimationDatabase uIAnimationDatabase = instance.Loop.Get(presetCategory);
		UIAnimationData uIAnimationData = uIAnimationDatabase.Get(presetName);
		if ((object)uIAnimationData != null && ((UnityEngine.Object)uIAnimationData).m_CachedPtr != (IntPtr)0)
		{
			UIAnimation animation = uIAnimationData.Animation.Copy();
			Animation = animation;
		}
	}

	public void Reset(ButtonLoopAnimationType loopAnimationType)
	{
		LoopAnimationType = loopAnimationType;
		UIAnimation uIAnimation = null;
		uIAnimation.Reset(AnimationType.Loop);
		Animation = uIAnimation;
		IsPlaying = false;
	}

	public unsafe void Start(RectTransform target, Vector3 startPosition, Vector3 startRotation)
	{
		//IL_0064: Expected O, but got Ref
		//IL_007c: Expected O, but got Ref
		if (Enabled && Animation != null && !IsPlaying)
		{
			float num = default(float);
			UnityAction onCompleteCallback = default(UnityAction);
			UIAnimator.MoveLoop(target, Animation, (Vector3)(&num), null, onCompleteCallback);
			UIAnimator.RotateLoop(target, Animation, (Vector3)(&num), null, onCompleteCallback);
			UIAnimator.ScaleLoop(target, Animation);
			UIAnimator.FadeLoop(target, Animation);
			IsPlaying = true;
		}
	}

	public void Stop(RectTransform target)
	{
		if (Animation != null && IsPlaying)
		{
			UIAnimator.StopAnimations(target, AnimationType.Loop);
			IsPlaying = false;
		}
	}
}
