using UnityEngine;
using UnityEngine.Localization;

public class RocketChip : Item
{
	public enum ChipType
	{
		Cpu = 0,
		Camera = 1,
		WingController = 2,
		ExtraBooster = 3,
		Parachute = 4
	}

	public ChipType type;

	public LocalizedString description;

	private Rocket rocket;

	public WingGizmo[] wingGizmo;

	public GameObject wingLineGizmoPrefab;

	public GameObject[] wingControlVisual;

	public RocketRecoreder rocketCamera;

	public Outline outline;

	private bool isCalculated;

	private void Start()
	{
		CraftingUI.OnOffAllGizmos += CraftingUI_OnOffAllGizmos;
		outline = GetComponent<Outline>();
		if (rocket == null)
		{
			rocket = GetComponentInParent<Rocket>();
		}
		if (type == ChipType.Camera)
		{
			if (rocket.cameraModule != null)
			{
				Object.Destroy(rocket.cameraModule);
			}
			rocket.cameraModule = base.gameObject;
			rocket.camPos.position = base.transform.position;
			base.transform.parent = rocket.camPos;
			GameManager.S.CameraInstalled();
		}
		else if (type == ChipType.WingController)
		{
			BusStopUI.OnRocketRetrived += BusStopUI_OnRocketRetrived;
			CraftingUI.OnWingConnectBtn += CraftingUI_OnWingConnectBtn;
			CraftingUI.OnWingControllerSelected += CraftingUI_OnWingControllerSelected;
			rocket.wingControlModule = base.gameObject;
			rocket.wingControlModuleCompo = this;
		}
		else if (type == ChipType.Parachute)
		{
			CraftingUI.OnParachuteSelected += CraftingUI_OnParachuteSelected;
			if (rocket.cameraModule != null)
			{
				Object.Destroy(rocket.parachuteModule);
			}
			rocket.parachuteModule = base.gameObject;
		}
	}

	public void WingsRotInit()
	{
		if (type == ChipType.WingController)
		{
			WingGizmo[] array = wingGizmo;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetOriginRot();
			}
		}
		isCalculated = true;
	}

	private void BusStopUI_OnRocketRetrived()
	{
		if (wingGizmo != null)
		{
			WingGizmo[] array = wingGizmo;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Reset();
			}
		}
		isCalculated = false;
	}

	private void CraftingUI_OnParachuteSelected()
	{
		if (outline != null)
		{
			outline.enabled = true;
		}
	}

	public void ClearWings()
	{
		if (this.wingGizmo == null)
		{
			return;
		}
		WingGizmo[] array = this.wingGizmo;
		foreach (WingGizmo wingGizmo in array)
		{
			if (wingGizmo.wingGO != null)
			{
				wingGizmo.DoneConnecting();
			}
		}
	}

	private void CraftingUI_OnWingConnectBtn()
	{
		if (wingGizmo != null)
		{
			WingGizmo[] array = wingGizmo;
			foreach (WingGizmo obj in array)
			{
				obj.gameObject.SetActive(value: true);
				obj.gameObject.GetComponent<Collider>().enabled = true;
			}
		}
	}

	private void Update()
	{
		if (isCalculated)
		{
			WingGizmo[] array = wingGizmo;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RotateWing();
			}
		}
	}

	public void RotateWing(int arg1, float arg2)
	{
		if (wingGizmo != null)
		{
			wingGizmo[arg1 - 1].SetWingRotation(arg2);
		}
	}

	private void CraftingUI_OnOffAllGizmos()
	{
		if (wingGizmo != null)
		{
			WingGizmo[] array = wingGizmo;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(value: false);
			}
		}
		if (outline != null)
		{
			outline.enabled = false;
		}
		if (type == ChipType.WingController)
		{
			GameObject[] array2 = wingControlVisual;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].gameObject.SetActive(value: false);
			}
		}
	}

	private void CraftingUI_OnWingControllerSelected()
	{
		if (outline != null)
		{
			outline.enabled = true;
		}
		GameObject[] array = wingControlVisual;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: true);
		}
	}

	private void OnDestroy()
	{
		CraftingUI.OnWingControllerSelected -= CraftingUI_OnWingControllerSelected;
		CraftingUI.OnOffAllGizmos -= CraftingUI_OnOffAllGizmos;
		CraftingUI.OnWingConnectBtn -= CraftingUI_OnWingConnectBtn;
		CraftingUI.OnParachuteSelected -= CraftingUI_OnParachuteSelected;
	}
}
