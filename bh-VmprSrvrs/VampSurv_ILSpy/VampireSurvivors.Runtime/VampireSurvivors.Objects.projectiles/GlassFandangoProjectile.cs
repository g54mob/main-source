using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class GlassFandangoProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public GlassFandangoProjectile _003C_003E4__this;

		public float physArea;

		internal void _003COnRecycle_003Eb__0()
		{
			//IL_0016: Expected O, but got I4
			ArcadeSprite arcadeSprite = _003C_003E4__this.setScale(physArea, (float?)(object)0);
		}
	}

	private PhaserSprite _lanceSprite;

	private PhaserSprite _lanceTipSprite;

	private bool IsEvolved;

	private Vector2 _collisionPos;

	private Vector2 _spritePos;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private int _sfxIndex;

	private readonly SfxType[] _sounds = new SfxType[25]
	{
		SfxType.Glass01,
		SfxType.Glass02,
		SfxType.Glass03,
		SfxType.Glass04,
		SfxType.Glass05,
		SfxType.Glass06,
		SfxType.Glass07,
		SfxType.Glass08,
		SfxType.Glass09,
		SfxType.Glass10,
		SfxType.Glass11,
		SfxType.Glass12,
		SfxType.Glass13,
		SfxType.Glass14,
		SfxType.Glass15,
		SfxType.Glass16,
		SfxType.Glass17,
		SfxType.Glass18,
		SfxType.Glass19,
		SfxType.Glass20,
		SfxType.Glass21,
		SfxType.Glass22,
		SfxType.Glass23,
		SfxType.Glass24,
		SfxType.Glass25
	};

	private uint[] _colors = new uint[5] { 13434879u, 143654911u, 4508927u, 4474111u, 8947967u };

	private readonly BlendMode[] _blendModes = new BlendMode[4]
	{
		BlendMode.Normal,
		BlendMode.Screen,
		BlendMode.Screen,
		BlendMode.Screen
	};

	private readonly float[] _timeFreezeAngles = new float[13]
	{
		0f, 2.5f, -2.5f, 5f, -5f, 7.5f, -7.5f, 10f, -10f, 12.5f,
		-12.5f, 15f, -15f
	};

	private readonly float[] _angles = new float[6] { 0f, 180f, 60f, 240f, 120f, 300f };

	private SoundManager.SoundConfig _soundConfig;

	public float _life;

	private Transform _cachedSpriteTransform;

	private Transform _cachedSpriteTipTransform;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private MultiTargetTween _tween3;

	public override float ProjectileSpeed
	{
		get
		{
			float num = _weapon.PSpeed();
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			CharacterData currentCharacterData = characterController._currentCharacterData;
			float num2 = GameManager.PlayerPxSpeed * currentCharacterData._003CmoveSpeed_003Ek__BackingField;
			object obj = default(object);
			float num3 = num2 * (float)obj;
			return num3 * _speed;
		}
	}

	protected override void Awake()
	{
		//IL_03a5: Expected O, but got I4
		//IL_044b: Expected O, but got I4
		//IL_038b->IL02f5: Incompatible stack heights: 1 vs 0
		//IL_03d7->IL02f5: Incompatible stack heights: 1 vs 0
		//IL_0161->IL02f5: Incompatible stack heights: 1 vs 0
		//IL_01cd->IL02f5: Incompatible stack heights: 1 vs 0
		//IL_01f9->IL02f5: Incompatible stack heights: 1 vs 0
		//IL_0226->IL02f5: Incompatible stack heights: 1 vs 0
		//IL_0252->IL02f5: Incompatible stack heights: 1 vs 0
		//IL_0431->IL02f5: Incompatible stack heights: 2 vs 0
		//IL_047d->IL02f5: Incompatible stack heights: 2 vs 0
		//IL_02d1->IL02f5: Incompatible stack heights: 2 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if ((object)this != null)
		{
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite lanceSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "SpearShape");
			_lanceSprite = lanceSprite;
			if ((object)_lanceSprite != null)
			{
				GameObject gameObject2 = _lanceSprite.gameObject;
				if ((object)gameObject2 != null)
				{
					((UnityEngine.Object)gameObject2).SetName("LanceSprite");
					if ((object)_lanceSprite != null)
					{
						Transform transform = _lanceSprite.transform;
						if ((object)transform != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v26 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rcx_v27 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v26 (UnityEngine.Transform)+10]");
							Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
							if ((object)_lanceSprite != null)
							{
								PhaserSprite phaserSprite = _lanceSprite.setOrigin(0f, (float?)(object)1);
								PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(_lanceSprite, 0f);
								if ((object)_lanceSprite != null)
								{
									PhaserSprite phaserSprite3 = _lanceSprite.setVisible(visible: false);
									if ((object)_lanceSprite != null)
									{
										Transform cachedSpriteTransform = _lanceSprite.transform;
										_cachedSpriteTransform = cachedSpriteTransform;
										GameObject gameObject3 = base.gameObject;
										PhaserSprite lanceTipSprite = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "vfx", "SpearTip");
										_lanceTipSprite = lanceTipSprite;
										if ((object)_lanceTipSprite != null)
										{
											GameObject gameObject4 = _lanceTipSprite.gameObject;
											if ((object)gameObject4 != null)
											{
												((UnityEngine.Object)gameObject4).SetName("LanceTipSprite");
												if ((object)_lanceTipSprite != null)
												{
													Transform transform2 = _lanceTipSprite.transform;
													if ((object)transform2 != null)
													{
														bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
														nint num2 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1024 @ rcx_v45 (Il2CppMethodInfo)+38]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
														}
														Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)0, true);
														if ((object)_lanceTipSprite != null)
														{
															PhaserSprite phaserSprite4 = _lanceTipSprite.setOrigin(0f, (float?)(object)1);
															PhaserSprite phaserSprite5 = RenderingExtensions.SetScale(_lanceTipSprite, 0f);
															if ((object)_lanceTipSprite != null)
															{
																PhaserSprite phaserSprite6 = _lanceTipSprite.setVisible(visible: false);
																if ((object)_lanceTipSprite != null)
																{
																	Transform cachedSpriteTipTransform = _lanceTipSprite.transform;
																	_cachedSpriteTipTransform = cachedSpriteTipTransform;
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
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0156: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0110: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_lanceSprite, 0f);
		PhaserSprite phaserSprite2 = _lanceSprite.setAlpha(0.35f);
		PhaserSprite phaserSprite3 = _lanceSprite.setVisible(visible: true);
		Transform cachedSpriteTransform = _lanceSprite.transform;
		_cachedSpriteTransform = cachedSpriteTransform;
		PhaserSprite phaserSprite4 = RenderingExtensions.SetScale(_lanceTipSprite, 0f);
		PhaserSprite phaserSprite5 = _lanceTipSprite.setAlpha(0.35f);
		PhaserSprite phaserSprite6 = _lanceTipSprite.setVisible(visible: false);
		Transform cachedSpriteTipTransform = _lanceTipSprite.transform;
		_cachedSpriteTipTransform = cachedSpriteTipTransform;
		SfxType[] sounds = _sounds;
		_collisionPos = (Vector2)0;
		_spritePos = (Vector2)0;
		int sfxIndex = UnityEngine.Random.RandomRangeInt(0, sounds.Length);
		_sfxIndex = sfxIndex;
		Extensions.Shuffle(_sounds);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		_soundConfig = soundConfig;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 391 Invalid \"Jump target not found in method: 0x1872956C0\"");
		throw new NullReferenceException();
	}

	private unsafe void OnRecycle()
	{
		//IL_012d: Expected O, but got I4
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_018f: Expected I, but got O
		//IL_019c: Expected I, but got O
		//IL_01ac: Expected O, but got I
		//IL_01e8: Expected O, but got I
		//IL_0279: Expected O, but got I4
		//IL_039b: Expected O, but got I4
		//IL_03b6: Expected I, but got O
		//IL_04a4: Expected I, but got O
		//IL_050e: Expected I, but got O
		//IL_0564: Expected O, but got I4
		//IL_059c: Expected O, but got I4
		//IL_0616: Expected I, but got O
		//IL_0722: Expected F4, but got O
		//IL_0733: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Expected O, but got Unknown
		//IL_09bf: Invalid comparison between F4 and I4
		//IL_081c: Expected O, but got Ref
		//IL_0842: Expected O, but got Ref
		//IL_089c: Expected O, but got F4
		//IL_090c: Expected O, but got F4
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		float num = (float)_indexInWeapon * 0.02f;
		if (num > 0.1f)
		{
			num = 0.1f;
		}
		float alpha = 0.35f - num;
		PhaserSprite phaserSprite = _lanceSprite.setAlpha(alpha);
		Extensions.Shuffle(_colors);
		uint[] colors = _colors;
		int num2 = _indexInWeapon % colors.Length;
		BlendMode[] blendModes = _blendModes;
		int num3 = _indexInWeapon % blendModes.Length;
		PhaserSprite phaserSprite2 = _lanceSprite.setTint(colors[num2]);
		PhaserSprite phaserSprite3 = _lanceSprite.setBlendMode((BlendMode)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref blendModes[num3]));
		uint[] colors2 = _colors;
		object obj = _indexInWeapon + 1;
		object obj2 = obj % colors2.Length;
		PhaserSprite phaserSprite4 = _lanceSprite.setTint(colors2[obj2]);
		PhaserSprite phaserSprite5 = _lanceTipSprite.setVisible(IsEvolved);
		Weapon weapon = _weapon;
		nint num4 = (nint)typeof(GlassFandangoWeapon);
		nint num5 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandangoWeapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandangoWeapon>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rax_v38+FFFFFFF8+v1086 @ rax_v37*8]");
			if (0 == (nint)typeof(GlassFandangoWeapon))
			{
				float num7 = weapon.PArea();
				float num8 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ r8_v14 (VampireSurvivors.Objects.Weapons.Weapon)+17C]");
				float physArea = num8 * 0f;
				CS_0024_003C_003E8__locals10.physArea = physArea;
				float num9 = _weapon.PArea();
				_life = 0f;
				ArcadeSprite arcadeSprite = setScale(CS_0024_003C_003E8__locals10.physArea, (float?)(object)0);
				PhaserSprite phaserSprite6 = RenderingExtensions.SetScale(_lanceSprite, 0f);
				PhaserSprite phaserSprite7 = RenderingExtensions.SetScale(_lanceTipSprite, 0f);
				if (_tween1 != null)
				{
					_tween1.Kill();
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] targets = new object[1];
				if ((object)_cachedTransform != null)
				{
					PhaserSprite phaserSprite8 = RenderingExtensions.SetScale((PhaserSprite)(object)_cachedTransform, 0f);
					if ((object)phaserSprite8 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig.targets = targets;
				tweenConfig.duration = 200f;
				tweenConfig.yoyo = true;
				tweenConfig.scale = (float?)(object)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1255 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GlassFandangoProjectile>)+370]");
				TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
				nint num10 = (nint)this;
				tweenConfig.onComplete = onComplete;
				TweenCallback onStart = delegate
				{
					//IL_0016: Expected O, but got I4
					ArcadeSprite arcadeSprite2 = CS_0024_003C_003E8__locals10._003C_003E4__this.setScale(CS_0024_003C_003E8__locals10.physArea, (float?)(object)0);
				};
				tweenConfig.onStart = onStart;
				MultiTargetTween tween = Tweens.Add(tweenConfig);
				_tween1 = tween;
				if (_tween2 != null)
				{
					_tween2.Kill();
				}
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array = new object[2];
				Transform transform = _lanceSprite.transform;
				if ((object)transform != null)
				{
					nint num11 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Transform transform2 = _lanceTipSprite.transform;
				if ((object)transform2 != null)
				{
					nint num12 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj6 = default(object);
					if (obj6 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array;
				tweenConfig2.scaleX = (float?)(object)1;
				tweenConfig2.duration = 200f;
				tweenConfig2.yoyo = true;
				tweenConfig2.ease = Ease.InOutSine;
				tweenConfig2.scaleY = (float?)(object)1;
				MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
				_tween2 = tween2;
				if (_tween3 != null)
				{
					_tween3.Kill();
				}
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array2 = new object[1];
				nint num13 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig3.targets = array2;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object value = default(object);
					bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_life", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					tweenConfig3.custom = dictionary;
					tweenConfig3.duration = 200f;
					tweenConfig3.ease = Ease.Linear;
					tweenConfig3.yoyo = true;
					MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
					_tween3 = tween3;
					Weapon weapon2 = _weapon;
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
					float num14 = (float)characterController._lastMovementDirection;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rcx_v79 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
					object obj8 = 0 ^ -0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872961CAh\"");
					if ((object)characterController._lastMovementDirection == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872961CAh\"");
						if (obj8 == null)
						{
							num14 = 1f;
						}
					}
					bool flag2 = !(characterController._walked > 0f);
					float[] array3 = _angles;
					if (!flag2)
					{
						array3 = _timeFreezeAngles;
					}
					int num15 = _indexInWeapon % array3.Length;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					float num16 = array3[num15] * ((float)Math.PI / 180f);
					float num17 = (float)obj8 + num16;
					Transform transform3 = _lanceSprite.transform;
					object obj9 = default(object);
					transform3.localEulerAngles = (Vector3)(&obj9);
					Transform transform4 = _lanceTipSprite.transform;
					transform4.localEulerAngles = (Vector3)(&obj9);
					float num18 = (CS_0024_003C_003E8__locals10.physArea *= 0.01f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					float num19 = num18 * 2.5f;
					float num20 = num17 * num19;
					_collisionPos = (Vector2)num20;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num21 = CS_0024_003C_003E8__locals10.physArea * -2.5f;
					float num22 = num17 * num21;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					float num23 = CS_0024_003C_003E8__locals10.physArea * 0.1f;
					float num24 = num17 * num23;
					_spritePos = (Vector2)num24;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num25 = CS_0024_003C_003E8__locals10.physArea * -0.1f;
					float num26 = num17 * num25;
					return;
				}
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		throw new InvalidCastException();
	}

	public override void InternalUpdate()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
		PhaserSprite phaserSprite = _lanceSprite.setPosition(float6);
		PhaserSprite phaserSprite2 = _lanceTipSprite.setPosition(float6);
	}

	protected unsafe override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			if ((IsEvolved ? 1 : 0) != (nint)obj)
			{
				bool flag = TryFreeze(other);
			}
			SfxType[] sounds = _sounds;
			int num = ++_sfxIndex % sounds.Length;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref sounds[num]), _soundConfig, 150f, 1, time);
		}
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _lanceSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _lanceTipSprite.setVisible(visible: false);
		base.Despawn();
	}
}
