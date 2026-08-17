using System;
using System.Collections.Generic;
using DG.Tweening;

namespace VampireSurvivors.Framework.PhaserTweens;

public class TweenConfig
{
	public object[] targets;

	public float duration;

	public float delay;

	public Ease ease;

	public int repeat;

	public float repeatDelay;

	public bool yoyo;

	public TweenCallback onStart;

	public TweenCallback onComplete;

	public TweenCallback onYoyo;

	public TweenCallback onRepeat;

	public TweenCallback onUpdate;

	public TweenCallback onStop;

	public float? x;

	public float? y;

	public float? localX;

	public float? localY;

	public float? scale;

	public float? scaleX;

	public float? scaleY;

	public float? tileScaleX;

	public float? tileScaleY;

	public float? angle;

	public float? localAngle;

	public RotateMode rotateMode;

	public float? alpha;

	public uint? tint;

	public Dictionary<string, object> custom;

	public Func<int, float> staggerDuration;

	public Func<int, float> staggerDelay;

	public Func<int, float> staggerX;

	public Func<int, float> staggerY;

	public Func<int, float> staggerLocalX;

	public Func<int, float> staggerLocalY;

	public Func<int, float> staggerScale;

	public Func<int, float> staggerScaleX;

	public Func<int, float> staggerScaleY;

	public Func<int, float> staggerAngle;

	public Func<int, float> staggerLocalAngle;

	public Func<int, float> staggerAlpha;

	public TweenConfig()
	{
		object[] array = new object[0];
		targets = array;
		duration = 1000f;
		ease = Ease.Linear;
		rotateMode = RotateMode.FastBeyond360;
	}
}
