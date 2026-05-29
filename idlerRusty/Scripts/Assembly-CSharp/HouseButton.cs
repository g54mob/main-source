using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HouseButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public House house;

	[SerializeField]
	private Image logoImage;

	[SerializeField]
	private TMP_Text sparePartsCostText;

	[SerializeField]
	private TMP_Text biofuelCostText;

	[SerializeField]
	private GameObject builtText;

	private bool isBuilt;

	private int sparePartsCost;

	private int biofuelCost;

	private void Start()
	{
		logoImage.sprite = house.getLogoSprite();
		sparePartsCost = house.spareParts;
		biofuelCost = house.biofuel;
		if (SaveData.ins.checkIfCrossover(out var crossover) && crossover == CrossoverFarmType.Balatro)
		{
			if (house.houseType == HouseType.HaikuHouse)
			{
				sparePartsCost *= 2;
			}
			else
			{
				sparePartsCost *= 3;
			}
		}
		sparePartsCostText.text = "<sprite index=0>" + sparePartsCost;
		biofuelCostText.text = "<sprite index=1>" + biofuelCost;
	}

	public void SetToBuilt()
	{
		isBuilt = true;
		builtText.SetActive(value: true);
		sparePartsCostText.gameObject.SetActive(value: false);
		biofuelCostText.gameObject.SetActive(value: false);
	}

	public void SelectHouse()
	{
		TooltipSystem.HideIcontip();
		TooltipSystem.HideSigntip();
		if (isBuilt)
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
		}
		else if (!doesPlayerHaveResources())
		{
			PlayNegativeFeedback();
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
		}
		else
		{
			GameManager.ins.houseSelected = house;
			GameManager.ins.state = GameManager.State.CanBuildHouse;
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		}
	}

	private void PlayNegativeFeedback()
	{
		if (Inventory.ins.spareParts < sparePartsCost)
		{
			Inventory.ins.NotEnoughSpareparts();
		}
		if (Inventory.ins.biofuel < biofuelCost)
		{
			Inventory.ins.NotEnoughBiofuel();
		}
	}

	private bool doesPlayerHaveResources()
	{
		if (Inventory.ins.spareParts < sparePartsCost)
		{
			return false;
		}
		if (Inventory.ins.biofuel < biofuelCost)
		{
			return false;
		}
		return true;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		BuildInfoPanel.ins.SetInfo(house);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		BuildInfoPanel.ins.SetBlank();
	}
}
