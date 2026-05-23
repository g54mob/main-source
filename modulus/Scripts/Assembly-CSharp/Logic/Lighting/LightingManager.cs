using Data.Lighting;
using Events;
using Events.Lighting;
using UnityEngine;

namespace Logic.Lighting
{
	public class LightingManager : MonoBehaviour
	{
		[SerializeField]
		private SetLightingConfigEventSO _setLightingConfigEvent;

		[SerializeField]
		private BaseEvent _resetToDefaultLightingConfigEvent;

		private LightingConfig _customLightConfig;

		public LightingConfig CustomLightConfig => _customLightConfig;

		private void Awake()
		{
			_setLightingConfigEvent.Register(HandleSetLightingConfig);
			_resetToDefaultLightingConfigEvent.Register(HandleResetToDefaultLightingConfig);
		}

		private void Start()
		{
			HandleResetToDefaultLightingConfig();
		}

		private void HandleResetToDefaultLightingConfig()
		{
			_customLightConfig = null;
		}

		private void HandleSetLightingConfig(LightingConfig newLightingConfig)
		{
			_customLightConfig = newLightingConfig;
			newLightingConfig.Apply();
		}

		private void OnDestroy()
		{
			_setLightingConfigEvent.UnRegister(HandleSetLightingConfig);
			_resetToDefaultLightingConfigEvent.UnRegister(HandleResetToDefaultLightingConfig);
		}
	}
}
