using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public interface IObjectContainerProvider
	{
		Transform CanvasesRoot { get; }

		Transform CraftCanvases { get; }

		Transform Crafts { get; }

		Transform FloatingOriginIgnoreContainer { get; }

		Transform General { get; }

		Transform OrbitCanvases { get; }

		Transform OrbitContainer { get; }

		Transform Planets { get; }

		Transform PlanetsCanvases { get; }

		Transform Root { get; }

		Transform UiContainer { get; }
	}
}
