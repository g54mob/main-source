using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatsCropPanel : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private string cropNameKey = "";

	[SerializeField]
	private Image cropImage;

	[SerializeField]
	private TMP_Text amountText;

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (cropNameKey != "")
		{
			TooltipSystem.Show(LocalizationSystem.GetLocalizedValue(cropNameKey));
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TooltipSystem.Hide();
	}

	public void SetCropStatTo(CropSO cropSO, int amount)
	{
		cropNameKey = cropSO.cropName;
		cropImage.sprite = cropSO.cropSprite;
		if (amount > 999)
		{
			amount = 999;
		}
		amountText.text = amount.ToString();
		base.gameObject.SetActive(value: true);
	}

	public void DisableCropStat()
	{
		cropNameKey = "";
		base.gameObject.SetActive(value: false);
	}
}
