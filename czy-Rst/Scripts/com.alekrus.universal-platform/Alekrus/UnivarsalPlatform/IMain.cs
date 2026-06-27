namespace Alekrus.UnivarsalPlatform
{
	public interface IMain : IInitializable, IUpdatable
	{
		SystemLanguage SystemLanguage { get; }

		bool CheckForLauncherAndRestart();
	}
}
