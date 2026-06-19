using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using JetBrains.Annotations;

namespace TH20
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class CharacterModifiersComponent : EntityTickComponent
	{
		private class ApplyInteractWithOtherModifiersParam
		{
			public Character Character;

			public CharacterAttributes Attributes;
		}

		private Character _character;

		private readonly List<CharacterModifier> _modifiers;

		private readonly Dictionary<CharacterStatusEffectDefinition, float> _statusEffects;

		private readonly List<CharacterStatusEffectDefinition> _displayedStatusEffects;

		private List<CharacterStatusEffectDefinition> _effectsToRemoveCache = new List<CharacterStatusEffectDefinition>(32);

		private ApplyInteractWithOtherModifiersParam _applyInteractWithOtherModifiersParam = new ApplyInteractWithOtherModifiersParam();

		public List<CharacterModifier> Modifiers => _modifiers;

		public Dictionary<CharacterStatusEffectDefinition, float> StatusEffects => _statusEffects;

		protected CharacterModifiersComponent()
		{
			_modifiers = new List<CharacterModifier>();
			_statusEffects = new Dictionary<CharacterStatusEffectDefinition, float>();
			_displayedStatusEffects = new List<CharacterStatusEffectDefinition>();
		}

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
		}

		public override void Destroy()
		{
			foreach (CharacterStatusEffectDefinition key in _statusEffects.Keys)
			{
				RemoveModifiers(key.Modifiers);
			}
			foreach (CharacterModifier modifier in _modifiers)
			{
				modifier.Remove(_character);
			}
			base.Destroy();
		}

		public string DebuggerDisplay()
		{
			string text = string.Empty;
			if (_statusEffects.Count == 0)
			{
				text += "\n<color=yellow>No status effects</color>";
			}
			else
			{
				foreach (KeyValuePair<CharacterStatusEffectDefinition, float> statusEffect in _statusEffects)
				{
					text += $"\nStatus effect {statusEffect.Key.NameLocalisedMale}";
				}
			}
			if (_modifiers.Count == 0)
			{
				text += "\n<color=yellow>No modifiers</color>";
			}
			else
			{
				foreach (CharacterModifier modifier in _modifiers)
				{
					text += $"\n{modifier}";
				}
			}
			return text;
		}

		public override void Tick()
		{
			float time = GameTime.time;
			for (int i = 0; i < _modifiers.Count; i++)
			{
				_modifiers[i].Update(_character);
			}
			_effectsToRemoveCache.Clear();
			foreach (KeyValuePair<CharacterStatusEffectDefinition, float> statusEffect in _statusEffects)
			{
				CharacterStatusEffectDefinition key = statusEffect.Key;
				float value = statusEffect.Value;
				if (key.HasFinished(value, time, _character))
				{
					RemoveModifiers(key.Modifiers);
					_displayedStatusEffects.Remove(key);
					_effectsToRemoveCache.Add(key);
				}
			}
			foreach (CharacterStatusEffectDefinition item in _effectsToRemoveCache)
			{
				_statusEffects.Remove(item);
			}
			base.Tick();
		}

		public void AddModifiers(CharacterModifier[] modifiers)
		{
			if (modifiers != null)
			{
				foreach (CharacterModifier modifier in modifiers)
				{
					AddModifier(modifier);
				}
			}
		}

		public void AddModifier(CharacterModifier modifier)
		{
			if (modifier != null)
			{
				_modifiers.Add(modifier);
				modifier.Add(_character);
			}
		}

		public void RemoveModifiers(CharacterModifier[] modifiers)
		{
			if (modifiers != null)
			{
				foreach (CharacterModifier modifier in modifiers)
				{
					RemoveModifier(modifier);
				}
			}
		}

		public void RemoveModifier(CharacterModifier modifier)
		{
			if (modifier != null)
			{
				_modifiers.Remove(modifier);
				modifier.Remove(_character);
			}
		}

		public void IterateModifiersOfType<P, T>(P param, Action<P, T> callback) where T : CharacterModifier
		{
			foreach (CharacterModifier modifier in _modifiers)
			{
				if (modifier is T)
				{
					callback(param, (T)modifier);
				}
			}
		}

		public void AddStatusEffect(CharacterStatusEffectDefinition statusEffect)
		{
			if (statusEffect == null || !statusEffect.IsValidForCharacter(_character))
			{
				return;
			}
			if (_statusEffects.ContainsKey(statusEffect))
			{
				_statusEffects[statusEffect] = GameTime.time;
				return;
			}
			AddModifiers(statusEffect.Modifiers);
			_statusEffects.Add(statusEffect, GameTime.time);
			if (statusEffect.DisplayInGUI)
			{
				_displayedStatusEffects.Add(statusEffect);
			}
		}

		public void RemoveStatusEffect(CharacterStatusEffectDefinition statusEffect)
		{
			if (statusEffect != null && _statusEffects.ContainsKey(statusEffect))
			{
				RemoveModifiers(statusEffect.Modifiers);
				_statusEffects.Remove(statusEffect);
				if (statusEffect.DisplayInGUI)
				{
					_displayedStatusEffects.Remove(statusEffect);
				}
			}
		}

		public void ApplyInteractWithOtherModifiers(Character character)
		{
			if (character.ModifiersComponent == null)
			{
				return;
			}
			_applyInteractWithOtherModifiersParam.Character = character;
			_applyInteractWithOtherModifiersParam.Attributes = character.GetCharacterAttributes();
			IterateModifiersOfType(_applyInteractWithOtherModifiersParam, delegate(ApplyInteractWithOtherModifiersParam param, CharacterModifierInteractWithOther modifier)
			{
				param.Attributes.GetAttribute(modifier.Type)?.Modify(modifier.Amount, 1f);
				if (modifier.StatusEffect != null && param.Character.ModifiersComponent != null)
				{
					param.Character.ModifiersComponent.AddStatusEffect(modifier.StatusEffect.Instance);
				}
			});
			_applyInteractWithOtherModifiersParam.Character = null;
			_applyInteractWithOtherModifiersParam.Attributes = null;
			GameAlgorithms.PassHygieneBetweenCharacters(_character, character);
		}

		public string GetHUDString(Character.Sex sex, string delimiter = ", ")
		{
			if (_displayedStatusEffects.Count <= 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < _displayedStatusEffects.Count; i++)
			{
				CharacterStatusEffectDefinition characterStatusEffectDefinition = _displayedStatusEffects[i];
				stringBuilder.Append(((sex == Character.Sex.Male) ? characterStatusEffectDefinition.NameLocalisedMale : characterStatusEffectDefinition.NameLocalisedFemale).Translation);
				if (i < _displayedStatusEffects.Count - 1)
				{
					stringBuilder.Append(delimiter);
				}
			}
			return stringBuilder.ToString();
		}

		public string GetTooltipText(Character.Sex sex)
		{
			string text = string.Empty;
			int count = _displayedStatusEffects.Count;
			for (int i = 0; i < count; i++)
			{
				CharacterStatusEffectDefinition characterStatusEffectDefinition = _displayedStatusEffects[i];
				LocalisedString localisedString = ((sex == Character.Sex.Male) ? characterStatusEffectDefinition.NameLocalisedMale : characterStatusEffectDefinition.NameLocalisedFemale);
				LocalisedString localisedString2 = ((sex == Character.Sex.Male) ? characterStatusEffectDefinition.DescriptionLocalisedMale : characterStatusEffectDefinition.DescriptionLocalisedFemale);
				string tooltipText = CharacterModifier.GetTooltipText(null, characterStatusEffectDefinition.Modifiers);
				text = ((!string.IsNullOrEmpty(tooltipText)) ? (text + $"<size=20>{localisedString.Translation}</size>\n{localisedString2.Translation}\n{tooltipText}\n") : (text + $"<size=20>{localisedString.Translation}</size>\n{localisedString2.Translation}\n"));
				if (count > 1 && i < count - 1)
				{
					text += "\n";
				}
			}
			return text;
		}

		public bool HasModifierOfType<T>()
		{
			foreach (CharacterModifier modifier in _modifiers)
			{
				if (modifier is T)
				{
					return true;
				}
			}
			return false;
		}
	}
}
