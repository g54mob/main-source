using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloraGUI : MonoBehaviour
{
	public GameObject effectPrefab;

	public GameObject floraIconPrefab;

	public GameObject occurancePrefab;

	public TextMeshProUGUI completionPercentageText;

	public TextScaleInOnLoad headerScale;

	public Transform floraListHolderTransform;

	public TextScaleInOnLoad floraDescriptionScale;

	public Image floraPortraitHolder;

	public TextScaleInOnLoad floraNameScale;

	public TextMeshProUGUI floraNameHeaderText;

	public TextMeshProUGUI floraDescriptionText;

	public InchwormBounce specificFloraIconBouncer;

	public Scrollbar occuranceScrollRef;

	public RectTransform occuranceInfoTransform;

	public RectTransform occuranceSliderAreaTransform;

	public Scrollbar effectScrollRef;

	public RectTransform effectInfoTransform;

	public RectTransform effectSliderAreaTransform;

	private GutFloraResource activeFlora;

	private string panelOpenSound = "field_guide_open";

	private string panelCloseSound = "field_guide_close";

	private string floraCycleSound = "field_guide_cycle";

	private string panelBubbleSound = "field_guide_bubble";

	private float finalEffectOffset = 100f;

	private float initialEffectOffset = 50f;

	private float finalOccuranceOffset = 210f;

	private float initialOccuranceOffset = 100f;

	public GameObject pageAllFlora;

	public GameObject pageSpecificFlora;

	private float iconBounceTime = 0.6f;

	private float bounceOffset = 0.025f;

	private int floraPerRow = 10;

	private float floraListOffsetX = 157.5f;

	private float floraListOffsetY = -165f;

	private int occurancesPerRow = 3;

	private float occuranceOffsetX = 185f;

	private float occuranceOffsetY = -185f;

	private Vector3 occuranceScale = new Vector3(0.35f, 0.35f, 0.35f);

	private float effectOffsetY = -75f;

	private List<GameObject> instantiatedEffects = new List<GameObject>();

	private List<GameObject> instantiatedOccurances = new List<GameObject>();

	private List<GameObject> instantiatedFloraIcons = new List<GameObject>();

	private FloraButtonBase floraButtonRef;

	private bool specificFloraPageOpen;

	private FloraManager floraManagerRef;

	private InventoryManager inventoryRef;

	private DogGutsManager dogGutsManagerRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		floraManagerRef = registrationScript.GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		dogGutsManagerRef = registrationScript.GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
		SFXOverlord.LockInWorldSFX(LockReason.FLORA_GUI);
		OpenAllFloraPage();
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			if (specificFloraPageOpen)
			{
				OpenAllFloraPage(fromBackButton: true);
			}
			else
			{
				CloseGUI();
			}
		}
	}

	public void SetFloraRef(FloraButtonBase newRef)
	{
		floraButtonRef = newRef;
	}

	public void CloseGUI()
	{
		ClearFloraList();
		ClearEffectsList();
		ClearOccurancesList();
		floraButtonRef.UnloadGUI();
		SFXOverlord.UnlockInWorldSFX(LockReason.FLORA_GUI);
		AudioController.Play(panelCloseSound);
	}

	public void OpenAllFloraPage(bool fromBackButton = false)
	{
		OpenAllFloraPage(immediate: false, playSounds: true, fromBackButton);
	}

	public void OpenAllFloraPage(bool immediate = false, bool playSounds = true, bool fromBackButton = false)
	{
		activeFlora = null;
		specificFloraPageOpen = false;
		ClearEffectsList();
		ClearOccurancesList();
		pageAllFlora.SetActive(value: true);
		pageSpecificFlora.SetActive(value: false);
		headerScale.RequestScaleIn();
		if (immediate)
		{
			PopulateFloraList();
		}
		else
		{
			StartCoroutine(PopulateFloraList());
		}
		CalculateAndUpdateCompletionPercentage();
		if (playSounds && !fromBackButton)
		{
			AudioController.Play(panelOpenSound);
		}
	}

	public void OpenSpecificFloraPage(GutFloraResource floraType)
	{
		activeFlora = floraType;
		specificFloraPageOpen = true;
		ClearFloraList();
		pageAllFlora.SetActive(value: false);
		pageSpecificFlora.SetActive(value: true);
		floraNameHeaderText.text = floraType.floraNameLocalized;
		floraPortraitHolder.sprite = floraType.gutFloraPreviewSprite;
		string floraPath = dogGutsManagerRef.floraNameToPathDict[floraType.gutFloraName];
		FloraUnlockInfo unlockInfoForFloraPath = floraManagerRef.GetUnlockInfoForFloraPath(floraPath);
		if (unlockInfoForFloraPath.floraDiscovered)
		{
			floraPortraitHolder.color = Color.white;
			floraDescriptionText.text = floraType.floraDescriptionLocalized;
			unlockInfoForFloraPath.floraDiscoveryRecognized = true;
		}
		else
		{
			floraPortraitHolder.color = Color.black;
			floraDescriptionText.text = ScriptLocalization.GUI.GUI_FLORAGUIDE_NODATA;
			floraNameHeaderText.text = TextUtil.GetHiddenString(floraNameHeaderText.text);
		}
		StartCoroutine(CreateOccurances(unlockInfoForFloraPath));
		CreateEffects(unlockInfoForFloraPath, floraPath);
		floraNameScale.RequestScaleIn();
		floraDescriptionScale.RequestScaleIn();
		specificFloraIconBouncer.RequestBounce();
		AudioController.Play(floraCycleSound);
	}

	public void OnLeftFloraButtonPressed()
	{
		GutFloraResource gutFloraResource = null;
		for (int i = 0; i < dogGutsManagerRef.allFlora.Count; i++)
		{
			if (activeFlora == dogGutsManagerRef.allFlora[i])
			{
				gutFloraResource = ((i != 0) ? dogGutsManagerRef.allFlora[i - 1] : dogGutsManagerRef.allFlora[dogGutsManagerRef.allFlora.Count - 1]);
			}
		}
		if (gutFloraResource == null)
		{
			Debug.LogError("Oh no! Not able to cycle through flora for some reason.");
		}
		else
		{
			OpenSpecificFloraPage(gutFloraResource);
		}
	}

	public void OnRightFloraButtonPressed()
	{
		GutFloraResource gutFloraResource = null;
		for (int i = 0; i < dogGutsManagerRef.allFlora.Count; i++)
		{
			if (activeFlora == dogGutsManagerRef.allFlora[i])
			{
				gutFloraResource = ((i != dogGutsManagerRef.allFlora.Count - 1) ? dogGutsManagerRef.allFlora[i + 1] : dogGutsManagerRef.allFlora[0]);
			}
		}
		if (gutFloraResource == null)
		{
			Debug.LogError("Oh no! Not able to cycle through flora for some reason.");
		}
		else
		{
			OpenSpecificFloraPage(gutFloraResource);
		}
	}

	private IEnumerator CreateOccurances(FloraUnlockInfo unlockInfo)
	{
		ClearOccurancesList();
		yield return new WaitForEndOfFrame();
		occuranceSliderAreaTransform.sizeDelta = Vector2.zero;
		List<int> objects = new List<int>();
		for (int i = 0; i < unlockInfo.foodList.Count; i++)
		{
			objects.Add(i);
		}
		ListUtil.ShuffleList(ref objects);
		int num = 0;
		for (int j = 0; j < unlockInfo.foodList.Count; j++)
		{
			InventoryItem itemForPath = inventoryRef.GetItemForPath(unlockInfo.foodList[j]);
			if ((CheatEngine.fishPackEnabled || itemForPath.setType != ItemSet.FISH) && (CheatEngine.groceryPackEnabled || itemForPath.setType != ItemSet.GROCERY) && (CheatEngine.desertPackEnabled || itemForPath.setType != ItemSet.DESERT) && (CheatEngine.basementPackEnabled || itemForPath.setType != ItemSet.BASEMENT))
			{
				GameObject gameObject = Object.Instantiate(occurancePrefab);
				gameObject.transform.SetParent(occuranceInfoTransform);
				gameObject.transform.localScale = occuranceScale;
				int num2 = num % occurancesPerRow;
				int num3 = Mathf.FloorToInt(num / occurancesPerRow);
				gameObject.transform.localPosition = new Vector3((float)num2 * occuranceOffsetX, (float)num3 * occuranceOffsetY);
				float num4 = (float)num3 * (0f - occuranceOffsetY) + finalOccuranceOffset;
				occuranceSliderAreaTransform.sizeDelta = new Vector2(0f, num4);
				occuranceInfoTransform.anchoredPosition3D = new Vector3(occuranceInfoTransform.anchoredPosition3D.x, num4 / 2f - initialOccuranceOffset, 0f);
				FloraOccurance component = gameObject.GetComponent<FloraOccurance>();
				bool flag = unlockInfo.foodListDiscoveries.Contains(unlockInfo.foodList[j]);
				bool newDiscovery = false;
				if (flag && !unlockInfo.recognizedFoodListDiscoveries.Contains(unlockInfo.foodList[j]))
				{
					newDiscovery = true;
					unlockInfo.recognizedFoodListDiscoveries.Add(unlockInfo.foodList[j]);
				}
				component.SetOccurance(itemForPath.icon, flag, newDiscovery);
				InchwormBounce component2 = gameObject.GetComponent<InchwormBounce>();
				component2.scaleTime = iconBounceTime;
				component2.startInvisible = true;
				component2.bounceStartDelay = bounceOffset * (float)objects[j];
				component2.RequestBounce();
				instantiatedOccurances.Add(gameObject);
				num++;
			}
		}
		occuranceScrollRef.value = 1f;
	}

	private void CreateEffects(FloraUnlockInfo unlockInfo, string floraPath)
	{
		ClearEffectsList();
		effectSliderAreaTransform.sizeDelta = Vector2.zero;
		for (int i = 0; i < unlockInfo.floraEffects.Count; i++)
		{
			GameObject gameObject = Object.Instantiate(effectPrefab);
			gameObject.transform.SetParent(effectInfoTransform);
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = new Vector3(0f, (float)i * effectOffsetY);
			float num = (float)i * (0f - effectOffsetY) + finalEffectOffset;
			effectSliderAreaTransform.sizeDelta = new Vector2(0f, num);
			effectInfoTransform.anchoredPosition3D = new Vector3(effectInfoTransform.anchoredPosition3D.x, num / 2f - initialEffectOffset, 0f);
			string text = GutFloraMutations.GetReadableNameForMutationEffect(unlockInfo.floraEffects[i]);
			TextMeshProUGUI component = gameObject.GetComponent<TextMeshProUGUI>();
			GameObject gameObject2 = gameObject.transform.GetChild(0).gameObject;
			gameObject2.SetActive(value: false);
			Image component2 = gameObject.transform.GetChild(1).GetComponent<Image>();
			component2.sprite = floraManagerRef.GetSymbolForRarity(floraManagerRef.GetRarityForFloraPathAndEffect(floraPath, unlockInfo.floraEffects[i]));
			if (!unlockInfo.floraEffectDiscoveries.Contains(unlockInfo.floraEffects[i]))
			{
				component.color = Color.black;
				component2.color = Color.black;
				text = TextUtil.GetHiddenString(text);
			}
			else if (!unlockInfo.recognizedFloraEffectDiscoveries.Contains(unlockInfo.floraEffects[i]))
			{
				gameObject2.SetActive(value: true);
				unlockInfo.recognizedFloraEffectDiscoveries.Add(unlockInfo.floraEffects[i]);
			}
			component.text = text;
			gameObject.GetComponent<TextScaleInOnLoad>().initialDelay = Random.Range(0f, bounceOffset * 10f);
			instantiatedEffects.Add(gameObject);
		}
		effectScrollRef.value = 1f;
	}

	public void OnGutFloraIconClicked(int index)
	{
		OpenSpecificFloraPage(dogGutsManagerRef.allFlora[index]);
	}

	private IEnumerator PopulateFloraList()
	{
		yield return new WaitForEndOfFrame();
		List<int> objects = new List<int>();
		for (int i = 0; i < dogGutsManagerRef.allFlora.Count; i++)
		{
			objects.Add(i / 2);
		}
		ListUtil.ShuffleList(ref objects);
		for (int j = 0; j < dogGutsManagerRef.allFlora.Count; j++)
		{
			string floraPath = dogGutsManagerRef.floraNameToPathDict[dogGutsManagerRef.allFlora[j].gutFloraName];
			bool num = floraManagerRef.IsFloraUnlocked(floraPath);
			GameObject gameObject = Object.Instantiate(floraIconPrefab);
			gameObject.transform.SetParent(floraListHolderTransform);
			gameObject.transform.localScale = Vector3.one;
			FloraIconButton component = gameObject.GetComponent<FloraIconButton>();
			component.index = j;
			component.guiRef = this;
			if (floraManagerRef.DoesFloraHaveUnrecognizedInfo(floraPath))
			{
				component.EnableDiscoveryIndicator();
			}
			FloraUnlockInfo unlockInfoForFloraPath = floraManagerRef.GetUnlockInfoForFloraPath(floraPath);
			if (floraManagerRef.GetUnlockPercentageForFlora(unlockInfoForFloraPath) >= 1f)
			{
				component.SetIsCompleted();
			}
			int num2 = j % floraPerRow;
			int num3 = Mathf.FloorToInt(j / floraPerRow);
			gameObject.transform.localPosition = new Vector3((float)num2 * floraListOffsetX, (float)num3 * floraListOffsetY);
			component.mainImageRef.sprite = dogGutsManagerRef.allFlora[j].gutFloraPreviewSprite;
			component.highlightImageRef.sprite = dogGutsManagerRef.allFlora[j].gutFloraPreviewSprite;
			if (!num)
			{
				component.mainImageRef.color = Color.black;
			}
			InchwormBounce component2 = gameObject.GetComponent<InchwormBounce>();
			component2.scaleTime = iconBounceTime;
			component2.startInvisible = true;
			component2.bounceStartDelay = bounceOffset * (float)objects[j];
			component2.RequestBounce();
			instantiatedFloraIcons.Add(gameObject);
			if (j % 2 == 0)
			{
				AudioController.Play(panelBubbleSound, 1f, bounceOffset * (float)objects[j]);
			}
		}
	}

	private void ClearFloraList()
	{
		for (int i = 0; i < instantiatedFloraIcons.Count; i++)
		{
			InchwormBounce component = instantiatedFloraIcons[i].GetComponent<InchwormBounce>();
			if (component != null)
			{
				component.StopBounce();
			}
			Object.Destroy(instantiatedFloraIcons[i]);
		}
		instantiatedFloraIcons.Clear();
	}

	private void ClearEffectsList()
	{
		for (int i = 0; i < instantiatedEffects.Count; i++)
		{
			Object.Destroy(instantiatedEffects[i]);
		}
		instantiatedEffects.Clear();
	}

	private void ClearOccurancesList()
	{
		for (int i = 0; i < instantiatedOccurances.Count; i++)
		{
			Object.Destroy(instantiatedOccurances[i]);
		}
		instantiatedOccurances.Clear();
	}

	private void CalculateAndUpdateCompletionPercentage()
	{
		float fieldGuideCompletionPercentage = floraManagerRef.GetFieldGuideCompletionPercentage();
		floraManagerRef.CheckFieldGuideComplete(fieldGuideCompletionPercentage);
		int num = Mathf.RoundToInt(fieldGuideCompletionPercentage * 100f);
		if (fieldGuideCompletionPercentage < 1f && num >= 100)
		{
			num = 99;
		}
		completionPercentageText.text = num + "%";
	}
}
