using UnityEngine;

public class TelePlayer : MonoBehaviour
{
	private LevelInteractor[] levelInteractors;

	private BonusLevelInteractor[] bonusLevelInteractors;

	private EternalTrialsInteractor eternalTrialsInteractor;

	public PlayerMovement playerMovement;

	public Vector3 spawnOnLevelOffsetPositon;

	private int frame;

	private void Start()
	{
		levelInteractors = GetComponentsInChildren<LevelInteractor>();
		eternalTrialsInteractor = GetComponentInChildren<EternalTrialsInteractor>();
		bonusLevelInteractors = GetComponentsInChildren<BonusLevelInteractor>();
	}

	private void Update()
	{
		frame++;
		if (frame == 2)
		{
			MovePlayerToTheLevelYouCameFrom();
		}
	}

	private void MovePlayerToTheLevelYouCameFrom()
	{
		SceneTransitionManager instance = SceneTransitionManager.instance;
		if (!instance || instance.ComingFromGameplayScene == "")
		{
			return;
		}
		if (instance.ComingFromGameplayScene == "Eternal Trials")
		{
			playerMovement.TeleportTo(eternalTrialsInteractor.banner.transform.position + spawnOnLevelOffsetPositon);
			return;
		}
		for (int i = 0; i < levelInteractors.Length; i++)
		{
			if (levelInteractors[i].levelInfo.sceneName == instance.ComingFromGameplayScene)
			{
				playerMovement.TeleportTo(levelInteractors[i].PlayerTeleportPosition + spawnOnLevelOffsetPositon);
				return;
			}
		}
		for (int j = 0; j < bonusLevelInteractors.Length; j++)
		{
			LevelInfo[] levelsToPick = bonusLevelInteractors[j].levelsToPick;
			for (int k = 0; k < levelsToPick.Length; k++)
			{
				if (levelsToPick[k].sceneName == instance.ComingFromGameplayScene)
				{
					playerMovement.TeleportTo(bonusLevelInteractors[j].transform.position + spawnOnLevelOffsetPositon);
					return;
				}
			}
		}
	}
}
