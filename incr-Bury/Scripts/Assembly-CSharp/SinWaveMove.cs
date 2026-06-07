using UnityEngine;

public class SinWaveMove : MonoBehaviour
{
	[Header("Sine Wave Settings")]
	public float amplitude = 0.5f;

	public float frequency = 1f;

	private Vector3 startLocalPos;

	private void Start()
	{
		startLocalPos = base.transform.localPosition;
	}

	private void Update()
	{
		float num = Mathf.Sin(Time.time * frequency) * amplitude;
		base.transform.localPosition = new Vector3(startLocalPos.x, startLocalPos.y + num, startLocalPos.z);
	}
}
