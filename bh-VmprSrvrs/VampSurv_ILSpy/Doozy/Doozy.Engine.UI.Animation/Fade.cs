using System;
using DG.Tweening;
using UnityEngine;

namespace Doozy.Engine.UI.Animation;

[Serializable]
public class Fade
{
	public AnimationType AnimationType;

	public bool Enabled;

	public float From;

	public float To;

	public float By;

	public bool UseCustomFromAndTo;

	public int NumberOfLoops;

	public LoopType LoopType;

	public EaseType EaseType;

	public Ease Ease;

	public AnimationCurve AnimationCurve;

	public float StartDelay;

	public float Duration;

	public float TotalDuration => Duration + StartDelay;

	public Fade(AnimationType animationType)
	{
		//IL_0061: Expected I4, but got I8
		AnimationType = animationType;
		From = 0f;
		UseCustomFromAndTo = false;
		Enabled = false;
		By = 0.5f;
		NumberOfLoops = -1;
		LoopType = LoopType.Yoyo;
		Ease = Ease.Linear;
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create((Keyframe[])null);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		AnimationCurve = animationCurve;
		StartDelay = 0f;
		Duration = 1f;
	}

	public Fade(AnimationType animationType, bool enabled, float from, float to, float by, bool useCustomFromAndTo, int numberOfLoops, LoopType loopType, EaseType easeType, Ease ease, AnimationCurve animationCurve, float startDelay, float duration)
	{
		//IL_0080: Expected I4, but got O
		//IL_008a: Expected I4, but got F4
		//IL_0094: Expected I4, but got F4
		//IL_00bc: Expected F4, but got I4
		//IL_00c6: Expected F4, but got I4
		this._002Ector(animationType);
		UseCustomFromAndTo = (byte)(int)animationCurve != 0;
		NumberOfLoops = (int)startDelay;
		LoopType = (LoopType)duration;
		IntPtr intPtr = default(IntPtr);
		EaseType = (EaseType)(nint)intPtr;
		Ease ease2 = default(Ease);
		Ease = ease2;
		From = from;
		To = (float)easeType;
		By = (float)ease;
		AnimationType = animationType;
		Enabled = enabled;
		AnimationCurve animationCurve2 = default(AnimationCurve);
		Keyframe[] keys = animationCurve2.GetKeys();
		AnimationCurve = new AnimationCurve
		{
			m_Ptr = AnimationCurve.Internal_Create(keys),
			m_RequiresNativeCleanup = true
		};
		float startDelay2 = default(float);
		StartDelay = startDelay2;
		float duration2 = default(float);
		Duration = duration2;
	}

	public void Reset(AnimationType animationType)
	{
		//IL_0061: Expected I4, but got I8
		AnimationType = animationType;
		From = 0f;
		UseCustomFromAndTo = false;
		Enabled = false;
		By = 0.5f;
		NumberOfLoops = -1;
		LoopType = LoopType.Yoyo;
		Ease = Ease.Linear;
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create((Keyframe[])null);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		AnimationCurve = animationCurve;
		StartDelay = 0f;
		Duration = 1f;
	}

	public Fade Copy()
	{
		Fade fade = new Fade(AnimationType);
		if (fade != null)
		{
			fade.AnimationType = AnimationType;
			fade.Enabled = Enabled;
			fade.From = From;
			fade.To = To;
			fade.By = By;
			fade.UseCustomFromAndTo = UseCustomFromAndTo;
			fade.NumberOfLoops = NumberOfLoops;
			fade.LoopType = LoopType;
			fade.EaseType = EaseType;
			fade.Ease = Ease;
			if (AnimationCurve != null)
			{
				Keyframe[] keys = AnimationCurve.GetKeys();
				AnimationCurve animationCurve = new AnimationCurve();
				IntPtr ptr = AnimationCurve.Internal_Create(keys);
				animationCurve.m_Ptr = ptr;
				animationCurve.m_RequiresNativeCleanup = true;
				fade.AnimationCurve = animationCurve;
				fade.StartDelay = StartDelay;
				fade.Duration = Duration;
				return fade;
			}
		}
		return (Fade)(object)new NullReferenceException();
	}
}
