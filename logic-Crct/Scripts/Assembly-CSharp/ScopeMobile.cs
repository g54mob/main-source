using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class ScopeMobile : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Tick_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScopeMobile _003C_003E4__this;

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
		public _003C_Tick_003Ed__35(int _003C_003E1__state)
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

	private static ScopeMobile inst;

	public GameObject mainObject;

	public BaseComponent component;

	public Text compName;

	public UILineRenderer voltGraph;

	public UILineRenderer voltGraphZero;

	public UILineRenderer currentGraph;

	public UILineRenderer currentGraphZero;

	public Text voltText;

	public Text currentText;

	private List<float> voltRecording;

	private List<float> currentRecording;

	public float scopeWidth;

	public float scopeHeight;

	public int recordingFrames;

	public float maxV;

	public float minV;

	public float maxA;

	public float minA;

	public Vector3 baseScopePosition;

	private Vector3 initDragPosition;

	private Vector3 initMousePosition;

	public RectTransform scopeTransform;

	private float voltage;

	private float current;

	private float updateT;

	private byte[] _data;

	private MemoryMappedFile mmf;

	private MemoryMappedViewStream mmvStream;

	private void Awake()
	{
	}

	public void InitDrag(BaseEventData data)
	{
	}

	public void Drag(BaseEventData data)
	{
	}

	public static void DisplayScope(BaseComponent c)
	{
	}

	private void _displayScope(BaseComponent c)
	{
	}

	public static void CloseScope()
	{
	}

	[IteratorStateMachine(typeof(_003C_Tick_003Ed__35))]
	private IEnumerator _Tick()
	{
		return null;
	}
}
