using UnityEngine;

public class IntroManager : MonoBehaviour
{
	public float TimeUntilSceneChange;

	public CanvasGroup ContinueCanvas;

	private void Start()
	{
	}

	private void Update()
	{
		TimeUntilSceneChange -= Time.deltaTime;
		if (TimeUntilSceneChange <= 0f)
		{
			ContinueCanvas.alpha = 1f;
			TimeUntilSceneChange = 0f;
			if (Input.anyKeyDown)
			{
				Application.LoadLevel("MainScene");
			}
		}
	}
}
