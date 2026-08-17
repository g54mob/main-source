using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Game.Spawning.New;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.MapGeneration;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements.Experimental;
using Utility;

namespace Assets.Scripts.Actors.Enemies;

public class Enemy : MonoBehaviour
{
	private sealed class _003CDespawn_003Ed__111 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Enemy _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003CdesiredHeight_003E5__3;

		private Vector3 _003ClocalPos_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDespawn_003Ed__111(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_029c: Expected I4, but got I8
			//IL_04a1: Expected I4, but got O
			//IL_0063: Invalid comparison between I4 and F4
			//IL_02ec: Invalid comparison between I4 and F4
			//IL_0337: Expected F4, but got I4
			//IL_0410: Expected O, but got Ref
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Expected F4, but got Unknown
			//IL_0360: Expected O, but got Ref
			//IL_01a1: Expected O, but got F4
			Enemy enemy = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					if (enemy.state == EEnemyState.Teleporting || !(0f < enemy._003Chp_003Ek__BackingField))
					{
						goto IL_0485;
					}
					if ((object)enemy.collider != null)
					{
						enemy.collider.enabled = false;
						if ((object)enemy.enemyMovement != null)
						{
							enemy.enemyMovement.StopMovement();
							enemy.state = EEnemyState.Teleporting;
							_003Ctime_003E5__2 = 0f;
							float num = enemy._003CmeshHeight_003Ek__BackingField * 1.25f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
							float num2 = num ^ 0;
							_003CdesiredHeight_003E5__3 = num2;
							if ((object)enemy.renderer != null)
							{
								Transform transform = enemy.renderer.transform;
								if ((object)transform != null)
								{
									Vector3 localPosition = transform.localPosition;
									_003ClocalPos_003E5__4 = (Vector3)localPosition.x;
									_ = localPosition.z;
									PoolManager instance = PoolManager.Instance;
									if ((object)PoolManager.Instance != null && instance.enemySpawnFxPool != null)
									{
										GameObject gameObject = instance.enemySpawnFxPool.Get();
										if (!(gameObject != null))
										{
											goto IL_04f4;
										}
										if ((object)gameObject != null)
										{
											EnemySpawnParticles component = gameObject.GetComponent<EnemySpawnParticles>();
											if ((object)component != null)
											{
												component.Set(_003C_003E4__this);
												goto IL_04f4;
											}
										}
									}
								}
							}
						}
					}
				}
				goto IL_0493;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_0485;
			}
			_003C_003E1__state = -1;
			goto IL_04f4;
			IL_0485:
			return false;
			IL_0493:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_04f4:
			float num3 = default(float);
			if (!(1f > _003Ctime_003E5__2))
			{
				if ((object)_003C_003E4__this != null)
				{
					enemy.state = EEnemyState.Default;
					if ((object)enemy.renderer != null)
					{
						Transform transform2 = enemy.renderer.transform;
						if ((object)transform2 != null)
						{
							transform2.localPosition = (Vector3)(&num3);
							if ((object)enemy.collider != null)
							{
								enemy.collider.enabled = true;
								if ((object)enemy.enemyMovement != null)
								{
									enemy.enemyMovement.StartMovement();
									_003C_003E4__this.ReleaseToPool();
									goto IL_0485;
								}
							}
						}
					}
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				float num4 = MyTime.deltaTime / enemy.teleportTime;
				float num5 = Easing.InOutQuad(_003Ctime_003E5__2 = num4 + _003Ctime_003E5__2);
				if (!(0f > num5))
				{
					if (num5 > 1f)
					{
						num5 = 1f;
					}
				}
				else
				{
					num5 = 0f;
				}
				if ((object)enemy.renderer != null)
				{
					Transform transform3 = enemy.renderer.transform;
					if ((object)transform3 != null)
					{
						transform3.localPosition = (Vector3)(&num3);
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			goto IL_0493;
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

	private sealed class _003CStartTeleporting_003Ed__110 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Enemy _003C_003E4__this;

		public bool skipStart;

		public Vector3 toPosition;

		private float _003Ctime_003E5__2;

		private float _003CdesiredHeight_003E5__3;

		private Vector3 _003ClocalPos_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CStartTeleporting_003Ed__110(int _003C_003E1__state)
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
			//IL_0082: Expected I4, but got I8
			//IL_0a19: Expected I4, but got O
			//IL_001d: Expected O, but got I4
			//IL_006e: Expected I4, but got I8
			//IL_005a: Expected I4, but got I8
			//IL_0101: Expected O, but got I
			//IL_0137: Expected O, but got I
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Expected F4, but got Unknown
			//IL_0397: Expected O, but got Ref
			//IL_028e: Invalid comparison between I4 and F4
			//IL_02d9: Expected F4, but got I4
			//IL_01b5: Expected O, but got I
			//IL_03ee: Expected O, but got I
			//IL_0b7f: Expected I, but got O
			//IL_08bc: Expected O, but got I
			//IL_07a0: Invalid comparison between I4 and F4
			//IL_01f2: Expected O, but got F4
			//IL_02ef: Expected O, but got I
			//IL_07eb: Expected F4, but got I4
			//IL_040a: Expected O, but got Ref
			//IL_0ac7: Expected I, but got O
			//IL_08eb: Expected O, but got Ref
			//IL_030b: Expected O, but got Ref
			//IL_0947: Expected O, but got I
			//IL_0812: Expected O, but got I
			//IL_046b: Expected O, but got I
			//IL_0ccf: Expected I, but got O
			//IL_082e: Expected O, but got Ref
			//IL_0530: Expected O, but got Ref
			//IL_055f: Expected O, but got Ref
			//IL_05ab: Expected O, but got Ref
			//IL_05f8: Expected O, but got I
			//IL_09f8: Expected O, but got I
			//IL_0659: Expected O, but got Ref
			//IL_0682: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			Component component = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj3 = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						goto IL_09fd;
					}
					_003C_003E1__state = -1;
					goto IL_0a42;
				}
				_003C_003E1__state = -1;
				goto IL_021e;
			}
			_003C_003E1__state = -1;
			if ((object)_003C_003E4__this != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+A0]");
				if ((nint)0 == 1)
				{
					goto IL_09fd;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+50]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+50]");
					((Collider)0).enabled = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+58]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+58]");
						((EnemyMovementRb)0).StopMovement();
						_ = 1;
						_003Ctime_003E5__2 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+40]");
						float num = 0f * 1.25f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
						float num2 = num ^ 0;
						_003CdesiredHeight_003E5__3 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+30]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+30]");
							Transform transform = ((Component)0).transform;
							if ((object)transform != null)
							{
								Vector3 localPosition = transform.localPosition;
								_003ClocalPos_003E5__4 = (Vector3)localPosition.x;
								_ = localPosition.z;
								if (!skipStart)
								{
									goto IL_021e;
								}
								goto IL_035d;
							}
						}
					}
				}
			}
			goto IL_0a0b;
			IL_09fd:
			return false;
			IL_0742:
			_003Ctime_003E5__2 = 0f;
			goto IL_0a42;
			IL_021e:
			if (!(1f > _003Ctime_003E5__2))
			{
				if ((object)_003C_003E4__this != null)
				{
					goto IL_035d;
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				float num3 = MyTime.deltaTime;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+100]");
				float num4 = num3 / 0f;
				float num5 = Easing.InOutQuad(_003Ctime_003E5__2 = num4 + _003Ctime_003E5__2);
				if (!(0f > num5))
				{
					if (num5 > 1f)
					{
						num5 = 1f;
					}
				}
				else
				{
					num5 = 0f;
				}
				float num6 = _003CdesiredHeight_003E5__3 * num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+30]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+30]");
					Transform transform2 = ((Component)0).transform;
					nint num7 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rcx_v57 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num8 = 0;
					float num9 = num6 * (float)Vector3.upVector;
					float num10 = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rdx_v41 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
					float num11 = num10 * 0f;
					float num12 = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rdx_v41 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					float num13 = num12 * 0f;
					float num14 = num9 + (float)_003ClocalPos_003E5__4;
					float num15 = num11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Enemies.Enemy+<StartTeleporting>d__110)+44]");
					float num16 = num15 + 0f;
					float num17 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Enemies.Enemy+<StartTeleporting>d__110)+48]");
					float num18 = num17 + 0f;
					if ((object)transform2 != null)
					{
						Vector3 localPosition2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						transform2.localPosition = localPosition2;
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						goto IL_0d79;
					}
				}
			}
			goto IL_0a0b;
			IL_0a0b:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0a42:
			if (!(1f > _003Ctime_003E5__2))
			{
				if ((object)_003C_003E4__this != null)
				{
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+30]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+30]");
						Transform transform3 = ((Component)0).transform;
						if ((object)transform3 != null)
						{
							Vector3 localPosition3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Enemies.Enemy+<StartTeleporting>d__110)+48]");
							_ = 0;
							_ = _003ClocalPos_003E5__4;
							transform3.localPosition = localPosition3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+50]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+50]");
								((Collider)0).enabled = true;
								MyPlayer instance = MyPlayer.Instance;
								if ((object)MyPlayer.Instance != null)
								{
									PlayerInventory inventory = instance.inventory;
									if (instance.inventory != null && inventory.statusEffects != null)
									{
										if (!inventory.statusEffects.HasStatusEffect(EStatusEffect.TimeFreeze))
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+58]");
											if ((nint)0 == 0)
											{
												goto IL_0a0b;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+58]");
											((EnemyMovementRb)0).StartMovement();
										}
										goto IL_09fd;
									}
								}
							}
						}
					}
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				float num19 = MyTime.deltaTime;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+100]");
				float num20 = num19 / 0f;
				float num21 = Easing.InOutQuad(_003Ctime_003E5__2 = num20 + _003Ctime_003E5__2);
				if (!(0f > num21))
				{
					if (num21 > 1f)
					{
						num21 = 1f;
					}
				}
				else
				{
					num21 = 0f;
				}
				float num22 = 0f - _003CdesiredHeight_003E5__3;
				float num23 = num22 * num21;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+30]");
				if ((nint)0 != 0)
				{
					float num24 = num23 + _003CdesiredHeight_003E5__3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+30]");
					Transform transform4 = ((Component)0).transform;
					nint num25 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rcx_v17 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num26 = 0;
					float num27 = num24 * (float)Vector3.upVector;
					float num28 = num24;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
					float num29 = num28 * 0f;
					float num30 = num24;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					float num31 = num30 * 0f;
					float num32 = num27 + (float)_003ClocalPos_003E5__4;
					float num33 = num29;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Enemies.Enemy+<StartTeleporting>d__110)+44]");
					float num34 = num33 + 0f;
					float num35 = num31;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Enemies.Enemy+<StartTeleporting>d__110)+48]");
					float num36 = num35 + 0f;
					if ((object)transform4 != null)
					{
						Vector3 localPosition4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						transform4.localPosition = localPosition4;
						_003C_003E2__current = null;
						_003C_003E1__state = 2;
						goto IL_0d79;
					}
				}
			}
			goto IL_0a0b;
			IL_035d:
			Transform transform5 = _003C_003E4__this.transform;
			if ((object)transform5 != null)
			{
				Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Enemies.Enemy+<StartTeleporting>d__110)+34]");
				_ = 0;
				_ = toPosition;
				transform5.position = position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+30]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+30]");
					Transform transform6 = ((Component)0).transform;
					nint num37 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rcx_v30 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num38 = 0;
					_ = Vector3.upVector;
					float num39 = (float)Vector3.upVector * _003CdesiredHeight_003E5__3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-25]");
					float num40 = 0f * _003CdesiredHeight_003E5__3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rdx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					float num41 = 0f * _003CdesiredHeight_003E5__3;
					float num42 = num39 + (float)_003ClocalPos_003E5__4;
					float num43 = num40;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Enemies.Enemy+<StartTeleporting>d__110)+44]");
					float num44 = num43 + 0f;
					float num45 = num41;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Enemies.Enemy+<StartTeleporting>d__110)+48]");
					float num46 = num45 + 0f;
					if ((object)transform6 != null)
					{
						Vector3 localPosition5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						transform6.localPosition = localPosition5;
						Transform transform7 = _003C_003E4__this.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+90]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+90]");
							Transform transform8 = ((Component)0).transform;
							if ((object)transform8 != null)
							{
								Vector3 position2 = transform8.position;
								Transform transform9 = _003C_003E4__this.transform;
								if ((object)transform9 != null)
								{
									Vector3 position3 = transform9.position;
									float num47 = position2.x - position3.x;
									float num48 = position2.y - position3.y;
									float num49 = position2.z - position3.z;
									Vector3 v = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
									Vector3 vector = VectorExtensions.XZVector(v);
									Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
									_ = vector.x;
									_ = vector.z;
									Quaternion quaternion = Quaternion.LookRotation(forward);
									if ((object)transform7 != null)
									{
										Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
										_ = quaternion.x;
										transform7.rotation = rotation;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+90]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+90]");
											Transform transform10 = ((Component)0).transform;
											if ((object)transform10 != null)
											{
												Vector3 position4 = transform10.position;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+58]");
												if ((nint)0 != 0)
												{
													Vector3 desiredRotation = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
													_ = position4.x;
													_ = position4.z;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdi_v1 (UnityEngine.Component)+58]");
													((EnemyMovementRb)0).SetDesiredRotation(desiredRotation);
													PoolManager instance2 = PoolManager.Instance;
													if ((object)PoolManager.Instance != null && instance2.enemySpawnFxPool != null)
													{
														GameObject gameObject = instance2.enemySpawnFxPool.Get();
														if (!(gameObject != null))
														{
															goto IL_0742;
														}
														if ((object)gameObject != null)
														{
															EnemySpawnParticles component2 = gameObject.GetComponent<EnemySpawnParticles>();
															if ((object)component2 != null)
															{
																component2.Set(_003C_003E4__this);
																goto IL_0742;
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
					}
				}
			}
			goto IL_0a0b;
			IL_0d79:
			return true;
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

	private EnemyData _003CenemyData_003Ek__BackingField;

	public AnimatedMesh animatedMesh;

	public Renderer renderer;

	public EnemyRenderer enemyRenderer;

	private float _003CmeshHeight_003Ek__BackingField;

	private float _003CmeshRadius_003Ek__BackingField;

	public Rigidbody rb;

	public CapsuleCollider collider;

	public EnemyMovementRb enemyMovement;

	public Material whiteMaterial;

	public EnemyDissolve dissolve;

	private float flashTime;

	private Vector3 _003CfeetOffset_003Ek__BackingField;

	private float _003Chp_003Ek__BackingField;

	public float maxHp;

	private uint _003Cid_003Ek__BackingField;

	private int _003CwaveNumber_003Ek__BackingField;

	private Rigidbody _003Ctarget_003Ek__BackingField;

	private float despawnAtTime;

	private float _003CspawnedAtTime_003Ek__BackingField;

	public EEnemyState state;

	private float eliteScaleMultiplier;

	private SpecialAttackController specialAttackController;

	public static int deaths;

	public static Action<Enemy, DamageContainer> A_EnemyDied;

	public static Action<Enemy> A_EnemyDiedPre;

	public static Action<Enemy> A_EnemySpawned;

	public static Action<Enemy> A_EnemyReleasedFromPool;

	public static Action<Enemy> A_TargetOfInterestSpawn;

	public static Action<Enemy, DamageContainer> A_Damage;

	public Action<Enemy, DamageContainer> A_DamageNonStatic;

	public static Action<Enemy> A_HealthChange;

	private float controlHp;

	private EEnemyFlag enemyFlag;

	private float _003CextraKnockbackRes_003Ek__BackingField;

	private float maxDespawnTime;

	private float speedMultiplier;

	private EnemyStatusSymbols statusSymbols;

	private float armor;

	private int _003CarmorCurrent_003Ek__BackingField;

	private int _003CarmorMax_003Ek__BackingField;

	public static Action<Enemy, int, int> A_ArmorChanged;

	private EEnemyFlag eliteChallengeFlags;

	private Vector3 defaultScale;

	private Outline outline;

	public float teleportTime;

	public static float bossTeleportTime = 2f;

	public static float defaultTeleportTime = 0.75f;

	public static Action A_HpTamper;

	private float echoDamage;

	private float stopFlashTime;

	private float readyToFlashTime;

	public float flashInterval;

	private bool flashing;

	private bool isInvulnerable;

	public static Action<Enemy, bool> A_InvulnerableChanged;

	private bool isDyingNextFrame;

	private bool deathFunctionCalled;

	private float startTeleportThresholdDistance;

	private float lastTeleportTime;

	private List<AddDebuffContainer> _toAddBuffer;

	public Dictionary<EDebuff, EnemyDebuff> debuffs;

	public HashSet<EDebuff> debuffsToRemove;

	public Dictionary<EDebuff, AddDebuffContainer> debuffsToAdd;

	public Action<EDebuff> A_DebuffAdded;

	public Action<EDebuff> A_DebuffRemoved;

	private Dictionary<EDebuff, int> debuffCounts;

	private float nextVerifyTime;

	private float nextTeleportTimeCheck;

	private float teleportCheckInterval;

	private Transform _003CfollowTarget_003Ek__BackingField;

	private float minStayAtDistance;

	private float maxStayAtDistance;

	private bool allowSpecialAttacks;

	private float basePowerupDropChance;

	public EnemyData enemyData
	{
		get
		{
			return _003CenemyData_003Ek__BackingField;
		}
		private set
		{
			_003CenemyData_003Ek__BackingField = value;
		}
	}

	public float meshHeight
	{
		get
		{
			return _003CmeshHeight_003Ek__BackingField;
		}
		private set
		{
			_003CmeshHeight_003Ek__BackingField = value;
		}
	}

	public float meshRadius
	{
		get
		{
			return _003CmeshRadius_003Ek__BackingField;
		}
		private set
		{
			_003CmeshRadius_003Ek__BackingField = value;
		}
	}

	public unsafe Vector3 feetOffset
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003CfeetOffset_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Assets.Scripts.Actors.Enemies.Enemy)+7C]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003CfeetOffset_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	public float hp
	{
		get
		{
			return _003Chp_003Ek__BackingField;
		}
		set
		{
			_003Chp_003Ek__BackingField = value;
		}
	}

	public uint id
	{
		get
		{
			return _003Cid_003Ek__BackingField;
		}
		private set
		{
			_003Cid_003Ek__BackingField = value;
		}
	}

	public int waveNumber
	{
		get
		{
			return _003CwaveNumber_003Ek__BackingField;
		}
		set
		{
			_003CwaveNumber_003Ek__BackingField = value;
		}
	}

	public Rigidbody target
	{
		get
		{
			return _003Ctarget_003Ek__BackingField;
		}
		private set
		{
			_003Ctarget_003Ek__BackingField = value;
		}
	}

	public float spawnedAtTime
	{
		get
		{
			return _003CspawnedAtTime_003Ek__BackingField;
		}
		private set
		{
			_003CspawnedAtTime_003Ek__BackingField = value;
		}
	}

	public float extraKnockbackRes
	{
		get
		{
			return _003CextraKnockbackRes_003Ek__BackingField;
		}
		set
		{
			_003CextraKnockbackRes_003Ek__BackingField = value;
		}
	}

	public int armorCurrent
	{
		get
		{
			return _003CarmorCurrent_003Ek__BackingField;
		}
		private set
		{
			_003CarmorCurrent_003Ek__BackingField = value;
		}
	}

	public int armorMax
	{
		get
		{
			return _003CarmorMax_003Ek__BackingField;
		}
		private set
		{
			_003CarmorMax_003Ek__BackingField = value;
		}
	}

	public Transform followTarget
	{
		get
		{
			return _003CfollowTarget_003Ek__BackingField;
		}
		private set
		{
			_003CfollowTarget_003Ek__BackingField = value;
		}
	}

	public unsafe void InitEnemy(uint id, EnemyData enemyData, Vector3 pos, int waveNumber, EEnemyFlag flag = EEnemyFlag.None, bool canBeElite = true, float extraSizeMultiplier = 1f)
	{
		//IL_0008: Expected O, but got Ref
		//IL_10d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d6: Expected O, but got Unknown
		//IL_10e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_10eb: Expected O, but got Unknown
		//IL_008d: Expected O, but got I4
		//IL_0197: Expected I, but got O
		//IL_01a5: Expected O, but got Ref
		//IL_01f7: Expected O, but got Ref
		//IL_026b: Expected O, but got Ref
		//IL_02dc: Expected O, but got I
		//IL_0c0f: Expected I, but got O
		//IL_0346: Expected O, but got Ref
		//IL_0391: Expected O, but got Ref
		//IL_0c9d: Expected I, but got O
		//IL_0431: Expected O, but got Ref
		//IL_0493: Invalid comparison between F4 and I4
		//IL_0d0d: Expected I, but got O
		//IL_0590: Expected O, but got Ref
		//IL_05bf: Expected O, but got Ref
		//IL_0dc6: Expected I, but got O
		//IL_0ddf: Expected F4, but got O
		//IL_0e17: Expected O, but got I
		//IL_0e34: Expected O, but got I
		//IL_0ea3: Invalid comparison between F4 and I4
		//IL_0ecc: Expected O, but got I4
		//IL_0643: Expected I, but got O
		//IL_0ef7: Expected O, but got Ref
		//IL_09ba: Expected O, but got F4
		//IL_09fb: Invalid comparison between F4 and I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		deathFunctionCalled = false;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = base.gameObject;
		int layer = LayerMask.NameToLayer("Enemy");
		gameObject2.layer = layer;
		_003CenemyData_003Ek__BackingField = enemyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+5F]");
		_003CwaveNumber_003Ek__BackingField = 0;
		_003Cid_003Ek__BackingField = id;
		_003CspawnedAtTime_003Ek__BackingField = MyTime.time;
		isInvulnerable = false;
		speedMultiplier = 1f;
		echoDamage = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		enemyFlag = EEnemyFlag.None;
		_003CarmorCurrent_003Ek__BackingField = 0;
		armor = 0f;
		Action<Enemy, int, int> a_ArmorChanged = A_ArmorChanged;
		bool flag2 = A_ArmorChanged == null;
		Vector3 vector = pos;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v82 @ r10_v2 (System.Action`3<Assets.Scripts.Actors.Enemies.Enemy, System.Int32, System.Int32>)+18] (should have been resolved before IL gen)");
			vector = (Vector3)0;
		}
		_003CextraKnockbackRes_003Ek__BackingField = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		object obj4 = default(object);
		object obj3 = obj4 ^ 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+6F]");
		object obj5 = 0 & obj3;
		if (obj5 != null)
		{
			float eliteChance = EnemyStats.GetEliteChance(enemyData);
			double num = MyRandom.random.NextDouble();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
			if ((nint)MyRandom.random > 0)
			{
				EEnemyFlag eEnemyFlag = enemyFlag | EEnemyFlag.Elite;
				enemyFlag = eEnemyFlag;
			}
		}
		float stat = PlayerStats.GetStat(EStat.EnemySizeMultiplier);
		float num2 = stat * enemyData.rendererScale;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		object obj6 = default(object);
		if (obj6 != null)
		{
			num2 *= eliteScaleMultiplier;
		}
		animatedMesh.SetAnimation(enemyData.animation);
		Transform transform = renderer.transform;
		nint num3 = (nint)typeof(Vector3);
		Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1024 @ rcx_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		_ = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rax_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		transform.localScale = localScale;
		Transform transform2 = renderer.transform;
		Vector3 euler = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
		float num5 = (float)enemyData.rendererRotationOffset * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [enemyData @ r8 (EnemyData)+44]");
		float num6 = 0f * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [enemyData @ r8 (EnemyData)+40]");
		float num7 = 0f * ((float)Math.PI / 180f);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		Quaternion localRotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
		_ = quaternion.x;
		transform2.localRotation = localRotation;
		enemyRenderer.Set(enemyData);
		dissolve.enabled = false;
		Bounds bounds = renderer.bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v34 (UnityEngine.Bounds)+10]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v34 (UnityEngine.Bounds)+10]");
		object obj7 = num8 + 0;
		float num9 = (float)obj7 * 0.5f;
		float num10 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
		float num11 = num10 * 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [enemyData @ r8 (EnemyData)+34]");
		float num12 = 0f + num9;
		Transform transform3 = renderer.transform;
		nint num13 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rcx_v31 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num14 = 0;
		float num15 = num12 * (float)Vector3.downVector;
		float num16 = num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
		float num17 = num16 * 0f;
		float num18 = num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
		float num19 = num18 * 0f;
		float num20 = num15 * num11;
		float num21 = num17 * num11;
		float num22 = num19 * num11;
		Vector3 localPosition = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
		transform3.localPosition = localPosition;
		Transform transform4 = renderer.transform;
		Vector3 localPosition2 = transform4.localPosition;
		Vector3 localPosition3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
		float num23 = num11 * (float)enemyData.rendererOffset;
		float num24 = num23 + localPosition2.x;
		_ = localPosition2.y;
		float num25 = num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [enemyData @ r8 (EnemyData)+38]");
		float num26 = num25 * 0f;
		float num27 = num26 + localPosition2.z;
		transform4.localPosition = localPosition3;
		Transform transform5 = renderer.transform;
		nint num28 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rcx_v38 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num29 = 0;
		float num30 = num11 * (float)Vector3.oneVector;
		float num31 = num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdx_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num32 = num31 * 0f;
		float num33 = num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdx_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num34 = num33 * 0f;
		Vector3 localScale2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
		transform5.localScale = localScale2;
		Bounds bounds2 = renderer.bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v44 (UnityEngine.Bounds)+10]");
		float num35 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v44 (UnityEngine.Bounds)+10]");
		float num36 = num35 + 0f;
		_003CmeshHeight_003Ek__BackingField = num36;
		if (enemyData.overrideHeight > 0f)
		{
			float num37 = num11 * enemyData.overrideHeight;
			_003CmeshHeight_003Ek__BackingField = num37;
		}
		Bounds bounds3 = renderer.bounds;
		float num38 = (float)bounds3.m_Extents + (float)bounds3.m_Extents;
		Bounds bounds4 = renderer.bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v46 (UnityEngine.Bounds)+14]");
		float num39 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v46 (UnityEngine.Bounds)+14]");
		float num40 = num39 + 0f;
		if (num38 < num40)
		{
			num38 = num40;
		}
		_003CmeshRadius_003Ek__BackingField = num38;
		dissolve.Reset();
		rb.mass = enemyData.mass;
		nint num41 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ rax_v50 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num42 = 0;
		float num43 = _003CmeshHeight_003Ek__BackingField * 0.5f;
		float num44 = num43 * (float)Vector3.upVector;
		float num45 = num43;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1139 @ rcx_v46 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		float num46 = num45 * 0f;
		float num47 = num43;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1139 @ rcx_v46 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num48 = num47 * 0f;
		float num49 = num44 + pos.x;
		float num50 = num46 + pos.y;
		float num51 = num48 + pos.z;
		Transform transform6 = base.transform;
		Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
		transform6.position = position;
		Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
		rb.position = position2;
		enemyMovement.Init();
		float radius = num11 * enemyData.colliderRadius;
		collider.radius = radius;
		collider.height = _003CmeshHeight_003Ek__BackingField;
		_ = enemyData.colliderCenter;
		nint num52 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rdx_v39 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num53 = 0;
		float num54 = (float)Vector3.zeroVector;
		_ = Vector3.zeroVector;
		float num55 = (float)enemyData.colliderCenter - (float)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-5D]");
		nint num56 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-4D]");
		object obj8 = num56 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [enemyData @ r8 (EnemyData)+5C]");
		nint num57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1168 @ rax_v58 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj9 = num57 - 0;
		object obj10 = obj8 * obj8;
		float num58 = num55 * num55;
		object obj11 = obj9 * obj9;
		float num59 = (float)obj10 + num58;
		float num60 = num59 + (float)obj11;
		bool flag3 = 9.9999994E-11f < num60;
		float num61 = 9.9999994E-11f - num60;
		bool flag4 = num61 == 0f;
		bool flag5 = !flag3;
		bool flag6 = !flag4;
		object obj12 = flag6 & flag5;
		if (obj12 != null)
		{
			nint num62 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdx_v79 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num63 = 0;
			_ = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1213 @ rax_v161 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
		}
		else
		{
			float num64 = num11 * (float)enemyData.colliderCenter;
			float num65 = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [enemyData @ r8 (EnemyData)+58]");
			num54 = num65 * 0f;
			float num66 = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [enemyData @ r8 (EnemyData)+5C]");
			float num67 = num66 * 0f;
		}
		Vector3 center = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
		collider.center = center;
		maxHp = (controlHp = (_003Chp_003Ek__BackingField = EnemyStats.GetHp(this)));
		PlayerMovement playerMovement = GameManager.Instance.GetPlayerMovement();
		_003Ctarget_003Ek__BackingField = playerMovement.rb;
		despawnAtTime = 0f;
		state = EEnemyState.Default;
		teleportTime = defaultTeleportTime;
		ClearAllDebuffs();
		allowSpecialAttacks = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		float num68;
		if ((nint)0 == 2)
		{
			SetBoss();
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
			if ((nint)0 == 4)
			{
				CheckStatusSymbols();
				teleportTime = bossTeleportTime;
				enemyMovement.Init();
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
				if ((nint)0 == 16)
				{
					SetBoss();
					EnemyManager instance = EnemyManager.Instance;
					SummonerController summonerController = instance.summonerController;
					if (summonerController._003CminibossCount_003Ek__BackingField != 0)
					{
						bool flag7 = summonerController._003CminibossCount_003Ek__BackingField != 1;
						num68 = 1f;
						if (!flag7)
						{
							num68 = 9f;
							goto IL_0869;
						}
					}
					else
					{
						num68 = 3f;
					}
					if (summonerController._003CminibossCount_003Ek__BackingField == 2)
					{
						num68 = 20f;
					}
					else if (summonerController._003CminibossCount_003Ek__BackingField == 3)
					{
						num68 = 40f;
					}
					goto IL_0869;
				}
			}
		}
		goto IL_0f4f;
		IL_0f4f:
		this.specialAttackController = null;
		EnemySpecialAttack[] specialAttacks = enemyData.specialAttacks;
		if (specialAttacks.Length != 0)
		{
			SpecialAttackController specialAttackController = new SpecialAttackController(this);
			this.specialAttackController = specialAttackController;
		}
		float enemyTeleportDistance = GameManager.GetEnemyTeleportDistance();
		float num69 = UnityEngine.Random.Range(1f, 2f);
		float num70 = num69 * enemyTeleportDistance;
		startTeleportThresholdDistance = num70;
		int num71 = UnityEngine.Random.Range(1, 3);
		float num72 = (float)num71 * 5f;
		teleportCheckInterval = num72;
		float num73 = MyTime.time + teleportCheckInterval;
		nextTeleportTimeCheck = num73;
		Transform transform7 = base.transform;
		Vector3 position3 = transform7.position;
		_003CStartTeleporting_003Ed__110 obj13 = new _003CStartTeleporting_003Ed__110(0);
		obj13._003C_003E1__state = 0;
		obj13._003C_003E4__this = this;
		obj13.toPosition = (Vector3)position3.x;
		_ = position3.z;
		obj13.skipStart = true;
		Coroutine coroutine = StartCoroutine(obj13);
		float num74 = enemyData.minStayAtDistance;
		bool flag8 = !(enemyData.minStayAtDistance > 0f);
		float num75 = 2f;
		if (!flag8)
		{
			float num76 = UnityEngine.Random.Range(0.75f, 1.5f);
			num75 = num76 * enemyData.minStayAtDistance;
			minStayAtDistance = num75;
			num74 = (maxStayAtDistance = num76 * enemyData.maxStayAtDistance) * 1.5f;
			startTeleportThresholdDistance = num74;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory = instance2.inventory;
		if (inventory.statusEffects.HasStatusEffect(EStatusEffect.TimeFreeze))
		{
			animatedMesh.Pause();
			enemyMovement.StopMovement();
		}
		Dictionary<EDebuff, int> dictionary = new Dictionary<EDebuff, int>();
		((Dictionary<System.Int32Enum, int>)(object)dictionary).Add((System.Int32Enum)8, 0);
		((Dictionary<System.Int32Enum, int>)(object)dictionary).Add((System.Int32Enum)2, 0);
		debuffCounts = dictionary;
		CheckStatusSymbols();
		Action<Enemy> a_EnemySpawned = A_EnemySpawned;
		if (A_EnemySpawned != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1696 @ r9_v6 (System.Action`1<Assets.Scripts.Actors.Enemies.Enemy>)+18] (should have been resolved before IL gen)");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		object obj14 = default(object);
		if (obj14 != null)
		{
			Action<Enemy> a_TargetOfInterestSpawn = A_TargetOfInterestSpawn;
			if (A_TargetOfInterestSpawn != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1741 @ r9_v8 (System.Action`1<Assets.Scripts.Actors.Enemies.Enemy>)+18] (should have been resolved before IL gen)");
			}
		}
		return;
		IL_0869:
		float num77 = EnemyStats.GetHp(this);
		float num78 = num77 * num68;
		controlHp = num78;
		float num79 = EnemyStats.GetHp(this);
		maxHp = (controlHp = (_003Chp_003Ek__BackingField = num79 * num68));
		enemyMovement.Init();
		vector = (Vector3)A_HealthChange;
		if (A_HealthChange != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v150 @ r9_v3 (UnityEngine.Vector3)+18] (should have been resolved before IL gen)");
		}
		goto IL_0f4f;
	}

	public void SetSpeedMultiplier(float f)
	{
		speedMultiplier = f;
	}

	public void SetSwarmMultiplierHp(float f)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_004c: Invalid comparison between I4 and F4
		//IL_005e: Expected F4, but got I4
		float num = f * _003Chp_003Ek__BackingField;
		object obj = num & -2147483649L;
		float num2;
		if ((nint)obj < 2139095040)
		{
			bool flag = !(0f < num);
			num2 = 0f;
			if (!flag)
			{
				num2 = num;
			}
		}
		else
		{
			num2 = 3.4028235E+38f;
		}
		_003Chp_003Ek__BackingField = num2;
		maxHp = num2;
		controlHp = num2;
	}

	public float GetSpeed()
	{
		//IL_0013: Invalid comparison between I4 and F4
		//IL_0097: Expected F4, but got I4
		EnemyData enemyData = _003CenemyData_003Ek__BackingField;
		if ((object)_003CenemyData_003Ek__BackingField == null)
		{
			goto IL_011c;
		}
		float result;
		if (0f < enemyData.minStayAtDistance)
		{
			EnemyMovementRb enemyMovementRb = enemyMovement;
			if ((object)enemyMovement == null)
			{
				goto IL_011c;
			}
			if (enemyMovementRb.distanceToTarget > minStayAtDistance)
			{
				bool flag = maxStayAtDistance > enemyMovementRb.distanceToTarget;
				result = 0f;
				if (flag)
				{
					goto IL_0151;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		object obj = default(object);
		float num = ((obj == null) ? 1f : 1.1f);
		float speed = EnemyStats.GetSpeed(_003CenemyData_003Ek__BackingField);
		float num2 = speed * num;
		result = num2 * speedMultiplier;
		goto IL_0151;
		IL_011c:
		throw new NullReferenceException();
		IL_0151:
		return result;
	}

	public float GetExtraKnockback()
	{
		return _003CextraKnockbackRes_003Ek__BackingField;
	}

	public int GetMoney()
	{
		return 1;
	}

	private void Freeze()
	{
		animatedMesh.Pause();
		enemyMovement.StopMovement();
	}

	private void UnFreeze()
	{
		animatedMesh.UnPause();
		enemyMovement.StartMovement();
	}

	private unsafe void CheckScale()
	{
		//IL_0022: Expected O, but got Ref
		Transform transform = renderer.transform;
		Vector3 vector = default(Vector3);
		transform.localScale = (Vector3)(&vector);
	}

	public void MakeChallenge()
	{
		CheckStatusSymbols();
	}

	private unsafe void CheckStatusSymbols()
	{
		//IL_00c0: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
			object obj2 = default(object);
			if (obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
				object obj3 = default(object);
				if (obj3 == null)
				{
					if (statusSymbols != null)
					{
						Transform transform = statusSymbols.transform;
						transform.parentInternal = null;
						Transform transform2 = statusSymbols.transform;
						object obj4 = default(object);
						transform2.localScale = (Vector3)(&obj4);
						GameObject gameObject = statusSymbols.gameObject;
						gameObject.SetActive(value: false);
						PoolManager instance = PoolManager.Instance;
						GameObject element = statusSymbols.gameObject;
						instance.enemyStatusSymbolsPool.Release(element);
						statusSymbols = null;
					}
					return;
				}
			}
		}
		if (statusSymbols == null)
		{
			AddStatusSymbols();
		}
		if (statusSymbols != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
			bool isElite = default(bool);
			bool isBoss = default(bool);
			bool isChallenge = default(bool);
			statusSymbols.Set(isElite, isBoss, isChallenge);
		}
	}

	public unsafe void Heal(int amount)
	{
		//IL_0042: Expected O, but got Ref
		//IL_0042: Expected O, but got Ref
		if ((_003Chp_003Ek__BackingField = (float)amount + _003Chp_003Ek__BackingField) > maxHp)
		{
			_003Chp_003Ek__BackingField = maxHp;
		}
		controlHp = _003Chp_003Ek__BackingField;
		int num = default(int);
		string text = num.ToString();
		string text2 = "+" + text;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		object obj2 = default(object);
		int textSize = default(int);
		EffectManager.Instance.PopupText(text2, (Color)(&obj), (Vector3)(&obj2), textSize);
		Action<Enemy> a_HealthChange = A_HealthChange;
		if (A_HealthChange != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v186 @ r9_v2 (System.Action`1<Assets.Scripts.Actors.Enemies.Enemy>)+18] (should have been resolved before IL gen)");
		}
	}

	private void SetBoss()
	{
		CheckStatusSymbols();
		teleportTime = bossTeleportTime;
		enemyMovement.Init();
	}

	public void SetArmor(float newArmor, int current, int max)
	{
		armor = newArmor;
		_003CarmorCurrent_003Ek__BackingField = current;
		_003CarmorMax_003Ek__BackingField = max;
		Action<Enemy, int, int> a_ArmorChanged = A_ArmorChanged;
		if (A_ArmorChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v54 @ r10_v1 (System.Action`3<Assets.Scripts.Actors.Enemies.Enemy, System.Int32, System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}

	public void SetSummonerMiniboss()
	{
		SetBoss();
		EnemyManager instance = EnemyManager.Instance;
		SummonerController summonerController = instance.summonerController;
		float num;
		if (summonerController._003CminibossCount_003Ek__BackingField != 0)
		{
			bool flag = summonerController._003CminibossCount_003Ek__BackingField != 1;
			num = 1f;
			if (!flag)
			{
				num = 9f;
				goto IL_00c4;
			}
		}
		else
		{
			num = 3f;
		}
		if (summonerController._003CminibossCount_003Ek__BackingField == 2)
		{
			num = 20f;
		}
		else if (summonerController._003CminibossCount_003Ek__BackingField == 3)
		{
			num = 40f;
		}
		goto IL_00c4;
		IL_00c4:
		float num2 = EnemyStats.GetHp(this);
		float num3 = num2 * num;
		controlHp = num3;
		float num4 = EnemyStats.GetHp(this);
		maxHp = (controlHp = (_003Chp_003Ek__BackingField = num4 * num));
		enemyMovement.Init();
		Action<Enemy> a_HealthChange = A_HealthChange;
		if (A_HealthChange != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v135 @ r9_v1 (System.Action`1<Assets.Scripts.Actors.Enemies.Enemy>)+18] (should have been resolved before IL gen)");
		}
	}

	public bool IsStageBoss()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		bool result = default(bool);
		return result;
	}

	public bool IsBoss()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		bool result = default(bool);
		return result;
	}

	public bool IsElite()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		bool result = default(bool);
		return result;
	}

	public bool IsChallenge()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		bool result = default(bool);
		return result;
	}

	public bool IsEliteChallenge()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D80");
		bool result = default(bool);
		return result;
	}

	public bool IsFinalBoss()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		bool result = default(bool);
		return result;
	}

	public void SetMinibossGoon(float hp)
	{
		_003Chp_003Ek__BackingField = hp;
		maxHp = hp;
		controlHp = hp;
	}

	private unsafe void AddStatusSymbols()
	{
		//IL_00e2: Expected O, but got Ref
		//IL_012e: Expected O, but got Ref
		if (statusSymbols == null)
		{
			PoolManager instance = PoolManager.Instance;
			GameObject gameObject = instance.enemyStatusSymbolsPool.Get();
			if (gameObject != null)
			{
				EnemyStatusSymbols component = gameObject.GetComponent<EnemyStatusSymbols>();
				statusSymbols = component;
				GameObject gameObject2 = statusSymbols.gameObject;
				gameObject2.SetActive(value: true);
				Transform transform = statusSymbols.transform;
				transform.parentInternal = null;
				Transform transform2 = statusSymbols.transform;
				float num = default(float);
				transform2.localScale = (Vector3)(&num);
				Transform transform3 = statusSymbols.transform;
				Transform transform4 = renderer.transform;
				Vector3 position = transform4.position;
				transform3.position = (Vector3)(&num);
				Transform transform5 = statusSymbols.transform;
				Transform parentInternal = renderer.transform;
				transform5.parentInternal = parentInternal;
			}
		}
	}

	private unsafe void RemoveStatusSymbols()
	{
		//IL_0067: Expected O, but got Ref
		if (statusSymbols != null)
		{
			Transform transform = statusSymbols.transform;
			transform.parentInternal = null;
			Transform transform2 = statusSymbols.transform;
			object obj = default(object);
			transform2.localScale = (Vector3)(&obj);
			GameObject gameObject = statusSymbols.gameObject;
			gameObject.SetActive(value: false);
			PoolManager instance = PoolManager.Instance;
			GameObject element = statusSymbols.gameObject;
			instance.enemyStatusSymbolsPool.Release(element);
			statusSymbols = null;
		}
	}

	private void ResetUi()
	{
	}

	private void Awake()
	{
		//IL_0440: Expected I, but got O
		//IL_0451: Expected O, but got I4
		//IL_045a: Expected O, but got I4
		//IL_0034: Expected I, but got O
		//IL_0090: Expected I, but got O
		//IL_009e: Expected I, but got O
		//IL_00af: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_05fa: Expected I, but got O
		//IL_049f: Expected I, but got O
		//IL_04b5: Expected I, but got O
		//IL_04be: Expected O, but got I4
		//IL_04c7: Expected O, but got I4
		//IL_04f1: Expected I, but got O
		//IL_0502: Expected O, but got I4
		//IL_050b: Expected O, but got I4
		//IL_0268: Expected I, but got O
		//IL_0279: Expected O, but got I4
		//IL_0282: Expected O, but got I4
		//IL_02c0: Expected I, but got O
		//IL_02d1: Expected O, but got I4
		//IL_02da: Expected O, but got I4
		//IL_0370: Expected I, but got O
		//IL_0381: Expected O, but got I4
		//IL_038a: Expected O, but got I4
		//IL_0344: Expected I, but got O
		//IL_03c8: Expected I, but got O
		//IL_03d6: Expected I, but got O
		//IL_03e7: Expected O, but got I4
		//IL_03f0: Expected O, but got I4
		//IL_0598: Expected O, but got I4
		//IL_05a1: Expected O, but got I4
		Action<bool> b = OnPaused;
		Delegate obj = Delegate.Combine(MyTime.A_Pause, b);
		nint num2;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num;
		if ((object)obj == null)
		{
			MyTime.A_Pause = null;
			num = (nint)MyTime.A_Pause;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action = default(Action<bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num2 = (nint)typeof(Action<bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0567;
			}
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num = (nint)typeof(Action<bool>);
			nint num3 = (nint)typeof(Action<bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
		}
		EnemyDissolve enemyDissolve = dissolve;
		bool flag2 = (object)dissolve == null;
		obj2 = obj;
		obj3 = 0;
		obj4 = 0;
		Delegate obj9;
		nint num4;
		if (!flag2)
		{
			Action action2 = OnDissolveFinished;
			Delegate obj6 = Delegate.Combine(enemyDissolve.A_DissolveFinished, action2);
			if ((object)obj6 == null)
			{
				enemyDissolve.A_DissolveFinished = null;
			}
			else
			{
				bool flag3 = (object)obj6.GetType() != typeof(Action);
				Delegate obj7 = null;
				if (!flag3)
				{
					obj7 = obj6;
				}
				bool flag4 = (object)obj7 == null;
				num = (nint)enemyDissolve.A_DissolveFinished;
				obj2 = action2;
				num4 = (nint)typeof(Action);
				obj3 = 0;
				obj4 = 0;
				if (flag4)
				{
					goto IL_05d7;
				}
				enemyDissolve.A_DissolveFinished = (Action)obj7;
				bool flag5 = (object)obj6.GetType() != typeof(Action);
				Delegate obj8 = null;
				if (!flag5)
				{
					obj8 = obj6;
				}
				bool flag6 = (object)obj8 == null;
				num = (nint)enemyDissolve.A_DissolveFinished;
				obj2 = action2;
				obj3 = 0;
				obj4 = 0;
				obj9 = (Delegate)(object)typeof(Action);
				if (flag6)
				{
					goto IL_05e7;
				}
			}
			Action<EStatusEffect, bool> b2 = OnStatusEffectAdded;
			Delegate obj10 = Delegate.Combine(PlayerStatusEffects.A_StatusEffectAdded, b2);
			if ((object)obj10 == null)
			{
				PlayerStatusEffects.A_StatusEffectAdded = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<EStatusEffect, bool> action3 = default(Action<EStatusEffect, bool>);
				bool flag7 = action3 == null;
				num2 = (nint)typeof(Action<EStatusEffect, bool>);
				obj2 = obj10;
				obj3 = 0;
				obj4 = 0;
				if (flag7)
				{
					goto IL_0527;
				}
				PlayerStatusEffects.A_StatusEffectAdded = action3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj11 = default(object);
				bool flag8 = obj11 == null;
				num2 = (nint)typeof(Action<EStatusEffect, bool>);
				obj2 = obj10;
				obj3 = 0;
				obj4 = 0;
				if (flag8)
				{
					goto IL_0547;
				}
			}
			Action<EStatusEffect> b3 = OnStatusEffectRemoved;
			Delegate obj12 = Delegate.Combine(PlayerStatusEffects.A_StatusEffectRemoved, b3);
			if ((object)obj12 == null)
			{
				PlayerStatusEffects.A_StatusEffectRemoved = null;
				num = (nint)PlayerStatusEffects.A_StatusEffectRemoved;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<EStatusEffect> action4 = default(Action<EStatusEffect>);
				bool flag9 = action4 == null;
				num2 = (nint)typeof(Action<EStatusEffect>);
				obj2 = obj12;
				obj3 = 0;
				obj4 = 0;
				if (flag9)
				{
					goto IL_0557;
				}
				PlayerStatusEffects.A_StatusEffectRemoved = action4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj13 = default(object);
				bool flag10 = obj13 == null;
				num = (nint)typeof(Action<EStatusEffect>);
				num2 = (nint)typeof(Action<EStatusEffect>);
				obj2 = obj12;
				obj3 = 0;
				obj4 = 0;
				if (flag10)
				{
					goto IL_0567;
				}
			}
			bool flag11 = MyRandom.random == null;
			obj2 = obj12;
			obj3 = 0;
			obj4 = 0;
			if (!flag11)
			{
				double num5 = MyRandom.random.NextDouble();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
				teleportCheckInterval = 4f;
				return;
			}
		}
		goto IL_046f;
		IL_0547:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0527;
		IL_0567:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0557;
		IL_05d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_046f;
		IL_046f:
		throw new NullReferenceException();
		IL_0557:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0547;
		IL_05e7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num4 = (nint)obj9;
		goto IL_05d7;
		IL_0527:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = num2;
		obj9 = obj2;
		goto IL_05e7;
	}

	private void OnDestroy()
	{
		//IL_0401: Expected I, but got O
		//IL_0412: Expected O, but got I4
		//IL_041b: Expected O, but got I4
		//IL_0034: Expected I, but got O
		//IL_0090: Expected I, but got O
		//IL_009e: Expected I, but got O
		//IL_00af: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_0583: Expected I, but got O
		//IL_0460: Expected I, but got O
		//IL_0476: Expected I, but got O
		//IL_047f: Expected O, but got I4
		//IL_0488: Expected O, but got I4
		//IL_04b2: Expected I, but got O
		//IL_04c3: Expected O, but got I4
		//IL_04cc: Expected O, but got I4
		//IL_0268: Expected I, but got O
		//IL_0279: Expected O, but got I4
		//IL_0282: Expected O, but got I4
		//IL_02c0: Expected I, but got O
		//IL_02d1: Expected O, but got I4
		//IL_02da: Expected O, but got I4
		//IL_0367: Expected I, but got O
		//IL_0378: Expected O, but got I4
		//IL_0381: Expected O, but got I4
		//IL_03bf: Expected I, but got O
		//IL_03d0: Expected O, but got I4
		//IL_03d9: Expected O, but got I4
		Action<bool> value = OnPaused;
		Delegate obj = Delegate.Remove(MyTime.A_Pause, value);
		nint num2;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num;
		if ((object)obj == null)
		{
			MyTime.A_Pause = null;
			num = (nint)MyTime.A_Pause;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action = default(Action<bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num2 = (nint)typeof(Action<bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0528;
			}
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num = (nint)typeof(Action<bool>);
			nint num3 = (nint)typeof(Action<bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
		}
		EnemyDissolve enemyDissolve = dissolve;
		bool flag2 = (object)dissolve == null;
		obj2 = obj;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0430;
		}
		Action action2 = OnDissolveFinished;
		Delegate obj6 = Delegate.Remove(enemyDissolve.A_DissolveFinished, action2);
		Delegate obj9;
		nint num4;
		if ((object)obj6 == null)
		{
			enemyDissolve.A_DissolveFinished = null;
		}
		else
		{
			bool flag3 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag3)
			{
				obj7 = obj6;
			}
			bool flag4 = (object)obj7 == null;
			num = (nint)enemyDissolve.A_DissolveFinished;
			obj2 = action2;
			num4 = (nint)typeof(Action);
			obj3 = 0;
			obj4 = 0;
			if (flag4)
			{
				goto IL_0560;
			}
			enemyDissolve.A_DissolveFinished = (Action)obj7;
			bool flag5 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag5)
			{
				obj8 = obj6;
			}
			bool flag6 = (object)obj8 == null;
			num = (nint)enemyDissolve.A_DissolveFinished;
			obj2 = action2;
			obj3 = 0;
			obj4 = 0;
			obj9 = (Delegate)(object)typeof(Action);
			if (flag6)
			{
				goto IL_0570;
			}
		}
		Action<EStatusEffect, bool> value2 = OnStatusEffectAdded;
		Delegate obj10 = Delegate.Remove(PlayerStatusEffects.A_StatusEffectAdded, value2);
		if ((object)obj10 == null)
		{
			PlayerStatusEffects.A_StatusEffectAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect, bool> action3 = default(Action<EStatusEffect, bool>);
			bool flag7 = action3 == null;
			num2 = (nint)typeof(Action<EStatusEffect, bool>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = 0;
			if (flag7)
			{
				goto IL_04e8;
			}
			PlayerStatusEffects.A_StatusEffectAdded = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag8 = obj11 == null;
			num2 = (nint)typeof(Action<EStatusEffect, bool>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = 0;
			if (flag8)
			{
				goto IL_0508;
			}
		}
		Action<EStatusEffect> value3 = OnStatusEffectRemoved;
		Delegate obj12 = Delegate.Remove(PlayerStatusEffects.A_StatusEffectRemoved, value3);
		if ((object)obj12 == null)
		{
			PlayerStatusEffects.A_StatusEffectRemoved = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EStatusEffect> action4 = default(Action<EStatusEffect>);
		bool flag9 = action4 == null;
		num2 = (nint)typeof(Action<EStatusEffect>);
		obj2 = obj12;
		obj3 = 0;
		obj4 = 0;
		if (flag9)
		{
			goto IL_0518;
		}
		PlayerStatusEffects.A_StatusEffectRemoved = action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj13 = default(object);
		bool flag10 = obj13 == null;
		num2 = (nint)typeof(Action<EStatusEffect>);
		obj2 = obj12;
		obj3 = 0;
		obj4 = 0;
		if (!flag10)
		{
			return;
		}
		goto IL_0528;
		IL_0508:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04e8;
		IL_0528:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0518;
		IL_0430:
		throw new NullReferenceException();
		IL_0560:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0430;
		IL_0518:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0508;
		IL_0570:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num4 = (nint)obj9;
		goto IL_0560;
		IL_04e8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = num2;
		obj9 = obj2;
		goto IL_0570;
	}

	private void OnStatusEffectAdded(EStatusEffect eStatusEffect, bool newEffect)
	{
		if (eStatusEffect == EStatusEffect.TimeFreeze)
		{
			animatedMesh.Pause();
			enemyMovement.StopMovement();
		}
	}

	private void OnStatusEffectRemoved(EStatusEffect eStatusEffect)
	{
		if (eStatusEffect == EStatusEffect.TimeFreeze)
		{
			animatedMesh.UnPause();
			enemyMovement.StartMovement();
		}
	}

	private IEnumerator StartTeleporting(Vector3 toPosition, bool skipStart = false)
	{
		//IL_0017: Expected O, but got F4
		_003CStartTeleporting_003Ed__110 obj = new _003CStartTeleporting_003Ed__110(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.toPosition = (Vector3)toPosition.x;
		_ = toPosition.z;
		obj.skipStart = skipStart;
		return obj;
	}

	private IEnumerator Despawn()
	{
		_003CDespawn_003Ed__111 obj = new _003CDespawn_003Ed__111(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void DamageFromPlayerWeapon(DamageContainer dc)
	{
		//IL_0013: Invalid comparison between F4 and I4
		Damage(dc);
		if (dc.procCoefficient > 0f)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			inventory.itemInventory.PostDamage(dc);
		}
	}

	public void DamageFromPlayerOther(DamageContainer dc)
	{
		//IL_0013: Invalid comparison between F4 and I4
		Damage(dc);
		if (dc.procCoefficient > 0f)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			inventory.itemInventory.PostDamage(dc);
		}
	}

	public void DamageExternal(DamageContainer dc)
	{
		Damage(dc);
	}

	public bool HasDebuff(EDebuff debuff)
	{
		//IL_002b: Expected I4, but got O
		if (debuffs != null)
		{
			return ((Dictionary<System.Int32Enum, object>)(object)debuffs).ContainsKey((System.Int32Enum)debuff);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void ReleaseEcho()
	{
		//IL_010d: Invalid comparison between I4 and F4
		//IL_000e: Expected O, but got Ref
		//IL_0058: Expected O, but got I4
		if (0f < echoDamage)
		{
			object obj = default(object);
			string damageSource = ((Enum)(&obj)).ToString();
			string damageSource2 = default(string);
			DamageContainer damageContainer = new DamageContainer(0f, damageSource2);
			damageContainer.damageSource = damageSource;
			damageContainer.procCoefficient = 0f;
			damageContainer.direction = (Vector3)0;
			_ = 0;
			damageContainer.crit = false;
			damageContainer.knockback = 0f;
			damageContainer.enemy = null;
			damageContainer.damageEffect = EDamageEffect.None;
			damageContainer.damageBlockedByArmor = 0;
			damageContainer.isExecute = false;
			damageContainer.canProcJoe = false;
			damageContainer.damage = echoDamage;
			damageContainer.damageEffect = EDamageEffect.Echo;
			damageContainer.enemy = this;
			DamageFromPlayerWeapon(damageContainer);
			echoDamage = 0f;
		}
	}

	private void Damage(DamageContainer damageContainer)
	{
		//IL_03f0: Invalid comparison between I4 and F4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_007c: Invalid comparison between O and F4
		//IL_0108: Invalid comparison between F4 and I4
		//IL_0482: Invalid comparison between I4 and F4
		//IL_01d0: Expected F4, but got I4
		//IL_0132: Expected O, but got I4
		//IL_04a9: Invalid comparison between I4 and F4
		//IL_02e7: Invalid comparison between F4 and I4
		//IL_01fe: Expected O, but got I
		//IL_0372: Invalid comparison between F4 and I4
		//IL_0309: Invalid comparison between I4 and F4
		//IL_0213: Expected O, but got I
		if (!(0f < _003Chp_003Ek__BackingField) || state == EEnemyState.Teleporting || isInvulnerable)
		{
			return;
		}
		float num = controlHp - _003Chp_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2f))
		{
			Action a_HpTamper = A_HpTamper;
			if (A_HpTamper != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v239.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		object obj2 = default(object);
		if (obj2 != null)
		{
			float stat = PlayerStats.GetStat(EStat.EliteDamageMultiplier);
			float damage = stat * damageContainer.damage;
			damageContainer.damage = damage;
		}
		if (!((Dictionary<System.Int32Enum, object>)(object)debuffs).ContainsKey((System.Int32Enum)16))
		{
			if (armor > 0f)
			{
				object obj3 = damageContainer.flags & DcFlags.BypassAll;
				if ((nint)obj3 != 5)
				{
					float num2 = 1f - armor;
					float damage2 = num2 * damageContainer.damage;
					damageContainer.damage = damage2;
				}
			}
			float num3 = _003Chp_003Ek__BackingField - damageContainer.damage;
			if (!(0f > num3))
			{
				bool flag = !(num3 > 3.4028235E+38f);
				float num4 = 3.4028235E+38f;
				if (!flag)
				{
					num4 = 3.4028235E+38f;
					num3 = 3.4028235E+38f;
				}
			}
			else
			{
				num3 = 0f;
			}
			_003Chp_003Ek__BackingField = num3;
			bool flag2 = 0f < num3;
			controlHp = num3;
			if (flag2)
			{
				bool flag3 = ((Dictionary<EDebuff, EnemyDebuff>)null).ContainsKey(EDebuff.Echo);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rax_v39 (System.Boolean)+20]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v40+38]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v41+14]");
				if ((nint)0 == 1 && MyTime.time > readyToFlashTime)
				{
					if (renderer != null)
					{
						renderer.SetMaterial(whiteMaterial);
					}
					flashing = true;
					float num5 = (stopFlashTime = MyTime.time + flashTime) + flashInterval;
					readyToFlashTime = num5;
				}
			}
			else
			{
				EnemyDied(damageContainer);
			}
			EnemyData enemyData = _003CenemyData_003Ek__BackingField;
			if (enemyData.despawnTime > 0f && !(0f < despawnAtTime))
			{
				EnemyData enemyData2 = _003CenemyData_003Ek__BackingField;
				float num6 = MyTime.time + enemyData2.despawnTime;
				despawnAtTime = num6;
			}
			EffectManager.Instance.NewDamageNumbers(damageContainer, this);
			if (damageContainer.knockback > 0f)
			{
				enemyMovement.Knockback(damageContainer);
			}
			Action<Enemy, DamageContainer> a_Damage = A_Damage;
			if (A_Damage != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v553 @ r10_v3 (System.Action`2<Assets.Scripts.Actors.Enemies.Enemy, Assets.Scripts.Actors.DamageContainer>)+18] (should have been resolved before IL gen)");
			}
			Action<Enemy, DamageContainer> a_DamageNonStatic = A_DamageNonStatic;
			if (A_DamageNonStatic != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v561 @ rax_v26 (System.Action`2<Assets.Scripts.Actors.Enemies.Enemy, Assets.Scripts.Actors.DamageContainer>)+18] (should have been resolved before IL gen)");
			}
		}
		else
		{
			float num7 = echoDamage + damageContainer.damage;
			echoDamage = num7;
		}
	}

	public void MakeWhite()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172B88]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		renderer.SetMaterial(whiteMaterial);
		CancelInvoke("ResetMaterial");
	}

	public void Kill(string damageSource = "Unkown")
	{
		//IL_00cd: Expected O, but got I
		//IL_0013: Expected O, but got I4
		//IL_0100: Expected I, but got O
		IntPtr intPtr = default(IntPtr);
		DamageContainer damageContainer = new DamageContainer(0f, (string)(nint)intPtr);
		damageContainer.damageSource = damageSource;
		damageContainer.procCoefficient = 0f;
		damageContainer.direction = (Vector3)0;
		_ = 0;
		damageContainer.crit = false;
		damageContainer.knockback = 0f;
		damageContainer.enemy = null;
		damageContainer.damageEffect = EDamageEffect.None;
		damageContainer.damageBlockedByArmor = 0;
		damageContainer.crit = false;
		damageContainer.canProcJoe = false;
		float damage = _003Chp_003Ek__BackingField + 1f;
		damageContainer.damage = damage;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		damageContainer.direction = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		damageContainer.knockback = 0f;
		if (_003Chp_003Ek__BackingField > damageContainer.damage)
		{
			float damage2 = _003Chp_003Ek__BackingField + 1f;
			damageContainer.damage = damage2;
		}
		Damage(damageContainer);
	}

	public bool CanTakeDamage()
	{
		//IL_000b: Invalid comparison between I4 and F4
		if (0f < _003Chp_003Ek__BackingField && state != EEnemyState.Teleporting)
		{
			return !isInvulnerable;
		}
		return false;
	}

	public void MakeInvulnerable(bool invulnerable)
	{
		isInvulnerable = invulnerable;
		enemyRenderer.SetInvulnerable(invulnerable);
		QueueClearAllDebuffs();
		Action<Enemy, bool> a_InvulnerableChanged = A_InvulnerableChanged;
		if (A_InvulnerableChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v59 @ r10_v1 (System.Action`2<Assets.Scripts.Actors.Enemies.Enemy, System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	public void DiedNextFrame()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172B8B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		isDyingNextFrame = true;
		Invoke("EnemyDied", 0f);
	}

	private void EnemyDied()
	{
		//IL_0013: Expected O, but got I4
		string damageSource = default(string);
		DamageContainer damageContainer = new DamageContainer(0f, damageSource);
		damageContainer.damageSource = "Unknown";
		damageContainer.procCoefficient = 0f;
		damageContainer.direction = (Vector3)0;
		_ = 0;
		damageContainer.crit = false;
		damageContainer.knockback = 0f;
		damageContainer.enemy = null;
		damageContainer.damageEffect = EDamageEffect.None;
		damageContainer.damageBlockedByArmor = 0;
		damageContainer.isExecute = false;
		damageContainer.canProcJoe = false;
		EnemyDied(damageContainer);
	}

	public void EnemyDied(DamageContainer dc)
	{
		if (!deathFunctionCalled)
		{
			deathFunctionCalled = true;
			_003Chp_003Ek__BackingField = 0f;
			controlHp = 0f;
			GameObject gameObject = base.gameObject;
			int layer = LayerMask.NameToLayer("Default");
			gameObject.layer = layer;
			enemyMovement.StopMovement();
			EnemyBehaviour.DeathBehaviour(this);
			StopAllCoroutines();
			int num = deaths + 1;
			deaths = num;
			Action<Enemy, DamageContainer> a_EnemyDied = A_EnemyDied;
			if (A_EnemyDied != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v179 @ rax_v15 (System.Action`2<Assets.Scripts.Actors.Enemies.Enemy, Assets.Scripts.Actors.DamageContainer>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void OnPaused(bool paused)
	{
		enemyMovement.Pause(paused);
	}

	private void OnDissolveFinished()
	{
		ReleaseToPool();
	}

	public void ReleaseToPoolNextFrame()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172B8E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Invoke("ReleaseToPool", 0f);
	}

	public void ReleaseToPool()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		PoolManager instance = PoolManager.Instance;
		GameObject element = base.gameObject;
		instance.enemyPool.Release(element);
		ClearAllDebuffs();
		Action<Enemy> a_EnemyReleasedFromPool = A_EnemyReleasedFromPool;
		if (A_EnemyReleasedFromPool != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v110 @ r9_v1 (System.Action`1<Assets.Scripts.Actors.Enemies.Enemy>)+18] (should have been resolved before IL gen)");
		}
	}

	public unsafe void MyFixedUpdate()
	{
		//IL_0097: Invalid comparison between F4 and I4
		//IL_00b9: Invalid comparison between F4 and I4
		//IL_029b: Expected O, but got I
		//IL_0190: Invalid comparison between I4 and F4
		//IL_05cb: Expected O, but got Ref
		//IL_046b: Expected O, but got Ref
		//IL_03d4: Expected O, but got I
		//IL_03b7: Expected O, but got Ref
		//IL_041e: Expected O, but got I
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Expected O, but got Unknown
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		Component component = this;
		if (!flag)
		{
			if (!gameObject.activeInHierarchy)
			{
				return;
			}
			if (allowSpecialAttacks && specialAttackController != null)
			{
				specialAttackController.Tick();
			}
			TryTeleport();
			component = this;
			EnemyData enemyData = _003CenemyData_003Ek__BackingField;
			if ((object)_003CenemyData_003Ek__BackingField != null)
			{
				if (enemyData.despawnTime > 0f && despawnAtTime > 0f && MyTime.time > despawnAtTime && state != EEnemyState.Teleporting)
				{
					_003CDespawn_003Ed__111 obj = new _003CDespawn_003Ed__111(0);
					obj._003C_003E1__state = 0;
					obj._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(obj);
				}
				bool flag2 = (object)enemyMovement == null;
				component = enemyMovement;
				if (!flag2)
				{
					enemyMovement.MyFixedUpdate();
					EnemyBehaviour.FixedUpdate(this);
					VerifyPosition();
					if (flashing)
					{
						component = this;
						if (MyTime.time > stopFlashTime)
						{
							flashing = false;
							if (0f < _003Chp_003Ek__BackingField)
							{
								EnemyData enemyData2 = _003CenemyData_003Ek__BackingField;
								if ((object)_003CenemyData_003Ek__BackingField != null)
								{
									bool flag3 = (object)renderer == null;
									component = renderer;
									if (!flag3)
									{
										renderer.SetMaterial(enemyData2.material);
										goto IL_0212;
									}
								}
								goto IL_0490;
							}
						}
					}
					goto IL_0212;
				}
			}
		}
		goto IL_0490;
		IL_0212:
		component = (Component)(object)_toAddBuffer;
		if (_toAddBuffer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v5 (UnityEngine.Component)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v5 (UnityEngine.Component)+18]");
			if ((nint)0 > (nint)0)
			{
				IntPtr cachedPtr = ((UnityEngine.Object)component).m_CachedPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v5 (UnityEngine.Component)+18]");
				Array.Clear((Array)(nint)cachedPtr, 0, 0);
			}
			bool flag4 = debuffsToAdd == null;
			component = (Component)(object)debuffsToAdd;
			if (!flag4)
			{
				Dictionary<EDebuff, AddDebuffContainer>.ValueCollection values = debuffsToAdd.Values;
				bool flag5 = values == null;
				component = (Component)(object)debuffsToAdd;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBF00");
					Dictionary<EDebuff, AddDebuffContainer>.ValueCollection.Enumerator enumerator = default(Dictionary<EDebuff, AddDebuffContainer>.ValueCollection.Enumerator);
					Dictionary<EDebuff, AddDebuffContainer>.ValueCollection.Enumerator enumerator2 = default(Dictionary<EDebuff, AddDebuffContainer>.ValueCollection.Enumerator);
					while (enumerator.MoveNext())
					{
						component = (Component)(object)_toAddBuffer;
						if (_toAddBuffer != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v5 (UnityEngine.Component)+1C]");
							_ = (nint)0 + (nint)1;
							IntPtr cachedPtr2 = ((UnityEngine.Object)component).m_CachedPtr;
							if (((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v5 (UnityEngine.Component)+18]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v27 (System.IntPtr)+18]");
								if (num >= 0)
								{
									_toAddBuffer.AddWithResize((AddDebuffContainer)(&enumerator2));
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v5 (UnityEngine.Component)+18]");
								object obj2 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v5 (UnityEngine.Component)+18]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v27 (System.IntPtr)+18]");
								if (num2 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v5 (UnityEngine.Component)+18]");
									object obj3 = (nint)0 * (nint)2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v5 (UnityEngine.Component)+18]");
									object obj4 = 0 + obj3;
									continue;
								}
								throw new IndexOutOfRangeException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					enumerator.Dispose();
					bool flag6 = _toAddBuffer == null;
					component = (Component)(&enumerator);
					if (!flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18113FB70");
						List<AddDebuffContainer>.Enumerator enumerator3 = default(List<AddDebuffContainer>.Enumerator);
						while (enumerator3.MoveNext())
						{
							AddDebuffImplementation((AddDebuffContainer)(&enumerator2));
						}
						enumerator3.Dispose();
						if (debuffsToAdd != null)
						{
							debuffsToAdd.Clear();
							return;
						}
					}
				}
			}
		}
		goto IL_0490;
		IL_0490:
		throw new NullReferenceException();
	}

	public unsafe void AddDebuff(EDebuff eDebuff, DamageContainer dc, float duration, int stacks = 1)
	{
		//IL_008e: Expected O, but got Ref
		//IL_0069: Invalid comparison between O and F4
		//IL_00c8: Expected O, but got Ref
		if (isInvulnerable)
		{
			return;
		}
		if (((Dictionary<System.Int32Enum, AddDebuffContainer>)(object)debuffsToAdd).ContainsKey((System.Int32Enum)eDebuff))
		{
			AddDebuffContainer addDebuffContainer = ((Dictionary<System.Int32Enum, AddDebuffContainer>)(object)debuffsToAdd).get_Item((System.Int32Enum)eDebuff);
			AddDebuffContainer addDebuffContainer2 = ((Dictionary<System.Int32Enum, AddDebuffContainer>)(object)debuffsToAdd).get_Item((System.Int32Enum)eDebuff);
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)duration))
			{
				object obj2 = default(object);
				((Dictionary<System.Int32Enum, AddDebuffContainer>)(object)debuffsToAdd).set_Item((System.Int32Enum)eDebuff, (AddDebuffContainer)(&obj2));
				return;
			}
		}
		object obj3 = default(object);
		((Dictionary<System.Int32Enum, AddDebuffContainer>)(object)debuffsToAdd).Add((System.Int32Enum)eDebuff, (AddDebuffContainer)(&obj3));
	}

	private void AddDebuffImplementation(AddDebuffContainer debuffContainer)
	{
		//IL_0049: Expected O, but got I4
		//IL_01aa: Expected I, but got O
		//IL_01f9: Expected O, but got I4
		//IL_027e: Expected I, but got O
		//IL_0238: Expected O, but got I4
		if (debuffCounts.ContainsKey(debuffContainer.eDebuff))
		{
			object obj = debuffContainer.eDebuff & EDebuff.DebuffsWithCap;
			if (obj != null)
			{
				int num = debuffCounts.get_Item(debuffContainer.eDebuff);
				int value = num + 1;
				((Dictionary<System.Int32Enum, int>)(object)debuffCounts).set_Item((System.Int32Enum)debuffContainer.eDebuff, value);
				int num2 = debuffCounts.get_Item(debuffContainer.eDebuff);
				int capCC = EnemyStats.GetCapCC();
				bool flag = num2 > capCC;
				nint num3 = 0;
				if (flag)
				{
					return;
				}
			}
		}
		if (!((Dictionary<System.Int32Enum, object>)(object)debuffs).ContainsKey((System.Int32Enum)debuffContainer.eDebuff))
		{
			int stacks = default(int);
			EnemyDebuff debuff = DebuffFactory.GetDebuff(debuffContainer.eDebuff, this, debuffContainer.dc, debuffContainer.duration, stacks);
			if (debuff != null)
			{
				((Dictionary<System.Int32Enum, object>)(object)debuffs).Add((System.Int32Enum)debuffContainer.eDebuff, (object)debuff);
				nint num3 = 0;
			}
		}
		else
		{
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)debuffs).get_Item((System.Int32Enum)debuffContainer.eDebuff);
			nint num3 = (nint)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v332 @ r9_v4 (Il2CppMethodInfo)+188] (should have been resolved before IL gen)");
			float duration = debuffContainer.duration;
			int ticks = ((EnemyDebuff)obj2).GetTicks(debuffContainer.duration);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v11 (System.Object)+10]");
			bool flag2 = (nint)ticks <= (nint)0;
			object obj3 = 0;
			if (!flag2)
			{
				duration = debuffContainer.duration;
				int ticks2 = ((EnemyDebuff)obj2).GetTicks(debuffContainer.duration);
				obj3 = 0;
			}
			nint num4 = (nint)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v407 @ rax_v15 (Il2CppClass<System.Object>)+1E8] (should have been resolved before IL gen)");
		}
		Action<EDebuff> a_DebuffAdded = A_DebuffAdded;
		if (A_DebuffAdded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v370 @ rax_v9 (System.Action`1<Assets.Scripts.Game.Combat.EnemyDebuffs.EDebuff>)+18] (should have been resolved before IL gen)");
		}
	}

	public void RemoveDebuff(EDebuff debuff, bool fromDeath)
	{
		//IL_0051: Expected I, but got O
		if (((Dictionary<System.Int32Enum, object>)(object)debuffs).ContainsKey((System.Int32Enum)debuff))
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)debuffs).get_Item((System.Int32Enum)debuff);
			nint num = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v52 @ r9_v3 (Il2CppClass<System.Object>)+1C8] (should have been resolved before IL gen)");
			object element = ((Dictionary<System.Int32Enum, object>)(object)debuffs).get_Item((System.Int32Enum)debuff);
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)DebuffFactory.debuffPools).get_Item((System.Int32Enum)debuff);
			((ObjectPool<EnemyDebuff>)obj2).Release((EnemyDebuff)element);
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)debuffs).Remove((System.Int32Enum)debuff);
			Action<EDebuff> a_DebuffRemoved = A_DebuffRemoved;
			if (A_DebuffRemoved != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v172 @ rax_v16 (System.Action`1<Assets.Scripts.Game.Combat.EnemyDebuffs.EDebuff>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public unsafe void DebuffTick()
	{
		//IL_00a3: Expected O, but got Ref
		//IL_00cc: Expected O, but got I4
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.activeInHierarchy)
			{
				return;
			}
			if (debuffs != null)
			{
				Dictionary<EDebuff, EnemyDebuff>.ValueCollection values = debuffs.Values;
				if (values != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
					nint num = 0;
					Dictionary<EDebuff, EnemyDebuff>.ValueCollection.Enumerator enumerator = default(Dictionary<EDebuff, EnemyDebuff>.ValueCollection.Enumerator);
					EDebuff eDebuff = default(EDebuff);
					EDebuff item = default(EDebuff);
					while (enumerator.MoveNext())
					{
						bool flag = eDebuff == (EDebuff)0;
						Dictionary<EDebuff, EnemyDebuff>.ValueCollection.Enumerator enumerator2 = (Dictionary<EDebuff, EnemyDebuff>.ValueCollection.Enumerator)(&enumerator);
						if (!flag)
						{
							nint num2 = (nint)eDebuff;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v393 @ rax_v26 (Il2CppClass<UnityEngine.Component>)+178] (should have been resolved before IL gen)");
							if ((nint)((UnityEngine.Object)eDebuff).m_CachedPtr <= 0)
							{
								nint num3 = (nint)eDebuff;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v396 @ rax_v28 (Il2CppClass<UnityEngine.Component>)+1B8] (should have been resolved before IL gen)");
								if (debuffsToRemove == null)
								{
									throw new NullReferenceException();
								}
								bool flag2 = debuffsToRemove.Add(item);
								num = 0;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					enumerator.Dispose();
					HashSet<EDebuff> hashSet = debuffsToRemove;
					if (debuffsToRemove != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v19 (System.Collections.Generic.HashSet`1<Assets.Scripts.Game.Combat.EnemyDebuffs.EDebuff>)+20]");
						if ((nint)0 <= (nint)0)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18106E6B0");
						HashSet<EDebuff>.Enumerator enumerator3 = default(HashSet<EDebuff>.Enumerator);
						while (enumerator3.MoveNext())
						{
							RemoveDebuff(eDebuff, fromDeath: false);
						}
						enumerator3.Dispose();
						if (debuffsToRemove != null)
						{
							debuffsToRemove.Clear();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void QueueClearAllDebuffs()
	{
		Dictionary<EDebuff, EnemyDebuff>.KeyCollection keys = debuffs.Keys;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE40");
		Dictionary<EDebuff, EnemyDebuff>.KeyCollection.Enumerator enumerator = default(Dictionary<EDebuff, EnemyDebuff>.KeyCollection.Enumerator);
		EDebuff item = default(EDebuff);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (debuffsToRemove == null)
				{
					break;
				}
				bool flag = debuffsToRemove.Add(item);
				continue;
			}
			enumerator.Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe void ClearAllDebuffs()
	{
		//IL_007d: Expected I, but got O
		if (debuffs != null)
		{
			Dictionary<EDebuff, EnemyDebuff>.ValueCollection values = debuffs.Values;
			List<object> list = Enumerable.ToList((IEnumerable<object>)values);
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				nint num = 0;
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				IEnumerable<object> enumerable = default(IEnumerable<object>);
				EDebuff debuff = default(EDebuff);
				while (enumerator.MoveNext())
				{
					if (enumerable != null)
					{
						nint num2 = (nint)enumerable;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v233 @ rax_v15 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Object>>)+1B8] (should have been resolved before IL gen)");
						RemoveDebuff(debuff, fromDeath: true);
						num = 1;
						continue;
					}
					throw new NullReferenceException();
				}
				((List<EnemyDebuff>.Enumerator*)(&enumerator))->Dispose();
				if (debuffs != null)
				{
					debuffs.Clear();
					if (debuffsToAdd != null)
					{
						debuffsToAdd.Clear();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Charm(DamageContainer dc, float duration)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_008c: Expected F4, but got I
		//IL_00a1: Invalid comparison between I and F4
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_0287: Expected O, but got I
		//IL_02e1: Expected I, but got O
		//IL_03af: Expected I, but got O
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		if (!isInvulnerable)
		{
			if (((Dictionary<System.Int32Enum, AddDebuffContainer>)(object)debuffsToAdd).ContainsKey((System.Int32Enum)32))
			{
				AddDebuffContainer addDebuffContainer = ((Dictionary<System.Int32Enum, AddDebuffContainer>)(object)debuffsToAdd).get_Item((System.Int32Enum)32);
				AddDebuffContainer addDebuffContainer2 = ((Dictionary<System.Int32Enum, AddDebuffContainer>)(object)debuffsToAdd).get_Item((System.Int32Enum)32);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
				float num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
				if (0f < duration)
				{
					num = duration;
				}
				AddDebuffContainer value = (AddDebuffContainer)(obj - 57);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-25]");
				object obj3 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
				_ = 0;
				((Dictionary<System.Int32Enum, AddDebuffContainer>)(object)debuffsToAdd).set_Item((System.Int32Enum)32, value);
			}
			else
			{
				_ = 32;
				_ = 0;
				_ = 1;
				AddDebuffContainer value2 = (AddDebuffContainer)(obj - 25);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
				_ = 0;
				((Dictionary<System.Int32Enum, AddDebuffContainer>)(object)debuffsToAdd).Add((System.Int32Enum)32, value2);
			}
		}
		EnemyMovementRb enemyMovementRb = enemyMovement;
		enemyMovementRb.state = EnemyMovementRb.State.Charmed;
		MyPlayer instance = MyPlayer.Instance;
		PlayerMovement playerMovement = instance.playerMovement;
		if (_003Ctarget_003Ek__BackingField == playerMovement.rb)
		{
			PlayerMovement playerMovement2 = GameManager.Instance.GetPlayerMovement();
			_003Ctarget_003Ek__BackingField = playerMovement2.rb;
		}
		PoolManager instance2 = PoolManager.Instance;
		GameObject gameObject = instance2.charmPool.Get();
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform transform2 = base.transform;
			Vector3 position = transform2.position;
			nint num2 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rdx_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num3 = 0;
			float num4 = _003CmeshHeight_003Ek__BackingField * (float)Vector3.upVector;
			float num5 = num4 * 0.7f;
			float num6 = num5 + position.x;
			float num7 = _003CmeshHeight_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rax_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num8 = num7 * 0f;
			float num9 = _003CmeshHeight_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rax_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num10 = num9 * 0f;
			float num11 = num8 * 0.7f;
			float num12 = num10 * 0.7f;
			float num13 = num11 + position.y;
			float num14 = num12 + position.z;
			nint num15 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdx_v13 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num16 = 0;
			float num17 = num6 + (float)Vector3.downVector;
			float num18 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v31 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
			float num19 = num18 + 0f;
			float num20 = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v31 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
			float num21 = num20 + 0f;
			Vector3 position2 = (Vector3)(obj - 57);
			transform.position = position2;
		}
	}

	public void ReleaseCharm()
	{
		EnemyMovementRb enemyMovementRb = enemyMovement;
		enemyMovementRb.state = EnemyMovementRb.State.Normal;
		PlayerMovement playerMovement = GameManager.Instance.GetPlayerMovement();
		_003Ctarget_003Ek__BackingField = playerMovement.rb;
	}

	public void FindTarget()
	{
		PlayerMovement playerMovement = GameManager.Instance.GetPlayerMovement();
		_003Ctarget_003Ek__BackingField = playerMovement.rb;
	}

	private void VerifyPosition()
	{
		//IL_00b6: Expected O, but got F4
		if (nextVerifyTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + 5f;
		nextVerifyTime = num;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num2 = MapInfo.DespawnEnemyHeight();
		float num3 = num2 + 1f;
		if (!(num3 < position.y))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
			object obj = default(object);
			if (obj != null)
			{
				float maxDistance = default(float);
				Vector3 enemySpawnPosition = SpawnPositions.GetEnemySpawnPosition(_003CenemyData_003Ek__BackingField, 50, useDirectionBias: true, maxDistance);
				_003CStartTeleporting_003Ed__110 obj2 = new _003CStartTeleporting_003Ed__110(0);
				obj2._003C_003E1__state = 0;
				obj2._003C_003E4__this = this;
				obj2.toPosition = (Vector3)enemySpawnPosition.x;
				_ = enemySpawnPosition.z;
				obj2.skipStart = true;
				Coroutine coroutine = StartCoroutine(obj2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172B8E]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Invoke("ReleaseToPool", 0f);
		}
	}

	public void TeleportToPlayer()
	{
		//IL_0039: Expected O, but got F4
		float maxDistance = default(float);
		Vector3 enemySpawnPosition = SpawnPositions.GetEnemySpawnPosition(_003CenemyData_003Ek__BackingField, 50, useDirectionBias: true, maxDistance);
		_003CStartTeleporting_003Ed__110 obj = new _003CStartTeleporting_003Ed__110(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.toPosition = (Vector3)enemySpawnPosition.x;
		_ = enemySpawnPosition.z;
		obj.skipStart = true;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private void TryDespawn()
	{
		//IL_0013: Invalid comparison between F4 and I4
		//IL_0035: Invalid comparison between F4 and I4
		EnemyData enemyData = _003CenemyData_003Ek__BackingField;
		if (enemyData.despawnTime > 0f && despawnAtTime > 0f && MyTime.time > despawnAtTime && state != EEnemyState.Teleporting)
		{
			_003CDespawn_003Ed__111 obj = new _003CDespawn_003Ed__111(0);
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
	}

	public bool IsTeleporting()
	{
		//IL_0010: Expected O, but got I4
		object obj = state - 1;
		return obj == null;
	}

	private unsafe void TryTeleport()
	{
		//IL_0522: Invalid comparison between I4 and F4
		//IL_0118: Invalid comparison between I4 and F4
		//IL_0262: Expected I, but got O
		//IL_0391: Invalid comparison between F4 and O
		//IL_03ae: Invalid comparison between O and F4
		//IL_057b: Invalid comparison between F4 and I
		//IL_0411: Invalid comparison between I and F4
		//IL_02aa: Expected O, but got Ref
		//IL_02aa: Expected O, but got Ref
		//IL_0449: Expected I, but got O
		//IL_02ff: Expected O, but got F4
		if (!(0f < _003Chp_003Ek__BackingField) || (state != EEnemyState.Default && state != EEnemyState.FollowTarget) || !(_003Ctarget_003Ek__BackingField != null) || rb.isKinematic || GameManager.Instance.IsTimeFreeze() || nextTeleportTimeCheck > MyTime.time || state == EEnemyState.Teleporting)
		{
			return;
		}
		float num = MyTime.time + teleportCheckInterval;
		nextTeleportTimeCheck = num;
		GameManager instance = GameManager.Instance;
		if (instance._003CisCrypt_003Ek__BackingField)
		{
			return;
		}
		EnemyData enemyData = _003CenemyData_003Ek__BackingField;
		if (!(0f < enemyData.teleportCooldown) || state != EEnemyState.Default)
		{
			return;
		}
		EnemyMovementRb enemyMovementRb = enemyMovement;
		if (enemyMovementRb.distanceToTarget < startTeleportThresholdDistance)
		{
			return;
		}
		EnemyData enemyData2 = _003CenemyData_003Ek__BackingField;
		float num2 = enemyData2.teleportCooldown + lastTeleportTime;
		if (MyTime.time < num2)
		{
			return;
		}
		Vector3 position = _003Ctarget_003Ek__BackingField.position;
		Vector3 position2 = _003Ctarget_003Ek__BackingField.position;
		Transform transform = base.transform;
		Vector3 position3 = transform.position;
		float num3 = position2.x - position3.x;
		float num4 = position2.z - position3.z;
		float num5 = num3 + position.x;
		float num6 = num4 + position.z;
		nint num7 = (nint)typeof(MapInfo);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref MapInfo.mapBoundsUpper))
		{
			if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref MapInfo.mapBoundsLower) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5))
			{
				num5 = (float)MapInfo.mapBoundsLower + 1f;
			}
		}
		else
		{
			num5 = (float)MapInfo.mapBoundsUpper - 1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rcx_v53 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ rax_v35 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+14]");
		if (!(num6 > 0f))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rcx_v53 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ rax_v70 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+8]");
			if (!(0f > num6))
			{
			}
		}
		GameManager instance2 = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float num10 = default(float);
		object obj = default(object);
		int layerMask = default(int);
		RaycastHit[] hits = Physics.RaycastAll((Vector3)(&num10), (Vector3)(&obj), 9999f, layerMask);
		RaycastHit raycastHit = SpawnPositions.FindHitClosestToPlayerY(hits, out var foundPosition);
		if (foundPosition)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			nint num11 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rax_v49 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num12 = 0;
			float num13 = _003CmeshHeight_003Ek__BackingField * 0.5f;
			float num14 = num13 * (float)Vector3.upVector;
			object obj2 = default(object);
			float num15 = num14 + (float)obj2;
			float num16 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1058 @ rcx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num17 = num16 * 0f;
			float num18 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1058 @ rcx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num19 = num18 * 0f;
			float num20 = num17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1040 @ rax_v47+4]");
			float num21 = num20 + 0f;
			float num22 = num19;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1040 @ rax_v47+8]");
			float num23 = num22 + 0f;
			lastTeleportTime = MyTime.time;
			_003CStartTeleporting_003Ed__110 obj3 = new _003CStartTeleporting_003Ed__110(0);
			obj3._003C_003E1__state = 0;
			obj3._003C_003E4__this = this;
			obj3.toPosition = (Vector3)num15;
			obj3.skipStart = false;
			Coroutine coroutine = StartCoroutine(obj3);
		}
	}

	public void StartSpecialAttack()
	{
		state = EEnemyState.Idle;
		enemyMovement.StopMovement();
	}

	public void EndSpecialAttack()
	{
		state = EEnemyState.Default;
		enemyMovement.StartMovement();
	}

	public void FollowTarget(Transform target)
	{
		_003CfollowTarget_003Ek__BackingField = target;
		state = EEnemyState.FollowTarget;
		enemyMovement.StartMovement();
	}

	public void MyUpdate()
	{
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy)
		{
			enemyMovement.MyUpdate();
		}
	}

	public bool CanMove()
	{
		//IL_010e: Invalid comparison between I4 and F4
		//IL_0103: Expected I4, but got O
		if (0f < _003Chp_003Ek__BackingField && (state == EEnemyState.Default || state == EEnemyState.FollowTarget) && _003Ctarget_003Ek__BackingField != null)
		{
			if ((object)rb != null)
			{
				if (rb.isKinematic)
				{
					goto IL_00ef;
				}
				if ((object)GameManager.Instance != null)
				{
					bool flag = GameManager.Instance.IsTimeFreeze();
					return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_00ef;
		IL_00ef:
		return false;
	}

	public bool IsRunningFromPlayer()
	{
		//IL_016b: Expected I4, but got O
		//IL_0037: Invalid comparison between F4 and I4
		//IL_012f: Invalid comparison between F4 and I4
		//IL_00a4: Invalid comparison between F4 and I4
		EnemyData enemyData = _003CenemyData_003Ek__BackingField;
		if ((object)_003CenemyData_003Ek__BackingField != null)
		{
			if (!(enemyData.minStayAtDistance > 0f))
			{
				if (!enemyData.isRunningFromPlayer)
				{
					return false;
				}
				bool flag = maxHp < _003Chp_003Ek__BackingField;
				float num = maxHp - _003Chp_003Ek__BackingField;
				bool flag2 = num == 0f;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				return flag4 & flag3;
			}
			EnemyMovementRb enemyMovementRb = enemyMovement;
			if ((object)enemyMovement != null)
			{
				bool flag5 = minStayAtDistance < enemyMovementRb.distanceToTarget;
				float num2 = minStayAtDistance - enemyMovementRb.distanceToTarget;
				bool flag6 = num2 == 0f;
				bool flag7 = !flag5;
				bool flag8 = !flag6;
				return flag8 & flag7;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool IsStationary()
	{
		//IL_0113: Expected I4, but got O
		//IL_0037: Invalid comparison between I4 and F4
		//IL_00d1: Invalid comparison between F4 and I4
		EnemyData enemyData = _003CenemyData_003Ek__BackingField;
		if ((object)_003CenemyData_003Ek__BackingField != null)
		{
			if (0f < enemyData.minStayAtDistance)
			{
				EnemyMovementRb enemyMovementRb = enemyMovement;
				if ((object)enemyMovement == null)
				{
					goto IL_0105;
				}
				if (enemyMovementRb.distanceToTarget > minStayAtDistance)
				{
					bool flag = maxStayAtDistance < enemyMovementRb.distanceToTarget;
					float num = maxStayAtDistance - enemyMovementRb.distanceToTarget;
					bool flag2 = num == 0f;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					return flag4 & flag3;
				}
			}
			return false;
		}
		goto IL_0105;
		IL_0105:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public int GetXp()
	{
		//IL_007c: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		EnemyData enemyData = _003CenemyData_003Ek__BackingField;
		if ((object)_003CenemyData_003Ek__BackingField != null)
		{
			object obj = default(object);
			if (obj != null)
			{
				return _003CenemyData_003Ek__BackingField.GetEliteXp();
			}
			return enemyData.xp;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private void ResetMaterial()
	{
		//IL_000b: Invalid comparison between I4 and F4
		if (0f < _003Chp_003Ek__BackingField)
		{
			EnemyData enemyData = _003CenemyData_003Ek__BackingField;
			renderer.SetMaterial(enemyData.material);
		}
	}

	public bool IsDead()
	{
		//IL_000b: Invalid comparison between I4 and F4
		bool flag = 0f < _003Chp_003Ek__BackingField;
		return !flag;
	}

	public bool IsDeadOrDyingNextFrame()
	{
		//IL_000b: Invalid comparison between I4 and F4
		bool flag = 0f < _003Chp_003Ek__BackingField;
		bool flag2 = !flag;
		bool result = true;
		if (!flag2)
		{
			result = isDyingNextFrame;
		}
		return result;
	}

	public unsafe Vector3 GetCenterPosition()
	{
		//IL_0041: Expected native int or pointer, but got O
		//IL_0053: Expected native int or pointer, but got O
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = position.x;
			((Vector3*)(nint)vector)->z = position.z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe Vector3 GetFeetPosition()
	{
		//IL_0065: Expected native int or pointer, but got O
		//IL_0077: Expected native int or pointer, but got O
		if ((object)renderer != null)
		{
			Transform transform = renderer.transform;
			if ((object)transform != null)
			{
				Vector3 position = transform.position;
				Vector3 vector = default(Vector3);
				((Vector3*)(nint)vector)->x = position.x;
				((Vector3*)(nint)vector)->z = position.z;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe Vector3 GetHeadPosition()
	{
		//IL_0055: Expected I, but got O
		//IL_00a3: Expected native int or pointer, but got O
		//IL_012a: Expected native int or pointer, but got O
		//IL_0137: Expected native int or pointer, but got O
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			float num3 = _003CmeshHeight_003Ek__BackingField * (float)Vector3.upVector;
			float num4 = num3 * 0.7f;
			float x = num4 + position.x;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = x;
			float num5 = _003CmeshHeight_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num6 = num5 * 0f;
			float num7 = _003CmeshHeight_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num8 = num7 * 0f;
			float num9 = num6 * 0.7f;
			float num10 = num8 * 0.7f;
			float z = num9 + position.z;
			float y = num10 + position.y;
			((Vector3*)(nint)vector)->z = z;
			((Vector3*)(nint)vector)->y = y;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe Vector3 GetGroundCheckPosition()
	{
		//IL_0055: Expected I, but got O
		//IL_00ff: Expected I, but got O
		//IL_0163: Expected native int or pointer, but got O
		//IL_0188: Expected native int or pointer, but got O
		//IL_01a4: Expected native int or pointer, but got O
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			float num3 = _003CmeshHeight_003Ek__BackingField * 0.5f;
			float num4 = num3 * (float)Vector3.downVector;
			float num5 = num4 + position.x;
			float num6 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
			float num7 = num6 * 0f;
			float num8 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
			float num9 = num8 * 0f;
			float num10 = num7 + position.y;
			float num11 = num9 + position.z;
			nint num12 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num13 = 0;
			float num14 = (float)Vector3.upVector * 0.25f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num15 = 0f * 0.25f;
			float x = num14 + num5;
			float z = num15 + num11;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num16 = 0f * 0.25f;
			((Vector3*)(nint)vector)->z = z;
			float y = num16 + num10;
			((Vector3*)(nint)vector)->y = y;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public bool IsImportantEnemy()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		object obj = default(object);
		if (obj != null)
		{
			return true;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383D90");
		bool result = default(bool);
		return result;
	}

	public float GetHeight()
	{
		return _003CmeshHeight_003Ek__BackingField;
	}

	public void DisableSpecialAttacks()
	{
		allowSpecialAttacks = false;
	}

	public unsafe Vector3 GetBottomPosition()
	{
		//IL_0055: Expected I, but got O
		//IL_00f9: Expected native int or pointer, but got O
		//IL_0106: Expected native int or pointer, but got O
		//IL_0113: Expected native int or pointer, but got O
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			float num3 = _003CmeshHeight_003Ek__BackingField * 0.5f;
			float num4 = num3 * (float)Vector3.downVector;
			float num5 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
			float num6 = num5 * 0f;
			float num7 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
			float num8 = num7 * 0f;
			float x = num4 + position.x;
			float z = num6 + position.z;
			float y = num8 + position.y;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = x;
			((Vector3*)(nint)vector)->z = z;
			((Vector3*)(nint)vector)->y = y;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public float GetPowerupDropChance()
	{
		return basePowerupDropChance;
	}

	public float GetHpRatio()
	{
		return _003Chp_003Ek__BackingField / maxHp;
	}

	public Enemy()
	{
		//IL_0112: Expected I, but got O
		flashTime = 0.08f;
		eliteScaleMultiplier = 1.5f;
		maxDespawnTime = 30f;
		speedMultiplier = 1f;
		eliteChallengeFlags = (EEnemyFlag)9;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		defaultScale = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		teleportTime = 0.75f;
		flashInterval = 0.14f;
		List<AddDebuffContainer> toAddBuffer = new List<AddDebuffContainer>();
		_toAddBuffer = toAddBuffer;
		debuffs = new Dictionary<EDebuff, EnemyDebuff>();
		debuffsToRemove = (HashSet<EDebuff>)(object)new HashSet<System.Int32Enum>();
		debuffsToAdd = new Dictionary<EDebuff, AddDebuffContainer>();
		debuffCounts = new Dictionary<EDebuff, int>
		{
			{
				(System.Int32Enum)8,
				0
			},
			{
				(System.Int32Enum)2,
				0
			},
			{
				(System.Int32Enum)32,
				0
			}
		};
		basePowerupDropChance = 0.01f;
		base._002Ector();
	}
}
