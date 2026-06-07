using System;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;

namespace VampireSurvivors.Framework.PhaserTweens
{
	public class TweenConfig
	{
		public object[] targets;

		public float duration;

		public float delay;

		public Ease ease;

		public int repeat;

		public float repeatDelay;

		public bool yoyo;

		[CanBeNull]
		public TweenCallback onStart;

		[CanBeNull]
		public TweenCallback onComplete;

		[CanBeNull]
		public TweenCallback onYoyo;

		[CanBeNull]
		public TweenCallback onRepeat;

		[CanBeNull]
		public TweenCallback onUpdate;

		[CanBeNull]
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

		[CanBeNull]
		public Func<int, float> staggerDuration;

		[CanBeNull]
		public Func<int, float> staggerDelay;

		[CanBeNull]
		public Func<int, float> staggerX;

		[CanBeNull]
		public Func<int, float> staggerY;

		[CanBeNull]
		public Func<int, float> staggerLocalX;

		[CanBeNull]
		public Func<int, float> staggerLocalY;

		[CanBeNull]
		public Func<int, float> staggerScale;

		[CanBeNull]
		public Func<int, float> staggerScaleX;

		[CanBeNull]
		public Func<int, float> staggerScaleY;

		[CanBeNull]
		public Func<int, float> staggerAngle;

		[CanBeNull]
		public Func<int, float> staggerLocalAngle;

		[CanBeNull]
		public Func<int, float> staggerAlpha;
	}
}
