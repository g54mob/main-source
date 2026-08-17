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

public class EX_FlikTrailWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public EnemyController closest;

		public EX_FlikTrailWeapon _003C_003E4__this;

		public Transform source;

		public float x;

		public float y;

		public Action _003C_003E9__0;

		internal unsafe void _003CFire_003Eb__0()
		{
			//IL_00cb: Expected O, but got Ref
			//IL_02bd: Expected I, but got O
			//IL_02cb: Expected I, but got O
			//IL_02db: Expected O, but got I
			//IL_035b: Expected O, but got I4
			//IL_0317: Expected O, but got I
			//IL_034d: Expected O, but got I4
			//IL_0438->IL03b6: Incompatible stack heights: 1 vs 0
			//IL_00a6->IL03b6: Incompatible stack heights: 1 vs 0
			//IL_0138->IL03b6: Incompatible stack heights: 1 vs 0
			//IL_017f->IL03b6: Incompatible stack heights: 1 vs 0
			//IL_04b1->IL03b6: Incompatible stack heights: 2 vs 0
			//IL_01fa->IL03b6: Incompatible stack heights: 2 vs 0
			//IL_0228->IL03b6: Incompatible stack heights: 2 vs 0
			//IL_0263->IL03b6: Incompatible stack heights: 2 vs 0
			//IL_0502->IL03b5: Incompatible stack heights: 2 vs 1
			//IL_03a1->IL03b5: Incompatible stack heights: 2 vs 1
			//IL_03b5->IL03b5: Incompatible stack heights: 2 vs 1
			GameManager core = GM.Core;
			Projectile projectile;
			Transform transform4;
			nint num5;
			object obj5;
			int num4;
			if ((object)GM.Core != null)
			{
				EX_FlikTrailWeapon eX_FlikTrailWeapon = _003C_003E4__this;
				if ((object)_003C_003E4__this != null && (object)((Equipment)eX_FlikTrailWeapon)._003COwner_003Ek__BackingField != null)
				{
					Transform transform = ((Equipment)eX_FlikTrailWeapon)._003COwner_003Ek__BackingField.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						EX_FlikTrailWeapon eX_FlikTrailWeapon2 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null && (object)core._stage != null)
						{
							object obj = default(object);
							EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true, eX_FlikTrailWeapon2._range);
							closest = enemyController;
							EnemyController enemyController2 = closest;
							if ((object)closest == null || ((UnityEngine.Object)enemyController2).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							if ((object)_003C_003E4__this != null)
							{
								Transform transform2 = _003C_003E4__this.GetSource();
								source = transform2;
								object obj2 = source;
								if ((object)source != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v10 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v10 (System.Object)+10]");
									Transform.get_position_Injected((IntPtr)0, out ret);
									if ((object)_003C_003E4__this != null)
									{
										float chanceFromArray = _003C_003E4__this.GetChanceFromArray();
										float num = (float)ret * 8f;
										EX_FlikTrailWeapon eX_FlikTrailWeapon3 = _003C_003E4__this;
										float num2 = num * 0.01f;
										float num3 = num2 + (float)ret;
										x = num3;
										if ((object)closest != null)
										{
											Transform transform3 = closest.transform;
											if ((object)_003C_003E4__this != null)
											{
												eX_FlikTrailWeapon3._targetTransform = transform3;
												EX_FlikTrailWeapon eX_FlikTrailWeapon4 = _003C_003E4__this;
												if ((object)_003C_003E4__this != null)
												{
													Vector2 pos = default(Vector2);
													projectile = _003C_003E4__this.FireOneProjectile(pos, 0, eX_FlikTrailWeapon4._targetTransform);
													bool flag3 = (object)projectile == null;
													num4 = 0;
													transform4 = null;
													if (!flag3)
													{
														num5 = (nint)projectile;
														nint num6 = (nint)typeof(EX_FlikTrailProjectile);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v941 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile>)+130]");
														object obj3 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
														nint num7 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v941 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile>)+130]");
														if (num7 >= 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
															object obj4 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v995 @ rax_v62+FFFFFFF8+v942 @ rax_v58*8]");
															if (0 == (nint)typeof(EX_FlikTrailProjectile))
															{
																obj5 = 1;
																goto IL_04bb;
															}
														}
														obj5 = 0;
														goto IL_04bb;
													}
													goto IL_04ea;
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
			IL_04ea:
			if ((object)transform4 != null && ((UnityEngine.Object)transform4).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184F813A0");
			}
			return;
			IL_04bb:
			bool flag4 = obj5 == null;
			num4 = (int)num5;
			transform4 = null;
			if (!flag4)
			{
				num4 = (int)num5;
				transform4 = (Transform)(object)projectile;
			}
			goto IL_04ea;
		}
	}

	public float _range;

	private int _sourceIndex;

	private float _maxSources = 1f;

	private List<Transform> _sources;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0037: Expected F4, but got I4
		base.InitWeapon(characterController, weaponType);
		List<Transform> list = new List<Transform>();
		Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F4B0");
		_sources = list;
		_maxSources = list._size;
	}

	public void SetSources(List<Transform> array)
	{
		//IL_0014: Expected F4, but got I4
		_sources = array;
		_maxSources = array._size;
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_017d: Expected O, but got Ref
		//IL_0421: Expected O, but got I4
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_0282: Expected O, but got F4
		//IL_02c1: Expected I4, but got O
		//IL_02cf: Expected I, but got O
		//IL_02df: Expected O, but got I
		//IL_035f: Expected O, but got I4
		//IL_048c: Expected F4, but got I4
		//IL_049a: Expected I, but got O
		//IL_04aa: Expected O, but got I
		//IL_031b: Expected O, but got I
		//IL_052a: Expected O, but got I4
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_068f: Expected O, but got Unknown
		//IL_06a1: Invalid comparison between F4 and O
		//IL_04e6: Expected O, but got I
		//IL_0351: Expected O, but got I4
		//IL_0537: Expected O, but got I4
		//IL_051c: Expected O, but got I4
		//IL_0835->IL0736: Incompatible stack heights: 1 vs 0
		//IL_01d9->IL0736: Incompatible stack heights: 1 vs 0
		//IL_0720->IL0736: Incompatible stack heights: 2 vs 0
		//IL_0239->IL0736: Incompatible stack heights: 2 vs 0
		//IL_09d2->IL0736: Incompatible stack heights: 2 vs 0
		//IL_05a6->IL0736: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals38 = new _003C_003Ec__DisplayClass6_0();
		float num5;
		Projectile projectile;
		float num6 = default(float);
		object obj3;
		object obj6;
		if (CS_0024_003C_003E8__locals38 != null)
		{
			CS_0024_003C_003E8__locals38._003C_003E4__this = this;
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
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v26 (UnityEngine.Transform)+10]");
										bool flag = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v26 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
										if ((object)core._stage != null)
										{
											object obj = default(object);
											EnemyController closest = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true, _range);
											CS_0024_003C_003E8__locals38.closest = closest;
											Transform source = GetSource();
											CS_0024_003C_003E8__locals38.source = source;
											object source2 = CS_0024_003C_003E8__locals38.source;
											if ((object)CS_0024_003C_003E8__locals38.source != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdi_v7 (System.Object)+10]");
												bool flag2 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdi_v7 (System.Object)+10]");
												Transform.get_position_Injected((IntPtr)0, out ret);
												float chanceFromArray = base.GetChanceFromArray();
												float num3 = (float)ret * 8f;
												object closest2 = CS_0024_003C_003E8__locals38.closest;
												float num4 = num3 * 0.01f;
												float x = num4 + (float)ret;
												CS_0024_003C_003E8__locals38.x = x;
												object obj2 = default(object);
												num5 = (CS_0024_003C_003E8__locals38.y = (float)obj2 + 0.24f);
												if ((object)CS_0024_003C_003E8__locals38.closest != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rdi_v8 (System.Object)+10]");
													if ((nint)0 != 0)
													{
														if ((object)CS_0024_003C_003E8__locals38.closest == null)
														{
															goto IL_0736;
														}
														Transform targetTransform = CS_0024_003C_003E8__locals38.closest.transform;
														_targetTransform = targetTransform;
														num = CS_0024_003C_003E8__locals38.y;
														projectile = base.FireOneProjectile((Vector2)num6, 0, _targetTransform);
														bool flag3;
														if ((object)projectile == null)
														{
															obj3 = null;
															flag3 = false;
															goto IL_0938;
														}
														flag3 = (byte)(int)projectile != 0;
														nint num7 = (nint)typeof(EX_FlikTrailProjectile);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1480 @ rdx_v52 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile>)+130]");
														object obj4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1168 @ r8_v26 (System.Boolean)+130]");
														nint num8 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1480 @ rdx_v52 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile>)+130]");
														if (num8 >= 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1168 @ r8_v26 (System.Boolean)+C8]");
															object obj5 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1563 @ rax_v117+FFFFFFF8+v1481 @ rax_v113*8]");
															if (0 == (nint)typeof(EX_FlikTrailProjectile))
															{
																obj6 = 1;
																goto IL_0911;
															}
														}
														obj6 = 0;
														goto IL_0911;
													}
												}
												goto IL_03c4;
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
		goto IL_0736;
		IL_0736:
		throw new NullReferenceException();
		IL_0911:
		bool flag4 = obj6 == null;
		obj3 = null;
		if (!flag4)
		{
			obj3 = projectile;
		}
		goto IL_0938;
		IL_06b5:
		float num9 = base.PInterval();
		bool flag5 = _lastFiringInterval == num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874F1A47h\"");
		if (!flag5)
		{
			float num10 = base.PInterval();
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
			goto IL_0736;
		}
		return;
		IL_03c4:
		float num11 = base.PAmount();
		if (num5 > 1f)
		{
			float num12 = base.PAmount();
			if (num5 > 1f)
			{
				object obj7 = 1;
				bool flag6 = default(bool);
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
					object obj8 = obj7 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					Action action;
					object obj11;
					if ((nint)obj8 <= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						float num13;
						if (!flag6)
						{
							action = null;
							num13 = num6;
							goto IL_0989;
						}
						num13 = (((bool*)(flag6 ? 1 : 0))->m_value ? 1 : 0);
						nint num14 = (nint)typeof(EX_FlikTrailProjectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1591 @ rdx_v46 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile>)+130]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1664 @ r8_v22 (System.Single)+130]");
						nint num15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1591 @ rdx_v46 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile>)+130]");
						if (num15 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1664 @ r8_v22 (System.Single)+C8]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1704 @ rax_v93+FFFFFFF8+v1592 @ rax_v89*8]");
							if (0 == (nint)typeof(EX_FlikTrailProjectile))
							{
								obj11 = 1;
								goto IL_0962;
							}
						}
						obj11 = 0;
						goto IL_0962;
					}
					if (_currentWeaponData == null)
					{
						break;
					}
					Action onComplete = CS_0024_003C_003E8__locals38._003C_003E9__0;
					if (CS_0024_003C_003E8__locals38._003C_003E9__0 == null)
					{
						onComplete = (CS_0024_003C_003E8__locals38._003C_003E9__0 = delegate
						{
							//IL_00cb: Expected O, but got Ref
							//IL_02bd: Expected I, but got O
							//IL_02cb: Expected I, but got O
							//IL_02db: Expected O, but got I
							//IL_035b: Expected O, but got I4
							//IL_0317: Expected O, but got I
							//IL_034d: Expected O, but got I4
							//IL_0438->IL03b6: Incompatible stack heights: 1 vs 0
							//IL_00a6->IL03b6: Incompatible stack heights: 1 vs 0
							//IL_0138->IL03b6: Incompatible stack heights: 1 vs 0
							//IL_017f->IL03b6: Incompatible stack heights: 1 vs 0
							//IL_04b1->IL03b6: Incompatible stack heights: 2 vs 0
							//IL_01fa->IL03b6: Incompatible stack heights: 2 vs 0
							//IL_0228->IL03b6: Incompatible stack heights: 2 vs 0
							//IL_0263->IL03b6: Incompatible stack heights: 2 vs 0
							//IL_0502->IL03b5: Incompatible stack heights: 2 vs 1
							//IL_03a1->IL03b5: Incompatible stack heights: 2 vs 1
							//IL_03b5->IL03b5: Incompatible stack heights: 2 vs 1
							GameManager core2 = GM.Core;
							Projectile projectile2;
							Transform transform3;
							nint num22;
							object obj15;
							int num21;
							if ((object)GM.Core != null)
							{
								EX_FlikTrailWeapon eX_FlikTrailWeapon = CS_0024_003C_003E8__locals38._003C_003E4__this;
								if ((object)CS_0024_003C_003E8__locals38._003C_003E4__this != null && (object)((Equipment)eX_FlikTrailWeapon)._003COwner_003Ek__BackingField != null)
								{
									Transform transform2 = ((Equipment)eX_FlikTrailWeapon)._003COwner_003Ek__BackingField.transform;
									if ((object)transform2 != null)
									{
										bool flag12 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
										EX_FlikTrailWeapon eX_FlikTrailWeapon2 = CS_0024_003C_003E8__locals38._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals38._003C_003E4__this != null && (object)core2._stage != null)
										{
											object obj12 = default(object);
											EnemyController closest3 = core2._stage.FindClosestEnemy((Vector3)(&obj12), excludeDead: true, eX_FlikTrailWeapon2._range);
											CS_0024_003C_003E8__locals38.closest = closest3;
											EnemyController closest4 = CS_0024_003C_003E8__locals38.closest;
											if ((object)CS_0024_003C_003E8__locals38.closest == null || ((UnityEngine.Object)closest4).m_CachedPtr == (IntPtr)0)
											{
												return;
											}
											if ((object)CS_0024_003C_003E8__locals38._003C_003E4__this != null)
											{
												Transform source3 = CS_0024_003C_003E8__locals38._003C_003E4__this.GetSource();
												CS_0024_003C_003E8__locals38.source = source3;
												object source4 = CS_0024_003C_003E8__locals38.source;
												if ((object)CS_0024_003C_003E8__locals38.source != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v10 (System.Object)+10]");
													bool flag13 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v10 (System.Object)+10]");
													Transform.get_position_Injected((IntPtr)0, out ret2);
													if ((object)CS_0024_003C_003E8__locals38._003C_003E4__this != null)
													{
														float chanceFromArray2 = CS_0024_003C_003E8__locals38._003C_003E4__this.GetChanceFromArray();
														float num19 = (float)ret2 * 8f;
														EX_FlikTrailWeapon eX_FlikTrailWeapon3 = CS_0024_003C_003E8__locals38._003C_003E4__this;
														float num20 = num19 * 0.01f;
														float x2 = num20 + (float)ret2;
														CS_0024_003C_003E8__locals38.x = x2;
														if ((object)CS_0024_003C_003E8__locals38.closest != null)
														{
															Transform targetTransform2 = CS_0024_003C_003E8__locals38.closest.transform;
															if ((object)CS_0024_003C_003E8__locals38._003C_003E4__this != null)
															{
																eX_FlikTrailWeapon3._targetTransform = targetTransform2;
																EX_FlikTrailWeapon eX_FlikTrailWeapon4 = CS_0024_003C_003E8__locals38._003C_003E4__this;
																if ((object)CS_0024_003C_003E8__locals38._003C_003E4__this != null)
																{
																	Vector2 pos = default(Vector2);
																	projectile2 = CS_0024_003C_003E8__locals38._003C_003E4__this.FireOneProjectile(pos, 0, eX_FlikTrailWeapon4._targetTransform);
																	bool flag14 = (object)projectile2 == null;
																	num21 = 0;
																	transform3 = null;
																	if (!flag14)
																	{
																		num22 = (nint)projectile2;
																		nint num23 = (nint)typeof(EX_FlikTrailProjectile);
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v941 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile>)+130]");
																		object obj13 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
																		nint num24 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v941 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_FlikTrailProjectile>)+130]");
																		if (num24 >= 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
																			object obj14 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v995 @ rax_v62+FFFFFFF8+v942 @ rax_v58*8]");
																			if (0 == (nint)typeof(EX_FlikTrailProjectile))
																			{
																				obj15 = 1;
																				goto IL_04bb;
																			}
																		}
																		obj15 = 0;
																		goto IL_04bb;
																	}
																	goto IL_04ea;
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
							IL_04ea:
							if ((object)transform3 != null && ((UnityEngine.Object)transform3).m_CachedPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184F813A0");
							}
							return;
							IL_04bb:
							bool flag15 = obj15 == null;
							num21 = (int)num22;
							transform3 = null;
							if (!flag15)
							{
								num21 = (int)num22;
								transform3 = (Transform)(object)projectile2;
							}
							goto IL_04ea;
						});
					}
					float num16 = (float)obj7 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					float num17 = num16 * 0.001f;
					Timer lastShotTimer = Timers.Register(num17, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
					num5 = num17;
					goto IL_0681;
					IL_0962:
					bool flag7 = obj11 == null;
					action = null;
					if (!flag7)
					{
						action = (Action)flag6;
					}
					goto IL_0989;
					IL_0989:
					bool flag8 = action == null;
					num5 = num6;
					if (!flag8)
					{
						bool flag9 = ((Delegate)action).method_ptr == (IntPtr)0;
						num5 = num6;
						if (!flag9)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184F813A0");
							num5 = num6;
						}
					}
					goto IL_0681;
					IL_0681:
					obj7++;
					float num18 = base.PAmount();
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
					{
						continue;
					}
					goto IL_06b5;
				}
				goto IL_0736;
			}
		}
		goto IL_06b5;
		IL_0938:
		bool flag10 = obj3 == null;
		num5 = num6;
		if (!flag10)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ rdi_v21 (System.Object)+10]");
			bool flag11 = (nint)0 == 0;
			num5 = num6;
			if (!flag11)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184F813A0");
				num5 = num6;
			}
		}
		goto IL_03c4;
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
