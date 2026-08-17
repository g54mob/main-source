using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Assets.Scripts.Game.Spawning;
using Cpp2ILInjected;
using UnityEngine;

public class EnemySpecialAttackPrefabMulti : EnemySpecialAttackPrefab
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public Vector3 pos;

		public EnemySpecialAttackPrefabMulti _003C_003E4__this;

		internal unsafe void _003CDoAttack_003Eb__0()
		{
			//IL_000f: Expected O, but got Ref
			object obj = default(object);
			_003C_003E4__this.SpawnHitEffect((Vector3)(&obj));
		}
	}

	private sealed class _003CDoAttack_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemySpecialAttackPrefabMulti _003C_003E4__this;

		private List<Vector3>[] _003CpositionsList_003E5__2;

		private int _003Ci_003E5__3;

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
			//IL_0048: Expected I4, but got I8
			//IL_05f1: Expected I4, but got I8
			//IL_07c3: Expected I4, but got O
			//IL_0981: Expected F4, but got I
			//IL_02a9: Expected O, but got I4
			//IL_0739: Expected O, but got Ref
			//IL_02da: Expected O, but got Ref
			//IL_02ec: Expected O, but got Ref
			//IL_02ec: Expected O, but got Ref
			//IL_0201: Expected I, but got O
			//IL_084a: Expected I, but got O
			//IL_057a: Expected O, but got Ref
			//IL_057a: Expected O, but got I
			//IL_046f: Expected O, but got Ref
			//IL_046f: Expected O, but got Ref
			//IL_04ec: Expected F4, but got O
			//IL_04fd: Expected F4, but got I
			EnemySpecialAttackPrefab enemySpecialAttackPrefab = _003C_003E4__this;
			object obj4 = default(object);
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)enemySpecialAttackPrefab.enemy != null)
				{
					Vector3 feetPosition = enemySpecialAttackPrefab.enemy.GetFeetPosition();
					if ((object)MyPlayer.Instance != null)
					{
						Transform transform = MyPlayer.Instance.transform;
						if ((object)transform != null)
						{
							Vector3 position = transform.position;
							float num = position.z - feetPosition.z;
							float num2 = position.y - feetPosition.y;
							float num3 = position.x - feetPosition.x;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
							EnemySpecialAttack enemySpecialAttack = enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField;
							if (enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rsi_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+5C]");
								List<Vector3>[] array = new List<Vector3>[0];
								_003CpositionsList_003E5__2 = array;
								int num4 = 0;
								int num5 = 0;
								object obj = default(object);
								_003C_003Ec__DisplayClass7_0 obj2 = default(_003C_003Ec__DisplayClass7_0);
								while (true)
								{
									int num6 = num5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rsi_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+5C]");
									if ((nint)num6 >= (nint)0)
									{
										break;
									}
									List<Vector3>[] array2 = _003CpositionsList_003E5__2;
									List<Vector3> list = new List<Vector3>();
									if (_003CpositionsList_003E5__2 == null)
									{
										goto IL_07b5;
									}
									bool flag = list == null;
									List<Vector3> list2 = list;
									if (!flag)
									{
										nint num7 = (nint)array2;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
										bool flag2 = obj == null;
										list2 = list;
										if (flag2)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
											throw obj2;
										}
									}
									bool flag3 = num4 >= array2.Length;
									_003C_003Ec__DisplayClass7_0 obj3 = (_003C_003Ec__DisplayClass7_0)(object)list2;
									if (!flag3)
									{
										array2[num4] = list;
										num4++;
										num5 = num4;
										continue;
									}
									goto IL_07e1;
								}
								float num8 = enemySpecialAttack.attackRadius + enemySpecialAttack.attackRadius;
								Vector3 vector = (Vector3)0;
								float num9 = 99f;
								int num10 = 0;
								float num11 = num8;
								int num12 = 0;
								int num14 = default(int);
								float num15 = default(float);
								float num16 = default(float);
								float num35 = default(float);
								int num36 = default(int);
								object obj5 = default(object);
								float num38 = default(float);
								while (true)
								{
									int num13 = num12;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rsi_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+54]");
									if ((nint)num13 >= (nint)0)
									{
										break;
									}
									Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num14));
									Vector3 vector2 = (Quaternion)(&num15) * (Vector3)(&num16);
									EnemySpecialAttack enemySpecialAttack2 = enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField;
									if (enemySpecialAttackPrefab._003CspecialAttack_003Ek__BackingField != null)
									{
										float num17 = enemySpecialAttack2.attackRadius * vector2.x;
										float num18 = num17 + feetPosition.x;
										float num19 = enemySpecialAttack2.attackRadius * vector2.z;
										float num20 = num19 + feetPosition.z;
										bool flag4 = false;
										int num21 = 0;
										float z = feetPosition.z;
										while (true)
										{
											int num22 = num21;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rsi_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+5C]");
											if ((nint)num22 >= (nint)0)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebx\"");
											float num23 = 0f * num11;
											float num24 = num23;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rsi_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+60]");
											float num25 = num24 * 0f;
											float num26 = vector2.x * num25;
											float num27 = num26 + num18;
											float num28 = vector2.z * num25;
											float num29 = num28 + num20;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rsi_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+50]");
											if ((nint)0 != 0)
											{
												nint num30 = (nint)typeof(Vector3);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1399 @ rdx_v30 (Il2CppClass<UnityEngine.Vector3>)+B8]");
												nint num31 = 0;
												float num32 = (float)Vector3.upVector * num9;
												z = num32 + num27;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1400 @ rax_v56 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
												float num33 = 0f * num9;
												float num34 = num33 + num29;
												GameManager instance = GameManager.Instance;
												if ((object)GameManager.Instance != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
													RaycastHit[] array3 = Physics.RaycastAll((Vector3)(&num35), (Vector3)(&obj4), 999f, num36);
													if (array3 != null)
													{
														bool flag5 = array3.Length == 0;
														flag4 = (byte)num36 != 0;
														if (!flag5)
														{
															RaycastHit raycastHit = SpawnPositions.FindHitClosestToPlayerY(array3, out var _);
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
															num27 = (float)obj5;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1477 @ rax_v66+8]");
															num29 = 0f;
															vector = raycastHit.m_Point;
															flag4 = true;
														}
														num35 = z;
														num9 = 99f;
														goto IL_0813;
													}
												}
												goto IL_07b5;
											}
											goto IL_0813;
											IL_0813:
											_003C_003Ec__DisplayClass7_0 obj3 = (_003C_003Ec__DisplayClass7_0)(object)_003CpositionsList_003E5__2;
											if (_003CpositionsList_003E5__2 != null)
											{
												int num37 = num21;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v3 (EnemySpecialAttackPrefabMulti+<>c__DisplayClass7_0)+18]");
												if ((nint)num37 >= (nint)0)
												{
													goto IL_07e1;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v3 (EnemySpecialAttackPrefabMulti+<>c__DisplayClass7_0)+20+v314 @ rbx_v13 (System.Int32)*8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v3 (EnemySpecialAttackPrefabMulti+<>c__DisplayClass7_0)+20+v314 @ rbx_v13 (System.Int32)*8]");
													((List<Vector3>)0).Add((Vector3)(&num38));
													num21++;
													num11 = num8;
													continue;
												}
											}
											goto IL_07b5;
										}
										num10++;
										num12 = num10;
										continue;
									}
									goto IL_07b5;
								}
								_003Ci_003E5__3 = 0;
								goto IL_090b;
							}
						}
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_075b;
				}
				_003C_003E1__state = -1;
				int num39 = _003Ci_003E5__3 + 1;
				_003Ci_003E5__3 = num39;
				if ((object)_003C_003E4__this != null)
				{
					goto IL_090b;
				}
			}
			goto IL_07b5;
			IL_07e1:
			throw new IndexOutOfRangeException();
			IL_07b5:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_075b:
			return false;
			IL_090b:
			int num40 = _003Ci_003E5__3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rsi_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+5C]");
			if ((nint)num40 >= (nint)0)
			{
				goto IL_075b;
			}
			List<Vector3>[] array4 = _003CpositionsList_003E5__2;
			if (_003CpositionsList_003E5__2 != null)
			{
				int num41 = _003Ci_003E5__3;
				if (_003Ci_003E5__3 >= array4.Length)
				{
					goto IL_07e1;
				}
				if (array4[num41] != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18114D740");
					List<Vector3>.Enumerator enumerator = default(List<Vector3>.Enumerator);
					Vector3 pos = default(Vector3);
					while (true)
					{
						if (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass7_0();
							if (CS_0024_003C_003E8__locals4 == null)
							{
								break;
							}
							CS_0024_003C_003E8__locals4._003C_003E4__this = _003C_003E4__this;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
							CS_0024_003C_003E8__locals4.pos = pos;
							Action completeAction = delegate
							{
								//IL_000f: Expected O, but got Ref
								object obj6 = default(object);
								CS_0024_003C_003E8__locals4._003C_003E4__this.SpawnHitEffect((Vector3)(&obj6));
							};
							_003C_003E4__this.CreateWarningSphere((Vector3)(&obj4), completeAction);
							bool flag4 = false;
							continue;
						}
						enumerator.Dispose();
						EnemySpecialAttackPrefabMulti enemySpecialAttackPrefabMulti = _003C_003E4__this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rsi_v1 (Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations.EnemySpecialAttackPrefab)+64]");
						IEnumerator enumerator2 = enemySpecialAttackPrefabMulti.WaitForSecondsCustom(0f);
						_003C_003E2__current = enumerator2;
						_003C_003E1__state = 1;
						return true;
					}
					throw new NullReferenceException();
				}
			}
			goto IL_07b5;
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

	public int numLines = 1;

	public int degreesBetweenLines = 30;

	public int numHits = 5;

	public float hitsSpacingMultiplier = 1f;

	public float delayBetweenHits = 0.3f;

	private int numSpawned;

	protected unsafe override void Init()
	{
		//IL_0037: Expected O, but got Ref
		numSpawned = 0;
		Transform transform = attackEffectPrefab.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
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

	private unsafe void SpawnHitEffect(Vector3 pos)
	{
		//IL_004b: Expected O, but got Ref
		//IL_00e7: Expected O, but got Ref
		//IL_0187: Expected O, but got I4
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
		}
		int num3 = numSpawned + 1;
		object obj = numHits * numLines;
		numSpawned = num3;
		if (num3 >= (nint)obj)
		{
			ReturnToPool();
		}
	}
}
