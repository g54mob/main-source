using UnityEngine;

public class ToggleGameObjectActive : MonoBehaviour
{
	[SerializeField]
	private KeyCode toggleKey;

	[SerializeField]
	private KeyCode deletePrefsKey;

	[SerializeField]
	private GameObject[] targetGameObjects;

	private void Update()
	{
		if (Input.GetKeyDown(toggleKey))
		{
			GameObject[] array = targetGameObjects;
			foreach (GameObject obj in array)
			{
				obj.SetActive(!obj.activeSelf);
			}
		}
	}

	private void DeletePlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("Player Prefs Deleted");
	}
}
