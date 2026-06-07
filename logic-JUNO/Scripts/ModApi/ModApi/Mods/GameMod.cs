using Jundroo.ModTools;
using ModApi.Craft;
using ModApi.Planet;
using ModApi.State;

namespace ModApi.Mods
{
	public abstract class GameMod : GameModBase
	{
		public virtual bool IsModRequiredForCelestialBody(PlanetDataScript celestialBody)
		{
			return false;
		}

		public virtual bool IsModRequiredForCraft(CraftData craft)
		{
			return false;
		}

		public virtual bool IsModRequiredForFlightState(IFlightStateData flightState)
		{
			return false;
		}

		public virtual bool IsModRequiredForPlanetarySystem(SolarSystemDataScript planetarySystem)
		{
			return false;
		}
	}
}
