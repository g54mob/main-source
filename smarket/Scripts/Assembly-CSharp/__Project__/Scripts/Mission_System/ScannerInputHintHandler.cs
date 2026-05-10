using UnityEngine;
using UnityEngine.Localization.Components;

namespace __Project__.Scripts.Mission_System
{
	public class ScannerInputHintHandler : MonoBehaviour
	{
		[SerializeField]
		private LocalizeStringEvent m_hintLocalizeEvent;

		private void Start()
		{
		}

		private void OnGamepadConnected(bool obj)
		{
		}
	}
}
