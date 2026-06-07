using UnityEngine;
using UnityEngine.Video;

public class IntroPanel1 : MonoBehaviour
{
	private enum State
	{
		PLAY = 0,
		DONE = 1
	}

	public Intro intro;

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
