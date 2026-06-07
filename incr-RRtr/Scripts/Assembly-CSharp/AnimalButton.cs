using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public AnimalSO animalSO;

	public BuildingSO buildInfoPanelSO;

	private int fossilCost;

	private int biofuelCost;

	private bool isHoveringOver;

	private bool infoPanelIsOpen;

	[Header("References")]
	[SerializeField]
	private Image animalLogo;

	[SerializeField]
	private TMP_Text fossilCostText;

	[SerializeField]
	private TMP_Text biofuelCostText;

	private void Start()
	{
		UpdateLogoImage();
		UpdateCostTexts();
	}

	private void UpdateLogoImage()
	{
		if ((bool)animalLogo)
		{
			animalLogo.sprite = animalSO.animalLogo;
		}
	}

	public void UpdateCostTexts()
	{
		int num = 0;
		if (animalSO.animalName == "Cow")
		{
			num = GameManager.ins.numberOfCows;
		}
		if (animalSO.animalName == "Pig")
		{
			num = GameManager.ins.numberOfPigs;
		}
		fossilCost = Mathf.CeilToInt((float)animalSO.fossilCost + Mathf.Pow((float)(animalSO.fossilStartIncrease + num) + 1f, animalSO.fossilCoef));
		biofuelCost = Mathf.CeilToInt((float)animalSO.biofuelCost + Mathf.Pow((float)(animalSO.biofuelStartIncrease + num) + 1f, animalSO.biofuelCoef));
		if (fossilCost > 50)
		{
			fossilCost = Mathf.CeilToInt((float)fossilCost * 0.1f) * 10;
		}
		if (biofuelCost > 500)
		{
			biofuelCost = Mathf.CeilToInt((float)biofuelCost * 0.1f) * 10;
		}
		if (biofuelCost > 1000)
		{
			biofuelCost = Mathf.CeilToInt((float)biofuelCost * 0.01f) * 100;
		}
		if ((bool)fossilCostText)
		{
			fossilCostText.text = "<sprite index=11>" + fossilCost;
		}
		if ((bool)biofuelCostText)
		{
			biofuelCostText.text = "<sprite index=1>" + biofuelCost;
		}
	}

	public void SelectAnimal()
	{
		TooltipSystem.HideIcontip();
		TooltipSystem.HideSigntip();
		if (!checkIfPlayerHasResources(fossilCost, biofuelCost))
		{
			PlayNegativeFeedback();
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		GameManager.ins.state = GameManager.State.CanPlaceAnimal;
		GameManager.ins.animalSelected = animalSO;
		GameManager.ins.animalFSCost = fossilCost;
		GameManager.ins.animalBFCost = biofuelCost;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	private void PlayNegativeFeedback()
	{
		if (Inventory.ins.biofuel < biofuelCost)
		{
			Inventory.ins.NotEnoughBiofuel();
		}
		if (Inventory.ins.fossils < fossilCost)
		{
			Inventory.ins.NotEnoughFossils();
		}
	}

	private bool checkIfPlayerHasResources(int fossils, int biofuel)
	{
		if (Inventory.ins.fossils < fossils)
		{
			return false;
		}
		if (Inventory.ins.biofuel < biofuel)
		{
			return false;
		}
		return true;
	}

	public int getFossilCost()
	{
		return fossilCost;
	}

	public int getBiofuelCost()
	{
		return biofuelCost;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		isHoveringOver = true;
	}

	private void Update()
	{
		if (isHoveringOver && !infoPanelIsOpen)
		{
			infoPanelIsOpen = true;
			BuildInfoPanel.ins.SetInfo(buildInfoPanelSO);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHoveringOver = false;
		infoPanelIsOpen = false;
		BuildInfoPanel.ins.SetBlank();
	}
}
