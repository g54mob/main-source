using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Utility Properties")]
public class PlaceableUtilityProperties : ScriptableObject, IPlaceable, IIconProvider, ITooltipProvider
{
	[SerializeField]
	private BuildableCategory _category;

	[SerializeField]
	private LocalizedString _name = null;

	[SerializeField]
	private LocalizedString _description = null;

	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private CursorProperties _cursorProperties;

	public BuildableCategory Category => _category;

	public string Name => _name;

	public Sprite Icon => _icon;

	public bool ShowToggle => true;

	public bool IsToggleEnabled => true;

	public bool IsCategoryEnabled => false;

	public bool RequiresMooringPoint => false;

	public void ActivateCursor(CursorManager.CursorEvent deactivatedCallback)
	{
		GameManager.CursorManager.Activate(_cursorProperties, deactivatedCallback);
	}

	public string GetDescription()
	{
		return _description;
	}

	public bool ReturnCanBePlaced(Community community, bool checkResources = true)
	{
		return true;
	}

	public Sprite GetIcon()
	{
		return _icon;
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return string.Empty;
	}

	public void ShowTooltip(GameObject trigger = null, bool delayed = true)
	{
		GameManager.UIManager.StartBuildableTooltipTimer(this, trigger.transform.position, delayed);
	}

	public void ShowTooltip(Vector3 position, bool delayed = true)
	{
		GameManager.UIManager.StartBuildableTooltipTimer(this, position, delayed);
	}

	public void HideTooltip()
	{
		GameManager.UIManager.ResetBuildableTooltipTimer(this);
	}

	public string GetName()
	{
		return Name;
	}
}
