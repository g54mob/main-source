using System.Collections;
using DV.CabControls;
using DV.Customization.Paint;
using DV.Interaction.Inputs;
using DV.InventorySystem;
using DV.Items;
using DV.Localization;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class PaintSprayer : MonoBehaviour, IItemUse
	{
		private const string LOC_PAINT = "interaction/paint/paint";

		private const string LOC_UNPAINT = "interaction/paint/unpaint";

		private const string LOC_ALREADY_PAINTED = "interaction/paint/already_painted";

		private const string LOC_ALREADY_SANDED = "interaction/paint/already_sanded";

		private const string LOC_NOT_ALLOWED_DVRT_LOCO = "interaction/paint/dvrt_loco";

		private const string LOC_INTERACTION = "interaction/load_paint_can";

		public const float REACH = 10f;

		private static int interactionLayerMask;

		public float paintingTime = 5f;

		public GameObject sprayEffect;

		public GameObject canReloadPoint;

		private float paintingProgress;

		private PaintCan insertedCan;

		private ItemMagazine magazine;

		private PaintSprayerEffects paintSprayerEffects;

		[SerializeField]
		private Transform unloadAnchor;

		private bool useOngoing;

		private bool isCareerMode;

		private bool reloadingOnCollisionDisabled;

		private bool ignoreMagazineChange;

		private Coroutine toggleReloadingCoro;

		private bool HasEmptyCan
		{
			get
			{
				if (insertedCan != null)
				{
					return insertedCan.theme == null;
				}
				return false;
			}
		}

		private void Awake()
		{
			if (interactionLayerMask == 0)
			{
				interactionLayerMask = LayerMask.GetMask("Train_Big_Collider", "Train_Interior");
			}
			isCareerMode = SingletonBehaviour<UserManager>.Instance?.CurrentUser?.CurrentSession?.GameMode == "Career";
			magazine = GetComponent<ItemMagazine>();
			magazine.ItemContainerDataChanged += OnItemMagazineDataChanged;
			paintSprayerEffects = GetComponent<PaintSprayerEffects>();
			if (VRManager.IsVREnabled())
			{
				canReloadPoint.AddComponent<ItemMagazineInteractionVr>().Initialize(magazine, canReloadPoint, UnloadPaintCan, unloadSpentOnly: false);
			}
		}

		private void Start()
		{
			ItemBase component = GetComponent<ItemBase>();
			component.Used += Use;
			component.UnUsed += UnUse;
			component.Grabbed += OnGrabbed;
			component.Ungrabbed += OnUnGrabbed;
			base.enabled = component.IsGrabbed();
			sprayEffect.SetActive(value: false);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && toggleReloadingCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(toggleReloadingCoro);
			}
		}

		private void OnItemMagazineDataChanged(AItemContainer container, int sourceIndex, int destinationIndex)
		{
			if (!ignoreMagazineChange && sourceIndex == 0 && destinationIndex == -1)
			{
				reloadingOnCollisionDisabled = true;
				if (toggleReloadingCoro != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(toggleReloadingCoro);
				}
				toggleReloadingCoro = SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(RestoreReloadingOnTriggerEnter());
				GameObject gameObject = container[0];
				if (gameObject == null)
				{
					insertedCan = null;
					paintSprayerEffects.OnExtracted();
				}
				else
				{
					PaintCan component = gameObject.GetComponent<PaintCan>();
					insertedCan = component;
					paintSprayerEffects.OnInserted(insertedCan, playSound: true);
				}
			}
		}

		private void OnGrabbed(ControlImplBase obj)
		{
			base.enabled = true;
		}

		private void OnUnGrabbed(ControlImplBase obj)
		{
			useOngoing = false;
			base.enabled = false;
		}

		private void Update()
		{
			TrainCar targetCar;
			TrainCarPaint interactionTarget = GetInteractionTarget(out targetCar);
			PaintCan.Validity validity = PaintCan.Validity.Incompatible;
			if (insertedCan == null || insertedCan.theme == null)
			{
				validity = PaintCan.Validity.PaintCanMissing;
			}
			else if (interactionTarget != null)
			{
				validity = insertedCan.CheckPaintApplicationValidity(interactionTarget.CurrentTheme, targetCar, isCareerMode);
			}
			string text = null;
			switch (validity)
			{
			case PaintCan.Validity.AlreadyPainted:
				text = (insertedCan.theme.IsStrippedSurface ? "interaction/paint/already_sanded" : "interaction/paint/already_painted");
				break;
			case PaintCan.Validity.NotOwnedLoco:
				text = "interaction/paint/dvrt_loco";
				break;
			case PaintCan.Validity.Ok:
				text = (insertedCan.theme.IsStrippedSurface ? "interaction/paint/unpaint" : "interaction/paint/paint");
				break;
			}
			if (text != null && !VRManager.IsVREnabled())
			{
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(LocalizationAPI.L(text, InputManager.Actions.InteractionPrimary.LocalizeInput()));
			}
			if (!useOngoing)
			{
				return;
			}
			if (validity != PaintCan.Validity.Ok)
			{
				paintingProgress = 0f;
				sprayEffect.SetActive(value: false);
				return;
			}
			paintingProgress += Time.deltaTime;
			sprayEffect.SetActive(value: true);
			if (paintingProgress > paintingTime)
			{
				Apply(interactionTarget);
			}
		}

		private void Apply(TrainCarPaint target)
		{
			target.CurrentTheme = insertedCan.theme;
			UnUse();
			ignoreMagazineChange = true;
			magazine.RemoveItem(0, activateItem: true, dropItem: true);
			ignoreMagazineChange = false;
			GameObject emptyCanPrefab = insertedCan.emptyCanPrefab;
			SingletonBehaviour<Inventory>.Instance.DestroyItem(insertedCan.gameObject);
			if (!(emptyCanPrefab == null))
			{
				GameObject gameObject = Object.Instantiate(emptyCanPrefab, unloadAnchor.transform.position, unloadAnchor.transform.rotation).gameObject;
				RespawnOnDrop component = gameObject.GetComponent<RespawnOnDrop>();
				if (component != null)
				{
					component.respawnOnDropThroughFloor = false;
					component.ignoreDistanceFromSpawnPosition = true;
				}
				ignoreMagazineChange = true;
				magazine.AddItem(gameObject, 0);
				ignoreMagazineChange = false;
				insertedCan = gameObject.GetComponent<PaintCan>();
				paintSprayerEffects.OnInserted(insertedCan, playSound: false);
				paintSprayerEffects.OnSpent();
			}
		}

		private TrainCarPaint GetInteractionTarget(out TrainCar targetCar)
		{
			targetCar = null;
			Transform transform = (VRManager.IsVREnabled() ? base.transform : PlayerManager.ActiveCamera.transform);
			if (!Physics.Raycast(transform.position, transform.forward, out var hitInfo, 10f, interactionLayerMask))
			{
				return null;
			}
			targetCar = TrainCar.Resolve(hitInfo.transform);
			if (targetCar == null)
			{
				return null;
			}
			bool flag = targetCar.physicsLod.PlayerInCar;
			CameraTrigger componentInChildren = targetCar.GetComponentInChildren<CameraTrigger>();
			if (componentInChildren != null)
			{
				flag = componentInChildren.IsMainCameraInside;
			}
			if (!(targetCar.PaintInterior != null && flag))
			{
				return targetCar.PaintExterior;
			}
			return targetCar.PaintInterior;
		}

		private void UnloadPaintCan()
		{
			if (!(insertedCan == null))
			{
				PaintCan paintCan = insertedCan;
				reloadingOnCollisionDisabled = true;
				if (toggleReloadingCoro != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(toggleReloadingCoro);
				}
				toggleReloadingCoro = SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(RestoreReloadingOnTriggerEnter());
				magazine.RemoveItem(0, activateItem: true, dropItem: true);
				paintCan.transform.SetPositionAndRotation(unloadAnchor.transform.position, unloadAnchor.transform.rotation);
			}
		}

		private IEnumerator RestoreReloadingOnTriggerEnter()
		{
			yield return WaitFor.FixedUpdate;
			yield return null;
			reloadingOnCollisionDisabled = false;
			toggleReloadingCoro = null;
		}

		private void Use()
		{
			paintingProgress = 0f;
			if (!VRManager.IsVREnabled() && (GetInteractionTarget(out var _) == null || HasEmptyCan))
			{
				UnloadPaintCan();
			}
			else
			{
				useOngoing = true;
			}
		}

		private void UnUse()
		{
			paintingProgress = 0f;
			sprayEffect.SetActive(value: false);
			useOngoing = false;
		}

		public bool HandleHover(ItemUseTarget target)
		{
			if (VRManager.IsVREnabled())
			{
				return false;
			}
			SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(LocalizationAPI.L("interaction/load_paint_can", InputManager.Actions.InteractionPrimary.LocalizeInput()));
			return true;
		}

		public bool HandleUse(ItemUseTarget target)
		{
			return magazine.AddItem(target.gameObject, 0);
		}

		public bool IsHoverCompatible(ItemUseTarget target)
		{
			return IsUseCompatible(target);
		}

		public bool IsUseCompatible(ItemUseTarget target)
		{
			if (reloadingOnCollisionDisabled)
			{
				return false;
			}
			PaintCan paintCan = ((target != null) ? target.GetComponent<PaintCan>() : null);
			if (paintCan == null || paintCan.isSpent)
			{
				return false;
			}
			if (magazine.GetFirstFreeSlot() < 0)
			{
				return false;
			}
			return true;
		}
	}
}
