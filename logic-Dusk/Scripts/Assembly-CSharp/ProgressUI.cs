using UnityEngine;

public class ProgressUI : MonoBehaviour
{
	public static ProgressUI Instance;

	public GameObject skinObject;

	private void Awake()
	{
		Instance = this;
		if (skinObject != null && GlobalSettings.GameState.CurrentSkin == SkinEnum.Default)
		{
			skinObject.SetActive(false);
		}
	}
}
