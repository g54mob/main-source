using ClockStone;
using TMPro;
using UnityEngine;

public class IntroPanel2 : MonoBehaviour
{
	private enum State
	{
		ALARM = 0,
		WAIT = 1,
		DONE = 2
	}

	public Intro intro;

	public TextMeshProUGUI text;

	public float fadeInTime;

	public float waitTime;

	private float a;

	private State state;

	private AudioObject alarmClockSound;

	private void Start()
	{
	}

	public void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void SetState(State state)
	{
	}

	public void OnSilenceAlarm()
	{
	}
}
