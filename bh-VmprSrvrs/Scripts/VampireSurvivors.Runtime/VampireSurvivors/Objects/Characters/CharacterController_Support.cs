using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Characters
{
	[DefaultExecutionOrder(851)]
	public class CharacterController_Support
	{
		public class TemporaryEffect
		{
			public ParticleSystem ParticleSystem;

			public int Actives;

			public MultiTargetTween Tween;

			public List<float> ActiveValueChanges;
		}

		[NonSerialized]
		public float RapidFire_Life;

		[NonSerialized]
		public float HeartRefresh_Life;

		[NonSerialized]
		public float MirrorOfTruth_Life;

		private TemporaryEffect _rapidFireEffect;

		private TemporaryEffect _heartRefreshEffect;

		private KarmaCoinVFX _lastKarmaCoinVFX;

		private int _karmaCoinCount;

		private HeartRefreshVFX _lastHeartRefreshVFX;

		private TemporaryEffect _mirrorOfTruthEffect;

		private readonly CharacterController controller;

		public CharacterController_Support(CharacterController controller)
		{
		}

		public void InternalUpdate()
		{
		}

		private void InitRapidFireEffect()
		{
		}

		public void AddActiveRapidFire(float cooldownChange, float speedChange, float duration)
		{
		}

		private void InitHeartRefreshEffect()
		{
		}

		public void AddActiveHeartRefresh(float statChange1, float statChange2, float duration)
		{
		}

		public void AddKarmaCoin()
		{
		}

		private void ActivateKarmaCoin(float pLuck)
		{
		}

		private void ApplyKarmaCoinEffect()
		{
		}

		private void InitMirrorOfTruthEffect()
		{
		}

		public void AddActiveMirrorOfTruth(float statChange1, float statChange2, float duration)
		{
		}
	}
}
