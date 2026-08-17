using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.VFX;
using Zenject;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyGallo : EnemyController
{
	private GameObject _LancetPierceEffectPrefab;

	private GameObject _EnemyLancetPrefab;

	private DiContainer _diContainer;

	private ObjectPool _effectPool;

	private ObjectPool _enemyLancetPool;

	private int _keepMoving = 1;

	private new const float Distance = 50000f;

	private float _fireTime;

	private float _fireDelay = 1f;

	private float _previousDistance;

	private int _ticks;

	private List<float> _angles;

	private List<Vector2> _targets;

	private List<EnemyLancet> _enemyLancetProjectiles;

	private EnemyType _bulletType;

	private Tween _onEnterTween;

	private Tween _onFireTimer;

	private Tween _lancetTween;

	protected override void FakeConstruct()
	{
		base.FakeConstruct();
		GameManager core = GM.Core;
		_diContainer = core._diContainer;
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0081: Expected I4, but got O
		//IL_038f: Expected I, but got O
		//IL_03cc: Expected O, but got Ref
		base.InitEnemy(enemyType, asRemote);
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdi_v2 (System.Object)+10]");
		if ((nint)0 == 0)
		{
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
			throw new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdi_v2 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected((IntPtr)0, ref value);
		EnemyData currentEnemyData = _currentEnemyData;
		_fireTime = 0f;
		float num2 = default(float);
		float num = (((object)currentEnemyData._003CfireDelay_003Ek__BackingField == null) ? 2000f : num2);
		float fireDelay = num * 0.001f;
		_fireDelay = fireDelay;
		EnemyData currentEnemyData2 = _currentEnemyData;
		EnemyType bulletType = (((object)currentEnemyData2._003CbulletType_003Ek__BackingField == null) ? EnemyType.BULLET_2 : ((EnemyType)((object?)currentEnemyData2._003CbulletType_003Ek__BackingField >> 32)));
		_bulletType = bulletType;
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rax_v26 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rcx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float x = 0f * _scaleMul;
		TweenerCore<Vector3, Vector3, VectorOptions> onEnterTween = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&value), 0.3f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_onEnterTween = onEnterTween;
		if (_onFireTimer != null)
		{
			TweenExtensions.Kill(_onFireTimer);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((EnemyGallo)(object)dOSetter)._003CInitEnemy_003Eb__19_1(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, _fireDelay);
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
					TweenCallback tweenCallback = Fire;
					tweenCallback2 = tweenCallback;
					goto IL_022c;
				}
			}
		}
		TweenCallback tweenCallback3 = Fire;
		bool flag = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag)
		{
			goto IL_022c;
		}
		goto IL_025b;
		IL_022c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_025b;
		IL_025b:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_onFireTimer = tweenerCore;
		InitLancet();
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_onFireTimer != null)
		{
			TweenExtensions.Kill(_onFireTimer);
		}
		ObjectPool enemyLancetPool = _enemyLancetPool;
		if ((object)_enemyLancetPool != null && ((UnityEngine.Object)enemyLancetPool).m_CachedPtr != (IntPtr)0)
		{
			_enemyLancetPool.Purge();
			_enemyLancetPool = null;
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_00d6: Expected O, but got I
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected O, but got Unknown
		//IL_0262: Expected I4, but got I8
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_02af: Expected O, but got F4
		//IL_039d->IL0320: Incompatible stack heights: 1 vs 0
		//IL_0483->IL0320: Incompatible stack heights: 1 vs 0
		//IL_041a->IL0127: Incompatible stack heights: 2 vs 0
		//IL_04aa->IL0320: Incompatible stack heights: 1 vs 0
		//IL_0189->IL0320: Incompatible stack heights: 1 vs 0
		//IL_05f1->IL0320: Incompatible stack heights: 1 vs 0
		//IL_031f->IL031f: Incompatible stack heights: 2 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		base.UpdateDepth();
		if (base._003CIsTimeStopped_003Ek__BackingField)
		{
			return;
		}
		if (!base._fixedDirection)
		{
			goto IL_00e4;
		}
		Vector2 currentDirection = _currentDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187714E9Bh\"");
		if ((object)_currentDirection == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187714E9Bh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyGallo)+1E4]");
			bool flag = (nint)0 != 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyGallo)+1E4]");
			currentDirection = (Vector2)0;
			if (!flag)
			{
				goto IL_00e4;
			}
		}
		goto IL_0127;
		IL_0320:
		throw new NullReferenceException();
		IL_00e4:
		RetargetIfNecessary();
		Transform targetTransform = base._targetTransform;
		Vector3 ret2;
		object obj3 = default(object);
		if ((object)base._targetTransform != null)
		{
			bool flag2 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			object cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v14 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v14 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret2);
				object obj2 = default(object);
				object obj = obj2 - obj3;
				currentDirection = ret - ret2;
				_currentDirection = currentDirection;
				Vector2 vector = (Vector2)(this + 480);
				((Vector2*)vector)->Normalize();
				goto IL_0127;
			}
		}
		goto IL_0320;
		IL_0127:
		Transform cachedTransform2 = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out ret2);
			float num = (float)obj3 * 100f;
			float num2 = (float)ret2 * 100f;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rcx_v28 (PhaserScene+Renderer)+38]");
						float num3 = 0f * 100f;
						float num4 = (float)renderer.screenCenter * 100f;
						float num5 = num - num3;
						float num6 = num2 - num4;
						float num7 = num5 * num5;
						float num8 = num6 * num6;
						float num9 = num8 + num7;
						if (!(47000f > num9))
						{
							if (num9 > 53000f)
							{
								_keepMoving = 1;
							}
						}
						else
						{
							_keepMoving = -1;
						}
						float num11;
						if (_receivingDamage)
						{
							float num10 = base._003CKnockBack_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
							object obj4 = num10 ^ 0;
							num11 = (float)obj4 * _damageKb;
						}
						else
						{
							num11 = 1f;
						}
						bool flag5 = (nint)_currentDirection < 0;
						bool flag6 = (object)_currentDirection == null;
						bool flag7 = !flag5;
						bool flag8 = !flag6;
						bool flag9 = flag8 & flag7;
						base.SetFlipX(flag9);
						float num12 = base._003CSpeed_003Ek__BackingField * GameManager.EnemySpeed;
						float num13 = num12 / 100f;
						float num14 = (float)_keepMoving * num13;
						float num15 = num14 * num11;
						float num16 = num15 * base._003CSlow_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyGallo)+1E4]");
						float num17 = 0f * num16;
						float num18 = (float)_currentDirection * num16;
						BaseBody baseBody = body;
						if (body != null)
						{
							baseBody._velocity = (float2)num18;
							bool flag10 = _enemyLancetProjectiles == null;
							List<EnemyLancet>.Enumerator enumerator = default(List<EnemyLancet>.Enumerator);
							while (enumerator.MoveNext())
							{
								EnemyLancet enemyLancet = null;
							}
							return;
						}
					}
				}
			}
		}
		goto IL_0320;
	}

	public void OnLancetDied(EnemyLancet enemyLancet)
	{
		List<EnemyLancet> enemyLancetProjectiles = _enemyLancetProjectiles;
		if (enemyLancetProjectiles._size != 0)
		{
			int num = Array.IndexOf((object[])enemyLancetProjectiles._items, (object)enemyLancet, 0, enemyLancetProjectiles._size);
			if (num != -1)
			{
				bool flag = ((List<object>)(object)_enemyLancetProjectiles).Remove((object)enemyLancet);
			}
		}
	}

	private void InitLancet()
	{
		//IL_003b: Expected I4, but got I8
		//IL_0125: Expected O, but got I4
		//IL_014d: Expected O, but got I
		//IL_015d: Expected O, but got I
		//IL_01b6: Expected O, but got I
		//IL_025b: Expected O, but got I
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		GenerateEffectPool();
		string text = ((UnityEngine.Object)_EnemyLancetPrefab).GetName();
		ObjectPool enemyLancetPool = ObjectPool.Create(_EnemyLancetPrefab, text, 6, -1);
		_enemyLancetPool = enemyLancetPool;
		ObjectPool enemyLancetPool2 = _enemyLancetPool;
		enemyLancetPool2._incrementalInstanceNames = true;
		ObjectPool enemyLancetPool3 = _enemyLancetPool;
		if (!enemyLancetPool3._003CInitialized_003Ek__BackingField)
		{
			enemyLancetPool3._003CInitialized_003Ek__BackingField = true;
			enemyLancetPool3.AutoFillName();
			enemyLancetPool3.Populate(enemyLancetPool3._defaultSize);
		}
		List<float> angles = new List<float>();
		_angles = angles;
		List<Vector2> list = (_targets = new List<Vector2>());
		nint num = 0;
		List<Vector2> list2 = list;
		object obj = 0;
		Vector2 item2 = default(Vector2);
		bool flag;
		do
		{
			List<Vector2> targets = _targets;
			float num2 = (float)obj / 12f;
			float item = num2 * ((float)Math.PI * 2f);
			list2._002Ector();
			list2._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rbx_v8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rbx_v8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rbx_v8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rbx_v8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdx_v13+18]");
			if (num3 >= 0)
			{
				targets.AddWithResize(item2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rbx_v8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj4 = (nint)0 + (nint)1;
			}
			List<float> angles2 = _angles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v22 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v22 (System.Collections.Generic.List`1<System.Single>)+10]");
			PopulateMethod populateMethod = PopulateMethod.Set;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v22 (System.Collections.Generic.List`1<System.Single>)+18]");
			num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v22 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r8_v11 (QFSW.MOP2.PopulateMethod)+18]");
			if (num4 >= 0)
			{
				angles2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v22 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj5 = (nint)0 + (nint)1;
			}
			obj++;
			flag = (nint)obj < 12;
			list2 = (List<Vector2>)(object)angles2;
		}
		while (flag);
	}

	private void GenerateEffectPool()
	{
		//IL_0077: Expected I4, but got I8
		MasterObjectPooler masterObjectPooler = MasterObjectPooler._003CInstance_003Ek__BackingField;
		int num = masterObjectPooler._poolTable.FindEntry("LancetPieceEffect");
		if (num < 0)
		{
			string text = ((UnityEngine.Object)_LancetPierceEffectPrefab).GetName();
			ObjectPool effectPool = ObjectPool.Create(_LancetPierceEffectPrefab, text, 1, -1);
			_effectPool = effectPool;
			ObjectPool effectPool2 = _effectPool;
			effectPool2._incrementalInstanceNames = true;
			ObjectPool effectPool3 = _effectPool;
			if (!effectPool3._003CInitialized_003Ek__BackingField)
			{
				effectPool3._003CInitialized_003Ek__BackingField = true;
				effectPool3.AutoFillName();
				effectPool3.Populate(effectPool3._defaultSize);
			}
			MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool("LancetPieceEffect", _effectPool);
		}
		else
		{
			ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("LancetPieceEffect");
			_effectPool = pool;
		}
	}

	private void GenerateEnemyLancetPool()
	{
		//IL_003b: Expected I4, but got I8
		string text = ((UnityEngine.Object)_EnemyLancetPrefab).GetName();
		ObjectPool enemyLancetPool = ObjectPool.Create(_EnemyLancetPrefab, text, 6, -1);
		_enemyLancetPool = enemyLancetPool;
		ObjectPool enemyLancetPool2 = _enemyLancetPool;
		enemyLancetPool2._incrementalInstanceNames = true;
		ObjectPool enemyLancetPool3 = _enemyLancetPool;
		if (!enemyLancetPool3._003CInitialized_003Ek__BackingField)
		{
			enemyLancetPool3._003CInitialized_003Ek__BackingField = true;
			enemyLancetPool3.AutoFillName();
			enemyLancetPool3.Populate(enemyLancetPool3._defaultSize);
		}
	}

	protected override void Die()
	{
		base.Die();
		if (_onFireTimer != null)
		{
			TweenExtensions.Kill(_onFireTimer);
		}
	}

	private unsafe void Fire()
	{
		//IL_00a3: Expected O, but got I
		//IL_017e: Expected O, but got I
		//IL_01c5: Expected O, but got I
		//IL_01c5: Expected F4, but got I
		//IL_0259: Expected O, but got Ref
		//IL_0259: Expected O, but got Ref
		//IL_02f7: Expected I4, but got O
		//IL_00c3->IL0320: Incompatible stack heights: 1 vs 0
		//IL_00ec->IL0320: Incompatible stack heights: 1 vs 0
		//IL_0136->IL0320: Incompatible stack heights: 2 vs 0
		//IL_03ab->IL0320: Incompatible stack heights: 2 vs 0
		//IL_019e->IL0320: Incompatible stack heights: 3 vs 0
		//IL_01eb->IL037d: Incompatible stack heights: 3 vs 2
		//IL_03ff->IL0320: Incompatible stack heights: 4 vs 0
		//IL_051d->IL0320: Incompatible stack heights: 5 vs 0
		//IL_028d->IL0320: Incompatible stack heights: 5 vs 0
		//IL_049c->IL0320: Incompatible stack heights: 6 vs 0
		//IL_0311->IL0320: Incompatible stack heights: 6 vs 0
		//IL_04f6->IL0349: Incompatible stack heights: 7 vs 0
		if (base._003CIsDead_003Ek__BackingField || base._003CIsTimeStopped_003Ek__BackingField)
		{
			return;
		}
		if (++_ticks >= 12)
		{
			_ticks = 0;
		}
		List<Vector2> targets = _targets;
		int ticks = _ticks;
		if (_targets != null)
		{
			int ticks2 = _ticks;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag = (nint)ticks2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			if ((nint)0 != 0)
			{
				List<float> angles = _angles;
				if (_angles != null)
				{
					int ticks3 = _ticks;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v32 (System.Collections.Generic.List`1<System.Single>)+18]");
					bool flag2 = (nint)ticks3 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v32 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 != 0)
					{
						int num = 0;
						Vector2 euler = default(Vector2);
						Vector2 spawnPos = default(Vector2);
						while (true)
						{
							List<float> angles2 = _angles;
							int ticks4 = _ticks;
							if (_angles == null)
							{
								break;
							}
							int ticks5 = _ticks;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rax_v37 (System.Collections.Generic.List`1<System.Single>)+18]");
							bool flag3 = (nint)ticks5 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rax_v37 (System.Collections.Generic.List`1<System.Single>)+10]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rax_v37 (System.Collections.Generic.List`1<System.Single>)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							int index = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rdx_v24+20+v375 @ rcx_v35 (System.Int32)*4]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rcx_v31+20+v272 @ rax_v5 (System.Int32)*8]");
							FireOneLancet(index, num2, (Vector2)0);
							num++;
							if (num >= 6)
							{
								bool flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
								IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
								Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								if ((object)transform == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v43 (UnityEngine.Transform)+10]");
								bool flag5 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v43 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
								Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion ret2);
								if ((object)_effectPool == null)
								{
									break;
								}
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1224 @ rdi_v19 (Il2CppMethodInfo)+38]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
								}
								GameObject obj3 = _effectPool.GetObject((Vector3)(&euler), (Quaternion)(&ret2));
								object objectComponent = _effectPool.GetObjectComponent<LancetPierceEffect>(obj3);
								if (objectComponent == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v55 (System.Object)+10]");
								bool flag6 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v55 (System.Object)+10]");
								IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
								GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
								if (_diContainer == null)
								{
									break;
								}
								_diContainer.InjectGameObject(gameObject);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v55 (System.Object)+10]");
								if ((nint)0 != 0)
								{
									((LancetPierceEffect)objectComponent).Play();
								}
								int num4 = (int)_cachedTransform;
								if ((object)_cachedTransform == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rdi_v21 (System.Int32)+10]");
								bool flag7 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rdi_v21 (System.Int32)+10]");
								Transform.get_position_Injected((IntPtr)0, out ret);
								base.FireEnemyAsBullet(spawnPos, _bulletType);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void FireOneLancet(int index, float angle, Vector2 targetPos)
	{
		//IL_0334: Expected O, but got I4
		//IL_0023: Expected O, but got Ref
		//IL_014a: Expected O, but got I
		//IL_0152: Expected I4, but got O
		//IL_036c->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_003f->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_006b->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_00b1->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_0100->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_01c1->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_01e3->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_0265->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_0299->IL02b6: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			object obj = default(object);
			float num = (float)obj * 0.5f;
			object obj2 = index + 1;
			float num2 = num * (float)obj2;
			object obj3 = default(object);
			float num3 = (float)obj3 - num2;
			if ((object)_enemyLancetPool != null)
			{
				EnemyLancet objectComponent = _enemyLancetPool.GetObjectComponent<EnemyLancet>((Vector3)(&ret));
				if ((object)objectComponent != null)
				{
					GameObject gameObject = objectComponent.gameObject;
					if (_diContainer != null)
					{
						_diContainer.InjectGameObject(gameObject);
						objectComponent.Init();
						List<object> enemyLancetProjectiles = (List<object>)(object)_enemyLancetProjectiles;
						if (_enemyLancetProjectiles != null)
						{
							int version = enemyLancetProjectiles._version + 1;
							enemyLancetProjectiles._version = version;
							object[] items = enemyLancetProjectiles._items;
							if (enemyLancetProjectiles._items != null)
							{
								int num4 = enemyLancetProjectiles._size;
								if (enemyLancetProjectiles._size >= items.Length)
								{
									((List<object>)(object)_enemyLancetProjectiles).AddWithResize((object)objectComponent);
									EnemyLancet enemyLancet = (EnemyLancet)0;
									num4 = (int)objectComponent;
								}
								else
								{
									int num5 = enemyLancetProjectiles._size + 1;
									enemyLancetProjectiles._size = num5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									EnemyLancet enemyLancet = objectComponent;
								}
								objectComponent._owner = this;
								GameSessionData gameSessionData = _gameSessionData;
								if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
								{
									float2 float5 = gameSessionData._activeCharacter.position;
									float num6 = num3 + 1f;
									object obj4 = default(object);
									float num7 = num6 - (float)obj4;
									float num8 = num7 * -1f;
									float num9 = num8 * 100f;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
									if ((object)objectComponent._groundFx != null)
									{
										int sortingOrder = default(int);
										objectComponent._groundFx.sortingOrder = sortingOrder;
										if ((object)objectComponent._particlesManager != null)
										{
											objectComponent._particlesManager.SetDepthMultiplied(num8);
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
		throw new NullReferenceException();
	}

	protected void SetLancetPoolItemsDuration(float duration)
	{
		//IL_0013: Expected O, but got I4
		List<EnemyLancet>.Enumerator enumerator = default(List<EnemyLancet>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public EnemyGallo()
	{
		List<EnemyLancet> enemyLancetProjectiles = new List<EnemyLancet>();
		_enemyLancetProjectiles = enemyLancetProjectiles;
		base._002Ector();
	}

	private float _003CInitEnemy_003Eb__19_0()
	{
		return _fireTime;
	}

	private void _003CInitEnemy_003Eb__19_1(float x)
	{
		_fireTime = x;
	}
}
