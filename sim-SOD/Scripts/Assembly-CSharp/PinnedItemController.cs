using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PinnedItemController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
	public delegate void OnMove();

	[CompilerGenerated]
	private sealed class _003CIsOver_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PinnedItemController _003C_003E4__this;

		private bool _003Cselected_003E5__2;

		private float _003CquickMenuTimer_003E5__3;

		private bool _003CdeselectTimer_003E5__4;

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
		public _003CIsOver_003Ed__51(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CIsDragging_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PinnedItemController _003C_003E4__this;

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
		public _003CIsDragging_003Ed__52(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CRescale_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PinnedItemController _003C_003E4__this;

		public Vector3 size;

		private float _003Clen_003E5__2;

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
		public _003CRescale_003Ed__53(int _003C_003E1__state)
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

	public Case.CaseElement caseElement;

	public Evidence evidence;

	public EvidenceButtonController evidenceButton;

	public RectTransform newInfoIcon;

	public Image background;

	public TextMeshProUGUI titleText;

	public RectTransform rect;

	public RectTransform pinnedRect;

	public PinnedPinButtonController pinButtonController;

	public DragCasePanel dragController;

	public RectTransform crossedOut;

	public Rigidbody2D rb;

	public HingeJoint2D joint;

	public JuiceController juice;

	public ContextMenuController contextMenu;

	public TooltipController tooltip;

	public List<StringController> connectedStrings;

	public static PinnedQuickMenuController activeQuickMenu;

	public bool hideConnections;

	public Vector2 originalSize;

	public bool isOver;

	public bool isDragging;

	public bool isSelected;

	public bool permSelected;

	public bool pinPlaceActive;

	public float scalingSpeed;

	public Vector3 mouseOverScale;

	public Vector3 prevLocalPos;

	public List<string> debug;

	public static List<float> angleSteps;

	public bool minimized;

	public event OnMove OnMoved
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Setup(Case.CaseElement newElement)
	{
	}

	private void OnDestroy()
	{
	}

	public void SetPostion(Vector2 newPos)
	{
	}

	public void AutoPinPostion()
	{
	}

	public void OnMoveThis()
	{
	}

	public void VisualUpdate()
	{
	}

	public void UpdateNewInfoIcon()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void SetHovered(bool val)
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData data)
	{
	}

	public void ForceDrag()
	{
	}

	public void OnEndDrag(PointerEventData eventData)
	{
	}

	public void ForcePointerUp()
	{
	}

	[IteratorStateMachine(typeof(_003CIsOver_003Ed__51))]
	private IEnumerator IsOver()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CIsDragging_003Ed__52))]
	private IEnumerator IsDragging()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CRescale_003Ed__53))]
	private IEnumerator Rescale(Vector3 size)
	{
		return null;
	}

	public void SetSelected(bool val, bool permenantSelected)
	{
	}

	public void ChangeBaseColour(Color newBaseColour)
	{
	}

	public void UpdateTooltipText()
	{
	}

	public void ToggleHideChildren()
	{
	}

	public void HideConnections()
	{
	}

	public void ShowConnections()
	{
	}

	public void ToggleMinimize()
	{
	}

	public void Minimize()
	{
	}

	public void Restore()
	{
	}

	public void OpenEvidence()
	{
	}

	public void Unpin()
	{
	}

	public void Cancel()
	{
	}

	private void LateUpdate()
	{
	}

	public void UpdateContextMenuOptions()
	{
	}

	public void CreateCustomString()
	{
	}

	public void ForceCancelDrag()
	{
	}

	public void ToggleCrossedOut()
	{
	}

	public void PlotRoute()
	{
	}

	public void LocateOnMap()
	{
	}

	public void ToggleCollapse()
	{
	}

	public void NewStickyNote()
	{
	}

	public void MinimizeAll()
	{
	}

	public void PinAllLinks()
	{
	}

	public void UnpinAllLinks()
	{
	}

	public void SetColourRed()
	{
	}

	public void SetColourBlue()
	{
	}

	public void SetColourYellow()
	{
	}

	public void SetColourGreen()
	{
	}

	public void SetColourPurple()
	{
	}

	public void SetColourWhite()
	{
	}

	public void SetColourBlack()
	{
	}

	public void UpdatePulsate()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayEvidenceIdentifier()
	{
	}
}
