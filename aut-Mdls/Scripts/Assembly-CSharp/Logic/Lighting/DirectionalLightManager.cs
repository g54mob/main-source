using Events.Lighting;
using UnityEngine;

namespace Logic.Lighting
{
	public class DirectionalLightManager : MonoBehaviour
	{
		[SerializeField]
		private Light _directionalLight;

		[SerializeField]
		private SetDirectionalLightEventSO _setDirectionalLightEvent;

		private bool _isEnabled = true;

		public Light DirectionalLight => _directionalLight;

		public bool IsEnabled => _isEnabled;

		private void Awake()
		{
			_setDirectionalLightEvent.Register(HandleSetDirectionalLight);
		}

		private void HandleSetDirectionalLight(bool active)
		{
			_isEnabled = active;
			_directionalLight.enabled = active;
		}

		private void OnDestroy()
		{
			_setDirectionalLightEvent.UnRegister(HandleSetDirectionalLight);
		}
	}
}
