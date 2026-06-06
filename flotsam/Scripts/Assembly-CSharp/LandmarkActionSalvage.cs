using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Flotsam/Landmarks/Actions/Salvage")]
public class LandmarkActionSalvage : LandmarkAction, ISalvageTarget
{
	public class Category : ILandmarkActionToggleable, IToggleable
	{
		private LandmarkActionSalvage _action;

		private LandmarkActionSalvageableUnlockable _unlockable;

		public string Label
		{
			get
			{
				if (!CategoryAsset)
				{
					return "No Category assigned!";
				}
				return CategoryAsset.Description;
			}
		}

		public LandmarkSalvageableCategory CategoryAsset { get; private set; }

		public List<Salvageable> Members { get; private set; }

		public bool Unlocked { get; set; }

		public bool IsInteractable => _action.ReturnIsInteractable();

		public bool IsToggled { get; private set; }

		public bool RequiresItem
		{
			get
			{
				if ((bool)CategoryAsset)
				{
					return CategoryAsset.ReturnRequiresItem();
				}
				return false;
			}
		}

		public bool RequiresAssignmentType
		{
			get
			{
				if ((bool)CategoryAsset)
				{
					return CategoryAsset.ReturnRequiresAssignmentType();
				}
				return false;
			}
		}

		public bool RequiresBuildable
		{
			get
			{
				if ((bool)CategoryAsset)
				{
					return CategoryAsset.ReturnRequiresBuildable();
				}
				return false;
			}
		}

		public bool CanBeSalvaged
		{
			get
			{
				if (Unlocked && !RequiresAssignmentType)
				{
					return !RequiresBuildable;
				}
				return false;
			}
		}

		public bool MarkedForSalvage
		{
			get
			{
				if (IsToggled)
				{
					return CanBeSalvaged;
				}
				return false;
			}
		}

		public bool IsCompleted => ReturnIsCompleted();

		public Dictionary<ItemProperties, bool> ItemFilter { get; private set; }

		public int TotalItemCount { get; private set; }

		public Category(LandmarkActionSalvage Action, Salvageable salvageable)
		{
			CategoryAsset = salvageable.CategoryAsset;
			Members = new List<Salvageable>(1);
			Unlocked = !RequiresItem;
			ItemFilter = new Dictionary<ItemProperties, bool>();
			IsToggled = false;
			_action = Action;
			TryAddMember(salvageable);
		}

		public bool TryAddMember(Salvageable salvageable)
		{
			if (CategoryAsset == salvageable.CategoryAsset)
			{
				Members.Add(salvageable);
				salvageable.Category = this;
				TotalItemCount += salvageable.ReturnCompositionCount();
				return true;
			}
			return false;
		}

		public void CountItems(InventoryAuditor auditor)
		{
			foreach (Salvageable member in Members)
			{
				member.CountItemsInComposition(auditor);
			}
		}

		public void CountSalvageableItems(InventoryAuditor auditor)
		{
			if (CanBeSalvaged)
			{
				CountItems(auditor);
			}
		}

		public void PopulateSalvageableItems(List<Item> salvageableItems, bool includeReserved)
		{
			foreach (Salvageable member in Members)
			{
				member.Instance?.Inventory.ReturnAllItems(SubInventoryType.Composition, salvageableItems, includeReserved);
			}
		}

		public bool ReturnIsCompleted()
		{
			if (!CanBeSalvaged)
			{
				return false;
			}
			foreach (Salvageable member in Members)
			{
				if (!member.Instance || !member.Instance.Inventory.ReturnIsEmpty(SubInventoryType.Composition))
				{
					return false;
				}
			}
			return true;
		}

		public List<InventoryAuditor.CountedItem> ReturnCountedItems()
		{
			InventoryAuditor global = InventoryAuditor.Global;
			global.Reset();
			foreach (Salvageable member in Members)
			{
				member.CountItemsInComposition(global);
			}
			return global.CountedItems;
		}

		public bool TryReturnRequiredItemCost(out int cost)
		{
			ItemProperties requiredItem;
			return TryReturnRequiredItemAndCost(out requiredItem, out cost);
		}

		public bool TryReturnRequiredItemAndCost(out ItemProperties requiredItem, out int cost)
		{
			requiredItem = null;
			cost = 0;
			if (CategoryAsset == null || CategoryAsset.RequiredItem.IsNullOrEmpty())
			{
				return false;
			}
			requiredItem = CategoryAsset.RequiredItem.ItemProperties;
			cost = Mathf.CeilToInt(CategoryAsset.RequiredItem.Amount * (float)Members.Count);
			return true;
		}

		public bool TryReturnSalvageItemExperience(Item item, out float experience)
		{
			if ((bool)CategoryAsset)
			{
				foreach (Salvageable member in Members)
				{
					if ((bool)member.Instance && item.Inventory == member.Instance.Inventory)
					{
						experience = CategoryAsset.SalvageItemExperience;
						return true;
					}
				}
			}
			experience = 0f;
			return false;
		}

		public void InitializeUnlockables(LandmarkActionSalvageableUnlockable[] unlockables)
		{
			foreach (LandmarkActionSalvageableUnlockable landmarkActionSalvageableUnlockable in unlockables)
			{
				if (landmarkActionSalvageableUnlockable.Initialize(this))
				{
					_unlockable = landmarkActionSalvageableUnlockable;
				}
			}
		}

		public IEnumerator Unlock()
		{
			Unlocked = true;
			if ((bool)_unlockable)
			{
				yield return _unlockable.Unlock();
			}
		}

		public void Toggle()
		{
			IsToggled = !IsToggled;
		}

		public void ToggleItemFilter(ItemProperties itemProperties)
		{
			if (ItemFilter.TryGetValue(itemProperties, out var value))
			{
				ItemFilter[itemProperties] = !value;
			}
		}

		public bool IsItemFilterToggled(ItemProperties itemProperties)
		{
			bool value;
			return ItemFilter.TryGetValue(itemProperties, out value) && value;
		}
	}

	public class Salvageable
	{
		public LandmarkSalvageableCategory CategoryAsset;

		public Category Category;

		public LandmarkSalvageable Instance;

		public int VariationIndex;

		public CountedItemProperty[] Composition;

		public CountedItemProperty[] CompositionItems;

		public Salvageable(LandmarkSalvageable landmarkSalvageable)
		{
			VariationIndex = landmarkSalvageable.ReturnRandomVariationIndex();
			CategoryAsset = landmarkSalvageable.ReturnCategoryAsset(VariationIndex);
			Composition = landmarkSalvageable.ReturnAssetComposition(VariationIndex).ToArray();
			CompositionItems = Composition;
		}

		public Salvageable(LandmarkSalvageable landmarkSalvageable, int variationIndex, CountedItemProperty[] compositionItems)
		{
			CategoryAsset = landmarkSalvageable.Category;
			VariationIndex = variationIndex;
			Composition = landmarkSalvageable.ReturnAssetComposition(variationIndex).ToArray();
			CompositionItems = compositionItems;
		}

		public void CountItemsInComposition(InventoryAuditor auditor)
		{
			if ((bool)Instance)
			{
				Instance.CountItemsInComposition(auditor);
			}
			else
			{
				auditor.CountItemProperties(CompositionItems);
			}
		}

		public int ReturnCompositionCount()
		{
			if (Composition.IsNullOrEmpty())
			{
				return 0;
			}
			int num = 0;
			CountedItemProperty[] composition = Composition;
			foreach (CountedItemProperty countedItemProperty in composition)
			{
				num += countedItemProperty.Amount;
			}
			return num;
		}
	}

	[SerializeField]
	private LandmarkActionSalvageUINew _uiPrefab;

	[SerializeField]
	private LocalizedString _categoriesLockedTooltip;

	private InventoryAuditor _auditor;

	private List<Salvageable> _salvageables;

	private Coroutine _compositionUpdatedCoroutine;

	public UnityEvent CompositionUpdated { get; private set; }

	public int AgentLimit { get; private set; } = 1;

	public Dictionary<ItemProperties, bool> ItemFilter { get; private set; }

	public override GameEventType InteractableEventType => GameEventType.LandmarkActionSalvageInteractable;

	public List<Category> Categories { get; private set; }

	public override void Initialize(LandmarkBehaviour landmarkBehaviour)
	{
		base.Initialize(landmarkBehaviour);
		_salvageables = new List<Salvageable>();
		Categories = new List<Category>();
	}

	public override void Restore(LandmarkPersistentData landmarkPersistentData)
	{
		if (!landmarkPersistentData.TryReturnLandmarkInteractablePersistentData<LandmarkSalvageablePersistentData>(out var persistentData))
		{
			return;
		}
		using ListPool<LandmarkSalvageable>.List list = ListPool<LandmarkSalvageable>.Get();
		_landmarkBehaviour.LandmarkPrefabGameObject.GetComponentsInChildren(list);
		for (int i = 0; i < list.Count; i++)
		{
			LandmarkSalvageable landmarkSalvageable = list[i];
			int variationIndex;
			CountedItemProperty[] compositionItems;
			Salvageable salvageable = ((!persistentData.TryReturnVariationIndexAndCompositionItems(i, out variationIndex, out compositionItems)) ? new Salvageable(landmarkSalvageable) : new Salvageable(landmarkSalvageable, variationIndex, compositionItems));
			_salvageables.Add(salvageable);
			AddSalvageableToCategory(salvageable);
		}
	}

	public override void OnLandmarkSpawned(LandmarkActionPersistentData persistentData = null)
	{
		base.OnLandmarkSpawned(persistentData);
		using ListPool<LandmarkSalvageable>.List list = ListPool<LandmarkSalvageable>.Get();
		_landmarkBehaviour.Landmark.GetComponentsInChildren(list);
		ItemFilter = new Dictionary<ItemProperties, bool>();
		int count = list.Count;
		InventoryAuditor.Global.Reset();
		for (int i = 0; i < count; i++)
		{
			LandmarkSalvageable landmarkSalvageable = list[i];
			Salvageable salvageable = ((i >= _salvageables.Count) ? AddSalvageable(landmarkSalvageable) : _salvageables[i]);
			salvageable.Instance = landmarkSalvageable;
			landmarkSalvageable.InitializeComposition(salvageable.VariationIndex, salvageable.CompositionItems);
			landmarkSalvageable.IsInteractable = true;
			landmarkSalvageable.CompositionUpdatedEvent += SalvageableCompositionUpdatedEvent;
			landmarkSalvageable.InitializeItemFilter(salvageable.Category.ItemFilter);
			landmarkSalvageable.CountComposition(InventoryAuditor.Global);
		}
		Sorting.SlowSort(Categories, CompareCategories);
		if (persistentData == null)
		{
			foreach (Category category in Categories)
			{
				category.InitializeUnlockables(_landmarkBehaviour.Landmark.Unlockables);
			}
		}
		CompositionUpdated = new UnityEvent();
	}

	private Salvageable AddSalvageable(LandmarkSalvageable landmarkSalvageable)
	{
		Salvageable salvageable = new Salvageable(landmarkSalvageable);
		_salvageables.Add(salvageable);
		AddSalvageableToCategory(salvageable);
		return salvageable;
	}

	public override void Uninitialize()
	{
		base.Uninitialize();
		if (_salvageables == null)
		{
			return;
		}
		foreach (Salvageable salvageable in _salvageables)
		{
			if (!(salvageable.Instance == null))
			{
				salvageable.Instance.CompositionUpdatedEvent -= SalvageableCompositionUpdatedEvent;
				salvageable.CompositionItems = salvageable.Instance.ReturnComposition();
			}
		}
	}

	public override void UpdateState()
	{
		using ListPool<Item>.List list = ReturnSalvageableItems();
		bool flag = 0 < list.Count;
		if (base.State == ILandmarkActionStates.Inactive && flag)
		{
			Activate();
		}
		else if (base.State == ILandmarkActionStates.Active && !flag)
		{
			Deactivate();
		}
		else if (flag)
		{
			AssignItemsToHaul();
		}
	}

	protected override void OnCompleted()
	{
		foreach (Salvageable salvageable in _salvageables)
		{
			if (!(salvageable.Instance == null))
			{
				salvageable.Instance.CompositionUpdatedEvent -= SalvageableCompositionUpdatedEvent;
			}
		}
	}

	private void SalvageableCompositionUpdatedEvent(float progress)
	{
		if (_compositionUpdatedCoroutine == null)
		{
			_compositionUpdatedCoroutine = _landmarkBehaviour.Landmark.StartCoroutine(CompositionUpdatedCoroutine());
		}
	}

	private IEnumerator CompositionUpdatedCoroutine()
	{
		yield return new WaitForEndOfFrame();
		CompositionUpdated.Invoke();
		base.UpdatedEvent.Invoke(this);
		if (IsLandmarkSalvaged())
		{
			OnProjectFinished(base.Project, success: true);
		}
		_compositionUpdatedCoroutine = null;
	}

	public override void CountItems(InventoryAuditor auditor, Landmark landmark)
	{
		foreach (Salvageable salvageable in _salvageables)
		{
			salvageable.CountItemsInComposition(auditor);
		}
	}

	private void AddSalvageableToCategory(Salvageable salvageable)
	{
		foreach (Category category in Categories)
		{
			if (category.TryAddMember(salvageable))
			{
				return;
			}
		}
		Categories.Add(new Category(this, salvageable));
	}

	private int CompareCategories(Category left, Category right)
	{
		if (left.CategoryAsset == null)
		{
			return 1;
		}
		if (right.CategoryAsset == null)
		{
			return -1;
		}
		return left.CategoryAsset.UIOrder - right.CategoryAsset.UIOrder;
	}

	private void AssignItemsToHaul()
	{
		if (base.Project == null)
		{
			return;
		}
		foreach (ProjectAssignment assignment in base.Project.Assignments)
		{
			if ((assignment.Flags & ProjectAssignmentFlags.Salvaging) != ProjectAssignmentFlags.None)
			{
				PopulateItemsToHaul(assignment);
			}
		}
	}

	public override Project ReturnProject()
	{
		return new Project(base.UseBoat ? GameManager.Settings.ProjectSettings.SalvagePOIProperties : GameManager.Settings.ProjectSettings.SalvagePOISwimProperties, _landmarkBehaviour.Landmark.gameObject, this)
		{
			AssignmentLimit = base.AssignmentLimit
		};
	}

	protected override void OnProjectFinished(Project project, bool success)
	{
		success = AreAllCategoriesUnlocked() && ReturnIsCompleted();
		base.OnProjectFinished(project, success);
	}

	public override void InitializeUI(LandmarkPanel landmarkPanel)
	{
		landmarkPanel.ReturnLandmarkActionUI<LandmarkActionSalvageUINew>().Initialize(this);
	}

	public List<InventoryAuditor.CountedItem> ReturnCountedSalvageableItems()
	{
		if (_auditor == null)
		{
			_auditor = new InventoryAuditor();
		}
		else
		{
			_auditor.Reset();
		}
		foreach (Category category in Categories)
		{
			category.CountSalvageableItems(_auditor);
		}
		return _auditor.CountedItems;
	}

	public bool IsLandmarkSalvaged()
	{
		foreach (Category category in Categories)
		{
			if (!category.Unlocked)
			{
				return false;
			}
		}
		List<InventoryAuditor.CountedItem> list = ReturnCountedSalvageableItems();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].UnreservedCount + list[i].ReservedCount > 0)
			{
				return false;
			}
		}
		return true;
	}

	private ListPool<Item>.List ReturnSalvageableItems(bool includeReserved = true, bool markedForSalvageOnly = true)
	{
		ListPool<Item>.List list = ListPool<Item>.Get();
		foreach (Category category in Categories)
		{
			if (!markedForSalvageOnly || category.MarkedForSalvage)
			{
				category.PopulateSalvageableItems(list, includeReserved);
			}
		}
		return list;
	}

	private bool ReturnIsCompleted()
	{
		foreach (Category category in Categories)
		{
			if (!category.ReturnIsCompleted())
			{
				return false;
			}
		}
		return true;
	}

	public override bool TryReturnInteractableTooltip(out LocalizedString tooltip)
	{
		if (ReturnIsInteractable() || AreAllCategoriesUnlocked())
		{
			tooltip = default(LocalizedString);
		}
		else
		{
			tooltip = _categoriesLockedTooltip;
		}
		return (string)tooltip != null;
	}

	public bool AreAllCategoriesUnlocked()
	{
		foreach (Category category in Categories)
		{
			if (!category.Unlocked)
			{
				return false;
			}
		}
		return true;
	}

	public bool ReturnIsAnyCategoryToggled()
	{
		foreach (Category category in Categories)
		{
			if (category.IsToggled)
			{
				return true;
			}
		}
		return false;
	}

	public void PopulateItemsToHaul(ProjectAssignment assignment)
	{
		Item itemToSalvage;
		while (TryReturnClosestSalvageableItem(out itemToSalvage, assignment) && assignment.AddItemToHaul(itemToSalvage))
		{
		}
	}

	public int PopulateItemList(Itemlist itemlist)
	{
		int num = 0;
		foreach (InventoryAuditor.CountedItem item in ReturnCountedSalvageableItems())
		{
			if (item.UnreservedCount != 0 && itemlist.TryAddUniqueItemSlot(num, item.ItemProperties))
			{
				num++;
			}
		}
		return num;
	}

	private bool TryReturnClosestSalvageableItem(out Item itemToSalvage, ProjectAssignment assignment)
	{
		ListPool<Item>.List list = ReturnSalvageableItems(includeReserved: false);
		itemToSalvage = null;
		using (list)
		{
			if (list.Count == 0)
			{
				return false;
			}
			ReserveFillInventory.SortedItemsByDistanceFromMooringpoint(assignment.Agent, assignment.Project, list);
			if (assignment.RequiresStorageSpace)
			{
				foreach (Item item in list)
				{
					if (assignment.Agent.Community.Inventory.FitsItem(item))
					{
						itemToSalvage = item;
						break;
					}
				}
			}
			else
			{
				itemToSalvage = list[0];
			}
			return itemToSalvage != null;
		}
	}

	public void ToggleItemFilter(ItemProperties itemProperties)
	{
		if (ItemFilter.TryGetValue(itemProperties, out var value))
		{
			ItemFilter[itemProperties] = !value;
		}
	}

	public ProjectBlocker ReturnProjectBlockers(Project project)
	{
		CommunityInventory inventory = Community.PlayerCommunity.Inventory;
		bool requiresGeneralStorageSpace = project.Properties.RequiresGeneralStorageSpace;
		int num = 0;
		foreach (InventoryAuditor.CountedItem item in ReturnCountedSalvageableItems())
		{
			if (item.UnreservedCount != 0)
			{
				if (!requiresGeneralStorageSpace || inventory.ReturnFitsItemWithProperties(item.ItemProperties))
				{
					return ProjectBlocker.None;
				}
				num += item.UnreservedCount;
			}
		}
		if (0 >= num)
		{
			return ProjectBlocker.SharableEmptyItemList;
		}
		return ProjectBlocker.StorageSpace;
	}

	public bool ReturnIsSalvageableItem(Item item)
	{
		using ListPool<Item>.List list = ReturnSalvageableItems();
		return list.Contains(item);
	}

	public bool ReturnIsSalvageableItem(ItemProperties itemProperties)
	{
		using (ListPool<Item>.List list = ReturnSalvageableItems())
		{
			foreach (Item item in list)
			{
				if (item.Properties == itemProperties)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool ReturnIsItemFilterToggled(ItemProperties itemProperties)
	{
		if (ItemFilter.TryGetValue(itemProperties, out var value))
		{
			return value;
		}
		return false;
	}

	public bool ReturnHasSalvageableItems(Project project, Agent agent)
	{
		using ListPool<Item>.List list = ReturnSalvageableItems(includeReserved: false);
		return 0 < list.Count && (!project.Properties.RequiresGeneralStorageSpace || agent.Community.Inventory.ReturnFitsAnyItem(list));
	}

	public bool ReturnHasCompletedCategory()
	{
		if (Categories.IsNullOrEmpty())
		{
			return true;
		}
		foreach (Category category in Categories)
		{
			if (category.IsCompleted)
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnIsSalvaged()
	{
		foreach (Category category in Categories)
		{
			if (category.IsToggled && !category.ReturnIsCompleted())
			{
				return false;
			}
		}
		return true;
	}

	public float ReturnSalvageItemExperience(Item item)
	{
		foreach (Category category in Categories)
		{
			if (category.TryReturnSalvageItemExperience(item, out var experience))
			{
				return experience;
			}
		}
		return 0f;
	}

	public override float ReturnProgress()
	{
		if (Categories.IsNullOrEmpty())
		{
			return 0f;
		}
		InventoryAuditor.Global.Reset();
		float num = 0f;
		foreach (Category category in Categories)
		{
			if (!category.RequiresAssignmentType && !category.RequiresBuildable)
			{
				num += (float)category.TotalItemCount;
				category.CountItems(InventoryAuditor.Global);
			}
		}
		if (num != 0f)
		{
			return 1f - (float)InventoryAuditor.Global.TotalItemCount / num;
		}
		return 1f;
	}

	public override LandmarkActionPersistentData ReturnLandmarkActionPersistentData()
	{
		return new LandmarkActionSalvagePersistentData(this);
	}

	public override void Restore(LandmarkActionPersistentData data, LandmarkBehaviour landmarkBehaviour)
	{
		base.Restore(data, landmarkBehaviour);
		LandmarkActionSalvagePersistentData landmarkActionSalvagePersistentData = data as LandmarkActionSalvagePersistentData;
		SetAssignmentLimit(landmarkActionSalvagePersistentData.AgentLimit);
	}

	public override void RestoreReferences(LandmarkActionPersistentData data)
	{
		base.RestoreReferences(data);
		if (!(data is LandmarkActionSalvagePersistentData landmarkActionSalvagePersistentData))
		{
			return;
		}
		if (base.Project != null)
		{
			base.Project.SalvageTarget = this;
		}
		SetAssignmentLimit(base.AssignmentLimit);
		if (landmarkActionSalvagePersistentData.ItemFilter != null)
		{
			landmarkActionSalvagePersistentData.ItemFilter.Restore(ItemFilter);
		}
		foreach (Category category in Categories)
		{
			category.Unlocked = category.Unlocked || landmarkActionSalvagePersistentData.IsCategoryUnlocked(category.CategoryAsset);
			category.InitializeUnlockables(_landmarkBehaviour.Landmark.Unlockables);
			if (category.IsToggled != landmarkActionSalvagePersistentData.IsCategoryToggled(category.CategoryAsset))
			{
				category.Toggle();
			}
			landmarkActionSalvagePersistentData.RestoreCategoryItemFilter(category.CategoryAsset, category.ItemFilter);
			if (!category.IsCompleted && base.State == ILandmarkActionStates.Completed)
			{
				SetState(ILandmarkActionStates.Inactive, dispatchEvent: false);
				Debug.LogException(new Exception("LandmarkActionSalavge for landmark " + _landmarkBehaviour.name + " state was persisted as 'Completed', but category '" + category.Label + "' is not yet completed. Setting LandmarkAction state to 'Inactive'"));
			}
		}
	}
}
