using DV.CabControls;
using DV.Utils;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetProximityScreenLOD : CustomizerLODObject<GadgetProximityScreen>
	{
		public LampControl barLamp0;

		public LampControl barLamp1;

		public LampControl barLamp2;

		public LampControl barLamp3;

		public LampControl barLamp4;

		public LampControl barLamp5;

		public LampControl barLampF;

		public GameObject channelSwitch;

		public GameObject settingSwitch;

		public LampControl onLamp;

		public LampControl connectedLamp;

		public AudioClip proximityBeep;

		public AudioClip proximityUndone;

		private ControlImplBase channelSwitchControl;

		private ControlImplBase settingSwitchControl;

		private ProximitySensor sensor;

		private float _beepTimer;

		private float _beepFrequency;

		private bool _done;

		private void Start()
		{
			channelSwitchControl = channelSwitch.GetComponent<ControlImplBase>();
			channelSwitchControl.SetValue((float)base.Base.CurrentChannel / 8f);
			channelSwitchControl.ValueChanged += ChannelSwitchChanged;
			settingSwitchControl = settingSwitch.GetComponent<ControlImplBase>();
			settingSwitchControl.SetValue(base.Base.CurrentMode);
			settingSwitchControl.ValueChanged += SettingSwitchChanged;
		}

		private void Update()
		{
			if (sensor == null)
			{
				return;
			}
			float barValue = Mathf.Clamp01(1f - sensor.ReadDistance() / sensor.Range);
			SetBarValue(barValue);
			if (_beepFrequency == 0f)
			{
				_beepTimer = 0f;
				return;
			}
			_beepTimer += _beepFrequency * Time.deltaTime;
			if (_beepTimer > 0f)
			{
				_beepTimer -= 1f;
				proximityBeep.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
		}

		protected internal override void OnPowerStateChanged(bool newValue)
		{
			onLamp.SetLampState(newValue ? LampControl.LampState.On : LampControl.LampState.Off);
			Clear();
			SingletonBehaviour<ProximitySensorNetwork>.Instance.SensorSettingsChanged -= FindSensor;
			if (base.Base.IsOnTrainCar)
			{
				base.Base.TrainCar.TrainsetChanged -= FindSensor;
			}
			if (base.Base.Controls?.Reverser != null)
			{
				base.Base.Controls.Reverser.ControlUpdated -= ReverserUpdated;
			}
			if (newValue)
			{
				SingletonBehaviour<ProximitySensorNetwork>.Instance.SensorSettingsChanged += FindSensor;
				if (base.Base.IsOnTrainCar)
				{
					base.Base.TrainCar.TrainsetChanged += FindSensor;
				}
				if (base.Base.Controls?.Reverser != null)
				{
					base.Base.Controls.Reverser.ControlUpdated += ReverserUpdated;
				}
				FindSensor();
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				OnPowerStateChanged(newValue: false);
			}
		}

		private void Clear()
		{
			SetBarValue(0f);
			connectedLamp.SetLampState(LampControl.LampState.Off);
			sensor = null;
		}

		private void ChannelSwitchChanged(ValueChangedEventArgs args)
		{
			base.Base.CurrentChannel = Mathf.RoundToInt(args.newValue * 8f);
			FindSensor();
		}

		private void SettingSwitchChanged(ValueChangedEventArgs args)
		{
			base.Base.CurrentMode = Mathf.RoundToInt(args.newValue);
			FindSensor();
		}

		private void ReverserUpdated(float _)
		{
			FindSensor();
		}

		private void FindSensor(object _ = null)
		{
			if (base.Base.PowerState)
			{
				bool flag = base.Base.CurrentMode == 1;
				Trainset trainset = base.Base.TrainCar?.trainset;
				Vector3 vector = base.transform.right;
				if ((base.Base.Controls?.Reverser?.Value ?? 0.5f) != 0f)
				{
					vector = -vector;
				}
				foreach (ProximitySensor item in SingletonBehaviour<ProximitySensorNetwork>.Instance.active)
				{
					if (flag)
					{
						if (item.Channel != base.Base.CurrentChannel)
						{
							continue;
						}
					}
					else if (item.SnappedToCar.trainset != trainset || Vector3.Dot(vector, item.SnappedToCoupler.transform.right) >= 0f)
					{
						continue;
					}
					if (!(sensor == item))
					{
						sensor = item;
						connectedLamp.SetLampState(LampControl.LampState.On);
						_done = false;
						SetBarValue(0f);
					}
					return;
				}
			}
			sensor = null;
			connectedLamp.SetLampState(LampControl.LampState.Off);
			_done = false;
			SetBarValue(0f);
		}

		private void SetBarValue(float v)
		{
			int num = (int)(v * 6f);
			barLamp0.SetLampState((v > 0f) ? LampControl.LampState.On : LampControl.LampState.Off);
			barLamp1.SetLampState((num > 0) ? LampControl.LampState.On : LampControl.LampState.Off);
			barLamp2.SetLampState((num > 1) ? LampControl.LampState.On : LampControl.LampState.Off);
			barLamp3.SetLampState((num > 2) ? LampControl.LampState.On : LampControl.LampState.Off);
			barLamp4.SetLampState((num > 3) ? LampControl.LampState.On : LampControl.LampState.Off);
			barLamp5.SetLampState((num > 4) ? LampControl.LampState.On : LampControl.LampState.Off);
			barLampF.SetLampState((num > 5) ? LampControl.LampState.On : LampControl.LampState.Off, num > 5);
			_beepFrequency = ((num <= 5) ? (v * 6f) : 0f);
			if (_done != num > 5)
			{
				if (_done)
				{
					proximityUndone.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
				}
				_done = !_done;
			}
		}
	}
}
