using UnityEngine;
using UnityEngine.UI;

public class ExpDisplay : MonoBehaviour
{
	public Character character;

	public Text expText;

	public int menuID;

	private void Start()
	{
	}

	private void Update()
	{
		if (character.menuID == menuID)
		{
			expText.text = "You currently have " + character.realExp.ToString("###,##0") + " EXP to spend.";
		}
	}
}
