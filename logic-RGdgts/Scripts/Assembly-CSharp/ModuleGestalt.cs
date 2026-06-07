using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class ModuleGestalt : SerializedScriptableObject
{
	public struct Property
	{
		public enum Type
		{
			Software = 0,
			Hardware = 1
		}

		public string name;

		public Type type;

		public bool configurable;

		public bool accessible;

		public bool mapAsInteger;

		public string table;

		public bool readOnly;

		public int position;

		public bool notSerialized;

		public bool persistent;

		public bool allowsAnyData;

		public Data defaultData;

		public bool useLimits;

		public bool dynamicLimits;

		public FloatRange limits;

		public bool customizationProperty;

		public bool alwaysTrigger;

		public int driverCommand;

		public int documentationOrder;

		public bool NameIsInteger => false;

		public bool isHardware => false;

		public bool accessibleFromLUA => false;

		public bool IsReadOnly => false;

		public bool IsCustomizationProperty => false;

		public bool IsSerialized()
		{
			return false;
		}

		private void SetValidData()
		{
		}

		private bool ValidateSelectionData(Data value)
		{
			return false;
		}

		private bool ValidateCustomizationProperty(Data value)
		{
			return false;
		}

		private bool ShouldMapCommand()
		{
			return false;
		}

		private bool ShouldShowUseLimits()
		{
			return false;
		}

		private bool ShouldShowDynamicLimits()
		{
			return false;
		}

		private bool ShouldShowLimits()
		{
			return false;
		}

		private IList<ValueDropdownItem<int>> CommandList()
		{
			return null;
		}

		public string GetTypeString()
		{
			return null;
		}

		public DocumentationType GetDocumentationType()
		{
			return default(DocumentationType);
		}
	}

	public enum ModuleCategory
	{
		None = 0,
		Input = 1,
		Output = 2,
		Misc = 3
	}

	public enum ModuleGroup
	{
		None = 0,
		Leds = 1,
		Buttons = 2,
		Knobs = 3,
		Displays = 4,
		Switches = 5,
		Gauges = 6,
		Sticks = 7,
		AudioChips = 8,
		CPUs = 9,
		Sliders = 10,
		Drives = 11,
		Speakers = 12,
		Connectors = 13,
		Video = 14,
		Decoration = 15,
		InputChips = 16,
		Memories = 17,
		Security = 18,
		ROM = 19,
		Comunication = 20,
		PowerButton = 21
	}

	public struct Variation
	{
		public string name;

		public GameObject modulePrefab;

		public ModuleGestaltVariationEnum id;

		[HideInInspector]
		public ModuleGestaltEnum moduleGestaltId;

		public ModuleGestalt moduleGestalt => null;

		private void SetInvalid()
		{
		}
	}

	public Type module;

	public string displayName;

	public bool disableColorPersonalization;

	public bool alwaysPlaymodeInteraction;

	public bool isSpecialFixedModule;

	public bool unique;

	public ModuleCategory moduleCategory;

	public ModuleGroup moduleGroup;

	public HashSet<PcbSide> pcbSides;

	public Dictionary<int, Property> properties;

	public Variation[] variations;

	public ModuleGestaltEnum id;

	public static ModuleGestalt instance;

	private void SetStaticInstance()
	{
	}

	private bool ValidateDisplayName(string value)
	{
		return false;
	}

	private void SetAsInvalid()
	{
	}

	public void SetId(ModuleGestaltEnum id)
	{
	}

	private IList<ValueDropdownItem<Type>> ModuleList()
	{
		return null;
	}

	public Dictionary<int, Property> GetConfigurableProperties()
	{
		return null;
	}

	public Variation? GetVariation(ModuleGestaltVariationEnum variationEnum)
	{
		return null;
	}
}
