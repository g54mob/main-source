using UnityEngine;

public class TweenTester : MonoBehaviour
{
	public Vector3 StartPosition = Vector3.zero;

	public Vector3 TargetPosition = Vector3.forward;

	public Vector3 HighestPosition = Vector3.zero;

	public bool Tween;

	[Range(0f, 1f)]
	public float Progress;

	public float Radius = 1f;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.position = AnimationTween.SphericalPositionLerp(StartPosition, TargetPosition, Progress, Radius);
	}
}
