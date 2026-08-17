using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

public class EnemySpecialAttackHitscanMultiple : EnemySpecialAttackPrefab
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public Vector3 startPos;

		public Vector3 dir;

		public EnemySpecialAttackHitscanMultiple _003C_003E4__this;

		internal unsafe void _003CDoAttack_003Eb__0()
		{
			//IL_0013: Expected O, but got Ref
			//IL_0013: Expected O, but got Ref
			object obj = default(object);
			object obj2 = default(object);
			_003C_003E4__this.SpawnHitEffect((Vector3)(&obj), (Vector3)(&obj2));
		}
	}

	private sealed class _003CDoAttack_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemySpecialAttackHitscanMultiple _003C_003E4__this;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoAttack_003Ed__7(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_040f: Expected I4, but got I8
			//IL_03d4: Expected I4, but got O
			//IL_011f: Invalid comparison between F4 and I4
			//IL_0140: Invalid comparison between F4 and I4
			//IL_02e8: Expected O, but got F4
			//IL_0358: Expected F4, but got I
			//IL_0358: Expected O, but got Ref
			//IL_0358: Expected O, but got Ref
			//IL_038c: Expected F4, but got I
			if (_003C_003E1__state == 0)
			{
				_003Ci_003E5__2 = _003C_003E1__state;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_03b8;
				}
				int num = _003Ci_003E5__2 + 1;
				_003Ci_003E5__2 = num;
			}
			EnemySpecialAttackPrefab enemySpecialAttackPrefab = _003C_003E4__this;
			_003C_003E1__state = -1;
			_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals5;
			if ((object)_003C_003E4__this != null)
			{
				int num2 = _003Ci_003E5__2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r14_v3 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+54]");
				if ((nint)num2 >= (nint)0)
				{
					goto IL_03b8;
				}
				CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass7_0();
				if (CS_0024_003C_003E8__locals5 != null)
				{
					CS_0024_003C_003E8__locals5._003C_003E4__this = _003C_003E4__this;
					if ((object)MyPlayer.Instance != null)
					{
						Transform transform = MyPlayer.Instance.transform;
						if ((object)transform != null)
						{
							Vector3 position = transform.position;
							if (MyRandom.random != null)
							{
								double num3 = MyRandom.random.NextDouble();
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm2,xmm0\"");
								if (0.4f < 0f)
								{
									if (0.8f < 0f)
									{
										goto IL_0488;
									}
									if ((object)MyPlayer.Instance != null)
									{
										Transform transform2 = MyPlayer.Instance.transform;
										if ((object)transform2 != null)
										{
											Vector3 position2 = transform2.position;
											Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
											goto IL_0488;
										}
									}
								}
								else if ((object)MyPlayer.Instance != null)
								{
									Transform transform3 = MyPlayer.Instance.transform;
									if ((object)transform3 != null)
									{
										Vector3 position3 = transform3.position;
										if (enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField != null)
										{
											MyPlayer instance = MyPlayer.Instance;
											if ((object)MyPlayer.Instance != null && (object)instance.playerMovement != null)
											{
												Vector3 insideUnitSphere = instance.playerMovement.GetVelocity();
												goto IL_0488;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_03c6;
			IL_0488:
			if ((object)enemySpecialAttackPrefab.enemy != null)
			{
				Vector3 headPosition = enemySpecialAttackPrefab.enemy.GetHeadPosition();
				float num4 = headPosition.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r14_v3 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+60]");
				float num5 = num4 + 0f;
				float num6 = headPosition.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r14_v3 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+64]");
				float num7 = num6 + 0f;
				float num8 = headPosition.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r14_v3 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+68]");
				float num9 = num8 + 0f;
				CS_0024_003C_003E8__locals5.startPos = (Vector3)num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				object dir = default(object);
				CS_0024_003C_003E8__locals5.dir = (Vector3)dir;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v631 @ rax_v23+8]");
				_ = 0;
				Action action = delegate
				{
					//IL_0013: Expected O, but got Ref
					//IL_0013: Expected O, but got Ref
					object obj2 = default(object);
					object obj3 = default(object);
					CS_0024_003C_003E8__locals5._003C_003E4__this.SpawnHitEffect((Vector3)(&obj2), (Vector3)(&obj3));
				};
				EnemySpecialAttackHitscanMultiple enemySpecialAttackHitscanMultiple = _003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r14_v3 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+5C]");
				object obj = default(object);
				float num10 = default(float);
				Action completeAction = default(Action);
				if (enemySpecialAttackHitscanMultiple.CreateWarningHitscan((Vector3)(&obj), (Vector3)(&num10), 0f, completeAction))
				{
					EnemySpecialAttackHitscanMultiple enemySpecialAttackHitscanMultiple2 = _003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r14_v3 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+50]");
					IEnumerator enumerator = enemySpecialAttackHitscanMultiple2.WaitForSecondsCustom(0f);
					_003C_003E2__current = enumerator;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_03b8;
			}
			goto IL_03c6;
			IL_03b8:
			return false;
			IL_03c6:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
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

	public float delayBetweenAttacks = 0.08f;

	public int numToSpawn = 20;

	private int numSpawned;

	public float maxRange = 999f;

	public Vector3 attackOffset;

	public float randomPositionRadius = 25f;

	protected override void Init()
	{
		numSpawned = 0;
		_003CDoAttack_003Ed__7 obj = new _003CDoAttack_003Ed__7(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator DoAttack()
	{
		_003CDoAttack_003Ed__7 obj = new _003CDoAttack_003Ed__7(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void SpawnHitEffect(Vector3 pos, Vector3 dir)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0110: Expected O, but got Ref
		//IL_011e: Expected O, but got Ref
		//IL_0062: Expected O, but got Ref
		//IL_0199: Expected O, but got Ref
		//IL_00a3: Expected O, but got Ref
		//IL_00d7: Expected O, but got Ref
		//IL_0226: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject effectPrefab = GetEffectPrefab();
		if (effectPrefab != null)
		{
			effectPrefab.SetActive(value: true);
			Transform transform = effectPrefab.transform;
			Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			_ = pos.z;
			_ = pos.x;
			transform.position = position;
			Transform transform2 = effectPrefab.transform;
			Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			_ = dir.z;
			_ = dir.x;
			Quaternion quaternion = Quaternion.LookRotation(forward);
			Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = quaternion.x;
			transform2.rotation = rotation;
		}
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = 0;
		_ = 0;
		_ = dir.x;
		_ = dir.z;
		_ = pos.x;
		_ = pos.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rax_v12+8]");
		_ = 0;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		Ray ray = (Ray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-9]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+7]");
		_ = 0;
		int layerMask = default(int);
		if (Physics.SphereCast(ray, enemySpecialAttack.attackRadius, maxRange, layerMask))
		{
			float damage = base._003CspecialAttack_003Ek__BackingField.GetDamage(enemy);
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			_ = dir.z;
			_ = dir.x;
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage, 5f, direction, ignoreShield, damageSource, flags, damageEffect);
			if (eAttack == EEnemyAttack.PoisonSpikeProjectiles)
			{
				MyPlayer instance3 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance3.inventory;
				inventory2.statusEffects.PoisonPlayer(8f);
			}
		}
		if (++numSpawned >= numToSpawn)
		{
			ReturnToPool();
		}
	}
}
