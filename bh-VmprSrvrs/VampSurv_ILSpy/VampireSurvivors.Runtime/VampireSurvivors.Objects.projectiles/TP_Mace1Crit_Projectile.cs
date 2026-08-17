using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Mace1Crit_Projectile : Projectile
{
	protected List<Projectile> _swipeAfterImageBodies;

	protected List<Vector2> _lerpRightList;

	protected List<Vector2> _lerpLeftList;

	protected List<Vector2> _lerpList;

	protected SpriteAnimation _anim;

	protected Timer _bodyDisableTimer;

	protected int _flipNum;

	protected float _lerpDist;

	protected bool _lerpActive;

	protected MultiTargetTween _lerpTween;

	[NonSerialized]
	public float lerpRatio;

	private Timer _freezeTimer;

	private bool _isMoving;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Mjollnjr01", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		CheckRenderer();
		GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		_anim = anim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Mjollnjr", 1, 24, "ThosePeople", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("swing", animationFrames, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0024: Expected I4, but got I8
		//IL_00c6: Expected O, but got I4
		//IL_01b3: Expected I, but got O
		//IL_0314: Invalid comparison between I4 and F4
		//IL_03d8: Expected O, but got I4
		//IL_03d8: Expected O, but got I4
		//IL_040c: Expected O, but got I4
		//IL_0415: Expected O, but got I4
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Expected O, but got Unknown
		base.InitProjectile(pool, weapon, index);
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		int flipNum = -1;
		if (!characterController._isFlipped)
		{
			flipNum = 1;
		}
		_flipNum = flipNum;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		List<Vector2> lerpList = ((!characterController2._isFlipped) ? _lerpRightList : _lerpLeftList);
		_lerpList = lerpList;
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		ArcadeSprite arcadeSprite = setFlipX(characterController3._isFlipped);
		float num = weapon.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			int num2 = renderer.pixelHeight - 1;
			ArcadeSprite arcadeSprite3 = setDepth(num2);
			lerpRatio = 0f;
			_lerpActive = true;
			float num3 = (_lerpDist = MultiDistance(_lerpList));
			if (_lerpTween != null)
			{
				_lerpTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig.targets = array;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value = default(object);
				bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"lerpRatio", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig.custom = dictionary;
				tweenConfig.ease = Ease.InQuad;
				tweenConfig.duration = 220f;
				TweenCallback onComplete = delegate
				{
					//IL_003f: Expected I, but got O
					if (_lerpTween != null)
					{
						_lerpTween.Kill();
					}
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[1];
					nint num9 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj2 = default(object);
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig2.targets = array2;
						Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						object value2 = default(object);
						bool flag3 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"lerpRatio", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						tweenConfig2.custom = dictionary2;
						tweenConfig2.duration = 30f;
						TweenCallback onComplete2 = delegate
						{
							//IL_001b: Expected O, but got I
							//IL_005d: Expected O, but got I4
							//IL_005d: Expected O, but got I4
							List<Vector2> lerpList3 = _lerpList;
							_isMoving = false;
							_lerpActive = false;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							object obj3 = -1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							if ((nint)obj3 < 0)
							{
								BaseBody baseBody4 = body.setCircle(20f, (float?)(object)1, (float?)(object)1);
								if (_bodyDisableTimer != null)
								{
									_bodyDisableTimer.Cancel();
								}
								Action onComplete3 = delegate
								{
									Despawn();
								};
								bool useRealTime = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer bodyDisableTimer = Timers.Register(1f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_bodyDisableTimer = bodyDisableTimer;
							}
							else
							{
								System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							}
						};
						tweenConfig2.onComplete = onComplete2;
						MultiTargetTween lerpTween2 = Tweens.Add(tweenConfig2);
						_lerpTween = lerpTween2;
						return;
					}
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				};
				tweenConfig.onComplete = onComplete;
				MultiTargetTween lerpTween = Tweens.Add(tweenConfig);
				_lerpTween = lerpTween;
				if (_swipeAfterImageBodies == null)
				{
					List<Projectile> swipeAfterImageBodies = new List<Projectile>();
					_swipeAfterImageBodies = swipeAfterImageBodies;
				}
				List<Projectile> swipeAfterImageBodies2 = _swipeAfterImageBodies;
				float num5 = weapon.PAmount();
				bool flag2 = (float)swipeAfterImageBodies2._size == num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187134C5Ah\"");
				if (!flag2)
				{
					float num6 = weapon.PAmount();
					if (_swipeAfterImageBodies == null)
					{
						goto IL_0540;
					}
				}
				List<Vector2> lerpList2 = _lerpList;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v47 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v47 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if ((nint)0 > (nint)0)
					{
						BaseBody baseBody = body.setCircle(12f, (float?)(object)1, (float?)(object)1);
						BaseBody baseBody2 = body;
						baseBody2._enable = true;
						List<Projectile> swipeAfterImageBodies3 = _swipeAfterImageBodies;
						float? num7 = (float?)(object)0;
						float? num8 = (float?)(object)0;
						while (true)
						{
							if ((nint)num8 < swipeAfterImageBodies3._size)
							{
								List<Projectile> swipeAfterImageBodies4 = _swipeAfterImageBodies;
								if ((nint)num7 >= swipeAfterImageBodies4._size)
								{
									break;
								}
								Projectile[] items = swipeAfterImageBodies4._items;
								Projectile projectile = items[(object)num7];
								BaseBody baseBody3 = projectile.body;
								num7 = (float?)(object)((_003F?)num7 + 1);
								baseBody3._enable = true;
								swipeAfterImageBodies3 = _swipeAfterImageBodies;
								num8 = num7;
								continue;
							}
							UpdatePositions();
							_anim.SetAnimation("swing");
							ArcadeSprite arcadeSprite4 = setVisible(visible: true);
							_isMoving = true;
							return;
						}
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
		goto IL_0540;
		IL_0540:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		UpdatePositions();
	}

	public unsafe void UpdatePositions()
	{
		//IL_00fa: Expected O, but got I4
		//IL_0130: Expected O, but got I4
		//IL_0142: Expected O, but got I4
		//IL_0171: Invalid comparison between I4 and F4
		//IL_0191: Expected F4, but got I4
		//IL_0399: Expected O, but got I4
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Expected O, but got Unknown
		//IL_01e0->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_0207->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_0504->IL03f2: Incompatible stack heights: 2 vs 0
		//IL_024a->IL03f2: Incompatible stack heights: 2 vs 0
		//IL_0296->IL03f2: Incompatible stack heights: 2 vs 0
		//IL_02d5->IL03f2: Incompatible stack heights: 2 vs 0
		//IL_0324->IL03f2: Incompatible stack heights: 3 vs 0
		//IL_035b->IL03f2: Incompatible stack heights: 3 vs 0
		//IL_037d->IL03f2: Incompatible stack heights: 3 vs 0
		//IL_03cf->IL03f2: Incompatible stack heights: 3 vs 0
		//IL_03f2->IL04c5: Incompatible stack heights: 3 vs 0
		if (!_isMoving)
		{
			return;
		}
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			float2 float6 = default(float2);
			base.position = float6;
			if (!_lerpActive)
			{
				return;
			}
			float2 float7 = MultiLerp(_lerpList, lerpRatio);
			object obj = default(object);
			float num = (float)obj * -1f;
			float x = (float)float7 * (float)_flipNum;
			if (body != null)
			{
				BaseBody baseBody = body.setOffset(x, (float?)(object)1);
				List<Projectile> swipeAfterImageBodies = _swipeAfterImageBodies;
				if (_swipeAfterImageBodies != null)
				{
					object obj2 = 0;
					float num2 = num;
					object obj3 = 0;
					while (true)
					{
						if ((nint)obj3 >= swipeAfterImageBodies._size)
						{
							return;
						}
						float num3 = (float)obj2 * 0.05f;
						float num4 = lerpRatio - num3;
						if (0f > num4)
						{
							num4 = 0f;
						}
						float2 float8 = MultiLerp(_lerpList, num4);
						List<Projectile> swipeAfterImageBodies2 = _swipeAfterImageBodies;
						float num5 = num2 * -1f;
						float num6 = (float)float8 * (float)_flipNum;
						if (_swipeAfterImageBodies == null)
						{
							break;
						}
						bool flag = (nint)obj2 >= swipeAfterImageBodies2._size;
						Projectile[] items = swipeAfterImageBodies2._items;
						if (swipeAfterImageBodies2._items == null)
						{
							break;
						}
						Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
						if ((object)cachedTrans == null)
						{
							break;
						}
						bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
						float2 ret;
						Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
						if (body != null)
						{
							BaseBody baseBody2 = body;
							ArcadeTransform arcadeTransform = baseBody2._transform;
							if (baseBody2._transform == null)
							{
								break;
							}
							arcadeTransform.position = ret;
						}
						if ((object)_weapon == null)
						{
							break;
						}
						float num7 = _weapon.PArea();
						if ((object)items[obj2] == null)
						{
							break;
						}
						items[obj2].position = float6;
						List<Projectile> swipeAfterImageBodies3 = _swipeAfterImageBodies;
						if (_swipeAfterImageBodies == null)
						{
							break;
						}
						bool flag3 = (nint)obj2 >= swipeAfterImageBodies3._size;
						Projectile[] items2 = swipeAfterImageBodies3._items;
						if (swipeAfterImageBodies3._items == null)
						{
							break;
						}
						Projectile projectile = items2[obj2];
						if ((object)items2[obj2] == null || projectile.body == null)
						{
							break;
						}
						BaseBody baseBody3 = projectile.body.setOffset(num6, (float?)(object)1);
						swipeAfterImageBodies = _swipeAfterImageBodies;
						obj2++;
						if (_swipeAfterImageBodies == null)
						{
							break;
						}
						num2 = num5;
						x = num6;
						obj3 = obj2;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected float2 MultiLerp(List<Vector2> waypoints, float ratio)
	{
		//IL_0303: Expected O, but got I4
		//IL_030c: Expected O, but got I4
		//IL_031d: Expected O, but got I4
		//IL_0114: Expected O, but got I
		//IL_011c: Expected I4, but got O
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0050: Expected O, but got I
		//IL_026c: Expected O, but got I
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected I4, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_029b: Expected O, but got I4
		//IL_00b2: Invalid comparison between O and F4
		//IL_00c0: Expected I4, but got O
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_01cc: Expected O, but got I4
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0245: Expected O, but got I4
		//IL_0251: Expected O, but got I4
		float num = ratio * _lerpDist;
		object obj = 0;
		object obj2 = 0;
		List<Vector2> list = waypoints;
		object obj3 = 0;
		object obj9 = default(object);
		int index;
		List<Vector2> list2 = default(List<Vector2>);
		while (true)
		{
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj4 < 0)
			{
				object obj5 = obj2 + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj6 = -1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
					object obj7 = obj2 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
					object obj8 = obj9 + obj;
					bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num);
					index = (int)list2;
					if (flag)
					{
						break;
					}
					obj2++;
					obj += obj9;
					list = list2;
					obj3 = obj2;
					continue;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			obj2 = -1;
			index = (int)list;
			break;
		}
		object obj10 = obj2 + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		int num3 = default(int);
		if ((nint)obj10 < 0)
		{
			int count = obj2 + 1;
			List<Vector2> range = waypoints.GetRange(index, count);
			float num2 = MultiDistance(range);
			object obj11 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj11 < 0)
			{
				object obj12 = obj2 + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)obj12 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
					List<Vector2> range2 = ((List<Vector2>)num3).GetRange(num3, 0);
					object obj13 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if ((nint)obj13 < 0)
					{
						object obj14 = obj2 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						if ((nint)obj14 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
							List<Vector2> range3 = ((List<Vector2>)num3).GetRange(num3, 0);
							return (float2)num3;
						}
					}
				}
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj15 = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj15 < 0)
			{
				return (float2)num3;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float2 result = default(float2);
		return result;
	}

	protected int GetVectorIndexFromDistanceTravelled(List<Vector2> waypoints, float distanceTravelled)
	{
		//IL_011d: Expected I4, but got O
		//IL_000e: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_0049: Expected O, but got I
		//IL_007d: Expected O, but got I4
		//IL_00ab: Invalid comparison between O and F4
		if (waypoints != null)
		{
			object obj = 0;
			int num = 0;
			int num2 = 0;
			object obj6 = default(object);
			while (true)
			{
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)num3 >= (nint)0)
				{
					break;
				}
				object obj2 = num + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj3 = -1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				object obj4 = num + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
				object obj5 = obj6 + obj;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)distanceTravelled))
				{
					num++;
					obj += obj6;
					num2 = num;
					continue;
				}
				return num;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			return (int)(-1);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	protected float MultiDistance(List<Vector2> waypoints)
	{
		//IL_0219: Expected F4, but got I4
		//IL_0222: Expected O, but got I4
		//IL_0233: Expected O, but got I4
		//IL_02c2: Expected O, but got I
		//IL_0044: Expected O, but got I
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_026d: Expected I, but got O
		//IL_028a: Expected O, but got I
		//IL_02a7: Expected O, but got I
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_01a2: Expected F8, but got I4
		bool flag = waypoints == null;
		float num = 0f;
		object obj = 0;
		double num3 = default(double);
		double num2 = num3;
		object obj2 = 0;
		if (!flag)
		{
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj3 = -1;
				float result;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					object obj4 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					bool flag2 = (nint)obj4 >= 0;
					result = (float)num2;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						bool flag3 = (nint)0 == 0;
						num3 = num2;
						if (flag3)
						{
							break;
						}
						object obj6 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+18]");
						bool flag4 = (nint)obj6 >= 0;
						num3 = num2;
						if (!flag4)
						{
							object obj7 = obj + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							bool flag5 = (nint)obj7 >= 0;
							result = (float)num2;
							if (flag5)
							{
								goto IL_0241;
							}
							object obj8 = obj + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+18]");
							bool flag6 = (nint)obj8 >= 0;
							num3 = num2;
							if (!flag6)
							{
								nint num4 = (nint)typeof(Math);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+20+v61 @ rbx_v2*8]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+28+v61 @ rbx_v2*8]");
								object obj9 = num5 - 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+24+v61 @ rbx_v2*8]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+2C+v61 @ rbx_v2*8]");
								object obj10 = num6 - 0;
								object obj11 = obj10 * obj10;
								object obj12 = obj9 * obj9;
								double d = (double)obj11 + (double)obj12;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v6 (Il2CppClass<System.Math>)+E4]");
								if ((nint)0 <= (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
									obj++;
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
									num2 = 0.0;
									obj2 = obj;
								}
								else
								{
									num2 = Math.Sqrt(d);
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
									obj++;
									num += (float)num2;
									obj2 = obj;
								}
								continue;
							}
						}
						throw new IndexOutOfRangeException();
					}
					goto IL_0241;
				}
				return num;
				IL_0241:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj2 = default(object);
			if (obj2 == null)
			{
			}
		}
	}

	public override void Despawn()
	{
		//IL_0045: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_036a: Expected O, but got I4
		//IL_0373: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		//IL_0194: Expected O, but got I4
		//IL_01bb: Expected O, but got I4
		//IL_01c9: Expected O, but got I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_swipeAfterImageBodies != null)
		{
			List<Projectile> swipeAfterImageBodies = _swipeAfterImageBodies;
			object obj = 0;
			List<Projectile> swipeAfterImageBodies2 = _swipeAfterImageBodies;
			object obj2 = 0;
			while ((nint)obj < swipeAfterImageBodies._size)
			{
				if ((nint)obj2 < swipeAfterImageBodies2._size)
				{
					Projectile[] items = swipeAfterImageBodies2._items;
					Projectile projectile = items[obj2];
					BaseBody baseBody2 = projectile.body;
					obj2++;
					baseBody2._enable = false;
					swipeAfterImageBodies2 = _swipeAfterImageBodies;
					obj = obj2;
					swipeAfterImageBodies = _swipeAfterImageBodies;
					continue;
				}
				goto IL_02be;
			}
		}
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_lerpTween != null)
		{
			_lerpTween.Kill();
		}
		if (_freezeTimer != null)
		{
			Timer freezeTimer = _freezeTimer;
			if (!_freezeTimer.IsDone)
			{
				float timeElapsed = _freezeTimer.GetTimeElapsed();
				freezeTimer._timeElapsedBeforeCancel = (float?)(object)1;
				freezeTimer._timeElapsedBeforePause = (float?)(object)0;
			}
		}
		Timer bodyDisableTimer = _bodyDisableTimer;
		if (_bodyDisableTimer != null && !_bodyDisableTimer.IsDone)
		{
			float timeElapsed2 = _bodyDisableTimer.GetTimeElapsed();
			bodyDisableTimer._timeElapsedBeforeCancel = (float?)(object)1;
			bodyDisableTimer._timeElapsedBeforePause = (float?)(object)0;
		}
		List<Projectile> swipeAfterImageBodies3 = _swipeAfterImageBodies;
		object obj3 = 0;
		object obj4 = 0;
		while (true)
		{
			if ((nint)obj4 < swipeAfterImageBodies3._size)
			{
				List<Projectile> swipeAfterImageBodies4 = _swipeAfterImageBodies;
				if ((nint)obj3 >= swipeAfterImageBodies4._size)
				{
					break;
				}
				Projectile[] items2 = swipeAfterImageBodies4._items;
				items2[obj3].Despawn();
				swipeAfterImageBodies3 = _swipeAfterImageBodies;
				obj3++;
				bool flag = _swipeAfterImageBodies != null;
				obj4 = obj3;
				if (!flag)
				{
					throw new NullReferenceException();
				}
				continue;
			}
			_swipeAfterImageBodies = null;
			base.Despawn();
			return;
		}
		goto IL_02be;
		IL_02be:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public TP_Mace1Crit_Projectile()
	{
		List<Projectile> swipeAfterImageBodies = new List<Projectile>();
		_swipeAfterImageBodies = swipeAfterImageBodies;
		Vector2 item = default(Vector2);
		_lerpRightList = new List<Vector2> { item, item, item, item, item };
		_lerpLeftList = new List<Vector2> { item, item, item, item, item };
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__14_0()
	{
		//IL_003f: Expected I, but got O
		if (_lerpTween != null)
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
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"lerpRatio", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 30f;
			TweenCallback onComplete = delegate
			{
				//IL_001b: Expected O, but got I
				//IL_005d: Expected O, but got I4
				//IL_005d: Expected O, but got I4
				List<Vector2> lerpList = _lerpList;
				_isMoving = false;
				_lerpActive = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj2 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)obj2 < 0)
				{
					BaseBody baseBody = body.setCircle(20f, (float?)(object)1, (float?)(object)1);
					if (_bodyDisableTimer != null)
					{
						_bodyDisableTimer.Cancel();
					}
					Action onComplete2 = delegate
					{
						Despawn();
					};
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer bodyDisableTimer = Timers.Register(1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_bodyDisableTimer = bodyDisableTimer;
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween lerpTween = Tweens.Add(tweenConfig);
			_lerpTween = lerpTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void _003CInitProjectile_003Eb__14_1()
	{
		//IL_001b: Expected O, but got I
		//IL_005d: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		List<Vector2> lerpList = _lerpList;
		_isMoving = false;
		_lerpActive = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		object obj = -1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)obj < 0)
		{
			BaseBody baseBody = body.setCircle(20f, (float?)(object)1, (float?)(object)1);
			if (_bodyDisableTimer != null)
			{
				_bodyDisableTimer.Cancel();
			}
			Action onComplete = delegate
			{
				Despawn();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer bodyDisableTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_bodyDisableTimer = bodyDisableTimer;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void _003CInitProjectile_003Eb__14_2()
	{
		Despawn();
	}
}
