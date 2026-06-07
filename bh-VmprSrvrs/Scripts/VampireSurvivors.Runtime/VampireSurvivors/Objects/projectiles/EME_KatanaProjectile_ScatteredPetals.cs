using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KatanaProjectile_ScatteredPetals : Projectile
	{
		[CompilerGenerated]
		private sealed class _003CDoSlash_003Ed__47 : IEnumerator<YieldInstruction>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private YieldInstruction _003C_003E2__current;

			public EME_KatanaProjectile_ScatteredPetals _003C_003E4__this;

			public MeshRenderer meshRen;

			public MaterialPropertyBlock block;

			public MeshRenderer lightBeamMeshRen;

			public MaterialPropertyBlock lightBeamBlock;

			private float _003CdurationSeconds_003E5__2;

			private float _003Celapsed_003E5__3;

			YieldInstruction IEnumerator<YieldInstruction>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDoSlash_003Ed__47(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private SpriteRenderer _MoonVFX;

		[SerializeField]
		private ParticleSystem _SlashVFX1;

		[SerializeField]
		private ParticleSystem _SlashVFX2;

		[SerializeField]
		private ParticleSystem _SlashVFX3;

		[SerializeField]
		private ParticleSystem _PetalsSlashVFX1;

		[SerializeField]
		private ParticleSystem _PetalsSlashVFX2;

		[SerializeField]
		private ParticleSystem _PetalsSlashVFX3a;

		[SerializeField]
		private ParticleSystem _PetalsSlashVFX3b;

		[SerializeField]
		private ParticleSystem _KanjiVFX1;

		[SerializeField]
		private ParticleSystem _KanjiVFX2;

		[SerializeField]
		private ParticleSystem _KanjiVFX3;

		[SerializeField]
		private MeshRenderer _SlashLine1;

		[SerializeField]
		private MeshRenderer _SlashLightBeamLine1;

		[SerializeField]
		private MeshRenderer _SlashLine2;

		[SerializeField]
		private MeshRenderer _SlashLightBeamLine2;

		[SerializeField]
		private MeshRenderer _SlashLine3;

		[SerializeField]
		private MeshRenderer _SlashLightBeamLine3;

		[SerializeField]
		private ParticleSystem _EndSlashesVFX;

		[SerializeField]
		private float LineSlashSpeed;

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
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePosition()
		{
		}

		private void Sequence_FadeInMoon()
		{
		}

		private void Sequence_UpwardsSlash()
		{
		}

		private void Sequence_DownwardsSlash()
		{
		}

		private void Sequence_MiniSlashes()
		{
		}

		private void Sequence_HorizontalSlash()
		{
		}

		private void Sequence_ThrowMoon()
		{
		}

		private void DoSlash(ParticleSystem slash, MeshRenderer meshRen, MaterialPropertyBlock block, MeshRenderer lightBeamMeshRen, MaterialPropertyBlock lightBeamBlock, bool finalSlash = false)
		{
		}

		private void SetSlashPropBlock(MeshRenderer mesh, MaterialPropertyBlock block, float amount)
		{
		}

		[IteratorStateMachine(typeof(_003CDoSlash_003Ed__47))]
		private IEnumerator<YieldInstruction> DoSlash(MeshRenderer meshRen, MaterialPropertyBlock block, MeshRenderer lightBeamMeshRen, MaterialPropertyBlock lightBeamBlock)
		{
			return null;
		}

		private void SpawnMoonProjectile()
		{
		}

		private void UpwardsSlashHitBox()
		{
		}

		private void DownwardsSlashHitBox()
		{
		}

		private void HorizontalSlashHitBox()
		{
		}

		private void ScaleMoonWhenSlashed(float duration, float scaleModifier = 1.1f, bool yoyo = true)
		{
		}

		private void PlaySfxSequence()
		{
		}

		private void PlaySfx(SfxType sfxType)
		{
		}

		public override void Despawn()
		{
		}
	}
}
