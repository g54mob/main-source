using UnityEngine;

namespace Assets.Nimbatus.GUI.SandboxSettings.Scripts
{
	public class SeedSettingsUi : SandboxSettingsUi
	{
		public UIInput InputArea;

		public RandomizeSeed RandomizeButton;

		public GameObject Warning;

		public string Value
		{
			get
			{
				return InputArea.value;
			}
			set
			{
				InputArea.value = value;
			}
		}

		public override void Activate(bool active)
		{
			NameLabel.color = (active ? ActiveColor : InactiveColor);
			InputArea.label.color = (active ? ActiveColor : InactiveColor);
			InputArea.GetComponent<Collider>().enabled = active;
			RandomizeButton.gameObject.SetActive(active);
			GameObject warning = Warning;
			if ((object)warning != null)
			{
				warning.SetActive(active);
			}
		}
	}
}
