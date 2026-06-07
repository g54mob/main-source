using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.SettingControls;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class EnumFlagButton : MonoBehaviour
	{
		public FlagEnumSettingControl Setting;

		public UITexture Icon;

		public Texture2D Open;

		public Texture2D Closed;

		public void Start()
		{
			Setting.IsToggled();
		}

		public void Update()
		{
			if (Setting.IsToggled())
			{
				Icon.mainTexture = Open;
			}
			else
			{
				Icon.mainTexture = Closed;
			}
		}

		public void OnClick()
		{
			Setting.ToggleOptions();
		}
	}
}
