using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DarkRoomManager : MonoBehaviour
{
	[SerializeField]
	private List<DialogSequence> darkRoomSequences = new List<DialogSequence>();

	[SerializeField]
	private List<DialogSequence> darkRoomDiceGameSequences = new List<DialogSequence>();

	[SerializeField]
	private bool goToDarkRoom;

	[SerializeField]
	private EntityNameTag entityNameTag;

	[SerializeField]
	private Animator animatorShaker;

	[SerializeField]
	private Transform diceSpawn;

	[SerializeField]
	private GameObject diceNumberPrefab;

	[SerializeField]
	private GameObject diceEffectPrefab;

	[SerializeField]
	private Texture2D[] textureDiceNumber;

	[SerializeField]
	private Texture2D[] textureDiceEffect;

	private List<GameObject> spawnedDice = new List<GameObject>();

	private Dialog activeDialog;

	private UnityAction onFishedDialogAction = delegate
	{
	};

	private int darkRoomEncounters;

	private int daysSinceEffect;

	private bool startDarkRoomEncounters;

	private bool triggerLevelEncounter;

	private bool triggerRandomDayEncounter;

	private bool exitDarkRoom;

	private static DarkRoomManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		entityNameTag = new EntityNameTag("...", Color.white, usePreLocalization: true, "...");
	}

	private void Start()
	{
		base.enabled = false;
	}

	public static void SaveDarkRoomStats(GameData gameData)
	{
		instance.darkRoomEncounters = 0;
		instance.daysSinceEffect = 0;
	}

	public static void LoadDarkRoomStats(GameData gameData)
	{
		instance.darkRoomEncounters = 0;
		instance.daysSinceEffect = 0;
	}

	private void SubscribeEvents()
	{
		ProgressionManager.ListenOnLevelUp(delegate
		{
			TriggerDarkRoomSequence();
		});
		WorldTime.instance.OnFinishedLoadNewDay.AddListener(delegate
		{
			CheckDay();
		});
		InputManager.OnMainClick.AddListener(OnClickEvent);
	}

	private void OnClickEvent()
	{
		if (goToDarkRoom && !exitDarkRoom && activeDialog != null)
		{
			DialogSequenceManager.PlayDialogSequence(activeDialog);
		}
	}

	public static bool IsRunningDarkRoomSequence()
	{
		return !instance.exitDarkRoom;
	}

	public static bool GetTriggerLevelEncounter()
	{
		return instance.triggerLevelEncounter;
	}

	public static bool GetTriggerRandomDayEncounter()
	{
		return instance.triggerRandomDayEncounter;
	}

	public static void ExitDarkRoom()
	{
		instance.goToDarkRoom = false;
		instance.triggerLevelEncounter = false;
		instance.triggerRandomDayEncounter = false;
		DialogSequenceManager.GetGlobalDialogBox().OnFinishedSingleEvent = new UnityEvent();
		DialogSequenceManager.GetGlobalDialogBox().StopDialogImmidiate();
		instance.activeDialog = null;
		instance.onFishedDialogAction = null;
		instance.animatorShaker.SetInteger("State", 0);
		TweenerManager.TweenTimeAction("CleanUp_Dices", 2.5f, delegate
		{
			instance.spawnedDice.ForEach(delegate(GameObject dice)
			{
				Object.Destroy(dice.gameObject);
			});
			instance.spawnedDice.Clear();
		});
	}

	public static bool CheckDarkRoomEvent()
	{
		return instance.goToDarkRoom;
	}

	public void CheckDay()
	{
		if (!instance.startDarkRoomEncounters)
		{
			return;
		}
		int anomalyDuration = AnomalyManager.GetAnomalyDuration();
		if (!AnomalyManager.IsAnomalyActive() || AnomalyManager.DaysSinceActivation() >= anomalyDuration)
		{
			if (AnomalyManager.IsAnomalyActive() && AnomalyManager.DaysSinceActivation() >= anomalyDuration)
			{
				AnomalyManager.EndAnomalyEffect();
				instance.daysSinceEffect = 0;
				GlobalReferences.GetHUDManager().HideDarkRoomEventBanner();
			}
			else if (instance.daysSinceEffect < AnomalyManager.GetAnomalyDuration())
			{
				instance.daysSinceEffect++;
			}
			else
			{
				triggerRandomDayEncounter = AnomalyManager.TriggerNewAnomalyEvent();
				instance.TriggerRoomDiceGameSequence();
			}
		}
	}

	private void TriggerRoomDiceGameSequence()
	{
		if (instance.startDarkRoomEncounters)
		{
			instance.goToDarkRoom = true;
			instance.exitDarkRoom = false;
		}
	}

	public static void PlayDarkRoomDiceGameSequence()
	{
		if (AnomalyManager.IsAnomalyActive())
		{
			AnomalyManager.EndAnomalyEffect();
		}
		DialogSequenceManager.GetGlobalDialogBox().StopDialogImmidiate();
		instance.PlayDarkRoomDiceGame();
	}

	private void PlayDarkRoomDiceGame()
	{
		DialogSequence dialogSequence = darkRoomDiceGameSequences.Find((DialogSequence x) => x.IsTag("DarkRoom_DiceGame"));
		if (dialogSequence == null)
		{
			EndDarkRoomSequence();
			return;
		}
		int num = Random.Range(0, dialogSequence.dialogKeys.Length);
		activeDialog = new Dialog(entityNameTag, new string[1] { dialogSequence.dialogKeys[num] }, dialogSequence.sound, autoProceed: true);
		SubscribeDialogAction(RollDice);
	}

	private void TriggerDarkRoomSequence()
	{
		if (!instance.startDarkRoomEncounters)
		{
			if (ProgressionManager.GetCurrentLevel() <= 1)
			{
				return;
			}
			instance.startDarkRoomEncounters = true;
		}
		instance.goToDarkRoom = true;
		instance.exitDarkRoom = false;
		instance.triggerLevelEncounter = true;
	}

	public static void PlayDarkRoomLevelSequence()
	{
		if (AnomalyManager.IsAnomalyActive())
		{
			AnomalyManager.EndAnomalyEffect();
		}
		DialogSequenceManager.GetGlobalDialogBox().StopDialogImmidiate();
		instance.PlayDarkRoomLevel();
	}

	private void PlayDarkRoomLevel()
	{
		if (ProgressionManager.GetCurrentLevel() - 2 > darkRoomSequences.Count)
		{
			PlayDiceSequence();
			return;
		}
		DialogSequence dialogSequence = darkRoomSequences[ProgressionManager.GetCurrentLevel() - 2];
		if (dialogSequence == null)
		{
			EndDarkRoomSequence();
			return;
		}
		activeDialog = dialogSequence.AsDialog(entityNameTag);
		activeDialog.autoProceed = true;
		SubscribeDialogAction(PlayDiceSequence);
	}

	[ContextMenu("End DarkRoom Sequence")]
	private void EndDarkRoomSequence()
	{
		exitDarkRoom = true;
	}

	private void PlayDiceSequence()
	{
		DialogSequence dialogSequence = darkRoomDiceGameSequences.Find((DialogSequence x) => x.IsTag("DarkRoom_DiceGame"));
		if (dialogSequence == null)
		{
			EndDarkRoomSequence();
			return;
		}
		int num = Random.Range(0, dialogSequence.dialogKeys.Length);
		if (darkRoomEncounters == 0 || darkRoomEncounters == 1)
		{
			num = 0;
		}
		activeDialog = new Dialog(entityNameTag, new string[1] { dialogSequence.dialogKeys[num] }, dialogSequence.sound, autoProceed: true);
		activeDialog.autoProceed = true;
		SubscribeDialogAction(RollDice);
	}

	private void RollDice()
	{
		AnomalyManager.RollEffect();
		TweenerManager.TweenTimeAction("DiceRoll_State_1", 1f, delegate
		{
			animatorShaker.SetInteger("State", 1);
		});
		TweenerManager.TweenTimeAction("DiceRoll_State_2", 4f, delegate
		{
			animatorShaker.SetInteger("State", 2);
			DiceSpawn();
			SoundManager.PlaySoundOnce("darkroom_dice_move");
		});
		TweenerManager.TweenTimeAction("DiceRoll_Reaction", 5f, delegate
		{
			PlayReaction();
			GlobalReferences.GetHUDManager().ShowDarkRoomEventBanner(AnomalyManager.GetActiveEffect().effectMsg);
		});
	}

	private void PlayReaction()
	{
		Debug.LogError(AnomalyManager.GetActiveEffect().effectType.ToString() + " | " + AnomalyManager.GetActiveEffect().effectName + " ");
		DialogSequence dialogSequence = darkRoomDiceGameSequences.Find(delegate(DialogSequence x)
		{
			if (AnomalyManager.GetActiveEffect().effectType == AnomalyEffect.EffectType.Positive)
			{
				return x.IsTag("DarkRoom_Reaction_PositiveEffect");
			}
			return (AnomalyManager.GetActiveEffect().effectType == AnomalyEffect.EffectType.Negative) ? x.IsTag("DarkRoom_Reaction_NegativeEffect") : x.IsTag("DarkRoom_Reaction_PositiveEffect");
		});
		activeDialog = dialogSequence.GetSingleRandomAsDialog(entityNameTag);
		activeDialog.autoProceed = true;
		DialogSequenceManager.GetGlobalDialogBox().StopDialogImmidiate();
		SubscribeDialogAction(EndDarkRoomSequence);
	}

	private void DiceSpawn()
	{
		GameObject gameObject = Object.Instantiate(diceEffectPrefab, diceSpawn);
		GameObject gameObject2 = Object.Instantiate(diceNumberPrefab, diceSpawn);
		spawnedDice.Add(gameObject2);
		spawnedDice.Add(gameObject);
		MeshRenderer componentInChildren = gameObject.GetComponentInChildren<MeshRenderer>();
		MeshRenderer componentInChildren2 = gameObject2.GetComponentInChildren<MeshRenderer>();
		AnomalyEffect activeEffect = AnomalyManager.GetActiveEffect();
		Texture2D value = ((activeEffect.effectType == AnomalyEffect.EffectType.Positive) ? textureDiceEffect[0] : textureDiceEffect[1]);
		Texture2D value2 = textureDiceNumber[activeEffect.index];
		componentInChildren.material.SetTexture("_BaseColor", value);
		componentInChildren2.material.SetTexture("_BaseColor", value2);
		_ = diceSpawn.position - Vector3.up * 0.02f;
		Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
		Rigidbody rigidbody2 = gameObject2.AddComponent<Rigidbody>();
		rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
		rigidbody2.AddForce(Vector3.up, ForceMode.Impulse);
		rigidbody.AddTorque(Random.insideUnitSphere, ForceMode.Impulse);
		rigidbody2.AddTorque(Random.insideUnitSphere, ForceMode.Impulse);
	}

	private void SubscribeDialogAction(UnityAction dialogFinishedAction)
	{
		onFishedDialogAction = delegate
		{
			Debug.Log("Finished Dialog Action: " + dialogFinishedAction.Method.ToString());
			DialogSequenceManager.GetGlobalDialogBox().OnFinishedSingleEvent.RemoveAllListeners();
			activeDialog = null;
			dialogFinishedAction();
			onFishedDialogAction = null;
		};
		DialogSequenceManager.GetGlobalDialogBox().OnFinishedSingleEvent.AddListener(onFishedDialogAction);
		DialogSequenceManager.PlayDialogSequence(activeDialog);
	}
}
