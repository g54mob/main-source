using System;
using DG.Tweening;
using DG.Tweening.Core;

namespace VampireSurvivors.App.Tools;

public class UITimerHelper
{
	public const string UI_TIMER_ID = "UI_CUSTOM_TIMER";

	public static Tween RegisterMillis(float duration, TweenCallback onComplete, TweenCallback onUpdate = null, bool isLooped = false)
	{
		//IL_00e5: Expected I4, but got I8
		float delay = duration * 0.001f;
		Tween tween = DOVirtual.DelayedCall(delay, onComplete);
		if (onUpdate != null && tween != null && tween._003Cactive_003Ek__BackingField)
		{
			tween.onUpdate = onUpdate;
		}
		if (isLooped)
		{
			if (tween == null)
			{
				goto IL_0143;
			}
			if (tween._003Cactive_003Ek__BackingField && !tween.creationLocked)
			{
				tween.loops = -1;
				tween.loopType = LoopType.Restart;
				if (((ABSSequentiable)tween).tweenType == TweenType.Tweener)
				{
					tween.fullDuration = 1f / 0f;
				}
			}
		}
		if (tween != null)
		{
			tween.stringId = "UI_CUSTOM_TIMER";
			return tween;
		}
		goto IL_0143;
		IL_0143:
		return (Tween)(object)new NullReferenceException();
	}
}
