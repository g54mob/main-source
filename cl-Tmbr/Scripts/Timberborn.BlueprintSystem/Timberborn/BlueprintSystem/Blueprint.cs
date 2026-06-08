using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Timberborn.BlueprintSystem
{
	public class Blueprint
	{
		public string Name { get; }

		public ImmutableArray<Blueprint> Children { get; }

		public ImmutableArray<ComponentSpec> Specs { get; }

		public Blueprint(string name, IEnumerable<ComponentSpec> specs, ImmutableArray<Blueprint> children)
		{
			Name = name;
			Specs = CopySpecs(specs, null, null);
			Children = children;
			ValidateChildrenNames();
		}

		public Blueprint(Blueprint originalBlueprint, ComponentSpec originalSpec, ComponentSpec newSpec)
		{
			Name = originalBlueprint?.Name;
			Specs = CopySpecs(originalBlueprint?.Specs, originalSpec, newSpec);
			Children = CopyChildren(originalBlueprint);
			ValidateChildrenNames();
		}

		public bool HasSpec<T>()
		{
			return GetSpec<T>() != null;
		}

		public T GetSpec<T>()
		{
			ImmutableArray<ComponentSpec>.Enumerator enumerator = Specs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ComponentSpec current = enumerator.Current;
				if (current is T)
				{
					return (T)(object)((current is T) ? current : null);
				}
			}
			return default(T);
		}

		public object GetSpec(Type componentType)
		{
			ImmutableArray<ComponentSpec>.Enumerator enumerator = Specs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ComponentSpec current = enumerator.Current;
				if (current.GetType() == componentType)
				{
					return current;
				}
			}
			return null;
		}

		public void GetSpecs<T>(List<T> specs)
		{
			ImmutableArray<ComponentSpec>.Enumerator enumerator = Specs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current is T item)
				{
					specs.Add(item);
				}
			}
		}

		public bool IsAllowedByFeatureToggles()
		{
			RequiredFeatureToggleSpec spec = GetSpec<RequiredFeatureToggleSpec>();
			DisablingFeatureToggleSpec spec2 = GetSpec<DisablingFeatureToggleSpec>();
			if ((object)spec == null || !spec.Disabled)
			{
				return !(spec2?.Disabled ?? false);
			}
			return false;
		}

		private ImmutableArray<ComponentSpec> CopySpecs(IEnumerable<ComponentSpec> specsToCopy, ComponentSpec specToIgnore, ComponentSpec specToAdd)
		{
			List<ComponentSpec> list = new List<ComponentSpec>();
			if (specsToCopy != null)
			{
				foreach (ComponentSpec item in specsToCopy)
				{
					if (item != specToIgnore)
					{
						item.DisableBlueprintCopying = true;
						list.Add(item with
						{
							Blueprint = this
						});
						item.DisableBlueprintCopying = false;
					}
				}
			}
			if (specToAdd != null)
			{
				list.Add(specToAdd);
			}
			return list.ToImmutableArray();
		}

		private static ImmutableArray<Blueprint> CopyChildren(Blueprint originalBlueprint)
		{
			List<Blueprint> list = new List<Blueprint>();
			if (originalBlueprint != null)
			{
				ImmutableArray<Blueprint>.Enumerator enumerator = originalBlueprint.Children.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Blueprint current = enumerator.Current;
					list.Add(new Blueprint(current, null, null));
				}
			}
			return list.ToImmutableArray();
		}

		private void ValidateChildrenNames()
		{
			HashSet<string> hashSet = new HashSet<string>();
			ImmutableArray<Blueprint>.Enumerator enumerator = Children.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Blueprint current = enumerator.Current;
				if (!hashSet.Add(current.Name))
				{
					throw new InvalidOperationException("Duplicate child name found: " + current.Name + " in Blueprint " + Name);
				}
			}
		}
	}
}
