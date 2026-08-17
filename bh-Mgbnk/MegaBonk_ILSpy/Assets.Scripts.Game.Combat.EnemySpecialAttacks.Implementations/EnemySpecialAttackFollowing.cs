using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;

public class EnemySpecialAttackFollowing : EnemySpecialAttackPrefab
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Vector3 pos;

		public EnemySpecialAttackFollowing _003C_003E4__this;

		internal unsafe void _003CDoAttack_003Eb__0()
		{
			//IL_000f: Expected O, but got Ref
			object obj = default(object);
			_003C_003E4__this.SpawnHitEffect((Vector3)(&obj));
		}
	}

	private sealed class _003CDoAttack_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemySpecialAttackFollowing _003C_003E4__this;

		private int _003Ci_003E5__2;

		private float _003Celapsed_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoAttack_003Ed__5(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_001e: Expected I4, but got I8
			//IL_0089: Expected I4, but got I8
			//IL_00a5: Expected O, but got I4
			//IL_039b: Expected I4, but got O
			//IL_0053: Expected O, but got I4
			//IL_00c5: Invalid comparison between I and F4
			//IL_0182: Expected O, but got F4
			//IL_04f4: Expected O, but got Ref
			//IL_02ec: Expected O, but got Ref
			//IL_02ec: Expected O, but got Ref
			//IL_031b: Expected O, but got I
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Expected O, but got Unknown
			EnemySpecialAttackPrefab enemySpecialAttackPrefab = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003Ci_003E5__2 = 0;
				if ((object)_003C_003E4__this != null)
				{
					Vector3 vector = (Vector3)0;
					goto IL_03c7;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_037f;
				}
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				Vector3 vector = (Vector3)0;
				if (!flag)
				{
					goto IL_00b3;
				}
			}
			goto IL_038d;
			IL_038d:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_00b3:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbp_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+54]");
			if (!(0f > _003Celapsed_003E5__3))
			{
				int num = _003Ci_003E5__2 + 1;
				_003Ci_003E5__2 = num;
				goto IL_03c7;
			}
			float num2 = _003Celapsed_003E5__3 + MyTime.deltaTime;
			_003C_003E2__current = null;
			_003Celapsed_003E5__3 = num2;
			_003C_003E1__state = 1;
			return true;
			IL_037f:
			return false;
			IL_040e:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbp_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+50]");
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals8;
			if ((nint)0 != 0)
			{
				float num3 = (float)Vector3.upVector * 99f;
				float num4 = num3 + (float)CS_0024_003C_003E8__locals8.pos;
				GameManager instance = GameManager.Instance;
				if ((object)GameManager.Instance == null)
				{
					goto IL_038d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				float num5 = default(float);
				Vector3 downVector = default(Vector3);
				int layerMask = default(int);
				RaycastHit[] hits = Physics.RaycastAll((Vector3)(&num5), (Vector3)(&downVector), 999f, layerMask);
				RaycastHit raycastHit = SpawnPositions.FindHitClosestToPlayerY(hits, out var _);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rax_v29 (UnityEngine.RaycastHit)+10]");
				Vector3 vector2 = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
				object pos = default(object);
				CS_0024_003C_003E8__locals8.pos = (Vector3)pos;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rax_v30+8]");
				_ = 0;
				Vector3 vector = raycastHit.m_Point;
				downVector = Vector3.downVector;
				num5 = num4;
			}
			Action completeAction = delegate
			{
				//IL_000f: Expected O, but got Ref
				object obj = default(object);
				CS_0024_003C_003E8__locals8._003C_003E4__this.SpawnHitEffect((Vector3)(&obj));
			};
			Vector3 vector3 = default(Vector3);
			_003C_003E4__this.CreateWarningSphere((Vector3)(&vector3), completeAction);
			_003Celapsed_003E5__3 = 0f;
			goto IL_00b3;
			IL_03c7:
			int num6 = _003Ci_003E5__2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbp_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+58]");
			if ((nint)num6 >= (nint)0)
			{
				goto IL_037f;
			}
			CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass5_0();
			if (CS_0024_003C_003E8__locals8 != null)
			{
				CS_0024_003C_003E8__locals8._003C_003E4__this = _003C_003E4__this;
				if ((object)MyPlayer.Instance != null)
				{
					Transform transform = MyPlayer.Instance.transform;
					if ((object)transform != null)
					{
						Vector3 position = transform.position;
						CS_0024_003C_003E8__locals8.pos = (Vector3)position.x;
						_ = position.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rbp_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+51]");
						if ((nint)0 == 0)
						{
							goto IL_040e;
						}
						EnemySpecialAttack enemySpecialAttack = enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField;
						if (enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField != null)
						{
							MyPlayer instance2 = MyPlayer.Instance;
							if ((object)MyPlayer.Instance != null && (object)instance2.playerMovement != null)
							{
								Vector3 velocity = instance2.playerMovement.GetVelocity();
								float num7 = enemySpecialAttack.attackChargeTime * velocity.x;
								float num8 = enemySpecialAttack.attackChargeTime * velocity.y;
								float num9 = enemySpecialAttack.attackChargeTime * velocity.z;
								Vector3 vector2 = num7 + CS_0024_003C_003E8__locals8.pos;
								float num10 = num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v7 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackFollowing+<>c__DisplayClass5_0)+14]");
								float num11 = num10 + 0f;
								float num12 = num9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v7 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackFollowing+<>c__DisplayClass5_0)+18]");
								float num13 = num12 + 0f;
								CS_0024_003C_003E8__locals8.pos = vector2;
								goto IL_040e;
							}
						}
					}
				}
			}
			goto IL_038d;
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

	public bool grounded = true;

	public bool predictive;

	public float delayBetweenHits = 0.4f;

	public int numHits = 8;

	private int numSpawned;

	protected unsafe override void Init()
	{
		//IL_0037: Expected O, but got Ref
		numSpawned = 0;
		Transform transform = attackEffectPrefab.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
		_003CDoAttack_003Ed__5 obj = new _003CDoAttack_003Ed__5(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator DoAttack()
	{
		_003CDoAttack_003Ed__5 obj = new _003CDoAttack_003Ed__5(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void SpawnHitEffect(Vector3 pos)
	{
		//IL_004b: Expected O, but got Ref
		//IL_00e7: Expected O, but got Ref
		//IL_0097: Expected O, but got Ref
		//IL_0183: Expected O, but got Ref
		GameObject effectPrefab = GetEffectPrefab();
		float num = default(float);
		if (effectPrefab != null)
		{
			Transform transform = effectPrefab.transform;
			transform.position = (Vector3)(&num);
			effectPrefab.SetActive(value: true);
			Transform transform2 = effectPrefab.transform;
			EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
			float num2 = enemySpecialAttack.attackRadius * (float)Vector3.oneVector;
			transform2.localScale = (Vector3)(&num);
			num = num2;
		}
		EnemySpecialAttack enemySpecialAttack2 = base._003CspecialAttack_003Ek__BackingField;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		int layerMask = default(int);
		if (Physics.CheckSphere((Vector3)(&num), enemySpecialAttack2.attackRadius, layerMask))
		{
			EnemySpecialAttack enemySpecialAttack3 = base._003CspecialAttack_003Ek__BackingField;
			float damage = EnemyStats.GetDamage(enemy);
			float damage2 = damage * enemySpecialAttack3.damageMultiplier;
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			DcFlags damageFlags = GetDamageFlags();
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage2, 25f, (Vector3)(&num), ignoreShield, damageSource, flags, damageEffect);
		}
		if (++numSpawned >= numHits)
		{
			ReturnToPool();
		}
	}
}
