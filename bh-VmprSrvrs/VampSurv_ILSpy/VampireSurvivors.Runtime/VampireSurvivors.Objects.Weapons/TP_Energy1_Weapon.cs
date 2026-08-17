using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Energy1_Weapon : Weapon
{
	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	[NonSerialized]
	public static float staticTotalTime;

	protected WeaponType _counterWeaponType = WeaponType.TP_ENERGY1_COUNTER;

	protected Weapon _counterWeapon;

	protected SantaJavelinCounterWeapon _counterSet;

	protected bool _hasCounterSet;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	protected override void Awake()
	{
		base.Awake();
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Ice07");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
		PhaserSprite phaserSprite2 = _cursor.setVisible(visible: false);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!IsPrimaryWeapon)
		{
			base._003CTotalTime_003Ek__BackingField = staticTotalTime;
		}
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
	}

	public override void InternalUpdate()
	{
		//IL_023c: Invalid comparison between I4 and F4
		//IL_035d->IL027f: Incompatible stack heights: 1 vs 0
		//IL_0177->IL027f: Incompatible stack heights: 1 vs 0
		//IL_01a6->IL027f: Incompatible stack heights: 1 vs 0
		//IL_0409->IL027f: Incompatible stack heights: 2 vs 0
		//IL_03c0->IL027f: Incompatible stack heights: 2 vs 0
		//IL_01de->IL027f: Incompatible stack heights: 2 vs 0
		//IL_0210->IL027f: Incompatible stack heights: 2 vs 0
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			if (IsPrimaryWeapon)
			{
				base.Fire();
			}
		}
		if (IsPrimaryWeapon)
		{
			staticTotalTime = base._003CTotalTime_003Ek__BackingField;
		}
		bool flipX2 = default(bool);
		if ((object)_cursor != null)
		{
			float num3 = base._003CTotalTime_003Ek__BackingField * 0.85f;
			float num4 = num3 / deltaTime;
			float alpha = num4 + 0.15f;
			PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
				ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
					if ((object)arcadeSprite._spriteRenderer != null)
					{
						Sprite sprite = arcadeSprite._spriteRenderer.sprite;
						if ((object)sprite != null)
						{
							bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
							ArcadeSprite arcadeSprite2 = ((Equipment)this)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
								if ((object)arcadeSprite2._spriteRenderer != null)
								{
									Sprite sprite2 = arcadeSprite2._spriteRenderer.sprite;
									if ((object)sprite2 != null)
									{
										bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret);
										if (flipX)
										{
											goto IL_03a6;
										}
										float playerFacing = PlayerFacing;
										if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
										{
											float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
											if ((object)_cursor != null)
											{
												PhaserSprite phaserSprite2 = _cursor.setPosition(position);
												if ((object)_cursor != null)
												{
													float2 localPosition = default(float2);
													PhaserSprite phaserSprite3 = _cursor.setLocalPosition(localPosition);
													float playerFacing2 = PlayerFacing;
													bool flag3 = 0f > -1f;
													flipX2 = flipX;
													if (!flag3)
													{
														flipX2 = (byte)((flipX ? 1u : 0u) ^ 1u) != 0;
													}
													goto IL_03a6;
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
		goto IL_027f;
		IL_03a6:
		if ((object)_cursor != null)
		{
			PhaserSprite phaserSprite4 = _cursor.setFlipX(flipX2);
			return;
		}
		goto IL_027f;
		IL_027f:
		throw new NullReferenceException();
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0118: Expected O, but got F4
		//IL_007b: Expected F4, but got I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00b8: Invalid comparison between O and F4
		float2 position = _cursor.position;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
		Projectile projectile2 = base.FireOneProjectile(pos, 1, _targetTransform);
		object obj = UnityEngine.Random.value;
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Globus, 200f, 10, 0f, volume, rate, detune, loop, 1f);
		float num = base.PInterval();
		float num3 = default(float);
		float num2 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num4 = base.PInterval();
			_lastFiringInterval = num3;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		if (IsPrimaryWeapon)
		{
			Fire_FireCounter(skipTriggers);
		}
	}

	public void FireProjectiles(Vector2 pos)
	{
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
		Projectile projectile2 = base.FireOneProjectile(pos, 1, _targetTransform);
	}

	protected void Fire_FireCounter(bool skipTriggers = false)
	{
		if (!_hasCounterSet)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				_hasCounterSet = true;
				_counterWeapon = weaponByType;
				_counterWeapon.Cleanup();
				GameObject gameObject = _counterWeapon.gameObject;
				gameObject.SetActive(value: true);
			}
		}
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			_counterWeapon.Fire(skipTriggers);
		}
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		if (!IsPrimaryWeapon)
		{
			return;
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj <= -1)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType == null || ((UnityEngine.Object)weaponByType).m_CachedPtr == (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			bool allowDuplicates = default(bool);
			Weapon weapon = (_counterWeapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates));
			while (((Equipment)weapon)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
			{
				bool flag = weapon.LevelUp(skipFire: true);
			}
			GM.Core.SetSeenWeapon(_counterWeaponType);
		}
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _cursor.setVisible(visible);
	}
}
