using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

[SelectionBase]
public class Obj_BossTrainCannon : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_LerpChargeRateText_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_BossTrainCannon _003C_003E4__this;

		public float rate;

		public float duration;

		private float _003CstartRate_003E5__2;

		private float _003CendRate_003E5__3;

		private float _003Ctime_003E5__4;

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
		public _003CCR_LerpChargeRateText_003Ed__15(int _003C_003E1__state)
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
	private Transform node_Model;

	[SerializeField]
	private Transform node_Shoot;

	[SerializeField]
	private ParticleSystem particle_Shoot;

	[SerializeField]
	private Transform node_Bullet;

	[SerializeField]
	private MeshRenderer mesh_Bullet;

	[SerializeField]
	private Transform node_RangeIndicator;

	[SerializeField]
	private TMP_Text text_ChargeRate;

	[SerializeField]
	private Gradient gradient_ChargeRate;

	private int curChargeRate;

	private void Start()
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	public void Shoot(Vector3 target)
	{
	}

	public void SetChargeRate(float rate, float duration)
	{
	}

	public void ToggleChargeRate(bool isShow)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LerpChargeRateText_003Ed__15))]
	private IEnumerator CR_LerpChargeRateText(float rate, float duration)
	{
		return null;
	}
}
