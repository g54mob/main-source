using System;
using TMPro;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class KeybindingLayoutItemView : LayoutGroupItemView
	{
		private int commandTextIndex;

		private int primaryBtnKeyIndex = 1;

		private int alternativeBtnKeyIndex = 2;

		private TMP_Text commandText;

		private TMP_Text primaryBtnText;

		private TMP_Text alternativeBtnText;

		private Action<KeybindingLayoutItemView, bool> keybindButtonCallback;

		public void InitializeText(string commandText, string primaryBtnText, string alternativeBtnText)
		{
			this.commandText.text = commandText;
			this.primaryBtnText.text = primaryBtnText;
			this.alternativeBtnText.text = alternativeBtnText;
		}

		public void SetKeybindButtonCallback(Action<KeybindingLayoutItemView, bool> callback)
		{
			keybindButtonCallback = callback;
		}

		public void SetPrimaryKeybindText(string text)
		{
			primaryBtnText.text = text;
		}

		public void SetAlternativeKeybingText(string text)
		{
			alternativeBtnText.text = text;
		}

		public void PrimaryKeybindClicked()
		{
			keybindButtonCallback?.Invoke(this, arg2: true);
		}

		public void AlternativeKeybindClicked()
		{
			keybindButtonCallback?.Invoke(this, arg2: false);
		}

		public void SetBackground(bool active)
		{
			GetComponent<Image>().enabled = active;
		}

		private void Awake()
		{
			commandText = base.GroupItems[commandTextIndex].GetComponent<TMP_Text>();
			primaryBtnText = base.GroupItems[primaryBtnKeyIndex].GetComponentInChildren<TMP_Text>();
			alternativeBtnText = base.GroupItems[alternativeBtnKeyIndex].GetComponentInChildren<TMP_Text>();
			base.GroupItems[primaryBtnKeyIndex].GetComponent<Button>().onClick.AddListener(delegate
			{
				PrimaryKeybindClicked();
			});
			base.GroupItems[alternativeBtnKeyIndex].GetComponent<Button>().onClick.AddListener(delegate
			{
				AlternativeKeybindClicked();
			});
		}
	}
}
