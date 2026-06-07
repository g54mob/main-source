using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDHint : MonoBehaviour
	{
		public TextMeshProUGUI text;

		private void Awake()
		{
			if (!text)
			{
				Debug.LogWarning("Missing TextMeshProUGUI, will destroy itself.", this);
				Object.Destroy(this);
			}
			text.text = "";
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<HUDHoverManager>.Instance.HoveredChangedAll += HUDHoverManagerOnHoveredChangedAll;
			}
			else
			{
				SingletonBehaviour<HUDHoverManager>.Instance.HoveredChangedAll -= HUDHoverManagerOnHoveredChangedAll;
			}
		}

		private void HUDHoverManagerOnHoveredChangedAll(LocoHUDControlBase controlBase)
		{
			if ((bool)controlBase)
			{
				text.text = controlBase.VisibleName;
			}
			else
			{
				text.text = "";
			}
		}
	}
}
