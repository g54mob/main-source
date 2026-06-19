using UnityEngine;

public class TestTicks : MonoBehaviour
{
	public Transform t1;

	public Transform t2;

	public float spinTime;

	public float distance = 20f;

	public float duration = 10f;

	private Vector3 _origPosT1;

	private Vector3 _origPosT2;

	private void Awake()
	{
		_origPosT1 = t1.position;
		_origPosT2 = t2.position;
	}

	private void FixedUpdate()
	{
		t1.position = _origPosT1 + Vector3.right * distance * (Mathf.Repeat(Time.time, duration) / duration);
	}

	private void Update()
	{
		t2.position = _origPosT2 + Vector3.right * distance * (Mathf.Repeat(Time.fixedTime, duration) / duration);
		double num = Time.realtimeSinceStartupAsDouble + (double)(spinTime / 1000f);
		while (Time.realtimeSinceStartupAsDouble < num)
		{
		}
	}
}
