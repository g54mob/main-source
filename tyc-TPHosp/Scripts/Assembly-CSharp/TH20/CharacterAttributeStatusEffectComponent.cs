using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterAttributeStatusEffectComponent : EntityComponent
	{
		[Serializable]
		private class Config
		{
			public CharacterAttributes.Type _attribute;

			public Level[] _levels;
		}

		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public new class Level
		{
			[InspectorTooltip("Add the effect when above threshold.\nOtherwise add effect when below.")]
			public readonly bool AddWhenAbove;

			public readonly float Threshold;

			public readonly SharedInstance<CharacterStatusEffectDefinition> Effect;
		}

		[SerializeField]
		private Config _config;

		private Character _character;

		private CharacterStatusEffectDefinition _activeEffect;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
			BindCallbacks(checkCallbacks: true);
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			BindCallbacks(checkCallbacks: false);
		}

		private void BindCallbacks(bool checkCallbacks)
		{
			if (_config._levels == null)
			{
				return;
			}
			AttributeFloat attribute = _character.GetCharacterAttributes().GetAttribute(_config._attribute);
			if (attribute == null)
			{
				return;
			}
			for (int i = 0; i < _config._levels.Length; i++)
			{
				Level level = _config._levels[i];
				if (!(level.Effect != null) || level.Effect.Instance == null)
				{
					continue;
				}
				CharacterStatusEffectDefinition effect = level.Effect.Instance;
				if (level.AddWhenAbove)
				{
					attribute.LessThan(level.Threshold, delegate
					{
						RemoveEffect(effect);
					}, checkCallbacks);
					attribute.GreaterThan(level.Threshold, delegate
					{
						AddEffect(effect);
					}, checkCallbacks);
				}
				else
				{
					attribute.LessThan(level.Threshold, delegate
					{
						AddEffect(effect);
					}, checkCallbacks);
					attribute.GreaterThan(level.Threshold, delegate
					{
						RemoveEffect(effect);
					}, checkCallbacks);
				}
			}
		}

		private void AddEffect(CharacterStatusEffectDefinition effect)
		{
			if (_activeEffect != effect)
			{
				RemoveEffect(_activeEffect);
				if (_character.ModifiersComponent != null)
				{
					_character.ModifiersComponent.AddStatusEffect(effect);
				}
				_activeEffect = effect;
			}
		}

		private void RemoveEffect(CharacterStatusEffectDefinition effect)
		{
			if (_activeEffect == effect)
			{
				if (effect != null && _character.ModifiersComponent != null)
				{
					_character.ModifiersComponent.RemoveStatusEffect(effect);
				}
				_activeEffect = null;
			}
		}
	}
}
