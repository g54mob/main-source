using System.Collections.Generic;
using GAudio;
using UnityEngine;

namespace Motorways.Audio
{
	public class Playback
	{
		protected AudioEnvironment Environment;

		protected double lastPulseTime;

		protected IGATPulseInfo pulse;

		protected IGATPulseInfo master;

		public int pseudoStep;

		public double time;

		protected List<AudioEvent> audioEvents = new List<AudioEvent>();

		protected int lastEventId;

		protected AudioEventFilter filter;

		public PulsedAudioModule Module;

		public AudioEventListener EventListener = new AudioEventListener();

		protected float gain = 1f;

		protected float pan = -1f;

		protected float pitch = 1f;

		protected string[] samples;

		private bool hasLoggedLagWarning;

		public Playback(AudioEventFilter filter, float gain = 1f)
		{
			this.filter = filter;
			this.gain = gain;
		}

		public Playback(AudioEventFilter filter, string[] samples, float gain = 1f)
			: this(filter)
		{
			this.samples = samples;
			this.gain = gain;
		}

		public Playback(AudioEventFilter filter)
		{
			this.filter = filter;
		}

		public Playback()
		{
		}

		public void OnGATPulse(IGATPulseInfo pulse, double lastPulseTime)
		{
			this.pulse = pulse;
			master = pulse.PulseSender.MasterPulseInfo;
			time = pulse.PulseDspTime;
			this.lastPulseTime = lastPulseTime;
			pseudoStep = master.StepIndex * pulse.NbOfSteps + pulse.StepIndex;
			if (!hasLoggedLagWarning && time < AudioSettings.dspTime + GATInfo.AudioBufferDuration)
			{
				Dbug.Log.Warn("Scheduled PulseDspTime ({0:0.##}) has lagged behind the current DSP time ({1:0.##}) plus the buffer duration ({2:0.##}) in Playback {3}. ({0:0.##} < {4:0.##}))", time, AudioSettings.dspTime, GATInfo.AudioBufferDuration, this, AudioSettings.dspTime + GATInfo.AudioBufferDuration);
				hasLoggedLagWarning = true;
			}
			else
			{
				OnPulse();
			}
		}

		public virtual void OnBeginPulse()
		{
		}

		public void Activate(AudioEnvironment environment)
		{
			Environment = environment;
			EventListener.Start(AddEventListeners);
			hasLoggedLagWarning = false;
		}

		public void Deactivate()
		{
			EventListener.Stop();
			Environment = null;
		}

		public virtual void AddEventListeners()
		{
		}

		public virtual void OnActivate()
		{
		}

		public virtual void OnDeactivate()
		{
		}

		public virtual void Update()
		{
		}

		protected virtual void OnPulse()
		{
		}

		protected bool GetEvents(int limit = 0)
		{
			List<AudioEvent> events = AudioSystem.Instance.GetEvents(lastPulseTime, lastEventId, filter, (Environment == null) ? null : Environment.City);
			if (events != null && events.Count != 0)
			{
				if (events.Count > limit && limit != 0)
				{
					events.RemoveRange(limit, events.Count - limit);
				}
				audioEvents.AddRange(events);
				lastEventId = events[events.Count - 1].Id + 1;
			}
			return audioEvents.Count != 0;
		}
	}
}
