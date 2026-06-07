using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.Core
{
	internal class RefsResolver
	{
		private readonly Logger logger;

		private readonly List<Entity> resolvableEntities;

		private readonly HashSet<Entity> localKnownEntities;

		private readonly Dictionary<Entity, List<Entity>> referencedEntities;

		private readonly HashSet<Entity> unresolvableEntities;

		public IReadOnlyList<Entity> ResolvableEntities => null;

		public RefsResolver(Logger logger)
		{
		}

		public void Resolve(List<RefsInfo> info, IEntityRegistry knownEntities)
		{
		}

		private void BuildLocalKnownEntities(List<RefsInfo> info)
		{
		}

		private void BuildReferrersMapAndMarkDirectlyUnresolvable(List<RefsInfo> info, IEntityRegistry knownEntities)
		{
		}

		private void MarkUnresolvableChains(IEntityRegistry knownEntities)
		{
		}

		private void MarkResolvable(List<RefsInfo> info)
		{
		}

		private bool IsDirectlyUnresolvable(RefsInfo refsInfo, IEntityRegistry knownEntities)
		{
			return false;
		}

		private bool IsEntityUnresolvable(in Entity entity)
		{
			return false;
		}

		private void MarkUnresolvable(in Entity entity, IEntityRegistry knownEntities)
		{
		}

		private void Clear()
		{
		}
	}
}
