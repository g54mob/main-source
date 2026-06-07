using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Motorways.Audio
{
	public class MusicData
	{
		public enum RhythmUpdateType
		{
			RandomParallel = 0,
			LinearParallel = 1,
			LinearUniform = 2,
			RandomSingle = 3,
			RandomAll = 4
		}

		public enum NoteSequenceType
		{
			Forward = 0,
			Backward = 1,
			PingPong = 2,
			Seeded = 3,
			Chaotic = 4,
			AutoReroll = 5
		}

		public struct EngineData
		{
			public string Prefix;

			public Vector2 PitchRange;

			public float Gain;

			public string Sample
			{
				get
				{
					if (!(Prefix != "engine-1"))
					{
						return "engine-1";
					}
					return "Engine_" + Prefix + "_Noise_" + UnityEngine.Random.Range(0, 7);
				}
			}

			public EngineData(string prefix, float pitchMin, float pitchMax, float gain = 1f)
			{
				Prefix = prefix;
				PitchRange = new Vector2(pitchMin, pitchMax);
				Gain = gain;
			}

			public override string ToString()
			{
				return $"EngineData[{Prefix}], PitchRange: {PitchRange.x},{PitchRange.y}";
			}
		}

		public AudioSample Bass;

		public List<Quality> CurrentQualities;

		public Scale CurrentScale;

		public Quality CurrentQuality;

		public static List<string> NoteWindowMenu;

		public static Scale CurrentScaleMenu;

		public static Quality CurrentQualityMenu;

		private int _notePointer;

		public D20 D20 = new D20();

		public int RhythmPointer;

		public int CurrentKey;

		public int StartingKey;

		public static int MenuKey;

		private double FadeInTimeNormal;

		private double FadeInTimePaused;

		private double FadeInProgression;

		private double FadeInProgressionZ;

		private bool FadeInProgressionAsMultiplier;

		public Param.LFO Tremolo;

		public Param.LFO TremoloZ;

		public Param.Vibrato Vibrato;

		public Param.Vibrato VibratoZ;

		public Param.Portamento Portamento;

		public Param.Portamento PortamentoZ;

		public int GlobalPolyphony;

		public double GlobalFadeOut;

		public int LocalPolyphony;

		public double LocalFadeOut;

		public List<Quality> DayQualities;

		public List<Quality> NightQualities;

		public bool DefaultNoteWindowBehavior;

		public List<NoteSequenceType> NoteSequenceStyles;

		private RhythmUpdateType RhythmType;

		public List<Rhythm> Rhythms;

		public Rhythm DrumSequencerRhythm;

		public bool Boom;

		public bool Bap;

		public bool Hat;

		public float DrumVolume = 0.6f;

		public bool UseEuclideanDrumGates = true;

		public float DrumDelayDuration = 5f;

		public float DrumAttackDuration;

		public List<float> EchoDuratios;

		protected int Seed = -1;

		public List<int> WeekendTranspositions;

		public float WeekendQualityChangeChance;

		public float WeekendKeyChangeChance;

		public string EasterEggHorn = Rando.Pick<string>("01", "02", "03", "04", "05");

		public List<string> GroupPrefices = new List<string> { "LineLoop_CIRCLE", "LineLoop_CIRCLE", "LineLoop_CIRCLE", "LineLoop_CIRCLE", "LineLoop_CIRCLE", "LineLoop_CIRCLE" };

		public List<EngineData> GroupEngines = Liszt.From<EngineData>(new EngineData("Three", 0.75f, 1.25f, 0.966051f), new EngineData("engine-1", 0.33f, 0.75f, 0.384952f), new EngineData("Four", 1f, 1.75f, 0.881049f), new EngineData("Orange", 0.5f, 0.75f), new EngineData("Shinkansen", 1.25f, 2f, 0.977237f), new EngineData("Scooter", 0.66f, 1.5f, 0.870964f));

		public List<string> Timbres = Liszt.From<string>("CIRCLE", "CROSS", "EGG", "SQUARE", "WEDGE", "PENTAGON");

		protected float timeAtStart = -1f;

		public List<string> NoteWindow { get; private set; }

		public int NotePointer
		{
			get
			{
				return _notePointer;
			}
			set
			{
				_notePointer = value;
				UpdateNoteWindow();
			}
		}

		public static int TotalCommonToneAttempts { get; private set; }

		public static int TotalCommonToneFailures { get; private set; }

		public static int TotalCommonToneMaxIterations { get; private set; }

		public int CommonToneAttempts { get; private set; }

		public int CommonToneFailures { get; private set; }

		public int CommonToneMaxIterations { get; private set; }

		public double FadeInTime()
		{
			double num = ((AudioSystem.Instance.ActivePulseTimeScale == TimeScale.Single) ? FadeInTimeNormal : FadeInTimePaused);
			double num2 = ((FadeInProgressionZ < 0.001) ? Maf.Lerp(FadeInProgression, FadeInProgressionZ, Get.ZoomOutProgress) : FadeInProgression);
			if (!FadeInProgressionAsMultiplier)
			{
				return num + num2;
			}
			return num * num2;
		}

		public void UpdateNoteWindow(int commonTones = -1, float chordChangeProbability = 1f, int transposeBy = 0, float keyChangeProbability = 0f, bool forceChange = false)
		{
			if (DefaultNoteWindowBehavior || forceChange)
			{
				if (commonTones < 0)
				{
					commonTones = Get.MaxGroups - 1;
				}
				if (transposeBy != 0 && Rando.FlipCoin(keyChangeProbability))
				{
					NoteWindow = Note.Transpose(transposeBy, NoteWindow);
					CurrentKey = Maf.FloorMod(CurrentKey + transposeBy, 12);
					CurrentScale.Key = CurrentKey;
				}
				if (Rando.FlipCoin(chordChangeProbability))
				{
					FindNewChord();
				}
				Dbug.Assert(CurrentScale != null);
				Dbug.Assert(CurrentQuality != null);
				if (this is Menu)
				{
					NoteWindowMenu = NoteWindow.ToList();
					CurrentScaleMenu = CurrentScale;
					CurrentQualityMenu = CurrentQuality;
				}
				DestinationGroup.DivvyUpNoteWindow();
			}
			void FindNewChord()
			{
				int num = Get.MaxGroups;
				Scale currentScale = CurrentScale;
				Quality quality = Quality.Clone(CurrentQuality);
				List<Quality> list = CurrentQualities.ToList();
				commonTones = Mathf.Min(NoteWindow?.Count ?? commonTones, num - 1, commonTones);
				if (NoteWindow == null && NoteWindowMenu != null)
				{
					NoteWindow = NoteWindowMenu.ToList();
					currentScale = CurrentScaleMenu;
					quality = CurrentQualityMenu;
					commonTones = 2;
				}
				Dbug.Log.Info("FindNewChord(): Current scale is {2}.\nCurrent chord is {3}", num, commonTones, CurrentScale?.FullName() ?? "null", (NoteWindow != null) ? string.Join(", ", NoteWindow) : "null");
				bool flag = commonTones == 0;
				if (flag)
				{
					commonTones = 1;
					num++;
				}
				if (NoteWindow == null)
				{
					CurrentQuality = list.Pick();
					NoteWindow = CurrentQuality.Notes(Get.Loadout.MusicData.CurrentKey, num, out CurrentScale);
					Dbug.Log.Info("Using the Quick Solution to grab a chord from {0}.\nAssigning the chord {1}\n", CurrentScale.FullName(), string.Join(", ", NoteWindow));
				}
				else
				{
					Dbug.Log.Info("Need {0} commonTones and {1} NonCommonTones", commonTones, num - commonTones);
					list.Shuffle();
					if (quality != null)
					{
						list.Insert(Mathf.Min(list.Count, 3), quality);
					}
					List<string> list2 = new List<string>();
					int iterations = 0;
					TotalCommonToneAttempts++;
					int commonToneAttempts = CommonToneAttempts + 1;
					CommonToneAttempts = commonToneAttempts;
					for (int i = 0; i < list.Count; i++)
					{
						list2 = list[i].CommonToneChord(NoteWindow, commonTones, num, ref CurrentScale, ref iterations);
						if (list2.Count > 0)
						{
							if (flag)
							{
								list2 = list2.Where((string x) => !NoteWindow.Contains(x)).ToList();
							}
							CurrentQuality = list[i];
							Dbug.Log.Info("CommonToneChord() Attempt {2} : Success. Using {0} > {1}", CurrentQuality.Name, CurrentScale.FullName(), i + 1);
							break;
						}
						if (iterations > 100)
						{
							Dbug.Log.Warn("FindNewChord() Taking too long. Breaking...");
							TotalCommonToneMaxIterations++;
							commonToneAttempts = CommonToneMaxIterations + 1;
							CommonToneMaxIterations = commonToneAttempts;
							break;
						}
						Dbug.Log.Info("CommonToneChord() Attempt {1} : Quality {0} had no Common Tone Chords. Continuing ...", list[i].Name, i + 1);
					}
					Dbug.Assert(list2 != null, "newChord should not be null here.");
					if (list2.Count < num)
					{
						Dbug.Log.Warn("FindNewChord() could not find a new chord of size {0} with {1} common tones. Using the old chord.", num, commonTones);
						TotalCommonToneFailures++;
						commonToneAttempts = CommonToneFailures + 1;
						CommonToneFailures = commonToneAttempts;
						CurrentScale = currentScale;
						CurrentQuality = quality;
						list2 = NoteWindow;
					}
					Dbug.Log.Info("Assigning the chord {0}\n", string.Join(", ", list2));
					NoteWindow = list2;
				}
			}
		}

		public float EchoDuration()
		{
			return Get.Pulse.Duratio((EchoDuratios != null) ? Rando.Pick(EchoDuratios) : 1f);
		}

		public void SetFadeInTimes(double normal, double paused)
		{
			FadeInTimeNormal = normal;
			FadeInTimePaused = paused;
		}

		public void SetFadeInProgression(double start, double end, bool asMultiplier)
		{
			FadeInProgressionAsMultiplier = asMultiplier;
			FadeInProgression = start;
			FadeInProgressionZ = end;
		}

		public void SetTremolo(Param.LFO a, Param.LFO z = null)
		{
			Tremolo = a;
			TremoloZ = z;
		}

		public void SetVibrato(Param.Vibrato a, Param.Vibrato z = null)
		{
			Vibrato = a;
			VibratoZ = z;
		}

		public void SetPortamento(Param.Portamento a, Param.Portamento z = null)
		{
			Portamento = a;
			PortamentoZ = z;
		}

		public void SetVoiceLimits(double globalFadeOut, int globalPolyphony, double localFadeOut = 0.0, int localPolyphony = 5)
		{
			GlobalFadeOut = globalFadeOut;
			GlobalPolyphony = globalPolyphony;
			LocalPolyphony = localPolyphony;
			LocalFadeOut = localFadeOut;
		}

		public void SetQualities(List<Quality> dayQualities, List<Quality> nightQualities = null, bool defaultNoteWindowBehavior = true)
		{
			DefaultNoteWindowBehavior = defaultNoteWindowBehavior;
			DayQualities = dayQualities.ToList();
			NightQualities = nightQualities?.ToList() ?? null;
		}

		public void SetNoteSequenceStyles(List<NoteSequenceType> styles)
		{
			NoteSequenceStyles = styles.ToList();
		}

		public void SetRhythms(List<Rhythm> rhythms, RhythmUpdateType type = RhythmUpdateType.RandomParallel)
		{
			Rhythms = rhythms.ToList();
			RhythmType = type;
		}

		public void SetDrumSequencer(Rhythm rhythm, bool boom = false, bool bap = false, bool hat = false, bool useEuclideanGates = true, float delayDuration = -1f, float attackDuration = -1f)
		{
			DrumSequencerRhythm = rhythm ?? DrumSequencerRhythm;
			Boom = boom;
			Bap = bap;
			Hat = hat;
			UseEuclideanDrumGates = useEuclideanGates;
			DrumDelayDuration = ((delayDuration < 0f) ? DrumDelayDuration : delayDuration);
			DrumAttackDuration = ((attackDuration < 0f) ? DrumAttackDuration : attackDuration);
		}

		public void UpdateDrumSequencer(Rhythm rhythm, bool boom = false, bool bap = false, bool hat = false, bool flipEuclideanGates = false)
		{
			bool flag = rhythm != DrumSequencerRhythm;
			DrumSequencerRhythm = rhythm ?? DrumSequencerRhythm;
			if (DrumSequencerRhythm != null)
			{
				Boom = boom;
				Bap = bap;
				Hat = hat;
				if (flipEuclideanGates)
				{
					UseEuclideanDrumGates = !UseEuclideanDrumGates;
				}
				if (flag)
				{
					Get.Loadout.DrumSequencer?.ChangePulse(DrumSequencerRhythm);
				}
			}
		}

		public void SetEchoDuratios(List<float> duratios)
		{
			EchoDuratios = duratios.ToList();
		}

		public void SetSeed(int seed)
		{
			Seed = seed;
		}

		public void SetKeyDeltas(List<int> weekend, int starting = 20)
		{
			WeekendTranspositions = weekend ?? Liszt.From<int>(default(int));
			StartingKey = ((starting != 20) ? starting : D20.Pick(WeekendTranspositions));
		}

		public void SetWeekendChances(float chordChange = 1f, float keyChange = 1f)
		{
			WeekendQualityChangeChance = chordChange;
			WeekendKeyChangeChance = keyChange;
		}

		public void SetEasterEggHorn(string suffix)
		{
			EasterEggHorn = suffix;
		}

		public void UpdateTrain(int patternLengthOverride = -1, float kickDoublingProbability = -1f, int bVariablePulse = -1, params string[] engines)
		{
			if (patternLengthOverride > 0)
			{
				Get.Loadout.Train.PatternLengthOverride = patternLengthOverride;
			}
			if (kickDoublingProbability >= -0f)
			{
				Get.Loadout.Train.KickDoublingProbability = kickDoublingProbability;
			}
			if (bVariablePulse > -1)
			{
				Get.Loadout.Train.VariablePulseMode = bVariablePulse == 1;
			}
			if (engines.Length != 0)
			{
				Get.Loadout.Train.TrainEngines = engines.ToList();
			}
			Get.Loadout.Train.Reseed();
		}

		public virtual int ChordSize()
		{
			return NoteWindow.Count;
		}

		public virtual float ChordSpread()
		{
			return 0.05f;
		}

		public virtual float SamplePitchSign()
		{
			if (!Get.Game.Simulation.IsPaused && !Get.State.HasFlag(StateType.ModeDelete) && !Rando.FlipCoin(Clock.GainFactor))
			{
				return 1f;
			}
			return -1f;
		}

		public MusicData()
		{
			SetFadeInProgression(0.0, 0.0, asMultiplier: false);
			SetFadeInTimes(0.0, 0.0);
			SetQualities(QualityDatabase.ALL);
			SetKeyDeltas(Rando.Numbers(13, -6));
			SetWeekendChances();
			SetTremolo(new Param.LFO(new Param.Data(0.25f, 10f), new Param.Data(0f, 0.5f)));
			SetVibrato(new Param.Vibrato(new Param.Data(4f, 10f), 15));
			SetPortamento(new Param.Portamento());
			SetNoteSequenceStyles(Liszt.Make(6, () => NoteSequenceType.AutoReroll));
			double globalFadeOut = D20.Range(0.01f, 2f);
			D20 d = D20;
			int[] obj = new int[4] { 1, 2, 3, 0 };
			obj[3] = D20.Range(4, Get.MaxGroups);
			SetVoiceLimits(globalFadeOut, d.Pick(obj));
			SetRhythms(Rhythm.Frags());
			SetEchoDuratios(Liszt.From<float>(0.5f, 1f / 3f, 0.25f, 1f / 6f, 0.125f, 1.25f, 1.3333334f, 1.5f));
			SetDrumSequencer(new Rhythm(0f, 1f));
			if (!(this is Menu))
			{
				Settings.PITCH_NIGHT = D20.Range(1.2f, 1.6666666f);
				Settings.PITCH_PAUSE = D20.Range(5f / 6f, 0.9375f);
			}
		}

		public virtual void Injections()
		{
		}

		public virtual void OnNewWeek()
		{
			SetEchoDuratios(Liszt.From<float>(Rhythms.SafeGet(RhythmPointer).Duration));
			FX.UpdateEcho();
		}

		public virtual void OnDestinationActivated(int index)
		{
		}

		public virtual void OnDawn()
		{
		}

		public virtual void OnDusk()
		{
		}

		public virtual void OnDay()
		{
		}

		public virtual void OnHour()
		{
		}

		public virtual void OnDestinationConnected(int groupIndex)
		{
		}

		public virtual void OnHouseConnected(int groupIndex)
		{
		}

		public virtual void OnConnection()
		{
		}

		public virtual void OnDrumPulse()
		{
		}

		public virtual void OnDrumRhythmComplete()
		{
		}

		public virtual void OnTrainArrived()
		{
			Get.Loadout.Train.Reseed();
		}

		public virtual void OnRhythmUpdate(int groupIndex)
		{
			switch (RhythmType)
			{
			case RhythmUpdateType.LinearParallel:
				foreach (DestinationGroup destinationGroup in Get.Loadout.DestinationGroups)
				{
					destinationGroup.Module.ChangePulse(Rhythms.SafeGet(destinationGroup.Index + RhythmPointer));
				}
				break;
			case RhythmUpdateType.RandomSingle:
			{
				List<DestinationGroup> destinationGroups = Get.Loadout.DestinationGroups;
				if (groupIndex >= 0 && groupIndex < destinationGroups.Count)
				{
					Get.Loadout.DestinationGroups[groupIndex].Module.ChangePulse(Rando.Pick(Rhythms));
				}
				break;
			}
			case RhythmUpdateType.RandomAll:
				foreach (DestinationGroup destinationGroup2 in Get.Loadout.DestinationGroups)
				{
					destinationGroup2.Module.ChangePulse(Rando.Pick(Rhythms));
				}
				break;
			case RhythmUpdateType.RandomParallel:
				foreach (DestinationGroup destinationGroup3 in Get.Loadout.DestinationGroups)
				{
					destinationGroup3.Module.ChangePulse(Rhythms.SafeGet(destinationGroup3.Seed + RhythmPointer));
				}
				break;
			case RhythmUpdateType.LinearUniform:
				foreach (DestinationGroup destinationGroup4 in Get.Loadout.DestinationGroups)
				{
					destinationGroup4.Module.ChangePulse(Rhythms.SafeGet(RhythmPointer));
				}
				break;
			}
			RhythmPointer++;
		}

		public void Initialize()
		{
			CurrentQualities = DayQualities.ToList();
			if (Get.State.HasFlag(StateType.ModeNight) && NightQualities != null)
			{
				CurrentQualities = NightQualities.ToList();
			}
			Timbres.Shuffle(D20);
			GroupEngines.Shuffle(D20);
			GroupPrefices.Shuffle(D20);
			Timbres = Timbres.GetRange(0, 6);
			GroupEngines = GroupEngines.GetRange(0, 6);
			GroupPrefices = GroupPrefices.GetRange(0, 6);
			CurrentKey = Maf.FloorMod(StartingKey, 12);
			UpdateNoteWindow(-1, 1f, 0, 0f, forceChange: true);
			Dbug.Log.Info(_ToString());
		}

		public virtual void PostLoad()
		{
			UpdateDrumSequencer(DrumSequencerRhythm, Boom, Bap, Hat);
			timeAtStart = Time.time;
		}

		private string _ToString()
		{
			return string.Format("{0}.\n\nSeed: {1}, StartingKey: {2}\n\nRhythms:\n{3}\n\nPitch Night: {4}, Pitch Pause: {5}\n\nTimbres: {6}\n\nEngines:\n{7}\n\nVoice Limiting:\n{8}\n\nNote Sequence Styles:\n{9}\n\nCurrentScale:\n{10}", GetType().ToString(), Seed, StartingKey, string.Join("\n", Rhythms), Settings.PITCH_NIGHT, Settings.PITCH_PAUSE, string.Join(", ", Timbres), string.Join("\n", GroupEngines), $"FadeTime: {GlobalFadeOut:0.###}, Polyphony: {GlobalPolyphony}", string.Join("\n", NoteSequenceStyles), CurrentScale?.FullName() ?? "Time Out");
		}

		public override string ToString()
		{
			return _ToString();
		}

		public virtual Rhythm PickInitRhythm(int groupIndex)
		{
			switch (RhythmType)
			{
			case RhythmUpdateType.RandomParallel:
			case RhythmUpdateType.RandomSingle:
				return Rando.Pick(Rhythms);
			case RhythmUpdateType.LinearUniform:
				return new D20(Seed).Pick(Rhythms);
			case RhythmUpdateType.LinearParallel:
				return Rhythms.SafeGet(groupIndex);
			default:
				return Rhythms.SafeGet(groupIndex);
			}
		}
	}
}
