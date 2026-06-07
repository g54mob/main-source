using UnityEngine;
using UnityEngine.Video;

public class OutroPanel1 : MonoBehaviour
{
	private enum State
	{
		PLAY = 0,
		DONE = 1
	}

	public Outro outro;

	private VideoPlayer videoPlayer;

	public GameObject videoPlayerContainer;

	private State state;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SetState(State state)
	{
	}
}
