using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class LEM_Planets1_Weapon : LEM_BaseWeapon
{
	public struct PlanetData
	{
		public string Name;

		public SpriteTextureData SpriteTexture;

		public SpriteTextureData SpriteNegative;

		public SpriteTextureData SpriteCard;

		public float SpriteScale;

		public float BodyRadius;

		public bool FullyRotate;

		public bool CardShown;

		public PlanetData(string name, SpriteTextureData spriteTexture, SpriteTextureData spriteNegative, SpriteTextureData spriteCard, float spriteScale, float bodyRadius, bool fullyRotate = false, bool cardShown = false)
		{
			//IL_0056: Expected O, but got I
			Name = name;
			SpriteTexture = (SpriteTextureData)spriteTexture.Sprite;
			SpriteNegative = (SpriteTextureData)spriteNegative.Sprite;
			IntPtr intPtr = default(IntPtr);
			SpriteCard = (SpriteTextureData)(nint)intPtr;
			bool fullyRotate2 = default(bool);
			FullyRotate = fullyRotate2;
			bool cardShown2 = default(bool);
			CardShown = cardShown2;
			float spriteScale2 = default(float);
			SpriteScale = spriteScale2;
			float bodyRadius2 = default(float);
			BodyRadius = bodyRadius2;
		}
	}

	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public PhaserSprite card;

		public float tweenDuration;

		public LEM_Planets1_Weapon _003C_003E4__this;

		public TweenCallback _003C_003E9__1;

		internal void _003CShowPlanetCard_003Eb__0()
		{
			PhaserSprite phaserSprite = card;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(phaserSprite._spriteRenderer, 0f, tweenDuration);
			TweenCallback tweenCallback = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				tweenCallback = (_003C_003E9__1 = delegate
				{
					_003C_003E4__this.UpdateCards(card, add: false);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
		}

		internal void _003CShowPlanetCard_003Eb__1()
		{
			_003C_003E4__this.UpdateCards(card, add: false);
		}
	}

	private Transform _PlanetContainer;

	private float _TiltSpeedDebug;

	private List<PlanetData> _003CPlanetList_003Ek__BackingField;

	private bool _003CIsNegative_003Ek__BackingField;

	private float _003CTiltAngle_003Ek__BackingField;

	private const float _playerCentreYOffset = 0.16f;

	private const float TiltSpeed = 40f;

	private bool _updatePlanets;

	private List<PhaserSprite> _cards;

	protected Timer _negativeTimer;

	private Timer _updatePlanetsTimer;

	protected Tween _tiltTween;

	public List<PlanetData> PlanetList
	{
		get
		{
			return _003CPlanetList_003Ek__BackingField;
		}
		protected set
		{
			_003CPlanetList_003Ek__BackingField = value;
		}
	}

	public Transform PlanetContainer => _PlanetContainer;

	protected virtual bool ShowBasePlanetCards => true;

	public bool IsNegative
	{
		get
		{
			return _003CIsNegative_003Ek__BackingField;
		}
		protected set
		{
			_003CIsNegative_003Ek__BackingField = value;
		}
	}

	public float TiltAngle
	{
		get
		{
			return _003CTiltAngle_003Ek__BackingField;
		}
		protected set
		{
			_003CTiltAngle_003Ek__BackingField = value;
		}
	}

	public float MaxTiltAngle => 60f;

	private Vector2 PlayerCentre
	{
		get
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Vector2 result = default(Vector2);
				return result;
			}
			return (Vector2)new NullReferenceException();
		}
	}

	private float NegativeDurationMillis
	{
		get
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
			object obj = default(object);
			float num2 = (float)obj * 1000f;
			return num2 + 5000f;
		}
	}

	private float NegativeIntervalMillis
	{
		get
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
			object obj = default(object);
			float num2 = 1f - (float)obj;
			float num3 = num2 * 5000f;
			return 15000f - num3;
		}
	}

	public override float PPower()
	{
		//IL_0064: Invalid comparison between F4 and I4
		//IL_0086: Invalid comparison between I4 and F4
		//IL_022a: Expected F4, but got I4
		//IL_00a3: Expected F4, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config;
		float num;
		float num3;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			config = core._playerOptions.Config;
			if (config != null)
			{
				if (!(config._003CRunCoins_003Ek__BackingField > 0f))
				{
					if (0f < config._003CRunCoins_003Ek__BackingField)
					{
						goto IL_00fd;
					}
					num = 0f;
				}
				else
				{
					if (10000f < config._003CRunCoins_003Ek__BackingField)
					{
						goto IL_00fd;
					}
					float num2 = config._003CRunCoins_003Ek__BackingField / 10000f;
					num = num2 * 0.5f;
					num3 = 10000f;
				}
				goto IL_0210;
			}
		}
		goto IL_01de;
		IL_0210:
		bool flag = !_003CIsNegative_003Ek__BackingField;
		float num4 = 0f;
		if (!flag)
		{
			num4 = 1f;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null)
		{
			float num5 = num + currentWeaponData._003Cpower_003Ek__BackingField;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num6 = num5 + num4;
					float num7 = num6 * num3;
					return num3 + num7;
				}
			}
		}
		goto IL_01de;
		IL_01de:
		throw new NullReferenceException();
		IL_00fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C46650");
		num = config._003CRunCoins_003Ek__BackingField * 0.25f;
		num3 = config._003CRunCoins_003Ek__BackingField;
		goto IL_0210;
	}

	public override float PAmount()
	{
		//IL_0040: Invalid comparison between I4 and F4
		//IL_0096: Expected F4, but got I4
		//IL_0064: Invalid comparison between F4 and I
		//IL_008b: Expected F4, but got I
		List<PlanetData> list = _003CPlanetList_003Ek__BackingField;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)currentWeaponData._003Camount_003Ek__BackingField + (float)obj;
		if (!(0f > num2))
		{
			float num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
			if (num3 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
				num2 = 0f;
			}
			return num2;
		}
		return 0f;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		object planetContainer = _PlanetContainer;
		_003CIsNegative_003Ek__BackingField = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsi_v1 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value);
		_updatePlanets = false;
		if (_updatePlanetsTimer != null)
		{
			_updatePlanetsTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_updatePlanets = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer updatePlanetsTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_updatePlanetsTimer = updatePlanetsTimer;
		AddOuterSaboteur();
	}

	private void DelayInitialPlanets()
	{
		_updatePlanets = false;
		if (_updatePlanetsTimer != null)
		{
			_updatePlanetsTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_updatePlanets = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer updatePlanetsTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_updatePlanetsTimer = updatePlanetsTimer;
	}

	public override void Fire(bool skipTriggers = false)
	{
	}

	public unsafe override void InternalUpdate()
	{
		//IL_017e: Invalid comparison between I4 and F4
		//IL_0132: Invalid comparison between F4 and I
		//IL_00e7: Invalid comparison between F4 and I
		//IL_016d: Expected O, but got Ref
		//IL_0159: Expected F4, but got I
		//IL_010e: Expected F4, but got I
		base.InternalUpdate();
		UpdateProjectileAmount();
		if (!_003CIsNegative_003Ek__BackingField)
		{
			return;
		}
		Vector3 localEulerAngles = _PlanetContainer.localEulerAngles;
		float num = localEulerAngles.z;
		if (localEulerAngles.z > 180f)
		{
			num -= 360f;
		}
		float num2 = ((!(0f > _TiltSpeedDebug)) ? _TiltSpeedDebug : 40f);
		float deltaTime = PauseSystem.DeltaTime;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num3 = deltaTime * num2;
		float num4;
		if (!characterController._isFlipped)
		{
			num4 = num + num3;
			float num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10D08]");
			if (num5 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10D08]");
				num4 = 0f;
			}
		}
		else
		{
			num4 = num - num3;
			float num6 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F8]");
			if (num6 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F8]");
				num4 = 0f;
			}
		}
		_003CTiltAngle_003Ek__BackingField = num4;
		object obj = default(object);
		_PlanetContainer.localEulerAngles = (Vector3)(&obj);
	}

	private void UpdateProjectileAmount()
	{
		//IL_0035: Invalid comparison between F4 and I4
		//IL_0079: Invalid comparison between F4 and I4
		//IL_01c7: Invalid comparison between I4 and F4
		//IL_00bd: Invalid comparison between F4 and I4
		//IL_022d: Invalid comparison between I4 and F4
		//IL_027d: Invalid comparison between F4 and I4
		//IL_010f: Expected O, but got I4
		//IL_0158: Expected O, but got I4
		if (!_updatePlanets)
		{
			return;
		}
		float num = PAmount();
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		if (num == (float)spawnedProjectiles._size)
		{
			return;
		}
		float num2 = PAmount();
		List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		if (!(num2 > (float)spawnedProjectiles2._size))
		{
			float num3 = PAmount();
			List<Projectile> spawnedProjectiles3 = _spawnedProjectiles;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			if (!(num3 < (float)spawnedProjectiles3._size))
			{
				return;
			}
			float num4 = PAmount();
			List<Projectile> spawnedProjectiles4 = _spawnedProjectiles;
			List<Projectile> spawnedProjectiles5 = _spawnedProjectiles;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				if (num4 < (float)spawnedProjectiles4._size)
				{
					object obj = spawnedProjectiles5._size - 1;
					if ((nint)obj < spawnedProjectiles5._size)
					{
						Projectile[] items = spawnedProjectiles5._items;
						object obj2 = spawnedProjectiles5._size - 1;
						items[obj2].Despawn();
						num4 = PAmount();
						spawnedProjectiles5 = _spawnedProjectiles;
						spawnedProjectiles4 = _spawnedProjectiles;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					break;
				}
				break;
			}
			return;
		}
		int num5 = spawnedProjectiles2._size;
		float num6 = PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		if (!((float)spawnedProjectiles2._size < num6))
		{
			return;
		}
		Vector2 pos = default(Vector2);
		float num7;
		do
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Projectile projectile = base.FireOneProjectile(pos, num5);
			if (ShowBasePlanetCards)
			{
				ShowPlanetCard(num5);
			}
			num5++;
			num7 = PAmount();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		}
		while ((float)num5 < num7);
	}

	protected unsafe void ShowPlanetCard(int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_007f: Expected O, but got I
		//IL_0092: Expected O, but got I4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_0142: Expected O, but got I
		//IL_015f: Expected O, but got I4
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_017c: Expected O, but got I
		//IL_024c: Expected O, but got I
		//IL_025f: Expected O, but got I4
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_02a5: Expected O, but got I
		//IL_02a5: Expected O, but got I
		//IL_02fd: Expected O, but got I4
		//IL_0325: Expected O, but got Ref
		//IL_03fd: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass41_0();
		CS_0024_003C_003E8__locals15._003C_003E4__this = this;
		if (index == 0)
		{
			return;
		}
		List<PlanetData> list = _003CPlanetList_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
		if ((nint)index < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+10]");
			object obj3 = 0;
			object obj4 = index * 8;
			object obj5 = index + obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v7+30+v191 @ rcx_v9*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v7+40+v191 @ rcx_v9*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v7+60+v191 @ rcx_v9*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v7+50+v191 @ rcx_v9*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-4F]");
			if ((nint)0 != 0)
			{
				return;
			}
			List<PlanetData> list2 = _003CPlanetList_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
			if ((nint)index < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+10]");
				object obj6 = 0;
				List<PlanetData> list3 = _003CPlanetList_003Ek__BackingField;
				object obj7 = index * 8;
				object obj8 = index + obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v9+60+v192 @ rcx_v10*8]");
				obj = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
				if ((nint)index < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v9+30+v192 @ rcx_v10*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v9+40+v192 @ rcx_v10*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v9+50+v192 @ rcx_v10*8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805FAB00");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
					List<PlanetData> list4 = _003CPlanetList_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ r8_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
					if ((nint)index < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ r8_v7 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+10]");
						object obj9 = 0;
						object obj10 = index * 8;
						object obj11 = index + obj10;
						GameObject gameObject = base.gameObject;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v8+50+v745 @ rdx_v11*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v8+40+v745 @ rdx_v11*8]");
						Vector2 pos = default(Vector2);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, (string)num, (string)0);
						Transform transform = phaserSprite.transform;
						transform.SetParent(_cachedTransform, worldPositionStays: true);
						float2 localPosition = default(float2);
						PhaserSprite phaserSprite2 = phaserSprite.setLocalPosition(localPosition);
						PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
						Transform transform2 = phaserSprite3.transform;
						float2 float5 = default(float2);
						transform2.localEulerAngles = (Vector3)(&float5);
						int depth = 1000 - index;
						PhaserSprite card = phaserSprite3.setDepth(depth);
						CS_0024_003C_003E8__locals15.card = card;
						UpdateCards(CS_0024_003C_003E8__locals15.card, add: true);
						CS_0024_003C_003E8__locals15.tweenDuration = 0.25f;
						Transform target = CS_0024_003C_003E8__locals15.card.transform;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, CS_0024_003C_003E8__locals15.tweenDuration);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
						Tween gameId = default(Tween);
						Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
						Transform target2 = CS_0024_003C_003E8__locals15.card.transform;
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(target2, (Vector3)(&float5), CS_0024_003C_003E8__locals15.tweenDuration, RotateMode.LocalAxisAdd);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
						Tween gameId2 = default(Tween);
						Tween tween2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId2);
						Action onComplete = delegate
						{
							PhaserSprite card2 = CS_0024_003C_003E8__locals15.card;
							TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(card2._spriteRenderer, 0f, CS_0024_003C_003E8__locals15.tweenDuration);
							TweenCallback tweenCallback = CS_0024_003C_003E8__locals15._003C_003E9__1;
							if (CS_0024_003C_003E8__locals15._003C_003E9__1 == null)
							{
								tweenCallback = (CS_0024_003C_003E8__locals15._003C_003E9__1 = delegate
								{
									CS_0024_003C_003E8__locals15._003C_003E4__this.UpdateCards(CS_0024_003C_003E8__locals15.card, add: false);
								});
							}
							if (tweenerCore3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 == 0)
								{
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
						};
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						return;
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void UpdateCards(PhaserSprite card, bool add)
	{
		//IL_01f4: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_00e9: Unsupported input type for neg.
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00f7: Expected O, but got I4
		//IL_0113: Expected F4, but got I4
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		bool flag = default(bool);
		if (!flag)
		{
			bool flag2 = ((List<object>)(object)_cards).Remove((object)card);
			IntPtr intPtr = default(IntPtr);
			int num = (int)(nint)intPtr;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_explosion_release, soundConfig, 250f, 1, time);
			int num = 1;
			float num2 = 250f;
		}
		List<PhaserSprite> cards = _cards;
		if (cards._size > 0)
		{
			int num3 = cards._size >> 31;
			object obj = cards._size - num3;
			object obj2 = obj >> 1;
			int num4 = cards._size & 1;
			object obj3 = 0 - obj2;
			object obj4 = 0;
			Component component = default(Component);
			bool flag3;
			do
			{
				float num5 = ((num4 != 0) ? 0f : 0.5f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Transform target = component.transform;
				object obj5 = obj3 + obj4;
				float num6 = (float)obj5 + num5;
				float endValue = num6 * 0.7f;
				TweenerCore<Vector3, Vector3, VectorOptions> gameId = ShortcutExtensions.DOLocalMoveX(target, endValue, 0.25f);
				Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
				obj4++;
				flag3 = (nint)obj4 < cards._size;
				int num = 0;
				float num2 = 0.25f;
			}
			while (flag3);
		}
	}

	private unsafe void UpdateTilt()
	{
		//IL_016d: Invalid comparison between I4 and F4
		//IL_0121: Invalid comparison between F4 and I
		//IL_00d6: Invalid comparison between F4 and I
		//IL_015c: Expected O, but got Ref
		//IL_0148: Expected F4, but got I
		//IL_00fd: Expected F4, but got I
		if (!_003CIsNegative_003Ek__BackingField)
		{
			return;
		}
		Vector3 localEulerAngles = _PlanetContainer.localEulerAngles;
		float num = localEulerAngles.z;
		if (localEulerAngles.z > 180f)
		{
			num -= 360f;
		}
		float num2 = ((!(0f > _TiltSpeedDebug)) ? _TiltSpeedDebug : 40f);
		float deltaTime = PauseSystem.DeltaTime;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num3 = deltaTime * num2;
		float num4;
		if (!characterController._isFlipped)
		{
			num4 = num + num3;
			float num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10D08]");
			if (num5 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10D08]");
				num4 = 0f;
			}
		}
		else
		{
			num4 = num - num3;
			float num6 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F8]");
			if (num6 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F8]");
				num4 = 0f;
			}
		}
		_003CTiltAngle_003Ek__BackingField = num4;
		object obj = default(object);
		_PlanetContainer.localEulerAngles = (Vector3)(&obj);
	}

	protected void StartNegativeTimer()
	{
		_003CIsNegative_003Ek__BackingField = false;
		if (_negativeTimer != null)
		{
			_negativeTimer.Cancel();
		}
		Action onComplete = delegate
		{
			ToggleNegative();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer negativeTimer = Timers.Register(3.0000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_negativeTimer = negativeTimer;
	}

	private unsafe void ToggleNegative(bool forceNegative = false)
	{
		//IL_07a3: Expected O, but got I4
		//IL_0343: Expected I4, but got O
		//IL_0359: Expected I4, but got O
		//IL_0422: Expected O, but got I4
		//IL_0754: Expected O, but got Ref
		//IL_0148: Expected I4, but got O
		//IL_07e7: Expected I4, but got F4
		//IL_017b: Expected I, but got O
		//IL_0198: Expected O, but got I
		//IL_077e: Expected I4, but got O
		//IL_0218: Expected O, but got I4
		//IL_05a3: Expected I, but got O
		//IL_05b9: Expected O, but got I
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Expected O, but got Unknown
		//IL_0561: Expected I4, but got F4
		//IL_06b6: Expected I4, but got O
		//IL_01d4: Expected O, but got I
		//IL_063d: Expected I, but got O
		//IL_0859: Expected O, but got I4
		//IL_0880: Expected I, but got I8
		//IL_022b: Expected I4, but got O
		//IL_023c: Expected I4, but got O
		//IL_020a: Expected O, but got I4
		//IL_0583: Expected O, but got I4
		//IL_0591: Expected O, but got I4
		//IL_0619: Expected I, but got I8
		//IL_028f: Expected O, but got I4
		//IL_0787->IL0643: Incompatible stack heights: 1 vs 0
		//IL_03f4->IL0427: Incompatible stack heights: 1 vs 0
		bool flag2;
		bool flag = default(bool);
		if (flag)
		{
			flag2 = true;
		}
		else
		{
			bool flag3 = !_003CIsNegative_003Ek__BackingField;
			flag2 = flag3;
		}
		if ((object)this != null)
		{
			_003CIsNegative_003Ek__BackingField = flag2;
			List<Projectile> spawnedProjectiles = _spawnedProjectiles;
			bool flag4 = _spawnedProjectiles == null;
			bool flag5 = false;
			bool flag6 = false;
			if (!flag4)
			{
				object obj4 = default(object);
				float num3 = default(float);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				while (true)
				{
					Projectile[] items;
					bool flag8;
					object obj3;
					if ((flag6 ? 1 : 0) < spawnedProjectiles._size)
					{
						List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
						if (_spawnedProjectiles == null)
						{
							break;
						}
						if ((flag5 ? 1 : 0) < spawnedProjectiles2._size)
						{
							items = spawnedProjectiles2._items;
							if (spawnedProjectiles2._items == null)
							{
								break;
							}
							if ((flag5 ? 1 : 0) < items.Length)
							{
								bool flag7 = (byte)(int)items[flag5 ? 1u : 0u] != 0;
								if ((object)items[flag5 ? 1u : 0u] == null)
								{
									flag8 = false;
									goto IL_06d2;
								}
								nint num = (nint)typeof(LEM_Planets1_Projectile);
								bool value = ((bool*)(flag7 ? 1 : 0))->m_value;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile>)+130]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r9_v16 (System.Boolean)+130]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile>)+130]");
								if (num2 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r9_v16 (System.Boolean)+C8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v109+FFFFFFF8+v559 @ rax_v105*8]");
									if (0 == (nint)typeof(LEM_Planets1_Projectile))
									{
										obj3 = 1;
										goto IL_0699;
									}
								}
								obj3 = 0;
								goto IL_0699;
							}
						}
						else
						{
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						}
						throw new IndexOutOfRangeException();
					}
					if (_tiltTween != null)
					{
						DG.Tweening.TweenExtensions.Kill(_tiltTween);
						flag = false;
					}
					Vector3 vector;
					if (!_003CIsNegative_003Ek__BackingField)
					{
						bool flag9 = (byte)(int)_PlanetContainer != 0;
						_003CTiltAngle_003Ek__BackingField = 0f;
						if ((int)(~_PlanetContainer) != 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rbx_v12 (System.Boolean)+10]");
						bool flag10 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rbx_v12 (System.Boolean)+10]");
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
						Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						vector = Vector3.zeroVector;
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj4), 1f);
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v912 @ rax_v66 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								_ = 3;
								_ = 0;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if ((int)(~tweenerCore) != 0)
						{
							break;
						}
						_tiltTween = tweenerCore;
					}
					else
					{
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Volume = (float?)(object)1;
						soundConfig.Rate = 1f;
						soundConfig.Detune = 700f;
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_negative, soundConfig, 500f, 1, num3);
						vector = (Vector3)0;
					}
					float num6;
					if (_003CIsNegative_003Ek__BackingField)
					{
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
						{
							break;
						}
						float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
						float num5 = (float)vector * 1000f;
						num6 = num5 + 5000f;
					}
					else
					{
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
						{
							break;
						}
						float num7 = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
						float num8 = 1f - (float)vector;
						float num9 = num8 * 5000f;
						float num10 = 15000f - num9;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
						{
							break;
						}
						float num11 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
						float num12 = (float)vector * 1000f;
						float num13 = num12 + 5000f;
						num6 = num10 - num13;
					}
					Timer negativeTimer = _negativeTimer;
					bool flag11 = _negativeTimer == null;
					bool useRealTime = (byte)(int)num3 != 0;
					if (!flag11)
					{
						useRealTime = (byte)(int)num3 != 0;
						if (!_negativeTimer.IsDone)
						{
							float timeElapsed = _negativeTimer.GetTimeElapsed();
							negativeTimer._timeElapsedBeforeCancel = (float?)(object)1;
							negativeTimer._timeElapsedBeforePause = (float?)(object)0;
						}
					}
					Action action = null;
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ r10_v1 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(LEM_Planets1_Weapon._003CToggleNegative_003Eb__45_0);
					((Delegate)action).m_target = this;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ r10_v1 (Il2CppMethodInfo)+4C]");
					object obj5 = (nint)0 >> 4;
					object obj6 = obj5 & 1;
					nint num15;
					if (obj6 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ r10_v1 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num15 = unchecked((nint)6447293664L);
							goto IL_0850;
						}
					}
					num15 = ((Delegate)action).method_ptr;
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					goto IL_0850;
					IL_06d2:
					if (flag8)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rbx_v15 (System.Boolean)+10]");
						if ((nint)0 != 0)
						{
							flag = _003CIsNegative_003Ek__BackingField;
							((LEM_Planets1_Projectile)flag8).SetNegative(_003CIsNegative_003Ek__BackingField);
						}
					}
					spawnedProjectiles = _spawnedProjectiles;
					flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
					if (_spawnedProjectiles == null)
					{
						break;
					}
					flag6 = flag5;
					continue;
					IL_0850:
					object obj7 = 24;
					float duration = num6 * 0.001f;
					((Delegate)action).extra_arg = unchecked((nint)6447293568L);
					Timer negativeTimer2 = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_negativeTimer = negativeTimer2;
					return;
					IL_0699:
					bool flag12 = obj3 == null;
					flag = (byte)(int)typeof(LEM_Planets1_Projectile) != 0;
					flag8 = false;
					if (!flag12)
					{
						flag = (byte)(int)typeof(LEM_Planets1_Projectile) != 0;
						flag8 = (byte)(int)items[flag5 ? 1u : 0u] != 0;
					}
					goto IL_06d2;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void PlayCardSfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_explosion_release, soundConfig, 250f, 1, time);
	}

	private void PlayNegativeSfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = 700f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_negative, soundConfig, 500f, 1, time);
	}

	public void ForceNegative()
	{
		ToggleNegative(forceNegative: true);
	}

	public override void SetVisible(bool visible)
	{
		//IL_0038: Expected O, but got I4
		//IL_00f8: Expected O, but got I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		_isVisible = visible;
		if (visible)
		{
			return;
		}
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			goto IL_00c5;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] >= 0)
			{
				continue;
			}
			goto IL_00c5;
		}
		goto IL_022a;
		IL_00c5:
		List<PhaserSprite> cards = _cards;
		bool flag2 = (nint)_cards < 0;
		object obj2 = cards._size - 1;
		if (flag2)
		{
			goto IL_018e;
		}
		while (true)
		{
			List<PhaserSprite> cards2 = _cards;
			if ((nint)obj2 >= cards2._size)
			{
				break;
			}
			PhaserSprite[] items2 = cards2._items;
			PhaserSprite phaserSprite = items2[obj2].setVisible(visible: false);
			obj2--;
			if ((nint)items2[obj2] >= 0)
			{
				continue;
			}
			goto IL_018e;
		}
		goto IL_022a;
		IL_022a:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_018e:
		List<PhaserSprite> cards3 = _cards;
		int version = cards3._version + 1;
		cards3._version = version;
		cards3._size = 0;
		if (cards3._size > 0)
		{
			Array.Clear(cards3._items, 0, cards3._size);
		}
	}

	public override void Cleanup()
	{
		if (_negativeTimer != null)
		{
			_negativeTimer.Cancel();
		}
		if (_updatePlanetsTimer != null)
		{
			_updatePlanetsTimer.Cancel();
		}
		if (_tiltTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_tiltTween);
		}
		base.Cleanup();
	}

	public unsafe LEM_Planets1_Weapon()
	{
		//IL_0008: Expected O, but got Ref
		//IL_012a: Expected O, but got I4
		//IL_019a: Expected O, but got I
		//IL_023a: Expected O, but got I
		//IL_024d: Expected O, but got Ref
		//IL_0212: Expected O, but got Ref
		//IL_0411: Expected O, but got I
		//IL_04b9: Expected O, but got I
		//IL_04cc: Expected O, but got Ref
		//IL_0491: Expected O, but got Ref
		//IL_0f9d: Expected O, but got Ref
		//IL_0fe5: Expected O, but got Ref
		//IL_0fe5: Expected O, but got Ref
		//IL_0fe0: Expected native int or pointer, but got O
		//IL_0ff3: Expected O, but got Ref
		//IL_108e: Expected O, but got Ref
		//IL_10d6: Expected O, but got Ref
		//IL_10d6: Expected O, but got Ref
		//IL_10d1: Expected native int or pointer, but got O
		//IL_10e4: Expected O, but got Ref
		//IL_117f: Expected O, but got Ref
		//IL_11c7: Expected O, but got Ref
		//IL_11c7: Expected O, but got Ref
		//IL_11c2: Expected native int or pointer, but got O
		//IL_11d5: Expected O, but got Ref
		//IL_1270: Expected O, but got Ref
		//IL_12b8: Expected O, but got Ref
		//IL_12b8: Expected O, but got Ref
		//IL_12b3: Expected native int or pointer, but got O
		//IL_12c6: Expected O, but got Ref
		//IL_1361: Expected O, but got Ref
		//IL_13a9: Expected O, but got Ref
		//IL_13a9: Expected O, but got Ref
		//IL_13a4: Expected native int or pointer, but got O
		//IL_13b7: Expected O, but got Ref
		//IL_1452: Expected O, but got Ref
		//IL_149a: Expected O, but got Ref
		//IL_149a: Expected O, but got Ref
		//IL_1495: Expected native int or pointer, but got O
		//IL_14a8: Expected O, but got Ref
		//IL_1543: Expected O, but got Ref
		//IL_158b: Expected O, but got Ref
		//IL_158b: Expected O, but got Ref
		//IL_1586: Expected native int or pointer, but got O
		//IL_1599: Expected O, but got Ref
		//IL_0dfa: Expected O, but got I
		//IL_0ea2: Expected O, but got I
		//IL_0eb5: Expected O, but got Ref
		//IL_0e7a: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_TiltSpeedDebug = -1f;
		List<PlanetData> list = new List<PlanetData>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E72]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj3 = "LEM_VFX_Rocket";
		if (SpriteTextures.Lemon.LEM_Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E73]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			object obj4 = "LEM_VFX_Rocket_Negative";
			if (SpriteTextures.Base.Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				object obj5 = "WhiteDot";
				_ = 0;
				_ = 0;
				obj = 0;
				_ = 0;
				_ = 0;
				_ = 1048576000;
				_ = 1094713344;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r9_v5+18]");
				if (num >= 0)
				{
					list.AddWithResize((PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128)));
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
					object obj7 = (nint)0 + (nint)1;
					object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805FAB00");
				}
				if (SpriteTextures.Lemon.LEM_Vfx != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E64]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					obj5 = "LEM_VFX_Planet_Mercury";
					if (SpriteTextures.Lemon.LEM_Vfx != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E65]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						obj4 = "LEM_VFX_Planet_Mercury_Negative";
						if (SpriteTextures.Lemon.LEM_Vfx != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E48]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							obj3 = "LEM_VFX_Card_Mercury";
							_ = 0;
							_ = 0;
							_ = 0;
							_ = 0;
							_ = 0;
							_ = 1056964608;
							_ = 1090519040;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+10]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ r9_v9+18]");
							if (num2 >= 0)
							{
								list.AddWithResize((PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128)));
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
								object obj10 = (nint)0 + (nint)1;
								object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805FAB00");
							}
							if (SpriteTextures.Lemon.LEM_Vfx != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E6E]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (SpriteTextures.Lemon.LEM_Vfx != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E6F]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									obj3 = "LEM_VFX_Planet_Venus_Negative";
									if (SpriteTextures.Lemon.LEM_Vfx != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E4E]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
										PlanetData planetData = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
										_ = 0;
										_ = 0;
										_ = 0;
										_ = 0;
										_ = 0;
										SpriteTextureData spriteCard = default(SpriteTextureData);
										float spriteScale = default(float);
										float bodyRadius = default(float);
										bool fullyRotate = default(bool);
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)planetData, new PlanetData("Venus", (SpriteTextureData)(&obj4), (SpriteTextureData)(&obj3), spriteCard, spriteScale, bodyRadius, fullyRotate, (byte)(&obj5) != 0));
										PlanetData item = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
										_ = 0;
										list.Add(item);
										if (SpriteTextures.Lemon.LEM_Vfx != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E5C]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
											SpriteTextures.SpriteTexturesLemon lemon = SpriteTextures.Lemon;
											if (lemon.LEM_Vfx != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E5D]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
												SpriteTextures.SpriteTexturesLemon lemon2 = SpriteTextures.Lemon;
												if (lemon2.LEM_Vfx != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E44]");
													if ((nint)0 == 0)
													{
														_ = 1;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
													PlanetData planetData2 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
													_ = 0;
													_ = 0;
													_ = 0;
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)planetData2, new PlanetData("Earth", (SpriteTextureData)(&obj5), (SpriteTextureData)(&obj4), spriteCard, spriteScale, bodyRadius, fullyRotate, (byte)(&obj3) != 0));
													PlanetData item2 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
													_ = 0;
													list.Add(item2);
													if (SpriteTextures.Lemon.LEM_Vfx != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E62]");
														if ((nint)0 == 0)
														{
															_ = 1;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
														SpriteTextures.SpriteTexturesLemon lemon3 = SpriteTextures.Lemon;
														if (lemon3.LEM_Vfx != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E63]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
															SpriteTextures.SpriteTexturesLemon lemon4 = SpriteTextures.Lemon;
															if (lemon4.LEM_Vfx != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E47]");
																if ((nint)0 == 0)
																{
																	_ = 1;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																PlanetData planetData3 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
																_ = 0;
																_ = 0;
																_ = 0;
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)planetData3, new PlanetData("Mars", (SpriteTextureData)(&obj5), (SpriteTextureData)(&obj4), spriteCard, spriteScale, bodyRadius, fullyRotate, (byte)(&obj3) != 0));
																PlanetData item3 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+160]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+170]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
																_ = 0;
																list.Add(item3);
																if (SpriteTextures.Lemon.LEM_Vfx != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E60]");
																	if ((nint)0 == 0)
																	{
																		_ = 1;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																	SpriteTextures.SpriteTexturesLemon lemon5 = SpriteTextures.Lemon;
																	if (lemon5.LEM_Vfx != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E61]");
																		if ((nint)0 == 0)
																		{
																			_ = 1;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																		SpriteTextures.SpriteTexturesLemon lemon6 = SpriteTextures.Lemon;
																		if (lemon6.LEM_Vfx != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E46]");
																			if ((nint)0 == 0)
																			{
																				_ = 1;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																			PlanetData planetData4 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432));
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			_ = 0;
																			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)planetData4, new PlanetData("Jupiter", (SpriteTextureData)(&obj5), (SpriteTextureData)(&obj4), spriteCard, spriteScale, bodyRadius, fullyRotate, (byte)(&obj3) != 0));
																			PlanetData item4 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1C0]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1F0]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1E0]");
																			_ = 0;
																			list.Add(item4);
																			if (SpriteTextures.Lemon.LEM_Vfx != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E6A]");
																				if ((nint)0 == 0)
																				{
																					_ = 1;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																				SpriteTextures.SpriteTexturesLemon lemon7 = SpriteTextures.Lemon;
																				if (lemon7.LEM_Vfx != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E6B]");
																					if ((nint)0 == 0)
																					{
																						_ = 1;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																					SpriteTextures.SpriteTexturesLemon lemon8 = SpriteTextures.Lemon;
																					if (lemon8.LEM_Vfx != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E4C]");
																						if ((nint)0 == 0)
																						{
																							_ = 1;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																						PlanetData planetData5 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 512));
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)planetData5, new PlanetData("Saturn", (SpriteTextureData)(&obj5), (SpriteTextureData)(&obj4), spriteCard, spriteScale, bodyRadius, fullyRotate, (byte)(&obj3) != 0));
																						PlanetData item5 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+200]");
																						_ = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+220]");
																						_ = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+210]");
																						_ = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+240]");
																						_ = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+230]");
																						_ = 0;
																						list.Add(item5);
																						if (SpriteTextures.Lemon.LEM_Vfx != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E6C]");
																							if ((nint)0 == 0)
																							{
																								_ = 1;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																							SpriteTextures.SpriteTexturesLemon lemon9 = SpriteTextures.Lemon;
																							if (lemon9.LEM_Vfx != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E6D]");
																								if ((nint)0 == 0)
																								{
																									_ = 1;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																								SpriteTextures.SpriteTexturesLemon lemon10 = SpriteTextures.Lemon;
																								if (lemon10.LEM_Vfx != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E4D]");
																									if ((nint)0 == 0)
																									{
																										_ = 1;
																									}
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																									PlanetData planetData6 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 592));
																									_ = 0;
																									_ = 0;
																									_ = 0;
																									_ = 0;
																									_ = 0;
																									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)planetData6, new PlanetData("Uranus", (SpriteTextureData)(&obj5), (SpriteTextureData)(&obj4), spriteCard, spriteScale, bodyRadius, fullyRotate, (byte)(&obj3) != 0));
																									PlanetData item6 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+250]");
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+270]");
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+260]");
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+290]");
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+280]");
																									_ = 0;
																									list.Add(item6);
																									if (SpriteTextures.Lemon.LEM_Vfx != null)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E66]");
																										if ((nint)0 == 0)
																										{
																											_ = 1;
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																										SpriteTextures.SpriteTexturesLemon lemon11 = SpriteTextures.Lemon;
																										if (lemon11.LEM_Vfx != null)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E67]");
																											if ((nint)0 == 0)
																											{
																												_ = 1;
																											}
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																											SpriteTextures.SpriteTexturesLemon lemon12 = SpriteTextures.Lemon;
																											if (lemon12.LEM_Vfx != null)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E49]");
																												if ((nint)0 == 0)
																												{
																													_ = 1;
																												}
																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																												PlanetData planetData7 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 672));
																												_ = 0;
																												_ = 0;
																												_ = 0;
																												_ = 0;
																												_ = 0;
																												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)planetData7, new PlanetData("Neptune", (SpriteTextureData)(&obj5), (SpriteTextureData)(&obj4), spriteCard, spriteScale, bodyRadius, fullyRotate, (byte)(&obj3) != 0));
																												PlanetData item7 = (PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+2A0]");
																												_ = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+2C0]");
																												_ = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+2B0]");
																												_ = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+2E0]");
																												_ = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+2D0]");
																												_ = 0;
																												list.Add(item7);
																												if (SpriteTextures.Lemon.LEM_Vfx != null)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E68]");
																													if ((nint)0 == 0)
																													{
																														_ = 1;
																													}
																													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
																													SpriteTextures.SpriteTexturesLemon lemon13 = SpriteTextures.Lemon;
																													if (lemon13.LEM_Vfx != null)
																													{
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E69]");
																														if ((nint)0 == 0)
																														{
																															_ = 1;
																														}
																														obj4 = "LEM_VFX_Planet_Pluto_Negative";
																														if (SpriteTextures.Lemon.LEM_Vfx != null)
																														{
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E4B]");
																															if ((nint)0 == 0)
																															{
																																_ = 1;
																															}
																															_ = 0;
																															_ = 0;
																															_ = 0;
																															_ = 0;
																															_ = 0;
																															_ = 0;
																															_ = 1056964608;
																															_ = 1090519040;
																															_ = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+1C]");
																															_ = (nint)0 + (nint)1;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+10]");
																															object obj12 = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
																															_ = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
																															_ = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
																															_ = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
																															_ = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
																															_ = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
																															nint num3 = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r9_v42+18]");
																															if (num3 >= 0)
																															{
																																list.AddWithResize((PlanetData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128)));
																															}
																															else
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
																																object obj13 = (nint)0 + (nint)1;
																																object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
																																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805FAB00");
																															}
																															_003CPlanetList_003Ek__BackingField = list;
																															_cards = new List<PhaserSprite>();
																															((Weapon)this)._002Ector();
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

	private void _003CDelayInitialPlanets_003Eb__37_0()
	{
		_updatePlanets = true;
	}

	private void _003CStartNegativeTimer_003Eb__44_0()
	{
		ToggleNegative();
	}

	private void _003CToggleNegative_003Eb__45_0()
	{
		ToggleNegative();
	}
}
