using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TowerDefaultPrioritySetting : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_ShowEffect_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_TowerDefaultPrioritySetting _003C_003E4__this;

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
		public _003CCR_ShowEffect_003Ed__17(int _003C_003E1__state)
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
	private Animator animator;

	[SerializeField]
	private List<UI_Obj_TowerDefaultPriorityEntry> list_Entries;

	[SerializeField]
	private Button button_SetupPriority;

	[SerializeField]
	private RectTransform mouseDetectRect;

	[SerializeField]
	private TMP_Text text_Button;

	[SerializeField]
	private GameObject node_Frame;

	private bool isOn;

	private Coroutine coroutine_ShowEffect;

	private bool isClickedOnThisUI;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTowerChanged(List<TowerIngameData> list, int index)
	{
	}

	private void OnClickSetupPriority()
	{
	}

	private void OnLanguageChanged()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void UpdateContent()
	{
	}

	private void Toggle(bool isOn)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowEffect_003Ed__17))]
	private IEnumerator CR_ShowEffect()
	{
		return null;
	}

	private void Update()
	{
	}
}
