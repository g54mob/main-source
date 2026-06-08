using UnityEngine;

public class MenuLauncher : MonoBehaviour
{
	private MenuScreenClass menu;

	private void Awake()
	{
		menu = new MainMenu();
	}

	private void Update()
	{
	}
}
