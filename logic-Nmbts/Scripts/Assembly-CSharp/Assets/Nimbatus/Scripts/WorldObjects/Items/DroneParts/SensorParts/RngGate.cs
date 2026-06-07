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
	public class RngGate : SensorPart
	{
		private const int MinProbability = 0;

		private const int MaxProbability = 100;

		private const int SliderSteps = 101;

		[HideInInspector]
		[IntSetting("DronePartSettings/Probability", 0, 100, 101, UndoManager.EStoreReason.RngGateProbability)]
		public int Probability = 50;

		public tk2dSprite OutputLed;

		public tk2dSprite InputLed;

		private EventKeyBinding _outputBinding;

		private KeyBinding _inputBinding;

		private bool _wasTrue;

		private bool _hadInput;

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
					InputLed.color = (flag ? Color.green : Color.red);
					OutputLed.color = Color.red;
					if (flag)
					{
						if (!_wasTrue && !_hadInput)
						{
							if (Random.Range(0, 100) < Probability)
							{
								_outputBinding.PressKey(true, KeyEventHub);
								_wasTrue = true;
							}
							_hadInput = true;
						}
						if (_wasTrue)
						{
							OutputLed.color = Color.green;
						}
					}
					else
					{
						_hadInput = false;
						if (_wasTrue)
						{
							_outputBinding.PressKey(false, KeyEventHub);
							_wasTrue = false;
						}
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

		public override void OnDisable()
		{
			base.OnDisable();
			if (_wasTrue)
			{
				_outputBinding.PressKey(false, KeyEventHub);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Probability") + ": " + LabelHelper.Orange + Probability.ToString("D", CultureInfo.InvariantCulture) + "%";
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
			return new RngGateData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			RngGateData rngGateData;
			if ((rngGateData = data as RngGateData) != null)
			{
				rngGateData.Probability = Probability;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			RngGateData rngGateData;
			if ((rngGateData = data as RngGateData) != null)
			{
				Probability = rngGateData.Probability;
			}
		}
	}
}
