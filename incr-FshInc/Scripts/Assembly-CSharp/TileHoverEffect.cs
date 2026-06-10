using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TileHoverEffect : MonoBehaviour
{
	[Header("Stage 1: Immediate Effect")]
	[SerializeField]
	private SpriteRenderer tileSpriteRenderer;

	[SerializeField]
	private Color hoverColor = new Color(1.2f, 1.2f, 1.2f);

	[Header("Stage 2: Delayed Effect")]
	[SerializeField]
	private SpriteRenderer delayedVisualsSprite;

	[SerializeField]
	private float hoverDelay = 0.25f;

	[SerializeField]
	private float fadeDuration = 0.5f;

	[SerializeField]
	private float scaleValue = 1f;

	private Color originalColor;

	private Coroutine hoverCoroutine;

	private Tween fadeTween;

	private void Start()
	{
		if (tileSpriteRenderer != null)
		{
			originalColor = tileSpriteRenderer.color;
		}
		if (delayedVisualsSprite != null)
		{
			Color color = delayedVisualsSprite.color;
			color.a = 0f;
			delayedVisualsSprite.color = color;
			delayedVisualsSprite.gameObject.SetActive(value: true);
		}
	}

	private void OnMouseEnter()
	{
		if (hoverCoroutine != null)
		{
			StopCoroutine(hoverCoroutine);
		}
		fadeTween?.Kill();
		if (delayedVisualsSprite != null)
		{
			delayedVisualsSprite.DOFade(0f, 0f);
		}
		if ((!(FishingManager.Instance != null) || !FishingManager.Instance.IsFishing()) && (!(DialogueManager.Instance != null) || !DialogueManager.Instance.isCutsceneActive) && (!(CutsceneManager.Instance != null) || !CutsceneManager.Instance.IsBlockingFishing) && !PlayerManager.IsDemoFinished && !EndOfGamePanel.IsVisible)
		{
			if (tileSpriteRenderer != null)
			{
				tileSpriteRenderer.DOKill();
				tileSpriteRenderer.DOColor(hoverColor, 0.1f);
			}
			hoverCoroutine = StartCoroutine(DelayedHoverEffect());
		}
	}

	private void OnMouseExit()
	{
		if (hoverCoroutine != null)
		{
			StopCoroutine(hoverCoroutine);
		}
		if (tileSpriteRenderer != null)
		{
			tileSpriteRenderer.DOKill();
			tileSpriteRenderer.DOColor(originalColor, 0.1f);
		}
		if (delayedVisualsSprite != null)
		{
			fadeTween?.Kill();
			fadeTween = delayedVisualsSprite.DOFade(0f, 0.2f);
		}
	}

	private IEnumerator DelayedHoverEffect()
	{
		yield return new WaitForSeconds(hoverDelay);
		if ((!(FishingManager.Instance != null) || !FishingManager.Instance.IsFishing()) && (!(CutsceneManager.Instance != null) || !CutsceneManager.Instance.IsBlockingFishing) && !EndOfGamePanel.IsVisible && delayedVisualsSprite != null)
		{
			fadeTween?.Kill();
			fadeTween = delayedVisualsSprite.DOFade(scaleValue, fadeDuration).SetEase(Ease.OutQuad);
		}
	}
}
