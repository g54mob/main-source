using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class LancetWeapon : Weapon
{
	private GameObject _LancetPierceEffectPrefab;

	private PhaserSprite _image;

	private SpriteAnimation _imageAnim;

	private MultiTargetTween _imageTween;

	private int _ticks = 8;

	private readonly List<Vector2> _targets;

	private readonly List<float> _angles;

	private const string AnimPierce = "pierce";

	public override float PAmount()
	{
		return 6f;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_004b: Expected I, but got O
		//IL_0054: Expected O, but got I4
		//IL_007c: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_00e5: Expected O, but got I
		//IL_0131: Expected O, but got I
		//IL_0198: Expected O, but got I
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
		WeaponType weaponType2 = default(WeaponType);
		base.InitWeapon(characterController2, weaponType2);
		List<Vector2> targets = _targets;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<float> angles = _angles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		nint num = unchecked((nint)null);
		object obj = 0;
		Vector2 item = default(Vector2);
		bool flag;
		do
		{
			List<Vector2> targets2 = _targets;
			float num2 = (float)obj / 12f;
			float num3 = num2 * ((float)Math.PI * 2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v5+18]");
			if (num4 >= 0)
			{
				targets2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj4 = (nint)0 + (nint)1;
			}
			angles = _angles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
			weaponType2 = WeaponType.VOID;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			characterController2 = (VampireSurvivors.Objects.Characters.CharacterController)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r8_v4 (VampireSurvivors.Data.WeaponType)+18]");
			if (num5 >= 0)
			{
				angles.AddWithResize(num3);
				weaponType2 = WeaponType.VOID;
				float num6 = num3;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj5 = (nint)0 + (nint)1;
				float num6 = num3;
			}
			obj++;
			flag = (nint)obj < 12;
			num = 0;
		}
		while (flag);
		SetupLancetEffect();
	}

	public override void Cleanup()
	{
		base.Cleanup();
		PhaserSprite image = _image;
		if ((object)_image != null && ((UnityEngine.Object)image).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _image.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject2 = _image.gameObject;
				gameObject2.SetActive(value: false);
			}
		}
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_004a: Expected O, but got I
		//IL_00d7: Expected O, but got I
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0704: Expected O, but got I4
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected I4, but got Unknown
		//IL_033f: Expected I, but got O
		//IL_03cf: Expected O, but got I4
		//IL_044d: Expected O, but got I
		//IL_0495: Expected O, but got I
		//IL_0495: Expected F4, but got I
		//IL_04a4: Expected O, but got I4
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Expected O, but got Unknown
		//IL_04fa: Invalid comparison between O and F4
		//IL_006a->IL05dc: Incompatible stack heights: 1 vs 0
		//IL_009d->IL05dc: Incompatible stack heights: 1 vs 0
		//IL_00f7->IL05dc: Incompatible stack heights: 2 vs 0
		//IL_01a4->IL05dc: Incompatible stack heights: 3 vs 0
		//IL_01d6->IL05dc: Incompatible stack heights: 3 vs 0
		//IL_020e->IL05dc: Incompatible stack heights: 3 vs 0
		//IL_0362->IL0362: Incompatible stack heights: 13 vs 12
		//IL_074d->IL05dc: Incompatible stack heights: 13 vs 0
		//IL_046d->IL05dc: Incompatible stack heights: 14 vs 0
		//IL_04bc->IL071f: Incompatible stack heights: 14 vs 13
		//IL_0774->IL05dc: Incompatible stack heights: 14 vs 0
		//IL_055a->IL05dc: Incompatible stack heights: 14 vs 0
		//IL_05c6->IL05dc: Incompatible stack heights: 14 vs 0
		if (++_ticks >= 12)
		{
			_ticks = 0;
		}
		List<Vector2> targets = _targets;
		int ticks = _ticks;
		if (_targets != null)
		{
			int ticks2 = _ticks;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag = (nint)ticks2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			if ((nint)0 != 0)
			{
				List<float> angles = _angles;
				int ticks3 = _ticks;
				if (_angles != null)
				{
					int ticks4 = _ticks;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+18]");
					bool flag2 = (nint)ticks4 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v39 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v33+20+v158 @ rdx_v24 (System.Int32)*4]");
						float num = 0f * 57.29578f;
						object cachedTransform = _cachedTransform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						object obj3 = num ^ 0;
						float num2 = (float)obj3 * ((float)Math.PI / 180f);
						Vector3 euler = default(Vector3);
						float ret;
						Quaternion.Internal_FromEulerRad_Injected(ref euler, out *(Quaternion*)(&ret));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rbx_v15 (System.Object)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rbx_v15 (System.Object)+10]");
						float value = default(float);
						Transform.set_localRotation_Injected((IntPtr)0, ref *(Quaternion*)(&value));
						PhaserSprite phaserSprite = _image.setAlpha(1f);
						_imageTween.Restart();
						float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						if ((object)_image != null)
						{
							PhaserSprite phaserSprite2 = _image.setPosition(position);
							if ((object)_image != null)
							{
								Transform transform = _image.transform;
								PhaserSprite cachedTransform2 = (PhaserSprite)(object)_cachedTransform;
								if ((object)_cachedTransform != null)
								{
									bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
									Transform.get_rotation_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out *(Quaternion*)(&ret));
									bool flag5 = (object)transform == null;
									bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)(&value));
									bool flag7 = (object)_image == null;
									PhaserSprite phaserSprite3 = _image.setVisible(visible: true);
									bool flag8 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
									int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
									object obj4 = Screen.height;
									bool flag9 = (object)_image == null;
									int depth2 = obj4 + depth;
									PhaserSprite phaserSprite4 = _image.setDepth(depth2);
									bool flag10 = (object)_imageAnim == null;
									_imageAnim.SetAnimation("pierce");
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									PhaserSprite image = _image;
									bool flag11 = (object)_image == null;
									bool flag12 = array == null;
									if ((object)image._spriteRenderer != null)
									{
										nint num3 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj5 = default(object);
										bool flag13 = obj5 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									bool flag14 = tweenConfig == null;
									tweenConfig.targets = array;
									tweenConfig.delay = 200f;
									tweenConfig.duration = 500f;
									tweenConfig.ease = Ease.Linear;
									tweenConfig.alpha = (float?)(object)1;
									TweenCallback onStart = delegate
									{
										PhaserSprite phaserSprite6 = _image.setAlpha(1f);
									};
									tweenConfig.onStart = onStart;
									MultiTargetTween imageTween = Tweens.Add(tweenConfig);
									_imageTween = imageTween;
									while (true)
									{
										List<float> angles2 = _angles;
										int ticks5 = _ticks;
										if (_angles == null)
										{
											break;
										}
										int ticks6 = _ticks;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v81 (System.Collections.Generic.List`1<System.Single>)+18]");
										bool flag15 = (nint)ticks6 >= (nint)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v81 (System.Collections.Generic.List`1<System.Single>)+10]");
										object obj6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v81 (System.Collections.Generic.List`1<System.Single>)+10]");
										if ((nint)0 == 0)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v46+20+v190 @ rcx_v68 (System.Int32)*4]");
										nint num4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v32+20+v56 @ rax_v4 (System.Int32)*8]");
										FireOneLancet(0, num4, (Vector2)0);
										PhaserSprite phaserSprite5 = (PhaserSprite)(0 + 1);
										if ((nint)phaserSprite5 < 6)
										{
											continue;
										}
										float num5 = base.PInterval();
										float num6 = _lastFiringInterval - ret;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
										object obj7 = num6 & 0;
										if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
										{
											float num7 = base.PInterval();
											_lastFiringInterval = ret;
											base.ResetFiringTimer();
										}
										GameManager core = GM.Core;
										if ((object)GM.Core == null)
										{
											break;
										}
										ArcanaManager arcanaManager = core._arcanaManager;
										if (core._arcanaManager == null)
										{
											break;
										}
										if (arcanaManager._hasAstronomia)
										{
											GameManager core2 = GM.Core;
											core2._arcanaManager.TriggerAstronomia(this);
										}
										if (!skipTriggers)
										{
											if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
											{
												break;
											}
											((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
										}
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void FireOneLancet(int index, float angle, Vector2 targetPos)
	{
		//IL_007a: Expected I, but got O
		//IL_0082: Expected I, but got O
		//IL_0092: Expected O, but got I
		//IL_00cf: Expected O, but got I
		//IL_0218->IL01ba: Incompatible stack heights: 3 vs 1
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				Vector2 pos = default(Vector2);
				Projectile projectile = base.FireOneProjectile(pos, index);
				if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				nint num = (nint)typeof(LancetProjectile);
				nint num2 = (nint)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LancetProjectile>)+130]");
				Vector2 vector = (Vector2)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rcx_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LancetProjectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LancetProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rcx_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LancetProjectile>)+C8]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rax_v45+FFFFFFF8+v640 @ rax_v33 (UnityEngine.Vector2)*8]");
					if (0 == (nint)typeof(LancetProjectile))
					{
						((LancetProjectile)projectile).SetTargetPosition(targetPos);
					}
				}
				Transform cachedTransform = _cachedTransform;
				Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&ret), out Quaternion _);
				bool flag2 = (object)_cachedTransform == null;
				bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Quaternion value = default(Quaternion);
				Transform.set_localRotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void SetupLancetEffect()
	{
		//IL_03fd: Expected I, but got O
		//IL_005a: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		//IL_0220: Expected O, but got I4
		//IL_046a->IL03e3: Incompatible stack heights: 1 vs 0
		//IL_0042->IL03e3: Incompatible stack heights: 1 vs 0
		//IL_0076->IL03e3: Incompatible stack heights: 1 vs 0
		//IL_00a5->IL03e3: Incompatible stack heights: 1 vs 0
		//IL_00d4->IL03e3: Incompatible stack heights: 1 vs 0
		//IL_0140->IL03e3: Incompatible stack heights: 1 vs 0
		//IL_015d->IL03e3: Incompatible stack heights: 1 vs 0
		//IL_01d1->IL03e3: Incompatible stack heights: 1 vs 0
		//IL_01af->IL01af: Incompatible stack heights: 2 vs 1
		//IL_02b3->IL03e3: Incompatible stack heights: 1 vs 0
		//IL_02d5->IL03e3: Incompatible stack heights: 1 vs 0
		//IL_03b4->IL03e3: Incompatible stack heights: 2 vs 0
		PhaserWorld instance = PhaserWorld.Instance;
		nint num = (nint)_cachedTransform;
		if ((object)_cachedTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v1 (Il2CppMethodInfo)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v1 (Il2CppMethodInfo)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			if ((object)instance != null)
			{
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "Pierce1");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0f, (float?)(object)1);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setVisible(visible: false);
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite phaserSprite4 = phaserSprite3.setTint(13430527u);
							if ((object)phaserSprite4 != null)
							{
								PhaserSprite image = phaserSprite4.setScale(2f, (float?)(object)1);
								_image = image;
								TweenConfig tweenConfig = new TweenConfig();
								object[] array = new object[1];
								PhaserSprite image2 = _image;
								if ((object)_image != null && array != null)
								{
									if ((object)image2._spriteRenderer != null)
									{
										object obj = array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj2 = default(object);
										bool flag2 = obj2 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig != null)
									{
										tweenConfig.targets = array;
										tweenConfig.delay = 200f;
										tweenConfig.duration = 500f;
										tweenConfig.ease = Ease.Linear;
										tweenConfig.alpha = (float?)(object)1;
										TweenCallback onStart = delegate
										{
											PhaserSprite phaserSprite5 = _image.setAlpha(1f);
										};
										tweenConfig.onStart = onStart;
										MultiTargetTween imageTween = Tweens.Add(tweenConfig);
										_imageTween = imageTween;
										bool flag3 = default(bool);
										List<Sprite> animation = SpriteManager.GetAnimation("Pierce", 1, 5, "vfx", flag3);
										PhaserSprite image3 = _image;
										if ((object)_image != null && (object)image3._spriteRenderer != null)
										{
											GameObject gameObject = image3._spriteRenderer.gameObject;
											nint num2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v9 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											bool flag4 = (object)gameObject == null;
											SpriteAnimation imageAnim = ((!gameObject.TryGetComponent<SpriteAnimation>(out var component)) ? gameObject.AddComponent<SpriteAnimation>() : component);
											_imageAnim = imageAnim;
											if ((object)_imageAnim != null)
											{
												bool startRandomFrame = default(bool);
												Action onComplete = default(Action);
												bool autoSetAnimation = default(bool);
												_imageAnim.AddAnimation("pierce", animation, 30, flag3, startRandomFrame, onComplete, autoSetAnimation);
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public LancetWeapon()
	{
		List<Vector2> targets = new List<Vector2>();
		_targets = targets;
		_angles = new List<float>();
		base._002Ector();
	}

	private void _003CFire_003Eb__11_0()
	{
		PhaserSprite phaserSprite = _image.setAlpha(1f);
	}

	private void _003CSetupLancetEffect_003Eb__13_0()
	{
		PhaserSprite phaserSprite = _image.setAlpha(1f);
	}
}
