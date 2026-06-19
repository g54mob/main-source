using Loxodon.Framework.Views;
using Michsky.DreamOS;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI.HUD.Settings.Graphics
{
	public class GraphicsSettingsControllView : UIView
	{
		[SerializeField]
		private SwitchManager _switchManager;

		[SerializeField]
		private TextMeshProUGUI _titleText;

		public void Init(string name, UnityAction<bool> onToggleChanged, bool isOn = true)
		{
			_switchManager.isOn = isOn;
			_switchManager.UpdateUI();
			if (isOn)
			{
				_switchManager.SetOn();
			}
			else
			{
				_switchManager.SetOff();
			}
			_switchManager.onValueChanged.AddListener(onToggleChanged);
			_titleText.text = name;
		}
	}
}
