using System;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
	public enum Reveal
	{
		None = 0,
		SpinUp = 1,
		SlideUp = 2
	}

	public Reveal reveal;

	public float openDuration;

	public float closeDuration;

	public float slideUpDist;

	public Image backImage;

	public float backAlphaMax;

	public RectTransform foreTransform;

	public bool resetInitialFocusOnOpen;

	public string openSoundId = "popup-open";

	public string closeSoundId = "popup-close";

	[Readonly]
	public PageTemplate pageTemplate;

	private Vector2 originalForePosition;

	private bool initted;

	public bool interactable
	{
		get
		{
			return pageTemplate != null && pageTemplate.interactable;
		}
		set
		{
			if (pageTemplate != null)
			{
				pageTemplate.interactable = value;
			}
		}
	}

	public float revealT
	{
		set
		{
			if (reveal == Reveal.SpinUp)
			{
				backImage.color = new Color(0f, 0f, 1f, value * backAlphaMax);
				float num = (float)Math.PI * 3f / 4f;
				float f = Util.LerpScale(value, 0.4f, 1f, 0f, num);
				float num2 = Mathf.Sin(f) / Mathf.Sin(num);
				float z = ((!(num2 <= 0f)) ? (-2f * (1f - num2)) : (-180f));
				float y = ((!(num2 <= 0f)) ? (-20f * (1f - num2)) : (-365f));
				foreTransform.localRotation = Quaternion.Euler(0f, 0f, z);
				foreTransform.anchoredPosition = new Vector2(foreTransform.anchoredPosition.x, y);
			}
			else if (reveal == Reveal.SlideUp)
			{
				Vector2 anchoredPosition = originalForePosition + new Vector2(0f, Mathf.Lerp(slideUpDist, 0f, value));
				foreTransform.anchoredPosition = anchoredPosition;
			}
		}
	}

	private void OnEnable()
	{
		if (!initted)
		{
			if (foreTransform != null)
			{
				originalForePosition = foreTransform.anchoredPosition;
			}
			initted = true;
		}
		if (resetInitialFocusOnOpen && pageTemplate != null)
		{
			pageTemplate.SetInitialFocus(pageTemplate.initialFocusPreferredSide);
		}
	}
}
