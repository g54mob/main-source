using TMPro;
using UnityEngine;

public class IntroPanel0 : MonoBehaviour
{
	private enum State
	{
		FADEIN = 0,
		WAIT = 1,
		DONE = 2
	}

	public Intro intro;

	public TextMeshProUGUI text;

	public float fadeInTime;

	public float waitTime;

	private float a;

	private State state;

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
