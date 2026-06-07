using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class UniquePreBuildData : ITransform
	{
		public int version;

		public ResultCode buildResult;

		public List<RenderSetupData.UniqueSerializationData> renderSetupDataList;

		public VirtualMesh.UniqueSerializationData proxyMesh;

		public List<VirtualMesh.UniqueSerializationData> renderMeshList;

		public ResultCode DataValidate()
		{
			return default(ResultCode);
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}
	}
}
