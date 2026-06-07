using System;
using System.Collections.Generic;
using Motorways.Models;
using Motorways.Views;
using Motorways.Views.Boats;
using Motorways.Views.Trains;
using Server;
using UnityEngine;

namespace Motorways.Audio
{
	public static class Get
	{
		public static class Pulse
		{
			public static class Master
			{
				public static double Next => AudioSystem.Instance.Database.MasterPulse.PulseInfo.PulseDspTime + Duration;

				public static double Duration => AudioSystem.Instance.Database.MasterPulse.PulseInfo.PulseDuration;
			}

			public static TimeScale Scale
			{
				get
				{
					return AudioSystem.Instance.ScheduledPulseTimeScale;
				}
				set
				{
					AudioSystem.Instance.ScheduledPulseTimeScale = value;
				}
			}

			public static double HybridTime(PulsedAudioModule module)
			{
				double num = module.NextPulseTime - AudioPlayer.EarliestSchedulableTime;
				if (!(num < Master.Duration * 0.125) || Math.Sign(num) <= 0)
				{
					return -1.0;
				}
				return module.NextPulseTime;
			}

			public static float Subduration(int divisor)
			{
				return (float)Master.Duration / (float)divisor;
			}

			public static float Subduration(params int[] divisorChoices)
			{
				return Rando.Pick(divisorChoices);
			}

			public static float SubdurationMs(int divisor)
			{
				return 1000f * Subduration(divisor);
			}

			public static float Duratio(float factor)
			{
				return (float)Master.Duration * factor;
			}

			public static float Duratio(params float[] factorChoices)
			{
				return Rando.Pick(factorChoices);
			}

			public static double QuantizedTime(double pulseDivisor)
			{
				double num = Master.Duration / pulseDivisor;
				double num2;
				for (num2 = Master.Next - Master.Duration; num2 < AudioPlayer.EarliestSchedulableTime; num2 += num)
				{
				}
				return num2;
			}
		}

		public static StateType State;

		public static AudioLoadout Loadout => AudioEnvironment.Instance?.Loadout;

		public static AudioEnvironment Environment => AudioEnvironment.Instance;

		public static AudioMixbus Mixbus => AudioSystem.Mixbus;

		public static City City => AudioEnvironment.Instance?.City;

		public static ClockModel Clock => AudioEnvironment.Instance?.ClockModel;

		public static CameraView Camera => AudioEnvironment.Instance?.CameraView;

		public static TilemapView TilemapView => AudioEnvironment.Instance?.TilemapView;

		public static MotorwaysGame Game => AudioEnvironment.Game;

		public static SimulationConstantsData GameConstants => Game.Scope.Get<SimulationConstantsData>();

		public static int Hour => (Clock?.Hour ?? 24) % 24;

		public static int Day => (Clock?.Day ?? 7) % 7;

		public static bool IsDaytime => Maf.IsWithin(Hour, 6, 18);

		public static int Week => Clock?.Week ?? 0;

		public static float WeekProgress => ((float)Day + (float)Hour / 23f) / 7f;

		public static int AudibleGroups => AudioEnvironment.Instance.AudibleGroups;

		public static int MaxGroups
		{
			get
			{
				if (Game.StartedWithGameMode != GameMode.Normal)
				{
					return 5;
				}
				return City.Definition.schedulePlanner.scheduleGroups.Count;
			}
		}

		public static float Zoom
		{
			get
			{
				City city = City;
				CameraView camera = Camera;
				if (city == null || city.Rules.DoesIgnorePlayableArea() || camera == null)
				{
					return Settings.Attenuation.Zoom.MENU;
				}
				float f = Maf.Normalize(camera.playerOrthoZoom, (float)city.Definition.cameraZoom.endSize, camera.MinZoom);
				return Mathf.Lerp(Settings.Attenuation.Zoom.DYNAMIC_RANGE.x, Settings.Attenuation.Zoom.DYNAMIC_RANGE.y, Maf.VolCurve(f));
			}
		}

		public static float ZoomSmooth => AudioEnvironment.Instance?.ZoomSmooth ?? 1f;

		public static float ZoomOutProgress
		{
			get
			{
				City city = City;
				CameraView camera = Camera;
				if (city == null || city.Rules.DoesIgnorePlayableArea() || camera == null)
				{
					return 0f;
				}
				return Maf.Normalize(camera.FixedZoom, (float)city.Definition.cameraZoom.startSize, (float)city.Definition.cameraZoom.endSize);
			}
		}

		public static bool HasAny<TEnum>(this TEnum state, params TEnum[] options) where TEnum : Enum
		{
			foreach (TEnum val in options)
			{
				if (state.HasFlag(val))
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasAll<TEnum>(this TEnum state, params TEnum[] options) where TEnum : Enum
		{
			int num = 0;
			foreach (TEnum val in options)
			{
				if (state.HasFlag(val))
				{
					num++;
				}
			}
			return num == options.Length;
		}

		public static float FacingDegrees(IAudioView view)
		{
			return view.transform.rotation.eulerAngles.z;
		}

		public static float NormBiDeltaAngle(IAudioView from, IAudioView to)
		{
			return Mathf.DeltaAngle(FacingDegrees(from), FacingDegrees(to)) / 180f;
		}

		public static Vector2 Pan(Vector2 screenPos)
		{
			float num = 1.5f;
			float value = Maf.Normalize(screenPos.x, (float)(-1 * Screen.width) * num, (float)Screen.width + (float)Screen.width * num);
			return new Vector2(y: Mathf.Clamp01(screenPos.y / (float)Screen.height), x: Mathf.Clamp01(value));
		}

		public static float PanX(Vector2 screenPos)
		{
			return Pan(screenPos).x;
		}

		public static float Attenuation(Vector2 screenPos, bool zoom = true, float falloffFactor = 5f)
		{
			float num = 100f;
			if (City != null)
			{
				num = TilemapView?.ScreenDistanceBetweenTiles ?? 100f;
			}
			float num2 = (float)Screen.width / num;
			float num3 = (float)Screen.height / num;
			Vector2 vector = new Vector2(screenPos.x / num, screenPos.y / num);
			float num4 = ((vector.x > num2) ? Maf.Map(vector.x, num2, num2 + falloffFactor, 1f, 0f) : ((!(screenPos.x < 0f)) ? 1f : Maf.Map(vector.x, 0f, 0f - falloffFactor, 1f, 0f)));
			float num5 = ((vector.y > num3) ? Maf.Map(vector.y, num3, num3 + falloffFactor, 1f, 0f) : ((!(screenPos.y < 0f)) ? (vector.y = 1f) : Maf.Map(vector.y, 0f, 0f - falloffFactor, 1f, 0f)));
			float num6 = Maf.VolCurve(num4 * num5);
			if (!zoom)
			{
				return num6;
			}
			return ZoomSmooth * num6;
		}

		public static int ConnectedViewCount()
		{
			ViewIndex viewIndex = City.Scope.Get<ViewIndex>();
			int num = 0;
			ModelListEnumerator<DestinationModel> enumerator = City.Scope.Get<ISimulation>().GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				DestinationView destinationView = viewIndex.GetDestinationView(current);
				if (destinationView != null && destinationView.NetworkConnectivity == NetworkConnectivity.Connected)
				{
					num++;
				}
			}
			ModelListEnumerator<HouseModel> enumerator2 = City.Scope.Get<ISimulation>().GetModels<HouseModel>().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				HouseModel current2 = enumerator2.Current;
				HouseView houseView = viewIndex.GetHouseView(current2);
				if (houseView != null && houseView.NetworkConnectivity == NetworkConnectivity.Connected)
				{
					num++;
				}
			}
			return num;
		}

		public static void AddDestinationsInto(List<List<DestinationView>> outResults)
		{
			ViewIndex viewIndex = City.Scope.Get<ViewIndex>();
			ModelListEnumerator<DestinationModel> enumerator = City.Scope.Get<ISimulation>().GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				DestinationView destinationView = viewIndex.GetDestinationView(current);
				if (!(destinationView == null) && destinationView.Model.isActive && destinationView.groupIndex > -1)
				{
					ExtendListToFitIndex(outResults, destinationView.groupIndex);
					outResults[destinationView.groupIndex].Add(destinationView);
				}
			}
		}

		public static void AddDisconnectedsInto(List<List<IAudioView>> outResults)
		{
			ViewIndex viewIndex = City.Scope.Get<ViewIndex>();
			ModelListEnumerator<DestinationModel> enumerator = City.Scope.Get<ISimulation>().GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				DestinationView destinationView = viewIndex.GetDestinationView(current);
				if (!(destinationView == null) && destinationView.NetworkConnectivity != NetworkConnectivity.Connected && destinationView.groupIndex > -1)
				{
					ExtendListToFitIndex(outResults, destinationView.groupIndex);
					outResults[destinationView.groupIndex].Add(destinationView);
				}
			}
			ModelListEnumerator<HouseModel> enumerator2 = City.Scope.Get<ISimulation>().GetModels<HouseModel>().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				HouseModel current2 = enumerator2.Current;
				HouseView houseView = viewIndex.GetHouseView(current2);
				if (!(houseView == null) && houseView.NetworkConnectivity != NetworkConnectivity.Connected && houseView.groupIndex > -1)
				{
					ExtendListToFitIndex(outResults, houseView.groupIndex);
					outResults[houseView.groupIndex].Add(houseView);
				}
			}
		}

		public static void AddHousesInto(List<List<HouseView>> results)
		{
			ViewIndex viewIndex = City.Scope.Get<ViewIndex>();
			ModelListEnumerator<HouseModel> enumerator = City.Scope.Get<ISimulation>().GetModels<HouseModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				HouseModel current = enumerator.Current;
				HouseView houseView = viewIndex.GetHouseView(current);
				if (!(houseView == null) && houseView.NetworkConnectivity == NetworkConnectivity.Connected && houseView.groupIndex > -1)
				{
					ExtendListToFitIndex(results, houseView.groupIndex);
					results[houseView.groupIndex].Add(houseView);
				}
			}
		}

		public static void AddVehiclesInto(List<List<VehicleView>> results)
		{
			ViewIndex viewIndex = City.Scope.Get<ViewIndex>();
			ModelListEnumerator<VehicleModel> enumerator = City.Scope.Get<ISimulation>().GetModels<VehicleModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				VehicleModel current = enumerator.Current;
				VehicleView vehicleView = viewIndex.GetVehicleView(current);
				if (!(vehicleView == null) && vehicleView.groupIndex > -1)
				{
					ExtendListToFitIndex(results, vehicleView.groupIndex);
					results[vehicleView.groupIndex].Add(vehicleView);
				}
			}
		}

		public static void AddBoatsInto(List<BoatView> results)
		{
			ViewIndex viewIndex = City.Scope.Get<ViewIndex>();
			ModelListEnumerator<BoatModel> enumerator = City.Scope.Get<ISimulation>().GetModels<BoatModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				BoatModel current = enumerator.Current;
				BoatView boatView = viewIndex.GetBoatView(current);
				if (!(boatView == null))
				{
					results.Add(boatView);
				}
			}
		}

		public static void AddTrainsInto(List<TrainView> results)
		{
			ViewIndex viewIndex = City.Scope.Get<ViewIndex>();
			ModelListEnumerator<TrainModel> enumerator = City.Scope.Get<ISimulation>().GetModels<TrainModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				TrainModel current = enumerator.Current;
				TrainView trainView = viewIndex.GetTrainView(current);
				if (!(trainView == null))
				{
					results.Add(trainView);
				}
			}
		}

		private static void ExtendListToFitIndex<T>(List<List<T>> container, int toFitIndex)
		{
			while (container.Count < toFitIndex + 1)
			{
				container.Add(new List<T>());
			}
		}
	}
}
