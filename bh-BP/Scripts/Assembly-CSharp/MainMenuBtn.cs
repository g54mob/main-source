using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using TMPro;
using UnityEngine;

public class MainMenuBtn : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_LerpToMatProgress_003Ed__12 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public MainMenuBtn _003C_003E4__this;

		public float tgtProgress;

		private float _003CstartTime_003E5__2;

		private float _003CstartProgress_003E5__3;

		private float _003Clen_003E5__4;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_LerpToMatProgress_003Ed__12(int _003C_003E1__state)
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

	public MainMenuOption Option;

	public CoolButton Btn;

	public Localize Loc;

	public TextMeshProUGUI Txt;

	private CoroutineHandle _curAnim;

	private float _curMatProgress;

	private void Awake()
	{
	}

	private void OnClicked()
	{
	}

	private void OnEnable()
	{
	}

	private void OnHover()
	{
	}

	public void OnHoverExit()
	{
	}

	public void SetMat(Material mat)
	{
	}

	[IteratorStateMachine(typeof(_003C_LerpToMatProgress_003Ed__12))]
	private IEnumerator<float> _LerpToMatProgress(float tgtProgress)
	{
		return null;
	}

	private void SetMatProgress(float prog)
	{
	}
}
