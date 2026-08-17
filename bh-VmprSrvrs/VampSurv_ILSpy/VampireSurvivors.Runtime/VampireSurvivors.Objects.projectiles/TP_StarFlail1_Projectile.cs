using System;
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
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_StarFlail1_Projectile : Projectile
{
	private TrailRenderer _afterImageTrail;

	private float _angleTime;

	private Timer _swingTimer;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _scaleTween;

	private float _multiplier;

	private Projectile _swipeBody;

	private float2 _playerOffset;

	private int _flipNum;

	private bool _isFlipped;

	private bool _isMoving;

	private float _attackDistance;

	private Timer _starCreationTimer;

	private float _swingTime = 300f;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_MaceGreen_Projectile", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_00e2: Expected I4, but got I8
		//IL_0142: Expected I, but got O
		//IL_014a: Expected I, but got O
		//IL_015a: Expected O, but got I
		//IL_0196: Expected O, but got I
		//IL_01d3: Expected O, but got I
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_0247: Expected O, but got I4
		//IL_02ae: Expected O, but got I4
		//IL_044d: Expected I, but got O
		//IL_04b0: Expected O, but got I4
		//IL_054b: Expected I, but got O
		//IL_06a6: Expected O, but got F4
		//IL_06d1: Expected O, but got I4
		//IL_0620: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(0f, (float?)(object)0, (float?)(object)0);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		Weapon weapon2 = _weapon;
		ArcadeSprite arcadeSprite = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		((ArcadeSprite)((Equipment)weapon2)._003COwner_003Ek__BackingField).CheckRenderer();
		Vector2 vector = arcadeSprite._spriteRenderer.size;
		object obj = default(object);
		float num = (float)obj * 0.5f;
		_playerOffset = (float2)0;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		bool flag = characterController._isFlipped;
		int flipNum = -1;
		if (!flag)
		{
			flipNum = 1;
		}
		_flipNum = flipNum;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		_isFlipped = characterController2._isFlipped;
		float num2 = weapon.PArea();
		float attackDistance = num * 0.39999998f;
		_attackDistance = attackDistance;
		nint num3 = (nint)typeof(TP_StarFlail1_Weapon);
		nint num4 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail1_Weapon>)+130]");
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v23+FFFFFFF8+v190 @ rax_v22*8]");
			if (0 == (nint)typeof(TP_StarFlail1_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail1_Weapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v23+FFFFFFF8+v658 @ rcx_v15*8]");
				object obj5 = 0 - typeof(TP_StarFlail1_Weapon);
				bool flag2 = obj5 == null;
				bool flag3 = !flag2;
				TP_StarFlail1_Weapon tP_StarFlail1_Weapon = null;
				if (!flag3)
				{
					tP_StarFlail1_Weapon = (TP_StarFlail1_Weapon)weapon;
				}
				Projectile swipeBody = tP_StarFlail1_Weapon.CreateSwipeBodyProjectile();
				_swipeBody = swipeBody;
				float2 float5 = default(float2);
				_swipeBody.position = float5;
				ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)1);
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				ArcadeSprite arcadeSprite3 = setFlipX(characterController3._isFlipped);
				float num6 = weapon.PArea();
				float num7 = weapon.PArea();
				float xScale = (float)float5 * 0.5f;
				ArcadeSprite arcadeSprite4 = setScale(xScale, (float?)(object)1);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer = s_scene._renderer;
					int num8 = renderer.pixelHeight - 1;
					ArcadeSprite arcadeSprite5 = setDepth(num8);
					_multiplier = 0f;
					updateAttackAngle(_angleTime = (float)_flipNum * ((float)Math.PI / 2f));
					if (_swingTimer != null)
					{
						_swingTimer.Cancel();
					}
					Action onComplete = LandHit;
					float num9 = _swingTime * 0.001f;
					bool flag4 = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer swingTimer = Timers.Register(num9, onComplete, null, isLooped: false, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_swingTimer = swingTimer;
					ArcadeSprite arcadeSprite6 = setAlpha(1f);
					_isMoving = true;
					if (_scaleTween != null)
					{
						_scaleTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					nint num10 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj6 = default(object);
					if (obj6 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig.targets = array;
						float num11 = weapon.PArea();
						tweenConfig.scaleX = (float?)(object)1;
						tweenConfig.duration = _swingTime;
						MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
						_scaleTween = scaleTween;
						if (_starCreationTimer != null)
						{
							_starCreationTimer.Cancel();
						}
						float num12 = _weapon.PAmount();
						Action onComplete2 = CreateStar;
						Weapon weapon3 = _weapon;
						nint num13 = (nint)weapon3;
						float num14 = weapon3.PAmount();
						float num15 = num9 - 1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
						float num16 = num9 + 1f;
						float num17 = _swingTime / num16;
						float num18 = num17 * 0.001f;
						Timer starCreationTimer = Timers.Register(num18, onComplete2, null, isLooped: false, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_starCreationTimer = starCreationTimer;
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Rate = 0.9f;
						object obj7 = UnityEngine.Random.value;
						float detune = num18 * -300f;
						soundConfig.Detune = detune;
						soundConfig.Volume = (float?)(object)1;
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_StarFlail, soundConfig, 200f, 10, flag4 ? 1 : 0);
						return;
					}
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		if (_isMoving)
		{
			float num = _multiplier + 2f;
			bool flag = !(5f > num);
			float multiplier = 5f;
			if (!flag)
			{
				multiplier = num;
			}
			_multiplier = multiplier;
			float deltaTime = PauseSystem.DeltaTime;
			float num2 = deltaTime + deltaTime;
			float num3 = num2 * _multiplier;
			updateAttackAngle(_angleTime = num3 + _angleTime);
		}
	}

	private unsafe void updateAttackAngle(float attackAngle)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		float num = attackAngle * -57.29578f;
		Transform cachedTransform = _cachedTransform;
		float num2 = num * (float)_flipNum;
		float num3 = num2 + 90f;
		float num4 = num3 * ((float)Math.PI / 180f);
		float2 euler = default(float2);
		Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion _);
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_StarFlail1_Projectile)+10C]");
		object obj2 = default(object);
		object obj = obj2 + 0;
		float2 float6 = default(float2);
		base.position = float6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 float7 = base.position;
		bool flag2 = (object)_swipeBody == null;
		_swipeBody.position = float6;
	}

	private void LandHit()
	{
		//IL_005e: Expected I, but got O
		//IL_00d0: Expected O, but got I4
		bool flag = _alphaTween == null;
		_isMoving = false;
		if (!flag)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_renderer != null)
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
		tweenConfig.duration = 100f;
		tweenConfig.delay = 250f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	private void CreateStar()
	{
		//IL_0034: Expected I, but got O
		//IL_003c: Expected I, but got O
		//IL_004c: Expected O, but got I
		//IL_0088: Expected O, but got I
		//IL_00c5: Expected O, but got I
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Weapon weapon2 = _weapon;
		nint num = (nint)typeof(TP_StarFlail1_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail1_Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v9+FFFFFFF8+v89 @ rax_v8*8]");
			if (0 == (nint)typeof(TP_StarFlail1_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail1_Weapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v9+FFFFFFF8+v211 @ rcx_v5*8]");
				object obj4 = 0 - typeof(TP_StarFlail1_Weapon);
				bool flag = obj4 == null;
				bool flag2 = !flag;
				TP_StarFlail1_Weapon tP_StarFlail1_Weapon = null;
				if (!flag2)
				{
					tP_StarFlail1_Weapon = (TP_StarFlail1_Weapon)weapon2;
				}
				float2 pos = default(float2);
				float area = default(float);
				TP_StarFlail1_Blade_Projectile tP_StarFlail1_Blade_Projectile = tP_StarFlail1_Weapon.SpawnBladeAt(pos, 0, 1, area);
				if ((object)tP_StarFlail1_Blade_Projectile != null && ((UnityEngine.Object)tP_StarFlail1_Blade_Projectile).m_CachedPtr != (IntPtr)0)
				{
					tP_StarFlail1_Blade_Projectile.ManualIntProjectile(_angleTime, _isFlipped);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_starCreationTimer != null)
		{
			_starCreationTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_swingTimer != null)
		{
			_swingTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		Projectile swipeBody = _swipeBody;
		if ((object)_swipeBody != null && ((UnityEngine.Object)swipeBody).m_CachedPtr != (IntPtr)0)
		{
			_swipeBody.Despawn();
			_swipeBody = null;
		}
		base.Despawn();
	}

	private void _003CLandHit_003Eb__18_0()
	{
		Despawn();
	}
}
