using UnityEngine;

public class BoatAnimation : MonoBehaviour
{
	private Vector3 startPosition;

	private Quaternion startRotation;

	private float time;

	[SerializeField]
	private AnimationCurve yOffset;

	[SerializeField]
	private AnimationCurve xRotation;

	[SerializeField]
	private AnimationCurve yRotation;

	[SerializeField]
	private AnimationCurve zRotation;

	private void Start()
	{
		time = Random.value * 10000f;
		startPosition = base.transform.position;
		startRotation = base.transform.rotation;
	}

	private void Update()
	{
		time += Time.deltaTime;
		Quaternion quaternion = Quaternion.Euler(xRotation.Evaluate(time), yRotation.Evaluate(time), zRotation.Evaluate(time));
		base.transform.rotation = startRotation * quaternion;
		base.transform.position = startPosition + Vector3.up * yOffset.Evaluate(time);
	}
}
