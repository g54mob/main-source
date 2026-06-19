using System;
using UnityEngine;

namespace TH20
{
	public class ElectricShockComponent : EntityTickComponent
	{
		private bool _isAnimating;

		private float _remainingFlashTime;

		private float _flickerDuration;

		private CharacterShockEffectConfig _config;

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_config = base.Level.VisualManager.VisualManagerConfig.CharacterShockEffectConfig;
			Character owner = GetOwner<Character>();
			RegisterAnimationEvents(owner);
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			_config = base.Level.VisualManager.VisualManagerConfig.CharacterShockEffectConfig;
			Character owner = GetOwner<Character>();
			RegisterAnimationEvents(owner);
		}

		private void RegisterAnimationEvents(Character character)
		{
			character.AnimationEventListener.RegisterEvent("PlayElectricShockEffect", PlayElectricShockEffect);
		}

		public override void Destroy()
		{
			Character owner = GetOwner<Character>();
			owner.AnimationEventListener.UnregisterEvent("PlayElectricShockEffect", PlayElectricShockEffect);
			if (_isAnimating)
			{
				owner.Visual.ShockModeEnabled = false;
			}
			base.Destroy();
		}

		private void PlayElectricShockEffect(AnimationEvent animationEvent)
		{
			GetOwner<Character>().Visual.ShockModeEnabled = true;
			_isAnimating = true;
			_remainingFlashTime = animationEvent.floatParameter;
			_flickerDuration = UnityEngine.Random.Range(_config.FlickerDurationMin, _config.FlickerDurationMax);
		}

		public override void Tick()
		{
			base.Tick();
			if (!_isAnimating)
			{
				return;
			}
			Character owner = GetOwner<Character>();
			_remainingFlashTime -= Time.deltaTime;
			float num = Mathf.Repeat(_remainingFlashTime, _flickerDuration);
			if (num < _flickerDuration * 0.5f)
			{
				if (owner.Visual.ShockModeEnabled)
				{
					owner.Visual.ShockModeEnabled = false;
				}
			}
			else
			{
				if (!owner.Visual.ShockModeEnabled)
				{
					owner.Visual.ShockModeEnabled = true;
					for (int i = 0; i < 3; i++)
					{
						Transform transform = owner.Visual.RigBones.RandomItem();
						base.Level.VisualManager.ElectricBoltManager.SpawnBolt(transform.position, Quaternion.LookRotation(UnityEngine.Random.onUnitSphere), Mathf.Min(_flickerDuration * 0.5f, _remainingFlashTime));
					}
				}
				float num2 = (num - _flickerDuration * 0.5f) / (_flickerDuration * 0.5f);
				num2 = Mathf.Sin(num2 * (float)Math.PI);
				Color shockColor = _config.ShockColor;
				if (owner.Visual.OverlayInstances != null)
				{
					foreach (CharModule.ModuleInstance overlayInstance in owner.Visual.OverlayInstances)
					{
						overlayInstance.OriginalMaterials[0].color = shockColor * num2;
						TH20Standard.SetEmissiveColor(overlayInstance.OriginalMaterials[0], shockColor * num2 * _config.EmissiveAmount);
					}
				}
			}
			if (_remainingFlashTime < 0f)
			{
				owner.Visual.ShockModeEnabled = false;
				_isAnimating = false;
			}
		}
	}
}
