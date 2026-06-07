using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModShopItem : MonoBehaviour
{
	[SerializeField]
	private Image itemIcon;

	[SerializeField]
	private TextMeshProUGUI txtName;

	[SerializeField]
	private TextMeshProUGUI txtPrice;

	private int modID;

	private ModConfig config;

	public void Initialize(int modID, ModConfig config, Sprite icon)
	{
	}

	public void ButtonBuyItem()
	{
	}
}
