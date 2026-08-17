using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyRangedAdvanced : EnemyController
{
	private EnemyType _originalBullet = EnemyType.BULLET_1;

	private float _keepMoving = 1f;

	private float _fireDelay = 2000f;

	private float _firingRandom;

	private float _minRange = 200f;

	private float _maxRange = 250f;

	private Tween _onEnterTween;

	private Timer _onFireTimer;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0044: Expected I4, but got O
		//IL_0421: Expected O, but got Ref
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected F4, but got Unknown
		//IL_00fe->IL03c9: Incompatible stack heights: 5 vs 3
		//IL_0168->IL03ee: Incompatible stack heights: 6 vs 4
		//IL_0479->IL01f5: Incompatible stack heights: 5 vs 4
		//IL_0297->IL0479: Incompatible stack heights: 7 vs 5
		base.InitEnemy(enemyType, asRemote);
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		EnemyData currentEnemyData = _currentEnemyData;
		EnemyType originalBullet = (((object)currentEnemyData._003CbulletType_003Ek__BackingField == null) ? EnemyType.BULLET_1 : ((EnemyType)((object?)currentEnemyData._003CbulletType_003Ek__BackingField >> 32)));
		_originalBullet = originalBullet;
		EnemyData currentEnemyData2 = _currentEnemyData;
		bool flag2 = _currentEnemyData == null;
		float num = default(float);
		float fireDelay = (((object)currentEnemyData2._003CfireDelay_003Ek__BackingField == null) ? 2000f : num);
		_fireDelay = fireDelay;
		EnemyData currentEnemyData3 = _currentEnemyData;
		_minRange = 200f;
		_maxRange = 250f;
		bool flag3 = _currentEnemyData == null;
		if ((object)currentEnemyData3._003CfiringRangeMin_003Ek__BackingField != null)
		{
			bool flag4 = _currentEnemyData == null;
			bool flag5 = (object)currentEnemyData3._003CfiringRangeMin_003Ek__BackingField == null;
			_minRange = num;
		}
		EnemyData currentEnemyData4 = _currentEnemyData;
		bool flag6 = _currentEnemyData == null;
		if ((object)currentEnemyData4._003CfiringRangeMax_003Ek__BackingField != null)
		{
			bool flag7 = _currentEnemyData == null;
			bool flag8 = (object)currentEnemyData4._003CfiringRangeMax_003Ek__BackingField == null;
			_maxRange = num;
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Restart(_onEnterTween);
		}
		else
		{
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&value), 0.3f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 0;
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag9 = tweenerCore == null;
			_onEnterTween = tweenerCore;
		}
		EnemyData currentEnemyData5 = _currentEnemyData;
		bool flag10 = _currentEnemyData == null;
		if ((object)currentEnemyData5._003CfireDelayRandomness_003Ek__BackingField == null)
		{
			_firingRandom = 0f;
		}
		else
		{
			bool flag11 = _currentEnemyData == null;
			bool flag12 = (object)currentEnemyData5._003CfireDelayRandomness_003Ek__BackingField == null;
			_firingRandom = num;
		}
		float firingRandom = _firingRandom;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float minInclusive = firingRandom ^ 0;
		float num2 = UnityEngine.Random.Range(minInclusive, _firingRandom);
		Action onComplete = delegate
		{
			Fire();
		};
		float num3 = num2 + _fireDelay;
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer onFireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_onFireTimer = onFireTimer;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_000a: Expected I, but got O
		//IL_001a: Expected O, but got I
		//IL_0089: Expected F4, but got O
		//IL_00d0: Expected F4, but got I
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected O, but got Unknown
		//IL_038d: Expected O, but got Ref
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_0283: Expected O, but got F4
		//IL_030b->IL028d: Incompatible stack heights: 1 vs 0
		//IL_042f->IL028d: Incompatible stack heights: 1 vs 0
		//IL_0392->IL0126: Incompatible stack heights: 2 vs 0
		//IL_019c->IL028d: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL028d: Incompatible stack heights: 1 vs 0
		//IL_0610->IL028d: Incompatible stack heights: 2 vs 0
		//IL_028d->IL02b6: Incompatible stack heights: 2 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v3 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyRangedAdvanced>)+480]");
		object obj = 0;
		base.UpdateDepth();
		if (base._003CIsTimeStopped_003Ek__BackingField)
		{
			return;
		}
		if (!base._fixedDirection)
		{
			goto IL_00e3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001877421A1h\"");
		bool flag = (object)_currentDirection != null;
		float num2 = (float)_currentDirection;
		Vector2 vector = (Vector2)this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001877421A1h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRangedAdvanced)+1E4]");
			bool flag2 = (nint)0 != 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRangedAdvanced)+1E4]");
			num2 = 0f;
			vector = (Vector2)this;
			if (!flag2)
			{
				goto IL_00e3;
			}
		}
		goto IL_0126;
		IL_028d:
		throw new NullReferenceException();
		IL_00e3:
		RetargetIfNecessary();
		Transform targetTransform = base._targetTransform;
		Vector3 ret2;
		object obj3 = default(object);
		if ((object)base._targetTransform != null)
		{
			bool flag3 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			object cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdi_v16 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdi_v16 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret2);
				Vector2 currentDirection = ret - ret2;
				object obj2 = default(object);
				num2 = (float)obj2 - (float)obj3;
				vector = (Vector2)(this + 480);
				_currentDirection = currentDirection;
				((Vector2*)vector)->Normalize();
				obj = (object)(&ret2);
				goto IL_0126;
			}
		}
		goto IL_028d;
		IL_0126:
		if (_medusa)
		{
			num2 = _medusaElapsed + 0.05f;
			_medusaElapsed = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		}
		Transform cachedTransform2 = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag5 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out ret2);
			float num3 = (float)ret2 * 100f;
			float num4 = (float)obj3 * 100f;
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret2);
					float num5 = (float)ret2 * 100f;
					float num6 = (float)obj3 * 100f;
					float num7 = num4 - num6;
					float num8 = num3 - num5;
					float num9 = _minRange * _minRange;
					float num10 = num7 * num7;
					float num11 = num8 * num8;
					float num12 = num11 + num10;
					if (!(num9 > num12))
					{
						float num13 = _maxRange * _maxRange;
						if (num12 > num13)
						{
							_keepMoving = 1f;
						}
					}
					else
					{
						_keepMoving = -1f;
					}
					float num15;
					if (_receivingDamage)
					{
						float num14 = base._003CKnockBack_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						object obj4 = num14 ^ 0;
						object obj5 = obj4 * _damageKb;
						num15 = (float)obj5 * _keepMoving;
					}
					else
					{
						num15 = 1f;
					}
					bool flag7 = (nint)_currentDirection < 0;
					bool flag8 = (object)_currentDirection == null;
					bool flag9 = !flag7;
					bool flag10 = !flag8;
					bool flag11 = flag10 & flag9;
					base.SetFlipX(flag11);
					float num16 = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
					float num17 = num16 / 100f;
					float num18 = num17 * _keepMoving;
					float num19 = num18 * num15;
					float num20 = num19 * base._003CSlow_003Ek__BackingField;
					float num21 = num20;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRangedAdvanced)+1E4]");
					float num22 = num21 * 0f;
					float num23 = num20 * (float)_currentDirection;
					BaseBody baseBody = body;
					if (body != null)
					{
						baseBody._velocity = (float2)num23;
						return;
					}
				}
			}
		}
		goto IL_028d;
	}

	protected override void Die()
	{
		base.Die();
		if (_onFireTimer != null)
		{
			_onFireTimer.Cancel();
		}
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_onFireTimer != null)
		{
			_onFireTimer.Cancel();
		}
	}

	private void Fire()
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected F4, but got Unknown
		//IL_00a1->IL00c3: Incompatible stack heights: 1 vs 0
		if (!base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField)
		{
			object cachedTransform = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rbx_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rbx_v2 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			Vector2 spawnPos = default(Vector2);
			base.FireEnemyAsBullet(spawnPos, _originalBullet);
			float firingRandom = _firingRandom;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float minInclusive = firingRandom ^ 0;
			float num = UnityEngine.Random.Range(minInclusive, _firingRandom);
			Action onComplete = delegate
			{
				Fire();
			};
			float num2 = num + _fireDelay;
			float duration = num2 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer onFireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_onFireTimer = onFireTimer;
		}
	}

	private void _003CInitEnemy_003Eb__8_0()
	{
		Fire();
	}

	private void _003CFire_003Eb__12_0()
	{
		Fire();
	}
}
