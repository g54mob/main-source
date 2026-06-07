using DV.Common;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.Utils;
using I2.Loc;

public class I2PrefReroute : I2CustomPersistentStorage
{
	private const string KEY = "I2 Language";

	public override void SetSetting_String(string key, string value)
	{
		if (key == "I2 Language")
		{
			Set(value);
		}
		else
		{
			base.SetSetting_String(key, value);
		}
	}

	public override string GetSetting_String(string key, string defaultValue)
	{
		if (key == "I2 Language")
		{
			return Get();
		}
		return base.GetSetting_String(key, defaultValue);
	}

	public override void DeleteSetting(string key)
	{
		if (key == "I2 Language")
		{
			Set("");
		}
		else
		{
			base.DeleteSetting(key);
		}
	}

	public override bool HasSetting(string key)
	{
		if (key == "I2 Language")
		{
			return !string.IsNullOrWhiteSpace(Get());
		}
		return base.HasSetting(key);
	}

	private void Set(string value)
	{
		SingletonBehaviour<UserManager>.Instance.CurrentUser.GameData.SetString("Language", value);
		SingletonBehaviour<UserManager>.Instance.CurrentUser.Save(UserSavingMode.JustUser);
	}

	private string Get()
	{
		return SingletonBehaviour<UserManager>.Instance.CurrentUser.GameData.GetString("Language");
	}
}
