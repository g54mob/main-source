using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Orbits;
using ModApi.Ioc;
using ModApi.State.MapView;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Items.Interfaces
{
	public interface ICraftInfo
	{
		MapItemData Data { get; }

		IIocContainer Ioc { get; }

		string ItemName { get; }

		Material LineMaterial { get; }

		IMapViewContext MapViewContext { get; }

		MapOrbitInfo OrbitInfo { get; }

		void ScheduleChainUpdate();
	}
}
