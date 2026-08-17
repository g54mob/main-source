using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class ShroudProjectile : Projectile
{
	private SpriteRenderer _InversionVFX;

	private SpriteRenderer _Bubble;

	public bool _ShroudActive;

	private Timer _expireTimer;

	private Tween _scaleTween;

	private Tween _inversionTween;

	private Tween _bubbleAlphaTween;

	private Vector3 _parentTransformPos;

	private const float Radius = 16f;

	private bool _enableBodyOnNextFrame;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0023: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_0141: Expected F4, but got O
		//IL_0156: Expected F4, but got I
		//IL_01e9: Expected O, but got I
		//IL_01f8: Expected I4, but got O
		//IL_0366: Expected I, but got O
		//IL_07e6: Expected O, but got I4
		//IL_02bd->IL05c6: Incompatible stack heights: 10 vs 0
		//IL_078e->IL05c6: Incompatible stack heights: 10 vs 0
		//IL_07ab->IL05c6: Incompatible stack heights: 10 vs 0
		//IL_050c->IL05c6: Incompatible stack heights: 10 vs 0
		//IL_07ca->IL05c6: Incompatible stack heights: 10 vs 0
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._enable = false;
			ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)1);
			if (body != null)
			{
				BaseBody baseBody2 = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
				ArcadeSprite arcadeSprite2 = setVisible(visible: false);
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					Transform transform = ((Equipment)weapon2)._003COwner_003Ek__BackingField.transform;
					if ((object)transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v36 (UnityEngine.Transform)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v36 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
						BaseBody baseBody3 = body;
						bool flag2 = body == null;
						baseBody3._position = (float2)ret;
						BaseBody baseBody4 = body;
						bool flag3 = body == null;
						baseBody4.MinX = (float)baseBody4._position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rcx_v35 (BaseBody)+54]");
						baseBody4.MinY = 0f;
						float maxX = (float)baseBody4._size + (float)baseBody4._position;
						baseBody4.MaxX = maxX;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rcx_v35 (BaseBody)+5C]");
						float num = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rcx_v35 (BaseBody)+54]");
						float maxY = num + 0f;
						baseBody4.MaxY = maxY;
						float2 center = baseBody4._halfSize + baseBody4._position;
						baseBody4._center = center;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rcx_v35 (BaseBody)+64]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rcx_v35 (BaseBody)+54]");
						object obj = num2 + 0;
						int num3 = (int)_cachedTransform;
						bool flag4 = (object)_cachedTransform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rsi_v15 (System.Int32)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rsi_v15 (System.Int32)+10]");
						Vector3 value = default(Vector3);
						Transform.set_position_Injected((IntPtr)0, ref value);
						_parentTransformPos = ret;
						_ = 0;
						Transform transform2 = base.transform;
						bool flag6 = (object)transform2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rax_v50 (UnityEngine.Transform)+10]");
						bool flag7 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rax_v50 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref ret);
						bool flag8 = (object)_InversionVFX == null;
						Transform transform3 = _InversionVFX.transform;
						bool flag9 = (object)transform3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1170 @ rax_v58 (UnityEngine.Transform)+10]");
						bool flag10 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1170 @ rax_v58 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref value);
						SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_Bubble, 1f);
						_enableBodyOnNextFrame = true;
						if (_scaleTween != null)
						{
							TweenExtensions.Kill(_scaleTween);
						}
						Transform target = base.transform;
						if ((object)_weapon != null)
						{
							float num4 = _weapon.PArea();
							float num5 = (float)Vector3.zeroVector + (float)Vector3.zeroVector;
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, num5, 0.4f);
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									_ = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1328 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.ShroudProjectile>)+370]");
							TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
							nint num6 = (nint)this;
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 == 0)
								{
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore != null)
							{
								_scaleTween = tweenerCore;
								if (_bubbleAlphaTween != null)
								{
									TweenExtensions.Kill(_bubbleAlphaTween);
								}
								TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_Bubble, 0f, 0.4f);
								if (tweenerCore2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v81 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 1;
										_ = 0;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore2 != null)
								{
									_bubbleAlphaTween = tweenerCore2;
									if ((object)_weapon != null)
									{
										float num7 = _weapon.PArea();
										float num8 = num5 + num5;
										InversionVFX(num8, 200f);
										if ((object)_weapon != null)
										{
											float num9 = _weapon.PAmount();
											float num10 = num8 * 0.25f;
											float num11 = 2f - num10;
											bool flag11 = 1f > num11;
											float rate = 1f;
											if (!flag11)
											{
												rate = num11;
											}
											float time = default(float);
											PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shroud, new SoundManager.SoundConfig
											{
												Volume = (float?)(object)1,
												Rate = rate
											}, 400f, 1, time);
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
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_00c0: Expected O, but got I4
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected I4, but got Unknown
		//IL_020e->IL0189: Incompatible stack heights: 1 vs 0
		//IL_002c->IL0189: Incompatible stack heights: 1 vs 0
		//IL_0235->IL0189: Incompatible stack heights: 1 vs 0
		//IL_0072->IL0189: Incompatible stack heights: 1 vs 0
		//IL_0096->IL0189: Incompatible stack heights: 1 vs 0
		//IL_016b->IL023a: Incompatible stack heights: 2 vs 1
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
			Weapon weapon = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				int num = ((Equipment)weapon)._003COwner_003Ek__BackingField.Depth;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null && (object)_renderer != null)
					{
						int num2 = renderer.pixelHeight >> 31;
						object obj = renderer.pixelHeight - num2;
						object obj2 = obj >> 1;
						int sortingOrder = num - obj2;
						_renderer.sortingOrder = sortingOrder;
						if (_enableBodyOnNextFrame && body != null)
						{
							BaseBody baseBody = body;
							_enableBodyOnNextFrame = false;
							bool flag2 = body == null;
							baseBody._enable = true;
						}
						bool flag3 = HasSoleSolution();
						bool flag4 = (object)_InversionVFX == null;
						bool flag5 = (byte)((flag3 ? 1u : 0u) ^ 1u) != 0;
						_InversionVFX.enabled = flag5;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private bool HasSoleSolution()
	{
		//IL_008d: Expected O, but got I4
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			ShroudProjectile shroudProjectile = (ShroudProjectile)(object)((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				BulletPool pool = _pool;
				if (_pool != null && pool._physicsType != PhysicsType.DYNAMIC_BODY)
				{
					List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
					while (enumerator.MoveNext())
					{
						object obj = 0;
					}
					return false;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		//IL_010a: Expected O, but got I4
		_ShroudActive = false;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		_scaleTween = null;
		if (_inversionTween != null)
		{
			TweenExtensions.Kill(_inversionTween);
		}
		_inversionTween = null;
		if (_bubbleAlphaTween != null)
		{
			TweenExtensions.Kill(_bubbleAlphaTween);
		}
		_bubbleAlphaTween = null;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		BaseBody baseBody = body;
		baseBody._enable = false;
		base.Despawn();
	}

	private void PlaySound()
	{
		//IL_00af: Expected O, but got I4
		float num = _weapon.PAmount();
		object obj = default(object);
		float num2 = (float)obj * 0.25f;
		float num3 = 2f - num2;
		bool flag = !(1f < num3);
		float rate = 1f;
		if (!flag)
		{
			rate = num3;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = rate;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shroud, soundConfig, 400f, 1, time);
	}

	private void InversionVFX(float radius, float duration)
	{
		//IL_01e5: Expected O, but got I
		Weapon weapon = _weapon;
		PlayerOptionsData config = weapon._playerOptions.Config;
		if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			return;
		}
		_ShroudActive = true;
		if (_inversionTween != null)
		{
			TweenExtensions.Kill(_inversionTween);
		}
		Transform target = _InversionVFX.transform;
		float num = _weapon.PAmount();
		float endValue = radius * 0.32f;
		object obj = default(object);
		float num2 = (float)obj * duration;
		float num3 = num2 * 0.5f;
		float duration2 = num3 * 0.001f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, endValue, duration2);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						object obj2 = num4 + 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_inversionTween = tweenerCore;
	}
}
