using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class UnderTheWeatherComponent : EntityTickComponent
	{
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		private bool _RemovedParticlesCalled;

		protected override Type ValidEntityType()
		{
			return typeof(Patient);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			SetupVisualBits();
		}

		internal override void RestoreComponentFromSave()
		{
			SetupVisualBits();
			if (_RemovedParticlesCalled)
			{
				RemoveParticles(null);
			}
			base.RestoreComponentFromSave();
		}

		private void SetupVisualBits()
		{
			AnimationEventListener animationEventListener = GetOwner<Patient>().AnimationEventListener;
			animationEventListener.RegisterEvent("TransferParticle", TransferParticles);
			animationEventListener.RegisterEvent("RemoveParticle", RemoveParticles);
		}

		private void TransferParticles(AnimationEvent animationEvent)
		{
			Patient owner = GetOwner<Patient>();
			if (owner.Visual.PfxGameObject != null)
			{
				owner.Visual.ReparentParticles(IllnessDefinition.ParticleRoot.Head);
			}
		}

		private void RemoveParticles(AnimationEvent animationEvent)
		{
			Patient owner = GetOwner<Patient>();
			if (owner.Visual.PfxGameObject != null)
			{
				owner.Visual.PfxGameObject.SetActive(value: false);
			}
			_RemovedParticlesCalled = true;
		}

		public override void Destroy()
		{
			AnimationEventListener animationEventListener = GetOwner<Patient>().AnimationEventListener;
			animationEventListener.UnregisterEvent("TransferParticle", TransferParticles);
			animationEventListener.UnregisterEvent("RemoveParticle", RemoveParticles);
			base.Destroy();
		}
	}
}
