using UnityEngine;
using UnityEngine.UI;

public class LittleRebirthTimer : MonoBehaviour
{
	public Character character;

	public Text timerText;

	private void Start()
	{
		InvokeRepeating("updateText", 0f, 0.1f);
	}

	private void updateText()
	{
		timerText.text = "Current Rebirth Time\n " + character.rebirthTime.timeDisplayColon();
	}
}
