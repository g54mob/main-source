using System;
using RainbowArt.CleanFlatUI;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class TearDownTable : Furniture
{
	[SerializeField]
	private CinemachineCamera tearDownCam;

	[SerializeField]
	private CinemachineCamera pcbCam;

	[SerializeField]
	private CinemachineCamera doneCam;

	public GameObject mount;

	public GameObject pcbMount;

	[SerializeField]
	private GameObject heatGunPrefab;

	[SerializeField]
	private TeardownBox teardownBox;

	[SerializeField]
	private TeardownBox desolderBox;

	[SerializeField]
	private Transform heatgunPos;

	private ProgressBarSpecialPattern desolderGage;

	private GameObject currentHeatGunGO;

	private bool isUsing;

	private DetailedDevice mountedDevice;

	public static event Action OnTeardownTableInteracted;

	private void OnEnable()
	{
		TearDownController.OnDesolderStart += TearDownController_OnDesolderStart;
		TearDownUI.OnInitTable += TearDownUI_OnInitTable;
		TearDownController.OnTeardownComplete += TearDownController_OnTeardownComplete;
		TearDownUI.OnDoneBtnPressed += TearDownUI_OnDoneBtnPressed;
	}

	private void OnDisable()
	{
		TearDownController.OnDesolderStart -= TearDownController_OnDesolderStart;
		TearDownUI.OnInitTable -= TearDownUI_OnInitTable;
		TearDownController.OnTeardownComplete -= TearDownController_OnTeardownComplete;
		TearDownUI.OnDoneBtnPressed -= TearDownUI_OnDoneBtnPressed;
	}

	private void TearDownUI_OnDoneBtnPressed()
	{
		if (isUsing)
		{
			teardownBox.gameObject.SetActive(value: false);
			desolderBox.gameObject.SetActive(value: false);
			if (currentHeatGunGO != null)
			{
				UnityEngine.Object.Destroy(currentHeatGunGO);
				currentHeatGunGO = null;
			}
			UnityEngine.Object.Destroy(mountedDevice.baseShell);
			GameObject[] coverShell = mountedDevice.coverShell;
			for (int i = 0; i < coverShell.Length; i++)
			{
				UnityEngine.Object.Destroy(coverShell[i]);
			}
			UnityEngine.Object.Destroy(mountedDevice.pcb);
			UnityEngine.Object.Destroy(mountedDevice.pcb);
			coverShell = mountedDevice.screws;
			for (int i = 0; i < coverShell.Length; i++)
			{
				UnityEngine.Object.Destroy(coverShell[i]);
			}
			if (mountedDevice.chips != null)
			{
				UnityEngine.Object.Destroy(mountedDevice.chips);
			}
			UnityEngine.Object.Destroy(mountedDevice.gameObject);
			GameManager.S.OnPlayerUI();
			mountedDevice = null;
			Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Player");
			Cursor.visible = false;
			FirstPersonController.S.canControl = true;
			tearDownCam.Priority = 0;
			doneCam.Priority = 0;
			pcbCam.Priority = 0;
			isUsing = false;
		}
	}

	private void TearDownController_OnTeardownComplete(Chips obj)
	{
		if (isUsing)
		{
			FirstPersonController.S.ComsumeItem();
			doneCam.Priority = 2;
			pcbCam.Priority = 0;
		}
	}

	private void TearDownUI_OnInitTable(ProgressBarSpecialPattern obj)
	{
		if (isUsing)
		{
			desolderGage = obj;
		}
	}

	private void TearDownController_OnDesolderStart(GameObject obj)
	{
		if (isUsing)
		{
			teardownBox.pcb = null;
			teardownBox.gameObject.SetActive(value: false);
			desolderBox.gameObject.SetActive(value: true);
			desolderBox.chip = obj;
			currentHeatGunGO = UnityEngine.Object.Instantiate(heatGunPrefab, heatgunPos.position, base.transform.rotation);
			HeatGun component = currentHeatGunGO.GetComponent<HeatGun>();
			component.startRot = base.transform.rotation;
			component.chip = obj;
			component.gage = desolderGage;
			component.InitGage();
			tearDownCam.Priority = 0;
			pcbCam.Priority = 2;
		}
	}

	public override void Interact()
	{
		FirstPersonController player = GameManager.S.player;
		if (player.itemOnHand != null)
		{
			if (player.itemOnHand.TryGetComponent<Device>(out var component))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(component.detailedDeviceGO, mount.transform);
				mountedDevice = gameObject.GetComponent<DetailedDevice>();
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = Quaternion.identity;
				TearDownController tearDownController = GameManager.S.player.AddComponent<TearDownController>();
				tearDownController.table = this;
				tearDownController.device = gameObject;
				Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
				Cursor.visible = true;
				tearDownCam.Priority = 2;
				GameManager.S.player.canControl = false;
				isUsing = true;
				TearDownTable.OnTeardownTableInteracted?.Invoke();
				teardownBox.pcb = mountedDevice.pcb;
				teardownBox.gameObject.SetActive(value: true);
				AudioManager.S.PlaySFX(AudioManager.S.craftingTableInteract);
			}
			else
			{
				GameManager.S.DeviceNeeded();
			}
		}
		else
		{
			GameManager.S.DeviceNeeded();
		}
	}
}
