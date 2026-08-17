using System;
using System.Globalization;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Graphics;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Unused_LEM_Inferno2_Projectile : Projectile
{
	private GenericShadowText _TextCounter;

	private SpriteRenderer _ColourBlockRenderer;

	private Texture _RedTexture;

	private Color _RedTint;

	private Texture _BlueTexture;

	private Color _BlueTint;

	private SpriteRenderer _FlameRenderer;

	private Unused_LEM_Inferno2_Weapon _trueWeapon;

	private Material _instancedMaterial;

	private Material _instancedMaterial2;

	private float _projHeight;

	private float _naneinfPercentage;

	private bool _isRising;

	private Tween _scaleTween;

	private Tween _posTween;

	private MultiTargetTween _fadeTween;

	private float ProjWidth
	{
		get
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			return renderer.screenWidthPixels * 0.5f;
		}
	}

	private bool IsFirstProj => _indexInWeapon == 0;

	private bool NaneinfReached
	{
		get
		{
			bool flag = _naneinfPercentage < 1f;
			return !flag;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		Material instancedMaterial = _instancedMaterial;
		if ((object)_instancedMaterial == null || ((UnityEngine.Object)instancedMaterial).m_CachedPtr == (IntPtr)0)
		{
			Material material = ((Renderer)_FlameRenderer).GetMaterial();
			_instancedMaterial = material;
			((Renderer)_FlameRenderer).SetMaterial(_instancedMaterial);
		}
		Material instancedMaterial2 = _instancedMaterial2;
		if ((object)_instancedMaterial2 == null || ((UnityEngine.Object)instancedMaterial2).m_CachedPtr == (IntPtr)0)
		{
			Material material2 = ((Renderer)_ColourBlockRenderer).GetMaterial();
			_instancedMaterial2 = material2;
			((Renderer)_ColourBlockRenderer).SetMaterial(_instancedMaterial2);
		}
		_ColourBlockRenderer.enabled = true;
		_FlameRenderer.enabled = true;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0027: Expected I, but got O
		//IL_002f: Expected I, but got O
		//IL_003f: Expected O, but got I
		//IL_00bf: Expected O, but got I4
		//IL_007b: Expected O, but got I
		//IL_00b1: Expected O, but got I4
		//IL_014c: Invalid comparison between I4 and F4
		//IL_0197: Expected F4, but got I4
		//IL_0359: Expected I, but got O
		//IL_026a: Expected O, but got I4
		//IL_026a: Expected O, but got I4
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_02b6: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		Unused_LEM_Inferno2_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_030b;
		}
		nint num = (nint)typeof(Unused_LEM_Inferno2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_LEM_Inferno2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_LEM_Inferno2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v46+FFFFFFF8+v68 @ rax_v41*8]");
			if (0 == (nint)typeof(Unused_LEM_Inferno2_Weapon))
			{
				obj3 = 1;
				goto IL_031a;
			}
		}
		obj3 = 0;
		goto IL_031a;
		IL_031a:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (Unused_LEM_Inferno2_Weapon)_weapon;
		}
		goto IL_030b;
		IL_030b:
		_trueWeapon = trueWeapon;
		_isCullable = false;
		Camera main = Camera.main;
		Transform parent = main.transform;
		Transform transform = base.transform;
		transform.SetParent(parent, worldPositionStays: true);
		Unused_LEM_Inferno2_Weapon trueWeapon2 = _trueWeapon;
		float num4 = (float)trueWeapon2._killsSinceLastNaneinf / 3080f;
		if (!(0f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = 0f;
		}
		_naneinfPercentage = num4;
		if ((object)GM.Core != null)
		{
			nint num5 = (nint)typeof(ArcadePhysics);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rax_v17 (Il2CppClass<ArcadePhysics>)+B8]");
			nint num6 = 0;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			bool flag2 = !(_naneinfPercentage < 1f);
			float num7 = 1f;
			if (!flag2)
			{
				num7 = 0.8f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
			float num8 = _naneinfPercentage * 0.8f;
			float num9 = num7 * renderer.screenHeightPixels;
			float num10 = num8 * renderer.screenHeightPixels;
			float num11 = renderer.screenHeightPixels * 0.2f;
			float num12 = num10 + num11;
			if (!(num12 > num9))
			{
				num9 = num12;
			}
			_projHeight = num9;
			InitPosition();
			BaseBody baseBody = body;
			bool enable = _indexInWeapon == 0;
			baseBody._enable = enable;
			BaseBody baseBody2 = body;
			if (baseBody2._enable)
			{
				float projWidth = ProjWidth;
				BaseBody baseBody3 = baseBody2.setSize((float?)(object)1, (float?)(object)1);
				float projWidth2 = ProjWidth;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj4 = projWidth2 ^ 0;
				float x = (float)obj4 * 0.5f;
				BaseBody baseBody4 = body.setOffset(x, (float?)(object)1);
			}
			InitSprites();
			SetText();
			FadeIn();
			ScaleIn();
			return;
		}
		throw new NullReferenceException();
	}

	private void InitPosition()
	{
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (_indexInWeapon != 0 || (object)GM.Core != null))
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
				{
					Camera main = Camera.main;
					if ((object)main != null)
					{
						Transform transform = main.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
							object cachedTransform = _cachedTransform;
							bool flag2 = (object)_cachedTransform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdi_v7 (System.Object)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdi_v7 (System.Object)+10]");
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected((IntPtr)0, ref value);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void InitBody()
	{
		//IL_0076: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00c2: Expected O, but got I4
		BaseBody baseBody = body;
		bool enable = _indexInWeapon == 0;
		baseBody._enable = enable;
		BaseBody baseBody2 = body;
		if (baseBody2._enable)
		{
			float projWidth = ProjWidth;
			BaseBody baseBody3 = baseBody2.setSize((float?)(object)1, (float?)(object)1);
			float projWidth2 = ProjWidth;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = projWidth2 ^ 0;
			float x = (float)obj * 0.5f;
			BaseBody baseBody4 = body.setOffset(x, (float?)(object)1);
		}
	}

	private void InitSprites()
	{
		Texture value = ((_indexInWeapon != 0) ? _RedTexture : _BlueTexture);
		Material instancedMaterial = _instancedMaterial;
		if ((object)_instancedMaterial != null && ((UnityEngine.Object)instancedMaterial).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_instancedMaterial == null)
			{
				goto IL_0240;
			}
			int num = Shader.PropertyToID("_GradientLookUp");
			_instancedMaterial.SetTextureImpl(num, value);
		}
		Material instancedMaterial2 = _instancedMaterial2;
		if ((object)_instancedMaterial2 != null && ((UnityEngine.Object)instancedMaterial2).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_instancedMaterial2 == null)
			{
				goto IL_0240;
			}
			int num2 = Shader.PropertyToID("_GradientLookUp");
			_instancedMaterial2.SetTextureImpl(num2, value);
		}
		float projWidth = ProjWidth;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ColourBlockRenderer, projWidth, 0f);
		float projWidth2 = ProjWidth;
		float xScale = projWidth2 * (1f / 128f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_FlameRenderer, xScale, 1f);
		if ((object)_ColourBlockRenderer != null)
		{
			Transform transform = _ColourBlockRenderer.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
			Transform transform2 = _FlameRenderer.transform;
			bool flag2 = (object)transform2 == null;
			bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Vector3 value3 = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value3);
			bool flag4 = (object)_ColourBlockRenderer == null;
			_ColourBlockRenderer.sortingOrder = 999;
			bool flag5 = (object)_FlameRenderer == null;
			_FlameRenderer.sortingOrder = 999;
			bool flag6 = (object)_TextCounter == null;
			_TextCounter.SetDepth(1001);
			return;
		}
		goto IL_0240;
		IL_0240:
		throw new NullReferenceException();
	}

	private void FadeIn()
	{
		//IL_00aa: Expected I, but got O
		//IL_0102: Expected I, but got O
		//IL_0166: Expected O, but got I4
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ColourBlockRenderer, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_FlameRenderer, 0f);
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_ColourBlockRenderer != null)
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
		if ((object)_FlameRenderer != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = CheckForFullAlphaFade;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
		_fadeTween = fadeTween;
	}

	private void CheckForFullAlphaFade()
	{
		//IL_007d: Expected I, but got O
		//IL_00d5: Expected I, but got O
		//IL_0139: Expected O, but got I4
		if (_naneinfPercentage < 1f)
		{
			return;
		}
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_ColourBlockRenderer != null)
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
		if ((object)_FlameRenderer != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
		_fadeTween = fadeTween;
	}

	private void ScaleIn()
	{
		//IL_0053: Expected O, but got I8
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0382: Expected O, but got I4
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		_isRising = true;
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		Transform target = _ColourBlockRenderer.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleY(target, _projHeight, 1f);
		object obj = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					object obj2 = tweenerCore + 184;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbp_v2+462E0+v257 @ rdx_v29*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbp_v2+462E0+v257 @ rdx_v29*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbp_v2+462E0+v257 @ rdx_v29*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbp_v2+462E0+v257 @ rdx_v29*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbp_v2+462E0+v257 @ rdx_v29*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = ScaleOut;
					tweenCallback2 = tweenCallback;
					goto IL_0179;
				}
			}
		}
		TweenCallback tweenCallback3 = ScaleOut;
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag2)
		{
			goto IL_0179;
		}
		goto IL_01a8;
		IL_0179:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_01a8;
		IL_01a8:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
		if (_posTween != null)
		{
			TweenExtensions.Kill(_posTween);
		}
		Transform target2 = _ColourBlockRenderer.transform;
		float num3 = _projHeight * 0.5f;
		float endValue = num3 * 0.01f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMoveY(target2, endValue, 1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
		_posTween = tweenerCore2;
	}

	private void ScaleOut()
	{
		//IL_0071: Expected O, but got I8
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_03b0: Expected O, but got I4
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected O, but got Unknown
		_isRising = false;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;
		if (_naneinfPercentage < 1f)
		{
			if (_scaleTween != null)
			{
				TweenExtensions.Kill(_scaleTween);
			}
			Transform target = _ColourBlockRenderer.transform;
			tweenerCore = ShortcutExtensions.DOScaleY(target, 0f, 1f);
			object obj = 6603577472L;
			TweenCallback tweenCallback2;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag = (nint)0 == 0;
					_ = 0;
					if (!flag)
					{
						object obj2 = tweenerCore + 184;
						object obj3 = obj2 >> 12;
						object obj4 = obj3 & 0x1FFFFF;
						object obj5 = obj4 >> 6;
						object obj6 = obj4 & 0x3F;
						nint num2;
						do
						{
							object obj7 = 1 << (int)obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbp_v5+462E0+v335 @ rdx_v30*8]");
							object obj8 = 0 | obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbp_v5+462E0+v335 @ rdx_v30*8]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbp_v5+462E0+v335 @ rdx_v30*8]");
							if (num == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbp_v5+462E0+v335 @ rdx_v30*8]");
							num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbp_v5+462E0+v335 @ rdx_v30*8]");
						}
						while (num2 != 0);
						TweenCallback tweenCallback = FadeOut;
						tweenCallback2 = tweenCallback;
						goto IL_0197;
					}
				}
			}
			TweenCallback tweenCallback3 = FadeOut;
			bool flag2 = tweenerCore == null;
			tweenCallback2 = tweenCallback3;
			if (!flag2)
			{
				goto IL_0197;
			}
			goto IL_01c6;
		}
		if (_indexInWeapon == 0)
		{
			_trueWeapon.TriggerNaneinf();
		}
		return;
		IL_01c6:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
		if (_posTween != null)
		{
			TweenExtensions.Kill(_posTween);
		}
		Transform target2 = _ColourBlockRenderer.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMoveY(target2, 0f, 1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_posTween = tweenerCore2;
		return;
		IL_0197:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_01c6;
	}

	private float GetProjHeight()
	{
		//IL_0070: Expected I, but got O
		//IL_0083: Expected I, but got O
		nint num = (nint)typeof(GM);
		nint num2 = (nint)typeof(ArcadePhysics);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v6 (Il2CppClass<ArcadePhysics>)+B8]");
		nint num3 = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		bool flag = !(_naneinfPercentage < 1f);
		float num4 = 1f;
		if (!flag)
		{
			num4 = 0.8f;
		}
		float num5 = num4 * renderer.screenHeightPixels;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
		float num6 = _naneinfPercentage * 0.8f;
		float num7 = num6 * renderer.screenHeightPixels;
		float num8 = renderer.screenHeightPixels * 0.2f;
		float num9 = num7 + num8;
		if (num5 > num9)
		{
			num5 = num9;
		}
		return num5;
	}

	private unsafe void SetText()
	{
		//IL_0158: Expected O, but got I
		//IL_007a: Expected O, but got I8
		//IL_0100: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4B1C]");
		bool flag = (nint)0 != 0;
		Unused_LEM_Inferno2_Projectile unused_LEM_Inferno2_Projectile = this;
		if (!flag)
		{
			_ = 1;
			unused_LEM_Inferno2_Projectile = (Unused_LEM_Inferno2_Projectile)(object)"#.##";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			unused_LEM_Inferno2_Projectile = (Unused_LEM_Inferno2_Projectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v47 @ rax_v3 (should have been resolved before IL gen)");
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text = System.Number.FormatSingle(1.01f, "#.##", currentInfo);
		float num = _naneinfPercentage * 154f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		int num2 = default(int);
		bool flag2 = num2 >= 11;
		int value = num2;
		if (!flag2)
		{
			value = 11;
		}
		object obj2 = default(object);
		string text2 = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj2), null);
		string text3 = text + "e" + text2;
		GenericShadowText textCounter = _TextCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	public override void InternalUpdate()
	{
		//IL_00aa: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		//IL_00cb: Expected O, but got F4
		//IL_00ef: Expected O, but got I4
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			float num2;
			if (_isRising)
			{
				float num = TweenExtensions.ElapsedPercentage(_scaleTween);
				num2 = num;
			}
			else
			{
				float num3 = TweenExtensions.ElapsedPercentage(_scaleTween);
				num2 = 1f - num3;
			}
			float num4 = num2 * ((float)Math.PI / 2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float projWidth = ProjWidth;
			BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
			float projWidth2 = ProjWidth;
			object obj = projWidth2 ^ -0f;
			float x = (float)obj * 0.5f;
			BaseBody baseBody3 = body.setOffset(x, (float?)(object)1);
		}
	}

	private void LateUpdate()
	{
		UpdateFlame();
	}

	private void UpdateBody()
	{
		//IL_00aa: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		//IL_00cb: Expected O, but got F4
		//IL_00ef: Expected O, but got I4
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			float num2;
			if (_isRising)
			{
				float num = TweenExtensions.ElapsedPercentage(_scaleTween);
				num2 = num;
			}
			else
			{
				float num3 = TweenExtensions.ElapsedPercentage(_scaleTween);
				num2 = 1f - num3;
			}
			float num4 = num2 * ((float)Math.PI / 2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float projWidth = ProjWidth;
			BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
			float projWidth2 = ProjWidth;
			object obj = projWidth2 ^ -0f;
			float x = (float)obj * 0.5f;
			BaseBody baseBody3 = body.setOffset(x, (float?)(object)1);
		}
	}

	private void UpdateFlame()
	{
		//IL_010e->IL00bd: Incompatible stack heights: 1 vs 0
		//IL_007c->IL00bd: Incompatible stack heights: 1 vs 0
		if ((object)_FlameRenderer != null)
		{
			Transform transform = _FlameRenderer.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_ColourBlockRenderer != null)
				{
					Transform transform2 = _ColourBlockRenderer.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
						bool flag3 = (object)_FlameRenderer == null;
						Transform transform3 = _FlameRenderer.transform;
						bool flag4 = (object)transform3 == null;
						bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref ret);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateText()
	{
	}

	private void FadeOut()
	{
		//IL_008b: Expected I, but got O
		//IL_00e3: Expected I, but got O
		//IL_0147: Expected O, but got I4
		//IL_0162: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_ColourBlockRenderer != null)
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
		if ((object)_FlameRenderer != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Unused_LEM_Inferno2_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num3 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
		_fadeTween = fadeTween;
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		if (_posTween != null)
		{
			TweenExtensions.Kill(_posTween);
		}
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		base.Despawn();
	}
}
