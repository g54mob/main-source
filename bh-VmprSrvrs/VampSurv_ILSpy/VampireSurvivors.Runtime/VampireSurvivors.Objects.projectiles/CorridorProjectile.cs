using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class CorridorProjectile : Projectile
{
	private SpriteRenderer _CorridorBg;

	private SpriteRenderer _CorridorLight;

	private Tween _angleTween;

	private Tween _scaleTween;

	private Tween _alphaTweenBg;

	private Tween _alphaTweenLight;

	private float _worldScreenHeight = 1f;

	private float _targetScale;

	private float _targetAlpha;

	private float _startAlpha;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_023f: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_002e: Expected I4, but got O
		//IL_0299: Expected O, but got F4
		//IL_01e5: Expected F4, but got I4
		//IL_0304: Expected O, but got I4
		//IL_031f: Expected O, but got I4
		//IL_00c9->IL0216: Incompatible stack heights: 1 vs 0
		//IL_00eb->IL0216: Incompatible stack heights: 1 vs 0
		//IL_011a->IL0216: Incompatible stack heights: 1 vs 0
		//IL_02e5->IL0216: Incompatible stack heights: 1 vs 0
		//IL_0178->IL0216: Incompatible stack heights: 1 vs 0
		//IL_01a7->IL0216: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(64f, (float?)(object)0, (float?)(object)0);
			int num = (int)_mainCamera;
			if ((object)_mainCamera != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rsi_v5 (System.Int32)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rsi_v5 (System.Int32)+10]");
				object obj = Camera.get_orthographicSize_Injected((IntPtr)0);
				object obj2 = default(object);
				float worldScreenHeight = (float)obj2 + (float)obj2;
				_worldScreenHeight = worldScreenHeight;
				float num2 = (float)CameraExtensions.OrthographicBounds(_mainCamera).m_Extents * 2f;
				float num3 = num2 * 100f;
				Weapon weapon2 = _weapon;
				float targetScale = num3 * (1f / 128f);
				_targetScale = targetScale;
				if ((object)_weapon != null && weapon2._playerOptions != null)
				{
					PlayerOptionsData config = weapon2._playerOptions.Config;
					if (config != null)
					{
						bool flag2 = config._003CFlashingVFXEnabled_003Ek__BackingField;
						float targetAlpha = 1f;
						if (!flag2)
						{
							targetAlpha = 0.2f;
						}
						_targetAlpha = targetAlpha;
						Weapon weapon3 = _weapon;
						if ((object)_weapon != null && weapon3._playerOptions != null)
						{
							PlayerOptionsData config2 = weapon3._playerOptions.Config;
							if (config2 != null)
							{
								float startAlpha = ((!config2._003CFlashingVFXEnabled_003Ek__BackingField) ? 0f : 0.75f);
								_startAlpha = startAlpha;
								ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
								float time = default(float);
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Corridor, new SoundManager.SoundConfig
								{
									Volume = (float?)(object)1,
									Rate = 1f,
									Detune = -500f
								}, 400f, 1, time);
								InAnim();
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01fc: Expected O, but got I4
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected I4, but got Unknown
		Weapon weapon = _weapon;
		Transform cachedTransform = _cachedTransform;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)_cachedTransform == null;
				bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
				float worldScreenHeight = _worldScreenHeight;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj = worldScreenHeight ^ 0;
				float num = (float)obj * 100f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
				bool flag4 = (object)_CorridorBg == null;
				int sortingOrder = default(int);
				_CorridorBg.sortingOrder = sortingOrder;
				CorridorProjectile corridorBg = (CorridorProjectile)(object)_CorridorBg;
				bool flag5 = (object)_CorridorBg == null;
				bool flag6 = ((UnityEngine.Object)corridorBg).m_CachedPtr == (IntPtr)0;
				object obj2 = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)corridorBg).m_CachedPtr);
				bool flag7 = (object)_CorridorLight == null;
				int sortingOrder2 = obj2 + 1;
				_CorridorLight.sortingOrder = sortingOrder2;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4040]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Despawn();
		if (_angleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_angleTween);
		}
		_angleTween = null;
		if (_scaleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_scaleTween);
		}
		_scaleTween = null;
		if (_alphaTweenBg != null)
		{
			DG.Tweening.TweenExtensions.Kill(_alphaTweenBg);
		}
		_alphaTweenBg = null;
		if (_alphaTweenLight != null)
		{
			DG.Tweening.TweenExtensions.Kill(_alphaTweenLight);
		}
		_alphaTweenLight = null;
		ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("CorridorProjectile");
		GameObject obj = base.gameObject;
		pool.Release(obj);
	}

	private unsafe void InAnim()
	{
		//IL_0094: Expected O, but got Ref
		//IL_00a5: Expected O, but got I8
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_06e0: Expected O, but got I4
		//IL_06f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f5: Expected O, but got Unknown
		//IL_0641->IL05a7: Incompatible stack heights: 1 vs 0
		//IL_068f->IL05a7: Incompatible stack heights: 1 vs 0
		//IL_06ae->IL05a7: Incompatible stack heights: 1 vs 0
		//IL_06cd->IL05a7: Incompatible stack heights: 1 vs 0
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_CorridorBg, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_CorridorLight, _startAlpha);
		Transform cachedTransform = _cachedTransform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			if (_angleTween != null)
			{
				DG.Tweening.TweenExtensions.Kill(_angleTween);
			}
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&ret), 2f, RotateMode.FastBeyond360);
			object obj = 6603577472L;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 1;
						_ = 0;
					}
				}
			}
			_angleTween = tweenerCore;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (_angleTween != null)
			{
				if (_scaleTween != null)
				{
					DG.Tweening.TweenExtensions.Kill(_scaleTween);
				}
				tweenerCore2 = ShortcutExtensions.DOScale(_cachedTransform, _targetScale, 1f);
				TweenCallback tweenCallback2;
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ rax_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
						bool flag2 = (nint)0 == 0;
						_ = 0;
						if (!flag2)
						{
							object obj2 = tweenerCore2 + 184;
							object obj3 = obj2 >> 12;
							object obj4 = obj3 & 0x1FFFFF;
							object obj5 = obj4 >> 6;
							object obj6 = obj4 & 0x3F;
							nint num2;
							do
							{
								object obj7 = 1 << (int)obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rbp_v4+462E0+v804 @ rdx_v48*8]");
								object obj8 = 0 | obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rbp_v4+462E0+v804 @ rdx_v48*8]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rbp_v4+462E0+v804 @ rdx_v48*8]");
								if (num == 0)
								{
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rbp_v4+462E0+v804 @ rdx_v48*8]");
								num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rbp_v4+462E0+v804 @ rdx_v48*8]");
							}
							while (num2 != 0);
							TweenCallback tweenCallback = OutAnim;
							tweenCallback2 = tweenCallback;
							goto IL_033c;
						}
					}
				}
				TweenCallback tweenCallback3 = OutAnim;
				bool flag3 = tweenerCore2 == null;
				tweenCallback2 = tweenCallback3;
				if (!flag3)
				{
					goto IL_033c;
				}
				goto IL_036b;
			}
		}
		goto IL_05a7;
		IL_036b:
		_scaleTween = tweenerCore2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_scaleTween != null)
		{
			if (_alphaTweenBg != null)
			{
				DG.Tweening.TweenExtensions.Kill(_alphaTweenBg);
			}
			TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(_CorridorBg, _targetAlpha, 1f);
			if (tweenerCore3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			_alphaTweenBg = tweenerCore3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (_alphaTweenBg != null)
			{
				if (_alphaTweenLight != null)
				{
					DG.Tweening.TweenExtensions.Kill(_alphaTweenLight);
				}
				TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleSprite.DOFade(_CorridorLight, _targetAlpha, 1f);
				if (tweenerCore4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v39 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
				}
				_alphaTweenLight = tweenerCore4;
				Tween alphaTweenLight = _alphaTweenLight;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (_alphaTweenLight != null)
				{
					alphaTweenLight.stringId = "DefaultGameTweenId";
					return;
				}
			}
		}
		goto IL_05a7;
		IL_05a7:
		throw new NullReferenceException();
		IL_033c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ rax_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_036b;
	}

	private void OutAnim()
	{
		//IL_00a1: Expected I, but got O
		if (_scaleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_scaleTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, 0f, 1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CorridorProjectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		_scaleTween = tweenerCore;
		Tween scaleTween = _scaleTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		scaleTween.stringId = "DefaultGameTweenId";
		if (_alphaTweenBg != null)
		{
			DG.Tweening.TweenExtensions.Kill(_alphaTweenBg);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_CorridorBg, 0f, 1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		_alphaTweenBg = tweenerCore2;
		Tween alphaTweenBg = _alphaTweenBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		alphaTweenBg.stringId = "DefaultGameTweenId";
		if (_alphaTweenLight != null)
		{
			DG.Tweening.TweenExtensions.Kill(_alphaTweenLight);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(_CorridorLight, _startAlpha, 1f);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		_alphaTweenLight = tweenerCore3;
		Tween alphaTweenLight = _alphaTweenLight;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		alphaTweenLight.stringId = "DefaultGameTweenId";
	}
}
