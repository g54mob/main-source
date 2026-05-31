using System.Collections.Generic;
using UnityEngine;

public class Power_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Ending = 2
	}

	public List<Power_Circle> Circles;

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	private bool _isSuccess;

	private int _currentGrid = -1;

	public bool AutoDevice;

	public bool IsSuccess
	{
		get
		{
			if (Power.GlobalInfo.TotalEvilCount > 0 && AutoDevice)
			{
				return true;
			}
			return _isSuccess;
		}
	}

	private void Start()
	{
		ChangeGrid();
	}

	private void Update()
	{
	}

	public void SetParent(Power parent)
	{
		foreach (Power_Circle circle in Circles)
		{
			circle.ParentPower = this;
		}
	}

	public void SetMainColor(Color color)
	{
		if (_mainColor != color)
		{
			_mainColor = color;
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
			Verify();
			break;
		case StageEnum.Part1:
			_isSuccess = false;
			ChangeGrid();
			break;
		case StageEnum.Ending:
			Verify();
			if (_isSuccess)
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_success);
			}
			break;
		}
	}

	private bool IsSolved()
	{
		bool result = true;
		if (_stage == StageEnum.Part1 || _stage == StageEnum.Ending)
		{
			for (int i = 0; i < 9; i++)
			{
				if (!Circles[i].IsMatch(Power_Circle.CircleGrid[_currentGrid][i]))
				{
					result = false;
				}
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	public void Verify()
	{
		_isSuccess = IsSolved();
		if (_isSuccess)
		{
			for (int i = 0; i < 9; i++)
			{
				Circles[i].GetComponent<SpriteRenderer>().color = GameController.EvilColor;
			}
		}
		else
		{
			for (int j = 0; j < 9; j++)
			{
				Circles[j].GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
	}

	private void ChangeGrid()
	{
		_currentGrid = Random.Range(0, Power_Circle.CircleGrid.Count);
		for (int i = 0; i < 9; i++)
		{
			Circles[i].SetForRandomFromInfo(Power_Circle.CircleGrid[_currentGrid][i]);
		}
		while (IsSolved())
		{
			_currentGrid = Random.Range(0, Power_Circle.CircleGrid.Count);
			for (int j = 0; j < 9; j++)
			{
				Circles[j].SetForRandomFromInfo(Power_Circle.CircleGrid[_currentGrid][j]);
			}
		}
		Verify();
	}
}
