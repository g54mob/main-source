using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot_DeleteButton : MonoBehaviour
{
	[SerializeField]
	private int slot;

	[SerializeField]
	private Image confirmProgress_FillImage;

	private float confirmProgress_Curr;

	private float confirmProgress_Growth = 0.21f;

	private float confirmProgress_DecayPerSec = 0.5f;

	private float confirmProgress_DecayTimer;

	private void Start()
	{
	}

	private void Update()
	{
		HandleDecayTimer();
		UpdateDeletionProgressFill();
	}

	public void OnClick()
	{
		confirmProgress_Curr = Mathf.Clamp(confirmProgress_Curr + confirmProgress_Growth, 0f, 1f);
		confirmProgress_DecayTimer = 3f;
		if (confirmProgress_Curr == 1f)
		{
			DeleteSaveSlot();
		}
	}

	private void HandleDecayTimer()
	{
		if (confirmProgress_DecayTimer > 0f)
		{
			confirmProgress_DecayTimer -= Time.deltaTime;
		}
		else if (confirmProgress_Curr > 0f)
		{
			confirmProgress_Curr -= Time.deltaTime * confirmProgress_DecayPerSec;
		}
	}

	private void UpdateDeletionProgressFill()
	{
		confirmProgress_FillImage.fillAmount = confirmProgress_Curr;
	}

	public void DeleteSaveSlot()
	{
		string path = Path.Combine(Application.persistentDataPath, "Demo", $"slot_{slot}.json");
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		string path2 = Path.Combine(Application.persistentDataPath, "Demo", $"slot_{slot}_Info.json");
		if (File.Exists(path2))
		{
			File.Delete(path2);
		}
		confirmProgress_Curr = 0f;
		confirmProgress_DecayTimer = 0f;
		MainMenuManager.Singleton.UpdateAllSaveSlotUIButtons();
	}
}
