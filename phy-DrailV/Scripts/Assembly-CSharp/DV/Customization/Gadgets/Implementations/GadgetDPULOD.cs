using DV.CabControls;
using DV.MultipleUnit;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetDPULOD : CustomizerLODObject<GadgetDPU>
	{
		public GameObject powerSwitch;

		public GameObject orientationSwitch;

		public GameObject channelSwitch;

		public LampControl lampConnected;

		public LampControl lampRXTX;

		public LampControl lampConflict;

		public LampControl lampReversed;

		public LCDDriver channelDisplay;

		private ControlImplBase powerSwitchControl;

		private ControlImplBase orientationSwitchControl;

		private ControlImplBase channelSwitchControl;

		private void Start()
		{
			powerSwitchControl = powerSwitch.GetComponent<ControlImplBase>();
			powerSwitchControl.SetValue((float)(int)base.Base.Regime / 2f);
			powerSwitchControl.ValueChanged += OnPowerSwitchMoved;
			orientationSwitchControl = orientationSwitch.GetComponent<ControlImplBase>();
			orientationSwitchControl.SetValue((!base.Base.ReverseOrientation) ? 1 : 0);
			orientationSwitchControl.ValueChanged += OnOrientationSwitchMoved;
			channelSwitchControl = channelSwitch.GetComponent<ControlImplBase>();
			channelSwitchControl.SetValue((float)base.Base.Channel / 7f);
			channelSwitchControl.ValueChanged += OnChannelSwitchMoved;
		}

		private void Update()
		{
			bool num = base.IsOnTrainCar && base.Base.TrainCar.muModule != null;
			bool flag = base.Base.On;
			bool flag2 = base.Base.Regime == GadgetDPU.WirelessMode.Transmit;
			MultipleUnitRemoteChannel multipleUnitRemoteChannel = (num ? base.Base.TrainCar.muModule.RemoteChannel : null);
			if (flag)
			{
				bool flag3 = multipleUnitRemoteChannel != null;
				lampConnected.SetLampState(flag3 ? LampControl.LampState.On : LampControl.LampState.Blinking, flag3);
				lampRXTX.SetLampState((multipleUnitRemoteChannel != null && multipleUnitRemoteChannel.HasOneTransmitter) ? LampControl.LampState.On : LampControl.LampState.Off);
				lampConflict.SetLampState((multipleUnitRemoteChannel != null && multipleUnitRemoteChannel.allTransmitters.Count > 1) ? ((!flag2) ? LampControl.LampState.On : LampControl.LampState.Blinking) : LampControl.LampState.Off);
				lampReversed.SetLampState(base.Base.ReverseOrientation ? LampControl.LampState.On : LampControl.LampState.Off);
				channelDisplay.Display((base.Base.Channel + 1).ToString());
			}
			else
			{
				lampConnected.SetLampState(LampControl.LampState.Off);
				lampRXTX.SetLampState(LampControl.LampState.Off);
				lampConflict.SetLampState(LampControl.LampState.Off);
				lampReversed.SetLampState(LampControl.LampState.Off);
				channelDisplay.Clear();
			}
		}

		public void SyncControls()
		{
			powerSwitchControl.SetValue((float)(int)base.Base.Regime / 2f);
			orientationSwitchControl.SetValue((!base.Base.ReverseOrientation) ? 1 : 0);
			channelSwitchControl.SetValue((float)base.Base.Channel / 7f);
		}

		private void OnPowerSwitchMoved(ValueChangedEventArgs e)
		{
			base.Base.Regime = (GadgetDPU.WirelessMode)Mathf.RoundToInt(e.newValue * 2f);
		}

		private void OnOrientationSwitchMoved(ValueChangedEventArgs e)
		{
			base.Base.ReverseOrientation = e.newValue < 0.5f;
		}

		private void OnChannelSwitchMoved(ValueChangedEventArgs e)
		{
			base.Base.Channel = Mathf.RoundToInt(e.newValue * 7f);
		}
	}
}
