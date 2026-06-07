using System;
using System.Collections.Generic;
using System.Linq;
using Dhs5.Utility.Settings;
using Dhs5.Utility.Updates;
using FMODUnity;
using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator
{
	public class InteractableNavElement : UINavElement, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICancelHandler, ITooltipDisplayer, IPointerEnterHandler, IPointerExitHandler
	{
		[Header("Interactable")]
		[SerializeField]
		private List<Graphic> m_selectionGraphics;

		[SerializeField]
		private List<Selectable> m_childSelectables;

		[SerializeField]
		private List<Transitioner> m_transitioners;

		[SerializeField]
		private bool m_submitOnSelectt;

		[Header("Tooltip")]
		[SerializeField]
		private Graphic m_tooltipGraphic;

		[SerializeField]
		private bool m_hasTooltip;

		[SerializeField]
		[TermsPopup("")]
		private string m_tooltipTerm;

		private DelayedCallHandle m_submitDelay;

		private Transitioner.ESelectionState m_previousState;

		public RectTransform RectTransform
		{
			get
			{
				if (!m_tooltipGraphic)
				{
					return null;
				}
				return m_tooltipGraphic.rectTransform;
			}
		}

		public Transitioner.ESelectionState CurrentState { get; private set; } = Transitioner.ESelectionState.None;

		public event Action SubmitEvent;

		protected override void OnDisable()
		{
			base.OnDisable();
			m_submitDelay.Kill();
		}

		protected virtual IEnumerable<Selectable> GetChildSelectables()
		{
			foreach (Selectable childSelectable in m_childSelectables)
			{
				if (childSelectable != null)
				{
					yield return childSelectable;
				}
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			TooltipManager.PrepareTooltip(this);
			CursorManager.StackState(MenuSettings.HoverCursor);
			foreach (Selectable childSelectable in GetChildSelectables())
			{
				childSelectable.OnPointerEnter(eventData);
			}
			if (base.Selected)
			{
				DoStateTransition(SelectionState.Selected, instant: false);
			}
			PlayAudio(SelectionState.Highlighted);
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			if (base.PointerOver)
			{
				CursorManager.PopCurrent();
			}
			base.OnPointerExit(eventData);
			TooltipManager.CancelTooltip(this);
			foreach (Selectable childSelectable in GetChildSelectables())
			{
				childSelectable.OnPointerExit(eventData);
			}
			if (base.Selected)
			{
				DoStateTransition(SelectionState.Selected, instant: false);
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			foreach (Selectable childSelectable in GetChildSelectables())
			{
				childSelectable.OnPointerDown(eventData);
			}
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			foreach (Selectable childSelectable in GetChildSelectables())
			{
				childSelectable.OnPointerUp(eventData);
			}
		}

		public void AppendTooltip(ITooltipDisplayer tooltipDisplayer)
		{
			TooltipManager.TryAppendTooltip(tooltipDisplayer);
		}

		public void CancelAllTooltips()
		{
			TooltipManager.CancelAllTooltips();
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			TooltipManager.PrepareTooltip(this);
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
			{
				foreach (Graphic selectionGraphic in m_selectionGraphics)
				{
					selectionGraphic.enabled = true;
				}
				PlayAudio(SelectionState.Highlighted);
			}
			if (m_submitOnSelectt)
			{
				OnSubmit(eventData);
			}
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			TooltipManager.CancelTooltip(this);
			foreach (Graphic selectionGraphic in m_selectionGraphics)
			{
				selectionGraphic.enabled = false;
			}
			foreach (Selectable childSelectable in GetChildSelectables())
			{
				childSelectable.OnDeselect(eventData);
			}
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
			Transitioner.ESelectionState selectionState = GetSelectionState();
			if (selectionState == CurrentState)
			{
				return;
			}
			CurrentState = selectionState;
			foreach (Transitioner transitioner in m_transitioners)
			{
				if (transitioner != null)
				{
					transitioner.DoTransition(selectionState, instant);
				}
			}
		}

		protected void OverrideTransition(Transitioner.ESelectionState newState, bool instant)
		{
			CurrentState = newState;
			foreach (Transitioner transitioner in m_transitioners)
			{
				if (transitioner != null)
				{
					transitioner.DoTransition(newState, instant);
				}
			}
		}

		private void PlayAudio(SelectionState state)
		{
			EventReference eventReference;
			switch (state)
			{
			case SelectionState.Highlighted:
				eventReference = CustomSettings<UiAudioSettings>.I.Highlighted;
				break;
			case SelectionState.Pressed:
				eventReference = CustomSettings<UiAudioSettings>.I.Pressed;
				break;
			case SelectionState.Normal:
			case SelectionState.Disabled:
				return;
			default:
				throw new ArgumentOutOfRangeException("state", state, null);
			}
			AudioManager.PlaySingleEvent(eventReference);
		}

		protected virtual Transitioner.ESelectionState GetSelectionState()
		{
			if (!base.interactable)
			{
				return Transitioner.ESelectionState.Disabled;
			}
			if (base.PointerDown)
			{
				return Transitioner.ESelectionState.Pressed;
			}
			if (base.PointerOver)
			{
				return Transitioner.ESelectionState.Highlighted;
			}
			if (base.Selected)
			{
				return Transitioner.ESelectionState.Selected;
			}
			return Transitioner.ESelectionState.Normal;
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			foreach (Selectable childSelectable in GetChildSelectables())
			{
				if (childSelectable is IPointerClickHandler pointerClickHandler)
				{
					pointerClickHandler.OnPointerClick(eventData);
				}
			}
			PlayAudio(SelectionState.Pressed);
		}

		public virtual void OnSubmit(BaseEventData eventData)
		{
			foreach (Selectable childSelectable in GetChildSelectables())
			{
				if (childSelectable is ISubmitHandler submitHandler)
				{
					submitHandler.OnSubmit(eventData);
				}
			}
			this.SubmitEvent?.Invoke();
			PlayAudio(SelectionState.Pressed);
			m_previousState = CurrentState;
			OverrideTransition(Transitioner.ESelectionState.Pressed, instant: false);
			Updater.CallInXSeconds(0.05f, GoHighlightedState, out m_submitDelay);
		}

		private void GoHighlightedState()
		{
			OverrideTransition(m_previousState, instant: false);
		}

		public virtual void OnCancel(BaseEventData eventData)
		{
			foreach (Selectable childSelectable in GetChildSelectables())
			{
				if (childSelectable is ICancelHandler cancelHandler)
				{
					cancelHandler.OnCancel(eventData);
					if (eventData.used)
					{
						return;
					}
				}
			}
			if (base.Parent != null)
			{
				base.Parent.OnChildCancel();
			}
		}

		public bool TryGetTooltipTerm(out string tooltipTerm)
		{
			tooltipTerm = m_tooltipTerm;
			return m_hasTooltip;
		}

		public void SetTooltipTerm(string term)
		{
			m_tooltipTerm = term;
		}

		public void FindTransitioners()
		{
			m_transitioners = new List<Transitioner>(GetComponentsInChildren<Transitioner>().ToList());
		}
	}
}
