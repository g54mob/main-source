using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CropSignButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public CropSO cropSO;

	public bool isUnlocked;

	[Space]
	[SerializeField]
	private Image cropImage;

	public void UnlockCropSign()
	{
		isUnlocked = true;
		cropImage.sprite = cropSO.cropSprite;
		base.gameObject.SetActive(value: true);
	}

	public void ClickedOnCropSign()
	{
		TooltipSystem.HideIcontip();
		if (Inventory.ins.spareParts < 10)
		{
			Inventory.ins.NotEnoughSpareparts();
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		GameManager.ins.cropSignSelected = cropSO;
		GameManager.ins.state = GameManager.State.CanPlaceSign;
		TooltipSystem.ShowSigntip(cropSO.cropSprite);
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void ClickedOnDontSeedSign()
	{
		TooltipSystem.HideIcontip();
		GameManager.ins.cropSignSelected = GridSystem.ins.dontSeedCropSO;
		GameManager.ins.state = GameManager.State.CanPlaceSign;
		TooltipSystem.ShowSigntip(GridSystem.ins.dontSeedCropSO.cropSprite);
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if ((bool)cropSO)
		{
			CropInfoPanel.ins.SetInfo(cropSO);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CropInfoPanel.ins.SetBlank();
	}
}
