using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HQFPSTemplate.UserInterface
{
	[ExecuteInEditMode]
	public abstract class UI_Slot : UserInterfaceBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
	{
		public enum State
		{
			Normal = 0,
			Highlighted = 1,
			Pressed = 2
		}

		[Serializable]
		public class Transition
		{
			public Color NormalColor = Color.grey;

			public Color HighlightedColor = Color.grey;

			public Color PressedColor = Color.grey;

			[Clamp(0.01f, 1f)]
			public float FadeDuration = 0.1f;
		}

		public Message<UI_Slot> Refresh = new Message<UI_Slot>();

		public Message<UI_Slot, PointerEventData> PointerDown = new Message<UI_Slot, PointerEventData>();

		public Message<UI_Slot, PointerEventData> PointerUp = new Message<UI_Slot, PointerEventData>();

		public Message<PointerEventData, UI_Slot> BeginDrag = new Message<PointerEventData, UI_Slot>();

		public Message<PointerEventData, UI_Slot> Drag = new Message<PointerEventData, UI_Slot>();

		public Message<PointerEventData, UI_Slot> EndDrag = new Message<PointerEventData, UI_Slot>();

		public Message<State> StateChanged = new Message<State>();

		[BHeader("General", true)]
		[SerializeField]
		protected Graphic _Graphic;

		[SerializeField]
		private Transition m_Transition;

		[SerializeField]
		private SoundPlayer m_PointerDownAudio;

		protected State m_State;

		private CanvasRenderer m_Renderer;

		protected bool m_Pressed;

		protected bool m_Selected;

		protected bool m_PointerHovering;

		public UI_ContainerInterface<UI_Slot> BaseParent { get; private set; }

		public virtual void Select()
		{
			m_Selected = true;
			RefreshState(m_State);
		}

		public virtual void Deselect()
		{
			m_Selected = false;
			RefreshState(m_PointerHovering ? State.Highlighted : State.Normal);
		}

		public virtual void OnPointerEnter(PointerEventData data)
		{
			m_PointerHovering = true;
			if (!m_Pressed)
			{
				RefreshState(State.Highlighted);
			}
		}

		public virtual void OnPointerDown(PointerEventData data)
		{
			if (data.button == PointerEventData.InputButton.Left)
			{
				m_Pressed = true;
				RefreshState(State.Pressed);
			}
			m_PointerDownAudio.Play2D();
			PointerDown.Send(this, data);
		}

		public virtual void OnPointerUp(PointerEventData data)
		{
			m_Pressed = false;
			UI_Slot uI_Slot = ((data.pointerCurrentRaycast.gameObject == null) ? null : data.pointerCurrentRaycast.gameObject.GetComponent<UI_Slot>());
			if (uI_Slot != null)
			{
				if (uI_Slot != this)
				{
					RefreshState(State.Normal);
				}
				else
				{
					RefreshState(State.Highlighted);
				}
			}
			else
			{
				RefreshState(State.Normal);
			}
			PointerUp.Send(this, data);
		}

		public virtual void OnPointerExit(PointerEventData data)
		{
			m_PointerHovering = false;
			if (!m_Pressed)
			{
				RefreshState(State.Normal);
			}
			else
			{
				RefreshState(State.Pressed);
			}
		}

		public void OnBeginDrag(PointerEventData data)
		{
			BeginDrag.Send(data, this);
		}

		public void OnDrag(PointerEventData data)
		{
			Drag.Send(data, this);
		}

		public void OnEndDrag(PointerEventData data)
		{
			EndDrag.Send(data, this);
		}

		protected virtual void Awake()
		{
			if (Application.isPlaying)
			{
				m_Renderer = GetComponent<CanvasRenderer>();
				BaseParent = GetComponentInParent<UI_ContainerInterface<UI_Slot>>();
			}
		}

		protected virtual void OnEnable()
		{
			if (_Graphic == null)
			{
				_Graphic = GetComponent<Graphic>();
			}
			if (m_Transition == null)
			{
				m_Transition = new Transition();
			}
			OnValidate();
		}

		protected virtual void OnDisable()
		{
			CanvasRenderer canvasRenderer = ((m_Renderer == null) ? GetComponent<CanvasRenderer>() : m_Renderer);
			if (canvasRenderer != null)
			{
				canvasRenderer.SetColor(Color.white);
			}
		}

		protected virtual void OnDestroy()
		{
			CanvasRenderer canvasRenderer = ((m_Renderer == null) ? GetComponent<CanvasRenderer>() : m_Renderer);
			if (canvasRenderer != null)
			{
				canvasRenderer.SetColor(Color.white);
			}
		}

		protected virtual void OnValidate()
		{
			CanvasRenderer canvasRenderer = ((m_Renderer == null) ? GetComponent<CanvasRenderer>() : m_Renderer);
			if (canvasRenderer != null)
			{
				canvasRenderer.SetColor(m_Transition.NormalColor);
			}
		}

		private void RefreshState(State state)
		{
			m_State = state;
			Color targetColor = m_Transition.NormalColor;
			switch (state)
			{
			case State.Highlighted:
				targetColor = m_Transition.HighlightedColor;
				break;
			case State.Pressed:
				targetColor = m_Transition.PressedColor;
				break;
			}
			if (m_Selected)
			{
				targetColor = m_Transition.HighlightedColor;
			}
			_Graphic.CrossFadeColor(targetColor, m_Transition.FadeDuration, ignoreTimeScale: true, useAlpha: true);
			StateChanged.Send(m_State);
		}
	}
}
