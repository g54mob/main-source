using UnityEngine;
using UnityEngine.Playables;

public class SimpleTimelineStarter : MonoBehaviour
{
	[Header("Timeline to Test")]
	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private KeyCode startKey = KeyCode.K;

	private void Update()
	{
		if (!(director == null) && !director.playOnAwake && Input.GetKeyDown(startKey))
		{
			director.time = 0.0;
			director.Play();
		}
	}
}
