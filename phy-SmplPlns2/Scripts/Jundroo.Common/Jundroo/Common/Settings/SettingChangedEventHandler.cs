namespace Jundroo.Common.Settings
{
	public delegate void SettingChangedEventHandler<T>(Setting<T> setting) where T : struct;
}
