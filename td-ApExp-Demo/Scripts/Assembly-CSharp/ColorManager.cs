using UnityEngine;

public class ColorManager : MonoBehaviour
{
	public Color[] RarityColors;

	public Color[] DarkerRarityColors;

	public Color colorReload;

	public Color ColorGreen = new Color(0.4f, 0.71f, 0.19f, 1f);

	public Color ColorYellow = new Color(0.87f, 0.69f, 0.16f, 1f);

	public Color ColorRed = new Color(0.82f, 0.18f, 0.12f, 1f);

	[Header("Status Effect Colors")]
	public Color HackedOutlineColor = new Color(0.58f, 0.36f, 0.74f);

	[Header("Flash Colors")]
	public Color DamageFlashColor = new Color(0.82f, 0.18f, 0.12f, 1f);

	public Color ShieldFlashColor = Color.white;

	public Color CritFlashColor = new Color(0.87f, 0.69f, 0.16f, 1f);

	public Color ImmuneFlashColor = Color.cyan;

	public Color HealFlashColor = new Color(0.4f, 0.71f, 0.19f, 1f);
}
