using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyTrina : EnemyController
{
	private int _activated;

	private Tween _onEnterTween;

	private float _legsAngle;

	private SpriteRenderer _wings;

	private SpriteRenderer _snakes;

	private SpriteRenderer _legs;

	private SpriteAnimation _wingsSpriteAnimation;

	private SpriteAnimation _snakesSpriteAnimation;

	private SpriteAnimation _legsSpriteAnimation;

	private const float LegsSpeed = 500f;

	protected override void Awake()
	{
		base.Awake();
		GenerateSpritesAndAnims();
		_activated = 0;
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		base._003CIsCullable_003Ek__BackingField = false;
		UpdateSprites();
		_wings.enabled = true;
		_snakes.enabled = true;
		_legs.enabled = true;
		EnemyData currentEnemyData = _currentEnemyData;
		_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
	}

	public override void Disappear()
	{
		base.Disappear();
		_wings.enabled = false;
		_snakes.enabled = false;
		_legs.enabled = false;
	}

	public override void Despawn()
	{
		base.Despawn();
		_wings.enabled = false;
		_snakes.enabled = false;
		_legs.enabled = false;
	}

	protected override void OnUpdate()
	{
		//IL_015e: Invalid comparison between F4 and O
		//IL_0116->IL00bb: Incompatible stack heights: 1 vs 0
		//IL_006d->IL00bb: Incompatible stack heights: 1 vs 0
		//IL_009c->IL00bb: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		float num = (float)_activated * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
					object obj = default(object);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)10.24f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
					{
						_activated = 1;
					}
					base.OnUpdate();
					UpdateSprites();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void Die()
	{
		base.Die();
		_wings.enabled = false;
		_snakes.enabled = false;
		_legs.enabled = false;
	}

	private unsafe void GenerateSpritesAndAnims()
	{
		//IL_027d: Expected I4, but got O
		//IL_02c9: Expected I4, but got O
		//IL_02e6: Expected I4, but got O
		//IL_0337: Expected I4, but got O
		//IL_0354: Expected I4, but got O
		//IL_03a5: Expected I4, but got O
		//IL_004a->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_0086->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_00b2->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_010e->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_014a->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_0176->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_01d2->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_020e->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_023a->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_029b->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_0309->IL03a6: Incompatible stack heights: 1 vs 0
		//IL_0377->IL03a6: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
			GameObject gameObject = base.gameObject;
			float y = default(float);
			string text = default(string);
			SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, ret, y, "enemies2", text);
			if ((object)spriteRenderer != null)
			{
				((UnityEngine.Object)spriteRenderer).SetName("Wings");
				_wings = spriteRenderer;
				if ((object)_wings != null)
				{
					GameObject gameObject2 = _wings.gameObject;
					if ((object)gameObject2 != null)
					{
						SpriteAnimation wingsSpriteAnimation = gameObject2.AddComponent<SpriteAnimation>();
						_wingsSpriteAnimation = wingsSpriteAnimation;
						GameObject gameObject3 = base.gameObject;
						SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(gameObject3, ret, y, "enemies2", text);
						if ((object)spriteRenderer2 != null)
						{
							((UnityEngine.Object)spriteRenderer2).SetName("Snakes");
							_snakes = spriteRenderer2;
							if ((object)_snakes != null)
							{
								GameObject gameObject4 = _snakes.gameObject;
								if ((object)gameObject4 != null)
								{
									SpriteAnimation snakesSpriteAnimation = gameObject4.AddComponent<SpriteAnimation>();
									_snakesSpriteAnimation = snakesSpriteAnimation;
									GameObject gameObject5 = base.gameObject;
									SpriteRenderer spriteRenderer3 = RenderingExtensions.AddSprite(gameObject5, ret, y, "enemies2", text);
									if ((object)spriteRenderer3 != null)
									{
										((UnityEngine.Object)spriteRenderer3).SetName("Legs");
										_legs = spriteRenderer3;
										if ((object)_legs != null)
										{
											GameObject gameObject6 = _legs.gameObject;
											if ((object)gameObject6 != null)
											{
												SpriteAnimation legsSpriteAnimation = gameObject6.AddComponent<SpriteAnimation>();
												_legsSpriteAnimation = legsSpriteAnimation;
												List<Sprite> animation = SpriteManager.GetAnimation("trinaW_", 1, 4, "enemies2", (byte)(int)text != 0);
												if ((object)_wingsSpriteAnimation != null)
												{
													bool startRandomFrame = default(bool);
													Action onComplete = default(Action);
													bool autoSetAnimation = default(bool);
													_wingsSpriteAnimation.AddAnimation("idle", animation, 10, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
													List<Sprite> animation2 = SpriteManager.GetAnimation("trinaS_", 1, 4, "enemies2", (byte)(int)text != 0);
													if ((object)_snakesSpriteAnimation != null)
													{
														_snakesSpriteAnimation.AddAnimation("idle", animation2, 10, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
														List<Sprite> animation3 = SpriteManager.GetAnimation("trinaL_", 1, 4, "enemies2", (byte)(int)text != 0);
														if ((object)_legsSpriteAnimation != null)
														{
															_legsSpriteAnimation.AddAnimation("idle", animation3, 10, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
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
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateSprites()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0528: Expected O, but got I4
		//IL_0069: Expected I4, but got O
		//IL_0097: Expected I4, but got O
		//IL_00c5: Expected I4, but got O
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Expected O, but got Unknown
		//IL_0622: Unknown result type (might be due to invalid IL or missing references)
		//IL_0627: Expected O, but got Unknown
		//IL_0679: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Expected O, but got Unknown
		//IL_06de: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Expected O, but got Unknown
		//IL_0747: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Expected O, but got Unknown
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cf: Expected O, but got Unknown
		//IL_082f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0834: Expected O, but got Unknown
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a7: Expected O, but got Unknown
		//IL_0907: Unknown result type (might be due to invalid IL or missing references)
		//IL_090c: Expected O, but got Unknown
		//IL_097a: Unknown result type (might be due to invalid IL or missing references)
		//IL_097f: Expected O, but got Unknown
		//IL_09e6: Expected O, but got I4
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected I4, but got Unknown
		//IL_0a31: Expected O, but got I4
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected I4, but got Unknown
		//IL_0a7c: Expected O, but got I4
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Expected I4, but got Unknown
		//IL_0ac7: Expected O, but got I4
		//IL_0b2d: Expected O, but got F4
		//IL_0af7: Expected I, but got O
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Expected O, but got Unknown
		//IL_0542->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_0083->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_00b1->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_00df->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_010d->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_013b->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_0169->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_0195->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_070f->IL04f1: Incompatible stack heights: 11 vs 0
		//IL_0242->IL04f1: Incompatible stack heights: 11 vs 0
		//IL_0b89->IL04f1: Incompatible stack heights: 38 vs 0
		//IL_0b1f->IL04f1: Incompatible stack heights: 38 vs 0
		object obj2 = default(object);
		object obj = obj2 - 95;
		SpriteRenderer enemyRenderer = _EnemyRenderer;
		if ((object)_EnemyRenderer != null)
		{
			bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
			SpriteRenderer spriteRenderer = (SpriteRenderer)SpriteRenderer.get_flipX_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr);
			if ((object)_legs != null)
			{
				_legs.flipX = (byte)(int)spriteRenderer != 0;
				if ((object)_snakes != null)
				{
					_snakes.flipX = (byte)(int)spriteRenderer != 0;
					if ((object)_wings != null)
					{
						_wings.flipX = (byte)(int)spriteRenderer != 0;
						if ((object)_wings != null)
						{
							Transform transform = _wings.transform;
							if ((object)_snakes != null)
							{
								Transform transform2 = _snakes.transform;
								if ((object)_legs != null)
								{
									Transform transform3 = _legs.transform;
									if ((object)_EnemyRenderer != null)
									{
										Transform transform4 = _EnemyRenderer.transform;
										if ((object)transform4 != null)
										{
											_ = 0;
											bool flag2 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
											object obj3 = obj - 9;
											Transform.get_rotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Quaternion*)obj3);
											bool flag3 = (object)transform3 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-9]");
											_ = 0;
											bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
											object obj4 = obj - 25;
											Transform.set_rotation_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Quaternion*)obj4);
											bool flag5 = (object)transform2 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-9]");
											_ = 0;
											bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											object obj5 = obj - 41;
											Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Quaternion*)obj5);
											bool flag7 = (object)transform == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-9]");
											_ = 0;
											bool flag8 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
											object obj6 = obj + 7;
											Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)obj6);
											bool flag9 = (object)_EnemyRenderer == null;
											Transform transform5 = _EnemyRenderer.transform;
											bool flag10 = (object)transform5 == null;
											_ = 0;
											_ = 0;
											bool flag11 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
											object obj7 = obj - 57;
											Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj7);
											if ((object)_snakes != null)
											{
												Transform transform6 = _snakes.transform;
												if ((object)transform6 != null)
												{
													_ = 0;
													_ = 0;
													bool flag12 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
													object obj8 = obj - 41;
													Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out *(Vector3*)obj8);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-29]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-35]");
													float num = 0f - 0.04f;
													bool flag13 = (object)_snakes == null;
													Transform transform7 = _snakes.transform;
													bool flag14 = (object)transform7 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-19]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-21]");
													_ = 0;
													bool flag15 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
													object obj9 = obj - 9;
													Transform.set_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref *(Vector3*)obj9);
													bool flag16 = (object)_legs == null;
													Transform transform8 = _legs.transform;
													bool flag17 = (object)transform8 == null;
													_ = 0;
													_ = 0;
													bool flag18 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
													object obj10 = obj - 41;
													Transform.get_position_Injected(((UnityEngine.Object)transform8).m_CachedPtr, out *(Vector3*)obj10);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-29]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-35]");
													_ = 0;
													bool flag19 = (object)_legs == null;
													Transform transform9 = _legs.transform;
													bool flag20 = (object)transform9 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-9]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-21]");
													_ = 0;
													bool flag21 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
													object obj11 = obj - 25;
													Transform.set_position_Injected(((UnityEngine.Object)transform9).m_CachedPtr, ref *(Vector3*)obj11);
													bool flag22 = (object)_wings == null;
													Transform transform10 = _wings.transform;
													bool flag23 = (object)transform10 == null;
													_ = 0;
													_ = 0;
													bool flag24 = ((UnityEngine.Object)transform10).m_CachedPtr == (IntPtr)0;
													object obj12 = obj - 41;
													Transform.get_position_Injected(((UnityEngine.Object)transform10).m_CachedPtr, out *(Vector3*)obj12);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-29]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-35]");
													_ = 0;
													bool flag25 = (object)_wings == null;
													Transform transform11 = _wings.transform;
													bool flag26 = (object)transform11 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-9]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-21]");
													_ = 0;
													bool flag27 = ((UnityEngine.Object)transform11).m_CachedPtr == (IntPtr)0;
													object obj13 = obj - 25;
													Transform.set_position_Injected(((UnityEngine.Object)transform11).m_CachedPtr, ref *(Vector3*)obj13);
													SpriteRenderer enemyRenderer2 = _EnemyRenderer;
													bool flag28 = (object)_EnemyRenderer == null;
													bool flag29 = ((UnityEngine.Object)enemyRenderer2).m_CachedPtr == (IntPtr)0;
													object obj14 = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer2).m_CachedPtr);
													bool flag30 = (object)_snakes == null;
													int sortingOrder = obj14 - 1;
													_snakes.sortingOrder = sortingOrder;
													SpriteRenderer enemyRenderer3 = _EnemyRenderer;
													bool flag31 = (object)_EnemyRenderer == null;
													bool flag32 = ((UnityEngine.Object)enemyRenderer3).m_CachedPtr == (IntPtr)0;
													object obj15 = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer3).m_CachedPtr);
													bool flag33 = (object)_legs == null;
													int sortingOrder2 = obj15 - 2;
													_legs.sortingOrder = sortingOrder2;
													SpriteRenderer enemyRenderer4 = _EnemyRenderer;
													bool flag34 = (object)_EnemyRenderer == null;
													bool flag35 = ((UnityEngine.Object)enemyRenderer4).m_CachedPtr == (IntPtr)0;
													object obj16 = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer4).m_CachedPtr);
													bool flag36 = (object)_wings == null;
													int sortingOrder3 = obj16 - 3;
													_wings.sortingOrder = sortingOrder3;
													SpriteRenderer enemyRenderer5 = _EnemyRenderer;
													bool flag37 = (object)_EnemyRenderer == null;
													bool flag38 = ((UnityEngine.Object)enemyRenderer5).m_CachedPtr == (IntPtr)0;
													object obj17 = SpriteRenderer.get_flipX_Injected(((UnityEngine.Object)enemyRenderer5).m_CachedPtr);
													float num2 = ((obj17 == null) ? (-1f) : 1f);
													object obj18 = Time.deltaTime;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rbp_v1-9]");
													float num3 = 0f * 500f;
													float num4 = num3 * num2;
													float legsAngle = num4 + _legsAngle;
													_legsAngle = legsAngle;
													if ((object)_legs != null)
													{
														Transform transform12 = _legs.transform;
														nint num5 = (nint)typeof(Vector3);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v157 (Il2CppClass<UnityEngine.Vector3>)+B8]");
														nint num6 = 0;
														if ((object)transform12 != null)
														{
															Vector3 axis = (Vector3)(obj - 9);
															_ = Vector3.backVector;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v185 (Il2CppStaticFields<UnityEngine.Vector3>)+5C]");
															_ = 0;
															transform12.Rotate(axis, _legsAngle, Space.Self);
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
			}
		}
		throw new NullReferenceException();
	}
}
