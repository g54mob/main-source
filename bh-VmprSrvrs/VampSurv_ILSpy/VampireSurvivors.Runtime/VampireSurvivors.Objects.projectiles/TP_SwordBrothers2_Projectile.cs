using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SwordBrothers2_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public float angleUnit;

		public TP_SwordBrothers2_Projectile _003C_003E4__this;
	}

	private sealed class _003C_003Ec__DisplayClass29_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CDoSwordCircle_003Eb__0()
		{
			//IL_0098: Expected O, but got Ref
			//IL_00cf: Expected O, but got I4
			_003C_003Ec__DisplayClass29_0 obj = CS_0024_003C_003E8__locals1;
			TP_SwordBrothers2_Projectile tP_SwordBrothers2_Projectile = obj._003C_003E4__this;
			List<PhaserSprite> miniSwordSprites = tP_SwordBrothers2_Projectile._miniSwordSprites;
			int num = localIndex;
			if (localIndex < miniSwordSprites._size)
			{
				PhaserSprite[] items = miniSwordSprites._items;
				Transform transform = items[num].transform;
				object obj2 = default(object);
				transform.localEulerAngles = (Vector3)(&obj2);
				PhaserSprite phaserSprite = items[num].setVisible(visible: true);
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				soundConfig.Detune = 1f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordSimple, soundConfig, 50f, 1, time);
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private sealed class _003CDespawnInAFrame_003Ed__26(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TP_SwordBrothers2_Projectile _003C_003E4__this;

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

	private SpriteRenderer _LightningSprite;

	private SpriteRenderer _Graphics;

	private SpriteRenderer _Graphics2;

	private const float BaseRadius = 16f;

	private const int MiniSwordAmount = 32;

	private TP_SwordBrothers2_Weapon _trueWeapon;

	private ParticleEmitterManager _PfxEmitterManager;

	private Tween _moveTween;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _hitGroundTween;

	private MultiTargetTween _chargeTween;

	private MultiTargetTween _secondMoveTween;

	private MultiTargetTween _finalScaleGroundTween;

	private bool _isGrounded;

	private ParticleSystem _PfxEmitter1;

	private Circle _explosionCircle;

	private Transform _target;

	private PhaserSprite _swordSprite;

	private List<PhaserSprite> _miniSwordSprites;

	private List<Timer> _miniSwordTimers;

	private bool _propelMiniSwords;

	private float _miniSwordRendYOffset;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0f9a: Expected O, but got I
		//IL_080e: Expected O, but got Ref
		//IL_0835: Expected O, but got I
		//IL_084f: Expected native int or pointer, but got O
		//IL_0869: Expected O, but got I
		//IL_0897: Expected O, but got I4
		//IL_08b0: Expected O, but got Ref
		//IL_08ca: Expected native int or pointer, but got O
		//IL_0fd4: Expected O, but got I
		//IL_0902: Expected O, but got Ref
		//IL_091c: Expected native int or pointer, but got O
		//IL_100e: Expected O, but got I
		//IL_0a71: Expected O, but got I4
		//IL_0b5d: Expected F4, but got I4
		//IL_0c09: Expected O, but got I4
		//IL_0c7d: Expected O, but got I
		//IL_0c8f: Expected I, but got O
		//IL_0d0c: Expected O, but got Ref
		//IL_0d0c: Expected I4, but got F4
		//IL_0e5d: Expected O, but got I
		//IL_1160: Invalid comparison between F4 and I4
		//IL_0f4a->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_028b->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_02c0->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_02e2->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0351->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_03ae->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_03f5->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0417->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0486->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_04e3->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_052a->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0586->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_05d5->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0689->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_073d->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_07bf->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0999->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_1061->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_09e4->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0a59->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0a8d->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0abc->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0aea->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_0b14->IL0e93: Incompatible stack heights: 1 vs 0
		//IL_116f->IL11a1: Incompatible stack heights: 16 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
			string textureName = default(string);
			Sprite sprite = SpriteManager.GetSprite(null, textureName);
			if ((object)_renderer != null)
			{
				_renderer.sprite = sprite;
				if ((object)_renderer != null)
				{
					_renderer.enabled = false;
					Circle circle = new Circle();
					circle._x = 0f;
					circle._radius = 16f;
					_explosionCircle = circle;
					SpriteTextures.SpriteTexturesBase spriteTexturesBase2 = SpriteTextures.Base;
					if (SpriteTextures.Base != null && spriteTexturesBase2.Vfx != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F93A]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B7C460");
						Sprite sprite2 = SpriteManager.GetSprite(null, textureName);
						if ((object)_LightningSprite != null)
						{
							_LightningSprite.sprite = sprite2;
							if ((object)_SpriteScroller != null)
							{
								Transform transform = _SpriteScroller.transform;
								if ((object)transform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v44 (UnityEngine.Transform)+10]");
									bool flag = (nint)0 == 0;
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1642 @ rcx_v41 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v44 (UnityEngine.Transform)+10]");
									Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, false);
									if ((object)_SpriteScroller != null)
									{
										Renderer component = _SpriteScroller.GetComponent<Renderer>();
										if ((object)component != null)
										{
											component.enabled = false;
											SpriteTextures.SpriteTexturesBase spriteTexturesBase3 = SpriteTextures.Base;
											if (SpriteTextures.Base != null && spriteTexturesBase3.Unitycircle != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F5AB]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
												string text = "UnityCircle";
												Sprite sprite3 = SpriteManager.GetSprite("UnityCircle", "UnityCircle");
												if ((object)_Graphics != null)
												{
													_Graphics.sprite = sprite3;
													SpriteRenderer spriteRenderer = RenderingExtensions.FillStyle(_Graphics, 16711935u, 0.125f);
													Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
													if ((object)spriteRenderer != null)
													{
														((Renderer)spriteRenderer).SetMaterial(material);
														spriteRenderer.enabled = false;
														SpriteTextures.SpriteTexturesBase spriteTexturesBase4 = SpriteTextures.Base;
														if (SpriteTextures.Base != null && spriteTexturesBase4.Unitycircle != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F5AB]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
															text = "UnityCircle";
															Sprite sprite4 = SpriteManager.GetSprite("UnityCircle", "UnityCircle");
															if ((object)_Graphics2 != null)
															{
																_Graphics2.sprite = sprite4;
																SpriteRenderer spriteRenderer2 = RenderingExtensions.FillStyle(_Graphics2, 16777215u, 0.125f);
																Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
																if ((object)spriteRenderer2 != null)
																{
																	((Renderer)spriteRenderer2).SetMaterial(material2);
																	spriteRenderer2.enabled = false;
																	GameObject gameObject = base.gameObject;
																	if ((object)gameObject != null)
																	{
																		ParticleEmitterManager pfxEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
																		_PfxEmitterManager = pfxEmitterManager;
																		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
																		List<string> list = new List<string>();
																		if (list != null)
																		{
																			int version = list._version + 1;
																			list._version = version;
																			string[] items = list._items;
																			if (list._items != null)
																			{
																				if (list._size >= items.Length)
																				{
																					((List<object>)(object)list).AddWithResize((object)"PfxYellow");
																				}
																				else
																				{
																					int num2 = list._size + 1;
																					list._size = num2;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				}
																				int version2 = list._version + 1;
																				list._version = version2;
																				string[] items2 = list._items;
																				if (list._items != null)
																				{
																					if (list._size >= items2.Length)
																					{
																						((List<object>)(object)list).AddWithResize((object)"PfxRed");
																					}
																					else
																					{
																						int num3 = list._size + 1;
																						list._size = num3;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					}
																					int version3 = list._version + 1;
																					list._version = version3;
																					string[] items3 = list._items;
																					if (list._items != null)
																					{
																						if (list._size >= items3.Length)
																						{
																							((List<object>)(object)list).AddWithResize((object)"PfxLine");
																						}
																						else
																						{
																							int num4 = list._size + 1;
																							list._size = num4;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																						}
																						if (particleSystemConfig != null)
																						{
																							particleSystemConfig._frame = list;
																							ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1f, 1f);
																							_ = 0;
																							_ = 0;
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
																							particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
																							_ = 0;
																							_ = 1;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
																							particleSystemConfig._quantity = (int?)(object)0;
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(90f, 90f));
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
																							particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(600f);
																							particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
																							particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 1f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
																							particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
																							_ = 0;
																							particleSystemConfig._emitZone = new EmitZone
																							{
																								_type = EmitZoneType.Random,
																								_source = _explosionCircle
																							};
																							particleSystemConfig._on = false;
																							if ((object)_PfxEmitterManager != null)
																							{
																								ParticleSystem pfxEmitter = _PfxEmitterManager.CreateEmitter(particleSystemConfig);
																								_PfxEmitter1 = pfxEmitter;
																								SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
																								if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A144A]");
																									if ((nint)0 == 0)
																									{
																										_ = 1;
																									}
																									text = "TP_VFX_Brothers01";
																									GameObject gameObject2 = base.gameObject;
																									Vector2 vector = default(Vector2);
																									PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "ThosePeople", "TP_VFX_Brothers01");
																									if ((object)phaserSprite != null)
																									{
																										PhaserSprite phaserSprite2 = phaserSprite.setScale(0.4f, (float?)(object)0);
																										if ((object)phaserSprite2 != null)
																										{
																											PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.6f);
																											if ((object)phaserSprite3 != null)
																											{
																												PhaserSprite phaserSprite4 = phaserSprite3.setLocalPosition(vector);
																												if ((object)phaserSprite4 != null)
																												{
																													GameObject gameObject3 = phaserSprite4.gameObject;
																													if ((object)gameObject3 != null)
																													{
																														((UnityEngine.Object)gameObject3).SetName("_swordSprite");
																														_swordSprite = phaserSprite4;
																														List<PhaserSprite> miniSwordSprites = new List<PhaserSprite>();
																														_miniSwordSprites = miniSwordSprites;
																														float num5 = 0f;
																														object obj4 = default(object);
																														do
																														{
																															SpriteTextures.SpriteTexturesThosepeople thosepeople2 = SpriteTextures.Thosepeople;
																															bool flag2 = SpriteTextures.Thosepeople == null;
																															bool flag3 = thosepeople2.Thosepeople == null;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A144A]");
																															if ((nint)0 == 0)
																															{
																																_ = 1;
																															}
																															GameObject gameObject4 = base.gameObject;
																															PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject4, vector, "ThosePeople", "TP_VFX_Brothers01");
																															bool flag4 = (object)phaserSprite5 == null;
																															PhaserSprite phaserSprite6 = phaserSprite5.setScale(0.2f, (float?)(object)0);
																															bool flag5 = (object)phaserSprite6 == null;
																															PhaserSprite phaserSprite7 = phaserSprite6.setAlpha(0.4f);
																															_ = 0;
																															_ = 0;
																															_ = 1;
																															bool flag6 = (object)phaserSprite7 == null;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
																															PhaserSprite phaserSprite8 = phaserSprite7.setOrigin(0.5f, (float?)(object)0);
																															nint num6 = (nint)typeof(float2);
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rcx_v140 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
																															nint num7 = 0;
																															bool flag7 = (object)phaserSprite8 == null;
																															PhaserSprite phaserSprite9 = phaserSprite8.setLocalPosition(vector);
																															bool flag8 = (object)phaserSprite9 == null;
																															PhaserSprite phaserSprite10 = phaserSprite9.setBlendMode(BlendMode.Add);
																															string text2 = System.Number.FormatInt32((int)num5, (ReadOnlySpan<char>)(&minMaxCurve), null);
																															string text3 = "_miniSwordSprite" + text2;
																															bool flag9 = (object)phaserSprite10 == null;
																															GameObject gameObject5 = phaserSprite10.gameObject;
																															bool flag10 = (object)gameObject5 == null;
																															((UnityEngine.Object)gameObject5).SetName(text3);
																															List<object> miniSwordSprites2 = (List<object>)(object)_miniSwordSprites;
																															bool flag11 = _miniSwordSprites == null;
																															int version4 = miniSwordSprites2._version + 1;
																															miniSwordSprites2._version = version4;
																															object[] items4 = miniSwordSprites2._items;
																															bool flag12 = miniSwordSprites2._items == null;
																															if (miniSwordSprites2._size >= items4.Length)
																															{
																																((List<object>)(object)_miniSwordSprites).AddWithResize((object)phaserSprite10);
																															}
																															else
																															{
																																int num8 = miniSwordSprites2._size + 1;
																																miniSwordSprites2._size = num8;
																																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																															}
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3697 @ rax_v158 (VampireSurvivors.Framework.Phaser.PhaserSprite)+28]");
																															object obj3 = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3697 @ rax_v158 (VampireSurvivors.Framework.Phaser.PhaserSprite)+28]");
																															bool flag13 = (nint)0 == 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdi_v22 (System.Object)+10]");
																															bool flag14 = (nint)0 == 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdi_v22 (System.Object)+10]");
																															IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
																															Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
																															bool flag15 = (object)transform2 == null;
																															bool flag16 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																															Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&text));
																															num5++;
																															float miniSwordRendYOffset = (float)obj4 - 0.5f;
																															_miniSwordRendYOffset = miniSwordRendYOffset;
																														}
																														while (num5 < 32f);
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
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0027: Expected I4, but got O
		//IL_0035: Expected I, but got O
		//IL_0045: Expected O, but got I
		//IL_00c5: Expected O, but got I4
		//IL_001a: Expected F4, but got I4
		//IL_0755: Expected F4, but got I4
		//IL_0081: Expected O, but got I
		//IL_0738: Expected O, but got F4
		//IL_00d4: Expected F4, but got O
		//IL_00b7: Expected O, but got I4
		//IL_03b9: Expected O, but got I4
		//IL_03b9: Expected O, but got I4
		//IL_0441: Expected O, but got I4
		//IL_05c5: Expected F4, but got O
		//IL_05f4: Expected F4, but got I
		//IL_0830->IL098d: Incompatible stack heights: 4 vs 0
		//IL_0952->IL068e: Incompatible stack heights: 7 vs 1
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float num;
		if ((object)_weapon == null)
		{
			num = 0f;
			goto IL_072e;
		}
		int num2 = (int)weapon2;
		nint num3 = (nint)typeof(TP_SwordBrothers2_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v88 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SwordBrothers2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v28 (System.Int32)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v88 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SwordBrothers2_Weapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v28 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v204+FFFFFFF8+v80 @ rax_v199*8]");
			if (0 == (nint)typeof(TP_SwordBrothers2_Weapon))
			{
				obj3 = 1;
				goto IL_073d;
			}
		}
		obj3 = 0;
		goto IL_073d;
		IL_073d:
		bool flag = obj3 == null;
		num = 0f;
		if (!flag)
		{
			num = (float)_weapon;
		}
		goto IL_072e;
		IL_072e:
		_trueWeapon = (TP_SwordBrothers2_Weapon)num;
		_isGrounded = false;
		_propelMiniSwords = false;
		_isCullable = false;
		_speed = 0f;
		if ((object)_weapon != null)
		{
			float num5 = _weapon.PArea();
			Circle circle = new Circle();
			circle._x = 0f;
			object obj4 = default(object);
			float radius = (float)obj4 * 8f;
			circle._radius = radius;
			_explosionCircle = circle;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = _explosionCircle;
			RenderingExtensions.SetEmitZone(_PfxEmitter1, emitZone);
			SpriteScroller spriteScroller = _SpriteScroller;
			if ((object)_SpriteScroller != null && (object)spriteScroller._spriteRenderer != null)
			{
				spriteScroller._spriteRenderer.enabled = false;
				SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
				if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A144A]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					string ret = "TP_VFX_Brothers01";
					Sprite sprite = SpriteManager.GetSprite("TP_VFX_Brothers01", "ThosePeople");
					if ((object)_swordSprite != null)
					{
						PhaserSprite phaserSprite = _swordSprite.setFrame(sprite);
						if ((object)_swordSprite != null)
						{
							PhaserSprite phaserSprite2 = _swordSprite.setVisible(visible: true);
							if (_miniSwordSprites != null)
							{
								List<PhaserSprite> value = _miniSwordSprites;
								List<PhaserSprite>.Enumerator enumerator = (List<PhaserSprite>.Enumerator)_miniSwordSprites;
								List<PhaserSprite>.Enumerator enumerator2 = default(List<PhaserSprite>.Enumerator);
								List<PhaserSprite>.Enumerator euler = default(List<PhaserSprite>.Enumerator);
								List<PhaserSprite>.Enumerator enumerator3 = default(List<PhaserSprite>.Enumerator);
								while (enumerator2.MoveNext())
								{
									Weapon weapon3 = null;
									PhaserSprite phaserSprite3 = ((PhaserSprite)null).setVisible(false);
									PhaserSprite phaserSprite4 = ((PhaserSprite)null).setAlpha(0.4f);
									Weapon dataManager = (Weapon)(object)((Equipment)weapon3)._dataManager;
									bool flag2 = ((Equipment)weapon3)._dataManager == null;
									bool flag3 = ((UnityEngine.Object)dataManager).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)dataManager).m_CachedPtr);
									Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
									bool flag4 = (object)transform == null;
									bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&euler));
									enumerator = enumerator3;
								}
								if (body != null)
								{
									BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
									BaseBody baseBody2 = body;
									if (body != null)
									{
										baseBody2._enable = false;
										if ((object)_weapon != null)
										{
											float num6 = _weapon.PArea();
											float xScale = (float)enumerator * 0.5f;
											ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
											Weapon weapon4 = _weapon;
											if ((object)_weapon != null)
											{
												if (!weapon4.IsHoming)
												{
													Transform target = base.AimForRandomEnemyInScreen();
													_target = target;
												}
												else
												{
													Transform nearestEnemyTransform = base.GetNearestEnemyTransform();
													_target = nearestEnemyTransform;
												}
												Weapon target2 = (Weapon)(object)_target;
												SpriteScroller spriteScroller2;
												if ((object)_target != null)
												{
													spriteScroller2 = _SpriteScroller;
													if (((UnityEngine.Object)target2).m_CachedPtr != (IntPtr)0)
													{
														if ((object)_SpriteScroller != null && (object)spriteScroller2._spriteRenderer != null)
														{
															Sprite sprite2 = spriteScroller2._spriteRenderer.sprite;
															if ((object)sprite2 != null)
															{
																Texture2D texture = sprite2.texture;
																if ((object)texture != null)
																{
																	texture.wrapMode = TextureWrapMode.Repeat;
																	float num7 = (float)_SpriteScroller;
																	if ((object)_SpriteScroller != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rbx_v21 (System.Single)+40]");
																		float num8 = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rbx_v21 (System.Single)+40]");
																		bool flag6 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1223 @ rbx_v22 (System.Single)+10]");
																		bool flag7 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1223 @ rbx_v22 (System.Single)+10]");
																		Color value2 = default(Color);
																		SpriteRenderer.set_color_Injected((IntPtr)0, ref value2);
																		SpriteScroller spriteScroller3 = _SpriteScroller;
																		bool flag8 = (object)_SpriteScroller == null;
																		bool flag9 = (object)spriteScroller3._spriteRenderer == null;
																		spriteScroller3._spriteRenderer.enabled = true;
																		bool flag10 = (object)_SpriteScroller == null;
																		Transform transform2 = _SpriteScroller.transform;
																		Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out *(Quaternion*)(&ret));
																		bool flag11 = (object)transform2 == null;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2739 @ rax_v117 (UnityEngine.Transform)+10]");
																		bool flag12 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2739 @ rax_v117 (UnityEngine.Transform)+10]");
																		Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value));
																		DoLightningTween();
																		return;
																	}
																}
															}
														}
														goto IL_06ea;
													}
												}
												else
												{
													spriteScroller2 = _SpriteScroller;
												}
												if ((object)spriteScroller2 != null)
												{
													Weapon spriteRenderer = (Weapon)(object)spriteScroller2._spriteRenderer;
													if ((object)spriteScroller2._spriteRenderer != null)
													{
														bool flag13 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
														Renderer.set_enabled_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, false);
														_003CDespawnInAFrame_003Ed__26 obj5 = null;
														obj5._003C_003E1__state = 0;
														obj5._003C_003E4__this = this;
														Coroutine coroutine = StartCoroutine(obj5);
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
		goto IL_06ea;
		IL_06ea:
		throw new NullReferenceException();
	}

	private unsafe void DoLightningTween()
	{
		//IL_0280: Expected O, but got Ref
		//IL_020b->IL0187: Incompatible stack heights: 1 vs 0
		//IL_002c->IL0187: Incompatible stack heights: 1 vs 0
		//IL_0232->IL0187: Incompatible stack heights: 1 vs 0
		//IL_0066->IL0187: Incompatible stack heights: 1 vs 0
		//IL_00cf->IL0187: Incompatible stack heights: 1 vs 0
		//IL_02b2->IL0187: Incompatible stack heights: 2 vs 0
		Transform target = _target;
		if ((object)_target != null)
		{
			bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)target).m_CachedPtr, out Vector3 ret);
			Weapon weapon = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
				{
					float2 float6 = default(float2);
					base.position = float6;
					if (_moveTween != null)
					{
						TweenExtensions.Kill(_moveTween);
					}
					Transform target2 = _target;
					if ((object)_target != null)
					{
						bool flag2 = ((UnityEngine.Object)target2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)target2).m_CachedPtr, out ret);
						object obj = default(object);
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, (Vector3)(&obj), 0.07f);
						TweenCallback tweenCallback = delegate
						{
							Strike(_target);
						};
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
							_moveTween = tweenerCore;
							Tween tween = TweenExtensions.Play(_moveTween);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator DespawnInAFrame()
	{
		_003CDespawnInAFrame_003Ed__26 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public override void Despawn()
	{
		CancelMiniSwordTimers();
		if (_moveTween != null)
		{
			TweenExtensions.Kill(_moveTween);
		}
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		if (_hitGroundTween != null)
		{
			_hitGroundTween.Kill();
		}
		if (_chargeTween != null)
		{
			_chargeTween.Kill();
		}
		if (_secondMoveTween != null)
		{
			_secondMoveTween.Kill();
		}
		if (_finalScaleGroundTween != null)
		{
			_finalScaleGroundTween.Kill();
		}
		base.Despawn();
	}

	protected virtual void Strike(Transform target)
	{
		//IL_03d4: Expected O, but got I4
		//IL_083a: Expected O, but got I4
		//IL_04d6: Expected I, but got O
		//IL_0556: Expected I, but got O
		//IL_023c: Expected O, but got I4
		//IL_024e: Unsupported input type for neg.
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_05ad: Expected I, but got O
		//IL_04f9->IL04f9: Incompatible stack heights: 1 vs 0
		//IL_0579->IL0579: Incompatible stack heights: 1 vs 0
		//IL_0752->IL065e: Incompatible stack heights: 1 vs 0
		//IL_038e->IL038e: Incompatible stack heights: 10 vs 0
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			BaseBody baseBody = body;
			if (body != null)
			{
				baseBody._enable = true;
				SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
				if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A144B]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					Sprite sprite = SpriteManager.GetSprite("TP_VFX_Brothers01a", "ThosePeople");
					if ((object)_swordSprite != null)
					{
						PhaserSprite phaserSprite = _swordSprite.setFrame(sprite);
						DoSwordCircle();
						GameManager core = GM.Core;
						if ((object)GM.Core != null && core._playerOptions != null)
						{
							PlayerOptionsData config = core._playerOptions.Config;
							if (config != null)
							{
								bool flag = !config._003CFlashingVFXEnabled_003Ek__BackingField;
								int num = 0;
								if (!flag)
								{
									bool flag2 = (object)target == null;
									num = 0;
									if (!flag2)
									{
										bool flag3 = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
										num = 0;
										if (!flag3)
										{
											PhaserScene s_scene = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer = s_scene._renderer;
												if (s_scene._renderer != null)
												{
													int num2 = renderer.pixelHeight >> 31;
													object obj = renderer.pixelHeight - num2;
													object obj2 = obj >> 1;
													object obj3 = 0 - obj2;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
													bool flag4 = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
													Transform.get_position_Injected(((UnityEngine.Object)target).m_CachedPtr, out Vector3 ret);
													if ((object)_Graphics != null)
													{
														Transform transform = _Graphics.transform;
														bool flag5 = (object)transform == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1543 @ rax_v110 (UnityEngine.Transform)+10]");
														bool flag6 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1543 @ rax_v110 (UnityEngine.Transform)+10]");
														Transform.set_localPosition_Injected((IntPtr)0, ref ret);
														bool flag7 = (object)_Graphics == null;
														_Graphics.enabled = true;
														SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_Graphics, 0f);
														bool flag8 = (object)_Graphics == null;
														int sortingOrder = default(int);
														_Graphics.sortingOrder = sortingOrder;
														bool flag9 = (object)_Graphics2 == null;
														Transform transform2 = _Graphics2.transform;
														bool flag10 = (object)transform2 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1850 @ rax_v122 (UnityEngine.Transform)+10]");
														bool flag11 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1850 @ rax_v122 (UnityEngine.Transform)+10]");
														Vector3 value = default(Vector3);
														Transform.set_localPosition_Injected((IntPtr)0, ref value);
														bool flag12 = (object)_Graphics2 == null;
														_Graphics2.enabled = true;
														SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_Graphics2, 0f);
														bool flag13 = (object)_Graphics2 == null;
														_Graphics2.sortingOrder = sortingOrder;
														num = 0;
														goto IL_038e;
													}
												}
											}
											goto IL_065e;
										}
									}
								}
								goto IL_038e;
							}
						}
					}
				}
			}
		}
		goto IL_065e;
		IL_065e:
		throw new NullReferenceException();
		IL_038e:
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			bool flag14 = !weapon._explodeOnExpire;
			float2 float5 = (float2)0;
			if (!flag14)
			{
				float2 float6 = base.position;
				Projectile projectile = _weapon.SpawnExplosionAt(float6, 0, 1, 0f);
				float5 = float6;
				int num = 0;
			}
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * 200f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning, soundConfig, 200f, 8, time);
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[2];
			if ((object)_Graphics != null)
			{
				Transform transform3 = _Graphics.transform;
				if (array != null)
				{
					if ((object)transform3 != null)
					{
						nint num3 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj4 = default(object);
						bool flag15 = obj4 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if ((object)_Graphics2 != null)
					{
						Transform transform4 = _Graphics2.transform;
						if ((object)transform4 != null)
						{
							nint num4 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj5 = default(object);
							bool flag16 = obj5 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
							_ = 1114636288;
							_ = 1;
							TweenCallback tweenCallback = delegate
							{
								//IL_00c1: Expected I, but got O
								//IL_0125: Expected O, but got I4
								//IL_0283: Expected O, but got I4
								//IL_0232: Expected I, but got O
								BaseBody baseBody2 = body;
								baseBody2._enable = false;
								_isGrounded = true;
								Action onComplete = delegate
								{
									SpriteScroller spriteScroller = _SpriteScroller;
									spriteScroller._spriteRenderer.enabled = false;
								};
								bool useRealTime = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer timer = Timers.Register(0.05f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								Transform transform5 = _Graphics2.transform;
								if ((object)transform5 != null)
								{
									nint num5 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj6 = default(object);
									if (obj6 == null)
									{
										ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
										throw ex;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								tweenConfig2.targets = array2;
								tweenConfig2.duration = 1500f;
								tweenConfig2.scale = (float?)(object)1;
								TweenCallback onComplete2 = delegate
								{
									_isGrounded = false;
								};
								tweenConfig2.onComplete = onComplete2;
								MultiTargetTween chargeTween = Tweens.Add(tweenConfig2);
								_chargeTween = chargeTween;
								Action onComplete3 = delegate
								{
									//IL_00a7: Expected O, but got I
									//IL_018c: Expected O, but got I
									//IL_0177: Expected O, but got I
									//IL_0162: Expected O, but got I
									//IL_012a: Expected O, but got I
									//IL_027d->IL027d: Incompatible stack heights: 4 vs 1
									Transform transform7 = _SpriteScroller.transform;
									Vector3 euler = default(Vector3);
									Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
									bool flag17 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
									Quaternion value2 = default(Quaternion);
									Transform.set_rotation_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref value2);
									SpriteScroller spriteScroller = _SpriteScroller;
									spriteScroller._spriteRenderer.enabled = true;
									PhaserSprite phaserSprite2 = _swordSprite.setVisible(visible: false);
									List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
									while (enumerator.MoveNext())
									{
										Transform core2 = (Transform)(object)GM.Core;
										bool flag18 = (object)GM.Core == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ rbx_v14 (UnityEngine.Transform)+90]");
										Transform transform8 = (Transform)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ rbx_v14 (UnityEngine.Transform)+90]");
										bool flag19 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+68]");
										object obj8;
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+58]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+78]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+78]");
													obj8 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v42+2CC]");
													if ((nint)0 != 0)
													{
														goto IL_0263;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+50]");
												obj8 = 0;
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+58]");
												obj8 = 0;
											}
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+68]");
											obj8 = 0;
										}
										goto IL_0263;
										IL_0263:
										bool flag20 = obj8 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v42+118]");
										if ((nint)0 != 0)
										{
											float num7 = 0.8f;
										}
										else
										{
											float num7 = 0.4f;
										}
									}
									_propelMiniSwords = true;
								};
								Timer timer2 = Timers.Register(1.25f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								TweenConfig tweenConfig3 = new TweenConfig();
								tweenConfig3.delay = 1300f;
								tweenConfig3.duration = 60f;
								object[] array3 = new object[1];
								Transform transform6 = _Graphics.transform;
								if ((object)transform6 != null)
								{
									nint num6 = (nint)array3;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj7 = default(object);
									if (obj7 == null)
									{
										ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
										throw ex2;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								tweenConfig3.targets = array3;
								tweenConfig3.scale = (float?)(object)1;
								TweenCallback onStart = delegate
								{
									//IL_0039: Expected O, but got I4
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
									SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
									soundConfig2.Rate = 1f;
									soundConfig2.Volume = (float?)(object)1;
									float detune2 = (float)_indexInWeapon * -100f;
									soundConfig2.Detune = detune2;
									float time2 = default(float);
									PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Lightning2, soundConfig2, 200f, 8, time2);
									TP_SwordBrothers2_Weapon trueWeapon = _trueWeapon;
									float2 pos = base.position;
									Projectile projectile2 = trueWeapon._explosionPool.SpawnAt(pos, _weapon);
									BaseBody baseBody3 = body;
									baseBody3._enable = true;
								};
								tweenConfig3.onStart = onStart;
								TweenCallback onComplete4 = delegate
								{
									//IL_0064: Expected I, but got O
									//IL_00d2: Expected O, but got I4
									BaseBody baseBody3 = body;
									baseBody3._enable = false;
									TweenConfig tweenConfig4 = new TweenConfig();
									object[] array4 = new object[1];
									Transform transform7 = base.transform;
									if ((object)transform7 != null)
									{
										nint num7 = (nint)array4;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj8 = default(object);
										if (obj8 == null)
										{
											ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
											throw ex3;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									tweenConfig4.targets = array4;
									float2 float7 = base.position;
									tweenConfig4.duration = 90f;
									tweenConfig4.y = (float?)(object)1;
									TweenCallback onComplete5 = delegate
									{
										//IL_003e: Expected I, but got O
										//IL_00a8: Expected I, but got O
										//IL_010c: Expected O, but got I4
										TweenConfig tweenConfig5 = new TweenConfig();
										object[] array5 = new object[2];
										Transform transform8 = _Graphics.transform;
										if ((object)transform8 != null)
										{
											nint num8 = (nint)array5;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj9 = default(object);
											if (obj9 == null)
											{
												ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
												throw ex4;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										Transform transform9 = _Graphics2.transform;
										if ((object)transform9 != null)
										{
											nint num9 = (nint)array5;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj10 = default(object);
											if (obj10 == null)
											{
												ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
												throw ex5;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										tweenConfig5.targets = array5;
										tweenConfig5.duration = 60f;
										tweenConfig5.scale = (float?)(object)1;
										TweenCallback onComplete6 = delegate
										{
											SpriteScroller spriteScroller = _SpriteScroller;
											spriteScroller._spriteRenderer.enabled = false;
											_Graphics.enabled = false;
											_Graphics2.enabled = false;
											Despawn();
										};
										tweenConfig5.onComplete = onComplete6;
										MultiTargetTween despawnTween = Tweens.Add(tweenConfig5);
										_despawnTween = despawnTween;
									};
									tweenConfig4.onComplete = onComplete5;
									MultiTargetTween secondMoveTween = Tweens.Add(tweenConfig4);
									_secondMoveTween = secondMoveTween;
								};
								tweenConfig3.onComplete = onComplete4;
								MultiTargetTween finalScaleGroundTween = Tweens.Add(tweenConfig3);
								_finalScaleGroundTween = finalScaleGroundTween;
							};
							MultiTargetTween hitGroundTween = Tweens.Add(tweenConfig);
							_hitGroundTween = hitGroundTween;
							if ((object)_SpriteScroller != null)
							{
								_SpriteScroller.SetScrollSpeedX(-10f);
								if ((object)_SpriteScroller != null)
								{
									_SpriteScroller.SetScrollOffsetY(2.47f);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_065e;
	}

	private unsafe void DoSwordCircle()
	{
		//IL_00c1: Expected I, but got O
		//IL_00d7: Expected O, but got I
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_014e: Expected I, but got O
		//IL_0239: Expected O, but got I4
		//IL_0250: Expected I, but got I8
		//IL_0137: Expected I, but got I8
		_003C_003Ec__DisplayClass29_0 obj = new _003C_003Ec__DisplayClass29_0();
		obj._003C_003E4__this = this;
		obj.angleUnit = -11.25f;
		CancelMiniSwordTimers();
		List<Timer> miniSwordTimers = new List<Timer>();
		_miniSwordTimers = miniSwordTimers;
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass29_1 obj2 = new _003C_003Ec__DisplayClass29_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.localIndex = (flag ? 1 : 0);
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass29_1._003CDoSwordCircle_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num2;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_0230;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_0230;
			IL_0230:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num3 = (float)(flag ? 1 : 0) * 31.25f;
			float duration = num3 * 0.001f;
			Timer item = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			List<object> miniSwordTimers2 = (List<object>)(object)_miniSwordTimers;
			int version = miniSwordTimers2._version + 1;
			miniSwordTimers2._version = version;
			object[] items = miniSwordTimers2._items;
			if (miniSwordTimers2._size >= items.Length)
			{
				miniSwordTimers2.AddWithResize((object)item);
			}
			else
			{
				int num4 = miniSwordTimers2._size + 1;
				miniSwordTimers2._size = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < 32);
	}

	private void CancelMiniSwordTimers()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		if (_miniSwordTimers == null)
		{
			return;
		}
		List<Timer> miniSwordTimers = _miniSwordTimers;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < miniSwordTimers._size)
		{
			List<Timer> miniSwordTimers2 = _miniSwordTimers;
			if ((nint)obj < miniSwordTimers2._size)
			{
				Timer[] items = miniSwordTimers2._items;
				if (items[obj] != null)
				{
					items[obj].Cancel();
				}
				miniSwordTimers = _miniSwordTimers;
				obj++;
				obj2 = obj;
				continue;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			break;
		}
	}

	public override void InternalUpdate()
	{
		//IL_00cc: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_0278: Expected O, but got F4
		//IL_0060->IL0060: Incompatible stack heights: 2 vs 0
		//IL_0132->IL029a: Incompatible stack heights: 6 vs 0
		Vector3 ret2;
		if (_isGrounded)
		{
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			Transform transform2 = base.transform;
			bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret2);
			Vector2 pos = default(Vector2);
			_PfxEmitterManager.EmitParticleAt(pos);
		}
		if (_propelMiniSwords)
		{
			List<PhaserSprite>.Enumerator miniSwordSprites = (List<PhaserSprite>.Enumerator)_miniSwordSprites;
			List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
			Vector3 value = default(Vector3);
			while (enumerator.MoveNext())
			{
				Transform transform3 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rdi_v17 (UnityEngine.Transform)+28]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rdi_v17 (UnityEngine.Transform)+28]");
				Transform transform4 = ((Component)0).transform;
				bool flag4 = (object)transform4 == null;
				bool flag5 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret2);
				float deltaTime = PauseSystem.DeltaTime;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rdi_v17 (UnityEngine.Transform)+28]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rdi_v17 (UnityEngine.Transform)+28]");
				Transform transform5 = ((Component)0).transform;
				bool flag7 = (object)transform5 == null;
				bool flag8 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value);
				float alpha = ((PhaserSprite)null).Alpha;
				float deltaTime2 = PauseSystem.DeltaTime;
				miniSwordSprites = (List<PhaserSprite>.Enumerator)(deltaTime2 * 5f);
				float alpha2 = alpha - (float)miniSwordSprites;
				PhaserSprite phaserSprite = ((PhaserSprite)null).setAlpha(alpha2);
			}
		}
	}

	private void LateUpdate()
	{
		//IL_0113->IL00c2: Incompatible stack heights: 1 vs 0
		//IL_008b->IL00c2: Incompatible stack heights: 1 vs 0
		if ((object)_SpriteScroller != null)
		{
			Transform transform = _SpriteScroller.transform;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
				if ((object)_SpriteScroller != null)
				{
					Transform transform3 = _SpriteScroller.transform;
					if ((object)transform3 != null)
					{
						Vector3 right = transform3.right;
						bool flag2 = (object)transform == null;
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CDoLightningTween_003Eb__25_0()
	{
		Strike(_target);
	}

	private void _003CStrike_003Eb__28_0()
	{
		//IL_00c1: Expected I, but got O
		//IL_0125: Expected O, but got I4
		//IL_0283: Expected O, but got I4
		//IL_0232: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		_isGrounded = true;
		Action onComplete = delegate
		{
			SpriteScroller spriteScroller = _SpriteScroller;
			spriteScroller._spriteRenderer.enabled = false;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.05f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = _Graphics2.transform;
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
		tweenConfig.duration = 1500f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete2 = delegate
		{
			_isGrounded = false;
		};
		tweenConfig.onComplete = onComplete2;
		MultiTargetTween chargeTween = Tweens.Add(tweenConfig);
		_chargeTween = chargeTween;
		Action onComplete3 = delegate
		{
			//IL_00a7: Expected O, but got I
			//IL_018c: Expected O, but got I
			//IL_0177: Expected O, but got I
			//IL_0162: Expected O, but got I
			//IL_012a: Expected O, but got I
			//IL_027d->IL027d: Incompatible stack heights: 4 vs 1
			Transform transform3 = _SpriteScroller.transform;
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
			SpriteScroller spriteScroller = _SpriteScroller;
			spriteScroller._spriteRenderer.enabled = true;
			PhaserSprite phaserSprite = _swordSprite.setVisible(visible: false);
			List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
			while (enumerator.MoveNext())
			{
				Transform core = (Transform)(object)GM.Core;
				bool flag2 = (object)GM.Core == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ rbx_v14 (UnityEngine.Transform)+90]");
				Transform transform4 = (Transform)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ rbx_v14 (UnityEngine.Transform)+90]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+68]");
				object obj3;
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+58]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+78]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+78]");
							obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v42+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_0263;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+50]");
						obj3 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+58]");
						obj3 = 0;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+68]");
					obj3 = 0;
				}
				goto IL_0263;
				IL_0263:
				bool flag4 = obj3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v42+118]");
				if ((nint)0 != 0)
				{
					float num3 = 0.8f;
				}
				else
				{
					float num3 = 0.4f;
				}
			}
			_propelMiniSwords = true;
		};
		Timer timer2 = Timers.Register(1.25f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		TweenConfig tweenConfig2 = new TweenConfig();
		tweenConfig2.delay = 1300f;
		tweenConfig2.duration = 60f;
		object[] array2 = new object[1];
		Transform transform2 = _Graphics.transform;
		if ((object)transform2 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0039: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_indexInWeapon * -100f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning2, soundConfig, 200f, 8, time);
			TP_SwordBrothers2_Weapon trueWeapon = _trueWeapon;
			float2 pos = base.position;
			Projectile projectile = trueWeapon._explosionPool.SpawnAt(pos, _weapon);
			BaseBody baseBody2 = body;
			baseBody2._enable = true;
		};
		tweenConfig2.onStart = onStart;
		TweenCallback onComplete4 = delegate
		{
			//IL_0064: Expected I, but got O
			//IL_00d2: Expected O, but got I4
			BaseBody baseBody2 = body;
			baseBody2._enable = false;
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			Transform transform3 = base.transform;
			if ((object)transform3 != null)
			{
				nint num3 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			float2 float5 = base.position;
			tweenConfig3.duration = 90f;
			tweenConfig3.y = (float?)(object)1;
			TweenCallback onComplete5 = delegate
			{
				//IL_003e: Expected I, but got O
				//IL_00a8: Expected I, but got O
				//IL_010c: Expected O, but got I4
				TweenConfig tweenConfig4 = new TweenConfig();
				object[] array4 = new object[2];
				Transform transform4 = _Graphics.transform;
				if ((object)transform4 != null)
				{
					nint num4 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
						throw ex4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Transform transform5 = _Graphics2.transform;
				if ((object)transform5 != null)
				{
					nint num5 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
						throw ex5;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig4.targets = array4;
				tweenConfig4.duration = 60f;
				tweenConfig4.scale = (float?)(object)1;
				TweenCallback onComplete6 = delegate
				{
					SpriteScroller spriteScroller = _SpriteScroller;
					spriteScroller._spriteRenderer.enabled = false;
					_Graphics.enabled = false;
					_Graphics2.enabled = false;
					Despawn();
				};
				tweenConfig4.onComplete = onComplete6;
				MultiTargetTween despawnTween = Tweens.Add(tweenConfig4);
				_despawnTween = despawnTween;
			};
			tweenConfig3.onComplete = onComplete5;
			MultiTargetTween secondMoveTween = Tweens.Add(tweenConfig3);
			_secondMoveTween = secondMoveTween;
		};
		tweenConfig2.onComplete = onComplete4;
		MultiTargetTween finalScaleGroundTween = Tweens.Add(tweenConfig2);
		_finalScaleGroundTween = finalScaleGroundTween;
	}

	private void _003CStrike_003Eb__28_1()
	{
		SpriteScroller spriteScroller = _SpriteScroller;
		spriteScroller._spriteRenderer.enabled = false;
	}

	private void _003CStrike_003Eb__28_3()
	{
		_isGrounded = false;
	}

	private void _003CStrike_003Eb__28_2()
	{
		//IL_00a7: Expected O, but got I
		//IL_018c: Expected O, but got I
		//IL_0177: Expected O, but got I
		//IL_0162: Expected O, but got I
		//IL_012a: Expected O, but got I
		//IL_027d->IL027d: Incompatible stack heights: 4 vs 1
		Transform transform = _SpriteScroller.transform;
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		SpriteScroller spriteScroller = _SpriteScroller;
		spriteScroller._spriteRenderer.enabled = true;
		PhaserSprite phaserSprite = _swordSprite.setVisible(visible: false);
		List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
		while (enumerator.MoveNext())
		{
			Transform core = (Transform)(object)GM.Core;
			bool flag2 = (object)GM.Core == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ rbx_v14 (UnityEngine.Transform)+90]");
			Transform transform2 = (Transform)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ rbx_v14 (UnityEngine.Transform)+90]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+68]");
			object obj;
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+58]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+78]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+78]");
						obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v42+2CC]");
						if ((nint)0 != 0)
						{
							goto IL_0263;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+50]");
					obj = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+58]");
					obj = 0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v15 (UnityEngine.Transform)+68]");
				obj = 0;
			}
			goto IL_0263;
			IL_0263:
			bool flag4 = obj == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v42+118]");
			if ((nint)0 != 0)
			{
				float num = 0.8f;
			}
			else
			{
				float num = 0.4f;
			}
		}
		_propelMiniSwords = true;
	}

	private void _003CStrike_003Eb__28_4()
	{
		//IL_0039: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lightning2, soundConfig, 200f, 8, time);
		TP_SwordBrothers2_Weapon trueWeapon = _trueWeapon;
		float2 pos = base.position;
		Projectile projectile = trueWeapon._explosionPool.SpawnAt(pos, _weapon);
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private void _003CStrike_003Eb__28_5()
	{
		//IL_0064: Expected I, but got O
		//IL_00d2: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = false;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
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
		float2 float5 = base.position;
		tweenConfig.duration = 90f;
		tweenConfig.y = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_003e: Expected I, but got O
			//IL_00a8: Expected I, but got O
			//IL_010c: Expected O, but got I4
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[2];
			Transform transform2 = _Graphics.transform;
			if ((object)transform2 != null)
			{
				nint num2 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Transform transform3 = _Graphics2.transform;
			if ((object)transform3 != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 60f;
			tweenConfig2.scale = (float?)(object)1;
			TweenCallback onComplete2 = delegate
			{
				SpriteScroller spriteScroller = _SpriteScroller;
				spriteScroller._spriteRenderer.enabled = false;
				_Graphics.enabled = false;
				_Graphics2.enabled = false;
				Despawn();
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween despawnTween = Tweens.Add(tweenConfig2);
			_despawnTween = despawnTween;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween secondMoveTween = Tweens.Add(tweenConfig);
		_secondMoveTween = secondMoveTween;
	}

	private void _003CStrike_003Eb__28_6()
	{
		//IL_003e: Expected I, but got O
		//IL_00a8: Expected I, but got O
		//IL_010c: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		Transform transform = _Graphics.transform;
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
		Transform transform2 = _Graphics2.transform;
		if ((object)transform2 != null)
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
		tweenConfig.duration = 60f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			SpriteScroller spriteScroller = _SpriteScroller;
			spriteScroller._spriteRenderer.enabled = false;
			_Graphics.enabled = false;
			_Graphics2.enabled = false;
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween despawnTween = Tweens.Add(tweenConfig);
		_despawnTween = despawnTween;
	}

	private void _003CStrike_003Eb__28_7()
	{
		SpriteScroller spriteScroller = _SpriteScroller;
		spriteScroller._spriteRenderer.enabled = false;
		_Graphics.enabled = false;
		_Graphics2.enabled = false;
		Despawn();
	}
}
