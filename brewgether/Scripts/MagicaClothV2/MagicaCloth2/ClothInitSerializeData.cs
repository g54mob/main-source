using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class ClothInitSerializeData : ITransform
	{
		public const int InitDataVersion = 2;

		public int initVersion;

		public int localHash;

		public int globalHash;

		public ClothProcess.ClothType clothType;

		public TransformRecordSerializeData clothTransformRecord;

		public TransformRecordSerializeData normalAdjustmentTransformRecord;

		public List<TransformRecordSerializeData> customSkinningBoneRecords;

		public List<RenderSetupSerializeData> clothSetupDataList;

		public bool HasData()
		{
			return false;
		}

		public void Clear()
		{
		}

		public ResultCode DataValidate(ClothProcess cprocess)
		{
			return default(ResultCode);
		}

		public bool Serialize(ClothSerializeData sdata, TransformRecord clothTransformRecord, TransformRecord normalAdjustmentTransformRecord, List<RenderSetupData> setupList)
		{
			return false;
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}

		private int GetLocalHash()
		{
			return 0;
		}

		private int GetGlobalHash()
		{
			return 0;
		}
	}
}
