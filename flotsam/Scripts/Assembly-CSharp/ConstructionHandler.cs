using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public class ConstructionHandler
{
	public Action<float> OnProgressUpdated;

	private WeakReference<IConstructible> _owner;

	private PlaceableProperties _properties;

	private ConstructibleStatus _status;

	private Inventory _inventory;

	private ResourceProvider _resourceProvider;

	private int _assignmentLimit = 1;

	public BuildPhase BuildPhase { get; private set; }

	public bool CancelConstructionAfterHaul { get; private set; }

	public float Progress { get; private set; }

	public Project AssignedProject { get; private set; }

	public int AssignmentLimit
	{
		get
		{
			if (AssignedProject == null || !AssignedProject.Properties.AllowAgentLimitOverride)
			{
				return _assignmentLimit;
			}
			return AssignedProject.AssignmentLimit;
		}
		set
		{
			value = Mathf.Max(1, value);
			if (AssignedProject != null && AssignedProject.Properties.AllowAgentLimitOverride)
			{
				if (AssignedProject.Properties.AllowAgentLimitOverride)
				{
					AssignedProject.AssignmentLimit = value;
				}
			}
			else
			{
				_assignmentLimit = value;
			}
		}
	}

	public bool IsInitialized => _owner != null;

	public void Start()
	{
		if (BuildPhase == BuildPhase.HaulFrom)
		{
			EndSalvaging();
		}
		if (BuildPhase == BuildPhase.HaulTo && (bool)_properties && _properties.HaulToConstructibleProjectProperties.IsGlobal && !_inventory.HasIncomingItems(SubInventoryType.Composition))
		{
			if (_inventory.ReturnCompositionProgress() < 1f)
			{
				StartSalvaging();
			}
			else
			{
				FinishBuilding();
			}
		}
	}

	public void Initialize(IConstructible owner)
	{
		_owner = new WeakReference<IConstructible>(owner);
		_properties = owner.Properties;
		_status = owner.StatusHolder;
		_inventory = owner.Inventory;
		_inventory.CompositionUpdatedEvent += OnCompositionUpdatedEvent;
	}

	~ConstructionHandler()
	{
		if (AssignedProject != null)
		{
			AssignedProject.ProjectAssignmentsUpdated.RemoveListener(UpdateBuildPhaseStatus);
			AssignedProject.FinishedEvent.RemoveListener(OnAssignedProjectFinished);
		}
		_inventory.CompositionUpdatedEvent -= OnCompositionUpdatedEvent;
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, FinishBuilding);
	}

	public void StartBuilding(bool instantFreeBuild = false)
	{
		if (instantFreeBuild || BuildingDevTools.InstantBuild)
		{
			ChangeBuildPhase(BuildPhase.Build);
			_inventory.FillComposition(_properties.RequiredResources);
			FinishBuilding();
		}
		else
		{
			StartConstructionProject();
		}
	}

	public void TryToSalvage()
	{
		if (_owner.TryGetTarget(out var target) && target.CanBeSalvaged())
		{
			StartSalvaging();
		}
	}

	public void CancelSalvaging()
	{
		if (BuildPhase == BuildPhase.HaulTo)
		{
			CancelConstructionAfterHaul = false;
			UpdateBuildPhaseStatus();
			return;
		}
		if (BuildPhase == BuildPhase.SalvageShutdown)
		{
			FinishBuilding();
			return;
		}
		BuildPhase buildPhase = BuildPhase;
		if (buildPhase != BuildPhase.Deconstructing && buildPhase != BuildPhase.HaulFrom)
		{
			return;
		}
		using ListPool<Agent>.List list = ListPool<Agent>.Get();
		if (AssignedProject != null)
		{
			AssignedProject.ReturnAssignedAgents(list);
			AssignedProject.Stop(ProjectFlags.Cancelled);
		}
		_inventory.InventoryUpdatedEvent.RemoveListener(EndSalvaging);
		if (_owner.TryGetTarget(out var target))
		{
			target.DetachBuildingAgents();
		}
		foreach (Agent item in list)
		{
			item.ReturnNavigator().AttachToTarget(item.ReturnClosestConstruction(onlyFinished: true).Target, overrideCheck: true);
		}
		if (Mathf.Approximately(Progress, 1f))
		{
			FinishBuilding();
		}
		else
		{
			BuildConstructible();
		}
	}

	private void StartConstructionProject()
	{
		if (!_owner.TryGetTarget(out var target))
		{
			Debug.LogException(new NullReferenceException("Trying to start constructing a constructible but ConstructionHandler's owner is null!"));
			return;
		}
		using ListPool<CountedItemProperty>.List list = ListPool<CountedItemProperty>.Get();
		CountedItemProperty[] requiredResources = _properties.RequiredResources;
		foreach (CountedItemProperty countedItemProperty in requiredResources)
		{
			ItemProperties itemProperties = countedItemProperty.ItemProperties;
			int num = countedItemProperty.Amount - _inventory.ReturnCount(countedItemProperty.ItemProperties, SubInventoryType.Resources) - _inventory.ReturnCount(countedItemProperty.ItemProperties, SubInventoryType.Composition);
			if (num > 0)
			{
				list.Add(new CountedItemProperty(itemProperties, num));
			}
		}
		List<Item> list2 = ((list.Count > 0) ? ResourceManager.ReserveClosestItems(target, list) : null);
		if (_properties.HaulToConstructibleProjectProperties.IsGlobal)
		{
			foreach (Item item in list2)
			{
				if (!_inventory.ReturnContainsItem(item.Properties, 1, SubInventoryType.Composition) && !_inventory.ReserveIncomingItem(item, SubInventoryType.Composition))
				{
					Debug.LogException(new NotSupportedException("Could not reserve item \"" + item.Properties.name + "\" for constructing decoration " + target.Name + "!"));
				}
			}
		}
		if (_properties.HaulToConstructibleProjectProperties != null)
		{
			AssignProject(_properties.HaulToConstructibleProjectProperties, list2);
			ChangeBuildPhase(BuildPhase.HaulTo);
		}
		else
		{
			StartBuildPhase();
		}
	}

	private void StartSalvaging()
	{
		if (BuildPhase == BuildPhase.HaulTo && _inventory.HasIncomingItems(SubInventoryType.Composition))
		{
			CancelConstructionAfterHaul = true;
			UpdateBuildPhaseStatus();
		}
		else if (_inventory.ReturnCount(SubInventoryType.Composition, includeReserved: true) > 0)
		{
			StartDeconstructing();
		}
		else if (_inventory.ReturnCount(SubInventoryType.Resources, includeReserved: true) > 0)
		{
			HaulFromConstructible();
		}
		else
		{
			EndSalvaging();
		}
	}

	private void StartDeconstructing()
	{
		if (_properties.ShouldDeconstructInstantly)
		{
			foreach (Item item in _inventory.ReturnAllItems(SubInventoryType.Composition))
			{
				_inventory.MoveToSubInventory(item, SubInventoryType.Resources);
			}
			HaulFromConstructible();
		}
		else
		{
			AssignProject(GameSettings.Instance.ProjectSettings.DeconstructBuildableProperties);
			ChangeBuildPhase(BuildPhase.Deconstructing);
			_status.FlagMalfunctionsUpdated();
		}
	}

	private void HaulFromConstructible(bool restore = false)
	{
		if (_inventory.ReturnCount(SubInventoryType.Resources, includeReserved: true) <= 0 && !restore)
		{
			EndSalvaging();
			return;
		}
		ChangeBuildPhase(BuildPhase.HaulFrom);
		_inventory.InventoryUpdatedEvent.AddListener(EndSalvaging);
		if (_owner.TryGetTarget(out var target))
		{
			_resourceProvider = ResourceProvider.Get(target, SubInventoryType.Resources, AssignmentType.Constructing);
			_resourceProvider.Register();
		}
	}

	private void EndSalvaging()
	{
		if (_inventory.ReturnCount(SubInventoryType.Resources, includeReserved: true) <= 0)
		{
			if (_resourceProvider != null)
			{
				_resourceProvider.Unregister();
				_resourceProvider = null;
			}
			_inventory.InventoryUpdatedEvent.RemoveListener(EndSalvaging);
			if (_owner.TryGetTarget(out var target))
			{
				target.RemoveConstructible();
			}
		}
	}

	private void AssignProject(ProjectProperties projectProperties, List<Item> items = null)
	{
		if (_owner.TryGetTarget(out var target))
		{
			if (AssignedProject != null)
			{
				Debug.LogException(new NotSupportedException($"Trying to assign a project to {target.Name}, but it still has a reference to '{AssignedProject.Properties}'"));
			}
			if (projectProperties.IsGlobal && Community.PlayerCommunity.TryReturnProjectWithProperties(projectProperties, out var project))
			{
				AssignedProject = project;
			}
			else
			{
				AssignedProject = new Project(projectProperties, target.gameObject, items);
				AssignedProject.ProjectAssignmentsUpdated.AddListener(UpdateBuildPhaseStatus);
				AssignedProject.FinishedEvent.AddListener(OnAssignedProjectFinished);
				Community.PlayerCommunity.QueueProject(AssignedProject);
			}
			if (projectProperties.AllowAgentLimitOverride)
			{
				AssignedProject.AssignmentLimit = _assignmentLimit;
				_assignmentLimit = 1;
			}
		}
	}

	private void OnAssignedProjectFinished(Project project, bool success)
	{
		if (AssignedProject != null)
		{
			AssignedProject.ProjectAssignmentsUpdated.RemoveListener(UpdateBuildPhaseStatus);
			AssignedProject.FinishedEvent.RemoveListener(OnAssignedProjectFinished);
			AssignedProject = null;
		}
		IConstructible target;
		switch (BuildPhase)
		{
		case BuildPhase.HaulTo:
			OnHaulToFinished();
			break;
		case BuildPhase.Build:
			if (Progress >= 1f)
			{
				FinishBuilding();
			}
			break;
		case BuildPhase.UpgradeHaulTo:
			if (_owner.TryGetTarget(out target))
			{
				target.StartUpgrade();
			}
			break;
		case BuildPhase.Deconstructing:
			if (Progress <= 0f)
			{
				HaulFromConstructible();
			}
			break;
		case BuildPhase.SalvageShutdown:
			TryToSalvage();
			break;
		case BuildPhase.HaulFrom:
			if (_owner.TryGetTarget(out target))
			{
				target.RemoveConstructible();
			}
			break;
		case BuildPhase.Finished:
		case BuildPhase.UpgradeShutdown:
			break;
		}
	}

	public void SetProgress(float progress)
	{
		Progress = Mathf.Clamp01(progress);
		if (_owner.TryGetTarget(out var target))
		{
			target.SetProgress(progress);
		}
		OnProgressUpdated.SafeInvoke(progress);
	}

	private void MoveReservedResources(SubInventoryType from, SubInventoryType to)
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		_inventory.ReturnAllItems(from, list);
		foreach (Item item in list)
		{
			if (item.IsReserved)
			{
				item.CancelReservation();
				_inventory.MoveToSubInventory(item, to);
			}
		}
	}

	private void OnCompositionUpdatedEvent(float progress)
	{
		if (BuildPhase != BuildPhase.Finished)
		{
			SetProgress(progress);
		}
		if (AssignedProject != null && AssignedProject.Properties.IsGlobal)
		{
			BuildPhase buildPhase = BuildPhase;
			if (((buildPhase == BuildPhase.HaulTo || buildPhase == BuildPhase.Build) && progress >= 1f) || (BuildPhase == BuildPhase.Deconstructing && progress <= 0f))
			{
				OnAssignedProjectFinished(AssignedProject, success: true);
			}
		}
	}

	private void OnHaulToFinished()
	{
		if (CancelConstructionAfterHaul)
		{
			ChangeBuildPhase(BuildPhase.SalvageShutdown);
			TryToSalvage();
			CancelConstructionAfterHaul = false;
		}
		else
		{
			StartBuildPhase();
		}
	}

	private void FinishBuilding(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, FinishBuilding);
		FinishBuilding();
	}

	private void FinishBuilding(bool restored = false)
	{
		ChangeBuildPhase(BuildPhase.Finished);
		if (_owner.TryGetTarget(out var target))
		{
			target.FinishConstruction(restored);
		}
	}

	private void ChangeBuildPhase(BuildPhase buildPhase)
	{
		BuildPhase = buildPhase;
		UpdateBuildPhaseStatus();
		if (_owner.TryGetTarget(out var target))
		{
			target.OnBuildPhaseUpdated(BuildPhase);
		}
	}

	private void StartBuildPhase()
	{
		if (BuildPhase != BuildPhase.Build)
		{
			BuildConstructible();
		}
	}

	public void BuildConstructible()
	{
		if (_properties.ConstructionProjectProperties != null)
		{
			AssignProject(_properties.ConstructionProjectProperties);
			ChangeBuildPhase(BuildPhase.Build);
			return;
		}
		foreach (Item item in _inventory.ReturnAllItems(SubInventoryType.Resources))
		{
			if (!_inventory.ReserveIncomingItem(item, SubInventoryType.Composition))
			{
				Debug.LogException(new NotSupportedException("Could not reserve item \"" + item.Properties.name + "\" for constructing constructible " + _properties.Name + "!"));
			}
		}
		FinishBuilding();
	}

	private void UpdateBuildPhaseStatus()
	{
		switch (BuildPhase)
		{
		case BuildPhase.HaulTo:
			if (CancelConstructionAfterHaul)
			{
				_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusStoppingConstructionProperties);
			}
			else if (AssignedProject != null && AssignedProject.ReturnAssignedAgents().Count > 0)
			{
				_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusResourcesComingProperties);
			}
			else
			{
				_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusWaitingForResourcesProperties);
			}
			break;
		case BuildPhase.Build:
			if (AssignedProject != null && AssignedProject.ReturnAssignedAgents().Count > 0)
			{
				_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusBuildingProperties);
			}
			else
			{
				_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusWaitingForConstructorProperties);
			}
			break;
		case BuildPhase.Deconstructing:
			if (AssignedProject != null && AssignedProject.ReturnAssignedAgents().Count > 0)
			{
				_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusDeconstructingProperties);
			}
			else
			{
				_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusWaitingForDeconstructorProperties);
			}
			break;
		case BuildPhase.HaulFrom:
			_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusSalvagingHaulingItemstoStorageProperties);
			break;
		default:
			_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusIdleProperties);
			break;
		}
	}

	public bool CanBeDeconstructed(out LocalizedString error)
	{
		error = GameSettings.Instance.BuildableSettings.DeconstructionTooltip;
		BuildPhase buildPhase = BuildPhase;
		if (buildPhase == BuildPhase.HaulFrom || buildPhase == BuildPhase.UpgradeHaulFrom)
		{
			error = GameSettings.Instance.BuildableSettings.HaulFromTooltip;
			return false;
		}
		buildPhase = BuildPhase;
		if (buildPhase == BuildPhase.UpgradeHaulTo || buildPhase == BuildPhase.UpgradeShutdown)
		{
			error = GameSettings.Instance.BuildableSettings.UpgradeHaulToTooltip;
			return false;
		}
		if (BuildPhase == BuildPhase.Deconstructing || (BuildPhase == BuildPhase.HaulTo && CancelConstructionAfterHaul))
		{
			error = GameSettings.Instance.BuildableSettings.CancelDeconstructionTooltip;
			return true;
		}
		if (_owner.TryGetTarget(out var target))
		{
			return target.CanBeDeconstructed(out error);
		}
		return true;
	}

	public void Restore(int assignmentLimit, BuildPhase buildPhase, float progress)
	{
		_assignmentLimit = assignmentLimit;
		SetProgress(progress);
		RestorePhase(buildPhase);
	}

	public void RestoreReferences(Project project)
	{
		AssignedProject = project;
		if (AssignedProject != null)
		{
			AssignedProject.ProjectAssignmentsUpdated.AddListener(UpdateBuildPhaseStatus);
			AssignedProject.FinishedEvent.AddListener(OnAssignedProjectFinished);
		}
	}

	public void RestorePhase(BuildPhase buildPhase)
	{
		BuildPhase = buildPhase;
		switch (buildPhase)
		{
		case BuildPhase.Build:
			MoveReservedResources(SubInventoryType.Resources, SubInventoryType.Composition);
			if (_inventory.ReturnCount(SubInventoryType.Resources) == 0)
			{
				GameEventDispatcher.AddListener(GameEventType.GameStart, FinishBuilding);
			}
			break;
		case BuildPhase.Deconstructing:
			if (_properties.ShouldDeconstructInstantly)
			{
				MoveReservedResources(SubInventoryType.Composition, SubInventoryType.Resources);
				if (_inventory.ReturnCount(SubInventoryType.Composition) == 0)
				{
					goto case BuildPhase.HaulFrom;
				}
			}
			_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusDeconstructingProperties);
			break;
		case BuildPhase.HaulFrom:
			_status.SetStatus(GameSettings.Instance.BuildableSettings.StatusSalvagingHaulingItemstoStorageProperties);
			HaulFromConstructible(restore: true);
			break;
		case BuildPhase.Finished:
			FinishBuilding(restored: true);
			break;
		case BuildPhase.SalvageShutdown:
		case BuildPhase.HaulTo:
			break;
		}
	}
}
