using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	public void Update()
	{
		if (Input.GetKeyDown("r"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
