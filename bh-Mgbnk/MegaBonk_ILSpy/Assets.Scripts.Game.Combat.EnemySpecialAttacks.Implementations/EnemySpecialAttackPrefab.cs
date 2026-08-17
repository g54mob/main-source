using System;
using System.Collections;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;

public abstract class EnemySpecialAttackPrefab : MonoBehaviour
{
	private sealed class _003CWaitForSecondsCustom_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float time;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CWaitForSecondsCustom_003Ed__18(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0011: Expected F4, but got I4
			//IL_0047: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003Ctimer_003E5__2 = _003C_003E1__state;
			}
			else if (_003C_003E1__state != 1)
			{
				goto IL_006f;
			}
			_003C_003E1__state = -1;
			if (time > _003Ctimer_003E5__2)
			{
				float num = _003Ctimer_003E5__2 + MyTime.deltaTime;
				_003C_003E2__current = null;
				_003Ctimer_003E5__2 = num;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_006f;
			IL_006f:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public GameObject attackEffectPrefab;

	public EEnemyAttack eAttack;

	private EnemySpecialAttack _003CspecialAttack_003Ek__BackingField;

	protected Enemy enemy;

	protected CircleWarning circleWarning;

	private bool isActive;

	public EnemySpecialAttack specialAttack
	{
		get
		{
			return _003CspecialAttack_003Ek__BackingField;
		}
		private set
		{
			_003CspecialAttack_003Ek__BackingField = value;
		}
	}

	public void Set(EnemySpecialAttack attack, Enemy enemy)
	{
		isActive = true;
		_003CspecialAttack_003Ek__BackingField = attack;
		this.enemy = enemy;
		Init();
	}

	protected abstract void Init();

	protected unsafe void CreateWarningSphere(Vector3 pos, Action completeAction)
	{
		//IL_0029: Expected O, but got Ref
		EnemySpecialAttack enemySpecialAttack = _003CspecialAttack_003Ek__BackingField;
		object obj = default(object);
		Action completeAction2 = default(Action);
		CircleWarning circleWarning = EffectManager.Instance.WarningSphere((Vector3)(&obj), enemySpecialAttack.attackRadius, enemySpecialAttack.attackChargeTime, completeAction2);
		this.circleWarning = circleWarning;
	}

	protected unsafe bool CreateWarningHitscan(Vector3 pos, Vector3 dir, float distance, Action completeAction)
	{
		//IL_0062: Expected I4, but got O
		//IL_004b: Expected O, but got Ref
		//IL_004b: Expected O, but got Ref
		EnemySpecialAttack enemySpecialAttack = _003CspecialAttack_003Ek__BackingField;
		object obj = default(object);
		float num = default(float);
		float distance2 = default(float);
		float time = default(float);
		Action completeAction2 = default(Action);
		if (_003CspecialAttack_003Ek__BackingField != null && (object)EffectManager.Instance != null)
		{
			return EffectManager.Instance.WarningTube((Vector3)(&obj), (Vector3)(&num), enemySpecialAttack.attackRadius, distance2, time, completeAction2);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected GameObject GetEffectPrefab()
	{
		if ((object)PoolManager.Instance != null)
		{
			return PoolManager.Instance.GetEnemyAttackFx(this);
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private void Awake()
	{
		//IL_0163: Expected I, but got O
		//IL_000a: Expected I, but got O
		//IL_00f9: Expected O, but got I4
		//IL_0102: Expected O, but got I4
		//IL_0110: Expected I, but got O
		//IL_00b7: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00ce: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v3 (Il2CppClass<Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab>)+190]");
		Action<Enemy> action = new Action<Enemy>(this, (IntPtr)0);
		bool flag = (object)this == null;
		nint num = (nint)action;
		EnemySpecialAttackPrefab enemySpecialAttackPrefab = this;
		if (!flag)
		{
			nint num2 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v3 (Il2CppClass<Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab>)+190]");
			action._002Ector((object)this, (IntPtr)0);
			Delegate obj = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, action);
			if ((object)obj == null)
			{
				Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action2 = default(Action<Enemy>);
			object obj3;
			object obj4;
			if (action2 != null)
			{
				Enemy.A_EnemyReleasedFromPool = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj2 = default(object);
				bool flag2 = obj2 == null;
				obj3 = 0;
				obj4 = 0;
				num = (nint)typeof(Action<Enemy>);
				enemySpecialAttackPrefab = (EnemySpecialAttackPrefab)(object)obj;
				if (flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				}
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			obj3 = 0;
			obj4 = 0;
			num = (nint)typeof(Action<Enemy>);
			enemySpecialAttackPrefab = (EnemySpecialAttackPrefab)(object)obj;
		}
		throw new NullReferenceException();
	}

	private void OnDestroy()
	{
		//IL_0163: Expected I, but got O
		//IL_000a: Expected I, but got O
		//IL_00f9: Expected O, but got I4
		//IL_0102: Expected O, but got I4
		//IL_0110: Expected I, but got O
		//IL_00b7: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_00ce: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v3 (Il2CppClass<Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab>)+190]");
		Action<Enemy> action = new Action<Enemy>(this, (IntPtr)0);
		bool flag = (object)this == null;
		nint num = (nint)action;
		EnemySpecialAttackPrefab enemySpecialAttackPrefab = this;
		if (!flag)
		{
			nint num2 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v3 (Il2CppClass<Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab>)+190]");
			action._002Ector((object)this, (IntPtr)0);
			Delegate obj = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, action);
			if ((object)obj == null)
			{
				Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action2 = default(Action<Enemy>);
			object obj3;
			object obj4;
			if (action2 != null)
			{
				Enemy.A_EnemyReleasedFromPool = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj2 = default(object);
				bool flag2 = obj2 == null;
				obj3 = 0;
				obj4 = 0;
				num = (nint)typeof(Action<Enemy>);
				enemySpecialAttackPrefab = (EnemySpecialAttackPrefab)(object)obj;
				if (flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				}
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			obj3 = 0;
			obj4 = 0;
			num = (nint)typeof(Action<Enemy>);
			enemySpecialAttackPrefab = (EnemySpecialAttackPrefab)(object)obj;
		}
		throw new NullReferenceException();
	}

	protected virtual void OnEnemyDied(Enemy enemy)
	{
		if (enemy == this.enemy)
		{
			GameObject gameObject = base.gameObject;
			if (gameObject.activeSelf && isActive)
			{
				PoolManager.Instance.ReturnEnemyAttack(this);
				isActive = false;
			}
		}
	}

	protected void ReturnToPool()
	{
		GameObject gameObject = base.gameObject;
		if (gameObject.activeSelf && isActive)
		{
			PoolManager.Instance.ReturnEnemyAttack(this);
			isActive = false;
		}
	}

	protected IEnumerator WaitForSecondsCustom(float time)
	{
		_003CWaitForSecondsCustom_003Ed__18 obj = new _003CWaitForSecondsCustom_003Ed__18(0);
		obj.time = time;
		obj._003C_003E1__state = 0;
		return obj;
	}

	protected DcFlags GetDamageFlags()
	{
		//IL_00f8: Expected I4, but got O
		Enemy enemy = this.enemy;
		if ((object)this.enemy != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
			object obj = default(object);
			if (obj != null)
			{
				return (DcFlags)11;
			}
			Enemy enemy2 = this.enemy;
			if ((object)this.enemy != null)
			{
				EnemyData enemyData = enemy2._003CenemyData_003Ek__BackingField;
				if ((object)enemy2._003CenemyData_003Ek__BackingField != null)
				{
					bool flag = enemyData.enemyName == EEnemy.GhostKing;
					DcFlags result = (DcFlags)11;
					if (!flag)
					{
						result = (DcFlags)3;
					}
					return result;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (DcFlags)ex;
	}
}
