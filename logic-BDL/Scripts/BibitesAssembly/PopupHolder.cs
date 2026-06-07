using UnityEngine;

public class PopupHolder : MonoBehaviour
{
	public static PopupHolder Instance;

	public GameObject screenBlocker;

	public void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}
}
