using UnityEngine;
using UnityEngine.UI;

public class TotalTimePlayed : MonoBehaviour
{
	public Character character;

	public Text timerText;

	private void Start()
	{
		InvokeRepeating("updateText", 0f, 0.1f);
	}

	private void Update()
	{
		updateTimer();
	}

	public void updateTimer()
	{
		character.totalPlaytime.advanceTime(Time.deltaTime);
	}

	private void updateText()
	{
		timerText.text = "<b>Total Time Played:</b> " + NumberOutput.timeOutput(character.totalPlaytime.totalseconds);
	}
}
