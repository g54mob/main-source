namespace ModApi.Settings.Core
{
	public delegate void SettingChangedEventHandler<T>(Setting<T> setting) where T : struct;
}
