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

public class EnemyRanged : EnemyController
{
	private EnemyType _originalBullet = EnemyType.BULLET_1;

	private float _keepMoving = 1f;

	private float _fireDelay = 2000f;

	private float _previousDistance;

	private Tween _onEnterTween;

	private Timer _onFireTimer;

	private new const float Distance = 50000f;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0044: Expected I4, but got O
		//IL_0252: Expected O, but got Ref
		//IL_02aa->IL0121: Incompatible stack heights: 3 vs 2
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
		if (_onEnterTween != null)
		{
			TweenExtensions.Restart(_onEnterTween);
		}
		else
		{
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&value), 0.3f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
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
			bool flag3 = tweenerCore == null;
			_onEnterTween = tweenerCore;
		}
		Action onComplete = delegate
		{
			//IL_00a3->IL005d: Incompatible stack heights: 1 vs 0
			if (!base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField)
			{
				Transform cachedTransform2 = _cachedTransform;
				bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out Vector3 _);
				Vector2 spawnPos = default(Vector2);
				base.FireEnemyAsBullet(spawnPos, _originalBullet);
			}
		};
		float duration = _fireDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer onFireTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_onFireTimer = onFireTimer;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_000a: Expected I, but got O
		//IL_001a: Expected O, but got I
		//IL_0089: Expected F4, but got O
		//IL_00d0: Expected F4, but got I
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		//IL_037b: Expected O, but got Ref
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0271: Expected O, but got F4
		//IL_02f9->IL027b: Incompatible stack heights: 1 vs 0
		//IL_041d->IL027b: Incompatible stack heights: 1 vs 0
		//IL_0380->IL0126: Incompatible stack heights: 2 vs 0
		//IL_019c->IL027b: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL027b: Incompatible stack heights: 1 vs 0
		//IL_05ec->IL027b: Incompatible stack heights: 2 vs 0
		//IL_027b->IL02a4: Incompatible stack heights: 2 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v3 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyRanged>)+480]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001877414B1h\"");
		bool flag = (object)_currentDirection != null;
		float num2 = (float)_currentDirection;
		Vector2 vector = (Vector2)this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001877414B1h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRanged)+1E4]");
			bool flag2 = (nint)0 != 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRanged)+1E4]");
			num2 = 0f;
			vector = (Vector2)this;
			if (!flag2)
			{
				goto IL_00e3;
			}
		}
		goto IL_0126;
		IL_027b:
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
		goto IL_027b;
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
					float num9 = num7 * num7;
					float num10 = num8 * num8;
					float num11 = num10 + num9;
					if (!(49000f > num11))
					{
						if (num11 > 51000f)
						{
							_keepMoving = 1f;
						}
					}
					else
					{
						_keepMoving = -1f;
					}
					float num13;
					if (_receivingDamage)
					{
						float num12 = base._003CKnockBack_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						object obj4 = num12 ^ 0;
						object obj5 = obj4 * _damageKb;
						num13 = (float)obj5 * _keepMoving;
					}
					else
					{
						num13 = 1f;
					}
					bool flag7 = (nint)_currentDirection < 0;
					bool flag8 = (object)_currentDirection == null;
					bool flag9 = !flag7;
					bool flag10 = !flag8;
					bool flag11 = flag10 & flag9;
					base.SetFlipX(flag11);
					float num14 = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
					float num15 = num14 / 100f;
					float num16 = num15 * _keepMoving;
					float num17 = num16 * num13;
					float num18 = num17 * base._003CSlow_003Ek__BackingField;
					float num19 = num18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyRanged)+1E4]");
					float num20 = num19 * 0f;
					float num21 = num18 * (float)_currentDirection;
					BaseBody baseBody = body;
					if (body != null)
					{
						baseBody._velocity = (float2)num21;
						return;
					}
				}
			}
		}
		goto IL_027b;
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
		//IL_00a3->IL005d: Incompatible stack heights: 1 vs 0
		if (!base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField)
		{
			Transform cachedTransform = _cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Vector2 spawnPos = default(Vector2);
			base.FireEnemyAsBullet(spawnPos, _originalBullet);
		}
	}

	private void _003CInitEnemy_003Eb__7_0()
	{
		//IL_00a3->IL005d: Incompatible stack heights: 1 vs 0
		if (!base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField)
		{
			Transform cachedTransform = _cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Vector2 spawnPos = default(Vector2);
			base.FireEnemyAsBullet(spawnPos, _originalBullet);
		}
	}
}
