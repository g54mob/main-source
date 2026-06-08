using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.BehaviorSystem;
using Timberborn.Buildings;
using Timberborn.EntitySystem;
using Timberborn.Navigation;
using Timberborn.PrioritySystem;
using Timberborn.WorkSystem;

namespace Timberborn.BuilderHubSystem
{
	public class BuilderHubWorkplaceBehavior : WorkplaceBehavior, IInitializableEntity
	{
		private readonly ImmutableArray<IBuilderJobProvider> _providers;

		private Accessible _accessible;

		public BuilderHubWorkplaceBehavior(IEnumerable<IBuilderJobProvider> builderJobProviders)
		{
			_providers = builderJobProviders.OrderBy((IBuilderJobProvider provider) => provider.ProviderPriority).ToImmutableArray();
		}

		public void InitializeEntity()
		{
			_accessible = GetComponent<BuildingAccessible>().Accessible;
		}

		public override Decision Decide(BehaviorAgent agent)
		{
			ImmutableArray<Priority>.Enumerator enumerator = Priorities.Descending.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Priority current = enumerator.Current;
				ImmutableArray<IBuilderJobProvider>.Enumerator enumerator2 = _providers.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					var (behavior, decision) = enumerator2.Current.GetJob(_accessible, agent, current);
					if (!decision.ShouldReleaseNow)
					{
						return Decision.TransferNow(behavior, in decision);
					}
				}
			}
			return Decision.ReleaseNow();
		}
	}
}
