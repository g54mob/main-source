using System;
using System.Threading;
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
using Zenject;

namespace VampireSurvivors.Objects.Projectiles;

public class WhipProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00a4: Expected I, but got O
		//IL_0151: Expected O, but got I4
		//IL_0251: Expected I, but got O
		//IL_01fe: Expected I, but got O
		//IL_0362: Expected I4, but got I8
		//IL_0264: Expected O, but got I4
		//IL_0299: Expected I, but got O
		//IL_03f9: Expected O, but got I4
		//IL_0410: Expected O, but got I4
		//IL_0395: Expected O, but got I4
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected O, but got Unknown
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected I4, but got Unknown
		//IL_03c4: Expected O, but got I4
		//IL_03e6: Expected O, but got I4
		//IL_0449: Expected I4, but got I8
		//IL_07b0: Expected O, but got I4
		//IL_04a9: Expected I4, but got O
		//IL_0479: Expected O, but got I4
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Expected O, but got Unknown
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Expected I4, but got Unknown
		//IL_057b: Expected O, but got I4
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Expected O, but got Unknown
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Expected I4, but got Unknown
		//IL_05e1: Expected O, but got I4
		//IL_00c7->IL00c7: Incompatible stack heights: 3 vs 2
		//IL_0221->IL0221: Incompatible stack heights: 6 vs 5
		//IL_02fe->IL02fe: Incompatible stack heights: 7 vs 4
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
			((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
			((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1120403456;
			((GameMonoBehaviour)(object)tweenConfig2)._onPauseSent = true;
			_ = 1120403456;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1411 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.WhipProjectile>)+370]");
			TweenCallback signalBus = new TweenCallback(this, (IntPtr)0);
			nint num4 = (nint)this;
			((Equipment)(object)tweenConfig2)._signalBus = (SignalBus)(object)signalBus;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
			bool flag9 = multiTargetTween == null;
			MultiTargetTween alphaTween = multiTargetTween.SetAutoKill(autoKill: false);
			_alphaTween = alphaTween;
		}
		Weapon weapon2 = _weapon;
		bool flag10 = (object)_weapon == null;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		bool flag11 = (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null;
		int num5 = (int)(_indexInWeapon & 0x80000001L);
		if ((nint)((Equipment)weapon2)._003COwner_003Ek__BackingField < 0)
		{
			object obj3 = num5 - 1;
			object obj4 = obj3 | -2;
			num5 = obj4 + 1;
		}
		Transform transform2;
		if (characterController._isFlipped)
		{
			object obj5 = num5 - 1;
			bool flag12 = obj5 == null;
			bool flag13 = !flag12;
			transform2 = (Transform)flag13;
		}
		else
		{
			object obj6 = num5 - 1;
			bool flag14 = obj6 == null;
			transform2 = (Transform)flag14;
		}
		Weapon cachedTransform = (Weapon)(object)_cachedTransform;
		bool flag15 = (object)_cachedTransform == null;
		bool flag16 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out value);
		if ((object)transform2 != null)
		{
		}
		Weapon cachedTransform2 = (Weapon)(object)_cachedTransform;
		bool flag17 = (object)_cachedTransform == null;
		bool flag18 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value2);
		bool flag19 = (object)_renderer == null;
		int num6 = (int)(_indexInWeapon & 0x80000001L);
		if ((nint)_renderer < 0)
		{
			object obj7 = num6 - 1;
			object obj8 = obj7 | -2;
			num6 = obj8 + 1;
		}
		object obj9 = num6 - 1;
		bool flag20 = obj9 == null;
		_renderer.flipY = flag20;
		bool flag21 = (object)_renderer == null;
		_renderer.flipX = (byte)(int)transform2 != 0;
		Weapon weapon3 = _weapon;
		bool flag22 = (object)_weapon == null;
		bool flag23 = (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null;
		int num7 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.Depth;
		bool flag24 = (object)GM.Core == null;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		bool flag25 = ArcadePhysics.s_scene == null;
		PhaserScene.Renderer renderer = s_scene._renderer;
		bool flag26 = s_scene._renderer == null;
		bool flag27 = (object)_renderer == null;
		object obj10 = renderer.pixelHeight >> 31;
		object obj11 = renderer.pixelHeight - obj10;
		object obj12 = obj11 >> 1;
		int sortingOrder = obj12 + num7;
		_renderer.sortingOrder = sortingOrder;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 2f;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Whip, soundConfig, 0f, 10, time);
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
