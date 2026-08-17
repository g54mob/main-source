using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Shield1_Old_Projectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private Vector3 _offsetLeft;

	private Vector3 _offsetRight;

	private Vector3 _offsetPos;

	private bool _storedFlip;

	private int _hitCounter;

	private float _moveSpeedPerc = 1f;

	private PhaserSprite _greyscaleSprite;

	private bool _despawning;

	private Timer _despawnTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Medusa1_0", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite greyscaleSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "Medusa1");
		_greyscaleSprite = greyscaleSprite;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0278: Expected O, but got I4
		//IL_0390: Expected O, but got I
		//IL_0371: Expected O, but got I
		//IL_0426->IL03c5: Incompatible stack heights: 1 vs 0
		//IL_0265->IL03c5: Incompatible stack heights: 1 vs 0
		//IL_0294->IL03c5: Incompatible stack heights: 1 vs 0
		//IL_049f->IL03c5: Incompatible stack heights: 2 vs 0
		//IL_02c0->IL03c5: Incompatible stack heights: 2 vs 0
		//IL_0305->IL03c5: Incompatible stack heights: 2 vs 0
		//IL_0327->IL03c5: Incompatible stack heights: 2 vs 0
		//IL_04ec->IL03c5: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			int num = ((Equipment)weapon)._003COwner_003Ek__BackingField.depth;
			if ((object)_greyscaleSprite != null)
			{
				int num2 = num + 2;
				PhaserSprite phaserSprite = _greyscaleSprite.setDepth(num2);
				if ((object)_greyscaleSprite != null)
				{
					PhaserSprite phaserSprite2 = _greyscaleSprite.setAlpha(0f);
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							characterController.MoveSpeedMultiplier = 1f;
							Weapon weapon3 = _weapon;
							if ((object)_weapon != null)
							{
								VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
								if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
								{
									characterController2.ArmorManualIncrease = 0f;
									ArcadeSprite arcadeSprite = ((Equipment)weapon)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
									{
										((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
										if ((object)arcadeSprite._spriteRenderer != null)
										{
											Sprite sprite = arcadeSprite._spriteRenderer.sprite;
											if ((object)sprite != null)
											{
												bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
												Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
												Weapon weapon4 = (Weapon)(object)((Equipment)weapon)._003COwner_003Ek__BackingField;
												if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
												{
													((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
													if (((Equipment)weapon4)._equipmentType != WeaponType.VOID)
													{
														Sprite sprite2 = ((SpriteRenderer)((Equipment)weapon4)._equipmentType).sprite;
														if ((object)sprite2 != null)
														{
															bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
															Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret);
															Weapon weapon5 = _weapon;
															Vector3 vector = default(Vector3);
															_offsetLeft = vector;
															_offsetRight = vector;
															_ = 0;
															_ = 0;
															if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
															{
																bool storedFlip = ((Equipment)weapon5)._003COwner_003Ek__BackingField.flipX;
																Weapon weapon6 = _weapon;
																_storedFlip = storedFlip;
																if ((object)_weapon != null && (object)((Equipment)weapon6)._003COwner_003Ek__BackingField != null)
																{
																	Vector3 offsetPos;
																	if (((Equipment)weapon6)._003COwner_003Ek__BackingField.flipX)
																	{
																		offsetPos = _offsetLeft;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Shield1_Old_Projectile)+E8]");
																		object obj = 0;
																	}
																	else
																	{
																		offsetPos = _offsetRight;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Shield1_Old_Projectile)+F4]");
																		object obj = 0;
																	}
																	_offsetPos = offsetPos;
																	bool flag3 = !_storedFlip;
																	ArcadeSprite arcadeSprite2 = setFlipX(flag3);
																	if ((object)_greyscaleSprite != null)
																	{
																		bool flag4 = !_storedFlip;
																		PhaserSprite phaserSprite3 = _greyscaleSprite.setFlipX(flag4);
																		_hitCounter = 0;
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
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		//IL_0191: Expected O, but got I
		//IL_0172: Expected O, but got I
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
			if (flag == _storedFlip)
			{
				goto IL_01bf;
			}
			Weapon weapon2 = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				bool storedFlip = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX;
				Weapon weapon3 = _weapon;
				_storedFlip = storedFlip;
				if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
				{
					Vector3 offsetPos;
					if (((Equipment)weapon3)._003COwner_003Ek__BackingField.flipX)
					{
						offsetPos = _offsetLeft;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Shield1_Old_Projectile)+E8]");
						object obj = 0;
					}
					else
					{
						offsetPos = _offsetRight;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Shield1_Old_Projectile)+F4]");
						object obj = 0;
					}
					_offsetPos = offsetPos;
					bool flag2 = !_storedFlip;
					ArcadeSprite arcadeSprite = setFlipX(flag2);
					if ((object)_greyscaleSprite != null)
					{
						bool flag3 = !_storedFlip;
						PhaserSprite phaserSprite = _greyscaleSprite.setFlipX(flag3);
						goto IL_01bf;
					}
				}
			}
		}
		goto IL_0228;
		IL_0228:
		throw new NullReferenceException();
		IL_01bf:
		Transform transform = base.transform;
		if ((object)_weapon != null)
		{
			Transform transform2 = _weapon.transform;
			if ((object)transform2 != null)
			{
				bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag5 = (object)transform == null;
				bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		goto IL_0228;
	}

	public override void InternalUpdate()
	{
		//IL_005b: Invalid comparison between F4 and I4
		//IL_0094: Invalid comparison between F4 and I
		//IL_00bb: Expected F4, but got I
		if (_despawning)
		{
			return;
		}
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018715DAA9h\"");
		float num;
		if (characterController._walked == 0f)
		{
			num = _moveSpeedPerc * 0.99f;
			float num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
			if (num2 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
				num = 0f;
			}
		}
		else
		{
			num = _moveSpeedPerc * 1.01f;
			if (num > 1f)
			{
				num = 1f;
			}
		}
		_moveSpeedPerc = num;
		float alpha = 1f - num;
		PhaserSprite phaserSprite = _greyscaleSprite.setAlpha(alpha);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		characterController2.MoveSpeedMultiplier = _moveSpeedPerc;
		Weapon weapon3 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
		float num3 = 1f - _moveSpeedPerc;
		float armorManualIncrease = num3 * 10f;
		characterController3.ArmorManualIncrease = armorManualIncrease;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		int num = ++_hitCounter;
		float num2 = _weapon.PAmount();
		object obj = default(object);
		if (num > (nint)obj)
		{
			Despawn();
		}
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		int num = ++_hitCounter;
		float num2 = _weapon.PAmount();
		object obj = default(object);
		if (num > (nint)obj)
		{
			Despawn();
		}
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
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		PhaserSprite phaserSprite = _greyscaleSprite.setAlpha(0f);
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		characterController.MoveSpeedMultiplier = 1f;
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		characterController2.ArmorManualIncrease = 0f;
		base.Despawn();
	}
}
