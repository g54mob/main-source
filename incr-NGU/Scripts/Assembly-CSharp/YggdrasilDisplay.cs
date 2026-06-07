using UnityEngine;
using UnityEngine.UI;

public class YggdrasilDisplay : MonoBehaviour
{
	public Text displayText;

	public Text poopText;

	public Character character;

	private void Start()
	{
		InvokeRepeating("updateDisplay", 0f, 0.5f);
	}

	private void Update()
	{
	}

	public void updateDisplay()
	{
		if (character.menuID == 9)
		{
			displayText.text = character.display(character.yggdrasil.seeds);
			poopText.text = character.display(character.arbitrary.poop1Count);
		}
	}
}
