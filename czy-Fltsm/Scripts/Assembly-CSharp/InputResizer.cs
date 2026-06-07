using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputResizer : UIBehaviour
{
	[Serializable]
	public struct InputSize
	{
		public InputFlags InputFlags;

		public Vector2 Size;
	}

	public enum LayoutElementSetting
	{
		MinWidth = 0,
		MinHeight = 1,
		MinWidthAndHeight = 2,
		PreferredWidth = 3,
		PreferredHeight = 4,
		PreferredWidthAndHeight = 5
	}

	[SerializeField]
	private InputFlags _activeInputFlags;

	[SerializeField]
	private InputSize[] _inputSizes;

	[SerializeField]
	private LayoutElement _layoutElement;

	[SerializeField]
	[ConditionalHide("_layoutElement", true)]
	private LayoutElementSetting _layoutElementSetting;

	[Header("RectTransform")]
	[SerializeField]
	[ConditionalHide("_layoutElement", true, true)]
	private bool _horizontal;

	[SerializeField]
	[ConditionalHide("_layoutElement", true, true)]
	private bool _vertical;

	protected override void OnEnable()
	{
		base.OnEnable();
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		OnActiveInputUpdated();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	private void Resize()
	{
		InputSize[] inputSizes = _inputSizes;
		for (int i = 0; i < inputSizes.Length; i++)
		{
			InputSize inputSize = inputSizes[i];
			if ((inputSize.InputFlags & _activeInputFlags) != InputFlags.None)
			{
				if (ResizeLayoutElement(inputSize.Size))
				{
					_ = 1;
				}
				else
					ResizeRectTransform(inputSize.Size);
				break;
			}
		}
	}

	private bool ResizeLayoutElement(Vector2 size)
	{
		if (_layoutElement == null)
		{
			return false;
		}
		switch (_layoutElementSetting)
		{
		case LayoutElementSetting.MinWidth:
			_layoutElement.minWidth = size.x;
			break;
		case LayoutElementSetting.MinHeight:
			_layoutElement.minHeight = size.y;
			break;
		case LayoutElementSetting.MinWidthAndHeight:
			_layoutElement.minWidth = size.x;
			_layoutElement.minHeight = size.y;
			break;
		case LayoutElementSetting.PreferredWidth:
			_layoutElement.preferredWidth = size.x;
			break;
		case LayoutElementSetting.PreferredHeight:
			_layoutElement.preferredHeight = size.y;
			break;
		case LayoutElementSetting.PreferredWidthAndHeight:
			_layoutElement.preferredWidth = size.x;
			_layoutElement.preferredHeight = size.y;
			break;
		default:
			Debug.LogException(new NotImplementedException());
			return false;
		}
		return true;
	}

	private bool ResizeRectTransform(Vector2 size)
	{
		RectTransform rectTransform = base.transform as RectTransform;
		if (_horizontal)
		{
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
		}
		if (_vertical)
		{
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
		}
		return true;
	}

	private void OnActiveInputUpdated(GameEvent gameEvent = null)
	{
		InputFlags activeInput = FlotsamInputManager.ActiveInput;
		if (_activeInputFlags != activeInput)
		{
			_activeInputFlags = activeInput;
			Resize();
		}
	}
}
