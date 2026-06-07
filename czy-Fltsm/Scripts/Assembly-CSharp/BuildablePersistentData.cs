using System;
using System.Runtime.Serialization;
using PajamaLlama.Debugs;
using PajamaLlama.Math;
using UnityEngine;

[Serializable]
public class BuildablePersistentData : PersistentReference<Buildable>
{
	public int PropertiesIndex;

	public int VisualIndex;

	public Vector3 Position;

	public Quaternion Rotation;

	public BuildPhase BuildPhase;

	public InventoryPersistentData Inventory;

	public bool IsActive;

	public string Name;

	public PersistentReference<Project>.Reference AssignedProject;

	[OptionalField(VersionAdded = 4)]
	public int AssignmentLimit;

	[OptionalField(VersionAdded = 2)]
	public PersistentReference<Item>.Reference[] ReservedUpgradeItems;

	public IBuildableExtendablePersistentData[] Extendables;

	public int CommunityIndex;

	[OptionalField(VersionAdded = 3)]
	public Vector3[] OutlinePositions;

	public BuildablePersistentData(Buildable buildable)
		: base(buildable)
	{
		PropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(buildable.Properties);
		CommunityIndex = Community.ReturnCommunityIndex(buildable.Community);
		VisualIndex = buildable.VisualIndex;
		Position = buildable.transform.position;
		Rotation = buildable.transform.rotation;
		BuildPhase = buildable.BuildPhase;
		Inventory = new InventoryPersistentData(buildable.Inventory);
		IsActive = buildable.IsActive;
		Name = buildable.CustomName;
		Extendables = buildable.ReturnExtendablesPersistentData();
		if (buildable.OutlinePositions != null)
		{
			OutlinePositions = new Vector3[buildable.OutlinePositions.Length];
			for (int i = 0; i < buildable.OutlinePositions.Length; i++)
			{
				OutlinePositions[i] = buildable.OutlinePositions[i].Vector3TopDown();
			}
		}
	}

	public void PopulateReferences()
	{
		AssignmentLimit = base.Instance.AssignmentLimit;
		if (base.Instance.AssignedProject != null)
		{
			AssignedProject = base.Instance.AssignedProject;
		}
		if (base.Instance.ReservedUpgradeItems != null)
		{
			ReservedUpgradeItems = new PersistentReference<Item>.Reference[base.Instance.ReservedUpgradeItems.Count];
			for (int i = 0; i < base.Instance.ReservedUpgradeItems.Count; i++)
			{
				ReservedUpgradeItems[i] = base.Instance.ReservedUpgradeItems[i];
			}
		}
		for (int j = 0; j < Extendables.Length; j++)
		{
			Extendables[j].PopulateReferences();
		}
	}

	public override void Restore()
	{
		if (GameManager.PersistenceManager.TryReturnPropertiesReference<BuildableProperties>(PropertiesIndex, out var reference))
		{
			base.Restore();
			base.Instance = UnityEngine.Object.Instantiate(reference.Prefab, Position, Rotation);
			Community.Communities.TryGetValueAtIndex(CommunityIndex, out var item);
			Vector2[] array = null;
			if (OutlinePositions != null)
			{
				array = new Vector2[OutlinePositions.Length];
				for (int i = 0; i < OutlinePositions.Length; i++)
				{
					array[i] = OutlinePositions[i].Vector2TopDown();
				}
			}
			base.Instance.Initialize(item, VisualIndex, array, restored: true);
			Inventory.Restore(base.Instance.Inventory, base.Instance.gameObject);
			base.Instance.RestorePhase(BuildPhase);
			if (Name != null)
			{
				base.Instance.Name = Name;
			}
			IBuildableExtendablePersistentData[] extendables = Extendables;
			foreach (IBuildableExtendablePersistentData obj in extendables)
			{
				obj.Restore();
				obj.RestoreData(base.Instance);
			}
		}
		else
		{
			Debugger.Warning("Buildable was unable to be restored because the BuildableProperties could not be referenced!");
		}
	}

	public void RestoreReferences()
	{
		if (base.Instance == null)
		{
			return;
		}
		if (!UnlockableManager.IsUnlocked(base.Instance.Properties) && GameManager.Settings.TechTree.UnlockNodeWithUnlockable(base.Instance.Properties, validateDependencyIntegrity: true))
		{
			Debug.LogErrorFormat("Buildable with properties '{0}' was restored, but not marked as Unlocked!", base.Instance.Properties.name);
		}
		for (int i = 0; i < Extendables.Length; i++)
		{
			Extendables[i].RestoreReferences();
		}
		if (BuildPhase == BuildPhase.SalvageShutdown)
		{
			base.Instance.Shutdown();
		}
		if (IsActive)
		{
			base.Instance.Activate();
		}
		else
		{
			base.Instance.Deactivate();
		}
		if (AssignedProject.TryReturn(out var instance))
		{
			base.Instance.RestoreAssignedProject(instance);
		}
		base.Instance.AssignmentLimit = AssignmentLimit;
		if (ReservedUpgradeItems != null)
		{
			Item instance2 = null;
			base.Instance.ReservedUpgradeItems.Clear();
			base.Instance.ReservedUpgradeItems.Capacity = ReservedUpgradeItems.Length;
			PersistentReference<Item>.Reference[] reservedUpgradeItems = ReservedUpgradeItems;
			for (int j = 0; j < reservedUpgradeItems.Length; j++)
			{
				if (reservedUpgradeItems[j].TryReturn(out instance2))
				{
					base.Instance.ReservedUpgradeItems.Add(instance2);
				}
			}
		}
		if (base.Instance.TryReturnBuildableExtendable<WalkwayPonton>(out var _))
		{
			base.Instance.StopAssignedProject();
			base.Instance.Activate();
		}
	}

	public bool TryReturnBuildableExtendable<T>(out T buildableExtendable)
	{
		if (Extendables != null)
		{
			IBuildableExtendablePersistentData[] extendables = Extendables;
			foreach (IBuildableExtendablePersistentData buildableExtendablePersistentData in extendables)
			{
				if (buildableExtendablePersistentData is T)
				{
					buildableExtendable = (T)buildableExtendablePersistentData;
					return true;
				}
			}
		}
		buildableExtendable = default(T);
		return false;
	}
}
