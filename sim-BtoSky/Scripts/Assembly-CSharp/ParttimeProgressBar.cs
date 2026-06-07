using RainbowArt.CleanFlatUI;
using UnityEngine;

public class ParttimeProgressBar : MonoBehaviour
{
	[SerializeField]
	private ProgressBar progressBar;

	private void Start()
	{
		QuestManager.S.OnNewsPaperDelivered += Qm_OnNewsPaperDelivered;
		QuestManager.S.OnTrashBagCleaned += Qm_OnTrashBagCleaned;
		QuestManager.S.OnGrassCutted += Qm_OnGrassCutted;
		QuestManager.S.OnGarageCleaned += Qm_OnGarageCleaned;
	}

	private void Qm_OnGarageCleaned()
	{
		progressBar.CurrentValue += 4f;
		if (progressBar.CurrentValue >= progressBar.MaxValue * 0.7f)
		{
			QuestManager.S.GarageCleaningCompleted();
		}
	}

	private void Qm_OnGrassCutted()
	{
		if (QuestManager.S.currentPartTimeIndex == 2)
		{
			progressBar.CurrentValue += 0.5f;
			if (progressBar.CurrentValue >= progressBar.MaxValue * 0.7f)
			{
				QuestManager.S.MowingCompleted();
				QuestManager.S.OnGrassCutted -= Qm_OnGrassCutted;
			}
		}
	}

	private void OnDestroy()
	{
		QuestManager.S.OnNewsPaperDelivered -= Qm_OnNewsPaperDelivered;
		QuestManager.S.OnTrashBagCleaned -= Qm_OnTrashBagCleaned;
		QuestManager.S.OnGrassCutted -= Qm_OnGrassCutted;
		QuestManager.S.OnGarageCleaned -= Qm_OnGarageCleaned;
	}

	private void Qm_OnTrashBagCleaned()
	{
		progressBar.CurrentValue += 10f;
		if (progressBar.CurrentValue == progressBar.MaxValue)
		{
			QuestManager.S.CleanUpCompleted();
		}
	}

	private void Qm_OnNewsPaperDelivered()
	{
		progressBar.CurrentValue += 25f;
	}

	private void Update()
	{
	}
}
