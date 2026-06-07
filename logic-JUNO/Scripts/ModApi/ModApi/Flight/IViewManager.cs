using ModApi.Flight.GameView;
using ModApi.Flight.MapView;

namespace ModApi.Flight
{
	public interface IViewManager
	{
		IGameView GameView { get; }

		IMapViewManager MapViewManager { get; }

		void ToggleMapView();
	}
}
