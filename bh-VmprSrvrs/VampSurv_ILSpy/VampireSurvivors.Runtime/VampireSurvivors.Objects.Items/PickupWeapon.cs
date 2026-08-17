using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects.Items;

public class PickupWeapon : PickupGuarded
{
	private PhaserSprite _shadow;

	private PhaserSprite _glow;

	private WeaponType _weaponType;

	private WeaponData _weaponData;

	private LevelUpFactory _levelUpFactory;

	private float _colorValue;

	private bool _triggerOnGet;

	private bool _despawnOnUnavailable = true;

	private Tween _floatTween;

	private Tween _shadowTween;

	private Tween _glowTween;

	private Sprite _sprite;

	private VampireSurvivors.Objects.Characters.CharacterController _markedForSpecificCharacter;

	public WeaponType WeaponType => _weaponType;

	public int SyncedWeaponType
	{
		get
		{
			return (int)_weaponType;
		}
		set
		{
			_weaponType = (WeaponType)value;
		}
	}

	public bool DespawnOnUnavailable
	{
		get
		{
			return _despawnOnUnavailable;
		}
		set
		{
			_despawnOnUnavailable = value;
		}
	}

	public CoherenceSync MarkedForSpecificCharacter
	{
		get
		{
			VampireSurvivors.Objects.Characters.CharacterController markedForSpecificCharacter = _markedForSpecificCharacter;
			if ((object)_markedForSpecificCharacter != null && ((UnityEngine.Object)markedForSpecificCharacter).m_CachedPtr != (IntPtr)0)
			{
				VampireSurvivors.Objects.Characters.CharacterController markedForSpecificCharacter2 = _markedForSpecificCharacter;
				if ((object)_markedForSpecificCharacter != null)
				{
					return markedForSpecificCharacter2._coherenceSync;
				}
				return (CoherenceSync)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				VampireSurvivors.Objects.Characters.CharacterController component = value.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
				_markedForSpecificCharacter = component;
			}
			else
			{
				_markedForSpecificCharacter = null;
			}
		}
	}

	protected override bool UsesOrderedCommand => true;

	private void Construct(LevelUpFactory levelUpFactory)
	{
		_levelUpFactory = levelUpFactory;
	}

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		_canPauseSyncTimer = false;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		Action action = CheckIfRemovedFromWeaponStore;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD8C0");
		DisposeTweens();
	}

	public override void GetOnlineTaken()
	{
		if (!ShouldAbortTake())
		{
			base.GetOnlineTaken();
		}
	}

	public void MarkForSpecificCharacter(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		_markedForSpecificCharacter = character;
	}

	public override void SetData(ItemType itemType)
	{
		//IL_036e: Expected O, but got I4
		//IL_036e: Expected O, but got I
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_0476: Expected O, but got I
		//IL_00bf->IL039a: Incompatible stack heights: 1 vs 0
		//IL_00f7->IL039a: Incompatible stack heights: 1 vs 0
		//IL_0121->IL039a: Incompatible stack heights: 1 vs 0
		//IL_005a->IL039a: Incompatible stack heights: 1 vs 0
		//IL_0086->IL039a: Incompatible stack heights: 1 vs 0
		//IL_0202->IL039a: Incompatible stack heights: 1 vs 0
		//IL_023a->IL039a: Incompatible stack heights: 1 vs 0
		//IL_0264->IL039a: Incompatible stack heights: 1 vs 0
		//IL_019d->IL039a: Incompatible stack heights: 1 vs 0
		//IL_01c9->IL039a: Incompatible stack heights: 1 vs 0
		//IL_02d1->IL039a: Incompatible stack heights: 1 vs 0
		//IL_0330->IL039a: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		Vector2 pos = default(Vector2);
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			PhaserSprite shadow = _shadow;
			if ((object)_shadow != null && ((UnityEngine.Object)shadow).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_shadow != null)
				{
					GameObject gameObject = _shadow.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: true);
						goto IL_0143;
					}
				}
			}
			else
			{
				PhaserWorld instance = PhaserWorld.Instance;
				if ((object)instance != null)
				{
					PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "items", "ShadowSpot");
					if ((object)phaserSprite != null)
					{
						GameObject gameObject2 = phaserSprite.gameObject;
						if ((object)gameObject2 != null)
						{
							((UnityEngine.Object)gameObject2).SetName("Shadow");
							_shadow = phaserSprite;
							goto IL_0143;
						}
					}
				}
			}
		}
		goto IL_039a;
		IL_0143:
		PhaserSprite glow = _glow;
		if ((object)_glow != null && ((UnityEngine.Object)glow).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_glow != null)
			{
				GameObject gameObject3 = _glow.gameObject;
				if ((object)gameObject3 != null)
				{
					gameObject3.SetActive(value: true);
					goto IL_0286;
				}
			}
		}
		else
		{
			PhaserWorld instance2 = PhaserWorld.Instance;
			if ((object)instance2 != null)
			{
				PhaserSprite phaserSprite2 = instance2.AddPhaserSprite(pos, "vfx", "round");
				if ((object)phaserSprite2 != null)
				{
					GameObject gameObject4 = phaserSprite2.gameObject;
					if ((object)gameObject4 != null)
					{
						((UnityEngine.Object)gameObject4).SetName("Glow");
						_glow = phaserSprite2;
						goto IL_0286;
					}
				}
			}
		}
		goto IL_039a;
		IL_039a:
		throw new NullReferenceException();
		IL_0286:
		((Pickup)this).SetData(itemType);
		((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
		OnRecycle();
		Action action = CheckIfRemovedFromWeaponStore;
		if (_signalBus != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rbx_v6 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			object obj = null;
			if (obj != null)
			{
				Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.ValidatePickupWeapons>)obj)._003CSubscribeId_003Eb__0;
				((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.ValidatePickupWeapons>)0)._003CSubscribeId_003Eb__0((object)1);
				object obj3 = default(object);
				object obj2 = obj3 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				SignalBus signalBus = _signalBus;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v35 (System.Object)+10]");
				Type signalType = default(Type);
				Action<object> callback = default(Action<object>);
				signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
				return;
			}
		}
		goto IL_039a;
	}

	public void SetWeaponType(WeaponType weaponType)
	{
		//IL_0099: Expected O, but got I
		//IL_00b0: Expected O, but got I
		_weaponType = weaponType;
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		int num = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).FindEntry((System.Int32Enum)_weaponType);
		if (num >= 0)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)_weaponType);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v12 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v12 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v13+20]");
			_weaponData = (WeaponData)0;
			if (_weaponData != null)
			{
				WeaponData weaponData = _weaponData;
				Sprite sprite = SpriteManager.GetSprite(weaponData._003CframeName_003Ek__BackingField, weaponData._003Ctexture_003Ek__BackingField);
				_sprite = sprite;
				ArcadeSprite arcadeSprite = setFrame(_sprite);
				WeaponData weaponData2 = _weaponData;
				_despawnOnUnavailable = weaponData2._003CdespawnOnUnavailable_003Ek__BackingField;
			}
		}
		SpawnCursor();
	}

	public override void InternalUpdate()
	{
		//IL_00e8->IL019c: Incompatible stack heights: 3 vs 0
		((Pickup)this).InternalUpdate();
		if (!_hasSpawned && IsAnyPlayerInGuardSpawnRange())
		{
			base.TriggerSpawn();
		}
		if ((object)_glow != null)
		{
			Transform transform = _glow.transform;
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				UpdateColor();
				CheckSpawnParticles();
				if (body == null)
				{
					return;
				}
				BaseBody baseBody = body;
				if (!baseBody._enable)
				{
					return;
				}
				if ((object)_coherenceSync != null)
				{
					if (!_coherenceSync.HasStateAuthority)
					{
						return;
					}
					float2 float5 = SafeXY();
					float2 float6 = base.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187348C60h\"");
					if ((object)float5 == (object)float6)
					{
						float2 float7 = base.position;
						object obj = default(object);
						bool flag4 = obj == obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187348C60h\"");
						if (flag4)
						{
							return;
						}
					}
					float2 float8 = default(float2);
					base.position = float8;
					ResumeFloat();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void UpdateDepth()
	{
	}

	public void TriggerOnGet()
	{
		//IL_0010: Expected O, but got I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003c: Expected O, but got I4
		object obj = _weaponType - 67;
		object obj2 = obj & 0xFFFFFFFAL;
		bool flag = obj2 == null;
		object obj3 = !flag;
		if ((obj3 == null && _weaponType != WeaponType.RIGHT) || _weaponType == WeaponType.RIGHT)
		{
			_triggerOnGet = true;
		}
	}

	public new void StopFloat()
	{
		if (_floatTween != null)
		{
			TweenExtensions.Kill(_floatTween);
		}
	}

	public unsafe void ResumeFloat()
	{
		//IL_0084: Expected O, but got I
		//IL_0338: Expected O, but got Ref
		//IL_03ff->IL03ff: Incompatible stack heights: 3 vs 0
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null)
		{
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
				{
					goto IL_02c2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v56 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				bool flag = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v56 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v56 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					object obj = -3;
					bool flag2 = obj == null;
					flag = flag2;
				}
				if (!flag)
				{
					return;
				}
			}
			if (_floatTween != null)
			{
				TweenExtensions.Kill(_floatTween);
			}
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				}
				else
				{
					Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Transform target = base.transform;
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(target, (Vector3)(&ret), 1f);
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 4;
							_ = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 4294967295L;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
								if ((nint)0 == 0)
								{
									_ = 2139095040;
								}
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tweenerCore != null)
					{
						_floatTween = tweenerCore;
						if ((object)_shadow != null)
						{
							Transform transform2 = _shadow.transform;
							PickupWeapon cachedTransform = (PickupWeapon)(object)_cachedTransform;
							if ((object)_cachedTransform != null)
							{
								bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out ret);
								bool flag4 = (object)transform2 == null;
								bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_02c2;
		IL_02c2:
		throw new NullReferenceException();
	}

	public void SetVfxVisible(bool visible)
	{
		_vfxEnabled = visible;
		if ((object)_glow != null)
		{
			GameObject gameObject = _glow.gameObject;
			gameObject.SetActive(visible);
		}
		if ((object)_shadow != null)
		{
			GameObject gameObject2 = _shadow.gameObject;
			gameObject2.SetActive(visible);
		}
	}

	private void OnWeaponUpdatedRemotely(int old, int newValue)
	{
		SetWeaponType((WeaponType)newValue);
	}

	public override void Despawn()
	{
		base.Despawn();
		Action action = CheckIfRemovedFromWeaponStore;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD8C0");
		DisposeTweens();
		GameObject gameObject = _shadow.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _glow.gameObject;
		gameObject2.SetActive(value: false);
		RemoveCursor();
	}

	protected unsafe override void OnRecycle()
	{
		//IL_0090: Expected O, but got Ref
		//IL_0571->IL049b: Incompatible stack heights: 2 vs 0
		//IL_0614->IL049b: Incompatible stack heights: 2 vs 0
		//IL_01bb->IL049b: Incompatible stack heights: 2 vs 0
		//IL_022c->IL049b: Incompatible stack heights: 2 vs 0
		//IL_0631->IL049b: Incompatible stack heights: 2 vs 0
		//IL_032a->IL049b: Incompatible stack heights: 2 vs 0
		//IL_035d->IL049b: Incompatible stack heights: 2 vs 0
		//IL_05f7->IL049b: Incompatible stack heights: 2 vs 0
		//IL_03b0->IL049b: Incompatible stack heights: 2 vs 0
		//IL_03e5->IL049b: Incompatible stack heights: 2 vs 0
		//IL_042d->IL049b: Incompatible stack heights: 2 vs 0
		base.OnRecycle();
		_colorValue = 0f;
		if ((object)_shadow != null)
		{
			Transform transform = _shadow.transform;
			object cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdi_v8 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdi_v8 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					_triggerOnGet = false;
					ResumeFloat();
					Transform transform2 = _shadow.transform;
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
					if ((object)_shadow != null)
					{
						Transform target = _shadow.transform;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&value), 1f);
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								_ = 4;
								_ = 0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (tweenerCore != null)
						{
							_shadowTween = tweenerCore;
							if ((object)_shadow != null)
							{
								PhaserSprite phaserSprite = _shadow.setAlpha(0.5f);
								if (_glowTween != null)
								{
									TweenExtensions.Kill(_glowTween);
								}
								PhaserSprite glow = _glow;
								if ((object)_glow != null)
								{
									TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(glow._spriteRenderer, 0f, 0.5f);
									if (tweenerCore2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1105 @ rax_v48 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1105 @ rax_v48 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
											if ((nint)0 == 0)
											{
												_ = 4294967295L;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1105 @ rax_v48 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
												if ((nint)0 == 0)
												{
													_ = 2139095040;
												}
											}
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									if (tweenerCore2 != null)
									{
										_glowTween = tweenerCore2;
										if ((object)_glow != null)
										{
											PhaserSprite phaserSprite2 = _glow.setBlendMode(BlendMode.Add);
											if ((object)_glow != null)
											{
												PhaserSprite phaserSprite3 = _glow.setAlpha(0.5f);
												RemoveCursor();
												PhaserScene s_scene = ArcadePhysics.s_scene;
												if (ArcadePhysics.s_scene != null)
												{
													object renderer = s_scene._renderer;
													if (s_scene._renderer != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdi_v13 (System.Object)+1C]");
														ArcadeSprite arcadeSprite = setDepth(0);
														if ((object)_shadow != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdi_v13 (System.Object)+1C]");
															int num = (int)(-1);
															PhaserSprite phaserSprite4 = _shadow.setDepth(num);
															if ((object)_glow != null)
															{
																PhaserSprite glow2 = _glow;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdi_v13 (System.Object)+1C]");
																PhaserSprite phaserSprite5 = glow2.setDepth(0);
																_markedForSpecificCharacter = null;
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
				else
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void GetTaken()
	{
		if (((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			return;
		}
		bool flag = ShouldAbortTake();
		if (!flag)
		{
			if (_triggerOnGet != flag)
			{
				base.TriggerSpawn();
			}
			GameObject gameObject = base.gameObject;
			string text = ((UnityEngine.Object)gameObject).GetName();
			string message = "Taking Weapon " + text;
			Debug.Log(message);
			RemoveCursor();
			_gameManager.AddFoundWeaponToQueue(_weaponType, _targetPlayer);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
			object obj = default(object);
			if (obj != null)
			{
				_playerOptions.UnlockWeapon(_weaponType);
				SetWeaponDataUnlocked(_weaponType);
			}
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
		}
	}

	private bool ShouldAbortTake()
	{
		//IL_0503: Expected I4, but got O
		//IL_04c8: Expected O, but got I4
		//IL_04e2: Expected O, but got I4
		//IL_01e0: Expected O, but got I4
		//IL_0533: Expected O, but got I4
		//IL_0289: Expected I, but got O
		//IL_0271: Expected I, but got O
		VampireSurvivors.Objects.Characters.CharacterController markedForSpecificCharacter = _markedForSpecificCharacter;
		if ((object)_markedForSpecificCharacter != null && ((UnityEngine.Object)markedForSpecificCharacter).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController markedForSpecificCharacter2 = _markedForSpecificCharacter;
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			bool flag = (object)_targetPlayer == null;
			bool flag2 = (object)_markedForSpecificCharacter == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				if ((object)_targetPlayer != null)
				{
					if ((object)_markedForSpecificCharacter != null)
					{
						object obj3 = (object)_markedForSpecificCharacter - (object)_targetPlayer;
						bool flag4 = obj3 == null;
						return !flag4;
					}
					bool flag5 = ((UnityEngine.Object)targetPlayer).m_CachedPtr == (IntPtr)0;
					return !flag5;
				}
				if ((object)_markedForSpecificCharacter != null)
				{
					bool flag6 = ((UnityEngine.Object)markedForSpecificCharacter2).m_CachedPtr == (IntPtr)0;
					return !flag6;
				}
				goto IL_04f5;
			}
		}
		else if (_weaponType != WeaponType.FB_WEAPONPU)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core == null || core._characters == null)
			{
				goto IL_04f5;
			}
			bool flag7 = false;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj4 = 0;
				VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = _targetPlayer;
				bool flag8 = (object)_targetPlayer == null;
				bool flag9 = !flag8;
				object obj5 = !flag9;
				if (obj5 == null)
				{
					nint num;
					if ((object)_targetPlayer == null)
					{
						num = (nint)typeof(UnityEngine.Object);
						throw new NullReferenceException();
					}
					bool flag10 = ((UnityEngine.Object)targetPlayer2).m_CachedPtr == (IntPtr)0;
					num = (nint)typeof(UnityEngine.Object);
					if (!flag10)
					{
						throw new NullReferenceException();
					}
				}
			}
			if (flag7)
			{
				return true;
			}
		}
		return false;
		IL_04f5:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void SetWeaponDataUnlocked(WeaponType weaponType)
	{
		//IL_008f: Expected I, but got O
		//IL_01e1: Expected O, but got I
		//IL_01f6: Expected O, but got I
		DataManager dataManager = _dataManager;
		if (dataManager._003CAllWeaponData_003Ek__BackingField != null && ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllWeaponData_003Ek__BackingField).TryGetValue((System.Int32Enum)weaponType, out object value))
		{
			int count = ((JContainer)value).Count;
			if (count > 0)
			{
				nint num = (nint)value;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v428 @ r8_v8 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				JToken jToken = true;
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v71 @ r10_v5+258] (should have been resolved before IL gen)");
				DataManager dataManager2 = _dataManager;
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllWeaponData_003Ek__BackingField).TryInsert((System.Int32Enum)weaponType, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			}
		}
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		if (convertedWeapons == null)
		{
			return;
		}
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _dataManager.GetConvertedWeapons();
		if (!((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).TryGetValue((System.Int32Enum)weaponType, out object value2) || value2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ stack_20_v6 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ stack_20_v6 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ stack_20_v6 (System.Object)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v11+20]");
				object obj4 = 0;
				_ = 1;
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private unsafe void UpdateColor()
	{
		//IL_00e0: Expected O, but got I
		float num = (_colorValue += 0.1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num2 = num * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		PhaserSprite glow = _glow;
		if ((object)_glow != null)
		{
			PhaserSprite spriteRenderer = (PhaserSprite)(object)glow._spriteRenderer;
			if ((object)glow._spriteRenderer != null)
			{
				bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out Color _);
				object glow2 = _glow;
				bool flag2 = (object)_glow == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rbx_v9 (System.Object)+28]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rbx_v9 (System.Object)+28]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rbx_v10 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rbx_v10 (System.Object)+10]");
				float value = default(float);
				SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void DisposeTweens()
	{
		TweenExtensions.Kill(_floatTween);
		_floatTween = null;
		Tween shadowTween = _shadowTween;
		if (_shadowTween != null && shadowTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_shadowTween);
		}
		_shadowTween = null;
		Tween glowTween = _glowTween;
		if (_glowTween != null && glowTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_glowTween);
		}
	}

	private unsafe void CheckIfRemovedFromWeaponStore()
	{
		//IL_00c6: Expected O, but got I
		//IL_00db: Expected O, but got I
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		if (((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).TryGetValue((System.Int32Enum)_weaponType, out object value) && value != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ stack_8_v5 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ stack_8_v5 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ stack_8_v5 (System.Object)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v19+20]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v29+19D]");
				if ((nint)0 != 0)
				{
					return;
				}
			}
		}
		if (_despawnOnUnavailable && !((Dictionary<WeaponType, List<WeaponData>>)(object)LevelUpFactory._weaponStore).TryGetValue(_weaponType, out *(List<WeaponData>*)null))
		{
			Action<Pickup> action = ((Pickup)this)._003CPickupCallback_003Ek__BackingField;
			if (((Pickup)this)._003CPickupCallback_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v364 @ rax_v19 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
			}
			Despawn();
		}
	}

	private void SpawnCursor()
	{
		//IL_01b3: Expected O, but got I4
		//IL_0029->IL0155: Incompatible stack heights: 1 vs 0
		//IL_0055->IL0155: Incompatible stack heights: 1 vs 0
		//IL_010f->IL0155: Incompatible stack heights: 1 vs 0
		//IL_0140->IL0155: Incompatible stack heights: 1 vs 0
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					if (!config._003CShowPickups_003Ek__BackingField)
					{
						return;
					}
					CursorData cursorData = new CursorData
					{
						IconAlpha = 1f,
						_cursorProportionOfScreenFromCenter = 0.45f,
						AnimationName = "arrow_0"
					};
					_ = 1;
					_ = 8;
					_ = 16;
					Sprite sprite = SpriteManager.GetSprite("arrow_01", "UI");
					_ = 1069547520;
					_ = 1061158912;
					_ = _sprite;
					Transform transform = base.transform;
					if ((object)transform != null)
					{
						GameObject gameObject2 = transform.gameObject;
						if (_signalBus != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void RemoveCursor()
	{
		Transform transform = base.transform;
		GameObject gameObject = transform.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
	}

	protected override void ToggleCursors(UISignals.ToggleGuidesSignal sig)
	{
		if ((object)sig == null)
		{
			RemoveCursor();
		}
		else
		{
			SpawnCursor();
		}
	}

	private bool _003CShouldAbortTake_003Eb__43_0(Equipment x)
	{
		//IL_0053: Expected I4, but got O
		//IL_0031: Expected O, but got I4
		if ((object)x != null)
		{
			object obj = x._equipmentType - _weaponType;
			return obj == null;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool _003CShouldAbortTake_003Eb__43_1(Equipment x)
	{
		//IL_0053: Expected I4, but got O
		//IL_0031: Expected O, but got I4
		if ((object)x != null)
		{
			object obj = x._equipmentType - _weaponType;
			return obj == null;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
