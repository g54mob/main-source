using System.Collections;
using SettingScripts;
using UIScripts;
using UIScripts.SettingHandles;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.Events;

namespace ManagementScripts
{
	public class SpriteGeneratorInitializer : MonoBehaviour
	{
		[Header("References")]
		public LoadingPanel LoadingPanel;

		public SpriteGeneratorSettingsManager SM;

		public Transform popupHolder;

		public ProceduralGenePreviewer preview;

		public UnityEvent OnProceduralSpritesLoaded = new UnityEvent();

		public void Start()
		{
			Time.timeScale = 1f;
			PopupManager.popupHolder = popupHolder;
			StartCoroutine(WaitMenuInitialization());
		}

		private IEnumerator WaitMenuInitialization()
		{
			int n = 15;
			LoadingPanel.SetActive(active: true);
			LoadingPanel.UpdateProgress(0f);
			yield return null;
			LoadingPanel.UpdateProgress(1f / (float)n);
			SM.StartLoadingSettingsHandles();
			for (int i = 0; i < n; i++)
			{
				yield return null;
				LoadingPanel.UpdateProgress(((float)i + 1f) / (float)n);
			}
			SM.UpdateControls();
			LoadingPanel.UpdateProgress(1f);
			yield return null;
			OnProceduralSpritesLoaded.Invoke();
			yield return null;
			LoadingPanel.SetActive(active: false, 0.5f);
			SpriteGeneratorSettings.inflateRatio.ResetValue();
		}

		public void SaveSprite()
		{
			SpriteGenerator.instance.SaveSpriteOfPreview(preview);
		}

		private void OnDestroy()
		{
			SpriteGeneratorSettings.inflateRatio.ResetValue();
		}
	}
}
