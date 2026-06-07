using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Febucci.UI;
using TMPro;
using UnityEngine;

public class UI_BuffApplyText : MonoBehaviour
{
	public enum ebuffTextStyle
	{
		NONE = 0,
		RAINBOW = 1,
		DARKRED = 2,
		GOLD = 3,
		WHITE = 4
	}

	[CompilerGenerated]
	private sealed class _003CEffectProc_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_BuffApplyText _003C_003E4__this;

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
		public _003CEffectProc_003Ed__17(int _003C_003E1__state)
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

	[SerializeField]
	private TypewriterByCharacter text_Content_Rainbow;

	[SerializeField]
	private TypewriterByCharacter text_Content_DarkRed;

	[SerializeField]
	private TypewriterByCharacter text_Content_Gold;

	[SerializeField]
	private TypewriterByCharacter text_Content_White;

	[SerializeField]
	private TMP_Text text_Content_White_TMP;

	[SerializeField]
	private float waitTimeAfterShowText;

	[SerializeField]
	private float width;

	private Vector3 worldPosition;

	private Vector3 curCameraPos;

	private TypewriterByCharacter currentText;

	public float Width => 0f;

	public void Trigger(Vector3 worldPos, string content, ebuffTextStyle style)
	{
	}

	public void SetTextColor(Color color)
	{
	}

	public void SetTextScale(float scale)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CEffectProc_003Ed__17))]
	private IEnumerator EffectProc()
	{
		return null;
	}
}
