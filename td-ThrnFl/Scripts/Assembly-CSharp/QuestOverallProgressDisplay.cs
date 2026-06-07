using TMPro;
using UnityEngine;

public class QuestOverallProgressDisplay : MonoBehaviour
{
	public TextMeshProUGUI questDisplay;

	public TextMeshProUGUI levelDisplay;

	public TextMeshProUGUI trophyDisplay;

	public GameObject trophyImage;

	public RectTransform backgroundRect;

	public float defaultBackgroundHeight = 89f;

	public float withTrophyBackgroundHeight = 120f;

	private PerkManager perkManager;

	private void Start()
	{
		perkManager = PerkManager.instance;
	}

	private void Update()
	{
		if (LevelProgressManager.instance == null)
		{
			return;
		}
		try
		{
			LevelProgressManager instance = LevelProgressManager.instance;
			int num = instance.CrownsAchieved();
			int num2 = instance.CrownsAvailabe();
			if (instance != null)
			{
				questDisplay.text = num + "<font=PTSerif-Bold SDF>/</font>" + num2;
			}
		}
		catch
		{
			questDisplay.text = "Unknown Error";
		}
		levelDisplay.text = TextTranslator.Translate("Menu/Level") + " <style=\"Body Numerals\">" + perkManager.level;
		int num3 = PerkManager.instance.level - PerkManager.instance.MetaLevels.Count - 1;
		if (num3 > 0)
		{
			backgroundRect.sizeDelta = new Vector2(backgroundRect.sizeDelta.x, withTrophyBackgroundHeight);
			trophyDisplay.text = num3.ToString();
			trophyDisplay.gameObject.SetActive(value: true);
			trophyImage.SetActive(value: true);
		}
		else
		{
			backgroundRect.sizeDelta = new Vector2(backgroundRect.sizeDelta.x, defaultBackgroundHeight);
			trophyDisplay.gameObject.SetActive(value: false);
			trophyImage.SetActive(value: false);
		}
	}
}
