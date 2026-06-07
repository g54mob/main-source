using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
	public KeyCode key;

	private void Update()
	{
		if (Input.GetKeyDown(key))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			base.enabled = false;
		}
	}
}
