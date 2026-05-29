using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewSeedCard : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerClickHandler, IDragHandler
{
	public CropType cropType;

	public TMP_Text cropName;

	public Image cropLogo;

	public Image seedLogo;

	public TMP_Text cropRarity;

	private RectTransform rectTrans;

	public bool collected;

	private void Start()
	{
		rectTrans = GetComponent<RectTransform>();
		rectTrans.localScale = new Vector3(0f, 0f, 0f);
		rectTrans.DOScale(1f, 0.3f).SetEase(Ease.OutElastic, 0.05f);
	}

	public void SetCropType(CropType type)
	{
		cropType = type;
		cropRarity.text = "[Radioactive]";
		seedLogo.sprite = GameManager.ins.getCropSeedSprite(cropType);
		cropLogo.sprite = GameManager.ins.getCropSprite(cropType);
		if (GameManager.ins.isCropUnlocked(cropType))
		{
			cropName.text = GameManager.ins.getCropName(cropType);
		}
		else if (!GameManager.ins.isCropUnlocked(cropType))
		{
			cropName.text = "NEW!";
			cropLogo.color = GameManager.ins.lockedC;
		}
	}

	public void AddSeedToInventory(bool instant)
	{
		TooltipSystem.HideIcontip();
		if (!collected)
		{
			collected = true;
			UpdateCropCollectedStatus();
			Inventory.ins.AddToSeedInventory(cropType, 1);
			Inventory.ins.seedsButtonRect.DOComplete();
			Inventory.ins.seedsButtonRect.DOPunchScale(new Vector3(1f, 1f, 0f) * 0.2f, 0.2f);
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
			if (instant)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			rectTrans.DOKill();
			rectTrans.DOScale(0f, 0.2f).SetEase(Ease.Linear);
			rectTrans.DOLocalRotate(new Vector3(0f, 0f, 180f), 0.2f);
			Object.Destroy(base.gameObject, 0.2f);
		}
	}

	private void UpdateCropCollectedStatus()
	{
		GameManager.ins.SetCropUnlocked(cropType, state: true);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		AddSeedToInventory(instant: false);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (Input.GetMouseButton(0))
		{
			AddSeedToInventory(instant: false);
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		AddSeedToInventory(instant: false);
	}
}
