using UnityEngine;

public class MainMenuBG : MonoBehaviour
{
	public static MainMenuBG Instance;

	private void Awake()
	{
		Instance = this;
		base.gameObject.SetActive(false);
	}
}
