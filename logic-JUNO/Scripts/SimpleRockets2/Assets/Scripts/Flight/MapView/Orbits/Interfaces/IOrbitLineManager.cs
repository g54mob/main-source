using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;

namespace Assets.Scripts.Flight.MapView.Orbits.Interfaces
{
	public interface IOrbitLineManager
	{
		ModeType Drawmode { get; }

		bool ShowApsidesInfo { get; }

		void SetOrbitDrawMode(ModeType newMode, bool craftOnly);
	}
}
