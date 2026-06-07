namespace Client
{
	public interface IThemeDatabase
	{
		void Start();

		void Tick(float deltaTime);

		ITheme GetTheme();

		void AddView(IClient view);

		void RemoveView(IClient view);

		void DisableDeleteModeOverrides();
	}
}
