using System;
using DV.ThingTypes;
using DV.Utils;

namespace DV.Logic.Job
{
	public class Car
	{
		public readonly TrainCarLivery carType;

		public readonly float capacity;

		public readonly float length;

		public readonly string ID;

		public readonly string carGuid;

		public readonly bool playerSpawnedCar;

		public readonly bool uniqueCar;

		private Track _currentTrack;

		public CargoType CurrentCargoTypeInCar { get; private set; }

		public CargoType LastUnloadedCargoType { get; private set; }

		public Track RearBogieTrack { get; private set; }

		public Track FrontBogieTrack { get; private set; }

		public bool BogiesOnSameTrack { get; private set; }

		public Track CurrentTrack
		{
			get
			{
				return _currentTrack;
			}
			private set
			{
				if (_currentTrack != value)
				{
					_currentTrack?.RemoveFullyOnTrackCar(this);
					_currentTrack = value;
					_currentTrack?.AddFullyOnTrackCar(this);
					this.CurrentTrackChanged?.Invoke();
				}
			}
		}

		public WarehouseMachine CargoOriginWarehouse { get; private set; }

		public float LoadedCargoAmount { get; private set; }

		public event Action<CargoType> CargoLoaded;

		public event Action CargoUnloaded;

		public event Action CurrentTrackChanged;

		public Car(TrainCarLivery carType, float length, float capacity, bool playerSpawnedCar, bool uniqueCar)
		{
			this.carType = carType;
			this.length = length;
			this.capacity = capacity;
			this.playerSpawnedCar = playerSpawnedCar;
			this.uniqueCar = uniqueCar;
			CurrentTrack = null;
			carGuid = Guid.NewGuid().ToString();
			ID = SingletonBehaviour<IdGenerator>.Instance.GenerateCarID(carType);
			DumpCargo();
			SingletonBehaviour<IdGenerator>.Instance.carGuidToCar.Add(carGuid, this);
		}

		public Car(TrainCarLivery carType, float length, float capacity, string ID, string carGuid, bool playerSpawnedCar, bool uniqueCar)
		{
			this.carType = carType;
			this.length = length;
			this.capacity = capacity;
			this.playerSpawnedCar = playerSpawnedCar;
			this.uniqueCar = uniqueCar;
			CurrentTrack = null;
			this.carGuid = carGuid;
			this.ID = ID;
			SingletonBehaviour<IdGenerator>.Instance.RegisterCarId(ID);
			DumpCargo();
			SingletonBehaviour<IdGenerator>.Instance.carGuidToCar.Add(this.carGuid, this);
		}

		public void LoadCargo(float cargoAmount, CargoType loadingCargoType, WarehouseMachine loadingWarehouseMachine = null)
		{
			if (LoadedCargoAmount + cargoAmount > capacity)
			{
				throw new Exception("Error: Trying to overload car[" + ID + "] with cargo!");
			}
			if (CurrentCargoTypeInCar != CargoType.None)
			{
				throw new Exception(string.Concat("Error: Trying to load car[", ID, "] with ", loadingCargoType, ", but car is already loaded with ", CurrentCargoTypeInCar, "!"));
			}
			CurrentCargoTypeInCar = loadingCargoType;
			LoadedCargoAmount += cargoAmount;
			LastUnloadedCargoType = CargoType.None;
			CargoOriginWarehouse = loadingWarehouseMachine;
			this.CargoLoaded?.Invoke(loadingCargoType);
		}

		public void UnloadCargo(float cargoAmount, CargoType unloadingCargoType, WarehouseMachine unloadingWarehouseMachine = null)
		{
			if (LoadedCargoAmount - cargoAmount < 0f)
			{
				throw new Exception("Error: Trying to unload car[" + ID + "] with more cargo than it posses!");
			}
			if (CurrentCargoTypeInCar != unloadingCargoType)
			{
				throw new Exception(string.Concat("Error: Trying to unload ", unloadingCargoType, " from car[", ID, "], but it has ", CurrentCargoTypeInCar, "!"));
			}
			CurrentCargoTypeInCar = CargoType.None;
			LoadedCargoAmount -= cargoAmount;
			LastUnloadedCargoType = unloadingCargoType;
			CargoOriginWarehouse = unloadingWarehouseMachine;
			this.CargoUnloaded?.Invoke();
		}

		public void DumpCargo()
		{
			LoadedCargoAmount = 0f;
			CurrentCargoTypeInCar = CargoType.None;
			LastUnloadedCargoType = CargoType.None;
			CargoOriginWarehouse = null;
		}

		public void UpdateFrontBogieTrack(Track track)
		{
			if (FrontBogieTrack != track)
			{
				Track frontBogieTrack = FrontBogieTrack;
				FrontBogieTrack = track;
				UpdateLogicTracks(FrontBogieTrack, frontBogieTrack, RearBogieTrack);
			}
		}

		public void UpdateRearBogieTrack(Track track)
		{
			if (RearBogieTrack != track)
			{
				Track rearBogieTrack = RearBogieTrack;
				RearBogieTrack = track;
				UpdateLogicTracks(RearBogieTrack, rearBogieTrack, FrontBogieTrack);
			}
		}

		private void UpdateLogicTracks(Track updatedBogieTrack, Track prevTrackOfUpdatedBogie, Track otherBogieTrack)
		{
			BogiesOnSameTrack = updatedBogieTrack == otherBogieTrack;
			if (BogiesOnSameTrack)
			{
				CurrentTrack = updatedBogieTrack;
				prevTrackOfUpdatedBogie?.RemovePartiallyOnTrackCar(this);
				otherBogieTrack?.RemovePartiallyOnTrackCar(this);
			}
			else if (CurrentTrack != null)
			{
				CurrentTrack = null;
				updatedBogieTrack?.AddPartiallyOnTrackCar(this);
				otherBogieTrack?.AddPartiallyOnTrackCar(this);
			}
			else
			{
				prevTrackOfUpdatedBogie?.RemovePartiallyOnTrackCar(this);
				updatedBogieTrack?.AddPartiallyOnTrackCar(this);
			}
		}

		public void ClearTracks()
		{
			if (BogiesOnSameTrack)
			{
				CurrentTrack = null;
			}
			else
			{
				FrontBogieTrack?.RemovePartiallyOnTrackCar(this);
				RearBogieTrack?.RemovePartiallyOnTrackCar(this);
			}
			Track rearBogieTrack = (FrontBogieTrack = null);
			RearBogieTrack = rearBogieTrack;
			BogiesOnSameTrack = false;
		}
	}
}
