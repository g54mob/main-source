using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KatanaProjectile_ScatteredPetals : Projectile
{
	private sealed class _003CDoSlash_003Ed__47(int _003C_003E1__state) : IEnumerator<YieldInstruction>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private YieldInstruction _003C_003E2__current;

		public EME_KatanaProjectile_ScatteredPetals _003C_003E4__this;

		public MeshRenderer meshRen;

		public MaterialPropertyBlock block;

		public MeshRenderer lightBeamMeshRen;

		public MaterialPropertyBlock lightBeamBlock;

		private float _003CdurationSeconds_003E5__2;

		private float _003Celapsed_003E5__3;

		YieldInstruction IEnumerator<YieldInstruction>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_00c0: Expected I4, but got I8
			//IL_01d4: Expected O, but got F4
			EME_KatanaProjectile_ScatteredPetals eME_KatanaProjectile_ScatteredPetals = _003C_003E4__this;
			bool num;
			float num2;
			float num3;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				num = flag;
				num2 = eME_KatanaProjectile_ScatteredPetals.LineSlashSpeed / 1000f;
				_003Celapsed_003E5__3 = 0f;
				num3 = _003Celapsed_003E5__3;
				_003CdurationSeconds_003E5__2 = num2;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				num3 = _003Celapsed_003E5__3;
				num2 = _003CdurationSeconds_003E5__2;
				bool flag2 = (object)_003C_003E4__this == null;
				num = flag2;
			}
			if (num2 > num3)
			{
				float amount = _003Celapsed_003E5__3 / _003CdurationSeconds_003E5__2;
				_003C_003E4__this.SetSlashPropBlock(meshRen, block, amount);
				_003C_003E4__this.SetSlashPropBlock(lightBeamMeshRen, lightBeamBlock, amount);
				object obj = Time.deltaTime;
				float num4 = num2 + _003Celapsed_003E5__3;
				_003C_003E2__current = null;
				_003Celapsed_003E5__3 = num4;
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003E4__this.SetSlashPropBlock(meshRen, block, 1f);
			_003C_003E4__this.SetSlashPropBlock(lightBeamMeshRen, lightBeamBlock, 1f);
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

	private SpriteRenderer _MoonVFX;

	private ParticleSystem _SlashVFX1;

	private ParticleSystem _SlashVFX2;

	private ParticleSystem _SlashVFX3;

	private ParticleSystem _PetalsSlashVFX1;

	private ParticleSystem _PetalsSlashVFX2;

	private ParticleSystem _PetalsSlashVFX3a;

	private ParticleSystem _PetalsSlashVFX3b;

	private ParticleSystem _KanjiVFX1;

	private ParticleSystem _KanjiVFX2;

	private ParticleSystem _KanjiVFX3;

	private MeshRenderer _SlashLine1;

	private MeshRenderer _SlashLightBeamLine1;

	private MeshRenderer _SlashLine2;

	private MeshRenderer _SlashLightBeamLine2;

	private MeshRenderer _SlashLine3;

	private MeshRenderer _SlashLightBeamLine3;

	private ParticleSystem _EndSlashesVFX;

	private float LineSlashSpeed = 200f;

	private const float MoonVFXScale = 0.75f;

	private MaterialPropertyBlock _slashLine1PropBlock;

	private MaterialPropertyBlock _slashLightBeam1PropBlock;

	private MaterialPropertyBlock _slashLine2PropBlock;

	private MaterialPropertyBlock _slashLightBeam2PropBlock;

	private MaterialPropertyBlock _slashLine3PropBlock;

	private MaterialPropertyBlock _slashLightBeam3PropBlock;

	private Timer _miniSlashTimer;

	private Timer _slashTimer;

	private Timer _bodyTimer;

	private Timer _sfxTimer;

	private MultiTargetTween _fadeTween;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _miniSlashTween;

	private EME_Katana2Weapon _trueWeapon;

	private static readonly int StepOverrideAmount;

	protected override void Awake()
	{
		base.Awake();
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		IntPtr ptr = MaterialPropertyBlock.CreateImpl();
		materialPropertyBlock.m_Ptr = ptr;
		_slashLine1PropBlock = materialPropertyBlock;
		MaterialPropertyBlock materialPropertyBlock2 = new MaterialPropertyBlock();
		IntPtr ptr2 = MaterialPropertyBlock.CreateImpl();
		materialPropertyBlock2.m_Ptr = ptr2;
		_slashLine2PropBlock = materialPropertyBlock2;
		MaterialPropertyBlock materialPropertyBlock3 = new MaterialPropertyBlock();
		IntPtr ptr3 = MaterialPropertyBlock.CreateImpl();
		materialPropertyBlock3.m_Ptr = ptr3;
		_slashLine3PropBlock = materialPropertyBlock3;
		MaterialPropertyBlock materialPropertyBlock4 = new MaterialPropertyBlock();
		IntPtr ptr4 = MaterialPropertyBlock.CreateImpl();
		materialPropertyBlock4.m_Ptr = ptr4;
		_slashLightBeam1PropBlock = materialPropertyBlock4;
		MaterialPropertyBlock materialPropertyBlock5 = new MaterialPropertyBlock();
		IntPtr ptr5 = MaterialPropertyBlock.CreateImpl();
		materialPropertyBlock5.m_Ptr = ptr5;
		_slashLightBeam2PropBlock = materialPropertyBlock5;
		MaterialPropertyBlock materialPropertyBlock6 = new MaterialPropertyBlock();
		IntPtr ptr6 = MaterialPropertyBlock.CreateImpl();
		materialPropertyBlock6.m_Ptr = ptr6;
		_slashLightBeam3PropBlock = materialPropertyBlock6;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I4, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_037b: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0399: Expected O, but got I4
		//IL_019a: Expected I4, but got O
		//IL_0474: Expected I4, but got I8
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0354;
		}
		nint num = (nint)typeof(EME_Katana2Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v45 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r9_v16 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v45 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r9_v16 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v90+FFFFFFF8+v65 @ rax_v85*8]");
			if (0 == (nint)typeof(EME_Katana2Weapon))
			{
				obj3 = 1;
				goto IL_0363;
			}
		}
		obj3 = 0;
		goto IL_0363;
		IL_0363:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0354;
		IL_0354:
		_trueWeapon = (EME_Katana2Weapon)trueWeapon;
		BaseBody baseBody = body;
		_isCullable = false;
		baseBody._enable = false;
		float num4 = _weapon.PArea();
		if ((object)_trueWeapon != null)
		{
			float num5 = default(float);
			if (2.5f > num5)
			{
				ArcadeSprite arcadeSprite = setScale(2.5f, (float?)(object)0);
				UpdatePosition();
			}
			Transform transform = _MoonVFX.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v31 (UnityEngine.Transform)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v31 (UnityEngine.Transform)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected((IntPtr)0, ref value);
			Transform transform2 = _MoonVFX.transform;
			bool flag3 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rax_v39 (UnityEngine.Transform)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rax_v39 (UnityEngine.Transform)+10]");
			Vector3 value2 = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value2);
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_MoonVFX, 0f);
			int num6 = (int)_MoonVFX;
			bool flag5 = (object)_MoonVFX == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rdi_v13 (System.Int32)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rdi_v13 (System.Int32)+10]");
			Renderer.set_sortingOrder_Injected((IntPtr)0, -1998);
			bool flag7 = (object)_SlashLine1 == null;
			GameObject gameObject = _SlashLine1.gameObject;
			bool flag8 = (object)gameObject == null;
			gameObject.SetActive(value: false);
			bool flag9 = (object)_SlashLine2 == null;
			GameObject gameObject2 = _SlashLine2.gameObject;
			bool flag10 = (object)gameObject2 == null;
			gameObject2.SetActive(value: false);
			bool flag11 = (object)_SlashLine3 == null;
			GameObject gameObject3 = _SlashLine3.gameObject;
			bool flag12 = (object)gameObject3 == null;
			gameObject3.SetActive(value: false);
			Sequence_FadeInMoon();
			if (_sfxTimer != null)
			{
				_sfxTimer.Cancel();
			}
			Action onComplete = delegate
			{
				Debug.Log("Sfx_eme_scatteredpetals1");
				PlaySfx(SfxType.Sfx_eme_scatteredpetals1);
				Action onComplete2 = delegate
				{
					Debug.Log("Sfx_eme_scatteredpetals2");
					PlaySfx(SfxType.Sfx_eme_scatteredpetals2);
					Action onComplete3 = delegate
					{
						Debug.Log("Sfx_eme_scatteredpetals3");
						PlaySfx(SfxType.Sfx_eme_scatteredpetals3);
						Action onComplete4 = delegate
						{
							Debug.Log("Sfx_eme_scatteredpetals4");
							PlaySfx(SfxType.Sfx_eme_scatteredpetals4);
						};
						bool useRealTime4 = default(bool);
						MonoBehaviour autoDestroyOwner4 = default(MonoBehaviour);
						int repeat4 = default(int);
						TimerType type4 = default(TimerType);
						Timer sfxTimer4 = Timers.Register(1.25f, onComplete4, null, isLooped: false, useRealTime4, autoDestroyOwner4, repeat4, type4, isOnlineTimer: false, canPause: false);
						_sfxTimer = sfxTimer4;
					};
					bool useRealTime3 = default(bool);
					MonoBehaviour autoDestroyOwner3 = default(MonoBehaviour);
					int repeat3 = default(int);
					TimerType type3 = default(TimerType);
					Timer sfxTimer3 = Timers.Register(0.15f, onComplete3, null, isLooped: false, useRealTime3, autoDestroyOwner3, repeat3, type3, isOnlineTimer: false, canPause: false);
					_sfxTimer = sfxTimer3;
				};
				bool useRealTime2 = default(bool);
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				TimerType type2 = default(TimerType);
				Timer sfxTimer2 = Timers.Register(0.85f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				_sfxTimer = sfxTimer2;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer sfxTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_sfxTimer = sfxTimer;
			return;
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
	}

	private void Sequence_FadeInMoon()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_MoonVFX != null)
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
		tweenConfig.duration = 750f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = Sequence_UpwardsSlash;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
		_fadeTween = fadeTween;
	}

	private void Sequence_UpwardsSlash()
	{
		//IL_00e1: Expected I4, but got O
		_trueWeapon.OnEnteredScatteredPetalStage(ScatteredPetalsStage.UpSlash);
		MeshRenderer meshRenderer = default(MeshRenderer);
		MaterialPropertyBlock materialPropertyBlock = default(MaterialPropertyBlock);
		bool flag = default(bool);
		DoSlash(_SlashVFX1, _SlashLine1, _slashLine1PropBlock, meshRenderer, materialPropertyBlock, flag);
		_PetalsSlashVFX1.Play(withChildren: true);
		_KanjiVFX1.Play(withChildren: true);
		UpwardsSlashHitBox();
		if (_slashTimer != null)
		{
			_slashTimer.Cancel();
		}
		Action onComplete = Sequence_DownwardsSlash;
		TimerType type = default(TimerType);
		Timer slashTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, (byte)(int)meshRenderer != 0, (MonoBehaviour)(object)materialPropertyBlock, flag ? 1 : 0, type, isOnlineTimer: false, canPause: false);
		_slashTimer = slashTimer;
	}

	private void Sequence_DownwardsSlash()
	{
		//IL_00b2: Expected I4, but got O
		_trueWeapon.OnEnteredScatteredPetalStage(ScatteredPetalsStage.DownSlash);
		MeshRenderer meshRenderer = default(MeshRenderer);
		MaterialPropertyBlock materialPropertyBlock = default(MaterialPropertyBlock);
		bool flag = default(bool);
		DoSlash(_SlashVFX2, _SlashLine2, _slashLine2PropBlock, meshRenderer, materialPropertyBlock, flag);
		_PetalsSlashVFX2.Play(withChildren: true);
		_KanjiVFX2.Play(withChildren: true);
		DownwardsSlashHitBox();
		Action onComplete = Sequence_MiniSlashes;
		TimerType type = default(TimerType);
		Timer slashTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, (byte)(int)meshRenderer != 0, (MonoBehaviour)(object)materialPropertyBlock, flag ? 1 : 0, type, isOnlineTimer: false, canPause: false);
		_slashTimer = slashTimer;
	}

	private void Sequence_MiniSlashes()
	{
		_EndSlashesVFX.Play(withChildren: true);
		_trueWeapon.FireScatteredPetalsMiniSlashes();
		Action onComplete = Sequence_HorizontalSlash;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer slashTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_slashTimer = slashTimer;
	}

	private void Sequence_HorizontalSlash()
	{
		//IL_00c7: Expected I4, but got O
		_trueWeapon.OnEnteredScatteredPetalStage(ScatteredPetalsStage.GroundSlash);
		MeshRenderer meshRenderer = default(MeshRenderer);
		MaterialPropertyBlock materialPropertyBlock = default(MaterialPropertyBlock);
		bool flag = default(bool);
		DoSlash(_SlashVFX3, _SlashLine3, _slashLine3PropBlock, meshRenderer, materialPropertyBlock, flag);
		_PetalsSlashVFX3a.Play(withChildren: true);
		_PetalsSlashVFX3b.Play(withChildren: true);
		_KanjiVFX3.Play(withChildren: true);
		HorizontalSlashHitBox();
		Action onComplete = Sequence_ThrowMoon;
		TimerType type = default(TimerType);
		Timer slashTimer = Timers.Register(0.1f, onComplete, null, isLooped: false, (byte)(int)meshRenderer != 0, (MonoBehaviour)(object)materialPropertyBlock, flag ? 1 : 0, type, isOnlineTimer: false, canPause: false);
		_slashTimer = slashTimer;
	}

	private void Sequence_ThrowMoon()
	{
		//IL_0338: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_008f: Expected I, but got O
		//IL_009f: Expected O, but got I
		//IL_011f: Expected O, but got I4
		//IL_00db: Expected O, but got I
		//IL_0111: Expected O, but got I4
		//IL_0187: Expected I, but got O
		//IL_01d1->IL02c3: Incompatible stack heights: 1 vs 0
		//IL_01fd->IL02c3: Incompatible stack heights: 1 vs 0
		//IL_022a->IL02c3: Incompatible stack heights: 1 vs 0
		//IL_0256->IL02c3: Incompatible stack heights: 1 vs 0
		//IL_0150->IL02c3: Incompatible stack heights: 1 vs 0
		//IL_0283->IL02c3: Incompatible stack heights: 1 vs 0
		//IL_02af->IL02c3: Incompatible stack heights: 1 vs 0
		Weapon weapon;
		object obj4;
		if ((object)_trueWeapon != null)
		{
			_trueWeapon.OnEnteredScatteredPetalStage(ScatteredPetalsStage.End);
			if ((object)_weapon != null)
			{
				GameObject gameObject = _weapon.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj != null)
					{
						weapon = _weapon;
						if ((object)_weapon != null)
						{
							nint num = (nint)typeof(EME_Katana2Weapon);
							nint num2 = (nint)weapon;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana2Weapon>)+130]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana2Weapon>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rax_v34+FFFFFFF8+v480 @ rax_v26*8]");
								if (0 == (nint)typeof(EME_Katana2Weapon))
								{
									obj4 = 1;
									goto IL_035a;
								}
							}
							obj4 = 0;
							goto IL_035a;
						}
					}
					goto IL_01a3;
				}
			}
		}
		goto IL_02c3;
		IL_035a:
		bool flag2 = obj4 == null;
		EME_Katana1Weapon eME_Katana1Weapon = null;
		if (!flag2)
		{
			eME_Katana1Weapon = (EME_Katana1Weapon)_weapon;
		}
		if ((object)eME_Katana1Weapon != null)
		{
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField == null)
			{
				goto IL_02c3;
			}
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile_ScatteredPetals>)+370]");
			Action onProjectileDespawn = new Action(this, (IntPtr)0);
			nint num4 = (nint)this;
			Vector2 vector = default(Vector2);
			eME_Katana1Weapon.FireScatteredPetalsMoon(vector, 0, onProjectileDespawn);
		}
		goto IL_01a3;
		IL_01a3:
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_MoonVFX, 0f);
		if ((object)_SlashLine1 != null)
		{
			GameObject gameObject2 = _SlashLine1.gameObject;
			if ((object)gameObject2 != null)
			{
				gameObject2.SetActive(value: false);
				if ((object)_SlashLine2 != null)
				{
					GameObject gameObject3 = _SlashLine2.gameObject;
					if ((object)gameObject3 != null)
					{
						gameObject3.SetActive(value: false);
						if ((object)_SlashLine3 != null)
						{
							GameObject gameObject4 = _SlashLine3.gameObject;
							if ((object)gameObject4 != null)
							{
								gameObject4.SetActive(value: false);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_02c3;
		IL_02c3:
		throw new NullReferenceException();
	}

	private void DoSlash(ParticleSystem slash, MeshRenderer meshRen, MaterialPropertyBlock block, MeshRenderer lightBeamMeshRen, MaterialPropertyBlock lightBeamBlock, bool finalSlash = false)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected I4, but got Unknown
		slash.Play(withChildren: true);
		object obj = default(object);
		bool yoyo = (byte)(obj ^ 1) != 0;
		ScaleMoonWhenSlashed(100f, 1.1f, yoyo);
		SetSlashPropBlock(meshRen, block, 0f);
		MeshRenderer meshRenderer = default(MeshRenderer);
		MaterialPropertyBlock block2 = default(MaterialPropertyBlock);
		SetSlashPropBlock(meshRenderer, block2, 0f);
		GameObject gameObject = meshRen.gameObject;
		gameObject.SetActive(value: true);
		MaterialPropertyBlock lightBeamBlock2 = default(MaterialPropertyBlock);
		IEnumerator<YieldInstruction> routine = DoSlash(meshRen, block, meshRenderer, lightBeamBlock2);
		Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
	}

	private void SetSlashPropBlock(MeshRenderer mesh, MaterialPropertyBlock block, float amount)
	{
		//IL_0066->IL0066: Incompatible stack heights: 2 vs 1
		((Renderer)mesh).Internal_GetPropertyBlock(block);
		bool flag = block.m_Ptr == (IntPtr)0;
		MaterialPropertyBlock.SetFloatImpl_Injected(block.m_Ptr, StepOverrideAmount, 0f);
		while (true)
		{
			bool flag2 = ((UnityEngine.Object)mesh).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		}
	}

	private IEnumerator<YieldInstruction> DoSlash(MeshRenderer meshRen, MaterialPropertyBlock block, MeshRenderer lightBeamMeshRen, MaterialPropertyBlock lightBeamBlock)
	{
		_003CDoSlash_003Ed__47 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.meshRen = meshRen;
		obj.block = block;
		obj.lightBeamMeshRen = lightBeamMeshRen;
		MaterialPropertyBlock lightBeamBlock2 = default(MaterialPropertyBlock);
		obj.lightBeamBlock = lightBeamBlock2;
		return obj;
	}

	private void SpawnMoonProjectile()
	{
		//IL_01e4: Expected O, but got I4
		//IL_0072: Expected I, but got O
		//IL_007a: Expected I, but got O
		//IL_008a: Expected O, but got I
		//IL_010a: Expected O, but got I4
		//IL_00c6: Expected O, but got I
		//IL_00fc: Expected O, but got I4
		//IL_0172: Expected I, but got O
		//IL_013b->IL018e: Incompatible stack heights: 1 vs 0
		Weapon weapon;
		object obj4;
		if ((object)_weapon != null)
		{
			GameObject gameObject = _weapon.gameObject;
			if ((object)gameObject != null)
			{
				bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
				if (obj == null)
				{
					return;
				}
				weapon = _weapon;
				if ((object)_weapon == null)
				{
					return;
				}
				nint num = (nint)typeof(EME_Katana2Weapon);
				nint num2 = (nint)weapon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana2Weapon>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana2Weapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rax_v23+FFFFFFF8+v323 @ rax_v15*8]");
					if (0 == (nint)typeof(EME_Katana2Weapon))
					{
						obj4 = 1;
						goto IL_0202;
					}
				}
				obj4 = 0;
				goto IL_0202;
			}
		}
		goto IL_018e;
		IL_0202:
		bool flag2 = obj4 == null;
		EME_Katana1Weapon eME_Katana1Weapon = null;
		if (!flag2)
		{
			eME_Katana1Weapon = (EME_Katana1Weapon)_weapon;
		}
		if ((object)eME_Katana1Weapon != null)
		{
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile_ScatteredPetals>)+370]");
				Action onProjectileDespawn = new Action(this, (IntPtr)0);
				nint num4 = (nint)this;
				Vector2 vector = default(Vector2);
				eME_Katana1Weapon.FireScatteredPetalsMoon(vector, 0, onProjectileDespawn);
				return;
			}
			goto IL_018e;
		}
		return;
		IL_018e:
		throw new NullReferenceException();
	}

	private void UpwardsSlashHitBox()
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_003a: Expected I, but got O
		//IL_004d: Expected O, but got I4
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		nint num = (nint)baseBody2;
		BaseBody baseBody3 = baseBody2.setOffset(0f, (float?)(object)1);
		BaseBody baseBody4 = body;
		baseBody4._enable = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		Action onComplete = delegate
		{
			BaseBody baseBody5 = body;
			baseBody5._enable = false;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bodyTimer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bodyTimer = bodyTimer;
	}

	private void DownwardsSlashHitBox()
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_003a: Expected I, but got O
		//IL_004d: Expected O, but got I4
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		nint num = (nint)baseBody2;
		BaseBody baseBody3 = baseBody2.setOffset(-60f, (float?)(object)1);
		BaseBody baseBody4 = body;
		baseBody4._enable = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		Action onComplete = delegate
		{
			BaseBody baseBody5 = body;
			baseBody5._enable = false;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bodyTimer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bodyTimer = bodyTimer;
	}

	private void HorizontalSlashHitBox()
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_003a: Expected I, but got O
		//IL_004d: Expected O, but got I4
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		nint num = (nint)baseBody2;
		BaseBody baseBody3 = baseBody2.setOffset(-100f, (float?)(object)1);
		BaseBody baseBody4 = body;
		baseBody4._enable = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		Action onComplete = delegate
		{
			BaseBody baseBody5 = body;
			baseBody5._enable = false;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bodyTimer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bodyTimer = bodyTimer;
	}

	private void ScaleMoonWhenSlashed(float duration, float scaleModifier = 1.1f, bool yoyo = true)
	{
		//IL_0070: Expected I, but got O
		//IL_00ee: Expected O, but got I4
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = _MoonVFX.transform;
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
		tweenConfig.duration = duration;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.yoyo = yoyo;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	private void PlaySfxSequence()
	{
		if (_sfxTimer != null)
		{
			_sfxTimer.Cancel();
		}
		Action onComplete = delegate
		{
			Debug.Log("Sfx_eme_scatteredpetals1");
			PlaySfx(SfxType.Sfx_eme_scatteredpetals1);
			Action onComplete2 = delegate
			{
				Debug.Log("Sfx_eme_scatteredpetals2");
				PlaySfx(SfxType.Sfx_eme_scatteredpetals2);
				Action onComplete3 = delegate
				{
					Debug.Log("Sfx_eme_scatteredpetals3");
					PlaySfx(SfxType.Sfx_eme_scatteredpetals3);
					Action onComplete4 = delegate
					{
						Debug.Log("Sfx_eme_scatteredpetals4");
						PlaySfx(SfxType.Sfx_eme_scatteredpetals4);
					};
					bool useRealTime4 = default(bool);
					MonoBehaviour autoDestroyOwner4 = default(MonoBehaviour);
					int repeat4 = default(int);
					TimerType type4 = default(TimerType);
					Timer sfxTimer4 = Timers.Register(1.25f, onComplete4, null, isLooped: false, useRealTime4, autoDestroyOwner4, repeat4, type4, isOnlineTimer: false, canPause: false);
					_sfxTimer = sfxTimer4;
				};
				bool useRealTime3 = default(bool);
				MonoBehaviour autoDestroyOwner3 = default(MonoBehaviour);
				int repeat3 = default(int);
				TimerType type3 = default(TimerType);
				Timer sfxTimer3 = Timers.Register(0.15f, onComplete3, null, isLooped: false, useRealTime3, autoDestroyOwner3, repeat3, type3, isOnlineTimer: false, canPause: false);
				_sfxTimer = sfxTimer3;
			};
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer sfxTimer2 = Timers.Register(0.85f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_sfxTimer = sfxTimer2;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer sfxTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_sfxTimer = sfxTimer;
	}

	private void PlaySfx(SfxType sfxType)
	{
		//IL_003c: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 500f, 1, time);
	}

	public override void Despawn()
	{
		if (_miniSlashTimer != null)
		{
			_miniSlashTimer.Cancel();
		}
		if (_slashTimer != null)
		{
			_slashTimer.Cancel();
		}
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		if (_sfxTimer != null)
		{
			_sfxTimer.Cancel();
		}
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_miniSlashTween != null)
		{
			_miniSlashTween.Kill();
		}
		base.Despawn();
	}

	static EME_KatanaProjectile_ScatteredPetals()
	{
		int stepOverrideAmount = Shader.PropertyToID("_StepOverrideAmount");
		StepOverrideAmount = stepOverrideAmount;
	}

	private void _003CUpwardsSlashHitBox_003Eb__49_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	private void _003CDownwardsSlashHitBox_003Eb__50_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	private void _003CHorizontalSlashHitBox_003Eb__51_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	private void _003CPlaySfxSequence_003Eb__53_0()
	{
		Debug.Log("Sfx_eme_scatteredpetals1");
		PlaySfx(SfxType.Sfx_eme_scatteredpetals1);
		Action onComplete = delegate
		{
			Debug.Log("Sfx_eme_scatteredpetals2");
			PlaySfx(SfxType.Sfx_eme_scatteredpetals2);
			Action onComplete2 = delegate
			{
				Debug.Log("Sfx_eme_scatteredpetals3");
				PlaySfx(SfxType.Sfx_eme_scatteredpetals3);
				Action onComplete3 = delegate
				{
					Debug.Log("Sfx_eme_scatteredpetals4");
					PlaySfx(SfxType.Sfx_eme_scatteredpetals4);
				};
				bool useRealTime3 = default(bool);
				MonoBehaviour autoDestroyOwner3 = default(MonoBehaviour);
				int repeat3 = default(int);
				TimerType type3 = default(TimerType);
				Timer sfxTimer3 = Timers.Register(1.25f, onComplete3, null, isLooped: false, useRealTime3, autoDestroyOwner3, repeat3, type3, isOnlineTimer: false, canPause: false);
				_sfxTimer = sfxTimer3;
			};
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer sfxTimer2 = Timers.Register(0.15f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_sfxTimer = sfxTimer2;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer sfxTimer = Timers.Register(0.85f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_sfxTimer = sfxTimer;
	}

	private void _003CPlaySfxSequence_003Eb__53_1()
	{
		Debug.Log("Sfx_eme_scatteredpetals2");
		PlaySfx(SfxType.Sfx_eme_scatteredpetals2);
		Action onComplete = delegate
		{
			Debug.Log("Sfx_eme_scatteredpetals3");
			PlaySfx(SfxType.Sfx_eme_scatteredpetals3);
			Action onComplete2 = delegate
			{
				Debug.Log("Sfx_eme_scatteredpetals4");
				PlaySfx(SfxType.Sfx_eme_scatteredpetals4);
			};
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer sfxTimer2 = Timers.Register(1.25f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_sfxTimer = sfxTimer2;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer sfxTimer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_sfxTimer = sfxTimer;
	}

	private void _003CPlaySfxSequence_003Eb__53_2()
	{
		Debug.Log("Sfx_eme_scatteredpetals3");
		PlaySfx(SfxType.Sfx_eme_scatteredpetals3);
		Action onComplete = delegate
		{
			Debug.Log("Sfx_eme_scatteredpetals4");
			PlaySfx(SfxType.Sfx_eme_scatteredpetals4);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer sfxTimer = Timers.Register(1.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_sfxTimer = sfxTimer;
	}

	private void _003CPlaySfxSequence_003Eb__53_3()
	{
		Debug.Log("Sfx_eme_scatteredpetals4");
		PlaySfx(SfxType.Sfx_eme_scatteredpetals4);
	}
}
