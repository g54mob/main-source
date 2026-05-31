using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComputerDesktopAppAdapter : MonoBehaviour, IPointerUpHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class _003CMathPositionMenu_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerDesktopAppAdapter _003C_003E4__this;

		public PointerEventData eventData;

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
		public _003CMathPositionMenu_003Ed__14(int _003C_003E1__state)
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

	[Header("Component")]
	public AppBase appBase;

	public appExplorerOpenApps appExplorerOpenApps;

	public AppProperties appProperties;

	[Header("File System Object")]
	public FileSystemObject fileSystemObject;

	[Header("UI")]
	public RectTransform menuLayout;

	public RectTransform closeLayout;

	public CanvasGroup canvasGroup;

	private Camera mainCamera;

	private void Start()
	{
	}

	public void ButtonOpen()
	{
	}

	public void ButtonOpenPropertie()
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void ButtonOpenMenu(PointerEventData eventData)
	{
	}

	public void CloseMenu()
	{
	}

	[IteratorStateMachine(typeof(_003CMathPositionMenu_003Ed__14))]
	private IEnumerator MathPositionMenu(PointerEventData eventData)
	{
		return null;
	}

	private bool viewOpenMenu()
	{
		return false;
	}
}
