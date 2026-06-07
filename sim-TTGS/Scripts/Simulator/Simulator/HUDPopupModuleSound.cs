using Dhs5.Utility.Settings;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	public class HUDPopupModuleSound : MonoBehaviour
	{
		[SerializeField]
		private HUDPopupModule m_module;

		private void Awake()
		{
			m_module.Activated += OnPopupActivated;
			m_module.Validated += OnValidated;
		}

		private void OnPopupActivated()
		{
			AudioManager.PlaySingleEvent(CustomSettings<UiAudioSettings>.I.PopupShowed);
		}

		private void OnValidated(HUDPopupModule tabletopHUDPopupModule)
		{
			AudioManager.PlaySingleEvent(CustomSettings<UiAudioSettings>.I.PopupValidated);
		}
	}
}
