using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
	public class SettingsComponent : MonoBehaviour
	{
		public UnityEvent<GameSettingsConfig> OnLoadConfig = new UnityEvent<GameSettingsConfig>();

		public UnityEvent<GameSettingsConfig> OnConfigChanges = new UnityEvent<GameSettingsConfig>();

		[SerializeField]
		private UnityEvent optionFields = new UnityEvent();

		private void Awake()
		{
			GameSettings.OnLoadConfigFinished.AddListener(delegate
			{
				GameSettings.RegisterSettingsComponent(this);
			});
		}

		public virtual void OnConfigLoad(GameSettingsConfig config)
		{
			optionFields.Invoke();
		}

		public virtual void OnConfigUpdate(GameSettingsConfig config)
		{
		}

		public virtual void OnConfigDestroy()
		{
		}

		public void LoadConfig(GameSettingsConfig config)
		{
			OnLoadConfig.Invoke(config);
			OnConfigLoad(config);
			StartCoroutine(WaitNextFrame(config));
		}

		private IEnumerator WaitNextFrame(GameSettingsConfig config)
		{
			yield return new WaitForSeconds(1f);
			ReloadSettings(config);
			StopCoroutine(WaitNextFrame(config));
		}

		public void ReloadSettings(GameSettingsConfig config)
		{
			OnConfigChanges.Invoke(config);
			OnConfigUpdate(config);
		}

		private void OnDestroy()
		{
			GameSettings.UnregisterSettingsComponent(this);
			OnConfigDestroy();
		}
	}
}
