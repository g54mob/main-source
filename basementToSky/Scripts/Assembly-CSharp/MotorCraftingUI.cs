using System;
using System.Collections;
using System.Collections.Generic;
using RainbowArt.CleanFlatUI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class MotorCraftingUI : MonoBehaviour
{
	[Serializable]
	public class PartsList
	{
		public GameObject part;
	}

	[Header("Remake")]
	[SerializeField]
	private MotorCraftingTable table;

	[SerializeField]
	private TextMeshProUGUI boardNum;

	[SerializeField]
	private TextMeshProUGUI woodNum;

	[SerializeField]
	private TextMeshProUGUI pvcNum;

	[SerializeField]
	private TextMeshProUGUI metalNum;

	[SerializeField]
	private GameObject basicGrain;

	[SerializeField]
	private Transform fuelParent;

	[SerializeField]
	private Transform oxiParent;

	[SerializeField]
	private GameObject ingredUIPrefab;

	[SerializeField]
	private AnimationCurve[] grainGeometryCurve;

	[SerializeField]
	private MotorTestingGraph completeGraph;

	[SerializeField]
	private CaptureMotorTexture motorTextureMaker;

	[SerializeField]
	private Button boardTubeBtn;

	[SerializeField]
	private Button circleGeoMetryBtn;

	private MotorIngredientItem selectedFuel;

	private MotorIngredientItem selectedOxi;

	private int selectedCastTube;

	public List<PartsList> recipes;

	[SerializeField]
	private Shelf shelf;

	[SerializeField]
	private HealthBar CompleteGage;

	[SerializeField]
	private GameObject motorSelectionUI;

	[SerializeField]
	private GameObject mensurationUI;

	[SerializeField]
	private GameObject grindUI;

	[SerializeField]
	private GameObject completeUI;

	[SerializeField]
	private GameObject testingUI;

	[SerializeField]
	private GameObject boilingUI;

	[SerializeField]
	private GameObject castingUI;

	[SerializeField]
	private GameObject doneBtn;

	[SerializeField]
	private ProgressBarPattern grindGage;

	[SerializeField]
	private Image selectedMotorImage;

	[SerializeField]
	private TextMeshProUGUI selectedMotorDescription;

	[SerializeField]
	private Image completedMotorImage;

	[SerializeField]
	private TextMeshProUGUI completedMotorSescription;

	[SerializeField]
	private Transform ingredientsParent;

	[SerializeField]
	private GameObject ingredientUIPrefab;

	[SerializeField]
	private GameObject testingDoneBtn;

	[SerializeField]
	private TextMeshProUGUI noteText;

	private List<GameObject> ingredients = new List<GameObject>();

	[SerializeField]
	private GameObject[] uiList;

	private RocketMotor selectedMotor;

	private bool canCraft;

	private int index = -1;

	private LocalizedString motorSelectedString = new LocalizedString("MyTable", "motorselected");

	private LocalizedString thrustPowerString = new LocalizedString("MyTable", "crafting-thrustpower");

	private LocalizedString thrustTimeString = new LocalizedString("MyTable", "crafting-thrusttime");

	private LocalizedString waterString = new LocalizedString("MyTable", "crafting- water");

	private LocalizedString solidFuelString = new LocalizedString("MyTable", "crafting-solidfuel");

	private LocalizedString massString = new LocalizedString("MyTable", "crafting-mass");

	private LocalizedString typeString = new LocalizedString("MyTable", "crafting-type");

	public static event Action OnCannotCraftMotor;

	public static event Action<string> OnCustomMotorCrafted;

	private void Start()
	{
		base.gameObject.SetActive(value: false);
		GameManager.S.OnMotorCraftingTableInteracted += GameManger_OnMotorCraftingTableInteracted;
		GameManager.S.OnMotorMensurationStart += Gm_OnMotorMensurationStart;
		GameManager.S.OnMotorGrindStart += Gm_OnMotorGrindStart;
		GameManager.S.OnMotorCastingStart += Gm_OnMotorCastingStart;
		GameManager.S.OnMotorCraftingCompleted += Gm_OnMotorCraftingCompleted;
		GameManager.S.OnMotorTestingStart += Gm_OnMotorTestingStart;
		GameManager.S.OnGrainExploded += Gm_OnGrainExploded;
		GameManager.S.OnMotorIngredBoilingStart += Gm_OnMotorIngredBoilingStart;
		CurrentCraftingRocketGrain.OnTestingCompleted += CurrentCraftingRocketGrain_OnTestingCompleted;
		MotorCraftingController.OnRecipeOnNote += MotorCraftingController_OnRecipeOnNote;
		MotorCraftingTable.OnMotorSetted += MotorCraftingTable_OnMotorSetted;
		completeUI.SetActive(value: false);
	}

	private void MotorCraftingController_OnRecipeOnNote(string obj)
	{
		noteText.text = obj;
	}

	private void CurrentCraftingRocketGrain_OnTestingCompleted()
	{
		testingDoneBtn.gameObject.SetActive(value: true);
	}

	private void OnDestroy()
	{
		GameManager.S.OnMotorCraftingTableInteracted -= GameManger_OnMotorCraftingTableInteracted;
		GameManager.S.OnMotorMensurationStart -= Gm_OnMotorMensurationStart;
		GameManager.S.OnMotorGrindStart -= Gm_OnMotorGrindStart;
		GameManager.S.OnMotorCastingStart -= Gm_OnMotorCastingStart;
		GameManager.S.OnMotorCraftingCompleted -= Gm_OnMotorCraftingCompleted;
		GameManager.S.OnMotorTestingStart -= Gm_OnMotorTestingStart;
		GameManager.S.OnGrainExploded -= Gm_OnGrainExploded;
		GameManager.S.OnMotorIngredBoilingStart -= Gm_OnMotorIngredBoilingStart;
		CurrentCraftingRocketGrain.OnTestingCompleted -= CurrentCraftingRocketGrain_OnTestingCompleted;
		MotorCraftingController.OnRecipeOnNote -= MotorCraftingController_OnRecipeOnNote;
		MotorCraftingTable.OnMotorSetted -= MotorCraftingTable_OnMotorSetted;
	}

	private void MotorCraftingTable_OnMotorSetted()
	{
		boardTubeBtn.onClick?.Invoke();
		circleGeoMetryBtn.onClick?.Invoke();
	}

	private void Gm_OnMotorIngredBoilingStart(object sender, EventArgs e)
	{
		OpenUI(boilingUI);
	}

	private void Gm_OnGrainExploded(object sender, EventArgs e)
	{
		MotorCraftingDone();
	}

	private void Gm_OnMotorTestingStart(object sender, GameManager.OnMotorTestingStartArg e)
	{
		testingUI.GetComponentInChildren<MotorTestingGraph>().SetCurve(e.grain.powerCurve);
		doneBtn.SetActive(value: false);
		testingDoneBtn.gameObject.SetActive(value: false);
		OpenUI(testingUI);
	}

	private void Gm_OnMotorCraftingCompleted(object sender, EventArgs e)
	{
		BasicGrain component = table.selectedMotorGO.GetComponent<BasicGrain>();
		OpenUI(completeUI);
		completeGraph.ClearGraph();
		completeGraph.SetCurve(component.powerCurve);
		completeGraph.DrawGraphInstantly();
		Cursor.visible = true;
		string text = null;
		text = solidFuelString.GetLocalizedString();
		motorSelectedString.Arguments = new object[8]
		{
			massString.GetLocalizedString(),
			component.mass,
			thrustPowerString.GetLocalizedString(),
			component.thrustPow,
			thrustTimeString.GetLocalizedString(),
			component.launchDuration,
			typeString.GetLocalizedString(),
			text
		};
		if (GameManager.S.rocketPerkList[2])
		{
			motorSelectedString.Arguments[3] = component.thrustPow * 1.2f;
			motorSelectedString.Arguments[5] = component.launchDuration * 1.2f;
		}
		completedMotorSescription.text = motorSelectedString.GetLocalizedString();
		AudioManager.S.PlayDoorBell(AudioManager.S.tutorialUIOn);
		string grainName = Guid.NewGuid().ToString();
		SaveCustomGrain(grainName, component);
	}

	public void SaveCustomGrain(string grainName, BasicGrain grain)
	{
		ES3.Save("Mass_" + grainName, grain.mass);
		ES3.Save("Power_" + grainName, grain.thrustPow);
		ES3.Save("Duration_" + grainName, grain.launchDuration);
		ES3.Save("StickIndex_" + grainName, grain.stickIndex);
		ES3.Save("ProIndex_" + grainName, grain.propellantIndex);
		ES3.Save("TubeIndex_" + grainName, grain.tubeIndex);
		ES3.Save("ProMat_" + grainName, grain.ProMat());
		ES3.Save("Curve_" + grainName, grain.powerCurve);
		StartCoroutine(DelayedCaptureMotorTexture(grainName));
		MotorCraftingUI.OnCustomMotorCrafted?.Invoke(grainName);
	}

	private IEnumerator DelayedCaptureMotorTexture(string name)
	{
		yield return null;
		motorTextureMaker.CaptureAndSaveAsSprite("Texture_" + name);
	}

	private void Gm_OnMotorCastingStart(object sender, EventArgs e)
	{
		OpenUI(castingUI);
	}

	private void Gm_OnMotorGrindStart(object sender, EventArgs e)
	{
		OpenUI(grindUI);
	}

	private void Gm_OnMotorMensurationStart(object sender, EventArgs e)
	{
		OpenUI(mensurationUI);
	}

	private void GameManger_OnMotorCraftingTableInteracted(object sender, EventArgs e)
	{
		OnUI();
	}

	private void OnUI()
	{
		base.gameObject.SetActive(value: true);
		OpenUI(motorSelectionUI);
		doneBtn.SetActive(value: true);
		index = 0;
		FirstStart();
	}

	private void OffUI()
	{
		MotorCraftingIngredUI[] componentsInChildren = fuelParent.GetComponentsInChildren<MotorCraftingIngredUI>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			UnityEngine.Object.Destroy(componentsInChildren[i].gameObject);
		}
		componentsInChildren = oxiParent.GetComponentsInChildren<MotorCraftingIngredUI>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			UnityEngine.Object.Destroy(componentsInChildren[i].gameObject);
		}
		selectedFuel = null;
		selectedOxi = null;
		testingUI.GetComponentInChildren<MotorTestingGraph>().ClearGraph();
		if (completeGraph.curve != null)
		{
			completeGraph.ClearGraph();
		}
		base.gameObject.SetActive(value: false);
		motorSelectionUI.SetActive(value: false);
		index = 0;
	}

	private void Update()
	{
	}

	public void CastingTubeSelected(int index)
	{
		canCraft = true;
		table.selectedMotorGO.GetComponent<BasicGrain>().CastingTubeSelected(index);
		selectedCastTube = index;
		AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
	}

	public void FuelSelected(MotorIngredientItem fuel)
	{
		table.selectedMotorGO.GetComponent<BasicGrain>().FuelSelected(fuel);
		selectedFuel = fuel;
		AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
	}

	public void oxidizerSelected(MotorIngredientItem oxi)
	{
		table.selectedMotorGO.GetComponent<BasicGrain>().OxidizerSelected(oxi);
		selectedOxi = oxi;
		AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
	}

	public void GrainGeometrySelected(int index)
	{
		table.selectedMotorGO.GetComponent<BasicGrain>().GrainGeometrySelected(index);
		AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
	}

	private void FirstStart()
	{
		selectedCastTube = -1;
		canCraft = true;
		foreach (GameObject item in shelf.items)
		{
			MotorIngredientItem component = item.GetComponent<MotorIngredientItem>();
			if (component.ingredType == MotorIngredientItem.Type.Fuel)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(ingredUIPrefab, fuelParent);
				MotorCraftingIngredUI ui = gameObject.GetComponent<MotorCraftingIngredUI>();
				ui.type = 0;
				ui.mainImage.sprite = component.mainImage;
				ui.item = component;
				gameObject.GetComponent<Button>().onClick.AddListener(delegate
				{
					FuelSelected(ui.item);
				});
			}
			else
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(ingredUIPrefab, oxiParent);
				MotorCraftingIngredUI ui2 = gameObject2.GetComponent<MotorCraftingIngredUI>();
				ui2.type = 1;
				ui2.mainImage.sprite = component.mainImage;
				ui2.item = component;
				gameObject2.GetComponent<Button>().onClick.AddListener(delegate
				{
					oxidizerSelected(ui2.item);
				});
			}
		}
		GameManager.S.MotorSelected(basicGrain);
	}

	private void MotorSelected(int index)
	{
		GameObject part = recipes[index].part;
		RocketMotor rocketMotor = (selectedMotor = part.GetComponentInChildren<RocketMotor>());
		selectedMotorImage.sprite = rocketMotor.mainImage;
		string text = null;
		if (rocketMotor.type == RocketType.Gunpowder)
		{
			text = solidFuelString.GetLocalizedString();
		}
		else if (rocketMotor.type == RocketType.Water)
		{
			text = waterString.GetLocalizedString();
		}
		motorSelectedString.Arguments = new object[8]
		{
			massString.GetLocalizedString(),
			selectedMotor.mass,
			thrustPowerString.GetLocalizedString(),
			selectedMotor.trustPow,
			thrustTimeString.GetLocalizedString(),
			selectedMotor.launchDuration,
			typeString.GetLocalizedString(),
			text
		};
		if (GameManager.S.rocketPerkList[2])
		{
			motorSelectedString.Arguments[3] = selectedMotor.trustPow * 1.2f;
			motorSelectedString.Arguments[5] = selectedMotor.launchDuration * 1.2f;
		}
		selectedMotorDescription.text = motorSelectedString.GetLocalizedString();
		int num = 0;
		canCraft = true;
		if (ingredients.Count > 0)
		{
			foreach (GameObject ingredient2 in ingredients)
			{
				UnityEngine.Object.Destroy(ingredient2.gameObject);
			}
			ingredients.Clear();
		}
		Food.Ingredient[] array = rocketMotor.ingredients;
		for (int i = 0; i < array.Length; i++)
		{
			Food.Ingredient ingredient = array[i];
			Item componentInChildren = ingredient.food.GetComponentInChildren<Item>();
			GameObject gameObject = UnityEngine.Object.Instantiate(ingredientUIPrefab, ingredientsParent);
			ingredients.Add(gameObject);
			gameObject.GetComponentInChildren<Tooltip>(includeInactive: true).description.text = componentInChildren.itemNameTemp.GetLocalizedString();
			gameObject.GetComponent<Image>().sprite = componentInChildren.mainImage;
			TextMeshProUGUI componentInChildren2 = gameObject.GetComponentInChildren<TextMeshProUGUI>();
			int num2 = CheckShelf(componentInChildren);
			componentInChildren2.text = $"{num2}/{ingredient.number}";
			if (num2 < ingredient.number)
			{
				canCraft = false;
			}
			num++;
		}
		GameManager.S.MotorSelected(part);
	}

	public int CheckShelf(Item item)
	{
		int num = 0;
		foreach (GameObject item2 in shelf.items)
		{
			if (item.itemName == item2.GetComponentInChildren<Item>().itemName)
			{
				num++;
			}
		}
		return num;
	}

	public void MotorCraftingDone()
	{
		GameManager.S.MotorCraftingDone();
		OffUI();
	}

	public void StartMotorCrafting()
	{
		Debug.Log($"{canCraft}, {selectedCastTube}, {selectedFuel}, {selectedOxi}");
		if (canCraft && selectedCastTube != -1 && selectedFuel != null && selectedOxi != null)
		{
			selectedOxi.GetComponentInParent<ShelfSlot>().Comsume();
			selectedFuel.GetComponentInParent<ShelfSlot>().Comsume();
			GameManager.S.StartMotorCrafting(grainGeometryCurve[selectedCastTube], grindGage);
			AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
		}
		else
		{
			MotorCraftingUI.OnCannotCraftMotor?.Invoke();
			AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
		}
	}

	public void ToTheNextStep()
	{
		GameManager.S.MotorToTheNextStep();
	}

	private void OpenUI(GameObject ui)
	{
		GameObject[] array = uiList;
		foreach (GameObject gameObject in array)
		{
			if (gameObject != ui)
			{
				gameObject.SetActive(value: false);
			}
		}
		ui.SetActive(value: true);
	}

	private void CloseAllUI()
	{
		GameObject[] array = uiList;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
	}
}
