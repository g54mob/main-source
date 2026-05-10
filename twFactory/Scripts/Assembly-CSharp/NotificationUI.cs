using DG.Tweening;
using TMPro;
using UnityEngine;

public class NotificationUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI text;

	[SerializeField]
	private float fadeTime = 0.5f;

	private CanvasGroup canvasGroup;

	private Tween appearTween;

	private Tween fadeTween;

	private AutoTransformRebuild transformRebuild;

	private void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup.alpha = 0f;
		transformRebuild = GetComponent<AutoTransformRebuild>();
	}

	public void ShowNotification(string message, Color color, float time)
	{
		if (fadeTween != null && fadeTween.IsActive())
		{
			fadeTween.Kill();
		}
		if (appearTween != null && appearTween.IsActive())
		{
			appearTween.Kill(complete: true);
		}
		text.text = message;
		text.color = color;
		canvasGroup.alpha = 1f;
		appearTween = base.transform.DOPunchScale(Vector3.one * 0.2f, 0.1f).SetUpdate(isIndependentUpdate: true);
		fadeTween = canvasGroup.DOFade(0f, fadeTime).SetDelay(time).SetUpdate(isIndependentUpdate: true);
		transformRebuild.RebuildTransform();
	}
}
