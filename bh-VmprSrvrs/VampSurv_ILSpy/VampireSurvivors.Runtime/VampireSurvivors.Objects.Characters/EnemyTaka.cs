using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using Zenject;

namespace VampireSurvivors.Objects.Characters;

public class EnemyTaka : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public PhaserSprite exp;

		public EnemyTaka _003C_003E4__this;

		internal void _003CAddExplosionEffect_003Eb__0()
		{
			PhaserSprite phaserSprite = exp.setVisible(visible: false);
			EnemyTaka enemyTaka = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
			EnemyTaka enemyTaka2 = _003C_003E4__this;
			bool flag = ((List<object>)(object)enemyTaka2._explosionSprites).Remove((object)exp);
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public EnemyController enemy;

		internal void _003CHandleBundle_003Eb__0()
		{
			//IL_00dd->IL0110: Incompatible stack heights: 1 vs 0
			Transform transform = (Transform)(object)enemy;
			if ((object)enemy != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
			{
				Behaviour behaviour = enemy;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v8 (UnityEngine.Behaviour)+28]");
				if ((nint)0 != 0)
				{
					behaviour.enabled = true;
					EnemyController enemyController = enemy;
					BaseBody body = enemyController.body;
					body._enable = true;
					Transform transform2 = enemy.transform;
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Quaternion value = default(Quaternion);
					Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					EnemyController enemyController2 = enemy;
					enemyController2._003CIsCullable_003Ek__BackingField = true;
				}
			}
		}
	}

	private EnemyWeakPoint _weakPoint;

	private Timer _bundleSpawnTimer;

	private Timer _swarmSpawnTimer;

	private Timer _bulletSpawnTimer;

	private List<Sprite> _explosionFrames;

	private List<PhaserSprite> _explosionSprites;

	private List<PhaserSprite> _readyExplosionSprites;

	private bool _isExploding;

	private float _explosionTimer;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		if (_weakPoint == null)
		{
			EnemyWeakPoint weakPoint = new EnemyWeakPoint(this);
			_weakPoint = weakPoint;
		}
		Action onComplete = FireBundle;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bundleSpawnTimer = Timers.Register(3.0000002f, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bundleSpawnTimer = bundleSpawnTimer;
		Action onComplete2 = FireSwarm;
		Timer swarmSpawnTimer = Timers.Register(5f, onComplete2, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_swarmSpawnTimer = swarmSpawnTimer;
		Action onComplete3 = FireBullet;
		Timer bulletSpawnTimer = Timers.Register(4.5f, onComplete3, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bulletSpawnTimer = bulletSpawnTimer;
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Crush Bomb-Explosion-F", 1, 7, "firstBlood", flag ? 1 : 0);
		_explosionFrames = animationFrames;
		_SpriteAnimation.SetAnimation("idle");
	}

	private void AddExplosionEffect(float2 position)
	{
		//IL_015a: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_01bc: Expected O, but got I4
		//IL_027c: Expected I4, but got O
		//IL_01a4->IL03bd: Incompatible stack heights: 1 vs 0
		//IL_021c->IL03bd: Incompatible stack heights: 1 vs 0
		//IL_0249->IL0249: Incompatible stack heights: 1 vs 0
		//IL_0472->IL03bd: Incompatible stack heights: 1 vs 0
		//IL_03ad->IL03bd: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass10_0();
		if (CS_0024_003C_003E8__locals20 != null)
		{
			CS_0024_003C_003E8__locals20._003C_003E4__this = this;
			List<PhaserSprite> readyExplosionSprites = _readyExplosionSprites;
			if (_readyExplosionSprites != null)
			{
				if (readyExplosionSprites._size <= 0)
				{
					PhaserWorld instance = PhaserWorld.Instance;
					if ((object)instance != null)
					{
						PhaserSprite exp = instance.AddPhaserSprite((Vector2)0, "firstBlood", "Crush Bomb-Explosion-F1");
						CS_0024_003C_003E8__locals20.exp = exp;
						PhaserSprite exp2 = CS_0024_003C_003E8__locals20.exp;
						if ((object)CS_0024_003C_003E8__locals20.exp != null)
						{
							Action action = delegate
							{
								PhaserSprite phaserSprite3 = CS_0024_003C_003E8__locals20.exp.setVisible(visible: false);
								EnemyTaka enemyTaka = CS_0024_003C_003E8__locals20._003C_003E4__this;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
								EnemyTaka enemyTaka2 = CS_0024_003C_003E8__locals20._003C_003E4__this;
								bool flag3 = ((List<object>)(object)enemyTaka2._explosionSprites).Remove((object)CS_0024_003C_003E8__locals20.exp);
							};
							if ((object)exp2._spriteAnimation != null)
							{
								bool shouldLoop = default(bool);
								bool startRandomFrame = default(bool);
								Action onComplete = default(Action);
								bool autoSetAnimation = default(bool);
								exp2._spriteAnimation.AddAnimation("bang", _explosionFrames, 16, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
								goto IL_0249;
							}
						}
					}
				}
				else if (_readyExplosionSprites != null)
				{
					object obj = readyExplosionSprites._size - 1;
					bool flag = (nint)obj >= readyExplosionSprites._size;
					PhaserSprite[] items = readyExplosionSprites._items;
					if (readyExplosionSprites._items != null)
					{
						object obj2 = readyExplosionSprites._size - 1;
						if ((nint)obj2 >= items.Length)
						{
							throw new IndexOutOfRangeException();
						}
						CS_0024_003C_003E8__locals20.exp = items[obj2];
						List<PhaserSprite> readyExplosionSprites2 = _readyExplosionSprites;
						if (_readyExplosionSprites != null)
						{
							int index = readyExplosionSprites2._size - 1;
							_readyExplosionSprites.RemoveAt(index);
							goto IL_0249;
						}
					}
				}
			}
		}
		goto IL_03bd;
		IL_0249:
		if (_explosionSprites != null)
		{
			_explosionSprites.RemoveAt((int)CS_0024_003C_003E8__locals20.exp);
			if ((object)CS_0024_003C_003E8__locals20.exp != null)
			{
				PhaserSprite phaserSprite = CS_0024_003C_003E8__locals20.exp.setVisible(visible: true);
				PhaserSprite exp3 = CS_0024_003C_003E8__locals20.exp;
				if ((object)CS_0024_003C_003E8__locals20.exp != null && (object)exp3._spriteAnimation != null)
				{
					exp3._spriteAnimation.SetAnimation("bang");
					if ((object)CS_0024_003C_003E8__locals20.exp != null)
					{
						Transform transform = CS_0024_003C_003E8__locals20.exp.transform;
						if ((object)transform != null)
						{
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
							if ((object)CS_0024_003C_003E8__locals20.exp != null)
							{
								PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals20.exp.setDepth(3000);
								if ((object)CS_0024_003C_003E8__locals20.exp != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_03bd;
		IL_03bd:
		throw new NullReferenceException();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0185: Expected O, but got I4
		//IL_018e: Expected O, but got I4
		//IL_02b5: Invalid comparison between I4 and F4
		//IL_00a3: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_04b9: Expected O, but got F4
		//IL_0129: Expected O, but got F4
		//IL_03cd: Expected O, but got F4
		//IL_0277: Expected F4, but got I4
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected O, but got Unknown
		//IL_0206->IL02fb: Incompatible stack heights: 1 vs 0
		//IL_022c->IL02fb: Incompatible stack heights: 1 vs 0
		//IL_025f->IL02fb: Incompatible stack heights: 1 vs 0
		//IL_03bf->IL02fb: Incompatible stack heights: 2 vs 0
		//IL_047d->IL02fb: Incompatible stack heights: 5 vs 0
		//IL_02aa->IL0482: Incompatible stack heights: 5 vs 0
		float num = default(float);
		if (!_isExploding)
		{
			base.OnUpdate();
			EnemyWeakPoint weakPoint = _weakPoint;
			if (_weakPoint != null)
			{
				ArcadeSprite damageZone = weakPoint._damageZone;
				if ((object)weakPoint._damageZone != null && damageZone.body != null)
				{
					BaseBody baseBody = damageZone.body.setCircle(16f, (float?)(object)1, (float?)(object)1);
					EnemyWeakPoint weakPoint2 = _weakPoint;
					if (_weakPoint != null && body != null)
					{
						if (base.flipX)
						{
						}
						if ((object)weakPoint2._damageZone != null)
						{
							weakPoint2._damageZone.position = (float2)num;
							return;
						}
					}
				}
			}
		}
		else
		{
			float deltaTime = PauseSystem.DeltaTime;
			List<PhaserSprite> explosionSprites = _explosionSprites;
			float explosionTimer = _explosionTimer - deltaTime;
			_explosionTimer = explosionTimer;
			if (_explosionSprites != null)
			{
				object obj = 0;
				object obj2 = 0;
				float value = default(float);
				while (true)
				{
					if ((nint)obj2 < explosionSprites._size)
					{
						List<PhaserSprite> explosionSprites2 = _explosionSprites;
						if (_explosionSprites == null)
						{
							break;
						}
						bool flag = (nint)obj >= explosionSprites2._size;
						PhaserSprite[] items = explosionSprites2._items;
						if (explosionSprites2._items == null || (object)items[obj] == null)
						{
							break;
						}
						Transform transform = items[obj].transform;
						if ((object)transform == null)
						{
							break;
						}
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if (PauseSystem._paused)
						{
							deltaTime = 0f;
						}
						else
						{
							object obj3 = Time.deltaTime;
						}
						Transform transform2 = items[obj].transform;
						Transform transform3 = items[obj].transform;
						if ((object)transform3 == null)
						{
							break;
						}
						bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
						bool flag4 = (object)transform2 == null;
						bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
						explosionSprites = _explosionSprites;
						obj++;
						if (_explosionSprites == null)
						{
							break;
						}
						deltaTime = num;
						obj2 = obj;
						continue;
					}
					if (0f > _explosionTimer)
					{
						_explosionTimer = 0.016f;
						if (body == null)
						{
							break;
						}
						UnityEngine.Random.GetRandomUnitCircle(out Vector2 _);
						AddExplosionEffect((float2)num);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StartExploding()
	{
		//IL_0085: Expected F4, but got I4
		//IL_0097: Expected I, but got O
		//IL_0132: Expected I4, but got F4
		//IL_0132: Expected O, but got F4
		//IL_0132: Expected I4, but got O
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		_isExploding = true;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		CancelAttacks();
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = false;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = false;
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BossExplosions, 5000f, 1, 0f, num, num2, num3, flag, 1f);
		nint num4 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num5 = 0;
		BaseBody baseBody = body;
		baseBody._velocity = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v9 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		Action onComplete = delegate
		{
			//IL_003f: Expected O, but got I4
			_isExploding = false;
			GameManager core3 = GM.Core;
			core3._003CCanInterrupt_003Ek__BackingField = true;
			GameManager core4 = GM.Core;
			core4._003CCanPause_003Ek__BackingField = true;
			ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
			base.Die();
		};
		Timer timer = Timers.Register(4.2000003f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
	}

	private void LateUpdate()
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	protected override void OnDestroy()
	{
		Clearup();
		base.OnDestroy();
	}

	protected override void Die()
	{
		if (!_isExploding && !base._003CIsDead_003Ek__BackingField && _coherenceSync.HasStateAuthority)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				StartExploding();
				return;
			}
			_isExploding = true;
			Action action = StartExplodingOnline;
			bool flag = _coherenceSync.SendCommand(action, MessageTarget.All);
		}
	}

	public void StartExplodingOnline()
	{
		StartExploding();
	}

	public override void Despawn()
	{
		Clearup();
		base.Despawn();
	}

	private void Clearup()
	{
		if (_weakPoint != null)
		{
			_weakPoint.Destroy();
			_weakPoint = null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x187682280\"");
	}

	private void CancelAttacks()
	{
		if (_bundleSpawnTimer != null)
		{
			_bundleSpawnTimer.Cancel();
			_bundleSpawnTimer = null;
		}
		if (_bulletSpawnTimer != null)
		{
			_bulletSpawnTimer.Cancel();
			_bulletSpawnTimer = null;
		}
		if (_swarmSpawnTimer != null)
		{
			_swarmSpawnTimer.Cancel();
			_swarmSpawnTimer = null;
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_008c: Expected F4, but got I4
		//IL_00aa: Expected I4, but got F4
		//IL_00aa: Expected I4, but got O
		if (!_isExploding)
		{
			EnemyWeakPoint weakPoint = _weakPoint;
			object obj = default(object);
			if (weakPoint._isApplyingDamage || (nint)obj == 73)
			{
				float? num = default(float?);
				float num2 = default(float);
				float detune = default(float);
				bool loop = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_EnemyHit, 100f, 10, 0f, num, num2, detune, loop, 1f);
				base.GetDamaged(value, showHitVfx, damageKb, (WeaponType)num, (byte)(int)num2 != 0);
			}
		}
	}

	private void FireBullet()
	{
		if (!base._003CIsTimeStopped_003Ek__BackingField && _coherenceSync.HasStateAuthority && !base._003CIsDead_003Ek__BackingField)
		{
			if (base.flipX)
			{
			}
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		}
	}

	private void FireBundle()
	{
		if (!base._003CIsTimeStopped_003Ek__BackingField && _coherenceSync.HasStateAuthority && !base._003CIsDead_003Ek__BackingField)
		{
			if (base.flipX)
			{
			}
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
			GameManager core2 = GM.Core;
			EnemyController enemyController = default(EnemyController);
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				HandleBundle(enemyController);
				return;
			}
			Action<CoherenceSync> action = OnBundleSpawned;
			bool flag = _coherenceSync.SendCommand((Action<object>)action, MessageTarget.All, enemyController._coherenceSync);
		}
	}

	private unsafe void HandleBundle(EnemyController enemy)
	{
		//IL_0012: Expected O, but got I8
		//IL_0289: Expected O, but got Ref
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_06de: Expected O, but got I4
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f3: Expected O, but got Unknown
		//IL_04a9: Expected O, but got Ref
		//IL_0583->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_0173->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_01a3->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_01d2->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_05f8->IL04fb: Incompatible stack heights: 2 vs 0
		//IL_0210->IL04fb: Incompatible stack heights: 2 vs 0
		//IL_064a->IL04fb: Incompatible stack heights: 3 vs 0
		//IL_0249->IL04fb: Incompatible stack heights: 3 vs 0
		//IL_069c->IL04fb: Incompatible stack heights: 4 vs 0
		//IL_03b8->IL04fb: Incompatible stack heights: 4 vs 0
		//IL_03f9->IL04fb: Incompatible stack heights: 4 vs 0
		//IL_0438->IL04fb: Incompatible stack heights: 4 vs 0
		//IL_046c->IL04fb: Incompatible stack heights: 4 vs 0
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals38 = new _003C_003Ec__DisplayClass23_0();
		Vector3 ret3;
		Sequence sequence;
		TweenCallback signalBus;
		if (CS_0024_003C_003E8__locals38 != null)
		{
			object obj = 6603577472L;
			CS_0024_003C_003E8__locals38.enemy = enemy;
			if ((object)CS_0024_003C_003E8__locals38.enemy != null)
			{
				CS_0024_003C_003E8__locals38.enemy.enabled = false;
				EnemyController enemy2 = CS_0024_003C_003E8__locals38.enemy;
				if ((object)CS_0024_003C_003E8__locals38.enemy != null)
				{
					BaseBody baseBody = enemy2.body;
					if (enemy2.body != null)
					{
						baseBody._enable = false;
						EnemyController enemy3 = CS_0024_003C_003E8__locals38.enemy;
						if ((object)CS_0024_003C_003E8__locals38.enemy != null)
						{
							((ArcadeSprite)CS_0024_003C_003E8__locals38.enemy).CheckRenderer();
							EnemyController spriteRenderer = (EnemyController)(object)((ArcadeSprite)enemy3)._spriteRenderer;
							if ((object)((ArcadeSprite)enemy3)._spriteRenderer != null)
							{
								bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
								Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, 2000);
								EnemyController enemy4 = CS_0024_003C_003E8__locals38.enemy;
								if ((object)CS_0024_003C_003E8__locals38.enemy != null)
								{
									enemy4._003CIsCullable_003Ek__BackingField = false;
									EnemyController enemy5 = CS_0024_003C_003E8__locals38.enemy;
									if ((object)CS_0024_003C_003E8__locals38.enemy != null)
									{
										enemy5._003CIsTeleportOnCull_003Ek__BackingField = false;
										if ((object)CS_0024_003C_003E8__locals38.enemy != null)
										{
											Transform transform = CS_0024_003C_003E8__locals38.enemy.transform;
											if ((object)transform != null)
											{
												bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
												if (base.flipX)
												{
												}
												if ((object)CS_0024_003C_003E8__locals38.enemy != null)
												{
													Transform transform2 = CS_0024_003C_003E8__locals38.enemy.transform;
													if ((object)transform2 != null)
													{
														bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
														Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
														if ((object)CS_0024_003C_003E8__locals38.enemy != null)
														{
															Transform transform3 = CS_0024_003C_003E8__locals38.enemy.transform;
															if ((object)transform3 != null)
															{
																bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret3);
																if ((object)CS_0024_003C_003E8__locals38.enemy != null)
																{
																	Transform target = CS_0024_003C_003E8__locals38.enemy.transform;
																	float duration = default(float);
																	bool snapping = default(bool);
																	sequence = ShortcutExtensions.DOJump(target, (Vector3)(&ret3), 1f, 1, duration, snapping);
																	if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																		bool flag5 = (nint)0 == 0;
																		sequence.stringId = "DefaultGameTweenId";
																		if (!flag5)
																		{
																			object obj2 = sequence + 56;
																			object obj3 = obj2 >> 12;
																			object obj4 = obj3 & 0x1FFFFF;
																			object obj5 = obj4 >> 6;
																			object obj6 = obj4 & 0x3F;
																			nint num2;
																			do
																			{
																				object obj7 = 1 << (int)obj6;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r14_v10+462E0+v1202 @ rdx_v46*8]");
																				object obj8 = 0 | obj7;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r14_v10+462E0+v1202 @ rdx_v46*8]");
																				nint num = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r14_v10+462E0+v1202 @ rdx_v46*8]");
																				if (num == 0)
																				{
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r14_v10+462E0+v1202 @ rdx_v46*8]");
																				num2 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r14_v10+462E0+v1202 @ rdx_v46*8]");
																			}
																			while (num2 != 0);
																			TweenCallback tweenCallback = delegate
																			{
																				//IL_00dd->IL0110: Incompatible stack heights: 1 vs 0
																				Transform enemy7 = (Transform)(object)CS_0024_003C_003E8__locals38.enemy;
																				if ((object)CS_0024_003C_003E8__locals38.enemy != null && ((UnityEngine.Object)enemy7).m_CachedPtr != (IntPtr)0)
																				{
																					Behaviour enemy8 = CS_0024_003C_003E8__locals38.enemy;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v8 (UnityEngine.Behaviour)+28]");
																					if ((nint)0 != 0)
																					{
																						enemy8.enabled = true;
																						EnemyController enemy9 = CS_0024_003C_003E8__locals38.enemy;
																						BaseBody baseBody2 = enemy9.body;
																						baseBody2._enable = true;
																						Transform transform4 = CS_0024_003C_003E8__locals38.enemy.transform;
																						bool flag9 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																						Quaternion value = default(Quaternion);
																						Transform.set_rotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value);
																						EnemyController enemy10 = CS_0024_003C_003E8__locals38.enemy;
																						enemy10._003CIsCullable_003Ek__BackingField = true;
																					}
																				}
																			};
																			signalBus = tweenCallback;
																			goto IL_03bd;
																		}
																	}
																	TweenCallback tweenCallback2 = delegate
																	{
																		//IL_00dd->IL0110: Incompatible stack heights: 1 vs 0
																		Transform enemy7 = (Transform)(object)CS_0024_003C_003E8__locals38.enemy;
																		if ((object)CS_0024_003C_003E8__locals38.enemy != null && ((UnityEngine.Object)enemy7).m_CachedPtr != (IntPtr)0)
																		{
																			Behaviour enemy8 = CS_0024_003C_003E8__locals38.enemy;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v8 (UnityEngine.Behaviour)+28]");
																			if ((nint)0 != 0)
																			{
																				enemy8.enabled = true;
																				EnemyController enemy9 = CS_0024_003C_003E8__locals38.enemy;
																				BaseBody baseBody2 = enemy9.body;
																				baseBody2._enable = true;
																				Transform transform4 = CS_0024_003C_003E8__locals38.enemy.transform;
																				bool flag9 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																				Quaternion value = default(Quaternion);
																				Transform.set_rotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value);
																				EnemyController enemy10 = CS_0024_003C_003E8__locals38.enemy;
																				enemy10._003CIsCullable_003Ek__BackingField = true;
																			}
																		}
																	};
																	bool flag6 = sequence == null;
																	signalBus = tweenCallback2;
																	if (!flag6)
																	{
																		goto IL_03bd;
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
		}
		goto IL_04fb;
		IL_04fb:
		throw new NullReferenceException();
		IL_03bd:
		((EnemyController)(object)sequence)._signalBus = (SignalBus)(object)signalBus;
		EnemyController enemy6 = CS_0024_003C_003E8__locals38.enemy;
		if ((object)CS_0024_003C_003E8__locals38.enemy != null)
		{
			((ArcadeSprite)CS_0024_003C_003E8__locals38.enemy).CheckRenderer();
			bool flag7 = base.flipX;
			if ((object)((ArcadeSprite)enemy6)._spriteRenderer != null)
			{
				((ArcadeSprite)enemy6)._spriteRenderer.flipX = flag7;
				if ((object)CS_0024_003C_003E8__locals38.enemy != null)
				{
					Transform target2 = CS_0024_003C_003E8__locals38.enemy.transform;
					bool flag8 = base.flipX;
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target2, (Vector3)(&ret3), 0.5f, RotateMode.LocalAxisAdd);
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1340 @ rax_v64 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
					return;
				}
			}
		}
		goto IL_04fb;
	}

	public void OnBundleSpawned(CoherenceSync bundle)
	{
		EnemyController component = bundle.GetComponent<EnemyController>();
		HandleBundle(component);
	}

	private void FireSwarm()
	{
		if (!base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			float moreZ = default(float);
			float rndDiv = default(float);
			stage._stageEventManager.GenerateEnemySwarm(10000f, 5, EnemyType.FB_GIGAFLY_SWARM, moreZ, rndDiv);
		}
	}

	public EnemyTaka()
	{
		List<PhaserSprite> explosionSprites = new List<PhaserSprite>();
		_explosionSprites = explosionSprites;
		_readyExplosionSprites = new List<PhaserSprite>();
		base._002Ector();
	}

	private void _003CStartExploding_003Eb__12_0()
	{
		//IL_003f: Expected O, but got I4
		_isExploding = false;
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = true;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = true;
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		base.Die();
	}
}
