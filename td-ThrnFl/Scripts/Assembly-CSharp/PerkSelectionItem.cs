using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PerkSelectionItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private LevelSelectManager levelSelectManager;

	[SerializeField]
	private GameObject selectedMarker;

	private PerkSelectionGroup perkSelectionGroup;

	private Color colorBasic;

	private Image image;

	[SerializeField]
	private Color hoverColor;

	private bool mouseIsOver;

	private Equippable equippable;

	public Equippable Equippable => equippable;

	public bool Selected
	{
		get
		{
			return selectedMarker.activeInHierarchy;
		}
		set
		{
			selectedMarker.SetActive(value);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		mouseIsOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		mouseIsOver = false;
		if (levelSelectManager.ShowingTooltipFor == equippable)
		{
			levelSelectManager.ShowTooltip(null);
		}
	}

	private void Update()
	{
		image.color = (mouseIsOver ? hoverColor : colorBasic);
		if (mouseIsOver)
		{
			levelSelectManager.ShowTooltip(equippable);
		}
		if (Input.GetMouseButtonDown(0) && mouseIsOver && (bool)perkSelectionGroup)
		{
			perkSelectionGroup.SelectPerk(this);
		}
	}

	public void Initialize(Equippable _equippable)
	{
		image = GetComponent<Image>();
		colorBasic = image.color;
		perkSelectionGroup = GetComponentInParent<PerkSelectionGroup>();
		Debug.Log(perkSelectionGroup);
		levelSelectManager = LevelSelectManager.instance;
		image.sprite = _equippable.icon;
		equippable = _equippable;
		if (PerkManager.instance.CurrentlyEquipped.Contains(equippable) && (bool)perkSelectionGroup)
		{
			perkSelectionGroup.SelectPerk(this);
		}
	}
}
