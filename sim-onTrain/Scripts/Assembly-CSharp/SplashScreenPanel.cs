using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenPanel : MonoBehaviour
{
	public Image backgroundImage;

	public Image onTheTrainImage;

	public Image companyLogoImage;

	public CanvasGroup canvasGroup;

	public float fadeInStart;

	public float gameNameDuration;

	public float gameNameFadeOutDuration;

	public float canvasGroupFadeOutDuration;

	private static bool hasShownThisSession;

	private void OnEnable()
	{
		if (hasShownThisSession)
		{
			canvasGroup.gameObject.SetActive(value: false);
			return;
		}
		hasShownThisSession = true;
		canvasGroup.alpha = 1f;
		canvasGroup.gameObject.SetActive(value: true);
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
		companyLogoImage.DOKill();
		onTheTrainImage.DOKill();
		backgroundImage.DOKill();
		canvasGroup.DOKill();
		companyLogoImage.DOFade(1f, gameNameFadeOutDuration).SetDelay(fadeInStart);
		companyLogoImage.DOFade(0f, 0.3f).SetDelay(gameNameDuration);
		onTheTrainImage.DOFade(1f, gameNameFadeOutDuration).SetDelay(fadeInStart);
		onTheTrainImage.DOFade(0f, 0.3f).SetDelay(gameNameDuration);
		backgroundImage.DOColor(Color.black, 0.8f).SetDelay(gameNameDuration + 0.3f);
		canvasGroup.DOFade(0f, 0.3f).SetDelay(canvasGroupFadeOutDuration).OnComplete(delegate
		{
			canvasGroup.gameObject.SetActive(value: false);
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		});
	}
}
