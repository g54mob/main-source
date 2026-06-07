namespace SettingScripts
{
	public abstract class UserSetting<TValueType> : Setting<TValueType>
	{
		public string key;

		public virtual void OnUpdate()
		{
		}
	}
}
