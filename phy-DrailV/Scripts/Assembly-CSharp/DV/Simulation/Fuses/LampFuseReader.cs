using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Fuses
{
	public class LampFuseReader : MonoBehaviour
	{
		public enum Mode
		{
			ON_WHEN_FUSE_ON = 0,
			BLINK_WHEN_FUSE_ON = 1
		}

		[FuseId]
		public string fuseId;

		[FuseId]
		public string powerFuseId;

		public Mode mode;

		private Fuse fuse;

		private Fuse powerFuse;

		private LampControl lampControl;

		public void Init(Fuse fuse, Fuse powerFuse)
		{
			lampControl = GetComponent<LampControl>();
			if (lampControl == null)
			{
				Debug.LogError("Can't find LampControl on " + base.gameObject.name + ". Ignoring init");
				return;
			}
			this.fuse = fuse;
			this.powerFuse = powerFuse;
			OnFuseStateUpdated(fuse.State);
			fuse.StateUpdated += OnFuseStateUpdated;
			if (powerFuse != null)
			{
				powerFuse.StateUpdated += OnPowerFuseStateUpdated;
			}
		}

		public void Deinit()
		{
			if (fuse != null)
			{
				fuse.StateUpdated -= OnFuseStateUpdated;
			}
			if (powerFuse != null)
			{
				powerFuse.StateUpdated -= OnPowerFuseStateUpdated;
			}
		}

		private void OnPowerFuseStateUpdated(bool _)
		{
			OnFuseStateUpdated(fuse.State);
		}

		private void OnFuseStateUpdated(bool fuseState)
		{
			if (powerFuse != null && !powerFuse.State)
			{
				if (lampControl.lampState != LampControl.LampState.Off)
				{
					lampControl.SetLampState(LampControl.LampState.Off);
				}
			}
			else if (fuseState)
			{
				switch (mode)
				{
				case Mode.ON_WHEN_FUSE_ON:
					if (lampControl.lampState != LampControl.LampState.On)
					{
						lampControl.SetLampState(LampControl.LampState.On);
					}
					break;
				case Mode.BLINK_WHEN_FUSE_ON:
					if (lampControl.lampState != LampControl.LampState.Blinking)
					{
						lampControl.SetLampState(LampControl.LampState.Blinking);
					}
					break;
				default:
					Debug.LogError($"Unexpected state: {mode} not handled properly!");
					break;
				}
			}
			else if (lampControl.lampState != LampControl.LampState.Off)
			{
				lampControl.SetLampState(LampControl.LampState.Off);
			}
		}
	}
}
