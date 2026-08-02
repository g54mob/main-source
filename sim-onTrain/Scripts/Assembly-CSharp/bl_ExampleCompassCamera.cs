using UnityEngine;

public class bl_ExampleCompassCamera : MonoBehaviour
{
	public AnimationCurve Curve;

	public float Speed = 1f;

	private float value;

	private float time;

	private void Update()
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		time += Time.deltaTime * Speed;
		value = Curve.Evaluate(time);
		float y = 360f * value;
		eulerAngles.y = y;
		base.transform.eulerAngles = eulerAngles;
	}
}
