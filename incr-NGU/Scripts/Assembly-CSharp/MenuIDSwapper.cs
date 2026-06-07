using UnityEngine;

public class MenuIDSwapper : MonoBehaviour
{
	public Character character;

	public int menuID;

	public void swapMenu()
	{
		character.menuID = menuID;
	}
}
