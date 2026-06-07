using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public interface IDrawModeProvider
	{
		IOrbitNode CraftNode { get; }

		IDrawMode DrawMode { get; }
	}
}
