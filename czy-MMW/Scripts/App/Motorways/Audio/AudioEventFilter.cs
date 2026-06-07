using System;
using Motorways.Views;

namespace Motorways.Audio
{
	public struct AudioEventFilter
	{
		public AudioEventType Type { get; set; }

		public UIEventType UIEventType { get; set; }

		public UIAudioProfile UIAudioProfile { get; set; }

		public DestinationView Destination { get; set; }

		public VehicleView Vehicle { get; set; }

		public int GroupIndex { get; set; }

		public ScreenStack.MotorwaysScreen Screen { get; set; }

		public AudioEventFilter(AudioEventType type)
		{
			this = default(AudioEventFilter);
			Type = type;
			UIEventType = UIEventType.None;
			UIAudioProfile = UIAudioProfile.None;
			Destination = null;
			Vehicle = null;
			GroupIndex = -1;
			Screen = ScreenStack.MotorwaysScreen.None;
		}

		public AudioEventFilter(UIEventType type, UIAudioProfile audioProfile = UIAudioProfile.None)
		{
			this = default(AudioEventFilter);
			Type = AudioEventType.UserInterface;
			UIAudioProfile = audioProfile;
			UIEventType = type;
			Destination = null;
			Vehicle = null;
			GroupIndex = -1;
			Screen = ScreenStack.MotorwaysScreen.None;
		}

		public bool IsEventFiltered(AudioEvent audioEvent)
		{
			if ((Type & audioEvent.Type) == AudioEventType.None)
			{
				return false;
			}
			if (UIEventType != UIEventType.None && (UIEventType & audioEvent.UIEventType) == 0)
			{
				return false;
			}
			if (UIAudioProfile != UIAudioProfile.None && (UIAudioProfile & audioEvent.UIAudioProfile) == 0)
			{
				return false;
			}
			if (Destination != null && Destination != audioEvent.Destination)
			{
				return false;
			}
			if (Vehicle != null && Vehicle.Id != audioEvent.Vehicle.Id)
			{
				return false;
			}
			if (GroupIndex > -1 && GroupIndex != audioEvent.GroupIndex)
			{
				return false;
			}
			if (Screen != ScreenStack.MotorwaysScreen.None && Screen != audioEvent.Screen)
			{
				return false;
			}
			return true;
		}

		public static AudioEventFilter FromJSON(JSON.Dictionary jsonFilter)
		{
			AudioEventFilter result = new AudioEventFilter(AudioEventType.None);
			if (jsonFilter == null)
			{
				return result;
			}
			string text = jsonFilter.GetString("type");
			if (text == null)
			{
				return result;
			}
			result.Type = (AudioEventType)Enum.Parse(typeof(AudioEventType), text);
			if (jsonFilter.ContainsKey("uiEventType"))
			{
				result.UIEventType = (UIEventType)Enum.Parse(typeof(UIEventType), jsonFilter.GetString("uiEventType"));
			}
			if (jsonFilter.ContainsKey("uiProfile"))
			{
				result.UIAudioProfile = (UIAudioProfile)Enum.Parse(typeof(UIAudioProfile), jsonFilter.GetString("uiProfile"));
			}
			return result;
		}
	}
}
