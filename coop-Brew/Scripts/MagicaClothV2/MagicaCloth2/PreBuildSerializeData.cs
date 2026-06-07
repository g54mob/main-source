using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class PreBuildSerializeData : ITransform
	{
		public bool enabled;

		public string buildId;

		public PreBuildScriptableObject preBuildScriptableObject;

		public UniquePreBuildData uniquePreBuildData;

		public bool UsePreBuild()
		{
			return false;
		}

		public ResultCode DataValidate()
		{
			return default(ResultCode);
		}

		public SharePreBuildData GetSharePreBuildData()
		{
			return null;
		}

		public static string GenerateBuildID()
		{
			return null;
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}
	}
}
