using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VfxManager : ScriptableObject
{
	[SerializeField]
	private SessionQuestFulfilledFX sessionQuestFulfilledFx;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private RewardSystem rewardSystem;

	private InteractionRestriction rememberInteractionRestriction;

	[FormerlySerializedAs("sessionQuestFulfilledSound")]
	[SerializeField]
	private AudioClipOptions challengeFulfilledSound;

	[SerializeField]
	private AudioClipOptions challengeUnlockedSound;

	[SerializeField]
	private bool debug;

	[SerializeField]
	private SessionQuest defaultFulfilledSessionQuest;

	[SerializeField]
	private bool shouldClearOtherSessionQuests;

	private List<SessionQuestFulfilledFX> spawnedSessionQuestFulfilledFxes = new List<SessionQuestFulfilledFX>();

	private List<SessionQuestInfo> pendingSessionQuestFxs = new List<SessionQuestInfo>();

	private SessionQuestFulfilledFX spawnedEffect;

	public SessionQuestFulfilledFX ActiveChallengeFx => spawnedEffect;

	public event Action<SessionQuest, int> OnChallengeFxStarted;

	public event Action<SessionQuest, int> OnChallengeRewardClaimed;

	public void Setup()
	{
		pendingSessionQuestFxs = new List<SessionQuestInfo>();
		rememberInteractionRestriction = new InteractionRestriction();
	}

	private void OpenMenu()
	{
		pendingSessionQuestFxs.Clear();
		if ((bool)spawnedEffect)
		{
			spawnedEffect.Hide();
		}
	}

	public void SpawnEffectAtPosition(VfxConfiguration targetEffect, Vector3 position)
	{
		if (!(targetEffect == null) && !(targetEffect.effect == null))
		{
			UnityEngine.Object.Instantiate(targetEffect.effect, position, Quaternion.identity);
		}
	}

	public SessionQuestFulfilledFX SpawnSessionQuestEffect(SessionQuest fulfilledSessionQuest, SessionQuestFxType fxType, int fulfilledLevel = -1)
	{
		if (fxType == SessionQuestFxType.ChallengeFulfilled)
		{
			this.OnChallengeFxStarted?.Invoke(fulfilledSessionQuest, fulfilledLevel);
		}
		Singleton<MainMenuUi>.Instance.ChangeIngameBrightness(shouldMakeDarker: true);
		if (debug)
		{
			if (fulfilledSessionQuest == null)
			{
				fulfilledSessionQuest = defaultFulfilledSessionQuest;
			}
			if (shouldClearOtherSessionQuests)
			{
				ClearSessionQuestFXs();
			}
		}
		switch (fxType)
		{
		case SessionQuestFxType.ChallengeFulfilled:
			AudioManager.Instance.PlayGlobalSound(challengeFulfilledSound);
			break;
		case SessionQuestFxType.ChallengeUnlocked:
			AudioManager.Instance.PlayGlobalSound(challengeUnlockedSound);
			break;
		}
		spawnedEffect = UnityEngine.Object.Instantiate(sessionQuestFulfilledFx, Vector3.zero, Quaternion.identity);
		spawnedEffect.Setup(fulfilledSessionQuest, fulfilledLevel, fxType);
		spawnedEffect.OnHidden += delegate
		{
			PlayNextSessionQuestFx(removeEffect: true);
		};
		if (debug)
		{
			spawnedSessionQuestFulfilledFxes.Add(spawnedEffect);
		}
		return spawnedEffect;
	}

	private void ClearSessionQuestFXs()
	{
		foreach (SessionQuestFulfilledFX spawnedSessionQuestFulfilledFx in spawnedSessionQuestFulfilledFxes)
		{
			if ((bool)spawnedSessionQuestFulfilledFx)
			{
				spawnedSessionQuestFulfilledFx.Hide();
			}
		}
		spawnedSessionQuestFulfilledFxes.Clear();
	}

	public void AddSessionQuestEffectToQueue(SessionQuest fulfilledSessionQuest, int fulfilledLevel, SessionQuestFxType type)
	{
		pendingSessionQuestFxs.Add(new SessionQuestInfo
		{
			sessionQuest = fulfilledSessionQuest,
			watchLevel = fulfilledLevel,
			fxType = type
		});
		if (pendingSessionQuestFxs.Count == 1)
		{
			Debug.LogWarning($"1 pendingFX, remember restriction {inputRouter.InteractionRestriction.cameraControlsAllowed} {inputRouter.InteractionRestriction.tileControlsAllowed}");
			rememberInteractionRestriction = inputRouter.InteractionRestriction;
			inputRouter.SetInteractionRestriction(new InteractionRestriction
			{
				cameraControlsAllowed = false,
				tileControlsAllowed = false
			});
			PlayNextSessionQuestFx(removeEffect: false);
		}
	}

	private void PlayNextSessionQuestFx(bool removeEffect)
	{
		Debug.Log($"Play next effect, remove? {removeEffect}");
		if (removeEffect && pendingSessionQuestFxs.Count > 0)
		{
			Debug.Log($"Trigger OnChallengeClaimed? {pendingSessionQuestFxs[0].fxType}");
			if (pendingSessionQuestFxs[0].fxType == SessionQuestFxType.ChallengeFulfilled)
			{
				this.OnChallengeRewardClaimed?.Invoke(pendingSessionQuestFxs[0].sessionQuest, pendingSessionQuestFxs[0].watchLevel);
			}
			pendingSessionQuestFxs.RemoveAt(0);
		}
		if (pendingSessionQuestFxs.Count == 0)
		{
			Debug.LogWarning($"0 pending FXs, set to rememberRestriction {rememberInteractionRestriction.cameraControlsAllowed} {rememberInteractionRestriction.tileControlsAllowed}");
			inputRouter.SetInteractionRestriction(rememberInteractionRestriction);
			spawnedEffect = null;
			Singleton<MainMenuUi>.Instance.ChangeIngameBrightness(shouldMakeDarker: false);
			if (rewardSystem.IsGameOver && inputRouter.GameState == GameState.Playing)
			{
				OverwritingSingleton<IngameUi>.Instance.SelectGameOverScreenDefault();
			}
		}
		else
		{
			SessionQuestInfo sessionQuestInfo = pendingSessionQuestFxs[0];
			SpawnSessionQuestEffect(sessionQuestInfo.sessionQuest, sessionQuestInfo.fxType, sessionQuestInfo.watchLevel);
		}
	}

	public void SpawnEffectAtTransform(VfxConfiguration targetEffect, Transform targetTransform)
	{
		if (!(targetEffect == null) && !(targetEffect.effect == null))
		{
			UnityEngine.Object.Instantiate(targetEffect.effect, targetTransform.position, targetTransform.rotation);
		}
	}

	private void _003CSpawnSessionQuestEffect_003Eb__23_0()
	{
		PlayNextSessionQuestFx(removeEffect: true);
	}
}
