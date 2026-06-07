using UnityEngine;

namespace Assets.Nimbatus.GUI.SandboxSettings.Scripts
{
	public class CheckboxSettingsUi : SandboxSettingsUi
	{
		public UIToggle Checkbox;

		public UISprite CheckboxSprite;

		public GameObject Warning;

		public bool Value
		{
			get
			{
				return Checkbox.value;
			}
			set
			{
				Checkbox.value = value;
			}
		}

		public override void Activate(bool active)
		{
			NameLabel.color = (active ? ActiveColor : InactiveColor);
			CheckboxSprite.color = (active ? ActiveColor : InactiveColor);
			Checkbox.GetComponent<Collider>().enabled = active;
			GameObject warning = Warning;
			if ((object)warning != null)
			{
				warning.SetActive(active);
			}
		}
	}
}
