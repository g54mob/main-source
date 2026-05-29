using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SoulGames.EasyGridBuilderPro
{
	public class MultiGridUIManager : MonoBehaviour
	{
		private delegate void OnCategoryButtonPressedDelegate(string buttonName);

		private delegate void OnBuildablesButtonPressedDelegate(string buttonName);

		private List<EasyGridBuilderPro> easyGridBuilderProList;

		private GridObjectSelector gridObjectSelector;

		private EasyGridBuilderProInputsSO gridBuilderProInputsSO;

		private EasyGridBuilderPro currentActiveSystem;

		private bool animationOpenTrigger;

		private bool animationCloseTrigger = true;

		[Space]
		[Tooltip("Add 'BuildableObjectTypeCategorySO' assets. Used to display buildable object categories in UI.")]
		[SerializeField]
		private List<BuildableObjectTypeCategorySO> buildableObjectTypeCategorySO;

		[SerializeField]
		public bool showBuildableListMenuData;

		[Space]
		[Tooltip("Displays build list menu in grid mode default")]
		[SerializeField]
		private bool showInGridModeDefault;

		[Tooltip("Displays build list menu in grid mode build")]
		[SerializeField]
		private bool showInGridModeBuild;

		[Tooltip("Displays build list menu in grid mode destruction")]
		[SerializeField]
		private bool showInGridModeDestruction;

		[Tooltip("Displays build list menu in grid mode selection")]
		[SerializeField]
		private bool showInGridModeSelection;

		private List<BuildableGridObjectTypeSO> buildableGridObjectTypeSOList;

		private List<BuildableEdgeObjectTypeSO> buildableEdgeObjectTypeSOList;

		private List<BuildableFreeObjectTypeSO> buildableFreeObjectTypeSOList;

		[SerializeField]
		public bool showHelpMenuData;

		[Space]
		[SerializeField]
		private GameObject inputGroupObject;

		[SerializeField]
		private TextMeshProUGUI gridModeResetText;

		[SerializeField]
		private TextMeshProUGUI gridHeightChangeText;

		[SerializeField]
		private TextMeshProUGUI buildModeActiveText;

		[SerializeField]
		private TextMeshProUGUI placementText;

		[SerializeField]
		private TextMeshProUGUI listScrollText;

		[SerializeField]
		private TextMeshProUGUI ghostRotateLText;

		[SerializeField]
		private TextMeshProUGUI ghostRotateRText;

		[SerializeField]
		private TextMeshProUGUI destructionModeActiveText;

		[SerializeField]
		private TextMeshProUGUI destroyText;

		[SerializeField]
		private TextMeshProUGUI selectionModeActiveText;

		[SerializeField]
		private TextMeshProUGUI selectionText;

		[SerializeField]
		private TextMeshProUGUI saveText;

		[SerializeField]
		private TextMeshProUGUI loadText;

		[SerializeField]
		public bool showBuildablesMenuData;

		[Space]
		[SerializeField]
		private GameObject categorySection;

		[SerializeField]
		private GameObject buildablesSection;

		[SerializeField]
		private GameObject placeHolderCategory;

		[SerializeField]
		private GameObject placeHolderBuildable;

		[SerializeField]
		private GameObject placeHolderBuildableSectionCategory;

		[SerializeField]
		private Animator buildableListAnimator;

		[SerializeField]
		public bool showVerticalGridMenuData;

		[Space]
		[SerializeField]
		private GameObject gridLevelUpButton;

		[SerializeField]
		private GameObject gridLevelDownButton;

		private List<GameObject> instantiatedCategoryObjectsList = new List<GameObject>();

		private List<GameObject> instantiatedBuildableObjectsList = new List<GameObject>();

		private List<GameObject> instantiatedBuildableSectionCategoryList = new List<GameObject>();

		private event OnCategoryButtonPressedDelegate OnCategoryButtonPressed;

		private event OnBuildablesButtonPressedDelegate OnBuildablesButtonPressed;

		private void Start()
		{
			easyGridBuilderProList = MultiGridManager.Instance.easyGridBuilderProList;
			currentActiveSystem = MultiGridManager.Instance.activeGridSystem;
			if ((bool)UnityEngine.Object.FindObjectOfType<GridObjectSelector>())
			{
				gridObjectSelector = UnityEngine.Object.FindObjectOfType<GridObjectSelector>();
			}
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.SetInputGridModeVariables(useBuildModeActivationKey: true, useDestructionModeActivationKey: true, useSelectionModeActivationKey: true);
				easyGridBuilderPro.OnBuildableGridObjectTypeSOListChange += OnBuildableGridObjectTypeSOListChangeMethod;
				easyGridBuilderPro.OnBuildableEdgeObjectTypeSOListChange += OnBuildableEdgeObjectTypeSOListChangeMethod;
				easyGridBuilderPro.OnBuildableFreeObjectTypeSOListChange += OnBuildableFreeObjectTypeSOListChangeMethod;
				easyGridBuilderPro.OnGridModeChange += OnGridModeChangeMethod;
			}
			if ((bool)gridObjectSelector)
			{
				gridObjectSelector.SetInputGridModeVariables(useBuildModeActivationKey: true, useDestructionModeActivationKey: true, useSelectionModeActivationKey: true);
			}
			gridBuilderProInputsSO = MultiGridInputManager.Instance.GetEasyGridBuilderProInputsSO();
			MultiGridManager.Instance.OnActiveGridChanged += OnActiveGridChangedMethod;
			OnCategoryButtonPressed += OnCategoryButtonPressedMethod;
			OnBuildablesButtonPressed += OnBuildablesButtonPressedMethod;
			buildableGridObjectTypeSOList = new List<BuildableGridObjectTypeSO>();
			buildableEdgeObjectTypeSOList = new List<BuildableEdgeObjectTypeSO>();
			buildableFreeObjectTypeSOList = new List<BuildableFreeObjectTypeSO>();
			HandleCategorySection();
			if ((bool)instantiatedBuildableSectionCategoryList[0] && !instantiatedBuildableSectionCategoryList[0].activeSelf)
			{
				instantiatedBuildableSectionCategoryList[0].SetActive(value: true);
			}
			if (showInGridModeDefault)
			{
				if (currentActiveSystem.GetGridMode() == GridMode.None && !animationOpenTrigger)
				{
					buildableListAnimator.SetTrigger("Open");
					animationOpenTrigger = true;
					animationCloseTrigger = false;
				}
			}
			else if (currentActiveSystem.GetGridMode() == GridMode.None && !animationCloseTrigger)
			{
				buildableListAnimator.SetTrigger("Close");
				animationOpenTrigger = false;
				animationCloseTrigger = true;
			}
			HandleBuildablesListSection();
			if (currentActiveSystem.gridEditorMode == GridEditorMode.GridLite)
			{
				if (gridLevelUpButton.activeSelf)
				{
					gridLevelUpButton.SetActive(value: false);
				}
				if (gridLevelDownButton.activeSelf)
				{
					gridLevelDownButton.SetActive(value: false);
				}
			}
			else if (currentActiveSystem.gridEditorMode == GridEditorMode.GridPro)
			{
				if (!gridLevelUpButton.activeSelf)
				{
					gridLevelUpButton.SetActive(value: true);
				}
				if (!gridLevelDownButton.activeSelf)
				{
					gridLevelDownButton.SetActive(value: true);
				}
			}
			else
			{
				if (gridLevelUpButton.activeSelf)
				{
					gridLevelUpButton.SetActive(value: false);
				}
				if (gridLevelDownButton.activeSelf)
				{
					gridLevelDownButton.SetActive(value: false);
				}
			}
		}

		private void OnDisable()
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.OnBuildableGridObjectTypeSOListChange -= OnBuildableGridObjectTypeSOListChangeMethod;
				easyGridBuilderPro.OnBuildableEdgeObjectTypeSOListChange -= OnBuildableEdgeObjectTypeSOListChangeMethod;
				easyGridBuilderPro.OnBuildableFreeObjectTypeSOListChange -= OnBuildableFreeObjectTypeSOListChangeMethod;
				easyGridBuilderPro.OnGridModeChange -= OnGridModeChangeMethod;
			}
			MultiGridManager.Instance.OnActiveGridChanged -= OnActiveGridChangedMethod;
			OnCategoryButtonPressed -= OnCategoryButtonPressedMethod;
			OnBuildablesButtonPressed -= OnBuildablesButtonPressedMethod;
		}

		private void Update()
		{
			currentActiveSystem = MultiGridManager.Instance.activeGridSystem;
			HandleHelpMenuInputs();
		}

		public void BuildButton()
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.SetGridModeBuilding();
			}
		}

		public void DestroyButton()
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.SetGridModeDestruction();
			}
		}

		public void SelectionButton()
		{
			gridObjectSelector.SetGridModeSelection();
		}

		public void SaveButton()
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGridSave();
			}
		}

		public void LoadButton()
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGridLoad();
			}
		}

		private void HandleHelpMenuInputs()
		{
			if (inputGroupObject.activeSelf)
			{
				if ((bool)gridModeResetText)
				{
					gridModeResetText.text = gridBuilderProInputsSO.gridModeResetKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					gridHeightChangeText.text = gridBuilderProInputsSO.gridHeightChangeKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					buildModeActiveText.text = gridBuilderProInputsSO.buildModeActivationKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					placementText.text = gridBuilderProInputsSO.buildablePlacementKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					listScrollText.text = gridBuilderProInputsSO.buildableListScrollKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					ghostRotateLText.text = gridBuilderProInputsSO.ghostRotateLeftKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					ghostRotateRText.text = gridBuilderProInputsSO.ghostRotateRightKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					destructionModeActiveText.text = gridBuilderProInputsSO.destructionModeActivationKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					destroyText.text = gridBuilderProInputsSO.buildableDestroyKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					selectionModeActiveText.text = gridBuilderProInputsSO.selectionModeActivationKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					selectionText.text = gridBuilderProInputsSO.buildableSelectionKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					saveText.text = gridBuilderProInputsSO.gridSaveKey.bindings[0].ToDisplayString();
				}
				if ((bool)gridModeResetText)
				{
					loadText.text = gridBuilderProInputsSO.gridLoadKey.bindings[0].ToDisplayString();
				}
			}
		}

		private void HandleCategorySection()
		{
			foreach (BuildableObjectTypeCategorySO item in buildableObjectTypeCategorySO)
			{
				if ((bool)categorySection && (bool)placeHolderCategory)
				{
					Transform categoryObject = UnityEngine.Object.Instantiate(placeHolderCategory, Vector3.zero, Quaternion.identity).transform;
					categoryObject.SetParent(categorySection.transform, worldPositionStays: false);
					categoryObject.position = Vector3.zero;
					categoryObject.gameObject.name = item.categoryName;
					categoryObject.GetChild(0).GetComponent<Image>().sprite = item.categoryIcon;
					Transform transform = UnityEngine.Object.Instantiate(placeHolderBuildableSectionCategory, Vector3.zero, Quaternion.identity).transform;
					transform.SetParent(buildablesSection.transform, worldPositionStays: false);
					transform.position = buildablesSection.transform.position;
					transform.gameObject.name = item.categoryName;
					transform.gameObject.SetActive(value: false);
					instantiatedCategoryObjectsList.Add(categoryObject.gameObject);
					instantiatedBuildableSectionCategoryList.Add(transform.gameObject);
					categoryObject.GetComponent<Button>().onClick.AddListener(delegate
					{
						this.OnCategoryButtonPressed(categoryObject.name);
					});
				}
			}
		}

		private void OnCategoryButtonPressedMethod(string buttonName)
		{
			foreach (GameObject instantiatedBuildableSectionCategory in instantiatedBuildableSectionCategoryList)
			{
				if (!(buttonName == instantiatedBuildableSectionCategory.name))
				{
					continue;
				}
				foreach (GameObject instantiatedBuildableSectionCategory2 in instantiatedBuildableSectionCategoryList)
				{
					if (instantiatedBuildableSectionCategory2.name == instantiatedBuildableSectionCategory.name)
					{
						if (!instantiatedBuildableSectionCategory2.activeSelf)
						{
							instantiatedBuildableSectionCategory2.SetActive(value: true);
						}
					}
					else if (instantiatedBuildableSectionCategory2.activeSelf)
					{
						instantiatedBuildableSectionCategory2.SetActive(value: false);
					}
				}
			}
		}

		private void OnGridModeChangeMethod(object sender, EventArgs e)
		{
			if (showInGridModeDefault)
			{
				if (currentActiveSystem.GetGridMode() == GridMode.None && !animationOpenTrigger)
				{
					buildableListAnimator.SetTrigger("Open");
					animationOpenTrigger = true;
					animationCloseTrigger = false;
				}
			}
			else if (currentActiveSystem.GetGridMode() == GridMode.None && !animationCloseTrigger)
			{
				buildableListAnimator.SetTrigger("Close");
				animationOpenTrigger = false;
				animationCloseTrigger = true;
			}
			if (showInGridModeBuild)
			{
				if (currentActiveSystem.GetGridMode() == GridMode.Build && !animationOpenTrigger)
				{
					buildableListAnimator.SetTrigger("Open");
					animationOpenTrigger = true;
					animationCloseTrigger = false;
				}
			}
			else if (currentActiveSystem.GetGridMode() == GridMode.Build && !animationCloseTrigger)
			{
				buildableListAnimator.SetTrigger("Close");
				animationOpenTrigger = false;
				animationCloseTrigger = true;
			}
			if (showInGridModeDestruction)
			{
				if (currentActiveSystem.GetGridMode() == GridMode.Destruct && !animationOpenTrigger)
				{
					buildableListAnimator.SetTrigger("Open");
					animationOpenTrigger = true;
					animationCloseTrigger = false;
				}
			}
			else if (currentActiveSystem.GetGridMode() == GridMode.Destruct && !animationCloseTrigger)
			{
				buildableListAnimator.SetTrigger("Close");
				animationOpenTrigger = false;
				animationCloseTrigger = true;
			}
			if (showInGridModeSelection)
			{
				if (currentActiveSystem.GetGridMode() == GridMode.Selected && !animationOpenTrigger)
				{
					buildableListAnimator.SetTrigger("Open");
					animationOpenTrigger = true;
					animationCloseTrigger = false;
				}
			}
			else if (currentActiveSystem.GetGridMode() == GridMode.Selected && !animationCloseTrigger)
			{
				buildableListAnimator.SetTrigger("Close");
				animationOpenTrigger = false;
				animationCloseTrigger = true;
			}
		}

		private void HandleBuildablesListSection()
		{
			buildableGridObjectTypeSOList = currentActiveSystem.GetBuildableGridObjectTypeSOList();
			buildableEdgeObjectTypeSOList = currentActiveSystem.GetBuildableEdgeObjectTypeSOList();
			buildableFreeObjectTypeSOList = currentActiveSystem.GetBuildableFreeObjectTypeSOList();
			ClearInstantiatedBuildableObjectsList();
			foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO in buildableGridObjectTypeSOList)
			{
				CreateBuidableGridGameObject(buildableGridObjectTypeSO);
			}
			foreach (BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO in buildableEdgeObjectTypeSOList)
			{
				CreateBuidableEdgeGameObject(buildableEdgeObjectTypeSO);
			}
			foreach (BuildableFreeObjectTypeSO buildableFreeObjectTypeSO in buildableFreeObjectTypeSOList)
			{
				CreateBuidableFreeGameObject(buildableFreeObjectTypeSO);
			}
		}

		private void OnBuildableGridObjectTypeSOListChangeMethod()
		{
			buildableGridObjectTypeSOList = currentActiveSystem.GetBuildableGridObjectTypeSOList();
			buildableEdgeObjectTypeSOList = currentActiveSystem.GetBuildableEdgeObjectTypeSOList();
			buildableFreeObjectTypeSOList = currentActiveSystem.GetBuildableFreeObjectTypeSOList();
			ClearInstantiatedBuildableObjectsList();
			foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO in buildableGridObjectTypeSOList)
			{
				CreateBuidableGridGameObject(buildableGridObjectTypeSO);
			}
			foreach (BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO in buildableEdgeObjectTypeSOList)
			{
				CreateBuidableEdgeGameObject(buildableEdgeObjectTypeSO);
			}
			foreach (BuildableFreeObjectTypeSO buildableFreeObjectTypeSO in buildableFreeObjectTypeSOList)
			{
				CreateBuidableFreeGameObject(buildableFreeObjectTypeSO);
			}
		}

		private void OnBuildableEdgeObjectTypeSOListChangeMethod()
		{
			buildableGridObjectTypeSOList = currentActiveSystem.GetBuildableGridObjectTypeSOList();
			buildableEdgeObjectTypeSOList = currentActiveSystem.GetBuildableEdgeObjectTypeSOList();
			buildableFreeObjectTypeSOList = currentActiveSystem.GetBuildableFreeObjectTypeSOList();
			ClearInstantiatedBuildableObjectsList();
			foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO in buildableGridObjectTypeSOList)
			{
				CreateBuidableGridGameObject(buildableGridObjectTypeSO);
			}
			foreach (BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO in buildableEdgeObjectTypeSOList)
			{
				CreateBuidableEdgeGameObject(buildableEdgeObjectTypeSO);
			}
			foreach (BuildableFreeObjectTypeSO buildableFreeObjectTypeSO in buildableFreeObjectTypeSOList)
			{
				CreateBuidableFreeGameObject(buildableFreeObjectTypeSO);
			}
		}

		private void OnBuildableFreeObjectTypeSOListChangeMethod()
		{
			buildableGridObjectTypeSOList = currentActiveSystem.GetBuildableGridObjectTypeSOList();
			buildableEdgeObjectTypeSOList = currentActiveSystem.GetBuildableEdgeObjectTypeSOList();
			buildableFreeObjectTypeSOList = currentActiveSystem.GetBuildableFreeObjectTypeSOList();
			ClearInstantiatedBuildableObjectsList();
			foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO in buildableGridObjectTypeSOList)
			{
				CreateBuidableGridGameObject(buildableGridObjectTypeSO);
			}
			foreach (BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO in buildableEdgeObjectTypeSOList)
			{
				CreateBuidableEdgeGameObject(buildableEdgeObjectTypeSO);
			}
			foreach (BuildableFreeObjectTypeSO buildableFreeObjectTypeSO in buildableFreeObjectTypeSOList)
			{
				CreateBuidableFreeGameObject(buildableFreeObjectTypeSO);
			}
		}

		private void OnActiveGridChangedMethod(EasyGridBuilderPro currentActiveSystem)
		{
			this.currentActiveSystem = currentActiveSystem;
			buildableGridObjectTypeSOList = currentActiveSystem.GetBuildableGridObjectTypeSOList();
			buildableEdgeObjectTypeSOList = currentActiveSystem.GetBuildableEdgeObjectTypeSOList();
			buildableFreeObjectTypeSOList = currentActiveSystem.GetBuildableFreeObjectTypeSOList();
			ClearInstantiatedBuildableObjectsList();
			foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO in buildableGridObjectTypeSOList)
			{
				CreateBuidableGridGameObject(buildableGridObjectTypeSO);
			}
			foreach (BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO in buildableEdgeObjectTypeSOList)
			{
				CreateBuidableEdgeGameObject(buildableEdgeObjectTypeSO);
			}
			foreach (BuildableFreeObjectTypeSO buildableFreeObjectTypeSO in buildableFreeObjectTypeSOList)
			{
				CreateBuidableFreeGameObject(buildableFreeObjectTypeSO);
			}
			if (currentActiveSystem.gridEditorMode == GridEditorMode.GridLite)
			{
				if (gridLevelUpButton.activeSelf)
				{
					gridLevelUpButton.SetActive(value: false);
				}
				if (gridLevelDownButton.activeSelf)
				{
					gridLevelDownButton.SetActive(value: false);
				}
			}
			else if (currentActiveSystem.gridEditorMode == GridEditorMode.GridPro)
			{
				if (!gridLevelUpButton.activeSelf)
				{
					gridLevelUpButton.SetActive(value: true);
				}
				if (!gridLevelDownButton.activeSelf)
				{
					gridLevelDownButton.SetActive(value: true);
				}
			}
			else
			{
				if (gridLevelUpButton.activeSelf)
				{
					gridLevelUpButton.SetActive(value: false);
				}
				if (gridLevelDownButton.activeSelf)
				{
					gridLevelDownButton.SetActive(value: false);
				}
			}
		}

		private void CreateBuidableGridGameObject(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			if (!buildablesSection || !placeHolderBuildable)
			{
				return;
			}
			Transform buildableObject = UnityEngine.Object.Instantiate(placeHolderBuildable, Vector3.zero, Quaternion.identity).transform;
			foreach (GameObject instantiatedBuildableSectionCategory in instantiatedBuildableSectionCategoryList)
			{
				if (buildableGridObjectTypeSO.buildableCategorySO.categoryName == instantiatedBuildableSectionCategory.name)
				{
					buildableObject.SetParent(instantiatedBuildableSectionCategory.transform, worldPositionStays: false);
					buildableObject.position = Vector3.zero;
					buildableObject.gameObject.name = buildableGridObjectTypeSO.objectName;
					buildableObject.GetChild(0).GetComponent<Image>().sprite = buildableGridObjectTypeSO.objectIcon;
					if (buildableGridObjectTypeSO.enableBuildCondition && (bool)buildableGridObjectTypeSO.buildConditionSO && (bool)buildableObject.GetComponent<UIBuildableSODataContainer>())
					{
						buildableObject.GetComponent<UIBuildableSODataContainer>().SetBuildConditionToolTipContent(buildableGridObjectTypeSO.buildConditionSO.tooltipContent);
					}
				}
			}
			instantiatedBuildableObjectsList.Add(buildableObject.gameObject);
			buildableObject.GetComponent<Button>().onClick.AddListener(delegate
			{
				this.OnBuildablesButtonPressed(buildableObject.name);
			});
		}

		private void CreateBuidableEdgeGameObject(BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO)
		{
			if (!buildablesSection || !placeHolderBuildable)
			{
				return;
			}
			Transform buildableObject = UnityEngine.Object.Instantiate(placeHolderBuildable, Vector3.zero, Quaternion.identity).transform;
			foreach (GameObject instantiatedBuildableSectionCategory in instantiatedBuildableSectionCategoryList)
			{
				if (buildableEdgeObjectTypeSO.buildableCategorySO.categoryName == instantiatedBuildableSectionCategory.name)
				{
					buildableObject.SetParent(instantiatedBuildableSectionCategory.transform, worldPositionStays: false);
					buildableObject.position = Vector3.zero;
					buildableObject.gameObject.name = buildableEdgeObjectTypeSO.objectName;
					buildableObject.GetChild(0).GetComponent<Image>().sprite = buildableEdgeObjectTypeSO.objectIcon;
					if (buildableEdgeObjectTypeSO.enableBuildCondition && (bool)buildableEdgeObjectTypeSO.buildConditionSO && (bool)buildableObject.GetComponent<UIBuildableSODataContainer>())
					{
						buildableObject.GetComponent<UIBuildableSODataContainer>().SetBuildConditionToolTipContent(buildableEdgeObjectTypeSO.buildConditionSO.tooltipContent);
					}
				}
			}
			instantiatedBuildableObjectsList.Add(buildableObject.gameObject);
			buildableObject.GetComponent<Button>().onClick.AddListener(delegate
			{
				this.OnBuildablesButtonPressed(buildableObject.name);
			});
		}

		private void CreateBuidableFreeGameObject(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO)
		{
			if (!buildablesSection || !placeHolderBuildable)
			{
				return;
			}
			Transform buildableObject = UnityEngine.Object.Instantiate(placeHolderBuildable, Vector3.zero, Quaternion.identity).transform;
			foreach (GameObject instantiatedBuildableSectionCategory in instantiatedBuildableSectionCategoryList)
			{
				if (buildableFreeObjectTypeSO.buildableCategorySO.categoryName == instantiatedBuildableSectionCategory.name)
				{
					buildableObject.SetParent(instantiatedBuildableSectionCategory.transform, worldPositionStays: false);
					buildableObject.position = Vector3.zero;
					buildableObject.gameObject.name = buildableFreeObjectTypeSO.objectName;
					buildableObject.GetChild(0).GetComponent<Image>().sprite = buildableFreeObjectTypeSO.objectIcon;
					if (buildableFreeObjectTypeSO.enableBuildCondition && (bool)buildableFreeObjectTypeSO.buildConditionSO && (bool)buildableObject.GetComponent<UIBuildableSODataContainer>())
					{
						buildableObject.GetComponent<UIBuildableSODataContainer>().SetBuildConditionToolTipContent(buildableFreeObjectTypeSO.buildConditionSO.tooltipContent);
					}
				}
			}
			instantiatedBuildableObjectsList.Add(buildableObject.gameObject);
			buildableObject.GetComponent<Button>().onClick.AddListener(delegate
			{
				this.OnBuildablesButtonPressed(buildableObject.name);
			});
		}

		private void ClearInstantiatedBuildableObjectsList()
		{
			foreach (GameObject instantiatedBuildableObjects in instantiatedBuildableObjectsList)
			{
				UnityEngine.Object.Destroy(instantiatedBuildableObjects);
			}
			instantiatedBuildableObjectsList.Clear();
		}

		private void OnBuildablesButtonPressedMethod(string buttonName)
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerBuildableListUI(buttonName);
			}
		}

		public void TriggerVerticalGridUp()
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGridHeightChangeUI(new Vector2(1f, 1f));
			}
		}

		public void TriggerVerticalGridDown()
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.TriggerGridHeightChangeUI(new Vector2(-1f, -1f));
			}
		}
	}
}
