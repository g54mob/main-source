using UnityEngine;
using UnityEngine.UI;

public class SmoothScrollRect : MonoBehaviour
{
	public ScrollRect scrollRect;

	public float smoothSpeed = 10f;

	private float targetPosition;

	private void Start()
	{
		if (scrollRect == null)
		{
			scrollRect = GetComponent<ScrollRect>();
		}
		targetPosition = scrollRect.verticalNormalizedPosition;
	}

	private void Update()
	{
		scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition, targetPosition, Time.deltaTime * smoothSpeed);
	}

	public void ScrollTo(float normalizedPos)
	{
		targetPosition = Mathf.Clamp01(normalizedPos);
	}
}
