using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabletAppFileCloud : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CMathPositionMenu_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppFileCloud _003C_003E4__this;

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
		public _003CMathPositionMenu_003Ed__15(int _003C_003E1__state)
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

	public DataCloud dataCloud;

	public appExplorer appExplorer;

	public TabletAppFile tabletAppFile;

	[Header("Explorer Content")]
	public Transform ParentExplorerContent;

	public GameObject ItemExplorerContent;

	[Header("App Object")]
	public RectTransform menuLayout;

	public RectTransform closeLayout;

	public CanvasGroup canvasGroup;

	[HideInInspector]
	public FileSystemObject currentDirectory;

	public Camera mainCamera;

	private FileSystemObject fileItem;

	public void Render(FileSystemObject directory, bool isNetwork)
	{
	}

	private void ClearExplorerContent()
	{
	}

	public void OpenMenu(FileSystemObject item, PointerEventData eventData)
	{
	}

	public void ButtonMenuSaveToDevice()
	{
	}

	[IteratorStateMachine(typeof(_003CMathPositionMenu_003Ed__15))]
	private IEnumerator MathPositionMenu(PointerEventData eventData)
	{
		return null;
	}

	public void CloseMenu()
	{
	}
}
