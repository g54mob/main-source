using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class SharePreBuildData
	{
		public int version;

		public string buildId;

		public ResultCode buildResult;

		public Vector3 buildScale;

		public List<RenderSetupData.ShareSerializationData> renderSetupDataList;

		public VirtualMesh.ShareSerializationData proxyMesh;

		public List<VirtualMesh.ShareSerializationData> renderMeshList;

		public DistanceConstraint.ConstraintData distanceConstraintData;

		public TriangleBendingConstraint.ConstraintData bendingConstraintData;

		public InertiaConstraint.ConstraintData inertiaConstraintData;

		public ResultCode DataValidate()
		{
			return default(ResultCode);
		}

		public bool CheckBuildId(string buildId)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
