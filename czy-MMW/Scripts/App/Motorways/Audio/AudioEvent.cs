using Motorways.Views;
using Motorways.Views.Trains;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Motorways.Audio
{
	public class AudioEvent
	{
		private static int nextId = 1;

		public int Id { get; private set; }

		public AudioEventType Type { get; private set; }

		public double DspTime { get; private set; }

		public float Pan { get; private set; }

		public float Attenuation { get; private set; }

		public float Magnitude { get; private set; }

		public Vector2 PanXY { get; private set; }

		public bool IsPaused { get; private set; }

		public UIEventType UIEventType { get; private set; }

		public UIAudioProfile UIAudioProfile { get; private set; }

		public ScreenStack.MotorwaysScreen Screen { get; private set; }

		public ScreenStack.MotorwaysScreen PreviousScreen { get; private set; }

		public float Duration { get; private set; }

		public VehicleView Vehicle { get; private set; }

		public TrainView Train { get; private set; }

		public MotorwayView Motorway { get; private set; }

		public HouseView House { get; private set; }

		public DestinationView Destination { get; private set; }

		public DestinationView NeighboringDestination
		{
			get
			{
				if (Destination != null)
				{
					return Destination.NeighboringDestination;
				}
				return null;
			}
		}

		public City City { get; private set; }

		public UpgradeType UpgradeType { get; private set; }

		public bool Condition { get; private set; }

		public PointerEventData PointerEventData { get; private set; }

		public TrafficLightView TrafficLight { get; private set; }

		public TileDirectionBitfield Directions { get; private set; }

		public int GroupIndex
		{
			get
			{
				if (House != null && House.Model != null)
				{
					return House.Model.GroupIndex;
				}
				if (Destination != null && Destination.Model != null)
				{
					return Destination.Model.GroupIndex;
				}
				if (Vehicle != null && Vehicle.Model != null)
				{
					return Vehicle.House.Model.GroupIndex;
				}
				return -1;
			}
		}

		private AudioEvent(double dspTime, AudioEventType type)
		{
			Id = nextId;
			nextId++;
			UIEventType = UIEventType.None;
			Screen = ScreenStack.MotorwaysScreen.None;
			PreviousScreen = ScreenStack.MotorwaysScreen.None;
			Duration = -1f;
			DspTime = dspTime;
			Pan = 0.5f;
			Vehicle = null;
			Motorway = null;
			Train = null;
			TrafficLight = null;
			Type = type;
			IsPaused = false;
		}

		public static AudioEvent CreateEvent(double dspTime, AudioEventType type, float pan = 0.5f, float duration = -1f, bool condition = true, City city = null)
		{
			return new AudioEvent(dspTime, type)
			{
				Pan = pan,
				Duration = duration,
				Condition = condition,
				City = city
			};
		}

		public static AudioEvent CreateTrainEvent(double dspTime, AudioEventType type, TrainView train)
		{
			return new AudioEvent(dspTime, type)
			{
				Train = train
			};
		}

		public static AudioEvent CreateDestinationEvent(AudioEventType type, DestinationView destination, bool condition = true)
		{
			return new AudioEvent(-1.0, type)
			{
				City = destination.City,
				Destination = destination,
				Condition = condition
			};
		}

		public static AudioEvent CreateHouseEvent(AudioEventType type, HouseView house, bool condition = true)
		{
			return new AudioEvent(-1.0, type)
			{
				City = house.City,
				House = house,
				Condition = condition
			};
		}

		public static AudioEvent CreateVehicleEvent(AudioEventType type, VehicleView vehicle, HouseView house = null, DestinationView destination = null, MotorwayView motorway = null)
		{
			return new AudioEvent(-1.0, type)
			{
				City = vehicle.City,
				Vehicle = vehicle,
				House = ((house == null) ? vehicle.House : house),
				Destination = ((destination == null) ? vehicle.Destination : destination),
				Motorway = motorway
			};
		}

		public static AudioEvent CreateMotorwayEvent(AudioEventType type, MotorwayView motorway, float pan = 0.5f, float attenuation = 1f, float magnitude = 0f)
		{
			return new AudioEvent(-1.0, type)
			{
				City = motorway.City,
				Motorway = motorway,
				Pan = pan,
				Attenuation = attenuation,
				Magnitude = magnitude
			};
		}

		public static AudioEvent CreateTrafficLightEvent(AudioEventType type, TrafficLightView trafficLight, TileDirectionBitfield rightOfWay)
		{
			return new AudioEvent(-1.0, type)
			{
				TrafficLight = trafficLight,
				City = trafficLight.City,
				Directions = rightOfWay
			};
		}

		public static AudioEvent CreateUpgradeEvent(AudioEventType type, UpgradeType upgradeType, bool success = true, MotorwayView motorway = null, Vector2 panXY = default(Vector2))
		{
			return new AudioEvent(-1.0, type)
			{
				UpgradeType = upgradeType,
				Condition = success,
				Motorway = motorway,
				PanXY = Get.Pan(panXY)
			};
		}

		public static AudioEvent CreateUIEvent(UIEventType type, UIAudioProfile profile = UIAudioProfile.None, float duration = -1f, bool condition = true, PointerEventData data = null, ScreenStack.MotorwaysScreen screen = ScreenStack.MotorwaysScreen.None, ScreenStack.MotorwaysScreen previousScreen = ScreenStack.MotorwaysScreen.None)
		{
			return new AudioEvent(AudioSystem.Instance.DspTime, AudioEventType.UserInterface)
			{
				UIAudioProfile = profile,
				UIEventType = type,
				Duration = duration,
				Screen = screen,
				PreviousScreen = previousScreen,
				Condition = condition,
				Pan = ((data != null) ? Maf.Normalize(data.position[0], 0f, UnityEngine.Screen.width) : 0.5f),
				PointerEventData = data
			};
		}

		public override string ToString()
		{
			string text = $"[AudioEvent: Type={Type}, DspTime={DspTime}, Pan={Pan}, Id={Id}";
			if (Vehicle != null)
			{
				text += $", Vehicle={Vehicle}";
			}
			if (House != null)
			{
				text += $", House={House}";
			}
			if (Destination != null)
			{
				text += $", Destination={Destination}";
			}
			if (TrafficLight != null)
			{
				text += $", TrafficLight={TrafficLight}, Directions={Directions}";
			}
			if (UIEventType != UIEventType.None)
			{
				text += $", UIEventType={UIEventType}, Duration={Duration}, Screen={Screen}, PreviousScreen={PreviousScreen}, UIAudioProfile={UIAudioProfile}";
			}
			return text + "]";
		}
	}
}
