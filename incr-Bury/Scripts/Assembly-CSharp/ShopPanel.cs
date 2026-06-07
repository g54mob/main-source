using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
	public ShopPanelIdentity shopIdentity;

	public TMP_Text itemNameText;

	public TMP_Text nextLevelInfo;

	public Button buyButton;

	[Header("Level Fill Bar")]
	public GameObject currentLevel_Parent;

	public Image currentLevel_FillBar;

	[Header("Placement")]
	public GameObject placement_Parent;

	public TMP_Text placementText_NumberPlacedvsInventory;

	public Button placement_Button;

	[Header("Child Upgrades")]
	public GameObject[] childUpgrades;

	private void OnEnable()
	{
		GameObject[] array = childUpgrades;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		ShopPanelHelper.Singleton.UpdateStorePanelInfo(this);
	}
}
