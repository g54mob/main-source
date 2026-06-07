using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_EmberRecover_Popup : APopupWindow
{
	[Serializable]
	public class EmberRecoverItemData
	{
		public eEmberRecoverItemType emberRecoverItemType;

		public int cost;
	}

	public enum eEmberRecoverItemType
	{
		NONE = 0,
		HEAL_LV1 = 1,
		HEAL_LV2 = 2,
		HEAL_LV3 = 3,
		MAX_HP = 4,
		DAMAGE = 5,
		SHIELD = 6
	}

	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_EmberRecover_Popup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__14(int _003C_003E1__state)
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
	private Button button_Leave;

	[SerializeField]
	private List<Obj_UI_EmberRecoverItem> list_EmberRecoverItems;

	[SerializeField]
	private List<EmberRecoverItemData> list_EmberRecoverItemData;

	[SerializeField]
	private List<Transform> list_Boxes;

	[SerializeField]
	private List<ParticleSystem> list_Particle_Heal1;

	[SerializeField]
	private List<ParticleSystem> list_Particle_Heal2;

	[SerializeField]
	private List<ParticleSystem> list_Particle_Heal3;

	[SerializeField]
	private List<ParticleSystem> list_Particle_MaxHP;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__14))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	private void OnEmberRecoverItemClicked(eEmberRecoverItemType type)
	{
	}

	private void PlayParticles(List<ParticleSystem> particles)
	{
	}

	private void ShakeBoxes(float durationMin, float durationMax, float strengthMin, float strengthMax)
	{
	}

	private void UpdateContent()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void OnButtonCancelClick()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public override void OnWindowRegainFocus()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void RebuildNavigationAndSelect()
	{
	}
}
