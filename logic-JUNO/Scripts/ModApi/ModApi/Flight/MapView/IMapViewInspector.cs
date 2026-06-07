namespace ModApi.Flight.MapView
{
	public interface IMapViewInspector
	{
		IMapView MapView { get; }

		ICameraFocusable SelectedItem { get; }
	}
}
