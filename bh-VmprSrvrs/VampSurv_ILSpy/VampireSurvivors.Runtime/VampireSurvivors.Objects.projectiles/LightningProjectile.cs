using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LightningProjectile : Projectile
{
	private sealed class _003CDespawnInAFrame_003Ed__4(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LightningProjectile _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00bc: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.Despawn();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private SpriteScroller _SpriteScroller;

	private Tween _moveTween;

	private Tween _despawnTween;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0114: Expected I4, but got O
		//IL_00fd: Expected I4, but got O
		//IL_05f8: Expected I, but got O
		//IL_060f: Expected I, but got O
		//IL_044c: Expected O, but got I4
		//IL_0588->IL04b2: Incompatible stack heights: 1 vs 0
		//IL_0226->IL04b2: Incompatible stack heights: 1 vs 0
		//IL_0255->IL04b2: Incompatible stack heights: 1 vs 0
		//IL_0695->IL04b2: Incompatible stack heights: 2 vs 0
		//IL_0281->IL04b2: Incompatible stack heights: 2 vs 0
		//IL_02aa->IL04b2: Incompatible stack heights: 2 vs 0
		//IL_0455->IL0455: Incompatible stack heights: 7 vs 0
		base.InitProjectile(pool, weapon, index);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
			ArcadeSprite arcadeSprite = setVisible(visible: false);
			SpriteScroller spriteScroller = _SpriteScroller;
			if ((object)_SpriteScroller != null && (object)spriteScroller._spriteRenderer != null)
			{
				spriteScroller._spriteRenderer.enabled = true;
				Weapon weapon2 = _weapon;
				_isCullable = false;
				if ((object)_weapon != null)
				{
					int num;
					if (!weapon2.IsHoming)
					{
						Transform transform = base.AimForRandomEnemyInScreen();
						num = (int)transform;
					}
					else
					{
						Transform nearestEnemyTransform = base.GetNearestEnemyTransform();
						num = (int)nearestEnemyTransform;
					}
					SpriteScroller spriteScroller2;
					if (num != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v32 (System.Int32)+10]");
						bool flag = (nint)0 == 0;
						spriteScroller2 = _SpriteScroller;
						if (!flag)
						{
							if ((object)_SpriteScroller != null && (object)spriteScroller2._spriteRenderer != null)
							{
								Sprite sprite = spriteScroller2._spriteRenderer.sprite;
								if ((object)sprite != null)
								{
									Texture2D texture = sprite.texture;
									if ((object)texture != null)
									{
										texture.wrapMode = TextureWrapMode.Repeat;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v32 (System.Int32)+10]");
										bool flag2 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v32 (System.Int32)+10]");
										Transform.get_position_Injected((IntPtr)0, out Vector3 _);
										Weapon weapon3 = _weapon;
										if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
										{
											Transform transform2 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.transform;
											if ((object)transform2 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v60 (UnityEngine.Transform)+10]");
												bool flag3 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v60 (UnityEngine.Transform)+10]");
												Transform.get_position_Injected((IntPtr)0, out Vector3 ret2);
												PhaserScene s_scene = ArcadePhysics.s_scene;
												if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
												{
													BulletPool cachedTransform = (BulletPool)(object)_cachedTransform;
													if ((object)_cachedTransform != null)
													{
														bool flag4 = ((EventEmitter)cachedTransform).callbacks == null;
														Transform.get_position_Injected((IntPtr)((EventEmitter)cachedTransform).callbacks, out Vector3 _);
														bool flag5 = ((EventEmitter)cachedTransform).callbacks == null;
														Transform.set_position_Injected((IntPtr)((EventEmitter)cachedTransform).callbacks, ref ret2);
														Tween moveTween = _moveTween;
														if (_moveTween != null && moveTween._003Cactive_003Ek__BackingField)
														{
															TweenExtensions.Kill(_moveTween);
														}
														float endValue = default(float);
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMoveY(_cachedTransform, endValue, 0.07f);
														TweenCallback tweenCallback = Strike;
														if (tweenerCore != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1352 @ rax_v79 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 == 0)
															{
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
														if ((nint)0 == 0)
														{
															_ = 1;
														}
														bool flag6 = tweenerCore == null;
														_moveTween = tweenerCore;
														Tween tween = TweenExtensions.Play(_moveTween);
														BaseBody baseBody2 = body;
														bool flag7 = body == null;
														baseBody2._enable = false;
														bool flag8 = (object)_weapon == null;
														float num2 = _weapon.PArea();
														object obj = default(object);
														float xScale = (float)obj * 0.5f;
														ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
														return;
													}
												}
											}
										}
									}
								}
							}
							goto IL_04b2;
						}
					}
					else
					{
						spriteScroller2 = _SpriteScroller;
					}
					if ((object)spriteScroller2 != null && (object)spriteScroller2._spriteRenderer != null)
					{
						spriteScroller2._spriteRenderer.enabled = false;
						_003CDespawnInAFrame_003Ed__4 obj2 = null;
						obj2._003C_003E1__state = 0;
						obj2._003C_003E4__this = this;
						Coroutine coroutine = StartCoroutine(obj2);
						return;
					}
				}
			}
		}
		goto IL_04b2;
		IL_04b2:
		throw new NullReferenceException();
	}

	private IEnumerator DespawnInAFrame()
	{
		_003CDespawnInAFrame_003Ed__4 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public override void Despawn()
	{
		Tween moveTween = _moveTween;
		if (_moveTween != null && moveTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_moveTween);
		}
		_moveTween = null;
		base.Despawn();
	}

	private unsafe void Strike()
	{
		//IL_0292: Expected O, but got I4
		//IL_030d: Expected O, but got Ref
		//IL_032c: Expected I, but got O
		//IL_034a->IL023d: Incompatible stack heights: 1 vs 0
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._enable = true;
			Weapon weapon = _weapon;
			if ((object)_weapon != null)
			{
				if (weapon._explodeOnExpire)
				{
					float2 pos = base.position;
					Projectile projectile = _weapon.SpawnExplosionAt(pos, 0, 1, 0f);
				}
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 2f;
				float detune = (float)_indexInWeapon * -100f;
				soundConfig.Detune = detune;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning, soundConfig, 200f, 4, time);
				if ((object)_SpriteScroller != null)
				{
					_SpriteScroller.SetScrollSpeedX(-10f);
					if ((object)_SpriteScroller != null)
					{
						_SpriteScroller.SetScrollOffsetY(2.47f);
						Tween despawnTween = _despawnTween;
						if (_despawnTween != null && despawnTween._003Cactive_003Ek__BackingField)
						{
							TweenExtensions.Kill(_despawnTween);
						}
						Transform cachedTransform = _cachedTransform;
						if ((object)_cachedTransform != null)
						{
							bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
							object obj = default(object);
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, (Vector3)(&obj), 0.060000002f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LightningProjectile>)+370]");
							TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
							nint num = (nint)this;
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
								_despawnTween = tweenerCore;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
