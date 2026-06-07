using DV.ModularAudioCar;
using DV.Utils;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;
using UnityEngine.Audio;

namespace DV.Simulation.Ports
{
	public class AudioClipPortReader : AAudioClipSimReader
	{
		public enum PlayClipType
		{
			PLAY_ON_ABOVE_THRESHOLD = 0,
			PLAY_ON_BELOW_THRESHOLD = 1,
			PLAY_ON_EQUAL_TO_THRESHOLD = 2
		}

		public AudioClip[] clips;

		public Transform positionAnchor;

		public float volume = 1f;

		public float pitch = 1f;

		public float spread;

		public float minDistance = 1f;

		public float maxDistance = 500f;

		public AudioMixerGroup mixerGroup;

		public bool isParented = true;

		public PlayClipType playType;

		public float playAudioThreshold;

		[PortId(null, null, false)]
		public string portId;

		public float valueMultiplier = 1f;

		public float valueOffset;

		public bool absoluteInputValue;

		public bool absoluteResultValue;

		public bool useValueMapper;

		public float inMapMin;

		public float inMapMax;

		public float outMapMin;

		public float outMapMax;

		private bool eligibleToPlayClip = true;

		private Port port;

		private Transform parent;

		public void OnValueUpdate(float newValue)
		{
			if (absoluteInputValue)
			{
				newValue = Mathf.Abs(newValue);
			}
			float num = newValue * valueMultiplier + valueOffset;
			if (useValueMapper)
			{
				num = NumberUtil.MapClamp(num, inMapMin, inMapMax, outMapMin, outMapMax);
			}
			if (absoluteResultValue)
			{
				num = Mathf.Abs(num);
			}
			switch (playType)
			{
			case PlayClipType.PLAY_ON_ABOVE_THRESHOLD:
				if (eligibleToPlayClip && num >= playAudioThreshold)
				{
					eligibleToPlayClip = false;
					clips.Play(positionAnchor.position, volume, pitch, spread, minDistance, maxDistance, default(AudioSourceCurves), mixerGroup, parent, randomizeStart: false, 0f, DopplerRequest.DEFAULT);
				}
				else if (!eligibleToPlayClip && num < playAudioThreshold)
				{
					eligibleToPlayClip = true;
				}
				break;
			case PlayClipType.PLAY_ON_BELOW_THRESHOLD:
				if (eligibleToPlayClip && num <= playAudioThreshold)
				{
					eligibleToPlayClip = false;
					clips.Play(positionAnchor.position, volume, pitch, spread, minDistance, maxDistance, default(AudioSourceCurves), mixerGroup, parent, randomizeStart: false, 0f, DopplerRequest.DEFAULT);
				}
				else if (!eligibleToPlayClip && num > playAudioThreshold)
				{
					eligibleToPlayClip = true;
				}
				break;
			case PlayClipType.PLAY_ON_EQUAL_TO_THRESHOLD:
				if (eligibleToPlayClip && num == playAudioThreshold)
				{
					eligibleToPlayClip = false;
					clips.Play(positionAnchor.position, volume, pitch, spread, minDistance, maxDistance, default(AudioSourceCurves), mixerGroup, parent, randomizeStart: false, 0f, DopplerRequest.DEFAULT);
				}
				else if ((!eligibleToPlayClip && num < playAudioThreshold) || num > playAudioThreshold)
				{
					eligibleToPlayClip = true;
				}
				break;
			}
		}

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(portId, out port))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: AudioClipPortReader not initialized properly");
				return;
			}
			if (parent == null)
			{
				if (isParented)
				{
					parent = base.transform;
				}
				else if (SingletonBehaviour<WorldMover>.Instance != null)
				{
					parent = WorldMover.OriginShiftParent;
				}
			}
			eligibleToPlayClip = true;
			port.ValueUpdatedInternally += OnValueUpdate;
		}

		public override void Deinit()
		{
			if (port != null)
			{
				port.ValueUpdatedInternally -= OnValueUpdate;
				port = null;
			}
		}
	}
}
