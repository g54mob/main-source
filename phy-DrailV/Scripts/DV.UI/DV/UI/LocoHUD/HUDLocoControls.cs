using System;
using System.Reflection;
using DV.UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.LocoHUD
{
	public class HUDLocoControls : MonoBehaviour
	{
		[Serializable]
		public class TextReferences
		{
			public LocoHUDControlBase locoIDText;

			public LocoHUDControlBase locoTypeText;

			public LocoHUDControlBase powertrainTypeText;

			public LocoHUDControlBase bodyHealthText;

			public LocoHUDControlBase mechanicalPowertrainHealthText;

			public LocoHUDControlBase electricalPowertrainHealthText;

			public LocoHUDControlBase wheelsBrakesText;

			public LocoHUDControlBase cargoText;

			public LocoHUDControlBase shortcutText;
		}

		[Serializable]
		public class BasicControlsReferences
		{
			public LocoHUDControlBase throttle;

			public LocoHUDControlBase reverser;

			public LocoHUDControlBase gearboxA;

			public LocoHUDControlBase gearboxB;

			public LocoHUDControlBase powerMeter;

			public LocoHUDControlBase voltageMeter;

			public LocoHUDControlBase sand;

			public LocoHUDControlBase ampMeter;

			public LocoHUDControlBase tmTempMeter;

			public LocoHUDControlBase oilTempMeter;

			public LocoHUDControlBase speedMeter;

			public LocoHUDControlBase rpmMeter;

			public LocoHUDControlBase turbineRpmMeter;

			public LocoHUDControlBase wheelSlipIndicator;
		}

		[Serializable]
		public class BrakingReferences
		{
			public LocoHUDControlBase trainBrake;

			public LocoHUDControlBase indBrake;

			public LocoHUDControlBase dynBrake;

			public LocoHUDControlBase handbrake;

			public LocoHUDControlBase brakePipeMeter;

			public LocoHUDControlBase mainResMeter;

			public LocoHUDControlBase brakeCylMeter;

			public LocoHUDControlBase releaseCyl;

			public LocoHUDControlBase brakeCutout;
		}

		[Serializable]
		public class SteamReferences
		{
			public LocoHUDControlBase cylCock;

			public LocoHUDControlBase injector;

			public LocoHUDControlBase firedoor;

			public LocoHUDControlBase blower;

			public LocoHUDControlBase damper;

			public LocoHUDControlBase blowdown;

			public LocoHUDControlBase steamMeter;

			public LocoHUDControlBase chestPressureMeter;

			public LocoHUDControlBase locoWaterMeter;

			public LocoHUDControlBase locoCoalMeter;

			public LocoHUDControlBase fireTemp;

			public LocoHUDControlBase shovel;

			public LocoHUDControlBase lubricator;

			public LocoHUDControlBase airPump;

			public LocoHUDControlBase dynamo;

			public LocoHUDControlBase tenderWaterLevel;

			public LocoHUDControlBase tenderCoalLevel;

			public LocoHUDControlBase coalDump;

			public LocoHUDControlBase lightFirebox;
		}

		[Serializable]
		public class CabReferences
		{
			public LocoHUDControlBase wipers;

			public LocoHUDControlBase indWipers1;

			public LocoHUDControlBase indWipers2;

			public LocoHUDControlBase cabLight;

			public LocoHUDControlBase indCabLight;

			public LocoHUDControlBase indDashLight;

			public LocoHUDControlBase headlightsFront;

			public LocoHUDControlBase headlightsRear;

			public LocoHUDControlBase indHeadlightsTypeFront;

			public LocoHUDControlBase indHeadlights1Front;

			public LocoHUDControlBase indHeadlights2Front;

			public LocoHUDControlBase indHeadlightsTypeRear;

			public LocoHUDControlBase indHeadlights1Rear;

			public LocoHUDControlBase indHeadlights2Rear;

			public LocoHUDControlBase horn;

			public LocoHUDControlBase fuelLevelMeter;

			public LocoHUDControlBase batteryLevelMeter;

			public LocoHUDControlBase oilLevelMeter;

			public LocoHUDControlBase sandMeter;

			public LocoHUDControlBase bell;

			public LocoHUDControlBase time;
		}

		[Serializable]
		public class MechanicalReferences
		{
			public LocoHUDControlBase cabOrient;

			public LocoHUDControlBase starterFuse;

			public LocoHUDControlBase electricsFuse;

			public LocoHUDControlBase tractionMotorFuse;

			public LocoHUDControlBase starterControl;

			public LocoHUDControlBase fuelCutoff;

			public LocoHUDControlBase alerter;

			public LocoHUDControlBase tmOfflineIndicator;

			public LocoHUDControlBase pantograph;
		}

		[Header("References")]
		public TextReferences text;

		public BasicControlsReferences basicControls;

		public BrakingReferences braking;

		public SteamReferences steam;

		public CabReferences cab;

		public MechanicalReferences mechanical;

		[Header("Panels")]
		public ButtonDV closeHUDButton;

		public ButtonDV openPassengersButton;

		public ButtonDV openCouplingButton;

		public ButtonDV openDamageButton;

		public ButtonDV openGadgetsButton;

		public RectTransform hudRect;

		private void Awake()
		{
			FieldInfo[] fields = GetType().GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!fieldInfo.Name.Contains("Reference"))
				{
					continue;
				}
				FieldInfo[] fields2 = fieldInfo.FieldType.GetFields();
				object value = fieldInfo.GetValue(this);
				FieldInfo[] array = fields2;
				foreach (FieldInfo fieldInfo2 in array)
				{
					if (!(fieldInfo2.FieldType != typeof(LocoHUDControlBase)))
					{
						LocoHUDControlBase locoHUDControlBase = fieldInfo2.GetValue(value) as LocoHUDControlBase;
						if (!locoHUDControlBase.gameObject.activeSelf)
						{
							fieldInfo2.SetValue(value, null);
							UnityEngine.Object.Destroy(locoHUDControlBase.gameObject);
						}
					}
				}
			}
			HorizontalOrVerticalLayoutGroup[] components = GetComponents<HorizontalOrVerticalLayoutGroup>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].enabled = false;
			}
		}
	}
}
