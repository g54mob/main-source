using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	[SerializeField]
	private GameObject explosionPrefab;

	[SerializeField]
	private float explosionSize = 1f;

	private bool lvl1TutStarted;

	private bool furnaceFixed;

	private bool lvl2TutStarted;

	private bool leverTurned;

	private bool lvl3TutStarted;

	private bool clawEntered;

	private bool lvl4TutStarted;

	private bool cannonEntered;

	public static TutorialManager Instance { get; private set; }

	public bool MapLocked { get; internal set; }

	private void Awake()
	{
		Instance = this;
		if (SaveManager.Instance.IsTutorialComplete)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		EnhancementCard.OnCardClicked += Enhancement_OnClicked;
		LevelManager.Instance.LevelStarted += LevelManager_LevelStarted1;
		LevelManager.Instance.LevelStarted += LevelManager_LevelStarted2;
		Train.Instance.GetFurnaceModuleSlot().Module.HealthComponent.OnFullFix += Furnace_OnFullFix;
		TrackEventSwitch.OnTurnSignalActivated += HandleObstacleWarning;
		Track.OnObstacleDisabled += HandleObstacleDisabled;
		TrackEventResource.OnResourceSignalActivated += HandleResourceWarning;
	}

	private void OnDestroy()
	{
		EnhancementCard.OnCardClicked -= Enhancement_OnClicked;
		LevelManager.Instance.LevelStarted -= LevelManager_LevelStarted1;
		LevelManager.Instance.LevelStarted -= LevelManager_LevelStarted2;
		TrackEventSwitch.OnTurnSignalActivated -= HandleObstacleWarning;
		Track.OnObstacleDisabled -= HandleObstacleDisabled;
		TrackEventResource.OnResourceSignalActivated -= HandleResourceWarning;
		Train.Instance.GetFurnaceModuleSlot().Module.HealthComponent.OnFullFix -= Furnace_OnFullFix;
		(Train.Instance.GetLeverModuleSlot().Module as ModuleDirectionLever).OnTrunLeverActivated -= ModuleDirectionLever_OnTrunLeverActivated;
		Train.Instance.GetClawModuleSlot().Module.OnInteractStartEvent -= ModuleClaw_OnInteractStart;
		Train.Instance.GetCannonModuleSlot().Module.OnInteractStartEvent -= ModuleCannon_OnInteractStart;
	}

	private void Enhancement_OnClicked(EnhancementCard card)
	{
		MapLocked = false;
	}

	private void LevelManager_LevelStarted1()
	{
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial" && LevelManager.Instance.CurrentLevel.Index == 1 && !lvl1TutStarted)
		{
			lvl1TutStarted = true;
			MapLocked = true;
			StartCoroutine(Level1TutCoroutine());
		}
		IEnumerator Level1TutCoroutine()
		{
			furnaceFixed = false;
			yield return new WaitForSeconds(3f);
			Train.Instance.DestroyFurnace(emptyCoal: true);
			GameObject obj = Object.Instantiate(explosionPrefab, Train.Instance.GetFurnaceModuleSlot().transform.position, Quaternion.identity);
			obj.layer = 15;
			obj.GetComponent<Explosion>().Initialize(Train.Instance.GetFurnaceModuleSlot().Module, explosionSize, 0f);
			GetComponent<ExplodeSprite>()?.Explode();
			yield return new WaitUntil(() => Train.Instance.SpeedCurrent <= 0f);
			DialogueManager.OnDialogueProgressTriggered();
			yield return new WaitUntil(() => furnaceFixed);
			DialogueManager.OnDialogueProgressTriggered();
			yield return new WaitUntil(() => Train.Instance.CoalSeconds > 0f);
			DialogueManager.OnDialogueProgressTriggered();
		}
	}

	private void Furnace_OnFullFix(HealthChangeInfo info)
	{
		furnaceFixed = true;
	}

	private void HandleObstacleWarning(bool obj)
	{
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial" && LevelManager.Instance.CurrentLevel.Index == 2 && !lvl2TutStarted)
		{
			lvl2TutStarted = true;
			MapLocked = true;
			(Train.Instance.GetLeverModuleSlot().Module as ModuleDirectionLever).OnTrunLeverActivated += ModuleDirectionLever_OnTrunLeverActivated;
			StartCoroutine(ShowDialogueAfterStop());
		}
		IEnumerator ShowDialogueAfterStop()
		{
			leverTurned = false;
			DialogueManager.OnDialogueProgressTriggered();
			Train.Instance.AddSlowDebuff(100f, 2f);
			yield return new WaitUntil(() => Train.Instance.SpeedCurrent <= 0f);
			DialogueManager.OnDialogueProgressTriggered();
			yield return new WaitUntil(() => leverTurned);
			DialogueManager.OnDialogueProgressTriggered();
			Train.Instance.RemoveSlowDebuffGradually();
		}
	}

	private void ModuleDirectionLever_OnTrunLeverActivated()
	{
		leverTurned = true;
	}

	private void HandleObstacleDisabled()
	{
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial" && LevelManager.Instance.CurrentLevel.Index == 2)
		{
			DialogueManager.OnDialogueProgressTriggered();
		}
	}

	private void HandleResourceWarning()
	{
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial" && LevelManager.Instance.CurrentLevel.Index == 3 && !lvl3TutStarted)
		{
			lvl3TutStarted = true;
			MapLocked = true;
			Train.Instance.GetClawModuleSlot().Module.OnInteractStartEvent += ModuleClaw_OnInteractStart;
			StartCoroutine(ShowDialogueAfterStop());
		}
		IEnumerator ShowDialogueAfterStop()
		{
			clawEntered = false;
			yield return new WaitForSeconds(3f);
			DialogueManager.OnDialogueProgressTriggered();
			Train.Instance.AddSlowDebuff(100f, 2f);
			yield return new WaitUntil(() => Train.Instance.SpeedCurrent <= 0f);
			DialogueManager.OnDialogueProgressTriggered();
			yield return new WaitUntil(() => clawEntered);
			DialogueManager.OnDialogueProgressTriggered();
			Train.Instance.RemoveSlowDebuffGradually();
		}
	}

	private void ModuleClaw_OnInteractStart()
	{
		clawEntered = true;
	}

	private void LevelManager_LevelStarted2()
	{
		if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial" && LevelManager.Instance.CurrentLevel.Index == 4 && !lvl4TutStarted)
		{
			lvl4TutStarted = true;
			Train.Instance.GetCannonModuleSlot().Module.GetComponent<ModuleCannon>().cannon.TryStopReload();
			Train.Instance.GetCannonModuleSlot().Module.GetComponent<ModuleCannon>().cannon.InstantFullReload();
			MapLocked = true;
			Train.Instance.GetCannonModuleSlot().Module.OnInteractStartEvent += ModuleCannon_OnInteractStart;
			StartCoroutine(Level4TutCoroutine());
		}
		IEnumerator Level4TutCoroutine()
		{
			cannonEntered = false;
			yield return new WaitForSeconds(3f);
			DialogueManager.OnDialogueProgressTriggered();
			yield return new WaitUntil(() => cannonEntered);
			DialogueManager.OnDialogueProgressTriggered();
		}
	}

	private void ModuleCannon_OnInteractStart()
	{
		cannonEntered = true;
	}
}
