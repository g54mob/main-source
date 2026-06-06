using System;
using System.Collections.Generic;
using System.Text;
using Unity.Profiling;

namespace MagicaCloth2
{
	public class PreBuildManager : IManager, IDisposable, IValid
	{
		internal class ShareDeserializationData : IDisposable
		{
			internal string buildId;

			internal ResultCode result;

			internal int referenceCount;

			internal List<RenderSetupData> renderSetupDataList;

			internal VirtualMesh proxyMesh;

			internal List<VirtualMesh> renderMeshList;

			internal DistanceConstraint.ConstraintData distanceConstraintData;

			internal TriangleBendingConstraint.ConstraintData bendingConstraintData;

			internal InertiaConstraint.ConstraintData inertiaConstraintData;

			public int RenderMeshCount => 0;

			public void Dispose()
			{
			}

			public void Deserialize(SharePreBuildData sharePreBuilddata)
			{
			}

			public VirtualMeshContainer GetProxyMeshContainer()
			{
				return null;
			}

			public VirtualMeshContainer GetRenderMeshContainer(int index)
			{
				return null;
			}
		}

		private Dictionary<SharePreBuildData, ShareDeserializationData> deserializationDict;

		private bool isValid;

		private static readonly ProfilerMarker deserializationProfiler;

		public void Dispose()
		{
		}

		public void EnterdEditMode()
		{
		}

		public void Initialize()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public void InformationLog(StringBuilder allsb)
		{
		}

		internal ShareDeserializationData RegisterPreBuildData(SharePreBuildData sdata, bool referenceIncrement)
		{
			return null;
		}

		internal ShareDeserializationData GetPreBuildData(SharePreBuildData sdata)
		{
			return null;
		}

		internal void UnregisterPreBuildData(SharePreBuildData sdata)
		{
		}

		internal void UnloadUnusedData()
		{
		}
	}
}
