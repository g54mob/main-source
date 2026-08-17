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

public class TP_StarFlail2_Projectile : Projectile
{
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
		Sprite sprite = SpriteManager.GetSprite("TP_MaceMoon_Projectile", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_00e2: Expected I4, but got I8
		//IL_0144: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0345: Expected I, but got O
		//IL_03a8: Expected O, but got I4
		//IL_0443: Expected I, but got O
		//IL_0582: Expected O, but got F4
		//IL_05ad: Expected O, but got I4
		//IL_0518: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
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
		float num3 = (_attackDistance = num * 0.39999998f);
		ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)1);
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		ArcadeSprite arcadeSprite3 = setFlipX(characterController3._isFlipped);
		float num4 = weapon.PArea();
		float num5 = weapon.PArea();
		float xScale = num3 * 0.5f;
		ArcadeSprite arcadeSprite4 = setScale(xScale, (float?)(object)1);
		if ((object)GM.Core == null)
		{
			throw new NullReferenceException();
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num6 = renderer.pixelHeight - 1;
		ArcadeSprite arcadeSprite5 = setDepth(num6);
		_multiplier = 0f;
		updateAttackAngle(_angleTime = (float)_flipNum * ((float)Math.PI / 2f));
		if (_swingTimer != null)
		{
			_swingTimer.Cancel();
		}
		Action onComplete = LandHit;
		float num7 = _swingTime * 0.001f;
		bool flag2 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer swingTimer = Timers.Register(num7, onComplete, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_swingTimer = swingTimer;
		ArcadeSprite arcadeSprite6 = setAlpha(1f);
		_isMoving = true;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num8 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float num9 = weapon.PArea();
			tweenConfig.scaleX = (float?)(object)1;
			tweenConfig.duration = _swingTime;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			if (_starCreationTimer != null)
			{
				_starCreationTimer.Cancel();
			}
			float num10 = _weapon.PAmount();
			Action onComplete2 = CreateStar;
			Weapon weapon3 = _weapon;
			nint num11 = (nint)weapon3;
			float num12 = weapon3.PAmount();
			float num13 = num7 - 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			float num14 = num7 + 1f;
			float num15 = _swingTime / num14;
			float num16 = num15 * 0.001f;
			Timer starCreationTimer = Timers.Register(num16, onComplete2, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_starCreationTimer = starCreationTimer;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.9f;
			object obj3 = UnityEngine.Random.value;
			float detune = num16 * -300f;
			soundConfig.Detune = detune;
			soundConfig.Volume = (float?)(object)1;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_StarFlail, soundConfig, 200f, 10, flag2 ? 1 : 0);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InternalUpdate()
	{
		if (_isMoving)
		{
			float num = _multiplier + 4f;
			bool flag = !(5f > num);
			float multiplier = 5f;
			if (!flag)
			{
				multiplier = num;
			}
			_multiplier = multiplier;
			float deltaTime = PauseSystem.DeltaTime;
			float num2 = deltaTime * 4f;
			float num3 = num2 * _multiplier;
			updateAttackAngle(_angleTime = num3 + _angleTime);
		}
	}

	private unsafe void updateAttackAngle(float attackAngle)
	{
		Transform cachedTransform = _cachedTransform;
		float2 euler = default(float2);
		Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion _);
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
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
		nint num = (nint)typeof(TP_StarFlail2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail2_Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v9+FFFFFFF8+v89 @ rax_v8*8]");
			if (0 == (nint)typeof(TP_StarFlail2_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_StarFlail2_Weapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v9+FFFFFFF8+v211 @ rcx_v5*8]");
				object obj4 = 0 - typeof(TP_StarFlail2_Weapon);
				bool flag = obj4 == null;
				bool flag2 = !flag;
				TP_StarFlail2_Weapon tP_StarFlail2_Weapon = null;
				if (!flag2)
				{
					tP_StarFlail2_Weapon = (TP_StarFlail2_Weapon)weapon2;
				}
				float2 pos = default(float2);
				float area = default(float);
				TP_StarFlail2_Blade_Projectile tP_StarFlail2_Blade_Projectile = tP_StarFlail2_Weapon.SpawnBladeAt(pos, 0, 1, area);
				if ((object)tP_StarFlail2_Blade_Projectile != null && ((UnityEngine.Object)tP_StarFlail2_Blade_Projectile).m_CachedPtr != (IntPtr)0)
				{
					tP_StarFlail2_Blade_Projectile.ManualIntProjectile(_angleTime, _isFlipped);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_swingTimer != null)
		{
			_swingTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_starCreationTimer != null)
		{
			_starCreationTimer.Cancel();
		}
		base.Despawn();
	}

	private void _003CLandHit_003Eb__17_0()
	{
		Despawn();
	}
}
