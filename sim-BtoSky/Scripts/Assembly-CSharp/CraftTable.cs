using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization;

public class CraftTable : Furniture
{
	[SerializeField]
	private CinemachineCamera craftCam;

	[SerializeField]
	private GameObject rocketMount;

	private Rocket mountedRocket;

	[Header("WaterRocketMockup")]
	[SerializeField]
	private GameObject rocket;

	[SerializeField]
	private GameObject rocketBody;

	[SerializeField]
	private GameObject rocketParticle;

	[SerializeField]
	private GameObject rocketHead;

	[SerializeField]
	private GameObject rocketNozzle;

	[SerializeField]
	private GameObject rocketMotor;

	[SerializeField]
	private GameObject wingLineGizmoPrefab;

	[SerializeField]
	private GameObject transformGizmo;

	private bool isUsing;

	protected LocalizedString fixText { get; } = new LocalizedString("MyTable", "interaction-fix");

	public override string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				if (!canGrab)
				{
					if (FirstPersonController.S.itemOnHand != null)
					{
						if (FirstPersonController.S.itemOnHand.TryGetComponent<Rench>(out var _))
						{
							return base.disassembleText.GetLocalizedString();
						}
						if (FirstPersonController.S.itemOnHand.TryGetComponent<CrashedRocketBox>(out var _))
						{
							return fixText.GetLocalizedString();
						}
					}
					if (!usable)
					{
						return "";
					}
					return interactionText.GetLocalizedString();
				}
				return base.grabText.GetLocalizedString();
			}
			return "Read";
		}
	}

	public static event Action OnTryUseCraftingTable;

	public static event Action OnSolidFuelMotorInstalled;

	private void Start()
	{
		CraftingUI.OnOffAllGizmos -= CraftingUI_OnOffAllGizmos;
		CraftingUI.OnOffAllGizmos += CraftingUI_OnOffAllGizmos;
		CraftingUI.OnWingConnectBtn -= CraftingUI_OnWingConnectBtn;
		CraftingUI.OnWingConnectBtn += CraftingUI_OnWingConnectBtn;
		CraftingUI.OnCpvisibleChanged -= CraftingUI_OnCpvisibleChanged;
		CraftingUI.OnCpvisibleChanged += CraftingUI_OnCpvisibleChanged;
		GameManager.S.OnPartInstallBtnPressed -= Gamanager_OnPartInstallBtnPressed;
		GameManager.S.OnPartInstallBtnPressed += Gamanager_OnPartInstallBtnPressed;
		GameManager.S.OnPartInstallBtnPressedCustomMotor -= S_OnPartInstallBtnPressedCustomMotor;
		GameManager.S.OnPartInstallBtnPressedCustomMotor += S_OnPartInstallBtnPressedCustomMotor;
		GameManager.S.OnCraftingDone -= GameManager_OnCraftingDone;
		GameManager.S.OnCraftingDone += GameManager_OnCraftingDone;
		CraftingUI.OnClearWings -= CraftingUI_OnClearWings;
		CraftingUI.OnClearWings += CraftingUI_OnClearWings;
		CraftingUI.OnUndoWing -= CraftingUI_OnUndoWing;
		CraftingUI.OnUndoWing += CraftingUI_OnUndoWing;
		CraftingUI.OnTransformGizmoVisibleChanged -= CraftingUI_OnTransformGizmoVisibleChanged;
		CraftingUI.OnTransformGizmoVisibleChanged += CraftingUI_OnTransformGizmoVisibleChanged;
	}

	private void CraftingUI_OnOffAllGizmos()
	{
		if (!isUsing)
		{
			return;
		}
		if (mountedRocket != null)
		{
			foreach (RocketWing wing in mountedRocket.wings)
			{
				wing.gizmos[0].SetActive(value: false);
			}
			return;
		}
		Debug.Log("Empty");
	}

	private void CraftingUI_OnWingConnectBtn()
	{
		if (!isUsing)
		{
			return;
		}
		if (mountedRocket != null)
		{
			foreach (RocketWing wing in mountedRocket.wings)
			{
				wing.gizmos[0].SetActive(value: true);
			}
			return;
		}
		Debug.Log("Empty");
	}

	private void CraftingUI_OnTransformGizmoVisibleChanged(bool obj)
	{
		if (isUsing)
		{
			transformGizmo.SetActive(obj);
		}
	}

	private void CraftingUI_OnCpvisibleChanged(bool obj)
	{
		if (mountedRocket != null)
		{
			mountedRocket.cp.gameObject.SetActive(obj);
			mountedRocket.cm.gameObject.SetActive(obj);
		}
	}

	private void S_OnPartInstallBtnPressedCustomMotor(string obj)
	{
		if (isUsing)
		{
			Rocket obj2 = mountedRocket;
			RocketMotor component = obj2.rocketMotor.GetComponent<RocketMotor>();
			if (component.type == RocketType.Gunpowder)
			{
				float newMass = ES3.Load("Mass_" + obj, 0f);
				float newThrustpow = ES3.Load("Power_" + obj, 0f);
				float newDuration = ES3.Load("Duration_" + obj, 0f);
				int proIndex = ES3.Load("ProIndex_" + obj, 0);
				int tubeIndex = ES3.Load("TubeIndex_" + obj, 0);
				Material proMat = ES3.Load("ProMat_" + obj, component.currentPro.sharedMaterial);
				AnimationCurve newCurve = ES3.Load("Curve_" + obj, component.powerCurve);
				component.InitCustomMotor(obj, newMass, newThrustpow, newDuration, newCurve, proIndex, tubeIndex, proMat);
			}
			obj2.UpdateCenterOfMass();
			AudioManager.S.PlaySFX(AudioManager.S.rocketPartsInstalled);
		}
	}

	private void CraftingUI_OnUndoWing()
	{
		if (isUsing)
		{
			UndoWing();
		}
	}

	private void CraftingUI_OnClearWings()
	{
		if (isUsing)
		{
			ClearWings();
		}
	}

	private void OnDestroy()
	{
		CraftingUI.OnOffAllGizmos -= CraftingUI_OnOffAllGizmos;
		CraftingUI.OnWingConnectBtn -= CraftingUI_OnWingConnectBtn;
		CraftingUI.OnTransformGizmoVisibleChanged -= CraftingUI_OnTransformGizmoVisibleChanged;
		GameManager.S.OnPartInstallBtnPressed -= Gamanager_OnPartInstallBtnPressed;
		GameManager.S.OnCraftingDone -= GameManager_OnCraftingDone;
		CraftingUI.OnClearWings -= CraftingUI_OnClearWings;
		CraftingUI.OnUndoWing -= CraftingUI_OnUndoWing;
		CraftingUI.OnCpvisibleChanged -= CraftingUI_OnCpvisibleChanged;
		GameManager.S.OnPartInstallBtnPressedCustomMotor -= S_OnPartInstallBtnPressedCustomMotor;
	}

	private void GameManager_OnCraftingDone(object sender, EventArgs e)
	{
		if (!isUsing)
		{
			return;
		}
		UnityEngine.Object.Destroy(GameManager.S.player.GetComponent<CraftingController>());
		MeshColliderPos componentInChildren = mountedRocket.rocketBody.GetComponentInChildren<MeshColliderPos>();
		if (componentInChildren != null)
		{
			MeshCollider componentInChildren2 = componentInChildren.GetComponentInChildren<MeshCollider>();
			if (componentInChildren2 != null)
			{
				UnityEngine.Object.Destroy(componentInChildren2);
				mountedRocket.body.GetComponentInChildren<Collider>().enabled = true;
			}
		}
		foreach (RocketWing wing in mountedRocket.wings)
		{
			wing.gizmos[0].SetActive(value: false);
		}
		mountedRocket.Interact();
		mountedRocket = null;
		craftCam.Priority = 0;
		GameManager.S.player.canControl = true;
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Player");
		Cursor.visible = false;
		isUsing = false;
		rocketMount.SetActive(value: false);
	}

	private void Gamanager_OnPartInstallBtnPressed(object sender, GameManager.OnPartInstallBtnPressedArg e)
	{
		if (!isUsing)
		{
			return;
		}
		if (e.partType == 0f)
		{
			GameObject gameObject;
			if (mountedRocket.rocketHead != null)
			{
				mountedRocket.rocketHead.GetComponent<RocketAttachment>().OnDisassembled();
				gameObject = UnityEngine.Object.Instantiate(e.part, mountedRocket.rocketHeadPos.transform);
			}
			else
			{
				gameObject = UnityEngine.Object.Instantiate(e.part, mountedRocket.rocketHeadPos.transform);
			}
			mountedRocket.rocketHead = gameObject;
			mountedRocket.head = gameObject.GetComponent<RocketHead>();
			if (mountedRocket.head.gizmos != null)
			{
				GameObject[] gizmos = mountedRocket.head.gizmos;
				for (int i = 0; i < gizmos.Length; i++)
				{
					gizmos[i].SetActive(value: true);
				}
			}
		}
		else if (e.partType == 1f)
		{
			GameObject gameObject2;
			if (mountedRocket.rocketBody != null)
			{
				mountedRocket.rocketBody.GetComponent<RocketAttachment>().OnDisassembled();
				gameObject2 = UnityEngine.Object.Instantiate(e.part, mountedRocket.rocketVisualPos.transform);
			}
			else
			{
				gameObject2 = UnityEngine.Object.Instantiate(e.part, mountedRocket.rocketVisualPos.transform);
			}
			if (gameObject2.GetComponent<RocketBody>().type == RocketType.Water)
			{
				gameObject2.GetComponent<RocketBody>().liquid.material = mountedRocket.rocketMotor.GetComponent<RocketMotor>().liquidMaterial;
			}
			if (mountedRocket.rocketWing.Count > 0)
			{
				foreach (GameObject item in mountedRocket.rocketWing)
				{
					item.GetComponentInChildren<RocketWing>().OnDisassembled();
					UnityEngine.Object.Destroy(item);
				}
				mountedRocket.rocketWing.Clear();
				mountedRocket.wings.Clear();
			}
			mountedRocket.rocketBody = gameObject2;
			mountedRocket.body = gameObject2.GetComponent<RocketBody>();
			if (mountedRocket.body.gizmos != null)
			{
				GameObject[] gizmos = mountedRocket.body.gizmos;
				for (int i = 0; i < gizmos.Length; i++)
				{
					gizmos[i].SetActive(value: true);
				}
			}
			ReplaceColliderWithMeshCollider(mountedRocket);
		}
		else if (e.partType != 2f)
		{
			if (e.partType == 3f)
			{
				GameObject gameObject3;
				if (mountedRocket.rocketMotor != null)
				{
					mountedRocket.rocketMotor.GetComponent<RocketAttachment>().OnDisassembled();
					gameObject3 = UnityEngine.Object.Instantiate(e.part, mountedRocket.motorPos.transform);
					if (gameObject3.GetComponent<Rigidbody>() != null)
					{
						UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
					}
				}
				else
				{
					gameObject3 = UnityEngine.Object.Instantiate(e.part, mountedRocket.rocketVisualPos.transform);
				}
				if (gameObject3.GetComponent<RocketMotor>().type == RocketType.Water)
				{
					mountedRocket.rocketBody.GetComponent<RocketBody>().liquid.material = gameObject3.GetComponent<RocketMotor>().liquidMaterial;
				}
				else if (gameObject3.GetComponent<RocketMotor>().type == RocketType.Gunpowder)
				{
					CraftTable.OnSolidFuelMotorInstalled?.Invoke();
				}
				mountedRocket.rocketMotor = gameObject3;
			}
			else if (e.partType == 4f)
			{
				GameObject gameObject4;
				if (mountedRocket.rocketNozzle != null)
				{
					mountedRocket.rocketNozzle.GetComponent<RocketAttachment>().OnDisassembled();
					gameObject4 = UnityEngine.Object.Instantiate(e.part, mountedRocket.motorPos);
				}
				else
				{
					gameObject4 = UnityEngine.Object.Instantiate(e.part, mountedRocket.motorPos);
				}
				mountedRocket.rocketNozzle = gameObject4;
			}
			else
			{
				RocketChip component = e.part.GetComponent<RocketChip>();
				if (component.type == RocketChip.ChipType.Parachute)
				{
					UnityEngine.Object.Instantiate(e.part, mountedRocket.rocketHeadPos);
				}
				else if (component.type == RocketChip.ChipType.Camera)
				{
					UnityEngine.Object.Instantiate(e.part, mountedRocket.camPos);
				}
			}
		}
		if (e.partType != 2f)
		{
			AudioManager.S.PlaySFX(AudioManager.S.rocketPartsInstalled);
		}
		mountedRocket.StartCoroutine(mountedRocket.DelayedCalculateCP());
	}

	public void ClearWings()
	{
		if (!isUsing)
		{
			return;
		}
		if (mountedRocket.rocketWing.Count > 0)
		{
			foreach (GameObject item in mountedRocket.rocketWing)
			{
				item.GetComponentInChildren<RocketWing>().OnDisassembled();
				UnityEngine.Object.Destroy(item);
			}
			mountedRocket.rocketWing.Clear();
			mountedRocket.wings.Clear();
		}
		mountedRocket.wingControlModuleCompo.ClearWings();
		mountedRocket.StartCoroutine(mountedRocket.DelayedCalculateCP());
	}

	public void UndoWing()
	{
		if (isUsing)
		{
			if (mountedRocket.rocketWing.Count > 0)
			{
				GameObject obj = mountedRocket.rocketWing[mountedRocket.rocketWing.Count - 1];
				mountedRocket.rocketWing.RemoveAt(mountedRocket.rocketWing.Count - 1);
				mountedRocket.wings.RemoveAt(mountedRocket.wings.Count - 1);
				obj.GetComponentInChildren<RocketWing>().OnDisassembled();
				UnityEngine.Object.Destroy(obj);
			}
			mountedRocket.StartCoroutine(mountedRocket.DelayedCalculateCP());
		}
	}

	private void ReplaceColliderWithMeshCollider(Rocket mountedRocket)
	{
		if (!mountedRocket.rocketBody.scene.IsValid())
		{
			Debug.LogError("mountedRocket is a prefab asset, not a scene instance.");
			return;
		}
		mountedRocket.head.GetComponentInChildren<Collider>().enabled = true;
		mountedRocket.rocketNozzle.GetComponentInChildren<Collider>().enabled = true;
		mountedRocket.rocketBody.GetComponent<Collider>().enabled = true;
		MeshColliderPos componentInChildren = mountedRocket.rocketBody.gameObject.GetComponentInChildren<MeshColliderPos>();
		if (componentInChildren != null)
		{
			MeshFilter component = componentInChildren.GetComponent<MeshFilter>();
			component.gameObject.AddComponent<MeshCollider>().sharedMesh = component.sharedMesh;
			mountedRocket.rocketBody.GetComponent<Collider>().enabled = false;
		}
	}

	public override void Interact()
	{
		base.Interact();
		FirstPersonController player = GameManager.S.player;
		if (player.itemOnHand != null)
		{
			CrashedRocketBox component2;
			if (player.itemOnHand.TryGetComponent<Rocket>(out var component))
			{
				rocketMount.SetActive(value: true);
				mountedRocket = component;
				component.currentHealth = component.maxHealth;
				component.transform.parent = rocketMount.transform;
				component.transform.localPosition = Vector3.zero;
				component.transform.localRotation = Quaternion.identity;
				component.transform.localPosition = -component.rocketVisualPos.localPosition;
				player.itemOnHand = null;
				component.UpdateCenterOfMass();
				component.CalculateTotalCP();
				CraftingController craftingController = GameManager.S.player.AddComponent<CraftingController>();
				craftingController.rocket = rocketMount;
				craftingController.wingLineGizmoPrefab = wingLineGizmoPrefab;
				craftingController.transformGizmo = transformGizmo;
				Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
				Cursor.visible = true;
				GameManager.S.InteractingWithCraftingTable(component);
				craftCam.Priority = 2;
				GameManager.S.player.canControl = false;
				AudioManager.S.PlaySFX(AudioManager.S.craftingTableInteract);
				rocketMount.transform.localRotation = Quaternion.Euler(-90f, 180f, 0f);
				ReplaceColliderWithMeshCollider(mountedRocket);
				isUsing = true;
			}
			else if (player.itemOnHand.TryGetComponent<CrashedRocketBox>(out component2))
			{
				rocketMount.SetActive(value: true);
				component2.rocket.gameObject.SetActive(value: true);
				mountedRocket = component2.rocket;
				mountedRocket.currentHealth = mountedRocket.maxHealth;
				component2.rocket.transform.parent = rocketMount.transform;
				component2.rocket.transform.localPosition = Vector3.zero;
				component2.rocket.transform.localRotation = Quaternion.identity;
				component2.rocket.transform.localPosition = -component2.rocket.rocketVisualPos.localPosition;
				player.itemOnHand = null;
				CraftingController craftingController2 = GameManager.S.player.AddComponent<CraftingController>();
				craftingController2.rocket = rocketMount;
				craftingController2.wingLineGizmoPrefab = wingLineGizmoPrefab;
				craftingController2.transformGizmo = transformGizmo;
				Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
				Cursor.visible = true;
				GameManager.S.InteractingWithCraftingTable(component2.rocket);
				craftCam.Priority = 2;
				GameManager.S.player.canControl = false;
				AudioManager.S.PlaySFX(AudioManager.S.craftingTableInteract);
				rocketMount.transform.localRotation = Quaternion.Euler(-90f, 180f, 0f);
				ReplaceColliderWithMeshCollider(mountedRocket);
				isUsing = true;
				UnityEngine.Object.Destroy(component2.gameObject);
			}
			else
			{
				CraftTable.OnTryUseCraftingTable?.Invoke();
				AudioManager.S.PlaySFX(AudioManager.S.doorLocked);
			}
		}
		else
		{
			CraftTable.OnTryUseCraftingTable?.Invoke();
			AudioManager.S.PlaySFX(AudioManager.S.doorLocked);
		}
	}

	private IEnumerator OpenNewRocketBox()
	{
		Debug.Log("Box Opened");
		GameObject rocketMain = UnityEngine.Object.Instantiate(rocket, base.gameObject.transform.position, base.transform.rotation);
		Debug.Log("rocketMain");
		Rocket rocketCompo = rocketMain.GetComponent<Rocket>();
		UnityEngine.Object.Instantiate(rocketBody, rocketCompo.rocketVisualPos);
		yield return null;
		UnityEngine.Object.Instantiate(rocketHead, rocketCompo.rocketHeadPos);
		if (rocketMotor != null)
		{
			UnityEngine.Object.Instantiate(rocketMotor, rocketCompo.motorPos);
		}
		UnityEngine.Object.Instantiate(rocketNozzle, rocketCompo.motorPos);
		yield return null;
		mountedRocket = rocketMain.GetComponent<Rocket>();
		mountedRocket.GetComponent<Rigidbody>().isKinematic = true;
		mountedRocket.transform.parent = rocketMount.transform;
		mountedRocket.transform.localPosition = Vector3.zero;
		mountedRocket.transform.localRotation = Quaternion.identity;
		mountedRocket.transform.localPosition = -mountedRocket.rocketVisualPos.localPosition;
		Collider[] componentsInChildren = mountedRocket.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = true;
		}
		MeshCollider componentInChildren = mountedRocket.rocketBody.GetComponentInChildren<MeshCollider>();
		if (componentInChildren != null)
		{
			componentInChildren.enabled = true;
			mountedRocket.rocketBody.GetComponentInChildren<CapsuleCollider>().enabled = false;
		}
		CraftingController craftingController = GameManager.S.player.AddComponent<CraftingController>();
		craftingController.rocket = rocketMount;
		craftingController.transformGizmo = transformGizmo;
		craftingController.wingLineGizmoPrefab = wingLineGizmoPrefab;
		Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
		Cursor.visible = true;
		GameManager.S.InteractingWithCraftingTable(mountedRocket);
		craftCam.Priority = 2;
		GameManager.S.player.canControl = false;
		AudioManager.S.PlaySFX(AudioManager.S.craftingTableInteract);
		rocketMount.transform.localRotation = Quaternion.Euler(-90f, 180f, 0f);
		isUsing = true;
	}
}
