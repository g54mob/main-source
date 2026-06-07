using System.Collections.Generic;
using Motorways.Models;
using Motorways.Views;
using Motorways.Views.Boats;
using Motorways.Views.Trains;
using Server;
using UnityEngine;

namespace Motorways.Audio
{
	public class AudioEnvironment
	{
		public AudioLoadout Loadout;

		public static AudioEnvironment Instance;

		public static MotorwaysGame Game;

		private ClockModel _clockModel;

		private CameraView _cameraView;

		private TilemapView _tilemapView;

		public bool Active;

		public readonly List<List<VehicleView>> Vehicles = new List<List<VehicleView>>();

		public readonly List<List<HouseView>> Houses = new List<List<HouseView>>();

		public readonly List<TrainView> Trains = new List<TrainView>();

		public readonly List<BoatView> Boats = new List<BoatView>();

		public readonly List<List<DestinationView>> Destinations = new List<List<DestinationView>>();

		public readonly List<List<IAudioView>> Disconnecteds = new List<List<IAudioView>>();

		public float ZoomSmooth;

		public int AudibleGroups;

		public int BlockedDestinations;

		public float TimeElapsed;

		public float TimeDelta;

		private bool lateGame;

		private float zoomElapsed;

		private bool loadoutActivated;

		public City City { get; private set; }

		public ClockModel ClockModel
		{
			get
			{
				if (_clockModel == null)
				{
					_clockModel = City.Scope.Get<Simulation>().GetModel<ClockModel>();
				}
				return _clockModel;
			}
		}

		public CameraView CameraView
		{
			get
			{
				if (_cameraView == null)
				{
					_cameraView = City.Scope.Get<CameraView>();
				}
				return _cameraView;
			}
		}

		public TilemapView TilemapView
		{
			get
			{
				if (_tilemapView == null)
				{
					_tilemapView = City.Scope.Get<TilemapView>();
				}
				return _tilemapView;
			}
		}

		public AudioEnvironment(AudioLoadout loadout, City city, MotorwaysGame game)
		{
			City = city;
			Instance = this;
			Game = game;
			Loadout = loadout;
			Active = true;
		}

		public void Kill()
		{
			Loadout.Deactivate();
			Loadout = null;
			Active = false;
		}

		public int GetPinCount(int groupIndex = -1)
		{
			int num = 0;
			if (Destinations == null)
			{
				return 0;
			}
			for (int i = 0; i < Destinations.Count; i++)
			{
				if (groupIndex != -1 && groupIndex != i)
				{
					continue;
				}
				foreach (DestinationView item in Destinations[i])
				{
					num += item.PinCount;
				}
			}
			return num;
		}

		public int GetDisconnectedCount(int groupIndex = -1)
		{
			int num = 0;
			ViewIndex viewIndex = City.Scope.Get<ViewIndex>();
			ModelListEnumerator<DestinationModel> enumerator = City.Scope.Get<ISimulation>().GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				DestinationView destinationView = viewIndex.GetDestinationView(current);
				if (!(destinationView == null) && (destinationView.groupIndex == groupIndex || groupIndex == -1) && destinationView.NetworkConnectivity == NetworkConnectivity.Disconnected)
				{
					num++;
				}
			}
			ModelListEnumerator<HouseModel> enumerator2 = City.Scope.Get<ISimulation>().GetModels<HouseModel>().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				HouseModel current2 = enumerator2.Current;
				HouseView houseView = viewIndex.GetHouseView(current2);
				if (!(houseView == null) && (houseView.groupIndex == groupIndex || groupIndex == -1) && houseView.NetworkConnectivity == NetworkConnectivity.Disconnected)
				{
					num++;
				}
			}
			return num;
		}

		public int GetAudibleGroups()
		{
			int num = 0;
			foreach (DestinationGroup destinationGroup in Loadout.DestinationGroups)
			{
				if (destinationGroup.ViewsCount > 0)
				{
					num++;
				}
			}
			return num;
		}

		private void UpdateCityData()
		{
			Clear(Destinations);
			Get.AddDestinationsInto(Destinations);
			Clear(Houses);
			Get.AddHousesInto(Houses);
			Clear(Vehicles);
			Get.AddVehiclesInto(Vehicles);
			Clear(Disconnecteds);
			Get.AddDisconnectedsInto(Disconnecteds);
			Trains.Clear();
			Get.AddTrainsInto(Trains);
			Boats.Clear();
			Get.AddBoatsInto(Boats);
			AudibleGroups = GetAudibleGroups();
			if (ZoomSmooth != Get.Zoom)
			{
				zoomElapsed += Time.deltaTime;
				ZoomSmooth = Mathf.Lerp(ZoomSmooth, Get.Zoom, zoomElapsed / 0.25f);
			}
			else
			{
				zoomElapsed = 0f;
			}
			if (!lateGame && AudibleGroups == Get.MaxGroups)
			{
				AudioEvent.CreateEvent(-1.0, AudioEventType.LateGame);
				Get.State |= StateType.LateGame;
				lateGame = true;
			}
			else
			{
				Get.State &= ~StateType.LateGame;
			}
		}

		private static void Clear<T>(List<List<T>> container)
		{
			for (int i = 0; i < container.Count; i++)
			{
				container[i].Clear();
			}
			while (container.Count < Get.MaxGroups)
			{
				container.Add(new List<T>());
			}
		}

		public void Update()
		{
			if (!Active)
			{
				return;
			}
			TimeDelta = Time.deltaTime;
			TimeElapsed += TimeDelta;
			UpdateCityData();
			if (!loadoutActivated)
			{
				Loadout.Activate(this);
				loadoutActivated = true;
				FX.ToggleNightMode(Get.State.HasFlag(StateType.ModeNight), init: true);
				IAudioSystem instance = AudioSystem.Instance;
				instance.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.CityStart));
				foreach (List<DestinationView> destination in Destinations)
				{
					foreach (DestinationView item in destination)
					{
						instance.ScheduleEvent(AudioEvent.CreateDestinationEvent(AudioEventType.DestinationActivated, item));
					}
				}
			}
			Loadout?.Update();
			AudioLoadout.PersistentLoadout?.Update();
		}
	}
}
