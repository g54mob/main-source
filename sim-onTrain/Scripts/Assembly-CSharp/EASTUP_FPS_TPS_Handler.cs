using System.Collections.Generic;
using System.Linq;
using EAST_UP;
using UnityEngine;
using UnityEngine.Rendering;

public class EASTUP_FPS_TPS_Handler : MonoBehaviour
{
	public GameObject tpsParent;

	public List<GameObject> fpsParts = new List<GameObject>();

	public List<GameObject> tpsParts = new List<GameObject>();

	public List<GameObject> fpsArms = new List<GameObject>();

	[SerializeField]
	private EASTUP_CameraController cameraController;

	private bool isFPS;

	public List<TPS_EquipmentItem> tPS_EquipmentItems = new List<TPS_EquipmentItem>();

	[SerializeField]
	private TPSCharacterPartsHolder tps;

	private void Awake()
	{
		cameraController.OnCameraModeChanged.AddListener(ChangeMode);
		tPS_EquipmentItems = GetComponentsInChildren<TPS_EquipmentItem>(includeInactive: true).ToList();
	}

	private void Start()
	{
		tpsParts = tps.tpsParts;
	}

	public void ChangeMode(CameraMode mode)
	{
		if (!GetComponent<TsPlayerNetworkHelper>().isLocalPlayer)
		{
			InitializeTPS();
			return;
		}
		switch (mode)
		{
		case CameraMode.FPS:
			InitializeFPS();
			break;
		case CameraMode.TPS:
			InitializeTPS();
			break;
		}
	}

	public void InitializeFPS()
	{
		isFPS = true;
		foreach (GameObject fpsPart in fpsParts)
		{
			fpsPart.SetActive(value: true);
		}
		foreach (GameObject tpsPart in tpsParts)
		{
			Renderer[] componentsInChildren = tpsPart.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].shadowCastingMode = ShadowCastingMode.ShadowsOnly;
			}
		}
		foreach (TPS_EquipmentItem tPS_EquipmentItem in tPS_EquipmentItems)
		{
			tPS_EquipmentItem.gameObject.SetActive(value: false);
		}
	}

	public void InitializeTPS()
	{
		Debug.Log("Tps Initialized");
		isFPS = false;
		foreach (GameObject fpsPart in fpsParts)
		{
			fpsPart.SetActive(value: false);
		}
		foreach (GameObject tpsPart in tpsParts)
		{
			tpsPart.SetActive(value: true);
			Renderer[] componentsInChildren = tpsPart.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].shadowCastingMode = ShadowCastingMode.On;
			}
		}
		foreach (TPS_EquipmentItem tPS_EquipmentItem in tPS_EquipmentItems)
		{
			if (tPS_EquipmentItem.isEnabled)
			{
				tPS_EquipmentItem.gameObject.SetActive(value: true);
			}
		}
	}
}
