using System;
using System.Collections;
using System.IO;
using Controller;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.UI.PhotoMode
{
	public class PhotoMode : MonoSingleton<PhotoMode>, IPauseGame
	{
		[SerializeField]
		private PhotoModeView photoModeView;

		public bool IsPhotoModeActive { get; private set; }

		public void Show()
		{
			MonoSingleton<UIController>.Instance.UIManager.CloseAllViews();
			MonoSingleton<UIPanelManager>.Instance.CloseAllOpened();
			photoModeView.Show();
			MonoSingleton<GlobalShaderVariables>.Instance.SetScreenshotModeEnabled(enableScreenshotMode: true);
			MonoSingleton<PhotoModeController>.Instance.TogglePhotoMode(visible: true);
			MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(Hide, photoModeView.gameObject);
			MonoSingleton<GameplayPauseManager>.Instance.Register(this);
			IsPhotoModeActive = true;
		}

		private void Hide()
		{
			photoModeView.Hide();
			MonoSingleton<GlobalShaderVariables>.Instance.SetScreenshotModeEnabled(enableScreenshotMode: false);
			MonoSingleton<PhotoModeController>.Instance.TogglePhotoMode(visible: false);
			MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(Hide, photoModeView.gameObject);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				MonoSingleton<GameplayPauseManager>.Instance.Unregister(this);
			});
			IsPhotoModeActive = false;
		}

		private void Start()
		{
			photoModeView.TakePhotoButton.onClick.AddListener(TakePhoto);
			photoModeView.CloseButton.onClick.AddListener(Hide);
			photoModeView.Hide();
		}

		private void TakePhoto()
		{
			StartCoroutine(ScreenshotEncode());
		}

		private IEnumerator ScreenshotEncode()
		{
			photoModeView.Hide();
			yield return new WaitForEndOfFrame();
			Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, mipChain: false);
			texture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
			texture.Apply();
			yield return 0;
			byte[] data = texture.EncodeToPNG();
			string text = Path.Combine(Application.persistentDataPath, string.Format("{0}/Photos/{1}_{2:yy-MM-dd}_{3:hh-mm-ss}.PNG", "UserData", GlobalSaveController.CurrentVillageData.Name, DateTime.Now, DateTime.Now)).Replace("\\", "/");
			FilePathUtils.CheckAndCreatePath(text);
			FileUtils.SafeWriteAllBytes(text, data);
			UnityEngine.Object.Destroy(texture);
			photoModeView.TakePhoto(MonoSingleton<LocalizationController>.Instance.GetText("photo_save_location") + ":\n" + text);
			yield return new WaitForEndOfFrame();
		}
	}
}
