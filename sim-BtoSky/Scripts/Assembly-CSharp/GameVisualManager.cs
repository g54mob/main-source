using System;
using System.Collections.Generic;
using UnityEngine;

public class GameVisualManager : MonoBehaviour
{
	public static GameVisualManager S;

	[SerializeField]
	private Material canBulid;

	[SerializeField]
	private Material cannotBuild;

	[SerializeField]
	private GameObject waterRocketMount;

	[SerializeField]
	private GameObject solidFuelRocketMount;

	[SerializeField]
	private LayerMask collisionCheckMask;

	private GameObject mountBluePrint;

	private RocketAttachment rocketPart;

	private Material rocketMaterialSave;

	private Vector3 rocketMountPos;

	private GameObject bluePrint;

	private List<GameObject> bluePrintList = new List<GameObject>();

	private bool isGreen;

	private bool colorChanged;

	private void Awake()
	{
		if (S != null && S != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		S = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		GameManager.S.OnInstallCpuBluePrint += S_OnInstallCpuBluePrint;
		GameManager.S.OnDrawBulePrint += GameManager_OnDrawBluePrint;
		GameManager.S.OnDrawRocketMountBluePrint += S_OnDrawRocketMountBluePrint;
		GameManager.S.OnDeleteBluePrint += GameManager_OnDeleteBluePrint;
		GameManager.S.OnInstallBluePrint += GameManager_OnInstallBluePrint;
		GameManager.S.OnDrawWingBluePrint += GameManager_OnDrawWingBluePrint;
		GameManager.S.OnDrawCpuBluePrint += S_OnDrawCpuBluePrint;
		GameManager.S.OnInstallWingBluePrint += GameManager_OnInstallWingBluePrint;
		GameManager.S.OnInstallRocketMountBluePrint += Gm_OnInstallRocketMountBluePrint;
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
		GameManager.S.OnPaintTemp += S_OnPaintTemp;
		GameManager.S.OnPaintRocket += S_OnPaintRocket;
		GameManager.S.OnDeletePaintTemp += S_OnDeletePaintTemp;
		GameManager.S.OnDeleteWingBluePrint += S_OnDeleteWingBluePrint;
	}

	private void S_OnDeletePaintTemp()
	{
		if (rocketPart != null)
		{
			rocketPart.meshRenderer.material = rocketMaterialSave;
		}
		rocketPart = null;
		rocketMaterialSave = null;
	}

	private void S_OnPaintRocket()
	{
		rocketPart = null;
		rocketMaterialSave = null;
		FirstPersonController.S.ComsumeItem();
	}

	private void S_OnPaintTemp(RocketAttachment obj)
	{
		if (obj.meshRenderer == null)
		{
			return;
		}
		if (rocketPart != null)
		{
			if (rocketPart != obj)
			{
				rocketPart.meshRenderer.material = rocketMaterialSave;
				rocketPart = obj;
				rocketMaterialSave = rocketPart.meshRenderer.material;
			}
		}
		else
		{
			rocketPart = obj;
			rocketMaterialSave = rocketPart.meshRenderer.material;
		}
	}

	private void PauseUI_OnSaveAndQuit()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void OnDestroy()
	{
		GameManager.S.OnInstallCpuBluePrint -= S_OnInstallCpuBluePrint;
		GameManager.S.OnDrawCpuBluePrint -= S_OnDrawCpuBluePrint;
		GameManager.S.OnDeleteWingBluePrint -= S_OnDeleteWingBluePrint;
		GameManager.S.OnDrawBulePrint -= GameManager_OnDrawBluePrint;
		GameManager.S.OnDrawRocketMountBluePrint -= S_OnDrawRocketMountBluePrint;
		GameManager.S.OnDeleteBluePrint -= GameManager_OnDeleteBluePrint;
		GameManager.S.OnInstallBluePrint -= GameManager_OnInstallBluePrint;
		GameManager.S.OnDrawWingBluePrint -= GameManager_OnDrawWingBluePrint;
		GameManager.S.OnInstallWingBluePrint -= GameManager_OnInstallWingBluePrint;
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
		GameManager.S.OnInstallRocketMountBluePrint -= Gm_OnInstallRocketMountBluePrint;
		GameManager.S.OnPaintTemp -= S_OnPaintTemp;
		GameManager.S.OnPaintRocket -= S_OnPaintRocket;
		GameManager.S.OnDeletePaintTemp -= S_OnDeletePaintTemp;
	}

	private void S_OnDeleteWingBluePrint(object sender, EventArgs e)
	{
		if (bluePrintList == null || bluePrintList.Count <= 0)
		{
			return;
		}
		foreach (GameObject bluePrint in bluePrintList)
		{
			if (bluePrint != null)
			{
				UnityEngine.Object.Destroy(bluePrint);
			}
		}
		bluePrintList.Clear();
	}

	private void GameManager_OnInstallWingBluePrint(object sender, GameManager.OnInstallWingBluePrintArg e)
	{
		foreach (GameObject bluePrint in bluePrintList)
		{
			GameObject obj = UnityEngine.Object.Instantiate(e.wing, e.rocket);
			obj.transform.position = bluePrint.transform.position;
			obj.transform.rotation = bluePrint.transform.rotation;
			if (bluePrint != null)
			{
				UnityEngine.Object.Destroy(bluePrint);
			}
		}
		bluePrintList.Clear();
		GameManager.S.WingInstalled();
		AudioManager.S.PlaySFX(AudioManager.S.rocketPartsInstalled);
	}

	private void Gm_OnInstallRocketMountBluePrint()
	{
		GameObject gameObject = null;
		if (FirstPersonController.S.rocket.body.type == RocketType.Water)
		{
			gameObject = UnityEngine.Object.Instantiate(waterRocketMount, mountBluePrint.transform.position, mountBluePrint.transform.rotation);
		}
		else if (FirstPersonController.S.rocket.body.type == RocketType.Gunpowder)
		{
			gameObject = UnityEngine.Object.Instantiate(solidFuelRocketMount, mountBluePrint.transform.position, mountBluePrint.transform.rotation);
		}
		RocketMount component = gameObject.GetComponent<RocketMount>();
		if (gameObject.TryGetComponent<Rigidbody>(out var component2))
		{
			component2.linearVelocity = Vector3.zero;
			component2.angularVelocity = Vector3.zero;
			component2.isKinematic = true;
		}
		component.MountRocket();
		FirstPersonController.S.rocketOnHand = false;
		FirstPersonController.S.rocket = null;
		GameManager.S.DeleteBluePrint();
		AudioManager.S.PlaySFX(AudioManager.S.rocketPartsInstalled);
	}

	private void GameManager_OnInstallBluePrint(object sender, EventArgs e)
	{
		Collider[] componentsInChildren = UnityEngine.Object.Instantiate(GameManager.S.player.itemOnHand.GetComponent<Furniture>().furnitureGO, bluePrint.transform.position, bluePrint.transform.rotation).GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = true;
		}
		FirstPersonController.S.ComsumeItem();
		if (bluePrint != null)
		{
			UnityEngine.Object.Destroy(bluePrint);
		}
		AudioManager.S.PlaySFX(AudioManager.S.rocketPartsInstalled);
	}

	private void S_OnInstallCpuBluePrint(GameObject arg1, Transform arg2)
	{
		GameObject obj = UnityEngine.Object.Instantiate(arg1, arg2);
		obj.transform.position = bluePrint.transform.position;
		obj.transform.rotation = bluePrint.transform.rotation;
		if (bluePrint != null)
		{
			UnityEngine.Object.Destroy(bluePrint);
		}
		GameManager.S.CpuInstalled();
		AudioManager.S.PlaySFX(AudioManager.S.rocketPartsInstalled);
	}

	private void GameManager_OnDeleteBluePrint(object sender, EventArgs e)
	{
		if (bluePrint != null)
		{
			UnityEngine.Object.Destroy(bluePrint);
		}
		if (mountBluePrint != null)
		{
			UnityEngine.Object.Destroy(mountBluePrint);
		}
	}

	private void S_OnDrawCpuBluePrint(GameObject arg1, Vector3 arg2, Transform arg3)
	{
		isGreen = true;
		if (bluePrint == null)
		{
			bluePrint = UnityEngine.Object.Instantiate(arg1, arg2, arg3.rotation);
			UnityEngine.Object.Destroy(bluePrint.GetComponent<RocketChip>());
		}
		else
		{
			bluePrint.transform.position = arg2;
			bluePrint.transform.rotation = arg3.rotation;
		}
	}

	private void S_OnDrawRocketMountBluePrint(object sender, GameManager.OnDrawRocketMountBluePrintArg e)
	{
		if (e.canInstall != isGreen)
		{
			colorChanged = true;
			isGreen = e.canInstall;
		}
		if (bluePrint == null && mountBluePrint == null)
		{
			bluePrint = CloneVisualOnlyRecursive(e.rocket.gameObject);
			int siblingIndex = e.rocket.motorPos.GetSiblingIndex();
			if (e.rocket.body.type == RocketType.Water)
			{
				mountBluePrint = CloneVisualOnlyRecursive(waterRocketMount);
				rocketMountPos = waterRocketMount.GetComponent<RocketMount>().rocketMount.transform.localPosition;
			}
			else if (e.rocket.body.type == RocketType.Gunpowder)
			{
				mountBluePrint = CloneVisualOnlyRecursive(solidFuelRocketMount);
				rocketMountPos = solidFuelRocketMount.GetComponent<RocketMount>().rocketMount.transform.localPosition;
			}
			bluePrint.transform.parent = mountBluePrint.transform.GetChild(1);
			bluePrint.transform.localPosition = Vector3.zero;
			bluePrint.transform.localRotation = Quaternion.identity;
			Vector3 vector = bluePrint.transform.position - bluePrint.transform.GetChild(0).GetChild(siblingIndex).position;
			Debug.Log(vector);
			bluePrint.transform.position += vector;
			Vector3 forward = FirstPersonController.S.transform.position - mountBluePrint.transform.position;
			forward.y = 0f;
			mountBluePrint.transform.rotation = Quaternion.LookRotation(forward);
			MeshRenderer[] componentsInChildren = bluePrint.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] componentsInChildren2 = mountBluePrint.GetComponentsInChildren<MeshRenderer>();
			if (isGreen)
			{
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].material = canBulid;
				}
				for (int j = 0; j < componentsInChildren2.Length; j++)
				{
					componentsInChildren2[j].material = canBulid;
				}
			}
			else
			{
				for (int k = 0; k < componentsInChildren.Length; k++)
				{
					componentsInChildren[k].material = cannotBuild;
				}
				for (int l = 0; l < componentsInChildren2.Length; l++)
				{
					componentsInChildren2[l].material = canBulid;
				}
			}
			return;
		}
		mountBluePrint.transform.position = e.position;
		Vector3 forward2 = FirstPersonController.S.transform.position - mountBluePrint.transform.position;
		forward2.y = 0f;
		mountBluePrint.transform.rotation = Quaternion.LookRotation(forward2);
		if (!colorChanged)
		{
			return;
		}
		MeshRenderer[] componentsInChildren3 = bluePrint.GetComponentsInChildren<MeshRenderer>();
		MeshRenderer[] componentsInChildren4 = mountBluePrint.GetComponentsInChildren<MeshRenderer>();
		if (isGreen)
		{
			for (int m = 0; m < componentsInChildren3.Length; m++)
			{
				componentsInChildren3[m].material = canBulid;
			}
			for (int n = 0; n < componentsInChildren4.Length; n++)
			{
				componentsInChildren4[n].material = canBulid;
			}
		}
		else
		{
			for (int num = 0; num < componentsInChildren3.Length; num++)
			{
				componentsInChildren3[num].material = cannotBuild;
			}
			for (int num2 = 0; num2 < componentsInChildren4.Length; num2++)
			{
				componentsInChildren4[num2].material = canBulid;
			}
		}
		colorChanged = false;
	}

	private void GameManager_OnDrawBluePrint(object sender, GameManager.OnDrawBluePrintArg e)
	{
		if (e.canInstall != isGreen)
		{
			colorChanged = true;
			isGreen = e.canInstall;
		}
		if (bluePrint == null)
		{
			bluePrint = CloneVisualOnlyRecursive(e.furniture);
			if (Physics.CheckBox(e.position, e.size, bluePrint.transform.rotation, collisionCheckMask))
			{
				isGreen = false;
			}
			ApplyMaterial();
		}
		else
		{
			bluePrint.transform.position = e.position;
			if (Physics.CheckBox(e.position, e.size, bluePrint.transform.rotation, collisionCheckMask))
			{
				if (isGreen)
				{
					colorChanged = true;
				}
				isGreen = false;
			}
			if (colorChanged)
			{
				ApplyMaterial();
				colorChanged = false;
			}
		}
		bluePrint.transform.Rotate(Vector3.up, (float)e.tick * 15f);
	}

	private void ApplyMaterial()
	{
		if (bluePrint == null)
		{
			return;
		}
		MeshRenderer[] componentsInChildren = bluePrint.GetComponentsInChildren<MeshRenderer>();
		Material material = (isGreen ? canBulid : cannotBuild);
		MeshRenderer[] array = componentsInChildren;
		foreach (MeshRenderer meshRenderer in array)
		{
			Material[] array2 = new Material[meshRenderer.sharedMaterials.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = material;
			}
			meshRenderer.materials = array2;
		}
	}

	private void GameManager_OnDrawWingBluePrint(object sender, GameManager.OnDrawWingBluePrintArg e)
	{
		if (e.canInstall != isGreen)
		{
			colorChanged = true;
			isGreen = e.canInstall;
		}
		int numOfWings = e.numOfWings;
		float num = 360f / (float)numOfWings;
		if (bluePrintList.Count != numOfWings)
		{
			GameManager_OnDeleteBluePrint(null, null);
			for (int i = 0; i < numOfWings; i++)
			{
				GameObject item = CloneVisualOnlyRecursive(e.furniture);
				bluePrintList.Add(item);
			}
		}
		_ = e.rocket.forward;
		Transform rocket = e.rocket;
		for (int j = 0; j < bluePrintList.Count; j++)
		{
			Quaternion quaternion = Quaternion.AngleAxis((float)j * num, rocket.forward);
			Vector3 vector = e.position - rocket.position;
			Vector3 position = quaternion * vector + rocket.position;
			Quaternion rotation = quaternion * e.rotation;
			bluePrintList[j].transform.position = position;
			bluePrintList[j].transform.rotation = rotation;
			if (colorChanged || bluePrintList[j].GetComponentInChildren<MeshRenderer>().material != (isGreen ? canBulid : cannotBuild))
			{
				MeshRenderer[] componentsInChildren = bluePrintList[j].GetComponentsInChildren<MeshRenderer>();
				Material material = (isGreen ? canBulid : cannotBuild);
				MeshRenderer[] array = componentsInChildren;
				for (int k = 0; k < array.Length; k++)
				{
					array[k].material = material;
				}
			}
		}
		colorChanged = false;
	}

	public GameObject CloneVisualOnlyRecursive(GameObject source)
	{
		if (source.CompareTag("Liquid") || source.CompareTag("Gizmo"))
		{
			return null;
		}
		GameObject gameObject = new GameObject(source.name + "_VisualClone");
		gameObject.transform.localPosition = source.transform.localPosition;
		gameObject.transform.localRotation = source.transform.localRotation;
		gameObject.transform.localScale = source.transform.localScale;
		CopyMeshComponents(source, gameObject);
		foreach (Transform item in source.transform)
		{
			GameObject gameObject2 = CloneVisualOnlyRecursive(item.gameObject);
			if (gameObject2 != null)
			{
				gameObject2.transform.SetParent(gameObject.transform, worldPositionStays: false);
			}
		}
		return gameObject;
	}

	private void CopyMeshComponents(GameObject source, GameObject clone)
	{
		MeshFilter component = source.GetComponent<MeshFilter>();
		if (component != null)
		{
			clone.AddComponent<MeshFilter>().sharedMesh = component.sharedMesh;
		}
		MeshRenderer component2 = source.GetComponent<MeshRenderer>();
		if (component2 != null)
		{
			clone.AddComponent<MeshRenderer>().sharedMaterials = component2.sharedMaterials;
		}
	}
}
