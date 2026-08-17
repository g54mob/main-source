using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KnifeProjectile_Special_Kaleidoscope : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _despawnTween;

	private List<Texture> _textures;

	private MeshRenderer _meshRenderer;

	private SortingGroup meshSortingGroup;

	private static readonly int _texture;

	private static readonly int _AlphaMul;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		Transform transform = _renderer.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_04c2: Expected I4, but got O
		//IL_04da: Expected O, but got I4
		//IL_0155: Expected O, but got I8
		//IL_051e: Expected I4, but got O
		//IL_03e0: Expected O, but got I4
		//IL_03fb: Expected I, but got O
		//IL_0572: Expected O, but got F4
		//IL_0538->IL0471: Incompatible stack heights: 1 vs 0
		//IL_0564->IL0471: Incompatible stack heights: 1 vs 0
		//IL_01a4->IL0471: Incompatible stack heights: 1 vs 0
		//IL_01d0->IL0471: Incompatible stack heights: 1 vs 0
		//IL_0256->IL0471: Incompatible stack heights: 1 vs 0
		//IL_02a8->IL0471: Incompatible stack heights: 2 vs 0
		//IL_0348->IL0471: Incompatible stack heights: 2 vs 0
		//IL_039f->IL0471: Incompatible stack heights: 3 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
			ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
			if ((object)_weapon != null)
			{
				float num = _weapon.PArea();
				float num2 = default(float);
				float num3;
				float value;
				if (num2 > 2.8f)
				{
					bool flag = !(1f < num2);
					num3 = num2;
					value = 1f;
					if (!flag)
					{
						if (num2 < 7f)
						{
							float num4 = num2 - 1f;
							float num5 = num4 * 0.65f;
							num3 = num5 / 6f;
							value = 1f - num3;
						}
						else
						{
							num3 = num2;
							value = 0.35f;
						}
					}
				}
				else
				{
					num3 = num2;
					value = 0.85f;
				}
				int num6 = (int)meshSortingGroup;
				bool flag2 = 2.8f > num2;
				object obj = 2;
				if (!flag2)
				{
					obj = 4294965298L;
				}
				if ((object)meshSortingGroup != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdi_v8 (System.Int32)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdi_v8 (System.Int32)+10]");
					SortingGroup.set_sortingOrder_Injected((IntPtr)0, (int)obj);
					if ((object)_meshRenderer != null)
					{
						Material material = ((Renderer)_meshRenderer).GetMaterial();
						Texture value2 = Extensions.PickRnd(_textures);
						if ((object)material != null)
						{
							material.SetTextureImpl(_texture, value2);
							if ((object)_meshRenderer != null)
							{
								Material material2 = ((Renderer)_meshRenderer).GetMaterial();
								if ((object)material2 != null)
								{
									material2.SetFloatImpl(_AlphaMul, value);
									_isCullable = false;
									if (_scaleTween != null)
									{
										_scaleTween.Kill();
									}
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if (array != null)
									{
										object obj2 = array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj3 = default(object);
										bool flag4 = obj3 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null)
										{
											_ = 1128792064;
											_ = 1;
											MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
											_scaleTween = scaleTween;
											if (_despawnTween != null)
											{
												_despawnTween.Kill();
											}
											TweenConfig tweenConfig2 = new TweenConfig();
											object[] array2 = new object[1];
											if (array2 != null)
											{
												int value3 = ((int*)(&array2))->m_value;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj4 = default(object);
												bool flag5 = obj4 == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig2 != null)
												{
													tweenConfig2.targets = array2;
													tweenConfig2.duration = 200f;
													tweenConfig2.delay = 600f;
													tweenConfig2.scale = (float?)(object)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v993 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KnifeProjectile_Special_Kaleidoscope>)+370]");
													TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
													nint num7 = (nint)this;
													tweenConfig2.onComplete = onComplete;
													MultiTargetTween despawnTween = Tweens.Add(tweenConfig2);
													_despawnTween = despawnTween;
													SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
													{
														Rate = 1f
													};
													object obj5 = UnityEngine.Random.value;
													float num8 = num3 * 2000f;
													_ = 1;
													float time = default(float);
													PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_kaleidoscope, soundConfig, 100f, 2, time);
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
		throw new NullReferenceException();
	}

	static EME_KnifeProjectile_Special_Kaleidoscope()
	{
		int texture = Shader.PropertyToID("_MainTex");
		_texture = texture;
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}
}
