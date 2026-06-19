using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;

namespace TH20
{
	public class CharacterTraits
	{
		private readonly string _flavourTraits;

		private readonly List<CharacterTraitDefinition> _traits;

		private readonly List<CharacterTraitDefinition> _activeTraits;

		public CharacterTraits(List<CharacterTraitDefinition> traits, string flavourTraits)
		{
			_traits = traits;
			_flavourTraits = flavourTraits;
			_activeTraits = new List<CharacterTraitDefinition>(_traits.Count);
		}

		public CharacterTraits(SharedInstance<CharacterTraitDefinition>[] traits)
		{
			_traits = new List<CharacterTraitDefinition>(traits.Length);
			_activeTraits = new List<CharacterTraitDefinition>(traits.Length);
			foreach (SharedInstance<CharacterTraitDefinition> sharedInstance in traits)
			{
				_traits.Add(sharedInstance.Instance);
			}
		}

		public string GetShortName(Character.Sex sex)
		{
			string text = string.Empty;
			for (int i = 0; i < _traits.Count; i++)
			{
				if (i != 0)
				{
					text += ", ";
				}
				text += _traits[i].GetShortName(sex).Translation;
			}
			return text;
		}

		public string GetDescription(Character.Sex sex)
		{
			string text = string.Empty;
			for (int i = 0; i < _traits.Count; i++)
			{
				text += $"•\u00a0{_traits[i].GetDescription(sex).Translation}.\n";
			}
			if (_flavourTraits != null)
			{
				string[] array = _flavourTraits.Split('.');
				for (int j = 0; j < array.Length; j++)
				{
					if (!string.IsNullOrWhiteSpace(array[j]) && LocalizationManager.TryGetTranslation(array[j], out var Translation))
					{
						if (Translation.Contains("<!-Missing Translation"))
						{
							Translation = array[j];
						}
						text += $"•\u00a0{Translation}.\n";
					}
				}
			}
			return text;
		}

		public string GetTooltipText(Character.Sex sex)
		{
			string text = string.Empty;
			int count = _traits.Count;
			for (int i = 0; i < count; i++)
			{
				CharacterTraitDefinition characterTraitDefinition = _traits[i];
				string translation = characterTraitDefinition.GetShortName(sex).Translation;
				if (characterTraitDefinition.EffectDescriptionLocalised == null || characterTraitDefinition.EffectDescriptionLocalised.Length == 0)
				{
					text += $"<size=20>{translation}</size>\n...\n";
				}
				else
				{
					LocalisedString localisedString = ((sex == Character.Sex.Male) ? characterTraitDefinition.EffectDescriptionLocalised[0] : characterTraitDefinition.EffectDescriptionLocalised[1]);
					string tooltipText = CharacterModifier.GetTooltipText(null, characterTraitDefinition.Modifiers);
					text = ((!string.IsNullOrEmpty(tooltipText)) ? (text + $"<size=20>{translation}</size>\n{localisedString.Translation}\n{tooltipText}\n") : (text + $"<size=20>{translation}</size>\n{localisedString.Translation}\n"));
				}
				if (count > 1 && i < count - 1)
				{
					text += "\n";
				}
			}
			return text;
		}

		public void Update(Character character)
		{
			CharacterModifiersComponent modifiersComponent = character.ModifiersComponent;
			if (modifiersComponent == null)
			{
				return;
			}
			foreach (CharacterTraitDefinition trait in _traits)
			{
				bool num = trait.IsActive(character);
				bool flag = _activeTraits.Contains(trait);
				if (num)
				{
					if (!flag)
					{
						_activeTraits.Add(trait);
						modifiersComponent.AddModifiers(trait.Modifiers);
					}
				}
				else if (flag)
				{
					_activeTraits.Remove(trait);
					modifiersComponent.RemoveModifiers(trait.Modifiers);
				}
			}
		}

		public void Add(CharacterTraitDefinition trait)
		{
			_traits.Add(trait);
		}

		public void Remove(Character character, CharacterTraitDefinition trait)
		{
			if (_activeTraits.Contains(trait) && character.ModifiersComponent != null)
			{
				character.ModifiersComponent.RemoveModifiers(trait.Modifiers);
			}
			_traits.Remove(trait);
			_activeTraits.Remove(trait);
		}

		public void RemoveAll(Character character)
		{
			CharacterModifiersComponent modifiersComponent = character.ModifiersComponent;
			if (modifiersComponent != null)
			{
				foreach (CharacterTraitDefinition activeTrait in _activeTraits)
				{
					modifiersComponent.RemoveModifiers(activeTrait.Modifiers);
				}
			}
			_traits.Clear();
			_activeTraits.Clear();
		}

		public void IterateAllModifiers<T, P>(P parameter, Action<P, T, CharacterTraitDefinition> callback) where T : CharacterModifier
		{
			Type typeFromHandle = typeof(T);
			foreach (CharacterTraitDefinition trait in _traits)
			{
				if (trait.Modifiers == null)
				{
					continue;
				}
				CharacterModifier[] modifiers = trait.Modifiers;
				foreach (CharacterModifier characterModifier in modifiers)
				{
					if (characterModifier.GetType() == typeFromHandle)
					{
						callback(parameter, (T)characterModifier, trait);
					}
				}
			}
		}

		public void IterateActiveModifiers<T, P>(P parameter, Action<P, T, CharacterTraitDefinition> callback) where T : CharacterModifier
		{
			Type typeFromHandle = typeof(T);
			foreach (CharacterTraitDefinition activeTrait in _activeTraits)
			{
				if (activeTrait.Modifiers == null)
				{
					continue;
				}
				CharacterModifier[] modifiers = activeTrait.Modifiers;
				foreach (CharacterModifier characterModifier in modifiers)
				{
					if (characterModifier.GetType() == typeFromHandle)
					{
						callback(parameter, (T)characterModifier, activeTrait);
					}
				}
			}
		}

		public bool HasTrait(CharacterTraitDefinition trait)
		{
			return _activeTraits.Contains(trait);
		}
	}
}
