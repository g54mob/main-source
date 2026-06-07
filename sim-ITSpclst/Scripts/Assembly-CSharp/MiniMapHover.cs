using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapHover : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRefreshBufferTextureTask_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MiniMapHover _003C_003E4__this;

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
		public _003CRefreshBufferTextureTask_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003CViewCanvasGroup_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MiniMapHover _003C_003E4__this;

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
		public _003CViewCanvasGroup_003Ed__20(int _003C_003E1__state)
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

	public RawImage rawImage;

	public Canvas canvas;

	public RectTransform DeviceInfoViewer;

	public TMP_Text DeviceInfoViewer_DeviceName;

	public TMP_Text DeviceInfoViewer_TaskData;

	public TMP_Text DeviceInfoViewer_Fullname;

	public Image DeviceInfoViewer_Avatar;

	public CanvasGroup canvasGroup;

	public List<MiniMapHoverDataDeviceByColor> dataDevice;

	public Color32 colorMouse;

	public MiniMapHoverDataDeviceByColor nowSelectedDevice;

	private RenderTexture renderTexture;

	private Texture2D texture;

	public Coroutine CortRefreshBufferTextureTask;

	[ContextMenu("Del Empty Object")]
	public void DelEmptyObject()
	{
	}

	[ContextMenu("Generate New Colors")]
	public void GenerateNewColors()
	{
	}

	public void ResetUI()
	{
	}

	public void RefreshBufferTexture()
	{
	}

	[IteratorStateMachine(typeof(_003CRefreshBufferTextureTask_003Ed__18))]
	private IEnumerator RefreshBufferTextureTask()
	{
		return null;
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CViewCanvasGroup_003Ed__20))]
	private IEnumerator ViewCanvasGroup()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	private Color32 GetColorByTaskDataType(TaskData taskData)
	{
		return default(Color32);
	}

	public static string Color32ToHexWithAlpha(Color32 color)
	{
		return null;
	}
}
