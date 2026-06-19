using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class IllnessGreyAnatomyComponent : EntityTickComponent
	{
		private bool _animateRed;

		private bool _animateGreen;

		private bool _animateBlue;

		private float _redDuration = 1f;

		private float _greenDuration = 1f;

		private float _blueDuration = 1f;

		private float _redCurrentTime;

		private float _greenCurrentTime;

		private float _blueCurrentTime;

		protected override Type ValidEntityType()
		{
			return typeof(Patient);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			Patient owner = GetOwner<Patient>();
			SetMaterialState(owner);
			RegisterAnimationEvents(owner);
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			Patient owner = GetOwner<Patient>();
			SetMaterialState(owner);
			RegisterAnimationEvents(owner);
		}

		private static void SetMaterialState(Patient patient)
		{
			if (patient.TreatmentOutcome != Treatment.Outcome.Cured)
			{
				patient.Visual.GreyAnatomyModeEnabled = true;
			}
		}

		private void RegisterAnimationEvents(Patient patient)
		{
			AnimationEventListener animationEventListener = patient.AnimationEventListener;
			animationEventListener.RegisterEvent("GrayAnatomyIncreaseRed", StartRedEvent);
			animationEventListener.RegisterEvent("GrayAnatomyIncreaseGreen", StartGreenEvent);
			animationEventListener.RegisterEvent("GrayAnatomyIncreaseBlue", StartBlueEvent);
		}

		public override void Destroy()
		{
			AnimationEventListener animationEventListener = GetOwner<Patient>().AnimationEventListener;
			animationEventListener.UnregisterEvent("GrayAnatomyIncreaseRed", StartRedEvent);
			animationEventListener.UnregisterEvent("GrayAnatomyIncreaseGreen", StartGreenEvent);
			animationEventListener.UnregisterEvent("GrayAnatomyIncreaseBlue", StartBlueEvent);
			base.Destroy();
		}

		private void StartRedEvent(AnimationEvent animationEvent)
		{
			_animateRed = true;
			_redDuration = animationEvent.floatParameter;
		}

		private void StartGreenEvent(AnimationEvent animationEvent)
		{
			_animateGreen = true;
			_greenDuration = animationEvent.floatParameter;
		}

		private void StartBlueEvent(AnimationEvent animationEvent)
		{
			_animateBlue = true;
			_blueDuration = animationEvent.floatParameter;
		}

		public override void Tick()
		{
			if (!_animateRed && !_animateGreen && !_animateBlue)
			{
				return;
			}
			Patient owner = GetOwner<Patient>();
			Vector3 zero = Vector3.zero;
			if (_animateRed)
			{
				_redCurrentTime += Time.deltaTime;
				if (_redCurrentTime > _redDuration)
				{
					_animateRed = false;
				}
			}
			if (_animateGreen)
			{
				_greenCurrentTime += Time.deltaTime;
				if (_greenCurrentTime > _greenDuration)
				{
					_animateGreen = false;
				}
			}
			if (_animateBlue)
			{
				_blueCurrentTime += Time.deltaTime;
				if (_blueCurrentTime > _blueDuration)
				{
					_animateBlue = false;
				}
			}
			zero.x = Mathf.Clamp01(_redCurrentTime / _redDuration);
			zero.y = Mathf.Clamp01(_greenCurrentTime / _greenDuration);
			zero.z = Mathf.Clamp01(_blueCurrentTime / _blueDuration);
			foreach (CharModule.ModuleInstance moduleInstance in owner.Visual.ModuleInstances)
			{
				Material[] sharedMaterials = moduleInstance.Renderer.sharedMaterials;
				for (int i = 0; i < sharedMaterials.Length; i++)
				{
					if (TH20Standard.IsTH20Standard(sharedMaterials[i]))
					{
						TH20Standard.SetGrayAnatomyRGBStrength(sharedMaterials[i], zero);
					}
				}
			}
			if (_redCurrentTime > _redDuration && _greenCurrentTime > _greenDuration && _blueCurrentTime > _blueDuration)
			{
				owner.Visual.GreyAnatomyModeEnabled = false;
				Destroy();
			}
		}
	}
}
