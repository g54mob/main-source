using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class BloomToggle : MonoBehaviour
	{
		private UIToggle _toggle;

		public void OnEnable()
		{
			_toggle = GetComponent<UIToggle>();
			_toggle.value = RuntimeGlobals.Settings.BloomActive;
			EventDelegate.Add(_toggle.onChange, OnChange, false);
		}

		public void OnDisable()
		{
			EventDelegate.Remove(_toggle.onChange, OnChange);
		}

		public void OnChange()
		{
			RuntimeGlobals.Settings.BloomActive = UIToggle.current.value;
		}
	}
}
