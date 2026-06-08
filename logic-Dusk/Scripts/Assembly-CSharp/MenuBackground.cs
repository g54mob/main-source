using UnityEngine;

public class MenuBackground : MonoBehaviour
{
	public static MenuBackground Instance;

	public Material backgroundMat;

	private void Awake()
	{
		Instance = this;
		Instance.gameObject.SetActive(false);
	}
}
