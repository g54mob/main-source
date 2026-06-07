using System;
using System.Collections.Generic;
using System.Globalization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class TriggerImpulsePart : SensorPart
	{
		public float MinTime;

		public float MaxTime;

		public int SliderSteps = 21;

		[NonSerialized]
		[HideInInspector]
		[FloatSetting("DronePartSettings/Delay", "MinTime", "MaxTime", "SliderSteps", UndoManager.EStoreReason.TriggerImpulsePartDelay)]
		public float Delay = 1f;

		[NonSerialized]
		[HideInInspector]
		[FloatSetting("DronePartSettings/ActiveTime", "MinTime", "MaxTime", "SliderSteps", UndoManager.EStoreReason.TriggerImpulsePartActiveTime)]
		public float ActiveTime = 1f;

		public tk2dSprite OutputLed;

		public tk2dSprite InputLed;

		public tk2dSprite DelayLed;

		private EventKeyBinding _outputBinding;

		private KeyBinding _inputBinding;

		private bool _wasOutputActive;

		private float _delayStartTime;

		private float _outputStartTime;

		private bool _wasInputActive;

		private bool _wasDelayActive;

		public override void FixedUpdate()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				return;
			}
			base.FixedUpdate();
			if (IsActive())
			{
				if (_inputBinding.KeyCode != KeyCode.None || !string.IsNullOrEmpty(_inputBinding.StringCode))
				{
					bool flag = _inputBinding.IsPressed(KeyEventHub);
					bool flag2 = _wasDelayActive;
					bool flag3 = _wasOutputActive;
					if (_wasDelayActive)
					{
						if (Time.time > _delayStartTime + Delay)
						{
							flag2 = false;
							flag3 = true;
							_outputStartTime = Time.time;
						}
					}
					else
					{
						flag2 = flag && !flag3;
						if (flag2)
						{
							_delayStartTime = Time.time;
						}
					}
					if (flag3 && Time.time > _outputStartTime + ActiveTime)
					{
						flag3 = false;
					}
					InputLed.color = (flag ? Color.green : Color.red);
					OutputLed.color = (flag3 ? Color.green : Color.red);
					DelayLed.color = (flag2 ? Color.green : ColorHelper.BlackAlpha0);
					if (flag3)
					{
						if (!_wasOutputActive)
						{
							_outputBinding.PressKey(true, KeyEventHub);
							_wasOutputActive = true;
						}
					}
					else if (_wasOutputActive)
					{
						_outputBinding.PressKey(false, KeyEventHub);
						_wasOutputActive = false;
					}
					_wasInputActive = flag;
					_wasDelayActive = flag2;
				}
			}
			else
			{
				InputLed.color = Color.red;
				OutputLed.color = Color.red;
				DelayLed.color = ColorHelper.BlackAlpha0;
			}
			if (IsBroken && _wasOutputActive)
			{
				_outputBinding.PressKey(false, KeyEventHub);
				_wasOutputActive = false;
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Delay") + ": " + LabelHelper.Orange + Delay.ToString("0.00", CultureInfo.InvariantCulture) + "s" + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/ActiveTime") + ": " + LabelHelper.Orange + ActiveTime.ToString("0.00", CultureInfo.InvariantCulture) + "s";
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_wasOutputActive)
			{
				_outputBinding.PressKey(false, KeyEventHub);
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_inputBinding = new KeyBinding("Input", KeyCode.None);
			return new List<KeyBinding> { _inputBinding };
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_outputBinding = new EventKeyBinding("Impulse Active", KeyCode.None, true);
			return new List<EventKeyBinding> { _outputBinding };
		}

		public override NimbatusItemData CreateData()
		{
			return new TriggerImpulsePartData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			TriggerImpulsePartData triggerImpulsePartData = data as TriggerImpulsePartData;
			if (triggerImpulsePartData != null)
			{
				triggerImpulsePartData.Delay = Delay;
				triggerImpulsePartData.ActiveTime = ActiveTime;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			TriggerImpulsePartData triggerImpulsePartData = data as TriggerImpulsePartData;
			if (triggerImpulsePartData != null)
			{
				Delay = triggerImpulsePartData.Delay;
				ActiveTime = triggerImpulsePartData.ActiveTime;
			}
		}
	}
}
