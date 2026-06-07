using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class appExplorerMenu : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CMathPositionMenu_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public appExplorerMenu _003C_003E4__this;

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
		public _003CMathPositionMenu_003Ed__31(int _003C_003E1__state)
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

	public appExplorer appExplorer;

	public ComputerDesktop computerDesktop;

	public AppProperties appProperties;

	public DataCloud dataCloud;

	private FileSystemObject cutItem;

	private FileSystemObject copyItem;

	[Header("App Object")]
	public RectTransform menuLayout;

	public RectTransform closeLayout;

	public Image openIcon;

	public Canvas canvas;

	public CanvasGroup canvasGroup;

	[Header("Menu Element List")]
	public RectTransform ElementOpen;

	public RectTransform ElementSendToColud;

	public RectTransform ElementNew;

	public RectTransform ElementDelete;

	public RectTransform ElementCut;

	public RectTransform ElementCopy;

	public RectTransform ElementPasteItem;

	public RectTransform ElementPasteViewport;

	public RectTransform ElementRename;

	public RectTransform ElementProperties;

	[Header("Menu Element List")]
	public RectTransform CreateFileMenu;

	private Camera mainCamera;

	public appExplorerItemAdapter appExplorerItemAdapter;

	public FileSystemObject appExplorerItem;

	private bool cutFromDesktop;

	public bool openPropertieFromAdapter;

	public bool isCut(FileSystemObject item)
	{
		return false;
	}

	public FileSystemObject getCut()
	{
		return null;
	}

	private void Start()
	{
	}

	public void OpenMenu(FileSystemObject item, appExplorerItemAdapter appExplorerItemAdapter, PointerEventData eventData)
	{
	}

	public void OpenMenuOnBackground(FileSystemObject item, PointerEventData eventData)
	{
	}

	[IteratorStateMachine(typeof(_003CMathPositionMenu_003Ed__31))]
	private IEnumerator MathPositionMenu(PointerEventData eventData)
	{
		return null;
	}

	public void CloseMenu()
	{
	}

	public void ButtonOpen()
	{
	}

	public void ButtonSendToCloud()
	{
	}

	public void ButtonDelete()
	{
	}

	public void ButtonCut()
	{
	}

	public void ButtonPaste()
	{
	}

	public void ButtonPasteViewport()
	{
	}

	public void ClearCopyCutItem()
	{
	}

	public void ButtonCopy()
	{
	}

	public void ButtonRename()
	{
	}

	public void ButtonPropertie()
	{
	}

	public void ButtonNew()
	{
	}

	public void ButtonCreateDirectory()
	{
	}

	public void ButtonCreateTextDocument()
	{
	}

	public void UpdateComputerDesktop()
	{
	}
}
