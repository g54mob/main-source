using UnityEngine;
using UnityEngine.UI;

public class SelectWarning : MonoBehaviour
{
	public GameObject Warning;

	public GUIToolTipper WarningTip;

	public Image ToggleBack;

	public void SetWarning(string warning)
	{
		WarningTip.TooltipDescription = warning;
		Warning.SetActive(true);
	}

	public void DisableWarning()
	{
		Warning.SetActive(false);
	}
}
