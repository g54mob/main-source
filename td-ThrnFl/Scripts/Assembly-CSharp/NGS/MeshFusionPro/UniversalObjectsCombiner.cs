using System;
using System.Collections.Generic;

namespace NGS.MeshFusionPro
{
	public class UniversalObjectsCombiner
	{
		private StaticObjectsCombiner _staticCombiner;

		private DynamicObjectsCombiner _dynamicCombiner;

		private LODGroupsCombiner _lodCombiner;

		public event Action<CombinedObject> onStaticCombinedObjectCreated;

		public event Action<DynamicCombinedObject> onDynamicCombinedObjectCreated;

		public event Action<CombinedLODGroup> onCombinedLODGroupCreated;

		public UniversalObjectsCombiner(ICombinedMeshFactory factory, int vertexLimit)
		{
			_staticCombiner = new StaticObjectsCombiner(factory, vertexLimit);
			_dynamicCombiner = new DynamicObjectsCombiner(factory, vertexLimit);
			_lodCombiner = new LODGroupsCombiner(factory, vertexLimit);
			_staticCombiner.onCombinedObjectCreated += delegate(CombinedObject r)
			{
				this.onStaticCombinedObjectCreated?.Invoke(r);
			};
			_dynamicCombiner.onCombinedObjectCreated += delegate(DynamicCombinedObject r)
			{
				this.onDynamicCombinedObjectCreated?.Invoke(r);
			};
			_lodCombiner.onCombinedObjectCreated += delegate(CombinedLODGroup r)
			{
				this.onCombinedLODGroupCreated?.Invoke(r);
			};
		}

		public void AddSource(ICombineSource source)
		{
			if (source is CombineSource source2)
			{
				_staticCombiner.AddSource(source2);
				return;
			}
			if (source is DynamicCombineSource source3)
			{
				_dynamicCombiner.AddSource(source3);
				return;
			}
			if (source is LODGroupCombineSource source4)
			{
				_lodCombiner.AddSource(source4);
				return;
			}
			throw new NotImplementedException("Unknown Combine Source");
		}

		public void AddSources(IEnumerable<ICombineSource> sources)
		{
			foreach (ICombineSource source in sources)
			{
				AddSource(source);
			}
		}

		public void RemoveSource(ICombineSource source)
		{
			if (source is CombineSource source2)
			{
				_staticCombiner.RemoveSource(source2);
				return;
			}
			if (source is DynamicCombineSource source3)
			{
				_dynamicCombiner.RemoveSource(source3);
				return;
			}
			if (source is LODGroupCombineSource source4)
			{
				_lodCombiner.RemoveSource(source4);
				return;
			}
			throw new NotImplementedException("Unknown Combine Source");
		}

		public void Combine()
		{
			if (_staticCombiner.ContainSources)
			{
				_staticCombiner.Combine();
			}
			if (_dynamicCombiner.ContainSources)
			{
				_dynamicCombiner.Combine();
			}
			if (_lodCombiner.ContainSources)
			{
				_lodCombiner.Combine();
			}
		}
	}
}
