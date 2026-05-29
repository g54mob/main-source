using UnityEngine;
using UnityEngine.UI;

public class AllSpellsController : MonoBehaviour
{
	public Character character;

	public Text bloodPointsDisplay;

	private void Update()
	{
		bloodPointsDisplay.text = "You currently have " + character.bloodMagic.bloodPoints + " Blood.";
	}
}
