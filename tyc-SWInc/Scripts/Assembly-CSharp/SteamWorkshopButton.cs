using UnityEngine;

public class SteamWorkshopButton : MonoBehaviour
{
	private void Start()
	{
		if (Versioning.Demo || !SteamManager.Initialized)
		{
			base.gameObject.SetActive(false);
		}
	}
}
