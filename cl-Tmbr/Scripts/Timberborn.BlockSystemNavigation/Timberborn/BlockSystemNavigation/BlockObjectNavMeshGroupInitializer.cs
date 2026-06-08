using System.Collections.Immutable;
using Timberborn.Navigation;
using Timberborn.SingletonSystem;
using Timberborn.TemplateSystem;

namespace Timberborn.BlockSystemNavigation
{
	public class BlockObjectNavMeshGroupInitializer : ILoadableSingleton
	{
		private readonly TemplateService _templateService;

		private readonly NavMeshGroupService _navMeshGroupService;

		public BlockObjectNavMeshGroupInitializer(TemplateService templateService, NavMeshGroupService navMeshGroupService)
		{
			_templateService = templateService;
			_navMeshGroupService = navMeshGroupService;
		}

		public void Load()
		{
			foreach (BlockObjectNavMeshSettingsSpec item in _templateService.GetAll<BlockObjectNavMeshSettingsSpec>())
			{
				ImmutableArray<BlockObjectNavMeshEdgeGroupSpec>.Enumerator enumerator2 = item.EdgeGroups.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					BlockObjectNavMeshEdgeGroupSpec current = enumerator2.Current;
					if (current.UseGroup)
					{
						_navMeshGroupService.GetOrAddGroupId(current.GroupName);
					}
				}
			}
		}
	}
}
