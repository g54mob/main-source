using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_leftUIDelay_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UserInterface _003C_003E4__this;

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
		public _003C_leftUIDelay_003Ed__17(int _003C_003E1__state)
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

	private static UserInterface inst;

	public StandaloneInputModule inputModule;

	public GraphicRaycaster transformRaycast;

	[Header("Tool Strip")]
	public List<ToolBase> tools;

	private ToolBase tool;

	private ToolBase editTool;

	public bool overUI;

	private static List<RaycastResult> results;

	private static PointerEventData eventDataCurrentPosition;

	public static bool OverUI => false;

	private void Awake()
	{
	}

	public static void SetTool(ToolBase item)
	{
	}

	public static void SetTool(int i, bool singlular = true)
	{
	}

	public static int ToolID(ToolBase tool)
	{
		return 0;
	}

	public static ToolBase Tool(int id)
	{
		return null;
	}

	public static void LoadEdit(BaseComponent comp)
	{
	}

	public static void CloseEdit()
	{
	}

	public static void LeftUI()
	{
	}

	[IteratorStateMachine(typeof(_003C_leftUIDelay_003Ed__17))]
	private IEnumerator _leftUIDelay()
	{
		return null;
	}

	public static void EnteredUI()
	{
	}

	public static bool IsPointerOverUI()
	{
		return false;
	}
}
