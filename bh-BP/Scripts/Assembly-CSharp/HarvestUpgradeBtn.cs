using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class HarvestUpgradeBtn : MonoBehaviour
{
	public CoolButton Btn;

	public Image ImgIcon;

	public Localize LocName;

	public Localize LocDesc;

	public LocalizationParamsManager ParamsDesc;

	private HarvestUpgradeType _tgtType;

	private void Awake()
	{
	}

	public void Init(CharMetaInst cInst, HarvestUpgradeType ht)
	{
	}

	private void OnClicked()
	{
	}
}
