using System.Collections.Generic;
using GAudio;
using UnityEngine;

namespace Motorways.Audio
{
	public class AudioDatabase
	{
		private GATActiveSampleBank masterBank;

		private MasterPulseModule masterPulse;

		private Dictionary<string, SubPulseModule> subPulses = new Dictionary<string, SubPulseModule>();

		private Dictionary<string, AudioLoadout> loadouts = new Dictionary<string, AudioLoadout>();

		private List<AudioDataBank> audioDataBanks = new List<AudioDataBank>();

		private List<AudioDataBank> activeAudioDataBanks = new List<AudioDataBank>();

		public GATActiveSampleBank MasterBank => masterBank;

		public GATActiveSampleBank DefaultSampleBank => masterBank;

		public MasterPulseModule MasterPulse => masterPulse;

		private int SampleBankRate
		{
			get
			{
				if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
				{
					return 24000;
				}
				int outputSampleRate = AudioSettings.outputSampleRate;
				int[] array = new int[3] { 24000, 44100, 48000 };
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] >= outputSampleRate)
					{
						return array[i];
					}
				}
				return array[array.Length - 1];
			}
		}

		public AudioDatabase()
		{
			new GameObject("GATManager").AddComponent<GATManager>();
			this.CreateBanks();
			CreatePulseModules();
		}

		public bool LoadBanks()
		{
			masterBank = LoadSampleBank();
			if (masterBank == null)
			{
				return false;
			}
			return true;
		}

		public bool LoadLoadouts()
		{
			foreach (string item in new List<string>
			{
				"Audio/Loadouts/sfx", "Audio/Loadouts/city", "Audio/Loadouts/menu", "Audio/Loadouts/beijing", "Audio/Loadouts/daressalaam", "Audio/Loadouts/dubai", "Audio/Loadouts/losangeles", "Audio/Loadouts/manila", "Audio/Loadouts/mexicocity", "Audio/Loadouts/moscow",
				"Audio/Loadouts/munich", "Audio/Loadouts/riodejaneiro", "Audio/Loadouts/tokyo", "Audio/Loadouts/tutorial", "Audio/Loadouts/wellington", "Audio/Loadouts/zurich", "Audio/Loadouts/warsaw", "Audio/Loadouts/chiangmai", "Audio/Loadouts/lisbon", "Audio/Loadouts/busan",
				"Audio/Loadouts/london", "Audio/Loadouts/mumbai", "Audio/Loadouts/newyorkcity", "Audio/Loadouts/reykjavik", "Audio/Loadouts/vancouver", "Audio/Loadouts/copenhagen", "Audio/Loadouts/cairns", "Audio/Loadouts/hongkong", "Audio/Loadouts/osaka", "Audio/Loadouts/capetown"
			})
			{
				object obj = null;
				if (obj == null)
				{
					obj = JSON.Load(item);
				}
				if (obj == null)
				{
					AudioSystem.Log.Error("AudioDatabase: Failed to load {0} as JSON.", item);
					continue;
				}
				AudioLoadout audioLoadout = AudioLoadout.FromJSON(obj as JSON.Dictionary);
				if (audioLoadout == null)
				{
					AudioSystem.Log.Error("AudioDatabase: Failed to parse {0}.", item);
				}
				else
				{
					loadouts[audioLoadout.Id] = audioLoadout;
				}
			}
			return true;
		}

		public AudioDataBank CreateDataBank(string id, int frequency, bool isCompressed = false)
		{
			AudioDataBank audioDataBank = new AudioDataBank(id, frequency);
			audioDataBanks.Add(audioDataBank);
			return audioDataBank;
		}

		public bool LoadSample(string name)
		{
			return GetSampleData(name) != null;
		}

		public AudioSampleData GetSampleData(string name)
		{
			for (int i = 0; i < activeAudioDataBanks.Count; i++)
			{
				AudioSampleData sampleData = activeAudioDataBanks[i].GetSampleData(name);
				if (sampleData != null)
				{
					return sampleData;
				}
			}
			AudioSystem.Log.Error("AudioDatabase: Failed to find data for sample '{0}'.", name);
			return null;
		}

		public AudioLoadout GetLoadout(string id)
		{
			if (!loadouts.ContainsKey(id))
			{
				return null;
			}
			return loadouts[id];
		}

		public GATActiveSampleBank GetSampleBank(string bankId)
		{
			return null;
		}

		public SubPulseModule GetPulse(int stepCount, string key = "")
		{
			if (key == "")
			{
				key = stepCount.ToString();
			}
			if (subPulses.TryGetValue(key, out var value))
			{
				return value;
			}
			if (stepCount <= 0)
			{
				return null;
			}
			value = CreateSubPulseModule("Subpulse: 1/" + stepCount, stepCount);
			subPulses.Add(stepCount.ToString(), value);
			return value;
		}

		public SubPulseModule GetHyperPulse(Rhythm rhythm)
		{
			if (subPulses.TryGetValue(rhythm.Id, out var value))
			{
				return value;
			}
			value = CreateHyperPulseModule(rhythm);
			subPulses.Add(rhythm.Id, value);
			return value;
		}

		private GATActiveSampleBank LoadSampleBank()
		{
			int sampleBankRate = SampleBankRate;
			if (sampleBankRate != AudioSettings.outputSampleRate)
			{
				AudioSystem.Log.Info("AudioDatabase: Resampling {0} Hz audio to {1} Hz.", sampleBankRate, AudioSettings.outputSampleRate);
			}
			if (!LoadAudioBank("core", sampleBankRate, async: false))
			{
				return null;
			}
			return new GameObject("sampleBank").AddComponent<GATActiveSampleBank>();
		}

		private void CreatePulseModules()
		{
			GameObject gameObject = new GameObject("Pulse: Master");
			masterPulse = gameObject.AddComponent<MasterPulseModule>();
			bool[] array = new bool[12];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = true;
			}
			masterPulse.Steps = array;
			masterPulse.Period = 5.0 / 6.0;
			masterPulse.StartPulsing(0);
		}

		private SubPulseModule CreateSubPulseModule(string name, int stepCount)
		{
			SubPulseModule subPulseModule = new GameObject(name).AddComponent<SubPulseModule>();
			subPulseModule.transform.parent = MasterPulse.transform;
			bool[] array = new bool[stepCount];
			for (int i = 0; i < stepCount; i++)
			{
				array[i] = true;
			}
			subPulseModule.Steps = array;
			subPulseModule.SubPulseMode = SubPulseModule.PeriodMode.SubdivideParent;
			subPulseModule.ParentPulse = masterPulse;
			return subPulseModule;
		}

		public SubPulseModule CreateHyperPulseModule(Rhythm rhythm)
		{
			SubPulseModule subPulseModule = new GameObject(rhythm.Id).AddComponent<SubPulseModule>();
			subPulseModule.transform.parent = MasterPulse.transform;
			bool[] array = new bool[rhythm.Steps.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = true;
			}
			subPulseModule.Steps = array;
			subPulseModule.Ratios = rhythm.Steps;
			subPulseModule.RatioOffset = rhythm.Offset;
			subPulseModule.SubPulseMode = SubPulseModule.PeriodMode.Hyper;
			subPulseModule.ParentPulse = masterPulse;
			return subPulseModule;
		}

		private bool LoadAudioBank(string id, int sampleRate, bool async)
		{
			for (int i = 0; i < audioDataBanks.Count; i++)
			{
				AudioDataBank audioDataBank = audioDataBanks[i];
				if (audioDataBank.Id == id && audioDataBank.Frequency == sampleRate)
				{
					if (!audioDataBank.Load(async))
					{
						AudioSystem.Log.Warn("AudioDatabase: Failed to load audio bank '{0}' for {1} kHz.", id, sampleRate);
						return false;
					}
					activeAudioDataBanks.Add(audioDataBank);
					return true;
				}
			}
			AudioSystem.Log.Warn("AudioDatabase: Failed to find audio bank '{0}' for {1} kHz.", id, sampleRate);
			return false;
		}
	}
}
