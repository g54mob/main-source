using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using I2.Loc;
using PajamaLlama.SurvivalGuide;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI.Extensions;

[CreateAssetMenu(menuName = "Flotsam/Items/ItemProperties")]
public class ItemProperties : PersistentProperties, ISurvivalGuideIdentifiable
{
	[Serializable]
	public struct ToggleSprites
	{
		public Sprite Off;

		public Sprite Disbaled;

		public Sprite Selected;
	}

	public class Event : UnityEvent<ItemProperties>
	{
	}

	public const int COUNT = 192;

	[ReadOnly]
	[SerializeField]
	private int _id = -1;

	[Header("Properties")]
	public ItemType ItemType;

	public FlotsamProperties FlotsamProperties;

	public Sprite InventorySprite;

	public ToggleSprites ToggleSprite;

	public bool ExcludeFromItemFilter;

	[Range(0f, 1f)]
	public float NutritionalValue;

	public ItemQuality Quality;

	[Header("General")]
	[SerializeField]
	[FormerlySerializedAs("LocalizedName")]
	private LocalizedString _localizedName = "";

	[SerializeField]
	[Tooltip("This should be used for development only! If no localization key is provided, this will be used instead.")]
	private string _fallbackName = "";

	[SerializeField]
	[FormerlySerializedAs("LocalizedDescription")]
	public LocalizedString _localizedDescription = "";

	[SerializeField]
	[Tooltip("This should be used for development only! If no localization key is provided, this will be used instead.")]
	private string _fallbackDescription = "";

	[Space]
	public int SlotSize = 1;

	public int StackLimit = 10;

	public StorageVisual StorageVisualPrefab;

	[EnumFlag(1)]
	public Item.Tags Tags;

	public float Weight = 1f;

	[Header("Pollution")]
	[FormerlySerializedAs("Pollution")]
	public int ConsumptionPollution;

	public float SalvagePollution;

	[Space]
	public bool IsSuperItem;

	[SerializeField]
	private SubItemPropertiesProviderBase _subItemProvider;

	[NonSerialized]
	private string _languageCode;

	[NonSerialized]
	private string _name;

	[NonSerialized]
	private string _nutritionalValue;

	public static List<ItemProperties> Identified { get; private set; } = new List<ItemProperties>(192);

	public override Types Type => Types.ItemProperties;

	public int Id => _id;

	public string LocalizedName => _localizedName.GetOrDefault(_fallbackName);

	public string LocalizedNameTerm => _localizedName.mTerm.GetOrDefault(_fallbackName);

	public string LocalizedDescription => _localizedDescription.GetOrDefault(_fallbackDescription);

	public string SurvivalGuideIdentifier => "item-" + base.name.ToLower();

	public bool IsQuestItem => (Tags & Item.Tags.Quest) == Item.Tags.Quest;

	public void ReturnNameAndNutritionalValue(out string name, out string nutritionalValue)
	{
		if (_languageCode == LocalizationManager.CurrentLanguageCode)
		{
			name = _name;
			nutritionalValue = _nutritionalValue;
			return;
		}
		string localizedName = LocalizedName;
		string[] separator = new string[3] { "\r\n", "\r", "\n" };
		string[] array = localizedName.Split(separator, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 2)
		{
			name = array[0];
			nutritionalValue = array[1];
		}
		else
		{
			name = localizedName;
			nutritionalValue = null;
		}
		_name = name;
		_nutritionalValue = nutritionalValue;
		_languageCode = LocalizationManager.CurrentLanguageCode;
	}

	public VisualPrefab ReturnVisualPrefab(out int index)
	{
		if (FlotsamProperties == null)
		{
			Debug.LogErrorFormat("ItemProperties.FlotsamProperties is null for '{0}'!", base.name);
		}
		return FlotsamProperties.ReturnRandomVisualPrefab(out index);
	}

	public bool TryReturnSubItemProperties(out ItemProperties subItemProperties, Item item = null)
	{
		if (IsSuperItem && (bool)_subItemProvider)
		{
			return _subItemProvider.TryReturnSubItemProperties(out subItemProperties, item);
		}
		subItemProperties = null;
		return false;
	}

	public void ReturnAllSubItemProperties(List<ItemProperties> itemPropertiesList)
	{
		if (IsSuperItem && (bool)_subItemProvider)
		{
			_subItemProvider.ReturnAllSubItemProperties(itemPropertiesList);
		}
		itemPropertiesList.AddUnique(this);
	}

	public string ReturnTooltip()
	{
		return ReturnTooltip(LocalizedName);
	}

	public string ReturnTooltip(LocalizedString localizedName)
	{
		string text = (((string)localizedName == null) ? localizedName.mTerm : localizedName.ToString());
		return string.Concat(string.Concat(string.Concat(string.Concat("<style=\"Tooltip Name\">" + text + "</style>", "<line-height=120%>\n"), ReturnCategory()), "</line-height>"), ReturnStats());
	}

	public string ReturnCategory()
	{
		string text = Regex.Replace(GameManager.Settings.ItemSettings.CategoryText, "%CATEGORY%", ItemType.Name.ToString(), RegexOptions.IgnoreCase);
		return "<i><b><color=#" + ColorUtility.ToHtmlStringRGBA(ItemType.LabelColor) + ">" + text + "</color></b></i>";
	}

	public string ReturnStats()
	{
		string text = string.Empty;
		if (Quality != null)
		{
			text = NextLine(text, Regex.Replace(GameManager.Settings.ItemSettings.QualityText, "%QUALITY%", Quality.Name.ToString(), RegexOptions.IgnoreCase));
		}
		if (Tags.HasFlag(Item.Tags.Food | Item.Tags.Drink) && ConsumptionPollution != 0)
		{
			text = NextLine(text, Regex.Replace(GameManager.Settings.ItemSettings.PollutionText, "%POLLUTION%", ConsumptionPollution.ToString(), RegexOptions.IgnoreCase));
		}
		return text;
	}

	private string NextLine(string current, string next)
	{
		if (!string.IsNullOrWhiteSpace(current))
		{
			return current + "/n" + next;
		}
		return next;
	}
}
