using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using MyBox;
using UnityEngine;
using __Project__.Scripts.Multiplayer;

public class SecurityAntenna : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStopWarning_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool _IsInstant;

		public SecurityAntenna _003C_003E4__this;

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
		public _003CStopWarning_003Ed__24(int _003C_003E1__state)
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

	public bool IsEnable;

	[SerializeField]
	private float m_WarningDuration;

	[Space]
	[SerializeField]
	private AudioSource m_WarningAudioSource;

	[SerializeField]
	private List<MeshRenderer> m_Meshes;

	private bool m_IsInWarning;

	private List<Tween> _EmissionTweens;

	public double AlertTime;

	private NetworkSecurityDetechArea m_NetworkSecurityDetechArea;

	public bool IsInWarning => false;

	public float WarningDuration => 0f;

	public NetworkSecurityDetechArea NetworkSecurityDetechArea => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void EnableAntenna()
	{
	}

	public void DisableAntenna()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void PlayWarning()
	{
	}

	public void ShoplifterTrigger(Shoplifter _shoplifter)
	{
	}

	public void DetechShoplifter(Shoplifter _shoplifter)
	{
	}

	public void StopWarningInstant()
	{
	}

	[IteratorStateMachine(typeof(_003CStopWarning_003Ed__24))]
	public IEnumerator StopWarning(bool _IsInstant = false)
	{
		return null;
	}

	private void OnFurnitureStartPlacingMode(GameObject obj)
	{
	}

	private void OnFurnitureBoxUp(GameObject obj)
	{
	}

	private void OnFurniturePlaced(GameObject obj)
	{
	}
}
