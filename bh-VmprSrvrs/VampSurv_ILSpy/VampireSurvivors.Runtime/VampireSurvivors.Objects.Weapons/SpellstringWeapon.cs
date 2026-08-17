using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class SpellstringWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public EnemyController closest;

		public SpellstringWeapon _003C_003E4__this;

		public Transform source;

		public float x;

		public float y;

		public Action _003C_003E9__0;

		internal unsafe void _003CFire_003Eb__0()
		{
			//IL_00cb: Expected O, but got Ref
			//IL_032f->IL02ad: Incompatible stack heights: 1 vs 0
			//IL_00a6->IL02ad: Incompatible stack heights: 1 vs 0
			//IL_0138->IL02ad: Incompatible stack heights: 1 vs 0
			//IL_017f->IL02ad: Incompatible stack heights: 1 vs 0
			//IL_03a3->IL02ad: Incompatible stack heights: 2 vs 0
			//IL_01f0->IL02ad: Incompatible stack heights: 2 vs 0
			//IL_021e->IL02ad: Incompatible stack heights: 2 vs 0
			//IL_0251->IL02ad: Incompatible stack heights: 2 vs 0
			//IL_0292->IL02ad: Incompatible stack heights: 2 vs 0
			//IL_02ad->IL0358: Incompatible stack heights: 2 vs 1
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				SpellstringWeapon spellstringWeapon = _003C_003E4__this;
				if ((object)_003C_003E4__this != null && (object)((Equipment)spellstringWeapon)._003COwner_003Ek__BackingField != null)
				{
					Transform transform = ((Equipment)spellstringWeapon)._003COwner_003Ek__BackingField.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						SpellstringWeapon spellstringWeapon2 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null && (object)core._stage != null)
						{
							object obj = default(object);
							EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true, spellstringWeapon2._range);
							closest = enemyController;
							Transform transform2 = (Transform)(object)closest;
							if ((object)closest == null || ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							if ((object)_003C_003E4__this != null)
							{
								Transform transform3 = _003C_003E4__this.GetSource();
								source = transform3;
								Transform transform4 = source;
								if ((object)source != null)
								{
									bool flag2 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
									if ((object)_003C_003E4__this != null)
									{
										float chanceFromArray = _003C_003E4__this.GetChanceFromArray();
										float num = (float)ret * 8f;
										float num2 = num * 0.01f;
										float num3 = num2 + (float)ret;
										x = num3;
										if ((object)closest != null)
										{
											Transform transform5 = closest.transform;
											if ((object)_003C_003E4__this != null)
											{
												SpellstringWeapon spellstringWeapon3 = _003C_003E4__this;
												if ((object)_003C_003E4__this != null)
												{
													Vector2 pos = default(Vector2);
													Projectile projectile = _003C_003E4__this.FireOneProjectile(pos, 0, spellstringWeapon3._targetTransform);
													if ((object)_003C_003E4__this != null)
													{
														_003C_003E4__this.DealDamage(closest);
														return;
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
			throw new NullReferenceException();
		}
	}

	private float _range;

	private int _sourceIndex;

	private float _maxSources = 1f;

	private List<Transform> _sources;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		List<Transform> list = new List<Transform>();
		Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F4B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 77 Invalid \"Jump target not found in method: 0x1873B38C0\"");
		throw new NullReferenceException();
	}

	public void SetSources(List<Transform> array)
	{
		//IL_0014: Expected F4, but got I4
		_sources = array;
		_maxSources = array._size;
	}

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null)
		{
			float num = base.PSpeed();
			float num3 = default(float);
			float num2 = num3 * 1.25f;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = num2 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num5 = num4 * num3;
					return num3 + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_017d: Expected O, but got Ref
		//IL_05ed: Expected O, but got I
		//IL_02d5: Expected O, but got I4
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_0282: Expected O, but got F4
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Expected O, but got Unknown
		//IL_0444: Invalid comparison between F4 and O
		//IL_05d8->IL04d9: Incompatible stack heights: 1 vs 0
		//IL_01d9->IL04d9: Incompatible stack heights: 1 vs 0
		//IL_04c3->IL04d9: Incompatible stack heights: 2 vs 0
		//IL_0239->IL04d9: Incompatible stack heights: 2 vs 0
		//IL_070d->IL04d9: Incompatible stack heights: 2 vs 0
		//IL_0349->IL04d9: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals42 = new _003C_003Ec__DisplayClass7_0();
		float num5;
		if (CS_0024_003C_003E8__locals42 != null)
		{
			CS_0024_003C_003E8__locals42._003C_003E4__this = this;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null && (object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							if (s_scene2._renderer != null)
							{
								float num = renderer2.height * 0.4f;
								float num2 = renderer.width * 0.4f;
								if (!(num > num2))
								{
									num2 = num;
								}
								_range = num2;
								GameManager core = GM.Core;
								if ((object)GM.Core != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
								{
									Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
									if ((object)transform != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v26 (UnityEngine.Transform)+10]");
										bool flag = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v26 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
										if ((object)core._stage != null)
										{
											object obj = default(object);
											EnemyController closest = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true, _range);
											CS_0024_003C_003E8__locals42.closest = closest;
											Transform source = GetSource();
											CS_0024_003C_003E8__locals42.source = source;
											object source2 = CS_0024_003C_003E8__locals42.source;
											if ((object)CS_0024_003C_003E8__locals42.source != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rsi_v7 (System.Object)+10]");
												Action action = (Action)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rsi_v7 (System.Object)+10]");
												bool flag2 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rsi_v7 (System.Object)+10]");
												Transform.get_position_Injected((IntPtr)0, out ret);
												float chanceFromArray = base.GetChanceFromArray();
												float num3 = (float)ret * 8f;
												object closest2 = CS_0024_003C_003E8__locals42.closest;
												float num4 = num3 * 0.01f;
												float x = num4 + (float)ret;
												CS_0024_003C_003E8__locals42.x = x;
												object obj2 = default(object);
												num5 = (CS_0024_003C_003E8__locals42.y = (float)obj2 + 0.24f);
												float num6 = default(float);
												if ((object)CS_0024_003C_003E8__locals42.closest != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rsi_v8 (System.Object)+10]");
													if ((nint)0 != 0)
													{
														if ((object)CS_0024_003C_003E8__locals42.closest == null)
														{
															goto IL_04d9;
														}
														Transform targetTransform = CS_0024_003C_003E8__locals42.closest.transform;
														_targetTransform = targetTransform;
														num = CS_0024_003C_003E8__locals42.y;
														Projectile projectile = base.FireOneProjectile((Vector2)num6, 0, _targetTransform);
														base.DealDamage(CS_0024_003C_003E8__locals42.closest);
														num5 = num6;
													}
												}
												float num7 = base.PAmount();
												if (num5 > 1f)
												{
													float num8 = base.PAmount();
													if (num5 > 1f)
													{
														object obj3 = 1;
														bool useRealTime = default(bool);
														MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
														int repeat = default(int);
														TimerType type = default(TimerType);
														while (true)
														{
															WeaponData currentWeaponData = _currentWeaponData;
															if (_currentWeaponData == null)
															{
																break;
															}
															object obj4 = obj3 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
															if ((nint)obj4 <= 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
																base.DealDamage(CS_0024_003C_003E8__locals42.closest);
																num5 = num6;
															}
															else
															{
																if (_currentWeaponData == null)
																{
																	break;
																}
																action = CS_0024_003C_003E8__locals42._003C_003E9__0;
																if (CS_0024_003C_003E8__locals42._003C_003E9__0 == null)
																{
																	action = (CS_0024_003C_003E8__locals42._003C_003E9__0 = delegate
																	{
																		//IL_00cb: Expected O, but got Ref
																		//IL_032f->IL02ad: Incompatible stack heights: 1 vs 0
																		//IL_00a6->IL02ad: Incompatible stack heights: 1 vs 0
																		//IL_0138->IL02ad: Incompatible stack heights: 1 vs 0
																		//IL_017f->IL02ad: Incompatible stack heights: 1 vs 0
																		//IL_03a3->IL02ad: Incompatible stack heights: 2 vs 0
																		//IL_01f0->IL02ad: Incompatible stack heights: 2 vs 0
																		//IL_021e->IL02ad: Incompatible stack heights: 2 vs 0
																		//IL_0251->IL02ad: Incompatible stack heights: 2 vs 0
																		//IL_0292->IL02ad: Incompatible stack heights: 2 vs 0
																		//IL_02ad->IL0358: Incompatible stack heights: 2 vs 1
																		GameManager core2 = GM.Core;
																		if ((object)GM.Core != null)
																		{
																			SpellstringWeapon spellstringWeapon = CS_0024_003C_003E8__locals42._003C_003E4__this;
																			if ((object)CS_0024_003C_003E8__locals42._003C_003E4__this != null && (object)((Equipment)spellstringWeapon)._003COwner_003Ek__BackingField != null)
																			{
																				Transform transform2 = ((Equipment)spellstringWeapon)._003COwner_003Ek__BackingField.transform;
																				if ((object)transform2 != null)
																				{
																					bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
																					SpellstringWeapon spellstringWeapon2 = CS_0024_003C_003E8__locals42._003C_003E4__this;
																					if ((object)CS_0024_003C_003E8__locals42._003C_003E4__this != null && (object)core2._stage != null)
																					{
																						object obj5 = default(object);
																						EnemyController closest3 = core2._stage.FindClosestEnemy((Vector3)(&obj5), excludeDead: true, spellstringWeapon2._range);
																						CS_0024_003C_003E8__locals42.closest = closest3;
																						Transform closest4 = (Transform)(object)CS_0024_003C_003E8__locals42.closest;
																						if ((object)CS_0024_003C_003E8__locals42.closest == null || ((UnityEngine.Object)closest4).m_CachedPtr == (IntPtr)0)
																						{
																							return;
																						}
																						if ((object)CS_0024_003C_003E8__locals42._003C_003E4__this != null)
																						{
																							Transform source3 = CS_0024_003C_003E8__locals42._003C_003E4__this.GetSource();
																							CS_0024_003C_003E8__locals42.source = source3;
																							Transform source4 = CS_0024_003C_003E8__locals42.source;
																							if ((object)CS_0024_003C_003E8__locals42.source != null)
																							{
																								bool flag5 = ((UnityEngine.Object)source4).m_CachedPtr == (IntPtr)0;
																								Transform.get_position_Injected(((UnityEngine.Object)source4).m_CachedPtr, out ret2);
																								if ((object)CS_0024_003C_003E8__locals42._003C_003E4__this != null)
																								{
																									float chanceFromArray2 = CS_0024_003C_003E8__locals42._003C_003E4__this.GetChanceFromArray();
																									float num14 = (float)ret2 * 8f;
																									float num15 = num14 * 0.01f;
																									float x2 = num15 + (float)ret2;
																									CS_0024_003C_003E8__locals42.x = x2;
																									if ((object)CS_0024_003C_003E8__locals42.closest != null)
																									{
																										Transform transform3 = CS_0024_003C_003E8__locals42.closest.transform;
																										if ((object)CS_0024_003C_003E8__locals42._003C_003E4__this != null)
																										{
																											SpellstringWeapon spellstringWeapon3 = CS_0024_003C_003E8__locals42._003C_003E4__this;
																											if ((object)CS_0024_003C_003E8__locals42._003C_003E4__this != null)
																											{
																												Vector2 pos = default(Vector2);
																												Projectile projectile2 = CS_0024_003C_003E8__locals42._003C_003E4__this.FireOneProjectile(pos, 0, spellstringWeapon3._targetTransform);
																												if ((object)CS_0024_003C_003E8__locals42._003C_003E4__this != null)
																												{
																													CS_0024_003C_003E8__locals42._003C_003E4__this.DealDamage(CS_0024_003C_003E8__locals42.closest);
																													return;
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
																		throw new NullReferenceException();
																	});
																}
																float num9 = (float)obj3 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
																float num10 = num9 * 0.001f;
																Timer lastShotTimer = Timers.Register(num10, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																_lastShotTimer = lastShotTimer;
																num5 = num10;
															}
															obj3++;
															float num11 = base.PAmount();
															if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
															{
																continue;
															}
															goto IL_0458;
														}
														goto IL_04d9;
													}
												}
												goto IL_0458;
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
		goto IL_04d9;
		IL_0458:
		float num12 = base.PInterval();
		bool flag3 = _lastFiringInterval == num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873B41A3h\"");
		if (!flag3)
		{
			float num13 = base.PInterval();
			_lastFiringInterval = num5;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
				return;
			}
			goto IL_04d9;
		}
		return;
		IL_04d9:
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		//IL_0018: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		_isVisible = visible;
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] < 0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private Transform GetSource()
	{
		List<Transform> sources = _sources;
		if (++_sourceIndex >= sources._size)
		{
			_sourceIndex = 0;
		}
		int sourceIndex = _sourceIndex;
		if (_sourceIndex < sources._size)
		{
			Transform[] items = sources._items;
			return items[sourceIndex];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Transform result = default(Transform);
		return result;
	}
}
