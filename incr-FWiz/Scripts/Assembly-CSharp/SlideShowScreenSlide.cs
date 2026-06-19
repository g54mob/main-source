using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlideShowScreenSlide : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWriteOutText_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SlideShowScreenSlide _003C_003E4__this;

		private string _003CfullText_003E5__2;

		private bool _003CinsideTag_003E5__3;

		private string _003CcurrentTag_003E5__4;

		private int _003CwriteCount_003E5__5;

		private int _003Ci_003E5__6;

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
		public _003CWriteOutText_003Ed__27(int _003C_003E1__state)
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

	public float FadeInTime;

	public float FadeOutTime;

	public Image Image;

	private StorySlide _slide;

	private Tween _runningTween;

	public float FadeOutLevel;

	public float FadeInLevel;

	public Image FadeImage;

	[SerializeField]
	private TextMeshProUGUI _textMesh;

	[SerializeField]
	private float _writeTextSpeed;

	public EventReference TalkSound;

	public int CharactersPerTalkSound;

	private bool _writingText;

	private Coroutine _writingTextCoroutine;

	public bool Shown { get; private set; }

	public bool TextWritten { get; private set; }

	public void Initiate()
	{
	}

	public Tween Show(StorySlide slide)
	{
		return null;
	}

	public Tween Hide()
	{
		return null;
	}

	public void CompleteTransitionInstantly(StorySlide slide)
	{
	}

	public void ShowFullText()
	{
	}

	[IteratorStateMachine(typeof(_003CWriteOutText_003Ed__27))]
	private IEnumerator WriteOutText()
	{
		return null;
	}

	private void StopWriting()
	{
	}
}
