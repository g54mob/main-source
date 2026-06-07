using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class AnimalText : MonoBehaviour
{
	[SerializeField]
	private string translationKey;

	[SerializeField]
	private int fossils;

	[SerializeField]
	private int biofuel;

	[SerializeField]
	private TMP_Text text;

	private string previousText;

	private LocalizationSystem.Language previousLanguage;

	private TMP_FontAsset previousFont;

	private void Start()
	{
		CheckLanguage();
		CheckFont();
	}

	private void OnEnable()
	{
		if (LocalizationSystem.language != previousLanguage)
		{
			CheckLanguage();
			previousLanguage = LocalizationSystem.language;
		}
		CheckFont();
	}

	private void Update()
	{
		if (previousText != text.text)
		{
			CheckLanguage();
		}
		if (LocalizationSystem.language != previousLanguage)
		{
			CheckLanguage();
			previousLanguage = LocalizationSystem.language;
		}
		CheckFont();
	}

	private void CheckLanguage()
	{
		previousText = LocalizationSystem.GetLocalizedValue(translationKey) + " - <color=#333333><sprite index=11>" + fossils + " <sprite index=1>" + biofuel;
		text.text = previousText;
	}

	private void CheckFont()
	{
		if (!(text == null) && !(text.font == GameManager.ins.fontAsset))
		{
			text.font = GameManager.ins.fontAsset;
			previousFont = text.font;
		}
	}

	public void UpdateCost(int newFossilCost, int newBiofuelCost)
	{
		fossils = newFossilCost;
		biofuel = newBiofuelCost;
		CheckLanguage();
	}
}
