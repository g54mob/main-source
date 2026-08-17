using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Items;

public class PickupRelic : PickupGuarded
{
	private PhaserSprite _shadow;

	private PhaserSprite _glow;

	private ItemType _itemType;

	private ItemData _itemData;

	private float _colorValue;

	private MultiTargetTween _floatTween;

	private MultiTargetTween _shadowTween;

	private Tween _glowTween;

	private Action<float> _onPickedUpCallback;

	public int SyncedRelicType
	{
		get
		{
			return (int)_itemType;
		}
		set
		{
			_itemType = (ItemType)value;
		}
	}

	protected override bool UsesOrderedCommand => true;

	public ItemType ItemType => _itemType;

	public PhaserSprite Shadow => _shadow;

	public PhaserSprite Glow => _glow;

	public Action<float> OnPickedUpCallback
	{
		get
		{
			return _onPickedUpCallback;
		}
		set
		{
			_onPickedUpCallback = value;
		}
	}

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		_canPauseSyncTimer = false;
		_onPickedUpCallback = null;
	}

	protected override void OnDestroy()
	{
		//IL_0085: Expected I, but got O
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		_onPickedUpCallback = null;
		Action<UISignals.ToggleGuidesSignal> token = null;
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003DC0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._gameObject = null;
		}
		DisposeTweens();
	}

	public override void SetData(ItemType itemType)
	{
		//IL_00bf->IL0203: Incompatible stack heights: 1 vs 0
		//IL_005a->IL0203: Incompatible stack heights: 1 vs 0
		//IL_0086->IL0203: Incompatible stack heights: 1 vs 0
		//IL_01ad->IL0203: Incompatible stack heights: 1 vs 0
		//IL_0148->IL0203: Incompatible stack heights: 1 vs 0
		//IL_0174->IL0203: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		Vector2 pos = default(Vector2);
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Transform shadow = (Transform)(object)_shadow;
			if ((object)_shadow != null && ((UnityEngine.Object)shadow).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_shadow != null)
				{
					GameObject gameObject = _shadow.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: true);
						goto IL_00ee;
					}
				}
			}
			else
			{
				PhaserWorld instance = PhaserWorld.Instance;
				if ((object)instance != null)
				{
					PhaserSprite shadow2 = instance.AddPhaserSprite(pos, "items", "ShadowSpot");
					_shadow = shadow2;
					goto IL_00ee;
				}
			}
		}
		goto IL_0203;
		IL_01dc:
		((Pickup)this).SetData(itemType);
		((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
		OnRecycle();
		SpawnCursor();
		return;
		IL_00ee:
		Transform glow = (Transform)(object)_glow;
		if ((object)_glow != null && ((UnityEngine.Object)glow).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_glow != null)
			{
				GameObject gameObject2 = _glow.gameObject;
				if ((object)gameObject2 != null)
				{
					gameObject2.SetActive(value: true);
					goto IL_01dc;
				}
			}
		}
		else
		{
			PhaserWorld instance2 = PhaserWorld.Instance;
			if ((object)instance2 != null)
			{
				PhaserSprite glow2 = instance2.AddPhaserSprite(pos, "vfx", "round");
				_glow = glow2;
				goto IL_01dc;
			}
		}
		goto IL_0203;
		IL_0203:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		((Pickup)this).InternalUpdate();
		if (!_hasSpawned && IsAnyPlayerInGuardSpawnRange())
		{
			base.TriggerSpawn();
		}
		if ((object)_shadow != null)
		{
			Transform transform = _shadow.transform;
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				bool flag4 = (object)_glow == null;
				Transform transform2 = _glow.transform;
				CheckRenderer();
				bool flag5 = (object)((ArcadeSprite)this)._spriteRenderer == null;
				Transform transform3 = ((ArcadeSprite)this)._spriteRenderer.transform;
				bool flag6 = (object)transform3 == null;
				bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
				bool flag8 = (object)transform2 == null;
				bool flag9 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value2 = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
				UpdateGlowColor();
				CheckSpawnParticles();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void SetItemType(ItemType itemType)
	{
		_itemType = itemType;
		DataManager dataManager = _dataManager;
		if (((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).TryGetValue((System.Int32Enum)_itemType, out object value))
		{
			_itemData = (ItemData)value;
		}
		if (_itemData != null)
		{
			ItemData itemData = _itemData;
			if (itemData._003Ctexture_003Ek__BackingField != null)
			{
				_textureName = itemData._003Ctexture_003Ek__BackingField;
			}
			ItemData itemData2 = _itemData;
			SetFrame(itemData2._003CframeName_003Ek__BackingField);
		}
	}

	public override void UpdateDepth()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		bool flag = !_ShowAboveAll;
		int num = renderer.pixelHeight;
		if (!flag)
		{
			num = 1990;
		}
		ArcadeSprite arcadeSprite = setDepth(num);
		int num2 = num - 1;
		PhaserSprite phaserSprite = _shadow.setDepth(num2);
		PhaserSprite phaserSprite2 = _glow.setDepth(num);
	}

	public override void Despawn()
	{
		base.Despawn();
		_onPickedUpCallback = null;
		GameObject gameObject = _shadow.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _glow.gameObject;
		gameObject2.SetActive(value: false);
		DisposeTweens();
		HideCursor();
	}

	public override void GetTaken()
	{
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			Action<float> onPickedUpCallback = _onPickedUpCallback;
			if (_onPickedUpCallback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v15 @ rax_v2 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
			_onPickedUpCallback = null;
			_gameManager.AddRelicToQueue(_itemType, _targetPlayer);
			base.SetHasSeenItem(_itemType);
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
		}
	}

	protected void OnRelicTypeSetRemotely(int oldType, int newType)
	{
		SetItemType((ItemType)newType);
	}

	private void ProcessNewItemType()
	{
		DataManager dataManager = _dataManager;
		if (((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).TryGetValue((System.Int32Enum)_itemType, out object value))
		{
			_itemData = (ItemData)value;
		}
		if (_itemData != null)
		{
			ItemData itemData = _itemData;
			if (itemData._003Ctexture_003Ek__BackingField != null)
			{
				_textureName = itemData._003Ctexture_003Ek__BackingField;
			}
			ItemData itemData2 = _itemData;
			SetFrame(itemData2._003CframeName_003Ek__BackingField);
		}
	}

	protected override void OnRecycle()
	{
		//IL_00ee: Expected I, but got O
		//IL_0178: Expected I4, but got I8
		//IL_0194: Expected O, but got I4
		//IL_0098->IL03cc: Incompatible stack heights: 1 vs 0
		//IL_00c4->IL03cc: Incompatible stack heights: 1 vs 0
		//IL_0133->IL03cc: Incompatible stack heights: 1 vs 0
		//IL_0111->IL0111: Incompatible stack heights: 2 vs 1
		//IL_01cf->IL03cc: Incompatible stack heights: 1 vs 0
		//IL_0240->IL03cc: Incompatible stack heights: 1 vs 0
		//IL_04b6->IL03cc: Incompatible stack heights: 1 vs 0
		//IL_033e->IL03cc: Incompatible stack heights: 1 vs 0
		//IL_0371->IL03cc: Incompatible stack heights: 1 vs 0
		base.OnRecycle();
		_colorValue = 0f;
		if ((object)_shadow != null)
		{
			Transform transform = _shadow.transform;
			object cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdi_v7 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdi_v7 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					StartFloatTween();
					if (_shadowTween != null)
					{
						_shadowTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if ((object)_shadow != null)
					{
						Transform transform2 = _shadow.transform;
						if (array != null)
						{
							if ((object)transform2 != null)
							{
								nint num = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj = default(object);
								bool flag2 = obj == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								tweenConfig.duration = 1000f;
								tweenConfig.ease = Ease.InOutSine;
								tweenConfig.repeat = -1;
								tweenConfig.yoyo = true;
								tweenConfig.scale = (float?)(object)1;
								MultiTargetTween shadowTween = Tweens.Add(tweenConfig);
								_shadowTween = shadowTween;
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
										TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(glow._spriteRenderer, 0f, 0.5f);
										if (tweenerCore != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v810 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v810 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v810 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
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
											_glowTween = tweenerCore;
											if ((object)_glow != null)
											{
												PhaserSprite phaserSprite2 = _glow.setBlendMode(BlendMode.Add);
												if ((object)_glow != null)
												{
													PhaserSprite phaserSprite3 = _glow.setAlpha(0.5f);
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
				else
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateGlowColor()
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
		if (_floatTween != null)
		{
			_floatTween.Kill();
		}
		_floatTween = null;
		if (_shadowTween != null)
		{
			_shadowTween.Kill();
		}
		_shadowTween = null;
		if (_glowTween != null)
		{
			TweenExtensions.Kill(_glowTween);
		}
	}

	public void StopFloatTween()
	{
		if (_floatTween != null)
		{
			_floatTween.Kill();
		}
		_floatTween = null;
	}

	public void StartFloatTween()
	{
		//IL_0076: Expected I, but got O
		//IL_00ec: Expected I4, but got I8
		//IL_0108: Expected O, but got I4
		if (_floatTween != null)
		{
			_floatTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		CheckRenderer();
		Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
		if ((object)transform != null)
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
		tweenConfig.duration = 1000f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.repeat = -1;
		tweenConfig.yoyo = true;
		tweenConfig.localY = (float?)(object)1;
		MultiTargetTween floatTween = Tweens.Add(tweenConfig);
		_floatTween = floatTween;
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

	protected override void TrackItemPickup(bool trackRunPickup = true)
	{
		PlayerOptionsData config = _playerOptions.Config;
		_playerOptions.TrackItemPickup(_itemType, config, trackRunPickup);
	}

	public void SpawnCursor()
	{
		CursorData cursorData = new CursorData();
		cursorData.IconAlpha = 1f;
		cursorData._cursorProportionOfScreenFromCenter = 0.45f;
		cursorData.AnimationName = "arrow_0";
		cursorData.AnimationStartingFrame = 1;
		cursorData.AnimationFramesCount = 8;
		cursorData.AnimationFrameRate = 16;
		Sprite sprite = SpriteManager.GetSprite("arrow_01", "UI");
		cursorData.CursorSprite = sprite;
		cursorData.CursorScale = 2f;
		cursorData.CursorAlpha = 1f;
		cursorData.CursorColorHex = "#00ff00";
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
	}

	public void HideCursor()
	{
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
	}
}
