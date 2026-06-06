namespace Febucci.TextAnimatorCore.Settings
{
	public interface ISettingsProvider<TSettings>
	{
		TSettings Settings { get; }
	}
}
