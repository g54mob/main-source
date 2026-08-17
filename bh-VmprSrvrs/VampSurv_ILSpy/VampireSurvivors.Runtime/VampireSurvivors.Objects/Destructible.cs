using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects;

public class Destructible : BasePoolableSpriteBehaviour, IDamageable
{
	private sealed class _003C_003Ec__DisplayClass56_0
	{
		public Action<Pickup> onRewardGiven;

		internal void _003CGiveReward_003Eb__0(Pickup pickup)
		{
			Action<Pickup> action = onRewardGiven;
			if (onRewardGiven != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
			}
		}

		internal void _003CGiveReward_003Eb__1(Pickup pickup)
		{
			Action<Pickup> action = onRewardGiven;
			if (onRewardGiven != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
			}
		}

		internal void _003CGiveReward_003Eb__2(Pickup pickup)
		{
			Action<Pickup> action = onRewardGiven;
			if (onRewardGiven != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public uint _deathSeed;

	protected SpriteRenderer _destructibleRenderer;

	protected SpriteAnimation _spriteAnimation;

	private DataManager _dataManager;

	protected PlayerOptions _playerOptions;

	private LootManager _lootManager;

	private GameManager _gameManager;

	protected GameSessionData _gameSessionData;

	protected PropData _propData;

	private MaterialPropertyBlock _propBlock;

	protected Camera _mainCamera;

	protected PropType _destructibleType;

	protected float _hp;

	private float _maxHp;

	protected Timer _blinkTimer;

	private bool _receivingDamage;

	private bool _isCullable;

	private bool _isTeleportOnCull;

	protected bool _isDead;

	public float _blessedLevel;

	private bool _003CIsStationary_003Ek__BackingField;

	protected Light2D _light;

	protected CoherenceSync _coherenceSync;

	private Unity.Mathematics.Random _deathRng;

	private bool _003CIgnoreForcedMovement_003Ek__BackingField;

	public int PropType
	{
		get
		{
			return (int)_destructibleType;
		}
		set
		{
			_destructibleType = (PropType)value;
		}
	}

	public bool IsStationary
	{
		get
		{
			return _003CIsStationary_003Ek__BackingField;
		}
		set
		{
			_003CIsStationary_003Ek__BackingField = value;
		}
	}

	public PropType DestructibleType => _destructibleType;

	public bool IgnoreForcedMovement
	{
		get
		{
			return _003CIgnoreForcedMovement_003Ek__BackingField;
		}
		set
		{
			_003CIgnoreForcedMovement_003Ek__BackingField = value;
		}
	}

	private void Construct(DataManager dataManager, PlayerOptions playerOptions, LootManager lootManager, GameManager gameManager, GameSessionData gameSessionData)
	{
		_dataManager = dataManager;
		_playerOptions = playerOptions;
		_lootManager = lootManager;
		GameManager gameManager2 = default(GameManager);
		_gameManager = gameManager2;
		GameSessionData gameSessionData2 = default(GameSessionData);
		_gameSessionData = gameSessionData2;
	}

	public virtual void Awake()
	{
		//IL_00fe: Expected O, but got I4
		//IL_007f->IL00ff: Incompatible stack heights: 1 vs 0
		//IL_00ab->IL00ff: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		_mainCamera = main;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			SpriteRenderer destructibleRenderer = RenderingExtensions.AddSprite(gameObject, pos, "items", "Brazier1");
			_destructibleRenderer = destructibleRenderer;
			if ((object)_destructibleRenderer != null)
			{
				GameObject gameObject2 = _destructibleRenderer.gameObject;
				if ((object)gameObject2 != null)
				{
					SpriteAnimation spriteAnimation = gameObject2.AddComponent<SpriteAnimation>();
					_spriteAnimation = spriteAnimation;
					MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
					IntPtr cachedPtr = MaterialPropertyBlock.CreateImpl();
					((UnityEngine.Object)(object)materialPropertyBlock).m_CachedPtr = cachedPtr;
					_propBlock = materialPropertyBlock;
					CoherenceSync component = GetComponent<CoherenceSync>();
					_coherenceSync = component;
					_deathRng = (Unity.Mathematics.Random)0;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe override void OnEnable()
	{
		//IL_0025: Expected O, but got Ref
		base.OnEnable();
		object obj = default(object);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTintFill(_destructibleRenderer, isEnabled: false, (Color?)(object)(&obj));
	}

	public virtual void OnDestructibleSpawned(SuperObject tiledScriptObject)
	{
	}

	protected override void OnUpdate()
	{
		SpriteRenderer destructibleRenderer = _destructibleRenderer;
		if ((object)_destructibleRenderer != null && ((UnityEngine.Object)destructibleRenderer).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
			int sortingOrder = default(int);
			_destructibleRenderer.sortingOrder = sortingOrder;
		}
	}

	public unsafe virtual void Init(PropType destructibleType)
	{
		//IL_01e8: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_02d5: Expected O, but got I4
		//IL_02d5: Expected O, but got I4
		//IL_0943: Expected O, but got I4
		//IL_06f4: Invalid comparison between I4 and F4
		//IL_0250->IL0729: Incompatible stack heights: 1 vs 0
		//IL_0288->IL0729: Incompatible stack heights: 1 vs 0
		//IL_02b5->IL0729: Incompatible stack heights: 1 vs 0
		//IL_02fd->IL0729: Incompatible stack heights: 1 vs 0
		//IL_032c->IL0729: Incompatible stack heights: 1 vs 0
		//IL_035b->IL0729: Incompatible stack heights: 1 vs 0
		//IL_03c9->IL0729: Incompatible stack heights: 1 vs 0
		//IL_08df->IL0785: Incompatible stack heights: 1 vs 0
		//IL_0849->IL0729: Incompatible stack heights: 1 vs 0
		//IL_068c->IL0785: Incompatible stack heights: 1 vs 0
		//IL_06ab->IL0729: Incompatible stack heights: 1 vs 0
		//IL_054a->IL0729: Incompatible stack heights: 1 vs 0
		//IL_0430->IL0729: Incompatible stack heights: 1 vs 0
		//IL_0948->IL0785: Incompatible stack heights: 1 vs 0
		//IL_04ca->IL0729: Incompatible stack heights: 1 vs 0
		//IL_0481->IL0729: Incompatible stack heights: 1 vs 0
		//IL_04fe->IL0729: Incompatible stack heights: 1 vs 0
		//IL_05be->IL0729: Incompatible stack heights: 1 vs 0
		//IL_05ed->IL0729: Incompatible stack heights: 1 vs 0
		//IL_0628->IL0729: Incompatible stack heights: 1 vs 0
		//IL_08c0->IL081d: Incompatible stack heights: 3 vs 1
		DataManager dataManager = _dataManager;
		_destructibleType = destructibleType;
		float ret;
		Renderer light;
		if (_dataManager != null && dataManager._003CAllProps_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllProps_003Ek__BackingField).FindEntry((System.Int32Enum)destructibleType);
			object propData;
			if (num < 0)
			{
				propData = null;
			}
			else
			{
				if (dataManager._003CAllProps_003Ek__BackingField == null)
				{
					goto IL_0729;
				}
				propData = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllProps_003Ek__BackingField).get_Item((System.Int32Enum)destructibleType);
			}
			_propData = (PropData)propData;
			if (_propData == null)
			{
				return;
			}
			PropData propData2 = _propData;
			_maxHp = propData2._003CmaxHp_003Ek__BackingField;
			_hp = propData2._003CmaxHp_003Ek__BackingField;
			_blessedLevel = 0f;
			SetupAnimations();
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				Factory add = s_scene.add;
				if (s_scene.add != null && add._world != null)
				{
					PhaserGameObject phaserGameObject = add._world.enableBody(this);
					PhysicsManager sInstance = PhysicsManager._sInstance;
					if (PhysicsManager._sInstance != null && sInstance._destructiblesGroup != null)
					{
						Group obj = sInstance._destructiblesGroup.add(this);
						BaseBody baseBody = body;
						if (body != null)
						{
							baseBody._immovable = true;
							_isDead = false;
							ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
							ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)1);
							Transform transform = base.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
								float2 float5 = default(float2);
								base.position = float5;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
								if ((object)_destructibleRenderer != null)
								{
									int sortingOrder = default(int);
									_destructibleRenderer.sortingOrder = sortingOrder;
									BaseBody baseBody2 = body;
									if (body != null)
									{
										baseBody2._enable = true;
										if (body != null)
										{
											BaseBody baseBody3 = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
											GameManager gameManager = _gameManager;
											if ((object)_gameManager != null)
											{
												Stage stage = gameManager._stage;
												if ((object)gameManager._stage != null)
												{
													StageData stageData = stage._stageData;
													if (stage._stageData != null)
													{
														if (!stageData._003ChasLights_003Ek__BackingField || !CanEmitLight())
														{
															goto IL_081d;
														}
														GameManager gameManager2 = _gameManager;
														if ((object)_gameManager != null && gameManager2._candleLightsMapping != null)
														{
															int num2 = gameManager2._candleLightsMapping.FindEntry(this);
															if (num2 < 0)
															{
																Queue<Light2D> candleLights = gameManager2._candleLights;
																if (gameManager2._candleLights != null)
																{
																	if (candleLights._size <= 0)
																	{
																		Stage stage2 = gameManager2._stage;
																		if ((object)gameManager2._stage == null)
																		{
																			goto IL_0729;
																		}
																		int count = stage2._003CMaxDestructibles_003Ek__BackingField + 1;
																		_gameManager.AddLightsToPool(count);
																	}
																	if (gameManager2._candleLights != null)
																	{
																		object obj2 = ((Queue<object>)(object)gameManager2._candleLights).Dequeue();
																		if (gameManager2._candleLightsMapping != null)
																		{
																			bool flag2 = ((Dictionary<object, object>)(object)gameManager2._candleLightsMapping).TryInsert((object)this, obj2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																			light = (Renderer)obj2;
																			goto IL_084e;
																		}
																	}
																}
															}
															else if (gameManager2._candleLightsMapping != null)
															{
																Light2D light2D = gameManager2._candleLightsMapping.get_Item(this);
																light = (Renderer)(object)light2D;
																goto IL_084e;
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
		goto IL_0729;
		IL_0729:
		throw new NullReferenceException();
		IL_084e:
		_light = (Light2D)(object)light;
		float? light2 = (float?)_light;
		if ((object)_light != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v13 (System.Nullable`1<System.Single>)+10]");
			if ((nint)0 != 0)
			{
				if ((object)_light != null)
				{
					_light.enabled = true;
					if ((object)_light != null)
					{
						Transform transform2 = _light.transform;
						Transform transform3 = base.transform;
						if ((object)transform3 != null)
						{
							Vector3 vector = transform3.position;
							bool flag3 = (object)transform2 == null;
							bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&ret));
							goto IL_081d;
						}
					}
				}
				goto IL_0729;
			}
		}
		goto IL_081d;
		IL_081d:
		float? coherenceSync = (float?)_coherenceSync;
		if ((object)_coherenceSync == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rbx_v11 (System.Nullable`1<System.Single>)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		if ((object)_coherenceSync != null)
		{
			bool hasStateAuthority = _coherenceSync.HasStateAuthority;
			if (hasStateAuthority)
			{
				float num3 = UnityEngine.Random.Range(1f, 4.2949673E+09f);
				if (0f > num3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
				}
				_deathSeed = (hasStateAuthority ? 1u : 0u);
			}
			int num4 = (int)(_deathSeed << 13);
			int num5 = (int)_deathSeed ^ num4;
			int num6 = num5 >> 17;
			int num7 = num5 ^ num6;
			int num8 = num7 << 5;
			int num9 = num8 ^ num7;
			_deathRng = (Unity.Mathematics.Random)num9;
			return;
		}
		goto IL_0729;
	}

	public void UpdateLightPosition()
	{
		//IL_0206->IL0163: Incompatible stack heights: 3 vs 0
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null)
		{
			Stage stage = gameManager._stage;
			if ((object)gameManager._stage != null)
			{
				StageData stageData = stage._stageData;
				if (stage._stageData != null)
				{
					if (!stageData._003ChasLights_003Ek__BackingField)
					{
						return;
					}
					Transform light = (Transform)(object)_light;
					if ((object)_light == null || ((UnityEngine.Object)light).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					if ((object)_light != null)
					{
						Transform transform = _light.transform;
						Transform transform2 = base.transform;
						if ((object)transform2 != null)
						{
							bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
							bool flag2 = (object)transform == null;
							bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual bool CanEmitLight()
	{
		return true;
	}

	public virtual void Despawn()
	{
		if (_blinkTimer != null)
		{
			_blinkTimer.Cancel();
		}
		GameManager gameManager = _gameManager;
		_isDead = true;
		Stage stage = gameManager._stage;
		StageData stageData = stage._stageData;
		if (stageData._003ChasLights_003Ek__BackingField)
		{
			Light2D light = _light;
			if ((object)_light != null && ((UnityEngine.Object)light).m_CachedPtr != (IntPtr)0)
			{
				_light.enabled = false;
				_light = null;
				GameManager gameManager2 = _gameManager;
				int num = gameManager2._candleLightsMapping.FindEntry(this);
				if (num >= 0)
				{
					Light2D item = gameManager2._candleLightsMapping.get_Item(this);
					((Queue<object>)(object)gameManager2._candleLights).Enqueue((object)item);
					bool flag = ((Dictionary<object, object>)(object)gameManager2._candleLightsMapping).Remove((object)this);
				}
			}
		}
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
		}
		PhysicsManager sInstance = PhysicsManager._sInstance;
		sInstance._destructiblesGroup.remove(this);
		GameObject obj = base.gameObject;
		base._ParentPool.Release(obj);
	}

	protected void Pushback(GameObject value, float duration)
	{
	}

	public virtual void RemoteDestroy()
	{
		_hp = 0f;
		_isDead = true;
		OnDestroyed();
		Despawn();
	}

	public virtual void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0029: Invalid comparison between I4 and F4
		if (!_isDead)
		{
			bool flag = !(0f < (_hp -= value));
			Destructible destructible = this;
			HitVfxType hitVfxType = showHitVfx;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 64 Invalid \"Jump target not found in method: 0x186E1D380\"");
				Destructible destructible2 = default(Destructible);
				destructible = destructible2;
				HitVfxType hitVfxType2 = default(HitVfxType);
				hitVfxType = hitVfxType2;
			}
			destructible._isDead = true;
			if (!destructible._coherenceSync.HasStateAuthority)
			{
				Action action = destructible.DestroyDestructible;
				bool flag2 = destructible._coherenceSync.SendCommand(action, MessageTarget.AuthorityOnly);
			}
			else
			{
				destructible.OnDestroyed();
			}
			destructible.OnGetDamaged(hitVfxType);
		}
	}

	public void DestroyDestructible()
	{
		_hp = 0f;
		GetDamaged(0f, HitVfxType.Default, 1f, WeaponType.VOID, hasKb: false);
	}

	public unsafe void OnGetDamaged(HitVfxType hitVfxType, bool hasKb = true)
	{
		//IL_0092: Expected I, but got O
		//IL_005e: Expected O, but got Ref
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
			object obj = default(object);
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTintFill(_destructibleRenderer, isEnabled: true, (Color?)(object)(&obj));
		}
		if (_blinkTimer != null)
		{
			_blinkTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+380]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer blinkTimer = Timers.Register(0.120000005f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_blinkTimer = blinkTimer;
	}

	public bool IsUnitDead()
	{
		return _isDead;
	}

	public float MaxHp()
	{
		return _maxHp;
	}

	public float CurrentHealth()
	{
		return _hp;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	protected virtual void SetupAnimations()
	{
		_spriteAnimation.CleanAnimations();
		PropData propData = _propData;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(propData._003CframeName_003Ek__BackingField, 1, 3, propData._003CtextureName_003Ek__BackingField, num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("Idle", animationFrames, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	protected unsafe virtual void OnDestroyed()
	{
		//IL_0008: Expected O, but got Ref
		//IL_09ee: Invalid comparison between F4 and I4
		//IL_01a4: Expected O, but got I
		//IL_02d5: Invalid comparison between F4 and I4
		//IL_05f2: Invalid comparison between F4 and I4
		//IL_0ae8: Expected O, but got Ref
		//IL_0b0d: Expected F4, but got I
		//IL_04cb: Expected O, but got I4
		//IL_04d4: Expected O, but got I4
		//IL_04dc: Expected I4, but got F4
		//IL_0a69: Expected O, but got Ref
		//IL_0a8e: Expected F4, but got I
		//IL_02ac: Expected O, but got F4
		//IL_04fa: Expected O, but got I
		//IL_051c: Expected O, but got I4
		//IL_0525: Expected O, but got I4
		//IL_052d: Expected I4, but got F4
		//IL_025d: Expected O, but got F4
		//IL_070f: Expected O, but got F4
		//IL_0720: Expected F4, but got I4
		//IL_0685: Expected O, but got F4
		//IL_0696: Expected F4, but got I4
		//IL_056a: Expected I4, but got F4
		//IL_0c77: Expected O, but got Ref
		//IL_0c9c: Expected F4, but got I
		//IL_0bb2: Expected O, but got Ref
		//IL_07f2: Expected O, but got F4
		//IL_09b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b6: Expected O, but got Unknown
		//IL_0cf0: Expected O, but got Ref
		//IL_0cfb: Expected I, but got O
		//IL_08cc: Expected O, but got F4
		//IL_08dc: Expected O, but got F4
		//IL_08e5: Expected O, but got I4
		//IL_0b27->IL09dc: Incompatible stack heights: 1 vs 0
		//IL_0aa8->IL09dc: Incompatible stack heights: 1 vs 0
		//IL_0c3c->IL02c0: Incompatible stack heights: 1 vs 0
		//IL_026b->IL02c0: Incompatible stack heights: 1 vs 0
		//IL_0734->IL0c22: Incompatible stack heights: 0 vs 1
		//IL_0cb6->IL09dc: Incompatible stack heights: 1 vs 0
		//IL_0c1d->IL09dc: Incompatible stack heights: 1 vs 0
		//IL_0818->IL09dc: Incompatible stack heights: 1 vs 0
		//IL_08b5->IL09dc: Incompatible stack heights: 1 vs 0
		//IL_083a->IL09dc: Incompatible stack heights: 1 vs 0
		//IL_08ea->IL08ea: Incompatible stack heights: 1 vs 0
		//IL_0869->IL09dc: Incompatible stack heights: 1 vs 0
		//IL_0898->IL02c0: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = _blessedLevel == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E1D72Dh\"");
		if (flag)
		{
			goto IL_0131;
		}
		GameManager core = GM.Core;
		float eggVal;
		Action<Pickup> action;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
				if ((object)gameSessionData._activeCharacter != null)
				{
					PlayerModifierStats playerStats = activeCharacter._playerStats;
					if (activeCharacter._playerStats != null)
					{
						EggFloat eggFloat = playerStats._003CLuck_003Ek__BackingField;
						if (playerStats._003CLuck_003Ek__BackingField != null)
						{
							float value = default(float);
							EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
							value = eggFloat._val + _blessedLevel;
							playerStats._003CLuck_003Ek__BackingField = eggFloat2;
							float num = value;
							eggVal = eggFloat._eggVal;
							action = null;
							goto IL_0131;
						}
					}
				}
			}
		}
		goto IL_09dc;
		IL_0131:
		float num2 = default(float);
		float num3 = default(float);
		Vector2 pos;
		GameManager gameManager;
		if (_lootManager != null)
		{
			_lootManager.RecalculateLoot();
			_ = 0;
			_ = _deathRng;
			_ = 1;
			if (_lootManager != null)
			{
				LootManager lootManager = _lootManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
				ItemType randomWeightedItem = lootManager.GetRandomWeightedItem((Unity.Mathematics.Random?)(object)0);
				if (randomWeightedItem == ItemType.VOID)
				{
					goto IL_02c0;
				}
				ItemType relicType = default(ItemType);
				bool shouldCallValidatePickups = default(bool);
				bool isRemote = default(bool);
				if (randomWeightedItem != ItemType.COIN)
				{
					Transform transform = base.transform;
					if (randomWeightedItem != ItemType.COINBAG1)
					{
						if ((object)transform != null)
						{
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v108 (UnityEngine.Transform)+10]");
							bool flag2 = (nint)0 == 0;
							object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v108 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-35]");
							float num = 0f;
							if ((object)_gameManager != null)
							{
								Pickup pickup = _gameManager.MakePickup((Vector2)num2, randomWeightedItem, WeaponType.VOID, num3, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
								action = null;
								goto IL_02c0;
							}
						}
					}
					else if ((object)transform != null)
					{
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v108 (UnityEngine.Transform)+10]");
						bool flag3 = (nint)0 == 0;
						object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v108 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj4);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-35]");
						float num = 0f;
						if ((object)_gameManager != null)
						{
							eggVal = _blessedLevel * 10f;
							pos = (Vector2)num2;
							action = null;
							gameManager = _gameManager;
							goto IL_0c22;
						}
					}
				}
				else
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && core2._lootManager != null)
					{
						if (!core2._lootManager.DropSurvarotsSuccessful())
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E1DD0Bh\"");
							if (_blessedLevel == 0f)
							{
								Transform transform2 = base.transform;
								if ((object)transform2 != null)
								{
									Vector3 vector = transform2.position;
									_ = vector.z;
									_ = vector.x;
									if ((object)_gameManager != null)
									{
										_gameManager.MakeCoin((Vector2)num2);
										float num = num2;
										eggVal = 0f;
										action = null;
										goto IL_02c0;
									}
								}
							}
							else
							{
								Transform transform3 = base.transform;
								if ((object)transform3 != null)
								{
									Vector3 vector2 = transform3.position;
									_ = vector2.z;
									_ = vector2.x;
									if ((object)_gameManager != null)
									{
										pos = (Vector2)num2;
										float num = num2;
										eggVal = 0f;
										action = null;
										gameManager = _gameManager;
										goto IL_0c22;
									}
								}
							}
						}
						else
						{
							GameManager core3 = GM.Core;
							if ((object)GM.Core != null && core3._lootManager != null)
							{
								ItemType survarotDraft = core3._lootManager.GetSurvarotDraft();
								Transform transform4 = base.transform;
								if ((object)transform4 != null)
								{
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v90 (UnityEngine.Transform)+10]");
									bool flag4 = (nint)0 == 0;
									object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v90 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-35]");
									float num = 0f;
									if ((object)_gameManager != null)
									{
										Pickup pickup2 = _gameManager.MakePickup((Vector2)num2, survarotDraft, WeaponType.VOID, num3, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
										GameManager core4 = GM.Core;
										if ((object)GM.Core != null && core4._playerOptions != null)
										{
											PlayerOptionsData config = core4._playerOptions.Config;
											if (config != null)
											{
												int num4 = config._003CRunFoundSurvarots_003Ek__BackingField + 1;
												config._003CRunFoundSurvarots_003Ek__BackingField = num4;
												action = null;
												goto IL_02c0;
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
		goto IL_09dc;
		IL_0c22:
		gameManager.MakeRedCoinBag(pos, eggVal, action);
		goto IL_02c0;
		IL_0417:
		bool requireDeclaration;
		float num5;
		if (_playerOptions != null)
		{
			_playerOptions.IncreaseDestroyedPropCount(_destructibleType);
			GameManager gameManager2 = _gameManager;
			if ((object)_gameManager != null)
			{
				ArcanaManager arcanaManager = gameManager2._arcanaManager;
				if (gameManager2._arcanaManager != null)
				{
					List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
					if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rcx_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
						bool flag5 = (nint)0 == 0;
						Vector2 vector3 = (Vector2)_destructibleType;
						object obj6 = 0;
						requireDeclaration = (byte)(int)num3 != 0;
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rcx_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
							action = (Action<Pickup>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj7 = default(object);
							bool flag6 = (nint)obj7 == -1;
							vector3 = (Vector2)19;
							obj6 = 0;
							requireDeclaration = (byte)(int)num3 != 0;
							if (!flag6)
							{
								Transform transform5 = base.transform;
								if ((object)transform5 != null)
								{
									requireDeclaration = (byte)(int)num3 != 0;
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v60 (UnityEngine.Transform)+10]");
									bool flag7 = (nint)0 == 0;
									object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v60 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj8);
									GameManager gameManager3 = _gameManager;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-35]");
									float num = 0f + 0.24f;
									if ((object)_gameManager != null && gameManager3._arcanaManager != null)
									{
										gameManager3._arcanaManager.TriggerFireExplosion((Vector2)num2);
										num5 = num2;
										vector3 = (Vector2)num2;
										obj6 = 0;
										goto IL_08ea;
									}
								}
								goto IL_09dc;
							}
						}
						goto IL_08ea;
					}
				}
			}
		}
		goto IL_09dc;
		IL_02c0:
		num5 = _blessedLevel;
		bool flag8 = _blessedLevel == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E1DA21h\"");
		if (flag8)
		{
			goto IL_0417;
		}
		GameManager core5 = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData2 = core5._gameSessionData;
			if (core5._gameSessionData != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = gameSessionData2._activeCharacter;
				if ((object)gameSessionData2._activeCharacter != null)
				{
					PlayerModifierStats playerStats2 = activeCharacter2._playerStats;
					if (activeCharacter2._playerStats != null)
					{
						EggFloat eggFloat3 = playerStats2._003CLuck_003Ek__BackingField;
						if (playerStats2._003CLuck_003Ek__BackingField != null)
						{
							float value2 = default(float);
							EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
							value2 = eggFloat3._val - _blessedLevel;
							playerStats2._003CLuck_003Ek__BackingField = eggFloat4;
							float num = value2;
							eggVal = eggFloat3._eggVal;
							action = null;
							goto IL_0417;
						}
					}
				}
			}
		}
		goto IL_09dc;
		IL_08ea:
		GameManager gameManager4 = _gameManager;
		if ((object)_gameManager != null && gameManager4._signalBus != null)
		{
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1655 @ rdi_v14 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1696 @ rsi_v15 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj10 = default(object);
			object obj9 = obj10 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type = default(Type);
			Type signalType = type;
			object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
			object signal = (IntPtr)obj11;
			gameManager4._signalBus.InternalFire(signalType, signal, (object)null, requireDeclaration);
			return;
		}
		goto IL_09dc;
		IL_09dc:
		throw new NullReferenceException();
	}

	public void GiveReward(Action<Pickup> onRewardGiven = null)
	{
		//IL_0046: Expected O, but got I4
		//IL_03b2->IL0299: Incompatible stack heights: 1 vs 0
		//IL_0299->IL02c6: Incompatible stack heights: 1 vs 0
		//IL_0349->IL0299: Incompatible stack heights: 1 vs 0
		//IL_0255->IL02c6: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass56_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass56_0();
		if (CS_0024_003C_003E8__locals10 != null)
		{
			CS_0024_003C_003E8__locals10.onRewardGiven = onRewardGiven;
			if (_lootManager != null)
			{
				ItemType randomWeightedItem = _lootManager.GetRandomWeightedItem((Unity.Mathematics.Random?)(object)1);
				if (randomWeightedItem == ItemType.VOID)
				{
					goto IL_02c6;
				}
				Transform transform = base.transform;
				Vector2 pos = default(Vector2);
				Vector3 ret;
				if (randomWeightedItem != ItemType.COIN)
				{
					if (randomWeightedItem != ItemType.COINBAG1)
					{
						if (randomWeightedItem != ItemType.GEM)
						{
							if ((object)transform != null)
							{
								Vector3 vector = transform.position;
								if ((object)_gameManager != null)
								{
									float value = default(float);
									ItemType relicType = default(ItemType);
									bool shouldCallValidatePickups = default(bool);
									bool isRemote = default(bool);
									Pickup pickup = _gameManager.MakePickup(pos, randomWeightedItem, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
									Action<Pickup> onRewardGiven2 = CS_0024_003C_003E8__locals10.onRewardGiven;
									if (CS_0024_003C_003E8__locals10.onRewardGiven != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v488 @ r9_v15 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
									}
									goto IL_02c6;
								}
							}
						}
						else if ((object)transform != null)
						{
							Vector3 vector2 = transform.position;
							Action<Pickup> callback = delegate
							{
								Action<Pickup> onRewardGiven3 = CS_0024_003C_003E8__locals10.onRewardGiven;
								if (CS_0024_003C_003E8__locals10.onRewardGiven != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
								}
							};
							if ((object)_gameManager != null)
							{
								_gameManager.MakeGem(pos, 1f, callback);
								goto IL_02c6;
							}
						}
					}
					else if ((object)transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v20 (UnityEngine.Transform)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v20 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out ret);
						Action<Pickup> callback2 = delegate
						{
							Action<Pickup> onRewardGiven3 = CS_0024_003C_003E8__locals10.onRewardGiven;
							if (CS_0024_003C_003E8__locals10.onRewardGiven != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
							}
						};
						if ((object)_gameManager != null)
						{
							_gameManager.MakeRedCoinBag(pos, 0f, callback2);
							goto IL_02c6;
						}
					}
				}
				else if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v20 (UnityEngine.Transform)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v20 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					Action<Pickup> callback3 = delegate
					{
						Action<Pickup> onRewardGiven3 = CS_0024_003C_003E8__locals10.onRewardGiven;
						if (CS_0024_003C_003E8__locals10.onRewardGiven != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
						}
					};
					if ((object)_gameManager != null)
					{
						_gameManager.MakeCoin(pos, 0f, callback3);
						goto IL_02c6;
					}
				}
			}
		}
		goto IL_0299;
		IL_02c6:
		if (_playerOptions != null)
		{
			_playerOptions.IncreaseDestroyedPropCount(_destructibleType);
			return;
		}
		goto IL_0299;
		IL_0299:
		throw new NullReferenceException();
	}

	private void HandleArcanas()
	{
		//IL_019e->IL011a: Incompatible stack heights: 1 vs 0
		//IL_00fd->IL011a: Incompatible stack heights: 1 vs 0
		//IL_0119->IL0119: Incompatible stack heights: 1 vs 0
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null)
		{
			ArcanaManager arcanaManager = gameManager._arcanaManager;
			if (gameManager._arcanaManager != null)
			{
				List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
				if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
					if ((nint)0 == 0)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj = default(object);
					if ((nint)obj == -1)
					{
						return;
					}
					Transform transform = base.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						GameManager gameManager2 = _gameManager;
						if ((object)_gameManager != null && gameManager2._arcanaManager != null)
						{
							Vector2 pos = default(Vector2);
							gameManager2._arcanaManager.TriggerFireExplosion(pos);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe virtual void RestoreTint()
	{
		//IL_0019: Expected O, but got Ref
		//IL_0028: Invalid comparison between F4 and I4
		object obj = default(object);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTintFill(_destructibleRenderer, isEnabled: false, (Color?)(object)(&obj));
		if (!(_hp > 0f))
		{
			_blinkTimer.Cancel();
			if (_coherenceSync.HasStateAuthority)
			{
				Despawn();
			}
		}
	}

	public virtual bool DoesAllowVenting()
	{
		return true;
	}

	public Destructible()
	{
		//IL_0036: Expected I, but got O
		_hp = 1f;
		_maxHp = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
