using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TowerBuffModule : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_BuffAnim_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ABaseTower tower;

		public ABaseBuffSettingData buff;

		private UI_Obj_TowerBuffIcon _003CtowerBuffIconScpt_003E5__2;

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
		public _003CCR_BuffAnim_003Ed__10(int _003C_003E1__state)
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
	private ABaseTower tower;

	private Dictionary<eItemType, ABaseBuffSettingData> dic_Buffs;

	private bool isOutlineOn;

	private List<Renderer> buffOutlineRenderers;

	public Action<eItemType> OnBuffApply;

	public Action<eItemType> OnBuffExpired;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void ApplyBuff(ABaseBuffSettingData buff, bool isFromPlayer, int sourceID)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_BuffAnim_003Ed__10))]
	private IEnumerator CR_BuffAnim(ABaseTower tower, ABaseBuffSettingData buff)
	{
		return null;
	}

	private void OnTowerShoot(ABaseTower tower, AMonsterBase target)
	{
	}

	private void OnTowerHit(ABaseTower tower, AMonsterBase target, int shootIndex, int bulletIndex)
	{
	}

	private void OnTowerDespawn(ABaseTower tower)
	{
	}

	public void RemoveAllBuffs()
	{
	}

	public bool HasAnyBuff()
	{
		return false;
	}

	public ABaseBuffSettingData GetCurrentBuff()
	{
		return null;
	}
}
