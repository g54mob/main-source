using System;
using Pug.UnityExtensions;
using UnityEngine;

public class TransformTranslator : MonoBehaviour
{
	public Vector2 amplitude = new Vector2(0f, 3f);

	public float cycleDuration = 5f;

	public Tween.Easing.EasingType easingFunctionType;

	public bool pingPong = true;

	private TimerSimple loopTimer;

	private Vector2 origin;

	private Func<float, float> easingFunction;

	private void Awake()
	{
		loopTimer = new TimerSimple(cycleDuration);
		origin = base.transform.position;
		easingFunction = Tween.Easing.GetFunctionByEasingType(easingFunctionType);
	}

	private void Start()
	{
		loopTimer.Start();
	}

	private void FixedUpdate()
	{
		float arg = (pingPong ? loopTimer.elapsedRatioLoopingPingPong : loopTimer.elapsedRatioLooping);
		base.transform.position = origin + easingFunction(arg) * amplitude;
	}
}
