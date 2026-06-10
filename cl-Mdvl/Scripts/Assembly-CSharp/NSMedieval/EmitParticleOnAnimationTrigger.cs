using NSEipix.Base;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Scripts.Pooler;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval
{
	public class EmitParticleOnAnimationTrigger : MonoBehaviour
	{
		[SerializeField]
		private Transform leftArm;

		[SerializeField]
		private Transform rightArm;

		[SerializeField]
		private Transform leftFoot;

		[SerializeField]
		private Transform rightFoot;

		[SerializeField]
		private Transform pelvis;

		private GameObject particlesFootstepInstance;

		private AnimatedAgentView agent;

		public Transform LeftArm => leftArm;

		public Transform RightArm => rightArm;

		public Transform LeftFoot => leftFoot;

		public Transform RightFoot => rightFoot;

		public Transform Pelvis => pelvis;

		public void PlayParticlesOnAnimationTrigger(Limbs limb)
		{
			if (!MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.EnvironmentFootprintsParticles)
			{
				return;
			}
			switch (limb)
			{
			case Limbs.LeftArm:
				if (!(leftArm == null))
				{
					MonoSingleton<Footprints>.Instance.Footprint(agent, "left", leftArm);
				}
				break;
			case Limbs.RightArm:
				if (!(rightArm == null))
				{
					MonoSingleton<Footprints>.Instance.Footprint(agent, "right", rightArm);
				}
				break;
			case Limbs.LeftFoot:
				if (!(leftFoot == null))
				{
					MonoSingleton<Footprints>.Instance.Footprint(agent, "left", leftFoot);
				}
				break;
			case Limbs.RightFoot:
				if (!(rightFoot == null))
				{
					MonoSingleton<Footprints>.Instance.Footprint(agent, "right", rightFoot);
				}
				break;
			}
		}

		public void PlaySplashOnAnimationTrigger(Limbs limb)
		{
			if (!MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.EnvironmentParticles)
			{
				return;
			}
			switch (limb)
			{
			case Limbs.LeftArm:
				if (!(leftArm == null))
				{
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("water_splash", leftArm);
				}
				break;
			case Limbs.RightArm:
				if (!(rightArm == null))
				{
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("water_splash", rightArm);
				}
				break;
			case Limbs.LeftFoot:
				if (!(leftFoot == null))
				{
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("water_splash", leftFoot);
				}
				break;
			case Limbs.RightFoot:
				if (!(rightFoot == null))
				{
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("water_splash", rightFoot);
				}
				break;
			}
		}

		private void Start()
		{
			if (base.gameObject.TryGetComponent<AnimatedAgentView>(out var component))
			{
				agent = component;
			}
		}
	}
}
