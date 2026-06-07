using DV.ModularAudioCar;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public class LayeredAudioPortReader : ALayeredAudioSimReader
	{
		public enum UpdateType
		{
			SET_VOLUME_AND_PITCH = 0,
			SET_VOLUME = 1,
			SET_PITCH = 2,
			SET_MASTER_VOLUME = 3
		}

		public UpdateType updateType;

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

		private LayeredAudio layeredAudio;

		private Port port;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			if (layeredAudio == null)
			{
				layeredAudio = GetComponent<LayeredAudio>();
			}
			if (!simFlow.TryGetPort(portId, out port))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: LayeredAudioPortReader not initialized properly");
				return;
			}
			layeredAudio.Reset();
			OnValueUpdate(port.Value);
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

		private void OnValueUpdate(float newValue)
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
			switch (updateType)
			{
			case UpdateType.SET_VOLUME_AND_PITCH:
				layeredAudio.Set(num);
				break;
			case UpdateType.SET_VOLUME:
				layeredAudio.SetVolume(num);
				break;
			case UpdateType.SET_PITCH:
				layeredAudio.SetPitch(num);
				break;
			case UpdateType.SET_MASTER_VOLUME:
				layeredAudio.MasterVolume = num;
				layeredAudio.RefreshVolumeAndPitch();
				break;
			}
		}
	}
}
