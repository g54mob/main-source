using System.Collections.Generic;
using UnityEngine;

public class Research_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Part2 = 2,
		Ending = 3
	}

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	public List<Research_Button> Buttons;

	private bool _isSuccess;

	private int _perfectCycles;

	public bool AutoDevice;

	public bool IsSuccess
	{
		get
		{
			if (Research.GlobalInfo.TotalEvilCount > 0 && AutoDevice)
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
		if (_stage == StageEnum.Part1 || _stage == StageEnum.Part2)
		{
			if (HasAllState())
			{
				_isSuccess = true;
			}
			{
				foreach (Research_Button button in Buttons)
				{
					button.SetEvilState(_isSuccess);
				}
				return;
			}
		}
		foreach (Research_Button button2 in Buttons)
		{
			button2.SetEvilState(isEvil: false);
		}
	}

	public void SetParent(Research parent)
	{
		foreach (Research_Button button in Buttons)
		{
			button.Parent = parent;
		}
	}

	public void SetMainColor(Color color)
	{
		if (!(_mainColor != color))
		{
			return;
		}
		_mainColor = color;
		foreach (Research_Button button in Buttons)
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
			NewCycle();
			break;
		case StageEnum.Part2:
			AllowUserInput();
			break;
		case StageEnum.Ending:
			if (HasAllState())
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_success);
				_isSuccess = true;
			}
			if (_isSuccess)
			{
				_perfectCycles++;
			}
			else
			{
				_perfectCycles = 0;
			}
			break;
		}
	}

	private bool HasAllState()
	{
		foreach (Research_Button button in Buttons)
		{
			if (!button.SameState())
			{
				return false;
			}
		}
		return true;
	}

	private void NewCycle()
	{
		foreach (Research_Button button in Buttons)
		{
			button.Lock();
			button.SetNullState();
			button.SetColor(_mainColor);
		}
		if (_perfectCycles >= 0)
		{
			Buttons[0].SetNewState(ignoreNull: true);
		}
		if (_perfectCycles >= 1)
		{
			Buttons[1].SetNewState();
		}
		if (_perfectCycles >= 2)
		{
			Buttons[2].SetNewState();
		}
		if (_perfectCycles >= 3)
		{
			Buttons[3].SetNewState();
		}
	}

	private void AllowUserInput()
	{
		foreach (Research_Button button in Buttons)
		{
			button.Unlock();
			button.ShowUserInput();
		}
	}
}
