using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildItem : MonoBehaviour
{
	public CoolButton Btn;

	public Image ImgIcon;

	public Localize LocCost;

	public TextMeshProUGUI TxtCost;

	public GameObject WrapperNew;

	public BuildingInfo TgtInfo;

	public bool IsLocked;

	public bool CanAfford;

	private void Awake()
	{
	}

	public void Init(BuildingInfo inf)
	{
	}

	public void InitLocked(BuildingInfo inf)
	{
	}

	private void InitInternal()
	{
	}

	private void OnClicked()
	{
	}
}
