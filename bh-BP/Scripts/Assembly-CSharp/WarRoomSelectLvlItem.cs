using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarRoomSelectLvlItem : MonoBehaviour
{
	public CoolButton Btn;

	public Image ImgIcon;

	public TextMeshProUGUI TxtRewards;

	public LocalizationParamsManager ParamsLen;

	public LevelInfo TgtLvl;

	private LevelData _tgtLvl;

	private void Awake()
	{
	}

	public void Init(CharMetaInst charInst, LevelData lvlData)
	{
	}

	private void OnClicked()
	{
	}
}
