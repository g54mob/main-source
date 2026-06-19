using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IllnessRemoveParticleComponent : EntityTickComponent
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
			GetOwner<Patient>().AnimationEventListener.RegisterEvent("RemoveParticle", RemoveParticles);
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
			GetOwner<Patient>().AnimationEventListener.UnregisterEvent("RemoveParticle", RemoveParticles);
			base.Destroy();
		}
	}
}
