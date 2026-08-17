using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors.Objects.Weapons;

public class SoleSolutionWeapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__27_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CFire_003Eb__27_2()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.SoleSSecond, soundConfig, 400f, 1, time);
		}
	}

	private Mesh _quadMesh;

	private RenderTexture _renderTexture;

	private MeshRenderer _galaxyMesh;

	private MeshRenderer _blitRenderer;

	public float _LayersAlpha;

	public float _GalaxyAlpha;

	public float _GalaxyScale;

	public float _GalaxyForce;

	private List<Tilemap> _layers;

	private bool _canFire;

	private bool _initialised;

	private SpriteRenderer _background;

	private Material _galaxyRTMaterial;

	private bool _particlesGenerated;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private GravityWell _well;

	private Camera _mainCam;

	private bool _canFadeTilemaps = true;

	private void LateUpdate()
	{
		//IL_0178->IL00f7: Incompatible stack heights: 4 vs 0
		Transform blitRenderer = (Transform)(object)_blitRenderer;
		if ((object)_blitRenderer == null || ((UnityEngine.Object)blitRenderer).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if ((object)_mainCam != null)
		{
			Transform transform = _mainCam.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)_blitRenderer == null;
				Transform transform2 = _blitRenderer.transform;
				bool flag3 = (object)transform2 == null;
				bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override float PInterval()
	{
		return 20000f;
	}

	public override void OnWeaponAdded()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		bool flag = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField).Remove((object)this);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager2 = characterController2._weaponsManager;
		bool flag2 = ((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField.Remove(this);
		GameEquipmentPanel panelForCharacter = GameEquipmentPanel.GetPanelForCharacter(((Equipment)this)._003COwner_003Ek__BackingField);
		if ((object)panelForCharacter != null && ((UnityEngine.Object)panelForCharacter).m_CachedPtr != (IntPtr)0)
		{
			panelForCharacter.AddExtra(((Equipment)this)._equipmentType);
		}
	}

	public override float PPower()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				float num = (float)config._003CRunEnemies_003Ek__BackingField / 5000f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
				float num2 = num;
				if (!flag)
				{
					num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
						float num3 = num * 0.1f;
						float num4 = num3 + currentWeaponData._003Cpower_003Ek__BackingField;
						float num5 = num4 * num2;
						return num2 + num5;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_01b7: Expected O, but got I4
		//IL_01b7: Expected O, but got I
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_0283: Expected O, but got I
		base.InitWeapon(characterController, weaponType);
		if (_layers == null)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			TilingTileset tilingTileset = stage._tilingTileset;
			if ((object)stage._tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
			{
				GameManager core2 = GM.Core;
				Stage stage2 = core2._stage;
				List<Tilemap> allLayers = stage2._tilingTileset.GetAllLayers();
				_layers = allLayers;
			}
		}
		_canFire = true;
		GenerateParticleSystems();
		Camera mainCam = _mainCam;
		_initialised = false;
		if ((object)_mainCam == null || ((UnityEngine.Object)mainCam).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_mainCam = main;
		}
		Action action = KillTilemapFade;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.KillSoleSolutionTilemapFade>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.KillSoleSolutionTilemapFade>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v20 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
	}

	private void KillTilemapFade()
	{
		_canFadeTilemaps = false;
	}

	protected override void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Action token = KillTilemapFade;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		base.OnDestroy();
	}

	public override void ParadoxFire()
	{
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0062: Expected O, but got I4
		//IL_0107: Expected I, but got O
		//IL_029f: Expected I, but got O
		//IL_0309: Expected I, but got O
		//IL_035f: Expected O, but got I4
		//IL_036d: Expected O, but got I4
		//IL_0397: Expected O, but got I4
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_042d: Invalid comparison between O and F4
		if (!_canFire)
		{
			return;
		}
		if (!_initialised)
		{
			InitialiseRT();
		}
		_canFire = false;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.SoleSAnti, soundConfig, 400f, 1, time);
		GravityWell well = _well;
		float num = (well._power = well._gravity * 0f);
		RenderingExtensions.SetQuantity(_pfxEmitter, 1);
		RenderingExtensions.Start(_pfxEmitter);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_GalaxyAlpha", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_GalaxyScale", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 300f;
			tweenConfig.delay = 3000f;
			TweenCallback onUpdate = UpdateGalaxy;
			tweenConfig.onUpdate = onUpdate;
			TweenCallback onStart = delegate
			{
				//IL_00fe: Expected O, but got I4
				//IL_011f: Expected F4, but got I4
				//IL_0315: Expected I, but got O
				//IL_006f->IL0453: Incompatible stack heights: 1 vs 0
				//IL_01c6->IL0453: Incompatible stack heights: 1 vs 0
				//IL_01f5->IL0453: Incompatible stack heights: 1 vs 0
				//IL_0224->IL0453: Incompatible stack heights: 1 vs 0
				//IL_0252->IL0453: Incompatible stack heights: 1 vs 0
				//IL_027f->IL0453: Incompatible stack heights: 1 vs 0
				//IL_02ac->IL0453: Incompatible stack heights: 1 vs 0
				//IL_0550->IL0453: Incompatible stack heights: 1 vs 0
				//IL_0308->IL0453: Incompatible stack heights: 1 vs 0
				//IL_035a->IL0453: Incompatible stack heights: 2 vs 0
				//IL_03a2->IL0453: Incompatible stack heights: 2 vs 0
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					Transform transform2 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
					if ((object)transform2 != null)
					{
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
						Vector2 pos = default(Vector2);
						Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
						_GalaxyAlpha = 0f;
						UpdateGalaxy();
						RenderingExtensions.SetQuantity(_pfxEmitter, 100);
						GravityWell well2 = _well;
						if ((object)_well != null)
						{
							well2._power = well2._gravity;
							Action onComplete2 = delegate
							{
								_pfxEmitter.Stop();
							};
							bool flag4 = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer timer = Timers.Register(0.1f, onComplete2, null, isLooped: false, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							Motion1();
							PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.SoleSFirst, new SoundManager.SoundConfig
							{
								Rate = 1f,
								Volume = (float?)(object)1
							}, 400f, 1, flag4 ? 1 : 0);
							Action onComplete3 = _003C_003Ec._003C_003E9__27_2;
							if (_003C_003Ec._003C_003E9__27_2 == null)
							{
								onComplete3 = (_003C_003Ec._003C_003E9__27_2 = delegate
								{
									//IL_003d: Expected O, but got I4
									SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
									soundConfig2.Volume = (float?)(object)1;
									soundConfig2.Rate = 1f;
									float time2 = default(float);
									PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.SoleSSecond, soundConfig2, 400f, 1, time2);
								});
							}
							Timer timer2 = Timers.Register(2.8000002f, onComplete3, null, isLooped: false, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							Action onComplete4 = delegate
							{
								Motion2();
							};
							Timer timer3 = Timers.Register(7.8f, onComplete4, null, isLooped: false, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							if ((object)_galaxyMesh != null)
							{
								_galaxyMesh.enabled = true;
								if ((object)_blitRenderer != null)
								{
									_blitRenderer.enabled = true;
									if ((object)_background != null)
									{
										_background.enabled = true;
										if ((object)GM.Core != null)
										{
											GM.Core.TogglePlayerHealthBar(visible: false);
											if ((object)GM.Core != null)
											{
												GM.Core.SetPlayersInvulForMilliSecondsNonCumulative(10000f);
												if ((object)GM.Core != null)
												{
													GM.Core.SetPlayersVisible(visible: false);
													PhysicsManager sInstance = PhysicsManager._sInstance;
													if (PhysicsManager._sInstance != null)
													{
														sInstance.PickupImmaterial = true;
														TweenConfig tweenConfig3 = new TweenConfig();
														object[] array3 = new object[1];
														if (array3 != null)
														{
															nint num8 = (nint)array3;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj5 = default(object);
															bool flag5 = obj5 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if (tweenConfig3 != null)
															{
																tweenConfig3.targets = array3;
																Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
																Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																if (dictionary2 != null)
																{
																	object value3 = default(object);
																	bool flag6 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_GalaxyScale", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																	tweenConfig3.custom = dictionary2;
																	tweenConfig3.duration = 300f;
																	tweenConfig3.delay = 9200f;
																	TweenCallback onUpdate2 = UpdateGalaxy;
																	tweenConfig3.onUpdate = onUpdate2;
																	TweenCallback onComplete5 = delegate
																	{
																		GM.Core.SetPlayersVisible(visible: true);
																		PhysicsManager sInstance2 = PhysicsManager._sInstance;
																		sInstance2.PickupImmaterial = false;
																		_pfxEmitter.Stop();
																	};
																	tweenConfig3.onComplete = onComplete5;
																	MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
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
				throw new NullReferenceException();
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			Bounds bounds = CameraExtensions.OrthographicBounds(_mainCam);
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[2];
			if ((object)_background != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Transform transform = _background.transform;
			if ((object)transform != null)
			{
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.alpha = (float?)(object)1;
			tweenConfig2.scaleX = (float?)(object)1;
			tweenConfig2.duration = 300f;
			tweenConfig2.delay = 3300f;
			tweenConfig2.scaleY = (float?)(object)1;
			TweenCallback onStart2 = delegate
			{
				//IL_00df: Expected O, but got I4
				//IL_00fb: Expected O, but got I4
				SpriteRenderer component = RenderingExtensions.SetAlpha(_background, 0f);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] targets = new object[1];
				if ((object)_background != null)
				{
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_background, 0f);
					if ((object)spriteRenderer2 == null)
					{
						ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
						throw ex4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig3.targets = targets;
				tweenConfig3.duration = 300f;
				tweenConfig3.alpha = (float?)(object)1;
				tweenConfig3.delay = 9200f;
				tweenConfig3.scale = (float?)(object)1;
				TweenCallback onComplete2 = delegate
				{
					RestoreLayers();
					_background.enabled = false;
					_galaxyMesh.enabled = false;
					_blitRenderer.enabled = false;
					GM.Core.TogglePlayerHealthBar(visible: true);
					_canFire = true;
				};
				tweenConfig3.onComplete = onComplete2;
				MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
			};
			tweenConfig2.onStart = onStart2;
			TweenCallback onComplete = delegate
			{
				FadeOutLayers();
			};
			tweenConfig2.onComplete = onComplete;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
			float num5 = PInterval();
			float num6 = _lastFiringInterval - num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj4 = num6 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
			{
				float num7 = PInterval();
				_lastFiringInterval = num;
				base.ResetFiringTimer();
			}
			return;
		}
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
	}

	protected override void OnPause()
	{
		Material galaxyRTMaterial = _galaxyRTMaterial;
		if ((object)_galaxyRTMaterial != null && ((UnityEngine.Object)galaxyRTMaterial).m_CachedPtr != (IntPtr)0)
		{
			int num = Shader.PropertyToID("_Speed");
			_galaxyRTMaterial.SetFloatImpl(num, 0f);
		}
	}

	protected override void OnResume()
	{
		Material galaxyRTMaterial = _galaxyRTMaterial;
		if ((object)_galaxyRTMaterial != null && ((UnityEngine.Object)galaxyRTMaterial).m_CachedPtr != (IntPtr)0)
		{
			int num = Shader.PropertyToID("_Speed");
			_galaxyRTMaterial.SetFloatImpl(num, 1f);
		}
	}

	protected override void MakeLevelOne()
	{
		//IL_000a: Expected I, but got O
		base.MakeLevelOne();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.SoleSolutionWeapon>)+4C0]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.SoleSolutionWeapon>)+4C0]");
		action._002Ector(this, (IntPtr)0);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_006f: Expected O, but got I
		//IL_016f: Expected O, but got Ref
		//IL_0196: Expected O, but got I
		//IL_01ab: Expected native int or pointer, but got O
		//IL_01c5: Expected O, but got I
		//IL_01e5: Expected O, but got Ref
		//IL_01ff: Expected native int or pointer, but got O
		//IL_041c: Expected O, but got I4
		//IL_0217: Expected O, but got Ref
		//IL_0231: Expected native int or pointer, but got O
		//IL_024b: Expected O, but got I
		//IL_026b: Expected O, but got Ref
		//IL_0285: Expected native int or pointer, but got O
		//IL_0439: Expected O, but got I4
		//IL_02b7: Expected O, but got Ref
		//IL_02d1: Expected native int or pointer, but got O
		//IL_0473: Expected O, but got I
		//IL_0322: Expected O, but got I
		//IL_0517->IL0517: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!_particlesGenerated)
		{
			GameObject gameObject = base.gameObject;
			_ = 0;
			ParticleEmitterManager particlesManager;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
				particlesManager = (ParticleEmitterManager)0;
			}
			else
			{
				particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
			}
			_particlesManager = particlesManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"WhiteDot");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 10;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1000f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(300f, 500f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			_ = 0;
			_ = 0;
			_ = 16777147;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
			particleSystemConfig._tint = (uint?)(object)0;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
			_pfxEmitter = pfxEmitter;
			Transform transform = _pfxEmitter.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			GravityWellConfig config = new GravityWellConfig
			{
				_power = 0f,
				_epsilon = 50f,
				_gravity = 20f
			};
			GravityWell well = _particlesManager.CreateGravityWell(config);
			_well = well;
			Transform transform2 = _well.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ rax_v59 (UnityEngine.Transform)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ rax_v59 (UnityEngine.Transform)+10]");
			Vector3 value2 = default(Vector3);
			Transform.set_localPosition_Injected((IntPtr)0, ref value2);
			_particlesGenerated = true;
		}
	}

	private unsafe void InitialiseRT()
	{
		//IL_003e: Expected O, but got Ref
		//IL_0138: Expected I4, but got I8
		if ((object)_galaxyMesh != null)
		{
			Material material = ((Renderer)_galaxyMesh).GetMaterial();
			if ((object)material != null)
			{
				Vector3 value = default(Vector3);
				material.color = (Color)(&value);
				if ((object)_galaxyMesh != null)
				{
					Material material2 = ((Renderer)_galaxyMesh).GetMaterial();
					_galaxyRTMaterial = material2;
					Bounds bounds = CameraExtensions.OrthographicBounds(_mainCam);
					if ((object)_blitRenderer != null)
					{
						Transform transform = _blitRenderer.transform;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value2 = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
						Transform transform2 = _blitRenderer.transform;
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector3 value3 = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value3);
						_GalaxyAlpha = 0f;
						UpdateGalaxy();
						GameObject gameObject = base.gameObject;
						string spriteName = default(string);
						SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, 0f, 0f, "vfx", spriteName);
						SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
						spriteRenderer.sortingOrder = -1000;
						_background = spriteRenderer;
						Transform transform3 = _background.transform;
						bool flag3 = (object)transform3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1255 @ rax_v58 (UnityEngine.Transform)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1255 @ rax_v58 (UnityEngine.Transform)+10]");
						Vector3 value4 = default(Vector3);
						Transform.set_localPosition_Injected((IntPtr)0, ref value4);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1255 @ rax_v58 (UnityEngine.Transform)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1255 @ rax_v58 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref value);
						bool flag6 = (object)_galaxyMesh == null;
						_galaxyMesh.enabled = false;
						bool flag7 = (object)_blitRenderer == null;
						_blitRenderer.enabled = false;
						bool flag8 = (object)_background == null;
						_background.enabled = false;
						_initialised = true;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void FadeOutLayers()
	{
		//IL_000d: Expected I, but got O
		_LayersAlpha = 1f;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_LayersAlpha", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 300f;
			TweenCallback onUpdate = delegate
			{
				SetLayersAlpha(_LayersAlpha);
			};
			tweenConfig.onUpdate = onUpdate;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void RestoreLayers()
	{
		//IL_0027: Expected I, but got O
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)this != null)
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
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_LayersAlpha", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 300f;
		TweenCallback onUpdate = delegate
		{
			SetLayersAlpha(_LayersAlpha);
		};
		tweenConfig.onUpdate = onUpdate;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void SetLayersAlpha(float alpha)
	{
		if (_layers != null && _canFadeTilemaps)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._SoleShadowAlpha = alpha;
			List<Tilemap> layers = _layers;
			List<Tilemap>.Enumerator enumerator = default(List<Tilemap>.Enumerator);
			while (enumerator.MoveNext())
			{
				Tilemap tilemap = null;
			}
		}
	}

	private void Motion1()
	{
		//IL_0027: Expected I, but got O
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)this != null)
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
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_GalaxyForce", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 500f;
		TweenCallback onUpdate = UpdateGalaxy;
		tweenConfig.onUpdate = onUpdate;
		TweenCallback onStart = delegate
		{
			_GalaxyForce = -1f;
			UpdateGalaxy();
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void Motion2()
	{
		//IL_0027: Expected I, but got O
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)this != null)
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
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_GalaxyForce", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 1400f;
		TweenCallback onUpdate = UpdateGalaxy;
		tweenConfig.onUpdate = onUpdate;
		TweenCallback onStart = delegate
		{
			_GalaxyForce = 1f;
			UpdateGalaxy();
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private unsafe void UpdateGalaxy()
	{
		//IL_00e7: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A594F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int num = Shader.PropertyToID("_Alpha");
		_galaxyRTMaterial.SetFloatImpl(num, _GalaxyAlpha);
		int num2 = Shader.PropertyToID("_Scale");
		_galaxyRTMaterial.SetFloatImpl(num2, _GalaxyScale);
		int num3 = Shader.PropertyToID("_Force");
		_galaxyRTMaterial.SetFloatImpl(num3, _GalaxyForce);
		int width = _renderTexture.width;
		int height = _renderTexture.height;
		int num4 = default(int);
		_galaxyRTMaterial.SetVector("_TargetSize", (Vector4)(&num4));
	}

	private void _003CFire_003Eb__27_0()
	{
		//IL_00fe: Expected O, but got I4
		//IL_011f: Expected F4, but got I4
		//IL_0315: Expected I, but got O
		//IL_006f->IL0453: Incompatible stack heights: 1 vs 0
		//IL_01c6->IL0453: Incompatible stack heights: 1 vs 0
		//IL_01f5->IL0453: Incompatible stack heights: 1 vs 0
		//IL_0224->IL0453: Incompatible stack heights: 1 vs 0
		//IL_0252->IL0453: Incompatible stack heights: 1 vs 0
		//IL_027f->IL0453: Incompatible stack heights: 1 vs 0
		//IL_02ac->IL0453: Incompatible stack heights: 1 vs 0
		//IL_0550->IL0453: Incompatible stack heights: 1 vs 0
		//IL_0308->IL0453: Incompatible stack heights: 1 vs 0
		//IL_035a->IL0453: Incompatible stack heights: 2 vs 0
		//IL_03a2->IL0453: Incompatible stack heights: 2 vs 0
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Vector2 pos = default(Vector2);
				Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
				_GalaxyAlpha = 0f;
				UpdateGalaxy();
				RenderingExtensions.SetQuantity(_pfxEmitter, 100);
				GravityWell well = _well;
				if ((object)_well != null)
				{
					well._power = well._gravity;
					Action onComplete = delegate
					{
						_pfxEmitter.Stop();
					};
					bool flag2 = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					Motion1();
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.SoleSFirst, new SoundManager.SoundConfig
					{
						Rate = 1f,
						Volume = (float?)(object)1
					}, 400f, 1, flag2 ? 1 : 0);
					Action onComplete2 = _003C_003Ec._003C_003E9__27_2;
					if (_003C_003Ec._003C_003E9__27_2 == null)
					{
						onComplete2 = (_003C_003Ec._003C_003E9__27_2 = delegate
						{
							//IL_003d: Expected O, but got I4
							SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
							soundConfig.Volume = (float?)(object)1;
							soundConfig.Rate = 1f;
							float time = default(float);
							PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.SoleSSecond, soundConfig, 400f, 1, time);
						});
					}
					Timer timer2 = Timers.Register(2.8000002f, onComplete2, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					Action onComplete3 = delegate
					{
						Motion2();
					};
					Timer timer3 = Timers.Register(7.8f, onComplete3, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					if ((object)_galaxyMesh != null)
					{
						_galaxyMesh.enabled = true;
						if ((object)_blitRenderer != null)
						{
							_blitRenderer.enabled = true;
							if ((object)_background != null)
							{
								_background.enabled = true;
								if ((object)GM.Core != null)
								{
									GM.Core.TogglePlayerHealthBar(visible: false);
									if ((object)GM.Core != null)
									{
										GM.Core.SetPlayersInvulForMilliSecondsNonCumulative(10000f);
										if ((object)GM.Core != null)
										{
											GM.Core.SetPlayersVisible(visible: false);
											PhysicsManager sInstance = PhysicsManager._sInstance;
											if (PhysicsManager._sInstance != null)
											{
												sInstance.PickupImmaterial = true;
												TweenConfig tweenConfig = new TweenConfig();
												object[] array = new object[1];
												if (array != null)
												{
													nint num = (nint)array;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj = default(object);
													bool flag3 = obj == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig != null)
													{
														tweenConfig.targets = array;
														Dictionary<string, object> dictionary = new Dictionary<string, object>();
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
														if (dictionary != null)
														{
															object value = default(object);
															bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_GalaxyScale", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
															tweenConfig.custom = dictionary;
															tweenConfig.duration = 300f;
															tweenConfig.delay = 9200f;
															TweenCallback onUpdate = UpdateGalaxy;
															tweenConfig.onUpdate = onUpdate;
															TweenCallback onComplete4 = delegate
															{
																GM.Core.SetPlayersVisible(visible: true);
																PhysicsManager sInstance2 = PhysicsManager._sInstance;
																sInstance2.PickupImmaterial = false;
																_pfxEmitter.Stop();
															};
															tweenConfig.onComplete = onComplete4;
															MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
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
		throw new NullReferenceException();
	}

	private void _003CFire_003Eb__27_1()
	{
		_pfxEmitter.Stop();
	}

	private void _003CFire_003Eb__27_3()
	{
		Motion2();
	}

	private void _003CFire_003Eb__27_4()
	{
		GM.Core.SetPlayersVisible(visible: true);
		PhysicsManager sInstance = PhysicsManager._sInstance;
		sInstance.PickupImmaterial = false;
		_pfxEmitter.Stop();
	}

	private void _003CFire_003Eb__27_5()
	{
		//IL_00df: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		SpriteRenderer component = RenderingExtensions.SetAlpha(_background, 0f);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] targets = new object[1];
		if ((object)_background != null)
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_background, 0f);
			if ((object)spriteRenderer2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = targets;
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.delay = 9200f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			RestoreLayers();
			_background.enabled = false;
			_galaxyMesh.enabled = false;
			_blitRenderer.enabled = false;
			GM.Core.TogglePlayerHealthBar(visible: true);
			_canFire = true;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void _003CFire_003Eb__27_7()
	{
		RestoreLayers();
		_background.enabled = false;
		_galaxyMesh.enabled = false;
		_blitRenderer.enabled = false;
		GM.Core.TogglePlayerHealthBar(visible: true);
		_canFire = true;
	}

	private void _003CFire_003Eb__27_6()
	{
		FadeOutLayers();
	}

	private void _003CFadeOutLayers_003Eb__33_0()
	{
		SetLayersAlpha(_LayersAlpha);
	}

	private void _003CRestoreLayers_003Eb__34_0()
	{
		SetLayersAlpha(_LayersAlpha);
	}

	private void _003CMotion1_003Eb__36_0()
	{
		_GalaxyForce = -1f;
		UpdateGalaxy();
	}

	private void _003CMotion2_003Eb__37_0()
	{
		_GalaxyForce = 1f;
		UpdateGalaxy();
	}
}
