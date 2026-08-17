using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_JetBlackWhip1_Projectile : TP_WhipCore_Projectile
{
	[NonSerialized]
	public float LineAlpha;

	private MultiTargetTween _lineTween;

	[NonSerialized]
	public float LerpRatio;

	private MultiTargetTween _lerpTween;

	private List<Vector2> _waypointListDefault;

	private List<Vector2> _waypointList;

	private bool _targetEnemy;

	private int _attackCount;

	private int _attackAmount;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		((Projectile)this).InitProjectile(pool, weapon, index);
		_isCullable = false;
		base.InitWhips();
		LineAlpha = 1f;
		_attackCount = 0;
		startAttack(_timeStartAttack);
	}

	protected override Projectile CreateNodeProjectile(float2 pos)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			nint num = (nint)typeof(TP_JetBlackWhip1_Weapon);
			nint num2 = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_JetBlackWhip1_Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_JetBlackWhip1_Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5+FFFFFFF8+v46 @ rax_v4*8]");
				if (0 == (nint)typeof(TP_JetBlackWhip1_Weapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_JetBlackWhip1_Weapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5+FFFFFFF8+v88 @ rcx_v4*8]");
					object obj4 = 0 - typeof(TP_JetBlackWhip1_Weapon);
					bool flag = obj4 == null;
					bool flag2 = !flag;
					TP_WhipCore1_Weapon tP_WhipCore1_Weapon = null;
					if (!flag2)
					{
						tP_WhipCore1_Weapon = (TP_WhipCore1_Weapon)_weapon;
					}
					float area = default(float);
					return tP_WhipCore1_Weapon.CreateNodeProjectile(pos, 0, 1, area);
				}
			}
		}
		return (Projectile)(object)new NullReferenceException();
	}

	private void startAttack(float delay)
	{
		//IL_003f: Expected I, but got O
		bool flag = _lerpTween == null;
		LerpRatio = 0f;
		if (!flag)
		{
			_lerpTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"LerpRatio", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.ease = Ease.OutQuad;
			tweenConfig.delay = delay;
			tweenConfig.duration = _timeLerpRatio;
			TweenCallback onStart = OnWhipStart;
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = OnWhipComplete;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween lerpTween = Tweens.Add(tweenConfig);
			_lerpTween = lerpTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void OnWhipStart()
	{
		//IL_0698: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_0196: Expected O, but got Ref
		//IL_020f: Expected O, but got I
		//IL_0743: Invalid comparison between F4 and I4
		//IL_02f3: Expected O, but got I
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_03ac: Expected I, but got O
		//IL_0482: Expected O, but got F4
		//IL_0494: Expected O, but got F4
		//IL_043e: Expected I, but got O
		//IL_04be: Expected I, but got O
		//IL_052f: Expected O, but got I
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Expected O, but got Unknown
		//IL_05fc: Expected I, but got O
		//IL_07ae->IL069d: Incompatible stack heights: 1 vs 0
		//IL_033b->IL069d: Incompatible stack heights: 1 vs 0
		//IL_0414->IL069d: Incompatible stack heights: 1 vs 0
		//IL_0461->IL0461: Incompatible stack heights: 2 vs 1
		//IL_0519->IL069d: Incompatible stack heights: 1 vs 0
		//IL_04e1->IL04e1: Incompatible stack heights: 2 vs 1
		//IL_054b->IL069d: Incompatible stack heights: 1 vs 0
		//IL_0807->IL069d: Incompatible stack heights: 2 vs 0
		//IL_0577->IL069d: Incompatible stack heights: 2 vs 0
		//IL_061f->IL061f: Incompatible stack heights: 3 vs 2
		//IL_0664->IL06c6: Incompatible stack heights: 2 vs 0
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Whip, soundConfig, 200f, 10, time);
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
			object obj = (flag ? 1 : 0) ^ 1;
			object obj2 = obj * 2;
			float flipNum = (float)obj2 - 1f;
			_flipNum = flipNum;
			_waypointList = _waypointListDefault;
			_targetEnemy = false;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
					if ((object)core._stage != null)
					{
						Vector3 ret = default(Vector3);
						EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&ret), excludeDead: true);
						if ((object)enemyController == null || !((SoundManager.SoundConfig)(object)enemyController).Mute)
						{
							goto IL_06c6;
						}
						((ArcadeSprite)enemyController).CheckRenderer();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v40 (VampireSurvivors.Objects.Characters.EnemyController)+48]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v40 (VampireSurvivors.Objects.Characters.EnemyController)+48]");
							Transform transform = ((Component)0).transform;
							if ((object)transform != null)
							{
								if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
								{
									UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
								}
								else
								{
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
									Weapon weapon3 = _weapon;
									if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
									{
										float2 float6 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
										bool flag2 = _whipSize > 2f;
										float num = 2f;
										if (!flag2)
										{
											num = _whipSize;
										}
										if (!(num > 1.06032006E+09f))
										{
											goto IL_06c6;
										}
										((ArcadeSprite)enemyController).CheckRenderer();
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v40 (VampireSurvivors.Objects.Characters.EnemyController)+48]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v40 (VampireSurvivors.Objects.Characters.EnemyController)+48]");
											Transform transform2 = ((Component)0).transform;
											if ((object)transform2 != null)
											{
												bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
												Weapon weapon4 = _weapon;
												if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
												{
													float2 float7 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.position;
													object obj4 = default(object);
													object obj3 = obj4 - 1060320051;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
													object obj5 = default(object);
													float num2 = (float)obj5 * -0.5f;
													float num3 = 1.06032006E+09f * -0.5f;
													WhipVerletNode[] array = new WhipVerletNode[3];
													nint num4 = (nint)typeof(float2);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1302 @ rcx_v55 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
													nint num5 = 0;
													WhipVerletNode whipVerletNode = null;
													whipVerletNode.position = float2.zero;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v33 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
													_ = 0;
													whipVerletNode.oldPosition = float2.zero;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v33 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
													_ = 0;
													if (array != null)
													{
														if (whipVerletNode != null)
														{
															nint num6 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj6 = default(object);
															bool flag4 = obj6 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														WhipVerletNode whipVerletNode2 = null;
														whipVerletNode2.position = (float2)num2;
														whipVerletNode2.oldPosition = (float2)num2;
														if (whipVerletNode2 != null)
														{
															nint num7 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj7 = default(object);
															bool flag5 = obj7 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														((ArcadeSprite)enemyController).CheckRenderer();
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v40 (VampireSurvivors.Objects.Characters.EnemyController)+48]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v40 (VampireSurvivors.Objects.Characters.EnemyController)+48]");
															Transform transform3 = ((Component)0).transform;
															if ((object)transform3 != null)
															{
																bool flag6 = !((SoundManager.SoundConfig)(object)transform3).Mute;
																Transform.get_position_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform3).Mute ? 1 : 0), out ret);
																Weapon weapon5 = _weapon;
																if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
																{
																	float2 float8 = ((Equipment)weapon5)._003COwner_003Ek__BackingField.position;
																	float2 oldPosition = (object)ret - (object)float8;
																	object obj8 = obj4 - 1060320051;
																	WhipVerletNode whipVerletNode3 = null;
																	whipVerletNode3.position = oldPosition;
																	whipVerletNode3.oldPosition = oldPosition;
																	if (whipVerletNode3 != null)
																	{
																		nint num8 = (nint)array;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																		object obj9 = default(object);
																		bool flag7 = obj9 == null;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	List<Vector2> waypointList = TP_WhipCore_Projectile.GenerateSpline(array, 10);
																	_waypointList = waypointList;
																	_targetEnemy = true;
																	goto IL_06c6;
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
			}
		}
		throw new NullReferenceException();
		IL_06c6:
		_applyNodeControl = true;
		bodyEnabled(enable: true);
	}

	private void OnWhipComplete()
	{
		//IL_0015: Expected O, but got I4
		//IL_004d: Expected I, but got O
		//IL_0055: Expected I, but got O
		//IL_0065: Expected O, but got I
		//IL_00a1: Expected O, but got I
		//IL_00de: Expected O, but got I
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0240: Expected I, but got O
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		WhipVerletNode[] nodes = _nodes;
		object obj = nodes.Length - 1;
		WhipVerletNode whipVerletNode = nodes[obj];
		Weapon weapon = _weapon;
		nint num = (nint)typeof(TP_JetBlackWhip1_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_JetBlackWhip1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r10_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_JetBlackWhip1_Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r10_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v13+FFFFFFF8+v124 @ rax_v12*8]");
			if (0 == (nint)typeof(TP_JetBlackWhip1_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_JetBlackWhip1_Weapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v13+FFFFFFF8+v363 @ rcx_v7*8]");
				object obj5 = 0 - typeof(TP_JetBlackWhip1_Weapon);
				bool flag = obj5 == null;
				bool flag2 = !flag;
				TP_JetBlackWhip1_Weapon tP_JetBlackWhip1_Weapon = null;
				if (!flag2)
				{
					tP_JetBlackWhip1_Weapon = (TP_JetBlackWhip1_Weapon)weapon;
				}
				Vector2 pos = default(Vector2);
				tP_JetBlackWhip1_Weapon.FireImpactProjectiles(pos);
				if (_attackCount >= _attackAmount)
				{
					Projectile[] nodeProjectiles = _nodeProjectiles;
					_applyNodeControl = false;
					TP_JetBlackWhip1_Weapon tP_JetBlackWhip1_Weapon2 = null;
					TP_JetBlackWhip1_Weapon tP_JetBlackWhip1_Weapon3 = null;
					while ((nint)tP_JetBlackWhip1_Weapon3 < nodeProjectiles.Length)
					{
						Projectile[] nodeProjectiles2 = _nodeProjectiles;
						Projectile projectile = nodeProjectiles2[(object)tP_JetBlackWhip1_Weapon2];
						BaseBody baseBody = projectile.body;
						tP_JetBlackWhip1_Weapon2 = (TP_JetBlackWhip1_Weapon)(tP_JetBlackWhip1_Weapon2 + 1);
						baseBody._enable = false;
						nodeProjectiles = _nodeProjectiles;
						tP_JetBlackWhip1_Weapon3 = tP_JetBlackWhip1_Weapon2;
					}
					if (_lineTween != null)
					{
						_lineTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					nint num4 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj6 = default(object);
					if (obj6 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig.targets = array;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object value = default(object);
					bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"LineAlpha", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					tweenConfig.custom = dictionary;
					tweenConfig.duration = _timeFadeOut;
					tweenConfig.delay = _delayFadeOut;
					TweenCallback onComplete = delegate
					{
						Despawn();
					};
					tweenConfig.onComplete = onComplete;
					MultiTargetTween lineTween = Tweens.Add(tweenConfig);
					_lineTween = lineTween;
				}
				else
				{
					int attackCount = _attackCount + 1;
					_attackCount = attackCount;
					startAttack(0f);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0062: Expected O, but got I4
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Expected O, but got Unknown
		//IL_0502: Expected O, but got I4
		//IL_00c9: Expected O, but got I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected I4, but got Unknown
		//IL_01ca: Expected O, but got I
		//IL_0222: Expected O, but got I
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Expected O, but got Unknown
		//IL_02b3: Expected I4, but got O
		//IL_05ad: Expected I4, but got O
		//IL_05c6: Expected O, but got Ref
		//IL_0192->IL04dc: Incompatible stack heights: 1 vs 0
		//IL_01ea->IL04dc: Incompatible stack heights: 2 vs 0
		//IL_0243->IL04dc: Incompatible stack heights: 3 vs 0
		//IL_0694->IL04dc: Incompatible stack heights: 1 vs 0
		//IL_056e->IL04dc: Incompatible stack heights: 3 vs 0
		//IL_0359->IL05cb: Incompatible stack heights: 3 vs 0
		//IL_06f7->IL04dc: Incompatible stack heights: 2 vs 0
		//IL_02e1->IL04dc: Incompatible stack heights: 3 vs 0
		//IL_0303->IL04dc: Incompatible stack heights: 3 vs 0
		//IL_0757->IL04dc: Incompatible stack heights: 3 vs 0
		//IL_05cb->IL053c: Incompatible stack heights: 5 vs 3
		//IL_0795->IL0610: Incompatible stack heights: 4 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			bool flag = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
			if (!flag)
			{
				float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				base.position = float5;
				ApplyGravity();
				ApplyManualNodeControl();
				object obj = 5;
				object obj2;
				do
				{
					ApplyVerletConstraints();
					obj--;
					obj2 = !flag;
				}
				while (obj2 != null);
				Projectile[] nodeProjectiles = _nodeProjectiles;
				if (_nodeProjectiles != null)
				{
					WhipVerletNode[] nodes = _nodes;
					if (_nodes != null)
					{
						object obj3 = nodes.Length - 1;
						object obj4 = nodeProjectiles.Length / obj3;
						int stepsPerCurve = obj4 - 1;
						List<Vector2> list = TP_WhipCore_Projectile.GenerateSpline(_nodes, stepsPerCurve, 0.5f);
						Projectile[] nodeProjectiles2 = _nodeProjectiles;
						if (_nodeProjectiles != null)
						{
							object obj5 = obj;
							float2 float6 = default(float2);
							object obj10 = default(object);
							object obj11 = default(object);
							float2 ret = default(float2);
							float2 value = default(float2);
							while (true)
							{
								if ((nint)obj5 < nodeProjectiles2.Length)
								{
									Projectile[] nodeProjectiles3 = _nodeProjectiles;
									if (_nodeProjectiles == null)
									{
										break;
									}
									bool flag2 = (nint)obj >= nodeProjectiles3.Length;
									if (list == null)
									{
										break;
									}
									object obj6 = obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v48 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
									bool flag3 = (nint)obj6 >= 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v48 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v48 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
									if ((nint)0 == 0)
									{
										break;
									}
									object obj8 = obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v49+18]");
									bool flag4 = (nint)obj8 >= 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v49+24+v176 @ rbx_v19 (System.Object)*8]");
									object obj9 = 0;
									if ((object)nodeProjectiles3[obj] == null)
									{
										break;
									}
									nodeProjectiles3[obj].position = float6;
									object lineRenderer = _lineRenderer;
									bool flag5 = (object)_lineRenderer == null;
									float2 float7 = float6;
									if (!flag5)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rsi_v24 (System.Object)+10]");
										bool flag6 = (nint)0 == 0;
										float7 = float6;
										if (!flag6)
										{
											int num = (int)_lineRenderer;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
											Weapon weapon2 = _weapon;
											if ((object)_weapon == null || (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null)
											{
												break;
											}
											float2 float8 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
											obj9 = obj10 - obj11;
											bool flag7 = (object)_lineRenderer == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rbp_v21 (System.Int32)+10]");
											bool flag8 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rbp_v21 (System.Int32)+10]");
											LineRenderer.SetPosition_Injected((IntPtr)0, (int)obj, ref *(Vector3*)(&ret));
											ret = float6;
											float7 = float6;
											obj3 = (object)(&ret);
										}
									}
									nodeProjectiles2 = _nodeProjectiles;
									obj++;
									if (_nodeProjectiles == null)
									{
										break;
									}
									obj5 = obj;
									continue;
								}
								LineRenderer lineRenderer2 = _lineRenderer;
								if ((object)_lineRenderer != null && ((UnityEngine.Object)lineRenderer2).m_CachedPtr != (IntPtr)0)
								{
									object lineRenderer3 = _lineRenderer;
									if ((object)_lineRenderer == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v24 (System.Object)+10]");
									bool flag9 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v24 (System.Object)+10]");
									IntPtr material_Injected = Renderer.GetMaterial_Injected((IntPtr)0);
									Material material = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected);
									if ((object)material == null)
									{
										break;
									}
									int num2 = Shader.PropertyToID("_Color");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v70 (UnityEngine.Material)+10]");
									bool flag10 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v70 (UnityEngine.Material)+10]");
									Material.GetColorImpl_Injected((IntPtr)0, num2, out *(Color*)(&ret));
									object lineRenderer4 = _lineRenderer;
									if ((object)_lineRenderer == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rbx_v26 (System.Object)+10]");
									bool flag11 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rbx_v26 (System.Object)+10]");
									IntPtr material_Injected2 = Renderer.GetMaterial_Injected((IntPtr)0);
									Material material2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected2);
									if ((object)material2 == null)
									{
										break;
									}
									int num3 = Shader.PropertyToID("_Color");
									bool flag12 = ((UnityEngine.Object)material2).m_CachedPtr == (IntPtr)0;
									Material.SetColorImpl_Injected(((UnityEngine.Object)material2).m_CachedPtr, num3, ref *(Color*)(&value));
								}
								Weapon weapon3 = _weapon;
								if ((object)_weapon == null || (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null)
								{
									break;
								}
								int num4 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.depth;
								int num5 = num4 - 1;
								ArcadeSprite arcadeSprite = setDepth(num5);
								object lineRenderer5 = _lineRenderer;
								int num6 = base.depth;
								if ((object)_lineRenderer == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rsi_v18 (System.Object)+10]");
								if ((nint)0 == 0)
								{
									UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_lineRenderer);
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 160 ConditionalJump @-1, v240 @ TEMP_v39 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 185 ConditionalJump @-1, v241 @ TEMP_v40 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 209 ConditionalJump @-1, v242 @ TEMP_v41 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 373 ConditionalJump @-1, v618 @ ZF_v84 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 408 ConditionalJump @-1, v557 @ ZF_v86 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 594 ConditionalJump @-1, v1187 @ ZF_v42 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 675 ConditionalJump @-1, v1619 @ ZF_v47 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 766 ConditionalJump @-1, v1686 @ ZF_v53 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 854 ConditionalJump @-1, v1587 @ ZF_v58 (System.Boolean) --- -1 Nop");
								/*Error: End of method reached without returning.*/;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ApplyManualNodeControl()
	{
		//IL_0097: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0150: Expected O, but got I4
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_0360: Expected O, but got I4
		//IL_02fc: Expected O, but got I
		//IL_0261: Expected O, but got I
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		WhipVerletNode[] nodes = _nodes;
		WhipVerletNode whipVerletNode = nodes[0];
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = float5 + _characterOffset;
		float num2 = default(float);
		float num = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_JetBlackWhip1_Projectile)+100]");
		float num3 = num + 0f;
		whipVerletNode.position = float6;
		WhipVerletNode[] nodes2 = _nodes;
		object obj = 1;
		object obj2 = 1;
		WhipVerletNode[] nodes3 = _nodes;
		while ((nint)obj < nodes2.Length)
		{
			WhipVerletNode whipVerletNode2 = nodes3[obj2];
			whipVerletNode2.isStatic = false;
			obj2++;
			nodes3 = _nodes;
			obj = obj2;
			nodes2 = _nodes;
		}
		WhipVerletNode[] nodes4 = _nodes;
		object obj3 = nodes4.Length * LerpRatio;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		WhipVerletNode[] nodes5 = _nodes;
		object obj4 = nodes5.Length - 1;
		object obj5 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
			obj4 = obj5;
		}
		bool flag = (nint)obj4 < 1;
		object obj6 = 1;
		if (!flag)
		{
			obj6 = obj4;
		}
		WhipVerletNode[] nodes6 = _nodes;
		WhipVerletNode whipVerletNode3 = nodes6[obj6];
		whipVerletNode3.isStatic = _applyNodeControl;
		WhipVerletNode[] nodes7 = _nodes;
		WhipVerletNode whipVerletNode4 = nodes7[obj6];
		if (whipVerletNode4.isStatic)
		{
			WhipVerletNode whipVerletNode5;
			float2 float7;
			object obj7;
			float2 float9;
			float num4;
			if (!_targetEnemy)
			{
				whipVerletNode5 = nodes7[obj6];
				WhipVerletNode whipVerletNode6 = nodes7[0];
				float7 = whipVerletNode6.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v16 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
				obj7 = 0;
				float2 float8 = MultiLerp(_waypointList, LerpRatio);
				float9 = float8 * _flipNum;
				num4 = num2 * -1f;
			}
			else
			{
				whipVerletNode5 = nodes7[obj6];
				WhipVerletNode whipVerletNode7 = nodes7[0];
				float7 = whipVerletNode7.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v14 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
				obj7 = 0;
				float2 float10 = MultiLerp(_waypointList, LerpRatio);
				num4 = num2;
				float9 = float10;
			}
			float2 float11 = float9 + float7;
			float num5 = num4 + (float)obj7;
			whipVerletNode5.position = float11;
		}
	}

	protected override float CalculateIndexNodeDistance(int index)
	{
		WhipVerletNode[] nodes = _nodes;
		float num = _nodeDistance / (float)nodes.Length;
		float num2 = num * (float)index;
		return num2 + 0.15f;
	}

	public override void Despawn()
	{
		if (_lineTween != null)
		{
			_lineTween.Kill();
		}
		if (_lerpTween != null)
		{
			_lerpTween.Kill();
		}
		base.Despawn();
	}

	public TP_JetBlackWhip1_Projectile()
	{
		Vector2 item = default(Vector2);
		_waypointListDefault = new List<Vector2>
		{
			item, item, item, item, item, item, item, item, item, item,
			item, item, item, item, item, item, item, item, item, item,
			item, item, item, item, item
		};
		base._002Ector();
	}

	private void _003COnWhipComplete_003Eb__13_0()
	{
		Despawn();
	}
}
