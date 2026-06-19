using OUSystems.Basics.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractUnlockShopUIItem : MonoBehaviour
{
	[SerializeField]
	private Image _iconImage;

	[SerializeField]
	private TextMeshProUGUI _title;

	protected UnlockShopCanvasUI _parent;

	protected ShopItem _shopitem;

	[SerializeField]
	private ClickListener _clickListener;

	public virtual void Initiate(UnlockShopCanvasUI parent, ShopItem shopItem)
	{
	}

	protected virtual void OnDestroy()
	{
	}

	protected abstract void OnClick();
}
