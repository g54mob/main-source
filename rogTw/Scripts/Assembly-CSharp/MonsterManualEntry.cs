using UnityEngine;
using UnityEngine.UI;

public class MonsterManualEntry : MonoBehaviour
{
	[SerializeField]
	private int level;

	[SerializeField]
	private int enemyClass;

	[SerializeField]
	private Enemy prefab;

	[SerializeField]
	private Text titleText;

	[SerializeField]
	private Text descriptionText;

	[SerializeField]
	private Text statsText;

	[SerializeField]
	private Image img;

	[SerializeField]
	private Sprite unknownSprite;

	private void Start()
	{
		if (PlayerPrefs.GetInt("Class" + enemyClass, 0) + 1 < level)
		{
			if (titleText != null)
			{
				titleText.text = "???";
			}
			if (descriptionText != null)
			{
				descriptionText.text = "???";
			}
			if (img != null)
			{
				img.sprite = unknownSprite;
			}
			if (statsText != null)
			{
				statsText.text = "???";
			}
		}
		else
		{
			if (!(prefab != null) || !(statsText != null))
			{
				return;
			}
			string text = "Level: " + prefab.level;
			text = text + "\nSpeed: " + prefab.baseSpeed;
			text = text + "\nHealth: " + prefab.baseHealth;
			if (prefab.healthRegen > 0)
			{
				text = text + " +" + prefab.healthRegen + "/s";
			}
			if (prefab.baseArmor > 0)
			{
				text = text + "\nArmor: " + prefab.baseArmor;
				if (prefab.armorRegen > 0)
				{
					text = text + " +" + prefab.armorRegen + "/s";
				}
			}
			if (prefab.baseShield > 0)
			{
				text = text + "\nShield: " + prefab.baseShield;
				if (prefab.shieldRegen > 0)
				{
					text = text + " +" + prefab.shieldRegen + "/s";
				}
			}
			statsText.text = text;
		}
	}
}
