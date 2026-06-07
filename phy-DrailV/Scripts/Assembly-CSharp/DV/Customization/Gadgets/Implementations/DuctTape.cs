using DV.CabControls;
using DV.CabControls.VRTK;
using DV.InventorySystem;
using DV.Items;
using DV.JObjectExtstensions;
using DV.Player;
using DV.Utils;
using DV.VRTK_Extensions;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VRTK;

namespace DV.Customization.Gadgets.Implementations
{
	public class DuctTape : MountHoleInteractor, ItemPositionController.IPositionProvider
	{
		private const string USES_LEFT_SAVE_KEY = "uses";

		public AudioClip soundOnCompleted;

		public ItemWorkingAnimation itemWorkingAnimation;

		public GameObject emptyTapeItemPrefab;

		private Drillable targetDrillable;

		private SDK_BaseController.ControllerHand vrGrabbedBy;

		private int currentHoleIndex;

		private ItemPositionController.OGPoseAnimationHelper animationHelper;

		public int numberOfUses;

		private int usesLeft;

		private ThresholdGameObjectActivator tapeModelUpdater;

		private ItemSaveData itemSaveData;

		private float PercentageUsesLeft => (float)usesLeft / (float)numberOfUses;

		public int Priority => 1;

		private void Awake()
		{
			usesLeft = numberOfUses;
			tapeModelUpdater = GetComponent<ThresholdGameObjectActivator>();
			if (tapeModelUpdater == null)
			{
				Debug.LogError("Unexpected state: Missing ThresholdGameObjectActivator component. Model won't be updated!");
			}
			tapeModelUpdater?.UpdateActiveStates(PercentageUsesLeft);
			if (emptyTapeItemPrefab == null)
			{
				Debug.LogError("Unexpected state: Missing emptyTapeItemPrefab reference! Won't spawn empty tape upon usage");
			}
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.AnimationStarted += delegate
				{
					SingletonBehaviour<ItemPositionController>.Instance.Add(this);
					Transform animationTarget = ((targetDrillable != null && currentHoleIndex.IsInRange(0, targetDrillable.MountPointCount)) ? targetDrillable.GetMountPoint(currentHoleIndex).transform : null);
					animationHelper.animationTarget = animationTarget;
					animationHelper.SetAnimationStartValues();
				};
				itemWorkingAnimation.AnimationStopped += delegate
				{
					SingletonBehaviour<ItemPositionController>.Instance.Remove(this);
				};
				itemWorkingAnimation.WorkDoneCallback = delegate
				{
					ConsumeOneUse();
					targetDrillable.SetMountPointState(currentHoleIndex, MountPoint.States.Taped);
					soundOnCompleted.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, targetDrillable.transform);
					animationHelper.SetAnimationStopValues(animationHelper.animationTarget.position, animationHelper.animationTarget.rotation);
					return true;
				};
				itemWorkingAnimation.InputPressedCallback = () => true;
			}
			if (TryGetComponent<ItemSaveData>(out itemSaveData))
			{
				itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
				itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
			}
		}

		private void OnDestroy()
		{
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.StopAnimating();
			}
			if (itemSaveData != null)
			{
				itemSaveData.ItemSaveDataRequested -= OnItemSaveDataRequested;
				itemSaveData.ItemSaveDataLoaded -= OnItemSaveDataLoaded;
			}
		}

		protected override bool OnUpdateHoles(Drillable drillable, int holeIndex, bool use)
		{
			if (itemWorkingAnimation.IsAnimating && !itemWorkingAnimation.WorkDone)
			{
				return false;
			}
			if (!drillable.CheckIfCanChangeToState(holeIndex, MountPoint.States.Taped, out var failedDueToSurfaceConditions))
			{
				if (failedDueToSurfaceConditions)
				{
					GadgetInteractor.ShowInteractionTextLMB("interaction/duct_tape_not_here");
				}
				return false;
			}
			if (usesLeft <= 0)
			{
				return false;
			}
			GadgetInteractor.ShowInteractionTextLMB("interaction/duct_tape");
			if (base.IsPressed)
			{
				if (VRManager.IsVREnabled())
				{
					ConsumeOneUse();
					drillable.SetMountPointState(holeIndex, MountPoint.States.Taped);
					soundOnCompleted.Play(base.transform.position);
					VRTK_ControllerReference vRTK_ControllerReference = ((vrGrabbedBy != SDK_BaseController.ControllerHand.None) ? VRTK_DeviceFinder.GetControllerReferenceForHand(vrGrabbedBy) : null);
					if (vRTK_ControllerReference != null && vRTK_ControllerReference.IsValid())
					{
						HapticUtils.DoHapticPulse(vRTK_ControllerReference, HapticIntensityType.Normal);
					}
				}
				else
				{
					targetDrillable = drillable;
					currentHoleIndex = holeIndex;
					itemWorkingAnimation.StartAnimating();
				}
			}
			return true;
		}

		protected override void OnGrabbed()
		{
			if (VRManager.IsVREnabled())
			{
				GameObject grabbingObject = base.gameObject.GetComponent<ItemVRTK>().Interactable.GetGrabbingObject();
				vrGrabbedBy = VRTK_DeviceFinder.GetControllerHand(grabbingObject);
			}
		}

		protected override void OnUngrabbed()
		{
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.StopAnimating();
			}
			else
			{
				vrGrabbedBy = SDK_BaseController.ControllerHand.None;
			}
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			return animationHelper.GetPose(vrInteractionPoint, itemWorkingAnimation);
		}

		public void ConsumeOneUse()
		{
			if (TutorialHelper.InRestrictedMode)
			{
				return;
			}
			if (usesLeft == 0)
			{
				Debug.LogError("Unexpected state: Attempt to use duct tape with 0 uses left!");
				return;
			}
			usesLeft--;
			tapeModelUpdater?.UpdateActiveStates(PercentageUsesLeft);
			if (usesLeft != 0)
			{
				return;
			}
			ItemBase component = GetComponent<ItemBase>();
			if (component == null)
			{
				Debug.LogError("Unexpected state: ItemBase missing on DuctTape, can't mark as irrelevant");
				return;
			}
			int equipSlotForItem = SingletonBehaviour<Inventory>.Instance.GetEquipSlotForItem(component.gameObject);
			if (equipSlotForItem < 0)
			{
				Debug.LogError("Unexpected state: DuctTape not equipped when consumed? Can't be swapped for empty");
				return;
			}
			SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(component.gameObject);
			if (emptyTapeItemPrefab != null)
			{
				GameObject gameObject = Object.Instantiate(emptyTapeItemPrefab, base.transform.position, base.transform.rotation);
				gameObject.GetComponent<RespawnOnDrop>().ignoreDistanceFromSpawnPosition = true;
				SingletonBehaviour<Inventory>.Instance.EquipItem(gameObject, equipSlotForItem);
			}
			SingletonBehaviour<Inventory>.Instance.DestroyItem(component.gameObject);
		}

		private JObject OnItemSaveDataRequested(JObject data)
		{
			data.SetInt("uses", usesLeft);
			return data;
		}

		private void OnItemSaveDataLoaded(JObject data)
		{
			int? num = data?.GetInt("uses");
			if (num.HasValue)
			{
				usesLeft = num.Value;
				tapeModelUpdater?.UpdateActiveStates(PercentageUsesLeft);
			}
		}
	}
}
