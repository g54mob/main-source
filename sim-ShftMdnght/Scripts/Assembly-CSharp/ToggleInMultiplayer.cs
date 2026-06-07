using UnityEngine;

public class ToggleInMultiplayer : MonoBehaviour
{
	public bool multiplayerObject;

	public void SetMultiplayer()
	{
		if (multiplayerObject)
		{
			base.gameObject.SetActive(value: true);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
