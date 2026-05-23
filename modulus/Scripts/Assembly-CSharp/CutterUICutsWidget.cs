using System;
using System.Collections.Generic;
using Presentation.Shapes;
using Presentation.UI.OperatorUIs;
using UnityEngine;

public class CutterUICutsWidget : MonoBehaviour
{
	[SerializeField]
	private CutLineMachineButton[] _cutButtons;

	private Func<int, bool> _changeCut;

	private Action[] _onCutStartHighlightHandlers;

	private Action[] _onCutEndHighlightHandlers;

	private event Action<int, bool> _onCutHighlight;

	private void Awake()
	{
		CutLineMachineButton[] cutButtons = _cutButtons;
		foreach (CutLineMachineButton obj in cutButtons)
		{
			obj.Interactable = false;
			obj.OnClick += OnCutButtonClicked;
		}
	}

	private void OnDestroy()
	{
		CutLineMachineButton[] cutButtons = _cutButtons;
		for (int i = 0; i < cutButtons.Length; i++)
		{
			cutButtons[i].OnClick -= OnCutButtonClicked;
		}
	}

	public void Setup(Func<int, bool> ChangeCut, Action<int, bool> OnCutHighlight)
	{
		_changeCut = ChangeCut;
		this._onCutHighlight = OnCutHighlight;
		_onCutStartHighlightHandlers = new Action[_cutButtons.Length];
		_onCutEndHighlightHandlers = new Action[_cutButtons.Length];
		for (int i = 0; i < _cutButtons.Length; i++)
		{
			int index = i;
			_onCutStartHighlightHandlers[i] = delegate
			{
				this._onCutHighlight(index, arg2: true);
			};
			_onCutEndHighlightHandlers[i] = delegate
			{
				this._onCutHighlight(index, arg2: false);
			};
			_cutButtons[i].OnHoverStart += _onCutStartHighlightHandlers[i];
			_cutButtons[i].OnHoverEnd += _onCutEndHighlightHandlers[i];
		}
	}

	public void Reset()
	{
		CutLineMachineButton[] cutButtons = _cutButtons;
		for (int i = 0; i < cutButtons.Length; i++)
		{
			cutButtons[i].IsPressed = false;
		}
	}

	public void SetCuts(List<int> cuts)
	{
		if (cuts == null)
		{
			Reset();
			return;
		}
		CutLineMachineButton[] cutButtons = _cutButtons;
		foreach (MachineButton machineButton in cutButtons)
		{
			machineButton.IsPressed = cuts.Contains(machineButton.ClickParam);
		}
	}

	public void OnShapeChanged(ShapeLoader shapeLoader)
	{
		Vector3Int bounds = shapeLoader.Shape.GetBounds();
		int num = -bounds.x / 2;
		int num2 = num + bounds.x;
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < _cutButtons.Length; i++)
		{
			bool flag3 = _cutButtons[i].ClickParam > num && _cutButtons[i].ClickParam < num2;
			if (!flag2 && _cutButtons[i].transform.parent.gameObject.activeSelf)
			{
				flag2 = true;
				_cutButtons[i].IsFirstButton = true;
			}
			else
			{
				_cutButtons[i].IsFirstButton = false;
			}
			if (flag3 && !flag)
			{
				flag = true;
				_cutButtons[i].IsFirstActiveButton = true;
			}
			else
			{
				_cutButtons[i].IsFirstActiveButton = false;
			}
			_cutButtons[i].Interactable = flag3;
		}
	}

	private void OnCutButtonClicked(int x, MachineButton button)
	{
		bool isPressed = _changeCut != null && _changeCut(x);
		button.IsPressed = isPressed;
	}

	public void Hide()
	{
		for (int i = 0; i < _cutButtons.Length; i++)
		{
			_onCutEndHighlightHandlers[i]();
		}
	}
}
