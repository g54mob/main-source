using DV.Common;
using DV.Localization;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryItemSpec : MonoBehaviour, IInventoryItemSpec
{
	public const string ITEM_TEXT_NOT_SET = "<NOT SET>";

	[FormerlySerializedAs("itemName")]
	public string localizationKeyName = "<NOT SET>";

	[FormerlySerializedAs("itemDescription")]
	public string localizationKeyDescription = "<NOT SET>";

	public Vector3 iconRenderPositionOffset = Vector3.zero;

	public Vector3 iconRenderAngleOffset = Vector3.zero;

	[SerializeField]
	private bool immuneToDumpster;

	[SerializeField]
	private bool isEssential;

	[SerializeField]
	private string itemPrefabName;

	[SerializeField]
	private Sprite itemIconSprite;

	[SerializeField]
	private Sprite itemIconSpriteStandard;

	[SerializeField]
	private Sprite itemIconSpriteDropped;

	[SerializeField]
	private GameObject previewPrefab;

	[SerializeField]
	private Bounds previewBounds;

	[SerializeField]
	private Vector3 previewRotation = Vector3.zero;

	public bool BelongsToPlayer { get; set; }

	public bool ImmuneToDumpster
	{
		get
		{
			if (!immuneToDumpster)
			{
				return IsEssential;
			}
			return true;
		}
		set
		{
			immuneToDumpster = value;
		}
	}

	public bool IsEssential
	{
		get
		{
			return isEssential;
		}
		set
		{
			isEssential = value;
		}
	}

	public string ItemPrefabName => itemPrefabName;

	public GameObject PreviewPrefab
	{
		get
		{
			return previewPrefab;
		}
		set
		{
			previewPrefab = value;
		}
	}

	public Bounds PreviewBounds
	{
		get
		{
			return previewBounds;
		}
		set
		{
			previewBounds = value;
		}
	}

	public Vector3 PreviewRotation => previewRotation;

	public Sprite ItemIconSpriteSimple
	{
		get
		{
			return itemIconSprite;
		}
		set
		{
			itemIconSprite = value;
		}
	}

	public Sprite ItemIconSprite
	{
		get
		{
			return itemIconSpriteStandard;
		}
		set
		{
			itemIconSpriteStandard = value;
		}
	}

	public Sprite ItemIconSpriteDropped
	{
		get
		{
			return itemIconSpriteDropped;
		}
		set
		{
			itemIconSpriteDropped = value;
		}
	}

	public string NameOverride { get; set; }

	public string LocalizedName
	{
		get
		{
			IInventoryItemLocalizer component = GetComponent<IInventoryItemLocalizer>();
			if (string.IsNullOrEmpty(NameOverride))
			{
				if (component == null)
				{
					return LocalizationAPI.L(localizationKeyName);
				}
				return LocalizationAPI.L(localizationKeyName, component.GetNameParam());
			}
			return NameOverride;
		}
	}

	public string LocalizationKey => localizationKeyName;

	public string LocalizedDescription
	{
		get
		{
			string text = GetComponent<IInventoryItemLocalizer>()?.GetCustomDescription();
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
			return LocalizationAPI.L(localizationKeyDescription);
		}
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}
}
