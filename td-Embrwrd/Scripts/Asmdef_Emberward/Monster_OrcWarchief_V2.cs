using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_OrcWarchief_V2 : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_Cast_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_OrcWarchief_V2 _003C_003E4__this;

		private List<ABaseTower> _003CtargetTowers_003E5__2;

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
		public _003CCR_Cast_003Ed__14(int _003C_003E1__state)
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
	private float skillRange;

	[SerializeField]
	private float skillStunTime;

	[SerializeField]
	private float skillSpeedModifier;

	[SerializeField]
	private GameObject weaponPrefab;

	[SerializeField]
	[Header("手上固定拿的的武器, 丟出時隱藏")]
	private GameObject obj_Weapon;

	[SerializeField]
	private Transform weaponHandNode;

	[SerializeField]
	private float skillCooldown;

	[SerializeField]
	private float skillTimer;

	[SerializeField]
	private float skillDetectInterval;

	private bool isSkillUsed;

	private float cooldown;

	protected override void SpawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void Skill_ThrowAxe()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Cast_003Ed__14))]
	private IEnumerator CR_Cast()
	{
		return null;
	}

	private List<ABaseTower> GetHighestThreatTowers(int count)
	{
		return null;
	}

	private float CalculateThreat(ABaseTower tower)
	{
		return 0f;
	}
}
