using System;

namespace Assets.Scripts.Terrain
{
	public class QuadSplitJob : QuadSphereJob
	{
		public QuadScript Quad { get; private set; }

		public CreateQuadData[] QuadData { get; private set; }

		public QuadSplitJob(Func<CreateQuadData> createQuadDataFactory)
		{
			QuadData = new CreateQuadData[4]
			{
				createQuadDataFactory(),
				createQuadDataFactory(),
				createQuadDataFactory(),
				createQuadDataFactory()
			};
		}

		public override void CancelJob(bool isMainThread)
		{
			Quad.IsSplitJobQueued = false;
			CreateQuadData[] quadData = QuadData;
			foreach (CreateQuadData createQuadData in quadData)
			{
				if (isMainThread)
				{
					createQuadData.TerrainMeshData.ReturnToPool();
					createQuadData.WaterMeshData.ReturnToPool();
				}
				else
				{
					createQuadData.TerrainMeshData.ReturnToPoolAsync();
					createQuadData.WaterMeshData.ReturnToPoolAsync();
				}
				createQuadData.TerrainMeshData = null;
				createQuadData.WaterMeshData = null;
			}
			if (isMainThread && Quad.IsPendingReturnToPool)
			{
				Quad.ReturnToPool();
			}
			Quad = null;
		}

		public override void Complete()
		{
			if (!Quad.IsSubdivisionPending)
			{
				CancelJob(isMainThread: true);
				return;
			}
			QuadScript quad = Quad;
			QuadScript.CreateQuad(Quad.QuadSphere, QuadData[0], quad, 0);
			QuadScript.CreateQuad(Quad.QuadSphere, QuadData[1], quad, 1);
			QuadScript.CreateQuad(Quad.QuadSphere, QuadData[2], quad, 2);
			QuadScript.CreateQuad(Quad.QuadSphere, QuadData[3], quad, 3);
			Quad.IsSubdivisionPending = false;
			Quad.IsSplitJobQueued = false;
			Quad = null;
		}

		public void Initialize(QuadScript quad)
		{
			Quad = quad;
			quad.IsSubdivisionPending = true;
			CreateQuadData[] quadData = QuadData;
			foreach (CreateQuadData data in quadData)
			{
				Quad.QuadSphere.InitializeQuadData(data);
			}
		}

		public override void Process()
		{
			Quad.QuadSphere.ProcessQuadSplitJob(this);
		}
	}
}
