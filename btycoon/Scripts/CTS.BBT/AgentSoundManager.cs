using CTS;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

public class AgentSoundManager : MonoBehaviour
{
	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _footsteps;

	[SerializeField]
	private float _exteriorFootstepsVolume = 0.15f;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _sitDownLow;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _sitDownHigh;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _sitUp;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _blockedMan;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _blockedWoman;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _talk001Man;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _talk002Man;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _talk003Man;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _talkCrossArmsMan;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _talk001Woman;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _talk002Woman;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _talk003Woman;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _talkCrossArmsWoman;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _talkLaughMan;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _talkLaughWoman;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _beforePeeMan;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _beforePeeWoman;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _peeItselfMan;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _peeItselfWoman;

	[SerializeField]
	[Foldout("Common")]
	private AudioAsset _slipOnPuddle;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _callingWaiterMan;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _callingWaiterWoman;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _drink;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _bittenMan;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _bittenDeathMan;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _bittenWoman;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _bittenDeathWoman;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _hypnotized;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _vomitMan;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _vomitWoman;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _alertMan;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _alertWoman;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _panicMan;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _panicWoman;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _zipBodyBag;

	[SerializeField]
	[Foldout("Customer")]
	private AudioAsset _vampireSpawn;

	[SerializeField]
	[Foldout("Hunter")]
	private AudioAsset _hunterShoot;

	[SerializeField]
	[Foldout("Hunter")]
	private AudioAsset _hunterDraw;

	[SerializeField]
	[Foldout("Hunter")]
	private AudioAsset _hunterReload;

	[SerializeField]
	[Foldout("Hunter")]
	private AudioAsset _hunterSheathe;

	[SerializeField]
	[Foldout("Hunter")]
	private AudioAsset _hunterBomb;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _takingOrderMan;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _takingOrderWoman;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _makingDrink;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _bittingMan;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _bittingWoman;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _corpseFall;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _corpseDrop;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _mop;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _cleaningTableHigh;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _cleaningTableLow;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _memoryWipe;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _hypnosis;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _levelUp;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _pickUpBodyBag;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _discardJunk;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _reaperAttackMan;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _reaperAttackFemale;

	[SerializeField]
	[Foldout("Worker")]
	private AudioAsset _teleport;

	private void OnDisable()
	{
		AgentSoundsEvents.Stepping -= OnStepping;
		AgentSoundsEvents.CallingWaiter -= OnCallingWaiter;
		AgentSoundsEvents.Drinking -= OnDrinking;
		AgentSoundsEvents.SittingLow -= OnSittingDownLow;
		AgentSoundsEvents.SittingHigh -= OnSittingHigh;
		AgentSoundsEvents.SittingUp -= OnSittingUp;
		AgentSoundsEvents.Bitten -= OnBitten;
		AgentSoundsEvents.BittenDeath -= OnBittenDeath;
		AgentSoundsEvents.Bitting -= OnBitting;
		AgentSoundsEvents.TakingOrder -= OnTakingOrder;
		AgentSoundsEvents.MakingDrink -= OnMakingDrink;
		AgentSoundsEvents.DropingCorpse -= OnDropingCorpse;
		AgentSoundsEvents.CorpseFall -= OnCorpseFall;
		AgentSoundsEvents.Mop -= OnMop;
		AgentSoundsEvents.CleaningTableHigh -= OnCleaningTableHigh;
		AgentSoundsEvents.CleaningTableLow -= OnCleaningTableLow;
		AgentSoundsEvents.Vomiting -= OnVomiting;
		AgentSoundsEvents.Talking001 -= OnTalk001;
		AgentSoundsEvents.Talking002 -= OnTalk002;
		AgentSoundsEvents.Talking003 -= OnTalk003;
		AgentSoundsEvents.TalkingCrossArms -= OnTalkCrossArms;
		AgentSoundsEvents.TalkingLaugh -= OnTalkLaugh;
		WorkerActionWipeMemory.WipingMemory -= OnWipingMemory;
		WorkerActionHypnotize.Hypnotizing -= OnHypnotizing;
		Customer.HypnosisStateChanging -= OnHypnosisStateChanging;
		CustomerActionAlert.AlertStatusChanged -= OnAlertStatusChanged;
		ContextualStatePanicking.Panicking -= OnPanicking;
		AgentActionBlocked.Blocked -= OnBlocked;
		WorkerLevel.LevelingUp -= OnLevelingUp;
		AgentActionPickUpBody.WrappingInBodyBag -= OnWrappingInBodyBag;
		AgentActionPickUpBodyBag.PickingBodyBagUp -= OnPickingBodyBagUp;
		AgentActionVampireSpawn.VampireSpawning -= OnVampireSpawning;
		WorkerChoreDiscardJunk.DiscardingJunk -= OnDiscardingJunk;
		AgentActionLeave.VampireLeaving -= OnVampireSpawning;
		AgentActionPeeAccident.PeeingHimself -= AgentActionPeeAccident_PeeingHimself;
		AgentActionSlipOnPuddle.SlippingOnPuddle -= AgentActionSlipOnPuddle_SlippingOnPuddle;
		AgentActionShootAgent.HunterShoot -= AgentActionShootAgent_HunterShoot;
		AgentActionReaperDash.ReaperDashSound -= AgentActionReaperDash_ReaperDashSound;
		AgentActionPeeAccident.PeeDance -= AgentActionPeeAccident_PeeDance;
		AgentActionShootAgent.HunterShoot -= AgentActionShootAgent_HunterShoot;
		AgentActionShootAgent.HunterDraw -= AgentActionShootAgent_HunterDraw;
		AgentActionShootAgent.HunterSheathe -= AgentActionShootAgent_HunterSheathe;
		AgentActionShootAgent.HunterReload -= AgentActionShootAgent_HunterReload;
		AgentActionDestroyMachine.ExplodeHunter -= AgentActionDestroyMachine_ExplodeHunter;
		AgentActionTeleport.BlinkPower -= AgentActionTeleport_BlinkPower;
	}

	private void OnEnable()
	{
		AgentSoundsEvents.Stepping += OnStepping;
		AgentSoundsEvents.CallingWaiter += OnCallingWaiter;
		AgentSoundsEvents.Drinking += OnDrinking;
		AgentSoundsEvents.SittingLow += OnSittingDownLow;
		AgentSoundsEvents.SittingHigh += OnSittingHigh;
		AgentSoundsEvents.SittingUp += OnSittingUp;
		AgentSoundsEvents.Bitten += OnBitten;
		AgentSoundsEvents.BittenDeath += OnBittenDeath;
		AgentSoundsEvents.Bitting += OnBitting;
		AgentSoundsEvents.TakingOrder += OnTakingOrder;
		AgentSoundsEvents.MakingDrink += OnMakingDrink;
		AgentSoundsEvents.DropingCorpse += OnDropingCorpse;
		AgentSoundsEvents.CorpseFall += OnCorpseFall;
		AgentSoundsEvents.Mop += OnMop;
		AgentSoundsEvents.CleaningTableHigh += OnCleaningTableHigh;
		AgentSoundsEvents.CleaningTableLow += OnCleaningTableLow;
		AgentSoundsEvents.Vomiting += OnVomiting;
		AgentSoundsEvents.Talking001 += OnTalk001;
		AgentSoundsEvents.Talking002 += OnTalk002;
		AgentSoundsEvents.Talking003 += OnTalk003;
		AgentSoundsEvents.TalkingCrossArms += OnTalkCrossArms;
		AgentSoundsEvents.TalkingLaugh += OnTalkLaugh;
		WorkerActionWipeMemory.WipingMemory += OnWipingMemory;
		WorkerActionHypnotize.Hypnotizing += OnHypnotizing;
		Customer.HypnosisStateChanging += OnHypnosisStateChanging;
		CustomerActionAlert.AlertStatusChanged += OnAlertStatusChanged;
		ContextualStatePanicking.Panicking += OnPanicking;
		AgentActionBlocked.Blocked += OnBlocked;
		WorkerLevel.LevelingUp += OnLevelingUp;
		AgentActionPickUpBody.WrappingInBodyBag += OnWrappingInBodyBag;
		AgentActionPickUpBodyBag.PickingBodyBagUp += OnPickingBodyBagUp;
		AgentActionVampireSpawn.VampireSpawning += OnVampireSpawning;
		WorkerChoreDiscardJunk.DiscardingJunk += OnDiscardingJunk;
		AgentActionLeave.VampireLeaving += OnVampireSpawning;
		AgentActionPeeAccident.PeeingHimself += AgentActionPeeAccident_PeeingHimself;
		AgentActionPeeAccident.PeeDance += AgentActionPeeAccident_PeeDance;
		AgentActionSlipOnPuddle.SlippingOnPuddle += AgentActionSlipOnPuddle_SlippingOnPuddle;
		AgentActionShootAgent.HunterShoot += AgentActionShootAgent_HunterShoot;
		AgentActionShootAgent.HunterDraw += AgentActionShootAgent_HunterDraw;
		AgentActionShootAgent.HunterSheathe += AgentActionShootAgent_HunterSheathe;
		AgentActionShootAgent.HunterReload += AgentActionShootAgent_HunterReload;
		AgentActionDestroyMachine.ExplodeHunter += AgentActionDestroyMachine_ExplodeHunter;
		AgentActionReaperDash.ReaperDashSound += AgentActionReaperDash_ReaperDashSound;
		AgentActionTeleport.BlinkPower += AgentActionTeleport_BlinkPower;
	}

	private void AgentActionTeleport_BlinkPower(Agent obj)
	{
		PlaySoundOneShot(obj, _teleport);
	}

	private void AgentActionPeeAccident_PeeDance(Agent obj)
	{
		PlaySoundOneShot(obj, _beforePeeMan, _beforePeeWoman);
	}

	private void AgentActionReaperDash_ReaperDashSound(Agent obj)
	{
		PlaySoundOneShot(obj, _reaperAttackMan, _reaperAttackFemale);
	}

	private void AgentActionShootAgent_HunterShoot(Agent obj)
	{
		PlaySoundOneShot(obj, _hunterShoot);
	}

	private void AgentActionShootAgent_HunterReload(Agent obj)
	{
		PlaySoundOneShot(obj, _hunterReload);
	}

	private void AgentActionShootAgent_HunterSheathe(Agent obj)
	{
		PlaySoundOneShot(obj, _hunterSheathe);
	}

	private void AgentActionShootAgent_HunterDraw(Agent obj)
	{
		PlaySoundOneShot(obj, _hunterDraw);
	}

	private void AgentActionDestroyMachine_ExplodeHunter(Agent obj)
	{
		PlaySoundOneShot(obj, _hunterBomb);
	}

	private void AgentActionSlipOnPuddle_SlippingOnPuddle(Agent obj)
	{
		PlaySoundOneShot(obj, _slipOnPuddle);
	}

	private void AgentActionPeeAccident_PeeingHimself(Agent obj)
	{
		PlaySoundOneShot(obj, _peeItselfMan, _peeItselfWoman);
	}

	private void OnTalkLaugh(Agent agent)
	{
		PlaySoundOneShot(agent, _talkLaughMan, _talkLaughWoman);
	}

	private void OnDiscardingJunk(Agent agent)
	{
		PlaySoundOneShot(agent, _discardJunk);
	}

	private void OnVampireSpawning(Agent agent)
	{
		PlaySoundOneShot(agent, _levelUp);
	}

	private void OnPickingBodyBagUp(Agent agent)
	{
		PlaySoundOneShot(agent, _pickUpBodyBag);
	}

	private void OnWrappingInBodyBag(Agent agent)
	{
		PlaySoundOneShot(agent, _zipBodyBag);
	}

	private void OnLevelingUp(Agent agent)
	{
		PlaySoundOneShot(agent, _levelUp);
	}

	private void OnBlocked(Agent agent)
	{
		PlaySoundOneShot(agent, _blockedMan, _blockedWoman);
	}

	private void OnPanicking(Agent agent)
	{
		PlaySoundOneShot(agent, _panicMan, _panicWoman);
	}

	private void OnAlertStatusChanged(Agent agent, bool alert)
	{
		if (alert)
		{
			PlaySoundOneShot(agent, _alertMan, _alertWoman);
		}
	}

	private void OnVomiting(Agent agent)
	{
		PlaySoundOneShot(agent, _vomitMan, _vomitWoman);
	}

	private void OnHypnosisStateChanging(Agent agent, bool hypnotized)
	{
		if (hypnotized)
		{
			agent.AudioSource.LoopSoundAsset(_hypnotized);
		}
		else
		{
			agent.AudioSource.Stop();
		}
	}

	private void OnHypnotizing(Agent agent)
	{
		PlaySoundOneShot(agent, _hypnosis);
	}

	private void OnDropingCorpse(Agent agent)
	{
		PlaySoundOneShot(agent, _corpseDrop);
	}

	private void OnCleaningTableHigh(Agent agent)
	{
		PlaySoundOneShot(agent, _cleaningTableHigh);
	}

	private void OnCleaningTableLow(Agent agent)
	{
		PlaySoundOneShot(agent, _cleaningTableLow);
	}

	private void OnWipingMemory(Worker worker, Customer human)
	{
		PlaySoundOneShot(worker, _memoryWipe);
	}

	private void OnMop(Agent agent)
	{
		PlaySoundOneShot(agent, _mop);
	}

	private void OnCorpseFall(Agent agent)
	{
		PlaySoundOneShot(agent, _corpseFall);
	}

	private void OnMakingDrink(Agent agent)
	{
		PlaySoundOneShot(agent, _makingDrink);
	}

	private void OnTakingOrder(Agent agent)
	{
		PlaySoundOneShot(agent, _takingOrderMan, _takingOrderWoman);
	}

	private void OnBitting(Agent p_agent)
	{
		PlaySoundOneShot(p_agent, p_agent.HasDeepVoice ? _bittingMan : _bittingWoman);
	}

	private void OnBitten(Agent agent)
	{
		PlaySoundOneShot(agent, _bittenMan, _bittenWoman);
	}

	private void OnBittenDeath(Agent agent)
	{
		PlaySoundOneShot(agent, _bittenDeathMan, _bittenDeathWoman);
	}

	private void OnStepping(Agent agent)
	{
		if (agent.RoomObject.CurrentRoom.RoomIndex == 0)
		{
			PlaySoundOneShot(agent, _footsteps);
		}
		else
		{
			PlaySoundOneShot(agent, _footsteps);
		}
	}

	private void OnSittingHigh(Agent agent)
	{
		PlaySoundOneShot(agent, _sitDownHigh);
	}

	private void OnSittingUp(Agent agent)
	{
		PlaySoundOneShot(agent, _sitUp);
	}

	private void OnSittingDownLow(Agent agent)
	{
		PlaySoundOneShot(agent, _sitDownLow);
	}

	private void OnDrinking(Agent agent)
	{
		PlaySoundOneShot(agent, _drink);
	}

	private void OnCallingWaiter(Agent agent)
	{
		PlaySoundOneShot(agent, _callingWaiterMan, _callingWaiterWoman);
	}

	private void OnTalk001(Agent agent)
	{
		if (Random.value < 0.3f)
		{
			PlaySoundOneShot(agent, _talk001Man, _talk001Woman);
		}
	}

	private void OnTalk002(Agent agent)
	{
		if (Random.value < 0.3f)
		{
			PlaySoundOneShot(agent, _talk002Man, _talk002Woman);
		}
	}

	private void OnTalk003(Agent agent)
	{
		if (Random.value < 0.3f)
		{
			PlaySoundOneShot(agent, _talk003Man, _talk003Woman);
		}
	}

	private void OnTalkCrossArms(Agent agent)
	{
		if (Random.value < 0.3f)
		{
			PlaySoundOneShot(agent, _talkCrossArmsMan, _talkCrossArmsWoman);
		}
	}

	private void PlaySoundOneShot(Agent agent, AudioAsset soundAsset)
	{
		MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(soundAsset, agent.transform.position);
	}

	private void PlaySoundOneShot(Agent agent, AudioAsset manSoundAsset, AudioAsset womanSoundAsset)
	{
		PlaySoundOneShot(agent, agent.HasDeepVoice ? manSoundAsset : womanSoundAsset);
	}

	private void StopAudioSource(Agent agent)
	{
		agent.AudioSource.Stop();
	}
}
