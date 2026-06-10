using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnomalyMeterUI : MonoBehaviour
{
	[Tooltip("The 4 Image segments of the meter, in order (0→3).")]
	public Image[] segments = new Image[4];

	[Header("Fill Animation")]
	[Tooltip("Base filled color at segment 0 (darkest).")]
	public Color filledColorStart = new Color(0.4f, 0.18f, 0f, 1f);

	[Tooltip("Final filled color at the last segment (brightest).")]
	public Color filledColorEnd = new Color(1f, 0.55f, 0f, 1f);

	[Tooltip("How long the bounce + color tween takes.")]
	public float fillDuration = 0.45f;

	[Tooltip("Overshoot scale multiplier for the bounce.")]
	public float bounceScale = 1.35f;

	[Tooltip("Color multiplier applied at peak of bounce (shader boost look).")]
	public float peakBrightness = 1.6f;

	public static AnomalyMeterUI Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		base.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void AnimateFill(int segmentIndex, int totalSegments)
	{
		if (segmentIndex >= 0 && segmentIndex < segments.Length)
		{
			Image image = segments[segmentIndex];
			if (!(image == null))
			{
				image.DOKill();
				image.transform.DOKill();
				float t = ((totalSegments <= 1) ? 1f : ((float)segmentIndex / (float)(totalSegments - 1)));
				Color color = Color.Lerp(filledColorStart, filledColorEnd, t);
				Color endValue = color * peakBrightness;
				endValue.a = 1f;
				image.color = color * 0.3f;
				Sequence sequence = DOTween.Sequence();
				image.transform.localScale = Vector3.one;
				sequence.Append(image.transform.DOScale(Vector3.one * bounceScale, fillDuration * 0.35f).SetEase(Ease.OutQuad));
				sequence.Append(image.transform.DOScale(Vector3.one, fillDuration * 0.65f).SetEase(Ease.OutBounce));
				Sequence sequence2 = DOTween.Sequence();
				sequence2.Append(image.DOColor(endValue, fillDuration * 0.3f).SetEase(Ease.OutQuad));
				sequence2.Append(image.DOColor(color, fillDuration * 0.7f).SetEase(Ease.OutQuart));
				sequence.Join(sequence2);
				sequence.SetLink(image.gameObject);
			}
		}
	}

	public void SetFilled(int segmentIndex, int totalSegments)
	{
		if (segmentIndex >= 0 && segmentIndex < segments.Length)
		{
			Image image = segments[segmentIndex];
			if (!(image == null))
			{
				float t = ((totalSegments <= 1) ? 1f : ((float)segmentIndex / (float)(totalSegments - 1)));
				image.color = Color.Lerp(filledColorStart, filledColorEnd, t);
				image.transform.localScale = Vector3.one;
			}
		}
	}

	public void SetEmpty(int segmentIndex, Color emptyColor)
	{
		if (segmentIndex >= 0 && segmentIndex < segments.Length)
		{
			Image image = segments[segmentIndex];
			if (!(image == null))
			{
				image.DOKill();
				image.transform.DOKill();
				image.color = emptyColor;
				image.transform.localScale = Vector3.one;
			}
		}
	}
}
