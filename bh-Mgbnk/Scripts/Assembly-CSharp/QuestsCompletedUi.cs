using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;
using UnityEngine.UI;

public class QuestsCompletedUi : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateQuests_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<MyAchievement> achievements;

		public QuestsCompletedUi _003C_003E4__this;

		private int _003Cindex_003E5__2;

		private List<MyAchievement>.Enumerator _003C_003E7__wrap2;

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
		public _003CAnimateQuests_003Ed__6(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public GameObject prefab;

	public Transform contentParent;

	public ScrollRect scrollRect;

	public AudioSource source;

	private float delay;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateQuests_003Ed__6))]
	private IEnumerator AnimateQuests(List<MyAchievement> achievements)
	{
		return null;
	}

	private void TestAddItem(MyAchievement ach)
	{
	}
}
