using System;
using PlayerState;
using Pug.UnityExtensions;
using UnityEngine;

public class CutsceneHandler : MonoBehaviour
{
	private TimerSimple cutsceneTimer = new TimerSimple(13.5f);

	[NonSerialized]
	public TheCore theCore;

	private bool skipCutscene;

	private bool cutsceneComplete;

	public bool isPlaying { get; private set; }

	public bool isLookingForObjectsToStartPlay { get; private set; }

	public void StartPlaying()
	{
		isPlaying = true;
		isLookingForObjectsToStartPlay = true;
		Manager.ui.FadeOutAllGameplayUI();
		Manager.ui.FadeOutMouse();
	}

	private void Update()
	{
		PlayerController player = Manager.main.player;
		if (isLookingForObjectsToStartPlay && !cutsceneComplete)
		{
			if (player != null)
			{
				player.playerCommandSystem.SetPlayerState(player.entity, PlayerStateEnum.SpawningFromCore, locked: true);
			}
			if (player != null && player.gameObject.activeInHierarchy && theCore != null && theCore.gameObject.activeInHierarchy)
			{
				player.StartSpawningFromCoreRoutine();
				theCore.StartCoroutine(theCore.Intro_Coroutine());
				isLookingForObjectsToStartPlay = false;
				cutsceneTimer.Start();
			}
		}
		if (player != null && !cutsceneComplete && ((isPlaying && !isLookingForObjectsToStartPlay && EntityUtility.GetComponentData<PlayerStateCD>(player.entity, player.world).HasAnyState(PlayerStateEnum.SpawningFromCore) && player.spawningFromCoreFinished && cutsceneTimer.isRunning && cutsceneTimer.isTimerElapsed) || skipCutscene))
		{
			skipCutscene = false;
			isPlaying = false;
			cutsceneTimer.Stop();
			Manager.ui.FadeInAllGameplayUI();
			Manager.ui.FadeInMouse();
			player.playerCommandSystem.UnlockCurrentState(player.entity);
			player.playerCommandSystem.SetPlayerState(player.entity, PlayerStateEnum.Walk);
			cutsceneComplete = true;
			WorldInfo worldInfo = Manager.saves.GetWorldInfo();
			if (worldInfo != null && worldInfo.worldGenerationType == WorldGenerationType.Classic && Manager.load.GetNameOfCurrentScene() == "Main")
			{
				Manager.ui.chatWindow.AddInfoText(ChatWindow.MessageTextType.StartingClassicWorld);
			}
		}
	}
}
