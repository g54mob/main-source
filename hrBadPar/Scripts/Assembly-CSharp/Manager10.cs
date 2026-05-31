using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager10 : MonoBehaviour
{
	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void End()
	{
		SceneManager.LoadScene("Main");
	}
}
