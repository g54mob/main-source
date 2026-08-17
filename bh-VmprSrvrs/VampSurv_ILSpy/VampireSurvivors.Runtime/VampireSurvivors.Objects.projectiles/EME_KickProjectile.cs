using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KickProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00a4: Expected I, but got O
		//IL_0151: Expected O, but got I4
		//IL_01fe: Expected I, but got O
		//IL_028e: Expected O, but got I4
		//IL_02a9: Expected I, but got O
		//IL_03b9: Expected I4, but got I8
		//IL_06d0: Expected O, but got I4
		//IL_03e9: Expected O, but got I4
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Expected O, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected I4, but got Unknown
		//IL_0502: Expected O, but got I4
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Expected I4, but got Unknown
		//IL_0556: Expected O, but got I4
		//IL_00c7->IL00c7: Incompatible stack heights: 3 vs 2
		//IL_0221->IL0221: Incompatible stack heights: 6 vs 5
		//IL_030e->IL030e: Incompatible stack heights: 7 vs 4
		int index2 = default(int);
		base.InitProjectile(pool, weapon, index2);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		bool flag2 = array == null;
		if ((object)_cachedTransform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			bool flag3 = obj == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag4 = tweenConfig == null;
		tweenConfig.targets = array;
		bool flag5 = (object)_weapon == null;
		float num2 = _weapon.PArea();
		tweenConfig.duration = 100f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		if (_alphaTween != null)
		{
			_alphaTween.Restart();
		}
		else
		{
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			bool flag6 = array2 == null;
			if ((object)_renderer != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				bool flag7 = obj2 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			bool flag8 = tweenConfig2 == null;
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 100f;
			tweenConfig2.ease = Ease.Linear;
			tweenConfig2.delay = 100f;
			tweenConfig2.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1402 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KickProjectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num4 = (nint)this;
			tweenConfig2.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
			bool flag9 = multiTargetTween == null;
			MultiTargetTween alphaTween = multiTargetTween.SetAutoKill(autoKill: false);
			_alphaTween = alphaTween;
		}
		Weapon weapon2 = _weapon;
		bool flag10 = (object)_weapon == null;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		bool flag11 = (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null;
		Transform cachedTransform = _cachedTransform;
		bool flag12 = (object)_cachedTransform == null;
		bool flag13 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out value);
		if (~(characterController._isFlipped ? 1u : 0u) == 0)
		{
		}
		Transform cachedTransform2 = _cachedTransform;
		bool flag14 = (object)_cachedTransform == null;
		bool flag15 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value2);
		bool flag16 = (object)_renderer == null;
		int num5 = (int)(_indexInWeapon & 0x80000001L);
		if ((nint)_renderer < 0)
		{
			object obj3 = num5 - 1;
			object obj4 = obj3 | -2;
			num5 = obj4 + 1;
		}
		object obj5 = num5 - 1;
		bool flag17 = obj5 == null;
		_renderer.flipY = flag17;
		bool flag18 = (object)_renderer == null;
		_renderer.flipX = characterController._isFlipped;
		Weapon weapon3 = _weapon;
		bool flag19 = (object)_weapon == null;
		bool flag20 = (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null;
		int num6 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.Depth;
		bool flag21 = (object)GM.Core == null;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		bool flag22 = ArcadePhysics.s_scene == null;
		PhaserScene.Renderer renderer = s_scene._renderer;
		bool flag23 = s_scene._renderer == null;
		bool flag24 = (object)_renderer == null;
		int num7 = renderer.pixelHeight >> 31;
		object obj6 = renderer.pixelHeight - num7;
		object obj7 = obj6 >> 1;
		int sortingOrder = obj7 + num6;
		_renderer.sortingOrder = sortingOrder;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Rate = 1f,
			Volume = (float?)(object)1
		};
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_Punch1, soundConfig, 0f, 10, time);
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Pause();
		}
		base.Despawn();
	}
}
