using System;
using UnityEngine;

public class Puzzle_Smoothie : BlackStarPuzzle
{
	public static Puzzle_Smoothie Singleton;

	[Header("Smoothie Visuals")]
	[SerializeField]
	private GameObject completedSmoothieDummy;

	[SerializeField]
	private GameObject smoothieDummyOutline;

	[SerializeField]
	private MeshRenderer completedSmoothieDummy_LiquidMeshRend;

	[Header("Solution")]
	[SerializeField]
	private int[] solutionArray;

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
		UpdateDummySmoothie();
	}

	private void Update()
	{
	}

	public override void CompletePuzzle(bool _spawnOrb, bool _playSpawnSFX)
	{
		base.CompletePuzzle(_spawnOrb, _playSpawnSFX);
		UpdateDummySmoothie();
	}

	private void SetCompletedDummySmoothieColors()
	{
		if (ColorUtility.TryParseHtmlString("#003CFF", out var color))
		{
			completedSmoothieDummy_LiquidMeshRend.material.SetColor("_Color1", color);
		}
		if (ColorUtility.TryParseHtmlString("#FF1E3E", out var color2))
		{
			completedSmoothieDummy_LiquidMeshRend.material.SetColor("_Color2", color2);
		}
	}

	public bool CheckPuzzleSolution(Berry _enteredSmoothieScript)
	{
		bool result = true;
		for (int i = 0; i < solutionArray.Length; i++)
		{
			if (solutionArray[i] != _enteredSmoothieScript.smoothieBerryTiers[i])
			{
				return false;
			}
		}
		return result;
	}

	public void CheckEnteredSmoothie(Berry _enteredSmoothie)
	{
		if (CheckPuzzleSolution(_enteredSmoothie))
		{
			CompletePuzzle(true, true);
			UpdateDummySmoothie();
			UnityEngine.Object.Destroy(_enteredSmoothie.gameObject);
		}
	}

	private void UpdateDummySmoothie()
	{
		if (puzzleCompleted)
		{
			smoothieDummyOutline.SetActive(value: false);
			completedSmoothieDummy.SetActive(value: true);
			SetCompletedDummySmoothieColors();
		}
		else
		{
			smoothieDummyOutline.SetActive(value: true);
			completedSmoothieDummy.SetActive(value: false);
		}
	}
}
