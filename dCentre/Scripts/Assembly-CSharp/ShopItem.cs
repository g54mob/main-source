using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
	[SerializeField]
	private GameObject unlockButton;

	private ButtonExtended buttonExtended;

	[SerializeField]
	private int xpToUnlock;

	[SerializeField]
	private int price;

	[SerializeField]
	private int itemID;

	[SerializeField]
	private string itemDisplayName;

	[SerializeField]
	private PlayerManager.ObjectInHand itemType;

	[SerializeField]
	private TextMeshProUGUI txtName;

	[SerializeField]
	private TextMeshProUGUI txtPrice;

	[SerializeField]
	private TextMeshProUGUI txtXpToUnlock;

	public string guid;

	public bool isUnlocked;

	private void Awake()
	{
	}

	public void ButtonBuyItem()
	{
	}

	private void TryUnlock()
	{
	}

	private void BuyItem()
	{
	}

	public void UnlockButton()
	{
	}

	private void UpdateVisualState()
	{
	}

	private void OnLoad()
	{
	}

	private void OnDestroy()
	{
	}
}
