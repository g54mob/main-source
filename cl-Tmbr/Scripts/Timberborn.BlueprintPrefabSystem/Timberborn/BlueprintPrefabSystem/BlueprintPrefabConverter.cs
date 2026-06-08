using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.BlueprintSystem;
using UnityEngine;

namespace Timberborn.BlueprintPrefabSystem
{
	public class BlueprintPrefabConverter
	{
		private readonly ImmutableArray<ISpecToPrefabConverter> _specToPrefabConverters;

		public BlueprintPrefabConverter(IEnumerable<ISpecToPrefabConverter> specToPrefabConverters)
		{
			_specToPrefabConverters = specToPrefabConverters.ToImmutableArray();
		}

		public GameObject Convert(Blueprint blueprint, Transform parent)
		{
			GameObject gameObject = new GameObject(blueprint.Name);
			gameObject.transform.SetParent(parent.transform);
			ImmutableArray<ComponentSpec>.Enumerator enumerator = blueprint.Specs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ComponentSpec current = enumerator.Current;
				ImmutableArray<ISpecToPrefabConverter>.Enumerator enumerator2 = _specToPrefabConverters.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ISpecToPrefabConverter current2 = enumerator2.Current;
					if (current2.CanConvert(current))
					{
						current2.Convert(gameObject, current);
					}
				}
			}
			ImmutableArray<Blueprint>.Enumerator enumerator3 = blueprint.Children.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				Blueprint current3 = enumerator3.Current;
				Convert(current3, gameObject.transform);
			}
			return gameObject;
		}
	}
}
