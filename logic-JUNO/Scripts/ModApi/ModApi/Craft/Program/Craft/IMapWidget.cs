using UnityEngine;

namespace ModApi.Craft.Program.Craft
{
	public interface IMapWidget
	{
		Vector2d Coordinates { get; set; }

		float Heading { get; set; }

		bool ManualMode { get; set; }

		bool NorthUp { get; set; }

		string PlanetName { get; set; }

		float Zoom { get; set; }
	}
}
