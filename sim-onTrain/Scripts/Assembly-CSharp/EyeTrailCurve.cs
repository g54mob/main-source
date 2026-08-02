using UnityEngine;

public class EyeTrailCurve : MonoBehaviour
{
	[Header("Curve Settings")]
	public float sideOffset = 1f;

	public float curveDistance = 3f;

	public AnimationCurve sidewaysCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

	public Vector3 curveDirection = Vector3.right;

	[Header("References")]
	public Transform zombieHead;

	private Vector3 startOffset;

	private float timeElapsed;

	private void Start()
	{
		SetupStartPosition();
	}

	private void SetupStartPosition()
	{
		if (!(zombieHead == null))
		{
			startOffset = curveDirection * sideOffset;
			base.transform.position = zombieHead.position + startOffset;
		}
	}

	private void Update()
	{
		if (!(zombieHead == null))
		{
			timeElapsed += Time.deltaTime;
			Vector3 forward = zombieHead.forward;
			float time = timeElapsed * 2f % 1f;
			float num = sidewaysCurve.Evaluate(time) * sideOffset;
			Vector3 b = zombieHead.position + forward * curveDistance + curveDirection * num;
			base.transform.position = Vector3.Lerp(base.transform.position, b, Time.deltaTime * 5f);
		}
	}
}
