using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Keybindings
{
	public class KeybindList : MonoBehaviour
	{
		public UIGrid Grid;

		public UIScrollView ResultScrollView;

		public KeybindListItem ItemPrefab;

		public GameObject AssignmentPopup;

		private string _language;

		private bool _showPopup;

		public void Start()
		{
			HidePopup();
			InitKeybinds();
		}

		private void InitKeybinds()
		{
			_language = LocalizationManager.CurrentLanguageCode;
			Grid.enabled = true;
			Grid.transform.DestroyChildren();
			foreach (KeybindSetting keybind in BaseSingleton<KeybindManager>.Instance.GetKeybinds())
			{
				KeybindListItem keybindListItem = Object.Instantiate(ItemPrefab);
				keybindListItem.Init(this, keybind);
				keybindListItem.transform.position = Grid.transform.position;
				keybindListItem.transform.parent = Grid.transform;
				keybindListItem.transform.localScale = Grid.transform.localScale;
			}
			ResultScrollView.ResetPosition();
			ResultScrollView.UpdateScrollbars(true);
			Grid.Reposition();
			Grid.repositionNow = true;
		}

		public void ResetToDefault()
		{
			BaseSingleton<KeybindManager>.Instance.ResetToDefault();
			BaseSingleton<KeybindManager>.Instance.Save();
			InitKeybinds();
		}

		public void Update()
		{
			if (_language != LocalizationManager.CurrentLanguageCode)
			{
				InitKeybinds();
			}
		}

		public void ShowPopup()
		{
			_showPopup = true;
			AssignmentPopup.gameObject.SetActive(true);
		}

		public void HidePopup()
		{
			_showPopup = false;
			AssignmentPopup.gameObject.SetActive(false);
		}

		public bool IsPopupShown()
		{
			return _showPopup;
		}
	}
}
