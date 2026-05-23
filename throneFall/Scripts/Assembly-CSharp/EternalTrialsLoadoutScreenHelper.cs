using UnityEngine;

public class EternalTrialsLoadoutScreenHelper : MonoBehaviour
{
	public LoadoutUIHelper loadout;

	public void Play()
	{
		EternalTrialsRunManager.LoadNextMap();
	}
}
