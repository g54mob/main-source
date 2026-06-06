using System;
using UnityEngine;
using UnityEngine.UI;

public class GraphicStates : MonoBehaviour
{
	[Serializable]
	public class State
	{
		[GraphicStates]
		public string Name;

		public Color Color = Color.white;

		public Sprite Sprite;
	}

	[SerializeField]
	private Graphic _targetGraphic;

	[SerializeField]
	[HideInInspector]
	private Image _targetImage;

	[SerializeField]
	private State[] _states;

	private string _currentStateName;

	private void OnValidate()
	{
		if (_targetGraphic == null)
		{
			_targetGraphic = GetComponent<Graphic>();
		}
		_targetImage = _targetGraphic as Image;
	}

	public void SetState(string stateName)
	{
		if (_targetGraphic == null || _currentStateName == stateName)
		{
			return;
		}
		State[] states = _states;
		foreach (State state in states)
		{
			if (state.Name == stateName)
			{
				_targetGraphic.color = state.Color;
				if ((bool)_targetImage)
				{
					_targetImage.overrideSprite = state.Sprite;
				}
				_currentStateName = stateName;
				break;
			}
		}
	}

	public void PreviewState(string stateName, bool propagate)
	{
		if (propagate)
		{
			GetComponentInParent<IGraphicStatesProvider>()?.PreviewState(stateName);
		}
		else
		{
			SetState(stateName);
		}
	}

	public bool TryGetStates(out string[] states, out int index, string state = null)
	{
		states = GetComponentInParent<IGraphicStatesProvider>(includeInactive: true)?.States;
		index = 0;
		if (states.IsNullOrEmpty())
		{
			return false;
		}
		while (index < states.Length)
		{
			if (states[index] == state)
			{
				return true;
			}
			index++;
		}
		index = 0;
		return true;
	}
}
