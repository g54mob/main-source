using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HospitalPlotDefinition
	{
		public LocalisedString NameLocalised;

		public int Cost;

		[FullInspector.InspectorName("Bought")]
		public bool InitiallyOpen = true;

		public bool Built;

		public bool InstaBuild;

		public bool HideUntilAvailable;

		[InspectorShowIf("HideUntilAvailable")]
		public bool NotHiddenInSandbox;

		public bool IncludePerimiterInNavMesh = true;

		[InspectorTooltip("Whether the energy UI should be displayed when purchasing this plot")]
		public bool UseEnergyUI;

		public int EnergyUnitsGenerated;

		public Texture2D FloorImage;

		public float TimeToBuild = 60f;

		public Color Color = Color.white;

		public float FootprintYOffset;

		public SharedInstance<RoomDefinition> BuiltRoomDefinition;

		public SharedInstance<RoomDefinition> BuildingRoomDefinition;

		public SharedInstance<RoomDefinition> UnbuiltRoomDefinition;

		public SharedInstance<RoomItemDefinition> MainEntranceDefinition;

		public SharedInstance<RoomItemDefinition> SideEntranceDefinition;

		public SharedInstance<RoomItemDefinition> InternalEntranceDefinition;

		public SharedInstance<RoomItemDefinition> WindowDefinition;

		public ParticleSystem DemolishParticleSystemOverride;

		public bool BuildObjectiveAutoStart;

		public bool BuildObjectiveStartOnPrereqsMet;

		public SharedInstance<ObjectiveDefinition> BuildObjective;

		[HideInInspector]
		[SerializeField]
		private List<HospitalPlotItem> Items;

		[HideInInspector]
		[SerializeField]
		private List<HospitalPlotItem> BuiltItems;

		[HideInInspector]
		[SerializeField]
		private List<HospitalPlotItem> UnbuiltItems;

		public List<HospitalPlotPrerequisite> Prerequisites;

		public SharedInstance<HospitalPlotDefinition> MergeInto;

		public GridDirection AmbulanceBayEntranceSide = GridDirection.Max;

		public GridCoord Anchor => new GridCoord(-FloorImage.width / 2, -FloorImage.height / 2);

		public List<HospitalPlotItem> GetItems(HospitalPlotLayer layer)
		{
			ValidateLists();
			return layer switch
			{
				HospitalPlotLayer.Base => Items, 
				HospitalPlotLayer.Built => BuiltItems, 
				HospitalPlotLayer.Unbuilt => UnbuiltItems, 
				_ => throw new ArgumentOutOfRangeException("layer", layer, null), 
			};
		}

		public bool Available(Level level)
		{
			if (Prerequisites != null)
			{
				foreach (HospitalPlotPrerequisite prerequisite in Prerequisites)
				{
					if (!prerequisite.Valid(level))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool RemoveDuplicateItems()
		{
			return (byte)(0u | (RemoveDuplicateItems(ref Items) ? 1u : 0u) | (RemoveDuplicateItems(ref BuiltItems) ? 1u : 0u) | (RemoveDuplicateItems(ref UnbuiltItems) ? 1u : 0u)) != 0;
		}

		private bool RemoveDuplicateItems(ref List<HospitalPlotItem> items)
		{
			if (items != null)
			{
				int count = items.Count;
				items = items.Distinct(new HospitalPlotItemEqualityComparer()).ToList();
				if (count != items.Count)
				{
					SharedInstanceUtils.MarkAsDirty(this);
					return true;
				}
			}
			return false;
		}

		public bool Contains(RoomItem roomItem, FloorPlan hospitalFloorPlan, HospitalPlotLayer hospitalPlotLayer, Vector3 cellOffset = default(Vector3))
		{
			Vector3 position = roomItem.WorldPosition - hospitalFloorPlan.Anchor.ToWorldPosition() + cellOffset;
			SharedInstance<RoomItemDefinition> sharedInstance = SharedInstanceUtils.GetSharedInstance(roomItem.Definition as RoomItemDefinition);
			HospitalPlotItem item = new HospitalPlotItem
			{
				Definition = sharedInstance,
				Position = position,
				Rotation = roomItem.Rotation
			};
			List<HospitalPlotItem> items = GetItems(hospitalPlotLayer);
			if (items != null)
			{
				foreach (HospitalPlotItem item2 in items)
				{
					if (item2.Equals(item))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void AddItem(HospitalPlotItem hospitalPlotItem, HospitalPlotLayer layer)
		{
			ValidateLists();
			(layer switch
			{
				HospitalPlotLayer.Base => Items, 
				HospitalPlotLayer.Built => BuiltItems, 
				_ => UnbuiltItems, 
			}).Add(hospitalPlotItem);
		}

		private void ValidateLists()
		{
			if (Items == null)
			{
				Items = new List<HospitalPlotItem>();
			}
			if (BuiltItems == null)
			{
				BuiltItems = new List<HospitalPlotItem>();
			}
			if (UnbuiltItems == null)
			{
				UnbuiltItems = new List<HospitalPlotItem>();
			}
		}

		public bool RemoveItem(RoomItem roomItem)
		{
			foreach (HospitalPlotLayer value in Enum.GetValues(typeof(HospitalPlotLayer)))
			{
				List<HospitalPlotItem> items = GetItems(value);
				if (items == null)
				{
					continue;
				}
				foreach (HospitalPlotItem item in items)
				{
					if (item.Equals(roomItem))
					{
						items.Remove(item);
						return true;
					}
				}
			}
			return false;
		}

		public string GetPrerequisiteText()
		{
			string text = string.Empty;
			if (Prerequisites != null)
			{
				for (int i = 0; i < Prerequisites.Count; i++)
				{
					text += Prerequisites[i].Description();
					if (Prerequisites.Count != 1 && i != Prerequisites.Count - 1)
					{
						text += ScriptLocalization.HospitalPlot.PrerequisiteSeperator_CS;
					}
				}
			}
			return text;
		}
	}
}
