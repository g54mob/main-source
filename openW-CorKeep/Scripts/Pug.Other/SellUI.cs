using UnityEngine;

public class SellUI : MonoBehaviour
{
	public SellInventoryUI sellInventory;

	public GameObject root;

	public PugText sellAmountText;

	public bool isShowing => root.activeInHierarchy;

	private void Awake()
	{
		sellInventory.Init();
		root.SetActive(value: false);
	}

	private void Update()
	{
		PlayerController player = Manager.main.player;
		if (isShowing && player != null)
		{
			string text = player.sellSlotsHandler.sellSlotsInventoryHandler.GetCoinValueAll(player, buy: false).ToString();
			if (text != sellAmountText.displayedTextString)
			{
				sellAmountText.Render(text);
			}
		}
	}

	private void LateUpdate()
	{
		root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
	}

	public void ShowContainerUI()
	{
		sellInventory.ShowContainerUI();
		root.SetActive(value: true);
	}

	public void HideContainerUI()
	{
		sellInventory.HideContainerUI();
		root.SetActive(value: false);
	}

	public void Sell()
	{
		Manager.main.player.sellSlotsHandler.sellSlotsInventoryHandler.SellAll(Manager.main.player, Manager.main.player.RenderPosition);
	}
}
