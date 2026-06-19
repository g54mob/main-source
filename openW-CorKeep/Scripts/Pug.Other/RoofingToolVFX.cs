using UnityEngine;

public class RoofingToolVFX : MonoBehaviour
{
	public Transform segment1;

	public Transform segment1_cap;

	public Transform segment2;

	public Transform segment2_cap;

	public Transform segment3;

	public Transform segment3_cap;

	public Transform hand;

	[Space(10f)]
	public float retractedSegmentLength = 0.0625f;

	public float extendedSegmentLength = 1f;

	public AnimationCurve animation = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	private float m_animationStartTime;

	private void OnEnable()
	{
		m_animationStartTime = -1f;
		SetAnimationTime(0f);
	}

	public void PlayAnimation()
	{
		m_animationStartTime = Time.time;
	}

	private void LateUpdate()
	{
		if (m_animationStartTime > 0f)
		{
			SetAnimationTime(Time.time - m_animationStartTime);
		}
	}

	private void SetAnimationTime(float time)
	{
		float num = Mathf.LerpUnclamped(retractedSegmentLength, extendedSegmentLength, animation.Evaluate(time));
		segment1.localScale = new Vector3(1f, num, 1f);
		segment1_cap.transform.localPosition = new Vector3(0f, num, 0f);
		segment2.transform.localPosition = new Vector3(0f, num, 0f);
		segment2.localScale = new Vector3(1f, num, 1f);
		segment2_cap.transform.localPosition = new Vector3(0f, num * 2f, 0f);
		segment3.transform.localPosition = new Vector3(0f, num * 2f, 0f);
		segment3.localScale = new Vector3(1f, num, 1f);
		segment3_cap.transform.localPosition = new Vector3(0f, num * 3f, 0f);
		hand.transform.localPosition = new Vector3(0f, num * 3f, 0f);
	}
}
