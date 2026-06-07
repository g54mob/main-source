using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_RedString : BlackStarPuzzle
{
	public static Puzzle_RedString Singleton;

	public bool canSubmitAnswer = true;

	[Header("Puzzle Objects")]
	[SerializeField]
	private GameObject bluePin;

	private float bluePin_Y_OnSubmit = -0.415f;

	private bool bluePinSubmitAnimActive;

	[SerializeField]
	private float bluePin_AnimSpeed;

	[SerializeField]
	private List<GameObject> pinObjects;

	[Header("PinCushions")]
	public List<PinCushion> pinCushions;

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
	}

	private void Update()
	{
		if (bluePinSubmitAnimActive)
		{
			bluePin.transform.localPosition = Vector3.MoveTowards(bluePin.transform.localPosition, new Vector3(bluePin.transform.localPosition.x, bluePin_Y_OnSubmit, bluePin.transform.localPosition.z), bluePin_AnimSpeed * Time.deltaTime);
		}
	}

	public override void CompletePuzzle(bool _spawnOrb, bool _playSpawnSFX)
	{
		base.CompletePuzzle(_spawnOrb, _playSpawnSFX);
		StartCoroutine(StartBluePinAnimation());
		pinCushions[0].SetPinAmount(4);
		pinCushions[1].SetPinAmount(7);
		pinCushions[2].SetPinAmount(8);
		canSubmitAnswer = false;
	}

	private IEnumerator StartBluePinAnimation()
	{
		bluePinSubmitAnimActive = true;
		yield return new WaitForSeconds(1f);
		bluePinSubmitAnimActive = false;
	}

	public bool CheckSolution()
	{
		foreach (PinCushion pinCushion in pinCushions)
		{
			if (!pinCushion.IsCorrectInput())
			{
				return false;
			}
		}
		return true;
	}

	public void UseBluePin()
	{
		if (canSubmitAnswer && !GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			canSubmitAnswer = false;
			StartCoroutine(StartBluePinAnimation());
			if (CheckSolution())
			{
				StartCoroutine(WaitASecThenCompletePuzzle());
			}
		}
	}

	private IEnumerator WaitASecThenCompletePuzzle()
	{
		yield return new WaitForSeconds(1.5f);
		CompletePuzzle(true, true);
	}
}
