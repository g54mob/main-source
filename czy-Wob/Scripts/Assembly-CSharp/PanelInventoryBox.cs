using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelInventoryBox : MonoBehaviour
{
	public Image iconHolder;

	public InchwormBounce iconBouncer;

	public CoreButtonUnityGUI boxButton;

	public GameObject numberHolder;

	public TextMeshProUGUI numberText;

	public GameObject newObjectIndicator;

	private Tooltip tooltipRef;

	private bool needsBounce;

	private int associatedIndex;

	private InventoryItem associatedItem;

	private CursorUpdateArea updateAreaRef;

	private PanelInventoryBoxes boxesRef;

	private void Update()
	{
		if (needsBounce)
		{
			needsBounce = false;
			iconBouncer.RequestBounce();
		}
	}

	public void RequestBounce(float delay, float shrinkAmount, bool startInvisible = false)
	{
		needsBounce = true;
		iconBouncer.bounceStartDelay = delay;
		iconBouncer.shrinkAmount = shrinkAmount;
		iconBouncer.startInvisible = startInvisible;
	}

	public void SetBoxesRef(PanelInventoryBoxes newRef, CursorUpdateArea areaRef)
	{
		boxesRef = newRef;
		updateAreaRef = areaRef;
	}

	public void SetAssociatedItem(InventoryItem newItem, int numHeld, int index, GameObject tooltip, bool newObject = false)
	{
		associatedIndex = index;
		associatedItem = newItem;
		iconHolder.sprite = newItem.icon;
		newObjectIndicator.SetActive(newObject);
		numberHolder.SetActive(numHeld > 1);
		numberText.text = numHeld.ToString();
		tooltipRef = tooltip.GetComponent<Tooltip>();
	}

	public InventoryItem GetAssociatedItem()
	{
		return associatedItem;
	}

	public void Deselect()
	{
	}

	public void OnHoverStart()
	{
		tooltipRef.SetItem(associatedItem);
		tooltipRef.gameObject.SetActive(value: true);
		updateAreaRef.ReportCursorOverContent();
	}

	public void OnHover()
	{
		tooltipRef.HoverBehavior();
		tooltipRef.gameObject.SetActive(value: true);
		updateAreaRef.ReportCursorOverContent();
	}

	public void OnHoverStop()
	{
		tooltipRef.gameObject.SetActive(value: false);
	}

	public void OnBoxSelected()
	{
		boxButton.Select();
		boxesRef.OnBoxSelected(associatedIndex, fromBox: true);
	}
}
