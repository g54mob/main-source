using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
	[SerializeField]
	private Image itemIcon;

	[SerializeField]
	private GameObject unlockButton;

	private ButtonExtended buttonExtended;

	[SerializeField]
	private ShopItemSO shopItemSO;

	[SerializeField]
	private TextMeshProUGUI txtName;

	[SerializeField]
	private TextMeshProUGUI txtPrice;

	[SerializeField]
	private TextMeshProUGUI txtXpToUnlock;

	public string guid;

	public bool isUnlocked;

	private string itemDisplayName;

	private void Awake()
	{
	}

	private void Start()
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
