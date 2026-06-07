using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class AntiAliasingToggle : MonoBehaviour
	{
		private UIToggle _toggle;

		public void OnEnable()
		{
			_toggle = GetComponent<UIToggle>();
			_toggle.value = RuntimeGlobals.Settings.AntiAliasingActive;
			EventDelegate.Add(_toggle.onChange, OnChange, false);
		}

		public void OnDisable()
		{
			EventDelegate.Remove(_toggle.onChange, OnChange);
		}

		public void OnChange()
		{
			RuntimeGlobals.Settings.AntiAliasingActive = UIToggle.current.value;
			RuntimeGlobals.Settings.Apply();
		}
	}
}
