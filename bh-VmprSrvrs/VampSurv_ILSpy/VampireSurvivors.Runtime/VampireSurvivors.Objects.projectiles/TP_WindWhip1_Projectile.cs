using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_WindWhip1_Projectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private float hOffset;

	private List<float> vOffsets;

	private uint[] _colors;

	private readonly BlendMode[] _blendModes;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Slash01", "ThosePeople");
		_renderer.sprite = sprite;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_renderer, 13434828u);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0157: Expected O, but got I4
		//IL_012f: Expected O, but got I4
		//IL_017c: Expected I4, but got O
		//IL_016e: Expected O, but got I4
		//IL_0292: Expected I, but got O
		//IL_0391: Expected I, but got O
		//IL_0421: Expected O, but got I4
		//IL_043c: Expected I, but got O
		//IL_0877: Expected O, but got F4
		//IL_04b9: Expected I4, but got I8
		//IL_0548: Expected O, but got I4
		//IL_04ec: Expected O, but got I4
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Expected O, but got Unknown
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Expected I4, but got Unknown
		//IL_051b: Expected O, but got I4
		//IL_0592: Expected I4, but got I8
		//IL_0995: Expected O, but got I4
		//IL_05c2: Expected O, but got I4
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Expected O, but got Unknown
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Expected I4, but got Unknown
		//IL_06d6: Expected O, but got I4
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Expected I4, but got Unknown
		//IL_09fa: Expected O, but got F4
		//IL_073a: Expected O, but got Ref
		//IL_0764: Expected O, but got I4
		//IL_083c->IL07b7: Incompatible stack heights: 1 vs 0
		//IL_007b->IL07b7: Incompatible stack heights: 1 vs 0
		//IL_00ee->IL07b7: Incompatible stack heights: 2 vs 0
		//IL_019a->IL07b7: Incompatible stack heights: 3 vs 0
		//IL_0262->IL0262: Incompatible stack heights: 5 vs 4
		//IL_03b4->IL03b4: Incompatible stack heights: 8 vs 7
		base.InitProjectile(pool, weapon, index);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 0.65f);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 ret = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
			if ((object)_renderer != null)
			{
				_renderer.enabled = true;
				Extensions.Shuffle(_colors);
				uint[] colors = _colors;
				if (_colors != null)
				{
					int num = _indexInWeapon % colors.Length;
					bool flag2 = num >= colors.Length;
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_renderer, colors[num]);
					BlendMode[] blendModes = _blendModes;
					if (_blendModes != null)
					{
						int num2 = _indexInWeapon % blendModes.Length;
						bool flag3 = num2 >= blendModes.Length;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rsi_v17 (VampireSurvivors.Framework.Particles.BlendMode[])+20+v618 @ rdx_v35 (System.Int32)*4]");
						Transform transform2;
						if ((nint)0 == 1)
						{
							transform2 = (Transform)4;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rsi_v17 (VampireSurvivors.Framework.Particles.BlendMode[])+20+v618 @ rdx_v35 (System.Int32)*4]");
							bool flag4 = (nint)0 != 2;
							transform2 = (Transform)8;
							if (!flag4)
							{
								transform2 = (Transform)18;
							}
						}
						Material material = MaterialManager.GetMaterial((MaterialType)transform2);
						if ((object)_renderer != null)
						{
							((Renderer)_renderer).SetMaterial(material);
							if (_scaleTween != null)
							{
								_scaleTween.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							bool flag5 = array == null;
							if ((object)_cachedTransform != null)
							{
								void* value = ((IntPtr*)(&array))->m_value;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj = default(object);
								bool flag6 = obj == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							bool flag7 = tweenConfig == null;
							((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
							bool flag8 = (object)_weapon == null;
							float num3 = _weapon.PArea();
							float num4 = (float)Vector3.zeroVector * 0.5f;
							_ = 1120403456;
							_ = 1;
							_ = 1;
							MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
							_scaleTween = scaleTween;
							if (_alphaTween != null)
							{
								_alphaTween.Kill();
							}
							TweenConfig tweenConfig2 = new TweenConfig();
							object[] array2 = new object[1];
							bool flag9 = array2 == null;
							if ((object)_renderer != null)
							{
								nint num5 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj2 = default(object);
								bool flag10 = obj2 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							bool flag11 = tweenConfig2 == null;
							tweenConfig2.targets = array2;
							tweenConfig2.duration = 100f;
							tweenConfig2.ease = Ease.Linear;
							tweenConfig2.delay = 100f;
							tweenConfig2.alpha = (float?)(object)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1744 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_WindWhip1_Projectile>)+370]");
							TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
							nint num6 = (nint)this;
							tweenConfig2.onComplete = onComplete;
							MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
							_alphaTween = alphaTween;
							object obj3 = UnityEngine.Random.value;
							Weapon weapon2 = _weapon;
							hOffset = 0.164f;
							bool flag12 = (object)_weapon == null;
							VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
							bool flag13 = (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null;
							int num7 = (int)(_indexInWeapon & 0x80000001L);
							if ((nint)((Equipment)weapon2)._003COwner_003Ek__BackingField < 0)
							{
								object obj4 = num7 - 1;
								object obj5 = obj4 | -2;
								num7 = obj5 + 1;
							}
							bool flag15;
							if (characterController._isFlipped)
							{
								object obj6 = num7 - 1;
								bool flag14 = obj6 == null;
								flag15 = !flag14;
							}
							else
							{
								object obj7 = num7 - 1;
								bool flag16 = obj7 == null;
								flag15 = flag16;
							}
							Transform cachedTransform = _cachedTransform;
							bool flag17 = (object)_cachedTransform == null;
							bool flag18 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out ret);
							if (flag15)
							{
							}
							Transform cachedTransform2 = _cachedTransform;
							bool flag19 = (object)_cachedTransform == null;
							bool flag20 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
							Vector3 value2 = default(Vector3);
							Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value2);
							bool flag21 = (object)_renderer == null;
							int num8 = (int)(_indexInWeapon & 0x80000001L);
							if ((nint)_renderer < 0)
							{
								object obj8 = num8 - 1;
								object obj9 = obj8 | -2;
								num8 = obj9 + 1;
							}
							object obj10 = num8 - 1;
							bool flag22 = obj10 == null;
							_renderer.flipY = flag22;
							bool flag23 = (object)_renderer == null;
							_renderer.flipX = flag15;
							Weapon weapon3 = _weapon;
							bool flag24 = (object)_weapon == null;
							bool flag25 = (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null;
							int num9 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.Depth;
							bool flag26 = (object)GM.Core == null;
							PhaserScene s_scene = ArcadePhysics.s_scene;
							bool flag27 = ArcadePhysics.s_scene == null;
							PhaserScene.Renderer renderer = s_scene._renderer;
							bool flag28 = s_scene._renderer == null;
							bool flag29 = (object)_renderer == null;
							int num10 = renderer.pixelHeight >> 31;
							object obj11 = renderer.pixelHeight - num10;
							object obj12 = obj11 >> 1;
							int sortingOrder = obj12 + num9;
							_renderer.sortingOrder = sortingOrder;
							object obj13 = UnityEngine.Random.value;
							bool flag30 = (object)_renderer == null;
							Transform transform3 = _renderer.transform;
							bool flag31 = (object)transform3 == null;
							transform3.localEulerAngles = (Vector3)(&ret);
							SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
							soundConfig.Rate = 1f;
							soundConfig.Volume = (float?)(object)1;
							soundConfig.Rate = 1.28f;
							float detune = (float)_indexInWeapon * 50f;
							soundConfig.Detune = detune;
							float time = default(float);
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Whip, soundConfig, 200f, 10, time);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}

	public TP_WindWhip1_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_021a: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0242: Expected O, but got I
		//IL_0157: Expected O, but got I
		hOffset = 0.032f;
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(0.16f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1042536202;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v5+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(-0.16f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 3190019850L;
		}
		vOffsets = list;
		_colors = new uint[5] { 13434828u, 143654860u, 4521932u, 4521932u, 8978312u };
		_blendModes = new BlendMode[4]
		{
			BlendMode.Normal,
			BlendMode.Screen,
			BlendMode.Screen,
			BlendMode.Screen
		};
		base._002Ector();
	}
}
