using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Resources
{
	[Serializable]
	public class ManageGroupPreset : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string displayName;

		[SerializeField]
		private string groupId;

		[SerializeField]
		private bool defaultPreset;

		[SerializeField]
		private float hitpointsMin;

		[SerializeField]
		private float hitpointsMax;

		[SerializeField]
		private int qualityMin;

		[SerializeField]
		private int qualityMax;

		[SerializeField]
		private List<string> allowedResources;

		[SerializeField]
		private List<string> forbiddenResources;

		[SerializeField]
		private bool forceUnequipInvalid;

		[SerializeField]
		private List<string> yearlyOverrideAllowedResources;

		[SerializeField]
		private List<string> yearlyOverrideForbiddenResources;

		[SerializeField]
		private int yearlyOverrideDateMin;

		[SerializeField]
		private int yearlyOverrideDateMax;

		[SerializeField]
		private bool isYearlyOverrideEnabled;

		[NonSerialized]
		private HashSet<Resource> manageGroupResourcesCached;

		public string DisplayName => displayName = ((displayName == string.Empty) ? MonoSingleton<LocalizationController>.Instance.GetText("preset_name_" + id) : displayName);

		public string GroupId => groupId;

		public bool DefaultPreset => defaultPreset;

		public List<string> DefaultAllowedResources => allowedResources ?? new List<string>();

		public List<string> DefaultForbiddenResources => forbiddenResources ?? new List<string>();

		public List<string> YearlyOverrideAllowedResources => yearlyOverrideAllowedResources ?? new List<string>();

		public List<string> YearlyOverrideForbiddenResources => yearlyOverrideForbiddenResources ?? new List<string>();

		public int YearlyOverrideDateMin => yearlyOverrideDateMin;

		public int YearlyOverrideDateMax => yearlyOverrideDateMax;

		public float HitpointsMin => hitpointsMin;

		public float HitpointsMax => hitpointsMax;

		public int QualityMin => qualityMin;

		public int QualityMax => qualityMax;

		public bool ForceUnequipInvalid
		{
			get
			{
				return forceUnequipInvalid;
			}
			set
			{
				forceUnequipInvalid = value;
			}
		}

		public bool IsYearlyOverrideEnabled
		{
			get
			{
				return isYearlyOverrideEnabled;
			}
			set
			{
				isYearlyOverrideEnabled = value;
			}
		}

		public ManageGroupPreset(string id, string displayName, string groupId, FloatRange hitponts, IntRange quality, List<string> allowedResources, List<string> forbiddenResources, bool defaultPreset, bool forceUnequipInvalid, List<string> yearlyOverrideAllowedResources = null, List<string> yearlyOverrideForbiddenResources = null, int yearlyOverrideDateMin = -1, int yearlyOverrideDateMax = -1, bool isYearlyOverrideEnabled = false)
		{
			this.id = id;
			this.displayName = displayName;
			this.groupId = groupId;
			this.defaultPreset = defaultPreset;
			hitpointsMin = hitponts.Min;
			hitpointsMax = hitponts.Max;
			qualityMin = quality.Min;
			qualityMax = quality.Max;
			this.allowedResources = allowedResources;
			this.forbiddenResources = forbiddenResources;
			this.yearlyOverrideAllowedResources = yearlyOverrideAllowedResources ?? new List<string>();
			this.yearlyOverrideForbiddenResources = yearlyOverrideForbiddenResources ?? new List<string>();
			this.yearlyOverrideDateMin = yearlyOverrideDateMin;
			this.yearlyOverrideDateMax = yearlyOverrideDateMax;
			this.forceUnequipInvalid = forceUnequipInvalid;
			this.isYearlyOverrideEnabled = isYearlyOverrideEnabled;
		}

		public override string GetID()
		{
			return id;
		}

		public List<string> GetAllowedResources(WorldDate date)
		{
			if (isYearlyOverrideEnabled && yearlyOverrideDateMin != yearlyOverrideDateMax)
			{
				int dayOfYear = date.DayOfYear;
				if (dayOfYear >= yearlyOverrideDateMin && dayOfYear <= yearlyOverrideDateMax)
				{
					return yearlyOverrideAllowedResources;
				}
			}
			return allowedResources;
		}

		public List<string> GetForbiddenResources(WorldDate date)
		{
			if (isYearlyOverrideEnabled && yearlyOverrideDateMin != yearlyOverrideDateMax)
			{
				int dayOfYear = date.DayOfYear;
				if (dayOfYear >= yearlyOverrideDateMin && dayOfYear <= yearlyOverrideDateMax)
				{
					return yearlyOverrideForbiddenResources;
				}
			}
			return forbiddenResources;
		}

		public bool IsResourceValid(Resource resource, WorldDate date)
		{
			if (resource == null)
			{
				return false;
			}
			bool num = (int)resource.Quality >= QualityMin && (int)resource.Quality <= QualityMax;
			List<string> list = GetAllowedResources(date);
			if (num)
			{
				return list.Contains(resource.GroupIdentifier);
			}
			return false;
		}

		public bool IsItemValid(EquipmentInstance item, WorldDate date)
		{
			if (item == null)
			{
				return false;
			}
			if (!IsResourceValid(item.Blueprint.Resource, date))
			{
				return false;
			}
			StatInstance stat = item.Stats.GetStat(StatType.Health);
			if (stat == null)
			{
				return false;
			}
			float num = stat.Current / stat.Max;
			if (num >= HitpointsMin)
			{
				return num <= HitpointsMax;
			}
			return false;
		}

		public bool IsResourcePartOfManageGroup(Resource resource)
		{
			if (manageGroupResourcesCached == null)
			{
				InitManageGroupResources();
			}
			return manageGroupResourcesCached.Contains(resource);
		}

		public void InitManageGroupResources()
		{
			if (manageGroupResourcesCached == null)
			{
				manageGroupResourcesCached = new HashSet<Resource>();
				Repository<ManageGroupRepository, ManageGroup>.Instance.GetByID(groupId).GetResources(manageGroupResourcesCached);
			}
		}

		public ManageGroup GetManageGroup()
		{
			return Repository<ManageGroupRepository, ManageGroup>.Instance.GetByID(groupId);
		}
	}
}
