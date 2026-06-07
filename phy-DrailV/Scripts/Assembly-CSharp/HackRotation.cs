using UnityEngine;

public class HackRotation : MonoBehaviour
{
	private const float OTHER_SCREW_PIVOT_ANGLE_THRESHOLD = -10f;

	public float angleThreshold = 89f;

	public float lerp = 0.03f;

	public Quaternion targetLocalRot;

	public Transform otherScrewPivot;

	[Header("Debug")]
	public bool engaged;

	public float angleDiff;

	private void Update()
	{
		angleDiff = Mathf.Abs(Quaternion.Angle(base.transform.localRotation, targetLocalRot));
		float num = otherScrewPivot.localRotation.eulerAngles.x;
		if (num > 180f)
		{
			num -= 360f;
		}
		engaged = angleDiff > angleThreshold && num < -10f;
		if (engaged)
		{
			base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, targetLocalRot, lerp);
		}
	}
}
