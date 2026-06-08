using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TutorialEventTester : MonoBehaviour
{
	private sealed class _003CStart_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TutorialEventTester _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CStart_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			TutorialEventTester tutorialEventTester = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (tutorialEventTester.playOnStart)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				break;
			case 1:
				_003C_003E1__state = -1;
				tutorialEventTester.BeginEvents();
				break;
			}
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
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private bool playOnStart;

	[SerializeField]
	private KeyCode startKey;

	private IEnumerator Start()
	{
		return new _003CStart_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}

	private void BeginEvents()
	{
		TutorialEvent[] componentsInChildren = GetComponentsInChildren<TutorialEvent>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Begin();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(startKey))
		{
			BeginEvents();
		}
	}
}
