using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChallengeInfo_ImageAnimator : MonoBehaviour
{
	[SerializeField]
	private List<FadingImageInfo> fadingImages;

	[SerializeField]
	private float fadingDuration;

	[SerializeField]
	private float showDuration;

	private Sequence fadingSequence;

	private void Start()
	{
		fadingSequence = DOTween.Sequence();
		DOTweenModuleUI.DOFade(fadingImages[0].image, 1f, 0f);
		ShortcutExtensionsTMPText.DOColor(fadingImages[0].text, Constants.UI.Colors.SelectedBlack, 0f);
		ShortcutExtensions.DOScale(fadingImages[0].text.transform, 1.5f, 0f);
		float num = 0f;
		for (int i = 0; i < fadingImages.Count; i++)
		{
			float atPosition = num + showDuration;
			TweenSettingsExtensions.Insert(fadingSequence, atPosition, DOTweenModuleUI.DOFade(fadingImages[i].image, 0f, fadingDuration));
			TweenSettingsExtensions.Insert(fadingSequence, atPosition, ShortcutExtensionsTMPText.DOColor(fadingImages[i].text, Color.white, fadingDuration));
			TweenSettingsExtensions.Insert(fadingSequence, atPosition, ShortcutExtensions.DOScale(fadingImages[i].text.transform, 1f, fadingDuration));
			TweenSettingsExtensions.Insert(fadingSequence, atPosition, DOTweenModuleUI.DOFade(fadingImages[(i + 1) % fadingImages.Count].image, 1f, fadingDuration));
			TweenSettingsExtensions.Insert(fadingSequence, atPosition, ShortcutExtensionsTMPText.DOColor(fadingImages[(i + 1) % fadingImages.Count].text, Constants.UI.Colors.SelectedBlack, fadingDuration));
			TweenSettingsExtensions.Insert(fadingSequence, atPosition, ShortcutExtensions.DOScale(fadingImages[(i + 1) % fadingImages.Count].text.transform, 1.5f, fadingDuration));
			num += fadingDuration + showDuration;
		}
		TweenSettingsExtensions.SetLoops(fadingSequence, -1, LoopType.Restart);
	}
}
