using System;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
	public enum FillMode
	{
		Fill = 0,
		Horizontal = 1,
		Vertical = 2
	}

	[SerializeField]
	private FillMode fillMode;

	[SerializeField]
	private float changeDelay;

	[SerializeField]
	private float lerpSpeed = 5f;

	[SerializeField]
	private bool useStandardGradient;

	[SerializeField]
	public bool lerpMovement = true;

	[SerializeField]
	public Gradient gradient;

	[SerializeField]
	public Gradient StandardGradient;

	[SerializeField]
	public Gradient BossGradient;

	private Color imageColor = Color.white;

	private Image image;

	private RectTransform rectTransform;

	[NonSerialized]
	public float value01;

	private float changeTimer;

	private void Awake()
	{
		image = GetComponent<Image>();
		rectTransform = GetComponent<RectTransform>();
		if (useStandardGradient)
		{
			gradient = UIManager.Instance.GradientGYR;
		}
	}

	private void Update()
	{
		changeTimer -= Time.unscaledDeltaTime;
		UpdateFill();
	}

	public void SetValue(float value01)
	{
		if (float.IsNaN(value01))
		{
			value01 = 0f;
		}
		this.value01 = Mathf.Clamp01(value01);
		changeTimer = changeDelay;
	}

	private void UpdateFill()
	{
		if (!(changeTimer > 0f))
		{
			float fillAmount = image.fillAmount;
			switch (fillMode)
			{
			case FillMode.Fill:
				UpdateFillMode(fillAmount);
				break;
			case FillMode.Horizontal:
				UpdateHorizontalMode();
				break;
			case FillMode.Vertical:
				UpdateVerticalMode();
				break;
			}
		}
	}

	private void UpdateFillMode(float current)
	{
		if (lerpMovement)
		{
			image.fillAmount = Mathf.Lerp(current, value01, lerpSpeed * Time.unscaledDeltaTime);
		}
		else
		{
			image.fillAmount = value01;
		}
		image.color = gradient.Evaluate(current);
	}

	private void UpdateHorizontalMode()
	{
		image.color = gradient.Evaluate(value01);
		float num = Mathf.Lerp(0f - rectTransform.rect.width, 0f, value01);
		if (lerpMovement)
		{
			float x = rectTransform.anchoredPosition.x;
			rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(x, num, lerpSpeed * Time.unscaledDeltaTime), rectTransform.anchoredPosition.y);
		}
		else
		{
			rectTransform.anchoredPosition = new Vector2(num, rectTransform.anchoredPosition.y);
		}
	}

	private void UpdateVerticalMode()
	{
		float num = Mathf.Lerp(0f - rectTransform.rect.height, 0f, value01);
		if (lerpMovement)
		{
			float y = rectTransform.anchoredPosition.y;
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, Mathf.Lerp(y, num, lerpSpeed * Time.unscaledDeltaTime));
		}
		else
		{
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, num);
		}
		image.color = gradient.Evaluate(value01);
	}

	public void SetVisible(bool isVisible)
	{
		image.enabled = isVisible;
	}

	public void SetFillMode(FillMode mode)
	{
		fillMode = mode;
	}
}
