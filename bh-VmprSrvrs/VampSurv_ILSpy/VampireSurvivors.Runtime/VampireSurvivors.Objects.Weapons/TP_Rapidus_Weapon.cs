using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Rapidus_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public TP_Rapidus_Weapon _003C_003E4__this;

		public float moveSpeedBonus;

		internal void _003CFire_003Eb__0()
		{
			TP_Rapidus_Weapon tP_Rapidus_Weapon = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)tP_Rapidus_Weapon)._003COwner_003Ek__BackingField;
			PlayerModifierStats playerStats = characterController._playerStats;
			EggFloat eggFloat = playerStats._003CMoveSpeed_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + moveSpeedBonus;
			playerStats._003CMoveSpeed_003Ek__BackingField = eggFloat2;
			TP_Rapidus_Weapon tP_Rapidus_Weapon2 = _003C_003E4__this;
			float currentMovespeedBonus = tP_Rapidus_Weapon2._currentMovespeedBonus + moveSpeedBonus;
			tP_Rapidus_Weapon2._currentMovespeedBonus = currentMovespeedBonus;
		}

		internal void _003CFire_003Eb__1()
		{
			TP_Rapidus_Weapon tP_Rapidus_Weapon = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)tP_Rapidus_Weapon)._003COwner_003Ek__BackingField;
			PlayerModifierStats playerStats = characterController._playerStats;
			EggFloat eggFloat = playerStats._003CMoveSpeed_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val - moveSpeedBonus;
			playerStats._003CMoveSpeed_003Ek__BackingField = eggFloat2;
			TP_Rapidus_Weapon tP_Rapidus_Weapon2 = _003C_003E4__this;
			float currentMovespeedBonus = tP_Rapidus_Weapon2._currentMovespeedBonus - moveSpeedBonus;
			tP_Rapidus_Weapon2._currentMovespeedBonus = currentMovespeedBonus;
		}

		internal void _003CFire_003Eb__2()
		{
			TP_Rapidus_Weapon tP_Rapidus_Weapon = _003C_003E4__this;
			ArcadeSprite arcadeSprite = tP_Rapidus_Weapon.sprite.setAlpha(0f);
		}
	}

	private ArcadeSprite sprite;

	private Timer spriteTimer;

	private bool _initialisedParticles;

	protected ParticleEmitterManager _pfxEmitterManager;

	protected ParticleSystem _pfxEmitter;

	private const float Radius = 16f;

	private float _currentMovespeedBonus;

	protected virtual float _perLevelBonus => 0.1f;

	protected virtual int _maxCharges => 0;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected Ref, but got Unknown
		//IL_0227: Expected O, but got I
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Expected O, but got Unknown
		//IL_043c: Expected native int or pointer, but got O
		//IL_0456: Expected O, but got I
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Expected O, but got Unknown
		//IL_0490: Expected native int or pointer, but got O
		//IL_0c1a: Expected O, but got I4
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_04c2: Expected native int or pointer, but got O
		//IL_04dc: Expected O, but got I
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Expected O, but got Unknown
		//IL_0523: Expected O, but got I
		//IL_053d: Expected native int or pointer, but got O
		//IL_0557: Expected O, but got I
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected O, but got Unknown
		//IL_0591: Expected native int or pointer, but got O
		//IL_0c4c: Expected O, but got I
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c9: Expected O, but got Unknown
		//IL_05e3: Expected native int or pointer, but got O
		//IL_0c86: Expected O, but got I
		//IL_063a: Expected O, but got I
		//IL_065b: Expected O, but got I
		//IL_0677: Expected O, but got I4
		//IL_089f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Expected O, but got Unknown
		//IL_08be: Expected native int or pointer, but got O
		//IL_08d8: Expected O, but got I
		//IL_08f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f8: Expected O, but got Unknown
		//IL_0912: Expected native int or pointer, but got O
		//IL_0cc0: Expected O, but got I
		//IL_0945: Unknown result type (might be due to invalid IL or missing references)
		//IL_094a: Expected O, but got Unknown
		//IL_0971: Expected O, but got I
		//IL_098b: Expected native int or pointer, but got O
		//IL_09a5: Expected O, but got I
		//IL_09c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c5: Expected O, but got Unknown
		//IL_09df: Expected native int or pointer, but got O
		//IL_09ed: Expected O, but got I4
		//IL_0ce8: Expected O, but got I4
		//IL_0a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1a: Expected O, but got Unknown
		//IL_0a34: Expected native int or pointer, but got O
		//IL_0d2f: Expected O, but got I
		//IL_0a7f: Expected O, but got I
		//IL_0a9b: Expected O, but got I4
		//IL_0b6f->IL0b6f: Incompatible stack heights: 16 vs 1
		object obj2 = default(object);
		object obj = obj2 - 504;
		base.InitWeapon(characterController, weaponType);
		if ((object)this != null)
		{
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			ArcadeSprite arcadeSprite = RenderingExtensions.AddArcadeSprite(gameObject, pos, "vfx", "aeroBubble");
			sprite = arcadeSprite;
			if ((object)sprite != null)
			{
				ArcadeSprite arcadeSprite2 = sprite.setAlpha(0f);
				if ((object)sprite != null)
				{
					Transform transform = sprite.transform;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						Transform parent = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
						if ((object)transform != null)
						{
							transform.SetParent(parent, worldPositionStays: true);
							if ((object)sprite != null)
							{
								Transform transform2 = sprite.transform;
								if ((object)transform2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v27 (UnityEngine.Transform)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v27 (UnityEngine.Transform)+10]");
									Vector2 value = default(Vector2);
									Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value));
									_currentMovespeedBonus = 0f;
									if (!_initialisedParticles)
									{
										_initialisedParticles = true;
										GameObject gameObject2 = base.gameObject;
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v735 @ rbx_v12 (Il2CppMethodInfo)+38]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
										}
										_ = 0;
										bool flag2 = (object)gameObject2 == null;
										ParticleEmitterManager pfxEmitterManager;
										if (gameObject2.TryGetComponent<ParticleEmitterManager>(out *(ParticleEmitterManager*)(obj + 512)))
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
											pfxEmitterManager = (ParticleEmitterManager)0;
										}
										else
										{
											pfxEmitterManager = gameObject2.AddComponent<ParticleEmitterManager>();
										}
										_pfxEmitterManager = pfxEmitterManager;
										ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
										List<string> list = new List<string>();
										bool flag3 = list == null;
										int version = list._version + 1;
										list._version = version;
										string[] items = list._items;
										bool flag4 = list._items == null;
										if (list._size >= items.Length)
										{
											((List<object>)(object)list).AddWithResize((object)"HitStarWhite1");
										}
										else
										{
											int size = list._size + 1;
											list._size = size;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version2 = list._version + 1;
										list._version = version2;
										string[] items2 = list._items;
										bool flag5 = list._items == null;
										if (list._size >= items2.Length)
										{
											((List<object>)(object)list).AddWithResize((object)"ProjectileWave");
										}
										else
										{
											int size2 = list._size + 1;
											list._size = size2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										bool flag6 = particleSystemConfig == null;
										particleSystemConfig._frame = list;
										ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)(obj + 80);
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 180f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
										particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)(obj + 112);
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(25f, 50f));
										particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)(obj + 144);
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
										particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)(obj + 176);
										_ = 0;
										_ = 2;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
										particleSystemConfig._quantity = (int?)(object)0;
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
										particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)(obj + 208);
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E0]");
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
										particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)(obj + 240);
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 1f));
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F0]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+100]");
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
										particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
										_ = 0;
										_ = 0;
										_ = 1;
										_ = 1;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
										particleSystemConfig._blendMode = (BlendMode?)(object)0;
										_ = 8978312;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
										particleSystemConfig._tint = (uint?)(object)0;
										ParticleSystem.MinMaxCurve minMaxCurve7 = new ParticleSystem.MinMaxCurve(-600f);
										particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
										_ = 0;
										particleSystemConfig._on = false;
										bool flag7 = (object)_pfxEmitterManager == null;
										ParticleSystem pfxEmitter = _pfxEmitterManager.CreateEmitter(particleSystemConfig);
										_pfxEmitter = pfxEmitter;
										ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
										List<string> list2 = new List<string>();
										bool flag8 = list2 == null;
										int version3 = list2._version + 1;
										list2._version = version3;
										string[] items3 = list2._items;
										bool flag9 = list2._items == null;
										if (list2._size >= items3.Length)
										{
											((List<object>)(object)list2).AddWithResize((object)"PfxGreen");
										}
										else
										{
											int size3 = list2._size + 1;
											list2._size = size3;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version4 = list2._version + 1;
										list2._version = version4;
										string[] items4 = list2._items;
										bool flag10 = list2._items == null;
										if (list2._size >= items4.Length)
										{
											((List<object>)(object)list2).AddWithResize((object)"PfxLightGreen");
										}
										else
										{
											int size4 = list2._size + 1;
											list2._size = size4;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										bool flag11 = particleSystemConfig2 == null;
										particleSystemConfig2._frame = list2;
										ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)(obj + 272);
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 180f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+110]");
										particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+120]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)(obj + 304);
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(25f, 50f));
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+130]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+140]");
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
										particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)(obj + 336);
										_ = 0;
										_ = 4;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
										particleSystemConfig2._quantity = (int?)(object)0;
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(200f, 400f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+150]");
										particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+160]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)(obj + 368);
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(1f, 0f));
										obj = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+170]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+180]");
										_ = 0;
										obj = (particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)1);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)(obj + 400);
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0.5f, 1.5f));
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+190]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
										particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
										_ = 0;
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+200]");
										particleSystemConfig2._blendMode = (BlendMode?)(object)0;
										minMaxCurve7 = new ParticleSystem.MinMaxCurve(-100f);
										particleSystemConfig2._gravity = (ParticleSystem.MinMaxCurve)0;
										_ = 0;
										particleSystemConfig2._on = false;
										bool flag12 = (object)_pfxEmitterManager == null;
										ParticleSystem particleSystem = _pfxEmitterManager.CreateEmitter(particleSystemConfig2);
										bool flag13 = (object)GM.Core == null;
										PhaserScene s_scene = ArcadePhysics.s_scene;
										bool flag14 = ArcadePhysics.s_scene == null;
										PhaserScene.Renderer renderer = s_scene._renderer;
										bool flag15 = s_scene._renderer == null;
										bool flag16 = (object)_pfxEmitterManager == null;
										int depth = -renderer.pixelHeight;
										ParticleEmitterManager particleEmitterManager = _pfxEmitterManager.SetDepth(depth);
									}
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

	protected override void OnStart()
	{
		//IL_0041: Expected I, but got O
		//IL_00de: Expected I, but got O
		base.ResetFiringTimer();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager gameMan = _gameMan;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Rapidus_Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_projectilePool, gameMan.Enemies, collideCallback, processCallback, callbackContext);
		Collider collider2 = collider.setName("Projectiles>Enemies");
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		ArcadePhysics physics2 = s_scene2.physics;
		GameManager gameMan2 = _gameMan;
		PhysicsManager physicsManager = gameMan2._physicsManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Rapidus_Weapon>)+3A0]");
		ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		Collider collider3 = physics2.add.overlap(_projectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		Collider collider4 = collider3.setName("Projectiles>Destructibles");
		collider2.SetColliderRunPosition(0);
		collider4.SetColliderRunPosition(1);
	}

	public void UpdateSprite()
	{
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_018f: Expected O, but got I4
		//IL_018f: Expected O, but got I4
		//IL_0264->IL01e0: Incompatible stack heights: 1 vs 0
		//IL_0093->IL01e0: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL01e0: Incompatible stack heights: 1 vs 0
		ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
		object obj4;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
			if ((object)arcadeSprite._spriteRenderer != null)
			{
				Sprite sprite = arcadeSprite._spriteRenderer.sprite;
				if ((object)sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
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
								Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out Rect _);
								object obj = default(object);
								object obj2 = default(object);
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
								{
									object obj3 = obj & -2147483649L;
									bool flag3 = (nint)obj3 <= 2139095040;
									obj4 = obj2;
									if (flag3)
									{
										goto IL_029e;
									}
								}
								obj4 = obj;
								goto IL_029e;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_029e:
		ArcadeSprite arcadeSprite3 = this.sprite;
		bool flag4 = (object)this.sprite == null;
		bool flag5 = arcadeSprite3.body == null;
		float num = (float)obj4 * (1f / 32f);
		float radius = num * 16f;
		BaseBody baseBody = arcadeSprite3.body.setCircle(radius, (float?)(object)0, (float?)(object)0);
		bool flag6 = (object)this.sprite == null;
		Transform transform = this.sprite.transform;
		bool flag7 = (object)transform == null;
		bool flag8 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = _currentWeaponData == null;
		float num2 = default(float);
		float num = num2;
		if (!flag)
		{
			float num3 = base.PArea();
			float num4 = base.PSpeed();
			bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num = num2;
			if (!flag2)
			{
				float num5 = ((Equipment)this)._003COwner_003Ek__BackingField.PMoveSpeed();
				bool flag3 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
				num = num2;
				if (!flag3)
				{
					num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
						float num6 = num2 * currentWeaponData._003Cpower_003Ek__BackingField;
						float num7 = num6 * num2;
						float num8 = num7 * num2;
						float num9 = num8 * num;
						return num + num9;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override float PAmount()
	{
		return 1f;
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_00a4: Invalid comparison between I4 and F4
		//IL_00ba: Expected F4, but got I4
		//IL_031c: Invalid comparison between F4 and I4
		//IL_00f6: Invalid comparison between I4 and F4
		//IL_0107: Expected F4, but got I4
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals13._003C_003E4__this = this;
		UpdateSprite();
		ArcadeSprite arcadeSprite = sprite.setAlpha(1f);
		if (spriteTimer != null)
		{
			spriteTimer.Cancel();
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats = characterController._playerStats;
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = !((float)currentWeaponData._003Ccharges_003Ek__BackingField > playerStats._003CShields_003Ek__BackingField);
		float num = currentWeaponData._003Ccharges_003Ek__BackingField;
		if (!flag)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			PlayerModifierStats playerStats2 = characterController2._playerStats;
			int maxCharges = _maxCharges;
			bool flag2 = !((float)maxCharges > playerStats2._003CShields_003Ek__BackingField);
			num = maxCharges;
			if (!flag2)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
				PlayerModifierStats playerStats3 = characterController3._playerStats;
				num = ++playerStats3._003CShields_003Ek__BackingField;
			}
		}
		float num2 = base.PDuration();
		float perLevelBonus = _perLevelBonus;
		float num3 = (CS_0024_003C_003E8__locals13.moveSpeedBonus = (float)((Equipment)this)._003CLevel_003Ek__BackingField * num);
		float num4 = 5f - _currentMovespeedBonus;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (num4 > 0f)
		{
			if (!(num4 > num3))
			{
				num3 = num4;
			}
			CS_0024_003C_003E8__locals13.moveSpeedBonus = num3;
			Action action = delegate
			{
				TP_Rapidus_Weapon tP_Rapidus_Weapon = CS_0024_003C_003E8__locals13._003C_003E4__this;
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)tP_Rapidus_Weapon)._003COwner_003Ek__BackingField;
				PlayerModifierStats playerStats4 = characterController4._playerStats;
				EggFloat eggFloat = playerStats4._003CMoveSpeed_003Ek__BackingField;
				float value = default(float);
				EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
				value = eggFloat._val + CS_0024_003C_003E8__locals13.moveSpeedBonus;
				playerStats4._003CMoveSpeed_003Ek__BackingField = eggFloat2;
				TP_Rapidus_Weapon tP_Rapidus_Weapon2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
				float currentMovespeedBonus = tP_Rapidus_Weapon2._currentMovespeedBonus + CS_0024_003C_003E8__locals13.moveSpeedBonus;
				tP_Rapidus_Weapon2._currentMovespeedBonus = currentMovespeedBonus;
			};
			Action action2 = delegate
			{
				TP_Rapidus_Weapon tP_Rapidus_Weapon = CS_0024_003C_003E8__locals13._003C_003E4__this;
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)tP_Rapidus_Weapon)._003COwner_003Ek__BackingField;
				PlayerModifierStats playerStats4 = characterController4._playerStats;
				EggFloat eggFloat = playerStats4._003CMoveSpeed_003Ek__BackingField;
				float value = default(float);
				EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
				value = eggFloat._val - CS_0024_003C_003E8__locals13.moveSpeedBonus;
				playerStats4._003CMoveSpeed_003Ek__BackingField = eggFloat2;
				TP_Rapidus_Weapon tP_Rapidus_Weapon2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
				float currentMovespeedBonus = tP_Rapidus_Weapon2._currentMovespeedBonus - CS_0024_003C_003E8__locals13.moveSpeedBonus;
				tP_Rapidus_Weapon2._currentMovespeedBonus = currentMovespeedBonus;
			};
			action2._002Ector(CS_0024_003C_003E8__locals13, (nint)__ldftn(_003C_003Ec__DisplayClass16_0._003CFire_003Eb__1));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v536.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			float duration = num * 0.001f;
			Timer timer = Timers.Register(duration, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
		Action onComplete = delegate
		{
			TP_Rapidus_Weapon tP_Rapidus_Weapon = CS_0024_003C_003E8__locals13._003C_003E4__this;
			ArcadeSprite arcadeSprite2 = tP_Rapidus_Weapon.sprite.setAlpha(0f);
		};
		float duration2 = num * 0.001f;
		Timer timer2 = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		spriteTimer = timer2;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		if (arcanaManager._hasAstronomia)
		{
			GameManager core2 = GM.Core;
			core2._arcanaManager.TriggerAstronomia(this);
		}
		base.Fire(skipTriggers);
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		ArcadeSprite arcadeSprite = sprite.setVisible(visible);
	}

	protected override bool OnBulletOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0151: Expected I4, but got O
		if (second != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				Projectile component = gameObject.GetComponent<Projectile>();
				if (first != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					GameObject gameObject2 = default(GameObject);
					if ((object)gameObject2 != null)
					{
						Destructible component2 = gameObject2.GetComponent<Destructible>();
						float num = PPower();
						float num2 = default(float);
						bool flag = !(1f > num2);
						float value = num2;
						if (!flag)
						{
							value = 1f;
						}
						if ((object)component != null)
						{
							if (!component.HasAlreadyHitObject(component2))
							{
								if (_currentWeaponData == null || (object)component2 == null)
								{
									goto IL_0143;
								}
								component2.GetDamaged(value, HitVfxType.None, 0f, WeaponType.VOID, hasKb: false);
							}
							return false;
						}
					}
				}
			}
		}
		goto IL_0143;
		IL_0143:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
