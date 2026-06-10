using System.Collections.Generic;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;

namespace NSMedieval.UI
{
	public class InfoPanelBody
	{
		private readonly string objectId;

		private readonly string objectName;

		private readonly string objectMaterial;

		private readonly List<InfoPanelStat> stats;

		private readonly List<string> modifiers;

		private readonly List<string> modifierTooltips;

		private readonly List<InfoPanelResource> resources;

		private readonly List<InfoEquipmentStat> equipmentStats;

		private readonly List<string> descriptions;

		private readonly List<string> infos;

		private BuildingSubCategoryUI buildingSubcategoryUI;

		private readonly List<ResourcePileInstance> storageResources;

		private readonly List<DecayModifierData> decayModifiers;

		public LinkedList<LifeEventLogStruct> LifeEventLogs { get; }

		public string ObjectId => objectId;

		public string ObjectName => objectName;

		public string ObjectMaterial => objectMaterial;

		public List<InfoPanelStat> Stats => stats;

		public List<string> Modifiers => modifiers;

		public List<DecayModifierData> DecayModifiers => decayModifiers;

		public List<string> ModifierTooltips => modifierTooltips;

		public List<InfoPanelResource> Resources => resources;

		public List<InfoEquipmentStat> EquipmentStats => equipmentStats;

		public List<string> Descriptions => descriptions;

		public List<string> Infos => infos;

		public BuildingSubCategoryUI BuildingSubcategoryUI => buildingSubcategoryUI;

		public List<ResourcePileInstance> StorageResources => storageResources;

		public void InjectBuildingSubCategoryUI(BuildingSubCategoryUI buildingSubcategoryUI)
		{
			this.buildingSubcategoryUI = buildingSubcategoryUI;
		}

		public InfoPanelBody(string id, string name, string objectMaterial, List<InfoPanelStat> stats, List<string> modifiers, List<InfoPanelResource> resources, List<string> descriptions, List<string> infos, LinkedList<LifeEventLogStruct> lifeEventLogs = null, List<DecayModifierData> decayModifiers = null)
		{
			objectId = id;
			objectName = name;
			this.objectMaterial = objectMaterial;
			this.stats = stats ?? new List<InfoPanelStat>();
			this.modifiers = modifiers ?? new List<string>();
			this.resources = resources ?? new List<InfoPanelResource>();
			this.descriptions = descriptions ?? new List<string>();
			this.infos = infos ?? new List<string>();
			equipmentStats = new List<InfoEquipmentStat>();
			LifeEventLogs = lifeEventLogs;
			this.decayModifiers = decayModifiers;
		}

		public InfoPanelBody(string id, string name, string objectMaterial, List<InfoPanelStat> stats, List<string> modifiers, List<InfoPanelResource> resources, List<string> descriptions, List<string> infos, List<ResourcePileInstance> storageResources, LinkedList<LifeEventLogStruct> lifeEventLogs = null, List<DecayModifierData> decayModifiers = null)
		{
			objectId = id;
			objectName = name;
			this.objectMaterial = objectMaterial;
			this.stats = stats ?? new List<InfoPanelStat>();
			this.modifiers = modifiers ?? new List<string>();
			this.resources = resources ?? new List<InfoPanelResource>();
			this.descriptions = descriptions ?? new List<string>();
			this.infos = infos ?? new List<string>();
			equipmentStats = new List<InfoEquipmentStat>();
			this.storageResources = storageResources;
			LifeEventLogs = lifeEventLogs;
			this.decayModifiers = decayModifiers;
		}

		public InfoPanelBody(string id, string name, string objectMaterial, List<InfoPanelStat> stats, List<string> modifiers, List<string> modifierTooltips, List<InfoPanelResource> resources, List<string> descriptions, List<string> infos, List<DecayModifierData> decayModifiers = null)
		{
			objectId = id;
			objectName = name;
			this.objectMaterial = objectMaterial;
			this.stats = stats ?? new List<InfoPanelStat>();
			this.modifiers = modifiers ?? new List<string>();
			this.modifierTooltips = modifierTooltips ?? new List<string>();
			this.resources = resources ?? new List<InfoPanelResource>();
			this.descriptions = descriptions ?? new List<string>();
			this.infos = infos ?? new List<string>();
			equipmentStats = new List<InfoEquipmentStat>();
			this.decayModifiers = decayModifiers;
		}

		public InfoPanelBody(string id, string name, string objectMaterial, List<InfoPanelStat> stats, List<string> modifiers, List<InfoPanelResource> resources, List<string> descriptions, List<string> infos, BuildingSubCategoryUI buildingSubcategoryUI, LinkedList<LifeEventLogStruct> lifeEventLogs = null)
		{
			objectId = id;
			objectName = name;
			this.objectMaterial = objectMaterial;
			this.stats = stats ?? new List<InfoPanelStat>();
			this.modifiers = modifiers ?? new List<string>();
			this.resources = resources ?? new List<InfoPanelResource>();
			this.descriptions = descriptions ?? new List<string>();
			this.infos = infos ?? new List<string>();
			this.buildingSubcategoryUI = buildingSubcategoryUI;
			equipmentStats = new List<InfoEquipmentStat>();
			LifeEventLogs = lifeEventLogs;
		}

		public InfoPanelBody(string id, string name, string objectMaterial, List<InfoPanelStat> stats, List<string> modifiers, List<InfoPanelResource> resources, List<string> descriptions, List<string> infos, BuildingSubCategoryUI buildingSubcategoryUI, List<ResourcePileInstance> storageResources, LinkedList<LifeEventLogStruct> lifeEventLogs = null)
		{
			objectId = id;
			objectName = name;
			this.objectMaterial = objectMaterial;
			this.stats = stats ?? new List<InfoPanelStat>();
			this.modifiers = modifiers ?? new List<string>();
			this.resources = resources ?? new List<InfoPanelResource>();
			this.descriptions = descriptions ?? new List<string>();
			this.infos = infos ?? new List<string>();
			this.buildingSubcategoryUI = buildingSubcategoryUI;
			this.storageResources = storageResources ?? new List<ResourcePileInstance>();
			equipmentStats = new List<InfoEquipmentStat>();
			LifeEventLogs = lifeEventLogs;
		}

		public InfoPanelBody(string id, string name, string objectMaterial, List<InfoPanelStat> stats, List<string> modifiers, List<InfoPanelResource> resources, List<string> descriptions, List<string> infos, List<InfoEquipmentStat> equipmentStats, List<DecayModifierData> decayModifiers = null)
		{
			objectId = id;
			objectName = name;
			this.objectMaterial = objectMaterial;
			this.stats = stats ?? new List<InfoPanelStat>();
			this.modifiers = modifiers ?? new List<string>();
			this.descriptions = descriptions ?? new List<string>();
			this.infos = infos ?? new List<string>();
			this.equipmentStats = equipmentStats ?? new List<InfoEquipmentStat>();
			this.resources = resources ?? new List<InfoPanelResource>();
			this.decayModifiers = decayModifiers;
		}
	}
}
