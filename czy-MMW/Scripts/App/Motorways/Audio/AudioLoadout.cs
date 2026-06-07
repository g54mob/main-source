using System.Collections.Generic;
using Motorways.Views;
using Motorways.Views.Boats;
using Motorways.Views.Trains;
using UnityEngine;

namespace Motorways.Audio
{
	public class AudioLoadout
	{
		public List<DestinationGroup> DestinationGroups = new List<DestinationGroup>();

		public MusicData MusicData;

		public DrumSequencer DrumSequencer;

		public Train Train;

		public Boat Boat;

		private bool isActive;

		private AudioEnvironment Environment;

		private Dictionary<string, Attribute> constants;

		private List<AudioModuleDefinition> moduleDefinitions = new List<AudioModuleDefinition>();

		private List<IAudioModule> modules;

		private List<IAudioModule> dynamicModules = new List<IAudioModule>();

		public static AudioLoadout PersistentLoadout;

		private AudioLoadout _baseLoadout;

		public GameObject GameObject { get; private set; }

		public string Id { get; private set; }

		public List<Rhythm> DestinationGroupRhythms
		{
			get
			{
				List<Rhythm> list = new List<Rhythm>();
				foreach (DestinationGroup destinationGroup in Get.Loadout.DestinationGroups)
				{
					list.Add(destinationGroup.Module.Rhythm);
				}
				return list;
			}
		}

		public AudioLoadout BaseLoadout => _baseLoadout;

		public bool IsActive => isActive;

		private AudioLoadout()
		{
		}

		private void CreateDestinationGroups()
		{
			int num = 0;
			foreach (List<DestinationView> destination in Get.Environment.Destinations)
			{
				foreach (DestinationView item in destination)
				{
					num = Mathf.Max(num, item.groupIndex + 1);
				}
			}
			DestinationGroups.Clear();
			for (int i = 0; i < num; i++)
			{
				DestinationGroups.Add(CreateDestinationGroup(i));
			}
		}

		private DestinationGroup CreateDestinationGroup(int groupIndex)
		{
			Dbug.Log.Info("AudioLoadout.CreateDestinationGroup(): New Destination Group: {0}", groupIndex);
			AudioEventFilter filter = new AudioEventFilter
			{
				GroupIndex = groupIndex
			};
			DestinationGroup destinationGroup = new DestinationGroup(filter);
			IAudioModule dynamicModule = PulsedAudioModule.CreateModule("Destination Group " + filter.GroupIndex, destinationGroup, MusicData.PickInitRhythm(filter.GroupIndex));
			AddDynamicModule(dynamicModule);
			return destinationGroup;
		}

		public DestinationGroup GetDestinationGroup(int groupIndex)
		{
			if (groupIndex < DestinationGroups.Count)
			{
				return DestinationGroups[groupIndex];
			}
			while (groupIndex >= DestinationGroups.Count)
			{
				DestinationGroups.Add(CreateDestinationGroup(DestinationGroups.Count));
			}
			return DestinationGroups[groupIndex];
		}

		private void CreateBoatModule()
		{
			Boat = null;
			if (Environment.Boats.Count > 0)
			{
				BoatView boatView = Environment.Boats[0];
				Boat = new Boat(boatView);
				AddDynamicModule(PulsedAudioModule.CreateModule("Boat " + boatView.name, Boat, null, 4));
			}
		}

		private void CreateTrainModule()
		{
			Train = null;
			if (Environment.Trains.Count > 0)
			{
				TrainView trainView = Environment.Trains[0];
				Train = new Train(trainView);
				AddDynamicModule(PulsedAudioModule.CreateModule("Train " + trainView.name, Train, null, 4));
			}
		}

		private void CreateVehicleModules()
		{
			if (Environment.Vehicles[0].Count == 0)
			{
				Dbug.Log.Warn("CreateVehicleModules(): No vehicles in group index 0.");
				return;
			}
			foreach (List<VehicleView> vehicle in Environment.Vehicles)
			{
				foreach (VehicleView item in vehicle)
				{
					if (item.AudioVehicle == null)
					{
						AudioEventFilter audioEventFilter = new AudioEventFilter
						{
							Vehicle = item
						};
						Playback playback = new Vehicle(item);
						IAudioModule dynamicModule = PulsedAudioModule.CreateModule("Vehicle " + item.Id, playback, null, 4);
						AddDynamicModule(dynamicModule);
					}
				}
			}
		}

		private void CreateDrumSequencer()
		{
			DrumSequencer = new DrumSequencer();
			IAudioModule dynamicModule = PulsedAudioModule.CreateModule("DrumSequencer " + Environment.City.Definition.name, DrumSequencer, null, 1);
			AddDynamicModule(dynamicModule);
		}

		public void Activate(AudioEnvironment environment = null)
		{
			AudioSystem.Log.Info("AudioLoadout: Activating loadout {0}. isActive == {1}", Id, isActive);
			Environment = environment ?? Get.Environment;
			if (!isActive)
			{
				if (Id != "sfx")
				{
					MusicData = Id switch
					{
						"menu" => new Menu(), 
						"tutorial" => new Tutorial(), 
						"beijing" => new Beijing(), 
						"daressalaam" => new DarEsSalaam(), 
						"losangeles" => new LosAngeles(), 
						"manila" => new Manila(), 
						"moscow" => new Moscow(), 
						"munich" => new Munich(), 
						"riodejaneiro" => new RioDeJaneiro(), 
						"tokyo" => new Tokyo(), 
						"mexicocity" => new MexicoCity(), 
						"dubai" => new Dubai(), 
						"zurich" => new Zurich(), 
						"wellington" => new Wellington(), 
						"chiangmai" => new ChiangMai(), 
						"warsaw" => new Warsaw(), 
						"lisbon" => new Lisbon(), 
						"busan" => new Busan(), 
						"london" => new London(), 
						"mumbai" => new Mumbai(), 
						"newyorkcity" => new NewYorkCity(), 
						"reykjavik" => new Reykjavik(), 
						"vancouver" => new Vancouver(), 
						"copenhagen" => new Copenhagen(), 
						"cairns" => new Cairns(), 
						"hongkong" => new HongKong(), 
						_ => new MusicData(), 
					};
					MusicData.Injections();
					MusicData.Initialize();
					CreateModules();
					CreateDestinationGroups();
					CreateVehicleModules();
					CreateDrumSequencer();
					CreateTrainModule();
					CreateBoatModule();
					MusicData.PostLoad();
				}
				else
				{
					CreateModules();
					PersistentLoadout = this;
				}
				isActive = true;
			}
			for (int i = 0; i < modules.Count; i++)
			{
				modules[i].Activate(environment);
			}
		}

		public void Deactivate()
		{
			if (isActive)
			{
				AudioSystem.Log.Info("AudioLoadout: Deactivating, then Resetting loadout {0}.", Id);
				isActive = false;
				for (int i = 0; i < modules.Count; i++)
				{
					modules[i].Deactivate();
				}
				Reset();
				for (int j = 0; j < dynamicModules.Count; j++)
				{
					modules.Remove(dynamicModules[j]);
					dynamicModules[j].Release();
				}
				dynamicModules.Clear();
				Environment = null;
			}
		}

		private void Reset()
		{
			DestinationGroups.Clear();
		}

		public void Update()
		{
			for (int i = 0; i < modules.Count; i++)
			{
				modules[i].UpdateModule();
			}
		}

		public AudioModuleDefinition GetModuleDefinition(string moduleId)
		{
			for (int i = 0; i < moduleDefinitions.Count; i++)
			{
				if (moduleDefinitions[i].Id == moduleId)
				{
					return moduleDefinitions[i];
				}
			}
			if (_baseLoadout == null)
			{
				return null;
			}
			return _baseLoadout.GetModuleDefinition(moduleId);
		}

		public Attribute GetConstant(string name)
		{
			if (constants != null && constants.ContainsKey(name))
			{
				return constants[name];
			}
			if (_baseLoadout != null)
			{
				return _baseLoadout.GetConstant(name);
			}
			return null;
		}

		public void AddDynamicModule(IAudioModule dynamicModule)
		{
			modules.Add(dynamicModule);
			dynamicModules.Add(dynamicModule);
			if (isActive)
			{
				dynamicModule.Activate(Environment);
			}
		}

		public static AudioLoadout FromJSON(JSON.Dictionary jsonDictionary)
		{
			if (jsonDictionary == null)
			{
				return null;
			}
			string text = jsonDictionary.GetString("id");
			if (text == null)
			{
				return null;
			}
			AudioLoadout audioLoadout = new AudioLoadout();
			audioLoadout.Id = text;
			audioLoadout.GameObject = new GameObject();
			string text2 = jsonDictionary.GetString("base");
			if (text2 != null)
			{
				audioLoadout._baseLoadout = AudioSystem.Instance.Database.GetLoadout(text2);
			}
			JSON.Dictionary dictionary = jsonDictionary.GetDictionary("constants");
			if (dictionary != null)
			{
				audioLoadout.constants = new Dictionary<string, Attribute>();
				foreach (string key in dictionary.Keys)
				{
					Attribute attribute = Attribute.FromJSON(dictionary[key]);
					if (attribute != null)
					{
						audioLoadout.constants[key] = attribute;
					}
				}
			}
			JSON.Array array = jsonDictionary.GetArray("modules");
			if (array != null)
			{
				for (int i = 0; i < array.Count; i++)
				{
					JSON.Dictionary dictionary2 = array.GetDictionary(i);
					if (dictionary2 == null)
					{
						continue;
					}
					if (dictionary2.ContainsKey("template") && dictionary2.ContainsKey("instances"))
					{
						JSON.Dictionary dictionary3 = dictionary2.GetDictionary("template");
						JSON.Array array2 = dictionary2.GetArray("instances");
						for (int j = 0; j < array2.Count; j++)
						{
							JSON.Dictionary dictionary4 = array2.GetDictionary(j);
							AudioModuleDefinition audioModuleDefinition = AudioModuleDefinition.FromJSON(audioLoadout, JSON.Dictionary.Merge(dictionary3, dictionary4));
							if (audioModuleDefinition != null)
							{
								audioLoadout.moduleDefinitions.Add(audioModuleDefinition);
							}
						}
					}
					else
					{
						AudioModuleDefinition audioModuleDefinition2 = AudioModuleDefinition.FromJSON(audioLoadout, dictionary2);
						if (audioModuleDefinition2 != null)
						{
							audioLoadout.moduleDefinitions.Add(audioModuleDefinition2);
						}
					}
				}
			}
			if (jsonDictionary.GetBool("activate"))
			{
				audioLoadout.Activate();
			}
			return audioLoadout;
		}

		private void CreateModules()
		{
			List<AudioModuleDefinition> list = null;
			if (_baseLoadout == null)
			{
				list = moduleDefinitions;
			}
			else
			{
				list = new List<AudioModuleDefinition>();
				for (AudioLoadout audioLoadout = this; audioLoadout != null; audioLoadout = audioLoadout._baseLoadout)
				{
					if (audioLoadout.moduleDefinitions != null)
					{
						for (int i = 0; i < audioLoadout.moduleDefinitions.Count; i++)
						{
							AudioModuleDefinition audioModuleDefinition = audioLoadout.moduleDefinitions[i];
							bool flag = false;
							if (audioModuleDefinition.Id != null)
							{
								for (int j = 0; j < list.Count; j++)
								{
									if (list[j].Id == audioModuleDefinition.Id)
									{
										flag = true;
										break;
									}
								}
							}
							if (!flag)
							{
								list.Add(audioModuleDefinition);
							}
						}
					}
				}
			}
			if (list == null)
			{
				return;
			}
			list.Sort((AudioModuleDefinition x, AudioModuleDefinition y) => x.Order - y.Order);
			bool flag2 = false;
			int num = 0;
			while (!flag2 && num < list.Count)
			{
				flag2 = list[num].IsSolo(this);
				num++;
			}
			modules = new List<IAudioModule>();
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				AudioModuleDefinition audioModuleDefinition2 = list[num2];
				if ((!flag2 || audioModuleDefinition2.IsSolo(this)) && !audioModuleDefinition2.IsMute(this))
				{
					IAudioModule audioModule = audioModuleDefinition2.CreateModule(this);
					if (audioModule != null)
					{
						modules.Add(audioModule);
					}
				}
			}
		}
	}
}
