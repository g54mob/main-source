using System;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_GoldenIdol : BlackStarPuzzle
{
	public static Puzzle_GoldenIdol Singleton;

	public bool idolCompleted_Blueberry;

	public bool idolCompleted_Raspberry;

	public bool idolCompleted_Strawberry;

	public bool idolCompleted_Kiwi;

	public bool idolCompleted_Plum;

	public bool idolCompleted_Apple;

	public bool idolCompleted_Pear;

	public bool idolCompleted_Peach;

	public bool idolCompleted_Banana;

	public bool idolCompleted_Pineapple;

	public bool idolCompleted_Watermelon;

	public bool idolCompleted_Pumpkin;

	[SerializeField]
	private List<GoldenIdol_Pillar> allPillars;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	public override void Start()
	{
		base.Start();
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Combine(singleton.OnRoundStart_Action, new Action(OnRoundStart));
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Remove(singleton.OnRoundStart_Action, new Action(OnRoundStart));
	}

	private void OnRoundStart()
	{
		UpdateIdolCompletionVisuals();
	}

	private void Update()
	{
	}

	public override void CompletePuzzle(bool _spawnOrb, bool _playSpawnSFX)
	{
		base.CompletePuzzle(_spawnOrb, _playSpawnSFX);
		foreach (GoldenIdol_Pillar allPillar in allPillars)
		{
			allPillar.CompleteIdol(_playSFX: false);
		}
		UpdateIdolCompletionVisuals();
	}

	public void CheckForAllIdolsCompleted(bool _playCompletionSFX)
	{
		foreach (GoldenIdol_Pillar allPillar in allPillars)
		{
			if (!allPillar.idolCompleted)
			{
				return;
			}
		}
		if (!puzzleCompleted)
		{
			CompletePuzzle(true, true);
		}
	}

	private void UpdateIdolCompletionVisuals()
	{
		foreach (GoldenIdol_Pillar allPillar in allPillars)
		{
			switch (allPillar.goldenIdolBerryTier)
			{
			case BerryNames.Blueberry:
				if (idolCompleted_Blueberry)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Raspberry:
				if (idolCompleted_Raspberry)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Strawberry:
				if (idolCompleted_Strawberry)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Kiwi:
				if (idolCompleted_Kiwi)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Plum:
				if (idolCompleted_Plum)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Apple:
				if (idolCompleted_Apple)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Pear:
				if (idolCompleted_Pear)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Peach:
				if (idolCompleted_Peach)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Banana:
				if (idolCompleted_Banana)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Pineapple:
				if (idolCompleted_Pineapple)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Watermelon:
				if (idolCompleted_Watermelon)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			case BerryNames.Pumpkin:
				if (idolCompleted_Pumpkin)
				{
					allPillar.CompleteIdol(_playSFX: false);
				}
				break;
			}
		}
	}
}
