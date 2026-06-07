using GAudio;
using UnityEngine;

namespace Motorways.Audio
{
	public class PulsedAudioModule : AGATPulseClient, IAudioModule
	{
		public bool isActive;

		private double lastPulseTime;

		public Rhythm Rhythm;

		public Playback Playback { get; set; }

		public double NextPulseTime => base.Pulse.PulseInfo.PulseDspTime + base.Pulse.PulseInfo.PulseDuration;

		public void Activate(AudioEnvironment environment)
		{
			if (Diagnostics.Verify(!isActive, "Cannot reactivate {0}.", this))
			{
				isActive = true;
				SubscribeToPulseIfNeeded();
				Playback?.Activate(environment);
				Playback?.OnActivate();
			}
		}

		public void Deactivate()
		{
			if (Diagnostics.Verify(isActive, "Cannot deactivate {0}.", this))
			{
				isActive = false;
				UnsubscribeToPulse();
				Playback?.Deactivate();
				Playback?.OnDeactivate();
			}
		}

		public void Release()
		{
			Object.Destroy(base.gameObject);
		}

		public void UpdateModule()
		{
			Playback?.Update();
		}

		public override void OnPulse(IGATPulseInfo pulseInfo)
		{
			if (_subscribedSteps[pulseInfo.StepIndex])
			{
				Playback?.OnGATPulse(pulseInfo, lastPulseTime);
				lastPulseTime = AudioSystem.Instance.DspTime;
			}
		}

		protected override bool CanSubscribeToPulse()
		{
			if (base.CanSubscribeToPulse())
			{
				return isActive;
			}
			return false;
		}

		public void ChangePulse(Rhythm newRhythm)
		{
			if (Rhythm == null || !(newRhythm.Id == Rhythm.Id))
			{
				base.Pulse = AudioSystem.Instance.Database.GetHyperPulse(newRhythm);
				Rhythm = newRhythm;
				base.gameObject.name = base.gameObject.name.Split('|')[0] + " " + Rhythm.Id;
				SubscribeToPulseIfNeeded();
				((SubPulseModule)base.Pulse).PrepOffset();
			}
		}

		public void ChangePulse(int pulseStep)
		{
			base.Pulse = AudioSystem.Instance.Database.GetPulse(pulseStep);
			SubscribeToPulseIfNeeded();
		}

		public static IAudioModule CreateModule(string id, Playback playback, Rhythm rhythm = null, int pulseStep = -1)
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.parent = Get.Loadout.GameObject.transform;
			PulsedAudioModule pulsedAudioModule = gameObject.AddComponent<PulsedAudioModule>();
			pulsedAudioModule.Playback = playback;
			gameObject.name = "Playback: " + ((!string.IsNullOrEmpty(id)) ? id : "");
			if (rhythm != null)
			{
				gameObject.name = gameObject.name + " | " + rhythm.Id;
				pulsedAudioModule.Pulse = AudioSystem.Instance.Database.GetHyperPulse(rhythm);
			}
			else
			{
				if (pulseStep <= 0)
				{
					return null;
				}
				pulsedAudioModule.Pulse = AudioSystem.Instance.Database.GetPulse(pulseStep);
			}
			pulsedAudioModule.Rhythm = rhythm;
			pulsedAudioModule.Playback.Module = pulsedAudioModule;
			pulsedAudioModule.Playback.OnBeginPulse();
			return pulsedAudioModule;
		}
	}
}
