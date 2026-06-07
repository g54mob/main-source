using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors
{
	public class DraculaCutsceneWineGlass : ArcadeSprite
	{
		[CompilerGenerated]
		private sealed class _003CThrowCoroutine_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutsceneWineGlass _003C_003E4__this;

			public float delay;

			public Vector2 startPosition;

			public Vector2 endPosition;

			private float _003Ctimer_003E5__2;

			private Quaternion _003CendRotation_003E5__3;

			object IEnumerator<object>.Current
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
			public _003CThrowCoroutine_003Ed__16(int _003C_003E1__state)
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
		private AnimationCurve _xAnimationCurve;

		[SerializeField]
		private AnimationCurve _yAnimationCurve;

		[SerializeField]
		private float _ThrowDuration;

		[SerializeField]
		private float _ThrowEndRotation;

		[SerializeField]
		private PhaserSprite _ImpactExplosion;

		[SerializeField]
		private ParticleSystem _WineGlassImpactParticles;

		private MultiTargetTween _scaleTween;

		private const string WineGlassSpriteName = "TP_VFX_WineGlass01";

		private const string WineGlassAnimName = "TP_VFX_WineGlass";

		private const string WineGlassParticleSpriteName = "TP_VFX_WineGlass04";

		private const string ThosePeopleTextureName = "ThosePeople";

		private const string ExplodeAnimName = "explode";

		private readonly List<SfxType> _glassLight;

		public void InitWineGlass()
		{
		}

		public void ThrowWineGlass(float delay, Vector2 startPosition, Vector2 endPosition)
		{
		}

		private void InitImpactExplosion()
		{
		}

		[IteratorStateMachine(typeof(_003CThrowCoroutine_003Ed__16))]
		private IEnumerator ThrowCoroutine(float delay, Vector2 startPosition, Vector2 endPosition)
		{
			return null;
		}

		private void BreakOnImpact()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
