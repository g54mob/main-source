using UnityEngine;

namespace TH20
{
	public class EightBitComponent : EntityComponent
	{
		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			RegisterAnimationEvents(GetOwner<Patient>());
			SetupVisuals();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RegisterAnimationEvents(GetOwner<Patient>());
			SetupVisuals();
		}

		private void RegisterAnimationEvents(Patient patient)
		{
			patient.AnimationEventListener.RegisterEvent("DisableEightBitEffect", DisableEightBitEffect);
		}

		private void DisableEightBitEffect(AnimationEvent animationEvent)
		{
			GetOwner<Character>().Visual.RetroModeEnabled = false;
		}

		private void SetupVisuals()
		{
			Patient owner = GetOwner<Patient>();
			if (owner.TreatmentOutcome != Treatment.Outcome.Cured)
			{
				owner.Visual.RetroModeEnabled = true;
			}
		}

		public override void Destroy()
		{
			Character owner = GetOwner<Character>();
			GetOwner<Patient>().AnimationEventListener.UnregisterEvent("DisableEightBitEffect", DisableEightBitEffect);
			owner.Visual.RetroModeEnabled = false;
			base.Destroy();
		}
	}
}
