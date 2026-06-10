using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class DevVoxelInfoLineView : MonoBehaviour
	{
		[SerializeField]
		private Color lineColor;

		[SerializeField]
		private Color infoOnlyLineColor;

		[SerializeField]
		private TMP_InputField text;

		[SerializeField]
		private Image image;

		[SerializeField]
		private Button button;

		private UnityAction buttonClickListener;

		private Image ImageComponent => image;

		private Button Button => button;

		private TMP_InputField Text => text;

		private void Awake()
		{
			Text.text = " ";
			Button.gameObject.SetActive(value: false);
		}

		public void SetText(string textToSet, bool isInfoOnlyLine)
		{
			if (textToSet.Equals(string.Empty))
			{
				Text.gameObject.SetActive(value: false);
				return;
			}
			if (!Text.gameObject.activeSelf)
			{
				Text.gameObject.SetActive(value: true);
			}
			Text.SetTextWithoutNotify(textToSet);
			ImageComponent.color = (isInfoOnlyLine ? infoOnlyLineColor : lineColor);
		}

		public void SetButton(string label, UnityAction clickListener)
		{
			if (!Button.gameObject.activeSelf)
			{
				Button.gameObject.SetActive(value: true);
			}
			Button.gameObject.GetComponentInChildren<TMP_Text>().text = label;
			SetListener(clickListener);
		}

		public void ClearButton()
		{
			Button.onClick.RemoveAllListeners();
			Button.gameObject.SetActive(value: false);
			buttonClickListener = null;
		}

		private void SetListener(UnityAction clickListener)
		{
			if (clickListener != null && buttonClickListener != clickListener)
			{
				buttonClickListener = clickListener;
				Button.interactable = true;
				Button.onClick.RemoveAllListeners();
				Button.onClick.AddListener(buttonClickListener);
			}
		}
	}
}
