using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
	[Serializable]
	public class PartsList
	{
		public GameObject part;

		public bool isUnlocked;
	}

	private LocalizedString selectString = new LocalizedString("MyTable", "crafting-select");

	private LocalizedString selectedString = new LocalizedString("MyTable", "crafting-selected");

	private LocalizedString installString = new LocalizedString("MyTable", "install");

	private LocalizedString installedString = new LocalizedString("MyTable", "installed");

	private LocalizedString headSelectedString = new LocalizedString("MyTable", "headselected");

	private LocalizedString massString = new LocalizedString("MyTable", "crafting-mass");

	private LocalizedString frontDragString = new LocalizedString("MyTable", "crafting-frontdrag");

	private LocalizedString liftString = new LocalizedString("MyTable", "crafting-lift");

	private LocalizedString bodySelectedString = new LocalizedString("MyTable", "bodyselected");

	private LocalizedString thrustTimeBonusString = new LocalizedString("MyTable", "crafting-thrust time bouns");

	private LocalizedString typeString = new LocalizedString("MyTable", "crafting-type");

	private LocalizedString waterRocketString = new LocalizedString("MyTable", "crafting-waterrocket");

	private LocalizedString solidFuelRocketString = new LocalizedString("MyTable", "crafting-solidfuelrocket");

	private LocalizedString wingSelectedString = new LocalizedString("MyTable", "wingselected");

	private LocalizedString dragString = new LocalizedString("MyTable", "crafting-drag");

	private LocalizedString motorSelectedString = new LocalizedString("MyTable", "motorselected");

	private LocalizedString thrustPowerString = new LocalizedString("MyTable", "crafting-thrustpower");

	private LocalizedString thrustTimeString = new LocalizedString("MyTable", "crafting-thrusttime");

	private LocalizedString waterString = new LocalizedString("MyTable", "crafting- water");

	private LocalizedString solidFuelString = new LocalizedString("MyTable", "crafting-solidfuel");

	private LocalizedString nozzleSelectedString = new LocalizedString("MyTable", "nozzleselected");

	private LocalizedString multiplierString = new LocalizedString("MyTable", "crafitng-thrustpowermultiplier");

	private LocalizedString lockedString = new LocalizedString("MyTable", "crafting-locked");

	private LocalizedString attchModeString = new LocalizedString("MyTable", "crafting-attach mode");

	[SerializeField]
	private Image selectedPartImage;

	[SerializeField]
	private TextMeshProUGUI selectedPartDescription;

	[SerializeField]
	private GameObject cannotSelectedGO;

	[SerializeField]
	private TextMeshProUGUI selectBtnText;

	[SerializeField]
	private Transform colorSelectUIPos;

	[SerializeField]
	private GameObject colorSelectBtn;

	[SerializeField]
	private GameObject wingClearBtn;

	[SerializeField]
	private GameObject wingUndoBtn;

	[SerializeField]
	private GameObject wingConnectBtn;

	[SerializeField]
	private GameObject[] numofWingBtn;

	[SerializeField]
	private Toggle cpVisibleToggle;

	[SerializeField]
	private Toggle transformGizmoToggle;

	[SerializeField]
	private GameObject[] wingNumChecks;

	[SerializeField]
	private GameObject chipCategoryBtn;

	[SerializeField]
	private GameObject dragToCustomUI;

	[SerializeField]
	private RectTransform cgIcon;

	[SerializeField]
	private RectTransform cpIcon;

	[SerializeField]
	private Camera uiCam;

	public List<PartsList> rocketHeadList;

	public List<PartsList> grainRocketHeadList;

	public List<PartsList> waterRocketBodyList;

	public List<PartsList> gunpowderRocketBodyList;

	public List<PartsList> rocketWingList;

	public List<PartsList> solidFuelWingList;

	public List<PartsList> waterRocketMotorList;

	public List<PartsList> gunpowderMotorList;

	public List<PartsList> rocektNozzleList;

	public List<PartsList> rocketChipsList;

	public List<string> customGrainList;

	public List<RocketColor> rocketColors;

	private List<GameObject> possibleColors;

	private GameObject selectedPart;

	private Rocket rocket;

	private HashSet<Texture2D> generatedTextures = new HashSet<Texture2D>();

	private float currentCategory;

	private int currentIndex;

	private bool cannotInstall;

	private int numOfWings = 1;

	private bool cpVisible;

	private bool transformVisible;

	public static event Action OnClearWings;

	public static event Action OnUndoWing;

	public static event Action<int> OnNumOfWings;

	public static event Action<bool> OnCpvisibleChanged;

	public static event Action OnCpuSelected;

	public static event Action OnWingControllerSelected;

	public static event Action OnParachuteSelected;

	public static event Action OnOffAllGizmos;

	public static event Action OnWingConnectBtn;

	public static event Action<bool> OnTransformGizmoVisibleChanged;

	private void Awake()
	{
		LoadPartsList();
	}

	private void Start()
	{
		base.gameObject.SetActive(value: false);
		ModuleSlot.OnModuleInstalled += ModuleSlot_OnModuleInstalled;
		GameManager.S.OnCpuInstalled += S_OnCpuInstalled;
		GameManager.S.OnCraftingTable += GameManager_OnCraftingTable;
		GameManager.S.OnUnlockNewMotor += Gm_OnUnlockNewMotor;
		GameManager.S.OnWingInstalled += Gm_OnWingInstalled;
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
		LapTop.OnBuyRocketParts += LapTop_OnBuyRocketParts;
		MotorCraftingUI.OnCustomMotorCrafted += MotorCraftingUI_OnCustomMotorCrafted;
		CustomCrafitng.OnPartsCustomed += CustomCrafitng_OnPartsCustomed;
		cpVisible = cpVisibleToggle.isOn;
		cpVisibleToggle.onValueChanged.AddListener(CpToggleValueChanged);
		transformVisible = transformGizmoToggle.isOn;
		transformGizmoToggle.onValueChanged.AddListener(TransformGizmoToggleValueChanged);
		possibleColors = new List<GameObject>();
		currentCategory = 0f;
		currentIndex = 0;
	}

	private void ModuleSlot_OnModuleInstalled(Chips obj)
	{
		if (obj.type == ChipType.Parachute)
		{
			rocketChipsList[1].isUnlocked = true;
		}
		else if (obj.type == ChipType.Camera)
		{
			rocketChipsList[0].isUnlocked = true;
		}
		else if (obj.type == ChipType.WingControl)
		{
			rocketChipsList[2].isUnlocked = true;
		}
	}

	private void LateUpdate()
	{
		if ((bool)cpVisibleToggle)
		{
			Vector3 vector = Camera.main.WorldToScreenPoint(rocket.cm.position);
			Vector3 vector2 = Camera.main.WorldToScreenPoint(rocket.cp.position);
			RectTransform component = cgIcon.parent.GetComponent<RectTransform>();
			RectTransformUtility.ScreenPointToLocalPointInRectangle(component, vector, uiCam, out var localPoint);
			cgIcon.localPosition = localPoint;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(component, vector2, uiCam, out localPoint);
			cpIcon.localPosition = localPoint;
		}
	}

	private void CustomCrafitng_OnPartsCustomed(RocketAttachment obj)
	{
		if (obj.partType == 0)
		{
			RocketHead component = obj.GetComponent<RocketHead>();
			headSelectedString.Arguments = new object[4]
			{
				massString.GetLocalizedString(),
				(float)Math.Round(component.mass, 2),
				frontDragString.GetLocalizedString(),
				(float)Math.Round(component.inspectorForce * 100f, 2)
			};
			selectedPartDescription.text = headSelectedString.GetLocalizedString();
		}
		else if (obj.partType == 1)
		{
			RocketBody component2 = obj.GetComponent<RocketBody>();
			string text = null;
			if (component2.type == RocketType.Gunpowder)
			{
				text = solidFuelRocketString.GetLocalizedString();
			}
			else if (component2.type == RocketType.Water)
			{
				text = waterRocketString.GetLocalizedString();
			}
			component2.GetLiftDrag();
			bodySelectedString.Arguments = new object[8]
			{
				massString.GetLocalizedString(),
				(float)Math.Round(component2.mass, 2),
				dragString.GetLocalizedString(),
				(float)Math.Round(component2.inspectorForce * 100f, 2),
				thrustTimeBonusString.GetLocalizedString(),
				component2.powTimeBonus,
				typeString.GetLocalizedString(),
				text
			};
			selectedPartDescription.text = bodySelectedString.GetLocalizedString();
		}
	}

	private void CpToggleValueChanged(bool isOn)
	{
		cpVisible = isOn;
		if (cpVisible)
		{
			cgIcon.gameObject.SetActive(value: true);
			cpIcon.gameObject.SetActive(value: true);
		}
		else
		{
			cgIcon.gameObject.SetActive(value: false);
			cpIcon.gameObject.SetActive(value: false);
		}
		CraftingUI.OnCpvisibleChanged?.Invoke(isOn);
	}

	private void TransformGizmoToggleValueChanged(bool isOn)
	{
		transformVisible = isOn;
		CraftingUI.OnTransformGizmoVisibleChanged?.Invoke(isOn);
	}

	private void MotorCraftingUI_OnCustomMotorCrafted(string obj)
	{
		customGrainList.Add(obj);
	}

	public Sprite LoadSavedIcon(string fileName)
	{
		string text = fileName + ".png";
		if (ES3.FileExists(text))
		{
			Texture2D texture2D = ES3.LoadImage(text);
			generatedTextures.Add(texture2D);
			return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
		}
		return null;
	}

	public void SafeDestroy(Sprite sprite)
	{
		if (!(sprite == null))
		{
			Texture2D texture = sprite.texture;
			if (texture != null && generatedTextures.Contains(texture))
			{
				generatedTextures.Remove(texture);
				UnityEngine.Object.Destroy(texture);
				Debug.Log("런타임 텍스처를 안전하게 삭제했습니다.");
				UnityEngine.Object.Destroy(sprite);
			}
		}
	}

	private void LapTop_OnBuyRocketParts(GameObject obj)
	{
		RocketAttachment componentInChildren = obj.GetComponentInChildren<RocketAttachment>();
		if (componentInChildren.partType == 0)
		{
			foreach (PartsList rocketHead in rocketHeadList)
			{
				if (rocketHead.part == obj)
				{
					rocketHead.isUnlocked = true;
				}
			}
			{
				foreach (PartsList grainRocketHead in grainRocketHeadList)
				{
					if (grainRocketHead.part == obj)
					{
						grainRocketHead.isUnlocked = true;
					}
				}
				return;
			}
		}
		if (componentInChildren.partType == 1)
		{
			RocketBody component = componentInChildren.GetComponent<RocketBody>();
			if (component.type == RocketType.Water)
			{
				foreach (PartsList waterRocketBody in waterRocketBodyList)
				{
					if (waterRocketBody.part == obj)
					{
						waterRocketBody.isUnlocked = true;
					}
				}
				return;
			}
			if (component.type != RocketType.Gunpowder)
			{
				return;
			}
			{
				foreach (PartsList gunpowderRocketBody in gunpowderRocketBodyList)
				{
					if (gunpowderRocketBody.part == obj)
					{
						gunpowderRocketBody.isUnlocked = true;
					}
				}
				return;
			}
		}
		if (componentInChildren.partType == 2)
		{
			foreach (PartsList rocketWing in rocketWingList)
			{
				if (rocketWing.part == obj)
				{
					rocketWing.isUnlocked = true;
				}
			}
			{
				foreach (PartsList solidFuelWing in solidFuelWingList)
				{
					if (solidFuelWing.part == obj)
					{
						solidFuelWing.isUnlocked = true;
					}
				}
				return;
			}
		}
		if (componentInChildren.partType == 3)
		{
			RocketMotor component2 = componentInChildren.GetComponent<RocketMotor>();
			if (component2.type == RocketType.Water)
			{
				foreach (PartsList waterRocketMotor in waterRocketMotorList)
				{
					if (waterRocketMotor.part == obj)
					{
						waterRocketMotor.isUnlocked = true;
					}
				}
				return;
			}
			if (component2.type != RocketType.Gunpowder)
			{
				return;
			}
			{
				foreach (PartsList gunpowderMotor in gunpowderMotorList)
				{
					if (gunpowderMotor.part == obj)
					{
						gunpowderMotor.isUnlocked = true;
					}
				}
				return;
			}
		}
		if (componentInChildren.partType != 4)
		{
			return;
		}
		foreach (PartsList rocektNozzle in rocektNozzleList)
		{
			if (rocektNozzle.part == obj)
			{
				rocektNozzle.isUnlocked = true;
			}
		}
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		SavePartsList();
	}

	private void SavePartsList()
	{
		ES3.Save("CraftingUI_grainRocketHeadList", grainRocketHeadList);
		ES3.Save("CraftingUI_rocketHeadList", rocketHeadList);
		ES3.Save("CraftingUI_waterRocketBodyList", waterRocketBodyList);
		ES3.Save("CraftingUI_gunpowderRocketBodyList", gunpowderRocketBodyList);
		ES3.Save("CraftingUI_waterRocketMotorList", waterRocketMotorList);
		ES3.Save("CraftingUI_gunpowderMotorList", gunpowderMotorList);
		ES3.Save("CraftingUI_rocektNozzleList", rocektNozzleList);
		ES3.Save("CraftingUI_WingList", rocketWingList);
		ES3.Save("CraftingUI_SolidFuelWingList", solidFuelWingList);
		ES3.Save("CraftingUI_ChipList", rocketChipsList);
		ES3.Save("customGrainList", customGrainList);
	}

	private void LoadPartsList()
	{
		rocketHeadList = ES3.Load("CraftingUI_rocketHeadList", rocketHeadList);
		waterRocketBodyList = ES3.Load("CraftingUI_waterRocketBodyList", waterRocketBodyList);
		gunpowderRocketBodyList = ES3.Load("CraftingUI_gunpowderRocketBodyList", gunpowderRocketBodyList);
		grainRocketHeadList = ES3.Load("CraftingUI_grainRocketHeadList", grainRocketHeadList);
		waterRocketMotorList = ES3.Load("CraftingUI_waterRocketMotorList", waterRocketMotorList);
		gunpowderMotorList = ES3.Load("CraftingUI_gunpowderMotorList", gunpowderMotorList);
		rocektNozzleList = ES3.Load("CraftingUI_rocektNozzleList", rocektNozzleList);
		rocketWingList = ES3.Load("CraftingUI_WingList", rocketWingList);
		solidFuelWingList = ES3.Load("CraftingUI_SolidFuelWingList", solidFuelWingList);
		rocketChipsList = ES3.Load("CraftingUI_ChipList", rocketChipsList);
		customGrainList = ES3.Load("customGrainList", customGrainList);
	}

	private void OnDestroy()
	{
		ModuleSlot.OnModuleInstalled += ModuleSlot_OnModuleInstalled;
		GameManager.S.OnCpuInstalled -= S_OnCpuInstalled;
		GameManager.S.OnCraftingTable -= GameManager_OnCraftingTable;
		GameManager.S.OnUnlockNewMotor -= Gm_OnUnlockNewMotor;
		GameManager.S.OnWingInstalled -= Gm_OnWingInstalled;
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
		LapTop.OnBuyRocketParts -= LapTop_OnBuyRocketParts;
		MotorCraftingUI.OnCustomMotorCrafted -= MotorCraftingUI_OnCustomMotorCrafted;
		CustomCrafitng.OnPartsCustomed -= CustomCrafitng_OnPartsCustomed;
	}

	private void Gm_OnWingInstalled(object sender, EventArgs e)
	{
		NumOfWings(1);
		selectBtnText.text = selectString.GetLocalizedString();
		rocket.StartCoroutine(rocket.DelayedCalculateCP());
	}

	private void S_OnCpuInstalled()
	{
		selectBtnText.text = installedString.GetLocalizedString();
		wingConnectBtn.SetActive(value: true);
	}

	private void Gm_OnUnlockNewMotor(object sender, GameManager.OnUnlockNewMotorArg e)
	{
		RocketMotor component = e.motor.GetComponent<RocketMotor>();
		if (component.type == RocketType.Water)
		{
			foreach (PartsList waterRocketMotor in waterRocketMotorList)
			{
				if (waterRocketMotor.part == e.motor)
				{
					waterRocketMotor.isUnlocked = true;
				}
			}
			return;
		}
		if (component.type != RocketType.Gunpowder)
		{
			return;
		}
		foreach (PartsList gunpowderMotor in gunpowderMotorList)
		{
			if (gunpowderMotor.part == e.motor)
			{
				gunpowderMotor.isUnlocked = true;
			}
		}
	}

	private void GameManager_OnCraftingTable(object sender, GameManager.OnCraftingTableArg e)
	{
		rocket = e.rocket;
		CpToggleValueChanged(cpVisible);
		OnUI();
	}

	private void GameManager_OnQuitCrafting(object sender, EventArgs e)
	{
		OffUI();
	}

	private void Update()
	{
	}

	public void OffUI()
	{
		base.gameObject.SetActive(value: false);
	}

	public void OnUI()
	{
		currentCategory = 0f;
		currentIndex = 0;
		PartSelected(currentIndex);
		base.gameObject.SetActive(value: true);
		if (rocket.body.type == RocketType.Gunpowder)
		{
			chipCategoryBtn.SetActive(value: true);
		}
		else
		{
			chipCategoryBtn.SetActive(value: false);
		}
	}

	private void PartSelected(int index)
	{
		if (possibleColors.Count > 0)
		{
			foreach (GameObject possibleColor in possibleColors)
			{
				UnityEngine.Object.Destroy(possibleColor);
			}
			possibleColors.Clear();
		}
		NumOfWings(1);
		GameManager.S.CancelWingInstalling();
		cannotSelectedGO.SetActive(value: false);
		bool flag = false;
		dragToCustomUI.SetActive(value: false);
		CraftingUI.OnOffAllGizmos?.Invoke();
		wingClearBtn.SetActive(value: false);
		wingUndoBtn.SetActive(value: false);
		wingConnectBtn.SetActive(value: false);
		GameObject[] array = numofWingBtn;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		RocketType type = rocket.rocketBody.GetComponent<RocketBody>().type;
		if (type != RocketType.Water)
		{
			if (rocket.body.gizmos != null)
			{
				array = rocket.body.gizmos;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
			}
			if (rocket.head.gizmos != null)
			{
				array = rocket.head.gizmos;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
			}
		}
		GameObject gameObject = null;
		if (currentCategory == 0f)
		{
			switch (type)
			{
			case RocketType.Water:
				gameObject = rocketHeadList[index].part;
				flag = rocketHeadList[index].isUnlocked;
				break;
			case RocketType.Gunpowder:
				gameObject = grainRocketHeadList[index].part;
				flag = grainRocketHeadList[index].isUnlocked;
				break;
			}
		}
		else if (currentCategory == 1f)
		{
			switch (type)
			{
			case RocketType.Water:
				gameObject = waterRocketBodyList[index].part;
				flag = waterRocketBodyList[index].isUnlocked;
				break;
			case RocketType.Gunpowder:
				gameObject = gunpowderRocketBodyList[index].part;
				flag = gunpowderRocketBodyList[index].isUnlocked;
				break;
			}
		}
		else if (currentCategory == 2f)
		{
			switch (type)
			{
			case RocketType.Water:
				gameObject = rocketWingList[index].part;
				flag = rocketWingList[index].isUnlocked;
				break;
			case RocketType.Gunpowder:
				gameObject = solidFuelWingList[index].part;
				flag = solidFuelWingList[index].isUnlocked;
				break;
			}
			wingUndoBtn.SetActive(value: true);
			wingClearBtn.SetActive(value: true);
			array = numofWingBtn;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
		}
		else if (currentCategory == 3f)
		{
			switch (type)
			{
			case RocketType.Water:
				gameObject = waterRocketMotorList[index].part;
				flag = waterRocketMotorList[index].isUnlocked;
				break;
			case RocketType.Gunpowder:
				if (index == 0)
				{
					gameObject = gunpowderMotorList[index].part;
					flag = gunpowderMotorList[index].isUnlocked;
				}
				break;
			}
		}
		else if (currentCategory == 4f)
		{
			gameObject = rocektNozzleList[index].part;
			flag = rocektNozzleList[index].isUnlocked;
		}
		else if (currentCategory == 5f)
		{
			gameObject = rocketChipsList[index].part;
			flag = rocketChipsList[index].isUnlocked;
		}
		selectedPart = gameObject;
		if (currentCategory == 5f)
		{
			RocketChip component = gameObject.GetComponent<RocketChip>();
			selectedPartImage.sprite = component.mainImage;
			if (component.type == RocketChip.ChipType.Camera)
			{
				selectedPartDescription.text = component.description.GetLocalizedString();
				selectBtnText.text = installString.GetLocalizedString();
			}
			else if (component.type == RocketChip.ChipType.WingController)
			{
				selectedPartDescription.text = component.description.GetLocalizedString();
				if (rocket.wingControlModule != null)
				{
					CraftingUI.OnWingControllerSelected?.Invoke();
					selectBtnText.text = installedString.GetLocalizedString();
					wingConnectBtn.SetActive(value: true);
				}
				else
				{
					selectBtnText.text = installString.GetLocalizedString();
				}
			}
			else if (component.type == RocketChip.ChipType.Parachute)
			{
				selectedPartDescription.text = component.description.GetLocalizedString();
				if (rocket.parachuteModule != null)
				{
					CraftingUI.OnParachuteSelected?.Invoke();
					selectBtnText.text = installedString.GetLocalizedString();
				}
				else
				{
					selectBtnText.text = installString.GetLocalizedString();
				}
			}
		}
		else
		{
			if (gameObject == null)
			{
				SafeDestroy(selectedPartImage.sprite);
				string text = null;
				text = solidFuelString.GetLocalizedString();
				string text2 = customGrainList[index - 1];
				float num = ES3.Load("Mass_" + text2, 0f);
				float num2 = ES3.Load("Power_" + text2, 0f);
				float num3 = ES3.Load("Duration_" + text2, 0f);
				Sprite sprite = LoadSavedIcon("Texture_" + text2);
				selectedPartImage.sprite = sprite;
				motorSelectedString.Arguments = new object[8]
				{
					massString.GetLocalizedString(),
					num,
					thrustPowerString.GetLocalizedString(),
					num2,
					thrustTimeString.GetLocalizedString(),
					num3,
					typeString.GetLocalizedString(),
					text
				};
				if (GameManager.S.rocketPerkList[2])
				{
					motorSelectedString.Arguments[3] = num2 * 1.2f;
					motorSelectedString.Arguments[5] = num3 * 1.2f;
				}
				selectedPartDescription.text = motorSelectedString.GetLocalizedString();
				if (text2 == rocket.rocketMotor.GetComponent<RocketAttachment>().partName)
				{
					selectBtnText.text = selectedString.GetLocalizedString();
				}
				else
				{
					selectBtnText.text = selectString.GetLocalizedString();
				}
				cannotInstall = false;
				return;
			}
			RocketAttachment componentInChildren = gameObject.GetComponentInChildren<RocketAttachment>();
			SafeDestroy(selectedPartImage.sprite);
			selectedPartImage.sprite = componentInChildren.mainImage;
			if (componentInChildren.partType == 0)
			{
				RocketHead rocketHead;
				if (componentInChildren.mainImage == rocket.rocketHead.GetComponent<RocketAttachment>().mainImage)
				{
					selectBtnText.text = selectedString.GetLocalizedString();
					rocketHead = rocket.head;
					if (rocketHead.gizmos != null)
					{
						array = rocketHead.gizmos;
						for (int i = 0; i < array.Length; i++)
						{
							array[i].gameObject.SetActive(value: true);
						}
					}
				}
				else
				{
					selectBtnText.text = selectString.GetLocalizedString();
					rocketHead = gameObject.GetComponent<RocketHead>();
				}
				rocketHead.GetLiftDrag();
				headSelectedString.Arguments = new object[4]
				{
					massString.GetLocalizedString(),
					(float)Math.Round(rocketHead.mass, 2),
					frontDragString.GetLocalizedString(),
					(float)Math.Round(rocketHead.inspectorForce * 100f, 2)
				};
				selectedPartDescription.text = headSelectedString.GetLocalizedString();
			}
			else if (componentInChildren.partType == 1)
			{
				RocketBody component2;
				if (componentInChildren.mainImage == rocket.rocketBody.GetComponent<RocketAttachment>().mainImage)
				{
					selectBtnText.text = selectedString.GetLocalizedString();
					component2 = rocket.rocketBody.GetComponent<RocketBody>();
					if (component2.gizmos != null)
					{
						array = component2.gizmos;
						for (int i = 0; i < array.Length; i++)
						{
							array[i].gameObject.SetActive(value: true);
							dragToCustomUI.SetActive(value: true);
						}
					}
					if (component2.customCrafting != null)
					{
						component2.customCrafting.RecordRelationship();
					}
				}
				else
				{
					component2 = gameObject.GetComponent<RocketBody>();
					selectBtnText.text = selectString.GetLocalizedString();
				}
				string text3 = null;
				if (component2.type == RocketType.Gunpowder)
				{
					text3 = solidFuelRocketString.GetLocalizedString();
				}
				else if (component2.type == RocketType.Water)
				{
					text3 = waterRocketString.GetLocalizedString();
				}
				component2.GetLiftDrag();
				bodySelectedString.Arguments = new object[8]
				{
					massString.GetLocalizedString(),
					(float)Math.Round(component2.mass, 2),
					dragString.GetLocalizedString(),
					(float)Math.Round(component2.inspectorForce * 100f, 2),
					thrustTimeBonusString.GetLocalizedString(),
					component2.powTimeBonus,
					typeString.GetLocalizedString(),
					text3
				};
				selectedPartDescription.text = bodySelectedString.GetLocalizedString();
			}
			else if (componentInChildren.partType == 2)
			{
				componentInChildren.GetLiftDrag();
				wingSelectedString.Arguments = new object[4]
				{
					massString.GetLocalizedString(),
					componentInChildren.mass,
					liftString.GetLocalizedString(),
					(float)Math.Round(componentInChildren.inspectorForce * 100f, 2)
				};
				selectedPartDescription.text = wingSelectedString.GetLocalizedString();
				selectBtnText.text = selectString.GetLocalizedString();
			}
			else if (componentInChildren.partType == 3)
			{
				RocketMotor component3 = gameObject.GetComponent<RocketMotor>();
				string text4 = null;
				if (component3.type == RocketType.Gunpowder)
				{
					text4 = solidFuelString.GetLocalizedString();
				}
				else if (component3.type == RocketType.Water)
				{
					text4 = waterString.GetLocalizedString();
				}
				motorSelectedString.Arguments = new object[8]
				{
					massString.GetLocalizedString(),
					component3.mass,
					thrustPowerString.GetLocalizedString(),
					component3.trustPow,
					thrustTimeString.GetLocalizedString(),
					component3.launchDuration,
					typeString.GetLocalizedString(),
					text4
				};
				if (GameManager.S.rocketPerkList[2])
				{
					motorSelectedString.Arguments[3] = component3.trustPow * 1.2f;
					motorSelectedString.Arguments[5] = component3.launchDuration * 1.2f;
				}
				selectedPartDescription.text = motorSelectedString.GetLocalizedString();
				rocket.rocketBody.GetComponentInChildren<RocketBody>();
				if (component3.mainImage == rocket.rocketMotor.GetComponent<RocketAttachment>().mainImage)
				{
					selectBtnText.text = selectedString.GetLocalizedString();
				}
				else
				{
					selectBtnText.text = selectString.GetLocalizedString();
				}
			}
			else if (componentInChildren.partType == 4)
			{
				RocketNozzle component4 = gameObject.GetComponent<RocketNozzle>();
				nozzleSelectedString.Arguments = new object[4]
				{
					massString.GetLocalizedString(),
					component4.mass,
					multiplierString.GetLocalizedString(),
					component4.rocketPowMultiplier
				};
				selectedPartDescription.text = nozzleSelectedString.GetLocalizedString();
				if (rocket.rocketNozzle == null)
				{
					selectBtnText.text = selectString.GetLocalizedString();
					return;
				}
				if (componentInChildren.mainImage == rocket.rocketNozzle.GetComponent<RocketAttachment>().mainImage)
				{
					selectBtnText.text = selectedString.GetLocalizedString();
				}
				else
				{
					selectBtnText.text = selectString.GetLocalizedString();
				}
			}
		}
		if (!flag)
		{
			cannotInstall = true;
			cannotSelectedGO.SetActive(value: true);
			selectBtnText.text = lockedString.GetLocalizedString();
		}
		else
		{
			cannotInstall = false;
		}
	}

	public void NumOfWings(int num)
	{
		numOfWings = num;
		CraftingUI.OnNumOfWings?.Invoke(numOfWings);
		for (int i = 0; i < wingNumChecks.Length; i++)
		{
			if (i == num - 1)
			{
				wingNumChecks[i].SetActive(value: true);
			}
			else
			{
				wingNumChecks[i].SetActive(value: false);
			}
		}
	}

	public void ClearWings()
	{
		CraftingUI.OnClearWings?.Invoke();
	}

	public void UndoWing()
	{
		CraftingUI.OnUndoWing?.Invoke();
	}

	public void InstallPart()
	{
		if (cannotInstall)
		{
			AudioManager.S.PlaySFX(AudioManager.S.doorLocked);
			return;
		}
		GameObject gameObject = selectedPart;
		if (currentCategory == 5f)
		{
			RocketChip component = gameObject.GetComponent<RocketChip>();
			if (component.type == RocketChip.ChipType.Camera)
			{
				if (!(selectBtnText.text == installedString.GetLocalizedString()))
				{
					AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
					selectBtnText.text = installedString.GetLocalizedString();
					GameManager.S.PartInstallBtnPressed(gameObject, 5f, 1);
				}
			}
			else if (component.type == RocketChip.ChipType.WingController)
			{
				if (!(selectBtnText.text == installedString.GetLocalizedString()))
				{
					AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
					selectBtnText.text = attchModeString.GetLocalizedString();
					GameManager.S.PartInstallBtnPressed(gameObject, 5f, numOfWings);
				}
			}
			else if (component.type == RocketChip.ChipType.Parachute && !(selectBtnText.text == installedString.GetLocalizedString()))
			{
				AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
				selectBtnText.text = installedString.GetLocalizedString();
				GameManager.S.PartInstallBtnPressed(gameObject, 5f, numOfWings);
			}
			return;
		}
		if (gameObject == null)
		{
			GameManager.S.PartInstallBtnPressedCustomMotor(customGrainList[currentIndex - 1]);
			selectBtnText.text = selectedString.GetLocalizedString();
			return;
		}
		RocketAttachment componentInChildren = gameObject.GetComponentInChildren<RocketAttachment>();
		if (componentInChildren.partType == 0)
		{
			RocketHead component2 = gameObject.GetComponent<RocketHead>();
			component2.GetLiftDrag();
			headSelectedString.Arguments = new object[4]
			{
				massString.GetLocalizedString(),
				(float)Math.Round(component2.mass, 2),
				frontDragString.GetLocalizedString(),
				(float)Math.Round(component2.inspectorForce * 100f, 2)
			};
			selectedPartDescription.text = headSelectedString.GetLocalizedString();
		}
		else if (componentInChildren.partType == 1)
		{
			RocketBody component3 = gameObject.GetComponent<RocketBody>();
			string text = null;
			if (component3.type == RocketType.Gunpowder)
			{
				text = solidFuelRocketString.GetLocalizedString();
			}
			else if (component3.type == RocketType.Water)
			{
				text = waterRocketString.GetLocalizedString();
			}
			component3.GetLiftDrag();
			bodySelectedString.Arguments = new object[8]
			{
				massString.GetLocalizedString(),
				(float)Math.Round(component3.mass, 2),
				dragString.GetLocalizedString(),
				(float)Math.Round(component3.inspectorForce * 100f, 2),
				thrustTimeBonusString.GetLocalizedString(),
				component3.powTimeBonus,
				typeString.GetLocalizedString(),
				text
			};
			selectedPartDescription.text = bodySelectedString.GetLocalizedString();
		}
		GameManager.S.PartInstallBtnPressed(gameObject, componentInChildren.partType, numOfWings);
		if (componentInChildren.partType == 2)
		{
			AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
			selectBtnText.text = attchModeString.GetLocalizedString();
		}
		else
		{
			selectBtnText.text = selectedString.GetLocalizedString();
		}
	}

	public void NextPart()
	{
		RocketType type = rocket.rocketBody.GetComponent<RocketBody>().type;
		int num = 0;
		if (currentCategory == 0f)
		{
			switch (type)
			{
			case RocketType.Water:
				num = rocketHeadList.Count - 1;
				break;
			case RocketType.Gunpowder:
				num = grainRocketHeadList.Count - 1;
				break;
			}
		}
		else if (currentCategory == 1f)
		{
			switch (type)
			{
			case RocketType.Water:
				num = waterRocketBodyList.Count - 1;
				break;
			case RocketType.Gunpowder:
				num = gunpowderRocketBodyList.Count - 1;
				break;
			}
		}
		else if (currentCategory == 2f)
		{
			switch (type)
			{
			case RocketType.Water:
				num = rocketWingList.Count - 1;
				break;
			case RocketType.Gunpowder:
				num = solidFuelWingList.Count - 1;
				break;
			}
		}
		else if (currentCategory == 3f)
		{
			switch (type)
			{
			case RocketType.Water:
				num = waterRocketMotorList.Count - 1;
				break;
			case RocketType.Gunpowder:
				num = ((customGrainList != null) ? customGrainList.Count : 0);
				break;
			}
		}
		else if (currentCategory == 4f)
		{
			num = rocektNozzleList.Count - 1;
		}
		else if (currentCategory == 5f)
		{
			num = rocketChipsList.Count - 1;
		}
		if (currentIndex == num)
		{
			currentIndex = 0;
		}
		else
		{
			currentIndex++;
		}
		PartSelected(currentIndex);
	}

	public void PrevPart()
	{
		RocketType type = rocket.rocketBody.GetComponent<RocketBody>().type;
		int num = 0;
		if (currentCategory == 0f)
		{
			switch (type)
			{
			case RocketType.Water:
				num = rocketHeadList.Count - 1;
				break;
			case RocketType.Gunpowder:
				num = grainRocketHeadList.Count - 1;
				break;
			}
		}
		else if (currentCategory == 1f)
		{
			switch (type)
			{
			case RocketType.Water:
				num = waterRocketBodyList.Count - 1;
				break;
			case RocketType.Gunpowder:
				num = gunpowderRocketBodyList.Count - 1;
				break;
			}
		}
		else if (currentCategory == 2f)
		{
			switch (type)
			{
			case RocketType.Water:
				num = rocketWingList.Count - 1;
				break;
			case RocketType.Gunpowder:
				num = solidFuelWingList.Count - 1;
				break;
			}
		}
		else if (currentCategory == 3f)
		{
			switch (type)
			{
			case RocketType.Water:
				num = waterRocketMotorList.Count - 1;
				break;
			case RocketType.Gunpowder:
				num = ((customGrainList != null) ? customGrainList.Count : 0);
				break;
			}
		}
		else if (currentCategory == 4f)
		{
			num = rocektNozzleList.Count - 1;
		}
		else if (currentCategory == 5f)
		{
			num = rocketChipsList.Count - 1;
		}
		if (currentIndex == 0)
		{
			currentIndex = num;
		}
		else
		{
			currentIndex--;
		}
		PartSelected(currentIndex);
	}

	public void CategoryChanged(int category)
	{
		currentCategory = category;
		currentIndex = 0;
		PartSelected(currentIndex);
	}

	public void CraftingDone()
	{
		rocket.cp.gameObject.SetActive(value: false);
		rocket.cm.gameObject.SetActive(value: false);
		if (rocket.head.gizmos != null)
		{
			GameObject[] gizmos = rocket.head.gizmos;
			for (int i = 0; i < gizmos.Length; i++)
			{
				gizmos[i].SetActive(value: false);
			}
		}
		if (rocket.body.gizmos != null)
		{
			GameObject[] gizmos = rocket.body.gizmos;
			for (int i = 0; i < gizmos.Length; i++)
			{
				gizmos[i].SetActive(value: false);
			}
		}
		AudioManager.S.PlaySFX(AudioManager.S.craftingTableDone);
		GameManager.S.CrafingDone();
		GameManager.S.CancelWingInstalling();
		CraftingUI.OnOffAllGizmos?.Invoke();
		OffUI();
	}

	public void ColorPicked(int i)
	{
		Debug.Log(i);
		selectedPart.GetComponent<RocketAttachment>().meshRenderer.material = rocketColors[i].mat;
	}

	public void WingConnectBtn()
	{
		CraftingUI.OnWingConnectBtn?.Invoke();
	}
}
