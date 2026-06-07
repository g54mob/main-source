using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ScaleProductDisplay : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CUpdateTextCoroutine_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScaleProductDisplay _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CUpdateTextCoroutine_003Ed__8(int _003C_003E1__state)
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
	private TMP_Text m_WeightText;

	private Coroutine m_TextUpdateCoroutine;

	private ProductPaperBag m_Product;

	[SerializeField]
	private ScaleItemDetailEntry m_DetailEntry;

	public ProductPaperBag Product
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void UpdateDisplay()
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateTextCoroutine_003Ed__8))]
	private IEnumerator UpdateTextCoroutine()
	{
		return null;
	}
}
