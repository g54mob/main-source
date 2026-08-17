using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDoppleganger : EnemyController
{
	public EnemyProjectile _knifePrefab;

	public EnemyProjectile _runetracerPrefab;

	private List<EnemyWeapon> _weapons;

	private CharacterController _targetCharacter;

	private float _weaponUsageCooldown;

	private float _reloadSpeed;

	private CharacterController _characterToCopy;

	private bool _hasStartedDeathAnimation;

	private DopplegangerGate _parentGate;

	private PlatformZoneMovement.JumpInfo _jumpInfo;

	private float _jumpTimer;

	public float WeaponUsageCooldown
	{
		get
		{
			return _weaponUsageCooldown;
		}
		set
		{
			_weaponUsageCooldown = value;
		}
	}

	public float ReloadSpeed
	{
		get
		{
			return _reloadSpeed;
		}
		set
		{
			_reloadSpeed = value;
		}
	}

	public CoherenceSync CharacterToCopy
	{
		get
		{
			CharacterController characterToCopy = _characterToCopy;
			if ((object)_characterToCopy != null && ((UnityEngine.Object)characterToCopy).m_CachedPtr != (IntPtr)0)
			{
				CharacterController characterToCopy2 = _characterToCopy;
				if ((object)_characterToCopy != null)
				{
					return characterToCopy2._coherenceSync;
				}
				return (CoherenceSync)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				CharacterController component = value.GetComponent<CharacterController>();
				_characterToCopy = component;
			}
			else
			{
				_characterToCopy = null;
			}
		}
	}

	public Vector2 SpritePosition
	{
		get
		{
			float2 float5 = base.position;
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			float2 float5 = default(float2);
			base.position = float5;
		}
	}

	public Vector2 CurrentDirectionSynced
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			_currentDirection = value;
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		base._003CIsBoss_003Ek__BackingField = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 12 Invalid \"Jump target not found in method: 0x18769F930\"");
	}

	private void SetTargetToNearestCharacter()
	{
		float2 float5 = base.position;
		GameManager gameManager = _gameManager;
		CoopConfig coopConfig = gameManager.CoopConfig;
		bool inclusionMode = !coopConfig._spawningEnemiesTargetDeadPlayersAlso;
		bool includeFollowers = default(bool);
		CharacterController closestPlayer = _gameManager.GetClosestPlayer(float5, inclusionMode ? PlayerInclusionMode.AlivePreferred : PlayerInclusionMode.AliveOrDead, 3.4028235E+38f, includeFollowers);
		_targetCharacter = closestPlayer;
		CharacterController targetCharacter = _targetCharacter;
		if ((object)_targetCharacter != null && ((UnityEngine.Object)targetCharacter).m_CachedPtr != (IntPtr)0)
		{
			Transform targetTransform = _targetCharacter.transform;
			base._targetTransform = targetTransform;
		}
	}

	public void SetupDoppleganger(CharacterController toCopy, float reloadSpeed, DopplegangerGate gate)
	{
		//IL_001f: Expected O, but got I
		//IL_008f: Expected O, but got I8
		CharacterController characterToCopy = default(CharacterController);
		_characterToCopy = characterToCopy;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		_reloadSpeed = reloadSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		EnemyDoppleganger enemyDoppleganger = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				goto IL_00b8;
			}
			enemyDoppleganger = (EnemyDoppleganger)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v96 @ rax_v6 (should have been resolved before IL gen)");
		_weaponUsageCooldown = 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 91 Invalid \"Jump target not found in method: 0x18769FC50\"");
		goto IL_00b8;
		IL_00b8:
		MissingMethodException ex = new MissingMethodException();
		throw ex;
	}

	public void SetupRemoteDoppleganger(DopplegangerGate gate)
	{
		SetupDoppleganger(_characterToCopy, gate);
	}

	private void SetupDoppleganger(CharacterController toCopy, DopplegangerGate gate)
	{
		//IL_013e: Expected O, but got I
		//IL_0171: Expected O, but got I
		//IL_0434: Expected O, but got I4
		//IL_0434: Expected O, but got I4
		//IL_0278: Expected O, but got I
		//IL_02c8: Expected O, but got I4
		//IL_071a: Expected I4, but got I8
		//IL_071e: Expected F4, but got I4
		//IL_01eb->IL05de: Incompatible stack heights: 1 vs 0
		//IL_023b->IL05de: Incompatible stack heights: 2 vs 0
		//IL_0753->IL05de: Incompatible stack heights: 2 vs 0
		//IL_045c->IL05de: Incompatible stack heights: 2 vs 0
		//IL_064e->IL05de: Incompatible stack heights: 3 vs 0
		//IL_0295->IL05de: Incompatible stack heights: 4 vs 0
		//IL_04bc->IL05de: Incompatible stack heights: 2 vs 0
		//IL_02e5->IL05de: Incompatible stack heights: 5 vs 0
		//IL_04fa->IL05de: Incompatible stack heights: 2 vs 0
		//IL_055e->IL05de: Incompatible stack heights: 2 vs 0
		//IL_0690->IL0729: Incompatible stack heights: 6 vs 2
		DopplegangerGate parentGate = default(DopplegangerGate);
		_parentGate = parentGate;
		object obj;
		if ((object)toCopy != null && (object)toCopy._spriteAnimation != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1873EDE70");
			if ((object)_SpriteAnimation != null)
			{
				_SpriteAnimation.CleanAnimations();
				DopplegangerGate dopplegangerGate = default(DopplegangerGate);
				bool shouldLoop = default(bool);
				bool startRandomFrame = default(bool);
				Action onComplete = default(Action);
				bool autoSetAnimation = default(bool);
				Rect ret;
				Rect ret2;
				if ((object)dopplegangerGate != null && ((MonoBehaviour)dopplegangerGate).m_CancellationTokenSource != null)
				{
					CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)dopplegangerGate).m_CancellationTokenSource;
					if ((nint)cancellationTokenSource._registeredCallbacksLists > 0)
					{
						if ((object)_SpriteAnimation != null)
						{
							_SpriteAnimation.AddAnimation((string)(nint)((UnityEngine.Object)dopplegangerGate).m_CachedPtr, (List<Sprite>)(object)((MonoBehaviour)dopplegangerGate).m_CancellationTokenSource, ((GameMonoBehaviour)dopplegangerGate)._onPauseSent ? 1 : 0, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
							if ((object)_SpriteAnimation != null)
							{
								_SpriteAnimation.SetAnimation((string)(nint)((UnityEngine.Object)dopplegangerGate).m_CachedPtr);
								CancellationTokenSource cancellationTokenSource2 = ((MonoBehaviour)dopplegangerGate).m_CancellationTokenSource;
								if (((MonoBehaviour)dopplegangerGate).m_CancellationTokenSource != null)
								{
									bool flag = (nint)cancellationTokenSource2._registeredCallbacksLists <= 0;
									ManualResetEvent kernelEvent = cancellationTokenSource2._kernelEvent;
									if (cancellationTokenSource2._kernelEvent != null)
									{
										bool flag2 = (nint)((WaitHandle)kernelEvent).waitHandle <= 0;
										CharacterController safeWaitHandle = (CharacterController)(object)((WaitHandle)kernelEvent).safeWaitHandle;
										if (((WaitHandle)kernelEvent).safeWaitHandle != null)
										{
											bool flag3 = ((UnityEngine.Object)safeWaitHandle).m_CachedPtr == (IntPtr)0;
											Sprite.get_rect_Injected(((UnityEngine.Object)safeWaitHandle).m_CachedPtr, out ret);
											DopplegangerGate cancellationTokenSource3 = (DopplegangerGate)(object)((MonoBehaviour)dopplegangerGate).m_CancellationTokenSource;
											if (((MonoBehaviour)dopplegangerGate).m_CancellationTokenSource != null)
											{
												bool flag4 = (nint)((MonoBehaviour)cancellationTokenSource3).m_CancellationTokenSource <= 0;
												DopplegangerGate dopplegangerGate2 = (DopplegangerGate)(nint)((UnityEngine.Object)cancellationTokenSource3).m_CachedPtr;
												if (((UnityEngine.Object)cancellationTokenSource3).m_CachedPtr != (IntPtr)0)
												{
													bool flag5 = (nint)((MonoBehaviour)dopplegangerGate2).m_CancellationTokenSource <= 0;
													DopplegangerGate dopplegangerGate3 = (DopplegangerGate)((GameMonoBehaviour)dopplegangerGate2)._onPauseSent;
													if (((GameMonoBehaviour)dopplegangerGate2)._onPauseSent)
													{
														bool flag6 = ((UnityEngine.Object)dopplegangerGate3).m_CachedPtr == (IntPtr)0;
														Sprite.get_rect_Injected(((UnityEngine.Object)dopplegangerGate3).m_CachedPtr, out ret2);
														object obj2 = default(object);
														obj = obj2;
														goto IL_0729;
													}
												}
											}
										}
									}
								}
							}
						}
						goto IL_05de;
					}
				}
				((ArcadeSprite)toCopy).CheckRenderer();
				if ((object)((ArcadeSprite)toCopy)._spriteRenderer != null)
				{
					Sprite sprite = ((ArcadeSprite)toCopy)._spriteRenderer.sprite;
					List<Sprite> list = new List<Sprite>();
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						if ((object)_SpriteAnimation != null)
						{
							_SpriteAnimation.AddAnimation("walk", list, 1, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
							if ((object)_SpriteAnimation != null)
							{
								_SpriteAnimation.SetAnimation("walk");
								if ((object)sprite != null)
								{
									bool flag7 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
									Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret2);
									bool flag8 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
									Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret);
									object obj3 = default(object);
									obj = obj3;
									goto IL_0729;
								}
							}
						}
					}
				}
			}
		}
		goto IL_05de;
		IL_0729:
		float num = (float)obj * 0.5f;
		if (body != null)
		{
			float radius = (float)obj * 0.5f;
			BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
			BaseBody baseBody2 = body;
			if (body != null)
			{
				baseBody2._enable = true;
				List<EnemyWeapon> weapons = new List<EnemyWeapon>();
				_weapons = weapons;
				EnemyWeapon enemyWeapon = new EnemyWeapon(_knifePrefab);
				if (_weapons != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2E40");
					EnemyWeapon enemyWeapon2 = new EnemyWeapon(_runetracerPrefab);
					if (_weapons != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2E40");
						_hasStartedDeathAnimation = false;
						base._003CIsCullable_003Ek__BackingField = false;
						base._003CIsTeleportOnCull_003Ek__BackingField = false;
						ArcadeSprite arcadeSprite = setAlpha(1f);
						CheckRenderer();
						if ((object)((ArcadeSprite)this)._spriteRenderer != null)
						{
							SpriteTrail component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteTrail>();
							if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
							{
								SpriteTrail spriteTrail = component.setVisible(b: true);
							}
							PlatformZoneMovement.JumpInfo jumpInfo = new PlatformZoneMovement.JumpInfo();
							_jumpInfo = jumpInfo;
							float jumpTimer = UnityEngine.Random.RandomRangeInt(-5, 3);
							_jumpTimer = jumpTimer;
							return;
						}
					}
				}
			}
		}
		goto IL_05de;
		IL_05de:
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		//IL_0048: Invalid comparison between I4 and F4
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Expected O, but got Unknown
		//IL_0559: Expected O, but got I4
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		//IL_043f: Invalid comparison between O and F4
		//IL_046d: Invalid comparison between F4 and O
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		//IL_00ee->IL0537: Incompatible stack heights: 1 vs 0
		//IL_061b->IL061b: Incompatible stack heights: 1 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			if (!_hasStartedDeathAnimation)
			{
				_hasStartedDeathAnimation = true;
				DoDeathAnimation();
			}
			return;
		}
		if (_weapons != null)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * _reloadSpeed;
			if (!(0f < (_weaponUsageCooldown -= num)))
			{
				List<EnemyWeapon> weapons = _weapons;
				object obj = UnityEngine.Random.RandomRangeInt(0, weapons._size);
				List<EnemyWeapon> weapons2 = _weapons;
				bool flag = (nint)obj >= weapons2._size;
				EnemyWeapon[] items = weapons2._items;
				float2 float5 = base.position;
				items[obj].Fire(float5);
				num = UnityEngine.Random.Range(2f, 4f);
				_weaponUsageCooldown = num;
			}
		}
		base.UpdateDepth();
		if (_coherenceSync.HasStateAuthority)
		{
			if (base._003CIsTimeStopped_003Ek__BackingField)
			{
				if (base._003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField)
				{
					if (base._003CConditionalCanMove_003Ek__BackingField)
					{
						base.CalculateCurrentDirection();
						base.CalculateDirectionAndVelocity();
						goto IL_0568;
					}
					return;
				}
				if (base._003CIsTimeStopped_003Ek__BackingField)
				{
					return;
				}
			}
			if ((bool)_targetCharacter)
			{
				CharacterController targetCharacter = _targetCharacter;
				if (!targetCharacter._isDead && !targetCharacter.IsDisconnectedFromOnlinePlay)
				{
					goto IL_0260;
				}
			}
			SetTargetToNearestCharacter();
			if ((bool)_targetCharacter)
			{
				goto IL_0260;
			}
			return;
		}
		goto IL_0568;
		IL_0260:
		base.CalculateCurrentDirection();
		base.CalculateDirectionAndVelocity();
		bool flag2 = 0 < (nint)_currentDirection;
		object obj2 = 0 - _currentDirection;
		bool flag3 = obj2 == null;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		bool flag6 = flag5 & flag4;
		ArcadeSprite arcadeSprite = setFlipX(flag6);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0140");
		object obj3 = default(object);
		float2 float7 = default(float2);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v881 @ rax_v24+10]");
			if ((nint)0 != 0)
			{
				float deltaTime2 = PauseSystem.DeltaTime;
				float jumpTimer = deltaTime2 + _jumpTimer;
				_jumpTimer = jumpTimer;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0140");
				PlatformZoneMovement platformZoneMovement = default(PlatformZoneMovement);
				bool tryingToJump = default(bool);
				float2 float6 = platformZoneMovement.ApplyMovement(this, _jumpInfo, float7, tryingToJump);
				if (_jumpTimer > 5f)
				{
					ResetJumpTimer();
				}
				float2 float8 = base.position;
				float deltaTime3 = PauseSystem.DeltaTime;
				base.position = float7;
			}
		}
		GameManager core = GM.Core;
		if ((object)core._003CHardBounds_003Ek__BackingField == null)
		{
			return;
		}
		Transform transform = base.transform;
		Vector3 vector = transform.position;
		GameManager core2 = GM.Core;
		bool flag7 = (object)core2._003CHardBounds_003Ek__BackingField == null;
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)vector.x))
		{
			object obj4 = float7 + float7;
			float x = vector.x;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
			}
		}
		object obj5 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v37 (VampireSurvivors.Framework.GameManager)+388]");
			object obj6 = 0 + float7;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
			{
			}
		}
		base.position = float7;
		return;
		IL_0568:
		bool flag8 = 0 < (nint)_currentDirection;
		object obj7 = 0 - _currentDirection;
		bool flag9 = obj7 == null;
		bool flag10 = !flag8;
		bool flag11 = !flag9;
		bool flag12 = flag11 & flag10;
		ArcadeSprite arcadeSprite2 = setFlipX(flag12);
	}

	private void ResetJumpTimer()
	{
		//IL_0018: Expected I4, but got I8
		//IL_001c: Expected F4, but got I4
		float jumpTimer = UnityEngine.Random.RandomRangeInt(-5, 3);
		_jumpTimer = jumpTimer;
	}

	private void HandleWeapons()
	{
		//IL_0043: Invalid comparison between I4 and F4
		//IL_0120: Expected O, but got I4
		//IL_00e9->IL0108: Incompatible stack heights: 1 vs 0
		if (_weapons != null)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * _reloadSpeed;
			if (!(0f < (_weaponUsageCooldown -= num)))
			{
				List<EnemyWeapon> weapons = _weapons;
				object obj = UnityEngine.Random.RandomRangeInt(0, weapons._size);
				List<EnemyWeapon> weapons2 = _weapons;
				bool flag = (nint)obj >= weapons2._size;
				EnemyWeapon[] items = weapons2._items;
				float2 float5 = base.position;
				items[obj].Fire(float5);
				float weaponUsageCooldown = UnityEngine.Random.Range(2f, 4f);
				_weaponUsageCooldown = weaponUsageCooldown;
			}
		}
	}

	public override void Disappear()
	{
		base._003CIsDead_003Ek__BackingField = true;
	}

	protected override void Die()
	{
		base._003CIsDead_003Ek__BackingField = true;
	}

	private void DoDeathAnimation()
	{
		//IL_0046: Expected F4, but got I4
		//IL_0075: Expected I, but got O
		//IL_00e7: Expected O, but got I4
		//IL_0123: Expected I, but got O
		//IL_0179: Expected O, but got I4
		//IL_01e6: Expected I4, but got F4
		//IL_01e6: Expected O, but got F4
		//IL_01e6: Expected I4, but got O
		//IL_0267: Expected I, but got O
		//IL_02bd: Expected O, but got I4
		//IL_02e7: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = false;
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.sfx_evilGong, 0f, 10, 0f, num, num2, num3, flag, 1f);
		TweenConfig tweenConfig = default(TweenConfig);
		object[] array = default(object[]);
		if (!base.flipX)
		{
			tweenConfig = new TweenConfig();
			array = new object[1];
		}
		nint num4 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.rotateMode = RotateMode.FastBeyond360;
			tweenConfig.duration = 5000f;
			tweenConfig.angle = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.alpha = (float?)(object)1;
				tweenConfig2.delay = 4000f;
				tweenConfig2.duration = 1000f;
				MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
				Action onComplete = delegate
				{
					CheckRenderer();
					SpriteTrail component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteTrail>();
					SpriteTrail spriteTrail = component.setVisible(b: false);
				};
				VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(4f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
				float2 float5 = base.position;
				DopplegangerGate parentGate = _parentGate;
				if ((object)_parentGate != null && ((UnityEngine.Object)parentGate).m_CachedPtr != (IntPtr)0)
				{
					DopplegangerGate parentGate2 = _parentGate;
					float2 float6 = parentGate2._gatePortal.position;
				}
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				nint num6 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig3.targets = array3;
					tweenConfig3.x = (float?)(object)1;
					tweenConfig3.ease = Ease.InOutQuad;
					tweenConfig3.duration = 5000f;
					tweenConfig3.y = (float?)(object)1;
					TweenCallback onComplete2 = DeathAnimationFinished;
					tweenConfig3.onComplete = onComplete2;
					MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
					return;
				}
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			throw ex2;
		}
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
	}

	private void DeathAnimationFinished()
	{
		GiveReward();
		base.Despawn();
		DopplegangerGate parentGate = _parentGate;
		if ((object)_parentGate != null && ((UnityEngine.Object)parentGate).m_CachedPtr != (IntPtr)0)
		{
			DopplegangerGate parentGate2 = _parentGate;
			bool flag = ((List<object>)(object)parentGate2._liveDopplegangers).Remove((object)this);
			List<EnemyDoppleganger> liveDopplegangers = parentGate2._liveDopplegangers;
			if (liveDopplegangers._size <= 0 && parentGate2._gateState == DopplegangerGate.GateState.Open)
			{
				parentGate2._gateState = DopplegangerGate.GateState.Closing;
				DopplegangerGate._003CRunClosingAnimation_003Ed__32 obj = null;
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = parentGate2;
				Coroutine coroutine = parentGate2.StartCoroutine(obj);
			}
		}
	}

	private void _003CDoDeathAnimation_003Eb__36_0()
	{
		CheckRenderer();
		SpriteTrail component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteTrail>();
		SpriteTrail spriteTrail = component.setVisible(b: false);
	}
}
