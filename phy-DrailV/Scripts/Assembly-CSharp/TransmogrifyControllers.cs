using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.InventorySystem;
using DV.Util.EventWrapper;
using DV.Utils;
using DV.VFX;
using DV.VR;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class TransmogrifyControllers : MonoBehaviour
{
	public const string CONTROLLER_TOOLTIP_NAME = "[controller_tooltip]";

	public const string TELEGRAB_NAME = "[telegrab]";

	public const string TELEGRAB_BEAM = "TelegrabBeam";

	public static event_<SDK_BaseController.ControllerHand> ControllerReady;

	public static Renderer[] leftControllerRenderers;

	public static Renderer[] rightControllerRenderers;

	public static bool overrideControllersTransparent;

	private static Material[] leftOriginalMaterials;

	private static Material[] rightOriginalMaterials;

	private static Material[] leftTransparentMaterials;

	private static Material[] rightTransparentMaterials;

	private static readonly Dictionary<ControllerType_DV, string[]> unneededColliderNames = new Dictionary<ControllerType_DV, string[]>
	{
		{
			ControllerType_DV.ViveWand,
			new string[2] { "SideA", "SideB" }
		},
		{
			ControllerType_DV.Undefined,
			new string[2] { "SideA", "SideB" }
		},
		{
			ControllerType_DV.QuestTouch,
			new string[1] { "Ring" }
		},
		{
			ControllerType_DV.RiftTouch,
			new string[1] { "Ring" }
		},
		{
			ControllerType_DV.WMR,
			new string[1] { "Head" }
		},
		{
			ControllerType_DV.HPReverbG2,
			new string[1] { "Head" }
		},
		{
			ControllerType_DV.ValveIndex,
			new string[1] { "Strap" }
		}
	};

	public Material material;

	private GameObject leftControllerRoot;

	private GameObject rightControllerRoot;

	private readonly HashSet<GameObject> alreadyTransmogrified = new HashSet<GameObject>();

	private Coroutine removeHandsCoro;

	public static bool IsControllerReadyRight { get; private set; }

	public static bool IsControllerReadyLeft { get; private set; }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StaticReload()
	{
		ControllerReady = default(event_<SDK_BaseController.ControllerHand>);
		IsControllerReadyRight = false;
		IsControllerReadyLeft = false;
		leftControllerRenderers = null;
		rightControllerRenderers = null;
		leftOriginalMaterials = null;
		rightOriginalMaterials = null;
		leftTransparentMaterials = null;
		rightTransparentMaterials = null;
		overrideControllersTransparent = false;
	}

	private void Awake()
	{
		VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isQuitting)
		{
			IsControllerReadyLeft = (IsControllerReadyRight = false);
			ControllerReady = default(event_<SDK_BaseController.ControllerHand>);
			VRTK_SDKManager.instance?.RemoveBehaviourToToggleOnLoadedSetupChange(this);
		}
	}

	private void OnEnable()
	{
		leftControllerRoot = VRTK_DeviceFinder.GetControllerLeftHand(getActual: true);
		rightControllerRoot = VRTK_DeviceFinder.GetControllerRightHand(getActual: true);
		SetupController(leftControllerRoot);
		SetupController(rightControllerRoot);
	}

	private void SetupController(GameObject controllerRoot)
	{
		if ((bool)controllerRoot)
		{
			controllerRoot.GetComponent<VRTK_TrackedController>().ControllerModelAvailable += Transmogrify;
			if (!controllerRoot.GetComponent<VRTK_VelocityEstimator>())
			{
				controllerRoot.AddComponent<VRTK_VelocityEstimator_DV>();
			}
		}
	}

	private void OnDisable()
	{
		if ((bool)leftControllerRoot && (bool)rightControllerRoot)
		{
			VRTK_TrackedController component = leftControllerRoot.GetComponent<VRTK_TrackedController>();
			VRTK_TrackedController component2 = rightControllerRoot.GetComponent<VRTK_TrackedController>();
			component.ControllerModelAvailable -= Transmogrify;
			component2.ControllerModelAvailable -= Transmogrify;
		}
	}

	private void Transmogrify(object sender, VRTKTrackedControllerEventArgs e)
	{
		VRTK_TrackedController vRTK_TrackedController = (VRTK_TrackedController)sender;
		StartCoroutine(Transmogrify(vRTK_TrackedController.gameObject));
	}

	private IEnumerator Transmogrify(GameObject controllerRoot)
	{
		int attemptsLeft = 50;
		VRTK_ControllerReference controllerReference;
		do
		{
			yield return WaitFor.SecondsRealtime(0.5f);
			controllerReference = VRTK_ControllerReference.GetControllerReference(controllerRoot);
			attemptsLeft--;
		}
		while (controllerRoot != controllerReference.scriptAlias.transform.parent.gameObject && attemptsLeft > 0);
		ChangeMaterial(controllerReference);
		GameObject scriptAlias = controllerReference.scriptAlias;
		if (!alreadyTransmogrified.Contains(scriptAlias))
		{
			VRTK_InteractGrab component = scriptAlias.GetComponent<VRTK_InteractGrab>();
			SDK_BaseController.ControllerHand hand = controllerReference.hand;
			AddPipa(controllerReference, component);
			AddTelegrab(controllerReference);
			AlignBeamObjects(controllerRoot);
			AddControllerTooltip(component, hand);
			SDKSpecificTweaks(controllerReference);
			alreadyTransmogrified.Add(scriptAlias);
			if (hand == SDK_BaseController.ControllerHand.Right)
			{
				IsControllerReadyRight = true;
			}
			else
			{
				IsControllerReadyLeft = true;
			}
			ControllerReady.Invoke(controllerReference.hand);
		}
	}

	private void AddControllerTooltip(VRTK_InteractGrab grab, SDK_BaseController.ControllerHand hand)
	{
		GameObject obj = (GameObject)Object.Instantiate(Resources.Load("[controller_tooltip]", typeof(GameObject)));
		Transform pipaTransform = PipaUtils.PipaTransform(grab.gameObject);
		ControllerTooltip component = obj.GetComponent<ControllerTooltip>();
		component.Initialize(pipaTransform);
		bool flag = hand == SDK_BaseController.ControllerHand.Right;
		if (flag && VRTK_ControllerUtils_DV.ControllerTooltipRight == null)
		{
			VRTK_ControllerUtils_DV.ControllerTooltipRight = component;
		}
		else if (!flag && VRTK_ControllerUtils_DV.ControllerTooltipLeft == null)
		{
			VRTK_ControllerUtils_DV.ControllerTooltipLeft = component;
		}
	}

	public static void AlignBeamObjects(GameObject controllerRoot)
	{
		Transform transform = controllerRoot.GetComponentInChildren<TeleportPointerController>(includeInactive: true).transform;
		Transform transform2 = controllerRoot.GetComponentInChildren<TeleGrab>(includeInactive: true).transform;
		Transform transform3 = controllerRoot.GetComponentInChildren<VRTK_UIPointer>(includeInactive: true).transform;
		Transform transform4 = controllerRoot.GetComponentInChildren<VRTK_SDKTransformModify>().transform.Find("HandRoot/OrientationReference");
		if (!transform4)
		{
			Debug.LogError("Couldn't find Orientation Reference!", controllerRoot);
			return;
		}
		transform.rotation = transform4.rotation;
		transform.position = transform4.position;
		transform2.rotation = transform4.rotation;
		transform2.position = transform4.position;
		transform3.rotation = transform4.rotation;
		transform3.position = transform4.position;
	}

	public static void RefreshControllerMaterials()
	{
		int defaultLayer = LayerMask.NameToLayer("Default");
		int thirdCameraLayer = LayerMask.NameToLayer("Ignore Raycast");
		bool shouldBeTransparent = ((bool)InventoryViewVR.Instance && InventoryViewVR.Instance.BigInventoryOpen) || overrideControllersTransparent;
		if (IsControllerReadyLeft)
		{
			DoController(leftControllerRenderers, leftOriginalMaterials, leftTransparentMaterials);
		}
		if (IsControllerReadyRight)
		{
			DoController(rightControllerRenderers, rightOriginalMaterials, rightTransparentMaterials);
		}
		void DoController(Renderer[] renderers, Material[] materials, Material[] transparentMaterials)
		{
			for (int i = 0; i < renderers.Length; i++)
			{
				Renderer obj = renderers[i];
				obj.sharedMaterial = (shouldBeTransparent ? transparentMaterials[i] : materials[i]);
				obj.gameObject.layer = (shouldBeTransparent ? thirdCameraLayer : defaultLayer);
			}
		}
	}

	private void ChangeMaterial(VRTK_ControllerReference ctrlRef)
	{
		Renderer[] source = ((!ctrlRef.scriptAlias) ? ctrlRef.model.GetComponentsInChildren<Renderer>(includeInactive: true) : (from go in ctrlRef.scriptAlias.GetComponentsInChildren<SkinnedMeshRenderer>()
			select go.GetComponent<Renderer>()).ToArray());
		Material[] source2 = source.Select((Renderer r) => r.sharedMaterial).ToArray();
		Material[] array = source2.Select((Material m) => SingletonBehaviour<MaterialUtils>.Instance.MakeTransparentCopy(m)).ToArray();
		if (ctrlRef.hand == SDK_BaseController.ControllerHand.Left)
		{
			leftControllerRenderers = source;
			leftOriginalMaterials = source2;
			leftTransparentMaterials = array;
		}
		else if (ctrlRef.hand == SDK_BaseController.ControllerHand.Right)
		{
			rightControllerRenderers = source;
			rightOriginalMaterials = source2;
			rightTransparentMaterials = array;
		}
		RefreshControllerMaterials();
	}

	private void AddPipa(VRTK_ControllerReference ctrlRef, VRTK_InteractGrab grab)
	{
		GameObject obj = Object.Instantiate(Resources.Load<GameObject>("[controller_pipa]"));
		obj.SetLayersRecursive("Controller");
		obj.transform.SetParent(ctrlRef.scriptAlias.transform, worldPositionStays: false);
		Transform transform = obj.transform.Find("[pipa]");
		transform.SetParent(ctrlRef.scriptAlias.transform);
		Object.Destroy(obj);
		PipaUtils.AnchorData anchorData = PipaUtils.GetAnchorData(ctrlRef);
		transform.localPosition = anchorData.pipaOffset;
		transform.localRotation = anchorData.pipaRotation;
		GameObject obj2 = new GameObject("[pipa attach point]");
		obj2.transform.SetParent(transform);
		obj2.transform.localPosition = Vector3.zero;
		obj2.transform.localRotation = Quaternion.identity;
		Rigidbody rigidbody = obj2.gameObject.AddComponent<Rigidbody>();
		rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		rigidbody.isKinematic = true;
		grab.ForceControllerAttachPoint(rigidbody);
		transform.gameObject.AddComponent<ControllerPipa>().grab = grab;
		PipaUtils.InitializePipaObjectCache(grab.gameObject, transform, ctrlRef.hand == SDK_BaseController.ControllerHand.Right);
	}

	private void AddTelegrab(VRTK_ControllerReference ctrlRef)
	{
		Transform transform = new GameObject("[telegrab]").transform;
		transform.SetParent(ctrlRef.scriptAlias.transform, worldPositionStays: false);
		PipaUtils.AnchorData anchorData = PipaUtils.GetAnchorData(ctrlRef);
		transform.localPosition = anchorData.telegrabOffset;
		transform.localRotation = anchorData.telegrabRotation;
		TeleGrab teleGrab = transform.gameObject.AddComponent<TeleGrab>();
		transform.gameObject.AddComponent<TeleGrabVRTKInput>();
		teleGrab.layers = LayerMask.GetMask("Interactable", "World_Item", "Train_Interior", "Default", "Inventory");
		GameObject obj = Object.Instantiate(Resources.Load("TelegrabBeam", typeof(GameObject)) as GameObject, teleGrab.transform, worldPositionStays: true);
		obj.transform.localRotation = Quaternion.identity;
		obj.transform.localPosition = Vector3.zero;
		transform.gameObject.AddComponent<TelegrabInteractionHandler>();
	}

	public static void FinalizeInteractionColliders(Transform collidersContainer, VRTK_ControllerReference controllerReference)
	{
		RemoveUnneededColliders(collidersContainer, controllerReference);
		SetLayers(collidersContainer, controllerReference);
	}

	private static void SetLayers(Transform collidersContainer, VRTK_ControllerReference controllerReference)
	{
		if (controllerReference == null)
		{
			Debug.LogWarning("TransmogrifyControllers requires a valid VRTK_ControllerReference. Layers not set.");
			return;
		}
		if (!collidersContainer)
		{
			Debug.LogWarning("TransmogrifyControllers got null collidersContainer. Layers not set.", controllerReference.actual);
			return;
		}
		Collider[] componentsInChildren = collidersContainer.GetComponentsInChildren<Collider>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].gameObject.layer = LayerMask.NameToLayer("Controller");
		}
	}

	private static void RemoveUnneededColliders(Transform collidersContainer, VRTK_ControllerReference controllerReference)
	{
		if (controllerReference == null)
		{
			Debug.LogWarning("TransmogrifyControllers requires a valid VRTK_ControllerReference, to remove unneeded colliders.");
			return;
		}
		if (!collidersContainer)
		{
			Debug.LogWarning("TransmogrifyControllers got null collidersContainer. No colliders removed.", controllerReference.actual);
			return;
		}
		ControllerType_DV controllerTypeDV = controllerReference.GetControllerTypeDV();
		if (unneededColliderNames.TryGetValue(controllerTypeDV, out var value))
		{
			string[] array = value;
			foreach (string n in array)
			{
				Transform transform = collidersContainer.Find(n);
				if ((bool)transform)
				{
					Object.Destroy(transform.gameObject);
				}
			}
		}
		else
		{
			Debug.LogWarning($"Skipping removing controller colliders for unknown controller type '{controllerTypeDV}'", controllerReference.actual);
		}
	}

	private void SDKSpecificTweaks(VRTK_ControllerReference ctrlRef)
	{
		VRManager.SDK currentSDK = VRManager.GetCurrentSDK();
		switch (currentSDK)
		{
		case VRManager.SDK.Oculus:
			TransmogrifyController_OculusSDK(ctrlRef);
			break;
		default:
			Debug.LogError($"Unexpected SDK '{currentSDK}'");
			break;
		case VRManager.SDK.SteamVR:
			break;
		}
	}

	private void TransmogrifyController_OculusSDK(VRTK_ControllerReference ctrlRef)
	{
		AddControllerHider(ctrlRef);
		RemoveTaggedObjects(ctrlRef);
		if (removeHandsCoro == null)
		{
			removeHandsCoro = StartCoroutine(RemoveHandsAndChangeMaterial());
		}
	}

	private void AddControllerHider(VRTK_ControllerReference ctrlRef)
	{
		OculusDashSupport oculusDashSupport = GetComponent<OculusDashSupport>();
		if (!oculusDashSupport && VRTK_SDKManager.GetLoadedSDKSetup().name.ToLower().Contains("oculus"))
		{
			oculusDashSupport = base.gameObject.AddComponent<OculusDashSupport>();
		}
		if ((bool)oculusDashSupport)
		{
			oculusDashSupport.controllers.Add(ctrlRef);
		}
	}

	private void RemoveTaggedObjects(VRTK_ControllerReference ctrlRef)
	{
		OculusSDKRemoveTag[] componentsInChildren = OVRManager.instance.transform.Find("LocalAvatar").GetComponentsInChildren<OculusSDKRemoveTag>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Object.Destroy(componentsInChildren[i].gameObject);
		}
	}

	private IEnumerator RemoveHandsAndChangeMaterial()
	{
		Transform parent = OVRManager.instance.transform.Find("LocalAvatar");
		bool found = false;
		for (int attempts = 0; attempts < 100; attempts++)
		{
			if (found)
			{
				break;
			}
			yield return null;
			foreach (Transform item in parent)
			{
				if (item.name.StartsWith("hand_"))
				{
					found = true;
					item.gameObject.SetActive(value: false);
				}
			}
		}
		if (!found)
		{
			Debug.LogError("TransmogrifyControllers couldn't find LocalAvatar children", this);
		}
		else
		{
			Transform parent2 = OVRManager.instance.transform.Find("LocalAvatar/controller_left");
			Transform parent3 = OVRManager.instance.transform.Find("LocalAvatar/controller_right");
			ChangeMaterial_OculusSDK(parent2);
			ChangeMaterial_OculusSDK(parent3);
		}
		removeHandsCoro = null;
	}

	private void ChangeMaterial_OculusSDK(Transform parent)
	{
		Renderer[] componentsInChildren = parent.GetComponentsInChildren<Renderer>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].sharedMaterial = material;
		}
	}
}
