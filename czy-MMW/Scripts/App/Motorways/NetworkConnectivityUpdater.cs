using System.Collections.Generic;
using Factory;
using Factory.Pools;
using Motorways.Models;
using Motorways.Views;
using Server;

namespace Motorways
{
	public class NetworkConnectivityUpdater : CityModel.IObserver, IReusable, CarparkModel.IObserver
	{
		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private Pathfinder _pathfinder;

		[Dependency]
		private ViewIndex _viewIndex;

		private bool _hasSubscribedToCity;

		private List<HouseView> _housesToTest = new List<HouseView>();

		private List<DestinationView> _destinationsToTest = new List<DestinationView>();

		private bool _testDisconnectedBuildingsDuringNextTick;

		public void Start()
		{
			TestDisconnectedBuildings();
		}

		public void TestHouse(HouseView house)
		{
			if (!_housesToTest.Contains(house))
			{
				house.NetworkConnectivity = NetworkConnectivity.Unknown;
				_housesToTest.Add(house);
			}
		}

		public void TestDestination(DestinationView destination)
		{
			if (!_destinationsToTest.Contains(destination))
			{
				destination.NetworkConnectivity = NetworkConnectivity.Unknown;
				_destinationsToTest.Add(destination);
			}
		}

		public void Reset()
		{
			_hasSubscribedToCity = false;
			_housesToTest.Clear();
			_destinationsToTest.Clear();
			_testDisconnectedBuildingsDuringNextTick = false;
		}

		public void Tick()
		{
			if (!_hasSubscribedToCity)
			{
				_simulation.GetModel<CityModel>().Subscribe(this);
				ModelListEnumerator<CarparkModel> enumerator = _simulation.GetModels<CarparkModel>().GetEnumerator();
				while (enumerator.MoveNext())
				{
					CarparkModel current = enumerator.Current;
					OnCarparkAdded(current);
				}
				_hasSubscribedToCity = true;
			}
			if (_testDisconnectedBuildingsDuringNextTick)
			{
				TestDisconnectedBuildings();
				_testDisconnectedBuildingsDuringNextTick = false;
			}
			if (_destinationsToTest.Count > 0)
			{
				DestinationView destination = _destinationsToTest[0];
				_destinationsToTest.RemoveAt(0);
				UpdateDestinationConnectivity(destination);
			}
			else if (_housesToTest.Count > 0)
			{
				HouseView house = _housesToTest[0];
				_housesToTest.RemoveAt(0);
				UpdateHouseConnectivity(house);
			}
		}

		public void OnLanesAdded()
		{
			TestDisconnectedBuildings();
		}

		public void OnLanesReleased()
		{
			TestConnectedBuildings();
		}

		public void OnDestinationAdded()
		{
			_testDisconnectedBuildingsDuringNextTick = true;
		}

		public void OnCarparkRemoved(CarparkModel carparkModel)
		{
			carparkModel.Unsubscribe(this);
			TestConnectedBuildings();
		}

		public void OnCarparkAdded(CarparkModel carparkModel)
		{
			if (carparkModel.SupportsTwoDestinations)
			{
				carparkModel.Subscribe(this);
			}
		}

		private void TestDisconnectedBuildings()
		{
			foreach (HouseView houseView in _viewIndex.HouseViews)
			{
				if (houseView.NetworkConnectivity == NetworkConnectivity.Disconnected)
				{
					TestHouse(houseView);
				}
			}
			foreach (DestinationView destinationView in _viewIndex.DestinationViews)
			{
				if (destinationView.NetworkConnectivity == NetworkConnectivity.Disconnected)
				{
					TestDestination(destinationView);
				}
			}
		}

		private void TestConnectedBuildings()
		{
			foreach (HouseView houseView in _viewIndex.HouseViews)
			{
				if (houseView.NetworkConnectivity != NetworkConnectivity.Connected)
				{
					continue;
				}
				bool flag = false;
				foreach (VehicleModel ownedVehicle in houseView.Model.ownedVehicles)
				{
					if (ownedVehicle.behaviorState != VehicleModel.BehaviorState.WaitingForDestination && ownedVehicle.behaviorState != VehicleModel.BehaviorState.DrivingHome)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					TestHouse(houseView);
				}
			}
			foreach (DestinationView destinationView in _viewIndex.DestinationViews)
			{
				if (destinationView.NetworkConnectivity == NetworkConnectivity.Connected)
				{
					TestDestination(destinationView);
				}
			}
		}

		private void UpdateDestinationConnectivity(DestinationView destination)
		{
			if (!destination.gameObject.activeInHierarchy)
			{
				return;
			}
			int groupIndex = destination.groupIndex;
			for (int i = 0; i < _housesToTest.Count; i++)
			{
				HouseView houseView = _housesToTest[i];
				if (houseView.groupIndex == groupIndex && AreHouseAndDestinationConnected(houseView.Model, destination.Model))
				{
					houseView.NetworkConnectivity = NetworkConnectivity.Connected;
					destination.NetworkConnectivity = NetworkConnectivity.Connected;
					_housesToTest.RemoveAt(i);
					return;
				}
			}
			ModelListEnumerator<HouseModel> enumerator = _simulation.GetModels<HouseModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				HouseModel current = enumerator.Current;
				if (current.GroupIndex == groupIndex && !WillTestHouse(current) && AreHouseAndDestinationConnected(current, destination.Model))
				{
					destination.NetworkConnectivity = NetworkConnectivity.Connected;
					return;
				}
			}
			destination.NetworkConnectivity = NetworkConnectivity.Disconnected;
		}

		private void UpdateHouseConnectivity(HouseView house)
		{
			int groupIndex = house.groupIndex;
			for (int i = 0; i < _destinationsToTest.Count; i++)
			{
				DestinationView destinationView = _destinationsToTest[i];
				if (destinationView.groupIndex == groupIndex && AreHouseAndDestinationConnected(house.Model, destinationView.Model))
				{
					house.NetworkConnectivity = NetworkConnectivity.Connected;
					destinationView.NetworkConnectivity = NetworkConnectivity.Connected;
					_destinationsToTest.RemoveAt(i);
					return;
				}
			}
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				if (current.isActive && current.GroupIndex == groupIndex && !WillTestDestination(current) && AreHouseAndDestinationConnected(house.Model, current))
				{
					house.NetworkConnectivity = NetworkConnectivity.Connected;
					return;
				}
			}
			house.NetworkConnectivity = NetworkConnectivity.Disconnected;
		}

		private bool AreHouseAndDestinationConnected(HouseModel house, DestinationModel destination)
		{
			LaneModel drivewayLane = house.DrivewayLane;
			if (Diagnostics.Verify(drivewayLane != null, "House on tile {0} does not have a valid driveway!", house.tileModel))
			{
				return _pathfinder.AreLanesConnected(drivewayLane, destination.Carpark.entranceLanes, allowMothballedLaneUsage: true);
			}
			return false;
		}

		private bool WillTestHouse(HouseModel houseModel)
		{
			foreach (HouseView item in _housesToTest)
			{
				if (item.Model == houseModel)
				{
					return true;
				}
			}
			return false;
		}

		private bool WillTestDestination(DestinationModel destinationModel)
		{
			foreach (DestinationView item in _destinationsToTest)
			{
				if (item.Model == destinationModel)
				{
					return true;
				}
			}
			return false;
		}
	}
}
