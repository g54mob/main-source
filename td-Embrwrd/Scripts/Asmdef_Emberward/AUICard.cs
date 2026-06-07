using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class AUICard : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
	[CompilerGenerated]
	private sealed class _003CCR_DrawCardAnimation_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AUICard _003C_003E4__this;

		public Vector3 fromPos;

		public float duration;

		private Transform _003CanimTransform_003E5__2;

		private float _003Ctime_003E5__3;

		private float _003CflyHeight_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_DrawCardAnimation_003Ed__41(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("拖動後復原的速度")]
	[SerializeField]
	protected float dragRecoverSpeed;

	[SerializeField]
	protected Animator animator;

	[SerializeField]
	protected CanvasGroup canvasGroup;

	[SerializeField]
	protected TwoMouseButtonButton button;

	[SerializeField]
	private Transform node_Discard;

	protected CardController cardController;

	[SerializeField]
	protected eCardState cardState;

	protected CardData cardData;

	protected bool isDraggable;

	protected Vector2 mousePosition;

	protected Vector2 startPosition;

	protected Vector2 differencePoint;

	protected Vector3 dragStartLocalPosition;

	private PointerEventData dragPointerEventData;

	protected Vector3 cardPositionOffset;

	protected Transform tranformParent_CardList;

	protected int siblingIndexInCardList;

	protected bool isCorrupted;

	protected bool isBanned;

	private bool isDiscarding;

	private bool isMouseOver;

	private bool isCardInFocus;

	public CardData CardData => null;

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	public void DiscardCard()
	{
	}

	private void OnClickButton_Left()
	{
	}

	private void OnClickButton_Right()
	{
	}

	private void OnClickButton_RightKey()
	{
	}

	private void OnClickButton()
	{
	}

	protected virtual void OnClickButtonProc()
	{
	}

	private void OnGameStateChanged(eGameState fromState, eGameState toState)
	{
	}

	private void ToggleTransparent(bool isTransparent, float alpha)
	{
	}

	public void ToggleCorrupted(bool isCorrupted)
	{
	}

	public void ToggleBanned(bool isBanned)
	{
	}

	protected virtual void ToggleCorruptedProc(bool isCorrupted)
	{
	}

	protected virtual void ToggleBannedProc(bool isBanned)
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetupContent(CardData cardData, bool isDraggable)
	{
	}

	protected abstract void SetupContentProc(CardData cardData);

	public void PlayDrawCardAnimation(Vector3 fromPos, float duration)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DrawCardAnimation_003Ed__41))]
	private IEnumerator CR_DrawCardAnimation(Vector3 fromPos, float duration)
	{
		return null;
	}

	private void UpdateRecovering()
	{
	}

	public void UpdateCardPosition(bool isImmediate = false)
	{
	}

	public Vector3 GetTargetCardWorldPos()
	{
		return default(Vector3);
	}

	public void ShowCard()
	{
	}

	public void RemoveCard()
	{
	}

	protected void Initialize()
	{
	}

	protected void SwitchCardState(eCardState targetState)
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	protected abstract void DraggingOntoFieldProc();

	public void OnEndDrag(PointerEventData eventData)
	{
	}

	protected void EndDrag()
	{
	}

	protected abstract void EndDragProc();

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	protected virtual void OnPointerEnterProc()
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void SetCardInFocus(bool isInFocus)
	{
	}

	private void OnCardInFocusProc()
	{
	}

	private void OnCardLostFocusProc()
	{
	}

	protected virtual void OnPointerExitProc()
	{
	}

	public void SetDocked(bool isDocked, Transform dockTranform = null)
	{
	}

	public void SkipFlipAnimation()
	{
	}

	public void ToggleSelectedEffect(bool isOn)
	{
	}

	protected virtual void ToggleSelectedEffectProc(bool isOn)
	{
	}
}
