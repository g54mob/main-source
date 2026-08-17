using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Elevator_Weapon : TP_Clockwork_Weapon
{
	private Transform _cachedCameraTransform;

	private Vector2 _leftOffset;

	private Vector2 _rightOffset;

	private Tween cableTween1;

	private Tween cableTween2;

	private TileSprite _003CChainSpriteL_003Ek__BackingField;

	private TileSprite _003CChainSpriteR_003Ek__BackingField;

	private Transform _003CRightTransform_003Ek__BackingField;

	private Transform _003CLeftTransform_003Ek__BackingField;

	public TileSprite ChainSpriteL
	{
		get
		{
			return _003CChainSpriteL_003Ek__BackingField;
		}
		set
		{
			_003CChainSpriteL_003Ek__BackingField = value;
		}
	}

	public TileSprite ChainSpriteR
	{
		get
		{
			return _003CChainSpriteR_003Ek__BackingField;
		}
		set
		{
			_003CChainSpriteR_003Ek__BackingField = value;
		}
	}

	public Transform RightTransform
	{
		get
		{
			return _003CRightTransform_003Ek__BackingField;
		}
		set
		{
			_003CRightTransform_003Ek__BackingField = value;
		}
	}

	public Transform LeftTransform
	{
		get
		{
			return _003CLeftTransform_003Ek__BackingField;
		}
		set
		{
			_003CLeftTransform_003Ek__BackingField = value;
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0089: Invalid comparison between F4 and I4
		//IL_00b2: Expected O, but got I4
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0192: Expected O, but got F4
		//IL_01b2: Expected O, but got F4
		base.InitWeapon(characterController, weaponType);
		Camera main = Camera.main;
		Transform cachedCameraTransform = main.transform;
		_cachedCameraTransform = cachedCameraTransform;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		bool flag = renderer.width < renderer2.height;
		float num = renderer.width - renderer2.height;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj = flag4 & flag3;
		float num2 = ((obj == null) ? 0.465f : 0.33f);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj2 = num2 ^ 0;
			object obj3 = obj2 * renderer3.width;
			float num3 = (float)obj3 - 0.25f;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer4 = s_scene4._renderer;
				float num4 = num2 * renderer4.width;
				_ = 0;
				_leftOffset = (Vector2)num3;
				_ = 0;
				float num5 = num4 + 0.25f;
				_rightOffset = (Vector2)num5;
				GameObject go = base.gameObject;
				string spriteName = default(string);
				TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, 0f, 0f, "ThosePeople", spriteName);
				tileSpriteBuilder._depth = 1992f;
				tileSpriteBuilder._depthMul = 1f;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene5 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer5 = s_scene5._renderer;
					float tileHeight = renderer5.screenHeight + renderer5.screenHeight;
					tileSpriteBuilder._tileWidth = 0.05f;
					tileSpriteBuilder._tileHeight = tileHeight;
					tileSpriteBuilder._name = "Elevator Chains";
					TileSprite tileSprite = tileSpriteBuilder.Build();
					_003CChainSpriteL_003Ek__BackingField = tileSprite;
					TileSprite tileSprite2 = RenderingExtensions.SetScrollFactor(_003CChainSpriteL_003Ek__BackingField, 0f);
					TileSprite tileSprite3 = _003CChainSpriteL_003Ek__BackingField;
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(tileSprite3._spriteRenderer, 0.75f);
					TileSprite tileSprite4 = tileSpriteBuilder.Build();
					_003CChainSpriteR_003Ek__BackingField = tileSprite4;
					TileSprite tileSprite5 = RenderingExtensions.SetScrollFactor(_003CChainSpriteR_003Ek__BackingField, 0f);
					TileSprite tileSprite6 = _003CChainSpriteR_003Ek__BackingField;
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(tileSprite6._spriteRenderer, 0.75f);
					TileSprite tileSprite7 = _003CChainSpriteL_003Ek__BackingField;
					Transform transform = tileSprite7._spriteRenderer.transform;
					_003CLeftTransform_003Ek__BackingField = transform;
					TileSprite tileSprite8 = _003CChainSpriteR_003Ek__BackingField;
					Transform transform2 = tileSprite8._spriteRenderer.transform;
					_003CRightTransform_003Ek__BackingField = transform2;
					if (cableTween1 != null)
					{
						TweenExtensions.Kill(cableTween1);
					}
					DOGetter<Vector2> dOGetter = null;
					TileSprite tileSprite9 = RenderingExtensions.SetScrollFactor((TileSprite)(object)dOGetter, 0.75f, fullscreen: false);
					DOSetter<Vector2> dOSetter = null;
					TileSprite tileSprite10 = RenderingExtensions.SetScrollFactor((TileSprite)(object)dOSetter, 0.75f, fullscreen: false);
					Vector2 endValue = default(Vector2);
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(dOGetter, dOSetter, endValue, 2f);
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 4;
							_ = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 4294967295L;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
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
					cableTween1 = tweenerCore;
					if (cableTween2 != null)
					{
						TweenExtensions.Kill(cableTween2);
					}
					DOGetter<Vector2> dOGetter2 = null;
					TileSprite tileSprite11 = RenderingExtensions.SetScrollFactor((TileSprite)(object)dOGetter2, 0.75f, fullscreen: false);
					DOSetter<Vector2> dOSetter2 = null;
					TileSprite tileSprite12 = RenderingExtensions.SetScrollFactor((TileSprite)(object)dOSetter2, 0.75f, fullscreen: false);
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = DOTween.To(dOGetter2, dOSetter2, endValue, 2f);
					if (tweenerCore2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1535 @ rax_v69 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 4;
							_ = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1535 @ rax_v69 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1535 @ rax_v69 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 4294967295L;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1535 @ rax_v69 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
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
					cableTween2 = tweenerCore2;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		((Weapon)this).InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((((Weapon)this)._003CTotalTime_003Ek__BackingField = num2 + ((Weapon)this)._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			((Weapon)this)._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
			FireOthers();
		}
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Transform transform2 = _003CLeftTransform_003Ek__BackingField;
				bool flag2 = (object)_003CLeftTransform_003Ek__BackingField == null;
				bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				Transform transform3 = _003CRightTransform_003Ek__BackingField;
				bool flag4 = (object)_003CRightTransform_003Ek__BackingField == null;
				bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref ret);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void FireProjectiles(Vector2 pos)
	{
		//IL_01d9: Expected O, but got F4
		//IL_0096: Expected F4, but got I4
		//IL_019d: Expected O, but got F4
		//IL_01cb: Expected F4, but got I4
		//IL_0142->IL009f: Incompatible stack heights: 1 vs 0
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		if (!flag)
		{
			bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
			Transform transform;
			Transform transform2;
			if (!flag)
			{
				transform = _003CRightTransform_003Ek__BackingField;
				transform2 = _003CLeftTransform_003Ek__BackingField;
			}
			else
			{
				transform = _003CLeftTransform_003Ek__BackingField;
				transform2 = _003CRightTransform_003Ek__BackingField;
			}
			if ((object)transform != null)
			{
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Vector2 pos2 = default(Vector2);
				Projectile projectile = base.FireOneProjectile(pos2, 0, transform);
				if ((object)transform2 != null)
				{
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
					Projectile projectile2 = base.FireOneProjectile(pos2, 1, transform2);
					object obj = UnityEngine.Random.value;
					float? volume = default(float?);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Door, 200f, 5, 0f, volume, rate, detune, loop, 1f);
					object obj2 = UnityEngine.Random.value;
					PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Swing, 1000f, 3, 0f, volume, rate, detune, loop, 1f);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Cleanup()
	{
		if (cableTween1 != null)
		{
			TweenExtensions.Kill(cableTween1);
		}
		if (cableTween2 != null)
		{
			TweenExtensions.Kill(cableTween2);
		}
		if ((object)_003CChainSpriteL_003Ek__BackingField != null)
		{
			_003CChainSpriteL_003Ek__BackingField.SetVisible(visible: false);
		}
		if ((object)_003CChainSpriteR_003Ek__BackingField != null)
		{
			_003CChainSpriteR_003Ek__BackingField.SetVisible(visible: false);
		}
		base.Cleanup();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_003CChainSpriteL_003Ek__BackingField.SetVisible(visible);
		_003CChainSpriteR_003Ek__BackingField.SetVisible(visible);
	}

	private Vector2 _003CInitWeapon_003Eb__21_0()
	{
		Vector2 result = default(Vector2);
		return result;
	}

	private void _003CInitWeapon_003Eb__21_1(Vector2 x)
	{
		_leftOffset = x;
	}

	private Vector2 _003CInitWeapon_003Eb__21_2()
	{
		Vector2 result = default(Vector2);
		return result;
	}

	private void _003CInitWeapon_003Eb__21_3(Vector2 x)
	{
		_rightOffset = x;
	}
}
