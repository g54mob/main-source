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
	public class ImpulseGiver : SensorPart
	{
		public float MinTime;

		public float MaxTime;

		public tk2dSprite[] ProgressLights;

		public tk2dSprite ImpulseLight;

		[HideInInspector]
		[FloatSetting("DronePartSettings/ActiveTime", "MinTime", "MaxTime", "GetSteps", UndoManager.EStoreReason.ImpulseGiverActiveTime)]
		public float ActiveTime;

		[HideInInspector]
		[FloatSetting("DronePartSettings/PauseTime", "MinTime", "MaxTime", "GetSteps", UndoManager.EStoreReason.ImpulseGiverPauseTime)]
		public float PauseTime;

		private EventKeyBinding _triggerEvent;

		private EventKeyHub _hub;

		private bool _wasTrue;

		private float _absTime;

		public int GetSteps()
		{
			int result = 100;
			if (MinTime >= 1f)
			{
				result = (int)MaxTime;
			}
			return result;
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			return new List<KeyBinding>();
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_triggerEvent = new EventKeyBinding("Impulse Active", KeyCode.None, true);
			return new List<EventKeyBinding> { _triggerEvent };
		}

		protected override void Awake()
		{
			base.Awake();
			ActiveTime = 1f;
			PauseTime = 1f;
		}

		protected override void Start()
		{
			base.Start();
			if (RuntimeGlobals.RunningMode != ERunningMode.DroneCustomization)
			{
				tk2dSprite[] progressLights = ProgressLights;
				for (int i = 0; i < progressLights.Length; i++)
				{
					progressLights[i].color = Color.red;
				}
				ImpulseLight.color = Color.red;
			}
			_hub = FindEventKeyHubRecursive();
		}

		public override void FixedUpdate()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				return;
			}
			base.FixedUpdate();
			if (IsActive())
			{
				_absTime += Time.fixedDeltaTime;
				float num = Mathf.Repeat(_absTime, ActiveTime + PauseTime);
				float num2 = PauseTime / (float)ProgressLights.Length;
				if (num < PauseTime)
				{
					for (int i = 0; i < ProgressLights.Length; i++)
					{
						if (num > num2 * (float)i)
						{
							ProgressLights[i].color = Color.green;
						}
						else
						{
							ProgressLights[i].color = Color.red;
						}
					}
					ImpulseLight.color = Color.red;
					if (_wasTrue)
					{
						_triggerEvent.PressKey(false, _hub);
						_wasTrue = false;
					}
				}
				else
				{
					ImpulseLight.color = Color.green;
					if (!_wasTrue)
					{
						_triggerEvent.PressKey(true, _hub);
						_wasTrue = true;
					}
				}
			}
			if (IsBroken && _wasTrue)
			{
				_triggerEvent.PressKey(false, _hub);
				_wasTrue = false;
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/ActiveTime") + ": " + LabelHelper.Orange + ActiveTime.ToString("0.00", CultureInfo.InvariantCulture) + "s" + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/PauseTime") + ": " + LabelHelper.Orange + PauseTime.ToString("0.00", CultureInfo.InvariantCulture) + "s";
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_wasTrue)
			{
				_triggerEvent.PressKey(false, _hub);
				_wasTrue = false;
			}
		}

		public override NimbatusItemData CreateData()
		{
			return new ImpulseGiverData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			ImpulseGiverData impulseGiverData = data as ImpulseGiverData;
			if (impulseGiverData != null)
			{
				impulseGiverData.PauseTime = PauseTime;
				impulseGiverData.ActiveTime = ActiveTime;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			ImpulseGiverData impulseGiverData = data as ImpulseGiverData;
			if (impulseGiverData != null)
			{
				ActiveTime = impulseGiverData.ActiveTime;
				PauseTime = impulseGiverData.PauseTime;
			}
		}
	}
}
