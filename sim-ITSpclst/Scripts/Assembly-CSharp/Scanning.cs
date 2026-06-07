using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scanning : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateDot_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Scanning _003C_003E4__this;

		private float _003Celapsed_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private Vector3 _003CtargetPos_003E5__4;

		private Vector2 _003CstartSize_003E5__5;

		private Vector2 _003CmidSize_003E5__6;

		private Vector2 _003CfinalSize_003E5__7;

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
		public _003CAnimateDot_003Ed__26(int _003C_003E1__state)
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
	private sealed class _003CFillBar_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Scanning _003C_003E4__this;

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
		public _003CFillBar_003Ed__28(int _003C_003E1__state)
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

	[Header("Components")]
	public AppVirusPlus appVirusPlus;

	[Header("Animation")]
	public GameObject scanningView;

	public GameObject all_scanning_object;

	public RectTransform dotObject;

	public RectTransform scanButton;

	public RectTransform targetCenter;

	public RectTransform backgroundTarget;

	public GameObject closeButton;

	public float moveDuration;

	public float growDuration;

	public float finalGrowDuration;

	private Vector2 originalSize;

	[Header("Progress Bar")]
	[SerializeField]
	private Image fillImage;

	[SerializeField]
	private TextMeshProUGUI percentText;

	[SerializeField]
	private float duration;

	[SerializeField]
	[Header("Count Virus")]
	private TextMeshProUGUI virusCountText;

	[SerializeField]
	private TextMeshProUGUI webCountText;

	[SerializeField]
	private TextMeshProUGUI documentsCountText;

	[SerializeField]
	private TextMeshProUGUI privacyCountText;

	[SerializeField]
	[Header("\ufffdcie\ufffdki")]
	private TextMeshProUGUI filesText;

	[SerializeField]
	private string[] explorerAndFile;

	private float timer;

	private bool isRunning;

	private void Start()
	{
	}

	public void StartDotAnimation()
	{
	}

	public void CloseScanning()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateDot_003Ed__26))]
	private IEnumerator AnimateDot()
	{
		return null;
	}

	public void StartProgress()
	{
	}

	[IteratorStateMachine(typeof(_003CFillBar_003Ed__28))]
	private IEnumerator FillBar()
	{
		return null;
	}

	public bool IsRunning()
	{
		return false;
	}
}
