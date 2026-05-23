using UnityEngine;

public class MinimapUIHelper : MonoBehaviour
{
	public Transform scaleTarget;

	public GameObject toggleParent;

	private DayNightCycle dnc;

	private LocalGamestate lgs;

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
		}
		else if (dnc.CurrentTimestate == DayNightCycle.Timestate.Night && lgs.CurrentState == LocalGamestate.State.InMatch)
		{
			toggleParent.SetActive(value: true);
		}
		else
		{
			toggleParent.SetActive(value: false);
		}
	}
}
