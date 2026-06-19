using OUSystems.Basics.DataStructures;
using OUSystems.Basics.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemStackUI : MonoBehaviour
{
	[SerializeField]
	protected Image _image;

	[SerializeField]
	protected TextMeshProUGUI _quantityText;

	public bool HideSingles;

	[SerializeField]
	private HoverListener _hoverListener;

	[SerializeField]
	private ItemTooltipTrigger _tooltipTrigger;

	[SerializeField]
	public ItemStack Stack { get; private set; }

	public virtual void Initiate(ItemStack stack)
	{
	}

	protected virtual void OnDestroy()
	{
	}

	protected virtual void OnUpdateCount(ValueUpdateData<int> update)
	{
	}

	public void OnHover()
	{
	}

	public void OnHoverEnd()
	{
	}

	public virtual void Clear()
	{
	}
}
