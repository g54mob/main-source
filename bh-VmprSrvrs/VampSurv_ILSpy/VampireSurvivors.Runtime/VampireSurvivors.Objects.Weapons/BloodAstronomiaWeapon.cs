using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class BloodAstronomiaWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass60_0
	{
		public BloodAstronomiaWeapon _003C_003E4__this;

		public float2 pos;
	}

	private sealed class _003C_003Ec__DisplayClass60_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass60_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireStream_003Eb__0()
		{
			//IL_0066: Expected I, but got O
			//IL_0074: Expected I, but got O
			//IL_0084: Expected O, but got I
			//IL_0104: Expected O, but got I4
			//IL_00c0: Expected O, but got I
			//IL_00f6: Expected O, but got I4
			_003C_003Ec__DisplayClass60_0 obj = CS_0024_003C_003E8__locals1;
			BloodAstronomiaWeapon bloodAstronomiaWeapon = obj._003C_003E4__this;
			float2 pos = default(float2);
			Projectile projectile = bloodAstronomiaWeapon._streamPool.SpawnAt(pos, obj._003C_003E4__this, localIndex);
			bool flag = (object)projectile == null;
			BloodStreamProjectile bloodStreamProjectile = null;
			object obj4;
			if (!flag)
			{
				nint num = (nint)projectile;
				nint num2 = (nint)typeof(BloodStreamProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodStreamProjectile>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodStreamProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v24+FFFFFFF8+v201 @ rax_v20*8]");
					if (0 == (nint)typeof(BloodStreamProjectile))
					{
						obj4 = 1;
						goto IL_0194;
					}
				}
				obj4 = 0;
				goto IL_0194;
			}
			goto IL_01bb;
			IL_01bb:
			if ((object)bloodStreamProjectile != null && ((UnityEngine.Object)bloodStreamProjectile).m_CachedPtr != (IntPtr)0)
			{
				_003C_003Ec__DisplayClass60_0 obj5 = CS_0024_003C_003E8__locals1;
				BloodAstronomiaWeapon bloodAstronomiaWeapon2 = obj5._003C_003E4__this;
				bloodStreamProjectile.OverrideWeaponData(bloodAstronomiaWeapon2._003CStream_003Ek__BackingField);
			}
			return;
			IL_0194:
			bool flag2 = obj4 == null;
			bloodStreamProjectile = null;
			if (!flag2)
			{
				bloodStreamProjectile = (BloodStreamProjectile)projectile;
			}
			goto IL_01bb;
		}
	}

	private SpriteRenderer _LineTop;

	private SpriteRenderer _LineBottom;

	private Transform DirectionalDamageCointainer;

	private SpriteRenderer _Image;

	private MultiTargetTween _imageTween;

	private MultiTargetTween _imageTween2;

	private BulletPool _garlicPool;

	private BulletPool _songPool;

	private BulletPool _pentagramPool;

	private BulletPool _laurelPool;

	private BulletPool _lancetPool;

	private ObjectPool _moonExplosionPool;

	private BulletPool _streamPool;

	private BulletPool _rapidusPool;

	private bool _hasRapidus;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private const float ImagePixelSize = 16f;

	private Weapon _003CGarlic_003Ek__BackingField;

	private Weapon _003CSong_003Ek__BackingField;

	private Weapon _003CPentagram_003Ek__BackingField;

	private Weapon _003CLaurel_003Ek__BackingField;

	private Weapon _003CLancet_003Ek__BackingField;

	private Weapon _003CStream_003Ek__BackingField;

	private Weapon _003CRapidus_003Ek__BackingField;

	public Weapon Garlic
	{
		get
		{
			return _003CGarlic_003Ek__BackingField;
		}
		set
		{
			_003CGarlic_003Ek__BackingField = value;
		}
	}

	public Weapon Song
	{
		get
		{
			return _003CSong_003Ek__BackingField;
		}
		set
		{
			_003CSong_003Ek__BackingField = value;
		}
	}

	public Weapon Pentagram
	{
		get
		{
			return _003CPentagram_003Ek__BackingField;
		}
		set
		{
			_003CPentagram_003Ek__BackingField = value;
		}
	}

	public Weapon Laurel
	{
		get
		{
			return _003CLaurel_003Ek__BackingField;
		}
		set
		{
			_003CLaurel_003Ek__BackingField = value;
		}
	}

	public Weapon Lancet
	{
		get
		{
			return _003CLancet_003Ek__BackingField;
		}
		set
		{
			_003CLancet_003Ek__BackingField = value;
		}
	}

	public Weapon Stream
	{
		get
		{
			return _003CStream_003Ek__BackingField;
		}
		set
		{
			_003CStream_003Ek__BackingField = value;
		}
	}

	public Weapon Rapidus
	{
		get
		{
			return _003CRapidus_003Ek__BackingField;
		}
		set
		{
			_003CRapidus_003Ek__BackingField = value;
		}
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_02db: Expected I, but got O
		//IL_043e: Expected O, but got I
		//IL_04b4: Expected O, but got I
		//IL_04eb: Expected O, but got I
		//IL_0561: Expected O, but got I
		//IL_05ae: Expected O, but got Ref
		//IL_05d5: Expected O, but got I
		//IL_05ea: Expected native int or pointer, but got O
		//IL_0619: Expected O, but got I
		//IL_062c: Expected O, but got Ref
		//IL_0646: Expected native int or pointer, but got O
		//IL_0961: Expected O, but got I4
		//IL_065e: Expected O, but got Ref
		//IL_0678: Expected native int or pointer, but got O
		//IL_098e: Expected O, but got I4
		//IL_09a3: Expected O, but got I
		//IL_09b8: Expected O, but got I
		//IL_07e3: Expected I4, but got I8
		//IL_07fb: Expected I4, but got I8
		//IL_01c7->IL01c7: Incompatible stack heights: 5 vs 4
		//IL_02fe->IL02fe: Incompatible stack heights: 8 vs 7
		//IL_06c6->IL085b: Incompatible stack heights: 14 vs 0
		//IL_070c->IL085b: Incompatible stack heights: 14 vs 0
		//IL_0738->IL085b: Incompatible stack heights: 14 vs 0
		//IL_076b->IL085b: Incompatible stack heights: 14 vs 0
		//IL_0797->IL085b: Incompatible stack heights: 14 vs 0
		//IL_07ca->IL085b: Incompatible stack heights: 14 vs 0
		//IL_081a->IL085b: Incompatible stack heights: 14 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitWeapon(characterController, weaponType);
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.ExplosionBloodVfx);
			_moonExplosionPool = pool;
			_hasRapidus = false;
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			if ((object)_Image != null)
			{
				((Renderer)_Image).SetMaterial(material);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_Image, 0.6f);
				if ((object)_Image != null)
				{
					Transform transform = _Image.transform;
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)characterController2._magnet != null)
					{
						Transform transform2 = characterController2._magnet.transform;
						if ((object)transform2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v48 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v48 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
							bool flag2 = (object)transform == null;
							bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							float num = PArea();
							float scale = (float)ret * 0.0625f;
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_Image, scale);
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							bool flag4 = array == null;
							if ((object)_Image != null)
							{
								SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_Image, scale);
								bool flag5 = (object)spriteRenderer3 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							bool flag6 = tweenConfig == null;
							_ = 4294967295L;
							_ = 0;
							_ = 1;
							_ = 1120403456;
							_ = 1148846080;
							_ = 1;
							_ = 1050253722;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
							_ = 0;
							MultiTargetTween imageTween = Tweens.Add(tweenConfig);
							_imageTween = imageTween;
							TweenConfig tweenConfig2 = new TweenConfig();
							object[] array2 = new object[1];
							bool flag7 = (object)_Image == null;
							Transform transform3 = _Image.transform;
							bool flag8 = array2 == null;
							if ((object)transform3 != null)
							{
								nint num2 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj3 = default(object);
								bool flag9 = obj3 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							bool flag10 = tweenConfig2 == null;
							_ = 0;
							_ = 3283353600L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
							_ = 0;
							_ = 4294967295L;
							_ = 1169915904;
							_ = 1;
							MultiTargetTween imageTween2 = Tweens.Add(tweenConfig2);
							_imageTween = imageTween2;
							bool flag11 = (object)DirectionalDamageCointainer == null;
							GameObject gameObject = DirectionalDamageCointainer.gameObject;
							bool flag12 = (object)gameObject == null;
							ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
							_pfxManager = pfxManager;
							ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
							List<string> list = new List<string>();
							bool flag13 = list == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v87 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v87 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v87 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag14 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v87 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1029 @ rcx_v77+18]");
							if (num3 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"PfxRed.png");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v87 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj5 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v87 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v87 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v87 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag15 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v87 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1030 @ rcx_v79+18]");
							if (num4 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"PfxDarkRed.png");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v87 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj7 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							bool flag16 = particleSystemConfig == null;
							((ArcadeSprite)(object)particleSystemConfig)._cachedTrans = (Transform)(object)list;
							ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
							_ = 0;
							_ = 5;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
							((VampireSurvivors.Objects.Characters.CharacterController)(object)particleSystemConfig)._dataManager = (DataManager)0;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1000f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
							((VampireSurvivors.Objects.Characters.CharacterController)(object)particleSystemConfig)._startingWeaponType = WeaponType.VOID;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
							((VampireSurvivors.Objects.Characters.CharacterController)(object)particleSystemConfig)._regenTimer = (Timer)0;
							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0.65f, 0f));
							((VampireSurvivors.Objects.Characters.CharacterController)(object)particleSystemConfig)._freezeWeaponsTimer = (Timer)1;
							bool hasWalkingAnimation = default(bool);
							((VampireSurvivors.Objects.Characters.CharacterController)(object)particleSystemConfig)._hasWalkingAnimation = hasWalkingAnimation;
							Vector2 currentDirection = default(Vector2);
							((VampireSurvivors.Objects.Characters.CharacterController)(object)particleSystemConfig)._currentDirection = currentDirection;
							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 32));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(2f, 1f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
							_ = 0;
							((VampireSurvivors.Objects.Characters.CharacterController)(object)particleSystemConfig)._lastMovementDirection = (Vector2)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
							((VampireSurvivors.Objects.Characters.CharacterController)(object)particleSystemConfig)._propBlock = (MaterialPropertyBlock)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
							((VampireSurvivors.Objects.Characters.CharacterController)(object)particleSystemConfig)._coopMovementBoxCollider = (ArcadeBodyBounds)0;
							_ = 0;
							Transform parent = base.transform;
							if ((object)_pfxManager != null)
							{
								ParticleSystem pfx = _pfxManager.CreateEmitter(particleSystemConfig, parent);
								_pfx = pfx;
								if ((object)_pfxManager != null)
								{
									Transform transform4 = _pfxManager.transform;
									if ((object)transform4 != null)
									{
										transform4.SetParent(DirectionalDamageCointainer, worldPositionStays: true);
										if ((object)_pfx != null)
										{
											Transform transform5 = _pfx.transform;
											if ((object)transform5 != null)
											{
												transform5.SetParent(DirectionalDamageCointainer, worldPositionStays: true);
												if ((object)_pfxManager != null)
												{
													ParticleEmitterManager particleEmitterManager = _pfxManager.SetDepth(-1997);
													RenderingExtensions.SetDepth(_pfx, -1997);
													if ((object)_pfxManager != null)
													{
														Transform transform6 = _pfxManager.transform;
														bool flag17 = (object)transform6 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2421 @ rax_v113 (UnityEngine.Transform)+10]");
														bool flag18 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2421 @ rax_v113 (UnityEngine.Transform)+10]");
														Transform.set_localPosition_Injected((IntPtr)0, ref value);
														bool flag19 = (object)_pfx == null;
														Transform transform7 = _pfx.transform;
														bool flag20 = (object)transform7 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2476 @ rax_v121 (UnityEngine.Transform)+10]");
														bool flag21 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2476 @ rax_v121 (UnityEngine.Transform)+10]");
														Transform.set_localPosition_Injected((IntPtr)0, ref ret);
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
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		float num = PArea();
		object obj = default(object);
		float scale = (float)obj * 0.0625f;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_Image, scale);
		base.Fire(skipTriggers: true);
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00d6->IL0100: Incompatible stack heights: 3 vs 0
		//IL_0221->IL0221: Incompatible stack heights: 5 vs 3
		base.InternalUpdate();
		if ((object)_Image != null)
		{
			Transform transform = _Image.transform;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)characterController._magnet != null)
			{
				Transform transform2 = characterController._magnet.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					if (!_hasRapidus)
					{
						return;
					}
					RenderingExtensions.Start(_pfx);
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						BloodAstronomiaWeapon directionalDamageCointainer = (BloodAstronomiaWeapon)(object)DirectionalDamageCointainer;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
						Quaternion.Internal_FromEulerRad_Injected(ref value, out *(Quaternion*)(&ret));
						bool flag4 = (object)DirectionalDamageCointainer == null;
						bool flag5 = ((UnityEngine.Object)directionalDamageCointainer).m_CachedPtr == (IntPtr)0;
						Quaternion value2 = default(Quaternion);
						Transform.set_rotation_Injected(((UnityEngine.Object)directionalDamageCointainer).m_CachedPtr, ref value2);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SpawnBloodExplosionVfxAt(float2 pos, float damage = 1f, float radius = 1f)
	{
		//IL_0016: Expected F4, but got O
		float yPos = default(float);
		float radius2 = default(float);
		SpawnBloodExplosionVfxAt((float)pos, yPos, damage, radius2);
	}

	public unsafe void SpawnBloodExplosionVfxAt(float xPos, float yPos, float damage = 1f, float radius = 1f)
	{
		//IL_0022: Expected O, but got Ref
		//IL_0022: Expected O, but got Ref
		//IL_00a2: Expected I4, but got O
		object obj2 = default(object);
		object obj3 = default(object);
		GameObject obj = _moonExplosionPool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
		ExplosionBloodVfx objectComponent = _moonExplosionPool.GetObjectComponent<ExplosionBloodVfx>(obj);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num = yPos + 1f;
		object obj4 = default(object);
		float num2 = num - (float)obj4;
		float depth = num2 * -1f;
		PhaserSprite groundFx = objectComponent._GroundFx;
		int sortingOrder = (int)((ObjectPool)(object)typeof(RenderingExtensions)).GetObjectComponent<ExplosionBloodVfx>(obj);
		groundFx._spriteRenderer.sortingOrder = sortingOrder;
		objectComponent._particlesManager.SetDepthMultiplied(depth);
		float radius2 = default(float);
		objectComponent.OnRecycle(radius2);
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_Image.enabled = visible;
	}

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		object obj = default(object);
		return (float)obj * currentWeaponData._003Cpower_003Ek__BackingField;
	}

	public override float PAmount()
	{
		return 1f;
	}

	public override float PArea()
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		MagnetZone magnet = characterController._magnet;
		EggFloat radius = magnet.Radius;
		float num = radius._eggVal + radius._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187391DBDh\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public void FireGarlic()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_016f: Expected I, but got O
		//IL_017f: Expected O, but got I
		//IL_01bb: Invalid comparison between F4 and I4
		//IL_0273: Expected I, but got O
		//IL_0281: Expected I, but got O
		//IL_0291: Expected O, but got I
		//IL_0311: Expected O, but got I4
		//IL_0434: Expected O, but got I
		//IL_02cd: Expected O, but got I
		//IL_0326: Expected O, but got I
		//IL_0303: Expected O, but got I4
		//IL_03c1: Invalid comparison between F4 and I4
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		float num2 = default(float);
		bool flag = num2 > 10f;
		float num3 = 10f;
		if (!flag)
		{
			num3 = num2;
		}
		Weapon weapon = _003CGarlic_003Ek__BackingField;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num4 = (float)currentWeaponData._003Camount_003Ek__BackingField + num3;
		MagnetZone magnet = characterController._magnet;
		EggFloat eggFloat = magnet.Radius / 32f;
		float num5 = eggFloat._eggVal + eggFloat._val;
		object obj = num5 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num5 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187391F3Ch\"");
				if (num5 == -1f / 0f)
				{
					num5 = -3.4028235E+38f;
				}
				goto IL_03e5;
			}
		}
		num5 = 3.4028235E+38f;
		goto IL_03e5;
		IL_03e5:
		Weapon weapon2 = _003CGarlic_003Ek__BackingField;
		nint num6 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+3F0]");
		Weapon weapon3 = (Weapon)0;
		float num7 = weapon2.PArea();
		float num8 = default(float);
		if (num5 > num2)
		{
			ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
			num8 = (float)Math.PI * 2f / num4;
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		if (!(num4 > 0f))
		{
			return;
		}
		int num9 = 0;
		Weapon weapon4 = null;
		float2 float5 = default(float2);
		do
		{
			float num10 = (float)num9 * num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num11 = (float)num9 * num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Projectile projectile = _garlicPool.SpawnAt(float5, this, num9);
			BloodGarlicProjectile bloodGarlicProjectile;
			float2 float6;
			if ((object)projectile == null)
			{
				bloodGarlicProjectile = null;
				weapon4 = this;
				float6 = float5;
				goto IL_0455;
			}
			nint num12 = (nint)projectile;
			nint num13 = (nint)typeof(BloodGarlicProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodGarlicProjectile>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodGarlicProjectile>)+130]");
			object obj5;
			if (num14 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rax_v37+FFFFFFF8+v498 @ rax_v33*8]");
				if (0 == (nint)typeof(BloodGarlicProjectile))
				{
					obj5 = 1;
					goto IL_0418;
				}
			}
			obj5 = 0;
			goto IL_0418;
			IL_0418:
			bool flag2 = obj5 == null;
			bloodGarlicProjectile = null;
			weapon4 = (Weapon)num12;
			float6 = (float2)typeof(BloodGarlicProjectile);
			if (!flag2)
			{
				bloodGarlicProjectile = (BloodGarlicProjectile)projectile;
				weapon4 = (Weapon)num12;
				float6 = (float2)typeof(BloodGarlicProjectile);
			}
			goto IL_0455;
			IL_0455:
			bool flag3 = (object)bloodGarlicProjectile == null;
			weapon3 = (Weapon)float6;
			ArcadeSprite arcadeSprite = (ArcadeSprite)(object)typeof(UnityEngine.Object);
			if (!flag3)
			{
				bool flag4 = ((UnityEngine.Object)bloodGarlicProjectile).m_CachedPtr == (IntPtr)0;
				weapon3 = (Weapon)float6;
				arcadeSprite = (ArcadeSprite)(object)typeof(UnityEngine.Object);
				if (!flag4)
				{
					weapon3 = _003CGarlic_003Ek__BackingField;
					bloodGarlicProjectile.OverrideWeaponData(_003CGarlic_003Ek__BackingField);
					weapon4 = null;
					arcadeSprite = bloodGarlicProjectile;
				}
			}
			num9++;
		}
		while (num4 > (float)num9);
	}

	public void FireSong()
	{
		//IL_0099: Invalid comparison between F4 and I4
		//IL_0108: Expected I, but got O
		//IL_0116: Expected I, but got O
		//IL_0126: Expected O, but got I
		//IL_01a6: Expected O, but got I4
		//IL_0162: Expected O, but got I
		//IL_0198: Expected O, but got I4
		//IL_0213: Invalid comparison between F4 and I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = characterController.PAmount();
		float num2 = default(float);
		bool flag = num2 > 10f;
		float num3 = 10f;
		if (!flag)
		{
			num3 = num2;
		}
		Weapon weapon = _003CSong_003Ek__BackingField;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		float num4 = (float)currentWeaponData._003Camount_003Ek__BackingField * 3f;
		float num5 = num4 + num3;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		if (!(num5 > 0f))
		{
			return;
		}
		int num6 = 0;
		float2 pos = default(float2);
		do
		{
			Projectile projectile = _songPool.SpawnAt(pos, this, num6);
			BloodPlanetProjectile bloodPlanetProjectile;
			if ((object)projectile == null)
			{
				bloodPlanetProjectile = null;
				goto IL_0272;
			}
			nint num7 = (nint)projectile;
			nint num8 = (nint)typeof(BloodPlanetProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodPlanetProjectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodPlanetProjectile>)+130]");
			object obj3;
			if (num9 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rax_v28+FFFFFFF8+v324 @ rax_v24*8]");
				if (0 == (nint)typeof(BloodPlanetProjectile))
				{
					obj3 = 1;
					goto IL_024b;
				}
			}
			obj3 = 0;
			goto IL_024b;
			IL_024b:
			bool flag2 = obj3 == null;
			bloodPlanetProjectile = null;
			if (!flag2)
			{
				bloodPlanetProjectile = (BloodPlanetProjectile)projectile;
			}
			goto IL_0272;
			IL_0272:
			if ((object)bloodPlanetProjectile != null && ((UnityEngine.Object)bloodPlanetProjectile).m_CachedPtr != (IntPtr)0)
			{
				bloodPlanetProjectile.OverrideWeaponData(_003CSong_003Ek__BackingField);
			}
			num6++;
		}
		while (num5 > (float)num6);
	}

	public void FirePentagram()
	{
		Action onComplete = delegate
		{
			//IL_000d: Expected I, but got O
			//IL_001d: Expected O, but got I
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Expected O, but got Unknown
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Expected O, but got Unknown
			//IL_024e: Invalid comparison between F4 and I4
			//IL_0454: Invalid comparison between F4 and I4
			//IL_0306: Expected I, but got O
			//IL_0314: Expected I, but got O
			//IL_0324: Expected O, but got I
			//IL_03a4: Expected O, but got I4
			//IL_04e5: Expected O, but got I
			//IL_0360: Expected O, but got I
			//IL_03b1: Expected O, but got I
			//IL_0396: Expected O, but got I4
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			nint num = (nint)characterController;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+5A0]");
			Weapon weapon = (Weapon)0;
			float num2 = characterController.PAmount();
			float num3 = default(float);
			bool flag = num3 > 10f;
			float num4 = 10f;
			if (!flag)
			{
				num4 = num3;
			}
			Weapon weapon2 = _003CPentagram_003Ek__BackingField;
			WeaponData currentWeaponData = weapon2._currentWeaponData;
			float num5 = (float)currentWeaponData._003Camount_003Ek__BackingField * 3f;
			float num6 = num5 + num4;
			float num7 = (float)Math.PI * 2f / num6;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			MagnetZone magnet = characterController2._magnet;
			EggFloat radius = magnet.Radius;
			float eggValue = default(float);
			float value = default(float);
			EggFloat eggFloat = new EggFloat(value, eggValue);
			eggValue = radius._eggVal * 0.01f;
			value = radius._val * 0.01f;
			float eggValue2 = default(float);
			float value2 = default(float);
			EggFloat eggFloat2 = new EggFloat(value2, eggValue2);
			eggValue2 = eggFloat._eggVal * 0.75f;
			value2 = eggFloat._val * 0.75f;
			float num8 = eggFloat2._eggVal + eggFloat2._val;
			object obj = num8 & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num8 & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873957C3h\"");
					if (num8 == -1f / 0f)
					{
						num8 = -3.4028235E+38f;
					}
					goto IL_049d;
				}
			}
			num8 = 3.4028235E+38f;
			goto IL_049d;
			IL_050b:
			BloodPentagramProjectile bloodPentagramProjectile = default(BloodPentagramProjectile);
			bool flag2 = (object)bloodPentagramProjectile == null;
			float2 float5 = default(float2);
			weapon = (Weapon)float5;
			ArcadeSprite typeFromHandle = (ArcadeSprite)(object)typeof(UnityEngine.Object);
			Weapon weapon3;
			if (!flag2)
			{
				bool flag3 = ((UnityEngine.Object)bloodPentagramProjectile).m_CachedPtr == (IntPtr)0;
				weapon = (Weapon)float5;
				typeFromHandle = (ArcadeSprite)(object)typeof(UnityEngine.Object);
				if (!flag3)
				{
					weapon = _003CPentagram_003Ek__BackingField;
					bloodPentagramProjectile.OverrideWeaponData(_003CPentagram_003Ek__BackingField);
					weapon3 = null;
					typeFromHandle = bloodPentagramProjectile;
				}
			}
			int num9 = num9 + 1;
			bool flag4 = num6 > (float)num9;
			Projectile projectile2 = default(Projectile);
			Projectile projectile = projectile2;
			if (!flag4)
			{
				return;
			}
			goto IL_0278;
			IL_04ce:
			object obj3;
			bool flag5 = obj3 == null;
			nint num10;
			weapon3 = (Weapon)num10;
			bloodPentagramProjectile = null;
			float5 = (float2)typeof(BloodPentagramProjectile);
			if (!flag5)
			{
				weapon3 = (Weapon)num10;
				bloodPentagramProjectile = (BloodPentagramProjectile)projectile2;
				float5 = (float2)typeof(BloodPentagramProjectile);
			}
			goto IL_050b;
			IL_0278:
			float num11 = (float)num9 * num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num12 = (float)num9 * num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float2 float6 = default(float2);
			projectile2 = _pentagramPool.SpawnAt(float6, this, num9);
			if ((object)projectile2 != null)
			{
				num10 = (nint)projectile2;
				nint num13 = (nint)typeof(BloodPentagramProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodPentagramProjectile>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodPentagramProjectile>)+130]");
				if (num14 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v45+FFFFFFF8+v617 @ rax_v41*8]");
					if (0 == (nint)typeof(BloodPentagramProjectile))
					{
						obj3 = 1;
						goto IL_04ce;
					}
				}
				obj3 = 0;
				goto IL_04ce;
			}
			weapon3 = this;
			bloodPentagramProjectile = null;
			float5 = float6;
			goto IL_050b;
			IL_049d:
			float num15 = renderer.height * 0.45f;
			if (num8 > num15)
			{
				typeFromHandle = ((Equipment)this)._003COwner_003Ek__BackingField;
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if (!(num6 > 0f))
				{
					return;
				}
				num9 = 0;
				projectile = null;
				goto IL_0278;
			}
			goto IL_050b;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void FireLaurel()
	{
		//IL_005f: Expected I, but got O
		//IL_006d: Expected I, but got O
		//IL_007d: Expected O, but got I
		//IL_00fd: Expected O, but got I4
		//IL_00b9: Expected O, but got I
		//IL_00ef: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float2 position = characterController._magnet.position;
		float2 pos = default(float2);
		Projectile projectile = _laurelPool.SpawnAt(pos, this);
		bool flag = (object)projectile == null;
		BloodLaurelProjectile bloodLaurelProjectile = null;
		object obj3;
		if (!flag)
		{
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(BloodLaurelProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodLaurelProjectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodLaurelProjectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v24+FFFFFFF8+v169 @ rax_v20*8]");
				if (0 == (nint)typeof(BloodLaurelProjectile))
				{
					obj3 = 1;
					goto IL_0169;
				}
			}
			obj3 = 0;
			goto IL_0169;
		}
		goto IL_0190;
		IL_0190:
		if ((object)bloodLaurelProjectile != null && ((UnityEngine.Object)bloodLaurelProjectile).m_CachedPtr != (IntPtr)0)
		{
			bloodLaurelProjectile.OverrideWeaponData(_003CLaurel_003Ek__BackingField);
		}
		return;
		IL_0169:
		bool flag2 = obj3 == null;
		bloodLaurelProjectile = null;
		if (!flag2)
		{
			bloodLaurelProjectile = (BloodLaurelProjectile)projectile;
		}
		goto IL_0190;
	}

	public void FireLancet()
	{
		//IL_005f: Expected I, but got O
		//IL_006d: Expected I, but got O
		//IL_007d: Expected O, but got I
		//IL_00fd: Expected O, but got I4
		//IL_00b9: Expected O, but got I
		//IL_00ef: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float2 position = characterController._magnet.position;
		float2 pos = default(float2);
		Projectile projectile = _lancetPool.SpawnAt(pos, this);
		bool flag = (object)projectile == null;
		BloodLancetProjectile bloodLancetProjectile = null;
		object obj3;
		if (!flag)
		{
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(BloodLancetProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodLancetProjectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodLancetProjectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v24+FFFFFFF8+v169 @ rax_v20*8]");
				if (0 == (nint)typeof(BloodLancetProjectile))
				{
					obj3 = 1;
					goto IL_0169;
				}
			}
			obj3 = 0;
			goto IL_0169;
		}
		goto IL_0190;
		IL_0190:
		if ((object)bloodLancetProjectile != null && ((UnityEngine.Object)bloodLancetProjectile).m_CachedPtr != (IntPtr)0)
		{
			bloodLancetProjectile.OverrideWeaponData(_003CLancet_003Ek__BackingField);
		}
		return;
		IL_0169:
		bool flag2 = obj3 == null;
		bloodLancetProjectile = null;
		if (!flag2)
		{
			bloodLancetProjectile = (BloodLancetProjectile)projectile;
		}
		goto IL_0190;
	}

	public unsafe void FireStream()
	{
		//IL_00f0: Expected I, but got O
		//IL_0106: Expected O, but got I
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_017d: Expected I, but got O
		//IL_01bc: Expected O, but got I4
		//IL_01cf: Expected O, but got I4
		//IL_01e1: Expected I, but got I8
		//IL_0197: Expected O, but got F4
		//IL_0166: Expected I, but got I8
		_003C_003Ec__DisplayClass60_0 obj = new _003C_003Ec__DisplayClass60_0();
		obj._003C_003E4__this = this;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float2 float5 = (obj.pos = characterController._magnet.position);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = false;
		float2 float6 = float5;
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			float num = characterController2.PAmount();
			if ((nint)float6 <= (flag2 ? 1 : 0))
			{
				break;
			}
			_003C_003Ec__DisplayClass60_1 obj2 = new _003C_003Ec__DisplayClass60_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.localIndex = (flag ? 1 : 0);
			Action action = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass60_1._003CFireStream_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num3;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num3 = unchecked((nint)6447293664L);
					goto IL_01b3;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num3 = ((Delegate)action).method_ptr;
			goto IL_01b3;
			IL_01b3:
			object obj5 = 24;
			object obj6 = (flag ? 1 : 0) + 1;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num4 = (float)obj6 * 50f;
			float num5 = num4 * 0.001f;
			Timer timer = Timers.Register(num5, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			float6 = (float2)num5;
			flag2 = flag;
		}
	}

	public unsafe void FireTPRapidus()
	{
		//IL_0078: Expected O, but got I
		//IL_00ad: Expected O, but got I
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_02be: Expected O, but got I
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_096f: Expected O, but got F4
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Expected O, but got Unknown
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Expected O, but got Unknown
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Expected O, but got Unknown
		//IL_05d5: Invalid comparison between F4 and I4
		//IL_0ac8: Expected O, but got F4
		//IL_0b0e: Expected O, but got F4
		//IL_0b34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b39: Expected O, but got Unknown
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0642: Expected O, but got Unknown
		//IL_06f2: Expected I, but got O
		//IL_0700: Expected I, but got O
		//IL_0710: Expected O, but got I
		//IL_0790: Expected O, but got I4
		//IL_074c: Expected O, but got I
		//IL_0782: Expected O, but got I4
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_083f: Expected O, but got Unknown
		//IL_0847: Invalid comparison between F4 and O
		//IL_0857->IL0c09: Incompatible stack heights: 5 vs 1
		//IL_085c->IL085c: Incompatible stack heights: 5 vs 1
		//IL_0c09->IL0831: Incompatible stack heights: 7 vs 5
		_hasRapidus = true;
		EggFloat eggFloat;
		PhaserScene.Renderer renderer;
		float num;
		if ((object)DirectionalDamageCointainer != null)
		{
			GameObject gameObject = DirectionalDamageCointainer.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				Transform transform = (Transform)(object)((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rbx_v11 (UnityEngine.Transform)+248]");
					Transform transform2 = (Transform)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rbx_v11 (UnityEngine.Transform)+248]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v12 (UnityEngine.Transform)+70]");
						Transform transform3 = (Transform)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v12 (UnityEngine.Transform)+70]");
						if ((nint)0 != 0)
						{
							float eggValue = default(float);
							float value = default(float);
							eggFloat = new EggFloat(value, eggValue);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v13 (UnityEngine.Transform)+14]");
							eggValue = 0f * 0.005f;
							value = (float)(nint)((UnityEngine.Object)transform3).m_CachedPtr * 0.005f;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									renderer = s_scene._renderer;
									if (s_scene._renderer != null && eggFloat != null)
									{
										num = eggFloat._eggVal + eggFloat._val;
										object obj = num & -2147483649L;
										if ((nint)obj != 2139095040)
										{
											object obj2 = num & -2147483649L;
											if ((nint)obj2 <= 2139095040)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187392D78h\"");
												if (num == -1f / 0f)
												{
													num = -3.4028235E+38f;
												}
												goto IL_08e9;
											}
										}
										num = 3.4028235E+38f;
										goto IL_08e9;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0896;
		IL_0953:
		Rectangle rectangle = new Rectangle();
		object obj3 = renderer.width ^ -0f;
		float x = (float)obj3 * 0.5f;
		rectangle._y = num;
		PhaserScene.Renderer renderer2;
		rectangle._width = renderer2.width;
		rectangle._x = x;
		float num2;
		rectangle._height = num2;
		if ((object)_LineTop == null)
		{
			goto IL_0896;
		}
		Transform transform4 = _LineTop.transform;
		float num3 = eggFloat._eggVal + eggFloat._val;
		object obj4 = num3 & -2147483649L;
		if ((nint)obj4 != 2139095040)
		{
			object obj5 = num3 & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187392F31h\"");
				if (num3 == -1f / 0f)
				{
					num3 = -3.4028235E+38f;
				}
				goto IL_09d7;
			}
		}
		num3 = 3.4028235E+38f;
		goto IL_09d7;
		IL_0896:
		throw new NullReferenceException();
		IL_0a47:
		Transform transform5;
		if ((object)transform5 != null)
		{
			bool flag = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
			float2 value2 = default(float2);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)(&value2));
			RenderingExtensions.SetEmitZone(emitZone: new EmitZone
			{
				_type = EmitZoneType.Random,
				_source = rectangle
			}, pfx: _pfx);
			float num4 = PAmount();
			float2 float5 = default(float2);
			float num5 = (float)float5 + 1f;
			float num6 = num5 + num5;
			if (!(num6 > 0f))
			{
				return;
			}
			float num7 = num5 + num5;
			EmitZone emitZone = null;
			float2 value3 = default(float2);
			do
			{
				object obj6 = UnityEngine.Random.value;
				bool flag2 = (object)GM.Core == null;
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				bool flag3 = ArcadePhysics.s_scene == null;
				bool flag4 = s_scene2._renderer == null;
				object obj7 = UnityEngine.Random.value;
				num6 = eggFloat._eggVal + eggFloat._val;
				object obj8 = num6 & -2147483649L;
				if ((nint)obj8 != 2139095040)
				{
					object obj9 = num6 & -2147483649L;
					if ((nint)obj9 <= 2139095040)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018739325Eh\"");
						if (num6 == -1f / 0f)
						{
							num6 = -3.4028235E+38f;
						}
						goto IL_0b56;
					}
				}
				num6 = 3.4028235E+38f;
				goto IL_0b56;
				IL_0b56:
				bool flag5 = _rapidusPool == null;
				Projectile projectile = _rapidusPool.SpawnAt(float5, this);
				EmitZone emitZone2;
				if ((object)projectile == null)
				{
					emitZone2 = null;
					goto IL_0b9f;
				}
				nint num8 = (nint)projectile;
				nint num9 = (nint)typeof(BloodRapidusProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1928 @ rdx_v41 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodRapidusProjectile>)+130]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1927 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1928 @ rdx_v41 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodRapidusProjectile>)+130]");
				object obj12;
				if (num10 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1927 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ rax_v110+FFFFFFF8+v1929 @ rax_v106*8]");
					if (0 == (nint)typeof(BloodRapidusProjectile))
					{
						obj12 = 1;
						goto IL_0b76;
					}
				}
				obj12 = 0;
				goto IL_0b76;
				IL_0b76:
				bool flag6 = obj12 == null;
				emitZone2 = null;
				if (!flag6)
				{
					emitZone2 = (EmitZone)(object)projectile;
				}
				goto IL_0b9f;
				IL_0b9f:
				if (emitZone2 != null && emitZone2._type != EmitZoneType.Edge)
				{
					Transform transform6 = ((Component)(object)emitZone2).transform;
					bool flag7 = (object)transform6 == null;
					transform6.SetParent(DirectionalDamageCointainer, worldPositionStays: true);
					((BloodRapidusProjectile)(object)emitZone2).OverrideWeaponData(_003CRapidus_003Ek__BackingField);
					bool flag8 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)(&value3));
					transform6.SetParent(null, worldPositionStays: true);
				}
				emitZone = (EmitZone)(emitZone + 1);
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num7) > System.Runtime.CompilerServices.Unsafe.As<EmitZone, UIntPtr>(ref emitZone));
			return;
		}
		goto IL_0896;
		IL_08e9:
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				renderer2 = s_scene3._renderer;
				if (s_scene3._renderer != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						Transform magnet = (Transform)(object)characterController._magnet;
						if ((object)characterController._magnet != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rbx_v14 (UnityEngine.Transform)+70]");
							Transform transform7 = (Transform)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rbx_v14 (UnityEngine.Transform)+70]");
							if ((nint)0 != 0)
							{
								float eggValue2 = default(float);
								float value4 = default(float);
								EggFloat eggFloat2 = new EggFloat(value4, eggValue2);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v15 (UnityEngine.Transform)+14]");
								eggValue2 = 0f * 0.01f;
								value4 = (float)(nint)((UnityEngine.Object)transform7).m_CachedPtr * 0.01f;
								if (eggFloat2 != null)
								{
									num2 = eggFloat2._eggVal + eggFloat2._val;
									object obj13 = num2 & -2147483649L;
									if ((nint)obj13 != 2139095040)
									{
										object obj14 = num2 & -2147483649L;
										if ((nint)obj14 <= 2139095040)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187392E9Bh\"");
											if (num2 == -1f / 0f)
											{
												num2 = -3.4028235E+38f;
											}
											goto IL_0953;
										}
									}
									num2 = 3.4028235E+38f;
									goto IL_0953;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0896;
		IL_09d7:
		if ((object)transform4 != null)
		{
			if (((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform4);
			}
			else
			{
				float2 value5 = default(float2);
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)(&value5));
				if ((object)_LineBottom != null)
				{
					transform5 = _LineBottom.transform;
					float num11 = eggFloat._eggVal + eggFloat._val;
					object obj15 = num11 & -2147483649L;
					if ((nint)obj15 != 2139095040)
					{
						object obj16 = num11 & -2147483649L;
						if ((nint)obj16 <= 2139095040)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187393007h\"");
							if (num11 == -1f / 0f)
							{
								num11 = -3.4028235E+38f;
							}
							goto IL_0a47;
						}
					}
					num11 = 3.4028235E+38f;
					goto IL_0a47;
				}
			}
		}
		goto IL_0896;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		_Image.enabled = false;
		if (_imageTween != null)
		{
			_imageTween.Kill();
		}
		if (_imageTween2 != null)
		{
			_imageTween2.Kill();
		}
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		if (_garlicPool != null)
		{
			_garlicPool.Cleanup();
		}
		if (_songPool != null)
		{
			_songPool.Cleanup();
		}
		if (_pentagramPool != null)
		{
			_pentagramPool.Cleanup();
		}
		if (_laurelPool != null)
		{
			_laurelPool.Cleanup();
		}
		if (_lancetPool != null)
		{
			_lancetPool.Cleanup();
		}
		if (_streamPool != null)
		{
			_streamPool.Cleanup();
		}
		if (_rapidusPool != null)
		{
			_rapidusPool.Cleanup();
		}
		ObjectPool moonExplosionPool = _moonExplosionPool;
		if ((object)_moonExplosionPool != null && ((UnityEngine.Object)moonExplosionPool).m_CachedPtr != (IntPtr)0)
		{
			_moonExplosionPool.ReleaseAll();
		}
	}

	protected override void OnStart()
	{
		//IL_01e2: Expected I, but got O
		//IL_0285: Expected I, but got O
		//IL_0316: Expected I, but got O
		//IL_03a7: Expected I, but got O
		//IL_0438: Expected I, but got O
		//IL_04c9: Expected I, but got O
		//IL_055a: Expected I, but got O
		//IL_05eb: Expected I, but got O
		//IL_067c: Expected I, but got O
		base.ResetFiringTimer();
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.BLOOD_GARLIC);
		BulletPool garlicPool = new BulletPool(projectilePrefab);
		_garlicPool = garlicPool;
		Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.BLOOD_SONG);
		BulletPool songPool = new BulletPool(projectilePrefab2);
		_songPool = songPool;
		Projectile projectilePrefab3 = _projectileFactory.GetProjectilePrefab(WeaponType.BLOOD_PENTAGRAM);
		BulletPool pentagramPool = new BulletPool(projectilePrefab3);
		_pentagramPool = pentagramPool;
		Projectile projectilePrefab4 = _projectileFactory.GetProjectilePrefab(WeaponType.BLOOD_LAUREL);
		BulletPool laurelPool = new BulletPool(projectilePrefab4);
		_laurelPool = laurelPool;
		Projectile projectilePrefab5 = _projectileFactory.GetProjectilePrefab(WeaponType.BLOOD_LANCET);
		BulletPool lancetPool = new BulletPool(projectilePrefab5);
		_lancetPool = lancetPool;
		Projectile projectilePrefab6 = _projectileFactory.GetProjectilePrefab(WeaponType.BLOOD_STREAM);
		BulletPool streamPool = new BulletPool(projectilePrefab6);
		_streamPool = streamPool;
		Projectile projectilePrefab7 = _projectileFactory.GetProjectilePrefab(WeaponType.BLOOD_RAPIDUS);
		BulletPool rapidusPool = new BulletPool(projectilePrefab7);
		_rapidusPool = rapidusPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1443 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_projectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_projectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene3.physics;
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1489 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+5C0]");
				ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				Collider collider3 = physics3.add.overlap(_garlicPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					ArcadePhysics physics4 = s_scene4.physics;
					GameManager core4 = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1511 @ r8_v32 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+5D0]");
					ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num4 = (nint)this;
					Collider collider4 = physics4.add.overlap(_songPool, core4.Enemies, collideCallback4, processCallback, callbackContext);
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene5 = ArcadePhysics.s_scene;
						ArcadePhysics physics5 = s_scene5.physics;
						GameManager core5 = GM.Core;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1533 @ r8_v35 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+5E0]");
						ArcadePhysicsCallback collideCallback5 = new ArcadePhysicsCallback(this, (IntPtr)0);
						nint num5 = (nint)this;
						Collider collider5 = physics5.add.overlap(_pentagramPool, core5.Enemies, collideCallback5, processCallback, callbackContext);
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene6 = ArcadePhysics.s_scene;
							ArcadePhysics physics6 = s_scene6.physics;
							GameManager core6 = GM.Core;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1555 @ r8_v38 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+5F0]");
							ArcadePhysicsCallback collideCallback6 = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num6 = (nint)this;
							Collider collider6 = physics6.add.overlap(_laurelPool, core6.Enemies, collideCallback6, processCallback, callbackContext);
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene7 = ArcadePhysics.s_scene;
								ArcadePhysics physics7 = s_scene7.physics;
								GameManager core7 = GM.Core;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+600]");
								ArcadePhysicsCallback collideCallback7 = new ArcadePhysicsCallback(this, (IntPtr)0);
								nint num7 = (nint)this;
								Collider collider7 = physics7.add.overlap(_lancetPool, core7.Enemies, collideCallback7, processCallback, callbackContext);
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene8 = ArcadePhysics.s_scene;
									ArcadePhysics physics8 = s_scene8.physics;
									GameManager core8 = GM.Core;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ r8_v44 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+350]");
									ArcadePhysicsCallback collideCallback8 = new ArcadePhysicsCallback(this, (IntPtr)0);
									nint num8 = (nint)this;
									Collider collider8 = physics8.add.overlap(_streamPool, core8.Enemies, collideCallback8, processCallback, callbackContext);
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene9 = ArcadePhysics.s_scene;
										ArcadePhysics physics9 = s_scene9.physics;
										GameManager core9 = GM.Core;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1621 @ r8_v47 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+610]");
										ArcadePhysicsCallback collideCallback9 = new ArcadePhysicsCallback(this, (IntPtr)0);
										nint num9 = (nint)this;
										Collider collider9 = physics9.add.overlap(_rapidusPool, core9.Enemies, collideCallback9, processCallback, callbackContext);
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

	protected virtual bool OnGarlicOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_018d: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_01aa;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									if ((object)_003CGarlic_003Ek__BackingField == null)
									{
										goto IL_017f;
									}
									float num = _003CGarlic_003Ek__BackingField.PPower();
									WeaponData currentWeaponData = _currentWeaponData;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									float num2 = default(float);
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num3;
								}
								goto IL_01aa;
							}
						}
					}
				}
			}
		}
		goto IL_017f;
		IL_017f:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01aa:
		return false;
	}

	protected unsafe virtual bool OnSongOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_021e: Expected I, but got O
		//IL_028c: Expected O, but got Ref
		//IL_0291->IL01e0: Incompatible stack heights: 1 vs 0
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_01e0;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								bool flag = component2.HasAlreadyHitObject(component);
								float num2 = default(float);
								float num = num2;
								if (!flag)
								{
									if ((object)_003CSong_003Ek__BackingField == null)
									{
										goto IL_01bc;
									}
									float num3 = _003CSong_003Ek__BackingField.PPower();
									WeaponData currentWeaponData = _currentWeaponData;
									if (_currentWeaponData != null)
									{
										HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
									}
									else
									{
										HitVfxType hitVfxType = HitVfxType.Default;
									}
									num = base.Knockback;
									nint num4 = (nint)component;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v461 @ rdx_v21 (Il2CppClass<ArcadeColliderType>)+3E8] (should have been resolved before IL gen)");
									float num5 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num5;
								}
								if (component2.CanExplode())
								{
									Transform transform = component.transform;
									if ((object)transform == null)
									{
										goto IL_01bc;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v19 (UnityEngine.Transform)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v19 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 _);
									object obj = default(object);
									component2.Explode((Vector2?)(object)(&obj));
								}
								goto IL_01e0;
							}
						}
					}
				}
			}
		}
		goto IL_01bc;
		IL_01bc:
		throw new NullReferenceException();
		IL_01e0:
		return false;
	}

	protected unsafe virtual bool OnPentagramOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_00ab: Expected I, but got O
		//IL_00b3: Expected I, but got O
		//IL_00c3: Expected O, but got I
		//IL_02a5: Expected I4, but got O
		//IL_00ff: Expected O, but got I
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_026a: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if (!component._003CIsDead_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject2 = default(GameObject);
			Projectile component2 = gameObject2.GetComponent<Projectile>();
			if ((object)component2 != null && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0)
			{
				nint num = (nint)typeof(BloodPentagramProjectile);
				nint num2 = (nint)component2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodPentagramProjectile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodPentagramProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v18+FFFFFFF8+v189 @ rax_v17*8]");
					if (0 == (nint)typeof(BloodPentagramProjectile))
					{
						if (((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0 && !component2.HasAlreadyHitObject(component))
						{
							object obj3 = default(object);
							bool flag = 0 < (nint)obj3;
							bool flag2 = !flag;
							object obj4 = (_003F?)component._003CResRosary_003Ek__BackingField & flag2;
							if (obj4 != null)
							{
								float num4 = component._maxHp - component._hp;
								WeaponData currentWeaponData = _currentWeaponData;
								bool flag3 = !(66f < num4);
								float num5 = 66f;
								if (!flag3)
								{
									num5 = num4;
								}
								HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
								component.GetDamaged(num5, showHitVfx, 0f, WeaponType.VOID, hasKb: false);
								float num6 = num5 + base._003CStatsInflictedDamage_003Ek__BackingField;
								base._003CStatsInflictedDamage_003Ek__BackingField = num6;
							}
							if (component2.CanExplode())
							{
								Transform transform = component.transform;
								Vector3 position = transform.position;
								object obj5 = default(object);
								component2.Explode((Vector2?)(object)(&obj5));
							}
						}
						goto IL_026f;
					}
				}
				InvalidCastException ex = new InvalidCastException();
				return (byte)(int)ex != 0;
			}
		}
		goto IL_026f;
		IL_026f:
		return false;
	}

	protected unsafe virtual bool OnLaurelOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0360: Expected O, but got Ref
		//IL_02f3: Expected I, but got O
		//IL_0365->IL0296: Incompatible stack heights: 1 vs 0
		EnemyController component;
		Projectile component2;
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0296;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								bool flag = component2.HasAlreadyHitObject(component);
								HitVfxType hitVfxType = HitVfxType.None;
								if (flag)
								{
									goto IL_029c;
								}
								if ((object)_003CLaurel_003Ek__BackingField != null)
								{
									float num = _003CLaurel_003Ek__BackingField.PPower();
									if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
									{
										float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
										float num3 = default(float);
										bool flag2 = !(10f > num3);
										float num4 = 10f;
										if (!flag2)
										{
											num4 = num3;
										}
										Weapon weapon = _003CLaurel_003Ek__BackingField;
										if ((object)_003CLaurel_003Ek__BackingField != null)
										{
											WeaponData currentWeaponData = weapon._currentWeaponData;
											if (weapon._currentWeaponData != null)
											{
												WeaponData currentWeaponData2 = _currentWeaponData;
												float num5 = num4 * num3;
												float num6 = num5 * (float)currentWeaponData._003Camount_003Ek__BackingField;
												if (_currentWeaponData != null)
												{
													hitVfxType = currentWeaponData2._003ChitVFX_003Ek__BackingField;
												}
												else
												{
													hitVfxType = HitVfxType.Default;
												}
												nint num7 = (nint)component;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v488 @ rdx_v22 (Il2CppClass<ArcadeColliderType>)+3E8] (should have been resolved before IL gen)");
												float num8 = num6 + base._003CStatsInflictedDamage_003Ek__BackingField;
												base._003CStatsInflictedDamage_003Ek__BackingField = num8;
												goto IL_029c;
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
		goto IL_0272;
		IL_0296:
		return false;
		IL_0272:
		throw new NullReferenceException();
		IL_029c:
		if (component2.CanExplode())
		{
			Transform transform = component.transform;
			if ((object)transform == null)
			{
				goto IL_0272;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v19 (UnityEngine.Transform)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v19 (UnityEngine.Transform)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			object obj = default(object);
			component2.Explode((Vector2?)(object)(&obj));
		}
		goto IL_0296;
	}

	protected virtual bool OnLancetOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_019d: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_01ba;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									if ((object)_003CLancet_003Ek__BackingField == null)
									{
										goto IL_018f;
									}
									float num = _003CLancet_003Ek__BackingField.PPower();
									WeaponData currentWeaponData = _currentWeaponData;
									object obj = default(object);
									float num2 = (float)obj + 0.5f;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num3;
								}
								goto IL_01ba;
							}
						}
					}
				}
			}
		}
		goto IL_018f;
		IL_018f:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01ba:
		return false;
	}

	protected unsafe virtual bool OnTPRapidusOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01ef: Expected I, but got O
		//IL_027d: Expected O, but got Ref
		//IL_0282->IL01d7: Incompatible stack heights: 1 vs 0
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_01d7;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									if ((object)_003CRapidus_003Ek__BackingField == null)
									{
										goto IL_01b3;
									}
									float num = _003CRapidus_003Ek__BackingField.PPower();
									WeaponData currentWeaponData = _currentWeaponData;
									if (_currentWeaponData != null)
									{
										HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
									}
									else
									{
										HitVfxType hitVfxType = HitVfxType.Default;
									}
									float knockback = base.Knockback;
									nint num2 = (nint)component;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v470 @ rdx_v15 (Il2CppClass<ArcadeColliderType>)+3E8] (should have been resolved before IL gen)");
									object obj = default(object);
									float num3 = (float)obj + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num3;
									if (component2.CanExplode())
									{
										Transform transform = component.transform;
										if ((object)transform == null)
										{
											goto IL_01b3;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v24 (UnityEngine.Transform)+10]");
										bool flag = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v24 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out Vector3 _);
										object obj2 = default(object);
										component2.Explode((Vector2?)(object)(&obj2));
									}
								}
								goto IL_01d7;
							}
						}
					}
				}
			}
		}
		goto IL_01b3;
		IL_01d7:
		return false;
		IL_01b3:
		throw new NullReferenceException();
	}

	private void _003CFirePentagram_003Eb__57_0()
	{
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_024e: Invalid comparison between F4 and I4
		//IL_0454: Invalid comparison between F4 and I4
		//IL_0306: Expected I, but got O
		//IL_0314: Expected I, but got O
		//IL_0324: Expected O, but got I
		//IL_03a4: Expected O, but got I4
		//IL_04e5: Expected O, but got I
		//IL_0360: Expected O, but got I
		//IL_03b1: Expected O, but got I
		//IL_0396: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		nint num = (nint)characterController;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+5A0]");
		Weapon weapon = (Weapon)0;
		float num2 = characterController.PAmount();
		float num3 = default(float);
		bool flag = num3 > 10f;
		float num4 = 10f;
		if (!flag)
		{
			num4 = num3;
		}
		Weapon weapon2 = _003CPentagram_003Ek__BackingField;
		WeaponData currentWeaponData = weapon2._currentWeaponData;
		float num5 = (float)currentWeaponData._003Camount_003Ek__BackingField * 3f;
		float num6 = num5 + num4;
		float num7 = (float)Math.PI * 2f / num6;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		MagnetZone magnet = characterController2._magnet;
		EggFloat radius = magnet.Radius;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat = new EggFloat(value, eggValue);
		eggValue = radius._eggVal * 0.01f;
		value = radius._val * 0.01f;
		float eggValue2 = default(float);
		float value2 = default(float);
		EggFloat eggFloat2 = new EggFloat(value2, eggValue2);
		eggValue2 = eggFloat._eggVal * 0.75f;
		value2 = eggFloat._val * 0.75f;
		float num8 = eggFloat2._eggVal + eggFloat2._val;
		object obj = num8 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num8 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873957C3h\"");
				if (num8 == -1f / 0f)
				{
					num8 = -3.4028235E+38f;
				}
				goto IL_049d;
			}
		}
		num8 = 3.4028235E+38f;
		goto IL_049d;
		IL_050b:
		BloodPentagramProjectile bloodPentagramProjectile = default(BloodPentagramProjectile);
		bool flag2 = (object)bloodPentagramProjectile == null;
		float2 float5 = default(float2);
		weapon = (Weapon)float5;
		ArcadeSprite typeFromHandle = (ArcadeSprite)(object)typeof(UnityEngine.Object);
		Weapon weapon3;
		if (!flag2)
		{
			bool flag3 = ((UnityEngine.Object)bloodPentagramProjectile).m_CachedPtr == (IntPtr)0;
			weapon = (Weapon)float5;
			typeFromHandle = (ArcadeSprite)(object)typeof(UnityEngine.Object);
			if (!flag3)
			{
				weapon = _003CPentagram_003Ek__BackingField;
				bloodPentagramProjectile.OverrideWeaponData(_003CPentagram_003Ek__BackingField);
				weapon3 = null;
				typeFromHandle = bloodPentagramProjectile;
			}
		}
		int num9 = num9 + 1;
		bool flag4 = num6 > (float)num9;
		Projectile projectile2 = default(Projectile);
		Projectile projectile = projectile2;
		if (!flag4)
		{
			return;
		}
		goto IL_0278;
		IL_04ce:
		object obj3;
		bool flag5 = obj3 == null;
		nint num10;
		weapon3 = (Weapon)num10;
		bloodPentagramProjectile = null;
		float5 = (float2)typeof(BloodPentagramProjectile);
		if (!flag5)
		{
			weapon3 = (Weapon)num10;
			bloodPentagramProjectile = (BloodPentagramProjectile)projectile2;
			float5 = (float2)typeof(BloodPentagramProjectile);
		}
		goto IL_050b;
		IL_0278:
		float num11 = (float)num9 * num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num12 = (float)num9 * num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 float6 = default(float2);
		projectile2 = _pentagramPool.SpawnAt(float6, this, num9);
		if ((object)projectile2 == null)
		{
			weapon3 = this;
			bloodPentagramProjectile = null;
			float5 = float6;
			goto IL_050b;
		}
		num10 = (nint)projectile2;
		nint num13 = (nint)typeof(BloodPentagramProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodPentagramProjectile>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodPentagramProjectile>)+130]");
		if (num14 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v45+FFFFFFF8+v617 @ rax_v41*8]");
			if (0 == (nint)typeof(BloodPentagramProjectile))
			{
				obj3 = 1;
				goto IL_04ce;
			}
		}
		obj3 = 0;
		goto IL_04ce;
		IL_049d:
		float num15 = renderer.height * 0.45f;
		if (!(num8 > num15))
		{
			goto IL_050b;
		}
		typeFromHandle = ((Equipment)this)._003COwner_003Ek__BackingField;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		if (num6 > 0f)
		{
			num9 = 0;
			projectile = null;
			goto IL_0278;
		}
	}
}
