using System;
using System.Collections;
using System.Linq;
using System.Text;
using DV.Localization;
using DV.ThingTypes;
using TMPro;
using UnityEngine;

namespace DV.LocoRestoration
{
	public class LocoRestorationView : MonoBehaviour
	{
		public enum ConnectionMode
		{
			Manual = 0,
			GetFromCurrentObject = 1,
			GetFromCurrentTrainCar = 2
		}

		[Serializable]
		public class RestorationStateGameObjectToEnablePair
		{
			public LocoRestorationController.RestorationState state;

			public GameObject goToEnable;
		}

		[Header("Behavior")]
		public ConnectionMode connectionMode;

		public LocoRestorationController controller;

		public bool hideOnCompletion;

		public bool hideIfNotRestoreable;

		[Header("View components")]
		public TextMeshPro locoNameLabel;

		public RestorationStateGameObjectToEnablePair[] taskCheckmarks;

		public InWorldTooltip restorationStatusTooltip;

		private static LocoRestorationController.RestorationState LAST_STEP = ((LocoRestorationController.RestorationState[])Enum.GetValues(typeof(LocoRestorationController.RestorationState))).Last();

		private const int LOC_EMPTY = int.MinValue;

		private const int LOC_START = -1;

		private const int LOC_0_MUSEUM_LICENSE = 0;

		private const int LOC_1_LOCO_LICENSE = 1;

		private const int LOC_2_RERAIL = 2;

		private const int LOC_3_ON_TRACK = 3;

		private const int LOC_4_PART_PURCHASE = 4;

		private const int LOC_5_PART_DELIVER = 5;

		private const int LOC_6_PART_INSTALL = 6;

		private const int LOC_7_SERVICED = 7;

		private const int LOC_8_PAINT = 8;

		private static StringBuilder _sb = new StringBuilder();

		private IEnumerator Start()
		{
			switch (connectionMode)
			{
			case ConnectionMode.Manual:
				if (controller == null)
				{
					Debug.LogError("LocoRestorationView: manual mode, controller is expected to be set, but it isn't");
					yield break;
				}
				break;
			case ConnectionMode.GetFromCurrentObject:
				if (controller != null)
				{
					Debug.LogWarning("LocoRestorationController: controller is already set, but it will be overwritten");
				}
				controller = GetComponent<LocoRestorationController>();
				if (controller == null)
				{
					Debug.LogError("LocoRestorationView: couldn't find LocoRestorationController on the current object");
				}
				break;
			case ConnectionMode.GetFromCurrentTrainCar:
			{
				if (controller != null)
				{
					Debug.LogWarning("LocoRestorationController: controller is already set, but it will be overwritten");
				}
				TrainCar trainCar = TrainCar.Resolve(base.gameObject);
				if (trainCar != null)
				{
					controller = LocoRestorationController.GetForTrainCar(trainCar);
					if (controller == null)
					{
						if (hideIfNotRestoreable)
						{
							base.gameObject.SetActive(value: false);
							yield break;
						}
						Debug.LogError("LocoRestorationView: couldn't find LocoRestorationController for the current train car");
					}
				}
				else
				{
					Debug.LogError("LocoRestorationView: couldn't find TrainCar for the current object");
				}
				break;
			}
			default:
				Debug.LogError(string.Format("{0}: unknown connection mode {1}, this should never happen, check code", "LocoRestorationView", connectionMode));
				break;
			}
			if (restorationStatusTooltip != null)
			{
				restorationStatusTooltip.enabled = false;
			}
			if (!(controller != null))
			{
				yield break;
			}
			yield return null;
			OnLocoRestorationStateChanged(controller, controller.locoLivery, controller.State);
			if (locoNameLabel != null)
			{
				Localize component = locoNameLabel.GetComponent<Localize>();
				if ((bool)component)
				{
					component.key = controller.locoLivery.localizationKey;
					component.UpdateLocalization();
				}
				else
				{
					locoNameLabel.text = LocalizationAPI.L(controller.locoLivery.localizationKey);
				}
			}
		}

		public void OnEnable()
		{
			if ((bool)controller)
			{
				controller.StateChanged += OnLocoRestorationStateChanged;
			}
		}

		public void OnDisable()
		{
			if ((bool)controller)
			{
				controller.StateChanged -= OnLocoRestorationStateChanged;
			}
		}

		private void OnLocoRestorationStateChanged(LocoRestorationController controller, TrainCarLivery livery, LocoRestorationController.RestorationState state)
		{
			if (state == LAST_STEP && hideOnCompletion)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			if (restorationStatusTooltip != null)
			{
				restorationStatusTooltip.localizeMessage = false;
				restorationStatusTooltip.messageToShow = GetStatusMessageFor(livery, state, popupMode: false);
				restorationStatusTooltip.enabled = !string.IsNullOrEmpty(restorationStatusTooltip.messageToShow);
			}
			RestorationStateGameObjectToEnablePair[] array = taskCheckmarks;
			foreach (RestorationStateGameObjectToEnablePair restorationStateGameObjectToEnablePair in array)
			{
				restorationStateGameObjectToEnablePair.goToEnable.SetActive(state >= restorationStateGameObjectToEnablePair.state);
			}
		}

		private static string LocalizeMessageTitle(string key, TrainCarLivery livery)
		{
			return LocalizationAPI.L(key);
		}

		private static string LocalizeMessageDesc(string key, TrainCarLivery livery)
		{
			if (key == "restoration/step5_desc")
			{
				LocoRestorationController forLivery = LocoRestorationController.GetForLivery(livery);
				return LocalizationAPI.L(key, forLivery.warehouseMachineForPartPickup.warehouseMachine.WarehouseTrack.ID.FullDisplayID);
			}
			return LocalizationAPI.L(key);
		}

		private static int TranslateToIndex(LocoRestorationController.RestorationState state, out bool subState, out bool locoSpecific)
		{
			subState = false;
			locoSpecific = true;
			switch (state)
			{
			case LocoRestorationController.RestorationState.S0_Initialized:
				subState = true;
				return -1;
			case LocoRestorationController.RestorationState.S1_UnlockedRestorationLicense:
				locoSpecific = false;
				return 0;
			case LocoRestorationController.RestorationState.S2_LocoUnblocked:
				return 1;
			case LocoRestorationController.RestorationState.S3_RerailedCars:
				return 2;
			case LocoRestorationController.RestorationState.S4_OnDestinationTrack:
				return 3;
			case LocoRestorationController.RestorationState.S5_PartOrdered:
				return 4;
			case LocoRestorationController.RestorationState.S6_PartPickedUp:
				subState = true;
				return 4;
			case LocoRestorationController.RestorationState.S7_PartDelivered:
				return 5;
			case LocoRestorationController.RestorationState.S8_PartInstalled:
				return 6;
			case LocoRestorationController.RestorationState.S9_LocoServiced:
				return 7;
			case LocoRestorationController.RestorationState.S10_PaintJobDone:
				return 8;
			default:
				return int.MinValue;
			}
		}

		public static string GetStatusMessageFor(TrainCarLivery livery, LocoRestorationController.RestorationState state, bool popupMode)
		{
			bool subState;
			bool locoSpecific;
			int num = TranslateToIndex(state, out subState, out locoSpecific);
			if (num == int.MinValue || (subState && popupMode))
			{
				return string.Empty;
			}
			_sb.Clear();
			if ((locoSpecific || !popupMode) && livery != null && !string.IsNullOrEmpty(livery.localizationKey))
			{
				_sb.Append("<align=\"left\"><margin-right=0><line-height=1.1em><color=#ffff00>");
				_sb.Append(LocalizationAPI.L(livery.localizationKey));
				_sb.AppendLine("</color>");
				_sb.AppendLine();
			}
			if (state >= LocoRestorationController.RestorationState.S1_UnlockedRestorationLicense && num >= -1)
			{
				_sb.AppendLine("<line-height=0.5em><color=#00ff00><align=\"left\"><size=50%><sprite=\"quick_tutorial\" index=8 tint=1></size></align>");
				_sb.Append("<align=\"left\"><margin-left=40><line-height=1.1em>");
				_sb.Append(LocalizeMessageTitle("restoration/step" + num, livery));
				_sb.AppendLine("</color>");
				_sb.Append("<margin-left=0><align=\"left\"><size=75%>");
				_sb.Append(LocalizeMessageDesc("restoration/step" + num + "_done", livery));
				_sb.AppendLine("</size></align>");
				if (state < LocoRestorationController.RestorationState.S10_PaintJobDone)
				{
					_sb.AppendLine();
				}
			}
			int num2 = num + 1;
			if ((!popupMode || state >= LocoRestorationController.RestorationState.S2_LocoUnblocked) && state < LocoRestorationController.RestorationState.S10_PaintJobDone && num2 <= 8)
			{
				_sb.Append("<align=\"left\"><margin-right=70><line-height=1.1em><color=#ffff00>");
				_sb.Append(LocalizationAPI.L("restoration/next") + " " + LocalizeMessageTitle("restoration/step" + num2, livery));
				_sb.AppendLine("</color>");
				_sb.Append("<margin-right=0><align=\"left\"><size=75%>");
				_sb.Append(LocalizeMessageDesc("restoration/step" + num2 + "_desc", livery));
				_sb.AppendLine("</size></align>");
			}
			return _sb.ToString();
		}
	}
}
