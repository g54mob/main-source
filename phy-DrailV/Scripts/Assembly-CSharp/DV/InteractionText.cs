using System.Collections.Generic;
using DV.Interaction.Inputs;
using DV.Localization;
using DV.ThingTypes;
using DV.Utils;
using VRTK;

namespace DV
{
	public class InteractionText : SingletonBehaviour<InteractionText>
	{
		public GeneralLicenseType_v2 muLicense;

		private Dictionary<InteractionInfoType, string> interactionText;

		private string BtnUse => InputManager.Actions.InteractionPrimary.LocalizeInput();

		private string BtnGrab => InputManager.Actions.InteractionPrimary.LocalizeInput();

		public new static string AllowAutoCreate()
		{
			return null;
		}

		protected override void Awake()
		{
			base.Awake();
			RefreshInteractionDict();
			InputManager.KeybindingsChanged += RefreshInteractionDict;
			if (VRManager.IsVREnabled())
			{
				if (SetupDeviceSpecificControls.AreControlsSetRight || SetupDeviceSpecificControls.AreControlsSetLeft)
				{
					UpdatedBeltSlotTextForWandEdgeCase();
				}
				else
				{
					SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
				}
			}
		}

		private void RefreshInteractionDict()
		{
			string btnUse = BtnUse;
			string btnGrab = BtnGrab;
			interactionText = new Dictionary<InteractionInfoType, string>
			{
				{
					InteractionInfoType.Cleared,
					string.Empty
				},
				{
					InteractionInfoType.PlugIn,
					LocalizationAPI.L("interaction/plug_in", btnUse)
				},
				{
					InteractionInfoType.CouplerNotParked,
					LocalizationAPI.L("interaction/coupler_not_parked")
				},
				{
					InteractionInfoType.GrabItem,
					LocalizationAPI.L("interaction/take", btnGrab)
				},
				{
					InteractionInfoType.InsertCassette,
					LocalizationAPI.L("interaction/cassette", btnGrab)
				},
				{
					InteractionInfoType.JobOverviewValidatorUse,
					LocalizationAPI.L("interaction/accept_job", btnUse)
				},
				{
					InteractionInfoType.JobBookletValidatorUse,
					LocalizationAPI.L("interaction/validate_job", btnGrab)
				},
				{
					InteractionInfoType.JobBookletAbandonerUse,
					LocalizationAPI.L("interaction/abandon_job", btnGrab)
				},
				{
					InteractionInfoType.ShovelLoadCoal,
					LocalizationAPI.L("interaction/load_shovel", btnGrab)
				},
				{
					InteractionInfoType.ShovelUnloadCoal,
					LocalizationAPI.L("interaction/unload_shovel", btnGrab)
				},
				{
					InteractionInfoType.ShovelCoalPileEmpty,
					LocalizationAPI.L("interaction/out_of_coal")
				},
				{
					InteractionInfoType.ShovelTargetFull,
					LocalizationAPI.L("interaction/shovel_target_full")
				},
				{
					InteractionInfoType.OilerRefill,
					LocalizationAPI.L("interaction/oiler_refill", btnUse)
				},
				{
					InteractionInfoType.WalletMoneyUse,
					LocalizationAPI.L("interaction/take_money", btnGrab)
				},
				{
					InteractionInfoType.WalletCashRegisterUse,
					LocalizationAPI.L("interaction/deposit", btnGrab)
				},
				{
					InteractionInfoType.JunctionRemoteSwitchUse,
					LocalizationAPI.L("interaction/change_switch", btnGrab)
				},
				{
					InteractionInfoType.KeyPadlockUse,
					LocalizationAPI.L("interaction/unlock", btnGrab)
				},
				{
					InteractionInfoType.LicenseRequired_MultipleUnit,
					LocalizationAPI.L("interaction/requires", LocalizationAPI.L(muLicense.localizationKey))
				},
				{
					InteractionInfoType.GrabToMoveBeltSlot,
					LocalizationAPI.L("interaction/move_slot", LocalizationAPI.L("vr/meta/grip"))
				},
				{
					InteractionInfoType.Ignite,
					LocalizationAPI.L("interaction/light_fire")
				},
				{
					InteractionInfoType.Bed,
					LocalizationAPI.L("sleeping/hover_text")
				},
				{
					InteractionInfoType.BedDisabled,
					LocalizationAPI.L("sleeping/hover_text_disabled")
				},
				{
					InteractionInfoType.LoadSolderRoll,
					LocalizationAPI.L("interaction/load_solder_roll", btnUse)
				},
				{
					InteractionInfoType.ContainerAccess,
					LocalizationAPI.L("interaction/container_access", btnUse)
				}
			};
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			InputManager.KeybindingsChanged -= RefreshInteractionDict;
			if (VRManager.IsVREnabled())
			{
				SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			}
		}

		private void OnControlsSet(SDK_BaseController.ControllerHand _)
		{
			UpdatedBeltSlotTextForWandEdgeCase();
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}

		private void UpdatedBeltSlotTextForWandEdgeCase()
		{
			if (VRManager.AnyWandController())
			{
				interactionText[InteractionInfoType.GrabToMoveBeltSlot] = LocalizationAPI.L("interaction/move_slot", LocalizationAPI.L("vr/meta/trigger"));
			}
		}

		public string GetText(InteractionInfoType infoType)
		{
			interactionText.TryGetValue(infoType, out var value);
			return value;
		}
	}
}
