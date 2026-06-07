using System.Collections.Generic;
using UnityEngine;

public class Drone_Tower : MonoBehaviour
{
	public GameObject Bottom;

	public GameObject Middle;

	public GameObject Top;

	public GameObject Selection;

	public Sprite BarSmall;

	public Sprite BarMedium;

	public Sprite BarLarge;

	public Drone_MiniGame Parent;

	private int _towerIndex;

	private bool _isSelected;

	private List<int> _bars = new List<int>();

	private SpriteRenderer _renderer;

	public void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}

	private void FixedUpdate()
	{
		Helper.SetZForFocus(base.transform);
	}

	public void SetTowerIndex(int index)
	{
		_towerIndex = index;
	}

	public void ClearState()
	{
		_isSelected = false;
		_bars.Clear();
		DrawBars();
	}

	public void SetSelection(bool isSelected)
	{
		_isSelected = isSelected;
		DrawBars();
	}

	public void AddBar(int i)
	{
		_bars.Add(i);
		DrawBars();
	}

	public void RemoveBar()
	{
		if (_bars.Count > 0)
		{
			_bars.RemoveAt(_bars.Count - 1);
		}
		DrawBars();
	}

	public bool IsSelected()
	{
		return _isSelected;
	}

	public int GetTopBarIndex()
	{
		if (_bars.Count > 0)
		{
			return _bars[_bars.Count - 1];
		}
		return 0;
	}

	public bool IsValid()
	{
		if (_bars.Count == 3 && _bars[0] == 3 && _bars[1] == 2 && _bars[2] == 1)
		{
			return true;
		}
		return false;
	}

	private void DrawBars()
	{
		int selection = 0;
		int top = 0;
		int middle = 0;
		int bottom = 0;
		if (_bars.Count > 0)
		{
			int num = _bars.Count;
			if (_isSelected)
			{
				selection = _bars[_bars.Count - 1];
				num--;
			}
			if (num >= 1)
			{
				bottom = _bars[0];
			}
			if (num >= 2)
			{
				middle = _bars[1];
			}
			if (num >= 3)
			{
				top = _bars[2];
			}
		}
		SetTowerBar(top, middle, bottom, selection);
	}

	private void SetTowerBar(int top, int middle, int bottom, int selection)
	{
		if (selection == 0)
		{
			Selection.SetActive(value: false);
		}
		else
		{
			Selection.SetActive(value: true);
			if (selection == 1)
			{
				Selection.GetComponent<SpriteRenderer>().sprite = BarSmall;
			}
			if (selection == 2)
			{
				Selection.GetComponent<SpriteRenderer>().sprite = BarMedium;
			}
			if (selection == 3)
			{
				Selection.GetComponent<SpriteRenderer>().sprite = BarLarge;
			}
		}
		if (top == 0)
		{
			Top.SetActive(value: false);
		}
		else
		{
			Top.SetActive(value: true);
			if (top == 1)
			{
				Top.GetComponent<SpriteRenderer>().sprite = BarSmall;
			}
			if (top == 2)
			{
				Top.GetComponent<SpriteRenderer>().sprite = BarMedium;
			}
			if (top == 3)
			{
				Top.GetComponent<SpriteRenderer>().sprite = BarLarge;
			}
		}
		if (middle == 0)
		{
			Middle.SetActive(value: false);
		}
		else
		{
			Middle.SetActive(value: true);
			if (middle == 1)
			{
				Middle.GetComponent<SpriteRenderer>().sprite = BarSmall;
			}
			if (middle == 2)
			{
				Middle.GetComponent<SpriteRenderer>().sprite = BarMedium;
			}
			if (middle == 3)
			{
				Middle.GetComponent<SpriteRenderer>().sprite = BarLarge;
			}
		}
		if (bottom == 0)
		{
			Bottom.SetActive(value: false);
			return;
		}
		Bottom.SetActive(value: true);
		if (bottom == 1)
		{
			Bottom.GetComponent<SpriteRenderer>().sprite = BarSmall;
		}
		if (bottom == 2)
		{
			Bottom.GetComponent<SpriteRenderer>().sprite = BarMedium;
		}
		if (bottom == 3)
		{
			Bottom.GetComponent<SpriteRenderer>().sprite = BarLarge;
		}
	}

	public void ChangeColor(Color newColor)
	{
		Bottom.GetComponent<SpriteRenderer>().color = newColor;
		Middle.GetComponent<SpriteRenderer>().color = newColor;
		Top.GetComponent<SpriteRenderer>().color = newColor;
	}

	private void OnMouseOver()
	{
		if (Drone.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.yellow;
		}
	}

	private void OnMouseExit()
	{
		if (Drone.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.white;
		}
	}

	private void OnMouseDown()
	{
		if (!Sign.PreventEvent)
		{
			Parent.TowerClick(_towerIndex);
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_click);
		}
	}
}
