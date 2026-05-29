using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CropSign : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private Collider2D coll;

	[Header("Sign")]
	[SerializeField]
	private GameObject signObj;

	[SerializeField]
	private SpriteRenderer cropSpriteRenderer;

	[SerializeField]
	private GameObject highlight;

	[SerializeField]
	private CropSO currentCropSO;

	private void Start()
	{
		coll = GetComponent<Collider2D>();
		if (currentCropSO == null)
		{
			RemoveSign(playSound: false);
		}
	}

	private void Update()
	{
		if (currentCropSO == null && GameManager.ins.state == GameManager.State.CanPlaceSign)
		{
			highlight.SetActive(value: true);
			if (!coll.enabled)
			{
				coll.enabled = true;
			}
		}
		else if (currentCropSO != null && GameManager.ins.state == GameManager.State.CanRemoveSign)
		{
			highlight.SetActive(value: true);
			if (!coll.enabled)
			{
				coll.enabled = true;
			}
		}
		else
		{
			highlight.SetActive(value: false);
			if (coll.enabled)
			{
				coll.enabled = false;
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (GameManager.ins.state == GameManager.State.CanPlaceSign && !currentCropSO)
		{
			PlaceCropSign(GameManager.ins.cropSignSelected, playSound: true, checkMoney: true);
		}
		if (GameManager.ins.state == GameManager.State.CanRemoveSign && (bool)currentCropSO)
		{
			RemoveSign(playSound: true);
		}
	}

	public void PlaceCropSign(CropSO crop, bool playSound, bool checkMoney)
	{
		if (crop == null)
		{
			return;
		}
		if (checkMoney)
		{
			if (Inventory.ins.spareParts < 10)
			{
				SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
				GameManager.ins.SetStateToIdle();
				return;
			}
			Inventory.ins.AddSpareParts(-10);
			GameManager.ins.SpawnSparePartsPopUp(signObj.transform.position + Vector3.up, -10);
		}
		currentCropSO = crop;
		cropSpriteRenderer.sprite = crop.cropSprite;
		signObj.SetActive(value: true);
		signObj.transform.localScale = new Vector3(1f, 0f);
		signObj.transform.DOScaleY(1f, 0.25f).SetEase(Ease.OutBack);
		if (playSound)
		{
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		}
	}

	public CropType getCropType()
	{
		if (currentCropSO != null)
		{
			return currentCropSO.cropType;
		}
		return CropType.None;
	}

	public CropSO getCropSO()
	{
		if (currentCropSO == null)
		{
			return null;
		}
		return currentCropSO;
	}

	private void RemoveSign(bool playSound)
	{
		currentCropSO = null;
		signObj.SetActive(value: false);
		if (playSound)
		{
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		}
	}
}
