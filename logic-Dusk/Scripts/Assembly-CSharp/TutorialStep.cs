using System;
using UnityEngine;

public class TutorialStep
{
	public Vector2 TextPosition;

	private Action _customAction;

	private Func<bool> _testForStepDone;

	private float _displayTimer;

	public string DisplayText { get; set; }

	public bool StepIsDone { get; private set; }

	public Color TextColor { get; set; }

	public Vector2 StartPosition { get; set; }

	public Vector2 EndPosition { get; set; }

	public float TotalMoveTime { get; set; }

	public bool AllowJumpAhead { get; private set; }

	public TutorialStep(string text, Vector2 textPosition, Color textColor, Func<bool> testForStepDone)
	{
		InitCustomTest(text, textPosition, textColor, testForStepDone, null, false);
	}

	public TutorialStep(string text, Vector2 textPosition, Color textColor, Func<bool> testForStepDone, bool allowJumpAhead)
	{
		InitCustomTest(text, textPosition, textColor, testForStepDone, null, allowJumpAhead);
	}

	public TutorialStep(string text, Vector2 textPosition, Color textColor, Func<bool> testForStepDone, Action customAction)
	{
		InitCustomTest(text, textPosition, textColor, testForStepDone, customAction, false);
	}

	public TutorialStep(string text, Vector2 textPosition, Color textColor, Func<bool> testForStepDone, Action customAction, bool allowJumpAhead)
	{
		InitCustomTest(text, textPosition, textColor, testForStepDone, customAction, allowJumpAhead);
	}

	public TutorialStep(string text, Vector2 startPosition, Vector2 endPosition, float totalMoveTime, Color textColor)
	{
		DisplayText = text;
		TextColor = textColor;
		StartPosition = startPosition;
		EndPosition = endPosition;
		TotalMoveTime = totalMoveTime;
		_displayTimer = totalMoveTime;
		_testForStepDone = delegate
		{
			if (!StepIsDone)
			{
				_displayTimer -= Time.deltaTime;
				if (_displayTimer <= 0f)
				{
					return true;
				}
				return false;
			}
			return true;
		};
	}

	public TutorialStep(string text, Vector2 textPosition, Color textColor, float timeDisplayed)
	{
		DisplayText = text;
		TextPosition = textPosition;
		_displayTimer = timeDisplayed;
		StepIsDone = false;
		TextColor = textColor;
		_testForStepDone = delegate
		{
			if (!StepIsDone)
			{
				_displayTimer -= Time.deltaTime;
				if (_displayTimer <= 0f)
				{
					return true;
				}
				return false;
			}
			return true;
		};
	}

	private void InitCustomTest(string text, Vector2 textPosition, Color textColor, Func<bool> testForStepDone, Action customAction, bool allowJumpAhead)
	{
		DisplayText = text;
		_testForStepDone = testForStepDone;
		_customAction = customAction;
		TextPosition = textPosition;
		TextColor = textColor;
		TotalMoveTime = 0f;
		AllowJumpAhead = allowJumpAhead;
	}

	public void StartStep()
	{
		GameAudio.Play2DSFX(GameAudio.SoundEnum.Hint);
		HintManager.PushTutorialHint(new BaseMessageHint(DisplayText, null));
	}

	public void EndStep()
	{
	}

	public void Update()
	{
		if (_testForStepDone == null)
		{
			Debug.LogError("TutorialStep, _testForStepDone not set!!!");
			StepIsDone = true;
			return;
		}
		StepIsDone = _testForStepDone();
		if (!StepIsDone && _customAction != null)
		{
			_customAction();
		}
	}

	public bool IsStepIsDone()
	{
		StepIsDone = _testForStepDone();
		return StepIsDone;
	}
}
