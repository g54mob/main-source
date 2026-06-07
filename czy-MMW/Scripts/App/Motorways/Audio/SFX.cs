using System;
using GAudio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Motorways.Audio
{
	public class SFX : ImmediateAudioModule
	{
		public static float PointerTargetDelta;

		private static Vector2 mousePosPrev;

		private static Vector2 mousePos;

		private static float mouseSpeed;

		private int mapClickCounter;

		private int hoverCounter;

		public static float MouseSpeed => Maf.Normalize(mouseSpeed, 0f, 100f);

		protected override void OnActivate()
		{
		}

		public override void UpdateModule()
		{
			mousePos = Input.mousePosition;
			mouseSpeed = (mousePos - mousePosPrev).magnitude;
			mousePosPrev = mousePos;
		}

		protected override void AddEventListeners()
		{
			EventListener.Add(OnHover, UIEventType.MouseOver);
			EventListener.Add(OnClick, UIEventType.Click);
			EventListener.Add(OnCheckbox, UIEventType.CheckboxChecked | UIEventType.CheckboxUnchecked);
			EventListener.Add(OnDrawModeToggle, UIEventType.Click, UIAudioProfile.DrawModeToggle);
			EventListener.Add(OnUpgrade, AudioEventType.UpgradeDragged | AudioEventType.UpgradeReleased | AudioEventType.UpgradeOver | AudioEventType.UpgradeDragSnap);
			EventListener.Add(OnTextMessageShown, AudioEventType.TextMessageShown);
			EventListener.Add(OnFocusZoom, UIEventType.FocusZoomIn | UIEventType.FocusZoomOut);
			EventListener.Add(OnUpgradePlaced, AudioEventType.UpgradePlaced);
			EventListener.Add(OnElectiveUpgradeAvailable, AudioEventType.ElectiveUpgradeAvailable);
			EventListener.Add(OnElectiveUpgradePulse, AudioEventType.ElectiveUpgradePulse);
			EventListener.Add(OnCreativeModeEditPanelButtonAppears, AudioEventType.CreativeModeEditPanelButtonAppears);
			EventListener.Add(OnLogoPin, AudioEventType.LogoPinAppear | AudioEventType.LogoPinDisappear);
			EventListener.Add(OnMapUnlock, AudioEventType.UnlockMap);
		}

		private void OnCreativeModeEditPanelButtonAppears(AudioEvent e)
		{
			string note = Get.Loadout.MusicData.NoteWindow.SafeGet(hoverCounter);
			note = Note.Transpose(24, note);
			float num = UnityEngine.Random.Range(0.1f, 0.5f);
			AudioPlayer.Default.PlayDurational("Boop_3_" + note, Note.GainFactor(note) * Mathf.Lerp(Settings.Gain.UI_CHECKBOX_HOVER.x, Settings.Gain.UI_CHECKBOX_HOVER.y, MouseSpeed), 0.5f, -1.0, num, 0f, num, 1f, stereo: false, new FX.Modulator(new FX.Modulator.Portamento(Rando.Range(0.5f, 1f), 1.0, Rando.Range(0f, 0.1f))));
			hoverCounter++;
		}

		private void OnElectiveUpgradeAvailable(AudioEvent e)
		{
			AudioPlayer.UI.PlaySample("elective-upgrade.available", 0.66f, 0.33f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
		}

		private void OnElectiveUpgradePulse(AudioEvent e)
		{
			AudioPlayer.UI.PlaySample("elective-upgrade.attract-mode", 0.66f, 0.225f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
		}

		private void OnMapUnlock(AudioEvent e)
		{
			AudioPlayer.UI.PlaySample("interchange_placed", 0.5f, 1f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
		}

		private void OnLogoPin(AudioEvent e)
		{
			if (e.Type == AudioEventType.LogoPinAppear)
			{
				AudioPlayer.UI.PlaySample("PinAppears-01", 0.5f, 0.1f, 1.33f);
			}
			else
			{
				AudioPlayer.UI.PlaySample("PinFulfilled-01", 0.5f, 0.1f, 1.33f);
			}
		}

		private void OnUpgradePlaced(AudioEvent e)
		{
			if (!Get.Game.Scope.Get<ScreenStack>().AreAnyScreensTransitioning)
			{
				AudioPlayer.UI.PlaySample("UpgradeReleased", e.Pan, 1f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
			}
		}

		private void OnFocusZoom(AudioEvent e)
		{
			float duration = 1f;
			float freq = 0.5f;
			float amp = Settings.PITCH_BOING_IN_PLACE.Random();
			switch (e.UIEventType)
			{
			case UIEventType.FocusZoomIn:
				AudioPlayer.UI.PlaySample("FocusZoomIn", 0.5f, 0.25f, 0.75f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				Get.Mixbus.BoingPitchInPlace(duration, freq, amp);
				break;
			case UIEventType.FocusZoomOut:
				AudioPlayer.UI.PlaySample("FocusZoomOut", 0.5f, 0.25f, 0.75f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				Get.Mixbus.BoingPitchInPlace(duration, freq, amp, 0.5f);
				break;
			}
		}

		private void OnTextMessageShown(AudioEvent e)
		{
			string text = (e.Condition ? "FocusZoomIn" : "FocusZoomOut");
			double num = (e.Condition ? 0.0 : 0.4);
			AudioPlayer.UI.PlaySample(text, 0.5f, 0.25f, dspTime: AudioPlayer.EarliestSchedulableTime + num, pitch: UnityEngine.Random.Range(1.75f, 2.25f), fadeTime: 0.0, loop: false, mix: null, stereo: false, randomStart: false, startPosition: 0f, isImportant: true);
		}

		private void OnUpgrade(AudioEvent e)
		{
			switch (e.Type)
			{
			case AudioEventType.UpgradeDragged:
				AudioPlayer.UI.PlaySample("ui_lineOpens", 0.5f, Settings.UPGRADE_GRAB.Gain.Value, Settings.UPGRADE_GRAB.Pitch.Value, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				break;
			case AudioEventType.UpgradeReleased:
				if (e.UpgradeType == UpgradeType.Motorway)
				{
					AudioPlayer.UI.PlaySample("DrawRoad", 0.5f, Settings.BUILD_ROAD.Gain.Range.Random(), Settings.BUILD_ROAD.Pitch.Range.Random(), 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				}
				else
				{
					AudioPlayer.UI.PlaySample("ui_lineOpens", 0.5f, Settings.UPGRADE_RELEASE.Gain.Value, Settings.UPGRADE_RELEASE.Pitch.Value, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				}
				break;
			case AudioEventType.UpgradeOver:
			case AudioEventType.UpgradeDragSnap:
			{
				double pulseDuration = AudioSystem.Instance.Database.MasterPulse.PulseInfo.PulseDuration;
				double num = AudioSystem.Instance.Database.MasterPulse.PulseInfo.PulseDspTime - pulseDuration;
				double num2 = pulseDuration / 12.0;
				double num3 = Math.Ceiling((AudioPlayer.EarliestSchedulableTime - num) / num2);
				double num4 = num + num3 * num2;
				float num5 = Maf.Normalize(mouseSpeed, 0f, 100f);
				AudioPlayer uI = AudioPlayer.UI;
				double dspTime = num4;
				uI.PlaySample("sineFX_35", 0.5f, Mathf.Lerp(0.05f, 0.5f, Maf.VolCurve(num5)), Mathf.Lerp(1f, 2f, num5), 0.0, dspTime, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				break;
			}
			}
		}

		private void OnDrawModeToggle(AudioEvent e)
		{
			bool flag = !e.Condition;
			AudioPlayer.UI.PlaySample("panel_" + (flag ? "lock" : "unlock"), 0.5f, 1f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
		}

		private void OnClick(AudioEvent e)
		{
			if (!e.UIAudioProfile.HasAny(UIAudioProfile.Pause, UIAudioProfile.Play, UIAudioProfile.FastForward) || e.Condition)
			{
				float gain = 1f;
				switch (e.UIAudioProfile)
				{
				case UIAudioProfile.None:
					Dbug.Log.Warn("Audio Event {0} has UIAudioProfile.None", e);
					return;
				case UIAudioProfile.DrawModeToggle:
					gain = 0.5f;
					break;
				case UIAudioProfile.Back:
					AudioPlayer.UI.PlaySample("ui_lineOpens", 0.5f, 1f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
					return;
				case UIAudioProfile.Picture:
					AudioPlayer.UI.PlaySample("take-photo", 0.5f, 0.025f, 1f, 0.0, -1.0, loop: false, null, stereo: true, randomStart: false, 0f, isImportant: true);
					break;
				case UIAudioProfile.CreativeModePaint:
					AudioPlayer.UI.PlaySample("paint-0" + Rando.Range(1, 9), 0.5f, 0.5f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
					return;
				case UIAudioProfile.CreativeModePaintWheel:
					AudioPlayer.UI.PlaySample("paint-0" + Rando.Range(1, 9), 0.5f, 0.5f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
					PlayHoverNote(e);
					return;
				case UIAudioProfile.CreativeModeTrash:
					AudioPlayer.UI.PlaySample("Erase", 0.5f, 0.5f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
					return;
				case UIAudioProfile.Map:
				{
					FX.Modulator.Tremolo tremolo = new FX.Modulator.Tremolo(Rando.Range(10.0, 20.0), UnityEngine.Random.Range(0f, 0.5f));
					AudioPlayer.Default.PlaySample("PeepEmbarks_" + Get.Loadout.MusicData.NoteWindow.SafeGet(mapClickCounter), 0.5f, 0.25f, 3f, UnityEngine.Random.Range(0f, 0.5f), -1.0, loop: false, Rando.Pick<FX.Modulator>(new FX.Modulator(null, null, tremolo), new FX.Modulator(tremolo: tremolo, portamento: new FX.Modulator.Portamento(4f + Mathf.Sign(PointerTargetDelta) * UnityEngine.Random.value, 4.0, Get.Pulse.Duratio(1f / 3f, 0.25f, 1f / 6f, 0.125f)))), stereo: false, randomStart: false, 0f, isImportant: true);
					mapClickCounter++;
					AudioPlayer.UI.PlaySample("sineFX_35", 0.5f, 0.75f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
					return;
				}
				}
				AudioPlayer.UI.PlaySample("sineFX_35", 0.5f, gain, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				AudioPlayer.UI.PlaySample("ui_lineOpens", 0.5f, gain, 0.5f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
			}
		}

		private void OnCheckbox(AudioEvent e)
		{
			float gain = 0.75f;
			float pitch = 1f;
			if (e.UIEventType == UIEventType.CheckboxUnchecked)
			{
				gain = 0.375f;
				pitch = 2f;
			}
			AudioPlayer.UI.PlaySample("ui_checked", 0.5f, gain, pitch, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
		}

		private void OnHover(AudioEvent e)
		{
			if (e.UIAudioProfile == UIAudioProfile.None)
			{
				Dbug.Log.Warn("Audio Event {0} has UIAudioProfile.None", e);
			}
			UIAudioProfile uIAudioProfile = e.UIAudioProfile;
			if (uIAudioProfile == UIAudioProfile.None || uIAudioProfile == UIAudioProfile.ArrowLeft || uIAudioProfile == UIAudioProfile.ArrowRight || uIAudioProfile == UIAudioProfile.Map || uIAudioProfile == UIAudioProfile.ElectiveUpgrade || uIAudioProfile == UIAudioProfile.Lock || uIAudioProfile == UIAudioProfile.NoHover)
			{
				return;
			}
			PointerEventData pointerEventData = e.PointerEventData;
			if (pointerEventData == null || pointerEventData.pointerId <= -1)
			{
				PlayHoverNote(e);
				if (!e.UIAudioProfile.HasAny(UIAudioProfile.Checkbox, UIAudioProfile.Theme))
				{
					AudioPlayer.UI.PlaySample("sineFX_35", 0.5f, Mathf.Lerp(0.1f, 0.4f, MouseSpeed), Mathf.Lerp(4f, 2f, MouseSpeed), 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				}
			}
		}

		private void PlayHoverNote(AudioEvent e)
		{
			string text = Note.Transpose(12, Get.Loadout.MusicData.NoteWindow.SafeGet(hoverCounter));
			string sampleName = "Boop_3_" + text;
			float num = Note.GainFactor(text) * Mathf.Lerp(Settings.Gain.UI_CHECKBOX_HOVER.x, Settings.Gain.UI_CHECKBOX_HOVER.y, MouseSpeed);
			if (!e.UIAudioProfile.HasAny(UIAudioProfile.Checkbox, UIAudioProfile.Theme))
			{
				num *= 0.5f;
			}
			IGATDynamicMixInfo iGATDynamicMixInfo = new FX.Modulator(new FX.Modulator.Portamento(Rando.Range(0.5f, 1f), 1.0, Rando.Range(0f, 0.1f)));
			if (Get.State.HasFlag(StateType.ModeNight))
			{
				float num2 = UnityEngine.Random.Range(0.33f, 1f);
				AudioPlayer audioPlayer = AudioPlayer.Default;
				float gain = num;
				IGATDynamicMixInfo mix = iGATDynamicMixInfo;
				audioPlayer.PlayDurational(sampleName, gain, 0.5f, -1.0, num2, 0f, num2, 1f, stereo: false, mix);
			}
			else
			{
				AudioPlayer.Default.PlaySample(sampleName, 0.5f, num, 1f, 0.0, -1.0, loop: false, iGATDynamicMixInfo, stereo: false, randomStart: false, 0f, isImportant: true);
			}
			hoverCounter++;
		}
	}
}
