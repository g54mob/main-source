using UnityEngine;

public class GameObjectToggler : MonoBehaviour
{
	public void Toggle()
	{
		base.gameObject.SetActive(!base.gameObject.activeSelf);
	}
}
