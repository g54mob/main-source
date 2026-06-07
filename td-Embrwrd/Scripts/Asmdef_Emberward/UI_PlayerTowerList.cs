using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UI_PlayerTowerList : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_CardJumpAnim_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_PlayerTowerList _003C_003E4__this;

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
		public _003CCR_CardJumpAnim_003Ed__8(int _003C_003E1__state)
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
	private List<Obj_UI_MapSceneTowerCard> list_Cards;

	[Header("卡片跳動動畫間隔")]
	[SerializeField]
	private float cardJumpAnimationInterval;

	private float cardJumpTimer;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTowerCardChanged(List<TowerIngameData> list_Data, int index)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CardJumpAnim_003Ed__8))]
	private IEnumerator CR_CardJumpAnim()
	{
		return null;
	}

	private void UpdateCards(List<TowerIngameData> list_Data)
	{
	}
}
