using System.Collections.Generic;
using UnityEngine;

public class Training_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Ending = 2
	}

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	public List<Training_Button> Buttons;

	private bool _isSuccess;

	private bool _previousPressed;

	private int _evilProgress;

	private int _evilMax = 5;

	public bool AutoDevice;

	public bool IsSuccess
	{
		get
		{
			if (Training.GlobalInfo.TotalEvilCount > 0 && AutoDevice)
			{
				return true;
			}
			return _isSuccess;
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetParent(Training parent)
	{
		foreach (Training_Button button in Buttons)
		{
			button.Parent = this;
		}
	}

	public void SetMainColor(Color color)
	{
		if (!(_mainColor != color))
		{
			return;
		}
		_mainColor = color;
		foreach (Training_Button button in Buttons)
		{
			_ = button;
		}
	}

	public void ChangeStage(StageEnum newStage)
	{
		if (_stage == newStage)
		{
			return;
		}
		_stage = newStage;
		_isSuccess = false;
		switch (_stage)
		{
		case StageEnum.None:
			_isSuccess = false;
			break;
		case StageEnum.Part1:
			_evilProgress = 0;
			break;
		case StageEnum.Ending:
			if (_evilProgress >= _evilMax)
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_success);
				_isSuccess = true;
				_evilMax += 5;
			}
			else
			{
				_evilMax = 5;
			}
			_evilProgress = 0;
			break;
		}
	}

	public float ProgressPercentage()
	{
		if (_evilProgress <= 0)
		{
			return 0f;
		}
		if (_evilProgress >= _evilMax)
		{
			return 1f;
		}
		return (float)_evilProgress / (float)_evilMax;
	}

	public bool ButtonPressed(bool isLeft)
	{
		if (_stage == StageEnum.Part1 && _previousPressed != isLeft)
		{
			_previousPressed = isLeft;
			_evilProgress++;
			return true;
		}
		return false;
	}
}
