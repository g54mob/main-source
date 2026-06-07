using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpdateInfoUser : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[CompilerGenerated]
	private sealed class _003Ctiming_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UpdateInfoUser _003C_003E4__this;

		private float _003Ctimer_003E5__2;

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
		public _003Ctiming_003Ed__13(int _003C_003E1__state)
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

	public Image[] fill;

	public GameObject[] fillObject;

	public GameObject[] updatesObject;

	public GameObject About;

	public GameObject[] AboutView;

	private Coroutine updateCoroutine;

	public float displayTime;

	public int currentID;

	private bool isPaused;

	public void ResetData()
	{
	}

	public void ResetDataWithOutFill()
	{
	}

	private void Start()
	{
	}

	public void SetUpdate()
	{
	}

	[IteratorStateMachine(typeof(_003Ctiming_003Ed__13))]
	public IEnumerator timing()
	{
		return null;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void ResetAboutView()
	{
	}

	public void ShowViewOne()
	{
	}

	public void ShowViewTwo()
	{
	}

	public void ShowViewThree()
	{
	}

	public void CloseAboutView()
	{
	}
}
