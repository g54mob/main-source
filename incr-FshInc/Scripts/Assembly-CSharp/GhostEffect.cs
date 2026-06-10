using System;
using DG.Tweening;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
	[Header("References")]
	public SpriteRenderer spriteRenderer;

	[Header("Alpha")]
	[Tooltip("Opacity the ghost fades in to.")]
	[Range(0f, 1f)]
	public float visibleAlpha = 0.5f;

	[Tooltip("Lowest opacity during drift fade.")]
	[Range(0f, 1f)]
	public float driftAlpha = 0.25f;

	[Tooltip("How long the initial fade-in takes.")]
	public float fadeInDuration = 1.5f;

	[Header("Bobbing")]
	[Tooltip("Enable continuous floating bob.")]
	public bool enableBob = true;

	[Tooltip("How fast the bob oscillates.")]
	public float bobSpeed = 0.8f;

	[Tooltip("How much the ghost bobs vertically.")]
	public float bobStrength = 0.3f;

	[Header("Pulse (breathing alpha)")]
	[Tooltip("Enable slow alpha pulse on top of visible alpha.")]
	public bool enablePulse = true;

	[Tooltip("How much the alpha dips during the pulse.")]
	[Range(0f, 0.3f)]
	public float pulseAmount = 0.1f;

	[Tooltip("Duration of one full pulse cycle (seconds).")]
	public float pulseDuration = 3f;

	[Header("Drift Fade")]
	[Tooltip("Enable periodic fade out and back in, like the ghost is phasing.")]
	public bool enableDriftFade = true;

	[Tooltip("Time between drift fades.")]
	public float driftFadeInterval = 4f;

	[Tooltip("How long each drift fade takes (out + in).")]
	public float driftFadeDuration = 2f;

	private float _bobSeed;

	private Tween _pulseTween;

	private Sequence _driftSequence;

	private float _baseAlpha;

	private void Start()
	{
		if (spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
		_bobSeed = UnityEngine.Random.Range(0f, 100f);
		_baseAlpha = visibleAlpha;
		if (spriteRenderer != null)
		{
			Color color = spriteRenderer.color;
			color.a = 0f;
			spriteRenderer.color = color;
			spriteRenderer.DOFade(visibleAlpha, fadeInDuration).SetEase(Ease.InOutSine).OnComplete(StartEffects);
		}
		else
		{
			StartEffects();
		}
	}

	private void StartEffects()
	{
		if (enablePulse)
		{
			StartPulse();
		}
		if (enableDriftFade)
		{
			StartDriftFade();
		}
	}

	private void Update()
	{
		if (enableBob)
		{
			float num = (Mathf.PerlinNoise(Time.time * bobSpeed, _bobSeed) - 0.5f) * bobStrength;
			Vector3 position = base.transform.position;
			position.y += num * Time.deltaTime;
			base.transform.position = position;
		}
	}

	private void StartPulse()
	{
		if (!(spriteRenderer == null))
		{
			float endValue = Mathf.Max(visibleAlpha - pulseAmount, 0f);
			_pulseTween = spriteRenderer.DOFade(endValue, pulseDuration * 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		}
	}

	private void StartDriftFade()
	{
		if (!(spriteRenderer == null))
		{
			_driftSequence = DOTween.Sequence();
			_driftSequence.AppendInterval(driftFadeInterval);
			_driftSequence.Append(spriteRenderer.DOFade(driftAlpha, driftFadeDuration * 0.5f).SetEase(Ease.InOutSine));
			_driftSequence.Append(spriteRenderer.DOFade(visibleAlpha, driftFadeDuration * 0.5f).SetEase(Ease.InOutSine));
			_driftSequence.SetLoops(-1, LoopType.Restart);
		}
	}

	public void Vanish(float duration = 1.5f, Action onComplete = null)
	{
		_pulseTween?.Kill();
		_driftSequence?.Kill();
		if (!(spriteRenderer == null))
		{
			Sequence sequence = DOTween.Sequence();
			float num = duration * 0.5f;
			int num2 = 6;
			float duration2 = num / (float)num2;
			for (int i = 0; i < num2; i++)
			{
				float endValue = ((i % 2 == 0) ? 0.1f : (visibleAlpha * 0.8f));
				sequence.Append(spriteRenderer.DOFade(endValue, duration2).SetEase(Ease.Linear));
			}
			sequence.Append(spriteRenderer.DOFade(0f, duration * 0.5f).SetEase(Ease.InOutSine));
			sequence.OnComplete(delegate
			{
				base.gameObject.SetActive(value: false);
				onComplete?.Invoke();
			});
		}
	}

	public void RiseAndFade(float riseDistance = 3f, float duration = 2f, Action onComplete = null)
	{
		_pulseTween?.Kill();
		_driftSequence?.Kill();
		if (!(spriteRenderer == null))
		{
			Sequence sequence = DOTween.Sequence();
			sequence.Append(base.transform.DOMoveY(base.transform.position.y + riseDistance, duration).SetEase(Ease.InSine));
			sequence.Join(spriteRenderer.DOFade(0f, duration).SetEase(Ease.InQuad));
			sequence.OnComplete(delegate
			{
				base.gameObject.SetActive(value: false);
				onComplete?.Invoke();
			});
		}
	}

	private void OnDisable()
	{
		_pulseTween?.Kill();
		_driftSequence?.Kill();
	}
}
