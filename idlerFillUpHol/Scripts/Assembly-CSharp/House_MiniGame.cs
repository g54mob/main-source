using System.Collections.Generic;
using UnityEngine;

public class House_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Part2 = 2,
		Part3 = 3,
		Part4 = 4,
		Ending = 5
	}

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	public List<House_Button> Buttons;

	private bool _isSuccess;

	public bool AutoDevice;

	public bool IsSuccess
	{
		get
		{
			if (House.GlobalInfo.TotalEvilCount > 0 && AutoDevice)
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

	public void SetParent(House parent)
	{
		foreach (House_Button button in Buttons)
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
		foreach (House_Button button in Buttons)
		{
			button.SetColor(_mainColor);
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
			Buttons[0].Inactivate();
			Buttons[1].Inactivate();
			Buttons[2].Inactivate();
			Buttons[3].Inactivate();
			break;
		case StageEnum.Part1:
			Buttons[0].Activate();
			break;
		case StageEnum.Part2:
			Buttons[1].Activate();
			break;
		case StageEnum.Part3:
			Buttons[2].Activate();
			break;
		case StageEnum.Part4:
			Buttons[3].Activate();
			break;
		case StageEnum.Ending:
			if (Buttons[0].State == House_Button.StateEnum.Click && Buttons[1].State == House_Button.StateEnum.Click && Buttons[2].State == House_Button.StateEnum.Click && Buttons[3].State == House_Button.StateEnum.Click)
			{
				_isSuccess = true;
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_success);
			}
			break;
		}
	}
}
