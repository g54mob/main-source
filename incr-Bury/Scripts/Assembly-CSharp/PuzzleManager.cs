using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
	public static PuzzleManager Singleton;

	public List<BlackStarPuzzle> blackStarPuzzleScripts = new List<BlackStarPuzzle>();

	[SerializeField]
	private GameObject blackStarOrb_Prefab;

	public List<BlackStarOrbState> blackStarOrb_StatesList = new List<BlackStarOrbState>();

	[Header("Puzzle Narrative Unlocks")]
	public List<NarrativePuzzleUnlockSet> narrativePuzzleUnlockSets_Bank;

	public Action Action_BlackStars_OnChanged;

	[Header("Localized Puzzles")]
	[SerializeField]
	private List<Renderer> pcCodePictures_Renders;

	[SerializeField]
	private List<Texture> pcCodePictures_Images_Standard;

	[SerializeField]
	private List<Texture> pcCodePictures_Images_Localized;

	[SerializeField]
	private List<GameObject> pcCodeLegends_Standard;

	[SerializeField]
	private List<GameObject> pcCodeLegends_Localized;

	[SerializeField]
	private List<GameObject> flipPuzzle_Sprites_Standard;

	[SerializeField]
	private List<GameObject> flipPuzzle_Sprites_Localized;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Singleton = this;
		SetupBlackStarStateList();
	}

	private void SetupBlackStarStateList()
	{
		int length = Enum.GetValues(typeof(PuzzleIdentity)).Length;
		for (int i = 0; i < length; i++)
		{
			blackStarOrb_StatesList.Add(BlackStarOrbState.NotSpawned);
		}
	}

	private void Start()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Combine(singleton.OnRoundStart_Action, new Action(OnRoundStart));
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Remove(singleton.OnRoundStart_Action, new Action(OnRoundStart));
	}

	public void UpdateActiveNarrativeObjectsFromPuzzlesSolved()
	{
		for (int i = 0; i < blackStarOrb_StatesList.Count; i++)
		{
			if (blackStarOrb_StatesList[i] == BlackStarOrbState.BrokenAndCollected)
			{
				ShowSolvedPuzzleNarrativeObjects(i);
			}
			else
			{
				HideSolvedPuzzleNarrativeObjects(i);
			}
		}
	}

	private void ShowSolvedPuzzleNarrativeObjects(int _index)
	{
		try
		{
			narrativePuzzleUnlockSets_Bank[_index].SolvedGroup_Show();
			narrativePuzzleUnlockSets_Bank[_index].UnSolvedGroup_Hide();
			narrativePuzzleUnlockSets_Bank[_index].ShowHide_RelatedPcContent(_show: true);
		}
		catch
		{
		}
	}

	private void HideSolvedPuzzleNarrativeObjects(int _index)
	{
		try
		{
			narrativePuzzleUnlockSets_Bank[_index].UnSolvedGroup_Show();
			narrativePuzzleUnlockSets_Bank[_index].SolvedGroup_Hide();
			narrativePuzzleUnlockSets_Bank[_index].ShowHide_RelatedPcContent(_show: false);
		}
		catch
		{
		}
	}

	public void SpawnBlackStarOrb(PuzzleIdentity _puzzleIdentity)
	{
		Transform starOrbSpawnTransform = blackStarPuzzleScripts[(int)_puzzleIdentity].GetStarOrbSpawnTransform();
		GameObject obj = UnityEngine.Object.Instantiate(blackStarOrb_Prefab, starOrbSpawnTransform.position, starOrbSpawnTransform.rotation);
		obj.GetComponent<PickUppable>().puzzleIdentity_Index = (int)_puzzleIdentity;
		Rigidbody component = obj.GetComponent<Rigidbody>();
		component.AddForce(Vector3.up * 1f, ForceMode.VelocityChange);
		component.AddTorque(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f)), ForceMode.VelocityChange);
		blackStarOrb_StatesList[(int)_puzzleIdentity] = BlackStarOrbState.Spawned;
	}

	private void OnRoundStart()
	{
		LoadPuzzleStates();
		Action_BlackStars_OnChanged?.Invoke();
		AchievementChecks();
	}

	private void LoadPuzzleStates()
	{
		for (int i = 0; i < blackStarOrb_StatesList.Count; i++)
		{
			if (blackStarOrb_StatesList[i] == BlackStarOrbState.BrokenAndCollected)
			{
				blackStarPuzzleScripts[i].CompletePuzzle(_SpawnBlackStarOrb: false, _playSolveSFX: false);
			}
			else if (blackStarOrb_StatesList[i] == BlackStarOrbState.Spawned)
			{
				blackStarPuzzleScripts[i].CompletePuzzle(_SpawnBlackStarOrb: true, _playSolveSFX: false);
			}
		}
	}

	public void SetBlackStarOrbState_Collected(int _puzzleIndex)
	{
		blackStarPuzzleScripts[_puzzleIndex].puzzleCompleted = true;
		blackStarOrb_StatesList[_puzzleIndex] = BlackStarOrbState.BrokenAndCollected;
		UpdateActiveNarrativeObjectsFromPuzzlesSolved();
		Action_BlackStars_OnChanged?.Invoke();
		StartCoroutine(WaitASec_ThenCheckBlackStarAchievements());
	}

	public bool HasAllBlackStarPuzzlesCompleted()
	{
		foreach (BlackStarPuzzle blackStarPuzzleScript in blackStarPuzzleScripts)
		{
			if (!blackStarPuzzleScript.puzzleCompleted)
			{
				return false;
			}
		}
		return true;
	}

	public int GetNumberOfCompletedBlackStarPuzzles()
	{
		int num = 0;
		foreach (BlackStarPuzzle blackStarPuzzleScript in blackStarPuzzleScripts)
		{
			if (blackStarPuzzleScript.puzzleCompleted)
			{
				num++;
			}
		}
		return num;
	}

	private IEnumerator WaitASec_ThenCheckBlackStarAchievements()
	{
		yield return new WaitForSeconds(10f);
		AchievementChecks();
	}

	private void AchievementChecks()
	{
		if (blackStarOrb_StatesList[0] == BlackStarOrbState.BrokenAndCollected && !AchievementHelper.IsAchievementUnlocked("ACH_BlackStar_Match"))
		{
			AchievementHelper.UnlockAchievement("ACH_BlackStar_Match");
		}
		if (blackStarOrb_StatesList[1] == BlackStarOrbState.BrokenAndCollected && !AchievementHelper.IsAchievementUnlocked("ACH_BlackStar_Radio"))
		{
			AchievementHelper.UnlockAchievement("ACH_BlackStar_Radio");
		}
		if (blackStarOrb_StatesList[2] == BlackStarOrbState.BrokenAndCollected && !AchievementHelper.IsAchievementUnlocked("ACH_BlackStar_GoldenIdol"))
		{
			AchievementHelper.UnlockAchievement("ACH_BlackStar_GoldenIdol");
		}
		if (blackStarOrb_StatesList[3] == BlackStarOrbState.BrokenAndCollected && !AchievementHelper.IsAchievementUnlocked("ACH_BlackStar_Smoothie"))
		{
			AchievementHelper.UnlockAchievement("ACH_BlackStar_Smoothie");
		}
		if (blackStarOrb_StatesList[4] == BlackStarOrbState.BrokenAndCollected && !AchievementHelper.IsAchievementUnlocked("ACH_BlackStar_Taxi"))
		{
			AchievementHelper.UnlockAchievement("ACH_BlackStar_Taxi");
		}
		if (blackStarOrb_StatesList[5] == BlackStarOrbState.BrokenAndCollected && !AchievementHelper.IsAchievementUnlocked("ACH_BlackStar_RedStrings"))
		{
			AchievementHelper.UnlockAchievement("ACH_BlackStar_RedStrings");
		}
		if (blackStarOrb_StatesList[6] == BlackStarOrbState.BrokenAndCollected && !AchievementHelper.IsAchievementUnlocked("ACH_BlackStar_Belladonna"))
		{
			AchievementHelper.UnlockAchievement("ACH_BlackStar_Belladonna");
		}
	}

	public void UpdateLocalizedPuzzleSwaps()
	{
		if (OptionsManager.Singleton.internationalPuzzles_Setting == 1)
		{
			for (int i = 0; i < pcCodePictures_Renders.Count; i++)
			{
				pcCodePictures_Renders[i].GetComponent<Renderer>().material.mainTexture = pcCodePictures_Images_Localized[i];
			}
			foreach (GameObject item in pcCodeLegends_Localized)
			{
				item.SetActive(value: true);
			}
			foreach (GameObject item2 in pcCodeLegends_Standard)
			{
				item2.SetActive(value: false);
			}
			foreach (GameObject item3 in flipPuzzle_Sprites_Standard)
			{
				item3.SetActive(value: false);
			}
			{
				foreach (GameObject item4 in flipPuzzle_Sprites_Localized)
				{
					item4.SetActive(value: true);
				}
				return;
			}
		}
		for (int j = 0; j < pcCodePictures_Renders.Count; j++)
		{
			pcCodePictures_Renders[j].GetComponent<Renderer>().material.mainTexture = pcCodePictures_Images_Standard[j];
		}
		foreach (GameObject item5 in pcCodeLegends_Localized)
		{
			item5.SetActive(value: false);
		}
		foreach (GameObject item6 in pcCodeLegends_Standard)
		{
			item6.SetActive(value: true);
		}
		foreach (GameObject item7 in flipPuzzle_Sprites_Standard)
		{
			item7.SetActive(value: true);
		}
		foreach (GameObject item8 in flipPuzzle_Sprites_Localized)
		{
			item8.SetActive(value: false);
		}
	}
}
