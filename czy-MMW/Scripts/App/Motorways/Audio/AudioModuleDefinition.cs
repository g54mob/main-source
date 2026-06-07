using System;
using System.Collections.Generic;

namespace Motorways.Audio
{
	public class AudioModuleDefinition
	{
		private AudioLoadout parentLoadout;

		private AudioEventFilter filter;

		private Dictionary<string, Attribute> attributes = new Dictionary<string, Attribute>();

		public string Id { get; private set; }

		public int Order { get; private set; }

		public AudioModuleType Type
		{
			get
			{
				Attribute attribute = GetAttribute("type");
				if (attribute == null)
				{
					return AudioModuleType.None;
				}
				return (AudioModuleType)Enum.Parse(typeof(AudioModuleType), attribute.GetString(parentLoadout));
			}
		}

		public AudioEventFilter Filter
		{
			get
			{
				if (filter.Type != AudioEventType.None)
				{
					return filter;
				}
				return BaseDefinition?.Filter ?? filter;
			}
		}

		private AudioModuleDefinition BaseDefinition
		{
			get
			{
				if (!string.IsNullOrEmpty(Id) && Id.Length > 0)
				{
					AudioLoadout baseLoadout = parentLoadout.BaseLoadout;
					if (baseLoadout != null)
					{
						return baseLoadout.GetModuleDefinition(Id);
					}
				}
				return null;
			}
		}

		public bool IsMute(AudioLoadout loadout)
		{
			return GetBool(loadout, "mute");
		}

		public bool IsSolo(AudioLoadout loadout)
		{
			return GetBool(loadout, "solo");
		}

		public IAudioModule CreateModule(AudioLoadout loadout)
		{
			IAudioModule audioModule = null;
			Playback playback = null;
			switch (Type)
			{
			case AudioModuleType.Experiment:
				playback = new Experiment(Filter);
				break;
			case AudioModuleType.DestinationInstancer:
				audioModule = new DestinationInstancer(Filter);
				break;
			case AudioModuleType.VehicleInstancer:
				audioModule = new VehicleInstancer(Filter);
				break;
			case AudioModuleType.SFX:
				audioModule = new SFX();
				break;
			case AudioModuleType.Persistent:
				audioModule = new Persistent();
				break;
			case AudioModuleType.Clock:
				playback = new Clock(Filter, Id);
				break;
			case AudioModuleType.DemandTimer:
				playback = new DemandTimer(Filter);
				break;
			case AudioModuleType.House:
				playback = new House(Filter);
				break;
			case AudioModuleType.Road:
				playback = new Road(Filter);
				break;
			case AudioModuleType.Motorway:
				playback = new Motorway(Filter);
				break;
			case AudioModuleType.TrafficLight:
				playback = new TrafficLight(Filter);
				break;
			}
			if (audioModule == null && playback != null)
			{
				audioModule = PulsedAudioModule.CreateModule(Id, playback, null, GetInt(loadout, "pulse", 1));
			}
			return audioModule;
		}

		public bool GetBool(AudioLoadout loadout, string name, bool defaultValue = false)
		{
			return GetAttribute(name)?.GetBool(loadout) ?? defaultValue;
		}

		public int GetInt(AudioLoadout loadout, string name, int defaultValue = 0)
		{
			return GetAttribute(name)?.GetInt(loadout) ?? defaultValue;
		}

		public int[] GetIntArray(AudioLoadout loadout, string name, int[] defaultValue = null)
		{
			Attribute attribute = GetAttribute(name);
			if (attribute == null)
			{
				return defaultValue;
			}
			return attribute.GetIntArray(loadout);
		}

		public float GetFloat(AudioLoadout loadout, string name, float defaultValue = 0f)
		{
			return GetAttribute(name)?.GetFloat(loadout) ?? defaultValue;
		}

		public float[] GetFloatArray(AudioLoadout loadout, string name, float[] defaultValue = null)
		{
			Attribute attribute = GetAttribute(name);
			if (attribute == null)
			{
				return defaultValue;
			}
			return attribute.GetFloatArray(loadout);
		}

		public string GetString(AudioLoadout loadout, string name, string defaultValue = null)
		{
			Attribute attribute = GetAttribute(name);
			if (attribute == null)
			{
				return defaultValue;
			}
			return attribute.GetString(loadout);
		}

		public string[] GetStringArray(AudioLoadout loadout, string name, string[] defaultValue = null)
		{
			Attribute attribute = GetAttribute(name);
			if (attribute == null)
			{
				return defaultValue;
			}
			return attribute.GetStringArray(loadout);
		}

		private Attribute GetAttribute(string name)
		{
			if (attributes.ContainsKey(name))
			{
				return attributes[name];
			}
			return BaseDefinition?.GetAttribute(name);
		}

		public static AudioModuleDefinition FromJSON(AudioLoadout loadout, JSON.Dictionary jsonDictionary)
		{
			if (jsonDictionary == null)
			{
				return null;
			}
			AudioModuleDefinition audioModuleDefinition = new AudioModuleDefinition(loadout);
			foreach (string key in jsonDictionary.Keys)
			{
				if (key == "id")
				{
					audioModuleDefinition.Id = jsonDictionary.GetString("id");
					continue;
				}
				if (key == "name" && string.IsNullOrEmpty(audioModuleDefinition.Id))
				{
					audioModuleDefinition.Id = jsonDictionary.GetString("name");
				}
				if (key == "filter")
				{
					audioModuleDefinition.filter = AudioEventFilter.FromJSON(jsonDictionary.GetDictionary("filter"));
					continue;
				}
				if (key == "order")
				{
					audioModuleDefinition.Order = jsonDictionary.GetInt("order");
					continue;
				}
				Attribute attribute = Attribute.FromJSON(jsonDictionary[key]);
				if (attribute != null)
				{
					audioModuleDefinition.attributes[key] = attribute;
				}
			}
			return audioModuleDefinition;
		}

		private AudioModuleDefinition(AudioLoadout loadout)
		{
			parentLoadout = loadout;
			Order = int.MaxValue;
		}
	}
}
