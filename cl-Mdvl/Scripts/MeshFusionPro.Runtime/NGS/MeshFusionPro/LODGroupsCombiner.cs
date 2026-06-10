using System.Collections.Generic;

namespace NGS.MeshFusionPro
{
	public class LODGroupsCombiner : ObjectsCombiner<CombinedLODGroup, LODGroupCombineSource>
	{
		private ICombinedMeshFactory _factory;

		private CombinedLODGroupMatcher _matcher;

		private int _vertexLimit;

		public LODGroupsCombiner(ICombinedMeshFactory factory, int vertexLimit)
		{
			_factory = factory;
			_matcher = new CombinedLODGroupMatcher();
			_vertexLimit = vertexLimit;
		}

		protected override CombinedLODGroup CreateCombinedObject(LODGroupCombineSource source)
		{
			return CombinedLODGroup.Create(_factory, source, _vertexLimit);
		}

		protected override void CombineSources(CombinedLODGroup root, IList<LODGroupCombineSource> sources)
		{
			root.Combine(sources);
		}

		protected override CombinedObjectMatcher<CombinedLODGroup, LODGroupCombineSource> GetMatcher()
		{
			return _matcher;
		}
	}
}
