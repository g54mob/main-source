using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace CTS.UI
{
	[RequireComponent(typeof(ToolTipsShower))]
	public class TooltipsToggleChanger : MonoBehaviour
	{
		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private LocalizedString _onToggleOnTooltipName;

		[SerializeField]
		private LocalizedString _onToggleOnTooltipDescription;

		[SerializeField]
		private LocalizedString _onToggleOffTooltipName;

		[SerializeField]
		private LocalizedString _onToggleOffTooltipDescription;

		private ToolTipsShower _tooltips;

		private void Awake()
		{
			_tooltips = GetComponent<ToolTipsShower>();
			_toggle.onValueChanged.AddListener(OnToggleChanged);
			OnToggleChanged(_toggle.isOn);
		}

		private void OnDestroy()
		{
			_toggle.onValueChanged.RemoveListener(OnToggleChanged);
		}

		private void OnToggleChanged(bool value)
		{
			_tooltips.SetTootipsInfo(value ? _onToggleOnTooltipName : _onToggleOffTooltipName, value ? _onToggleOnTooltipDescription : _onToggleOffTooltipDescription);
		}
	}
}
