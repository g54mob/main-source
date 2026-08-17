using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class InsatiableWeapon : Weapon
{
	private PhaserSprite _image;

	private MultiTargetTween _imageTween;

	private MultiTargetTween _imageTween2;

	private float _imagePixelSize = 30f;

	public bool IsFromDarkana;

	public override float PPower()
	{
		float num = default(float);
		float num2;
		if (IsFromDarkana)
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
			{
				goto IL_011d;
			}
			num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			num2 = num;
		}
		else
		{
			num2 = 1f;
		}
		float num4;
		if (IsFromDarkana)
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
			{
				goto IL_011d;
			}
			float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
			num4 = num * 0.1f;
		}
		else
		{
			num4 = 1f;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num5 = ((Equipment)this)._003COwner_003Ek__BackingField.PGreed();
			bool flag = !(1f < num4);
			float num6 = 1f;
			if (!flag)
			{
				num6 = num4;
			}
			float num7 = num * num2;
			float num8 = num6 * currentWeaponData._003Cpower_003Ek__BackingField;
			return num7 * num8;
		}
		goto IL_011d;
		IL_011d:
		throw new NullReferenceException();
	}

	public override float PAmount()
	{
		return 1f;
	}

	public override float PArea()
	{
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		bool flag = !IsFromDarkana;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		EggFloat eggFloat2;
		if (!flag)
		{
			MagnetZone magnet = characterController._magnet;
			EggFloat radius = magnet.Radius;
			float num = characterController.PAreaFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			object obj2 = default(object);
			object obj = obj2 * currentWeaponData._003Carea_003Ek__BackingField;
			float eggValue = default(float);
			float value = default(float);
			EggFloat eggFloat = new EggFloat(value, eggValue);
			eggValue = radius._eggVal * (float)obj;
			value = radius._val * (float)obj;
			eggFloat2 = eggFloat;
		}
		else
		{
			MagnetZone magnet2 = characterController._magnet;
			eggFloat2 = magnet2.Radius;
		}
		float num2 = eggFloat2._eggVal + eggFloat2._val;
		object obj3 = num2 & -2147483649L;
		if ((nint)obj3 != 2139095040)
		{
			object obj4 = num2 & -2147483649L;
			if ((nint)obj4 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873A5E15h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				return num2;
			}
		}
		return 3.4028235E+38f;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_02bd: Expected I, but got O
		//IL_02e0->IL02e0: Incompatible stack heights: 9 vs 8
		base.InitWeapon(characterController, weaponType);
		PhaserWorld instance = PhaserWorld.Instance;
		if ((object)instance != null)
		{
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "_Insatiable");
			if ((object)phaserSprite != null)
			{
				GameObject gameObject = phaserSprite.gameObject;
				if ((object)gameObject != null)
				{
					((UnityEngine.Object)gameObject).SetName("InsatiableWeapon - _Insatiable");
					_image = phaserSprite;
					if ((object)_image != null)
					{
						PhaserSprite phaserSprite2 = _image.setBlendMode(BlendMode.Normal);
						if ((object)_image != null)
						{
							PhaserSprite phaserSprite3 = _image.setAlpha(0.6f);
							if ((object)_image != null)
							{
								Transform transform = _image.transform;
								VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)characterController2._magnet != null)
								{
									Transform transform2 = characterController2._magnet.transform;
									if ((object)transform2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v28 (UnityEngine.Transform)+10]");
										bool flag = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v28 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out Vector3 _);
										bool flag2 = (object)transform == null;
										bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Vector3 value = default(Vector3);
										Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
										PhaserSprite phaserSprite4 = RenderingExtensions.SetScale(scale: GetImageScale(), component: _image);
										bool flag4 = (object)GM.Core == null;
										PhaserScene s_scene = ArcadePhysics.s_scene;
										bool flag5 = ArcadePhysics.s_scene == null;
										PhaserScene.Renderer renderer = s_scene._renderer;
										bool flag6 = s_scene._renderer == null;
										bool flag7 = (object)_image == null;
										float height = renderer.height;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
										object obj = height ^ 0;
										float depth = (float)obj * 0.5f;
										PhaserSprite phaserSprite5 = _image.setDepth(depth);
										TweenConfig tweenConfig = new TweenConfig();
										object[] array = new object[1];
										bool flag8 = array == null;
										if ((object)_image != null)
										{
											nint num = (nint)array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj2 = default(object);
											bool flag9 = obj2 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										bool flag10 = tweenConfig == null;
										_ = 4294967295L;
										_ = 1;
										_ = 1120403456;
										_ = 1148846080;
										_ = 1;
										_ = 1;
										MultiTargetTween imageTween = Tweens.Add(tweenConfig);
										_imageTween = imageTween;
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

	public override void Fire(bool skipTriggers = false)
	{
		float imageScale = GetImageScale();
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_image, imageScale);
		base.Fire(skipTriggers: true);
	}

	protected override void OnUpdate()
	{
		//IL_0145->IL00ea: Incompatible stack heights: 1 vs 0
		//IL_00a1->IL00ea: Incompatible stack heights: 1 vs 0
		//IL_00d0->IL00ea: Incompatible stack heights: 1 vs 0
		//IL_0194->IL00ea: Incompatible stack heights: 2 vs 0
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)characterController._magnet != null)
		{
			Transform transform = characterController._magnet.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)characterController2._magnet != null)
				{
					Transform transform2 = characterController2._magnet.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
						if ((object)_image != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Cleanup()
	{
		base.Cleanup();
		_imageTween.Kill();
		PhaserSprite phaserSprite = _image.setVisible(visible: false);
		_image.enabled = false;
		_image.destroy();
		_image = null;
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if ((object)_image != null)
		{
			PhaserSprite phaserSprite = _image.setVisible(visible);
		}
	}

	private unsafe float GetImageScale()
	{
		//IL_036a->IL02a4: Incompatible stack heights: 1 vs 0
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
			{
				Sprite image = (Sprite)(object)_image;
				if ((object)_image == null || ((UnityEngine.Object)image).m_CachedPtr == (IntPtr)0)
				{
					goto IL_02a4;
				}
				PhaserSprite image2 = _image;
				if ((object)_image != null)
				{
					Sprite spriteRenderer = (Sprite)(object)image2._spriteRenderer;
					if ((object)image2._spriteRenderer == null || ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0)
					{
						goto IL_02a4;
					}
					PhaserSprite image3 = _image;
					if ((object)_image != null && (object)image3._spriteRenderer != null)
					{
						Sprite sprite = image3._spriteRenderer.sprite;
						if ((object)sprite == null || ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0)
						{
							goto IL_02a4;
						}
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene2 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
							{
								PhaserSprite image4 = _image;
								if ((object)_image != null && (object)image4._spriteRenderer != null)
								{
									Sprite sprite2 = image4._spriteRenderer.sprite;
									if ((object)sprite2 != null)
									{
										bool flag = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
										float ret;
										Sprite.get_bounds_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out *(Bounds*)(&ret));
										goto IL_02a4;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_02a4:
		float num = PArea();
		return 0f / _imagePixelSize;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_024e: Expected I4, but got O
		if (IsFromDarkana)
		{
			if (first != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				GameObject gameObject = default(GameObject);
				if ((object)gameObject != null)
				{
					EnemyController component = gameObject.GetComponent<EnemyController>();
					if ((object)component != null)
					{
						if (component._003CIsDead_003Ek__BackingField)
						{
							goto IL_026d;
						}
						if (second != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							GameObject gameObject2 = default(GameObject);
							if ((object)gameObject2 != null)
							{
								Projectile component2 = gameObject2.GetComponent<Projectile>();
								if ((object)component2 != null)
								{
									if (!component2.HasAlreadyHitObject(component))
									{
										base.DealDamage(component);
									}
									if (component._003CIsDead_003Ek__BackingField)
									{
										float value = UnityEngine.Random.value;
										float2 position = component.position;
										if (0.025f > value)
										{
											if ((object)GM.Core != null)
											{
												Vector2 pos = default(Vector2);
												float value2 = default(float);
												ItemType relicType = default(ItemType);
												bool shouldCallValidatePickups = default(bool);
												bool isRemote = default(bool);
												Pickup pickup = GM.Core.MakePickup(pos, ItemType.BONUS_CURSEDSOUL, WeaponType.VOID, value2, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
												if ((object)pickup != null)
												{
													pickup.GoToPlayer = true;
													pickup.TargetPlayer = ((Equipment)this)._003COwner_003Ek__BackingField;
													pickup.Time = 1f;
													pickup._003CValue_003Ek__BackingField = 0f;
													goto IL_026d;
												}
											}
											goto IL_0240;
										}
									}
									goto IL_026d;
								}
							}
						}
					}
				}
			}
			goto IL_0240;
		}
		return base.OnBulletOverlapsEnemy(context, second, first);
		IL_0240:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_026d:
		return false;
	}
}
