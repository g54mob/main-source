using UnityEngine;
using UnityEngine.UI;

public class TrollButton : MonoBehaviour
{
	public Character character;

	public Button button;

	private Text text;

	private void Start()
	{
		text = button.GetComponentInChildren<Text>();
	}

	public void trollText()
	{
		if (character.bossID < 27)
		{
			text.text = "I lied.";
		}
	}
}
