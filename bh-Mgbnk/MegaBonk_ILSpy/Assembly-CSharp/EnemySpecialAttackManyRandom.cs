using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Assets.Scripts.Game.Spawning;
using Cpp2ILInjected;
using UnityEngine;

public class EnemySpecialAttackManyRandom : EnemySpecialAttackPrefab
{
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public EnemySpecialAttackManyRandom _003C_003E4__this;

		public Vector3 playerPos;

		internal unsafe void _003CDoAttack_003Eb__0()
		{
			//IL_000f: Expected O, but got Ref
			object obj = default(object);
			_003C_003E4__this.SpawnHitEffect((Vector3)(&obj));
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public Vector3 pos;

		public _003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CDoAttack_003Eb__1()
		{
			//IL_0021: Expected O, but got Ref
			_003C_003Ec__DisplayClass8_0 obj = CS_0024_003C_003E8__locals1;
			object obj2 = default(object);
			obj._003C_003E4__this.SpawnHitEffect((Vector3)(&obj2));
		}
	}

	private sealed class _003CDoAttack_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemySpecialAttackManyRandom _003C_003E4__this;

		private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

		private float _003Cstep_003E5__2;

		private int _003Ci_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoAttack_003Ed__8(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_04d0: Expected I4, but got I8
			//IL_0a49: Expected I4, but got O
			//IL_00b8: Expected I4, but got I8
			//IL_003c: Invalid comparison between F8 and I4
			//IL_0085: Expected I4, but got I8
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Expected O, but got Unknown
			//IL_0599: Expected O, but got F4
			//IL_019d: Invalid comparison between F8 and I4
			//IL_01ac: Expected F8, but got I4
			//IL_0abd: Expected O, but got I4
			//IL_0ac6: Expected O, but got I4
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Expected O, but got Unknown
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Expected O, but got Unknown
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b4: Expected O, but got Unknown
			//IL_02d8: Expected O, but got F8
			//IL_0af3: Expected O, but got Ref
			//IL_0440: Unknown result type (might be due to invalid IL or missing references)
			//IL_0445: Expected O, but got Unknown
			//IL_0455: Expected F8, but got I
			//IL_0490: Expected F4, but got I
			//IL_086f: Expected O, but got F4
			//IL_073b: Expected O, but got F4
			//IL_0333: Expected O, but got Ref
			//IL_0333: Expected O, but got Ref
			//IL_09ee: Expected O, but got Ref
			//IL_0a18: Expected F4, but got I
			//IL_08e8: Expected O, but got Ref
			//IL_08e8: Expected O, but got Ref
			object obj2 = default(object);
			object obj = (object)(&obj2);
			EnemySpecialAttackPrefab enemySpecialAttackPrefab = _003C_003E4__this;
			_ = 0;
			_ = 0;
			_ = 0;
			bool flag = _003C_003E1__state == 0;
			bool result;
			if (!flag)
			{
				_ = 1;
				double num = (double)_003C_003E1__state - 1.0;
				if (!flag)
				{
					bool flag2 = num != 1.0;
					result = false;
					if (flag2)
					{
						goto IL_0a84;
					}
					int num2 = _003Ci_003E5__3 + 1;
					_003Ci_003E5__3 = num2;
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						goto IL_0a89;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						EnemySpecialAttack enemySpecialAttack = enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField;
						if (enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField != null)
						{
							float num3 = enemySpecialAttack.attackRadius + enemySpecialAttack.attackRadius;
							float num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r15_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+64]");
							float num5 = num4 + 0f;
							_003Ci_003E5__3 = 1;
							_003Cstep_003E5__2 = num5;
							goto IL_0a89;
						}
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				_003C_003Ec__DisplayClass8_0 obj3 = new _003C_003Ec__DisplayClass8_0();
				_003C_003E8__1 = obj3;
				_003C_003Ec__DisplayClass8_0 obj4 = _003C_003E8__1;
				if (_003C_003E8__1 != null)
				{
					obj4._003C_003E4__this = _003C_003E4__this;
					_003C_003Ec__DisplayClass8_0 obj5 = _003C_003E8__1;
					if ((object)MyPlayer.Instance != null)
					{
						Transform transform = MyPlayer.Instance.transform;
						if ((object)transform != null)
						{
							Vector3 position = transform.position;
							if (_003C_003E8__1 != null)
							{
								obj5.playerPos = (Vector3)position.x;
								_ = position.z;
								if ((object)_003C_003E4__this != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r15_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+51]");
									if ((nint)0 == 0)
									{
										goto IL_0b69;
									}
									EnemySpecialAttack enemySpecialAttack2 = enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField;
									if (enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField != null)
									{
										_003C_003Ec__DisplayClass8_0 obj6 = _003C_003E8__1;
										MyPlayer instance = MyPlayer.Instance;
										if ((object)MyPlayer.Instance != null && (object)instance.playerMovement != null)
										{
											Vector3 velocity = instance.playerMovement.GetVelocity();
											float num6 = enemySpecialAttack2.attackChargeTime * velocity.x;
											float num7 = enemySpecialAttack2.attackChargeTime * velocity.y;
											float num8 = enemySpecialAttack2.attackChargeTime * velocity.z;
											_003C_003Ec__DisplayClass8_0 obj7 = _003C_003E8__1;
											if (_003C_003E8__1 != null)
											{
												float num9 = num6 + (float)obj7.playerPos;
												float num10 = num7;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v55 (EnemySpecialAttackManyRandom+<>c__DisplayClass8_0)+1C]");
												float num11 = num10 + 0f;
												float num12 = num8;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v55 (EnemySpecialAttackManyRandom+<>c__DisplayClass8_0)+20]");
												float num13 = num12 + 0f;
												if (_003C_003E8__1 != null)
												{
													obj6.playerPos = (Vector3)num9;
													goto IL_0b69;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_0a3b;
			IL_0a3b:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0a89:
			int num14 = _003Ci_003E5__3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r15_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+54]");
			float num29 = default(float);
			Vector3 vector2 = default(Vector3);
			if ((nint)num14 <= (nint)0)
			{
				object obj8 = _003Ci_003E5__3 * _003Cstep_003E5__2;
				float num15 = (float)obj8 * ((float)Math.PI * 2f);
				float num16 = num15 / _003Cstep_003E5__2;
				double num17 = Math.Ceiling(num16);
				bool flag3 = num17 < 1.0;
				double num18 = 1.0;
				if (!flag3)
				{
					num18 = num17;
				}
				Vector3 vector = (Vector3)0;
				object obj9 = 0;
				Vector3 downVector = default(Vector3);
				int layerMask = default(int);
				object pos = default(object);
				while (true)
				{
					_003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass8_1();
					if (CS_0024_003C_003E8__locals8 == null)
					{
						break;
					}
					object obj10 = CS_0024_003C_003E8__locals8 + 32;
					CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
					double num19 = (double)obj9 / num18;
					double num20 = num19 + num19;
					double num21 = num20 * 3.1415927410125732;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE090");
					double num22 = num21 * (double)obj8;
					object obj11 = obj8 * 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
					double num23 = num21 * (double)obj8;
					_003C_003Ec__DisplayClass8_0 obj12 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 == null)
					{
						break;
					}
					double num24 = num22 + (double)obj12.playerPos;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v72 (EnemySpecialAttackManyRandom+<>c__DisplayClass8_0)+1C]");
					object obj13 = obj11 + 0;
					double num25 = num23;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v72 (EnemySpecialAttackManyRandom+<>c__DisplayClass8_0)+20]");
					double num26 = num25 + 0.0;
					CS_0024_003C_003E8__locals8.pos = (Vector3)num24;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r15_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+50]");
					if ((nint)0 != 0)
					{
						float num27 = (float)Vector3.upVector * 99f;
						float num28 = num27 + (float)num24;
						GameManager instance2 = GameManager.Instance;
						if ((object)GameManager.Instance == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
						RaycastHit[] array = Physics.RaycastAll((Vector3)(&num29), (Vector3)(&downVector), 999f, layerMask);
						if (array == null)
						{
							break;
						}
						bool flag4 = array.Length == 0;
						downVector = Vector3.downVector;
						float num30 = 999f;
						num29 = num28;
						if (!flag4)
						{
							RaycastHit raycastHit = SpawnPositions.FindHitClosestToPlayerY(array, out System.Runtime.CompilerServices.Unsafe.As<object, bool>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160)));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ rax_v88 (UnityEngine.RaycastHit)+10]");
							_ = 0;
							_ = raycastHit.m_Distance;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
							CS_0024_003C_003E8__locals8.pos = (Vector3)pos;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1016 @ rax_v89+8]");
							_ = 0;
							vector = raycastHit.m_Point;
							downVector = Vector3.downVector;
							num30 = 999f;
							num29 = num28;
						}
					}
					Action completeAction = delegate
					{
						//IL_0021: Expected O, but got Ref
						_003C_003Ec__DisplayClass8_0 obj18 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
						object obj19 = default(object);
						obj18._003C_003E4__this.SpawnHitEffect((Vector3)(&obj19));
					};
					_003C_003E4__this.CreateWarningSphere((Vector3)(&vector2), completeAction);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r15_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+58]");
					_ = (nint)0 + (nint)1;
					obj9++;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
					num18 = 0.0;
					object obj14 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
					if ((nint)obj14 < 0)
					{
						continue;
					}
					goto IL_0479;
				}
				goto IL_0a3b;
			}
			result = false;
			goto IL_0a84;
			IL_0b69:
			EnemySpecialAttack enemySpecialAttack3 = enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField;
			if (enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField != null)
			{
				_003C_003Ec__DisplayClass8_0 obj15 = _003C_003E8__1;
				MyPlayer instance3 = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null && (object)instance3.playerMovement != null)
				{
					Vector3 velocity2 = instance3.playerMovement.GetVelocity();
					float num31 = enemySpecialAttack3.attackChargeTime * velocity2.x;
					float num32 = enemySpecialAttack3.attackChargeTime * velocity2.y;
					float num33 = enemySpecialAttack3.attackChargeTime * velocity2.z;
					_003C_003Ec__DisplayClass8_0 obj16 = _003C_003E8__1;
					if (_003C_003E8__1 != null)
					{
						float num34 = num31 + (float)obj16.playerPos;
						float num35 = num32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rax_v24 (EnemySpecialAttackManyRandom+<>c__DisplayClass8_0)+1C]");
						float num36 = num35 + 0f;
						float num37 = num33;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rax_v24 (EnemySpecialAttackManyRandom+<>c__DisplayClass8_0)+20]");
						float num38 = num37 + 0f;
						if (_003C_003E8__1 != null)
						{
							obj15.playerPos = (Vector3)num34;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r15_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+50]");
							if ((nint)0 == 0)
							{
								goto IL_0be6;
							}
							if (_003C_003E8__1 != null)
							{
								GameManager instance4 = GameManager.Instance;
								if ((object)GameManager.Instance != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
									int layerMask2 = default(int);
									RaycastHit[] array2 = Physics.RaycastAll((Vector3)(&num29), (Vector3)(&vector2), 999f, layerMask2);
									if (array2 != null)
									{
										if (array2.Length != 0)
										{
											_003C_003Ec__DisplayClass8_0 obj17 = _003C_003E8__1;
											RaycastHit raycastHit2 = SpawnPositions.FindHitClosestToPlayerY(array2, out System.Runtime.CompilerServices.Unsafe.As<object, bool>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160)));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1257 @ rax_v41 (UnityEngine.RaycastHit)+10]");
											_ = 0;
											_ = raycastHit2.m_Distance;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
											if (_003C_003E8__1 == null)
											{
												goto IL_0a3b;
											}
											object playerPos = default(object);
											obj17.playerPos = (Vector3)playerPos;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v42+8]");
											_ = 0;
										}
										goto IL_0be6;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0a3b;
			IL_0a84:
			return result;
			IL_0c0d:
			result = true;
			goto IL_0a84;
			IL_0479:
			EnemySpecialAttackManyRandom enemySpecialAttackManyRandom = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r15_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+60]");
			IEnumerator enumerator = enemySpecialAttackManyRandom.WaitForSecondsCustom(0f);
			_003C_003E2__current = enumerator;
			_003C_003E1__state = 2;
			goto IL_0c0d;
			IL_0be6:
			if (_003C_003E8__1 == null)
			{
				goto IL_0a3b;
			}
			Action completeAction2 = delegate
			{
				//IL_000f: Expected O, but got Ref
				object obj18 = default(object);
				_003C_003E8__1._003C_003E4__this.SpawnHitEffect((Vector3)(&obj18));
			};
			_003C_003E4__this.CreateWarningSphere((Vector3)(&vector2), completeAction2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r15_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+58]");
			_ = (nint)0 + (nint)1;
			EnemySpecialAttackManyRandom enemySpecialAttackManyRandom2 = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r15_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+60]");
			IEnumerator enumerator2 = enemySpecialAttackManyRandom2.WaitForSecondsCustom(0f);
			_003C_003E2__current = enumerator2;
			_003C_003E1__state = 1;
			goto IL_0c0d;
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

	public bool grounded;

	public bool predictive = true;

	public int circles = 4;

	private int numToSpawn;

	private int numSpawned;

	public float delayBetweenCircles = 0.2f;

	public float margin = 1f;

	protected override void Init()
	{
		numToSpawn = 0;
		_003CDoAttack_003Ed__8 obj = new _003CDoAttack_003Ed__8(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator DoAttack()
	{
		_003CDoAttack_003Ed__8 obj = new _003CDoAttack_003Ed__8(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void SpawnHitEffect(Vector3 pos)
	{
		//IL_004b: Expected O, but got Ref
		//IL_00e7: Expected O, but got Ref
		//IL_0097: Expected O, but got Ref
		//IL_0161: Expected O, but got Ref
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
			float damage = base._003CspecialAttack_003Ek__BackingField.GetDamage(enemy);
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			DcFlags damageFlags = GetDamageFlags();
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage, 25f, (Vector3)(&num), ignoreShield, damageSource, flags, damageEffect);
			if (eAttack == EEnemyAttack.PoisonSpikes)
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
