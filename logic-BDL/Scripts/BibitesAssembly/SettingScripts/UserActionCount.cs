namespace SettingScripts
{
	public class UserActionCount : IntUserSetting
	{
		public int Trigger()
		{
			_ = val;
			SetValue(val + 1);
			return val + 1;
		}

		public UserActionCount(string statsKey)
		{
			key = statsKey;
			DefaultValue = 0;
		}
	}
}
