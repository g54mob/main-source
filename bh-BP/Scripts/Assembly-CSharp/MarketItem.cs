using TMPro;
using UnityEngine;

public class MarketItem : MonoBehaviour
{
	public CoolButton Btn;

	public TextMeshProUGUI TxtResource;

	public TextMeshProUGUI TxtGold;

	public bool IsBuy;

	public ResourceType TgtResource;

	private void Awake()
	{
	}

	public void Init(bool isBuy, ResourceType rt, int quantity)
	{
	}

	private void OnClicked()
	{
	}
}
