using System.Collections.Generic;
using UnityEngine;

public class Industry_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Ending = 2
	}

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	public List<Industry_Switch> Switchs;

	private bool _isSuccess;

	private int _currentNumber = 1;

	public bool AutoDevice;

	public bool IsSuccess
	{
		get
		{
			if (Industry.GlobalInfo.TotalEvilCount > 0 && AutoDevice)
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
		if (_stage == StageEnum.Part1)
		{
			if (GetSwitchNumber() == _currentNumber && _currentNumber != 0)
			{
				_isSuccess = true;
			}
			else
			{
				_isSuccess = false;
			}
		}
	}

	public void SetParent(Industry parent)
	{
		foreach (Industry_Switch @switch in Switchs)
		{
			@switch.Parent = parent;
		}
	}

	public void SetMainColor(Color color)
	{
		if (!(_mainColor != color))
		{
			return;
		}
		_mainColor = color;
		foreach (Industry_Switch @switch in Switchs)
		{
			_ = @switch;
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
		case StageEnum.Ending:
			if (GetSwitchNumber() == _currentNumber)
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_success);
				_isSuccess = true;
				_currentNumber++;
				if (_currentNumber == 16)
				{
					_currentNumber = 0;
				}
			}
			else if (GetSwitchNumber() == 0)
			{
				_currentNumber = 1;
			}
			else
			{
				_currentNumber = 0;
			}
			break;
		case StageEnum.Part1:
			break;
		}
	}

	private int GetSwitchNumber()
	{
		int num = 0;
		if (Switchs[0].State == Industry_Switch.StateEnum.On)
		{
			num += 8;
		}
		if (Switchs[1].State == Industry_Switch.StateEnum.On)
		{
			num += 4;
		}
		if (Switchs[2].State == Industry_Switch.StateEnum.On)
		{
			num += 2;
		}
		if (Switchs[3].State == Industry_Switch.StateEnum.On)
		{
			num++;
		}
		return num;
	}
}
