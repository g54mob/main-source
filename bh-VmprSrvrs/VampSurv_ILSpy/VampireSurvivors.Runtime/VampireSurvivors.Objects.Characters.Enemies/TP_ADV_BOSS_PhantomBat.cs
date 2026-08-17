using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class TP_ADV_BOSS_PhantomBat : EnemyControllerBoss
{
	private enum BEHAVIOUR_MODE
	{
		SETUP,
		MAIN,
		SWARM_TRANSITION,
		SWARM
	}

	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public TP_ADV_BOSS_PhantomBat _003C_003E4__this;

		public Vector2 spawnPos;

		internal void _003CSplitIntoSwarm_003Eb__0()
		{
			TP_ADV_BOSS_PhantomBat tP_ADV_BOSS_PhantomBat = _003C_003E4__this;
			Vector2 pos = default(Vector2);
			_003C_003E4__this.SpawnPhantomSwarm(tP_ADV_BOSS_PhantomBat.swarmBat, tP_ADV_BOSS_PhantomBat.phantomBatsSpawned, pos);
			_003C_003E4__this.FinishSwarmTransition();
		}
	}

	private EnemyType swarmBat = EnemyType.TP_ADV_MINION_SWARMBAT;

	private int phantomBatsSpawned = 20;

	private BEHAVIOUR_MODE _behaviour;

	private static readonly List<float> HealthPercentThresholds;

	private int _currentPercentThreshold;

	private float _healthThreshold;

	private bool _thresholdsCompleted;

	private bool _isInvulnerable;

	private List<EnemyController> _batSwarmTracker;

	private Vector3 finalBatDeathPosition;

	private SpriteTrail _spriteTrail;

	private Tween _moveTween;

	private MultiTargetTween _swarmTween;

	public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
	{
		//IL_003e: Expected O, but got I
		base.InitEnemy(enemyType, asRemote);
		_behaviour = BEHAVIOUR_MODE.MAIN;
		_thresholdsCompleted = false;
		List<float> healthPercentThresholds = HealthPercentThresholds;
		int currentPercentThreshold = _currentPercentThreshold;
		int currentPercentThreshold2 = _currentPercentThreshold;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)currentPercentThreshold2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			float num = _maxHp;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v9+20+v70 @ rax_v6 (System.Int32)*4]");
			float healthThreshold = num * 0f;
			_healthThreshold = healthThreshold;
			SpriteTrail component = _EnemyRenderer.GetComponent<SpriteTrail>();
			_spriteTrail = component;
			Action onComplete = delegate
			{
				EnableSpriteTrail(enable: false);
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	protected override void OnUpdate()
	{
		//IL_00e6: Expected O, but got I4
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0249: Expected O, but got F4
		OnUpdate();
		base.UpdateSpawnDamageZones();
		if (((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		base.UpdateDepth();
		if (((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField || _thresholdsCompleted)
		{
			return;
		}
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null && ((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0 && !_coherenceSync.HasStateAuthority)
		{
			return;
		}
		bool flag = _behaviour == BEHAVIOUR_MODE.SETUP;
		if (flag)
		{
			return;
		}
		object obj = _behaviour - 1;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 != 1)
				{
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				IsSwarmDead();
			}
		}
		else if (_healthThreshold > _hp)
		{
			object obj3 = UnityEngine.Random.value;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				SplitIntoSwarm(_healthThreshold);
				return;
			}
			Action<float> action = null;
			float randomValue = default(float);
			((TP_ADV_BOSS_PhantomBat)(object)action).SplitIntoSwarm(randomValue);
			bool flag2 = _coherenceSync.SendCommand(action, MessageTarget.All, _healthThreshold);
		}
	}

	protected override void SpawnBossBullets()
	{
		if (bossSpawnsBullets && !((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField && !((EnemyController)this)._003CIsDead_003Ek__BackingField && _behaviour == BEHAVIOUR_MODE.MAIN)
		{
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		}
	}

	private void CheckForSplitIntoSwarm()
	{
		//IL_00a1: Expected O, but got F4
		if (_healthThreshold > _hp)
		{
			object obj = UnityEngine.Random.value;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				SplitIntoSwarm(_healthThreshold);
				return;
			}
			Action<float> action = null;
			float randomValue = default(float);
			((TP_ADV_BOSS_PhantomBat)(object)action).SplitIntoSwarm(randomValue);
			bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, _healthThreshold);
		}
	}

	public unsafe void SplitIntoSwarm(float randomValue)
	{
		//IL_0012: Expected O, but got I8
		//IL_0146: Expected O, but got Ref
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_03db: Expected O, but got I4
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_03c8->IL02f3: Incompatible stack heights: 1 vs 0
		//IL_02f2->IL02f2: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass18_0();
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;
		if (CS_0024_003C_003E8__locals9 != null)
		{
			object obj = 6603577472L;
			CS_0024_003C_003E8__locals9._003C_003E4__this = this;
			if (((EnemyController)this)._003CIsDead_003Ek__BackingField)
			{
				return;
			}
			_behaviour = BEHAVIOUR_MODE.SWARM_TRANSITION;
			_isInvulnerable = true;
			((EnemyController)this)._003CSpeed_003Ek__BackingField = 0f;
			if (BulletSpawnTimer != null)
			{
				BulletSpawnTimer.Cancel();
			}
			EnableSpriteTrail(enable: true);
			Vector2 batSwarmSpawnPos = GetBatSwarmSpawnPos(randomValue);
			CS_0024_003C_003E8__locals9.spawnPos = batSwarmSpawnPos;
			if ((object)_EnemyRenderer != null)
			{
				Transform transform = _EnemyRenderer.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					object obj3 = default(object);
					object obj4 = default(object);
					object obj2 = obj3 + obj4;
					if (_moveTween != null)
					{
						TweenExtensions.Kill(_moveTween);
					}
					tweenerCore = ShortcutExtensions.DOLocalMove(_cachedTransform, (Vector3)(&ret), 0.5f);
					TweenCallback tweenCallback2;
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v542 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							bool flag2 = (nint)0 == 0;
							_ = 0;
							if (!flag2)
							{
								object obj5 = tweenerCore + 184;
								object obj6 = obj5 >> 12;
								object obj7 = obj6 & 0x1FFFFF;
								object obj8 = obj7 >> 6;
								object obj9 = obj7 & 0x3F;
								nint num2;
								do
								{
									object obj10 = 1 << (int)obj9;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r14_v4+462E0+v594 @ rdx_v25*8]");
									object obj11 = 0 | obj10;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r14_v4+462E0+v594 @ rdx_v25*8]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r14_v4+462E0+v594 @ rdx_v25*8]");
									if (num == 0)
									{
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r14_v4+462E0+v594 @ rdx_v25*8]");
									num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r14_v4+462E0+v594 @ rdx_v25*8]");
								}
								while (num2 != 0);
								TweenCallback tweenCallback = delegate
								{
									TP_ADV_BOSS_PhantomBat tP_ADV_BOSS_PhantomBat = CS_0024_003C_003E8__locals9._003C_003E4__this;
									Vector2 pos = default(Vector2);
									CS_0024_003C_003E8__locals9._003C_003E4__this.SpawnPhantomSwarm(tP_ADV_BOSS_PhantomBat.swarmBat, tP_ADV_BOSS_PhantomBat.phantomBatsSpawned, pos);
									CS_0024_003C_003E8__locals9._003C_003E4__this.FinishSwarmTransition();
								};
								tweenCallback2 = tweenCallback;
								goto IL_0276;
							}
						}
					}
					TweenCallback tweenCallback3 = delegate
					{
						TP_ADV_BOSS_PhantomBat tP_ADV_BOSS_PhantomBat = CS_0024_003C_003E8__locals9._003C_003E4__this;
						Vector2 pos = default(Vector2);
						CS_0024_003C_003E8__locals9._003C_003E4__this.SpawnPhantomSwarm(tP_ADV_BOSS_PhantomBat.swarmBat, tP_ADV_BOSS_PhantomBat.phantomBatsSpawned, pos);
						CS_0024_003C_003E8__locals9._003C_003E4__this.FinishSwarmTransition();
					};
					bool flag3 = tweenerCore == null;
					tweenCallback2 = tweenCallback3;
					if (!flag3)
					{
						goto IL_0276;
					}
					goto IL_02a5;
				}
			}
		}
		goto IL_02f3;
		IL_0276:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v542 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_02a5;
		IL_02f3:
		throw new NullReferenceException();
		IL_02a5:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			_moveTween = tweenerCore;
			return;
		}
		goto IL_02f3;
	}

	private void FinishSwarmTransition()
	{
		//IL_0096: Expected I, but got O
		//IL_00fa: Expected O, but got I4
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
		EnableSpriteTrail(enable: false);
		if (_swarmTween != null)
		{
			_swarmTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_EnemyRenderer != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween swarmTween = Tweens.Add(tweenConfig);
		_swarmTween = swarmTween;
	}

	private unsafe void IsSwarmDead()
	{
		//IL_00a2: Expected O, but got I
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_005f: Expected O, but got Ref
		//IL_0117: Expected O, but got I
		//IL_015e: Expected O, but got I4
		//IL_0141: Expected O, but got Ref
		//IL_0102: Expected O, but got I8
		List<EnemyController> batSwarmTracker = _batSwarmTracker;
		if (batSwarmTracker._size > 0)
		{
			return;
		}
		GameManager core = GM.Core;
		object obj = default(object);
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			RecoverFromSwarm((Vector3)(&obj));
			return;
		}
		Action<Vector3> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r10_v2 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj2 = (nint)0 >> 4;
		object obj3 = obj2 & 1;
		object obj4;
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				obj4 = 6447744240L;
				goto IL_0155;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v9 (System.Action`1<UnityEngine.Vector3>)+10]");
		obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v9 (System.Action`1<UnityEngine.Vector3>)+20]");
		_ = 0;
		goto IL_0155;
		IL_0155:
		object obj5 = 24;
		_ = 6447744112L;
		bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, (Vector3)(&obj));
	}

	public unsafe void RecoverFromSwarm(Vector3 finalBatDeathPosition)
	{
		//IL_009d: Expected O, but got I
		//IL_02ae: Expected O, but got I4
		//IL_02e6: Expected O, but got I4
		//IL_034a: Expected I, but got O
		//IL_00bd->IL03a3: Incompatible stack heights: 1 vs 0
		//IL_0113->IL03f8: Incompatible stack heights: 1 vs 0
		//IL_0529->IL03a3: Incompatible stack heights: 6 vs 0
		//IL_01bf->IL03a3: Incompatible stack heights: 6 vs 0
		//IL_0213->IL03a3: Incompatible stack heights: 7 vs 0
		//IL_0289->IL03a3: Incompatible stack heights: 7 vs 0
		//IL_0267->IL0267: Incompatible stack heights: 8 vs 7
		//IL_03a3->IL057d: Incompatible stack heights: 7 vs 0
		if (((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		int num = _currentPercentThreshold + 1;
		_behaviour = BEHAVIOUR_MODE.MAIN;
		_currentPercentThreshold = num;
		List<float> healthPercentThresholds = HealthPercentThresholds;
		if (HealthPercentThresholds != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num >= (nint)0)
			{
				_thresholdsCompleted = true;
				goto IL_03f8;
			}
			List<float> healthPercentThresholds2 = HealthPercentThresholds;
			int currentPercentThreshold = _currentPercentThreshold;
			if (HealthPercentThresholds != null)
			{
				int currentPercentThreshold2 = _currentPercentThreshold;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rcx_v91 (System.Collections.Generic.List`1<System.Single>)+18]");
				bool flag = (nint)currentPercentThreshold2 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rcx_v91 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rcx_v91 (System.Collections.Generic.List`1<System.Single>)+10]");
				if ((nint)0 != 0)
				{
					int currentPercentThreshold3 = _currentPercentThreshold;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v92+18]");
					if ((nint)currentPercentThreshold3 < (nint)0)
					{
						float num2 = _maxHp;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v92+20+v314 @ rax_v117 (System.Int32)*4]");
						float healthThreshold = num2 * 0f;
						_healthThreshold = healthThreshold;
						goto IL_03f8;
					}
					throw new IndexOutOfRangeException();
				}
			}
		}
		goto IL_03a3;
		IL_03a3:
		throw new NullReferenceException();
		IL_03f8:
		Transform cachedTransform = _cachedTransform;
		bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)(&value));
		object cachedTransform2 = _cachedTransform;
		bool flag3 = (object)_cachedTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ rbx_v19 (System.Object)+10]");
		bool flag4 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ rbx_v19 (System.Object)+10]");
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected((IntPtr)0, ref value2);
		BaseBody baseBody = body;
		bool flag5 = body == null;
		baseBody._enable = true;
		_isInvulnerable = true;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_EnemyRenderer, 1f);
		EnableSpriteTrail(enable: false);
		object cachedTransform3 = _cachedTransform;
		bool flag6 = (object)_cachedTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rbx_v21 (System.Object)+10]");
		bool flag7 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rbx_v21 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 _);
		if ((object)_EnemyRenderer != null)
		{
			Transform transform = _EnemyRenderer.transform;
			if ((object)transform != null)
			{
				bool flag8 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&value));
				if (_swarmTween != null)
				{
					_swarmTween.Kill();
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				if (array != null)
				{
					if ((object)_cachedTransform != null)
					{
						int value3 = ((int*)(&array))->m_value;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj2 = default(object);
						bool flag9 = obj2 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						tweenConfig.scale = (float?)(object)1;
						tweenConfig.duration = 800f;
						tweenConfig.delay = 200f;
						tweenConfig.ease = Ease.OutBack;
						tweenConfig.y = (float?)(object)1;
						TweenCallback onComplete = delegate
						{
							SpriteAnimation spriteAnimation = _SpriteAnimation;
							_isInvulnerable = false;
							((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
							((EnemyController)this)._003CSpeed_003Ek__BackingField = _defaultSpeed;
						};
						tweenConfig.onComplete = onComplete;
						MultiTargetTween swarmTween = Tweens.Add(tweenConfig);
						_swarmTween = swarmTween;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1485 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.TP_ADV_BOSS_PhantomBat>)+510]");
						Action onComplete2 = new Action(this, (IntPtr)0);
						nint num3 = (nint)this;
						float duration = bulletSpawnInterval * 0.001f;
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer bulletSpawnTimer = Timers.Register(duration, onComplete2, null, bulletSpawnLooping, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						BulletSpawnTimer = bulletSpawnTimer;
						return;
					}
				}
			}
		}
		goto IL_03a3;
	}

	protected virtual void SpawnPhantomSwarm(EnemyType type, int spawnAmount, Vector2 pos)
	{
		//IL_0094: Expected O, but got I4
		//IL_00f8: Expected I, but got O
		//IL_0108: Expected O, but got I
		//IL_0188: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_0241: Expected O, but got I4
		//IL_0144: Expected O, but got I
		//IL_017a: Expected O, but got I4
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		List<EnemyController> batSwarmTracker = _batSwarmTracker;
		_behaviour = BEHAVIOUR_MODE.SWARM;
		int version = batSwarmTracker._version + 1;
		batSwarmTracker._version = version;
		batSwarmTracker._size = 0;
		if (batSwarmTracker._size > 0)
		{
			Array.Clear(batSwarmTracker._items, 0, batSwarmTracker._size);
		}
		bool flag = spawnAmount <= 0;
		object obj = 0;
		if (flag)
		{
			return;
		}
		object obj2 = default(object);
		do
		{
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
			object obj3;
			Vector2 vector;
			if (obj2 == null)
			{
				obj3 = 0;
				vector = pos;
				goto IL_0254;
			}
			vector = (Vector2)obj2;
			nint num = (nint)typeof(TP_ADV_MINION_SwarmBat);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.TP_ADV_MINION_SwarmBat>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v5 (UnityEngine.Vector2)+130]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.TP_ADV_MINION_SwarmBat>)+130]");
			object obj6;
			if (num2 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v5 (UnityEngine.Vector2)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rax_v28+FFFFFFF8+v281 @ rax_v24*8]");
				if (0 == (nint)typeof(TP_ADV_MINION_SwarmBat))
				{
					obj6 = 1;
					goto IL_0229;
				}
			}
			obj6 = 0;
			goto IL_0229;
			IL_0229:
			bool flag2 = obj6 == null;
			obj3 = 0;
			if (!flag2)
			{
				obj3 = obj2;
			}
			goto IL_0254;
			IL_0254:
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v3+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
				}
			}
			obj++;
		}
		while ((nint)obj < spawnAmount);
	}

	private Vector2 GetBatSwarmSpawnPos(float randomValue)
	{
		//IL_00b2->IL004d: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		float num = randomValue * ((float)Math.PI * 2f);
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Transform cachedTransform2 = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Vector2 result = default(Vector2);
				return result;
			}
		}
		throw new NullReferenceException();
	}

	public void BatInSwarmKilled(EnemyController batKilled)
	{
		//IL_015e->IL0118: Incompatible stack heights: 1 vs 0
		if ((object)batKilled == null || ((UnityEngine.Object)batKilled).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (_batSwarmTracker != null)
		{
			bool flag = ((List<object>)(object)_batSwarmTracker).Remove((object)batKilled);
			List<EnemyController> batSwarmTracker = _batSwarmTracker;
			if (_batSwarmTracker != null)
			{
				if (batSwarmTracker._size != 0)
				{
					return;
				}
				Transform transform = batKilled.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					finalBatDeathPosition = ret;
					_ = 0;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void EnableSpriteTrail(bool enable)
	{
		SpriteTrail spriteTrail = _spriteTrail;
		if ((object)_spriteTrail != null && ((UnityEngine.Object)spriteTrail).m_CachedPtr != (IntPtr)0)
		{
			SpriteTrail spriteTrail2 = _spriteTrail.setVisible(enable);
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (!_isInvulnerable)
		{
			base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
		}
	}

	public override void Despawn()
	{
		if (_moveTween != null)
		{
			TweenExtensions.Kill(_moveTween);
		}
		if (_swarmTween != null)
		{
			_swarmTween.Kill();
		}
		base.Despawn();
	}

	public TP_ADV_BOSS_PhantomBat()
	{
		List<EnemyController> batSwarmTracker = new List<EnemyController>();
		_batSwarmTracker = batSwarmTracker;
		base._002Ector();
	}

	static TP_ADV_BOSS_PhantomBat()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_019e: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_01c6: Expected O, but got I
		//IL_0156: Expected O, but got I
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(0.75f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1061158912;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v5+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(0.5f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1056964608;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(0.25f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1048576000;
		}
		HealthPercentThresholds = list;
	}

	private void _003CInitEnemy_003Eb__14_0()
	{
		EnableSpriteTrail(enable: false);
	}

	private void _003CRecoverFromSwarm_003Eb__21_0()
	{
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		_isInvulnerable = false;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		((EnemyController)this)._003CSpeed_003Ek__BackingField = _defaultSpeed;
	}
}
