using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIRenderSourceProvider : GPUIDataProvider<int, GPUIRenderSource>
	{
		public override void Dispose()
		{
			if (_dataDict != null)
			{
				foreach (GPUIRenderSource value in base.Values)
				{
					value?.Dispose();
				}
			}
			base.Dispose();
		}

		internal bool TryCreateRenderSource(Object source, GPUIRenderSourceGroup renderSourceGroup, out GPUIRenderSource renderSource)
		{
			renderSource = new GPUIRenderSource(source, renderSourceGroup);
			if (renderSourceGroup.AddRenderSource(renderSource))
			{
				AddOrSet(renderSource.Key, renderSource);
				GPUIRenderingSystem.Instance.OnCreatedRenderSource(renderSource);
				return true;
			}
			return false;
		}

		internal void DisposeRenderer(int renderKey)
		{
			if (TryGetData(renderKey, out var result))
			{
				Remove(renderKey);
				result.Dispose();
				GPUIRenderingSystem.Instance.OnRemovedRenderSource(renderKey);
			}
		}
	}
}
