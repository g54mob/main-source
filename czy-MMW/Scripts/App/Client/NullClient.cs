using FixMath;
using Server;

namespace Client
{
	public class NullClient : IClient, ISimulationObserver
	{
		public void Start()
		{
		}

		public void Tick(TimeInterval timeInterval, float stepAlpha)
		{
		}

		public void OnModelAdded(ISimulation simulation, IModel element, Fix64 timestamp)
		{
		}

		public void OnModelRemoved(ISimulation simulation, IModel model, Fix64 timestamp)
		{
		}

		public void ApplyTheme(ITheme theme)
		{
		}

		public void ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
		}
	}
}
