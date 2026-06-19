using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class SettingsManager : MonoBehaviour
	{
		[SerializeField]
		private UIManager UIManagerAsset;

		[SerializeField]
		private Transform accentColorList;

		[SerializeField]
		private Transform accentReversedColorList;

		[SerializeField]
		private ItemDragContainer desktopDragger;

		[SerializeField]
		private UserManager userManager;

		[SerializeField]
		private SpeechRecognition speechRecognition;

		[SerializeField]
		private ModalWindowManager profilePictureWindow;

		[SerializeField]
		private ModalWindowManager resetPasswordWindow;

		[SerializeField]
		private ModalWindowManager wipeUserDataWindow;

		public Sprite defaultWallpaper;

		private Toggle toggleHelper;

		public void SnapDesktopItems(bool value)
		{
			if (!(desktopDragger == null))
			{
				if (value)
				{
					desktopDragger.SnappedDragMode();
				}
				else
				{
					desktopDragger.FreeDragMode();
				}
			}
		}

		public void SaveDesktopOrder(bool value)
		{
			if (desktopDragger == null)
			{
				return;
			}
			if (value)
			{
				for (int i = 0; i < desktopDragger.transform.childCount; i++)
				{
					ItemDragger component = desktopDragger.transform.GetChild(i).GetComponent<ItemDragger>();
					component.rememberPosition = true;
					if (component.dragContainer.dragMode == ItemDragContainer.DragMode.Free)
					{
						component.UpdateObject(readData: false);
					}
				}
			}
			else
			{
				for (int j = 0; j < desktopDragger.transform.childCount; j++)
				{
					desktopDragger.transform.GetChild(j).GetComponent<ItemDragger>().rememberPosition = false;
				}
			}
		}

		public void UseShortTimeFormat(bool value)
		{
			if (!(DateAndTimeManager.instance == null))
			{
				DateAndTimeManager.instance.ShortTimeFormat(value);
			}
		}

		public void SpeechRecognition(bool value)
		{
			if (!(speechRecognition == null))
			{
				speechRecognition.EnableSpeechRecognition(value);
			}
		}

		public void AdjustProfilePicture()
		{
			if (!(profilePictureWindow == null))
			{
				profilePictureWindow.OpenWindow();
			}
		}

		public void ResetPassword()
		{
			if (!(resetPasswordWindow == null))
			{
				resetPasswordWindow.OpenWindow();
			}
		}

		public void WipeUserData()
		{
			if (!(wipeUserDataWindow == null))
			{
				wipeUserDataWindow.OpenWindow();
				wipeUserDataWindow.onConfirm.RemoveAllListeners();
				wipeUserDataWindow.onConfirm.AddListener(delegate
				{
					userManager.WipeUserData();
					wipeUserDataWindow.CloseWindow();
				});
			}
		}

		public void CheckForToggles()
		{
			foreach (Transform accentColor in accentColorList)
			{
				if (accentColor.name == PlayerPrefs.GetString("CustomThemeAccentColor"))
				{
					toggleHelper = accentColor.GetComponent<Toggle>();
					toggleHelper.isOn = true;
					toggleHelper.onValueChanged.Invoke(arg0: true);
				}
			}
			foreach (Transform accentReversedColor in accentReversedColorList)
			{
				if (accentReversedColor.name == PlayerPrefs.GetString("CustomThemeAccentRevColor"))
				{
					toggleHelper = accentReversedColor.GetComponent<Toggle>();
					toggleHelper.isOn = true;
					toggleHelper.onValueChanged.Invoke(arg0: true);
				}
			}
		}

		public void SelectSystemTheme()
		{
			UIManagerAsset.selectedTheme = UIManager.SelectedTheme.Default;
		}

		public void SelectCustomTheme()
		{
			UIManagerAsset.selectedTheme = UIManager.SelectedTheme.Custom;
		}

		public void ChangeAccentColor(string colorCode)
		{
			ColorUtility.TryParseHtmlString("#" + colorCode, out var color);
			UIManagerAsset.highlightedColorCustom = new Color(color.r, color.g, color.b, UIManagerAsset.highlightedColorCustom.a);
		}

		public void ChangeAccentReversedColor(string colorCodeReversed)
		{
			ColorUtility.TryParseHtmlString("#" + colorCodeReversed, out var color);
			UIManagerAsset.highlightedColorSecondaryCustom = new Color(color.r, color.g, color.b, UIManagerAsset.highlightedColorSecondaryCustom.a);
		}
	}
}
