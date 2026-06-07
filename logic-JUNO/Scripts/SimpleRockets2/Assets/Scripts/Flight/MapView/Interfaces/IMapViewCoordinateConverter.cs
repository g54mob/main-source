using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public interface IMapViewCoordinateConverter
	{
		double MapScale { get; }

		Vector3d ConvertAbsoluteToWorldMapPosition(Vector3d absolutePosition);

		Vector3d ConvertMapViewToSolar(Vector3d mapViewPosition);

		Vector3d ConvertSolarToMapView(Vector3d solarPosition);

		Vector3d ConvertWorldToAbsoluteMapPosition(Vector3d worldPosition);
	}
}
