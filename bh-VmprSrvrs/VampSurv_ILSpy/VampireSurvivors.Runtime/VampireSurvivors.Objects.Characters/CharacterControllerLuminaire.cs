using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerLuminaire : CharacterController
{
	private float _cooldownBonus;

	private float _moveBonus;

	private float _bonusDuration = 15000f;

	private bool _hasBonus;

	private List<PhaserSprite> _doilies;

	private MultiTargetTween _tween1;

	private float _mightBonus;

	private MorphVFX _morphVFX;

	private float _elapsedGFBonusTime;

	private PhaserSprite _fogRays;

	private float _timesRevived;

	private float _originalMoveSpeed = 1f;

	public override bool NeedsCart => false;

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (_hasBonus)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = _timesRevived * 2000f;
			float num2 = deltaTime * 1000f;
			float num3 = num + _bonusDuration;
			float num4 = num2 + _elapsedGFBonusTime;
			float num5 = num3 - 2000f;
			_elapsedGFBonusTime = num4;
			if (!(num4 < num5))
			{
				float num6 = num3 - 2000f;
				float num7 = num4 - num6;
				float num8 = num7 / 1000f;
				float alpha = 1f - num8;
				PhaserSprite phaserSprite = _fogRays.setAlpha(alpha);
			}
			if (!(_elapsedGFBonusTime < _bonusDuration))
			{
				PhaserSprite phaserSprite2 = _fogRays.setVisible(visible: false);
				RemoveBonus();
			}
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		float num = base.PMoveSpeed();
		float originalMoveSpeed = default(float);
		_originalMoveSpeed = originalMoveSpeed;
	}

	public unsafe override void AfterFullInitialization()
	{
		//IL_0073: Expected O, but got Ref
		//IL_00a4: Expected O, but got F4
		//IL_00dc: Expected O, but got I4
		//IL_016f: Expected O, but got Ref
		//IL_0267: Expected O, but got I4
		//IL_026f: Expected F4, but got I4
		//IL_037d: Expected O, but got I4
		base.AfterFullInitialization();
		List<PhaserSprite> doilies = new List<PhaserSprite>();
		_doilies = doilies;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.width * 0.5f;
		float num2 = num;
		int num3 = 1;
		System.ParamsArray paramsArray = default(System.ParamsArray);
		uint num4 = default(uint);
		BlendMode blendMode = default(BlendMode);
		object arg = default(object);
		object obj = default(object);
		bool flag;
		do
		{
			PhaserWorld instance = PhaserWorld.Instance;
			string text = System.Number.FormatInt32(num3, (ReadOnlySpan<char>)(&paramsArray), null);
			string spriteName = "doi0" + text;
			PhaserSprite phaserSprite = instance.AddPhaserSprite((Vector2)num, "vfx", spriteName);
			PhaserSprite phaserSprite2 = RenderingExtensions.SetScrollFactor(phaserSprite, 0f);
			PhaserSprite phaserSprite3 = phaserSprite.setOrigin(0.5f, (float?)(object)0);
			PhaserSprite phaserSprite4 = phaserSprite.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite5 = phaserSprite.setAlpha(0f);
			PhaserSprite phaserSprite6 = phaserSprite.setDepth(10000);
			PhaserSprite phaserSprite7 = phaserSprite.setTint(16777215u, 16777181u, 16777215u, num4, blendMode);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			paramsArray = new System.ParamsArray(arg);
			string text2 = string.FormatHelper((IFormatProvider)null, "Doilie_{0}", (System.ParamsArray)(&obj));
			GameObject gameObject = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject).SetName(text2);
			List<object> doilies2 = (List<object>)(object)_doilies;
			int version = doilies2._version + 1;
			doilies2._version = version;
			object[] items = doilies2._items;
			if (doilies2._size >= items.Length)
			{
				doilies2.AddWithResize((object)phaserSprite);
			}
			else
			{
				int num5 = doilies2._size + 1;
				doilies2._size = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int num6 = num3 + 1;
			flag = num6 <= 9;
			obj = 0;
			num2 = num3;
			num3 = num6;
		}
		while (flag);
		MorphVFX morphVFX = new MorphVFX();
		_morphVFX = morphVFX;
		MorphVFX morphVFX2 = _morphVFX;
		morphVFX2._burstTint = new uint[4] { 4369u, 1118464u, 1114129u, 1118481u };
		MorphVFX morphVFX3 = _morphVFX;
		morphVFX3._sparkName = "s_pfx_rainbow_64";
		MorphVFX morphVFX4 = _morphVFX;
		morphVFX4._diskName = "bubbleSphere";
		_morphVFX.Make();
		PhaserWorld instance2 = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite8 = instance2.AddPhaserSprite(pos, "vfx", "fogRays1");
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float xScale = renderer2.width / 1.5999999f;
		PhaserSprite phaserSprite9 = phaserSprite8.setScale(xScale, (float?)(object)1);
		PhaserSprite phaserSprite10 = phaserSprite9.setBlendMode(BlendMode.Screen);
		PhaserSprite phaserSprite11 = phaserSprite10.setAlpha(0f);
		PhaserSprite component = phaserSprite11.setVisible(visible: false);
		PhaserSprite phaserSprite12 = RenderingExtensions.SetScrollFactor(component, 0f);
		PhaserSprite fogRays = phaserSprite12.setDepth(31763);
		_fogRays = fogRays;
		List<Sprite> animation = SpriteManager.GetAnimation("fogRays", 1, 2, "vfx", (byte)num4 != 0);
		PhaserSprite fogRays2 = _fogRays;
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		fogRays2._spriteAnimation.AddAnimation("loop", animation, 24, (byte)num4 != 0, (byte)blendMode != 0, onComplete, autoSetAnimation);
		PhaserSprite fogRays3 = _fogRays;
		fogRays3._spriteAnimation.SetAnimation("loop");
	}

	public override void LevelUp()
	{
		//IL_015f: Expected O, but got I4
		//IL_0179: Expected O, but got I4
		base.LevelUp();
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		CharacterController activeCharacter = gameSessionData._activeCharacter;
		bool flag = (object)gameSessionData._activeCharacter == null;
		bool flag2 = (object)this == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)this != null)
			{
				if ((object)gameSessionData._activeCharacter != null)
				{
					object obj3 = (object)gameSessionData._activeCharacter - (object)this;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)activeCharacter).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		Action onComplete = RosaryDamage;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public unsafe override void Revive(float percentage = 1f, bool instantRevival = false)
	{
		//IL_0462: Expected O, but got I4
		//IL_01da: Invalid comparison between I4 and F4
		//IL_01e9: Expected F4, but got I4
		//IL_0356: Expected O, but got I4
		//IL_035e: Expected O, but got Ref
		base.Revive(percentage, instantRevival);
		float num = ++_timesRevived;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.5f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, time);
		_morphVFX.PlaySparkle(this);
		_elapsedGFBonusTime = 0f;
		if (_hasBonus)
		{
			return;
		}
		base.IsInvul = true;
		float num2 = _timesRevived * 2000f;
		float num3 = num2 + 4000f;
		float num4 = num3 * 0.001f;
		if (num4 > base._invincibilityTimer)
		{
			base._invincibilityTimer = num4;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = !config._003CFlashingVFXEnabled_003Ek__BackingField;
		bool flag2 = false;
		if (!flag)
		{
			PhaserSprite phaserSprite = _fogRays.setVisible(visible: true);
			PhaserSprite phaserSprite2 = _fogRays.setAlpha(1f);
			flag2 = false;
		}
		bool flag3 = _hasBonus;
		float num5 = 2000f;
		if (!flag3)
		{
			_hasBonus = true;
			_mightBonus = 2f;
			_cooldownBonus = -1f;
			float num6 = base.PMoveSpeed();
			float num7 = 2f - num;
			bool flag4 = 0f > num7;
			float moveBonus = 0f;
			if (!flag4)
			{
				moveBonus = num7;
			}
			_moveBonus = moveBonus;
			PlayerModifierStats playerStats = _playerStats;
			EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
			float value = default(float);
			EggFloat power = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + _mightBonus;
			playerStats.Power = power;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat2 = playerStats2._003CCooldown_003Ek__BackingField;
			float value2 = default(float);
			EggFloat cooldown = new EggFloat(value2, eggFloat2._eggVal);
			value2 = eggFloat2._val + _cooldownBonus;
			playerStats2.Cooldown = cooldown;
			PlayerModifierStats playerStats3 = _playerStats;
			EggFloat eggFloat3 = playerStats3._003CMoveSpeed_003Ek__BackingField;
			float value3 = default(float);
			EggFloat moveSpeed = new EggFloat(value3, eggFloat3._eggVal);
			value3 = eggFloat3._val + _moveBonus;
			playerStats3.MoveSpeed = moveSpeed;
			num5 = eggFloat3._eggVal;
		}
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public void RemoveBonus()
	{
		//IL_016d: Invalid comparison between F4 and O
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		if (!_hasBonus)
		{
			return;
		}
		PlayerModifierStats playerStats = _playerStats;
		_hasBonus = false;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val - _mightBonus;
		playerStats._003CPower_003Ek__BackingField = eggFloat2;
		PlayerModifierStats playerStats2 = _playerStats;
		EggFloat eggFloat3 = playerStats2._003CCooldown_003Ek__BackingField;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = eggFloat3._val - _cooldownBonus;
		playerStats2._003CCooldown_003Ek__BackingField = eggFloat4;
		PlayerModifierStats playerStats3 = _playerStats;
		EggFloat eggFloat5 = playerStats3._003CMoveSpeed_003Ek__BackingField;
		float value3 = default(float);
		EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
		value3 = eggFloat5._val - _moveBonus;
		playerStats3._003CMoveSpeed_003Ek__BackingField = eggFloat6;
		float num = base.PMoveSpeed();
		float originalMoveSpeed = _originalMoveSpeed;
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)originalMoveSpeed) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			return;
		}
		PlayerModifierStats playerStats4 = _playerStats;
		EggFloat eggFloat7 = playerStats4._003CMoveSpeed_003Ek__BackingField;
		object obj2 = _originalMoveSpeed & -2147483649L;
		float val;
		if ((nint)obj2 != 2139095040)
		{
			object obj3 = _originalMoveSpeed & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875A5ED1h\"");
				bool flag = _originalMoveSpeed != -1f / 0f;
				val = _originalMoveSpeed;
				if (!flag)
				{
					val = -3.4028235E+38f;
				}
				goto IL_025a;
			}
		}
		val = 3.4028235E+38f;
		goto IL_025a;
		IL_025a:
		eggFloat7._val = val;
	}

	protected override void OnStop()
	{
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}

	private void RosaryDamage()
	{
		bool setDark = default(bool);
		GM.Core.RosaryDamage(showVfx: false, 0f, WeaponType.ROSARY, setDark);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 45 Invalid \"Jump target not found in method: 0x1875A5F90\"");
		throw new NullReferenceException();
	}

	private void PlayRosaryAnim()
	{
		//IL_0220: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 2f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Rosary, soundConfig, 500f, 2, time);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			return;
		}
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		PhaserSprite[] targets = _doilies.ToArray();
		tweenConfig.targets = targets;
		StaggerConfig staggerConfig = new StaggerConfig();
		staggerConfig.ease = Ease.Linear;
		staggerConfig.start = 0.35f;
		Func<int, float> staggerAlpha = Tweens.Stagger(0.05f, staggerConfig);
		tweenConfig.staggerAlpha = staggerAlpha;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.angle = (float?)(object)1;
		StaggerConfig staggerConfig2 = new StaggerConfig();
		staggerConfig2.ease = Ease.Linear;
		staggerConfig2.start = 2f;
		Func<int, float> staggerScale = Tweens.Stagger(0.25f, staggerConfig2);
		tweenConfig.staggerScale = staggerScale;
		Func<int, float> staggerDelay = Tweens.Stagger(10f);
		tweenConfig.staggerDelay = staggerDelay;
		tweenConfig.duration = 100f;
		tweenConfig.yoyo = true;
		TweenCallback onStop = delegate
		{
			//IL_00bf: Expected O, but got I4
			//IL_00c8: Expected O, but got I4
			//IL_0066: Expected O, but got I4
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			List<PhaserSprite> doilies = _doilies;
			object obj = 0;
			object obj2 = 0;
			while (true)
			{
				if ((nint)obj2 >= doilies._size)
				{
					return;
				}
				List<PhaserSprite> doilies2 = _doilies;
				if ((nint)obj >= doilies2._size)
				{
					break;
				}
				PhaserSprite[] items = doilies2._items;
				PhaserSprite phaserSprite = items[obj].setScale(0f, (float?)(object)0);
				PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
				doilies = _doilies;
				obj++;
				obj2 = obj;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		};
		tweenConfig.onStop = onStop;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween1 = tween;
	}

	private void _003CPlayRosaryAnim_003Eb__22_0()
	{
		//IL_00bf: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		List<PhaserSprite> doilies = _doilies;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < doilies._size)
			{
				List<PhaserSprite> doilies2 = _doilies;
				if ((nint)obj >= doilies2._size)
				{
					break;
				}
				PhaserSprite[] items = doilies2._items;
				PhaserSprite phaserSprite = items[obj].setScale(0f, (float?)(object)0);
				PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
				doilies = _doilies;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}
}
