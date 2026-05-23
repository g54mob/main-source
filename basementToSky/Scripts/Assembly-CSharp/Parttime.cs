using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Parttime : MonoBehaviour
{
	[SerializeField]
	private Image mainImage;

	[SerializeField]
	private TextMeshProUGUI title;

	[SerializeField]
	private TextMeshProUGUI pay;

	[SerializeField]
	private QuestData parttime;

	private void Start()
	{
		PerkUI.OnPerkUnlocked += PerkUI_OnPerkUnlocked;
		if (GameManager.S.intelPerkList[2])
		{
			int num = Mathf.FloorToInt((float)parttime.pay * 1.5f);
			pay.text = $"{num}";
		}
		else
		{
			pay.text = $"{parttime.pay}";
		}
	}

	private void OnDestroy()
	{
		PerkUI.OnPerkUnlocked -= PerkUI_OnPerkUnlocked;
	}

	private void PerkUI_OnPerkUnlocked()
	{
		if (GameManager.S.intelPerkList[2])
		{
			int num = Mathf.FloorToInt((float)parttime.pay * 1.5f);
			pay.text = $"{num}";
		}
	}

	private void Update()
	{
	}

	public void StartParttime()
	{
		GameManager.S.StartPartTime(parttime, base.transform);
	}
}
