using UnityEngine;

public class CroppedWindowAsk : MonoBehaviour
{
	private int toTransparencyMode;

	public void ActivateCroppedAsk(int transparencyMode)
	{
		toTransparencyMode = transparencyMode;
		base.gameObject.SetActive(value: true);
	}

	public void YesDaddy()
	{
		SaveData.ins.taskbarHeight = ((toTransparencyMode == 3) ? 80 : 40);
		SaveData.ins.sidebarWidth = 0;
		SaveData.ins.transparencyMode = toTransparencyMode;
		SaveData.ins.SaveGameDataAndQuit();
	}

	public void NoDaddy()
	{
		base.gameObject.SetActive(value: false);
	}
}
