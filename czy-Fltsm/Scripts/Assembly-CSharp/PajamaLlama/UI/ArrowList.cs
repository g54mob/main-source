using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PajamaLlama.UI
{
	public class ArrowList : Selectable
	{
		[Header("Arrow List")]
		[SerializeField]
		private TextMeshProUGUI _label;

		[SerializeField]
		private TextMeshProUGUI _option;

		[SerializeField]
		[Tooltip("List of interactable that this components interactable state should be applied to")]
		private Selectable[] _relatedInteractables;

		[Header("Animator")]
		[SerializeField]
		private Animator _animator;

		[SerializeField]
		[Tooltip("[OPTIONAL] Will not trigger when left empty")]
		private string _triggerPrevious;

		[SerializeField]
		[Tooltip("[OPTIONAL] Will not trigger when left empty")]
		private string _triggerNext;

		[SerializeField]
		private string _firstOptionParameter = "FirstOption";

		[SerializeField]
		private string _lastOptionParameter = "LastOption";

		[Header("Events")]
		[SerializeField]
		private UnityEvent<int> _onValueChanged;

		private int _indexMax;

		private List<object> _options = new List<object>();

		public UnityEvent<int> OnValueChanged => _onValueChanged;

		public int Index { get; private set; } = -1;

		public void SetLabel(string text)
		{
			_label.text = text;
		}

		public void SetIndex(int index)
		{
			SetIndex(index, notify: true);
		}

		public void SetIndexWithoutNotify(int index)
		{
			SetIndex(_options.ClampIndex(index), notify: false);
		}

		public virtual void AddOptions(IEnumerable<object> options)
		{
			p_AddOptions(options);
		}

		public virtual void AddOptions(params object[] options)
		{
			if (options.Length == 1 && options[0] is IEnumerable<object> options2)
			{
				p_AddOptions(options2);
			}
			else
			{
				p_AddOptions(options);
			}
		}

		public void SetInteractable(bool interactable)
		{
			base.interactable = interactable;
			Selectable[] relatedInteractables = _relatedInteractables;
			for (int i = 0; i < relatedInteractables.Length; i++)
			{
				relatedInteractables[i].interactable = interactable;
			}
		}

		private void p_AddOptions(IEnumerable<object> options)
		{
			_options.Clear();
			_options.AddRange(options);
			OnOptionsAdded();
		}

		private void OnOptionsAdded()
		{
			_indexMax = _options.Count - 1;
			SetIndex(Mathf.Clamp(Index, 0, _indexMax), notify: false);
		}

		private void SetIndex(int index, bool notify)
		{
			if (Index != index)
			{
				Index = index;
				_option.text = _options[Index].ToString();
				if (notify && _onValueChanged != null)
				{
					_onValueChanged.Invoke(index);
				}
				if ((bool)base.animator)
				{
					_animator.SetBool(_firstOptionParameter, Index == 0);
					_animator.SetBool(_lastOptionParameter, Index == _indexMax);
				}
			}
		}

		private void SetAnimatorTrigger(string trigger)
		{
			if (!(_animator == null) && !string.IsNullOrWhiteSpace(trigger))
			{
				_animator.ResetTrigger(_triggerPrevious);
				_animator.ResetTrigger(_triggerNext);
				_animator.SetTrigger(trigger);
			}
		}

		public override void OnMove(AxisEventData eventData)
		{
			switch (eventData.moveDir)
			{
			case MoveDirection.Left:
				Previous();
				break;
			case MoveDirection.Right:
				Next();
				break;
			default:
				base.OnMove(eventData);
				break;
			}
		}

		public void Previous()
		{
			if (Index > 0 && base.interactable)
			{
				SetIndex(Index - 1);
				SetAnimatorTrigger(_triggerPrevious);
			}
		}

		public void Next()
		{
			if (Index < _indexMax && base.interactable)
			{
				SetIndex(Index + 1);
				SetAnimatorTrigger(_triggerNext);
			}
		}
	}
}
