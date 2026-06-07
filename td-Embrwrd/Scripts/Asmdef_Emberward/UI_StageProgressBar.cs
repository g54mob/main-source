using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageProgressBar : AUISituational
{
	[CompilerGenerated]
	private sealed class _003CCR_EndlessModeNextRound_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_StageProgressBar _003C_003E4__this;

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
		public _003CCR_EndlessModeNextRound_003Ed__23(int _003C_003E1__state)
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
	private Image image_Line;

	[SerializeField]
	private float maxLineWidth;

	[SerializeField]
	private float endlessModeExtraLineWidth;

	[SerializeField]
	private float nodeDistance;

	[SerializeField]
	private Transform node_NodeAnchor;

	[SerializeField]
	private GameObject prefab_ProgressNode;

	[Header("有箭頭的線條Sprite")]
	[SerializeField]
	private Sprite sprite_Line_Arrow;

	[Header("普通線條Sprite")]
	[SerializeField]
	private Sprite sprite_Line_Normal;

	private List<UI_Obj_LevelProgressNode> list_ProgressNodes;

	private EndlessModeRoundRewardData endlessModeRoundRewardData;

	private float nodeWidth;

	private int totalRound;

	private bool isEndless;

	private bool isScoreAttack;

	private int lastNodeRound;

	private bool isAnimPlaying;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGameInitReady()
	{
	}

	private void OnRoundEnd()
	{
	}

	private void OnToggleRoundTimerUI(bool isOn, bool doShowCountdown, bool isFirstRound)
	{
	}

	public void Setup()
	{
	}

	private void OnNextRound()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_EndlessModeNextRound_003Ed__23))]
	private IEnumerator CR_EndlessModeNextRound()
	{
		return null;
	}

	private void NodeAnim()
	{
	}

	private UI_Obj_LevelProgressNode CreateProgressNode(int index, EndlessModeRoundReward reward = null)
	{
		return null;
	}
}
