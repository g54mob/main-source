using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoPanel : MonoBehaviour
{
	public Localize LocName;

	public Image ImgIcon;

	public Localize LocDesc;

	public LocalizationParamsManager ParamsDesc;

	public TextMeshProUGUI TxtCost;

	public bool ColorizeCost;

	public bool IsBuild;

	private BuildingInfo _tgtBuilding;

	public void SetBuilding(BuildingInfo inf)
	{
	}
}
