using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Holy1_Weapon : Weapon
{
	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private string _cursorTexture;

	private string _cursorSprite;

	private Vector2 _cursorOffset;

	private float _cursorMinAlpha;

	[NonSerialized]
	public static float staticTotalTime;

	protected WeaponType _counterWeaponType;

	protected Weapon _counterWeapon;

	protected SantaJavelinCounterWeapon _counterSet;

	protected bool _hasCounterSet;

	public virtual bool IsPrimaryWeapon => true;

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(7f > num2);
		float result = 7f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	protected override void Awake()
	{
		base.Awake();
		if (IsPrimaryWeapon)
		{
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, _cursorTexture, _cursorSprite);
			_cursor = cursor;
			PhaserSprite phaserSprite = _cursor.setDepth(1);
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
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
		PhaserSprite cursor = _cursor;
		if ((object)_cursor != null && ((UnityEngine.Object)cursor).m_CachedPtr != (IntPtr)0)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			PhaserSprite phaserSprite = _cursor.setPosition(position);
			PhaserSprite phaserSprite2 = _cursor.setAlpha(_cursorMinAlpha);
		}
	}

	public override void InternalUpdate()
	{
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
		if (IsPrimaryWeapon)
		{
			float num3 = 1f - _cursorMinAlpha;
			float num4 = num3 * base._003CTotalTime_003Ek__BackingField;
			float num5 = num4 / deltaTime;
			float alpha = num5 + _cursorMinAlpha;
			PhaserSprite phaserSprite = _cursor.setAlpha(alpha);
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			PhaserSprite phaserSprite2 = _cursor.setPosition(position);
			float2 localPosition = default(float2);
			PhaserSprite phaserSprite3 = _cursor.setLocalPosition(localPosition);
		}
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
		//IL_002a: Expected O, but got F4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00e9: Invalid comparison between O and F4
		//IL_0186: Expected O, but got F4
		//IL_0095: Expected F4, but got I4
		//IL_013f: Expected I, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num = default(float);
		Projectile projectile = base.FireOneProjectile((Vector2)num, 0, _targetTransform);
		bool isPrimaryWeapon = IsPrimaryWeapon;
		bool flag = !isPrimaryWeapon;
		float num2 = num;
		float num4 = default(float);
		float num3 = num4;
		if (!flag)
		{
			object obj = UnityEngine.Random.value;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Heal, 1000f, 1, 0f, volume, rate, detune, loop, 1f);
			num2 = 1f;
			num3 = 1000f;
		}
		float num5 = base.PInterval();
		float num6 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num6 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num7 = base.PInterval();
			_lastFiringInterval = num2;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		if (IsPrimaryWeapon)
		{
			Fire_FireCounter(skipTriggers);
			nint num8 = (nint)this;
			float num9 = base.PDuration();
			float num10 = num2 / 250f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
			int times = default(int);
			DisplayCursorVFX(times, 250f);
		}
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
		if (IsPrimaryWeapon)
		{
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj > -1)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
				if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
				{
					return;
				}
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
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager2 = core3._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			_explodeOnExpire = true;
		}
	}

	private unsafe void DisplayCursorVFX(int _times, float _duration)
	{
		//IL_0112: Expected O, but got Ref
		//IL_0169->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00e8->IL0113: Incompatible stack heights: 1 vs 0
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.SpellcastingCursor);
			if ((object)pool != null)
			{
				SpellcastingCursorVFX objectComponent = pool.GetObjectComponent<SpellcastingCursorVFX>();
				if ((object)_cursor != null)
				{
					Transform transform = _cursor.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)_cursor != null)
						{
							Transform transform2 = _cursor.transform;
							if ((object)transform2 != null)
							{
								Vector3 localEulerAngles = transform2.localEulerAngles;
								if ((object)objectComponent != null)
								{
									object obj = default(object);
									float angle = default(float);
									string texture = default(string);
									string frame = default(string);
									bool flip = default(bool);
									objectComponent.Display(_times, _duration, (Vector3)(&obj), angle, texture, frame, flip);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		PhaserSprite cursor = _cursor;
		_isVisible = visible;
		if ((object)_cursor != null && ((UnityEngine.Object)cursor).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _cursor.setVisible(visible);
		}
	}

	public TP_Holy1_Weapon()
	{
		//IL_0010: Expected O, but got I4
		_cursorTexture = "ThosePeople";
		_cursorSprite = "TP_VFX_Holy06";
		_cursorOffset = (Vector2)0;
		_ = 3184315597L;
		_cursorMinAlpha = 0.15f;
		_counterWeaponType = WeaponType.TP_HOLY1_COUNTER;
		base._002Ector();
	}
}
