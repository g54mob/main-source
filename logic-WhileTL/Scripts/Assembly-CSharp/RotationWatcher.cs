using UnityEngine;

public class RotationWatcher : MonoBehaviour
{
	private const float CIRCLE = 360f;

	public float SegmentSize = 30f;

	public float OffsetSize = 15f;

	public Transform MovablePart;

	public Transform StaticPart;

	private float[] _timings = new float[0];

	public float[] Timings => _timings;

	public void Clear()
	{
		for (int i = 0; i < _timings.Length; i++)
		{
			_timings[i] = 0f;
		}
	}

	private void Start()
	{
		_timings = new float[Mathf.CeilToInt(360f / SegmentSize)];
	}

	private void FixedUpdate()
	{
		if (StaticPart != null && MovablePart != null)
		{
			Vector3 normalized = Vector3.ProjectOnPlane(MovablePart.forward, StaticPart.up).normalized;
			float num = Vector3.Angle(StaticPart.forward, normalized);
			int num2 = Mathf.CeilToInt(Mathf.Max(0f, Vector3.Dot(normalized, StaticPart.right)));
			float num3 = num * (float)(1 - num2) + (float)num2 * (360f - num) + OffsetSize;
			if (num3 > 360f)
			{
				num3 -= 360f;
			}
			int num4 = Mathf.FloorToInt(num3 / SegmentSize);
			_timings[num4] += Time.fixedDeltaTime;
		}
	}
}
