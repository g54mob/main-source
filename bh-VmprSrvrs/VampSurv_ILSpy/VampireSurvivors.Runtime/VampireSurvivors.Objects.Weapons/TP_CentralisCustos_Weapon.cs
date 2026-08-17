using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects.Weapons;

public class TP_CentralisCustos_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__40_0;

		public static TweenCallback _003C_003E9__40_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDoScreenShake_003Eb__40_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -3f;
		}

		internal void _003CDoScreenShake_003Eb__40_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private SpriteRenderer _AreaRenderer;

	private SpriteRenderer _HeadRenderer;

	private SpriteRenderer _HeadEnrageEffect;

	private Transform _HeadScaler;

	private bool _enableDebugText;

	private TMP_Text _debugText;

	private const float YPosOffset = 0.5f;

	private const float RendererScaleMultiplier = 2f;

	private const float HeadRendererScaleMultiplier = 1f;

	private SpriteAnimation _headAnim;

	private const int AnimFPS = 20;

	private const float BonusStatsDuration = 2500f;

	private const float BonusArmor = 10f;

	private const float BonusRegen = 2f;

	private const float BonusCooldown = 0.1f;

	private const int StatBonusStackLimit = 1;

	private int _numStatBonusStacks;

	private Timer _bonusRetriggerTimer;

	private const float BonusRetriggerTime = 1000f;

	private bool _bonusCanTrigger;

	private Tween _rotateTweenHandle;

	private Tween _headRotateTween;

	private Sequence _fadeTween;

	private MultiTargetTween _headAlphaTween;

	private MultiTargetTween _headScaleXTween;

	private MultiTargetTween _headScaleYTween;

	private MultiTargetTween _headEnrageTween;

	private const float HeadDefaultAlpha = 0.6f;

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(4f > num2);
		float result = 4f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings6", "vfx");
		_AreaRenderer.sprite = sprite;
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_014c: Expected O, but got Ref
		//IL_034d: Expected O, but got I4
		//IL_037c: Expected F4, but got I4
		//IL_0385: Expected O, but got I4
		//IL_0420: Expected I4, but got I8
		//IL_0582: Expected I4, but got I8
		//IL_0590: Expected O, but got I4
		//IL_060c: Expected I, but got O
		//IL_0662: Expected O, but got I4
		//IL_069e: Expected I4, but got I8
		//IL_06e0: Expected O, but got Ref
		//IL_086c: Expected O, but got I4
		//IL_089c: Expected O, but got I4
		//IL_08bc: Expected O, but got I4
		//IL_0909: Expected O, but got I4
		//IL_0909: Expected O, but got I
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_0917: Expected O, but got Unknown
		//IL_0a95: Expected O, but got I
		base.InitWeapon(characterController, weaponType);
		SpriteAnimation headAnim = _headAnim;
		if ((object)_headAnim == null || ((UnityEngine.Object)headAnim).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = _HeadRenderer.gameObject;
			SpriteAnimation headAnim2 = gameObject.AddComponent<SpriteAnimation>();
			_headAnim = headAnim2;
		}
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 25, 28, "ThosePeople", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_headAnim.AddAnimation("enraged", animationFrames, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Cerberus", 33, 36, "ThosePeople", num);
		_headAnim.AddAnimation("idle", animationFrames2, 20, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_headAnim.SetAnimation("idle");
		Transform target = _AreaRenderer.transform;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&obj), 6.0000005f, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_rotateTweenHandle = tweenerCore;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_AreaRenderer, 0.2f);
		Sequence fadeTween = DOTween.Sequence();
		_fadeTween = fadeTween;
		Sequence sequence = TweenSettingsExtensions.SetDelay(_fadeTween, 0.1f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_AreaRenderer, 0.4f, 1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1240 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		bool flag = TweenSettingsExtensions.ValidateAddToSequence(_fadeTween, (Tween)tweenerCore2, false);
		bool flag2 = !flag;
		float num2 = 1f;
		object obj2 = 0;
		if (!flag2)
		{
			Sequence sequence2 = Sequence.DoInsert(_fadeTween, (Tween)tweenerCore2, 0f);
			num2 = 0f;
			obj2 = 0;
		}
		Sequence sequence3 = TweenSettingsExtensions.AppendInterval(_fadeTween, 0.1f);
		Sequence fadeTween2 = _fadeTween;
		if (_fadeTween != null && ((Tween)fadeTween2)._003Cactive_003Ek__BackingField && !((Tween)fadeTween2).creationLocked)
		{
			((Tween)fadeTween2).loops = -1;
			((Tween)fadeTween2).loopType = LoopType.Yoyo;
			if (((ABSSequentiable)fadeTween2).tweenType == TweenType.Tweener)
			{
				((Tween)fadeTween2).fullDuration = 1f / 0f;
			}
		}
		Sequence fadeTween3 = _fadeTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		fadeTween3.stringId = "DefaultGameTweenId";
		StartLoopingAlphaTween();
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_HeadRenderer, 1f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] targets = new object[1];
		Transform transform = _HeadRenderer.transform;
		if ((object)transform != null)
		{
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale((SpriteRenderer)(object)transform, 1f);
			if ((object)spriteRenderer3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = targets;
		tweenConfig.duration = 2000f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		tweenConfig.scaleX = (float?)(object)1;
		MultiTargetTween headScaleXTween = Tweens.Add(tweenConfig);
		_headScaleXTween = headScaleXTween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array = new object[1];
		Transform transform2 = _HeadRenderer.transform;
		if ((object)transform2 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array;
		tweenConfig2.scaleY = (float?)(object)1;
		tweenConfig2.duration = 1000f;
		tweenConfig2.ease = Ease.InOutSine;
		tweenConfig2.yoyo = true;
		tweenConfig2.repeat = -1;
		MultiTargetTween headScaleYTween = Tweens.Add(tweenConfig2);
		_headScaleYTween = headScaleYTween;
		Transform target2 = _HeadRenderer.transform;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DORotate(target2, (Vector3)(&obj), 1.5000001f);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v65 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v65 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v65 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v65 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_rotateTweenHandle = tweenerCore3;
		Action action = OnPlayerDamaged;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2100 @ rbx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rbx_v13 (Il2CppMethodInfo)+38]");
		bool flag3 = (nint)0 != 0;
		Action<object> callback = (Action<object>)num;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rbx_v13 (Il2CppMethodInfo)+38]");
			bool flag4 = (nint)0 != 0;
			callback = (Action<object>)num;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				callback = (Action<object>)num;
			}
		}
		object obj4 = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.CharacterReceivedDamageSignal>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.CharacterReceivedDamageSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v79 (System.Object)+10]");
		Type signalType = default(Type);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		UpdatePosition();
		UpdateRenderersScaleToArea();
		GameObject gameObject2 = _debugText.gameObject;
		gameObject2.SetActive(_enableDebugText);
		_bonusCanTrigger = true;
		_HeadEnrageEffect.enabled = false;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		SpriteRenderer areaRenderer = _AreaRenderer;
		if ((object)_AreaRenderer != null && ((UnityEngine.Object)areaRenderer).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _AreaRenderer.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject2 = _AreaRenderer.gameObject;
				gameObject2.SetActive(value: false);
			}
		}
		SpriteRenderer headRenderer = _HeadRenderer;
		if ((object)_HeadRenderer != null && ((UnityEngine.Object)headRenderer).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject3 = _HeadRenderer.gameObject;
			if ((object)gameObject3 != null && ((UnityEngine.Object)gameObject3).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject4 = _HeadRenderer.gameObject;
				gameObject4.SetActive(value: false);
			}
		}
		if (_rotateTweenHandle != null)
		{
			TweenExtensions.Kill(_rotateTweenHandle);
		}
		if (_fadeTween != null)
		{
			TweenExtensions.Kill(_fadeTween);
		}
		if (_headRotateTween != null)
		{
			TweenExtensions.Kill(_headRotateTween);
		}
		if (_headAlphaTween != null)
		{
			_headAlphaTween.Kill();
		}
		if (_headScaleXTween != null)
		{
			_headScaleXTween.Kill();
		}
		if (_headScaleYTween != null)
		{
			_headScaleYTween.Kill();
		}
		if (_headEnrageTween != null)
		{
			_headEnrageTween.Kill();
		}
		if (_bonusRetriggerTimer != null)
		{
			_bonusRetriggerTimer.Cancel();
		}
	}

	public override void InternalUpdate()
	{
		//IL_0055: Expected O, but got I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected I4, but got Unknown
		base.InternalUpdate();
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		int sortingOrder = depth + obj2;
		_AreaRenderer.sortingOrder = sortingOrder;
		_HeadRenderer.sortingOrder = sortingOrder;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		_AreaRenderer.flipX = characterController._isFlipped;
		_HeadRenderer.flipX = characterController._isFlipped;
		UpdatePosition();
		UpdateRenderersScaleToArea();
		GameObject gameObject = _debugText.gameObject;
		gameObject.SetActive(_enableDebugText);
		float deltaTime = PauseSystem.DeltaTime;
		float num2 = deltaTime * 1000f;
		float num3 = (base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField);
		float num4 = base.PInterval();
		if (!(num3 < deltaTime))
		{
			float num5 = base.PInterval();
			float num6 = base._003CTotalTime_003Ek__BackingField - deltaTime;
			base._003CTotalTime_003Ek__BackingField = num6;
			base.Fire();
		}
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			Transform transform = projectile.transform;
			if ((object)transform == null)
			{
				return (Projectile)(object)new NullReferenceException();
			}
			transform.SetParent(_cachedTransform, worldPositionStays: true);
		}
		return projectile;
	}

	public override float PAmount()
	{
		return 1f;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_AreaRenderer.enabled = visible;
		_HeadRenderer.enabled = visible;
		if (!visible)
		{
			_HeadEnrageEffect.enabled = false;
		}
	}

	private void OnPlayerDamaged()
	{
		if (_numStatBonusStacks < 1 && _bonusCanTrigger)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
			Action action = delegate
			{
				ApplyStatBonuses();
			};
			Action onComplete = delegate
			{
				ApplyStatBonuses(addStats: false);
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v205.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			object obj = default(object);
			float num2 = (float)obj * 2500f;
			float duration = num2 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private void ApplyStatBonuses(bool addStats = true)
	{
		//IL_087d: Expected O, but got I4
		//IL_0886: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected I4, but got Unknown
		//IL_0696: Expected I, but got O
		//IL_06f6: Expected O, but got I4
		//IL_02c2: Expected I, but got O
		//IL_0326: Expected O, but got I4
		//IL_0429: Expected I, but got O
		//IL_0493: Expected I, but got O
		//IL_04e9: Expected O, but got I4
		//IL_0513: Expected O, but got I4
		//IL_05e3: Expected F4, but got I4
		//IL_05e3: Expected F4, but got I4
		//IL_05e3: Expected F4, but got O
		//IL_05e3: Expected O, but got I4
		//IL_08ed: Expected O, but got F4
		//IL_091b: Expected F4, but got I4
		//IL_091b: Expected F4, but got I4
		//IL_091b: Expected F4, but got O
		//IL_091b: Expected O, but got I4
		//IL_0940: Expected F4, but got I4
		//IL_06b9->IL06b9: Incompatible stack heights: 1 vs 0
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		object obj = (addStats ? 1 : 0) * 2;
		object obj2 = obj - 1;
		PlayerModifierStats playerStats = characterController._playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float num = (float)obj2 * 10f;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num;
		playerStats._003CArmor_003Ek__BackingField = eggFloat2;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats2 = characterController2._playerStats;
		EggFloat eggFloat3 = playerStats2._003CRegen_003Ek__BackingField;
		object obj3 = obj2 + obj2;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = (float)obj3 + eggFloat3._val;
		playerStats2._003CRegen_003Ek__BackingField = eggFloat4;
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats3 = characterController3._playerStats;
		EggFloat eggFloat5 = playerStats3._003CCooldown_003Ek__BackingField;
		float num2 = (float)obj2 * 0.1f;
		float value3 = default(float);
		EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
		value3 = eggFloat5._val - num2;
		playerStats3._003CCooldown_003Ek__BackingField = eggFloat6;
		int num3 = (_numStatBonusStacks += obj2);
		bool flag = !addStats;
		float num4 = value3;
		float eggVal = eggFloat5._eggVal;
		bool flag2 = false;
		bool flag4 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num11 = default(int);
		TimerType timerType = default(TimerType);
		if (!flag)
		{
			bool flag3 = num3 != 1;
			num4 = value3;
			eggVal = eggFloat5._eggVal;
			flag2 = false;
			if (!flag3)
			{
				_headAnim.SetAnimation("enraged");
				if (_headAlphaTween != null)
				{
					_headAlphaTween.Kill();
				}
				float num5 = PArea();
				float num6 = default(float);
				if (!(num6 > 3f))
				{
					float num7 = num6 - 1f;
					num6 = num7 / 3f;
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				if ((object)_HeadRenderer != null)
				{
					nint num8 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig.targets = array;
				tweenConfig.duration = 500f;
				tweenConfig.alpha = (float?)(object)1;
				MultiTargetTween headAlphaTween = Tweens.Add(tweenConfig);
				_headAlphaTween = headAlphaTween;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_HeadEnrageEffect, 1f);
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_HeadEnrageEffect, 1f);
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
				_HeadEnrageEffect.flipX = characterController4._isFlipped;
				_HeadEnrageEffect.enabled = true;
				if (_headEnrageTween != null)
				{
					_headEnrageTween.Kill();
				}
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[2];
				if ((object)_HeadEnrageEffect != null)
				{
					nint num9 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Transform transform = _HeadEnrageEffect.transform;
				if ((object)transform != null)
				{
					nint num10 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj6 = default(object);
					if (obj6 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.alpha = (float?)(object)1;
				tweenConfig2.duration = 500f;
				tweenConfig2.ease = Ease.InSine;
				tweenConfig2.scale = (float?)(object)1;
				TweenCallback onComplete = delegate
				{
					_HeadEnrageEffect.enabled = false;
				};
				tweenConfig2.onComplete = onComplete;
				TweenCallback onUpdate = delegate
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController6 = ((Equipment)this)._003COwner_003Ek__BackingField;
					_HeadEnrageEffect.flipX = characterController6._isFlipped;
				};
				tweenConfig2.onUpdate = onUpdate;
				MultiTargetTween headEnrageTween = Tweens.Add(tweenConfig2);
				_headEnrageTween = headEnrageTween;
				VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
				characterController5._classSupport.AddActiveRapidFire(0f, 0f, 2500f);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Scream, 1000f, 1, 0f, (float?)(object)flag4, (float)monoBehaviour, num11, (byte)timerType != 0, 1f);
				object obj7 = UnityEngine.Random.value;
				PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_ShieldFire1, 1000f, 1, 0f, (float?)(object)flag4, (float)monoBehaviour, num11, (byte)timerType != 0, 1f);
				DoScreenShake();
				num6 = 0.9f;
				num4 = 1000f;
				eggVal = 0f;
				flag2 = false;
			}
		}
		if (_numStatBonusStacks == 0)
		{
			_headAnim.SetAnimation("idle");
			if (_headAlphaTween != null)
			{
				_headAlphaTween.Kill();
			}
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_HeadRenderer != null)
			{
				nint num12 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj8 = default(object);
				bool flag5 = obj8 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.duration = 500f;
			tweenConfig3.alpha = (float?)(object)1;
			TweenCallback onComplete2 = delegate
			{
				StartLoopingAlphaTween();
			};
			tweenConfig3.onComplete = onComplete2;
			MultiTargetTween headAlphaTween2 = Tweens.Add(tweenConfig3);
			_headAlphaTween = headAlphaTween2;
			_bonusCanTrigger = false;
			if (_bonusRetriggerTimer != null)
			{
				_bonusRetriggerTimer.Cancel();
			}
			Action onComplete3 = delegate
			{
				_bonusCanTrigger = true;
			};
			Timer bonusRetriggerTimer = Timers.Register(1f, onComplete3, null, isLooped: false, flag4, monoBehaviour, num11, timerType, isOnlineTimer: false, canPause: false);
			_bonusRetriggerTimer = bonusRetriggerTimer;
		}
		string text3;
		if (!addStats)
		{
			string text = _debugText.text;
			string text2 = _debugText.text;
			int startIndex = text2._stringLength - 1;
			text3 = text.Remove(startIndex);
		}
		else
		{
			string text4 = _debugText.text;
			text3 = text4 + "I";
		}
		_debugText.text = text3;
	}

	private void StartLoopingAlphaTween()
	{
		//IL_0091: Expected I, but got O
		//IL_0115: Expected I4, but got I8
		//IL_0131: Expected O, but got I4
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_HeadRenderer, 0.6f);
		if (_headAlphaTween != null)
		{
			_headAlphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_HeadRenderer != null)
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
		tweenConfig.duration = 2000f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		tweenConfig.repeatDelay = 1000f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween headAlphaTween = Tweens.Add(tweenConfig);
		_headAlphaTween = headAlphaTween;
	}

	private void DoScreenShake()
	{
		//IL_00b3: Expected I, but got O
		//IL_0133: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
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
		tweenConfig.duration = 24f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 12;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__40_0;
		if (_003C_003Ec._003C_003E9__40_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__40_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -3f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__40_1;
		if (_003C_003Ec._003C_003E9__40_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__40_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void UpdatePosition()
	{
		//IL_0005: Expected I, but got O
		nint num = (nint)this;
		float num2 = PArea();
		object obj = default(object);
		if (0 <= (nint)obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm6,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void UpdateRenderersScaleToArea()
	{
		Transform transform = _AreaRenderer.transform;
		float num = PArea();
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = _HeadScaler.transform;
		float num2 = PArea();
		bool flag2 = (object)transform2 == null;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
	}

	private void UpdateDebugTextVisibility()
	{
		GameObject gameObject = _debugText.gameObject;
		gameObject.SetActive(_enableDebugText);
	}

	private float AlphaFromScale(float weaponArea, float maxScale, float minAlpha)
	{
		if (!(weaponArea > maxScale))
		{
			float num = weaponArea - 1f;
			float num2 = 1f - minAlpha;
			float num3 = num / maxScale;
			float num4 = 1f - num3;
			float num5 = num4 * num2;
			return num5 + minAlpha;
		}
		return minAlpha;
	}

	private void _003COnPlayerDamaged_003Eb__37_0()
	{
		ApplyStatBonuses();
	}

	private void _003COnPlayerDamaged_003Eb__37_1()
	{
		ApplyStatBonuses(addStats: false);
	}

	private void _003CApplyStatBonuses_003Eb__38_1()
	{
		_HeadEnrageEffect.enabled = false;
	}

	private void _003CApplyStatBonuses_003Eb__38_2()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		_HeadEnrageEffect.flipX = characterController._isFlipped;
	}

	private void _003CApplyStatBonuses_003Eb__38_3()
	{
		StartLoopingAlphaTween();
	}

	private void _003CApplyStatBonuses_003Eb__38_0()
	{
		_bonusCanTrigger = true;
	}
}
