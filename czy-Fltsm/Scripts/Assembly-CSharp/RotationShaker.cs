using System.Collections;
using UnityEngine;

public class RotationShaker : MonoBehaviour
{
	[Range(0f, 2.5f)]
	[SerializeField]
	private float _maxRotation;

	[Range(0f, 1f)]
	[SerializeField]
	private float _rotationDuration;

	[EnumFlag(0)]
	[SerializeField]
	private TransformLocalEulerAnglesTweener.Axis _rotationAxis;

	[SerializeField]
	private bool _debug;

	private void Start()
	{
		if (_debug)
		{
			StartCoroutines(float.MaxValue);
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	public IEnumerator ShakeCoroutine(float duration)
	{
		StartCoroutines(duration);
		yield return new WaitForSeconds(duration);
	}

	private void StartCoroutines(float duration)
	{
		if ((_rotationAxis & TransformLocalEulerAnglesTweener.Axis.X) == TransformLocalEulerAnglesTweener.Axis.X)
		{
			StartCoroutine(ShakeAxisCoroutine(TransformLocalEulerAnglesTweener.Axis.X, duration));
		}
		if ((_rotationAxis & TransformLocalEulerAnglesTweener.Axis.Y) == TransformLocalEulerAnglesTweener.Axis.Y)
		{
			StartCoroutine(ShakeAxisCoroutine(TransformLocalEulerAnglesTweener.Axis.Y, duration));
		}
		if ((_rotationAxis & TransformLocalEulerAnglesTweener.Axis.Z) == TransformLocalEulerAnglesTweener.Axis.Z)
		{
			StartCoroutine(ShakeAxisCoroutine(TransformLocalEulerAnglesTweener.Axis.Z, duration));
		}
	}

	private IEnumerator ShakeAxisCoroutine(TransformLocalEulerAnglesTweener.Axis axis, float duration)
	{
		float targetRotation = Random.Range(0f - _maxRotation, _maxRotation);
		float time = 0f;
		for (duration -= _rotationDuration; time < duration; time += _rotationDuration)
		{
			yield return Tweener.TweenRoutine(_rotationDuration, EasingFunctions.SineInOut, false, new TransformLocalEulerAnglesTweener(base.transform, targetRotation, axis));
			targetRotation = ((!(targetRotation < 0f)) ? Random.Range(0f, 0f - _maxRotation) : Random.Range(0f, _maxRotation));
		}
		yield return Tweener.TweenRoutine(_rotationDuration, EasingFunctions.SineInOut, false, new TransformLocalEulerAnglesTweener(base.transform, 0f, axis));
	}

	public void InterruptShaking()
	{
		StopAllCoroutines();
		TransformLocalEulerAnglesTweener.Axis axis = (TransformLocalEulerAnglesTweener.Axis)7;
		Tweener.TweenRoutine(_rotationDuration, EasingFunctions.SineInOut, false, new TransformLocalEulerAnglesTweener(base.transform, 0f, axis));
	}
}
