using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DelAll : ActiveComponent
{
	private void Del()
	{
		PlayerPrefs.DeleteAll();
		ActiveComponent._controller.construction.OnUnInit();
		SceneManager.LoadSceneAsync("art");
	}

	private void Start()
	{
		base.gameObject.GetComponent<Button>().onClick.AddListener(Del);
	}
}
