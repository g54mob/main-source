using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Audio
{
	public class Persistent : ImmediateAudioModule
	{
		public class Chord
		{
			private string prefix = "chordTone_";

			public void Play(int polyphony = 0, float spread = -1f, bool isImportant = false, int transpose = 0, float gainAdjust = 1f, double dspStartTime = -1.0)
			{
				List<string> notes = Get.Loadout.MusicData.NoteWindow;
				if (transpose != 0)
				{
					notes = Note.Transpose(transpose, notes);
				}
				if (polyphony == 0)
				{
					polyphony = Get.Loadout.MusicData.ChordSize();
				}
				if (spread < 0f)
				{
					spread = Get.Loadout.MusicData.ChordSpread();
				}
				if (dspStartTime < 0.0)
				{
					dspStartTime = AudioPlayer.EarliestSchedulableTime;
				}
				Maf.Repeat(polyphony, delegate(int i)
				{
					AudioPlayer.Default.PlaySample(prefix + notes[i], Rando.m(), dspTime: dspStartTime + (double)(spread * (float)i), gain: gainAdjust * 0.275f * Note.GainFactor(notes[i]), pitch: 1f, fadeTime: Mathf.Lerp(0f, 0.5f, (i != 0) ? (i / (notes.Count - 1)) : 0), loop: false, mix: new FX.Modulator(new FX.Modulator.Portamento(0.9375, 1.0, Rando.Range(0.1, 0.33)), Rando.Pick<FX.Modulator.Vibrato>(null, new FX.Modulator.Vibrato(Rando.Range(10.0, 20.0), Rando.Range(0.0, 0.01), 1.0, UnityEngine.Random.value)), new FX.Modulator.Tremolo(Rando.Range(0.25, 20.0), UnityEngine.Random.Range(0f, 0.5f), UnityEngine.Random.value)), stereo: false, randomStart: false, startPosition: 0f, isImportant: isImportant);
				}, Rando.FlipCoin());
			}

			public void PlaySingleRandom(int transpose = 0, float fadeTime = 0f, float gainAdjust = 1f)
			{
				string text = Note.Transpose(transpose, Rando.Pick(Get.Loadout.MusicData.NoteWindow));
				AudioPlayer.Default.PlaySample(prefix + text, Rando.m(), dspTime: Clock.NextPulseTime, gain: gainAdjust * 0.275f * Note.GainFactor(text), pitch: 1f, fadeTime: fadeTime, loop: false, mix: new FX.Modulator(new FX.Modulator.Portamento(0.9375, 1.0, Rando.Range(0.1, 0.33)), Rando.Pick<FX.Modulator.Vibrato>(null, new FX.Modulator.Vibrato(Rando.Range(10.0, 20.0), Rando.Range(0.0, 0.01), 1.0, UnityEngine.Random.value)), new FX.Modulator.Tremolo(Rando.Range(0.25, 20.0), UnityEngine.Random.Range(0f, 0.5f), UnityEngine.Random.value)));
			}
		}

		private bool firedStartupChord;

		public static int Connections;

		protected override void OnActivate()
		{
			FX.TogglePauseModePitch(on: false);
		}

		public override void UpdateModule()
		{
			if (Get.Loadout.MusicData.NoteWindow != null && !firedStartupChord && !Get.State.HasFlag(StateType.SkippingMenu))
			{
				StartupChord();
				firedStartupChord = true;
			}
		}

		private void StartupChord()
		{
			Maf.Repeat(Get.Loadout.MusicData.NoteWindow.Count, delegate(int i)
			{
				AudioPlayer.Default.PlayDurational("LineCreated_" + Get.Loadout.MusicData.NoteWindow[i], pan: UnityEngine.Random.Range(0f, 1f), gain: 0.55f * Note.GainFactor(Get.Loadout.MusicData.NoteWindow[i]), dspTime: -1.0, length: UnityEngine.Random.Range(3f, 5f), attack: UnityEngine.Random.Range(1f, 3f), decay: UnityEngine.Random.Range(2f, 4f), pitch: 1f, stereo: false, mix: new FX.Modulator(new FX.Modulator.Portamento(0.9375, 1.0, UnityEngine.Random.Range(0.1f, 0.33f)), Rando.Pick<FX.Modulator.Vibrato>(null, new FX.Modulator.Vibrato(Rando.Range(10.0, 20.0), Rando.Range(0.0, 0.01), 1.0, UnityEngine.Random.value))));
			});
		}

		protected override void AddEventListeners()
		{
			EventListener.Add(OnDrawModeToggle, AudioEventType.DrawMode);
			EventListener.Add(OnNightModeToggle, AudioEventType.NightMode);
			EventListener.Add(OnTransition, UIEventType.Transition);
			EventListener.Add(OnLateGame, AudioEventType.LateGame);
			EventListener.Add(OnInGamePause, UIEventType.Click, UIAudioProfile.Pause | UIAudioProfile.Play | UIAudioProfile.FastForward);
			EventListener.Add(OnTheHour, AudioEventType.Pulse);
		}

		private void OnTheHour(AudioEvent e)
		{
			if (AudioEnvironment.Instance == null)
			{
				return;
			}
			int num = Get.ConnectedViewCount();
			MusicData musicData = Get.Loadout.MusicData;
			if (!(musicData is Menu) && num > Connections)
			{
				musicData.NotePointer++;
				musicData.OnConnection();
			}
			Connections = num;
			if (!Get.State.HasFlag(StateType.MenuUpgrades) && Get.Clock.Hour > 6)
			{
				musicData.OnHour();
				if (Get.Hour == 0)
				{
					musicData.OnDay();
				}
				if (Get.Hour == 6)
				{
					musicData.OnDawn();
				}
				else if (Get.Hour == 19)
				{
					musicData.OnDusk();
				}
			}
		}

		private void OnLateGame(AudioEvent e)
		{
			DrumSequencer(play: true);
		}

		private void OnInGamePause(AudioEvent e)
		{
			switch (e.UIAudioProfile)
			{
			case UIAudioProfile.Pause:
				if (!Get.State.HasFlag(StateType.GamePaused))
				{
					AudioPlayer.UI.PlaySample("ui_clockSlow", 0.75f, 0.5f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				}
				if (Get.Pulse.Scale == TimeScale.Single)
				{
					Get.Pulse.Scale = TimeScale.SingleSlow;
				}
				else
				{
					Get.Pulse.Scale = TimeScale.DoubleSlow;
				}
				Get.State |= StateType.GamePaused;
				Get.State &= ~StateType.GameActive;
				FX.TogglePauseModePitch(on: true);
				DrumSequencer(play: true);
				break;
			case UIAudioProfile.Play:
				if (Get.Pulse.Scale != TimeScale.Single)
				{
					AudioPlayer.UI.PlaySample((Get.Pulse.Scale == TimeScale.Double) ? "ui_clockSlow" : "ui_clockFast", 0.75f, 0.5f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				}
				Get.Pulse.Scale = TimeScale.Single;
				Get.State |= StateType.GameActive;
				Get.State &= ~StateType.GamePaused;
				FX.TogglePauseModePitch(on: false);
				DrumSequencer(play: false);
				break;
			case UIAudioProfile.FastForward:
				if (Get.Pulse.Scale != TimeScale.Double)
				{
					AudioPlayer.UI.PlaySample("ui_clockFast", 0.75f, 0.5f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				}
				Get.Pulse.Scale = TimeScale.Double;
				Get.State |= StateType.GameActive;
				Get.State &= ~StateType.GamePaused;
				FX.TogglePauseModePitch(on: false);
				DrumSequencer(play: false);
				break;
			}
		}

		private void OnDrawModeToggle(AudioEvent e)
		{
			float duration = e.Duration;
			if (!e.Condition)
			{
				Get.State |= StateType.ModeDelete;
				Get.State &= ~StateType.ModeEdit;
				Get.Mixbus.InterpolateCutoffFreq(AudioMixbus.FilterType.Lowpass, 750f, 3f * duration);
				Get.Mixbus.InterpolateCutoffFreq(AudioMixbus.FilterType.Highpass, 100f, 3f * duration);
			}
			else
			{
				Get.State |= StateType.ModeEdit;
				Get.State &= ~StateType.ModeDelete;
				Get.Mixbus.InterpolateCutoffFreq(AudioMixbus.FilterType.Lowpass, 22000f, 3f * duration);
				Get.Mixbus.InterpolateCutoffFreq(AudioMixbus.FilterType.Highpass, 10f, 3f * duration);
			}
		}

		private void OnNightModeToggle(AudioEvent e)
		{
			FX.ToggleNightMode(Get.State.HasFlag(StateType.ModeNight));
		}

		private void OnTransition(AudioEvent e)
		{
			if (e.Screen == ScreenStack.MotorwaysScreen.Startup || e.PreviousScreen == ScreenStack.MotorwaysScreen.Photo || e.Screen == ScreenStack.MotorwaysScreen.CinematicMode || e.PreviousScreen == ScreenStack.MotorwaysScreen.CinematicMode)
			{
				return;
			}
			if (Get.State.HasFlag(StateType.MenuMain) && !Get.State.HasFlag(StateType.ModeNight))
			{
				FX.ToggleEcho(on: false);
			}
			bool flag = e.PreviousScreen == ScreenStack.MotorwaysScreen.InGame && e.Screen == ScreenStack.MotorwaysScreen.Pause;
			float num = ((e.Screen == ScreenStack.MotorwaysScreen.MapSelect) ? 0.5f : (e.Duration * 0.7f));
			float attack = ((e.Screen == ScreenStack.MotorwaysScreen.MapSelect) ? num : (num * 0.3f));
			float gain = ((e.Screen == ScreenStack.MotorwaysScreen.MapSelect) ? 0.015000001f : 0.075f);
			float pitch = ((e.Screen == ScreenStack.MotorwaysScreen.MapSelect) ? 2f : 1f);
			if (e.Condition && !Get.State.HasFlag(StateType.SkippingMenu) && !flag && num > 0f)
			{
				AudioPlayer.UI.PlayDurational("ui_transition", gain, 0.5f, -1.0, num, attack, num, pitch, stereo: true, null, randomStart: true);
			}
			switch (e.Screen)
			{
			case ScreenStack.MotorwaysScreen.InGame:
				if (e.PreviousScreen == ScreenStack.MotorwaysScreen.Upgrade)
				{
					Get.Loadout.MusicData.OnRhythmUpdate(0);
					Get.Loadout.MusicData.OnNewWeek();
					Get.Loadout.MusicData.UpdateNoteWindow(Get.MaxGroups - Get.AudibleGroups, transposeBy: Rando.Pick(Get.Loadout.MusicData.WeekendTranspositions), chordChangeProbability: Get.Loadout.MusicData.WeekendQualityChangeChance, keyChangeProbability: Get.Loadout.MusicData.WeekendKeyChangeChance);
					DestinationGroup.CityHocketTones.Limit(0.0, 0);
					DestinationGroup.CityIdleLoops.Limit(0.0, 0);
				}
				if (!Get.State.HasFlag(StateType.SkippingMenu))
				{
					PlayScreenChangeChord();
				}
				else
				{
					Get.State &= ~StateType.SkippingMenu;
				}
				LPFSweep(on: false);
				break;
			case ScreenStack.MotorwaysScreen.GameOver:
				PlayScreenChangeChord(isImportant: true);
				LPFSweep(on: false);
				DrumSequencer(play: false);
				break;
			case ScreenStack.MotorwaysScreen.Upgrade:
				if (Get.City.Rules.ScoringMode == ScoringMode.EfficiencyMilestones)
				{
					UpgradeChord();
				}
				LPFSweep(on: true);
				break;
			case ScreenStack.MotorwaysScreen.Pause:
				LPFSweep(on: true);
				break;
			default:
				LPFSweep(on: false);
				Get.Mixbus.InterpolateCutoffFreq(AudioMixbus.FilterType.Highpass, 10f, 2f);
				break;
			}
		}

		private void LPFSweep(bool on)
		{
			Get.Mixbus.InterpolateCutoffFreq(AudioMixbus.FilterType.Lowpass, on ? 900f : 22000f, on ? 1.5f : 2f);
		}

		private void DrumSequencer(bool play)
		{
			Get.Loadout.DrumSequencer.PauseMode = play;
			FX.ToggleEcho(play);
		}

		public static void UpgradeChord(double dspTime = -1.0)
		{
			AudioPlayer.Default.PlayChord("chordTone", Get.Loadout.MusicData.NoteWindow, dspTime, gain: Settings.Gain.CHORD_WEEKOVER.x, gainEnd: Settings.Gain.CHORD_WEEKOVER.y, arpeggioRate: Get.Loadout.MusicData.ChordSpread(), minPan: 0f, maxPan: 1f, fadeTimeStart: 0f, fadeTimeEnd: 0.1f, count: Get.Loadout.MusicData.ChordSize(), downwards: Rando.FlipCoin());
		}

		private void PlayScreenChangeChord(bool isImportant = false)
		{
			Get.Loadout.MusicData.Bass?.FadeOutAndStop(0.5);
			Get.Loadout.MusicData.Bass = AudioPlayer.Default.PlaySample("bass_" + Note.SCALE[Get.Loadout.MusicData.CurrentScale.Key], 0.5f, 0.5f, 1f, 0.5, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant);
			new Chord().Play(0, -1f, isImportant, 12);
		}
	}
}
