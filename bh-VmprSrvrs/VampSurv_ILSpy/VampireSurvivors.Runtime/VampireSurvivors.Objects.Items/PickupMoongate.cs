using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class PickupMoongate : PickupGuarded
{
	private SpriteRenderer _glow;

	private float _colorValue;

	private Tween _glowTween;

	private ParticleSystem _pfx;

	private PickupMoongate _linkedGate;

	private bool _canTeleport = true;

	private bool _canTeleportLocally;

	private const float TriggerDelay = 20000f;

	public bool CanTeleport
	{
		get
		{
			return _canTeleport;
		}
		set
		{
			_canTeleport = value;
		}
	}

	public bool CanTeleportLocally
	{
		get
		{
			return _canTeleportLocally;
		}
		set
		{
			_canTeleportLocally = value;
		}
	}

	public GameObject Link
	{
		get
		{
			PickupMoongate linkedGate = _linkedGate;
			if ((object)_linkedGate != null && ((UnityEngine.Object)linkedGate).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_linkedGate != null)
				{
					return _linkedGate.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				PickupMoongate component = value.GetComponent<PickupMoongate>();
				_linkedGate = component;
			}
			else
			{
				_linkedGate = null;
			}
		}
	}

	protected override void Awake()
	{
		//IL_005b: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		object cachedTransform = _cachedTransform;
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdi_v1 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 _);
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		SpriteRenderer glow = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "round");
		_glow = glow;
		GenerateParticleSystem();
	}

	public override void InternalUpdate()
	{
		((Pickup)this).InternalUpdate();
		if (!_hasSpawned && IsAnyPlayerInGuardSpawnRange())
		{
			base.TriggerSpawn();
		}
		UpdateGlowColor();
	}

	public void LinkTo(PickupMoongate moongate)
	{
		_linkedGate = moongate;
	}

	public override void UpdateDepth()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		if (_ShowAboveAll)
		{
			num = 1990;
		}
		ArcadeSprite arcadeSprite = setDepth(num);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num2 = default(int);
		_glow.sortingOrder = num2;
		int num3 = num2 + 9;
		RenderingExtensions.SetDepth(_pfx, num3);
	}

	protected override void OnRecycle()
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		base.OnRecycle();
		_colorValue = 0f;
		BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		if (_glowTween != null)
		{
			TweenExtensions.Kill(_glowTween);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_glow, 0f, 0.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
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
		_glowTween = tweenerCore;
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_glow).SetMaterial(material);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_glow, 0.5f);
		_itemRenderer.enabled = false;
		_pfx.Play(withChildren: true);
	}

	private unsafe void UpdateGlowColor()
	{
		float num = (_colorValue += 0.1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num2 = num * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		SpriteRenderer glow = _glow;
		bool flag = ((UnityEngine.Object)glow).m_CachedPtr == (IntPtr)0;
		SpriteRenderer.get_color_Injected(((UnityEngine.Object)glow).m_CachedPtr, out Color _);
		SpriteRenderer glow2 = _glow;
		bool flag2 = (object)_glow == null;
		bool flag3 = ((UnityEngine.Object)glow2).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)glow2).m_CachedPtr, ref *(Color*)(&value));
	}

	public override void GetTaken()
	{
		//IL_036c->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_010d->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_02a3->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_0157->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_02cc->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_0183->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_02f1->IL0371: Incompatible stack heights: 1 vs 0
		//IL_01ce->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_01f0->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_0240->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_0220->IL0371: Incompatible stack heights: 1 vs 0
		//IL_026a->IL02f1: Incompatible stack heights: 1 vs 0
		//IL_0283->IL0371: Incompatible stack heights: 1 vs 0
		if (((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			return;
		}
		if (!_canTeleport)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core == null || core._multiplayer == null)
			{
				goto IL_02f1;
			}
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				return;
			}
		}
		float2 offsetForEachPlayer = default(float2);
		if ((object)_linkedGate != null)
		{
			Transform transform = _linkedGate.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._multiplayer != null)
				{
					if (!core2._multiplayer.IsOnlineMultiplayer)
					{
						goto IL_0283;
					}
					if (_playerOptions != null)
					{
						PlayerOptionsData config = _playerOptions.Config;
						if (config != null)
						{
							if (!config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
							{
								goto IL_0283;
							}
							VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
							if ((object)_targetPlayer != null && (object)targetPlayer._coherenceSync != null)
							{
								if (!targetPlayer._coherenceSync.HasStateAuthority)
								{
									Reset();
									return;
								}
								TempDisableTeleport();
								if ((object)_linkedGate != null)
								{
									_linkedGate.TempDisableTeleport();
									if ((object)_targetPlayer != null)
									{
										_targetPlayer.position = offsetForEachPlayer;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_02f1;
		IL_02f1:
		throw new NullReferenceException();
		IL_0283:
		TempDisableTeleport();
		if ((object)_linkedGate != null)
		{
			_linkedGate.TempDisableTeleport();
			if ((object)GM.Core != null)
			{
				bool focusCameraOnPlayer = default(bool);
				GM.Core.TeleportPlayers(offsetForEachPlayer, offsetForEachPlayer, centered: false, focusCameraOnPlayer);
				return;
			}
		}
		goto IL_02f1;
	}

	public override void GetOnlineTaken()
	{
		GameManager core = GM.Core;
		bool flag;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
			{
				flag = _canTeleportLocally;
				goto IL_00ab;
			}
		}
		flag = _canTeleport;
		goto IL_00ab;
		IL_00ab:
		if (flag)
		{
			base.GetOnlineTaken();
		}
	}

	private bool CheckCanTakeTeleport()
	{
		//IL_0108: Expected I4, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				goto IL_00f3;
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null && core2._playerOptions != null)
			{
				PlayerOptionsData config = core2._playerOptions.Config;
				if (config != null)
				{
					if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
					{
						return _canTeleportLocally;
					}
					goto IL_00f3;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_00f3:
		return _canTeleport;
	}

	private void TempDisableTeleport()
	{
		_canTeleport = false;
		_glow.enabled = false;
		_pfx.Stop();
		Action onComplete = delegate
		{
			_glow.enabled = true;
			_canTeleport = true;
			_pfx.Play(withChildren: true);
			Reset();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(20f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03f4: Expected O, but got Ref
		//IL_0409: Expected native int or pointer, but got O
		//IL_0423: Expected O, but got I
		//IL_0443: Expected O, but got Ref
		//IL_045d: Expected native int or pointer, but got O
		//IL_0477: Expected O, but got I
		//IL_0497: Expected O, but got Ref
		//IL_04b1: Expected native int or pointer, but got O
		//IL_04cb: Expected O, but got I
		//IL_04eb: Expected O, but got Ref
		//IL_0505: Expected native int or pointer, but got O
		//IL_06e1: Expected O, but got I4
		//IL_051d: Expected O, but got Ref
		//IL_0544: Expected O, but got I
		//IL_055e: Expected native int or pointer, but got O
		//IL_06fe: Expected O, but got I4
		//IL_0583: Expected O, but got Ref
		//IL_059d: Expected native int or pointer, but got O
		//IL_0730: Expected O, but got I
		//IL_05f4: Expected O, but got I
		//IL_061b: Expected O, but got I
		//IL_064a: Expected O, but got I
		//IL_077f: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		if (list != null)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"_runes_02.png");
				}
				else
				{
					int num = list._size + 1;
					list._size = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"_runes_03.png");
					}
					else
					{
						int num2 = list._size + 1;
						list._size = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items3 = list._items;
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"_runes_04.png");
						}
						else
						{
							int num3 = list._size + 1;
							list._size = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						string[] items4 = list._items;
						if (list._items != null)
						{
							if (list._size >= items4.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"_runes_05.png");
							}
							else
							{
								int num4 = list._size + 1;
								list._size = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version5 = list._version + 1;
							list._version = version5;
							string[] items5 = list._items;
							if (list._items != null)
							{
								if (list._size >= items5.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"_runes_06.png");
								}
								else
								{
									int num5 = list._size + 1;
									list._size = num5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								if (particleSystemConfig != null)
								{
									particleSystemConfig._frame = list;
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(2000f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
									particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
									particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(240f, 300f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
									particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(10f, 50f));
									particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
									_ = 0;
									_ = 1;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
									particleSystemConfig._quantity = (int?)(object)0;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.3f, 0.5f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
									_ = 0;
									particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
									particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
									_ = 0;
									_ = 0;
									_ = 1140457472;
									_ = 1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
									particleSystemConfig._frequency = (float?)(object)0;
									_ = 11206655;
									_ = 1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
									particleSystemConfig._tint = (uint?)(object)0;
									particleSystemConfig._on = true;
									_ = 1;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
									particleSystemConfig._blendMode = (BlendMode?)(object)0;
									ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
									_pfx = pfx;
									if ((object)_pfx != null)
									{
										Transform transform = _pfx.transform;
										bool flag = ((List<string>)(object)transform)._items == null;
										Vector3 value = default(Vector3);
										Transform.set_localPosition_Injected((IntPtr)((List<string>)(object)transform)._items, ref value);
										return;
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

	private void _003CTempDisableTeleport_003Eb__26_0()
	{
		_glow.enabled = true;
		_canTeleport = true;
		_pfx.Play(withChildren: true);
		Reset();
	}
}
