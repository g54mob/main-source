using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomDefinition : EntityDefinition, IPriceModifier, ISilverUnlockable, ISilverUnlockToken
	{
		public enum Type
		{
			[UsedImplicitly]
			Invalid = -1,
			[UsedImplicitly]
			Hospital = 0,
			[UsedImplicitly]
			GPOffice = 1,
			[UsedImplicitly]
			Pharmacy = 2,
			[UsedImplicitly]
			XRay = 3,
			[UsedImplicitly]
			GeneralDiagnosis = 4,
			[UsedImplicitly]
			Cardiography = 5,
			[UsedImplicitly]
			MRIScanner = 6,
			[UsedImplicitly]
			Cafe = 7,
			[UsedImplicitly]
			Ward = 8,
			[UsedImplicitly]
			StaffRoom = 9,
			[UsedImplicitly]
			Toilets = 10,
			[UsedImplicitly]
			Training = 11,
			[UsedImplicitly]
			Research = 12,
			[UsedImplicitly]
			Psychiatry = 13,
			[UsedImplicitly]
			OperatingTheater = 14,
			[UsedImplicitly]
			ClinicCubism = 15,
			[UsedImplicitly]
			FluidAnalysis = 16,
			[UsedImplicitly]
			DNAAnalysis = 17,
			[UsedImplicitly]
			InjectionRoom = 18,
			[UsedImplicitly]
			Marketing = 19,
			[UsedImplicitly]
			Chromatherapy = 20,
			[UsedImplicitly]
			LightHeaded = 21,
			[UsedImplicitly]
			MummyClinic = 22,
			[UsedImplicitly]
			ElectricShockClinic = 23,
			[UsedImplicitly]
			ClownClinic = 24,
			[UsedImplicitly]
			PandemicClinic = 25,
			[UsedImplicitly]
			AnimalMagnetismClinic = 26,
			[UsedImplicitly]
			TurtleHeadClinic = 27,
			[UsedImplicitly]
			ClinicVI10 = 28,
			[UsedImplicitly]
			FractureWard = 29,
			[UsedImplicitly]
			Reception = 30,
			[UsedImplicitly]
			HospitalUnbuilt = 31,
			[UsedImplicitly]
			EightBitClinic = 32,
			[UsedImplicitly]
			FrankensteinClinic = 33,
			[UsedImplicitly]
			DogClinic = 34,
			[UsedImplicitly]
			RobotMonsterClinic = 35,
			[UsedImplicitly]
			BlankLooksClinic = 36,
			[UsedImplicitly]
			EightBallClinic = 37,
			[UsedImplicitly]
			ExplorerClinic = 38,
			[UsedImplicitly]
			CardboardClinic = 39,
			[UsedImplicitly]
			FrogClinic = 40,
			[UsedImplicitly]
			AstroClinic = 41,
			[UsedImplicitly]
			PinocchioClinic = 42,
			[UsedImplicitly]
			ScarecrowClinic = 43,
			[UsedImplicitly]
			TechClinic = 44,
			[UsedImplicitly]
			PlantWardClinic = 45,
			[UsedImplicitly]
			StuntmanClinic = 46,
			[UsedImplicitly]
			MudPersonClinic = 47,
			[UsedImplicitly]
			ToySoldierClinic = 48,
			[UsedImplicitly]
			TimeTunnel = 49,
			[UsedImplicitly]
			SnowballedClinic = 50,
			[UsedImplicitly]
			HivesClinic = 51,
			[UsedImplicitly]
			UnderTheWeatherClinic = 52,
			[UsedImplicitly]
			AmbulanceBay = 53,
			[UsedImplicitly]
			NoDataRoom = 54
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		private struct SatisfactionBehaviourOverride
		{
			public CharacterAttributes.Type Attribute;

			public ExternalBehavior Behavior;

			public SharedInstance<RoomItemDefinition>[] SpecificItems;
		}

		public static readonly Type[] DiagnosisRooms = new Type[8]
		{
			Type.GeneralDiagnosis,
			Type.Cardiography,
			Type.MRIScanner,
			Type.Ward,
			Type.Psychiatry,
			Type.FluidAnalysis,
			Type.DNAAnalysis,
			Type.XRay
		};

		public readonly Type _type;

		[SerializeField]
		private LocalisedString Name;

		public LocalisedString Description;

		public LocalisedString LongDescription;

		public LocalisedString UnlockedMessage;

		public readonly Sprite _icon;

		public readonly Sprite _jobAssignmentIcon;

		public readonly int _cost;

		public readonly int _silverCost;

		public readonly float Prestige = 3f;

		public readonly int PrestigePerExtraCell = 1;

		public readonly int MaxPrestigePerCell = 10;

		public readonly int _maxCapacity = 1;

		public readonly bool _hasQueue = true;

		public readonly bool _canManageQueue = true;

		public readonly bool _allowQueueWarningStatusIcon = true;

		[InspectorTooltip("Minimum number of staff for this room to be considered staffed")]
		public readonly int MinimumStaffCount;

		public readonly int _minSizeX = 3;

		public readonly int _minSizeY = 3;

		[InspectorTooltip("Stop staff evaluating needs and micro behaviours when using this room")]
		public readonly bool _disallowStaffNeeds;

		public readonly bool _allowStaffNeedsSatisfaction;

		public readonly bool _allowPatientsNeedsSatisfaction;

		public readonly bool _staffBreakRoom;

		public readonly WhoCanUseRoom.GroupDefinition[] WhoCanUseRoom;

		public readonly SharedInstance<DLCItemDefinition> DlcPackRequired;

		[InspectorTooltip("If true, only available if the room is white listed by the level config.")]
		public readonly bool MustBeWhiteListed;

		public readonly int _diagnosisCost;

		public readonly float _sessionDurationDefault = 10f;

		public readonly float WallThickness;

		public readonly bool UseHospitalFloorTile;

		public readonly GameObject _roomFloorTile;

		public readonly RoomWallDefinition _wallsInterior;

		public readonly RoomWallDefinition _wallsExterior;

		public SharedInstance<RoomWallDefinition> _blueprintWallDefinition;

		public SharedInstance<RoomWallDefinition> _dragAddWallDefinition;

		public SharedInstance<RoomWallDefinition> _dragSubWallDefinition;

		[FullInspector.InspectorName("RequiredItems")]
		public RequiredItem[] _requiredItemsNew;

		public readonly SharedInstance<RoomItemDefinition>[] _requiredWorkingItems;

		public readonly SharedInstance<RoomItemDefinition> _itemToLeaveOnCursor;

		public readonly RoomItemDefinition.Type[] _singlePlaceItems;

		public readonly StaffRequired[] _requiresStaff;

		public readonly float _staffEnergyModifierWork;

		public readonly float _staffEnergyModifierBreak;

		public readonly float _staffEnergyModifierIdle;

		public readonly Material _roomLightMaterial;

		public readonly Cubemap _roomReflectionCubemap;

		public readonly Material _roomClosedLightMaterial;

		public readonly Cubemap _roomClosedReflectionCubemap;

		public readonly Material _roomOperationalLightMaterial;

		public readonly Cubemap _roomOperationalReflectionCubemap;

		public readonly StaffPatientInteraction[] _staffPatientInteractions;

		public readonly LocalisedString _unitsProcessedStringInGUI;

		public readonly bool _showUnitsProcessedInGUI;

		public readonly bool _showTotalRevenueInGUI;

		public readonly GameObject _hoverMenuPrefab;

		public readonly GameObject _selectMenuPrefab;

		public RoomFilter[] Filters;

		public bool NoArributeData;

		[SerializeField]
		private readonly SatisfactionBehaviourOverride[] SatisfactionBehaviourOverrides;

		public ISilverUnlockToken SilverUnlockToken => this;

		public bool IsHospitalOrBay
		{
			get
			{
				if (_type != Type.Hospital)
				{
					return _type == Type.AmbulanceBay;
				}
				return true;
			}
		}

		public bool IsHospital => IsHospitalOnly;

		public bool IsHospitalOnly => _type == Type.Hospital;

		public bool IsAmbulanceBayOnly => _type == Type.AmbulanceBay;

		public bool IsNoDataRoom
		{
			get
			{
				if (_type != Type.AmbulanceBay)
				{
					return NoArributeData;
				}
				return true;
			}
		}

		public bool IsHospitalUnbuilt => _type == Type.HospitalUnbuilt;

		public LocalisedString LocalisedName => Name;

		public virtual string ToLocalisedString()
		{
			return GetLocalisedName();
		}

		public override string ToString()
		{
			return LocalisedName.ToString();
		}

		public string GetSanitizedName()
		{
			return LocalisedName.ToString().Replace("'", "_");
		}

		public string GetLocalisedName()
		{
			return LocalisedName.TranslationPlural(1);
		}

		public string GetLocalisedNamePlural(int count)
		{
			return LocalisedName.TranslationPlural(count);
		}

		public RoomItemDefinition GetItemToLeaveOnCursor()
		{
			if (!(_itemToLeaveOnCursor != null))
			{
				return null;
			}
			return _itemToLeaveOnCursor.Instance;
		}

		public RequiredItem[] GetRequiredItems()
		{
			return _requiredItemsNew;
		}

		public RequiredItem GetRequiredItem(IRoomItemDefinition definition)
		{
			if (_requiredItemsNew != null)
			{
				RequiredItem[] requiredItemsNew = _requiredItemsNew;
				foreach (RequiredItem requiredItem in requiredItemsNew)
				{
					if (requiredItem.Contains(definition))
					{
						return requiredItem;
					}
				}
			}
			return null;
		}

		public bool IsRequiredItem(IRoomItemDefinition itemDefinition)
		{
			return GetRequiredItem(itemDefinition) != null;
		}

		public bool RequiresWorkingItem(IRoomItemDefinition itemDefinition)
		{
			if (_requiredWorkingItems != null)
			{
				SharedInstance<RoomItemDefinition>[] requiredWorkingItems = _requiredWorkingItems;
				for (int i = 0; i < requiredWorkingItems.Length; i++)
				{
					if (requiredWorkingItems[i].Instance == itemDefinition)
					{
						return true;
					}
				}
			}
			return false;
		}

		public float GetStaffEnergyModifier(Staff staff, Room room)
		{
			if (staff.CurrentMode == Staff.Mode.Break)
			{
				float num = _staffEnergyModifierBreak;
				if (room != null && room.Definition._type == Type.StaffRoom)
				{
					num *= GameAlgorithms.CalculateRoomPrestige(room.FloorPlan).Data.StaffRoomEnergyMultiplier;
				}
				return num;
			}
			if (staff.CurrentJob != null)
			{
				return _staffEnergyModifierWork;
			}
			return _staffEnergyModifierIdle;
		}

		public bool UseBlueprintEditMode(IRoomItemDefinition itemDefinition)
		{
			if (IsHospitalOrBay)
			{
				return false;
			}
			if (itemDefinition.ItemType == RoomItemDefinition.Type.Research)
			{
				return false;
			}
			if (itemDefinition.ItemType == RoomItemDefinition.Type.Door || itemDefinition.ItemType == RoomItemDefinition.Type.Window)
			{
				return true;
			}
			return false;
		}

		public bool HasExteriorWalls()
		{
			return _wallsExterior.HasWallDefinition();
		}

		public int GetCostWithRequiredItems()
		{
			int num = _cost;
			if (_requiredItemsNew != null)
			{
				RequiredItem[] requiredItemsNew = _requiredItemsNew;
				foreach (RequiredItem requiredItem in requiredItemsNew)
				{
					if (requiredItem.Items == null)
					{
						continue;
					}
					int num2 = 0;
					SharedInstance<RoomItemDefinition>[] items = requiredItem.Items;
					foreach (SharedInstance<RoomItemDefinition> sharedInstance in items)
					{
						if (num2 == 0 || sharedInstance.Instance.GetCost() < num2)
						{
							num2 = sharedInstance.Instance.GetCost();
						}
					}
					num += num2;
				}
			}
			return num;
		}

		public bool RequiresCornerFillers()
		{
			if (_wallsInterior != null)
			{
				return _wallsInterior.GetPiece(RoomWallDefinition.Type.FillerLeft) != null;
			}
			return false;
		}

		public bool AlwaysAddStaff()
		{
			if (!IsHospitalOrBay && _type != Type.Training)
			{
				return _type == Type.Cafe;
			}
			return true;
		}

		public bool IsLowWallRoom()
		{
			if (_type != Type.Reception)
			{
				return _type == Type.Cafe;
			}
			return true;
		}

		public int SilverCost()
		{
			return _silverCost;
		}

		public LocalisedString GetUnlockName()
		{
			return LocalisedName;
		}

		public LocalisedString GetUnlockMessage()
		{
			return UnlockedMessage;
		}

		public Sprite GetUnlockIcon()
		{
			return _icon;
		}

		public ESandboxCheckType GetSandboxCheckType()
		{
			return ESandboxCheckType.Rooms;
		}

		public bool AllowNeedsSatisfaction()
		{
			if (!IsHospitalOrBay && _type != Type.StaffRoom)
			{
				return _type == Type.Toilets;
			}
			return true;
		}

		public ExternalBehavior GetSatisfactionOverride(CharacterAttributes.Type attributeType, RoomItem item)
		{
			if (SatisfactionBehaviourOverrides != null)
			{
				SatisfactionBehaviourOverride[] satisfactionBehaviourOverrides = SatisfactionBehaviourOverrides;
				for (int i = 0; i < satisfactionBehaviourOverrides.Length; i++)
				{
					SatisfactionBehaviourOverride satisfactionBehaviourOverride = satisfactionBehaviourOverrides[i];
					if (satisfactionBehaviourOverride.Attribute != attributeType)
					{
						continue;
					}
					if (item != null && satisfactionBehaviourOverride.SpecificItems != null)
					{
						bool flag = false;
						SharedInstance<RoomItemDefinition>[] specificItems = satisfactionBehaviourOverride.SpecificItems;
						for (int j = 0; j < specificItems.Length; j++)
						{
							if (specificItems[j].Instance == item.Definition)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							return null;
						}
					}
					return satisfactionBehaviourOverride.Behavior;
				}
			}
			return null;
		}

		public bool EvictUsersWhenUnstaffed()
		{
			if (_type != Type.Cafe && _type != Type.Ward)
			{
				return _type != Type.FractureWard;
			}
			return false;
		}

		public bool WaitForRoomToBecomeValid()
		{
			if (_type != Type.Toilets)
			{
				return _type != Type.Cafe;
			}
			return false;
		}

		public bool CanStaffAlwaysLeave()
		{
			if (_type != Type.Ward)
			{
				return _type == Type.FractureWard;
			}
			return true;
		}

		public List<StaffRequired> GetRequiredStaff()
		{
			List<StaffRequired> list = new List<StaffRequired>();
			StaffRequired[] requiresStaff = _requiresStaff;
			foreach (StaffRequired item in requiresStaff)
			{
				list.Add(item);
			}
			RequiredItem[] requiredItems = GetRequiredItems();
			for (int i = 0; i < requiredItems.Length; i++)
			{
				SharedInstance<RoomItemDefinition>[] items = requiredItems[i].Items;
				foreach (SharedInstance<RoomItemDefinition> sharedInstance in items)
				{
					list.AddRange(sharedInstance.Instance.GetRequiredStaff(includeRoomModifier: true));
				}
			}
			return list;
		}

		public GameObject GetFloorTile(WorldState worldState)
		{
			if (!UseHospitalFloorTile)
			{
				return _roomFloorTile;
			}
			return worldState.HospitalPlots[0].GetRoomDefinition()._roomFloorTile;
		}
	}
}
