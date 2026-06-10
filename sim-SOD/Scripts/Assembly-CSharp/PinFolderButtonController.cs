using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class PinFolderButtonController : ButtonController, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[CompilerGenerated]
	private sealed class _003CPlacementFade_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PinFolderButtonController _003C_003E4__this;

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
		public _003CPlacementFade_003Ed__15(int _003C_003E1__state)
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

	public Sprite pinnedImage;

	public Sprite pinnedMO;

	public Sprite unpinnedImage;

	public Sprite unpinnedMO;

	public Sprite pinnedColour;

	public Sprite unpinnedColour;

	public ContextMenuController contextMenu;

	public bool placementActive;

	public bool pointerDown;

	private void Start()
	{
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnCreateNewCasePopup()
	{
	}

	public void onCreateNewCasePopupCancel()
	{
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
	}

	public void ForcePointerUp()
	{
	}

	[IteratorStateMachine(typeof(_003CPlacementFade_003Ed__15))]
	private IEnumerator PlacementFade()
	{
		return null;
	}

	public override void OnLeftClick()
	{
	}

	public override void OnHoverStart()
	{
	}

	public override void OnHoverEnd()
	{
	}

	public override void VisualUpdate()
	{
	}
}
