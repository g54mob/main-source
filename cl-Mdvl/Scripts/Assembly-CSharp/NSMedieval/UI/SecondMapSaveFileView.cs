using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Model.SecondMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class SecondMapSaveFileView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text saveFileName;

		[SerializeField]
		private TMP_Text lastPlayed;

		[SerializeField]
		private SoundButton deleteFileButton;

		[SerializeField]
		private SoundButton overwriteFileButton;

		[SerializeField]
		private SoundButton profileClickButton;

		[SerializeField]
		private BasicLayoutItemView warningIcon;

		[SerializeField]
		private Image selectedImage;

		private SecondMapSaveInfo saveInfo;

		private bool listenersDone;

		private bool selected;

		private Action<SecondMapSaveInfo> overwriteProfileAction;

		private Action<SecondMapSaveInfo> deleteProfileAction;

		private Action<SecondMapSaveInfo> selectProfileAction;

		private Action<SecondMapSaveInfo> loadProfileAction;

		private float timeAfterFirstclick;

		private const float timeForDoubleClick = 1f;

		public SecondMapSaveInfo Profile => saveInfo;

		public void Hide()
		{
			saveInfo = null;
			MonoSingleton<SceneController>.Instance.Tick -= OnTick;
		}

		public void Setup(SecondMapSaveInfo saveInfo, Action<SecondMapSaveInfo> overwriteProfileAction, Action<SecondMapSaveInfo> deleteProfileAction, Action<SecondMapSaveInfo> selectProfileAction, Action<SecondMapSaveInfo> loadProfileAction)
		{
			this.overwriteProfileAction = overwriteProfileAction;
			this.deleteProfileAction = deleteProfileAction;
			this.selectProfileAction = selectProfileAction;
			this.loadProfileAction = loadProfileAction;
			this.saveInfo = saveInfo;
			TryInitListeners();
			saveFileName.SetText(saveInfo.Name);
			lastPlayed.SetText(saveInfo.Type.ToString());
			overwriteFileButton.gameObject.SetActive(overwriteProfileAction != null);
		}

		private void TryInitListeners()
		{
			if (overwriteFileButton != null && overwriteProfileAction != null)
			{
				overwriteFileButton.onClick.RemoveAllListeners();
				overwriteFileButton.onClick.AddListener(delegate
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\SecondMapSaveFileView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Overwrite file clicked ");
						messageBuilder.AppendFormatted(saveInfo.Name);
					}
					Log.Info(messageBuilder);
					overwriteProfileAction(saveInfo);
				});
			}
			if (deleteFileButton != null && deleteProfileAction != null)
			{
				deleteFileButton.onClick.RemoveAllListeners();
				deleteFileButton.onClick.AddListener(delegate
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\SecondMapSaveFileView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Delete file clicked ");
						messageBuilder.AppendFormatted(saveInfo.Name);
					}
					Log.Info(messageBuilder);
					deleteProfileAction(saveInfo);
				});
			}
			if (profileClickButton != null && selectProfileAction != null)
			{
				profileClickButton.onClick.RemoveAllListeners();
				profileClickButton.onClick.AddListener(OnProfileClick);
			}
		}

		private void OnProfileClick()
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\SecondMapSaveFileView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Select profile clicked ");
				messageBuilder.AppendFormatted(saveInfo.Name);
			}
			Log.Info(messageBuilder);
			if (loadProfileAction == null)
			{
				selectProfileAction(saveInfo);
			}
			else if (timeAfterFirstclick <= 0f)
			{
				timeAfterFirstclick = 1f;
				selectProfileAction(saveInfo);
			}
			else if (selected && timeAfterFirstclick > 0f)
			{
				loadProfileAction(saveInfo);
			}
		}

		private void OnTick(float deltaTime)
		{
			if (!(timeAfterFirstclick <= 0f))
			{
				timeAfterFirstclick -= ((deltaTime == 0f) ? 0.02f : deltaTime);
			}
		}

		public void SetSelected(bool selected)
		{
			this.selected = selected;
			selectedImage.enabled = selected;
		}

		public void SetProfile(SecondMapSaveInfo newSave)
		{
			saveInfo = newSave;
			saveFileName.SetText(newSave.Name);
		}
	}
}
