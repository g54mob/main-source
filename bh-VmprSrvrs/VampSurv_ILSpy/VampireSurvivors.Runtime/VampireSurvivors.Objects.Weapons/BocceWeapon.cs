using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class BocceWeapon : Weapon
{
	protected int _radius = 32;

	protected string _orbFrame = "bubbleSphere";

	private SpriteRenderer _image;

	private MultiTargetTween _imageTween;

	private List<SpriteRenderer> _orbs;

	private List<float> _angles;

	private float _angleUnit = (float)Math.PI / 360f;

	private List<float> _anglesMul;

	public float _Alpha;

	public override float PAmount()
	{
		return 1f;
	}

	public override float PPower()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected F4, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		float num6;
		float num4 = default(float);
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PCurse();
				float num3 = num4 - num4;
				float num5 = num3 & -2147483649L;
				object obj = num5 & -2147483649L;
				if ((nint)obj <= 2139095040)
				{
					bool flag = !(num5 > 10f);
					num6 = num5;
					if (flag)
					{
						goto IL_0199;
					}
				}
				num6 = 10f;
				goto IL_0199;
			}
		}
		goto IL_018e;
		IL_018e:
		throw new NullReferenceException();
		IL_0199:
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag2 = _currentWeaponData == null;
		num4 = 10f;
		if (!flag2)
		{
			bool flag3 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num4 = 10f;
			if (!flag3)
			{
				num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num7 = num6 + 1f;
					float num8 = num7 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num9 = num8 * num4;
					return num4 + num9;
				}
			}
		}
		goto IL_018e;
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_011e: Expected O, but got Ref
		//IL_01f1: Expected I4, but got O
		//IL_0256: Expected I4, but got I8
		//IL_0264: Expected O, but got I4
		//IL_02ac: Expected O, but got I4
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected I4, but got Unknown
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_0437: Expected O, but got I4
		//IL_0460: Expected O, but got I4
		//IL_0504: Expected O, but got I
		//IL_0671: Expected O, but got F4
		//IL_053b: Expected O, but got I
		//IL_05b4: Expected O, but got I
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Expected O, but got Unknown
		base.InitWeapon(characterController, weaponType);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float y = renderer2.height * 0.5f;
		float x = renderer.width * 0.5f;
		GameObject gameObject = base.gameObject;
		string spriteName = default(string);
		SpriteRenderer image = RenderingExtensions.AddSprite(gameObject, x, y, "vfx", spriteName);
		_image = image;
		Material material = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
		((Renderer)_image).SetMaterial(material);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScrollFactor(_image, 0f);
		float num = base.PArea();
		object obj = default(object);
		float scale = (float)obj + (float)obj;
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_image, scale);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj2 = default(object);
		RenderingExtensions.SetTint(_image, (Color?)(object)(&obj2));
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_image, 0.1f);
		if (_imageTween != null)
		{
			_imageTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_image != null)
		{
			SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScrollFactor(_image, 0.1f);
			if ((object)spriteRenderer4 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScrollFactor((SpriteRenderer)(object)array, 0.1f, (byte)(int)_image != 0);
		tweenConfig.targets = array;
		tweenConfig.yoyo = true;
		tweenConfig.repeatDelay = 100f;
		tweenConfig.duration = 1000f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.repeat = -1;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween imageTween = Tweens.Add(tweenConfig);
		_imageTween = imageTween;
		List<SpriteRenderer> orbs = new List<SpriteRenderer>();
		_orbs = orbs;
		object obj3 = 0;
		do
		{
			GameObject gameObject2 = base.gameObject;
			SpriteRenderer spriteRenderer6 = RenderingExtensions.AddSprite(gameObject2, 0f, 0f, "vfx", spriteName);
			int depth = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
			int sortingOrder = depth + obj3;
			spriteRenderer6.sortingOrder = sortingOrder;
			List<object> orbs2 = (List<object>)(object)_orbs;
			int version = orbs2._version + 1;
			orbs2._version = version;
			object[] items = orbs2._items;
			if (orbs2._size >= items.Length)
			{
				orbs2.AddWithResize((object)spriteRenderer6);
			}
			else
			{
				int size = orbs2._size + 1;
				orbs2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			obj3++;
		}
		while ((nint)obj3 < 8);
		List<float> angles = new List<float>();
		_angles = angles;
		List<float> anglesMul = new List<float>();
		_anglesMul = anglesMul;
		List<SpriteRenderer> orbs3 = _orbs;
		object obj4 = orbs3._size + 1;
		if ((nint)obj4 <= 0)
		{
			return;
		}
		object obj5 = 0;
		do
		{
			List<float> angles2 = _angles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v61 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v61 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint num2 = 0;
			object obj6 = obj5 / obj4;
			float item = (float)obj6 * ((float)Math.PI * 2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v61 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r8_v27 (Il2CppMethodInfo)+18]");
			if (num3 >= 0)
			{
				angles2.AddWithResize(item);
				num2 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v61 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj7 = (nint)0 + (nint)1;
			}
			List<float> anglesMul2 = _anglesMul;
			object obj8 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rbx_v19 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rbx_v19 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj9 = 0;
			float num4 = (float)obj4 * 0.2f;
			float item2 = num4 + 0.8f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rbx_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v39+18]");
			if (num5 >= 0)
			{
				anglesMul2.AddWithResize(item2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rbx_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj10 = (nint)0 + (nint)1;
			}
			obj5++;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4));
	}

	public override void Fire(bool skipTriggers = false)
	{
		SpriteRenderer image = _image;
		if ((object)_image != null && ((UnityEngine.Object)image).m_CachedPtr != (IntPtr)0)
		{
			float num = base.PArea();
			object obj = default(object);
			float scale = (float)obj + (float)obj;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_image, scale);
			base.Fire(skipTriggers);
		}
	}

	public override void Cleanup()
	{
		//IL_006c: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		base.Cleanup();
		if (_imageTween != null)
		{
			_imageTween.Kill();
		}
		_image.enabled = false;
		_image.enabled = false;
		UnityEngine.Object.Destroy(_image, 0f);
		List<SpriteRenderer> orbs = _orbs;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < orbs._size)
			{
				List<SpriteRenderer> orbs2 = _orbs;
				if ((nint)obj >= orbs2._size)
				{
					break;
				}
				SpriteRenderer[] items = orbs2._items;
				UnityEngine.Object.Destroy(items[obj], 0f);
				orbs = _orbs;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0e66: Expected O, but got Ref
		//IL_0ebd: Expected O, but got Ref
		//IL_00fe: Expected O, but got I4
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected I4, but got Unknown
		//IL_109d: Invalid comparison between F4 and O
		//IL_0210: Expected O, but got I
		//IL_11d2: Invalid comparison between F4 and O
		//IL_1307: Invalid comparison between F4 and O
		//IL_02ac: Expected O, but got I
		//IL_0f59: Expected O, but got F4
		//IL_02fe: Expected F4, but got I4
		//IL_0318: Expected O, but got I
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Expected O, but got Unknown
		//IL_081f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0824: Expected O, but got Unknown
		//IL_0860: Unknown result type (might be due to invalid IL or missing references)
		//IL_0865: Expected O, but got Unknown
		//IL_0a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a92: Expected O, but got Unknown
		//IL_0ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad3: Expected O, but got Unknown
		//IL_0d07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0c: Expected O, but got Unknown
		//IL_1022: Expected O, but got Ref
		//IL_0d48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4d: Expected O, but got Unknown
		//IL_0d80: Expected F4, but got I
		//IL_1157: Expected O, but got Ref
		//IL_105c: Expected O, but got Ref
		//IL_128c: Expected O, but got Ref
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_0679: Expected O, but got Unknown
		//IL_1191: Expected O, but got Ref
		//IL_13be: Expected O, but got Ref
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ef: Expected O, but got Unknown
		//IL_12c6: Expected O, but got Ref
		//IL_0b58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5d: Expected O, but got Unknown
		//IL_13f5: Expected O, but got Ref
		//IL_0de2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de7: Expected O, but got Unknown
		//IL_040b->IL0f5e: Incompatible stack heights: 23 vs 11
		//IL_069f->IL1076: Incompatible stack heights: 27 vs 12
		//IL_090d->IL11ab: Incompatible stack heights: 28 vs 13
		//IL_06a5->IL06a5: Incompatible stack heights: 27 vs 12
		//IL_0b7b->IL12e0: Incompatible stack heights: 29 vs 14
		//IL_0913->IL0913: Incompatible stack heights: 28 vs 13
		//IL_0e06->IL140c: Incompatible stack heights: 30 vs 15
		//IL_0b81->IL0b81: Incompatible stack heights: 29 vs 14
		//IL_0e0c->IL0e0c: Incompatible stack heights: 30 vs 15
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InternalUpdate();
		bool flag = (object)_image == null;
		Transform transform = _image.transform;
		Transform transform2 = base.transform;
		bool flag2 = (object)transform2 == null;
		_ = 0;
		_ = 0;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj3);
		bool flag4 = (object)transform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-61]");
		_ = 0;
		bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj4);
		bool flag6 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
		bool flag7 = (object)GM.Core == null;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		bool flag8 = ArcadePhysics.s_scene == null;
		PhaserScene.Renderer renderer = s_scene._renderer;
		bool flag9 = s_scene._renderer == null;
		bool flag10 = (object)_image == null;
		object obj5 = renderer.pixelHeight >> 31;
		object obj6 = renderer.pixelHeight - obj5;
		object obj7 = obj6 >> 1;
		int sortingOrder = depth - obj7;
		_image.sortingOrder = sortingOrder;
		float num = base.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
		float num2 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
		float num3 = num2 + 0f;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_image, num3);
		List<float> angles = _angles;
		bool flag11 = _angles == null;
		float num4 = num3;
		Transform transform3 = null;
		Transform transform4 = null;
		while (true)
		{
			Transform obj8 = transform4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rax_v107 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)obj8 >= 0)
			{
				break;
			}
			object angles2 = _angles;
			bool flag12 = _angles == null;
			Transform obj9 = transform3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rsi_v45 (System.Object)+18]");
			bool flag13 = (nint)obj9 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rsi_v45 (System.Object)+10]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rsi_v45 (System.Object)+10]");
			bool flag14 = (nint)0 == 0;
			Transform obj11 = transform3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rcx_v200+18]");
			bool flag15 = (nint)obj11 >= 0;
			List<float> anglesMul = _anglesMul;
			bool flag16 = _anglesMul == null;
			Transform obj12 = transform3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rcx_v201 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag17 = (nint)obj12 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rcx_v201 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rcx_v201 (System.Collections.Generic.List`1<System.Single>)+10]");
			bool flag18 = (nint)0 == 0;
			Transform obj14 = transform3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rcx_v202+18]");
			bool flag19 = (nint)obj14 >= 0;
			if (PauseSystem._paused)
			{
				num4 = 0f;
			}
			else
			{
				object obj15 = Time.deltaTime;
			}
			Transform obj16 = transform3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rsi_v45 (System.Object)+18]");
			bool flag20 = (nint)obj16 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rsi_v45 (System.Object)+10]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rsi_v45 (System.Object)+10]");
			bool flag21 = (nint)0 == 0;
			Transform obj18 = transform3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v206+18]");
			bool flag22 = (nint)obj18 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rcx_v202+20+v220 @ rdi_v38 (UnityEngine.Transform)*4]");
			float num5 = 0f * _angleUnit;
			Transform transform5 = (Transform)(transform3 + 1);
			float num6 = num5 * num4;
			float num7 = num6 * 1000f;
			float num8 = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rcx_v200+20+v220 @ rdi_v38 (UnityEngine.Transform)*4]");
			float num9 = num8 + 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rsi_v45 (System.Object)+1C]");
			_ = (nint)0 + (nint)1;
			angles = _angles;
			bool flag23 = _angles == null;
			transform3 = transform5;
			transform4 = transform5;
		}
		float num10 = base.PArea();
		List<SpriteRenderer> orbs = _orbs;
		bool flag24 = _orbs == null;
		Transform transform6 = null;
		Transform transform7 = null;
		List<SpriteRenderer> orbs2;
		bool flag40;
		do
		{
			orbs2 = _orbs;
			float num11 = (float)orbs._size * 0.25f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num11) <= System.Runtime.CompilerServices.Unsafe.As<Transform, UIntPtr>(ref transform7))
			{
				break;
			}
			bool flag25 = _orbs == null;
			bool flag26 = (nint)transform6 >= orbs2._size;
			SpriteRenderer[] items = orbs2._items;
			bool flag27 = orbs2._items == null;
			bool flag28 = (nint)transform6 >= items.Length;
			SpriteRenderer spriteRenderer2 = items[(object)transform6];
			bool flag29 = (object)items[(object)transform6] == null;
			bool flag30 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr);
			Transform transform8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			List<float> angles3 = _angles;
			bool flag31 = _angles == null;
			Transform obj19 = transform6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v180 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag32 = (nint)obj19 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v180 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v180 (System.Collections.Generic.List`1<System.Single>)+10]");
			bool flag33 = (nint)0 == 0;
			Transform obj20 = transform6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rcx_v181 (System.IntPtr)+18]");
			bool flag34 = (nint)obj20 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v180 (System.Collections.Generic.List`1<System.Single>)+10]");
			Transform transform9 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)0);
			List<float> angles4 = _angles;
			object obj21 = transform6 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1782 @ rcx_v182 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag35 = (nint)obj21 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1782 @ rcx_v182 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint gcHandlePtr2 = 0;
			object obj22 = transform6 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rcx_v183 (System.IntPtr)+18]");
			bool flag36 = (nint)obj22 >= 0;
			Transform transform10 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			bool flag37 = (object)transform8 == null;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v217 (UnityEngine.Transform)+10]");
			bool flag38 = (nint)0 == 0;
			object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v217 (UnityEngine.Transform)+10]");
			Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj23);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-61]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v217 (UnityEngine.Transform)+10]");
			bool flag39 = (nint)0 == 0;
			object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v217 (UnityEngine.Transform)+10]");
			Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj24);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(items[(object)transform6], num4);
			orbs = _orbs;
			transform6 = (Transform)(transform6 + 1);
			flag40 = _orbs != null;
			transform7 = transform6;
		}
		while (flag40);
		bool flag41 = _orbs == null;
		List<SpriteRenderer> orbs3;
		do
		{
			orbs3 = _orbs;
			float num13 = (float)orbs2._size * 0.5f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num13) <= System.Runtime.CompilerServices.Unsafe.As<Transform, UIntPtr>(ref transform6))
			{
				break;
			}
			bool flag42 = _orbs == null;
			bool flag43 = (nint)transform6 >= orbs3._size;
			SpriteRenderer[] items2 = orbs3._items;
			bool flag44 = orbs3._items == null;
			bool flag45 = (nint)transform6 >= items2.Length;
			object obj25 = items2[(object)transform6];
			bool flag46 = (object)items2[(object)transform6] == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ r15_v39 (System.Object)+10]");
			bool flag47 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ r15_v39 (System.Object)+10]");
			IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
			Transform transform11 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			List<float> angles5 = _angles;
			bool flag48 = _angles == null;
			Transform obj26 = transform6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v156 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag49 = (nint)obj26 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v156 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v156 (System.Collections.Generic.List`1<System.Single>)+10]");
			bool flag50 = (nint)0 == 0;
			Transform obj27 = transform6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v157 (System.IntPtr)+18]");
			bool flag51 = (nint)obj27 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v156 (System.Collections.Generic.List`1<System.Single>)+10]");
			Transform transform12 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)0);
			List<float> angles6 = _angles;
			object obj28 = transform6 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1783 @ rcx_v158 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag52 = (nint)obj28 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1783 @ rcx_v158 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint gcHandlePtr4 = 0;
			object obj29 = transform6 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v159 (System.IntPtr)+18]");
			bool flag53 = (nint)obj29 >= 0;
			Transform transform13 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
			bool flag54 = (object)transform11 == null;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v185 (UnityEngine.Transform)+10]");
			bool flag55 = (nint)0 == 0;
			object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v185 (UnityEngine.Transform)+10]");
			Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj30);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-61]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v185 (UnityEngine.Transform)+10]");
			bool flag56 = (nint)0 == 0;
			transform7 = (Transform)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v185 (UnityEngine.Transform)+10]");
			Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)transform7);
			SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(items2[(object)transform6], num4);
			orbs2 = _orbs;
			transform6 = (Transform)(transform6 + 1);
		}
		while (_orbs != null);
		bool flag57 = _orbs == null;
		List<SpriteRenderer> orbs4;
		do
		{
			orbs4 = _orbs;
			float num15 = (float)orbs3._size * 0.75f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num15) <= System.Runtime.CompilerServices.Unsafe.As<Transform, UIntPtr>(ref transform6))
			{
				break;
			}
			bool flag58 = _orbs == null;
			bool flag59 = (nint)transform6 >= orbs4._size;
			SpriteRenderer[] items3 = orbs4._items;
			bool flag60 = orbs4._items == null;
			bool flag61 = (nint)transform6 >= items3.Length;
			object obj31 = items3[(object)transform6];
			bool flag62 = (object)items3[(object)transform6] == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r15_v38 (System.Object)+10]");
			bool flag63 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r15_v38 (System.Object)+10]");
			IntPtr gcHandlePtr5 = Component.get_transform_Injected((IntPtr)0);
			Transform transform14 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
			List<float> angles7 = _angles;
			bool flag64 = _angles == null;
			Transform obj32 = transform6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v132 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag65 = (nint)obj32 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v132 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v132 (System.Collections.Generic.List`1<System.Single>)+10]");
			bool flag66 = (nint)0 == 0;
			Transform obj33 = transform6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rcx_v133 (System.IntPtr)+18]");
			bool flag67 = (nint)obj33 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v132 (System.Collections.Generic.List`1<System.Single>)+10]");
			Transform transform15 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)0);
			List<float> angles8 = _angles;
			object obj34 = transform6 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1784 @ rcx_v134 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag68 = (nint)obj34 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1784 @ rcx_v134 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint gcHandlePtr6 = 0;
			object obj35 = transform6 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v135 (System.IntPtr)+18]");
			bool flag69 = (nint)obj35 >= 0;
			Transform transform16 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
			bool flag70 = (object)transform14 == null;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rax_v154 (UnityEngine.Transform)+10]");
			bool flag71 = (nint)0 == 0;
			object obj36 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rax_v154 (UnityEngine.Transform)+10]");
			Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj36);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-61]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rax_v154 (UnityEngine.Transform)+10]");
			bool flag72 = (nint)0 == 0;
			transform7 = (Transform)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rax_v154 (UnityEngine.Transform)+10]");
			Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)transform7);
			SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale(items3[(object)transform6], num4);
			orbs3 = _orbs;
			transform6 = (Transform)(transform6 + 1);
		}
		while (_orbs != null);
		bool flag73 = _orbs == null;
		while ((nint)transform6 < orbs4._size)
		{
			List<SpriteRenderer> orbs5 = _orbs;
			bool flag74 = _orbs == null;
			bool flag75 = (nint)transform6 >= orbs5._size;
			SpriteRenderer[] items4 = orbs5._items;
			bool flag76 = orbs5._items == null;
			bool flag77 = (nint)transform6 >= items4.Length;
			object obj37 = items4[(object)transform6];
			bool flag78 = (object)items4[(object)transform6] == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r15_v37 (System.Object)+10]");
			bool flag79 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r15_v37 (System.Object)+10]");
			IntPtr gcHandlePtr7 = Component.get_transform_Injected((IntPtr)0);
			Transform transform17 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr7);
			List<float> angles9 = _angles;
			bool flag80 = _angles == null;
			Transform obj38 = transform6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v108 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag81 = (nint)obj38 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v108 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v108 (System.Collections.Generic.List`1<System.Single>)+10]");
			bool flag82 = (nint)0 == 0;
			Transform obj39 = transform6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rcx_v109 (System.IntPtr)+18]");
			bool flag83 = (nint)obj39 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v108 (System.Collections.Generic.List`1<System.Single>)+10]");
			Transform transform18 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)0);
			List<float> angles10 = _angles;
			object obj40 = transform6 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1785 @ rcx_v110 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag84 = (nint)obj40 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1785 @ rcx_v110 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint gcHandlePtr8 = 0;
			object obj41 = transform6 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v111 (System.IntPtr)+18]");
			bool flag85 = (nint)obj41 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v111 (System.IntPtr)+20+v2054 @ rax_v127*4]");
			float num15 = 0f;
			Transform transform19 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr8);
			bool flag86 = (object)transform17 == null;
			_ = 0;
			_ = 0;
			bool flag87 = ((UnityEngine.Object)transform17).m_CachedPtr == (IntPtr)0;
			object obj42 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform17).m_CachedPtr, out *(Vector3*)obj42);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-61]");
			_ = 0;
			bool flag88 = ((UnityEngine.Object)transform17).m_CachedPtr == (IntPtr)0;
			transform7 = (Transform)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform17).m_CachedPtr, ref *(Vector3*)transform7);
			SpriteRenderer spriteRenderer6 = RenderingExtensions.SetScale(items4[(object)transform6], num4);
			orbs4 = _orbs;
			transform6 = (Transform)(transform6 + 1);
			if (_orbs == null)
			{
				break;
			}
		}
	}

	public override void SetVisible(bool visible)
	{
		//IL_0032: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		bool isVisible = default(bool);
		_isVisible = isVisible;
		if ((object)_image != null)
		{
			_image.enabled = isVisible;
		}
		List<SpriteRenderer> orbs = _orbs;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < orbs._size)
			{
				List<SpriteRenderer> orbs2 = _orbs;
				if ((nint)obj >= orbs2._size)
				{
					break;
				}
				SpriteRenderer[] items = orbs2._items;
				if ((object)items[obj] != null)
				{
					items[obj].enabled = isVisible;
				}
				orbs = _orbs;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}
}
