using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Unused_TP_AlchemyWhipBasic_Projectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _posTween;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0052: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_013a: Expected I, but got O
		//IL_036a: Expected I, but got O
		//IL_0372: Expected I, but got O
		//IL_0382: Expected O, but got I
		//IL_0228: Expected I, but got O
		//IL_0402: Expected O, but got I4
		//IL_02b8: Expected O, but got I4
		//IL_02d3: Expected I, but got O
		//IL_03be: Expected O, but got I
		//IL_0426: Expected O, but got I
		//IL_03f4: Expected O, but got I4
		//IL_050a: Expected I, but got O
		//IL_057c: Expected O, but got I
		//IL_05d0: Expected O, but got I
		//IL_0622: Expected O, but got I4
		//IL_063c: Expected O, but got I
		//IL_0690: Expected O, but got I
		//IL_06fe: Expected O, but got I4
		//IL_0803: Expected O, but got I4
		//IL_0819: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Expected I4, but got Unknown
		//IL_0857: Expected O, but got I4
		//IL_010a->IL010a: Incompatible stack heights: 3 vs 2
		//IL_024b->IL024b: Incompatible stack heights: 6 vs 5
		//IL_0337->IL0337: Incompatible stack heights: 7 vs 4
		//IL_052d->IL052d: Incompatible stack heights: 9 vs 8
		base.InitProjectile(pool, weapon, index);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		bool flag2 = array == null;
		if ((object)_cachedTransform != null)
		{
			void* value2 = ((IntPtr*)(&array))->m_value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			bool flag3 = obj == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag4 = tweenConfig == null;
		((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
		bool flag5 = (object)_weapon == null;
		float num = _weapon.PArea();
		_ = 1120403456;
		_ = 1;
		_ = 1;
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
				nint num2 = (nint)array2;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1469 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Unused_TP_AlchemyWhipBasic_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			tweenConfig2.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
			bool flag9 = multiTargetTween == null;
			MultiTargetTween alphaTween = multiTargetTween.SetAutoKill(autoKill: false);
			_alphaTween = alphaTween;
		}
		Weapon weapon2 = _weapon;
		bool flag10 = (object)_weapon == null;
		nint num4 = (nint)typeof(Unused_TP_AlchemyWhipBasic_Weapon);
		nint num5 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_AlchemyWhipBasic_Weapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_AlchemyWhipBasic_Weapon>)+130]");
		object obj5;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1321 @ rax_v102+FFFFFFF8+v1307 @ rax_v51*8]");
			if (0 == (nint)typeof(Unused_TP_AlchemyWhipBasic_Weapon))
			{
				obj5 = 1;
				goto IL_08f6;
			}
		}
		obj5 = 0;
		goto IL_08f6;
		IL_08f6:
		bool flag11 = obj5 == null;
		Transform transform2 = null;
		if (!flag11)
		{
			transform2 = (Transform)(object)_weapon;
		}
		bool flag12 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rbx_v14 (UnityEngine.Transform)+158]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rbx_v14 (UnityEngine.Transform)+158]");
		bool flag13 = (nint)0 == 0;
		int indexInWeapon = _indexInWeapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rcx_v41+18]");
		int num7 = (int)((nint)indexInWeapon % (nint)0);
		float2 pos = base.position;
		((Unused_TP_AlchemyWhipBasic_Weapon)(object)transform2).addWhipSprite(pos, num7);
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		bool flag14 = array3 == null;
		if ((object)_cachedTransform != null)
		{
			nint num8 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			bool flag15 = obj7 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag16 = tweenConfig3 == null;
		tweenConfig3.targets = array3;
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rbx_v14 (UnityEngine.Transform)+168]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rbx_v14 (UnityEngine.Transform)+168]");
		bool flag17 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rax_v65+18]");
		bool flag18 = (nint)num7 >= (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rax_v65+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rax_v65+10]");
		bool flag19 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ rcx_v52+18]");
		bool flag20 = (nint)num7 >= (nint)0;
		tweenConfig3.x = (float?)(object)1;
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rbx_v14 (UnityEngine.Transform)+168]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rbx_v14 (UnityEngine.Transform)+168]");
		bool flag21 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rcx_v54+18]");
		bool flag22 = (nint)num7 >= (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rcx_v54+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rcx_v54+10]");
		bool flag23 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ rcx_v55+18]");
		bool flag24 = (nint)num7 >= (nint)0;
		tweenConfig3.duration = 100f;
		tweenConfig3.ease = Ease.Linear;
		tweenConfig3.y = (float?)(object)1;
		MultiTargetTween posTween = Tweens.Add(tweenConfig3);
		_posTween = posTween;
		Weapon weapon3 = _weapon;
		bool flag25 = (object)_weapon == null;
		bool flag26 = (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null;
		int num9 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.Depth;
		bool flag27 = (object)GM.Core == null;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		bool flag28 = ArcadePhysics.s_scene == null;
		PhaserScene.Renderer renderer = s_scene._renderer;
		bool flag29 = s_scene._renderer == null;
		bool flag30 = (object)_renderer == null;
		int num10 = renderer.pixelHeight >> 31;
		object obj12 = renderer.pixelHeight - num10;
		object obj13 = obj12 >> 1;
		int sortingOrder = obj13 + num9;
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
