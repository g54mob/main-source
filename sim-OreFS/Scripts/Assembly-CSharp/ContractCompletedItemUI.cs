using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContractCompletedItemUI : MonoBehaviour
{
	[Header("UI Elements")]
	[Tooltip("Malzeme ikonu")]
	[SerializeField]
	private Image materialIcon;

	[Tooltip("Malzeme ismi")]
	[SerializeField]
	private TextMeshProUGUI materialNameText;

	[Tooltip("Teslimat durumu (delivered/required)")]
	[SerializeField]
	private TextMeshProUGUI deliveryCountText;

	[Header("Colors")]
	[Tooltip("Tamamlandı rengi")]
	[SerializeField]
	private Color completeColor = new Color(0.2f, 0.8f, 0.2f);

	[Tooltip("Varsayılan renk")]
	[SerializeField]
	private Color defaultColor = Color.white;

	public void Initialize(string itemId, int deliveredCount, int requiredCount)
	{
		T_ItemSO t_ItemSO = null;
		if (ItemSOManager.Instance != null)
		{
			t_ItemSO = ItemSOManager.Instance.GetItemSOById(itemId);
		}
		if (materialIcon != null)
		{
			if (t_ItemSO != null && t_ItemSO.Icon != null)
			{
				materialIcon.sprite = t_ItemSO.Icon;
				materialIcon.gameObject.SetActive(value: true);
			}
			else
			{
				materialIcon.gameObject.SetActive(value: false);
			}
		}
		if (materialNameText != null)
		{
			if (t_ItemSO != null)
			{
				string translation = LocalizationManager.GetTranslation(t_ItemSO.Name);
				materialNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : t_ItemSO.Name);
			}
			else
			{
				materialNameText.text = itemId;
			}
		}
		bool flag = deliveredCount >= requiredCount;
		if (deliveryCountText != null)
		{
			deliveryCountText.text = $"({deliveredCount}/{requiredCount})";
			deliveryCountText.color = (flag ? completeColor : defaultColor);
		}
	}
}
