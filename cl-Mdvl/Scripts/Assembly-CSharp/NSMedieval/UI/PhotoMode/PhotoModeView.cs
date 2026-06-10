using System.Collections;
using System.Collections.Generic;
using NSEipix.View.UI;
using NSMedieval.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI.PhotoMode
{
	public class PhotoModeView : UIView
	{
		[SerializeField]
		private Image flashImage;

		[SerializeField]
		private BasicLayoutItemView promptMessage;

		[SerializeField]
		private List<GameObject> elementsToHide;

		[SerializeField]
		private SoundButton takePhotoButton;

		[SerializeField]
		private SoundButton toggleUiButton;

		[SerializeField]
		private SoundButton closeButton;

		public SoundButton TakePhotoButton => takePhotoButton;

		public SoundButton CloseButton => closeButton;

		public override void Show()
		{
			base.Show();
			elementsToHide[0].GetComponent<TMP_Text>().SetText(TextFormatting.FormatKeyInputEvent(base.Localize.GetText("photo_mode_instructions")));
		}

		public void TakePhoto(string displayText)
		{
			Show();
			StartCoroutine(FlashEffect());
			StartCoroutine(ShowMessage(displayText));
		}

		private IEnumerator ShowMessage(string displayText)
		{
			closeButton.interactable = false;
			toggleUiButton.interactable = false;
			takePhotoButton.interactable = false;
			promptMessage.SetText(displayText);
			CanvasGroup prompt = promptMessage.GetComponent<CanvasGroup>();
			float step = 0.75f;
			float alpha = 1.5f;
			while (alpha > 0.001f)
			{
				alpha -= step * Time.unscaledDeltaTime;
				prompt.alpha = Mathf.Clamp01(alpha);
				yield return null;
			}
			prompt.alpha = 0f;
			closeButton.interactable = true;
			toggleUiButton.interactable = true;
			takePhotoButton.interactable = true;
		}

		private IEnumerator FlashEffect()
		{
			flashImage.color = Color.white;
			float step = 0.08f;
			float alpha = 1f;
			while (alpha > 0.01f)
			{
				alpha -= step;
				flashImage.color = new Color(1f, 1f, 1f, alpha);
				yield return null;
			}
			flashImage.color = new Color(1f, 1f, 1f, 0f);
		}

		private void Start()
		{
			toggleUiButton.onClick.AddListener(ToggleUi);
		}

		private void ToggleUi()
		{
			foreach (GameObject item in elementsToHide)
			{
				item.SetActive(!item.activeSelf);
			}
		}
	}
}
