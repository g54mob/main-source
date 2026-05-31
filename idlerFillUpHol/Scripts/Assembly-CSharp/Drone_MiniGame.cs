using UnityEngine;

public class Drone_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Ending = 2
	}

	public Drone_Tower Tower1;

	public Drone_Tower Tower2;

	public Drone_Tower Tower3;

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	private bool _isSuccess;

	public bool AutoDevice;

	private int _lastIndex = -1;

	public bool IsSuccess
	{
		get
		{
			if (Drone.GlobalInfo.TotalEvilCount > 0 && AutoDevice)
			{
				return true;
			}
			return _isSuccess;
		}
	}

	private void Start()
	{
		Tower1.ClearState();
		Tower2.ClearState();
		Tower3.ClearState();
	}

	private void Update()
	{
		if (Tower3.IsValid())
		{
			Tower1.ChangeColor(GameController.EvilColor);
			Tower2.ChangeColor(GameController.EvilColor);
			Tower3.ChangeColor(GameController.EvilColor);
		}
		else
		{
			Tower1.ChangeColor(Color.white);
			Tower2.ChangeColor(Color.white);
			Tower3.ChangeColor(Color.white);
		}
	}

	public void SetParent(Drone parent)
	{
		Tower1.Parent = this;
		Tower2.Parent = this;
		Tower3.Parent = this;
		Tower1.SetTowerIndex(0);
		Tower2.SetTowerIndex(1);
		Tower3.SetTowerIndex(2);
	}

	public void TowerClick(int index)
	{
		if (_stage != StageEnum.Part1)
		{
			return;
		}
		if (_lastIndex == -1)
		{
			int num = 0;
			if (index == 0)
			{
				num = Tower1.GetTopBarIndex();
			}
			if (index == 1)
			{
				num = Tower2.GetTopBarIndex();
			}
			if (index == 2)
			{
				num = Tower3.GetTopBarIndex();
			}
			if (num > 0)
			{
				_lastIndex = index;
				if (index == 0)
				{
					Tower1.SetSelection(isSelected: true);
				}
				if (index == 1)
				{
					Tower2.SetSelection(isSelected: true);
				}
				if (index == 2)
				{
					Tower3.SetSelection(isSelected: true);
				}
			}
			return;
		}
		int num2 = 0;
		Tower1.SetSelection(isSelected: false);
		Tower2.SetSelection(isSelected: false);
		Tower3.SetSelection(isSelected: false);
		if (_lastIndex == 0)
		{
			num2 = Tower1.GetTopBarIndex();
		}
		if (_lastIndex == 1)
		{
			num2 = Tower2.GetTopBarIndex();
		}
		if (_lastIndex == 2)
		{
			num2 = Tower3.GetTopBarIndex();
		}
		int num3 = 0;
		if (index == 0)
		{
			num3 = Tower1.GetTopBarIndex();
		}
		if (index == 1)
		{
			num3 = Tower2.GetTopBarIndex();
		}
		if (index == 2)
		{
			num3 = Tower3.GetTopBarIndex();
		}
		if (num3 == 0 || num3 > num2)
		{
			if (_lastIndex == 0)
			{
				Tower1.RemoveBar();
			}
			if (_lastIndex == 1)
			{
				Tower2.RemoveBar();
			}
			if (_lastIndex == 2)
			{
				Tower3.RemoveBar();
			}
			if (index == 0)
			{
				Tower1.AddBar(num2);
			}
			if (index == 1)
			{
				Tower2.AddBar(num2);
			}
			if (index == 2)
			{
				Tower3.AddBar(num2);
			}
		}
		_lastIndex = -1;
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
			_lastIndex = -1;
			Tower1.ClearState();
			Tower2.ClearState();
			Tower3.ClearState();
			break;
		case StageEnum.Part1:
		{
			_lastIndex = -1;
			Tower1.ClearState();
			Tower2.ClearState();
			Tower3.ClearState();
			for (int i = 1; i < 4; i++)
			{
				int num = Random.Range(1, 4);
				if (num == 1)
				{
					Tower1.AddBar(i);
				}
				if (num == 2)
				{
					Tower2.AddBar(i);
				}
				if (num == 3)
				{
					Tower3.AddBar(i);
				}
			}
			while (Tower3.IsValid())
			{
				Tower1.ClearState();
				Tower2.ClearState();
				Tower3.ClearState();
				for (int j = 1; j < 3; j++)
				{
					int num2 = Random.Range(1, 4);
					if (num2 == 1)
					{
						Tower1.AddBar(j);
					}
					if (num2 == 2)
					{
						Tower1.AddBar(j);
					}
					if (num2 == 3)
					{
						Tower1.AddBar(j);
					}
				}
			}
			break;
		}
		case StageEnum.Ending:
			if (Tower3.IsValid())
			{
				_isSuccess = true;
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_success);
			}
			_lastIndex = -1;
			Tower1.ClearState();
			Tower2.ClearState();
			Tower3.ClearState();
			break;
		}
	}
}
