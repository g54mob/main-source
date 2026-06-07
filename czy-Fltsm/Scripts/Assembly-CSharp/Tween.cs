using UnityEngine;

public class Tween : MonoBehaviour
{
	[SerializeReference]
	[InstantiateSerializeReference]
	private ITweenPropertyTweener[] _propertyTweeners;

	[SerializeField]
	private Easing _easing;

	[SerializeField]
	private float _duration;

	[SerializeField]
	private bool _useUnscaledTime;

	[SerializeField]
	private bool _overrideInverse;

	[SerializeField]
	[ConditionalHide("_overrideInverse", HideInInspector = true)]
	private Easing _inverseEasing;

	[SerializeField]
	[ConditionalHide("_overrideInverse", HideInInspector = true)]
	private float _inverseDuration;

	public void Play(bool invert = false)
	{
		ITweenPropertyTweener[] propertyTweeners = _propertyTweeners;
		for (int i = 0; i < propertyTweeners.Length; i++)
		{
			propertyTweeners[i].Initialize(invert);
		}
		if (invert && _overrideInverse)
		{
			float inverseDuration = _inverseDuration;
			Easing inverseEasing = _inverseEasing;
			bool useUnscaledTime = _useUnscaledTime;
			IPropertyTweener[] propertyTweeners2 = _propertyTweeners;
			Tweener.StartTween(inverseDuration, inverseEasing, useUnscaledTime, propertyTweeners2);
		}
		else
		{
			float duration = _duration;
			Easing easing = _easing;
			bool useUnscaledTime2 = _useUnscaledTime;
			IPropertyTweener[] propertyTweeners2 = _propertyTweeners;
			Tweener.StartTween(duration, easing, useUnscaledTime2, propertyTweeners2);
		}
	}
}
