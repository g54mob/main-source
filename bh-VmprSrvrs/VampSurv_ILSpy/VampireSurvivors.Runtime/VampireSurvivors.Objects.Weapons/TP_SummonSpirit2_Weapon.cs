using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_SummonSpirit2_Weapon : TP_SummonSpirit_Weapon
{
	private float _deltaTime;

	private const float Percentage = 0.0625f;

	private const float Radius = 1f;

	private const float SpeedModifier = 25f;

	protected override float2 BulletSpawnPos
	{
		get
		{
			if ((object)_animatedSprite != null)
			{
				return _animatedSprite.position;
			}
			return (float2)new NullReferenceException();
		}
	}

	protected unsafe override SpriteTextureData PortalSprite
	{
		get
		{
			//IL_0063: Expected native int or pointer, but got O
			SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
			if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A14A7]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				SpriteTextureData spriteTextureData = default(SpriteTextureData);
				System.Runtime.CompilerServices.Unsafe.Write(&((SpriteTextureData*)(nint)spriteTextureData)->Sprite, "TP_VFX_Dark01_Inverse");
				return spriteTextureData;
			}
			return (SpriteTextureData)new NullReferenceException();
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		DoTweens();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 25f;
		float num2 = num * 0.0625f;
		float deltaTime2 = num2 + _deltaTime;
		_deltaTime = deltaTime2;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 position2 = default(float2);
		PhaserSprite phaserSprite = _animatedSprite.setPosition(position2);
		Transform transform = _animatedSprite.transform;
		Vector3 localEulerAngles = transform.localEulerAngles;
		float deltaTime3 = PauseSystem.DeltaTime;
		float num3 = deltaTime3 * 180f;
		float angle = localEulerAngles.z - num3;
		_animatedSprite.angle = angle;
	}

	private void DoTweens()
	{
		//IL_001a: Expected O, but got I4
		//IL_0067: Expected I, but got O
		//IL_00bd: Expected O, but got I4
		//IL_00eb: Expected I4, but got I8
		//IL_0107: Expected O, but got I4
		PhaserSprite phaserSprite = _animatedSprite.setScale(0.75f, (float?)(object)0);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_animatedSprite != null)
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
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 600f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.repeat = -1;
		tweenConfig.yoyo = true;
		tweenConfig.angle = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	private void UpdatePortalPosition()
	{
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 25f;
		float num2 = num * 0.0625f;
		float deltaTime2 = num2 + _deltaTime;
		_deltaTime = deltaTime2;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 position2 = default(float2);
		PhaserSprite phaserSprite = _animatedSprite.setPosition(position2);
	}

	private void UpdatePortalRotation()
	{
		Transform transform = _animatedSprite.transform;
		Vector3 localEulerAngles = transform.localEulerAngles;
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 180f;
		float angle = localEulerAngles.z - num;
		_animatedSprite.angle = angle;
	}

	protected override void SetPortalPosition()
	{
	}

	protected override void DoPortalTween()
	{
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				WeaponData currentWeaponData = _currentWeaponData;
				currentWeaponData._003Cpenetrating_003Ek__BackingField = 65535;
				_bonusBounces = 3;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.25f;
			}
		}
		CheckBeginningArcana();
	}

	public TP_SummonSpirit2_Weapon()
	{
		//IL_000b: Expected O, but got I4
		base._bulletStartOffset = (float2)0;
		_ = 1067366482;
		base.emissionDuration = 1000f;
		((Weapon)this)._002Ector();
	}
}
