using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Extensions;
using NSMedieval.Sound;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class DoorOpenAnim : MonoBehaviour
	{
		[SerializeField]
		protected Animator lockAnimator;

		[SerializeField]
		protected LockState openWhenInLockState = LockState.Unlocked;

		[SerializeField]
		protected LockState alwaysOpenLockState = LockState.AlwaysOpen;

		[SerializeField]
		protected LockState forcedOpenLockState = LockState.ForcedOpen;

		[SerializeField]
		protected bool openBothSides = true;

		[SerializeField]
		private DoorComponent doorComponent;

		[SerializeField]
		private BaseBuildingViewComponent baseBuildingViewComponent;

		[SerializeField]
		private AudioEventsComponent audioEventsComponent;

		private DoorComponentInstance doorComponentInstance;

		private readonly List<Collider> nearbyWorkerColliders = new List<Collider>();

		public void SetDoorComponentInstance(DoorComponentInstance doorComponentInstance)
		{
			this.doorComponentInstance = doorComponentInstance;
		}

		public void OnDoorAnimationEvent(string eventName)
		{
			if (doorComponentInstance == null || doorComponentInstance.HasDisposed || string.IsNullOrWhiteSpace(eventName))
			{
				return;
			}
			using PooledDictionary<string, string> parameters = DictionaryPool<string, string>.GetJanitor();
			parameters.Add("Material", doorComponentInstance.OwnerBuilding.Blueprint.SoundMaterialCategory.ToString());
			bool isEnabled;
			switch (eventName)
			{
			case "OpenStart":
			{
				audioEventsComponent.SetEventParameters(doorComponentInstance.Blueprint.OpenAudioEventId, parameters);
				audioEventsComponent.PlayEventInstance(doorComponentInstance.Blueprint.OpenAudioEventId);
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\DoorOpenAnim.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Play ");
					messageBuilder.AppendFormatted(doorComponentInstance.Blueprint.OpenAudioEventId);
					messageBuilder.AppendLiteral(". Parameters: ");
					messageBuilder.AppendFormatted(parameters.Values.ToPrettyString());
				}
				Log.Debug(messageBuilder);
				break;
			}
			case "OpenEnd":
				audioEventsComponent.KeyOffEventInstance(doorComponentInstance.Blueprint.OpenAudioEventId);
				break;
			case "CloseStart":
			{
				audioEventsComponent.SetEventParameters(doorComponentInstance.Blueprint.CloseAudioEventId, parameters);
				audioEventsComponent.PlayEventInstance(doorComponentInstance.Blueprint.CloseAudioEventId);
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\DoorOpenAnim.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Play ");
					messageBuilder.AppendFormatted(doorComponentInstance.Blueprint.CloseAudioEventId);
					messageBuilder.AppendLiteral(". Parameters: ");
					messageBuilder.AppendFormatted(parameters.Values.ToPrettyString());
				}
				Log.Debug(messageBuilder);
				break;
			}
			case "CloseEnd":
				audioEventsComponent.KeyOffEventInstance(doorComponentInstance.Blueprint.CloseAudioEventId);
				break;
			}
		}

		public void StartOpeningAnimation(float animationSpeedMultiplier)
		{
			if (!(lockAnimator == null) && doorComponentInstance != null && !doorComponentInstance.HasDisposed && doorComponentInstance.LockState != LockState.ForcedOpen)
			{
				SetAnimatorBool("open_abort", value: false);
				SetAnimatorBool("close_abort", value: false);
				SetAnimatorFloat("Multiplier", animationSpeedMultiplier);
				SetAnimatorBool("close", value: false);
				if (doorComponentInstance.Blueprint.CanChangeDirection)
				{
					SetAnimatorBool("front", doorComponentInstance.GateDirection != GateDirection.Default);
				}
				SetAnimatorBool("open", value: true);
			}
		}

		public void StartClosingAnimation(float animationDuration)
		{
			if (!(lockAnimator == null) && doorComponentInstance != null && !doorComponentInstance.HasDisposed && doorComponentInstance.LockState != LockState.ForcedOpen)
			{
				SetAnimatorBool("open_abort", value: false);
				SetAnimatorBool("close_abort", value: false);
				SetAnimatorFloat("Speed", animationDuration);
				SetAnimatorBool("open", value: false);
				if (doorComponentInstance.Blueprint.CanChangeDirection)
				{
					SetAnimatorBool("front", doorComponentInstance.GateDirection != GateDirection.Default);
				}
				SetAnimatorBool("close", value: true);
			}
		}

		public void AbortPortcullisOpening()
		{
			if (!(lockAnimator == null) && doorComponentInstance != null && !doorComponentInstance.HasDisposed && doorComponentInstance.LockState != LockState.ForcedOpen)
			{
				SetAnimatorBool("open_abort", value: true);
			}
		}

		public void AbortDrawbridgeClosing()
		{
			if (!(lockAnimator == null) && doorComponentInstance != null && !doorComponentInstance.HasDisposed && doorComponentInstance.LockState != LockState.ForcedOpen)
			{
				SetAnimatorBool("close_abort", value: true);
			}
		}

		public void AbortGateOpening()
		{
			if (!(lockAnimator == null) && doorComponentInstance != null && !doorComponentInstance.HasDisposed && doorComponentInstance.LockState != LockState.ForcedOpen)
			{
				SetAnimatorBool("close_abort", value: false);
				SetAnimatorBool("open_abort", value: true);
				SetAnimatorBool("open", value: false);
				SetAnimatorBool("close", value: true);
			}
		}

		public void AbortGateClosing()
		{
			if (!(lockAnimator == null) && doorComponentInstance != null && !doorComponentInstance.HasDisposed && doorComponentInstance.LockState != LockState.ForcedOpen)
			{
				SetAnimatorBool("open_abort", value: false);
				SetAnimatorBool("close_abort", value: true);
				SetAnimatorBool("close", value: false);
				SetAnimatorBool("open", value: true);
			}
		}

		public void InvertOpenedGate()
		{
			if (doorComponentInstance != null && !doorComponentInstance.HasDisposed)
			{
				SetAnimatorBool((doorComponentInstance.GateDirection == GateDirection.Default) ? "snap_to_front" : "snap_to_back", value: true);
			}
		}

		public void UpdateDoorAnim(Collider collider)
		{
			if (lockAnimator == null || doorComponentInstance == null || doorComponentInstance.HasDisposed)
			{
				return;
			}
			openBothSides = doorComponentInstance.Blueprint.DoorType == DoorType.Regular;
			bool flag = doorComponentInstance.LockState == openWhenInLockState || doorComponentInstance.LockState == alwaysOpenLockState || doorComponentInstance.LockState == forcedOpenLockState;
			if (flag && doorComponentInstance.LockState != alwaysOpenLockState && doorComponentInstance.LockState != forcedOpenLockState)
			{
				for (int num = nearbyWorkerColliders.Count - 1; num >= 0; num--)
				{
					if (nearbyWorkerColliders[num] == null || nearbyWorkerColliders[num].gameObject == null || !nearbyWorkerColliders[num].gameObject.activeInHierarchy || IsTooFar(nearbyWorkerColliders[num].gameObject.transform.position))
					{
						nearbyWorkerColliders.RemoveAt(num);
					}
				}
				flag &= nearbyWorkerColliders.Count > 0;
			}
			SetOpenCloseAnim(flag, collider);
		}

		public void UpdatePortcullisState()
		{
			if (!(lockAnimator == null) && doorComponentInstance != null && !doorComponentInstance.HasDisposed && doorComponentInstance.LockState != LockState.ForcedOpen)
			{
				if (doorComponentInstance.LockState == LockState.AlwaysOpen)
				{
					SetAnimatorBool("close", value: false);
					SetAnimatorBool("open", value: true);
				}
				else
				{
					SetAnimatorBool("open", value: false);
					SetAnimatorBool("close", value: true);
				}
			}
		}

		public void UpdateDrawbridgeState()
		{
			if (!(lockAnimator == null) && doorComponentInstance != null && !doorComponentInstance.HasDisposed)
			{
				LockState lockState = doorComponentInstance.LockState;
				if (lockState == LockState.AlwaysOpen || lockState == LockState.ForcedOpen)
				{
					SetAnimatorBool("close", value: false);
					SetAnimatorBool("open", value: true);
				}
				else
				{
					SetAnimatorBool("open", value: false);
					SetAnimatorBool("close", value: true);
				}
			}
		}

		private void Start()
		{
			if (lockAnimator != null)
			{
				lockAnimator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
				lockAnimator.updateMode = AnimatorUpdateMode.Normal;
				lockAnimator.speed = 1f;
				lockAnimator.enabled = false;
				lockAnimator.gameObject.AddComponent<AnimationEventForwarder>().target = base.gameObject;
			}
		}

		private void SetAnimatorBool(string name, bool value)
		{
			if (!lockAnimator.enabled)
			{
				lockAnimator.enabled = true;
				VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.Register(lockAnimator);
			}
			lockAnimator.SetBool(name, value);
			VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.OnAnimatorParamModified(lockAnimator);
		}

		private void SetAnimatorFloat(string name, float value)
		{
			if (!lockAnimator.enabled)
			{
				lockAnimator.enabled = true;
				VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.Register(lockAnimator);
			}
			lockAnimator.SetFloat(name, value);
			VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.OnAnimatorParamModified(lockAnimator);
		}

		private bool IsTooFar(Vector3 worldPosition)
		{
			if (doorComponentInstance == null || doorComponentInstance.HasDisposed)
			{
				return true;
			}
			if (!(Mathf.Abs(doorComponentInstance.WorldPosition.x - worldPosition.x) > 1.1f) && !(Mathf.Abs(doorComponentInstance.WorldPosition.z - worldPosition.z) > 1.1f))
			{
				return Mathf.Abs(doorComponentInstance.WorldPosition.y - worldPosition.y) > 1.5f;
			}
			return true;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!(lockAnimator == null) && baseBuildingViewComponent?.BaseBuildingInstance != null && !baseBuildingViewComponent.BaseBuildingInstance.HasDisposed && baseBuildingViewComponent.BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Finished) && doorComponentInstance != null && !doorComponentInstance.HasDisposed && doorComponentInstance.Blueprint.DoorType == DoorType.Regular && other.CompareTag("Villager"))
			{
				if (!nearbyWorkerColliders.Contains(other))
				{
					nearbyWorkerColliders.Add(other);
				}
				UpdateDoorAnim(other);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (!(lockAnimator == null) && doorComponentInstance != null && !baseBuildingViewComponent.HasDisposed && !doorComponentInstance.HasDisposed && !baseBuildingViewComponent.BaseBuildingInstance.HasDisposed && baseBuildingViewComponent.BaseBuildingInstance.ConstructionPhase == ConstructionPhase.Finished && doorComponentInstance.Blueprint.DoorType == DoorType.Regular && other.CompareTag("Villager"))
			{
				if (nearbyWorkerColliders.Contains(other))
				{
					nearbyWorkerColliders.Remove(other);
				}
				UpdateDoorAnim(other);
			}
		}

		public void OnBuildingDisposed()
		{
			VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.Unregister(lockAnimator);
			doorComponentInstance = null;
			lockAnimator.enabled = false;
			lockAnimator.transform.rotation = Quaternion.Euler(Vector3.zero);
			lockAnimator.enabled = true;
		}

		private void SetOpenCloseAnim(bool isOpen, Collider opener)
		{
			if (lockAnimator == null || doorComponentInstance == null || doorComponentInstance.HasDisposed || lockAnimator.GetBool("open") == isOpen)
			{
				return;
			}
			if (openBothSides)
			{
				if (isOpen && opener != null)
				{
					SetAnimatorBool("front", CheckDoorSide(opener.transform));
				}
			}
			else if (doorComponentInstance.Blueprint.CanChangeDirection)
			{
				SetAnimatorBool("front", doorComponentInstance.GateDirection != GateDirection.Default);
			}
			SetAnimatorBool("open", isOpen);
		}

		private bool CheckDoorSide(Transform target)
		{
			return !(base.transform.InverseTransformPoint(target.position).z > 0f);
		}
	}
}
