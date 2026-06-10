using UnityEngine;

public class AdvanceIndicatorAnimator : MonoBehaviour
{
	public float pulseSpeed = 4f;

	public float scaleAmount = 0.1f;

	private Vector3 originalScale;

	private void Awake()
	{
		originalScale = base.transform.localScale;
	}

	private void Update()
	{
		float num = Mathf.Sin(Time.time * pulseSpeed) * scaleAmount;
		base.transform.localScale = originalScale * (1f + num);
	}
}
