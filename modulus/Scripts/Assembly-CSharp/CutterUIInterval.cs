using System;
using System.Collections.Generic;
using Events.Generic;
using Presentation.Shapes;
using Presentation.UI.OperatorUIs;
using Presentation.UI.OperatorUIs.InsideOperatorUIs;
using UnityEngine;

public class CutterUIInterval : MonoBehaviour
{
	private const int MaxCuts = 21;

	private const int MiddleCut = 10;

	[SerializeField]
	private MachineButton[] _cutIntervalButtons;

	[SerializeField]
	private CutterUICutsWidget _cutButtons;

	[Space]
	[SerializeField]
	private IntEvent _setIntervalButtonPressedEvent;

	public Action<IReadOnlyList<int>> OnCutsChanged;

	private readonly List<int> _cuts = new List<int>();

	private int _currentShapeWidth;

	private int _currentCutInterval;

	private CutterUI _parent;

	public IReadOnlyList<int> Cuts => _cuts;

	public bool HasCuts => _cuts.Count > 0;

	public int CutInterval => _currentCutInterval;

	public event Action<int, bool> OnCutHighlight;

	private void Awake()
	{
		for (int i = 0; i < _cutIntervalButtons.Length; i++)
		{
			_cutIntervalButtons[i].OnClick += OnCuttingIntervalClicked;
		}
		if (_cutButtons != null)
		{
			_cutButtons.Setup(SetCut, HighlightCut);
		}
	}

	private void OnDestroy()
	{
		for (int i = 0; i < _cutIntervalButtons.Length; i++)
		{
			_cutIntervalButtons[i].OnClick -= OnCuttingIntervalClicked;
		}
		if (_parent != null)
		{
			_parent.OnNewShapeEntered -= OnNewShapeEntered;
			_parent = null;
		}
	}

	public void Setup(CutterUI cutterUI)
	{
		_parent = cutterUI;
		_parent.OnNewShapeEntered += OnNewShapeEntered;
	}

	public void SetCutsConfig(List<int> cuts, int cutInterval, CutterUI cutterUI)
	{
		_cuts.Clear();
		if (cuts != null)
		{
			_cuts.AddRange(cuts);
		}
		if (_cutButtons != null)
		{
			_cutButtons.SetCuts(cuts);
		}
		for (int i = 0; i < _cutIntervalButtons.Length; i++)
		{
			_cutIntervalButtons[i].IsPressed = i == cutInterval - 1;
		}
		_currentCutInterval = cutInterval;
		if (cutterUI.InputShape != null)
		{
			OnNewShapeEntered(cutterUI.InputShape);
		}
		else
		{
			OnCutsChanged?.Invoke(_cuts);
		}
	}

	public void SetCuttingInterval(int interval, MachineButton machineButton)
	{
		_currentCutInterval = interval;
		for (int i = 0; i < _cutIntervalButtons.Length; i++)
		{
			_cutIntervalButtons[i].IsPressed = false;
		}
		machineButton.IsPressed = true;
		IntervalToCuts(interval, _currentShapeWidth, in _cuts);
		_setIntervalButtonPressedEvent.Fire(interval);
		if (_cutButtons != null)
		{
			_cutButtons.SetCuts(_cuts);
		}
		OnCutsChanged?.Invoke(_cuts);
	}

	public void OnCuttingIntervalClicked(int interval, MachineButton machineButton)
	{
		if (_currentCutInterval != interval)
		{
			SetCuttingInterval(interval, machineButton);
		}
	}

	public static void IntervalToCuts(int interval, int shapeWidth, in List<int> cuts)
	{
		cuts.Clear();
		for (int i = 0; i < 21; i++)
		{
			int num = i - 10;
			if ((num + shapeWidth / 2) % interval == 0)
			{
				cuts.Add(num);
			}
		}
	}

	public bool SetCut(int x)
	{
		_currentCutInterval = 0;
		for (int i = 0; i < _cutIntervalButtons.Length; i++)
		{
			_cutIntervalButtons[i].IsPressed = false;
		}
		bool num = !_cuts.Contains(x);
		if (num)
		{
			_cuts.Add(x);
		}
		else
		{
			_cuts.Remove(x);
		}
		Action<IReadOnlyList<int>> onCutsChanged = OnCutsChanged;
		if (onCutsChanged != null)
		{
			onCutsChanged(_cuts);
			return num;
		}
		return num;
	}

	private void HighlightCut(int index, bool toggle)
	{
		this.OnCutHighlight?.Invoke(index, toggle);
	}

	public void Reset()
	{
		for (int i = 0; i < _cutIntervalButtons.Length; i++)
		{
			_cutIntervalButtons[i].IsPressed = false;
		}
		_cuts.Clear();
		_currentCutInterval = 0;
		if (_cutButtons != null)
		{
			_cutButtons.Reset();
		}
		OnCutsChanged?.Invoke(_cuts);
	}

	private void OnNewShapeEntered(ShapeLoader shapeLoader)
	{
		_currentShapeWidth = shapeLoader.Shape.GetBounds().x;
		if (_cutButtons != null)
		{
			_cutButtons.OnShapeChanged(shapeLoader);
		}
		if (_currentCutInterval > 0)
		{
			SetCuttingInterval(_currentCutInterval, _cutIntervalButtons[_currentCutInterval - 1]);
			return;
		}
		RemoveCutsOutOfShapeBounds(shapeLoader, _cuts);
		OnCutsChanged?.Invoke(_cuts);
	}

	private void RemoveCutsOutOfShapeBounds(ShapeLoader shapeLoader, List<int> cuts)
	{
		for (int i = 0; i < cuts.Count; i++)
		{
			int num = cuts[i];
			int num2 = shapeLoader.Shape.GetBounds().x / -2 + 1;
			if (num < num2 || num >= shapeLoader.Shape.GetBounds().x + num2)
			{
				cuts.RemoveAt(i);
			}
		}
	}

	public void Hide()
	{
		if (_cutButtons != null)
		{
			_cutButtons.Hide();
		}
	}
}
