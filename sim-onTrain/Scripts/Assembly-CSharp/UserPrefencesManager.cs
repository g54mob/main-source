using UnityEngine;

public class UserPrefencesManager : Singleton<UserPrefencesManager>
{
	public KeyData keyData;

	private void Start()
	{
		SettingsSaveManager.OnSettingsManagerReady.AddListener(LoadKeyBindings);
	}

	public void LoadKeyBindings()
	{
		if (!(keyData == null))
		{
			SettingsSaveManager instance = Singleton<SettingsSaveManager>.Instance;
			keyData.InteractKey = (KeyCode)instance.LoadSetting("keyBind_InteractKey", (int)keyData.InteractKey);
			keyData.AddFuelKey = (KeyCode)instance.LoadSetting("keyBind_AddFuelKey", (int)keyData.AddFuelKey);
			keyData.InventoryKey = (KeyCode)instance.LoadSetting("keyBind_InventoryKey", (int)keyData.InventoryKey);
			keyData.BuildKey = (KeyCode)instance.LoadSetting("keyBind_BuildKey", (int)keyData.BuildKey);
			keyData.SimpleCraftKey = (KeyCode)instance.LoadSetting("keyBind_SimpleCraftKey", (int)keyData.SimpleCraftKey);
			keyData.ExitKey = (KeyCode)instance.LoadSetting("keyBind_ExitKey", (int)keyData.ExitKey);
			keyData.RadialSelectMenuKey = (KeyCode)instance.LoadSetting("keyBind_RadialSelectMenuKey", (int)keyData.RadialSelectMenuKey);
			keyData.DropKey = (KeyCode)instance.LoadSetting("keyBind_DropKey", (int)keyData.DropKey);
			keyData.RotateKey = (KeyCode)instance.LoadSetting("keyBind_RotateKey", (int)keyData.RotateKey);
			keyData.StoryPanelKey = (KeyCode)instance.LoadSetting("keyBind_StoryPanelKey", (int)keyData.StoryPanelKey);
			keyData.PushToTalkKey = (KeyCode)instance.LoadSetting("keyBind_PushToTalkKey", (int)keyData.PushToTalkKey);
		}
	}

	public void SaveKeyBinding(KeyBindType type, KeyCode key)
	{
		Singleton<SettingsSaveManager>.Instance.SaveSetting("keyBind_" + type, (int)key);
	}
}
