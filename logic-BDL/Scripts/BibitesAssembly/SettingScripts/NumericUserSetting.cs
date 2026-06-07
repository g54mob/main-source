namespace SettingScripts
{
	public abstract class NumericUserSetting<TValueType> : NumericSetting<TValueType>
	{
		public string key;

		public virtual void OnUpdate()
		{
		}
	}
}
