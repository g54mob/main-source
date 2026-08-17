using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class Cart2EvoWeapon : Weapon
{
	private const float CartWidth = 3.1f;

	private const float LightWidth = 2.6f;

	private Camera _mainCamera;

	private Transform _topTrackContainer;

	private Transform _bottomTrackContainer;

	private List<PhaserSprite> _topTracks;

	private List<PhaserSprite> _bottomTracks;

	private int _fireCounter;

	private bool _hasImage;

	private bool _hasCharacterImage;

	private PhaserSprite _backSprite;

	private Cart2Weapon _cartWeapon;

	private bool _totalDamageCalculated;

	private readonly float _003CScaleMultiplier_003Ek__BackingField;

	public float ScaleMultiplier => _003CScaleMultiplier_003Ek__BackingField;

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = _currentWeaponData == null;
		float num2 = default(float);
		float num = num2;
		if (!flag)
		{
			float num3 = base.PDuration();
			float num4 = PSpeed();
			float num5 = PArea();
			bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num = num2;
			if (!flag2)
			{
				num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num6 = num2 * 0.001f;
					float num7 = num6 + currentWeaponData._003Cpower_003Ek__BackingField;
					float num8 = num7 + num2;
					float num9 = num8 + num2;
					float num10 = num9 * num;
					return num + num10;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override float PArea()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		return currentWeaponData._003Carea_003Ek__BackingField;
	}

	public override float PSpeed()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		return currentWeaponData._003Cspeed_003Ek__BackingField;
	}

	protected override void Awake()
	{
		base.Awake();
		Camera main = Camera.main;
		_mainCamera = main;
	}

	protected override void OnStart()
	{
		base.OnStart();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x18739D690\"");
	}

	private void CreateDetachedCartWeapon()
	{
		//IL_0059: Expected I, but got O
		//IL_0067: Expected I, but got O
		//IL_0077: Expected O, but got I
		//IL_00f7: Expected O, but got I4
		//IL_00b3: Expected O, but got I
		//IL_00e9: Expected O, but got I4
		//IL_0203: Expected I, but got O
		//IL_0211: Expected I, but got O
		//IL_0221: Expected O, but got I
		//IL_02a1: Expected O, but got I4
		//IL_025d: Expected O, but got I
		//IL_0293: Expected O, but got I4
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.CreateDetachedWeapon(WeaponType.CART2, ((Equipment)this)._003COwner_003Ek__BackingField);
		Equipment equipment;
		Weapon cartWeapon;
		if ((object)weapon == null)
		{
			equipment = null;
			cartWeapon = null;
			goto IL_031b;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(Cart2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Cart2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Cart2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v63+FFFFFFF8+v242 @ rax_v58*8]");
			if (0 == (nint)typeof(Cart2Weapon))
			{
				obj3 = 1;
				goto IL_032a;
			}
		}
		obj3 = 0;
		goto IL_032a;
		IL_039c:
		if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
		{
			base.CopyAccumulatedLimitBreaks((Weapon)equipment, _cartWeapon);
		}
		GameManager core2 = GM.Core;
		core2._levelUpFactory.ForceExclude(WeaponType.CART2);
		return;
		IL_031b:
		_cartWeapon = (Cart2Weapon)cartWeapon;
		Cart2Weapon cartWeapon2 = _cartWeapon;
		if ((object)_cartWeapon != null && ((UnityEngine.Object)cartWeapon2).m_CachedPtr != (IntPtr)0)
		{
			Cart2Weapon cartWeapon3 = _cartWeapon;
			((Weapon)cartWeapon3)._skipAddingEvolution = true;
			Equipment cartWeapon4 = _cartWeapon;
			while (!cartWeapon4.IsMaxLevel())
			{
				bool flag = _cartWeapon.LevelUp();
				cartWeapon4 = _cartWeapon;
			}
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Equipment removedEquipment = characterController._weaponsManager.GetRemovedEquipment(WeaponType.CART2);
		object obj6;
		if ((object)removedEquipment != null)
		{
			nint num4 = (nint)removedEquipment;
			nint num5 = (nint)typeof(Weapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v37+FFFFFFF8+v534 @ rax_v33*8]");
				if (0 == (nint)typeof(Weapon))
				{
					obj6 = 1;
					goto IL_037a;
				}
			}
			obj6 = 0;
			goto IL_037a;
		}
		goto IL_039c;
		IL_032a:
		bool flag2 = obj3 == null;
		equipment = null;
		cartWeapon = null;
		if (!flag2)
		{
			equipment = null;
			cartWeapon = weapon;
		}
		goto IL_031b;
		IL_037a:
		if (obj6 != null)
		{
			equipment = removedEquipment;
		}
		goto IL_039c;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0032: Expected I, but got O
		//IL_0040: Expected I, but got O
		//IL_0050: Expected O, but got I
		//IL_008c: Expected O, but got I
		base.InitWeapon(characterController, weaponType);
		_fireCounter = 0;
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.95f;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (characterController2._characterType != CharacterType.MARIA)
		{
			return;
		}
		nint num3 = (nint)characterController2;
		nint num4 = (nint)typeof(CharacterControllerRamba);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterControllerRamba>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterControllerRamba>)+130]");
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v11+FFFFFFF8+v72 @ rax_v10*8]");
			if (0 == (nint)typeof(CharacterControllerRamba))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v5 (VampireSurvivors.Objects.Characters.CharacterController)+420]");
				_hasCharacterImage = false;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0081: Expected I, but got O
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0422: Expected O, but got I
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected O, but got Unknown
		//IL_0490: Expected O, but got I4
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_0108: Expected I4, but got I8
		//IL_04fd: Expected O, but got I8
		//IL_0136: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected I4, but got Unknown
		//IL_01bc: Expected F4, but got O
		//IL_0160: Expected O, but got I4
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_0341: Invalid comparison between O and F4
		//IL_0628: Expected I4, but got O
		//IL_0628: Expected O, but got F4
		//IL_01e6: Expected I, but got O
		//IL_01f4: Expected I, but got O
		//IL_0204: Expected O, but got I
		//IL_0284: Expected O, but got I4
		//IL_0240: Expected O, but got I
		//IL_0276: Expected O, but got I4
		//IL_055d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_0391->IL03a7: Incompatible stack heights: 1 vs 0
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
				Vector2 vector = default(Vector2);
				float num = (float)vector * 2f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v16 (UnityEngine.Bounds)+10]");
				float num2 = 0f * 2f;
				float num3 = PArea();
				nint num4 = (nint)this;
				object obj2 = default(object);
				object obj = obj2 * _003CScaleMultiplier_003Ek__BackingField;
				float num5 = base.PAmount();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebp,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebp\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Cart2EvoWeapon>)+410]");
				object obj3 = (nint)0 >> 31;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Cart2EvoWeapon>)+410]");
				object obj4 = 0 + obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
				object obj5 = default(object);
				float num6 = (float)obj5 * 200f;
				float num7 = -1500f - num6;
				Transform transform2 = null;
				float time = default(float);
				do
				{
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
					{
						Rate = 1f,
						Volume = (float?)(object)1
					};
					float num8 = (float)transform2 * 100f;
					float detune = num7 - num8;
					soundConfig.Detune = detune;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Brakes, soundConfig, 300f, 3, time);
					transform2 = (Transform)(transform2 + 1);
				}
				while ((nint)transform2 < 3);
				int num9 = (int)(_fireCounter & 0x80000001L);
				if ((nint)transform2 < 3)
				{
					object obj6 = num9 - 1;
					object obj7 = obj6 | -2;
					num9 = obj7 + 1;
				}
				bool flag2 = num9 == 1;
				float num10 = num * 0.5f;
				float num11 = num2 * 0.25f;
				Transform transform3 = (Transform)4294967295L;
				if (!flag2)
				{
					transform3 = (Transform)1;
				}
				float num12 = num10 * (float)transform3;
				float yOffset = num11 * (float)transform3;
				GenerateTrainTracks(vector);
				UpdateTrainTrack(flag2, yOffset);
				ShowTrainTrack(show: true, flag2);
				float num13 = (float)ret - num12;
				float num14 = (float)obj * 5.7f;
				float num15 = num14 * (float)transform3;
				float num16 = num13 - num15;
				object obj8 = default(object);
				bool flag3 = (nint)obj8 <= 0;
				float num17 = (float)transform3;
				if (!flag3)
				{
					Transform transform4 = null;
					do
					{
						float num18 = (float)transform4 * 3.1f;
						float num19 = num18 * (float)obj;
						float num20 = num19 * (float)transform3;
						num17 = num16 - num20;
						Projectile projectile = base.FireOneProjectile((Vector2)num17, (int)transform4, _targetTransform);
						Transform transform5;
						if ((object)projectile == null)
						{
							transform5 = null;
							goto IL_0537;
						}
						nint num21 = (nint)projectile;
						nint num22 = (nint)typeof(Cart2EvoProjectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Cart2EvoProjectile>)+130]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Cart2EvoProjectile>)+130]");
						object obj11;
						if (num23 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v897 @ rax_v71+FFFFFFF8+v839 @ rax_v67*8]");
							if (0 == (nint)typeof(Cart2EvoProjectile))
							{
								obj11 = 1;
								goto IL_0510;
							}
						}
						obj11 = 0;
						goto IL_0510;
						IL_0510:
						bool flag4 = obj11 == null;
						transform5 = null;
						if (!flag4)
						{
							transform5 = (Transform)(object)projectile;
						}
						goto IL_0537;
						IL_0537:
						if ((object)transform5 != null && ((UnityEngine.Object)transform5).m_CachedPtr != (IntPtr)0)
						{
							((Cart2EvoProjectile)(object)transform5).SetFlipped(flag2);
							object obj12 = obj8 - 1;
							object obj13 = (object)transform4 - obj12;
							bool flag5 = obj13 == null;
						}
						transform4 = (Transform)(transform4 + 1);
					}
					while (System.Runtime.CompilerServices.Unsafe.As<Transform, UIntPtr>(ref transform4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8));
				}
				float num24 = base.PInterval();
				float num25 = _lastFiringInterval - num17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				object obj14 = num25 & 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
				{
					float num26 = base.PInterval();
					_lastFiringInterval = num17;
					ResetFiringTimer();
				}
				if (skipTriggers)
				{
					return;
				}
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void PlaySfx(int amount)
	{
		//IL_0076: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		//IL_00d3: Expected O, but got I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebx\"");
		int num = amount >> 31;
		object obj = amount + num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj2 = default(object);
		float num2 = (float)obj2 * 200f;
		float num3 = -1500f - num2;
		object obj3 = 0;
		float time = default(float);
		do
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float num4 = (float)obj3 * 100f;
			float detune = num3 - num4;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Brakes, soundConfig, 300f, 3, time);
			obj3++;
		}
		while ((nint)obj3 < 3);
	}

	private void GenerateTrainTracks(Vector2 startPos)
	{
		//IL_032b: Invalid comparison between F4 and I4
		//IL_0354: Expected O, but got I4
		//IL_0801: Invalid comparison between F4 and I4
		//IL_0396: Expected O, but got I4
		//IL_03f2: Expected O, but got I4
		//IL_0555: Expected O, but got I4
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected O, but got Unknown
		//IL_0688: Invalid comparison between F4 and O
		//IL_0813->IL06e4: Incompatible stack heights: 11 vs 0
		//IL_08ff->IL06aa: Incompatible stack heights: 11 vs 0
		//IL_03d9->IL06aa: Incompatible stack heights: 12 vs 0
		//IL_0450->IL06aa: Incompatible stack heights: 12 vs 0
		//IL_04a0->IL06aa: Incompatible stack heights: 12 vs 0
		//IL_0532->IL06aa: Incompatible stack heights: 12 vs 0
		//IL_08d6->IL06aa: Incompatible stack heights: 13 vs 0
		//IL_05b3->IL06aa: Incompatible stack heights: 13 vs 0
		//IL_0602->IL06aa: Incompatible stack heights: 13 vs 0
		//IL_06a5->IL08db: Incompatible stack heights: 13 vs 11
		//IL_06aa->IL06e4: Incompatible stack heights: 13 vs 0
		Transform topTrackContainer = _topTrackContainer;
		if ((object)_topTrackContainer != null && ((UnityEngine.Object)topTrackContainer).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		Transform bottomTrackContainer = _bottomTrackContainer;
		if ((object)_bottomTrackContainer != null && ((UnityEngine.Object)bottomTrackContainer).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		if ((object)_mainCamera != null)
		{
			GameObject gameObject = _mainCamera.gameObject;
			if ((object)gameObject != null)
			{
				Transform parent = gameObject.transform;
				GameObject gameObject2 = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject2, (string)null);
				if ((object)gameObject2 != null)
				{
					Transform topTrackContainer2 = gameObject2.transform;
					_topTrackContainer = topTrackContainer2;
					if ((object)_topTrackContainer != null)
					{
						_topTrackContainer.SetParent(parent, worldPositionStays: true);
						if ((object)_topTrackContainer != null)
						{
							Transform transform = _topTrackContainer.transform;
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							((UnityEngine.Object)_topTrackContainer).SetName("Cart2Evo - Train Tracks (Top)");
							GameObject gameObject3 = new GameObject();
							GameObject.Internal_CreateGameObject(gameObject3, (string)null);
							Transform bottomTrackContainer2 = gameObject3.transform;
							_bottomTrackContainer = bottomTrackContainer2;
							_bottomTrackContainer.SetParent(parent, worldPositionStays: true);
							Transform transform2 = _bottomTrackContainer.transform;
							bool flag2 = (object)transform2 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1701 @ rax_v64 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1701 @ rax_v64 (UnityEngine.Transform)+10]");
							Vector3 value2 = default(Vector3);
							Transform.set_localPosition_Injected((IntPtr)0, ref value2);
							bool flag4 = (object)_bottomTrackContainer == null;
							((UnityEngine.Object)_bottomTrackContainer).SetName("Cart2Evo - Train Tracks (Bottom)");
							bool flag5 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
							int depth = ((Equipment)this)._003COwner_003Ek__BackingField.depth;
							bool flag6 = (object)GM.Core == null;
							PhaserScene s_scene = ArcadePhysics.s_scene;
							bool flag7 = ArcadePhysics.s_scene == null;
							PhaserScene.Renderer renderer = s_scene._renderer;
							bool flag8 = s_scene._renderer == null;
							bool flag9 = (object)GM.Core == null;
							PhaserScene s_scene2 = ArcadePhysics.s_scene;
							bool flag10 = ArcadePhysics.s_scene == null;
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							bool flag11 = s_scene2._renderer == null;
							bool flag12 = renderer.width < renderer2.height;
							float num = renderer.width - renderer2.height;
							bool flag13 = num == 0f;
							bool flag14 = !flag12;
							bool flag15 = !flag13;
							object obj = flag15 & flag14;
							float num2 = ((obj == null) ? 74f : 108f);
							if (!(num2 > 0f))
							{
								return;
							}
							float? num3 = (float?)(object)0;
							Vector2 pos = default(Vector2);
							while (true)
							{
								object topTrackContainer3 = _topTrackContainer;
								if ((object)_topTrackContainer == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rsi_v18 (System.Object)+10]");
								bool flag16 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rsi_v18 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
								GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
								PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject4, pos, "vfx", "TrainTrack");
								if ((object)phaserSprite == null)
								{
									break;
								}
								PhaserSprite phaserSprite2 = phaserSprite.setScale(_003CScaleMultiplier_003Ek__BackingField, (float?)(object)0);
								PhaserSprite phaserSprite3 = phaserSprite.setAlpha(0f);
								int depth2 = depth - 2;
								PhaserSprite phaserSprite4 = phaserSprite.setDepth(depth2);
								List<object> topTracks = (List<object>)(object)_topTracks;
								if (_topTracks == null)
								{
									break;
								}
								int version = topTracks._version + 1;
								topTracks._version = version;
								object[] items = topTracks._items;
								if (topTracks._items == null)
								{
									break;
								}
								if (topTracks._size >= items.Length)
								{
									((List<object>)(object)_topTracks).AddWithResize((object)phaserSprite);
								}
								else
								{
									int size = topTracks._size + 1;
									topTracks._size = size;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								object bottomTrackContainer3 = _bottomTrackContainer;
								if ((object)_bottomTrackContainer == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rsi_v21 (System.Object)+10]");
								bool flag17 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rsi_v21 (System.Object)+10]");
								IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
								GameObject gameObject5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
								PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject5, pos, "vfx", "TrainTrack");
								if ((object)phaserSprite5 == null)
								{
									break;
								}
								PhaserSprite phaserSprite6 = phaserSprite5.setScale(_003CScaleMultiplier_003Ek__BackingField, (float?)(object)0);
								PhaserSprite phaserSprite7 = phaserSprite5.setAlpha(0f);
								int depth3 = depth - 2;
								PhaserSprite phaserSprite8 = phaserSprite5.setDepth(depth3);
								List<object> bottomTracks = (List<object>)(object)_bottomTracks;
								if (_bottomTracks == null)
								{
									break;
								}
								int version2 = bottomTracks._version + 1;
								bottomTracks._version = version2;
								object[] items2 = bottomTracks._items;
								if (bottomTracks._items == null)
								{
									break;
								}
								if (bottomTracks._size >= items2.Length)
								{
									((List<object>)(object)_bottomTracks).AddWithResize((object)phaserSprite5);
								}
								else
								{
									int size2 = bottomTracks._size + 1;
									bottomTracks._size = size2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								num3 = (float?)(object)((_003F?)num3 + 1);
								bool flag18 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num3);
								s_scene = (PhaserScene)(object)bottomTracks._items;
								if (!flag18)
								{
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

	private unsafe void UpdateTrainTrack(bool flipped, float yOffset)
	{
		//IL_01c0: Expected I, but got O
		//IL_00d4: Expected I, but got O
		//IL_0098: Expected O, but got I
		//IL_0275: Expected O, but got Ref
		//IL_0056: Expected O, but got I
		//IL_01ad: Expected O, but got Ref
		//IL_01b2->IL027a: Incompatible stack heights: 5 vs 2
		float num = PArea();
		float num2 = (float)Vector3.zeroVector * 0.23f;
		object obj = default(object);
		Vector3 value = default(Vector3);
		Vector3 value2 = default(Vector3);
		if (!flipped)
		{
			Transform transform = _topTrackContainer.transform;
			nint num3 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v45 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num4 = 0;
			float num5 = PArea();
			float num6 = (float)obj * num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v31 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num7 = 0f * num2;
			bool flag = (object)transform == null;
			bool flag2 = (byte)(~(nuint)(nint)((UnityEngine.Object)transform).m_CachedPtr) != 0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			bool flag3 = (object)_topTrackContainer == null;
			Transform transform2 = _topTrackContainer.transform;
			bool flag4 = (object)transform2 == null;
			IntPtr cachedPtr = ((UnityEngine.Object)transform2).m_CachedPtr;
			bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			object obj2 = 0;
			object obj3 = obj;
			object obj4 = (object)(&value2);
		}
		else
		{
			Transform transform3 = _bottomTrackContainer.transform;
			nint num8 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v30 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num9 = 0;
			float num10 = PArea();
			float num6 = (float)obj * num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdx_v24 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num7 = 0f * num2;
			bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
			Transform transform4 = _bottomTrackContainer.transform;
			IntPtr cachedPtr = ((UnityEngine.Object)transform4).m_CachedPtr;
			bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			object obj2 = 0;
			object obj3 = obj;
			object obj4 = (object)(&value);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v965 @ rax_v5 (should have been resolved before IL gen)");
	}

	public void ShowTrainTrack(bool show, bool flipped)
	{
		//IL_003c: Expected F4, but got I4
		//IL_004f: Expected O, but got I4
		if (flipped)
		{
		}
		if (show)
		{
			float num = 0.5f;
		}
		else
		{
			float num = 0f;
		}
		List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		float num3 = base.PInterval();
		if (!(num2 < deltaTime))
		{
			float num4 = base.PInterval();
			float num5 = base._003CTotalTime_003Ek__BackingField - deltaTime;
			base._003CTotalTime_003Ek__BackingField = num5;
			Fire();
		}
		Cart2Weapon cartWeapon = _cartWeapon;
		if ((object)_cartWeapon != null && ((UnityEngine.Object)cartWeapon).m_CachedPtr != (IntPtr)0)
		{
			_cartWeapon.InternalUpdate();
		}
	}

	public override void Fire()
	{
		Fire(false);
		int fireCounter = _fireCounter + 1;
		_fireCounter = fireCounter;
	}

	private void UpdateFiringInterval()
	{
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = (base._003CTotalTime_003Ek__BackingField = num + base._003CTotalTime_003Ek__BackingField);
		float num3 = base.PInterval();
		if (!(num2 < deltaTime))
		{
			float num4 = base.PInterval();
			float num5 = base._003CTotalTime_003Ek__BackingField - deltaTime;
			base._003CTotalTime_003Ek__BackingField = num5;
			Fire();
		}
	}

	private void UpdateCartWeapon()
	{
		Cart2Weapon cartWeapon = _cartWeapon;
		if ((object)_cartWeapon != null && ((UnityEngine.Object)cartWeapon).m_CachedPtr != (IntPtr)0)
		{
			_cartWeapon.InternalUpdate();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override float CalculateTotalDamage()
	{
		if (!_totalDamageCalculated)
		{
			Cart2Weapon cartWeapon = _cartWeapon;
			float num = ((Weapon)cartWeapon)._003CStatsInflictedDamage_003Ek__BackingField + base._003CStatsInflictedDamage_003Ek__BackingField;
			_totalDamageCalculated = true;
			base._003CStatsInflictedDamage_003Ek__BackingField = num;
		}
		return base._003CStatsInflictedDamage_003Ek__BackingField;
	}

	protected override void OnUpdate()
	{
		if (!_hasImage && !_hasCharacterImage)
		{
			InitImage();
			_hasImage = true;
		}
	}

	private void InitImage()
	{
		//IL_015d: Expected O, but got I4
		PhaserSprite backSprite = _backSprite;
		if ((object)_backSprite == null || ((UnityEngine.Object)backSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			Vector2 pos = default(Vector2);
			PhaserSprite backSprite2 = instance.AddPhaserSprite(pos, "anima", "Kahrahmbah_i0");
			_backSprite = backSprite2;
			bool flag = default(bool);
			List<Sprite> animation = SpriteManager.GetAnimation("Kahrahmbah_i0", 1, 4, "anima", flag);
			PhaserSprite backSprite3 = _backSprite;
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			backSprite3._spriteAnimation.AddAnimation("Idle", animation, 8, flag, startRandomFrame, onComplete, autoSetAnimation);
			PhaserSprite backSprite4 = _backSprite;
			backSprite4._spriteAnimation.SetAnimation("Idle");
		}
		PhaserSprite phaserSprite = _backSprite.setAlpha(0.65f);
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		int depth2 = depth - 2;
		PhaserSprite phaserSprite2 = phaserSprite.setDepth(depth2);
		PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
	}

	private void UpdateImage()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		int depth2 = depth - 2;
		PhaserSprite phaserSprite = _backSprite.setDepth(depth2);
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		PhaserSprite phaserSprite2 = _backSprite.setFlipX(flipX);
	}

	public override void SetVisible(bool visible)
	{
		PhaserSprite backSprite = _backSprite;
		_isVisible = visible;
		if ((object)_backSprite != null && ((UnityEngine.Object)backSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _backSprite.setVisible(visible);
		}
	}

	public override void Cleanup()
	{
		PhaserSprite backSprite = _backSprite;
		if ((object)_backSprite != null && ((UnityEngine.Object)backSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _backSprite.setVisible(visible: false);
		}
		_cartWeapon.Cleanup();
		base.Cleanup();
	}

	private void LateUpdate()
	{
		if (_hasImage)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
			int depth2 = depth - 2;
			PhaserSprite phaserSprite = _backSprite.setDepth(depth2);
			bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
			PhaserSprite phaserSprite2 = _backSprite.setFlipX(flipX);
		}
	}

	public Cart2EvoWeapon()
	{
		List<PhaserSprite> topTracks = new List<PhaserSprite>();
		_topTracks = topTracks;
		_bottomTracks = new List<PhaserSprite>();
		_003CScaleMultiplier_003Ek__BackingField = 0.6f;
		base._002Ector();
	}
}
