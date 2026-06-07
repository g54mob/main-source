using System;

namespace Assets.Scripts.Terrain
{
	public class QuadRefreshJob : QuadSphereJob
	{
		public QuadScript Quad { get; private set; }

		public CreateQuadData QuadData { get; private set; }

		public QuadRefreshJob(Func<CreateQuadData> createQuadDataFactory)
		{
			QuadData = createQuadDataFactory();
		}

		public override void CancelJob(bool isMainThread)
		{
			if (isMainThread)
			{
				QuadData.TerrainMeshData.ReturnToPool();
				QuadData.WaterMeshData.ReturnToPool();
			}
			else
			{
				QuadData.TerrainMeshData.ReturnToPoolAsync();
				QuadData.WaterMeshData.ReturnToPoolAsync();
			}
			QuadData.TerrainMeshData = null;
			QuadData.WaterMeshData = null;
			Quad = null;
		}

		public override void Complete()
		{
			Quad.ReturnToPool(releaseQuad: false);
			Quad.Initialize(Quad.QuadSphere, QuadData);
			Quad.IsRefreshPending = false;
			Quad = null;
		}

		public void Initialize(QuadScript quad)
		{
			Quad = quad;
			Quad.IsRefreshPending = true;
			Quad.QuadSphere.InitializeQuadData(QuadData);
			if (quad.Parent != null)
			{
				quad.Parent.IsRefreshRequired = true;
			}
		}

		public override void Process()
		{
			Quad.QuadSphere.ProcessQuadRefreshJob(this);
			Quad.IsRefreshRequired = false;
		}
	}
}
