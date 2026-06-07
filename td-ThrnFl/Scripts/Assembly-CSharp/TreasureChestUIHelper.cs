using TMPro;
using UnityEngine;

public class TreasureChestUIHelper : MonoBehaviour
{
	public static TreasureChestUIHelper instance;

	public bool overrideActiveState = true;

	public Transform scaleTarget;

	public TextMeshProUGUI balanceNumber;

	public GameObject toggleParent;

	private DayNightCycle dnc;

	private LocalGamestate lgs;

	private void Awake()
	{
		instance = this;
	}

	private void Update()
	{
		if (dnc == null)
		{
			dnc = DayNightCycle.Instance;
		}
		if (lgs == null)
		{
			lgs = LocalGamestate.Instance;
		}
		if (dnc == null || lgs == null)
		{
			toggleParent.SetActive(value: false);
			overrideActiveState = true;
		}
		else if (dnc.CurrentTimestate == DayNightCycle.Timestate.Day && lgs.CurrentState == LocalGamestate.State.InMatch)
		{
			toggleParent.SetActive(overrideActiveState);
		}
		else
		{
			toggleParent.SetActive(value: false);
			overrideActiveState = true;
		}
	}
}
