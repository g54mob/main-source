using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.BlueprintSystem;
using Timberborn.Common;

namespace Timberborn.GameFactionSystem
{
	public class FactionBlueprintModifierProvider : IBlueprintModifierProvider
	{
		private ImmutableArray<BlueprintModifierSpec> _blueprintModifierSpecs;

		public string ModifierName => "Faction modifier";

		private bool Initialized => !_blueprintModifierSpecs.IsDefault;

		public void Initialize(IEnumerable<BlueprintModifierSpec> modifiers)
		{
			Asserts.IsFalse(this, Initialized, "Initialized");
			_blueprintModifierSpecs = modifiers.ToImmutableArray();
		}

		public IEnumerable<string> GetModifiers(string blueprintPath)
		{
			if (!Initialized)
			{
				yield break;
			}
			ImmutableArray<BlueprintModifierSpec>.Enumerator enumerator = _blueprintModifierSpecs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				BlueprintModifierSpec current = enumerator.Current;
				if (current.Original.Asset.Path == blueprintPath)
				{
					yield return current.Modifier.Asset.Content;
				}
			}
		}
	}
}
