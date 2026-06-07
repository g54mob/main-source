using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_BossExtraSkillEntry : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_ShineAnimation_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public UI_Obj_BossExtraSkillEntry _003C_003E4__this;

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
		public _003CCR_ShineAnimation_003Ed__8(int _003C_003E1__state)
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
	private Image image_SkillImage;

	[SerializeField]
	private TMP_Text text_SkillName;

	[SerializeField]
	private TMP_Text text_SkillContent;

	[SerializeField]
	private GameObject node_Locked;

	[SerializeField]
	private ParticleSystem particle_Dust;

	public void Setup(Sprite skillImage, string skillName, string skillContent, bool isActivated)
	{
	}

	public void TriggerShineAnimation(float delay)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShineAnimation_003Ed__8))]
	private IEnumerator CR_ShineAnimation(float delay)
	{
		return null;
	}

	public void ToggleLocked(bool isLocked)
	{
	}

	public void CloseUI()
	{
	}
}
