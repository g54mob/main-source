using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void GoToTheOpenField()
	{
		SceneManager.LoadScene(1);
	}

	public void GoBackTotheHouse()
	{
	}
}
