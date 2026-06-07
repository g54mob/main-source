using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceActivatedBuilding : GameplayObject, ISelectable, ISavable
{
	private const float DEACTIVATE_DELAY = 0.33f;

	[SerializeField]
	private List<ResourceActivatedGEData> recipes;

	[SerializeField]
	private bool autoSelectFirstRecipe = true;

	[SerializeField]
	[Savable("inputStorage", false, false)]
	private Storage_ResourceData inputStorage;

	private ResourceActivatedGEData selectedRecipe;

	[Savable("selectedRecipeId", true, false)]
	private string selectedRecipeId = "";

	private bool isActive;

	[Savable("savedIsActive", true, false)]
	private bool savedIsActive;

	private float currentDuration;

	[Savable("savedCurrentDuration", true, false)]
	private float savedCurrentDuration;

	private Coroutine activateCoroutine;

	private Coroutine stopAnimationCoroutine;

	private WaitForSeconds deactivationDealyWFS;

	private PlacementComponent placementComponent;

	private Dictionary<string, object> loadedData;

	public List<ResourceActivatedGEData> Recipes
	{
		get
		{
			return recipes;
		}
		set
		{
			recipes = value;
		}
	}

	public ResourceActivatedGEData SelectedRecipe => selectedRecipe;

	public Storage_ResourceData InputStorage => inputStorage;

	public PlacementComponent PlacementComponent => placementComponent;

	public float CurrentDuration
	{
		get
		{
			return currentDuration;
		}
		private set
		{
			currentDuration = value;
		}
	}

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			if (IsActive != value)
			{
				isActive = value;
				if (isActive)
				{
					OnActivate();
					this.onActivate?.Invoke(this);
				}
				else
				{
					OnDeactivate();
					this.onDeactivate?.Invoke(this);
				}
			}
		}
	}

	public event Action<ResourceActivatedBuilding> onActivate;

	public event Action<ResourceActivatedBuilding> onDeactivate;

	public event Action<ResourceActivatedGEData> onSelectedRecipeChanged;

	protected virtual void Awake()
	{
		placementComponent = GetComponentInParent<PlacementComponent>();
		inputStorage.Size = 0;
		inputStorage.StackSize = 0;
		deactivationDealyWFS = new WaitForSeconds(0.33f);
	}

	protected virtual void Start()
	{
		PlacementComponent.onPlace += OnPlace;
		PlacementComponent.onUnplace += OnUnplace;
		inputStorage.onStoreObject += OnInputStorageModified;
		Init();
	}

	private void Init()
	{
		EnableStorage(enabled: false);
		if (recipes == null)
		{
			recipes = new List<ResourceActivatedGEData>();
		}
		if (!SelectedRecipe && autoSelectFirstRecipe)
		{
			ChangeSelectedRecipe(recipes[0]);
		}
	}

	public bool ChangeSelectedRecipe(ResourceActivatedGEData recipe)
	{
		if (selectedRecipe == recipe)
		{
			return true;
		}
		if (recipes.Contains(recipe))
		{
			selectedRecipe = recipe;
			selectedRecipeId = selectedRecipe.Id;
			CurrentDuration = 0f;
			StopCurrentActivationCoroutine();
			EnableStorage(enabled: true);
			inputStorage.ClearFilters();
			Cost[] input = selectedRecipe.Input;
			foreach (Cost cost in input)
			{
				inputStorage.AddFilter(cost.Resource.Id, cost.Amount * 2);
			}
			this.onSelectedRecipeChanged?.Invoke(SelectedRecipe);
			return true;
		}
		EnableStorage(enabled: false);
		return false;
	}

	private bool TryActivate(bool checkIsActive)
	{
		if ((!checkIsActive || !IsActive) && (bool)selectedRecipe && CanProcessRecipe(selectedRecipe))
		{
			this.StartCoroutineCheckingVar(ActivateCoroutine(), ref activateCoroutine);
			return true;
		}
		return false;
	}

	private IEnumerator ActivateCoroutine(float starterCurrentDuration = 0f)
	{
		CurrentDuration = starterCurrentDuration;
		IsActive = true;
		this.onActivate?.Invoke(this);
		if (starterCurrentDuration == 0f)
		{
			Cost[] input = selectedRecipe.Input;
			foreach (Cost cost in input)
			{
				inputStorage.RemoveStoredObjectByID(cost.Resource.Id, cost.Amount);
			}
		}
		if (selectedRecipe.Duration > 0f)
		{
			while (CurrentDuration < selectedRecipe.Duration)
			{
				CurrentDuration += Time.deltaTime;
				yield return null;
			}
			yield return deactivationDealyWFS;
			activateCoroutine = null;
			if (!TryActivate(checkIsActive: false))
			{
				IsActive = false;
			}
		}
		else
		{
			EnableStorage(enabled: false);
			activateCoroutine = null;
		}
	}

	private void StopCurrentActivationCoroutine()
	{
		if (activateCoroutine != null)
		{
			this.StopCoroutineCheckingVar(ref activateCoroutine);
			activateCoroutine = null;
			CurrentDuration = 0f;
			IsActive = false;
		}
	}

	private bool CanProcessRecipe(ResourceActivatedGEData recipe)
	{
		return recipe.HasAllInputElements(inputStorage);
	}

	private void EnableStorage(bool enabled)
	{
		inputStorage.SendAllResourcesToInventory();
		if (enabled)
		{
			inputStorage.ClearFilters();
			Cost[] input = selectedRecipe.Input;
			foreach (Cost cost in input)
			{
				inputStorage.AddFilter(cost.Resource.Id, cost.Amount * 2);
			}
		}
		inputStorage.StorageEnabled = enabled;
	}

	protected virtual void OnActivate(bool playAnimation = true)
	{
		GameplayEffectsComponent component = LTFunctionLibrary.GetLTGameManager().PlayerCharacter.GetComponent<GameplayEffectsComponent>();
		GameplayEffectData[] geToApply = selectedRecipe.GeToApply;
		foreach (GameplayEffectData effectData in geToApply)
		{
			component.ApplyEffect(effectData);
		}
	}

	protected virtual void OnDeactivate()
	{
		GameplayEffectsComponent component = LTFunctionLibrary.GetLTGameManager().PlayerCharacter.GetComponent<GameplayEffectsComponent>();
		GameplayEffectData[] geToApply = selectedRecipe.GeToApply;
		foreach (GameplayEffectData effectData in geToApply)
		{
			component.RemoveEffect(effectData, 1);
		}
	}

	private void OnPlace(PlacementComponent placementComponent)
	{
	}

	private void OnUnplace(PlacementComponent placementComponent)
	{
		StopCurrentActivationCoroutine();
	}

	private void OnInputStorageModified(object obj, int storedAmount, string storeSourceID)
	{
		TryActivate(checkIsActive: true);
	}

	private void OnGameStarted()
	{
		if (selectedRecipeId != "")
		{
			ChangeSelectedRecipe(recipes.Find((ResourceActivatedGEData x) => x.Id == selectedRecipeId));
		}
		if (loadedData.ContainsKey("inputStorage"))
		{
			SaveSystem.LoadObjectData(inputStorage, loadedData["inputStorage"] as Dictionary<string, object>);
		}
		if (savedCurrentDuration > 0f)
		{
			this.StartCoroutineCheckingVar(ActivateCoroutine(savedCurrentDuration), ref activateCoroutine);
		}
		else if ((bool)selectedRecipe && selectedRecipe.Duration <= 0f && savedIsActive)
		{
			IsActive = true;
			EnableStorage(enabled: false);
		}
	}

	public void Select()
	{
	}

	public void Deselect()
	{
	}

	public override void OnSave()
	{
		base.OnSave();
		savedCurrentDuration = CurrentDuration;
		savedIsActive = IsActive;
	}

	public override void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		base.OnLoad(data, hasLoadedSomething);
		if (hasLoadedSomething)
		{
			loadedData = data;
			if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
			{
				OnGameStarted();
				return;
			}
			LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
			lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(OnGameStarted));
		}
	}
}
