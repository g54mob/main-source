using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FreeUpgradeItem : MonoBehaviour
{
	public Vector2 EntryDir;

	public Vector2 DefaultPos;

	public SlidingPanel Panel;

	public RectTransform Xfm;

	public Image ImgIcon;

	public Image ImgPetIcon;

	public ImageAnimator ImgAnim;

	public Localize LocTxt;

	public TextMeshProUGUI Txt;

	public UpgradeInfo TgtInf;

	public FuserOptionType Type;

	public int Idx;

	public int Idx2;

	public bool IsSelected;

	public CoolButton Btn;

	private void Awake()
	{
	}

	public void InitFreeUpgrade(UpgradeChoice choice)
	{
	}

	public void InitEvolutionComponent(UpgradeInfo inf)
	{
	}

	public void InitEvolution(UpgradeInfo inf)
	{
	}

	public void InitMoney(int amt)
	{
	}

	public void InitCombo(int idx1, int idx2)
	{
	}

	public void OnHover()
	{
	}

	private void OnClicked()
	{
	}

	public void OnHoverExit()
	{
	}
}
