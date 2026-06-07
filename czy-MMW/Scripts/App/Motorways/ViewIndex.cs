using System.Collections.Generic;
using Factory.Pools;
using Motorways.Models;
using Motorways.Views;
using Motorways.Views.Boats;
using Motorways.Views.Trains;

namespace Motorways
{
	public class ViewIndex : IReusable
	{
		private readonly Dictionary<HouseModel, HouseView> _houseModelToViewIndex = new Dictionary<HouseModel, HouseView>();

		private readonly Dictionary<DestinationModel, DestinationView> _destinationModelToViewIndex = new Dictionary<DestinationModel, DestinationView>();

		private readonly Dictionary<VehicleModel, VehicleView> _vehicleModelToViewIndex = new Dictionary<VehicleModel, VehicleView>();

		private readonly Dictionary<RailTileModel, RailView> _railModelToViewIndex = new Dictionary<RailTileModel, RailView>();

		private readonly Dictionary<BoatPathTileModel, BoatPathView> _boatPathModelToViewIndex = new Dictionary<BoatPathTileModel, BoatPathView>();

		private readonly Dictionary<TrainModel, TrainView> _trainModelToViewIndex = new Dictionary<TrainModel, TrainView>();

		private readonly Dictionary<BoatModel, BoatView> _boatModelToViewIndex = new Dictionary<BoatModel, BoatView>();

		public IEnumerable<HouseView> HouseViews => _houseModelToViewIndex.Values;

		public IEnumerable<DestinationView> DestinationViews => _destinationModelToViewIndex.Values;

		public void Reset()
		{
			_houseModelToViewIndex.Clear();
			_destinationModelToViewIndex.Clear();
			_vehicleModelToViewIndex.Clear();
			_railModelToViewIndex.Clear();
			_boatPathModelToViewIndex.Clear();
			_trainModelToViewIndex.Clear();
			_boatModelToViewIndex.Clear();
		}

		public void AddHouseView(HouseView view)
		{
			_houseModelToViewIndex[view.Model] = view;
		}

		public void RemoveHouseView(HouseView view)
		{
			_houseModelToViewIndex.Remove(view.Model);
		}

		public HouseView GetHouseView(HouseModel model)
		{
			if (model != null && Diagnostics.Verify(_houseModelToViewIndex.TryGetValue(model, out var value), "Could not find matching view for house {0}.", model))
			{
				return value;
			}
			return null;
		}

		public void AddDestinationView(DestinationView view)
		{
			if (Diagnostics.Verify(view.Model != null))
			{
				_destinationModelToViewIndex[view.Model] = view;
			}
		}

		public void RemoveDestinationView(DestinationView view)
		{
			if (Diagnostics.Verify(view.Model != null))
			{
				_destinationModelToViewIndex.Remove(view.Model);
			}
		}

		public DestinationView GetDestinationView(DestinationModel model)
		{
			if (model != null && Diagnostics.Verify(_destinationModelToViewIndex.TryGetValue(model, out var value), "Could not find matching view for destination {0}.", model))
			{
				return value;
			}
			return null;
		}

		public void AddVehicleView(VehicleView view)
		{
			_vehicleModelToViewIndex[view.Model] = view;
		}

		public void RemoveVehicleView(VehicleView view)
		{
			_vehicleModelToViewIndex.Remove(view.Model);
		}

		public VehicleView GetVehicleView(VehicleModel model)
		{
			if (model != null && Diagnostics.Verify(_vehicleModelToViewIndex.TryGetValue(model, out var value), "Could not find matching view for vehicle {0}.", model))
			{
				return value;
			}
			return null;
		}

		public void AddRailView(RailView view)
		{
			_railModelToViewIndex[view.Model] = view;
		}

		public void RemoveRailView(RailView view)
		{
			_railModelToViewIndex.Remove(view.Model);
		}

		public RailView GetRailView(RailTileModel model)
		{
			if (model != null && Diagnostics.Verify(_railModelToViewIndex.TryGetValue(model, out var value), "Could not find matching view for rail {0}.", model))
			{
				return value;
			}
			return null;
		}

		public void AddTrainView(TrainView view)
		{
			_trainModelToViewIndex[view.Model] = view;
		}

		public void RemoveTrainView(TrainView view)
		{
			_trainModelToViewIndex.Remove(view.Model);
		}

		public TrainView GetTrainView(TrainModel model)
		{
			if (model != null && Diagnostics.Verify(_trainModelToViewIndex.TryGetValue(model, out var value), "Could not find matching view for train {0}.", model))
			{
				return value;
			}
			return null;
		}

		public BoatView GetBoatView(BoatModel model)
		{
			if (model != null && Diagnostics.Verify(_boatModelToViewIndex.TryGetValue(model, out var value), "Could not find matching view for boat {0}.", model))
			{
				return value;
			}
			return null;
		}

		public void AddBoatView(BoatView view)
		{
			_boatModelToViewIndex[view.Model] = view;
		}

		public void RemoveBoatView(BoatView view)
		{
			_boatModelToViewIndex.Remove(view.Model);
		}

		public void AddBoatPathView(BoatPathView view)
		{
			_boatPathModelToViewIndex[view.Model] = view;
		}

		public void RemoveBoatPathView(BoatPathView view)
		{
			_boatPathModelToViewIndex.Remove(view.Model);
		}

		public BoatPathView GetBoatPathView(BoatPathTileModel model)
		{
			if (model != null && Diagnostics.Verify(_boatPathModelToViewIndex.TryGetValue(model, out var value), "Could not find matching view for rail {0}.", model))
			{
				return value;
			}
			return null;
		}
	}
}
