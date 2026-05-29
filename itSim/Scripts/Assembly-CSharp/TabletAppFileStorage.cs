using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabletAppFileStorage : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CMathPositionMenu_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppFileStorage _003C_003E4__this;

		public string storageMode;

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
		public _003CMathPositionMenu_003Ed__20(int _003C_003E1__state)
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

	public TabletAppFile tabletAppFile;

	public appExplorer appExplorer;

	[Header("Explorer Content")]
	public Transform ParentExplorerContentStorage;

	public Transform ParentExplorerContentDeleted;

	public GameObject ItemExplorerContent;

	[Header("App Object")]
	public RectTransform menuLayout;

	public RectTransform closeLayout;

	public CanvasGroup canvasGroup;

	[Header("UI")]
	public RectTransform ConfirmationOfDeletionWindow;

	public TMP_Text ConfirmationOfDeletionWindowInfo;

	[HideInInspector]
	public FileSystemObject currentDirectory;

	public Camera mainCamera;

	private FileSystemObject fileItem;

	public void RenderStorage(FileSystemObject directory)
	{
	}

	public void RenderDeleted(FileSystemObject directory, bool isNetwork)
	{
	}

	private void ClearExplorerContent()
	{
	}

	public void OpenMenu(FileSystemObject item, PointerEventData eventData, string storageMode)
	{
	}

	public void ButtonMenuMoveToTrash()
	{
	}

	public void ButtonMenuDelete()
	{
	}

	public void ButtonMenuDeleteConfirm()
	{
	}

	[IteratorStateMachine(typeof(_003CMathPositionMenu_003Ed__20))]
	private IEnumerator MathPositionMenu(PointerEventData eventData, string storageMode)
	{
		return null;
	}

	public void CloseMenu()
	{
	}
}
