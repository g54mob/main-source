using System.Collections.Generic;
using GAudio;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Audio
{
	public class DestinationGroup : Playback
	{
		private class IdleLoopMix : FX.Modulator
		{
			public IAudioView View;

			private string note;

			private float pan;

			public override float Pan => pan;

			public override float Gain => base.Gain * 0.125f * Note.GainFactor(note);

			public IdleLoopMix(IAudioView view, Vibrato vibrato, Tremolo tremolo, string note = "C2")
				: base(null, vibrato, tremolo)
			{
				View = view;
				this.note = note;
			}

			public override void OnGameTick()
			{
				pan = View?.Pan.x ?? 0.5f;
			}
		}

		private class IdleLoopMixMenu : FX.Modulator
		{
			private float attenuation;

			private string note;

			private Vector3 center = new Vector3(-259f, 100.5f, 30f);

			public override float Gain => base.Gain * (3f / 32f) * Note.GainFactor(note) * attenuation;

			public IdleLoopMixMenu(Vibrato vibrato, Tremolo tremolo, string note = "C2")
				: base(null, vibrato, tremolo)
			{
				this.note = note;
			}

			public override void OnGameTick()
			{
				attenuation = Get.Camera.GameCamera.GetAttenuationFromWorld(center, zoom: false, 500f);
			}
		}

		public int Index;

		public readonly List<string> Notes = new List<string>();

		public List<AudioSample> IdleLoops = new List<AudioSample>();

		public int Note_i;

		public readonly int Seed = Rando.Range(0, 10000);

		public static List<AudioSample> CityIdleLoops = new List<AudioSample>();

		public static List<AudioSample> CityHocketTones = new List<AudioSample>();

		private readonly List<IAudioView> _views = new List<IAudioView>();

		private float _tremFreq;

		private float _tremFreqZ;

		private float _tremAmp;

		private float _tremAmpZ;

		private float _vibrFreq;

		private float _vibrFreqZ;

		private float _vibrAmp;

		private float _vibrAmpZ;

		private int _maxDemand = 10;

		private int _loopPoint = 1;

		private int _loopPointPrev = 1;

		private float _v_gain = 0.17f;

		private string _prefix;

		private int _step;

		private int _dest_i;

		private MusicData.NoteSequenceType _seqStyle;

		private bool _retrograde;

		private bool _doOnce;

		private IAudioView _v;

		private readonly List<IAudioView> _disconnectedViews = new List<IAudioView>();

		private List<AudioSample> HocketTones = new List<AudioSample>();

		public MusicData.NoteSequenceType SequenceStyleActual => _seqStyle;

		private float VibratoFrequencyLive => Mathf.Lerp(_vibrFreq, _vibrFreqZ, Get.ZoomOutProgress);

		private float VibratoAmplitudeLive => Mathf.Lerp(_vibrAmp, _vibrAmpZ, Get.ZoomOutProgress);

		private float TremoloFrequencyLive => Mathf.Lerp(_tremFreq, _tremFreqZ, Get.ZoomOutProgress);

		private float TremoloAmplitudeLive => Mathf.Lerp(_tremAmp, _tremAmpZ, Get.ZoomOutProgress);

		private int HocketCount => Mathf.Min(Notes.Count, _loopPoint);

		public int ViewsCount
		{
			get
			{
				RefreshViews();
				return _views.Count;
			}
		}

		public int ConnectedHouseCount
		{
			get
			{
				if (Index < 0)
				{
					return 0;
				}
				if (Environment?.Houses?.Count > Index)
				{
					return Environment.Houses[Index].Count;
				}
				return 0;
			}
		}

		private void RefreshViews()
		{
			_views.Clear();
			if (Index < 0)
			{
				return;
			}
			if (Environment?.Houses?.Count > Index)
			{
				_views.AddRange(Environment.Houses[Index]);
			}
			if (!(Environment?.Destinations?.Count > Index))
			{
				return;
			}
			List<DestinationView> list = Environment.Destinations[Index];
			for (int i = 0; i < list.Count; i++)
			{
				DestinationView destinationView = list[i];
				if (destinationView.NetworkConnectivity == NetworkConnectivity.Connected)
				{
					_views.Add(destinationView);
				}
			}
		}

		public DestinationGroup(AudioEventFilter filter)
			: base(filter)
		{
			Index = filter.GroupIndex;
			_prefix = Get.Loadout.MusicData.GroupPrefices[Index] + "_";
			SetLFOData();
		}

		private void SetLFOData()
		{
			MusicData musicData = Get.Loadout.MusicData;
			_tremFreq = (_tremFreqZ = musicData.Tremolo.Freq.Range.Random());
			_tremAmp = (_tremAmpZ = musicData.Tremolo.Amp.Range.Random());
			_vibrFreq = (_vibrFreqZ = musicData.Vibrato.Freq.Range.Random());
			_vibrAmp = (_vibrAmpZ = musicData.Vibrato.Amp.Range.Random());
			if (musicData.TremoloZ != null)
			{
				_tremFreqZ = musicData.TremoloZ.Freq.Range.Random();
				_tremAmpZ = musicData.TremoloZ.Amp.Range.Random();
			}
			if (musicData.VibratoZ != null)
			{
				_vibrFreqZ = musicData.VibratoZ.Freq.Range.Random();
				_vibrAmpZ = musicData.VibratoZ.Amp.Range.Random();
			}
		}

		private void StopAndRemoveIdleLoopAt(int i)
		{
			double fadeDuration = 3.5 * ((Get.Pulse.Scale == TimeScale.Double) ? 0.5 : 1.0);
			IdleLoops[i].FadeOutAndStop(fadeDuration);
			CityIdleLoops.Remove(IdleLoops[i]);
			IdleLoops.RemoveAt(i);
		}

		private void ManageIdleLoops(List<string> noteNames, bool isMenu)
		{
			for (int num = IdleLoops.Count - 1; num >= 0; num--)
			{
				if (ConnectedHouseCount == 0 || !ContainsAnyNoteNames(IdleLoops[num].Name, noteNames))
				{
					StopAndRemoveIdleLoopAt(num);
				}
			}
			if (ConnectedHouseCount == 0)
			{
				return;
			}
			List<string> list = new List<string>(noteNames.Count);
			foreach (string note in noteNames)
			{
				if (IdleLoops.TrueForAll((AudioSample idleLoop) => !idleLoop.Name.Contains(note)))
				{
					list.Add(note);
				}
			}
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				float num3;
				IGATDynamicMixInfo mix;
				if (isMenu)
				{
					num3 = Rando.m();
					string note2 = list[num2];
					mix = new IdleLoopMixMenu(new FX.Modulator.Vibrato(VibratoFrequencyLive, VibratoAmplitudeLive, Get.Loadout.MusicData.SamplePitchSign(), UnityEngine.Random.value), new FX.Modulator.Tremolo(TremoloFrequencyLive * 0.25f, TremoloAmplitudeLive * 2f, UnityEngine.Random.value), note2);
				}
				else
				{
					num3 = ((num2 < _disconnectedViews.Count - 1) ? _disconnectedViews[num2].Pan.x : Rando.m());
					mix = new IdleLoopMix(_v, new FX.Modulator.Vibrato(VibratoFrequencyLive, VibratoAmplitudeLive, Get.Loadout.MusicData.SamplePitchSign(), UnityEngine.Random.value), new FX.Modulator.Tremolo(TremoloFrequencyLive * 0.25f, TremoloAmplitudeLive * 2f, UnityEngine.Random.value));
				}
				AudioPlayer audioPlayer = AudioPlayer.Default;
				string sampleName = "LineCreated_" + list[num2];
				double dspTime = time;
				float num4 = Get.Loadout.MusicData.SamplePitchSign();
				AudioSample voice = audioPlayer.PlaySample(sampleName, num3, 1f, num4, 2.0, dspTime, loop: true, mix);
				IdleLoops.AddVoice(voice);
				CityIdleLoops.AddVoice(voice);
			}
		}

		private static bool ContainsAnyNoteNames(string name, List<string> noteNames)
		{
			foreach (string noteName in noteNames)
			{
				if (name.Contains(noteName))
				{
					return true;
				}
			}
			return false;
		}

		public override void OnActivate()
		{
			UpdateLoopPoint();
			DivvyUpNoteWindow();
			LatchToOffsetAndStartPulsing();
		}

		public override void OnDeactivate()
		{
			CityIdleLoops?.ForEach(delegate(AudioSample x)
			{
				x?.FadeOutAndStop(3.0);
			});
			CityHocketTones?.ForEach(delegate(AudioSample x)
			{
				x?.FadeOutAndStop(3.0);
			});
			CityIdleLoops.Clear();
			CityHocketTones.Clear();
			HocketTones.Clear();
			IdleLoops.Clear();
		}

		public override void Update()
		{
			IdleLoops.ForEach(delegate(AudioSample x)
			{
				x?.DynamicMix?.OnGameTick();
			});
			UpdateLoopPoint();
		}

		protected override void OnPulse()
		{
			RefreshViews();
			_disconnectedViews.Clear();
			if (Index < 0 || Index >= Environment.Disconnecteds.Count)
			{
				Diagnostics.FailAssert("Index {0} is OutOfRange of Environment.Disconnecteds Count: {1}", Index, Environment.Disconnecteds.Count);
				return;
			}
			_disconnectedViews.AddRange(Environment.Disconnecteds[Index]);
			if (Notes.Count == 0 || _views.Count == 0)
			{
				return;
			}
			MusicData musicData = Get.Loadout.MusicData;
			if (Get.Loadout.Id != "menu")
			{
				ManageIdleLoops(Notes, isMenu: false);
			}
			else if (Index == 0)
			{
				ManageIdleLoops(Get.Loadout.MusicData.NoteWindow, isMenu: true);
			}
			if (HocketCount == 0)
			{
				return;
			}
			_v = _views[_dest_i % _views.Count];
			int dest_i = _dest_i;
			while (_v is DestinationView && ((DestinationView)_v).PinCount == 0)
			{
				_v = _views[_dest_i % _views.Count];
				if (_dest_i - dest_i >= _views.Count)
				{
					break;
				}
				_dest_i++;
			}
			_dest_i++;
			Note_i = Maf.FloorMod(_step, HocketCount);
			if (Note_i < 0 || Note_i > Notes.Count - 1)
			{
				Diagnostics.FailAssert("Note_i index OutOfBounds. Note_i: {0} - Notes.Count {1}. Clamping Note_i to within bounds.", Note_i, Notes.Count);
				Note_i = Mathf.Clamp(Note_i, 0, Notes.Count - 1);
			}
			if (Diagnostics.Verify(Index < musicData.NoteSequenceStyles.Count, "Index OutOfBounds. Does the map have more Indexes than defined NotSequenceStyles?"))
			{
				_seqStyle = musicData.NoteSequenceStyles[Index];
			}
			if (_seqStyle == MusicData.NoteSequenceType.AutoReroll)
			{
				_seqStyle = Rando.EnumValue<MusicData.NoteSequenceType>(1, Index + musicData.NotePointer);
			}
			switch (_seqStyle)
			{
			case MusicData.NoteSequenceType.Backward:
				_step--;
				break;
			case MusicData.NoteSequenceType.PingPong:
				if (!_retrograde && Note_i == HocketCount - 1)
				{
					_retrograde = true;
				}
				else if (_retrograde && Note_i == 0)
				{
					_retrograde = false;
				}
				_step += ((!_retrograde) ? 1 : (-1));
				break;
			case MusicData.NoteSequenceType.Seeded:
			{
				List<string> list = new List<string>(Notes);
				list.Shuffle(null, musicData.NotePointer);
				Note_i = list.FindIndex((string x) => x == Notes[Note_i]);
				goto default;
			}
			case MusicData.NoteSequenceType.Chaotic:
				_step = UnityEngine.Random.Range(0, 100);
				goto default;
			default:
				_step++;
				break;
			}
			_v_gain = ((_v is DestinationView) ? Twerp.Ease.Out(Mathf.Lerp(0.17f, 0.4f, Mathf.Clamp01((float)((DestinationView)_v).PinCount / (float)_maxDemand)), 2) : 0.17f);
			_v_gain *= Note.GainFactor(Notes[Note_i]);
			if (Get.Loadout.Id == "menu")
			{
				_v_gain = Mathf.Min(_v_gain, 0.060000002f);
			}
			int voiceLimit = Mathf.Min(musicData.LocalPolyphony, Notes.Count);
			HocketTones.Limit(musicData.LocalFadeOut, voiceLimit);
			voiceLimit = Mathf.Min(musicData.GlobalPolyphony, Notes.Count);
			CityHocketTones.Limit((musicData.SamplePitchSign() < 0f) ? 2.0 : musicData.GlobalFadeOut, (musicData.SamplePitchSign() < 0f) ? 4 : voiceLimit);
			float num = ((Get.Loadout.Id == "menu") ? _v.GetAttenuation(zoom: false, 33f) : _v.Attenuation);
			float num2 = musicData.SamplePitchSign();
			bool num3 = musicData.PortamentoZ != null;
			float num4 = (num3 ? Vector2.Lerp(musicData.Portamento.StartingPitch.Range, musicData.PortamentoZ.StartingPitch.Range, Get.ZoomOutProgress).Random() : musicData.Portamento.StartingPitch.Range.Random());
			float num5 = num2 * num4;
			float num6 = (num3 ? Vector2.Lerp(musicData.Portamento.Time.Range, musicData.PortamentoZ.Time.Range, Get.ZoomOutProgress).Random() : musicData.Portamento.Time.Range.Random());
			num6 *= ((Get.Pulse.Scale == TimeScale.Double) ? 0.5f : 1f);
			AudioSample voice = AudioPlayer.Default.PlaySample(_prefix + Notes[Note_i], _v.Pan.x, num * _v_gain, num2, musicData.FadeInTime(), time, loop: false, new FX.Modulator(new FX.Modulator.Portamento(num5, num2, num6), new FX.Modulator.Vibrato(VibratoFrequencyLive, VibratoAmplitudeLive, num2, UnityEngine.Random.value), new FX.Modulator.Tremolo(TremoloFrequencyLive, TremoloAmplitudeLive, UnityEngine.Random.value)));
			HocketTones.AddVoice(voice);
			CityHocketTones.AddVoice(voice);
			while (IdleLoops.Count > Notes.Count - HocketCount)
			{
				StopAndRemoveIdleLoopAt(IdleLoops.Count - 1);
			}
		}

		public override void AddEventListeners()
		{
			EventListener.Add(OnEvents, AudioEventType.HouseSpawned | AudioEventType.DestinationActivated | AudioEventType.DestinationDemanded | AudioEventType.VehicleFulfillsDemand | AudioEventType.DestinationConnectedToNetwork | AudioEventType.HouseConnectedToNetwork | AudioEventType.DestinationMutated, Index);
			EventListener.Add(OnAudioMinimized, AudioEventType.AudioMinimized);
		}

		private void OnAudioMinimized(AudioEvent e)
		{
			OnDeactivate();
		}

		public void OnEvents(AudioEvent e)
		{
			DestinationView destination = e.Destination;
			List<string> window = Get.Loadout.MusicData.NoteWindow;
			switch (e.Type)
			{
			case AudioEventType.DestinationMutated:
			{
				AudioPlayer.UI.PlaySample("interchange_placed", destination.Pan.x, destination.GetAttenuation(zoom: false, 25f) * 0.7f, 0.75f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				double num = 0.6;
				double delayedTriggerTime = AudioPlayer.EarliestSchedulableTime + num;
				AudioPlayer.UI.PlaySample("StationSpawn_" + Get.Loadout.MusicData.Timbres[destination.groupIndex], destination.Pan.x, destination.GetAttenuation(zoom: false, 25f) * 1f, 1f, 0.0, delayedTriggerTime, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				Get.Loadout.MusicData.UpdateNoteWindow(Get.MaxGroups - 2);
				Get.Loadout.MusicData.Bass?.FadeOutAndStop(0.5);
				Get.Loadout.MusicData.Bass = AudioPlayer.Default.PlaySample("bass_" + Note.SCALE[Get.Loadout.MusicData.CurrentScale.Key], e.Destination.Pan.x, e.Destination.Attenuation * 1f, 1f, 0.0, delayedTriggerTime, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				int repeats = 3;
				Maf.Repeat(repeats, delegate(int i)
				{
					AudioPlayer.Default.PlaySample("chordTone_" + Note.Transpose(12, window[i % window.Count]), e.Destination.Pan.x, Note.GainFactor(window[i]) * e.Destination.Attenuation * (Notes.Contains(window[i]) ? 0.33f : 0.15f), 1f, 0.0, delayedTriggerTime + (double)i * 1.25 / (double)repeats, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				}, Rando.FlipCoin());
				break;
			}
			case AudioEventType.DestinationActivated:
				if (!(Get.Loadout.MusicData is Menu))
				{
					Get.Loadout.MusicData.OnDestinationActivated(Index);
					AudioPlayer.UI.PlaySample("StationSpawn_" + Get.Loadout.MusicData.Timbres[destination.groupIndex], destination.Pan.x, destination.GetAttenuation(zoom: false, 25f) * 1f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
					Get.Loadout.MusicData.UpdateNoteWindow(Get.MaxGroups - 2);
					Get.Loadout.MusicData.Bass?.FadeOutAndStop(0.5);
					Get.Loadout.MusicData.Bass = AudioPlayer.Default.PlaySample("bass_" + Note.SCALE[Get.Loadout.MusicData.CurrentScale.Key], e.Destination.Pan.x, e.Destination.Attenuation * 1f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
					Maf.Repeat(window.Count, delegate(int i)
					{
						AudioPlayer.Default.PlaySample("chordTone_" + window[i], e.Destination.Pan.x, Note.GainFactor(window[i]) * e.Destination.Attenuation * (Notes.Contains(window[i]) ? 0.33f : 0.15f), 1f, 0.0, AudioPlayer.EarliestSchedulableTime + (double)i * 0.25 / (double)window.Count);
					}, Rando.FlipCoin());
				}
				break;
			case AudioEventType.DestinationDemanded:
			{
				string text = ((Notes.Count < 1) ? Get.Loadout.MusicData.NoteWindow.SafeGet(-1) : Notes.SafeGet(Note_i));
				bool isImportant = FeatureToggle.IsFeatureEnabled(Feature.SmallPinSFXWithMinimalSoundscape);
				AudioPlayer.Default.PlaySample("StationAdded_" + text, destination.Pan.x, dspTime: Get.Pulse.HybridTime(Module), gain: Note.GainFactor(text) * destination.Attenuation * Twerp.Ease.Out(Mathf.Lerp(Settings.Gain.DESTINATION_DEMANDED.x, Settings.Gain.DESTINATION_DEMANDED.y, (float)destination.PinCount / (float)_maxDemand), 3), pitch: 2f, fadeTime: 0.0, loop: false, mix: null, stereo: false, randomStart: false, startPosition: 0f, isImportant: isImportant);
				break;
			}
			case AudioEventType.VehicleFulfillsDemand:
				AudioPlayer.UI.PlaySample("PinFulfilled-01", destination.Pan.x, destination.Attenuation * Twerp.Ease.Out(Mathf.Lerp(0.05f, 0.2f, (float)destination.PinCount / (float)_maxDemand), 2), 1.33f, 0.0, AudioPlayer.EarliestSchedulableTime + 0.25);
				break;
			case AudioEventType.DestinationConnectedToNetwork:
				if (e.Condition)
				{
					Get.Loadout.MusicData.OnRhythmUpdate(e.GroupIndex);
					Get.Loadout.MusicData.OnDestinationConnected(e.GroupIndex);
				}
				break;
			case AudioEventType.HouseConnectedToNetwork:
				if (e.Condition)
				{
					SetLFOData();
					Get.Loadout.MusicData.OnHouseConnected(e.GroupIndex);
				}
				break;
			}
		}

		private void LatchToOffsetAndStartPulsing()
		{
			if (!_doOnce)
			{
				((SubPulseModule)Module.Pulse).PrepOffset();
				_doOnce = true;
			}
		}

		private void UpdateLoopPoint()
		{
			_loopPoint = Mathf.Max(0, Environment.GetPinCount(Index) - Environment.GetDisconnectedCount(Index));
			if (_loopPoint > 0 && _loopPointPrev > 0 && _loopPoint != _loopPointPrev)
			{
				_step += Maf.FloorMod(_step + (_retrograde ? 1 : (-1)), _loopPointPrev) - Maf.FloorMod(_step + (_retrograde ? 1 : (-1)), _loopPoint);
			}
			_loopPointPrev = _loopPoint;
		}

		public static void DivvyUpNoteWindow()
		{
			if (Get.Loadout.DestinationGroups.Count < 1)
			{
				Dbug.Log.Info("Note Divvy : No Groups !");
				return;
			}
			if (Get.Loadout.DestinationGroups.Count < 2)
			{
				Dbug.Log.Info("Note Divvy : Only One Group, Giving Them All The Notes !");
				Get.Loadout.DestinationGroups[0].Notes.Clear();
				Get.Loadout.DestinationGroups[0].Notes.AddRange(Get.Loadout.MusicData.NoteWindow);
				return;
			}
			int maxGroups = Get.MaxGroups;
			int audibleGroups = AudioEnvironment.Instance.GetAudibleGroups();
			List<string> list = new List<string>(Get.Loadout.MusicData.NoteWindow);
			int a = list.Count / Mathf.Max(1, audibleGroups);
			Dbug.Log.Info("Note Divvy: Destination Groups: {0}, Notes to Distribute: {1}", audibleGroups, list.Count);
			foreach (DestinationGroup destinationGroup2 in Get.Loadout.DestinationGroups)
			{
				destinationGroup2.Notes.Clear();
				if (destinationGroup2.ViewsCount == 0)
				{
					Dbug.Log.Info($"Note Divvy: Group {destinationGroup2.Index} is empty. Continuing...");
					continue;
				}
				int num = Mathf.Max(1, Mathf.Min(a, destinationGroup2.ViewsCount));
				Dbug.Log.Info($"Note Divvy: Loop Point is {destinationGroup2.ViewsCount}, notesToTake is {num}, availableNotes is {list.Count}");
				for (int i = 0; i < num; i++)
				{
					if (list.Count == 0)
					{
						Dbug.Log.Warn("Note Divvy: Ran out of available notes!");
						break;
					}
					int index = Rando.Index(list, maxGroups);
					destinationGroup2.Notes.Add(list[index]);
					list.RemoveAt(index);
				}
				Dbug.Log.Info($"Note Divvy: Step 1. Divvy Proportionally : Destination Group {destinationGroup2.Index} Gets {destinationGroup2.Notes.Count} Notes. Available Notes Left: {list.Count}");
			}
			foreach (DestinationGroup destinationGroup3 in Get.Loadout.DestinationGroups)
			{
				if (destinationGroup3.ViewsCount == 0 || destinationGroup3.Notes.Count >= destinationGroup3.ViewsCount)
				{
					continue;
				}
				if (list.Count == 0)
				{
					goto IL_03e3;
				}
				int index2 = Rando.Index(list, maxGroups);
				destinationGroup3.Notes.Add(list[index2]);
				list.RemoveAt(index2);
				Dbug.Log.Info("Note Divvy: Step 2. Divvy Remaining Notes: Destination {0} has less notes than Views. Adding a Note. Available Notes Left: {1}", destinationGroup3.Index, list.Count);
			}
			if (list.Count > 0)
			{
				DestinationGroup destinationGroup = Get.Loadout.GetDestinationGroup(0);
				int num2 = 0;
				foreach (DestinationGroup destinationGroup4 in Get.Loadout.DestinationGroups)
				{
					if (destinationGroup4.ViewsCount > num2)
					{
						destinationGroup = destinationGroup4;
						num2 = destinationGroup4.ViewsCount;
					}
				}
				int count = list.Count;
				Dbug.Log.Info("Note Divvy: Step 3. Lingering Notes Left. Giving all {0} remaining notes to Destination Group {1}", list.Count, destinationGroup.Index);
				for (int j = 0; j < count; j++)
				{
					int index3 = Rando.Index(list, maxGroups);
					destinationGroup.Notes.Add(list[index3]);
					list.RemoveAt(index3);
				}
			}
			goto IL_03e3;
			IL_03e3:
			Diagnostics.Verify(list.Count == 0, "Audio | Note Divvy: {0} Notes Failed to be Distributed.", list.Count);
		}
	}
}
