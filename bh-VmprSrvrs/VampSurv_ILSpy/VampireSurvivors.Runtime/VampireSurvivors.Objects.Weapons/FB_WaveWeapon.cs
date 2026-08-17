using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_WaveWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public FB_WaveWeapon _003C_003E4__this;

		public bool isMoving;
	}

	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_003Eb__0()
		{
			//IL_01d2: Expected O, but got I4
			//IL_00a8->IL019b: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL019b: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL019b: Incompatible stack heights: 1 vs 0
			//IL_0134->IL019b: Incompatible stack heights: 1 vs 0
			//IL_0163->IL019b: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass14_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass14_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						FB_WaveWeapon fB_WaveWeapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)((Equipment)fB_WaveWeapon)._003COwner_003Ek__BackingField != null)
						{
							float2 position = ((Equipment)fB_WaveWeapon)._003COwner_003Ek__BackingField.position;
							_003C_003Ec__DisplayClass14_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								FB_WaveWeapon fB_WaveWeapon2 = obj4._003C_003E4__this;
								if ((object)obj4._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									BulletPool pool = default(BulletPool);
									bool isCharged = default(bool);
									Projectile projectile = obj3._003C_003E4__this.CustomFireOneProjectile(pos, localIndex, fB_WaveWeapon2._targetTransform, pool, isCharged);
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

	private float _mainCooldownTimer;

	private float _chargeCooldownTimer;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleEmitterManager _chargingParticlesManager;

	private ParticleSystem _chargingPfxEmitter;

	private PhaserSprite _chargingBall;

	private GravityWellConfig _gravityWellConfig;

	private PhaserSprite _smokeBoom;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_00f2: Expected O, but got I4
		//IL_00a5->IL02fc: Incompatible stack heights: 1 vs 0
		//IL_00d8->IL02fc: Incompatible stack heights: 1 vs 0
		//IL_0110->IL02fc: Incompatible stack heights: 1 vs 0
		//IL_0143->IL02fc: Incompatible stack heights: 1 vs 0
		//IL_016f->IL02fc: Incompatible stack heights: 1 vs 0
		//IL_03a1->IL02fc: Incompatible stack heights: 2 vs 0
		//IL_01d8->IL02fc: Incompatible stack heights: 2 vs 0
		//IL_0230->IL02fc: Incompatible stack heights: 2 vs 0
		//IL_0283->IL02fc: Incompatible stack heights: 3 vs 0
		//IL_02b6->IL02fc: Incompatible stack heights: 3 vs 0
		//IL_02de->IL02fc: Incompatible stack heights: 3 vs 0
		base.InitWeapon(characterController, weaponType);
		_mainCooldownTimer = 0f;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("fbSmokeBoom", 1, 8, "firstBlood", num);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite smokeBoom = RenderingExtensions.AddPhaserSprite(gameObject, pos, "firstBlood", "fbSmokeBoom1");
			_smokeBoom = smokeBoom;
			if ((object)_smokeBoom != null)
			{
				PhaserSprite phaserSprite = _smokeBoom.setAlpha(0.85f);
				if ((object)_smokeBoom != null)
				{
					PhaserSprite phaserSprite2 = _smokeBoom.setScale(2f, (float?)(object)0);
					if ((object)_smokeBoom != null)
					{
						PhaserSprite phaserSprite3 = _smokeBoom.setVisible(visible: false);
						if ((object)_smokeBoom != null)
						{
							Transform transform2 = _smokeBoom.transform;
							if ((object)transform2 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v868 @ rcx_v36 (Il2CppMethodInfo)+38]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
								}
								Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)0, true);
								PhaserSprite smokeBoom2 = _smokeBoom;
								if ((object)_smokeBoom != null && (object)smokeBoom2._spriteAnimation != null)
								{
									bool startRandomFrame = default(bool);
									Action onComplete = default(Action);
									bool autoSetAnimation = default(bool);
									smokeBoom2._spriteAnimation.AddAnimation("Smoke", animationFrames, 24, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
									Transform transform3 = base.transform;
									if ((object)transform3 != null)
									{
										bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
										GameObject gameObject2 = base.gameObject;
										PhaserSprite chargingBall = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "Burst2");
										_chargingBall = chargingBall;
										if ((object)_chargingBall != null)
										{
											PhaserSprite phaserSprite4 = _chargingBall.setVisible(visible: false);
											if ((object)_chargingBall != null)
											{
												PhaserSprite phaserSprite5 = _chargingBall.setTint(16755200u);
												Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 665 Invalid \"Jump target not found in method: 0x1873F03C0\"");
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

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0168: Expected O, but got I4
		//IL_0181: Expected O, but got Ref
		//IL_019b: Expected native int or pointer, but got O
		//IL_01b5: Expected O, but got I
		//IL_01d5: Expected O, but got Ref
		//IL_01ef: Expected native int or pointer, but got O
		//IL_0209: Expected O, but got I
		//IL_0229: Expected O, but got Ref
		//IL_0243: Expected native int or pointer, but got O
		//IL_08df: Expected O, but got I4
		//IL_0268: Expected O, but got Ref
		//IL_0282: Expected native int or pointer, but got O
		//IL_0919: Expected O, but got I
		//IL_02ba: Expected O, but got Ref
		//IL_02e1: Expected O, but got I
		//IL_02fb: Expected native int or pointer, but got O
		//IL_0953: Expected O, but got I
		//IL_0333: Expected O, but got Ref
		//IL_035a: Expected O, but got I
		//IL_0374: Expected native int or pointer, but got O
		//IL_039c: Expected O, but got I
		//IL_098d: Expected O, but got I
		//IL_0514: Expected O, but got Ref
		//IL_052e: Expected native int or pointer, but got O
		//IL_0560: Expected O, but got Ref
		//IL_057a: Expected native int or pointer, but got O
		//IL_05ac: Expected O, but got Ref
		//IL_05c6: Expected native int or pointer, but got O
		//IL_05fe: Expected O, but got Ref
		//IL_0618: Expected native int or pointer, but got O
		//IL_0650: Expected O, but got Ref
		//IL_0689: Expected native int or pointer, but got O
		//IL_06c1: Expected O, but got Ref
		//IL_06fa: Expected native int or pointer, but got O
		//IL_079e: Expected O, but got I
		//IL_0b73: Expected O, but got I
		//IL_077a->IL08a3: Incompatible stack heights: 1 vs 0
		//IL_0b18->IL08a3: Incompatible stack heights: 2 vs 0
		//IL_07c0->IL08a3: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			ParticleEmitterManager particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
			_particlesManager = particlesManager;
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
						((List<object>)(object)list).AddWithResize((object)"HitCloud1");
					}
					else
					{
						int size = list._size + 1;
						list._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					if (particleSystemConfig != null)
					{
						particleSystemConfig._frame = list;
						ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
						particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 0f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
						particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 0f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
						particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(-100f, 100f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
						_ = 0;
						particleSystemConfig._speedX = (ParticleSystem.MinMaxCurve?)(object)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(-50f, 50f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
						particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304));
						_ = 0;
						_ = 4;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
						particleSystemConfig._quantity = (int?)(object)0;
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
						particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 336));
						_ = 0;
						_ = 1;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
						particleSystemConfig._blendMode = (BlendMode?)(object)0;
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0.35f, 0f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
						obj = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
						particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
						_ = 0;
						particleSystemConfig._on = false;
						Transform parent = base.transform;
						ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, parent, "WavePfxEmitter");
						_pfxEmitter = pfxEmitter;
						Transform transform = _pfxEmitter.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1537 @ rax_v65 (UnityEngine.Transform)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1537 @ rax_v65 (UnityEngine.Transform)+10]");
						Vector3 value = default(Vector3);
						Transform.set_localPosition_Injected((IntPtr)0, ref value);
						GameObject gameObject2 = base.gameObject;
						ParticleEmitterManager chargingParticlesManager = gameObject2.AddComponent<ParticleEmitterManager>();
						_chargingParticlesManager = chargingParticlesManager;
						ParticleSystemConfig config = new ParticleSystemConfig("vfx");
						List<string> list2 = new List<string>();
						int version2 = list2._version + 1;
						list2._version = version2;
						string[] items2 = list2._items;
						if (list2._size >= items2.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"HitCloud1");
						}
						else
						{
							int size2 = list2._size + 1;
							list2._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						minMaxCurve = new ParticleSystem.MinMaxCurve(400f);
						_ = 0;
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 368));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 0f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 400));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 0f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(0f, 0f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1B0]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1C0]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 464));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(0f, 0f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1D0]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 496));
						_ = 0;
						_ = 4;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
						_ = 0;
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0f, 0.5f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 528));
						_ = 0;
						_ = 1;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
						_ = 0;
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(0.35f, 0f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+220]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+88]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+98]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A8]");
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 16755200;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
						_ = 0;
						GravityWellConfig gravityWellConfig = new GravityWellConfig();
						Transform transform2 = base.transform;
						if ((object)transform2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v107 (UnityEngine.Transform)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v107 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
							_ = 0;
							_ = 1;
							if (gravityWellConfig != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
								gravityWellConfig._x = (float?)(object)0;
								Transform transform3 = base.transform;
								if ((object)transform3 != null)
								{
									bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
									gravityWellConfig._y = (float?)(object)0;
									gravityWellConfig._power = 1f;
									_gravityWellConfig = gravityWellConfig;
									bool flag4 = (object)_chargingParticlesManager == null;
									GravityWell gravityWell = _chargingParticlesManager.CreateGravityWell(_gravityWellConfig);
									Transform parent2 = base.transform;
									bool flag5 = (object)_chargingParticlesManager == null;
									ParticleSystem chargingPfxEmitter = _chargingParticlesManager.CreateEmitter(config, parent2, "WaveChargingPfxEmitter");
									_chargingPfxEmitter = chargingPfxEmitter;
									bool flag6 = (object)_chargingPfxEmitter == null;
									Transform transform4 = _chargingPfxEmitter.transform;
									bool flag7 = (object)transform4 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v914 @ rax_v126 (UnityEngine.Transform)+10]");
									bool flag8 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v914 @ rax_v126 (UnityEngine.Transform)+10]");
									Transform.set_localPosition_Injected((IntPtr)0, ref ret);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_04bb: Expected I, but got O
		//IL_04fb: Expected O, but got I
		//IL_052b: Invalid comparison between F4 and O
		//IL_054a: Invalid comparison between F4 and I4
		//IL_055d: Expected O, but got I4
		//IL_004f: Invalid comparison between I4 and F4
		//IL_0095: Expected O, but got I
		//IL_00e5: Expected O, but got I
		//IL_073d: Expected O, but got Ref
		//IL_038f: Expected O, but got I4
		//IL_063d->IL0477: Incompatible stack heights: 1 vs 0
		//IL_00c1->IL0477: Incompatible stack heights: 1 vs 0
		//IL_069d->IL0477: Incompatible stack heights: 2 vs 0
		//IL_0109->IL0477: Incompatible stack heights: 2 vs 0
		//IL_016c->IL0477: Incompatible stack heights: 2 vs 0
		//IL_02eb->IL0477: Incompatible stack heights: 10 vs 0
		//IL_0356->IL0477: Incompatible stack heights: 11 vs 0
		//IL_03ac->IL0772: Incompatible stack heights: 11 vs 0
		//IL_03c7->IL0772: Incompatible stack heights: 11 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InternalUpdate();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v31 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			object obj3 = characterController._currentDirection - Vector2.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (VampireSurvivors.Objects.Characters.CharacterController)+174]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
			object obj4 = num3 - 0;
			object obj5 = obj4 * obj4;
			object obj6 = obj3 * obj3;
			object obj7 = obj5 + obj6;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7);
			float num4 = 9.9999994E-11f - (float)obj7;
			bool flag2 = num4 == 0f;
			object obj8 = flag | flag2;
			if (obj8 == null)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num5 = deltaTime * 1000f;
				if (0f > (_mainCooldownTimer -= num5))
				{
					_mainCooldownTimer = 0f;
				}
				float deltaTime2 = PauseSystem.DeltaTime;
				float num6 = deltaTime2 * 1000f;
				float chargeCooldownTimer = num6 + _chargeCooldownTimer;
				_chargeCooldownTimer = chargeCooldownTimer;
				GravityWellConfig gravityWellConfig = _gravityWellConfig;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					_ = 0;
					_ = 1;
					if (_gravityWellConfig != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
						gravityWellConfig._x = (float?)(object)0;
						GravityWellConfig gravityWellConfig2 = _gravityWellConfig;
						Transform transform2 = base.transform;
						if ((object)transform2 != null)
						{
							bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
							_ = 0;
							_ = 1;
							if (_gravityWellConfig != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
								gravityWellConfig2._y = (float?)(object)0;
								GravityWellConfig gravityWellConfig3 = _gravityWellConfig;
								if (_gravityWellConfig != null)
								{
									gravityWellConfig3._power = 1f;
									object chargingPfxEmitter = _chargingPfxEmitter;
									_ = 0;
									_ = 0;
									_ = 0;
									_ = 0;
									_ = 0;
									_ = 0;
									Transform transform3 = base.transform;
									if ((object)transform3 != null)
									{
										bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
										Vector2 insideUnitCircle = UnityEngine.Random.insideUnitCircle;
										_ = 1;
										_ = 1;
										bool flag6 = (object)_chargingPfxEmitter == null;
										object obj9 = default(object);
										obj = obj9;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r14_v16 (System.Object)+10]");
										bool flag7 = (nint)0 == 0;
										object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r14_v16 (System.Object)+10]");
										ParticleSystem.Emit_Injected((IntPtr)0, ref *(ParticleSystem.EmitParams*)obj10, 1);
										bool flag8 = (object)_chargingBall == null;
										PhaserSprite phaserSprite = _chargingBall.setVisible(visible: true);
										bool flag9 = (object)_chargingBall == null;
										Transform transform4 = _chargingBall.transform;
										bool flag10 = (object)transform4 == null;
										Vector3 localEulerAngles = transform4.localEulerAngles;
										float deltaTime3 = PauseSystem.DeltaTime;
										float num7 = deltaTime3 * 960f;
										float num8 = num7 + localEulerAngles.z;
										_chargingBall.angle = num8;
										float num9 = base.PDuration();
										WeaponData currentWeaponData = _currentWeaponData;
										bool flag11 = _currentWeaponData == null;
										_ = currentWeaponData._003Cduration_003Ek__BackingField;
										bool flag12 = (object)currentWeaponData._003Cduration_003Ek__BackingField == null;
										if (_currentWeaponData != null)
										{
											bool flag13 = (object)currentWeaponData._003Cduration_003Ek__BackingField == null;
											float num10 = num8;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A4]");
											float num11 = num10 / 0f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A4]");
											float num12 = 0f / num11;
											if ((object)_chargingBall != null)
											{
												float num13 = _chargeCooldownTimer / num12;
												float xScale = num13 + num13;
												PhaserSprite phaserSprite2 = _chargingBall.setScale(xScale, (float?)(object)0);
												if (!(_chargeCooldownTimer < num12))
												{
													base.Fire();
													_chargeCooldownTimer = 0f;
												}
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
			else
			{
				float deltaTime4 = PauseSystem.DeltaTime;
				float num14 = deltaTime4 * 1000f;
				_chargeCooldownTimer = 0f;
				float num15 = (_mainCooldownTimer = num14 + _mainCooldownTimer);
				if ((object)_chargingBall != null)
				{
					PhaserSprite phaserSprite3 = _chargingBall.setVisible(visible: false);
					float num16 = base.PInterval();
					if (!(_mainCooldownTimer < num15))
					{
						base.Fire();
						_mainCooldownTimer = 0f;
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_02ca: Expected I, but got O
		//IL_030a: Expected O, but got I
		//IL_033a: Invalid comparison between F4 and O
		//IL_0359: Invalid comparison between F4 and I4
		//IL_0070: Invalid comparison between O and F4
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		//IL_0267: Invalid comparison between O and F4
		//IL_00a2: Invalid comparison between O and F4
		//IL_0292: Expected F4, but got O
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_01db: Expected O, but got I4
		//IL_01db: Expected I4, but got O
		//IL_01f5: Expected O, but got F4
		_003C_003Ec__DisplayClass14_0 obj = new _003C_003Ec__DisplayClass14_0();
		obj._003C_003E4__this = this;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v8 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		object obj2 = characterController._currentDirection - Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v6 (VampireSurvivors.Objects.Characters.CharacterController)+174]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		object obj3 = num3 - 0;
		object obj4 = obj3 * obj3;
		object obj5 = obj2 * obj2;
		object obj6 = obj4 + obj5;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
		float num4 = 9.9999994E-11f - (float)obj6;
		bool flag2 = num4 == 0f;
		bool isMoving = flag | flag2;
		obj.isMoving = isMoving;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		BulletPool bulletPool = default(BulletPool);
		bool flag3 = default(bool);
		Projectile projectile = CustomFireOneProjectile(vector, 0, _targetTransform, bulletPool, flag3);
		float num5 = base.PAmount();
		bool flag4 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		Vector2 vector2 = vector;
		if (!flag4)
		{
			float num6 = base.PAmount();
			bool flag5 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			vector2 = vector;
			if (!flag5)
			{
				int num7 = 1;
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj7 = num7 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj7 <= 0)
					{
						Vector2 playerPos = base.PlayerPos;
						Projectile projectile2 = CustomFireOneProjectile(playerPos, num7, _targetTransform, bulletPool, flag3);
						vector2 = playerPos;
					}
					else
					{
						_003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass14_1();
						CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 = obj;
						CS_0024_003C_003E8__locals9.localIndex = num7;
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_01d2: Expected O, but got I4
							//IL_00a8->IL019b: Incompatible stack heights: 1 vs 0
							//IL_00d7->IL019b: Incompatible stack heights: 1 vs 0
							//IL_00f9->IL019b: Incompatible stack heights: 1 vs 0
							//IL_0134->IL019b: Incompatible stack heights: 1 vs 0
							//IL_0163->IL019b: Incompatible stack heights: 1 vs 0
							_003C_003Ec__DisplayClass14_0 obj9 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj9._003C_003E4__this != null)
							{
								GameObject gameObject = obj9._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag7 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj10 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj10 == null)
									{
										return;
									}
									_003C_003Ec__DisplayClass14_0 obj11 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null)
									{
										FB_WaveWeapon fB_WaveWeapon = obj11._003C_003E4__this;
										if ((object)obj11._003C_003E4__this != null && (object)((Equipment)fB_WaveWeapon)._003COwner_003Ek__BackingField != null)
										{
											float2 position2 = ((Equipment)fB_WaveWeapon)._003COwner_003Ek__BackingField.position;
											_003C_003Ec__DisplayClass14_0 obj12 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null)
											{
												FB_WaveWeapon fB_WaveWeapon2 = obj12._003C_003E4__this;
												if ((object)obj12._003C_003E4__this != null)
												{
													Vector2 pos = default(Vector2);
													BulletPool pool = default(BulletPool);
													bool isCharged = default(bool);
													Projectile projectile3 = obj11._003C_003E4__this.CustomFireOneProjectile(pos, CS_0024_003C_003E8__locals9.localIndex, fB_WaveWeapon2._targetTransform, pool, isCharged);
													return;
												}
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						float num8 = (float)num7 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						float num9 = num8 * 0.001f;
						Timer lastShotTimer = Timers.Register(num9, onComplete, null, isLooped: false, (byte)(int)bulletPool != 0, (MonoBehaviour)flag3, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
						vector2 = (Vector2)num9;
					}
					num7++;
					float num10 = base.PAmount();
				}
				while ((nint)vector2 > num7);
			}
		}
		float num11 = base.PInterval();
		float num12 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj8 = num12 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num13 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			ResetFiringTimer();
		}
		bool flag6 = default(bool);
		if (!flag6)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public unsafe Projectile CustomFireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null, bool isCharged = false)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0416: Expected F4, but got I
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Expected O, but got Unknown
		//IL_0469: Expected I, but got O
		//IL_00c4: Expected F4, but got I
		//IL_00e8: Expected I, but got O
		//IL_00f0: Expected I, but got O
		//IL_0100: Expected O, but got I
		//IL_0138: Expected O, but got I
		//IL_09c6: Expected I, but got O
		//IL_09ce: Expected I, but got O
		//IL_09de: Expected O, but got I
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Expected O, but got Unknown
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Expected O, but got Unknown
		//IL_0171: Expected O, but got I
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_0570: Expected O, but got I
		//IL_05a9: Expected O, but got I
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Expected O, but got Unknown
		//IL_0231: Expected O, but got I4
		//IL_07f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Expected O, but got Unknown
		//IL_0aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aef: Expected O, but got Unknown
		//IL_08d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dc: Expected O, but got Unknown
		//IL_0bdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be0: Expected O, but got Unknown
		//IL_0986: Unknown result type (might be due to invalid IL or missing references)
		//IL_098b: Expected O, but got Unknown
		//IL_0548->IL09b8: Incompatible stack heights: 2 vs 1
		//IL_0911->IL0bfc: Incompatible stack heights: 11 vs 0
		//IL_0bfc->IL0bfc: Incompatible stack heights: 11 vs 0
		//IL_03dc->IL0bfc: Incompatible stack heights: 21 vs 0
		object obj2 = default(object);
		object obj = obj2 - 392;
		BulletPool bulletPool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, bulletPool);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			_ = 0;
			_ = 1056964608;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B8]");
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			Vector3 ret;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_Explosion1, 500f, 10, 0f, (float?)bulletPool, rate, detune, loop);
				Transform transform = projectile.AimForNearestEnemy();
				nint num = (nint)typeof(FB_WaveProjectile);
				nint num2 = (nint)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_WaveProjectile>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_WaveProjectile>)+130]");
				bool flag = num3 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v96+FFFFFFF8+v497 @ rax_v95*8]");
				bool flag2 = 0 != (nint)typeof(FB_WaveProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_WaveProjectile>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v96+FFFFFFF8+v797 @ rcx_v67*8]");
				object obj6 = 0 - typeof(FB_WaveProjectile);
				bool flag3 = obj6 == null;
				bool flag4 = !flag3;
				Projectile projectile2 = null;
				if (!flag4)
				{
					projectile2 = projectile;
				}
				((FB_WaveProjectile)projectile2).MakeChargedProjectile();
				bool flag5 = projectile.body == null;
				ParticleSystem pfxEmitter = _pfxEmitter;
				_ = 0;
				_ = 0;
				Transform transform2 = base.transform;
				bool flag6 = (object)transform2 == null;
				bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
				_ = 257;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9590");
				_ = 1;
				bool flag8 = (object)_pfxEmitter == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
				_ = 0;
				obj = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				bool flag9 = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
				object obj7 = obj - 16;
				ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitter).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj7, 5);
				object pfxEmitter2 = _pfxEmitter;
				_ = 0;
				_ = 0;
				Transform transform3 = base.transform;
				bool flag10 = (object)transform3 == null;
				bool flag11 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
				_ = 257;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9590");
				_ = 1;
				bool flag12 = (object)_pfxEmitter == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ r14_v31 (System.Object)+10]");
				bool flag13 = (nint)0 == 0;
				object obj8 = obj + 128;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ r14_v31 (System.Object)+10]");
				ParticleSystem.Emit_Injected((IntPtr)0, ref *(ParticleSystem.EmitParams*)obj8, 5);
				if (index == 0)
				{
					bool flag14 = (object)_smokeBoom == null;
					PhaserSprite phaserSprite = _smokeBoom.setVisible(visible: true);
					PhaserSprite smokeBoom = _smokeBoom;
					bool flag15 = (object)_smokeBoom == null;
					bool flag16 = (object)smokeBoom._spriteAnimation == null;
					smokeBoom._spriteAnimation.SetAnimation("Smoke");
					bool flag17 = (object)_smokeBoom == null;
					Transform transform4 = _smokeBoom.transform;
					Transform transform5 = projectile.transform;
					bool flag18 = (object)transform5 == null;
					bool flag19 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
					Transform.get_rotation_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Quaternion*)(&ret));
					bool flag20 = (object)transform4 == null;
					bool flag21 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					object obj9 = obj + 272;
					Transform.set_rotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Quaternion*)obj9);
					bool flag22 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
					float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					bool flag23 = (object)_smokeBoom == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
				PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_EnemyHit, 500f, 10, 0f, (float?)bulletPool, rate, detune, loop);
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				bool flag24 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
				object obj10 = obj + 432;
				_ = characterController._lastMovementDirection;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
				nint num4 = (nint)projectile;
				if (!IsHoming)
				{
					float projectileSpeed = projectile.ProjectileSpeed;
					Vector2 lastMovementDirection = characterController._lastMovementDirection;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B4]");
					object obj11 = lastMovementDirection * 0;
					Vector2 lastMovementDirection2 = characterController._lastMovementDirection;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
					float2 velocity = (float2)(lastMovementDirection2 * 0);
					BaseBody body = projectile.body;
					bool flag25 = projectile.body == null;
					body._velocity = velocity;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B4]");
					float angle = 0f * 57.29578f;
					projectile.angle = angle;
				}
				else
				{
					Transform transform6 = projectile.AimForNearestEnemy();
				}
				nint num5 = (nint)typeof(FB_WaveProjectile);
				nint num6 = (nint)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rcx_v39 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_WaveProjectile>)+130]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rcx_v39 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_WaveProjectile>)+130]");
				bool flag26 = num7 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ rax_v48+FFFFFFF8+v793 @ rax_v47*8]");
				bool flag27 = 0 != (nint)typeof(FB_WaveProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rcx_v39 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_WaveProjectile>)+130]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ rax_v48+FFFFFFF8+v860 @ rdx_v25*8]");
				object obj15 = 0 - typeof(FB_WaveProjectile);
				bool flag28 = obj15 == null;
				bool flag29 = !flag28;
				Projectile projectile3 = null;
				if (!flag29)
				{
					projectile3 = projectile;
				}
				((FB_WaveProjectile)projectile3).MakeBasicProjectile();
				ParticleSystem pfxEmitter3 = _pfxEmitter;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				Transform transform7 = base.transform;
				bool flag30 = (object)transform7 == null;
				bool flag31 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, out ret);
				_ = 257;
				bool flag32 = (object)_pfxEmitter == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
				_ = 0;
				bool flag33 = ((UnityEngine.Object)pfxEmitter3).m_CachedPtr == (IntPtr)0;
				object obj16 = obj + 128;
				ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitter3).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj16, 5);
				Transform pfxEmitter4 = (Transform)(object)_pfxEmitter;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				Transform transform8 = base.transform;
				bool flag34 = (object)transform8 == null;
				bool flag35 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform8).m_CachedPtr, out ret);
				bool flag36 = (object)_pfxEmitter == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
				_ = 0;
				object obj17 = default(object);
				obj = obj17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
				_ = 0;
				bool flag37 = ((UnityEngine.Object)pfxEmitter4).m_CachedPtr == (IntPtr)0;
				object obj18 = obj - 16;
				ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitter4).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj18, 5);
			}
		}
		else
		{
			projectile = null;
		}
		return projectile;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_bonusBounces = 3;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0175: Expected I4, but got O
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
						goto IL_0192;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							FB_WaveProjectile component2 = gameObject2.GetComponent<FB_WaveProjectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									bool flag = !component2.IsCharged;
									object obj2 = default(object);
									object obj = obj2 * obj2;
									float num3 = (flag ? 1f : 2.5f);
									float damage = num3 * (float)obj;
									base.DealDamage(component, damage);
								}
								goto IL_0192;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0192:
		return false;
	}
}
