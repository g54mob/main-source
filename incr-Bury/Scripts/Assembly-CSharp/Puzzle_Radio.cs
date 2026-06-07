using System;

public class Puzzle_Radio : BlackStarPuzzle
{
	private string solutionString = "rrllrlllrrl";

	private string[] altSolutions = new string[2] { "rrllrlllrlr", "rrllrllllrr" };

	public string enteredString = "";

	public override void Start()
	{
		base.Start();
		Radio radioInScene = GameManager.Singleton.radioInScene;
		radioInScene.Action_ButtonClicked_Center = (Action)Delegate.Combine(radioInScene.Action_ButtonClicked_Center, new Action(CenterButtonPressed));
		Radio radioInScene2 = GameManager.Singleton.radioInScene;
		radioInScene2.Action_ButtonClicked_Right = (Action)Delegate.Combine(radioInScene2.Action_ButtonClicked_Right, new Action(RightButtonPressed));
		Radio radioInScene3 = GameManager.Singleton.radioInScene;
		radioInScene3.Action_ButtonClicked_Left = (Action)Delegate.Combine(radioInScene3.Action_ButtonClicked_Left, new Action(LeftButtonPressed));
	}

	private void OnDestroy()
	{
		Radio radioInScene = GameManager.Singleton.radioInScene;
		radioInScene.Action_ButtonClicked_Center = (Action)Delegate.Remove(radioInScene.Action_ButtonClicked_Center, new Action(CenterButtonPressed));
		Radio radioInScene2 = GameManager.Singleton.radioInScene;
		radioInScene2.Action_ButtonClicked_Right = (Action)Delegate.Remove(radioInScene2.Action_ButtonClicked_Right, new Action(RightButtonPressed));
		Radio radioInScene3 = GameManager.Singleton.radioInScene;
		radioInScene3.Action_ButtonClicked_Left = (Action)Delegate.Remove(radioInScene3.Action_ButtonClicked_Left, new Action(LeftButtonPressed));
	}

	private void LeftButtonPressed()
	{
		if (!puzzleCompleted)
		{
			enteredString += "l";
			if (enteredString.Length > solutionString.Length)
			{
				enteredString = enteredString.Remove(0, 1);
			}
			if (enteredString.Length == solutionString.Length && CheckSolution())
			{
				CompletePuzzle(true, true);
			}
		}
	}

	private void RightButtonPressed()
	{
		if (!puzzleCompleted)
		{
			enteredString += "r";
			if (enteredString.Length > solutionString.Length)
			{
				enteredString = enteredString.Remove(0, 1);
			}
			if (enteredString.Length == solutionString.Length && CheckSolution())
			{
				CompletePuzzle(true, true);
			}
		}
	}

	private void CenterButtonPressed()
	{
		if (!puzzleCompleted)
		{
			ResetEnteredString();
		}
	}

	private bool CheckSolution()
	{
		if (enteredString == solutionString)
		{
			return true;
		}
		string[] array = altSolutions;
		foreach (string text in array)
		{
			if (enteredString == text)
			{
				return true;
			}
		}
		return false;
	}

	private void Update()
	{
	}

	public override void CompletePuzzle(bool _spawnOrb, bool _playSpawnSFX)
	{
		base.CompletePuzzle(_spawnOrb, _playSpawnSFX);
	}

	public void ResetEnteredString()
	{
		enteredString = "";
	}
}
