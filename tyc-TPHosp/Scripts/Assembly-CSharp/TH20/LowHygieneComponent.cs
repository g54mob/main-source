using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class LowHygieneComponent : EntityTickComponent
	{
		private Character _character;

		private AttributeFloat _hygieneAttribute;

		private CharacterStatusEffectDefinition _statusEffect;

		private float _timeUntilNextCheck;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			SetComponentTickEnabled(enabled: false);
			_character = GetOwner<Character>();
			_hygieneAttribute = _character.GetCharacterAttributes().GetAttribute(CharacterAttributes.Type.Hygiene);
			ListenForHygieneChanges(checkCallback: true);
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			ListenForHygieneChanges(checkCallback: false);
		}

		private void ListenForHygieneChanges(bool checkCallback)
		{
			if (_hygieneAttribute != null)
			{
				_hygieneAttribute.LessThan(_character.Definition.HygieneLowStatusEffectThreshold, EnableStatusEffect, checkCallback);
				_hygieneAttribute.GreaterThan(_character.Definition.HygieneLowStatusEffectThreshold, DisableStatusEffect, checkCallback);
			}
		}

		public override void Destroy()
		{
			if (_hygieneAttribute != null)
			{
				_hygieneAttribute.RemoveCallback(EnableStatusEffect);
				_hygieneAttribute.RemoveCallback(DisableStatusEffect);
			}
			DisableStatusEffect();
			base.Destroy();
		}

		private void EnableStatusEffect()
		{
			SetComponentTickEnabled(enabled: true);
		}

		private void DisableStatusEffect()
		{
			SetComponentTickEnabled(enabled: false);
			if (_statusEffect != null)
			{
				_character.GetComponent<CharacterModifiersComponent>()?.RemoveStatusEffect(_statusEffect);
			}
		}

		private bool ChooseRandomStatusEffect()
		{
			int num = RandomUtils.GlobalRandomInstance.Next(0, 100);
			CharacterManager characterManager = _character.Level.CharacterManager;
			if (num >= characterManager.ChanceOfLowHygieneEffect)
			{
				List<CharacterStatusEffectDefinition> lowHygieneStatusEffects = characterManager.LowHygieneStatusEffects;
				if (lowHygieneStatusEffects.Count != 0)
				{
					CharacterModifiersComponent component = _character.GetComponent<CharacterModifiersComponent>();
					if (component != null)
					{
						_statusEffect = lowHygieneStatusEffects.RandomItem();
						component.AddStatusEffect(_statusEffect);
					}
					return true;
				}
			}
			return false;
		}

		public override void Tick()
		{
			base.Tick();
			_timeUntilNextCheck -= Time.deltaTime;
			if (_timeUntilNextCheck <= 0f)
			{
				_timeUntilNextCheck += _character.Level.CharacterManager.LowHygieneChanceCheckInterval;
				if (ChooseRandomStatusEffect())
				{
					SetComponentTickEnabled(enabled: false);
				}
			}
		}
	}
}
