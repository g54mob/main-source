using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class DecorButton : MonoBehaviour
{
	public Decoration decorSO;

	[Header("References")]
	[SerializeField]
	private Image decorImage;

	private void Start()
	{
		decorImage.sprite = decorSO.decorSprite;
	}

	public void SelectDecoration()
	{
		TooltipSystem.HideIcontip();
		TooltipSystem.HideSigntip();
		if (!DoesPlayerHaveResources())
		{
			PlayNegativeFeedback();
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			GameManager.ins.SetStateToIdle();
		}
		else
		{
			GameManager.ins.decorSelected = decorSO;
			GameManager.ins.state = GameManager.State.CanDecorate;
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		}
	}

	private void PlayNegativeFeedback()
	{
		if (Inventory.ins.spareParts < decorSO.spareParts)
		{
			Inventory.ins.NotEnoughSpareparts();
		}
		if (Inventory.ins.biofuel < decorSO.biofuel)
		{
			Inventory.ins.NotEnoughBiofuel();
		}
	}

	private bool DoesPlayerHaveResources()
	{
		if (Inventory.ins.spareParts < decorSO.spareParts)
		{
			return false;
		}
		if (Inventory.ins.biofuel < decorSO.biofuel)
		{
			return false;
		}
		return true;
	}
}
