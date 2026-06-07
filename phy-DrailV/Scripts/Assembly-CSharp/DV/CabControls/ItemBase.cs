using System;
using System.Collections;
using System.Linq;
using DV.CabControls.Spec;
using DV.ECS.Components;
using DV.ECS.Systems;
using DV.Interaction;
using DV.InventorySystem;
using DV.Items;
using DV.Utils;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace DV.CabControls
{
	public abstract class ItemBase : ControlImplBase
	{
		public delegate void ItemInventoryStateChangedDelegate(ItemBase item, InventoryActionType actionType, InventoryItemState itemState);

		public delegate void ItemContainerStateChangedDelegate(ItemBase item, AItemContainer newContainer, AItemContainer oldContainer, bool added);

		private static CachedArchetype itemArchetype;

		public ItemDisabler itemDisabler;

		private Vector3? originalLocalScale;

		private Renderer[] _renderers;

		protected ItemUseApproach useApproach;

		private Coroutine addItemDisablerCoro;

		private ControlImplBase[] nestedInteractables;

		private DVConvertToEntity entityConvert;

		private ItemContainer inContainer;

		public InventoryItemSpec InventorySpecs { get; private set; }

		public CabItemRigidbody CabItem { get; private set; }

		public SnappableItem SnappableItem { get; private set; }

		public bool IsSnapped
		{
			get
			{
				if (SnappableItem != null)
				{
					return SnappableItem.IsSnapped;
				}
				return false;
			}
		}

		public bool IsBeltSnappable { get; private set; }

		public bool IsUprightInBelt { get; private set; }

		public Item SpecItem { get; private set; }

		public Rigidbody ItemRigidbody
		{
			get
			{
				if (!(CabItem != null))
				{
					return null;
				}
				return CabItem.GetRigidbody();
			}
		}

		public Renderer[] Renderers => _renderers ?? (_renderers = GetComponentsInChildren<Renderer>(includeInactive: true));

		public ItemContainer InContainer
		{
			get
			{
				return inContainer;
			}
			set
			{
				if (!(inContainer == value))
				{
					ItemContainer oldContainer = inContainer;
					inContainer = value;
					this.ItemInContainerStateChanged?.Invoke(this, inContainer, oldContainer, inContainer != null);
				}
			}
		}

		public AItemContainer TopmostContainer
		{
			get
			{
				if (!inContainer)
				{
					return null;
				}
				return inContainer.NestedIn.lastNest ?? inContainer;
			}
		}

		protected override InteractionHandPoses GenericHandPoses { get; } = new InteractionHandPoses(HandPose.PreGrab, HandPose.PreGrab, HandPose.Grab);

		public abstract bool IsTwoHanded { get; }

		public event Action<ItemBase> AboutToBeDestroyed;

		public event Action<ItemBase> ForceRemovedFromActivityHandler;

		public event ItemInventoryStateChangedDelegate ItemInventoryStateChanged;

		public event ItemContainerStateChangedDelegate ItemInContainerStateChanged;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void StaticInit()
		{
			itemArchetype = new CachedArchetype(ComponentType.ReadWrite<Transform>(), ComponentType.ReadWrite<LocalToWorld>(), ComponentType.ReadWrite<CopyTransformFromGameObjectLateUpdate>(), ComponentType.ReadWrite<PreviousFrameLocalToWorld>(), ComponentType.ReadWrite<VelocityEstimate>(), ComponentType.ReadWrite<ItemComponent>());
		}

		public abstract void AssignForceDropAnchor(Transform forceDropTransform);

		private void Awake()
		{
			originalLocalScale = base.transform.localScale;
			SpecItem = GetComponent<Item>();
			useApproach = SpecItem.itemUseApproach;
			base.gameObject.AddComponent<ItemBuoyancy>().buoyancy = SpecItem.buoyancy;
			Rigidbody rigidbody = base.gameObject.GetComponent<Rigidbody>();
			if (!rigidbody)
			{
				rigidbody = base.gameObject.AddComponent<Rigidbody>();
			}
			rigidbody.mass = SpecItem.rigidbodyMass;
			rigidbody.drag = SpecItem.rigidbodyDrag;
			rigidbody.angularDrag = SpecItem.rigidbodyAngularDrag;
			rigidbody.isKinematic = false;
			rigidbody.useGravity = true;
			CabItem = base.gameObject.AddComponent<CabItemRigidbody>();
			CabItem.receiveForces = SpecItem.receiveForces;
			CabItem.allowPlayerRotationXAxis = SpecItem.allowPlayerRotationXAxisVr;
			CabItem.allowPlayerRotationYAxis = SpecItem.allowPlayerRotationYAxisVr;
			if ((bool)SpecItem.collision)
			{
				CollisionSound collisionSound = base.gameObject.AddComponent<CollisionSound>();
				collisionSound.sound = SpecItem.collision;
				collisionSound.InitializeCollisionSoundCategory(SpecItem.itemCollisionSoundCategory, SpecItem.ignoredCollsionSoundCategory);
			}
			InventorySpecs = GetComponent<InventoryItemSpec>();
			base.gameObject.AddComponent<NonAABBReflectionProbeSampler>();
			if (!base.gameObject.TryGetComponent<ItemTransparencyHandler>(out var _))
			{
				if (TryGetComponent<PageBook>(out var _))
				{
					base.gameObject.AddComponent<PageBookTransparencyHandler>();
				}
				else
				{
					base.gameObject.AddComponent<ItemTransparencyHandler>();
				}
			}
			SetupECS();
			Setup();
			AddItemReparenting();
			SetupSnappable(SpecItem);
			addItemDisablerCoro = SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(EndOfFrameSetupCoro());
		}

		private void SetupECS()
		{
			entityConvert = base.gameObject.AddComponent<DVConvertToEntity>();
			entityConvert.Initialize(itemArchetype.Archetype);
			entityConvert.OnConverted += delegate(EntityManager manager, Entity entity)
			{
				manager.SetComponentData(entity, new LocalToWorld
				{
					Value = base.transform.localToWorldMatrix
				});
				manager.SetComponentData(entity, new PreviousFrameLocalToWorld
				{
					value = base.transform.localToWorldMatrix
				});
			};
			if (!TryGetComponent<ItemSimulationSpace>(out var component))
			{
				return;
			}
			component.SimulationSpaceChanged += delegate(Transform oldParent, Transform newParent)
			{
				EntityCommandBuffer value = World.DefaultGameObjectInjectionWorld.GetExistingSystem<BeginPresentationEntityCommandBufferSystem>().CreateCommandBuffer();
				if ((bool)newParent)
				{
					DVConvertToEntity componentInParent = newParent.GetComponentInParent<DVConvertToEntity>();
					if ((bool)componentInParent)
					{
						value.AddComponent(entityConvert.Entity, new VelocityParent
						{
							parent = componentInParent.Entity
						});
						return;
					}
				}
				if (entityConvert.HasComponent<VelocityParent>())
				{
					value.RemoveComponent<VelocityParent>(entityConvert.Entity);
				}
				VelocityEstimateSystem.SkipOneFrame(entityConvert.Entity, Option<EntityCommandBuffer>.Some(value));
			};
		}

		private void SetupSnappable(Item spec)
		{
			SnapPointTypes snapPointTypes = spec.allowedSnapPointTypes;
			if (!VRManager.IsVREnabled())
			{
				snapPointTypes &= ~SnapPointTypes.Belt;
			}
			if (snapPointTypes != SnapPointTypes.None)
			{
				if (snapPointTypes.HasIntFlag(SnapPointTypes.Belt))
				{
					IsBeltSnappable = true;
					IsUprightInBelt = spec.isUprightInBelt;
				}
				SnappableItem = base.gameObject.AddComponent<SnappableItem>();
				SnappableItem.Initialize(this, snapPointTypes);
			}
		}

		public void ReCacheRenderers()
		{
			_renderers = null;
		}

		private void SetLayers(bool grabbed)
		{
			int layerToInteractionColliders = (grabbed ? LayerMask.NameToLayer("Grabbed_Item") : LayerMask.NameToLayer("World_Item"));
			SetLayerToInteractionColliders(layerToInteractionColliders);
		}

		public void RefreshLayersExternal()
		{
			SetLayers(IsGrabbed());
		}

		private void OnEnable()
		{
			CabItem.SetupTrainReceivingForces(TrainCar.Resolve(base.transform.root)?.GetComponent<Rigidbody>());
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				if (InventorySpecs != null && (bool)SingletonBehaviour<StorageController>.Instance)
				{
					SingletonBehaviour<StorageController>.Instance.RemoveItemFromStorageItemList(this);
				}
				if (itemDisabler != null)
				{
					itemDisabler.Destroy();
					itemDisabler = null;
				}
				if (addItemDisablerCoro != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.StopCoroutine(addItemDisablerCoro);
				}
				this.AboutToBeDestroyed?.Invoke(this);
			}
		}

		private IEnumerator EndOfFrameSetupCoro()
		{
			yield return null;
			yield return WaitFor.EndOfFrame;
			itemDisabler = new ItemDisabler(this, GetComponent<ItemReparentingBase>());
			if (SpecItem.preventNestedGrabWhenUnGrabbed)
			{
				nestedInteractables = (from c in GetComponentsInChildren<ControlImplBase>()
					where c != this
					select c).ToArray();
			}
			RefreshNestedInteractablesUsage();
		}

		protected override void AcceptSetValue(float newValue)
		{
			Debug.LogWarning("ItemBase doesn't support AcceptSetValue", base.gameObject);
		}

		protected abstract void Setup();

		protected abstract void AddItemReparenting();

		protected override void FireGrabbed()
		{
			SetLayers(grabbed: true);
			base.FireGrabbed();
			RefreshNestedInteractablesUsage();
			ResetScale();
			PlayerManager.PlayerTeleportFinished += OnTP;
		}

		protected override void FireUngrabbed()
		{
			if (!IsGrabbed())
			{
				SetLayers(grabbed: false);
			}
			base.FireUngrabbed();
			RefreshNestedInteractablesUsage();
			ResetScale();
			PlayerManager.PlayerTeleportFinished -= OnTP;
		}

		private void OnTP()
		{
			VelocityEstimateSystem.SkipOneFrame(entityConvert.Entity);
		}

		protected void ResetScale()
		{
			if (originalLocalScale.HasValue)
			{
				base.transform.localScale = originalLocalScale.Value;
			}
		}

		public void FireInventoryStateChanged(InventoryActionType actionType, InventoryItemState itemState)
		{
			this.ItemInventoryStateChanged?.Invoke(this, actionType, itemState);
		}

		public void ForceRemoveFromActivityHandler()
		{
			this.ForceRemovedFromActivityHandler?.Invoke(this);
		}

		private void RefreshNestedInteractablesUsage()
		{
			if (SpecItem.preventNestedGrabWhenUnGrabbed)
			{
				ControlImplBase[] array = nestedInteractables;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].InteractionAllowed = IsGrabbed();
				}
			}
		}
	}
}
