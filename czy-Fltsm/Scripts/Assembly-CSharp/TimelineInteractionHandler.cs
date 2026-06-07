using UnityEngine;
using UnityEngine.Playables;

public class TimelineInteractionHandler : MonoBehaviour
{
	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private KeyCode continueKey = KeyCode.L;

	private bool waitingForInput;

	public void PauseAndWait()
	{
		if (!(director == null))
		{
			director.Pause();
			waitingForInput = true;
		}
	}

	private void Update()
	{
		if (waitingForInput && Input.GetKeyDown(continueKey))
		{
			Resume();
		}
	}

	public void Resume()
	{
		if (waitingForInput && !(director == null))
		{
			waitingForInput = false;
			director.Resume();
		}
	}
}
