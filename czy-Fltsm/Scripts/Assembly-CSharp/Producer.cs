using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Construction))]
public class Producer : BuildableExtendableBase, IEnergyGridConsumer, IEnergyGridComponent, IItemProducer, IBlockingProjectProvider, IPersistentReference
{
	public enum Type
	{
		Workshop = 0,
		Farm = 1
	}

	public enum ContinuousMode
	{
		Single = 0,
		SingleFillQueue = 1,
		Multiple = 2
	}

	public class Recipe : IComparable<Recipe>
	{
		private int _persistedQueueIndex = int.MaxValue;

		public Producer Producer { get; private set; }

		public int Index { get; private set; }

		public ProductionRecipeProperties Properties { get; private set; }

		public int AmountToProduce { get; private set; }

		public IReadOnlyList<CountedItemProperty> Ingredients => Properties.RequiredItems;

		public IReadOnlyList<CountedItemProperty> ProducedItems => Properties.ProducedItems;

		public bool IsContinuous => AmountToProduce < 0;

		public bool IsPrioritized { get; private set; }

		public List<PlaceableAlertProperties> Malfunctions { get; private set; } = new List<PlaceableAlertProperties>();

		public Recipe(Producer producer, int index, ProductionRecipeProperties properties)
		{
			Producer = producer;
			Index = index;
			Properties = properties;
		}

		public void SetAmountToProduce(int amount)
		{
			AmountToProduce = Mathf.Clamp(amount, 0, 99);
		}

		public void IncreaseAmountToProduce(int amount = 1)
		{
			AmountToProduce = Mathf.Min(AmountToProduce + amount, 99);
		}

		public void DecreaseAmountToProduce(int amount = 1)
		{
			int num = GetQueuedCount();
			AmountToProduce = Mathf.Max(AmountToProduce - amount, 0);
			while (AmountToProduce < num && Producer.CancelLastQueuedRecipe(this))
			{
				num--;
			}
		}

		public bool ToggleContinuous()
		{
			if (IsContinuous)
			{
				DisableContinuous();
				return false;
			}
			AmountToProduce = -1;
			return true;
		}

		public void DisableContinuous()
		{
			int num = 0;
			foreach (QueuedRecipe queuedRecipe in Producer.QueuedRecipes)
			{
				if (queuedRecipe.Recipe == this)
				{
					num++;
				}
			}
			AmountToProduce = num;
		}

		public void OnQueuedRecipeRemoved(QueuedRecipe queuedRecipe)
		{
			if (queuedRecipe.RecipeStage == QueuedRecipe.Stage.WaitingToExportItems)
			{
				if (0 < AmountToProduce)
				{
					AmountToProduce--;
				}
			}
			else
			{
				DisableContinuous();
			}
		}

		public bool AddMallfunction(PlaceableAlertProperties malfunction)
		{
			if (GetQueuedCount() == 0)
			{
				return Malfunctions.AddUnique(malfunction);
			}
			return false;
		}

		public void PopulateMalfunctions(List<PlaceableAlertProperties> malfunctions, PlaceableAlertProperties.AlertType minimumAlertType)
		{
			foreach (PlaceableAlertProperties malfunction in Malfunctions)
			{
				if (minimumAlertType <= malfunction.Alert)
				{
					malfunctions.AddUnique(malfunction);
				}
			}
		}

		public bool ClearMalfunctions()
		{
			if (Malfunctions.Count == 0)
			{
				return false;
			}
			Malfunctions.Clear();
			return true;
		}

		public bool IsUnlocked()
		{
			return Properties.IsUnlocked();
		}

		public bool IsWaitingToBeQueued()
		{
			if (AmountToProduce >= 0)
			{
				return 0 < AmountToProduce - GetQueuedCount();
			}
			return true;
		}

		public Sprite GetIcon(ItemProperties itemProperties)
		{
			return Properties.ReturnIcon(itemProperties);
		}

		public ItemProperties GetFirstIngredientItemProperties()
		{
			return Properties.ReturnFirstRequiredItemProperties();
		}

		public ItemProperties GetFirstProducedItemProperties()
		{
			return Properties.ReturnFirstProducedItemProperties();
		}

		private int GetQueuedCount()
		{
			int num = 0;
			foreach (QueuedRecipe queuedRecipe in Producer.QueuedRecipes)
			{
				if (queuedRecipe.Recipe == this)
				{
					num++;
				}
			}
			return num;
		}

		public void Restore(ProducerPersistentData.Recipe persistentData)
		{
			AmountToProduce = persistentData.AmountToProduce;
			IsPrioritized = persistentData.IsPrioritized;
			_persistedQueueIndex = persistentData.QueueIndex;
		}

		public int CompareTo(Recipe other)
		{
			return _persistedQueueIndex - other._persistedQueueIndex;
		}
	}

	[SerializeField]
	private ProductionProperties _properties;

	[SerializeField]
	private AssignmentType _additionalAssignmentType;

	[SerializeField]
	[FormerlySerializedAs("WorkerSlots")]
	private AttachableSlots _workerSlots;

	[SerializeField]
	[FormerlySerializedAs("FarmSlots")]
	private FarmSlots _farmSlots;

	[SerializeField]
	[FormerlySerializedAs("ImportSlots")]
	private InventorySlots _importSlots;

	[FormerlySerializedAs("ExportSlots")]
	[SerializeField]
	private InventorySlots _exportSlots;

	private IProducerVisualHelper[] _producerVisualHelpers;

	private static readonly Queue<Producer> _producerQueue = new Queue<Producer>();

	private readonly List<Agent> _attachedWorkers = new List<Agent>();

	private ProjectSettings _projectSettings;

	private ContinuousMode _continuousMode;

	private bool _queuedUpdated;

	private int _queueContinuousRecipeThreshold = -1;

	private bool _wasRestored;

	public Project ProductionProject { get; set; }

	public Project ImportProject { get; private set; }

	public int SelectedRecipeIndex { get; private set; }

	public Recipe SelectedRecipe => Recipes[SelectedRecipeIndex];

	public List<Recipe> Recipes { get; private set; } = new List<Recipe>();

	public List<Recipe> RecipeQueue { get; private set; } = new List<Recipe>();

	public List<QueuedRecipe> QueuedRecipes { get; private set; } = new List<QueuedRecipe>();

	public QueuedRecipe ProductionRecipe
	{
		get
		{
			if (QueuedRecipes.Count <= 0)
			{
				return null;
			}
			return QueuedRecipes[0];
		}
	}

	public bool HasEnergyCost { get; private set; }

	public int SelectedFuelIndex { get; private set; }

	public int MaximumQueuedRecipes { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public bool IsBlockedByImport { get; set; }

	public bool IsProducingItems { get; set; }

	public int MaxProducedItemCount { get; private set; }

	public ResourceProvider ExportResourceProvider { get; private set; }

	public List<ItemProperties> ProducedItems { get; private set; } = new List<ItemProperties>();

	public IReadOnlyList<Agent> AttachedWorkers => _attachedWorkers;

	public ProjectSettings.Priority Priority { get; private set; }

	public int QueueContinuousRecipeThreshold
	{
		get
		{
			return _queueContinuousRecipeThreshold;
		}
		set
		{
			_queueContinuousRecipeThreshold = Mathf.Clamp(value, 1, MaximumQueuedRecipes);
		}
	}

	public ProductionProperties ProductionProperties => _properties;

	public EnergyGridConnector Connector { get; set; }

	public EnergyGrid EnergyGrid => Connector.EnergyGrid;

	public float CurrentEnergyConsumption => ReturnCurrentEnergyConsumption();

	public float EnergyRequirement => ReturnCurrentEnergyRequirement();

	public UnityEvent<Buildable> OnStartProducing { get; private set; } = new UnityEvent<Buildable>();

	public UnityEvent<Buildable> OnStopProducing { get; private set; } = new UnityEvent<Buildable>();

	[HideInInspector]
	public event BuildableEventHandler QueueUpdatedEvent;

	protected override void Awake()
	{
		HasEnergyCost = _properties.EnergyCost > 0f;
		base.Awake();
	}

	private void Start()
	{
		StopDuplicateProjects(ImportProject);
		StopDuplicateProjects(ProductionProject);
	}

	private void Update()
	{
		if (!IsEnabled())
		{
			return;
		}
		switch (_properties.Type)
		{
		case Type.Workshop:
			if (ProductionRecipe != null)
			{
				AdvanceQueuedRecipeStage(ProductionRecipe, !ProductionRecipe.RequiresPerson);
			}
			break;
		case Type.Farm:
		{
			for (int i = 0; i < QueuedRecipes.Count; i++)
			{
				AdvanceQueuedRecipeStage(QueuedRecipes[i], autoProduce: true);
			}
			break;
		}
		}
	}

	private void LateUpdate()
	{
		if (base.Buildable.IsActive && base.Buildable.BuildPhase == BuildPhase.Finished && QueuedRecipes.Count == 0 && base.Buildable.Inventory.ReturnCount(SubInventoryType.Export, includeReserved: true) == 0)
		{
			if (_properties.Type == Type.Workshop)
			{
				base.Buildable.SetStatus(GameManager.Settings.BuildableSettings.StatusQueueEmptyProperties);
			}
			else
			{
				base.Buildable.SetStatus(GameManager.Settings.BuildableSettings.StatusIdleProperties);
			}
		}
		TryQueueRecipe();
		if (_queuedUpdated)
		{
			_queuedUpdated = false;
			this.QueueUpdatedEvent?.Invoke();
		}
	}

	private void OnDestroy()
	{
		_producerQueue?.Remove(this);
		ExportResourceProvider.Unregister();
		UninitializeProjects();
		RemoveListeners();
		if (base.gameObject.scene.isLoaded)
		{
			ImportProject?.Stop(ProjectFlags.BuildableRemoved);
		}
		if (_properties.Type == Type.Workshop)
		{
			_importSlots.Remove();
			_exportSlots.Remove();
		}
	}

	public override void Initialize(Buildable buildable, bool restored = false)
	{
		base.Initialize(buildable, restored);
		AssignmentType assignmentType = _additionalAssignmentType;
		if (HasEnergyCost)
		{
			if (TryGetComponent<EnergyGridConnector>(out var component))
			{
				Connector = component;
				Connector.AddComponent(this);
			}
			else
			{
				Debug.LogError("Producer " + base.name + " that requires fuel does not have an EnergyGridConnector.");
			}
		}
		for (int i = 0; i < ProductionProperties.Recipes.Count; i++)
		{
			AddRecipe(i);
		}
		base.Buildable.Community.AddProducer(this);
		if (ProductionProperties.ProductionProject != null)
		{
			assignmentType |= ProductionProperties.ProductionProject.AssignmentType;
		}
		base.Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Import);
		base.Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Export, _properties.ExportCapacity);
		ExportResourceProvider = ResourceProvider.Get(base.Buildable, SubInventoryType.Export, ReturnInventorySpaceLimiter(), assignmentType);
		base.Buildable.Inventory.InventoryUpdatedEvent.AddListener(UpdateImports);
		base.Buildable.Inventory.InventoryUpdatedEvent.AddListener(UpdateExports);
		AddNewFoundItems();
		_producerVisualHelpers = GetComponentsInChildren<IProducerVisualHelper>(includeInactive: true);
		switch (_properties.Type)
		{
		case Type.Farm:
			_farmSlots.Initialize();
			MaximumQueuedRecipes = _properties.SlotAmount;
			break;
		case Type.Workshop:
			_importSlots.Initialize(base.Buildable.Inventory, SubInventoryType.Import, base.Buildable.OutlineRenderer);
			_exportSlots.Initialize(base.Buildable.Inventory, SubInventoryType.Export, base.Buildable.OutlineRenderer);
			MaximumQueuedRecipes = GameManager.Settings.BuildableSettings.MaximumQueuedRecipes;
			if (_queueContinuousRecipeThreshold < 1)
			{
				_queueContinuousRecipeThreshold = MaximumQueuedRecipes;
			}
			break;
		}
		_projectSettings = GameManager.Settings.ProjectSettings;
		Priority = _projectSettings.ProducerProjectDefaultPriority;
		_continuousMode = GameSettings.Instance.GameplaySettings.ProducerContinuousMode;
	}

	private void InitializeProjects()
	{
		AssignmentType assignmentType = _additionalAssignmentType;
		if (ProductionProperties.ProductionProject != null)
		{
			assignmentType |= ProductionProperties.ProductionProject.AssignmentType;
		}
		if (_properties.Type == Type.Workshop && ProductionProject == null)
		{
			ProductionProject = new Project(_properties.ProductionProject, base.gameObject);
			ProductionProject.SetBlockingProjectProvider(this);
			base.Buildable.Community.QueueProject(ProductionProject);
		}
		if (ImportProject == null)
		{
			ImportProject = new Project(GameManager.Settings.ProjectSettings.ImportProperties, base.gameObject);
			ImportProject.AddAssignmentType(assignmentType);
			base.Buildable.Community.QueueProject(ImportProject);
		}
	}

	private void UninitializeProjects()
	{
		ProductionProject?.Stop(ProjectFlags.BuildableRemoved);
		ProductionProject = null;
		ImportProject?.Stop(ProjectFlags.BuildableRemoved);
		ImportProject = null;
	}

	public override void Finish(bool restored = false)
	{
		ExportResourceProvider.Register();
		if (!restored)
		{
			InitializeProjects();
		}
		switch (_properties.Type)
		{
		case Type.Farm:
			SetSelectedRecipe(0);
			if (!restored && QueuedRecipes.Count < MaximumQueuedRecipes)
			{
				for (int i = 0; i < MaximumQueuedRecipes; i++)
				{
					QueuedRecipes.Add(QueuedRecipe.Get());
				}
			}
			break;
		case Type.Workshop:
			base.Buildable.SetStatus(GameManager.Settings.BuildableSettings.StatusQueueEmptyProperties);
			break;
		}
		if (_properties.AutomaticallyStart)
		{
			SetSelectedRecipe(0);
		}
		_producerQueue.Enqueue(this);
	}

	public override void Remove()
	{
		ExportResourceProvider.Unregister();
		UninitializeProjects();
		RemoveListeners();
		for (int i = 0; i < QueuedRecipes.Count; i++)
		{
			QueuedRecipes[i].Reset();
		}
		if (HasEnergyCost)
		{
			Connector.RemoveComponent(this);
		}
		base.Buildable.Community.RemoveProducer(this);
	}

	private void RemoveListeners()
	{
		base.Buildable.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateImports);
		base.Buildable.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateExports);
	}

	private void AddNewFoundItems()
	{
		for (int i = 0; i < ProductionProperties.Recipes.Count; i++)
		{
			ProductionRecipeProperties productionRecipeProperties = ProductionProperties.Recipes[i];
			for (int j = 0; j < productionRecipeProperties.ProducedItems.Count; j++)
			{
				CountedItemProperty countedItemProperty = productionRecipeProperties.ProducedItems[j];
				Community.PlayerCommunity.AddFoundItem(countedItemProperty.ItemProperties);
			}
		}
	}

	public void AddRecipe(int index)
	{
		Recipe recipe = new Recipe(this, index, ProductionProperties.Recipes[index]);
		Recipes.Add(recipe);
		RecipeQueue.Add(recipe);
		foreach (CountedItemProperty producedItem in recipe.ProducedItems)
		{
			ProducedItems.AddUnique(producedItem.ItemProperties);
		}
	}

	public void SetSelectedRecipe(int recipeIndex)
	{
		if (!_properties.Recipes.IsValidIndex(recipeIndex))
		{
			Debug.LogException(new ArgumentException($"Trying to set SelectedRecipeIndex to {recipeIndex} for producer '{_properties}' which has {_properties.Recipes.Count} recipes"));
		}
		SelectedRecipeIndex = _properties.Recipes.ClampIndex(recipeIndex);
		if (recipeIndex < 0 || recipeIndex >= _properties.Recipes.Count)
		{
			base.Buildable.RemoveMalfunction(GameManager.Settings.BuildableSettings.ErrorItemsMissingProperties);
			if (IsEnabled())
			{
				base.Buildable.SetStatus(GameManager.Settings.BuildableSettings.StatusNoRecipeSelectedProperties);
			}
		}
		else if (IsEnabled())
		{
			base.Buildable.SetStatus(GameManager.Settings.BuildableSettings.StatusIdleProperties);
		}
		if (_properties.Type != Type.Farm)
		{
			return;
		}
		foreach (QueuedRecipe queuedRecipe in QueuedRecipes)
		{
			if (queuedRecipe.RecipeStage == QueuedRecipe.Stage.WaitingToReserveItems)
			{
				queuedRecipe.Reset(SelectedRecipeIndex, Recipes);
			}
		}
		if (TryReturnRecipe(SelectedRecipeIndex, out var recipe))
		{
			ExportResourceProvider.OverrideCapacity(recipe.ProducedItems.Count * _properties.SlotAmount);
		}
	}

	public void ToggleSelecteRecipeContinuous()
	{
		if (SelectedRecipe == null || !SelectedRecipe.ToggleContinuous())
		{
			return;
		}
		ContinuousMode continuousMode = _continuousMode;
		if ((uint)continuousMode <= 1u)
		{
			foreach (Recipe recipe in Recipes)
			{
				if (recipe != SelectedRecipe)
				{
					recipe.DisableContinuous();
				}
			}
		}
		QueueRecipes(SelectedRecipe, MaximumQueuedRecipes);
		_queuedUpdated = true;
	}

	private bool QueueRecipe(Recipe recipe)
	{
		if (QueuedRecipes.Count < MaximumQueuedRecipes && TryReserveRequiredItems(out var reservedItems, recipe, handleMalfunctions: true))
		{
			QueuedRecipe queuedRecipe = QueuedRecipe.Get(recipe);
			queuedRecipe.RecipeItems = reservedItems;
			queuedRecipe.RecipeStage = QueuedRecipe.Stage.WaitingToImport;
			AddQueuedRecipe(queuedRecipe);
			AddQueuedRecipeItemsToImportProject(queuedRecipe);
			UpdateImports();
			_queuedUpdated = true;
			return true;
		}
		return false;
	}

	private void QueueRecipes(Recipe recipe, int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			if (!QueueRecipe(recipe))
			{
				break;
			}
		}
	}

	private bool TryQueueRecipe()
	{
		if (QueuedRecipes.Count >= MaximumQueuedRecipes)
		{
			return false;
		}
		bool result = false;
		for (int i = 0; i < RecipeQueue.Count; i++)
		{
			Recipe recipe = RecipeQueue[i];
			if (!recipe.IsWaitingToBeQueued())
			{
				continue;
			}
			result = true;
			if (QueueRecipe(recipe))
			{
				if (!recipe.IsPrioritized)
				{
					RecipeQueue.RemoveAt(i);
					RecipeQueue.Add(recipe);
				}
				return true;
			}
		}
		return result;
	}

	public void IncreaseSelectedRecipeAmountToProduce()
	{
		SelectedRecipe.IncreaseAmountToProduce();
		RecipeQueue.Remove(SelectedRecipe);
		RecipeQueue.Insert(0, SelectedRecipe);
		TryQueueRecipe();
	}

	public void AddQueuedRecipe(QueuedRecipe queuedRecipe)
	{
		QueuedRecipes.Add(queuedRecipe);
		foreach (CountedItemProperty producedItem in queuedRecipe.ProducedItems)
		{
			ItemEvent.Dispatch(GameEventType.ProducerItemQueued, producedItem.ItemProperties);
		}
		_queuedUpdated = true;
	}

	private void RemoveQueuedRecipe(QueuedRecipe queuedRecipe)
	{
		if (base.Buildable.BuildPhase == BuildPhase.Finished && _properties.Type == Type.Farm)
		{
			Debug.LogException(new Exception("Queued recipes should never be removed from an active producer of type 'FARM'"));
		}
		else if (QueuedRecipes.Remove(queuedRecipe))
		{
			queuedRecipe.Recipe.OnQueuedRecipeRemoved(queuedRecipe);
			queuedRecipe.Release();
			if (QueuedRecipes.Count == 0)
			{
				base.Buildable.RemoveAllMalfunctions();
				base.Buildable.SetStatus(GameManager.Settings.BuildableSettings.StatusQueueEmptyProperties);
			}
			_queuedUpdated = true;
		}
	}

	public void CancelRecipe(int index)
	{
		if (index < QueuedRecipes.Count)
		{
			QueuedRecipe queuedRecipe = QueuedRecipes[index];
			switch (queuedRecipe.RecipeStage)
			{
			case QueuedRecipe.Stage.WaitingToProduce:
			case QueuedRecipe.Stage.Producing:
				base.Buildable.Inventory.ExportItems(queuedRecipe.RecipeItems);
				break;
			case QueuedRecipe.Stage.WaitingToExportItems:
				return;
			}
			if (_properties.Type == Type.Farm)
			{
				_farmSlots.Remove(index);
			}
			RemoveQueuedRecipe(queuedRecipe);
			CleanImportInventory();
		}
	}

	public bool CancelLastQueuedRecipe(Recipe recipe)
	{
		int count = QueuedRecipes.Count;
		while (0 < count--)
		{
			QueuedRecipe queuedRecipe = QueuedRecipes[count];
			if (queuedRecipe.Recipe == recipe && CancelQueuedRecipe(queuedRecipe))
			{
				return true;
			}
		}
		return false;
	}

	private bool CancelQueuedRecipe(QueuedRecipe queuedRecipe)
	{
		switch (queuedRecipe.RecipeStage)
		{
		case QueuedRecipe.Stage.WaitingToProduce:
		case QueuedRecipe.Stage.Producing:
			base.Buildable.Inventory.ExportItems(queuedRecipe.RecipeItems);
			break;
		case QueuedRecipe.Stage.WaitingToExportItems:
			return false;
		}
		if (_properties.Type == Type.Farm)
		{
			throw new NotImplementedException();
		}
		RemoveQueuedRecipe(queuedRecipe);
		CleanImportInventory();
		return true;
	}

	public static void UpdateQueuedProducer()
	{
		if (_producerQueue == null)
		{
			return;
		}
		int count = _producerQueue.Count;
		for (int i = 0; i < count; i++)
		{
			if (!_producerQueue.TryDequeue(out var result) || !result)
			{
				continue;
			}
			_producerQueue.Enqueue(result);
			switch (result._properties.Type)
			{
			case Type.Farm:
				if (result.UpdateQueuedRecipeItems())
				{
					return;
				}
				break;
			case Type.Workshop:
				if (result.TryQueueRecipe())
				{
					return;
				}
				break;
			}
		}
	}

	private bool UpdateQueuedRecipeItems()
	{
		if (QueuedRecipes.IsNullOrEmpty())
		{
			return false;
		}
		using ListPool<Recipe>.List list = ListPool<Recipe>.Get(_properties.Recipes.Count);
		for (int i = 0; i < QueuedRecipes.Count; i++)
		{
			QueuedRecipe queuedRecipe = QueuedRecipes[i];
			if (queuedRecipe.RecipeStage == QueuedRecipe.Stage.WaitingToReserveItems && !list.Contains(queuedRecipe.Recipe) && !TryToReserveRequiredItems(queuedRecipe, i == 0))
			{
				list.Add(queuedRecipe.Recipe);
			}
		}
		UpdateImports();
		return true;
	}

	private bool TryToReserveRequiredItems(QueuedRecipe queuedRecipe, bool canChangeMalfunctions)
	{
		if (TryReserveRequiredItems(out var reservedItems, ProductionRecipe.Recipe, canChangeMalfunctions))
		{
			queuedRecipe.RecipeItems = reservedItems;
			queuedRecipe.RecipeStage = QueuedRecipe.Stage.WaitingToImport;
			_queuedUpdated = true;
			AddQueuedRecipeItemsToImportProject(queuedRecipe);
			return true;
		}
		return false;
	}

	private bool TryReserveRequiredItems(out List<Item> reservedItems, Recipe recipe, bool handleMalfunctions)
	{
		reservedItems = null;
		if (!IsEnabled() || recipe == null)
		{
			return false;
		}
		bool flag = recipe.ClearMalfunctions();
		try
		{
			foreach (CountedItemProperty producedItem in recipe.ProducedItems)
			{
				if (_properties.Type == Type.Workshop && GameManager.ResourceManager.IsProductionLimitReached(producedItem.ItemProperties, producedItem.Amount))
				{
					flag = handleMalfunctions && recipe.AddMallfunction(GameManager.Settings.BuildableSettings.ErrorProductionLimitReachedProperties);
					return false;
				}
			}
			if (!ResourceManager.AreItemsAvailable(recipe.Ingredients))
			{
				flag = handleMalfunctions && _properties.Type == Type.Workshop && recipe.AddMallfunction(GameManager.Settings.BuildableSettings.ErrorItemsMissingProperties);
				return false;
			}
			reservedItems = ResourceManager.ReserveClosestItems(base.Buildable, recipe.Ingredients);
			return true;
		}
		finally
		{
			if (flag)
			{
				UpdateMalfunctions();
			}
		}
	}

	private void AddQueuedRecipeItemsToImportProject(QueuedRecipe queuedRecipe)
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		int count = queuedRecipe.RecipeItems.Count;
		while (0 < count--)
		{
			Item item = queuedRecipe.RecipeItems[count];
			if (item.Inventory == base.Buildable.Inventory)
			{
				if (item.SubInventory != SubInventoryType.Import)
				{
					base.Buildable.Inventory.MoveToSubInventory(item, SubInventoryType.Import);
				}
			}
			else
			{
				list.Add(item);
			}
		}
		if (0 < list.Count)
		{
			ImportProject.AddItems(list);
		}
		else if (!HasEnergyCost)
		{
			queuedRecipe.RecipeStage = QueuedRecipe.Stage.WaitingToProduce;
		}
	}

	private void UpdateImports()
	{
		CleanImportInventory();
		for (int i = 0; i < QueuedRecipes.Count; i++)
		{
			QueuedRecipe queuedRecipe = QueuedRecipes[i];
			if (queuedRecipe.RecipeStage == QueuedRecipe.Stage.WaitingToImport && queuedRecipe.AreItemsInInventory(base.Buildable.Inventory, SubInventoryType.Import))
			{
				queuedRecipe.RecipeStage = QueuedRecipe.Stage.WaitingToProduce;
			}
		}
		_queuedUpdated = true;
	}

	private void CleanImportInventory()
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		base.Buildable.Inventory.ReturnAllItems(SubInventoryType.Import, list);
		foreach (Item item in list)
		{
			if (!ReturnIsRecipeItem(item))
			{
				base.Buildable.Inventory.ExportItem(item);
			}
		}
	}

	private void UpdateExports()
	{
		for (int i = 0; i < QueuedRecipes.Count; i++)
		{
			QueuedRecipe queuedRecipe = QueuedRecipes[i];
			if (queuedRecipe.Recipe == null)
			{
				continue;
			}
			if (base.Buildable.Inventory.ReturnCapacity(SubInventoryType.Export) >= base.Buildable.Inventory.ReturnCount(SubInventoryType.Export) + queuedRecipe.ProducedItems.Count)
			{
				base.Buildable.RemoveMalfunction(GameManager.Settings.BuildableSettings.ErrorExportStorageFullProperties);
			}
			if (queuedRecipe.RecipeStage == QueuedRecipe.Stage.WaitingToExportItems && !queuedRecipe.AreItemsInInventory(base.Buildable.Inventory, SubInventoryType.Export))
			{
				Type type = _properties.Type;
				if (type != Type.Workshop && type == Type.Farm)
				{
					queuedRecipe.Reset(SelectedRecipeIndex, Recipes, resetRecipeState: true);
					_farmSlots.Remove(i);
				}
			}
		}
		_queuedUpdated = true;
	}

	private void FinishQueuedRecipe(QueuedRecipe queuedRecipe)
	{
		queuedRecipe.Finish();
		base.Buildable.Inventory.AddItems(queuedRecipe.RecipeItems, SubInventoryType.Export);
		ItemEvent.DispatchItemsProduced(ProductionRecipe.RecipeItems);
		AudioManager.PlayOneShot(_properties.FMODEventReference_FarmItemCompleted, base.transform);
		switch (_properties.Type)
		{
		case Type.Workshop:
			RemoveQueuedRecipe(queuedRecipe);
			break;
		case Type.Farm:
			_farmSlots.Finish(QueuedRecipes.IndexOf(queuedRecipe));
			break;
		}
		_queuedUpdated = true;
	}

	public void DecreasePriority()
	{
		int index = _projectSettings.ProducerProjectPriorities.IndexOf(Priority);
		if (0 < index--)
		{
			ProjectSettings.Priority priority = _projectSettings.ProducerProjectPriorities[index];
			SetPriority(priority);
			ProductionRecipeEvent.DispatchPriorityChange(priority.Score);
		}
	}

	public void IncreasePriority()
	{
		int num = _projectSettings.ProducerProjectPriorities.IndexOf(Priority) + 1;
		if (num < _projectSettings.ProducerProjectPriorities.Count)
		{
			ProjectSettings.Priority priority = _projectSettings.ProducerProjectPriorities[num];
			SetPriority(priority);
			ProductionRecipeEvent.DispatchPriorityChange(priority.Score);
		}
	}

	private void SetPriority(ProjectSettings.Priority priority)
	{
		Priority = priority;
		ImportProject.SetPriority(Priority.Score);
		if (ProductionProperties.Type == Type.Workshop)
		{
			ProductionProject.SetPriority(Priority.Score);
		}
	}

	public void AttachWorker(Agent worker)
	{
		_attachedWorkers.Add(worker);
		_workerSlots.Attach(worker.transform);
	}

	public void DetachWorker(Agent worker, Transform newParent)
	{
		_attachedWorkers.Remove(worker);
		_workerSlots.Detach(worker.transform, newParent);
	}

	public void AdvanceQueuedRecipeStage(QueuedRecipe queuedRecipe, bool autoProduce)
	{
		switch (queuedRecipe.RecipeStage)
		{
		case QueuedRecipe.Stage.WaitingToImport:
			base.Buildable.SetStatus(GameManager.Settings.BuildableSettings.StatusWaitingForResourcesProperties);
			break;
		case QueuedRecipe.Stage.WaitingToProduce:
			base.Buildable.SetStatus(GameManager.Settings.BuildableSettings.StatusWaitingForProducerProperties);
			if (IsBlockedByImport)
			{
				break;
			}
			if (base.Buildable.Inventory.ReturnCapacity(SubInventoryType.Export) < base.Buildable.Inventory.ReturnCount(SubInventoryType.Export) + queuedRecipe.ReturnProducedItemCount())
			{
				base.Buildable.AddMalfunction(GameManager.Settings.BuildableSettings.ErrorExportStorageFullProperties);
				break;
			}
			if (HasEnergyCost)
			{
				if (!Connector.EnergyGrid.HasEnergy)
				{
					base.Buildable.AddMalfunction(GameManager.Settings.BuildableSettings.ErrorNoEnergyProperties);
					break;
				}
				base.Buildable.RemoveMalfunction(GameManager.Settings.BuildableSettings.ErrorNoEnergyProperties);
			}
			if (autoProduce)
			{
				StartProducing(queuedRecipe);
			}
			UpdateProducerVisuals(queuedRecipe);
			break;
		case QueuedRecipe.Stage.Producing:
			base.Buildable.SetStatus(GameManager.Settings.BuildableSettings.StatusWorkingProperties);
			if (autoProduce)
			{
				if (HasEnergyCost && !Connector.EnergyGrid.HasEnergy)
				{
					StopProducing();
				}
				Produce(queuedRecipe);
			}
			UpdateProducerVisuals(queuedRecipe);
			if (!(queuedRecipe.Progress < queuedRecipe.ProductionTime))
			{
				FinishQueuedRecipe(queuedRecipe);
			}
			break;
		case QueuedRecipe.Stage.WaitingToExportItems:
			base.Buildable.SetStatus(GameManager.Settings.BuildableSettings.StatusProducerHaulingItemstoStorageProperties);
			if (queuedRecipe.RecipeItems.Count == 0)
			{
				Debug.LogException(new Exception("QueuedRecipe with 0 recipe item is waiting to export items which should be impossible...!"));
				if (_properties.Type == Type.Workshop)
				{
					RemoveQueuedRecipe(queuedRecipe);
				}
				else
				{
					queuedRecipe.Reset(SelectedRecipeIndex, Recipes, resetRecipeState: true);
				}
			}
			break;
		case QueuedRecipe.Stage.WaitingToReserveItems:
			break;
		}
	}

	public void Produce(QueuedRecipe recipe, float agentModifier = 1f)
	{
		float num = TimeManager.GetDeltaTime() * agentModifier * base.Buildable.ReturnModifier(ModifierType.ProductionSpeed);
		float addedProgress = ((!HasEnergyCost) ? num : (Connector.EnergyGrid.GridEfficiency * num));
		recipe.Produce(addedProgress);
		if (_properties.Type == Type.Farm)
		{
			_farmSlots.Update(QueuedRecipes.IndexOf(recipe), recipe.Progress);
		}
	}

	public void StartProducing(QueuedRecipe recipe, float modifier = 1f)
	{
		if (recipe == null)
		{
			Debug.LogError($"PRODUCER::Recipe was null in StartProducing in {base.Buildable.name}");
		}
		if (base.Buildable.FMODEventEmitter == null)
		{
			Debug.LogError($"PRODUCER::FMODEventEmitter was null in StartProducing in {base.Buildable.name}");
		}
		if (_properties.FMODEventReference_Production.IsNull)
		{
			Debug.LogError($"PRODUCER::FMODEvent_Production was null in StartProducing in {base.Buildable.name}");
		}
		if (recipe.RecipeStage == QueuedRecipe.Stage.WaitingToProduce || recipe.RecipeStage == QueuedRecipe.Stage.Producing)
		{
			base.Buildable.FMODEventEmitter.Emit(_properties.FMODEventReference_Production);
			StartProductionAnimation(recipe, modifier);
			recipe.RecipeStage = QueuedRecipe.Stage.Producing;
			if (_properties.Type == Type.Farm)
			{
				_farmSlots.Display(QueuedRecipes.IndexOf(recipe), recipe);
			}
		}
		OnStartProducing.Invoke(base.Buildable);
	}

	private void StartProductionAnimation(QueuedRecipe recipe, float modifier)
	{
		if (!(base.Buildable.BuildableAnimator == null))
		{
			base.Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 1);
			if (base.Buildable.BuildableAnimator.HasParameter("Transition Time"))
			{
				base.Buildable.BuildableAnimator.Animator.SetFloat("Transition Time", recipe.ProductionTime / modifier);
			}
		}
	}

	public void StopProducing()
	{
		if (base.Buildable.FMODEventEmitter != null)
		{
			base.Buildable.FMODEventEmitter.Stop(_properties.FMODEventReference_Production);
		}
		if (base.Buildable.BuildableAnimator != null)
		{
			base.Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 0);
		}
		OnStopProducing.Invoke(base.Buildable);
		if (ProductionRecipe != null && ProductionRecipe.Progress < ProductionRecipe.ProductionTime && ProductionRecipe.RecipeStage == QueuedRecipe.Stage.Producing)
		{
			ProductionRecipe.RecipeStage = QueuedRecipe.Stage.WaitingToProduce;
		}
	}

	private void UpdateProducerVisuals(QueuedRecipe queuedRecipe)
	{
		if (queuedRecipe != null && queuedRecipe.RecipeStage == QueuedRecipe.Stage.Producing)
		{
			for (int i = 0; i < _producerVisualHelpers.Length; i++)
			{
				_producerVisualHelpers[i].SetProgress(ReturnProgressNormalized(queuedRecipe));
			}
		}
		else
		{
			for (int j = 0; j < _producerVisualHelpers.Length; j++)
			{
				_producerVisualHelpers[j].Reset();
			}
		}
	}

	public bool IsProducerOf(ProductionRecipeProperties recipeProperties)
	{
		foreach (Recipe recipe in Recipes)
		{
			if (recipe.Properties == recipeProperties)
			{
				return true;
			}
		}
		return false;
	}

	public float ReturnEnergyCost()
	{
		return _properties.EnergyCost * base.Buildable.ReturnModifier(ModifierType.ProductionEnergyCost);
	}

	public bool TryReturnRecipe(int index, out Recipe recipe)
	{
		return Recipes.TryGetValue(index, out recipe);
	}

	public bool TryReturnRecipe(ProductionRecipeProperties properties, out Recipe recipe)
	{
		int count = Recipes.Count;
		while (0 < count--)
		{
			recipe = Recipes[count];
			if (recipe.Properties == properties)
			{
				return true;
			}
		}
		recipe = null;
		return false;
	}

	public bool TryReturnRestoredProducingRecipe(out QueuedRecipe queuedRecipe)
	{
		if (_wasRestored)
		{
			_wasRestored = false;
			for (int i = 0; i < QueuedRecipes.Count; i++)
			{
				queuedRecipe = QueuedRecipes[i];
				if (queuedRecipe != null && queuedRecipe.Recipe != null && queuedRecipe.RecipeStage == QueuedRecipe.Stage.Producing)
				{
					return true;
				}
			}
		}
		queuedRecipe = null;
		return false;
	}

	public bool TryReturnNextRecipeToProduce(out QueuedRecipe queuedRecipe)
	{
		if (base.Buildable.Inventory.ReturnIsFull(SubInventoryType.Export))
		{
			queuedRecipe = null;
			return false;
		}
		for (int i = 0; i < QueuedRecipes.Count; i++)
		{
			queuedRecipe = QueuedRecipes[i];
			if (queuedRecipe != null && queuedRecipe.Recipe != null && (queuedRecipe.RecipeStage == QueuedRecipe.Stage.WaitingToProduce || queuedRecipe.RecipeStage == QueuedRecipe.Stage.Producing) && base.Buildable.Inventory.FitsInInventory(queuedRecipe.ProducedItems, SubInventoryType.Export))
			{
				return true;
			}
		}
		queuedRecipe = null;
		return false;
	}

	public float ReturnProgressNormalized(QueuedRecipe queuedRecipe = null)
	{
		if (queuedRecipe == null)
		{
			if (ProductionRecipe == null)
			{
				return 0f;
			}
			queuedRecipe = ProductionRecipe;
		}
		return queuedRecipe.Progress / queuedRecipe.ProductionTime;
	}

	public bool ReturnProducesItem(ItemProperties itemProperties)
	{
		if (_properties == null || _properties.Recipes.IsNullOrEmpty())
		{
			return false;
		}
		foreach (ProductionRecipeProperties recipe in _properties.Recipes)
		{
			if (recipe.ReturnProducesItem(itemProperties))
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnUsesItem(ItemProperties itemProperties)
	{
		if (_properties == null || _properties.Recipes.IsNullOrEmpty())
		{
			return false;
		}
		foreach (ProductionRecipeProperties recipe in _properties.Recipes)
		{
			if (recipe.ReturnUsesItem(itemProperties))
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnCanRun()
	{
		if (IsEnabled() && GameManager.TimeManager.CurrentDay.DayTime == Day.E_DayTime.Day)
		{
			if (HasEnergyCost)
			{
				return Connector.EnergyGrid.HasEnergy;
			}
			return true;
		}
		return false;
	}

	private IInventorySpaceLimiter ReturnInventorySpaceLimiter()
	{
		if (_properties.Type != Type.Workshop)
		{
			return GameManager.ResourceManager;
		}
		return base.Buildable.Community.Inventory;
	}

	private float ReturnCurrentEnergyConsumption()
	{
		if (IsProducing())
		{
			return ReturnEnergyCost();
		}
		return 0f;
	}

	private float ReturnCurrentEnergyRequirement()
	{
		if (IsProducing())
		{
			return ReturnEnergyCost();
		}
		if (_properties.Type == Type.Workshop && ProductionRecipe != null && ProductionRecipe.RecipeStage == QueuedRecipe.Stage.WaitingToProduce)
		{
			return ReturnEnergyCost();
		}
		return 0f;
	}

	private bool IsProducing()
	{
		switch (_properties.Type)
		{
		case Type.Workshop:
			if (ProductionRecipe == null)
			{
				return false;
			}
			if (ProductionRecipe.RecipeStage == QueuedRecipe.Stage.Producing)
			{
				return true;
			}
			break;
		case Type.Farm:
			foreach (QueuedRecipe queuedRecipe in QueuedRecipes)
			{
				if (queuedRecipe.RecipeStage == QueuedRecipe.Stage.Producing)
				{
					return true;
				}
			}
			break;
		}
		return false;
	}

	private bool ReturnIsRecipeItem(Item item)
	{
		foreach (QueuedRecipe queuedRecipe in QueuedRecipes)
		{
			if (!queuedRecipe.RecipeItems.IsNullOrEmpty() && queuedRecipe.RecipeItems.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool TryReturnBlockingProject(out Project blockingProject, Agent agent)
	{
		blockingProject = null;
		if (base.Buildable == null || base.Buildable.Community == null)
		{
			Debug.LogException(new Exception("Unable to return blocking project. The producer has been Destroyed! Uninitialzing its projects."));
			UninitializeProjects();
			return false;
		}
		foreach (IItemProducer producer2 in base.Buildable.Community.Producers)
		{
			if (producer2 is Producer { ProductionProject: not null } producer && ProductionProject.AgentPriorityScore <= producer.ProductionProject.AgentPriorityScore && 0 < producer.QueuedRecipes.Count && producer.QueuedRecipes[0].RecipeStage == QueuedRecipe.Stage.WaitingToProduce && producer.ProductionProject.Assignments.IsNullOrEmpty())
			{
				return false;
			}
		}
		if (0 < QueuedRecipes.Count && QueuedRecipes[0].RecipeStage == QueuedRecipe.Stage.WaitingToImport && ImportProject.Assignments.IsNullOrEmpty())
		{
			blockingProject = ImportProject;
		}
		return blockingProject != null;
	}

	public override bool IsEnabled()
	{
		if (base.IsEnabled())
		{
			return base.Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public override bool CanBeSalvaged()
	{
		if (base.Buildable.Inventory.ReturnCount(SubInventoryType.Export, includeReserved: true) > 0)
		{
			return false;
		}
		if (base.Buildable.Inventory.ReturnCount(SubInventoryType.Import, includeReserved: true) > 0)
		{
			return false;
		}
		switch (_properties.Type)
		{
		case Type.Workshop:
			if (ProductionRecipe != null)
			{
				return ProductionRecipe.IsSalvagable();
			}
			return true;
		case Type.Farm:
		{
			for (int i = 0; i < QueuedRecipes.Count; i++)
			{
				if (!QueuedRecipes[i].IsSalvagable())
				{
					return false;
				}
			}
			return true;
		}
		default:
			return true;
		}
	}

	public override void Shutdown()
	{
		int count = QueuedRecipes.Count;
		while (0 < count--)
		{
			CancelRecipe(count);
		}
		Deactivate();
	}

	public override void Activate()
	{
		base.Activate();
		_queuedUpdated = true;
	}

	public override void Deactivate()
	{
		base.Deactivate();
		base.Buildable.RemoveAllMalfunctions();
		_queuedUpdated = true;
	}

	public override void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public override void PopulateMalfunctions(List<PlaceableAlertProperties> malfunctions, PlaceableAlertProperties.AlertType minimumAlertType = PlaceableAlertProperties.AlertType.Minor)
	{
		base.PopulateMalfunctions(malfunctions, minimumAlertType);
		foreach (Recipe recipe in Recipes)
		{
			if (minimumAlertType == PlaceableAlertProperties.AlertType.Major || SelectedRecipe == recipe)
			{
				recipe.PopulateMalfunctions(malfunctions, minimumAlertType);
			}
		}
	}

	public override IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new ProducerPersistentData(this);
	}

	public override void Restore(IBuildableExtendablePersistentData persistentData)
	{
		if (!(persistentData is ProducerPersistentData producerPersistentData))
		{
			return;
		}
		if (base.Buildable.BuildPhase == BuildPhase.SalvageShutdown || base.Buildable.BuildPhase == BuildPhase.UpgradeShutdown)
		{
			ExportResourceProvider.Register();
		}
		SetSelectedRecipe(producerPersistentData.SelectedRecipeIndex);
		if (producerPersistentData.Recipes == null)
		{
			RestoreContinuousRecipe(producerPersistentData.ContinuousRecipeIndex);
		}
		else
		{
			ProducerPersistentData.Recipe[] recipes = producerPersistentData.Recipes;
			for (int i = 0; i < recipes.Length; i++)
			{
				ProducerPersistentData.Recipe persistentData2 = recipes[i];
				if (persistentData2.TryGetProperties(out var properties) && TryReturnRecipe(properties, out var recipe))
				{
					recipe.Restore(persistentData2);
				}
			}
			Sorting.SlowSort(RecipeQueue);
		}
		_wasRestored = true;
	}

	private void RestoreContinuousRecipe(int index)
	{
		if (Recipes.TryGetValue(index, out var value))
		{
			value.ToggleContinuous();
		}
	}

	public override void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		ProducerPersistentData producerPersistentData = persistentData as ProducerPersistentData;
		if (producerPersistentData.ImportProject != null && producerPersistentData.ImportProject.TryReturn(out var instance))
		{
			ImportProject = instance;
		}
		if (producerPersistentData.ProductionProject != null && producerPersistentData.ProductionProject.TryReturn(out var instance2))
		{
			ProductionProject = instance2;
			ProductionProject.SetBlockingProjectProvider(this);
		}
		InitializeProjects();
		_projectSettings = GameManager.Settings.ProjectSettings;
		if (_projectSettings.ProducerProjectPriorities.IsValidIndex(producerPersistentData.PriorityIndex))
		{
			SetPriority(_projectSettings.ProducerProjectPriorities[producerPersistentData.PriorityIndex]);
		}
		int num = ((_properties.Type == Type.Workshop) ? producerPersistentData.QueuedRecipes.Length : MaximumQueuedRecipes);
		if (num == 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			if (!TryRestoreQueuedRecipe(i, producerPersistentData.QueuedRecipes, out var queuedRecipe))
			{
				continue;
			}
			AddQueuedRecipe(queuedRecipe);
			if (ProductionProperties.Type == Type.Farm && queuedRecipe.Recipe != null)
			{
				QueuedRecipe.Stage recipeStage = queuedRecipe.RecipeStage;
				if ((uint)(recipeStage - 2) <= 2u)
				{
					_farmSlots.Display(i, queuedRecipe);
				}
			}
		}
	}

	private bool TryRestoreQueuedRecipe(int index, QueuedRecipePersistentData[] persistentData, out QueuedRecipe queuedRecipe)
	{
		if (index < persistentData.Length && QueuedRecipe.TryGet(persistentData[index], Recipes, out queuedRecipe))
		{
			return true;
		}
		if (_properties.Type == Type.Farm)
		{
			Debug.LogException(new Exception("Producer '" + base.Buildable.Name + "' did not persist its QueuedRecipes correctly"));
			queuedRecipe = QueuedRecipe.Get(SelectedRecipeIndex, Recipes);
			return true;
		}
		queuedRecipe = null;
		return false;
	}

	private void StopDuplicateProjects(Project project)
	{
		if (project == null)
		{
			return;
		}
		int count = base.Buildable.Community.Projects.Count;
		while (0 < count--)
		{
			Project project2 = base.Buildable.Community.Projects[count];
			if (project2 != project && project2.Target == project.Target && project2.Properties == project.Properties)
			{
				project2.Stop(ProjectFlags.BugFix);
				Debug.LogException(new Exception($"Project '{project2.Properties}' was stopped by '{base.Buildable.Name}', because it was a duplicate!"));
			}
		}
	}

	public override void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		ProducerPersistentData producerPersistentData = persistentData as ProducerPersistentData;
		producerPersistentData.ProductionProject = ProductionProject;
		producerPersistentData.ImportProject = ImportProject;
		producerPersistentData.PriorityIndex = _projectSettings.ProducerProjectPriorities.IndexOf(Priority);
		if (ProductionRecipe != null && ProductionRecipe.RecipeStage == QueuedRecipe.Stage.Producing)
		{
			producerPersistentData.BuildableAnimatorData = BuildableAnimatorPersistentData.Create(base.Buildable);
			if (ProductionProject != null && ProductionProject.Assignments.Count > 0)
			{
				producerPersistentData.AgentAnimatorData = new MeshAnimatorPersistentData(ProductionProject.Assignments[0].Agent);
			}
		}
		else
		{
			producerPersistentData.BuildableAnimatorData = null;
			producerPersistentData.AgentAnimatorData = null;
		}
		producerPersistentData.PopulateQueuedRecipes(this);
	}

	public override void OnDeconstruct()
	{
		ExportResourceProvider.Unregister();
	}

	public List<Agent> GetWorkers(List<Agent> listToPopulate = null)
	{
		if (listToPopulate == null)
		{
			listToPopulate = new List<Agent>(_attachedWorkers.Count);
		}
		listToPopulate.AddUniqueRange(listToPopulate);
		return listToPopulate;
	}

	public void AddToEnergyGrid(EnergyGrid grid)
	{
		grid.Consumers.AddUnique(this);
		grid.AddComponent(this);
	}

	public void RemoveFromEnergyGrid(EnergyGrid grid)
	{
		if (grid != null)
		{
			grid.Consumers.Remove(this);
			grid.RemoveComponent(this);
		}
	}

	public EnergyGridOverviewSlotUI ReturnUI()
	{
		if (!ProducerOverviewUI.TryReturnAvailableUI(out var ui))
		{
			ui = UnityEngine.Object.Instantiate(GameManager.Settings.UISettings.ProducerOverviewUIPrefab);
		}
		ui.Initialize(this);
		return ui;
	}

	int IItemProducer.GetItemsInProductionCount(ItemProperties itemProperties)
	{
		int num = 0;
		foreach (QueuedRecipe queuedRecipe in QueuedRecipes)
		{
			if (queuedRecipe.RecipeStage == QueuedRecipe.Stage.WaitingToReserveItems || queuedRecipe.RecipeStage == QueuedRecipe.Stage.WaitingToExportItems)
			{
				continue;
			}
			foreach (CountedItemProperty producedItem in queuedRecipe.ProducedItems)
			{
				if (producedItem.ItemProperties == itemProperties)
				{
					num += producedItem.Amount;
				}
			}
		}
		return num;
	}
}
