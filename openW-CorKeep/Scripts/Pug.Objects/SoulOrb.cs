using System;
using System.Collections;
using System.Collections.Generic;
using Pug.UnityExtensions;
using PugScan;
using Unity.Entities;
using UnityEngine;

public class SoulOrb : EntityMonoBehaviour
{
	[Serializable]
	public class AvailableEffects
	{
		public PlayerController activeTarget;

		public ParticlesTargeting effect;
	}

	public List<AvailableEffects> empowerPlayerEffects;

	private TimerSimple updateTimer;

	private Flashable flasher;

	private bool hasCollectedSouls;

	private List<PlayerController> playersCurrentlyGivenSoul = new List<PlayerController>();

	private const float SQR_DISTANCE_TO_GIVE_SOUL = 25f;

	private const string NAMES = "Names/";

	public override void OnOccupied()
	{
		base.OnOccupied();
		updateTimer = new TimerSimple(3f);
		updateTimer.Start();
		playersCurrentlyGivenSoul.Clear();
		for (int i = 0; i < empowerPlayerEffects.Count; i++)
		{
			empowerPlayerEffects[i].activeTarget = null;
			empowerPlayerEffects[i].effect.p.Stop();
		}
		flasher = GetComponent<Flashable>();
		SoulID givesSoul = EntityUtility.GetComponentData<SoulOrbCD>(base.entity, base.world).givesSoul;
		hasCollectedSouls = Manager.saves.HasCollectedSoul(givesSoul);
		if (hasCollectedSouls)
		{
			animator.SetTrigger(1796921150);
		}
		ObjectID objectID = ObjectID.None;
		switch (givesSoul)
		{
		case SoulID.SoulOfAzeos:
			objectID = ObjectID.NatureBossStatue;
			break;
		case SoulID.SoulOfOmoroth:
			objectID = ObjectID.SeaBossStatue;
			break;
		case SoulID.SoulOfScarab:
			objectID = ObjectID.DesertBossStatue;
			break;
		case SoulID.SoulOfNatureHydra:
			objectID = ObjectID.HydraBossStatue;
			break;
		case SoulID.SoulOfSeaHydra:
			objectID = ObjectID.HydraBossStatue;
			break;
		case SoulID.SoulOfDesertHydra:
			objectID = ObjectID.HydraBossStatue;
			break;
		}
		if (Manager.ui.mapUI.IsShowingShrineMarker(objectID))
		{
			Manager.ui.chatWindow.AddInfoText(ChatWindow.MessageTextType.TalkToTheCore);
			if (objectID != ObjectID.None)
			{
				base.world.GetExistingSystemManaged<PugScanClientSystem>().Scan(new ScanRequestCD
				{
					objectToScan = new ObjectDataCD
					{
						objectID = objectID
					},
					sendResponse = false,
					typeOfRequest = PugScanType.HideMarker
				});
			}
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		SoulID givesSoul = EntityUtility.GetComponentData<SoulOrbCD>(base.entity, base.world).givesSoul;
		if (!updateTimer.isRunning || updateTimer.isTimerElapsed)
		{
			updateTimer.Start(0.5f);
			foreach (PlayerController allPlayer in Manager.main.allPlayers)
			{
				TryPlaySoulEffectOnPlayer(allPlayer, givesSoul);
			}
		}
		UpdateParticlesTargets();
		if (Manager.saves.HasCollectedSoul(givesSoul) && !hasCollectedSouls)
		{
			hasCollectedSouls = true;
			animator.SetTrigger(1796921150);
		}
	}

	private void TryPlaySoulEffectOnPlayer(PlayerController player, SoulID givesSoul)
	{
		if (player == null || player.entity == Entity.Null || player.currentHealth <= 0 || playersCurrentlyGivenSoul.Contains(player))
		{
			return;
		}
		if (!EntityUtility.HasUnlockedSouls(player.entity, player.world))
		{
			Manager.main.player.UnlockSouls();
		}
		if (EntityUtility.HasCollectedSoul(givesSoul, player.entity, player.world) || !((player.transform.position - base.transform.position).sqrMagnitude < 25f))
		{
			return;
		}
		playersCurrentlyGivenSoul.Add(player);
		int num = -1;
		for (int i = 0; i < empowerPlayerEffects.Count; i++)
		{
			if (empowerPlayerEffects[i].activeTarget == null)
			{
				num = i;
				empowerPlayerEffects[i].activeTarget = player;
				break;
			}
		}
		if (num != -1)
		{
			StartCoroutine(SoulEffect_Coroutine(player, givesSoul, num));
		}
	}

	private IEnumerator SoulEffect_Coroutine(PlayerController player, SoulID givesSoul, int effectIndex)
	{
		empowerPlayerEffects[effectIndex].effect.p.Play(withChildren: true);
		AudioManager.SfxFollowTransform(SfxID.powerUp, base.transform, 0.8f, 0.85f);
		if ((bool)flasher)
		{
			flasher.FlashLinearNoCurve(3.1f);
		}
		yield return new WaitForSeconds(0.25f);
		if (player == null)
		{
			empowerPlayerEffects[effectIndex].effect.p.Stop(withChildren: true);
			empowerPlayerEffects[effectIndex].activeTarget = null;
			playersCurrentlyGivenSoul.Remove(player);
			yield break;
		}
		player.flashableComponent.FlashLinearNoCurve(3.5f);
		yield return new WaitForSeconds(1.75f);
		empowerPlayerEffects[effectIndex].effect.p.Stop(withChildren: true);
		if (player == null)
		{
			empowerPlayerEffects[effectIndex].activeTarget = null;
			playersCurrentlyGivenSoul.Remove(player);
			yield break;
		}
		if (player.isLocal)
		{
			Manager.main.player.CollectSoul(givesSoul);
			Manager.ui.chatWindow.AddInfoText(new string[1] { "Names/" + givesSoul }, ChatWindow.MessageTextType.GainedSoul);
			if (!Manager.ui.characterWindow.isShowing)
			{
				Manager.ui.ShowBagLightUpHint();
			}
			if (!Manager.ui.characterWindow.soulsWindow.isShowing)
			{
				Manager.ui.ShowSoulsTabLightUpHint();
			}
		}
		yield return new WaitForSeconds(3f);
		playersCurrentlyGivenSoul.Remove(player);
		empowerPlayerEffects[effectIndex].activeTarget = null;
	}

	private void UpdateParticlesTargets()
	{
		foreach (AvailableEffects empowerPlayerEffect in empowerPlayerEffects)
		{
			if (empowerPlayerEffect.activeTarget != null)
			{
				empowerPlayerEffect.effect.Target.position = empowerPlayerEffect.activeTarget.center;
			}
		}
	}
}
