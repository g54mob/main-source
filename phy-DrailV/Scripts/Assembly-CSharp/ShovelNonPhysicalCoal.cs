using System;
using DV.CabControls;
using DV.Interaction;
using DV.Player;
using DV.Simulation.Cars;
using DV.Simulation.Controllers;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK.GrabAttachMechanics;

public class ShovelNonPhysicalCoal : MonoBehaviour, IItemUseAnimated, IItemUse, IInteractionPointProvider
{
	public const float REQUIRED_DOOR_OPENED_PERCENTAGE_NON_VR = 0.6f;

	private const float REQUIRED_DOOR_OPENED_PERCENTAGE_VR = 0.25f;

	private const float VR_INTERACTION_TIMEOUT = 0.5f;

	private const string VISUAL_COAL_ANCHOR = "[visual coal anchor]";

	[NonSerialized]
	public int shovelChunksCapacity;

	[NonSerialized]
	public GameObject[] visualCoalPrefabs;

	private GrabHandlerItem grabHandler;

	private ItemBase item;

	private VRTK_TwoHandedPoleGrab vrGrab;

	private RaycastHit[] hits = new RaycastHit[6];

	private LayerMask shovelCoalPileLayerMask;

	private Collider shovelTip;

	private ShovelAudio shovelAudio;

	private GameObject[] loadedCoalVisuals;

	private GameObject loadedCoalVisual;

	private Collider lastTouchedPile;

	private Rigidbody lastTouchedPileRb;

	private Vector3 shovelEndPosition = new Vector3(0.015f, 0.03f, 0.38f);

	private ConfigurableJoint joint;

	private float lastTimeInteracted;

	private bool isVR;

	private float _coalMassCapacity;

	private float _coalMassLoaded;

	private Transform visualAnchor;

	public bool IsLoaded => coalMassLoaded > 0f;

	private float coalMassCapacity
	{
		get
		{
			return _coalMassCapacity;
		}
		set
		{
			_coalMassCapacity = value;
		}
	}

	private float coalMassLoaded
	{
		get
		{
			return _coalMassLoaded;
		}
		set
		{
			_coalMassLoaded = value;
		}
	}

	public Transform InteractionPoint => visualAnchor;

	private void Start()
	{
		isVR = VRManager.IsVREnabled();
		if (!isVR)
		{
			grabHandler = GetComponent<GrabHandlerItem>();
			if (grabHandler == null)
			{
				Debug.LogError("Couldn't extract ItemBase. Deleting this script!", this);
				UnityEngine.Object.Destroy(this);
				return;
			}
		}
		else
		{
			vrGrab = GetComponent<VRTK_TwoHandedPoleGrab>();
			if (vrGrab != null)
			{
				vrGrab.ToggleHeaviness(isHeavy: false);
			}
			joint = base.gameObject.AddComponent<ConfigurableJoint>();
			DisableJointVR();
		}
		item = GetComponent<ItemBase>();
		if (item == null)
		{
			Debug.LogError("Couldn't extract ItemBase. Deleting this script!", this);
			UnityEngine.Object.Destroy(this);
			return;
		}
		visualAnchor = base.transform.Find("[visual coal anchor]");
		if (visualAnchor != null)
		{
			shovelEndPosition = visualAnchor.localPosition;
		}
		else
		{
			visualAnchor = new GameObject("[visual coal anchor]").transform;
			Debug.LogError("Create a gameObject for coal visual anchor under this script with the name [visual coal anchor]", this);
			visualAnchor.SetParent(base.transform);
			visualAnchor.localPosition = shovelEndPosition;
		}
		loadedCoalVisuals = new GameObject[visualCoalPrefabs.Length];
		for (int i = 0; i < loadedCoalVisuals.Length; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(visualCoalPrefabs[i], item.transform);
			gameObject.transform.localPosition = shovelEndPosition;
			gameObject.transform.localRotation = Quaternion.Euler(new Vector3(-15f, 0f, 0f));
			gameObject.SetActive(value: false);
			loadedCoalVisuals[i] = gameObject;
		}
		if (loadedCoalVisuals.Length != 0)
		{
			loadedCoalVisual = loadedCoalVisuals[loadedCoalVisuals.Length - 1];
		}
		else
		{
			Debug.LogError("Shovel requires at least 1 visualCoalPrefab");
		}
		shovelCoalPileLayerMask = LayerMask.GetMask("Train_Interior");
		shovelTip = GetComponent<Shovel>().shovelTip;
		shovelAudio = GetComponent<ShovelAudio>();
		item.Ungrabbed += OnUngrab;
	}

	private void Update()
	{
		if (isVR && item.IsGrabbed())
		{
			OnShovelUsed();
			if (lastTouchedPile != null)
			{
				EnableJointVR(lastTouchedPileRb);
			}
			else
			{
				DisableJointVR();
			}
		}
	}

	private void DisableJointVR()
	{
		joint.connectedBody = null;
		joint.xMotion = ConfigurableJointMotion.Free;
		joint.yMotion = ConfigurableJointMotion.Free;
		joint.zMotion = ConfigurableJointMotion.Free;
		joint.angularXMotion = ConfigurableJointMotion.Free;
		joint.angularYMotion = ConfigurableJointMotion.Free;
		joint.angularZMotion = ConfigurableJointMotion.Free;
	}

	private void EnableJointVR(Rigidbody other)
	{
		if (other == null)
		{
			DisableJointVR();
			return;
		}
		joint.xMotion = ConfigurableJointMotion.Free;
		joint.yMotion = ConfigurableJointMotion.Locked;
		joint.zMotion = ConfigurableJointMotion.Locked;
		joint.angularXMotion = ConfigurableJointMotion.Limited;
		joint.angularYMotion = ConfigurableJointMotion.Limited;
		joint.angularZMotion = ConfigurableJointMotion.Limited;
		SoftJointLimitSpring softJointLimitSpring = new SoftJointLimitSpring
		{
			spring = 400f,
			damper = 50f
		};
		SoftJointLimit softJointLimit = new SoftJointLimit
		{
			limit = 177f
		};
		SoftJointLimit lowAngularXLimit = new SoftJointLimit
		{
			limit = -177f
		};
		joint.angularXLimitSpring = softJointLimitSpring;
		joint.angularYZLimitSpring = softJointLimitSpring;
		joint.lowAngularXLimit = lowAngularXLimit;
		joint.highAngularXLimit = softJointLimit;
		joint.angularYLimit = softJointLimit;
		joint.angularZLimit = softJointLimit;
		joint.anchor = base.transform.InverseTransformPoint(shovelTip.transform.position);
		joint.axis = base.transform.InverseTransformDirection(shovelTip.transform.right);
		joint.connectedBody = other;
		joint.autoConfigureConnectedAnchor = true;
		joint.connectedBody = other;
		joint.autoConfigureConnectedAnchor = true;
	}

	private bool TryFindValidDestinationFirebox(GameObject gameObj, out FireboxSimController fireboxController)
	{
		if (TryFindFireboxController(gameObj, out fireboxController) && IsFireboxDoorOpen(fireboxController))
		{
			return fireboxController.SpaceForCoal() > 0f;
		}
		return false;
	}

	private bool TryFindFireboxController(GameObject gameObj, out FireboxSimController fireboxSimController)
	{
		fireboxSimController = null;
		Component component = gameObj.GetComponent<NonPhysicsCoalTarget>();
		if (component == null)
		{
			component = gameObj.GetComponent<Fire>();
		}
		if (component == null)
		{
			return false;
		}
		TrainCar trainCar = TrainCar.Resolve(component.gameObject);
		if (trainCar == null)
		{
			return false;
		}
		if (!trainCar.TryGetComponent<SimController>(out var component2))
		{
			return false;
		}
		fireboxSimController = component2.firebox;
		return fireboxSimController != null;
	}

	private bool IsFireboxDoorOpen(FireboxSimController fireboxController)
	{
		float num = (isVR ? 0.25f : 0.6f);
		return fireboxController.FireboxDoorOpening >= num;
	}

	private bool ShowCoalPileInteractionPrompt(ICoalPile coalPile)
	{
		InteractionTextControllerNonVr instance = SingletonBehaviour<InteractionTextControllerNonVr>.Instance;
		InteractionInfoType interactionInfoType = InteractionInfoType.Cleared;
		if (coalPile.CoalAvailable() <= 0f)
		{
			interactionInfoType = InteractionInfoType.ShovelCoalPileEmpty;
		}
		else if (coalMassLoaded < ShovelCapacityForPile(coalPile))
		{
			interactionInfoType = InteractionInfoType.ShovelLoadCoal;
		}
		else if (coalMassLoaded > 0f && coalPile.SpaceForCoal() > 0f)
		{
			interactionInfoType = InteractionInfoType.ShovelUnloadCoal;
		}
		else if (coalMassLoaded > 0f)
		{
			interactionInfoType = InteractionInfoType.ShovelTargetFull;
		}
		if (interactionInfoType != InteractionInfoType.Cleared)
		{
			instance.DisplayText(interactionInfoType);
			return true;
		}
		return false;
	}

	private bool ShowFireboxInteractionPrompt(FireboxSimController fireboxController)
	{
		if (!IsFireboxDoorOpen(fireboxController))
		{
			return false;
		}
		InteractionTextControllerNonVr instance = SingletonBehaviour<InteractionTextControllerNonVr>.Instance;
		InteractionInfoType interactionInfoType = InteractionInfoType.Cleared;
		if (coalMassLoaded > 0f && fireboxController.SpaceForCoal() > 0f)
		{
			interactionInfoType = InteractionInfoType.ShovelUnloadCoal;
		}
		else if (coalMassLoaded > 0f)
		{
			interactionInfoType = InteractionInfoType.ShovelTargetFull;
		}
		if (interactionInfoType != InteractionInfoType.Cleared)
		{
			instance.DisplayText(interactionInfoType);
			return true;
		}
		return false;
	}

	private void OnUngrab(ControlImplBase _)
	{
		if (isVR)
		{
			VRTK_InteractableObject_DV component = GetComponent<VRTK_InteractableObject_DV>();
			if (!(component != null) || !component.IsGrabbed())
			{
				DisableJointVR();
			}
		}
	}

	private void OnShovelUsed()
	{
		int num = ScanHits();
		if (num == 0)
		{
			lastTouchedPile = null;
			lastTouchedPileRb = null;
			return;
		}
		if (lastTouchedPile != null && isVR)
		{
			for (int i = 0; i < num; i++)
			{
				if (hits[i].collider == lastTouchedPile)
				{
					return;
				}
			}
		}
		for (int j = 0; j < num; j++)
		{
			Collider collider = hits[j].collider;
			ShovelCoalPile component = collider.GetComponent<ShovelCoalPile>();
			if (component != null)
			{
				if (Time.time - lastTimeInteracted > 0.5f)
				{
					InteractWithCoalPile(component);
				}
				lastTouchedPile = collider;
				lastTouchedPileRb = collider.GetComponentInParent<Rigidbody>();
				return;
			}
			if (coalMassLoaded > 0f && TryFindValidDestinationFirebox(collider.gameObject, out var fireboxController) && Time.time - lastTimeInteracted > 0.5f)
			{
				UnloadCoal(fireboxController);
				lastTouchedPile = collider;
				return;
			}
		}
		lastTouchedPile = null;
		lastTouchedPileRb = null;
	}

	private float ShovelCapacityForPile(ICoalPile coalPile)
	{
		return (float)shovelChunksCapacity * coalPile.CoalChunkMass();
	}

	private void InteractWithCoalPile(ICoalPile coalPile)
	{
		if (coalMassLoaded < ShovelCapacityForPile(coalPile) && coalPile.CoalAvailable() > 0f)
		{
			LoadCoal(coalPile);
		}
		else if (coalMassLoaded > 0f && coalPile.SpaceForCoal() > 0f)
		{
			UnloadCoal(coalPile);
		}
	}

	private bool UpdateLoadedCoal()
	{
		if (coalMassLoaded == 0f)
		{
			if (loadedCoalVisual.activeSelf)
			{
				loadedCoalVisual.SetActive(value: false);
				if (isVR && vrGrab != null)
				{
					vrGrab.ToggleHeaviness(isHeavy: false);
				}
				return true;
			}
		}
		else
		{
			int num = Mathf.CeilToInt(coalMassLoaded / coalMassCapacity * (float)loadedCoalVisuals.Length) - 1;
			if (!loadedCoalVisual.activeSelf || loadedCoalVisual != loadedCoalVisuals[num])
			{
				if (loadedCoalVisual.activeSelf)
				{
					loadedCoalVisual.SetActive(value: false);
				}
				loadedCoalVisual = loadedCoalVisuals[num];
				loadedCoalVisual.SetActive(value: true);
				if (isVR && vrGrab != null)
				{
					vrGrab.ToggleHeaviness(isHeavy: true);
				}
				return true;
			}
		}
		return false;
	}

	private void LoadCoal(ICoalPile coalPile)
	{
		coalMassCapacity = ShovelCapacityForPile(coalPile);
		float coalAmount = coalMassCapacity - coalMassLoaded;
		float num = coalPile.TryRemoveCoal(coalAmount);
		if (!(num <= 0f))
		{
			shovelAudio.OnCoalSpawned(loadedCoalVisual.transform, staticSpeed: true);
			coalMassLoaded += num;
			UpdateLoadedCoal();
			lastTimeInteracted = Time.time;
		}
	}

	private void UnloadCoal(ICoalPile coalPile)
	{
		float num = coalPile.TryAddCoal(coalMassLoaded);
		if (!(num <= 0f))
		{
			shovelAudio.OnCoalDropped(loadedCoalVisual.transform);
			coalMassLoaded -= num;
			UpdateLoadedCoal();
			lastTimeInteracted = Time.time;
		}
	}

	private void UnloadCoal(FireboxSimController fireboxController)
	{
		float num = Mathf.Min(coalMassLoaded, fireboxController.SpaceForCoal());
		if (!(num <= 0f))
		{
			shovelAudio.OnCoalDropped(loadedCoalVisual.transform);
			fireboxController.TransferCoal(num);
			coalMassLoaded -= num;
			UpdateLoadedCoal();
		}
	}

	private int ScanHits()
	{
		if (!isVR)
		{
			Grabber grabber = grabHandler.GetGrabber();
			if (grabber == null)
			{
				return 0;
			}
			return Physics.SphereCastNonAlloc(grabber.Cursor.GetRay(), 0.005f, hits, (coalMassLoaded == 0f) ? 2f : 2.5f, shovelCoalPileLayerMask, QueryTriggerInteraction.Collide);
		}
		return Physics.SphereCastNonAlloc(new Ray(shovelTip.transform.position, Vector3.forward), 0.025f, hits, 0.001f, shovelCoalPileLayerMask, QueryTriggerInteraction.Collide);
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			item.Ungrabbed -= OnUngrab;
			item.Used -= OnShovelUsed;
			UnityEngine.Object.Destroy(loadedCoalVisual);
		}
	}

	public bool HandleHover(ItemUseTarget target)
	{
		if (target.TryGetComponent<ShovelCoalPile>(out var component))
		{
			ShowCoalPileInteractionPrompt(component);
			return true;
		}
		if (TryFindFireboxController(target.gameObject, out var fireboxSimController))
		{
			ShowFireboxInteractionPrompt(fireboxSimController);
			return true;
		}
		return false;
	}

	public bool HandleUse(ItemUseTarget target)
	{
		if (target == null)
		{
			return false;
		}
		if (target.TryGetComponent<ShovelCoalPile>(out var component))
		{
			InteractWithCoalPile(component);
			return true;
		}
		if (coalMassLoaded > 0f && TryFindValidDestinationFirebox(target.gameObject, out var fireboxController))
		{
			UnloadCoal(fireboxController);
			return true;
		}
		return false;
	}

	public bool IsHoverCompatible(ItemUseTarget target)
	{
		if ((bool)target.GetComponent<ShovelCoalPile>())
		{
			return true;
		}
		if (TryFindFireboxController(target.gameObject, out var _))
		{
			return true;
		}
		return false;
	}

	public bool IsUseCompatible(ItemUseTarget target)
	{
		if ((bool)target.GetComponent<ShovelCoalPile>())
		{
			return true;
		}
		if (coalMassLoaded > 0f && TryFindValidDestinationFirebox(target.gameObject, out var _))
		{
			return true;
		}
		return false;
	}

	public (Vector3 pos, Quaternion rot) TargetPoint(ItemUseTarget target)
	{
		Transform transform = target.transform.Find("[animation_pose_target]");
		if ((bool)transform)
		{
			if (TryFindFireboxController(target.gameObject, out var _))
			{
				return (pos: Vector3.Lerp(transform.position, SingletonBehaviour<ItemPositionController>.Instance.itemAnchor.position, 0.5f), rot: Quaternion.Slerp(transform.rotation, visualAnchor.rotation, 0.95f));
			}
			return (pos: transform.position, rot: Quaternion.Slerp(transform.rotation, visualAnchor.rotation, 0.6f));
		}
		return (pos: target.transform.position, rot: target.transform.rotation);
	}
}
