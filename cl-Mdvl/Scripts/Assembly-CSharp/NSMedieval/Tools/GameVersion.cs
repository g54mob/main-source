using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.StructurePresets;
using NSMedieval.UI;
using NSMedieval.UI.PhotoMode;
using TMPro;
using UnityEngine;

namespace NSMedieval.Tools
{
	[RequireComponent(typeof(TMP_Text))]
	public class GameVersion : MonoBehaviour, IObserver
	{
		[SerializeField]
		private string prefix;

		[SerializeField]
		private string suffix;

		private TMP_Text label;

		private void Start()
		{
			label = GetComponent<TMP_Text>();
			label.SetText(prefix + Application.version + suffix + " ");
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += OnMainSceneLoaded;
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnMainSceneLeft;
		}

		private void OnMainSceneLoaded()
		{
			MonoSingleton<PhotoModeController>.Instance.PhotoModeVisibleEvent += HideText;
			MonoSingleton<StructurePresetModeController>.Instance.StructurePresetModeVisibleEvent += HideText;
			MonoSingleton<UIController>.Instance.HideUIToggleEvent += HideText;
		}

		private void OnMainSceneLeft()
		{
			MonoSingleton<PhotoModeController>.Instance.PhotoModeVisibleEvent -= HideText;
			MonoSingleton<StructurePresetModeController>.Instance.StructurePresetModeVisibleEvent -= HideText;
			MonoSingleton<UIController>.Instance.HideUIToggleEvent -= HideText;
		}

		private void HideText(bool textHidden)
		{
			label.enabled = !textHidden;
		}
	}
}
