using System;
using System.Collections.Generic;
using Data.FactoryFloor.Freighter.Actions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI.Freighters
{
	public class FreighterActionCycleButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private Image _background;

		[SerializeField]
		private Image _fakeShadow;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TextInfoPanelContent _infoPanel;

		private IReadOnlyList<FreighterSlotAction> _freighterSlotActions;

		private int _value;

		public Action<int> OnActionChanged = delegate
		{
		};

		public int Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
				SetActionUI();
				OnActionChanged(_value);
			}
		}

		public void Setup(IReadOnlyList<FreighterSlotAction> actionUIDatas)
		{
			_freighterSlotActions = actionUIDatas;
			Value = 0;
		}

		public void SetValueWithoutNotify(int value)
		{
			_value = value;
			SetActionUI();
		}

		private void SetActionUI()
		{
			_background.color = _freighterSlotActions[_value].Color;
			_fakeShadow.color = _freighterSlotActions[_value].ColorVariant;
			_icon.sprite = _freighterSlotActions[_value].Icon;
			_infoPanel.UpdateContent(_freighterSlotActions[_value].LocalizedName);
			_infoPanel.ForceUpdate();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				Value = (Value + 1) % _freighterSlotActions.Count;
			}
			else if (eventData.button == PointerEventData.InputButton.Right)
			{
				Value = (Value - 1 + _freighterSlotActions.Count) % _freighterSlotActions.Count;
			}
		}
	}
}
