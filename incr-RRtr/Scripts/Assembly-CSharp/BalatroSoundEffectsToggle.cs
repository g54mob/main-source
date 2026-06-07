using UnityEngine;
using UnityEngine.UI;

public class BalatroSoundEffectsToggle : MonoBehaviour
{
	[SerializeField]
	private Image toggleImage;

	[SerializeField]
	private Sprite toggleOnSprite;

	[SerializeField]
	private Sprite toggleOffSprite;

	public void ToggleSFX(bool toggle)
	{
		GameManager.ins.balatroSoundEffects = toggle;
		if (toggle)
		{
			toggleImage.sprite = toggleOnSprite;
		}
		else
		{
			toggleImage.sprite = toggleOffSprite;
		}
	}
}
