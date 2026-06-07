using Server;

namespace Client
{
	public interface IClient : ISimulationObserver
	{
		void Start();

		void Tick(TimeInterval tickTime, float stepAlpha);

		void ApplyTheme(ITheme theme);

		void ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress);
	}
}
