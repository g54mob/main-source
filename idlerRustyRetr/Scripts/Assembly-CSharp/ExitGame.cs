using UnityEngine;

public class ExitGame : MonoBehaviour
{
	public void Exit()
	{
		SaveData.ins.SaveGameDataAndQuit();
	}
}
