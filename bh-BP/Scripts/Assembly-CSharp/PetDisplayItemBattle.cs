using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetDisplayItemBattle : MonoBehaviour
{
	public Image ImgIcon;

	public CoolButton BtnIcon;

	public TextMeshProUGUI TxtName;

	public LevelUpCurEquipItem[] UpgradeItems;

	private PetBattleInst _petInst;

	private void Awake()
	{
	}

	public void Init(PetBattleInst inst)
	{
	}

	public PetBattleInst GetPet()
	{
		return null;
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}
}
