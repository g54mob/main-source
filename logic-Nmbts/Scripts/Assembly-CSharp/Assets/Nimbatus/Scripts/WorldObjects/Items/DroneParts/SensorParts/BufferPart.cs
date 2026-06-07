using System.Collections.Generic;
using System.Globalization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class BufferPart : SensorPart
	{
		public float MinTime;

		public float MaxTime;

		public int SliderSteps = 21;

		[HideInInspector]
		[FloatSetting("DronePartSettings/Time", "MinTime", "MaxTime", "SliderSteps", UndoManager.EStoreReason.BufferPartTime)]
		public float BufferTime = 1f;

		public tk2dSprite OutputLed;

		public tk2dSprite InputLed;

		private EventKeyBinding _outputBinding;

		private KeyBinding _inputBinding;

		private bool _wasTrue;

		private float _lastActiveTime;

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
					if (flag)
					{
						_lastActiveTime = Time.time;
					}
					bool flag2 = flag || _lastActiveTime + BufferTime > Time.time;
					InputLed.color = (flag ? Color.green : Color.red);
					OutputLed.color = (flag2 ? Color.green : Color.red);
					if (flag2)
					{
						if (!_wasTrue)
						{
							_outputBinding.PressKey(true, KeyEventHub);
							_wasTrue = true;
						}
					}
					else if (_wasTrue)
					{
						_outputBinding.PressKey(false, KeyEventHub);
						_wasTrue = false;
					}
				}
			}
			else
			{
				InputLed.color = Color.red;
				OutputLed.color = Color.red;
			}
			if (IsBroken && _wasTrue)
			{
				_outputBinding.PressKey(false, KeyEventHub);
				_wasTrue = false;
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Time") + ": " + LabelHelper.Orange + BufferTime.ToString("0.00", CultureInfo.InvariantCulture) + "s";
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_wasTrue)
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
			_outputBinding = new EventKeyBinding("Output", KeyCode.None, true);
			return new List<EventKeyBinding> { _outputBinding };
		}

		public override NimbatusItemData CreateData()
		{
			return new BufferPartData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			BufferPartData bufferPartData = data as BufferPartData;
			if (bufferPartData != null)
			{
				bufferPartData.BufferTime = BufferTime;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			BufferPartData bufferPartData = data as BufferPartData;
			if (bufferPartData != null)
			{
				BufferTime = bufferPartData.BufferTime;
			}
		}
	}
}
