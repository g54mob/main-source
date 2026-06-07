using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DV.CabControls;
using DV.Damage;
using DV.Interaction;
using DV.JObjectExtstensions;
using DV.Utils;
using DV.VRTK_Extensions;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VRTK.GrabAttachMechanics;

namespace DV.Customization.Gadgets
{
	public class GadgetBase : TrainCarCustomization.TrainCarCustomizerBase
	{
		[Flags]
		public enum GadgetRemovalMethod
		{
			None = 0,
			Remover = 1,
			EmptyHand = 2,
			FromCode = 4,
			Any = -1
		}

		private static readonly List<GadgetWiringModule.WireLinkPort> wiredToBuffer = new List<GadgetWiringModule.WireLinkPort>();

		public const string KEY_SOURCE_ITEM = "sourceitem";

		public const string KEY_SOURCE_ITEM_PREFABNAME = "prefabname";

		public const string KEY_SOURCE_ITEM_ISOWNEDBYPLAYER = "belongsToPlayer";

		public const string KEY_LINKS = "links";

		public const string KEY_ON_GLASS = "onGlass";

		[SerializeField]
		private GameObject hudPrefab;

		[SerializeField]
		private Vector3 boundsCenter;

		[SerializeField]
		private Vector3 boundsSize;

		[SerializeField]
		private GadgetRemovalMethod removalMethod = GadgetRemovalMethod.Remover;

		[SerializeField]
		private MeshFilter[] highlightMeshes;

		[SerializeField]
		private AudioClip soundOnPlaced;

		[SerializeField]
		private AudioClip soundOnRemoved;

		[SerializeField]
		private bool autoPlaySoundOnPlaced = true;

		[SerializeField]
		private int requiredMountPoints;

		[SerializeField]
		[Tooltip("A string ID ensuring that only one gadget of a given group can be placed on a single Customization. Leave empty to allow multiple instances.")]
		private string reservationGroupID;

		[SerializeField]
		private Collider[] vrIgnoreColliders;

		public readonly GadgetWiringModule wiring = new GadgetWiringModule();

		private bool highlightMeshesInitialized;

		private GadgetSystemUtility.HighlightMesh[] highlightMeshHelpers;

		private ControlImplBase[] nestedInteractables;

		private WindowsBreakingController windowsBreaking;

		private GadgetComponent[] components;

		private Telegrabbable telegrabbableRedirect;

		public GadgetItem GadgetItem { get; private set; }

		public bool IsOnGlass { get; internal set; }

		public GameObject HUDPrefab => hudPrefab;

		public Bounds Bounds => new Bounds(boundsCenter, boundsSize);

		public Vector3 BoundsCenter => boundsCenter;

		public Vector3 BoundsSize => boundsSize;

		public int RequiredMountPoints => requiredMountPoints;

		public GadgetRemovalMethod RawRemovalMethods => removalMethod;

		public bool AutoPlaySoundOnPlaced => autoPlaySoundOnPlaced;

		public AudioClip SoundOnPlaced => soundOnPlaced;

		public AudioClip SoundOnRemoved => soundOnRemoved;

		public bool HasAnyWirePorts => wiring.wireLinkPorts.Count > 0;

		public ReadOnlyCollection<GadgetWiringModule.WireLinkPort> WireLinkPorts => wiring.wireLinkPorts;

		public Mount MountedOn { get; internal set; }

		public bool IsGlassBroken
		{
			get
			{
				if (windowsBreaking != null)
				{
					return windowsBreaking.windowsBroken;
				}
				return false;
			}
		}

		public event Action<GadgetBase, bool> ForceRemoveCalled;

		public event Action<GadgetBase> ItemAssigned;

		public bool CanBeRemovedUsingMethod(GadgetRemovalMethod method)
		{
			return GetValidRemovalMethods().HasAnyFlag(method);
		}

		protected override void Awake()
		{
			components = GetComponents<GadgetComponent>();
			base.Awake();
			if (!VRManager.IsVREnabled() || !removalMethod.HasIntFlag(GadgetRemovalMethod.EmptyHand))
			{
				return;
			}
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			VRTK_InteractableObject_DV vRTK_InteractableObject_DV = base.gameObject.AddComponent<VRTK_InteractableObject_DV>();
			if (vrIgnoreColliders.Length != 0)
			{
				Collider[] array = vrIgnoreColliders;
				for (int i = 0; i < array.Length; i++)
				{
					if (!(array[i] != null))
					{
						Debug.LogError("[CUSTOMIZATION] Gadget " + base.name + " has a null collider in the VR ignore colliders list. This will cause issues.", this);
					}
				}
				vRTK_InteractableObject_DV.ignoredColliders = vrIgnoreColliders;
			}
			base.gameObject.AddComponent<GadgetTouchedHighlighter>();
			rigidbody.isKinematic = true;
			vRTK_InteractableObject_DV.interactionHandPoses = new InteractionHandPoses
			{
				grabPose = HandPose.Grab,
				nearTouchPose = HandPose.PreGrab,
				touchPose = HandPose.PreGrab
			};
			GadgetAttachMethod gadgetAttachMethod = base.gameObject.AddComponent<GadgetAttachMethod>();
			gadgetAttachMethod.gadget = this;
			vRTK_InteractableObject_DV.grabAttachMechanicScript = gadgetAttachMethod;
			vRTK_InteractableObject_DV.isGrabbable = true;
			base.gameObject.AddComponent<GadgetHandVR>().gadget = this;
		}

		protected void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && telegrabbableRedirect != null)
			{
				telegrabbableRedirect.IsBeingTelegrabbedChanged.Unregister(OnTelegrabbableChanged);
			}
		}

		public void OnTelegrabbableChanged(bool isBeingTelegrabbed)
		{
			if (base.IsLinked && isBeingTelegrabbed)
			{
				ForceRemove();
			}
		}

		public GadgetRemovalMethod GetValidRemovalMethods()
		{
			return (removalMethod | GadgetRemovalMethod.FromCode) & GetValidRemovalMethodsMask();
		}

		public virtual GadgetRemovalMethod GetValidRemovalMethodsMask()
		{
			GadgetRemovalMethod gadgetRemovalMethod = GadgetRemovalMethod.Any;
			GadgetComponent[] array = components;
			foreach (GadgetComponent gadgetComponent in array)
			{
				gadgetRemovalMethod &= gadgetComponent.GetValidRemovalMethodsMask();
			}
			return gadgetRemovalMethod;
		}

		public void AssignItem(GadgetItem gadgetItem)
		{
			if (GadgetItem != null || gadgetItem.Gadget != this)
			{
				Debug.LogError("[CUSTOMIZATION] Bad gadget-item pairing!", this);
				return;
			}
			GadgetItem = gadgetItem;
			if (VRManager.IsVREnabled() && removalMethod.HasIntFlag(GadgetRemovalMethod.EmptyHand))
			{
				TelegrabbableGadget telegrabbableGadget = base.gameObject.AddComponent<TelegrabbableGadget>();
				telegrabbableGadget.gadgetBase = this;
				telegrabbableGadget.RedirectTo = GadgetItem.GetComponent<Telegrabbable>();
				telegrabbableRedirect = telegrabbableGadget.RedirectTo;
				if (telegrabbableRedirect != null)
				{
					telegrabbableRedirect.IsBeingTelegrabbedChanged.Register(OnTelegrabbableChanged);
				}
			}
			nestedInteractables = GetComponentsInChildren<ControlImplBase>(includeInactive: true);
			OnItemAssigned();
			this.ItemAssigned?.Invoke(this);
		}

		protected internal virtual void GeneratePlacementData(Collider placedOnto)
		{
			IsOnGlass = placedOnto.TryGetComponent<LocoWindowMesh>(out var _);
			GadgetComponent[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].GeneratePlacementData(placedOnto);
			}
		}

		protected internal virtual void OnGlassBroken()
		{
			GadgetComponent[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnGlassBroken();
			}
			if (IsOnGlass)
			{
				ForceRemove();
			}
		}

		public virtual GadgetItem ForceRemove(bool reparentToTrainCar = true)
		{
			if (!base.IsLinked)
			{
				Debug.LogError("[CUSTOMIZATION] The gadget you are trying to removed is already removed!", this);
				return null;
			}
			this.ForceRemoveCalled?.Invoke(this, reparentToTrainCar);
			return Remove(reparentToTrainCar);
		}

		public GadgetItem Remove(bool reparentToTrainCar = true)
		{
			if (!base.IsLinked)
			{
				Debug.LogError("[CUSTOMIZATION] The gadget you are trying to removed is already removed!", this);
				return null;
			}
			if (!CanBeRemovedUsingMethod(GadgetRemovalMethod.Any))
			{
				Debug.LogError("[CUSTOMIZATION] The gadget you are trying to removed cannot be removed! Is another gadget sitting on top of it?", this);
				return null;
			}
			if (GadgetItem == null)
			{
				Debug.LogError("Gadget " + base.name + " has no item to remove. This should not happen.", this);
				return null;
			}
			TrainCar trainCar = base.TrainCar;
			Unlink();
			GadgetItem.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
			SingletonBehaviour<StorageController>.Instance.MoveFromInstalledGadgetsToWorld(GadgetItem.gameObject);
			ItemReparentingBase component = GadgetItem.Item.GetComponent<ItemReparentingBase>();
			if (reparentToTrainCar && trainCar != null)
			{
				component.ParentItemExternal(trainCar.interior, trainCar.rb);
			}
			else
			{
				component.ParentItemExternal(WorldMover.OriginShiftParent, null);
			}
			base.transform.SetParent(null);
			base.gameObject.SetActive(value: false);
			return GadgetItem;
		}

		public override bool IsValidTarget(Customization target, Collider hitCollider)
		{
			if (base.IsValidTarget(target, hitCollider))
			{
				return IsValidTargetSelf(target, hitCollider);
			}
			return false;
		}

		private bool IsValidTargetSelf(Customization target, Collider hitCollider)
		{
			if (!string.IsNullOrWhiteSpace(reservationGroupID))
			{
				foreach (Customization.CustomizerBase customizer in target.Customizers)
				{
					if (customizer is GadgetBase gadgetBase && !string.IsNullOrWhiteSpace(gadgetBase.reservationGroupID) && reservationGroupID == gadgetBase.reservationGroupID)
					{
						return false;
					}
				}
			}
			return true;
		}

		protected GadgetWiringModule.WireLinkPort<T> RegisterWireLink<T>(Action<T> onWired, Action<T> onUnwired, bool allowMultipleLinks, bool markPassive = false) where T : GadgetBase
		{
			if (allowMultipleLinks)
			{
				return new GadgetWiringModule.WireLinkPortMulti<T>(this, markPassive, onWired, onUnwired);
			}
			return new GadgetWiringModule.WireLinkPortMono<T>(this, markPassive, onWired, onUnwired);
		}

		public bool TryGetCompatiblePorts(GadgetBase other, out GadgetWiringModule.WireLinkPort myPort, out GadgetWiringModule.WireLinkPort otherPort)
		{
			return wiring.TryGetCompatiblePorts(other.wiring, out myPort, out otherPort);
		}

		public void DrawHighlight(Vector3 position, Quaternion rotation, Color color)
		{
			if (!highlightMeshesInitialized || highlightMeshHelpers == null)
			{
				highlightMeshHelpers = GadgetSystemUtility.GenerateHighlightMeshes(base.transform, highlightMeshes);
				highlightMeshesInitialized = true;
			}
			if (highlightMeshHelpers.Length != 0)
			{
				GadgetSystemUtility.DrawHighlight(position, rotation, highlightMeshHelpers, color);
			}
			else
			{
				GadgetSystemUtility.DrawBounds(position, rotation, BoundsCenter, BoundsSize, color);
			}
		}

		public void DrawHighlight(Color color, bool doLateUpdateOffset = false)
		{
			Vector3 position = base.transform.position;
			if (doLateUpdateOffset && (bool)PlayerManager.Car)
			{
				position += PlayerManager.Car.GetNextInteriorPositionOffset();
			}
			DrawHighlight(position, base.transform.rotation, color);
		}

		public override void SaveDataRequested(JObject dst)
		{
			GadgetComponent[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SaveDataRequested(dst);
			}
			if (HasAnyWirePorts)
			{
				wiredToBuffer.Clear();
				foreach (GadgetWiringModule.WireLinkPort wireLinkPort in wiring.wireLinkPorts)
				{
					wireLinkPort.GetLinks(wiredToBuffer);
				}
				PooledArray<int> pooledArray = ArrayPool<int>.New(wiredToBuffer.Count);
				for (int j = 0; j < pooledArray.Length; j++)
				{
					pooledArray[j] = wiredToBuffer[j].owner.UID;
				}
				dst.SetIntArray("links", pooledArray);
				wiredToBuffer.Clear();
				pooledArray.Dispose();
			}
			dst.SetBool("onGlass", IsOnGlass);
			base.SaveDataRequested(dst);
		}

		public override void SaveDataLoaded(JObject src)
		{
			base.SaveDataLoaded(src);
			IsOnGlass = src.GetBool("onGlass") ?? false;
			GadgetComponent[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SaveDataLoaded(src);
			}
			int[] intArray = src.GetIntArray("links");
			if (intArray == null || base.Custom == null)
			{
				return;
			}
			int[] array2 = intArray;
			foreach (int num in array2)
			{
				if (base.Custom.TryGetCustomizerByUID(num, out var customizer) && customizer is GadgetBase other && (!TryGetCompatiblePorts(other, out var myPort, out var otherPort) || !GadgetWiringModule.WireLinkPort.Wire(myPort, otherPort)))
				{
					Debug.LogError($"[CUSTOMIZATION] Failed to wire or find compatible wire ports for gadgets uid{base.UID} {GetType().Name} and uid{num} {customizer.GetType().Name}", this);
				}
			}
		}

		public override void AfterSaveDataLoaded(JObject src)
		{
			base.AfterSaveDataLoaded(src);
			GadgetComponent[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AfterSaveDataLoaded(src);
			}
		}

		public void PlayPlaceSound(Transform transformOverride = null)
		{
			Transform transform = transformOverride ?? base.transform;
			((SoundOnPlaced != null) ? SoundOnPlaced : SingletonBehaviour<GadgetSystemUtility>.Instance.SoundOnGadgetPlaced).Play(transform.position);
		}

		public void PlayRemoveSound(Transform transformOverride = null)
		{
			Transform transform = transformOverride ?? base.transform;
			((SoundOnRemoved != null) ? SoundOnRemoved : SingletonBehaviour<GadgetSystemUtility>.Instance.SoundOnGadgetRemoved).Play(transform.position);
		}

		protected override void OnBeforeLinked()
		{
			base.OnBeforeLinked();
			IsOnGlass = false;
		}

		protected override void OnAfterLinked()
		{
			base.OnAfterLinked();
			if (base.IsOnTrainCar)
			{
				windowsBreaking = base.TrainCar.GetComponent<WindowsBreakingController>();
				if (windowsBreaking != null)
				{
					windowsBreaking.WindowsBroken += OnGlassBroken;
				}
				base.TrainCar.InteriorAboutToBeDestroyed += OnTrainCarDestroyed;
			}
			ControlImplBase[] array = nestedInteractables;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ResetParent();
			}
		}

		protected override void OnBeforeUnlinked()
		{
			if (MountedOn != null)
			{
				MountedOn.UnmountGadget();
			}
			if (base.IsOnTrainCar)
			{
				base.TrainCar.InteriorAboutToBeDestroyed -= OnTrainCarDestroyed;
			}
			wiring.UnwireAll();
			base.OnBeforeUnlinked();
			if (windowsBreaking != null)
			{
				windowsBreaking.WindowsBroken -= OnGlassBroken;
				windowsBreaking = null;
			}
		}

		protected override void OnAfterUnlinked()
		{
			base.OnAfterUnlinked();
			IsOnGlass = false;
		}

		private void OnTrainCarDestroyed(TrainCar _)
		{
			if (!UnloadWatcher.isUnloading && base.IsLinked)
			{
				ForceRemove(reparentToTrainCar: false);
			}
		}

		protected virtual void OnDrawGizmosSelected()
		{
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.color = Color.white;
			Gizmos.DrawWireCube(boundsCenter, boundsSize);
		}

		protected virtual void OnItemAssigned()
		{
		}
	}
}
