using UnityEngine;

public class YRotationPingPong : MonoBehaviour
{
	[Header("World Y rotation offset (degrees)")]
	public float minYOffset = -15f;

	public float maxYOffset = 15f;

	[Tooltip("Time (seconds) to go from min to max")]
	public float duration = 3f;

	private float baseY;

	private Quaternion baseRotation;

	private void Start()
	{
		baseRotation = base.transform.rotation;
		baseY = base.transform.eulerAngles.y;
	}

	private void Update()
	{
		float t = Mathf.PingPong(Time.time / duration, 1f);
		t = Mathf.SmoothStep(0f, 1f, t);
		float num = Mathf.Lerp(minYOffset, maxYOffset, t);
		float y = baseY + num;
		base.transform.rotation = Quaternion.Euler(baseRotation.eulerAngles.x, y, baseRotation.eulerAngles.z);
	}
}
