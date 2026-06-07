using I2.Loc;
using TMPro;
using UnityEngine;

public class LeaderboardUIItem : MonoBehaviour
{
	public CoolButton Btn;

	public TextMeshProUGUI TxtNum;

	public TextMeshProUGUI TxtName;

	public TextMeshProUGUI TxtScore;

	public Localize LocScore;

	public LocalizationParamsManager ParamsScore;

	public LBEntry Entry;

	private void Awake()
	{
	}

	public void Init(LBType t, LBEntry entry)
	{
	}

	public void Init(LBParams prms, LBEntry entry)
	{
	}

	private void OnHover()
	{
	}
}
