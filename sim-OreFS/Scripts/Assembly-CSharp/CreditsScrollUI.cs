using UnityEngine;

public class CreditsScrollUI : MonoBehaviour
{
	[SerializeField]
	private RectTransform creditsContent;

	[SerializeField]
	private float durationMultiplier = 0.03f;

	private float scrollDuration;

	private float elapsed;

	private bool isScrolling;

	private void OnEnable()
	{
		StartScroll();
	}

	public void StartScroll()
	{
		if (!(creditsContent == null))
		{
			creditsContent.anchorMin = new Vector2(0.5f, 0f);
			creditsContent.anchorMax = new Vector2(0.5f, 0f);
			creditsContent.pivot = new Vector2(0.5f, 1f);
			creditsContent.anchoredPosition = Vector2.zero;
			float height = creditsContent.rect.height;
			scrollDuration = height * durationMultiplier;
			elapsed = 0f;
			isScrolling = true;
		}
	}

	private void Update()
	{
		if (isScrolling && !(creditsContent == null))
		{
			elapsed += Time.unscaledDeltaTime;
			float num = Mathf.Clamp01(elapsed / scrollDuration);
			creditsContent.anchorMin = new Vector2(0.5f, num);
			creditsContent.anchorMax = new Vector2(0.5f, num);
			creditsContent.pivot = new Vector2(0.5f, 1f - num);
			creditsContent.anchoredPosition = Vector2.zero;
			if (num >= 1f)
			{
				StartScroll();
			}
		}
	}
}
