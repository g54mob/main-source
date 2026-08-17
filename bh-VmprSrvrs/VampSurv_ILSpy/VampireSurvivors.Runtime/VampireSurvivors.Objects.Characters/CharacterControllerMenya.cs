using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerMenya : CharacterController
{
	private bool _hasSecondAnim;

	private float _mightBonus;

	private float _moveBonus;

	private float _cooldownBonus;

	private float _curseBonus;

	private float _morphDuration = 30000f;

	private int _morphedTimes;

	private int _finalMorphedTimes;

	private SpriteRenderer _sparkSprite;

	private SpriteRenderer _ringSprite;

	private MultiTargetTween _ringTween;

	private MultiTargetTween _sparkTween;

	private SpriteRenderer _burstSprite;

	private SpriteRenderer _darkSprite;

	private MultiTargetTween _darkTween;

	private SpriteAnimation _burstAnim;

	private int[] _thresholds = new int[8] { 500, 1000, 2000, 3000, 5000, 7000, 10000, 15000 };

	private int _finalThreshold = 10000;

	private bool _isMorphed;

	private bool _hasBonusApplied;

	private int _enemiesTs;

	private float _originalMoveSpeed = 1f;

	public override bool NeedsCart => false;

	private void CalculateTreshold()
	{
		int[] thresholds = _thresholds;
		if (_morphedTimes < thresholds.Length)
		{
			int[] thresholds2 = _thresholds;
			int morphedTimes = _morphedTimes;
			_enemiesTs = thresholds2[morphedTimes];
		}
		else
		{
			int enemiesTs = _finalThreshold * _finalMorphedTimes;
			int finalMorphedTimes = _finalMorphedTimes + 1;
			_finalMorphedTimes = finalMorphedTimes;
			_enemiesTs = enemiesTs;
		}
	}

	protected override void OnUpdate()
	{
		//IL_00e0: Expected I8, but got O
		//IL_00ef: Expected I8, but got O
		base.OnUpdate();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CRunEnemies_003Ek__BackingField > _enemiesTs && _coherenceSync.HasStateAuthority && !_isMorphed)
		{
			_isMorphed = true;
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				Morph();
				return;
			}
			Action<long> action = null;
			((CharacterControllerMenya)(object)action).PerformOnlineMorph((long)this);
			((CharacterControllerMenya)(object)action).PerformOnlineMorph((long)this);
			OnlineStageManager onlineStageManager = default(OnlineStageManager);
			long startingOnlineClientFrame = onlineStageManager.GetStartingOnlineClientFrame();
			bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	protected unsafe override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_0156: Expected F4, but got I4
		//IL_02ac: Expected F4, but got I4
		//IL_04d8: Expected I4, but got O
		//IL_0535: Expected O, but got I4
		//IL_03fa: Expected O, but got I
		//IL_0487: Expected I4, but got O
		//IL_04b6: Expected F4, but got I4
		//IL_062b: Expected F4, but got I
		//IL_0648: Expected O, but got I4
		//IL_0648: Expected O, but got Ref
		//IL_0648: Expected O, but got Ref
		//IL_0648: Expected O, but got Ref
		//IL_0a9f: Expected F4, but got I4
		//IL_0aa7: Expected F4, but got O
		//IL_07d1->IL0800: Incompatible stack heights: 1 vs 0
		//IL_0aac->IL0a07: Incompatible stack heights: 2 vs 0
		base.MakeLevelOne();
		_morphedTimes = 0;
		_finalMorphedTimes = 2;
		_isMorphed = false;
		_hasSecondAnim = false;
		_mightBonus = 0f;
		_cooldownBonus = 0f;
		float num = base.PMoveSpeed();
		float originalMoveSpeed = default(float);
		_originalMoveSpeed = originalMoveSpeed;
		CalculateTreshold();
		SpriteRenderer sparkSprite = _sparkSprite;
		if ((object)_sparkSprite != null && ((UnityEngine.Object)sparkSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_015c;
		}
		float2 float5 = base.cachedPosition;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, "vfx", "blurredSharpStar");
		SpriteRenderer component = RenderingExtensions.SetAlpha(spriteRenderer, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(component, 0f);
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		if ((object)spriteRenderer2 != null)
		{
			((Renderer)spriteRenderer2).SetMaterial(material);
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					originalMoveSpeed = renderer.height * 100f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
					int sortingOrder = default(int);
					spriteRenderer2.sortingOrder = sortingOrder;
					_sparkSprite = spriteRenderer2;
					float num2 = 0f;
					goto IL_015c;
				}
			}
		}
		goto IL_0800;
		IL_02b2:
		SpriteRenderer darkSprite = _darkSprite;
		if ((object)_darkSprite != null && ((UnityEngine.Object)darkSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_04bc;
		}
		float2 float6 = base.cachedPosition;
		GameObject gameObject2 = base.gameObject;
		string text = default(string);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.AddSprite(gameObject2, vector, vector, "vfx", text);
		SpriteRenderer component2 = RenderingExtensions.SetAlpha(spriteRenderer3, 0f);
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			if (s_scene2._renderer != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer3 = s_scene3._renderer;
					if (s_scene3._renderer != null)
					{
						float xScale = renderer2.width * 100f;
						float yScale = renderer3.height * 100f;
						SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(component2, xScale, yScale);
						SpriteRenderer s_scene4 = (SpriteRenderer)(object)ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rcx_v108 (UnityEngine.SpriteRenderer)+28]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rcx_v108 (UnityEngine.SpriteRenderer)+28]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1073 @ rax_v124+14]");
								float num3 = 0f - 1f;
								originalMoveSpeed = num3 * 100f;
								SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale((SpriteRenderer)(object)ArcadePhysics.s_scene, xScale, yScale);
								if ((object)spriteRenderer4 != null)
								{
									spriteRenderer4.sortingOrder = (int)spriteRenderer5;
									SpriteRenderer darkSprite2 = RenderingExtensions.SetScrollFactor(spriteRenderer4, 0f);
									_darkSprite = darkSprite2;
									float num2 = 0f;
									goto IL_04bc;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0800;
		IL_015c:
		SpriteRenderer ringSprite = _ringSprite;
		if ((object)_ringSprite != null && ((UnityEngine.Object)ringSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_02b2;
		}
		float2 float7 = base.cachedPosition;
		GameObject gameObject3 = base.gameObject;
		SpriteRenderer spriteRenderer6 = RenderingExtensions.AddSprite(gameObject3, vector, "vfx", "disc");
		SpriteRenderer component3 = RenderingExtensions.SetAlpha(spriteRenderer6, 0f);
		SpriteRenderer spriteRenderer7 = RenderingExtensions.SetScale(component3, 0f);
		Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
		if ((object)spriteRenderer7 != null)
		{
			((Renderer)spriteRenderer7).SetMaterial(material2);
			PhaserScene s_scene5 = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer4 = s_scene5._renderer;
				if (s_scene5._renderer != null)
				{
					originalMoveSpeed = renderer4.height * 100f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
					int sortingOrder2 = default(int);
					spriteRenderer7.sortingOrder = sortingOrder2;
					_ringSprite = spriteRenderer7;
					float num2 = 0f;
					goto IL_02b2;
				}
			}
		}
		goto IL_0800;
		IL_0800:
		throw new NullReferenceException();
		IL_06ba:
		bool flag;
		List<Sprite> animation = SpriteManager.GetAnimation("Burst", 1, 6, "vfx", flag);
		bool flag3 = default(bool);
		if ((object)_burstSprite != null)
		{
			GameObject gameObject4 = _burstSprite.gameObject;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ rdi_v15 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			bool flag2 = (object)gameObject4 == null;
			SpriteAnimation burstAnim = ((!gameObject4.TryGetComponent<SpriteAnimation>(out var component4)) ? gameObject4.AddComponent<SpriteAnimation>() : component4);
			_burstAnim = burstAnim;
			if ((object)_burstAnim != null)
			{
				Action onComplete = default(Action);
				bool autoSetAnimation = default(bool);
				_burstAnim.AddAnimation("enter", animation, 30, flag, flag3, onComplete, autoSetAnimation);
				return;
			}
		}
		goto IL_0800;
		IL_04bc:
		SpriteRenderer burstSprite = _burstSprite;
		flag = (byte)(int)text != 0;
		if ((object)_burstSprite == null || ((UnityEngine.Object)burstSprite).m_CachedPtr == (IntPtr)0)
		{
			float2 float8 = base.cachedPosition;
			GameObject gameObject5 = base.gameObject;
			SpriteRenderer spriteRenderer8 = RenderingExtensions.AddSprite(gameObject5, vector, vector, "vfx", (string)flag);
			SpriteRenderer component5 = RenderingExtensions.SetAlpha(spriteRenderer8, 0f);
			SpriteRenderer spriteRenderer9 = RenderingExtensions.SetScale(component5, 10f);
			Material material3 = MaterialManager.GetMaterial(MaterialType.Vfx);
			if ((object)spriteRenderer9 != null)
			{
				((Renderer)spriteRenderer9).SetMaterial(material3);
				PhaserScene s_scene6 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer5 = s_scene6._renderer;
					if (s_scene6._renderer != null)
					{
						float num5 = renderer5.height * 100f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
						int sortingOrder3 = default(int);
						spriteRenderer9.sortingOrder = sortingOrder3;
						SpriteRenderer spriteRenderer10 = RenderingExtensions.SetScrollFactor(spriteRenderer9, 0f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
						float yScale = 0f;
						object obj2 = default(object);
						object obj3 = default(object);
						float ret = default(float);
						SpriteRenderer burstSprite2 = RenderingExtensions.SetTint(spriteRenderer10, (Color)(&obj2), (Color)(&obj3), (Color)(&ret), (Color)flag, flag3 ? BlendMode.Add : BlendMode.Normal);
						_burstSprite = burstSprite2;
						if ((object)_burstSprite != null)
						{
							Transform transform = _burstSprite.transform;
							if ((object)transform != null)
							{
								bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
								flag = flag;
								bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								float value = default(float);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
								float num2 = 0f;
								originalMoveSpeed = (float)vector;
								goto IL_06ba;
							}
						}
					}
				}
			}
			goto IL_0800;
		}
		goto IL_06ba;
	}

	protected override void OnStop()
	{
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}

	public void PerformOnlineMorph(long startingSimFrame)
	{
		Action onSyncedTimer = Morph;
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void Morph()
	{
		//IL_05db: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_0097: Expected I4, but got F4
		//IL_00c2: Expected I4, but got F4
		//IL_0322: Expected I4, but got F4
		//IL_0688: Expected I, but got O
		//IL_035e: Invalid comparison between I4 and F4
		//IL_036d: Expected F4, but got I4
		//IL_01de: Expected O, but got I
		//IL_01f3: Expected O, but got I
		//IL_0213: Expected O, but got I
		//IL_0254: Expected I4, but got O
		//IL_0254: Expected O, but got F4
		//IL_029b: Expected O, but got I4
		//IL_028d: Expected O, but got I
		//IL_02ae: Expected I4, but got O
		//IL_02d6: Expected O, but got I4
		//IL_02d6: Expected I4, but got O
		//IL_02d6: Expected I4, but got F4
		//IL_04cc: Expected I4, but got F4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Rosary, soundConfig2, 2000f, 1, num);
		PlaySparkle();
		GM.Core.RosaryDamage(showVfx: false, 1.8f, WeaponType.ROSARY, (byte)(int)num != 0);
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.BOCCE, this, removeFromStore: true, (byte)(int)num != 0);
		int morphedTimes = _morphedTimes;
		int[] thresholds = _thresholds;
		_isMorphed = true;
		int enemiesTs;
		if (++_morphedTimes < thresholds.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rcx_v21 (System.Int32[])+24+v205 @ rdx_v10 (System.Int32)*4]");
			enemiesTs = 0;
		}
		else
		{
			int finalMorphedTimes = _finalMorphedTimes + 1;
			_finalMorphedTimes = finalMorphedTimes;
			enemiesTs = _finalMorphedTimes * _finalThreshold;
		}
		_enemiesTs = enemiesTs;
		Vector2 vector = default(Vector2);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num2 = default(int);
		TimerType timerType = default(TimerType);
		if (!_hasSecondAnim)
		{
			GameManager core2 = GM.Core;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core2._dataManager.GetConvertedCharacterData();
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)71);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v80 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v80 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rbx_v19+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rbx_v20+48]");
				string animName = ((string)0).Replace("01.png", "");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rbx_v20+68]");
				int end = (int)(-1);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, end, vector, (string)num, (int)monoBehaviour, (byte)num2 != 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rbx_v20+80]");
				object obj4;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rbx_v20+80]");
					obj4 = 0;
				}
				else
				{
					obj4 = 1;
				}
				if (obj4 != null)
				{
					int fps = obj4 >> 32;
					_spriteAnimation.AddAnimation("walk2", animationFrames, fps, (byte)(int)num != 0, (byte)(int)monoBehaviour != 0, (Action)num2, (byte)timerType != 0);
					_hasSecondAnim = true;
					goto IL_02e6;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
		}
		goto IL_02e6;
		IL_02e6:
		_spriteAnimation.SetAnimation("walk2");
		base._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
		bool flag = _hasBonusApplied;
		bool useRealTime = (byte)(int)num != 0;
		if (!flag)
		{
			_cooldownBonus = -0.2f;
			float num3 = base.PMoveSpeed();
			float num4 = 2f - (float)vector;
			bool flag2 = 0f > num4;
			float moveBonus = 0f;
			if (!flag2)
			{
				moveBonus = num4;
			}
			PlayerModifierStats playerStats = _playerStats;
			_moveBonus = moveBonus;
			_mightBonus = 2f;
			_curseBonus = 0.5f;
			EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + _cooldownBonus;
			playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat3 = playerStats2._003CMoveSpeed_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val + _moveBonus;
			playerStats2._003CMoveSpeed_003Ek__BackingField = eggFloat4;
			PlayerModifierStats playerStats3 = _playerStats;
			EggFloat eggFloat5 = playerStats3._003CPower_003Ek__BackingField;
			float value3 = default(float);
			EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
			value3 = eggFloat5._val + _mightBonus;
			playerStats3._003CPower_003Ek__BackingField = eggFloat6;
			PlayerModifierStats playerStats4 = _playerStats;
			EggFloat eggFloat7 = playerStats4._003CCurse_003Ek__BackingField;
			useRealTime = (byte)(int)num != 0;
			float value4 = default(float);
			EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
			value4 = eggFloat7._val + _curseBonus;
			playerStats4._003CCurse_003Ek__BackingField = eggFloat8;
			_hasBonusApplied = true;
		}
		base.IsInvul = true;
		float num5 = _morphDuration * 0.001f;
		float invincibilityTimer = num5 + base._invincibilityTimer;
		base._invincibilityTimer = invincibilityTimer;
		base.RestoreTint();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterControllerMenya>)+620]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num6 = (nint)this;
		Timer timer = Timers.Register(0.010000001f, onComplete, null, isLooped: false, useRealTime, monoBehaviour, num2, timerType, isOnlineTimer: false, canPause: false);
		Action onComplete2 = Unmorph;
		float duration = _morphDuration * 0.001f;
		Timer timer2 = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, monoBehaviour, num2, timerType, isOnlineTimer: false, canPause: false);
	}

	private void Unmorph()
	{
		//IL_01ad: Invalid comparison between F4 and O
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		if (!_hasBonusApplied)
		{
			goto IL_0299;
		}
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val - _cooldownBonus;
		playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
		PlayerModifierStats playerStats2 = _playerStats;
		EggFloat eggFloat3 = playerStats2._003CMoveSpeed_003Ek__BackingField;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = eggFloat3._val - _moveBonus;
		playerStats2._003CMoveSpeed_003Ek__BackingField = eggFloat4;
		PlayerModifierStats playerStats3 = _playerStats;
		EggFloat eggFloat5 = playerStats3._003CPower_003Ek__BackingField;
		float value3 = default(float);
		EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
		value3 = eggFloat5._val - _mightBonus;
		playerStats3._003CPower_003Ek__BackingField = eggFloat6;
		PlayerModifierStats playerStats4 = _playerStats;
		EggFloat eggFloat7 = playerStats4._003CCurse_003Ek__BackingField;
		float value4 = default(float);
		EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
		value4 = eggFloat7._val - _curseBonus;
		playerStats4._003CCurse_003Ek__BackingField = eggFloat8;
		float num = base.PMoveSpeed();
		float originalMoveSpeed = _originalMoveSpeed;
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)originalMoveSpeed) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			goto IL_0306;
		}
		PlayerModifierStats playerStats5 = _playerStats;
		EggFloat eggFloat9 = playerStats5._003CMoveSpeed_003Ek__BackingField;
		object obj2 = _originalMoveSpeed & -2147483649L;
		float val;
		if ((nint)obj2 != 2139095040)
		{
			object obj3 = _originalMoveSpeed & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875AD769h\"");
				bool flag = _originalMoveSpeed != -1f / 0f;
				val = _originalMoveSpeed;
				if (!flag)
				{
					val = -3.4028235E+38f;
				}
				goto IL_0316;
			}
		}
		val = 3.4028235E+38f;
		goto IL_0316;
		IL_0299:
		_spriteAnimation.SetAnimation("walk");
		base._003CCurrentWalkAnimName_003Ek__BackingField = "walk";
		_isMorphed = false;
		GameManager core = GM.Core;
		core._weaponsFacade.RemoveHiddenWeapon(WeaponType.BOCCE, this);
		return;
		IL_0306:
		_hasBonusApplied = false;
		goto IL_0299;
		IL_0316:
		eggFloat9._val = val;
		goto IL_0306;
	}

	private unsafe void PlaySparkle()
	{
		//IL_00b8: Expected I, but got O
		//IL_0110: Expected I, but got O
		//IL_0174: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_0190: Expected O, but got I4
		//IL_0251: Expected I, but got O
		//IL_02c3: Expected O, but got I4
		//IL_0396: Expected I, but got O
		//IL_03ee: Expected I, but got O
		//IL_0444: Expected O, but got I4
		//IL_0452: Expected O, but got I4
		//IL_0460: Expected O, but got I4
		//IL_047c: Expected O, but got I4
		_burstAnim.SetAnimation("enter");
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_burstSprite, 1f);
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		Transform transform = _ringSprite.transform;
		if ((object)transform != null)
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
		if ((object)_ringSprite != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_ringSprite, 0f);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_ringSprite, 1f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween ringTween = Tweens.Add(tweenConfig);
		_ringTween = ringTween;
		if (_darkTween != null)
		{
			_darkTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_darkSprite != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 100f;
		tweenConfig2.yoyo = true;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_darkSprite, 0f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween darkTween = Tweens.Add(tweenConfig2);
		_darkTween = darkTween;
		if (_sparkTween != null)
		{
			_sparkTween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[2];
		Transform transform2 = _sparkSprite.transform;
		if ((object)transform2 != null)
		{
			nint num4 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sparkSprite != null)
		{
			nint num5 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.scaleX = (float?)(object)1;
		tweenConfig3.scaleY = (float?)(object)1;
		tweenConfig3.alpha = (float?)(object)1;
		tweenConfig3.duration = 200f;
		tweenConfig3.angle = (float?)(object)1;
		TweenCallback onStart3 = delegate
		{
			//IL_0053: Expected O, but got Ref
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_sparkSprite, 0f);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_sparkSprite, 1f);
			Transform transform3 = _sparkSprite.transform;
			object obj6 = default(object);
			transform3.localEulerAngles = (Vector3)(&obj6);
		};
		tweenConfig3.onStart = onStart3;
		TweenCallback onUpdate = delegate
		{
			Transform cachedTransform = base._cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			bool flag2 = (object)_sparkSprite == null;
			Transform transform3 = _sparkSprite.transform;
			bool flag3 = (object)transform3 == null;
			bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
			bool flag5 = (object)_ringSprite == null;
			Transform transform4 = _ringSprite.transform;
			bool flag6 = (object)transform4 == null;
			bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value2);
		};
		tweenConfig3.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 0f);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_sparkSprite, 0f);
		};
		tweenConfig3.onComplete = onComplete;
		MultiTargetTween sparkTween = Tweens.Add(tweenConfig3);
		_sparkTween = sparkTween;
	}

	private void _003CPlaySparkle_003Eb__31_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 1f);
	}

	private void _003CPlaySparkle_003Eb__31_1()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_darkSprite, 0f);
	}

	private unsafe void _003CPlaySparkle_003Eb__31_2()
	{
		//IL_0053: Expected O, but got Ref
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_sparkSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 1f);
		Transform transform = _sparkSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CPlaySparkle_003Eb__31_3()
	{
		Transform cachedTransform = base._cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		bool flag2 = (object)_sparkSprite == null;
		Transform transform = _sparkSprite.transform;
		bool flag3 = (object)transform == null;
		bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag5 = (object)_ringSprite == null;
		Transform transform2 = _ringSprite.transform;
		bool flag6 = (object)transform2 == null;
		bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
	}

	private void _003CPlaySparkle_003Eb__31_4()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 0f);
	}
}
