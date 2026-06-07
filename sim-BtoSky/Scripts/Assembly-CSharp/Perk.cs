using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class Perk : MonoBehaviour
{
	public LocalizedString perkName;

	public LocalizedString perkDescription;

	public Sprite perkImage;

	public Image bg;

	public GameObject selectedImage;

	public bool isUnlocked;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
