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

		internal void DisposeRenderer(int renderKey)
		{
			if (TryGetData(renderKey, out var result))
			{
				Remove(renderKey);
				result.Dispose();
			}
		}
	}
}
