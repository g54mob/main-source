using ModApi.Ioc;
using UnityEngine;

namespace ModApi.Flight.MapView
{
	public interface IMapViewManager
	{
		IIocContainer Ioc { get; }

		bool IsInForeground { get; set; }

		IMapView MapView { get; }

		Camera MapViewCamera { get; }

		event MapViewForegroundStateChangedHandler ForegroundStateChanged;

		event MapViewForegroundStateChangedHandler ForegroundStateChanging;
	}
}
