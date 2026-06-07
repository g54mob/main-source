using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsComponent))]
public class Processor : GameplayObject, ISelectable, ISampleableData, ISavable
{
	private const float AUX_SPEED = 0.001f;

	private const float STOP_ANIMATION_DELAY = 0.25f;

	[SerializeField]
	private List<Recipe> recipes;

	private Recipe selectedRecipe;

	[Savable("selectedRecipeId", true, false)]
	private string selectedRecipeId;

	private float processingSpeed;

	private Coroutine processRecipeCoroutine;

	private Coroutine stopAnimationCoroutine;

	private WaitForSeconds stopAnimationWFS;

	[SerializeField]
	private bool usePlayerStorage;

	[SerializeField]
	[Savable("outputStorage", true, false)]
	private Storage_ResourceData outputStorage;

	[SerializeField]
	[Savable("inputStorage", true, false)]
	private Storage_ResourceData inputStorage;

	[SerializeField]
	private ConveyorBelt[] conveyorBelts;

	private Animator animator;

	private PlacementComponent placementComponent;

	private StatsComponent statsComponent;

	private GameplayEffectsComponent gameplayEffectsComponent;

	public List<Recipe> Recipes => recipes;

	public Recipe SelectedRecipe => selectedRecipe;

	public Storage_ResourceData InputStorage => inputStorage;

	public PlacementComponent PlacementComponent => placementComponent;

	public bool UsePlayerStorage => usePlayerStorage;

	public float CurrentProcessingRecipeTime { get; private set; }

	public Storage_ResourceData OutputStorage
	{
		get
		{
			if (UsePlayerStorage)
			{
				return LTFunctionLibrary.GetPlayerInventory();
			}
			return outputStorage;
		}
	}

	public float ProcessingSpeed
	{
		get
		{
			return processingSpeed;
		}
		set
		{
			processingSpeed = value;
		}
	}

	public float InternalProcessingSpeed => processingSpeed + 0.001f;

	public event Action<Processor> onStartProcessing;

	public event Action<Processor> onStopProcessing;

	public event Action onStartProcessingAnimation;

	public event Action onStopProcessingAnimation;

	public event Action<Recipe> onSelectedRecipeChanged;

	protected virtual void Awake()
	{
		animator = GetComponent<Animator>();
		placementComponent = GetComponentInParent<PlacementComponent>();
		statsComponent = GetComponent<StatsComponent>();
		gameplayEffectsComponent = GetComponent<GameplayEffectsComponent>();
		inputStorage.Size = 0;
		inputStorage.StackSize = 0;
		if ((bool)outputStorage)
		{
			outputStorage.Size = 0;
			outputStorage.StackSize = 0;
		}
		UpdateProcessingSpeed(statsComponent.GetStat(EStats.Speed));
		stopAnimationWFS = new WaitForSeconds(0.25f);
	}

	private void Start()
	{
		PlacementComponent.onPlace += OnPlace;
		PlacementComponent.onUnplace += OnUnplace;
		statsComponent.onStatChanged += OnStatChanged;
		OnStatChanged(EStats.Speed, statsComponent.GetStat(EStats.Speed), 0f);
		gameplayEffectsComponent.onEffectAdded += OnEffectAdded;
		gameplayEffectsComponent.onEffectRemoved += OnEffectRemoved;
		inputStorage.onStoreObject += OnInputStorageModified;
		if ((bool)outputStorage)
		{
			outputStorage.onRemoveObject += OnOutputStorageModified;
		}
		InitProcessor();
	}

	private void InitProcessor()
	{
		if (recipes == null)
		{
			recipes = new List<Recipe>();
		}
		if (!SelectedRecipe)
		{
			ChangeSelectedRecipe(recipes[0]);
		}
	}

	public bool ChangeSelectedRecipe(Recipe recipe, bool keepStoragedResources = false)
	{
		if (selectedRecipe == recipe)
		{
			return true;
		}
		if (recipes.Contains(recipe))
		{
			selectedRecipe = recipe;
			selectedRecipeId = selectedRecipe.RecipeId;
			CurrentProcessingRecipeTime = 0f;
			StopCurrentProcessingCoroutine();
			if (!keepStoragedResources)
			{
				inputStorage.SendAllResourcesToInventory();
				if ((bool)outputStorage)
				{
					outputStorage.SendAllResourcesToInventory();
				}
			}
			inputStorage.ClearFilters();
			Cost[] input = selectedRecipe.Input;
			foreach (Cost cost in input)
			{
				inputStorage.AddFilter(cost.Resource.Id, cost.Amount * 2);
			}
			if ((bool)outputStorage)
			{
				outputStorage.Size = 1;
				outputStorage.StackSize = selectedRecipe.Output.Amount * 2;
			}
			this.onSelectedRecipeChanged?.Invoke(SelectedRecipe);
			return true;
		}
		return false;
	}

	private bool TryStartProcessRecipe()
	{
		if (processRecipeCoroutine == null && (bool)selectedRecipe && CanProcessRecipe(selectedRecipe))
		{
			CurrentProcessingRecipeTime = 0f;
			this.StartCoroutineCheckingVar(ProcessRecipeCoroutine(), ref processRecipeCoroutine);
			return true;
		}
		if ((bool)animator && processRecipeCoroutine == null)
		{
			this.StartCoroutineCheckingVar(StopAnimationCoroutine(), ref stopAnimationCoroutine);
		}
		return false;
	}

	private IEnumerator ProcessRecipeCoroutine()
	{
		this.onStartProcessing?.Invoke(this);
		if ((bool)animator)
		{
			this.StopCoroutineCheckingVar(ref stopAnimationCoroutine);
			animator.ResetTrigger("Stop");
			animator.SetTrigger("Start");
			this.onStartProcessingAnimation?.Invoke();
			yield return null;
		}
		while (CurrentProcessingRecipeTime < selectedRecipe.ProcessingTime)
		{
			CurrentProcessingRecipeTime += Time.deltaTime * InternalProcessingSpeed;
			yield return null;
		}
		StoreRecipe();
		processRecipeCoroutine = null;
		this.onStopProcessing?.Invoke(this);
		TryStartProcessRecipe();
	}

	protected virtual void StoreRecipe()
	{
		Cost[] input = selectedRecipe.Input;
		foreach (Cost cost in input)
		{
			inputStorage.RemoveStoredObjectByID(cost.Resource.Id, cost.Amount);
		}
		OutputStorage.StoreObject(selectedRecipe.Output.Resource, selectedRecipe.Output.Amount, Storage_ResourceData.EStoreSource.Production);
	}

	private void StopCurrentProcessingCoroutine()
	{
		if (processRecipeCoroutine != null)
		{
			this.StopCoroutineCheckingVar(ref processRecipeCoroutine);
			if ((bool)animator)
			{
				animator.ResetTrigger("Start");
				animator.SetTrigger("Stop");
				this.onStopProcessingAnimation?.Invoke();
			}
			processRecipeCoroutine = null;
			CurrentProcessingRecipeTime = 0f;
			this.onStopProcessing?.Invoke(this);
		}
	}

	private IEnumerator StopAnimationCoroutine()
	{
		yield return stopAnimationWFS;
		animator.ResetTrigger("Start");
		animator.SetTrigger("Stop");
		this.onStopProcessingAnimation?.Invoke();
		stopAnimationCoroutine = null;
	}

	private bool CanProcessRecipe(Recipe recipe)
	{
		if (recipe.HasAllRecipeElements(inputStorage))
		{
			return OutputStorage.CanStore(selectedRecipe.Output.Resource.Id, selectedRecipe.Output.Amount);
		}
		return false;
	}

	private void UpdateProcessingSpeed(float statSpeed)
	{
		ProcessingSpeed = statSpeed;
		animator.speed = statSpeed / statsComponent.GetStatBase(EStats.Speed);
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.Speed)
		{
			UpdateProcessingSpeed(newValue);
		}
	}

	private void OnEffectAdded(GameplayEffect effect)
	{
		ConveyorBelt[] array = conveyorBelts;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GameplayEffectsComponent.ApplyEffect(effect.EffectData);
		}
	}

	private void OnEffectRemoved(GameplayEffect effect)
	{
		ConveyorBelt[] array = conveyorBelts;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GameplayEffectsComponent.RemoveEffect(effect.EffectData);
		}
	}

	private void OnPlace(PlacementComponent placementComponent)
	{
	}

	private void OnUnplace(PlacementComponent placementComponent)
	{
		StopCurrentProcessingCoroutine();
	}

	private void OnInputStorageModified(object obj, int storedAmount, string storeSourceID)
	{
		TryStartProcessRecipe();
	}

	private void OnOutputStorageModified(Storage<ResourceData>.StoredObjectData storedObject, int removedAmount)
	{
		if (processRecipeCoroutine == null)
		{
			TryStartProcessRecipe();
		}
	}

	public void Select()
	{
	}

	public void Deselect()
	{
	}

	public Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object> { { "selectedRecipe", SelectedRecipe } };
	}

	public void SetData(Dictionary<string, object> data)
	{
		ChangeSelectedRecipe((Recipe)data["selectedRecipe"]);
	}

	private IEnumerator LoadCoroutine()
	{
		yield return new WaitForSeconds(UnityEngine.Random.Range(0f, 1f));
		TryStartProcessRecipe();
	}

	public override void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		base.OnLoad(data, hasLoadedSomething);
		if (hasLoadedSomething)
		{
			ChangeSelectedRecipe(recipes.Find((Recipe x) => x.RecipeId == selectedRecipeId), keepStoragedResources: true);
			StartCoroutine(LoadCoroutine());
		}
	}
}
