using UnityEngine;

public class CameraFloat : MonoBehaviour
{
	public AnimationCurve AnimCurve;

	private Vector3 StartPos;

	private Vector3 CurPos;

	private Vector3 EndPos;

	private Quaternion StartRot;

	private Quaternion CurRot;

	private Quaternion EndRot;

	private float t;

	private float max;

	private void Start()
	{
		StartPos = base.transform.position;
		StartRot = base.transform.rotation;
	}

	private void Update()
	{
		t += Time.deltaTime;
		if (t >= max)
		{
			CurPos = base.transform.position;
			CurRot = base.transform.rotation;
			EndPos = StartPos + Random.insideUnitSphere * Random.Range(0.1f, 0.5f);
			EndRot = StartRot * Quaternion.Euler(Random.Range(-2f, 0f), Random.Range(-2f, 2f), 0f);
			t = 0f;
			max = Random.Range(5f, 10f);
		}
		base.transform.SetPositionAndRotation(Vector3.Lerp(CurPos, EndPos, AnimCurve.Evaluate(t / max)), Quaternion.Lerp(CurRot, EndRot, AnimCurve.Evaluate(t / max)));
	}
}
